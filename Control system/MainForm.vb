Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms.DataVisualization.Charting

Imports ControlSystemLibrary
Imports System.Threading

Public Class MainForm
	Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		ReadStartData()
		SetupHostXbee()
		LoadSetting()

		DisplayAGV()
		DisplayPart()
		SetStartViewAGV()

        'Dim ResetType As Byte = isNeedReset()
        'If ResetType <> 0 Then
        '    ChartResetSQL()
        '    SettingReset(ResetType)
        'End If
        If isNeedToReset Then
            ChartResetSQL()
        End If
		ChartInit()
		SetStartViewPart()

		DisplayTimer.Start()
        CrossTimer.Start()
        AutoSaveTimer.Start()
        RecordTimer.Start()
        AndonTimer.Start()
		'CrossView.Show()
	End Sub

	Private Sub MainForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
		TabControl1.Dock = DockStyle.Fill
		TableLayoutPanel1.Dock = DockStyle.Fill
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
    Private Sub MenuLstViewAGV_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MenuLstViewAGV.Opening
        If lstViewAGV.SelectedIndices.Count = 0 Then
            MenuAGVView.Visible = True
            MenuAGVConfirmConn.Visible = True
            MenuAGVConfirmSelected.Enabled = False
            MenuAGVConfirmAll.Enabled = True
            MenuAGVEnable.Visible = False
        ElseIf lstViewAGV.SelectedIndices.Count = 1 Then
            MenuAGVView.Visible = False
            MenuAGVConfirmConn.Visible = True
            MenuAGVConfirmSelected.Enabled = True
            MenuAGVConfirmAll.Enabled = True
            MenuAGVEnable.Visible = True
            If AGVArray(lstViewAGV.SelectedIndices(0)).Enable Then
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
        Dim a = lstViewAGV.Items(0).ToString
    End Sub
    Private Sub MenuAGVView_Click(sender As Object, e As EventArgs) Handles MenuAGVViewLargeIcon.Click, MenuAGVViewDetails.Click, MenuAGVViewList.Click, MenuAGVViewSmallIcon.Click, MenuAGVViewTile.Click, MenuAGVViewDetails.Click
        If sender.Equals(MenuAGVViewTile) Then
            lstViewAGV.View = View.Tile
            Return
        End If
        If sender.Equals(MenuAGVViewList) Then
            lstViewAGV.View = View.List
            Return
        End If
        If sender.Equals(MenuAGVViewSmallIcon) Then
            lstViewAGV.View = View.SmallIcon
            Return
        End If
        If sender.Equals(MenuAGVViewDetails) Then
            lstViewAGV.View = View.Details
            Return
        End If
        If sender.Equals(MenuAGVViewLargeIcon) Then
            lstViewAGV.View = View.LargeIcon
            Return
        End If
    End Sub
    Private Sub ForSelectedAGVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenuAGVConfirmSelected.Click
        Dim listSelected As System.Windows.Forms.ListView.SelectedIndexCollection = lstViewAGV.SelectedIndices
        If listSelected.Count > 0 Then
            For Each index In listSelected
                AGVArray(index).SetHostAddress()
            Next
        End If
    End Sub
    Private Sub MenuAGVEnable_Click(sender As Object, e As EventArgs) Handles MenuAGVEnable.Click
        AGVArray(lstViewAGV.SelectedIndices(0)).Enable = Not AGVArray(lstViewAGV.SelectedIndices(0)).Enable
    End Sub
