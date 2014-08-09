Namespace My
	' The following events are available for MyApplication:
	' 
	' Startup: Raised when the application starts, before the startup form is created.
	' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
	' UnhandledException: Raised if the application encounters an unhandled exception.
	' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
	' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
	Partial Friend Class MyApplication

		Private Sub MyApplication_UnhandledException(sender As Object, e As ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
			Dim str As String = ""
			str += Now.ToString + ": "
			str += e.Exception.ToString + vbCrLf
			Dim strPromt As String = "Sorry! Program have error! Please run again." + vbCrLf + vbCrLf + "Chúng tôi rất xin lỗi! Chương trình không thể chạy tiếp được. Xin vui lòng khởi động lại chương trình."
			MessageBox.Show(strPromt, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
			My.Computer.FileSystem.WriteAllText("Error.txt", str, True)
		End Sub
	End Class


End Namespace

