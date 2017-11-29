<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SettingForm))
        Me.TabSetting = New System.Windows.Forms.TabControl()
        Me.TabSettingAGV = New System.Windows.Forms.TabPage()
        Me.dgvAGV = New System.Windows.Forms.DataGridView()
        Me.TabSettingPart = New System.Windows.Forms.TabPage()
        Me.dgvPart = New System.Windows.Forms.DataGridView()
        Me.TabSettingEndDevices = New System.Windows.Forms.TabPage()
        Me.dgvEndDevices = New System.Windows.Forms.DataGridView()
        Me.TabSettingHostXbee = New System.Windows.Forms.TabPage()
        Me.dgvHostXbee = New System.Windows.Forms.DataGridView()
        Me.TabSettingLine = New System.Windows.Forms.TabPage()
        Me.dgvLineGroup = New System.Windows.Forms.DataGridView()
        Me.TabSettingStartPoint = New System.Windows.Forms.TabPage()
        Me.dgvStartPoint = New System.Windows.Forms.DataGridView()
        Me.TabSettingCrossPoint = New System.Windows.Forms.TabPage()
        Me.dgvCrossPoint = New System.Windows.Forms.DataGridView()
        Me.TabSettingAGVGroup = New System.Windows.Forms.TabPage()
        Me.dgvAGVGroup = New System.Windows.Forms.DataGridView()
        Me.TabSettingParkPoint = New System.Windows.Forms.TabPage()
        Me.dgvParkPoint = New System.Windows.Forms.DataGridView()
        Me.TabWorkingTime = New System.Windows.Forms.TabPage()
        Me.dgvWorkingTime = New System.Windows.Forms.DataGridView()
        Me.TabChart = New System.Windows.Forms.TabPage()
        Me.dgvChart = New System.Windows.Forms.DataGridView()
        Me.butSettingOK = New System.Windows.Forms.Button()
        Me.butSettingCancel = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddColumnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveColumnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FindToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.But_Find = New System.Windows.Forms.Button()
        Me.ButtonApply = New System.Windows.Forms.Button()
        Me.TabTextSource = New System.Windows.Forms.TabPage()
        Me.dgvTextSource = New System.Windows.Forms.DataGridView()
        Me.TabSetting.SuspendLayout
        Me.TabSettingAGV.SuspendLayout
        CType(Me.dgvAGV,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TabSettingPart.SuspendLayout
        CType(Me.dgvPart,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TabSettingEndDevices.SuspendLayout
        CType(Me.dgvEndDevices,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TabSettingHostXbee.SuspendLayout
        CType(Me.dgvHostXbee,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TabSettingLine.SuspendLayout
        CType(Me.dgvLineGroup,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TabSettingStartPoint.SuspendLayout
        CType(Me.dgvStartPoint,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TabSettingCrossPoint.SuspendLayout
        CType(Me.dgvCrossPoint,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TabSettingAGVGroup.SuspendLayout
        CType(Me.dgvAGVGroup,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TabSettingParkPoint.SuspendLayout
        CType(Me.dgvParkPoint,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TabWorkingTime.SuspendLayout
        CType(Me.dgvWorkingTime,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TabChart.SuspendLayout
        CType(Me.dgvChart,System.ComponentModel.ISupportInitialize).BeginInit
        Me.MenuStrip1.SuspendLayout
        Me.TabTextSource.SuspendLayout
        CType(Me.dgvTextSource,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'TabSetting
        '
        Me.TabSetting.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.TabSetting.Controls.Add(Me.TabSettingAGV)
        Me.TabSetting.Controls.Add(Me.TabSettingPart)
        Me.TabSetting.Controls.Add(Me.TabSettingEndDevices)
        Me.TabSetting.Controls.Add(Me.TabSettingHostXbee)
        Me.TabSetting.Controls.Add(Me.TabSettingLine)
        Me.TabSetting.Controls.Add(Me.TabSettingStartPoint)
        Me.TabSetting.Controls.Add(Me.TabSettingCrossPoint)
        Me.TabSetting.Controls.Add(Me.TabSettingAGVGroup)
        Me.TabSetting.Controls.Add(Me.TabSettingParkPoint)
        Me.TabSetting.Controls.Add(Me.TabWorkingTime)
        Me.TabSetting.Controls.Add(Me.TabChart)
        Me.TabSetting.Controls.Add(Me.TabTextSource)
        Me.TabSetting.Location = New System.Drawing.Point(0, 24)
        Me.TabSetting.Multiline = true
        Me.TabSetting.Name = "TabSetting"
        Me.TabSetting.SelectedIndex = 0
        Me.TabSetting.Size = New System.Drawing.Size(1217, 548)
        Me.TabSetting.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabSetting.TabIndex = 2
        '
        'TabSettingAGV
        '
        Me.TabSettingAGV.Controls.Add(Me.dgvAGV)
        Me.TabSettingAGV.Location = New System.Drawing.Point(4, 22)
        Me.TabSettingAGV.Name = "TabSettingAGV"
        Me.TabSettingAGV.Padding = New System.Windows.Forms.Padding(3)
        Me.TabSettingAGV.Size = New System.Drawing.Size(1209, 522)
        Me.TabSettingAGV.TabIndex = 0
        Me.TabSettingAGV.Text = "AGV"
        Me.TabSettingAGV.UseVisualStyleBackColor = true
        '
        'dgvAGV
        '
        Me.dgvAGV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAGV.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgvAGV.Location = New System.Drawing.Point(3, 3)
        Me.dgvAGV.Name = "dgvAGV"
        Me.dgvAGV.RowHeadersWidth = 50
        Me.dgvAGV.Size = New System.Drawing.Size(1203, 516)
        Me.dgvAGV.TabIndex = 2
        '
        'TabSettingPart
        '
        Me.TabSettingPart.Controls.Add(Me.dgvPart)
        Me.TabSettingPart.Location = New System.Drawing.Point(4, 22)
        Me.TabSettingPart.Name = "TabSettingPart"
        Me.TabSettingPart.Padding = New System.Windows.Forms.Padding(3)
        Me.TabSettingPart.Size = New System.Drawing.Size(1209, 522)
        Me.TabSettingPart.TabIndex = 1
        Me.TabSettingPart.Text = "Part"
        Me.TabSettingPart.UseVisualStyleBackColor = true
        '
        'dgvPart
        '
        Me.dgvPart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPart.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPart.Location = New System.Drawing.Point(3, 3)
        Me.dgvPart.Name = "dgvPart"
        Me.dgvPart.Size = New System.Drawing.Size(1203, 516)
        Me.dgvPart.TabIndex = 0
        '
        'TabSettingEndDevices
        '
        Me.TabSettingEndDevices.Controls.Add(Me.dgvEndDevices)
        Me.TabSettingEndDevices.Location = New System.Drawing.Point(4, 22)
        Me.TabSettingEndDevices.Name = "TabSettingEndDevices"
        Me.TabSettingEndDevices.Size = New System.Drawing.Size(1209, 522)
        Me.TabSettingEndDevices.TabIndex = 2
        Me.TabSettingEndDevices.Text = "End Devices"
        Me.TabSettingEndDevices.UseVisualStyleBackColor = true
        '
        'dgvEndDevices
        '
        Me.dgvEndDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEndDevices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvEndDevices.Location = New System.Drawing.Point(0, 0)
        Me.dgvEndDevices.Name = "dgvEndDevices"
        Me.dgvEndDevices.Size = New System.Drawing.Size(1209, 522)
        Me.dgvEndDevices.TabIndex = 0
        '
        'TabSettingHostXbee
        '
        Me.TabSettingHostXbee.Controls.Add(Me.dgvHostXbee)
        Me.TabSettingHostXbee.Location = New System.Drawing.Point(4, 22)
        Me.TabSettingHostXbee.Name = "TabSettingHostXbee"
        Me.TabSettingHostXbee.Size = New System.Drawing.Size(1209, 522)
        Me.TabSettingHostXbee.TabIndex = 3
        Me.TabSettingHostXbee.Text = "Host Xbee"
        Me.TabSettingHostXbee.UseVisualStyleBackColor = true
        '
        'dgvHostXbee
        '
        Me.dgvHostXbee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHostXbee.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvHostXbee.Location = New System.Drawing.Point(0, 0)
        Me.dgvHostXbee.Name = "dgvHostXbee"
        Me.dgvHostXbee.Size = New System.Drawing.Size(1209, 522)
        Me.dgvHostXbee.TabIndex = 0
        '
        'TabSettingLine
        '
        Me.TabSettingLine.Controls.Add(Me.dgvLineGroup)
        Me.TabSettingLine.Location = New System.Drawing.Point(4, 22)
        Me.TabSettingLine.Name = "TabSettingLine"
        Me.TabSettingLine.Size = New System.Drawing.Size(1209, 522)
        Me.TabSettingLine.TabIndex = 4
        Me.TabSettingLine.Text = "Line"
        Me.TabSettingLine.UseVisualStyleBackColor = true
        '
        'dgvLineGroup
        '
        Me.dgvLineGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLineGroup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLineGroup.Location = New System.Drawing.Point(0, 0)
        Me.dgvLineGroup.Name = "dgvLineGroup"
        Me.dgvLineGroup.Size = New System.Drawing.Size(1209, 522)
        Me.dgvLineGroup.TabIndex = 0
        '
        'TabSettingStartPoint
        '
        Me.TabSettingStartPoint.Controls.Add(Me.dgvStartPoint)
        Me.TabSettingStartPoint.Location = New System.Drawing.Point(4, 22)
        Me.TabSettingStartPoint.Name = "TabSettingStartPoint"
        Me.TabSettingStartPoint.Size = New System.Drawing.Size(1209, 522)
        Me.TabSettingStartPoint.TabIndex = 5
        Me.TabSettingStartPoint.Text = "Start Point"
        Me.TabSettingStartPoint.UseVisualStyleBackColor = true
        '
        'dgvStartPoint
        '
        Me.dgvStartPoint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvStartPoint.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvStartPoint.Location = New System.Drawing.Point(0, 0)
        Me.dgvStartPoint.Name = "dgvStartPoint"
        Me.dgvStartPoint.Size = New System.Drawing.Size(1209, 522)
        Me.dgvStartPoint.TabIndex = 0
        '
        'TabSettingCrossPoint
        '
        Me.TabSettingCrossPoint.Controls.Add(Me.dgvCrossPoint)
        Me.TabSettingCrossPoint.Location = New System.Drawing.Point(4, 22)
        Me.TabSettingCrossPoint.Name = "TabSettingCrossPoint"
        Me.TabSettingCrossPoint.Padding = New System.Windows.Forms.Padding(3)
        Me.TabSettingCrossPoint.Size = New System.Drawing.Size(1209, 522)
        Me.TabSettingCrossPoint.TabIndex = 6
        Me.TabSettingCrossPoint.Text = "Cross point"
        Me.TabSettingCrossPoint.UseVisualStyleBackColor = true
        '
        'dgvCrossPoint
        '
        Me.dgvCrossPoint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCrossPoint.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCrossPoint.Location = New System.Drawing.Point(3, 3)
        Me.dgvCrossPoint.Name = "dgvCrossPoint"
        Me.dgvCrossPoint.Size = New System.Drawing.Size(1203, 516)
        Me.dgvCrossPoint.TabIndex = 0
        '
        'TabSettingAGVGroup
        '
        Me.TabSettingAGVGroup.Controls.Add(Me.dgvAGVGroup)
        Me.TabSettingAGVGroup.Location = New System.Drawing.Point(4, 22)
        Me.TabSettingAGVGroup.Name = "TabSettingAGVGroup"
        Me.TabSettingAGVGroup.Padding = New System.Windows.Forms.Padding(3)
        Me.TabSettingAGVGroup.Size = New System.Drawing.Size(1209, 522)
        Me.TabSettingAGVGroup.TabIndex = 7
        Me.TabSettingAGVGroup.Text = "AGV group"
        Me.TabSettingAGVGroup.UseVisualStyleBackColor = true
        '
        'dgvAGVGroup
        '
        Me.dgvAGVGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAGVGroup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAGVGroup.Location = New System.Drawing.Point(3, 3)
        Me.dgvAGVGroup.Name = "dgvAGVGroup"
        Me.dgvAGVGroup.Size = New System.Drawing.Size(1203, 516)
        Me.dgvAGVGroup.TabIndex = 0
        '
        'TabSettingParkPoint
        '
        Me.TabSettingParkPoint.Controls.Add(Me.dgvParkPoint)
        Me.TabSettingParkPoint.Location = New System.Drawing.Point(4, 22)
        Me.TabSettingParkPoint.Name = "TabSettingParkPoint"
        Me.TabSettingParkPoint.Padding = New System.Windows.Forms.Padding(3)
        Me.TabSettingParkPoint.Size = New System.Drawing.Size(1209, 522)
        Me.TabSettingParkPoint.TabIndex = 8
        Me.TabSettingParkPoint.Text = "Park point"
        Me.TabSettingParkPoint.UseVisualStyleBackColor = true
        '
        'dgvParkPoint
        '
        Me.dgvParkPoint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvParkPoint.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvParkPoint.Location = New System.Drawing.Point(3, 3)
        Me.dgvParkPoint.Name = "dgvParkPoint"
        Me.dgvParkPoint.Size = New System.Drawing.Size(1203, 516)
        Me.dgvParkPoint.TabIndex = 0
        '
        'TabWorkingTime
        '
        Me.TabWorkingTime.Controls.Add(Me.dgvWorkingTime)
        Me.TabWorkingTime.Location = New System.Drawing.Point(4, 22)
        Me.TabWorkingTime.Name = "TabWorkingTime"
        Me.TabWorkingTime.Padding = New System.Windows.Forms.Padding(3)
        Me.TabWorkingTime.Size = New System.Drawing.Size(1209, 522)
        Me.TabWorkingTime.TabIndex = 9
        Me.TabWorkingTime.Text = "Working time"
        Me.TabWorkingTime.UseVisualStyleBackColor = true
        '
        'dgvWorkingTime
        '
        Me.dgvWorkingTime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvWorkingTime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvWorkingTime.Location = New System.Drawing.Point(3, 3)
        Me.dgvWorkingTime.Name = "dgvWorkingTime"
        Me.dgvWorkingTime.Size = New System.Drawing.Size(1203, 516)
        Me.dgvWorkingTime.TabIndex = 0
        '
        'TabChart
        '
        Me.TabChart.Controls.Add(Me.dgvChart)
        Me.TabChart.Location = New System.Drawing.Point(4, 22)
        Me.TabChart.Name = "TabChart"
        Me.TabChart.Padding = New System.Windows.Forms.Padding(3)
        Me.TabChart.Size = New System.Drawing.Size(1209, 522)
        Me.TabChart.TabIndex = 10
        Me.TabChart.Text = "Chart"
        Me.TabChart.UseVisualStyleBackColor = true
        '
        'dgvChart
        '
        Me.dgvChart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvChart.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvChart.Location = New System.Drawing.Point(3, 3)
        Me.dgvChart.Name = "dgvChart"
        Me.dgvChart.Size = New System.Drawing.Size(1203, 516)
        Me.dgvChart.TabIndex = 0
        '
        'butSettingOK
        '
        Me.butSettingOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.butSettingOK.Location = New System.Drawing.Point(1037, 604)
        Me.butSettingOK.Name = "butSettingOK"
        Me.butSettingOK.Size = New System.Drawing.Size(81, 29)
        Me.butSettingOK.TabIndex = 3
        Me.butSettingOK.Text = "OK"
        Me.butSettingOK.UseVisualStyleBackColor = true
        '
        'butSettingCancel
        '
        Me.butSettingCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.butSettingCancel.Location = New System.Drawing.Point(1124, 604)
        Me.butSettingCancel.Name = "butSettingCancel"
        Me.butSettingCancel.Size = New System.Drawing.Size(81, 29)
        Me.butSettingCancel.TabIndex = 4
        Me.butSettingCancel.Text = "Cancel"
        Me.butSettingCancel.UseVisualStyleBackColor = true
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ToolToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1217, 24)
        Me.MenuStrip1.TabIndex = 8
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.SaveToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O),System.Windows.Forms.Keys)
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.OpenToolStripMenuItem.Text = "Open"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S),System.Windows.Forms.Keys)
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearToolStripMenuItem, Me.ClearAllToolStripMenuItem, Me.AddColumnToolStripMenuItem, Me.RemoveColumnToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ClearToolStripMenuItem
        '
        Me.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem"
        Me.ClearToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.ClearToolStripMenuItem.Text = "Clear table"
        '
        'ClearAllToolStripMenuItem
        '
        Me.ClearAllToolStripMenuItem.Name = "ClearAllToolStripMenuItem"
        Me.ClearAllToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.ClearAllToolStripMenuItem.Text = "Clear all"
        '
        'AddColumnToolStripMenuItem
        '
        Me.AddColumnToolStripMenuItem.Name = "AddColumnToolStripMenuItem"
        Me.AddColumnToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.AddColumnToolStripMenuItem.Text = "Add column"
        '
        'RemoveColumnToolStripMenuItem
        '
        Me.RemoveColumnToolStripMenuItem.Name = "RemoveColumnToolStripMenuItem"
        Me.RemoveColumnToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.RemoveColumnToolStripMenuItem.Text = "Remove column"
        '
        'ToolToolStripMenuItem
        '
        Me.ToolToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FindToolStripMenuItem})
        Me.ToolToolStripMenuItem.Name = "ToolToolStripMenuItem"
        Me.ToolToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.ToolToolStripMenuItem.Text = "Tool"
        '
        'FindToolStripMenuItem
        '
        Me.FindToolStripMenuItem.Name = "FindToolStripMenuItem"
        Me.FindToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F),System.Windows.Forms.Keys)
        Me.FindToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.FindToolStripMenuItem.Text = "Find"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'But_Find
        '
        Me.But_Find.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.But_Find.Location = New System.Drawing.Point(12, 604)
        Me.But_Find.Name = "But_Find"
        Me.But_Find.Size = New System.Drawing.Size(81, 29)
        Me.But_Find.TabIndex = 9
        Me.But_Find.Text = "Find"
        Me.But_Find.UseVisualStyleBackColor = true
        '
        'ButtonApply
        '
        Me.ButtonApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.ButtonApply.Location = New System.Drawing.Point(950, 604)
        Me.ButtonApply.Name = "ButtonApply"
        Me.ButtonApply.Size = New System.Drawing.Size(81, 29)
        Me.ButtonApply.TabIndex = 10
        Me.ButtonApply.Text = "Apply"
        Me.ButtonApply.UseVisualStyleBackColor = true
        '
        'TabTextSource
        '
        Me.TabTextSource.Controls.Add(Me.dgvTextSource)
        Me.TabTextSource.Location = New System.Drawing.Point(4, 22)
        Me.TabTextSource.Name = "TabTextSource"
        Me.TabTextSource.Size = New System.Drawing.Size(1209, 522)
        Me.TabTextSource.TabIndex = 11
        Me.TabTextSource.Text = "TextSource"
        Me.TabTextSource.UseVisualStyleBackColor = true
        '
        'dgvTextSource
        '
        Me.dgvTextSource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTextSource.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTextSource.Location = New System.Drawing.Point(0, 0)
        Me.dgvTextSource.Name = "dgvTextSource"
        Me.dgvTextSource.Size = New System.Drawing.Size(1209, 522)
        Me.dgvTextSource.TabIndex = 0
        '
        'SettingForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1217, 645)
        Me.Controls.Add(Me.ButtonApply)
        Me.Controls.Add(Me.But_Find)
        Me.Controls.Add(Me.butSettingOK)
        Me.Controls.Add(Me.butSettingCancel)
        Me.Controls.Add(Me.TabSetting)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "SettingForm"
        Me.Text = "Setting"
        Me.TabSetting.ResumeLayout(false)
        Me.TabSettingAGV.ResumeLayout(false)
        CType(Me.dgvAGV,System.ComponentModel.ISupportInitialize).EndInit
        Me.TabSettingPart.ResumeLayout(false)
        CType(Me.dgvPart,System.ComponentModel.ISupportInitialize).EndInit
        Me.TabSettingEndDevices.ResumeLayout(false)
        CType(Me.dgvEndDevices,System.ComponentModel.ISupportInitialize).EndInit
        Me.TabSettingHostXbee.ResumeLayout(false)
        CType(Me.dgvHostXbee,System.ComponentModel.ISupportInitialize).EndInit
        Me.TabSettingLine.ResumeLayout(false)
        CType(Me.dgvLineGroup,System.ComponentModel.ISupportInitialize).EndInit
        Me.TabSettingStartPoint.ResumeLayout(false)
        CType(Me.dgvStartPoint,System.ComponentModel.ISupportInitialize).EndInit
        Me.TabSettingCrossPoint.ResumeLayout(false)
        CType(Me.dgvCrossPoint,System.ComponentModel.ISupportInitialize).EndInit
        Me.TabSettingAGVGroup.ResumeLayout(false)
        CType(Me.dgvAGVGroup,System.ComponentModel.ISupportInitialize).EndInit
        Me.TabSettingParkPoint.ResumeLayout(false)
        CType(Me.dgvParkPoint,System.ComponentModel.ISupportInitialize).EndInit
        Me.TabWorkingTime.ResumeLayout(false)
        CType(Me.dgvWorkingTime,System.ComponentModel.ISupportInitialize).EndInit
        Me.TabChart.ResumeLayout(false)
        CType(Me.dgvChart,System.ComponentModel.ISupportInitialize).EndInit
        Me.MenuStrip1.ResumeLayout(false)
        Me.MenuStrip1.PerformLayout
        Me.TabTextSource.ResumeLayout(false)
        CType(Me.dgvTextSource,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents TabSetting As System.Windows.Forms.TabControl
	Friend WithEvents TabSettingPart As System.Windows.Forms.TabPage
	Friend WithEvents butSettingOK As System.Windows.Forms.Button
	Friend WithEvents butSettingCancel As System.Windows.Forms.Button
	Friend WithEvents dgvAGV As System.Windows.Forms.DataGridView
	Friend WithEvents dgvPart As System.Windows.Forms.DataGridView
	Friend WithEvents TabSettingEndDevices As System.Windows.Forms.TabPage
	Friend WithEvents dgvEndDevices As System.Windows.Forms.DataGridView
	Friend WithEvents TabSettingHostXbee As System.Windows.Forms.TabPage
	Friend WithEvents dgvHostXbee As System.Windows.Forms.DataGridView
	Friend WithEvents TabSettingLine As System.Windows.Forms.TabPage
	Friend WithEvents dgvLineGroup As System.Windows.Forms.DataGridView
	Friend WithEvents TabSettingStartPoint As System.Windows.Forms.TabPage
	Friend WithEvents dgvStartPoint As System.Windows.Forms.DataGridView
	Friend WithEvents TabSettingCrossPoint As System.Windows.Forms.TabPage
	Friend WithEvents dgvCrossPoint As System.Windows.Forms.DataGridView
	Friend WithEvents TabSettingAGVGroup As System.Windows.Forms.TabPage
	Friend WithEvents dgvAGVGroup As System.Windows.Forms.DataGridView
	Friend WithEvents TabSettingParkPoint As System.Windows.Forms.TabPage
	Friend WithEvents dgvParkPoint As System.Windows.Forms.DataGridView
	Friend WithEvents TabWorkingTime As System.Windows.Forms.TabPage
	Friend WithEvents dgvWorkingTime As System.Windows.Forms.DataGridView
	Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
	Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ClearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ClearAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ToolToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents FindToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents TabSettingAGV As System.Windows.Forms.TabPage
	Friend WithEvents But_Find As System.Windows.Forms.Button
	Friend WithEvents AddColumnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents RemoveColumnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents TabChart As System.Windows.Forms.TabPage
	Friend WithEvents dgvChart As System.Windows.Forms.DataGridView
	Friend WithEvents ButtonApply As System.Windows.Forms.Button
    Friend WithEvents TabTextSource As TabPage
    Friend WithEvents dgvTextSource As DataGridView
End Class
