Imports System.Windows.Forms
Imports System.Drawing

Public Class AGVDisplay
    Private _Robocar As AGV
    Property Robocar As AGV
        Get
            Return _Robocar
        End Get
        Set(ByVal value As AGV)
            _Robocar = value
            If IsNothing(value) Then Return
            Me.DataBindings.Clear()
            Me.DataBindings.Add(New Binding("Used", value, "Enable"))
            Me.DataBindings.Add(New Binding("AGVname", value, "Name"))
            Me.DataBindings.Add(New Binding("Battery", value, "Battery"))
            Me.DataBindings.Add(New Binding("SupplyPartStatus", value, "SupplyPartStatus"))
            Me.DataBindings.Add(New Binding("WorkingStatus", value, "WorkingStatus"))
            Me.DataBindings.Add(New Binding("Position", value, "Position"))
            Me.DataBindings.Add(New Binding("RunningStatus", value, "Status"))
            Me.DataBindings.Add(New Binding("Connecting", value, "Connecting"))
        End Set
    End Property
    'Color property
    Property OKColorBackground As Color = Color.Blue
    Property NormalColorBackground As Color = Color.Yellow
    Property NGColorBackground As Color = Color.Red
    Property OKColorText As Color = Color.White
    Property NormalColorText As Color = Color.Black
    Property NGColorText As Color = Color.White
    Property DisColor As Color = Color.WhiteSmoke

    Property AGVID As String = "AGV"

    Private usedValue As Boolean
    Private AGVnameValue As String
    Private batteryValue As Byte() = New Byte(3) {}
    Private SupplyPartStatusValue As Byte
    Private WorkingStatusValue As Byte
    Private PositionValue As Integer
    Private RunningStatusValue As Byte
    Private ConnectingValue As Boolean

    Property Used As Boolean
        Set(ByVal value As Boolean)
            SetUsed(value)
        End Set
        Get
            Return usedValue
        End Get
	End Property
	Private Sub SetUsed(ByVal value As Boolean)
		If Me.InvokeRequired Then
			Dim d As New SetUsedCallback(AddressOf SetUsed)
			Me.Invoke(d, New Object() {value})
		Else
			grpAGVdisplay.Enabled = value
			chkEnable.Checked = value
			usedValue = value
		End If
	End Sub
	'////////
    Property AGVname As String
        Set(ByVal value As String)
            SetAGVName(value)
        End Set
        Get
            Return AGVnameValue
        End Get
	End Property
	Private Sub SetAGVName(ByVal value As String)
		' InvokeRequired required compares the thread ID of the
		' calling thread to the thread ID of the creating thread.
		' If these threads are different, it returns true.
		If Me.InvokeRequired Then
			Dim d As New SetAGVNameCallback(AddressOf SetAGVName)
			Me.Invoke(d, New Object() {value})
		Else
			Me.grpName.Text = value
			AGVnameValue = value
		End If
	End Sub
	'///////////
    Property Battery As Byte()
        Set(ByVal value As Byte())
            SetBattery(value)
        End Set
        Get
            Return batteryValue
        End Get
	End Property
	Private Sub SetBattery(ByVal value As Byte())
		If Me.InvokeRequired Then
			Dim d As New SetBatteryCallback(AddressOf SetBattery)
			Me.Invoke(d, New Object() {value})
		Else
			BatteryDisplay1.value = value(0)
			BatteryDisplay2.value = value(1)
			BatteryDisplay3.value = value(2)
			BatteryDisplay4.value = value(3)
			Dim i
			For i = 0 To 3
				batteryValue(i) = value(i)
			Next
		End If
	End Sub
	'///////////
    Property SupplyPartStatus As Byte
        Set(ByVal value As Byte)
            SetSupplyPartStatus(value)
        End Set
        Get
            Return SupplyPartStatusValue
        End Get
	End Property
	Private Sub SetSupplyPartStatus(ByVal value As Byte)
		If Me.InvokeRequired Then
			Dim d As New SetSupplyPartStatusCallBack(AddressOf SetSupplyPartStatus)
			Me.Invoke(d, New Object() {value})
		Else
			inpPart.Text = value
			SupplyPartStatusValue = value
		End If
	End Sub
	'///////////////
    Property WorkingStatus As Byte
        Set(ByVal value As Byte)
            SetWorkingStatus(value)
        End Set
        Get
            Return WorkingStatusValue
        End Get
	End Property
	Private Sub SetWorkingStatus(ByVal value As Byte)
		If Me.InvokeRequired Then
			Dim d As New SetWorkingStatusCallback(AddressOf SetWorkingStatus)
			Me.Invoke(d, New Object() {value})
		Else
			If Not Used Then
				inpWorkingStatus.Text = ""
				inpWorkingStatus.BackColor = DisColor
			Else
				If value = 0 Then
					inpWorkingStatus.Text = Robocar.RobocarWorkingStatusName(value)
					inpWorkingStatus.ForeColor = NormalColorText
					inpWorkingStatus.BackColor = NormalColorBackground
				Else
					inpWorkingStatus.Text = Robocar.RobocarWorkingStatusName(value)
					inpWorkingStatus.ForeColor = OKColorText
					inpWorkingStatus.BackColor = OKColorBackground
				End If
			End If
			WorkingStatusValue = value
		End If
	End Sub
	'/////////////
    Property Position As Integer
        Set(ByVal value As Integer)
            SetPosition(value)
        End Set
        Get
            Return PositionValue
        End Get
	End Property
	Private Sub SetPosition(ByVal value As Integer)
		If Me.InvokeRequired Then
			Dim d As New SetPositionCallback(AddressOf SetPosition)
			Me.Invoke(d, New Object() {value})
		Else
			inpPosition.Text = value
			PositionValue = value
		End If
	End Sub
	'//////////////
    Property RunningStatus As Byte
        Set(ByVal value As Byte)
            SetRunningStatus(value)
        End Set
        Get
            Return RunningStatusValue
        End Get
	End Property
	Private Sub SetRunningStatus(ByVal value As Byte)
		If Me.InvokeRequired Then
			Dim d As New SetRunningStatusCallback(AddressOf SetRunningStatus)
			Me.Invoke(d, New Object() {value})
		Else
			If Not Used Then
				inpRunningStatus.Text = ""
				inpRunningStatus.BackColor = DisColor
			Else
				inpRunningStatus.Text = Robocar.RobocarStatusName(value)
				Select Case value
					Case 0, 1, 4, 5, 6
						inpRunningStatus.ForeColor = NGColorText
						inpRunningStatus.BackColor = NGColorBackground
					Case 2
						inpRunningStatus.ForeColor = NormalColorText
						inpRunningStatus.BackColor = NormalColorBackground
					Case Else
						inpRunningStatus.ForeColor = OKColorText
						inpRunningStatus.BackColor = OKColorBackground
				End Select
			End If
			RunningStatusValue = value
		End If
	End Sub
	'//////////////
    Property Connecting As Boolean
        Set(ByVal value As Boolean)
            SetConnecting(value)
        End Set
        Get
            Return ConnectingValue
        End Get
	End Property
	Private Sub SetConnecting(ByVal value As Boolean)
		If Me.InvokeRequired Then
			Dim d As New SetConnectingCallback(AddressOf SetConnecting)
			Me.Invoke(d, New Object() {value})
		Else
			If Not Used Then
				inpConnectingStatus.Text = ""
				inpConnectingStatus.BackColor = DisColor
			Else
				If value Then
					inpConnectingStatus.Text = "Connected"
					inpConnectingStatus.BackColor = OKColorBackground
					inpConnectingStatus.ForeColor = OKColorText
				Else
					inpConnectingStatus.Text = "Disconnect"
					inpConnectingStatus.BackColor = NGColorBackground
					inpConnectingStatus.ForeColor = NGColorText
				End If
			End If
			ConnectingValue = value
		End If
	End Sub
	'////////////
    Private Sub ChkEnable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEnable.CheckedChanged
        Robocar.Enable = chkEnable.Checked
        Dim iniFile As CIniFile
        iniFile = New CIniFile(Environment.CurrentDirectory + "\setting.ini")
        iniFile.WriteValue(AGVID, "enable", chkEnable.Checked.ToString)
    End Sub

    Private Delegate Sub SetUsedCallback(ByVal value As Boolean)
    Private Delegate Sub SetAGVNameCallback(ByVal value As String)
    Private Delegate Sub SetBatteryCallback(ByVal value As Byte())
    Private Delegate Sub SetSupplyPartStatusCallBack(ByVal value As Byte)
    Private Delegate Sub SetWorkingStatusCallback(ByVal value As Byte)
    Private Delegate Sub SetPositionCallback(ByVal value As Integer)
    Private Delegate Sub SetRunningStatusCallback(ByVal value As Byte)
    Private Delegate Sub SetConnectingCallback(ByVal value As Boolean)


End Class