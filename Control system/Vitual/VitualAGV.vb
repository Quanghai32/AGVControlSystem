Imports ControlSystemLibrary
Imports ControlSystemLibrary.AGV

Public Class VitualAGV
	Public WithEvents myAGV As AGV
	Public Address As UInt32
	Private stt As RobocarStatusValue

	Private Sub VitualForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		ComboBoxStt.DataSource = [Enum].GetValues(GetType(RobocarStatusValue))
		stt = New RobocarStatusValue()
		stt = RobocarStatusValue.NORMAL
	End Sub

	Private Sub TimerVitual_Tick(sender As Object, e As EventArgs) Handles TimerVitual.Tick
		If CheckBoxRealAGV.Checked Then
			If CheckBoxEMG.Checked Then
				stt = RobocarStatusValue.EMERGENCY
			End If
			Select Case stt
				Case RobocarStatusValue.POLE_ERROR
					ComboBoxStt.SelectedIndex = 0
				Case RobocarStatusValue.EMERGENCY
					ComboBoxStt.SelectedIndex = 1
				Case RobocarStatusValue.SAFETY
					ComboBoxStt.SelectedIndex = 2
				Case RobocarStatusValue.STOP_BY_CARD
					ComboBoxStt.SelectedIndex = 3
				Case RobocarStatusValue.OUT_OF_LINE
					ComboBoxStt.SelectedIndex = 4
				Case RobocarStatusValue.BATTERY_EMPTY
					ComboBoxStt.SelectedIndex = 5
				Case RobocarStatusValue.NO_CART
					ComboBoxStt.SelectedIndex = 6
				Case RobocarStatusValue.NORMAL
					ComboBoxStt.SelectedIndex = 7
				Case RobocarStatusValue.STOP_BY_CROSS_AGV
					ComboBoxStt.SelectedIndex = 8
			End Select
		End If
		CreatData()
	End Sub
	Private Sub CreatData()
		Dim TransmitData As XBee.XBeeDataStruct = New XBee.XBeeDataStruct(0)
		Dim Position(1) As Byte
		Dim Time(2) As Byte
		Dim Pos_temp As Integer = NumericPosition.Value
		Dim Time_temp As Integer = NumericTime.Value
		Position = BitConverter.GetBytes(Pos_temp)
		Time = BitConverter.GetBytes(Time_temp)

		TransmitData.ID = Address
		TransmitData.len = 12
		TransmitData.data(0) = ComboBoxStt.SelectedValue	'Status
		TransmitData.data(1) = Position(1)					'Position 1
		TransmitData.data(2) = Position(0)					'Position 0
		TransmitData.data(3) = NumericRoute.Value			'Route
		TransmitData.data(4) = 0
		TransmitData.data(5) = 0
		TransmitData.data(6) = 0
		TransmitData.data(7) = 130
		TransmitData.data(8) = 0
		TransmitData.data(9) = Time(2)
		TransmitData.data(10) = Time(1)
		TransmitData.data(11) = Time(0)
		myAGV.analizeVitual(Address, TransmitData.data, TransmitData.len)
	End Sub

	Private Sub ButtonSend_Click(sender As Object, e As EventArgs) Handles ButtonSend.Click
		CreatData()
	End Sub

	Private Sub ButtonLoop_Click(sender As Object, e As EventArgs) Handles ButtonLoop.Click
		TimerVitual.Start()
		CreatData()
	End Sub

	Private Sub ButtonRun_Click(sender As Object, e As EventArgs) Handles ButtonRun.Click
		myAGV.AGVRun()
		stt = RobocarStatusValue.NORMAL
	End Sub
	Private Sub MyAGVRun() Handles myAGV.EventRun
		stt = RobocarStatusValue.NORMAL
	End Sub
	Private Sub MyAGVStop() Handles myAGV.EventStop
		stt = RobocarStatusValue.STOP_BY_CARD
	End Sub

	Private Sub VitualForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
		myAGV.VitualMode = False
	End Sub

End Class