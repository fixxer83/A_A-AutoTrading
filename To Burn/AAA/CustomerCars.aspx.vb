
Partial Class CustomerCars
    Inherits System.Web.UI.Page

    'Global Instances
    Dim VehicleFunction As New VehicleFunction
    Dim VehicleData As New VehicleData
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim UserID As String = HttpContext.Current.Session("UserID")
        'If the user is not logged in, then he will be redirected to the login page
        If UserID = "" Then
            lblNotLogged.Visible = True
            lblNotLogged.Text = "Please login to be able to access your cars!"
            Exit Sub
        Else
            VehicleFunction.UserVehicles(UserID, gvVehicle)
            'If the user didn't add any vehicles then he will  be advised accordingly
            If gvVehicle.Rows.Count = 0 Then
                lblNotLogged.Visible = True
                lblNotLogged.Text = "You currently have no cars added in our database!"
            End If
        End If
    End Sub

    Protected Sub gvVehicle_RowDeleting(sender As Object, e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvVehicle.RowDeleting
        Dim delQuestion = MsgBox("Are you sure you want to delete this Vehicle?", MsgBoxStyle.YesNo)
        Dim V_ID As String = CType(gvVehicle.Rows(e.RowIndex).FindControl("lblVID"), Label).Text
        Dim Sold As String = CType(gvVehicle.Rows(e.RowIndex).FindControl("lblSold"), Label).Text
        'If delQuestion = 6 (Yes), then we will check whether the vehicle is sold or not
        'If sold then the user may not delete the vehicle, otherwise the vehicle will be deleted successfully
        If delQuestion = 6 Then
            If Sold = True Then
                Exit Sub
            Else
                VehicleFunction.VehicleDel(V_ID, gvVehicle)
                VehicleFunction.VehicleFillAdmin(gvVehicle)
            End If
        Else
            Return
        End If
    End Sub

    Protected Sub gvVehicle_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvVehicle.SelectedIndexChanged
        'Selecting a vehicle
        Dim VID As New Label
        Dim i As Integer = gvVehicle.SelectedIndex
        VID.Text = CStr(CType(gvVehicle.Rows(i).FindControl("lblVID"), Label).Text)
        Response.Redirect("CarsSingleView.aspx?VID=" + Server.UrlEncode(VID.Text) & _
                          ",UserID=" + Server.UrlEncode(HttpContext.Current.Session("UserID")))
    End Sub

End Class
