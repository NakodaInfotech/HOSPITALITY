<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AgeingReportGrid
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AgeingReportGrid))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.CMDPRINT = New System.Windows.Forms.Button
        Me.cmdshowdetails = New System.Windows.Forms.Button
        Me.chkdate = New System.Windows.Forms.CheckBox
        Me.dtto = New System.Windows.Forms.DateTimePicker
        Me.lblto = New System.Windows.Forms.Label
        Me.dtfrom = New System.Windows.Forms.DateTimePicker
        Me.lblfrom = New System.Windows.Forms.Label
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.gname = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GBOOKINGNO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GBOOKTYPE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTYPE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GBOOKINGDATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GHOTELNAME = New DevExpress.XtraGrid.Columns.GridColumn
        Me.G30 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.G45 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.G60 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.G75 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.G90 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.G100 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GBOKEDBY = New DevExpress.XtraGrid.Columns.GridColumn
        Me.CHKEDIT = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Me.CMDOK = New System.Windows.Forms.Button
        Me.cmdcancel = New System.Windows.Forms.Button
        Me.lbl = New System.Windows.Forms.Label
        Me.GBILL = New DevExpress.XtraGrid.Columns.GridColumn
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CHKEDIT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMDPRINT)
        Me.BlendPanel1.Controls.Add(Me.cmdshowdetails)
        Me.BlendPanel1.Controls.Add(Me.chkdate)
        Me.BlendPanel1.Controls.Add(Me.dtto)
        Me.BlendPanel1.Controls.Add(Me.lblto)
        Me.BlendPanel1.Controls.Add(Me.dtfrom)
        Me.BlendPanel1.Controls.Add(Me.lblfrom)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1004, 562)
        Me.BlendPanel1.TabIndex = 5
        '
        'CMDPRINT
        '
        Me.CMDPRINT.BackColor = System.Drawing.Color.Transparent
        Me.CMDPRINT.BackgroundImage = CType(resources.GetObject("CMDPRINT.BackgroundImage"), System.Drawing.Image)
        Me.CMDPRINT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CMDPRINT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDPRINT.FlatAppearance.BorderSize = 0
        Me.CMDPRINT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDPRINT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDPRINT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDPRINT.Location = New System.Drawing.Point(25, 9)
        Me.CMDPRINT.Name = "CMDPRINT"
        Me.CMDPRINT.Size = New System.Drawing.Size(25, 21)
        Me.CMDPRINT.TabIndex = 501
        Me.CMDPRINT.UseVisualStyleBackColor = False
        '
        'cmdshowdetails
        '
        Me.cmdshowdetails.BackColor = System.Drawing.Color.Transparent
        Me.cmdshowdetails.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdshowdetails.FlatAppearance.BorderSize = 0
        Me.cmdshowdetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdshowdetails.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdshowdetails.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdshowdetails.Image = CType(resources.GetObject("cmdshowdetails.Image"), System.Drawing.Image)
        Me.cmdshowdetails.Location = New System.Drawing.Point(339, 34)
        Me.cmdshowdetails.Name = "cmdshowdetails"
        Me.cmdshowdetails.Size = New System.Drawing.Size(83, 25)
        Me.cmdshowdetails.TabIndex = 499
        Me.cmdshowdetails.UseVisualStyleBackColor = False
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.Location = New System.Drawing.Point(155, 14)
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
        Me.dtto.Location = New System.Drawing.Point(246, 38)
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
        Me.lblto.Location = New System.Drawing.Point(222, 41)
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
        Me.dtfrom.Location = New System.Drawing.Point(245, 12)
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
        Me.lblfrom.Location = New System.Drawing.Point(207, 15)
        Me.lblfrom.Name = "lblfrom"
        Me.lblfrom.Size = New System.Drawing.Size(34, 14)
        Me.lblfrom.TabIndex = 496
        Me.lblfrom.Text = "From"
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(13, 64)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CHKEDIT})
        Me.gridbilldetails.Size = New System.Drawing.Size(979, 466)
        Me.gridbilldetails.TabIndex = 494
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gname, Me.GBOOKINGNO, Me.GBOOKTYPE, Me.GTYPE, Me.GBOOKINGDATE, Me.GHOTELNAME, Me.G30, Me.G45, Me.G60, Me.G75, Me.G90, Me.G100, Me.GBOKEDBY, Me.GBILL})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        '
        'gname
        '
        Me.gname.Caption = "Name"
        Me.gname.FieldName = "SALELEDGER"
        Me.gname.ImageIndex = 0
        Me.gname.Name = "gname"
        Me.gname.OptionsColumn.AllowEdit = False
        Me.gname.Visible = True
        Me.gname.VisibleIndex = 0
        Me.gname.Width = 200
        '
        'GBOOKINGNO
        '
        Me.GBOOKINGNO.Caption = "Booking No"
        Me.GBOOKINGNO.FieldName = "BOOKINGNO"
        Me.GBOOKINGNO.Name = "GBOOKINGNO"
        Me.GBOOKINGNO.OptionsColumn.AllowEdit = False
        Me.GBOOKINGNO.Visible = True
        Me.GBOOKINGNO.VisibleIndex = 1
        '
        'GBOOKTYPE
        '
        Me.GBOOKTYPE.Caption = "BOOKTYPE"
        Me.GBOOKTYPE.FieldName = "BOOKTYPE"
        Me.GBOOKTYPE.Name = "GBOOKTYPE"
        '
        'GTYPE
        '
        Me.GTYPE.Caption = "TYPE"
        Me.GTYPE.FieldName = "TYPE"
        Me.GTYPE.Name = "GTYPE"
        '
        'GBOOKINGDATE
        '
        Me.GBOOKINGDATE.Caption = "Date"
        Me.GBOOKINGDATE.FieldName = "DATE"
        Me.GBOOKINGDATE.Name = "GBOOKINGDATE"
        Me.GBOOKINGDATE.OptionsColumn.AllowEdit = False
        Me.GBOOKINGDATE.Visible = True
        Me.GBOOKINGDATE.VisibleIndex = 2
        '
        'GHOTELNAME
        '
        Me.GHOTELNAME.Caption = "Hotel Name"
        Me.GHOTELNAME.FieldName = "HOTELNAME"
        Me.GHOTELNAME.ImageIndex = 1
        Me.GHOTELNAME.Name = "GHOTELNAME"
        Me.GHOTELNAME.OptionsColumn.AllowEdit = False
        Me.GHOTELNAME.Visible = True
        Me.GHOTELNAME.VisibleIndex = 3
        Me.GHOTELNAME.Width = 200
        '
        'G30
        '
        Me.G30.Caption = "1-30"
        Me.G30.DisplayFormat.FormatString = "0.00"
        Me.G30.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.G30.FieldName = "30"
        Me.G30.Name = "G30"
        Me.G30.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.G30.Visible = True
        Me.G30.VisibleIndex = 4
        '
        'G45
        '
        Me.G45.Caption = "31-45"
        Me.G45.DisplayFormat.FormatString = "0.00"
        Me.G45.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.G45.FieldName = "45"
        Me.G45.Name = "G45"
        Me.G45.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.G45.Visible = True
        Me.G45.VisibleIndex = 5
        '
        'G60
        '
        Me.G60.Caption = "46-60"
        Me.G60.DisplayFormat.FormatString = "0.00"
        Me.G60.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.G60.FieldName = "60"
        Me.G60.Name = "G60"
        Me.G60.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.G60.Visible = True
        Me.G60.VisibleIndex = 6
        '
        'G75
        '
        Me.G75.Caption = "61-75"
        Me.G75.DisplayFormat.FormatString = "0.00"
        Me.G75.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.G75.FieldName = "75"
        Me.G75.Name = "G75"
        Me.G75.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.G75.Visible = True
        Me.G75.VisibleIndex = 7
        '
        'G90
        '
        Me.G90.Caption = "76-90"
        Me.G90.DisplayFormat.FormatString = "0.00"
        Me.G90.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.G90.FieldName = "90"
        Me.G90.Name = "G90"
        Me.G90.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.G90.Visible = True
        Me.G90.VisibleIndex = 8
        '
        'G100
        '
        Me.G100.Caption = ">90"
        Me.G100.DisplayFormat.FormatString = "0.00"
        Me.G100.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.G100.FieldName = "GREATER"
        Me.G100.Name = "G100"
        Me.G100.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.G100.Visible = True
        Me.G100.VisibleIndex = 9
        '
        'GBOKEDBY
        '
        Me.GBOKEDBY.Caption = "Booked By"
        Me.GBOKEDBY.FieldName = "BOOKEDBY"
        Me.GBOKEDBY.Name = "GBOKEDBY"
        Me.GBOKEDBY.Visible = True
        Me.GBOKEDBY.VisibleIndex = 10
        '
        'CHKEDIT
        '
        Me.CHKEDIT.AutoHeight = False
        Me.CHKEDIT.Name = "CHKEDIT"
        Me.CHKEDIT.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'CMDOK
        '
        Me.CMDOK.BackColor = System.Drawing.Color.Transparent
        Me.CMDOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDOK.FlatAppearance.BorderSize = 0
        Me.CMDOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDOK.Image = CType(resources.GetObject("CMDOK.Image"), System.Drawing.Image)
        Me.CMDOK.Location = New System.Drawing.Point(427, 532)
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
        Me.cmdcancel.Image = CType(resources.GetObject("cmdcancel.Image"), System.Drawing.Image)
        Me.cmdcancel.Location = New System.Drawing.Point(505, 534)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(72, 24)
        Me.cmdcancel.TabIndex = 316
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(20, 47)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(153, 14)
        Me.lbl.TabIndex = 251
        Me.lbl.Text = "Select a Voucher to Change"
        '
        'GBILL
        '
        Me.GBILL.Caption = "BILL"
        Me.GBILL.FieldName = "BILL"
        Me.GBILL.Name = "GBILL"
        '
        'AgeingReportGrid
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1004, 562)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "AgeingReportGrid"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Ageing Report Grid"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CHKEDIT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMDPRINT As System.Windows.Forms.Button
    Friend WithEvents cmdshowdetails As System.Windows.Forms.Button
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblto As System.Windows.Forms.Label
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblfrom As System.Windows.Forms.Label
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents CHKEDIT As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GBOOKINGNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBOOKINGDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GHOTELNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMDOK As System.Windows.Forms.Button
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents G30 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents G45 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents G60 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents G75 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents G90 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents G100 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBOKEDBY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBOOKTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBILL As DevExpress.XtraGrid.Columns.GridColumn
End Class
