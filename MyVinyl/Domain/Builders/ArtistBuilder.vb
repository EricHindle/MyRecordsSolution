' Hindleware
' Copyright (c) 2024-26 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports MyVinyl.VinylDataSet

Namespace Domain
    Public Class ArtistBuilder
#Region "properties"
        Private _artistId As Integer
        Private _artistName As String
        Private _artistImage = String.Empty
#End Region
#Region "methods"
        Public Shared Function AnArtist() As ArtistBuilder
            Return New ArtistBuilder
        End Function
        Public Function StartingWithNothing() As ArtistBuilder
            _artistId = -1
            _artistName = String.Empty
            _artistImage = String.Empty
            Return Me
        End Function
        Public Function StartingWith(pRow As ArtistsRow) As ArtistBuilder
            StartingWithNothing()
            If pRow IsNot Nothing Then
                _artistId = pRow.ArtistId
                _artistName = pRow.ArtistName
                If pRow.IsArtistImageFileNull Then
                    _artistImage = String.Empty
                Else
                    _artistImage = pRow.ArtistImageFile
                End If

            End If
            Return Me
        End Function
        Public Function StartingWith(pArtist As Artist) As ArtistBuilder
            _artistId = pArtist.ArtistId
            _artistName = pArtist.ArtistName
            _artistImage = pArtist.ArtistImage
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
        Public Function WithArtistImage(ByVal pArtistImage As String) As ArtistBuilder
            _artistImage = pArtistImage
            Return Me
        End Function
        Public Function Build() As Artist
            Return New Artist(_artistId, _artistName, _artistImage)
        End Function
#End Region
    End Class
End Namespace
