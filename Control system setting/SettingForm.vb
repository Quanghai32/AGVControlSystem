Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml

Public Class SettingForm
    Private SettingDataTable() As DataTable
    'Private myDataset() As DataSet
    Private Event isChangeData()

    Private myTableName() As String = New String() {"AGV", "Part", "EndDevices", "HostXbee", "LineGroup", "StartPoint", "CrossTable", "AGVGroup", "ParkPoint", "WorkingTime", "Chart","TextSource"}
    Private myDgv() As DataGridView

    Private TableSIZE As Integer

    Private Sub SettingForm_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Keys.F Then
            MsgBox("abc")
        End If
    End Sub

    Private Sub Setting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        myDgv = New DataGridView() {dgvAGV, dgvPart, dgvEndDevices, dgvHostXbee, dgvLineGroup, dgvStartPoint, dgvCrossPoint, dgvAGVGroup, dgvParkPoint, dgvWorkingTime, dgvChart,dgvTextSource}
        LoadSQL()
    End Sub

    Private Sub LoadSQL()
        TableSIZE = myTableName.Count
        SettingDataTable = New DataTable(TableSIZE - 1) {}

        CreateTable()
        ButtonApply.Enabled = False
    End Sub

#Region "Create tables"
    Private Sub CreateTable()
        CreateAGV()
        CreatePart()
        CreateHostXbee()

        CreateEndDevice()
        CreateAgvGroup()
        CreateLineGroup()
        CreateParkPoint()
        CreateStartPoint()
        CreateCross()
        CreateWorkingTime()
        CreateChart()

        CreateTextSource()
    End Sub

    Private Sub CreateTextSource()
        SettingDataTable(11) = New DataTable
        SettingDataTable(11).Columns.Add("Id", System.Type.GetType("System.Int32"))
        SettingDataTable(11).Columns.Add("Path")
        SettingDataTable(11).TableName = "TextSource"
        myDgv(11).DataSource = SettingDataTable(11)


        If File.Exists(".\XML\TextSource.xml") Then
            SettingDataTable(11).ReadXml(".\XML\TextSource.xml")
        Else
            MessageBox.Show("Can not find TextSource table!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub CreateAGV()
        SettingDataTable(0) = New DataTable
        SettingDataTable(0).Columns.Add("Id", System.Type.GetType("System.Int32"))
        SettingDataTable(0).Columns.Add("Name")
        SettingDataTable(0).Columns.Add("Enable", System.Type.GetType("System.Boolean"))
        SettingDataTable(0).Columns.Add("Address")
        SettingDataTable(0).Columns.Add("Host Xbee", System.Type.GetType("System.Int32"))
        SettingDataTable(0).Columns.Add("Count", System.Type.GetType("System.Int32"))
        SettingDataTable(0).Columns.Add("Group", System.Type.GetType("System.Int32"))
        SettingDataTable(0).Columns.Add("Part")
        SettingDataTable(0).TableName = "AGV"
        myDgv(0).DataSource = SettingDataTable(0)
        If File.Exists(".\XML\AGV.xml") Then
            SettingDataTable(0).ReadXml(".\XML\AGV.xml")
        Else
            MessageBox.Show("Can not find AGV table!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub CreatePart()
        SettingDataTable(1) = New DataTable
        SettingDataTable(1).Columns.Add("Id", System.Type.GetType("System.Int32"))
        SettingDataTable(1).Columns.Add("Name")
        SettingDataTable(1).Columns.Add("Enable", System.Type.GetType("System.Boolean"))
        SettingDataTable(1).Columns.Add("TargetPoint", System.Type.GetType("System.Int32"))
        SettingDataTable(1).Columns.Add("Route", System.Type.GetType("System.Int32"))
        SettingDataTable(1).Columns.Add("EndDevices", System.Type.GetType("System.Int32"))
        SettingDataTable(1).Columns.Add("Text", System.Type.GetType("System.Boolean"))
        SettingDataTable(1).Columns.Add("TextSource", System.Type.GetType("System.Int32"))
        SettingDataTable(1).Columns.Add("RemainStock", System.Type.GetType("System.Int32"))
        SettingDataTable(1).Columns.Add("Priority", System.Type.GetType("System.Int32"))
        SettingDataTable(1).Columns.Add("Group", System.Type.GetType("System.Int32"))   
        SettingDataTable(1).Columns.Add("Count", System.Type.GetType("System.Int32"))
        SettingDataTable(1).Columns.Add("Target", System.Type.GetType("System.Int32"))      
        SettingDataTable(1).Columns.Add("CycleTime", System.Type.GetType("System.Int32"))
        SettingDataTable(1).Columns.Add("Description")
        SettingDataTable(1).Columns.Add("EmptyCount", System.Type.GetType("System.Int32"))
        SettingDataTable(1).Columns.Add("X", System.Type.GetType("System.Int32"))
        SettingDataTable(1).Columns.Add("Y", System.Type.GetType("System.Int32"))
        SettingDataTable(1).TableName = "Part"
        myDgv(1).DataSource = SettingDataTable(1)

        If File.Exists(".\XML\Part.xml") Then
            SettingDataTable(1).ReadXml(".\XML\Part.xml")
        Else
            MessageBox.Show("Can not find Part table!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    Private Sub CreateEndDevice()
        SettingDataTable(2) = New DataTable
        SettingDataTable(2).Columns.Add("Id", System.Type.GetType("System.Int32"))
        SettingDataTable(2).Columns.Add("Address")
        SettingDataTable(2).Columns.Add("Host Xbee", System.Type.GetType("System.Int32"))
        SettingDataTable(2).TableName = "EndDevices"
        myDgv(2).DataSource = SettingDataTable(2)

        If File.Exists(".\XML\EndDevices.xml") Then
            SettingDataTable(2).ReadXml(".\XML\EndDevices.xml")
        Else
            MessageBox.Show("Can not find End Deivce table!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub CreateHostXbee()
        SettingDataTable(3) = New DataTable
        SettingDataTable(3).Columns.Add("Id", System.Type.GetType("System.Int32"))
        SettingDataTable(3).Columns.Add("Address")
        SettingDataTable(3).TableName = "HostXbee"
        myDgv(3).DataSource = SettingDataTable(3)

        If File.Exists(".\XML\HostXbee.xml") Then
            SettingDataTable(3).ReadXml(".\XML\HostXbee.xml")
        Else
            MessageBox.Show("Can not find Host Xbee table!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub CreateLineGroup()
        SettingDataTable(4) = New DataTable
        SettingDataTable(4).Columns.Add("Id", System.Type.GetType("System.Int32"))
        SettingDataTable(4).Columns.Add("Name")
        SettingDataTable(4).TableName = "LineGroup"
        myDgv(4).DataSource = SettingDataTable(4)

        If File.Exists(".\XML\LineGroup.xml") Then
            SettingDataTable(4).ReadXml(".\XML\LineGroup.xml")
        Else
            MessageBox.Show("Can not find LineGroup table!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub CreateStartPoint()
        SettingDataTable(5) = New DataTable
        SettingDataTable(5).Columns.Add("Id", System.Type.GetType("System.Int32"))
        SettingDataTable(5).Columns.Add("Card ID", System.Type.GetType("System.Int32"))
        SettingDataTable(5).TableName = "StartPoint"
        myDgv(5).DataSource = SettingDataTable(5)

        If File.Exists(".\XML\StartPoint.xml") Then
            SettingDataTable(5).ReadXml(".\XML\StartPoint.xml")
        Else
            MessageBox.Show("Can not find StartPoint table!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub CreateCross()
        SettingDataTable(6) = New DataTable
        SettingDataTable(6).Columns.Add("Id", System.Type.GetType("System.Int32"))
        For i As Integer = 1 To 20
            SettingDataTable(6).Columns.Add(i.ToString, System.Type.GetType("System.Int32"))
        Next
        SettingDataTable(6).TableName = "CrossTable"
        myDgv(6).DataSource = SettingDataTable(6)

        If File.Exists(".\XML\CrossTable.xml") Then
            SettingDataTable(6).ReadXml(".\XML\CrossTable.xml")
        Else
            MessageBox.Show("Can not find Cross table!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub CreateAgvGroup()
        SettingDataTable(7) = New DataTable
        SettingDataTable(7).Columns.Add("Id", System.Type.GetType("System.Int32"))
        SettingDataTable(7).Columns.Add("Name")
        SettingDataTable(7).TableName = "AGVGroup"
        myDgv(7).DataSource = SettingDataTable(7)

        If File.Exists(".\XML\AGVGroup.xml") Then
            SettingDataTable(7).ReadXml(".\XML\AGVGroup.xml")
        Else
            MessageBox.Show("Can not find AGV Group table!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub CreateParkPoint()
        SettingDataTable(8) = New DataTable
        SettingDataTable(8).Columns.Add("Id", System.Type.GetType("System.Int32"))
        SettingDataTable(8).Columns.Add("First", System.Type.GetType("System.Int32"))
        SettingDataTable(8).Columns.Add("Second", System.Type.GetType("System.Int32"))
        SettingDataTable(8).TableName = "ParkPoint"
        myDgv(8).DataSource = SettingDataTable(8)

        If File.Exists(".\XML\ParkPoint.xml") Then
            SettingDataTable(8).ReadXml(".\XML\ParkPoint.xml")
        Else
            MessageBox.Show("Can not find ParkPoint table!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub CreateWorkingTime()
        SettingDataTable(9) = New DataTable
        SettingDataTable(9).Columns.Add("Id", System.Type.GetType("System.Int32"))
        SettingDataTable(9).Columns.Add("BeginTime", System.Type.GetType("System.DateTime"))
        SettingDataTable(9).Columns.Add("StartMorTime", System.Type.GetType("System.DateTime"))
        SettingDataTable(9).Columns.Add("StopMorTime", System.Type.GetType("System.DateTime"))
        SettingDataTable(9).Columns.Add("StartLunTime", System.Type.GetType("System.DateTime"))
        SettingDataTable(9).Columns.Add("StopLunTime", System.Type.GetType("System.DateTime"))
        SettingDataTable(9).Columns.Add("StartAftTime", System.Type.GetType("System.DateTime"))
        SettingDataTable(9).Columns.Add("StopAftTime", System.Type.GetType("System.DateTime"))
        SettingDataTable(9).Columns.Add("EndTime", System.Type.GetType("System.DateTime"))
        SettingDataTable(9).TableName = "WorkingTime"
        myDgv(9).DataSource = SettingDataTable(9)

        If File.Exists(".\XML\WorkingTime.xml") Then
            SettingDataTable(9).ReadXml(".\XML\WorkingTime.xml")
        Else
            MessageBox.Show("Can not find WorkingTime table!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub CreateChart()
        SettingDataTable(10) = New DataTable
        SettingDataTable(10).Columns.Add("Id", System.Type.GetType("System.Double"))
        SettingDataTable(10).Columns.Add("Name")
        SettingDataTable(10).Columns.Add("EMG", System.Type.GetType("System.Double"))
        SettingDataTable(10).Columns.Add("Safety", System.Type.GetType("System.Double"))
        SettingDataTable(10).Columns.Add("Stop", System.Type.GetType("System.Double"))
        SettingDataTable(10).Columns.Add("Out line", System.Type.GetType("System.Double"))
        SettingDataTable(10).Columns.Add("Battery empty", System.Type.GetType("System.Double"))
        SettingDataTable(10).Columns.Add("No cart", System.Type.GetType("System.Double"))
        SettingDataTable(10).Columns.Add("Normal", System.Type.GetType("System.Double"))
        SettingDataTable(10).Columns.Add("Free", System.Type.GetType("System.Double"))
        SettingDataTable(10).Columns.Add("Pole error", System.Type.GetType("System.Double"))
        SettingDataTable(10).Columns.Add("Disconnect", System.Type.GetType("System.Double"))
        SettingDataTable(10).Columns.Add("Shutdown", System.Type.GetType("System.Double"))
        SettingDataTable(10).TableName = "Chart"
        myDgv(10).DataSource = SettingDataTable(10)

        If File.Exists(".\XML\Chart.xml") Then
            SettingDataTable(10).ReadXml(".\XML\Chart.xml")
        Else
            MessageBox.Show("Can not find Chart table!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
#End Region
    Private Sub Cancel(sender As Object, e As EventArgs) Handles butSettingCancel.Click
        Close()
    End Sub

    Private Sub OK(sender As Object, e As EventArgs) Handles butSettingOK.Click
        FillValueToAllEmptyCell()
        If CheckCross() Then
            ButtonApply.Enabled = False
        Else
            Return
        End If

        Dim str As String = ".\XML\"
        For i As Byte = 0 To TableSIZE - 1
            SettingDataTable(i).WriteXml(str + myTableName(i) + ".xml")
        Next

        Application.Exit()
    End Sub

    Private Sub Open(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        'open
        Dim openDlg As FolderBrowserDialog = New FolderBrowserDialog
        openDlg.SelectedPath = CurDir()
        openDlg.ShowNewFolderButton = False
        Dim Result As DialogResult = openDlg.ShowDialog()
        If Result <> DialogResult.OK Then Return
        Dim str As String = openDlg.SelectedPath
        If str = "" Then Return
        'delete
        For table As Byte = 0 To TableSIZE - 1
            For row As Integer = 0 To CType(myDgv(table), DataGridView).Rows.Count - 2
                CType(myDgv(table), DataGridView).Rows(row).Selected = True
            Next
            For Each row As DataGridViewRow In CType(myDgv(table), DataGridView).SelectedRows
                CType(myDgv(table), DataGridView).Rows.Remove(row)
            Next
        Next
        'restore
        For i As Byte = 0 To TableSIZE - 1
            If File.Exists(str + "\" + myTableName(i) + ".xml") Then
                'SettingDataTable(i) = myDgv(i).DataSource.tables(0)
                SettingDataTable(i).ReadXml(str + "\" + myTableName(i) + ".xml")
            End If
        Next
    End Sub

    Private Sub FindToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FindToolStripMenuItem.Click, But_Find.Click
        Dim x As String = InputBox("Find what: ")
        For i As Integer = 0 To CType(myDgv(TabSetting.SelectedIndex), DataGridView).Rows.Count - 2
            For j As Integer = 0 To CType(myDgv(TabSetting.SelectedIndex), DataGridView).ColumnCount - 1
                CType(myDgv(TabSetting.SelectedIndex), DataGridView).Rows(i).Cells(j).Selected = False
            Next
        Next
        For i As Integer = 0 To CType(myDgv(TabSetting.SelectedIndex), DataGridView).Rows.Count - 2
            For j As Integer = 1 To CType(myDgv(TabSetting.SelectedIndex), DataGridView).ColumnCount - 1
                If CType(myDgv(TabSetting.SelectedIndex), DataGridView).Rows(i).Cells(j).Value.ToString.ToUpper.Replace(" ", "") = x.ToUpper.Replace(" ", "") Then
                    CType(myDgv(TabSetting.SelectedIndex), DataGridView).Rows(i).Cells(j).Selected = True
                End If
            Next
        Next
    End Sub

    Private Sub FillValueToAllEmptyCell()
        For table As Byte = 0 To TableSIZE - 1
            For row As Integer = 0 To myDgv(table).Rows.Count - 2
                For cell As Integer = 0 To myDgv(table).ColumnCount - 1
                    If myDgv(table).Rows(row).Cells(cell).Value.ToString = "" Then
                        myDgv(table).Rows(row).Cells(cell).Value = 0
                    End If
                Next
            Next
        Next
    End Sub


    Private Function CheckCross() As Boolean
        Dim result As Boolean = True
        For row1 As Integer = 0 To myDgv(6).RowCount - 2
            For row2 As Integer = 0 To myDgv(6).RowCount - 2
                If row1 <> row2 Then
                    If Check2Row(row1, row2) Then
                        result = False
                        MessageBox.Show("Tất cả các thẻ ở Cross " & row1.ToString & " đều thuộc Cross " & row2.ToString & vbCrLf & "Hãy kiểm tra lại", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                    End If
                End If
            Next
        Next
        Return result
    End Function
    Private Function Check2Row(row1, row2) As Boolean
        Dim result As Boolean = False
        For ColumnIndex1 As Byte = 1 To myDgv(6).ColumnCount - 1
            If myDgv(6).Rows(row1).Cells(ColumnIndex1).Value = 0 Then
                Continue For
            End If
            For ColumnIndex2 As Byte = 1 To myDgv(6).ColumnCount - 1
                If myDgv(6).Rows(row2).Cells(ColumnIndex2).Value = 0 Then
                    Exit For
                ElseIf (myDgv(6).Rows(row1).Cells(ColumnIndex1).Value = myDgv(6).Rows(row2).Cells(ColumnIndex2).Value) Then
                    result = True
                    Exit For
                Else
                    result = False
                End If
            Next
            If result = False Then
                Exit For
            End If
        Next
        Return result
    End Function

    Private Sub Apply(sender As Object, e As EventArgs) Handles ButtonApply.Click
        FillValueToAllEmptyCell()
        If CheckCross() Then
            ButtonApply.Enabled = False
        Else
            Return
        End If
        Dim str As String = ".\XML\"
        For i As Byte = 0 To TableSIZE - 1
            SettingDataTable(i).WriteXml(str + myTableName(i) + ".xml")
        Next
    End Sub

    Private Sub dgvAGV_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAGV.CellValueChanged, dgvAGVGroup.CellValueChanged, dgvChart.CellValueChanged, dgvCrossPoint.CellValueChanged, dgvEndDevices.CellValueChanged, dgvHostXbee.CellValueChanged, dgvLineGroup.CellValueChanged, dgvParkPoint.CellValueChanged, dgvPart.CellValueChanged, dgvStartPoint.CellValueChanged, dgvWorkingTime.CellValueChanged
        RaiseEvent isChangeData()
    End Sub
    Private Sub dgvAGV_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvAGV.RowsAdded, dgvAGVGroup.RowsAdded, dgvChart.RowsAdded, dgvCrossPoint.RowsAdded, dgvEndDevices.RowsAdded, dgvHostXbee.RowsAdded, dgvLineGroup.RowsAdded, dgvParkPoint.RowsAdded, dgvPart.RowsAdded, dgvStartPoint.RowsAdded, dgvWorkingTime.RowsAdded
        RaiseEvent isChangeData()
    End Sub

    Private Sub dgvAGV_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgvAGV.RowsRemoved, dgvAGVGroup.RowsRemoved, dgvChart.RowsRemoved, dgvCrossPoint.RowsRemoved, dgvEndDevices.RowsRemoved, dgvHostXbee.RowsRemoved, dgvLineGroup.RowsRemoved, dgvParkPoint.RowsRemoved, dgvPart.RowsRemoved, dgvStartPoint.RowsRemoved, dgvWorkingTime.RowsRemoved
        RaiseEvent isChangeData()
    End Sub
    Private Sub NeedToApply() Handles Me.isChangeData
        ButtonApply.Enabled = True
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        Dim saveDlg As FolderBrowserDialog = New FolderBrowserDialog
        saveDlg.SelectedPath = CurDir()
        Dim Result As DialogResult = saveDlg.ShowDialog()
        If Result <> DialogResult.OK Then Return
        Dim str As String = saveDlg.SelectedPath
        If str = "" Then Return
        Dim isReplace As Boolean = False

        For i As Byte = 0 To TableSIZE - 1
            If File.Exists(str + "\" + myTableName(i) + ".xml") Then            'Chỉ cần có 1 file
                Dim ResultSave As DialogResult = MessageBox.Show("Do you want to replace exist file: ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If ResultSave = Windows.Forms.DialogResult.Yes Then
                    isReplace = True
                    Exit For
                ElseIf Windows.Forms.DialogResult.No Then
                    isReplace = False
                    Exit For
                End If
            End If
            isReplace = True        'Nếu chưa có file đã lưu
        Next

        If isReplace Then
            For i As Byte = 0 To TableSIZE - 1
                'SettingDataTable(i) = myDgv(i).DataSource.Tables(0)
                SettingDataTable(i).WriteXml(str + "\" + myTableName(i) + ".xml")
            Next
            MessageBox.Show("Backup complete", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub

    Private Sub SaveXml(ByVal table As String, ByVal id As Integer, ByVal element As String, ByVal value As String)
        Dim doc = XElement.Load(".\XML\" + table + ".xml")
        Dim c As Integer = doc.Elements("AGV").Count()
        Dim target = doc.Elements(table).
            [Single](Function(u) u.Element("Id").Value = id.ToString())

        target.Element(element).Value = value
        doc.Save(".\XML\" + table + ".xml")
    End Sub

End Class