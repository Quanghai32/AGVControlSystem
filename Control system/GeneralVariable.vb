Imports ControlSystemLibrary
Public Module GeneralVariable
    Public AGVArray() As AGV
    Public HostXbee() As XBee
    Public EndDevicesArray() As EndDevices
    Public PartArray() As CPart
    Structure LineGroup
        Public Name As String
        Public MaxPart As Byte
        Public ChildPart As Collection
	End Structure

    Public LineGroupArray() As LineGroup
End Module
