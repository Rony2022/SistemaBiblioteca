Public Class PrincipalEstudiante

    Private Sub FPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Login.Visible = False
        Call PanelContenido(InicioEstudiante)
    End Sub


    Public Sub PanelContenido(ByVal Formulario As Form)

        Panel1.Controls.Clear()
        Formulario.TopLevel = False
        Formulario.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Formulario.Dock = DockStyle.Fill
        Panel1.Controls.Add(Formulario)
        Formulario.Show()

    End Sub





End Class