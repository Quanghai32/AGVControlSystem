Imports ControlSystemLibrary

Public Class VirtualAGV
    Public AGVArray() As AGV
    Private Sub VirtualAGV_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbAGV.SelectedIndex = 0
        cmbAGVStatus.SelectedIndex = 0
        cmbPartSupply.SelectedIndex = 0
        cmbPosition.SelectedIndex = 0
        cmbWorkingStatus.SelectedIndex = 0
    End Sub

    Private Sub cmbPosition_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPosition.SelectedIndexChanged
        If Not IsNothing(AGVArray) Then
            AGVArray(cmbAGV.SelectedIndex).Position = cmbPosition.SelectedIndex
        End If
    End Sub

    Private Sub cmbAGVStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAGVStatus.SelectedIndexChanged
        If Not IsNothing(AGVArray) Then
            AGVArray(cmbAGV.SelectedIndex).Status = cmbAGVStatus.SelectedIndex
        End If
    End Sub

    Private Sub cmbWorkingStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbWorkingStatus.SelectedIndexChanged
        If Not IsNothing(AGVArray) Then
            AGVArray(cmbAGV.SelectedIndex).WorkingStatus = cmbWorkingStatus.SelectedIndex
        End If
    End Sub

    Private Sub cmbPartSupply_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPartSupply.SelectedIndexChanged
        If Not IsNothing(AGVArray) Then
            AGVArray(cmbAGV.SelectedIndex).SupplyPartStatus = cmbPartSupply.SelectedIndex
        End If
    End Sub
End Class
