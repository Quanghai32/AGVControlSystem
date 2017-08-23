Public Class TextSource
    Public Parts As List(Of CPart)
    Public WithEvents timerTxt As Timers.Timer
    Private _analyseMethod As IAnalyses
    Private _filePath As String
    Private _connecting As Boolean

    Public Sub New(ByVal filePath As String, ByVal analyseMethod As IAnalyses)
        Parts=New List(Of CPart)
        _analyseMethod = analyseMethod
        _filePath = filePath
        timerTxt=New Timers.Timer(1000)
        timerTxt.Start
        connecting=True
    End Sub

    Property connecting As Boolean
        Get
            Return _connecting
        End Get
        Set(ByVal value As Boolean)
            _connecting = value
            If Parts.Count > 0 Then
                For i As Byte = 0 To Parts.Count - 1
                    Parts(i).connecting = value
                Next
            End If
            'RaiseEvent PropertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs("connecting"))
        End Set
    End Property


    Sub timerTxt_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerTxt.Elapsed
        timerTxt.Stop()
        Try
            GetdataReceive()
        Catch
            timerTxt.Start()
        End Try
        timerTxt.Start()
    End Sub

    Public Structure Data
        Public Name As String
        Public Value As Integer
    End Structure
    Public Sub GetdataReceive()
        Dim fStream As New FileStream(_filePath, FileMode.Open)
        Dim sReader As New StreamReader(fStream)
        Dim ChildCollection As Collection=New Collection

        Do While sReader.Peek >= 0
            Dim line As String
            line=sReader.ReadLine
            Dim TempArray() As String = Split(line, ",")
            ChildCollection.Add(TempArray(1),TempArray(0))
        Loop
        fStream.Close()
        sReader.Close()

        _analyseMethod.AnalyseInfomation(ChildCollection,Parts)
    End Sub

    Public Sub AnalyseInfomation(value As Hashtable, ByRef parts As List(Of CPart))
        For partNum As Integer=0 To parts.Count-1
            parts(partNum).Status=value(parts(partNum).Name)
        Next
    End Sub
End Class
