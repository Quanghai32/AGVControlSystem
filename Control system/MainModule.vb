﻿Imports System.Threading
Imports ControlSystemLibrary
Imports System.IO.Ports
Imports System.IO
Imports Newtonsoft.Json

Public Module MainModule
    Public UpdateThread As New Thread(AddressOf UpdateData)
    Public DoCrossThread As New Thread(AddressOf DoCrossFunc)
    Public SaveThread As New Thread(AddressOf ChartUpdateXml)
    Public RecordThread As New Thread(AddressOf RecordData)
    Public WithEvents CopyTimer As Timers.Timer = New Timers.Timer

    Sub CopyTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyTimer.Elapsed
        Dim fileLog As String = BlockName + "_" + Now.ToString("yyyyMMdd") + ".csv"
        CopyFile(fileLog, "./Log", pathLogFile + "/" + fileLog)

        Dim filePerformance=BlockName + "_" + Now.ToString("yyyyMMdd") + "_" + ShipName + ".txt"
        CopyFile(filePerformance, "./Performance/", pathPerformance + "/" + filePerformance)
    End Sub

    Public Sub SetupTextFile()

    End Sub
    Public Sub ReadSetting()
        Dim settingFile As CIniFile
        settingFile = New CIniFile(Environment.CurrentDirectory + "\setting.ini")
        IsReadText = Convert.ToBoolean(settingFile.ReadValue("IsReadTextFile", "value"))
        Tab_start = Convert.ToByte(settingFile.ReadValue("Tab_start", "value"))
        Path_Text = settingFile.ReadValue("Path_Text", "value")
        TimerChangePartSttValue = Conversion.Int(settingFile.ReadValue("TimerPart", "value"))
        MapPartHeight = settingFile.ReadValue("PartSize", "Height")
        MapPartWidth = settingFile.ReadValue("PartSize", "Width")
        MAX_POS_IN_CROSS = settingFile.ReadValue("MAX_POS_IN_CROSS", "value")
        Part_EmptyCount = settingFile.ReadValue("Path_EmptyCount", "value")
        BlockName = settingFile.ReadValue("BLOCK_NAME", "value")
        ServerName = settingFile.ReadValue("ServerName", "value")

        pathLogFile = settingFile.ReadValue("PathLog", "value")
        pathPerformance = settingFile.ReadValue("PathPerformance", "value")
        DurationCopy = Int32.Parse(settingFile.ReadValue("DurationCopy", "value"))

        If DurationCopy > 0 Then
            CopyTimer.Interval = DurationCopy
            CopyTimer.Start()
        End If
    End Sub
    Public Sub SetupHostXbee()
        Dim HostXbeeName() As String
        HostXbeeName = SerialPort.GetPortNames()
        Dim list() As String
        list = New String(HostXbee.Length - 1) {}
        Dim tempXbee As XBee = New XBee
        If HostXbeeName.Length > 0 Then
            For i As Byte = 0 To HostXbeeName.Length - 1
                tempXbee.SettingPort(HostXbeeName(i), 9600)
                tempXbee.Address = 0
                For k As Byte = 0 To 2
                    tempXbee.Send_AT_Command(XBee.AT_COMMAND_ENUM.SERIAL_NUMBER_LOW)
                    Dim CurrentTime As Integer = Environment.TickCount
                    While (tempXbee.Address = 0) And (CurrentTime + 1000) > Environment.TickCount
                    End While
                    If tempXbee.Address <> 0 Then
                        For j As Byte = 0 To HostXbee.Length - 1
                            If tempXbee.Address = HostXbee(j).Address Then
                                list(j) = HostXbeeName(i)
                                Exit For
                            End If
                        Next
                        Exit For
                    End If
                Next
                tempXbee.ClosePort()
            Next
        End If
        Dim Str As String = New String("Can not connect with ")
        Dim isError As Boolean = False
        For i As Byte = 0 To list.Length - 1
            If list(i) = "" Then
                Str = Str + " Host Xbee " + i.ToString + ", "
                isError = True
            End If
        Next
        If isError Then
            Dim confirm As Byte = MessageBox.Show(Str + vbCrLf + "Do you want to continue?", "Error - " + Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Error)
            If confirm <> vbYes Then Environment.Exit(0)
        End If
        For i As Byte = 0 To HostXbee.Length - 1
            If list(i) <> "" Then
                HostXbee(i).SettingPort(list(i), 9600)
            End If
        Next
    End Sub
    Public Sub UpdateData() 'todo: ignore disconect time if turn on AGV.position=0
        If isOnWorkingTime(Now.Hour, Now.Minute) Then
            For AGVNum As Byte = 0 To AGVList.Count - 1
                If AGVList(AGVNum).Connecting Then
                    UpdateWhenConnect(AGVNum)
                Else
                    UpdateWhenDisconnect(AGVNum)
                End If
            Next
            isPreOnTime = True  'Is preview stt OnWorkingTime or OnBreakTime ?
        Else
            If isPreOnTime Then 'If before BreakTime is OnWorkingTime
                ForceUpdate()
                isPreOnTime = False
            Else                'On break time
                For AGVNum As Byte = 0 To AGVList.Count - 1
                    UpdateAllValue(AGVNum)
                Next
                isPreOnTime = False
            End If
        End If
    End Sub

    Public Sub RequestData()
        For AGVNum As Byte = 0 To AGVList.Count - 1
            If isAGVFree4Supply(AGVNum) Then
                If AGVList(AGVNum).isRequesting = False Then 'todo: thread
                    Dim ThreadAGV As New Dictionary(Of String, Thread)()
                    Dim variableName = "Thread"
                    If ThreadAGV.ContainsKey(variableName & "(" & AGVNum.ToString() & ")") Then
                        If Not ThreadAGV(variableName & "(" & AGVNum.ToString() & ")").IsAlive Then
                            ThreadAGV(variableName & "(" & AGVNum.ToString() & ")") = New Thread(AddressOf RequestAGV)
                            ThreadAGV(variableName & "(" & AGVNum.ToString() & ")").Name = "Thread " & AGVList(AGVNum).Name.ToString
                            ThreadAGV(variableName & "(" & AGVNum.ToString() & ")").Start(AGVNum)
                        End If
                    Else
                        ThreadAGV(variableName & "(" & AGVNum.ToString() & ")") = New Thread(AddressOf RequestAGV)
                        ThreadAGV(variableName & "(" & AGVNum.ToString() & ")").Name = "Thread " & AGVList(AGVNum).Name.ToString
                        ThreadAGV(variableName & "(" & AGVNum.ToString() & ")").Start(AGVNum)
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub RequestAGV(ByVal AGVnum As Byte)
        AGVList(AGVnum).isRequesting = True 'todo: thread
        Debug.WriteLine("start find AGV" & Environment.TickCount.ToString)
        Dim partNeedSupply As Byte = findSupplyPart4AGV(AGVnum)
        Debug.WriteLine("finise find AGV" & Environment.TickCount)
        If partNeedSupply <> 99 Then
            PartList(partNeedSupply).isRequesting = True 'todo: thread
            For iTry As Byte = 0 To 4
                Dim TimePoint As Integer = Environment.TickCount
                AGVList(AGVnum).RequestRoute(PartList(partNeedSupply).route)
                While (AGVList(AGVnum).Status = AGV.RobocarStatusValue.STOP_BY_CARD And (TimePoint + 5000) > Environment.TickCount) 'neu = Nomal-->false
                End While
                If (AGVList(AGVnum).Status <> AGV.RobocarStatusValue.STOP_BY_CARD) Then Exit For
            Next
            If (AGVList(AGVnum).Status <> AGV.RobocarStatusValue.STOP_BY_CARD) Then
                AGVList(AGVnum).RequestRoute(PartList(partNeedSupply).route)
                'AGVList(AGVnum).SupplyPartName = PartList(partNeedSupply).Name
                AGVList(AGVnum).WorkingStatus = AGV.RobocarWorkingStatusValue.SUPPLYING
                'AGVList(AGVNum).Status = AGV.RobocarStatusValue.NORMAL
                AGVList(AGVnum).SupplyTime = Now
                AGVList(AGVnum).SupplyCount += 1
                Record(AGVList(AGVnum).Name, "Status", "CALL_BY_SYSTEM", "Route", PartList(partNeedSupply).route, "Part", PartList(partNeedSupply).Name)
                PartList(partNeedSupply).AGVSupply = AGVList(AGVnum).Name
                PartList(partNeedSupply).SupplyCount += 1
                PartList(partNeedSupply).SupplyTime = Now
            End If
            PartList(partNeedSupply).isRequesting = False 'todo: thread
        End If
        AGVList(AGVnum).isRequesting = False 'todo: thread
    End Sub

    Public Sub RequestDataBak()
        For AGVNum As Byte = 0 To AGVList.Count - 1
            If isAGVFree4Supply(AGVNum) Then
                Dim partNeedSupply As Byte = findSupplyPart4AGV(AGVNum)
                If partNeedSupply <> 99 Then
                    For iTry As Byte = 0 To 4
                        Dim TimePoint As Integer = Environment.TickCount
                        AGVList(AGVNum).RequestRoute(PartList(partNeedSupply).route)
                        While (AGVList(AGVNum).Status = AGV.RobocarStatusValue.STOP_BY_CARD And (TimePoint + 5000) > Environment.TickCount) 'neu = Nomal-->false
                        End While
                        If (AGVList(AGVNum).Status <> AGV.RobocarStatusValue.STOP_BY_CARD) Then Exit For
                    Next
                    If (AGVList(AGVNum).Status <> AGV.RobocarStatusValue.STOP_BY_CARD) Then
                        AGVList(AGVNum).RequestRoute(PartList(partNeedSupply).route)
                        AGVList(AGVNum).SupplyPartName = PartList(partNeedSupply).Name
                        AGVList(AGVNum).WorkingStatus = AGV.RobocarWorkingStatusValue.SUPPLYING
                        'AGVList(AGVNum).Status = AGV.RobocarStatusValue.NORMAL
                        AGVList(AGVNum).SupplyTime = Now
                        AGVList(AGVNum).SupplyCount += 1
                        Record(AGVList(AGVNum).Name, "Status", "CALL_BY_SYSTEM", "Route", PartList(partNeedSupply).route, "Part", PartList(partNeedSupply).Name)
                        PartList(partNeedSupply).AGVSupply = AGVList(AGVNum).Name
                        PartList(partNeedSupply).SupplyCount += 1
                        PartList(partNeedSupply).SupplyTime = Now
                    End If
                End If
            End If
        Next
    End Sub
    Public Sub DoCrossFunc()
        CheckCross()

        If Not IsNothing(ParkPointArray) Then
            For AGVNum As Byte = 0 To AGVList.Count - 1
                If isCanRun(AGVNum) And (AGVList(AGVNum).Connecting = True) And (AGVList(AGVNum).Status = AGV.RobocarStatusValue.STOP_BY_CARD) Then
                    AGVList(AGVNum).AGVRun()
                    Record(AGVList(AGVNum).Name, "Status", "CALL_IN_PARKPOINT",,,,)
                    AGVList(AGVNum).Status = AGV.RobocarStatusValue.NORMAL
                End If
            Next
        End If
    End Sub
    Public Sub RecordData()
        AGVConnectRecord()
        AGVRouteRecord()
        AGVPositionRecord()
        AGVWorkingStatusRecord()
        AGVStatusRecord()

        PartConnectRecord()
        PartStatusRecord()
        PartAGVSupplyRecord()
    End Sub

