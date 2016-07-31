Partial Class ShoppingCart
    Inherits System.Web.UI.Page
    Dim ShoppingCartFunction As New ShoppingCartFunction
    Dim OrderFunction As New OrderFunction
    Dim decPrice As Decimal = 0
    Dim CredentialMatch As String = ""
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
       lblZeroRows.Visible = False
        CredentialMatch = ""
        'Validating the checkout process
        Dim State = Request.QueryString("State")
        If State = String.Empty Then
            Dim UserID As String = System.Web.HttpContext.Current.Session("UserID")
            ShoppingCartFunction.gvShopCartFill(UserID, gvShopCart)
            If gvShopCart.Rows.Count = 0 Then
                btnCheckout.Visible = False
                lblZeroRows.Visible = True
                lblZeroRows.Text = "You have no vehicles in your shopping cart!"
                lblZeroRows.ForeColor = Drawing.Color.Red
            End If
        ElseIf State = "Matched" Then
            CredentialMatch = "Passed"
            Dim UserID As String = System.Web.HttpContext.Current.Session("UserID")
            ShoppingCartFunction.gvShopCartFill(UserID, gvShopCart)
        ElseIf State = "Unmatched" Then
            MsgBox("Please use your correct Login Credentials!")
            HttpContext.Current.Session.RemoveAll()
            Response.Redirect("Login.aspx")
        End If
    End Sub

    Protected Sub gvShopCart_RowDeleting(sender As Object, e As System.Web.UI.WebControls.GridViewDeleteEventArgs)
        Handles gvShopCart.RowDeleting
        Dim V_ID As String = CType(gvShopCart.Rows(e.RowIndex).FindControl("lblV_ID"), Label).Text
        Dim UserID As Integer = System.Web.HttpContext.Current.Session("UserID")
        ShoppingCartFunction.gvShopCartItemDel(V_ID, UserID, gvShopCart)
        ShoppingCartFunction.gvShopCartFill(UserID, gvShopCart)
    End Sub

    Protected Sub gvShopCart_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvShopCart.SelectedIndexChanged
    End Sub

    Protected Sub btnCheckout_Click(sender As Object, e As System.EventArgs) Handles btnCheckout.Click
        Dim UserID As String = System.Web.HttpContext.Current.Session("UserID")
        Dim DateTime As DateTime = Date.Now
        Dim TotalPrice As Label = CType(gvShopCart.FooterRow.FindControl("lblTotalPrice"), Label)
        TotalPrice.Text = Regex.Replace(TotalPrice.Text, "€", "")

        If CredentialMatch = "" Then
            Response.Redirect("Login.Aspx?UserID=" + Server.UrlEncode(UserID))
        ElseIf CredentialMatch = "Passed" Then
            OrderFunction.PlaceOrder(UserID, DateTime, TotalPrice.Text)

            Dim i As Integer = 0
            For Each GridViewRow In gvShopCart.Rows
                Dim V_ID As String = CType(gvShopCart.Rows(i).FindControl("lblV_ID"), Label).Text
                OrderFunction.AddOrderLine(UserID, DateTime, TotalPrice.Text, V_ID, 1)
                OrderFunction.VehicleSoldStatus(V_ID)
                OrderFunction.EmptyCart(UserID)
                i = i + 1
            Next
            OrderFunction.EmptyCart(UserID)
            Response.Redirect("Checkout.Aspx")
        End If

    End Sub


End Class
