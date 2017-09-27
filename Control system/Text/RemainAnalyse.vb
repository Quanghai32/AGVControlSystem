Public Class RemainAnalyse
    Implements IAnalyses

    Public Sub AnalyseInfomation(value As Collection, ByRef parts As List(Of CPart)) Implements IAnalyses.AnalyseInfomation
        For i As Integer = 0 To parts.Count - 1
            If value.Contains(parts(i).Name) Then
                If Int32.Parse(value(parts(i).Name)) >= parts(i).RemainStock Then
                    'parts(partNum).Status = True
                    parts(i).EmptyCounter = 0
                    If parts(i).TIME_FULL = 0 Then   'If confirm timer is disable
                        If parts(i).Status = False Then 'If part change from Full to Empty --> Save empty time
                            parts(i).FullTime = Now
                        End If
                        parts(i).Status = True
                        parts(i).AGVSupply = ""     'Reset AGV supply
                        Continue For
                    End If
                    If parts(i).Status = True Then 'If preview status is full - Only update status again
                        parts(i).Status = True
                        parts(i).AGVSupply = ""
                    Else    'If preview status is empty
                        If parts(i).FullCounter = 0 Then 'if timer not set - it mean this's the first time sensor detect full
                            parts(i).FullCounter = Environment.TickCount
                        Else
                            If Environment.TickCount > (parts(i).FullCounter + parts(i).TIME_FULL) Then
                                parts(i).FullTime = Now
                                parts(i).Status = True
                                parts(i).AGVSupply = ""
                                parts(i).FullCounter = 0
                            End If
                        End If
                    End If
                Else
                    'parts(i).Status = False
                    parts(i).FullCounter = 0
                    If parts(i).TIME_EMPTY = 0 Then
                        If parts(i).Status = True Then 'If part change from Full to Empty --> Save empty time
                            parts(i).EmptyTime = Now
                        End If
                        parts(i).Status = False
                        Continue For
                    End If
                    If parts(i).Status = False Then
                        parts(i).Status = False
                    Else
                        If parts(i).EmptyCounter = 0 Then
                            parts(i).EmptyCounter = Environment.TickCount
                        Else
                            If Environment.TickCount > (parts(i).EmptyCounter + parts(i).TIME_EMPTY) Then
                                parts(i).EmptyTime = Now
                                parts(i).Status = False
                                parts(i).EmptyCounter = 0
                            End If
                        End If
                    End If
                End If
                If parts(i).Status = True Then
                    parts(i).AGVSupply = ""
                End If

            Else 'Do not have text for Part
                parts(i).Enable = False
                'MessageBox.Show("Khong co du lieu cho part: " + parts(partNum).Name)
            End If
        Next
    End Sub
End Class
