Public Class DoubleListView : Inherits ListView
	Public Sub SetBuffer()
		MyClass.DoubleBuffered = True
	End Sub
	Public Property EnableDoubleBuffered() As Boolean
		Get
			Return DoubleBuffered
		End Get
		Set(value As Boolean)
			MyClass.DoubleBuffered = value
		End Set
	End Property
End Class
