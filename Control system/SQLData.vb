Imports ControlSystemLibrary
Imports System.Data
Imports System.Data.SqlClient
Public Module SQLData
    Public SQLstrConn As String = "Data Source=" + My.Computer.Name + "\SQLEXPRESS;Integrated Security=True"
    Public SQLcon As SqlConnection
    Public ChartDataSet As DataSet
    Public ChartDataTable As New DataTable
    Public ChartDataAdapter As SqlDataAdapter

    Public Sub ReadStartData()
        SQLcon = New SqlConnection(SQLstrConn)
        SQLcon.Open()
        If isNeedToReset Then
            ResetPartCounter()
        End If
        ReadHost()
        ReadEndDevices()
        ReadLineGroup()
        ReadPart()
        ReadAGV()
        ReadCross()
        ReadChart()
        ReadStartPoint()
    End Sub
    Public Sub setAGVSupply(ByVal AGVnumber As Byte, ByVal PartString As String)
        If PartString.ToLower = "all" Then
            For i As Byte = 0 To PartList.Count - 1
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
        myDataAdapter = New SqlDataAdapter("SELECT * FROM HostXbee", SQLcon)
        myDataTable = New DataTable
        myDataAdapter.Fill(myDataTable)
        If myDataTable.Rows.Count = 0 Then
            MessageBox.Show("Can not read setting for host Xbee. Please check again", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Environment.Exit(-1)
        End If
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
        myDataAdapter = New SqlDataAdapter("SELECT * FROM EndDevices", SQLcon)
        myDataTable = New DataTable
        myDataAdapter.Fill(myDataTable)
        If myDataTable.Rows.Count = 0 Then
            MessageBox.Show("Can not read setting for End Devices. Please check again", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Environment.Exit(-1)
        End If
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
        myDataAdapter = New SqlDataAdapter("SELECT * FROM LineGroup", SQLcon)
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
        myDataAdapter = New SqlDataAdapter("SELECT * FROM Part", SQLcon)
        myDataTable = New DataTable
        myDataAdapter.Fill(myDataTable)
        PartList = New List(Of CPart)
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
                    EndDevicesArray(num).Parts(j).supplyCount = myDataTable.Rows(i)("count")
                    EndDevicesArray(num).Parts(j).target = myDataTable.Rows(i)("target")
                    LineGroupArray(EndDevicesArray(num).Parts(j).group).MaxPart += 1
                    If IsNothing(LineGroupArray(EndDevicesArray(num).Parts(j).group).ChildPart) Then
                        LineGroupArray(EndDevicesArray(num).Parts(j).group).ChildPart = New Collection
                    End If
                    LineGroupArray(EndDevicesArray(num).Parts(j).group).ChildPart.Add(EndDevicesArray(num).Parts(j))
                    PartList.Add(EndDevicesArray(num).Parts(j))
                    Exit For
                End If
            Next
        Next
    End Sub
    Private Sub ReadAGV()
        Dim myDataAdapter As SqlDataAdapter
        Dim myDataTable As DataTable
        'Read AGV information 
        myDataAdapter = New SqlDataAdapter("SELECT * FROM AGV", SQLcon)
        myDataTable = New DataTable
        myDataAdapter.Fill(myDataTable)
        AGVList = New List(Of AGV)
        'Make copy
        preAGVStatusArray = New struct_AGVStoreStatus(myDataTable.Rows.Count - 1) {}
        AGVnPART = New Boolean(myDataTable.Rows.Count - 1, PartList.Count - 1) {}
        For i As Byte = 0 To myDataTable.Rows.Count - 1
            For j As Byte = 0 To PartList.Count - 1
                AGVnPART(i, j) = False
            Next
        Next
        For i As Byte = 0 To myDataTable.Rows.Count - 1
            AGVList.Add(New AGV(myDataTable.Rows(i)("Name"), myDataTable.Rows(i)("Address")))
            preAGVStatusArray(i).connecting_time = Now
            preAGVStatusArray(i).status_time = Now
            preAGVStatusArray(i).working_time = Now
            AGVList(i).Enable = myDataTable.Rows(i)("Enable")
            LinkDeviceAndXbee(AGVList(i), HostXbee(myDataTable.Rows(i)("Host Xbee")))
            setAGVSupply(i, myDataTable.Rows(i)("Part"))
        Next
    End Sub
    Private Sub ReadCross()
        Dim myDataAdapter As SqlDataAdapter
        Dim myDataTable As DataTable
        'Read CrossFunction
        myDataAdapter = New SqlDataAdapter("SELECT * FROM CrossTable", SQLcon)
        myDataTable = New DataTable
        myDataAdapter.Fill(myDataTable)
        CrossArray = New CrossStruct(myDataTable.Rows.Count - 1) {}
        For CrossNumber As Byte = 0 To myDataTable.Rows.Count - 1
            Dim CrossPosArray() As Integer = New Integer(MAX_POS_IN_CROSS - 1) {}
            For CrossPosNum As Byte = 1 To 10
                If myDataTable.Rows(CrossNumber)(CrossPosNum.ToString).GetType = GetType(Integer) Then
                    CrossPosArray(CrossPosNum - 1) = myDataTable.Rows(CrossNumber)(CrossPosNum.ToString)
                Else : Exit For
                End If
            Next
            InitSingleCross(CrossArray(CrossNumber), CrossPosArray)
        Next
        initCrossVar()
    End Sub
    Private Sub ReadChart()
        Dim sqlProducts As String = "SELECT * FROM chart"
        ChartDataAdapter = New SqlDataAdapter(sqlProducts, SQLcon)
        ChartDataSet = New DataSet()
        ChartDataAdapter.FillSchema(ChartDataSet, SchemaType.Source, "chart")
        ChartDataTable = New DataTable()
        ChartDataAdapter.Fill(ChartDataSet, "chart")
        ChartDataTable = ChartDataSet.Tables("chart")
    End Sub
    Private Sub ReadStartPoint()
        Dim myDataAdapter As SqlDataAdapter
        Dim myDataTable As DataTable
        'Read CrossFunction
        myDataAdapter = New SqlDataAdapter("SELECT * FROM StartPoint", SQLcon)
        myDataTable = New DataTable
        myDataAdapter.Fill(myDataTable)
        StartPoint = New Byte(myDataTable.Rows.Count - 1) {}
        For SPnum As Byte = 0 To myDataTable.Rows.Count - 1
            StartPoint(SPnum) = myDataTable.Rows(SPnum)(1)
        Next
    End Sub
    Public Sub ChartResetSQL()
        For AGVNum As Byte = 0 To AGVList.Count - 1
            For column As Byte = 2 To 10
                ChartDataTable.Rows(AGVNum)(column) = 0
            Next
        Next
        Dim objCommandBuilder As New SqlCommandBuilder(ChartDataAdapter)
        ChartDataAdapter.Update(ChartDataSet, "chart")
    End Sub

    Public Sub ChartUpdateSQL()
        Dim objCommandBuilder As New SqlCommandBuilder(ChartDataAdapter)
        ChartDataAdapter.Update(ChartDataSet, "chart")
    End Sub

    Public Sub ResetPartCounter()
        Dim cmdText As String = "UPDATE PART SET COUNT=0"
        Dim sqlcmd = New SqlCommand(cmdText, SQLcon)
        sqlcmd.ExecuteNonQuery()
    End Sub
End Module
