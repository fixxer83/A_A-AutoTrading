Imports System.Data.SqlClient
Imports System.Data

Partial Class Register
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        PwdExLbl.Visible = False
        PwdMatchExLbl.Visible = False
    End Sub
    Protected Sub RegBtn_Click(sender As Object, e As System.EventArgs) Handles btnRegister.Click
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
        ElseIf PWDtxt.Text = String.Empty Then
            PWDtxt.BackColor = Drawing.Color.Red
            Exit Sub
        ElseIf PWDtxt.Text <> PWDMatchTxt.Text Then
            PWDtxt.Text = String.Empty
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
            Dim UserDataVal As UserData = UserValidation.UserVal(UserNameTxt.Text.ToUpper, PWDtxt.Text.ToUpper)
            Dim UserNameVal As UserData = UserValidation.UserNameVal(UserNameTxt.Text.ToUpper)

            If Not (UserDataVal Is Nothing) Then
                MsgBox("User already exists", MsgBoxStyle.Critical)
                UserNameTxt.BackColor = Drawing.Color.Red
                PWDtxt.BackColor = Drawing.Color.Red
                PWDMatchTxt.BackColor = Drawing.Color.Red
                Exit Sub
            ElseIf Not (UserNameVal Is Nothing) Then
                MsgBox("User already exists", MsgBoxStyle.Critical)
                UserNameTxt.BackColor = Drawing.Color.Red
                Exit Sub
            Else
                'Calling the RegUser from the Register Function Class to register a new user
                Dim RegisterUser As New UserFunction
                RegisterUser.RegUser(NameTxt.Text, SurnameTxt.Text, UserNameTxt.Text, PWDtxt.Text, "False")
                NameTxt.Text = String.Empty
                SurnameTxt.Text = String.Empty
                UserNameTxt.Text = String.Empty
                PWDtxt.Text = String.Empty
                PWDMatchTxt.Text = String.Empty
                MsgBox("User has been added successfully!", MsgBoxStyle.Information)
                Response.Redirect("Login.aspx")
            End If
        End If
    End Sub
    Protected Sub PWDTxt_TextChanged(sender As Object, e As System.EventArgs) Handles PWDTxt.TextChanged

    End Sub
End Class
