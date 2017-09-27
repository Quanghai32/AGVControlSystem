Public Class MapPart
    Private Sub MPart_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private _AGVSupply As String
	Private _status As Boolean = False				'Full or Empty
	Private _connectStatus As Boolean = False		'Connect or Disconnect
	Private _used As Boolean						'Enable or Disable
	Private _CurrentCount As Integer
	Private _route As Integer
	Private _name As String

	Private Delegate Sub SetAGVSupplyCallback(ByVal value As String)
	Private Delegate Sub SetStatusCallBack(ByVal value As Boolean)
	Private Delegate Sub SetConnectStatusCallback(ByVal value As Boolean)
	Private Delegate Sub SetUsedCallback(ByVal value As Boolean)
	Private Delegate Sub SetCurrentCountCallback(ByVal value As Integer)
	Private Delegate Sub SetPartNameCallBack(ByVal value As String)
	'///////////////////////////////////////////////////////////////////
	'location
	Property X As Integer
	Property Y As Integer
	'Name
	Property PartName As String
		Get
			Return _name
		End Get
		Set(value As String)
			labelName.UserText = value
			'SetName(value & "(" & _route.ToString & ")")
		End Set
	End Property
	Private Sub SetName(ByVal value As String)
		If Me.InvokeRequired Then
			Dim d As New SetPartNameCallBack(AddressOf SetName)
			Me.Invoke(d, New Object() {value})
		Else
			_name = value

		End If
	End Sub

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
	'Stt Full or Empty
	Property status As Boolean
		Get
			Return _status
		End Get
		Set(ByVal value As Boolean)
			SetStatus(value)
		End Set
	End Property
	Private Sub SetStatus(ByVal value As Boolean)
		If Me.InvokeRequired Then
			Dim d As New SetStatusCallBack(AddressOf SetStatus)
			Me.Invoke(d, New Object() {value})
		Else
			_status = value
			If value Then
				AGVSupply = ""
			Else
				AGVSupply = _AGVSupply
			End If
		End If
	End Sub
	'Connect or Disconnect
	Property ConnectStatus As Boolean
		Get
			Return _connectStatus
		End Get
		Set(ByVal value As Boolean)
			SetConnectStatus(value)
		End Set
	End Property
	Private Sub SetConnectStatus(ByVal value As Boolean)
		If Me.InvokeRequired Then
			Dim d As New SetConnectStatusCallback(AddressOf SetConnectStatus)
			Me.Invoke(d, New Object() {value})
		Else
			_connectStatus = value
			AGVSupply = _AGVSupply
		End If
	End Sub
	'Current count
	Property CurrentCount As Integer
		Get
			Return _CurrentCount
		End Get
		Set(value As Integer)
			SetCurentCount(value)
		End Set
	End Property
	Private Sub SetCurentCount(ByVal value As Integer)
		If Me.InvokeRequired Then
			Dim d As New SetCurrentCountCallback(AddressOf SetCurentCount)
			Me.Invoke(d, New Object() {value})
		Else
			_CurrentCount = value
			'labelCount.Text = _CurrentCount.ToString + "/" + TotalCount.ToString
		End If
	End Sub
	'AGV supply
	Property AGVSupply As String
		Get
			Return _AGVSupply
		End Get
		Set(value As String)
			SetAGVSupply(value)
		End Set
	End Property
	Private Sub SetAGVSupply(ByVal value As String)
		If Me.InvokeRequired Then
			Dim d As New SetAGVSupplyCallback(AddressOf SetAGVSupply)
			Me.Invoke(d, New Object() {value})
		Else
			_AGVSupply = value
			If _used = False Then
				'LabelAGV.UserText = ""
				'Hide()
                SetBackground(Color.LightGray)
			Else
				'Show()
				'LabelAGV.UserText = value
				If _connectStatus Then		'If status is connecting
					'Enabled = True
					If value = "" Then		'If no AGV supply
						If _status Then		'If part full
							SetBackground(Color.GreenYellow)
						Else				'Empty
							SetBackground(Color.Red)
						End If
					Else
						SetBackground(Color.Yellow)
					End If
				Else
					'Enabled = False
					SetBackground(Color.Gray)
				End If
			End If
		End If
	End Sub
	'Route
	Property route As Integer
		Get
			Return _route
		End Get
		Set(value As Integer)
			_route = value
		End Set
	End Property

	Private Sub SetBackground(c As Color)
		'labelName.BackColor = c
		'LabelAGV.BackColor = c
		BackColor = c
	End Sub

	Public Sub setDataBinding(part As CPart)
		Me.DataBindings.Add(New Binding("Used", part, "Enable"))				'Disable or Enable
		'Me.DataBindings.Add(New Binding("PartName", part, "Name"))
		Me.DataBindings.Add(New Binding("ConnectStatus", part, "connecting"))	'Connect or disconnect
		Me.DataBindings.Add(New Binding("status", part, "Status"))				'Empty or Full
		Me.DataBindings.Add(New Binding("AGVSupply", part, "AGVSupply"))
		'Me.DataBindings.Add(New Binding("route", part, "route"))
	End Sub

	Private Sub TimerShowDialog_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
		Me.Size = New System.Drawing.Size(MapPartWidth, MapPartHeight)
	End Sub

	Private Sub labelName_Click(sender As Object, e As EventArgs) 
		Me.BringToFront()
		If Me.Size.Height = MapPartHeight Then
			Me.Size = New System.Drawing.Size(97, 46)
			Timer1.Start()
		Else
			Me.Size = New System.Drawing.Size(MapPartWidth, MapPartHeight)
		End If
	End Sub
	''''''''''''''------for move and drag------''''''''''''''''
	Structure PickPos
		Dim X As Integer
		Dim Y As Integer
	End Structure
	Dim A, B, C, D As PickPos
	Public Pick As PickPos() = New PickPos(3) {}
	Dim CursorX, CursorY As Integer
	Dim Dragging As Boolean

    Private Sub MapPart_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Control_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
		If isReadOnlyMap Then Return
		If e.Button = Windows.Forms.MouseButtons.Left Then
			If My.Computer.Keyboard.CtrlKeyDown Then
				MyBase.BorderStyle = Forms.BorderStyle.Fixed3D
				PartForAlign.Add(Me)
			Else
				Me.BorderStyle = Forms.BorderStyle.None
				PartForAlign.Remove(Me)
				' Set the flag
				Dragging = True
				' Note positions of cursor when pressed
				CursorX = e.X
				CursorY = e.Y
				MyBase.Cursor = Cursors.Cross
			End If		
		End If
	End Sub

	Private Sub Control_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp
		If isReadOnlyMap Then Return
		If e.Button = Windows.Forms.MouseButtons.Left Then
			' Reset the flag
			Dragging = False
			MyBase.Cursor = Cursors.Default
		End If

	End Sub

	Private Sub Control_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
		If isReadOnlyMap Then Return
		If Dragging Then
			' Move the control according to mouse movement
			MyBase.Left = (MyBase.Left + e.X) - CursorX
			MyBase.Top = (MyBase.Top + e.Y) - CursorY
			X = MyBase.Left
			Y = MyBase.Top
			' Ensure moved control stays on top of anything it is dragged on to
			MyBase.BringToFront()
			A.X = MyBase.Left
			A.Y = MyBase.Top
			B.X = A.X + Width
			B.Y = A.Y
			C.X = A.X + Width
			C.Y = A.Y + Height
			D.X = A.X
			D.Y = A.Y + Height

			Pick(0) = A
			Pick(1) = B
			Pick(2) = C
			Pick(3) = D
		End If
	End Sub
	Public Sub New(ByVal width As Integer,ByVal height As Integer,ByVal isVertical As Boolean)

		' This call is required by the designer.
		InitializeComponent()

		A.X = MyBase.Left
		A.Y = MyBase.Top
		B.X = A.X + Width
		B.Y = A.Y
		C.X = A.X + Width
		C.Y = A.Y + Height
		D.X = A.X
		D.Y = A.Y + Height

		Pick(0) = A
		Pick(1) = B
		Pick(2) = C
		Pick(3) = D

        labelName.UserFont=new Font("Arial", 12)
        labelAGV.UserFont=new Font("Arial", 12)
        Me.Width=width
        Me.Height=height
        If isVertical
            labelName.UserDirection=StringFormatFlags.DirectionVertical
            labelAGV.UserDirection=StringFormatFlags.DirectionVertical
            labelName.Location=New Point(0,0)
            labelAGV.Location=New Point(18,0)
            labelAGV.UserText="AGV"
        End If
	End Sub
End Class
