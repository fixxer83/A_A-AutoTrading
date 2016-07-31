
Partial Class UserLoginPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        txtPWD.TextMode = TextBoxMode.Password
        LogoutHL.Visible = False
        btnVeh.Visible = False
        btnAddVehicle.Visible = False
        btnUser.Visible = False
        lblInitLogin.Visible = False
        lblUserID.Visible = False
        LblIsAdmin.Visible = False
    End Sub

    Protected Sub RegBtn_Click(sender As Object, e As System.EventArgs) Handles BtnReg.Click
        Response.Redirect("Register.aspx")
    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As System.EventArgs) Handles BtnLogin.Click

        Dim UserData As UserData = UserValidation.UserVal(txtUserName.Text, txtPWD.Text)

        If txtUserName.Text = String.Empty Then
            MsgBox("Kindly enter a valid username", MsgBoxStyle.Exclamation)
            Exit Sub
        ElseIf txtPWD.Text = String.Empty Then
            MsgBox("Kindly enter a valid password", MsgBoxStyle.Exclamation)
            Exit Sub

            'Setting login and logout (click) event
            'Login
        ElseIf BtnLogin.Text = "Login" Then

            If UserData Is Nothing Then
                lblInitLogin.Text = "Username & Password are not valid, if you have valid credentials " & _
                    "please re-enter or else register as a new user!"
                lblInitLogin.Visible = False
                LblUserPg.Visible = False
                Exit Sub
            Else
                Session.Add("UserName", UserData)
                lblInitLogin.Text = "Welcome! You are logged in as: " & UserData.uName & " " & UserData.uSurname

                'Binding data with hidden labels 
                lblUserID.Text = UserData.uID

                txtUserName.Visible = False
                lblName.Visible = False
                txtPWD.Visible = False
                lblPassword.Visible = False
                LblIsAdmin.Text = UserData.uIsAdmin
                lblInitLogin.Visible = True
                LblUserPg.Visible = False
                btnVeh.Visible = True
                btnAddVehicle.Visible = True
                btnUser.Visible = True
            End If

            'Only admins have access to all user data
            If UserData.uIsAdmin = True Then
                btnUser.Visible = True
            Else
                btnUser.Visible = False
            End If
            BtnLogin.Text = "Logout"

            'Logout
        ElseIf BtnLogin.Text = "Logout" Then
            Session.Remove("UserName")
            Response.Redirect("UserLoginPage.aspx")
        End If

    End Sub

    Protected Sub btnVeh_Click(sender As Object, e As System.EventArgs) Handles btnVeh.Click
        Response.Redirect("ViewVehicles.aspx?UserID=" + Server.UrlEncode(lblUserID.Text))
    End Sub

    Protected Sub btnUser_Click(sender As Object, e As System.EventArgs) Handles btnUser.Click
        Response.Redirect("UserEditPage.aspx?IsAdmin=" + Server.UrlEncode(LblIsAdmin.Text))
    End Sub

    Protected Sub btnAddVehicle_Click(sender As Object, e As System.EventArgs) Handles btnAddVehicle.Click
        Response.Redirect("AddVehicle.aspx?IsAdmin=" + Server.UrlEncode(lblUserID.Text))
    End Sub

End Class
