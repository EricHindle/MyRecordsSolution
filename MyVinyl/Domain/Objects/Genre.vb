' Hindleware
' Copyright (c) 2024-26 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Namespace Domain

    Public Class Genre
        Implements IComparable
#Region "properties"
        Private _genreId As Integer
        Private _genreName As String
        Public Property GenreName() As String
            Get
                Return _genreName
            End Get
            Set(ByVal value As String)
                _genreName = value
            End Set
        End Property
        Public Property GenreId() As Integer
            Get
                Return _genreId
            End Get
            Set(ByVal value As Integer)
                _genreId = value
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
#Region "methods"
        Public Function IsExists() As Boolean
            Return _genreId > -1
        End Function
        Public Overloads Function CompareTo(ByVal obj As Object) As Integer _
        Implements IComparable.CompareTo

            If obj Is Nothing Then Return 1

            Dim otherGenre As Genre = TryCast(obj, Genre)
            If otherGenre IsNot Nothing Then
                Return Me.GenreName.CompareTo(otherGenre.GenreName)
            Else
                Throw New ArgumentException("Object is not a Genre")
            End If
        End Function
#End Region
    End Class
End Namespace
