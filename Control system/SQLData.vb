Imports ControlSystemLibrary
Imports System.Data
Imports System.Data.SqlClient
Public Module SQLData
    Dim con As SqlConnection
    Public Sub ReadStartData()
        Dim str As String = "Data Source=TL-APRO-NPC08\SQLEXPRESS;Integrated Security=True"
        con = New SqlConnection(str)
        con.Open()

		ReadHost()
		ReadEndDevices()
		ReadLineGroup()
		ReadPart()
		ReadAGV()

    End Sub
    Public Sub setAGVSupply(ByVal AGVnumber As Byte, ByVal PartString As String)
        If PartString.ToLower = "all" Then
            For i As Byte = 0 To PartArray.Length - 1
                AGVnPART(AGVnumber, i) = True
            Next
        Else
            Dim str As String() = PartString.Split(";")
            For i As Byte = 0 To str.Length - 1
                AGVnPART(AGVnumber, Byte.Parse(str(i))) = True
            Next
        End If
	End Sub
	Private Sub ReadHost()
		Dim myDataAdapter As SqlDataAdapter
		Dim myDataTable As DataTable
		'Read Host Xbee information 
		myDataAdapter = New SqlDataAdapter("SELECT * FROM HostXbee", con)
		myDataTable = New DataTable
		myDataAdapter.Fill(myDataTable)
		HostXbee = New XBee(myDataTable.Rows.Count - 1) {}
		For i As Byte = 0 To myDataTable.Rows.Count - 1
			HostXbee(i) = New XBee()
			HostXbee(i).Address = myDataTable.Rows(i)("Address")
		Next
	End Sub
	Private Sub ReadEndDevices()
		Dim myDataAdapter As SqlDataAdapter
		Dim myDataTable As DataTable
		'Read End devices information 
		myDataAdapter = New SqlDataAdapter("SELECT * FROM EndDevices", con)
		myDataTable = New DataTable
		myDataAdapter.Fill(myDataTable)
		EndDevicesArray = New EndDevices(myDataTable.Rows.Count - 1) {}
		For i As Byte = 0 To myDataTable.Rows.Count - 1
			EndDevicesArray(i) = New EndDevices(3)
			EndDevicesArray(i).Address = myDataTable.Rows(i)("Address")
			LinkDeviceAndXbee(EndDevicesArray(i), HostXbee(myDataTable.Rows(i)("Host Xbee")))
		Next
	End Sub
	Private Sub ReadLineGroup()
		Dim myDataAdapter As SqlDataAdapter
		Dim myDataTable As DataTable
		'Read Group information - Line information also
		myDataAdapter = New SqlDataAdapter("SELECT * FROM LineGroup", con)
		myDataTable = New DataTable
		myDataAdapter.Fill(myDataTable)
		LineGroupArray = New LineGroup(myDataTable.Rows.Count - 1) {}
		For i As Byte = 0 To myDataTable.Rows.Count - 1
			LineGroupArray(i).Name = myDataTable.Rows(i)("Name")
			LineGroupArray(i).MaxPart = 0
		Next
	End Sub
	Private Sub ReadPart()
		Dim myDataAdapter As SqlDataAdapter
		Dim myDataTable As DataTable
		'Read Part information 
		myDataAdapter = New SqlDataAdapter("SELECT * FROM Part", con)
		myDataTable = New DataTable
		myDataAdapter.Fill(myDataTable)
		PartArray = New CPart(myDataTable.Rows.Count - 1) {}
		For i As Byte = 0 To myDataTable.Rows.Count - 1
			Dim num As Byte
			num = myDataTable.Rows(i)("EndDevices")
			For j As Byte = 0 To 2
				If EndDevicesArray(num).Parts(j).Name = "" Then
					EndDevicesArray(num).Parts(j).Name = myDataTable.Rows(i)("Name")
					EndDevicesArray(num).Parts(j).Enable = myDataTable.Rows(i)("Enable")
					EndDevicesArray(num).Parts(j).index = myDataTable.Rows(i)("ID")
					EndDevicesArray(num).Parts(j).priority = myDataTable.Rows(i)("Priority")
					EndDevicesArray(num).Parts(j).group = myDataTable.Rows(i)("Group")
					LineGroupArray(EndDevicesArray(num).Parts(j).group).MaxPart += 1
					If IsNothing(LineGroupArray(EndDevicesArray(num).Parts(j).group).ChildPart) Then
						LineGroupArray(EndDevicesArray(num).Parts(j).group).ChildPart = New Collection
					End If
					LineGroupArray(EndDevicesArray(num).Parts(j).group).ChildPart.Add(EndDevicesArray(num).Parts(j))
					PartArray(i) = EndDevicesArray(num).Parts(j)
					Exit For
				End If
			Next
		Next
	End Sub
	Private Sub ReadAGV()
		Dim myDataAdapter As SqlDataAdapter
		Dim myDataTable As DataTable
		'Read AGV information 
		myDataAdapter = New SqlDataAdapter("SELECT * FROM AGV", con)
		myDataTable = New DataTable
		myDataAdapter.Fill(myDataTable)
		AGVArray = New AGV(myDataTable.Rows.Count - 1) {}
		'Make copy
		preAGVStatusArray = New struct_AGVStoreStatus(myDataTable.Rows.Count - 1) {}
		AGVnPART = New Boolean(AGVArray.Length - 1, PartArray.Length - 1) {}
		For i As Byte = 0 To AGVArray.Length - 1
			For j As Byte = 0 To PartArray.Length - 1
				AGVnPART(i, j) = False
			Next
		Next
		For i As Byte = 0 To myDataTable.Rows.Count - 1
			AGVArray(i) = New AGV(myDataTable.Rows(i)("Name"), myDataTable.Rows(i)("Address"))
			preAGVStatusArray(i).connecting_time = Now
			preAGVStatusArray(i).status_time = Now
			preAGVStatusArray(i).working_time = Now
			AGVArray(i).Enable = myDataTable.Rows(i)("Enable")
			LinkDeviceAndXbee(AGVArray(i), HostXbee(myDataTable.Rows(i)("Host Xbee")))
			setAGVSupply(i, myDataTable.Rows(i)("Part"))
		Next
	End Sub
End Module
