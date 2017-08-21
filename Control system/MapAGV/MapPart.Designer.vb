<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MapPart
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
		Me.components = New System.ComponentModel.Container()
		Me.labelName = New System.Windows.Forms.Label()
		Me.LabelAGV = New System.Windows.Forms.Label()
		Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
		Me.SuspendLayout()
		'
		'labelName
		'
		Me.labelName.AutoSize = True
		Me.labelName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.labelName.Location = New System.Drawing.Point(3, 4)
		Me.labelName.Name = "labelName"
		Me.labelName.Size = New System.Drawing.Size(32, 16)
		Me.labelName.TabIndex = 0
		Me.labelName.Text = "Part"
		'
		'LabelAGV
		'
		Me.LabelAGV.AutoSize = True
		Me.LabelAGV.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LabelAGV.Location = New System.Drawing.Point(3, 23)
		Me.LabelAGV.Name = "LabelAGV"
		Me.LabelAGV.Size = New System.Drawing.Size(36, 16)
		Me.LabelAGV.TabIndex = 1
		Me.LabelAGV.Text = "AGV"
		'
		'Timer1
		'
		'
		'MapPart
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Highlight
		Me.Controls.Add(Me.LabelAGV)
		Me.Controls.Add(Me.labelName)
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.Name = "MapPart"
		Me.Size = New System.Drawing.Size(80, 45)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents labelName As System.Windows.Forms.Label
	Friend WithEvents LabelAGV As System.Windows.Forms.Label
	Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
