<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CarBookingSaleGridReport
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
        Me.gdate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCARNO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GVEHICLE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GDRIVERNAME = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCONFIRMEDBY = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gname = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GSTARTTIME = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GENDTIME = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTOTALTIME = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GREFNO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GSTART = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GEND = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTOTALKMS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GEXTRAKMS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GEXTRATIME = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTOLLANDPARKING = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gaccname = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ExcelExport = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.GBILLNO = New DevExpress.XtraGrid.Columns.GridColumn
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
        Me.gridbilldetails.Location = New System.Drawing.Point(15, 33)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1107, 494)
        Me.gridbilldetails.TabIndex = 314
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GINITIALS, Me.gdate, Me.GCARNO, Me.GVEHICLE, Me.GDRIVERNAME, Me.GCONFIRMEDBY, Me.gname, Me.GSTARTTIME, Me.GENDTIME, Me.GTOTALTIME, Me.GREFNO, Me.GSTART, Me.GEND, Me.GTOTALKMS, Me.GEXTRAKMS, Me.GEXTRATIME, Me.GTOLLANDPARKING, Me.gaccname, Me.GBILLNO})
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
        'GDRIVERNAME
        '
        Me.GDRIVERNAME.Caption = "Driver Name"
        Me.GDRIVERNAME.FieldName = "DRIVERNAME"
        Me.GDRIVERNAME.Name = "GDRIVERNAME"
        Me.GDRIVERNAME.Visible = True
        Me.GDRIVERNAME.VisibleIndex = 4
        Me.GDRIVERNAME.Width = 200
        '
        'GCONFIRMEDBY
        '
        Me.GCONFIRMEDBY.Caption = "Confirmed By"
        Me.GCONFIRMEDBY.FieldName = "CONFIRMEDBY"
        Me.GCONFIRMEDBY.Name = "GCONFIRMEDBY"
        Me.GCONFIRMEDBY.Visible = True
        Me.GCONFIRMEDBY.VisibleIndex = 5
        Me.GCONFIRMEDBY.Width = 120
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
        'GSTARTTIME
        '
        Me.GSTARTTIME.Caption = "Start Time"
        Me.GSTARTTIME.DisplayFormat.FormatString = "0.0"
        Me.GSTARTTIME.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSTARTTIME.FieldName = "STARTTIME"
        Me.GSTARTTIME.Name = "GSTARTTIME"
        Me.GSTARTTIME.Visible = True
        Me.GSTARTTIME.VisibleIndex = 7
        '
        'GENDTIME
        '
        Me.GENDTIME.Caption = "End Time"
        Me.GENDTIME.DisplayFormat.FormatString = "0.0"
        Me.GENDTIME.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GENDTIME.FieldName = "ENDTIME"
        Me.GENDTIME.Name = "GENDTIME"
        Me.GENDTIME.Visible = True
        Me.GENDTIME.VisibleIndex = 8
        '
        'GTOTALTIME
        '
        Me.GTOTALTIME.Caption = "Total Time"
        Me.GTOTALTIME.DisplayFormat.FormatString = "0.0"
        Me.GTOTALTIME.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALTIME.FieldName = "TOTALTIME"
        Me.GTOTALTIME.Name = "GTOTALTIME"
        Me.GTOTALTIME.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GTOTALTIME.Visible = True
        Me.GTOTALTIME.VisibleIndex = 9
        '
        'GREFNO
        '
        Me.GREFNO.Caption = "Ref No"
        Me.GREFNO.DisplayFormat.FormatString = "0.00"
        Me.GREFNO.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GREFNO.FieldName = "NIGHTCHGS"
        Me.GREFNO.Name = "GREFNO"
        Me.GREFNO.Visible = True
        Me.GREFNO.VisibleIndex = 10
        '
        'GSTART
        '
        Me.GSTART.Caption = "Opening Kms"
        Me.GSTART.DisplayFormat.FormatString = "0"
        Me.GSTART.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSTART.FieldName = "STARTKMS"
        Me.GSTART.Name = "GSTART"
        Me.GSTART.Visible = True
        Me.GSTART.VisibleIndex = 11
        Me.GSTART.Width = 80
        '
        'GEND
        '
        Me.GEND.Caption = "Closing Kms"
        Me.GEND.DisplayFormat.FormatString = "0"
        Me.GEND.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GEND.FieldName = "ENDKMS"
        Me.GEND.Name = "GEND"
        Me.GEND.Visible = True
        Me.GEND.VisibleIndex = 12
        Me.GEND.Width = 80
        '
        'GTOTALKMS
        '
        Me.GTOTALKMS.Caption = "Total Kms"
        Me.GTOTALKMS.DisplayFormat.FormatString = "0"
        Me.GTOTALKMS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALKMS.FieldName = "TOTALKMS"
        Me.GTOTALKMS.Name = "GTOTALKMS"
        Me.GTOTALKMS.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GTOTALKMS.Visible = True
        Me.GTOTALKMS.VisibleIndex = 13
        '
        'GEXTRAKMS
        '
        Me.GEXTRAKMS.Caption = "Extra Kms"
        Me.GEXTRAKMS.DisplayFormat.FormatString = "0"
        Me.GEXTRAKMS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GEXTRAKMS.FieldName = "EXTRAKMS"
        Me.GEXTRAKMS.Name = "GEXTRAKMS"
        Me.GEXTRAKMS.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GEXTRAKMS.Visible = True
        Me.GEXTRAKMS.VisibleIndex = 14
        '
        'GEXTRATIME
        '
        Me.GEXTRATIME.Caption = "Extra Time"
        Me.GEXTRATIME.DisplayFormat.FormatString = "0.0"
        Me.GEXTRATIME.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GEXTRATIME.FieldName = "EXTRATIME"
        Me.GEXTRATIME.Name = "GEXTRATIME"
        Me.GEXTRATIME.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GEXTRATIME.Visible = True
        Me.GEXTRATIME.VisibleIndex = 15
        '
        'GTOLLANDPARKING
        '
        Me.GTOLLANDPARKING.Caption = "Toll & Parking"
        Me.GTOLLANDPARKING.DisplayFormat.FormatString = "0"
        Me.GTOLLANDPARKING.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOLLANDPARKING.FieldName = "TOLLANDPARKING"
        Me.GTOLLANDPARKING.Name = "GTOLLANDPARKING"
        Me.GTOLLANDPARKING.Visible = True
        Me.GTOLLANDPARKING.VisibleIndex = 16
        Me.GTOLLANDPARKING.Width = 100
        '
        'gaccname
        '
        Me.gaccname.Caption = "Account Name"
        Me.gaccname.FieldName = "ACCNAME"
        Me.gaccname.Name = "gaccname"
        Me.gaccname.Visible = True
        Me.gaccname.VisibleIndex = 17
        Me.gaccname.Width = 200
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExcelExport, Me.ToolStripSeparator1})
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'GBILLNO
        '
        Me.GBILLNO.Caption = "BILLNO"
        Me.GBILLNO.FieldName = "BILLNO"
        Me.GBILLNO.Name = "GBILLNO"
        '
        'CarBookingSaleGridReport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1134, 562)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "CarBookingSaleGridReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Car Booking Sale Report"
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
    Friend WithEvents GDRIVERNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCONFIRMEDBY As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTARTTIME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GENDTIME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALTIME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREFNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTART As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GEND As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALKMS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GEXTRAKMS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GEXTRATIME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOLLANDPARKING As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gaccname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ExcelExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GBILLNO As DevExpress.XtraGrid.Columns.GridColumn
End Class
