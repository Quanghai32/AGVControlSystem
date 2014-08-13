Public Module setting
	Private StartDayShift As Date
	Private StartNightShift As Date
	Private isResetDay As Boolean
	Private isResetNight As Boolean
	Public Sub LoadSetting()
		Dim iniFile As ControlSystemLibrary.CIniFile
        iniFile = New ControlSystemLibrary.CIniFile(Environment.CurrentDirectory + "\setting.ini")
		Dim str = iniFile.ReadValue("SYSTEM SETTING", "day")
		StartDayShift = Date.Parse(str)
		str = iniFile.ReadValue("SYSTEM SETTING", "night")
		StartNightShift = Date.Parse(str)
		str = iniFile.ReadValue("SYSTEM SETTING", "isResetDay")
		isResetDay = Boolean.Parse(str)
		str = iniFile.ReadValue("SYSTEM SETTING", "isResetNight")
		isResetNight = Boolean.Parse(str)
	End Sub
	''' <summary>
	''' Return the value of timing point need to reset
	''' </summary>
	''' <returns>
	''' 0: Don't need reset
	''' 1: Day point need to reset
	''' 2: Night point need to reset
	''' </returns>
	''' <remarks></remarks>
	Public Function isNeedReset() As Byte
		If isCompareInDay(StartDayShift, Now) And isCompareInDay(Now, StartNightShift) Then
			If Not isResetDay Then
				Return 1
			Else
				Return 0
			End If
		Else
			If Not isResetNight Then
				Return 2
			Else
				Return 0
            End If

		End If
	End Function
	''' <summary>
	''' Compare two time (only compare about hour and minute - Don't care about day)
	''' </summary>
	''' <param name="FirstTime">First time need to compare</param>
	''' <param name="SecondTime">Second time need to compare</param>
	''' <returns>Return true if FirstTime smaller than SecondTime, otherwise is false</returns>
	''' <remarks></remarks>
	Private Function isCompareInDay(ByVal FirstTime As Date, ByVal SecondTime As Date) As Boolean
		If FirstTime.Hour < SecondTime.Hour Then
			Return True
		ElseIf FirstTime.Hour > SecondTime.Hour Then
			Return False
		Else
			If FirstTime.Minute < SecondTime.Minute Then
				Return True
			ElseIf FirstTime.Minute > SecondTime.Minute Then
				Return False
			Else
				Return True
			End If
		End If
	End Function
    Public Sub SettingReset(ByVal type)
        If type = 1 Then
            Dim iniFile As ControlSystemLibrary.CIniFile = New ControlSystemLibrary.CIniFile(Environment.CurrentDirectory + "\setting.ini")
            iniFile.WriteValue("SYSTEM SETTING", "isResetDay", "true")
            iniFile.WriteValue("SYSTEM SETTING", "isResetNight", "false")
        ElseIf type = 2 Then
            Dim iniFile As ControlSystemLibrary.CIniFile = New ControlSystemLibrary.CIniFile("setting.ini")
            iniFile.WriteValue("SYSTEM SETTING", "isResetDay", "false")
            iniFile.WriteValue("SYSTEM SETTING", "isResetNight", "true")
        End If
    End Sub
End Module
