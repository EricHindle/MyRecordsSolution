' Hindleware
' Copyright (c) 2024-26 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Namespace Domain

    Public Class RecordLabel
        Implements IComparable
#Region "properties"
        Private _labelId As Integer
        Private _labelName As String
        Public Property LabelName() As String
            Get
                Return _labelName
            End Get
            Set(ByVal value As String)
                _labelName = value
            End Set
        End Property
        Public Property LabelId() As Integer
            Get
                Return _labelId
            End Get
            Set(ByVal value As Integer)
                _labelId = value
            End Set
        End Property
#End Region
#Region "constructors"
        Private Sub Initialise()
            _labelId = -1
            _labelName = String.Empty
        End Sub
        Public Sub New()
            Initialise()
        End Sub
        Public Sub New(pId As Integer, Pname As String)
            _labelId = pId
            _labelName = Pname
        End Sub
#End Region
#Region "methods"
        Public Function IsExists() As Boolean
            Return _labelId > -1
        End Function
        Public Overloads Function CompareTo(ByVal obj As Object) As Integer _
        Implements IComparable.CompareTo
            If obj Is Nothing Then Return 1
            Dim otherLabel As RecordLabel = TryCast(obj, RecordLabel)
            If otherLabel IsNot Nothing Then
                Return Me.LabelName.CompareTo(otherLabel.LabelName)
            Else
                Throw New ArgumentException("Object is not a Record Label")
            End If
        End Function
#End Region
    End Class
End Namespace
