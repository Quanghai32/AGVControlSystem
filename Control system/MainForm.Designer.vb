<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Title1 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Me.MainMenu = New System.Windows.Forms.MenuStrip()
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
        Me.ShowAllCardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowAllCardToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ForceUploadToServerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MainMenuSetting = New System.Windows.Forms.ToolStripMenuItem()
        Me.DebugModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IndexToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RequestFormToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CrossViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DebugFormToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DisplayPartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MainStatus = New System.Windows.Forms.StatusStrip()
        Me.imgAGVBig = New System.Windows.Forms.ImageList(Me.components)
        Me.MainTabControl = New System.Windows.Forms.TabControl()
        Me.TabMainForm = New System.Windows.Forms.TabPage()
        Me.SplitContainerOverView = New System.Windows.Forms.SplitContainer()
        Me.olvAGV = New BrightIdeasSoftware.ObjectListView()
        Me.OlvColumnGroup = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnName = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnPart = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnWorkingType = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnPosition = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnStatus = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnConnecting = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnBattery = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.MenuLstViewAGV = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuAGVView = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuAGVViewSmallIcon = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuAGVViewTile = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuAGVConfirmConn = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuAGVConfirmSelected = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuAGVConfirmAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuAGVEnable = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VitualAGVToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RunToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.olvPart = New BrightIdeasSoftware.ObjectListView()
        Me.OlvColumnPartGroup = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnPartName = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnPartStatus = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnPartConnecting = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnPartEmptyTime = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnPartAGVSupply = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.MenuLstViewPart = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuPartView = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuPartViewSmallIcon = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuPartViewTile = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuPartConfirmConn = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuPartConfirmSelected = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuPartConfirmAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.DisableEndDeviceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuPartEnable = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadPartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VitualPartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabChart = New System.Windows.Forms.TabPage()
        Me.panelDetail = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelAgvDetail = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.LabelTotal = New System.Windows.Forms.Label()
        Me.LabelShutdown = New System.Windows.Forms.Label()
        Me.LabelDisconnect = New System.Windows.Forms.Label()
        Me.LabelNormal = New System.Windows.Forms.Label()
        Me.LabelStop = New System.Windows.Forms.Label()
        Me.LabelFree = New System.Windows.Forms.Label()
        Me.LabelSafety = New System.Windows.Forms.Label()
        Me.LabelEMG = New System.Windows.Forms.Label()
        Me.LabelNoCart = New System.Windows.Forms.Label()
        Me.LabelBatteryLow = New System.Windows.Forms.Label()
        Me.LabelPoleErr = New System.Windows.Forms.Label()
        Me.LabelOutLine = New System.Windows.Forms.Label()
        Me.agvChart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TabMap = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TablePanel_Header = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonFindAGV = New System.Windows.Forms.Button()
        Me.PanelAlarm = New System.Windows.Forms.Panel()
        Me.LabelAlarm = New System.Windows.Forms.Label()
        Me.labelMapName = New System.Windows.Forms.Label()
        Me.Panel_Appendix = New System.Windows.Forms.TableLayoutPanel()
        Me.Label_YellowDetail = New System.Windows.Forms.Label()
        Me.Label_Green = New System.Windows.Forms.Label()
        Me.Label_VioletDetail = New System.Windows.Forms.Label()
        Me.Label_Gray = New System.Windows.Forms.Label()
        Me.Label_RedDetail = New System.Windows.Forms.Label()
        Me.Label_Violet = New System.Windows.Forms.Label()
        Me.Label_Yellow = New System.Windows.Forms.Label()
        Me.Label_GreenDetail = New System.Windows.Forms.Label()
        Me.Label_Aqua = New System.Windows.Forms.Label()
        Me.Label_GrayDetail = New System.Windows.Forms.Label()
        Me.Label_Red = New System.Windows.Forms.Label()
        Me.Label_AquaDetail = New System.Windows.Forms.Label()
        Me.Panel_Map = New System.Windows.Forms.Panel()
        Me.LabelCardNotExit = New System.Windows.Forms.Label()
        Me.PictureBoxMap = New System.Windows.Forms.PictureBox()
        Me.ContextMenuMap = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AlignCenterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AligToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabLog = New System.Windows.Forms.TabPage()
        Me.imgPartBig = New System.Windows.Forms.ImageList(Me.components)
        Me.imgPartSmall = New System.Windows.Forms.ImageList(Me.components)
        Me.imgAGVSmall = New System.Windows.Forms.ImageList(Me.components)
        Me.DisplayTimer = New System.Windows.Forms.Timer(Me.components)
        Me.CrossTimer = New System.Windows.Forms.Timer(Me.components)
        Me.AutoSaveTimer = New System.Windows.Forms.Timer(Me.components)
        Me.RecordTimer = New System.Windows.Forms.Timer(Me.components)
        Me.AndonTimer = New System.Windows.Forms.Timer(Me.components)
        Me.TimerAndonMap = New System.Windows.Forms.Timer(Me.components)
        Me.RequestDataTimer = New System.Windows.Forms.Timer(Me.components)
        Me.MainMenu.SuspendLayout()
        Me.MainTabControl.SuspendLayout()
        Me.TabMainForm.SuspendLayout()
        CType(Me.SplitContainerOverView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerOverView.Panel1.SuspendLayout()
        Me.SplitContainerOverView.Panel2.SuspendLayout()
        Me.SplitContainerOverView.SuspendLayout()
        CType(Me.olvAGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuLstViewAGV.SuspendLayout()
        CType(Me.olvPart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuLstViewPart.SuspendLayout()
        Me.TabChart.SuspendLayout()
        Me.panelDetail.SuspendLayout()
        CType(Me.agvChart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabMap.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TablePanel_Header.SuspendLayout()
        Me.PanelAlarm.SuspendLayout()
        Me.Panel_Appendix.SuspendLayout()
        Me.Panel_Map.SuspendLayout()
        CType(Me.PictureBoxMap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuMap.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenu
        '
        Me.MainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.HelpToolStripMenuItem1, Me.ViewToolStripMenuItem})
        Me.MainMenu.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu.Margin = New System.Windows.Forms.Padding(0, 0, 20, 0)
        Me.MainMenu.Name = "MainMenu"
        Me.MainMenu.Padding = New System.Windows.Forms.Padding(6, 2, 10, 2)
        Me.MainMenu.Size = New System.Drawing.Size(882, 24)
        Me.MainMenu.TabIndex = 0
        Me.MainMenu.Text = "MenuStrip1"
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
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CustomizeToolStripMenuItem, Me.OptionsToolStripMenuItem, Me.MainMenuSetting, Me.DebugModeToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.ToolsToolStripMenuItem.Text = "&Tools"
        '
        'CustomizeToolStripMenuItem
        '
        Me.CustomizeToolStripMenuItem.Name = "CustomizeToolStripMenuItem"
        Me.CustomizeToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.CustomizeToolStripMenuItem.Text = "Enable edit map"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowAllCardToolStripMenuItem, Me.ShowAllCardToolStripMenuItem1, Me.ForceUploadToServerToolStripMenuItem})
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.OptionsToolStripMenuItem.Text = "&Options"
        '
        'ShowAllCardToolStripMenuItem
        '
        Me.ShowAllCardToolStripMenuItem.Name = "ShowAllCardToolStripMenuItem"
        Me.ShowAllCardToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.D1), System.Windows.Forms.Keys)
        Me.ShowAllCardToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.ShowAllCardToolStripMenuItem.Text = "Show Setting"
        '
        'ShowAllCardToolStripMenuItem1
        '
        Me.ShowAllCardToolStripMenuItem1.Name = "ShowAllCardToolStripMenuItem1"
        Me.ShowAllCardToolStripMenuItem1.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.D2), System.Windows.Forms.Keys)
        Me.ShowAllCardToolStripMenuItem1.Size = New System.Drawing.Size(192, 22)
        Me.ShowAllCardToolStripMenuItem1.Text = "Show all card"
        '
        'ForceUploadToServerToolStripMenuItem
        '
        Me.ForceUploadToServerToolStripMenuItem.Name = "ForceUploadToServerToolStripMenuItem"
        Me.ForceUploadToServerToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.ForceUploadToServerToolStripMenuItem.Text = "Force upload to Server"
        '
        'MainMenuSetting
        '
        Me.MainMenuSetting.Name = "MainMenuSetting"
        Me.MainMenuSetting.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.MainMenuSetting.Size = New System.Drawing.Size(181, 22)
        Me.MainMenuSetting.Text = "Setting"
        '
        'DebugModeToolStripMenuItem
        '
        Me.DebugModeToolStripMenuItem.Name = "DebugModeToolStripMenuItem"
        Me.DebugModeToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.DebugModeToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.DebugModeToolStripMenuItem.Text = "Debug mode"
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
        Me.ContentsToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.ContentsToolStripMenuItem.Text = "&Contents"
        '
        'IndexToolStripMenuItem
        '
        Me.IndexToolStripMenuItem.Name = "IndexToolStripMenuItem"
        Me.IndexToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.IndexToolStripMenuItem.Text = "&Index"
        '
        'SearchToolStripMenuItem
        '
        Me.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem"
        Me.SearchToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.SearchToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.SearchToolStripMenuItem.Text = "&Search"
        '
        'toolStripSeparator5
        '
        Me.toolStripSeparator5.Name = "toolStripSeparator5"
        Me.toolStripSeparator5.Size = New System.Drawing.Size(146, 6)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.AboutToolStripMenuItem.Text = "&About..."
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RequestFormToolStripMenuItem, Me.CrossViewToolStripMenuItem, Me.DebugFormToolStripMenuItem1, Me.DisplayPartToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'RequestFormToolStripMenuItem
        '
        Me.RequestFormToolStripMenuItem.Name = "RequestFormToolStripMenuItem"
        Me.RequestFormToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.RequestFormToolStripMenuItem.Text = "Request form"
        '
        'CrossViewToolStripMenuItem
        '
        Me.CrossViewToolStripMenuItem.Name = "CrossViewToolStripMenuItem"
        Me.CrossViewToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.CrossViewToolStripMenuItem.Text = "Cross view"
        '
        'DebugFormToolStripMenuItem1
        '
        Me.DebugFormToolStripMenuItem1.Name = "DebugFormToolStripMenuItem1"
        Me.DebugFormToolStripMenuItem1.Size = New System.Drawing.Size(145, 22)
        Me.DebugFormToolStripMenuItem1.Text = "Catch log"
        '
        'DisplayPartToolStripMenuItem
        '
        Me.DisplayPartToolStripMenuItem.Name = "DisplayPartToolStripMenuItem"
        Me.DisplayPartToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.DisplayPartToolStripMenuItem.Text = "Display part"
        '
        'MainStatus
        '
        Me.MainStatus.Location = New System.Drawing.Point(0, 434)
        Me.MainStatus.Name = "MainStatus"
        Me.MainStatus.Size = New System.Drawing.Size(882, 22)
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
        'MainTabControl
        '
        Me.MainTabControl.Controls.Add(Me.TabMainForm)
        Me.MainTabControl.Controls.Add(Me.TabChart)
        Me.MainTabControl.Controls.Add(Me.TabMap)
        Me.MainTabControl.Controls.Add(Me.TabLog)
        Me.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainTabControl.Location = New System.Drawing.Point(0, 24)
        Me.MainTabControl.Name = "MainTabControl"
        Me.MainTabControl.SelectedIndex = 0
        Me.MainTabControl.Size = New System.Drawing.Size(882, 410)
        Me.MainTabControl.TabIndex = 2
        '
        'TabMainForm
        '
        Me.TabMainForm.Controls.Add(Me.SplitContainerOverView)
        Me.TabMainForm.Location = New System.Drawing.Point(4, 22)
        Me.TabMainForm.Name = "TabMainForm"
        Me.TabMainForm.Padding = New System.Windows.Forms.Padding(3)
        Me.TabMainForm.Size = New System.Drawing.Size(874, 384)
        Me.TabMainForm.TabIndex = 0
        Me.TabMainForm.Text = "Overview"
        Me.TabMainForm.UseVisualStyleBackColor = True
        '
        'SplitContainerOverView
        '
        Me.SplitContainerOverView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerOverView.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainerOverView.Name = "SplitContainerOverView"
        '
        'SplitContainerOverView.Panel1
        '
        Me.SplitContainerOverView.Panel1.Controls.Add(Me.olvAGV)
        '
        'SplitContainerOverView.Panel2
        '
        Me.SplitContainerOverView.Panel2.Controls.Add(Me.olvPart)
        Me.SplitContainerOverView.Size = New System.Drawing.Size(868, 378)
        Me.SplitContainerOverView.SplitterDistance = 425
        Me.SplitContainerOverView.TabIndex = 0
        '
        'olvAGV
        '
        Me.olvAGV.AllColumns.Add(Me.OlvColumnGroup)
        Me.olvAGV.AllColumns.Add(Me.OlvColumnName)
        Me.olvAGV.AllColumns.Add(Me.OlvColumnPart)
        Me.olvAGV.AllColumns.Add(Me.OlvColumnWorkingType)
        Me.olvAGV.AllColumns.Add(Me.OlvColumnPosition)
        Me.olvAGV.AllColumns.Add(Me.OlvColumnStatus)
        Me.olvAGV.AllColumns.Add(Me.OlvColumnConnecting)
        Me.olvAGV.AllColumns.Add(Me.OlvColumnBattery)
        Me.olvAGV.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumnGroup, Me.OlvColumnName, Me.OlvColumnPart, Me.OlvColumnWorkingType, Me.OlvColumnPosition, Me.OlvColumnStatus, Me.OlvColumnConnecting, Me.OlvColumnBattery})
        Me.olvAGV.ContextMenuStrip = Me.MenuLstViewAGV
        Me.olvAGV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.olvAGV.FullRowSelect = True
        Me.olvAGV.GridLines = True
        Me.olvAGV.Location = New System.Drawing.Point(0, 0)
        Me.olvAGV.Name = "olvAGV"
        Me.olvAGV.Size = New System.Drawing.Size(425, 378)
        Me.olvAGV.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.olvAGV.TabIndex = 7
        Me.olvAGV.TileSize = New System.Drawing.Size(300, 100)
        Me.olvAGV.UseCompatibleStateImageBehavior = False
        Me.olvAGV.UseTranslucentSelection = True
        Me.olvAGV.View = System.Windows.Forms.View.Details
        '
        'OlvColumnGroup
        '
        Me.OlvColumnGroup.AspectName = "Group"
        Me.OlvColumnGroup.CellPadding = Nothing
        Me.OlvColumnGroup.IsTileViewColumn = True
        Me.OlvColumnGroup.Text = "Group"
        '
        'OlvColumnName
        '
        Me.OlvColumnName.AspectName = "Name"
        Me.OlvColumnName.CellPadding = Nothing
        Me.OlvColumnName.Groupable = False
        Me.OlvColumnName.Text = "Name"
        Me.OlvColumnName.UseFiltering = False
        '
        'OlvColumnPart
        '
        Me.OlvColumnPart.AspectName = "SupplyPartStatus"
        Me.OlvColumnPart.CellPadding = Nothing
        Me.OlvColumnPart.IsTileViewColumn = True
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
        Me.OlvColumnStatus.IsTileViewColumn = True
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
        Me.MenuLstViewAGV.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuAGVView, Me.MenuAGVConfirmConn, Me.MenuAGVEnable, Me.LoadDataToolStripMenuItem, Me.VitualAGVToolStripMenuItem, Me.TestToolStripMenuItem})
        Me.MenuLstViewAGV.Name = "ContextMenuStrip1"
        Me.MenuLstViewAGV.Size = New System.Drawing.Size(182, 136)
        '
        'MenuAGVView
        '
        Me.MenuAGVView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuAGVViewSmallIcon, Me.MenuAGVViewTile})
        Me.MenuAGVView.Name = "MenuAGVView"
        Me.MenuAGVView.Size = New System.Drawing.Size(181, 22)
        Me.MenuAGVView.Text = "View"
        '
        'MenuAGVViewSmallIcon
        '
        Me.MenuAGVViewSmallIcon.Name = "MenuAGVViewSmallIcon"
        Me.MenuAGVViewSmallIcon.Size = New System.Drawing.Size(129, 22)
        Me.MenuAGVViewSmallIcon.Text = "Small Icon"
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
        'LoadDataToolStripMenuItem
        '
        Me.LoadDataToolStripMenuItem.Name = "LoadDataToolStripMenuItem"
        Me.LoadDataToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.LoadDataToolStripMenuItem.Text = "Load channel"
        '
        'VitualAGVToolStripMenuItem
        '
        Me.VitualAGVToolStripMenuItem.Name = "VitualAGVToolStripMenuItem"
        Me.VitualAGVToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.VitualAGVToolStripMenuItem.Text = "Vitual AGV"
        '
        'TestToolStripMenuItem
        '
        Me.TestToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RunToolStripMenuItem, Me.StopToolStripMenuItem})
        Me.TestToolStripMenuItem.Name = "TestToolStripMenuItem"
        Me.TestToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.TestToolStripMenuItem.Text = "Test"
        '
        'RunToolStripMenuItem
        '
        Me.RunToolStripMenuItem.Name = "RunToolStripMenuItem"
        Me.RunToolStripMenuItem.Size = New System.Drawing.Size(98, 22)
        Me.RunToolStripMenuItem.Text = "Run"
        '
        'StopToolStripMenuItem
        '
        Me.StopToolStripMenuItem.Name = "StopToolStripMenuItem"
        Me.StopToolStripMenuItem.Size = New System.Drawing.Size(98, 22)
        Me.StopToolStripMenuItem.Text = "Stop"
        '
        'olvPart
        '
        Me.olvPart.AllColumns.Add(Me.OlvColumnPartGroup)
        Me.olvPart.AllColumns.Add(Me.OlvColumnPartName)
        Me.olvPart.AllColumns.Add(Me.OlvColumnPartStatus)
        Me.olvPart.AllColumns.Add(Me.OlvColumnPartConnecting)
        Me.olvPart.AllColumns.Add(Me.OlvColumnPartEmptyTime)
        Me.olvPart.AllColumns.Add(Me.OlvColumnPartAGVSupply)
        Me.olvPart.AllColumns.Add(Me.OlvColumn)
        Me.olvPart.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumnPartGroup, Me.OlvColumnPartName, Me.OlvColumnPartStatus, Me.OlvColumnPartConnecting, Me.OlvColumnPartEmptyTime, Me.OlvColumnPartAGVSupply, Me.OlvColumn})
        Me.olvPart.ContextMenuStrip = Me.MenuLstViewPart
        Me.olvPart.Dock = System.Windows.Forms.DockStyle.Fill
        Me.olvPart.FullRowSelect = True
        Me.olvPart.GridLines = True
        Me.olvPart.HeaderUsesThemes = False
        Me.olvPart.Location = New System.Drawing.Point(0, 0)
        Me.olvPart.Name = "olvPart"
        Me.olvPart.SelectedColumnTint = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.olvPart.Size = New System.Drawing.Size(439, 378)
        Me.olvPart.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.olvPart.TabIndex = 8
        Me.olvPart.TileSize = New System.Drawing.Size(230, 100)
        Me.olvPart.TintSortColumn = True
        Me.olvPart.UseCompatibleStateImageBehavior = False
        Me.olvPart.UseTranslucentSelection = True
        Me.olvPart.View = System.Windows.Forms.View.Details
        '
        'OlvColumnPartGroup
        '
        Me.OlvColumnPartGroup.AspectName = "group"
        Me.OlvColumnPartGroup.CellPadding = Nothing
        Me.OlvColumnPartGroup.IsTileViewColumn = True
        Me.OlvColumnPartGroup.Text = "Line"
        '
        'OlvColumnPartName
        '
        Me.OlvColumnPartName.AspectName = "Name"
        Me.OlvColumnPartName.CellPadding = Nothing
        Me.OlvColumnPartName.CheckBoxes = True
        Me.OlvColumnPartName.Text = "Name"
        '
        'OlvColumnPartStatus
        '
        Me.OlvColumnPartStatus.AspectName = "Status"
        Me.OlvColumnPartStatus.CellPadding = Nothing
        Me.OlvColumnPartStatus.Text = "Status"
        '
        'OlvColumnPartConnecting
        '
        Me.OlvColumnPartConnecting.AspectName = "connecting"
        Me.OlvColumnPartConnecting.CellPadding = Nothing
        Me.OlvColumnPartConnecting.Text = "Connection"
        Me.OlvColumnPartConnecting.Width = 77
        '
        'OlvColumnPartEmptyTime
        '
        Me.OlvColumnPartEmptyTime.AspectName = "EmptyTime"
        Me.OlvColumnPartEmptyTime.CellPadding = Nothing
        Me.OlvColumnPartEmptyTime.Text = "Empty time"
        '
        'OlvColumnPartAGVSupply
        '
        Me.OlvColumnPartAGVSupply.AspectName = "AGVSupply"
        Me.OlvColumnPartAGVSupply.CellPadding = Nothing
        Me.OlvColumnPartAGVSupply.Text = "AGV Supply"
        '
        'OlvColumn
        '
        Me.OlvColumn.AspectName = "PalletNo"
        Me.OlvColumn.CellPadding = Nothing
        '
        'MenuLstViewPart
        '
        Me.MenuLstViewPart.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuPartView, Me.MenuPartConfirmConn, Me.MenuPartEnable, Me.LoadPartToolStripMenuItem, Me.VitualPartToolStripMenuItem, Me.EditToolStripMenuItem1})
        Me.MenuLstViewPart.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.MenuLstViewPart.Name = "contMenuListViewPart"
        Me.MenuLstViewPart.Size = New System.Drawing.Size(182, 136)
        '
        'MenuPartView
        '
        Me.MenuPartView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuPartViewSmallIcon, Me.MenuPartViewTile})
        Me.MenuPartView.Name = "MenuPartView"
        Me.MenuPartView.Size = New System.Drawing.Size(181, 22)
        Me.MenuPartView.Text = "View"
        '
        'MenuPartViewSmallIcon
        '
        Me.MenuPartViewSmallIcon.Name = "MenuPartViewSmallIcon"
        Me.MenuPartViewSmallIcon.Size = New System.Drawing.Size(129, 22)
        Me.MenuPartViewSmallIcon.Text = "Small icon"
        '
        'MenuPartViewTile
        '
        Me.MenuPartViewTile.Name = "MenuPartViewTile"
        Me.MenuPartViewTile.Size = New System.Drawing.Size(129, 22)
        Me.MenuPartViewTile.Text = "Tile"
        '
        'MenuPartConfirmConn
        '
        Me.MenuPartConfirmConn.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuPartConfirmSelected, Me.MenuPartConfirmAll, Me.DisableEndDeviceToolStripMenuItem})
        Me.MenuPartConfirmConn.Name = "MenuPartConfirmConn"
        Me.MenuPartConfirmConn.Size = New System.Drawing.Size(181, 22)
        Me.MenuPartConfirmConn.Text = "Confirm connection"
        '
        'MenuPartConfirmSelected
        '
        Me.MenuPartConfirmSelected.Name = "MenuPartConfirmSelected"
        Me.MenuPartConfirmSelected.Size = New System.Drawing.Size(238, 22)
        Me.MenuPartConfirmSelected.Text = "For EndDevices of selected part"
        '
        'MenuPartConfirmAll
        '
        Me.MenuPartConfirmAll.Name = "MenuPartConfirmAll"
        Me.MenuPartConfirmAll.Size = New System.Drawing.Size(238, 22)
        Me.MenuPartConfirmAll.Text = "For all EndDevices"
        '
        'DisableEndDeviceToolStripMenuItem
        '
        Me.DisableEndDeviceToolStripMenuItem.Name = "DisableEndDeviceToolStripMenuItem"
        Me.DisableEndDeviceToolStripMenuItem.Size = New System.Drawing.Size(238, 22)
        Me.DisableEndDeviceToolStripMenuItem.Text = "Disable EndDevice"
        '
        'MenuPartEnable
        '
        Me.MenuPartEnable.Name = "MenuPartEnable"
        Me.MenuPartEnable.Size = New System.Drawing.Size(181, 22)
        Me.MenuPartEnable.Text = "Enable"
        '
        'LoadPartToolStripMenuItem
        '
        Me.LoadPartToolStripMenuItem.Name = "LoadPartToolStripMenuItem"
        Me.LoadPartToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.LoadPartToolStripMenuItem.Text = "Load channel"
        '
        'VitualPartToolStripMenuItem
        '
        Me.VitualPartToolStripMenuItem.Name = "VitualPartToolStripMenuItem"
        Me.VitualPartToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.VitualPartToolStripMenuItem.Text = "Vitual part"
        '
        'EditToolStripMenuItem1
        '
        Me.EditToolStripMenuItem1.Name = "EditToolStripMenuItem1"
        Me.EditToolStripMenuItem1.Size = New System.Drawing.Size(181, 22)
        Me.EditToolStripMenuItem1.Text = "Edit"
        '
        'TabChart
        '
        Me.TabChart.Controls.Add(Me.panelDetail)
        Me.TabChart.Controls.Add(Me.agvChart)
        Me.TabChart.Location = New System.Drawing.Point(4, 22)
        Me.TabChart.Name = "TabChart"
        Me.TabChart.Padding = New System.Windows.Forms.Padding(3)
        Me.TabChart.Size = New System.Drawing.Size(874, 384)
        Me.TabChart.TabIndex = 1
        Me.TabChart.Text = "AGV performent"
        Me.TabChart.UseVisualStyleBackColor = True
        '
        'panelDetail
        '
        Me.panelDetail.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelDetail.BackColor = System.Drawing.Color.LightGray
        Me.panelDetail.ColumnCount = 2
        Me.panelDetail.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.panelDetail.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67.0!))
        Me.panelDetail.Controls.Add(Me.LabelAgvDetail, 0, 0)
        Me.panelDetail.Controls.Add(Me.Label2, 0, 1)
        Me.panelDetail.Controls.Add(Me.Label3, 0, 2)
        Me.panelDetail.Controls.Add(Me.Label4, 0, 3)
        Me.panelDetail.Controls.Add(Me.Label5, 0, 4)
        Me.panelDetail.Controls.Add(Me.Label6, 0, 5)
        Me.panelDetail.Controls.Add(Me.Label7, 0, 6)
        Me.panelDetail.Controls.Add(Me.Label8, 0, 7)
        Me.panelDetail.Controls.Add(Me.Label9, 0, 8)
        Me.panelDetail.Controls.Add(Me.Label10, 0, 9)
        Me.panelDetail.Controls.Add(Me.Label11, 0, 10)
        Me.panelDetail.Controls.Add(Me.Label12, 0, 11)
        Me.panelDetail.Controls.Add(Me.LabelTotal, 1, 0)
        Me.panelDetail.Controls.Add(Me.LabelShutdown, 1, 1)
        Me.panelDetail.Controls.Add(Me.LabelDisconnect, 1, 2)
        Me.panelDetail.Controls.Add(Me.LabelNormal, 1, 3)
        Me.panelDetail.Controls.Add(Me.LabelStop, 1, 4)
        Me.panelDetail.Controls.Add(Me.LabelFree, 1, 5)
        Me.panelDetail.Controls.Add(Me.LabelSafety, 1, 6)
        Me.panelDetail.Controls.Add(Me.LabelEMG, 1, 7)
        Me.panelDetail.Controls.Add(Me.LabelNoCart, 1, 8)
        Me.panelDetail.Controls.Add(Me.LabelBatteryLow, 1, 9)
        Me.panelDetail.Controls.Add(Me.LabelPoleErr, 1, 10)
        Me.panelDetail.Controls.Add(Me.LabelOutLine, 1, 11)
        Me.panelDetail.Location = New System.Drawing.Point(579, 138)
        Me.panelDetail.Name = "panelDetail"
        Me.panelDetail.RowCount = 14
        Me.panelDetail.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.panelDetail.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.panelDetail.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.panelDetail.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.panelDetail.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.panelDetail.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.panelDetail.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.panelDetail.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.panelDetail.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.panelDetail.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.panelDetail.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.panelDetail.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.panelDetail.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.panelDetail.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.panelDetail.Size = New System.Drawing.Size(137, 243)
        Me.panelDetail.TabIndex = 1
        '
        'LabelAgvDetail
        '
        Me.LabelAgvDetail.AutoSize = True
        Me.LabelAgvDetail.Location = New System.Drawing.Point(3, 0)
        Me.LabelAgvDetail.Name = "LabelAgvDetail"
        Me.LabelAgvDetail.Size = New System.Drawing.Size(0, 13)
        Me.LabelAgvDetail.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Shut down"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Disconnect"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Normal"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Stop"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 100)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(28, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Free"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 120)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Safety"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 140)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "EMG"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(3, 160)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "No cart"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 180)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 13)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Battery low"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(3, 200)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(52, 13)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Pole error"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(3, 220)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(43, 13)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "Out line"
        '
        'LabelTotal
        '
        Me.LabelTotal.AutoSize = True
        Me.LabelTotal.Location = New System.Drawing.Point(73, 0)
        Me.LabelTotal.Name = "LabelTotal"
        Me.LabelTotal.Size = New System.Drawing.Size(27, 13)
        Me.LabelTotal.TabIndex = 12
        Me.LabelTotal.Text = "total"
        '
        'LabelShutdown
        '
        Me.LabelShutdown.AutoSize = True
        Me.LabelShutdown.Location = New System.Drawing.Point(73, 20)
        Me.LabelShutdown.Name = "LabelShutdown"
        Me.LabelShutdown.Size = New System.Drawing.Size(53, 13)
        Me.LabelShutdown.TabIndex = 13
        Me.LabelShutdown.Text = "shutdown"
        '
        'LabelDisconnect
        '
        Me.LabelDisconnect.AutoSize = True
        Me.LabelDisconnect.Location = New System.Drawing.Point(73, 40)
        Me.LabelDisconnect.Name = "LabelDisconnect"
        Me.LabelDisconnect.Size = New System.Drawing.Size(59, 13)
        Me.LabelDisconnect.TabIndex = 14
        Me.LabelDisconnect.Text = "disconnect"
        '
        'LabelNormal
        '
        Me.LabelNormal.AutoSize = True
        Me.LabelNormal.Location = New System.Drawing.Point(73, 60)
        Me.LabelNormal.Name = "LabelNormal"
        Me.LabelNormal.Size = New System.Drawing.Size(38, 13)
        Me.LabelNormal.TabIndex = 15
        Me.LabelNormal.Text = "normal"
        '
        'LabelStop
        '
        Me.LabelStop.AutoSize = True
        Me.LabelStop.Location = New System.Drawing.Point(73, 80)
        Me.LabelStop.Name = "LabelStop"
        Me.LabelStop.Size = New System.Drawing.Size(27, 13)
        Me.LabelStop.TabIndex = 16
        Me.LabelStop.Text = "stop"
        '
        'LabelFree
        '
        Me.LabelFree.AutoSize = True
        Me.LabelFree.Location = New System.Drawing.Point(73, 100)
        Me.LabelFree.Name = "LabelFree"
        Me.LabelFree.Size = New System.Drawing.Size(25, 13)
        Me.LabelFree.TabIndex = 17
        Me.LabelFree.Text = "free"
        '
        'LabelSafety
        '
        Me.LabelSafety.AutoSize = True
        Me.LabelSafety.Location = New System.Drawing.Point(73, 120)
        Me.LabelSafety.Name = "LabelSafety"
        Me.LabelSafety.Size = New System.Drawing.Size(35, 13)
        Me.LabelSafety.TabIndex = 18
        Me.LabelSafety.Text = "safety"
        '
        'LabelEMG
        '
        Me.LabelEMG.AutoSize = True
        Me.LabelEMG.Location = New System.Drawing.Point(73, 140)
        Me.LabelEMG.Name = "LabelEMG"
        Me.LabelEMG.Size = New System.Drawing.Size(27, 13)
        Me.LabelEMG.TabIndex = 19
        Me.LabelEMG.Text = "emg"
        '
        'LabelNoCart
        '
        Me.LabelNoCart.AutoSize = True
        Me.LabelNoCart.Location = New System.Drawing.Point(73, 160)
        Me.LabelNoCart.Name = "LabelNoCart"
        Me.LabelNoCart.Size = New System.Drawing.Size(40, 13)
        Me.LabelNoCart.TabIndex = 20
        Me.LabelNoCart.Text = "no cart"
        '
        'LabelBatteryLow
        '
        Me.LabelBatteryLow.AutoSize = True
        Me.LabelBatteryLow.Location = New System.Drawing.Point(73, 180)
        Me.LabelBatteryLow.Name = "LabelBatteryLow"
        Me.LabelBatteryLow.Size = New System.Drawing.Size(39, 13)
        Me.LabelBatteryLow.TabIndex = 21
        Me.LabelBatteryLow.Text = "battery"
        '
        'LabelPoleErr
        '
        Me.LabelPoleErr.AutoSize = True
        Me.LabelPoleErr.Location = New System.Drawing.Point(73, 200)
        Me.LabelPoleErr.Name = "LabelPoleErr"
        Me.LabelPoleErr.Size = New System.Drawing.Size(27, 13)
        Me.LabelPoleErr.TabIndex = 22
        Me.LabelPoleErr.Text = "pole"
        '
        'LabelOutLine
        '
        Me.LabelOutLine.AutoSize = True
        Me.LabelOutLine.Location = New System.Drawing.Point(73, 220)
        Me.LabelOutLine.Name = "LabelOutLine"
        Me.LabelOutLine.Size = New System.Drawing.Size(41, 13)
        Me.LabelOutLine.TabIndex = 23
        Me.LabelOutLine.Text = "out line"
        '
        'agvChart
        '
        ChartArea1.Name = "ChartArea1"
        Me.agvChart.ChartAreas.Add(ChartArea1)
        Me.agvChart.Dock = System.Windows.Forms.DockStyle.Fill
        Legend1.Font = New System.Drawing.Font("Cambria", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Legend1.IsTextAutoFit = False
        Legend1.Name = "Legend1"
        Me.agvChart.Legends.Add(Legend1)
        Me.agvChart.Location = New System.Drawing.Point(3, 3)
        Me.agvChart.Name = "agvChart"
        Me.agvChart.Size = New System.Drawing.Size(868, 378)
        Me.agvChart.TabIndex = 0
        Me.agvChart.Text = "ChartPerformance"
        Title1.Font = New System.Drawing.Font("Cambria", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Title1.ForeColor = System.Drawing.Color.Maroon
        Title1.Name = "Title1"
        Title1.ShadowOffset = 3
        Title1.Text = "AGV STATUS"
        Title1.TextStyle = System.Windows.Forms.DataVisualization.Charting.TextStyle.Shadow
        Me.agvChart.Titles.Add(Title1)
        '
        'TabMap
        '
        Me.TabMap.Controls.Add(Me.TableLayoutPanel1)
        Me.TabMap.Location = New System.Drawing.Point(4, 22)
        Me.TabMap.Name = "TabMap"
        Me.TabMap.Padding = New System.Windows.Forms.Padding(3)
        Me.TabMap.Size = New System.Drawing.Size(874, 384)
        Me.TabMap.TabIndex = 2
        Me.TabMap.Text = "Map"
        Me.TabMap.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TablePanel_Header, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel_Map, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(868, 378)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TablePanel_Header
        '
        Me.TablePanel_Header.ColumnCount = 4
        Me.TablePanel_Header.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.9781!))
        Me.TablePanel_Header.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.0219!))
        Me.TablePanel_Header.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 796.0!))
        Me.TablePanel_Header.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 558.0!))
        Me.TablePanel_Header.Controls.Add(Me.ButtonFindAGV, 0, 0)
        Me.TablePanel_Header.Controls.Add(Me.PanelAlarm, 1, 0)
        Me.TablePanel_Header.Controls.Add(Me.labelMapName, 2, 0)
        Me.TablePanel_Header.Controls.Add(Me.Panel_Appendix, 3, 0)
        Me.TablePanel_Header.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TablePanel_Header.Location = New System.Drawing.Point(3, 3)
        Me.TablePanel_Header.Name = "TablePanel_Header"
        Me.TablePanel_Header.RowCount = 1
        Me.TablePanel_Header.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TablePanel_Header.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TablePanel_Header.Size = New System.Drawing.Size(862, 74)
        Me.TablePanel_Header.TabIndex = 19
        '
        'ButtonFindAGV
        '
        Me.ButtonFindAGV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonFindAGV.Location = New System.Drawing.Point(3, 3)
        Me.ButtonFindAGV.Name = "ButtonFindAGV"
        Me.ButtonFindAGV.Size = New System.Drawing.Size(1, 68)
        Me.ButtonFindAGV.TabIndex = 16
        Me.ButtonFindAGV.Text = "Find AGV"
        Me.ButtonFindAGV.UseVisualStyleBackColor = True
        '
        'PanelAlarm
        '
        Me.PanelAlarm.BackColor = System.Drawing.Color.Transparent
        Me.PanelAlarm.Controls.Add(Me.LabelAlarm)
        Me.PanelAlarm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelAlarm.Location = New System.Drawing.Point(-90, 3)
        Me.PanelAlarm.Name = "PanelAlarm"
        Me.PanelAlarm.Size = New System.Drawing.Size(1, 68)
        Me.PanelAlarm.TabIndex = 17
        '
        'LabelAlarm
        '
        Me.LabelAlarm.AutoSize = True
        Me.LabelAlarm.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.LabelAlarm.Location = New System.Drawing.Point(4, -14)
        Me.LabelAlarm.Name = "LabelAlarm"
        Me.LabelAlarm.Size = New System.Drawing.Size(29, 13)
        Me.LabelAlarm.TabIndex = 0
        Me.LabelAlarm.Text = "Error"
        '
        'labelMapName
        '
        Me.labelMapName.AutoSize = True
        Me.labelMapName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labelMapName.Font = New System.Drawing.Font("Constantia", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelMapName.ForeColor = System.Drawing.Color.Red
        Me.labelMapName.Location = New System.Drawing.Point(-488, 0)
        Me.labelMapName.Name = "labelMapName"
        Me.labelMapName.Size = New System.Drawing.Size(790, 74)
        Me.labelMapName.TabIndex = 1
        Me.labelMapName.Text = "Control system visualize Map"
        Me.labelMapName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel_Appendix
        '
        Me.Panel_Appendix.ColumnCount = 4
        Me.Panel_Appendix.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.Panel_Appendix.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.Panel_Appendix.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.Panel_Appendix.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.Panel_Appendix.Controls.Add(Me.Label_YellowDetail, 3, 2)
        Me.Panel_Appendix.Controls.Add(Me.Label_Green, 0, 0)
        Me.Panel_Appendix.Controls.Add(Me.Label_VioletDetail, 3, 1)
        Me.Panel_Appendix.Controls.Add(Me.Label_Gray, 0, 1)
        Me.Panel_Appendix.Controls.Add(Me.Label_RedDetail, 3, 0)
        Me.Panel_Appendix.Controls.Add(Me.Label_Violet, 2, 1)
        Me.Panel_Appendix.Controls.Add(Me.Label_Yellow, 2, 2)
        Me.Panel_Appendix.Controls.Add(Me.Label_GreenDetail, 1, 0)
        Me.Panel_Appendix.Controls.Add(Me.Label_Aqua, 0, 2)
        Me.Panel_Appendix.Controls.Add(Me.Label_GrayDetail, 1, 1)
        Me.Panel_Appendix.Controls.Add(Me.Label_Red, 2, 0)
        Me.Panel_Appendix.Controls.Add(Me.Label_AquaDetail, 1, 2)
        Me.Panel_Appendix.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_Appendix.Location = New System.Drawing.Point(308, 3)
        Me.Panel_Appendix.Name = "Panel_Appendix"
        Me.Panel_Appendix.RowCount = 3
        Me.Panel_Appendix.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.Panel_Appendix.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.Panel_Appendix.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.Panel_Appendix.Size = New System.Drawing.Size(552, 68)
        Me.Panel_Appendix.TabIndex = 18
        '
        'Label_YellowDetail
        '
        Me.Label_YellowDetail.AutoSize = True
        Me.Label_YellowDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_YellowDetail.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_YellowDetail.Location = New System.Drawing.Point(333, 46)
        Me.Label_YellowDetail.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Label_YellowDetail.Name = "Label_YellowDetail"
        Me.Label_YellowDetail.Size = New System.Drawing.Size(216, 20)
        Me.Label_YellowDetail.TabIndex = 12
        Me.Label_YellowDetail.Text = "Pole error, No Cart, Safety"
        '
        'Label_Green
        '
        Me.Label_Green.AutoSize = True
        Me.Label_Green.BackColor = System.Drawing.Color.GreenYellow
        Me.Label_Green.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_Green.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Green.Location = New System.Drawing.Point(3, 2)
        Me.Label_Green.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Label_Green.Name = "Label_Green"
        Me.Label_Green.Size = New System.Drawing.Size(49, 18)
        Me.Label_Green.TabIndex = 4
        Me.Label_Green.Text = "         "
        '
        'Label_VioletDetail
        '
        Me.Label_VioletDetail.AutoSize = True
        Me.Label_VioletDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_VioletDetail.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_VioletDetail.Location = New System.Drawing.Point(333, 24)
        Me.Label_VioletDetail.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Label_VioletDetail.Name = "Label_VioletDetail"
        Me.Label_VioletDetail.Size = New System.Drawing.Size(216, 18)
        Me.Label_VioletDetail.TabIndex = 14
        Me.Label_VioletDetail.Text = "Stop by card"
        '
        'Label_Gray
        '
        Me.Label_Gray.AutoSize = True
        Me.Label_Gray.BackColor = System.Drawing.Color.Gray
        Me.Label_Gray.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_Gray.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Gray.Location = New System.Drawing.Point(3, 24)
        Me.Label_Gray.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Label_Gray.Name = "Label_Gray"
        Me.Label_Gray.Size = New System.Drawing.Size(49, 18)
        Me.Label_Gray.TabIndex = 5
        Me.Label_Gray.Text = "         "
        '
        'Label_RedDetail
        '
        Me.Label_RedDetail.AutoSize = True
        Me.Label_RedDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_RedDetail.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_RedDetail.Location = New System.Drawing.Point(333, 2)
        Me.Label_RedDetail.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Label_RedDetail.Name = "Label_RedDetail"
        Me.Label_RedDetail.Size = New System.Drawing.Size(216, 18)
        Me.Label_RedDetail.TabIndex = 11
        Me.Label_RedDetail.Text = "Emergency, Out of line, Battery low"
        '
        'Label_Violet
        '
        Me.Label_Violet.AutoSize = True
        Me.Label_Violet.BackColor = System.Drawing.Color.Violet
        Me.Label_Violet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_Violet.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Violet.Location = New System.Drawing.Point(278, 24)
        Me.Label_Violet.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Label_Violet.Name = "Label_Violet"
        Me.Label_Violet.Size = New System.Drawing.Size(49, 18)
        Me.Label_Violet.TabIndex = 13
        Me.Label_Violet.Text = "         "
        '
        'Label_Yellow
        '
        Me.Label_Yellow.AutoSize = True
        Me.Label_Yellow.BackColor = System.Drawing.Color.Yellow
        Me.Label_Yellow.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_Yellow.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Yellow.Location = New System.Drawing.Point(278, 46)
        Me.Label_Yellow.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Label_Yellow.Name = "Label_Yellow"
        Me.Label_Yellow.Size = New System.Drawing.Size(49, 20)
        Me.Label_Yellow.TabIndex = 6
        Me.Label_Yellow.Text = "         "
        '
        'Label_GreenDetail
        '
        Me.Label_GreenDetail.AutoSize = True
        Me.Label_GreenDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_GreenDetail.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_GreenDetail.Location = New System.Drawing.Point(58, 2)
        Me.Label_GreenDetail.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Label_GreenDetail.Name = "Label_GreenDetail"
        Me.Label_GreenDetail.Size = New System.Drawing.Size(214, 18)
        Me.Label_GreenDetail.TabIndex = 8
        Me.Label_GreenDetail.Text = "Running Nomal"
        '
        'Label_Aqua
        '
        Me.Label_Aqua.AutoSize = True
        Me.Label_Aqua.BackColor = System.Drawing.Color.Cyan
        Me.Label_Aqua.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_Aqua.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Aqua.Location = New System.Drawing.Point(3, 46)
        Me.Label_Aqua.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Label_Aqua.Name = "Label_Aqua"
        Me.Label_Aqua.Size = New System.Drawing.Size(49, 20)
        Me.Label_Aqua.TabIndex = 7
        Me.Label_Aqua.Text = "         "
        '
        'Label_GrayDetail
        '
        Me.Label_GrayDetail.AutoSize = True
        Me.Label_GrayDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_GrayDetail.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_GrayDetail.Location = New System.Drawing.Point(58, 24)
        Me.Label_GrayDetail.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Label_GrayDetail.Name = "Label_GrayDetail"
        Me.Label_GrayDetail.Size = New System.Drawing.Size(214, 18)
        Me.Label_GrayDetail.TabIndex = 9
        Me.Label_GrayDetail.Text = "Disconnect"
        '
        'Label_Red
        '
        Me.Label_Red.AutoSize = True
        Me.Label_Red.BackColor = System.Drawing.Color.Red
        Me.Label_Red.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_Red.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Red.Location = New System.Drawing.Point(278, 2)
        Me.Label_Red.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Label_Red.Name = "Label_Red"
        Me.Label_Red.Size = New System.Drawing.Size(49, 18)
        Me.Label_Red.TabIndex = 3
        Me.Label_Red.Text = "         "
        '
        'Label_AquaDetail
        '
        Me.Label_AquaDetail.AutoSize = True
        Me.Label_AquaDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_AquaDetail.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_AquaDetail.Location = New System.Drawing.Point(58, 46)
        Me.Label_AquaDetail.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Label_AquaDetail.Name = "Label_AquaDetail"
        Me.Label_AquaDetail.Size = New System.Drawing.Size(214, 20)
        Me.Label_AquaDetail.TabIndex = 10
        Me.Label_AquaDetail.Text = "Free"
        '
        'Panel_Map
        '
        Me.Panel_Map.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_Map.Controls.Add(Me.LabelCardNotExit)
        Me.Panel_Map.Controls.Add(Me.PictureBoxMap)
        Me.Panel_Map.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_Map.Location = New System.Drawing.Point(3, 83)
        Me.Panel_Map.Name = "Panel_Map"
        Me.Panel_Map.Size = New System.Drawing.Size(862, 481)
        Me.Panel_Map.TabIndex = 0
        '
        'LabelCardNotExit
        '
        Me.LabelCardNotExit.AutoSize = True
        Me.LabelCardNotExit.Location = New System.Drawing.Point(4, 652)
        Me.LabelCardNotExit.Name = "LabelCardNotExit"
        Me.LabelCardNotExit.Size = New System.Drawing.Size(46, 13)
        Me.LabelCardNotExit.TabIndex = 1
        Me.LabelCardNotExit.Text = "No Card"
        Me.LabelCardNotExit.Visible = False
        '
        'PictureBoxMap
        '
        Me.PictureBoxMap.ContextMenuStrip = Me.ContextMenuMap
        Me.PictureBoxMap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBoxMap.Location = New System.Drawing.Point(0, 0)
        Me.PictureBoxMap.Name = "PictureBoxMap"
        Me.PictureBoxMap.Size = New System.Drawing.Size(860, 479)
        Me.PictureBoxMap.TabIndex = 0
        Me.PictureBoxMap.TabStop = False
        Me.PictureBoxMap.Visible = False
        '
        'ContextMenuMap
        '
        Me.ContextMenuMap.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AlignCenterToolStripMenuItem, Me.AligToolStripMenuItem})
        Me.ContextMenuMap.Name = "ContextMenuMap"
        Me.ContextMenuMap.Size = New System.Drawing.Size(159, 48)
        '
        'AlignCenterToolStripMenuItem
        '
        Me.AlignCenterToolStripMenuItem.Name = "AlignCenterToolStripMenuItem"
        Me.AlignCenterToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.AlignCenterToolStripMenuItem.Text = "Align vertical"
        '
        'AligToolStripMenuItem
        '
        Me.AligToolStripMenuItem.Name = "AligToolStripMenuItem"
        Me.AligToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.AligToolStripMenuItem.Text = "Align horisontal"
        '
        'TabLog
        '
        Me.TabLog.Location = New System.Drawing.Point(4, 22)
        Me.TabLog.Name = "TabLog"
        Me.TabLog.Size = New System.Drawing.Size(874, 384)
        Me.TabLog.TabIndex = 3
        Me.TabLog.Text = "History"
        Me.TabLog.UseVisualStyleBackColor = True
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
        Me.CrossTimer.Interval = 200
        '
        'AutoSaveTimer
        '
        Me.AutoSaveTimer.Interval = 10000
        '
        'RecordTimer
        '
        Me.RecordTimer.Interval = 500
        '
        'AndonTimer
        '
        Me.AndonTimer.Interval = 500
        '
        'TimerAndonMap
        '
        Me.TimerAndonMap.Interval = 200
        '
        'RequestDataTimer
        '
        Me.RequestDataTimer.Interval = 200
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(882, 456)
        Me.Controls.Add(Me.MainTabControl)
        Me.Controls.Add(Me.MainStatus)
        Me.Controls.Add(Me.MainMenu)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MainMenu
        Me.Name = "MainForm"
        Me.Text = "AGV Control System"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MainMenu.ResumeLayout(False)
        Me.MainMenu.PerformLayout()
        Me.MainTabControl.ResumeLayout(False)
        Me.TabMainForm.ResumeLayout(False)
        Me.SplitContainerOverView.Panel1.ResumeLayout(False)
        Me.SplitContainerOverView.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerOverView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerOverView.ResumeLayout(False)
        CType(Me.olvAGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuLstViewAGV.ResumeLayout(False)
        CType(Me.olvPart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuLstViewPart.ResumeLayout(False)
        Me.TabChart.ResumeLayout(False)
        Me.panelDetail.ResumeLayout(False)
        Me.panelDetail.PerformLayout()
        CType(Me.agvChart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabMap.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TablePanel_Header.ResumeLayout(False)
        Me.TablePanel_Header.PerformLayout()
        Me.PanelAlarm.ResumeLayout(False)
        Me.PanelAlarm.PerformLayout()
        Me.Panel_Appendix.ResumeLayout(False)
        Me.Panel_Appendix.PerformLayout()
        Me.Panel_Map.ResumeLayout(False)
        Me.Panel_Map.PerformLayout()
        CType(Me.PictureBoxMap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuMap.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MainMenu As System.Windows.Forms.MenuStrip
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
    Friend WithEvents MainTabControl As System.Windows.Forms.TabControl
    Friend WithEvents TabChart As System.Windows.Forms.TabPage
    Friend WithEvents TabMainForm As System.Windows.Forms.TabPage
    Friend WithEvents agvChart As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents TabMap As System.Windows.Forms.TabPage
    Friend WithEvents imgAGVSmall As System.Windows.Forms.ImageList
    Friend WithEvents MenuLstViewAGV As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MenuLstViewPart As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents imgPartBig As System.Windows.Forms.ImageList
    Friend WithEvents imgPartSmall As System.Windows.Forms.ImageList
    Friend WithEvents DisplayTimer As System.Windows.Forms.Timer
    Friend WithEvents CrossTimer As System.Windows.Forms.Timer
    Friend WithEvents AutoSaveTimer As System.Windows.Forms.Timer
    Friend WithEvents RecordTimer As System.Windows.Forms.Timer
    Friend WithEvents MenuPartView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuPartViewSmallIcon As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuPartViewTile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuAGVView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuAGVViewSmallIcon As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuAGVViewTile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuAGVConfirmConn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuAGVConfirmSelected As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuAGVConfirmAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuPartConfirmConn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuPartConfirmSelected As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuPartConfirmAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuAGVEnable As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AndonTimer As System.Windows.Forms.Timer
    Friend WithEvents SplitContainerOverView As System.Windows.Forms.SplitContainer
    Friend WithEvents olvPart As BrightIdeasSoftware.ObjectListView
    Friend WithEvents OlvColumnPartGroup As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumnPartName As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumnPartStatus As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumnPartConnecting As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumnPartEmptyTime As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumnPartAGVSupply As BrightIdeasSoftware.OLVColumn
    Friend WithEvents MenuPartEnable As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MainMenuSetting As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadPartToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowAllCardToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowAllCardToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TimerAndonMap As System.Windows.Forms.Timer
    Friend WithEvents VitualAGVToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DisableEndDeviceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VitualPartToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabLog As System.Windows.Forms.TabPage
    Friend WithEvents ContextMenuMap As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AlignCenterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AligToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OlvColumnGroup As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumnName As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumnPart As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumnWorkingType As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumnPosition As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumnStatus As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumnConnecting As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumnBattery As BrightIdeasSoftware.OLVColumn
    Private WithEvents olvAGV As BrightIdeasSoftware.ObjectListView
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TablePanel_Header As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonFindAGV As System.Windows.Forms.Button
    Friend WithEvents PanelAlarm As System.Windows.Forms.Panel
    Friend WithEvents LabelAlarm As System.Windows.Forms.Label
    Friend WithEvents labelMapName As System.Windows.Forms.Label
    Friend WithEvents Panel_Appendix As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label_YellowDetail As System.Windows.Forms.Label
    Friend WithEvents Label_Green As System.Windows.Forms.Label
    Friend WithEvents Label_VioletDetail As System.Windows.Forms.Label
    Friend WithEvents Label_Gray As System.Windows.Forms.Label
    Friend WithEvents Label_RedDetail As System.Windows.Forms.Label
    Friend WithEvents Label_Violet As System.Windows.Forms.Label
    Friend WithEvents Label_Yellow As System.Windows.Forms.Label
    Friend WithEvents Label_GreenDetail As System.Windows.Forms.Label
    Friend WithEvents Label_Aqua As System.Windows.Forms.Label
    Friend WithEvents Label_GrayDetail As System.Windows.Forms.Label
    Friend WithEvents Label_Red As System.Windows.Forms.Label
    Friend WithEvents Label_AquaDetail As System.Windows.Forms.Label
    Friend WithEvents Panel_Map As System.Windows.Forms.Panel
    Friend WithEvents LabelCardNotExit As System.Windows.Forms.Label
    Friend WithEvents PictureBoxMap As System.Windows.Forms.PictureBox
    Friend WithEvents panelDetail As TableLayoutPanel
    Friend WithEvents LabelAgvDetail As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents LabelTotal As Label
    Friend WithEvents LabelShutdown As Label
    Friend WithEvents LabelDisconnect As Label
    Friend WithEvents LabelNormal As Label
    Friend WithEvents LabelStop As Label
    Friend WithEvents LabelFree As Label
    Friend WithEvents LabelSafety As Label
    Friend WithEvents LabelEMG As Label
    Friend WithEvents LabelNoCart As Label
    Friend WithEvents LabelBatteryLow As Label
    Friend WithEvents LabelPoleErr As Label
    Friend WithEvents LabelOutLine As Label
    Friend WithEvents RequestDataTimer As Forms.Timer
    Friend WithEvents DebugModeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RequestFormToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CrossViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DebugFormToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ForceUploadToServerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DisplayPartToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TestToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RunToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StopToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents OlvColumn As OLVColumn
End Class
