Public Class Principal

    Private Sub FPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Login.Visible = False
        Call PanelContenido(Inicio)
    End Sub


    Public Sub PanelContenido(ByVal Formulario As Form)

        Panel1.Controls.Clear()
        Formulario.TopLevel = False
        Formulario.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Formulario.Dock = DockStyle.Fill
        Panel1.Controls.Add(Formulario)
        Formulario.Show()

    End Sub


    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs)
        Call PanelContenido(Categorias)
        Idiomas.Close()
        Paises.Close()
        Autores.Close()
        Libros.Close()
        editorial.Close()
        Libros.Close()

    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs)
        Call PanelContenido(editorial)
        Idiomas.Close()
        Paises.Close()
        Categorias.Close()
        Autores.Close()
        Libros.Close()
        Libros.Close()

    End Sub


    Private Sub IdiomasToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Call PanelContenido(Idiomas)
        Paises.Close()
        Categorias.Close()
        Autores.Close()
        Libros.Close()
        editorial.Close()
        Libros.Close()

    End Sub

    Private Sub PaisesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PaisesToolStripMenuItem.Click
        Call PanelContenido(Idiomas)
        Paises.Close()
        Categorias.Close()
        Autores.Close()
        Libros.Close()
        editorial.Close()
        Libros.Close()

    End Sub

    Private Sub CategoriasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CategoriasToolStripMenuItem.Click
        Call PanelContenido(Categorias)
        Idiomas.Close()
        Paises.Close()
        Autores.Close()
        editorial.Close()
        Libros.Close()
        Libros.Close()

    End Sub

    Private Sub EditorialesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditorialesToolStripMenuItem.Click
        Call PanelContenido(editorial)
        Idiomas.Close()
        Paises.Close()
        Categorias.Close()
        Autores.Close()
        Libros.Close()

    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs)
        Call PanelContenido(Inicio)
        Idiomas.Close()
        Paises.Close()
        Categorias.Close()
        Autores.Close()
        editorial.Close()
        Libros.Close()
        Libros.Close()

    End Sub

    Private Sub LibrosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LibrosToolStripMenuItem.Click
        Call PanelContenido(Autores)
        Idiomas.Close()
        Paises.Close()
        Categorias.Close()
        editorial.Close()
        Libros.Close()
        Libros.Close()

    End Sub

    Private Sub activaIdioma_Click(sender As Object, e As EventArgs)
        Call PanelContenido(Inicio)
    End Sub

    Private Sub ToolStripDropDownButton1_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton1.Click
        Call PanelContenido(Inicio)
        Idiomas.Close()
        Paises.Close()
        Categorias.Close()
        Autores.Close()
        editorial.Close()
        Libros.Close()
        Libros.Close()
        Inicio.Panel1.Visible = False


    End Sub

    Private Sub Principal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()

    End Sub

    Private Sub LibrosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles LibrosToolStripMenuItem1.Click
        Inicio.Panel1.Visible = True
        Call PanelContenido(Libros)
    End Sub

    Private Sub PaisesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PaisesToolStripMenuItem1.Click
        Call PanelContenido(Paises)
        Idiomas.Close()
        Libros.Close()
        Categorias.Close()
        Autores.Close()
        editorial.Close()
        Libros.Close()

    End Sub

    Private Sub GestionDeUsuariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GestionDeUsuariosToolStripMenuItem.Click
        Call PanelContenido(Usuarios)
    End Sub

    Private Sub PrestamosYDevolucionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrestamosYDevolucionesToolStripMenuItem.Click
        Call PanelContenido(Movimientos)
    End Sub
End Class