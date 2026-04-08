' Hindleware
' Copyright (c) 2024-25 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'
Namespace Domain

    Public Class RecordFormat
        Implements IComparable
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
        Public Function IsExists() As Boolean
            Return Not String.IsNullOrEmpty(_formatId)
        End Function

#End Region
#Region "methods"
        Public Overloads Function CompareTo(ByVal obj As Object) As Integer _
        Implements IComparable.CompareTo

            If obj Is Nothing Then Return 1

            Dim otherRecordFormat As RecordFormat = TryCast(obj, RecordFormat)
            If otherRecordFormat IsNot Nothing Then
                Return Me.FormatName.CompareTo(otherRecordFormat.FormatName)
            Else
                Throw New ArgumentException("Object is not a Record Format")
            End If
        End Function
#End Region
    End Class
End Namespace
