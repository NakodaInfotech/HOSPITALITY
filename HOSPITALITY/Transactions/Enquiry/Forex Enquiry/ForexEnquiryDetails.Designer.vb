<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ForexEnquiryDetails
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
        Me.GFOREXENQNO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GGUESTNAME = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GBUYSELL = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GSOURCE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GENQHANDELEDBY = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GAGENT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GSTATUS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCURRENCY = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GROE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCURRENCYAMT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GAMTINR = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GSTAX = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GOTHERCHGSNAME = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GOTHERCHGS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GROUNDOFF = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GGTOTAL = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GRETURNDATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GREMARKS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCLOSEREMARKS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.PBPHOTO = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
        Me.CHKDONE = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TOOLEXCEL = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.TOOLREFRESH = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.CMDEXIT = New System.Windows.Forms.Button
        Me.CMDEDIT = New System.Windows.Forms.Button
        Me.CMDADD = New System.Windows.Forms.Button
        Me.GCOMM = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GPRODUCT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBPHOTO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CHKDONE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Controls.Add(Me.CMDEDIT)
        Me.BlendPanel1.Controls.Add(Me.CMDADD)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1106, 577)
        Me.BlendPanel1.TabIndex = 8
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(20, 42)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.PBPHOTO, Me.CHKDONE})
        Me.gridbilldetails.Size = New System.Drawing.Size(1068, 495)
        Me.gridbilldetails.TabIndex = 321
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.gridbill.Appearance.HeaderPanel.Options.UseFont = True
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GFOREXENQNO, Me.GDATE, Me.GGUESTNAME, Me.GBUYSELL, Me.GSOURCE, Me.GENQHANDELEDBY, Me.GAGENT, Me.GSTATUS, Me.GPRODUCT, Me.GCURRENCY, Me.GROE, Me.GCURRENCYAMT, Me.GAMTINR, Me.GSTAX, Me.GOTHERCHGSNAME, Me.GOTHERCHGS, Me.GROUNDOFF, Me.GGTOTAL, Me.GRETURNDATE, Me.GCOMM, Me.GREMARKS, Me.GCLOSEREMARKS})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsCustomization.AllowRowSizing = True
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        '
        'GFOREXENQNO
        '
        Me.GFOREXENQNO.Caption = "Enq. No."
        Me.GFOREXENQNO.FieldName = "FOREXENQNO"
        Me.GFOREXENQNO.Name = "GFOREXENQNO"
        Me.GFOREXENQNO.Visible = True
        Me.GFOREXENQNO.VisibleIndex = 0
        Me.GFOREXENQNO.Width = 60
        '
        'GDATE
        '
        Me.GDATE.Caption = "Date"
        Me.GDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDATE.FieldName = "DATE"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.Visible = True
        Me.GDATE.VisibleIndex = 1
        '
        'GGUESTNAME
        '
        Me.GGUESTNAME.Caption = "Guest Name"
        Me.GGUESTNAME.FieldName = "GUESTNAME"
        Me.GGUESTNAME.Name = "GGUESTNAME"
        Me.GGUESTNAME.Visible = True
        Me.GGUESTNAME.VisibleIndex = 2
        Me.GGUESTNAME.Width = 200
        '
        'GBUYSELL
        '
        Me.GBUYSELL.Caption = "Buy/Sell"
        Me.GBUYSELL.FieldName = "BUYSELL"
        Me.GBUYSELL.Name = "GBUYSELL"
        Me.GBUYSELL.Visible = True
        Me.GBUYSELL.VisibleIndex = 3
        Me.GBUYSELL.Width = 60
        '
        'GSOURCE
        '
        Me.GSOURCE.Caption = "Source"
        Me.GSOURCE.FieldName = "SOURCE"
        Me.GSOURCE.Name = "GSOURCE"
        Me.GSOURCE.Visible = True
        Me.GSOURCE.VisibleIndex = 4
        Me.GSOURCE.Width = 150
        '
        'GENQHANDELEDBY
        '
        Me.GENQHANDELEDBY.Caption = "Enq. Handled By"
        Me.GENQHANDELEDBY.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GENQHANDELEDBY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GENQHANDELEDBY.FieldName = "ENQHANDELEDBY"
        Me.GENQHANDELEDBY.Name = "GENQHANDELEDBY"
        Me.GENQHANDELEDBY.Visible = True
        Me.GENQHANDELEDBY.VisibleIndex = 5
        Me.GENQHANDELEDBY.Width = 120
        '
        'GAGENT
        '
        Me.GAGENT.Caption = "Agent"
        Me.GAGENT.FieldName = "AGENT"
        Me.GAGENT.Name = "GAGENT"
        Me.GAGENT.Visible = True
        Me.GAGENT.VisibleIndex = 6
        Me.GAGENT.Width = 120
        '
        'GSTATUS
        '
        Me.GSTATUS.Caption = "Status"
        Me.GSTATUS.FieldName = "STATUS"
        Me.GSTATUS.Name = "GSTATUS"
        Me.GSTATUS.Visible = True
        Me.GSTATUS.VisibleIndex = 7
        Me.GSTATUS.Width = 60
        '
        'GCURRENCY
        '
        Me.GCURRENCY.Caption = "Currency"
        Me.GCURRENCY.FieldName = "CURRENCY"
        Me.GCURRENCY.Name = "GCURRENCY"
        Me.GCURRENCY.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GCURRENCY.Visible = True
        Me.GCURRENCY.VisibleIndex = 9
        Me.GCURRENCY.Width = 60
        '
        'GROE
        '
        Me.GROE.Caption = "R.O.E."
        Me.GROE.DisplayFormat.FormatString = "0.00"
        Me.GROE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GROE.FieldName = "ROE"
        Me.GROE.Name = "GROE"
        Me.GROE.Visible = True
        Me.GROE.VisibleIndex = 10
        Me.GROE.Width = 60
        '
        'GCURRENCYAMT
        '
        Me.GCURRENCYAMT.Caption = "Currency Amt."
        Me.GCURRENCYAMT.DisplayFormat.FormatString = "0.000"
        Me.GCURRENCYAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCURRENCYAMT.FieldName = "CURRENCYAMT"
        Me.GCURRENCYAMT.Name = "GCURRENCYAMT"
        Me.GCURRENCYAMT.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GCURRENCYAMT.Visible = True
        Me.GCURRENCYAMT.VisibleIndex = 11
        Me.GCURRENCYAMT.Width = 90
        '
        'GAMTINR
        '
        Me.GAMTINR.Caption = "Amount (INR)"
        Me.GAMTINR.DisplayFormat.FormatString = "0.000"
        Me.GAMTINR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GAMTINR.FieldName = "AMTINR"
        Me.GAMTINR.Name = "GAMTINR"
        Me.GAMTINR.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GAMTINR.Visible = True
        Me.GAMTINR.VisibleIndex = 12
        Me.GAMTINR.Width = 90
        '
        'GSTAX
        '
        Me.GSTAX.Caption = "S. Tax"
        Me.GSTAX.DisplayFormat.FormatString = "0.000"
        Me.GSTAX.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSTAX.FieldName = "STAX"
        Me.GSTAX.Name = "GSTAX"
        Me.GSTAX.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GSTAX.Visible = True
        Me.GSTAX.VisibleIndex = 13
        Me.GSTAX.Width = 60
        '
        'GOTHERCHGSNAME
        '
        Me.GOTHERCHGSNAME.Caption = "Other Chgs Name"
        Me.GOTHERCHGSNAME.FieldName = "OTHERCHGSNAME"
        Me.GOTHERCHGSNAME.Name = "GOTHERCHGSNAME"
        Me.GOTHERCHGSNAME.Visible = True
        Me.GOTHERCHGSNAME.VisibleIndex = 14
        Me.GOTHERCHGSNAME.Width = 120
        '
        'GOTHERCHGS
        '
        Me.GOTHERCHGS.Caption = "Other Chgs."
        Me.GOTHERCHGS.DisplayFormat.FormatString = "0.000"
        Me.GOTHERCHGS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GOTHERCHGS.FieldName = "OTHERCHGS"
        Me.GOTHERCHGS.Name = "GOTHERCHGS"
        Me.GOTHERCHGS.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GOTHERCHGS.Visible = True
        Me.GOTHERCHGS.VisibleIndex = 15
        Me.GOTHERCHGS.Width = 80
        '
        'GROUNDOFF
        '
        Me.GROUNDOFF.Caption = "Round Off"
        Me.GROUNDOFF.DisplayFormat.FormatString = "0.00"
        Me.GROUNDOFF.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GROUNDOFF.FieldName = "ROUNDOFF"
        Me.GROUNDOFF.Name = "GROUNDOFF"
        Me.GROUNDOFF.Visible = True
        Me.GROUNDOFF.VisibleIndex = 16
        Me.GROUNDOFF.Width = 80
        '
        'GGTOTAL
        '
        Me.GGTOTAL.Caption = "Grant Total"
        Me.GGTOTAL.DisplayFormat.FormatString = "0.000"
        Me.GGTOTAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GGTOTAL.FieldName = "GTOTAL"
        Me.GGTOTAL.Name = "GGTOTAL"
        Me.GGTOTAL.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GGTOTAL.Visible = True
        Me.GGTOTAL.VisibleIndex = 17
        Me.GGTOTAL.Width = 80
        '
        'GRETURNDATE
        '
        Me.GRETURNDATE.Caption = "Return Date"
        Me.GRETURNDATE.DisplayFormat.FormatString = "0.00"
        Me.GRETURNDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GRETURNDATE.FieldName = "RETURNDATE"
        Me.GRETURNDATE.Name = "GRETURNDATE"
        Me.GRETURNDATE.Visible = True
        Me.GRETURNDATE.VisibleIndex = 18
        '
        'GREMARKS
        '
        Me.GREMARKS.Caption = "Remarks"
        Me.GREMARKS.DisplayFormat.FormatString = "0.000"
        Me.GREMARKS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GREMARKS.FieldName = "REMARKS"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.Visible = True
        Me.GREMARKS.VisibleIndex = 20
        Me.GREMARKS.Width = 100
        '
        'GCLOSEREMARKS
        '
        Me.GCLOSEREMARKS.Caption = "Close Remarks"
        Me.GCLOSEREMARKS.DisplayFormat.FormatString = "0.00"
        Me.GCLOSEREMARKS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCLOSEREMARKS.FieldName = "CLOSEREMARKS"
        Me.GCLOSEREMARKS.Name = "GCLOSEREMARKS"
        Me.GCLOSEREMARKS.Visible = True
        Me.GCLOSEREMARKS.VisibleIndex = 21
        Me.GCLOSEREMARKS.Width = 100
        '
        'PBPHOTO
        '
        Me.PBPHOTO.Name = "PBPHOTO"
        Me.PBPHOTO.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        '
        'CHKDONE
        '
        Me.CHKDONE.AutoHeight = False
        Me.CHKDONE.Name = "CHKDONE"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TOOLEXCEL, Me.ToolStripSeparator2, Me.TOOLREFRESH, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1106, 25)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TOOLEXCEL
        '
        Me.TOOLEXCEL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLEXCEL.Image = Global.HOSPITALITY.My.Resources.Resources.Excel_icon1
        Me.TOOLEXCEL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLEXCEL.Name = "TOOLEXCEL"
        Me.TOOLEXCEL.Size = New System.Drawing.Size(23, 22)
        Me.TOOLEXCEL.Text = "Print"
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
        'CMDEXIT
        '
        Me.CMDEXIT.Location = New System.Drawing.Point(598, 543)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 2
        Me.CMDEXIT.Text = "E&xit"
        Me.CMDEXIT.UseVisualStyleBackColor = True
        '
        'CMDEDIT
        '
        Me.CMDEDIT.Location = New System.Drawing.Point(513, 543)
        Me.CMDEDIT.Name = "CMDEDIT"
        Me.CMDEDIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEDIT.TabIndex = 1
        Me.CMDEDIT.Text = "&Edit"
        Me.CMDEDIT.UseVisualStyleBackColor = True
        '
        'CMDADD
        '
        Me.CMDADD.Location = New System.Drawing.Point(428, 543)
        Me.CMDADD.Name = "CMDADD"
        Me.CMDADD.Size = New System.Drawing.Size(80, 28)
        Me.CMDADD.TabIndex = 0
        Me.CMDADD.Text = "&Add New"
        Me.CMDADD.UseVisualStyleBackColor = True
        '
        'GCOMM
        '
        Me.GCOMM.Caption = "Comm"
        Me.GCOMM.DisplayFormat.FormatString = "0.00"
        Me.GCOMM.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCOMM.FieldName = "COMM"
        Me.GCOMM.Name = "GCOMM"
        Me.GCOMM.Visible = True
        Me.GCOMM.VisibleIndex = 19
        '
        'GPRODUCT
        '
        Me.GPRODUCT.Caption = "Product"
        Me.GPRODUCT.FieldName = "PRODUCT"
        Me.GPRODUCT.Name = "GPRODUCT"
        Me.GPRODUCT.Visible = True
        Me.GPRODUCT.VisibleIndex = 8
        '
        'ForexEnquiryDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1106, 577)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "ForexEnquiryDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Forex Enquiry Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBPHOTO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CHKDONE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GFOREXENQNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGUESTNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBUYSELL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSOURCE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GENQHANDELEDBY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAGENT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTATUS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCURRENCY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GROE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCURRENCYAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAMTINR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTAX As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOTHERCHGS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGTOTAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRETURNDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCLOSEREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PBPHOTO As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
    Friend WithEvents CHKDONE As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TOOLEXCEL As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TOOLREFRESH As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CMDEXIT As System.Windows.Forms.Button
    Friend WithEvents CMDEDIT As System.Windows.Forms.Button
    Friend WithEvents CMDADD As System.Windows.Forms.Button
    Friend WithEvents GROUNDOFF As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOTHERCHGSNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPRODUCT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCOMM As DevExpress.XtraGrid.Columns.GridColumn
End Class
