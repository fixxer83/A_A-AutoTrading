Imports Microsoft.VisualBasic

Public Class CategoryData
    'Getter and Setter Class for the Category table
    Private cCategoryID As Integer
    Public Property CategoryID() As Integer
        Get
            Return cCategoryID
        End Get
        Set(ByVal value As Integer)
            cCategoryID = value
        End Set
    End Property

    Private cDescription As String
    Public Property Description() As String
        Get
            Return cDescription
        End Get
        Set(ByVal value As String)
            cDescription = value
        End Set
    End Property

    Private cDateCreated As Date
    Public Property DateCreated() As Date
        Get
            Return cDateCreated
        End Get
        Set(ByVal value As Date)
            cDateCreated = value
        End Set
    End Property
End Class
