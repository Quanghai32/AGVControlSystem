Public Class CrossView
	Public AGVcrossFlagLabel(,) As Label
	Public AGVLabel() As Label
	Public AGVPosition() As Label
    Public CrossPosLabel() As Label
    Public AGVExistInCross() As Label

	Private Sub CrossView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Me.TopMost = True
		AGVcrossFlagLabel = New Label(AGVList.Count - 1, CrossArray.Length - 1) {}
		AGVLabel = New Label(AGVList.Count - 1) {}
		CrossPosLabel = New Label(CrossArray.Length - 1) {}
		AGVPosition = New Label(AGVList.Count - 1) {}
		AGVExistInCross = New Label(CrossArray.Length - 1) {}

		Dim PositionLabel = New Label
		Me.Controls.Add(PositionLabel)
		PositionLabel.Location = New Point(100, 70)
		PositionLabel.AutoSize = True
		PositionLabel.Text = "Position"

		For AGVnum As Byte = 0 To AGVList.Count - 1
			'AGV name
			AGVLabel(AGVnum) = New Label
			AGVLabel(AGVnum).Text = AGVList(AGVnum).Name
			Me.Controls.Add(AGVLabel(AGVnum))
			AGVLabel(AGVnum).AutoSize = True
			AGVLabel(AGVnum).Location = New Point(50, 100 + AGVnum * 30)
			'AGV position
			AGVPosition(AGVnum) = New Label
			AGVPosition(AGVnum).Text = AGVList(AGVnum).Position.ToString
			Me.Controls.Add(AGVPosition(AGVnum))
			AGVPosition(AGVnum).BackColor = Color.Gold
			AGVPosition(AGVnum).AutoSize = True
			AGVPosition(AGVnum).Location = New Point(110, 100 + AGVnum * 30)
			For CrossNum As Byte = 0 To CrossArray.Length - 1
				'Crossflag
				AGVcrossFlagLabel(AGVnum, CrossNum) = New Label
				Me.Controls.Add(AGVcrossFlagLabel(AGVnum, CrossNum))
				AGVcrossFlagLabel(AGVnum, CrossNum).AutoSize = True
				AGVcrossFlagLabel(AGVnum, CrossNum).Text = "0"
				AGVcrossFlagLabel(AGVnum, CrossNum).BackColor = Color.Transparent
				AGVcrossFlagLabel(AGVnum, CrossNum).Location = New Point(150 + CrossNum * 20, 100 + AGVnum * 30)
			Next
		Next

		'Cross lable
		For CrossNum As Byte = 0 To CrossArray.Length - 1
			CrossPosLabel(CrossNum) = New Label
			Me.Controls.Add(CrossPosLabel(CrossNum))
			CrossPosLabel(CrossNum).AutoSize = True
			CrossPosLabel(CrossNum).Text = CrossNum.ToString
			CrossPosLabel(CrossNum).Location = New Point(150 + CrossNum * 20, 70)
			'AGV exist
			AGVExistInCross(CrossNum) = New Label
			Me.Controls.Add(AGVExistInCross(CrossNum))
			AGVExistInCross(CrossNum).AutoSize = True
			AGVExistInCross(CrossNum).Text = "0"
			AGVExistInCross(CrossNum).Location = New Point(150 + CrossNum * 20, 50)
		Next
	End Sub

	Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
		For i As Byte = 0 To CrossArray.Length - 1
			If CrossArray(i).isExistAGV Then
				CrossPosLabel(i).BackColor = Color.Red
			Else
				CrossPosLabel(i).BackColor = Color.GreenYellow
            End If
            AGVExistInCross(i).Text = CrossArray(i).AGVExist.Substring(3)
		Next
		For AGVnum As Byte = 0 To AGVList.Count - 1
			AGVPosition(AGVnum).Text = AGVList(AGVnum).Position.ToString
			For CrossNum As Byte = 0 To CrossArray.Length - 1
				If AGVCrossFlag(AGVnum, CrossNum) Then
					AGVcrossFlagLabel(AGVnum, CrossNum).BackColor = Color.Red
					AGVcrossFlagLabel(AGVnum, CrossNum).Text = "1"
				Else
					AGVcrossFlagLabel(AGVnum, CrossNum).BackColor = Color.GreenYellow
					AGVcrossFlagLabel(AGVnum, CrossNum).Text = "0"
				End If
			Next
		Next
	End Sub

    Private Sub ResetCrossToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetCrossToolStripMenuItem.Click
        For i As Byte = 0 To CrossArray.Length - 1
            CrossArray(i).isExistAGV = False
            AGVExistInCross(i).Text = "0"
        Next
        For AGVnum As Byte = 0 To AGVList.Count - 1
            For CrossNum As Byte = 0 To CrossArray.Length - 1
                AGVCrossFlag(AGVnum, CrossNum) = False
            Next
        Next
    End Sub
End Class