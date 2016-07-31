Imports Microsoft.VisualBasic

Public Class UserData

    Private UserID As Integer
    Public Property uID() As Integer
        Get
            Return UserID
        End Get
        Set(ByVal value As Integer)
            UserID = value
        End Set
    End Property

    Private Name As String
    Public Property uName() As String
        Get
            Return Name
        End Get
        Set(ByVal value As String)
            Name = value
        End Set
    End Property

    Private Surname As String
    Public Property uSurname() As String
        Get
            Return Surname
        End Get
        Set(ByVal value As String)
            Surname = value
        End Set
    End Property

    Private UserName As String
    Public Property uUserName() As String
        Get
            Return UserName
        End Get
        Set(ByVal value As String)
            UserName = value
        End Set
    End Property

    Private Password As String
    Public Property uPwd() As String
        Get
            Return Password
        End Get
        Set(ByVal value As String)
            Password = value
        End Set
    End Property

    Private IsAdmin As Boolean
    Public Property uIsAdmin() As Boolean
        Get
            Return IsAdmin
        End Get
        Set(ByVal value As Boolean)
            IsAdmin = value
        End Set
    End Property

End Class