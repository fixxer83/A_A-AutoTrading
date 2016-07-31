Imports System.IO
Imports System.Data.SqlClient
Imports System.Data

Partial Class AddVehicle
    Inherits System.Web.UI.Page

    Dim VehicleFunction As New VehicleFunction

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        lblUpld.Text = "Please upload the MAIN IMAGE for your vehicle"
        lblmainAltImg.Visible = False
        'Adding items to the dropdown lists
        DropDownProperties()
    End Sub

    Protected Sub UpldBtn_Click(sender As Object, e As System.EventArgs) Handles btnUpload.Click
        UploadImg()
        If Not VehImg1.ImageUrl = String.Empty Then
            lblmainAltImg.Visible = True
            lblmainAltImg.Text = "Please upload additional images for your vehicle"
            lblmainAltImg.ForeColor = Drawing.Color.Red
        Else
            lblmainAltImg.Visible = True
            lblmainAltImg.Text = "Please upload at least one MAIN IMAGE for your vehicle"
            lblmainAltImg.ForeColor = Drawing.Color.Red
        End If
    End Sub

    Protected Sub DropDownProperties()
        'Adding a span of 50 years (to the age of the vehicle) from current year - 50
        ddlYr.Items.Add("Select YOM!")
        Dim i As Integer = DateTime.Now.Year + 1
        Do Until i = 1950
            i = i - 1
            ddlYr.Items.Add(i)
        Loop

        'Adding fuel types in the FuelDDL
        ddlFuel.Items.Add("Select Fuel Type!")
        ddlFuel.Items.Add("Unleaded")
        ddlFuel.Items.Add("Diesel")
        ddlFuel.Items.Add("Hybrid")

        'Adding transmission types in the TransDDL
        ddlTrans.Items.Add("Choose a Transmission Type!")
        ddlTrans.Items.Add("Manual")
        ddlTrans.Items.Add("Auto")

        'Adding condition types in the CondDDL
        ddlCond.Items.Add("Choose The Vehicle Condition!")
        ddlCond.Items.Add("New")
        ddlCond.Items.Add("Second hand")

        'Populating the Category Table's data into ddlCat
        If Not IsPostBack Then
            Dim cmd As New SqlCommand("SELECT * FROM Category", Conn.OpenConn)
            Dim ddlValues As SqlDataReader
            ddlValues = cmd.ExecuteReader()
            ddlCat.DataSource = ddlValues
            ddlCat.DataValueField = "CatID"
            ddlCat.DataTextField = "Description"
            ddlCat.DataBind()
            cmd.Connection.Close()
            cmd.Connection.Dispose()
        Else
            Return
        End If
    End Sub

    Protected Sub UploadImg()
        'Max image size 2621440bytes / 2.50mb
        Dim imageSize As Integer = 2621440

        Dim ext As String = IO.Path.GetExtension(fUImage.FileName)
        If fUImage.HasFile = False Then
            lblUpld.Text = "No Image/s found to Upload"
            lblUpld.ForeColor = Drawing.Color.Red
            Return
        ElseIf fUImage.FileBytes.Length > imageSize Then
            lblUpld.Text = "Image must not exceed 2.50 mb!"
            lblUpld.ForeColor = Drawing.Color.Red
            Return
        ElseIf Not (ext = ".jpg" Or ext = ".png") Then
            lblUpld.Text = "Kindly use ""jpg"" or ""png"" image types only!"
            lblUpld.ForeColor = Drawing.Color.Red
            Return
        Else
            'Info about the uploaded file
            lblUpld.Text = String.Format( _
                    "Uploaded file: {0}<br />" & _
                    "Size: {1:N0} bytes<br />" & _
                    "Content-type: {2}", _
                    fUImage.FileName, _
                    fUImage.FileBytes.Length, _
                    fUImage.PostedFile.ContentType)
            lblUpld.ForeColor = Drawing.Color.Red

            'Determinig the file path (to be saved)
            Dim ImgPath As String = _
                Server.MapPath("~/Images/" & fUImage.FileName)

            'Validating image filenames if an image already exist in our db, the vehicle ID (which will be unique for all vehicles will 
            'be added to its original name
            If ImgPath = Path.GetFileName(fUImage.FileName) = True Then
                ImgPath = Server.MapPath("~/Images/" & txtVID.Text & fUImage.FileName)
                fUImage.SaveAs(Server.MapPath("~/Images/") & ImgPath)
            Else
                ImgPath = Server.MapPath("~/Images/" & fUImage.FileName)
                fUImage.SaveAs(ImgPath)

                'Upload file into actual image
                Dim StrPath As String
                If fUImage.HasFile Then
                    Try

                        Dim filename As String = Path.GetFileName(fUImage.FileName)
                        'fUImage.SaveAs(Server.MapPath("~/Images/") & filename)
                        StrPath = "~/Images/" & filename
                        lblUpld.Text = lblUpld.Text & " File Uploaded Successfully!"

                        If VehImg1.ImageUrl = String.Empty Then
                            VehImg1.Visible = True
                            VehImg1.ImageUrl = StrPath
                        ElseIf VehImg2.ImageUrl = String.Empty Then
                            VehImg2.Visible = True
                            VehImg2.ImageUrl = StrPath
                        ElseIf VehImg3.ImageUrl = String.Empty Then
                            VehImg3.Visible = True
                            VehImg3.ImageUrl = StrPath
                        ElseIf VehImg4.ImageUrl = String.Empty Then
                            VehImg4.Visible = True
                            VehImg4.ImageUrl = StrPath
                        ElseIf VehImg5.ImageUrl = String.Empty Then
                            VehImg5.Visible = True
                            VehImg5.ImageUrl = StrPath
                        ElseIf VehImg6.ImageUrl = String.Empty Then
                            VehImg6.Visible = True
                            VehImg6.ImageUrl = StrPath
                        Else
                            MsgBox("You cannot upload more than six images!", MsgBoxStyle.Information)
                            Return
                        End If
                    Catch ex As Exception
                        lblUpld.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message
                    End Try
                End If
            End If
        End If
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As System.EventArgs) Handles btnSave.Click
        'Fetching the information from the objects
        Dim Make As String = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtMake.Text)
        Dim Model As String = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtModel.Text)
        Dim Color As String = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtColor.Text)
        Dim Desc As String = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtDesc.Text)
        Dim MainImage As String = VehImg1.ImageUrl.ToString
        Dim AltImgs As String

        'Determining which images from the VehImg series contain a valid URL that can be saved in our DB
        If VehImg2.ImageUrl.ToString = "" Then
            AltImgs = ""
        ElseIf VehImg3.ImageUrl.ToString = "" Then
            AltImgs = VehImg2.ImageUrl.ToString
        ElseIf VehImg4.ImageUrl.ToString = "" Then
            AltImgs = VehImg2.ImageUrl.ToString & "," & VehImg3.ImageUrl.ToString
        ElseIf VehImg5.ImageUrl.ToString = "" Then
            AltImgs = VehImg2.ImageUrl.ToString & "," & VehImg3.ImageUrl.ToString & "," & _
                VehImg4.ImageUrl.ToString()
        ElseIf VehImg6.ImageUrl.ToString = "" Then
            AltImgs = VehImg2.ImageUrl.ToString & "," & VehImg3.ImageUrl.ToString & "," & _
                VehImg4.ImageUrl.ToString & "," & VehImg5.ImageUrl.ToString
        Else
            AltImgs = VehImg2.ImageUrl.ToString & "," & VehImg3.ImageUrl.ToString & "," & _
                VehImg4.ImageUrl.ToString & "," & VehImg5.ImageUrl.ToString & "," & VehImg6.ImageUrl.ToString
        End If

        'Prior Saving the image to our database the folder name will be removed from the actual db, for both MainImage and AltImgs
        MainImage = Regex.Replace(MainImage, "~/Images/", "")
        AltImgs = Regex.Replace(AltImgs, "~/Images/", "")

        Dim VehicleData As VehicleData = VehicleValidation.VehicleVal(txtVID.Text.ToUpper)

        'Removing any white space from the vehicle ID field
        Dim VIDStr As String = Regex.Replace(txtVID.Text, "\s", "")

        'Validating the data fields
        If Not VehicleData Is Nothing Then
            MsgBox("Vehicle ID already exists", MsgBoxStyle.Exclamation)
            Return
        ElseIf txtVID.Text = String.Empty Then
            MsgBox("Please enter a Vehicle ID", MsgBoxStyle.Exclamation)
            txtVID.BackColor = Drawing.Color.Red
            Return
        ElseIf Not (VIDStr.Length = 8) Then
            MsgBox("Vehicle ID cannot be less/exceed 8 character", MsgBoxStyle.Exclamation)
            txtVID.BackColor = Drawing.Color.Red
            Return
        ElseIf ddlYr.SelectedItem.Text = "Select YOM!" Then
            MsgBox("Please choose the vehicle's YOM!", MsgBoxStyle.Exclamation)
            ddlYr.BorderColor = Drawing.Color.Red
            Return
        ElseIf (ddlYr.SelectedItem.Text < 1997 And ddlFuel.SelectedItem.Text = "Hybrid") Then
            MsgBox("First publicly available hybrid engined vehicle was not available until 1997!", MsgBoxStyle.Exclamation)
            ddlYr.SelectedItem.Text = "Select YOM!"
            Return
        ElseIf txtMake.Text = String.Empty Then
            MsgBox("Please enter the make of your vehicle", MsgBoxStyle.Exclamation)
            txtMake.BackColor = Drawing.Color.Red
            Return
        ElseIf txtModel.Text = String.Empty Then
            MsgBox("Please enter the model of your vehicle", MsgBoxStyle.Exclamation)
            txtModel.BackColor = Drawing.Color.Red
            Return
        ElseIf ddlFuel.SelectedItem.Text = "Select Fuel Type!" Then
            MsgBox("Please a fuel type for your vehicle!", MsgBoxStyle.Exclamation)
            ddlFuel.BorderColor = Drawing.Color.Red
            Return
        ElseIf txtEngine.Text = String.Empty Then
            MsgBox("Please enter the size of your vehicle's engine!", MsgBoxStyle.Exclamation)
            txtEngine.BackColor = Drawing.Color.Red
            Return
        ElseIf Not IsNumeric(txtEngine.Text) Then
            MsgBox("Engine value has to be strictly numerical!", MsgBoxStyle.Exclamation)
            txtEngine.BackColor = Drawing.Color.Red
            Return
        ElseIf ddlTrans.SelectedItem.Text = "Choose a Transmission Type!" Then
            MsgBox("Please select a transmission type!", MsgBoxStyle.Exclamation)
            ddlTrans.BorderColor = Drawing.Color.Red
            Return
        ElseIf txtColor.Text = String.Empty Then
            MsgBox("Please enter your vehicle's color!", MsgBoxStyle.Exclamation)
            txtColor.BackColor = Drawing.Color.Red
            Return
        ElseIf IsNumeric(txtColor) Then
            MsgBox("Vehicle's color cannot be numerical!", MsgBoxStyle.Exclamation)
            txtColor.BackColor = Drawing.Color.Red
            Return
        ElseIf txtPrice.Text = String.Empty Then
            MsgBox("Please enter your vehicle's price!", MsgBoxStyle.Exclamation)
            txtPrice.BackColor = Drawing.Color.Red
            Return
        ElseIf Not IsNumeric(txtPrice.Text) Then
            MsgBox("Vehicle price has to be strictly numerical!", MsgBoxStyle.Exclamation)
            txtPrice.BackColor = Drawing.Color.Red
            Return
        ElseIf txtDesc.Text = String.Empty Then
            MsgBox("Please enter vehicle's description!", MsgBoxStyle.Exclamation)
            txtDesc.BackColor = Drawing.Color.Red
            Return
        ElseIf ddlCond.SelectedItem.Text = "Choose The Vehicle Condition!" Then
            MsgBox("Please specify your vehicle's condition!", MsgBoxStyle.Exclamation)
            ddlCond.BorderColor = Drawing.Color.Red
            Return
        ElseIf VehImg1.ImageUrl = String.Empty Then
            MsgBox("Please add at least one image for your vehicle!", MsgBoxStyle.Exclamation)
            Return
        Else
            'Calling AddVehicle() from the VehicleFunction class to add a new vehicle
            VehicleFunction.AddVehicle(VIDStr.ToUpper, ddlYr.SelectedItem.Text, Make, Model, ddlFuel.SelectedItem.Text,
                               txtEngine.Text, ddlTrans.SelectedItem.Text, Color, txtPrice.Text, Desc, ddlCond.SelectedItem.Text, MainImage,
                               AltImgs, ddlCat.Text.ToString, HttpContext.Current.Session("UserID"), "False")
        End If
    End Sub
End Class
