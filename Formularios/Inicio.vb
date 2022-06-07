Imports System.Data.SqlClient

Public Class Inicio
    Private Sub Inicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrarCantidadLibros()
        mostrarCantidadEditoriales()
        Panel1.Visible = False

    End Sub
    Public Sub PanelContenido(ByVal Formulario As Form)
        Panel1.Controls.Clear()
        Formulario.TopLevel = False
        Formulario.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Formulario.Dock = DockStyle.Fill
        Panel1.Controls.Add(Formulario)
        Formulario.Show()

    End Sub
    Public Sub mostrarCantidadLibros()
        Try
            Abrir_Conexion()
            Dim sql As String
            Dim rs As SqlDataReader
            Dim com As New SqlCommand
            sql = "Select count(*) from libros"
            com = New SqlCommand(sql, conect)
            rs = com.ExecuteReader()
            rs.Read()
            Dim Conteo As Integer
            Conteo = rs(0)
            btnLR.Text = "Libros Registrados " & Conteo
            Cerrar_Conexion()
        Catch ex As Exception
            Cerrar_Conexion()
        End Try

    End Sub

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
            btnER.Text = "Editoriales Registrados " & Conteo
            Cerrar_Conexion()
        Catch ex As Exception
            Cerrar_Conexion()
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Panel1.Visible = True
        Call PanelContenido(Libros)
    End Sub

End Class