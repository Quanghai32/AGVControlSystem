﻿Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms.DataVisualization.Charting

Imports ControlSystemLibrary
Imports System.Threading
Imports BrightIdeasSoftware
Imports System.IO

Public Class MainForm
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReadStartData()
        SetupHostXbee()

        DisplayAGV()
        DisplayPart()

        If isNeedToReset Then
            ChartResetSQL()
        End If
        ChartInit()

        DisplayTimer.Start()
        CrossTimer.Start()
        AutoSaveTimer.Start()
        RecordTimer.Start()
        AndonTimer.Start()
        'CrossView.Show()
    End Sub

    Private Sub MainForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        TabControl1.Dock = DockStyle.Fill
        'TableLayoutPanel1.Dock = DockStyle.Fill
    End Sub
    Private Sub DisplayTimer_Tick(sender As Object, e As EventArgs) Handles DisplayTimer.Tick
        DisplayTimer.Stop()
        Select Case TabControl1.SelectedIndex
            Case 0
                DisplayOverView()
            Case 1
                UpdateChart()
        End Select
        If Not RequestThread.IsAlive Then
            RequestThread = New Thread(AddressOf RequestData)
            RequestThread.Name = "Request Thread"
            RequestThread.Start()
        End If
        If Not UpdateThread.IsAlive Then
            UpdateThread = New Thread(AddressOf UpdateData)
            UpdateThread.Name = "Update Thread"
            UpdateThread.Start()
        End If
        DisplayTimer.Start()
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
        ElseIf olvAGV.SelectedIndices.Count = 1 Then
            MenuAGVView.Visible = False
            MenuAGVConfirmConn.Visible = True
            MenuAGVConfirmSelected.Enabled = True
            MenuAGVConfirmAll.Enabled = True
            MenuAGVEnable.Visible = True
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
        End If
        'If My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator) Then
        '    MenuAGVEnable.Enabled = True
        'Else
        '    MenuAGVEnable.Enabled = False
        'End If
    End Sub
    Private Sub MenuAGVView_Click(sender As Object, e As EventArgs) Handles MenuAGVViewLargeIcon.Click, MenuAGVViewDetails.Click, MenuAGVViewList.Click, MenuAGVViewSmallIcon.Click, MenuAGVViewTile.Click, MenuAGVViewDetails.Click
        If sender.Equals(MenuAGVViewTile) Then
            olvAGV.View = View.Tile
            Return
        End If
        If sender.Equals(MenuAGVViewList) Then
            olvAGV.View = View.List
            Return
        End If
        If sender.Equals(MenuAGVViewSmallIcon) Then
            olvAGV.View = View.SmallIcon
            Return
        End If
        If sender.Equals(MenuAGVViewDetails) Then
            olvAGV.View = View.Details
            Return
        End If
        If sender.Equals(MenuAGVViewLargeIcon) Then
            olvAGV.View = View.LargeIcon
            Return
        End If
    End Sub
    Private Sub ForSelectedAGVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenuAGVConfirmSelected.Click
        Dim AGVSelectedCollection As ArrayList = olvAGV.SelectedObjects
        For i As Byte = 0 To AGVSelectedCollection.Count - 1
            Dim AGVIndex As AGV = CType(AGVSelectedCollection(i), AGV)
            AGVIndex.SetHostAddress()
        Next
    End Sub
    Private Sub MenuAGVEnable_Click(sender As Object, e As EventArgs) Handles MenuAGVEnable.Click
        Dim rbc As AGV = CType(olvAGV.SelectedObject, AGV)
        rbc.Enable = Not rbc.Enable
        Dim cmdValue As String = Convert.ToByte(rbc.Enable)
        Dim cmdWhere As String = rbc.Name

        Dim cmdText As String = "UPDATE AGV SET Enable=" + cmdValue + " WHERE Name='" + cmdWhere + "'"
        Dim cmdUpdate As SqlCommand = New SqlCommand(cmdText, SQLcon)
        cmdUpdate.ExecuteNonQuery()
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
            DrawAGV(g, itemBounds, rowObject, olv, CType(e.Item, OLVListItem))

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

        Public Sub DrawAGV(g As Graphics, itemBounds As Rectangle, rowObject As Object, olv As ObjectListView, item As OLVListItem)
            Const spacing As Integer = 8

            ' Allow a border around the card
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
                photoRect.Width = 80
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
            fmt.Alignment = StringAlignment.Center
            fmt.LineAlignment = StringAlignment.Near
            Dim txt As String = rbc.Name

            Using uFont As Font = New Font("Tahoma", 11)
                ' Measure the height of the title
                Dim size As SizeF = g.MeasureString(txt, uFont, CType(textBoxRect.Width, Integer), fmt)
                ' Draw the title
                Dim r3 As RectangleF = textBoxRect
                r3.Height = size.Height
                path = GetRoundedRect(r3, 15)
                If rbc.Enable Then
                    g.FillPath(Brushes.DarkKhaki, path)
                Else
                    g.FillPath(Brushes.DarkGray, path)
                End If
                g.DrawString(txt, uFont, HeaderTextBrush, textBoxRect, fmt)
                textBoxRect.Y += size.Height + 5
            End Using
            If rbc.Enable Then
                'Draw the other bits of information
                Using uFont As Font = New Font("Tahoma", 11)
                    Dim size As SizeF = g.MeasureString("Wj", uFont, itemBounds.Width, fmt)
                    textBoxRect.Height = size.Height
                    fmt.Alignment = StringAlignment.Near
                    If rbc.SupplyPartStatus > PartList.Count Then
                        txt = "Part: " + "Unknown" + " (" + rbc.SupplyPartStatus.ToString + ")"
                    Else
                        txt = "Part: " + PartList(rbc.SupplyPartStatus).Name + " (" + rbc.SupplyPartStatus.ToString + ")"
                    End If
                    g.DrawString(txt, uFont, TextBrush, textBoxRect, fmt)
                    textBoxRect.Y += size.Height

                    txt = "Position: " + CType(rowObject, AGV).Position.ToString
                    g.DrawString(txt, uFont, TextBrush, textBoxRect, fmt)
                    textBoxRect.Y += size.Height
                    Dim value = rbc.BatteryPercent()
                    txt = "Battery: " + value.ToString + "%"
                    If value < 25 Then
                        g.DrawString(txt, uFont, Brushes.DarkRed, textBoxRect, fmt)
                    Else
                        g.DrawString(txt, uFont, TextBrush, textBoxRect, fmt)
                    End If
                    textBoxRect.Y += size.Height
                End Using
            End If
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
        olvAGV.View = View.Tile
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
        ElseIf olvPart.SelectedIndices.Count = 1 Then
            MenuPartView.Visible = False
            MenuPartConfirmConn.Visible = True
            MenuPartConfirmSelected.Enabled = True
            MenuPartConfirmAll.Enabled = True
            MenuPartEnable.Visible = True
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
        End If
        'If My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator) Then
        '    MenuPartEnable.Enabled = True
        'Else
        '    MenuPartEnable.Enabled = False
        'End If
    End Sub
    Private Sub MenuPartViewItem_Click(sender As Object, e As EventArgs) Handles MenuPartViewLargeIcon.Click, MenuPartViewDetail.Click, MenuPartViewSmallIcon.Click, MenuPartViewList.Click, MenuPartViewTile.Click
        If sender.Equals(MenuPartViewTile) Then
            olvPart.View = View.Tile
            Return
        End If
        If sender.Equals(MenuPartViewList) Then
            olvPart.View = View.List
            Return
        End If
        If sender.Equals(MenuPartViewSmallIcon) Then
            olvPart.View = View.SmallIcon
            Return
        End If
        If sender.Equals(MenuPartViewDetail) Then
            olvPart.View = View.Details
            Return
        End If
        If sender.Equals(MenuPartViewLargeIcon) Then
            olvPart.View = View.LargeIcon
            Return
        End If
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
    Private Sub MenuPartEnable_Click(sender As Object, e As EventArgs) Handles MenuPartEnable.Click
        Dim PartIndex As Byte = CType(olvPart.SelectedObject, CPart).index
        PartList(PartIndex).Enable = Not PartList(PartIndex).Enable
        Dim cmdValue As String = Convert.ToByte(PartList(PartIndex).Enable)
        Dim cmdWhere As String = PartIndex.ToString

        Dim cmdText As String = "UPDATE Part SET Enable=" + cmdValue + " WHERE ID=" + cmdWhere
        Dim cmdUpdate As SqlCommand = New SqlCommand(cmdText, SQLcon)
        cmdUpdate.ExecuteNonQuery()
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
            DrawPart(g, itemBounds, rowObject, olv, CType(e.Item, OLVListItem))

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
            Dim txt As String = part.Name + " (" + part.index.ToString + ")"

            Using uFont As Font = New Font("Tahoma", 11)
                ' Measure the height of the title
                Dim size As SizeF = g.MeasureString(txt, uFont, CType(textBoxRect.Width, Integer), fmt)
                ' Draw the title
                Dim r3 As RectangleF = textBoxRect
                r3.Height = size.Height
                path = GetRoundedRect(r3, 15)
                If part.Enable Then
                    g.FillPath(Brushes.DarkKhaki, path)
                Else
                    g.FillPath(Brushes.DarkGray, path)
                End If

                g.DrawString(txt, uFont, HeaderTextBrush, textBoxRect, fmt)
                textBoxRect.Y += size.Height + 5
            End Using
            If part.Enable Then
                'Draw the other bits of information
                Using uFont As Font = New Font("Tahoma", 11)
                    Dim size As SizeF = g.MeasureString("Wj", uFont, itemBounds.Width, fmt)
                    textBoxRect.Height = size.Height
                    fmt.Alignment = StringAlignment.Near

                    txt = "Count: " + part.supplyCount.ToString + "/" + part.target.ToString
                    g.DrawString(txt, uFont, TextBrush, textBoxRect, fmt)
                    textBoxRect.Y += size.Height
                    If part.AGVSupply = "" Then
                        If part.Status = False Then
                            txt = "Time: " + Math.Round((Now - part.EmptyTime).TotalSeconds).ToString() + "s"
                            g.DrawString(txt, uFont, Brushes.DarkRed, textBoxRect, fmt)
                            textBoxRect.Y += size.Height
                        End If
                    Else
                        txt = "AGV: " + part.AGVSupply
                        g.DrawString(txt, uFont, Brushes.DarkGreen, textBoxRect, fmt)
                        textBoxRect.Y += size.Height
                    End If
                End Using
            End If
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
        olvPart.View = View.Tile
        olvPart.OwnerDraw = True
        InitializeOlvPart(PartList)
    End Sub
    
