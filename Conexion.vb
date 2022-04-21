Imports System.Data.SqlClient

Module Conexion

    Public conexion As SqlConnection
    Public enunciado As SqlCommand
    Public respuesta As SqlDataReader

    Sub abrir()
        Try
            conexion = New SqlConnection("Data Source=DESKTOP-878072S\SQLEXPRESS;Initial Catalog=Biblioteca;Integrated Security=True")
            conexion.Open()
            'MsgBox("Conectado", MsgBoxStyle.Information, Title:="Sistema Biblioteca")
        Catch ex As Exception
            MsgBox("No se pudo conectar" + ex.ToString)
        End Try
    End Sub

    Function usuarioRegistrado(ByVal nombreUsuario As String) As Boolean
        Dim resultado As Boolean = False
        Try
            enunciado = New SqlCommand("Select * from Usuarios where NombreUsuario='" & nombreUsuario & "'", conexion)
            respuesta = enunciado.ExecuteReader

            If respuesta.Read Then
                resultado = True
            End If
            respuesta.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return resultado
    End Function

    Function contraseñaadmin(ByVal nombreUsuario As String) As String
        Dim resultado As String = ""
        Try
            enunciado = New SqlCommand("Select Contraseña,TipoUsuario from Usuarios where NombreUsuario='" & nombreUsuario & "' and TipoUsuario=1", conexion)
            respuesta = enunciado.ExecuteReader

            If respuesta.Read Then
                resultado = respuesta.Item("Contraseña")
            End If
            respuesta.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return resultado
    End Function

    Function contraseñaestudiante(ByVal nombreUsuario As String) As String
        Dim resultado As String = ""
        Try
            enunciado = New SqlCommand("Select Contraseña,TipoUsuario from Usuarios where NombreUsuario='" & nombreUsuario & "' and TipoUsuario=2", conexion)
            respuesta = enunciado.ExecuteReader

            If respuesta.Read Then
                resultado = respuesta.Item("Contraseña")
            End If
            respuesta.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return resultado
    End Function


    Function recuperarcontraseña(ByVal nombreUsuario As String, ByVal id As Integer) As String
        Dim resultado As String = ""
        Try
            enunciado = New SqlCommand("Select Contraseña from Usuarios where NombreUsuario='" & nombreUsuario & "' and IdUsuario'" & id, conexion)
            respuesta = enunciado.ExecuteReader

            If respuesta.Read Then
                resultado = respuesta.Item("Contraseña")
            End If
            respuesta.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return resultado
    End Function




End Module

