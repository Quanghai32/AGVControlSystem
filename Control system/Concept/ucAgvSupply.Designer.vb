<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucAgvSupply
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
        Me.PanelAgv = New System.Windows.Forms.Panel()
        Me.LabelAgv = New System.Windows.Forms.Label()
        Me.PanelSecondPart = New System.Windows.Forms.Panel()
        Me.btnRelease = New System.Windows.Forms.Button()
        Me.LabelSecondPart = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout
        Me.PanelAgv.SuspendLayout
        Me.PanelSecondPart.SuspendLayout
        Me.SuspendLayout
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.PanelAgv, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.PanelSecondPart, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(730, 150)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'PanelAgv
        '
        Me.PanelAgv.Controls.Add(Me.LabelAgv)
        Me.PanelAgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelAgv.Location = New System.Drawing.Point(4, 4)
        Me.PanelAgv.Name = "PanelAgv"
        Me.PanelAgv.Size = New System.Drawing.Size(175, 142)
        Me.PanelAgv.TabIndex = 0
        '
        'LabelAgv
        '
        Me.LabelAgv.AutoSize = True
        Me.LabelAgv.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelAgv.Location = New System.Drawing.Point(11, 41)
        Me.LabelAgv.Name = "LabelAgv"
        Me.LabelAgv.Size = New System.Drawing.Size(168, 73)
        Me.LabelAgv.TabIndex = 1
        Me.LabelAgv.Text = "AGV"
        '
        'PanelSecondPart
        '
        Me.PanelSecondPart.Controls.Add(Me.btnRelease)
        Me.PanelSecondPart.Controls.Add(Me.LabelSecondPart)
        Me.PanelSecondPart.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelSecondPart.Location = New System.Drawing.Point(186, 4)
        Me.PanelSecondPart.Name = "PanelSecondPart"
        Me.PanelSecondPart.Size = New System.Drawing.Size(540, 142)
        Me.PanelSecondPart.TabIndex = 0
        '
        'btnRelease
        '
        Me.btnRelease.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRelease.Location = New System.Drawing.Point(462, 3)
        Me.btnRelease.Name = "btnRelease"
        Me.btnRelease.Size = New System.Drawing.Size(75, 23)
        Me.btnRelease.TabIndex = 1
        Me.btnRelease.Text = "Release"
        Me.btnRelease.UseVisualStyleBackColor = True
        '
        'LabelSecondPart
        '
        Me.LabelSecondPart.AutoSize = True
        Me.LabelSecondPart.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSecondPart.Location = New System.Drawing.Point(21, 41)
        Me.LabelSecondPart.Name = "LabelSecondPart"
        Me.LabelSecondPart.Size = New System.Drawing.Size(86, 73)
        Me.LabelSecondPart.TabIndex = 0
        Me.LabelSecondPart.Text = "..."
        '
        'ucAgvSupply
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "ucAgvSupply"
        Me.Size = New System.Drawing.Size(730, 150)
        Me.TableLayoutPanel1.ResumeLayout(false)
        Me.PanelAgv.ResumeLayout(false)
        Me.PanelAgv.PerformLayout
        Me.PanelSecondPart.ResumeLayout(false)
        Me.PanelSecondPart.PerformLayout
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents PanelAgv As Panel
    Friend WithEvents PanelSecondPart As Panel
    Friend WithEvents LabelAgv As Label
    Friend WithEvents LabelSecondPart As Label
    Friend WithEvents btnRelease As Button
End Class
