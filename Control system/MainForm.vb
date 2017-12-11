Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Drawing.Point

Imports ControlSystemLibrary
Imports System.Threading
Imports BrightIdeasSoftware
Imports System.IO
Imports Microsoft.Win32
Imports Newtonsoft.Json

Public Class MainForm
    Shared DesignColor() As Brush = {Brushes.Black, Brushes.Gold, Brushes.Red, Brushes.Orange,
        Brushes.Green, Brushes.Blue, Brushes.Violet, Brushes.Gray, Brushes.Chocolate, Brushes.Pink,
        Brushes.Navy, Brushes.Aqua, Brushes.Teal, Brushes.Red, Brushes.Orange, Brushes.Green, Brushes.Blue,
        Brushes.Violet, Brushes.Gray, Brushes.Chocolate, Brushes.Pink, Brushes.WhiteSmoke}

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReadSetting()
        Record("System", "Running", "Startup")
        ReadXmlData()
        RecordInitialInfor()
        RecordPartEmptyCounterInit()

        Select Case RequestRouteConcept
            Case "Normal"

            Case "2Routes"
                RequestForm = New SupplyForm
                RequestForm.TopMost = True
                RequestForm.Show()
        End Select

        SetupHostXbee()
        SetupEventAgv()

        DisplayAGV()
        DisplayPart()
        Display_Map()

        If isNeedToReset Then
            ChartResetXML()
        End If
        ChartInit()

        DisplayTimer.Start()
        CrossTimer.Start()
        AutoSaveTimer.Start()
        RecordTimer.Start()
        AndonTimer.Start()
        RequestDataTimer.Start()

        SplitContainerOverView.SplitterDistance = Settings.SplitDistance
        MainTabControl.SelectedIndex = Tab_start
        panelDetail.Hide()

        ReadVersion()
    End Sub

    Private Sub ReadVersion()
        Dim assembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim fileInfo As New System.IO.FileInfo(assembly.Location)
        Dim lastModified As DateTime = fileInfo.LastWriteTime
        Text = "AGVControlSystem -- version: " + lastModified.ToString()
    End Sub
    Private Sub MainForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Record("System", "Running", "Close")
        RemoveHandler SystemEvents.DisplaySettingsChanged, AddressOf MyEH
        UploadToServer()
        Environment.Exit(0)
    End Sub
    Public Sub MyEH(ByVal sender As Object, ByVal e As EventArgs)
        Dim ScrWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim ScrHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        agvChart.Width = ScrWidth * 1863 / 1920 '1863
        agvChart.Height = (Me.Bottom - 120)
        MsgBox("Resolution has changed")
    End Sub
    Private Sub ResizeAndResolution()
        AddHandler SystemEvents.DisplaySettingsChanged, AddressOf MyEH
        Dim ScrWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim ScrHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        agvChart.Width = ScrWidth * 1863 / 1920 '1863
        agvChart.Height = (Me.Bottom - 120)
    End Sub

    Private Sub RequestDataTimer_Tick(sender As Object, e As EventArgs) Handles RequestDataTimer.Tick
        RequestDataTimer.Stop()
        RequestData()
        RequestDataTimer.Start()
    End Sub
    Private Sub DisplayTimer_Tick(sender As Object, e As EventArgs) Handles DisplayTimer.Tick '500 ms
        DisplayTimer.Stop()
        Select Case MainTabControl.SelectedIndex
            Case 0
                DisplayOverView()
            Case 1
                UpdateChart()
            Case 2

        End Select
        'If Not RequestThread.IsAlive Then
        '	RequestThread = New Thread(AddressOf RequestData)
        '	RequestThread.Name = "Request Thread"
        '	RequestThread.Start()
        'End If
        If Not UpdateThread.IsAlive Then
            UpdateThread = New Thread(AddressOf UpdateData)
            UpdateThread.Name = "Update Thread"
            UpdateThread.Start()
        End If
        DisplayTimer.Start()
    End Sub
    Private Sub ShowAllCardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowAllCardToolStripMenuItem.Click
        IsOptionShow = Not IsOptionShow
        If IsOptionShow = True Then
            ShowAllCardToolStripMenuItem.Text = "Show setting"
        Else
            ShowAllCardToolStripMenuItem.Text = "Hide setting"
        End If
    End Sub
#Region "Display Overview"
#Region "Display AGV"
#Region "For context menu"
    Private Sub MenuListViewAGV_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MenuLstViewAGV.Opening
        If olvAGV.SelectedIndices.Count = 0 Then
            MenuAGVView.Visible = True
            MenuAGVConfirmConn.Visible = True
            MenuAGVConfirmSelected.Enabled = False
            MenuAGVConfirmAll.Enabled = True
            MenuAGVEnable.Visible = False
            VitualAGVToolStripMenuItem.Visible = False
            LoadDataToolStripMenuItem.Visible = False
        ElseIf olvAGV.SelectedIndices.Count = 1 Then
            MenuAGVView.Visible = False
            MenuAGVConfirmConn.Visible = True
            MenuAGVConfirmSelected.Enabled = True
            MenuAGVConfirmAll.Enabled = True
            MenuAGVEnable.Visible = True
            If DebugMode Then
                VitualAGVToolStripMenuItem.Visible = True
            Else
                VitualAGVToolStripMenuItem.Visible = False
            End If
            LoadDataToolStripMenuItem.Visible = True
            If CType(olvAGV.SelectedObject, AGV).Enable Then
                MenuAGVEnable.Text = "Disable"
            Else
                MenuAGVEnable.Text = "Enable"
            End If
        Else
            MenuAGVView.Visible = False
            MenuAGVConfirmConn.Visible = True
            MenuAGVConfirmSelected.Enabled = True
            MenuAGVConfirmAll.Enabled = True
            MenuAGVEnable.Visible = False
            VitualAGVToolStripMenuItem.Visible = False
            LoadDataToolStripMenuItem.Visible = False
        End If
        'If My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator) Then
        '    MenuAGVEnable.Enabled = True
        'Else
        '    MenuAGVEnable.Enabled = False
        'End If
    End Sub
    Private Sub MenuAGVView_Click(sender As Object, e As EventArgs) Handles MenuAGVViewSmallIcon.Click, MenuAGVViewTile.Click, MyBase.Load
        If sender.Equals(MenuAGVViewTile) Then
            olvAGV.View = View.Tile
            Settings.AGVView = 0
            Settings.Save()
        End If
        If sender.Equals(MenuAGVViewSmallIcon) Then
            Settings.AGVView = 1
            Settings.Save()
        End If
        If Settings.AGVView = 0 Then
            olvAGV.TileSize = New Size(300, 100)
        ElseIf Settings.AGVView = 1 Then
            olvAGV.TileSize = New Size(300, 70)
        End If
    End Sub
    'Confirm to selected AGV
    Private Sub ForSelectedAGVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenuAGVConfirmSelected.Click
        Dim AGVSelectedCollection As ArrayList = olvAGV.SelectedObjects
        For i As Byte = 0 To AGVSelectedCollection.Count - 1
            Dim AGVIndex As AGV = CType(AGVSelectedCollection(i), AGV)
            AGVIndex.SetHostAddress()
        Next
    End Sub
    'Enable or Disable AGV
    Private Sub MenuAGVEnable_Click(sender As Object, e As EventArgs) Handles MenuAGVEnable.Click
        Dim rbc As AGV = CType(olvAGV.SelectedObject, AGV)      'ep kieu sang AGV
        rbc.Enable = Not rbc.Enable
        'update to sql
        Dim cmdValue As String = Convert.ToByte(rbc.Enable)
        Dim cmdWhere As String = rbc.Name
        'Dim cmdText As String = "UPDATE AGV SET Enable=" + cmdValue + " WHERE Name='" + cmdWhere + "'"
        'Dim cmdUpdate As SqlCommand = New SqlCommand(cmdText, SQLcon)
        'cmdUpdate.ExecuteNonQuery()
        SaveXml("AGV", rbc.index, "Enable", rbc.Enable.ToString().ToLower())
    End Sub
    'Host AGV
    'Private Sub HostAGVToolStripMenuItem_click(sender As Object, e As EventArgs)
    '	Dim rbc As AGV = CType(olvAGV.SelectedObject, AGV)
    '	Dim index As Byte = 99
    '	For i As Byte = 0 To HostXbee.Count - 1
    '		If HostXbee(i).Equals(rbc.myXbee) Then
    '			index = i
    '			Exit For
    '		End If
    '	Next
    '	If index = 99 Then
    '		MsgBox("Error")
    '	Else
    '		MsgBox("Host: " & index & vbCrLf & "Address" & rbc.myXbee.Address)
    '	End If
    'End Sub

    'Load data for channel
    Private Sub LoadDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadDataToolStripMenuItem.Click
        Dim rbc As AGV = CType(olvAGV.SelectedObject, AGV)
        If IsNothing(rbc.myXbee.port) = False Then
            rbc.myXbee.Send_AT_Command(XBee.AT_COMMAND_ENUM.CHANNEL)
            rbc.myXbee.Send_AT_Command(XBee.AT_COMMAND_ENUM.PAN_ID)
            rbc.myXbee.Send_AT_Command(XBee.AT_COMMAND_ENUM.CHANNEL_S2B)
        End If
    End Sub

