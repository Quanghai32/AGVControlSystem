Public Class ucAgvSupply

    Public Event DeleteControl(ByVal name As String)

    Private Sub btnRelease_Click(sender As Object, e As EventArgs) Handles btnRelease.Click
        RaiseEvent DeleteControl(Name)
    End Sub
End Class
