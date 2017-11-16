Public Class CDebug_Form
    Public Delegate Sub SetPrintCallBack(ByVal mode As EnumDebugInfor, ByVal str As String)

    Public Sub Print(ByVal mode As EnumDebugInfor, ByVal str As String)
        If Me.InvokeRequired Then
            Dim d As New SetPrintCallBack(AddressOf Print)
            Me.Invoke(d, New Object() {mode, str})
        Else
            If CheckBeforePrint(mode) Then
                RichTextBoxDebug.Text += (str + vbCrLf)
                RichTextBoxDebug.SelectionStart = RichTextBoxDebug.TextLength
                RichTextBoxDebug.ScrollToCaret()
            End If
            If CheckBeforeRecord(mode) Then
                RecordDebug(str)
            End If
        End If
    End Sub

    Function CheckBeforePrint(ByVal mode As EnumDebugInfor) As Boolean
        Dim check As CheckState = CheckedListBoxDebug.GetItemCheckState(mode)
        If check = CheckState.Checked Then
            Return True
        Else
            Return False
        End If
    End Function

    Function CheckBeforeRecord(ByVal mode As EnumDebugInfor) As Boolean
        Dim check As CheckState = CheckedListBoxRecord.GetItemCheckState(mode)
        If check = CheckState.Checked Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub RecordDebug(ByVal s As String)
        Static objlock As Object = New Object
        SyncLock objlock
            Dim sw As StreamWriter = File.AppendText("Debug.csv")
            sw.WriteLine(s)
            sw.Close()
        End SyncLock
    End Sub

    Private Sub RecordDebug(ParamArray args As string())
        Static objlock As Object = New Object
        Dim s=String.Join(",",args)
        SyncLock objlock
            Dim sw As StreamWriter = File.AppendText("Debug.csv")
            sw.WriteLine(s)
            sw.Close()
        End SyncLock
    End Sub

    Private Sub DisplayDebug(ParamArray args As Object())
        Dim s=String.Join(" - ",args)
    End Sub


    Private Sub CDebug_Form_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        IsAllowPrintDebug = False
    End Sub

    Private Sub CDebug_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckedListBoxDebug.Items.AddRange([Enum].GetNames(GetType(EnumDebugInfor)))
        CheckedListBoxRecord.Items.AddRange([Enum].GetNames(GetType(EnumDebugInfor)))
    End Sub

    Private Sub ButtonRun_Click(sender As Object, e As EventArgs) Handles ButtonRun.Click
        Static isRun As Boolean = True
        If isRun Then
            IsAllowPrintDebug = False
            ButtonRun.BackColor = Color.Red
            ButtonRun.Text = "Run"
        Else
            IsAllowPrintDebug = True
            ButtonRun.BackColor = Color.GreenYellow
            ButtonRun.Text = "Stop"
        End If
        isRun = Not isRun
    End Sub

    Private Sub ButtonClear_Click(sender As Object, e As EventArgs) Handles ButtonClear.Click
        RichTextBoxDebug.Text = ""
    End Sub

End Class