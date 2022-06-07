Imports System.Data.SqlClient

Public Class Paises

    Private Sub Paises_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tblpaises.DataSource = CargarPaises()
        txtcodigo.Enabled = False
        txtpais.Enabled = False
        btnModificar.Enabled = False
        btnEliminar.Enabled = False
        mostrarCantidadPaises()
        mostrarCantidadPaisesseleccionados()
    End Sub
    Public Function CargarPaises() As DataTable
        Dim da As New SqlDataAdapter("MostrarPaises", conect)
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
            txtpais.Enabled = True
            btnModificar.Enabled = False
            btnEliminar.Enabled = False

        ElseIf contador = 2 Then
            txtpais.TabIndex = 1
            btnAgregar.TabIndex = 2
            guardar()
            contador = 0
        End If
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim act As New SqlCommand
        If txtcodigo.Text <> "" And txtpais.Text <> "" Then

            Try
                Abrir_Conexion()
                act = New SqlCommand("ActualizarPais", conect)

                act.CommandType = CommandType.StoredProcedure
                act.Parameters.AddWithValue("@IdPais", txtcodigo.Text)
                act.Parameters.AddWithValue("@nombre", txtpais.Text)
                act.ExecuteNonQuery()
                Cerrar_Conexion()
                MsgBox("Pais:  " & txtpais.Text & " Modificado Exitosamente", MsgBoxStyle.Information, Title:="Sistema Biblioteca")

                txtcodigo.Text = ""
                txtpais.Text = ""
                txtcodigo.Enabled = False
                txtpais.Enabled = False
                btnAgregar.Enabled = True
                btnEliminar.Enabled = False
                btnModificar.Enabled = False
                tblpaises.DataSource = CargarPaises()
                mostrarCantidadPaises()
                mostrarCantidadPaisesseleccionados()
            Catch ex As Exception
                MsgBox("Error", ex.ToString)
                txtcodigo.Text = ""
                txtpais.Text = ""
                txtcodigo.Enabled = False
                txtpais.Enabled = False
                btnAgregar.Enabled = True
                btnEliminar.Enabled = False
                btnModificar.Enabled = False
                tblpaises.DataSource = CargarPaises()
                mostrarCantidadPaises()
                mostrarCantidadPaisesseleccionados()
                Cerrar_Conexion()
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
                del = New SqlCommand("EliminarPais", conect)

                del.CommandType = CommandType.StoredProcedure
                del.Parameters.AddWithValue("@IdPais", txtcodigo.Text)
                del.ExecuteNonQuery()
                Cerrar_Conexion()
                MsgBox("Pais Eliminado Exitosamente", MsgBoxStyle.Information, Title:="Sistema Biblioteca")
                txtcodigo.Text = ""
                txtpais.Text = ""
                txtcodigo.Enabled = False
                txtpais.Enabled = False
                btnEliminar.Enabled = False
                btnModificar.Enabled = False
                btnAgregar.Enabled = True
                tblpaises.DataSource = CargarPaises()
                mostrarCantidadPaises()
                mostrarCantidadPaisesseleccionados()

            Catch ex As Exception
                MsgBox("Error", MsgBoxStyle.Critical, Title:="Sistema Biblioteca")
                txtcodigo.Text = ""
                txtpais.Text = ""
                txtcodigo.Enabled = False
                txtpais.Enabled = False
                btnEliminar.Enabled = False
                btnModificar.Enabled = False
                btnAgregar.Enabled = True
                tblpaises.DataSource = CargarPaises()
                mostrarCantidadPaisesseleccionados()
                mostrarCantidadPaises()
                Cerrar_Conexion()
            End Try
        Else
            MsgBox("Ingrese un Codigo para poder eliminar un Idioma", MsgBoxStyle.Information, Title:="Sistema Biblioteca")

        End If
    End Sub

    Private Sub txtapais_KeyPress(sender As Object, e As KeyPressEventArgs)
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

    Private Sub txtmcodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcodigo.KeyPress
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

    Private Sub txtmpais_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtpais.KeyPress
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

    Private Sub guardar()
        Dim cmd As New SqlCommand
        If txtpais.Text <> "" Then

            Try
                Abrir_Conexion()
                cmd = New SqlCommand("NuevoPais", conect)

                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@nombre", txtpais.Text)
                cmd.ExecuteNonQuery()
                Cerrar_Conexion()
                MsgBox("Pais: " & txtpais.Text & " agregado Exitosamente", MsgBoxStyle.Information, Title:="Sistema Biblioteca")

                txtcodigo.Text = ""
                txtpais.Text = ""
                tblpaises.DataSource = CargarPaises()
                mostrarCantidadPaises()
                mostrarCantidadPaisesseleccionados()
                btnAgregar.Text = "Agregar"
                btnModificar.Enabled = False
                btnEliminar.Enabled = False
                txtcodigo.Enabled = False
                txtpais.Enabled = False

            Catch ex As Exception
                MsgBox(ex.ToString & "El Codigo:" & txtpais.Text & " Ya se ha asignado a otro idioma", MsgBoxStyle.Critical, Title:="Sistema Biblioteca")
                mostrarCantidadPaisesseleccionados()
                txtcodigo.Text = ""
                txtpais.Text = ""
                tblpaises.DataSource = CargarPaises()
                mostrarCantidadPaises()
                btnAgregar.Text = "Agregar"
                btnModificar.Enabled = False
                btnEliminar.Enabled = False
                txtcodigo.Enabled = False
                txtpais.Enabled = False

            End Try
        Else
            MsgBox("LLene los campos", MsgBoxStyle.Information, Title:="Sistema Biblioteca")

        End If


    End Sub
    Public Function FiltroIdioma() As DataTable
        Dim sql As String
        sql = "select IdPais as CODIGO,nombre as PAIS from paises where nombre Like '%" + txtbuscar.Text + "%'"
        Dim da As New SqlDataAdapter(sql, conect)
        Dim tbl As New DataTable
        da.Fill(tbl)
        Return tbl
    End Function
    Private Sub txtbuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtbuscar.KeyPress
        tblpaises.DataSource = FiltroIdioma()
    End Sub

    Private Sub txtbuscar_Leave(sender As Object, e As EventArgs) Handles txtbuscar.Leave
        tblpaises.DataSource = CargarPaises()
    End Sub
    Private Sub tblpaises_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles tblpaises.CellContentClick
        txtpais.Enabled = True
        btnModificar.Enabled = True
        btnAgregar.Enabled = False
        btnEliminar.Enabled = True
        txtcodigo.Text = tblpaises.Item(0, e.RowIndex).Value
        txtpais.Text = tblpaises.Item(1, e.RowIndex).Value
        tblinfo.DataSource = infopais()
        mostrarCantidadPaisesseleccionados()
    End Sub


    Public Function infopais() As DataTable
        Dim sql As String
        sql = "Select A.nombre As AUTOR,P.nombre As PAIS FROM Autores A,paises p WHERE A.IdPais=P.IdPais And p.nombre='" + txtpais.Text + "'"
        Dim da As New SqlDataAdapter(sql, conect)
        Dim tbl As New DataTable
        da.Fill(tbl)
        Return tbl

    End Function

    Public Sub mostrarCantidadPaisesseleccionados()
        Try
            Abrir_Conexion()
            Dim sql As String
            Dim rs As SqlDataReader
            Dim com As New SqlCommand
            sql = "SELECT count(*) FROM Autores A,paises p WHERE A.IdPais=P.IdPais and p.nombre='" + txtpais.Text + "'"
            com = New SqlCommand(sql, conect)
            rs = com.ExecuteReader()
            rs.Read()
            Dim Conteo As Integer
            Conteo = rs(0)
            btntotalselect.Text = "Autores del pais seleccionado " & Conteo
            Cerrar_Conexion()
        Catch ex As Exception
            Cerrar_Conexion()
        End Try

    End Sub

    Public Sub mostrarCantidadPaises()
        Try
            Abrir_Conexion()
            Dim sql As String
            Dim rs As SqlDataReader
            Dim com As New SqlCommand
            sql = "Select count(*) from Paises"
            com = New SqlCommand(sql, conect)
            rs = com.ExecuteReader()
            rs.Read()
            Dim Conteo As Integer
            Conteo = rs(0)
            btninf.Text = "Total de Paises Registrados " & Conteo
            Cerrar_Conexion()
        Catch ex As Exception
            Cerrar_Conexion()
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btninf.Click

    End Sub

    Private Sub btntotalselect_Click(sender As Object, e As EventArgs) Handles btntotalselect.Click

    End Sub

    Private Sub txtpais_KeyDown(sender As Object, e As KeyEventArgs) Handles txtpais.KeyDown

    End Sub
End Class