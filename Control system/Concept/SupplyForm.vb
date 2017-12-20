Public Class SupplyForm
    Private Delegate Sub SetPrintCallBack(ByVal item As Control, ByVal prop As String, ByVal value As Object)
    Private Delegate Sub AddControlDelegate(ByVal item As Control)
    Private Delegate Sub RemoveControlDelegate(ByVal key As String)

    Private Sub SetAnyProperty(ByVal item As Control, ByVal prop As String, ByVal value As Object)
        If Me.InvokeRequired Then
            Dim d As New SetPrintCallBack(AddressOf SetAnyProperty)
            Me.Invoke(d, New Object() {item, prop, value})
        Else
            Dim propertyInfo As PropertyInfo = item.[GetType]().GetProperty(prop)
            propertyInfo.SetValue(item, Convert.ChangeType(value, propertyInfo.PropertyType), Nothing)
        End If
    End Sub
    Private Sub SupplyForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.AutoSize = True
        Me.ControlBox = False
        'Dim uc As ucAgvSupply = New ucAgvSupply()
        'uc.LabelAgv.Text = "test"
        'uc.Dock = DockStyle.Top
        'AddHandler uc.DeleteControl,AddressOf RemoveCtrl
        'Me.Controls.Add(uc)      
    End Sub

    'Public Sub AddSupply(ByVal agvName As String, ByVal firstPart As String, ByVal secondPart As String)
    '    Dim uc As ucAgvSupply = New ucAgvSupply()
    '    uc.Name = agvName
    '    uc.LabelAgv.Text = agvName
    '    uc.Dock = DockStyle.Top

    '    If firstPart <> "" Then
    '        uc.LabelFirstPart.Text = firstPart
    '        uc.PanelFirstPart.BackColor = Color.GreenYellow
    '    End If
    '    If secondPart <> "" Then
    '        uc.LabelSecondPart.Text = secondPart
    '        uc.PanelSecondPart.BackColor = Color.Coral
    '    End If
    '    AddHandler uc.DeleteControl, AddressOf RemoveCtrl
    '    AddCtrl(uc)
    'End Sub

    Public Sub AddSupply(ByVal agvName As String, ByVal firstPart As String)
        Dim uc As ucAgvSupply = New ucAgvSupply()
        uc.Name = agvName
        uc.LabelAgv.Text = agvName
        uc.Dock = DockStyle.Top

        If firstPart <> "" Then
            uc.LabelSecondPart.Text = firstPart
            uc.PanelSecondPart.BackColor = Color.GreenYellow
        End If

        AddHandler uc.DeleteControl, AddressOf RemoveCtrl
        AddCtrl(uc)
    End Sub

    Private Sub AddCtrl(ByVal item As Control)
        If InvokeRequired Then
            Dim d As New AddControlDelegate(AddressOf AddCtrl)
            Me.Invoke(d, New Object() {item})
        Else
            Me.Controls.Add(item)
        End If
    End Sub

    Private Sub RemoveCtrl(ByVal item As String)
        If InvokeRequired Then
            Dim d As New RemoveControlDelegate(AddressOf RemoveCtrl)
            Me.Invoke(d, New Object() {item})
        Else
            Me.Controls.RemoveByKey(item)
        End If
    End Sub

    Public Sub RemoveSupply(ByVal name)
        RemoveCtrl(name)
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        AddSupply("AGV 00", "TM15-03(24)_No:12_Re:24")
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim agvName As String = InputBox("Input AGV name")
        RemoveSupply(agvName)
    End Sub

    Private Sub AutoSizeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutoSizeToolStripMenuItem.Click
        Static isAllowExpand As Boolean = False
        If isAllowExpand = False Then
            Me.AutoSize = True
            isAllowExpand = True
            AutoSizeToolStripMenuItem.Text="Fix size"
        Else
            Me.AutoSize = False
            isAllowExpand = False
            AutoSizeToolStripMenuItem.Text="Auto size"
        End If
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class