#End Region
    Public Sub DisplayOverView()
        olvAGV.BuildList()
        olvPart.BuildList()
    End Sub
#End Region
#Region "Display Chart"
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
        AGVPerformance.Series.Add(mySeries)
        AGVPerformance.Series(name).XValueMember = "Name"
        AGVPerformance.Series(name).YValueMembers = name
    End Sub
    Public Sub ChartInit()
        AGVPerformance.Name = "Chart1"
        AGVPerformance.TabIndex = 0
        AGVPerformance.Text = "Chart1"
        AGVPerformance.DataSource = ChartDataTable

        ChartAddSeries("EMG", Color.Red, ChartHatchStyle.Percent05)
        ChartAddSeries("Out line", Color.Red, ChartHatchStyle.Percent25)
        ChartAddSeries("Battery empty", Color.Red, ChartHatchStyle.Percent50)
        ChartAddSeries("No cart", Color.Red, ChartHatchStyle.Percent70)
        ChartAddSeries("Safety", Color.Orange)
        ChartAddSeries("Stop", Color.Yellow)
        ChartAddSeries("Normal", Color.Green)
        ChartAddSeries("Free", Color.GreenYellow)
        ChartAddSeries("Disconnect", Color.Gray)
    End Sub
    Public Sub UpdateChart()
        AGVPerformance.Series("EMG").Points.Clear()
        AGVPerformance.Series("Safety").Points.Clear()
        AGVPerformance.Series("Stop").Points.Clear()
        AGVPerformance.Series("Out line").Points.Clear()
        AGVPerformance.Series("Battery empty").Points.Clear()
        AGVPerformance.Series("No cart").Points.Clear()
        AGVPerformance.Series("Normal").Points.Clear()
        AGVPerformance.Series("Free").Points.Clear()
        AGVPerformance.Series("Disconnect").Points.Clear()
        AGVPerformance.DataSource = ""
        AGVPerformance.DataSource = ChartDataTable
    End Sub
