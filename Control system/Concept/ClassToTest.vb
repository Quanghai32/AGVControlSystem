Imports MoreLinq

Public Class ClassToTest
    Public Sub Find2SupplyPart4AGV(ByVal agvNum As Byte, ByRef firstIndex As Byte, ByRef secondIndex As Byte, ByVal MockPartList As List(Of CPart))
        'PDC
        Dim firstList = MockPartList.Where(Function(p As CPart)
                                               Return p.TextSource = 0 And p.Text = True And p.connecting = True And
                                               p.Enable = True And p.Status = False And p.isRequested = False And
                                               p.AGVSupply = "" And p.isRequesting = False
                                           End Function).ToList()
        'LOG
        Dim secondList = MockPartList.Where(Function(p As CPart)
                                                Return p.TextSource = 1 And p.Text = True And p.connecting = True And
                                               p.Enable = True And p.Status = False And p.isRequested = False And
                                               p.AGVSupply = "" And p.isRequesting = False
                                            End Function).ToList()

        If firstList.Count = 0 And secondList.Count > 0 Then 'only second part
            Dim partInSecondList As CPart
            partInSecondList = secondList.MinBy(Function(p) p.priority)
            'secondIndex = MockPartList.FindIndex(Function(p) p.Name = partInSecondList.Name)
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
End Class

Public Class ClassTestModule
    Public Sub TestModule()
        SetupNewConcept()
    End Sub
End Class
