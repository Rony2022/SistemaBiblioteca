Imports System.Data.SqlClient

Public Class Usuarios
    Private Sub Usuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tblusuarios.DataSource = Cargarusuarios()
        mostrarCantidadUsuarios()
        Cargarrol()

    End Sub

    Public Sub mostrarCantidadUsuarios()
        Try
            Abrir_Conexion()
            Dim sql As String
            Dim rs As SqlDataReader
            Dim com As New SqlCommand
            sql = "Select count(*) from Usuarios"
            com = New SqlCommand(sql, conect)
            rs = com.ExecuteReader()
            rs.Read()
            Dim Conteo As Integer
            Conteo = rs(0)
            btninf.Text = "Usuarios Registrados " & Conteo
            Cerrar_Conexion()
        Catch ex As Exception
            Cerrar_Conexion()
        End Try
    End Sub

    Public Function Cargarusuarios() As DataTable
        Dim da As New SqlDataAdapter("MostrarUsuarios", conect)
        Dim tbl As New DataTable
        da.Fill(tbl)
        Return tbl
    End Function
    Dim contador As Integer = 0
    Private Sub btnagregar_Click(sender As Object, e As EventArgs) Handles btnagregar.Click
        contador = contador + 1
        If contador = 1 Then
            cbxrol.Enabled = True
            txtcodigo.TabIndex = False
            btnagregar.Text = "Guardar"
            txtcodigo.Enabled = False
            txtusuario.Enabled = True
            txtcontraseña.Enabled = True
            btnmodificar.Enabled = False
            btneliminar.Enabled = False

        ElseIf contador = 2 Then
            cbxrol.Enabled = True
            txtcodigo.TabIndex = False
            cbxrol.TabIndex = 1
            txtusuario.TabIndex = 2
            txtcontraseña.TabIndex = 3
            btnagregar.TabIndex = 4
            guardar()
            contador = 0
        End If
    End Sub

    Private Sub guardar()
        Dim cmd As New SqlCommand
        If txtusuario.Text <> "" And txtcontraseña.Text <> "" Then
            Try
                Abrir_Conexion()
                cmd = New SqlCommand("NuevoUsuario", conect)

                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@TipoUsuario", cbxrol.SelectedValue.ToString)
                cmd.Parameters.AddWithValue("@NombreUsuario ", txtusuario.Text)
                cmd.Parameters.AddWithValue("@Contraseña", txtcontraseña.Text)

                cmd.ExecuteNonQuery()
                MsgBox("Editorial: " & txtusuario.Text & " Agregado Exitosamente", MsgBoxStyle.Information, Title:="Sistema Biblioteca")
                Cerrar_Conexion()
                txtcodigo.Text = ""
                cbxrol.Enabled = False
                txtusuario.Text = ""
                txtcontraseña.Text = ""
                btnagregar.Enabled = True
                btneliminar.Enabled = False
                btnmodificar.Enabled = False
                btnagregar.Text = "Agregar"
                tblusuarios.DataSource = Cargarusuarios()
                tblinfo.DataSource = infousuarios()
            Catch ex As Exception
                Cerrar_Conexion()
                MsgBox(ex.ToString & "Error", MsgBoxStyle.Critical, Title:="Sistema Biblioteca")
                txtcodigo.Text = ""
                cbxrol.Enabled = False
                txtusuario.Text = ""
                txtcontraseña.Text = ""
                btnagregar.Enabled = True
                btneliminar.Enabled = False
                btnmodificar.Enabled = False
                btnagregar.Text = "Agregar"
                tblusuarios.DataSource = Cargarusuarios()
                tblinfo.DataSource = infousuarios()
            End Try
        Else
            MsgBox("LLene los campos", MsgBoxStyle.Information, Title:="Sistema Biblioteca")

        End If
    End Sub
    Public Function Cargarrol()
        Dim sql As String = "SELECT TipoUsuario,rol FROM TipoUsuarios"
        Dim da As New SqlDataAdapter(sql, conect)
        Dim dt As New DataTable("Autores")
        da.Fill(dt)
        With Me.cbxrol
            .DataSource = dt
            .DisplayMember = "rol"
            .ValueMember = "TipoUsuario"
        End With
        Return dt
    End Function
    Public Function infousuarios() As DataTable
        Dim sql As String
        sql = "SELECT  u.IdUsuario as CODIGO,t.Rol AS ROL,u.NombreUsuario AS USUARIO
