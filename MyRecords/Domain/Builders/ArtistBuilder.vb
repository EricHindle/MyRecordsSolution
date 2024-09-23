' Hindleware
' Copyright (c) 2024 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class ArtistBuilder
    Private _artistId As Integer
    Private _artistName As String
    Public Shared Function AnArtist() As ArtistBuilder
        Return New ArtistBuilder
    End Function

    Public Function StartingWithNothing() As ArtistBuilder
        _artistId = -1
        _artistName = String.Empty
        Return Me
    End Function
    Public Function StartingWith(pRow As RecordsDataSet.ArtistsRow) As ArtistBuilder
        StartingWithNothing()
        If pRow IsNot Nothing Then
            _artistId = pRow.ArtistId
            _artistName = pRow.ArtistName
        End If
        Return Me
    End Function
    Public Function StartingWith(pArtist As Artist) As ArtistBuilder
        _artistId = pArtist.ArtistId
        _artistName = pArtist.ArtistName
        Return Me
    End Function
    Public Function WithId(ByVal pArtistId As Integer) As ArtistBuilder
        _artistId = pArtistId
        Return Me
    End Function
    Public Function WithArtistName(ByVal pArtistName As String) As ArtistBuilder
        _artistName = pArtistName
        Return Me
    End Function
    Public Function Build() As Artist
        Return New Artist(_artistId, _artistName)
    End Function

End Class
