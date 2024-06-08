Imports System.Data.OleDb

Public Class loginform
    Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\PC\Documents\sms_db.accdb")
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnreg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnreg.Click
        registrationfrm.Show()
        Me.Hide()

    End Sub

    Private Sub btnlogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlogin.Click
        con.Open()
        Dim mycmd As New OleDbCommand("select * from registration_table where username= '" & txtuser.Text & "'and passw='" & txtpwd.Text & "' ", con)
        Dim myread As OleDbDataReader = mycmd.ExecuteReader
        If myread.Read Then
            MsgBox("login success")
            txtuser.Clear()
            txtpwd.Clear()
            Dim dashboard As New teacher_dashboard()
            dashboard.Show()
            Me.Hide()
        End If

    End Sub

    Private Sub txtpwd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpwd.TextChanged

    End Sub
End Class