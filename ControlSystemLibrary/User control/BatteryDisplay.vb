Imports System.Drawing

Public Class BatteryDisplay
    Property EmptyColor As Color = Color.Red
    Property NormalColor As Color = Color.Yellow
    Property FullColor As Color = Color.Green
    Property FullValue As Byte = 50
    Property EmptyValue As Byte = 20
    Property FULL_VOLTAGE As Byte = 130
    Property EMPTY_VOLTAGE As Byte = 110

    Public WriteOnly Property value As Byte
        Set(ByVal value As Byte)
            Dim positionX As Integer = RectangleShape1.Left
            Dim PositionY As Integer = RectangleShape1.Top
            Dim height As Integer = RectangleShape1.Height
            Dim width As Integer = RectangleShape1.Width
            If value > FULL_VOLTAGE Then value = FULL_VOLTAGE
            If value < EMPTY_VOLTAGE Then value = EMPTY_VOLTAGE
            Dim value_percent = (value - EMPTY_VOLTAGE) / (FULL_VOLTAGE - EMPTY_VOLTAGE) * 100
            If value_percent > FullValue Then
                RectangleShape2.FillColor = MyClass.FullColor
            ElseIf value_percent < EmptyValue Then
                RectangleShape2.FillColor = MyClass.EmptyColor
            Else
                RectangleShape2.FillColor = MyClass.NormalColor
            End If
            If value_percent = 100 Then
                RectangleShape2.Top = RectangleShape1.Top
                RectangleShape2.Height = height
            ElseIf value_percent = 0 Then
                RectangleShape2.Top = RectangleShape1.Top + height - 1
                RectangleShape2.Height = 1
            Else
                RectangleShape2.Top = RectangleShape1.Top + ((height / 100) * (100 - value_percent))
                RectangleShape2.Height = height - RectangleShape2.Top + RectangleShape1.Top
            End If
            txtValue.Text = value_percent.ToString() + "%"
            If Not Enabled Then RectangleShape2.FillColor = Color.Silver
        End Set
    End Property
End Class