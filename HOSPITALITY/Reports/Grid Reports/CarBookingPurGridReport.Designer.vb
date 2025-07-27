<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CarBookingPurGridReport
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
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GINITIALS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GBOOKINGNO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gdate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gaccname = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTOTALTIME = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTOTALKMS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GEXTRAKMS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GEXTRATIME = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GVEHICLE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCARNO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GAMT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GEXTRAKMAMT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GEXTRAHRAMT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTOLLANDPARKING = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GGRANDTOTAL = New DevExpress.XtraGrid.Columns.GridColumn
        Me.cmdcancel = New System.Windows.Forms.Button
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ExcelExport = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.GNIGHTS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GDAYS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GPURALLOWANCE = New DevExpress.XtraGrid.Columns.GridColumn
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
        Me.BlendPanel1.Size = New System.Drawing.Size(1137, 582)
        Me.BlendPanel1.TabIndex = 6
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(15, 33)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1107, 506)
        Me.gridbilldetails.TabIndex = 314
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GINITIALS, Me.GBOOKINGNO, Me.gdate, Me.gaccname, Me.GTOTALTIME, Me.GTOTALKMS, Me.GEXTRAKMS, Me.GEXTRATIME, Me.GVEHICLE, Me.GCARNO, Me.GDAYS, Me.GNIGHTS, Me.GAMT, Me.GEXTRAKMAMT, Me.GEXTRAHRAMT, Me.GPURALLOWANCE, Me.GTOLLANDPARKING, Me.GGRANDTOTAL})
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
        Me.GINITIALS.Caption = "Booking No"
        Me.GINITIALS.FieldName = "BILLINITIALS"
        Me.GINITIALS.Name = "GINITIALS"
        Me.GINITIALS.Visible = True
        Me.GINITIALS.VisibleIndex = 0
        '
        'GBOOKINGNO
        '
        Me.GBOOKINGNO.Caption = "Booking No"
        Me.GBOOKINGNO.FieldName = "BOOKINGNO"
        Me.GBOOKINGNO.Name = "GBOOKINGNO"
        '
        'gdate
        '
        Me.gdate.Caption = "Date"
        Me.gdate.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.gdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.gdate.FieldName = "DATE"
        Me.gdate.Name = "gdate"
        Me.gdate.Visible = True
        Me.gdate.VisibleIndex = 1
        Me.gdate.Width = 70
        '
        'gaccname
        '
        Me.gaccname.Caption = "Account Name"
        Me.gaccname.FieldName = "ACCNAME"
        Me.gaccname.Name = "gaccname"
        Me.gaccname.Visible = True
        Me.gaccname.VisibleIndex = 2
        Me.gaccname.Width = 200
        '
        'GTOTALTIME
        '
        Me.GTOTALTIME.Caption = "Total Time"
        Me.GTOTALTIME.DisplayFormat.FormatString = "0.0"
        Me.GTOTALTIME.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALTIME.FieldName = "PURTOTALTIME"
        Me.GTOTALTIME.Name = "GTOTALTIME"
        Me.GTOTALTIME.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GTOTALTIME.Visible = True
        Me.GTOTALTIME.VisibleIndex = 3
        '
        'GTOTALKMS
        '
        Me.GTOTALKMS.Caption = "Total Kms"
        Me.GTOTALKMS.DisplayFormat.FormatString = "0"
        Me.GTOTALKMS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALKMS.FieldName = "PURTOTALKMS"
        Me.GTOTALKMS.Name = "GTOTALKMS"
        Me.GTOTALKMS.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GTOTALKMS.Visible = True
        Me.GTOTALKMS.VisibleIndex = 4
        '
        'GEXTRAKMS
        '
        Me.GEXTRAKMS.Caption = "Extra Kms"
        Me.GEXTRAKMS.DisplayFormat.FormatString = "0"
        Me.GEXTRAKMS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GEXTRAKMS.FieldName = "PUREXTRAKMS"
        Me.GEXTRAKMS.Name = "GEXTRAKMS"
        Me.GEXTRAKMS.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GEXTRAKMS.Visible = True
        Me.GEXTRAKMS.VisibleIndex = 5
        '
        'GEXTRATIME
        '
        Me.GEXTRATIME.Caption = "Extra Time"
        Me.GEXTRATIME.DisplayFormat.FormatString = "0.0"
        Me.GEXTRATIME.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GEXTRATIME.FieldName = "PUREXTRATIME"
        Me.GEXTRATIME.Name = "GEXTRATIME"
        Me.GEXTRATIME.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GEXTRATIME.Visible = True
        Me.GEXTRATIME.VisibleIndex = 6
        '
        'GVEHICLE
        '
        Me.GVEHICLE.Caption = "Car Type"
        Me.GVEHICLE.FieldName = "VEHICLENAME"
        Me.GVEHICLE.Name = "GVEHICLE"
        Me.GVEHICLE.Visible = True
        Me.GVEHICLE.VisibleIndex = 7
        Me.GVEHICLE.Width = 100
        '
        'GCARNO
        '
        Me.GCARNO.Caption = "Car No"
        Me.GCARNO.FieldName = "VEHICLENO"
        Me.GCARNO.Name = "GCARNO"
        Me.GCARNO.Visible = True
        Me.GCARNO.VisibleIndex = 8
        '
        'GAMT
        '
        Me.GAMT.Caption = "Total"
        Me.GAMT.DisplayFormat.FormatString = "0.00"
        Me.GAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GAMT.FieldName = "PURTOTALAMT"
        Me.GAMT.Name = "GAMT"
        Me.GAMT.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GAMT.Visible = True
        Me.GAMT.VisibleIndex = 11
        '
        'GEXTRAKMAMT
        '
        Me.GEXTRAKMAMT.Caption = "Extra Km Amt"
        Me.GEXTRAKMAMT.DisplayFormat.FormatString = "0.00"
        Me.GEXTRAKMAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GEXTRAKMAMT.FieldName = "PUREXTRAKMAMT"
        Me.GEXTRAKMAMT.Name = "GEXTRAKMAMT"
        Me.GEXTRAKMAMT.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GEXTRAKMAMT.Visible = True
        Me.GEXTRAKMAMT.VisibleIndex = 12
        '
        'GEXTRAHRAMT
        '
        Me.GEXTRAHRAMT.Caption = "Extra Hr Amt"
        Me.GEXTRAHRAMT.DisplayFormat.FormatString = "0.00"
        Me.GEXTRAHRAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GEXTRAHRAMT.FieldName = "PUREXTRAHRAMT"
        Me.GEXTRAHRAMT.Name = "GEXTRAHRAMT"
        Me.GEXTRAHRAMT.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GEXTRAHRAMT.Visible = True
        Me.GEXTRAHRAMT.VisibleIndex = 13
        '
        'GTOLLANDPARKING
        '
        Me.GTOLLANDPARKING.Caption = "Toll & Parking"
        Me.GTOLLANDPARKING.DisplayFormat.FormatString = "0"
        Me.GTOLLANDPARKING.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOLLANDPARKING.FieldName = "PUROTHERCHGS"
        Me.GTOLLANDPARKING.Name = "GTOLLANDPARKING"
        Me.GTOLLANDPARKING.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GTOLLANDPARKING.Visible = True
        Me.GTOLLANDPARKING.VisibleIndex = 15
        Me.GTOLLANDPARKING.Width = 100
        '
        'GGRANDTOTAL
        '
        Me.GGRANDTOTAL.Caption = "Grand Total"
        Me.GGRANDTOTAL.DisplayFormat.FormatString = "0.00"
        Me.GGRANDTOTAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GGRANDTOTAL.FieldName = "PURGTOTAL"
        Me.GGRANDTOTAL.Name = "GGRANDTOTAL"
        Me.GGRANDTOTAL.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GGRANDTOTAL.Visible = True
        Me.GGRANDTOTAL.VisibleIndex = 16
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.Color.Transparent
        Me.cmdcancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdcancel.FlatAppearance.BorderSize = 0
        Me.cmdcancel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.Black
        Me.cmdcancel.Location = New System.Drawing.Point(528, 545)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(80, 28)
        Me.cmdcancel.TabIndex = 316
        Me.cmdcancel.Text = "E&xit"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExcelExport, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1137, 25)
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'GNIGHTS
        '
        Me.GNIGHTS.Caption = "Nights"
        Me.GNIGHTS.DisplayFormat.FormatString = "0"
        Me.GNIGHTS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GNIGHTS.FieldName = "NIGHTS"
        Me.GNIGHTS.Name = "GNIGHTS"
        Me.GNIGHTS.Visible = True
        Me.GNIGHTS.VisibleIndex = 10
        '
        'GDAYS
        '
        Me.GDAYS.Caption = "Days"
        Me.GDAYS.DisplayFormat.FormatString = "0"
        Me.GDAYS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GDAYS.FieldName = "DAYS"
        Me.GDAYS.Name = "GDAYS"
        Me.GDAYS.Visible = True
        Me.GDAYS.VisibleIndex = 9
        '
        'GPURALLOWANCE
        '
        Me.GPURALLOWANCE.Caption = "Allowance"
        Me.GPURALLOWANCE.DisplayFormat.FormatString = "0.00"
        Me.GPURALLOWANCE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPURALLOWANCE.FieldName = "PURALLOWANCE"
        Me.GPURALLOWANCE.Name = "GPURALLOWANCE"
        Me.GPURALLOWANCE.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GPURALLOWANCE.Visible = True
        Me.GPURALLOWANCE.VisibleIndex = 14
        '
        'CarBookingPurGridReport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1137, 582)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "CarBookingPurGridReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Car Booking Purchase"
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
    Private WithEvents gdate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCARNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GVEHICLE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALTIME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALKMS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GEXTRAKMS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GEXTRATIME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOLLANDPARKING As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gaccname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ExcelExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GEXTRAKMAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GEXTRAHRAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGRANDTOTAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBOOKINGNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDAYS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNIGHTS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURALLOWANCE As DevExpress.XtraGrid.Columns.GridColumn
End Class
