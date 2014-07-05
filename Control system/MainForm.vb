Imports ControlSystemLibrary
Public Class MainForm
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReadStartData()
        'Dim avaiableWidth As Integer = Panel1.Width - 30
        'Dim eachWidth As Integer = avaiableWidth / LineGroupArray(0).MaxPart
        'If eachWidth < 100 Then
        '    eachWidth = 100
        'End If
        'For row As Byte = 0 To LineGroupArray.Length - 1
        '    Dim txt As verticalText = New verticalText()
        '    txt.UserText = LineGroupArray(row).Name
        '    txt.Width = 20
        '    txt.Height = 100
        '    txt.Top = 100 * row
        '    txt.Left = 0
        '    txt.Parent = Panel1
        '    For column As Byte = 0 To LineGroupArray(0).MaxPart - 1
        '        Dim part As PartSingleDisplay = New PartSingleDisplay()
        '        part.Width = eachWidth
        '        part.Height = 100
        '        part.Parent = Panel1
        '        part.Top = 100 * row
        '        part.Left = eachWidth * column + 25
        '        part.setDataBinding(PartArray(column))
        '    Next
        'Next
        ComboBox1.SelectedIndex = 0
    End Sub

    Private Sub MainForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        TabControl1.Dock = DockStyle.Fill
        TableLayoutPanel1.Dock = DockStyle.Fill
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ListView1.View = ComboBox1.SelectedIndex
    End Sub
End Class
