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
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.labelName = New ControlSystemLibrary.CustomText()
        Me.labelAGV = New ControlSystemLibrary.CustomText()
        Me.SuspendLayout
        '
        'Timer1
        '
        '
        'labelName
        '
        Me.labelName.AutoSize = true
        Me.labelName.Location = New System.Drawing.Point(0, 0)
        Me.labelName.Name = "labelName"
        Me.labelName.Size = New System.Drawing.Size(24, 14)
        Me.labelName.TabIndex = 0
        Me.labelName.UserFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.labelName.UserRotate = 0
        Me.labelName.UserText = "Part"
        Me.labelName.UserXOrigin = 0
        Me.labelName.UserYOrigin = 0
        '
        'labelAGV
        '
        Me.labelAGV.AutoSize = true
        Me.labelAGV.Location = New System.Drawing.Point(0, 20)
        Me.labelAGV.Name = "labelAGV"
        Me.labelAGV.Size = New System.Drawing.Size(28, 14)
        Me.labelAGV.TabIndex = 1
        Me.labelAGV.UserFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.labelAGV.UserRotate = 0
        Me.labelAGV.UserText = "AGV"
        Me.labelAGV.UserXOrigin = 0
        Me.labelAGV.UserYOrigin = 0
        '
        'MapPart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DodgerBlue
        Me.Controls.Add(Me.labelName)
        Me.Controls.Add(Me.labelAGV)
        Me.Name = "MapPart"
        Me.Size = New System.Drawing.Size(108, 105)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents labelName As CustomText
    Friend WithEvents labelAGV As CustomText
    Friend WithEvents Timer1 As Forms.Timer
End Class
