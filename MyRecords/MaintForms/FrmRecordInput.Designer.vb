<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRecordInput
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblRecordId = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CbRecordFormat = New System.Windows.Forms.ComboBox()
        Me.RecordFormatBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RecordsDataSet = New MyRecords.RecordsDataSet()
        Me.RecordFormatTableAdapter = New MyRecords.RecordsDataSetTableAdapters.RecordFormatTableAdapter()
        Me.BtnAdd = New System.Windows.Forms.Button()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CbRecordLabel = New System.Windows.Forms.ComboBox()
        Me.RecordLabelsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RecordLabelsTableAdapter = New MyRecords.RecordsDataSetTableAdapters.RecordLabelsTableAdapter()
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnNext = New System.Windows.Forms.Button()
        Me.BtnAddTracks = New System.Windows.Forms.Button()
        Me.Status = New System.Windows.Forms.StatusStrip()
        Me.LblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.trkSide = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.trkTrack = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.trkArtist = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.trkYear = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.trkTitle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.trkGenre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.RecordFormatBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RecordsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RecordLabelsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DgvTracks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Status.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(23, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Record Id"
        '
        'LblRecordId
        '
        Me.LblRecordId.AutoSize = True
        Me.LblRecordId.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRecordId.Location = New System.Drawing.Point(114, 19)
        Me.LblRecordId.Name = "LblRecordId"
        Me.LblRecordId.Size = New System.Drawing.Size(21, 17)
        Me.LblRecordId.TabIndex = 1
        Me.LblRecordId.Text = "-1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(65, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Format"
        '
        'CbRecordFormat
        '
        Me.CbRecordFormat.DataSource = Me.RecordFormatBindingSource
        Me.CbRecordFormat.DisplayMember = "FormatId"
        Me.CbRecordFormat.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbRecordFormat.FormattingEnabled = True
        Me.CbRecordFormat.Location = New System.Drawing.Point(70, 82)
        Me.CbRecordFormat.Name = "CbRecordFormat"
        Me.CbRecordFormat.Size = New System.Drawing.Size(65, 27)
        Me.CbRecordFormat.TabIndex = 3
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
        'RecordFormatTableAdapter
        '
        Me.RecordFormatTableAdapter.ClearBeforeFill = True
        '
        'BtnAdd
        '
        Me.BtnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnAdd.BackColor = System.Drawing.Color.White
        Me.BtnAdd.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAdd.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAdd.ForeColor = System.Drawing.Color.Black
        Me.BtnAdd.Location = New System.Drawing.Point(68, 403)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(78, 78)
        Me.BtnAdd.TabIndex = 5
        Me.BtnAdd.Text = "Save Record"
        Me.BtnAdd.UseVisualStyleBackColor = False
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
        Me.BtnClose.Location = New System.Drawing.Point(843, 403)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(78, 78)
        Me.BtnClose.TabIndex = 8
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(65, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 17)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Record Label"
        '
        'CbRecordLabel
        '
        Me.CbRecordLabel.DataSource = Me.RecordLabelsBindingSource
        Me.CbRecordLabel.DisplayMember = "LabelName"
        Me.CbRecordLabel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbRecordLabel.FormattingEnabled = True
        Me.CbRecordLabel.Location = New System.Drawing.Point(68, 138)
        Me.CbRecordLabel.Name = "CbRecordLabel"
        Me.CbRecordLabel.Size = New System.Drawing.Size(198, 27)
        Me.CbRecordLabel.TabIndex = 10
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
        'BtnAddFormat
        '
        Me.BtnAddFormat.BackColor = System.Drawing.Color.White
        Me.BtnAddFormat.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnAddFormat.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtnAddFormat.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAddFormat.ForeColor = System.Drawing.Color.Black
        Me.BtnAddFormat.Location = New System.Drawing.Point(306, 82)
        Me.BtnAddFormat.Name = "BtnAddFormat"
        Me.BtnAddFormat.Size = New System.Drawing.Size(65, 32)
        Me.BtnAddFormat.TabIndex = 11
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
        Me.BtnAddLabel.Location = New System.Drawing.Point(306, 134)
        Me.BtnAddLabel.Name = "BtnAddLabel"
        Me.BtnAddLabel.Size = New System.Drawing.Size(65, 32)
        Me.BtnAddLabel.TabIndex = 12
        Me.BtnAddLabel.Text = "Add"
        Me.BtnAddLabel.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(65, 180)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 17)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Record Number"
        '
        'TxtRecNumber
        '
        Me.TxtRecNumber.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRecNumber.Location = New System.Drawing.Point(68, 200)
        Me.TxtRecNumber.Name = "TxtRecNumber"
        Me.TxtRecNumber.Size = New System.Drawing.Size(153, 27)
        Me.TxtRecNumber.TabIndex = 14
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RbNoSize)
        Me.GroupBox1.Controls.Add(Me.Rb12)
        Me.GroupBox1.Controls.Add(Me.Rb7)
        Me.GroupBox1.Location = New System.Drawing.Point(68, 233)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 57)
        Me.GroupBox1.TabIndex = 16
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
        Me.GroupBox2.Location = New System.Drawing.Point(68, 310)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(272, 53)
        Me.GroupBox2.TabIndex = 17
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
        Me.DgvTracks.Name = "DgvTracks"
        Me.DgvTracks.ReadOnly = True
        Me.DgvTracks.RowHeadersVisible = False
        Me.DgvTracks.Size = New System.Drawing.Size(481, 174)
        Me.DgvTracks.TabIndex = 18
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.DgvTracks)
        Me.Panel1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(440, 53)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(481, 174)
        Me.Panel1.TabIndex = 20
        '
        'BtnNext
        '
        Me.BtnNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnNext.BackColor = System.Drawing.Color.White
        Me.BtnNext.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNext.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNext.ForeColor = System.Drawing.Color.Black
        Me.BtnNext.Location = New System.Drawing.Point(344, 403)
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(78, 78)
        Me.BtnNext.TabIndex = 21
        Me.BtnNext.Text = "Next Record"
        Me.BtnNext.UseVisualStyleBackColor = False
        '
        'BtnAddTracks
        '
        Me.BtnAddTracks.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnAddTracks.BackColor = System.Drawing.Color.White
        Me.BtnAddTracks.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnAddTracks.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAddTracks.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAddTracks.ForeColor = System.Drawing.Color.Black
        Me.BtnAddTracks.Location = New System.Drawing.Point(206, 403)
        Me.BtnAddTracks.Name = "BtnAddTracks"
        Me.BtnAddTracks.Size = New System.Drawing.Size(78, 78)
        Me.BtnAddTracks.TabIndex = 22
        Me.BtnAddTracks.Text = "Add Tracks"
        Me.BtnAddTracks.UseVisualStyleBackColor = False
        '
        'Status
        '
        Me.Status.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblStatus})
        Me.Status.Location = New System.Drawing.Point(0, 484)
        Me.Status.Name = "Status"
        Me.Status.Size = New System.Drawing.Size(933, 22)
        Me.Status.TabIndex = 23
        Me.Status.Text = "StatusStrip1"
        '
        'LblStatus
        '
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.LblStatus.Size = New System.Drawing.Size(6, 17)
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
        'FrmRecordInput
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(933, 506)
        Me.Controls.Add(Me.Status)
        Me.Controls.Add(Me.BtnAddTracks)
        Me.Controls.Add(Me.BtnNext)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TxtRecNumber)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.BtnAddLabel)
        Me.Controls.Add(Me.BtnAddFormat)
        Me.Controls.Add(Me.CbRecordLabel)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.BtnAdd)
        Me.Controls.Add(Me.CbRecordFormat)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LblRecordId)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmRecordInput"
        Me.Text = "Input Records"
        CType(Me.RecordFormatBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RecordsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RecordLabelsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DgvTracks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Status.ResumeLayout(False)
        Me.Status.PerformLayout()
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
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnNext As Button
    Friend WithEvents BtnAddTracks As Button
    Friend WithEvents Status As StatusStrip
    Friend WithEvents LblStatus As ToolStripStatusLabel
    Friend WithEvents trkSide As DataGridViewTextBoxColumn
    Friend WithEvents trkTrack As DataGridViewTextBoxColumn
    Friend WithEvents trkArtist As DataGridViewTextBoxColumn
    Friend WithEvents trkYear As DataGridViewTextBoxColumn
    Friend WithEvents trkTitle As DataGridViewTextBoxColumn
    Friend WithEvents trkGenre As DataGridViewTextBoxColumn
End Class
