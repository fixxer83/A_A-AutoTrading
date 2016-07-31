Imports System.Data.SqlClient
Imports System.Data
Partial Class AdminPanel
    Inherits System.Web.UI.Page
    Dim CategoryFunction As New CategoryFunction
    Dim VehicleFunction As New VehicleFunction
    Dim UserFunction As New UserFunction

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        gvVehicle.Visible = False
        pAddCat.Visible = False
        gvCategories.Visible = False
        gvOrder.Visible = False
        gvOrderLine.Visible = False
        gvUser.Visible = False
    End Sub

    Protected Sub btnUsers_Click(sender As Object, e As System.EventArgs) Handles btnUsers.Click
        gvVehicle.Visible = False
        pAddCat.Visible = False
        gvCategories.Visible = False
        gvOrder.Visible = False
        gvOrderLine.Visible = False
        gvUser.Visible = True
        UserFunction.UserGvFill(gvUser)
    End Sub

    Protected Sub btnVehicles_Click(sender As Object, e As System.EventArgs) Handles btnVehicles.Click
        gvVehicle.Visible = True
        pAddCat.Visible = False
        gvCategories.Visible = False
        gvOrder.Visible = False
        gvOrderLine.Visible = False
        gvUser.Visible = False
        VehicleFunction.VehicleFillAdmin(gvVehicle)
    End Sub

    Protected Sub btnCategories_Click(sender As Object, e As System.EventArgs) Handles btnCategories.Click
        gvVehicle.Visible = False
        pAddCat.Visible = True
        gvCategories.Visible = True
        gvOrder.Visible = False
        gvOrderLine.Visible = False
        gvUser.Visible = False
        CategoryFunction.gvCategoryFill(gvCategories)
    End Sub

    Protected Sub gvCategories_RowDeleting(sender As Object, e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvCategories.RowDeleting

        Dim delQuestion = MsgBox("Are you sure you want to delete this category?", MsgBoxStyle.YesNo)
        Dim CatID As Integer = CInt(CType(gvCategories.Rows(e.RowIndex).FindControl("lblCatID"), Label).Text)
        Dim VehicleCategory As CategoryData = CategoryValidation.VehicleCategoryVal(CatID)

        If delQuestion = 6 Then
            If Not (VehicleCategory Is Nothing) Then
                MsgBox("Category selected cannot be deleted, since it is still associated with some vehicles!", MsgBoxStyle.Exclamation)
                Return
            Else
                CategoryFunction.CategoryDel(CatID, gvCategories)
                CategoryFunction.gvCategoryFill(gvCategories)
            End If
        ElseIf delQuestion = 7 Then
            Return
        End If

    End Sub

    Protected Sub gvCategories_RowEditing(sender As Object, e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvCategories.RowEditing

    End Sub

    Protected Sub gvCategories_RowUpdating(sender As Object, e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gvCategories.RowUpdating
        'Getting The gridview row values
        Dim CatID As Integer = CInt(CType(gvCategories.Rows(e.RowIndex).FindControl("txtCatID"), TextBox).Text)
        Dim Description As String = CType(gvCategories.Rows(e.RowIndex).FindControl("txtDesc"), TextBox).Text
        Dim DateCreated As Date = CType(gvCategories.Rows(e.RowIndex).FindControl("txtDateCr"), TextBox).Text

        Dim CatValidation As CategoryData = CategoryValidation.CategoryVal(Description)

        'Determining whether the category entered is already existent in our database
        If Not (CatValidation Is Nothing) Then
            MsgBox("Category you tried to enter, already matches another category, please try again!", MsgBoxStyle.Exclamation)
            txtDescription.Text = String.Empty
            CategoryFunction.gvCategoryFill(gvCategories)
            Return
        Else
            CategoryFunction.GVUpd(CatID, Description, DateCreated, gvCategories)
            CategoryFunction.gvCategoryFill(gvCategories)
        End If
    End Sub
    Protected Sub btnSaveCat_Click1(sender As Object, e As System.EventArgs) Handles btnSaveCat.Click
        Dim Description As String = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtDescription.Text)
        'Dim DateCreated As Date = Date.Now

        Dim CatValidation As CategoryData = CategoryValidation.CategoryVal(Description)

        If Not (CatValidation Is Nothing) Then
            MsgBox("Category you tried to enter, already matches another category, please try again!", MsgBoxStyle.Exclamation)
            Return
        ElseIf txtDescription.Text = String.Empty Then
            MsgBox("Kindly enter a valid Description for you category!", MsgBoxStyle.Exclamation)
            Return
        Else
            CategoryFunction.AddNewCat(Description, Date.Now, gvCategories)
            CategoryFunction.gvCategoryFill(gvCategories)
            txtDescription.Text = ""
        End If

    End Sub

    Protected Sub gvVehicle_RowDeleting(sender As Object, e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvVehicle.RowDeleting
        Dim delQuestion = MsgBox("Are you sure you want to delete this Vehicle?", MsgBoxStyle.YesNo)
        Dim V_ID As String = CType(gvVehicle.Rows(e.RowIndex).FindControl("lblVID"), Label).Text

        If delQuestion = 6 Then
            VehicleFunction.VehicleDel(V_ID, gvVehicle)
            VehicleFunction.VehicleFillAdmin(gvVehicle)
        Else
            Return
        End If
    End Sub

    Protected Sub gvVehicle_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvVehicle.SelectedIndexChanged
        'Selecting a vehicle
        Dim VID As New Label
        Dim i As Integer = gvVehicle.SelectedIndex
        VID.Text = CStr(CType(gvVehicle.Rows(i).FindControl("lblVID"), Label).Text)
        Response.Redirect("CarsSingleView.aspx?VID=" + Server.UrlEncode(VID.Text) + ",UserID=" + Server.UrlEncode(System.Web.HttpContext.Current.Session("UserID")))
    End Sub

    Protected Sub btnAddVeh_Click(sender As Object, e As System.EventArgs) Handles btnAddVeh.Click
        Response.Redirect("AddVehicle.Aspx?IsAdmin=" + Server.UrlEncode(System.Web.HttpContext.Current.Session("UserID")))
    End Sub

    Protected Sub gvCategories_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvCategories.SelectedIndexChanged

    End Sub
End Class
