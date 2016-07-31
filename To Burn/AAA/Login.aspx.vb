Imports System.Data.SqlClient
Imports System.Data

Public Class Login
    Inherits System.Web.UI.Page
    Dim ShoppingCartFunction As New ShoppingCartFunction
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtPWD.TextMode = TextBoxMode.Password
        lblUserID.Visible = False
        LblIsAdmin.Visible = False
        lblUserNameVal.Visible = False
        lblPwdVal.Visible = False
        lblCredentialsVal.Visible = False

    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim UserDataLogin As New UserData
        'Removing all previous sessions (if any), in order to force the program to start a new session
        HttpContext.Current.Session.RemoveAll()
        Session.RemoveAll()
        Dim UserID As String = Request.QueryString("UserID")
        Dim State As String

        If UserID = String.Empty Then
            UserValFields()
            If HttpContext.Current.Session("UserID") <= 0 Then
                Exit Sub
            Else
                UserValFields()
                If lblIsAdmin.Text = True Then
                    Response.Redirect("AdminPanel.aspx")
                ElseIf lblIsAdmin.Text = False Then
                    Response.Redirect("UserPanel.aspx")
                End If
            End If
        ElseIf Not UserID = String.Empty Then
            UserValFields()
            If UserID = HttpContext.Current.Session("UserID") Then
                State = "Matched"
                Response.Redirect("ShoppingCart.aspx?State=" + Server.UrlEncode(State))
            ElseIf Not UserID = System.Web.HttpContext.Current.Session("UserID") Then
                State = "Unmatched"
                Response.Redirect("ShoppingCart.aspx?State=" + Server.UrlEncode(State))
            End If
        End If

    End Sub

    Public Sub UserValFields()
        lblUserNameVal.Visible = False
        lblPwdVal.Visible = False
        If BtnLogin.Text = "Login" Then
            Dim UserData As UserData = UserValidation.UserVal(txtUserName.Text, txtPWD.Text)
            'Validaton on UserName
            If txtUserName.Text = String.Empty Then
                lblUserNameVal.Visible = True
                lblUserNameVal.Text = "Kindly enter a valid username!"
                lblUserNameVal.ForeColor = Drawing.Color.Red
                Exit Sub
                'Validaton on Password
            ElseIf txtPWD.Text = String.Empty Then
                lblPwdVal.Visible = True
                lblPwdVal.Text = "Kindly enter a valid password!"
                lblPwdVal.ForeColor = Drawing.Color.Red
                Exit Sub

            ElseIf UserData Is Nothing Then
                lblCredentialsVal.Text = "Username and / or Password may not be valid!"
                lblCredentialsVal.ForeColor = Drawing.Color.Red
                lblCredentialsVal.Visible = True
                Exit Sub
            Else
                'Removing session on login, in order to start a new one below!
                System.Web.HttpContext.Current.Session.RemoveAll()
                'Adding New Sessions
                System.Web.HttpContext.Current.Session.Add("UserID", UserData.UserID)
                System.Web.HttpContext.Current.Session.Add("UserName", UserData.UserName)
                System.Web.HttpContext.Current.Session.Add("IsAdmin", UserData.IsAdmin)

                'Binding data with hidden labels 
                lblUserID.Text = UserData.UserID
                txtUserName.Visible = False
                txtPWD.Visible = False
                LblIsAdmin.Text = UserData.IsAdmin
            End If

        End If
    End Sub
End Class