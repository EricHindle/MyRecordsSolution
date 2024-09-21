' Hindleware
' Copyright (c) 2024 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class GenreBuilder
    Private _genreId As Integer
    Private _genreName As String
    Public Shared Function AGenre() As GenreBuilder
        Return New GenreBuilder
    End Function
    Public Function StartingWithNothing() As GenreBuilder
        _genreId = -1
        _genreName = String.Empty
        Return Me
    End Function
    Public Function StartingWith(pRow As RecordsDataSet.MusicGenreRow) As GenreBuilder
        StartingWithNothing()
        If pRow IsNot Nothing Then
            _genreId = pRow.GenreId
            _genreName = pRow.GenreName
        End If
        Return Me
    End Function
    Public Function StartingWith(pGenre As Genre) As GenreBuilder
        _genreId = pGenre.GenreId
        _genreName = pGenre.GenreName
        Return Me
    End Function
    Public Function WithId(ByVal pGenreId As Integer) As GenreBuilder
        _genreId = pGenreId
        Return Me
    End Function
    Public Function WithGenreName(ByVal pGenreName As String) As GenreBuilder
        _genreName = pGenreName
        Return Me
    End Function
    Public Function Build() As Genre
        Return New Genre(_genreId, _genreName)
    End Function

End Class
