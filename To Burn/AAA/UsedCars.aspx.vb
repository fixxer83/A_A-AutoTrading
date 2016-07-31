
Partial Class UsedCars
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim VehicleFunction As New VehicleFunction

        VehicleFunction.SearchQuery("Second Hand", gvVehicle)
    End Sub

    Protected Sub gvVehicle_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvVehicle.SelectedIndexChanged
        'Selecting a vehicle
        Dim VID As New Label
        Dim i As Integer = gvVehicle.SelectedIndex
        VID.Text = CStr(CType(gvVehicle.Rows(i).FindControl("lblVID"), Label).Text)
        Response.Redirect("CarsSingleView.aspx?VID=" + Server.UrlEncode(VID.Text) & _
                          ",UserID=" + Server.UrlEncode(System.Web.HttpContext.Current.Session("UserID")))
    End Sub
End Class
