<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CarBookingInvoiceDetailsGridReport
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
        Me.cmdcancel = New System.Windows.Forms.Button
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GINITIALS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gsrno = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GFROMDATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCARNO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GVEHICLE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCONFIRMEDBY = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gaccname = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gname = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GSUBTOTAL = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTAXNAME = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTAXAMT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GOTHERCHGS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gtotalsale = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ExcelExport = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.GSPECIALREMARKS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1134, 562)
        Me.BlendPanel1.TabIndex = 5
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.Color.Transparent
        Me.cmdcancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdcancel.FlatAppearance.BorderSize = 0
        Me.cmdcancel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.Black
        Me.cmdcancel.Location = New System.Drawing.Point(527, 533)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(80, 28)
        Me.cmdcancel.TabIndex = 316
        Me.cmdcancel.Text = "E&xit"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(14, 32)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1107, 487)
        Me.gridbilldetails.TabIndex = 314
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GINITIALS, Me.gsrno, Me.GFROMDATE, Me.GCARNO, Me.GVEHICLE, Me.GCONFIRMEDBY, Me.gaccname, Me.gname, Me.GSUBTOTAL, Me.GTAXNAME, Me.GTAXAMT, Me.GOTHERCHGS, Me.gtotalsale, Me.GDATE, Me.GSPECIALREMARKS})
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
        'GINITIALS
        '
        Me.GINITIALS.Caption = "Invoice No"
        Me.GINITIALS.FieldName = "BILLINITIALS"
        Me.GINITIALS.Name = "GINITIALS"
        Me.GINITIALS.Visible = True
        Me.GINITIALS.VisibleIndex = 0
        '
        'gsrno
        '
        Me.gsrno.Caption = "Booking No"
        Me.gsrno.FieldName = "BOOKINGNO"
        Me.gsrno.ImageIndex = 1
        Me.gsrno.Name = "gsrno"
        '
        'GFROMDATE
        '
        Me.GFROMDATE.Caption = "Form Date"
        Me.GFROMDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GFROMDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GFROMDATE.FieldName = "FROMDATE"
        Me.GFROMDATE.Name = "GFROMDATE"
        Me.GFROMDATE.Visible = True
        Me.GFROMDATE.VisibleIndex = 1
        Me.GFROMDATE.Width = 80
        '
        'GCARNO
        '
        Me.GCARNO.Caption = "Car No"
        Me.GCARNO.FieldName = "VEHICLENO"
        Me.GCARNO.Name = "GCARNO"
        Me.GCARNO.Visible = True
        Me.GCARNO.VisibleIndex = 2
        '
        'GVEHICLE
        '
        Me.GVEHICLE.Caption = "Car Type"
        Me.GVEHICLE.FieldName = "VEHICLENAME"
        Me.GVEHICLE.Name = "GVEHICLE"
        Me.GVEHICLE.Visible = True
        Me.GVEHICLE.VisibleIndex = 3
        Me.GVEHICLE.Width = 100
        '
        'GCONFIRMEDBY
        '
        Me.GCONFIRMEDBY.Caption = "Confirmed By"
        Me.GCONFIRMEDBY.FieldName = "CONFIRMEDBY"
        Me.GCONFIRMEDBY.Name = "GCONFIRMEDBY"
        Me.GCONFIRMEDBY.Visible = True
        Me.GCONFIRMEDBY.VisibleIndex = 4
        Me.GCONFIRMEDBY.Width = 120
        '
        'gaccname
        '
        Me.gaccname.Caption = "Account Name"
        Me.gaccname.FieldName = "ACCNAME"
        Me.gaccname.Name = "gaccname"
        Me.gaccname.Visible = True
        Me.gaccname.VisibleIndex = 5
        Me.gaccname.Width = 200
        '
        'gname
        '
        Me.gname.Caption = "Guest Name"
        Me.gname.FieldName = "GUESTNAME"
        Me.gname.ImageIndex = 0
        Me.gname.Name = "gname"
        Me.gname.Visible = True
        Me.gname.VisibleIndex = 6
        Me.gname.Width = 200
        '
        'GSUBTOTAL
        '
        Me.GSUBTOTAL.Caption = "Sub Total"
        Me.GSUBTOTAL.DisplayFormat.FormatString = "0.00"
        Me.GSUBTOTAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSUBTOTAL.FieldName = "SUBTOTAL"
        Me.GSUBTOTAL.Name = "GSUBTOTAL"
        Me.GSUBTOTAL.Visible = True
        Me.GSUBTOTAL.VisibleIndex = 7
        Me.GSUBTOTAL.Width = 80
        '
        'GTAXNAME
        '
        Me.GTAXNAME.Caption = "Tax Name"
        Me.GTAXNAME.FieldName = "TAXNAME"
        Me.GTAXNAME.Name = "GTAXNAME"
        Me.GTAXNAME.Visible = True
        Me.GTAXNAME.VisibleIndex = 8
        Me.GTAXNAME.Width = 80
        '
        'GTAXAMT
        '
        Me.GTAXAMT.Caption = "Tax Amt"
        Me.GTAXAMT.DisplayFormat.FormatString = "0.00"
        Me.GTAXAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTAXAMT.FieldName = "TAXAMT"
        Me.GTAXAMT.Name = "GTAXAMT"
        Me.GTAXAMT.Visible = True
        Me.GTAXAMT.VisibleIndex = 9
        Me.GTAXAMT.Width = 80
        '
        'GOTHERCHGS
        '
        Me.GOTHERCHGS.Caption = "Toll & Parking"
        Me.GOTHERCHGS.DisplayFormat.FormatString = "0.00"
        Me.GOTHERCHGS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GOTHERCHGS.FieldName = "OTHERCHGS"
        Me.GOTHERCHGS.Name = "GOTHERCHGS"
        Me.GOTHERCHGS.Visible = True
        Me.GOTHERCHGS.VisibleIndex = 10
        Me.GOTHERCHGS.Width = 100
        '
        'gtotalsale
        '
        Me.gtotalsale.Caption = "G. Total"
        Me.gtotalsale.DisplayFormat.FormatString = "0.00"
        Me.gtotalsale.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.gtotalsale.FieldName = "GRANDTOTAL"
        Me.gtotalsale.Name = "gtotalsale"
        Me.gtotalsale.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.gtotalsale.Visible = True
        Me.gtotalsale.VisibleIndex = 11
        Me.gtotalsale.Width = 80
        '
        'GDATE
        '
        Me.GDATE.Caption = "Bill Date"
        Me.GDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDATE.FieldName = "BOOKINGDATE"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.Visible = True
        Me.GDATE.VisibleIndex = 12
        Me.GDATE.Width = 80
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExcelExport, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1134, 25)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
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
        'GSPECIALREMARKS
        '
        Me.GSPECIALREMARKS.Caption = "IO No"
        Me.GSPECIALREMARKS.FieldName = "SPECIALREMARKS"
        Me.GSPECIALREMARKS.Name = "GSPECIALREMARKS"
        Me.GSPECIALREMARKS.Visible = True
        Me.GSPECIALREMARKS.VisibleIndex = 13
        Me.GSPECIALREMARKS.Width = 200
        '
        'CarBookingInvoiceDetailsGridReport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1134, 562)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "CarBookingInvoiceDetailsGridReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Car Booking Invoice Details"
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
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GINITIALS As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gsrno As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GFROMDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCARNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GVEHICLE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCONFIRMEDBY As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gaccname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSUBTOTAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTAXNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTAXAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gtotalsale As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ExcelExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GOTHERCHGS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSPECIALREMARKS As DevExpress.XtraGrid.Columns.GridColumn
End Class
