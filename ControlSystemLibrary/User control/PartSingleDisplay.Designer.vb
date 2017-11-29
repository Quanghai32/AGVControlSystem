<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PartSingleDisplay
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
		Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
		Me.labelName = New System.Windows.Forms.Label()
		Me.labelAGV = New System.Windows.Forms.Label()
		Me.TableLayoutPanel1.SuspendLayout()
		Me.SuspendLayout()
		'
		'TableLayoutPanel1
		'
		Me.TableLayoutPanel1.ColumnCount = 1
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
		Me.TableLayoutPanel1.Controls.Add(Me.labelName, 0, 0)
		Me.TableLayoutPanel1.Controls.Add(Me.labelAGV, 0, 1)
		Me.TableLayoutPanel1.Location = New System.Drawing.Point(4, 4)
		Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
		Me.TableLayoutPanel1.RowCount = 2
		Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
		Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
		Me.TableLayoutPanel1.Size = New System.Drawing.Size(124, 65)
		Me.TableLayoutPanel1.TabIndex = 0
		'
		'labelName
		'
		Me.labelName.BackColor = System.Drawing.SystemColors.Control
		Me.labelName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.labelName.Location = New System.Drawing.Point(3, 0)
		Me.labelName.Name = "labelName"
		Me.labelName.Size = New System.Drawing.Size(118, 32)
		Me.labelName.TabIndex = 0
		Me.labelName.Text = "Bottom"
		Me.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'labelAGV
		'
		Me.labelAGV.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.labelAGV.Location = New System.Drawing.Point(3, 32)
		Me.labelAGV.Name = "labelAGV"
		Me.labelAGV.Size = New System.Drawing.Size(118, 33)
		Me.labelAGV.TabIndex = 0
		Me.labelAGV.Text = "AGV 10"
		Me.labelAGV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'PartSingleDisplay
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Controls.Add(Me.TableLayoutPanel1)
		Me.Name = "PartSingleDisplay"
		Me.Size = New System.Drawing.Size(132, 79)
		Me.TableLayoutPanel1.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
	Friend WithEvents labelName As System.Windows.Forms.Label
	Friend WithEvents labelAGV As System.Windows.Forms.Label

End Class
