' Hindleware
' Copyright (c) 2024 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class Artist
#Region "properties"
    Private _artistId As Integer
    Private _artistName As String
    Public Property ArtistName() As String
        Get
            Return _artistName
        End Get
        Set(ByVal value As String)
            _artistName = value
        End Set
    End Property
    Public Property ArtistId() As Integer
        Get
            Return _artistId
        End Get
        Set(ByVal value As Integer)
            _artistId = value
        End Set
    End Property
#End Region
#Region "constructors"
    Private Sub Initialise()
        _artistId = -1
        _artistName = String.Empty
    End Sub
    Public Sub New()
        Initialise()
    End Sub
    Public Sub New(pId As Integer, pName As String)
        _artistId = pId
        _artistName = pName
    End Sub
    Public Function IsExists() As Boolean
        Return _artistId > -1
    End Function
#End Region
End Class
