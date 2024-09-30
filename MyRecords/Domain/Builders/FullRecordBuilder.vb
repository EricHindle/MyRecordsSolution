' Hindleware
' Copyright (c) 2024 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class FullRecordBuilder
    Private _record As Record
    Private _tracks As List(Of Track)

    Public Shared Function AFullRecord() As FullRecordBuilder
        Return New FullRecordBuilder
    End Function
    Private Sub Initialise()
        _record = New Record
        _tracks = New List(Of Track)
    End Sub
    Public Function StartingWithNothing() As FullRecordBuilder
        Initialise()
        Return Me
    End Function
    Public Sub WithRecord(pRecord As Record)
        _record = pRecord
    End Sub
    Public Sub WithTracks(pTracks As List(Of Track))
        _tracks = pTracks
    End Sub
    Public Sub WithTracks(pTrack As Track)
        _tracks.Add(pTrack)
    End Sub
    Public Function Build()
        Return New FullRecord(_record, _tracks)
    End Function
    Public Function StartingWith(pRecordId As Integer) As FullRecordBuilder
        Initialise()
        _record = GetRecordFromId(pRecordId)
        If _record.IsExists Then
            _tracks = GetTracksForRecord(pRecordId)
        End If
        Return Me
    End Function
    Public Function StartingWith(pRecordId As Integer, pSide As String, pTrackNo As Integer) As FullRecordBuilder
        Initialise()
        _record = GetRecordFromId(pRecordId)
        If _record.IsExists Then
            _tracks.Add(GetTrackForKey(pRecordId, pSide, pTrackNo))
        End If
        Return Me
    End Function
End Class
