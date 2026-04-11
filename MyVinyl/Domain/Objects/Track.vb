' Hindleware
' Copyright (c) 2024-26 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Namespace Domain

    Public Class Track
#Region "properties"
        Private _recordId As Integer
        Private _track As String
        Private _title As String
        Private _year As Integer
        Private _genre As Genre
        Private _side As String
        Private _artist As Artist
        Private _chartPos As Integer
        Private _chartDate As DateTime?
        Public Property ChartDate() As DateTime?
            Get
                Return _chartDate
            End Get
            Set(ByVal value As DateTime?)
                _chartDate = value
            End Set
        End Property
        Public Property PeakChartPosition() As Integer
            Get
                Return _chartPos
            End Get
            Set(ByVal value As Integer)
                _chartPos = value
            End Set
        End Property
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
            _chartPos = -1
            _chartDate = New Date(1899, 12, 31)
        End Sub
        Public Sub New()
            Initialise()
        End Sub
        Public Sub New(pId As Integer, pSide As String, pTrack As Integer, pArtist As Artist, pTitle As String, pYear As Integer, pGenre As Genre, pChartPos As Integer, pChartDate As DateTime?)
            _recordId = pId
            _side = pSide
            _track = pTrack
            _artist = pArtist
            _title = pTitle
            _year = pYear
            _genre = pGenre
            _chartPos = pChartPos
            _chartDate = pChartDate
        End Sub
#End Region
#Region "methods"
        Public Function IsExists() As Boolean
            Return _recordId > -1
        End Function
#End Region
    End Class
End Namespace
