Imports ControlSystemLibrary
Imports System.Data
Imports System.Data.SqlClient
Public Module SQLData
    Dim con As SqlConnection
    Public Sub ReadStartData()
        Dim str As String = "Data Source=TL-APRO-NPC08\SQLEXPRESS;Integrated Security=True"
        con = New SqlConnection(str)
        con.Open()

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

        'Read AGV information 
        myDataAdapter = New SqlDataAdapter("SELECT * FROM AGV", con)
        myDataTable = New DataTable
        myDataAdapter.Fill(myDataTable)
        AGVArray = New AGV(myDataTable.Rows.Count - 1) {}
        For i As Byte = 0 To myDataTable.Rows.Count - 1
            AGVArray(i) = New AGV(myDataTable.Rows(i)("Name"), myDataTable.Rows(i)("Address"))
            AGVArray(i).Enable = myDataTable.Rows(i)("Enable")
            LinkDeviceAndXbee(AGVArray(i), HostXbee(myDataTable.Rows(i)("Host Xbee")))
        Next

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
        'Read Group information - Line information also
        myDataAdapter = New SqlDataAdapter("SELECT * FROM LineGroup", con)
        myDataTable = New DataTable
        myDataAdapter.Fill(myDataTable)
        LineGroupArray = New LineGroup(myDataTable.Rows.Count - 1) {}
        For i As Byte = 0 To myDataTable.Rows.Count - 1
            LineGroupArray(i).Name = myDataTable.Rows(i)("Name")
            LineGroupArray(i).MaxPart = 0
        Next

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
End Module