#End Region
    Public Sub InitializeOlvAGV(ByVal list As List(Of AGV))
        olvAGV.AddDecoration(New EditingCellBorderDecoration(True))
        Dim tlist As TypedObjectListView(Of AGV) = New TypedObjectListView(Of AGV)(olvAGV)
        tlist.GenerateAspectGetters()
        OlvColumnGroup.AspectGetter = New AspectGetterDelegate(Function(row As Object) As String
                                                                   Dim myAGV As AGV = CType(row, AGV)
                                                                   Return AGVGroupArray(myAGV.group).Name
                                                               End Function)
        olvAGV.ItemRenderer = New AGVRenderer()
        olvAGV.SetObjects(list)
        olvAGV.View = View.Tile
        olvAGV.OwnerDraw = True
        'olvAGV.Groups.Clear()
    End Sub

    Class AGVRenderer
        Inherits AbstractRenderer
        Public Overrides Function RenderItem(e As DrawListViewItemEventArgs, g As Graphics, itemBounds As Rectangle, rowObject As Object) As Boolean
            Dim olv As ObjectListView = CType(e.Item.ListView, ObjectListView)
            If IsNothing(olv) Or (olv.View <> View.Tile) Then Return False
            Dim buffered As BufferedGraphics = BufferedGraphicsManager.Current.Allocate(g, itemBounds)
            g = buffered.Graphics
            g.Clear(olv.BackColor)
            g.SmoothingMode = ObjectListView.TextRenderingHint

            If (e.Item.Selected) Then
                BorderPen = Pens.Blue
                HeaderBackBrush = New SolidBrush(olv.HighlightBackgroundColorOrDefault)
            Else
                BorderPen = New Pen(Color.FromArgb(&H33, &H33, &H33))
                HeaderBackBrush = New SolidBrush(Color.FromArgb(&H33, &H33, &H33))
            End If
            Select Case Settings.AGVView
                Case 0 'full icon
                    DrawAGV(g, itemBounds, rowObject, olv, CType(e.Item, OLVListItem))
                Case 1 'small icon
                    DrawAGVSmall(g, itemBounds, rowObject, olv, CType(e.Item, OLVListItem))
            End Select
            ' Finally render the buffered graphics
            buffered.Render()
            buffered.Dispose()

            ' Return true to say that we've handled the drawing
            Return True
        End Function

        Friend BorderPen As Pen = New Pen(Color.FromArgb(&H33, &H33, &H33))
        Friend TextBrush As Brush = New SolidBrush(Color.FromArgb(&H22, &H22, &H22))
        Friend HeaderTextBrush As Brush = Brushes.AliceBlue
        'Friend HeaderBackBrush As Brush = New SolidBrush(Color.FromArgb(&H33, &H33, &H33))
        Friend HeaderBackBrush As Brush = Brushes.Brown
        Friend BackBrush As Brush = Brushes.LemonChiffon

        Public Sub DrawAGVSmall(g As Graphics, itemBounds As Rectangle, rowObject As Object, olv As ObjectListView, item As OLVListItem)
            Const spacing As Integer = 8

            ' Allow a border around the AGV
            itemBounds.Inflate(-2, -2)

            ' Draw card background
            Const rounding As Integer = 20
            Dim path As Drawing2D.GraphicsPath = GetRoundedRect(itemBounds, rounding)

            If CType(rowObject, AGV).Enable Then
                If CType(rowObject, AGV).Connecting Then
                    If CType(rowObject, AGV).WorkingStatus = AGV.RobocarWorkingStatusValue.FREE Then
                        BackBrush = Brushes.Yellow
                    Else
                        BackBrush = Brushes.GreenYellow
                    End If
                Else
                    BackBrush = Brushes.Gray
                End If
            Else
                BackBrush = Brushes.LightGray
            End If
            g.FillPath(BackBrush, path)
            g.DrawPath(BorderPen, path)

            g.Clip = New Region(itemBounds)

            'Draw the photo
            Dim photoRect As Rectangle = itemBounds
            photoRect.Inflate(-spacing, -spacing)
            Dim rbc As AGV = CType(rowObject, AGV)
            If Not IsNothing(rbc) Then
                photoRect.Width = 50            'size of photo
                Dim photoFile As String = String.Format(".\img\AGV\{0}.png", CalcImgFile(rbc))
                If File.Exists(photoFile) Then
                    Dim photo As Image = Image.FromFile(photoFile)
                    If photo.Width > photoRect.Width Then
                        photoRect.Height = CType(photo.Height * (CType(photoRect.Width, Single) / photo.Width), Integer)
                    Else
                        photoRect.Height = photo.Height
                    End If
                    g.DrawImage(photo, photoRect)
                Else
                    g.DrawRectangle(Pens.DarkGray, photoRect)
                End If
            End If

            ' Now draw the text portion
            Dim textBoxRect As RectangleF = photoRect
            textBoxRect.X += (photoRect.Width + spacing)
            textBoxRect.Width = itemBounds.Right - textBoxRect.X - spacing

            Dim fmt As StringFormat = New StringFormat(StringFormatFlags.NoWrap)
            fmt.Trimming = StringTrimming.EllipsisCharacter
            fmt.Alignment = StringAlignment.Center                  'position X of AGV name
            fmt.LineAlignment = StringAlignment.Near                'position Y of AGV name
            Dim txt As String = rbc.Name

            Using uFont As Font = New Font("Tahoma", 10)
                ' Measure the height of the title
                Dim size As SizeF = g.MeasureString(txt, uFont, CType(textBoxRect.Width, Integer), fmt)
                ' Draw the title
                Dim r3 As RectangleF = textBoxRect
                r3.Height = size.Height
                path = GetRoundedRect(r3, 15)


                If IsOptionShow = True Then 'hai:backcolor of AGV
                    If rbc.Enable Then
                        g.FillPath(Brushes.DarkKhaki, path)
                    Else
                        g.FillPath(Brushes.DarkGray, path)
                    End If
                Else
                    Dim HeaderColow As Brush = DesignColor(rbc.HostControl)
                    g.FillPath(HeaderColow, path)
                End If

                g.DrawString(txt, uFont, HeaderTextBrush, textBoxRect, fmt)
                textBoxRect.Y += size.Height + 2
            End Using


            'Draw the other bits of information
            Using uFont As Font = New Font("Tahoma", 10)
                Dim size As SizeF = g.MeasureString("Wj", uFont, itemBounds.Width, fmt)
                textBoxRect.Height = size.Height
                fmt.Alignment = StringAlignment.Near            'alignment text (part name, possition, Battery)
                txt = ""
                If IsOptionShow = True Then                     'option show more detail
                    If rbc.Enable Then
                        'display Part Name
                        For i As Byte = 0 To AGVnPART.GetLength(1) - 1
                            If AGVnPART(rbc.index, i) = True Then
                                If rbc.SupplyPartStatus = PartList(i).route Then            'get route of part
                                    txt = "Part: " + PartList(i).Name + " (" + rbc.SupplyPartStatus.ToString + ")"
                                    Exit For
                                End If
                            End If
                        Next
                        If txt = "" Then
                            txt = "Part: " + "Unknown" + " (" + rbc.SupplyPartStatus.ToString + ")"
                        End If
                        g.DrawString(txt, uFont, TextBrush, textBoxRect, fmt)
                        textBoxRect.Y += size.Height - 2                                      'xuong dong
                        'display free time
                        If rbc.WorkingStatus = AGV.RobocarWorkingStatusValue.FREE Then
                            txt = "F.Time: " + Math.Round((Now - rbc.FreeTime).TotalSeconds).ToString() + "s" + "| Count: " + rbc.SupplyCount.ToString
                        Else
                            txt = "S.Time: " + Math.Round((Now - rbc.SupplyTime).TotalSeconds).ToString() + "s" + "| Count: " + rbc.SupplyCount.ToString
                        End If
                        g.DrawString(txt, uFont, TextBrush, textBoxRect, fmt)
                        textBoxRect.Y += size.Height - 2
                    End If
                Else                                                'show setting
                    'address
                    txt = "Add:" & Conversion.Hex(rbc.Address) & "|Host:" & rbc.HostControl.ToString
                    If IsNothing(rbc.myXbee.port) = False Then
                        txt = txt + "|" & rbc.myXbee.port.PortName
                    Else
                        txt = txt + "|No port"
                    End If
                    g.DrawString(txt, uFont, TextBrush, textBoxRect, fmt)
                    textBoxRect.Y += size.Height
                    'CH and ID
                    txt = "CH:" & Conversion.Hex(rbc.myXbee.CH) & "|ID :" & Conversion.Hex(rbc.myXbee.ID) & "|" & "On time:" & rbc.TimeAGVPowerOn.ToString
                    g.DrawString(txt, uFont, TextBrush, textBoxRect, fmt)
                    textBoxRect.Y += size.Height
                End If
            End Using
        End Sub
        Public Sub DrawAGV(g As Graphics, itemBounds As Rectangle, rowObject As Object, olv As ObjectListView, item As OLVListItem)
            Const spacing As Integer = 8

            ' Allow a border around the AGV
            itemBounds.Inflate(-2, -2)

            ' Draw card background
            Const rounding As Integer = 20
            Dim path As Drawing2D.GraphicsPath = GetRoundedRect(itemBounds, rounding)

            If CType(rowObject, AGV).Enable Then
                If CType(rowObject, AGV).Connecting Then
                    If CType(rowObject, AGV).WorkingStatus = AGV.RobocarWorkingStatusValue.FREE Then
                        BackBrush = Brushes.Yellow
                    Else
                        BackBrush = Brushes.GreenYellow
                    End If
                Else
                    BackBrush = Brushes.Gray
                End If
            Else
                BackBrush = Brushes.LightGray
            End If
            g.FillPath(BackBrush, path)
            g.DrawPath(BorderPen, path)

            g.Clip = New Region(itemBounds)

            'Draw the photo
            Dim photoRect As Rectangle = itemBounds
            photoRect.Inflate(-spacing, -spacing)
            Dim rbc As AGV = CType(rowObject, AGV)
            If Not IsNothing(rbc) Then
                photoRect.Width = 80            'size of photo
                Dim photoFile As String = String.Format(".\img\AGV\{0}.png", CalcImgFile(rbc))
                If File.Exists(photoFile) Then
                    Dim photo As Image = Image.FromFile(photoFile)
                    If photo.Width > photoRect.Width Then
                        photoRect.Height = CType(photo.Height * (CType(photoRect.Width, Single) / photo.Width), Integer)
                    Else
                        photoRect.Height = photo.Height
                    End If
                    g.DrawImage(photo, photoRect)
                Else
                    g.DrawRectangle(Pens.DarkGray, photoRect)
                End If
            End If

            ' Now draw the text portion
            Dim textBoxRect As RectangleF = photoRect
            textBoxRect.X += (photoRect.Width + spacing)
            textBoxRect.Width = itemBounds.Right - textBoxRect.X - spacing

            Dim fmt As StringFormat = New StringFormat(StringFormatFlags.NoWrap)
            fmt.Trimming = StringTrimming.EllipsisCharacter
            fmt.Alignment = StringAlignment.Center                  'position X of AGV name
            fmt.LineAlignment = StringAlignment.Near                'position Y of AGV name
            Dim txt As String = rbc.Name

            Using uFont As Font = New Font("Tahoma", 10)
                ' Measure the height of the title
                Dim size As SizeF = g.MeasureString(txt, uFont, CType(textBoxRect.Width, Integer), fmt)
                ' Draw the title
                Dim r3 As RectangleF = textBoxRect
                r3.Height = size.Height
                path = GetRoundedRect(r3, 15)


                If IsOptionShow = True Then 'hai:backcolor of AGV
                    If rbc.Enable Then
                        g.FillPath(Brushes.DarkKhaki, path)
                    Else
                        g.FillPath(Brushes.DarkGray, path)
                    End If
                Else
                    Dim HeaderColow As Brush = DesignColor(rbc.HostControl)
                    g.FillPath(HeaderColow, path)
                End If

                g.DrawString(txt, uFont, HeaderTextBrush, textBoxRect, fmt)
                textBoxRect.Y += size.Height + 5
            End Using


            'Draw the other bits of information
            Using uFont As Font = New Font("Tahoma", 10)
                Dim size As SizeF = g.MeasureString("Wj", uFont, itemBounds.Width, fmt)
                textBoxRect.Height = size.Height
                fmt.Alignment = StringAlignment.Near            'alignment text (part name, possition, Battery)
                txt = ""
                If IsOptionShow = True Then                     'option show more detail
                    If rbc.Enable Then
                        'display Part Name
                        For i As Byte = 0 To AGVnPART.GetLength(1) - 1
                            If AGVnPART(rbc.index, i) = True Then
                                If rbc.SupplyPartStatus = PartList(i).route Then            'get route of part
                                    txt = "Part: " + PartList(i).Name + " (" + rbc.SupplyPartStatus.ToString + ")"
                                    Exit For
                                End If
                            End If
                        Next
                        If txt = "" Then
                            txt = "Part: " + "Unknown" + " (" + rbc.SupplyPartStatus.ToString + ")"
                        End If
                        g.DrawString(txt, uFont, TextBrush, textBoxRect, fmt)
                        textBoxRect.Y += size.Height                                        'xuong dong
                        'display position
                        If CType(rowObject, AGV).Position = 5000 Then 'Cross function AGV
                            txt = "AGV Cross"
                        Else
                            If CType(rowObject, AGV).isStopByCross = False Then
                                txt = "Position: " + CType(rowObject, AGV).Position.ToString
                            Else
                                txt = "Cross: " + CType(rowObject, AGV).Position.ToString
                            End If
                        End If
                        'display free time
                        If rbc.WorkingStatus = AGV.RobocarWorkingStatusValue.FREE Then
                            txt += " | F.Time: " + Math.Round((Now - rbc.FreeTime).TotalSeconds).ToString() + "s"
                        Else
                            txt += " | S.Time: " + Math.Round((Now - rbc.SupplyTime).TotalSeconds).ToString() + "s"
                        End If
                        g.DrawString(txt, uFont, TextBrush, textBoxRect, fmt)
                        textBoxRect.Y += size.Height
                        'display battery
                        Dim value = rbc.BatteryPercent()
                        txt = "Battery: " + value.ToString + "%" + "| Count: " + rbc.SupplyCount.ToString
                        If value < 25 Then
                            g.DrawString(txt, uFont, Brushes.DarkRed, textBoxRect, fmt)
                        Else
                            g.DrawString(txt, uFont, TextBrush, textBoxRect, fmt)
                        End If
                        textBoxRect.Y += size.Height
                    End If
                Else                                                'show setting
                    'address
                    txt = "Add:" & Conversion.Hex(rbc.Address)
                    g.DrawString(txt, uFont, TextBrush, textBoxRect, fmt)
                    textBoxRect.Y += size.Height
                    'host
                    txt = "Host:" & rbc.HostControl.ToString
                    If IsNothing(rbc.myXbee.port) = False Then
                        txt = txt + "|" & rbc.myXbee.port.PortName
                    Else
                        txt = txt + "|No port"
                    End If

                    g.DrawString(txt, uFont, TextBrush, textBoxRect, fmt)
                    textBoxRect.Y += size.Height
                    'CH and ID
                    txt = "CH:" & Conversion.Hex(rbc.myXbee.CH) & "|ID:" & Conversion.Hex(rbc.myXbee.ID) & "|" & "On time:" & rbc.TimeAGVPowerOn.ToString
                    g.DrawString(txt, uFont, TextBrush, textBoxRect, fmt)
                    textBoxRect.Y += size.Height
                End If
            End Using
        End Sub

        'Rounded rectangle
        Private Function GetRoundedRect(rect As RectangleF, diameter As Single) As Drawing2D.GraphicsPath
            Dim path As Drawing2D.GraphicsPath = New Drawing2D.GraphicsPath()
            Dim arc As RectangleF = New RectangleF(rect.X, rect.Y, diameter, diameter)

            path.AddArc(arc, 180, 90)
            arc.X = rect.Right - diameter
            path.AddArc(arc, 270, 90)
            arc.Y = rect.Bottom - diameter
            path.AddArc(arc, 0, 90)
            arc.X = rect.Left
            path.AddArc(arc, 90, 90)
            path.CloseFigure()
            Return path
        End Function

        'Choose Image to show
        Private Function CalcImgFile(rbc As AGV) As String
            If rbc.Enable = False Then
                Return "disable"
            Else
                If rbc.Connecting Then
                    If rbc.WorkingStatus = AGV.RobocarWorkingStatusValue.FREE Then
                        Return rbc.WorkingStatus.ToString + "-" + "Connecting"
                    Else
                        Return rbc.Status.ToString + "-" + "Connecting"
                    End If
                Else
                    If rbc.WorkingStatus = AGV.RobocarWorkingStatusValue.FREE Then
                        Return rbc.WorkingStatus.ToString + "-" + "Disconnecting"
                    Else
                        Return rbc.Status.ToString + "-" + "Disconnecting"
                    End If
                End If
            End If
        End Function
    End Class

    Public Sub DisplayAGV()
        'olvAGV.View = View.Tile
        olvAGV.OwnerDraw = True
        InitializeOlvAGV(AGVList)

    End Sub
