Imports System.IO

Public Class CHistory
    Enum WriteType As Byte
        Information = 0
        crash = 1
    End Enum
    Public Sub write(ByVal str As String, Optional ByVal type As WriteType = WriteType.Information)
        Dim file As StreamWriter
        Select Case type
            Case WriteType.Information
                file = New StreamWriter("Info-" + Now.Year.ToString() + "-" + Now.Month.ToString() + "-" + Now.Day.ToString() + ".log", True)
            Case WriteType.crash
                file = New StreamWriter("Err-" + Now.Year.ToString() + "-" + Now.Month.ToString() + "-" + Now.Day.ToString() + ".log", True)
            Case Else
                file = New StreamWriter("Info-" + Now.Year.ToString() + "-" + Now.Month.ToString() + "-" + Now.Day.ToString() + ".log", True)
        End Select
        file.WriteLine(str)
        file.Close()
    End Sub
End Class
