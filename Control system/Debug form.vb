Public Class CDebug_Form
	Public Delegate Sub SetPrintCallBack(ByVal str As String)
	'Public myDelegate As New SetPrintCallBack(AddressOf Print)

	Public Sub Print(ByVal str As String)
		If Me.InvokeRequired Then
			Dim d As New SetPrintCallBack(AddressOf Print)
			Me.Invoke(d, New Object() {str})
		Else
			RichTextBoxDebug.Text += str
			RichTextBoxDebug.SelectionStart = RichTextBoxDebug.TextLength
			RichTextBoxDebug.ScrollToCaret()
		End If
	End Sub

	Private Sub CDebug_Form_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
		IsAllowPrintDebug = False
	End Sub

	Private Sub CDebug_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

	End Sub
End Class