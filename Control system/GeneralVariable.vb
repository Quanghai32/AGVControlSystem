Imports ControlSystemLibrary
Public Module GeneralVariable
    ''' <summary>
    ''' This array store all AGV object
    ''' </summary>
    Public AGVArray() As AGV
    ''' <summary>
    ''' This array store previous status of all AGV object
    ''' </summary>
    Public PreAGVArray() As AGV
    ''' <summary>
    ''' Array of Host Xbee
    ''' </summary>
    ''' <remarks></remarks>
    Public HostXbee() As XBee
    Public EndDevicesArray() As EndDevices
    Public PartArray() As CPart
    Structure LineGroup
        Public Name As String
        Public MaxPart As Byte
        Public ChildPart As Collection
    End Structure

    Public LineGroupArray() As LineGroup

    Public ChartDataSet As New DataSet()
    Public ChartDataTable As New DataTable()

    Public AGVnPART(,) As Boolean
End Module
