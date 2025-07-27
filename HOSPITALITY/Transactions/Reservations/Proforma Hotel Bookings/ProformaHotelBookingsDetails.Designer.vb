<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProformaHotelBookingsDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProformaHotelBookingsDetails))
        Me.PRINTDIALOG = New System.Windows.Forms.PrintDialog()
        Me.PRINTDOC = New System.Drawing.Printing.PrintDocument()
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TXTCOPIES = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LBLTO = New System.Windows.Forms.Label()
        Me.LBLFROM = New System.Windows.Forms.Label()
        Me.TXTTO = New System.Windows.Forms.TextBox()
        Me.TXTFROM = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GINITIALS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gsrno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREFNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gdate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ghotelname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gaccname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGSTIN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSTATENAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSTATECODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURGSTIN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURSTATENAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURSTATECODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.garrival = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gdeparture = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gtotalpax = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gtotalrooms = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURHSNCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gDISCRECDRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gCOMMRECDRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gPURTDSRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gPUREXTRACHGS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURSERVCHGS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURCGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PURSGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURIGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURSUBTOTAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURTAXNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURTAXAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gPURADDTAXNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gPURADDTAX = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gtotalpurchase = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gPUROTHERCHGSNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gPUROTHERCHGS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gPURROUNDOFF = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURCHASEBALANCE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GHSNCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALSALEAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDISC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GEXTRACHGS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSUBTOTAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOURCOMMRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GIGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTAXNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TAXAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOTHERCHGSNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOTHERCHGS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GROUNDOFF = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gtotalsale = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSALEBALANCE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBOOKEDBY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMODIFIEDBY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCANCEL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAMENDED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBILLCHECKED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDISPUTE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBALANCE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GEMAIL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRETURN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREFUNDED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFAILED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GARRFROM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GARRFLIGHTNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDEPTTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDEPTTOFLIGHTNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURTAXSERVCHGS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTAXSERVCHGS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ExcelExport = New System.Windows.Forms.ToolStripButton()
        Me.PRINTTOOL = New System.Windows.Forms.ToolStripButton()
        Me.TOOLMAIL = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lbl = New System.Windows.Forms.Label()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PRINTDIALOG
        '
        Me.PRINTDIALOG.AllowSelection = True
        Me.PRINTDIALOG.AllowSomePages = True
        Me.PRINTDIALOG.ShowHelp = True
        Me.PRINTDIALOG.UseEXDialog = True
        '
        'imageList1
        '
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList1.TransparentColor = System.Drawing.Color.Magenta
        Me.imageList1.Images.SetKeyName(0, "")
        Me.imageList1.Images.SetKeyName(1, "")
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.Label11)
        Me.BlendPanel1.Controls.Add(Me.TXTCOPIES)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.Label10)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.LBLTO)
        Me.BlendPanel1.Controls.Add(Me.LBLFROM)
        Me.BlendPanel1.Controls.Add(Me.TXTTO)
        Me.BlendPanel1.Controls.Add(Me.TXTFROM)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.Label8)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.Label7)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1010, 669)
        Me.BlendPanel1.TabIndex = 4
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.White
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(342, 5)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(44, 14)
        Me.Label11.TabIndex = 799
        Me.Label11.Text = "Copies"
        '
        'TXTCOPIES
        '
        Me.TXTCOPIES.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCOPIES.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCOPIES.Location = New System.Drawing.Point(387, 1)
        Me.TXTCOPIES.Name = "TXTCOPIES"
        Me.TXTCOPIES.Size = New System.Drawing.Size(29, 22)
        Me.TXTCOPIES.TabIndex = 798
        Me.TXTCOPIES.Text = "1"
        Me.TXTCOPIES.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(701, 40)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(106, 14)
        Me.Label9.TabIndex = 797
        Me.Label9.Text = "Refunded Voucher"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.PeachPuff
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Location = New System.Drawing.Point(679, 39)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(18, 17)
        Me.Label10.TabIndex = 796
        Me.Label10.Text = "   "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(587, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 14)
        Me.Label1.TabIndex = 795
        Me.Label1.Text = "Failed Voucher"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Plum
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Location = New System.Drawing.Point(565, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(18, 17)
        Me.Label2.TabIndex = 794
        Me.Label2.Text = "   "
        '
        'LBLTO
        '
        Me.LBLTO.AutoSize = True
        Me.LBLTO.BackColor = System.Drawing.Color.White
        Me.LBLTO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTO.Location = New System.Drawing.Point(257, 5)
        Me.LBLTO.Name = "LBLTO"
        Me.LBLTO.Size = New System.Drawing.Size(19, 14)
        Me.LBLTO.TabIndex = 783
        Me.LBLTO.Text = "To"
        '
        'LBLFROM
        '
        Me.LBLFROM.AutoSize = True
        Me.LBLFROM.BackColor = System.Drawing.Color.White
        Me.LBLFROM.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLFROM.Location = New System.Drawing.Point(159, 5)
        Me.LBLFROM.Name = "LBLFROM"
        Me.LBLFROM.Size = New System.Drawing.Size(34, 14)
        Me.LBLFROM.TabIndex = 782
        Me.LBLFROM.Text = "From"
        '
        'TXTTO
        '
        Me.TXTTO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTTO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTO.Location = New System.Drawing.Point(278, 1)
        Me.TXTTO.Name = "TXTTO"
        Me.TXTTO.Size = New System.Drawing.Size(57, 22)
        Me.TXTTO.TabIndex = 781
        Me.TXTTO.TabStop = False
        Me.TXTTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTFROM
        '
        Me.TXTFROM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTFROM.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFROM.Location = New System.Drawing.Point(194, 1)
        Me.TXTFROM.Name = "TXTFROM"
        Me.TXTFROM.Size = New System.Drawing.Size(57, 22)
        Me.TXTFROM.TabIndex = 780
        Me.TXTFROM.TabStop = False
        Me.TXTFROM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(487, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 14)
        Me.Label6.TabIndex = 494
        Me.Label6.Text = "Bill Checked"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.LightGreen
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Location = New System.Drawing.Point(465, 39)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(18, 17)
        Me.Label8.TabIndex = 493
        Me.Label8.Text = "   "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(358, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 14)
        Me.Label3.TabIndex = 492
        Me.Label3.Text = "Disputed Voucher"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.LightBlue
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Location = New System.Drawing.Point(336, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(18, 17)
        Me.Label5.TabIndex = 491
        Me.Label5.Text = "   "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(225, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(107, 14)
        Me.Label7.TabIndex = 488
        Me.Label7.Text = "Cancelled Voucher"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Location = New System.Drawing.Point(203, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(18, 17)
        Me.Label4.TabIndex = 487
        Me.Label4.Text = "   "
        '
        'CMDOK
        '
        Me.CMDOK.BackColor = System.Drawing.Color.Transparent
        Me.CMDOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDOK.FlatAppearance.BorderSize = 0
        Me.CMDOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDOK.Image = Global.HOSPITALITY.My.Resources.Resources.ok
        Me.CMDOK.Location = New System.Drawing.Point(437, 552)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(72, 26)
        Me.CMDOK.TabIndex = 317
        Me.CMDOK.UseVisualStyleBackColor = False
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.Color.Transparent
        Me.cmdcancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdcancel.FlatAppearance.BorderSize = 0
        Me.cmdcancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdcancel.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdcancel.Image = Global.HOSPITALITY.My.Resources.Resources._Exit
        Me.cmdcancel.Location = New System.Drawing.Point(515, 554)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(72, 24)
        Me.cmdcancel.TabIndex = 316
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(15, 59)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(995, 487)
        Me.gridbilldetails.TabIndex = 314
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GINITIALS, Me.gsrno, Me.GREFNO, Me.gdate, Me.gname, Me.ghotelname, Me.gaccname, Me.GGSTIN, Me.GSTATENAME, Me.GSTATECODE, Me.GPURNAME, Me.GPURGSTIN, Me.GPURSTATENAME, Me.GPURSTATECODE, Me.garrival, Me.gdeparture, Me.gtotalpax, Me.gtotalrooms, Me.GPURHSNCODE, Me.GPURAMT, Me.gDISCRECDRS, Me.gCOMMRECDRS, Me.gPURTDSRS, Me.gPUREXTRACHGS, Me.GPURSERVCHGS, Me.GPURCGSTAMT, Me.PURSGSTAMT, Me.GPURIGSTAMT, Me.GPURSUBTOTAL, Me.GPURTAXNAME, Me.GPURTAXAMT, Me.gPURADDTAXNAME, Me.gPURADDTAX, Me.gtotalpurchase, Me.gPUROTHERCHGSNAME, Me.gPUROTHERCHGS, Me.gPURROUNDOFF, Me.GPURCHASEBALANCE, Me.GHSNCODE, Me.GTOTALSALEAMT, Me.GDISC, Me.GEXTRACHGS, Me.GSUBTOTAL, Me.GOURCOMMRS, Me.GCGSTAMT, Me.GSGSTAMT, Me.GIGSTAMT, Me.GTAXNAME, Me.TAXAMT, Me.GOTHERCHGSNAME, Me.GOTHERCHGS, Me.GROUNDOFF, Me.gtotalsale, Me.GSALEBALANCE, Me.GBOOKEDBY, Me.GMODIFIEDBY, Me.GCANCEL, Me.GAMENDED, Me.GBILLCHECKED, Me.GDISPUTE, Me.GBALANCE, Me.GEMAIL, Me.GRETURN, Me.GREFUNDED, Me.GFAILED, Me.GARRFROM, Me.GARRFLIGHTNO, Me.GDEPTTO, Me.GDEPTTOFLIGHTNO, Me.GPURTAXSERVCHGS, Me.GTAXSERVCHGS})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Images = Me.imageList1
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsSelection.CheckBoxSelectorColumnWidth = 30
        Me.gridbill.OptionsSelection.MultiSelect = True
        Me.gridbill.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        '
        'GINITIALS
        '
        Me.GINITIALS.Caption = "Booking No"
        Me.GINITIALS.FieldName = "BILLINITIALS"
        Me.GINITIALS.Name = "GINITIALS"
        Me.GINITIALS.Visible = True
        Me.GINITIALS.VisibleIndex = 1
        '
        'gsrno
        '
        Me.gsrno.Caption = "Booking No"
        Me.gsrno.FieldName = "BOOKINGNO"
        Me.gsrno.ImageIndex = 1
        Me.gsrno.Name = "gsrno"
        '
        'GREFNO
        '
        Me.GREFNO.Caption = "Ref No"
        Me.GREFNO.FieldName = "REFNO"
        Me.GREFNO.Name = "GREFNO"
        Me.GREFNO.Visible = True
        Me.GREFNO.VisibleIndex = 2
        '
        'gdate
        '
        Me.gdate.Caption = "Date"
        Me.gdate.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.gdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.gdate.FieldName = "BOOKINGDATE"
        Me.gdate.Name = "gdate"
        Me.gdate.Visible = True
        Me.gdate.VisibleIndex = 3
        Me.gdate.Width = 70
        '
        'gname
        '
        Me.gname.Caption = "Guest Name"
        Me.gname.FieldName = "GUESTNAME"
        Me.gname.ImageIndex = 0
        Me.gname.Name = "gname"
        Me.gname.Visible = True
        Me.gname.VisibleIndex = 4
        Me.gname.Width = 200
        '
        'ghotelname
        '
        Me.ghotelname.Caption = "Hotel Name"
        Me.ghotelname.FieldName = "HOTELNAME"
        Me.ghotelname.Name = "ghotelname"
        Me.ghotelname.Visible = True
        Me.ghotelname.VisibleIndex = 5
        Me.ghotelname.Width = 200
        '
        'gaccname
        '
        Me.gaccname.Caption = "Account Name"
        Me.gaccname.FieldName = "ACCNAME"
        Me.gaccname.Name = "gaccname"
        Me.gaccname.Visible = True
        Me.gaccname.VisibleIndex = 6
        Me.gaccname.Width = 200
        '
        'GGSTIN
        '
        Me.GGSTIN.Caption = "GSTIN"
        Me.GGSTIN.FieldName = "GSTIN"
        Me.GGSTIN.Name = "GGSTIN"
        Me.GGSTIN.Visible = True
        Me.GGSTIN.VisibleIndex = 7
        Me.GGSTIN.Width = 80
        '
        'GSTATENAME
        '
        Me.GSTATENAME.Caption = "State Name"
        Me.GSTATENAME.FieldName = "STATENAME"
        Me.GSTATENAME.Name = "GSTATENAME"
        Me.GSTATENAME.Visible = True
        Me.GSTATENAME.VisibleIndex = 8
        '
        'GSTATECODE
        '
        Me.GSTATECODE.Caption = "STATE Code"
        Me.GSTATECODE.FieldName = "STATECODE"
        Me.GSTATECODE.Name = "GSTATECODE"
        Me.GSTATECODE.Visible = True
        Me.GSTATECODE.VisibleIndex = 10
        '
        'GPURNAME
        '
        Me.GPURNAME.Caption = "Purchase Account Name"
        Me.GPURNAME.FieldName = "PURNAME"
        Me.GPURNAME.Name = "GPURNAME"
        Me.GPURNAME.Visible = True
        Me.GPURNAME.VisibleIndex = 9
        Me.GPURNAME.Width = 200
        '
        'GPURGSTIN
        '
        Me.GPURGSTIN.Caption = "Purchase GSTIN"
        Me.GPURGSTIN.FieldName = "PURGSTIN"
        Me.GPURGSTIN.Name = "GPURGSTIN"
        Me.GPURGSTIN.Visible = True
        Me.GPURGSTIN.VisibleIndex = 11
        Me.GPURGSTIN.Width = 80
        '
        'GPURSTATENAME
        '
        Me.GPURSTATENAME.Caption = "Pur. State Name"
        Me.GPURSTATENAME.FieldName = "PURSTATENAME"
        Me.GPURSTATENAME.Name = "GPURSTATENAME"
        Me.GPURSTATENAME.Visible = True
        Me.GPURSTATENAME.VisibleIndex = 14
        '
        'GPURSTATECODE
        '
        Me.GPURSTATECODE.Caption = "Pur. State Code"
        Me.GPURSTATECODE.FieldName = "PURSTATECODE"
        Me.GPURSTATECODE.Name = "GPURSTATECODE"
        Me.GPURSTATECODE.Visible = True
        Me.GPURSTATECODE.VisibleIndex = 15
        '
        'garrival
        '
        Me.garrival.Caption = "Arrival"
        Me.garrival.FieldName = "ARRIVAL"
        Me.garrival.Name = "garrival"
        Me.garrival.Visible = True
        Me.garrival.VisibleIndex = 12
        Me.garrival.Width = 70
        '
        'gdeparture
        '
        Me.gdeparture.Caption = "Departure"
        Me.gdeparture.FieldName = "DEPARTURE"
        Me.gdeparture.Name = "gdeparture"
        Me.gdeparture.Width = 70
        '
        'gtotalpax
        '
        Me.gtotalpax.Caption = "Total Pax"
        Me.gtotalpax.FieldName = "TOTALPAX"
        Me.gtotalpax.Name = "gtotalpax"
        Me.gtotalpax.Visible = True
        Me.gtotalpax.VisibleIndex = 13
        '
        'gtotalrooms
        '
        Me.gtotalrooms.Caption = "Rooms"
        Me.gtotalrooms.FieldName = "TOTALROOMS"
        Me.gtotalrooms.Name = "gtotalrooms"
        Me.gtotalrooms.Visible = True
        Me.gtotalrooms.VisibleIndex = 16
        '
        'GPURHSNCODE
        '
        Me.GPURHSNCODE.Caption = "Pur. HSN Code"
        Me.GPURHSNCODE.FieldName = "PURHSNCODE"
        Me.GPURHSNCODE.Name = "GPURHSNCODE"
        Me.GPURHSNCODE.Visible = True
        Me.GPURHSNCODE.VisibleIndex = 17
        '
        'GPURAMT
        '
        Me.GPURAMT.Caption = "Purchase Amt."
        Me.GPURAMT.FieldName = "TOTALPURAMT"
        Me.GPURAMT.Name = "GPURAMT"
        Me.GPURAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PURAMT", "")})
        Me.GPURAMT.Visible = True
        Me.GPURAMT.VisibleIndex = 18
        '
        'gDISCRECDRS
        '
        Me.gDISCRECDRS.Caption = "Pur Discount Rec"
        Me.gDISCRECDRS.FieldName = "DISCRECDRS"
        Me.gDISCRECDRS.Name = "gDISCRECDRS"
        Me.gDISCRECDRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.gDISCRECDRS.Visible = True
        Me.gDISCRECDRS.VisibleIndex = 19
        '
        'gCOMMRECDRS
        '
        Me.gCOMMRECDRS.Caption = "Comm Recived"
        Me.gCOMMRECDRS.FieldName = "COMMRECDRS"
        Me.gCOMMRECDRS.Name = "gCOMMRECDRS"
        Me.gCOMMRECDRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.gCOMMRECDRS.Visible = True
        Me.gCOMMRECDRS.VisibleIndex = 20
        '
        'gPURTDSRS
        '
        Me.gPURTDSRS.Caption = "Pur TDS"
        Me.gPURTDSRS.FieldName = "PURTDSRS"
        Me.gPURTDSRS.Name = "gPURTDSRS"
        Me.gPURTDSRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.gPURTDSRS.Visible = True
        Me.gPURTDSRS.VisibleIndex = 21
        '
        'gPUREXTRACHGS
        '
        Me.gPUREXTRACHGS.Caption = "Pur Extra Chgs"
        Me.gPUREXTRACHGS.FieldName = "PUREXTRACHGS"
        Me.gPUREXTRACHGS.Name = "gPUREXTRACHGS"
        Me.gPUREXTRACHGS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.gPUREXTRACHGS.Visible = True
        Me.gPUREXTRACHGS.VisibleIndex = 22
        '
        'GPURSERVCHGS
        '
        Me.GPURSERVCHGS.Caption = "Pur Serv Chgs."
        Me.GPURSERVCHGS.FieldName = "PUROURCOMMPER"
        Me.GPURSERVCHGS.Name = "GPURSERVCHGS"
        Me.GPURSERVCHGS.Visible = True
        Me.GPURSERVCHGS.VisibleIndex = 23
        '
        'GPURCGSTAMT
        '
        Me.GPURCGSTAMT.Caption = "Pur CGST Amt."
        Me.GPURCGSTAMT.FieldName = "PURCGSTAMT"
        Me.GPURCGSTAMT.Name = "GPURCGSTAMT"
        Me.GPURCGSTAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPURCGSTAMT.Visible = True
        Me.GPURCGSTAMT.VisibleIndex = 24
        '
        'PURSGSTAMT
        '
        Me.PURSGSTAMT.Caption = "Pur SGST Amt."
        Me.PURSGSTAMT.FieldName = "PURSGSTAMT"
        Me.PURSGSTAMT.Name = "PURSGSTAMT"
        Me.PURSGSTAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.PURSGSTAMT.Visible = True
        Me.PURSGSTAMT.VisibleIndex = 25
        '
        'GPURIGSTAMT
        '
        Me.GPURIGSTAMT.Caption = "Pur IGST Amt."
        Me.GPURIGSTAMT.FieldName = "PURIGSTAMT"
        Me.GPURIGSTAMT.Name = "GPURIGSTAMT"
        Me.GPURIGSTAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPURIGSTAMT.Visible = True
        Me.GPURIGSTAMT.VisibleIndex = 26
        '
        'GPURSUBTOTAL
        '
        Me.GPURSUBTOTAL.Caption = "Pur Sub Total"
        Me.GPURSUBTOTAL.DisplayFormat.FormatString = "0.00"
        Me.GPURSUBTOTAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPURSUBTOTAL.FieldName = "PURSUBTOTAL"
        Me.GPURSUBTOTAL.Name = "GPURSUBTOTAL"
        Me.GPURSUBTOTAL.Visible = True
        Me.GPURSUBTOTAL.VisibleIndex = 27
        Me.GPURSUBTOTAL.Width = 80
        '
        'GPURTAXNAME
        '
        Me.GPURTAXNAME.Caption = "Pur Tax Name"
        Me.GPURTAXNAME.FieldName = "PURTAXNAME"
        Me.GPURTAXNAME.Name = "GPURTAXNAME"
        Me.GPURTAXNAME.Visible = True
        Me.GPURTAXNAME.VisibleIndex = 28
        Me.GPURTAXNAME.Width = 80
        '
        'GPURTAXAMT
        '
        Me.GPURTAXAMT.Caption = "Pur Tax Amt"
        Me.GPURTAXAMT.DisplayFormat.FormatString = "0.00"
        Me.GPURTAXAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPURTAXAMT.FieldName = "PURTAXAMT"
        Me.GPURTAXAMT.Name = "GPURTAXAMT"
        Me.GPURTAXAMT.Visible = True
        Me.GPURTAXAMT.VisibleIndex = 29
        '
        'gPURADDTAXNAME
        '
        Me.gPURADDTAXNAME.Caption = "Pur Add Tax"
        Me.gPURADDTAXNAME.FieldName = "PURADDTAXNAME"
        Me.gPURADDTAXNAME.Name = "gPURADDTAXNAME"
        Me.gPURADDTAXNAME.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.gPURADDTAXNAME.Visible = True
        Me.gPURADDTAXNAME.VisibleIndex = 30
        '
        'gPURADDTAX
        '
        Me.gPURADDTAX.Caption = "PUR ADD TAX"
        Me.gPURADDTAX.FieldName = "PURADDTAX"
        Me.gPURADDTAX.Name = "gPURADDTAX"
        Me.gPURADDTAX.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.gPURADDTAX.Visible = True
        Me.gPURADDTAX.VisibleIndex = 31
        '
        'gtotalpurchase
        '
        Me.gtotalpurchase.Caption = "Purchase Amt"
        Me.gtotalpurchase.FieldName = "PURTOTAL"
        Me.gtotalpurchase.Name = "gtotalpurchase"
        Me.gtotalpurchase.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.gtotalpurchase.Visible = True
        Me.gtotalpurchase.VisibleIndex = 32
        Me.gtotalpurchase.Width = 90
        '
        'gPUROTHERCHGSNAME
        '
        Me.gPUROTHERCHGSNAME.Caption = "Pur Other Chgs Name"
        Me.gPUROTHERCHGSNAME.FieldName = "PUROTHERCHGSNAME"
        Me.gPUROTHERCHGSNAME.Name = "gPUROTHERCHGSNAME"
        Me.gPUROTHERCHGSNAME.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.gPUROTHERCHGSNAME.Visible = True
        Me.gPUROTHERCHGSNAME.VisibleIndex = 33
        '
        'gPUROTHERCHGS
        '
        Me.gPUROTHERCHGS.Caption = "Pur Other Chgs"
        Me.gPUROTHERCHGS.FieldName = "PUROTHERCHGS"
        Me.gPUROTHERCHGS.Name = "gPUROTHERCHGS"
        Me.gPUROTHERCHGS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.gPUROTHERCHGS.Visible = True
        Me.gPUROTHERCHGS.VisibleIndex = 34
        '
        'gPURROUNDOFF
        '
        Me.gPURROUNDOFF.Caption = "Pur Round Off"
        Me.gPURROUNDOFF.FieldName = "PURROUNDOFF"
        Me.gPURROUNDOFF.Name = "gPURROUNDOFF"
        Me.gPURROUNDOFF.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.gPURROUNDOFF.Visible = True
        Me.gPURROUNDOFF.VisibleIndex = 35
        '
        'GPURCHASEBALANCE
        '
        Me.GPURCHASEBALANCE.Caption = "Purchase Balance"
        Me.GPURCHASEBALANCE.FieldName = "PURBAL"
        Me.GPURCHASEBALANCE.Name = "GPURCHASEBALANCE"
        Me.GPURCHASEBALANCE.Visible = True
        Me.GPURCHASEBALANCE.VisibleIndex = 36
        '
        'GHSNCODE
        '
        Me.GHSNCODE.Caption = "HSN Code"
        Me.GHSNCODE.FieldName = "HSNCODE"
        Me.GHSNCODE.Name = "GHSNCODE"
        Me.GHSNCODE.Visible = True
        Me.GHSNCODE.VisibleIndex = 37
        '
        'GTOTALSALEAMT
        '
        Me.GTOTALSALEAMT.Caption = "Total Sale Amt."
        Me.GTOTALSALEAMT.FieldName = "TOTALSALEAMT"
        Me.GTOTALSALEAMT.Name = "GTOTALSALEAMT"
        Me.GTOTALSALEAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALSALEAMT.Visible = True
        Me.GTOTALSALEAMT.VisibleIndex = 38
        '
        'GDISC
        '
        Me.GDISC.Caption = "Discount Recieved"
        Me.GDISC.FieldName = "DISCRS"
        Me.GDISC.Name = "GDISC"
        Me.GDISC.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GDISC.Visible = True
        Me.GDISC.VisibleIndex = 39
        '
        'GEXTRACHGS
        '
        Me.GEXTRACHGS.Caption = "Extra Chgs."
        Me.GEXTRACHGS.FieldName = "EXTRACHGS"
        Me.GEXTRACHGS.Name = "GEXTRACHGS"
        Me.GEXTRACHGS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GEXTRACHGS.Visible = True
        Me.GEXTRACHGS.VisibleIndex = 40
        '
        'GSUBTOTAL
        '
        Me.GSUBTOTAL.Caption = "Sub Total"
        Me.GSUBTOTAL.DisplayFormat.FormatString = "0.00"
        Me.GSUBTOTAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSUBTOTAL.FieldName = "SUBTOTAL"
        Me.GSUBTOTAL.Name = "GSUBTOTAL"
        Me.GSUBTOTAL.Visible = True
        Me.GSUBTOTAL.VisibleIndex = 41
        '
        'GOURCOMMRS
        '
        Me.GOURCOMMRS.Caption = "Serv Chgs."
        Me.GOURCOMMRS.FieldName = "OURCOMMRS"
        Me.GOURCOMMRS.Name = "GOURCOMMRS"
        Me.GOURCOMMRS.Visible = True
        Me.GOURCOMMRS.VisibleIndex = 42
        '
        'GCGSTAMT
        '
        Me.GCGSTAMT.Caption = "CGST Amt."
        Me.GCGSTAMT.FieldName = "CGSTAMT"
        Me.GCGSTAMT.Name = "GCGSTAMT"
        Me.GCGSTAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GCGSTAMT.Visible = True
        Me.GCGSTAMT.VisibleIndex = 43
        '
        'GSGSTAMT
        '
        Me.GSGSTAMT.Caption = "SGST Amt."
        Me.GSGSTAMT.FieldName = "SGSTAMT"
        Me.GSGSTAMT.Name = "GSGSTAMT"
        Me.GSGSTAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GSGSTAMT.Visible = True
        Me.GSGSTAMT.VisibleIndex = 44
        '
        'GIGSTAMT
        '
        Me.GIGSTAMT.Caption = "IGST Amt"
        Me.GIGSTAMT.FieldName = "IGSTAMT"
        Me.GIGSTAMT.Name = "GIGSTAMT"
        Me.GIGSTAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GIGSTAMT.Visible = True
        Me.GIGSTAMT.VisibleIndex = 45
        '
        'GTAXNAME
        '
        Me.GTAXNAME.Caption = "Tax Name"
        Me.GTAXNAME.FieldName = "TAXNAME"
        Me.GTAXNAME.Name = "GTAXNAME"
        Me.GTAXNAME.Visible = True
        Me.GTAXNAME.VisibleIndex = 46
        '
        'TAXAMT
        '
        Me.TAXAMT.Caption = "Tax Amt"
        Me.TAXAMT.DisplayFormat.FormatString = "0.00"
        Me.TAXAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TAXAMT.FieldName = "TAXAMT"
        Me.TAXAMT.Name = "TAXAMT"
        Me.TAXAMT.Visible = True
        Me.TAXAMT.VisibleIndex = 47
        '
        'GOTHERCHGSNAME
        '
        Me.GOTHERCHGSNAME.Caption = "Chgs Name"
        Me.GOTHERCHGSNAME.FieldName = "OTHERCHGSNAME"
        Me.GOTHERCHGSNAME.Name = "GOTHERCHGSNAME"
        Me.GOTHERCHGSNAME.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GOTHERCHGSNAME.Visible = True
        Me.GOTHERCHGSNAME.VisibleIndex = 48
        '
        'GOTHERCHGS
        '
        Me.GOTHERCHGS.Caption = "Other Chgs."
        Me.GOTHERCHGS.FieldName = "OTHERCHGS"
        Me.GOTHERCHGS.Name = "GOTHERCHGS"
        Me.GOTHERCHGS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GOTHERCHGS.Visible = True
        Me.GOTHERCHGS.VisibleIndex = 49
        '
        'GROUNDOFF
        '
        Me.GROUNDOFF.Caption = "Round Off"
        Me.GROUNDOFF.FieldName = "ROUNDOFF"
        Me.GROUNDOFF.Name = "GROUNDOFF"
        Me.GROUNDOFF.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GROUNDOFF.Visible = True
        Me.GROUNDOFF.VisibleIndex = 50
        '
        'gtotalsale
        '
        Me.gtotalsale.Caption = "G. Total"
        Me.gtotalsale.FieldName = "GRANDTOTAL"
        Me.gtotalsale.Name = "gtotalsale"
        Me.gtotalsale.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.gtotalsale.Visible = True
        Me.gtotalsale.VisibleIndex = 51
        '
        'GSALEBALANCE
        '
        Me.GSALEBALANCE.Caption = "Sale Balance"
        Me.GSALEBALANCE.FieldName = "SALEBAL"
        Me.GSALEBALANCE.Name = "GSALEBALANCE"
        Me.GSALEBALANCE.Visible = True
        Me.GSALEBALANCE.VisibleIndex = 52
        '
        'GBOOKEDBY
        '
        Me.GBOOKEDBY.Caption = "Booked By"
        Me.GBOOKEDBY.FieldName = "BOOKEDBY"
        Me.GBOOKEDBY.Name = "GBOOKEDBY"
        Me.GBOOKEDBY.Visible = True
        Me.GBOOKEDBY.VisibleIndex = 53
        Me.GBOOKEDBY.Width = 90
        '
        'GMODIFIEDBY
        '
        Me.GMODIFIEDBY.Caption = "Modified By"
        Me.GMODIFIEDBY.FieldName = "MODIFIEDBY"
        Me.GMODIFIEDBY.Name = "GMODIFIEDBY"
        Me.GMODIFIEDBY.Visible = True
        Me.GMODIFIEDBY.VisibleIndex = 54
        Me.GMODIFIEDBY.Width = 90
        '
        'GCANCEL
        '
        Me.GCANCEL.Caption = "Cancelled"
        Me.GCANCEL.FieldName = "CANCELLED"
        Me.GCANCEL.Name = "GCANCEL"
        '
        'GAMENDED
        '
        Me.GAMENDED.Caption = "Amended"
        Me.GAMENDED.FieldName = "AMENDED"
        Me.GAMENDED.Name = "GAMENDED"
        '
        'GBILLCHECKED
        '
        Me.GBILLCHECKED.Caption = "Bill Checked"
        Me.GBILLCHECKED.FieldName = "BILLCHECKED"
        Me.GBILLCHECKED.Name = "GBILLCHECKED"
        Me.GBILLCHECKED.Visible = True
        Me.GBILLCHECKED.VisibleIndex = 55
        '
        'GDISPUTE
        '
        Me.GDISPUTE.Caption = "Disputed"
        Me.GDISPUTE.FieldName = "DISPUTED"
        Me.GDISPUTE.Name = "GDISPUTE"
        Me.GDISPUTE.Visible = True
        Me.GDISPUTE.VisibleIndex = 56
        '
        'GBALANCE
        '
        Me.GBALANCE.Caption = "Balance"
        Me.GBALANCE.DisplayFormat.FormatString = "0.00"
        Me.GBALANCE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GBALANCE.FieldName = "BALANCE"
        Me.GBALANCE.Name = "GBALANCE"
        Me.GBALANCE.Visible = True
        Me.GBALANCE.VisibleIndex = 57
        '
        'GEMAIL
        '
        Me.GEMAIL.Caption = "EMail Address"
        Me.GEMAIL.FieldName = "EMAIL"
        Me.GEMAIL.Name = "GEMAIL"
        Me.GEMAIL.Visible = True
        Me.GEMAIL.VisibleIndex = 58
        '
        'GRETURN
        '
        Me.GRETURN.Caption = "SALERETURN"
        Me.GRETURN.FieldName = "SALERETURN"
        Me.GRETURN.Name = "GRETURN"
        '
        'GREFUNDED
        '
        Me.GREFUNDED.Caption = "REFUNDED"
        Me.GREFUNDED.FieldName = "REFUNDED"
        Me.GREFUNDED.Name = "GREFUNDED"
        '
        'GFAILED
        '
        Me.GFAILED.Caption = "FAILED"
        Me.GFAILED.FieldName = "FAILED"
        Me.GFAILED.Name = "GFAILED"
        '
        'GARRFROM
        '
        Me.GARRFROM.Caption = "Arr. From"
        Me.GARRFROM.FieldName = "ARRFROM"
        Me.GARRFROM.Name = "GARRFROM"
        Me.GARRFROM.Visible = True
        Me.GARRFROM.VisibleIndex = 59
        '
        'GARRFLIGHTNO
        '
        Me.GARRFLIGHTNO.Caption = "Arr. Flight No."
        Me.GARRFLIGHTNO.FieldName = "ARRFLIGHTNO"
        Me.GARRFLIGHTNO.Name = "GARRFLIGHTNO"
        Me.GARRFLIGHTNO.Visible = True
        Me.GARRFLIGHTNO.VisibleIndex = 60
        '
        'GDEPTTO
        '
        Me.GDEPTTO.Caption = "Depart To"
        Me.GDEPTTO.FieldName = "DEPARTTO"
        Me.GDEPTTO.Name = "GDEPTTO"
        Me.GDEPTTO.Visible = True
        Me.GDEPTTO.VisibleIndex = 61
        '
        'GDEPTTOFLIGHTNO
        '
        Me.GDEPTTOFLIGHTNO.Caption = "Dept. Flight No."
        Me.GDEPTTOFLIGHTNO.FieldName = "DEPARTFLIGHTNO"
        Me.GDEPTTOFLIGHTNO.Name = "GDEPTTOFLIGHTNO"
        Me.GDEPTTOFLIGHTNO.Visible = True
        Me.GDEPTTOFLIGHTNO.VisibleIndex = 62
        '
        'GPURTAXSERVCHGS
        '
        Me.GPURTAXSERVCHGS.Caption = "Pur Serv. Chgs"
        Me.GPURTAXSERVCHGS.FieldName = "PURTAXSERVCHGS"
        Me.GPURTAXSERVCHGS.Name = "GPURTAXSERVCHGS"
        Me.GPURTAXSERVCHGS.Visible = True
        Me.GPURTAXSERVCHGS.VisibleIndex = 63
        '
        'GTAXSERVCHGS
        '
        Me.GTAXSERVCHGS.Caption = "Sale Serv. Chgs"
        Me.GTAXSERVCHGS.FieldName = "TAXSERVCHGS"
        Me.GTAXSERVCHGS.Name = "GTAXSERVCHGS"
        Me.GTAXSERVCHGS.Visible = True
        Me.GTAXSERVCHGS.VisibleIndex = 64
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.toolStripSeparator, Me.ExcelExport, Me.PRINTTOOL, Me.TOOLMAIL, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1010, 25)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(59, 22)
        Me.ToolStripButton1.Text = "Add New"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'ExcelExport
        '
        Me.ExcelExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ExcelExport.Image = Global.HOSPITALITY.My.Resources.Resources.Excel_icon
        Me.ExcelExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ExcelExport.Name = "ExcelExport"
        Me.ExcelExport.Size = New System.Drawing.Size(23, 22)
        Me.ExcelExport.Text = "&Export to Excel"
        '
        'PRINTTOOL
        '
        Me.PRINTTOOL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PRINTTOOL.Image = CType(resources.GetObject("PRINTTOOL.Image"), System.Drawing.Image)
        Me.PRINTTOOL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PRINTTOOL.Name = "PRINTTOOL"
        Me.PRINTTOOL.Size = New System.Drawing.Size(23, 22)
        Me.PRINTTOOL.Text = "&Print"
        '
        'TOOLMAIL
        '
        Me.TOOLMAIL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLMAIL.Image = Global.HOSPITALITY.My.Resources.Resources.MAIL_IMAGE
        Me.TOOLMAIL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLMAIL.Name = "TOOLMAIL"
        Me.TOOLMAIL.Size = New System.Drawing.Size(23, 22)
        Me.TOOLMAIL.Text = "Mail Challan Directly"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(20, 44)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(153, 14)
        Me.lbl.TabIndex = 251
        Me.lbl.Text = "Select a Voucher to Change"
        '
        'ProformaHotelBookingsDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1010, 669)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "ProformaHotelBookingsDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "ProformaHotelBookingsDetails"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PRINTDIALOG As PrintDialog
    Friend WithEvents PRINTDOC As Printing.PrintDocument
    Private WithEvents imageList1 As ImageList
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents Label11 As Label
    Friend WithEvents TXTCOPIES As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents LBLTO As Label
    Friend WithEvents LBLFROM As Label
    Friend WithEvents TXTTO As TextBox
    Friend WithEvents TXTFROM As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents CMDOK As Button
    Friend WithEvents cmdcancel As Button
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GINITIALS As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gsrno As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREFNO As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gdate As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ghotelname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gaccname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGSTIN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTATENAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTATECODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURGSTIN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURSTATENAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURSTATECODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents garrival As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gdeparture As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gtotalpax As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gtotalrooms As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURHSNCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gDISCRECDRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gCOMMRECDRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gPURTDSRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gPUREXTRACHGS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURSERVCHGS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURCGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PURSGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURIGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURSUBTOTAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURTAXNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURTAXAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gPURADDTAXNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gPURADDTAX As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gtotalpurchase As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gPUROTHERCHGSNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gPUROTHERCHGS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gPURROUNDOFF As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURCHASEBALANCE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GHSNCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALSALEAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDISC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GEXTRACHGS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSUBTOTAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOURCOMMRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GIGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTAXNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TAXAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOTHERCHGSNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOTHERCHGS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GROUNDOFF As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gtotalsale As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSALEBALANCE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBOOKEDBY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMODIFIEDBY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCANCEL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAMENDED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBILLCHECKED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDISPUTE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBALANCE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GEMAIL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRETURN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREFUNDED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFAILED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GARRFROM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GARRFLIGHTNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDEPTTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDEPTTOFLIGHTNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURTAXSERVCHGS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTAXSERVCHGS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents ExcelExport As ToolStripButton
    Friend WithEvents PRINTTOOL As ToolStripButton
    Friend WithEvents TOOLMAIL As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents lbl As Label
End Class
