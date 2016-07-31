Imports System.Data.SqlClient
Imports System.Data

Partial Class SingleVehicleView
    Inherits System.Web.UI.Page

    Protected Sub form1_Load(sender As Object, e As System.EventArgs) Handles form1.Load
        VDescTxt.ReadOnly = True
        gvVehicle.Visible = False

        'Requesting VID query string
        Dim VID As String = Request.QueryString("VID")

        'Splitting VID into VehicleID and User ID (Below)
        Dim IDStr() As String = VID.Split(",")
        Dim VIDStr As String = IDStr(0)


        If IDStr.Length <> 2 Then
            VIDStr = VIDStr.Replace("?VID=", "")
            lblVID.Text = VIDStr
        Else
            VIDStr = VIDStr.Replace("?VID=", "")
            lblVID.Text = VIDStr
            Dim UserIDStr As String = IDStr(1)
            UserIDStr = UserIDStr.Replace("UserID=", "")
            lblUserID.Text = UserIDStr
        End If
        'Populating the gvVehicle
        VehicleView(lblVID.Text)
        
        Dim UserID As String = CType(gvVehicle.Rows(0).FindControl("lblUserID"), Label).Text
        Dim UserID2 As String = lblUserID.Text '.Replace(",UserID=", "")

        MsgBox("Control: " & UserID & ", Label: " & UserID2)

        If String.Equals(UserID, UserID2) = False Then
            btnVehDel.Visible = False
        Else
            btnVehDel.Visible = True
        End If

    End Sub
    Sub VehicleView(V_ID As String)
        Dim VehicleData As New VehicleData
        Dim Conn As New SqlConnection
        Conn.ConnectionString = "Server=Montesin-PC\SQLEXPRESS;Database=BIS2212-CW3;User Id=sa;Password=user123;"

        Dim UPD As New SqlCommand
        UPD = Conn.CreateCommand
        UPD.CommandType = CommandType.Text
        UPD.CommandText = "Select * From Vehicle Where V_ID = @V_ID;"
        UPD.Connection = Conn

        Try
            Conn.Open()
            UPD.Parameters.Clear()
            UPD.Parameters.AddWithValue("@V_ID", V_ID)
            UPD.Connection = Conn
            UPD.ExecuteNonQuery()

            Dim DR As SqlDataReader
            Dim DT As New DataTable

            DR = UPD.ExecuteReader
            DT.Load(DR)
            gvVehicle.DataSource = DT
            gvVehicle.DataBind()
        Catch e As SqlException
            e.Message.ToString()
        Finally

            Conn.Close()
            Conn.Dispose()
        End Try

        Dim vMakeStr As String = CType(gvVehicle.Rows(0).FindControl("lblMake"), Label).Text
        Dim vModelStr As String = CType(gvVehicle.Rows(0).FindControl("lblModel"), Label).Text
        Dim VID As String = CType(gvVehicle.Rows(0).FindControl("lblVID"), Label).Text
        VName.Text = vMakeStr & " " & vModelStr & " - " & VID
        VName.Text.ToUpper()

        'Getting values from query to the respective text boxes
        VTrans.Text = "Transmission Type: " & CType(gvVehicle.Rows(0).FindControl("lblTrans"), Label).Text
        VEngine.Text = "Engine CC: " & CType(gvVehicle.Rows(0).FindControl("lblEngine"), Label).Text
        VFuel.Text = "Fuel Type: " & CType(gvVehicle.Rows(0).FindControl("lblFuel"), Label).Text
        VColor.Text = "Color: " & (CType(gvVehicle.Rows(0).FindControl("lblColor"), Label).Text)
        VCond.Text = "Condition: " & CType(gvVehicle.Rows(0).FindControl("lblCond"), Label).Text
        VDescTxt.Text = "Additional Information: " & CType(gvVehicle.Rows(0).FindControl("lblDesc"), Label).Text
        VPrice.Text = "Price: €" & CInt(CType(gvVehicle.Rows(0).FindControl("lblPrice"), Label).Text)

        If Not IsPostBack Then
            Dim MainImg As String = CType(gvVehicle.Rows(0).FindControl("lblMainImage"), Label).Text
            Dim AltImg As String = CType(gvVehicle.Rows(0).FindControl("lblAltImg"), Label).Text
            AltImgBinding(MainImg, AltImg)

        End If
    End Sub

    Sub AltImgBinding(MainImg As String, AltImg As String)
        LargeVImg.ImageUrl = "~/Images/" & MainImg
        LargeVImg.Height = 550
        LargeVImg.Width = 700

        btnImg1.ImageUrl = "~/Images/" & MainImg
        btnImg1.Height = 80
        btnImg1.Width = 110

        'Read comma delimited Alternate Images
        Dim AltImgs As String = AltImg
        Dim i As Integer = 0
        For Each AltImgStr As String In AltImgs.Split(","c)

            i = i + 1
            Select Case i <= 5
                Case i = 1
                    btnImg2.ImageUrl = "~/Images/" & AltImgStr
                    btnImg2.Height = 80
                    btnImg2.Width = 110
                    MsgBox(btnImg2.ImageUrl)
                Case i = 2
                    btnImg3.ImageUrl = "~/Images/" & AltImgStr
                    btnImg3.Height = 80
                    btnImg3.Width = 110
                Case i = 3
                    btnImg4.ImageUrl = "~/Images/" & AltImgStr
                    btnImg4.Height = 80
                    btnImg4.Width = 110
                Case i = 4
                    btnImg5.ImageUrl = "~/Images/" & AltImgStr
                    btnImg5.Height = 80
                    btnImg5.Width = 110

                Case i = 5
                    btnImg6.ImageUrl = "~/Images/" & AltImgStr
                    btnImg6.Height = 80
                    btnImg6.Width = 110
            End Select
        Next
    End Sub

    Sub VehicleDel(V_ID As String, UserID As String)
        Dim VehicleData As New VehicleData
        Dim Conn As New SqlConnection
        Conn.ConnectionString = "Server=Montesin-PC\SQLEXPRESS;Database=BIS2212-CW3;User Id=sa;Password=user123;"

        Dim UPD As New SqlCommand
        UPD = Conn.CreateCommand
        UPD.CommandType = CommandType.Text
        UPD.CommandText = "DELETE FROM Vehicle WHERE V_ID=@V_ID AND UserID=@UserID"
        UPD.Connection = Conn

        Try
            Conn.Open()
            UPD.Parameters.Clear()
            UPD.Parameters.AddWithValue("@V_ID", V_ID)
            UPD.Parameters.AddWithValue("@UserID", UserID)
            UPD.Connection = Conn
            'UPD.ExecuteNonQuery()

            'From Here
            Dim updSuccess As Integer = UPD.ExecuteNonQuery()
            Dim imageToDel As String
            If updSuccess > 0 Then
                'Find a solution to delete all images
                If Not btnImg1.ImageUrl = String.Empty Then
                    MsgBox(btnImg1.ImageUrl)
                    imageToDel = Server.MapPath(btnImg1.ImageUrl)
                    System.IO.File.Delete(imageToDel)
                    If Not btnImg2.ImageUrl = String.Empty Then
                        imageToDel = Server.MapPath(btnImg2.ImageUrl)
                        System.IO.File.Delete(imageToDel)
                    ElseIf Not btnImg3.ImageUrl = String.Empty Then
                        imageToDel = Server.MapPath(btnImg3.ImageUrl)
                        System.IO.File.Delete(imageToDel)
                    ElseIf Not btnImg4.ImageUrl = String.Empty Then
                        imageToDel = Server.MapPath(btnImg4.ImageUrl)
                        System.IO.File.Delete(imageToDel)
                    ElseIf Not btnImg5.ImageUrl = String.Empty Then
                        imageToDel = Server.MapPath(btnImg5.ImageUrl)
                        System.IO.File.Delete(imageToDel)
                    ElseIf Not btnImg6.ImageUrl = String.Empty Then
                        imageToDel = Server.MapPath(btnImg6.ImageUrl)
                        System.IO.File.Delete(imageToDel)
                        MsgBox("Vehicle was deleted succesfully!", MsgBoxStyle.Exclamation)
                    End If
                End If

            Else
                MsgBox("Vehicle was not deleted!", MsgBoxStyle.Exclamation)
                Exit Sub
            End If





            Dim DR As SqlDataReader
            Dim DT As New DataTable

            DR = UPD.ExecuteReader
            DT.Load(DR)
            gvVehicle.DataSource = DT
            gvVehicle.DataBind()

        Catch e As SqlException
            MsgBox("An error has occurred: " & e.Message.ToString())
        Finally

            Conn.Close()
            Conn.Dispose()

        End Try
    End Sub


    Protected Sub btnImg1_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles btnImg1.Click
        LargeVImg.ImageUrl = btnImg1.ImageUrl
    End Sub

    Protected Sub btnImg2_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles btnImg2.Click
        LargeVImg.ImageUrl = btnImg2.ImageUrl
    End Sub

    Protected Sub btnImg3_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles btnImg3.Click
        LargeVImg.ImageUrl = btnImg3.ImageUrl
    End Sub

    Protected Sub btnImg4_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles btnImg4.Click
        LargeVImg.ImageUrl = btnImg4.ImageUrl
    End Sub

    Protected Sub btnImg5_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles btnImg5.Click
        LargeVImg.ImageUrl = btnImg5.ImageUrl
    End Sub

    Protected Sub btnImg6_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles btnImg6.Click
        LargeVImg.ImageUrl = btnImg6.ImageUrl
    End Sub
    Protected Sub btnVehDel_Click(sender As Object, e As System.EventArgs) Handles btnVehDel.Click

        Dim delQuestion = MsgBox("Are you sure you want to delete this vehicle?", MsgBoxStyle.YesNo)
        If delQuestion = 6 Then
            VehicleDel(lblVID.Text, lblUserID.Text)
            Return

        ElseIf delQuestion = 7 Then
            Return
        End If

    End Sub
End Class
