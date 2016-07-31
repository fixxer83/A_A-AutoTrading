Imports Microsoft.VisualBasic

Public Class ShoppingCartData
    Private sSessionDate As DateTime
    Public Property SessionDate() As DateTime
        Get
            Return sSessionDate
        End Get
        Set(ByVal value As DateTime)
            sSessionDate = value
        End Set
    End Property

    Private sUserID As Integer
    Public Property UserID() As Integer
        Get
            Return sUserID
        End Get
        Set(ByVal value As Integer)
            sUserID = value
        End Set
    End Property

    Private sV_ID As String
    Public Property V_ID() As String
        Get
            Return sV_ID
        End Get
        Set(ByVal value As String)
            sV_ID = value
        End Set
    End Property

    Private sQuantity As Integer
    Public Property Quantity() As Integer
        Get
            Return sQuantity
        End Get
        Set(ByVal value As Integer)
            sQuantity = value
        End Set
    End Property


End Class
