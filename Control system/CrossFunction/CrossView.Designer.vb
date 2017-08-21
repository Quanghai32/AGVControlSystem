<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CrossView
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
		Me.components = New System.ComponentModel.Container()
		Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
		Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
		Me.ResetCrossToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.MenuStrip1.SuspendLayout()
		Me.SuspendLayout()
		'
		'Timer1
		'
		Me.Timer1.Enabled = True
		'
		'MenuStrip1
		'
		Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ResetCrossToolStripMenuItem})
		Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
		Me.MenuStrip1.Name = "MenuStrip1"
		Me.MenuStrip1.Size = New System.Drawing.Size(599, 24)
		Me.MenuStrip1.TabIndex = 0
		Me.MenuStrip1.Text = "MenuStrip1"
		'
		'ResetCrossToolStripMenuItem
		'
		Me.ResetCrossToolStripMenuItem.Name = "ResetCrossToolStripMenuItem"
		Me.ResetCrossToolStripMenuItem.Size = New System.Drawing.Size(77, 20)
		Me.ResetCrossToolStripMenuItem.Text = "Reset cross"
		'
		'CrossView
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(599, 302)
		Me.Controls.Add(Me.MenuStrip1)
		Me.MainMenuStrip = Me.MenuStrip1
		Me.Name = "CrossView"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "CrossView"
		Me.TopMost = True
		Me.MenuStrip1.ResumeLayout(False)
		Me.MenuStrip1.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
	Friend WithEvents ResetCrossToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
