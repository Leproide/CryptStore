Imports PassCrypt.Crypto

Public Class Form2

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.TextLength < 10 Then
            MsgBox("La chiave per essere sicura deve essere di almeno 10 caratteri")
        Else
            If TextBox1.Text = TextBox2.Text Then
                If TextBox1.Text = "" And TextBox2.Text = "" Then
                    MsgBox("Inserire una chiave")
                Else

                    Dim nomeFile As String = "DB.crypt"
                    If IO.File.Exists(nomeFile) = True Then
                        Dim scelta
                        scelta = MsgBox("Esiste già un file password, continuando verrà sovrascritto perdendone il contenuto. Sovrascrivere?", vbYesNo, "Conferma sovrascrittura")
                        Select Case scelta
                            Case 6
                                Dim aes As AES256 = New AES256(TextBox1.Text)
                                Dim controllobug As String
                                controllobug = aes.Encrypt(RichTextBox1.Text)
                                If controllobug = "PassCrypt.Crypto+AES256" Then
                                    MsgBox("La password utilizzata non è compatibile, questo bug dovrebbe essere risolto il prima possibile")
                                Else
                                    System.IO.File.WriteAllText("DB.crypt", aes.Encrypt(RichTextBox1.Text))
                                    RichTextBox1.Text = "File generato con successo!"
                                    TextBox1.Text = ""
                                    TextBox2.Text = ""
                                End If
                            Case 7
                                ' Non si sovrascrive
                        End Select

                    Else
                        Dim aes As AES256 = New AES256(TextBox1.Text)
                        Dim controllobug As String
                        controllobug = aes.Encrypt(RichTextBox1.Text)
                        If controllobug = "PassCrypt.Crypto+AES256" Then
                            MsgBox("La password utilizzata non è compatibile, questo bug dovrebbe essere risolto il prima possibile")
                        Else

                            System.IO.File.WriteAllText("DB.crypt", aes.Encrypt(RichTextBox1.Text))
                            RichTextBox1.Text = "File generato con successo!"
                            TextBox1.Text = ""
                            TextBox2.Text = ""
                        End If
                    End If
                End If


            Else
                MsgBox("Le password non coincidono!")
            End If
            End If


       

    End Sub

    Private Sub RichTextBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RichTextBox1.Click
        If RichTextBox1.Text = "Inserisci le tue credenziali in questo campo e la password che hai scelto negli appositi spazi quì sotto,  subito dopo clicca su 'Cripta' per salvarle in formato protetto" Then
            RichTextBox1.Text = ""
        Else
        End If
    End Sub

    Private Sub TextBox2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.Click
        TextBox2.Text = ""
        TextBox2.PasswordChar = "•"
    End Sub




    Private Sub TextBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Click
        TextBox1.Text = ""
        TextBox1.PasswordChar = "•"
    End Sub



    Private Sub RichTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RichTextBox1.TextChanged

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If Form1.RichTextBox1.Text = "Inserisci la password e premi su ""Decripta""" Then
            MsgBox("Per recuperare il vecchio DB prima decriptarlo")
        Else
            If Form1.RichTextBox1.Text = "" Then
                MsgBox("Il vecchio database risulta vuoto o non decriptato")
            Else
                If Form1.RichTextBox1.Text = "Chiave errata" Then
                    MsgBox("Vecchio DB non decriptato correttamente, Chiave errata")
                Else
                    RichTextBox1.Text = Form1.RichTextBox1.Text
                End If
            End If
        End If
    End Sub
End Class