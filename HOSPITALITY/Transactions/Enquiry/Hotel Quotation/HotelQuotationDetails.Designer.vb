<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HotelQuotationDetails
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
        Me.CMDOK = New System.Windows.Forms.Button
        Me.cmdcancel = New System.Windows.Forms.Button
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.gsrno = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GREFNO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gdate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gname = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ghotelname = New DevExpress.XtraGrid.Columns.GridColumn
        Me.garrival = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gdeparture = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gtotalpax = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gtotalrooms = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCOMM = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gtotalsale = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GUSERNAME = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GMODIFIEDBY = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCONFIRMED = New DevExpress.XtraGrid.Columns.GridColumn
        Me.CHKDONE = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.ExcelExport = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.lbl = New System.Windows.Forms.Label
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CHKDONE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1008, 582)
        Me.BlendPanel1.TabIndex = 4
        '
        'CMDOK
        '
        Me.CMDOK.BackColor = System.Drawing.Color.Transparent
        Me.CMDOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDOK.FlatAppearance.BorderSize = 0
        Me.CMDOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDOK.Image = Global.HOSPITALITY.My.Resources.Resources.ok
        Me.CMDOK.Location = New System.Drawing.Point(439, 552)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(72, 26)
        Me.CMDOK.TabIndex = 317
        Me.CMDOK.UseVisualStyleBackColor = False
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.Color.Transparent
        Me.cmdcancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdcancel.FlatAppearance.BorderSize = 0
        Me.cmdcancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdcancel.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdcancel.Image = Global.HOSPITALITY.My.Resources.Resources._Exit
        Me.cmdcancel.Location = New System.Drawing.Point(517, 554)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(72, 24)
        Me.cmdcancel.TabIndex = 316
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(13, 53)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CHKDONE})
        Me.gridbilldetails.Size = New System.Drawing.Size(982, 493)
        Me.gridbilldetails.TabIndex = 314
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gsrno, Me.GREFNO, Me.gdate, Me.gname, Me.ghotelname, Me.garrival, Me.gdeparture, Me.gtotalpax, Me.gtotalrooms, Me.GCOMM, Me.gtotalsale, Me.GUSERNAME, Me.GMODIFIEDBY, Me.GCONFIRMED})
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
        'gsrno
        '
        Me.gsrno.Caption = "Enquiry No"
        Me.gsrno.FieldName = "ENQNO"
        Me.gsrno.ImageIndex = 1
        Me.gsrno.Name = "gsrno"
        Me.gsrno.Visible = True
        Me.gsrno.VisibleIndex = 0
        '
        'GREFNO
        '
        Me.GREFNO.Caption = "Ref No"
        Me.GREFNO.FieldName = "REFNO"
        Me.GREFNO.Name = "GREFNO"
        Me.GREFNO.Visible = True
        Me.GREFNO.VisibleIndex = 1
        '
        'gdate
        '
        Me.gdate.Caption = "Date"
        Me.gdate.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.gdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.gdate.FieldName = "ENQDATE"
        Me.gdate.Name = "gdate"
        Me.gdate.Visible = True
        Me.gdate.VisibleIndex = 2
        Me.gdate.Width = 70
        '
        'gname
        '
        Me.gname.Caption = "Guest Name"
        Me.gname.FieldName = "GUESTNAME"
        Me.gname.ImageIndex = 0
        Me.gname.Name = "gname"
        Me.gname.Visible = True
        Me.gname.VisibleIndex = 3
        Me.gname.Width = 200
        '
        'ghotelname
        '
        Me.ghotelname.Caption = "Hotel Name"
        Me.ghotelname.FieldName = "HOTELNAME"
        Me.ghotelname.Name = "ghotelname"
        Me.ghotelname.Visible = True
        Me.ghotelname.VisibleIndex = 4
        Me.ghotelname.Width = 200
        '
        'garrival
        '
        Me.garrival.Caption = "Arrival"
        Me.garrival.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.garrival.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.garrival.FieldName = "ARRIVAL"
        Me.garrival.Name = "garrival"
        Me.garrival.Visible = True
        Me.garrival.VisibleIndex = 5
        Me.garrival.Width = 70
        '
        'gdeparture
        '
        Me.gdeparture.Caption = "Departure"
        Me.gdeparture.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.gdeparture.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.gdeparture.FieldName = "DEPARTURE"
        Me.gdeparture.Name = "gdeparture"
        Me.gdeparture.Visible = True
        Me.gdeparture.VisibleIndex = 6
        Me.gdeparture.Width = 70
        '
        'gtotalpax
        '
        Me.gtotalpax.Caption = "Total Pax"
        Me.gtotalpax.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.gtotalpax.FieldName = "TOTALPAX"
        Me.gtotalpax.Name = "gtotalpax"
        Me.gtotalpax.Visible = True
        Me.gtotalpax.VisibleIndex = 7
        Me.gtotalpax.Width = 55
        '
        'gtotalrooms
        '
        Me.gtotalrooms.Caption = "Rooms"
        Me.gtotalrooms.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.gtotalrooms.FieldName = "TOTALROOMS"
        Me.gtotalrooms.Name = "gtotalrooms"
        Me.gtotalrooms.Visible = True
        Me.gtotalrooms.VisibleIndex = 8
        Me.gtotalrooms.Width = 45
        '
        'GCOMM
        '
        Me.GCOMM.Caption = "Our Commission"
        Me.GCOMM.DisplayFormat.FormatString = "0.00"
        Me.GCOMM.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCOMM.FieldName = "OURCOMM"
        Me.GCOMM.Name = "GCOMM"
        Me.GCOMM.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GCOMM.Visible = True
        Me.GCOMM.VisibleIndex = 9
        Me.GCOMM.Width = 90
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
        Me.gtotalsale.VisibleIndex = 10
        Me.gtotalsale.Width = 80
        '
        'GUSERNAME
        '
        Me.GUSERNAME.Caption = "User Name"
        Me.GUSERNAME.FieldName = "USERNAME"
        Me.GUSERNAME.Name = "GUSERNAME"
        Me.GUSERNAME.Visible = True
        Me.GUSERNAME.VisibleIndex = 11
        Me.GUSERNAME.Width = 90
        '
        'GMODIFIEDBY
        '
        Me.GMODIFIEDBY.Caption = "Modified By"
        Me.GMODIFIEDBY.FieldName = "MODIFIEDBY"
        Me.GMODIFIEDBY.Name = "GMODIFIEDBY"
        Me.GMODIFIEDBY.Visible = True
        Me.GMODIFIEDBY.VisibleIndex = 12
        Me.GMODIFIEDBY.Width = 90
        '
        'GCONFIRMED
        '
        Me.GCONFIRMED.Caption = "Confirmed"
        Me.GCONFIRMED.ColumnEdit = Me.CHKDONE
        Me.GCONFIRMED.FieldName = "DONE"
        Me.GCONFIRMED.Name = "GCONFIRMED"
        Me.GCONFIRMED.Visible = True
        Me.GCONFIRMED.VisibleIndex = 13
        '
        'CHKDONE
        '
        Me.CHKDONE.AutoHeight = False
        Me.CHKDONE.Name = "CHKDONE"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.toolStripSeparator, Me.ExcelExport, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1008, 25)
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
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(20, 36)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(157, 14)
        Me.lbl.TabIndex = 251
        Me.lbl.Text = "Select an Enquiry to Change"
        '
        'HotelQuotationDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1008, 582)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "HotelQuotationDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Hotel Enquiry Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CHKDONE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMDOK As System.Windows.Forms.Button
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents gsrno As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREFNO As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gdate As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ghotelname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents garrival As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gdeparture As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gtotalpax As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gtotalrooms As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gtotalsale As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GUSERNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMODIFIEDBY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCONFIRMED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CHKDONE As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExcelExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents GCOMM As DevExpress.XtraGrid.Columns.GridColumn
End Class