#End Region
    Public Sub AddColumnAGVDisplay()
        Dim str As String() = New String() {"Name", "Part supply", "Working status", "Position", "Running status", "Connecting", "Battery"}
        For i As Byte = 0 To str.Length - 1
            Dim MyColumnHeader As System.Windows.Forms.ColumnHeader
            MyColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            MyColumnHeader.Text = str(i)
            lstViewAGV.Columns.Add(MyColumnHeader)
        Next
    End Sub
    Public Function GetAGVIcon(ByVal myAGV As AGV) As Byte
        If myAGV.Enable = False Then Return 0
        If myAGV.Connecting Then
            Return myAGV.Status * 2 + 1
        Else
            Return myAGV.Status * 2 + 2
        End If
    End Function
    Public Sub DisplaySingleAGV(ByVal myAGV As AGV)
        Dim str As String() = New String(5) {}
        str(0) = myAGV.Name
        str(1) = "Part: " + myAGV.SupplyPartStatus.ToString
        str(2) = "Work status: " + myAGV.WorkingStatus.ToString
        str(3) = "Position: " + myAGV.Position.ToString
        str(4) = "Status: " + myAGV.Status.ToString
        str(5) = "Connect: " + myAGV.Connecting.ToString
        Dim AGVItem As ListViewItem = New ListViewItem(str)
        lstViewAGV.Items.Add(AGVItem)
    End Sub
    Public Sub SetStartViewAGV()
        For i As Byte = 0 To AGVArray.Length - 1
            lstViewAGV.Items(i).SubItems(4).Text = "Status: " + AGVArray(i).Status.ToString
            lstViewAGV.Items(i).ImageIndex = GetAGVIcon(AGVArray(i))
        Next
    End Sub
    Public Sub DisplayAGV()
        AddColumnAGVDisplay()
        For i As Byte = 0 To AGVArray.Length - 1
            DisplaySingleAGV(AGVArray(i))
        Next
    End Sub
#End Region
#Region "Display part"
#Region "For context menu"
    Private Sub MenuPartViewItem_Click(sender As Object, e As EventArgs) Handles MenuPartViewLargeIcon.Click, MenuPartViewDetail.Click, MenuPartViewSmallIcon.Click, MenuPartViewList.Click, MenuPartViewTile.Click
        If sender.Equals(MenuPartViewTile) Then
            lstViewPart.View = View.Tile
            Return
        End If
        If sender.Equals(MenuPartViewList) Then
            lstViewPart.View = View.List
            Return
        End If
        If sender.Equals(MenuPartViewSmallIcon) Then
            lstViewPart.View = View.SmallIcon
            Return
        End If
        If sender.Equals(MenuPartViewDetail) Then
            lstViewPart.View = View.Details
            Return
        End If
        If sender.Equals(MenuPartViewLargeIcon) Then
            lstViewPart.View = View.LargeIcon
            Return
        End If
    End Sub
    Private Sub ForEndDevicesOfSelectedPartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ForEndDevicesOfSelectedPartToolStripMenuItem.Click
        Dim listSelected As System.Windows.Forms.ListView.SelectedIndexCollection = lstViewPart.SelectedIndices
        If listSelected.Count > 0 Then
            For Each index In listSelected
                PartArray(index).parent.SettingAddress()
            Next
        End If
    End Sub
#End Region
    Public Sub AddColumnPartDisplay()
        Dim str As String() = New String() {"Name", "Connecting", "Status", "Supply by"}
        For i As Byte = 0 To str.Length - 1
            Dim MyColumnHeader As System.Windows.Forms.ColumnHeader
            MyColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            MyColumnHeader.Text = str(i)
            lstViewPart.Columns.Add(MyColumnHeader)
        Next
    End Sub
    Public Sub AddGroupPart()
        For i As Byte = 0 To LineGroupArray.Length - 1
            Dim grp As ListViewGroup
            grp = New ListViewGroup(LineGroupArray(i).Name)
            lstViewPart.Groups.Add(grp)
        Next
    End Sub
    Public Function GetPartIcon(ByVal part As CPart) As Byte
        If part.Enable = False Then Return 0
        If part.parent.connecting Then
            If part.Status Then
                Return 3
            Else
                If part.AGVSupply = "" Then
                    Return 1
                Else
                    Return 5
                End If
            End If
        Else
            If part.Status Then
                Return 4
            Else
                If part.AGVSupply = "" Then
                    Return 2
                Else
                    Return 6
                End If
            End If
        End If
    End Function
    Public Sub DisplaySinglePart(ByVal myPart As CPart)
        Dim str As String() = New String(3) {}
        str(0) = myPart.Name + " (" + myPart.index.ToString + ")"
        str(1) = "Status: " + myPart.Status.ToString
        str(2) = "Connect: " + myPart.parent.connecting.ToString
        str(3) = "Supply by: " + myPart.AGVSupply
        Dim PartItem As ListViewItem = New ListViewItem(str)
        PartItem.Group = lstViewPart.Groups(myPart.group)
        lstViewPart.Items.Add(PartItem)
    End Sub
    Public Sub SetStartViewPart()
        For i As Byte = 0 To PartArray.Length - 1
            lstViewPart.Items(i).SubItems(1).Text = "Status: " + PartArray(i).Status.ToString
            lstViewPart.Items(i).ImageIndex = GetPartIcon(PartArray(i))
        Next
    End Sub
    Public Sub DisplayPart()
        AddColumnPartDisplay()
        AddGroupPart()
        For i As Byte = 0 To PartArray.Length - 1
            DisplaySinglePart(PartArray(i))
        Next
    End Sub
