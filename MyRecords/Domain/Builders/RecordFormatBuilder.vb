' Hindleware
' Copyright (c) 2024 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class RecordFormatBuilder
    Private _formatId As String
    Private _formatName As String
    Public Shared Function ARecordFormat() As RecordFormatBuilder
        Return New RecordFormatBuilder
    End Function
    Public Function StartingWithNothing() As RecordFormatBuilder
        _formatId = -1
        _formatName = String.Empty
        Return Me
    End Function
    Public Function StartingWith(pRow As RecordsDataSet.RecordFormatRow) As RecordFormatBuilder
        StartingWithNothing()
        If pRow IsNot Nothing Then
            _formatId = pRow.FormatId
            _formatName = pRow.FormatName
        End If
        Return Me
    End Function
    Public Function StartingWith(pRecordFormat As RecordFormat) As RecordFormatBuilder
        _formatId = pRecordFormat.FormatId
        _formatName = pRecordFormat.FormatName
        Return Me
    End Function
    Public Function WithId(ByVal pFormatId As Integer) As RecordFormatBuilder
        _formatId = pFormatId
        Return Me
    End Function
    Public Function WithFormatName(ByVal pFormatName As String) As RecordFormatBuilder
        _formatName = pFormatName
        Return Me
    End Function
    Public Function Build() As RecordFormat
        Return New RecordFormat(_formatId, _formatName)
    End Function

End Class
