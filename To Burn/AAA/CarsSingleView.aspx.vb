Imports System.Data.SqlClient
Imports System.Data

Public Class CarsSingleView
    Inherits System.Web.UI.Page
    Dim ShoppingCartFunction As New ShoppingCartFunction
    Dim VehicleFunction As New VehicleFunction
    'Dim UserData As New UserData
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        VDescTxt.ReadOnly = True
        gvVehicle.Visible = False

        Dim UserID As String
        Dim UserID2 As String
        'Requesting VID query string to load the previously selected vehicle
        Dim VID As String = Request.QueryString("VID")

        'If User is logged in then, the user may add to cart the selected vehicle otherwise he cannot
        If Not System.Web.HttpContext.Current.Session("UserID") > 0 Then
            UserID = String.Empty
            UserID2 = String.Empty
            btnAddCart.Visible = False
        Else
            UserID = System.Web.HttpContext.Current.Session("UserID")
            UserID2 = lblUserID.Text
            btnAddCart.Visible = True
        End If
        'Splitting VID into VehicleID and User ID (Below)
        Dim IDStr() As String = VID.Split(",")
        Dim VIDStr As String = IDStr(0)

        If IDStr.Length <> 2 Then
            VIDStr = VIDStr.Replace("?VID=", "")
            lblVID.Text = VIDStr
            'If User is not logged in, UserID will be declared as 0
            'So it does not match any user thus the delete button will not be visible
            VehicleFunction.VehicleDelBtnValidation(0, VIDStr, btnVehDel)
        Else
            VIDStr = VIDStr.Replace("?VID=", "")
            lblVID.Text = VIDStr
            Dim UserIDStr As String = IDStr(1)
            UserIDStr = UserIDStr.Replace("UserID=", "")
            lblUserID.Text = UserIDStr
            VehicleFunction.SingleVehicleView(lblVID.Text, gvVehicle)
            BindingVehicleData()
            VehicleFunction.VehicleDelBtnValidation(UserIDStr, VIDStr, btnVehDel)
        End If

        'Hiding images having an empty URL (empty)
        If btnImg2.ImageUrl = String.Empty Then
            btnImg2.Visible = False
            btnImg3.Visible = False
            btnImg4.Visible = False
            btnImg5.Visible = False
            btnImg6.Visible = False
        ElseIf btnImg3.ImageUrl = String.Empty Then
            btnImg3.Visible = False
            btnImg4.Visible = False
            btnImg5.Visible = False
            btnImg6.Visible = False
        ElseIf btnImg4.ImageUrl = String.Empty Then
            btnImg4.Visible = False
            btnImg5.Visible = False
            btnImg6.Visible = False
        ElseIf btnImg5.ImageUrl = String.Empty Then
            btnImg5.Visible = False
            btnImg6.Visible = False
        ElseIf btnImg6.ImageUrl = String.Empty Then
            btnImg6.Visible = False
        End If
    End Sub

    Public Sub BindingVehicleData()
        Dim vMakeStr As String = CType(gvVehicle.Rows(0).FindControl("lblMake"), Label).Text
        Dim vModelStr As String = CType(gvVehicle.Rows(0).FindControl("lblModel"), Label).Text
        Dim VID As String = CType(gvVehicle.Rows(0).FindControl("lblVID"), Label).Text
        VName.Text = vMakeStr & " - " & vModelStr & " - " & VID
        VName.Text.ToUpper()

        'Getting values from VehicleView() to their respective text boxes/labels
        VTrans.Text = "Transmission Type: " & CType(gvVehicle.Rows(0).FindControl("lblTrans"), Label).Text
        VEngine.Text = "Engine CC: " & CType(gvVehicle.Rows(0).FindControl("lblEngine"), Label).Text
        VFuel.Text = "Fuel Type: " & CType(gvVehicle.Rows(0).FindControl("lblFuel"), Label).Text
        VColor.Text = "Color: " & CType(gvVehicle.Rows(0).FindControl("lblColor"), Label).Text
        VCond.Text = "Condition: " & CType(gvVehicle.Rows(0).FindControl("lblCond"), Label).Text
        VDescTxt.Text = "Additional Information: " & CType(gvVehicle.Rows(0).FindControl("lblDesc"), Label).Text
        lblPrice.Text = "Price: €" & CInt(CType(gvVehicle.Rows(0).FindControl("lblPrice"), Label).Text)
        Dim catIDStr As String = CType(gvVehicle.Rows(0).FindControl("lblCatID"), Label).Text
        Dim CatDesc As String = CType(gvVehicle.Rows(0).FindControl("lblCatDesc"), Label).Text

        lblCategory.Text = "Category: " & CatDesc

        If Not IsPostBack Then
            Dim MainImg As String = CType(gvVehicle.Rows(0).FindControl("lblMainImage"), Label).Text
            Dim AltImg As String = CType(gvVehicle.Rows(0).FindControl("lblAltImg"), Label).Text
            AltImgBinding(MainImg, AltImg)

        End If
    End Sub

    'Binding images and setting image properties
    Public Sub AltImgBinding(MainImg As String, AltImg As String)
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
    'Function to delete a vehicle
    Public Sub VehicleDel(V_ID As String, UserID As String)
        Try
            Dim VehicleData As New VehicleData
            Dim CMD As New SqlCommand()

            With CMD
                .Connection = Conn.OpenConn
                .CommandText = "DELETE FROM Vehicle WHERE V_ID=@V_ID AND UserID=@UserID"
                .Parameters.Clear()
                .Parameters.AddWithValue("@V_ID", V_ID)
                .Parameters.AddWithValue("@UserID", UserID)
                .ExecuteNonQuery()
            End With

            Dim CMDSuccess As Integer = CMD.ExecuteNonQuery()
            Dim imageToDel As String

            If CMDSuccess > 0 Then
                'Deleting all images for the vehicle being deleted
                If Not btnImg1.ImageUrl = String.Empty Then
                    imageToDel = Server.MapPath(btnImg1.ImageUrl)
                    System.IO.File.Delete(imageToDel)

                    If Not btnImg2.ImageUrl = String.Empty Then
                        imageToDel = Server.MapPath(btnImg2.ImageUrl)
                        System.IO.File.Delete(imageToDel)
                    End If

                    If Not btnImg3.ImageUrl = String.Empty Then
                        imageToDel = Server.MapPath(btnImg3.ImageUrl)
                        System.IO.File.Delete(imageToDel)
                    End If

                    If Not btnImg4.ImageUrl = String.Empty Then
                        imageToDel = Server.MapPath(btnImg4.ImageUrl)
                        System.IO.File.Delete(imageToDel)
                    End If

                    If Not btnImg5.ImageUrl = String.Empty Then
                        imageToDel = Server.MapPath(btnImg5.ImageUrl)
                        System.IO.File.Delete(imageToDel)
                    End If

                    If Not btnImg6.ImageUrl = String.Empty Then
                        imageToDel = Server.MapPath(btnImg6.ImageUrl)
                        System.IO.File.Delete(imageToDel)
                    End If
                    MsgBox("Vehicle was deleted succesfully!", MsgBoxStyle.Exclamation)
                End If
            End If

            Dim DR As SqlDataReader
            Dim DT As New DataTable

            DR = CMD.ExecuteReader
            DT.Load(DR)
            gvVehicle.DataSource = DT
            gvVehicle.DataBind()

        Catch e As SqlException
            MsgBox("An error has occurred: " & e.Message.ToString())
        Finally
            Conn.CloseConn()
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

    Protected Sub btnAddCart_Click(sender As Object, e As System.EventArgs) Handles btnAddCart.Click
        Dim vIDShopCartVal As ShoppingCartData = ShoppingCartValidation.ShoppingCartVehicleVal(lblVID.Text)

        If Not (vIDShopCartVal Is Nothing) Then
            MsgBox("You have already added this vehicle to your cart!", MsgBoxStyle.Exclamation)
            If Not lblTotal.Text = "€" Then
                lblTotal.Visible = True
            End If
            Return
        Else
            Dim SessionDate As DateTime = DateTime.Now
            Dim UserID As String = System.Web.HttpContext.Current.Session("UserID")
            'Quantity of (each) vehicle to be added to the cart shall be always 1
            Dim Qty As Integer = 1

            ShoppingCartFunction.AddToCart(SessionDate, UserID, lblVID.Text, Qty, gvVehicle)

            If lblShopItems.Text = String.Empty Or lblShopItems.Text = "Label" Then
                lblShopItems.Text = lblPrice.Text
            Else
                lblShopItems.Text = lblShopItems.Text + lblPrice.Text
            End If

            If Not lblShopItems.Text = String.Empty Then
                lblTotal.Visible = True
                lblShopItems.Visible = True
            End If
        End If
    End Sub
End Class


