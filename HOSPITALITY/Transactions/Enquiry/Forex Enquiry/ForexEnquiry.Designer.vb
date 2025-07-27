<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ForexEnquiry
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ForexEnquiry))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.BlendPanel2 = New VbPowerPack.BlendPanel
        Me.Label7 = New System.Windows.Forms.Label
        Me.CMBPRODUCT = New System.Windows.Forms.ComboBox
        Me.TXTCOMM = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TXTADD = New System.Windows.Forms.TextBox
        Me.CMBOTHERCHGSCODE = New System.Windows.Forms.ComboBox
        Me.Label38 = New System.Windows.Forms.Label
        Me.txtroundoff = New System.Windows.Forms.TextBox
        Me.CMBOTHERCHGS = New System.Windows.Forms.ComboBox
        Me.cmbaddsub = New System.Windows.Forms.ComboBox
        Me.TXTOTHERCHGS = New System.Windows.Forms.TextBox
        Me.TXTADDGUESTNAME = New System.Windows.Forms.TextBox
        Me.TXTROE = New System.Windows.Forms.TextBox
        Me.CMBBUYSELL = New System.Windows.Forms.ComboBox
        Me.MTBRETURNDATE = New System.Windows.Forms.MaskedTextBox
        Me.LBLRETURNDATE = New System.Windows.Forms.Label
        Me.TXTGTOTAL = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.TXTST = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.TXTAMTINR = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.TXTCURRENCYAMT = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.CMBCURRENCY = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TXTCLOSEREMARKS = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TXTREMARKS = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.CMBSTATUS = New System.Windows.Forms.ComboBox
        Me.TXTAGENT = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.CMBGUESTNAME = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.DTFOREXENQDATE = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.TXTFOREXENQNO = New System.Windows.Forms.TextBox
        Me.CMDDELETE = New System.Windows.Forms.Button
        Me.CMDEXIT = New System.Windows.Forms.Button
        Me.CMDOK = New System.Windows.Forms.Button
        Me.CMDCLEAR = New System.Windows.Forms.Button
        Me.tstxtbillno = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.CMBBOOKEDBY = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.CMBSOURCE = New System.Windows.Forms.ComboBox
        Me.lbl = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripprint = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.toolprevious = New System.Windows.Forms.ToolStripButton
        Me.toolnext = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        Me.BlendPanel2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.BlendPanel2)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(697, 454)
        Me.BlendPanel1.TabIndex = 0
        '
        'BlendPanel2
        '
        Me.BlendPanel2.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel2.Controls.Add(Me.Label7)
        Me.BlendPanel2.Controls.Add(Me.CMBPRODUCT)
        Me.BlendPanel2.Controls.Add(Me.TXTCOMM)
        Me.BlendPanel2.Controls.Add(Me.Label5)
        Me.BlendPanel2.Controls.Add(Me.TXTADD)
        Me.BlendPanel2.Controls.Add(Me.CMBOTHERCHGSCODE)
        Me.BlendPanel2.Controls.Add(Me.Label38)
        Me.BlendPanel2.Controls.Add(Me.txtroundoff)
        Me.BlendPanel2.Controls.Add(Me.CMBOTHERCHGS)
        Me.BlendPanel2.Controls.Add(Me.cmbaddsub)
        Me.BlendPanel2.Controls.Add(Me.TXTOTHERCHGS)
        Me.BlendPanel2.Controls.Add(Me.TXTADDGUESTNAME)
        Me.BlendPanel2.Controls.Add(Me.TXTROE)
        Me.BlendPanel2.Controls.Add(Me.CMBBUYSELL)
        Me.BlendPanel2.Controls.Add(Me.MTBRETURNDATE)
        Me.BlendPanel2.Controls.Add(Me.LBLRETURNDATE)
        Me.BlendPanel2.Controls.Add(Me.TXTGTOTAL)
        Me.BlendPanel2.Controls.Add(Me.Label17)
        Me.BlendPanel2.Controls.Add(Me.TXTST)
        Me.BlendPanel2.Controls.Add(Me.Label15)
        Me.BlendPanel2.Controls.Add(Me.TXTAMTINR)
        Me.BlendPanel2.Controls.Add(Me.Label14)
        Me.BlendPanel2.Controls.Add(Me.TXTCURRENCYAMT)
        Me.BlendPanel2.Controls.Add(Me.Label12)
        Me.BlendPanel2.Controls.Add(Me.Label11)
        Me.BlendPanel2.Controls.Add(Me.Label10)
        Me.BlendPanel2.Controls.Add(Me.CMBCURRENCY)
        Me.BlendPanel2.Controls.Add(Me.Label9)
        Me.BlendPanel2.Controls.Add(Me.TXTCLOSEREMARKS)
        Me.BlendPanel2.Controls.Add(Me.Label8)
        Me.BlendPanel2.Controls.Add(Me.TXTREMARKS)
        Me.BlendPanel2.Controls.Add(Me.Label6)
        Me.BlendPanel2.Controls.Add(Me.CMBSTATUS)
        Me.BlendPanel2.Controls.Add(Me.TXTAGENT)
        Me.BlendPanel2.Controls.Add(Me.Label2)
        Me.BlendPanel2.Controls.Add(Me.Label1)
        Me.BlendPanel2.Controls.Add(Me.Label33)
        Me.BlendPanel2.Controls.Add(Me.CMBGUESTNAME)
        Me.BlendPanel2.Controls.Add(Me.Label4)
        Me.BlendPanel2.Controls.Add(Me.DTFOREXENQDATE)
        Me.BlendPanel2.Controls.Add(Me.Label3)
        Me.BlendPanel2.Controls.Add(Me.TXTFOREXENQNO)
        Me.BlendPanel2.Controls.Add(Me.CMDDELETE)
        Me.BlendPanel2.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel2.Controls.Add(Me.CMDOK)
        Me.BlendPanel2.Controls.Add(Me.CMDCLEAR)
        Me.BlendPanel2.Controls.Add(Me.tstxtbillno)
        Me.BlendPanel2.Controls.Add(Me.Label28)
        Me.BlendPanel2.Controls.Add(Me.CMBBOOKEDBY)
        Me.BlendPanel2.Controls.Add(Me.Label13)
        Me.BlendPanel2.Controls.Add(Me.CMBSOURCE)
        Me.BlendPanel2.Controls.Add(Me.lbl)
        Me.BlendPanel2.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel2.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel2.Name = "BlendPanel2"
        Me.BlendPanel2.Size = New System.Drawing.Size(697, 454)
        Me.BlendPanel2.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(222, 173)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 15)
        Me.Label7.TabIndex = 779
        Me.Label7.Text = "Product"
        '
        'CMBPRODUCT
        '
        Me.CMBPRODUCT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBPRODUCT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBPRODUCT.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBPRODUCT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBPRODUCT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBPRODUCT.FormattingEnabled = True
        Me.CMBPRODUCT.Items.AddRange(New Object() {"CURRENCY NOTES", "TRAVEL CARD", "TRAVELLERS CHQ", "REMITTANCE"})
        Me.CMBPRODUCT.Location = New System.Drawing.Point(274, 169)
        Me.CMBPRODUCT.Name = "CMBPRODUCT"
        Me.CMBPRODUCT.Size = New System.Drawing.Size(78, 23)
        Me.CMBPRODUCT.TabIndex = 5
        '
        'TXTCOMM
        '
        Me.TXTCOMM.BackColor = System.Drawing.Color.White
        Me.TXTCOMM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCOMM.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCOMM.Location = New System.Drawing.Point(274, 286)
        Me.TXTCOMM.MaxLength = 100
        Me.TXTCOMM.Name = "TXTCOMM"
        Me.TXTCOMM.Size = New System.Drawing.Size(78, 23)
        Me.TXTCOMM.TabIndex = 10
        Me.TXTCOMM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(231, 290)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 15)
        Me.Label5.TabIndex = 777
        Me.Label5.Text = "Comm"
        '
        'TXTADD
        '
        Me.TXTADD.BackColor = System.Drawing.Color.White
        Me.TXTADD.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTADD.ForeColor = System.Drawing.Color.Black
        Me.TXTADD.Location = New System.Drawing.Point(514, 32)
        Me.TXTADD.Name = "TXTADD"
        Me.TXTADD.ReadOnly = True
        Me.TXTADD.Size = New System.Drawing.Size(90, 22)
        Me.TXTADD.TabIndex = 775
        Me.TXTADD.TabStop = False
        Me.TXTADD.Text = "0.00"
        Me.TXTADD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTADD.Visible = False
        '
        'CMBOTHERCHGSCODE
        '
        Me.CMBOTHERCHGSCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBOTHERCHGSCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBOTHERCHGSCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBOTHERCHGSCODE.FormattingEnabled = True
        Me.CMBOTHERCHGSCODE.Location = New System.Drawing.Point(425, 29)
        Me.CMBOTHERCHGSCODE.MaxDropDownItems = 14
        Me.CMBOTHERCHGSCODE.Name = "CMBOTHERCHGSCODE"
        Me.CMBOTHERCHGSCODE.Size = New System.Drawing.Size(73, 22)
        Me.CMBOTHERCHGSCODE.TabIndex = 774
        Me.CMBOTHERCHGSCODE.Visible = False
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(439, 232)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(60, 14)
        Me.Label38.TabIndex = 773
        Me.Label38.Text = "Round Off"
        '
        'txtroundoff
        '
        Me.txtroundoff.BackColor = System.Drawing.Color.Linen
        Me.txtroundoff.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtroundoff.ForeColor = System.Drawing.Color.Black
        Me.txtroundoff.Location = New System.Drawing.Point(500, 228)
        Me.txtroundoff.Name = "txtroundoff"
        Me.txtroundoff.ReadOnly = True
        Me.txtroundoff.Size = New System.Drawing.Size(83, 22)
        Me.txtroundoff.TabIndex = 772
        Me.txtroundoff.TabStop = False
        Me.txtroundoff.Text = "0.00"
        Me.txtroundoff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMBOTHERCHGS
        '
        Me.CMBOTHERCHGS.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBOTHERCHGS.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBOTHERCHGS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBOTHERCHGS.FormattingEnabled = True
        Me.CMBOTHERCHGS.Location = New System.Drawing.Point(426, 199)
        Me.CMBOTHERCHGS.MaxDropDownItems = 14
        Me.CMBOTHERCHGS.Name = "CMBOTHERCHGS"
        Me.CMBOTHERCHGS.Size = New System.Drawing.Size(73, 22)
        Me.CMBOTHERCHGS.TabIndex = 14
        '
        'cmbaddsub
        '
        Me.cmbaddsub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbaddsub.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbaddsub.FormattingEnabled = True
        Me.cmbaddsub.Items.AddRange(New Object() {"", "Add", "Sub."})
        Me.cmbaddsub.Location = New System.Drawing.Point(377, 199)
        Me.cmbaddsub.Name = "cmbaddsub"
        Me.cmbaddsub.Size = New System.Drawing.Size(47, 22)
        Me.cmbaddsub.TabIndex = 13
        '
        'TXTOTHERCHGS
        '
        Me.TXTOTHERCHGS.BackColor = System.Drawing.Color.White
        Me.TXTOTHERCHGS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTOTHERCHGS.ForeColor = System.Drawing.Color.Black
        Me.TXTOTHERCHGS.Location = New System.Drawing.Point(500, 199)
        Me.TXTOTHERCHGS.Name = "TXTOTHERCHGS"
        Me.TXTOTHERCHGS.Size = New System.Drawing.Size(83, 22)
        Me.TXTOTHERCHGS.TabIndex = 15
        Me.TXTOTHERCHGS.Text = "0.00"
        Me.TXTOTHERCHGS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTADDGUESTNAME
        '
        Me.TXTADDGUESTNAME.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTADDGUESTNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTADDGUESTNAME.Location = New System.Drawing.Point(14, 438)
        Me.TXTADDGUESTNAME.MaxLength = 100
        Me.TXTADDGUESTNAME.Name = "TXTADDGUESTNAME"
        Me.TXTADDGUESTNAME.Size = New System.Drawing.Size(27, 23)
        Me.TXTADDGUESTNAME.TabIndex = 767
        Me.TXTADDGUESTNAME.Visible = False
        '
        'TXTROE
        '
        Me.TXTROE.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTROE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTROE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTROE.Location = New System.Drawing.Point(500, 79)
        Me.TXTROE.MaxLength = 100
        Me.TXTROE.Name = "TXTROE"
        Me.TXTROE.Size = New System.Drawing.Size(83, 23)
        Me.TXTROE.TabIndex = 11
        Me.TXTROE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMBBUYSELL
        '
        Me.CMBBUYSELL.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBBUYSELL.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBBUYSELL.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBBUYSELL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBBUYSELL.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBBUYSELL.FormattingEnabled = True
        Me.CMBBUYSELL.Items.AddRange(New Object() {"Buy", "Sell"})
        Me.CMBBUYSELL.Location = New System.Drawing.Point(125, 139)
        Me.CMBBUYSELL.Name = "CMBBUYSELL"
        Me.CMBBUYSELL.Size = New System.Drawing.Size(93, 23)
        Me.CMBBUYSELL.TabIndex = 2
        '
        'MTBRETURNDATE
        '
        Me.MTBRETURNDATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MTBRETURNDATE.Location = New System.Drawing.Point(125, 286)
        Me.MTBRETURNDATE.Mask = "00/00/0000"
        Me.MTBRETURNDATE.Name = "MTBRETURNDATE"
        Me.MTBRETURNDATE.Size = New System.Drawing.Size(75, 23)
        Me.MTBRETURNDATE.TabIndex = 9
        Me.MTBRETURNDATE.ValidatingType = GetType(Date)
        '
        'LBLRETURNDATE
        '
        Me.LBLRETURNDATE.AutoSize = True
        Me.LBLRETURNDATE.BackColor = System.Drawing.Color.Transparent
        Me.LBLRETURNDATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLRETURNDATE.Location = New System.Drawing.Point(52, 289)
        Me.LBLRETURNDATE.Name = "LBLRETURNDATE"
        Me.LBLRETURNDATE.Size = New System.Drawing.Size(71, 15)
        Me.LBLRETURNDATE.TabIndex = 763
        Me.LBLRETURNDATE.Text = "Return Date"
        '
        'TXTGTOTAL
        '
        Me.TXTGTOTAL.BackColor = System.Drawing.Color.Linen
        Me.TXTGTOTAL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTGTOTAL.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTGTOTAL.Location = New System.Drawing.Point(500, 257)
        Me.TXTGTOTAL.MaxLength = 100
        Me.TXTGTOTAL.Name = "TXTGTOTAL"
        Me.TXTGTOTAL.ReadOnly = True
        Me.TXTGTOTAL.Size = New System.Drawing.Size(83, 23)
        Me.TXTGTOTAL.TabIndex = 14
        Me.TXTGTOTAL.TabStop = False
        Me.TXTGTOTAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(428, 261)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(71, 15)
        Me.Label17.TabIndex = 761
        Me.Label17.Text = "Grand Total"
        '
        'TXTST
        '
        Me.TXTST.BackColor = System.Drawing.Color.Linen
        Me.TXTST.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTST.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTST.Location = New System.Drawing.Point(500, 169)
        Me.TXTST.MaxLength = 100
        Me.TXTST.Name = "TXTST"
        Me.TXTST.ReadOnly = True
        Me.TXTST.Size = New System.Drawing.Size(83, 23)
        Me.TXTST.TabIndex = 12
        Me.TXTST.TabStop = False
        Me.TXTST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(446, 173)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(53, 15)
        Me.Label15.TabIndex = 757
        Me.Label15.Text = "Total S.T."
        '
        'TXTAMTINR
        '
        Me.TXTAMTINR.BackColor = System.Drawing.Color.Linen
        Me.TXTAMTINR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTAMTINR.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTAMTINR.Location = New System.Drawing.Point(500, 139)
        Me.TXTAMTINR.MaxLength = 100
        Me.TXTAMTINR.Name = "TXTAMTINR"
        Me.TXTAMTINR.ReadOnly = True
        Me.TXTAMTINR.Size = New System.Drawing.Size(83, 23)
        Me.TXTAMTINR.TabIndex = 11
        Me.TXTAMTINR.TabStop = False
        Me.TXTAMTINR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(420, 143)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(79, 15)
        Me.Label14.TabIndex = 755
        Me.Label14.Text = "Amount (INR)"
        '
        'TXTCURRENCYAMT
        '
        Me.TXTCURRENCYAMT.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTCURRENCYAMT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCURRENCYAMT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCURRENCYAMT.Location = New System.Drawing.Point(500, 109)
        Me.TXTCURRENCYAMT.MaxLength = 100
        Me.TXTCURRENCYAMT.Name = "TXTCURRENCYAMT"
        Me.TXTCURRENCYAMT.Size = New System.Drawing.Size(83, 23)
        Me.TXTCURRENCYAMT.TabIndex = 12
        Me.TXTCURRENCYAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(416, 113)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(83, 15)
        Me.Label12.TabIndex = 753
        Me.Label12.Text = "Currency Amt."
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(470, 83)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(29, 15)
        Me.Label11.TabIndex = 752
        Me.Label11.Text = "ROE"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(33, 173)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(90, 15)
        Me.Label10.TabIndex = 750
        Me.Label10.Text = "Currency Name"
        '
        'CMBCURRENCY
        '
        Me.CMBCURRENCY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCURRENCY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCURRENCY.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBCURRENCY.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCURRENCY.FormattingEnabled = True
        Me.CMBCURRENCY.Items.AddRange(New Object() {""})
        Me.CMBCURRENCY.Location = New System.Drawing.Point(125, 169)
        Me.CMBCURRENCY.Name = "CMBCURRENCY"
        Me.CMBCURRENCY.Size = New System.Drawing.Size(93, 23)
        Me.CMBCURRENCY.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(361, 318)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(87, 15)
        Me.Label9.TabIndex = 748
        Me.Label9.Text = "Close Remarks"
        '
        'TXTCLOSEREMARKS
        '
        Me.TXTCLOSEREMARKS.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTCLOSEREMARKS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCLOSEREMARKS.Location = New System.Drawing.Point(450, 315)
        Me.TXTCLOSEREMARKS.Multiline = True
        Me.TXTCLOSEREMARKS.Name = "TXTCLOSEREMARKS"
        Me.TXTCLOSEREMARKS.Size = New System.Drawing.Size(227, 68)
        Me.TXTCLOSEREMARKS.TabIndex = 17
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(69, 318)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 15)
        Me.Label8.TabIndex = 746
        Me.Label8.Text = "Remarks"
        '
        'TXTREMARKS
        '
        Me.TXTREMARKS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTREMARKS.Location = New System.Drawing.Point(125, 315)
        Me.TXTREMARKS.Multiline = True
        Me.TXTREMARKS.Name = "TXTREMARKS"
        Me.TXTREMARKS.Size = New System.Drawing.Size(227, 68)
        Me.TXTREMARKS.TabIndex = 16
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(231, 143)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 15)
        Me.Label6.TabIndex = 744
        Me.Label6.Text = "Status"
        '
        'CMBSTATUS
        '
        Me.CMBSTATUS.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBSTATUS.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBSTATUS.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBSTATUS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBSTATUS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBSTATUS.FormattingEnabled = True
        Me.CMBSTATUS.Items.AddRange(New Object() {"Pending", "Cancel", "Confirmed"})
        Me.CMBSTATUS.Location = New System.Drawing.Point(274, 139)
        Me.CMBSTATUS.Name = "CMBSTATUS"
        Me.CMBSTATUS.Size = New System.Drawing.Size(78, 23)
        Me.CMBSTATUS.TabIndex = 3
        '
        'TXTAGENT
        '
        Me.TXTAGENT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTAGENT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTAGENT.Location = New System.Drawing.Point(125, 257)
        Me.TXTAGENT.MaxLength = 100
        Me.TXTAGENT.Name = "TXTAGENT"
        Me.TXTAGENT.Size = New System.Drawing.Size(227, 23)
        Me.TXTAGENT.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(86, 261)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 15)
        Me.Label2.TabIndex = 739
        Me.Label2.Text = "Agent"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(71, 143)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 15)
        Me.Label1.TabIndex = 737
        Me.Label1.Text = "Buy/Sell"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(51, 113)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(72, 15)
        Me.Label33.TabIndex = 735
        Me.Label33.Text = "Guest Name"
        '
        'CMBGUESTNAME
        '
        Me.CMBGUESTNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBGUESTNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBGUESTNAME.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBGUESTNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBGUESTNAME.FormattingEnabled = True
        Me.CMBGUESTNAME.Items.AddRange(New Object() {""})
        Me.CMBGUESTNAME.Location = New System.Drawing.Point(125, 109)
        Me.CMBGUESTNAME.Name = "CMBGUESTNAME"
        Me.CMBGUESTNAME.Size = New System.Drawing.Size(227, 23)
        Me.CMBGUESTNAME.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(230, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 15)
        Me.Label4.TabIndex = 721
        Me.Label4.Text = "Date"
        '
        'DTFOREXENQDATE
        '
        Me.DTFOREXENQDATE.CustomFormat = "dd/MM/yyyy"
        Me.DTFOREXENQDATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTFOREXENQDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTFOREXENQDATE.Location = New System.Drawing.Point(265, 79)
        Me.DTFOREXENQDATE.Name = "DTFOREXENQDATE"
        Me.DTFOREXENQDATE.Size = New System.Drawing.Size(87, 23)
        Me.DTFOREXENQDATE.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(53, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 15)
        Me.Label3.TabIndex = 324
        Me.Label3.Text = "Enquiry No."
        '
        'TXTFOREXENQNO
        '
        Me.TXTFOREXENQNO.BackColor = System.Drawing.Color.Linen
        Me.TXTFOREXENQNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFOREXENQNO.Location = New System.Drawing.Point(124, 79)
        Me.TXTFOREXENQNO.Name = "TXTFOREXENQNO"
        Me.TXTFOREXENQNO.ReadOnly = True
        Me.TXTFOREXENQNO.Size = New System.Drawing.Size(87, 23)
        Me.TXTFOREXENQNO.TabIndex = 321
        Me.TXTFOREXENQNO.TabStop = False
        '
        'CMDDELETE
        '
        Me.CMDDELETE.BackColor = System.Drawing.Color.Transparent
        Me.CMDDELETE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDDELETE.FlatAppearance.BorderSize = 0
        Me.CMDDELETE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDDELETE.ForeColor = System.Drawing.Color.Black
        Me.CMDDELETE.Location = New System.Drawing.Point(351, 401)
        Me.CMDDELETE.Name = "CMDDELETE"
        Me.CMDDELETE.Size = New System.Drawing.Size(80, 28)
        Me.CMDDELETE.TabIndex = 20
        Me.CMDDELETE.Text = "&Delete"
        Me.CMDDELETE.UseVisualStyleBackColor = False
        '
        'CMDEXIT
        '
        Me.CMDEXIT.BackColor = System.Drawing.Color.Transparent
        Me.CMDEXIT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDEXIT.FlatAppearance.BorderSize = 0
        Me.CMDEXIT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEXIT.ForeColor = System.Drawing.Color.Black
        Me.CMDEXIT.Location = New System.Drawing.Point(437, 401)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 21
        Me.CMDEXIT.Text = "&Exit"
        Me.CMDEXIT.UseVisualStyleBackColor = False
        '
        'CMDOK
        '
        Me.CMDOK.BackColor = System.Drawing.Color.Transparent
        Me.CMDOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDOK.FlatAppearance.BorderSize = 0
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.Black
        Me.CMDOK.Location = New System.Drawing.Point(179, 402)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(80, 28)
        Me.CMDOK.TabIndex = 18
        Me.CMDOK.Text = "&Save"
        Me.CMDOK.UseVisualStyleBackColor = False
        '
        'CMDCLEAR
        '
        Me.CMDCLEAR.BackColor = System.Drawing.Color.Transparent
        Me.CMDCLEAR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDCLEAR.FlatAppearance.BorderSize = 0
        Me.CMDCLEAR.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDCLEAR.ForeColor = System.Drawing.Color.Black
        Me.CMDCLEAR.Location = New System.Drawing.Point(265, 401)
        Me.CMDCLEAR.Name = "CMDCLEAR"
        Me.CMDCLEAR.Size = New System.Drawing.Size(80, 28)
        Me.CMDCLEAR.TabIndex = 19
        Me.CMDCLEAR.Text = "&Clear"
        Me.CMDCLEAR.UseVisualStyleBackColor = False
        '
        'tstxtbillno
        '
        Me.tstxtbillno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tstxtbillno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstxtbillno.Location = New System.Drawing.Point(216, 2)
        Me.tstxtbillno.Name = "tstxtbillno"
        Me.tstxtbillno.Size = New System.Drawing.Size(62, 21)
        Me.tstxtbillno.TabIndex = 15
        Me.tstxtbillno.TabStop = False
        Me.tstxtbillno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(9, 232)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(114, 15)
        Me.Label28.TabIndex = 567
        Me.Label28.Text = "Enquiry Handled By"
        '
        'CMBBOOKEDBY
        '
        Me.CMBBOOKEDBY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBBOOKEDBY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBBOOKEDBY.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBBOOKEDBY.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBBOOKEDBY.FormattingEnabled = True
        Me.CMBBOOKEDBY.Items.AddRange(New Object() {""})
        Me.CMBBOOKEDBY.Location = New System.Drawing.Point(125, 228)
        Me.CMBBOOKEDBY.Name = "CMBBOOKEDBY"
        Me.CMBBOOKEDBY.Size = New System.Drawing.Size(227, 23)
        Me.CMBBOOKEDBY.TabIndex = 7
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(79, 203)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(44, 15)
        Me.Label13.TabIndex = 404
        Me.Label13.Text = "Source"
        '
        'CMBSOURCE
        '
        Me.CMBSOURCE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBSOURCE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBSOURCE.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBSOURCE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBSOURCE.FormattingEnabled = True
        Me.CMBSOURCE.Items.AddRange(New Object() {""})
        Me.CMBSOURCE.Location = New System.Drawing.Point(125, 199)
        Me.CMBSOURCE.Name = "CMBSOURCE"
        Me.CMBSOURCE.Size = New System.Drawing.Size(227, 23)
        Me.CMBSOURCE.TabIndex = 6
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(12, 32)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(146, 25)
        Me.lbl.TabIndex = 320
        Me.lbl.Text = "Forex Enquiry"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripButton, Me.SaveToolStripButton, Me.ToolStripprint, Me.ToolStripSeparator2, Me.toolprevious, Me.toolnext, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(697, 25)
        Me.ToolStrip1.TabIndex = 319
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'OpenToolStripButton
        '
        Me.OpenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OpenToolStripButton.Image = CType(resources.GetObject("OpenToolStripButton.Image"), System.Drawing.Image)
        Me.OpenToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenToolStripButton.Name = "OpenToolStripButton"
        Me.OpenToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.OpenToolStripButton.Text = "&Open"
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.SaveToolStripButton.Text = "&Save"
        '
        'ToolStripprint
        '
        Me.ToolStripprint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripprint.Image = CType(resources.GetObject("ToolStripprint.Image"), System.Drawing.Image)
        Me.ToolStripprint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripprint.Name = "ToolStripprint"
        Me.ToolStripprint.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripprint.Text = "Print"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'toolprevious
        '
        Me.toolprevious.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.toolprevious.Image = Global.HOSPITALITY.My.Resources.Resources.POINT02
        Me.toolprevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolprevious.Name = "toolprevious"
        Me.toolprevious.Size = New System.Drawing.Size(73, 22)
        Me.toolprevious.Text = "Previous"
        '
        'toolnext
        '
        Me.toolnext.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.toolnext.Image = Global.HOSPITALITY.My.Resources.Resources.POINT04
        Me.toolnext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.toolnext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolnext.Name = "toolnext"
        Me.toolnext.Size = New System.Drawing.Size(51, 22)
        Me.toolnext.Text = "Next"
        Me.toolnext.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'ForexEnquiry
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(697, 454)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "ForexEnquiry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Forex Enquiry"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel2.ResumeLayout(False)
        Me.BlendPanel2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents BlendPanel2 As VbPowerPack.BlendPanel
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents CMBGUESTNAME As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DTFOREXENQDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TXTFOREXENQNO As System.Windows.Forms.TextBox
    Friend WithEvents CMDDELETE As System.Windows.Forms.Button
    Friend WithEvents CMDEXIT As System.Windows.Forms.Button
    Friend WithEvents CMDOK As System.Windows.Forms.Button
    Friend WithEvents CMDCLEAR As System.Windows.Forms.Button
    Friend WithEvents tstxtbillno As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents CMBBOOKEDBY As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents CMBSOURCE As System.Windows.Forms.ComboBox
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents OpenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripprint As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolprevious As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolnext As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CMBSTATUS As System.Windows.Forms.ComboBox
    Friend WithEvents TXTAGENT As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TXTREMARKS As System.Windows.Forms.TextBox
    Friend WithEvents TXTCURRENCYAMT As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CMBCURRENCY As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TXTCLOSEREMARKS As System.Windows.Forms.TextBox
    Friend WithEvents TXTGTOTAL As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TXTST As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TXTAMTINR As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents LBLRETURNDATE As System.Windows.Forms.Label
    Friend WithEvents MTBRETURNDATE As System.Windows.Forms.MaskedTextBox
    Friend WithEvents CMBBUYSELL As System.Windows.Forms.ComboBox
    Friend WithEvents TXTROE As System.Windows.Forms.TextBox
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents TXTADDGUESTNAME As System.Windows.Forms.TextBox
    Friend WithEvents CMBOTHERCHGS As System.Windows.Forms.ComboBox
    Friend WithEvents cmbaddsub As System.Windows.Forms.ComboBox
    Friend WithEvents TXTOTHERCHGS As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents txtroundoff As System.Windows.Forms.TextBox
    Friend WithEvents TXTADD As System.Windows.Forms.TextBox
    Friend WithEvents CMBOTHERCHGSCODE As System.Windows.Forms.ComboBox
    Friend WithEvents TXTCOMM As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CMBPRODUCT As System.Windows.Forms.ComboBox
End Class