#End Region
#Region "Display part"
#Region "For context menu"
    Private Sub MenuLstViewPart_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MenuLstViewPart.Opening
        If olvPart.SelectedIndices.Count = 0 Then
            MenuPartView.Visible = True
            MenuPartConfirmConn.Visible = True
            MenuPartConfirmSelected.Enabled = False
            MenuPartConfirmAll.Enabled = True
            MenuPartEnable.Visible = False
            LoadPartToolStripMenuItem.Visible = False
            VitualPartToolStripMenuItem.Visible = False
        ElseIf olvPart.SelectedIndices.Count = 1 Then
            MenuPartView.Visible = False
            MenuPartConfirmConn.Visible = True
            MenuPartConfirmSelected.Enabled = True
            MenuPartConfirmAll.Enabled = True
            MenuPartEnable.Visible = True
            LoadPartToolStripMenuItem.Visible = True
            If DebugMode Then
                VitualPartToolStripMenuItem.Visible = True
            Else
                VitualPartToolStripMenuItem.Visible = False
            End If
            If CType(olvPart.SelectedObject, CPart).Enable Then
                MenuPartEnable.Text = "Disable"
            Else
                MenuPartEnable.Text = "Enable"
            End If
        Else
            MenuPartView.Visible = False
            MenuPartConfirmConn.Visible = True
            MenuPartConfirmSelected.Enabled = True
            MenuPartConfirmAll.Enabled = True
            MenuPartEnable.Visible = False
            LoadPartToolStripMenuItem.Visible = False
            VitualPartToolStripMenuItem.Visible = False
        End If
        'If My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator) Then
        '    MenuPartEnable.Enabled = True
        'Else
        '    MenuPartEnable.Enabled = False
        'End If
    End Sub
    Private Sub MenuPartViewItem_Click(sender As Object, e As EventArgs) Handles MenuPartViewSmallIcon.Click, MenuPartViewTile.Click, MyBase.Load
        If sender.Equals(MenuPartViewTile) Then
            olvPart.View = View.Tile
            Settings.PartView = 0
            Settings.Save()
        End If
        If sender.Equals(MenuPartViewSmallIcon) Then
            'olvPart.View = View.SmallIcon
            Settings.PartView = 1
            Settings.Save()
        End If
        Select Case Settings.PartView
            Case 0
                olvPart.TileSize = New Size(260, 100)
            Case 1
                olvPart.TileSize = New Size(250, 70)
        End Select
    End Sub
    Private Sub MenuPartConfirmSelected_Click(sender As Object, e As EventArgs) Handles MenuPartConfirmSelected.Click
        Dim PartSelectedCollection As ArrayList = olvPart.SelectedObjects
        For i As Byte = 0 To PartSelectedCollection.Count - 1
            Dim PartIndex As Byte = CType(PartSelectedCollection(i), CPart).index
            PartList(PartIndex).parent.SettingAddress()
        Next

        'Dim PartIndex As Byte = CType(olvPart.SelectedObject, CPart).index
        'PartList(PartIndex).parent.SettingAddress()
    End Sub
    Private Sub DisableEndDeviceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DisableEndDeviceToolStripMenuItem.Click
        Dim PartSelectedCollection As ArrayList = olvPart.SelectedObjects
        For i As Byte = 0 To PartSelectedCollection.Count - 1
            Dim PartIndex As Byte = CType(PartSelectedCollection(i), CPart).index
            PartList(PartIndex).parent.DisableEndevice()
        Next
    End Sub

    Private Sub MenuPartEnable_Click(sender As Object, e As EventArgs) Handles MenuPartEnable.Click
        Dim part As CPart = CType(olvPart.SelectedObject, CPart)
        part.Enable = Not part.Enable
        SaveXml("Part", part.index, "Enable", part.Enable.ToString().ToLower())
        'Dim cmdValue As String = Convert.ToByte(PartList(PartIndex).Enable)
        'Dim cmdWhere As String = PartIndex.ToString
        'Dim cmdText As String = "UPDATE Part SET Enable=" + cmdValue + " WHERE ID=" + cmdWhere
        'Dim cmdUpdate As SqlCommand = New SqlCommand(cmdText, SQLcon)
        'cmdUpdate.ExecuteNonQuery()
    End Sub
    'EndDevice
    Private Sub LoadPartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadPartToolStripMenuItem.Click
        Dim Part As CPart = CType(olvPart.SelectedObject, CPart)        'ep kieu sang AGV
        If IsNothing(Part.parent.myXbee) Then Return
        If IsNothing(Part.parent.myXbee.port) = False Then
            Part.parent.myXbee.Send_AT_Command(XBee.AT_COMMAND_ENUM.CHANNEL)
            Part.parent.myXbee.Send_AT_Command(XBee.AT_COMMAND_ENUM.PAN_ID)
            Part.parent.myXbee.Send_AT_Command(XBee.AT_COMMAND_ENUM.CHANNEL_S2B)
        End If
    End Sub
    Private Sub HostToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim Part As CPart = CType(olvPart.SelectedObject, CPart)
        Dim index As Byte = 99
        For i As Byte = 0 To EndDevicesArray.Count - 1
            If EndDevicesArray(i).myXbee.Equals(Part.parent.myXbee) Then
                index = i
                Exit For
            End If
        Next
        If index = 99 Then
            MsgBox("Error")
        Else
            MsgBox("Host: " & index & vbCrLf & "Address: " & Part.parent.myXbee.Address)
        End If
    End Sub
