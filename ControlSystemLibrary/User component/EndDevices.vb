Imports System.Timers
Public Class EndDevices
    Implements IXbeeDevices
    Implements System.ComponentModel.INotifyPropertyChanged
    Property Address As UInt32
    Property PID As Byte
    Property TIMEOUT As Integer = 4000
    Property Host As Byte

    Private _connecting As Boolean
    Public Parts As List(Of CPart)
    Public CollectPart_PerEnd As Collection
    Private WithEvents timerDisconnect As Timer
    Public _VitualMode As Boolean = False
    Public myXbee As XBee

    Property VitualMode As Boolean
        Get
            Return _VitualMode
        End Get
        Set(value As Boolean)
            _VitualMode = value
            If value Then
                connecting = True
            Else
                connecting = False
            End If
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
            RaiseEvent PropertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs("connecting"))
        End Set
    End Property

    Public Sub New()
        init()
    End Sub
    'Public Sub New(ByVal DeviceLimit As Byte)
    '	MAX_DEVICES = DeviceLimit
    '	init()
    'End Sub
    'Public Sub New(ByVal DeviceLimit As Byte, ByVal add As UInt32)
    '	MAX_DEVICES = DeviceLimit
    '	Address = add
    '	init()
    'End Sub

    'Public Sub init()
    '	Dim i As Byte
    '	If MAX_DEVICES > 0 Then
    '		Parts = New CPart(MAX_DEVICES - 1) {}
    '		For i = 0 To MAX_DEVICES - 1
    '			Parts(i) = New CPart
    '			Parts(i).parent = Me
    '		Next
    '	End If
    '	timerDisconnect = New Timer()
    '	timerDisconnect.Interval = TIMEOUT
    '	startTimer()
    'End Sub
    Public Sub init()
        'CollectPart_PerEnd = New Collection
        Parts = New List(Of CPart)
        timerDisconnect = New Timer()
        timerDisconnect.Interval = TIMEOUT
        startTimer()
    End Sub
    Public Sub AddPart(Num As Byte)
        If Num > 0 Then
            'Parts = New CPart(Num - 1) {}
            For i As Byte = 0 To Num - 1
                Parts(i) = New CPart
                Parts(i).NumberInEnd = i + 1
                Parts(i).parent = Me
                CollectPart_PerEnd.Add(Parts(i))
            Next
        End If
        timerDisconnect = New Timer()
        timerDisconnect.Interval = TIMEOUT
        startTimer()
    End Sub

    Public Sub AddPart(part As CPart)
        part.parent = Me
        Parts.Add(part)
    End Sub

    Private Sub startTimer()
        timerDisconnect.Start()
    End Sub

    Private Sub stopTimer()
        timerDisconnect.Stop()
    End Sub

    Friend Sub analizeInput(ByVal ID As UInt32, ByVal data() As Byte, ByVal len As Byte) Implements IXbeeDevices.analizeInput
        If VitualMode Then
            Return
        End If
        Dim i As Byte
        If ID <> Address Then Return
        If (len < Parts.Count) Then Return 'consider to show a message
        connecting = True
        timerDisconnect.Stop()
        timerDisconnect.Start()
        Static FullCounter As Integer = 0
        Static EmptyCounter As Integer = 0
        If Parts.Count = 0 Then Return
        For i = 0 To Parts.Count - 1      'For i = 0 To MAX_DEVICES - 1	
            If data(i) = 0 Then                         'Sensor detect - Part Full
                Parts(i).EmptyCounter = 0
                If Parts(i).TIME_FULL = 0 Then   'If confirm timer is disable
                    If Parts(i).Status = False Then 'If part change from Full to Empty --> Save empty time
                        Parts(i).FullTime = Now
                    End If
                    Parts(i).Status = True
                    Parts(i).AGVSupply = ""     'Reset AGV supply
                    Continue For
                End If
                If Parts(i).Status = True Then 'If preview status is full - Only update status again
                    Parts(i).Status = True
                    Parts(i).AGVSupply = ""
                Else    'If preview status is empty
                    If Parts(i).FullCounter = 0 Then 'if timer not set - it mean this's the first time sensor detect full
                        Parts(i).FullCounter = Environment.TickCount
                    Else
                        If Environment.TickCount > (Parts(i).FullCounter + Parts(i).TIME_FULL) Then
                            Parts(i).FullTime = Now
                            Parts(i).Status = True
                            Parts(i).AGVSupply = ""
                            Parts(i).FullCounter = 0
                        End If
                    End If
                End If
            Else    'Sensor not detect - Part Empty
                Parts(i).FullCounter = 0
                If Parts(i).TIME_EMPTY = 0 Then
                    If Parts(i).Status = True Then 'If part change from Full to Empty --> Save empty time
                        Parts(i).EmptyTime = Now
                    End If
                    Parts(i).Status = False
                    Continue For
                End If
                If Parts(i).Status = False Then
                    Parts(i).Status = False
                Else
                    If Parts(i).EmptyCounter = 0 Then
                        Parts(i).EmptyCounter = Environment.TickCount
                    Else
                        If Environment.TickCount > (Parts(i).EmptyCounter + Parts(i).TIME_EMPTY) Then
                            Parts(i).EmptyTime = Now
                            Parts(i).Status = False
                            Parts(i).EmptyCounter = 0
                        End If
                    End If
                End If
            End If
            If Parts(i).Status = True Then
                Parts(i).AGVSupply = ""
            End If
        Next
    End Sub
    Sub timerDisconnect_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerDisconnect.Elapsed
        If VitualMode Then Return
        connecting = False
    End Sub
    Friend Function getAddress() As UInt32 Implements IXbeeDevices.getAddress
        Return Address
    End Function

    Public Sub SettingAddress()
        Dim data As XBee.XBeeDataStruct = New XBee.XBeeDataStruct(0)
        data.ID = Address
        data.data(0) = &H53 'Setting command - 'S'
        data.len = 1
        myXbee.putd(data)
    End Sub
    Public Sub DisableEndevice()
        Dim data As XBee.XBeeDataStruct = New XBee.XBeeDataStruct(0)
        data.ID = Address
        data.data(0) = &H58 'Setting command - 'X'
        data.len = 1
        myXbee.putd(data)
    End Sub

    Private Event PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs) Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
End Class

