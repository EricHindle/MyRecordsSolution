' Hindleware
' Copyright (c) 2024-26 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmResult
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmResult))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtYear = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtTitle = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtRecNumber = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.PicImage = New System.Windows.Forms.PictureBox()
        Me.BtnStop = New System.Windows.Forms.Button()
        Me.BtnPlay = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TxtSongFile = New System.Windows.Forms.TextBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtChartPos = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LblId = New System.Windows.Forms.Label()
        Me.TxtArtist = New System.Windows.Forms.TextBox()
        Me.TxtLabel = New System.Windows.Forms.TextBox()
        Me.TxtGenre = New System.Windows.Forms.TextBox()
        Me.TxtSide = New System.Windows.Forms.TextBox()
        Me.TxtTrack = New System.Windows.Forms.TextBox()
        Me.TxtChartDate = New System.Windows.Forms.TextBox()
        Me.TxtSize = New System.Windows.Forms.TextBox()
        Me.TxtSpeed = New System.Windows.Forms.TextBox()
        Me.TxtCopies = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.BtnMetadata = New System.Windows.Forms.Button()
        CType(Me.PicImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 11)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(20, 17)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Id"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 194)
        Me.Label7.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 17)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Genre"
        '
        'TxtYear
        '
        Me.TxtYear.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtYear.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtYear.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtYear.ForeColor = System.Drawing.Color.MidnightBlue
        Me.TxtYear.Location = New System.Drawing.Point(15, 283)
        Me.TxtYear.Margin = New System.Windows.Forms.Padding(5)
        Me.TxtYear.Name = "TxtYear"
        Me.TxtYear.Size = New System.Drawing.Size(101, 17)
        Me.TxtYear.TabIndex = 22
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 258)
        Me.Label6.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 17)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Year"
        '
        'TxtTitle
        '
        Me.TxtTitle.AllowDrop = True
        Me.TxtTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTitle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtTitle.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtTitle.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTitle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.TxtTitle.Location = New System.Drawing.Point(15, 95)
        Me.TxtTitle.Margin = New System.Windows.Forms.Padding(5)
        Me.TxtTitle.Name = "TxtTitle"
        Me.TxtTitle.Size = New System.Drawing.Size(408, 17)
        Me.TxtTitle.TabIndex = 19
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 71)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 17)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Title"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(145, 10)
        Me.Label8.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 17)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Artist"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(145, 131)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 17)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Record Label"
        '
        'TxtRecNumber
        '
        Me.TxtRecNumber.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtRecNumber.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtRecNumber.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRecNumber.ForeColor = System.Drawing.Color.MidnightBlue
        Me.TxtRecNumber.Location = New System.Drawing.Point(15, 156)
        Me.TxtRecNumber.Margin = New System.Windows.Forms.Padding(5)
        Me.TxtRecNumber.Name = "TxtRecNumber"
        Me.TxtRecNumber.Size = New System.Drawing.Size(109, 17)
        Me.TxtRecNumber.TabIndex = 20
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 131)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 17)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Record Number"
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnClose.Location = New System.Drawing.Point(488, 380)
        Me.BtnClose.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(71, 39)
        Me.BtnClose.TabIndex = 31
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'PicImage
        '
        Me.PicImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicImage.Location = New System.Drawing.Point(488, 11)
        Me.PicImage.Margin = New System.Windows.Forms.Padding(0)
        Me.PicImage.Name = "PicImage"
        Me.PicImage.Size = New System.Drawing.Size(70, 70)
        Me.PicImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicImage.TabIndex = 98
        Me.PicImage.TabStop = False
        '
        'BtnStop
        '
        Me.BtnStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnStop.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnStop.Image = Global.MyVinyl.My.Resources.Resources._stop
        Me.BtnStop.Location = New System.Drawing.Point(328, 352)
        Me.BtnStop.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnStop.Name = "BtnStop"
        Me.BtnStop.Size = New System.Drawing.Size(30, 32)
        Me.BtnStop.TabIndex = 102
        Me.BtnStop.UseVisualStyleBackColor = True
        '
        'BtnPlay
        '
        Me.BtnPlay.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPlay.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPlay.Image = Global.MyVinyl.My.Resources.Resources.play
        Me.BtnPlay.Location = New System.Drawing.Point(272, 352)
        Me.BtnPlay.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnPlay.Name = "BtnPlay"
        Me.BtnPlay.Size = New System.Drawing.Size(30, 32)
        Me.BtnPlay.TabIndex = 101
        Me.BtnPlay.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(16, 363)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(62, 17)
        Me.Label13.TabIndex = 100
        Me.Label13.Text = "Song File"
        '
        'TxtSongFile
        '
        Me.TxtSongFile.AllowDrop = True
        Me.TxtSongFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSongFile.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtSongFile.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSongFile.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSongFile.ForeColor = System.Drawing.Color.MidnightBlue
        Me.TxtSongFile.Location = New System.Drawing.Point(15, 388)
        Me.TxtSongFile.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtSongFile.Name = "TxtSongFile"
        Me.TxtSongFile.Size = New System.Drawing.Size(348, 20)
        Me.TxtSongFile.TabIndex = 99
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(132, 357)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(100, 23)
        Me.ProgressBar1.TabIndex = 103
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(151, 302)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(108, 17)
        Me.Label12.TabIndex = 107
        Me.Label12.Text = "Peak Chart Date"
        '
        'TxtChartPos
        '
        Me.TxtChartPos.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtChartPos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtChartPos.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtChartPos.ForeColor = System.Drawing.Color.MidnightBlue
        Me.TxtChartPos.Location = New System.Drawing.Point(292, 262)
        Me.TxtChartPos.Name = "TxtChartPos"
        Me.TxtChartPos.Size = New System.Drawing.Size(62, 17)
        Me.TxtChartPos.TabIndex = 104
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(151, 265)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(126, 17)
        Me.Label11.TabIndex = 106
        Me.Label11.Text = "Peak Chart Position"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(448, 131)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 17)
        Me.Label2.TabIndex = 108
        Me.Label2.Text = "Side"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(505, 131)
        Me.Label9.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 17)
        Me.Label9.TabIndex = 109
        Me.Label9.Text = "Track"
        '
        'LblId
        '
        Me.LblId.AutoSize = True
        Me.LblId.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblId.Location = New System.Drawing.Point(16, 39)
        Me.LblId.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.LblId.Name = "LblId"
        Me.LblId.Size = New System.Drawing.Size(21, 17)
        Me.LblId.TabIndex = 111
        Me.LblId.Text = "-1"
        '
        'TxtArtist
        '
        Me.TxtArtist.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtArtist.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtArtist.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtArtist.ForeColor = System.Drawing.Color.MidnightBlue
        Me.TxtArtist.Location = New System.Drawing.Point(148, 36)
        Me.TxtArtist.Name = "TxtArtist"
        Me.TxtArtist.Size = New System.Drawing.Size(275, 17)
        Me.TxtArtist.TabIndex = 112
        '
        'TxtLabel
        '
        Me.TxtLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtLabel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtLabel.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtLabel.ForeColor = System.Drawing.Color.MidnightBlue
        Me.TxtLabel.Location = New System.Drawing.Point(148, 156)
        Me.TxtLabel.Name = "TxtLabel"
        Me.TxtLabel.Size = New System.Drawing.Size(215, 17)
        Me.TxtLabel.TabIndex = 113
        '
        'TxtGenre
        '
        Me.TxtGenre.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtGenre.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtGenre.ForeColor = System.Drawing.Color.MidnightBlue
        Me.TxtGenre.Location = New System.Drawing.Point(15, 214)
        Me.TxtGenre.Name = "TxtGenre"
        Me.TxtGenre.Size = New System.Drawing.Size(100, 17)
        Me.TxtGenre.TabIndex = 114
        '
        'TxtSide
        '
        Me.TxtSide.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSide.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtSide.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSide.ForeColor = System.Drawing.Color.MidnightBlue
        Me.TxtSide.Location = New System.Drawing.Point(447, 156)
        Me.TxtSide.Name = "TxtSide"
        Me.TxtSide.Size = New System.Drawing.Size(35, 17)
        Me.TxtSide.TabIndex = 115
        '
        'TxtTrack
        '
        Me.TxtTrack.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTrack.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtTrack.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtTrack.ForeColor = System.Drawing.Color.MidnightBlue
        Me.TxtTrack.Location = New System.Drawing.Point(506, 156)
        Me.TxtTrack.Name = "TxtTrack"
        Me.TxtTrack.Size = New System.Drawing.Size(41, 17)
        Me.TxtTrack.TabIndex = 116
        '
        'TxtChartDate
        '
        Me.TxtChartDate.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtChartDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtChartDate.ForeColor = System.Drawing.Color.MidnightBlue
        Me.TxtChartDate.Location = New System.Drawing.Point(292, 299)
        Me.TxtChartDate.Name = "TxtChartDate"
        Me.TxtChartDate.Size = New System.Drawing.Size(100, 17)
        Me.TxtChartDate.TabIndex = 117
        '
        'TxtSize
        '
        Me.TxtSize.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtSize.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSize.ForeColor = System.Drawing.Color.MidnightBlue
        Me.TxtSize.Location = New System.Drawing.Point(148, 214)
        Me.TxtSize.Name = "TxtSize"
        Me.TxtSize.Size = New System.Drawing.Size(61, 17)
        Me.TxtSize.TabIndex = 118
        '
        'TxtSpeed
        '
        Me.TxtSpeed.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtSpeed.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSpeed.ForeColor = System.Drawing.Color.MidnightBlue
        Me.TxtSpeed.Location = New System.Drawing.Point(235, 214)
        Me.TxtSpeed.Name = "TxtSpeed"
        Me.TxtSpeed.Size = New System.Drawing.Size(67, 17)
        Me.TxtSpeed.TabIndex = 119
        '
        'TxtCopies
        '
        Me.TxtCopies.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtCopies.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCopies.ForeColor = System.Drawing.Color.MidnightBlue
        Me.TxtCopies.Location = New System.Drawing.Point(323, 214)
        Me.TxtCopies.Name = "TxtCopies"
        Me.TxtCopies.Size = New System.Drawing.Size(40, 17)
        Me.TxtCopies.TabIndex = 120
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(153, 195)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(31, 17)
        Me.Label10.TabIndex = 121
        Me.Label10.Text = "Size"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(232, 195)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(46, 17)
        Me.Label14.TabIndex = 122
        Me.Label14.Text = "Speed"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(325, 194)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(48, 17)
        Me.Label15.TabIndex = 123
        Me.Label15.Text = "Copies"
        '
        'BtnMetadata
        '
        Me.BtnMetadata.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnMetadata.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnMetadata.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMetadata.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnMetadata.Location = New System.Drawing.Point(489, 319)
        Me.BtnMetadata.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnMetadata.Name = "BtnMetadata"
        Me.BtnMetadata.Size = New System.Drawing.Size(71, 39)
        Me.BtnMetadata.TabIndex = 124
        Me.BtnMetadata.Text = "Copy Meta Data"
        Me.BtnMetadata.UseVisualStyleBackColor = True
        '
        'FrmResult
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(574, 435)
        Me.Controls.Add(Me.BtnMetadata)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TxtCopies)
        Me.Controls.Add(Me.TxtSpeed)
        Me.Controls.Add(Me.TxtSize)
        Me.Controls.Add(Me.TxtChartDate)
        Me.Controls.Add(Me.TxtTrack)
        Me.Controls.Add(Me.TxtSide)
        Me.Controls.Add(Me.TxtGenre)
        Me.Controls.Add(Me.TxtLabel)
        Me.Controls.Add(Me.TxtArtist)
        Me.Controls.Add(Me.LblId)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TxtChartPos)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.BtnStop)
        Me.Controls.Add(Me.BtnPlay)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TxtSongFile)
        Me.Controls.Add(Me.PicImage)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtYear)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtTitle)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtRecNumber)
        Me.Controls.Add(Me.Label4)
        Me.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmResult"
        Me.Text = "Record Details"
        CType(Me.PicImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TxtYear As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtTitle As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtRecNumber As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents BtnClose As Button
    Friend WithEvents PicImage As PictureBox
    Friend WithEvents BtnStop As Button
    Friend WithEvents BtnPlay As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents TxtSongFile As TextBox
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Label12 As Label
    Friend WithEvents TxtChartPos As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents LblId As Label
    Friend WithEvents TxtArtist As TextBox
    Friend WithEvents TxtLabel As TextBox
    Friend WithEvents TxtGenre As TextBox
    Friend WithEvents TxtSide As TextBox
    Friend WithEvents TxtTrack As TextBox
    Friend WithEvents TxtChartDate As TextBox
    Friend WithEvents TxtSize As TextBox
    Friend WithEvents TxtSpeed As TextBox
    Friend WithEvents TxtCopies As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents BtnMetadata As Button
End Class
