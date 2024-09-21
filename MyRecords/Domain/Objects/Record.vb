' Hindleware
' Copyright (c) 2024 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class Record
#Region "properties"
    Private _recordId As Integer
    Private _label As RecordLabel
    Private _format As RecordFormat
    Private _recordNumber As String
    Private _size As Integer
    Private _speed As String
    Public Property Speed() As String
        Get
            Return _speed
        End Get
        Set(ByVal value As String)
            _speed = value
        End Set
    End Property
    Public Property Size() As Integer
        Get
            Return _size
        End Get
        Set(ByVal value As Integer)
            _size = value
        End Set
    End Property
    Public Property RecordNumber() As String
        Get
            Return _recordNumber
        End Get
        Set(ByVal value As String)
            _recordNumber = value
        End Set
    End Property
    Public Property RecordFormat() As RecordFormat
        Get
            Return _format
        End Get
        Set(ByVal value As RecordFormat)
            _format = value
        End Set
    End Property
    Public Property Label() As RecordLabel
        Get
            Return _label
        End Get
        Set(ByVal value As RecordLabel)
            _label = value
        End Set
    End Property

    Public Property RecordId() As Integer
        Get
            Return _recordId
        End Get
        Set(ByVal value As Integer)
            _recordId = value
        End Set
    End Property
#End Region
#Region "constructors"
    Private Sub Initialise()
        _recordId = -1
        _label = New RecordLabel
        _format = New RecordFormat
        _recordNumber = ""
        _size = 0
        _speed = ""
    End Sub
    Public Sub New()
        Initialise()
    End Sub
    Public Sub New(pId As Integer, pLabel As RecordLabel, pFormat As RecordFormat, pNumber As Integer, pSize As Integer, pSpeed As String)
        _recordId = pId
        _label = pLabel
        _format = pFormat
        _recordNumber = pNumber
        _size = pSize
        _speed = pSpeed
    End Sub
#End Region
End Class
