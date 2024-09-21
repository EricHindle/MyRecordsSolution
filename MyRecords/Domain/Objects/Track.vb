Imports System.Reflection.Emit

Public Class Track
#Region "properties"
    Private _recordId As Integer
    Private _track As String
    Private _artist As String
    Private _title As String
    Private _year As Integer
    Private _genre As Integer
    Public Property Genre() As Integer
        Get
            Return _genre
        End Get
        Set(ByVal value As Integer)
            _genre = value
        End Set
    End Property
    Public Property Year() As Integer
        Get
            Return _year
        End Get
        Set(ByVal value As Integer)
            _year = value
        End Set
    End Property
    Public Property Title() As String
        Get
            Return _title
        End Get
        Set(ByVal value As String)
            _title = value
        End Set
    End Property
    Public Property Artist() As String
        Get
            Return _artist
        End Get
        Set(ByVal value As String)
            _artist = value
        End Set
    End Property
    Public Property Track() As String
        Get
            Return _track
        End Get
        Set(ByVal value As String)
            _track = value
        End Set
    End Property
    Public Property RecordId() As Integer
        Get
            Return _recordId
        End Get
        Set(ByVal value As Integer)
            _recordId = value
        End Set
    End Property
#End Region
#Region "constructors"
    Private Sub Initialise()
        _recordId = -1
        _track = String.Empty
        _artist = String.Empty
        _title = String.Empty
        _year = -1
        _genre = -1
    End Sub
    Public Sub New()
        Initialise()
    End Sub
    Public Sub New(pId, pTrack, pArtist, pTitle, pYear, pGenre)
        _recordId = pId
        _track = pTrack
        _artist = pArtist
        _title = pTitle
        _year = pYear
        _genre = pGenre
    End Sub
#End Region
End Class
