<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DebitNoteDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DebitNoteDetails))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.griddetails = New DevExpress.XtraGrid.GridControl()
        Me.gridDN = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GSRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBILLNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGUESTNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GHOTELNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGSTIN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDISCAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCOMM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTDS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GEXTRACHGS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTAXNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTAXAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GADDTAXNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GADDTAXAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOTHERCHGS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSERVCHGS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GIGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGRANDTOTAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GIRNNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GACKNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GACKDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GQRCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.cmbregister = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdprint = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ExcelExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lbl = New System.Windows.Forms.Label()
        Me.GGSTR1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CHKGSTR1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridDN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.CHKGSTR1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BlendPanel1.Controls.Add(Me.cmdprint)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 1
        '
        'griddetails
        '
        Me.griddetails.Location = New System.Drawing.Point(12, 60)
        Me.griddetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.griddetails.MainView = Me.gridDN
        Me.griddetails.Name = "griddetails"
        Me.griddetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CHKGSTR1})
        Me.griddetails.Size = New System.Drawing.Size(1210, 480)
        Me.griddetails.TabIndex = 327
        Me.griddetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridDN})
        '
        'gridDN
        '
        Me.gridDN.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridDN.Appearance.Row.Options.UseFont = True
        Me.gridDN.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GSRNO, Me.GDATE, Me.GBILLNO, Me.GGUESTNAME, Me.GHOTELNAME, Me.GNAME, Me.GGSTIN, Me.GTOTALAMT, Me.GDISCAMT, Me.GCOMM, Me.GTDS, Me.GEXTRACHGS, Me.GTAXNAME, Me.GTAXAMT, Me.GADDTAXNAME, Me.GADDTAXAMT, Me.GOTHERCHGS, Me.GSERVCHGS, Me.GCGSTAMT, Me.GSGSTAMT, Me.GIGSTAMT, Me.GGRANDTOTAL, Me.GDP, Me.GIRNNO, Me.GACKNO, Me.GACKDATE, Me.GQRCODE, Me.GGSTR1})
        Me.gridDN.GridControl = Me.griddetails
        Me.gridDN.Images = Me.imageList1
        Me.gridDN.Name = "gridDN"
        Me.gridDN.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridDN.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridDN.OptionsBehavior.Editable = False
        Me.gridDN.OptionsView.ColumnAutoWidth = False
        Me.gridDN.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridDN.OptionsView.ShowAutoFilterRow = True
        Me.gridDN.OptionsView.ShowFooter = True
        Me.gridDN.OptionsView.ShowGroupPanel = False
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
        Me.GDATE.FieldName = "GDATE"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.Visible = True
        Me.GDATE.VisibleIndex = 1
        Me.GDATE.Width = 70
        '
        'GBILLNO
        '
        Me.GBILLNO.Caption = "Bill No"
        Me.GBILLNO.FieldName = "GBILLNO"
        Me.GBILLNO.ImageIndex = 1
        Me.GBILLNO.Name = "GBILLNO"
        Me.GBILLNO.Visible = True
        Me.GBILLNO.VisibleIndex = 2
        Me.GBILLNO.Width = 60
        '
        'GGUESTNAME
        '
        Me.GGUESTNAME.Caption = "Guest Name"
        Me.GGUESTNAME.FieldName = "GGUESTNAME"
        Me.GGUESTNAME.Name = "GGUESTNAME"
        Me.GGUESTNAME.Visible = True
        Me.GGUESTNAME.VisibleIndex = 3
        Me.GGUESTNAME.Width = 220
        '
        'GHOTELNAME
        '
        Me.GHOTELNAME.Caption = "Hotel Name"
        Me.GHOTELNAME.FieldName = "GHOTELNAME"
        Me.GHOTELNAME.Name = "GHOTELNAME"
        Me.GHOTELNAME.Visible = True
        Me.GHOTELNAME.VisibleIndex = 4
        Me.GHOTELNAME.Width = 210
        '
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "GNAME"
        Me.GNAME.ImageIndex = 0
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 5
        Me.GNAME.Width = 210
        '
        'GGSTIN
        '
        Me.GGSTIN.Caption = "GSTIN"
        Me.GGSTIN.FieldName = "GSTIN"
        Me.GGSTIN.Name = "GGSTIN"
        Me.GGSTIN.Visible = True
        Me.GGSTIN.VisibleIndex = 6
        Me.GGSTIN.Width = 100
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
        Me.GTOTALAMT.VisibleIndex = 7
        Me.GTOTALAMT.Width = 90
        '
        'GDISCAMT
        '
        Me.GDISCAMT.Caption = "Disc Amt"
        Me.GDISCAMT.DisplayFormat.FormatString = "0.00"
        Me.GDISCAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GDISCAMT.FieldName = "DISCAMT"
        Me.GDISCAMT.Name = "GDISCAMT"
        Me.GDISCAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GDISCAMT.Visible = True
        Me.GDISCAMT.VisibleIndex = 8
        '
        'GCOMM
        '
        Me.GCOMM.Caption = "Comm"
        Me.GCOMM.DisplayFormat.FormatString = "0.00"
        Me.GCOMM.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCOMM.FieldName = "COMMAMT"
        Me.GCOMM.Name = "GCOMM"
        Me.GCOMM.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GCOMM.Visible = True
        Me.GCOMM.VisibleIndex = 9
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
        Me.GTDS.VisibleIndex = 10
        '
        'GEXTRACHGS
        '
        Me.GEXTRACHGS.Caption = "Other Chgs"
        Me.GEXTRACHGS.DisplayFormat.FormatString = "0.00"
        Me.GEXTRACHGS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GEXTRACHGS.FieldName = "EXTRACHGS"
        Me.GEXTRACHGS.Name = "GEXTRACHGS"
        Me.GEXTRACHGS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GEXTRACHGS.Visible = True
        Me.GEXTRACHGS.VisibleIndex = 11
        '
        'GTAXNAME
        '
        Me.GTAXNAME.Caption = "Tax Name"
        Me.GTAXNAME.FieldName = "TAXNAME"
        Me.GTAXNAME.Name = "GTAXNAME"
        Me.GTAXNAME.Visible = True
        Me.GTAXNAME.VisibleIndex = 12
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
        Me.GTAXAMT.VisibleIndex = 13
        '
        'GADDTAXNAME
        '
        Me.GADDTAXNAME.Caption = "Add Tax Name"
        Me.GADDTAXNAME.FieldName = "ADDTAXNAME"
        Me.GADDTAXNAME.Name = "GADDTAXNAME"
        Me.GADDTAXNAME.Visible = True
        Me.GADDTAXNAME.VisibleIndex = 14
        Me.GADDTAXNAME.Width = 100
        '
        'GADDTAXAMT
        '
        Me.GADDTAXAMT.Caption = "Add Tax Amt"
        Me.GADDTAXAMT.DisplayFormat.FormatString = "0.00"
        Me.GADDTAXAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GADDTAXAMT.FieldName = "ADDTAXAMT"
        Me.GADDTAXAMT.Name = "GADDTAXAMT"
        Me.GADDTAXAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GADDTAXAMT.Visible = True
        Me.GADDTAXAMT.VisibleIndex = 15
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
        Me.GOTHERCHGS.VisibleIndex = 16
        '
        'GSERVCHGS
        '
        Me.GSERVCHGS.Caption = "Serv Chgs"
        Me.GSERVCHGS.FieldName = "SERVCHGS"
        Me.GSERVCHGS.Name = "GSERVCHGS"
        Me.GSERVCHGS.Visible = True
        Me.GSERVCHGS.VisibleIndex = 17
        Me.GSERVCHGS.Width = 100
        '
        'GCGSTAMT
        '
        Me.GCGSTAMT.Caption = "CGST Amt."
        Me.GCGSTAMT.FieldName = "CGSTAMT"
        Me.GCGSTAMT.Name = "GCGSTAMT"
        Me.GCGSTAMT.Visible = True
        Me.GCGSTAMT.VisibleIndex = 18
        Me.GCGSTAMT.Width = 100
        '
        'GSGSTAMT
        '
        Me.GSGSTAMT.Caption = "SGST Amt."
        Me.GSGSTAMT.FieldName = "SGSTAMT"
        Me.GSGSTAMT.Name = "GSGSTAMT"
        Me.GSGSTAMT.Visible = True
        Me.GSGSTAMT.VisibleIndex = 19
        Me.GSGSTAMT.Width = 100
        '
        'GIGSTAMT
        '
        Me.GIGSTAMT.Caption = "IGST Amt."
        Me.GIGSTAMT.FieldName = "IGSTAMT"
        Me.GIGSTAMT.Name = "GIGSTAMT"
        Me.GIGSTAMT.Visible = True
        Me.GIGSTAMT.VisibleIndex = 20
        Me.GIGSTAMT.Width = 100
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
        Me.GGRANDTOTAL.VisibleIndex = 21
        Me.GGRANDTOTAL.Width = 85
        '
        'GDP
        '
        Me.GDP.Caption = "DP"
        Me.GDP.DisplayFormat.FormatString = "0.00"
        Me.GDP.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GDP.FieldName = "DP"
        Me.GDP.Name = "GDP"
        Me.GDP.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GDP.Visible = True
        Me.GDP.VisibleIndex = 22
        '
        'GIRNNO
        '
        Me.GIRNNO.Caption = "GIrnno"
        Me.GIRNNO.FieldName = "IRNNO"
        Me.GIRNNO.Name = "GIRNNO"
        Me.GIRNNO.Visible = True
        Me.GIRNNO.VisibleIndex = 23
        '
        'GACKNO
        '
        Me.GACKNO.Caption = "GAckno"
        Me.GACKNO.FieldName = "ACKNO"
        Me.GACKNO.Name = "GACKNO"
        Me.GACKNO.Visible = True
        Me.GACKNO.VisibleIndex = 24
        '
        'GACKDATE
        '
        Me.GACKDATE.Caption = "GAckdate"
        Me.GACKDATE.FieldName = "ACKDATE"
        Me.GACKDATE.Name = "GACKDATE"
        Me.GACKDATE.Visible = True
        Me.GACKDATE.VisibleIndex = 25
        '
        'GQRCODE
        '
        Me.GQRCODE.Caption = "GQrcode"
        Me.GQRCODE.FieldName = "QRCODE"
        Me.GQRCODE.Name = "GQRCODE"
        Me.GQRCODE.Visible = True
        Me.GQRCODE.VisibleIndex = 26
        '
        'imageList1
        '
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList1.TransparentColor = System.Drawing.Color.Magenta
        Me.imageList1.Images.SetKeyName(0, "")
        Me.imageList1.Images.SetKeyName(1, "")
        '
        'CMDOK
        '
        Me.CMDOK.BackColor = System.Drawing.Color.Transparent
        Me.CMDOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDOK.FlatAppearance.BorderSize = 0
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.Black
        Me.CMDOK.Location = New System.Drawing.Point(534, 548)
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
        Me.cmdcancel.Location = New System.Drawing.Point(620, 548)
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
        Me.cmbregister.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbregister.FormattingEnabled = True
        Me.cmbregister.Items.AddRange(New Object() {""})
        Me.cmbregister.Location = New System.Drawing.Point(743, 34)
        Me.cmbregister.Name = "cmbregister"
        Me.cmbregister.Size = New System.Drawing.Size(216, 23)
        Me.cmbregister.TabIndex = 314
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(687, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 15)
        Me.Label1.TabIndex = 321
        Me.Label1.Text = "Register"
        '
        'cmdprint
        '
        Me.cmdprint.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdprint.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdprint.Location = New System.Drawing.Point(23, 395)
        Me.cmdprint.Name = "cmdprint"
        Me.cmdprint.Size = New System.Drawing.Size(63, 24)
        Me.cmdprint.TabIndex = 320
        Me.cmdprint.Text = "&Print"
        Me.cmdprint.UseVisualStyleBackColor = True
        Me.cmdprint.Visible = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.toolStripSeparator, Me.ExcelExport, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1234, 25)
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
        'GGSTR1
        '
        Me.GGSTR1.Caption = "GSTR1"
        Me.GGSTR1.ColumnEdit = Me.CHKGSTR1
        Me.GGSTR1.FieldName = "GSTR1"
        Me.GGSTR1.Name = "GGSTR1"
        Me.GGSTR1.Visible = True
        Me.GGSTR1.VisibleIndex = 27
        '
        'CHKGSTR1
        '
        Me.CHKGSTR1.AutoHeight = False
        Me.CHKGSTR1.Name = "CHKGSTR1"
        Me.CHKGSTR1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'DebitNoteDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "DebitNoteDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Debit Note Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridDN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.CHKGSTR1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMDOK As System.Windows.Forms.Button
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Friend WithEvents cmbregister As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdprint As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents griddetails As DevExpress.XtraGrid.GridControl
    Friend WithEvents gridDN As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GSRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBILLNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGUESTNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GHOTELNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALAMT As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents imageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ExcelExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GDISCAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCOMM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTDS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GEXTRACHGS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTAXNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTAXAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOTHERCHGS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGRANDTOTAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GADDTAXNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GADDTAXAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGSTIN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSERVCHGS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GIGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GIRNNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GACKNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GACKDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GQRCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGSTR1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CHKGSTR1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
End Class
