<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PartDisplayControl
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtConnectStatus = New System.Windows.Forms.TextBox()
        Me.txtPartStatus = New System.Windows.Forms.TextBox()
        Me.txtAGVSupply = New System.Windows.Forms.TextBox()
        Me.chkEnable = New System.Windows.Forms.CheckBox()
        Me.grpName = New System.Windows.Forms.GroupBox()
        Me.grpPart = New System.Windows.Forms.GroupBox()
        Me.grpName.SuspendLayout()
        Me.grpPart.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Connect status:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Part status:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "AGV supply:"
        '
        'txtConnectStatus
        '
        Me.txtConnectStatus.Font = New System.Drawing.Font("Cambria", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConnectStatus.Location = New System.Drawing.Point(94, 13)
        Me.txtConnectStatus.Name = "txtConnectStatus"
        Me.txtConnectStatus.Size = New System.Drawing.Size(100, 20)
        Me.txtConnectStatus.TabIndex = 1
        Me.txtConnectStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPartStatus
        '
        Me.txtPartStatus.Font = New System.Drawing.Font("Cambria", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPartStatus.Location = New System.Drawing.Point(94, 39)
        Me.txtPartStatus.Name = "txtPartStatus"
        Me.txtPartStatus.Size = New System.Drawing.Size(100, 20)
        Me.txtPartStatus.TabIndex = 1
        Me.txtPartStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtAGVSupply
        '
        Me.txtAGVSupply.Font = New System.Drawing.Font("Cambria", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAGVSupply.Location = New System.Drawing.Point(94, 65)
        Me.txtAGVSupply.Name = "txtAGVSupply"
        Me.txtAGVSupply.Size = New System.Drawing.Size(100, 20)
        Me.txtAGVSupply.TabIndex = 1
        Me.txtAGVSupply.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chkEnable
        '
        Me.chkEnable.AutoSize = True
        Me.chkEnable.Location = New System.Drawing.Point(6, 15)
        Me.chkEnable.Name = "chkEnable"
        Me.chkEnable.Size = New System.Drawing.Size(59, 17)
        Me.chkEnable.TabIndex = 2
        Me.chkEnable.Text = "Enable"
        Me.chkEnable.UseVisualStyleBackColor = True
        '
        'grpName
        '
        Me.grpName.Controls.Add(Me.chkEnable)
        Me.grpName.Controls.Add(Me.grpPart)
        Me.grpName.Location = New System.Drawing.Point(3, 3)
        Me.grpName.Name = "grpName"
        Me.grpName.Size = New System.Drawing.Size(212, 128)
        Me.grpName.TabIndex = 0
        Me.grpName.TabStop = False
        Me.grpName.Text = "Part 1"
        '
        'grpPart
        '
        Me.grpPart.Controls.Add(Me.txtAGVSupply)
        Me.grpPart.Controls.Add(Me.txtPartStatus)
        Me.grpPart.Controls.Add(Me.Label1)
        Me.grpPart.Controls.Add(Me.txtConnectStatus)
        Me.grpPart.Controls.Add(Me.Label2)
        Me.grpPart.Controls.Add(Me.Label3)
        Me.grpPart.Location = New System.Drawing.Point(6, 29)
        Me.grpPart.Name = "grpPart"
        Me.grpPart.Size = New System.Drawing.Size(200, 92)
        Me.grpPart.TabIndex = 3
        Me.grpPart.TabStop = False
        '
        'PartDisplayControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.grpName)
        Me.Name = "PartDisplayControl"
        Me.Size = New System.Drawing.Size(221, 137)
        Me.grpName.ResumeLayout(False)
        Me.grpName.PerformLayout()
        Me.grpPart.ResumeLayout(False)
        Me.grpPart.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtConnectStatus As System.Windows.Forms.TextBox
    Friend WithEvents txtPartStatus As System.Windows.Forms.TextBox
    Friend WithEvents txtAGVSupply As System.Windows.Forms.TextBox
    Friend WithEvents chkEnable As System.Windows.Forms.CheckBox
    Friend WithEvents grpName As System.Windows.Forms.GroupBox
    Friend WithEvents grpPart As System.Windows.Forms.GroupBox

End Class
