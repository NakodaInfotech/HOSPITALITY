<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MiscEnqGridReport
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
        Me.GMISCENQNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCATEGORY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBOOKER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGUESTNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMOBILENO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GEMAILID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHECKIN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHECKOUT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLEADTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSTATUS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDESTINATION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSOURCE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GENQHANDELEDBY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GENQTRANSTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCLOSEREMARKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GADDRESS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PBPHOTO = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit()
        Me.CHKDONE = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.TOOLEXCEL = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TOOLREFRESH = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CMDEXIT = New System.Windows.Forms.Button()
        Me.GCMPNAME = New DevExpress.XtraGrid.Columns.GridColumn()
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
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1284, 581)
        Me.BlendPanel1.TabIndex = 10
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(14, 35)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.PBPHOTO, Me.CHKDONE})
        Me.gridbilldetails.Size = New System.Drawing.Size(1256, 502)
        Me.gridbilldetails.TabIndex = 321
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.gridbill.Appearance.HeaderPanel.Options.UseFont = True
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GMISCENQNO, Me.GDATE, Me.GCATEGORY, Me.GBOOKER, Me.GGUESTNAME, Me.GMOBILENO, Me.GEMAILID, Me.GCHECKIN, Me.GCHECKOUT, Me.GTYPE, Me.GLEADTYPE, Me.GSTATUS, Me.GDESTINATION, Me.GSOURCE, Me.GENQHANDELEDBY, Me.GENQTRANSTO, Me.GCLOSEREMARKS, Me.GADDRESS, Me.GCMPNAME})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsCustomization.AllowRowSizing = True
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowGroupPanel = False
        '
        'GMISCENQNO
        '
        Me.GMISCENQNO.Caption = "Enq. No."
        Me.GMISCENQNO.FieldName = "MISCNO"
        Me.GMISCENQNO.Name = "GMISCENQNO"
        Me.GMISCENQNO.Visible = True
        Me.GMISCENQNO.VisibleIndex = 0
        Me.GMISCENQNO.Width = 60
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
        'GCATEGORY
        '
        Me.GCATEGORY.Caption = "Company Group"
        Me.GCATEGORY.FieldName = "CATEGORY"
        Me.GCATEGORY.Name = "GCATEGORY"
        Me.GCATEGORY.Visible = True
        Me.GCATEGORY.VisibleIndex = 2
        Me.GCATEGORY.Width = 150
        '
        'GBOOKER
        '
        Me.GBOOKER.Caption = "Booker"
        Me.GBOOKER.FieldName = "BOOKER"
        Me.GBOOKER.Name = "GBOOKER"
        Me.GBOOKER.Visible = True
        Me.GBOOKER.VisibleIndex = 3
        Me.GBOOKER.Width = 150
        '
        'GGUESTNAME
        '
        Me.GGUESTNAME.Caption = "Guest Name"
        Me.GGUESTNAME.FieldName = "GUESTNAME"
        Me.GGUESTNAME.Name = "GGUESTNAME"
        Me.GGUESTNAME.Visible = True
        Me.GGUESTNAME.VisibleIndex = 4
        Me.GGUESTNAME.Width = 200
        '
        'GMOBILENO
        '
        Me.GMOBILENO.Caption = "Mobile No"
        Me.GMOBILENO.FieldName = "MOBILENO"
        Me.GMOBILENO.Name = "GMOBILENO"
        Me.GMOBILENO.Visible = True
        Me.GMOBILENO.VisibleIndex = 5
        Me.GMOBILENO.Width = 100
        '
        'GEMAILID
        '
        Me.GEMAILID.Caption = "Email Id"
        Me.GEMAILID.FieldName = "EMAILID"
        Me.GEMAILID.Name = "GEMAILID"
        Me.GEMAILID.Visible = True
        Me.GEMAILID.VisibleIndex = 6
        Me.GEMAILID.Width = 80
        '
        'GCHECKIN
        '
        Me.GCHECKIN.Caption = "Check In"
        Me.GCHECKIN.FieldName = "CHECKIN"
        Me.GCHECKIN.Name = "GCHECKIN"
        Me.GCHECKIN.Visible = True
        Me.GCHECKIN.VisibleIndex = 7
        '
        'GCHECKOUT
        '
        Me.GCHECKOUT.Caption = "Check Out"
        Me.GCHECKOUT.FieldName = "CHECKOUT"
        Me.GCHECKOUT.Name = "GCHECKOUT"
        Me.GCHECKOUT.Visible = True
        Me.GCHECKOUT.VisibleIndex = 8
        '
        'GTYPE
        '
        Me.GTYPE.Caption = "Enq.Type"
        Me.GTYPE.FieldName = "TYPE"
        Me.GTYPE.Name = "GTYPE"
        Me.GTYPE.Visible = True
        Me.GTYPE.VisibleIndex = 9
        Me.GTYPE.Width = 100
        '
        'GLEADTYPE
        '
        Me.GLEADTYPE.Caption = "Lead Type"
        Me.GLEADTYPE.FieldName = "LEADTYPE"
        Me.GLEADTYPE.Name = "GLEADTYPE"
        Me.GLEADTYPE.Visible = True
        Me.GLEADTYPE.VisibleIndex = 10
        '
        'GSTATUS
        '
        Me.GSTATUS.Caption = "Status"
        Me.GSTATUS.FieldName = "STATUS"
        Me.GSTATUS.Name = "GSTATUS"
        Me.GSTATUS.Visible = True
        Me.GSTATUS.VisibleIndex = 11
        Me.GSTATUS.Width = 90
        '
        'GDESTINATION
        '
        Me.GDESTINATION.Caption = "Destination"
        Me.GDESTINATION.FieldName = "CITY"
        Me.GDESTINATION.Name = "GDESTINATION"
        Me.GDESTINATION.Visible = True
        Me.GDESTINATION.VisibleIndex = 12
        Me.GDESTINATION.Width = 120
        '
        'GSOURCE
        '
        Me.GSOURCE.Caption = "Source"
        Me.GSOURCE.FieldName = "SOURCE"
        Me.GSOURCE.Name = "GSOURCE"
        Me.GSOURCE.Visible = True
        Me.GSOURCE.VisibleIndex = 13
        Me.GSOURCE.Width = 150
        '
        'GENQHANDELEDBY
        '
        Me.GENQHANDELEDBY.Caption = "Enq. Handled By"
        Me.GENQHANDELEDBY.FieldName = "BOOKEDBY"
        Me.GENQHANDELEDBY.Name = "GENQHANDELEDBY"
        Me.GENQHANDELEDBY.Visible = True
        Me.GENQHANDELEDBY.VisibleIndex = 14
        Me.GENQHANDELEDBY.Width = 120
        '
        'GENQTRANSTO
        '
        Me.GENQTRANSTO.Caption = "Enq Transferred To"
        Me.GENQTRANSTO.FieldName = "ENQTRANSFERREDTO"
        Me.GENQTRANSTO.Name = "GENQTRANSTO"
        Me.GENQTRANSTO.Visible = True
        Me.GENQTRANSTO.VisibleIndex = 15
        Me.GENQTRANSTO.Width = 120
        '
        'GCLOSEREMARKS
        '
        Me.GCLOSEREMARKS.Caption = "Close Remarks"
        Me.GCLOSEREMARKS.DisplayFormat.FormatString = "0.00"
        Me.GCLOSEREMARKS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCLOSEREMARKS.FieldName = "CLOSEDREMARKS"
        Me.GCLOSEREMARKS.Name = "GCLOSEREMARKS"
        Me.GCLOSEREMARKS.Visible = True
        Me.GCLOSEREMARKS.VisibleIndex = 16
        Me.GCLOSEREMARKS.Width = 100
        '
        'GADDRESS
        '
        Me.GADDRESS.Caption = "Address"
        Me.GADDRESS.FieldName = "ADDRESS"
        Me.GADDRESS.Name = "GADDRESS"
        Me.GADDRESS.Visible = True
        Me.GADDRESS.VisibleIndex = 17
        Me.GADDRESS.Width = 200
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
        Me.ToolStrip1.Size = New System.Drawing.Size(1284, 25)
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
        Me.CMDEXIT.Location = New System.Drawing.Point(602, 543)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 2
        Me.CMDEXIT.Text = "E&xit"
        Me.CMDEXIT.UseVisualStyleBackColor = True
        '
        'GCMPNAME
        '
        Me.GCMPNAME.Caption = "Cmp Name"
        Me.GCMPNAME.FieldName = "CMPNAME"
        Me.GCMPNAME.Name = "GCMPNAME"
        Me.GCMPNAME.Visible = True
        Me.GCMPNAME.VisibleIndex = 18
        Me.GCMPNAME.Width = 300
        '
        'MiscEnqGridReport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1284, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "MiscEnqGridReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Misc Enq Grid Report"
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
    Friend WithEvents GMISCENQNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCATEGORY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBOOKER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGUESTNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMOBILENO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GEMAILID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHECKIN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHECKOUT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLEADTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTATUS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDESTINATION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSOURCE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GENQHANDELEDBY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GENQTRANSTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCLOSEREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GADDRESS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PBPHOTO As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
    Friend WithEvents CHKDONE As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents TOOLEXCEL As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents TOOLREFRESH As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents CMDEXIT As Button
    Friend WithEvents GCMPNAME As DevExpress.XtraGrid.Columns.GridColumn
End Class
