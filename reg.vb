Imports System.Data.OleDb

Public Class registrationfrm
    Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\PC\Documents\sms_db.accdb")

    Private Sub btnregister_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnregister.Click
        Try
            con.Open()
            Dim sqlquery As String = "INSERT INTO registration_table (firstname, lastname, username, passw, email, phone) VALUES (@firstname, @lastname, @username, @passw, @email, @phone)"
            Dim mycmd As New OleDbCommand(sqlquery, con)
            mycmd.Parameters.AddWithValue("@firstname", txtfname.Text)
            mycmd.Parameters.AddWithValue("@lastname", txtlname.Text)
            mycmd.Parameters.AddWithValue("@username", txtuser.Text)
            mycmd.Parameters.AddWithValue("@passw", txtpwd.Text)
            mycmd.Parameters.AddWithValue("@email", txtemail.Text)
            mycmd.Parameters.AddWithValue("@phone", txtphone.Text)

            mycmd.ExecuteNonQuery()


            ' Clear textboxes after successful registration
            txtfname.Clear()
            txtlname.Clear()
            txtuser.Clear()
            txtpwd.Clear()
            txtemail.Clear()
            txtphone.Clear()

            ' Show success message
            MsgBox("Registration successful!")

        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message)
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub
End Class
