<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MapAGV
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
		Me.LabelName = New System.Windows.Forms.Label()
		Me.TimerDialog = New System.Windows.Forms.Timer(Me.components)
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.LabelStt = New System.Windows.Forms.Label()
		Me.LabelPartSupply = New System.Windows.Forms.Label()
		Me.TimerAlarm = New System.Windows.Forms.Timer(Me.components)
		Me.SuspendLayout()
		'
		'LabelName
		'
		Me.LabelName.AutoSize = True
		Me.LabelName.Location = New System.Drawing.Point(3, 3)
		Me.LabelName.Name = "LabelName"
		Me.LabelName.Size = New System.Drawing.Size(29, 13)
		Me.LabelName.TabIndex = 4
		Me.LabelName.Text = "AGV"
		'
		'TimerDialog
		'
		Me.TimerDialog.Interval = 5000
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(3, 20)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(40, 13)
		Me.Label1.TabIndex = 5
		Me.Label1.Text = "Status:"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(3, 37)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(32, 13)
		Me.Label2.TabIndex = 6
		Me.Label2.Text = "Part: "
		'
		'LabelStt
		'
		Me.LabelStt.AutoSize = True
		Me.LabelStt.Location = New System.Drawing.Point(50, 20)
		Me.LabelStt.Name = "LabelStt"
		Me.LabelStt.Size = New System.Drawing.Size(20, 13)
		Me.LabelStt.TabIndex = 7
		Me.LabelStt.Text = "Stt"
		'
		'LabelPartSupply
		'
		Me.LabelPartSupply.AutoSize = True
		Me.LabelPartSupply.Location = New System.Drawing.Point(50, 37)
		Me.LabelPartSupply.Name = "LabelPartSupply"
		Me.LabelPartSupply.Size = New System.Drawing.Size(39, 13)
		Me.LabelPartSupply.TabIndex = 8
		Me.LabelPartSupply.Text = "Supply"
		'
		'TimerAlarm
		'
		Me.TimerAlarm.Interval = 200
		'
		'MapAGV
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Controls.Add(Me.LabelPartSupply)
		Me.Controls.Add(Me.LabelStt)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.LabelName)
		Me.Name = "MapAGV"
		Me.Size = New System.Drawing.Size(152, 55)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents LabelName As System.Windows.Forms.Label
	Friend WithEvents TimerDialog As System.Windows.Forms.Timer
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents LabelStt As System.Windows.Forms.Label
	Friend WithEvents LabelPartSupply As System.Windows.Forms.Label
	Friend WithEvents TimerAlarm As System.Windows.Forms.Timer

End Class
