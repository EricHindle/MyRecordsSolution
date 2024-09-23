' Hindleware
' Copyright (c) 2024 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class RecordFormat
#Region "properties"
    Private _formatId As String
    Private _formatName As String
    Public Property FormatName() As String
        Get
            Return _formatName
        End Get
        Set(ByVal value As String)
            _formatName = value
        End Set
    End Property
    Public Property FormatId() As String
        Get
            Return _formatId
        End Get
        Set(ByVal value As String)
            _formatId = value
        End Set
    End Property
#End Region
#Region "constructors"
    Private Sub Initialise()
        _formatId = String.Empty
        _formatName = String.Empty
    End Sub
    Public Sub New()
        Initialise()
    End Sub
    Public Sub New(pId As String, Pname As String)
        _formatId = pId
        _formatName = Pname
    End Sub
#End Region
End Class
