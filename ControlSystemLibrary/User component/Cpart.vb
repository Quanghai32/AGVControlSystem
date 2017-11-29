Public Class CPart
    Implements System.ComponentModel.INotifyPropertyChanged
    Private _Enable As Boolean
    Private _Name As String
    Private _Status As Boolean = False
    Private _index As Byte
    Private _priority As Byte
    Private _group As Byte
    Private _target As Integer = 0
    Private _supplyCount As Integer = 0
    Private _route As Integer = 0
    Private _EndDevice As Byte

    Property TargetPoint As Integer
    Public Property TIME_FULL As Integer
    Public Property TIME_EMPTY As Integer
    Property isRequesting As Boolean = False
    Property isFinding4Suply As Boolean = False
    Property CycleTime As Integer
    Property RemainStock As Integer
    Property Text As Boolean
    Property TextSource As Integer

    Public EmptyCounter As Integer = 0
    Public FullCounter As Integer = 0
    Public parent As Object
    Public isRequested As Boolean = False
    Public EmptyTime As DateTime = Now
    Public FullTime As DateTime = Now
    Public SupplyTime As DateTime = Now
    Public EmptyCount As Integer
    'location
    Property X As Integer
    Property Y As Integer
    Property EndDevice As Byte
        Set(value As Byte)
            _EndDevice = value
        End Set
        Get
            Return _EndDevice
        End Get
    End Property
    Property NumberInEnd As Byte
    Property Description As String
    Property Enable As Boolean
        Get
            Return _Enable
        End Get
        Set(ByVal value As Boolean)
            _Enable = value
            RaiseEvent PropertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs("Enable"))
        End Set
    End Property
    Property Name As String
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            _Name = value
            RaiseEvent PropertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs("Name"))
        End Set
    End Property
    Property Status As Boolean
        Get
            Return _Status
        End Get
        Set(ByVal value As Boolean)
            _Status = value
            RaiseEvent PropertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs("Status"))
        End Set
    End Property
    Property index As Byte
        Get
            Return _index
        End Get
        Set(value As Byte)
            _index = value
        End Set
    End Property
    Property route As Integer
        Get
            Return _route
        End Get
        Set(value As Integer)
            _route = value
        End Set
    End Property
    Private _AGVSupply As String
    Public Property AGVSupply() As String
        Get
            Return _AGVSupply
        End Get
        Set(ByVal value As String)
            _AGVSupply = value
            RaiseEvent PropertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs("AGVSupply"))
        End Set
    End Property
    Property priority As Byte
        Get
            Return _priority
        End Get
        Set(value As Byte)
            _priority = value
        End Set
    End Property
    Property group As Byte
        Get
            Return _group
        End Get
        Set(value As Byte)
            _group = value
        End Set
    End Property
    Property SupplyCount As Integer
        Get
            Return _supplyCount
        End Get
        Set(value As Integer)
            _supplyCount = value
        End Set
    End Property
    Property target As Integer
        Get
            Return _target
        End Get
        Set(value As Integer)
            _target = value
            RaiseEvent PropertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs("target"))
        End Set
    End Property
    Public Property connecting() As Boolean
        Get
            If IsNothing(parent) Then Return True
            Return parent.connecting
        End Get
        Set(value As Boolean)
            RaiseEvent PropertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs("connecting"))
        End Set
    End Property
    Private Event PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs) Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
End Class
