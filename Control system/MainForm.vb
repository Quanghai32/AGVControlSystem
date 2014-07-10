Imports ControlSystemLibrary
Public Class MainForm
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReadStartData()
        SetupHostXbee()
        displayAGV()
        ComboBox1.SelectedIndex = 0
        Timer1.Start()
		VirtualAGV1.AGVArray = AGVArray
		SetStartViewAGV()
    End Sub

    Private Sub MainForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        TabControl1.Dock = DockStyle.Fill
        TableLayoutPanel1.Dock = DockStyle.Fill
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ListView1.View = ComboBox1.SelectedIndex
    End Sub

    Public Sub displayAGV()
        AddColumnAGVDisplay()
        For i As Byte = 0 To AGVArray.Length - 1
            DisplaySingleAGV(AGVArray(i))
        Next
    End Sub

    Private Sub LargeIconToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LargeIconToolStripMenuItem.Click
        ListView2.View = View.LargeIcon
    End Sub

    Private Sub DetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DetailsToolStripMenuItem.Click
        ListView2.View = View.Details
    End Sub

    Private Sub SmallIconToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SmallIconToolStripMenuItem.Click
        ListView2.View = View.SmallIcon
    End Sub

    Private Sub ListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListToolStripMenuItem.Click
        ListView2.View = View.List
    End Sub

    Private Sub TileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TileToolStripMenuItem.Click
        ListView2.View = View.Tile
    End Sub
    Public Sub DisplaySingleAGV(myAGV As AGV)
		Dim info As String() = New String() {myAGV.Name, myAGV.SupplyPartStatus.ToString, myAGV.WorkingStatus.ToString, myAGV.Position.ToString, myAGV.Status.ToString, myAGV.Connecting.ToString}
		Dim str As String() = New String(5) {}
		str(0) = myAGV.Name
		str(1) = "Part: " + myAGV.SupplyPartStatus.ToString
		str(2) = "Work status: " + myAGV.WorkingStatus.ToString
		str(3) = "Position: " + myAGV.Position.ToString
		str(4) = "Status: " + myAGV.Status.ToString
		str(5) = "Connect: " + myAGV.Connecting.ToString
		Dim AGVItem As ListViewItem = New ListViewItem(str)
        ListView2.Items.Add(AGVItem)
    End Sub
    Public Sub AddColumnAGVDisplay()
        Dim str As String() = New String() {"Name", "Part supply", "Working status", "Position", "Running status", "Connecting", "Battery"}
        For i As Byte = 0 To str.Length - 1
            Dim MyColumnHeader As System.Windows.Forms.ColumnHeader
            MyColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            MyColumnHeader.Text = str(i)
            ListView2.Columns.Add(MyColumnHeader)
        Next
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick 'testing
		For i As Byte = 0 To AGVArray.Length - 1
			If ListView2.Items(i).SubItems(1).Text <> ("Part: " + AGVArray(i).SupplyPartStatus.ToString) Then
				ListView2.Items(i).SubItems(1).Text = "Part: " + AGVArray(i).SupplyPartStatus.ToString
			End If
			If ListView2.Items(i).SubItems(2).Text <> ("Work status: " + AGVArray(i).WorkingStatus.ToString) Then
				ListView2.Items(i).SubItems(2).Text = "Work status: " + AGVArray(i).WorkingStatus.ToString
			End If
			If ListView2.Items(i).SubItems(3).Text <> ("Position: " + AGVArray(i).Position.ToString) Then
				ListView2.Items(i).SubItems(3).Text = "Position: " + AGVArray(i).Position.ToString
			End If
			If ListView2.Items(i).SubItems(4).Text <> ("Status: " + AGVArray(i).Status.ToString) Then
				ListView2.Items(i).SubItems(4).Text = "Status: " + AGVArray(i).Status.ToString
				ListView2.Items(i).ImageIndex = AGVArray(i).Status
				ListView2.Items(i).BackColor = AGVColor(AGVArray(i).Status)
			End If
			If ListView2.Items(i).SubItems(5).Text <> ("Connect: " + AGVArray(i).Connecting.ToString) Then
				ListView2.Items(i).SubItems(5).Text = "Connect: " + AGVArray(i).Connecting.ToString
			End If
		Next
    End Sub
	Public Sub SetStartViewAGV()
		For i As Byte = 0 To AGVArray.Length - 1
			ListView2.Items(i).SubItems(4).Text = "Status: " + AGVArray(i).Status.ToString
			ListView2.Items(i).ImageIndex = AGVArray(i).Status
			ListView2.Items(i).BackColor = AGVColor(AGVArray(i).Status)
		Next
	End Sub
	Public Function AGVColor(ByVal status As Byte) As Color
		Select Case status
			Case AGV.RobocarStatusValue.BATTERY_EMPTY, AGV.RobocarStatusValue.EMERGENCY, AGV.RobocarStatusValue.NO_CART, AGV.RobocarStatusValue.OUT_OF_LINE
				Return Color.Red
			Case AGV.RobocarStatusValue.SAFETY
				Return Color.Yellow
			Case Else
				Return Color.LightGreen
		End Select
	End Function
End Class
