Imports System.Data.SqlClient

Public Class SettingForm
    Private myAGVAdapter As SqlDataAdapter
    Private myAGVDataset As DataSet

    Private myEndDevicesAdapter As SqlDataAdapter
    Private myEndDevicesDataset As DataSet

    Private myHostXbeeAdapter As SqlDataAdapter
    Private myHostXbeeDataset As DataSet

    Private myLineGroupAdapter As SqlDataAdapter
    Private myLineGroupDataset As DataSet

    Private myPartAdapter As SqlDataAdapter
    Private myPartDataset As DataSet

    Private myStartPointAdapter As SqlDataAdapter
    Private myStartPointDataset As DataSet

    Private Sub Setting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReadData(myAGVAdapter, myAGVDataset, "AGV")
        ReadData(myEndDevicesAdapter, myEndDevicesDataset, "EndDevices")
        ReadData(myHostXbeeAdapter, myHostXbeeDataset, "HostXbee")
        ReadData(myLineGroupAdapter, myLineGroupDataset, "LineGroup")
        ReadData(myPartAdapter, myPartDataset, "Part")
        ReadData(myStartPointAdapter, myStartPointDataset, "StartPoint")

        dgvAGV.DataSource = myAGVDataset
        dgvAGV.DataMember = "AGV"

        dgvEndDevices.DataSource = myEndDevicesDataset
        dgvEndDevices.DataMember = "EndDevices"

        dgvHostXbee.DataSource = myHostXbeeDataset
        dgvHostXbee.DataMember = "HostXbee"

        dgvLineGroup.DataSource = myLineGroupDataset
        dgvLineGroup.DataMember = "LineGroup"

        dgvPart.DataSource = myPartDataset
        dgvPart.DataMember = "Part"

        dgvStartPoint.DataSource = myStartPointDataset
        dgvStartPoint.DataMember = "StartPoint"
    End Sub

    Private Sub ReadData(ByRef adapter As SqlDataAdapter, ByRef ds As DataSet, ByVal TableName As String)
        adapter = New SqlDataAdapter("SELECT * FROM " + TableName, SQLcon)
        ds = New DataSet
        adapter.Fill(ds, TableName)
    End Sub
    Private Sub WriteData(ByRef adapter As SqlDataAdapter, ByRef ds As DataSet, ByVal TableName As String)
        Dim objCommandBuilder As New SqlCommandBuilder(adapter)
        adapter.Update(ds, TableName)
        objCommandBuilder.Dispose()
    End Sub
    Private Sub butSettingOK_Click(sender As Object, e As EventArgs) Handles butSettingOK.Click
        WriteData(myAGVAdapter, myAGVDataset, "AGV")
        WriteData(myEndDevicesAdapter, myEndDevicesDataset, "EndDevices")
        WriteData(myHostXbeeAdapter, myHostXbeeDataset, "HostXbee")
        WriteData(myLineGroupAdapter, myLineGroupDataset, "LineGroup")
        WriteData(myPartAdapter, myPartDataset, "Part")
        WriteData(myStartPointAdapter, myStartPointDataset, "StartPoint")
        Application.Restart()
    End Sub

    Private Sub butSettingCancel_Click(sender As Object, e As EventArgs) Handles butSettingCancel.Click
        Close()
    End Sub
End Class