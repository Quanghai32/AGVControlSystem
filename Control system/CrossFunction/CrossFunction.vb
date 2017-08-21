Imports ControlSystemLibrary
Public Module CrossFunction
#Region "Variable for cross function"
	Public MAX_CROSS As Byte = 1
	Public MAX_POS_IN_CROSS As Byte
	''' <summary>
	''' InCrossPosition(): các thẻ trong điểm Cross
	''' </summary>
	''' <remarks></remarks>
	Public Structure CrossStruct
		Public InCrossPosition() As Integer
		Public isExistAGV As Boolean
		Public AGVExist As String
	End Structure
	''' <summary>
	''' AGVCorssFlag(AGV,CrossPos): true mean AGV in CrossPos
	''' </summary>
	''' <remarks></remarks>
	Public AGVCrossFlag(,) As Boolean
	Public CrossArray() As CrossStruct
	Public Enum CrossState
		AGV_run
		AGV_Stop
		DontCare
	End Enum
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
	Public Sub initCrossVar()
		AGVCrossFlag = New Boolean(AGVList.Count - 1, CrossArray.Length - 1) {}
		For Each a In AGVCrossFlag
			a = False
		Next
		For i As Integer = 0 To MAX_CROSS - 1
			CrossArray(i).AGVExist = "AGVNo"
		Next
	End Sub
	Public Sub CheckCross()
		For iAGV As Byte = 0 To AGVList.Count - 1
			AGVCrossCheck(iAGV)
		Next
	End Sub
	Public Sub AGVCrossCheck(ByRef myAGVNumber As Byte)
		Dim CrossPositionIndex As Byte
		For CrossPositionIndex = 0 To MAX_CROSS - 1
			If isInCross(myAGVNumber, CrossPositionIndex) Then
				If CrossArray(CrossPositionIndex).isExistAGV = True Then	'Neu da co tg trong cross
					If AGVCrossFlag(myAGVNumber, CrossPositionIndex) = False And AGVList(myAGVNumber).Status = AGV.RobocarStatusValue.NORMAL Then 'Neu truoc do AGV chua o trong cross thi stop
						AGVList(myAGVNumber).AGVStop()
						AGVList(myAGVNumber).CrossNum = CrossPositionIndex.ToString
						AGVList(myAGVNumber).isStopByCross = True
						AGVList(myAGVNumber).Status = AGV.RobocarStatusValue.STOP_BY_CARD

                        Record(AGVList(myAGVNumber).Name, "Status", "CROSS_STOP", "Position", AGVList(myAGVNumber).Position.ToString, "CrossNum", CrossPositionIndex.ToString)
                        PrintToDebug(Now.ToString & " - " & AGVList(myAGVNumber).Name & " - STOP_by_cross" & " - Position - " & AGVList(myAGVNumber).Position.ToString & " - CrossNum - " & CrossPositionIndex.ToString & vbCrLf)

					End If
				Else 'Neu ko co tg nao trong cross
					CrossArray(CrossPositionIndex).isExistAGV = True		 'bao co tg trong cross
					CrossArray(CrossPositionIndex).AGVExist = AGVList(myAGVNumber).Name
					If (AGVList(myAGVNumber).Status = AGV.RobocarStatusValue.STOP_BY_CARD) And (AGVList(myAGVNumber).CrossNum = CrossPositionIndex) Then	'Neu hien tai dang dung thi cho chay tiep
						AGVList(myAGVNumber).AGVRun()
						AGVList(myAGVNumber).isStopByCross = False
						AGVList(myAGVNumber).Status = AGV.RobocarStatusValue.NORMAL
						AGVList(myAGVNumber).CrossNum = 9999

                        Record(AGVList(myAGVNumber).Name, "Status", "CROSS_RUN", "Position", AGVList(myAGVNumber).Position.ToString, "CrossNum", CrossPositionIndex.ToString)
                        PrintToDebug(Now.ToString & " - " & AGVList(myAGVNumber).Name & " - RUN_by_cross" & " - Position - " & AGVList(myAGVNumber).Position.ToString & " - CrossNum - " & CrossPositionIndex.ToString & vbCrLf)

					End If
				End If
				AGVCrossFlag(myAGVNumber, CrossPositionIndex) = True	'AGV đã vào Cross
			Else														'It mean RBC position different with all card in CardInArray
				'If AGVList(myAGVNumber).Position <> 0 Then
				If AGVCrossFlag(myAGVNumber, CrossPositionIndex) = True Then 'neu agv vua ra khoi cross
					CrossArray(CrossPositionIndex).isExistAGV = False 'báo cross không còn AGV
				End If
				AGVCrossFlag(myAGVNumber, CrossPositionIndex) = False 'báo AGV đã ra khỏi cross
				'End If
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
#Region "Test new cross"
    Public Sub AGVCrossCheck_Test_NG(ByRef myAGVNumber As Byte)
        Dim CrossPositionIndex As Byte
        For CrossPositionIndex = 0 To MAX_CROSS - 1
            If isInCross(myAGVNumber, CrossPositionIndex) Then
                If CrossArray(CrossPositionIndex).isExistAGV = True Then    'Neu da co tg trong cross
                    If AGVCrossFlag(myAGVNumber, CrossPositionIndex) = False And AGVList(myAGVNumber).Status = AGV.RobocarStatusValue.NORMAL Then 'Neu truoc do AGV chua o trong cross thi stop
                        AGVList(myAGVNumber).AGVStop()
                        AGVList(myAGVNumber).isStopByCross = True
                        Record(AGVList(myAGVNumber).Name, "Status", "STOP_by_cross", "Position", AGVList(myAGVNumber).Position.ToString, "CrossNum", CrossPositionIndex.ToString)
                        PrintToDebug(Now.ToString & AGVList(myAGVNumber).Name & " - STOP_by_cross" & " - Position - " & AGVList(myAGVNumber).Position.ToString & " - CrossNum - " & CrossPositionIndex.ToString & vbCrLf)
                        AGVList(myAGVNumber).Status = AGV.RobocarStatusValue.STOP_BY_CARD
                    End If
                Else 'Neu ko co tg nao trong cross
                    CrossArray(CrossPositionIndex).isExistAGV = True         'bao co tg trong cross
                    CrossArray(CrossPositionIndex).AGVExist = AGVList(myAGVNumber).Name
                    If AGVList(myAGVNumber).Status = AGV.RobocarStatusValue.STOP_BY_CARD Then 'Neu hien tai dang dung thi cho chay tiep
                        Record(AGVList(myAGVNumber).Name, "Status", "RUN_by_cross", "Position", AGVList(myAGVNumber).Position.ToString, "CrossNum", CrossPositionIndex.ToString)
                        PrintToDebug(Now.ToString & AGVList(myAGVNumber).Name & " - RUN_by_cross" & " - Position - " & AGVList(myAGVNumber).Position.ToString & " - CrossNum - " & CrossPositionIndex.ToString & vbCrLf)
                        AGVList(myAGVNumber).AGVRun()
                        AGVList(myAGVNumber).isStopByCross = False
                        AGVList(myAGVNumber).Status = AGV.RobocarStatusValue.NORMAL
                    End If
                End If
                AGVCrossFlag(myAGVNumber, CrossPositionIndex) = True    'AGV đã vào Cross
            Else                                                        'It mean RBC position different with all card in CardInArray
                If AGVList(myAGVNumber).Position <> 0 Then
                    If AGVCrossFlag(myAGVNumber, CrossPositionIndex) = True Then 'neu agv vua ra khoi cross
                        CrossArray(CrossPositionIndex).isExistAGV = False 'báo cross không còn AGV
                    End If
                    AGVCrossFlag(myAGVNumber, CrossPositionIndex) = False 'báo AGV đã ra khỏi cross
                End If
            End If
        Next
    End Sub
#End Region
End Module
