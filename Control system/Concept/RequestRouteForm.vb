Public Class RequestRouteForm
    Private Delegate Sub SetPrintCallBack(ByVal item As Control, ByVal prop As String, ByVal value As Object)

    Private Sub SetAnyProperty(ByVal item As Control, ByVal prop As String, ByVal value As Object)
        If Me.InvokeRequired Then
            Dim d As New SetPrintCallBack(AddressOf SetAnyProperty)
            Me.Invoke(d, New Object() {item, prop, value})
        Else
            Dim propertyInfo As PropertyInfo = item.[GetType]().GetProperty(prop)
            propertyInfo.SetValue(item, Convert.ChangeType(value, propertyInfo.PropertyType), Nothing)
        End If
    End Sub

    Public Sub SetData(Optional agv As String = "", Optional firstPart As String = "", Optional firstRoute As String = "",
                           Optional secondPart As String = "", Optional secondRoute As String = "")
        SetAnyProperty(lblAgvName, "Text", agv)
        SetAnyProperty(LabelFirstPart, "Text", firstPart)
        SetAnyProperty(LabelSecondPart, "Text", secondPart)

        SetAnyProperty(LabelFirstRoute, "Text", firstRoute)
        SetAnyProperty(LabelSecondRoute, "Text", secondRoute)

        If firstPart <> "" Then
            SetAnyProperty(PanelFirstPart, "BackColor", Color.YellowGreen)
        Else
            SetAnyProperty(PanelFirstPart, "BackColor", Color.Transparent)
        End If
        If secondPart <> "" Then
            SetAnyProperty(PanelSecondPart, "BackColor", Color.Coral)
        Else
            SetAnyProperty(PanelSecondPart, "BackColor", Color.Transparent)
        End If

    End Sub

    Private Sub RequestRouteForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class