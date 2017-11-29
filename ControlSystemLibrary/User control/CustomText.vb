Imports System.Drawing
Imports System.Windows.Forms

Public Class CustomText
    Private _UserText As String
    Private _UserRotate As Integer
    Private _UserXOrigin As Integer
    Private _UserYOrigin As Integer
    Private _UserFont As Font
    Private _UserWith As Integer
    Private _UserHeight As Integer
    Private _UserDirection As StringFormatFlags

    Property UserText As String
        Get
            Return _UserText
        End Get
        Set(value As String)
            _UserText = value
            UserRefresh()
        End Set
    End Property
    Property UserFont As Font
        Get
            Return _UserFont
        End Get
        Set(value As Font)
            _UserFont = value
            UserRefresh()
        End Set
    End Property
    Property UserRotate As Integer
        Get
            Return _UserRotate
        End Get
        Set(value As Integer)
            _UserRotate = value
            UserRefresh()
        End Set
    End Property
    Property UserXOrigin As Integer
        Get
            Return _UserXOrigin
        End Get
        Set(value As Integer)
            _UserXOrigin = value
            UserRefresh()
        End Set
    End Property
    Property UserYOrigin As Integer
        Get
            Return _UserYOrigin
        End Get
        Set(value As Integer)
            _UserYOrigin = value
            UserRefresh()
        End Set
    End Property
    Property UserDirection As StringFormatFlags
        Get
            Return _UserDirection
        End Get
        Set(value As StringFormatFlags)
            _UserDirection = value
            UserRefresh()
        End Set
    End Property

    Private Sub UserRefresh()
        Refresh()
    End Sub

    Private Sub CustomText_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        Dim myPoint As New PointF(0, 0)
        Dim StrFormat As New StringFormat()
        Dim MysolidBrush As New SolidBrush(ForeColor)

        _UserWith = e.Graphics.MeasureString(UserText, UserFont).Width
        _UserHeight = e.Graphics.MeasureString(UserText, UserFont).Height

        Select Case UserDirection
            Case StringFormatFlags.DirectionVertical
                Me.Width = _UserHeight
                Me.Height = _UserWith
                StrFormat.FormatFlags = StringFormatFlags.DirectionVertical
                e.Graphics.TranslateTransform(0, 0)
            Case Else
                Me.Width = _UserWith
                Me.Height = _UserHeight
                e.Graphics.TranslateTransform(UserXOrigin, UserYOrigin)
        End Select
        'e.Graphics.TranslateTransform(0, Me.Height / 2 + a / 2)
        'e.Graphics.TranslateTransform(UserXOrigin, UserYOrigin)
        'e.Graphics.RotateTransform(UserRotate)
        e.Graphics.DrawString(UserText, UserFont, MysolidBrush, myPoint, StrFormat)
    End Sub

   
End Class