#End Region
    Public Sub InitializeOlvPart(ByVal list As List(Of CPart))
        olvPart.AddDecoration(New EditingCellBorderDecoration(True))
        Dim tlist As TypedObjectListView(Of CPart) = New TypedObjectListView(Of CPart)(olvPart)
        tlist.GenerateAspectGetters()
        OlvColumnPartConnecting.AspectGetter = New AspectGetterDelegate(Function(row As Object) As String
                                                                            Dim part As CPart = CType(row, CPart)
                                                                            If (part.connecting) Then
                                                                                Return "Connected"
                                                                            Else
                                                                                Return "Disconnect"
                                                                            End If
                                                                        End Function)
        OlvColumnPartGroup.AspectGetter = New AspectGetterDelegate(Function(row As Object) As String
                                                                       Dim part As CPart = CType(row, CPart)
                                                                       Return LineGroupArray(part.group).Name
                                                                   End Function)
        olvPart.ItemRenderer = New PartRenderer()
        olvPart.SetObjects(list)
        olvPart.View = View.Tile
        olvPart.OwnerDraw = True
        olvPart.Sort(1)
    End Sub

    Class PartRenderer
        Inherits AbstractRenderer
        Public Overrides Function RenderItem(e As DrawListViewItemEventArgs, g As Graphics, itemBounds As Rectangle, rowObject As Object) As Boolean
            Dim olv As ObjectListView = CType(e.Item.ListView, ObjectListView)
            If IsNothing(olv) Or (olv.View <> View.Tile) Then Return False
            Dim buffered As BufferedGraphics = BufferedGraphicsManager.Current.Allocate(g, itemBounds)
            g = buffered.Graphics
            g.Clear(olv.BackColor)
            g.SmoothingMode = ObjectListView.TextRenderingHint

            If (e.Item.Selected) Then
                BorderPen = Pens.Blue
                HeaderBackBrush = New SolidBrush(olv.HighlightBackgroundColorOrDefault)
            Else
                BorderPen = New Pen(Color.FromArgb(&H33, &H33, &H33))
                HeaderBackBrush = New SolidBrush(Color.FromArgb(&H33, &H33, &H33))
            End If
            Select Case Settings.PartView
                Case 0
                    DrawPart(g, itemBounds, rowObject, olv, CType(e.Item, OLVListItem))
                Case 1
                    DrawPartSmall(g, itemBounds, rowObject, olv, CType(e.Item, OLVListItem))
            End Select
            ' Finally render the buffered graphics
            buffered.Render()
            buffered.Dispose()

            ' Return true to say that we've handled the drawing
            Return True
        End Function
        Friend BorderPen As Pen = New Pen(Color.FromArgb(&H33, &H33, &H33))
        Friend TextBrush As Brush = New SolidBrush(Color.FromArgb(&H22, &H22, &H22))
        Friend HeaderTextBrush As Brush = Brushes.AliceBlue
        Friend HeaderBackBrush As Brush = New SolidBrush(Color.FromArgb(&H33, &H33, &H33))
        'Friend HeaderBackBrush As Brush = Brushes.Brown
        Friend BackBrush As Brush = Brushes.LemonChiffon

        Public Sub DrawPartSmall(g As Graphics, itemBounds As Rectangle, rowObject As Object, olv As ObjectListView, item As OLVListItem)
            Const spacing As Integer = 8

            ' Allow a border around the card
            itemBounds.Inflate(-2, -2)

            ' Draw card background
            Const rounding As Integer = 20
            Dim path As Drawing2D.GraphicsPath = GetRoundedRect(itemBounds, rounding)

            If CType(rowObject, CPart).Enable Then
                If CType(rowObject, CPart).parent.connecting Then
                    BackBrush = Brushes.YellowGreen
                Else
                    BackBrush = Brushes.Gray
                End If
            Else
                BackBrush = Brushes.LightGray
            End If
            g.FillPath(BackBrush, path)
            'BorderPen.Width = 5
            g.DrawPath(BorderPen, path)

            g.Clip = New Region(itemBounds)

            'Draw the photo
            Dim photoRect As Rectangle = itemBounds
            photoRect.Inflate(-spacing, -spacing)
            Dim part As CPart = CType(rowObject, CPart)
            If Not IsNothing(part) Then
                photoRect.Width = 50
                Dim photoFile As String = String.Format(".\img\part\{0}.png", CalcImgFile(part))
                If File.Exists(photoFile) Then
                    Dim photo As Image = Image.FromFile(photoFile)
                    If photo.Width > photoRect.Width Then
                        photoRect.Height = CType(photo.Height * (CType(photoRect.Width, Single) / photo.Width), Integer)
                    Else
                        photoRect.Height = photo.Height
                    End If
                    g.DrawImage(photo, photoRect)
                Else
                    g.DrawRectangle(Pens.DarkGray, photoRect)
                End If
            End If

            ' Now draw the text portion
            Dim textBoxRect As RectangleF = photoRect
            textBoxRect.X += (photoRect.Width + spacing)
            textBoxRect.Width = itemBounds.Right - textBoxRect.X - spacing

            Dim fmt As StringFormat = New StringFormat(StringFormatFlags.NoWrap)
            fmt.Trimming = StringTrimming.EllipsisCharacter
            fmt.Alignment = StringAlignment.Center
            fmt.LineAlignment = StringAlignment.Near

            Dim txt As String
            If IsOptionShow = True Then
                txt = part.Name + " (" + part.route.ToString + ")" 'TODO: name and route
            Else
                txt = part.index.ToString + ". " + part.Name
            End If
            Using uFont As Font = New Font("Tahoma", 10)
                ' Measure the height of the title
                Dim size As SizeF = g.MeasureString(txt, uFont, CType(textBoxRect.Width, Integer), fmt)
                ' Draw the title
                Dim r3 As RectangleF = textBoxRect
                r3.Height = size.Height
                path = GetRoundedRect(r3, 15)

                If IsOptionShow = True Then 'hai:backcolor of partname
                    If part.Enable Then
                        g.FillPath(Brushes.DarkKhaki, path)
                    Else
                        g.FillPath(Brushes.DarkGray, path)
                    End If
                Else
                    Dim HeaderColow As Brush = DesignColor(part.EndDevice)
                    g.FillPath(HeaderColow, path)
                End If

                g.DrawString(txt, uFont, HeaderTextBrush, textBoxRect, fmt)
                textBoxRect.Y += size.Height + 2
            End Using

            'Draw the other bits of information
            Using uFont As Font = New Font("Tahoma", 10)
                Dim size As SizeF = g.MeasureString("Wj", uFont, itemBounds.Width, fmt)
                textBoxRect.Height = size.Height
                fmt.Alignment = StringAlignment.Near
                If IsOptionShow = True Then
                    If part.Enable Then
                        txt = "Count: " + part.SupplyCount.ToString + "/" + part.target.ToString
                        g.DrawString(txt, uFont, TextBrush, textBoxRect, fmt)
                        textBoxRect.Y += size.Height - 2
                        If part.AGVSupply = "" Then
                            If part.Status = False Then
                                txt = "Empty time: " + Math.Round((Now - part.EmptyTime).TotalSeconds).ToString() + "s"
                                g.DrawString(txt, uFont, Brushes.DarkRed, textBoxRect, fmt)
                                textBoxRect.Y += size.Height - 2
                            Else
                                txt = "Full time: " + Math.Round((Now - part.FullTime).TotalSeconds).ToString() + "s"
                                g.DrawString(txt, uFont, Brushes.DarkGreen, textBoxRect, fmt)
                                textBoxRect.Y += size.Height - 2
                            End If
                        Else
                            txt = "AGV: " + part.AGVSupply + "| " + Math.Round((Now - part.SupplyTime).TotalSeconds).ToString() + "s"
                            g.DrawString(txt, uFont, Brushes.DarkBlue, textBoxRect, fmt)
                        End If
                    End If
                Else                                                'show setting
                    'End
                    txt = "End:" & part.EndDevice & "." & part.NumberInEnd.ToString & "|" & Conversion.Hex(part.parent.Address)
                    g.DrawString(txt, uFont, TextBrush, textBoxRect, fmt)
                    textBoxRect.Y += size.Height
                    'host				
                    txt = "Host:" + part.parent.Host.ToString   '"Host: " & index
                    If RequestRouteConcept = "Normal" Then
                        If IsNothing(part.parent.myXbee.port) = False Then
                            txt = txt & "|" & part.parent.myXbee.port.PortName
                        Else
                            txt = txt & "|No port"
                        End If
                    Else
                        txt = txt & "|Text"
                    End If
                    g.DrawString(txt, uFont, TextBrush, textBoxRect, fmt)
                    textBoxRect.Y += size.Height
                    'CH and ID
                    If RequestRouteConcept = "Normal" Then
                        txt = "CH:" & Conversion.Hex(part.parent.myXbee.CH) & "|ID:" & Conversion.Hex(part.parent.myXbee.ID)
                    Else
                        txt = "Text"
                    End If
                    g.DrawString(txt, uFont, TextBrush, textBoxRect, fmt)
                    textBoxRect.Y += size.Height
                End If
            End Using
        End Sub
        Public Sub DrawPart(g As Graphics, itemBounds As Rectangle, rowObject As Object, olv As ObjectListView, item As OLVListItem)
            Const spacing As Integer = 8

            ' Allow a border around the card
            itemBounds.Inflate(-2, -2)

            ' Draw card background
            Const rounding As Integer = 20
            Dim path As Drawing2D.GraphicsPath = GetRoundedRect(itemBounds, rounding)

            If CType(rowObject, CPart).Enable Then
                If CType(rowObject, CPart).parent.connecting Then
                    BackBrush = Brushes.YellowGreen
                Else
                    BackBrush = Brushes.Gray
                End If
            Else
                BackBrush = Brushes.LightGray
            End If
            g.FillPath(BackBrush, path)
            'BorderPen.Width = 5
            g.DrawPath(BorderPen, path)

            g.Clip = New Region(itemBounds)

            'Draw the photo
            Dim photoRect As Rectangle = itemBounds
            photoRect.Inflate(-spacing, -spacing)
            Dim part As CPart = CType(rowObject, CPart)
            If Not IsNothing(part) Then
                photoRect.Width = 80
                Dim photoFile As String = String.Format(".\img\part\{0}.png", CalcImgFile(part))
                If File.Exists(photoFile) Then
                    Dim photo As Image = Image.FromFile(photoFile)
                    If photo.Width > photoRect.Width Then
                        photoRect.Height = CType(photo.Height * (CType(photoRect.Width, Single) / photo.Width), Integer)
                    Else
                        photoRect.Height = photo.Height
                    End If
                    g.DrawImage(photo, photoRect)
                Else
                    g.DrawRectangle(Pens.DarkGray, photoRect)
                End If
            End If

            ' Now draw the text portion
            Dim textBoxRect As RectangleF = photoRect
            textBoxRect.X += (photoRect.Width + spacing)
            textBoxRect.Width = itemBounds.Right - textBoxRect.X - spacing

            Dim fmt As StringFormat = New StringFormat(StringFormatFlags.NoWrap)
            fmt.Trimming = StringTrimming.EllipsisCharacter
            fmt.Alignment = StringAlignment.Center
            fmt.LineAlignment = StringAlignment.Near

            Dim txt As String
            If IsOptionShow = True Then
                txt = part.Name + " (" + part.route.ToString + ")" 'TODO: name and route
            Else
                txt = part.index.ToString + ". " + part.Name
            End If
            Using uFont As Font = New Font("Tahoma", 11)
                ' Measure the height of the title
                Dim size As SizeF = g.MeasureString(txt, uFont, CType(textBoxRect.Width, Integer), fmt)
                ' Draw the title
                Dim r3 As RectangleF = textBoxRect
                r3.Height = size.Height
                path = GetRoundedRect(r3, 15)

                If IsOptionShow = True Then 'hai:backcolor of partname
                    If part.Enable Then
                        g.FillPath(Brushes.DarkKhaki, path)
                    Else
                        g.FillPath(Brushes.DarkGray, path)
                    End If
                Else
                    Dim HeaderColow As Brush = DesignColor(part.EndDevice)
                    g.FillPath(HeaderColow, path)
                End If

                g.DrawString(txt, uFont, HeaderTextBrush, textBoxRect, fmt)
                textBoxRect.Y += size.Height + 5
            End Using

            'Draw the other bits of information
            Using uFont As Font = New Font("Tahoma", 10)
                Dim size As SizeF = g.MeasureString("Wj", uFont, itemBounds.Width, fmt)
                textBoxRect.Height = size.Height
                fmt.Alignment = StringAlignment.Near
                If IsOptionShow = True Then
                    If part.Enable Then
                        txt = "Count: " + part.SupplyCount.ToString + "/" + part.target.ToString
                        g.DrawString(txt, uFont, TextBrush, textBoxRect, fmt)
                        textBoxRect.Y += size.Height
                        If part.AGVSupply = "" Then
                            If part.Status = False Then
                                txt = "Empty time: " + Math.Round((Now - part.EmptyTime).TotalSeconds).ToString() + "s"
                                g.DrawString(txt, uFont, Brushes.DarkRed, textBoxRect, fmt)
                                textBoxRect.Y += size.Height
                            Else
                                txt = "Full time: " + Math.Round((Now - part.FullTime).TotalSeconds).ToString() + "s"
                                g.DrawString(txt, uFont, Brushes.DarkGreen, textBoxRect, fmt)
                                textBoxRect.Y += size.Height
                            End If
                            txt = "Cycle time: " + part.CycleTime.ToString + "s"
                            g.DrawString(txt, uFont, TextBrush, textBoxRect, fmt)
                        Else
                            txt = "AGV: " + part.AGVSupply
                            g.DrawString(txt, uFont, Brushes.DarkGreen, textBoxRect, fmt)
                            textBoxRect.Y += size.Height
                            txt = "Supply time: " + Math.Round((Now - part.SupplyTime).TotalSeconds).ToString() + "s"
                            g.DrawString(txt, uFont, Brushes.DarkBlue, textBoxRect, fmt)
                            textBoxRect.Y += size.Height
                        End If
                    End If
                Else                                                'show setting
                    'End
                    If RequestRouteConcept = "Normal" Then
                        txt = "End:" & part.EndDevice & "." & part.NumberInEnd.ToString & "|" & Conversion.Hex(part.parent.Address)
                    End If

                    g.DrawString(txt, uFont, TextBrush, textBoxRect, fmt)
                    textBoxRect.Y += size.Height
                    'host				
                    txt = "Host:" + part.parent.Host.ToString   '"Host: " & index
                    If RequestRouteConcept = "Normal" Then
                        If IsNothing(part.parent.myXbee.port) = False Then
                            txt = txt & "|" & part.parent.myXbee.port.PortName
                        Else
                            txt = txt & "|No port"
                        End If
                    Else
                        txt = txt & "|Text"
                    End If
                    g.DrawString(txt, uFont, TextBrush, textBoxRect, fmt)
                    textBoxRect.Y += size.Height
                    'CH and ID
                    If RequestRouteConcept = "Normal" Then
                        txt = "CH:" & Conversion.Hex(part.parent.myXbee.CH) & "|ID:" & Conversion.Hex(part.parent.myXbee.ID)
                    Else
                        txt = "Text"
                    End If
                    g.DrawString(txt, uFont, TextBrush, textBoxRect, fmt)
                    textBoxRect.Y += size.Height
                End If
            End Using
        End Sub
        Private Function GetRoundedRect(rect As RectangleF, diameter As Single) As Drawing2D.GraphicsPath
            Dim path As Drawing2D.GraphicsPath = New Drawing2D.GraphicsPath()

            Dim arc As RectangleF = New RectangleF(rect.X, rect.Y, diameter, diameter)
            path.AddArc(arc, 180, 90)
            arc.X = rect.Right - diameter
            path.AddArc(arc, 270, 90)
            arc.Y = rect.Bottom - diameter
            path.AddArc(arc, 0, 90)
            arc.X = rect.Left
            path.AddArc(arc, 90, 90)
            path.CloseFigure()

            Return path
        End Function
        Private Function CalcImgFile(part As CPart) As String
            If part.Enable Then
                If part.parent.connecting Then
                    If part.AGVSupply = "" Then
                        Return part.Status.ToString + "-Connecting"
                    Else
                        Return "AGV-Connecting"
                    End If
                Else
                    If part.AGVSupply = "" Then
                        Return part.Status.ToString + "-Disconnecting"
                    Else
                        Return "AGV-Disconnecting"
                    End If
                End If
            Else
                Return "disable"
            End If
        End Function
    End Class

    Public Sub DisplayPart()
        'olvPart.View = View.Tile
        olvPart.OwnerDraw = True
        InitializeOlvPart(PartList)
    End Sub

