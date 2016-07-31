Imports System.IO
Imports System.Data.SqlClient
Imports System.Data

Partial Class AddVehicle
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        UpldLbl.Text = "Please upload the MAIN IMAGE for your vehicle"
        'Adding items to the dropdown lists
        DropDownProperties()
    End Sub

    Protected Sub UpldBtn_Click(sender As Object, e As System.EventArgs) Handles btnUpload.Click
        UploadImg()
        If Not VehImg1.ImageUrl = String.Empty Then
            UpldLbl.Text = "Please upload additional images for your vehicle"
        Else
            UpldLbl.Text = "Please upload the MAIN IMAGE for your vehicle"
        End If
    End Sub

    Sub DropDownProperties()
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

    Protected Sub AddVehicle(VID As String, Year As String, Make As String, Model As String, Fuel As String, Engine As String,
                             Transmission As String, Color As String, Price As Integer, Description As String, Condition As String,
                             MainImage As String, AlternateImgs As String, CatID As Integer, UserID As Integer)

        Dim VehicleData As New VehicleData
        Dim Conn As New SqlConnection
        Conn.ConnectionString = "Server=Montesin-PC\SQLEXPRESS;Database=BIS2212-CW3;User Id=sa;Password=user123;"

        Dim CMD As New SqlCommand
        CMD = Conn.CreateCommand
        CMD.CommandType = CommandType.Text
        CMD.CommandText = "INSERT INTO Vehicle (V_ID, Year, Make, Model, Fuel, Engine, " & _
            "Transmission, Color, Price, Description, Condition, MainImage, AlternateImgs, CatID, UserID)" & _
            "VALUES (@V_ID, @Year, @Make, @Model, @Fuel, @Engine, " & _
            "@Transmission, @Color, @Price, @Description, @Condition, @MainImage, @AlternateImgs, @CatID, @UserID)"
        CMD.Connection = Conn

        Try
            Conn.Open()
            CMD.Parameters.Clear()

            CMD.Parameters.AddWithValue("@V_ID", VID)
            CMD.Parameters.AddWithValue("@Year", Year)
            CMD.Parameters.AddWithValue("@Make", Make)
            CMD.Parameters.AddWithValue("@Model", Model)
            CMD.Parameters.AddWithValue("@Fuel", Fuel)
            CMD.Parameters.AddWithValue("@Engine", Engine)
            CMD.Parameters.AddWithValue("@Transmission", Transmission)
            CMD.Parameters.AddWithValue("@Color", Color)
            CMD.Parameters.AddWithValue("@Price", Price)
            CMD.Parameters.AddWithValue("@Description", Description)
            CMD.Parameters.AddWithValue("@Condition", Condition)
            CMD.Parameters.AddWithValue("@MainImage", MainImage)
            CMD.Parameters.AddWithValue("@AlternateImgs", AlternateImgs)
            CMD.Parameters.AddWithValue("@CatID", CatID)
            CMD.Parameters.AddWithValue("@UserID", UserID)

            CMD.Connection = Conn
            CMD.ExecuteNonQuery()

        Catch e As SqlException
            MsgBox("An error has occured:" & e.Message.ToString())
        Finally
            Conn.Close()
            Conn.Dispose()
        End Try
    End Sub

    Protected Sub UploadImg()
        If fUImage.HasFile = False Then
            UpldLbl.Text = "No Image/s Found to Upload"
            UpldLbl.BackColor = Drawing.Color.Red
            Return
        Else
            ' Display the uploaded file's details
            UpldLbl.Text = String.Format( _
                    "Uploaded file: {0}<br />" & _
                    "File size (in bytes): {1:N0}<br />" & _
                    "Content-type: {2}", _
                    fUImage.FileName, _
                    fUImage.FileBytes.Length, _
                    fUImage.PostedFile.ContentType)
            ' Save the file

            Dim ImgPath As String = _
                Server.MapPath("~/Images/" & fUImage.FileName)

            'Validating image filenames if an image already exist in our db, the vehicle ID (which will be unique for all vehicles will 
            'be added to its original name
            If ImgPath = Path.GetFileName(fUImage.FileName) = True Then
                ImgPath = Server.MapPath("~/Images/" & txtVID.Text & fUImage.FileName)
                fUImage.SaveAs(ImgPath)
            Else
                fUImage.SaveAs(ImgPath)

                'Upload file into actual image
                Dim StrPath As String
                If fUImage.HasFile Then
                    Try
                        Dim filename As String = Path.GetFileName(fUImage.FileName)
                        fUImage.SaveAs(Server.MapPath("~/") & filename)
                        StrPath = "~/" & filename
                        UpldLbl.Text = "File Uploaded Successfully!"

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
                        UpldLbl.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message
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
        Dim AltImgs As String = VehImg2.ImageUrl.ToString & "," & VehImg3.ImageUrl.ToString & "," & _
            VehImg4.ImageUrl.ToString & "," & VehImg5.ImageUrl.ToString & "," & VehImg6.ImageUrl.ToString

        AltImgs = Regex.Replace(AltImgs, "~/Images/", "")
        MsgBox(AltImgs)

        'Dim VehicleData As VehicleData = VehicleValidation.VehicleVal(txtVID.Text.ToUpper)

        ''Removing any white space from the vehicle ID field
        'Dim VIDStr As String = Regex.Replace(txtVID.Text, "\s", "")

        ''Validating the data fields
        'If Not VehicleData Is Nothing Then
        '    MsgBox("Vehicle ID already exists", MsgBoxStyle.Exclamation)
        '    Return
        'ElseIf txtVID.Text = String.Empty Then
        '    MsgBox("Please enter a Vehicle ID", MsgBoxStyle.Exclamation)
        '    txtVID.BackColor = Drawing.Color.Red
        '    Return
        'ElseIf Not (VIDStr.Length = 8) Then
        '    MsgBox("Vehicle ID cannot be less/exceed 8 character", MsgBoxStyle.Exclamation)
        '    txtVID.BackColor = Drawing.Color.Red
        '    Return
        'ElseIf ddlYr.SelectedItem.Text = "Select YOM!" Then
        '    MsgBox("Please choose the vehicle's YOM!", MsgBoxStyle.Exclamation)
        '    ddlYr.BorderColor = Drawing.Color.Red
        '    Return
        'ElseIf (ddlYr.SelectedItem.Text < 1997 And ddlFuel.SelectedItem.Text = "Hybrid") Then
        '    MsgBox("First publicly available hybrid engined vehicle was not available until 1997!", MsgBoxStyle.Exclamation)
        '    ddlYr.SelectedItem.Text = "Select YOM!"
        '    Return
        'ElseIf txtMake.Text = String.Empty Then
        '    MsgBox("Please enter the make of your vehicle", MsgBoxStyle.Exclamation)
        '    txtMake.BackColor = Drawing.Color.Red
        '    Return
        'ElseIf txtModel.Text = String.Empty Then
        '    MsgBox("Please enter the model of your vehicle", MsgBoxStyle.Exclamation)
        '    txtModel.BackColor = Drawing.Color.Red
        '    Return
        'ElseIf ddlFuel.SelectedItem.Text = "Select Fuel Type!" Then
        '    MsgBox("Please a fuel type for your vehicle!", MsgBoxStyle.Exclamation)
        '    ddlFuel.BorderColor = Drawing.Color.Red
        '    Return
        'ElseIf txtEngine.Text = String.Empty Then
        '    MsgBox("Please enter the size of your vehicle's engine!", MsgBoxStyle.Exclamation)
        '    txtEngine.BackColor = Drawing.Color.Red
        '    Return
        'ElseIf Not IsNumeric(txtEngine.Text) Then
        '    MsgBox("Engine value has to be strictly numerical!", MsgBoxStyle.Exclamation)
        '    txtEngine.BackColor = Drawing.Color.Red
        '    Return
        'ElseIf ddlTrans.SelectedItem.Text = "Choose a Transmission Type!" Then
        '    MsgBox("Please select a transmission type!", MsgBoxStyle.Exclamation)
        '    ddlTrans.BorderColor = Drawing.Color.Red
        '    Return
        'ElseIf txtColor.Text = String.Empty Then
        '    MsgBox("Please enter your vehicle's color!", MsgBoxStyle.Exclamation)
        '    txtColor.BackColor = Drawing.Color.Red
        '    Return
        'ElseIf IsNumeric(txtColor) Then
        '    MsgBox("Vehicle's color cannot be numerical!", MsgBoxStyle.Exclamation)
        '    txtColor.BackColor = Drawing.Color.Red
        '    Return
        'ElseIf txtPrice.Text = String.Empty Then
        '    MsgBox("Please enter your vehicle's price!", MsgBoxStyle.Exclamation)
        '    txtPrice.BackColor = Drawing.Color.Red
        '    Return
        'ElseIf Not IsNumeric(txtPrice) Then
        '    MsgBox("Vehicle price has to be strictly numerical!", MsgBoxStyle.Exclamation)
        '    txtColor.BackColor = Drawing.Color.Red
        '    Return
        'ElseIf txtDesc.Text = String.Empty Then
        '    MsgBox("Please enter vehicle's description!", MsgBoxStyle.Exclamation)
        '    txtDesc.BackColor = Drawing.Color.Red
        '    Return
        'ElseIf ddlCond.SelectedItem.Text = "Choose The Vehicle Condition!" Then
        '    MsgBox("Please specify your vehicle's condition!", MsgBoxStyle.Exclamation)
        '    ddlCond.BorderColor = Drawing.Color.Red
        '    Return
        'ElseIf VehImg1.ImageUrl = String.Empty Then
        '    MsgBox("Please add at least one image for your vehicle!", MsgBoxStyle.Exclamation)
        '    Return
        'Else
        '    AddVehicle(VIDStr.ToUpper, ddlYr.SelectedItem.Text, Make, Model, ddlFuel.SelectedItem.Text,
        '                       txtEngine.Text, ddlTrans.SelectedItem.Text, Color, txtPrice.Text, Desc, ddlCond.SelectedItem.Text, VehImg1.ImageUrl.ToString,
        '                       AltImgs, ddlCat.Text.ToString, Request.QueryString("UserID"))
        'End If
    End Sub
End Class