#Region "Private function for RequestData"
    ''' <summary>
    ''' Check AGV that it's already for request new route or not
    ''' </summary>
    ''' <param name="AGVNum">The order number of AGV</param>
    ''' <returns>Return true if it's already for request new route, otherwise return false</returns>
    Private Function isAGVFree4Supply(ByVal AGVNum As Byte) As Boolean
        If AGVList(AGVNum).Enable And AGVList(AGVNum).Connecting And AGVList(AGVNum).WorkingStatus = AGV.RobocarWorkingStatusValue.FREE Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function isPartNeedSupply(ByVal PartNum As Byte) As Boolean
        If (PartList(PartNum).Enable And
            PartList(PartNum).parent.connecting And
            PartList(PartNum).Status = False And
            PartList(PartNum).AGVSupply = "" And
            PartList(PartNum).isRequested = False) Then
            Return True
        Else
            Return False
        End If
    End Function
    ''' <summary>
    ''' Compare priority of two parts
    ''' </summary>
    ''' <param name="CurentPart">First part to compare</param>
    ''' <param name="PrevPart">Second part to compare</param>
    ''' <returns>Return true if FirstPart's priority is higher or same with SecondPart's</returns>
    ''' <remarks></remarks>
    Private Function ComparePartPriority(ByVal CurentPart As Byte, ByVal PrevPart As Byte) As Boolean
        If PartList(CurentPart).priority < PartList(PrevPart).priority Then
            Return True
        ElseIf PartList(CurentPart).priority > PartList(PrevPart).priority Then
            Return False
        ElseIf PartList(CurentPart).CycleTime + Math.Round((Now - PartList(CurentPart).EmptyTime).TotalSeconds) > PartList(PrevPart).CycleTime + Math.Round((Now - PartList(PrevPart).EmptyTime).TotalSeconds) Then
            Return True
        ElseIf PartList(CurentPart).CycleTime + Math.Round((Now - PartList(CurentPart).EmptyTime).TotalSeconds) < PartList(PrevPart).CycleTime + Math.Round((Now - PartList(PrevPart).EmptyTime).TotalSeconds) Then
            Return False
        Else
            If PartList(CurentPart).EmptyTime <= PartList(PrevPart).EmptyTime Then
                Return True
            Else
                Return False
            End If
        End If
    End Function
    Private Function findSupplyPart4AGV(ByVal AGVNum As Byte) As Byte
        Dim returnValue As Byte = 99
        For PartNum As Byte = 0 To PartList.Count - 1
            If PartList(PartNum).isRequesting = True Then Continue For 'todo: thread
            If AGVnPART(AGVNum, PartNum) Then 'If AGVNum was setup for suply PartNum
                If isPartNeedSupply(PartNum) Then 'If PartNum is needed to supply
                    If returnValue = 99 Then 'If have only 1 Part need to supply after For next (trước đó chưa có part nào đủ đk)
                        returnValue = PartNum
                    Else 'If have > 1 part need to supply after For next
                        If ComparePartPriority(PartNum, returnValue) Then 'High priority
                            returnValue = PartNum
                        End If
                    End If
                End If
            End If
        Next
        Return returnValue
    End Function