#End Region
    Public Sub DisplayOverView()
        olvPart.Sorting = Windows.Forms.SortOrder.Ascending
        'olvAGV.BuildList()
        'olvPart.BuildList()
        'Refresh()
        olvAGV.Refresh()
        olvPart.Refresh()

    End Sub
#End Region
#Region "Display Chart"  'chart size = 1863, 952
    Public Sub ChartAddSeries(ByVal name As String, ByVal SeriesColor As Color, Optional hatchStyle As ChartHatchStyle = ChartHatchStyle.None)
        Dim mySeries As Series = New Series()
        mySeries.ChartArea = "ChartArea1"
        mySeries.Legend = "Legend1"
        mySeries.Name = name
        mySeries.ChartType = SeriesChartType.StackedColumn
        mySeries.IsValueShownAsLabel = True
        mySeries.Color = SeriesColor
        mySeries.BackHatchStyle = hatchStyle
        mySeries.LabelFormat = "F1"
        mySeries.LabelToolTip = "#SERIESNAME:\nAGV name: #AXISLABEL"
        agvChart.Series.Add(mySeries)
        agvChart.Series(name).XValueMember = "Name"
        agvChart.Series(name).YValueMembers = name
    End Sub
    Public Sub ChartInit()
        agvChart.Name = "Chart1"
        agvChart.TabIndex = 0
        agvChart.Text = "Chart1"
        agvChart.DataSource = ChartDataTable

        ChartAddSeries("Out line", Color.BlueViolet)
        ChartAddSeries("Pole error", Color.Olive)
        ChartAddSeries("Battery empty", Color.SteelBlue)
        ChartAddSeries("No cart", Color.Pink)
        ChartAddSeries("EMG", Color.Red, ChartHatchStyle.Percent05)
        ChartAddSeries("Safety", Color.Orange)
        ChartAddSeries("Free", Color.GreenYellow)
        ChartAddSeries("Stop", Color.Yellow)
        ChartAddSeries("Normal", Color.Green)
        ChartAddSeries("Disconnect", Color.Gray)
        ChartAddSeries("Shutdown", Color.Gray, ChartHatchStyle.Percent70)
        agvChart.ChartAreas(0).AxisX.Interval = 1
    End Sub

    Public Sub UpdateChart()
        agvChart.Series("EMG").Points.Clear()
        agvChart.Series("Safety").Points.Clear()
        agvChart.Series("Stop").Points.Clear()
        agvChart.Series("Out line").Points.Clear()
        agvChart.Series("Battery empty").Points.Clear()
        agvChart.Series("No cart").Points.Clear()
        agvChart.Series("Normal").Points.Clear()
        agvChart.Series("Free").Points.Clear()
        agvChart.Series("Disconnect").Points.Clear()
        agvChart.Series("Pole error").Points.Clear()
        agvChart.Series("Shutdown").Points.Clear()
        agvChart.DataSource = ""
        agvChart.DataSource = ChartDataTable



    End Sub

    Private Sub agvChart_MouseDown(sender As Object, e As MouseEventArgs) Handles agvChart.MouseDown
        Dim result As HitTestResult = agvChart.HitTest(e.X, e.Y)
        If result.ChartElementType = ChartElementType.DataPoint Then
            Dim dp As DataPoint = CType(result.Object, DataPoint)

            Dim agvName As String = dp.AxisLabel
            Dim agvNum As Integer
            For agvNum = 0 To AGVList.Count - 1
                If AGVList(agvNum).Name = agvName Then
                    Exit For
                End If
            Next
            panelDetail.Show()

            Dim shutdown As Double = Math.Round(Convert.ToDouble(ChartDataTable.Rows(agvNum)("Shutdown")), 1)
            Dim disconnect As Double = Math.Round(Convert.ToDouble(ChartDataTable.Rows(agvNum)("Disconnect")), 1)
            Dim normal As Double = Math.Round(Convert.ToDouble(ChartDataTable.Rows(agvNum)("Normal")), 1)
            Dim safety As Double = Math.Round(Convert.ToDouble(ChartDataTable.Rows(agvNum)("Safety")), 1)
            Dim emg As Double = Math.Round(Convert.ToDouble(ChartDataTable.Rows(agvNum)("EMG")), 1)
            Dim outline As Double = Math.Round(Convert.ToDouble(ChartDataTable.Rows(agvNum)("Out line")), 1)
            Dim batterylow As Double = Math.Round(Convert.ToDouble(ChartDataTable.Rows(agvNum)("Battery empty")), 1)
            Dim poleerror As Double = Math.Round(Convert.ToDouble(ChartDataTable.Rows(agvNum)("Pole error")), 1)
            Dim stops As Double = Math.Round(Convert.ToDouble(ChartDataTable.Rows(agvNum)("Stop")), 1)
            Dim free As Double = Math.Round(Convert.ToDouble(ChartDataTable.Rows(agvNum)("Free")), 1)
            Dim nocart As Double = Math.Round(Convert.ToDouble(ChartDataTable.Rows(agvNum)("No cart")), 1)
            Dim total As Double = shutdown + disconnect + normal + safety + emg + outline + batterylow + poleerror + stops + free + nocart

            LabelTotal.Text = total.ToString
            LabelAgvDetail.Text = agvName
            LabelShutdown.Text = shutdown.ToString
            LabelDisconnect.Text = disconnect.ToString
            LabelNormal.Text = normal.ToString
            LabelSafety.Text = safety.ToString
            LabelEMG.Text = emg.ToString
            LabelOutLine.Text = outline.ToString
            LabelBatteryLow.Text = batterylow.ToString
            LabelPoleErr.Text = poleerror.ToString
            LabelStop.Text = stops.ToString
            LabelFree.Text = free.ToString
            LabelNoCart.Text = nocart.ToString
        Else
            panelDetail.Hide()
        End If
    End Sub
