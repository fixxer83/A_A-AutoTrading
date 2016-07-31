
Partial Class Checkout
    Inherits System.Web.UI.Page

    Protected Sub lbViewOrders_Click(sender As Object, e As System.EventArgs) Handles lbViewOrders.Click
        Response.Redirect("UserPanel.aspx")
    End Sub
End Class
