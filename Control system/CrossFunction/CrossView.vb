Public Class CrossView
	Public CrossPos() As Label
	Public AGV1Pos() As Label
	Public AGV2Pos() As Label

	Private Sub CrossView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		CrossPos = New Label(9) {Label1, Label2, Label3, Label4, Label5, Label6, Label7, Label8, Label9, Label10}
		AGV1Pos = New Label(9) {Label11, Label12, Label13, Label14, Label15, Label16, Label17, Label18, Label19, Label20}
		AGV2Pos = New Label(9) {Label21, Label22, Label23, Label24, Label25, Label26, Label27, Label28, Label29, Label30}
	End Sub

	Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
		For i As Byte = 0 To 1
			If CrossArray(i).isExistAGV Then
				CrossPos(i).BackColor = Color.Red
			Else
				CrossPos(i).BackColor = Color.Green
			End If
		Next
		For i As Byte = 0 To 1
			If AGVCrossFlag(0, i) Then
				AGV1Pos(i).BackColor = Color.Red
			Else
				AGV1Pos(i).BackColor = Color.Green
			End If
		Next
		For i As Byte = 0 To 1
			If AGVCrossFlag(1, i) Then
				AGV2Pos(i).BackColor = Color.Red
			Else
				AGV2Pos(i).BackColor = Color.Green
			End If
		Next
	End Sub
End Class