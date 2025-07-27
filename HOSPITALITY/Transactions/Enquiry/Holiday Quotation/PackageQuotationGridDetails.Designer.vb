<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PackageQuotationGridDetails
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
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCATEGORY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBOOKER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GHOTELNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCONFNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCONFBY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GINCLUSIONS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GARRIVAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDEPARTURE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GROOMTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPLAN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GADULTS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNOOFROOMS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPACKAGE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREMARKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPOLICYNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNOTESNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ExcelExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TOOLREFRESH = New System.Windows.Forms.ToolStripButton()
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
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
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
        Me.gridbilldetails.Location = New System.Drawing.Point(14, 28)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1207, 517)
        Me.gridbilldetails.TabIndex = 493
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gsrno, Me.gdate, Me.gaccname, Me.GNAME, Me.GCATEGORY, Me.GBOOKER, Me.GHOTELNAME, Me.GCONFNO, Me.GCONFBY, Me.GINCLUSIONS, Me.GARRIVAL, Me.GDEPARTURE, Me.GROOMTYPE, Me.GPLAN, Me.GADULTS, Me.GNOOFROOMS, Me.GPACKAGE, Me.GRATE, Me.GREMARKS, Me.GPOLICYNAME, Me.GNOTESNAME})
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
        Me.gsrno.Caption = "Quote No"
        Me.gsrno.FieldName = "QUOTENO"
        Me.gsrno.Name = "gsrno"
        Me.gsrno.Visible = True
        Me.gsrno.VisibleIndex = 0
        '
        'gdate
        '
        Me.gdate.Caption = "Quote Date"
        Me.gdate.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.gdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.gdate.FieldName = "BOOKINGDATE"
        Me.gdate.Name = "gdate"
        Me.gdate.Visible = True
        Me.gdate.VisibleIndex = 1
        '
        'gaccname
        '
        Me.gaccname.Caption = "Guest Name"
        Me.gaccname.FieldName = "GUESTNAME"
        Me.gaccname.ImageIndex = 0
        Me.gaccname.Name = "gaccname"
        Me.gaccname.Visible = True
        Me.gaccname.VisibleIndex = 2
        Me.gaccname.Width = 150
        '
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 3
        Me.GNAME.Width = 200
        '
        'GCATEGORY
        '
        Me.GCATEGORY.Caption = "Comp Group"
        Me.GCATEGORY.FieldName = "COMPANYGROUP"
        Me.GCATEGORY.Name = "GCATEGORY"
        Me.GCATEGORY.Visible = True
        Me.GCATEGORY.VisibleIndex = 4
        Me.GCATEGORY.Width = 150
        '
        'GBOOKER
        '
        Me.GBOOKER.Caption = "Booker"
        Me.GBOOKER.FieldName = "BOOKER"
        Me.GBOOKER.Name = "GBOOKER"
        Me.GBOOKER.Visible = True
        Me.GBOOKER.VisibleIndex = 5
        Me.GBOOKER.Width = 150
        '
        'GHOTELNAME
        '
        Me.GHOTELNAME.Caption = "Hotel Name"
        Me.GHOTELNAME.FieldName = "HOTELNAME"
        Me.GHOTELNAME.Name = "GHOTELNAME"
        Me.GHOTELNAME.Visible = True
        Me.GHOTELNAME.VisibleIndex = 6
        Me.GHOTELNAME.Width = 250
        '
        'GCONFNO
        '
        Me.GCONFNO.Caption = "Conf No"
        Me.GCONFNO.FieldName = "CONFNO"
        Me.GCONFNO.Name = "GCONFNO"
        Me.GCONFNO.Visible = True
        Me.GCONFNO.VisibleIndex = 7
        Me.GCONFNO.Width = 100
        '
        'GCONFBY
        '
        Me.GCONFBY.Caption = "Conf By"
        Me.GCONFBY.FieldName = "CONFBY"
        Me.GCONFBY.Name = "GCONFBY"
        Me.GCONFBY.Visible = True
        Me.GCONFBY.VisibleIndex = 8
        Me.GCONFBY.Width = 120
        '
        'GINCLUSIONS
        '
        Me.GINCLUSIONS.Caption = "Inclusions"
        Me.GINCLUSIONS.FieldName = "INCLUSIONS"
        Me.GINCLUSIONS.Name = "GINCLUSIONS"
        Me.GINCLUSIONS.Visible = True
        Me.GINCLUSIONS.VisibleIndex = 9
        Me.GINCLUSIONS.Width = 150
        '
        'GARRIVAL
        '
        Me.GARRIVAL.Caption = "Check In"
        Me.GARRIVAL.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GARRIVAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GARRIVAL.FieldName = "ARRIVAL"
        Me.GARRIVAL.Name = "GARRIVAL"
        Me.GARRIVAL.Visible = True
        Me.GARRIVAL.VisibleIndex = 10
        '
        'GDEPARTURE
        '
        Me.GDEPARTURE.Caption = "Check Out"
        Me.GDEPARTURE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDEPARTURE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDEPARTURE.FieldName = "DEPARTURE"
        Me.GDEPARTURE.Name = "GDEPARTURE"
        Me.GDEPARTURE.Visible = True
        Me.GDEPARTURE.VisibleIndex = 11
        '
        'GROOMTYPE
        '
        Me.GROOMTYPE.Caption = "Room Type"
        Me.GROOMTYPE.FieldName = "ROOMTYPE"
        Me.GROOMTYPE.Name = "GROOMTYPE"
        Me.GROOMTYPE.Visible = True
        Me.GROOMTYPE.VisibleIndex = 12
        Me.GROOMTYPE.Width = 200
        '
        'GPLAN
        '
        Me.GPLAN.Caption = "Plan"
        Me.GPLAN.FieldName = "PLAN"
        Me.GPLAN.Name = "GPLAN"
        Me.GPLAN.Visible = True
        Me.GPLAN.VisibleIndex = 13
        Me.GPLAN.Width = 100
        '
        'GADULTS
        '
        Me.GADULTS.Caption = "Adults"
        Me.GADULTS.DisplayFormat.FormatString = "0"
        Me.GADULTS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GADULTS.FieldName = "ADULTS"
        Me.GADULTS.Name = "GADULTS"
        Me.GADULTS.Visible = True
        Me.GADULTS.VisibleIndex = 14
        '
        'GNOOFROOMS
        '
        Me.GNOOFROOMS.Caption = "Rooms"
        Me.GNOOFROOMS.DisplayFormat.FormatString = "0"
        Me.GNOOFROOMS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GNOOFROOMS.FieldName = "NOOFROOMS"
        Me.GNOOFROOMS.Name = "GNOOFROOMS"
        Me.GNOOFROOMS.Visible = True
        Me.GNOOFROOMS.VisibleIndex = 15
        '
        'GPACKAGE
        '
        Me.GPACKAGE.Caption = "Package"
        Me.GPACKAGE.FieldName = "BPACKAGE"
        Me.GPACKAGE.Name = "GPACKAGE"
        Me.GPACKAGE.Visible = True
        Me.GPACKAGE.VisibleIndex = 16
        Me.GPACKAGE.Width = 50
        '
        'GRATE
        '
        Me.GRATE.Caption = "Rate"
        Me.GRATE.DisplayFormat.FormatString = "0.00"
        Me.GRATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GRATE.FieldName = "RATE"
        Me.GRATE.Name = "GRATE"
        Me.GRATE.Visible = True
        Me.GRATE.VisibleIndex = 17
        '
        'GREMARKS
        '
        Me.GREMARKS.Caption = "Remarks"
        Me.GREMARKS.FieldName = "REMARKS"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.Visible = True
        Me.GREMARKS.VisibleIndex = 18
        Me.GREMARKS.Width = 250
        '
        'GPOLICYNAME
        '
        Me.GPOLICYNAME.Caption = "Policy Name"
        Me.GPOLICYNAME.FieldName = "POLICYNAME"
        Me.GPOLICYNAME.Name = "GPOLICYNAME"
        Me.GPOLICYNAME.Visible = True
        Me.GPOLICYNAME.VisibleIndex = 19
        Me.GPOLICYNAME.Width = 150
        '
        'GNOTESNAME
        '
        Me.GNOTESNAME.Caption = "Notes Name"
        Me.GNOTESNAME.FieldName = "NOTESNAME"
        Me.GNOTESNAME.Name = "GNOTESNAME"
        Me.GNOTESNAME.Visible = True
        Me.GNOTESNAME.VisibleIndex = 20
        Me.GNOTESNAME.Width = 150
        '
        'CMDOK
        '
        Me.CMDOK.BackColor = System.Drawing.Color.Transparent
        Me.CMDOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDOK.FlatAppearance.BorderSize = 0
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.Black
        Me.CMDOK.Location = New System.Drawing.Point(534, 551)
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
        Me.cmdcancel.Location = New System.Drawing.Point(620, 551)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(80, 28)
        Me.cmdcancel.TabIndex = 316
        Me.cmdcancel.Text = "E&xit"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.TOOLREFRESH, Me.toolStripSeparator, Me.ExcelExport, Me.ToolStripSeparator2})
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
        Me.TOOLREFRESH.Text = "ToolStripButton2"
        '
        'PackageQuotationGridDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "PackageQuotationGridDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Package Quotation Grid Details"
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
    Friend WithEvents CMDOK As Button
    Friend WithEvents cmdcancel As Button
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents ExcelExport As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents GHOTELNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCONFNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCONFBY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GINCLUSIONS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GARRIVAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDEPARTURE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GROOMTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPLAN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GADULTS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNOOFROOMS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPACKAGE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPOLICYNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNOTESNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCATEGORY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBOOKER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TOOLREFRESH As ToolStripButton
End Class
