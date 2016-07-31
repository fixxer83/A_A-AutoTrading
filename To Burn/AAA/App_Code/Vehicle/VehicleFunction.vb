Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class VehicleFunction

    Public Sub VehicleFill(gvVehicle As GridView)
        Dim CmdStr As String
        CmdStr = "Select * From Vehicle Where Sold ='False';"
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

    Public Sub VehicleFillAdmin(gvVehicle As GridView)
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

    Public Sub SingleVehicleView(V_ID As String, gvVehicle As GridView)
        Try
            Dim UserData As New UserData
            Dim CMD As New SqlCommand()

            With CMD
                .Connection = Conn.OpenConn
                .CommandText = "Select V.*, C.Description As CatDesc From Vehicle V, Category C Where V_ID = @V_ID And V.CatID = C.CatID;"
                .Parameters.Clear()
                .Parameters.AddWithValue("@V_ID", V_ID)
            End With

            Dim DR As SqlDataReader
            Dim DT As New DataTable

            DR = CMD.ExecuteReader
            DT.Load(DR)
            gvVehicle.DataSource = DT
            gvVehicle.DataBind()

        Catch e As SqlException
            MsgBox("An error has occurred " & e.Message.ToString())
        Finally
            Conn.CloseConn()
        End Try
    End Sub

    Public Sub AddVehicle(VID As String, Year As String, Make As String, Model As String, Fuel As String, Engine As String,
                             Transmission As String, Color As String, Price As Integer, Description As String, Condition As String,
                             MainImage As String, AlternateImgs As String, CatID As Integer, UserID As Integer, Sold As Boolean)

        Try
            Dim CMD As New SqlCommand()

            With CMD
                .Connection = Conn.OpenConn
                .CommandText = "INSERT INTO Vehicle (V_ID, Year, Make, Model, Fuel, Engine, " & _
            "Transmission, Color, Price, Description, Condition, MainImage, AlternateImgs, CatID, UserID, Sold)" & _
            "VALUES (@V_ID, @Year, @Make, @Model, @Fuel, @Engine, " & _
            "@Transmission, @Color, @Price, @Description, @Condition, @MainImage, @AlternateImgs, @CatID, @UserID, @Sold)"
                .Parameters.Clear()
                .Parameters.AddWithValue("@V_ID", VID)
                .Parameters.AddWithValue("@Year", Year)
                .Parameters.AddWithValue("@Make", Make)
                .Parameters.AddWithValue("@Model", Model)
                .Parameters.AddWithValue("@Fuel", Fuel)
                .Parameters.AddWithValue("@Engine", Engine)
                .Parameters.AddWithValue("@Transmission", Transmission)
                .Parameters.AddWithValue("@Color", Color)
                .Parameters.AddWithValue("@Price", Price)
                .Parameters.AddWithValue("@Description", Description)
                .Parameters.AddWithValue("@Condition", Condition)
                .Parameters.AddWithValue("@MainImage", MainImage)
                .Parameters.AddWithValue("@AlternateImgs", AlternateImgs)
                .Parameters.AddWithValue("@CatID", CatID)
                .Parameters.AddWithValue("@UserID", UserID)
                .Parameters.AddWithValue("@Sold", Sold)
                .ExecuteNonQuery()
            End With

        Catch e As SqlException
            MsgBox("An error has occurred " & e.Message.ToString())
        Finally
            Conn.CloseConn()
        End Try
    End Sub

    Public Sub VehicleDelBtnValidation(UserID As String, V_ID As String, btnVehDel As Button)
        Try
            Dim UserData As New UserData
            Dim CMD As New SqlCommand()

            With CMD
                .Connection = Conn.OpenConn
                .CommandText = "Select * From Vehicle Where UserID=@UserID And V_ID=@V_ID;"
                .Parameters.Clear()
                .Parameters.AddWithValue("@UserID", UserID)
                .Parameters.AddWithValue("@V_ID", V_ID)
                .ExecuteNonQuery()
            End With
            Dim read As SqlDataReader
            read = CMD.ExecuteReader()

            If read.HasRows Then
                btnVehDel.Visible = True
            Else
                btnVehDel.Visible = False
            End If

        Catch e As SqlException
            MsgBox("An error has occurred " & e.Message.ToString())
        Finally
            Conn.CloseConn()
        End Try
    End Sub

    Public Sub SearchQuery(SearchStr As String, gvVehicle As GridView)
        Try
            Dim CMD As New SqlCommand()
            With CMD
                .Connection = Conn.OpenConn
                'Select Statement
                .CommandText = "Select * From Vehicle Where Make = " & _
                    "@SearchStr Or Model=@SearchStr or Condition=@SearchStr And Sold='False';"
                .Parameters.Clear()
                .Parameters.AddWithValue("@SearchStr", SearchStr)
            End With

            Dim DR As SqlDataReader
            Dim DT As New DataTable
            DR = CMD.ExecuteReader
            DT.Load(DR)
            gvVehicle.DataSource = DT
            gvVehicle.DataBind()
        Catch e As SqlException
            MsgBox("An error has occurred " & e.Message.ToString())
        Finally
            Conn.CloseConn()
        End Try
    End Sub

    'Delete selected Vehicle
    Public Sub VehicleDel(V_ID As String, gvVehicle As GridView)
        Try
            Dim CMD As New SqlCommand()
            With CMD
                .Connection = Conn.OpenConn
                .CommandText = "Delete FROM Vehicle WHERE V_ID=@V_ID;"
                .Parameters.Clear()
                .Parameters.AddWithValue("@V_ID", V_ID)
                .ExecuteNonQuery()
            End With

            Dim DR As SqlDataReader
            Dim DT As New DataTable
            DR = CMD.ExecuteReader
            DT.Load(DR)
            gvVehicle.DataSource = DT
            gvVehicle.DataBind()
        Catch e As SqlException
            MsgBox("An error has occurred " & e.Message.ToString())
        Finally
            Conn.CloseConn()
        End Try

    End Sub

    Public Sub UserVehicles(UserID As String, gvVehicle As GridView)
        Try
            Dim UserData As New UserData
            Dim CMD As New SqlCommand()
            With CMD
                .Connection = Conn.OpenConn
                .CommandText = "Select * From Vehicle Where UserID = @UserID;"
                .Parameters.Clear()
                .Parameters.AddWithValue("@UserID", UserID)
            End With

            Dim DR As SqlDataReader
            Dim DT As New DataTable
            DR = CMD.ExecuteReader
            DT.Load(DR)
            gvVehicle.DataSource = DT
            gvVehicle.DataBind()
        Catch e As SqlException
            MsgBox("An error has occurred " & e.Message.ToString())
        Finally
            Conn.CloseConn()
        End Try
    End Sub

End Class
