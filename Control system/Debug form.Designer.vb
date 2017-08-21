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
		Me.SuspendLayout()
		'
		'RichTextBoxDebug
		'
		Me.RichTextBoxDebug.Dock = System.Windows.Forms.DockStyle.Fill
		Me.RichTextBoxDebug.Location = New System.Drawing.Point(0, 0)
		Me.RichTextBoxDebug.Name = "RichTextBoxDebug"
		Me.RichTextBoxDebug.Size = New System.Drawing.Size(468, 472)
		Me.RichTextBoxDebug.TabIndex = 0
		Me.RichTextBoxDebug.Text = ""
		'
		'CDebug_Form
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(468, 472)
		Me.Controls.Add(Me.RichTextBoxDebug)
		Me.Name = "CDebug_Form"
		Me.Text = "Debug"
		Me.TopMost = True
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents RichTextBoxDebug As System.Windows.Forms.RichTextBox
End Class
