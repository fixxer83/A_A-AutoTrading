Option Strict On

Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Data

Public Class UserValidation

    Public Shared Function UserVal(ByVal uUserName As String, ByVal uPwd As String) As UserData
        Try
            Dim CMD As New SqlCommand()

            With CMD
                .Connection = Conn.OpenConn
                .CommandText = "SELECT * FROM [User] WHERE UserName = @uUserName AND Password = @uPwd"
                .Parameters.AddWithValue("@uUserName", uUserName)
                .Parameters.AddWithValue("@uPwd", uPwd)
            End With

            Dim DT As New DataTable()
            DT.Load(CMD.ExecuteReader())

            If DT.Rows.Count > 0 Then

                For Each Row As DataRow In DT.Rows

                    Dim UserData As New UserData()

                    With UserData
                        .uID = CInt(Row.Item("UserID"))
                        .uName = Row.Item("Name").ToString()
                        .uSurname = Row.Item("Surname").ToString()
                        .uUserName = Row.Item("UserName").ToString()

                        If (Row.Item("IsAdmin").ToString() = "True") Then
                            .uIsAdmin = True
                        ElseIf (Row.Item("IsAdmin").ToString() = "False") Then
                            .uIsAdmin = False
                        End If
                        .uPwd = Row.Item("Password").ToString()

                    End With

                    Return UserData

                Next

            End If

        Catch Ex As Exception

        Finally
            Conn.CloseConn()
        End Try

        Return Nothing
    End Function

    Public Shared Function UserNameVal(ByVal uUserName As String) As UserData
        Try
            Dim CMD As New SqlCommand()

            With CMD
                .Connection = Conn.OpenConn
                .CommandText = "SELECT * FROM [User] WHERE UserName = @uUserName"
                .Parameters.AddWithValue("@uUserName", uUserName)
            End With

            Dim DT As New DataTable()
            DT.Load(CMD.ExecuteReader())

            If DT.Rows.Count > 0 Then

                For Each Row As DataRow In DT.Rows

                    Dim UserData As New UserData()

                    With UserData
                        .uID = CInt(Row.Item("UserID"))
                        .uName = Row.Item("Name").ToString()
                        .uSurname = Row.Item("Surname").ToString()
                        .uUserName = Row.Item("UserName").ToString()

                        If (Row.Item("IsAdmin").ToString() = "True") Then
                            .uIsAdmin = True
                        ElseIf (Row.Item("IsAdmin").ToString() = "False") Then
                            .uIsAdmin = False
                        End If
                        .uPwd = Row.Item("Password").ToString()

                    End With

                    Return UserData

                Next

            End If

        Catch Ex As Exception

        Finally
            Conn.CloseConn()
        End Try

        Return Nothing
    End Function

    Public Shared Function RegUserVal(ByVal uName As String, ByVal uSurname As String, ByVal uUserName As String, ByVal uPwd As String, ByVal uIsAdmin As String) As UserData

        Try
            Dim CMD As New SqlCommand()

            With CMD
                .Connection = Conn.OpenConn
                .CommandText = "SELECT * FROM [User] WHERE UserName = @uUserName AND Password = @uPwd;"
                .Parameters.AddWithValue("@uUserName", uUserName)
                .Parameters.AddWithValue("@uPwd", uPwd)
            End With

            Dim DT As New DataTable()
            DT.Load(CMD.ExecuteReader())

            If DT.Rows.Count <= 0 Then

                For Each Row As DataRow In DT.Rows

                    Dim UserData As New UserData()

                    With UserData
                        .uID = CInt(Row.Item("UserID"))
                        .uName = Row.Item("Name").ToString()
                        .uSurname = Row.Item("Surname").ToString()
                        .uUserName = Row.Item("UserName").ToString()

                        If (Row.Item("IsAdmin").ToString() = "True") Then
                            .uIsAdmin = True
                        ElseIf (Row.Item("IsAdmin").ToString() = "False") Then
                            .uIsAdmin = False
                        End If
                        .uPwd = Row.Item("Password").ToString()

                    End With

                    Return UserData

                    Conn.CloseConn()
                    Conn.OpenConn()
                    CMD.CommandText = "Insert Into [User] (Name, Surname, UserName, Pasword, IsAdmin) VALUES (@uName, @uSurname, @uUserName, @uPwd, @uIsAdmin)"
                    CMD.Parameters.AddWithValue("@uName", uUserName)
                    CMD.Parameters.AddWithValue("@uSurname", uSurname)
                    CMD.Parameters.AddWithValue("@uUserName", uUserName)
                    CMD.Parameters.AddWithValue("@uPwd", uPwd)
                    CMD.Parameters.AddWithValue("@uIsAdmin", uIsAdmin)

                    CMD.ExecuteReader()

                Next
            Else
                MsgBox("Username & Password already exist")
                Conn.CloseConn()
                Stop
            End If

        Catch Ex As Exception

        Finally
            Conn.CloseConn()
        End Try

        Return Nothing
    End Function

End Class
