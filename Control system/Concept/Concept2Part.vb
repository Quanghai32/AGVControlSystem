Imports MoreLinq

Module Concept2Part
    Public Sub SetupNewConcept()
        For Each agv In AGVList
            AddHandler agv.ChangePostion, AddressOf CheckAGVPosition
        Next
        NextPartNeedSupply = New Integer(AGVList.Count) {}
    End Sub

    Private Sub CheckAGVPosition(ByVal position As Integer, ByVal agvNum As Integer)
        Dim partNum As Integer = NextPartNeedSupply(agvNum)
        If AGVList(agvNum).Position = PartList(partNum).TargetPoint Then
            ChangeRoute(agvNum, partNum)
        End If
    End Sub

    Public Sub Request2Data()
        For AGVNum As Byte = 0 To AGVList.Count - 1
            If isAGVFree4Supply(AGVNum) Then
            If AGVList(AGVNum).isRequesting = False Then 'todo: thread
                Dim ThreadAGV As New Dictionary(Of String, Thread)()
                Dim variableName = "Thread"
                If ThreadAGV.ContainsKey(variableName & "(" & AGVNum.ToString() & ")") Then
                    If Not ThreadAGV(variableName & "(" & AGVNum.ToString() & ")").IsAlive Then
                        ThreadAGV(variableName & "(" & AGVNum.ToString() & ")") = New Thread(AddressOf RequestAGV2Route)
                        ThreadAGV(variableName & "(" & AGVNum.ToString() & ")").Name = "Thread " & AGVList(AGVNum).Name.ToString
                        ThreadAGV(variableName & "(" & AGVNum.ToString() & ")").Start(AGVNum)
                    End If
                Else
                    ThreadAGV(variableName & "(" & AGVNum.ToString() & ")") = New Thread(AddressOf RequestAGV2Route)
                    ThreadAGV(variableName & "(" & AGVNum.ToString() & ")").Name = "Thread " & AGVList(AGVNum).Name.ToString
                    ThreadAGV(variableName & "(" & AGVNum.ToString() & ")").Start(AGVNum)
                End If
            End If
            End If
        Next
    End Sub

    Private Sub RequestAGV2Route(ByVal agvNum As Byte)
        AGVList(agvNum).isRequesting = True
        Dim firstIndex, secondIndex As Byte
        Find2SupplyPart4AGV(firstIndex, secondIndex)
        If firstIndex = 99 And secondIndex <> 99 Then
            RequestRoute(agvNum, secondIndex)
        ElseIf firstIndex <> 99 And secondIndex = 99 Then
            RequestRoute(agvNum, firstIndex)
        ElseIf firstIndex <> 99 And secondIndex <> 99 Then
            RequestRoute(agvNum, firstIndex)
            'remember second part
            NextPartNeedSupply(agvNum) = secondIndex
            ChangeRoute(agvNum, secondIndex)
        End If
        AGVList(agvNum).isRequesting = False
    End Sub

    Private Sub ChangeRoute(ByVal agvNum As Byte, ByVal partNeedSupply As Byte)
        PartList(partNeedSupply).isRequesting = True 'todo: thread
        For iTry As Byte = 0 To 4
            Dim TimePoint As Integer = Environment.TickCount
            AGVList(agvNum).RequestRoute(PartList(partNeedSupply).route)
            While (AGVList(agvNum).Status = AGV.RobocarStatusValue.STOP_BY_CARD And (TimePoint + 5000) > Environment.TickCount) 'neu = Nomal-->false
            End While
            If (AGVList(agvNum).Status <> AGV.RobocarStatusValue.STOP_BY_CARD) Then Exit For
        Next
        If (AGVList(agvNum).Status <> AGV.RobocarStatusValue.STOP_BY_CARD) Then
            AGVList(agvNum).RequestRoute(PartList(partNeedSupply).route)
            AGVList(agvNum).WorkingStatus = AGV.RobocarWorkingStatusValue.SUPPLYING
            AGVList(agvNum).SupplyTime = Now
            AGVList(agvNum).SupplyCount += 1
            Record(AGVList(agvNum).Name, "Status", "CALL_BY_SYSTEM", "Route", PartList(partNeedSupply).route, "Part", PartList(partNeedSupply).Name)
            PartList(partNeedSupply).AGVSupply = AGVList(agvNum).Name
            PartList(partNeedSupply).SupplyCount += 1
            PartList(partNeedSupply).SupplyTime = Now
        End If
        PartList(partNeedSupply).isRequesting = False 'todo: thread
    End Sub

    Private Sub RequestRoute(ByVal agvNum As Byte, ByVal partNeedSupply As Byte)
        PartList(partNeedSupply).isRequesting = True 'todo: thread
        For iTry As Byte = 0 To 4
            Dim TimePoint As Integer = Environment.TickCount
            AGVList(agvNum).RequestRoute(PartList(partNeedSupply).route)
            While (AGVList(agvNum).Status = AGV.RobocarStatusValue.STOP_BY_CARD And (TimePoint + 5000) > Environment.TickCount) 'neu = Nomal-->false
            End While
            If (AGVList(agvNum).Status <> AGV.RobocarStatusValue.STOP_BY_CARD) Then Exit For
        Next
        If (AGVList(agvNum).Status <> AGV.RobocarStatusValue.STOP_BY_CARD) Then
            AGVList(agvNum).RequestRoute(PartList(partNeedSupply).route)
            AGVList(agvNum).WorkingStatus = AGV.RobocarWorkingStatusValue.SUPPLYING
            AGVList(agvNum).SupplyTime = Now
            AGVList(agvNum).SupplyCount += 1
            Record(AGVList(agvNum).Name, "Status", "CALL_BY_SYSTEM", "Route", PartList(partNeedSupply).route, "Part", PartList(partNeedSupply).Name)
            PartList(partNeedSupply).AGVSupply = AGVList(agvNum).Name
            PartList(partNeedSupply).SupplyCount += 1
            PartList(partNeedSupply).SupplyTime = Now
        End If
        PartList(partNeedSupply).isRequesting = False 'todo: thread
    End Sub

    Private Sub Find2SupplyPart4AGV(ByVal firstIndex As Byte, ByVal secondIndex As Byte)
        'PDC
        Dim firstList = PartList.Where(Function(p As CPart)
                                           Return p.TextSource = 0 And p.Text = True And p.connecting = True And
                                           p.Enable = True And p.Status = False And p.isRequested = False And
                                           p.AGVSupply = "" And p.isRequesting = False
                                       End Function).ToList()
        'LOG
        Dim secondList = PartList.Where(Function(p As CPart)
                                            Return p.TextSource = 1 And p.Text = True And p.connecting = True And
                                           p.Enable = True And p.Status = False And p.isRequested = False And
                                           p.AGVSupply = "" And p.isRequesting = False
                                        End Function).ToList()

        If firstList.Count = 0 And secondList.Count > 0 Then 'only second part
            Dim partInSecondList As CPart
            partInSecondList = secondList.MinBy(Function(p) p.priority)
            secondIndex = partInSecondList.index
            firstIndex = 99
            Return
        ElseIf firstList.Count > 0 And secondList.Count = 0 Then 'only first part
            Dim partInFirstList As CPart
            partInFirstList = firstList.MinBy(Function(p) p.priority)
            firstIndex = partInFirstList.index
            secondIndex = 99
            Return
        ElseIf firstList.Count = 0 And secondList.Count = 0 Then 'nothing part need to supply
            firstIndex = 99
            secondIndex = 99
            Return
        ElseIf firstList.Count > 0 And secondList.Count > 0 Then
            Dim firstMinPriority = firstList.Min(Function(p) p.priority)
            Dim secondMinPriority = secondList.Min(Function(p) p.priority)
            Dim partInSecondList As CPart
            Dim partInFirstList As CPart
            partInFirstList = firstList.MinBy(Function(p) p.priority)
            partInSecondList = secondList.MinBy(Function(p) p.priority)

            If firstMinPriority >= secondMinPriority Then 'call both of 2 part               
                firstIndex = partInFirstList.index
                secondIndex = partInSecondList.index
                Return
            ElseIf firstMinPriority < secondMinPriority Then 'only call firstPart
                firstIndex = partInFirstList.index
                secondIndex = 99
                Return
            End If
            Return
        End If
    End Sub
End Module
