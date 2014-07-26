Imports ControlSystemLibrary
Public Class MainForm
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReadStartData()
        SetupHostXbee()
		DisplayAGV()
		DisplayPart()
        'TimerDisplayAGV.Start()
		VirtualAGV1.AGVArray = AGVArray
		SetStartViewAGV()
        'TimerDisplayPart.Start()
        SetStartViewPart()
        DisplayTimer.Start()
    End Sub

    Private Sub MainForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        TabControl1.Dock = DockStyle.Fill
        TableLayoutPanel1.Dock = DockStyle.Fill
    End Sub

#Region "Display AGV"
    Private Sub AGVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LargeIconAGVToolStripMenuItem.Click,
        DetailsAGVToolStripMenuItem.Click, SmallIconAGVToolStripMenuItem.Click,
        ListAGVToolStripMenuItem.Click, TileAGVToolStripMenuItem.Click
        If sender.Equals(TileAGVToolStripMenuItem) Then
            lstViewAGV.View = View.Tile
            Return
        End If
        If sender.Equals(ListAGVToolStripMenuItem) Then
            lstViewAGV.View = View.List
            Return
        End If
        If sender.Equals(SmallIconAGVToolStripMenuItem) Then
            lstViewAGV.View = View.SmallIcon
            Return
        End If
        If sender.Equals(DetailsAGVToolStripMenuItem) Then
            lstViewAGV.View = View.Details
            Return
        End If
        If sender.Equals(LargeIconAGVToolStripMenuItem) Then
            lstViewAGV.View = View.LargeIcon
            Return
        End If
    End Sub
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
        If myAGV.Connecting Then
            Return myAGV.Status * 2
        Else
            Return myAGV.Status * 2 + 1
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
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles TimerDisplayAGV.Tick 'testing
        For i As Byte = 0 To AGVArray.Length - 1
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
    End Sub
#End Region
#Region "Display part"
    Private Sub TitleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TilePartToolStripMenuItem.Click, ListPartToolStripMenuItem.Click, SmallIconPartToolStripMenuItem.Click, DetailPartToolStripMenuItem.Click, LargePartToolStripMenuItem.Click
        If sender.Equals(TilePartToolStripMenuItem) Then
            lstViewPart.View = View.Tile
            Return
        End If
        If sender.Equals(ListPartToolStripMenuItem) Then
            lstViewPart.View = View.List
            Return
        End If
        If sender.Equals(SmallIconPartToolStripMenuItem) Then
            lstViewPart.View = View.SmallIcon
            Return
        End If
        If sender.Equals(DetailPartToolStripMenuItem) Then
            lstViewPart.View = View.Details
            Return
        End If
        If sender.Equals(LargePartToolStripMenuItem) Then
            lstViewPart.View = View.LargeIcon
            Return
        End If
    End Sub
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
        If part.parent.connecting Then
            If part.Status Then
                Return 2
            Else
                If part.AGVSupply = "" Then
                    Return 0
                Else
                    Return 4
                End If
            End If
        Else
            If part.Status Then
                Return 3
            Else
                If part.AGVSupply = "" Then
                    Return 1
                Else
                    Return 5
                End If
            End If
        End If
    End Function
    Public Sub DisplaySinglePart(ByVal myPart As CPart)
        Dim str As String() = New String(3) {}
        str(0) = myPart.Name
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
    Private Sub TimerDisplayPart_Tick(sender As Object, e As EventArgs) Handles TimerDisplayPart.Tick
        For i As Byte = 0 To PartArray.Length - 1
            If lstViewPart.Items(i).SubItems(1).Text <> ("Status: " + PartArray(i).Status.ToString) Then
                lstViewPart.Items(i).SubItems(1).Text = "Status: " + PartArray(i).Status.ToString
                lstViewPart.Items(i).ImageIndex = GetPartIcon(PartArray(i))
            End If
            If lstViewPart.Items(i).SubItems(2).Text <> ("Connect: " + PartArray(i).parent.connecting.ToString) Then
                lstViewPart.Items(i).SubItems(2).Text = "Connect: " + PartArray(i).parent.connecting.ToString
                lstViewPart.Items(i).ImageIndex = GetPartIcon(PartArray(i))
            End If
            If lstViewPart.Items(i).SubItems(3).Text <> ("Supply by: " + PartArray(i).AGVSupply) Then
                lstViewPart.Items(i).SubItems(3).Text = "Supply by: " + PartArray(i).AGVSupply
                lstViewPart.Items(i).ImageIndex = GetPartIcon(PartArray(i))
            End If
        Next
    End Sub
#End Region

    Private Sub DisplayTimer_Tick(sender As Object, e As EventArgs) Handles DisplayTimer.Tick
        Dim a As Byte
        Select Case TabControl1.SelectedIndex
            Case 0
                DisplayOverView()
            Case 1
                a = 1
            Case 2
                a = 2
            Case 3
                a = 3
            Case 4
                a = 4
        End Select
    End Sub
    Public Sub DisplayOverView()
        For i As Byte = 0 To AGVArray.Length - 1
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
        For i As Byte = 0 To PartArray.Length - 1
            If lstViewPart.Items(i).SubItems(1).Text <> ("Status: " + PartArray(i).Status.ToString) Then
                lstViewPart.Items(i).SubItems(1).Text = "Status: " + PartArray(i).Status.ToString
                lstViewPart.Items(i).ImageIndex = GetPartIcon(PartArray(i))
            End If
            If lstViewPart.Items(i).SubItems(2).Text <> ("Connect: " + PartArray(i).parent.connecting.ToString) Then
                lstViewPart.Items(i).SubItems(2).Text = "Connect: " + PartArray(i).parent.connecting.ToString
                lstViewPart.Items(i).ImageIndex = GetPartIcon(PartArray(i))
            End If
            If lstViewPart.Items(i).SubItems(3).Text <> ("Supply by: " + PartArray(i).AGVSupply) Then
                lstViewPart.Items(i).SubItems(3).Text = "Supply by: " + PartArray(i).AGVSupply
                lstViewPart.Items(i).ImageIndex = GetPartIcon(PartArray(i))
            End If
        Next
    End Sub
End Class
