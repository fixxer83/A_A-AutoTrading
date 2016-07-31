Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class OrderFunction

    'Method for an order acording to the shopping cart items!
    Public Sub PlaceOrder(UserID As Integer, DateTime As DateTime, TotalPrice As Int64)
        Try
            Dim CMD As New SqlCommand()
            With CMD
                .Connection = Conn.OpenConn
                .CommandText = "INSERT INTO [Order] (UserID, DateTime, TotalPrice)" & _
                    "VALUES (@UserID, @DateTime, @TotalPrice)"
                .Parameters.Clear()
                .Parameters.AddWithValue("@UserID", UserID)
                .Parameters.AddWithValue("@DateTime", DateTime)
                .Parameters.AddWithValue("@TotalPrice", TotalPrice)
                .ExecuteNonQuery()
            End With

        Catch e As SqlException
            MsgBox("An error has occurred " & e.Message.ToString())
        Finally
            Conn.CloseConn()
        End Try
    End Sub

    'Add orderLine!
    Public Sub AddOrderLine(UserID As Integer, DateTime As DateTime, TotalPrice As Int64, V_ID As String, Quantity As Integer)
        Try
            Dim CMD As New SqlCommand()
            With CMD
                .Connection = Conn.OpenConn
                .CommandText = "INSERT INTO OrderLine (OrderID, V_ID, Quantity) SELECT OrderID," & _
                    "@V_ID, @Quantity From [Order] Where Datetime=@DateTime and UserID=@UserID And TotalPrice=@TotalPrice"
                .Parameters.Clear()
                .Parameters.AddWithValue("@UserID", UserID)
                .Parameters.AddWithValue("@DateTime", DateTime)
                .Parameters.AddWithValue("@TotalPrice", TotalPrice)
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

    Public Sub VehicleSoldStatus(V_ID As String)
        Try
            Dim CMD As New SqlCommand()
            With CMD
                .Connection = Conn.OpenConn
                .CommandText = "Update Vehicle Set Sold = 'True' Where V_ID = @V_ID"
                .Parameters.Clear()
                .Parameters.AddWithValue("@V_ID", V_ID)
                .ExecuteNonQuery()
            End With
        Catch e As SqlException
            MsgBox("An error has occurred " & e.Message.ToString())
        Finally
            Conn.CloseConn()
        End Try
    End Sub

    Public Sub EmptyCart(UserID As Integer)
        Try
            Dim CMD As New SqlCommand()
            With CMD
                .Connection = Conn.OpenConn
                .CommandText = "Delete From ShoppingCart Where UserID=@UserID;"
                .Parameters.Clear()
                .Parameters.AddWithValue("@UserID", UserID)
                .ExecuteNonQuery()
            End With
        Catch e As SqlException
            MsgBox("An error has occurred " & e.Message.ToString())
        Finally
            Conn.CloseConn()
        End Try

    End Sub

    'Populating gvOrder with the data fetched from the Order table
    Public Sub gvOrderFill(UserID As Integer, gvOrder As GridView)
        Dim DR As SqlDataReader
        Dim DT As New DataTable

        Try
            Dim CMD As New SqlCommand()
            With CMD
                .Connection = Conn.OpenConn
                .CommandText = "Select * From [Order] Where UserID=@UserID"
                .Parameters.Clear()
                .Parameters.AddWithValue("@UserID", UserID)
                .ExecuteNonQuery()
            End With
            DR = CMD.ExecuteReader
            DT.Load(DR)
            gvOrder.DataSource = DT
            gvOrder.DataBind()
        Catch e As SqlException
            MsgBox("An error has occurred " & e.Message.ToString())
        Finally
            Conn.CloseConn()
        End Try
    End Sub

    Public Sub gvOrderLineFill(OrderID As Integer, gvOrderLine As GridView)
        Dim DR As SqlDataReader
        Dim DT As New DataTable
        Try
            Dim CMD As New SqlCommand()
            With CMD
                .Connection = Conn.OpenConn
                .CommandText = "Select V.Make, V.Model, V.Price, OL.* From Vehicle V, OrderLine OL Where OrderID = @OrderID And OL.V_ID = V.V_ID;"
                .Parameters.Clear()
                .Parameters.AddWithValue("@OrderID", OrderID)
                .ExecuteNonQuery()
            End With
            DR = CMD.ExecuteReader
            DT.Load(DR)
            gvOrderLine.DataSource = DT
            gvOrderLine.DataBind()
        Catch e As SqlException
            MsgBox("An error has occurred " & e.Message.ToString())
        Finally
            Conn.CloseConn()
        End Try
    End Sub

End Class
