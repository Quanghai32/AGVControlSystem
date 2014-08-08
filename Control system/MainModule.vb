Imports System.Threading
Imports ControlSystemLibrary
Imports System.IO.Ports
Public Module MainModule
	Public UpdateThread As New Thread(AddressOf UpdateData)
	Public RequestThread As New Thread(AddressOf RequestData)
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


End Module
