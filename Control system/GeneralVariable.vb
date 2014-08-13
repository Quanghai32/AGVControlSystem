Imports ControlSystemLibrary
Public Module GeneralVariable
    ''' <summary>
    ''' This array store all AGV object
    ''' </summary>
    Public AGVArray() As AGV
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
	End Structure
	''' <summary>
	''' This array store preview status and time of AGVs
	''' </summary>
	''' <remarks></remarks>
	Public preAGVStatusArray() As struct_AGVStoreStatus
End Module
