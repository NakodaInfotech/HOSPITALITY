<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PackageQuotationGridReport
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
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gsrno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gdate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gaccname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOURNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPACKAGEFROM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPACKAGETO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gtotalpax = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gtotalsale = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOURCOMM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREMARKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GQUOTE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDONE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREFNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GUSERNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAMENDED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCMPNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ExcelExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TOOLREFRESH = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 6
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(14, 33)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1207, 512)
        Me.gridbilldetails.TabIndex = 493
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gsrno, Me.gdate, Me.gaccname, Me.GTOURNAME, Me.GPACKAGEFROM, Me.GPACKAGETO, Me.gtotalpax, Me.gtotalsale, Me.GOURCOMM, Me.GREMARKS, Me.GQUOTE, Me.GDONE, Me.GREFNO, Me.GUSERNAME, Me.GAMENDED, Me.GCMPNAME})
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
        'gsrno
        '
        Me.gsrno.Caption = "Enquiry No"
        Me.gsrno.FieldName = "ENQNO"
        Me.gsrno.Name = "gsrno"
        Me.gsrno.Visible = True
        Me.gsrno.VisibleIndex = 0
        '
        'gdate
        '
        Me.gdate.Caption = "Date"
        Me.gdate.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.gdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.gdate.FieldName = "ENQDATE"
        Me.gdate.Name = "gdate"
        Me.gdate.Visible = True
        Me.gdate.VisibleIndex = 1
        Me.gdate.Width = 70
        '
        'gaccname
        '
        Me.gaccname.Caption = "Guest Name"
        Me.gaccname.FieldName = "GUESTNAME"
        Me.gaccname.ImageIndex = 0
        Me.gaccname.Name = "gaccname"
        Me.gaccname.Visible = True
        Me.gaccname.VisibleIndex = 2
        Me.gaccname.Width = 230
        '
        'GTOURNAME
        '
        Me.GTOURNAME.Caption = "Tour Name"
        Me.GTOURNAME.FieldName = "TOURNAME"
        Me.GTOURNAME.Name = "GTOURNAME"
        Me.GTOURNAME.Visible = True
        Me.GTOURNAME.VisibleIndex = 3
        Me.GTOURNAME.Width = 160
        '
        'GPACKAGEFROM
        '
        Me.GPACKAGEFROM.Caption = "From"
        Me.GPACKAGEFROM.FieldName = "PACKAGEFROM"
        Me.GPACKAGEFROM.Name = "GPACKAGEFROM"
        Me.GPACKAGEFROM.Visible = True
        Me.GPACKAGEFROM.VisibleIndex = 4
        '
        'GPACKAGETO
        '
        Me.GPACKAGETO.Caption = "To"
        Me.GPACKAGETO.FieldName = "PACKAGETO"
        Me.GPACKAGETO.Name = "GPACKAGETO"
        Me.GPACKAGETO.Visible = True
        Me.GPACKAGETO.VisibleIndex = 5
        '
        'gtotalpax
        '
        Me.gtotalpax.Caption = "Total Pax"
        Me.gtotalpax.FieldName = "TOTALPAX"
        Me.gtotalpax.Name = "gtotalpax"
        Me.gtotalpax.Visible = True
        Me.gtotalpax.VisibleIndex = 6
        '
        'gtotalsale
        '
        Me.gtotalsale.Caption = "G. Total"
        Me.gtotalsale.FieldName = "GRANDTOTAL"
        Me.gtotalsale.ImageIndex = 1
        Me.gtotalsale.Name = "gtotalsale"
        Me.gtotalsale.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.gtotalsale.Visible = True
        Me.gtotalsale.VisibleIndex = 7
        Me.gtotalsale.Width = 90
        '
        'GOURCOMM
        '
        Me.GOURCOMM.Caption = "Our Commission"
        Me.GOURCOMM.DisplayFormat.FormatString = "0.00"
        Me.GOURCOMM.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GOURCOMM.FieldName = "COMM"
        Me.GOURCOMM.Name = "GOURCOMM"
        Me.GOURCOMM.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GOURCOMM.Visible = True
        Me.GOURCOMM.VisibleIndex = 8
        Me.GOURCOMM.Width = 90
        '
        'GREMARKS
        '
        Me.GREMARKS.Caption = "Remarks"
        Me.GREMARKS.FieldName = "REMARKS"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.Visible = True
        Me.GREMARKS.VisibleIndex = 9
        Me.GREMARKS.Width = 200
        '
        'GQUOTE
        '
        Me.GQUOTE.Caption = "Quote Pending"
        Me.GQUOTE.FieldName = "QUOTEPENDING"
        Me.GQUOTE.Name = "GQUOTE"
        Me.GQUOTE.Visible = True
        Me.GQUOTE.VisibleIndex = 10
        Me.GQUOTE.Width = 60
        '
        'GDONE
        '
        Me.GDONE.Caption = "Confirmed"
        Me.GDONE.FieldName = "DONE"
        Me.GDONE.Name = "GDONE"
        Me.GDONE.Visible = True
        Me.GDONE.VisibleIndex = 11
        Me.GDONE.Width = 60
        '
        'GREFNO
        '
        Me.GREFNO.Caption = "Ref No"
        Me.GREFNO.FieldName = "REFNO"
        Me.GREFNO.Name = "GREFNO"
        Me.GREFNO.Visible = True
        Me.GREFNO.VisibleIndex = 12
        Me.GREFNO.Width = 70
        '
        'GUSERNAME
        '
        Me.GUSERNAME.Caption = "User Name"
        Me.GUSERNAME.FieldName = "USERNAME"
        Me.GUSERNAME.Name = "GUSERNAME"
        Me.GUSERNAME.Visible = True
        Me.GUSERNAME.VisibleIndex = 13
        Me.GUSERNAME.Width = 90
        '
        'GAMENDED
        '
        Me.GAMENDED.Caption = "Amended"
        Me.GAMENDED.FieldName = "AMENDED"
        Me.GAMENDED.Name = "GAMENDED"
        '
        'GCMPNAME
        '
        Me.GCMPNAME.Caption = "Company Name"
        Me.GCMPNAME.FieldName = "CMPNAME"
        Me.GCMPNAME.Name = "GCMPNAME"
        Me.GCMPNAME.Visible = True
        Me.GCMPNAME.VisibleIndex = 14
        Me.GCMPNAME.Width = 250
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.Color.Transparent
        Me.cmdcancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdcancel.FlatAppearance.BorderSize = 0
        Me.cmdcancel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.Black
        Me.cmdcancel.Location = New System.Drawing.Point(620, 551)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(80, 28)
        Me.cmdcancel.TabIndex = 316
        Me.cmdcancel.Text = "E&xit"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExcelExport, Me.ToolStripSeparator2, Me.TOOLREFRESH, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1234, 25)
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
        'TOOLREFRESH
        '
        Me.TOOLREFRESH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLREFRESH.Image = Global.HOSPITALITY.My.Resources.Resources.refresh1
        Me.TOOLREFRESH.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLREFRESH.Name = "TOOLREFRESH"
        Me.TOOLREFRESH.Size = New System.Drawing.Size(23, 22)
        Me.TOOLREFRESH.Text = "ToolStripButton1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'PackageQuotationGridReport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "PackageQuotationGridReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "PackageQuotationGridReport"
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
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents gsrno As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gdate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gaccname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOURNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPACKAGEFROM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPACKAGETO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gtotalpax As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gtotalsale As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOURCOMM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GQUOTE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDONE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREFNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GUSERNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAMENDED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdcancel As Button
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ExcelExport As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents GCMPNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TOOLREFRESH As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
End Class
