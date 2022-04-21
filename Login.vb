Public Class Login
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        abrir()
    End Sub

    Private Sub btnacceder_Click(sender As Object, e As EventArgs) Handles btnacceder.Click
        If txtusuario.Text <> "" And txtcontraseña.Text <> "" Then
            Try
                If usuarioRegistrado(txtusuario.Text) = True Then
                    Dim contraadmin As String = contraseñaadmin(txtusuario.Text)
                    Dim contraestudiante As String = contraseñaestudiante(txtusuario.Text)

                    If contraadmin.Equals(txtcontraseña.Text) = True Then
                        MsgBox("Accediste Correctamente como administrador", MsgBoxStyle.Information, Title:="Sistema Biblioteca")
                    ElseIf contraestudiante.Equals(txtcontraseña.Text) = True Then
                        MsgBox("Accediste Correctamente como Estudiante", MsgBoxStyle.Information, Title:="Sistema Biblioteca")
                    Else
                        MsgBox("Contraseña Invalida", MsgBoxStyle.Critical)
                    End If
                Else
                    MsgBox("El Usuario: " + txtusuario.Text + " no se encuentra registrado", MsgBoxStyle.OkCancel, Title:="Sistema Biblioteca")
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Else
            MsgBox("Llene todos los campos para Acceder", MsgBoxStyle.Information, Title:="Sistema Biblioteca")
        End If
    End Sub

    Private Sub btnrestaurar_Click(sender As Object, e As EventArgs) Handles btnrestaurar.Click
        Recuperacion.Visible = True
    End Sub
End Class