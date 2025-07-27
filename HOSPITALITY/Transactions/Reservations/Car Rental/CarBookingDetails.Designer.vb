<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CarBookingDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CarBookingDetails))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TXTCOPIES = New System.Windows.Forms.TextBox()
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
        Me.GBOOKINGTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCARNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GVEHICLE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDRIVERNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCONFIRMEDBY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gaccname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSTATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGSTIN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFROM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDAYS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNIGHTS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSTART = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GEND = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALKMS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GEXTRAKMS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSTARTTIME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GENDTIME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALTIME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GEXTRATIME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSUBTOTAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTAXNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTAXAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOTHERCHGS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gHSNCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTAXSERVCHGSAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCGSTPER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gCGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gSGSTPER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gSGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gIGSTPER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gIGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gtotalsale = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBALANCE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURSTART = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPUREND = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURTOTALKMS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPUREXTRAKMS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURSTARTTIME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURENDTIME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURTOTALTIME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPUREXTRATIME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURSUBTOTAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURTAXNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURTAXAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPUROTHERCHGS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gtotalpurchase = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GUSERNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRETURN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDISPUTE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBILLCHECKED = New DevExpress.XtraGrid.Columns.GridColumn()
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
        Me.TOOLGRIDDETAILS = New System.Windows.Forms.ToolStripButton()
        Me.lbl = New System.Windows.Forms.Label()
        Me.PRINTDIALOG = New System.Windows.Forms.PrintDialog()
        Me.PRINTDOC = New System.Drawing.Printing.PrintDocument()
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
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 562)
        Me.BlendPanel1.TabIndex = 4
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.White
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(457, 5)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(44, 14)
        Me.Label11.TabIndex = 805
        Me.Label11.Text = "Copies"
        '
        'TXTCOPIES
        '
        Me.TXTCOPIES.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCOPIES.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCOPIES.Location = New System.Drawing.Point(585, 1)
        Me.TXTCOPIES.Name = "TXTCOPIES"
        Me.TXTCOPIES.Size = New System.Drawing.Size(29, 22)
        Me.TXTCOPIES.TabIndex = 804
        Me.TXTCOPIES.Text = "1"
        Me.TXTCOPIES.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LBLTO
        '
        Me.LBLTO.AutoSize = True
        Me.LBLTO.BackColor = System.Drawing.Color.White
        Me.LBLTO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTO.Location = New System.Drawing.Point(356, 5)
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
        Me.LBLFROM.Location = New System.Drawing.Point(257, 5)
        Me.LBLFROM.Name = "LBLFROM"
        Me.LBLFROM.Size = New System.Drawing.Size(34, 14)
        Me.LBLFROM.TabIndex = 786
        Me.LBLFROM.Text = "From"
        '
        'TXTTO
        '
        Me.TXTTO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTTO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTO.Location = New System.Drawing.Point(379, 1)
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
        Me.TXTFROM.Location = New System.Drawing.Point(296, 1)
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
        Me.Label6.Location = New System.Drawing.Point(483, 41)
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
        Me.Label8.Location = New System.Drawing.Point(464, 39)
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
        Me.Label3.Location = New System.Drawing.Point(354, 41)
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
        Me.Label5.Location = New System.Drawing.Point(335, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(18, 16)
        Me.Label5.TabIndex = 491
        Me.Label5.Text = "   "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(222, 41)
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
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.Black
        Me.CMDOK.Location = New System.Drawing.Point(534, 535)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(80, 28)
        Me.CMDOK.TabIndex = 317
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
        Me.cmdcancel.Location = New System.Drawing.Point(620, 535)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(80, 28)
        Me.cmdcancel.TabIndex = 316
        Me.cmdcancel.Text = "E&xit"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(15, 59)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1207, 470)
        Me.gridbilldetails.TabIndex = 314
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GINITIALS, Me.gsrno, Me.GREFNO, Me.gdate, Me.GBOOKINGTYPE, Me.GCARNO, Me.GVEHICLE, Me.GDRIVERNAME, Me.GCONFIRMEDBY, Me.gname, Me.gaccname, Me.GSTATE, Me.GGSTIN, Me.GFROM, Me.GTO, Me.GDAYS, Me.GNIGHTS, Me.GSTART, Me.GEND, Me.GTOTALKMS, Me.GEXTRAKMS, Me.GSTARTTIME, Me.GENDTIME, Me.GTOTALTIME, Me.GEXTRATIME, Me.GSUBTOTAL, Me.GTAXNAME, Me.GTAXAMT, Me.GOTHERCHGS, Me.gHSNCODE, Me.GTAXSERVCHGSAMT, Me.GCGSTPER, Me.gCGSTAMT, Me.gSGSTPER, Me.gSGSTAMT, Me.gIGSTPER, Me.gIGSTAMT, Me.gtotalsale, Me.GBALANCE, Me.GPURSTART, Me.GPUREND, Me.GPURTOTALKMS, Me.GPUREXTRAKMS, Me.GPURSTARTTIME, Me.GPURENDTIME, Me.GPURTOTALTIME, Me.GPUREXTRATIME, Me.GPURSUBTOTAL, Me.GPURTAXNAME, Me.GPURTAXAMT, Me.GPUROTHERCHGS, Me.gtotalpurchase, Me.GUSERNAME, Me.GRETURN, Me.GDISPUTE, Me.GBILLCHECKED, Me.GIRNNO, Me.GACKNO, Me.GACKDATE, Me.GQRCODE, Me.GGROUPDEPARTURE})
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
        'GBOOKINGTYPE
        '
        Me.GBOOKINGTYPE.Caption = "Booking Type"
        Me.GBOOKINGTYPE.FieldName = "BOOKINGTYPE"
        Me.GBOOKINGTYPE.Name = "GBOOKINGTYPE"
        Me.GBOOKINGTYPE.Visible = True
        Me.GBOOKINGTYPE.VisibleIndex = 4
        Me.GBOOKINGTYPE.Width = 100
        '
        'GCARNO
        '
        Me.GCARNO.Caption = "Car No"
        Me.GCARNO.FieldName = "VEHICLENO"
        Me.GCARNO.Name = "GCARNO"
        Me.GCARNO.Visible = True
        Me.GCARNO.VisibleIndex = 5
        '
        'GVEHICLE
        '
        Me.GVEHICLE.Caption = "Car Type"
        Me.GVEHICLE.FieldName = "VEHICLENAME"
        Me.GVEHICLE.Name = "GVEHICLE"
        Me.GVEHICLE.Visible = True
        Me.GVEHICLE.VisibleIndex = 6
        Me.GVEHICLE.Width = 100
        '
        'GDRIVERNAME
        '
        Me.GDRIVERNAME.Caption = "Driver Name"
        Me.GDRIVERNAME.FieldName = "DRIVERNAME"
        Me.GDRIVERNAME.Name = "GDRIVERNAME"
        Me.GDRIVERNAME.Visible = True
        Me.GDRIVERNAME.VisibleIndex = 7
        Me.GDRIVERNAME.Width = 120
        '
        'GCONFIRMEDBY
        '
        Me.GCONFIRMEDBY.Caption = "Confirmed By"
        Me.GCONFIRMEDBY.FieldName = "CONFIRMEDBY"
        Me.GCONFIRMEDBY.Name = "GCONFIRMEDBY"
        Me.GCONFIRMEDBY.Visible = True
        Me.GCONFIRMEDBY.VisibleIndex = 8
        Me.GCONFIRMEDBY.Width = 120
        '
        'gname
        '
        Me.gname.Caption = "Guest Name"
        Me.gname.FieldName = "GUESTNAME"
        Me.gname.ImageIndex = 0
        Me.gname.Name = "gname"
        Me.gname.Visible = True
        Me.gname.VisibleIndex = 9
        Me.gname.Width = 200
        '
        'gaccname
        '
        Me.gaccname.Caption = "Account Name"
        Me.gaccname.FieldName = "ACCNAME"
        Me.gaccname.Name = "gaccname"
        Me.gaccname.Visible = True
        Me.gaccname.VisibleIndex = 10
        Me.gaccname.Width = 200
        '
        'GSTATE
        '
        Me.GSTATE.Caption = "State Name"
        Me.GSTATE.FieldName = "STATENAME"
        Me.GSTATE.Name = "GSTATE"
        Me.GSTATE.Visible = True
        Me.GSTATE.VisibleIndex = 11
        Me.GSTATE.Width = 80
        '
        'GGSTIN
        '
        Me.GGSTIN.Caption = "GSTIN"
        Me.GGSTIN.FieldName = "GSTIN"
        Me.GGSTIN.Name = "GGSTIN"
        Me.GGSTIN.Visible = True
        Me.GGSTIN.VisibleIndex = 12
        '
        'GFROM
        '
        Me.GFROM.Caption = "From"
        Me.GFROM.FieldName = "FROM"
        Me.GFROM.Name = "GFROM"
        Me.GFROM.Visible = True
        Me.GFROM.VisibleIndex = 13
        Me.GFROM.Width = 70
        '
        'GTO
        '
        Me.GTO.Caption = "To"
        Me.GTO.FieldName = "TO"
        Me.GTO.Name = "GTO"
        Me.GTO.Visible = True
        Me.GTO.VisibleIndex = 14
        Me.GTO.Width = 70
        '
        'GDAYS
        '
        Me.GDAYS.Caption = "Days"
        Me.GDAYS.DisplayFormat.FormatString = "0"
        Me.GDAYS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GDAYS.FieldName = "DAYS"
        Me.GDAYS.Name = "GDAYS"
        Me.GDAYS.Visible = True
        Me.GDAYS.VisibleIndex = 15
        Me.GDAYS.Width = 60
        '
        'GNIGHTS
        '
        Me.GNIGHTS.Caption = "Nights"
        Me.GNIGHTS.DisplayFormat.FormatString = "0"
        Me.GNIGHTS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GNIGHTS.FieldName = "NIGHTS"
        Me.GNIGHTS.Name = "GNIGHTS"
        Me.GNIGHTS.Visible = True
        Me.GNIGHTS.VisibleIndex = 16
        '
        'GSTART
        '
        Me.GSTART.AppearanceCell.BackColor = System.Drawing.Color.Linen
        Me.GSTART.AppearanceCell.Options.UseBackColor = True
        Me.GSTART.Caption = "Opening Kms"
        Me.GSTART.DisplayFormat.FormatString = "0"
        Me.GSTART.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSTART.FieldName = "STARTKMS"
        Me.GSTART.Name = "GSTART"
        Me.GSTART.Visible = True
        Me.GSTART.VisibleIndex = 17
        Me.GSTART.Width = 80
        '
        'GEND
        '
        Me.GEND.AppearanceCell.BackColor = System.Drawing.Color.Linen
        Me.GEND.AppearanceCell.Options.UseBackColor = True
        Me.GEND.Caption = "Closing Kms"
        Me.GEND.DisplayFormat.FormatString = "0"
        Me.GEND.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GEND.FieldName = "ENDKMS"
        Me.GEND.Name = "GEND"
        Me.GEND.Visible = True
        Me.GEND.VisibleIndex = 18
        Me.GEND.Width = 80
        '
        'GTOTALKMS
        '
        Me.GTOTALKMS.AppearanceCell.BackColor = System.Drawing.Color.Linen
        Me.GTOTALKMS.AppearanceCell.Options.UseBackColor = True
        Me.GTOTALKMS.Caption = "Total Kms"
        Me.GTOTALKMS.DisplayFormat.FormatString = "0"
        Me.GTOTALKMS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALKMS.FieldName = "TOTALKMS"
        Me.GTOTALKMS.Name = "GTOTALKMS"
        Me.GTOTALKMS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALKMS.Visible = True
        Me.GTOTALKMS.VisibleIndex = 19
        '
        'GEXTRAKMS
        '
        Me.GEXTRAKMS.AppearanceCell.BackColor = System.Drawing.Color.Linen
        Me.GEXTRAKMS.AppearanceCell.Options.UseBackColor = True
        Me.GEXTRAKMS.Caption = "Extra Kms"
        Me.GEXTRAKMS.DisplayFormat.FormatString = "0"
        Me.GEXTRAKMS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GEXTRAKMS.FieldName = "EXTRAKMS"
        Me.GEXTRAKMS.Name = "GEXTRAKMS"
        Me.GEXTRAKMS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GEXTRAKMS.Visible = True
        Me.GEXTRAKMS.VisibleIndex = 20
        '
        'GSTARTTIME
        '
        Me.GSTARTTIME.AppearanceCell.BackColor = System.Drawing.Color.Linen
        Me.GSTARTTIME.AppearanceCell.Options.UseBackColor = True
        Me.GSTARTTIME.Caption = "Start Time"
        Me.GSTARTTIME.DisplayFormat.FormatString = "0.0"
        Me.GSTARTTIME.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSTARTTIME.FieldName = "STARTTIME"
        Me.GSTARTTIME.Name = "GSTARTTIME"
        Me.GSTARTTIME.Visible = True
        Me.GSTARTTIME.VisibleIndex = 21
        '
        'GENDTIME
        '
        Me.GENDTIME.AppearanceCell.BackColor = System.Drawing.Color.Linen
        Me.GENDTIME.AppearanceCell.Options.UseBackColor = True
        Me.GENDTIME.Caption = "End Time"
        Me.GENDTIME.DisplayFormat.FormatString = "0.0"
        Me.GENDTIME.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GENDTIME.FieldName = "ENDTIME"
        Me.GENDTIME.Name = "GENDTIME"
        Me.GENDTIME.Visible = True
        Me.GENDTIME.VisibleIndex = 22
        '
        'GTOTALTIME
        '
        Me.GTOTALTIME.AppearanceCell.BackColor = System.Drawing.Color.Linen
        Me.GTOTALTIME.AppearanceCell.Options.UseBackColor = True
        Me.GTOTALTIME.Caption = "Total Time"
        Me.GTOTALTIME.DisplayFormat.FormatString = "0.0"
        Me.GTOTALTIME.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALTIME.FieldName = "TOTALTIME"
        Me.GTOTALTIME.Name = "GTOTALTIME"
        Me.GTOTALTIME.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALTIME.Visible = True
        Me.GTOTALTIME.VisibleIndex = 23
        '
        'GEXTRATIME
        '
        Me.GEXTRATIME.AppearanceCell.BackColor = System.Drawing.Color.Linen
        Me.GEXTRATIME.AppearanceCell.Options.UseBackColor = True
        Me.GEXTRATIME.Caption = "Extra Time"
        Me.GEXTRATIME.DisplayFormat.FormatString = "0.0"
        Me.GEXTRATIME.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GEXTRATIME.FieldName = "EXTRATIME"
        Me.GEXTRATIME.Name = "GEXTRATIME"
        Me.GEXTRATIME.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GEXTRATIME.Visible = True
        Me.GEXTRATIME.VisibleIndex = 24
        '
        'GSUBTOTAL
        '
        Me.GSUBTOTAL.AppearanceCell.BackColor = System.Drawing.Color.Linen
        Me.GSUBTOTAL.AppearanceCell.Options.UseBackColor = True
        Me.GSUBTOTAL.Caption = "Sub Total"
        Me.GSUBTOTAL.DisplayFormat.FormatString = "0.00"
        Me.GSUBTOTAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSUBTOTAL.FieldName = "SUBTOTAL"
        Me.GSUBTOTAL.Name = "GSUBTOTAL"
        Me.GSUBTOTAL.Visible = True
        Me.GSUBTOTAL.VisibleIndex = 25
        '
        'GTAXNAME
        '
        Me.GTAXNAME.AppearanceCell.BackColor = System.Drawing.Color.Linen
        Me.GTAXNAME.AppearanceCell.Options.UseBackColor = True
        Me.GTAXNAME.Caption = "Tax Name"
        Me.GTAXNAME.FieldName = "TAXNAME"
        Me.GTAXNAME.Name = "GTAXNAME"
        Me.GTAXNAME.Visible = True
        Me.GTAXNAME.VisibleIndex = 26
        '
        'GTAXAMT
        '
        Me.GTAXAMT.AppearanceCell.BackColor = System.Drawing.Color.Linen
        Me.GTAXAMT.AppearanceCell.Options.UseBackColor = True
        Me.GTAXAMT.Caption = "Tax Amt"
        Me.GTAXAMT.DisplayFormat.FormatString = "0.00"
        Me.GTAXAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTAXAMT.FieldName = "TAXAMT"
        Me.GTAXAMT.Name = "GTAXAMT"
        Me.GTAXAMT.Visible = True
        Me.GTAXAMT.VisibleIndex = 27
        '
        'GOTHERCHGS
        '
        Me.GOTHERCHGS.AppearanceCell.BackColor = System.Drawing.Color.Linen
        Me.GOTHERCHGS.AppearanceCell.Options.UseBackColor = True
        Me.GOTHERCHGS.Caption = "Toll & Parking"
        Me.GOTHERCHGS.DisplayFormat.FormatString = "0.00"
        Me.GOTHERCHGS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GOTHERCHGS.FieldName = "OTHERCHGS"
        Me.GOTHERCHGS.Name = "GOTHERCHGS"
        Me.GOTHERCHGS.Visible = True
        Me.GOTHERCHGS.VisibleIndex = 28
        '
        'gHSNCODE
        '
        Me.gHSNCODE.Caption = "HSN Code"
        Me.gHSNCODE.FieldName = "HSNCODE"
        Me.gHSNCODE.Name = "gHSNCODE"
        Me.gHSNCODE.Visible = True
        Me.gHSNCODE.VisibleIndex = 29
        '
        'GTAXSERVCHGSAMT
        '
        Me.GTAXSERVCHGSAMT.Caption = "Serv. Chgs."
        Me.GTAXSERVCHGSAMT.FieldName = "TAXSERVCHGSAMT"
        Me.GTAXSERVCHGSAMT.Name = "GTAXSERVCHGSAMT"
        Me.GTAXSERVCHGSAMT.Visible = True
        Me.GTAXSERVCHGSAMT.VisibleIndex = 30
        '
        'GCGSTPER
        '
        Me.GCGSTPER.Caption = "CGST %"
        Me.GCGSTPER.FieldName = "CGSTPER"
        Me.GCGSTPER.Name = "GCGSTPER"
        Me.GCGSTPER.Visible = True
        Me.GCGSTPER.VisibleIndex = 31
        '
        'gCGSTAMT
        '
        Me.gCGSTAMT.Caption = "CGST Amt."
        Me.gCGSTAMT.FieldName = "CGSTAMT"
        Me.gCGSTAMT.Name = "gCGSTAMT"
        Me.gCGSTAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.gCGSTAMT.Visible = True
        Me.gCGSTAMT.VisibleIndex = 32
        '
        'gSGSTPER
        '
        Me.gSGSTPER.Caption = "SGST %"
        Me.gSGSTPER.FieldName = "SGSTPER"
        Me.gSGSTPER.Name = "gSGSTPER"
        Me.gSGSTPER.Visible = True
        Me.gSGSTPER.VisibleIndex = 33
        '
        'gSGSTAMT
        '
        Me.gSGSTAMT.Caption = "SGST Amt."
        Me.gSGSTAMT.FieldName = "SGSTAMT"
        Me.gSGSTAMT.Name = "gSGSTAMT"
        Me.gSGSTAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.gSGSTAMT.Visible = True
        Me.gSGSTAMT.VisibleIndex = 34
        '
        'gIGSTPER
        '
        Me.gIGSTPER.Caption = "IGST %"
        Me.gIGSTPER.FieldName = "IGSTPER"
        Me.gIGSTPER.Name = "gIGSTPER"
        Me.gIGSTPER.Visible = True
        Me.gIGSTPER.VisibleIndex = 35
        '
        'gIGSTAMT
        '
        Me.gIGSTAMT.Caption = "IGST Amt."
        Me.gIGSTAMT.FieldName = "IGSTAMT"
        Me.gIGSTAMT.Name = "gIGSTAMT"
        Me.gIGSTAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.gIGSTAMT.Visible = True
        Me.gIGSTAMT.VisibleIndex = 36
        '
        'gtotalsale
        '
        Me.gtotalsale.AppearanceCell.BackColor = System.Drawing.Color.Linen
        Me.gtotalsale.AppearanceCell.Options.UseBackColor = True
        Me.gtotalsale.Caption = "G. Total"
        Me.gtotalsale.DisplayFormat.FormatString = "0.00"
        Me.gtotalsale.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.gtotalsale.FieldName = "GRANDTOTAL"
        Me.gtotalsale.Name = "gtotalsale"
        Me.gtotalsale.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.gtotalsale.Visible = True
        Me.gtotalsale.VisibleIndex = 37
        '
        'GBALANCE
        '
        Me.GBALANCE.AppearanceCell.BackColor = System.Drawing.Color.Linen
        Me.GBALANCE.AppearanceCell.Options.UseBackColor = True
        Me.GBALANCE.Caption = "Balance"
        Me.GBALANCE.DisplayFormat.FormatString = "0.00"
        Me.GBALANCE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GBALANCE.FieldName = "BALANCE"
        Me.GBALANCE.Name = "GBALANCE"
        Me.GBALANCE.Visible = True
        Me.GBALANCE.VisibleIndex = 38
        '
        'GPURSTART
        '
        Me.GPURSTART.AppearanceCell.BackColor = System.Drawing.Color.LightBlue
        Me.GPURSTART.AppearanceCell.Options.UseBackColor = True
        Me.GPURSTART.Caption = "Pur Op Kms"
        Me.GPURSTART.DisplayFormat.FormatString = "0"
        Me.GPURSTART.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPURSTART.FieldName = "PURSTARTKMS"
        Me.GPURSTART.Name = "GPURSTART"
        Me.GPURSTART.Visible = True
        Me.GPURSTART.VisibleIndex = 39
        Me.GPURSTART.Width = 90
        '
        'GPUREND
        '
        Me.GPUREND.AppearanceCell.BackColor = System.Drawing.Color.LightBlue
        Me.GPUREND.AppearanceCell.Options.UseBackColor = True
        Me.GPUREND.Caption = "Pur Clo Kms"
        Me.GPUREND.DisplayFormat.FormatString = "0"
        Me.GPUREND.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPUREND.FieldName = "PURENDKMS"
        Me.GPUREND.Name = "GPUREND"
        Me.GPUREND.Visible = True
        Me.GPUREND.VisibleIndex = 40
        Me.GPUREND.Width = 90
        '
        'GPURTOTALKMS
        '
        Me.GPURTOTALKMS.AppearanceCell.BackColor = System.Drawing.Color.LightBlue
        Me.GPURTOTALKMS.AppearanceCell.Options.UseBackColor = True
        Me.GPURTOTALKMS.Caption = "Pur Total Kms"
        Me.GPURTOTALKMS.DisplayFormat.FormatString = "0"
        Me.GPURTOTALKMS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPURTOTALKMS.FieldName = "PURTOTALKMS"
        Me.GPURTOTALKMS.Name = "GPURTOTALKMS"
        Me.GPURTOTALKMS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPURTOTALKMS.Visible = True
        Me.GPURTOTALKMS.VisibleIndex = 41
        '
        'GPUREXTRAKMS
        '
        Me.GPUREXTRAKMS.AppearanceCell.BackColor = System.Drawing.Color.LightBlue
        Me.GPUREXTRAKMS.AppearanceCell.Options.UseBackColor = True
        Me.GPUREXTRAKMS.Caption = "Pur Extra Kms"
        Me.GPUREXTRAKMS.DisplayFormat.FormatString = "0"
        Me.GPUREXTRAKMS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPUREXTRAKMS.FieldName = "PUREXTRAKMS"
        Me.GPUREXTRAKMS.Name = "GPUREXTRAKMS"
        Me.GPUREXTRAKMS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPUREXTRAKMS.Visible = True
        Me.GPUREXTRAKMS.VisibleIndex = 42
        '
        'GPURSTARTTIME
        '
        Me.GPURSTARTTIME.AppearanceCell.BackColor = System.Drawing.Color.LightBlue
        Me.GPURSTARTTIME.AppearanceCell.Options.UseBackColor = True
        Me.GPURSTARTTIME.Caption = "Pur Start Time"
        Me.GPURSTARTTIME.DisplayFormat.FormatString = "0.0"
        Me.GPURSTARTTIME.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPURSTARTTIME.FieldName = "PURSTARTTIME"
        Me.GPURSTARTTIME.Name = "GPURSTARTTIME"
        Me.GPURSTARTTIME.Visible = True
        Me.GPURSTARTTIME.VisibleIndex = 43
        '
        'GPURENDTIME
        '
        Me.GPURENDTIME.AppearanceCell.BackColor = System.Drawing.Color.LightBlue
        Me.GPURENDTIME.AppearanceCell.Options.UseBackColor = True
        Me.GPURENDTIME.Caption = "Pur End Time"
        Me.GPURENDTIME.DisplayFormat.FormatString = "0.0"
        Me.GPURENDTIME.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPURENDTIME.FieldName = "PURENDTIME"
        Me.GPURENDTIME.Name = "GPURENDTIME"
        Me.GPURENDTIME.Visible = True
        Me.GPURENDTIME.VisibleIndex = 44
        '
        'GPURTOTALTIME
        '
        Me.GPURTOTALTIME.AppearanceCell.BackColor = System.Drawing.Color.LightBlue
        Me.GPURTOTALTIME.AppearanceCell.Options.UseBackColor = True
        Me.GPURTOTALTIME.Caption = "Pur Total Time"
        Me.GPURTOTALTIME.DisplayFormat.FormatString = "0.0"
        Me.GPURTOTALTIME.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPURTOTALTIME.FieldName = "PURTOTALTIME"
        Me.GPURTOTALTIME.Name = "GPURTOTALTIME"
        Me.GPURTOTALTIME.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPURTOTALTIME.Visible = True
        Me.GPURTOTALTIME.VisibleIndex = 45
        '
        'GPUREXTRATIME
        '
        Me.GPUREXTRATIME.AppearanceCell.BackColor = System.Drawing.Color.LightBlue
        Me.GPUREXTRATIME.AppearanceCell.Options.UseBackColor = True
        Me.GPUREXTRATIME.Caption = "Pur Extra Time"
        Me.GPUREXTRATIME.DisplayFormat.FormatString = "0.0"
        Me.GPUREXTRATIME.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPUREXTRATIME.FieldName = "PUREXTRATIME"
        Me.GPUREXTRATIME.Name = "GPUREXTRATIME"
        Me.GPUREXTRATIME.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPUREXTRATIME.Visible = True
        Me.GPUREXTRATIME.VisibleIndex = 46
        '
        'GPURSUBTOTAL
        '
        Me.GPURSUBTOTAL.AppearanceCell.BackColor = System.Drawing.Color.LightBlue
        Me.GPURSUBTOTAL.AppearanceCell.Options.UseBackColor = True
        Me.GPURSUBTOTAL.Caption = "Pur Sub Total"
        Me.GPURSUBTOTAL.DisplayFormat.FormatString = "0.00"
        Me.GPURSUBTOTAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPURSUBTOTAL.FieldName = "PURSUBTOTAL"
        Me.GPURSUBTOTAL.Name = "GPURSUBTOTAL"
        Me.GPURSUBTOTAL.Visible = True
        Me.GPURSUBTOTAL.VisibleIndex = 47
        Me.GPURSUBTOTAL.Width = 85
        '
        'GPURTAXNAME
        '
        Me.GPURTAXNAME.AppearanceCell.BackColor = System.Drawing.Color.LightBlue
        Me.GPURTAXNAME.AppearanceCell.Options.UseBackColor = True
        Me.GPURTAXNAME.Caption = "Pur Tax Name"
        Me.GPURTAXNAME.FieldName = "PURTAXNAME"
        Me.GPURTAXNAME.Name = "GPURTAXNAME"
        Me.GPURTAXNAME.Visible = True
        Me.GPURTAXNAME.VisibleIndex = 48
        Me.GPURTAXNAME.Width = 90
        '
        'GPURTAXAMT
        '
        Me.GPURTAXAMT.AppearanceCell.BackColor = System.Drawing.Color.LightBlue
        Me.GPURTAXAMT.AppearanceCell.Options.UseBackColor = True
        Me.GPURTAXAMT.Caption = "Pur Tax"
        Me.GPURTAXAMT.DisplayFormat.FormatString = "0.00"
        Me.GPURTAXAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPURTAXAMT.FieldName = "PURTAXAMT"
        Me.GPURTAXAMT.Name = "GPURTAXAMT"
        Me.GPURTAXAMT.Visible = True
        Me.GPURTAXAMT.VisibleIndex = 49
        '
        'GPUROTHERCHGS
        '
        Me.GPUROTHERCHGS.AppearanceCell.BackColor = System.Drawing.Color.LightBlue
        Me.GPUROTHERCHGS.AppearanceCell.Options.UseBackColor = True
        Me.GPUROTHERCHGS.Caption = "Pur Toll & Parking"
        Me.GPUROTHERCHGS.FieldName = "PUROTHERCHGS"
        Me.GPUROTHERCHGS.Name = "GPUROTHERCHGS"
        Me.GPUROTHERCHGS.Visible = True
        Me.GPUROTHERCHGS.VisibleIndex = 50
        '
        'gtotalpurchase
        '
        Me.gtotalpurchase.AppearanceCell.BackColor = System.Drawing.Color.LightBlue
        Me.gtotalpurchase.AppearanceCell.Options.UseBackColor = True
        Me.gtotalpurchase.Caption = "Purchase Amt"
        Me.gtotalpurchase.FieldName = "PURTOTAL"
        Me.gtotalpurchase.Name = "gtotalpurchase"
        Me.gtotalpurchase.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.gtotalpurchase.Visible = True
        Me.gtotalpurchase.VisibleIndex = 51
        Me.gtotalpurchase.Width = 90
        '
        'GUSERNAME
        '
        Me.GUSERNAME.Caption = "User Name"
        Me.GUSERNAME.FieldName = "USERNAME"
        Me.GUSERNAME.Name = "GUSERNAME"
        Me.GUSERNAME.Visible = True
        Me.GUSERNAME.VisibleIndex = 52
        Me.GUSERNAME.Width = 90
        '
        'GRETURN
        '
        Me.GRETURN.Caption = "Cancelled"
        Me.GRETURN.DisplayFormat.FormatString = "0.00"
        Me.GRETURN.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GRETURN.FieldName = "RETURN"
        Me.GRETURN.Name = "GRETURN"
        '
        'GDISPUTE
        '
        Me.GDISPUTE.Caption = "Disputed"
        Me.GDISPUTE.FieldName = "DISPUTED"
        Me.GDISPUTE.Name = "GDISPUTE"
        Me.GDISPUTE.Visible = True
        Me.GDISPUTE.VisibleIndex = 53
        '
        'GBILLCHECKED
        '
        Me.GBILLCHECKED.Caption = "Bill Checked"
        Me.GBILLCHECKED.FieldName = "BILLCHECKED"
        Me.GBILLCHECKED.Name = "GBILLCHECKED"
        Me.GBILLCHECKED.Visible = True
        Me.GBILLCHECKED.VisibleIndex = 54
        '
        'GIRNNO
        '
        Me.GIRNNO.Caption = "Irnno"
        Me.GIRNNO.FieldName = "IRNNO"
        Me.GIRNNO.Name = "GIRNNO"
        Me.GIRNNO.Visible = True
        Me.GIRNNO.VisibleIndex = 55
        '
        'GACKNO
        '
        Me.GACKNO.Caption = "Ackno"
        Me.GACKNO.FieldName = "ACKNO"
        Me.GACKNO.Name = "GACKNO"
        Me.GACKNO.Visible = True
        Me.GACKNO.VisibleIndex = 56
        '
        'GACKDATE
        '
        Me.GACKDATE.Caption = "Ackdate"
        Me.GACKDATE.FieldName = "ACKDATE"
        Me.GACKDATE.Name = "GACKDATE"
        Me.GACKDATE.Visible = True
        Me.GACKDATE.VisibleIndex = 57
        '
        'GQRCODE
        '
        Me.GQRCODE.Caption = "Qrcode"
        Me.GQRCODE.FieldName = "QRCODE"
        Me.GQRCODE.Name = "GQRCODE"
        Me.GQRCODE.Visible = True
        Me.GQRCODE.VisibleIndex = 58
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
        Me.lbl.Location = New System.Drawing.Point(21, 41)
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
        Me.GGROUPDEPARTURE.VisibleIndex = 59
        '
        'CarBookingDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 562)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "CarBookingDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Car Booking Details"
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
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CMDOK As System.Windows.Forms.Button
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GINITIALS As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gsrno As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREFNO As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gdate As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gaccname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFROM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gtotalpurchase As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gtotalsale As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GUSERNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRETURN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBILLCHECKED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDISPUTE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBALANCE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExcelExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents LBLTO As System.Windows.Forms.Label
    Friend WithEvents LBLFROM As System.Windows.Forms.Label
    Friend WithEvents TXTTO As System.Windows.Forms.TextBox
    Friend WithEvents TXTFROM As System.Windows.Forms.TextBox
    Friend WithEvents PRINTTOOL As System.Windows.Forms.ToolStripButton
    Friend WithEvents GPURSUBTOTAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURTAXNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURTAXAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSUBTOTAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTAXNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTAXAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCONFIRMEDBY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTART As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GEND As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURSTART As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPUREND As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCARNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GVEHICLE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALKMS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GEXTRAKMS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTARTTIME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GENDTIME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALTIME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GEXTRATIME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURTOTALKMS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPUREXTRAKMS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURSTARTTIME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURENDTIME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURTOTALTIME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPUREXTRATIME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDRIVERNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOTHERCHGS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBOOKINGTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPUROTHERCHGS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDAYS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNIGHTS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGSTIN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gHSNCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTAXSERVCHGSAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCGSTPER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gCGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gSGSTPER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gSGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gIGSTPER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gIGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TOOLMAIL As ToolStripButton
    Friend WithEvents Label11 As Label
    Friend WithEvents TXTCOPIES As TextBox
    Friend WithEvents PRINTDIALOG As PrintDialog
    Friend WithEvents PRINTDOC As Printing.PrintDocument
    Friend WithEvents TOOLGRIDDETAILS As ToolStripButton
    Friend WithEvents GIRNNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GACKNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GACKDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GQRCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TOOLREFRESH As ToolStripButton
    Friend WithEvents GGROUPDEPARTURE As DevExpress.XtraGrid.Columns.GridColumn
End Class
