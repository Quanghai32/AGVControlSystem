Public Class RemainAnalyse
    Implements IAnalyses

    Public Sub AnalyseInfomation(value As Collection, ByRef parts As List(Of CPart)) Implements IAnalyses.AnalyseInfomation
        For partNum As Integer = 0 To parts.Count - 1
            If value.Contains(parts(partNum).Name) Then
                If Int32.Parse(value(parts(partNum).Name)) < parts(partNum).RemainStock Then
                    parts(partNum).Status = False
                Else
                    parts(partNum).Status = True
                End If
            Else 'Do not have text for Part
                parts(partNum).Enable = False
                'MessageBox.Show("Khong co du lieu cho part: " + parts(partNum).Name)
            End If
        Next
    End Sub
End Class
