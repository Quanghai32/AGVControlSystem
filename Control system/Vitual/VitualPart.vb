Imports ControlSystemLibrary

Public Class VitualPart
	Public WithEvents myPart As CPart

	Private Sub VitualPart_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
		myPart.parent.VitualMode = False
	End Sub
	Private Sub VitualPart_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		TimerVitualPart.Start()
		myPart.parent.connecting = True
	End Sub

	Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles TimerVitualPart.Tick
		If CheckBox1.Checked Then
			myPart.Status = True
		Else
			myPart.Status = False
		End If
	End Sub
End Class