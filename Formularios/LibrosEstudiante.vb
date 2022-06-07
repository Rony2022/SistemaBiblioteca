Imports System.Data.SqlClient

Public Class LibrosEstudiante

    Public Function CargarEditorial()
        Dim sql As String = "SELECT IdEditorial,nombre FROM Editoriales"
        Dim da As New SqlDataAdapter(sql, conect)
        Dim dt As New DataTable("Editoriales")
        da.Fill(dt)
        Return dt
    End Function

    Public Function CargarAutores()
        Dim sql As String = "SELECT IdAutor,nombre FROM Autores"
        Dim da As New SqlDataAdapter(sql, conect)
        Dim dt As New DataTable("Autores")
        da.Fill(dt)
        Return dt
    End Function

    Public Function CargarCategoria()
        Dim sql As String = "SELECT IdCategorias,nombre FROM Categorias"
        Dim da As New SqlDataAdapter(sql, conect)
        Dim dt As New DataTable("Categorias")
        da.Fill(dt)
        Return dt
    End Function

    Public Function CargarIdioma()
        Dim sql As String = "SELECT IdIdiomas,nombre FROM Idiomas"
        Dim da As New SqlDataAdapter(sql, conect)
        Dim dt As New DataTable("Idiomas")
        da.Fill(dt)
        Return dt
    End Function


    Public Sub mostrarCantidadLibros()
        Try
            Abrir_Conexion()
            Dim sql As String
            Dim rs As SqlDataReader
            Dim com As New SqlCommand
            sql = "Select count(*) from Libros"
            com = New SqlCommand(sql, conect)
            rs = com.ExecuteReader()
            rs.Read()
            Dim Conteo As Integer
            Conteo = rs(0)
            btninf.Text = "Total de Libros Registrados " & Conteo
            Cerrar_Conexion()
        Catch ex As Exception
            Cerrar_Conexion()
        End Try

    End Sub

    Public Function infoLibro() As DataTable
        Dim cmd
        cmd = New SqlCommand()
        Dim da As New SqlDataAdapter
        Dim tbl As New DataTable
        cmd = New SqlCommand("LibrosFiltro", conect)
            cmd.Parameters.AddWithValue("@dato", cbxFiltro.SelectedItem)
            cmd.CommandType = CommandType.StoredProcedure
            da.SelectCommand = cmd
            da.Fill(tbl)
        Return tbl

    End Function
    Public Function infoLibro2() As DataTable
        Dim cmd
        cmd = New SqlCommand()
        Dim da As New SqlDataAdapter
        Dim tbl As New DataTable
        cmd = New SqlCommand("filtroSeleccionLibro", conect)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@dato", cbxFiltro.SelectedItem)
        cmd.Parameters.AddWithValue("@nombre", txtbuscar2.Text)
        da.SelectCommand = cmd
        da.Fill(tbl)
        Return tbl

    End Function
    Private Sub Libros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarEditorial()
        CargarAutores()
        CargarCategoria()
        CargarIdioma()
        mostrarCantidadLibros()
        tbllibros.DataSource = CargarLibros()
    End Sub

    Public Function FiltroLibros() As DataTable
        Dim sql As String
        sql = "SELECT 
L.IdLibros AS CODIGO,
L.Titulo AS LIBRO, 
A.nombre AS AUTOR,
E.nombre AS EDITORIAL,
C.nombre AS CATEGORIA, 
I.nombre AS IDIOMA,
L.FechaPublicacion AS PUBLICACION,
L.Stock AS STOCK
FROM Libros L,Autores A,Editoriales E,Categorias C,Idiomas I
WHERE 
L.IdAutor=A.IdAutor AND
L.IdEditorial=E.IdEditorial AND
L.IdCategorias=C.IdCategorias AND
L.IdIdiomas=I.IdIdiomas AND L.Titulo like '%" + txtbuscar.Text + "%'"
        Dim da As New SqlDataAdapter(sql, conect)
        Dim tbl As New DataTable
        da.Fill(tbl)
        Return tbl
    End Function
    Public Function CargarLibros() As DataTable
        Dim da As New SqlDataAdapter("MostrarLibros", conect)
        Dim tbl As New DataTable
        da.Fill(tbl)
        Return tbl
    End Function

    Dim contador As Integer = 0
    Private Sub txtbuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtbuscar.KeyPress
        tbllibros.DataSource = FiltroLibros()
    End Sub



    Private Sub cbxFiltro_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbxFiltro.SelectedValueChanged
        tblinfo.DataSource = infoLibro()
        txtbuscar2.Text = ""
    End Sub


    Private Sub txtbuscar2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtbuscar2.KeyPress
        tblinfo.DataSource = infoLibro2()
    End Sub

    Private Sub txtmstock_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
            MsgBox("Solo se Admiten Numeros", MsgBoxStyle.Critical, Title:="Sistema Biblioteca")
        End If
    End Sub

    Private Sub txtstock_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
            MsgBox("Solo se Admiten Numeros", MsgBoxStyle.Critical, Title:="Sistema Biblioteca")
        End If
    End Sub

    Private Sub txttitulo_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
            MsgBox("Solo se Admiten Letras y numeros", MsgBoxStyle.Critical, Title:="Sistema Biblioteca")
        End If
    End Sub


End Class
