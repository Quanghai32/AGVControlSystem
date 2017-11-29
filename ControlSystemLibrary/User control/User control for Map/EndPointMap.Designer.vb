<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EndPointMap
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
        Me.LabName = New System.Windows.Forms.Label()
        Me.TxtStatus = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'LabName
        '
        Me.LabName.AutoSize = True
        Me.LabName.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabName.Location = New System.Drawing.Point(31, 0)
        Me.LabName.Name = "LabName"
        Me.LabName.Size = New System.Drawing.Size(56, 19)
        Me.LabName.TabIndex = 0
        Me.LabName.Text = "Label1"
        '
        'TxtStatus
        '
        Me.TxtStatus.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStatus.Location = New System.Drawing.Point(12, 22)
        Me.TxtStatus.Name = "TxtStatus"
        Me.TxtStatus.Size = New System.Drawing.Size(100, 26)
        Me.TxtStatus.TabIndex = 1
        '
        'EndPointMap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TxtStatus)
        Me.Controls.Add(Me.LabName)
        Me.Name = "EndPointMap"
        Me.Size = New System.Drawing.Size(124, 59)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabName As System.Windows.Forms.Label
    Friend WithEvents TxtStatus As System.Windows.Forms.TextBox

End Class
