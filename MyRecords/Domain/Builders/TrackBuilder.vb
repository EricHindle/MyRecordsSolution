' Hindleware
' Copyright (c) 2024 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class TrackBuilder
    Private _recordId As Integer
    Private _side As String
    Private _track As String
    Private _artist As String
    Private _title As String
    Private _year As Integer
    Private _genre As Genre
    Public Shared Function ATrack() As TrackBuilder
        Return New TrackBuilder
    End Function
    Public Function StartingWithNothing() As TrackBuilder
        _recordId = -1
        _side = String.Empty
        _track = -1
        _artist = String.Empty
        _title = String.Empty
        _year = -1
        _genre = New Genre
        Return Me
    End Function
    Public Function StartingWith(pRow As RecordsDataSet.TracksRow) As TrackBuilder
        StartingWithNothing()
        If pRow IsNot Nothing Then
            _recordId = pRow.RecordId
            _track = pRow.Track
            _side = pRow.Side
            _artist = pRow.Artist
            _title = pRow.Title
            _year = pRow.Year
            _genre = GetGenreFromId(pRow.Genre)
        End If
        Return Me
    End Function
    Public Function StartingWith(pTrack As Track) As TrackBuilder
        _recordId = pTrack.RecordId
        _side = pTrack.Side
        _track = pTrack.Track
        _artist = pTrack.Artist
        _title = pTrack.Title
        _year = pTrack.Year
        _genre = pTrack.Genre
        Return Me
    End Function
    Public Function StartingWith(pTrack As RecordsDataSet.vRecordTracksRow) As TrackBuilder
        _recordId = pTrack.RecordId
        _side = pTrack.Side
        _track = pTrack.Track
        _artist = pTrack.Artist
        _title = pTrack.Title
        _year = pTrack.Year
        _genre = New Genre(0, pTrack.GenreName)
        Return Me
    End Function

    Public Function WithId(ByVal pRecordId As Integer) As TrackBuilder
        _recordId = pRecordId
        Return Me
    End Function
    Public Function WithSide(ByVal pSide As String) As TrackBuilder
        _side = pSide
        Return Me
    End Function
    Public Function WithTrack(ByVal pTrack As String) As TrackBuilder
        _track = pTrack
        Return Me
    End Function
    Public Function WithArtist(ByVal pArtist As String) As TrackBuilder
        _artist = pArtist
        Return Me
    End Function
    Public Function WithTitle(ByVal pTitle As String) As TrackBuilder
        _title = pTitle
        Return Me
    End Function
    Public Function WithYear(ByVal pYear As Integer) As TrackBuilder
        _year = pYear
        Return Me
    End Function
    Public Function WithGenre(ByVal pGenre As Genre) As TrackBuilder
        _genre = pGenre
        Return Me
    End Function
    Public Function Build() As Track
        Return New Track(_recordId, _side, _track, _artist, _title, _year, _genre)
    End Function
End Class
