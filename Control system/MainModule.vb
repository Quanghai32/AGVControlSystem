Imports System.Threading
Imports ControlSystemLibrary
Imports System.IO.Ports
Public Module MainModule
	Public UpdateThread As New Thread(AddressOf UpdateData)
	Public RequestThread As New Thread(AddressOf RequestData)
	Public DoCrossThread As New Thread(AddressOf DoCrossFunc)

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
				End If
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

	Public Sub UpdateData()
		For AGVNum As Byte = 0 To AGVArray.Length - 1
			If AGVArray(AGVNum).Connecting Then
				UpdateWhenConnect(AGVNum)
			Else
				UpdateWhenDisconnect(AGVNum)
			End If
		Next
	End Sub
	Public Sub RequestData()
		For AGVNum As Byte = 0 To AGVArray.Length - 1
			If isAGVFree4Supply(AGVNum) Then
				Dim partNeedSupply As Byte = findSupplyPart4AGV(AGVNum)
				If partNeedSupply <> 99 Then
					AGVArray(AGVNum).RequestRoute(partNeedSupply)
					AGVArray(AGVNum).WorkingStatus = AGV.RobocarWorkingStatusValue.SUPPLYING
					AGVArray(AGVNum).Status = AGV.RobocarStatusValue.NORMAL
					PartArray(partNeedSupply).AGVSupply = AGVArray(AGVNum).Name
				End If
			End If
		Next
	End Sub
	Public Sub DoCrossFunc()
		CheckCross()
	End Sub
