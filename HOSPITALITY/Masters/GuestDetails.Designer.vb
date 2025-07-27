<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GuestDetails
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
        Me.CMDREFRESH = New System.Windows.Forms.Button
        Me.gridname = New DevExpress.XtraGrid.GridControl
        Me.gridledger = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GGUESTNAME = New DevExpress.XtraGrid.Columns.GridColumn
        Me.cmdadd = New System.Windows.Forms.Button
        Me.cmdedit = New System.Windows.Forms.Button
        Me.cmdexit = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.Details = New System.Windows.Forms.TabPage
        Me.BlendPanel2 = New VbPowerPack.BlendPanel
        Me.Label3 = New System.Windows.Forms.Label
        Me.TXTREF = New System.Windows.Forms.TextBox
        Me.DOB = New System.Windows.Forms.DateTimePicker
        Me.chkdob = New System.Windows.Forms.CheckBox
        Me.TXTMEMBERSHIP = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtresino = New System.Windows.Forms.TextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.TXTNAME = New System.Windows.Forms.TextBox
        Me.txtaltno = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtstd = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtcountry = New System.Windows.Forms.TextBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.txtwebsite = New System.Windows.Forms.TextBox
        Me.Label53 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label52 = New System.Windows.Forms.Label
        Me.Label49 = New System.Windows.Forms.Label
        Me.txtstate = New System.Windows.Forms.TextBox
        Me.txtfax = New System.Windows.Forms.TextBox
        Me.txtzipcode = New System.Windows.Forms.TextBox
        Me.txtmobile = New System.Windows.Forms.TextBox
        Me.txtcity = New System.Windows.Forms.TextBox
        Me.txtarea = New System.Windows.Forms.TextBox
        Me.txtemail = New System.Windows.Forms.TextBox
        Me.Label50 = New System.Windows.Forms.Label
        Me.Label40 = New System.Windows.Forms.Label
        Me.txttel1 = New System.Windows.Forms.TextBox
        Me.Label41 = New System.Windows.Forms.Label
        Me.Label43 = New System.Windows.Forms.Label
        Me.Label42 = New System.Windows.Forms.Label
        Me.General = New System.Windows.Forms.TabPage
        Me.BlendPanel4 = New VbPowerPack.BlendPanel
        Me.txtadd2 = New System.Windows.Forms.TextBox
        Me.txtadd1 = New System.Windows.Forms.TextBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.TXTREMARKS = New System.Windows.Forms.TextBox
        Me.Label44 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtadd = New System.Windows.Forms.TextBox
        Me.Label45 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.GUNIQUENO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.BlendPanel1.SuspendLayout()
        CType(Me.PBEXCEL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridname, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridledger, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.Details.SuspendLayout()
        Me.BlendPanel2.SuspendLayout()
        Me.General.SuspendLayout()
        Me.BlendPanel4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.PBEXCEL)
        Me.BlendPanel1.Controls.Add(Me.CMDREFRESH)
        Me.BlendPanel1.Controls.Add(Me.gridname)
        Me.BlendPanel1.Controls.Add(Me.cmdadd)
        Me.BlendPanel1.Controls.Add(Me.cmdedit)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.TabControl1)
        Me.BlendPanel1.Controls.Add(Me.Label21)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1034, 582)
        Me.BlendPanel1.TabIndex = 1
        '
        'PBEXCEL
        '
        Me.PBEXCEL.Image = Global.HOSPITALITY.My.Resources.Resources.Excel_icon
        Me.PBEXCEL.Location = New System.Drawing.Point(809, 22)
        Me.PBEXCEL.Name = "PBEXCEL"
        Me.PBEXCEL.Size = New System.Drawing.Size(25, 25)
        Me.PBEXCEL.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBEXCEL.TabIndex = 450
        Me.PBEXCEL.TabStop = False
        '
        'CMDREFRESH
        '
        Me.CMDREFRESH.BackColor = System.Drawing.Color.Transparent
        Me.CMDREFRESH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDREFRESH.FlatAppearance.BorderSize = 0
        Me.CMDREFRESH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDREFRESH.ForeColor = System.Drawing.Color.Black
        Me.CMDREFRESH.Location = New System.Drawing.Point(842, 20)
        Me.CMDREFRESH.Name = "CMDREFRESH"
        Me.CMDREFRESH.Size = New System.Drawing.Size(80, 28)
        Me.CMDREFRESH.TabIndex = 449
        Me.CMDREFRESH.Text = "&Refresh"
        Me.CMDREFRESH.UseVisualStyleBackColor = False
        '
        'gridname
        '
        Me.gridname.Location = New System.Drawing.Point(18, 33)
        Me.gridname.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridname.MainView = Me.gridledger
        Me.gridname.Name = "gridname"
        Me.gridname.Size = New System.Drawing.Size(467, 503)
        Me.gridname.TabIndex = 315
        Me.gridname.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridledger})
        '
        'gridledger
        '
        Me.gridledger.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridledger.Appearance.Row.Options.UseFont = True
        Me.gridledger.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GGUESTNAME, Me.GUNIQUENO})
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
        'GGUESTNAME
        '
        Me.GGUESTNAME.Caption = "Guest Name"
        Me.GGUESTNAME.FieldName = "NAME"
        Me.GGUESTNAME.Name = "GGUESTNAME"
        Me.GGUESTNAME.Visible = True
        Me.GGUESTNAME.VisibleIndex = 0
        Me.GGUESTNAME.Width = 350
        '
        'cmdadd
        '
        Me.cmdadd.BackColor = System.Drawing.Color.Transparent
        Me.cmdadd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdadd.FlatAppearance.BorderSize = 0
        Me.cmdadd.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdadd.ForeColor = System.Drawing.Color.Black
        Me.cmdadd.Location = New System.Drawing.Point(434, 542)
        Me.cmdadd.Name = "cmdadd"
        Me.cmdadd.Size = New System.Drawing.Size(80, 28)
        Me.cmdadd.TabIndex = 2
        Me.cmdadd.Text = "&Add New"
        Me.cmdadd.UseVisualStyleBackColor = False
        '
        'cmdedit
        '
        Me.cmdedit.BackColor = System.Drawing.Color.Transparent
        Me.cmdedit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdedit.FlatAppearance.BorderSize = 0
        Me.cmdedit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdedit.ForeColor = System.Drawing.Color.Black
        Me.cmdedit.Location = New System.Drawing.Point(928, 20)
        Me.cmdedit.Name = "cmdedit"
        Me.cmdedit.Size = New System.Drawing.Size(80, 28)
        Me.cmdedit.TabIndex = 4
        Me.cmdedit.Text = "&Edit"
        Me.cmdedit.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(520, 542)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 3
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.Details)
        Me.TabControl1.Controls.Add(Me.General)
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(491, 33)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(531, 503)
        Me.TabControl1.TabIndex = 239
        '
        'Details
        '
        Me.Details.Controls.Add(Me.BlendPanel2)
        Me.Details.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Details.Location = New System.Drawing.Point(4, 22)
        Me.Details.Name = "Details"
        Me.Details.Padding = New System.Windows.Forms.Padding(3)
        Me.Details.Size = New System.Drawing.Size(523, 477)
        Me.Details.TabIndex = 0
        Me.Details.Text = "Guest Details"
        Me.Details.UseVisualStyleBackColor = True
        '
        'BlendPanel2
        '
        Me.BlendPanel2.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel2.Controls.Add(Me.Label3)
        Me.BlendPanel2.Controls.Add(Me.TXTREF)
        Me.BlendPanel2.Controls.Add(Me.DOB)
        Me.BlendPanel2.Controls.Add(Me.chkdob)
        Me.BlendPanel2.Controls.Add(Me.TXTMEMBERSHIP)
        Me.BlendPanel2.Controls.Add(Me.Label1)
        Me.BlendPanel2.Controls.Add(Me.txtresino)
        Me.BlendPanel2.Controls.Add(Me.Label29)
        Me.BlendPanel2.Controls.Add(Me.Label6)
        Me.BlendPanel2.Controls.Add(Me.TXTNAME)
        Me.BlendPanel2.Controls.Add(Me.txtaltno)
        Me.BlendPanel2.Controls.Add(Me.Label5)
        Me.BlendPanel2.Controls.Add(Me.txtstd)
        Me.BlendPanel2.Controls.Add(Me.Label2)
        Me.BlendPanel2.Controls.Add(Me.txtcountry)
        Me.BlendPanel2.Controls.Add(Me.Label33)
        Me.BlendPanel2.Controls.Add(Me.txtwebsite)
        Me.BlendPanel2.Controls.Add(Me.Label53)
        Me.BlendPanel2.Controls.Add(Me.Label34)
        Me.BlendPanel2.Controls.Add(Me.Label52)
        Me.BlendPanel2.Controls.Add(Me.Label49)
        Me.BlendPanel2.Controls.Add(Me.txtstate)
        Me.BlendPanel2.Controls.Add(Me.txtfax)
        Me.BlendPanel2.Controls.Add(Me.txtzipcode)
        Me.BlendPanel2.Controls.Add(Me.txtmobile)
        Me.BlendPanel2.Controls.Add(Me.txtcity)
        Me.BlendPanel2.Controls.Add(Me.txtarea)
        Me.BlendPanel2.Controls.Add(Me.txtemail)
        Me.BlendPanel2.Controls.Add(Me.Label50)
        Me.BlendPanel2.Controls.Add(Me.Label40)
        Me.BlendPanel2.Controls.Add(Me.txttel1)
        Me.BlendPanel2.Controls.Add(Me.Label41)
        Me.BlendPanel2.Controls.Add(Me.Label43)
        Me.BlendPanel2.Controls.Add(Me.Label42)
        Me.BlendPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlendPanel2.Location = New System.Drawing.Point(3, 3)
        Me.BlendPanel2.Name = "BlendPanel2"
        Me.BlendPanel2.Size = New System.Drawing.Size(517, 471)
        Me.BlendPanel2.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(337, 202)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 14)
        Me.Label3.TabIndex = 302
        Me.Label3.Text = "Ref"
        '
        'TXTREF
        '
        Me.TXTREF.BackColor = System.Drawing.Color.White
        Me.TXTREF.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTREF.ForeColor = System.Drawing.Color.DimGray
        Me.TXTREF.Location = New System.Drawing.Point(365, 198)
        Me.TXTREF.Name = "TXTREF"
        Me.TXTREF.ReadOnly = True
        Me.TXTREF.Size = New System.Drawing.Size(132, 22)
        Me.TXTREF.TabIndex = 303
        Me.TXTREF.TabStop = False
        '
        'DOB
        '
        Me.DOB.CustomFormat = "dd/MM/yyyy"
        Me.DOB.Enabled = False
        Me.DOB.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DOB.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DOB.Location = New System.Drawing.Point(107, 198)
        Me.DOB.Name = "DOB"
        Me.DOB.Size = New System.Drawing.Size(77, 22)
        Me.DOB.TabIndex = 301
        '
        'chkdob
        '
        Me.chkdob.AutoSize = True
        Me.chkdob.Enabled = False
        Me.chkdob.ForeColor = System.Drawing.Color.Black
        Me.chkdob.Location = New System.Drawing.Point(57, 200)
        Me.chkdob.Name = "chkdob"
        Me.chkdob.Size = New System.Drawing.Size(49, 18)
        Me.chkdob.TabIndex = 300
        Me.chkdob.Text = "DOB"
        Me.chkdob.UseVisualStyleBackColor = True
        '
        'TXTMEMBERSHIP
        '
        Me.TXTMEMBERSHIP.BackColor = System.Drawing.Color.White
        Me.TXTMEMBERSHIP.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTMEMBERSHIP.ForeColor = System.Drawing.Color.DimGray
        Me.TXTMEMBERSHIP.Location = New System.Drawing.Point(107, 170)
        Me.TXTMEMBERSHIP.Name = "TXTMEMBERSHIP"
        Me.TXTMEMBERSHIP.ReadOnly = True
        Me.TXTMEMBERSHIP.Size = New System.Drawing.Size(132, 22)
        Me.TXTMEMBERSHIP.TabIndex = 255
        Me.TXTMEMBERSHIP.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(9, 174)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 14)
        Me.Label1.TabIndex = 254
        Me.Label1.Text = "Membership No."
        '
        'txtresino
        '
        Me.txtresino.BackColor = System.Drawing.Color.White
        Me.txtresino.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtresino.ForeColor = System.Drawing.Color.DimGray
        Me.txtresino.Location = New System.Drawing.Point(365, 10)
        Me.txtresino.Name = "txtresino"
        Me.txtresino.ReadOnly = True
        Me.txtresino.Size = New System.Drawing.Size(132, 22)
        Me.txtresino.TabIndex = 253
        Me.txtresino.TabStop = False
        Me.txtresino.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(32, 14)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(74, 14)
        Me.Label29.TabIndex = 216
        Me.Label29.Text = "Guest Name"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(310, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 14)
        Me.Label6.TabIndex = 252
        Me.Label6.Text = "Resi No."
        '
        'TXTNAME
        '
        Me.TXTNAME.BackColor = System.Drawing.Color.White
        Me.TXTNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNAME.ForeColor = System.Drawing.Color.DimGray
        Me.TXTNAME.Location = New System.Drawing.Point(107, 10)
        Me.TXTNAME.Name = "TXTNAME"
        Me.TXTNAME.ReadOnly = True
        Me.TXTNAME.Size = New System.Drawing.Size(186, 22)
        Me.TXTNAME.TabIndex = 219
        Me.TXTNAME.TabStop = False
        '
        'txtaltno
        '
        Me.txtaltno.BackColor = System.Drawing.Color.White
        Me.txtaltno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtaltno.ForeColor = System.Drawing.Color.DimGray
        Me.txtaltno.Location = New System.Drawing.Point(365, 38)
        Me.txtaltno.Name = "txtaltno"
        Me.txtaltno.ReadOnly = True
        Me.txtaltno.Size = New System.Drawing.Size(132, 22)
        Me.txtaltno.TabIndex = 251
        Me.txtaltno.TabStop = False
        Me.txtaltno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(319, 42)
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
        Me.txtstd.Location = New System.Drawing.Point(242, 38)
        Me.txtstd.Name = "txtstd"
        Me.txtstd.ReadOnly = True
        Me.txtstd.Size = New System.Drawing.Size(51, 22)
        Me.txtstd.TabIndex = 249
        Me.txtstd.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(207, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 14)
        Me.Label2.TabIndex = 248
        Me.Label2.Text = "S.T.D."
        '
        'txtcountry
        '
        Me.txtcountry.BackColor = System.Drawing.Color.White
        Me.txtcountry.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcountry.ForeColor = System.Drawing.Color.DimGray
        Me.txtcountry.Location = New System.Drawing.Point(107, 142)
        Me.txtcountry.Name = "txtcountry"
        Me.txtcountry.ReadOnly = True
        Me.txtcountry.Size = New System.Drawing.Size(132, 22)
        Me.txtcountry.TabIndex = 247
        Me.txtcountry.TabStop = False
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Black
        Me.Label33.Location = New System.Drawing.Point(59, 146)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(47, 14)
        Me.Label33.TabIndex = 246
        Me.Label33.Text = "Country"
        '
        'txtwebsite
        '
        Me.txtwebsite.BackColor = System.Drawing.Color.White
        Me.txtwebsite.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtwebsite.ForeColor = System.Drawing.Color.DimGray
        Me.txtwebsite.Location = New System.Drawing.Point(365, 142)
        Me.txtwebsite.Name = "txtwebsite"
        Me.txtwebsite.ReadOnly = True
        Me.txtwebsite.Size = New System.Drawing.Size(132, 22)
        Me.txtwebsite.TabIndex = 245
        Me.txtwebsite.TabStop = False
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.ForeColor = System.Drawing.Color.Black
        Me.Label53.Location = New System.Drawing.Point(337, 120)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(25, 14)
        Me.Label53.TabIndex = 227
        Me.Label53.Text = "Fax"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(309, 146)
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
        Me.Label52.Location = New System.Drawing.Point(316, 94)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(46, 14)
        Me.Label52.TabIndex = 226
        Me.Label52.Text = "Mobile"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.ForeColor = System.Drawing.Color.Black
        Me.Label49.Location = New System.Drawing.Point(324, 174)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(38, 14)
        Me.Label49.TabIndex = 228
        Me.Label49.Text = "Email"
        '
        'txtstate
        '
        Me.txtstate.BackColor = System.Drawing.Color.White
        Me.txtstate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtstate.ForeColor = System.Drawing.Color.DimGray
        Me.txtstate.Location = New System.Drawing.Point(107, 116)
        Me.txtstate.Name = "txtstate"
        Me.txtstate.ReadOnly = True
        Me.txtstate.Size = New System.Drawing.Size(132, 22)
        Me.txtstate.TabIndex = 243
        Me.txtstate.TabStop = False
        '
        'txtfax
        '
        Me.txtfax.BackColor = System.Drawing.Color.White
        Me.txtfax.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfax.ForeColor = System.Drawing.Color.DimGray
        Me.txtfax.Location = New System.Drawing.Point(365, 116)
        Me.txtfax.Name = "txtfax"
        Me.txtfax.ReadOnly = True
        Me.txtfax.Size = New System.Drawing.Size(132, 22)
        Me.txtfax.TabIndex = 233
        Me.txtfax.TabStop = False
        Me.txtfax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtzipcode
        '
        Me.txtzipcode.BackColor = System.Drawing.Color.White
        Me.txtzipcode.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtzipcode.ForeColor = System.Drawing.Color.DimGray
        Me.txtzipcode.Location = New System.Drawing.Point(107, 90)
        Me.txtzipcode.Name = "txtzipcode"
        Me.txtzipcode.ReadOnly = True
        Me.txtzipcode.Size = New System.Drawing.Size(132, 22)
        Me.txtzipcode.TabIndex = 242
        Me.txtzipcode.TabStop = False
        '
        'txtmobile
        '
        Me.txtmobile.BackColor = System.Drawing.Color.White
        Me.txtmobile.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmobile.ForeColor = System.Drawing.Color.DimGray
        Me.txtmobile.Location = New System.Drawing.Point(365, 90)
        Me.txtmobile.Name = "txtmobile"
        Me.txtmobile.ReadOnly = True
        Me.txtmobile.Size = New System.Drawing.Size(132, 22)
        Me.txtmobile.TabIndex = 232
        Me.txtmobile.TabStop = False
        Me.txtmobile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtcity
        '
        Me.txtcity.BackColor = System.Drawing.Color.White
        Me.txtcity.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcity.ForeColor = System.Drawing.Color.DimGray
        Me.txtcity.Location = New System.Drawing.Point(107, 64)
        Me.txtcity.Name = "txtcity"
        Me.txtcity.ReadOnly = True
        Me.txtcity.Size = New System.Drawing.Size(132, 22)
        Me.txtcity.TabIndex = 241
        Me.txtcity.TabStop = False
        '
        'txtarea
        '
        Me.txtarea.BackColor = System.Drawing.Color.White
        Me.txtarea.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtarea.ForeColor = System.Drawing.Color.DimGray
        Me.txtarea.Location = New System.Drawing.Point(107, 38)
        Me.txtarea.Name = "txtarea"
        Me.txtarea.ReadOnly = True
        Me.txtarea.Size = New System.Drawing.Size(77, 22)
        Me.txtarea.TabIndex = 240
        Me.txtarea.TabStop = False
        '
        'txtemail
        '
        Me.txtemail.BackColor = System.Drawing.Color.White
        Me.txtemail.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtemail.ForeColor = System.Drawing.Color.DimGray
        Me.txtemail.Location = New System.Drawing.Point(365, 170)
        Me.txtemail.Name = "txtemail"
        Me.txtemail.ReadOnly = True
        Me.txtemail.Size = New System.Drawing.Size(132, 22)
        Me.txtemail.TabIndex = 234
        Me.txtemail.TabStop = False
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.ForeColor = System.Drawing.Color.Black
        Me.Label50.Location = New System.Drawing.Point(321, 68)
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
        Me.Label40.Location = New System.Drawing.Point(71, 120)
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
        Me.txttel1.Location = New System.Drawing.Point(365, 64)
        Me.txttel1.Name = "txttel1"
        Me.txttel1.ReadOnly = True
        Me.txttel1.Size = New System.Drawing.Size(132, 22)
        Me.txttel1.TabIndex = 230
        Me.txttel1.TabStop = False
        Me.txttel1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.Black
        Me.Label41.Location = New System.Drawing.Point(52, 94)
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
        Me.Label43.Location = New System.Drawing.Point(74, 42)
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
        Me.Label42.Location = New System.Drawing.Point(80, 68)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(26, 14)
        Me.Label42.TabIndex = 237
        Me.Label42.Text = "City"
        '
        'General
        '
        Me.General.Controls.Add(Me.BlendPanel4)
        Me.General.Location = New System.Drawing.Point(4, 22)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(523, 449)
        Me.General.TabIndex = 2
        Me.General.Text = "General Details"
        Me.General.UseVisualStyleBackColor = True
        '
        'BlendPanel4
        '
        Me.BlendPanel4.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel4.Controls.Add(Me.txtadd2)
        Me.BlendPanel4.Controls.Add(Me.txtadd1)
        Me.BlendPanel4.Controls.Add(Me.GroupBox5)
        Me.BlendPanel4.Controls.Add(Me.Label44)
        Me.BlendPanel4.Controls.Add(Me.GroupBox3)
        Me.BlendPanel4.Controls.Add(Me.Label45)
        Me.BlendPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel4.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel4.Name = "BlendPanel4"
        Me.BlendPanel4.Size = New System.Drawing.Size(523, 449)
        Me.BlendPanel4.TabIndex = 0
        '
        'txtadd2
        '
        Me.txtadd2.BackColor = System.Drawing.Color.White
        Me.txtadd2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtadd2.ForeColor = System.Drawing.Color.DimGray
        Me.txtadd2.Location = New System.Drawing.Point(104, 39)
        Me.txtadd2.Name = "txtadd2"
        Me.txtadd2.ReadOnly = True
        Me.txtadd2.Size = New System.Drawing.Size(312, 22)
        Me.txtadd2.TabIndex = 195
        Me.txtadd2.TabStop = False
        '
        'txtadd1
        '
        Me.txtadd1.BackColor = System.Drawing.Color.White
        Me.txtadd1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtadd1.ForeColor = System.Drawing.Color.DimGray
        Me.txtadd1.Location = New System.Drawing.Point(104, 13)
        Me.txtadd1.Name = "txtadd1"
        Me.txtadd1.ReadOnly = True
        Me.txtadd1.Size = New System.Drawing.Size(312, 22)
        Me.txtadd1.TabIndex = 194
        Me.txtadd1.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.TXTREMARKS)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(36, 175)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(240, 95)
        Me.GroupBox5.TabIndex = 191
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Remarks"
        '
        'TXTREMARKS
        '
        Me.TXTREMARKS.BackColor = System.Drawing.Color.White
        Me.TXTREMARKS.ForeColor = System.Drawing.Color.DimGray
        Me.TXTREMARKS.Location = New System.Drawing.Point(5, 16)
        Me.TXTREMARKS.Multiline = True
        Me.TXTREMARKS.Name = "TXTREMARKS"
        Me.TXTREMARKS.ReadOnly = True
        Me.TXTREMARKS.Size = New System.Drawing.Size(229, 74)
        Me.TXTREMARKS.TabIndex = 3
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.ForeColor = System.Drawing.Color.Black
        Me.Label44.Location = New System.Drawing.Point(41, 43)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(60, 14)
        Me.Label44.TabIndex = 193
        Me.Label44.Text = "Address 2"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.txtadd)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(36, 67)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(240, 102)
        Me.GroupBox3.TabIndex = 189
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
        Me.txtadd.ReadOnly = True
        Me.txtadd.Size = New System.Drawing.Size(229, 80)
        Me.txtadd.TabIndex = 3
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.ForeColor = System.Drawing.Color.Black
        Me.Label45.Location = New System.Drawing.Point(41, 17)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(60, 14)
        Me.Label45.TabIndex = 192
        Me.Label45.Text = "Address 1"
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
        'GUNIQUENO
        '
        Me.GUNIQUENO.Caption = "Unique No"
        Me.GUNIQUENO.FieldName = "UNIQUENO"
        Me.GUNIQUENO.Name = "GUNIQUENO"
        Me.GUNIQUENO.Visible = True
        Me.GUNIQUENO.VisibleIndex = 1
        '
        'GuestDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1034, 582)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "GuestDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Guest Details"
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
        Me.General.ResumeLayout(False)
        Me.BlendPanel4.ResumeLayout(False)
        Me.BlendPanel4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMDREFRESH As System.Windows.Forms.Button
    Private WithEvents gridname As DevExpress.XtraGrid.GridControl
    Private WithEvents gridledger As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cmdadd As System.Windows.Forms.Button
    Friend WithEvents cmdedit As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Details As System.Windows.Forms.TabPage
    Friend WithEvents BlendPanel2 As VbPowerPack.BlendPanel
    Friend WithEvents txtresino As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TXTNAME As System.Windows.Forms.TextBox
    Friend WithEvents txtaltno As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtstd As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtcountry As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtwebsite As System.Windows.Forms.TextBox
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents txtstate As System.Windows.Forms.TextBox
    Friend WithEvents txtfax As System.Windows.Forms.TextBox
    Friend WithEvents txtzipcode As System.Windows.Forms.TextBox
    Friend WithEvents txtmobile As System.Windows.Forms.TextBox
    Friend WithEvents txtcity As System.Windows.Forms.TextBox
    Friend WithEvents txtarea As System.Windows.Forms.TextBox
    Friend WithEvents txtemail As System.Windows.Forms.TextBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents txttel1 As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents General As System.Windows.Forms.TabPage
    Friend WithEvents BlendPanel4 As VbPowerPack.BlendPanel
    Friend WithEvents txtadd2 As System.Windows.Forms.TextBox
    Friend WithEvents txtadd1 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents TXTREMARKS As System.Windows.Forms.TextBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtadd As System.Windows.Forms.TextBox
    Friend WithEvents TXTMEMBERSHIP As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DOB As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkdob As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TXTREF As System.Windows.Forms.TextBox
    Friend WithEvents GGUESTNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PBEXCEL As System.Windows.Forms.PictureBox
    Friend WithEvents GUNIQUENO As DevExpress.XtraGrid.Columns.GridColumn
End Class
