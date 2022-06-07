Imports System.Data.SqlClient

Public Class Autores
    Public Function CargarAutores() As DataTable
        Dim da As New SqlDataAdapter("MostrarAutores", conect)
        Dim tbl As New DataTable
        da.Fill(tbl)
        Return tbl
    End Function

    Public Function FiltroAutores() As DataTable
        Dim sql As String
        sql = "select a.IdAutor as CODIGO,a.nombre AS AUTOR,p.nombre AS PAIS,a.email AS EMAIL,a.direccion AS DIRECCION 
from Autores a,paises p 
where a.IdPais=p.IdPais and a.nombre Like '" + txtbuscar.Text + "%'"
        Dim da As New SqlDataAdapter(sql, conect)
        Dim tbl As New DataTable
        da.Fill(tbl)
        Return tbl
    End Function

    Public Function CargarPaises()
        Dim sql As String = "SELECT IdPais,nombre FROM paises"
        Dim da As New SqlDataAdapter(sql, conect)
        Dim dt As New DataTable("Paises")
        da.Fill(dt)
        With Me.cbxpais
            .DataSource = dt
            .DisplayMember = "nombre"
            .ValueMember = "IdPais"
        End With
        Return dt
    End Function
    Public Sub mostrarCantidadAutoresseleccionados()
        Try
            Abrir_Conexion()
            Dim sql As String
            Dim rs As SqlDataReader
            Dim com As New SqlCommand
            sql = "SELECT count(*) FROM Autores a,Libros l WHERE a.IdAutor=l.IdAutor and a.nombre='" + txtautor.Text + "'"
            com = New SqlCommand(sql, conect)
            rs = com.ExecuteReader()
            rs.Read()
            Dim Conteo As Integer
            Conteo = rs(0)
            btntotalselect.Text = "Autores de Libros Seleccionados " & Conteo
            Cerrar_Conexion()
        Catch ex As Exception
            Cerrar_Conexion()
        End Try

    End Sub
    Public Sub mostrarCantidadAutores()
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
            btninf.Text = "Total de Autores Registrados " & Conteo
            Cerrar_Conexion()
        Catch ex As Exception
            Cerrar_Conexion()
        End Try

    End Sub
    Private Sub Autores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarPaises()
        cbxpais.Enabled = False
        txtcodigo.Enabled = False
        txtautor.Enabled = False
        txtdireccion.Enabled = False
        txtemail.Enabled = False
        tblautor.DataSource = CargarAutores()
        btnModificar.Enabled = False
        btnEliminar.Enabled = False
        mostrarCantidadAutores()
        mostrarCantidadAutoresseleccionados()

    End Sub
    Dim contador As Integer = 0
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        contador = contador + 1
        If contador = 1 Then
            cbxpais.Enabled = True
            txtcodigo.TabIndex = False
            btnAgregar.Text = "Guardar"
            txtcodigo.Enabled = False
            txtautor.Enabled = True
            txtdireccion.Enabled = True
            txtemail.Enabled = True
            btnModificar.Enabled = False
            btnEliminar.Enabled = False

        ElseIf contador = 2 Then
            cbxpais.Enabled = True
            txtcodigo.TabIndex = False
            txtautor.TabIndex = 0
            cbxpais.TabIndex = 1
            txtdireccion.TabIndex = 2
            txtemail.TabIndex = 3
            btnAgregar.TabIndex = 4
            guardar()
            contador = 0
        End If
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim cmd As New SqlCommand
        If txtautor.Text <> "" And txtdireccion.Text <> "" And txtemail.Text <> "" Then
            Try


                Abrir_Conexion()
                cmd = New SqlCommand("ModificarAutor", conect)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@IdAutor", txtcodigo.Text)
                cmd.Parameters.AddWithValue("@nombre", txtautor.Text)
                With Me.cbxpais
                    .DisplayMember = "nombre"
                    .ValueMember = "IdPais"
                End With
                cmd.Parameters.AddWithValue("@IdPais", cbxpais.SelectedValue.ToString)
                cmd.Parameters.AddWithValue("@email", txtemail.Text)
                cmd.Parameters.AddWithValue("@direccion", txtdireccion.Text)
                cmd.ExecuteNonQuery()
                Cerrar_Conexion()

                MsgBox("Autor: " & txtautor.Text & " agregado Exitosamente", MsgBoxStyle.Information, Title:="Sistema Biblioteca")
                txtcodigo.Text = ""
                cbxpais.Enabled = False
                txtautor.Text = ""
                txtdireccion.Text = ""
                txtemail.Text = ""
                txtautor.Text = ""
                cbxpais.Enabled = False
                txtcodigo.Enabled = False
                txtautor.Enabled = False
                txtdireccion.Enabled = False
                txtemail.Enabled = False
                btnAgregar.Enabled = True
                btnEliminar.Enabled = False
                btnModificar.Enabled = False
                tblautor.DataSource = CargarAutores()
            Catch ex As Exception
                MsgBox(ex.ToString & "Error", MsgBoxStyle.Critical, Title:="Sistema Biblioteca")
                txtcodigo.Text = ""
                cbxpais.Enabled = False
                txtautor.Text = ""
                txtdireccion.Text = ""
                txtemail.Text = ""
                txtcodigo.Enabled = False
                txtautor.Enabled = False
                txtdireccion.Enabled = False
                txtemail.Enabled = False
                btnAgregar.Enabled = True
                btnEliminar.Enabled = False
                btnModificar.Enabled = False
                tblautor.DataSource = CargarAutores()
                Cerrar_Conexion()

            End Try
        Else
            MsgBox("LLene los campos", MsgBoxStyle.Information, Title:="Sistema Biblioteca")

        End If
    End Sub
    Private Sub guardar()
        Dim cmd As New SqlCommand
        If txtautor.Text <> "" And txtdireccion.Text <> "" And txtemail.Text <> "" Then
            Try
                Abrir_Conexion()
                cmd = New SqlCommand("NuevoAutor", conect)
                CargarPaises()
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@nombre", txtautor.Text)
                cmd.Parameters.AddWithValue("@IdPais", cbxpais.SelectedValue)
                cmd.Parameters.AddWithValue("@email", txtemail.Text)
                cmd.Parameters.AddWithValue("@direccion", txtdireccion.Text)
                cmd.ExecuteNonQuery()
                Cerrar_Conexion()

                MsgBox("Autor: " & txtautor.Text & " agregado Exitosamente", MsgBoxStyle.Information, Title:="Sistema Biblioteca")
                txtcodigo.Text = ""
                txtautor.Text = ""
                cbxpais.Enabled = False
                txtdireccion.Text = ""
                txtemail.Text = ""
                btnAgregar.Text = "Agregar"
                btnModificar.Enabled = False
                btnEliminar.Enabled = False
                txtcodigo.Enabled = False
                txtautor.Enabled = False
                txtdireccion.Enabled = False
                txtemail.Enabled = False
                tblautor.DataSource = CargarAutores()
            Catch ex As Exception
                MsgBox(ex.ToString & "Error", MsgBoxStyle.Critical, Title:="Sistema Biblioteca")
                txtcodigo.Text = ""
                txtautor.Text = ""
                txtautor.Text = ""
                cbxpais.Enabled = False
                txtdireccion.Text = ""
                txtemail.Text = ""
                btnAgregar.Text = "Agregar"
                btnModificar.Enabled = False
                btnEliminar.Enabled = False
                txtcodigo.Enabled = False
                txtautor.Enabled = False
                txtdireccion.Enabled = False
                txtemail.Enabled = False
                tblautor.DataSource = CargarAutores()
                Cerrar_Conexion()
            End Try
        Else
            MsgBox("LLene los campos", MsgBoxStyle.Information, Title:="Sistema Biblioteca")

        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim del As New SqlCommand

        Try
            Abrir_Conexion()
            del = New SqlCommand("EliminarAutor", conect)

            del.CommandType = CommandType.StoredProcedure
            del.Parameters.AddWithValue("@IdAutor", txtcodigo.Text)
            del.ExecuteNonQuery()
            Cerrar_Conexion()
            MsgBox("Autor Eliminado Exitosamente", MsgBoxStyle.Information, Title:="Sistema Biblioteca")
            txtcodigo.Text = ""
            txtautor.Text = ""
            txtdireccion.Text = ""
            txtemail.Text = ""
            cbxpais.Enabled = False
            txtcodigo.Enabled = False
            txtautor.Enabled = False
            txtdireccion.Enabled = False
            txtemail.Enabled = False
            btnAgregar.Enabled = True
            btnEliminar.Enabled = False
            btnModificar.Enabled = False
            tblautor.DataSource = CargarAutores()

        Catch ex As Exception
            MsgBox("ERROR", MsgBoxStyle.Critical, Title:="Sistema Biblioteca")
            txtcodigo.Text = ""
            txtautor.Text = ""
            txtdireccion.Text = ""
            txtemail.Text = ""
            txtcodigo.Enabled = False
            txtautor.Enabled = False
            cbxpais.Enabled = False
            txtdireccion.Enabled = False
            txtemail.Enabled = False
            btnAgregar.Enabled = True
            btnEliminar.Enabled = False
            btnModificar.Enabled = False
            tblautor.DataSource = CargarAutores()
            Cerrar_Conexion()
        End Try
    End Sub

    Private Sub tblautor_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblautor.CellContentClick
        txtcodigo.Enabled = False
        txtautor.Enabled = True
        cbxpais.Enabled = True
        txtdireccion.Enabled = True
        txtemail.Enabled = True
        btnModificar.Enabled = True
        btnAgregar.Enabled = False
        btnEliminar.Enabled = True
        txtcodigo.Text = tblautor.Item(0, e.RowIndex).Value
        txtautor.Text = tblautor.Item(1, e.RowIndex).Value
        With Me.cbxpais
            .DisplayMember = "nombre"
            .ValueMember = "nombre"
        End With
        cbxpais.SelectedValue = tblautor.Item(2, e.RowIndex).Value
        txtemail.Text = tblautor.Item(3, e.RowIndex).Value
        txtdireccion.Text = tblautor.Item(4, e.RowIndex).Value
        mostrarCantidadAutoresseleccionados()
        tblinfo.DataSource = infoAutores()
    End Sub
    Public Function infoAutores() As DataTable
        Dim sql As String
        sql = "Select l.Titulo As LIBRO,a.nombre As Autor FROM libros l,Autores a WHERE a.IdAutor=l.IdAutor And a.nombre='" + txtautor.Text + "'"
        Dim da As New SqlDataAdapter(sql, conect)
        Dim tbl As New DataTable
        da.Fill(tbl)
        Return tbl
    End Function
    Private Sub txtbuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtbuscar.KeyPress
        tblautor.DataSource = FiltroAutores()
    End Sub

    Private Sub txtemail_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtemail.KeyPress

    End Sub

    Private Sub txtemail_Leave(sender As Object, e As EventArgs) Handles txtemail.Leave
        If InStr(txtemail.Text, "@") <= 0 And InStr(txtemail.Text, ".") <= 0 Then
            MsgBox("Correo Invalido", MsgBoxStyle.Critical, Title:="Sistema Biblioteca")
            txtemail.Text = ""
        End If
    End Sub

    Private Sub txtdireccion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtdireccion.KeyPress
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