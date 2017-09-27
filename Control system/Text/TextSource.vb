Public Class TextSource
    Public Parts As List(Of CPart)
    Public WithEvents ReadTime As Timers.Timer
    Public WithEvents DisConnectTimer As Timers.Timer
    Private _analyseMethod As IAnalyses
    Private _filePath As String
    Private _fileName As String
    Private _connecting As Boolean
    Private _Id As Integer

    Public Sub New(ByVal id As Integer, ByVal filePath As String, ByVal analyseMethod As IAnalyses)
        Parts = New List(Of CPart)
        _analyseMethod = analyseMethod
        _filePath = filePath
        DisConnectTimer = New System.Timers.Timer(5000)
        ReadTime = New Timers.Timer(1000)
        ReadTime.Start()
        connecting = True
        Me.Id = id
    End Sub
    Property Id As Integer
        Get
            Return _Id
        End Get
        Set(value As Integer)
            _Id = value
            _fileName = "./TextSource/" + Id.ToString() + ".txt"
        End Set
    End Property

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
        End Set
    End Property


    Sub timerTxt_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReadTime.Elapsed
        ReadTime.Stop()
        Try
            'GetdataReceive()
            CopyFile(_filePath)
        Catch
            ReadTime.Start()
            connecting=False
        End Try
        ReadTime.Start()
    End Sub

    Sub DisconnectTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DisConnectTimer.Elapsed
        DisConnectTimer.Stop()
        connecting = False
        DisConnectTimer.Start()
    End Sub

    Public Structure Data
        Public Name As String
        Public Value As Integer
    End Structure

    Private Sub CopyFile(ByVal srcPath As String)
        File.Copy(srcPath, _fileName, True)
        GetdataReceive()
    End Sub
    Public Sub GetdataReceive()
        Dim fStream As New FileStream(_fileName, FileMode.Open)
        Dim sReader As New StreamReader(fStream)
        Dim ChildCollection As Collection = New Collection

        Do While sReader.Peek >= 0
            Dim line As String
            line = sReader.ReadLine
            Dim TempArray() As String = Split(line, ",")
            If ChildCollection.Contains(TempArray(0)) Then
                If Int32.Parse(ChildCollection(TempArray(0))) > Int32.Parse(TempArray(1)) Then
                    ChildCollection.Remove(TempArray(0).ToString())
                    ChildCollection.Add(TempArray(1), TempArray(0))
                End If
            Else
                ChildCollection.Add(TempArray(1), TempArray(0))
            End If
        Loop
        fStream.Close()
        sReader.Close()

        connecting=True
        DisConnectTimer.Stop()
        DisConnectTimer.Start()
        AnalyseInfo(ChildCollection, Parts)
    End Sub

    Public Sub AnalyseInfo(value As Collection, ByRef parts As List(Of CPart))
        For i As Integer = 0 To parts.Count - 1
            If value.Contains(parts(i).Name) Then
                If Int32.Parse(value(parts(i).Name)) >= parts(i).RemainStock Then
                    'parts(partNum).Status = True
                    parts(i).EmptyCounter = 0
                    If parts(i).TIME_FULL = 0 Then   'If confirm timer is disable
                        If parts(i).Status = False Then 'If part change from Full to Empty --> Save empty time
                            parts(i).FullTime = Now
                        End If
                        parts(i).Status = True
                        parts(i).AGVSupply = ""     'Reset AGV supply
                        Continue For
                    End If
                    If parts(i).Status = True Then 'If preview status is full - Only update status again
                        parts(i).Status = True
                        parts(i).AGVSupply = ""
                    Else    'If preview status is empty
                        If parts(i).FullCounter = 0 Then 'if timer not set - it mean this's the first time sensor detect full
                            parts(i).FullCounter = Environment.TickCount
                        Else
                            If Environment.TickCount > (parts(i).FullCounter + parts(i).TIME_FULL) Then
                                parts(i).FullTime = Now
                                parts(i).Status = True
                                parts(i).AGVSupply = ""
                                parts(i).FullCounter = 0
                            End If
                        End If
                    End If
                Else
                    'parts(i).Status = False
                    parts(i).FullCounter = 0
                    If parts(i).TIME_EMPTY = 0 Then
                        If parts(i).Status = True Then 'If part change from Full to Empty --> Save empty time
                            parts(i).EmptyTime = Now
                        End If
                        parts(i).Status = False
                        Continue For
                    End If
                    If parts(i).Status = False Then
                        parts(i).Status = False
                    Else
                        If parts(i).EmptyCounter = 0 Then
                            parts(i).EmptyCounter = Environment.TickCount
                        Else
                            If Environment.TickCount > (parts(i).EmptyCounter + parts(i).TIME_EMPTY) Then
                                parts(i).EmptyTime = Now
                                parts(i).Status = False
                                parts(i).EmptyCounter = 0
                            End If
                        End If
                    End If
                End If
                If parts(i).Status = True Then
                    parts(i).AGVSupply = ""
                End If

            Else 'Do not have text for Part
                parts(i).Enable = False
                'MessageBox.Show("Khong co du lieu cho part: " + parts(partNum).Name)
            End If
        Next
    End Sub
End Class
