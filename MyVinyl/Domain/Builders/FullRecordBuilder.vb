' Hindleware
' Copyright (c) 2024-26 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Namespace Domain

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
        Public Function WithRecord(pRecord As Record) As FullRecordBuilder
            _record = pRecord
            Return Me
        End Function
        Public Function WithTracks(pTracks As List(Of Track)) As FullRecordBuilder
            _tracks = pTracks
            Return Me
        End Function
        Public Function WithTracks(pTrack As Track) As FullRecordBuilder
            _tracks.Add(pTrack)
            Return Me
        End Function
        Public Function Build() As FullRecord
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
End Namespace
