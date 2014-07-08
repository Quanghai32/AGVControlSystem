<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VirtualAGV
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cmbAGV = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkEnable = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbPosition = New System.Windows.Forms.ComboBox()
        Me.cmbAGVStatus = New System.Windows.Forms.ComboBox()
        Me.cmbWorkingStatus = New System.Windows.Forms.ComboBox()
        Me.cmbPartSupply = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'cmbAGV
        '
        Me.cmbAGV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAGV.FormattingEnabled = True
        Me.cmbAGV.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20"})
        Me.cmbAGV.Location = New System.Drawing.Point(134, 8)
        Me.cmbAGV.Name = "cmbAGV"
        Me.cmbAGV.Size = New System.Drawing.Size(121, 21)
        Me.cmbAGV.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "AGV"
        '
        'chkEnable
        '
        Me.chkEnable.AutoSize = True
        Me.chkEnable.Location = New System.Drawing.Point(134, 42)
        Me.chkEnable.Name = "chkEnable"
        Me.chkEnable.Size = New System.Drawing.Size(59, 17)
        Me.chkEnable.TabIndex = 3
        Me.chkEnable.Text = "Enable"
        Me.chkEnable.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 111)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "AGV status"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Position"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 144)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "AGV working status"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 177)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Part supply"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 45)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Enable"
        '
        'cmbPosition
        '
        Me.cmbPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPosition.FormattingEnabled = True
        Me.cmbPosition.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40"})
        Me.cmbPosition.Location = New System.Drawing.Point(134, 72)
        Me.cmbPosition.Name = "cmbPosition"
        Me.cmbPosition.Size = New System.Drawing.Size(121, 21)
        Me.cmbPosition.TabIndex = 5
        '
        'cmbAGVStatus
        '
        Me.cmbAGVStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAGVStatus.FormattingEnabled = True
        Me.cmbAGVStatus.Items.AddRange(New Object() {"Unknow", "Emergency", "Safety", "Stop", "Out line", "Battery empty", "No cart", "Normal"})
        Me.cmbAGVStatus.Location = New System.Drawing.Point(134, 106)
        Me.cmbAGVStatus.Name = "cmbAGVStatus"
        Me.cmbAGVStatus.Size = New System.Drawing.Size(121, 21)
        Me.cmbAGVStatus.TabIndex = 7
        '
        'cmbWorkingStatus
        '
        Me.cmbWorkingStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbWorkingStatus.FormattingEnabled = True
        Me.cmbWorkingStatus.Items.AddRange(New Object() {"Free", "Supplying", "Returning"})
        Me.cmbWorkingStatus.Location = New System.Drawing.Point(134, 140)
        Me.cmbWorkingStatus.Name = "cmbWorkingStatus"
        Me.cmbWorkingStatus.Size = New System.Drawing.Size(121, 21)
        Me.cmbWorkingStatus.TabIndex = 9
        '
        'cmbPartSupply
        '
        Me.cmbPartSupply.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPartSupply.FormattingEnabled = True
        Me.cmbPartSupply.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.cmbPartSupply.Location = New System.Drawing.Point(134, 174)
        Me.cmbPartSupply.Name = "cmbPartSupply"
        Me.cmbPartSupply.Size = New System.Drawing.Size(121, 21)
        Me.cmbPartSupply.TabIndex = 11
        '
        'VirtualAGV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.chkEnable)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbPartSupply)
        Me.Controls.Add(Me.cmbWorkingStatus)
        Me.Controls.Add(Me.cmbAGVStatus)
        Me.Controls.Add(Me.cmbPosition)
        Me.Controls.Add(Me.cmbAGV)
        Me.Name = "VirtualAGV"
        Me.Size = New System.Drawing.Size(269, 204)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbAGV As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkEnable As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbPosition As System.Windows.Forms.ComboBox
    Friend WithEvents cmbAGVStatus As System.Windows.Forms.ComboBox
    Friend WithEvents cmbWorkingStatus As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPartSupply As System.Windows.Forms.ComboBox

End Class
