Imports System.Net.Http
Imports ControlSystemLibrary

Public Module GeneralVariable
    Public AGVList As List(Of AGV)
    Public HostXbee() As XBee
    Public EndDevicesArray() As EndDevices
    Public TextList() As TextSource

    Public PartList As List(Of CPart)
    'Public PartListRefer As List(Of CPart)
    Public isNeedToReset As Boolean
    Public MapPartWidth As Integer
    Public MapPartHeight As Integer
    Public IsVerticalPart As Boolean
    Public PartCounterList As List(Of CPart)
    Public Part_EmptyCount As String
    Public IsOptionShow As Boolean = True
    Public IsReadOnlyMap As Boolean = True
    Public IsAllowPrintDebug As Boolean = False
    Public BlockName As String = ""
    Public ServerName As String = ""
    Public pathLogFile As String = ""
    Public pathPerformance As String = ""
    Public httpRequest As HttpRequestMessage
    Public httpResponse As HttpResponseMessage
    Public DurationCopy As Integer
    Public ShipName As String = ""
    Public DayName As String = ""
    Public DebugMode As Boolean = False
    Public TimerChangePartSttValue As Integer

    Structure LineGroup
        Public Name As String
        Public MaxPart As Byte
        Public ChildPart As Collection
    End Structure

    Public LineGroupArray() As LineGroup
    Public StartPoint As Integer() = New Integer(1) {10, 20}

    Structure AGVGroup
        Public Name As String
        Public MaxAGV As Byte
        Public ChildAGV As Collection
    End Structure

    Public AGVGroupArray() As AGVGroup
    ''' <summary>
    ''' AGVnPART(AGVNum,PartNum):
    ''' Description: Array for define which AGVs can supply for which Parts
    ''' Value type: Boolean
    '''    true: Can supply
    '''    false: Cannot supply
    ''' </summary>
    ''' <remarks></remarks>
    Public AGVnPART(,) As Boolean

    Public Structure struct_AGVStoreStatus
        Public connecting_value As Boolean
        Public connecting_time As Date
        Public status_value As AGV.RobocarStatusValue
        Public status_time As Date
        Public working_value As AGV.RobocarWorkingStatusValue
        Public working_time As Date
        Public Enable_value As Boolean
        Public Enable_time As Date
        Public TimeAGVPowerOn_value As Integer
        Public Shutdown_time As Date
    End Structure
    ''' <summary>
    ''' This array store preview status and time of AGVs
    ''' </summary>
    ''' <remarks></remarks>
    Public preAGVStatusArray() As struct_AGVStoreStatus
    Public needAlarm As Boolean = False
    Public needAlarmMap As Boolean = False

    Public Structure struct_Workingtime
        Public StartTime As DateTime
        Public StartMorningTime As DateTime
        Public StopMorningTime As DateTime
        Public StartLunchTime As DateTime
        Public StopLunchTime As DateTime
        Public StartAfterTime As DateTime
        Public StopAfterTime As DateTime
        Public StopTime As DateTime
    End Structure

    Public WorkingTimeArray() As struct_Workingtime
    Public isPreOnTime As Boolean = False
    Public RequestRouteConcept As string
    Public Path_Text As String
    Public Tab_start As Byte = 0
    Public NextPartNeedSupply() As Integer
    Public RequestForm As SupplyForm


    'for visualize map
    Public Map_High As Integer
    Public Map_Width As Integer
    Public MapAGVList As New Collection
    Public MapPartList As List(Of MapPart)
    Public PartForAlign As List(Of MapPart)
    Public CollectNotExistCard As Collection

    'For debug mode
    Public Enum EnumDebugInfor
        THREAD
        REQUEST_AGV
        CROSS_FUNCTION
    End Enum
End Module
