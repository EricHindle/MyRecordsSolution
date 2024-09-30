' Hindleware
' Copyright (c) 2024 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSearch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSearch))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnSearch = New System.Windows.Forms.Button()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CbRecordLabel = New System.Windows.Forms.ComboBox()
        Me.TxtRecNumber = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CbArtists = New System.Windows.Forms.ComboBox()
        Me.CbGenre = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtYear = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtTitle = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DgvRecords = New System.Windows.Forms.DataGridView()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtId = New System.Windows.Forms.TextBox()
        Me.BtnClear = New System.Windows.Forms.Button()
        Me.recId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.recLabel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.recNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.recArtist = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.recSide = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.recTitle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.recLabelId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.recArtistId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DgvRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnSearch)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 365)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(158, 116)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Database Search"
        '
        'BtnSearch
        '
        Me.BtnSearch.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSearch.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnSearch.Location = New System.Drawing.Point(18, 34)
        Me.BtnSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(125, 66)
        Me.BtnSearch.TabIndex = 0
        Me.BtnSearch.Text = "SEARCH"
        Me.BtnSearch.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnClose.Location = New System.Drawing.Point(1062, 476)
        Me.BtnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(136, 32)
        Me.BtnClose.TabIndex = 7
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 210)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 16)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Record Label"
        '
        'CbRecordLabel
        '
        Me.CbRecordLabel.DisplayMember = "LabelName"
        Me.CbRecordLabel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbRecordLabel.FormattingEnabled = True
        Me.CbRecordLabel.Location = New System.Drawing.Point(13, 230)
        Me.CbRecordLabel.Margin = New System.Windows.Forms.Padding(4)
        Me.CbRecordLabel.Name = "CbRecordLabel"
        Me.CbRecordLabel.Size = New System.Drawing.Size(230, 24)
        Me.CbRecordLabel.TabIndex = 4
        Me.CbRecordLabel.ValueMember = "LabelId"
        '
        'TxtRecNumber
        '
        Me.TxtRecNumber.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRecNumber.Location = New System.Drawing.Point(12, 180)
        Me.TxtRecNumber.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtRecNumber.Name = "TxtRecNumber"
        Me.TxtRecNumber.Size = New System.Drawing.Size(178, 23)
        Me.TxtRecNumber.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 160)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 16)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Record Number"
        '
        'CbArtists
        '
        Me.CbArtists.DisplayMember = "ArtistName"
        Me.CbArtists.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbArtists.FormattingEnabled = True
        Me.CbArtists.Location = New System.Drawing.Point(13, 80)
        Me.CbArtists.Margin = New System.Windows.Forms.Padding(4)
        Me.CbArtists.Name = "CbArtists"
        Me.CbArtists.Size = New System.Drawing.Size(274, 24)
        Me.CbArtists.TabIndex = 1
        Me.CbArtists.ValueMember = "ArtistId"
        '
        'CbGenre
        '
        Me.CbGenre.DisplayMember = "GenreName"
        Me.CbGenre.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbGenre.FormattingEnabled = True
        Me.CbGenre.Location = New System.Drawing.Point(12, 330)
        Me.CbGenre.Margin = New System.Windows.Forms.Padding(4)
        Me.CbGenre.Name = "CbGenre"
        Me.CbGenre.Size = New System.Drawing.Size(214, 24)
        Me.CbGenre.TabIndex = 6
        Me.CbGenre.ValueMember = "GenreId"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(10, 310)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 16)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Genre"
        '
        'TxtYear
        '
        Me.TxtYear.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtYear.Location = New System.Drawing.Point(12, 280)
        Me.TxtYear.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtYear.Name = "TxtYear"
        Me.TxtYear.Size = New System.Drawing.Size(87, 23)
        Me.TxtYear.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(10, 260)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 16)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Year"
        '
        'TxtTitle
        '
        Me.TxtTitle.AllowDrop = True
        Me.TxtTitle.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTitle.Location = New System.Drawing.Point(12, 130)
        Me.TxtTitle.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtTitle.Name = "TxtTitle"
        Me.TxtTitle.Size = New System.Drawing.Size(350, 23)
        Me.TxtTitle.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 110)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 16)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Title"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(10, 60)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 16)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Artist"
        '
        'DgvRecords
        '
        Me.DgvRecords.AllowUserToAddRows = False
        Me.DgvRecords.AllowUserToDeleteRows = False
        Me.DgvRecords.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvRecords.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.recId, Me.recLabel, Me.recNumber, Me.recArtist, Me.recSide, Me.recTitle, Me.recLabelId, Me.recArtistId})
        Me.DgvRecords.Location = New System.Drawing.Point(385, 12)
        Me.DgvRecords.MultiSelect = False
        Me.DgvRecords.Name = "DgvRecords"
        Me.DgvRecords.ReadOnly = True
        Me.DgvRecords.RowHeadersVisible = False
        Me.DgvRecords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvRecords.Size = New System.Drawing.Size(812, 454)
        Me.DgvRecords.TabIndex = 9
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 512)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1211, 22)
        Me.StatusStrip1.TabIndex = 8
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'LblStatus
        '
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.LblStatus.Size = New System.Drawing.Size(6, 17)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 16)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Id"
        '
        'TxtId
        '
        Me.TxtId.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtId.Location = New System.Drawing.Point(12, 33)
        Me.TxtId.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtId.Name = "TxtId"
        Me.TxtId.Size = New System.Drawing.Size(87, 23)
        Me.TxtId.TabIndex = 0
        '
        'BtnClear
        '
        Me.BtnClear.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClear.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnClear.Location = New System.Drawing.Point(295, 28)
        Me.BtnClear.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(67, 32)
        Me.BtnClear.TabIndex = 18
        Me.BtnClear.Text = "Clear"
        Me.BtnClear.UseVisualStyleBackColor = True
        '
        'recId
        '
        Me.recId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.recId.HeaderText = "Id"
        Me.recId.Name = "recId"
        Me.recId.ReadOnly = True
        Me.recId.Width = 40
        '
        'recLabel
        '
        Me.recLabel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.recLabel.HeaderText = "Label"
        Me.recLabel.Name = "recLabel"
        Me.recLabel.ReadOnly = True
        Me.recLabel.Width = 150
        '
        'recNumber
        '
        Me.recNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.recNumber.HeaderText = "Number"
        Me.recNumber.Name = "recNumber"
        Me.recNumber.ReadOnly = True
        '
        'recArtist
        '
        Me.recArtist.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.recArtist.HeaderText = "Artist"
        Me.recArtist.Name = "recArtist"
        Me.recArtist.ReadOnly = True
        Me.recArtist.Width = 200
        '
        'recSide
        '
        Me.recSide.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.recSide.HeaderText = "Side"
        Me.recSide.Name = "recSide"
        Me.recSide.ReadOnly = True
        Me.recSide.Width = 40
        '
        'recTitle
        '
        Me.recTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.recTitle.HeaderText = "Title"
        Me.recTitle.Name = "recTitle"
        Me.recTitle.ReadOnly = True
        '
        'recLabelId
        '
        Me.recLabelId.HeaderText = "Lbl Id"
        Me.recLabelId.Name = "recLabelId"
        Me.recLabelId.ReadOnly = True
        Me.recLabelId.Visible = False
        '
        'recArtistId
        '
        Me.recArtistId.HeaderText = "Art Id"
        Me.recArtistId.Name = "recArtistId"
        Me.recArtistId.ReadOnly = True
        Me.recArtistId.Visible = False
        '
        'FrmSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1211, 534)
        Me.Controls.Add(Me.BtnClear)
        Me.Controls.Add(Me.TxtId)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.DgvRecords)
        Me.Controls.Add(Me.CbArtists)
        Me.Controls.Add(Me.CbGenre)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtYear)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtTitle)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CbRecordLabel)
        Me.Controls.Add(Me.TxtRecNumber)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmSearch"
        Me.Text = "Search"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DgvRecords, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BtnSearch As Button
    Friend WithEvents BtnClose As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents CbRecordLabel As ComboBox
    Friend WithEvents TxtRecNumber As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents CbArtists As ComboBox
    Friend WithEvents CbGenre As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TxtYear As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtTitle As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents DgvRecords As DataGridView
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents LblStatus As ToolStripStatusLabel
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtId As TextBox
    Friend WithEvents BtnClear As Button
    Friend WithEvents recId As DataGridViewTextBoxColumn
    Friend WithEvents recLabel As DataGridViewTextBoxColumn
    Friend WithEvents recNumber As DataGridViewTextBoxColumn
    Friend WithEvents recArtist As DataGridViewTextBoxColumn
    Friend WithEvents recSide As DataGridViewTextBoxColumn
    Friend WithEvents recTitle As DataGridViewTextBoxColumn
    Friend WithEvents recLabelId As DataGridViewTextBoxColumn
    Friend WithEvents recArtistId As DataGridViewTextBoxColumn
End Class
