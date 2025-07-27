<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AirlineBookingDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AirlineBookingDetails))
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
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GINITIALS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gsrno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gdate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBSP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCOUPON = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAIRNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURGSTIN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURSTATENAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURSTATECODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gaccname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGSTIN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSTATENAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSTATECODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gticket = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRETURNDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gpnr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gairpnr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcrspnr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREFNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBOOKEDBY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSOURCE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURSERVCHGS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPUROTHERCHGSNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPUROTHERCHGS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURDISCAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gPURADDDISCAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GHSNCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURCGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURSGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURIGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURTAXNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURTAX = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GpurTDS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURTDSRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURROUNDOFF = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gtotalpurchase = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALPURAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBASIC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GYQ = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDISCAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSERVCHGS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GIGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTAXES = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTAXNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gOTHERCHGSNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOTHERCHGS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GROUNDOFF = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALSALEAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gtotalsale = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMARKUP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCANCELLED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBILLCHECKED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDISPUTE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREMARKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GUSER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRETURN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREFUNDED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFAILED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GIRNNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GACKNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GACKDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GQRCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ExcelExport = New System.Windows.Forms.ToolStripButton()
        Me.PRINTTOOL = New System.Windows.Forms.ToolStripButton()
        Me.TOOLMAIL = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TOOLGRIDDETAILS = New System.Windows.Forms.ToolStripButton()
        Me.lbl = New System.Windows.Forms.Label()
        Me.PRINTDOC = New System.Drawing.Printing.PrintDocument()
        Me.PRINTDIALOG = New System.Windows.Forms.PrintDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.TOOLREFRESH = New System.Windows.Forms.ToolStripButton()
        Me.GGROUPDEPARTURE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.BlendPanel1.Controls.Add(Me.Label7)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.Label8)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 582)
        Me.BlendPanel1.TabIndex = 4
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.White
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(768, 6)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(44, 14)
        Me.Label11.TabIndex = 803
        Me.Label11.Text = "Copies"
        '
        'TXTCOPIES
        '
        Me.TXTCOPIES.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCOPIES.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCOPIES.Location = New System.Drawing.Point(813, 2)
        Me.TXTCOPIES.Name = "TXTCOPIES"
        Me.TXTCOPIES.Size = New System.Drawing.Size(29, 22)
        Me.TXTCOPIES.TabIndex = 802
        Me.TXTCOPIES.Text = "1"
        Me.TXTCOPIES.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(686, 42)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(106, 14)
        Me.Label9.TabIndex = 793
        Me.Label9.Text = "Refunded Voucher"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.PeachPuff
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Location = New System.Drawing.Point(664, 41)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(18, 16)
        Me.Label10.TabIndex = 792
        Me.Label10.Text = "   "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(572, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 14)
        Me.Label1.TabIndex = 791
        Me.Label1.Text = "Failed Voucher"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Plum
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Location = New System.Drawing.Point(550, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(18, 16)
        Me.Label2.TabIndex = 790
        Me.Label2.Text = "   "
        '
        'LBLTO
        '
        Me.LBLTO.AutoSize = True
        Me.LBLTO.BackColor = System.Drawing.Color.White
        Me.LBLTO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTO.Location = New System.Drawing.Point(645, 6)
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
        Me.LBLFROM.Location = New System.Drawing.Point(547, 6)
        Me.LBLFROM.Name = "LBLFROM"
        Me.LBLFROM.Size = New System.Drawing.Size(34, 14)
        Me.LBLFROM.TabIndex = 786
        Me.LBLFROM.Text = "From"
        '
        'TXTTO
        '
        Me.TXTTO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTTO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTO.Location = New System.Drawing.Point(666, 2)
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
        Me.TXTFROM.Location = New System.Drawing.Point(582, 2)
        Me.TXTFROM.Name = "TXTFROM"
        Me.TXTFROM.Size = New System.Drawing.Size(57, 22)
        Me.TXTFROM.TabIndex = 784
        Me.TXTFROM.TabStop = False
        Me.TXTFROM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(210, 42)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(107, 14)
        Me.Label7.TabIndex = 496
        Me.Label7.Text = "Cancelled Voucher"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Location = New System.Drawing.Point(188, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(18, 16)
        Me.Label4.TabIndex = 495
        Me.Label4.Text = "   "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(472, 42)
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
        Me.Label8.Location = New System.Drawing.Point(450, 41)
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
        Me.Label3.Location = New System.Drawing.Point(343, 42)
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
        Me.Label5.Location = New System.Drawing.Point(321, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(18, 16)
        Me.Label5.TabIndex = 491
        Me.Label5.Text = "   "
        '
        'CMDOK
        '
        Me.CMDOK.BackColor = System.Drawing.Color.Transparent
        Me.CMDOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDOK.FlatAppearance.BorderSize = 0
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.Black
        Me.CMDOK.Location = New System.Drawing.Point(534, 552)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(80, 28)
        Me.CMDOK.TabIndex = 317
        Me.CMDOK.Text = "&Ok"
        Me.CMDOK.UseVisualStyleBackColor = False
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.Color.Transparent
        Me.cmdcancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdcancel.FlatAppearance.BorderSize = 0
        Me.cmdcancel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.Black
        Me.cmdcancel.Location = New System.Drawing.Point(620, 552)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(80, 28)
        Me.cmdcancel.TabIndex = 316
        Me.cmdcancel.Text = "E&xit"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(14, 59)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1207, 487)
        Me.gridbilldetails.TabIndex = 314
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GINITIALS, Me.gsrno, Me.gdate, Me.GCRS, Me.GBSP, Me.GCOUPON, Me.GAIRNAME, Me.GPURNAME, Me.GPURGSTIN, Me.GPURSTATENAME, Me.GPURSTATECODE, Me.gaccname, Me.GGSTIN, Me.GSTATENAME, Me.GSTATECODE, Me.gticket, Me.GRETURNDATE, Me.gpnr, Me.gairpnr, Me.gcrspnr, Me.GREFNO, Me.GBOOKEDBY, Me.GSOURCE, Me.GPURSERVCHGS, Me.GPUROTHERCHGSNAME, Me.GPUROTHERCHGS, Me.GPURDISCAMT, Me.gPURADDDISCAMT, Me.GHSNCODE, Me.GPURCGSTAMT, Me.GPURSGSTAMT, Me.GPURIGSTAMT, Me.GPURTAXNAME, Me.GPURTAX, Me.GpurTDS, Me.GPURTDSRS, Me.GPURROUNDOFF, Me.gtotalpurchase, Me.GTOTALPURAMT, Me.GBASIC, Me.GYQ, Me.GDISCAMT, Me.GSERVCHGS, Me.GCGSTAMT, Me.GSGSTAMT, Me.GIGSTAMT, Me.GTAXES, Me.GTAXNAME, Me.GST, Me.gOTHERCHGSNAME, Me.GOTHERCHGS, Me.GROUNDOFF, Me.GTOTALSALEAMT, Me.gtotalsale, Me.GMARKUP, Me.GCANCELLED, Me.GBILLCHECKED, Me.GDISPUTE, Me.GREMARKS, Me.GUSER, Me.GRETURN, Me.GREFUNDED, Me.GFAILED, Me.GIRNNO, Me.GACKNO, Me.GACKDATE, Me.GQRCODE, Me.GTOTAL, Me.GPS, Me.GGROUPDEPARTURE})
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
        Me.gridbill.OptionsView.ShowGroupPanel = False
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
        Me.gdate.FieldName = "BOOKINGDATE"
        Me.gdate.Name = "gdate"
        Me.gdate.Visible = True
        Me.gdate.VisibleIndex = 2
        '
        'GCRS
        '
        Me.GCRS.Caption = "CRS"
        Me.GCRS.FieldName = "CRS"
        Me.GCRS.Name = "GCRS"
        Me.GCRS.Visible = True
        Me.GCRS.VisibleIndex = 17
        '
        'GBSP
        '
        Me.GBSP.Caption = "BSP"
        Me.GBSP.FieldName = "BSP"
        Me.GBSP.Name = "GBSP"
        Me.GBSP.Width = 50
        '
        'GCOUPON
        '
        Me.GCOUPON.Caption = "COUPON"
        Me.GCOUPON.FieldName = "COUPON"
        Me.GCOUPON.Name = "GCOUPON"
        Me.GCOUPON.Width = 50
        '
        'GAIRNAME
        '
        Me.GAIRNAME.Caption = "Airline Name"
        Me.GAIRNAME.FieldName = "AIRLINE"
        Me.GAIRNAME.ImageIndex = 0
        Me.GAIRNAME.Name = "GAIRNAME"
        Me.GAIRNAME.Visible = True
        Me.GAIRNAME.VisibleIndex = 4
        Me.GAIRNAME.Width = 150
        '
        'GPURNAME
        '
        Me.GPURNAME.Caption = "Pur Name"
        Me.GPURNAME.FieldName = "PURNAME"
        Me.GPURNAME.Name = "GPURNAME"
        Me.GPURNAME.Visible = True
        Me.GPURNAME.VisibleIndex = 5
        Me.GPURNAME.Width = 200
        '
        'GPURGSTIN
        '
        Me.GPURGSTIN.Caption = "Purchase GSTIN"
        Me.GPURGSTIN.FieldName = "PURGSTIN"
        Me.GPURGSTIN.Name = "GPURGSTIN"
        Me.GPURGSTIN.Visible = True
        Me.GPURGSTIN.VisibleIndex = 6
        Me.GPURGSTIN.Width = 100
        '
        'GPURSTATENAME
        '
        Me.GPURSTATENAME.Caption = "Pur. State Name"
        Me.GPURSTATENAME.FieldName = "PURSTATENAME"
        Me.GPURSTATENAME.Name = "GPURSTATENAME"
        Me.GPURSTATENAME.Visible = True
        Me.GPURSTATENAME.VisibleIndex = 7
        '
        'GPURSTATECODE
        '
        Me.GPURSTATECODE.Caption = "Pur. State Code"
        Me.GPURSTATECODE.FieldName = "PURSTATECODE"
        Me.GPURSTATECODE.Name = "GPURSTATECODE"
        Me.GPURSTATECODE.Visible = True
        Me.GPURSTATECODE.VisibleIndex = 8
        '
        'gaccname
        '
        Me.gaccname.Caption = "Name"
        Me.gaccname.FieldName = "ACCNAME"
        Me.gaccname.Name = "gaccname"
        Me.gaccname.Visible = True
        Me.gaccname.VisibleIndex = 9
        Me.gaccname.Width = 200
        '
        'GGSTIN
        '
        Me.GGSTIN.Caption = "GSTIN"
        Me.GGSTIN.FieldName = "GSTIN"
        Me.GGSTIN.Name = "GGSTIN"
        Me.GGSTIN.Visible = True
        Me.GGSTIN.VisibleIndex = 10
        Me.GGSTIN.Width = 100
        '
        'GSTATENAME
        '
        Me.GSTATENAME.Caption = "State Name"
        Me.GSTATENAME.FieldName = "STATENAME"
        Me.GSTATENAME.Name = "GSTATENAME"
        Me.GSTATENAME.Visible = True
        Me.GSTATENAME.VisibleIndex = 11
        '
        'GSTATECODE
        '
        Me.GSTATECODE.Caption = "State Code"
        Me.GSTATECODE.FieldName = "STATECODE"
        Me.GSTATECODE.Name = "GSTATECODE"
        Me.GSTATECODE.Visible = True
        Me.GSTATECODE.VisibleIndex = 12
        '
        'gticket
        '
        Me.gticket.Caption = "Ticket Date"
        Me.gticket.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.gticket.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.gticket.FieldName = "TICKETDATE"
        Me.gticket.Name = "gticket"
        Me.gticket.Visible = True
        Me.gticket.VisibleIndex = 13
        Me.gticket.Width = 70
        '
        'GRETURNDATE
        '
        Me.GRETURNDATE.Caption = "Return Date"
        Me.GRETURNDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GRETURNDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GRETURNDATE.FieldName = "RETURNDATE"
        Me.GRETURNDATE.Name = "GRETURNDATE"
        Me.GRETURNDATE.Visible = True
        Me.GRETURNDATE.VisibleIndex = 14
        '
        'gpnr
        '
        Me.gpnr.Caption = "PNR"
        Me.gpnr.FieldName = "PNR"
        Me.gpnr.Name = "gpnr"
        Me.gpnr.Visible = True
        Me.gpnr.VisibleIndex = 15
        Me.gpnr.Width = 80
        '
        'gairpnr
        '
        Me.gairpnr.Caption = "AIR PNR"
        Me.gairpnr.FieldName = "AIRPNR"
        Me.gairpnr.Name = "gairpnr"
        Me.gairpnr.Visible = True
        Me.gairpnr.VisibleIndex = 16
        Me.gairpnr.Width = 80
        '
        'gcrspnr
        '
        Me.gcrspnr.Caption = "CRS PNR"
        Me.gcrspnr.FieldName = "CRSPNR"
        Me.gcrspnr.Name = "gcrspnr"
        Me.gcrspnr.Visible = True
        Me.gcrspnr.VisibleIndex = 18
        Me.gcrspnr.Width = 80
        '
        'GREFNO
        '
        Me.GREFNO.Caption = "Ref No"
        Me.GREFNO.FieldName = "REFNO"
        Me.GREFNO.Name = "GREFNO"
        Me.GREFNO.Visible = True
        Me.GREFNO.VisibleIndex = 3
        '
        'GBOOKEDBY
        '
        Me.GBOOKEDBY.Caption = "Booked By"
        Me.GBOOKEDBY.FieldName = "BOOKEDBY"
        Me.GBOOKEDBY.Name = "GBOOKEDBY"
        Me.GBOOKEDBY.Visible = True
        Me.GBOOKEDBY.VisibleIndex = 19
        Me.GBOOKEDBY.Width = 100
        '
        'GSOURCE
        '
        Me.GSOURCE.Caption = "Source"
        Me.GSOURCE.FieldName = "SOURCE"
        Me.GSOURCE.Name = "GSOURCE"
        Me.GSOURCE.Visible = True
        Me.GSOURCE.VisibleIndex = 20
        Me.GSOURCE.Width = 100
        '
        'GPURSERVCHGS
        '
        Me.GPURSERVCHGS.Caption = "Pur. Serv. Chgs."
        Me.GPURSERVCHGS.DisplayFormat.FormatString = "0.00"
        Me.GPURSERVCHGS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPURSERVCHGS.FieldName = "PURSERVCHGS"
        Me.GPURSERVCHGS.Name = "GPURSERVCHGS"
        Me.GPURSERVCHGS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPURSERVCHGS.Visible = True
        Me.GPURSERVCHGS.VisibleIndex = 21
        '
        'GPUROTHERCHGSNAME
        '
        Me.GPUROTHERCHGSNAME.Caption = "Pur Other Chgs Name"
        Me.GPUROTHERCHGSNAME.FieldName = "PUROTHERCHGSNAME"
        Me.GPUROTHERCHGSNAME.Name = "GPUROTHERCHGSNAME"
        Me.GPUROTHERCHGSNAME.Visible = True
        Me.GPUROTHERCHGSNAME.VisibleIndex = 22
        '
        'GPUROTHERCHGS
        '
        Me.GPUROTHERCHGS.Caption = "Pur Other Chgs."
        Me.GPUROTHERCHGS.DisplayFormat.FormatString = "0.00"
        Me.GPUROTHERCHGS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPUROTHERCHGS.FieldName = "PUROTHERCHGS"
        Me.GPUROTHERCHGS.Name = "GPUROTHERCHGS"
        Me.GPUROTHERCHGS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPUROTHERCHGS.Visible = True
        Me.GPUROTHERCHGS.VisibleIndex = 23
        '
        'GPURDISCAMT
        '
        Me.GPURDISCAMT.Caption = "Our Commission"
        Me.GPURDISCAMT.DisplayFormat.FormatString = "0.00"
        Me.GPURDISCAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPURDISCAMT.FieldName = "PURDISCAMT"
        Me.GPURDISCAMT.Name = "GPURDISCAMT"
        Me.GPURDISCAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPURDISCAMT.Visible = True
        Me.GPURDISCAMT.VisibleIndex = 24
        '
        'gPURADDDISCAMT
        '
        Me.gPURADDDISCAMT.Caption = "Pur Add Discount"
        Me.gPURADDDISCAMT.FieldName = "PURADDDISCAMT"
        Me.gPURADDDISCAMT.Name = "gPURADDDISCAMT"
        Me.gPURADDDISCAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.gPURADDDISCAMT.Visible = True
        Me.gPURADDDISCAMT.VisibleIndex = 25
        '
        'GHSNCODE
        '
        Me.GHSNCODE.Caption = "HSN Code"
        Me.GHSNCODE.FieldName = "HSNCODE"
        Me.GHSNCODE.Name = "GHSNCODE"
        Me.GHSNCODE.Visible = True
        Me.GHSNCODE.VisibleIndex = 26
        '
        'GPURCGSTAMT
        '
        Me.GPURCGSTAMT.Caption = "Pur CGST Amt."
        Me.GPURCGSTAMT.DisplayFormat.FormatString = "0.00"
        Me.GPURCGSTAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPURCGSTAMT.FieldName = "PURCGSTAMT"
        Me.GPURCGSTAMT.Name = "GPURCGSTAMT"
        Me.GPURCGSTAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPURCGSTAMT.Visible = True
        Me.GPURCGSTAMT.VisibleIndex = 27
        '
        'GPURSGSTAMT
        '
        Me.GPURSGSTAMT.Caption = "Pur SGST Amt."
        Me.GPURSGSTAMT.DisplayFormat.FormatString = "0.00"
        Me.GPURSGSTAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPURSGSTAMT.FieldName = "PURSGSTAMT"
        Me.GPURSGSTAMT.Name = "GPURSGSTAMT"
        Me.GPURSGSTAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPURSGSTAMT.Visible = True
        Me.GPURSGSTAMT.VisibleIndex = 28
        '
        'GPURIGSTAMT
        '
        Me.GPURIGSTAMT.Caption = "Pur IGST Amt."
        Me.GPURIGSTAMT.DisplayFormat.FormatString = "0.00"
        Me.GPURIGSTAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPURIGSTAMT.FieldName = "PURIGSTAMT"
        Me.GPURIGSTAMT.Name = "GPURIGSTAMT"
        Me.GPURIGSTAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPURIGSTAMT.Visible = True
        Me.GPURIGSTAMT.VisibleIndex = 29
        '
        'GPURTAXNAME
        '
        Me.GPURTAXNAME.Caption = "Pur Tax Name"
        Me.GPURTAXNAME.FieldName = "PURTAXNAME"
        Me.GPURTAXNAME.Name = "GPURTAXNAME"
        Me.GPURTAXNAME.Visible = True
        Me.GPURTAXNAME.VisibleIndex = 30
        '
        'GPURTAX
        '
        Me.GPURTAX.Caption = "Pur Tax"
        Me.GPURTAX.DisplayFormat.FormatString = "0.00"
        Me.GPURTAX.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPURTAX.FieldName = "PURTAXAMT"
        Me.GPURTAX.Name = "GPURTAX"
        Me.GPURTAX.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPURTAX.Visible = True
        Me.GPURTAX.VisibleIndex = 31
        '
        'GpurTDS
        '
        Me.GpurTDS.Caption = "Pur TDS %"
        Me.GpurTDS.FieldName = "PURTDSPER"
        Me.GpurTDS.Name = "GpurTDS"
        Me.GpurTDS.Visible = True
        Me.GpurTDS.VisibleIndex = 32
        '
        'GPURTDSRS
        '
        Me.GPURTDSRS.Caption = "Pur TDS"
        Me.GPURTDSRS.FieldName = "PURTDSRS"
        Me.GPURTDSRS.Name = "GPURTDSRS"
        Me.GPURTDSRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPURTDSRS.Visible = True
        Me.GPURTDSRS.VisibleIndex = 33
        '
        'GPURROUNDOFF
        '
        Me.GPURROUNDOFF.Caption = "Pur Round Off"
        Me.GPURROUNDOFF.FieldName = "PURROUNDOFF"
        Me.GPURROUNDOFF.Name = "GPURROUNDOFF"
        Me.GPURROUNDOFF.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPURROUNDOFF.Visible = True
        Me.GPURROUNDOFF.VisibleIndex = 34
        '
        'gtotalpurchase
        '
        Me.gtotalpurchase.Caption = "Purchase Amt"
        Me.gtotalpurchase.FieldName = "PURTOTAL"
        Me.gtotalpurchase.Name = "gtotalpurchase"
        Me.gtotalpurchase.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.gtotalpurchase.Visible = True
        Me.gtotalpurchase.VisibleIndex = 57
        Me.gtotalpurchase.Width = 90
        '
        'GTOTALPURAMT
        '
        Me.GTOTALPURAMT.Caption = "Total Pur Amt."
        Me.GTOTALPURAMT.FieldName = "TOTALPURAMT"
        Me.GTOTALPURAMT.Name = "GTOTALPURAMT"
        Me.GTOTALPURAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALPURAMT.Visible = True
        Me.GTOTALPURAMT.VisibleIndex = 35
        '
        'GBASIC
        '
        Me.GBASIC.Caption = "Basic"
        Me.GBASIC.DisplayFormat.FormatString = "0.00"
        Me.GBASIC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GBASIC.FieldName = "BASIC"
        Me.GBASIC.Name = "GBASIC"
        Me.GBASIC.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GBASIC.Visible = True
        Me.GBASIC.VisibleIndex = 36
        '
        'GYQ
        '
        Me.GYQ.Caption = "YQ"
        Me.GYQ.DisplayFormat.FormatString = "0.00"
        Me.GYQ.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GYQ.FieldName = "YQ"
        Me.GYQ.Name = "GYQ"
        Me.GYQ.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GYQ.Visible = True
        Me.GYQ.VisibleIndex = 37
        '
        'GDISCAMT
        '
        Me.GDISCAMT.Caption = "Disc. Amt."
        Me.GDISCAMT.DisplayFormat.FormatString = "0.00"
        Me.GDISCAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GDISCAMT.FieldName = "DISCAMT"
        Me.GDISCAMT.Name = "GDISCAMT"
        Me.GDISCAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GDISCAMT.Visible = True
        Me.GDISCAMT.VisibleIndex = 38
        '
        'GSERVCHGS
        '
        Me.GSERVCHGS.Caption = "Serv Chgs."
        Me.GSERVCHGS.DisplayFormat.FormatString = "0.00"
        Me.GSERVCHGS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSERVCHGS.FieldName = "EXTRACHGS"
        Me.GSERVCHGS.Name = "GSERVCHGS"
        Me.GSERVCHGS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GSERVCHGS.Visible = True
        Me.GSERVCHGS.VisibleIndex = 39
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
        Me.GCGSTAMT.VisibleIndex = 40
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
        Me.GSGSTAMT.VisibleIndex = 41
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
        Me.GIGSTAMT.VisibleIndex = 42
        '
        'GTAXES
        '
        Me.GTAXES.Caption = "Taxes"
        Me.GTAXES.DisplayFormat.FormatString = "0.00"
        Me.GTAXES.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTAXES.FieldName = "TAXES"
        Me.GTAXES.Name = "GTAXES"
        Me.GTAXES.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTAXES.Visible = True
        Me.GTAXES.VisibleIndex = 43
        '
        'GTAXNAME
        '
        Me.GTAXNAME.Caption = "Tax Name"
        Me.GTAXNAME.FieldName = "TAXNAME"
        Me.GTAXNAME.Name = "GTAXNAME"
        Me.GTAXNAME.Visible = True
        Me.GTAXNAME.VisibleIndex = 44
        '
        'GST
        '
        Me.GST.Caption = "S.T."
        Me.GST.DisplayFormat.FormatString = "0.00"
        Me.GST.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GST.FieldName = "TAXAMT"
        Me.GST.Name = "GST"
        Me.GST.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GST.Visible = True
        Me.GST.VisibleIndex = 45
        '
        'gOTHERCHGSNAME
        '
        Me.gOTHERCHGSNAME.Caption = "Other Chgs Name"
        Me.gOTHERCHGSNAME.FieldName = "OTHERCHGSNAME"
        Me.gOTHERCHGSNAME.Name = "gOTHERCHGSNAME"
        Me.gOTHERCHGSNAME.Visible = True
        Me.gOTHERCHGSNAME.VisibleIndex = 46
        '
        'GOTHERCHGS
        '
        Me.GOTHERCHGS.Caption = "Other Chgs."
        Me.GOTHERCHGS.FieldName = "OTHERCHGS"
        Me.GOTHERCHGS.Name = "GOTHERCHGS"
        Me.GOTHERCHGS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OTHERCHGS  ", "")})
        Me.GOTHERCHGS.Visible = True
        Me.GOTHERCHGS.VisibleIndex = 47
        '
        'GROUNDOFF
        '
        Me.GROUNDOFF.Caption = "Round Off"
        Me.GROUNDOFF.FieldName = "ROUNDOFF"
        Me.GROUNDOFF.Name = "GROUNDOFF"
        Me.GROUNDOFF.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GROUNDOFF.Visible = True
        Me.GROUNDOFF.VisibleIndex = 48
        '
        'GTOTALSALEAMT
        '
        Me.GTOTALSALEAMT.Caption = "Total Sale Amt."
        Me.GTOTALSALEAMT.FieldName = "TOTALSALEAMT"
        Me.GTOTALSALEAMT.Name = "GTOTALSALEAMT"
        Me.GTOTALSALEAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALSALEAMT.Visible = True
        Me.GTOTALSALEAMT.VisibleIndex = 49
        '
        'gtotalsale
        '
        Me.gtotalsale.Caption = "G. Total"
        Me.gtotalsale.FieldName = "GRANDTOTAL"
        Me.gtotalsale.Name = "gtotalsale"
        Me.gtotalsale.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.gtotalsale.Visible = True
        Me.gtotalsale.VisibleIndex = 50
        Me.gtotalsale.Width = 90
        '
        'GMARKUP
        '
        Me.GMARKUP.Caption = "Markup"
        Me.GMARKUP.DisplayFormat.FormatString = "0.00"
        Me.GMARKUP.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GMARKUP.FieldName = "MARKUP"
        Me.GMARKUP.Name = "GMARKUP"
        Me.GMARKUP.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GMARKUP.Visible = True
        Me.GMARKUP.VisibleIndex = 51
        '
        'GCANCELLED
        '
        Me.GCANCELLED.Caption = "Cancelled"
        Me.GCANCELLED.FieldName = "CANCELLED"
        Me.GCANCELLED.Name = "GCANCELLED"
        Me.GCANCELLED.Visible = True
        Me.GCANCELLED.VisibleIndex = 52
        '
        'GBILLCHECKED
        '
        Me.GBILLCHECKED.Caption = "Bill Checked"
        Me.GBILLCHECKED.FieldName = "BILLCHECKED"
        Me.GBILLCHECKED.Name = "GBILLCHECKED"
        Me.GBILLCHECKED.Visible = True
        Me.GBILLCHECKED.VisibleIndex = 53
        '
        'GDISPUTE
        '
        Me.GDISPUTE.Caption = "Disputed"
        Me.GDISPUTE.FieldName = "DISPUTED"
        Me.GDISPUTE.Name = "GDISPUTE"
        Me.GDISPUTE.Visible = True
        Me.GDISPUTE.VisibleIndex = 54
        '
        'GREMARKS
        '
        Me.GREMARKS.Caption = "Remarks"
        Me.GREMARKS.FieldName = "REMARKS"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.Visible = True
        Me.GREMARKS.VisibleIndex = 55
        '
        'GUSER
        '
        Me.GUSER.Caption = "User Name"
        Me.GUSER.FieldName = "USERNAME"
        Me.GUSER.Name = "GUSER"
        Me.GUSER.Visible = True
        Me.GUSER.VisibleIndex = 56
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
        Me.GIRNNO.VisibleIndex = 58
        '
        'GACKNO
        '
        Me.GACKNO.Caption = "Ack No"
        Me.GACKNO.FieldName = "ACKNO"
        Me.GACKNO.Name = "GACKNO"
        Me.GACKNO.Visible = True
        Me.GACKNO.VisibleIndex = 59
        '
        'GACKDATE
        '
        Me.GACKDATE.Caption = "Ack Date"
        Me.GACKDATE.FieldName = "ACKDATE"
        Me.GACKDATE.Name = "GACKDATE"
        Me.GACKDATE.Visible = True
        Me.GACKDATE.VisibleIndex = 60
        '
        'GQRCODE
        '
        Me.GQRCODE.Caption = "QR Code"
        Me.GQRCODE.FieldName = "QRCODE"
        Me.GQRCODE.Name = "GQRCODE"
        Me.GQRCODE.Visible = True
        Me.GQRCODE.VisibleIndex = 61
        '
        'GTOTAL
        '
        Me.GTOTAL.Caption = "TOTAL"
        Me.GTOTAL.FieldName = "TOTAL"
        Me.GTOTAL.Name = "GTOTAL"
        Me.GTOTAL.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTAL.Visible = True
        Me.GTOTAL.VisibleIndex = 63
        '
        'GPS
        '
        Me.GPS.Caption = "PSF"
        Me.GPS.FieldName = "PSF"
        Me.GPS.Name = "GPS"
        Me.GPS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPS.Visible = True
        Me.GPS.VisibleIndex = 62
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.toolStripSeparator, Me.ExcelExport, Me.PRINTTOOL, Me.TOOLMAIL, Me.TOOLREFRESH, Me.ToolStripSeparator2, Me.TOOLGRIDDETAILS})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1234, 25)
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
        'TOOLGRIDDETAILS
        '
        Me.TOOLGRIDDETAILS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TOOLGRIDDETAILS.Image = CType(resources.GetObject("TOOLGRIDDETAILS.Image"), System.Drawing.Image)
        Me.TOOLGRIDDETAILS.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLGRIDDETAILS.Name = "TOOLGRIDDETAILS"
        Me.TOOLGRIDDETAILS.Size = New System.Drawing.Size(71, 22)
        Me.TOOLGRIDDETAILS.Text = "Grid Details"
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(20, 42)
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
        'PrintDialog1
        '
        Me.PrintDialog1.AllowSelection = True
        Me.PrintDialog1.AllowSomePages = True
        Me.PrintDialog1.ShowHelp = True
        Me.PrintDialog1.UseEXDialog = True
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(71, 22)
        Me.ToolStripButton2.Text = "Grid Details"
        '
        'TOOLREFRESH
        '
        Me.TOOLREFRESH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLREFRESH.Image = Global.HOSPITALITY.My.Resources.Resources.refresh1
        Me.TOOLREFRESH.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLREFRESH.Name = "TOOLREFRESH"
        Me.TOOLREFRESH.Size = New System.Drawing.Size(23, 22)
        Me.TOOLREFRESH.Text = "&Refresh"
        '
        'GGROUPDEPARTURE
        '
        Me.GGROUPDEPARTURE.Caption = "Group Departure"
        Me.GGROUPDEPARTURE.FieldName = "GROUPDEPARTURE"
        Me.GGROUPDEPARTURE.Name = "GGROUPDEPARTURE"
        Me.GGROUPDEPARTURE.Visible = True
        Me.GGROUPDEPARTURE.VisibleIndex = 64
        '
        'AirlineBookingDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 582)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "AirlineBookingDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Airline Booking Details"
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
    Friend WithEvents CMDOK As System.Windows.Forms.Button
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GINITIALS As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gsrno As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREFNO As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gdate As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GAIRNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gaccname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gticket As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gpnr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gairpnr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBOOKEDBY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gtotalpurchase As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gtotalsale As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBILLCHECKED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDISPUTE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExcelExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents GCRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBSP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCOUPON As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcrspnr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCANCELLED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GUSER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TXTTO As System.Windows.Forms.TextBox
    Friend WithEvents TXTFROM As System.Windows.Forms.TextBox
    Friend WithEvents PRINTTOOL As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GRETURN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREFUNDED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFAILED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBASIC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GYQ As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTAXES As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTAXNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURTAXNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURTAX As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMARKUP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURSERVCHGS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURCGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURSGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURIGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSERVCHGS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GIGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURDISCAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURGSTIN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGSTIN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURSTATENAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURSTATECODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTATENAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTATECODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GHSNCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPUROTHERCHGS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDISCAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GpurTDS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURTDSRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gPURADDDISCAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPUROTHERCHGSNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURROUNDOFF As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALPURAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gOTHERCHGSNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOTHERCHGS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GROUNDOFF As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALSALEAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TOOLMAIL As ToolStripButton
    Friend WithEvents Label11 As Label
    Friend WithEvents TXTCOPIES As TextBox
    Friend WithEvents PRINTDOC As Printing.PrintDocument
    Friend WithEvents PRINTDIALOG As PrintDialog
    Friend WithEvents GSOURCE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents PrintDialog1 As PrintDialog
    Friend WithEvents LBLTO As Label
    Friend WithEvents LBLFROM As Label
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents TOOLGRIDDETAILS As ToolStripButton
    Friend WithEvents GIRNNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GACKNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GACKDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GQRCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRETURNDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TOOLREFRESH As ToolStripButton
    Friend WithEvents GGROUPDEPARTURE As DevExpress.XtraGrid.Columns.GridColumn
End Class
