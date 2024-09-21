' Hindleware
' Copyright (c) 2024 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class RecordLabelBuilder
    Private _labelId As Integer
    Private _labelName As String
    Public Shared Function ARecordLabel() As RecordLabelBuilder
        Return New RecordLabelBuilder
    End Function

    Public Function StartingWithNothing() As RecordLabelBuilder
        _labelId = -1
        _labelName = String.Empty
        Return Me
    End Function
    Public Function StartingWith(pRow As RecordsDataSet.RecordLabelsRow) As RecordLabelBuilder
        StartingWithNothing()
        If pRow IsNot Nothing Then
            _labelId = pRow.LabelId
            _labelName = pRow.LabelName
        End If
        Return Me
    End Function
    Public Function StartingWith(pRecordLabel As RecordLabel) As RecordLabelBuilder
        _labelId = pRecordLabel.LabelId
        _labelName = pRecordLabel.LabelName
        Return Me
    End Function
    Public Function WithId(ByVal pLabelId As Integer) As RecordLabelBuilder
        _labelId = pLabelId
        Return Me
    End Function
    Public Function WithLabelName(ByVal pLabelName As String) As RecordLabelBuilder
        _labelName = pLabelName
        Return Me
    End Function
    Public Function Build() As RecordLabel
        Return New RecordLabel(_labelId, _labelName)
    End Function
End Class
