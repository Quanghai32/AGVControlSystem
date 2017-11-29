Imports System.Drawing
Imports System.Windows.Forms

Public Class PartDisplayControl
    Property InvertStatus As Boolean = False
    Property OKBackgoundColor As Color = Color.Green
    Property OKForeColor As Color = Color.Black
    Property NGBackgoundColor As Color = Color.Red
    Property NGForeColor As Color = Color.White
    Property DisColor As Color = Color.WhiteSmoke
    <System.ComponentModel.Description("This is name of this control in setting file")>
    Property PARTID As String

    Private myDev As EndDevices
    Private PartNum As Byte

    Public Sub setDataBinding(ByRef myDevices As EndDevices, ByVal PartNum As Byte)
        myDev = myDevices
        Me.PartNum = PartNum
        Me.DataBindings.Add(New Binding("Used", myDevices.Parts(PartNum), "Enable"))
        Me.DataBindings.Add(New Binding("PartName", myDevices.Parts(PartNum), "Name"))
        Me.DataBindings.Add(New Binding("ConnectStatus", myDevices, "connecting"))
        Me.DataBindings.Add(New Binding("PartStatus", myDevices.Parts(PartNum), "Status"))
        Me.DataBindings.Add(New Binding("AGVSupply", myDevices.Parts(PartNum), "AGVSupply"))
    End Sub

    Private _used As Boolean
    Public Property Used() As Boolean
        Get
            Return _used
        End Get
        Set(ByVal value As Boolean)
            SetUsed(value)
        End Set
    End Property

    Private _partName As String
    Public Property PartName() As String
        Get
            Return _partName
        End Get
        Set(ByVal value As String)
            SetPartName(value)
        End Set
    End Property

    Private _ConnectStatus As Boolean
    Public Property ConnectStatus() As Boolean
        Get
            Return _ConnectStatus
        End Get
        Set(ByVal value As Boolean)
            SetConnectStatus(value)
        End Set
    End Property

    Private _PartStatus As Boolean
    Public Property PartStatus() As Boolean
        Get
            Return _PartStatus
        End Get
        Set(ByVal value As Boolean)
            SetPartStatus(value)
        End Set
    End Property


    Private _AGVSupply As String
    Public Property AGVSupply() As String
        Get
            Return _AGVSupply
        End Get
        Set(ByVal value As String)
            SetAGVSupply(value)
        End Set
    End Property

    Private Delegate Sub SetUsedCallback(ByVal value As Boolean)
    Private Delegate Sub SetPartNameCallback(ByVal value As String)
    Private Delegate Sub SetConnectStatusCallback(ByVal value As Boolean)
    Private Delegate Sub SetPartStatusCallback(ByVal value As Boolean)
    Private Delegate Sub SetAGVSupplyCallback(ByVal value As String)

    Private Sub SetUsed(ByVal value As Boolean)
        If Me.InvokeRequired Then
            Dim d As New SetUsedCallback(AddressOf SetUsed)
            Me.Invoke(d, New Object() {value})
        Else
            _used = value
            grpPart.Enabled = value
            chkEnable.Checked = value
        End If
    End Sub
    Private Sub SetPartName(ByVal value As String)
        If Me.InvokeRequired Then
            Dim d As New SetPartNameCallback(AddressOf SetPartName)
            Me.Invoke(d, New Object() {value})
        Else
            _partName = value
            grpName.Text = value
        End If
    End Sub
    Private Sub SetConnectStatus(ByVal value As Boolean)
        If Me.InvokeRequired Then
            Dim d As New SetConnectStatusCallback(AddressOf SetConnectStatus)
            Me.Invoke(d, New Object() {value})
        Else
            _ConnectStatus = value
            If _used Then
                If value Then
                    txtConnectStatus.Text = "CONNECTING"
                    txtConnectStatus.ForeColor = OKForeColor
                    txtConnectStatus.BackColor = OKBackgoundColor
                Else
                    txtConnectStatus.Text = "DISCONNECT"
                    txtConnectStatus.ForeColor = NGForeColor
                    txtConnectStatus.BackColor = NGBackgoundColor
                End If
            Else
                txtConnectStatus.Text = ""
                txtConnectStatus.ForeColor = DisColor
                txtConnectStatus.BackColor = DisColor
            End If
        End If
    End Sub
    Private Sub SetPartStatus(ByVal value As Boolean)
        If Me.InvokeRequired Then
            Dim d As New SetPartStatusCallback(AddressOf SetPartStatus)
            Me.Invoke(d, New Object() {value})
        Else
            _PartStatus = value
            If _used Then
                If value Then
                    txtPartStatus.Text = "FULL"
                    If InvertStatus Then
                        txtPartStatus.ForeColor = NGForeColor
                        txtPartStatus.BackColor = NGBackgoundColor
                    Else
                        txtPartStatus.ForeColor = OKForeColor
                        txtPartStatus.BackColor = OKBackgoundColor
                    End If
                Else
                    txtPartStatus.Text = "EMPTY"
                    If InvertStatus Then
                        txtPartStatus.ForeColor = OKForeColor
                        txtPartStatus.BackColor = OKBackgoundColor
                    Else
                        txtPartStatus.ForeColor = NGForeColor
                        txtPartStatus.BackColor = NGBackgoundColor
                    End If
                End If
            Else
                txtPartStatus.Text = ""
                txtPartStatus.ForeColor = DisColor
                txtPartStatus.BackColor = DisColor
            End If
        End If
    End Sub
    Private Sub SetAGVSupply(ByVal value As String)
        If Me.InvokeRequired Then
            Dim d As New SetAGVSupplyCallback(AddressOf SetAGVSupply)
            Me.Invoke(d, New Object() {value})
        Else
            _AGVSupply = value
            If _used Then
                txtAGVSupply.Text = value
            Else
                txtPartStatus.Text = ""
            End If
        End If
    End Sub
    Private Sub chkEnable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEnable.CheckedChanged
        If IsNothing(myDev) Then Return
        myDev.Parts(PartNum).Enable = chkEnable.Checked
		myDev.connecting = myDev.connecting
        Dim iniFile As New CIniFile(Environment.CurrentDirectory + "\setting.ini")
        iniFile.WriteValue(PARTID, "enable", chkEnable.Checked.ToString)
    End Sub
End Class
