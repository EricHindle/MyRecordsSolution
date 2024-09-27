' Hindleware
' Copyright (c) 2024 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class Track
#Region "properties"
    Private _recordId As Integer
    Private _track As String
    Private _title As String
    Private _year As Integer
    Private _genre As Genre
    Private _side As String
    Private _artist As Artist
    Public Property Artist() As Artist
        Get
            Return _artist
        End Get
        Set(ByVal value As Artist)
            _artist = value
        End Set
    End Property
    Public Property Side() As String
        Get
            Return _side
        End Get
        Set(ByVal value As String)
            _side = value
        End Set
    End Property
    Public Property Genre() As Genre
        Get
            Return _genre
        End Get
        Set(ByVal value As Genre)
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
    Public Property Track() As Integer
        Get
            Return _track
        End Get
        Set(ByVal value As Integer)
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
        _track = -1
        _side = String.Empty
        _artist = New Artist
        _title = String.Empty
        _year = -1
        _genre = New Genre
    End Sub
    Public Sub New()
        Initialise()
    End Sub
    Public Sub New(pId As Integer, pSide As String, pTrack As Integer, pArtist As Artist, pTitle As String, pYear As Integer, pGenre As Genre)
        _recordId = pId
        _side = pSide
        _track = pTrack
        _artist = pArtist
        _title = pTitle
        _year = pYear
        _genre = pGenre
    End Sub
    Public Function IsExists() As Boolean
        Return _recordId > -1
    End Function
#End Region
End Class
