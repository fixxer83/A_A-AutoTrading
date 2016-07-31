Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class UserFunction
    'Populating gvUser with the data fetched from the User table
    Public Sub UserGvFill(gvUser As GridView)
        Dim CMD As New SqlCommand()
        Dim DR As SqlDataReader
        Dim DT As New DataTable
        Try
            With CMD
                .Connection = Conn.OpenConn
                .CommandText = "Select UserID, Name, Surname, Username, Password, IsAdmin From [User]"
            End With
            DR = CMD.ExecuteReader
            DT.Load(DR)
            gvUser.DataSource = DT
            gvUser.DataBind()
        Catch e As SqlException
            MsgBox("An error has occurred " & e.Message.ToString())
        Finally
            Conn.CloseConn()
        End Try
    End Sub

    'Update data fields in GV
    Public Sub GVUpd(UserID As Integer, Name As String, Surname As String, UserName As String, Password As String, IsAdmin As String, gvUser As GridView)
        Dim UserData As New UserData
        Try
            Dim CMD As New SqlCommand()
            With CMD
                .Connection = Conn.OpenConn
                .CommandText = "Update [User] Set Name = @uName, Surname = @uSurname, UserName = @uUserName, Password = @uPwd, IsAdmin = @uIsAdmin Where UserID = @uID;"
                .Parameters.Clear()
                .Parameters.AddWithValue("@uName", Name)
                .Parameters.AddWithValue("@uSurname", Surname)
                .Parameters.AddWithValue("@uUserName", UserName)
                .Parameters.AddWithValue("@uPwd", Password)
                .Parameters.AddWithValue("@uIsAdmin", IsAdmin)
                .Parameters.AddWithValue("@uID", UserID)
                .ExecuteNonQuery()
            End With
            gvUser.EditIndex = -1
        Catch e As SqlException
            MsgBox("An error has occurred " & e.Message.ToString())
        Finally
            Conn.CloseConn()
        End Try
    End Sub

    'Method for Registering a New User!
    Public Sub RegUser(Name As String, Surname As String, UserName As String, Password As String, IsAdmin As String)
        Try
            Dim CMD As New SqlCommand()
            With CMD
                .Connection = Conn.OpenConn
                .CommandText = "INSERT INTO [User] (Name, Surname, UserName, Password, IsAdmin) VALUES" & _
               "(@uName, @uSurname, @uUserName, @uPwd, @uIsAdmin)"
                .Parameters.Clear()
                .Parameters.AddWithValue("@uName", Name)
                .Parameters.AddWithValue("@uSurname", Surname)
                .Parameters.AddWithValue("@uUserName", UserName)
                .Parameters.AddWithValue("@uPwd", Password)
                .Parameters.AddWithValue("@uIsAdmin", IsAdmin)
                .ExecuteNonQuery()
            End With
        Catch e As SqlException
            MsgBox("An error has occurred " & e.Message.ToString())
        Finally
            Conn.CloseConn()
        End Try
    End Sub

End Class
