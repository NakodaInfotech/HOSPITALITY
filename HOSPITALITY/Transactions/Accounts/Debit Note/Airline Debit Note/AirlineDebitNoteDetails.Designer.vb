<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AirlineDebitNoteDetails
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
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.griddetails = New DevExpress.XtraGrid.GridControl()
        Me.gridDN = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GSRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBILLNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPNR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAIRPNR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCRSPNR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGUESTNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GHOTELNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSTATECODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSTATENAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGSTIN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURSTATECODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURGSTIN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GHSNCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSERVCHGS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCGSTPER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSGSTPER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GIGSTPER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GIGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDISCAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTDS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GADDDISC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTAXNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTAXAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOTHERCHGS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCANCELAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGRANDTOTAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.cmbregister = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ExcelExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lbl = New System.Windows.Forms.Label()
        Me.GIRNNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GACKNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GACKDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GQRCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridDN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.griddetails)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Controls.Add(Me.cmbregister)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1084, 582)
        Me.BlendPanel1.TabIndex = 4
        '
        'griddetails
        '
        Me.griddetails.Location = New System.Drawing.Point(12, 59)
        Me.griddetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.griddetails.MainView = Me.gridDN
        Me.griddetails.Name = "griddetails"
        Me.griddetails.Size = New System.Drawing.Size(1060, 472)
        Me.griddetails.TabIndex = 326
        Me.griddetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridDN})
        '
        'gridDN
        '
        Me.gridDN.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridDN.Appearance.Row.Options.UseFont = True
        Me.gridDN.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GSRNO, Me.GDATE, Me.GBILLNO, Me.GPNR, Me.GAIRPNR, Me.GCRSPNR, Me.GGUESTNAME, Me.GHOTELNAME, Me.GNAME, Me.GSTATECODE, Me.GSTATENAME, Me.GGSTIN, Me.GPURNAME, Me.GPURSTATECODE, Me.GPURGSTIN, Me.GHSNCODE, Me.GSERVCHGS, Me.GCGSTPER, Me.GCGSTAMT, Me.GSGSTPER, Me.GSGSTAMT, Me.GIGSTPER, Me.GIGSTAMT, Me.GTOTALAMT, Me.GDISCAMT, Me.GTDS, Me.GADDDISC, Me.GTAXNAME, Me.GTAXAMT, Me.GOTHERCHGS, Me.GCANCELAMT, Me.GGRANDTOTAL, Me.GIRNNO, Me.GACKNO, Me.GACKDATE, Me.GQRCODE})
        Me.gridDN.GridControl = Me.griddetails
        Me.gridDN.Name = "gridDN"
        Me.gridDN.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridDN.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridDN.OptionsBehavior.Editable = False
        Me.gridDN.OptionsView.ColumnAutoWidth = False
        Me.gridDN.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridDN.OptionsView.ShowAutoFilterRow = True
        Me.gridDN.OptionsView.ShowFooter = True
        '
        'GSRNO
        '
        Me.GSRNO.Caption = "Sr. No"
        Me.GSRNO.FieldName = "GSRNO"
        Me.GSRNO.Name = "GSRNO"
        Me.GSRNO.Visible = True
        Me.GSRNO.VisibleIndex = 0
        Me.GSRNO.Width = 50
        '
        'GDATE
        '
        Me.GDATE.Caption = "Date"
        Me.GDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDATE.FieldName = "DATE"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.Visible = True
        Me.GDATE.VisibleIndex = 1
        Me.GDATE.Width = 70
        '
        'GBILLNO
        '
        Me.GBILLNO.Caption = "Bill No"
        Me.GBILLNO.FieldName = "BILLNO"
        Me.GBILLNO.ImageIndex = 1
        Me.GBILLNO.Name = "GBILLNO"
        Me.GBILLNO.Visible = True
        Me.GBILLNO.VisibleIndex = 2
        Me.GBILLNO.Width = 60
        '
        'GPNR
        '
        Me.GPNR.Caption = "PNR No"
        Me.GPNR.FieldName = "PNR"
        Me.GPNR.Name = "GPNR"
        Me.GPNR.Visible = True
        Me.GPNR.VisibleIndex = 3
        '
        'GAIRPNR
        '
        Me.GAIRPNR.Caption = "Air PNR"
        Me.GAIRPNR.FieldName = "AIRPNR"
        Me.GAIRPNR.Name = "GAIRPNR"
        Me.GAIRPNR.Visible = True
        Me.GAIRPNR.VisibleIndex = 4
        '
        'GCRSPNR
        '
        Me.GCRSPNR.Caption = "CRS PNR"
        Me.GCRSPNR.FieldName = "CRS PNR"
        Me.GCRSPNR.Name = "GCRSPNR"
        Me.GCRSPNR.Visible = True
        Me.GCRSPNR.VisibleIndex = 5
        '
        'GGUESTNAME
        '
        Me.GGUESTNAME.Caption = "Customer"
        Me.GGUESTNAME.FieldName = "GGUESTNAME"
        Me.GGUESTNAME.Name = "GGUESTNAME"
        Me.GGUESTNAME.Width = 220
        '
        'GHOTELNAME
        '
        Me.GHOTELNAME.Caption = "Airline Name"
        Me.GHOTELNAME.FieldName = "AIRLINE"
        Me.GHOTELNAME.Name = "GHOTELNAME"
        Me.GHOTELNAME.Visible = True
        Me.GHOTELNAME.VisibleIndex = 6
        Me.GHOTELNAME.Width = 210
        '
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.ImageIndex = 0
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 7
        Me.GNAME.Width = 210
        '
        'GSTATECODE
        '
        Me.GSTATECODE.Caption = "State Code"
        Me.GSTATECODE.FieldName = "STATECODE"
        Me.GSTATECODE.Name = "GSTATECODE"
        Me.GSTATECODE.Visible = True
        Me.GSTATECODE.VisibleIndex = 8
        '
        'GSTATENAME
        '
        Me.GSTATENAME.Caption = "State Name"
        Me.GSTATENAME.Name = "GSTATENAME"
        Me.GSTATENAME.Visible = True
        Me.GSTATENAME.VisibleIndex = 9
        Me.GSTATENAME.Width = 80
        '
        'GGSTIN
        '
        Me.GGSTIN.Caption = "GSTIN"
        Me.GGSTIN.FieldName = "GSTIN"
        Me.GGSTIN.Name = "GGSTIN"
        Me.GGSTIN.Visible = True
        Me.GGSTIN.VisibleIndex = 10
        Me.GGSTIN.Width = 80
        '
        'GPURNAME
        '
        Me.GPURNAME.Caption = "Pur. Name"
        Me.GPURNAME.FieldName = "PURNAME"
        Me.GPURNAME.Name = "GPURNAME"
        Me.GPURNAME.Visible = True
        Me.GPURNAME.VisibleIndex = 11
        Me.GPURNAME.Width = 100
        '
        'GPURSTATECODE
        '
        Me.GPURSTATECODE.Caption = "Pur. State Code"
        Me.GPURSTATECODE.FieldName = "PURSTATECODE"
        Me.GPURSTATECODE.Name = "GPURSTATECODE"
        Me.GPURSTATECODE.Visible = True
        Me.GPURSTATECODE.VisibleIndex = 12
        '
        'GPURGSTIN
        '
        Me.GPURGSTIN.Caption = "Pur. GSTIN"
        Me.GPURGSTIN.FieldName = "PURGSTIN"
        Me.GPURGSTIN.Name = "GPURGSTIN"
        Me.GPURGSTIN.Visible = True
        Me.GPURGSTIN.VisibleIndex = 13
        '
        'GHSNCODE
        '
        Me.GHSNCODE.Caption = "HSN Code"
        Me.GHSNCODE.FieldName = "HSNCODE"
        Me.GHSNCODE.Name = "GHSNCODE"
        Me.GHSNCODE.Visible = True
        Me.GHSNCODE.VisibleIndex = 14
        '
        'GSERVCHGS
        '
        Me.GSERVCHGS.Caption = "Serv Chgs."
        Me.GSERVCHGS.FieldName = "SERVCHGS"
        Me.GSERVCHGS.Name = "GSERVCHGS"
        Me.GSERVCHGS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GSERVCHGS.Visible = True
        Me.GSERVCHGS.VisibleIndex = 15
        '
        'GCGSTPER
        '
        Me.GCGSTPER.Caption = "CGST %"
        Me.GCGSTPER.FieldName = "CGSTPER"
        Me.GCGSTPER.Name = "GCGSTPER"
        Me.GCGSTPER.Visible = True
        Me.GCGSTPER.VisibleIndex = 16
        '
        'GCGSTAMT
        '
        Me.GCGSTAMT.Caption = "CGST Amt."
        Me.GCGSTAMT.DisplayFormat.FormatString = "0.00"
        Me.GCGSTAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCGSTAMT.FieldName = "CGSTAMT"
        Me.GCGSTAMT.Name = "GCGSTAMT"
        Me.GCGSTAMT.Visible = True
        Me.GCGSTAMT.VisibleIndex = 17
        '
        'GSGSTPER
        '
        Me.GSGSTPER.Caption = "SGST %"
        Me.GSGSTPER.FieldName = "SGSTPER"
        Me.GSGSTPER.Name = "GSGSTPER"
        Me.GSGSTPER.Visible = True
        Me.GSGSTPER.VisibleIndex = 18
        '
        'GSGSTAMT
        '
        Me.GSGSTAMT.Caption = "SGST Amt."
        Me.GSGSTAMT.DisplayFormat.FormatString = "0.00"
        Me.GSGSTAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSGSTAMT.FieldName = "SGSTAMT"
        Me.GSGSTAMT.Name = "GSGSTAMT"
        Me.GSGSTAMT.Visible = True
        Me.GSGSTAMT.VisibleIndex = 19
        '
        'GIGSTPER
        '
        Me.GIGSTPER.Caption = "IGST %"
        Me.GIGSTPER.FieldName = "IGSTPER"
        Me.GIGSTPER.Name = "GIGSTPER"
        Me.GIGSTPER.Visible = True
        Me.GIGSTPER.VisibleIndex = 20
        '
        'GIGSTAMT
        '
        Me.GIGSTAMT.Caption = "IGST Amt."
        Me.GIGSTAMT.DisplayFormat.FormatString = "0.00"
        Me.GIGSTAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GIGSTAMT.FieldName = "IGSTAMT"
        Me.GIGSTAMT.Name = "GIGSTAMT"
        Me.GIGSTAMT.Visible = True
        Me.GIGSTAMT.VisibleIndex = 21
        '
        'GTOTALAMT
        '
        Me.GTOTALAMT.Caption = "Total Amt"
        Me.GTOTALAMT.DisplayFormat.FormatString = "0.00"
        Me.GTOTALAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALAMT.FieldName = "TOTALAMT"
        Me.GTOTALAMT.Name = "GTOTALAMT"
        Me.GTOTALAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALAMT.Visible = True
        Me.GTOTALAMT.VisibleIndex = 22
        Me.GTOTALAMT.Width = 90
        '
        'GDISCAMT
        '
        Me.GDISCAMT.Caption = "Comm"
        Me.GDISCAMT.DisplayFormat.FormatString = "0.00"
        Me.GDISCAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GDISCAMT.FieldName = "DISCAMT"
        Me.GDISCAMT.Name = "GDISCAMT"
        Me.GDISCAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GDISCAMT.Visible = True
        Me.GDISCAMT.VisibleIndex = 23
        '
        'GTDS
        '
        Me.GTDS.Caption = "TDS"
        Me.GTDS.DisplayFormat.FormatString = "0.00"
        Me.GTDS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTDS.FieldName = "TDS"
        Me.GTDS.Name = "GTDS"
        Me.GTDS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTDS.Visible = True
        Me.GTDS.VisibleIndex = 24
        '
        'GADDDISC
        '
        Me.GADDDISC.Caption = "Add Disc Amt"
        Me.GADDDISC.DisplayFormat.FormatString = "0.00"
        Me.GADDDISC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GADDDISC.FieldName = "ADDDISCAMT"
        Me.GADDDISC.Name = "GADDDISC"
        Me.GADDDISC.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GADDDISC.Visible = True
        Me.GADDDISC.VisibleIndex = 25
        '
        'GTAXNAME
        '
        Me.GTAXNAME.Caption = "Tax Name"
        Me.GTAXNAME.FieldName = "TAXNAME"
        Me.GTAXNAME.Name = "GTAXNAME"
        Me.GTAXNAME.Visible = True
        Me.GTAXNAME.VisibleIndex = 26
        Me.GTAXNAME.Width = 100
        '
        'GTAXAMT
        '
        Me.GTAXAMT.Caption = "Tax Amt"
        Me.GTAXAMT.DisplayFormat.FormatString = "0.00"
        Me.GTAXAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTAXAMT.FieldName = "TAXAMT"
        Me.GTAXAMT.Name = "GTAXAMT"
        Me.GTAXAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTAXAMT.Visible = True
        Me.GTAXAMT.VisibleIndex = 27
        '
        'GOTHERCHGS
        '
        Me.GOTHERCHGS.Caption = "Other Chgs"
        Me.GOTHERCHGS.DisplayFormat.FormatString = "0.00"
        Me.GOTHERCHGS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GOTHERCHGS.FieldName = "OTHERCHGS"
        Me.GOTHERCHGS.Name = "GOTHERCHGS"
        Me.GOTHERCHGS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GOTHERCHGS.Visible = True
        Me.GOTHERCHGS.VisibleIndex = 28
        '
        'GCANCELAMT
        '
        Me.GCANCELAMT.Caption = "Calncellation Amt"
        Me.GCANCELAMT.DisplayFormat.FormatString = "0.00"
        Me.GCANCELAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCANCELAMT.FieldName = "CANCELAMT"
        Me.GCANCELAMT.Name = "GCANCELAMT"
        Me.GCANCELAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GCANCELAMT.Visible = True
        Me.GCANCELAMT.VisibleIndex = 29
        Me.GCANCELAMT.Width = 100
        '
        'GGRANDTOTAL
        '
        Me.GGRANDTOTAL.Caption = "Grand Total"
        Me.GGRANDTOTAL.DisplayFormat.FormatString = "0.00"
        Me.GGRANDTOTAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GGRANDTOTAL.FieldName = "GRANDTOTAL"
        Me.GGRANDTOTAL.Name = "GGRANDTOTAL"
        Me.GGRANDTOTAL.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GGRANDTOTAL.Visible = True
        Me.GGRANDTOTAL.VisibleIndex = 30
        Me.GGRANDTOTAL.Width = 85
        '
        'CMDOK
        '
        Me.CMDOK.BackColor = System.Drawing.Color.Transparent
        Me.CMDOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDOK.FlatAppearance.BorderSize = 0
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.Black
        Me.CMDOK.Location = New System.Drawing.Point(459, 542)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(80, 28)
        Me.CMDOK.TabIndex = 325
        Me.CMDOK.Text = "&Edit"
        Me.CMDOK.UseVisualStyleBackColor = False
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.Color.Transparent
        Me.cmdcancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdcancel.FlatAppearance.BorderSize = 0
        Me.cmdcancel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.Black
        Me.cmdcancel.Location = New System.Drawing.Point(545, 542)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(80, 28)
        Me.cmdcancel.TabIndex = 324
        Me.cmdcancel.Text = "E&xit"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'cmbregister
        '
        Me.cmbregister.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbregister.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbregister.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbregister.FormattingEnabled = True
        Me.cmbregister.Items.AddRange(New Object() {""})
        Me.cmbregister.Location = New System.Drawing.Point(734, 34)
        Me.cmbregister.Name = "cmbregister"
        Me.cmbregister.Size = New System.Drawing.Size(216, 22)
        Me.cmbregister.TabIndex = 314
        Me.cmbregister.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(678, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 14)
        Me.Label1.TabIndex = 321
        Me.Label1.Text = "Register"
        Me.Label1.Visible = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.toolStripSeparator, Me.ExcelExport, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1084, 25)
        Me.ToolStrip1.TabIndex = 318
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
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
        Me.lbl.Location = New System.Drawing.Point(20, 41)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(169, 14)
        Me.lbl.TabIndex = 319
        Me.lbl.Text = "Select a Debit Note to Change"
        '
        'GIRNNO
        '
        Me.GIRNNO.Caption = "Irnno"
        Me.GIRNNO.FieldName = "IRNNO"
        Me.GIRNNO.Name = "GIRNNO"
        Me.GIRNNO.Visible = True
        Me.GIRNNO.VisibleIndex = 31
        '
        'GACKNO
        '
        Me.GACKNO.Caption = "Ackno"
        Me.GACKNO.FieldName = "ACKNO"
        Me.GACKNO.Name = "GACKNO"
        Me.GACKNO.Visible = True
        Me.GACKNO.VisibleIndex = 32
        '
        'GACKDATE
        '
        Me.GACKDATE.Caption = "Ackdate"
        Me.GACKDATE.FieldName = "ACKDATE"
        Me.GACKDATE.Name = "GACKDATE"
        Me.GACKDATE.Visible = True
        Me.GACKDATE.VisibleIndex = 33
        '
        'GQRCODE
        '
        Me.GQRCODE.Caption = "Qrcode"
        Me.GQRCODE.FieldName = "QRCODE"
        Me.GQRCODE.Name = "GQRCODE"
        Me.GQRCODE.Visible = True
        Me.GQRCODE.VisibleIndex = 34
        '
        'AirlineDebitNoteDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1084, 582)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "AirlineDebitNoteDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Airline Debit Note Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridDN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents griddetails As DevExpress.XtraGrid.GridControl
    Friend WithEvents gridDN As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GSRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBILLNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPNR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAIRPNR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCRSPNR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGUESTNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GHOTELNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMDOK As System.Windows.Forms.Button
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Friend WithEvents cmbregister As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExcelExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents GDISCAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTDS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GADDDISC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTAXNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTAXAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOTHERCHGS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCANCELAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGRANDTOTAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTATECODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTATENAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGSTIN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GHSNCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCGSTPER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSGSTPER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GIGSTPER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GIGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURSTATECODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURGSTIN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSERVCHGS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GIRNNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GACKNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GACKDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GQRCODE As DevExpress.XtraGrid.Columns.GridColumn
End Class