FROM  TipoUsuarios t INNER JOIN
Usuarios u ON t.TipoUsuario = u.TipoUsuario AND t.Rol='" + cbxrol.SelectedValue.ToString + "'"
        Dim da As New SqlDataAdapter(sql, conect)
        Dim tbl As New DataTable
        da.Fill(tbl)
        Return tbl
    End Function
    Private Sub tblusuarios_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblusuarios.CellContentClick

        cbxrol.Enabled = True
        txtusuario.Enabled = True
        txtcontraseña.Enabled = True
        btnmodificar.Enabled = True
        btnagregar.Enabled = False
        btneliminar.Enabled = True

        txtcodigo.Text = tblusuarios.Item(0, e.RowIndex).Value
        With Me.cbxrol
            .DisplayMember = "rol"
            .ValueMember = "rol"
        End With
        cbxrol.SelectedValue = tblusuarios.Item(1, e.RowIndex).Value
        txtusuario.Text = tblusuarios.Item(2, e.RowIndex).Value
        txtcontraseña.Text = tblusuarios.Item(3, e.RowIndex).Value
        tblinfo.DataSource = infousuarios()
    End Sub

    Private Sub btnmodificar_Click(sender As Object, e As EventArgs) Handles btnmodificar.Click
        Dim cmd As New SqlCommand
        If txtcodigo.Text <> "" And txtusuario.Text <> "" And txtcontraseña.Text <> "" Then
            Try
                Abrir_Conexion()
                cmd = New SqlCommand("ModificarUsuario", conect)

                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@IdUsuario", txtcodigo.Text)
                With Me.cbxrol
                    .DisplayMember = "rol"
                    .ValueMember = "TipoUsuario"
                End With
                cmd.Parameters.AddWithValue("@TipoUsuario", cbxrol.SelectedValue.ToString)

                cmd.Parameters.AddWithValue("@NombreUsuario ", txtusuario.Text)
                cmd.Parameters.AddWithValue("@Contraseña", txtcontraseña.Text)

                cmd.ExecuteNonQuery()
                MsgBox("Editorial: " & txtusuario.Text & " Modificado Exitosamente", MsgBoxStyle.Information, Title:="Sistema Biblioteca")
                Cerrar_Conexion()
                txtcodigo.Text = ""
                cbxrol.Enabled = False
                txtusuario.Text = ""
                txtcontraseña.Text = ""
                btnagregar.Enabled = True
                btneliminar.Enabled = False
                btnmodificar.Enabled = False
                tblusuarios.DataSource = Cargarusuarios()
                tblinfo.DataSource = infousuarios()
            Catch ex As Exception
                Cerrar_Conexion()
                MsgBox(ex.ToString & "Error", MsgBoxStyle.Critical, Title:="Sistema Biblioteca")
                txtcodigo.Text = ""
                cbxrol.Enabled = False
                txtusuario.Text = ""
                txtcontraseña.Text = ""
                btnagregar.Enabled = True
                btneliminar.Enabled = False
                btnmodificar.Enabled = False
                tblusuarios.DataSource = Cargarusuarios()
                tblinfo.DataSource = infousuarios()
            End Try
        Else
            MsgBox("LLene los campos", MsgBoxStyle.Information, Title:="Sistema Biblioteca")

        End If
    End Sub

    Private Sub btneliminar_Click(sender As Object, e As EventArgs) Handles btneliminar.Click
        Dim del As New SqlCommand
        If txtcodigo.Text <> "" Then

            Try
                Abrir_Conexion()
                del = New SqlCommand("EliminarUsuario", conect)

                del.CommandType = CommandType.StoredProcedure
                del.Parameters.AddWithValue("@IdUsuario", txtcodigo.Text)
                del.ExecuteNonQuery()
                Cerrar_Conexion()
                MsgBox("Editorial Eliminado Exitosamente", MsgBoxStyle.Information, Title:="Sistema Biblioteca")
                txtcodigo.Text = ""
                cbxrol.Enabled = False
                txtusuario.Text = ""
                txtcontraseña.Text = ""
                btnagregar.Enabled = True
                btneliminar.Enabled = False
                btnmodificar.Enabled = False
                tblusuarios.DataSource = Cargarusuarios()
                tblinfo.DataSource = infousuarios()
            Catch ex As Exception
                Cerrar_Conexion()
                MsgBox("No existe Ningun Editorial con ese Codigo", MsgBoxStyle.Critical, Title:="Sistema Biblioteca")
                txtcodigo.Text = ""
                cbxrol.Enabled = False
                txtusuario.Text = ""
                txtcontraseña.Text = ""
                btnagregar.Enabled = True
                btneliminar.Enabled = False
                btnmodificar.Enabled = False
                tblusuarios.DataSource = Cargarusuarios()
                tblinfo.DataSource = infousuarios()
            End Try
        Else
            MsgBox("Ingrese un  Codigo para poder eliminar un Editorial", MsgBoxStyle.Information, Title:="Sistema Biblioteca")

        End If
    End Sub

    Private Sub txtusuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtusuario.KeyPress

    End Sub
End Class