Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class Conn
    Shared Conn As New SqlConnection
    Public Shared Function OpenConn() As SqlConnection
        If Conn.State = ConnectionState.Closed Then
            Conn.ConnectionString = "Server=Montesin-PC\SQLEXPRESS;Database=BIS2212-CW4;" & _
                "User Id=sa; Password=user123;"
            Conn.Open()
        End If
        Return Conn
    End Function

    Public Shared Sub CloseConn()
        Conn.Close()
    End Sub

End Class
