Imports ControlSystemLibrary
Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml.Linq

Public Module SQLData
    Public SQLstrConn As String = "Data Source=" + My.Computer.Name + "\SQLEXPRESS;Integrated Security=True"
    Public SQLcon As SqlConnection

    Public ChartDataAdapter As SqlDataAdapter

    Public Sub ReadStartData()
        SQLcon = New SqlConnection(SQLstrConn)
        SQLcon.Open()
        If isNeedToReset Then
            ResetCounter()
        End If
        ReadHost()
        ReadEndDevices()
        ReadLineGroup()
        ReadAGVGroup()
        ReadPart()
        ReadAGV()
        ReadCross()
        ReadChart()
        ReadStartPoint()
        ReadParkPoint()
        ReadWorkingTime()

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
            'HostXbee(i).Address = myDataTable.Rows(i)("Address")
            HostXbee(i).Address = Convert.ToInt32(myDataTable.Rows(i)("Address"), 16)
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
        'If RequestRouteConcept = False Then
            For i As Byte = 0 To myDataTable.Rows.Count - 1
                EndDevicesArray(i) = New EndDevices()
                EndDevicesArray(i).Address = Convert.ToInt32(myDataTable.Rows(i)("Address"), 16)
                LinkDeviceAndXbee(EndDevicesArray(i), HostXbee(myDataTable.Rows(i)("Host Xbee")))
                EndDevicesArray(i).Host = (myDataTable.Rows(i)("Host Xbee"))
            Next
        'Else 'read text
     
        'End If
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

    Private Sub ReadAGVGroup()
        Dim myDataAdapter As SqlDataAdapter
        Dim myDataTable As DataTable
        'Read Group information - Line information also
        myDataAdapter = New SqlDataAdapter("SELECT * FROM AGVGroup", SQLcon)
        myDataTable = New DataTable
        myDataAdapter.Fill(myDataTable)
        AGVGroupArray = New AGVGroup(myDataTable.Rows.Count - 1) {}
        For i As Byte = 0 To myDataTable.Rows.Count - 1
            AGVGroupArray(i).Name = myDataTable.Rows(i)("Name")
            AGVGroupArray(i).MaxAGV = 0
        Next
    End Sub

    Private Sub ReadPart()
        Dim myDataAdapter As SqlDataAdapter
        Dim myDataTable As DataTable
        'Read Part information 
        myDataAdapter = New SqlDataAdapter("SELECT * FROM Part", SQLcon)        'lay du lieu tu bang Part
        myDataTable = New DataTable
        myDataAdapter.Fill(myDataTable)
        PartList = New List(Of CPart)


        'Khai bao bo nho cho part theo tung End
        For i As Byte = 0 To EndDevicesArray.Count - 1
            Dim NumPartOfEnd As Byte = 0
            For j As Byte = 0 To myDataTable.Rows.Count - 1                         'theo hàng
                Dim num As Byte
                If Not IsDBNull(myDataTable.Rows(j)("EndDevices")) Then             'neu database co du lieu
                    num = myDataTable.Rows(j)("EndDevices")                         'num = gia tri ghi trong cot EndDeivces tai hang thu i
                    If i.Equals(num) Then
                        NumPartOfEnd = NumPartOfEnd + 1
                    End If
                End If
            Next
            EndDevicesArray(i).AddPart(NumPartOfEnd)
        Next
        'Read Part table
        For i As Byte = 0 To myDataTable.Rows.Count - 1
            Dim num As Byte
            If Not IsDBNull(myDataTable.Rows(i)("EndDevices")) Then             'neu database co du lieu
                num = myDataTable.Rows(i)("EndDevices")
                For j As Byte = 0 To EndDevicesArray(num).CollectPart_PerEnd.Count          'theo cột
                    If EndDevicesArray(num).Parts(j).Name = "" Then
                        EndDevicesArray(num).Parts(j).Name = myDataTable.Rows(i)("Name")
                        If IsDBNull(myDataTable.Rows(i)("Enable")) Then
                            EndDevicesArray(num).Parts(j).Enable = False
                        Else
                            EndDevicesArray(num).Parts(j).Enable = myDataTable.Rows(i)("Enable")
                        End If
                        EndDevicesArray(num).Parts(j).index = myDataTable.Rows(i)("ID")
                        EndDevicesArray(num).Parts(j).priority = myDataTable.Rows(i)("Priority")
                        EndDevicesArray(num).Parts(j).group = myDataTable.Rows(i)("Group")
                        EndDevicesArray(num).Parts(j).SupplyCount = myDataTable.Rows(i)("count")
                        EndDevicesArray(num).Parts(j).target = myDataTable.Rows(i)("target")
                        EndDevicesArray(num).Parts(j).route = myDataTable.Rows(i)("Route")
                        EndDevicesArray(num).Parts(j).Status = True
                        EndDevicesArray(num).Parts(j).EndDevice = num
                        EndDevicesArray(num).Parts(j).CycleTime = myDataTable.Rows(i)("CycleTime")
                        EndDevicesArray(num).Parts(j).Description = myDataTable.Rows(i)("Description")
                        EndDevicesArray(num).Parts(j).EmptyCount = myDataTable.Rows(i)("EmptyCount")
                        EndDevicesArray(num).Parts(j).X = myDataTable.Rows(i)("X")
                        EndDevicesArray(num).Parts(j).Y = myDataTable.Rows(i)("y")
                        LineGroupArray(EndDevicesArray(num).Parts(j).group).MaxPart += 1
                        If IsNothing(LineGroupArray(EndDevicesArray(num).Parts(j).group).ChildPart) Then
                            LineGroupArray(EndDevicesArray(num).Parts(j).group).ChildPart = New Collection
                        End If
                        LineGroupArray(EndDevicesArray(num).Parts(j).group).ChildPart.Add(EndDevicesArray(num).Parts(j))
                        PartList.Add(EndDevicesArray(num).Parts(j))
                        Exit For
                    End If
                Next
            End If
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
            AGVList.Add(New AGV(myDataTable.Rows(i)("Name"), Convert.ToInt32(myDataTable.Rows(i)("Address"), 16)))
            preAGVStatusArray(i).connecting_time = Now
            preAGVStatusArray(i).status_time = Now
            preAGVStatusArray(i).working_time = Now
            preAGVStatusArray(i).Enable_time = Now
            preAGVStatusArray(i).Shutdown_time = Now
            preAGVStatusArray(i).TimeAGVPowerOn_value = 0
            If IsDBNull(myDataTable.Rows(i)("Enable")) Then
                AGVList(i).Enable = False
            Else
                AGVList(i).Enable = myDataTable.Rows(i)("Enable")
            End If
            AGVList(i).group = myDataTable.Rows(i)("Group")
            AGVList(i).index = myDataTable.Rows(i)("id")
            AGVList(i).HostControl = myDataTable.Rows(i)("Host Xbee")
            AGVList(i).SupplyCount = myDataTable.Rows(i)("Count")
            AGVGroupArray(AGVList(i).group).MaxAGV += 1
            If IsNothing(AGVGroupArray(AGVList(i).group).ChildAGV) Then
                AGVGroupArray(AGVList(i).group).ChildAGV = New Collection
            End If
            AGVGroupArray(AGVList(i).group).ChildAGV.Add(AGVList(i))
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
        MAX_CROSS = myDataTable.Rows.Count
        CrossArray = New CrossStruct(myDataTable.Rows.Count - 1) {}
        For CrossNumber As Byte = 0 To myDataTable.Rows.Count - 1
            Dim CrossPosArray() As Integer = New Integer(MAX_POS_IN_CROSS - 1) {}
            For CrossPosNum As Byte = 1 To MAX_POS_IN_CROSS
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

        If ChartDataTable.Rows.Count < AGVList.Count Then
            While ChartDataTable.Rows.Count < AGVList.Count
                Dim newRow As DataRow = ChartDataTable.NewRow()
                newRow(0) = ChartDataTable.Rows.Count
                For i As Byte = 1 To 12 'tocheck: disable time
                    newRow(i) = 0
                Next
                ChartDataTable.Rows.Add(newRow)
            End While
            ChartResetSQL()
        ElseIf ChartDataTable.Rows.Count > AGVList.Count Then
            Dim cmdText As String = "delete from [master].[dbo].[chart]" 'tocheck: giữ lại những AGV có tên
            Dim sqlcmd = New SqlCommand(cmdText, SQLcon)
            sqlcmd.ExecuteNonQuery()

            While ChartDataTable.Rows.Count > AGVList.Count
                ChartDataTable.Rows.RemoveAt(ChartDataTable.Rows.Count - 1)
            End While
            ChartResetSQL()
        End If

        For i As Byte = 0 To ChartDataTable.Rows.Count - 1
            ChartDataTable.Rows.Item(i)(1) = AGVList(i).Name
        Next
        Dim MaxTime As Double = 0
        For i As Byte = 0 To ChartDataTable.Rows.Count - 1
            Dim totalTime As Double = 0
            For j As Byte = 2 To 12 'tockeck: disable time
                totalTime = totalTime + ChartDataTable.Rows.Item(i)(j)
            Next
            If MaxTime < totalTime Then MaxTime = totalTime
        Next
        For i As Byte = 0 To ChartDataTable.Rows.Count - 1
            Dim notDisconnectTime As Double = 0
            For j As Byte = 2 To 11 'tocheck: disable time
                notDisconnectTime += ChartDataTable.Rows.Item(i)(j)
            Next
            ChartDataTable.Rows.Item(i)(12) = MaxTime - notDisconnectTime 'tocheck: disable time
        Next
    End Sub
    Private Sub ReadStartPoint()
        Dim myDataAdapter As SqlDataAdapter
        Dim myDataTable As DataTable
        myDataAdapter = New SqlDataAdapter("SELECT * FROM StartPoint", SQLcon)
        myDataTable = New DataTable
        myDataAdapter.Fill(myDataTable)
        StartPoint = New Integer(myDataTable.Rows.Count - 1) {}
        For SPnum As Byte = 0 To myDataTable.Rows.Count - 1
            StartPoint(SPnum) = myDataTable.Rows(SPnum)(1)
        Next
    End Sub
    Private Sub ReadParkPoint()
        Dim myDataAdapter As SqlDataAdapter
        Dim myDataTable As DataTable
        myDataAdapter = New SqlDataAdapter("SELECT * FROM ParkPoint", SQLcon)
        myDataTable = New DataTable
        myDataAdapter.Fill(myDataTable)
        If myDataTable.Rows.Count > 0 Then
            ParkPointArray = New Integer(1, myDataTable.Rows.Count - 1) {}
            For PPNum As Byte = 0 To myDataTable.Rows.Count - 1
                ParkPointArray(0, PPNum) = myDataTable.Rows(PPNum)("First")
                ParkPointArray(1, PPNum) = myDataTable.Rows(PPNum)("Second")
            Next
        End If
    End Sub
    Private Sub ReadWorkingTime()
        Dim myDataAdapter As SqlDataAdapter
        Dim myDataTable As DataTable
        myDataAdapter = New SqlDataAdapter("SELECT * FROM WorkingTime", SQLcon)
        myDataTable = New DataTable
        myDataAdapter.Fill(myDataTable)
        If myDataTable.Rows.Count > 0 Then
            WorkingTimeArray = New struct_Workingtime(myDataTable.Rows.Count - 1) {}
            For PPNum As Byte = 0 To myDataTable.Rows.Count - 1
                WorkingTimeArray(PPNum).StartTime = New DateTime(2015, 1, 1, CType(myDataTable.Rows(PPNum)("BeginTime"), DateTime).Hour, CType(myDataTable.Rows(PPNum)("BeginTime"), DateTime).Minute, 0)
                WorkingTimeArray(PPNum).StartMorningTime = New DateTime(2015, 1, 1, CType(myDataTable.Rows(PPNum)("StartMorTime"), DateTime).Hour, CType(myDataTable.Rows(PPNum)("StartMorTime"), DateTime).Minute, 0)
                WorkingTimeArray(PPNum).StopMorningTime = New DateTime(2015, 1, 1, CType(myDataTable.Rows(PPNum)("StopMorTime"), DateTime).Hour, CType(myDataTable.Rows(PPNum)("StopMorTime"), DateTime).Minute, 0)
                WorkingTimeArray(PPNum).StartLunchTime = New DateTime(2015, 1, 1, CType(myDataTable.Rows(PPNum)("StartLunTime"), DateTime).Hour, CType(myDataTable.Rows(PPNum)("StartLunTime"), DateTime).Minute, 0)
                WorkingTimeArray(PPNum).StopLunchTime = New DateTime(2015, 1, 1, CType(myDataTable.Rows(PPNum)("StopLunTime"), DateTime).Hour, CType(myDataTable.Rows(PPNum)("StopLunTime"), DateTime).Minute, 0)
                WorkingTimeArray(PPNum).StartAfterTime = New DateTime(2015, 1, 1, CType(myDataTable.Rows(PPNum)("StartAftTime"), DateTime).Hour, CType(myDataTable.Rows(PPNum)("StartAftTime"), DateTime).Minute, 0)
                WorkingTimeArray(PPNum).StopAfterTime = New DateTime(2015, 1, 1, CType(myDataTable.Rows(PPNum)("StopAftTime"), DateTime).Hour, CType(myDataTable.Rows(PPNum)("StopAftTime"), DateTime).Minute, 0)
                WorkingTimeArray(PPNum).StopTime = New DateTime(2015, 1, 1, CType(myDataTable.Rows(PPNum)("EndTime"), DateTime).Hour, CType(myDataTable.Rows(PPNum)("EndTime"), DateTime).Minute, 0)
            Next
        End If
    End Sub

    Public Sub ChartResetSQL()
        For AGVNum As Byte = 0 To AGVList.Count - 1
            For column As Byte = 2 To 12 'tocheck:disable time
                ChartDataTable.Rows(AGVNum)(column) = 0
            Next
        Next
        Dim objCommandBuilder As New SqlCommandBuilder(ChartDataAdapter)
        ChartDataAdapter.Update(ChartDataSet, "chart")
    End Sub
    Public Sub ChartUpdateSQL()
       		'have bug, need to test
		Try
			Dim objCommandBuilder As New SqlCommandBuilder(ChartDataAdapter)
			ChartDataAdapter.Update(ChartDataSet, "chart")

			Static PartCounter() As Integer = New Integer(PartList.Count - 1) {}
			For i As Byte = 0 To PartList.Count - 1
				If PartCounter(i) <> PartList(i).SupplyCount Then
					Dim cmdText As String = "UPDATE PART SET COUNT=" + PartList(i).SupplyCount.ToString + " WHERE Id=" + i.ToString
					Dim sqlcmd = New SqlCommand(cmdText, SQLcon)
					sqlcmd.ExecuteNonQuery()
					PartCounter(i) = PartList(i).SupplyCount
				End If
			Next

			Static EmptyCounter() As Integer = New Integer(PartList.Count - 1) {}
			For i As Byte = 0 To PartList.Count - 1
				If EmptyCounter(i) <> PartList(i).EmptyCount Then
					Dim cmdText As String = "UPDATE PART SET EMPTYCOUNT=" + PartList(i).EmptyCount.ToString + " WHERE Id=" + i.ToString
					Dim sqlcmd = New SqlCommand(cmdText, SQLcon)
					sqlcmd.ExecuteNonQuery()
					EmptyCounter(i) = PartList(i).EmptyCount
				End If
			Next

			Static AGVCounter() As Integer = New Integer(AGVList.Count - 1) {}
			For i As Byte = 0 To AGVList.Count - 1
				If AGVCounter(i) <> AGVList(i).SupplyCount Then
					Dim cmdText As String = "UPDATE AGV SET COUNT=" + AGVList(i).SupplyCount.ToString + " WHERE Id=" + i.ToString
					Dim sqlcmd = New SqlCommand(cmdText, SQLcon)
					sqlcmd.ExecuteNonQuery()
					AGVCounter(i) = AGVList(i).SupplyCount
				End If
			Next
		Catch ex As Exception
			Dim str As String = ""
			str += Now.ToString + ex.Message + vbCrLf
			My.Computer.FileSystem.WriteAllText("UpdateSQL_Error.txt", str, True)
		End Try
    End Sub

    'Public Sub MapUpdate()
    '    Static X() As Integer = New Integer(MapPartList.Count - 1) {}
    '    For i As Byte = 0 To MapPartList.Count - 1
    '        If X(i) <> MapPartList(i).X Then
    '            Dim cmdText As String = "UPDATE PART SET X=" + MapPartList(i).X.ToString + " WHERE Id=" + i.ToString
    '            Dim sqlcmd = New SqlCommand(cmdText, SQLcon)
    '            sqlcmd.ExecuteNonQuery()
    '            X(i) = MapPartList(i).X
    '        End If
    '    Next

    '    Static Y() As Integer = New Integer(MapPartList.Count - 1) {}
    '    For i As Byte = 0 To MapPartList.Count - 1
    '        If Y(i) <> MapPartList(i).Y Then
    '            Dim cmdText As String = "UPDATE PART SET Y=" + MapPartList(i).Y.ToString + " WHERE Id=" + i.ToString
    '            Dim sqlcmd = New SqlCommand(cmdText, SQLcon)
    '            sqlcmd.ExecuteNonQuery()
    '            Y(i) = MapPartList(i).Y
    '        End If
    '    Next
    'End Sub
    Private Sub ResetCounter()
        ResetPartCounter()
        ResetAGVCounter()
        ResetEmptyCounter()
    End Sub
    Public Sub ResetPartCounter()
        Dim cmdText As String = "UPDATE PART SET COUNT=0"
        Dim sqlcmd = New SqlCommand(cmdText, SQLcon)
        sqlcmd.ExecuteNonQuery()
    End Sub
    Public Sub ResetAGVCounter()
        Dim cmdText As String = "UPDATE AGV SET COUNT=0"
        Dim sqlcmd = New SqlCommand(cmdText, SQLcon)
        sqlcmd.ExecuteNonQuery()
    End Sub
    Public Sub ResetEmptyCounter()
        Dim cmdText As String = "UPDATE PART SET EMPTYCOUNT=0"
        Dim sqlcmd = New SqlCommand(cmdText, SQLcon)
        sqlcmd.ExecuteNonQuery()
    End Sub


End Module

