Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class CategoryValidation

    Public Shared Function CategoryVal(ByVal cDescription As String) As CategoryData
        Try
            Dim CMD As New SqlCommand()

            With CMD
                .Connection = Conn.OpenConn
                .CommandText = "SELECT * FROM Category WHERE Description = @cDescription"
                .Parameters.AddWithValue("@cDescription", cDescription)
            End With

            Dim DT As New DataTable()
            DT.Load(CMD.ExecuteReader())

            If DT.Rows.Count > 0 Then

                For Each Row As DataRow In DT.Rows

                    Dim CategoryData As New CategoryData()

                    Return CategoryData

                Next

            End If

        Catch e As Exception
            MsgBox("An error has occurred " & e.Message.ToString)
        Finally
            Conn.CloseConn()
        End Try

        Return Nothing
    End Function


    Public Shared Function VehicleCategoryVal(ByVal CatID As Integer) As CategoryData
        Try
            Dim CMD As New SqlCommand()

            With CMD
                .Connection = Conn.OpenConn
                .CommandText = "SELECT V_ID, Make, Model FROM Vehicle WHERE CatID=@CatID"
                .Parameters.AddWithValue("@CatID", CatID)
            End With

            Dim DT As New DataTable()
            DT.Load(CMD.ExecuteReader())

            If DT.Rows.Count > 0 Then

                For Each Row As DataRow In DT.Rows

                    Dim CategoryData As New CategoryData()

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

                    Return CategoryData

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
