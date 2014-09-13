<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Title1 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Me.MainManu = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintPreviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UndoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RedoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.CutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IndexToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MainStatus = New System.Windows.Forms.StatusStrip()
        Me.imgAGVBig = New System.Windows.Forms.ImageList(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.olvAGV = New BrightIdeasSoftware.ObjectListView()
        Me.OlvColumnName = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnPart = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnWorkingType = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnPosition = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnStatus = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnConnecting = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnBattery = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.MenuLstViewAGV = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuAGVView = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuAGVViewLargeIcon = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuAGVViewDetails = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuAGVViewSmallIcon = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuAGVViewList = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuAGVViewTile = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuAGVConfirmConn = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuAGVConfirmSelected = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuAGVConfirmAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuAGVEnable = New System.Windows.Forms.ToolStripMenuItem()
        Me.olvPart = New BrightIdeasSoftware.ObjectListView()
        Me.OlvColumnPartGroup = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.AGVPerformance = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.contMenuLstViewPart = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuPartViewLargeIcon = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuPartViewDetail = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuPartViewSmallIcon = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuPartViewList = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuPartViewTile = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfirmConnectionToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ForEndDevicesOfSelectedPartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ForAllEndDevicesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.imgPartBig = New System.Windows.Forms.ImageList(Me.components)
        Me.imgPartSmall = New System.Windows.Forms.ImageList(Me.components)
        Me.imgAGVSmall = New System.Windows.Forms.ImageList(Me.components)
        Me.DisplayTimer = New System.Windows.Forms.Timer(Me.components)
        Me.CrossTimer = New System.Windows.Forms.Timer(Me.components)
        Me.AutoSaveTimer = New System.Windows.Forms.Timer(Me.components)
        Me.RecordTimer = New System.Windows.Forms.Timer(Me.components)
        Me.AndonTimer = New System.Windows.Forms.Timer(Me.components)
        Me.MainManu.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.olvAGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuLstViewAGV.SuspendLayout()
        CType(Me.olvPart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.AGVPerformance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.contMenuLstViewPart.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainManu
        '
        Me.MainManu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.HelpToolStripMenuItem1})
        Me.MainManu.Location = New System.Drawing.Point(0, 0)
        Me.MainManu.Name = "MainManu"
        Me.MainManu.Size = New System.Drawing.Size(1904, 24)
        Me.MainManu.TabIndex = 0
        Me.MainManu.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.OpenToolStripMenuItem, Me.toolStripSeparator, Me.SaveToolStripMenuItem, Me.SaveAsToolStripMenuItem, Me.toolStripSeparator1, Me.PrintToolStripMenuItem, Me.PrintPreviewToolStripMenuItem, Me.toolStripSeparator2, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Image = CType(resources.GetObject("NewToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.NewToolStripMenuItem.Text = "&New"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Image = CType(resources.GetObject("OpenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OpenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.OpenToolStripMenuItem.Text = "&Open"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(143, 6)
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Image = CType(resources.GetObject("SaveToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SaveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.SaveToolStripMenuItem.Text = "&Save"
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.SaveAsToolStripMenuItem.Text = "Save &As"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(143, 6)
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Image = CType(resources.GetObject("PrintToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PrintToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.PrintToolStripMenuItem.Text = "&Print"
        '
        'PrintPreviewToolStripMenuItem
        '
        Me.PrintPreviewToolStripMenuItem.Image = CType(resources.GetObject("PrintPreviewToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PrintPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintPreviewToolStripMenuItem.Name = "PrintPreviewToolStripMenuItem"
        Me.PrintPreviewToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.PrintPreviewToolStripMenuItem.Text = "Print Pre&view"
        '
        'toolStripSeparator2
        '
        Me.toolStripSeparator2.Name = "toolStripSeparator2"
        Me.toolStripSeparator2.Size = New System.Drawing.Size(143, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UndoToolStripMenuItem, Me.RedoToolStripMenuItem, Me.toolStripSeparator3, Me.CutToolStripMenuItem, Me.CopyToolStripMenuItem, Me.PasteToolStripMenuItem, Me.toolStripSeparator4, Me.SelectAllToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "&Edit"
        '
        'UndoToolStripMenuItem
        '
        Me.UndoToolStripMenuItem.Name = "UndoToolStripMenuItem"
        Me.UndoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.UndoToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.UndoToolStripMenuItem.Text = "&Undo"
        '
        'RedoToolStripMenuItem
        '
        Me.RedoToolStripMenuItem.Name = "RedoToolStripMenuItem"
        Me.RedoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys)
        Me.RedoToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.RedoToolStripMenuItem.Text = "&Redo"
        '
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(141, 6)
        '
        'CutToolStripMenuItem
        '
        Me.CutToolStripMenuItem.Image = CType(resources.GetObject("CutToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        Me.CutToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.CutToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.CutToolStripMenuItem.Text = "Cu&t"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Image = CType(resources.GetObject("CopyToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CopyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.CopyToolStripMenuItem.Text = "&Copy"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Image = CType(resources.GetObject("PasteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.PasteToolStripMenuItem.Text = "&Paste"
        '
        'toolStripSeparator4
        '
        Me.toolStripSeparator4.Name = "toolStripSeparator4"
        Me.toolStripSeparator4.Size = New System.Drawing.Size(141, 6)
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.SelectAllToolStripMenuItem.Text = "Select &All"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CustomizeToolStripMenuItem, Me.OptionsToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.ToolsToolStripMenuItem.Text = "&Tools"
        '
        'CustomizeToolStripMenuItem
        '
        Me.CustomizeToolStripMenuItem.Name = "CustomizeToolStripMenuItem"
        Me.CustomizeToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.CustomizeToolStripMenuItem.Text = "&Customize"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.OptionsToolStripMenuItem.Text = "&Options"
        '
        'HelpToolStripMenuItem1
        '
        Me.HelpToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContentsToolStripMenuItem, Me.IndexToolStripMenuItem, Me.SearchToolStripMenuItem, Me.toolStripSeparator5, Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem1.Name = "HelpToolStripMenuItem1"
        Me.HelpToolStripMenuItem1.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem1.Text = "&Help"
        '
        'ContentsToolStripMenuItem
        '
        Me.ContentsToolStripMenuItem.Name = "ContentsToolStripMenuItem"
        Me.ContentsToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.ContentsToolStripMenuItem.Text = "&Contents"
        '
        'IndexToolStripMenuItem
        '
        Me.IndexToolStripMenuItem.Name = "IndexToolStripMenuItem"
        Me.IndexToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.IndexToolStripMenuItem.Text = "&Index"
        '
        'SearchToolStripMenuItem
        '
        Me.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem"
        Me.SearchToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.SearchToolStripMenuItem.Text = "&Search"
        '
        'toolStripSeparator5
        '
        Me.toolStripSeparator5.Name = "toolStripSeparator5"
        Me.toolStripSeparator5.Size = New System.Drawing.Size(119, 6)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.AboutToolStripMenuItem.Text = "&About..."
        '
        'MainStatus
        '
        Me.MainStatus.Location = New System.Drawing.Point(0, 1020)
        Me.MainStatus.Name = "MainStatus"
        Me.MainStatus.Size = New System.Drawing.Size(1904, 22)
        Me.MainStatus.TabIndex = 1
        Me.MainStatus.Text = "StatusStrip1"
        '
        'imgAGVBig
        '
        Me.imgAGVBig.ImageStream = CType(resources.GetObject("imgAGVBig.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgAGVBig.TransparentColor = System.Drawing.Color.Transparent
        Me.imgAGVBig.Images.SetKeyName(0, "Disable.jpg")
        Me.imgAGVBig.Images.SetKeyName(1, "0-Connect.jpg")
        Me.imgAGVBig.Images.SetKeyName(2, "0-Disconnect.jpg")
        Me.imgAGVBig.Images.SetKeyName(3, "1-Connect.jpg")
        Me.imgAGVBig.Images.SetKeyName(4, "1-Disconnect.jpg")
        Me.imgAGVBig.Images.SetKeyName(5, "2-Connect.jpg")
        Me.imgAGVBig.Images.SetKeyName(6, "2-Disconnect.jpg")
        Me.imgAGVBig.Images.SetKeyName(7, "3-Connect.jpg")
        Me.imgAGVBig.Images.SetKeyName(8, "3-Disconnect.jpg")
        Me.imgAGVBig.Images.SetKeyName(9, "4-Connect.jpg")
        Me.imgAGVBig.Images.SetKeyName(10, "4-Disconnect.jpg")
        Me.imgAGVBig.Images.SetKeyName(11, "5-Connect.jpg")
        Me.imgAGVBig.Images.SetKeyName(12, "5-Disconnect.jpg")
        Me.imgAGVBig.Images.SetKeyName(13, "6-Connect.jpg")
        Me.imgAGVBig.Images.SetKeyName(14, "6-Disconnect.jpg")
        Me.imgAGVBig.Images.SetKeyName(15, "7-Connect.jpg")
        Me.imgAGVBig.Images.SetKeyName(16, "7-Disconnect.jpg")
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Location = New System.Drawing.Point(12, 24)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1880, 990)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TableLayoutPanel1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1872, 964)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Overview"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.olvAGV, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.olvPart, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 968.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1529, 968)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'olvAGV
        '
        Me.olvAGV.AllColumns.Add(Me.OlvColumnName)
        Me.olvAGV.AllColumns.Add(Me.OlvColumnPart)
        Me.olvAGV.AllColumns.Add(Me.OlvColumnWorkingType)
        Me.olvAGV.AllColumns.Add(Me.OlvColumnPosition)
        Me.olvAGV.AllColumns.Add(Me.OlvColumnStatus)
        Me.olvAGV.AllColumns.Add(Me.OlvColumnConnecting)
        Me.olvAGV.AllColumns.Add(Me.OlvColumnBattery)
        Me.olvAGV.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumnName, Me.OlvColumnPart, Me.OlvColumnWorkingType, Me.OlvColumnPosition, Me.OlvColumnStatus, Me.OlvColumnConnecting, Me.OlvColumnBattery})
        Me.olvAGV.ContextMenuStrip = Me.MenuLstViewAGV
        Me.olvAGV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.olvAGV.Location = New System.Drawing.Point(3, 3)
        Me.olvAGV.Name = "olvAGV"
        Me.olvAGV.Size = New System.Drawing.Size(758, 962)
        Me.olvAGV.TabIndex = 6
        Me.olvAGV.TileSize = New System.Drawing.Size(230, 100)
        Me.olvAGV.UseCompatibleStateImageBehavior = False
        Me.olvAGV.View = System.Windows.Forms.View.Tile
        '
        'OlvColumnName
        '
        Me.OlvColumnName.AspectName = "Name"
        Me.OlvColumnName.CellPadding = Nothing
        Me.OlvColumnName.Text = "Name"
        '
        'OlvColumnPart
        '
        Me.OlvColumnPart.AspectName = "SupplyPartStatus"
        Me.OlvColumnPart.CellPadding = Nothing
        Me.OlvColumnPart.Text = "Part supply"
        '
        'OlvColumnWorkingType
        '
        Me.OlvColumnWorkingType.AspectName = "WorkingStatus"
        Me.OlvColumnWorkingType.CellPadding = Nothing
        Me.OlvColumnWorkingType.Text = "Working type"
        '
        'OlvColumnPosition
        '
        Me.OlvColumnPosition.AspectName = "Position"
        Me.OlvColumnPosition.CellPadding = Nothing
        Me.OlvColumnPosition.Text = "Position"
        '
        'OlvColumnStatus
        '
        Me.OlvColumnStatus.AspectName = "Status"
        Me.OlvColumnStatus.CellPadding = Nothing
        Me.OlvColumnStatus.Text = "Status"
        '
        'OlvColumnConnecting
        '
        Me.OlvColumnConnecting.AspectName = "Connecting"
        Me.OlvColumnConnecting.CellPadding = Nothing
        Me.OlvColumnConnecting.Text = "Connection"
        '
        'OlvColumnBattery
        '
        Me.OlvColumnBattery.AspectName = "Battery"
        Me.OlvColumnBattery.CellPadding = Nothing
        Me.OlvColumnBattery.Text = "Battery"
        '
        'MenuLstViewAGV
        '
        Me.MenuLstViewAGV.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuAGVView, Me.MenuAGVConfirmConn, Me.MenuAGVEnable})
        Me.MenuLstViewAGV.Name = "ContextMenuStrip1"
        Me.MenuLstViewAGV.Size = New System.Drawing.Size(182, 70)
        '
        'MenuAGVView
        '
        Me.MenuAGVView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuAGVViewLargeIcon, Me.MenuAGVViewDetails, Me.MenuAGVViewSmallIcon, Me.MenuAGVViewList, Me.MenuAGVViewTile})
        Me.MenuAGVView.Name = "MenuAGVView"
        Me.MenuAGVView.Size = New System.Drawing.Size(181, 22)
        Me.MenuAGVView.Text = "View"
        '
        'MenuAGVViewLargeIcon
        '
        Me.MenuAGVViewLargeIcon.Name = "MenuAGVViewLargeIcon"
        Me.MenuAGVViewLargeIcon.Size = New System.Drawing.Size(129, 22)
        Me.MenuAGVViewLargeIcon.Text = "Large Icon"
        '
        'MenuAGVViewDetails
        '
        Me.MenuAGVViewDetails.Name = "MenuAGVViewDetails"
        Me.MenuAGVViewDetails.Size = New System.Drawing.Size(129, 22)
        Me.MenuAGVViewDetails.Text = "Details"
        '
        'MenuAGVViewSmallIcon
        '
        Me.MenuAGVViewSmallIcon.Name = "MenuAGVViewSmallIcon"
        Me.MenuAGVViewSmallIcon.Size = New System.Drawing.Size(129, 22)
        Me.MenuAGVViewSmallIcon.Text = "Small Icon"
        '
        'MenuAGVViewList
        '
        Me.MenuAGVViewList.Name = "MenuAGVViewList"
        Me.MenuAGVViewList.Size = New System.Drawing.Size(129, 22)
        Me.MenuAGVViewList.Text = "List"
        '
        'MenuAGVViewTile
        '
        Me.MenuAGVViewTile.Name = "MenuAGVViewTile"
        Me.MenuAGVViewTile.Size = New System.Drawing.Size(129, 22)
        Me.MenuAGVViewTile.Text = "Tile"
        '
        'MenuAGVConfirmConn
        '
        Me.MenuAGVConfirmConn.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuAGVConfirmSelected, Me.MenuAGVConfirmAll})
        Me.MenuAGVConfirmConn.Name = "MenuAGVConfirmConn"
        Me.MenuAGVConfirmConn.Size = New System.Drawing.Size(181, 22)
        Me.MenuAGVConfirmConn.Text = "Confirm connection"
        '
        'MenuAGVConfirmSelected
        '
        Me.MenuAGVConfirmSelected.Name = "MenuAGVConfirmSelected"
        Me.MenuAGVConfirmSelected.Size = New System.Drawing.Size(163, 22)
        Me.MenuAGVConfirmSelected.Text = "For selected AGV"
        '
        'MenuAGVConfirmAll
        '
        Me.MenuAGVConfirmAll.Name = "MenuAGVConfirmAll"
        Me.MenuAGVConfirmAll.Size = New System.Drawing.Size(163, 22)
        Me.MenuAGVConfirmAll.Text = "For all AGV"
        '
        'MenuAGVEnable
        '
        Me.MenuAGVEnable.Name = "MenuAGVEnable"
        Me.MenuAGVEnable.Size = New System.Drawing.Size(181, 22)
        Me.MenuAGVEnable.Text = "Enable"
        '
        'olvPart
        '
        Me.olvPart.AllColumns.Add(Me.OlvColumnPartGroup)
        Me.olvPart.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumnPartGroup})
        Me.olvPart.ContextMenuStrip = Me.contMenuLstViewPart
        Me.olvPart.Dock = System.Windows.Forms.DockStyle.Fill
        Me.olvPart.Location = New System.Drawing.Point(767, 3)
        Me.olvPart.Name = "olvPart"
        Me.olvPart.Size = New System.Drawing.Size(759, 962)
        Me.olvPart.TabIndex = 7
        Me.olvPart.TileSize = New System.Drawing.Size(230, 100)
        Me.olvPart.UseCompatibleStateImageBehavior = False
        Me.olvPart.View = System.Windows.Forms.View.Details
        '
        'OlvColumnPartGroup
        '
        Me.OlvColumnPartGroup.AspectName = "group"
        Me.OlvColumnPartGroup.CellPadding = Nothing
        Me.OlvColumnPartGroup.Text = "Line"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.AGVPerformance)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1872, 964)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "AGV performent"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'AGVPerformance
        '
        ChartArea1.Name = "ChartArea1"
        Me.AGVPerformance.ChartAreas.Add(ChartArea1)
        Legend1.Font = New System.Drawing.Font("Cambria", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Legend1.IsTextAutoFit = False
        Legend1.Name = "Legend1"
        Me.AGVPerformance.Legends.Add(Legend1)
        Me.AGVPerformance.Location = New System.Drawing.Point(6, 6)
        Me.AGVPerformance.Name = "AGVPerformance"
        Me.AGVPerformance.Size = New System.Drawing.Size(1863, 952)
        Me.AGVPerformance.TabIndex = 0
        Me.AGVPerformance.Text = "Chart1"
        Title1.Font = New System.Drawing.Font("Cambria", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Title1.ForeColor = System.Drawing.Color.Maroon
        Title1.Name = "Title1"
        Title1.ShadowOffset = 3
        Title1.Text = "AGV STATUS"
        Title1.TextStyle = System.Windows.Forms.DataVisualization.Charting.TextStyle.Shadow
        Me.AGVPerformance.Titles.Add(Title1)
        '
        'TabPage3
        '
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1872, 964)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Map"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(1872, 964)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "History"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'TabPage5
        '
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(1872, 964)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Test"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'contMenuLstViewPart
        '
        Me.contMenuLstViewPart.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewToolStripMenuItem, Me.ConfirmConnectionToolStripMenuItem1})
        Me.contMenuLstViewPart.Name = "contMenuListViewPart"
        Me.contMenuLstViewPart.Size = New System.Drawing.Size(182, 48)
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuPartViewLargeIcon, Me.MenuPartViewDetail, Me.MenuPartViewSmallIcon, Me.MenuPartViewList, Me.MenuPartViewTile})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'MenuPartViewLargeIcon
        '
        Me.MenuPartViewLargeIcon.Name = "MenuPartViewLargeIcon"
        Me.MenuPartViewLargeIcon.Size = New System.Drawing.Size(129, 22)
        Me.MenuPartViewLargeIcon.Text = "Large Icon"
        '
        'MenuPartViewDetail
        '
        Me.MenuPartViewDetail.Name = "MenuPartViewDetail"
        Me.MenuPartViewDetail.Size = New System.Drawing.Size(129, 22)
        Me.MenuPartViewDetail.Text = "Detail"
        '
        'MenuPartViewSmallIcon
        '
        Me.MenuPartViewSmallIcon.Name = "MenuPartViewSmallIcon"
        Me.MenuPartViewSmallIcon.Size = New System.Drawing.Size(129, 22)
        Me.MenuPartViewSmallIcon.Text = "Small icon"
        '
        'MenuPartViewList
        '
        Me.MenuPartViewList.Name = "MenuPartViewList"
        Me.MenuPartViewList.Size = New System.Drawing.Size(129, 22)
        Me.MenuPartViewList.Text = "List"
        '
        'MenuPartViewTile
        '
        Me.MenuPartViewTile.Name = "MenuPartViewTile"
        Me.MenuPartViewTile.Size = New System.Drawing.Size(129, 22)
        Me.MenuPartViewTile.Text = "Tile"
        '
        'ConfirmConnectionToolStripMenuItem1
        '
        Me.ConfirmConnectionToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ForEndDevicesOfSelectedPartToolStripMenuItem, Me.ForAllEndDevicesToolStripMenuItem})
        Me.ConfirmConnectionToolStripMenuItem1.Name = "ConfirmConnectionToolStripMenuItem1"
        Me.ConfirmConnectionToolStripMenuItem1.Size = New System.Drawing.Size(181, 22)
        Me.ConfirmConnectionToolStripMenuItem1.Text = "Confirm connection"
        '
        'ForEndDevicesOfSelectedPartToolStripMenuItem
        '
        Me.ForEndDevicesOfSelectedPartToolStripMenuItem.Name = "ForEndDevicesOfSelectedPartToolStripMenuItem"
        Me.ForEndDevicesOfSelectedPartToolStripMenuItem.Size = New System.Drawing.Size(238, 22)
        Me.ForEndDevicesOfSelectedPartToolStripMenuItem.Text = "For EndDevices of selected part"
        '
        'ForAllEndDevicesToolStripMenuItem
        '
        Me.ForAllEndDevicesToolStripMenuItem.Name = "ForAllEndDevicesToolStripMenuItem"
        Me.ForAllEndDevicesToolStripMenuItem.Size = New System.Drawing.Size(238, 22)
        Me.ForAllEndDevicesToolStripMenuItem.Text = "For all EndDevices"
        '
        'imgPartBig
        '
        Me.imgPartBig.ImageStream = CType(resources.GetObject("imgPartBig.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgPartBig.TransparentColor = System.Drawing.Color.Transparent
        Me.imgPartBig.Images.SetKeyName(0, "Disable.jpg")
        Me.imgPartBig.Images.SetKeyName(1, "0-Connect.jpg")
        Me.imgPartBig.Images.SetKeyName(2, "0-Disconnect.jpg")
        Me.imgPartBig.Images.SetKeyName(3, "1-Connect.jpg")
        Me.imgPartBig.Images.SetKeyName(4, "1-Disconnect.jpg")
        Me.imgPartBig.Images.SetKeyName(5, "2-Connect.jpg")
        Me.imgPartBig.Images.SetKeyName(6, "2-Disconnect.jpg")
        '
        'imgPartSmall
        '
        Me.imgPartSmall.ImageStream = CType(resources.GetObject("imgPartSmall.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgPartSmall.TransparentColor = System.Drawing.Color.Transparent
        Me.imgPartSmall.Images.SetKeyName(0, "Disable.jpg")
        Me.imgPartSmall.Images.SetKeyName(1, "0-Connect.jpg")
        Me.imgPartSmall.Images.SetKeyName(2, "0-Disconnect.jpg")
        Me.imgPartSmall.Images.SetKeyName(3, "1-Connect.jpg")
        Me.imgPartSmall.Images.SetKeyName(4, "1-Disconnect.jpg")
        Me.imgPartSmall.Images.SetKeyName(5, "2-Connect.jpg")
        Me.imgPartSmall.Images.SetKeyName(6, "2-Disconnect.jpg")
        '
        'imgAGVSmall
        '
        Me.imgAGVSmall.ImageStream = CType(resources.GetObject("imgAGVSmall.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgAGVSmall.TransparentColor = System.Drawing.Color.Transparent
        Me.imgAGVSmall.Images.SetKeyName(0, "Disable.jpg")
        Me.imgAGVSmall.Images.SetKeyName(1, "0-Connect.jpg")
        Me.imgAGVSmall.Images.SetKeyName(2, "0-Disconnect.jpg")
        Me.imgAGVSmall.Images.SetKeyName(3, "1-Connect.jpg")
        Me.imgAGVSmall.Images.SetKeyName(4, "1-Disconnect.jpg")
        Me.imgAGVSmall.Images.SetKeyName(5, "2-Connect.jpg")
        Me.imgAGVSmall.Images.SetKeyName(6, "2-Disconnect.jpg")
        Me.imgAGVSmall.Images.SetKeyName(7, "3-Connect.jpg")
        Me.imgAGVSmall.Images.SetKeyName(8, "3-Disconnect.jpg")
        Me.imgAGVSmall.Images.SetKeyName(9, "4-Connect.jpg")
        Me.imgAGVSmall.Images.SetKeyName(10, "4-Disconnect.jpg")
        Me.imgAGVSmall.Images.SetKeyName(11, "5-Connect.jpg")
        Me.imgAGVSmall.Images.SetKeyName(12, "5-Disconnect.jpg")
        Me.imgAGVSmall.Images.SetKeyName(13, "6-Connect.jpg")
        Me.imgAGVSmall.Images.SetKeyName(14, "6-Disconnect.jpg")
        Me.imgAGVSmall.Images.SetKeyName(15, "7-Connect.jpg")
        Me.imgAGVSmall.Images.SetKeyName(16, "7-Disconnect.jpg")
        '
        'DisplayTimer
        '
        Me.DisplayTimer.Interval = 500
        '
        'CrossTimer
        '
        '
        'AutoSaveTimer
        '
        Me.AutoSaveTimer.Interval = 60000
        '
        'RecordTimer
        '
        Me.RecordTimer.Interval = 500
        '
        'AndonTimer
        '
        Me.AndonTimer.Interval = 500
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1904, 1042)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.MainStatus)
        Me.Controls.Add(Me.MainManu)
        Me.MainMenuStrip = Me.MainManu
        Me.Name = "MainForm"
        Me.Text = "Main windows"
        Me.MainManu.ResumeLayout(False)
        Me.MainManu.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.olvAGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuLstViewAGV.ResumeLayout(False)
        CType(Me.olvPart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.AGVPerformance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.contMenuLstViewPart.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MainManu As System.Windows.Forms.MenuStrip
    Friend WithEvents MainStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintPreviewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UndoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RedoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SelectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CustomizeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IndexToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents imgAGVBig As System.Windows.Forms.ImageList
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents AGVPerformance As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents imgAGVSmall As System.Windows.Forms.ImageList
    Friend WithEvents MenuLstViewAGV As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents contMenuLstViewPart As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents imgPartBig As System.Windows.Forms.ImageList
    Friend WithEvents imgPartSmall As System.Windows.Forms.ImageList
    Friend WithEvents DisplayTimer As System.Windows.Forms.Timer
    Friend WithEvents CrossTimer As System.Windows.Forms.Timer
    Friend WithEvents AutoSaveTimer As System.Windows.Forms.Timer
    Friend WithEvents RecordTimer As System.Windows.Forms.Timer
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuPartViewLargeIcon As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuPartViewDetail As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuPartViewSmallIcon As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuPartViewList As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuPartViewTile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuAGVView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuAGVViewLargeIcon As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuAGVViewDetails As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuAGVViewSmallIcon As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuAGVViewList As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuAGVViewTile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuAGVConfirmConn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuAGVConfirmSelected As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuAGVConfirmAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConfirmConnectionToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ForEndDevicesOfSelectedPartToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ForAllEndDevicesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuAGVEnable As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AndonTimer As System.Windows.Forms.Timer
    Friend WithEvents olvAGV As BrightIdeasSoftware.ObjectListView
    Friend WithEvents OlvColumnName As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumnPart As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumnWorkingType As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumnPosition As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumnStatus As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumnConnecting As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumnBattery As BrightIdeasSoftware.OLVColumn
    Friend WithEvents olvPart As BrightIdeasSoftware.ObjectListView
    Friend WithEvents OlvColumnPartGroup As BrightIdeasSoftware.OLVColumn

End Class