#End Region
#Region "Display Map"
    Private Sub Display_Map()
        Dim IsError As Boolean = False
        If File.Exists(".\map\map.jpg") = False Then
            If Tab_start = 2 Then
                MsgBox("không có file ảnh")
            End If
            IsError = True
        End If
        If File.Exists(".\map\MapExport.csv") = False Then
            If Tab_start = 2 Then
                MsgBox("không có file csv")
            End If
            IsError = True
        End If

        If IsError = False Then
            PictureBoxMap.Visible = True
            PictureBoxMap.SizeMode = PictureBoxSizeMode.StretchImage
            PictureBoxMap.Image = System.Drawing.Image.FromFile(".\map\map.jpg")
            Read_CsvData()
            init_MapAGV()
            init_MapPart()
            TimerAndonMap.Start()
        End If
    End Sub

    Private Sub TimerAndonMap_Tick(sender As Object, e As EventArgs) Handles TimerAndonMap.Tick
        Static blink As Boolean
        Dim needToAlarm As Boolean = False

        Dim txt As String = ""
        For i As Byte = 1 To AGVMapDisplayCollection.Count
            Select Case CType(AGVMapDisplayCollection(i), MapAGV).RunningStatus
                Case AGV.RobocarStatusValue.BATTERY_EMPTY, AGV.RobocarStatusValue.EMERGENCY, AGV.RobocarStatusValue.OUT_OF_LINE
                    If (CType(AGVMapDisplayCollection(i), MapAGV).Connecting = True And CType(AGVMapDisplayCollection(i), MapAGV).Used = True) Then
                        needToAlarm = True
                        txt = txt + vbCrLf + CType(AGVMapDisplayCollection(i), MapAGV).AGVName + " " + CType(AGVMapDisplayCollection(i), MapAGV).RunningStatus.ToString
                    End If
            End Select
        Next

        If needToAlarm Then
            If blink Then
                PanelAlarm.BackColor = Color.Yellow
                blink = False
            Else
                PanelAlarm.BackColor = Color.Red
                blink = True
            End If
        Else
            PanelAlarm.BackColor = Color.Transparent
        End If
        LabelAlarm.Text = txt
    End Sub

