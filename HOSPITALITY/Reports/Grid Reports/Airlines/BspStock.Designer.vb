<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BspStock
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
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BspStock))
        Me.GRIDREC = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GTICKETNO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GBASIC = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GPSF = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTAX = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GAMT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.griddetails = New DevExpress.XtraGrid.GridControl
        Me.gridregister = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GTYPE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GAIRLINENAME = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GREFNO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gcrstype = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gbillinitials = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gdr = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gcr = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gbillno = New DevExpress.XtraGrid.Columns.GridColumn
        Me.greg = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTICKET = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GBOOKEDBY = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gremarks = New DevExpress.XtraGrid.Columns.GridColumn
        Me.guser = New DevExpress.XtraGrid.Columns.GridColumn
        Me.CHKTICKET = New System.Windows.Forms.CheckBox
        Me.ARRTO = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.ARRFROM = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.lbldrcropening = New System.Windows.Forms.Label
        Me.txtopening = New System.Windows.Forms.TextBox
        Me.lblopbal = New System.Windows.Forms.Label
        Me.chkpaid = New System.Windows.Forms.CheckBox
        Me.CMBACCCODE = New System.Windows.Forms.ComboBox
        Me.txtadd = New System.Windows.Forms.TextBox
        Me.cmdshowdetails = New System.Windows.Forms.Button
        Me.cmdok = New System.Windows.Forms.Button
        Me.cmdexit = New System.Windows.Forms.Button
        Me.txtcrtotal = New System.Windows.Forms.TextBox
        Me.txtdrtotal = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblfrom = New System.Windows.Forms.Label
        Me.chkall = New System.Windows.Forms.CheckBox
        Me.lblname = New System.Windows.Forms.Label
        Me.cmbname = New System.Windows.Forms.ComboBox
        Me.lbldate = New System.Windows.Forms.Label
        Me.registerdate = New System.Windows.Forms.DateTimePicker
        Me.lbldrcrclosing = New System.Windows.Forms.Label
        Me.txttotal = New System.Windows.Forms.TextBox
        Me.lbln = New System.Windows.Forms.Label
        Me.txttempbillno = New System.Windows.Forms.TextBox
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.chkdate = New System.Windows.Forms.CheckBox
        Me.dtto = New System.Windows.Forms.DateTimePicker
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.lblto = New System.Windows.Forms.Label
        Me.dtfrom = New System.Windows.Forms.DateTimePicker
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ExcelExport = New System.Windows.Forms.ToolStripButton
        Me.lbl = New System.Windows.Forms.Label
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.CMBAIRCODE = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbairline = New System.Windows.Forms.ComboBox
        CType(Me.GRIDREC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridregister, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.BlendPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GRIDREC
        '
        Me.GRIDREC.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GTICKETNO, Me.GBASIC, Me.GPSF, Me.GTAX, Me.GAMT})
        Me.GRIDREC.GridControl = Me.griddetails
        Me.GRIDREC.Name = "GRIDREC"
        Me.GRIDREC.OptionsBehavior.AutoExpandAllGroups = True
        Me.GRIDREC.OptionsBehavior.Editable = False
        Me.GRIDREC.OptionsView.ColumnAutoWidth = False
        Me.GRIDREC.OptionsView.ShowFooter = True
        Me.GRIDREC.OptionsView.ShowGroupPanel = False
        '
        'GTICKETNO
        '
        Me.GTICKETNO.Caption = "Ticket No"
        Me.GTICKETNO.FieldName = "TICKETNO"
        Me.GTICKETNO.Name = "GTICKETNO"
        Me.GTICKETNO.Visible = True
        Me.GTICKETNO.VisibleIndex = 0
        Me.GTICKETNO.Width = 120
        '
        'GBASIC
        '
        Me.GBASIC.Caption = "Basic Amount"
        Me.GBASIC.DisplayFormat.FormatString = "0.00"
        Me.GBASIC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GBASIC.FieldName = "GRIDBASIC"
        Me.GBASIC.Name = "GBASIC"
        Me.GBASIC.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GBASIC.Visible = True
        Me.GBASIC.VisibleIndex = 1
        Me.GBASIC.Width = 100
        '
        'GPSF
        '
        Me.GPSF.Caption = "PSF Amount"
        Me.GPSF.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPSF.FieldName = "GRIDPSF"
        Me.GPSF.Name = "GPSF"
        Me.GPSF.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GPSF.Visible = True
        Me.GPSF.VisibleIndex = 2
        Me.GPSF.Width = 100
        '
        'GTAX
        '
        Me.GTAX.Caption = "Tax Amount"
        Me.GTAX.DisplayFormat.FormatString = "0.00"
        Me.GTAX.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTAX.FieldName = "GRIDTAX"
        Me.GTAX.Name = "GTAX"
        Me.GTAX.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GTAX.Visible = True
        Me.GTAX.VisibleIndex = 3
        Me.GTAX.Width = 100
        '
        'GAMT
        '
        Me.GAMT.Caption = "Total"
        Me.GAMT.DisplayFormat.FormatString = "0.00"
        Me.GAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GAMT.FieldName = "GRIDTOTAL"
        Me.GAMT.Name = "GAMT"
        Me.GAMT.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GAMT.Visible = True
        Me.GAMT.VisibleIndex = 4
        Me.GAMT.Width = 100
        '
        'griddetails
        '
        Me.griddetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        GridLevelNode1.LevelTemplate = Me.GRIDREC
        GridLevelNode1.RelationName = "BILLDETAILS"
        Me.griddetails.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.griddetails.Location = New System.Drawing.Point(17, 102)
        Me.griddetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.griddetails.MainView = Me.gridregister
        Me.griddetails.Name = "griddetails"
        Me.griddetails.Size = New System.Drawing.Size(951, 417)
        Me.griddetails.TabIndex = 447
        Me.griddetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridregister, Me.GRIDREC})
        '
        'gridregister
        '
        Me.gridregister.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridregister.Appearance.Row.Options.UseFont = True
        Me.gridregister.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridregister.Appearance.ViewCaption.Options.UseFont = True
        Me.gridregister.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GTYPE, Me.gDate, Me.GAIRLINENAME, Me.GNAME, Me.GREFNO, Me.gcrstype, Me.gbillinitials, Me.gdr, Me.gcr, Me.gbillno, Me.greg, Me.GTICKET, Me.GBOOKEDBY, Me.gremarks, Me.guser})
        Me.gridregister.GridControl = Me.griddetails
        Me.gridregister.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridregister.Name = "gridregister"
        Me.gridregister.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridregister.OptionsBehavior.Editable = False
        Me.gridregister.OptionsView.AllowCellMerge = True
        Me.gridregister.OptionsView.ColumnAutoWidth = False
        Me.gridregister.OptionsView.ShowFooter = True
        '
        'GTYPE
        '
        Me.GTYPE.Caption = "TYPE"
        Me.GTYPE.FieldName = "TYPE"
        Me.GTYPE.Name = "GTYPE"
        '
        'gDate
        '
        Me.gDate.Caption = "Date"
        Me.gDate.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.gDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.gDate.FieldName = "DATE"
        Me.gDate.Name = "gDate"
        Me.gDate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.gDate.Visible = True
        Me.gDate.VisibleIndex = 0
        '
        'GAIRLINENAME
        '
        Me.GAIRLINENAME.Caption = "Airline Name"
        Me.GAIRLINENAME.FieldName = "AIRLINENAME"
        Me.GAIRLINENAME.Name = "GAIRLINENAME"
        Me.GAIRLINENAME.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GAIRLINENAME.Visible = True
        Me.GAIRLINENAME.VisibleIndex = 1
        Me.GAIRLINENAME.Width = 150
        '
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "CMNNAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 2
        Me.GNAME.Width = 150
        '
        'GREFNO
        '
        Me.GREFNO.Caption = "Ref No"
        Me.GREFNO.FieldName = "REFNO"
        Me.GREFNO.Name = "GREFNO"
        Me.GREFNO.Visible = True
        Me.GREFNO.VisibleIndex = 3
        '
        'gcrstype
        '
        Me.gcrstype.Caption = "CRS Type"
        Me.gcrstype.FieldName = "CRSTYPE"
        Me.gcrstype.Name = "gcrstype"
        Me.gcrstype.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.gcrstype.Visible = True
        Me.gcrstype.VisibleIndex = 4
        '
        'gbillinitials
        '
        Me.gbillinitials.Caption = "Bill No."
        Me.gbillinitials.FieldName = "INITIALS"
        Me.gbillinitials.ImageIndex = 1
        Me.gbillinitials.Name = "gbillinitials"
        Me.gbillinitials.Visible = True
        Me.gbillinitials.VisibleIndex = 5
        '
        'gdr
        '
        Me.gdr.Caption = "Debit"
        Me.gdr.DisplayFormat.FormatString = "0.00"
        Me.gdr.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.gdr.FieldName = "DR"
        Me.gdr.Name = "gdr"
        Me.gdr.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.gdr.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.gdr.Visible = True
        Me.gdr.VisibleIndex = 6
        '
        'gcr
        '
        Me.gcr.Caption = "Credit"
        Me.gcr.DisplayFormat.FormatString = "0.00"
        Me.gcr.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.gcr.FieldName = "CR"
        Me.gcr.Name = "gcr"
        Me.gcr.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.gcr.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.gcr.Visible = True
        Me.gcr.VisibleIndex = 7
        '
        'gbillno
        '
        Me.gbillno.Caption = "Bill no"
        Me.gbillno.FieldName = "BILL"
        Me.gbillno.Name = "gbillno"
        '
        'greg
        '
        Me.greg.Caption = "Reg Name"
        Me.greg.FieldName = "REGTYPE"
        Me.greg.Name = "greg"
        '
        'GTICKET
        '
        Me.GTICKET.Caption = "Ticket Date"
        Me.GTICKET.FieldName = "TICKETDATE"
        Me.GTICKET.Name = "GTICKET"
        Me.GTICKET.Visible = True
        Me.GTICKET.VisibleIndex = 8
        '
        'GBOOKEDBY
        '
        Me.GBOOKEDBY.Caption = "Booked By"
        Me.GBOOKEDBY.FieldName = "BOOKEDBY"
        Me.GBOOKEDBY.Name = "GBOOKEDBY"
        Me.GBOOKEDBY.Visible = True
        Me.GBOOKEDBY.VisibleIndex = 9
        '
        'gremarks
        '
        Me.gremarks.Caption = "Remarks"
        Me.gremarks.FieldName = "REMARKS"
        Me.gremarks.Name = "gremarks"
        Me.gremarks.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.gremarks.Visible = True
        Me.gremarks.VisibleIndex = 10
        Me.gremarks.Width = 120
        '
        'guser
        '
        Me.guser.Caption = "User"
        Me.guser.FieldName = "USERNAME"
        Me.guser.Name = "guser"
        Me.guser.Visible = True
        Me.guser.VisibleIndex = 11
        '
        'CHKTICKET
        '
        Me.CHKTICKET.AutoSize = True
        Me.CHKTICKET.BackColor = System.Drawing.Color.Transparent
        Me.CHKTICKET.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKTICKET.Location = New System.Drawing.Point(571, 40)
        Me.CHKTICKET.Name = "CHKTICKET"
        Me.CHKTICKET.Size = New System.Drawing.Size(71, 18)
        Me.CHKTICKET.TabIndex = 491
        Me.CHKTICKET.Text = "Tik Date"
        Me.CHKTICKET.UseVisualStyleBackColor = False
        '
        'ARRTO
        '
        Me.ARRTO.CustomFormat = "dd/MM/yyyy"
        Me.ARRTO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ARRTO.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.ARRTO.Location = New System.Drawing.Point(679, 64)
        Me.ARRTO.Name = "ARRTO"
        Me.ARRTO.Size = New System.Drawing.Size(79, 22)
        Me.ARRTO.TabIndex = 493
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(655, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 14)
        Me.Label1.TabIndex = 494
        Me.Label1.Text = "To"
        '
        'ARRFROM
        '
        Me.ARRFROM.CustomFormat = "dd/MM/yyyy"
        Me.ARRFROM.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ARRFROM.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.ARRFROM.Location = New System.Drawing.Point(678, 38)
        Me.ARRFROM.Name = "ARRFROM"
        Me.ARRFROM.Size = New System.Drawing.Size(80, 22)
        Me.ARRFROM.TabIndex = 492
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(640, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 14)
        Me.Label3.TabIndex = 490
        Me.Label3.Text = "From"
        '
        'lbldrcropening
        '
        Me.lbldrcropening.AutoSize = True
        Me.lbldrcropening.BackColor = System.Drawing.Color.Transparent
        Me.lbldrcropening.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldrcropening.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbldrcropening.Location = New System.Drawing.Point(934, 80)
        Me.lbldrcropening.Name = "lbldrcropening"
        Me.lbldrcropening.Size = New System.Drawing.Size(0, 14)
        Me.lbldrcropening.TabIndex = 487
        Me.lbldrcropening.Visible = False
        '
        'txtopening
        '
        Me.txtopening.BackColor = System.Drawing.Color.White
        Me.txtopening.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtopening.ForeColor = System.Drawing.Color.Black
        Me.txtopening.Location = New System.Drawing.Point(832, 77)
        Me.txtopening.Name = "txtopening"
        Me.txtopening.ReadOnly = True
        Me.txtopening.Size = New System.Drawing.Size(100, 22)
        Me.txtopening.TabIndex = 486
        Me.txtopening.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtopening.Visible = False
        '
        'lblopbal
        '
        Me.lblopbal.AutoSize = True
        Me.lblopbal.BackColor = System.Drawing.Color.Transparent
        Me.lblopbal.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblopbal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblopbal.Location = New System.Drawing.Point(782, 80)
        Me.lblopbal.Name = "lblopbal"
        Me.lblopbal.Size = New System.Drawing.Size(45, 14)
        Me.lblopbal.TabIndex = 485
        Me.lblopbal.Text = "O/P Bal"
        Me.lblopbal.Visible = False
        '
        'chkpaid
        '
        Me.chkpaid.AutoSize = True
        Me.chkpaid.BackColor = System.Drawing.Color.Transparent
        Me.chkpaid.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkpaid.Location = New System.Drawing.Point(856, 47)
        Me.chkpaid.Name = "chkpaid"
        Me.chkpaid.Size = New System.Drawing.Size(78, 18)
        Me.chkpaid.TabIndex = 484
        Me.chkpaid.Text = "Paid Bills"
        Me.chkpaid.UseVisualStyleBackColor = False
        Me.chkpaid.Visible = False
        '
        'CMBACCCODE
        '
        Me.CMBACCCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBACCCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBACCCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBACCCODE.FormattingEnabled = True
        Me.CMBACCCODE.Items.AddRange(New Object() {""})
        Me.CMBACCCODE.Location = New System.Drawing.Point(964, 28)
        Me.CMBACCCODE.Name = "CMBACCCODE"
        Me.CMBACCCODE.Size = New System.Drawing.Size(28, 22)
        Me.CMBACCCODE.TabIndex = 483
        Me.CMBACCCODE.Visible = False
        '
        'txtadd
        '
        Me.txtadd.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtadd.Location = New System.Drawing.Point(837, 28)
        Me.txtadd.Name = "txtadd"
        Me.txtadd.Size = New System.Drawing.Size(14, 22)
        Me.txtadd.TabIndex = 448
        Me.txtadd.Visible = False
        '
        'cmdshowdetails
        '
        Me.cmdshowdetails.BackColor = System.Drawing.Color.Transparent
        Me.cmdshowdetails.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdshowdetails.FlatAppearance.BorderSize = 0
        Me.cmdshowdetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdshowdetails.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdshowdetails.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdshowdetails.Image = Global.HOSPITALITY.My.Resources.Resources.showdetails2
        Me.cmdshowdetails.Location = New System.Drawing.Point(561, 60)
        Me.cmdshowdetails.Name = "cmdshowdetails"
        Me.cmdshowdetails.Size = New System.Drawing.Size(83, 25)
        Me.cmdshowdetails.TabIndex = 4
        Me.cmdshowdetails.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Image = Global.HOSPITALITY.My.Resources.Resources.ok
        Me.cmdok.Location = New System.Drawing.Point(439, 535)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(72, 25)
        Me.cmdok.TabIndex = 5
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Image = Global.HOSPITALITY.My.Resources.Resources._Exit
        Me.cmdexit.Location = New System.Drawing.Point(517, 535)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(72, 24)
        Me.cmdexit.TabIndex = 6
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'txtcrtotal
        '
        Me.txtcrtotal.BackColor = System.Drawing.Color.White
        Me.txtcrtotal.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcrtotal.ForeColor = System.Drawing.Color.Black
        Me.txtcrtotal.Location = New System.Drawing.Point(827, 525)
        Me.txtcrtotal.Name = "txtcrtotal"
        Me.txtcrtotal.ReadOnly = True
        Me.txtcrtotal.Size = New System.Drawing.Size(100, 22)
        Me.txtcrtotal.TabIndex = 443
        Me.txtcrtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtdrtotal
        '
        Me.txtdrtotal.BackColor = System.Drawing.Color.White
        Me.txtdrtotal.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdrtotal.ForeColor = System.Drawing.Color.Black
        Me.txtdrtotal.Location = New System.Drawing.Point(727, 525)
        Me.txtdrtotal.Name = "txtdrtotal"
        Me.txtdrtotal.ReadOnly = True
        Me.txtdrtotal.Size = New System.Drawing.Size(100, 22)
        Me.txtdrtotal.TabIndex = 442
        Me.txtdrtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(692, 529)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 14)
        Me.Label2.TabIndex = 441
        Me.Label2.Text = "Total"
        '
        'lblfrom
        '
        Me.lblfrom.AutoSize = True
        Me.lblfrom.BackColor = System.Drawing.Color.Transparent
        Me.lblfrom.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfrom.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblfrom.Location = New System.Drawing.Point(429, 42)
        Me.lblfrom.Name = "lblfrom"
        Me.lblfrom.Size = New System.Drawing.Size(34, 14)
        Me.lblfrom.TabIndex = 1
        Me.lblfrom.Text = "From"
        '
        'chkall
        '
        Me.chkall.AutoSize = True
        Me.chkall.BackColor = System.Drawing.Color.Transparent
        Me.chkall.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkall.Location = New System.Drawing.Point(782, 47)
        Me.chkall.Name = "chkall"
        Me.chkall.Size = New System.Drawing.Size(69, 18)
        Me.chkall.TabIndex = 440
        Me.chkall.Text = "All Bills"
        Me.chkall.UseVisualStyleBackColor = False
        '
        'lblname
        '
        Me.lblname.AutoSize = True
        Me.lblname.BackColor = System.Drawing.Color.Transparent
        Me.lblname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblname.ForeColor = System.Drawing.Color.Black
        Me.lblname.Location = New System.Drawing.Point(139, 43)
        Me.lblname.Name = "lblname"
        Me.lblname.Size = New System.Drawing.Size(39, 14)
        Me.lblname.TabIndex = 429
        Me.lblname.Text = "Name"
        '
        'cmbname
        '
        Me.cmbname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbname.FormattingEnabled = True
        Me.cmbname.Location = New System.Drawing.Point(181, 39)
        Me.cmbname.MaxDropDownItems = 14
        Me.cmbname.Name = "cmbname"
        Me.cmbname.Size = New System.Drawing.Size(187, 22)
        Me.cmbname.TabIndex = 0
        '
        'lbldate
        '
        Me.lbldate.AutoSize = True
        Me.lbldate.BackColor = System.Drawing.Color.Transparent
        Me.lbldate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldate.Location = New System.Drawing.Point(22, 76)
        Me.lbldate.Name = "lbldate"
        Me.lbldate.Size = New System.Drawing.Size(33, 14)
        Me.lbldate.TabIndex = 428
        Me.lbldate.Text = "Date"
        Me.lbldate.Visible = False
        '
        'registerdate
        '
        Me.registerdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.registerdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.registerdate.Location = New System.Drawing.Point(56, 72)
        Me.registerdate.Name = "registerdate"
        Me.registerdate.Size = New System.Drawing.Size(25, 22)
        Me.registerdate.TabIndex = 423
        Me.registerdate.Visible = False
        '
        'lbldrcrclosing
        '
        Me.lbldrcrclosing.AutoSize = True
        Me.lbldrcrclosing.BackColor = System.Drawing.Color.Transparent
        Me.lbldrcrclosing.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldrcrclosing.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbldrcrclosing.Location = New System.Drawing.Point(929, 554)
        Me.lbldrcrclosing.Name = "lbldrcrclosing"
        Me.lbldrcrclosing.Size = New System.Drawing.Size(0, 14)
        Me.lbldrcrclosing.TabIndex = 436
        '
        'txttotal
        '
        Me.txttotal.BackColor = System.Drawing.Color.White
        Me.txttotal.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotal.ForeColor = System.Drawing.Color.Black
        Me.txttotal.Location = New System.Drawing.Point(827, 551)
        Me.txttotal.Name = "txttotal"
        Me.txttotal.ReadOnly = True
        Me.txttotal.Size = New System.Drawing.Size(100, 22)
        Me.txttotal.TabIndex = 435
        Me.txttotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbln
        '
        Me.lbln.AutoSize = True
        Me.lbln.BackColor = System.Drawing.Color.Transparent
        Me.lbln.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbln.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbln.Location = New System.Drawing.Point(761, 555)
        Me.lbln.Name = "lbln"
        Me.lbln.Size = New System.Drawing.Size(64, 14)
        Me.lbln.TabIndex = 434
        Me.lbln.Text = "Closing Bal."
        '
        'txttempbillno
        '
        Me.txttempbillno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttempbillno.Location = New System.Drawing.Point(879, 28)
        Me.txttempbillno.Name = "txttempbillno"
        Me.txttempbillno.Size = New System.Drawing.Size(12, 22)
        Me.txttempbillno.TabIndex = 433
        Me.txttempbillno.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.Location = New System.Drawing.Point(377, 40)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(52, 18)
        Me.chkdate.TabIndex = 1
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'dtto
        '
        Me.dtto.CustomFormat = "dd/MM/yyyy"
        Me.dtto.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(468, 64)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(87, 22)
        Me.dtto.TabIndex = 3
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
        'lblto
        '
        Me.lblto.AutoSize = True
        Me.lblto.BackColor = System.Drawing.Color.Transparent
        Me.lblto.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblto.Location = New System.Drawing.Point(444, 68)
        Me.lblto.Name = "lblto"
        Me.lblto.Size = New System.Drawing.Size(19, 14)
        Me.lblto.TabIndex = 432
        Me.lblto.Text = "To"
        '
        'dtfrom
        '
        Me.dtfrom.CustomFormat = "dd/MM/yyyy"
        Me.dtfrom.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfrom.Location = New System.Drawing.Point(467, 38)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(88, 22)
        Me.dtfrom.TabIndex = 2
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintToolStripButton, Me.ToolStripSeparator2, Me.ExcelExport, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1004, 25)
        Me.ToolStrip1.TabIndex = 430
        Me.ToolStrip1.Text = "v"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
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
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(11, 33)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(106, 24)
        Me.lbl.TabIndex = 427
        Me.lbl.Text = "BSP Stock"
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMBAIRCODE)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.cmbairline)
        Me.BlendPanel1.Controls.Add(Me.CHKTICKET)
        Me.BlendPanel1.Controls.Add(Me.ARRTO)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.ARRFROM)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.lbldrcropening)
        Me.BlendPanel1.Controls.Add(Me.txtopening)
        Me.BlendPanel1.Controls.Add(Me.lblopbal)
        Me.BlendPanel1.Controls.Add(Me.griddetails)
        Me.BlendPanel1.Controls.Add(Me.chkpaid)
        Me.BlendPanel1.Controls.Add(Me.CMBACCCODE)
        Me.BlendPanel1.Controls.Add(Me.txtadd)
        Me.BlendPanel1.Controls.Add(Me.cmdshowdetails)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.txtcrtotal)
        Me.BlendPanel1.Controls.Add(Me.txtdrtotal)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.chkall)
        Me.BlendPanel1.Controls.Add(Me.lbldrcrclosing)
        Me.BlendPanel1.Controls.Add(Me.txttotal)
        Me.BlendPanel1.Controls.Add(Me.lbln)
        Me.BlendPanel1.Controls.Add(Me.txttempbillno)
        Me.BlendPanel1.Controls.Add(Me.chkdate)
        Me.BlendPanel1.Controls.Add(Me.dtto)
        Me.BlendPanel1.Controls.Add(Me.lblto)
        Me.BlendPanel1.Controls.Add(Me.dtfrom)
        Me.BlendPanel1.Controls.Add(Me.lblfrom)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.lblname)
        Me.BlendPanel1.Controls.Add(Me.cmbname)
        Me.BlendPanel1.Controls.Add(Me.lbldate)
        Me.BlendPanel1.Controls.Add(Me.registerdate)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1004, 605)
        Me.BlendPanel1.TabIndex = 2
        '
        'CMBAIRCODE
        '
        Me.CMBAIRCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBAIRCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBAIRCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBAIRCODE.FormattingEnabled = True
        Me.CMBAIRCODE.Items.AddRange(New Object() {""})
        Me.CMBAIRCODE.Location = New System.Drawing.Point(964, 66)
        Me.CMBAIRCODE.Name = "CMBAIRCODE"
        Me.CMBAIRCODE.Size = New System.Drawing.Size(28, 22)
        Me.CMBAIRCODE.TabIndex = 497
        Me.CMBAIRCODE.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(128, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 14)
        Me.Label4.TabIndex = 496
        Me.Label4.Text = "Airlines"
        '
        'cmbairline
        '
        Me.cmbairline.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbairline.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbairline.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbairline.FormattingEnabled = True
        Me.cmbairline.Location = New System.Drawing.Point(181, 65)
        Me.cmbairline.MaxDropDownItems = 14
        Me.cmbairline.Name = "cmbairline"
        Me.cmbairline.Size = New System.Drawing.Size(187, 22)
        Me.cmbairline.TabIndex = 495
        '
        'BspStock
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1004, 605)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.KeyPreview = True
        Me.Name = "BspStock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Tag = ""
        Me.Text = "BSP Stock"
        Me.TopMost = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.GRIDREC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridregister, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CHKTICKET As System.Windows.Forms.CheckBox
    Friend WithEvents ARRTO As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ARRFROM As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbldrcropening As System.Windows.Forms.Label
    Friend WithEvents txtopening As System.Windows.Forms.TextBox
    Friend WithEvents lblopbal As System.Windows.Forms.Label
    Private WithEvents griddetails As DevExpress.XtraGrid.GridControl
    Friend WithEvents GRIDREC As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents gridregister As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents gDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAIRLINENAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREFNO As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gcrstype As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gbillinitials As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gdr As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gcr As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gbillno As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents greg As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTICKET As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gremarks As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents chkpaid As System.Windows.Forms.CheckBox
    Friend WithEvents CMBACCCODE As System.Windows.Forms.ComboBox
    Friend WithEvents txtadd As System.Windows.Forms.TextBox
    Friend WithEvents cmdshowdetails As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents txtcrtotal As System.Windows.Forms.TextBox
    Friend WithEvents txtdrtotal As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblfrom As System.Windows.Forms.Label
    Friend WithEvents chkall As System.Windows.Forms.CheckBox
    Friend WithEvents lblname As System.Windows.Forms.Label
    Friend WithEvents cmbname As System.Windows.Forms.ComboBox
    Friend WithEvents lbldate As System.Windows.Forms.Label
    Friend WithEvents registerdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbldrcrclosing As System.Windows.Forms.Label
    Friend WithEvents txttotal As System.Windows.Forms.TextBox
    Friend WithEvents lbln As System.Windows.Forms.Label
    Friend WithEvents txttempbillno As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblto As System.Windows.Forms.Label
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExcelExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbairline As System.Windows.Forms.ComboBox
    Friend WithEvents guser As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMBAIRCODE As System.Windows.Forms.ComboBox
    Friend WithEvents GBOOKEDBY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTICKETNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBASIC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPSF As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTAX As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAMT As DevExpress.XtraGrid.Columns.GridColumn
End Class
