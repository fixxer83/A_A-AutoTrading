Imports System.Data.SqlClient
Imports System.Data

Partial Class Register
    Inherits System.Web.UI.Page

    Protected Sub form1_Load(sender As Object, e As System.EventArgs) Handles form1.Load
        PwdExLbl.Visible = False
        PwdMatchExLbl.Visible = False
        IsAdminChk.Checked = False
        IsAdminChk.Enabled = False
    End Sub
    Protected Sub RegBtn_Click(sender As Object, e As System.EventArgs) Handles RegBtn.Click
        'Validation on all textboxes
        If NameTxt.Text = String.Empty Then
            NameTxt.BackColor = Drawing.Color.Red
            Exit Sub
        ElseIf SurnameTxt.Text = String.Empty Then
            SurnameTxt.BackColor = Drawing.Color.Red
            Exit Sub
        ElseIf UserNameTxt.Text = String.Empty Then
            UserNameTxt.BackColor = Drawing.Color.Red
            Exit Sub
        ElseIf PWDTxt.Text = String.Empty Then
            PWDTxt.BackColor = Drawing.Color.Red
            Exit Sub
        ElseIf PWDTxt.Text <> PWDMatchTxt.Text Then
            PWDTxt.Text = String.Empty
            PWDMatchTxt.Text = String.Empty
            PwdExLbl.Text = "Passwords do not match!"
            PwdExLbl.ForeColor = Drawing.Color.Red

            PwdMatchExLbl.Text = "Passwords do not match!"
            PwdMatchExLbl.ForeColor = Drawing.Color.Red
            PwdExLbl.Visible = True
            PwdMatchExLbl.Visible = True
            Exit Sub
        Else
            'Checking whether the username & password entered already exist in User DB
            Dim UserDataVal As UserData = UserValidation.UserVal(UserNameTxt.Text.ToUpper, PWDTxt.Text.ToUpper)
            Dim UserNameVal As UserData = UserValidation.UserNameVal(UserNameTxt.Text.ToUpper)

            If Not (UserDataVal Is Nothing) Then
                MsgBox("User already exists", MsgBoxStyle.Critical)
                UserNameTxt.BackColor = Drawing.Color.Red
                PWDTxt.BackColor = Drawing.Color.Red
                PWDMatchTxt.BackColor = Drawing.Color.Red
                Exit Sub

            ElseIf Not (UserNameVal Is Nothing) Then
                MsgBox("User already exists", MsgBoxStyle.Critical)
                UserNameTxt.BackColor = Drawing.Color.Red
                Exit Sub

            Else
                RegUser(NameTxt.Text, SurnameTxt.Text, UserNameTxt.Text, PWDTxt.Text, "False")
                NameTxt.Text = String.Empty
                SurnameTxt.Text = String.Empty
                UserNameTxt.Text = String.Empty
                PWDTxt.Text = String.Empty
                PWDMatchTxt.Text = String.Empty
                MsgBox("User has been added successfully!", MsgBoxStyle.Information)
                Response.Redirect("UserLoginPage.aspx")

            End If
        End If

    End Sub
    'Method for Registering a New User!
    Protected Sub RegUser(Name As String, Surname As String, UserName As String, Password As String, IsAdmin As String)
        Dim UserData As New UserData
        Dim Conn As New SqlConnection
        Conn.ConnectionString = "Server=Montesin-PC\SQLEXPRESS;Database=BIS2212-CW3;User Id=sa;Password=user123;"

        Dim Cmd As New SqlCommand
        Cmd = Conn.CreateCommand
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = "INSERT INTO [User] (Name, Surname, UserName, Password, IsAdmin) VALUES" & _
           "(@uName, @uSurname, @uUserName, @uPwd, @uIsAdmin)"
        Cmd.Connection = Conn

        Try
            Conn.Open()
            Cmd.Parameters.Clear()
            Cmd.Parameters.AddWithValue("@uName", Name)
            Cmd.Parameters.AddWithValue("@uSurname", Surname)
            Cmd.Parameters.AddWithValue("@uUserName", UserName)
            Cmd.Parameters.AddWithValue("@uPwd", Password)
            Cmd.Parameters.AddWithValue("@uIsAdmin", IsAdmin)
            Cmd.ExecuteNonQuery()

        Catch e As SqlException
            MsgBox(e.Message.ToString(), vbMsgBoxSetForeground)
        Finally

            Conn.Close()
            Conn.Dispose()

        End Try

    End Sub
End Class
