<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TargetReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TargetReport))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.CMDOK = New System.Windows.Forms.Button
        Me.dtto = New System.Windows.Forms.DateTimePicker
        Me.lblto = New System.Windows.Forms.Label
        Me.dtfrom = New System.Windows.Forms.DateTimePicker
        Me.lblfrom = New System.Windows.Forms.Label
        Me.CMBMONTH = New System.Windows.Forms.ComboBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.CMDPRINT = New System.Windows.Forms.Button
        Me.cmdshowdetails = New System.Windows.Forms.Button
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GEMPNAME = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTARGET = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GACHIEVED = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GACHIEVEDPER = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GELIGIBILITYPER = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GELIGIBLE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.CHKEDIT = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Me.GINCENTIVES = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GINCENTIVESPER = New DevExpress.XtraGrid.Columns.GridColumn
        Me.cmdcancel = New System.Windows.Forms.Button
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CHKEDIT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.dtto)
        Me.BlendPanel1.Controls.Add(Me.lblto)
        Me.BlendPanel1.Controls.Add(Me.dtfrom)
        Me.BlendPanel1.Controls.Add(Me.lblfrom)
        Me.BlendPanel1.Controls.Add(Me.CMBMONTH)
        Me.BlendPanel1.Controls.Add(Me.Label22)
        Me.BlendPanel1.Controls.Add(Me.CMDPRINT)
        Me.BlendPanel1.Controls.Add(Me.cmdshowdetails)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(890, 562)
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
        Me.CMDOK.Image = CType(resources.GetObject("CMDOK.Image"), System.Drawing.Image)
        Me.CMDOK.Location = New System.Drawing.Point(370, 532)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(72, 26)
        Me.CMDOK.TabIndex = 683
        Me.CMDOK.UseVisualStyleBackColor = False
        '
        'dtto
        '
        Me.dtto.CustomFormat = "dd/MM/yyyy"
        Me.dtto.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(345, 26)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(87, 22)
        Me.dtto.TabIndex = 681
        Me.dtto.Visible = False
        '
        'lblto
        '
        Me.lblto.AutoSize = True
        Me.lblto.BackColor = System.Drawing.Color.Transparent
        Me.lblto.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblto.Location = New System.Drawing.Point(321, 30)
        Me.lblto.Name = "lblto"
        Me.lblto.Size = New System.Drawing.Size(19, 14)
        Me.lblto.TabIndex = 682
        Me.lblto.Text = "To"
        Me.lblto.Visible = False
        '
        'dtfrom
        '
        Me.dtfrom.CustomFormat = "dd/MM/yyyy"
        Me.dtfrom.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfrom.Location = New System.Drawing.Point(344, 0)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(88, 22)
        Me.dtfrom.TabIndex = 680
        Me.dtfrom.Visible = False
        '
        'lblfrom
        '
        Me.lblfrom.AutoSize = True
        Me.lblfrom.BackColor = System.Drawing.Color.Transparent
        Me.lblfrom.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfrom.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblfrom.Location = New System.Drawing.Point(306, 4)
        Me.lblfrom.Name = "lblfrom"
        Me.lblfrom.Size = New System.Drawing.Size(34, 14)
        Me.lblfrom.TabIndex = 679
        Me.lblfrom.Text = "From"
        Me.lblfrom.Visible = False
        '
        'CMBMONTH
        '
        Me.CMBMONTH.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBMONTH.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBMONTH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBMONTH.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBMONTH.FormattingEnabled = True
        Me.CMBMONTH.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.CMBMONTH.Location = New System.Drawing.Point(104, 20)
        Me.CMBMONTH.Name = "CMBMONTH"
        Me.CMBMONTH.Size = New System.Drawing.Size(120, 22)
        Me.CMBMONTH.TabIndex = 677
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(59, 24)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(42, 14)
        Me.Label22.TabIndex = 678
        Me.Label22.Text = "Month"
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
        Me.CMDPRINT.Location = New System.Drawing.Point(26, 20)
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
        Me.cmdshowdetails.Location = New System.Drawing.Point(230, 18)
        Me.cmdshowdetails.Name = "cmdshowdetails"
        Me.cmdshowdetails.Size = New System.Drawing.Size(83, 25)
        Me.cmdshowdetails.TabIndex = 499
        Me.cmdshowdetails.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(25, 49)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CHKEDIT})
        Me.gridbilldetails.Size = New System.Drawing.Size(841, 477)
        Me.gridbilldetails.TabIndex = 494
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GEMPNAME, Me.GTARGET, Me.GACHIEVED, Me.GACHIEVEDPER, Me.GELIGIBILITYPER, Me.GELIGIBLE, Me.GINCENTIVES, Me.GINCENTIVESPER})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        '
        'GEMPNAME
        '
        Me.GEMPNAME.Caption = "Name"
        Me.GEMPNAME.FieldName = "NAME"
        Me.GEMPNAME.Name = "GEMPNAME"
        Me.GEMPNAME.Visible = True
        Me.GEMPNAME.VisibleIndex = 0
        Me.GEMPNAME.Width = 250
        '
        'GTARGET
        '
        Me.GTARGET.Caption = "Target"
        Me.GTARGET.DisplayFormat.FormatString = "0.00"
        Me.GTARGET.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTARGET.FieldName = "TARGET"
        Me.GTARGET.Name = "GTARGET"
        Me.GTARGET.Visible = True
        Me.GTARGET.VisibleIndex = 1
        Me.GTARGET.Width = 80
        '
        'GACHIEVED
        '
        Me.GACHIEVED.Caption = "Achieved"
        Me.GACHIEVED.DisplayFormat.FormatString = "0.00"
        Me.GACHIEVED.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GACHIEVED.FieldName = "ACHIEVED"
        Me.GACHIEVED.Name = "GACHIEVED"
        Me.GACHIEVED.Visible = True
        Me.GACHIEVED.VisibleIndex = 2
        Me.GACHIEVED.Width = 80
        '
        'GACHIEVEDPER
        '
        Me.GACHIEVEDPER.Caption = "% Achieved"
        Me.GACHIEVEDPER.DisplayFormat.FormatString = "0.00"
        Me.GACHIEVEDPER.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GACHIEVEDPER.FieldName = "PERACHIEVED"
        Me.GACHIEVEDPER.Name = "GACHIEVEDPER"
        Me.GACHIEVEDPER.Visible = True
        Me.GACHIEVEDPER.VisibleIndex = 3
        Me.GACHIEVEDPER.Width = 80
        '
        'GELIGIBILITYPER
        '
        Me.GELIGIBILITYPER.Caption = "% Eligibility"
        Me.GELIGIBILITYPER.DisplayFormat.FormatString = "0.00"
        Me.GELIGIBILITYPER.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GELIGIBILITYPER.FieldName = "PERELIGIBILITY"
        Me.GELIGIBILITYPER.Name = "GELIGIBILITYPER"
        Me.GELIGIBILITYPER.Visible = True
        Me.GELIGIBILITYPER.VisibleIndex = 4
        Me.GELIGIBILITYPER.Width = 80
        '
        'GELIGIBLE
        '
        Me.GELIGIBLE.Caption = "Eligible"
        Me.GELIGIBLE.ColumnEdit = Me.CHKEDIT
        Me.GELIGIBLE.FieldName = "ELIGIBLE"
        Me.GELIGIBLE.Name = "GELIGIBLE"
        Me.GELIGIBLE.Visible = True
        Me.GELIGIBLE.VisibleIndex = 5
        Me.GELIGIBLE.Width = 60
        '
        'CHKEDIT
        '
        Me.CHKEDIT.AutoHeight = False
        Me.CHKEDIT.Name = "CHKEDIT"
        Me.CHKEDIT.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'GINCENTIVES
        '
        Me.GINCENTIVES.Caption = "Incentives"
        Me.GINCENTIVES.DisplayFormat.FormatString = "0.00"
        Me.GINCENTIVES.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GINCENTIVES.FieldName = "INCENTIVES"
        Me.GINCENTIVES.Name = "GINCENTIVES"
        Me.GINCENTIVES.Visible = True
        Me.GINCENTIVES.VisibleIndex = 6
        Me.GINCENTIVES.Width = 80
        '
        'GINCENTIVESPER
        '
        Me.GINCENTIVESPER.Caption = "% Incentives"
        Me.GINCENTIVESPER.DisplayFormat.FormatString = "0.00"
        Me.GINCENTIVESPER.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GINCENTIVESPER.FieldName = "PERINCENTIVES"
        Me.GINCENTIVESPER.Name = "GINCENTIVESPER"
        Me.GINCENTIVESPER.Visible = True
        Me.GINCENTIVESPER.VisibleIndex = 7
        Me.GINCENTIVESPER.Width = 80
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
        Me.cmdcancel.Location = New System.Drawing.Point(448, 534)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(72, 24)
        Me.cmdcancel.TabIndex = 316
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'TargetReport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(890, 562)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "TargetReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Target Report"
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
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents CHKEDIT As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Friend WithEvents CMBMONTH As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents GEMPNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTARGET As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GACHIEVED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GACHIEVEDPER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GINCENTIVES As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GINCENTIVESPER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GELIGIBLE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblto As System.Windows.Forms.Label
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblfrom As System.Windows.Forms.Label
    Friend WithEvents GELIGIBILITYPER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMDOK As System.Windows.Forms.Button
End Class
