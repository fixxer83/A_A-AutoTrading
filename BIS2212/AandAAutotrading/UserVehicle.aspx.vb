Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.OleDb

Partial Class UserVehicle
    Inherits System.Web.UI.Page

    Protected Sub form1_Load(sender As Object, e As System.EventArgs) Handles form1.Load
        If Not IsPostBack Then
            UserVehicleFill(Request.QueryString("UserID"))
        End If
    End Sub

    'Populating VehicleLV
    Sub UserVehicleFill(UserID As Integer)
        Dim VehicleData As New VehicleData
        Dim DR As SqlDataReader
        Dim DT As New DataTable
        Dim Conn As New SqlConnection
        Conn.ConnectionString = "Server=Montesin-PC\SQLEXPRESS;Database=BIS2212-CW3;User Id=sa;Password=user123;"

        Dim UPD As New SqlCommand
        UPD = Conn.CreateCommand
        UPD.CommandType = CommandType.Text
        UPD.CommandText = "Select * From Vehicle Where UserID = @UserID;"
        UPD.Connection = Conn

        Try
            Conn.Open()
            UPD.Parameters.Clear()

            UPD.Parameters.AddWithValue("@UserID", UserID)

            UPD.Connection = Conn
            UPD.ExecuteNonQuery()

            DR = UPD.ExecuteReader
            DT.Load(DR)
            gvUserVehicle.DataSource = DT
            gvUserVehicle.DataBind()

        Catch e As SqlException
            e.Message.ToString()
        Finally
            Conn.Close()
            Conn.Dispose()

        End Try

       

        'DR = Cmd.ExecuteReader
        'DT.Load(DR)
        'gvUserVehicle.DataSource = DT
        'gvUserVehicle.DataBind()
        'Conn.CloseConn()
    End Sub

    Protected Sub gvUserVehicle_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvUserVehicle.SelectedIndexChanged
        'Selecting a vehicle
        Dim VID As New Label
        Dim i As Integer = gvUserVehicle.SelectedIndex
        VID.Text = CStr(CType(gvUserVehicle.Rows(i).FindControl("lblVID"), Label).Text)
        Dim UID As New Label
        UID.Text = CStr(CType(gvUserVehicle.Rows(i).FindControl("lblUserID"), Label).Text)
        Response.Redirect("SingleVehicleView.aspx?VID=" + Server.UrlEncode(VID.Text) + ",UserID=" + Server.UrlEncode(UID.Text))
    End Sub
End Class
