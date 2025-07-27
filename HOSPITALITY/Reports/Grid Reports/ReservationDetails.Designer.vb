<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReservationDetails
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
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ExcelExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GBOOKINGNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBOOKINGDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGUESTNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GHOTELNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSECTORS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSALENAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHECKIN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHECKOUT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREFNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBOOKEDBY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURBAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSALEAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBALANCE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGROSSSALE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGROSSAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGROSS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGROUPNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALPAX = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALROOMS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNIGHTS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALNIGHTS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBILL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBOOKTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGROUPOFHOTELS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCMPNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCMPGST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDISPLAYNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURDISPLAYNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.lbl = New System.Windows.Forms.Label()
        Me.GPACKAGETYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BlendPanel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.Label10)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.Label8)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.Label7)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1284, 582)
        Me.BlendPanel1.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(512, 34)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 14)
        Me.Label9.TabIndex = 520
        Me.Label9.Text = "Checked Out"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Orange
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Location = New System.Drawing.Point(493, 33)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(18, 16)
        Me.Label10.TabIndex = 519
        Me.Label10.Text = "   "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(219, 34)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(122, 14)
        Me.Label6.TabIndex = 518
        Me.Label6.Text = "5 Days befor Check In"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.LightGreen
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Location = New System.Drawing.Point(200, 33)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(18, 16)
        Me.Label8.TabIndex = 517
        Me.Label8.Text = "   "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(820, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(135, 14)
        Me.Label3.TabIndex = 516
        Me.Label3.Text = "1 Month after Check Out"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Plum
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Location = New System.Drawing.Point(801, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(18, 16)
        Me.Label5.TabIndex = 515
        Me.Label5.Text = "   "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(646, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 14)
        Me.Label1.TabIndex = 514
        Me.Label1.Text = "1 Week after Check Out"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.MistyRose
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Location = New System.Drawing.Point(627, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(18, 16)
        Me.Label2.TabIndex = 513
        Me.Label2.Text = "   "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(393, 34)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 14)
        Me.Label7.TabIndex = 512
        Me.Label7.Text = "Checked In"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Location = New System.Drawing.Point(374, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(18, 16)
        Me.Label4.TabIndex = 511
        Me.Label4.Text = "   "
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExcelExport, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1284, 25)
        Me.ToolStrip1.TabIndex = 495
        Me.ToolStrip1.Text = "v"
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(13, 54)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1258, 479)
        Me.gridbilldetails.TabIndex = 494
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GBOOKINGNO, Me.GBOOKINGDATE, Me.GGUESTNAME, Me.GHOTELNAME, Me.GSECTORS, Me.GSALENAME, Me.GPURNAME, Me.GCHECKIN, Me.GCHECKOUT, Me.GREFNO, Me.GBOOKEDBY, Me.GPURAMT, Me.GPURBAL, Me.GSALEAMT, Me.GBALANCE, Me.GGROSSSALE, Me.GGROSSAMT, Me.GGROSS, Me.GST, Me.GGROUPNAME, Me.GTOTALPAX, Me.GTOTALROOMS, Me.GNIGHTS, Me.GTOTALNIGHTS, Me.GBILL, Me.GTYPE, Me.GBOOKTYPE, Me.GGROUPOFHOTELS, Me.GCMPNAME, Me.GCMPGST, Me.GDISPLAYNAME, Me.GPURDISPLAYNAME, Me.GPACKAGETYPE})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        Me.gridbill.OptionsView.ShowGroupPanel = False
        '
        'GBOOKINGNO
        '
        Me.GBOOKINGNO.Caption = "Booking No"
        Me.GBOOKINGNO.FieldName = "BOOKINGNO"
        Me.GBOOKINGNO.Name = "GBOOKINGNO"
        Me.GBOOKINGNO.Visible = True
        Me.GBOOKINGNO.VisibleIndex = 0
        '
        'GBOOKINGDATE
        '
        Me.GBOOKINGDATE.Caption = "Date"
        Me.GBOOKINGDATE.FieldName = "DATE"
        Me.GBOOKINGDATE.Name = "GBOOKINGDATE"
        Me.GBOOKINGDATE.Visible = True
        Me.GBOOKINGDATE.VisibleIndex = 1
        '
        'GGUESTNAME
        '
        Me.GGUESTNAME.Caption = "Guest Name"
        Me.GGUESTNAME.FieldName = "GUESTNAME"
        Me.GGUESTNAME.ImageIndex = 0
        Me.GGUESTNAME.Name = "GGUESTNAME"
        Me.GGUESTNAME.Visible = True
        Me.GGUESTNAME.VisibleIndex = 2
        Me.GGUESTNAME.Width = 160
        '
        'GHOTELNAME
        '
        Me.GHOTELNAME.Caption = "Hotel / Airline / Train Name"
        Me.GHOTELNAME.FieldName = "HOTELNAME"
        Me.GHOTELNAME.ImageIndex = 1
        Me.GHOTELNAME.Name = "GHOTELNAME"
        Me.GHOTELNAME.Visible = True
        Me.GHOTELNAME.VisibleIndex = 3
        Me.GHOTELNAME.Width = 160
        '
        'GSECTORS
        '
        Me.GSECTORS.Caption = "Sector"
        Me.GSECTORS.FieldName = "SECTOR"
        Me.GSECTORS.Name = "GSECTORS"
        Me.GSECTORS.Visible = True
        Me.GSECTORS.VisibleIndex = 4
        Me.GSECTORS.Width = 120
        '
        'GSALENAME
        '
        Me.GSALENAME.Caption = "Sale A/C Name"
        Me.GSALENAME.FieldName = "SALELEDGER"
        Me.GSALENAME.Name = "GSALENAME"
        Me.GSALENAME.Visible = True
        Me.GSALENAME.VisibleIndex = 5
        Me.GSALENAME.Width = 160
        '
        'GPURNAME
        '
        Me.GPURNAME.Caption = "Pur A/C Name"
        Me.GPURNAME.FieldName = "PURLEDGER"
        Me.GPURNAME.Name = "GPURNAME"
        Me.GPURNAME.Visible = True
        Me.GPURNAME.VisibleIndex = 6
        Me.GPURNAME.Width = 160
        '
        'GCHECKIN
        '
        Me.GCHECKIN.Caption = "Check In"
        Me.GCHECKIN.FieldName = "ARRIVAL"
        Me.GCHECKIN.Name = "GCHECKIN"
        Me.GCHECKIN.Visible = True
        Me.GCHECKIN.VisibleIndex = 7
        '
        'GCHECKOUT
        '
        Me.GCHECKOUT.Caption = "Check Out"
        Me.GCHECKOUT.FieldName = "DEPARTURE"
        Me.GCHECKOUT.Name = "GCHECKOUT"
        Me.GCHECKOUT.Visible = True
        Me.GCHECKOUT.VisibleIndex = 8
        '
        'GREFNO
        '
        Me.GREFNO.Caption = "Ref No."
        Me.GREFNO.FieldName = "REFNO"
        Me.GREFNO.Name = "GREFNO"
        Me.GREFNO.Visible = True
        Me.GREFNO.VisibleIndex = 9
        '
        'GBOOKEDBY
        '
        Me.GBOOKEDBY.Caption = "Booked By"
        Me.GBOOKEDBY.FieldName = "BOOKEDBY"
        Me.GBOOKEDBY.Name = "GBOOKEDBY"
        Me.GBOOKEDBY.Visible = True
        Me.GBOOKEDBY.VisibleIndex = 10
        '
        'GPURAMT
        '
        Me.GPURAMT.Caption = "Pur Amt"
        Me.GPURAMT.DisplayFormat.FormatString = "0.00"
        Me.GPURAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPURAMT.FieldName = "PURAMT"
        Me.GPURAMT.Name = "GPURAMT"
        Me.GPURAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPURAMT.Visible = True
        Me.GPURAMT.VisibleIndex = 11
        Me.GPURAMT.Width = 85
        '
        'GPURBAL
        '
        Me.GPURBAL.Caption = "Pur Bal"
        Me.GPURBAL.DisplayFormat.FormatString = "0.00"
        Me.GPURBAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPURBAL.FieldName = "PURBAL"
        Me.GPURBAL.Name = "GPURBAL"
        Me.GPURBAL.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPURBAL.Visible = True
        Me.GPURBAL.VisibleIndex = 12
        Me.GPURBAL.Width = 85
        '
        'GSALEAMT
        '
        Me.GSALEAMT.Caption = "Sale Amt"
        Me.GSALEAMT.DisplayFormat.FormatString = "0.00"
        Me.GSALEAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSALEAMT.FieldName = "SALEAMT"
        Me.GSALEAMT.Name = "GSALEAMT"
        Me.GSALEAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GSALEAMT.Visible = True
        Me.GSALEAMT.VisibleIndex = 13
        Me.GSALEAMT.Width = 85
        '
        'GBALANCE
        '
        Me.GBALANCE.Caption = "Balance"
        Me.GBALANCE.DisplayFormat.FormatString = "0.00"
        Me.GBALANCE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GBALANCE.FieldName = "SALEBAL"
        Me.GBALANCE.Name = "GBALANCE"
        Me.GBALANCE.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GBALANCE.Visible = True
        Me.GBALANCE.VisibleIndex = 14
        Me.GBALANCE.Width = 85
        '
        'GGROSSSALE
        '
        Me.GGROSSSALE.Caption = "Gross Sale"
        Me.GGROSSSALE.DisplayFormat.FormatString = "0.00"
        Me.GGROSSSALE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GGROSSSALE.FieldName = "GROSSSALE"
        Me.GGROSSSALE.Name = "GGROSSSALE"
        Me.GGROSSSALE.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GGROSSSALE.Visible = True
        Me.GGROSSSALE.VisibleIndex = 15
        '
        'GGROSSAMT
        '
        Me.GGROSSAMT.Caption = "Gross"
        Me.GGROSSAMT.DisplayFormat.FormatString = "0.00"
        Me.GGROSSAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GGROSSAMT.FieldName = "GROSSAMT"
        Me.GGROSSAMT.Name = "GGROSSAMT"
        Me.GGROSSAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GGROSSAMT.Visible = True
        Me.GGROSSAMT.VisibleIndex = 16
        Me.GGROSSAMT.Width = 85
        '
        'GGROSS
        '
        Me.GGROSS.Caption = "Gross %"
        Me.GGROSS.DisplayFormat.FormatString = "0.00"
        Me.GGROSS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GGROSS.FieldName = "GROSSPERCENT"
        Me.GGROSS.Name = "GGROSS"
        Me.GGROSS.Visible = True
        Me.GGROSS.VisibleIndex = 17
        '
        'GST
        '
        Me.GST.Caption = "Service Tax"
        Me.GST.DisplayFormat.FormatString = "0.00"
        Me.GST.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GST.FieldName = "TAX"
        Me.GST.Name = "GST"
        Me.GST.Visible = True
        Me.GST.VisibleIndex = 18
        Me.GST.Width = 80
        '
        'GGROUPNAME
        '
        Me.GGROUPNAME.Caption = "Group Name"
        Me.GGROUPNAME.FieldName = "GROUPNAME"
        Me.GGROUPNAME.Name = "GGROUPNAME"
        Me.GGROUPNAME.Visible = True
        Me.GGROUPNAME.VisibleIndex = 19
        Me.GGROUPNAME.Width = 100
        '
        'GTOTALPAX
        '
        Me.GTOTALPAX.Caption = "Pax"
        Me.GTOTALPAX.DisplayFormat.FormatString = "0"
        Me.GTOTALPAX.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALPAX.FieldName = "TOTALPAX"
        Me.GTOTALPAX.Name = "GTOTALPAX"
        Me.GTOTALPAX.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALPAX.Visible = True
        Me.GTOTALPAX.VisibleIndex = 20
        '
        'GTOTALROOMS
        '
        Me.GTOTALROOMS.Caption = "Rooms"
        Me.GTOTALROOMS.DisplayFormat.FormatString = "0"
        Me.GTOTALROOMS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALROOMS.FieldName = "ROOMS"
        Me.GTOTALROOMS.Name = "GTOTALROOMS"
        Me.GTOTALROOMS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALROOMS.Visible = True
        Me.GTOTALROOMS.VisibleIndex = 21
        '
        'GNIGHTS
        '
        Me.GNIGHTS.Caption = "Nights"
        Me.GNIGHTS.DisplayFormat.FormatString = "0"
        Me.GNIGHTS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GNIGHTS.FieldName = "NIGHTS"
        Me.GNIGHTS.Name = "GNIGHTS"
        Me.GNIGHTS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GNIGHTS.Visible = True
        Me.GNIGHTS.VisibleIndex = 22
        '
        'GTOTALNIGHTS
        '
        Me.GTOTALNIGHTS.Caption = "Total Nights"
        Me.GTOTALNIGHTS.DisplayFormat.FormatString = "0"
        Me.GTOTALNIGHTS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALNIGHTS.FieldName = "TOTALNIGHTS"
        Me.GTOTALNIGHTS.Name = "GTOTALNIGHTS"
        Me.GTOTALNIGHTS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALNIGHTS.Visible = True
        Me.GTOTALNIGHTS.VisibleIndex = 23
        '
        'GBILL
        '
        Me.GBILL.Caption = "BILL"
        Me.GBILL.FieldName = "BILL"
        Me.GBILL.Name = "GBILL"
        '
        'GTYPE
        '
        Me.GTYPE.Caption = "TYPE"
        Me.GTYPE.FieldName = "TYPE"
        Me.GTYPE.Name = "GTYPE"
        '
        'GBOOKTYPE
        '
        Me.GBOOKTYPE.Caption = "BOOKTYPE"
        Me.GBOOKTYPE.FieldName = "BOOKTYPE"
        Me.GBOOKTYPE.Name = "GBOOKTYPE"
        '
        'GGROUPOFHOTELS
        '
        Me.GGROUPOFHOTELS.Caption = "Group Of Hotels"
        Me.GGROUPOFHOTELS.FieldName = "GROUPOFHOTELS"
        Me.GGROUPOFHOTELS.Name = "GGROUPOFHOTELS"
        Me.GGROUPOFHOTELS.Visible = True
        Me.GGROUPOFHOTELS.VisibleIndex = 24
        '
        'GCMPNAME
        '
        Me.GCMPNAME.Caption = "Company Name"
        Me.GCMPNAME.FieldName = "CMPNAME"
        Me.GCMPNAME.Name = "GCMPNAME"
        Me.GCMPNAME.Visible = True
        Me.GCMPNAME.VisibleIndex = 25
        Me.GCMPNAME.Width = 250
        '
        'GCMPGST
        '
        Me.GCMPGST.Caption = "Company GST"
        Me.GCMPGST.FieldName = "CMPGST"
        Me.GCMPGST.Name = "GCMPGST"
        Me.GCMPGST.Visible = True
        Me.GCMPGST.VisibleIndex = 26
        Me.GCMPGST.Width = 120
        '
        'GDISPLAYNAME
        '
        Me.GDISPLAYNAME.Caption = "Guest Display Name"
        Me.GDISPLAYNAME.FieldName = "GUESTDISPLAYNAME"
        Me.GDISPLAYNAME.Name = "GDISPLAYNAME"
        Me.GDISPLAYNAME.Visible = True
        Me.GDISPLAYNAME.VisibleIndex = 27
        Me.GDISPLAYNAME.Width = 150
        '
        'GPURDISPLAYNAME
        '
        Me.GPURDISPLAYNAME.Caption = "Pur Display Name"
        Me.GPURDISPLAYNAME.FieldName = "PURDISPLAYNAME"
        Me.GPURDISPLAYNAME.Name = "GPURDISPLAYNAME"
        Me.GPURDISPLAYNAME.Width = 160
        '
        'CMDOK
        '
        Me.CMDOK.BackColor = System.Drawing.Color.Transparent
        Me.CMDOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDOK.FlatAppearance.BorderSize = 0
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.Black
        Me.CMDOK.Location = New System.Drawing.Point(559, 544)
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
        Me.cmdcancel.Location = New System.Drawing.Point(645, 544)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(80, 28)
        Me.cmdcancel.TabIndex = 316
        Me.cmdcancel.Text = "E&xit"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(10, 37)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(153, 14)
        Me.lbl.TabIndex = 251
        Me.lbl.Text = "Select a Voucher to Change"
        '
        'GPACKAGETYPE
        '
        Me.GPACKAGETYPE.Caption = "Package Type"
        Me.GPACKAGETYPE.FieldName = "DOMINT"
        Me.GPACKAGETYPE.Name = "GPACKAGETYPE"
        Me.GPACKAGETYPE.Visible = True
        Me.GPACKAGETYPE.VisibleIndex = 28
        Me.GPACKAGETYPE.Width = 120
        '
        'ReservationDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1284, 582)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "ReservationDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Reservation Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GBOOKINGNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBOOKINGDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGUESTNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GHOTELNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHECKIN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHECKOUT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBOOKEDBY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBALANCE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMDOK As System.Windows.Forms.Button
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ExcelExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GPURAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURBAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSALEAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBOOKTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBILL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSALENAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREFNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGROSSAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGROUPNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALROOMS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNIGHTS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALNIGHTS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GGROSS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGROSSSALE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALPAX As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSECTORS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGROUPOFHOTELS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCMPNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCMPGST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDISPLAYNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURDISPLAYNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPACKAGETYPE As DevExpress.XtraGrid.Columns.GridColumn
End Class