#End Region
#Region "Private function for UpdateData"
    Private Sub UpdateWhenDisconnect(ByVal AGVNum As Byte)
        If preAGVStatusArray(AGVNum).connecting_value Then
            If preAGVStatusArray(AGVNum).working_value = AGV.RobocarWorkingStatusValue.FREE Then
                ChartDataTable.Rows(AGVNum)("Free") += (Now - preAGVStatusArray(AGVNum).working_time).TotalMinutes
                UpdateAllValue(AGVNum)
            Else
                Select Case preAGVStatusArray(AGVNum).status_value
                    Case AGV.RobocarStatusValue.EMERGENCY
                        ChartDataTable.Rows(AGVNum)("EMG") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                    Case AGV.RobocarStatusValue.SAFETY
                        ChartDataTable.Rows(AGVNum)("Safety") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                    Case AGV.RobocarStatusValue.STOP_BY_CARD
                        ChartDataTable.Rows(AGVNum)("Stop") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                    Case AGV.RobocarStatusValue.OUT_OF_LINE
                        ChartDataTable.Rows(AGVNum)("Out line") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                    Case AGV.RobocarStatusValue.BATTERY_EMPTY
                        ChartDataTable.Rows(AGVNum)("Battery empty") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                    Case AGV.RobocarStatusValue.NO_CART
                        ChartDataTable.Rows(AGVNum)("No cart") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                    Case AGV.RobocarStatusValue.NORMAL
                        ChartDataTable.Rows(AGVNum)("Normal") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                    Case AGV.RobocarStatusValue.POLE_ERROR
                        ChartDataTable.Rows(AGVNum)("Pole error") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                End Select
                UpdateAllValue(AGVNum)
            End If
        End If
    End Sub
    Private Sub UpdateWhenConnect(ByVal AGVNum As Byte)
        If preAGVStatusArray(AGVNum).connecting_value Then
            If AGVList(AGVNum).WorkingStatus = AGV.RobocarWorkingStatusValue.FREE Then
                If preAGVStatusArray(AGVNum).working_value <> AGV.RobocarWorkingStatusValue.FREE Then
                    Select Case preAGVStatusArray(AGVNum).status_value
                        Case AGV.RobocarStatusValue.EMERGENCY
                            ChartDataTable.Rows(AGVNum)("EMG") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                        Case AGV.RobocarStatusValue.SAFETY
                            ChartDataTable.Rows(AGVNum)("Safety") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                        Case AGV.RobocarStatusValue.STOP_BY_CARD
                            ChartDataTable.Rows(AGVNum)("Stop") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                        Case AGV.RobocarStatusValue.OUT_OF_LINE
                            ChartDataTable.Rows(AGVNum)("Out line") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                        Case AGV.RobocarStatusValue.BATTERY_EMPTY
                            ChartDataTable.Rows(AGVNum)("Battery empty") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                        Case AGV.RobocarStatusValue.NO_CART
                            ChartDataTable.Rows(AGVNum)("No cart") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                        Case AGV.RobocarStatusValue.NORMAL
                            ChartDataTable.Rows(AGVNum)("Normal") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                        Case AGV.RobocarStatusValue.POLE_ERROR
                            ChartDataTable.Rows(AGVNum)("Pole error") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                    End Select
                    UpdateAllValue(AGVNum)
                End If
            Else
                If preAGVStatusArray(AGVNum).working_value = AGV.RobocarWorkingStatusValue.FREE Then
                    ChartDataTable.Rows(AGVNum)("Free") += (Now - preAGVStatusArray(AGVNum).working_time).TotalMinutes
                    UpdateAllValue(AGVNum)
                Else
                    If preAGVStatusArray(AGVNum).status_value <> AGVList(AGVNum).Status Then
                        Select Case preAGVStatusArray(AGVNum).status_value
                            Case AGV.RobocarStatusValue.EMERGENCY
                                ChartDataTable.Rows(AGVNum)("EMG") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                            Case AGV.RobocarStatusValue.SAFETY
                                ChartDataTable.Rows(AGVNum)("Safety") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                            Case AGV.RobocarStatusValue.STOP_BY_CARD
                                ChartDataTable.Rows(AGVNum)("Stop") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                            Case AGV.RobocarStatusValue.OUT_OF_LINE
                                ChartDataTable.Rows(AGVNum)("Out line") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                            Case AGV.RobocarStatusValue.BATTERY_EMPTY
                                ChartDataTable.Rows(AGVNum)("Battery empty") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                            Case AGV.RobocarStatusValue.NO_CART
                                ChartDataTable.Rows(AGVNum)("No cart") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                            Case AGV.RobocarStatusValue.NORMAL
                                ChartDataTable.Rows(AGVNum)("Normal") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                            Case AGV.RobocarStatusValue.POLE_ERROR
                                ChartDataTable.Rows(AGVNum)("Pole error") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                        End Select
                        UpdateAllValue(AGVNum)
                    End If
                End If
            End If
        Else 'TimeAGVPowerOn: after | TimeAGVPowerOn_value: before | TimeAGVPowerOn default = 1
            If (AGVList(AGVNum).TimeAGVPowerOn <= preAGVStatusArray(AGVNum).TimeAGVPowerOn_value) And (AGVList(AGVNum).TimeAGVPowerOn > 0) Then  'If AGV turn on
                ChartDataTable.Rows(AGVNum)("Shutdown") += (Now - preAGVStatusArray(AGVNum).Shutdown_time).TotalMinutes
                UpdateAllValue(AGVNum)
            ElseIf preAGVStatusArray(AGVNum).TimeAGVPowerOn_value = 0 Then  'If System turn on
                ChartDataTable.Rows(AGVNum)("Shutdown") += (Now - preAGVStatusArray(AGVNum).Shutdown_time).TotalMinutes
                UpdateAllValue(AGVNum)
            Else
                ChartDataTable.Rows(AGVNum)("Disconnect") += (Now - preAGVStatusArray(AGVNum).connecting_time).TotalMinutes
                'Record(AGVList(AGVNum).Name, "UpdateConnect", AGVList(AGVNum).Connecting.ToString & ",preAGVOnTime," & preAGVStatusArray(AGVNum).TimeAGVPowerOn_value.ToString & ",Power," & AGVList(AGVNum).TimeAGVPowerOn.ToString)
                UpdateAllValue(AGVNum)
            End If
        End If
    End Sub
    Private Sub UpdateAllValue(ByVal AGVNum As Byte)
        preAGVStatusArray(AGVNum).connecting_value = AGVList(AGVNum).Connecting
        preAGVStatusArray(AGVNum).status_value = AGVList(AGVNum).Status
        preAGVStatusArray(AGVNum).working_value = AGVList(AGVNum).WorkingStatus
        preAGVStatusArray(AGVNum).Enable_value = AGVList(AGVNum).Enable
        preAGVStatusArray(AGVNum).TimeAGVPowerOn_value = AGVList(AGVNum).TimeAGVPowerOn

        preAGVStatusArray(AGVNum).connecting_time = Now
        preAGVStatusArray(AGVNum).status_time = Now
        preAGVStatusArray(AGVNum).working_time = Now
        preAGVStatusArray(AGVNum).Enable_time = Now
        preAGVStatusArray(AGVNum).Shutdown_time = Now
    End Sub
    Private Function isOnWorkingTime(ByVal hour As Integer, ByVal min As Integer) As Boolean
        Dim checkTime As DateTime = Now
        Dim endHour As DateTime = New DateTime(2015, 1, 1, 23, 59, 59)
        Dim zeroHour As DateTime = New DateTime(2015, 1, 1, 0, 0, 0)

        Dim day As String = ""
        Dim ShipName As String = ""
        FCheckTime(day, ShipName)


        If ShipName = "Day" Then
            Dim StartTime As DateTime = WorkingTimeArray(0).StartTime
            Dim StartMorningTime As DateTime = WorkingTimeArray(0).StartMorningTime
            Dim StopMorningTime As DateTime = WorkingTimeArray(0).StopMorningTime
            Dim StartLunchTime As DateTime = WorkingTimeArray(0).StartLunchTime
            Dim StopLunchTime As DateTime = WorkingTimeArray(0).StopLunchTime
            Dim StartAfterTime As DateTime = WorkingTimeArray(0).StartAfterTime
            Dim StopAfterTime As DateTime = WorkingTimeArray(0).StopAfterTime
            Dim StopTime As DateTime = WorkingTimeArray(0).StopTime

            If ((checkTime.TimeOfDay >= StartTime.TimeOfDay) And (checkTime.TimeOfDay <= StartMorningTime.TimeOfDay)) Or
                    ((checkTime.TimeOfDay >= StopMorningTime.TimeOfDay) And (checkTime.TimeOfDay <= StartLunchTime.TimeOfDay)) Or
                    ((checkTime.TimeOfDay >= StopLunchTime.TimeOfDay) And (checkTime.TimeOfDay <= StartAfterTime.TimeOfDay)) Or
                    ((checkTime.TimeOfDay >= StopAfterTime.TimeOfDay) And (checkTime.TimeOfDay <= StopTime.TimeOfDay)) Then
                Return True
            Else
                Return False
            End If
        ElseIf ShipName = "Night" Then
            Dim StartTime As DateTime = WorkingTimeArray(1).StartTime
            Dim StartMorningTime As DateTime = WorkingTimeArray(1).StartMorningTime
            Dim StopMorningTime As DateTime = WorkingTimeArray(1).StopMorningTime
            Dim StartLunchTime As DateTime = WorkingTimeArray(1).StartLunchTime
            Dim StopLunchTime As DateTime = WorkingTimeArray(1).StopLunchTime
            Dim StartAfterTime As DateTime = WorkingTimeArray(1).StartAfterTime
            Dim StopAfterTime As DateTime = WorkingTimeArray(1).StopAfterTime
            Dim StopTime As DateTime = WorkingTimeArray(1).StopTime

            If (checkTime.TimeOfDay >= StartTime.TimeOfDay) And (checkTime.TimeOfDay <= endHour.TimeOfDay) Then '<0h
                If ((checkTime.TimeOfDay >= StartTime.TimeOfDay) And (checkTime.TimeOfDay <= StartMorningTime.TimeOfDay)) Or
                    ((checkTime.TimeOfDay >= StopMorningTime.TimeOfDay) And (checkTime.TimeOfDay <= endHour.TimeOfDay)) Then
                    Return True
                Else
                    Return False
                End If
            ElseIf (checkTime.TimeOfDay >= zeroHour.TimeOfDay) And (checkTime.TimeOfDay <= StopTime.TimeOfDay) Then
                If ((checkTime.TimeOfDay >= zeroHour.TimeOfDay) And (checkTime.TimeOfDay <= StartLunchTime.TimeOfDay)) Or
                        ((checkTime.TimeOfDay >= StopLunchTime.TimeOfDay) And (checkTime.TimeOfDay <= StartAfterTime.TimeOfDay)) Or
                        ((checkTime.TimeOfDay >= StopAfterTime.TimeOfDay) And (checkTime.TimeOfDay <= StopTime.TimeOfDay)) Then
                    Return True
                Else
                    Return False
                End If
            End If

        End If
        Return False
    End Function
    Private Sub ForceUpdate()
        For i As Byte = 0 To AGVList.Count - 1
            If AGVList(i).Connecting Then
                ForceUpdateWhenConnect(i)
            Else
                ForceUpdateWhenDisconnect(i)
            End If
        Next
    End Sub
    Private Sub ForceUpdateWhenConnect(ByVal AGVNum As Byte)
        If preAGVStatusArray(AGVNum).connecting_value Then
            If AGVList(AGVNum).WorkingStatus = AGV.RobocarWorkingStatusValue.FREE Then
                If preAGVStatusArray(AGVNum).working_value = AGV.RobocarWorkingStatusValue.FREE Then
                    ChartDataTable.Rows(AGVNum)("Free") += (Now - preAGVStatusArray(AGVNum).working_time).TotalMinutes
                    UpdateAllValue(AGVNum)
                Else
                    Select Case preAGVStatusArray(AGVNum).status_value
                        Case AGV.RobocarStatusValue.EMERGENCY
                            ChartDataTable.Rows(AGVNum)("EMG") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                        Case AGV.RobocarStatusValue.SAFETY
                            ChartDataTable.Rows(AGVNum)("Safety") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                        Case AGV.RobocarStatusValue.STOP_BY_CARD
                            ChartDataTable.Rows(AGVNum)("Stop") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                        Case AGV.RobocarStatusValue.OUT_OF_LINE
                            ChartDataTable.Rows(AGVNum)("Out line") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                        Case AGV.RobocarStatusValue.BATTERY_EMPTY
                            ChartDataTable.Rows(AGVNum)("Battery empty") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                        Case AGV.RobocarStatusValue.NO_CART
                            ChartDataTable.Rows(AGVNum)("No cart") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                        Case AGV.RobocarStatusValue.NORMAL
                            ChartDataTable.Rows(AGVNum)("Normal") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                        Case AGV.RobocarStatusValue.POLE_ERROR
                            ChartDataTable.Rows(AGVNum)("Pole error") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                    End Select
                    UpdateAllValue(AGVNum)
                End If
            Else
                If preAGVStatusArray(AGVNum).working_value = AGV.RobocarWorkingStatusValue.FREE Then
                    ChartDataTable.Rows(AGVNum)("Free") += (Now - preAGVStatusArray(AGVNum).working_time).TotalMinutes
                    UpdateAllValue(AGVNum)
                Else
                    Select Case preAGVStatusArray(AGVNum).status_value
                        Case AGV.RobocarStatusValue.EMERGENCY
                            ChartDataTable.Rows(AGVNum)("EMG") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                        Case AGV.RobocarStatusValue.SAFETY
                            ChartDataTable.Rows(AGVNum)("Safety") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                        Case AGV.RobocarStatusValue.STOP_BY_CARD
                            ChartDataTable.Rows(AGVNum)("Stop") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                        Case AGV.RobocarStatusValue.OUT_OF_LINE
                            ChartDataTable.Rows(AGVNum)("Out line") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                        Case AGV.RobocarStatusValue.BATTERY_EMPTY
                            ChartDataTable.Rows(AGVNum)("Battery empty") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                        Case AGV.RobocarStatusValue.NO_CART
                            ChartDataTable.Rows(AGVNum)("No cart") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                        Case AGV.RobocarStatusValue.NORMAL
                            ChartDataTable.Rows(AGVNum)("Normal") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                        Case AGV.RobocarStatusValue.POLE_ERROR
                            ChartDataTable.Rows(AGVNum)("Pole error") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                    End Select
                    UpdateAllValue(AGVNum)
                End If
            End If
        Else
            If (AGVList(AGVNum).TimeAGVPowerOn <= preAGVStatusArray(AGVNum).TimeAGVPowerOn_value) And (AGVList(AGVNum).TimeAGVPowerOn > 0) Then  'If AGV turn on
                ChartDataTable.Rows(AGVNum)("Shutdown") += (Now - preAGVStatusArray(AGVNum).Shutdown_time).TotalMinutes
                UpdateAllValue(AGVNum)
            ElseIf preAGVStatusArray(AGVNum).TimeAGVPowerOn_value = 0 Then  'If System turn on
                ChartDataTable.Rows(AGVNum)("Shutdown") += (Now - preAGVStatusArray(AGVNum).Shutdown_time).TotalMinutes
                UpdateAllValue(AGVNum)
            Else
                ChartDataTable.Rows(AGVNum)("Disconnect") += (Now - preAGVStatusArray(AGVNum).connecting_time).TotalMinutes
                'Record(AGVList(AGVNum).Name, "ForceUpdateConnect", AGVList(AGVNum).Connecting.ToString & ",preAGVOnTime," & preAGVStatusArray(AGVNum).TimeAGVPowerOn_value.ToString & ",Power," & AGVList(AGVNum).TimeAGVPowerOn.ToString)
                UpdateAllValue(AGVNum)
            End If
        End If
    End Sub
    Private Sub ForceUpdateWhenDisconnect(ByVal AGVNum As Byte)
        If preAGVStatusArray(AGVNum).connecting_value Then
            If preAGVStatusArray(AGVNum).working_value = AGV.RobocarWorkingStatusValue.FREE Then
                ChartDataTable.Rows(AGVNum)("Free") += (Now - preAGVStatusArray(AGVNum).working_time).TotalMinutes
                UpdateAllValue(AGVNum)
            Else
                Select Case preAGVStatusArray(AGVNum).status_value
                    Case AGV.RobocarStatusValue.EMERGENCY
                        ChartDataTable.Rows(AGVNum)("EMG") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                    Case AGV.RobocarStatusValue.SAFETY
                        ChartDataTable.Rows(AGVNum)("Safety") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                    Case AGV.RobocarStatusValue.STOP_BY_CARD
                        ChartDataTable.Rows(AGVNum)("Stop") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                    Case AGV.RobocarStatusValue.OUT_OF_LINE
                        ChartDataTable.Rows(AGVNum)("Out line") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                    Case AGV.RobocarStatusValue.BATTERY_EMPTY
                        ChartDataTable.Rows(AGVNum)("Battery empty") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                    Case AGV.RobocarStatusValue.NO_CART
                        ChartDataTable.Rows(AGVNum)("No cart") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                    Case AGV.RobocarStatusValue.NORMAL
                        ChartDataTable.Rows(AGVNum)("Normal") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                    Case AGV.RobocarStatusValue.POLE_ERROR
                        ChartDataTable.Rows(AGVNum)("Pole error") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMinutes
                End Select
                UpdateAllValue(AGVNum)
            End If
        Else
            If (AGVList(AGVNum).TimeAGVPowerOn <= preAGVStatusArray(AGVNum).TimeAGVPowerOn_value) And (AGVList(AGVNum).TimeAGVPowerOn > 0) Then  'If AGV turn on
                ChartDataTable.Rows(AGVNum)("Shutdown") += (Now - preAGVStatusArray(AGVNum).Shutdown_time).TotalMinutes
                UpdateAllValue(AGVNum)
            ElseIf preAGVStatusArray(AGVNum).TimeAGVPowerOn_value = 0 Then  'If System turn on
                ChartDataTable.Rows(AGVNum)("Shutdown") += (Now - preAGVStatusArray(AGVNum).Shutdown_time).TotalMinutes
                UpdateAllValue(AGVNum)
            Else
                ChartDataTable.Rows(AGVNum)("Disconnect") += (Now - preAGVStatusArray(AGVNum).connecting_time).TotalMinutes
                'Record(AGVList(AGVNum).Name, "ForceUpdateDisconnect", AGVList(AGVNum).Connecting.ToString & ",preAGVOnTime," & preAGVStatusArray(AGVNum).TimeAGVPowerOn_value.ToString & ",Power," & AGVList(AGVNum).TimeAGVPowerOn.ToString)
                UpdateAllValue(AGVNum)
            End If
        End If
    End Sub
