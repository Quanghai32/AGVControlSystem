Public Class Password

    Private Sub butOK_Click(sender As Object, e As EventArgs) Handles butOK.Click
        If txtPass.Text = "apro" Then
            SettingForm.Show()
            Close()
        Else
            MessageBox.Show("Your password is incorrect." + vbCrLf + "Please check again.", "Control System Setting", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPass.SelectAll()
        End If
    End Sub

    Private Sub butCancel_Click(sender As Object, e As EventArgs) Handles butCancel.Click
        Close()
    End Sub
End Class