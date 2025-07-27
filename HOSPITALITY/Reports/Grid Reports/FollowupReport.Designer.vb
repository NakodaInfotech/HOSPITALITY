<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FollowupReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FollowupReport))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TOOLEXCEL = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.TOOLREFRESH = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GENQNO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GGUESTNAME = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTOUR = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GFOLLOWTO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.TXTFOLLOWUP = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
        Me.GSTAGE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.CMBSTAGE = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox
        Me.GNEXTDATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GNARR = New DevExpress.XtraGrid.Columns.GridColumn
        Me.TXTNARRATION = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
        Me.GREMARKS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.CMDSAVE = New System.Windows.Forms.Button
        Me.CMDEXIT = New System.Windows.Forms.Button
        Me.CMDEDIT = New System.Windows.Forms.Button
        Me.DTFOLLOWUPDATE = New System.Windows.Forms.MaskedTextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.ToolStrip1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TXTFOLLOWUP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CMBSTAGE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TXTNARRATION, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BlendPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TOOLEXCEL, Me.ToolStripSeparator2, Me.TOOLREFRESH, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1161, 25)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TOOLEXCEL
        '
        Me.TOOLEXCEL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLEXCEL.Image = Global.HOSPITALITY.My.Resources.Resources.Excel_icon
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
        Me.TOOLREFRESH.Image = CType(resources.GetObject("TOOLREFRESH.Image"), System.Drawing.Image)
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
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(13, 82)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CMBSTAGE, Me.TXTFOLLOWUP, Me.TXTNARRATION})
        Me.gridbilldetails.Size = New System.Drawing.Size(1136, 495)
        Me.gridbilldetails.TabIndex = 321
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill, Me.GridView1})
        '
        'gridbill
        '
        Me.gridbill.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.gridbill.Appearance.HeaderPanel.Options.UseFont = True
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GENQNO, Me.GDATE, Me.GGUESTNAME, Me.GTOUR, Me.GFOLLOWTO, Me.GSTAGE, Me.GNEXTDATE, Me.GNARR, Me.GREMARKS})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridbill.OptionsCustomization.AllowRowSizing = True
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        '
        'GENQNO
        '
        Me.GENQNO.Caption = "Enq. No."
        Me.GENQNO.FieldName = "ENQNO"
        Me.GENQNO.Name = "GENQNO"
        Me.GENQNO.OptionsColumn.AllowEdit = False
        Me.GENQNO.Visible = True
        Me.GENQNO.VisibleIndex = 0
        Me.GENQNO.Width = 60
        '
        'GDATE
        '
        Me.GDATE.Caption = "Date"
        Me.GDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDATE.FieldName = "ENQDATE"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.OptionsColumn.AllowEdit = False
        Me.GDATE.Visible = True
        Me.GDATE.VisibleIndex = 1
        '
        'GGUESTNAME
        '
        Me.GGUESTNAME.Caption = "Guest Name"
        Me.GGUESTNAME.FieldName = "GUESTNAME"
        Me.GGUESTNAME.Name = "GGUESTNAME"
        Me.GGUESTNAME.OptionsColumn.AllowEdit = False
        Me.GGUESTNAME.Visible = True
        Me.GGUESTNAME.VisibleIndex = 2
        Me.GGUESTNAME.Width = 160
        '
        'GTOUR
        '
        Me.GTOUR.Caption = "Tour Name"
        Me.GTOUR.FieldName = "TOUR"
        Me.GTOUR.Name = "GTOUR"
        Me.GTOUR.OptionsColumn.AllowEdit = False
        Me.GTOUR.Visible = True
        Me.GTOUR.VisibleIndex = 3
        Me.GTOUR.Width = 200
        '
        'GFOLLOWTO
        '
        Me.GFOLLOWTO.Caption = "Followup Given To"
        Me.GFOLLOWTO.ColumnEdit = Me.TXTFOLLOWUP
        Me.GFOLLOWTO.FieldName = "FOLLOWTO"
        Me.GFOLLOWTO.MaxWidth = 200
        Me.GFOLLOWTO.Name = "GFOLLOWTO"
        Me.GFOLLOWTO.Visible = True
        Me.GFOLLOWTO.VisibleIndex = 4
        Me.GFOLLOWTO.Width = 200
        '
        'TXTFOLLOWUP
        '
        Me.TXTFOLLOWUP.AutoHeight = False
        Me.TXTFOLLOWUP.MaxLength = 50
        Me.TXTFOLLOWUP.Name = "TXTFOLLOWUP"
        '
        'GSTAGE
        '
        Me.GSTAGE.Caption = "Stage"
        Me.GSTAGE.ColumnEdit = Me.CMBSTAGE
        Me.GSTAGE.FieldName = "STAGE"
        Me.GSTAGE.Name = "GSTAGE"
        Me.GSTAGE.Visible = True
        Me.GSTAGE.VisibleIndex = 5
        '
        'CMBSTAGE
        '
        Me.CMBSTAGE.AutoHeight = False
        Me.CMBSTAGE.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CMBSTAGE.Name = "CMBSTAGE"
        '
        'GNEXTDATE
        '
        Me.GNEXTDATE.Caption = "Next Date"
        Me.GNEXTDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GNEXTDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GNEXTDATE.FieldName = "NEXTDATE"
        Me.GNEXTDATE.Name = "GNEXTDATE"
        Me.GNEXTDATE.Visible = True
        Me.GNEXTDATE.VisibleIndex = 6
        Me.GNEXTDATE.Width = 80
        '
        'GNARR
        '
        Me.GNARR.Caption = "Narration"
        Me.GNARR.ColumnEdit = Me.TXTNARRATION
        Me.GNARR.FieldName = "NARRATION"
        Me.GNARR.MaxWidth = 500
        Me.GNARR.Name = "GNARR"
        Me.GNARR.Visible = True
        Me.GNARR.VisibleIndex = 7
        Me.GNARR.Width = 200
        '
        'TXTNARRATION
        '
        Me.TXTNARRATION.AutoHeight = False
        Me.TXTNARRATION.MaxLength = 500
        Me.TXTNARRATION.Name = "TXTNARRATION"
        '
        'GREMARKS
        '
        Me.GREMARKS.Caption = "Remarks"
        Me.GREMARKS.FieldName = "REMARKS"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.OptionsColumn.AllowEdit = False
        Me.GREMARKS.Visible = True
        Me.GREMARKS.VisibleIndex = 8
        Me.GREMARKS.Width = 250
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.gridbilldetails
        Me.GridView1.Name = "GridView1"
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMDSAVE)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Controls.Add(Me.CMDEDIT)
        Me.BlendPanel1.Controls.Add(Me.DTFOLLOWUPDATE)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1161, 618)
        Me.BlendPanel1.TabIndex = 0
        '
        'CMDSAVE
        '
        Me.CMDSAVE.Location = New System.Drawing.Point(455, 583)
        Me.CMDSAVE.Name = "CMDSAVE"
        Me.CMDSAVE.Size = New System.Drawing.Size(80, 28)
        Me.CMDSAVE.TabIndex = 1
        Me.CMDSAVE.Text = "&Save"
        Me.CMDSAVE.UseVisualStyleBackColor = True
        '
        'CMDEXIT
        '
        Me.CMDEXIT.Location = New System.Drawing.Point(626, 583)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 3
        Me.CMDEXIT.Text = "E&xit"
        Me.CMDEXIT.UseVisualStyleBackColor = True
        '
        'CMDEDIT
        '
        Me.CMDEDIT.Location = New System.Drawing.Point(541, 583)
        Me.CMDEDIT.Name = "CMDEDIT"
        Me.CMDEDIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEDIT.TabIndex = 2
        Me.CMDEDIT.Text = "&Edit"
        Me.CMDEDIT.UseVisualStyleBackColor = True
        '
        'DTFOLLOWUPDATE
        '
        Me.DTFOLLOWUPDATE.AsciiOnly = True
        Me.DTFOLLOWUPDATE.BackColor = System.Drawing.Color.LemonChiffon
        Me.DTFOLLOWUPDATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTFOLLOWUPDATE.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.DTFOLLOWUPDATE.Location = New System.Drawing.Point(113, 50)
        Me.DTFOLLOWUPDATE.Mask = "00/00/0000"
        Me.DTFOLLOWUPDATE.Name = "DTFOLLOWUPDATE"
        Me.DTFOLLOWUPDATE.Size = New System.Drawing.Size(80, 23)
        Me.DTFOLLOWUPDATE.TabIndex = 0
        Me.DTFOLLOWUPDATE.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.DTFOLLOWUPDATE.ValidatingType = GetType(Date)
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(16, 53)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(96, 15)
        Me.Label9.TabIndex = 749
        Me.Label9.Text = "Followup Date : "
        '
        'FollowupReport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1161, 618)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "FollowupReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Package Enquiry Followup Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TXTFOLLOWUP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CMBSTAGE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TXTNARRATION, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TOOLEXCEL As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TOOLREFRESH As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GENQNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGUESTNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DTFOLLOWUPDATE As System.Windows.Forms.MaskedTextBox
    Friend WithEvents GTOUR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMDEXIT As System.Windows.Forms.Button
    Friend WithEvents CMDEDIT As System.Windows.Forms.Button
    Friend WithEvents GFOLLOWTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNEXTDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNARR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMDSAVE As System.Windows.Forms.Button
    Friend WithEvents GSTAGE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMBSTAGE As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents TXTFOLLOWUP As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents TXTNARRATION As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
End Class
