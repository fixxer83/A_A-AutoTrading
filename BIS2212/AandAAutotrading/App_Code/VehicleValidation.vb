Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class VehicleValidation

    Public Shared Function VehicleVal(ByVal V_ID As String) As VehicleData
        Try
            Dim CMD As New SqlCommand()

            With CMD
                .Connection = Conn.OpenConn
                .CommandText = "SELECT * FROM Vehicle WHERE V_ID = @V_ID"
                .Parameters.AddWithValue("@V_ID", V_ID)
            End With

            Dim DT As New DataTable()
            DT.Load(CMD.ExecuteReader())

            If DT.Rows.Count > 0 Then

                For Each Row As DataRow In DT.Rows

                    Dim VehicleData As New VehicleData()

                    'With VehicleData
                    '    '.uID = CInt(Row.Item("UserID"))
                    '    '.uName = Row.Item("Name").ToString()
                    '    '.uSurname = Row.Item("Surname").ToString()
                    '    '.uUserName = Row.Item("UserName").ToString()

                    '    'If (Row.Item("IsAdmin").ToString() = "True") Then
                    '    '    .uIsAdmin = True
                    '    'ElseIf (Row.Item("IsAdmin").ToString() = "False") Then
                    '    '    .uIsAdmin = False
                    '    'End If
                    '    '.uPwd = Row.Item("Password").ToString()

                    'End With

                    Return VehicleData

                Next

            End If

        Catch Ex As Exception

        Finally
            Conn.CloseConn()
        End Try

        Return Nothing
    End Function

End Class
