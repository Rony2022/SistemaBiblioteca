Imports System.Data.SqlClient

Public Class Recuperacion
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub



    Private Sub Recuperacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Login.Visible = False
    End Sub

    Private Sub btnacceder_Click(sender As Object, e As EventArgs) Handles btnacceder.Click
        If txtcodigo.Text <> "" And txtuser.Text <> "" Then

            Try
                Abrir_Conexion()
                Dim sql As String
                Dim rs As SqlDataReader
                Dim com As New SqlCommand
                sql = "select Contraseña from Usuarios 
        where IdUsuario=" & txtcodigo.Text & " and NombreUsuario='" & txtuser.Text & "'"
                com = New SqlCommand(sql, conect)
                rs = com.ExecuteReader()
                rs.Read()
                txtpassword.Text = rs(0)
                Cerrar_Conexion()
            Catch ex As Exception
                MsgBox("No se encontro su contraseña", MsgBoxStyle.Critical, Title:="Sistema Biblioteca")
                txtcodigo.Text = ""
                txtuser.Text = ""
                txtpassword.Text = ""
            End Try
        Else
            MsgBox("LLene los campos", MsgBoxStyle.Critical, Title:="Sistema Biblioteca")
        End If

    End Sub

    Private Sub Recuperacion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Login.Visible = True
    End Sub
End Class