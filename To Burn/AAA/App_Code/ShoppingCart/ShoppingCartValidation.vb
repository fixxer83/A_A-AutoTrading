Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class ShoppingCartValidation
    Public Shared Function ShoppingCartVehicleVal(ByVal V_ID As String) As ShoppingCartData
        Try
            Dim CMD As New SqlCommand()

            With CMD
                .Connection = Conn.OpenConn
                .CommandText = "SELECT * FROM ShoppingCart WHERE V_ID=@V_ID"
                .Parameters.AddWithValue("@V_ID", V_ID)
            End With

            Dim DT As New DataTable()
            DT.Load(CMD.ExecuteReader())

            If DT.Rows.Count > 0 Then

                For Each Row As DataRow In DT.Rows

                    Dim ShoppingCartData As New ShoppingCartData()

                    Return ShoppingCartData

                Next

            End If

        Catch e As Exception
            MsgBox("An error has occurred " & e.Message.ToString)
        Finally
            Conn.CloseConn()
        End Try

        Return Nothing
    End Function

    Public Shared Function ValShopCartItems() As ShoppingCartData
        Try
            Dim CMD As New SqlCommand()

            With CMD
                .Connection = Conn.OpenConn
                .CommandText = "SELECT * FROM ShoppingCart;"
            End With

            Dim DT As New DataTable()
            DT.Load(CMD.ExecuteReader())

            If DT.Rows.Count > 0 Then

                For Each Row As DataRow In DT.Rows

                    Dim ShoppingCartData As New ShoppingCartData()

                    Return ShoppingCartData

                Next

            End If

        Catch e As Exception
            MsgBox("An error has occurred " & e.Message.ToString)
        Finally
            Conn.CloseConn()
        End Try

        Return Nothing
    End Function

End Class
