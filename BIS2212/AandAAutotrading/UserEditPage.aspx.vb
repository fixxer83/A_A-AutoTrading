Imports System.Data.SqlClient
Imports System.Data

Partial Class UserEditPage
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        IsAdminLbl.Text = Request.QueryString("IsAdmin")

        If Not Page.IsPostBack Then
            UserGvFill()
        End If

        'GVHeader()
    End Sub

    Protected Sub gvUser_RowCancelingEdit(sender As Object, e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gvUser.RowCancelingEdit
        UserGvFill()
    End Sub

    Protected Sub gvUser_RowEditing(sender As Object, e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvUser.RowEditing
        UserGvFill()
    End Sub


    'Populating GV
    Sub UserGvFill()
        Dim CmdStr As String
        CmdStr = "Select UserID, Name, Surname, Username, Password, IsAdmin From [User]"
        Dim Cmd As New SqlCommand(CmdStr, Conn.OpenConn)
        Dim DR As SqlDataReader
        Dim DT As New DataTable
        Conn.OpenConn()
        DR = Cmd.ExecuteReader
        DT.Load(DR)
        gvUser.DataSource = DT
        gvUser.DataBind()
        Conn.CloseConn()
    End Sub

    'Binding DB Names with GV column headers
    Public Sub GVHeader()
        Dim Conn As New SqlConnection
        Conn.ConnectionString = "Server=Montesin-PC\SQLEXPRESS;Database=BIS2212-CW3;User Id=sa;Password=user123;"
        Dim DA As New SqlDataAdapter
        Dim DS As New DataSet
        Dim DT As New DataTable

        DA = New SqlDataAdapter("Select * From [User]", Conn)
        DA.Fill(DS, "[User]")

        With Me.gvUser
            .DataSource = DS
            .DataMember = "[User]"
            .DataBind()
        End With
        Conn.Close()
    End Sub

    Protected Sub gvUser_RowUpdating(sender As Object, e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gvUser.RowUpdating
        'Getting The gridview row values...
        Dim UserID As Integer = CInt(CType(gvUser.Rows(e.RowIndex).FindControl("txtUserID"), TextBox).Text)
        Dim Name As String = CType(gvUser.Rows(e.RowIndex).FindControl("txtName"), TextBox).Text
        Dim Surname As String = CType(gvUser.Rows(e.RowIndex).FindControl("txtSurname"), TextBox).Text
        Dim UserName As String = CType(gvUser.Rows(e.RowIndex).FindControl("txtUserName"), TextBox).Text
        Dim Password As String = CType(gvUser.Rows(e.RowIndex).FindControl("txtPassword"), TextBox).Text

        If IsAdminLbl.Text = "True" Then
            Dim IsAdmin As String = CType(gvUser.Rows(e.RowIndex).FindControl("txtIsAdmin"), TextBox).Text
            GVUpd(UserID, Name, Surname, UserName, Password, IsAdmin)

        ElseIf IsAdminLbl.Text = "False" Then
            Dim IsAdmin As String = "False"
            GVUpd(UserID, Name, Surname, UserName, Password, IsAdmin)
        End If
        UserGvFill()
    End Sub

    'Update data fields in GV
    Protected Sub GVUpd(UserID As Integer, Name As String, Surname As String, UserName As String, Password As String, IsAdmin As String)
        Dim UserData As New UserData
        Dim Conn As New SqlConnection
        Conn.ConnectionString = "Server=Montesin-PC\SQLEXPRESS;Database=BIS2212-CW3;User Id=sa;Password=user123;"

        Dim UPD As New SqlCommand
        UPD = Conn.CreateCommand
        UPD.CommandType = CommandType.Text
        UPD.CommandText = "Update [User] Set Name = @uName, Surname = @uSurname, UserName = @uUserName, Password = @uPwd, IsAdmin = @uIsAdmin Where UserID = @uID;"
        UPD.Connection = Conn

        Try
            Conn.Open()
            UPD.Parameters.Clear()

            UPD.Parameters.AddWithValue("@uName", Name)
            UPD.Parameters.AddWithValue("@uSurname", Surname)
            UPD.Parameters.AddWithValue("@uUserName", UserName)
            UPD.Parameters.AddWithValue("@uPwd", Password)
            UPD.Parameters.AddWithValue("@uIsAdmin", IsAdmin)
            UPD.Parameters.AddWithValue("@uID", UserID)

            UPD.Connection = Conn
            UPD.ExecuteNonQuery()

        Catch e As SqlException
            e.Message.ToString()
        Finally
            gvUser.EditIndex = -1


            Conn.Close()
            Conn.Dispose()

        End Try

    End Sub

    Protected Sub gvUser_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvUser.SelectedIndexChanged

    End Sub
End Class
