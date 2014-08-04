Imports System.Threading
Imports ControlSystemLibrary
Imports System.IO.Ports
Public Module MainModule
	Public UpdateThread As New Thread(AddressOf UpdateData)
	Public RequestThread As New Thread(AddressOf RequestData)
    Public Sub SetupHostXbee()
        Dim HostXbeeName() As String
        HostXbeeName = SerialPort.GetPortNames()
        Dim list() As String
        list = New String(HostXbee.Length - 1) {}
        Dim tempXbee As XBee = New XBee
        If HostXbeeName.Length > 0 Then
            For i As Byte = 0 To HostXbeeName.Length - 1
                tempXbee.SettingPort(HostXbeeName(i), 9600)
                tempXbee.Address = 0
                tempXbee.Send_AT_Command(XBee.AT_COMMAND_ENUM.SERIAL_NUMBER_LOW)
                Dim CurrentTime As Integer = Environment.TickCount
                While (tempXbee.Address = 0) And (CurrentTime + 1000) > Environment.TickCount
                End While
                If tempXbee.Address <> 0 Then
                    For j As Byte = 0 To HostXbee.Length - 1
                        If tempXbee.Address = HostXbee(j).Address Then
                            list(j) = HostXbeeName(i)
                            Exit For
                        End If
                    Next
                End If
                tempXbee.ClosePort()
            Next
        End If
        Dim Str As String = New String("Can not connect with ")
        Dim isError As Boolean = False
        For i As Byte = 0 To list.Length - 1
            If list(i) = "" Then
                Str = Str + " Host Xbee " + i.ToString + ", "
                isError = True
            End If
        Next
        If isError Then
            Dim confirm As Byte = MessageBox.Show(Str + vbCrLf + "Do you want to continue?", "Error - " + Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Error)
            If confirm <> vbYes Then Environment.Exit(0)
        End If
        For i As Byte = 0 To HostXbee.Length - 1
            If list(i) <> "" Then
                HostXbee(i).SettingPort(list(i), 9600)
            End If
        Next
    End Sub
    Public Sub UpdateData()
		
	End Sub
	Public Sub RequestData()

	End Sub
End Module
