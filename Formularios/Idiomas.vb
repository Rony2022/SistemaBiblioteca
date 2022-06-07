Imports System.Data.SqlClient
Public Class Idiomas


    Dim contador As Integer = 0
    Private Sub btnagregar_Click(sender As Object, e As EventArgs) Handles btnagregar.Click
        contador = contador + 1
        If contador = 1 Then
            btnagregar.Text = "Guardar"
            txtcodigo.Enabled = False
            txtidioma.Enabled = True
            btnmodificar.Enabled = False
            btneliminar.Enabled = False

        ElseIf contador = 2 Then
            txtidioma.TabIndex = 1
            btnagregar.TabIndex = 2
            guardar()
            contador = 0
        End If

    End Sub
    Public Sub mostrarCantidaIdiomas()
        Try
            Abrir_Conexion()
            Dim sql As String
            Dim rs As SqlDataReader
            Dim com As New SqlCommand
            sql = "Select count(*) from Idiomas"
            com = New SqlCommand(sql, conect)
            rs = com.ExecuteReader()
            rs.Read()
            Dim Conteo As Integer
            Conteo = rs(0)
            btninf.Text = "Total de Idiomas Registrados " & Conteo
            Cerrar_Conexion()
        Catch ex As Exception
            Cerrar_Conexion()
        End Try

    End Sub

    Public Sub mostrarCantidadIdiomasseleccionados()
        Try
            Abrir_Conexion()
            Dim sql As String
            Dim rs As SqlDataReader
            Dim com As New SqlCommand
            sql = "SELECT count(*) FROM Libros L,Idiomas I WHERE L.IdIdiomas=I.IdIdiomas and I.nombre='" + txtidioma.Text + "'"
            com = New SqlCommand(sql, conect)
            rs = com.ExecuteReader()
            rs.Read()
            Dim Conteo As Integer
            Conteo = rs(0)
            btntotalselect.Text = "Libros con el del Idioma seleccionado " & Conteo
            Cerrar_Conexion()
        Catch ex As Exception
            Cerrar_Conexion()
        End Try

    End Sub

    Private Sub Idiomas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtcodigo.Enabled = False
        txtidioma.Enabled = False
        mostrarCantidaIdiomas()
        tblidiomas.DataSource = CargarIdioma()
        mostrarCantidadIdiomasseleccionados()
        btnmodificar.Enabled = False
        btneliminar.Enabled = False
    End Sub

    Public Function CargarIdioma() As DataTable
        Dim da As New SqlDataAdapter("MostrarIdiomas", conect)
        Dim tbl As New DataTable
        da.Fill(tbl)
        Return tbl
    End Function

    Public Function FiltroIdioma() As DataTable
        Dim sql As String
        sql = "select IdIdiomas as CODIGO,nombre as IDIOMA from Idiomas where nombre Like '%" + txtbuscar.Text + "%'"
        Dim da As New SqlDataAdapter(sql, conect)
        Dim tbl As New DataTable
        da.Fill(tbl)
        Return tbl
    End Function

    Private Sub btnmodificar_Click(sender As Object, e As EventArgs) Handles btnmodificar.Click
        Dim act As New SqlCommand
        If txtcodigo.Text <> "" And txtidioma.Text <> "" Then

            Try
                Abrir_Conexion()
                act = New SqlCommand("ActualizarIdioma", conect)

                act.CommandType = CommandType.StoredProcedure
                act.Parameters.AddWithValue("@IdIdiomas", txtcodigo.Text)
                act.Parameters.AddWithValue("@nombre", txtidioma.Text)
                act.ExecuteNonQuery()
                Cerrar_Conexion()
                MsgBox("Idioma: " & txtidioma.Text & " Modificado Exitosamente", MsgBoxStyle.Information, Title:="Sistema Biblioteca")
                txtcodigo.Text = ""
                txtidioma.Text = ""
                txtcodigo.Enabled = False
                txtidioma.Enabled = False
                btnagregar.Enabled = True
                btneliminar.Enabled = False
                btnmodificar.Enabled = False
                tblidiomas.DataSource = CargarIdioma()

            Catch ex As Exception
                MsgBox("Error", ex.ToString)
                Cerrar_Conexion()
                txtcodigo.Text = ""
                txtidioma.Text = ""
                txtcodigo.Enabled = False
                txtidioma.Enabled = False
                btnagregar.Enabled = True
                btneliminar.Enabled = False
                btnmodificar.Enabled = False
                tblidiomas.DataSource = CargarIdioma()
            End Try
        Else
            MsgBox("LLene los campos", MsgBoxStyle.Information, Title:="Sistema Biblioteca")

        End If
    End Sub

    Private Sub btneliminar_Click(sender As Object, e As EventArgs) Handles btneliminar.Click
        Dim del As New SqlCommand

        Try
                Abrir_Conexion()
                del = New SqlCommand("EliminarIdioma", conect)

                del.CommandType = CommandType.StoredProcedure
                del.Parameters.AddWithValue("@IdIdiomas", txtcodigo.Text)
                del.ExecuteNonQuery()
                Cerrar_Conexion()
                MsgBox("Idioma Eliminado Exitosamente", MsgBoxStyle.Information, Title:="Sistema Biblioteca")
                txtcodigo.Text = ""
            txtidioma.Text = ""
            txtcodigo.Enabled = False
            txtidioma.Enabled = False
            btneliminar.Enabled = False
                btnmodificar.Enabled = False
                btnagregar.Enabled = True
            tblidiomas.DataSource = CargarIdioma()
            mostrarCantidaIdiomas()
        Catch ex As Exception
                MsgBox("No existe Ningun Idioma con ese ID_IDIOMA", MsgBoxStyle.Critical, Title:="Sistema Biblioteca")
                txtcodigo.Text = ""
            txtidioma.Text = ""
            txtcodigo.Enabled = False
            txtidioma.Enabled = False
            btneliminar.Enabled = False
                btnmodificar.Enabled = False
                btnagregar.Enabled = True
            tblidiomas.DataSource = CargarIdioma()
            mostrarCantidaIdiomas()
            Cerrar_Conexion()
        End Try

    End Sub

    Private Sub guardar()
        Dim cmd As New SqlCommand
        If txtidioma.Text <> "" Then
            Try
                Abrir_Conexion()
                cmd = New SqlCommand("NuevoIdioma", conect)

                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@nombre", txtidioma.Text)
                cmd.ExecuteNonQuery()
                Cerrar_Conexion()
                MsgBox("Idioma: " & txtidioma.Text & " agregado Exitosamente", MsgBoxStyle.Information, Title:="Sistema Biblioteca")
                txtcodigo.Text = ""
                txtidioma.Text = ""
                tblidiomas.DataSource = CargarIdioma()
                mostrarCantidaIdiomas()
                btnagregar.Text = "Agregar"
                btnmodificar.Enabled = False
                btneliminar.Enabled = False
                txtcodigo.Enabled = False
                txtidioma.Enabled = False


            Catch ex As Exception
                MsgBox(ex.ToString & "Error", MsgBoxStyle.Critical, Title:="Sistema Biblioteca")
                Cerrar_Conexion()
                txtcodigo.Text = ""
                txtidioma.Text = ""
                mostrarCantidaIdiomas()
                tblidiomas.DataSource = CargarIdioma()
                btnagregar.Text = "Agregar"
                btnmodificar.Enabled = False
                btneliminar.Enabled = False
                txtcodigo.Enabled = False
                txtidioma.Enabled = False
            End Try
        Else
            MsgBox("LLene los campos", MsgBoxStyle.Information, Title:="Sistema Biblioteca")
        End If
    End Sub

    Private Sub txtaidioma_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtidioma.KeyPress

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

    Private Sub txtmidioma_KeyPress(sender As Object, e As KeyPressEventArgs)
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

    Public Function infoidioma() As DataTable
        Dim sql As String
        sql = "Select L.Titulo As Libro,I.nombre As Idioma FROM Libros L,Idiomas I WHERE L.IdIdiomas=I.IdIdiomas And I.nombre='" + txtidioma.Text + "'"
        Dim da As New SqlDataAdapter(sql, conect)
        Dim tbl As New DataTable
        da.Fill(tbl)
        Return tbl

    End Function
    Private Sub tblidiomas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblidiomas.CellContentClick
        txtcodigo.Enabled = False
        txtidioma.Enabled = True
        btnmodificar.Enabled = True
        btnagregar.Enabled = False
        btneliminar.Enabled = True
        txtcodigo.Text = tblidiomas.Item(0, e.RowIndex).Value
        txtidioma.Text = tblidiomas.Item(1, e.RowIndex).Value
        mostrarCantidadIdiomasseleccionados()
        tblinfo.DataSource = infoIdioma()
    End Sub

    Private Sub txtbuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtbuscar.KeyPress
        tblidiomas.DataSource = FiltroIdioma()
    End Sub

    Private Sub txtbuscar_Leave(sender As Object, e As EventArgs) Handles txtbuscar.Leave
        tblidiomas.DataSource = CargarIdioma()
    End Sub
End Class