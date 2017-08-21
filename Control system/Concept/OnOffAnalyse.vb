Public Class OnOffAnalyse
    Implements IAnalyses
    Public ChildComponent As List(Of CPart)

    Public Sub AnalyseInfomation(value As Collection, ByRef parts As List(Of CPart)) Implements IAnalyses.AnalyseInfomation
        For partNum As Integer = 0 To parts.Count - 1
            If value.Contains(parts(partNum).Name) Then
                parts(partNum).Status = value(parts(partNum).Name)
            Else 'co part ma khong co text 
                parts(partNum).Enable=False      
                'MessageBox.Show("Khong co du lieu cho part: " + parts(partNum).Name)
            End If
        Next
    End Sub
End Class
