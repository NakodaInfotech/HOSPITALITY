<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RailwayBookingDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RailwayBookingDetails))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.TXTCOPIES = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.LBLTO = New System.Windows.Forms.Label()
        Me.LBLFROM = New System.Windows.Forms.Label()
        Me.TXTTO = New System.Windows.Forms.TextBox()
        Me.TXTFROM = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GINITIALS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gsrno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gdate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GJOURNEYDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gaccname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGSTIN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSTATENAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSTATECODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURGSTIN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURSTATENAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURSTATECODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLOGIN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTRAINNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTRAINNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gtotalpax = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCLASS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFROM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GQUOTA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFARE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GIRCTC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGATEWAY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GHSNCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURSERVCHGS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURCGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURSGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURIGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALPURAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDISCRECDRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCOMMRECDRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURTDSRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPUREXTRACHGS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURSUBTOTAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURROUNDOFF = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gtotalpurchase = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSERVICECHGS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GIGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTAXNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTAXAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALSALEAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOURCOMMRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GEXTRACHGS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSUBTOTAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GROUNDOFF = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gtotalsale = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCANCEL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBILLCHECKED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDISPUTE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBALANCE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRETURN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREFUNDED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFAILED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GIRNNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GACKNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GACKDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GQRCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ExcelExport = New System.Windows.Forms.ToolStripButton()
        Me.PRINTTOOL = New System.Windows.Forms.ToolStripButton()
        Me.TOOLMAIL = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lbl = New System.Windows.Forms.Label()
        Me.PRINTDIALOG = New System.Windows.Forms.PrintDialog()
        Me.PRINTDOC = New System.Drawing.Printing.PrintDocument()
        Me.GTOURNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.TXTCOPIES)
        Me.BlendPanel1.Controls.Add(Me.Label11)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.Label10)
        Me.BlendPanel1.Controls.Add(Me.LBLTO)
        Me.BlendPanel1.Controls.Add(Me.LBLFROM)
        Me.BlendPanel1.Controls.Add(Me.TXTTO)
        Me.BlendPanel1.Controls.Add(Me.TXTFROM)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.Label8)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.Label2)
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
        Me.BlendPanel1.Size = New System.Drawing.Size(1004, 562)
        Me.BlendPanel1.TabIndex = 4
        '
        'TXTCOPIES
        '
        Me.TXTCOPIES.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCOPIES.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCOPIES.Location = New System.Drawing.Point(398, 1)
        Me.TXTCOPIES.Name = "TXTCOPIES"
        Me.TXTCOPIES.Size = New System.Drawing.Size(29, 22)
        Me.TXTCOPIES.TabIndex = 810
        Me.TXTCOPIES.Text = "1"
        Me.TXTCOPIES.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.White
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(353, 5)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(44, 14)
        Me.Label11.TabIndex = 811
        Me.Label11.Text = "Copies"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(710, 40)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(106, 14)
        Me.Label9.TabIndex = 789
        Me.Label9.Text = "Refunded Voucher"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.PeachPuff
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Location = New System.Drawing.Point(691, 39)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(18, 16)
        Me.Label10.TabIndex = 788
        Me.Label10.Text = "   "
        '
        'LBLTO
        '
        Me.LBLTO.AutoSize = True
        Me.LBLTO.BackColor = System.Drawing.Color.White
        Me.LBLTO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTO.Location = New System.Drawing.Point(247, 5)
        Me.LBLTO.Name = "LBLTO"
        Me.LBLTO.Size = New System.Drawing.Size(19, 14)
        Me.LBLTO.TabIndex = 787
        Me.LBLTO.Text = "To"
        '
        'LBLFROM
        '
        Me.LBLFROM.AutoSize = True
        Me.LBLFROM.BackColor = System.Drawing.Color.White
        Me.LBLFROM.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLFROM.Location = New System.Drawing.Point(149, 5)
        Me.LBLFROM.Name = "LBLFROM"
        Me.LBLFROM.Size = New System.Drawing.Size(34, 14)
        Me.LBLFROM.TabIndex = 786
        Me.LBLFROM.Text = "From"
        '
        'TXTTO
        '
        Me.TXTTO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTTO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTO.Location = New System.Drawing.Point(268, 1)
        Me.TXTTO.Name = "TXTTO"
        Me.TXTTO.Size = New System.Drawing.Size(57, 22)
        Me.TXTTO.TabIndex = 785
        Me.TXTTO.TabStop = False
        Me.TXTTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTFROM
        '
        Me.TXTFROM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTFROM.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFROM.Location = New System.Drawing.Point(184, 1)
        Me.TXTFROM.Name = "TXTFROM"
        Me.TXTFROM.Size = New System.Drawing.Size(57, 22)
        Me.TXTFROM.TabIndex = 784
        Me.TXTFROM.TabStop = False
        Me.TXTFROM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(482, 40)
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
        Me.Label8.Location = New System.Drawing.Point(463, 39)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(18, 16)
        Me.Label8.TabIndex = 493
        Me.Label8.Text = "   "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(353, 40)
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
        Me.Label5.Location = New System.Drawing.Point(334, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(18, 16)
        Me.Label5.TabIndex = 491
        Me.Label5.Text = "   "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(588, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 14)
        Me.Label1.TabIndex = 490
        Me.Label1.Text = "Failed Voucher"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Plum
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Location = New System.Drawing.Point(569, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(18, 16)
        Me.Label2.TabIndex = 489
        Me.Label2.Text = "   "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(222, 40)
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
        Me.Label4.Size = New System.Drawing.Size(18, 16)
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
        Me.CMDOK.Location = New System.Drawing.Point(437, 529)
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
        Me.cmdcancel.Location = New System.Drawing.Point(515, 531)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(72, 24)
        Me.cmdcancel.TabIndex = 316
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(13, 59)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(979, 469)
        Me.gridbilldetails.TabIndex = 314
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GINITIALS, Me.gsrno, Me.gdate, Me.GJOURNEYDATE, Me.gaccname, Me.GGSTIN, Me.GSTATENAME, Me.GSTATECODE, Me.GPURNAME, Me.GPURGSTIN, Me.GPURSTATENAME, Me.GPURSTATECODE, Me.GLOGIN, Me.GTRAINNAME, Me.GTRAINNO, Me.gtotalpax, Me.GCLASS, Me.GFROM, Me.GTO, Me.GQUOTA, Me.GFARE, Me.GIRCTC, Me.GGATEWAY, Me.GHSNCODE, Me.GPURSERVCHGS, Me.GPURCGSTAMT, Me.GPURSGSTAMT, Me.GPURIGSTAMT, Me.GTOTALPURAMT, Me.GDISCRECDRS, Me.GCOMMRECDRS, Me.GPURTDSRS, Me.GPUREXTRACHGS, Me.GPURSUBTOTAL, Me.GPURROUNDOFF, Me.gtotalpurchase, Me.GSERVICECHGS, Me.GCGSTAMT, Me.GSGSTAMT, Me.GIGSTAMT, Me.GTAXNAME, Me.GTAXAMT, Me.GTOTALSALEAMT, Me.GOURCOMMRS, Me.GEXTRACHGS, Me.GSUBTOTAL, Me.GROUNDOFF, Me.gtotalsale, Me.GCANCEL, Me.GBILLCHECKED, Me.GDISPUTE, Me.GBALANCE, Me.GRETURN, Me.GREFUNDED, Me.GFAILED, Me.GIRNNO, Me.GACKNO, Me.GACKDATE, Me.GQRCODE, Me.GTOURNAME})
        Me.gridbill.GridControl = Me.gridbilldetails
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
        'gdate
        '
        Me.gdate.Caption = "Date"
        Me.gdate.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.gdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.gdate.FieldName = "DATE"
        Me.gdate.Name = "gdate"
        Me.gdate.Visible = True
        Me.gdate.VisibleIndex = 2
        Me.gdate.Width = 70
        '
        'GJOURNEYDATE
        '
        Me.GJOURNEYDATE.Caption = "Journey Date"
        Me.GJOURNEYDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GJOURNEYDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GJOURNEYDATE.FieldName = "JOURNEYDATE"
        Me.GJOURNEYDATE.Name = "GJOURNEYDATE"
        Me.GJOURNEYDATE.Visible = True
        Me.GJOURNEYDATE.VisibleIndex = 3
        '
        'gaccname
        '
        Me.gaccname.Caption = "Account Name"
        Me.gaccname.FieldName = "NAME"
        Me.gaccname.Name = "gaccname"
        Me.gaccname.Visible = True
        Me.gaccname.VisibleIndex = 4
        Me.gaccname.Width = 200
        '
        'GGSTIN
        '
        Me.GGSTIN.Caption = "GSTIN"
        Me.GGSTIN.FieldName = "GSTIN"
        Me.GGSTIN.Name = "GGSTIN"
        Me.GGSTIN.Visible = True
        Me.GGSTIN.VisibleIndex = 5
        Me.GGSTIN.Width = 100
        '
        'GSTATENAME
        '
        Me.GSTATENAME.Caption = "State Name"
        Me.GSTATENAME.FieldName = "STATENAME"
        Me.GSTATENAME.Name = "GSTATENAME"
        Me.GSTATENAME.Visible = True
        Me.GSTATENAME.VisibleIndex = 6
        '
        'GSTATECODE
        '
        Me.GSTATECODE.Caption = "State Code"
        Me.GSTATECODE.FieldName = "STATECODE"
        Me.GSTATECODE.Name = "GSTATECODE"
        Me.GSTATECODE.Visible = True
        Me.GSTATECODE.VisibleIndex = 7
        '
        'GPURNAME
        '
        Me.GPURNAME.Caption = "Purchase A/C  Name"
        Me.GPURNAME.FieldName = "PURNAME"
        Me.GPURNAME.Name = "GPURNAME"
        Me.GPURNAME.Visible = True
        Me.GPURNAME.VisibleIndex = 8
        Me.GPURNAME.Width = 200
        '
        'GPURGSTIN
        '
        Me.GPURGSTIN.Caption = "Purchase GSTIN"
        Me.GPURGSTIN.FieldName = "PURGSTIN"
        Me.GPURGSTIN.Name = "GPURGSTIN"
        Me.GPURGSTIN.Visible = True
        Me.GPURGSTIN.VisibleIndex = 9
        Me.GPURGSTIN.Width = 100
        '
        'GPURSTATENAME
        '
        Me.GPURSTATENAME.Caption = "Pur. State Name"
        Me.GPURSTATENAME.FieldName = "PURSTATENAME"
        Me.GPURSTATENAME.Name = "GPURSTATENAME"
        Me.GPURSTATENAME.Visible = True
        Me.GPURSTATENAME.VisibleIndex = 10
        '
        'GPURSTATECODE
        '
        Me.GPURSTATECODE.Caption = "Pur. State Code"
        Me.GPURSTATECODE.FieldName = "PURSTATECODE"
        Me.GPURSTATECODE.Name = "GPURSTATECODE"
        Me.GPURSTATECODE.Visible = True
        Me.GPURSTATECODE.VisibleIndex = 11
        '
        'GLOGIN
        '
        Me.GLOGIN.Caption = "Login Id"
        Me.GLOGIN.FieldName = "LOGINID"
        Me.GLOGIN.Name = "GLOGIN"
        Me.GLOGIN.Visible = True
        Me.GLOGIN.VisibleIndex = 12
        Me.GLOGIN.Width = 90
        '
        'GTRAINNAME
        '
        Me.GTRAINNAME.Caption = "Train Name"
        Me.GTRAINNAME.FieldName = "TRAINNAME"
        Me.GTRAINNAME.Name = "GTRAINNAME"
        Me.GTRAINNAME.Visible = True
        Me.GTRAINNAME.VisibleIndex = 13
        Me.GTRAINNAME.Width = 130
        '
        'GTRAINNO
        '
        Me.GTRAINNO.Caption = "Train No"
        Me.GTRAINNO.FieldName = "TRAINNO"
        Me.GTRAINNO.Name = "GTRAINNO"
        Me.GTRAINNO.Visible = True
        Me.GTRAINNO.VisibleIndex = 14
        '
        'gtotalpax
        '
        Me.gtotalpax.Caption = "Total Pax"
        Me.gtotalpax.FieldName = "TOTALPAX"
        Me.gtotalpax.Name = "gtotalpax"
        Me.gtotalpax.Visible = True
        Me.gtotalpax.VisibleIndex = 15
        '
        'GCLASS
        '
        Me.GCLASS.Caption = "Class"
        Me.GCLASS.FieldName = "CLASS"
        Me.GCLASS.Name = "GCLASS"
        Me.GCLASS.Visible = True
        Me.GCLASS.VisibleIndex = 16
        Me.GCLASS.Width = 50
        '
        'GFROM
        '
        Me.GFROM.Caption = "From"
        Me.GFROM.FieldName = "FROM"
        Me.GFROM.Name = "GFROM"
        Me.GFROM.Visible = True
        Me.GFROM.VisibleIndex = 17
        Me.GFROM.Width = 50
        '
        'GTO
        '
        Me.GTO.Caption = "To"
        Me.GTO.FieldName = "TO"
        Me.GTO.Name = "GTO"
        Me.GTO.Visible = True
        Me.GTO.VisibleIndex = 18
        Me.GTO.Width = 50
        '
        'GQUOTA
        '
        Me.GQUOTA.Caption = "Quota"
        Me.GQUOTA.FieldName = "QUOTA"
        Me.GQUOTA.Name = "GQUOTA"
        Me.GQUOTA.Visible = True
        Me.GQUOTA.VisibleIndex = 19
        Me.GQUOTA.Width = 50
        '
        'GFARE
        '
        Me.GFARE.Caption = "Fare"
        Me.GFARE.FieldName = "FARE"
        Me.GFARE.Name = "GFARE"
        Me.GFARE.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GFARE.Visible = True
        Me.GFARE.VisibleIndex = 20
        '
        'GIRCTC
        '
        Me.GIRCTC.Caption = "IRCTC"
        Me.GIRCTC.FieldName = "IRCTC"
        Me.GIRCTC.Name = "GIRCTC"
        Me.GIRCTC.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GIRCTC.Visible = True
        Me.GIRCTC.VisibleIndex = 21
        '
        'GGATEWAY
        '
        Me.GGATEWAY.Caption = "Gateway"
        Me.GGATEWAY.FieldName = "GATEWAY"
        Me.GGATEWAY.Name = "GGATEWAY"
        Me.GGATEWAY.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GGATEWAY.Visible = True
        Me.GGATEWAY.VisibleIndex = 22
        '
        'GHSNCODE
        '
        Me.GHSNCODE.Caption = "HSN Code"
        Me.GHSNCODE.FieldName = "HSNCODE"
        Me.GHSNCODE.Name = "GHSNCODE"
        Me.GHSNCODE.Visible = True
        Me.GHSNCODE.VisibleIndex = 23
        '
        'GPURSERVCHGS
        '
        Me.GPURSERVCHGS.Caption = "Pur Serv Chgs"
        Me.GPURSERVCHGS.DisplayFormat.FormatString = "0.00"
        Me.GPURSERVCHGS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPURSERVCHGS.FieldName = "PURSERVCHGS"
        Me.GPURSERVCHGS.Name = "GPURSERVCHGS"
        Me.GPURSERVCHGS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPURSERVCHGS.Visible = True
        Me.GPURSERVCHGS.VisibleIndex = 24
        '
        'GPURCGSTAMT
        '
        Me.GPURCGSTAMT.Caption = "Pur CGST Amt"
        Me.GPURCGSTAMT.DisplayFormat.FormatString = "0.00"
        Me.GPURCGSTAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPURCGSTAMT.FieldName = "PURCGSTAMT"
        Me.GPURCGSTAMT.Name = "GPURCGSTAMT"
        Me.GPURCGSTAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPURCGSTAMT.Visible = True
        Me.GPURCGSTAMT.VisibleIndex = 25
        '
        'GPURSGSTAMT
        '
        Me.GPURSGSTAMT.Caption = "Pur SGST Amt"
        Me.GPURSGSTAMT.DisplayFormat.FormatString = "0.00"
        Me.GPURSGSTAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPURSGSTAMT.FieldName = "PURSGSTAMT"
        Me.GPURSGSTAMT.Name = "GPURSGSTAMT"
        Me.GPURSGSTAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPURSGSTAMT.Visible = True
        Me.GPURSGSTAMT.VisibleIndex = 26
        '
        'GPURIGSTAMT
        '
        Me.GPURIGSTAMT.Caption = "Pur IGST Amt"
        Me.GPURIGSTAMT.DisplayFormat.FormatString = "0.00"
        Me.GPURIGSTAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPURIGSTAMT.FieldName = "PURIGSTAMT"
        Me.GPURIGSTAMT.Name = "GPURIGSTAMT"
        Me.GPURIGSTAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPURIGSTAMT.Visible = True
        Me.GPURIGSTAMT.VisibleIndex = 27
        '
        'GTOTALPURAMT
        '
        Me.GTOTALPURAMT.Caption = "Total Pur Amt."
        Me.GTOTALPURAMT.DisplayFormat.FormatString = "0.00"
        Me.GTOTALPURAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALPURAMT.FieldName = "TOTALPURAMT"
        Me.GTOTALPURAMT.Name = "GTOTALPURAMT"
        Me.GTOTALPURAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALPURAMT.Visible = True
        Me.GTOTALPURAMT.VisibleIndex = 28
        '
        'GDISCRECDRS
        '
        Me.GDISCRECDRS.Caption = "Pur. Dis. Recd."
        Me.GDISCRECDRS.DisplayFormat.FormatString = "0.00"
        Me.GDISCRECDRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GDISCRECDRS.FieldName = "DISCRECDRS"
        Me.GDISCRECDRS.Name = "GDISCRECDRS"
        Me.GDISCRECDRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GDISCRECDRS.Visible = True
        Me.GDISCRECDRS.VisibleIndex = 29
        '
        'GCOMMRECDRS
        '
        Me.GCOMMRECDRS.Caption = "Pur. Comm. Recd."
        Me.GCOMMRECDRS.DisplayFormat.FormatString = "0.00"
        Me.GCOMMRECDRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCOMMRECDRS.FieldName = "COMMRECDRS"
        Me.GCOMMRECDRS.Name = "GCOMMRECDRS"
        Me.GCOMMRECDRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GCOMMRECDRS.Visible = True
        Me.GCOMMRECDRS.VisibleIndex = 30
        '
        'GPURTDSRS
        '
        Me.GPURTDSRS.Caption = "Pur. TDS"
        Me.GPURTDSRS.DisplayFormat.FormatString = "0.00"
        Me.GPURTDSRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPURTDSRS.FieldName = "PURTDSRS"
        Me.GPURTDSRS.Name = "GPURTDSRS"
        Me.GPURTDSRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPURTDSRS.Visible = True
        Me.GPURTDSRS.VisibleIndex = 31
        '
        'GPUREXTRACHGS
        '
        Me.GPUREXTRACHGS.Caption = "Pur. Extra Chgs."
        Me.GPUREXTRACHGS.DisplayFormat.FormatString = "0.00"
        Me.GPUREXTRACHGS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPUREXTRACHGS.FieldName = "PUREXTRACHGS"
        Me.GPUREXTRACHGS.Name = "GPUREXTRACHGS"
        Me.GPUREXTRACHGS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPUREXTRACHGS.Visible = True
        Me.GPUREXTRACHGS.VisibleIndex = 32
        '
        'GPURSUBTOTAL
        '
        Me.GPURSUBTOTAL.Caption = "Pur. Subtotal"
        Me.GPURSUBTOTAL.DisplayFormat.FormatString = "0.00"
        Me.GPURSUBTOTAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPURSUBTOTAL.FieldName = "PURSUBTOTAL"
        Me.GPURSUBTOTAL.Name = "GPURSUBTOTAL"
        Me.GPURSUBTOTAL.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPURSUBTOTAL.Visible = True
        Me.GPURSUBTOTAL.VisibleIndex = 33
        '
        'GPURROUNDOFF
        '
        Me.GPURROUNDOFF.Caption = "Pur. Roundoff"
        Me.GPURROUNDOFF.DisplayFormat.FormatString = "0.00"
        Me.GPURROUNDOFF.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPURROUNDOFF.FieldName = "PURROUNDOFF"
        Me.GPURROUNDOFF.Name = "GPURROUNDOFF"
        Me.GPURROUNDOFF.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPURROUNDOFF.Visible = True
        Me.GPURROUNDOFF.VisibleIndex = 34
        '
        'gtotalpurchase
        '
        Me.gtotalpurchase.Caption = "Purchase Amt"
        Me.gtotalpurchase.DisplayFormat.FormatString = "0.00"
        Me.gtotalpurchase.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.gtotalpurchase.FieldName = "PURTOTAL"
        Me.gtotalpurchase.Name = "gtotalpurchase"
        Me.gtotalpurchase.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.gtotalpurchase.Visible = True
        Me.gtotalpurchase.VisibleIndex = 35
        Me.gtotalpurchase.Width = 90
        '
        'GSERVICECHGS
        '
        Me.GSERVICECHGS.Caption = "Service Chgs"
        Me.GSERVICECHGS.DisplayFormat.FormatString = "0.00"
        Me.GSERVICECHGS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSERVICECHGS.FieldName = "SERVICECHGS"
        Me.GSERVICECHGS.Name = "GSERVICECHGS"
        Me.GSERVICECHGS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GSERVICECHGS.Visible = True
        Me.GSERVICECHGS.VisibleIndex = 36
        '
        'GCGSTAMT
        '
        Me.GCGSTAMT.Caption = "CGST Amt."
        Me.GCGSTAMT.DisplayFormat.FormatString = "0.00"
        Me.GCGSTAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCGSTAMT.FieldName = "CGSTAMT"
        Me.GCGSTAMT.Name = "GCGSTAMT"
        Me.GCGSTAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GCGSTAMT.Visible = True
        Me.GCGSTAMT.VisibleIndex = 37
        '
        'GSGSTAMT
        '
        Me.GSGSTAMT.Caption = "SGST Amt."
        Me.GSGSTAMT.DisplayFormat.FormatString = "0.00"
        Me.GSGSTAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSGSTAMT.FieldName = "SGSTAMT"
        Me.GSGSTAMT.Name = "GSGSTAMT"
        Me.GSGSTAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GSGSTAMT.Visible = True
        Me.GSGSTAMT.VisibleIndex = 38
        '
        'GIGSTAMT
        '
        Me.GIGSTAMT.Caption = "IGST Amt."
        Me.GIGSTAMT.DisplayFormat.FormatString = "0.00"
        Me.GIGSTAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GIGSTAMT.FieldName = "IGSTAMT"
        Me.GIGSTAMT.Name = "GIGSTAMT"
        Me.GIGSTAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GIGSTAMT.Visible = True
        Me.GIGSTAMT.VisibleIndex = 39
        '
        'GTAXNAME
        '
        Me.GTAXNAME.Caption = "Tax Name"
        Me.GTAXNAME.FieldName = "TAXNAME"
        Me.GTAXNAME.Name = "GTAXNAME"
        Me.GTAXNAME.Visible = True
        Me.GTAXNAME.VisibleIndex = 40
        '
        'GTAXAMT
        '
        Me.GTAXAMT.Caption = "Tax Amt"
        Me.GTAXAMT.FieldName = "TAXAMT"
        Me.GTAXAMT.Name = "GTAXAMT"
        Me.GTAXAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTAXAMT.Visible = True
        Me.GTAXAMT.VisibleIndex = 41
        '
        'GTOTALSALEAMT
        '
        Me.GTOTALSALEAMT.Caption = "Total Sale Amt."
        Me.GTOTALSALEAMT.DisplayFormat.FormatString = "0.00"
        Me.GTOTALSALEAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALSALEAMT.FieldName = "TOTALSALEAMT"
        Me.GTOTALSALEAMT.Name = "GTOTALSALEAMT"
        Me.GTOTALSALEAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALSALEAMT.Visible = True
        Me.GTOTALSALEAMT.VisibleIndex = 42
        '
        'GOURCOMMRS
        '
        Me.GOURCOMMRS.Caption = "Comm Recd."
        Me.GOURCOMMRS.DisplayFormat.FormatString = "0.00"
        Me.GOURCOMMRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GOURCOMMRS.FieldName = "OURCOMMRS"
        Me.GOURCOMMRS.Name = "GOURCOMMRS"
        Me.GOURCOMMRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GOURCOMMRS.Visible = True
        Me.GOURCOMMRS.VisibleIndex = 43
        '
        'GEXTRACHGS
        '
        Me.GEXTRACHGS.Caption = "Extra Chgs."
        Me.GEXTRACHGS.DisplayFormat.FormatString = "0.00"
        Me.GEXTRACHGS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GEXTRACHGS.FieldName = "EXTRACHGS"
        Me.GEXTRACHGS.Name = "GEXTRACHGS"
        Me.GEXTRACHGS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GEXTRACHGS.Visible = True
        Me.GEXTRACHGS.VisibleIndex = 44
        '
        'GSUBTOTAL
        '
        Me.GSUBTOTAL.Caption = "Subtotal"
        Me.GSUBTOTAL.DisplayFormat.FormatString = "0.00"
        Me.GSUBTOTAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSUBTOTAL.FieldName = "SUBTOTAL"
        Me.GSUBTOTAL.Name = "GSUBTOTAL"
        Me.GSUBTOTAL.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GSUBTOTAL.Visible = True
        Me.GSUBTOTAL.VisibleIndex = 45
        '
        'GROUNDOFF
        '
        Me.GROUNDOFF.Caption = "Roundoff"
        Me.GROUNDOFF.DisplayFormat.FormatString = "0.00"
        Me.GROUNDOFF.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GROUNDOFF.FieldName = "ROUNDOFF"
        Me.GROUNDOFF.Name = "GROUNDOFF"
        Me.GROUNDOFF.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GROUNDOFF.Visible = True
        Me.GROUNDOFF.VisibleIndex = 46
        '
        'gtotalsale
        '
        Me.gtotalsale.Caption = "G. Total"
        Me.gtotalsale.DisplayFormat.FormatString = "0.00"
        Me.gtotalsale.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.gtotalsale.FieldName = "GTOTAL"
        Me.gtotalsale.Name = "gtotalsale"
        Me.gtotalsale.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.gtotalsale.Visible = True
        Me.gtotalsale.VisibleIndex = 47
        '
        'GCANCEL
        '
        Me.GCANCEL.Caption = "Cancelled"
        Me.GCANCEL.FieldName = "CANCELLED"
        Me.GCANCEL.Name = "GCANCEL"
        '
        'GBILLCHECKED
        '
        Me.GBILLCHECKED.Caption = "Bill Checked"
        Me.GBILLCHECKED.FieldName = "BILLCHECKED"
        Me.GBILLCHECKED.Name = "GBILLCHECKED"
        Me.GBILLCHECKED.Visible = True
        Me.GBILLCHECKED.VisibleIndex = 50
        '
        'GDISPUTE
        '
        Me.GDISPUTE.Caption = "Disputed"
        Me.GDISPUTE.FieldName = "DISPUTED"
        Me.GDISPUTE.Name = "GDISPUTE"
        Me.GDISPUTE.Visible = True
        Me.GDISPUTE.VisibleIndex = 48
        '
        'GBALANCE
        '
        Me.GBALANCE.Caption = "Balance"
        Me.GBALANCE.DisplayFormat.FormatString = "0.00"
        Me.GBALANCE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GBALANCE.FieldName = "BALANCE"
        Me.GBALANCE.Name = "GBALANCE"
        Me.GBALANCE.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GBALANCE.Visible = True
        Me.GBALANCE.VisibleIndex = 49
        '
        'GRETURN
        '
        Me.GRETURN.Caption = "RETURN"
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
        'GIRNNO
        '
        Me.GIRNNO.Caption = "IRN No"
        Me.GIRNNO.FieldName = "IRNNO"
        Me.GIRNNO.Name = "GIRNNO"
        Me.GIRNNO.Visible = True
        Me.GIRNNO.VisibleIndex = 51
        '
        'GACKNO
        '
        Me.GACKNO.Caption = "ACK No"
        Me.GACKNO.FieldName = "ACKNO"
        Me.GACKNO.Name = "GACKNO"
        Me.GACKNO.Visible = True
        Me.GACKNO.VisibleIndex = 52
        '
        'GACKDATE
        '
        Me.GACKDATE.Caption = "ACK Date"
        Me.GACKDATE.FieldName = "ACKDATE"
        Me.GACKDATE.Name = "GACKDATE"
        Me.GACKDATE.Visible = True
        Me.GACKDATE.VisibleIndex = 53
        '
        'GQRCODE
        '
        Me.GQRCODE.Caption = "QR Code"
        Me.GQRCODE.FieldName = "QRCODE"
        Me.GQRCODE.Name = "GQRCODE"
        Me.GQRCODE.Visible = True
        Me.GQRCODE.VisibleIndex = 54
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.toolStripSeparator, Me.ExcelExport, Me.PRINTTOOL, Me.TOOLMAIL, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1004, 25)
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
        'PRINTDIALOG
        '
        Me.PRINTDIALOG.AllowSelection = True
        Me.PRINTDIALOG.AllowSomePages = True
        Me.PRINTDIALOG.ShowHelp = True
        Me.PRINTDIALOG.UseEXDialog = True
        '
        'GTOURNAME
        '
        Me.GTOURNAME.Caption = "Tour Name"
        Me.GTOURNAME.FieldName = "TOURNAME"
        Me.GTOURNAME.Name = "GTOURNAME"
        Me.GTOURNAME.OptionsColumn.AllowEdit = False
        Me.GTOURNAME.Visible = True
        Me.GTOURNAME.VisibleIndex = 55
        Me.GTOURNAME.Width = 120
        '
        'RailwayBookingDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1004, 562)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "RailwayBookingDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Railway Booking Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CMDOK As System.Windows.Forms.Button
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GINITIALS As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gsrno As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gdate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gaccname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLOGIN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTRAINNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gtotalpax As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCLASS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gtotalpurchase As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gtotalsale As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCANCEL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBILLCHECKED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDISPUTE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBALANCE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExcelExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents GJOURNEYDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTRAINNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFROM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GQUOTA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFARE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GIRCTC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGATEWAY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LBLTO As System.Windows.Forms.Label
    Friend WithEvents LBLFROM As System.Windows.Forms.Label
    Friend WithEvents TXTTO As System.Windows.Forms.TextBox
    Friend WithEvents TXTFROM As System.Windows.Forms.TextBox
    Friend WithEvents PRINTTOOL As System.Windows.Forms.ToolStripButton
    Friend WithEvents GRETURN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREFUNDED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFAILED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GSERVICECHGS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTAXNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTAXAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURSERVCHGS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURCGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURSGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURIGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GIGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGSTIN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURGSTIN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTATENAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTATECODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURSTATENAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURSTATECODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GHSNCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALPURAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDISCRECDRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURSUBTOTAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCOMMRECDRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURTDSRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPUREXTRACHGS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURROUNDOFF As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALSALEAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOURCOMMRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GEXTRACHGS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSUBTOTAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GROUNDOFF As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TXTCOPIES As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TOOLMAIL As ToolStripButton
    Friend WithEvents PRINTDIALOG As PrintDialog
    Friend WithEvents PRINTDOC As Printing.PrintDocument
    Friend WithEvents GIRNNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GACKNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GACKDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GQRCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOURNAME As DevExpress.XtraGrid.Columns.GridColumn
End Class
