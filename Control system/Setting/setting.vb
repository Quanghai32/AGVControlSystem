Public Module setting
	Public Sub LoadSetting()
		Dim iniFile As ControlSystemLibrary.CIniFile
		iniFile = New ControlSystemLibrary.CIniFile("setting.ini")
		Dim a = iniFile.ReadValue("SYSTEM SETTING", "day")
	End Sub
End Module
