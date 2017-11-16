Module NormalConcept
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
        PrintToDebug(EnumDebugInfor.THREAD, Now.ToString() + ",Thread,RequestAGV," + AGVList(AGVnum).Name)
        AGVList(AGVnum).isRequesting = True 'todo: thread
        'Debug.WriteLine("start find Part" & Environment.TickCount.ToString)
        Dim partNeedSupply As Byte = findSupplyPart4AGV(AGVnum)
        'Debug.WriteLine("finise find Part" & Environment.TickCount)
        If partNeedSupply <> 99 Then
            PartList(partNeedSupply).isRequesting = True 'todo: thread
            For iTry As Byte = 0 To 4
                Dim TimePoint As Integer = Environment.TickCount
                AGVList(AGVnum).RequestRoute(PartList(partNeedSupply).route)
                Record("System", "Call", AGVList(AGVnum).Name, "Call_Time", iTry.ToString(), PartList(partNeedSupply).Name, PartList(partNeedSupply).route)
                PrintToDebug(EnumDebugInfor.REQUEST_AGV, Now.ToString() + ",Request," +
                             AGVList(AGVnum).Name + ",Call_Time," + iTry.ToString() + "," +
                             PartList(partNeedSupply).Name + "," +
                             PartList(partNeedSupply).route.ToString())
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
                PrintToDebug(EnumDebugInfor.REQUEST_AGV, Now.ToString() + "," + AGVList(AGVnum).Name +
                             ",CALL_BY_SYSTEM," + PartList(partNeedSupply).Name + "," +
                             PartList(partNeedSupply).route.ToString())
                PartList(partNeedSupply).AGVSupply = AGVList(AGVnum).Name
                PartList(partNeedSupply).SupplyCount += 1
                PartList(partNeedSupply).SupplyTime = Now
            End If
            PartList(partNeedSupply).isRequesting = False 'todo: thread
        End If
        AGVList(AGVnum).isRequesting = False 'todo: thread
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
#Region "Private function for RequestData"
    ''' <summary>
    ''' Check AGV that it's already for request new route or not
    ''' </summary>
    ''' <param name="AGVNum">The order number of AGV</param>
    ''' <returns>Return true if it's already for request new route, otherwise return false</returns>
    Public Function isAGVFree4Supply(ByVal AGVNum As Byte) As Boolean
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
End Module