#End Region
	Public Sub DisplayOverView()
        For i As Byte = 0 To AGVArray.Length - 1
            If lstViewAGV.Items(i).ImageIndex <> GetAGVIcon(AGVArray(i)) Then
                lstViewAGV.Items(i).ImageIndex = GetAGVIcon(AGVArray(i))
            End If
            If lstViewAGV.Items(i).SubItems(1).Text <> ("Part: " + AGVArray(i).SupplyPartStatus.ToString) Then
                lstViewAGV.Items(i).SubItems(1).Text = "Part: " + AGVArray(i).SupplyPartStatus.ToString
            End If
            If lstViewAGV.Items(i).SubItems(2).Text <> ("Work status: " + AGVArray(i).WorkingStatus.ToString) Then
                lstViewAGV.Items(i).SubItems(2).Text = "Work status: " + AGVArray(i).WorkingStatus.ToString
            End If
            If lstViewAGV.Items(i).SubItems(3).Text <> ("Position: " + AGVArray(i).Position.ToString) Then
                lstViewAGV.Items(i).SubItems(3).Text = "Position: " + AGVArray(i).Position.ToString
            End If
            If lstViewAGV.Items(i).SubItems(4).Text <> ("Status: " + AGVArray(i).Status.ToString) Then
                lstViewAGV.Items(i).SubItems(4).Text = "Status: " + AGVArray(i).Status.ToString
                lstViewAGV.Items(i).ImageIndex = GetAGVIcon(AGVArray(i))
            End If
            If lstViewAGV.Items(i).SubItems(5).Text <> ("Connect: " + AGVArray(i).Connecting.ToString) Then
                lstViewAGV.Items(i).SubItems(5).Text = "Connect: " + AGVArray(i).Connecting.ToString
                lstViewAGV.Items(i).ImageIndex = GetAGVIcon(AGVArray(i))
            End If
        Next
		lstViewPart.BeginUpdate()
		For i As Byte = 0 To PartArray.Length - 1
			Dim isUpdate As Boolean = False
			lstViewPart.Items(i).SubItems(1).Text = "Status: " + PartArray(i).Status.ToString
			lstViewPart.Items(i).SubItems(2).Text = "Connect: " + PartArray(i).parent.connecting.ToString
			lstViewPart.Items(i).SubItems(3).Text = "Supply by: " + PartArray(i).AGVSupply
			lstViewPart.Items(i).ImageIndex = GetPartIcon(PartArray(i))
		Next
		lstViewPart.EndUpdate()
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
        Static AlarmCounter() As Byte = New Byte(AGVArray.Length - 1) {}
        Static PreStatusForAndon() As AGV.RobocarStatusValue = New AGV.RobocarStatusValue(AGVArray.Length - 1) {}
        Static blind As Boolean = False
        For i As Byte = 0 To AGVArray.Length - 1
            If PreStatusForAndon(i) <> AGVArray(i).Status Then
                AlarmCounter(i) = 0
                PreStatusForAndon(i) = AGVArray(i).Status
            ElseIf isAndonAlarmCondition(PreStatusForAndon(i)) And AlarmCounter(i) < 200 Then
                AlarmCounter(i) += 1
            End If
        Next
        needAlarm = False
        For i As Byte = 0 To AGVArray.Length - 1
            If AlarmCounter(i) > 10 Then
                needAlarm = True
                Exit For
            End If
        Next
        If needAlarm Then
            If blind Then
                lstViewAGV.BackColor = Color.Red
            Else
                lstViewAGV.BackColor = Color.Yellow
            End If
            blind = Not blind
        Else
            lstViewAGV.BackColor = Color.White
        End If
    End Sub
    Private Function isAndonAlarmCondition(ByVal value As AGV.RobocarStatusValue) As Boolean
        If value = AGV.RobocarStatusValue.BATTERY_EMPTY Or value = AGV.RobocarStatusValue.EMERGENCY Or value = AGV.RobocarStatusValue.NO_CART Or value = AGV.RobocarStatusValue.OUT_OF_LINE Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
