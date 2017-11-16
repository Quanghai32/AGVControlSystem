<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CDebug_Form
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
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
        Me.RichTextBoxDebug = New System.Windows.Forms.RichTextBox()
        Me.ButtonRun = New System.Windows.Forms.Button()
        Me.CheckedListBoxDebug = New System.Windows.Forms.CheckedListBox()
        Me.CheckedListBoxRecord = New System.Windows.Forms.CheckedListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ButtonClear = New System.Windows.Forms.Button()
        Me.SuspendLayout
        '
        'RichTextBoxDebug
        '
        Me.RichTextBoxDebug.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.RichTextBoxDebug.Location = New System.Drawing.Point(0, 111)
        Me.RichTextBoxDebug.Name = "RichTextBoxDebug"
        Me.RichTextBoxDebug.Size = New System.Drawing.Size(468, 361)
        Me.RichTextBoxDebug.TabIndex = 0
        Me.RichTextBoxDebug.Text = ""
        '
        'ButtonRun
        '
        Me.ButtonRun.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.ButtonRun.BackColor = System.Drawing.Color.Lime
        Me.ButtonRun.Location = New System.Drawing.Point(381, 12)
        Me.ButtonRun.Name = "ButtonRun"
        Me.ButtonRun.Size = New System.Drawing.Size(75, 33)
        Me.ButtonRun.TabIndex = 1
        Me.ButtonRun.Text = "Stop"
        Me.ButtonRun.UseVisualStyleBackColor = false
        '
        'CheckedListBoxDebug
        '
        Me.CheckedListBoxDebug.BackColor = System.Drawing.SystemColors.Control
        Me.CheckedListBoxDebug.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.CheckedListBoxDebug.FormattingEnabled = true
        Me.CheckedListBoxDebug.Location = New System.Drawing.Point(22, 34)
        Me.CheckedListBoxDebug.Name = "CheckedListBoxDebug"
        Me.CheckedListBoxDebug.Size = New System.Drawing.Size(158, 45)
        Me.CheckedListBoxDebug.TabIndex = 4
        '
        'CheckedListBoxRecord
        '
        Me.CheckedListBoxRecord.BackColor = System.Drawing.SystemColors.Control
        Me.CheckedListBoxRecord.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.CheckedListBoxRecord.FormattingEnabled = true
        Me.CheckedListBoxRecord.Location = New System.Drawing.Point(186, 34)
        Me.CheckedListBoxRecord.Name = "CheckedListBoxRecord"
        Me.CheckedListBoxRecord.Size = New System.Drawing.Size(156, 45)
        Me.CheckedListBoxRecord.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(19, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Show"
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Location = New System.Drawing.Point(183, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Record"
        '
        'ButtonClear
        '
        Me.ButtonClear.Location = New System.Drawing.Point(381, 56)
        Me.ButtonClear.Name = "ButtonClear"
        Me.ButtonClear.Size = New System.Drawing.Size(75, 23)
        Me.ButtonClear.TabIndex = 8
        Me.ButtonClear.Text = "Clear"
        Me.ButtonClear.UseVisualStyleBackColor = true
        '
        'CDebug_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(468, 472)
        Me.Controls.Add(Me.ButtonClear)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CheckedListBoxRecord)
        Me.Controls.Add(Me.CheckedListBoxDebug)
        Me.Controls.Add(Me.ButtonRun)
        Me.Controls.Add(Me.RichTextBoxDebug)
        Me.Name = "CDebug_Form"
        Me.Text = "Debug"
        Me.TopMost = true
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
	Friend WithEvents RichTextBoxDebug As System.Windows.Forms.RichTextBox
    Friend WithEvents ButtonRun As Button
    Friend WithEvents CheckedListBoxDebug As CheckedListBox
    Friend WithEvents CheckedListBoxRecord As CheckedListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ButtonClear As Button
End Class
