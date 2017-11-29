<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AGVDisplay
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
		Me.grpName = New System.Windows.Forms.GroupBox()
		Me.grpAGVdisplay = New System.Windows.Forms.GroupBox()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.BatteryDisplay4 = New ControlSystemLibrary.BatteryDisplay()
		Me.BatteryDisplay1 = New ControlSystemLibrary.BatteryDisplay()
		Me.BatteryDisplay2 = New ControlSystemLibrary.BatteryDisplay()
		Me.BatteryDisplay3 = New ControlSystemLibrary.BatteryDisplay()
		Me.inpConnectingStatus = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.inpRunningStatus = New System.Windows.Forms.TextBox()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.inpPosition = New System.Windows.Forms.TextBox()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.inpWorkingStatus = New System.Windows.Forms.TextBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.inpPart = New System.Windows.Forms.TextBox()
		Me.chkEnable = New System.Windows.Forms.CheckBox()
		Me.grpName.SuspendLayout()
		Me.grpAGVdisplay.SuspendLayout()
		Me.GroupBox2.SuspendLayout()
		Me.SuspendLayout()
		'
		'grpName
		'
		Me.grpName.Controls.Add(Me.grpAGVdisplay)
		Me.grpName.Controls.Add(Me.chkEnable)
		Me.grpName.Font = New System.Drawing.Font("Cambria", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.grpName.Location = New System.Drawing.Point(4, 4)
		Me.grpName.Name = "grpName"
		Me.grpName.Size = New System.Drawing.Size(238, 333)
		Me.grpName.TabIndex = 1
		Me.grpName.TabStop = False
		Me.grpName.Text = "AGV"
		'
		'grpAGVdisplay
		'
		Me.grpAGVdisplay.Controls.Add(Me.GroupBox2)
		Me.grpAGVdisplay.Controls.Add(Me.inpConnectingStatus)
		Me.grpAGVdisplay.Controls.Add(Me.Label1)
		Me.grpAGVdisplay.Controls.Add(Me.Label2)
		Me.grpAGVdisplay.Controls.Add(Me.inpRunningStatus)
		Me.grpAGVdisplay.Controls.Add(Me.Label4)
		Me.grpAGVdisplay.Controls.Add(Me.inpPosition)
		Me.grpAGVdisplay.Controls.Add(Me.Label5)
		Me.grpAGVdisplay.Controls.Add(Me.inpWorkingStatus)
		Me.grpAGVdisplay.Controls.Add(Me.Label3)
		Me.grpAGVdisplay.Controls.Add(Me.inpPart)
		Me.grpAGVdisplay.Location = New System.Drawing.Point(6, 37)
		Me.grpAGVdisplay.Name = "grpAGVdisplay"
		Me.grpAGVdisplay.Size = New System.Drawing.Size(226, 291)
		Me.grpAGVdisplay.TabIndex = 2
		Me.grpAGVdisplay.TabStop = False
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.BatteryDisplay4)
		Me.GroupBox2.Controls.Add(Me.BatteryDisplay1)
		Me.GroupBox2.Controls.Add(Me.BatteryDisplay2)
		Me.GroupBox2.Controls.Add(Me.BatteryDisplay3)
		Me.GroupBox2.Font = New System.Drawing.Font("Cambria", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.GroupBox2.Location = New System.Drawing.Point(6, 10)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(199, 150)
		Me.GroupBox2.TabIndex = 0
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "Battery"
		'
		'BatteryDisplay4
		'
		Me.BatteryDisplay4.EMPTY_VOLTAGE = CType(110, Byte)
		Me.BatteryDisplay4.EmptyColor = System.Drawing.Color.Red
		Me.BatteryDisplay4.EmptyValue = CType(20, Byte)
		Me.BatteryDisplay4.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.BatteryDisplay4.FULL_VOLTAGE = CType(130, Byte)
		Me.BatteryDisplay4.FullColor = System.Drawing.Color.Green
		Me.BatteryDisplay4.FullValue = CType(50, Byte)
		Me.BatteryDisplay4.Location = New System.Drawing.Point(155, 16)
		Me.BatteryDisplay4.Name = "BatteryDisplay4"
		Me.BatteryDisplay4.NormalColor = System.Drawing.Color.Yellow
		Me.BatteryDisplay4.Size = New System.Drawing.Size(40, 128)
		Me.BatteryDisplay4.TabIndex = 0
		'
		'BatteryDisplay1
		'
		Me.BatteryDisplay1.EMPTY_VOLTAGE = CType(110, Byte)
		Me.BatteryDisplay1.EmptyColor = System.Drawing.Color.Red
		Me.BatteryDisplay1.EmptyValue = CType(20, Byte)
		Me.BatteryDisplay1.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.BatteryDisplay1.FULL_VOLTAGE = CType(130, Byte)
		Me.BatteryDisplay1.FullColor = System.Drawing.Color.Green
		Me.BatteryDisplay1.FullValue = CType(50, Byte)
		Me.BatteryDisplay1.Location = New System.Drawing.Point(5, 16)
		Me.BatteryDisplay1.Name = "BatteryDisplay1"
		Me.BatteryDisplay1.NormalColor = System.Drawing.Color.Yellow
		Me.BatteryDisplay1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.BatteryDisplay1.Size = New System.Drawing.Size(40, 128)
		Me.BatteryDisplay1.TabIndex = 0
		'
		'BatteryDisplay2
		'
		Me.BatteryDisplay2.EMPTY_VOLTAGE = CType(110, Byte)
		Me.BatteryDisplay2.EmptyColor = System.Drawing.Color.Red
		Me.BatteryDisplay2.EmptyValue = CType(20, Byte)
		Me.BatteryDisplay2.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.BatteryDisplay2.FULL_VOLTAGE = CType(130, Byte)
		Me.BatteryDisplay2.FullColor = System.Drawing.Color.Green
		Me.BatteryDisplay2.FullValue = CType(50, Byte)
		Me.BatteryDisplay2.Location = New System.Drawing.Point(55, 16)
		Me.BatteryDisplay2.Name = "BatteryDisplay2"
		Me.BatteryDisplay2.NormalColor = System.Drawing.Color.Yellow
		Me.BatteryDisplay2.Size = New System.Drawing.Size(40, 128)
		Me.BatteryDisplay2.TabIndex = 0
		'
		'BatteryDisplay3
		'
		Me.BatteryDisplay3.EMPTY_VOLTAGE = CType(110, Byte)
		Me.BatteryDisplay3.EmptyColor = System.Drawing.Color.Red
		Me.BatteryDisplay3.EmptyValue = CType(20, Byte)
		Me.BatteryDisplay3.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.BatteryDisplay3.FULL_VOLTAGE = CType(130, Byte)
		Me.BatteryDisplay3.FullColor = System.Drawing.Color.Green
		Me.BatteryDisplay3.FullValue = CType(50, Byte)
		Me.BatteryDisplay3.Location = New System.Drawing.Point(105, 16)
		Me.BatteryDisplay3.Name = "BatteryDisplay3"
		Me.BatteryDisplay3.NormalColor = System.Drawing.Color.Yellow
		Me.BatteryDisplay3.Size = New System.Drawing.Size(40, 128)
		Me.BatteryDisplay3.TabIndex = 0
		'
		'inpConnectingStatus
		'
		Me.inpConnectingStatus.Font = New System.Drawing.Font("Cambria", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.inpConnectingStatus.Location = New System.Drawing.Point(120, 262)
		Me.inpConnectingStatus.Name = "inpConnectingStatus"
		Me.inpConnectingStatus.ReadOnly = True
		Me.inpConnectingStatus.Size = New System.Drawing.Size(100, 23)
		Me.inpConnectingStatus.TabIndex = 2
		Me.inpConnectingStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Font = New System.Drawing.Font("Cambria", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.Location = New System.Drawing.Point(3, 170)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(38, 16)
		Me.Label1.TabIndex = 1
		Me.Label1.Text = "Part:"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Font = New System.Drawing.Font("Cambria", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.Location = New System.Drawing.Point(3, 196)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(104, 16)
		Me.Label2.TabIndex = 1
		Me.Label2.Text = "Working Status:"
		'
		'inpRunningStatus
		'
		Me.inpRunningStatus.Font = New System.Drawing.Font("Cambria", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.inpRunningStatus.Location = New System.Drawing.Point(120, 238)
		Me.inpRunningStatus.Name = "inpRunningStatus"
		Me.inpRunningStatus.ReadOnly = True
		Me.inpRunningStatus.Size = New System.Drawing.Size(100, 23)
		Me.inpRunningStatus.TabIndex = 2
		Me.inpRunningStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Font = New System.Drawing.Font("Cambria", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label4.Location = New System.Drawing.Point(3, 245)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(105, 16)
		Me.Label4.TabIndex = 1
		Me.Label4.Text = "Running Status:"
		'
		'inpPosition
		'
		Me.inpPosition.Font = New System.Drawing.Font("Cambria", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.inpPosition.Location = New System.Drawing.Point(120, 214)
		Me.inpPosition.Name = "inpPosition"
		Me.inpPosition.ReadOnly = True
		Me.inpPosition.Size = New System.Drawing.Size(100, 23)
		Me.inpPosition.TabIndex = 2
		Me.inpPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Font = New System.Drawing.Font("Cambria", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label5.Location = New System.Drawing.Point(3, 269)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(121, 16)
		Me.Label5.TabIndex = 1
		Me.Label5.Text = "Connecting Status:"
		'
		'inpWorkingStatus
		'
		Me.inpWorkingStatus.Font = New System.Drawing.Font("Cambria", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.inpWorkingStatus.Location = New System.Drawing.Point(120, 190)
		Me.inpWorkingStatus.Name = "inpWorkingStatus"
		Me.inpWorkingStatus.ReadOnly = True
		Me.inpWorkingStatus.Size = New System.Drawing.Size(100, 23)
		Me.inpWorkingStatus.TabIndex = 2
		Me.inpWorkingStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Font = New System.Drawing.Font("Cambria", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label3.Location = New System.Drawing.Point(3, 222)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(61, 16)
		Me.Label3.TabIndex = 1
		Me.Label3.Text = "Position:"
		'
		'inpPart
		'
		Me.inpPart.Font = New System.Drawing.Font("Cambria", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.inpPart.Location = New System.Drawing.Point(120, 166)
		Me.inpPart.Name = "inpPart"
		Me.inpPart.ReadOnly = True
		Me.inpPart.Size = New System.Drawing.Size(100, 23)
		Me.inpPart.TabIndex = 2
		Me.inpPart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'chkEnable
		'
		Me.chkEnable.AutoSize = True
		Me.chkEnable.Location = New System.Drawing.Point(15, 20)
		Me.chkEnable.Name = "chkEnable"
		Me.chkEnable.Size = New System.Drawing.Size(69, 20)
		Me.chkEnable.TabIndex = 3
		Me.chkEnable.Text = "Enable"
		Me.chkEnable.UseVisualStyleBackColor = True
		'
		'AGVDisplay
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.AutoScroll = True
		Me.Controls.Add(Me.grpName)
		Me.Name = "AGVDisplay"
		Me.Size = New System.Drawing.Size(249, 343)
		Me.grpName.ResumeLayout(False)
		Me.grpName.PerformLayout()
		Me.grpAGVdisplay.ResumeLayout(False)
		Me.grpAGVdisplay.PerformLayout()
		Me.GroupBox2.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub
    Friend WithEvents BatteryDisplay3 As BatteryDisplay
    Friend WithEvents BatteryDisplay4 As BatteryDisplay
    Friend WithEvents BatteryDisplay1 As BatteryDisplay
    Friend WithEvents BatteryDisplay2 As BatteryDisplay
    Friend WithEvents grpName As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents inpPart As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents inpConnectingStatus As System.Windows.Forms.TextBox
    Friend WithEvents inpRunningStatus As System.Windows.Forms.TextBox
    Friend WithEvents inpPosition As System.Windows.Forms.TextBox
    Friend WithEvents inpWorkingStatus As System.Windows.Forms.TextBox
    Friend WithEvents chkEnable As System.Windows.Forms.CheckBox
    Friend WithEvents grpAGVdisplay As System.Windows.Forms.GroupBox

End Class
