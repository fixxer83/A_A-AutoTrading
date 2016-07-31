
Partial Class CarSearch
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        LblNoSearch.Visible = False
        Dim SearchStr As String = Request.QueryString("SearchStr")
        Dim VehicleFunction As New VehicleFunction
        If SearchStr = String.Empty Then
            LblNoSearch.Text = "Enter Make / Model first then click GO. Please try again!"
            LblNoSearch.Visible = True
        ElseIf Not SearchStr = String.Empty Then
            VehicleFunction.SearchQuery(SearchStr, gvVehicle)
            If gvVehicle.Rows.Count = 0 Then
                LblNoSearch.Text = "Your search returned no Vehicles. Make / Model may not be available at the moment. Please try searching in a couple of days!"
                LblNoSearch.Visible = True
            ElseIf gvVehicle.Rows.Count > 0 Then
                LblNoSearch.Text = "Your search returned the following Vehicle/s"
                LblNoSearch.Visible = True
            End If
            VehicleFunction.SearchQuery(SearchStr, gvVehicle)
        Else
        End If
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
