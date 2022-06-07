Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Module ConexionMaestra
    Public conect As New SqlConnection("Data Source=DESKTOP-878072S\SQLEXPRESS;Initial Catalog=Biblioteca;Integrated Security=True")
    Sub Abrir_Conexion()
        If conect.State = 0 Then
            conect.Open()
        End If

    End Sub

    Sub Cerrar_Conexion()
        If conect.State = 1 Then
            conect.Close()
        End If

    End Sub
End Module
