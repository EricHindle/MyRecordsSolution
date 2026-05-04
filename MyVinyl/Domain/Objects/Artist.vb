' Hindleware
' Copyright (c) 2024-26 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Namespace Domain

    Public Class Artist
        Implements IComparable
#Region "properties"
        Private _artistId As Integer
        Private _artistName As String
        Private _artistImage As String
        Public Property ArtistImage() As String
            Get
                Return _artistImage
            End Get
            Set(ByVal value As String)
                _artistImage = value
            End Set
        End Property
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
            _artistImage = String.Empty
        End Sub
        Public Sub New()
            Initialise()
        End Sub
        Public Sub New(pId As Integer, pName As String, pImage As String)
            _artistId = pId
            _artistName = pName
            _artistImage = pImage
        End Sub
#End Region
#Region "methods"
        Public Function IsExists() As Boolean
            Return _artistId > -1
        End Function
        Public Overloads Function CompareTo(ByVal obj As Object) As Integer _
        Implements IComparable.CompareTo
            If obj Is Nothing Then Return 1
            Dim otherArtist As Artist = TryCast(obj, Artist)
            If otherArtist IsNot Nothing Then
                Return Me.ArtistName.CompareTo(otherArtist.ArtistName)
            Else
                Throw New ArgumentException("Object is not a Artist")
            End If
        End Function
#End Region
    End Class
End Namespace
