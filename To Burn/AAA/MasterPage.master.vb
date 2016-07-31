Imports System.Data.SqlClient
Imports System.Data
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Private Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Dim msName As String = CStr(System.Web.HttpContext.Current.Session("UserName"))


        If msName = String.Empty Then
            Exit Sub
        Else
            lbtnUserLogged.Text = System.Web.HttpContext.Current.Session("UserName")
            btnLogout.Visible = True
            lblLogin.Visible = False
        End If

    End Sub

    Public Sub btnLogout_Click(sender As Object, e As System.EventArgs) Handles btnLogout.Click

        'Logout
        System.Web.HttpContext.Current.Session.Remove("UserID")
        System.Web.HttpContext.Current.Session.Remove("UserName")
        System.Web.HttpContext.Current.Session.Abandon()
        System.Web.HttpContext.Current.Session.Clear()

        lbtnUserLogged.Text = "?"

        Response.Redirect("Login.aspx")

    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As System.EventArgs) Handles btnSearch.Click

        Response.Redirect("CarSearch.aspx?SearchStr=" + Server.UrlEncode(txtbSearch.Text))

    End Sub

    Protected Sub lbtnUserLogged_Click(sender As Object, e As System.EventArgs) Handles lbtnUserLogged.Click
        Dim UserData As New UserData

        If lbtnUserLogged.Text = "?" Then
            Response.Redirect("Login.aspx")
        ElseIf System.Web.HttpContext.Current.Session("IsAdmin") = True Then
            Response.Redirect("AdminPanel.aspx")
        ElseIf Not lbtnUserLogged.Text = "?" Then
            Response.Redirect("UserPanel.aspx")
        End If
    End Sub

    Protected Sub IbtnCart_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles IbtnCart.Click
        If lbtnUserLogged.Text = "?" Then
            Response.Redirect("Login.aspx")
        Else
            Response.Redirect("ShoppingCart.aspx")
        End If
    End Sub

End Class

