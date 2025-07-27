<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HomePage2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HomePage2))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.CMDREFRESH = New System.Windows.Forms.Button
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GTourname = New DevExpress.XtraGrid.Columns.GridColumn
        Me.Gstartdate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.Genddate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GNodays = New DevExpress.XtraGrid.Columns.GridColumn
        Me.Ggrstrength = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GAdult = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GChild = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GInfant = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GSEATBALANCE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCUTOFDATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCUTOFDAYS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.CMDOK = New System.Windows.Forms.Button
        Me.cmdcancel = New System.Windows.Forms.Button
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.ExcelExport = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.PRINTTOOL = New System.Windows.Forms.ToolStripButton
        Me.GDeccostinfant = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GDeccostchild = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GDeccostadult = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GDecpkginfant = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GDecpkgchild = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GDecpkgadult = New DevExpress.XtraGrid.Columns.GridColumn
        Me.Gprofitinfant = New DevExpress.XtraGrid.Columns.GridColumn
        Me.Gprofitchild = New DevExpress.XtraGrid.Columns.GridColumn
        Me.Gprofitadult = New DevExpress.XtraGrid.Columns.GridColumn
        Me.Gpkgcostinfant = New DevExpress.XtraGrid.Columns.GridColumn
        Me.Gpkgcostchild = New DevExpress.XtraGrid.Columns.GridColumn
        Me.Gpkgcostadult = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTourtype = New DevExpress.XtraGrid.Columns.GridColumn
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMDREFRESH)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1184, 562)
        Me.BlendPanel1.TabIndex = 7
        '
        'CMDREFRESH
        '
        Me.CMDREFRESH.BackColor = System.Drawing.Color.Transparent
        Me.CMDREFRESH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDREFRESH.FlatAppearance.BorderSize = 0
        Me.CMDREFRESH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDREFRESH.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDREFRESH.Location = New System.Drawing.Point(552, 508)
        Me.CMDREFRESH.Name = "CMDREFRESH"
        Me.CMDREFRESH.Size = New System.Drawing.Size(80, 28)
        Me.CMDREFRESH.TabIndex = 319
        Me.CMDREFRESH.Text = "&Refresh"
        Me.CMDREFRESH.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(12, 41)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1160, 451)
        Me.gridbilldetails.TabIndex = 318
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GTourname, Me.Gstartdate, Me.Genddate, Me.GNodays, Me.Ggrstrength, Me.GAdult, Me.GChild, Me.GInfant, Me.GSEATBALANCE, Me.GCUTOFDATE, Me.GCUTOFDAYS})
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
        'GTourname
        '
        Me.GTourname.Caption = "Tour Name"
        Me.GTourname.FieldName = "TOURNAME"
        Me.GTourname.Name = "GTourname"
        Me.GTourname.Visible = True
        Me.GTourname.VisibleIndex = 0
        Me.GTourname.Width = 250
        '
        'Gstartdate
        '
        Me.Gstartdate.Caption = "Start Date"
        Me.Gstartdate.FieldName = "STARTDATE"
        Me.Gstartdate.Name = "Gstartdate"
        Me.Gstartdate.Visible = True
        Me.Gstartdate.VisibleIndex = 1
        Me.Gstartdate.Width = 90
        '
        'Genddate
        '
        Me.Genddate.Caption = "End date"
        Me.Genddate.FieldName = "ENDDATE"
        Me.Genddate.Name = "Genddate"
        Me.Genddate.Visible = True
        Me.Genddate.VisibleIndex = 2
        Me.Genddate.Width = 90
        '
        'GNodays
        '
        Me.GNodays.AppearanceHeader.Options.UseTextOptions = True
        Me.GNodays.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GNodays.Caption = "Days"
        Me.GNodays.DisplayFormat.FormatString = "0"
        Me.GNodays.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GNodays.FieldName = "DAYS"
        Me.GNodays.Name = "GNodays"
        Me.GNodays.Visible = True
        Me.GNodays.VisibleIndex = 3
        Me.GNodays.Width = 60
        '
        'Ggrstrength
        '
        Me.Ggrstrength.AppearanceHeader.Options.UseTextOptions = True
        Me.Ggrstrength.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.Ggrstrength.Caption = "Group Strength"
        Me.Ggrstrength.DisplayFormat.FormatString = "0"
        Me.Ggrstrength.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.Ggrstrength.FieldName = "GROUPSTRENGTH"
        Me.Ggrstrength.Name = "Ggrstrength"
        Me.Ggrstrength.Visible = True
        Me.Ggrstrength.VisibleIndex = 4
        Me.Ggrstrength.Width = 85
        '
        'GAdult
        '
        Me.GAdult.AppearanceHeader.Options.UseTextOptions = True
        Me.GAdult.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GAdult.Caption = "Adult"
        Me.GAdult.DisplayFormat.FormatString = "0.00"
        Me.GAdult.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GAdult.FieldName = "ADULT"
        Me.GAdult.Name = "GAdult"
        Me.GAdult.Visible = True
        Me.GAdult.VisibleIndex = 5
        Me.GAdult.Width = 80
        '
        'GChild
        '
        Me.GChild.AppearanceHeader.Options.UseTextOptions = True
        Me.GChild.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GChild.Caption = "Child"
        Me.GChild.DisplayFormat.FormatString = "0.00"
        Me.GChild.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GChild.FieldName = "CHILD"
        Me.GChild.Name = "GChild"
        Me.GChild.Visible = True
        Me.GChild.VisibleIndex = 6
        Me.GChild.Width = 80
        '
        'GInfant
        '
        Me.GInfant.AppearanceHeader.Options.UseTextOptions = True
        Me.GInfant.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GInfant.Caption = "Infant"
        Me.GInfant.DisplayFormat.FormatString = "0.00"
        Me.GInfant.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GInfant.FieldName = "INFANT"
        Me.GInfant.Name = "GInfant"
        Me.GInfant.Visible = True
        Me.GInfant.VisibleIndex = 7
        Me.GInfant.Width = 80
        '
        'GSEATBALANCE
        '
        Me.GSEATBALANCE.AppearanceHeader.Options.UseTextOptions = True
        Me.GSEATBALANCE.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GSEATBALANCE.Caption = "Balance Seats"
        Me.GSEATBALANCE.FieldName = "BALANCE"
        Me.GSEATBALANCE.Name = "GSEATBALANCE"
        Me.GSEATBALANCE.Visible = True
        Me.GSEATBALANCE.VisibleIndex = 8
        Me.GSEATBALANCE.Width = 90
        '
        'GCUTOFDATE
        '
        Me.GCUTOFDATE.Caption = "Cut Of Date"
        Me.GCUTOFDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GCUTOFDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GCUTOFDATE.FieldName = "CUTOFDATE"
        Me.GCUTOFDATE.Name = "GCUTOFDATE"
        Me.GCUTOFDATE.Visible = True
        Me.GCUTOFDATE.VisibleIndex = 9
        Me.GCUTOFDATE.Width = 90
        '
        'GCUTOFDAYS
        '
        Me.GCUTOFDAYS.AppearanceHeader.Options.UseTextOptions = True
        Me.GCUTOFDAYS.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GCUTOFDAYS.Caption = "Cut OF Days"
        Me.GCUTOFDAYS.DisplayFormat.FormatString = "0"
        Me.GCUTOFDAYS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCUTOFDAYS.FieldName = "CUTOFDAYS"
        Me.GCUTOFDAYS.Name = "GCUTOFDAYS"
        Me.GCUTOFDAYS.Visible = True
        Me.GCUTOFDAYS.VisibleIndex = 10
        Me.GCUTOFDAYS.Width = 90
        '
        'CMDOK
        '
        Me.CMDOK.BackColor = System.Drawing.Color.Transparent
        Me.CMDOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDOK.FlatAppearance.BorderSize = 0
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDOK.Location = New System.Drawing.Point(466, 508)
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
        Me.cmdcancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdcancel.Location = New System.Drawing.Point(638, 508)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(80, 28)
        Me.cmdcancel.TabIndex = 316
        Me.cmdcancel.Text = "&Exit"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.toolStripSeparator, Me.ExcelExport, Me.ToolStripSeparator2, Me.PRINTTOOL})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1184, 25)
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
        'PRINTTOOL
        '
        Me.PRINTTOOL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PRINTTOOL.Image = CType(resources.GetObject("PRINTTOOL.Image"), System.Drawing.Image)
        Me.PRINTTOOL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PRINTTOOL.Name = "PRINTTOOL"
        Me.PRINTTOOL.Size = New System.Drawing.Size(23, 22)
        Me.PRINTTOOL.Text = "&Print"
        Me.PRINTTOOL.Visible = False
        '
        'GDeccostinfant
        '
        Me.GDeccostinfant.Caption = "Dec Cost Infant"
        Me.GDeccostinfant.FieldName = "DECINFANT"
        Me.GDeccostinfant.Name = "GDeccostinfant"
        Me.GDeccostinfant.Visible = True
        Me.GDeccostinfant.VisibleIndex = 10
        '
        'GDeccostchild
        '
        Me.GDeccostchild.Caption = "Dec Cost Child"
        Me.GDeccostchild.FieldName = "DECCHILD"
        Me.GDeccostchild.Name = "GDeccostchild"
        Me.GDeccostchild.Visible = True
        Me.GDeccostchild.VisibleIndex = 10
        '
        'GDeccostadult
        '
        Me.GDeccostadult.Caption = "Dec Adult Cost "
        Me.GDeccostadult.FieldName = "DECADULT"
        Me.GDeccostadult.Name = "GDeccostadult"
        Me.GDeccostadult.Visible = True
        Me.GDeccostadult.VisibleIndex = 10
        '
        'GDecpkginfant
        '
        Me.GDecpkginfant.Caption = "Dec Infant Pkg"
        Me.GDecpkginfant.FieldName = "DECPKGINFANT"
        Me.GDecpkginfant.Name = "GDecpkginfant"
        Me.GDecpkginfant.Visible = True
        Me.GDecpkginfant.VisibleIndex = 10
        '
        'GDecpkgchild
        '
        Me.GDecpkgchild.Caption = "Dec Child Pkg"
        Me.GDecpkgchild.FieldName = "DECPKGCHILD"
        Me.GDecpkgchild.Name = "GDecpkgchild"
        Me.GDecpkgchild.Visible = True
        Me.GDecpkgchild.VisibleIndex = 10
        '
        'GDecpkgadult
        '
        Me.GDecpkgadult.Caption = "dec Adult Pkg"
        Me.GDecpkgadult.FieldName = "DECPKGADULT"
        Me.GDecpkgadult.Name = "GDecpkgadult"
        Me.GDecpkgadult.Visible = True
        Me.GDecpkgadult.VisibleIndex = 10
        '
        'Gprofitinfant
        '
        Me.Gprofitinfant.Caption = "Profit Infant"
        Me.Gprofitinfant.FieldName = "PROFITINFANT"
        Me.Gprofitinfant.Name = "Gprofitinfant"
        Me.Gprofitinfant.Visible = True
        Me.Gprofitinfant.VisibleIndex = 10
        '
        'Gprofitchild
        '
        Me.Gprofitchild.Caption = "Profit Child"
        Me.Gprofitchild.FieldName = "PROFITCHILD"
        Me.Gprofitchild.Name = "Gprofitchild"
        Me.Gprofitchild.Visible = True
        Me.Gprofitchild.VisibleIndex = 10
        '
        'Gprofitadult
        '
        Me.Gprofitadult.Caption = "Profit Adult"
        Me.Gprofitadult.FieldName = "PROFITADULT"
        Me.Gprofitadult.Name = "Gprofitadult"
        Me.Gprofitadult.Visible = True
        Me.Gprofitadult.VisibleIndex = 10
        '
        'Gpkgcostinfant
        '
        Me.Gpkgcostinfant.Caption = "Pkg Cost Infant"
        Me.Gpkgcostinfant.FieldName = "PKGINFANT"
        Me.Gpkgcostinfant.Name = "Gpkgcostinfant"
        Me.Gpkgcostinfant.Visible = True
        Me.Gpkgcostinfant.VisibleIndex = 10
        '
        'Gpkgcostchild
        '
        Me.Gpkgcostchild.Caption = "Pkg Cost Child"
        Me.Gpkgcostchild.FieldName = "PKGCHILD"
        Me.Gpkgcostchild.Name = "Gpkgcostchild"
        Me.Gpkgcostchild.Visible = True
        Me.Gpkgcostchild.VisibleIndex = 10
        '
        'Gpkgcostadult
        '
        Me.Gpkgcostadult.Caption = "Pkg Cost Adult"
        Me.Gpkgcostadult.FieldName = "PKGADULT"
        Me.Gpkgcostadult.Name = "Gpkgcostadult"
        Me.Gpkgcostadult.Visible = True
        Me.Gpkgcostadult.VisibleIndex = 10
        '
        'GTourtype
        '
        Me.GTourtype.Caption = "Tour Type"
        Me.GTourtype.FieldName = "TOURTYPE"
        Me.GTourtype.Name = "GTourtype"
        Me.GTourtype.Visible = True
        Me.GTourtype.VisibleIndex = 10
        '
        'HomePage2
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1184, 562)
        Me.Controls.Add(Me.BlendPanel1)
        Me.KeyPreview = True
        Me.Name = "HomePage2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "HomePage2"
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
    Friend WithEvents CMDOK As System.Windows.Forms.Button
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExcelExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PRINTTOOL As System.Windows.Forms.ToolStripButton
    Friend WithEvents GDeccostinfant As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDeccostchild As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDeccostadult As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDecpkginfant As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDecpkgchild As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDecpkgadult As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Gprofitinfant As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Gprofitchild As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Gprofitadult As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Gpkgcostinfant As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Gpkgcostchild As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Gpkgcostadult As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTourtype As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GTourname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Ggrstrength As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNodays As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Gstartdate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Genddate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSEATBALANCE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAdult As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GChild As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GInfant As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCUTOFDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCUTOFDAYS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMDREFRESH As System.Windows.Forms.Button
End Class