#Region "Private function for RequestData"
	''' <summary>
	''' Check AGV that it's already for request new route or not
	''' </summary>
	''' <param name="AGVNum">The order number of AGV</param>
	''' <returns>Return true if it's already for request new route, otherwise return false</returns>
	Private Function isAGVFree4Supply(ByVal AGVNum As Byte) As Boolean
		If AGVArray(AGVNum).Enable And AGVArray(AGVNum).Connecting And AGVArray(AGVNum).WorkingStatus = AGV.RobocarWorkingStatusValue.FREE Then
			Return True
		Else
			Return False
		End If
	End Function
	Private Function isPartNeedSupply(ByVal PartNum As Byte) As Boolean
		If (PartArray(PartNum).Enable And _
			PartArray(PartNum).parent.connecting And _
			PartArray(PartNum).Status = False And _
			PartArray(PartNum).AGVSupply = "" And _
			PartArray(PartNum).isRequested = False) Then

			Return True
		Else
			Return False
		End If
	End Function
	''' <summary>
	''' Compare priority of two parts
	''' </summary>
	''' <param name="FirstPart">First part to compare</param>
	''' <param name="SecondPart">Second part to compare</param>
	''' <returns>Return true if FirstPart's priority is higher or same with SecondPart's</returns>
	''' <remarks></remarks>
	Private Function ComparePartPriority(ByVal FirstPart As Byte, ByVal SecondPart As Byte) As Boolean
		If PartArray(FirstPart).priority < PartArray(SecondPart).priority Then
			Return True
		ElseIf PartArray(FirstPart).priority > PartArray(SecondPart).priority Then
			Return False
		Else
			If PartArray(FirstPart).EmptyTime <= PartArray(SecondPart).EmptyTime Then
				Return True
			Else
				Return False
			End If
		End If
	End Function
	Private Function findSupplyPart4AGV(ByVal AGVNum As Byte) As Byte
		Dim returnValue As Byte = 99
		For PartNum As Byte = 0 To PartArray.Length - 1
			If AGVnPART(AGVNum, PartNum) Then
				If isPartNeedSupply(PartNum) Then
					If returnValue = 99 Then
						returnValue = PartNum
					Else
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
				ChartDataTable.Rows(AGVNum)("Free") += (Now - preAGVStatusArray(AGVNum).working_time).TotalMilliseconds
				UpdateAllValue(AGVNum)
			Else
				Select Case preAGVStatusArray(AGVNum).status_value
					Case AGV.RobocarStatusValue.EMERGENCY
						ChartDataTable.Rows(AGVNum)("EMG") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMilliseconds
					Case AGV.RobocarStatusValue.SAFETY
						ChartDataTable.Rows(AGVNum)("Safety") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMilliseconds
					Case AGV.RobocarStatusValue.STOP_BY_CARD
						ChartDataTable.Rows(AGVNum)("Stop") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMilliseconds
					Case AGV.RobocarStatusValue.OUT_OF_LINE
						ChartDataTable.Rows(AGVNum)("Out line") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMilliseconds
					Case AGV.RobocarStatusValue.BATTERY_EMPTY
						ChartDataTable.Rows(AGVNum)("Battery empty") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMilliseconds
					Case AGV.RobocarStatusValue.NO_CART
						ChartDataTable.Rows(AGVNum)("No cart") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMilliseconds
					Case AGV.RobocarStatusValue.NORMAL
						ChartDataTable.Rows(AGVNum)("Normal") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMilliseconds
				End Select
				UpdateAllValue(AGVNum)
			End If
		End If
	End Sub
	Private Sub UpdateWhenConnect(ByVal AGVNum As Byte)
		If preAGVStatusArray(AGVNum).connecting_value Then
			If AGVArray(AGVNum).WorkingStatus = AGV.RobocarWorkingStatusValue.FREE Then
				If Not preAGVStatusArray(AGVNum).working_value = AGV.RobocarWorkingStatusValue.FREE Then
					Select Case preAGVStatusArray(AGVNum).status_value
						Case AGV.RobocarStatusValue.EMERGENCY
							ChartDataTable.Rows(AGVNum)("EMG") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMilliseconds
						Case AGV.RobocarStatusValue.SAFETY
							ChartDataTable.Rows(AGVNum)("Safety") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMilliseconds
						Case AGV.RobocarStatusValue.STOP_BY_CARD
							ChartDataTable.Rows(AGVNum)("Stop") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMilliseconds
						Case AGV.RobocarStatusValue.OUT_OF_LINE
							ChartDataTable.Rows(AGVNum)("Out line") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMilliseconds
						Case AGV.RobocarStatusValue.BATTERY_EMPTY
							ChartDataTable.Rows(AGVNum)("Battery empty") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMilliseconds
						Case AGV.RobocarStatusValue.NO_CART
							ChartDataTable.Rows(AGVNum)("No cart") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMilliseconds
						Case AGV.RobocarStatusValue.NORMAL
							ChartDataTable.Rows(AGVNum)("Normal") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMilliseconds
					End Select
					UpdateAllValue(AGVNum)
				End If
			Else
				If preAGVStatusArray(AGVNum).working_value = AGV.RobocarWorkingStatusValue.FREE Then
					ChartDataTable.Rows(AGVNum)("Free") += (Now - preAGVStatusArray(AGVNum).working_time).TotalMilliseconds
					UpdateAllValue(AGVNum)
				Else
					If preAGVStatusArray(AGVNum).status_value <> AGVArray(AGVNum).Status Then
						Select Case preAGVStatusArray(AGVNum).status_value
							Case AGV.RobocarStatusValue.EMERGENCY
								ChartDataTable.Rows(AGVNum)("EMG") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMilliseconds
							Case AGV.RobocarStatusValue.SAFETY
								ChartDataTable.Rows(AGVNum)("Safety") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMilliseconds
							Case AGV.RobocarStatusValue.STOP_BY_CARD
								ChartDataTable.Rows(AGVNum)("Stop") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMilliseconds
							Case AGV.RobocarStatusValue.OUT_OF_LINE
								ChartDataTable.Rows(AGVNum)("Out line") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMilliseconds
							Case AGV.RobocarStatusValue.BATTERY_EMPTY
								ChartDataTable.Rows(AGVNum)("Battery empty") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMilliseconds
							Case AGV.RobocarStatusValue.NO_CART
								ChartDataTable.Rows(AGVNum)("No cart") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMilliseconds
							Case AGV.RobocarStatusValue.NORMAL
								ChartDataTable.Rows(AGVNum)("Normal") += (Now - preAGVStatusArray(AGVNum).status_time).TotalMilliseconds
						End Select
						UpdateAllValue(AGVNum)
					End If
				End If
			End If
		Else
			ChartDataTable.Rows(AGVNum)("Disconnect") += (Now - preAGVStatusArray(AGVNum).connecting_time).TotalMilliseconds
			UpdateAllValue(AGVNum)
		End If
	End Sub
	Private Sub UpdateAllValue(ByVal AGVNum As Byte)
		preAGVStatusArray(AGVNum).connecting_value = AGVArray(AGVNum).Connecting
		preAGVStatusArray(AGVNum).status_value = AGVArray(AGVNum).Status
		preAGVStatusArray(AGVNum).working_value = AGVArray(AGVNum).WorkingStatus

		preAGVStatusArray(AGVNum).connecting_time = Now
		preAGVStatusArray(AGVNum).status_time = Now
		preAGVStatusArray(AGVNum).working_time = Now
	End Sub
#End Region
End Module
