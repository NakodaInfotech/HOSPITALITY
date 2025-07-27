<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VehicleRateList
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
        Me.components = New System.ComponentModel.Container
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.CMBCITY = New System.Windows.Forms.ComboBox
        Me.TXTNIGHTALLOWANCE = New System.Windows.Forms.TextBox
        Me.TXTALLOWANCE = New System.Windows.Forms.TextBox
        Me.TXTKMS = New System.Windows.Forms.TextBox
        Me.TXTHRRATE = New System.Windows.Forms.TextBox
        Me.TXTKMRATE = New System.Windows.Forms.TextBox
        Me.TXTADD = New System.Windows.Forms.TextBox
        Me.CMBCODE = New System.Windows.Forms.ComboBox
        Me.CMBTYPE = New System.Windows.Forms.ComboBox
        Me.CMBVEHICLENAME = New System.Windows.Forms.ComboBox
        Me.TXTRATE = New System.Windows.Forms.TextBox
        Me.CMBNAME = New System.Windows.Forms.ComboBox
        Me.TXTNO = New System.Windows.Forms.TextBox
        Me.CMDEXIT = New System.Windows.Forms.Button
        Me.CMDDELETE = New System.Windows.Forms.Button
        Me.CMDEDIT = New System.Windows.Forms.Button
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GID = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GVEHICLE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GLEDGER = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCITY = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTYPE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GKMS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GALLOWANCE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GNIGHTALLOWANCE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GRATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GPERHRRATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GKMRATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMBCITY)
        Me.BlendPanel1.Controls.Add(Me.TXTNIGHTALLOWANCE)
        Me.BlendPanel1.Controls.Add(Me.TXTALLOWANCE)
        Me.BlendPanel1.Controls.Add(Me.TXTKMS)
        Me.BlendPanel1.Controls.Add(Me.TXTHRRATE)
        Me.BlendPanel1.Controls.Add(Me.TXTKMRATE)
        Me.BlendPanel1.Controls.Add(Me.TXTADD)
        Me.BlendPanel1.Controls.Add(Me.CMBCODE)
        Me.BlendPanel1.Controls.Add(Me.CMBTYPE)
        Me.BlendPanel1.Controls.Add(Me.CMBVEHICLENAME)
        Me.BlendPanel1.Controls.Add(Me.TXTRATE)
        Me.BlendPanel1.Controls.Add(Me.CMBNAME)
        Me.BlendPanel1.Controls.Add(Me.TXTNO)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Controls.Add(Me.CMDDELETE)
        Me.BlendPanel1.Controls.Add(Me.CMDEDIT)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1136, 572)
        Me.BlendPanel1.TabIndex = 0
        '
        'CMBCITY
        '
        Me.CMBCITY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCITY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCITY.BackColor = System.Drawing.Color.White
        Me.CMBCITY.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCITY.FormattingEnabled = True
        Me.CMBCITY.Items.AddRange(New Object() {""})
        Me.CMBCITY.Location = New System.Drawing.Point(436, 24)
        Me.CMBCITY.Name = "CMBCITY"
        Me.CMBCITY.Size = New System.Drawing.Size(76, 22)
        Me.CMBCITY.TabIndex = 2
        '
        'TXTNIGHTALLOWANCE
        '
        Me.TXTNIGHTALLOWANCE.BackColor = System.Drawing.Color.White
        Me.TXTNIGHTALLOWANCE.Location = New System.Drawing.Point(753, 24)
        Me.TXTNIGHTALLOWANCE.Name = "TXTNIGHTALLOWANCE"
        Me.TXTNIGHTALLOWANCE.Size = New System.Drawing.Size(100, 23)
        Me.TXTNIGHTALLOWANCE.TabIndex = 6
        Me.TXTNIGHTALLOWANCE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTALLOWANCE
        '
        Me.TXTALLOWANCE.BackColor = System.Drawing.Color.White
        Me.TXTALLOWANCE.Location = New System.Drawing.Point(672, 24)
        Me.TXTALLOWANCE.Name = "TXTALLOWANCE"
        Me.TXTALLOWANCE.Size = New System.Drawing.Size(80, 23)
        Me.TXTALLOWANCE.TabIndex = 5
        Me.TXTALLOWANCE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTKMS
        '
        Me.TXTKMS.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTKMS.Location = New System.Drawing.Point(612, 24)
        Me.TXTKMS.Name = "TXTKMS"
        Me.TXTKMS.Size = New System.Drawing.Size(60, 23)
        Me.TXTKMS.TabIndex = 4
        Me.TXTKMS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTHRRATE
        '
        Me.TXTHRRATE.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTHRRATE.Location = New System.Drawing.Point(923, 24)
        Me.TXTHRRATE.Name = "TXTHRRATE"
        Me.TXTHRRATE.Size = New System.Drawing.Size(70, 23)
        Me.TXTHRRATE.TabIndex = 8
        Me.TXTHRRATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTKMRATE
        '
        Me.TXTKMRATE.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTKMRATE.Location = New System.Drawing.Point(992, 24)
        Me.TXTKMRATE.Name = "TXTKMRATE"
        Me.TXTKMRATE.Size = New System.Drawing.Size(70, 23)
        Me.TXTKMRATE.TabIndex = 9
        Me.TXTKMRATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTADD
        '
        Me.TXTADD.BackColor = System.Drawing.Color.White
        Me.TXTADD.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTADD.ForeColor = System.Drawing.Color.Black
        Me.TXTADD.Location = New System.Drawing.Point(562, 4)
        Me.TXTADD.Name = "TXTADD"
        Me.TXTADD.Size = New System.Drawing.Size(50, 23)
        Me.TXTADD.TabIndex = 650
        Me.TXTADD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTADD.Visible = False
        '
        'CMBCODE
        '
        Me.CMBCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCODE.BackColor = System.Drawing.Color.White
        Me.CMBCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCODE.FormattingEnabled = True
        Me.CMBCODE.Items.AddRange(New Object() {""})
        Me.CMBCODE.Location = New System.Drawing.Point(618, 4)
        Me.CMBCODE.Name = "CMBCODE"
        Me.CMBCODE.Size = New System.Drawing.Size(44, 22)
        Me.CMBCODE.TabIndex = 649
        Me.CMBCODE.Visible = False
        '
        'CMBTYPE
        '
        Me.CMBTYPE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBTYPE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBTYPE.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBTYPE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBTYPE.FormattingEnabled = True
        Me.CMBTYPE.Items.AddRange(New Object() {"LOCAL", "OUTSTATION", "4HRS 40KMS"})
        Me.CMBTYPE.Location = New System.Drawing.Point(512, 24)
        Me.CMBTYPE.Name = "CMBTYPE"
        Me.CMBTYPE.Size = New System.Drawing.Size(100, 22)
        Me.CMBTYPE.TabIndex = 3
        '
        'CMBVEHICLENAME
        '
        Me.CMBVEHICLENAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBVEHICLENAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBVEHICLENAME.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBVEHICLENAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBVEHICLENAME.FormattingEnabled = True
        Me.CMBVEHICLENAME.Items.AddRange(New Object() {""})
        Me.CMBVEHICLENAME.Location = New System.Drawing.Point(36, 24)
        Me.CMBVEHICLENAME.Name = "CMBVEHICLENAME"
        Me.CMBVEHICLENAME.Size = New System.Drawing.Size(120, 22)
        Me.CMBVEHICLENAME.TabIndex = 0
        '
        'TXTRATE
        '
        Me.TXTRATE.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTRATE.Location = New System.Drawing.Point(853, 24)
        Me.TXTRATE.Name = "TXTRATE"
        Me.TXTRATE.Size = New System.Drawing.Size(70, 23)
        Me.TXTRATE.TabIndex = 7
        Me.TXTRATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMBNAME
        '
        Me.CMBNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBNAME.BackColor = System.Drawing.Color.White
        Me.CMBNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBNAME.FormattingEnabled = True
        Me.CMBNAME.Items.AddRange(New Object() {""})
        Me.CMBNAME.Location = New System.Drawing.Point(156, 24)
        Me.CMBNAME.Name = "CMBNAME"
        Me.CMBNAME.Size = New System.Drawing.Size(280, 22)
        Me.CMBNAME.TabIndex = 1
        '
        'TXTNO
        '
        Me.TXTNO.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNO.ForeColor = System.Drawing.Color.Black
        Me.TXTNO.Location = New System.Drawing.Point(34, 3)
        Me.TXTNO.Name = "TXTNO"
        Me.TXTNO.Size = New System.Drawing.Size(50, 23)
        Me.TXTNO.TabIndex = 648
        Me.TXTNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTNO.Visible = False
        '
        'CMDEXIT
        '
        Me.CMDEXIT.Location = New System.Drawing.Point(563, 540)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 12
        Me.CMDEXIT.Text = "E&xit"
        Me.CMDEXIT.UseVisualStyleBackColor = True
        '
        'CMDDELETE
        '
        Me.CMDDELETE.Location = New System.Drawing.Point(477, 540)
        Me.CMDDELETE.Name = "CMDDELETE"
        Me.CMDDELETE.Size = New System.Drawing.Size(80, 28)
        Me.CMDDELETE.TabIndex = 11
        Me.CMDDELETE.Text = "&Delete"
        Me.CMDDELETE.UseVisualStyleBackColor = True
        '
        'CMDEDIT
        '
        Me.CMDEDIT.Location = New System.Drawing.Point(391, 540)
        Me.CMDEDIT.Name = "CMDEDIT"
        Me.CMDEDIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEDIT.TabIndex = 10
        Me.CMDEDIT.Text = "&Edit"
        Me.CMDEDIT.UseVisualStyleBackColor = True
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(18, 47)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1068, 487)
        Me.gridbilldetails.TabIndex = 9
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.gridbill.Appearance.HeaderPanel.Options.UseFont = True
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GID, Me.GVEHICLE, Me.GLEDGER, Me.GCITY, Me.GTYPE, Me.GKMS, Me.GALLOWANCE, Me.GNIGHTALLOWANCE, Me.GRATE, Me.GPERHRRATE, Me.GKMRATE})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsCustomization.AllowColumnMoving = False
        Me.gridbill.OptionsCustomization.AllowColumnResizing = False
        Me.gridbill.OptionsCustomization.AllowGroup = False
        Me.gridbill.OptionsCustomization.AllowQuickHideColumns = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowGroupPanel = False
        '
        'GID
        '
        Me.GID.Caption = "ID"
        Me.GID.FieldName = "ID"
        Me.GID.Name = "GID"
        '
        'GVEHICLE
        '
        Me.GVEHICLE.Caption = "Vehicle Name"
        Me.GVEHICLE.FieldName = "VEHICLENAME"
        Me.GVEHICLE.Name = "GVEHICLE"
        Me.GVEHICLE.Visible = True
        Me.GVEHICLE.VisibleIndex = 0
        Me.GVEHICLE.Width = 120
        '
        'GLEDGER
        '
        Me.GLEDGER.Caption = "Customer Name"
        Me.GLEDGER.FieldName = "NAME"
        Me.GLEDGER.Name = "GLEDGER"
        Me.GLEDGER.Visible = True
        Me.GLEDGER.VisibleIndex = 1
        Me.GLEDGER.Width = 280
        '
        'GCITY
        '
        Me.GCITY.Caption = "City Name"
        Me.GCITY.FieldName = "CITY"
        Me.GCITY.Name = "GCITY"
        Me.GCITY.Visible = True
        Me.GCITY.VisibleIndex = 2
        '
        'GTYPE
        '
        Me.GTYPE.Caption = "Type"
        Me.GTYPE.FieldName = "TYPE"
        Me.GTYPE.Name = "GTYPE"
        Me.GTYPE.Visible = True
        Me.GTYPE.VisibleIndex = 3
        Me.GTYPE.Width = 100
        '
        'GKMS
        '
        Me.GKMS.Caption = "Kms"
        Me.GKMS.DisplayFormat.FormatString = "0"
        Me.GKMS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GKMS.FieldName = "KMS"
        Me.GKMS.Name = "GKMS"
        Me.GKMS.Visible = True
        Me.GKMS.VisibleIndex = 4
        Me.GKMS.Width = 60
        '
        'GALLOWANCE
        '
        Me.GALLOWANCE.Caption = "Allowance"
        Me.GALLOWANCE.DisplayFormat.FormatString = "0.00"
        Me.GALLOWANCE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GALLOWANCE.FieldName = "ALLOWANCE"
        Me.GALLOWANCE.Name = "GALLOWANCE"
        Me.GALLOWANCE.Visible = True
        Me.GALLOWANCE.VisibleIndex = 5
        Me.GALLOWANCE.Width = 80
        '
        'GNIGHTALLOWANCE
        '
        Me.GNIGHTALLOWANCE.Caption = "Ngt Allowance"
        Me.GNIGHTALLOWANCE.DisplayFormat.FormatString = "0.00"
        Me.GNIGHTALLOWANCE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GNIGHTALLOWANCE.FieldName = "NIGHTALLOWANCE"
        Me.GNIGHTALLOWANCE.Name = "GNIGHTALLOWANCE"
        Me.GNIGHTALLOWANCE.Visible = True
        Me.GNIGHTALLOWANCE.VisibleIndex = 6
        Me.GNIGHTALLOWANCE.Width = 100
        '
        'GRATE
        '
        Me.GRATE.Caption = "Rate"
        Me.GRATE.DisplayFormat.FormatString = "0.00"
        Me.GRATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GRATE.FieldName = "RATE"
        Me.GRATE.Name = "GRATE"
        Me.GRATE.Visible = True
        Me.GRATE.VisibleIndex = 7
        Me.GRATE.Width = 70
        '
        'GPERHRRATE
        '
        Me.GPERHRRATE.Caption = "Hr Rate"
        Me.GPERHRRATE.DisplayFormat.FormatString = "0.00"
        Me.GPERHRRATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPERHRRATE.FieldName = "HRRATE"
        Me.GPERHRRATE.Name = "GPERHRRATE"
        Me.GPERHRRATE.Visible = True
        Me.GPERHRRATE.VisibleIndex = 8
        Me.GPERHRRATE.Width = 70
        '
        'GKMRATE
        '
        Me.GKMRATE.Caption = "Km Rate"
        Me.GKMRATE.DisplayFormat.FormatString = "0.00"
        Me.GKMRATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GKMRATE.FieldName = "KMRATE"
        Me.GKMRATE.Name = "GKMRATE"
        Me.GKMRATE.Visible = True
        Me.GKMRATE.VisibleIndex = 9
        Me.GKMRATE.Width = 70
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'VehicleRateList
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1136, 572)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "VehicleRateList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Vehicle Rate List"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents TXTNO As System.Windows.Forms.TextBox
    Friend WithEvents CMDEXIT As System.Windows.Forms.Button
    Friend WithEvents CMDDELETE As System.Windows.Forms.Button
    Friend WithEvents CMDEDIT As System.Windows.Forms.Button
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GVEHICLE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLEDGER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMBVEHICLENAME As System.Windows.Forms.ComboBox
    Friend WithEvents TXTRATE As System.Windows.Forms.TextBox
    Friend WithEvents CMBNAME As System.Windows.Forms.ComboBox
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents CMBTYPE As System.Windows.Forms.ComboBox
    Friend WithEvents GTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TXTADD As System.Windows.Forms.TextBox
    Friend WithEvents CMBCODE As System.Windows.Forms.ComboBox
    Friend WithEvents GPERHRRATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GKMRATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TXTHRRATE As System.Windows.Forms.TextBox
    Friend WithEvents TXTKMRATE As System.Windows.Forms.TextBox
    Friend WithEvents TXTKMS As System.Windows.Forms.TextBox
    Friend WithEvents GKMS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GALLOWANCE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNIGHTALLOWANCE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TXTNIGHTALLOWANCE As System.Windows.Forms.TextBox
    Friend WithEvents TXTALLOWANCE As System.Windows.Forms.TextBox
    Friend WithEvents GCITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMBCITY As System.Windows.Forms.ComboBox
End Class