#End Region
#Region "Private function for RecordData"
    Function FindIdFromRoute(ByVal route As Integer) As Integer
        For i As Integer = 0 To PartList.Count - 1
            If PartList(i).route = route Then
                Return i
            End If
        Next
        Return -1
    End Function

    Public Sub AGVConnectRecord()
        Static PreAGVConnectStatusRecord() As Boolean = New Boolean(AGVList.Count - 1) {}
        For i As Byte = 0 To AGVList.Count - 1
            If PreAGVConnectStatusRecord(i) <> AGVList(i).Connecting Then
                Record(AGVList(i).Name, "Connect", AGVList(i).Connecting.ToString, "Restart", AGVList(i).RestartStt.ToString, "Power", AGVList(i).TimeAGVPowerOn.ToString)
                PreAGVConnectStatusRecord(i) = AGVList(i).Connecting
            End If
        Next
    End Sub
    Public Sub AGVRouteRecord()
        Static indexOfPart As Integer
        Static PreAGVRouteRecord() As Byte = New Byte(AGVList.Count - 1) {}
        For i As Byte = 0 To AGVList.Count - 1
            If PreAGVRouteRecord(i) <> AGVList(i).SupplyPartStatus Then

                indexOfPart = FindIdFromRoute(AGVList(i).SupplyPartStatus)
                If indexOfPart <> -1 Then
                    AGVList(i).SupplyPartName = PartList(indexOfPart).Name
                    AGVList(i).SupplyPartId = indexOfPart
                End If

                Record(AGVList(i).Name, "Supply part", AGVList(i).SupplyPartStatus.ToString, "Route", AGVList(i).SupplyPartStatus.ToString, "Part", AGVList(i).SupplyPartName)
                PreAGVRouteRecord(i) = AGVList(i).SupplyPartStatus
            End If
        Next
    End Sub
    Public Sub AGVPositionRecord()
        Static PreAGVPositionRecord() As Integer = New Integer(AGVList.Count - 1) {}
        For i As Byte = 0 To AGVList.Count - 1
            If PreAGVPositionRecord(i) <> AGVList(i).Position Then
                Record(AGVList(i).Name, "Position", AGVList(i).Position.ToString, "Route", AGVList(i).SupplyPartStatus.ToString, "Part", AGVList(i).SupplyPartName)
                PreAGVPositionRecord(i) = AGVList(i).Position

                If AGVList(i).Position = PartList(AGVList(i).SupplyPartId).TargetPoint And AGVList(i).Position <> 0 Then
                    Record(AGVList(i).Name, "Working status", "RETURNING", "Route", AGVList(i).SupplyPartStatus.ToString, "Part", AGVList(i).SupplyPartName)
                End If
            End If
        Next
    End Sub
    Public Sub AGVStatusRecord()
        Static PreAGVStatusRecord() As AGV.RobocarStatusValue = New AGV.RobocarStatusValue(AGVList.Count - 1) {}
        For i As Byte = 0 To AGVList.Count - 1
            If PreAGVStatusRecord(i) <> AGVList(i).Status Then
                Record(AGVList(i).Name, "Status", AGVList(i).Status.ToString, "Route", AGVList(i).SupplyPartStatus.ToString, "Part", AGVList(i).SupplyPartName)
                PreAGVStatusRecord(i) = AGVList(i).Status
            End If
        Next
    End Sub
    Public Sub AGVWorkingStatusRecord()
        Static PreAGVWorkingStatusRecord() As AGV.RobocarWorkingStatusValue = New AGV.RobocarWorkingStatusValue(AGVList.Count - 1) {}
        For i As Byte = 0 To AGVList.Count - 1
            If PreAGVWorkingStatusRecord(i) <> AGVList(i).WorkingStatus Then
                Record(AGVList(i).Name, "Working status", AGVList(i).WorkingStatus.ToString, "Route", AGVList(i).SupplyPartStatus.ToString, "Part", AGVList(i).SupplyPartName)
                PreAGVWorkingStatusRecord(i) = AGVList(i).WorkingStatus
            End If
        Next
    End Sub

    Public Sub PartConnectRecord()
        Static PrePartConnectRecord() As Boolean = New Boolean(PartList.Count - 1) {}
        For i As Byte = 0 To PartList.Count - 1
            If PrePartConnectRecord(i) <> PartList(i).parent.connecting Then
                Record(PartList(i).Name, "Connect", PartList(i).parent.connecting.ToString)
                PrePartConnectRecord(i) = PartList(i).parent.connecting
            End If
        Next
    End Sub
    Public Sub PartStatusRecord()
        Static PrePartStatusRecord() As Boolean = New Boolean(PartList.Count - 1) {}
        Static isFirstRecord As Boolean = True

        For i As Byte = 0 To PartList.Count - 1
            If PrePartStatusRecord(i) <> PartList(i).Status Then
                If isFirstRecord Then
                    PrePartStatusRecord(i) = PartList(i).Status
                    Continue For
                End If
                Record(PartList(i).Name, "Status", PartList(i).Status.ToString)
                PrePartStatusRecord(i) = PartList(i).Status
                If PartList(i).Status = True Then
                    PartList(i).EmptyCount += 1
                    RecordPartEmptyCounter()
                End If
            End If
        Next
        isFirstRecord = False
    End Sub
    Public Sub PartAGVSupplyRecord()
        Static PrePartStatusRecord() As String = New String(PartList.Count - 1) {}
        For i As Byte = 0 To PartList.Count - 1
            If PrePartStatusRecord(i) <> PartList(i).AGVSupply Then
                Record(PartList(i).Name, "AGV supply", PartList(i).AGVSupply)
                PrePartStatusRecord(i) = PartList(i).AGVSupply
            End If
        Next
    End Sub
    'for PDC test
    Public Sub RecordPartEmptyCounterInit()
        PartCounterList = New List(Of CPart)
        For i As Byte = 0 To PartList.Count - 1
            If PartList(i).Description <> "0" Then
                PartCounterList.Add(PartList(i))
            End If
        Next
    End Sub
    Private Sub RecordPartEmptyCounter()
        Dim str As String = "Line no: Q'ty" & vbCrLf
        Dim log As String = ""
        If PartCounterList.Count = 0 Then Return
        For i As Byte = 0 To PartCounterList.Count - 1
            str += PartCounterList(i).Description + ": " + PartCounterList(i).EmptyCount.ToString + vbCrLf
            log += PartCounterList(i).Description + ", " + PartCounterList(i).EmptyCount.ToString + ", "
        Next
        log += log.Remove(log.Length - 2)
        Try
            System.IO.File.WriteAllText(Part_EmptyCount + "Count.txt", "")
            My.Computer.FileSystem.WriteAllText(Part_EmptyCount + "Count.txt", str, True)
            'for log
            My.Computer.FileSystem.WriteAllText(Part_EmptyCount + "\log\" + Today.Year.ToString + Today.Month.ToString + Today.Day.ToString + ".csv", Now.ToString + ", " + log + vbCrLf, True)
        Catch ex As Exception
            Dim st As String = ""
            st += Now.ToString + ex.Message + vbCrLf
            My.Computer.FileSystem.WriteAllText("Record_EmptyCount_Error.txt", st, True)
        End Try
    End Sub

    Public Sub Record(ByVal section As String, ByVal par1 As String, ByVal value1 As String, Optional par2 As String = "", Optional value2 As String = "", Optional par3 As String = "", Optional value3 As String = "")
        Static objlock As Object = New Object
        Dim s As String = Now.ToString + "," + section + "," +
            par1 + "," + value1 + "," + par2 + "," + value2 + "," + par3 + "," + value3
        SyncLock objlock
            While write(s) = False 'loop until write ok
            End While
        End SyncLock
    End Sub

    Private Function write(ByVal s As String) As Boolean
        Try
            Using writer As StreamWriter = File.AppendText(Environment.CurrentDirectory + "\log\" + BlockName + "_" + Now.ToString("yyyyMMdd") + ".csv")
                writer.WriteLine(s)
                writer.Close()
            End Using
            Return True
        Catch ex As Exception
            Dim str As String = ""
            str += s + vbCrLf
            My.Computer.FileSystem.WriteAllText("Record_Error.txt", s, True)
            Return False
        End Try
    End Function

#End Region
#Region "Function for debug form"
    Public DebugForm As CDebug_Form
    Public Sub PrintToDebug(ByVal str As String)
        If IsAllowPrintDebug Then
            DebugForm.Print(str)
        End If
    End Sub
#End Region
#Region "Json"
    Public Sub DataTableToJson(ByVal dt As DataTable, ByRef json As String)
        json = JsonConvert.SerializeObject(dt, Formatting.Indented)
    End Sub
    Public Sub JsonToDataTable(ByVal json As String, ByRef dt As DataTable)
        dt = CType(JsonConvert.DeserializeObject(json, (GetType(DataTable))), DataTable) 'DirectCast==Ctype
    End Sub
#End Region

    Public Sub CopyFile(ByVal fileName As String, ByVal pathSrc As String, ByVal pathDest As String)
        If pathDest = "" Then Return
        Dim extention = fileName.Split(".")(1)
        Static objlock As Object = New Object

        If File.Exists(pathSrc + "/" + fileName) Then
            SyncLock objlock
                Try
                    File.Copy(pathSrc + "/" + fileName, pathSrc + "/" + "temp." + extention, True)
                Catch ex As Exception
                    My.Computer.FileSystem.WriteAllText("Copy_Error.txt", Now.ToString() + " Copy to temp error" + vbCrLf, True)
                End Try

                Try
                    File.Copy(pathSrc + "/" + "temp." + extention, pathDest, True)
                Catch ex As Exception
                    My.Computer.FileSystem.WriteAllText("Copy_Error.txt", Now.ToString() + " Copy to destination error" + vbCrLf, True)
                End Try
            End SyncLock
        End If
    End Sub

End Module
