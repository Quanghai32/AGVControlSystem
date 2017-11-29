Public Interface IXbeeDevices
    Sub analizeInput(ByVal ID As UInt32, ByVal data() As Byte, ByVal len As Byte)
    Function getAddress() As UInt32
End Interface