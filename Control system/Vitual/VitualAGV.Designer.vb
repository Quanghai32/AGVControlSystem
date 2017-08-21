<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VitualAGV
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
		Me.TimerVitual = New System.Windows.Forms.Timer(Me.components)
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.ComboBoxStt = New System.Windows.Forms.ComboBox()
		Me.NumericRoute = New System.Windows.Forms.NumericUpDown()
		Me.NumericPosition = New System.Windows.Forms.NumericUpDown()
		Me.NumericTime = New System.Windows.Forms.NumericUpDown()
		Me.ButtonSend = New System.Windows.Forms.Button()
		Me.ButtonLoop = New System.Windows.Forms.Button()
		Me.CheckBoxEMG = New System.Windows.Forms.CheckBox()
		Me.ButtonRun = New System.Windows.Forms.Button()
		Me.CheckBoxRealAGV = New System.Windows.Forms.CheckBox()
		CType(Me.NumericRoute, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.NumericPosition, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.NumericTime, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'TimerVitual
		'
		Me.TimerVitual.Interval = 1000
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(6, 12)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(20, 13)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "Stt"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(6, 35)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(36, 13)
		Me.Label2.TabIndex = 1
		Me.Label2.Text = "Route"
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(6, 61)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(44, 13)
		Me.Label3.TabIndex = 2
		Me.Label3.Text = "Position"
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(6, 87)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(69, 13)
		Me.Label4.TabIndex = 3
		Me.Label4.Text = "Running time"
		'
		'ComboBoxStt
		'
		Me.ComboBoxStt.FormattingEnabled = True
		Me.ComboBoxStt.Location = New System.Drawing.Point(66, 4)
		Me.ComboBoxStt.Name = "ComboBoxStt"
		Me.ComboBoxStt.Size = New System.Drawing.Size(179, 21)
		Me.ComboBoxStt.TabIndex = 4
		'
		'NumericRoute
		'
		Me.NumericRoute.Location = New System.Drawing.Point(125, 28)
		Me.NumericRoute.Name = "NumericRoute"
		Me.NumericRoute.Size = New System.Drawing.Size(120, 20)
		Me.NumericRoute.TabIndex = 5
		'
		'NumericPosition
		'
		Me.NumericPosition.Location = New System.Drawing.Point(125, 54)
		Me.NumericPosition.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
		Me.NumericPosition.Name = "NumericPosition"
		Me.NumericPosition.Size = New System.Drawing.Size(120, 20)
		Me.NumericPosition.TabIndex = 6
		'
		'NumericTime
		'
		Me.NumericTime.Location = New System.Drawing.Point(125, 80)
		Me.NumericTime.Name = "NumericTime"
		Me.NumericTime.Size = New System.Drawing.Size(120, 20)
		Me.NumericTime.TabIndex = 7
		'
		'ButtonSend
		'
		Me.ButtonSend.Location = New System.Drawing.Point(170, 132)
		Me.ButtonSend.Name = "ButtonSend"
		Me.ButtonSend.Size = New System.Drawing.Size(75, 23)
		Me.ButtonSend.TabIndex = 8
		Me.ButtonSend.Text = "Send"
		Me.ButtonSend.UseVisualStyleBackColor = True
		'
		'ButtonLoop
		'
		Me.ButtonLoop.Location = New System.Drawing.Point(9, 132)
		Me.ButtonLoop.Name = "ButtonLoop"
		Me.ButtonLoop.Size = New System.Drawing.Size(75, 23)
		Me.ButtonLoop.TabIndex = 9
		Me.ButtonLoop.Text = "Loop"
		Me.ButtonLoop.UseVisualStyleBackColor = True
		'
		'CheckBoxEMG
		'
		Me.CheckBoxEMG.AutoSize = True
		Me.CheckBoxEMG.Location = New System.Drawing.Point(9, 109)
		Me.CheckBoxEMG.Name = "CheckBoxEMG"
		Me.CheckBoxEMG.Size = New System.Drawing.Size(79, 17)
		Me.CheckBoxEMG.TabIndex = 10
		Me.CheckBoxEMG.Text = "Emergency"
		Me.CheckBoxEMG.UseVisualStyleBackColor = True
		'
		'ButtonRun
		'
		Me.ButtonRun.Location = New System.Drawing.Point(170, 103)
		Me.ButtonRun.Name = "ButtonRun"
		Me.ButtonRun.Size = New System.Drawing.Size(75, 23)
		Me.ButtonRun.TabIndex = 11
		Me.ButtonRun.Text = "Run"
		Me.ButtonRun.UseVisualStyleBackColor = True
		'
		'CheckBoxRealAGV
		'
		Me.CheckBoxRealAGV.AutoSize = True
		Me.CheckBoxRealAGV.Checked = True
		Me.CheckBoxRealAGV.CheckState = System.Windows.Forms.CheckState.Checked
		Me.CheckBoxRealAGV.Location = New System.Drawing.Point(94, 109)
		Me.CheckBoxRealAGV.Name = "CheckBoxRealAGV"
		Me.CheckBoxRealAGV.Size = New System.Drawing.Size(70, 17)
		Me.CheckBoxRealAGV.TabIndex = 12
		Me.CheckBoxRealAGV.Text = "RealAGV"
		Me.CheckBoxRealAGV.UseVisualStyleBackColor = True
		'
		'VitualAGV
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(254, 158)
		Me.Controls.Add(Me.CheckBoxRealAGV)
		Me.Controls.Add(Me.ButtonRun)
		Me.Controls.Add(Me.CheckBoxEMG)
		Me.Controls.Add(Me.ButtonLoop)
		Me.Controls.Add(Me.ButtonSend)
		Me.Controls.Add(Me.NumericTime)
		Me.Controls.Add(Me.NumericPosition)
		Me.Controls.Add(Me.NumericRoute)
		Me.Controls.Add(Me.ComboBoxStt)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.Label1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Name = "VitualAGV"
		Me.Text = "VitualForm"
		Me.TopMost = True
		CType(Me.NumericRoute, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.NumericPosition, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.NumericTime, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents TimerVitual As System.Windows.Forms.Timer
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents ComboBoxStt As System.Windows.Forms.ComboBox
	Friend WithEvents NumericRoute As System.Windows.Forms.NumericUpDown
	Friend WithEvents NumericPosition As System.Windows.Forms.NumericUpDown
	Friend WithEvents NumericTime As System.Windows.Forms.NumericUpDown
	Friend WithEvents ButtonSend As System.Windows.Forms.Button
	Friend WithEvents ButtonLoop As System.Windows.Forms.Button
	Friend WithEvents CheckBoxEMG As System.Windows.Forms.CheckBox
	Friend WithEvents ButtonRun As System.Windows.Forms.Button
	Friend WithEvents CheckBoxRealAGV As System.Windows.Forms.CheckBox
End Class
