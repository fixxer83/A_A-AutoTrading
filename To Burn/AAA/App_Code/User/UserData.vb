Imports Microsoft.VisualBasic

Public Class UserData

    Private uUserID As Integer
    Public Property UserID() As Integer
        Get
            Return uUserID
        End Get
        Set(ByVal value As Integer)
            uUserID = value
        End Set
    End Property

    Private uName As String
    Public Property Name() As String
        Get
            Return uName
        End Get
        Set(ByVal value As String)
            uName = value
        End Set
    End Property

    Private uSurname As String
    Public Property Surname() As String
        Get
            Return uSurname
        End Get
        Set(ByVal value As String)
            uSurname = value
        End Set
    End Property

    Private uUserName As String
    Public Property UserName() As String
        Get
            Return uUserName
        End Get
        Set(ByVal value As String)
            uUserName = value
        End Set
    End Property

    Private uPassword As String
    Public Property Password() As String
        Get
            Return uPassword
        End Get
        Set(ByVal value As String)
            uPassword = value
        End Set
    End Property

    Private uIsAdmin As Boolean
    Public Property IsAdmin() As Boolean
        Get
            Return uIsAdmin
        End Get
        Set(ByVal value As Boolean)
            uIsAdmin = value
        End Set
    End Property

End Class