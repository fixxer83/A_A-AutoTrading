Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.OleDb

Partial Class ViewVehicles
    Inherits System.Web.UI.Page
    
    Protected Sub form1_Load(sender As Object, e As System.EventArgs) Handles form1.Load
       
        lblUserID.Text = Request.QueryString("UserID")
        Response.Write(lblUserID.Text)

        Dim UserIDStr As String = Request.QueryString("UserID")

        If Not IsPostBack Then
            VehicleFill()
        End If
    End Sub

    'Populating VehicleLV
    Sub VehicleFill()
        Dim CmdStr As String
        CmdStr = "Select * From Vehicle;"
        Dim Cmd As New SqlCommand(CmdStr, Conn.OpenConn)
        Dim DR As SqlDataReader
        Dim DT As New DataTable
        Conn.OpenConn()
        DR = Cmd.ExecuteReader
        DT.Load(DR)
        gvVehicle.DataSource = DT
        gvVehicle.DataBind()
        Conn.CloseConn()
    End Sub
    Protected Sub gvVehicle_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvVehicle.SelectedIndexChanged
        'Selecting a vehicle
        Dim VID As New Label
        Dim i As Integer = gvVehicle.SelectedIndex
        VID.Text = CStr(CType(gvVehicle.Rows(i).FindControl("lblVID"), Label).Text)
        Response.Redirect("SingleVehicleView.aspx?VID=" + Server.UrlEncode(VID.Text) + ",UserID=" + Server.UrlEncode(lblUserID.Text))
    End Sub

    Protected Sub BackBtn_Click(sender As Object, e As System.EventArgs) Handles BtnBack.Click
        Response.Redirect("UserLoginPage.aspx?Login=" + Server.UrlEncode(lblUserID.Text))
    End Sub

    Protected Sub btnAddVeh_Click(sender As Object, e As System.EventArgs) Handles btnAddVeh.Click
        Response.Redirect("AddVehicle.aspx?UserID=" + Server.UrlEncode(lblUserID.Text))
    End Sub

    Protected Sub btnViewUserVehicles_Click(sender As Object, e As System.EventArgs) Handles btnViewUserVehicles.Click
        Response.Redirect("UserVehicle.aspx?UserID=" + Server.UrlEncode(lblUserID.Text))
    End Sub
End Class
