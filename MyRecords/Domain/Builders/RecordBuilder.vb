' Hindleware
' Copyright (c) 2024 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class RecordBuilder
    Private _recordId As Integer
    Private _label As RecordLabel
    Private _format As RecordFormat
    Private _recordNumber As String
    Private _size As Integer
    Private _speed As String
    Private _copies As Integer
    Public Shared Function ARecord() As RecordBuilder
        Return New RecordBuilder
    End Function
    Public Function StartingWithNothing() As RecordBuilder
        _recordId = -1
        _label = New RecordLabel
        _format = New RecordFormat
        _recordNumber = String.Empty
        _size = 0
        _speed = String.Empty
        _copies = 0
        Return Me
    End Function
    Public Function StartingWith(pRow As RecordsDataSet.RecordsRow) As RecordBuilder
        StartingWithNothing()
        If pRow IsNot Nothing Then
            _recordId = pRow.RecordId
            _label = GetLabelbyId(pRow.Label)
            _format = GetFormatbyId(pRow.Format)
            _recordNumber = pRow.RecordNo
            _size = pRow.Size
            _speed = pRow.Speed
            _copies = pRow.Copies
        End If
        Return Me
    End Function
    Public Function StartingWith(pRow As RecordsDataSet.vRecordTracksRow) As RecordBuilder
        StartingWithNothing()
        If pRow IsNot Nothing Then
            _recordId = pRow.RecordId
            _label = GetLabelbyId(pRow.LabelId)
            _format = GetFormatbyId(pRow.Format)
            _recordNumber = pRow.RecordNo
            _size = pRow.Size
            _speed = pRow.Speed
            _copies = pRow.Copies
        End If
        Return Me
    End Function
    Public Function StartingWith(pRecord As Record) As RecordBuilder
        StartingWithNothing()
        If pRecord IsNot Nothing Then
            _recordId = pRecord.RecordId
            _label = pRecord.Label
            _format = pRecord.RecordFormat
            _recordNumber = pRecord.RecordNumber
            _size = pRecord.Size
            _speed = pRecord.Speed
            _copies = pRecord.Copies
        End If
        Return Me
    End Function
    Public Function WithId(ByVal pRecordId As Integer) As RecordBuilder
        _recordId = pRecordId
        Return Me
    End Function
    Public Function WithLabel(ByVal pLabelId As Integer) As RecordBuilder
        _label = GetLabelbyId(pLabelId)
        Return Me
    End Function
    Public Function WithLabel(ByVal pLabel As RecordLabel) As RecordBuilder
        _label = pLabel
        Return Me
    End Function
    Public Function WithFormat(ByVal pFormatId As String) As RecordBuilder
        _format = GetFormatbyId(pFormatId)
        Return Me
    End Function
    Public Function WithFormat(ByVal pFormat As RecordFormat) As RecordBuilder
        _format = pFormat
        Return Me
    End Function
    Public Function WithRecordNumber(ByVal pRecordNumber As String) As RecordBuilder
        _recordNumber = pRecordNumber
        Return Me
    End Function
    Public Function WithSize(ByVal pSize As Integer) As RecordBuilder
        _size = pSize
        Return Me
    End Function
    Public Function WithSpeed(ByVal pSpeed As String) As RecordBuilder
        _speed = pSpeed
        Return Me
    End Function
    Public Function WithCopies(ByVal pCopies As Integer) As RecordBuilder
        _copies = pCopies
        Return Me
    End Function
    Public Function Build() As Record
        Return New Record(_recordId, _label, _format, _recordNumber, _size, _speed, _copies)
    End Function

End Class
