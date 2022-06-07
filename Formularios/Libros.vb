Imports System.Data.SqlClient

Public Class Libros

    Public Function CargarEditorial()
        Dim sql As String = "SELECT IdEditorial,nombre FROM Editoriales"
        Dim da As New SqlDataAdapter(sql, conect)
        Dim dt As New DataTable("Editoriales")
        da.Fill(dt)
        With Me.cbxeditorial
            .DataSource = dt
            .DisplayMember = "nombre"
            .ValueMember = "IdEditorial"
        End With
        Return dt
    End Function

    Public Function CargarAutores()
        Dim sql As String = "SELECT IdAutor,nombre FROM Autores"
        Dim da As New SqlDataAdapter(sql, conect)
        Dim dt As New DataTable("Autores")
        da.Fill(dt)
        With Me.cbxautores
            .DataSource = dt
            .DisplayMember = "nombre"
            .ValueMember = "IdAutor"
        End With
        Return dt
    End Function

    Public Function CargarCategoria()
        Dim sql As String = "SELECT IdCategorias,nombre FROM Categorias"
        Dim da As New SqlDataAdapter(sql, conect)
        Dim dt As New DataTable("Categorias")
        da.Fill(dt)
        With Me.cbxcategoria
            .DataSource = dt
            .DisplayMember = "nombre"
            .ValueMember = "IdCategorias"
        End With
        Return dt
    End Function

    Public Function CargarIdioma()
        Dim sql As String = "SELECT IdIdiomas,nombre FROM Idiomas"
        Dim da As New SqlDataAdapter(sql, conect)
        Dim dt As New DataTable("Idiomas")
        da.Fill(dt)
        With Me.cbxidioma
            .DataSource = dt
            .DisplayMember = "nombre"
            .ValueMember = "IdIdiomas"
        End With
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
        txtcodigo.Enabled = False
        txtfecha.Enabled = False
        cbxautores.Enabled = False
        cbxeditorial.Enabled = False
        cbxcategoria.Enabled = False
        cbxidioma.Enabled = False
        txttitulo.Enabled = False
        txtstock.Enabled = False
        btnModificar.Enabled = False
        btnEliminar.Enabled = False
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
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        contador = contador + 1
        If contador = 1 Then
            btnAgregar.Text = "Guardar"
            txtcodigo.Enabled = False
            txtfecha.Enabled = True
            cbxautores.Enabled = True
            cbxcategoria.Enabled = True
            cbxidioma.Enabled = True
            txttitulo.Enabled = True
            txtstock.Enabled = True

            btnModificar.Enabled = False
            btnEliminar.Enabled = False

        ElseIf contador = 2 Then
            txtcodigo.TabIndex = 1
            txtfecha.TabIndex = 2
            cbxautores.TabIndex = 3
            cbxcategoria.TabIndex = 4
            cbxidioma.TabIndex = 5
            txttitulo.TabIndex = 6
            txtstock.TabIndex = 7
            btnAgregar.TabIndex = 8
            guardar()
            contador = 0
        End If
    End Sub
    Private Sub guardar()
        Dim cmd As New SqlCommand
        If txttitulo.Text <> "" And txtfecha.Text <> "  /  /" And txtstock.Text <> "" Then
            Try
                Abrir_Conexion()
                cmd = New SqlCommand("NuevoLibro", conect)
                'parametros
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@IdAutor", cbxautores.SelectedValue.ToString)
                cmd.Parameters.AddWithValue("@IdEditorial", cbxeditorial.SelectedValue.ToString)
                cmd.Parameters.AddWithValue("@IdCategorias", cbxcategoria.SelectedValue.ToString)
                cmd.Parameters.AddWithValue("@IdIdiomas", cbxidioma.SelectedValue.ToString)
                cmd.Parameters.AddWithValue("@Titulo", txttitulo.Text)
                cmd.Parameters.AddWithValue("@FechaPublicacion", txtfecha.Text.ToString)
                cmd.Parameters.AddWithValue("@Stock", txtstock.Text)
                cmd.ExecuteNonQuery()
                Cerrar_Conexion()

                MsgBox("Autor: " & txttitulo.Text & " agregado Exitosamente", MsgBoxStyle.Information, Title:="Sistema Biblioteca")
                Cerrar_Conexion()
                txtcodigo.Text = ""
                txtfecha.Text = ""
                cbxautores.Enabled = False
                cbxcategoria.Enabled = False
                cbxidioma.Enabled = False
                txttitulo.Text = ""
                txtstock.Text = ""
                btnAgregar.Text = "Agregar"
                mostrarCantidadLibros()
                tbllibros.DataSource = CargarLibros()
                Inicio.mostrarCantidadLibros()
                txtcodigo.Enabled = False
                cbxeditorial.Enabled = False
                txtfecha.Enabled = False
                cbxautores.Enabled = False
                cbxcategoria.Enabled = False
                cbxidioma.Enabled = False
                txttitulo.Enabled = False
                txtstock.Enabled = False
                btnModificar.Enabled = False
                btnEliminar.Enabled = False

            Catch ex As Exception
                MsgBox(ex.ToString & "Error al registrar", MsgBoxStyle.Critical, Title:="Sistema Biblioteca")
                Cerrar_Conexion()
                Inicio.mostrarCantidadLibros()
                txtcodigo.Text = ""
                txtfecha.Text = ""
                cbxautores.Enabled = False
                cbxcategoria.Enabled = False
                cbxidioma.Enabled = False
                txttitulo.Text = ""
                txtstock.Text = ""
                btnAgregar.Text = "Agregar"
                mostrarCantidadLibros()
                tbllibros.DataSource = CargarLibros()
                txtcodigo.Enabled = False
                cbxeditorial.Enabled = False
                txtfecha.Enabled = False
                cbxautores.Enabled = False
                cbxcategoria.Enabled = False
                cbxidioma.Enabled = False
                txttitulo.Enabled = False
                txtstock.Enabled = False
                btnModificar.Enabled = False
                btnEliminar.Enabled = False
            End Try
        Else
            MsgBox("LLene los campos", MsgBoxStyle.Information, Title:="Sistema Biblioteca")

        End If
    End Sub

    Private Sub AgregarStock()
        Dim cmd As New SqlCommand
        If txtmstock.Text <> "" Then
            Try
                Abrir_Conexion()
                cmd = New SqlCommand("CargarStock", conect)
                'parametros
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@nombre", txtmlibro.Text)
                cmd.Parameters.AddWithValue("@cantidad", txtmstock.Text)
                cmd.ExecuteNonQuery()
                Cerrar_Conexion()

                MsgBox("Cantidad Cargada Correctamente", MsgBoxStyle.Information, Title:="Sistema Biblioteca")
                Cerrar_Conexion()
                txtmlibro.Text = ""
                txtmstock.Text = ""
                mostrarCantidadLibros()
                tbllibros.DataSource = CargarLibros()
                Inicio.mostrarCantidadLibros()

            Catch ex As Exception
                MsgBox("Error al cargar", MsgBoxStyle.Critical, Title:="Sistema Biblioteca")
                Cerrar_Conexion()
                txtmlibro.Text = ""
                txtmstock.Text = ""
                mostrarCantidadLibros()
                tbllibros.DataSource = CargarLibros()
                Inicio.mostrarCantidadLibros()
            End Try
        Else
            MsgBox("LLene los campos", MsgBoxStyle.Information, Title:="Sistema Biblioteca")
        End If



    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim cmd As New SqlCommand
        If txttitulo.Text <> "" And txtfecha.Text <> "  /  /" And txtstock.Text <> "" Then
            Try
                Abrir_Conexion()
                cmd = New SqlCommand("ModificarLibros", conect)

                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@IdLibros", txtcodigo.Text)

                With Me.cbxautores
                    .DisplayMember = "nombre"
                    .ValueMember = "IdAutor"
                End With
                cmd.Parameters.AddWithValue("@IdAutor", cbxautores.SelectedValue.ToString)

                With Me.cbxeditorial
                    .DisplayMember = "nombre"
                    .ValueMember = "IdEditorial"
                End With

                cmd.Parameters.AddWithValue("@IdEditorial", cbxeditorial.SelectedValue.ToString)

                With Me.cbxcategoria
                    .DisplayMember = "nombre"
                    .ValueMember = "IdCategorias"
                End With

                cmd.Parameters.AddWithValue("@IdCategorias", cbxcategoria.SelectedValue.ToString)


                With Me.cbxidioma
                    .DisplayMember = "nombre"
                    .ValueMember = "IdIdiomas"
                End With

                cmd.Parameters.AddWithValue("@IdIdiomas", cbxidioma.SelectedValue.ToString)
                cmd.Parameters.AddWithValue("@Titulo", txttitulo.Text)
                cmd.Parameters.AddWithValue("@FechaPublicacion", txtfecha.Text.ToString)
                cmd.Parameters.AddWithValue("@Stock", txtstock.Text)
                cmd.ExecuteNonQuery()
                Cerrar_Conexion()

                MsgBox("Autor: " & txttitulo.Text & " Modificado Exitosamente", MsgBoxStyle.Information, Title:="Sistema Biblioteca")
                Cerrar_Conexion()
                txtcodigo.Text = ""
                txtfecha.Text = ""
                cbxautores.Enabled = False
                cbxcategoria.Enabled = False
                cbxidioma.Enabled = False
                txttitulo.Text = ""
                txtstock.Text = ""
                btnAgregar.Text = "Agregar"
                tbllibros.DataSource = CargarLibros()
                Inicio.mostrarCantidadLibros()
                txtcodigo.Enabled = False
                cbxeditorial.Enabled = False
                txtfecha.Enabled = False
                cbxautores.Enabled = False
                cbxcategoria.Enabled = False
                cbxidioma.Enabled = False
                txttitulo.Enabled = False
                txtstock.Enabled = False
                btnAgregar.Enabled = True
                btnEliminar.Enabled = False
                btnModificar.Enabled = False

            Catch ex As Exception
                MsgBox(ex.ToString & "Error al Modificar", MsgBoxStyle.Critical, Title:="Sistema Biblioteca")
                Cerrar_Conexion()
                Inicio.mostrarCantidadLibros()
                txtcodigo.Text = ""
                txtfecha.Text = ""
                cbxautores.Enabled = False
                cbxcategoria.Enabled = False
                cbxidioma.Enabled = False
                txttitulo.Text = ""
                txtstock.Text = ""
                btnAgregar.Text = "Agregar"
                tbllibros.DataSource = CargarLibros()

                txtcodigo.Enabled = False
                cbxeditorial.Enabled = False
                txtfecha.Enabled = False
                cbxautores.Enabled = False
                cbxcategoria.Enabled = False
                cbxidioma.Enabled = False
                txttitulo.Enabled = False
                txtstock.Enabled = False
                btnAgregar.Enabled = True
                btnEliminar.Enabled = False
                btnModificar.Enabled = False
            End Try
        Else
            MsgBox("LLene los campos", MsgBoxStyle.Information, Title:="Sistema Biblioteca")

        End If
    End Sub

    Private Sub tbllibros_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles tbllibros.CellContentClick
        txtcodigo.Enabled = False
        txtfecha.Enabled = True
        cbxautores.Enabled = True
        cbxeditorial.Enabled = True
        cbxcategoria.Enabled = True
        cbxidioma.Enabled = True
        txttitulo.Enabled = True
        txtstock.Enabled = True
        btnModificar.Enabled = True
        btnAgregar.Enabled = False
        btnEliminar.Enabled = True

        txtcodigo.Text = tbllibros.Item(0, e.RowIndex).Value
        txttitulo.Text = tbllibros.Item(1, e.RowIndex).Value
        txtmlibro.Text = tbllibros.Item(1, e.RowIndex).Value
        With Me.cbxautores
            .DisplayMember = "nombre"
            .ValueMember = "nombre"
        End With
        cbxautores.SelectedValue = tbllibros.Item(2, e.RowIndex).Value
        With Me.cbxeditorial
            .DisplayMember = "nombre"
            .ValueMember = "nombre"
        End With
        cbxeditorial.SelectedValue = tbllibros.Item(3, e.RowIndex).Value
        With Me.cbxcategoria
            .DisplayMember = "nombre"
            .ValueMember = "nombre"
        End With
        cbxcategoria.SelectedValue = tbllibros.Item(4, e.RowIndex).Value
        With Me.cbxidioma
            .DisplayMember = "nombre"
            .ValueMember = "nombre"
        End With
        cbxidioma.SelectedValue = tbllibros.Item(5, e.RowIndex).Value


        txtfecha.Text = tbllibros.Item(6, e.RowIndex).Value
        txtstock.Text = tbllibros.Item(7, e.RowIndex).Value

        btnactual.Text = "Cantidad Actual: " & tbllibros.Item(7, e.RowIndex).Value

    End Sub

    Private Sub txtbuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtbuscar.KeyPress
        tbllibros.DataSource = FiltroLibros()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim cmd As New SqlCommand
        If txtcodigo.Text <> "" Then
            Try
                Abrir_Conexion()
                cmd = New SqlCommand("EliminarLibro", conect)

                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@IdLibros", txtcodigo.Text)
                cmd.ExecuteNonQuery()
                Cerrar_Conexion()

                MsgBox("Autor: " & txttitulo.Text & " Eliminado Exitosamente", MsgBoxStyle.Information, Title:="Sistema Biblioteca")
                Cerrar_Conexion()
                txtcodigo.Text = ""
                txtfecha.Text = ""
                cbxautores.Enabled = False
                cbxcategoria.Enabled = False
                cbxidioma.Enabled = False
                txttitulo.Text = ""
                txtstock.Text = ""
                btnAgregar.Text = "Agregar"
                tbllibros.DataSource = CargarLibros()
                Inicio.mostrarCantidadLibros()
                txtcodigo.Enabled = False
                cbxeditorial.Enabled = False
                txtfecha.Enabled = False
                cbxautores.Enabled = False
                cbxcategoria.Enabled = False
                cbxidioma.Enabled = False
                txttitulo.Enabled = False
                txtstock.Enabled = False
                btnAgregar.Enabled = True
                btnEliminar.Enabled = False
                btnModificar.Enabled = False

            Catch ex As Exception
                MsgBox(ex.ToString & "Error al Eliminar", MsgBoxStyle.Critical, Title:="Sistema Biblioteca")
                Cerrar_Conexion()
                Inicio.mostrarCantidadLibros()
                txtcodigo.Text = ""
                txtfecha.Text = ""
                cbxautores.Enabled = False
                cbxcategoria.Enabled = False
                cbxidioma.Enabled = False
                txttitulo.Text = ""
                txtstock.Text = ""
                btnAgregar.Text = "Agregar"
                tbllibros.DataSource = CargarLibros()

                txtcodigo.Enabled = False
                cbxeditorial.Enabled = False
                txtfecha.Enabled = False
                cbxautores.Enabled = False
                cbxcategoria.Enabled = False
                cbxidioma.Enabled = False
                txttitulo.Enabled = False
                txtstock.Enabled = False
                btnAgregar.Enabled = True
                btnEliminar.Enabled = False
                btnModificar.Enabled = False
            End Try
        Else
            MsgBox("LLene los campos", MsgBoxStyle.Information, Title:="Sistema Biblioteca")

        End If
    End Sub

    Private Sub btnastock_Click(sender As Object, e As EventArgs) Handles btnastock.Click
        AgregarStock()
        mostrarCantidadLibros()
    End Sub

    Private Sub cbxFiltro_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbxFiltro.SelectedValueChanged
        tblinfo.DataSource = infoLibro()
        txtbuscar2.Text = ""
    End Sub


    Private Sub txtbuscar2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtbuscar2.KeyPress
        tblinfo.DataSource = infoLibro2()
    End Sub

    Private Sub txtmstock_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtmstock.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        MsgBox("Solo se Admiten Numeros", MsgBoxStyle.Critical, Title:="Sistema Biblioteca")
        End If
    End Sub

    Private Sub txtstock_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtstock.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
            MsgBox("Solo se Admiten Numeros", MsgBoxStyle.Critical, Title:="Sistema Biblioteca")
        End If
    End Sub

    Private Sub txttitulo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttitulo.KeyPress
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
