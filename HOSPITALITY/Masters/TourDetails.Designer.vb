<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TourDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TourDetails))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.CMDOK = New System.Windows.Forms.Button
        Me.cmdcancel = New System.Windows.Forms.Button
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.gsrno = New DevExpress.XtraGrid.Columns.GridColumn
        Me.Gdate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTourname = New DevExpress.XtraGrid.Columns.GridColumn
        Me.Ggrstrength = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GNodays = New DevExpress.XtraGrid.Columns.GridColumn
        Me.Gstartdate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.Genddate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.Gvisaembassy = New DevExpress.XtraGrid.Columns.GridColumn
        Me.Gportofentry = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GFaizeno = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTourtype = New DevExpress.XtraGrid.Columns.GridColumn
        Me.Gpkgcostadult = New DevExpress.XtraGrid.Columns.GridColumn
        Me.Gpkgcostchild = New DevExpress.XtraGrid.Columns.GridColumn
        Me.Gpkgcostinfant = New DevExpress.XtraGrid.Columns.GridColumn
        Me.Gprofitadult = New DevExpress.XtraGrid.Columns.GridColumn
        Me.Gprofitchild = New DevExpress.XtraGrid.Columns.GridColumn
        Me.Gprofitinfant = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GDecpkgadult = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GDecpkgchild = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GDecpkginfant = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GDeccostadult = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GDeccostchild = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GDeccostinfant = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.ExcelExport = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.PRINTTOOL = New System.Windows.Forms.ToolStripButton
        Me.lbl = New System.Windows.Forms.Label
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BlendPanel1.Size = New System.Drawing.Size(1161, 586)
        Me.BlendPanel1.TabIndex = 6
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
        Me.CMDOK.Location = New System.Drawing.Point(437, 529)
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
        Me.cmdcancel.Location = New System.Drawing.Point(515, 531)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(72, 24)
        Me.cmdcancel.TabIndex = 316
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(23, 74)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1075, 451)
        Me.gridbilldetails.TabIndex = 314
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gsrno, Me.Gdate, Me.GTourname, Me.Ggrstrength, Me.GNodays, Me.Gstartdate, Me.Genddate, Me.Gvisaembassy, Me.Gportofentry, Me.GFaizeno, Me.GTourtype, Me.Gpkgcostadult, Me.Gpkgcostchild, Me.Gpkgcostinfant, Me.Gprofitadult, Me.Gprofitchild, Me.Gprofitinfant, Me.GDecpkgadult, Me.GDecpkgchild, Me.GDecpkginfant, Me.GDeccostadult, Me.GDeccostchild, Me.GDeccostinfant})
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
        Me.gsrno.Caption = "Tour No"
        Me.gsrno.FieldName = "TOURNO"
        Me.gsrno.ImageIndex = 1
        Me.gsrno.Name = "gsrno"
        Me.gsrno.Visible = True
        Me.gsrno.VisibleIndex = 0
        '
        'Gdate
        '
        Me.Gdate.Caption = "Date"
        Me.Gdate.FieldName = "DATE"
        Me.Gdate.Name = "Gdate"
        Me.Gdate.Visible = True
        Me.Gdate.VisibleIndex = 1
        '
        'GTourname
        '
        Me.GTourname.Caption = "Tour Name"
        Me.GTourname.FieldName = "TOURNAME"
        Me.GTourname.Name = "GTourname"
        Me.GTourname.Visible = True
        Me.GTourname.VisibleIndex = 2
        '
        'Ggrstrength
        '
        Me.Ggrstrength.Caption = "Group Strength"
        Me.Ggrstrength.FieldName = "GRPSTRENGTH"
        Me.Ggrstrength.Name = "Ggrstrength"
        Me.Ggrstrength.Visible = True
        Me.Ggrstrength.VisibleIndex = 3
        '
        'GNodays
        '
        Me.GNodays.Caption = "Days"
        Me.GNodays.FieldName = "DAYS"
        Me.GNodays.Name = "GNodays"
        Me.GNodays.Visible = True
        Me.GNodays.VisibleIndex = 4
        '
        'Gstartdate
        '
        Me.Gstartdate.Caption = "Start Date"
        Me.Gstartdate.FieldName = "STARTDATE"
        Me.Gstartdate.Name = "Gstartdate"
        Me.Gstartdate.Visible = True
        Me.Gstartdate.VisibleIndex = 5
        '
        'Genddate
        '
        Me.Genddate.Caption = "End date"
        Me.Genddate.FieldName = "ENDDATE"
        Me.Genddate.Name = "Genddate"
        Me.Genddate.Visible = True
        Me.Genddate.VisibleIndex = 6
        '
        'Gvisaembassy
        '
        Me.Gvisaembassy.Caption = "Visa"
        Me.Gvisaembassy.FieldName = "VISA"
        Me.Gvisaembassy.Name = "Gvisaembassy"
        Me.Gvisaembassy.Visible = True
        Me.Gvisaembassy.VisibleIndex = 7
        '
        'Gportofentry
        '
        Me.Gportofentry.Caption = "Port of Entry"
        Me.Gportofentry.FieldName = "PORT"
        Me.Gportofentry.Name = "Gportofentry"
        Me.Gportofentry.Visible = True
        Me.Gportofentry.VisibleIndex = 8
        '
        'GFaizeno
        '
        Me.GFaizeno.Caption = "Faize/Muwafeka No"
        Me.GFaizeno.FieldName = "FAIZE"
        Me.GFaizeno.Name = "GFaizeno"
        Me.GFaizeno.Visible = True
        Me.GFaizeno.VisibleIndex = 9
        '
        'GTourtype
        '
        Me.GTourtype.Caption = "Tour Type"
        Me.GTourtype.FieldName = "TOURTYPE"
        Me.GTourtype.Name = "GTourtype"
        Me.GTourtype.Visible = True
        Me.GTourtype.VisibleIndex = 10
        '
        'Gpkgcostadult
        '
        Me.Gpkgcostadult.Caption = "Pkg Cost Adult"
        Me.Gpkgcostadult.FieldName = "PKGADULT"
        Me.Gpkgcostadult.Name = "Gpkgcostadult"
        Me.Gpkgcostadult.Visible = True
        Me.Gpkgcostadult.VisibleIndex = 11
        '
        'Gpkgcostchild
        '
        Me.Gpkgcostchild.Caption = "Pkg Cost Child"
        Me.Gpkgcostchild.FieldName = "PKGCHILD"
        Me.Gpkgcostchild.Name = "Gpkgcostchild"
        Me.Gpkgcostchild.Visible = True
        Me.Gpkgcostchild.VisibleIndex = 12
        '
        'Gpkgcostinfant
        '
        Me.Gpkgcostinfant.Caption = "Pkg Cost Infant"
        Me.Gpkgcostinfant.FieldName = "PKGINFANT"
        Me.Gpkgcostinfant.Name = "Gpkgcostinfant"
        Me.Gpkgcostinfant.Visible = True
        Me.Gpkgcostinfant.VisibleIndex = 13
        '
        'Gprofitadult
        '
        Me.Gprofitadult.Caption = "Profit Adult"
        Me.Gprofitadult.FieldName = "PROFITADULT"
        Me.Gprofitadult.Name = "Gprofitadult"
        Me.Gprofitadult.Visible = True
        Me.Gprofitadult.VisibleIndex = 14
        '
        'Gprofitchild
        '
        Me.Gprofitchild.Caption = "Profit Child"
        Me.Gprofitchild.FieldName = "PROFITCHILD"
        Me.Gprofitchild.Name = "Gprofitchild"
        Me.Gprofitchild.Visible = True
        Me.Gprofitchild.VisibleIndex = 15
        '
        'Gprofitinfant
        '
        Me.Gprofitinfant.Caption = "Profit Infant"
        Me.Gprofitinfant.FieldName = "PROFITINFANT"
        Me.Gprofitinfant.Name = "Gprofitinfant"
        Me.Gprofitinfant.Visible = True
        Me.Gprofitinfant.VisibleIndex = 16
        '
        'GDecpkgadult
        '
        Me.GDecpkgadult.Caption = "dec Adult Pkg"
        Me.GDecpkgadult.FieldName = "DECPKGADULT"
        Me.GDecpkgadult.Name = "GDecpkgadult"
        Me.GDecpkgadult.Visible = True
        Me.GDecpkgadult.VisibleIndex = 17
        '
        'GDecpkgchild
        '
        Me.GDecpkgchild.Caption = "Dec Child Pkg"
        Me.GDecpkgchild.FieldName = "DECPKGCHILD"
        Me.GDecpkgchild.Name = "GDecpkgchild"
        Me.GDecpkgchild.Visible = True
        Me.GDecpkgchild.VisibleIndex = 18
        '
        'GDecpkginfant
        '
        Me.GDecpkginfant.Caption = "Dec Infant Pkg"
        Me.GDecpkginfant.FieldName = "DECPKGINFANT"
        Me.GDecpkginfant.Name = "GDecpkginfant"
        Me.GDecpkginfant.Visible = True
        Me.GDecpkginfant.VisibleIndex = 19
        '
        'GDeccostadult
        '
        Me.GDeccostadult.Caption = "Dec Adult Cost "
        Me.GDeccostadult.FieldName = "DECADULT"
        Me.GDeccostadult.Name = "GDeccostadult"
        Me.GDeccostadult.Visible = True
        Me.GDeccostadult.VisibleIndex = 20
        '
        'GDeccostchild
        '
        Me.GDeccostchild.Caption = "Dec Cost Child"
        Me.GDeccostchild.FieldName = "DECCHILD"
        Me.GDeccostchild.Name = "GDeccostchild"
        Me.GDeccostchild.Visible = True
        Me.GDeccostchild.VisibleIndex = 21
        '
        'GDeccostinfant
        '
        Me.GDeccostinfant.Caption = "Dec Cost Infant"
        Me.GDeccostinfant.FieldName = "DECINFANT"
        Me.GDeccostinfant.Name = "GDeccostinfant"
        Me.GDeccostinfant.Visible = True
        Me.GDeccostinfant.VisibleIndex = 22
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.toolStripSeparator, Me.ExcelExport, Me.ToolStripSeparator2, Me.PRINTTOOL})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1161, 25)
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
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(20, 44)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(153, 14)
        Me.lbl.TabIndex = 251
        Me.lbl.Text = "Select a Voucher to Change"
        '
        'TourDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1161, 586)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "TourDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "TourDetails"
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
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents gsrno As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExcelExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PRINTTOOL As System.Windows.Forms.ToolStripButton
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents Gdate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTourname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Ggrstrength As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNodays As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Gstartdate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Genddate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Gvisaembassy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Gportofentry As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFaizeno As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTourtype As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Gpkgcostadult As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Gpkgcostchild As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Gpkgcostinfant As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Gprofitadult As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Gprofitchild As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Gprofitinfant As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDecpkgadult As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDecpkgchild As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDecpkginfant As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDeccostadult As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDeccostchild As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDeccostinfant As DevExpress.XtraGrid.Columns.GridColumn
End Class
