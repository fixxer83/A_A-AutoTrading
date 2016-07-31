
Partial Class UserPanel
    Inherits System.Web.UI.Page
    Dim OrderFunction As New OrderFunction
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        gvOrderLine.Visible = False
        'Populating the gvOrder gridView with the data from the Order table
        'For the current user
        Dim UserID As Integer = HttpContext.Current.Session("UserID")
        OrderFunction.gvOrderFill(UserID, gvOrder)
        If gvOrder.Rows.Count = 0 Then
            lblPastOrders.Visible = False
        Else
            lblPastOrders.Visible = True
        End If
    End Sub
    'Selecting an order
    Protected Sub gvOrder_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvOrder.SelectedIndexChanged
        Dim i As Integer = gvOrder.SelectedIndex
        Dim OrderID As String = CStr(CType(gvOrder.Rows(i).FindControl("lblOrderID"), Label).Text)
        OrderFunction.gvOrderLineFill(OrderID, gvOrderLine)
        gvOrderLine.Visible = True
    End Sub
    'Adding a vehicle
    Protected Sub btnAddVeh_Click(sender As Object, e As System.EventArgs) Handles btnAddVeh.Click
        Response.Redirect("AddVehicle.Aspx?IsAdmin=" + Server.UrlEncode(System.Web.HttpContext.Current.Session("UserID")))
    End Sub
End Class
