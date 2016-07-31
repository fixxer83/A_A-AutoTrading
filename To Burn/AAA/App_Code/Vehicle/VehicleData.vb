Imports Microsoft.VisualBasic

Public Class VehicleData

    Private vV_ID As String
    Public Property V_ID() As String
        Get
            Return vV_ID
        End Get
        Set(ByVal value As String)
            vV_ID = value
        End Set
    End Property

    Private vYear As String
    Public Property Year() As String
        Get
            Return vYear
        End Get
        Set(ByVal value As String)
            vYear = value
        End Set
    End Property

    Private vMake As String
    Public Property Make() As String
        Get
            Return vMake
        End Get
        Set(ByVal value As String)
            vMake = value
        End Set
    End Property

    Private vModel As String
    Public Property Model() As String
        Get
            Return vModel
        End Get
        Set(ByVal value As String)
            vModel = value
        End Set
    End Property

    Private vFuel As String
    Public Property Fuel() As String
        Get
            Return vFuel
        End Get
        Set(ByVal value As String)
            vFuel = value
        End Set
    End Property

    Private vEngine As String
    Public Property Engine() As String
        Get
            Return vEngine
        End Get
        Set(ByVal value As String)
            vEngine = value
        End Set
    End Property

    Private vTrans As String
    Public Property Transmission() As String
        Get
            Return vTrans
        End Get
        Set(ByVal value As String)
            vTrans = value
        End Set
    End Property

    Private vColor As String
    Public Property Color() As String
        Get
            Return vColor
        End Get
        Set(ByVal value As String)
            vColor = value
        End Set
    End Property

    Private vPrice As Integer
    Public Property Price() As Integer
        Get
            Return vPrice
        End Get
        Set(ByVal value As Integer)
            vPrice = value
        End Set
    End Property

    Private vDesc As String
    Public Property Description() As String
        Get
            Return vDesc
        End Get
        Set(ByVal value As String)
            vDesc = value
        End Set
    End Property

    Private vCond As String
    Public Property Condition() As String
        Get
            Return vCond
        End Get
        Set(ByVal value As String)
            vCond = value
        End Set
    End Property

    Private vMainImage As String
    Public Property MainImage() As String
        Get
            Return vMainImage
        End Get
        Set(ByVal value As String)
            vMainImage = value
        End Set
    End Property
    Private vAltImage As String
    Public Property AlternateImgs() As String
        Get
            Return vAltImage
        End Get
        Set(ByVal value As String)
            vAltImage = value
        End Set
    End Property

    Private vCatID As Integer
    Public Property CatID() As Integer
        Get
            Return vCatID
        End Get
        Set(ByVal value As Integer)
            vCatID = value
        End Set
    End Property

    Private vUserID As Integer
    Public Property UserID() As Integer
        Get
            Return vUserID
        End Get
        Set(ByVal value As Integer)
            vUserID = value
        End Set
    End Property
    Private vSold As Boolean
    Public Property Sold() As Boolean
        Get
            Return vSold
        End Get
        Set(ByVal value As Boolean)
            vSold = value
        End Set
    End Property


End Class
