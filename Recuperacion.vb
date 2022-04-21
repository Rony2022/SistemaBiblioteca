Public Class Recuperacion
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Recuperacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Login.Visible = False
        abrir()
    End Sub

    Private Sub btnacceder_Click(sender As Object, e As EventArgs) Handles btnacceder.Click
        If txtuser.Text <> "" And txtcodigo.Text <> "" Then
            Try
                If recuperarcontraseña(txtuser.Text, txtcodigo.Text) = True Then
                    Dim contraseña As String

                    MsgBox("Exito", MsgBoxStyle.Information, Title:="Sistema Biblioteca")

                Else
                    MsgBox("no se encuentra registrado", MsgBoxStyle.OkCancel, Title:="Sistema Biblioteca")
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Else
            MsgBox("Llene todos los campos para Acceder", MsgBoxStyle.Information, Title:="Sistema Biblioteca")
        End If
    End Sub
End Class