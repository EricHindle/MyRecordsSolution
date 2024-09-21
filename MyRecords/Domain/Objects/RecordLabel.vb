' Hindleware
' Copyright (c) 2024 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class RecordLabel
#Region "properties"
    Private _labelId As Integer
    Private _labelName As String
    Public Property LabelName() As String
        Get
            Return _LabelName
        End Get
        Set(ByVal value As String)
            _LabelName = value
        End Set
    End Property
    Public Property LabelId() As Integer
        Get
            Return _LabelId
        End Get
        Set(ByVal value As Integer)
            _LabelId = value
        End Set
    End Property
#End Region
#Region "constructors"
    Private Sub Initialise()
        _LabelId = -1
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
End Class
