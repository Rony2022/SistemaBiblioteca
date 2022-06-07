Imports System.Data.SqlClient

Public Class editorial
    Public Function CargarPaises()
        Dim sql As String = "SELECT IdPais,nombre FROM paises"
        Dim da As New SqlDataAdapter(sql, conect)
        Dim dt As New DataTable("Paises")
        da.Fill(dt)
        With Me.cbxpais
            .DataSource = dt
            .DisplayMember = "nombre"
            .ValueMember = "nombre"
        End With
        Return dt
    End Function
    Public Function FiltroEditoriales() As DataTable
        Dim sql As String
        sql = "select IdEditorial as CODIGO,nombre as 'NOMBRE EDITORIAL',direccion AS DIRECCION,pais as PAIS,email AS 'E-MAIL',telefono AS TELEFONO from Editoriales WHERE nombre Like '%" + txtbuscar.Text + "%'"
        Dim da As New SqlDataAdapter(sql, conect)
        Dim tbl As New DataTable
        da.Fill(tbl)
        Return tbl
    End Function


    Public Sub mostrarCantidadEditoriales()
        Try
            Abrir_Conexion()
            Dim sql As String
            Dim rs As SqlDataReader
            Dim com As New SqlCommand
            sql = "Select count(*) from Editoriales"
            com = New SqlCommand(sql, conect)
            rs = com.ExecuteReader()
            rs.Read()
            Dim Conteo As Integer
            Conteo = rs(0)
            btninf.Text = "Total de Editoriales Registrados " & Conteo
            Cerrar_Conexion()
        Catch ex As Exception
            Cerrar_Conexion()
        End Try

    End Sub
    Public Sub mostrarCantidadEditorialesseleccionados()
        Try
            Abrir_Conexion()
            Dim sql As String
            Dim rs As SqlDataReader
            Dim com As New SqlCommand
            sql = "SELECT count(*) FROM libros l,editoriales e WHERE l.IdEditorial=e.IdEditorial And e.nombre='" + txteditorial.Text + "'"
            com = New SqlCommand(sql, conect)
            rs = com.ExecuteReader()
            rs.Read()
            Dim Conteo As Integer
            Conteo = rs(0)
            btntotalselect.Text = "Libros del Editorial seleccionado " & Conteo
            Cerrar_Conexion()
        Catch ex As Exception
            Cerrar_Conexion()
        End Try

    End Sub


    Public Function infoeditorial() As DataTable
        Dim sql As String
        sql = "Select l.Titulo As LIBRO,e.nombre As EDITORIAL FROM libros l,Editoriales e 
