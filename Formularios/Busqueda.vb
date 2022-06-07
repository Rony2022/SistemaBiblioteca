Imports System.Data.SqlClient

Public Class BusquedaLibros
    Private Sub BusquedaLibros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tblbusqueda.DataSource = CargarLibros()
    End Sub
    Public Function CargarLibros() As DataTable
        Dim da As New SqlDataAdapter("MostrarLibros", conect)
        Dim tbl As New DataTable
        da.Fill(tbl)
        Return tbl
    End Function
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
L.IdIdiomas=I.IdIdiomas AND L.Titulo like '" + txtbuscar.Text + "%'"
        Dim da As New SqlDataAdapter(sql, conect)
        Dim tbl As New DataTable
        da.Fill(tbl)
        Return tbl
    End Function
    Private Sub txtbuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtbuscar.KeyPress
        tblbusqueda.DataSource = FiltroLibros()
    End Sub
End Class