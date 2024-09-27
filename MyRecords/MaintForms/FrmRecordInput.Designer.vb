<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmRecordInput
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRecordInput))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblRecordId = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CbRecordFormat = New System.Windows.Forms.ComboBox()
        Me.RecordFormatBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RecordsDataSet = New MyRecords.RecordsDataSet()
        Me.ArtistsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MusicGenreBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RecordFormatTableAdapter = New MyRecords.RecordsDataSetTableAdapters.RecordFormatTableAdapter()
        Me.ArtistsTableAdapter = New MyRecords.RecordsDataSetTableAdapters.ArtistsTableAdapter()
        Me.BtnAdd = New System.Windows.Forms.Button()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CbRecordLabel = New System.Windows.Forms.ComboBox()
        Me.RecordLabelsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RecordLabelsTableAdapter = New MyRecords.RecordsDataSetTableAdapters.RecordLabelsTableAdapter()
        Me.MusicGenreTableAdapter = New MyRecords.RecordsDataSetTableAdapters.MusicGenreTableAdapter()
        Me.BtnAddFormat = New System.Windows.Forms.Button()
        Me.BtnAddLabel = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtRecNumber = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RbNoSize = New System.Windows.Forms.RadioButton()
        Me.Rb12 = New System.Windows.Forms.RadioButton()
        Me.Rb7 = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RbNoSpeed = New System.Windows.Forms.RadioButton()
        Me.Rb78 = New System.Windows.Forms.RadioButton()
        Me.Rb33 = New System.Windows.Forms.RadioButton()
        Me.Rb45 = New System.Windows.Forms.RadioButton()
        Me.DgvTracks = New System.Windows.Forms.DataGridView()
        Me.trkSide = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.trkTrack = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.trkArtist = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.trkYear = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.trkTitle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.trkGenre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BtnNext = New System.Windows.Forms.Button()
        Me.Status = New System.Windows.Forms.StatusStrip()
        Me.LblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.DgvRecords = New System.Windows.Forms.DataGridView()
        Me.recId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.recFormat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.recLabel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.recNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.recArtist = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.NudCopies = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.BtnSaveTrack = New System.Windows.Forms.Button()
        Me.CbArtists = New System.Windows.Forms.ComboBox()
        Me.BtnTracks = New System.Windows.Forms.Button()
        Me.BtnAddGenre = New System.Windows.Forms.Button()
        Me.CbGenre = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtYear = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtTitle = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.NudTrackNo = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Rb2 = New System.Windows.Forms.RadioButton()
        Me.Rb1 = New System.Windows.Forms.RadioButton()
        Me.RbB = New System.Windows.Forms.RadioButton()
        Me.RbAA = New System.Windows.Forms.RadioButton()
        Me.RbA = New System.Windows.Forms.RadioButton()
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.RecordFormatBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RecordsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ArtistsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MusicGenreBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RecordLabelsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DgvTracks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Status.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DgvRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.NudCopies, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudTrackNo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 17)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Record Id"
        '
        'LblRecordId
        '
        Me.LblRecordId.AutoSize = True
        Me.LblRecordId.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRecordId.Location = New System.Drawing.Point(77, 15)
        Me.LblRecordId.Name = "LblRecordId"
        Me.LblRecordId.Size = New System.Drawing.Size(21, 17)
        Me.LblRecordId.TabIndex = 7
        Me.LblRecordId.Text = "-1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(19, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 17)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Format"
        '
        'CbRecordFormat
        '
        Me.CbRecordFormat.DataSource = Me.RecordFormatBindingSource
        Me.CbRecordFormat.DisplayMember = "FormatName"
        Me.CbRecordFormat.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbRecordFormat.FormattingEnabled = True
        Me.CbRecordFormat.Location = New System.Drawing.Point(24, 66)
        Me.CbRecordFormat.Name = "CbRecordFormat"
        Me.CbRecordFormat.Size = New System.Drawing.Size(196, 27)
        Me.CbRecordFormat.TabIndex = 0
        Me.CbRecordFormat.ValueMember = "FormatId"
        '
        'RecordFormatBindingSource
        '
        Me.RecordFormatBindingSource.DataMember = "RecordFormat"
        Me.RecordFormatBindingSource.DataSource = Me.RecordsDataSet
        '
        'RecordsDataSet
        '
        Me.RecordsDataSet.DataSetName = "RecordsDataSet"
        Me.RecordsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ArtistsBindingSource
        '
        Me.ArtistsBindingSource.DataMember = "Artists"
        Me.ArtistsBindingSource.DataSource = Me.RecordsDataSet
        '
        'MusicGenreBindingSource
        '
        Me.MusicGenreBindingSource.DataMember = "MusicGenre"
        Me.MusicGenreBindingSource.DataSource = Me.RecordsDataSet
        '
        'RecordFormatTableAdapter
        '
        Me.RecordFormatTableAdapter.ClearBeforeFill = True
        '
        'ArtistsTableAdapter
        '
        Me.ArtistsTableAdapter.ClearBeforeFill = True
        '
        'BtnAdd
        '
        Me.BtnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnAdd.BackColor = System.Drawing.Color.White
        Me.BtnAdd.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAdd.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAdd.ForeColor = System.Drawing.Color.Black
        Me.BtnAdd.Location = New System.Drawing.Point(22, 354)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(78, 78)
        Me.BtnAdd.TabIndex = 4
        Me.BtnAdd.Text = "Save Record"
        Me.BtnAdd.UseVisualStyleBackColor = False
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.BackColor = System.Drawing.Color.White
        Me.BtnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClose.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.BtnClose.Location = New System.Drawing.Point(1088, 461)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(78, 34)
        Me.BtnClose.TabIndex = 2
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(19, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 17)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Record Label"
        '
        'CbRecordLabel
        '
        Me.CbRecordLabel.DataSource = Me.RecordLabelsBindingSource
        Me.CbRecordLabel.DisplayMember = "LabelName"
        Me.CbRecordLabel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbRecordLabel.FormattingEnabled = True
        Me.CbRecordLabel.Location = New System.Drawing.Point(22, 122)
        Me.CbRecordLabel.Name = "CbRecordLabel"
        Me.CbRecordLabel.Size = New System.Drawing.Size(198, 27)
        Me.CbRecordLabel.TabIndex = 1
        Me.CbRecordLabel.ValueMember = "LabelId"
        '
        'RecordLabelsBindingSource
        '
        Me.RecordLabelsBindingSource.DataMember = "RecordLabels"
        Me.RecordLabelsBindingSource.DataSource = Me.RecordsDataSet
        '
        'RecordLabelsTableAdapter
        '
        Me.RecordLabelsTableAdapter.ClearBeforeFill = True
        '
        'MusicGenreTableAdapter
        '
        Me.MusicGenreTableAdapter.ClearBeforeFill = True
        '
        'BtnAddFormat
        '
        Me.BtnAddFormat.BackColor = System.Drawing.Color.White
        Me.BtnAddFormat.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnAddFormat.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtnAddFormat.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAddFormat.ForeColor = System.Drawing.Color.Black
        Me.BtnAddFormat.Location = New System.Drawing.Point(226, 65)
        Me.BtnAddFormat.Name = "BtnAddFormat"
        Me.BtnAddFormat.Size = New System.Drawing.Size(65, 32)
        Me.BtnAddFormat.TabIndex = 4
        Me.BtnAddFormat.Text = "Add"
        Me.BtnAddFormat.UseVisualStyleBackColor = False
        '
        'BtnAddLabel
        '
        Me.BtnAddLabel.BackColor = System.Drawing.Color.White
        Me.BtnAddLabel.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnAddLabel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtnAddLabel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAddLabel.ForeColor = System.Drawing.Color.Black
        Me.BtnAddLabel.Location = New System.Drawing.Point(226, 118)
        Me.BtnAddLabel.Name = "BtnAddLabel"
        Me.BtnAddLabel.Size = New System.Drawing.Size(65, 32)
        Me.BtnAddLabel.TabIndex = 5
        Me.BtnAddLabel.Text = "Add"
        Me.BtnAddLabel.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(19, 164)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 17)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Record Number"
        '
        'TxtRecNumber
        '
        Me.TxtRecNumber.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRecNumber.Location = New System.Drawing.Point(22, 184)
        Me.TxtRecNumber.Name = "TxtRecNumber"
        Me.TxtRecNumber.Size = New System.Drawing.Size(153, 27)
        Me.TxtRecNumber.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RbNoSize)
        Me.GroupBox1.Controls.Add(Me.Rb12)
        Me.GroupBox1.Controls.Add(Me.Rb7)
        Me.GroupBox1.Location = New System.Drawing.Point(22, 227)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 57)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Size"
        '
        'RbNoSize
        '
        Me.RbNoSize.AutoSize = True
        Me.RbNoSize.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbNoSize.Location = New System.Drawing.Point(138, 23)
        Me.RbNoSize.Name = "RbNoSize"
        Me.RbNoSize.Size = New System.Drawing.Size(50, 23)
        Me.RbNoSize.TabIndex = 2
        Me.RbNoSize.TabStop = True
        Me.RbNoSize.Text = "n/a"
        Me.RbNoSize.UseVisualStyleBackColor = True
        '
        'Rb12
        '
        Me.Rb12.AutoSize = True
        Me.Rb12.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rb12.Location = New System.Drawing.Point(74, 23)
        Me.Rb12.Name = "Rb12"
        Me.Rb12.Size = New System.Drawing.Size(51, 23)
        Me.Rb12.TabIndex = 1
        Me.Rb12.TabStop = True
        Me.Rb12.Text = "12"""
        Me.Rb12.UseVisualStyleBackColor = True
        '
        'Rb7
        '
        Me.Rb7.AutoSize = True
        Me.Rb7.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rb7.Location = New System.Drawing.Point(10, 23)
        Me.Rb7.Name = "Rb7"
        Me.Rb7.Size = New System.Drawing.Size(42, 23)
        Me.Rb7.TabIndex = 0
        Me.Rb7.TabStop = True
        Me.Rb7.Text = "7"""
        Me.Rb7.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RbNoSpeed)
        Me.GroupBox2.Controls.Add(Me.Rb78)
        Me.GroupBox2.Controls.Add(Me.Rb33)
        Me.GroupBox2.Controls.Add(Me.Rb45)
        Me.GroupBox2.Location = New System.Drawing.Point(22, 290)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(272, 53)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Speed"
        '
        'RbNoSpeed
        '
        Me.RbNoSpeed.AutoSize = True
        Me.RbNoSpeed.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbNoSpeed.Location = New System.Drawing.Point(202, 23)
        Me.RbNoSpeed.Name = "RbNoSpeed"
        Me.RbNoSpeed.Size = New System.Drawing.Size(50, 23)
        Me.RbNoSpeed.TabIndex = 3
        Me.RbNoSpeed.TabStop = True
        Me.RbNoSpeed.Text = "n/a"
        Me.RbNoSpeed.UseVisualStyleBackColor = True
        '
        'Rb78
        '
        Me.Rb78.AutoSize = True
        Me.Rb78.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rb78.Location = New System.Drawing.Point(138, 23)
        Me.Rb78.Name = "Rb78"
        Me.Rb78.Size = New System.Drawing.Size(45, 23)
        Me.Rb78.TabIndex = 2
        Me.Rb78.TabStop = True
        Me.Rb78.Text = "78"
        Me.Rb78.UseVisualStyleBackColor = True
        '
        'Rb33
        '
        Me.Rb33.AutoSize = True
        Me.Rb33.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rb33.Location = New System.Drawing.Point(74, 23)
        Me.Rb33.Name = "Rb33"
        Me.Rb33.Size = New System.Drawing.Size(45, 23)
        Me.Rb33.TabIndex = 1
        Me.Rb33.TabStop = True
        Me.Rb33.Text = "33"
        Me.Rb33.UseVisualStyleBackColor = True
        '
        'Rb45
        '
        Me.Rb45.AutoSize = True
        Me.Rb45.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rb45.Location = New System.Drawing.Point(10, 23)
        Me.Rb45.Name = "Rb45"
        Me.Rb45.Size = New System.Drawing.Size(45, 23)
        Me.Rb45.TabIndex = 0
        Me.Rb45.TabStop = True
        Me.Rb45.Text = "45"
        Me.Rb45.UseVisualStyleBackColor = True
        '
        'DgvTracks
        '
        Me.DgvTracks.AllowUserToAddRows = False
        Me.DgvTracks.AllowUserToDeleteRows = False
        Me.DgvTracks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTracks.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.trkSide, Me.trkTrack, Me.trkArtist, Me.trkYear, Me.trkTitle, Me.trkGenre})
        Me.DgvTracks.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvTracks.Location = New System.Drawing.Point(0, 0)
        Me.DgvTracks.MultiSelect = False
        Me.DgvTracks.Name = "DgvTracks"
        Me.DgvTracks.ReadOnly = True
        Me.DgvTracks.RowHeadersVisible = False
        Me.DgvTracks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvTracks.Size = New System.Drawing.Size(498, 147)
        Me.DgvTracks.TabIndex = 0
        '
        'trkSide
        '
        Me.trkSide.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.trkSide.HeaderText = "Side"
        Me.trkSide.Name = "trkSide"
        Me.trkSide.ReadOnly = True
        Me.trkSide.Width = 40
        '
        'trkTrack
        '
        Me.trkTrack.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.trkTrack.HeaderText = "Track"
        Me.trkTrack.Name = "trkTrack"
        Me.trkTrack.ReadOnly = True
        Me.trkTrack.Width = 50
        '
        'trkArtist
        '
        Me.trkArtist.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.trkArtist.HeaderText = "Artist"
        Me.trkArtist.Name = "trkArtist"
        Me.trkArtist.ReadOnly = True
        '
        'trkYear
        '
        Me.trkYear.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.trkYear.HeaderText = "Year"
        Me.trkYear.Name = "trkYear"
        Me.trkYear.ReadOnly = True
        Me.trkYear.Width = 60
        '
        'trkTitle
        '
        Me.trkTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.trkTitle.HeaderText = "Title"
        Me.trkTitle.Name = "trkTitle"
        Me.trkTitle.ReadOnly = True
        '
        'trkGenre
        '
        Me.trkGenre.HeaderText = "Genre"
        Me.trkGenre.Name = "trkGenre"
        Me.trkGenre.ReadOnly = True
        '
        'BtnNext
        '
        Me.BtnNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnNext.BackColor = System.Drawing.Color.White
        Me.BtnNext.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNext.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNext.ForeColor = System.Drawing.Color.Black
        Me.BtnNext.Location = New System.Drawing.Point(461, 461)
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(245, 34)
        Me.BtnNext.TabIndex = 1
        Me.BtnNext.Text = "Next Record"
        Me.BtnNext.UseVisualStyleBackColor = False
        '
        'Status
        '
        Me.Status.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblStatus})
        Me.Status.Location = New System.Drawing.Point(0, 500)
        Me.Status.Name = "Status"
        Me.Status.Size = New System.Drawing.Size(1173, 22)
        Me.Status.TabIndex = 3
        Me.Status.Text = "StatusStrip1"
        '
        'LblStatus
        '
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.LblStatus.Size = New System.Drawing.Size(6, 17)
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Location = New System.Drawing.Point(300, 13)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.DgvRecords)
        Me.SplitContainer1.Panel1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DgvTracks)
        Me.SplitContainer1.Panel2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SplitContainer1.Size = New System.Drawing.Size(502, 421)
        Me.SplitContainer1.SplitterDistance = 266
        Me.SplitContainer1.TabIndex = 8
        '
        'DgvRecords
        '
        Me.DgvRecords.AllowUserToAddRows = False
        Me.DgvRecords.AllowUserToDeleteRows = False
        Me.DgvRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvRecords.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.recId, Me.recFormat, Me.recLabel, Me.recNumber, Me.recArtist})
        Me.DgvRecords.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvRecords.Location = New System.Drawing.Point(0, 0)
        Me.DgvRecords.MultiSelect = False
        Me.DgvRecords.Name = "DgvRecords"
        Me.DgvRecords.ReadOnly = True
        Me.DgvRecords.RowHeadersVisible = False
        Me.DgvRecords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvRecords.Size = New System.Drawing.Size(498, 262)
        Me.DgvRecords.TabIndex = 0
        '
        'recId
        '
        Me.recId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.recId.HeaderText = "Id"
        Me.recId.Name = "recId"
        Me.recId.ReadOnly = True
        Me.recId.Width = 40
        '
        'recFormat
        '
        Me.recFormat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.recFormat.HeaderText = "Format"
        Me.recFormat.Name = "recFormat"
        Me.recFormat.ReadOnly = True
        Me.recFormat.Width = 50
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
        Me.recArtist.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.recArtist.HeaderText = "Artist"
        Me.recArtist.Name = "recArtist"
        Me.recArtist.ReadOnly = True
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer2.Location = New System.Drawing.Point(12, 12)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.NudCopies)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label10)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.SplitContainer1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.LblRecordId)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.GroupBox2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.BtnAdd)
        Me.SplitContainer2.Panel1.Controls.Add(Me.CbRecordFormat)
        Me.SplitContainer2.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer2.Panel1.Controls.Add(Me.CbRecordLabel)
        Me.SplitContainer2.Panel1.Controls.Add(Me.BtnAddFormat)
        Me.SplitContainer2.Panel1.Controls.Add(Me.TxtRecNumber)
        Me.SplitContainer2.Panel1.Controls.Add(Me.BtnAddLabel)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label4)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.BtnSaveTrack)
        Me.SplitContainer2.Panel2.Controls.Add(Me.CbArtists)
        Me.SplitContainer2.Panel2.Controls.Add(Me.BtnTracks)
        Me.SplitContainer2.Panel2.Controls.Add(Me.BtnAddGenre)
        Me.SplitContainer2.Panel2.Controls.Add(Me.CbGenre)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label7)
        Me.SplitContainer2.Panel2.Controls.Add(Me.TxtYear)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label6)
        Me.SplitContainer2.Panel2.Controls.Add(Me.TxtTitle)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label5)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label8)
        Me.SplitContainer2.Panel2.Controls.Add(Me.NudTrackNo)
        Me.SplitContainer2.Panel2.Controls.Add(Me.GroupBox3)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label9)
        Me.SplitContainer2.Size = New System.Drawing.Size(1154, 443)
        Me.SplitContainer2.SplitterDistance = 809
        Me.SplitContainer2.TabIndex = 0
        '
        'NudCopies
        '
        Me.NudCopies.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudCopies.Location = New System.Drawing.Point(212, 184)
        Me.NudCopies.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudCopies.Name = "NudCopies"
        Me.NudCopies.Size = New System.Drawing.Size(45, 27)
        Me.NudCopies.TabIndex = 3
        Me.NudCopies.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(209, 164)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 17)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Copies"
        '
        'BtnSaveTrack
        '
        Me.BtnSaveTrack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnSaveTrack.BackColor = System.Drawing.Color.White
        Me.BtnSaveTrack.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnSaveTrack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSaveTrack.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSaveTrack.ForeColor = System.Drawing.Color.Black
        Me.BtnSaveTrack.Location = New System.Drawing.Point(12, 354)
        Me.BtnSaveTrack.Name = "BtnSaveTrack"
        Me.BtnSaveTrack.Size = New System.Drawing.Size(78, 78)
        Me.BtnSaveTrack.TabIndex = 6
        Me.BtnSaveTrack.Text = "Save Track"
        Me.BtnSaveTrack.UseVisualStyleBackColor = False
        '
        'CbArtists
        '
        Me.CbArtists.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CbArtists.DataSource = Me.ArtistsBindingSource
        Me.CbArtists.DisplayMember = "ArtistName"
        Me.CbArtists.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbArtists.FormattingEnabled = True
        Me.CbArtists.Location = New System.Drawing.Point(12, 140)
        Me.CbArtists.Name = "CbArtists"
        Me.CbArtists.Size = New System.Drawing.Size(235, 27)
        Me.CbArtists.TabIndex = 2
        Me.CbArtists.ValueMember = "ArtistId"
        '
        'BtnTracks
        '
        Me.BtnTracks.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnTracks.BackColor = System.Drawing.Color.White
        Me.BtnTracks.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnTracks.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtnTracks.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTracks.ForeColor = System.Drawing.Color.Black
        Me.BtnTracks.Location = New System.Drawing.Point(253, 136)
        Me.BtnTracks.Name = "BtnTracks"
        Me.BtnTracks.Size = New System.Drawing.Size(65, 32)
        Me.BtnTracks.TabIndex = 7
        Me.BtnTracks.Text = "Add"
        Me.BtnTracks.UseVisualStyleBackColor = False
        '
        'BtnAddGenre
        '
        Me.BtnAddGenre.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAddGenre.BackColor = System.Drawing.Color.White
        Me.BtnAddGenre.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnAddGenre.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtnAddGenre.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAddGenre.ForeColor = System.Drawing.Color.Black
        Me.BtnAddGenre.Location = New System.Drawing.Point(202, 308)
        Me.BtnAddGenre.Name = "BtnAddGenre"
        Me.BtnAddGenre.Size = New System.Drawing.Size(65, 32)
        Me.BtnAddGenre.TabIndex = 8
        Me.BtnAddGenre.Text = "Add"
        Me.BtnAddGenre.UseVisualStyleBackColor = False
        '
        'CbGenre
        '
        Me.CbGenre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CbGenre.DataSource = Me.MusicGenreBindingSource
        Me.CbGenre.DisplayMember = "GenreName"
        Me.CbGenre.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbGenre.FormattingEnabled = True
        Me.CbGenre.Location = New System.Drawing.Point(12, 309)
        Me.CbGenre.Name = "CbGenre"
        Me.CbGenre.Size = New System.Drawing.Size(184, 27)
        Me.CbGenre.TabIndex = 5
        Me.CbGenre.ValueMember = "GenreId"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 285)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 17)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Genre"
        '
        'TxtYear
        '
        Me.TxtYear.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtYear.Location = New System.Drawing.Point(12, 250)
        Me.TxtYear.Name = "TxtYear"
        Me.TxtYear.Size = New System.Drawing.Size(75, 27)
        Me.TxtYear.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 227)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 17)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Year"
        '
        'TxtTitle
        '
        Me.TxtTitle.AllowDrop = True
        Me.TxtTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTitle.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTitle.Location = New System.Drawing.Point(12, 190)
        Me.TxtTitle.Name = "TxtTitle"
        Me.TxtTitle.Size = New System.Drawing.Size(301, 27)
        Me.TxtTitle.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 170)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 17)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Title"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 118)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 17)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Artist"
        '
        'NudTrackNo
        '
        Me.NudTrackNo.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudTrackNo.Location = New System.Drawing.Point(186, 39)
        Me.NudTrackNo.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudTrackNo.Name = "NudTrackNo"
        Me.NudTrackNo.Size = New System.Drawing.Size(64, 27)
        Me.NudTrackNo.TabIndex = 1
        Me.NudTrackNo.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Rb2)
        Me.GroupBox3.Controls.Add(Me.Rb1)
        Me.GroupBox3.Controls.Add(Me.RbB)
        Me.GroupBox3.Controls.Add(Me.RbAA)
        Me.GroupBox3.Controls.Add(Me.RbA)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 19)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(145, 91)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Side"
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
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(182, 19)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 17)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Track #"
        '
        'FrmRecordInput
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1173, 522)
        Me.Controls.Add(Me.SplitContainer2)
        Me.Controls.Add(Me.Status)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.BtnNext)
        Me.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmRecordInput"
        Me.Text = "Input Records"
        CType(Me.RecordFormatBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RecordsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ArtistsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MusicGenreBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RecordLabelsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DgvTracks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Status.ResumeLayout(False)
        Me.Status.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DgvRecords, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.NudCopies, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudTrackNo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents LblRecordId As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents CbRecordFormat As ComboBox
    Friend WithEvents RecordsDataSet As RecordsDataSet
    Friend WithEvents RecordFormatBindingSource As BindingSource
    Friend WithEvents RecordFormatTableAdapter As RecordsDataSetTableAdapters.RecordFormatTableAdapter
    Friend WithEvents ArtistsBindingSource As BindingSource
    Friend WithEvents ArtistsTableAdapter As RecordsDataSetTableAdapters.ArtistsTableAdapter
    Friend WithEvents MusicGenreBindingSource As BindingSource
    Friend WithEvents MusicGenreTableAdapter As RecordsDataSetTableAdapters.MusicGenreTableAdapter
    Friend WithEvents BtnAdd As Button
    Friend WithEvents BtnClose As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents CbRecordLabel As ComboBox
    Friend WithEvents RecordLabelsBindingSource As BindingSource
    Friend WithEvents RecordLabelsTableAdapter As RecordsDataSetTableAdapters.RecordLabelsTableAdapter
    Friend WithEvents BtnAddFormat As Button
    Friend WithEvents BtnAddLabel As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtRecNumber As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Rb7 As RadioButton
    Friend WithEvents RbNoSize As RadioButton
    Friend WithEvents Rb12 As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Rb78 As RadioButton
    Friend WithEvents Rb33 As RadioButton
    Friend WithEvents Rb45 As RadioButton
    Friend WithEvents RbNoSpeed As RadioButton
    Friend WithEvents DgvTracks As DataGridView
    Friend WithEvents BtnNext As Button
    Friend WithEvents Status As StatusStrip
    Friend WithEvents LblStatus As ToolStripStatusLabel
    Friend WithEvents trkSide As DataGridViewTextBoxColumn
    Friend WithEvents trkTrack As DataGridViewTextBoxColumn
    Friend WithEvents trkArtist As DataGridViewTextBoxColumn
    Friend WithEvents trkYear As DataGridViewTextBoxColumn
    Friend WithEvents trkTitle As DataGridViewTextBoxColumn
    Friend WithEvents trkGenre As DataGridViewTextBoxColumn
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents DgvRecords As DataGridView
    Friend WithEvents recId As DataGridViewTextBoxColumn
    Friend WithEvents recFormat As DataGridViewTextBoxColumn
    Friend WithEvents recLabel As DataGridViewTextBoxColumn
    Friend WithEvents recNumber As DataGridViewTextBoxColumn
    Friend WithEvents recArtist As DataGridViewTextBoxColumn
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents CbArtists As ComboBox
    Friend WithEvents BtnTracks As Button
    Friend WithEvents BtnAddGenre As Button
    Friend WithEvents CbGenre As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TxtYear As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtTitle As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents NudTrackNo As NumericUpDown
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Rb2 As RadioButton
    Friend WithEvents Rb1 As RadioButton
    Friend WithEvents RbB As RadioButton
    Friend WithEvents RbAA As RadioButton
    Friend WithEvents RbA As RadioButton
    Friend WithEvents Label9 As Label
    Friend WithEvents BtnSaveTrack As Button
    Friend WithEvents NudCopies As NumericUpDown
    Friend WithEvents Label10 As Label
End Class
