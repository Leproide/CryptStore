Imports PassCrypt.Crypto

Public Class Form1


    Dim istart As Integer
    Dim ilen As Integer
    
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            RichTextBox1.Text = ""
            Dim strFile As String = "DB.crypt"
            Dim sr As New IO.StreamReader(strFile)
            Dim testocriptato As String
            testocriptato = sr.ReadToEnd()
            sr.Close()
            Dim aes As AES256 = New AES256(TextBox1.Text)
            RichTextBox1.Text = aes.Decrypt(testocriptato)
            Button3.Enabled = True
            Button4.Enabled = True
            Button5.Enabled = True
            TextBox2.ReadOnly = False
        Catch
            RichTextBox1.Text = "File password non ancora generato, clicca sul pulsante 'C' per aprire il generatore"
        End Try

    End Sub

    Private Sub TextBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Click
        If TextBox1.Text = "Inserisci password" Then
            TextBox1.Text = ""
            TextBox1.PasswordChar = "•"
        Else
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Form2.Show()
    End Sub

    Private Sub TextBox2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.Click
        If TextBox2.ReadOnly = False Then
            If TextBox2.Text = "Cerca..." Then
                TextBox2.Text = ""
            Else

            End If
        End If
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        
        istart = InStr(RichTextBox1.Text, TextBox2.Text, CompareMethod.Text)
        If istart = 0 Then
            MsgBox("nessuna corrispondenza")
            Exit Sub
        End If
        ilen = TextBox2.TextLength
        RichTextBox1.Focus()
        RichTextBox1.SelectionStart = istart - 1
        RichTextBox1.SelectionLength = ilen

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        istart = InStr(istart + ilen - 1, RichTextBox1.Text, TextBox2.Text, CompareMethod.Text)
        If istart = 0 Then
            MsgBox("nessuna corrispondenza")
            Exit Sub
        End If
        ilen = TextBox2.TextLength
        RichTextBox1.Focus()
        RichTextBox1.SelectionStart = istart - 1
        RichTextBox1.SelectionLength = ilen
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        istart = InStrRev(RichTextBox1.Text, TextBox2.Text, istart - 1, CompareMethod.Text)
        If istart = 0 Then
            MsgBox("nessuna corrispondenza")
            Exit Sub
        End If
        ilen = TextBox2.TextLength
        RichTextBox1.Focus()
        RichTextBox1.SelectionStart = istart - 1
        RichTextBox1.SelectionLength = ilen
    End Sub
End Class
