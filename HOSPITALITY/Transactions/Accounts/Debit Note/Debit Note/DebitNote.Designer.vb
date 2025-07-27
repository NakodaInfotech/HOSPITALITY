<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DebitNote
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DebitNote))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripdelete = New System.Windows.Forms.ToolStripButton()
        Me.TOOLEINV = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.toolprevious = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolnext = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.tstxtbillno = New System.Windows.Forms.TextBox()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.DNDATE = New System.Windows.Forms.MaskedTextBox()
        Me.TXTNEWIMGPATH = New System.Windows.Forms.TextBox()
        Me.PBQRCODE = New System.Windows.Forms.PictureBox()
        Me.TXTFILENAME = New System.Windows.Forms.TextBox()
        Me.CMDUPLOADIRN = New System.Windows.Forms.Button()
        Me.txtimgpath = New System.Windows.Forms.TextBox()
        Me.CMDGETQRCODE = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.ACKDATE = New System.Windows.Forms.DateTimePicker()
        Me.TXTIRNNO = New System.Windows.Forms.TextBox()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.TXTACKNO = New System.Windows.Forms.TextBox()
        Me.LBLEINVGENERATED = New System.Windows.Forms.Label()
        Me.CHKMANUAL = New System.Windows.Forms.CheckBox()
        Me.LBLSTATECODE = New System.Windows.Forms.Label()
        Me.TXTSTATECODE = New System.Windows.Forms.TextBox()
        Me.LBLHSNCODE = New System.Windows.Forms.Label()
        Me.TXTHSNCODE = New System.Windows.Forms.TextBox()
        Me.LBLHSNDESC = New System.Windows.Forms.Label()
        Me.CMBHSNITEMDESC = New System.Windows.Forms.ComboBox()
        Me.CHKTAXSERVCHGS = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TXTPURSERVCHGS = New System.Windows.Forms.TextBox()
        Me.TXTIGSTAMT = New System.Windows.Forms.TextBox()
        Me.LBLIGST = New System.Windows.Forms.Label()
        Me.TXTIGSTPER = New System.Windows.Forms.TextBox()
        Me.LBLSGST = New System.Windows.Forms.Label()
        Me.TXTSGSTPER = New System.Windows.Forms.TextBox()
        Me.TXTSGSTAMT = New System.Windows.Forms.TextBox()
        Me.TXTCGSTAMT = New System.Windows.Forms.TextBox()
        Me.LBLCGST = New System.Windows.Forms.Label()
        Me.TXTCGSTPER = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXTDP = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ARRIVALDATE = New System.Windows.Forms.DateTimePicker()
        Me.CMBACCCODE = New System.Windows.Forms.ComboBox()
        Me.CMBNAME = New System.Windows.Forms.ComboBox()
        Me.TXTOTHERCHGSADD = New System.Windows.Forms.TextBox()
        Me.CMBOTHERCHGSCODE = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXTBILLNO = New System.Windows.Forms.TextBox()
        Me.CMBADDTAX = New System.Windows.Forms.ComboBox()
        Me.TXTADDTAX = New System.Windows.Forms.TextBox()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.LBLEXTRACHGS = New System.Windows.Forms.Label()
        Me.TXTPUREXTRACHGS = New System.Windows.Forms.TextBox()
        Me.PBPURTDSDEL = New System.Windows.Forms.PictureBox()
        Me.TXTPURTDSPER = New System.Windows.Forms.TextBox()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.TXTPURTDSRS = New System.Windows.Forms.TextBox()
        Me.PBCOMMRECDDEL = New System.Windows.Forms.PictureBox()
        Me.TXTCOMMRECDPER = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.TXTCOMMRECDRS = New System.Windows.Forms.TextBox()
        Me.TXTHOTELNAME = New System.Windows.Forms.TextBox()
        Me.TXTGUESTNAME = New System.Windows.Forms.TextBox()
        Me.LBLHOTELNAME = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CMBOTHERCHGS = New System.Windows.Forms.ComboBox()
        Me.PBDISCDEL = New System.Windows.Forms.PictureBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.TXTTOTALPURAMT = New System.Windows.Forms.TextBox()
        Me.txtgrandtotal = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.cmbaddsub = New System.Windows.Forms.ComboBox()
        Me.txtotherchg = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.txtroundoff = New System.Windows.Forms.TextBox()
        Me.cmbtax = New System.Windows.Forms.ComboBox()
        Me.txttax = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TXTSUBTOTAL = New System.Windows.Forms.TextBox()
        Me.TXTDISCPER = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TXTDISCRS = New System.Windows.Forms.TextBox()
        Me.cmdclear = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtremarks = New System.Windows.Forms.TextBox()
        Me.cmbregister = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TXTDNNO = New System.Windows.Forms.TextBox()
        Me.lblsrno = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbl = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape6 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.CHKGSTR1 = New System.Windows.Forms.CheckBox()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.PBQRCODE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBPURTDSDEL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBCOMMRECDDEL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBDISCDEL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripButton, Me.SaveToolStripButton, Me.PrintToolStripButton, Me.ToolStripdelete, Me.TOOLEINV, Me.toolStripSeparator, Me.toolprevious, Me.ToolStripSeparator2, Me.toolnext, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(778, 25)
        Me.ToolStrip1.TabIndex = 285
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
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = CType(resources.GetObject("PrintToolStripButton.Image"), System.Drawing.Image)
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintToolStripButton.Text = "&Print"
        '
        'ToolStripdelete
        '
        Me.ToolStripdelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripdelete.Image = CType(resources.GetObject("ToolStripdelete.Image"), System.Drawing.Image)
        Me.ToolStripdelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripdelete.Name = "ToolStripdelete"
        Me.ToolStripdelete.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripdelete.Text = "Delete Debit Note"
        '
        'TOOLEINV
        '
        Me.TOOLEINV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLEINV.Image = Global.HOSPITALITY.My.Resources.Resources.EINVOICE_LOGO
        Me.TOOLEINV.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLEINV.Name = "TOOLEINV"
        Me.TOOLEINV.Size = New System.Drawing.Size(23, 22)
        Me.TOOLEINV.Text = "Generate E-Invoice"
        Me.TOOLEINV.Visible = False
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'toolprevious
        '
        Me.toolprevious.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toolprevious.Image = Global.HOSPITALITY.My.Resources.Resources.POINT02
        Me.toolprevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolprevious.Name = "toolprevious"
        Me.toolprevious.Size = New System.Drawing.Size(73, 22)
        Me.toolprevious.Text = "Previous"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'toolnext
        '
        Me.toolnext.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toolnext.Image = Global.HOSPITALITY.My.Resources.Resources.POINT04
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
        'tstxtbillno
        '
        Me.tstxtbillno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tstxtbillno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstxtbillno.Location = New System.Drawing.Point(272, 1)
        Me.tstxtbillno.Name = "tstxtbillno"
        Me.tstxtbillno.Size = New System.Drawing.Size(67, 22)
        Me.tstxtbillno.TabIndex = 1
        Me.tstxtbillno.TabStop = False
        Me.tstxtbillno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CHKGSTR1)
        Me.BlendPanel1.Controls.Add(Me.DNDATE)
        Me.BlendPanel1.Controls.Add(Me.TXTNEWIMGPATH)
        Me.BlendPanel1.Controls.Add(Me.PBQRCODE)
        Me.BlendPanel1.Controls.Add(Me.TXTFILENAME)
        Me.BlendPanel1.Controls.Add(Me.CMDUPLOADIRN)
        Me.BlendPanel1.Controls.Add(Me.txtimgpath)
        Me.BlendPanel1.Controls.Add(Me.CMDGETQRCODE)
        Me.BlendPanel1.Controls.Add(Me.Label7)
        Me.BlendPanel1.Controls.Add(Me.Label58)
        Me.BlendPanel1.Controls.Add(Me.ACKDATE)
        Me.BlendPanel1.Controls.Add(Me.TXTIRNNO)
        Me.BlendPanel1.Controls.Add(Me.Label56)
        Me.BlendPanel1.Controls.Add(Me.TXTACKNO)
        Me.BlendPanel1.Controls.Add(Me.LBLEINVGENERATED)
        Me.BlendPanel1.Controls.Add(Me.CHKMANUAL)
        Me.BlendPanel1.Controls.Add(Me.LBLSTATECODE)
        Me.BlendPanel1.Controls.Add(Me.TXTSTATECODE)
        Me.BlendPanel1.Controls.Add(Me.LBLHSNCODE)
        Me.BlendPanel1.Controls.Add(Me.TXTHSNCODE)
        Me.BlendPanel1.Controls.Add(Me.LBLHSNDESC)
        Me.BlendPanel1.Controls.Add(Me.CMBHSNITEMDESC)
        Me.BlendPanel1.Controls.Add(Me.CHKTAXSERVCHGS)
        Me.BlendPanel1.Controls.Add(Me.Label8)
        Me.BlendPanel1.Controls.Add(Me.TXTPURSERVCHGS)
        Me.BlendPanel1.Controls.Add(Me.TXTIGSTAMT)
        Me.BlendPanel1.Controls.Add(Me.LBLIGST)
        Me.BlendPanel1.Controls.Add(Me.TXTIGSTPER)
        Me.BlendPanel1.Controls.Add(Me.LBLSGST)
        Me.BlendPanel1.Controls.Add(Me.TXTSGSTPER)
        Me.BlendPanel1.Controls.Add(Me.TXTSGSTAMT)
        Me.BlendPanel1.Controls.Add(Me.TXTCGSTAMT)
        Me.BlendPanel1.Controls.Add(Me.LBLCGST)
        Me.BlendPanel1.Controls.Add(Me.TXTCGSTPER)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.TXTDP)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.ARRIVALDATE)
        Me.BlendPanel1.Controls.Add(Me.CMBACCCODE)
        Me.BlendPanel1.Controls.Add(Me.CMBNAME)
        Me.BlendPanel1.Controls.Add(Me.TXTOTHERCHGSADD)
        Me.BlendPanel1.Controls.Add(Me.CMBOTHERCHGSCODE)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.TXTBILLNO)
        Me.BlendPanel1.Controls.Add(Me.CMBADDTAX)
        Me.BlendPanel1.Controls.Add(Me.TXTADDTAX)
        Me.BlendPanel1.Controls.Add(Me.Label63)
        Me.BlendPanel1.Controls.Add(Me.LBLEXTRACHGS)
        Me.BlendPanel1.Controls.Add(Me.TXTPUREXTRACHGS)
        Me.BlendPanel1.Controls.Add(Me.PBPURTDSDEL)
        Me.BlendPanel1.Controls.Add(Me.TXTPURTDSPER)
        Me.BlendPanel1.Controls.Add(Me.Label48)
        Me.BlendPanel1.Controls.Add(Me.TXTPURTDSRS)
        Me.BlendPanel1.Controls.Add(Me.PBCOMMRECDDEL)
        Me.BlendPanel1.Controls.Add(Me.TXTCOMMRECDPER)
        Me.BlendPanel1.Controls.Add(Me.Label41)
        Me.BlendPanel1.Controls.Add(Me.TXTCOMMRECDRS)
        Me.BlendPanel1.Controls.Add(Me.TXTHOTELNAME)
        Me.BlendPanel1.Controls.Add(Me.TXTGUESTNAME)
        Me.BlendPanel1.Controls.Add(Me.LBLHOTELNAME)
        Me.BlendPanel1.Controls.Add(Me.Label33)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.CMBOTHERCHGS)
        Me.BlendPanel1.Controls.Add(Me.PBDISCDEL)
        Me.BlendPanel1.Controls.Add(Me.Label51)
        Me.BlendPanel1.Controls.Add(Me.TXTTOTALPURAMT)
        Me.BlendPanel1.Controls.Add(Me.txtgrandtotal)
        Me.BlendPanel1.Controls.Add(Me.Label36)
        Me.BlendPanel1.Controls.Add(Me.cmbaddsub)
        Me.BlendPanel1.Controls.Add(Me.txtotherchg)
        Me.BlendPanel1.Controls.Add(Me.Label38)
        Me.BlendPanel1.Controls.Add(Me.txtroundoff)
        Me.BlendPanel1.Controls.Add(Me.cmbtax)
        Me.BlendPanel1.Controls.Add(Me.txttax)
        Me.BlendPanel1.Controls.Add(Me.Label32)
        Me.BlendPanel1.Controls.Add(Me.Label25)
        Me.BlendPanel1.Controls.Add(Me.TXTSUBTOTAL)
        Me.BlendPanel1.Controls.Add(Me.TXTDISCPER)
        Me.BlendPanel1.Controls.Add(Me.Label24)
        Me.BlendPanel1.Controls.Add(Me.TXTDISCRS)
        Me.BlendPanel1.Controls.Add(Me.cmdclear)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.txtremarks)
        Me.BlendPanel1.Controls.Add(Me.cmbregister)
        Me.BlendPanel1.Controls.Add(Me.Label23)
        Me.BlendPanel1.Controls.Add(Me.TXTDNNO)
        Me.BlendPanel1.Controls.Add(Me.lblsrno)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Controls.Add(Me.ShapeContainer1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 25)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(778, 557)
        Me.BlendPanel1.TabIndex = 0
        '
        'DNDATE
        '
        Me.DNDATE.AsciiOnly = True
        Me.DNDATE.BackColor = System.Drawing.Color.LemonChiffon
        Me.DNDATE.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.DNDATE.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.DNDATE.Location = New System.Drawing.Point(484, 55)
        Me.DNDATE.Mask = "00/00/0000"
        Me.DNDATE.Name = "DNDATE"
        Me.DNDATE.Size = New System.Drawing.Size(87, 23)
        Me.DNDATE.TabIndex = 1
        Me.DNDATE.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.DNDATE.ValidatingType = GetType(Date)
        '
        'TXTNEWIMGPATH
        '
        Me.TXTNEWIMGPATH.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNEWIMGPATH.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTNEWIMGPATH.Location = New System.Drawing.Point(642, 58)
        Me.TXTNEWIMGPATH.Multiline = True
        Me.TXTNEWIMGPATH.Name = "TXTNEWIMGPATH"
        Me.TXTNEWIMGPATH.Size = New System.Drawing.Size(27, 22)
        Me.TXTNEWIMGPATH.TabIndex = 966
        Me.TXTNEWIMGPATH.Visible = False
        '
        'PBQRCODE
        '
        Me.PBQRCODE.BackColor = System.Drawing.Color.Transparent
        Me.PBQRCODE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PBQRCODE.Location = New System.Drawing.Point(590, 407)
        Me.PBQRCODE.Name = "PBQRCODE"
        Me.PBQRCODE.Size = New System.Drawing.Size(90, 90)
        Me.PBQRCODE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBQRCODE.TabIndex = 934
        Me.PBQRCODE.TabStop = False
        '
        'TXTFILENAME
        '
        Me.TXTFILENAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFILENAME.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTFILENAME.Location = New System.Drawing.Point(624, 59)
        Me.TXTFILENAME.Multiline = True
        Me.TXTFILENAME.Name = "TXTFILENAME"
        Me.TXTFILENAME.Size = New System.Drawing.Size(10, 22)
        Me.TXTFILENAME.TabIndex = 965
        Me.TXTFILENAME.Visible = False
        '
        'CMDUPLOADIRN
        '
        Me.CMDUPLOADIRN.BackColor = System.Drawing.Color.Transparent
        Me.CMDUPLOADIRN.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDUPLOADIRN.FlatAppearance.BorderSize = 0
        Me.CMDUPLOADIRN.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDUPLOADIRN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDUPLOADIRN.Location = New System.Drawing.Point(471, 434)
        Me.CMDUPLOADIRN.Name = "CMDUPLOADIRN"
        Me.CMDUPLOADIRN.Size = New System.Drawing.Size(100, 27)
        Me.CMDUPLOADIRN.TabIndex = 935
        Me.CMDUPLOADIRN.Text = "&Upload"
        Me.CMDUPLOADIRN.UseVisualStyleBackColor = False
        '
        'txtimgpath
        '
        Me.txtimgpath.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtimgpath.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtimgpath.Location = New System.Drawing.Point(642, 81)
        Me.txtimgpath.Multiline = True
        Me.txtimgpath.Name = "txtimgpath"
        Me.txtimgpath.Size = New System.Drawing.Size(12, 22)
        Me.txtimgpath.TabIndex = 964
        Me.txtimgpath.Visible = False
        '
        'CMDGETQRCODE
        '
        Me.CMDGETQRCODE.BackColor = System.Drawing.Color.Transparent
        Me.CMDGETQRCODE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDGETQRCODE.FlatAppearance.BorderSize = 0
        Me.CMDGETQRCODE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDGETQRCODE.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDGETQRCODE.Location = New System.Drawing.Point(471, 467)
        Me.CMDGETQRCODE.Name = "CMDGETQRCODE"
        Me.CMDGETQRCODE.Size = New System.Drawing.Size(100, 27)
        Me.CMDGETQRCODE.TabIndex = 936
        Me.CMDGETQRCODE.Text = "&Get QRCode"
        Me.CMDGETQRCODE.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(69, 410)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(26, 14)
        Me.Label7.TabIndex = 941
        Me.Label7.Text = "IRN"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.BackColor = System.Drawing.Color.Transparent
        Me.Label58.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.ForeColor = System.Drawing.Color.Black
        Me.Label58.Location = New System.Drawing.Point(52, 438)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(43, 14)
        Me.Label58.TabIndex = 938
        Me.Label58.Text = "Ack No"
        Me.Label58.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ACKDATE
        '
        Me.ACKDATE.CustomFormat = "dd/MM/yyyy"
        Me.ACKDATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ACKDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.ACKDATE.Location = New System.Drawing.Point(98, 463)
        Me.ACKDATE.Name = "ACKDATE"
        Me.ACKDATE.Size = New System.Drawing.Size(85, 23)
        Me.ACKDATE.TabIndex = 939
        '
        'TXTIRNNO
        '
        Me.TXTIRNNO.BackColor = System.Drawing.Color.White
        Me.TXTIRNNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTIRNNO.Location = New System.Drawing.Point(98, 406)
        Me.TXTIRNNO.Name = "TXTIRNNO"
        Me.TXTIRNNO.Size = New System.Drawing.Size(473, 22)
        Me.TXTIRNNO.TabIndex = 932
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.BackColor = System.Drawing.Color.Transparent
        Me.Label56.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label56.Location = New System.Drawing.Point(41, 467)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(54, 15)
        Me.Label56.TabIndex = 940
        Me.Label56.Text = "Ack Date"
        Me.Label56.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTACKNO
        '
        Me.TXTACKNO.BackColor = System.Drawing.Color.White
        Me.TXTACKNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTACKNO.Location = New System.Drawing.Point(98, 434)
        Me.TXTACKNO.Name = "TXTACKNO"
        Me.TXTACKNO.Size = New System.Drawing.Size(170, 23)
        Me.TXTACKNO.TabIndex = 937
        Me.TXTACKNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LBLEINVGENERATED
        '
        Me.LBLEINVGENERATED.AutoSize = True
        Me.LBLEINVGENERATED.BackColor = System.Drawing.Color.Transparent
        Me.LBLEINVGENERATED.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLEINVGENERATED.Location = New System.Drawing.Point(287, 435)
        Me.LBLEINVGENERATED.Name = "LBLEINVGENERATED"
        Me.LBLEINVGENERATED.Size = New System.Drawing.Size(168, 26)
        Me.LBLEINVGENERATED.TabIndex = 955
        Me.LBLEINVGENERATED.Text = "E-INV GENERATED"
        Me.LBLEINVGENERATED.Visible = False
        '
        'CHKMANUAL
        '
        Me.CHKMANUAL.AutoSize = True
        Me.CHKMANUAL.BackColor = System.Drawing.Color.Transparent
        Me.CHKMANUAL.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKMANUAL.Location = New System.Drawing.Point(642, 210)
        Me.CHKMANUAL.Name = "CHKMANUAL"
        Me.CHKMANUAL.Size = New System.Drawing.Size(92, 19)
        Me.CHKMANUAL.TabIndex = 918
        Me.CHKMANUAL.Text = "Manual GST"
        Me.CHKMANUAL.UseVisualStyleBackColor = False
        '
        'LBLSTATECODE
        '
        Me.LBLSTATECODE.AutoSize = True
        Me.LBLSTATECODE.BackColor = System.Drawing.Color.Transparent
        Me.LBLSTATECODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLSTATECODE.Location = New System.Drawing.Point(202, 91)
        Me.LBLSTATECODE.Name = "LBLSTATECODE"
        Me.LBLSTATECODE.Size = New System.Drawing.Size(68, 14)
        Me.LBLSTATECODE.TabIndex = 891
        Me.LBLSTATECODE.Text = " State Code"
        '
        'TXTSTATECODE
        '
        Me.TXTSTATECODE.BackColor = System.Drawing.Color.Linen
        Me.TXTSTATECODE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTSTATECODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSTATECODE.Location = New System.Drawing.Point(272, 87)
        Me.TXTSTATECODE.MaxLength = 10
        Me.TXTSTATECODE.Name = "TXTSTATECODE"
        Me.TXTSTATECODE.ReadOnly = True
        Me.TXTSTATECODE.Size = New System.Drawing.Size(56, 22)
        Me.TXTSTATECODE.TabIndex = 890
        Me.TXTSTATECODE.TabStop = False
        Me.TXTSTATECODE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LBLHSNCODE
        '
        Me.LBLHSNCODE.AutoSize = True
        Me.LBLHSNCODE.BackColor = System.Drawing.Color.Transparent
        Me.LBLHSNCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLHSNCODE.Location = New System.Drawing.Point(38, 222)
        Me.LBLHSNCODE.Name = "LBLHSNCODE"
        Me.LBLHSNCODE.Size = New System.Drawing.Size(59, 14)
        Me.LBLHSNCODE.TabIndex = 889
        Me.LBLHSNCODE.Text = "HSN Code"
        '
        'TXTHSNCODE
        '
        Me.TXTHSNCODE.BackColor = System.Drawing.Color.Linen
        Me.TXTHSNCODE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTHSNCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTHSNCODE.Location = New System.Drawing.Point(99, 218)
        Me.TXTHSNCODE.MaxLength = 10
        Me.TXTHSNCODE.Name = "TXTHSNCODE"
        Me.TXTHSNCODE.ReadOnly = True
        Me.TXTHSNCODE.Size = New System.Drawing.Size(90, 22)
        Me.TXTHSNCODE.TabIndex = 888
        Me.TXTHSNCODE.TabStop = False
        Me.TXTHSNCODE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LBLHSNDESC
        '
        Me.LBLHSNDESC.AutoSize = True
        Me.LBLHSNDESC.BackColor = System.Drawing.Color.Transparent
        Me.LBLHSNDESC.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLHSNDESC.Location = New System.Drawing.Point(36, 197)
        Me.LBLHSNDESC.Name = "LBLHSNDESC"
        Me.LBLHSNDESC.Size = New System.Drawing.Size(61, 14)
        Me.LBLHSNDESC.TabIndex = 887
        Me.LBLHSNDESC.Text = "HSN Desc."
        '
        'CMBHSNITEMDESC
        '
        Me.CMBHSNITEMDESC.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBHSNITEMDESC.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBHSNITEMDESC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBHSNITEMDESC.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CMBHSNITEMDESC.FormattingEnabled = True
        Me.CMBHSNITEMDESC.Location = New System.Drawing.Point(99, 193)
        Me.CMBHSNITEMDESC.MaxDropDownItems = 14
        Me.CMBHSNITEMDESC.Name = "CMBHSNITEMDESC"
        Me.CMBHSNITEMDESC.Size = New System.Drawing.Size(90, 22)
        Me.CMBHSNITEMDESC.TabIndex = 886
        '
        'CHKTAXSERVCHGS
        '
        Me.CHKTAXSERVCHGS.AutoSize = True
        Me.CHKTAXSERVCHGS.BackColor = System.Drawing.Color.Transparent
        Me.CHKTAXSERVCHGS.Location = New System.Drawing.Point(577, 232)
        Me.CHKTAXSERVCHGS.Name = "CHKTAXSERVCHGS"
        Me.CHKTAXSERVCHGS.Size = New System.Drawing.Size(110, 18)
        Me.CHKTAXSERVCHGS.TabIndex = 885
        Me.CHKTAXSERVCHGS.Text = "On Service Chgs"
        Me.CHKTAXSERVCHGS.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(358, 234)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 14)
        Me.Label8.TabIndex = 883
        Me.Label8.Text = "Service Charges"
        '
        'TXTPURSERVCHGS
        '
        Me.TXTPURSERVCHGS.BackColor = System.Drawing.Color.White
        Me.TXTPURSERVCHGS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPURSERVCHGS.ForeColor = System.Drawing.Color.Black
        Me.TXTPURSERVCHGS.Location = New System.Drawing.Point(481, 230)
        Me.TXTPURSERVCHGS.Name = "TXTPURSERVCHGS"
        Me.TXTPURSERVCHGS.Size = New System.Drawing.Size(90, 22)
        Me.TXTPURSERVCHGS.TabIndex = 882
        Me.TXTPURSERVCHGS.Text = "0.00"
        Me.TXTPURSERVCHGS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTIGSTAMT
        '
        Me.TXTIGSTAMT.BackColor = System.Drawing.Color.Linen
        Me.TXTIGSTAMT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTIGSTAMT.ForeColor = System.Drawing.Color.Black
        Me.TXTIGSTAMT.Location = New System.Drawing.Point(686, 306)
        Me.TXTIGSTAMT.Name = "TXTIGSTAMT"
        Me.TXTIGSTAMT.ReadOnly = True
        Me.TXTIGSTAMT.Size = New System.Drawing.Size(53, 22)
        Me.TXTIGSTAMT.TabIndex = 881
        Me.TXTIGSTAMT.TabStop = False
        Me.TXTIGSTAMT.Text = "0.00"
        Me.TXTIGSTAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LBLIGST
        '
        Me.LBLIGST.AutoSize = True
        Me.LBLIGST.BackColor = System.Drawing.Color.Transparent
        Me.LBLIGST.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLIGST.Location = New System.Drawing.Point(606, 310)
        Me.LBLIGST.Name = "LBLIGST"
        Me.LBLIGST.Size = New System.Drawing.Size(34, 14)
        Me.LBLIGST.TabIndex = 880
        Me.LBLIGST.Text = "IGST "
        Me.LBLIGST.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTIGSTPER
        '
        Me.TXTIGSTPER.BackColor = System.Drawing.Color.Linen
        Me.TXTIGSTPER.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTIGSTPER.ForeColor = System.Drawing.Color.Black
        Me.TXTIGSTPER.Location = New System.Drawing.Point(642, 306)
        Me.TXTIGSTPER.Name = "TXTIGSTPER"
        Me.TXTIGSTPER.ReadOnly = True
        Me.TXTIGSTPER.Size = New System.Drawing.Size(38, 22)
        Me.TXTIGSTPER.TabIndex = 879
        Me.TXTIGSTPER.TabStop = False
        Me.TXTIGSTPER.Text = "0.00"
        Me.TXTIGSTPER.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LBLSGST
        '
        Me.LBLSGST.AutoSize = True
        Me.LBLSGST.BackColor = System.Drawing.Color.Transparent
        Me.LBLSGST.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLSGST.Location = New System.Drawing.Point(604, 286)
        Me.LBLSGST.Name = "LBLSGST"
        Me.LBLSGST.Size = New System.Drawing.Size(36, 14)
        Me.LBLSGST.TabIndex = 878
        Me.LBLSGST.Text = "SGST "
        Me.LBLSGST.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTSGSTPER
        '
        Me.TXTSGSTPER.BackColor = System.Drawing.Color.Linen
        Me.TXTSGSTPER.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSGSTPER.ForeColor = System.Drawing.Color.Black
        Me.TXTSGSTPER.Location = New System.Drawing.Point(642, 282)
        Me.TXTSGSTPER.Name = "TXTSGSTPER"
        Me.TXTSGSTPER.ReadOnly = True
        Me.TXTSGSTPER.Size = New System.Drawing.Size(38, 22)
        Me.TXTSGSTPER.TabIndex = 877
        Me.TXTSGSTPER.TabStop = False
        Me.TXTSGSTPER.Text = "0.00"
        Me.TXTSGSTPER.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTSGSTAMT
        '
        Me.TXTSGSTAMT.BackColor = System.Drawing.Color.Linen
        Me.TXTSGSTAMT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSGSTAMT.ForeColor = System.Drawing.Color.Black
        Me.TXTSGSTAMT.Location = New System.Drawing.Point(686, 282)
        Me.TXTSGSTAMT.Name = "TXTSGSTAMT"
        Me.TXTSGSTAMT.ReadOnly = True
        Me.TXTSGSTAMT.Size = New System.Drawing.Size(53, 22)
        Me.TXTSGSTAMT.TabIndex = 876
        Me.TXTSGSTAMT.TabStop = False
        Me.TXTSGSTAMT.Text = "0.00"
        Me.TXTSGSTAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTCGSTAMT
        '
        Me.TXTCGSTAMT.BackColor = System.Drawing.Color.Linen
        Me.TXTCGSTAMT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCGSTAMT.ForeColor = System.Drawing.Color.Black
        Me.TXTCGSTAMT.Location = New System.Drawing.Point(686, 258)
        Me.TXTCGSTAMT.Name = "TXTCGSTAMT"
        Me.TXTCGSTAMT.ReadOnly = True
        Me.TXTCGSTAMT.Size = New System.Drawing.Size(53, 22)
        Me.TXTCGSTAMT.TabIndex = 875
        Me.TXTCGSTAMT.TabStop = False
        Me.TXTCGSTAMT.Text = "0.00"
        Me.TXTCGSTAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LBLCGST
        '
        Me.LBLCGST.AutoSize = True
        Me.LBLCGST.BackColor = System.Drawing.Color.Transparent
        Me.LBLCGST.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCGST.Location = New System.Drawing.Point(604, 262)
        Me.LBLCGST.Name = "LBLCGST"
        Me.LBLCGST.Size = New System.Drawing.Size(36, 14)
        Me.LBLCGST.TabIndex = 874
        Me.LBLCGST.Text = "CGST "
        Me.LBLCGST.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTCGSTPER
        '
        Me.TXTCGSTPER.BackColor = System.Drawing.Color.Linen
        Me.TXTCGSTPER.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCGSTPER.ForeColor = System.Drawing.Color.Black
        Me.TXTCGSTPER.Location = New System.Drawing.Point(642, 258)
        Me.TXTCGSTPER.Name = "TXTCGSTPER"
        Me.TXTCGSTPER.ReadOnly = True
        Me.TXTCGSTPER.Size = New System.Drawing.Size(38, 22)
        Me.TXTCGSTPER.TabIndex = 873
        Me.TXTCGSTPER.TabStop = False
        Me.TXTCGSTPER.Text = "0.00"
        Me.TXTCGSTPER.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(8, 362)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 14)
        Me.Label3.TabIndex = 714
        Me.Label3.Text = "Direct Payment"
        '
        'TXTDP
        '
        Me.TXTDP.BackColor = System.Drawing.Color.Linen
        Me.TXTDP.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDP.ForeColor = System.Drawing.Color.Black
        Me.TXTDP.Location = New System.Drawing.Point(98, 358)
        Me.TXTDP.Name = "TXTDP"
        Me.TXTDP.ReadOnly = True
        Me.TXTDP.Size = New System.Drawing.Size(90, 22)
        Me.TXTDP.TabIndex = 713
        Me.TXTDP.TabStop = False
        Me.TXTDP.Text = "0.00"
        Me.TXTDP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(411, 86)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 14)
        Me.Label6.TabIndex = 712
        Me.Label6.Text = "Arrival Date"
        '
        'ARRIVALDATE
        '
        Me.ARRIVALDATE.CustomFormat = "dd/MM/yyyy"
        Me.ARRIVALDATE.Enabled = False
        Me.ARRIVALDATE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ARRIVALDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.ARRIVALDATE.Location = New System.Drawing.Point(484, 82)
        Me.ARRIVALDATE.Name = "ARRIVALDATE"
        Me.ARRIVALDATE.Size = New System.Drawing.Size(87, 22)
        Me.ARRIVALDATE.TabIndex = 711
        '
        'CMBACCCODE
        '
        Me.CMBACCCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBACCCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBACCCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBACCCODE.FormattingEnabled = True
        Me.CMBACCCODE.Items.AddRange(New Object() {""})
        Me.CMBACCCODE.Location = New System.Drawing.Point(163, 10)
        Me.CMBACCCODE.Name = "CMBACCCODE"
        Me.CMBACCCODE.Size = New System.Drawing.Size(74, 22)
        Me.CMBACCCODE.TabIndex = 705
        Me.CMBACCCODE.Visible = False
        '
        'CMBNAME
        '
        Me.CMBNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBNAME.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBNAME.FormattingEnabled = True
        Me.CMBNAME.Items.AddRange(New Object() {""})
        Me.CMBNAME.Location = New System.Drawing.Point(99, 166)
        Me.CMBNAME.Name = "CMBNAME"
        Me.CMBNAME.Size = New System.Drawing.Size(230, 22)
        Me.CMBNAME.TabIndex = 706
        '
        'TXTOTHERCHGSADD
        '
        Me.TXTOTHERCHGSADD.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTOTHERCHGSADD.ForeColor = System.Drawing.Color.DimGray
        Me.TXTOTHERCHGSADD.Location = New System.Drawing.Point(389, 33)
        Me.TXTOTHERCHGSADD.Multiline = True
        Me.TXTOTHERCHGSADD.Name = "TXTOTHERCHGSADD"
        Me.TXTOTHERCHGSADD.Size = New System.Drawing.Size(17, 18)
        Me.TXTOTHERCHGSADD.TabIndex = 704
        Me.TXTOTHERCHGSADD.Visible = False
        '
        'CMBOTHERCHGSCODE
        '
        Me.CMBOTHERCHGSCODE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBOTHERCHGSCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBOTHERCHGSCODE.FormattingEnabled = True
        Me.CMBOTHERCHGSCODE.Items.AddRange(New Object() {"", "Add", "Sub."})
        Me.CMBOTHERCHGSCODE.Location = New System.Drawing.Point(337, 29)
        Me.CMBOTHERCHGSCODE.Name = "CMBOTHERCHGSCODE"
        Me.CMBOTHERCHGSCODE.Size = New System.Drawing.Size(47, 22)
        Me.CMBOTHERCHGSCODE.TabIndex = 703
        Me.CMBOTHERCHGSCODE.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(53, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 14)
        Me.Label4.TabIndex = 702
        Me.Label4.Text = "Bill No"
        '
        'TXTBILLNO
        '
        Me.TXTBILLNO.BackColor = System.Drawing.Color.White
        Me.TXTBILLNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTBILLNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTBILLNO.ForeColor = System.Drawing.Color.Black
        Me.TXTBILLNO.Location = New System.Drawing.Point(99, 87)
        Me.TXTBILLNO.Name = "TXTBILLNO"
        Me.TXTBILLNO.Size = New System.Drawing.Size(90, 22)
        Me.TXTBILLNO.TabIndex = 2
        '
        'CMBADDTAX
        '
        Me.CMBADDTAX.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBADDTAX.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBADDTAX.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBADDTAX.FormattingEnabled = True
        Me.CMBADDTAX.Location = New System.Drawing.Point(407, 306)
        Me.CMBADDTAX.MaxDropDownItems = 14
        Me.CMBADDTAX.Name = "CMBADDTAX"
        Me.CMBADDTAX.Size = New System.Drawing.Size(73, 22)
        Me.CMBADDTAX.TabIndex = 13
        '
        'TXTADDTAX
        '
        Me.TXTADDTAX.BackColor = System.Drawing.Color.White
        Me.TXTADDTAX.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTADDTAX.ForeColor = System.Drawing.Color.Black
        Me.TXTADDTAX.Location = New System.Drawing.Point(481, 306)
        Me.TXTADDTAX.Name = "TXTADDTAX"
        Me.TXTADDTAX.ReadOnly = True
        Me.TXTADDTAX.Size = New System.Drawing.Size(90, 22)
        Me.TXTADDTAX.TabIndex = 14
        Me.TXTADDTAX.Text = "0.00"
        Me.TXTADDTAX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.BackColor = System.Drawing.Color.Transparent
        Me.Label63.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label63.ForeColor = System.Drawing.Color.Black
        Me.Label63.Location = New System.Drawing.Point(358, 310)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(48, 14)
        Me.Label63.TabIndex = 700
        Me.Label63.Text = "Add Tax"
        '
        'LBLEXTRACHGS
        '
        Me.LBLEXTRACHGS.AutoSize = True
        Me.LBLEXTRACHGS.BackColor = System.Drawing.Color.Transparent
        Me.LBLEXTRACHGS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLEXTRACHGS.Location = New System.Drawing.Point(358, 210)
        Me.LBLEXTRACHGS.Name = "LBLEXTRACHGS"
        Me.LBLEXTRACHGS.Size = New System.Drawing.Size(97, 14)
        Me.LBLEXTRACHGS.TabIndex = 697
        Me.LBLEXTRACHGS.Text = "Other Chgs (Add)"
        '
        'TXTPUREXTRACHGS
        '
        Me.TXTPUREXTRACHGS.BackColor = System.Drawing.Color.White
        Me.TXTPUREXTRACHGS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPUREXTRACHGS.ForeColor = System.Drawing.Color.Black
        Me.TXTPUREXTRACHGS.Location = New System.Drawing.Point(481, 206)
        Me.TXTPUREXTRACHGS.Name = "TXTPUREXTRACHGS"
        Me.TXTPUREXTRACHGS.Size = New System.Drawing.Size(90, 22)
        Me.TXTPUREXTRACHGS.TabIndex = 10
        Me.TXTPUREXTRACHGS.Text = "0.00"
        Me.TXTPUREXTRACHGS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PBPURTDSDEL
        '
        Me.PBPURTDSDEL.BackColor = System.Drawing.Color.Transparent
        Me.PBPURTDSDEL.Image = Global.HOSPITALITY.My.Resources.Resources.DELETE_ICON
        Me.PBPURTDSDEL.Location = New System.Drawing.Point(571, 186)
        Me.PBPURTDSDEL.Name = "PBPURTDSDEL"
        Me.PBPURTDSDEL.Size = New System.Drawing.Size(15, 15)
        Me.PBPURTDSDEL.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBPURTDSDEL.TabIndex = 695
        Me.PBPURTDSDEL.TabStop = False
        '
        'TXTPURTDSPER
        '
        Me.TXTPURTDSPER.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPURTDSPER.Location = New System.Drawing.Point(442, 182)
        Me.TXTPURTDSPER.Name = "TXTPURTDSPER"
        Me.TXTPURTDSPER.Size = New System.Drawing.Size(38, 22)
        Me.TXTPURTDSPER.TabIndex = 8
        Me.TXTPURTDSPER.Text = "0.00"
        Me.TXTPURTDSPER.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.BackColor = System.Drawing.Color.Transparent
        Me.Label48.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.Location = New System.Drawing.Point(358, 186)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(87, 14)
        Me.Label48.TabIndex = 694
        Me.Label48.Text = "TDS (Purchase)"
        '
        'TXTPURTDSRS
        '
        Me.TXTPURTDSRS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPURTDSRS.Location = New System.Drawing.Point(481, 182)
        Me.TXTPURTDSRS.Name = "TXTPURTDSRS"
        Me.TXTPURTDSRS.Size = New System.Drawing.Size(90, 22)
        Me.TXTPURTDSRS.TabIndex = 9
        Me.TXTPURTDSRS.Text = "0.00"
        Me.TXTPURTDSRS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PBCOMMRECDDEL
        '
        Me.PBCOMMRECDDEL.BackColor = System.Drawing.Color.Transparent
        Me.PBCOMMRECDDEL.Image = Global.HOSPITALITY.My.Resources.Resources.DELETE_ICON
        Me.PBCOMMRECDDEL.Location = New System.Drawing.Point(571, 162)
        Me.PBCOMMRECDDEL.Name = "PBCOMMRECDDEL"
        Me.PBCOMMRECDDEL.Size = New System.Drawing.Size(15, 15)
        Me.PBCOMMRECDDEL.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBCOMMRECDDEL.TabIndex = 691
        Me.PBCOMMRECDDEL.TabStop = False
        '
        'TXTCOMMRECDPER
        '
        Me.TXTCOMMRECDPER.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCOMMRECDPER.Location = New System.Drawing.Point(442, 158)
        Me.TXTCOMMRECDPER.Name = "TXTCOMMRECDPER"
        Me.TXTCOMMRECDPER.Size = New System.Drawing.Size(38, 22)
        Me.TXTCOMMRECDPER.TabIndex = 6
        Me.TXTCOMMRECDPER.Text = "0.00"
        Me.TXTCOMMRECDPER.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.BackColor = System.Drawing.Color.Transparent
        Me.Label41.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(358, 162)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(69, 14)
        Me.Label41.TabIndex = 690
        Me.Label41.Text = "Comm Recd"
        '
        'TXTCOMMRECDRS
        '
        Me.TXTCOMMRECDRS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCOMMRECDRS.Location = New System.Drawing.Point(481, 158)
        Me.TXTCOMMRECDRS.Name = "TXTCOMMRECDRS"
        Me.TXTCOMMRECDRS.Size = New System.Drawing.Size(90, 22)
        Me.TXTCOMMRECDRS.TabIndex = 7
        Me.TXTCOMMRECDRS.Text = "0.00"
        Me.TXTCOMMRECDRS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTHOTELNAME
        '
        Me.TXTHOTELNAME.BackColor = System.Drawing.Color.White
        Me.TXTHOTELNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTHOTELNAME.ForeColor = System.Drawing.Color.Black
        Me.TXTHOTELNAME.Location = New System.Drawing.Point(99, 140)
        Me.TXTHOTELNAME.Name = "TXTHOTELNAME"
        Me.TXTHOTELNAME.ReadOnly = True
        Me.TXTHOTELNAME.Size = New System.Drawing.Size(230, 22)
        Me.TXTHOTELNAME.TabIndex = 685
        Me.TXTHOTELNAME.TabStop = False
        '
        'TXTGUESTNAME
        '
        Me.TXTGUESTNAME.BackColor = System.Drawing.Color.White
        Me.TXTGUESTNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTGUESTNAME.ForeColor = System.Drawing.Color.Black
        Me.TXTGUESTNAME.Location = New System.Drawing.Point(99, 114)
        Me.TXTGUESTNAME.Name = "TXTGUESTNAME"
        Me.TXTGUESTNAME.ReadOnly = True
        Me.TXTGUESTNAME.Size = New System.Drawing.Size(230, 22)
        Me.TXTGUESTNAME.TabIndex = 3
        Me.TXTGUESTNAME.TabStop = False
        '
        'LBLHOTELNAME
        '
        Me.LBLHOTELNAME.AutoSize = True
        Me.LBLHOTELNAME.BackColor = System.Drawing.Color.Transparent
        Me.LBLHOTELNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLHOTELNAME.Location = New System.Drawing.Point(25, 144)
        Me.LBLHOTELNAME.Name = "LBLHOTELNAME"
        Me.LBLHOTELNAME.Size = New System.Drawing.Size(72, 14)
        Me.LBLHOTELNAME.TabIndex = 683
        Me.LBLHOTELNAME.Text = "Hotel Name"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(17, 170)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(78, 14)
        Me.Label33.TabIndex = 681
        Me.Label33.Text = "Ledger Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(23, 118)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 14)
        Me.Label1.TabIndex = 679
        Me.Label1.Text = "Guest Name"
        '
        'CMBOTHERCHGS
        '
        Me.CMBOTHERCHGS.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBOTHERCHGS.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBOTHERCHGS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBOTHERCHGS.FormattingEnabled = True
        Me.CMBOTHERCHGS.Location = New System.Drawing.Point(407, 330)
        Me.CMBOTHERCHGS.MaxDropDownItems = 14
        Me.CMBOTHERCHGS.Name = "CMBOTHERCHGS"
        Me.CMBOTHERCHGS.Size = New System.Drawing.Size(73, 22)
        Me.CMBOTHERCHGS.TabIndex = 16
        '
        'PBDISCDEL
        '
        Me.PBDISCDEL.BackColor = System.Drawing.Color.Transparent
        Me.PBDISCDEL.Image = Global.HOSPITALITY.My.Resources.Resources.DELETE_ICON
        Me.PBDISCDEL.Location = New System.Drawing.Point(571, 138)
        Me.PBDISCDEL.Name = "PBDISCDEL"
        Me.PBDISCDEL.Size = New System.Drawing.Size(15, 15)
        Me.PBDISCDEL.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBDISCDEL.TabIndex = 670
        Me.PBDISCDEL.TabStop = False
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.BackColor = System.Drawing.Color.Transparent
        Me.Label51.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.Location = New System.Drawing.Point(358, 114)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(78, 14)
        Me.Label51.TabIndex = 667
        Me.Label51.Text = "Total Pur Amt"
        '
        'TXTTOTALPURAMT
        '
        Me.TXTTOTALPURAMT.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTTOTALPURAMT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOTALPURAMT.ForeColor = System.Drawing.Color.Black
        Me.TXTTOTALPURAMT.Location = New System.Drawing.Point(481, 110)
        Me.TXTTOTALPURAMT.Name = "TXTTOTALPURAMT"
        Me.TXTTOTALPURAMT.Size = New System.Drawing.Size(90, 22)
        Me.TXTTOTALPURAMT.TabIndex = 3
        Me.TXTTOTALPURAMT.Text = "0.00"
        Me.TXTTOTALPURAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtgrandtotal
        '
        Me.txtgrandtotal.BackColor = System.Drawing.Color.Linen
        Me.txtgrandtotal.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtgrandtotal.ForeColor = System.Drawing.Color.Black
        Me.txtgrandtotal.Location = New System.Drawing.Point(481, 378)
        Me.txtgrandtotal.Name = "txtgrandtotal"
        Me.txtgrandtotal.ReadOnly = True
        Me.txtgrandtotal.Size = New System.Drawing.Size(90, 22)
        Me.txtgrandtotal.TabIndex = 663
        Me.txtgrandtotal.TabStop = False
        Me.txtgrandtotal.Text = "0.00"
        Me.txtgrandtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.BackColor = System.Drawing.Color.Transparent
        Me.Label36.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.Red
        Me.Label36.Location = New System.Drawing.Point(358, 383)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(70, 14)
        Me.Label36.TabIndex = 662
        Me.Label36.Text = "Grand Total"
        '
        'cmbaddsub
        '
        Me.cmbaddsub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbaddsub.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbaddsub.FormattingEnabled = True
        Me.cmbaddsub.Items.AddRange(New Object() {"", "Add", "Sub."})
        Me.cmbaddsub.Location = New System.Drawing.Point(358, 330)
        Me.cmbaddsub.Name = "cmbaddsub"
        Me.cmbaddsub.Size = New System.Drawing.Size(47, 22)
        Me.cmbaddsub.TabIndex = 15
        '
        'txtotherchg
        '
        Me.txtotherchg.BackColor = System.Drawing.Color.White
        Me.txtotherchg.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtotherchg.ForeColor = System.Drawing.Color.Black
        Me.txtotherchg.Location = New System.Drawing.Point(481, 330)
        Me.txtotherchg.Name = "txtotherchg"
        Me.txtotherchg.Size = New System.Drawing.Size(90, 22)
        Me.txtotherchg.TabIndex = 17
        Me.txtotherchg.Text = "0.00"
        Me.txtotherchg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(358, 358)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(60, 14)
        Me.Label38.TabIndex = 661
        Me.Label38.Text = "Round Off"
        '
        'txtroundoff
        '
        Me.txtroundoff.BackColor = System.Drawing.Color.White
        Me.txtroundoff.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtroundoff.ForeColor = System.Drawing.Color.Black
        Me.txtroundoff.Location = New System.Drawing.Point(481, 354)
        Me.txtroundoff.Name = "txtroundoff"
        Me.txtroundoff.ReadOnly = True
        Me.txtroundoff.Size = New System.Drawing.Size(90, 22)
        Me.txtroundoff.TabIndex = 660
        Me.txtroundoff.TabStop = False
        Me.txtroundoff.Text = "0.00"
        Me.txtroundoff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbtax
        '
        Me.cmbtax.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbtax.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbtax.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbtax.FormattingEnabled = True
        Me.cmbtax.Location = New System.Drawing.Point(407, 282)
        Me.cmbtax.MaxDropDownItems = 14
        Me.cmbtax.Name = "cmbtax"
        Me.cmbtax.Size = New System.Drawing.Size(73, 22)
        Me.cmbtax.TabIndex = 11
        '
        'txttax
        '
        Me.txttax.BackColor = System.Drawing.Color.White
        Me.txttax.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttax.ForeColor = System.Drawing.Color.Black
        Me.txttax.Location = New System.Drawing.Point(481, 282)
        Me.txttax.Name = "txttax"
        Me.txttax.ReadOnly = True
        Me.txttax.Size = New System.Drawing.Size(90, 22)
        Me.txttax.TabIndex = 12
        Me.txttax.Text = "0.00"
        Me.txttax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Black
        Me.Label32.Location = New System.Drawing.Point(358, 286)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(41, 14)
        Me.Label32.TabIndex = 659
        Me.Label32.Text = "Tax (+)"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Red
        Me.Label25.Location = New System.Drawing.Point(358, 262)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(57, 14)
        Me.Label25.TabIndex = 657
        Me.Label25.Text = "Sub Total"
        '
        'TXTSUBTOTAL
        '
        Me.TXTSUBTOTAL.BackColor = System.Drawing.Color.Linen
        Me.TXTSUBTOTAL.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSUBTOTAL.ForeColor = System.Drawing.Color.Black
        Me.TXTSUBTOTAL.Location = New System.Drawing.Point(481, 258)
        Me.TXTSUBTOTAL.Name = "TXTSUBTOTAL"
        Me.TXTSUBTOTAL.ReadOnly = True
        Me.TXTSUBTOTAL.Size = New System.Drawing.Size(90, 22)
        Me.TXTSUBTOTAL.TabIndex = 656
        Me.TXTSUBTOTAL.TabStop = False
        Me.TXTSUBTOTAL.Text = "0.00"
        Me.TXTSUBTOTAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTDISCPER
        '
        Me.TXTDISCPER.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDISCPER.ForeColor = System.Drawing.Color.Black
        Me.TXTDISCPER.Location = New System.Drawing.Point(442, 134)
        Me.TXTDISCPER.Name = "TXTDISCPER"
        Me.TXTDISCPER.Size = New System.Drawing.Size(38, 22)
        Me.TXTDISCPER.TabIndex = 4
        Me.TXTDISCPER.Text = "0.00"
        Me.TXTDISCPER.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(358, 138)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(74, 14)
        Me.Label24.TabIndex = 655
        Me.Label24.Text = "Disc Recd (-)"
        '
        'TXTDISCRS
        '
        Me.TXTDISCRS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDISCRS.ForeColor = System.Drawing.Color.Black
        Me.TXTDISCRS.Location = New System.Drawing.Point(481, 134)
        Me.TXTDISCRS.Name = "TXTDISCRS"
        Me.TXTDISCRS.Size = New System.Drawing.Size(90, 22)
        Me.TXTDISCRS.TabIndex = 5
        Me.TXTDISCRS.Text = "0.00"
        Me.TXTDISCRS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdclear
        '
        Me.cmdclear.BackColor = System.Drawing.Color.Transparent
        Me.cmdclear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdclear.FlatAppearance.BorderSize = 0
        Me.cmdclear.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdclear.ForeColor = System.Drawing.Color.Black
        Me.cmdclear.Location = New System.Drawing.Point(349, 520)
        Me.cmdclear.Name = "cmdclear"
        Me.cmdclear.Size = New System.Drawing.Size(80, 28)
        Me.cmdclear.TabIndex = 20
        Me.cmdclear.Text = "&Clear"
        Me.cmdclear.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(263, 520)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 19
        Me.cmdok.Text = "&Save"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(435, 520)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 21
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(42, 248)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 14)
        Me.Label2.TabIndex = 319
        Me.Label2.Text = "Remarks"
        '
        'txtremarks
        '
        Me.txtremarks.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtremarks.ForeColor = System.Drawing.Color.DimGray
        Me.txtremarks.Location = New System.Drawing.Point(98, 245)
        Me.txtremarks.Multiline = True
        Me.txtremarks.Name = "txtremarks"
        Me.txtremarks.Size = New System.Drawing.Size(230, 107)
        Me.txtremarks.TabIndex = 18
        '
        'cmbregister
        '
        Me.cmbregister.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbregister.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbregister.BackColor = System.Drawing.Color.LemonChiffon
        Me.cmbregister.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbregister.FormattingEnabled = True
        Me.cmbregister.Items.AddRange(New Object() {""})
        Me.cmbregister.Location = New System.Drawing.Point(99, 51)
        Me.cmbregister.Name = "cmbregister"
        Me.cmbregister.Size = New System.Drawing.Size(229, 22)
        Me.cmbregister.TabIndex = 0
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(45, 55)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(52, 14)
        Me.Label23.TabIndex = 318
        Me.Label23.Text = "Register"
        '
        'TXTDNNO
        '
        Me.TXTDNNO.BackColor = System.Drawing.Color.Linen
        Me.TXTDNNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDNNO.Location = New System.Drawing.Point(484, 29)
        Me.TXTDNNO.Name = "TXTDNNO"
        Me.TXTDNNO.ReadOnly = True
        Me.TXTDNNO.Size = New System.Drawing.Size(87, 22)
        Me.TXTDNNO.TabIndex = 315
        Me.TXTDNNO.TabStop = False
        Me.TXTDNNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblsrno
        '
        Me.lblsrno.BackColor = System.Drawing.Color.Transparent
        Me.lblsrno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsrno.Location = New System.Drawing.Point(432, 33)
        Me.lblsrno.Name = "lblsrno"
        Me.lblsrno.Size = New System.Drawing.Size(50, 13)
        Me.lblsrno.TabIndex = 316
        Me.lblsrno.Text = "Sr. No."
        Me.lblsrno.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(449, 59)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 14)
        Me.Label5.TabIndex = 314
        Me.Label5.Text = "Date"
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(12, 7)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(113, 25)
        Me.lbl.TabIndex = 313
        Me.lbl.Text = "Debit Note"
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape6})
        Me.ShapeContainer1.Size = New System.Drawing.Size(778, 557)
        Me.ShapeContainer1.TabIndex = 884
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape6
        '
        Me.LineShape6.Name = "LineShape6"
        Me.LineShape6.X1 = 353
        Me.LineShape6.X2 = 585
        Me.LineShape6.Y1 = 254
        Me.LineShape6.Y2 = 254
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'CHKGSTR1
        '
        Me.CHKGSTR1.AutoSize = True
        Me.CHKGSTR1.BackColor = System.Drawing.Color.Transparent
        Me.CHKGSTR1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKGSTR1.Location = New System.Drawing.Point(642, 186)
        Me.CHKGSTR1.Name = "CHKGSTR1"
        Me.CHKGSTR1.Size = New System.Drawing.Size(106, 19)
        Me.CHKGSTR1.TabIndex = 967
        Me.CHKGSTR1.Text = "Show in GSTR1"
        Me.CHKGSTR1.UseVisualStyleBackColor = False
        '
        'DebitNote
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(778, 582)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Controls.Add(Me.tstxtbillno)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "DebitNote"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Debit Note"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.PBQRCODE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBPURTDSDEL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBCOMMRECDDEL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBDISCDEL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents OpenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripdelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolprevious As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolnext As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents tstxtbillno As System.Windows.Forms.TextBox
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents TXTHOTELNAME As System.Windows.Forms.TextBox
    Friend WithEvents TXTGUESTNAME As System.Windows.Forms.TextBox
    Friend WithEvents LBLHOTELNAME As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CMBOTHERCHGS As System.Windows.Forms.ComboBox
    Friend WithEvents PBDISCDEL As System.Windows.Forms.PictureBox
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents TXTTOTALPURAMT As System.Windows.Forms.TextBox
    Friend WithEvents txtgrandtotal As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents cmbaddsub As System.Windows.Forms.ComboBox
    Friend WithEvents txtotherchg As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents txtroundoff As System.Windows.Forms.TextBox
    Friend WithEvents cmbtax As System.Windows.Forms.ComboBox
    Friend WithEvents txttax As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TXTSUBTOTAL As System.Windows.Forms.TextBox
    Friend WithEvents TXTDISCPER As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents TXTDISCRS As System.Windows.Forms.TextBox
    Friend WithEvents cmdclear As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtremarks As System.Windows.Forms.TextBox
    Friend WithEvents cmbregister As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TXTDNNO As System.Windows.Forms.TextBox
    Friend WithEvents lblsrno As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents PBCOMMRECDDEL As System.Windows.Forms.PictureBox
    Friend WithEvents TXTCOMMRECDPER As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents TXTCOMMRECDRS As System.Windows.Forms.TextBox
    Friend WithEvents LBLEXTRACHGS As System.Windows.Forms.Label
    Friend WithEvents TXTPUREXTRACHGS As System.Windows.Forms.TextBox
    Friend WithEvents PBPURTDSDEL As System.Windows.Forms.PictureBox
    Friend WithEvents TXTPURTDSPER As System.Windows.Forms.TextBox
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents TXTPURTDSRS As System.Windows.Forms.TextBox
    Friend WithEvents CMBADDTAX As System.Windows.Forms.ComboBox
    Friend WithEvents TXTADDTAX As System.Windows.Forms.TextBox
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TXTBILLNO As System.Windows.Forms.TextBox
    Friend WithEvents CMBOTHERCHGSCODE As System.Windows.Forms.ComboBox
    Friend WithEvents TXTOTHERCHGSADD As System.Windows.Forms.TextBox
    Friend WithEvents CMBACCCODE As System.Windows.Forms.ComboBox
    Friend WithEvents CMBNAME As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ARRIVALDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TXTDP As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TXTPURSERVCHGS As System.Windows.Forms.TextBox
    Friend WithEvents TXTIGSTAMT As System.Windows.Forms.TextBox
    Friend WithEvents LBLIGST As System.Windows.Forms.Label
    Friend WithEvents TXTIGSTPER As System.Windows.Forms.TextBox
    Friend WithEvents LBLSGST As System.Windows.Forms.Label
    Friend WithEvents TXTSGSTPER As System.Windows.Forms.TextBox
    Friend WithEvents TXTSGSTAMT As System.Windows.Forms.TextBox
    Friend WithEvents TXTCGSTAMT As System.Windows.Forms.TextBox
    Friend WithEvents LBLCGST As System.Windows.Forms.Label
    Friend WithEvents TXTCGSTPER As System.Windows.Forms.TextBox
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape6 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents CHKTAXSERVCHGS As System.Windows.Forms.CheckBox
    Friend WithEvents LBLHSNCODE As System.Windows.Forms.Label
    Friend WithEvents TXTHSNCODE As System.Windows.Forms.TextBox
    Friend WithEvents LBLHSNDESC As System.Windows.Forms.Label
    Friend WithEvents CMBHSNITEMDESC As System.Windows.Forms.ComboBox
    Friend WithEvents LBLSTATECODE As System.Windows.Forms.Label
    Friend WithEvents TXTSTATECODE As System.Windows.Forms.TextBox
    Friend WithEvents CHKMANUAL As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As Label
    Friend WithEvents ACKDATE As DateTimePicker
    Friend WithEvents Label56 As Label
    Friend WithEvents TXTACKNO As TextBox
    Friend WithEvents TXTIRNNO As TextBox
    Friend WithEvents Label58 As Label
    Friend WithEvents CMDGETQRCODE As Button
    Friend WithEvents CMDUPLOADIRN As Button
    Friend WithEvents PBQRCODE As PictureBox
    Friend WithEvents TOOLEINV As ToolStripButton
    Friend WithEvents LBLEINVGENERATED As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents TXTNEWIMGPATH As TextBox
    Friend WithEvents TXTFILENAME As TextBox
    Friend WithEvents txtimgpath As TextBox
    Friend WithEvents DNDATE As MaskedTextBox
    Friend WithEvents CHKGSTR1 As CheckBox
End Class
