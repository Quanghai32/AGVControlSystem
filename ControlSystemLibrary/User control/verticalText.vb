Imports System.Drawing
Public Class verticalText
    Private _UserText As String
    Property UserText As String
        Get
            Return _UserText
        End Get
        Set(value As String)
            _UserText = value
        End Set
    End Property

    Private Sub verticalText_Paint(sender As Object, e As Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim myPoint As New PointF(0, 0)
        Dim StrFormat As New StringFormat()
        Dim MysolidBrush As New SolidBrush(ForeColor)
        StrFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft + StringFormatFlags.DirectionVertical
        Dim a As Integer = e.Graphics.MeasureString(UserText, Font).Width
        Dim b As Integer = e.Graphics.MeasureString(UserText, Font).Height
        Me.Width = b
        Me.Height = a
        e.Graphics.TranslateTransform(0, Me.Height / 2 + a / 2)
        e.Graphics.RotateTransform(180)
        e.Graphics.DrawString(UserText, Font, MysolidBrush, myPoint, StrFormat)
    End Sub
End Class
