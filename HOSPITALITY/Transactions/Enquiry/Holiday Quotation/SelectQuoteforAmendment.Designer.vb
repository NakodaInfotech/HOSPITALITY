<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectQuoteforAmendment
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
        Me.GCHK = New DevExpress.XtraGrid.Columns.GridColumn
        Me.CHKC = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Me.gsrno = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gdate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gaccname = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTOURNAME = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GPACKAGEFROM = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GPACKAGETO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gtotalpax = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gtotalsale = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GREMARKS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GQUOTE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GDONE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GREFNO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GUSERNAME = New DevExpress.XtraGrid.Columns.GridColumn
        Me.CMDOK = New System.Windows.Forms.Button
        Me.cmdcancel = New System.Windows.Forms.Button
        Me.lbl = New System.Windows.Forms.Label
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CHKC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1004, 558)
        Me.BlendPanel1.TabIndex = 6
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(15, 36)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CHKC})
        Me.gridbilldetails.Size = New System.Drawing.Size(974, 481)
        Me.gridbilldetails.TabIndex = 493
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCHK, Me.gsrno, Me.gdate, Me.gaccname, Me.GTOURNAME, Me.GPACKAGEFROM, Me.GPACKAGETO, Me.gtotalpax, Me.gtotalsale, Me.GREMARKS, Me.GQUOTE, Me.GDONE, Me.GREFNO, Me.GUSERNAME})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowGroupPanel = False
        '
        'GCHK
        '
        Me.GCHK.ColumnEdit = Me.CHKC
        Me.GCHK.FieldName = "CHK"
        Me.GCHK.Name = "GCHK"
        Me.GCHK.OptionsColumn.ShowCaption = False
        Me.GCHK.Visible = True
        Me.GCHK.VisibleIndex = 0
        Me.GCHK.Width = 40
        '
        'CHKC
        '
        Me.CHKC.AutoHeight = False
        Me.CHKC.Name = "CHKC"
        Me.CHKC.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'gsrno
        '
        Me.gsrno.Caption = "Enquiry No"
        Me.gsrno.FieldName = "ENQNO"
        Me.gsrno.Name = "gsrno"
        Me.gsrno.OptionsColumn.AllowEdit = False
        Me.gsrno.Visible = True
        Me.gsrno.VisibleIndex = 1
        '
        'gdate
        '
        Me.gdate.Caption = "Date"
        Me.gdate.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.gdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.gdate.FieldName = "ENQDATE"
        Me.gdate.Name = "gdate"
        Me.gdate.OptionsColumn.AllowEdit = False
        Me.gdate.Visible = True
        Me.gdate.VisibleIndex = 2
        Me.gdate.Width = 70
        '
        'gaccname
        '
        Me.gaccname.Caption = "Guest Name"
        Me.gaccname.FieldName = "GUESTNAME"
        Me.gaccname.ImageIndex = 0
        Me.gaccname.Name = "gaccname"
        Me.gaccname.OptionsColumn.AllowEdit = False
        Me.gaccname.Visible = True
        Me.gaccname.VisibleIndex = 4
        Me.gaccname.Width = 230
        '
        'GTOURNAME
        '
        Me.GTOURNAME.Caption = "Tour Name"
        Me.GTOURNAME.FieldName = "TOURNAME"
        Me.GTOURNAME.Name = "GTOURNAME"
        Me.GTOURNAME.OptionsColumn.AllowEdit = False
        Me.GTOURNAME.Visible = True
        Me.GTOURNAME.VisibleIndex = 5
        Me.GTOURNAME.Width = 160
        '
        'GPACKAGEFROM
        '
        Me.GPACKAGEFROM.Caption = "From"
        Me.GPACKAGEFROM.FieldName = "PACKAGEFROM"
        Me.GPACKAGEFROM.Name = "GPACKAGEFROM"
        Me.GPACKAGEFROM.OptionsColumn.AllowEdit = False
        Me.GPACKAGEFROM.Visible = True
        Me.GPACKAGEFROM.VisibleIndex = 6
        '
        'GPACKAGETO
        '
        Me.GPACKAGETO.Caption = "To"
        Me.GPACKAGETO.FieldName = "PACKAGETO"
        Me.GPACKAGETO.Name = "GPACKAGETO"
        Me.GPACKAGETO.OptionsColumn.AllowEdit = False
        Me.GPACKAGETO.Visible = True
        Me.GPACKAGETO.VisibleIndex = 7
        '
        'gtotalpax
        '
        Me.gtotalpax.Caption = "Total Pax"
        Me.gtotalpax.FieldName = "TOTALPAX"
        Me.gtotalpax.Name = "gtotalpax"
        Me.gtotalpax.OptionsColumn.AllowEdit = False
        Me.gtotalpax.Visible = True
        Me.gtotalpax.VisibleIndex = 8
        '
        'gtotalsale
        '
        Me.gtotalsale.Caption = "G. Total"
        Me.gtotalsale.FieldName = "GRANDTOTAL"
        Me.gtotalsale.ImageIndex = 1
        Me.gtotalsale.Name = "gtotalsale"
        Me.gtotalsale.OptionsColumn.AllowEdit = False
        Me.gtotalsale.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.gtotalsale.Visible = True
        Me.gtotalsale.VisibleIndex = 9
        Me.gtotalsale.Width = 90
        '
        'GREMARKS
        '
        Me.GREMARKS.Caption = "Remarks"
        Me.GREMARKS.FieldName = "REMARKS"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.OptionsColumn.AllowEdit = False
        Me.GREMARKS.Visible = True
        Me.GREMARKS.VisibleIndex = 10
        Me.GREMARKS.Width = 200
        '
        'GQUOTE
        '
        Me.GQUOTE.Caption = "Quote Pending"
        Me.GQUOTE.FieldName = "QUOTEPENDING"
        Me.GQUOTE.Name = "GQUOTE"
        Me.GQUOTE.OptionsColumn.AllowEdit = False
        Me.GQUOTE.Visible = True
        Me.GQUOTE.VisibleIndex = 11
        Me.GQUOTE.Width = 60
        '
        'GDONE
        '
        Me.GDONE.Caption = "Confirmed"
        Me.GDONE.FieldName = "DONE"
        Me.GDONE.Name = "GDONE"
        Me.GDONE.OptionsColumn.AllowEdit = False
        Me.GDONE.Visible = True
        Me.GDONE.VisibleIndex = 12
        Me.GDONE.Width = 60
        '
        'GREFNO
        '
        Me.GREFNO.Caption = "Ref No"
        Me.GREFNO.FieldName = "REFNO"
        Me.GREFNO.Name = "GREFNO"
        Me.GREFNO.OptionsColumn.AllowEdit = False
        Me.GREFNO.Visible = True
        Me.GREFNO.VisibleIndex = 3
        Me.GREFNO.Width = 70
        '
        'GUSERNAME
        '
        Me.GUSERNAME.Caption = "User Name"
        Me.GUSERNAME.FieldName = "USERNAME"
        Me.GUSERNAME.Name = "GUSERNAME"
        Me.GUSERNAME.OptionsColumn.AllowEdit = False
        Me.GUSERNAME.Visible = True
        Me.GUSERNAME.VisibleIndex = 13
        Me.GUSERNAME.Width = 90
        '
        'CMDOK
        '
        Me.CMDOK.BackColor = System.Drawing.Color.Transparent
        Me.CMDOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDOK.FlatAppearance.BorderSize = 0
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.Black
        Me.CMDOK.Location = New System.Drawing.Point(427, 523)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.RightToLeft = System.Windows.Forms.RightToLeft.No
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
        Me.cmdcancel.Location = New System.Drawing.Point(513, 523)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdcancel.Size = New System.Drawing.Size(80, 28)
        Me.cmdcancel.TabIndex = 316
        Me.cmdcancel.Text = "E&xit"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(20, 16)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(151, 14)
        Me.lbl.TabIndex = 251
        Me.lbl.Text = "Select a Voucher to Amend"
        '
        'SelectQuoteforAmendment
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1004, 558)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "SelectQuoteforAmendment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Select Quote for Amendment"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CHKC, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents GREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GQUOTE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDONE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREFNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GUSERNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMDOK As System.Windows.Forms.Button
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents GCHK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CHKC As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
End Class