#End Region

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
            SaveThread = New Thread(AddressOf ChartUpdateSQL)
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
        'Static AlarmCounter() As Byte = New Byte(AGVList.Count - 1) {}
        'Static PreStatusForAndon() As AGV.RobocarStatusValue = New AGV.RobocarStatusValue(AGVList.Count - 1) {}
        'Static blind As Boolean = False
        'For i As Byte = 0 To AGVList.Count - 1
        '    If PreStatusForAndon(i) <> AGVList(i).Status Then
        '        AlarmCounter(i) = 0
        '        PreStatusForAndon(i) = AGVList(i).Status
        '    ElseIf isAndonAlarmCondition(PreStatusForAndon(i)) And AlarmCounter(i) < 200 Then
        '        AlarmCounter(i) += 1
        '    End If
        'Next
        'needAlarm = False
        'For i As Byte = 0 To AGVList.Count - 1
        '    If AlarmCounter(i) > 10 Then
        '        needAlarm = True
        '        Exit For
        '    End If
        'Next
        'If needAlarm Then
        '    If blind Then
        '        olvAGV.BackColor = Color.Red
        '    Else
        '        olvAGV.BackColor = Color.Yellow
        '    End If
        '    blind = Not blind
        'Else
        '    olvAGV.BackColor = Color.White
        'End If
    End Sub
    Private Function isAndonAlarmCondition(ByVal value As AGV.RobocarStatusValue) As Boolean
        If value = AGV.RobocarStatusValue.BATTERY_EMPTY Or value = AGV.RobocarStatusValue.EMERGENCY Or value = AGV.RobocarStatusValue.NO_CART Or value = AGV.RobocarStatusValue.OUT_OF_LINE Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub MainMenuSetting_Click(sender As Object, e As EventArgs) Handles MainMenuSetting.Click
        System.Diagnostics.Process.Start("setting.exe")
    End Sub
End Class
