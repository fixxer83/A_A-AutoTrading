Option Strict On

Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Data

Public Class UserValidation

    Public Shared Function UserVal(ByVal UserName As String, ByVal Password As String) As UserData
        Try
            Dim CMD As New SqlCommand()

            With CMD
                .Connection = Conn.OpenConn
                .CommandText = "SELECT * FROM [User] WHERE UserName = @UserName AND Password = @Password"
                .Parameters.AddWithValue("@UserName", UserName)
                .Parameters.AddWithValue("@Password", Password)
            End With

            Dim DT As New DataTable()
            DT.Load(CMD.ExecuteReader())

            If DT.Rows.Count > 0 Then
                For Each Row As DataRow In DT.Rows
                    Dim UserData As New UserData()
                    With UserData
                        .UserID = CInt(Row.Item("UserID"))
                        .Name = Row.Item("Name").ToString()
                        .Surname = Row.Item("Surname").ToString()
                        .UserName = Row.Item("UserName").ToString()

                        If (Row.Item("IsAdmin").ToString() = "True") Then
                            .IsAdmin = True
                        ElseIf (Row.Item("IsAdmin").ToString() = "False") Then
                            .IsAdmin = False
                        End If
                        .Password = Row.Item("Password").ToString()
                    End With
                    Return UserData
                Next
            End If
        Catch e As Exception
            MsgBox("An error has occurred " & e.Message.ToString)
        Finally
            Conn.CloseConn()
        End Try
        Return Nothing
    End Function

    Public Shared Function UserNameVal(ByVal UserName As String) As UserData
        Try
            Dim CMD As New SqlCommand()
            With CMD
                .Connection = Conn.OpenConn
                .CommandText = "SELECT * FROM [User] WHERE UserName = @UserName"
                .Parameters.AddWithValue("@UserName", UserName)
            End With

            Dim DT As New DataTable()
            DT.Load(CMD.ExecuteReader())

            If DT.Rows.Count > 0 Then
                For Each Row As DataRow In DT.Rows
                    Dim UserData As New UserData()
                    With UserData
                        .UserID = CInt(Row.Item("UserID"))
                        .Name = Row.Item("Name").ToString()
                        .Surname = Row.Item("Surname").ToString()
                        .UserName = Row.Item("UserName").ToString()
                        If (Row.Item("IsAdmin").ToString() = "True") Then
                            .IsAdmin = True
                        ElseIf (Row.Item("IsAdmin").ToString() = "False") Then
                            .IsAdmin = False
                        End If
                        .Password = Row.Item("Password").ToString()
                    End With
                    Return UserData
                Next
            End If
        Catch e As Exception
            MsgBox("An error has occurred " & e.Message.ToString)
        Finally
            Conn.CloseConn()
        End Try
        Return Nothing
    End Function

    Public Shared Function RegUserVal(ByVal Name As String, ByVal Surname As String, ByVal UserName As String, ByVal Password As String, ByVal IsAdmin As String) As UserData
        Try
            Dim CMD As New SqlCommand()
            With CMD
                .Connection = Conn.OpenConn
                .CommandText = "SELECT * FROM [User] WHERE UserName = @UserName AND Password = @Password;"
                .Parameters.AddWithValue("@UserName", UserName)
                .Parameters.AddWithValue("@Password", Password)
            End With
            Dim DT As New DataTable()
            DT.Load(CMD.ExecuteReader())
            If DT.Rows.Count <= 0 Then
                For Each Row As DataRow In DT.Rows
                    Dim UserData As New UserData()
                    With UserData
                        .UserID = CInt(Row.Item("UserID"))
                        .Name = Row.Item("Name").ToString()
                        .Surname = Row.Item("Surname").ToString()
                        .UserName = Row.Item("UserName").ToString()
                        If (Row.Item("IsAdmin").ToString() = "True") Then
                            .IsAdmin = True
                        ElseIf (Row.Item("IsAdmin").ToString() = "False") Then
                            .IsAdmin = False
                        End If
                        .Password = Row.Item("Password").ToString()
                    End With
                    Return UserData
                    Conn.CloseConn()
                    Conn.OpenConn()
                    CMD.CommandText = "Insert Into [User] (Name, Surname, UserName, Password, IsAdmin) VALUES (@Name, @Surname, @UserName, @Password, @IsAdmin)"
                    CMD.Parameters.AddWithValue("@Name", Name)
                    CMD.Parameters.AddWithValue("@Surname", Surname)
                    CMD.Parameters.AddWithValue("@UserName", UserName)
                    CMD.Parameters.AddWithValue("@Password", Password)
                    CMD.Parameters.AddWithValue("@IsAdmin", IsAdmin)
                    CMD.ExecuteReader()
                Next
            Else
                MsgBox("Username & Password already exist")
                Conn.CloseConn()
                Stop
            End If

        Catch e As Exception
            MsgBox("An error has occurred " & e.Message.ToString)
        Finally
            Conn.CloseConn()
        End Try

        Return Nothing
    End Function

    Public Shared Function UserIDVal(ByVal UserID As Integer) As UserData
        Try
            Dim CMD As New SqlCommand()
            With CMD
                .Connection = Conn.OpenConn
                .CommandText = "SELECT * FROM [User] WHERE UserID = @UserID"
                .Parameters.AddWithValue("@UserID", UserID)
            End With
            Dim DT As New DataTable()
            DT.Load(CMD.ExecuteReader())
            If DT.Rows.Count > 0 Then
                For Each Row As DataRow In DT.Rows
                    Dim UserData As New UserData()
                    With UserData
                        .UserID = CInt(Row.Item("UserID"))
                        .Name = Row.Item("Name").ToString()
                        .Surname = Row.Item("Surname").ToString()
                        .UserName = Row.Item("UserName").ToString()
                        If (Row.Item("IsAdmin").ToString() = "True") Then
                            .IsAdmin = True
                        ElseIf (Row.Item("IsAdmin").ToString() = "False") Then
                            .IsAdmin = False
                        End If
                        .Password = Row.Item("Password").ToString()
                    End With
                    Return UserData
                Next
            End If
        Catch e As Exception
            MsgBox("An error has occurred " & e.Message.ToString)
        Finally
            Conn.CloseConn()
        End Try
        Return Nothing
    End Function
End Class
