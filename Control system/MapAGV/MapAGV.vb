Imports System.Drawing
Imports System.Windows.Forms
Imports ControlSystemLibrary

Public Class MapAGV 'size=45,19
	Private _used As Boolean
	Private _AGVname As String
	Private _Battery As Byte() = New Byte(3) {}
	Private _SupplyPartStatus As Byte
	Private _WorkingStatus As Byte
	Private _Position As Integer
	Private _RunningStatus As AGV.RobocarStatusValue
	Private _Connecting As Boolean
	Private _ID As Integer
	Private _LastPosition As Integer


	Private Delegate Sub SetUsedCallback(ByVal value As Boolean)
	Private Delegate Sub SetAGVNameCallback(ByVal value As String)
	Private Delegate Sub SetBatteryCallback(ByVal value As Byte())
	Private Delegate Sub SetSupplyPartStatusCallBack(ByVal value As Byte)
	Private Delegate Sub SetWorkingStatusCallback(ByVal value As AGV.RobocarWorkingStatusValue)
	Private Delegate Sub SetPositionCallback(ByVal value As Integer)
	Private Delegate Sub SetRunningStatusCallback(ByVal value As AGV.RobocarStatusValue)
	Private Delegate Sub SetConnectingCallback(ByVal value As Boolean)
	'Color property
	Property OKColorBackground As Color = Color.Blue
	Property NormalColorBackground As Color = Color.Yellow
	Property NGColorBackground As Color = Color.Red
	Property OKColorText As Color = Color.White
	Property NormalColorText As Color = Color.Black
	Property NGColorText As Color = Color.White
	Property DisColor As Color = Color.WhiteSmoke

	Public Event DetectNewCard(ByVal CardID As Integer)

	'location

	'name
	Property AGVName As String
		Get
			Return LabelName.Text
		End Get
		Set(value As String)
			LabelName.Text = value
		End Set
	End Property

	'last position
	Private Sub Last_Position(ByVal Cur_position As Integer)
		If Cur_position = 0 Then
			_LastPosition = 0
		Else
			If MapAGVList.Contains(Cur_position.ToString) = True Then	'nếu thẻ không tồn tại - không cho vào lastposition
				_LastPosition = Cur_position
			End If
		End If
	End Sub

	'position
	Property Position As Integer
		Set(ByVal value As Integer)
			SetPosition(value)
			If value <> 0 Then			'Neu the = 0 thi khong update vị trí trước đó. Dùng trong trường hợp tắt đi bật lại nhiều lần.
				Last_Position(value)
			End If
		End Set
		Get
			Return _Position
		End Get
	End Property
	Private Sub SetPosition(ByVal value As Integer)
		If Me.InvokeRequired Then 'true if the control's System.Windows.Forms.Control.Handle was created on a different thread than the calling thread (indicating that you must make calls to the control through an invoke method); otherwise, false.
			Dim d As New SetPositionCallback(AddressOf SetPosition)
			Me.Invoke(d, New Object() {value})
		Else
			_Position = value

			If MapAGVList.Contains(value.ToString) = False Then
				Dim str As String = "No card " & value.ToString
				If value <> 0 Then					'neu the khong ton tai
					If IsNothing(CollectNotExistCard) Then CollectNotExistCard = New Collection
					If CollectNotExistCard.Contains(value) = False Then
						CollectNotExistCard.Add(value, value)
						RaiseEvent DetectNewCard(value)
					End If
				Else										'neu the =0
					If _LastPosition = 0 Then				'neu truoc do la the 0 - moi khoi dong chuong trinh
						Location = New Point(0, ID * 25)
					Else									'neu tat AGV bat lai
						Dim x, y As Integer
						x = CType(MapAGVList(_LastPosition.ToString), Label).Location.X
						y = CType(MapAGVList(_LastPosition.ToString), Label).Location.Y
						Location = New Point(x, y)
					End If
				End If
			Else
				Dim x, y As Integer
				x = CType(MapAGVList(value.ToString), Label).Location.X
				y = CType(MapAGVList(value.ToString), Label).Location.Y
				Location = New Point(x, y)
			End If
			Me.BringToFront()
		End If
	End Sub
	'ID
	Property ID As Integer
		Set(value As Integer)
			_ID = value
		End Set
		Get
			Return _ID
		End Get
	End Property
	'enable or disable
	Property Used As Boolean
		Set(ByVal value As Boolean)
			SetUsed(value)
		End Set
		Get
			Return _used
		End Get
	End Property
	Private Sub SetUsed(ByVal value As Boolean)
		If Me.InvokeRequired Then
			Dim d As New SetUsedCallback(AddressOf SetUsed)
			Me.Invoke(d, New Object() {value})
		Else
			_used = value
		End If
	End Sub
	'working stt
	Property WorkingStatus As AGV.RobocarWorkingStatusValue
		Set(ByVal value As AGV.RobocarWorkingStatusValue)
			SetWorkingStatus(value)
		End Set
		Get
			Return _WorkingStatus
		End Get
	End Property
	Private Sub SetWorkingStatus(ByVal value As AGV.RobocarWorkingStatusValue)
		If Me.InvokeRequired Then
			Dim d As New SetWorkingStatusCallback(AddressOf SetWorkingStatus)
			Me.Invoke(d, New Object() {value})
		Else
			_WorkingStatus = value
		End If
	End Sub
	'part supply
	Property SupplyPartStatus As Byte
		Get
			Return _SupplyPartStatus
		End Get
		Set(value As Byte)
			SetSupplyPartStt(value)
		End Set
	End Property
	Private Sub SetSupplyPartStt(ByVal value As Byte)
		If Me.InvokeRequired Then
			Dim d As New SetSupplyPartStatusCallBack(AddressOf SetSupplyPartStt)
			Me.Invoke(d, New Object() {value})
		Else
			_SupplyPartStatus = value
			LabelPartSupply.Text = value.ToString
		End If
	End Sub
	'running stt
	Property RunningStatus As AGV.RobocarStatusValue
		Set(ByVal value As AGV.RobocarStatusValue)
			SetRunningStatus(value)
		End Set
		Get
			Return _RunningStatus
		End Get
	End Property
	Private Sub SetRunningStatus(ByVal value As AGV.RobocarStatusValue)
		If Me.InvokeRequired Then
			Dim d As New SetRunningStatusCallback(AddressOf SetRunningStatus)
			Me.Invoke(d, New Object() {value})
		Else
			If Not Used Then
				Hide()
			Else
				Show()
				Select Case value
					Case AGV.RobocarStatusValue.POLE_ERROR, AGV.RobocarStatusValue.NO_CART, AGV.RobocarStatusValue.SAFETY
						SetBackground(Color.Yellow)
					Case AGV.RobocarStatusValue.EMERGENCY, AGV.RobocarStatusValue.OUT_OF_LINE, AGV.RobocarStatusValue.BATTERY_EMPTY
						SetBackground(Color.Red)
					Case AGV.RobocarStatusValue.STOP_BY_CARD
						If WorkingStatus = 0 Then
							SetBackground(Color.Cyan) 'Free
						Else
							SetBackground(Color.Violet)	'Normal stop
						End If
					Case Else
						SetBackground(Color.GreenYellow) 'Normal
				End Select
			End If
			_RunningStatus = value
			LabelStt.Text = value.ToString
		End If
	End Sub
	'connnect or disconnect
	Property Connecting As Boolean
		Set(ByVal value As Boolean)
			SetConnecting(value)
		End Set
		Get
			Return _Connecting
		End Get
	End Property
	Private Sub SetConnecting(ByVal value As Boolean)
		If Me.InvokeRequired Then
			Dim d As New SetConnectingCallback(AddressOf SetConnecting)
			Me.Invoke(d, New Object() {value})
		Else
			If Not Used Then
				Hide()
			Else
				Show()
				If Not value Then
					SetBackground(Color.Gray)
				End If
			End If
			_Connecting = value
		End If
	End Sub

	Public Sub setDataBinding(rbc As AGV)
		Me.DataBindings.Add(New Binding("Used", rbc, "Enable"))
		Me.DataBindings.Add(New Binding("AGVname", rbc, "Name"))
		'Me.DataBindings.Add(New Binding("Battery", rbc, "Battery"))
		Me.DataBindings.Add(New Binding("SupplyPartStatus", rbc, "SupplyPartStatus"))
		Me.DataBindings.Add(New Binding("WorkingStatus", rbc, "WorkingStatus"))
		Me.DataBindings.Add(New Binding("Position", rbc, "Position"))
		Me.DataBindings.Add(New Binding("RunningStatus", rbc, "Status"))
		Me.DataBindings.Add(New Binding("Connecting", rbc, "Connecting"))
	End Sub
	Private Sub SetBackground(c As Color)
		LabelName.BackColor = c
		BackColor = c
	End Sub

	Private Sub LabelName_Click(sender As Object, e As EventArgs) Handles LabelName.Click
		Me.BringToFront()
		If Me.Size.Height = 20 Then
			Me.Size = New System.Drawing.Size(150, 55)
			TimerDialog.Start()
		Else
			Me.Size = New System.Drawing.Size(46, 20)
		End If
	End Sub

	Private Sub TimerDialog_Tick(sender As Object, e As EventArgs) Handles TimerDialog.Tick
		Me.Size = New System.Drawing.Size(46, 20)
	End Sub
	Public Sub DisplayWhenFind()
		Me.Size = New System.Drawing.Size(150, 55)
		TimerAlarm.Start()
	End Sub

	Private Sub TimerAlarm_Tick(sender As Object, e As EventArgs) Handles TimerAlarm.Tick
		Static i As Byte
		Static blink As Boolean
		i += 1
		If i = 15 Then
			i = 0
			TimerAlarm.Stop()
			Me.Size = New System.Drawing.Size(46, 20)
		End If
		If blink Then
			SetBackground(Color.Yellow)
			blink = False
		Else
			SetBackground(Color.Red)
			blink = True
		End If
	End Sub

	''''''''''''''------for move and drag------''''''''''''''''
	Dim X, Y As Integer
	Dim Dragging As Boolean
	Public isReadOnly As Boolean
	Private Sub Control_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
		If isReadOnly Then Return
		If e.Button = Windows.Forms.MouseButtons.Left Then
			' Set the flag
			Dragging = True
			' Note positions of cursor when pressed
			X = e.X
			Y = e.Y
			MyBase.Cursor = Cursors.Cross
		End If
	End Sub

	Private Sub Control_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp
		If isReadOnly Then Return
		If e.Button = Windows.Forms.MouseButtons.Left Then
			' Reset the flag
			Dragging = False
			MyBase.Cursor = Cursors.Default
		End If

	End Sub

	Private Sub Control_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
		If isReadOnly Then Return
		If Dragging Then
			' Move the control according to mouse movement
			MyBase.Left = (MyBase.Left + e.X) - X
			MyBase.Top = (MyBase.Top + e.Y) - Y
			' Ensure moved control stays on top of anything it is dragged on to
			MyBase.BringToFront()
		End If
	End Sub
End Class

