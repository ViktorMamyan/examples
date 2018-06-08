Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim origin As DateTime = New DateTime(1970, 1, 1, 0, 0, 0, 0)
        TextBox1.Text = origin.AddSeconds(1528486750)

    End Sub

End Class