WHERE l.IdEditorial=E.IdEditorial And e.nombre='" + txteditorial.Text + "'"
        Dim da As New SqlDataAdapter(sql, conect)
        Dim tbl As New DataTable
        da.Fill(tbl)
        Return tbl
    End Function
    Private Sub editorial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarPaises()
        cbxpais.Enabled = False
        txtcodigo.Enabled = False
        txteditorial.Enabled = False
        txtdireccion.Enabled = False
        txtemail.Enabled = False
        txttelefono.Enabled = False
        tbleditorial.DataSource = CargarEditorial()
        btnmodificar.Enabled = False
        btnEliminar.Enabled = False
        mostrarCantidadEditoriales()
        mostrarCantidadEditorialesseleccionados()

    End Sub

    Dim contador As Integer = 0
    Private Sub btnagregar_Click(sender As Object, e As EventArgs) Handles btnagregar.Click
        contador = contador + 1
        If contador = 1 Then
            cbxpais.Enabled = True
            txtcodigo.TabIndex = False
            btnagregar.Text = "Guardar"
            txtcodigo.Enabled = False
            txteditorial.Enabled = True
            txtdireccion.Enabled = True
            txtemail.Enabled = True
            txttelefono.Enabled = True
            btnmodificar.Enabled = False
            btnEliminar.Enabled = False

        ElseIf contador = 2 Then
            cbxpais.Enabled = True
            txtcodigo.TabIndex = False
            txteditorial.TabIndex = 0
            cbxpais.TabIndex = 1
            txtdireccion.TabIndex = 2
            txtemail.TabIndex = 3
            txttelefono.TabIndex = 4
            btnagregar.TabIndex = 5
            guardar()
            contador = 0
        End If
    End Sub

    Public Function CargarEditorial() As DataTable
        Dim da As New SqlDataAdapter("MostrarEditoriales", conect)
        Dim tbl As New DataTable
        da.Fill(tbl)
        Return tbl
    End Function

    Private Sub btnmodificar_Click(sender As Object, e As EventArgs) Handles btnmodificar.Click
        Dim cmd As New SqlCommand
        If txteditorial.Text <> "" And txtdireccion.Text <> "" And txtemail.Text <> "" And txttelefono.Text <> "" Then
            Try
                Abrir_Conexion()
                cmd = New SqlCommand("ActualizarEditorial", conect)

                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@IdEditorial", txtcodigo.Text)
                cmd.Parameters.AddWithValue("@nombre", txteditorial.Text)
                cmd.Parameters.AddWithValue("@direccion", txtdireccion.Text)
                cmd.Parameters.AddWithValue("@pais", cbxpais.SelectedValue.ToString)
                cmd.Parameters.AddWithValue("@email", txtemail.Text)
                cmd.Parameters.AddWithValue("@telefono", txttelefono.Text)
                cmd.ExecuteNonQuery()
                Cerrar_Conexion()
                MsgBox("Editorial: " & txteditorial.Text & " Actualizado Exitosamente", MsgBoxStyle.Information, Title:="Sistema Biblioteca")
                txtcodigo.Text = ""
                cbxpais.Enabled = False
                txteditorial.Text = ""
                txtdireccion.Text = ""
                txtemail.Text = ""
                txttelefono.Text = ""
                cbxpais.Enabled = False
                txtcodigo.Enabled = False
                txteditorial.Enabled = False
                txtdireccion.Enabled = False
                txtemail.Enabled = False
                txttelefono.Enabled = False
                btnagregar.Enabled = True
                btnEliminar.Enabled = False
                btnmodificar.Enabled = False
                tbleditorial.DataSource = CargarEditorial()
            Catch ex As Exception
                Cerrar_Conexion()
                MsgBox(ex.ToString & "Error", MsgBoxStyle.Critical, Title:="Sistema Biblioteca")
                txtcodigo.Text = ""
                cbxpais.Enabled = False
                txteditorial.Text = ""
                txtdireccion.Text = ""
                txtemail.Text = ""
                txttelefono.Text = ""
                cbxpais.Enabled = False
                txtcodigo.Enabled = False
                txteditorial.Enabled = False
                txtdireccion.Enabled = False
                txtemail.Enabled = False
                txttelefono.Enabled = False
                btnagregar.Enabled = True
                btnEliminar.Enabled = False
                btnmodificar.Enabled = False
                tbleditorial.DataSource = CargarEditorial()
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
                del = New SqlCommand("EliminarEditorial", conect)

                del.CommandType = CommandType.StoredProcedure
                del.Parameters.AddWithValue("@IdEditorial", txtcodigo.Text)
                del.ExecuteNonQuery()
                Cerrar_Conexion()

                MsgBox("Editorial Eliminado Exitosamente", MsgBoxStyle.Information, Title:="Sistema Biblioteca")
                txtcodigo.Text = ""
                txteditorial.Text = ""
                txtdireccion.Text = ""
                txtemail.Text = ""
                txttelefono.Text = ""
                cbxpais.Enabled = False
                txtcodigo.Enabled = False
                txteditorial.Enabled = False
                txtdireccion.Enabled = False
                txtemail.Enabled = False
                txttelefono.Enabled = False
                btnagregar.Enabled = True
                btnEliminar.Enabled = False
                btnmodificar.Enabled = False
                tbleditorial.DataSource = CargarEditorial()
            Catch ex As Exception
                Cerrar_Conexion()
                MsgBox("No existe Ningun Editorial con ese Codigo", MsgBoxStyle.Critical, Title:="Sistema Biblioteca")
                txtcodigo.Text = ""
                txteditorial.Text = ""
                txtdireccion.Text = ""
                txtemail.Text = ""
                txttelefono.Text = ""
                cbxpais.Enabled = False
                txtcodigo.Enabled = False
                txteditorial.Enabled = False
                txtdireccion.Enabled = False
                txtemail.Enabled = False
                txttelefono.Enabled = False
                btnagregar.Enabled = True
                btnEliminar.Enabled = False
                btnmodificar.Enabled = False
                tbleditorial.DataSource = CargarEditorial()
            End Try
        Else
            MsgBox("Ingrese un  Codigo para poder eliminar un Editorial", MsgBoxStyle.Information, Title:="Sistema Biblioteca")

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

    Private Sub txtmdireccion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtdireccion.KeyPress
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

    Private Sub txtmemail_Leave(sender As Object, e As EventArgs) Handles txtemail.Leave
        If InStr(txtemail.Text, "@") <= 0 And InStr(txtemail.Text, ".") <= 0 Then
            MsgBox("Correo Invalido", MsgBoxStyle.Critical, Title:="Sistema Biblioteca")
            txtemail.Text = ""
        End If
    End Sub

    Private Sub txtmeditorial_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txteditorial.KeyPress
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



    Private Sub txtadireccion_KeyPress(sender As Object, e As KeyPressEventArgs)
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

    Private Sub txtaemail_Leave(sender As Object, e As EventArgs)
        If InStr(txtemail.Text, "@") <= 0 And InStr(txtemail.Text, ".") <= 0 Then
            MsgBox("Correo Invalido", MsgBoxStyle.Critical, Title:="Sistema Biblioteca")
            txtemail.Text = ""
        End If
    End Sub

    Private Sub txtaeditorial_KeyPress(sender As Object, e As KeyPressEventArgs)
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
        If txteditorial.Text <> "" And txtdireccion.Text <> "" And txtemail.Text <> "" And txttelefono.Text <> "" Then
            Try
                Abrir_Conexion()
                cmd = New SqlCommand("NuevoEditorial", conect)
                'parametros
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@nombre", txteditorial.Text)
                cmd.Parameters.AddWithValue("@direccion", txtdireccion.Text)
                cmd.Parameters.AddWithValue("@pais", cbxpais.SelectedValue)
                cmd.Parameters.AddWithValue("@email", txtemail.Text)
                cmd.Parameters.AddWithValue("@telefono", txttelefono.Text)
                cmd.ExecuteNonQuery()
                Cerrar_Conexion()

                MsgBox("Editorial: " & txteditorial.Text & " agregado Exitosamente", MsgBoxStyle.Information, Title:="Sistema Biblioteca")
                Cerrar_Conexion()
                txtcodigo.Text = ""
                txteditorial.Text = ""
                cbxpais.Enabled = False
                txtdireccion.Text = ""
                txtemail.Text = ""
                txttelefono.Text = ""
                btnagregar.Text = "Agregar"
                btnmodificar.Enabled = False
                btnEliminar.Enabled = False
                txtcodigo.Enabled = False
                txteditorial.Enabled = False
                txtdireccion.Enabled = False
                txtemail.Enabled = False
                txttelefono.Enabled = False
                tbleditorial.DataSource = CargarEditorial()
                Inicio.mostrarCantidadEditoriales()


            Catch ex As Exception
                MsgBox(ex.ToString & "Error al registrar", MsgBoxStyle.Critical, Title:="Sistema Biblioteca")
                txteditorial.Text = ""
                txtdireccion.Text = ""
                txtemail.Text = ""
                txttelefono.Text = ""
                tbleditorial.DataSource = CargarEditorial()
                Inicio.mostrarCantidadEditoriales()
            End Try
        Else
            MsgBox("LLene los campos", MsgBoxStyle.Information, Title:="Sistema Biblioteca")

        End If
    End Sub

    Private Sub tbleditorial_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles tbleditorial.CellContentClick
        txtcodigo.Enabled = False
        txteditorial.Enabled = True
        cbxpais.Enabled = True
        txtdireccion.Enabled = True
        txtemail.Enabled = True
        txttelefono.Enabled = True
        btnmodificar.Enabled = True
        btnagregar.Enabled = False
        btnEliminar.Enabled = True
        txtcodigo.Text = tbleditorial.Item(0, e.RowIndex).Value
        txteditorial.Text = tbleditorial.Item(1, e.RowIndex).Value
        txtdireccion.Text = tbleditorial.Item(2, e.RowIndex).Value
        cbxpais.SelectedValue = tbleditorial.Item(3, e.RowIndex).Value
        txtemail.Text = tbleditorial.Item(4, e.RowIndex).Value
        txttelefono.Text = tbleditorial.Item(5, e.RowIndex).Value
        mostrarCantidadEditorialesseleccionados()
        tblinfo.DataSource = infoeditorial()
    End Sub

    Private Sub txtbuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtbuscar.KeyPress
        tbleditorial.DataSource = FiltroEditoriales()
    End Sub

End Class