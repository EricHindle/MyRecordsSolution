' Hindleware
' Copyright (c) 2024 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class Genre
#Region "properties"
    Private _genreId As Integer
    Private _genreName As String
    Public Property GenreName() As String
        Get
            Return _GenreName
        End Get
        Set(ByVal value As String)
            _GenreName = value
        End Set
    End Property
    Public Property GenreId() As Integer
        Get
            Return _GenreId
        End Get
        Set(ByVal value As Integer)
            _GenreId = value
        End Set
    End Property
#End Region
#Region "constructors"
    Private Sub Initialise()
        _genreId = -1
        _genreName = String.Empty
    End Sub
    Public Sub New()
        Initialise()
    End Sub
    Public Sub New(pId As Integer, Pname As String)
        _genreId = pId
        _genreName = Pname
    End Sub
#End Region
End Class
