<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ledgers
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
        Me.PBEXCEL = New System.Windows.Forms.PictureBox
        Me.gridname = New DevExpress.XtraGrid.GridControl
        Me.gridledger = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCODE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GGROUPNAME = New DevExpress.XtraGrid.Columns.GridColumn
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.Details = New System.Windows.Forms.TabPage
        Me.BlendPanel2 = New VbPowerPack.BlendPanel
        Me.CMDEXIT = New System.Windows.Forms.Button
        Me.chkcopy = New System.Windows.Forms.CheckBox
        Me.CMDSAVE = New System.Windows.Forms.Button
        Me.txtadd2 = New System.Windows.Forms.TextBox
        Me.txtadd1 = New System.Windows.Forms.TextBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.txtnotes = New System.Windows.Forms.TextBox
        Me.Label44 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtadd = New System.Windows.Forms.TextBox
        Me.Label45 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtshipadd = New System.Windows.Forms.TextBox
        Me.cmbemail = New System.Windows.Forms.ComboBox
        Me.cmbcountry = New System.Windows.Forms.ComboBox
        Me.cmbstate = New System.Windows.Forms.ComboBox
        Me.cmbcity = New System.Windows.Forms.ComboBox
        Me.cmbarea = New System.Windows.Forms.ComboBox
        Me.txtcode = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtcusname = New System.Windows.Forms.TextBox
        Me.txtresino = New System.Windows.Forms.TextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtcmpname = New System.Windows.Forms.TextBox
        Me.txtaltno = New System.Windows.Forms.TextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtstd = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.txtcrlimit = New System.Windows.Forms.TextBox
        Me.txtwebsite = New System.Windows.Forms.TextBox
        Me.Label53 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label52 = New System.Windows.Forms.Label
        Me.Label51 = New System.Windows.Forms.Label
        Me.Label49 = New System.Windows.Forms.Label
        Me.Label46 = New System.Windows.Forms.Label
        Me.txtfax = New System.Windows.Forms.TextBox
        Me.txtzipcode = New System.Windows.Forms.TextBox
        Me.txtmobile = New System.Windows.Forms.TextBox
        Me.txtcrdays = New System.Windows.Forms.TextBox
        Me.Label50 = New System.Windows.Forms.Label
        Me.Label40 = New System.Windows.Forms.Label
        Me.txttel1 = New System.Windows.Forms.TextBox
        Me.Label41 = New System.Windows.Forms.Label
        Me.Label43 = New System.Windows.Forms.Label
        Me.Label42 = New System.Windows.Forms.Label
        Me.txtdrcr = New System.Windows.Forms.TextBox
        Me.txtopbal = New System.Windows.Forms.TextBox
        Me.txtgroup = New System.Windows.Forms.TextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.CMBTYPE = New System.Windows.Forms.ComboBox
        Me.BlendPanel1.SuspendLayout()
        CType(Me.PBEXCEL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridname, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridledger, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.Details.SuspendLayout()
        Me.BlendPanel2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.PBEXCEL)
        Me.BlendPanel1.Controls.Add(Me.gridname)
        Me.BlendPanel1.Controls.Add(Me.TabControl1)
        Me.BlendPanel1.Controls.Add(Me.Label21)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1011, 578)
        Me.BlendPanel1.TabIndex = 1
        '
        'PBEXCEL
        '
        Me.PBEXCEL.Image = Global.HOSPITALITY.My.Resources.Resources.Excel_icon
        Me.PBEXCEL.Location = New System.Drawing.Point(782, 23)
        Me.PBEXCEL.Name = "PBEXCEL"
        Me.PBEXCEL.Size = New System.Drawing.Size(25, 25)
        Me.PBEXCEL.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBEXCEL.TabIndex = 240
        Me.PBEXCEL.TabStop = False
        '
        'gridname
        '
        Me.gridname.Location = New System.Drawing.Point(12, 33)
        Me.gridname.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridname.MainView = Me.gridledger
        Me.gridname.Name = "gridname"
        Me.gridname.Size = New System.Drawing.Size(349, 500)
        Me.gridname.TabIndex = 0
        Me.gridname.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridledger})
        '
        'gridledger
        '
        Me.gridledger.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridledger.Appearance.Row.Options.UseFont = True
        Me.gridledger.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GNAME, Me.GCODE, Me.GGROUPNAME})
        Me.gridledger.GridControl = Me.gridname
        Me.gridledger.Name = "gridledger"
        Me.gridledger.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridledger.OptionsBehavior.Editable = False
        Me.gridledger.OptionsCustomization.AllowColumnMoving = False
        Me.gridledger.OptionsCustomization.AllowGroup = False
        Me.gridledger.OptionsView.ColumnAutoWidth = False
        Me.gridledger.OptionsView.ShowAutoFilterRow = True
        Me.gridledger.OptionsView.ShowGroupPanel = False
        '
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 0
        Me.GNAME.Width = 250
        '
        'GCODE
        '
        Me.GCODE.Caption = "Code"
        Me.GCODE.FieldName = "CODE"
        Me.GCODE.Name = "GCODE"
        Me.GCODE.Visible = True
        Me.GCODE.VisibleIndex = 1
        Me.GCODE.Width = 100
        '
        'GGROUPNAME
        '
        Me.GGROUPNAME.Caption = "Group Name"
        Me.GGROUPNAME.FieldName = "GROUPNAME"
        Me.GGROUPNAME.Name = "GGROUPNAME"
        Me.GGROUPNAME.Visible = True
        Me.GGROUPNAME.VisibleIndex = 2
        Me.GGROUPNAME.Width = 100
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.Details)
        Me.TabControl1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(370, 33)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(609, 500)
        Me.TabControl1.TabIndex = 0
        '
        'Details
        '
        Me.Details.Controls.Add(Me.BlendPanel2)
        Me.Details.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Details.Location = New System.Drawing.Point(4, 23)
        Me.Details.Name = "Details"
        Me.Details.Padding = New System.Windows.Forms.Padding(3)
        Me.Details.Size = New System.Drawing.Size(601, 473)
        Me.Details.TabIndex = 0
        Me.Details.Text = "Company Details"
        Me.Details.UseVisualStyleBackColor = True
        '
        'BlendPanel2
        '
        Me.BlendPanel2.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel2.Controls.Add(Me.Label1)
        Me.BlendPanel2.Controls.Add(Me.CMBTYPE)
        Me.BlendPanel2.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel2.Controls.Add(Me.chkcopy)
        Me.BlendPanel2.Controls.Add(Me.CMDSAVE)
        Me.BlendPanel2.Controls.Add(Me.txtadd2)
        Me.BlendPanel2.Controls.Add(Me.txtadd1)
        Me.BlendPanel2.Controls.Add(Me.GroupBox5)
        Me.BlendPanel2.Controls.Add(Me.Label44)
        Me.BlendPanel2.Controls.Add(Me.GroupBox3)
        Me.BlendPanel2.Controls.Add(Me.Label45)
        Me.BlendPanel2.Controls.Add(Me.GroupBox2)
        Me.BlendPanel2.Controls.Add(Me.cmbemail)
        Me.BlendPanel2.Controls.Add(Me.cmbcountry)
        Me.BlendPanel2.Controls.Add(Me.cmbstate)
        Me.BlendPanel2.Controls.Add(Me.cmbcity)
        Me.BlendPanel2.Controls.Add(Me.cmbarea)
        Me.BlendPanel2.Controls.Add(Me.txtcode)
        Me.BlendPanel2.Controls.Add(Me.Label7)
        Me.BlendPanel2.Controls.Add(Me.txtcusname)
        Me.BlendPanel2.Controls.Add(Me.txtresino)
        Me.BlendPanel2.Controls.Add(Me.Label29)
        Me.BlendPanel2.Controls.Add(Me.Label6)
        Me.BlendPanel2.Controls.Add(Me.txtcmpname)
        Me.BlendPanel2.Controls.Add(Me.txtaltno)
        Me.BlendPanel2.Controls.Add(Me.Label31)
        Me.BlendPanel2.Controls.Add(Me.Label5)
        Me.BlendPanel2.Controls.Add(Me.txtstd)
        Me.BlendPanel2.Controls.Add(Me.Label2)
        Me.BlendPanel2.Controls.Add(Me.Label33)
        Me.BlendPanel2.Controls.Add(Me.txtcrlimit)
        Me.BlendPanel2.Controls.Add(Me.txtwebsite)
        Me.BlendPanel2.Controls.Add(Me.Label53)
        Me.BlendPanel2.Controls.Add(Me.Label34)
        Me.BlendPanel2.Controls.Add(Me.Label52)
        Me.BlendPanel2.Controls.Add(Me.Label51)
        Me.BlendPanel2.Controls.Add(Me.Label49)
        Me.BlendPanel2.Controls.Add(Me.Label46)
        Me.BlendPanel2.Controls.Add(Me.txtfax)
        Me.BlendPanel2.Controls.Add(Me.txtzipcode)
        Me.BlendPanel2.Controls.Add(Me.txtmobile)
        Me.BlendPanel2.Controls.Add(Me.txtcrdays)
        Me.BlendPanel2.Controls.Add(Me.Label50)
        Me.BlendPanel2.Controls.Add(Me.Label40)
        Me.BlendPanel2.Controls.Add(Me.txttel1)
        Me.BlendPanel2.Controls.Add(Me.Label41)
        Me.BlendPanel2.Controls.Add(Me.Label43)
        Me.BlendPanel2.Controls.Add(Me.Label42)
        Me.BlendPanel2.Controls.Add(Me.txtdrcr)
        Me.BlendPanel2.Controls.Add(Me.txtopbal)
        Me.BlendPanel2.Controls.Add(Me.txtgroup)
        Me.BlendPanel2.Controls.Add(Me.Label30)
        Me.BlendPanel2.Controls.Add(Me.Label32)
        Me.BlendPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlendPanel2.Location = New System.Drawing.Point(3, 3)
        Me.BlendPanel2.Name = "BlendPanel2"
        Me.BlendPanel2.Size = New System.Drawing.Size(595, 467)
        Me.BlendPanel2.TabIndex = 0
        '
        'CMDEXIT
        '
        Me.CMDEXIT.Location = New System.Drawing.Point(493, 416)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(75, 23)
        Me.CMDEXIT.TabIndex = 23
        Me.CMDEXIT.Text = "&Exit"
        Me.CMDEXIT.UseVisualStyleBackColor = True
        '
        'chkcopy
        '
        Me.chkcopy.AutoSize = True
        Me.chkcopy.BackColor = System.Drawing.Color.Transparent
        Me.chkcopy.ForeColor = System.Drawing.Color.Black
        Me.chkcopy.Location = New System.Drawing.Point(416, 297)
        Me.chkcopy.Name = "chkcopy"
        Me.chkcopy.Size = New System.Drawing.Size(75, 18)
        Me.chkcopy.TabIndex = 468
        Me.chkcopy.Text = "Copy Add"
        Me.chkcopy.UseVisualStyleBackColor = False
        '
        'CMDSAVE
        '
        Me.CMDSAVE.Location = New System.Drawing.Point(390, 416)
        Me.CMDSAVE.Name = "CMDSAVE"
        Me.CMDSAVE.Size = New System.Drawing.Size(75, 23)
        Me.CMDSAVE.TabIndex = 22
        Me.CMDSAVE.Text = "&Save"
        Me.CMDSAVE.UseVisualStyleBackColor = True
        '
        'txtadd2
        '
        Me.txtadd2.BackColor = System.Drawing.Color.White
        Me.txtadd2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtadd2.ForeColor = System.Drawing.Color.DimGray
        Me.txtadd2.Location = New System.Drawing.Point(100, 297)
        Me.txtadd2.Name = "txtadd2"
        Me.txtadd2.Size = New System.Drawing.Size(247, 22)
        Me.txtadd2.TabIndex = 11
        '
        'txtadd1
        '
        Me.txtadd1.BackColor = System.Drawing.Color.White
        Me.txtadd1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtadd1.ForeColor = System.Drawing.Color.DimGray
        Me.txtadd1.Location = New System.Drawing.Point(100, 271)
        Me.txtadd1.Name = "txtadd1"
        Me.txtadd1.Size = New System.Drawing.Size(247, 22)
        Me.txtadd1.TabIndex = 10
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.txtnotes)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(90, 400)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(268, 59)
        Me.GroupBox5.TabIndex = 463
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Remarks"
        '
        'txtnotes
        '
        Me.txtnotes.BackColor = System.Drawing.Color.White
        Me.txtnotes.ForeColor = System.Drawing.Color.DimGray
        Me.txtnotes.Location = New System.Drawing.Point(5, 16)
        Me.txtnotes.Multiline = True
        Me.txtnotes.Name = "txtnotes"
        Me.txtnotes.Size = New System.Drawing.Size(252, 36)
        Me.txtnotes.TabIndex = 0
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.ForeColor = System.Drawing.Color.Black
        Me.Label44.Location = New System.Drawing.Point(37, 299)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(60, 14)
        Me.Label44.TabIndex = 465
        Me.Label44.Text = "Address 2"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.txtadd)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(93, 321)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(265, 77)
        Me.GroupBox3.TabIndex = 461
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Billing Address"
        '
        'txtadd
        '
        Me.txtadd.BackColor = System.Drawing.Color.White
        Me.txtadd.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.txtadd.ForeColor = System.Drawing.Color.DimGray
        Me.txtadd.Location = New System.Drawing.Point(5, 17)
        Me.txtadd.Multiline = True
        Me.txtadd.Name = "txtadd"
        Me.txtadd.Size = New System.Drawing.Size(249, 52)
        Me.txtadd.TabIndex = 0
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.ForeColor = System.Drawing.Color.Black
        Me.Label45.Location = New System.Drawing.Point(37, 273)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(60, 14)
        Me.Label45.TabIndex = 464
        Me.Label45.Text = "Address 1"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.txtshipadd)
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(390, 321)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(186, 77)
        Me.GroupBox2.TabIndex = 462
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Shipping Address"
        '
        'txtshipadd
        '
        Me.txtshipadd.BackColor = System.Drawing.Color.White
        Me.txtshipadd.ForeColor = System.Drawing.Color.DimGray
        Me.txtshipadd.Location = New System.Drawing.Point(5, 17)
        Me.txtshipadd.Multiline = True
        Me.txtshipadd.Name = "txtshipadd"
        Me.txtshipadd.Size = New System.Drawing.Size(173, 52)
        Me.txtshipadd.TabIndex = 0
        '
        'cmbemail
        '
        Me.cmbemail.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbemail.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbemail.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbemail.FormattingEnabled = True
        Me.cmbemail.Location = New System.Drawing.Point(436, 164)
        Me.cmbemail.MaxDropDownItems = 14
        Me.cmbemail.Name = "cmbemail"
        Me.cmbemail.Size = New System.Drawing.Size(132, 22)
        Me.cmbemail.TabIndex = 18
        '
        'cmbcountry
        '
        Me.cmbcountry.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbcountry.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbcountry.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbcountry.FormattingEnabled = True
        Me.cmbcountry.Location = New System.Drawing.Point(100, 164)
        Me.cmbcountry.MaxDropDownItems = 14
        Me.cmbcountry.Name = "cmbcountry"
        Me.cmbcountry.Size = New System.Drawing.Size(132, 22)
        Me.cmbcountry.TabIndex = 6
        '
        'cmbstate
        '
        Me.cmbstate.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbstate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbstate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbstate.FormattingEnabled = True
        Me.cmbstate.Location = New System.Drawing.Point(100, 138)
        Me.cmbstate.MaxDropDownItems = 14
        Me.cmbstate.Name = "cmbstate"
        Me.cmbstate.Size = New System.Drawing.Size(132, 22)
        Me.cmbstate.TabIndex = 5
        '
        'cmbcity
        '
        Me.cmbcity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbcity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbcity.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbcity.FormattingEnabled = True
        Me.cmbcity.Location = New System.Drawing.Point(100, 86)
        Me.cmbcity.MaxDropDownItems = 14
        Me.cmbcity.Name = "cmbcity"
        Me.cmbcity.Size = New System.Drawing.Size(132, 22)
        Me.cmbcity.TabIndex = 3
        '
        'cmbarea
        '
        Me.cmbarea.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbarea.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbarea.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbarea.FormattingEnabled = True
        Me.cmbarea.Location = New System.Drawing.Point(100, 60)
        Me.cmbarea.MaxDropDownItems = 14
        Me.cmbarea.Name = "cmbarea"
        Me.cmbarea.Size = New System.Drawing.Size(132, 22)
        Me.cmbarea.TabIndex = 2
        '
        'txtcode
        '
        Me.txtcode.BackColor = System.Drawing.Color.White
        Me.txtcode.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcode.ForeColor = System.Drawing.Color.DimGray
        Me.txtcode.Location = New System.Drawing.Point(436, 60)
        Me.txtcode.Name = "txtcode"
        Me.txtcode.ReadOnly = True
        Me.txtcode.Size = New System.Drawing.Size(132, 22)
        Me.txtcode.TabIndex = 14
        Me.txtcode.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(395, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 14)
        Me.Label7.TabIndex = 255
        Me.Label7.Text = "Code"
        '
        'txtcusname
        '
        Me.txtcusname.BackColor = System.Drawing.Color.White
        Me.txtcusname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcusname.ForeColor = System.Drawing.Color.DimGray
        Me.txtcusname.Location = New System.Drawing.Point(100, 35)
        Me.txtcusname.Name = "txtcusname"
        Me.txtcusname.ReadOnly = True
        Me.txtcusname.Size = New System.Drawing.Size(230, 22)
        Me.txtcusname.TabIndex = 1
        Me.txtcusname.TabStop = False
        '
        'txtresino
        '
        Me.txtresino.BackColor = System.Drawing.Color.White
        Me.txtresino.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtresino.ForeColor = System.Drawing.Color.DimGray
        Me.txtresino.Location = New System.Drawing.Point(100, 216)
        Me.txtresino.Name = "txtresino"
        Me.txtresino.Size = New System.Drawing.Size(132, 22)
        Me.txtresino.TabIndex = 8
        Me.txtresino.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(6, 13)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(91, 14)
        Me.Label29.TabIndex = 216
        Me.Label29.Text = "Company Name"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(45, 220)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 14)
        Me.Label6.TabIndex = 252
        Me.Label6.Text = "Resi No."
        '
        'txtcmpname
        '
        Me.txtcmpname.BackColor = System.Drawing.Color.White
        Me.txtcmpname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcmpname.ForeColor = System.Drawing.Color.DimGray
        Me.txtcmpname.Location = New System.Drawing.Point(100, 9)
        Me.txtcmpname.Name = "txtcmpname"
        Me.txtcmpname.ReadOnly = True
        Me.txtcmpname.Size = New System.Drawing.Size(230, 22)
        Me.txtcmpname.TabIndex = 0
        Me.txtcmpname.TabStop = False
        '
        'txtaltno
        '
        Me.txtaltno.BackColor = System.Drawing.Color.White
        Me.txtaltno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtaltno.ForeColor = System.Drawing.Color.DimGray
        Me.txtaltno.Location = New System.Drawing.Point(100, 242)
        Me.txtaltno.Name = "txtaltno"
        Me.txtaltno.Size = New System.Drawing.Size(132, 22)
        Me.txtaltno.TabIndex = 9
        Me.txtaltno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.Black
        Me.Label31.Location = New System.Drawing.Point(7, 39)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(90, 14)
        Me.Label31.TabIndex = 217
        Me.Label31.Text = "Concern Person"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(54, 246)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 14)
        Me.Label5.TabIndex = 250
        Me.Label5.Text = "Alt No."
        '
        'txtstd
        '
        Me.txtstd.BackColor = System.Drawing.Color.White
        Me.txtstd.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtstd.ForeColor = System.Drawing.Color.DimGray
        Me.txtstd.Location = New System.Drawing.Point(100, 190)
        Me.txtstd.Name = "txtstd"
        Me.txtstd.Size = New System.Drawing.Size(132, 22)
        Me.txtstd.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(31, 194)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 14)
        Me.Label2.TabIndex = 248
        Me.Label2.Text = "S.T.D. Code"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Black
        Me.Label33.Location = New System.Drawing.Point(50, 168)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(47, 14)
        Me.Label33.TabIndex = 246
        Me.Label33.Text = "Country"
        '
        'txtcrlimit
        '
        Me.txtcrlimit.BackColor = System.Drawing.Color.White
        Me.txtcrlimit.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcrlimit.ForeColor = System.Drawing.Color.DimGray
        Me.txtcrlimit.Location = New System.Drawing.Point(436, 216)
        Me.txtcrlimit.Name = "txtcrlimit"
        Me.txtcrlimit.ReadOnly = True
        Me.txtcrlimit.Size = New System.Drawing.Size(132, 22)
        Me.txtcrlimit.TabIndex = 20
        Me.txtcrlimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtwebsite
        '
        Me.txtwebsite.BackColor = System.Drawing.Color.White
        Me.txtwebsite.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtwebsite.ForeColor = System.Drawing.Color.DimGray
        Me.txtwebsite.Location = New System.Drawing.Point(436, 138)
        Me.txtwebsite.Name = "txtwebsite"
        Me.txtwebsite.Size = New System.Drawing.Size(132, 22)
        Me.txtwebsite.TabIndex = 17
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.ForeColor = System.Drawing.Color.Black
        Me.Label53.Location = New System.Drawing.Point(408, 116)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(25, 14)
        Me.Label53.TabIndex = 227
        Me.Label53.Text = "Fax"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(380, 142)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(53, 14)
        Me.Label34.TabIndex = 244
        Me.Label34.Text = "Website"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.ForeColor = System.Drawing.Color.Black
        Me.Label52.Location = New System.Drawing.Point(387, 90)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(46, 14)
        Me.Label52.TabIndex = 226
        Me.Label52.Text = "Mobile"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.ForeColor = System.Drawing.Color.Black
        Me.Label51.Location = New System.Drawing.Point(384, 194)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(48, 14)
        Me.Label51.TabIndex = 225
        Me.Label51.Text = "Cr. Days"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.ForeColor = System.Drawing.Color.Black
        Me.Label49.Location = New System.Drawing.Point(395, 168)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(38, 14)
        Me.Label49.TabIndex = 228
        Me.Label49.Text = "Email"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.ForeColor = System.Drawing.Color.Black
        Me.Label46.Location = New System.Drawing.Point(383, 220)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(49, 14)
        Me.Label46.TabIndex = 229
        Me.Label46.Text = "Cr. Limit"
        '
        'txtfax
        '
        Me.txtfax.BackColor = System.Drawing.Color.White
        Me.txtfax.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfax.ForeColor = System.Drawing.Color.DimGray
        Me.txtfax.Location = New System.Drawing.Point(436, 112)
        Me.txtfax.Name = "txtfax"
        Me.txtfax.Size = New System.Drawing.Size(132, 22)
        Me.txtfax.TabIndex = 16
        Me.txtfax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtzipcode
        '
        Me.txtzipcode.BackColor = System.Drawing.Color.White
        Me.txtzipcode.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtzipcode.ForeColor = System.Drawing.Color.DimGray
        Me.txtzipcode.Location = New System.Drawing.Point(100, 112)
        Me.txtzipcode.Name = "txtzipcode"
        Me.txtzipcode.Size = New System.Drawing.Size(132, 22)
        Me.txtzipcode.TabIndex = 4
        '
        'txtmobile
        '
        Me.txtmobile.BackColor = System.Drawing.Color.White
        Me.txtmobile.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmobile.ForeColor = System.Drawing.Color.DimGray
        Me.txtmobile.Location = New System.Drawing.Point(436, 86)
        Me.txtmobile.Name = "txtmobile"
        Me.txtmobile.Size = New System.Drawing.Size(132, 22)
        Me.txtmobile.TabIndex = 15
        Me.txtmobile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtcrdays
        '
        Me.txtcrdays.BackColor = System.Drawing.Color.White
        Me.txtcrdays.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcrdays.ForeColor = System.Drawing.Color.DimGray
        Me.txtcrdays.Location = New System.Drawing.Point(436, 190)
        Me.txtcrdays.Name = "txtcrdays"
        Me.txtcrdays.ReadOnly = True
        Me.txtcrdays.Size = New System.Drawing.Size(132, 22)
        Me.txtcrdays.TabIndex = 19
        Me.txtcrdays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.ForeColor = System.Drawing.Color.Black
        Me.Label50.Location = New System.Drawing.Point(392, 246)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(41, 14)
        Me.Label50.TabIndex = 224
        Me.Label50.Text = "Phone"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.Color.Black
        Me.Label40.Location = New System.Drawing.Point(62, 142)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(35, 14)
        Me.Label40.TabIndex = 239
        Me.Label40.Text = "State"
        '
        'txttel1
        '
        Me.txttel1.BackColor = System.Drawing.Color.White
        Me.txttel1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttel1.ForeColor = System.Drawing.Color.DimGray
        Me.txttel1.Location = New System.Drawing.Point(436, 242)
        Me.txttel1.Name = "txttel1"
        Me.txttel1.Size = New System.Drawing.Size(132, 22)
        Me.txttel1.TabIndex = 21
        Me.txttel1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.Black
        Me.Label41.Location = New System.Drawing.Point(43, 116)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(54, 14)
        Me.Label41.TabIndex = 238
        Me.Label41.Text = "Zip Code"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.ForeColor = System.Drawing.Color.Black
        Me.Label43.Location = New System.Drawing.Point(65, 64)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(32, 14)
        Me.Label43.TabIndex = 236
        Me.Label43.Text = "Area"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.Black
        Me.Label42.Location = New System.Drawing.Point(71, 90)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(26, 14)
        Me.Label42.TabIndex = 237
        Me.Label42.Text = "City"
        '
        'txtdrcr
        '
        Me.txtdrcr.BackColor = System.Drawing.Color.White
        Me.txtdrcr.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdrcr.ForeColor = System.Drawing.Color.DimGray
        Me.txtdrcr.Location = New System.Drawing.Point(537, 35)
        Me.txtdrcr.Name = "txtdrcr"
        Me.txtdrcr.ReadOnly = True
        Me.txtdrcr.Size = New System.Drawing.Size(31, 22)
        Me.txtdrcr.TabIndex = 254
        Me.txtdrcr.TabStop = False
        Me.txtdrcr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtopbal
        '
        Me.txtopbal.BackColor = System.Drawing.Color.White
        Me.txtopbal.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtopbal.ForeColor = System.Drawing.Color.DimGray
        Me.txtopbal.Location = New System.Drawing.Point(436, 35)
        Me.txtopbal.Name = "txtopbal"
        Me.txtopbal.ReadOnly = True
        Me.txtopbal.Size = New System.Drawing.Size(101, 22)
        Me.txtopbal.TabIndex = 13
        Me.txtopbal.TabStop = False
        Me.txtopbal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtgroup
        '
        Me.txtgroup.BackColor = System.Drawing.Color.White
        Me.txtgroup.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtgroup.ForeColor = System.Drawing.Color.DimGray
        Me.txtgroup.Location = New System.Drawing.Point(436, 9)
        Me.txtgroup.Name = "txtgroup"
        Me.txtgroup.ReadOnly = True
        Me.txtgroup.Size = New System.Drawing.Size(132, 22)
        Me.txtgroup.TabIndex = 12
        Me.txtgroup.TabStop = False
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(393, 13)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(40, 14)
        Me.Label30.TabIndex = 220
        Me.Label30.Text = "Group"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Black
        Me.Label32.Location = New System.Drawing.Point(387, 39)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(46, 14)
        Me.Label32.TabIndex = 222
        Me.Label32.Text = "Op. Bal"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(15, 13)
        Me.Label21.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(175, 14)
        Me.Label21.TabIndex = 232
        Me.Label21.Text = "Double Click on Account to Edit"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(403, 273)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 14)
        Me.Label1.TabIndex = 732
        Me.Label1.Text = "Type"
        '
        'CMBTYPE
        '
        Me.CMBTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBTYPE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBTYPE.FormattingEnabled = True
        Me.CMBTYPE.Items.AddRange(New Object() {"Agent", "Walk In", "Hotel"})
        Me.CMBTYPE.Location = New System.Drawing.Point(436, 269)
        Me.CMBTYPE.MaxDropDownItems = 14
        Me.CMBTYPE.Name = "CMBTYPE"
        Me.CMBTYPE.Size = New System.Drawing.Size(132, 22)
        Me.CMBTYPE.TabIndex = 731
        '
        'Ledgers
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1011, 578)
        Me.Controls.Add(Me.BlendPanel1)
        Me.KeyPreview = True
        Me.Name = "Ledgers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Ledgers"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.PBEXCEL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridname, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridledger, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.Details.ResumeLayout(False)
        Me.BlendPanel2.ResumeLayout(False)
        Me.BlendPanel2.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents PBEXCEL As System.Windows.Forms.PictureBox
    Private WithEvents gridname As DevExpress.XtraGrid.GridControl
    Private WithEvents gridledger As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGROUPNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Details As System.Windows.Forms.TabPage
    Friend WithEvents BlendPanel2 As VbPowerPack.BlendPanel
    Friend WithEvents txtcode As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtcusname As System.Windows.Forms.TextBox
    Friend WithEvents txtresino As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtcmpname As System.Windows.Forms.TextBox
    Friend WithEvents txtaltno As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtstd As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtcrlimit As System.Windows.Forms.TextBox
    Friend WithEvents txtwebsite As System.Windows.Forms.TextBox
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents txtfax As System.Windows.Forms.TextBox
    Friend WithEvents txtzipcode As System.Windows.Forms.TextBox
    Friend WithEvents txtmobile As System.Windows.Forms.TextBox
    Friend WithEvents txtcrdays As System.Windows.Forms.TextBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents txttel1 As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents txtdrcr As System.Windows.Forms.TextBox
    Friend WithEvents txtopbal As System.Windows.Forms.TextBox
    Friend WithEvents txtgroup As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cmbemail As System.Windows.Forms.ComboBox
    Friend WithEvents cmbcountry As System.Windows.Forms.ComboBox
    Friend WithEvents cmbstate As System.Windows.Forms.ComboBox
    Friend WithEvents cmbcity As System.Windows.Forms.ComboBox
    Friend WithEvents cmbarea As System.Windows.Forms.ComboBox
    Friend WithEvents CMDEXIT As System.Windows.Forms.Button
    Friend WithEvents CMDSAVE As System.Windows.Forms.Button
    Friend WithEvents chkcopy As System.Windows.Forms.CheckBox
    Friend WithEvents txtadd2 As System.Windows.Forms.TextBox
    Friend WithEvents txtadd1 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtnotes As System.Windows.Forms.TextBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtadd As System.Windows.Forms.TextBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtshipadd As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CMBTYPE As System.Windows.Forms.ComboBox
End Class
