Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar

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
        _LabelId = String.Empty
    End Sub
    Public Sub New()
        Initialise()
    End Sub
#End Region
End Class
