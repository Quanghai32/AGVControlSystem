Imports System.Windows.Forms

Public Class EndPointMap

    Public BindingPart As EndDevices
    Public BindingPartNum As Byte

    Public Sub BindDataToControl(ByVal part As EndDevices, ByVal num As Byte)
        Me.DataBindings.Clear()
        Me.DataBindings.Add(New Binding("PartName", part.Parts(num), "Name"))
        Me.DataBindings.Add(New Binding("Used", part.Parts(num), "Enable"))
        Me.DataBindings.Add(New Binding("Connecting", part, "connecting"))
        Me.DataBindings.Add(New Binding("Status", part, "Status"))
    End Sub
    Private _PartName As String
    Public Property PartName() As String
        Get
            Return _PartName
        End Get
        Set(ByVal value As String)
            _PartName = value
        End Set
    End Property

    Private _Used As Boolean
    Public Property Used() As Boolean
        Get
            Return _Used
        End Get
        Set(ByVal value As Boolean)
            _Used = value
        End Set
    End Property

    Private _Connecting As Boolean
    Public Property Connecting() As Boolean
        Get
            Return _Connecting
        End Get
        Set(ByVal value As Boolean)
            _Connecting = value
        End Set
    End Property

    Private _Status As String
    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            _Status = value
        End Set
    End Property

    Private Delegate Sub SetPartNameCallback(ByVal value As String)
    Private Delegate Sub SetUsedCallback(ByVal value As Boolean)
    Private Delegate Sub SetConnectingCallback(ByVal value As Boolean)
    Private Delegate Sub SetStatusCallback(ByVal value As Boolean)

    Private Sub SetPartName(ByVal value As Boolean)
        If Me.InvokeRequired Then
            Dim d As New SetPartNameCallback(AddressOf SetPartName)
            Me.Invoke(d, New Object() {value})
        Else
            _PartName = value
            LabName.Text = value
        End If
    End Sub
    Private Sub SetUsed(ByVal value As Boolean)
        If Me.InvokeRequired Then
            Dim d As New SetUsedCallback(AddressOf SetUsed)
            Me.Invoke(d, New Object() {value})
        Else
            _Used = value
            LabName.Enabled = _Used
            TxtStatus.Enabled = _Used
        End If
    End Sub
End Class
