Public Class TextSource
    Public TextPalletList As List(Of CPart)
    Public WithEvents ReadTime As Timers.Timer
    Public WithEvents DisConnectTimer As Timers.Timer
    Private _analyseMethod As IAnalyses
    Private _filePath As String
    Private _fileName As String
    Private _connecting As Boolean
    Private _Id As Integer
    Public Event PalletListChange

    Public Sub New(ByVal id As Integer, ByVal filePath As String, ByVal analyseMethod As IAnalyses)
        TextPalletList = New List(Of CPart)
        _analyseMethod = analyseMethod
        _filePath = filePath
        DisConnectTimer = New System.Timers.Timer(5000)
        ReadTime = New Timers.Timer(1000)
        connecting = True
        Me.Id = id
    End Sub

    Public Sub Init()
        ReadTime.Start()
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
            If TextPalletList.Count > 0 Then
                For i As Byte = 0 To TextPalletList.Count - 1
                    TextPalletList(i).connecting = value
                Next
            End If
        End Set
    End Property


    Sub timerTxt_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReadTime.Elapsed
        ReadTime.Stop()
        Try
            CopyFile(_filePath)
        Catch
            ReadTime.Start()
            connecting = False
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
        'If Not File.Exists(srcPath) Then Return
        'Static prevFile = File.GetLastWriteTime(srcPath)
        'Static isFileNotChange As Boolean = False
        'Dim currentFileModifyTime = File.GetLastWriteTime(srcPath)
        'If (prevFile = currentFileModifyTime) Then
        '    If isFileNotChange

        '    End If
        '    isFileNotChange = True
        '    DisConnectTimer.Start()
        'Else
        '    isFileNotChange = False
        '    DisConnectTimer.Stop()
        '    prevFile = currentFileModifyTime
        'End If

        Try
            File.Copy(srcPath, _fileName, True)
            GetdataReceive()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub GetdataReceive()
        Dim fStream As New FileStream(_fileName, FileMode.Open)
        Dim sReader As New StreamReader(fStream)
        Dim ChildCollection As Collection = New Collection

        For Each a As CPart In TextPalletList
            a.IsSetRemainValue = False
        Next
        Do While sReader.Peek >= 0
            Dim line As String
            line = sReader.ReadLine
            If line = "" Then Continue Do
            Dim TempArray() As String = Split(line, ",")
            Dim LineName = TempArray(0)
            Dim RemainValue As Integer = Int32.Parse(TempArray(1))
            Dim PalletNo = TempArray(2)

            Dim tempPallet As CPart = TextPalletList.FirstOrDefault(Function(p) p.Name = LineName)
            If tempPallet Is Nothing Then 'neu chua co trong PalletList
                Dim tempPart As CPart = ClonePart(PartList.FirstOrDefault(Function(p) p.Name = LineName))
                'Dim tempPart As CPart = PartList.FirstOrDefault(Function(p) p.Name = LineName).ClonePart()
                If tempPart Is Nothing Then 'neu khong co trong PartList reference thi warning
                    Debug.Print("Don't have part " + LineName + " pallet: " + PalletNo)
                Else 'neu da co trong reference thi them moi vao PalletList
                    tempPart.RemainPallet = RemainValue
                    tempPart.PalletNo = PalletNo
                    tempPart.IsSetRemainValue = True
                    tempPart.parent = Me
                    TextPalletList.Add(tempPart)
                    RaiseEvent PalletListChange
                    PalletList.Add(tempPart)
                End If
            Else 'da co trong PalletList
                Dim tempPallett As CPart = TextPalletList.FirstOrDefault(Function(p) p.PalletNo = PalletNo And p.Name = LineName)
                If tempPallett Is Nothing Then 'neu chua co Pallet No thi them moi Pallet No
                    Dim tempPart = ClonePart(PartList.FirstOrDefault(Function(p) p.Name = LineName))
                    'Dim tempPart = PartList.FirstOrDefault(Function(p) p.Name = LineName).ClonePart()
                    tempPart.PalletNo = PalletNo
                    tempPart.RemainPallet = RemainValue
                    tempPart.IsSetRemainValue = True
                    tempPart.parent = Me
                    TextPalletList.Add(tempPart)
                    RaiseEvent PalletListChange
                    PalletList.Add(tempPart)
                Else 'Neu da co Pallet No --> cap nhat Remain value
                    TextPalletList.FirstOrDefault(Function(p) p.PalletNo = PalletNo And p.Name = LineName).RemainPallet = RemainValue
                    TextPalletList.FirstOrDefault(Function(p) p.PalletNo = PalletNo And p.Name = LineName).IsSetRemainValue = True
                End If
            End If
        Loop
        TextPalletList.RemoveAll(Function(p) p.IsSetRemainValue = False)
        Dim count = PalletList.Count
        PalletList.RemoveAll(Function(p) p.IsSetRemainValue = False And p.TextSource = Me.Id)
        If count <> PalletList.Count
            RaiseEvent PalletListChange
        End If
        TextPalletList.ForEach(Function(p) p.IsSetRemainValue = False)
        fStream.Close()
        sReader.Close()

        connecting = True
        DisConnectTimer.Stop()
        DisConnectTimer.Start()
        AnalyseInfo()
    End Sub

    Public Sub AnalyseInfo()
        For i As Integer = 0 To TextPalletList.Count - 1
            If TextPalletList(i).RemainPallet >= TextPalletList(i).RemainStock Or TextPalletList(i).RemainPallet = -1 Then
                'parts(partNum).Status = True
                TextPalletList(i).EmptyCounter = 0
                If TextPalletList(i).TIME_FULL = 0 Then   'If confirm timer is disable
                    If TextPalletList(i).Status = False Then 'If part change from Full to Empty --> Save empty time
                        TextPalletList(i).FullTime = Now
                    End If
                    TextPalletList(i).Status = True
                    TextPalletList(i).AGVSupply = ""     'Reset AGV supply
                    Continue For
                End If
                If TextPalletList(i).Status = True Then 'If preview status is full - Only update status again
                    TextPalletList(i).Status = True
                    TextPalletList(i).AGVSupply = ""
                Else    'If preview status is empty
                    If TextPalletList(i).FullCounter = 0 Then 'if timer not set - it mean this's the first time sensor detect full
                        TextPalletList(i).FullCounter = Environment.TickCount
                    Else
                        If Environment.TickCount > (TextPalletList(i).FullCounter + TextPalletList(i).TIME_FULL) Then
                            TextPalletList(i).FullTime = Now
                            TextPalletList(i).Status = True
                            TextPalletList(i).AGVSupply = ""
                            TextPalletList(i).FullCounter = 0
                        End If
                    End If
                End If
            Else
                'parts(i).Status = False
                TextPalletList(i).FullCounter = 0
                If TextPalletList(i).TIME_EMPTY = 0 Then
                    If TextPalletList(i).Status = True Then 'If part change from Full to Empty --> Save empty time
                        TextPalletList(i).EmptyTime = Now
                    End If
                    TextPalletList(i).Status = False
                    Continue For
                End If
                If TextPalletList(i).Status = False Then
                    TextPalletList(i).Status = False
                Else
                    If TextPalletList(i).EmptyCounter = 0 Then
                        TextPalletList(i).EmptyCounter = Environment.TickCount
                    Else
                        If Environment.TickCount > (TextPalletList(i).EmptyCounter + TextPalletList(i).TIME_EMPTY) Then
                            TextPalletList(i).EmptyTime = Now
                            TextPalletList(i).Status = False
                            TextPalletList(i).EmptyCounter = 0
                        End If
                    End If
                End If
            End If
            If TextPalletList(i).Status = True Then
                TextPalletList(i).AGVSupply = ""
            End If


        Next
    End Sub
End Class
