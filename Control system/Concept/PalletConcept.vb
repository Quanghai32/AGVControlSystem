Module PalletConcept
    Public Sub RequestDataPallet()
        For AGVNum As Byte = 0 To AGVList.Count - 1
            If isAGVFree4Supply(AGVNum) Then
                If AGVList(AGVNum).isRequesting = False Then
                    Dim partNeedSupply As Byte = findSupplyPart4AGV(AGVNum)
                    If partNeedSupply <> 99 Then
                        PalletList(partNeedSupply).isRequesting = True
                        AGVList(AGVNum).isRequesting = True
                        Dim t As New Thread(AddressOf RequestSequence)
                        t.Start(New agv_supply With {.AgvNum = AGVNum, .PartNum = partNeedSupply})
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub RequestSequence(ByVal RequestInfo As agv_supply)
        Dim partNeedSupply As Integer = RequestInfo.PartNum
        Dim AGVnum As Integer = RequestInfo.AgvNum
        PrintToDebug(EnumDebugInfor.THREAD, Now.ToString("HH:mm:ss.fff") + ",RequestAGV," + AGVList(AGVnum).Name + "," + PalletList(partNeedSupply).Name)

        For iTry As Byte = 0 To 4
            Dim TimePoint As Integer = Environment.TickCount
            AGVList(AGVnum).RequestRoute(PalletList(partNeedSupply).route)
            Record("System", "Call", AGVList(AGVnum).Name, "Call_Time", iTry.ToString(), PalletList(partNeedSupply).Name, PalletList(partNeedSupply).route)
            PrintToDebug(EnumDebugInfor.REQUEST_AGV, Now.ToString() + ",Request," +
                         AGVList(AGVnum).Name + ",Call_Time," + iTry.ToString() + "," +
                         PalletList(partNeedSupply).Name + "," +
                         PalletList(partNeedSupply).route.ToString())
            While (AGVList(AGVnum).Status = AGV.RobocarStatusValue.STOP_BY_CARD And (TimePoint + 1000) > Environment.TickCount) 'neu = Nomal-->false
            End While
            If (AGVList(AGVnum).Status <> AGV.RobocarStatusValue.STOP_BY_CARD) Then Exit For
        Next
        If (AGVList(AGVnum).Status <> AGV.RobocarStatusValue.STOP_BY_CARD) Then
            AGVList(AGVnum).RequestRoute(PalletList(partNeedSupply).route)
            AGVList(AGVnum).WorkingStatus = AGV.RobocarWorkingStatusValue.SUPPLYING
            AGVList(AGVnum).SupplyTime = Now
            AGVList(AGVnum).SupplyCount += 1
            Record(AGVList(AGVnum).Name, "Status", "CALL_BY_SYSTEM", "Route", PalletList(partNeedSupply).route, "Part", PalletList(partNeedSupply).Name)
            PrintToDebug(EnumDebugInfor.REQUEST_AGV, Now.ToString() + "," + AGVList(AGVnum).Name +
                         ",CALL_BY_SYSTEM," + PalletList(partNeedSupply).Name + "," +
                         PalletList(partNeedSupply).route.ToString())
            If Not IsNothing(RequestForm) Then
                RequestForm.AddSupply(AGVList(AGVnum).Name, PalletList(partNeedSupply).Name +
                    "(" + PalletList(partNeedSupply).route.ToString + ")" +
                    "_No:" + PalletList(partNeedSupply).PalletNo.ToString() + "_Re:" +
                    PalletList(partNeedSupply).RemainPallet.ToString())
            End If
            PalletList(partNeedSupply).AGVSupply = AGVList(AGVnum).Name
            PalletList(partNeedSupply).SupplyCount += 1
            PalletList(partNeedSupply).SupplyTime = Now
        End If
        PalletList(partNeedSupply).isRequesting = False
        AGVList(AGVnum).isRequesting = False
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
        If (PalletList(PartNum).Enable And
            PalletList(PartNum).parent.connecting And
            PalletList(PartNum).Status = False And
            PalletList(PartNum).AGVSupply = "") Then
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
        If PalletList(CurentPart).RemainPallet < PalletList(PrevPart).RemainPallet Then'which part have smaller remain, that is higher priority
            Return True
        ElseIf PalletList(CurentPart).RemainPallet >= PalletList(PrevPart).RemainPallet Then
            Return False
        ElseIf PalletList(CurentPart).priority < PalletList(PrevPart).priority Then 'which part have smaller priority, that is higher priority
            Return True
        ElseIf PalletList(CurentPart).priority > PalletList(PrevPart).priority Then
            Return False
        ElseIf PalletList(CurentPart).CycleTime + Math.Round((Now - PalletList(CurentPart).EmptyTime).TotalSeconds) >
            PalletList(PrevPart).CycleTime + Math.Round((Now - PalletList(PrevPart).EmptyTime).TotalSeconds) Then
            Return True
        ElseIf PalletList(CurentPart).CycleTime + Math.Round((Now - PalletList(CurentPart).EmptyTime).TotalSeconds) < 
            PalletList(PrevPart).CycleTime + Math.Round((Now - PalletList(PrevPart).EmptyTime).TotalSeconds) Then
            Return False
        Else
            If PalletList(CurentPart).EmptyTime <= PalletList(PrevPart).EmptyTime Then 'which part have 
                Return True
            Else
                Return False
            End If
        End If
    End Function
    Private Function findSupplyPart4AGV(ByVal AGVNum As Byte) As Byte
        Dim returnValue As Byte = 99
        For PartNum As Byte = 0 To PalletList.Count - 1
            If PalletList(PartNum).isRequesting = True Then Continue For 'todo: thread
            Dim index As Integer = PartList.Where(Function(p) p.Name = PalletList(PartNum).Name).Select(Function(p) p.index).First()
            If AGVnPART(AGVNum, index) Then 'If AGVNum was setup for suply PartNum
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
