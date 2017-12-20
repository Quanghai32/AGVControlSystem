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
Public Class EditPartForm
    Public PartName As String
    Public PartTargetPoint As String
    Public PartRoute As String
    Public PartRemainStock As String
    Public PartTarget As String
    Public PartCycleTime As String
    Public dt As DataTable = New DataTable()
    Dim mainform As New MainForm()
    Private Sub EditPartForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dt.Columns.Add("Name")
        dt.Columns.Add("TargetPoint", System.Type.GetType("System.Int32"))
        dt.Columns.Add("Route", System.Type.GetType("System.Int32"))
        dt.Columns.Add("RemainStock", System.Type.GetType("System.Int32"))
        dt.Columns.Add("Target", System.Type.GetType("System.Int32"))
        dt.Columns.Add("CycleTime", System.Type.GetType("System.Int32"))
        dt.TableName = "editPartN"
        dgvPart.DataSource = dt

        Dim roww As DataRow = dt.NewRow()
        roww(0) = PartName
        roww(1) = PartTargetPoint
        roww(2) = PartRoute
        roww(3) = PartRemainStock
        roww(4) = PartTarget
        roww(5) = PartCycleTime
        dt.Rows.Add(roww)
    End Sub
    Private Sub FillValueToAllEmptyCell()
        For row As Integer = 0 To dt.Rows.Count - 1
            For cell As Integer = 0 To dt.Columns.Count - 1
                If dt.Rows(row)(cell).ToString = "" Then
                    dt.Rows(row)(cell) = 0
                End If
            Next
        Next
    End Sub
    Private Sub ButtonOK_Click_1(sender As Object, e As EventArgs) Handles ButtonOK.Click
        FillValueToAllEmptyCell()
        Me.Close()
    End Sub
End Class