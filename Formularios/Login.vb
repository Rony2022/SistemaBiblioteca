Public Class Login
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Conexion.Conectar()

    End Sub

    Private Sub acceder()
        Try
            If usuarioRegistrado(txtusuario.Text) = True Then
                Dim contraadmin As String = contraseñaadmin(txtusuario.Text)
                Dim contraestudiante As String = contraseñaestudiante(txtusuario.Text)

                If contraadmin.Equals(txtcontraseña.Text) = True Then

                    MsgBox("Accediste Correctamente como administrador", MsgBoxStyle.Information, Title:="Sistema Biblioteca")
                    Principal.Visible = True
                ElseIf contraestudiante.Equals(txtcontraseña.Text) = True Then

                    MsgBox("Accediste Correctamente como Estudiante", MsgBoxStyle.Information, Title:="Sistema Biblioteca")
                    PrincipalEstudiante.Visible = True
                Else
                    MsgBox("Datos incorrectos", MsgBoxStyle.Critical)

                    If MsgBox("¿Desea intentar recuperar su contraseña?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                        Recuperacion.Visible = True
                    Else
                        Return
                    End If
                End If
            Else
                MsgBox("Usuario Invalido", MsgBoxStyle.OkCancel, Title:="Sistema Biblioteca")

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub btnacceder_Click(sender As Object, e As EventArgs) Handles btnacceder.Click
        If txtusuario.Text <> "" And txtcontraseña.Text <> "" Then
            acceder()
        Else
            MsgBox("Llene todos los campos para Acceder", MsgBoxStyle.Information, Title:="Sistema Biblioteca")
        End If
    End Sub

    Private Sub btnrestaurar_Click(sender As Object, e As EventArgs) Handles btnrestaurar.Click
        Recuperacion.Visible = True
    End Sub
    Private Sub btnacceder_Enter(sender As Object, e As EventArgs) Handles btnacceder.Enter
        If txtusuario.Text <> "" And txtcontraseña.Text <> "" Then
            acceder()
        Else
            MsgBox("Llene todos los campos para Acceder", MsgBoxStyle.Information, Title:="Sistema Biblioteca")
        End If
    End Sub
End Class