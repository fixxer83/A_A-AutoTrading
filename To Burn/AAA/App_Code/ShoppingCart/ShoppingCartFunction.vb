Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class ShoppingCartFunction

    'Populating gvShopCart with (SQL Table) ShoppingCart contents
    Public Sub gvShopCartFill(UserID As String, gvShopCart As GridView)
        Try
            Dim CMD As New SqlCommand()
            With CMD
                .Connection = Conn.OpenConn
                .CommandText = "Select S.*, V.Price As ShopPrice From ShoppingCart S, Vehicle V Where S.UserID = @UserID And S.V_ID = V.V_ID;"
                .Parameters.Clear()
                .Parameters.AddWithValue("@UserID", UserID)
                .ExecuteNonQuery()
            End With
            Dim DR As SqlDataReader
            Dim DT As New DataTable

            DR = CMD.ExecuteReader
            DT.Load(DR)
            gvShopCart.DataSource = DT
            gvShopCart.DataBind()

            'Producing the total price of all the vehicles in the Shopping Cart
            Dim i As Integer = 0
            For Each count As GridViewRow In gvShopCart.Rows

                Dim Price As Integer = CType(gvShopCart.Rows(i).FindControl("lblShopPrice"), Label).Text
                Dim TotalPrice As Integer
                TotalPrice += Price

                Dim lblControl As Label = DirectCast(gvShopCart.FooterRow.FindControl("lblTotalPrice"), Label)
                lblControl.Text = "€" & Convert.ToDecimal(TotalPrice.ToString())
                i = i + 1
            Next
        Catch e As SqlException
            MsgBox("An error has occurred " & e.Message.ToString())
        Finally
            Conn.CloseConn()
        End Try
    End Sub

    'Deleting the selected item from the Shopping Cart
    Public Sub gvShopCartItemDel(V_ID As String, UserID As String, gvShopCart As GridView)
        Try
            Dim VehicleData As New VehicleData
            Dim CMD As New SqlCommand()

            With CMD
                .Connection = Conn.OpenConn
                .CommandText = "Delete From ShoppingCart Where V_ID = @V_ID And UserID = @UserID;"
                .Parameters.Clear()
                .Parameters.AddWithValue("@V_ID", V_ID)
                .Parameters.AddWithValue("@UserID", UserID)
            End With
            Dim DR As SqlDataReader
            Dim DT As New DataTable

            DR = CMD.ExecuteReader
            DT.Load(DR)
            gvShopCart.DataSource = DT
            gvShopCart.DataBind()

        Catch e As SqlException
            MsgBox("An error has occurred " & e.Message.ToString())
        Finally
            Conn.CloseConn()
        End Try

    End Sub

    Public Sub AddToCart(SessionDate As DateTime, UserID As Integer, V_ID As String, Quantity As Integer, gvCategory As GridView)
        Try
            Dim UserData As New UserData
            Dim CMD As New SqlCommand()

            With CMD
                .Connection = Conn.OpenConn
                .CommandText = "INSERT INTO ShoppingCart (SessionDate, UserID, V_ID, Quantity) VALUES" & _
           "(@SessionDate, @UserID, @V_ID, @Quantity)"
                .Parameters.Clear()
                .Parameters.AddWithValue("@SessionDate", SessionDate)
                .Parameters.AddWithValue("@UserID", UserID)
                .Parameters.AddWithValue("@V_ID", V_ID)
                .Parameters.AddWithValue("@Quantity", Quantity)
                .ExecuteNonQuery()
            End With

        Catch e As SqlException
            MsgBox("An error has occurred " & e.Message.ToString())
        Finally
            Conn.CloseConn()
        End Try
    End Sub

    'Getting the shopping cart's price for the logged in user
    Public Sub ShoppingCartTotal(UserID As String, lblTotalPrice As Label)
        Try
            Dim VehicleData As New VehicleData
            Dim CMD As New SqlCommand()

            With CMD
                .Connection = Conn.OpenConn
                .CommandText = "Select Price From Vehicle V, ShoppingCart S Where S.UserID = @UserID And S.V_ID = V.V_ID;"
                .Parameters.Clear()
                .Parameters.AddWithValue("@UserID", UserID)

            End With
            Dim DR As SqlDataReader
            Dim DT As New DataTable

            DR = CMD.ExecuteReader
            If DR.HasRows Then
                Dim singlePrice As Int64 = 0
                Dim Total As Int64 = 0

                While DR.Read()
                    singlePrice = DR.Item("Price")
                    Total = Total + singlePrice
                End While
                lblTotalPrice.Text = Total
            Else
                Return
            End If
            MsgBox(lblTotalPrice.Text)
        Catch e As SqlException
            MsgBox("An error has occurred " & e.Message.ToString())
        Finally
            Conn.CloseConn()
        End Try

    End Sub

End Class
