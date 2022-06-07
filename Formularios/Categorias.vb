Imports System.Data.SqlClient

Public Class Categorias
    Dim contador As Integer
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        contador = contador + 1
        If contador = 1 Then
            btnAgregar.Text = "Guardar"
            txtcodigo.Enabled = False
            txtcategoria.Enabled = True
            btnModificar.Enabled = False
            btnEliminar.Enabled = False

        ElseIf contador = 2 Then
            txtcategoria.TabIndex = 1
            btnAgregar.TabIndex = 2
            guardar()
            contador = 0
        End If
    End Sub

    Public Sub mostrarCantidadCategorias()
        Try
            Abrir_Conexion()
            Dim sql As String
            Dim rs As SqlDataReader
            Dim com As New SqlCommand
            sql = "Select count(*) from categorias"
            com = New SqlCommand(sql, conect)
            rs = com.ExecuteReader()
            rs.Read()
            Dim Conteo As Integer
            Conteo = rs(0)
            btninf.Text = "Total de Categorias Registradas " & Conteo
            Cerrar_Conexion()
        Catch ex As Exception
            Cerrar_Conexion()
        End Try

    End Sub
    Public Sub mostrarCantidadcategoriasseleccionados()
        Try
            Abrir_Conexion()
            Dim sql As String
            Dim rs As SqlDataReader
            Dim com As New SqlCommand
            sql = "SELECT count(*) FROM categorias c,libros l WHERE c.IdCategorias=l.IdCategorias and c.nombre='" + txtcategoria.Text + "'"
            com = New SqlCommand(sql, conect)
            rs = com.ExecuteReader()
            rs.Read()
            Dim Conteo As Integer
            Conteo = rs(0)
            btntotalselect.Text = "Libros pertenecientes a la categoria seleccionada " & Conteo
            Cerrar_Conexion()
        Catch ex As Exception
            Cerrar_Conexion()
        End Try

    End Sub

    Public Function infocategoria() As DataTable
        Dim sql As String
        sql = "Select l.Titulo As LIBRO,c.nombre As CATEGORIA FROM libros l,categorias c WHERE l.IdCategorias=c.IdCategorias And c.nombre='" + txtcategoria.Text + "'"
        Dim da As New SqlDataAdapter(sql, conect)
        Dim tbl As New DataTable
        da.Fill(tbl)
        Return tbl
    End Function

    Private Sub Categorias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtcodigo.Enabled = False
        txtcategoria.Enabled = False
        tblcategorias.DataSource = CargarCategorias()
        btnModificar.Enabled = False
        btnEliminar.Enabled = False
        mostrarCantidadCategorias()
        mostrarCantidadcategoriasseleccionados()
    End Sub

    Public Function FiltroIdioma() As DataTable
        Dim sql As String
        sql = "select IdCategorias as CODIGO,nombre as CATEGORIA from Categorias where nombre Like '%" + txtbuscar.Text + "%'"
        Dim da As New SqlDataAdapter(sql, conect)
        Dim tbl As New DataTable
        da.Fill(tbl)
        Return tbl
    End Function

    Public Function CargarCategorias() As DataTable
        Dim da As New SqlDataAdapter("MostrarCategorias", conect)
        Dim tbl As New DataTable
        da.Fill(tbl)
        Return tbl
    End Function

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim act As New SqlCommand
        If txtcodigo.Text <> "" And txtcategoria.Text <> "" Then

            Try
                Abrir_Conexion()
                act = New SqlCommand("ActualizarCategoria", conect)

                act.CommandType = CommandType.StoredProcedure
                act.Parameters.AddWithValue("@IdCategorias", txtcodigo.Text)
                act.Parameters.AddWithValue("@nombre", txtcategoria.Text)
                act.ExecuteNonQuery()
                Cerrar_Conexion()
                MsgBox("Categoria: " & txtcategoria.Text & " Modificada Exitosamente", MsgBoxStyle.Information, Title:="Sistema Biblioteca")
                txtcodigo.Text = ""
                txtcategoria.Text = ""
                txtcodigo.Enabled = False
                txtcategoria.Enabled = False
                btnAgregar.Enabled = True
                btnEliminar.Enabled = False
                btnModificar.Enabled = False
                tblcategorias.DataSource = CargarCategorias()
            Catch ex As Exception
                MsgBox(ex.ToString)
                Cerrar_Conexion()
                txtcodigo.Text = ""
                txtcategoria.Text = ""
                txtcodigo.Enabled = False
                txtcategoria.Enabled = False
                btnAgregar.Enabled = True
                btnEliminar.Enabled = False
                btnModificar.Enabled = False
                tblcategorias.DataSource = CargarCategorias()
            End Try
        Else
            MsgBox("LLene los campos", MsgBoxStyle.Information, Title:="Sistema Biblioteca")

        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim del As New SqlCommand
        If txtcodigo.Text <> "" Then

            Try
                Abrir_Conexion()
                del = New SqlCommand("EliminarCategoria", conect)

                del.CommandType = CommandType.StoredProcedure
                del.Parameters.AddWithValue("@IdCategoria", txtcodigo.Text)
                del.ExecuteNonQuery()
                Cerrar_Conexion()
                MsgBox("Categoria Eliminada Exitosamente", MsgBoxStyle.Information, Title:="Sistema Biblioteca")
                txtcategoria.Text = ""
                txtcodigo.Enabled = False
                txtcategoria.Enabled = False
                btnEliminar.Enabled = False
                btnModificar.Enabled = False
                btnAgregar.Enabled = True
                tblcategorias.DataSource = CargarCategorias()
            Catch ex As Exception
                MsgBox("No existe Ninguna categoria con ese codigo", MsgBoxStyle.Critical, Title:="Sistema Biblioteca")
                txtcategoria.Text = ""
                txtcodigo.Enabled = False
                txtcategoria.Enabled = False
                btnEliminar.Enabled = False
                btnModificar.Enabled = False
                btnAgregar.Enabled = True
                tblcategorias.DataSource = CargarCategorias()
                Cerrar_Conexion()
            End Try
        Else
            MsgBox("Ingrese un codigo para poder eliminar una categoria", MsgBoxStyle.Information, Title:="Sistema Biblioteca")

        End If

    End Sub
    Private Sub guardar()
        Dim cmd As New SqlCommand
        If txtcategoria.Text <> "" Then

            Try
                Abrir_Conexion()
                cmd = New SqlCommand("NuevaCategoria", conect)

                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@nombre", txtcategoria.Text)
                cmd.ExecuteNonQuery()
                Cerrar_Conexion()
                MsgBox("Categoria: " & txtcategoria.Text & " agregada Exitosamente", MsgBoxStyle.Information, Title:="Sistema Biblioteca")

                txtcodigo.Text = ""
                txtcategoria.Text = ""
                tblcategorias.DataSource = CargarCategorias()

                btnAgregar.Text = "Agregar"
                btnModificar.Enabled = False
                btnEliminar.Enabled = False
                txtcodigo.Enabled = False
                txtcategoria.Enabled = False

            Catch ex As Exception
                MsgBox(ex.ToString & "El Codigo:" & txtcategoria.Text & " Ya se ha asignado a otra categoria", MsgBoxStyle.Critical, Title:="Sistema Biblioteca")
                txtcodigo.Text = ""
                txtcategoria.Text = ""
                tblcategorias.DataSource = CargarCategorias()

                btnAgregar.Text = "Agregar"
                btnModificar.Enabled = False
                btnEliminar.Enabled = False
                txtcodigo.Enabled = False
                txtcategoria.Enabled = False
                Cerrar_Conexion()

            End Try
        Else
            MsgBox("LLene los campos", MsgBoxStyle.Information, Title:="Sistema Biblioteca")

        End If
    End Sub
    Private Sub txtacategoria_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
            MsgBox("Solo se Admiten Letras", MsgBoxStyle.Critical, Title:="Sistema Biblioteca")
        End If
    End Sub

    Private Sub txtmcategoria_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcategoria.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
            MsgBox("Solo se Admiten Letras", MsgBoxStyle.Critical, Title:="Sistema Biblioteca")
        End If
    End Sub

    Private Sub txtMCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcodigo.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
            MsgBox("Solo se Admiten Numeros", MsgBoxStyle.Critical, Title:="Sistema Biblioteca")
        End If
    End Sub

    Private Sub txtecodigo_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
            MsgBox("Solo se Admiten Numeros", MsgBoxStyle.Critical, Title:="Sistema Biblioteca")
        End If
    End Sub

    Private Sub txtbuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtbuscar.KeyPress
        tblcategorias.DataSource = FiltroIdioma()
    End Sub

    Private Sub tblcategorias_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles tblcategorias.CellContentClick
        txtcodigo.Enabled = False
        txtcategoria.Enabled = True
        btnModificar.Enabled = True
        btnAgregar.Enabled = False
        btnEliminar.Enabled = True
        txtcodigo.Text = tblcategorias.Item(0, e.RowIndex).Value
        txtcategoria.Text = tblcategorias.Item(1, e.RowIndex).Value
        mostrarCantidadcategoriasseleccionados()
        tblinfo.DataSource = infocategoria()
    End Sub
End Class