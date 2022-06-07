Imports System.Data.SqlClient

Public Class Movimientos
    Private Sub Movimientos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarLibros()
        tbllibros.DataSource = CargarDatos()
        tbllibro.DataSource = CargarLibroFiltro()

    End Sub

    Public Function CargarDatos() As DataTable
        Dim da As New SqlDataAdapter("cargarLibros", conect)
        Dim tbl As New DataTable
        da.Fill(tbl)
        Return tbl
    End Function

    Public Function CargarLibroFiltro() As DataTable
        Dim da As New SqlDataAdapter("Select Titulo From Libros", conect)
        Dim tbl As New DataTable
        da.Fill(tbl)
        Return tbl
    End Function
    Public Function CargarLibroFiltroseleccionado() As DataTable
        Dim sql As String
        sql = "Select Titulo From Libros where Titulo Like '%" + txtbuscar.Text + "%'"
        Dim da As New SqlDataAdapter(sql, conect)
        Dim tbl As New DataTable
        da.Fill(tbl)
        Return tbl
    End Function
    Public Function CargarLibros()
        Dim sql As String = "SELECT IdLibros,Titulo FROM Libros"
        Dim da As New SqlDataAdapter(sql, conect)
        Dim dt As New DataTable("Libros")
        da.Fill(dt)
        With Me.cbxlibro
            .DataSource = dt
            .DisplayMember = "Titulo"
            .ValueMember = "IdLibros"
        End With
        Return dt
    End Function
    Private Sub prestamo()
        If txtcantidad.Text <> "" And txtestudiante.Text <> "" Then
            Try

                Dim cmd As New SqlCommand
                Abrir_Conexion()
                cmd = New SqlCommand("prestamos", conect)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@opcion", cbxopcion.SelectedItem)
                cmd.Parameters.AddWithValue("@estudiante", txtestudiante.Text)
                cmd.Parameters.AddWithValue("@prestamos", txtcantidad.Text)
                With Me.cbxlibro
                    .DisplayMember = "Titulo"
                    .ValueMember = "IdLibros"
                End With
                cmd.Parameters.AddWithValue("@IdLibros", cbxlibro.SelectedValue.ToString)
                Dim respuesta = cmd.ExecuteNonQuery()
                If (respuesta > 0) Then
                    MsgBox("Prestamo Realizado", MsgBoxStyle.Information, Title:="Sistema Biblioteca")
                    Cerrar_Conexion()
                    tbllibros.DataSource = CargarDatos()
                Else
                    MsgBox("Stock Insuficiente", MsgBoxStyle.Critical, Title:="Sistema Biblioteca")
                    tbllibros.DataSource = CargarDatos()
                End If
            Catch ex As Exception
                MsgBox("Error", MsgBoxStyle.Critical, Title:="Sistema Biblioteca")
                Cerrar_Conexion()
                tbllibros.DataSource = CargarDatos()

            End Try
        Else
            MsgBox("LLene los campos", MsgBoxStyle.Information, Title:="Sistema Biblioteca")
        End If
    End Sub


    Private Sub Devolucion()
        If txtcantidad.Text <> "" And txtestudiante.Text <> "" Then
            Try

                Dim cmd As New SqlCommand
                Abrir_Conexion()
                cmd = New SqlCommand("devoluciones", conect)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@opcion", cbxopcion.SelectedItem)
                cmd.Parameters.AddWithValue("@estudiante", txtestudiante.Text)
                cmd.Parameters.AddWithValue("@devoluciones", txtcantidad.Text)
                With Me.cbxlibro
                    .DisplayMember = "Titulo"
                    .ValueMember = "IdLibros"
                End With
                cmd.Parameters.AddWithValue("@IdLibros", cbxlibro.SelectedValue.ToString)
                Dim respuesta = cmd.ExecuteNonQuery()
                If (respuesta > 0) Then
                    MsgBox("Devolucion Realizado", MsgBoxStyle.Information, Title:="Sistema Biblioteca")
                    Cerrar_Conexion()
                    tbllibros.DataSource = CargarDatos()
                Else
                    MsgBox("Verifique la Devolucion", MsgBoxStyle.Critical, Title:="Sistema Biblioteca")
                    tbllibros.DataSource = CargarDatos()
                End If
            Catch ex As Exception
                MsgBox("Error", MsgBoxStyle.Critical, Title:="Sistema Biblioteca")
                Cerrar_Conexion()
                tbllibros.DataSource = CargarDatos()

            End Try
        Else
            MsgBox("LLene los campos", MsgBoxStyle.Information, Title:="Sistema Biblioteca")
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click

        If (cbxopcion.SelectedItem = "Prestamo") Then
            prestamo()
            txtestudiante.Text = ""
            txtcantidad.Text = ""
        ElseIf (cbxopcion.SelectedItem = "Devolucion") Then
            Devolucion()
            txtestudiante.Text = ""
            txtcantidad.Text = ""

        Else
            MsgBox("Seleccione una Opcion", MsgBoxStyle.Information, Title:="Sistema Biblioteca")
        End If

    End Sub
    Private Sub tbllibros_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles tbllibros.CellContentClick

    End Sub

    Private Sub tbllibro_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles tbllibro.CellContentClick
        With Me.cbxlibro
            .DisplayMember = "Titulo"
            .ValueMember = "Titulo"
        End With
        cbxlibro.SelectedValue = tbllibro(0, e.RowIndex).Value
        txtestudiante.Enabled = True
        txtcantidad.Enabled = True
        cbxlibro.Enabled = True
    End Sub

    Private Sub txtbuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtbuscar.KeyPress
        tbllibro.DataSource = CargarLibroFiltroseleccionado()
    End Sub

    Private Sub txtcantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcantidad.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
            MsgBox("Solo se Admiten Numeros", MsgBoxStyle.Critical, Title:="Sistema Biblioteca")
        End If
    End Sub

    Private Sub txtestudiante_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtestudiante.KeyPress
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

    Private Sub cbxopcion_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbxopcion.SelectedValueChanged
        txtestudiante.Enabled = True
        txtcantidad.Enabled = True
        cbxlibro.Enabled = True
    End Sub
End Class