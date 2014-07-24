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
		Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
		Dim ListViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("gege", System.Windows.Forms.HorizontalAlignment.Left)
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
		Me.contextMenuLstViewAGV = New System.Windows.Forms.ContextMenuStrip(Me.components)
		Me.LargeIconAGVToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.DetailsAGVToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.SmallIconAGVToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.ListAGVToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.TileAGVToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.imgAGVSmall = New System.Windows.Forms.ImageList(Me.components)
		Me.contMenuLstViewPart = New System.Windows.Forms.ContextMenuStrip(Me.components)
		Me.LargePartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.DetailPartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.SmallIconPartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.ListPartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.TilePartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.TabPage2 = New System.Windows.Forms.TabPage()
		Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
		Me.TabPage3 = New System.Windows.Forms.TabPage()
		Me.TabPage4 = New System.Windows.Forms.TabPage()
		Me.TabPage5 = New System.Windows.Forms.TabPage()
		Me.TimerDisplayAGV = New System.Windows.Forms.Timer(Me.components)
		Me.TimerDisplayPart = New System.Windows.Forms.Timer(Me.components)
		Me.imgPartBig = New System.Windows.Forms.ImageList(Me.components)
		Me.imgPartSmall = New System.Windows.Forms.ImageList(Me.components)
		Me.lstViewAGV = New System.Windows.Forms.ListView()
		Me.lstViewPart = New System.Windows.Forms.ListView()
		Me.ListView1 = New System.Windows.Forms.ListView()
		Me.VirtualAGV1 = New Control_system.VirtualAGV()
		Me.MainManu.SuspendLayout()
		Me.TabControl1.SuspendLayout()
		Me.TabPage1.SuspendLayout()
		Me.TableLayoutPanel1.SuspendLayout()
		Me.contextMenuLstViewAGV.SuspendLayout()
		Me.contMenuLstViewPart.SuspendLayout()
		Me.TabPage2.SuspendLayout()
		CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.TabPage5.SuspendLayout()
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
		Me.imgAGVBig.Images.SetKeyName(0, "0.jpg")
		Me.imgAGVBig.Images.SetKeyName(1, "1.jpg")
		Me.imgAGVBig.Images.SetKeyName(2, "2.jpg")
		Me.imgAGVBig.Images.SetKeyName(3, "3.jpg")
		Me.imgAGVBig.Images.SetKeyName(4, "4.jpg")
		Me.imgAGVBig.Images.SetKeyName(5, "5.jpg")
		Me.imgAGVBig.Images.SetKeyName(6, "6.jpg")
		Me.imgAGVBig.Images.SetKeyName(7, "7.jpg")
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
		Me.TabControl1.Size = New System.Drawing.Size(1543, 990)
		Me.TabControl1.TabIndex = 2
		'
		'TabPage1
		'
		Me.TabPage1.Controls.Add(Me.TableLayoutPanel1)
		Me.TabPage1.Location = New System.Drawing.Point(4, 22)
		Me.TabPage1.Name = "TabPage1"
		Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
		Me.TabPage1.Size = New System.Drawing.Size(1535, 964)
		Me.TabPage1.TabIndex = 0
		Me.TabPage1.Text = "Overview"
		Me.TabPage1.UseVisualStyleBackColor = True
		'
		'TableLayoutPanel1
		'
		Me.TableLayoutPanel1.ColumnCount = 2
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel1.Controls.Add(Me.lstViewPart, 1, 0)
		Me.TableLayoutPanel1.Controls.Add(Me.lstViewAGV, 0, 0)
		Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
		Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
		Me.TableLayoutPanel1.RowCount = 1
		Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
		Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 968.0!))
		Me.TableLayoutPanel1.Size = New System.Drawing.Size(1529, 968)
		Me.TableLayoutPanel1.TabIndex = 0
		'
		'contextMenuLstViewAGV
		'
		Me.contextMenuLstViewAGV.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LargeIconAGVToolStripMenuItem, Me.DetailsAGVToolStripMenuItem, Me.SmallIconAGVToolStripMenuItem, Me.ListAGVToolStripMenuItem, Me.TileAGVToolStripMenuItem})
		Me.contextMenuLstViewAGV.Name = "ContextMenuStrip1"
		Me.contextMenuLstViewAGV.Size = New System.Drawing.Size(130, 114)
		'
		'LargeIconAGVToolStripMenuItem
		'
		Me.LargeIconAGVToolStripMenuItem.Name = "LargeIconAGVToolStripMenuItem"
		Me.LargeIconAGVToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
		Me.LargeIconAGVToolStripMenuItem.Text = "Large Icon"
		'
		'DetailsAGVToolStripMenuItem
		'
		Me.DetailsAGVToolStripMenuItem.Name = "DetailsAGVToolStripMenuItem"
		Me.DetailsAGVToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
		Me.DetailsAGVToolStripMenuItem.Text = "Details"
		'
		'SmallIconAGVToolStripMenuItem
		'
		Me.SmallIconAGVToolStripMenuItem.Name = "SmallIconAGVToolStripMenuItem"
		Me.SmallIconAGVToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
		Me.SmallIconAGVToolStripMenuItem.Text = "Small icon"
		'
		'ListAGVToolStripMenuItem
		'
		Me.ListAGVToolStripMenuItem.Name = "ListAGVToolStripMenuItem"
		Me.ListAGVToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
		Me.ListAGVToolStripMenuItem.Text = "List"
		'
		'TileAGVToolStripMenuItem
		'
		Me.TileAGVToolStripMenuItem.Name = "TileAGVToolStripMenuItem"
		Me.TileAGVToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
		Me.TileAGVToolStripMenuItem.Text = "Tile"
		'
		'imgAGVSmall
		'
		Me.imgAGVSmall.ImageStream = CType(resources.GetObject("imgAGVSmall.ImageStream"), System.Windows.Forms.ImageListStreamer)
		Me.imgAGVSmall.TransparentColor = System.Drawing.Color.Transparent
		Me.imgAGVSmall.Images.SetKeyName(0, "0.jpg")
		Me.imgAGVSmall.Images.SetKeyName(1, "1.jpg")
		Me.imgAGVSmall.Images.SetKeyName(2, "2.jpg")
		Me.imgAGVSmall.Images.SetKeyName(3, "3.jpg")
		Me.imgAGVSmall.Images.SetKeyName(4, "4.jpg")
		Me.imgAGVSmall.Images.SetKeyName(5, "5.jpg")
		Me.imgAGVSmall.Images.SetKeyName(6, "6.jpg")
		Me.imgAGVSmall.Images.SetKeyName(7, "7.jpg")
		'
		'contMenuLstViewPart
		'
		Me.contMenuLstViewPart.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LargePartToolStripMenuItem, Me.DetailPartToolStripMenuItem, Me.SmallIconPartToolStripMenuItem, Me.ListPartToolStripMenuItem, Me.TilePartToolStripMenuItem})
		Me.contMenuLstViewPart.Name = "contMenuListViewPart"
		Me.contMenuLstViewPart.Size = New System.Drawing.Size(130, 114)
		'
		'LargePartToolStripMenuItem
		'
		Me.LargePartToolStripMenuItem.Name = "LargePartToolStripMenuItem"
		Me.LargePartToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
		Me.LargePartToolStripMenuItem.Text = "Large Icon"
		'
		'DetailPartToolStripMenuItem
		'
		Me.DetailPartToolStripMenuItem.Name = "DetailPartToolStripMenuItem"
		Me.DetailPartToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
		Me.DetailPartToolStripMenuItem.Text = "Detail"
		'
		'SmallIconPartToolStripMenuItem
		'
		Me.SmallIconPartToolStripMenuItem.Name = "SmallIconPartToolStripMenuItem"
		Me.SmallIconPartToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
		Me.SmallIconPartToolStripMenuItem.Text = "Small icon"
		'
		'ListPartToolStripMenuItem
		'
		Me.ListPartToolStripMenuItem.Name = "ListPartToolStripMenuItem"
		Me.ListPartToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
		Me.ListPartToolStripMenuItem.Text = "List"
		'
		'TilePartToolStripMenuItem
		'
		Me.TilePartToolStripMenuItem.Name = "TilePartToolStripMenuItem"
		Me.TilePartToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
		Me.TilePartToolStripMenuItem.Text = "Tile"
		'
		'TabPage2
		'
		Me.TabPage2.Controls.Add(Me.Chart1)
		Me.TabPage2.Location = New System.Drawing.Point(4, 22)
		Me.TabPage2.Name = "TabPage2"
		Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
		Me.TabPage2.Size = New System.Drawing.Size(1535, 964)
		Me.TabPage2.TabIndex = 1
		Me.TabPage2.Text = "AGV performent"
		Me.TabPage2.UseVisualStyleBackColor = True
		'
		'Chart1
		'
		ChartArea1.Name = "ChartArea1"
		Me.Chart1.ChartAreas.Add(ChartArea1)
		Legend1.Name = "Legend1"
		Me.Chart1.Legends.Add(Legend1)
		Me.Chart1.Location = New System.Drawing.Point(6, 6)
		Me.Chart1.Name = "Chart1"
		Series1.ChartArea = "ChartArea1"
		Series1.Legend = "Legend1"
		Series1.Name = "Series1"
		Me.Chart1.Series.Add(Series1)
		Me.Chart1.Size = New System.Drawing.Size(1875, 952)
		Me.Chart1.TabIndex = 0
		Me.Chart1.Text = "Chart1"
		'
		'TabPage3
		'
		Me.TabPage3.Location = New System.Drawing.Point(4, 22)
		Me.TabPage3.Name = "TabPage3"
		Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
		Me.TabPage3.Size = New System.Drawing.Size(1535, 964)
		Me.TabPage3.TabIndex = 2
		Me.TabPage3.Text = "Map"
		Me.TabPage3.UseVisualStyleBackColor = True
		'
		'TabPage4
		'
		Me.TabPage4.Location = New System.Drawing.Point(4, 22)
		Me.TabPage4.Name = "TabPage4"
		Me.TabPage4.Size = New System.Drawing.Size(1535, 964)
		Me.TabPage4.TabIndex = 3
		Me.TabPage4.Text = "History"
		Me.TabPage4.UseVisualStyleBackColor = True
		'
		'TabPage5
		'
		Me.TabPage5.Controls.Add(Me.ListView1)
		Me.TabPage5.Location = New System.Drawing.Point(4, 22)
		Me.TabPage5.Name = "TabPage5"
		Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
		Me.TabPage5.Size = New System.Drawing.Size(1535, 964)
		Me.TabPage5.TabIndex = 4
		Me.TabPage5.Text = "Test"
		Me.TabPage5.UseVisualStyleBackColor = True
		'
		'TimerDisplayAGV
		'
		Me.TimerDisplayAGV.Interval = 500
		'
		'TimerDisplayPart
		'
		Me.TimerDisplayPart.Interval = 500
		'
		'imgPartBig
		'
		Me.imgPartBig.ImageStream = CType(resources.GetObject("imgPartBig.ImageStream"), System.Windows.Forms.ImageListStreamer)
		Me.imgPartBig.TransparentColor = System.Drawing.Color.Transparent
		Me.imgPartBig.Images.SetKeyName(0, "0.jpg")
		Me.imgPartBig.Images.SetKeyName(1, "1.jpg")
		'
		'imgPartSmall
		'
		Me.imgPartSmall.ImageStream = CType(resources.GetObject("imgPartSmall.ImageStream"), System.Windows.Forms.ImageListStreamer)
		Me.imgPartSmall.TransparentColor = System.Drawing.Color.Transparent
		Me.imgPartSmall.Images.SetKeyName(0, "0.jpg")
		Me.imgPartSmall.Images.SetKeyName(1, "1.jpg")
		'
		'lstViewAGV
		'
		Me.lstViewAGV.ContextMenuStrip = Me.contextMenuLstViewAGV
		Me.lstViewAGV.Dock = System.Windows.Forms.DockStyle.Fill
		Me.lstViewAGV.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lstViewAGV.FullRowSelect = True
		Me.lstViewAGV.LargeImageList = Me.imgAGVBig
		Me.lstViewAGV.Location = New System.Drawing.Point(3, 3)
		Me.lstViewAGV.Name = "lstViewAGV"
		Me.lstViewAGV.Size = New System.Drawing.Size(758, 962)
		Me.lstViewAGV.SmallImageList = Me.imgAGVSmall
		Me.lstViewAGV.TabIndex = 2
		Me.lstViewAGV.TileSize = New System.Drawing.Size(250, 150)
		Me.lstViewAGV.UseCompatibleStateImageBehavior = False
		Me.lstViewAGV.View = System.Windows.Forms.View.Tile
		'
		'lstViewPart
		'
		Me.lstViewPart.ContextMenuStrip = Me.contMenuLstViewPart
		Me.lstViewPart.Dock = System.Windows.Forms.DockStyle.Fill
		Me.lstViewPart.LargeImageList = Me.imgPartBig
		Me.lstViewPart.Location = New System.Drawing.Point(767, 3)
		Me.lstViewPart.Name = "lstViewPart"
		Me.lstViewPart.Size = New System.Drawing.Size(759, 962)
		Me.lstViewPart.SmallImageList = Me.imgPartSmall
		Me.lstViewPart.TabIndex = 3
		Me.lstViewPart.UseCompatibleStateImageBehavior = False
		'
		'ListView1
		'
		ListViewGroup1.Header = "gege"
		ListViewGroup1.Name = "ListViewGroup1"
		Me.ListView1.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup1})
		Me.ListView1.Location = New System.Drawing.Point(73, 252)
		Me.ListView1.Name = "ListView1"
		Me.ListView1.Size = New System.Drawing.Size(121, 97)
		Me.ListView1.TabIndex = 0
		Me.ListView1.UseCompatibleStateImageBehavior = False
		'
		'VirtualAGV1
		'
		Me.VirtualAGV1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.VirtualAGV1.Location = New System.Drawing.Point(1561, 46)
		Me.VirtualAGV1.Name = "VirtualAGV1"
		Me.VirtualAGV1.Size = New System.Drawing.Size(269, 204)
		Me.VirtualAGV1.TabIndex = 3
		'
		'MainForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(1904, 1042)
		Me.Controls.Add(Me.VirtualAGV1)
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
		Me.contextMenuLstViewAGV.ResumeLayout(False)
		Me.contMenuLstViewPart.ResumeLayout(False)
		Me.TabPage2.ResumeLayout(False)
		CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.TabPage5.ResumeLayout(False)
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
	Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
	Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
	Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
	Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
	Friend WithEvents imgAGVSmall As System.Windows.Forms.ImageList
	Friend WithEvents contextMenuLstViewAGV As System.Windows.Forms.ContextMenuStrip
	Friend WithEvents LargeIconAGVToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents DetailsAGVToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents SmallIconAGVToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ListAGVToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents TileAGVToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents TimerDisplayAGV As System.Windows.Forms.Timer
	Friend WithEvents VirtualAGV1 As Control_system.VirtualAGV
	Friend WithEvents contMenuLstViewPart As System.Windows.Forms.ContextMenuStrip
	Friend WithEvents LargePartToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents DetailPartToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents SmallIconPartToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ListPartToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents TilePartToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents TimerDisplayPart As System.Windows.Forms.Timer
	Friend WithEvents imgPartBig As System.Windows.Forms.ImageList
	Friend WithEvents imgPartSmall As System.Windows.Forms.ImageList
	Friend WithEvents lstViewPart As System.Windows.Forms.ListView
	Friend WithEvents lstViewAGV As System.Windows.Forms.ListView
	Friend WithEvents ListView1 As System.Windows.Forms.ListView

End Class
