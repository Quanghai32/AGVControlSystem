Imports ControlSystemLibrary
Public Module CrossFunction
#Region "Variable for cross function"
    Public MAX_CROSS As Byte = 1
    Public Const MAX_POS_IN_CROSS As Byte = 10
    Public Structure CrossStruct
        Public InCrossPosition() As Integer
        Public isExistAGV As Boolean
    End Structure
    ''' <summary>
    ''' AGVCorssFlag(AGV,CrossPos): true mean AGV in CrossPos
    ''' </summary>
    ''' <remarks></remarks>
    Public AGVCrossFlag(,) As Boolean
    Public CrossArray() As CrossStruct
#End Region

#Region "Variable for call AGV in waiting zone"
    Public ParkPointArray(,) As Integer
#End Region

#Region "Function for cross function"
    Public Sub InitSingleCross(ByRef CrossPoint As CrossStruct, ByVal Position() As Integer)
        CrossPoint.InCrossPosition = New Integer(Position.Length - 1) {}
        For i As Byte = 0 To Position.Length - 1
            CrossPoint.InCrossPosition(i) = Position(i)
        Next
        CrossPoint.isExistAGV = False
    End Sub
    Public Sub CheckCross()
        For iAGV As Byte = 0 To AGVList.Count - 1
            AGVCrossCheck(iAGV)
        Next
    End Sub
    Public Sub initCrossVar()
        AGVCrossFlag = New Boolean(AGVList.Count - 1, CrossArray.Length - 1) {}
        For Each a In AGVCrossFlag
            a = False
        Next
    End Sub
    Public Sub AGVCrossCheck(ByRef myAGVNumber As Byte)
        Dim CrossPositionIndex As Byte
        For CrossPositionIndex = 0 To MAX_CROSS - 1
            If isInCross(myAGVNumber, CrossPositionIndex) Then
                If CrossArray(CrossPositionIndex).isExistAGV = True Then    'Neu da co tg trong cross
                    'Neu truoc do chua o trong cross thi stop
                    If AGVCrossFlag(myAGVNumber, CrossPositionIndex) = False And AGVList(myAGVNumber).Status = AGV.RobocarStatusValue.NORMAL Then
                        AGVList(myAGVNumber).AGVStop()
                        AGVList(myAGVNumber).Status = AGV.RobocarStatusValue.STOP_BY_CARD
                    End If
                Else 'Neu ko co tg nao trong cross
                    CrossArray(CrossPositionIndex).isExistAGV = True 'thong bao la da co tg trong cross
                    'Neu hien tai dang dung thi cho chay tiep
                    If AGVList(myAGVNumber).Status = AGV.RobocarStatusValue.STOP_BY_CARD Then
                        AGVList(myAGVNumber).AGVRun()
                        AGVList(myAGVNumber).Status = AGV.RobocarStatusValue.NORMAL
                    End If
                End If
                AGVCrossFlag(myAGVNumber, CrossPositionIndex) = True
            Else
                If AGVList(myAGVNumber).Position <> 0 Then  'It mean RBC position different with all card in CardInArray
                    If AGVCrossFlag(myAGVNumber, CrossPositionIndex) = True Then
                        CrossArray(CrossPositionIndex).isExistAGV = False
                    End If
                    AGVCrossFlag(myAGVNumber, CrossPositionIndex) = False
                End If
            End If
        Next
    End Sub
    Private Function isInCross(ByVal AGVNum As Byte, ByVal CrossNum As Byte) As Boolean
        For i As Byte = 0 To MAX_POS_IN_CROSS - 1
            If AGVList(AGVNum).Position = CrossArray(CrossNum).InCrossPosition(i) And CrossArray(CrossNum).InCrossPosition(i) <> 0 Then
                Return True
            End If
        Next
        Return False
    End Function
#End Region

#Region "Function for call AGV in waiting zone"
    Public Function isInPark(ByVal AGVNum As Byte) As Byte
        For i = 0 To ParkPointArray.GetLength(1) - 1
            If AGVList(AGVNum).Position = ParkPointArray(1, i) Then
                Return i
            End If
        Next
        Return 99
    End Function
    Public Function isCanRun(ByVal AGVNum As Byte) As Boolean
        Dim iPos = isInPark(AGVNum)
        If iPos <> 99 Then
            For i As Byte = 0 To AGVList.Count - 1
                If AGVList(i).Position = ParkPointArray(0, iPos) Then
                    Return False
                End If
            Next
            Return True
        End If
        Return False
    End Function
#End Region
End Module
