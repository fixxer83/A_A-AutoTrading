Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class CategoryFunction
    Public Sub gvCategoryFill(GvName As GridView)
        Dim CMD As New SqlCommand()
        Dim DR As SqlDataReader
        Dim DT As New DataTable
        Try
            With CMD
                .Connection = Conn.OpenConn
                .CommandText = "Select * From Category;"
                .ExecuteNonQuery()
                DR = CMD.ExecuteReader
                DT.Load(DR)
                GvName.DataSource = DT
                GvName.DataBind()
            End With

        Catch e As SqlException
            MsgBox("An error has occurred " & e.Message.ToString())
        Finally
            Conn.CloseConn()
        End Try
    End Sub

    'Update data fields in GV
    Public Sub GVUpd(CatID As Integer, Description As String, DateCreated As Date, gvCategory As GridView)
        Dim CategoryData As New CategoryData
        Try
            Dim CMD As New SqlCommand()
            With CMD
                .Connection = Conn.OpenConn
                .CommandText = "Update Category Set Description=@Description, DateCreated=@DateCreated Where CatID=@CatID;"
                .Parameters.Clear()
                .Parameters.AddWithValue("@CatID", CatID)
                .Parameters.AddWithValue("@Description", Description)
                .Parameters.AddWithValue("@DateCreated", DateCreated)
                .ExecuteNonQuery()
            End With
            gvCategory.EditIndex = -1
            'gvCategoryFill()
        Catch e As SqlException
            MsgBox("An error has occurred " & e.Message.ToString())
        Finally
            Conn.CloseConn()
        End Try
    End Sub

    'Adding a category
    Public Sub AddNewCat(Description As String, DateCreated As Date, gvCategory As GridView)
        Try
            Dim CMD As New SqlCommand()

            With CMD
                .Connection = Conn.OpenConn
                .CommandText = "Insert Into Category (Description, DateCreated) Values (@Description, @DateCreated)"
                .Parameters.Clear()
                .Parameters.AddWithValue("@Description", Description)
                .Parameters.AddWithValue("@DateCreated", DateCreated)
            End With

            Dim DR As SqlDataReader
            Dim DT As New DataTable

            DR = CMD.ExecuteReader
            DT.Load(DR)
            gvCategory.DataSource = DT
            gvCategory.DataBind()

        Catch e As SqlException
            MsgBox("An error has occurred " & e.Message.ToString())
        Finally
            Conn.CloseConn()
        End Try
    End Sub

    'Delete selected category
    Public Sub CategoryDel(CatID As Integer, gvCategory As GridView)
        Try
            Dim CMD As New SqlCommand()
            With CMD
                .Connection = Conn.OpenConn
                .CommandText = "Delete FROM Category WHERE CatID=@CatID;"
                .Parameters.Clear()
                .Parameters.AddWithValue("@CatID", CatID)
                .ExecuteNonQuery()
            End With

            Dim DR As SqlDataReader
            Dim DT As New DataTable
            DR = CMD.ExecuteReader
            DT.Load(DR)
            gvCategory.DataSource = DT
            gvCategory.DataBind()

        Catch e As SqlException
            MsgBox("An error has occurred " & e.Message.ToString())
        Finally
            Conn.CloseConn()
        End Try
    End Sub

End Class