#Region "Drawing map"
    Private Sub AligToolStripMenuHorisontal(sender As Object, e As EventArgs) Handles AligToolStripMenuItem.Click
        For Each part As MapPart In PartForAlign
            part.Top = PartForAlign(0).Top
        Next
    End Sub

    Private Sub AlignCenterToolStripMenuVertical(sender As Object, e As EventArgs) Handles AlignCenterToolStripMenuItem.Click
        For Each part As MapPart In PartForAlign
            part.Left = PartForAlign(0).Left
        Next
    End Sub
    Private Sub CustomizeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomizeToolStripMenuItem.Click
        If IsReadOnlyMap Then
            CustomizeToolStripMenuItem.Text = "Save map"
            IsReadOnlyMap = False
        Else
            CustomizeToolStripMenuItem.Text = "Enable edit map"
            IsReadOnlyMap = True
            MapUpdate()
        End If
    End Sub
    Private Sub PictureBoxMap_DoubleClick(sender As Object, e As EventArgs) Handles PictureBoxMap.DoubleClick
        For Each part As MapPart In PartForAlign
            part.BorderStyle = BorderStyle.None
        Next
        PartForAlign.Clear()
    End Sub
    Dim canResize As Boolean
    Public rect As Rectangle = New Rectangle()
    Dim X As Integer
    Dim Y As Integer
    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBoxMap.MouseMove
        If canResize = False Then Return

        If X < e.X Then 'mouse move to right
            rect.X = X
            rect.Width = e.X - X
        Else            'mouse move to left
            rect.X = e.X
            rect.Width = X - e.X
        End If

        If Y < e.Y Then 'mose move down
            rect.Y = Y
            rect.Height = e.Y - Y
        Else            'mose move up
            rect.Y = e.Y
            rect.Height = Y - e.Y
        End If
        If My.Computer.Keyboard.CtrlKeyDown Then
            rect.Height = rect.Width
        End If
        '///////////////////////////////////////
        'CheckContain()
        'For item As Byte = 1 To MapPartList.Count
        '	If e.X > MapPartList(item).Left And
        '		e.X < MapPartList(item).Left + MapPartList(item).Width And
        '		e.Y > MapPartList(item).Top And
        '		e.Y < MapPartList(item).Top + MapPartList(item).Height Then
        '		MapPartList(item).BackColor = Color.Red
        '	End If
        'Next

        Refresh()

    End Sub
    Private Sub CheckContain()
        For item As Byte = 1 To MapPartList.Count
            For pos As Byte = 0 To 3
                If (rect.Left < MapPartList(item).Pick(pos).X) And
                    (rect.Left + rect.Width > MapPartList(item).Pick(pos).X) And
                    (rect.Top < MapPartList(item).Pick(pos).Y) And
                    (rect.Top + rect.Height > MapPartList(item).Pick(pos).Y) Then
                    MapPartList(item).BackColor = Color.Red

                End If
            Next
        Next
    End Sub
    Private Sub Form1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBoxMap.MouseUp
        canResize = False
        rect.Height = 0
        rect.Width = 0
        Refresh()
    End Sub
    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBoxMap.MouseDown
        canResize = True
        X = e.X
        Y = e.Y
        rect.Location = New Point(X, Y)
    End Sub
    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBoxMap.Paint
        Dim blackPen As New Pen(Color.Black, 1)
        e.Graphics.DrawRectangle(blackPen, rect)
    End Sub
#End Region

    Private Sub init_MapPart()
        MapPartList = New List(Of MapPart)
        PartForAlign = New List(Of MapPart)
        For i As Integer = 0 To PartList.Count - 1
            Dim Part As MapPart = New MapPart(MapPartWidth, MapPartHeight, IsVerticalPart)
            PictureBoxMap.Controls.Add(Part)
            Part.setDataBinding(PartList(i))
            'Part.Size = New Size(MapPartWidth, MapPartHeight)
            Part.Location = New Point(PartList(i).X, PartList(i).Y)
            Part.PartName = PartList(i).Name + "(" + PartList(i).route.ToString + ")"
            MapPartList.Add(Part)
        Next
    End Sub
    'Display AGV
    Public WithEvents AGVMapDisplayCollection As Collection = New Collection
    Public Sub init_MapAGV()
        For i As Integer = 0 To AGVList.Count - 1
            Dim AGV As MapAGV = New MapAGV
            AGV.setDataBinding(AGVList(i))
            PictureBoxMap.Controls.Add(AGV)
            AGV.ID = i
            AGVMapDisplayCollection.Add(AGV)
            AGV.Size = New Size(46, 20)
            AddHandler AGV.DetectNewCard, AddressOf AddNotExistCard
        Next
    End Sub

    Public Sub AddNotExistCard(ByVal cardID As Integer)
        Dim str As String = "Not exist card: "
        Dim ListCard As String = ""
        'TOCHECK: Lần nào có thẻ mới là chương trình lại phải quét lại toàn bộ mảng CollectNotExistCard à? cái nào có mới thì mới update
        For i As Integer = 1 To CollectNotExistCard.Count
            If i = 1 Then                                           'Bo qua dau "," voi the dau tien
                ListCard = ListCard & CollectNotExistCard(1)
            Else
                ListCard = ListCard & ", " & CollectNotExistCard(i)
            End If
        Next

        str = str & ListCard
        LabelCardNotExit.Visible = True
        LabelCardNotExit.Text = str
        LabelCardNotExit.Location = New Point(2, PictureBoxMap.Height - 18)
    End Sub

    'Read data
    Private Sub Read_CsvData()
        Dim fStream As New System.IO.FileStream(".\map\MapExport.csv", IO.FileMode.Open)
        Dim sReader As New System.IO.StreamReader(fStream)

        Do While sReader.Peek >= 0
            Dim data As String
            Dim key As String
            data = sReader.ReadLine
            Dim TempArray() As String = Split(data, ",")
            key = TempArray(1).ToString

            Dim result As Integer
            If Integer.TryParse(TempArray(1), result) Then              'card
                If MapAGVList.Contains(key) Then
                    MsgBox("có thẻ trùng ID " & key)
                Else
                    Dim CardLabel As Label = New System.Windows.Forms.Label()
                    CardLabel.Text = TempArray(1)
                    CardLabel.TextAlign = ContentAlignment.MiddleCenter
                    CardLabel.AutoSize = True
                    CardLabel.Visible = False
                    CardLabel.BackColor = Color.Yellow
                    PictureBoxMap.Controls.Add(CardLabel)
                    CardLabel.Location = New Point(TempArray(2), TempArray(3))
                    MapAGVList.Add(CardLabel, key)
                End If
            ElseIf (key = "map") Then                                   'map size
                Map_High = TempArray(4)
                Map_Width = TempArray(5)
                'Else														'part
                '	If Collect_Part.Contains(key) Then
                '		MsgBox("có tên part trùng nhau")
                '	Else
                '		Dim PartLabel As MapPart = New MapPart()
                '		PartLabel.Name = key
                '		PictureBoxMap.Controls.Add(PartLabel)
                '		PartLabel.Location = New Point(TempArray(2), TempArray(3))
                '		Collect_Part.Add(PartLabel, key)
                '	End If
            End If
        Loop
        fStream.Close()
        sReader.Close()

        'Card
        For i As Integer = 1 To MapAGVList.Count
            Dim X As Integer = CType(MapAGVList(i), Label).Location.X
            Dim Y As Integer = CType(MapAGVList(i), Label).Location.Y
            analyse_location(X, Y)
            X = X - CType(MapAGVList(i), Label).Width / 2
            Y = Y - CType(MapAGVList(i), Label).Height / 2
            CType(MapAGVList(i), Label).Location = New Point(X, Y)
        Next

        '--------------------convert KEY Part from Name to ID of Database----------------------------------
        'For i As Integer = 0 To PartList.Count - 1
        '	Dim temp As Boolean = False
        '	For j As Integer = 1 To Collect_Part.Count
        '		If PartList(i).Name.Replace(" ", "").ToUpper = CType(Collect_Part(j), MapPart).Name.Replace(" ", "").ToUpper Then
        '			Collect_Part.Add(Collect_Part(j), i + 1)
        '			Collect_Part.Remove(j)
        '			temp = True
        '			Exit For
        '		End If
        '	Next
        '	If temp = False Then
        '		MsgBox("kiểm tra lại: " & PartList(i).Name)
        '	End If
        'Next
    End Sub

    'Analyse location
    Private Sub analyse_location(ByRef X As Integer, ByRef Y As Integer)
        Dim X10, X11, X12, X20, X21, X22 As Integer
        Dim Y10, Y11, Y12, Y20, Y21, Y22 As Integer
        Dim X0 As Int16 = X
        Dim Y0 As Int16 = Y

        X10 = X0
        X11 = 0
        X12 = Map_Width
        X21 = PictureBoxMap.Location.X
        X22 = X21 + PictureBoxMap.Width

        Y10 = Y0
        Y11 = 0
        Y12 = Map_High
        Y21 = PictureBoxMap.Location.Y
        Y22 = Y21 + PictureBoxMap.Height

        X20 = X21 + (X10 - X11) * (X22 / X12)
        Y20 = Y21 + (Y10 - Y11) * (Y22 / Y12)
        X = X20 ' - Label1.Width / 2
        Y = Y20 ' - Label1.Height / 2
    End Sub
    'Find AGV
    Private Sub SearchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SearchToolStripMenuItem.Click, ButtonFindAGV.Click
        Dim tempAGV As String = InputBox("Nhập AGV cần tìm", "Find AGV").Replace(" ", "").ToUpper
        For i As Byte = 1 To AGVMapDisplayCollection.Count
            If CType(AGVMapDisplayCollection(i), MapAGV).LabelName.Text.ToUpper.Replace(" ", "") = tempAGV Then
                CType(AGVMapDisplayCollection(i), MapAGV).DisplayWhenFind()
            End If
        Next
    End Sub
    'show all card
    Public isShowCard As Boolean = False
    Private Sub ShowAllCardToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ShowAllCardToolStripMenuItem1.Click
        ShowAllCard()
        isShowCard = Not isShowCard
    End Sub
    Private Sub ShowAllCard()
        If isShowCard = True Then
            ShowAllCardToolStripMenuItem1.Text = "Show all card"
            For i As Integer = 1 To MapAGVList.Count
                CType(MapAGVList(i), Label).Visible = False
            Next
        Else
            ShowAllCardToolStripMenuItem1.Text = "Hide all card"
            For i As Integer = 1 To MapAGVList.Count
                CType(MapAGVList(i), Label).Visible = True
            Next
        End If
    End Sub

    'Public Sub UpdateDisplayPart()
    '	For i As Integer = 1 To MapPartList.Count
    '		Select Case CType(MapPartList(i), Label).BackColor
    '			Case Color.GreenYellow														'before status is FULL
    '				If PartList(i - 1).Status <> True Then									'now is EMPTY
    '					If PartList(i - 1).AGVSupply <> "" Then
    '						CType(MapPartList(i), Label).BackColor = Color.Yellow			'if do not have AGV supply
    '					Else
    '						CType(MapPartList(i), Label).BackColor = Color.Red				'if have AGV supply
    '					End If
    '				End If
    '			Case Color.Red																'before status is Empty
    '				If PartList(i - 1).Status = True Then
    '					CType(MapPartList(i), Label).BackColor = Color.GreenYellow			'now is FULL
    '				End If
    '			Case Color.Yellow															'now is being SUPPLY

    '			Case Else

    '		End Select
    '	Next
    'End Sub
