<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SaleTDSReport
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
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.RDSUMMARY = New System.Windows.Forms.RadioButton
        Me.RDDETAILS = New System.Windows.Forms.RadioButton
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ExcelExport = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GBILL = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GBOOKINGNO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GBOOKINGDATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GGUESTNAME = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GFLIGHT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTOTAL = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCOMMPER = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCOMMRS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTDSPER = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTDSRS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GBILLAMT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTYPE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.cmdshowdetails = New System.Windows.Forms.Button
        Me.chkdate = New System.Windows.Forms.CheckBox
        Me.dtto = New System.Windows.Forms.DateTimePicker
        Me.lblto = New System.Windows.Forms.Label
        Me.dtfrom = New System.Windows.Forms.DateTimePicker
        Me.lblfrom = New System.Windows.Forms.Label
        Me.cmdcancel = New System.Windows.Forms.Button
        Me.BlendPanel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.RDSUMMARY)
        Me.BlendPanel1.Controls.Add(Me.RDDETAILS)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.cmdshowdetails)
        Me.BlendPanel1.Controls.Add(Me.chkdate)
        Me.BlendPanel1.Controls.Add(Me.dtto)
        Me.BlendPanel1.Controls.Add(Me.lblto)
        Me.BlendPanel1.Controls.Add(Me.dtfrom)
        Me.BlendPanel1.Controls.Add(Me.lblfrom)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1184, 582)
        Me.BlendPanel1.TabIndex = 7
        '
        'RDSUMMARY
        '
        Me.RDSUMMARY.AutoSize = True
        Me.RDSUMMARY.BackColor = System.Drawing.Color.Transparent
        Me.RDSUMMARY.Checked = True
        Me.RDSUMMARY.Location = New System.Drawing.Point(12, 60)
        Me.RDSUMMARY.Name = "RDSUMMARY"
        Me.RDSUMMARY.Size = New System.Drawing.Size(76, 19)
        Me.RDSUMMARY.TabIndex = 513
        Me.RDSUMMARY.TabStop = True
        Me.RDSUMMARY.Text = "Summary"
        Me.RDSUMMARY.UseVisualStyleBackColor = False
        '
        'RDDETAILS
        '
        Me.RDDETAILS.AutoSize = True
        Me.RDDETAILS.BackColor = System.Drawing.Color.Transparent
        Me.RDDETAILS.Location = New System.Drawing.Point(92, 60)
        Me.RDDETAILS.Name = "RDDETAILS"
        Me.RDDETAILS.Size = New System.Drawing.Size(64, 19)
        Me.RDDETAILS.TabIndex = 512
        Me.RDDETAILS.Text = "Details"
        Me.RDDETAILS.UseVisualStyleBackColor = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExcelExport, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1184, 25)
        Me.ToolStrip1.TabIndex = 511
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
        Me.gridbilldetails.Location = New System.Drawing.Point(10, 84)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1165, 460)
        Me.gridbilldetails.TabIndex = 494
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GBILL, Me.GBOOKINGNO, Me.GBOOKINGDATE, Me.GGUESTNAME, Me.GFLIGHT, Me.GNAME, Me.GTOTAL, Me.GCOMMPER, Me.GCOMMRS, Me.GTDSPER, Me.GTDSRS, Me.GBILLAMT, Me.GTYPE})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        '
        'GBILL
        '
        Me.GBILL.Caption = "BILL"
        Me.GBILL.FieldName = "BOOKINGNO"
        Me.GBILL.Name = "GBILL"
        '
        'GBOOKINGNO
        '
        Me.GBOOKINGNO.Caption = "Booking No"
        Me.GBOOKINGNO.FieldName = "BILLINITIALS"
        Me.GBOOKINGNO.Name = "GBOOKINGNO"
        Me.GBOOKINGNO.Visible = True
        Me.GBOOKINGNO.VisibleIndex = 0
        Me.GBOOKINGNO.Width = 80
        '
        'GBOOKINGDATE
        '
        Me.GBOOKINGDATE.Caption = "Date"
        Me.GBOOKINGDATE.FieldName = "DATE"
        Me.GBOOKINGDATE.Name = "GBOOKINGDATE"
        Me.GBOOKINGDATE.Visible = True
        Me.GBOOKINGDATE.VisibleIndex = 1
        Me.GBOOKINGDATE.Width = 80
        '
        'GGUESTNAME
        '
        Me.GGUESTNAME.Caption = "Guest Name"
        Me.GGUESTNAME.FieldName = "GUESTNAME"
        Me.GGUESTNAME.ImageIndex = 0
        Me.GGUESTNAME.Name = "GGUESTNAME"
        Me.GGUESTNAME.Visible = True
        Me.GGUESTNAME.VisibleIndex = 2
        Me.GGUESTNAME.Width = 190
        '
        'GFLIGHT
        '
        Me.GFLIGHT.Caption = "Airline Name"
        Me.GFLIGHT.FieldName = "FLIGHTNAME"
        Me.GFLIGHT.ImageIndex = 1
        Me.GFLIGHT.Name = "GFLIGHT"
        Me.GFLIGHT.Visible = True
        Me.GFLIGHT.VisibleIndex = 3
        Me.GFLIGHT.Width = 200
        '
        'GNAME
        '
        Me.GNAME.Caption = "Account Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 4
        Me.GNAME.Width = 210
        '
        'GTOTAL
        '
        Me.GTOTAL.Caption = "Total Amt"
        Me.GTOTAL.DisplayFormat.FormatString = "0.00"
        Me.GTOTAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTAL.FieldName = "TOTALSALE"
        Me.GTOTAL.Name = "GTOTAL"
        Me.GTOTAL.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GTOTAL.Visible = True
        Me.GTOTAL.VisibleIndex = 5
        Me.GTOTAL.Width = 90
        '
        'GCOMMPER
        '
        Me.GCOMMPER.Caption = "Comm Per"
        Me.GCOMMPER.DisplayFormat.FormatString = "0.00"
        Me.GCOMMPER.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCOMMPER.FieldName = "COMMPER"
        Me.GCOMMPER.Name = "GCOMMPER"
        Me.GCOMMPER.Width = 90
        '
        'GCOMMRS
        '
        Me.GCOMMRS.Caption = "Comm"
        Me.GCOMMRS.DisplayFormat.FormatString = "0.00"
        Me.GCOMMRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCOMMRS.FieldName = "COMMRS"
        Me.GCOMMRS.Name = "GCOMMRS"
        Me.GCOMMRS.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GCOMMRS.Visible = True
        Me.GCOMMRS.VisibleIndex = 6
        Me.GCOMMRS.Width = 90
        '
        'GTDSPER
        '
        Me.GTDSPER.Caption = "TDS Per"
        Me.GTDSPER.DisplayFormat.FormatString = "0.00"
        Me.GTDSPER.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTDSPER.FieldName = "TDSPER"
        Me.GTDSPER.Name = "GTDSPER"
        Me.GTDSPER.Width = 90
        '
        'GTDSRS
        '
        Me.GTDSRS.Caption = "TDS"
        Me.GTDSRS.DisplayFormat.FormatString = "0.00"
        Me.GTDSRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTDSRS.FieldName = "TDSRS"
        Me.GTDSRS.Name = "GTDSRS"
        Me.GTDSRS.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GTDSRS.Visible = True
        Me.GTDSRS.VisibleIndex = 7
        Me.GTDSRS.Width = 90
        '
        'GBILLAMT
        '
        Me.GBILLAMT.Caption = "Bill Amount"
        Me.GBILLAMT.FieldName = "GRANDTOTAL"
        Me.GBILLAMT.Name = "GBILLAMT"
        Me.GBILLAMT.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GBILLAMT.Visible = True
        Me.GBILLAMT.VisibleIndex = 8
        Me.GBILLAMT.Width = 90
        '
        'GTYPE
        '
        Me.GTYPE.Caption = "TYPE"
        Me.GTYPE.FieldName = "TYPE"
        Me.GTYPE.Name = "GTYPE"
        '
        'cmdshowdetails
        '
        Me.cmdshowdetails.BackColor = System.Drawing.Color.Transparent
        Me.cmdshowdetails.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdshowdetails.FlatAppearance.BorderSize = 0
        Me.cmdshowdetails.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdshowdetails.ForeColor = System.Drawing.Color.Black
        Me.cmdshowdetails.Location = New System.Drawing.Point(353, 52)
        Me.cmdshowdetails.Name = "cmdshowdetails"
        Me.cmdshowdetails.Size = New System.Drawing.Size(88, 28)
        Me.cmdshowdetails.TabIndex = 499
        Me.cmdshowdetails.Text = "&Show Details"
        Me.cmdshowdetails.UseVisualStyleBackColor = False
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.Location = New System.Drawing.Point(169, 32)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(52, 18)
        Me.chkdate.TabIndex = 495
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'dtto
        '
        Me.dtto.CustomFormat = "dd/MM/yyyy"
        Me.dtto.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(260, 56)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(87, 22)
        Me.dtto.TabIndex = 498
        '
        'lblto
        '
        Me.lblto.AutoSize = True
        Me.lblto.BackColor = System.Drawing.Color.Transparent
        Me.lblto.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblto.Location = New System.Drawing.Point(236, 59)
        Me.lblto.Name = "lblto"
        Me.lblto.Size = New System.Drawing.Size(19, 14)
        Me.lblto.TabIndex = 500
        Me.lblto.Text = "To"
        '
        'dtfrom
        '
        Me.dtfrom.CustomFormat = "dd/MM/yyyy"
        Me.dtfrom.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfrom.Location = New System.Drawing.Point(259, 30)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(88, 22)
        Me.dtfrom.TabIndex = 497
        '
        'lblfrom
        '
        Me.lblfrom.AutoSize = True
        Me.lblfrom.BackColor = System.Drawing.Color.Transparent
        Me.lblfrom.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfrom.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblfrom.Location = New System.Drawing.Point(221, 33)
        Me.lblfrom.Name = "lblfrom"
        Me.lblfrom.Size = New System.Drawing.Size(34, 14)
        Me.lblfrom.TabIndex = 496
        Me.lblfrom.Text = "From"
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.Color.Transparent
        Me.cmdcancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdcancel.FlatAppearance.BorderSize = 0
        Me.cmdcancel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.Black
        Me.cmdcancel.Location = New System.Drawing.Point(552, 548)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(80, 28)
        Me.cmdcancel.TabIndex = 316
        Me.cmdcancel.Text = "E&xit"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'SaleTDSReport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1184, 582)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "SaleTDSReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Sale TDS Report"
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
    Friend WithEvents RDSUMMARY As System.Windows.Forms.RadioButton
    Friend WithEvents RDDETAILS As System.Windows.Forms.RadioButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ExcelExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GBILL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBOOKINGNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBOOKINGDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGUESTNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFLIGHT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCOMMPER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCOMMRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTDSPER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTDSRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBILLAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdshowdetails As System.Windows.Forms.Button
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblto As System.Windows.Forms.Label
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblfrom As System.Windows.Forms.Label
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
End Class
