' Hindleware
' Copyright (c) 2024 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTrackInput
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.LblRecordId = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblRecordNo = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Rb2 = New System.Windows.Forms.RadioButton()
        Me.Rb1 = New System.Windows.Forms.RadioButton()
        Me.RbB = New System.Windows.Forms.RadioButton()
        Me.RbAA = New System.Windows.Forms.RadioButton()
        Me.RbA = New System.Windows.Forms.RadioButton()
        Me.NudTrackNo = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtArtist = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtTitle = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtYear = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.CbGenre = New System.Windows.Forms.ComboBox()
        Me.MusicGenreBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RecordsDataSet = New MyRecords.RecordsDataSet()
        Me.MusicGenreTableAdapter = New MyRecords.RecordsDataSetTableAdapters.MusicGenreTableAdapter()
        Me.BtnNextTrack = New System.Windows.Forms.Button()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnSaveTrack = New System.Windows.Forms.Button()
        Me.BtnAddGenre = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NudTrackNo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.MusicGenreBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RecordsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblRecordId
        '
        Me.LblRecordId.AutoSize = True
        Me.LblRecordId.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRecordId.Location = New System.Drawing.Point(135, 27)
        Me.LblRecordId.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblRecordId.Name = "LblRecordId"
        Me.LblRecordId.Size = New System.Drawing.Size(21, 18)
        Me.LblRecordId.TabIndex = 10
        Me.LblRecordId.Text = "-1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(29, 27)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 17)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Record Id"
        '
        'LblRecordNo
        '
        Me.LblRecordNo.AutoSize = True
        Me.LblRecordNo.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRecordNo.Location = New System.Drawing.Point(311, 27)
        Me.LblRecordNo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblRecordNo.Name = "LblRecordNo"
        Me.LblRecordNo.Size = New System.Drawing.Size(56, 18)
        Me.LblRecordNo.TabIndex = 12
        Me.LblRecordNo.Text = "999999"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(199, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 17)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Record Number"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(228, 78)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 17)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Track #"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Rb2)
        Me.GroupBox1.Controls.Add(Me.Rb1)
        Me.GroupBox1.Controls.Add(Me.RbB)
        Me.GroupBox1.Controls.Add(Me.RbAA)
        Me.GroupBox1.Controls.Add(Me.RbA)
        Me.GroupBox1.Location = New System.Drawing.Point(32, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(145, 91)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Side"
        '
        'Rb2
        '
        Me.Rb2.AutoSize = True
        Me.Rb2.Location = New System.Drawing.Point(58, 57)
        Me.Rb2.Name = "Rb2"
        Me.Rb2.Size = New System.Drawing.Size(34, 21)
        Me.Rb2.TabIndex = 4
        Me.Rb2.Text = "2"
        Me.Rb2.UseVisualStyleBackColor = True
        '
        'Rb1
        '
        Me.Rb1.AutoSize = True
        Me.Rb1.Location = New System.Drawing.Point(18, 57)
        Me.Rb1.Name = "Rb1"
        Me.Rb1.Size = New System.Drawing.Size(34, 21)
        Me.Rb1.TabIndex = 3
        Me.Rb1.Text = "1"
        Me.Rb1.UseVisualStyleBackColor = True
        '
        'RbB
        '
        Me.RbB.AutoSize = True
        Me.RbB.Location = New System.Drawing.Point(106, 20)
        Me.RbB.Name = "RbB"
        Me.RbB.Size = New System.Drawing.Size(34, 21)
        Me.RbB.TabIndex = 2
        Me.RbB.Text = "B"
        Me.RbB.UseVisualStyleBackColor = True
        '
        'RbAA
        '
        Me.RbAA.AutoSize = True
        Me.RbAA.Location = New System.Drawing.Point(58, 20)
        Me.RbAA.Name = "RbAA"
        Me.RbAA.Size = New System.Drawing.Size(42, 21)
        Me.RbAA.TabIndex = 1
        Me.RbAA.Text = "AA"
        Me.RbAA.UseVisualStyleBackColor = True
        '
        'RbA
        '
        Me.RbA.AutoSize = True
        Me.RbA.Checked = True
        Me.RbA.Location = New System.Drawing.Point(18, 20)
        Me.RbA.Name = "RbA"
        Me.RbA.Size = New System.Drawing.Size(34, 21)
        Me.RbA.TabIndex = 0
        Me.RbA.TabStop = True
        Me.RbA.Text = "A"
        Me.RbA.UseVisualStyleBackColor = True
        '
        'NudTrackNo
        '
        Me.NudTrackNo.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudTrackNo.Location = New System.Drawing.Point(303, 73)
        Me.NudTrackNo.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudTrackNo.Name = "NudTrackNo"
        Me.NudTrackNo.Size = New System.Drawing.Size(64, 27)
        Me.NudTrackNo.TabIndex = 1
        Me.NudTrackNo.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 160)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 17)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Artist"
        '
        'TxtArtist
        '
        Me.TxtArtist.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtArtist.Location = New System.Drawing.Point(32, 180)
        Me.TxtArtist.Name = "TxtArtist"
        Me.TxtArtist.Size = New System.Drawing.Size(335, 27)
        Me.TxtArtist.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(29, 222)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 17)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Title"
        '
        'TxtTitle
        '
        Me.TxtTitle.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTitle.Location = New System.Drawing.Point(32, 242)
        Me.TxtTitle.Name = "TxtTitle"
        Me.TxtTitle.Size = New System.Drawing.Size(335, 27)
        Me.TxtTitle.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(29, 284)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 17)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Year"
        '
        'TxtYear
        '
        Me.TxtYear.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtYear.Location = New System.Drawing.Point(32, 304)
        Me.TxtYear.Name = "TxtYear"
        Me.TxtYear.Size = New System.Drawing.Size(75, 27)
        Me.TxtYear.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(29, 346)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 17)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Genre"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 522)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(401, 22)
        Me.StatusStrip1.TabIndex = 18
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'LblStatus
        '
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.LblStatus.Size = New System.Drawing.Size(6, 17)
        '
        'CbGenre
        '
        Me.CbGenre.DataSource = Me.MusicGenreBindingSource
        Me.CbGenre.DisplayMember = "GenreName"
        Me.CbGenre.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbGenre.FormattingEnabled = True
        Me.CbGenre.Location = New System.Drawing.Point(32, 366)
        Me.CbGenre.Name = "CbGenre"
        Me.CbGenre.Size = New System.Drawing.Size(201, 27)
        Me.CbGenre.TabIndex = 5
        Me.CbGenre.ValueMember = "GenreId"
        '
        'MusicGenreBindingSource
        '
        Me.MusicGenreBindingSource.DataMember = "MusicGenre"
        Me.MusicGenreBindingSource.DataSource = Me.RecordsDataSet
        '
        'RecordsDataSet
        '
        Me.RecordsDataSet.DataSetName = "RecordsDataSet"
        Me.RecordsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'MusicGenreTableAdapter
        '
        Me.MusicGenreTableAdapter.ClearBeforeFill = True
        '
        'BtnNextTrack
        '
        Me.BtnNextTrack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnNextTrack.BackColor = System.Drawing.Color.White
        Me.BtnNextTrack.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnNextTrack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNextTrack.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNextTrack.ForeColor = System.Drawing.Color.Black
        Me.BtnNextTrack.Location = New System.Drawing.Point(160, 432)
        Me.BtnNextTrack.Name = "BtnNextTrack"
        Me.BtnNextTrack.Size = New System.Drawing.Size(78, 78)
        Me.BtnNextTrack.TabIndex = 7
        Me.BtnNextTrack.Text = "Next Track"
        Me.BtnNextTrack.UseVisualStyleBackColor = False
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.BackColor = System.Drawing.Color.White
        Me.BtnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClose.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.BtnClose.Location = New System.Drawing.Point(304, 432)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(78, 78)
        Me.BtnClose.TabIndex = 8
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'BtnSaveTrack
        '
        Me.BtnSaveTrack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnSaveTrack.BackColor = System.Drawing.Color.White
        Me.BtnSaveTrack.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnSaveTrack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSaveTrack.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSaveTrack.ForeColor = System.Drawing.Color.Black
        Me.BtnSaveTrack.Location = New System.Drawing.Point(33, 432)
        Me.BtnSaveTrack.Name = "BtnSaveTrack"
        Me.BtnSaveTrack.Size = New System.Drawing.Size(78, 78)
        Me.BtnSaveTrack.TabIndex = 6
        Me.BtnSaveTrack.Text = "Save Track"
        Me.BtnSaveTrack.UseVisualStyleBackColor = False
        '
        'BtnAddGenre
        '
        Me.BtnAddGenre.BackColor = System.Drawing.Color.White
        Me.BtnAddGenre.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnAddGenre.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtnAddGenre.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAddGenre.ForeColor = System.Drawing.Color.Black
        Me.BtnAddGenre.Location = New System.Drawing.Point(239, 362)
        Me.BtnAddGenre.Name = "BtnAddGenre"
        Me.BtnAddGenre.Size = New System.Drawing.Size(65, 32)
        Me.BtnAddGenre.TabIndex = 19
        Me.BtnAddGenre.Text = "Add"
        Me.BtnAddGenre.UseVisualStyleBackColor = False
        '
        'FrmTrackInput
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(401, 544)
        Me.Controls.Add(Me.BtnAddGenre)
        Me.Controls.Add(Me.BtnNextTrack)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.BtnSaveTrack)
        Me.Controls.Add(Me.CbGenre)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtYear)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtTitle)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtArtist)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NudTrackNo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LblRecordNo)
        Me.Controls.Add(Me.LblRecordId)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmTrackInput"
        Me.Text = "Input Tracks"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NudTrackNo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.MusicGenreBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RecordsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LblRecordId As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LblRecordNo As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Rb2 As RadioButton
    Friend WithEvents Rb1 As RadioButton
    Friend WithEvents RbB As RadioButton
    Friend WithEvents RbAA As RadioButton
    Friend WithEvents RbA As RadioButton
    Friend WithEvents NudTrackNo As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtArtist As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TxtTitle As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtYear As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents LblStatus As ToolStripStatusLabel
    Friend WithEvents CbGenre As ComboBox
    Friend WithEvents RecordsDataSet As RecordsDataSet
    Friend WithEvents MusicGenreBindingSource As BindingSource
    Friend WithEvents MusicGenreTableAdapter As RecordsDataSetTableAdapters.MusicGenreTableAdapter
    Friend WithEvents BtnNextTrack As Button
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnSaveTrack As Button
    Friend WithEvents BtnAddGenre As Button
End Class