#End Region
    '//////////////////////////////////////////////////////////////////////////////////////////
    Private Sub CrossTimer_Tick(sender As Object, e As EventArgs) Handles CrossTimer.Tick
        If Not DoCrossThread.IsAlive Then
            DoCrossThread = New Thread(AddressOf DoCrossFunc)
            DoCrossThread.Name = "Cross Thread"
            DoCrossThread.Start()
        End If
    End Sub

    ''' <summary>
    ''' Timer for auto save chart data
    ''' </summary>
    ''' <remarks>This timer interrupt each 60000ms (1 min)</remarks>
    Private Sub AutoSaveTimer_Tick(sender As Object, e As EventArgs) Handles AutoSaveTimer.Tick
        If Not SaveThread.IsAlive Then
            SaveThread = New Thread(AddressOf ChartUpdateXml)
            SaveThread.Name = "Save Thread"
            SaveThread.Start()
        End If
    End Sub

    ''' <summary>
    ''' Timer for record part and AGV information
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RecordTimer_Tick(sender As Object, e As EventArgs) Handles RecordTimer.Tick
        If Not RecordThread.IsAlive Then
            RecordThread = New Thread(AddressOf RecordData)
            RecordThread.Name = "Save Thread"
            RecordThread.Start()
        End If
    End Sub

    Private Sub AndonTimer_Tick(sender As Object, e As EventArgs) Handles AndonTimer.Tick
        Static AlarmCounter() As Byte = New Byte(AGVList.Count - 1) {}
        Static PreStatusForAndon() As AGV.RobocarStatusValue = New AGV.RobocarStatusValue(AGVList.Count - 1) {}
        Static blind As Boolean = False
        For i As Byte = 0 To AGVList.Count - 1
            If PreStatusForAndon(i) <> AGVList(i).Status Then
                AlarmCounter(i) = 0
                PreStatusForAndon(i) = AGVList(i).Status
            ElseIf isAndonAlarmCondition(PreStatusForAndon(i)) And AlarmCounter(i) < 100 Then 'AlarmCounter(i) < 100: avoid overflow byte 255
                AlarmCounter(i) += 1
            End If
        Next
        needAlarm = False
        For i As Byte = 0 To AGVList.Count - 1
            If AlarmCounter(i) > 10 Then    'If time > AndonTime.interval * 10 then needAlarm
                needAlarm = True
                Exit For
            End If
        Next
        If needAlarm Then
            If blind Then
                olvAGV.BackColor = Color.Red
            Else
                olvAGV.BackColor = Color.Yellow
            End If
            blind = Not blind
        Else
            olvAGV.BackColor = Color.White
        End If
    End Sub
    Private Function isAndonAlarmCondition(ByVal value As AGV.RobocarStatusValue) As Boolean
        If value = AGV.RobocarStatusValue.BATTERY_EMPTY Or value = AGV.RobocarStatusValue.EMERGENCY Or value = AGV.RobocarStatusValue.NO_CART Or value = AGV.RobocarStatusValue.OUT_OF_LINE Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub MainMenuSetting_Click(sender As Object, e As EventArgs) Handles MainMenuSetting.Click
        Try
            System.Diagnostics.Process.Start("Control System setting.exe")
        Catch
        End Try
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        About.ShowDialog()
    End Sub


    Private Sub UserSettingToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Try
            System.Diagnostics.Process.Start("User Setting.exe")
        Catch
        End Try
    End Sub

    Private Sub VitualAGVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VitualAGVToolStripMenuItem.Click
        Dim vitual As New VitualAGV
        Dim rbc As AGV = CType(olvAGV.SelectedObject, AGV)
        rbc.VitualMode = True
        vitual.Text = "Vitual " & rbc.Name
        vitual.Address = rbc.Address
        vitual.myAGV = rbc
        vitual.Show()
    End Sub

    Private Sub CrossViewToolStripMenuItem1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub VitualPartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VitualPartToolStripMenuItem.Click
        Dim vitual As New VitualPart
        Dim part As CPart = CType(olvPart.SelectedObject, CPart)
        vitual.Text = "Vitual " & part.Name 'tocheck: part=nothing, name = MainForm
        part.parent.VitualMode = True
        vitual.myPart = part
        vitual.Show()
    End Sub

    Private Sub SplitContainerOverView_SplitterMoving(sender As Object, e As SplitterCancelEventArgs) Handles SplitContainerOverView.SplitterMoving
        Settings.SplitDistance = SplitContainerOverView.SplitterDistance
        Settings.Save()
    End Sub

    Private Sub DebugFormToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DebugModeToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DebugModeToolStripMenuItem.Click
        If DebugMode = True Then
            DebugMode = False
            DebugModeToolStripMenuItem.Text = "Debug mode"
        Else
            DebugMode = True
            DebugModeToolStripMenuItem.Text = "Normal mode"
        End If
    End Sub

    Private Sub RequestFormToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RequestFormToolStripMenuItem.Click
        If IsNothing(RequestForm) Then
            RequestForm = New SupplyForm()
        Else
            RequestForm.Close()
        End If
        RequestForm = New SupplyForm()
        RequestForm.Visible = True
        RequestForm.TopMost = True
    End Sub

    Private Sub CrossViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CrossViewToolStripMenuItem.Click
        CrossView.Show()
    End Sub

    Private Sub DebugFormToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DebugFormToolStripMenuItem1.Click
        DebugForm = New CDebug_Form
        IsAllowPrintDebug = True
        DebugForm.Show()
    End Sub

    Private Sub ForceUploadToServerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ForceUploadToServerToolStripMenuItem.Click
        UploadToServer()
    End Sub
End Class
