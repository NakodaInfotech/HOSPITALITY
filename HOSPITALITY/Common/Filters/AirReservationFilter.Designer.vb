<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AirReservationFilter
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
        Me.CHKDETAIL = New System.Windows.Forms.CheckBox()
        Me.TXTSALEBAL = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.CMBCONFIRMEDBY = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.CMDSHOWDETAILS = New System.Windows.Forms.Button()
        Me.CHKARRDATE = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ARRIVALTO = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ARRIVALFROM = New System.Windows.Forms.DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TXTPURLESS = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TXTPURGREATER = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TXTSALELESS = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TXTSALEGREATER = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CMBBOOKINGNO = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CMBACCCODE = New System.Windows.Forms.ComboBox()
        Me.CMBPURCODE = New System.Windows.Forms.ComboBox()
        Me.CHKAMENDED = New System.Windows.Forms.CheckBox()
        Me.CHKCANCELLED = New System.Windows.Forms.CheckBox()
        Me.CMBNAME = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CMBPURNAME = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CMBGUESTNAME = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXTHOTELADD = New System.Windows.Forms.TextBox()
        Me.cmbaircode = New System.Windows.Forms.ComboBox()
        Me.CMBAIRNAME = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkdate = New System.Windows.Forms.CheckBox()
        Me.cmdShowReport = New System.Windows.Forms.Button()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.CMBBOOKEDBY = New System.Windows.Forms.ComboBox()
        Me.lblreg = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.CMBPACKAGETYPE = New System.Windows.Forms.ComboBox()
        Me.BlendPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.Label43)
        Me.BlendPanel1.Controls.Add(Me.CMBPACKAGETYPE)
        Me.BlendPanel1.Controls.Add(Me.CHKDETAIL)
        Me.BlendPanel1.Controls.Add(Me.TXTSALEBAL)
        Me.BlendPanel1.Controls.Add(Me.Label16)
        Me.BlendPanel1.Controls.Add(Me.CMBCONFIRMEDBY)
        Me.BlendPanel1.Controls.Add(Me.Label15)
        Me.BlendPanel1.Controls.Add(Me.Label14)
        Me.BlendPanel1.Controls.Add(Me.CMDSHOWDETAILS)
        Me.BlendPanel1.Controls.Add(Me.CHKARRDATE)
        Me.BlendPanel1.Controls.Add(Me.GroupBox1)
        Me.BlendPanel1.Controls.Add(Me.TXTPURLESS)
        Me.BlendPanel1.Controls.Add(Me.Label10)
        Me.BlendPanel1.Controls.Add(Me.TXTPURGREATER)
        Me.BlendPanel1.Controls.Add(Me.Label11)
        Me.BlendPanel1.Controls.Add(Me.TXTSALELESS)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.TXTSALEGREATER)
        Me.BlendPanel1.Controls.Add(Me.Label8)
        Me.BlendPanel1.Controls.Add(Me.CMBBOOKINGNO)
        Me.BlendPanel1.Controls.Add(Me.Label7)
        Me.BlendPanel1.Controls.Add(Me.CMBACCCODE)
        Me.BlendPanel1.Controls.Add(Me.CMBPURCODE)
        Me.BlendPanel1.Controls.Add(Me.CHKAMENDED)
        Me.BlendPanel1.Controls.Add(Me.CHKCANCELLED)
        Me.BlendPanel1.Controls.Add(Me.CMBNAME)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.CMBPURNAME)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.CMBGUESTNAME)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.TXTHOTELADD)
        Me.BlendPanel1.Controls.Add(Me.cmbaircode)
        Me.BlendPanel1.Controls.Add(Me.CMBAIRNAME)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.chkdate)
        Me.BlendPanel1.Controls.Add(Me.cmdShowReport)
        Me.BlendPanel1.Controls.Add(Me.cmdExit)
        Me.BlendPanel1.Controls.Add(Me.CMBBOOKEDBY)
        Me.BlendPanel1.Controls.Add(Me.lblreg)
        Me.BlendPanel1.Controls.Add(Me.GroupBox2)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(400, 472)
        Me.BlendPanel1.TabIndex = 1
        '
        'CHKDETAIL
        '
        Me.CHKDETAIL.AutoSize = True
        Me.CHKDETAIL.BackColor = System.Drawing.Color.Transparent
        Me.CHKDETAIL.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CHKDETAIL.Location = New System.Drawing.Point(258, 439)
        Me.CHKDETAIL.Name = "CHKDETAIL"
        Me.CHKDETAIL.Size = New System.Drawing.Size(60, 18)
        Me.CHKDETAIL.TabIndex = 654
        Me.CHKDETAIL.Text = "Detail"
        Me.CHKDETAIL.UseVisualStyleBackColor = False
        '
        'TXTSALEBAL
        '
        Me.TXTSALEBAL.BackColor = System.Drawing.Color.White
        Me.TXTSALEBAL.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSALEBAL.ForeColor = System.Drawing.Color.Black
        Me.TXTSALEBAL.Location = New System.Drawing.Point(291, 156)
        Me.TXTSALEBAL.Name = "TXTSALEBAL"
        Me.TXTSALEBAL.Size = New System.Drawing.Size(73, 22)
        Me.TXTSALEBAL.TabIndex = 6
        Me.TXTSALEBAL.Text = "0.00"
        Me.TXTSALEBAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label16.Location = New System.Drawing.Point(194, 160)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(95, 14)
        Me.Label16.TabIndex = 653
        Me.Label16.Text = "Bal greater than"
        '
        'CMBCONFIRMEDBY
        '
        Me.CMBCONFIRMEDBY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCONFIRMEDBY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCONFIRMEDBY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBCONFIRMEDBY.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CMBCONFIRMEDBY.FormattingEnabled = True
        Me.CMBCONFIRMEDBY.Items.AddRange(New Object() {""})
        Me.CMBCONFIRMEDBY.Location = New System.Drawing.Point(113, 237)
        Me.CMBCONFIRMEDBY.Name = "CMBCONFIRMEDBY"
        Me.CMBCONFIRMEDBY.Size = New System.Drawing.Size(251, 22)
        Me.CMBCONFIRMEDBY.TabIndex = 11
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label15.Location = New System.Drawing.Point(35, 241)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(76, 14)
        Me.Label15.TabIndex = 651
        Me.Label15.Text = "Confirmed By"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Maroon
        Me.Label14.Location = New System.Drawing.Point(319, 443)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(53, 14)
        Me.Label14.TabIndex = 649
        Me.Label14.Text = "(In GRID)"
        '
        'CMDSHOWDETAILS
        '
        Me.CMDSHOWDETAILS.BackColor = System.Drawing.Color.Transparent
        Me.CMDSHOWDETAILS.FlatAppearance.BorderSize = 0
        Me.CMDSHOWDETAILS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDSHOWDETAILS.Image = Global.HOSPITALITY.My.Resources.Resources.show_report1
        Me.CMDSHOWDETAILS.Location = New System.Drawing.Point(172, 428)
        Me.CMDSHOWDETAILS.Name = "CMDSHOWDETAILS"
        Me.CMDSHOWDETAILS.Size = New System.Drawing.Size(80, 29)
        Me.CMDSHOWDETAILS.TabIndex = 19
        Me.CMDSHOWDETAILS.UseVisualStyleBackColor = False
        '
        'CHKARRDATE
        '
        Me.CHKARRDATE.AutoSize = True
        Me.CHKARRDATE.BackColor = System.Drawing.Color.Transparent
        Me.CHKARRDATE.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CHKARRDATE.Location = New System.Drawing.Point(49, 373)
        Me.CHKARRDATE.Name = "CHKARRDATE"
        Me.CHKARRDATE.Size = New System.Drawing.Size(87, 18)
        Me.CHKARRDATE.TabIndex = 16
        Me.CHKARRDATE.Text = "Ticket Date"
        Me.CHKARRDATE.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.ARRIVALTO)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.ARRIVALFROM)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(37, 375)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(327, 48)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        '
        'ARRIVALTO
        '
        Me.ARRIVALTO.CustomFormat = "dd/MM/yyyy"
        Me.ARRIVALTO.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.ARRIVALTO.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.ARRIVALTO.Location = New System.Drawing.Point(208, 19)
        Me.ARRIVALTO.Name = "ARRIVALTO"
        Me.ARRIVALTO.Size = New System.Drawing.Size(92, 22)
        Me.ARRIVALTO.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(179, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(25, 14)
        Me.Label12.TabIndex = 106
        Me.Label12.Text = "To :"
        '
        'ARRIVALFROM
        '
        Me.ARRIVALFROM.CustomFormat = "dd/MM/yyyy"
        Me.ARRIVALFROM.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.ARRIVALFROM.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.ARRIVALFROM.Location = New System.Drawing.Point(70, 19)
        Me.ARRIVALFROM.Name = "ARRIVALFROM"
        Me.ARRIVALFROM.Size = New System.Drawing.Size(92, 22)
        Me.ARRIVALFROM.TabIndex = 0
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(26, 22)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(40, 14)
        Me.Label13.TabIndex = 104
        Me.Label13.Text = "From :"
        '
        'TXTPURLESS
        '
        Me.TXTPURLESS.BackColor = System.Drawing.Color.White
        Me.TXTPURLESS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPURLESS.ForeColor = System.Drawing.Color.Black
        Me.TXTPURLESS.Location = New System.Drawing.Point(291, 210)
        Me.TXTPURLESS.Name = "TXTPURLESS"
        Me.TXTPURLESS.Size = New System.Drawing.Size(73, 22)
        Me.TXTPURLESS.TabIndex = 10
        Me.TXTPURLESS.Text = "0.00"
        Me.TXTPURLESS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label10.Location = New System.Drawing.Point(211, 214)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(78, 14)
        Me.Label10.TabIndex = 645
        Me.Label10.Text = "Pur less than"
        '
        'TXTPURGREATER
        '
        Me.TXTPURGREATER.BackColor = System.Drawing.Color.White
        Me.TXTPURGREATER.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPURGREATER.ForeColor = System.Drawing.Color.Black
        Me.TXTPURGREATER.Location = New System.Drawing.Point(113, 210)
        Me.TXTPURGREATER.Name = "TXTPURGREATER"
        Me.TXTPURGREATER.Size = New System.Drawing.Size(80, 22)
        Me.TXTPURGREATER.TabIndex = 9
        Me.TXTPURGREATER.Text = "0.00"
        Me.TXTPURGREATER.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label11.Location = New System.Drawing.Point(17, 214)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(94, 14)
        Me.Label11.TabIndex = 643
        Me.Label11.Text = "Pur greater than"
        '
        'TXTSALELESS
        '
        Me.TXTSALELESS.BackColor = System.Drawing.Color.White
        Me.TXTSALELESS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSALELESS.ForeColor = System.Drawing.Color.Black
        Me.TXTSALELESS.Location = New System.Drawing.Point(291, 183)
        Me.TXTSALELESS.Name = "TXTSALELESS"
        Me.TXTSALELESS.Size = New System.Drawing.Size(73, 22)
        Me.TXTSALELESS.TabIndex = 8
        Me.TXTSALELESS.Text = "0.00"
        Me.TXTSALELESS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label9.Location = New System.Drawing.Point(204, 187)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 14)
        Me.Label9.TabIndex = 641
        Me.Label9.Text = "Sale less than"
        '
        'TXTSALEGREATER
        '
        Me.TXTSALEGREATER.BackColor = System.Drawing.Color.White
        Me.TXTSALEGREATER.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSALEGREATER.ForeColor = System.Drawing.Color.Black
        Me.TXTSALEGREATER.Location = New System.Drawing.Point(113, 183)
        Me.TXTSALEGREATER.Name = "TXTSALEGREATER"
        Me.TXTSALEGREATER.Size = New System.Drawing.Size(80, 22)
        Me.TXTSALEGREATER.TabIndex = 7
        Me.TXTSALEGREATER.Text = "0.00"
        Me.TXTSALEGREATER.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label8.Location = New System.Drawing.Point(10, 187)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(101, 14)
        Me.Label8.TabIndex = 302
        Me.Label8.Text = "Sale greater than"
        '
        'CMBBOOKINGNO
        '
        Me.CMBBOOKINGNO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBBOOKINGNO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBBOOKINGNO.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CMBBOOKINGNO.FormattingEnabled = True
        Me.CMBBOOKINGNO.Items.AddRange(New Object() {""})
        Me.CMBBOOKINGNO.Location = New System.Drawing.Point(113, 156)
        Me.CMBBOOKINGNO.Name = "CMBBOOKINGNO"
        Me.CMBBOOKINGNO.Size = New System.Drawing.Size(80, 22)
        Me.CMBBOOKINGNO.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(42, 160)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 14)
        Me.Label7.TabIndex = 301
        Me.Label7.Text = "Booking No"
        '
        'CMBACCCODE
        '
        Me.CMBACCCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBACCCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBACCCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBACCCODE.FormattingEnabled = True
        Me.CMBACCCODE.Items.AddRange(New Object() {""})
        Me.CMBACCCODE.Location = New System.Drawing.Point(309, 102)
        Me.CMBACCCODE.Name = "CMBACCCODE"
        Me.CMBACCCODE.Size = New System.Drawing.Size(55, 22)
        Me.CMBACCCODE.TabIndex = 299
        '
        'CMBPURCODE
        '
        Me.CMBPURCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBPURCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBPURCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBPURCODE.FormattingEnabled = True
        Me.CMBPURCODE.Items.AddRange(New Object() {""})
        Me.CMBPURCODE.Location = New System.Drawing.Point(309, 75)
        Me.CMBPURCODE.Name = "CMBPURCODE"
        Me.CMBPURCODE.Size = New System.Drawing.Size(55, 22)
        Me.CMBPURCODE.TabIndex = 298
        '
        'CHKAMENDED
        '
        Me.CHKAMENDED.AutoSize = True
        Me.CHKAMENDED.BackColor = System.Drawing.Color.Transparent
        Me.CHKAMENDED.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CHKAMENDED.Location = New System.Drawing.Point(284, 294)
        Me.CHKAMENDED.Name = "CHKAMENDED"
        Me.CHKAMENDED.Size = New System.Drawing.Size(78, 18)
        Me.CHKAMENDED.TabIndex = 13
        Me.CHKAMENDED.Text = "Amended"
        Me.CHKAMENDED.UseVisualStyleBackColor = False
        Me.CHKAMENDED.Visible = False
        '
        'CHKCANCELLED
        '
        Me.CHKCANCELLED.AutoSize = True
        Me.CHKCANCELLED.BackColor = System.Drawing.Color.Transparent
        Me.CHKCANCELLED.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CHKCANCELLED.Location = New System.Drawing.Point(113, 294)
        Me.CHKCANCELLED.Name = "CHKCANCELLED"
        Me.CHKCANCELLED.Size = New System.Drawing.Size(80, 18)
        Me.CHKCANCELLED.TabIndex = 12
        Me.CHKCANCELLED.Text = "Cancelled"
        Me.CHKCANCELLED.UseVisualStyleBackColor = False
        '
        'CMBNAME
        '
        Me.CMBNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBNAME.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CMBNAME.FormattingEnabled = True
        Me.CMBNAME.Items.AddRange(New Object() {""})
        Me.CMBNAME.Location = New System.Drawing.Point(113, 102)
        Me.CMBNAME.Name = "CMBNAME"
        Me.CMBNAME.Size = New System.Drawing.Size(194, 22)
        Me.CMBNAME.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(59, 106)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 14)
        Me.Label5.TabIndex = 295
        Me.Label5.Text = "Sale A/C"
        '
        'CMBPURNAME
        '
        Me.CMBPURNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBPURNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBPURNAME.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CMBPURNAME.FormattingEnabled = True
        Me.CMBPURNAME.Items.AddRange(New Object() {""})
        Me.CMBPURNAME.Location = New System.Drawing.Point(113, 75)
        Me.CMBPURNAME.Name = "CMBPURNAME"
        Me.CMBPURNAME.Size = New System.Drawing.Size(194, 22)
        Me.CMBPURNAME.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(66, 79)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 14)
        Me.Label4.TabIndex = 293
        Me.Label4.Text = "Pur A/C"
        '
        'CMBGUESTNAME
        '
        Me.CMBGUESTNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBGUESTNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBGUESTNAME.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CMBGUESTNAME.FormattingEnabled = True
        Me.CMBGUESTNAME.Items.AddRange(New Object() {""})
        Me.CMBGUESTNAME.Location = New System.Drawing.Point(113, 21)
        Me.CMBGUESTNAME.Name = "CMBGUESTNAME"
        Me.CMBGUESTNAME.Size = New System.Drawing.Size(251, 22)
        Me.CMBGUESTNAME.TabIndex = 0
        Me.CMBGUESTNAME.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(37, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 14)
        Me.Label3.TabIndex = 291
        Me.Label3.Text = "Guest Name"
        Me.Label3.Visible = False
        '
        'TXTHOTELADD
        '
        Me.TXTHOTELADD.BackColor = System.Drawing.Color.White
        Me.TXTHOTELADD.ForeColor = System.Drawing.Color.DimGray
        Me.TXTHOTELADD.Location = New System.Drawing.Point(8, 8)
        Me.TXTHOTELADD.Multiline = True
        Me.TXTHOTELADD.Name = "TXTHOTELADD"
        Me.TXTHOTELADD.ReadOnly = True
        Me.TXTHOTELADD.Size = New System.Drawing.Size(10, 61)
        Me.TXTHOTELADD.TabIndex = 289
        Me.TXTHOTELADD.Visible = False
        '
        'cmbaircode
        '
        Me.cmbaircode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbaircode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbaircode.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbaircode.FormattingEnabled = True
        Me.cmbaircode.Items.AddRange(New Object() {""})
        Me.cmbaircode.Location = New System.Drawing.Point(309, 48)
        Me.cmbaircode.Name = "cmbaircode"
        Me.cmbaircode.Size = New System.Drawing.Size(55, 22)
        Me.cmbaircode.TabIndex = 10
        '
        'CMBAIRNAME
        '
        Me.CMBAIRNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBAIRNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBAIRNAME.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CMBAIRNAME.FormattingEnabled = True
        Me.CMBAIRNAME.Items.AddRange(New Object() {""})
        Me.CMBAIRNAME.Location = New System.Drawing.Point(113, 48)
        Me.CMBAIRNAME.Name = "CMBAIRNAME"
        Me.CMBAIRNAME.Size = New System.Drawing.Size(194, 22)
        Me.CMBAIRNAME.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(32, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 14)
        Me.Label2.TabIndex = 288
        Me.Label2.Text = "Airline Name"
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.chkdate.Location = New System.Drawing.Point(49, 313)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(52, 18)
        Me.chkdate.TabIndex = 14
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'cmdShowReport
        '
        Me.cmdShowReport.BackColor = System.Drawing.Color.Transparent
        Me.cmdShowReport.FlatAppearance.BorderSize = 0
        Me.cmdShowReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdShowReport.Image = Global.HOSPITALITY.My.Resources.Resources.show_report1
        Me.cmdShowReport.Location = New System.Drawing.Point(3, 439)
        Me.cmdShowReport.Name = "cmdShowReport"
        Me.cmdShowReport.Size = New System.Drawing.Size(80, 29)
        Me.cmdShowReport.TabIndex = 14
        Me.cmdShowReport.UseVisualStyleBackColor = False
        Me.cmdShowReport.Visible = False
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.Color.Transparent
        Me.cmdExit.FlatAppearance.BorderSize = 0
        Me.cmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdExit.Image = Global.HOSPITALITY.My.Resources.Resources._Exit
        Me.cmdExit.Location = New System.Drawing.Point(90, 432)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(76, 25)
        Me.cmdExit.TabIndex = 18
        Me.cmdExit.UseVisualStyleBackColor = False
        '
        'CMBBOOKEDBY
        '
        Me.CMBBOOKEDBY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBBOOKEDBY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBBOOKEDBY.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CMBBOOKEDBY.FormattingEnabled = True
        Me.CMBBOOKEDBY.Items.AddRange(New Object() {""})
        Me.CMBBOOKEDBY.Location = New System.Drawing.Point(113, 129)
        Me.CMBBOOKEDBY.Name = "CMBBOOKEDBY"
        Me.CMBBOOKEDBY.Size = New System.Drawing.Size(251, 22)
        Me.CMBBOOKEDBY.TabIndex = 4
        '
        'lblreg
        '
        Me.lblreg.AutoSize = True
        Me.lblreg.BackColor = System.Drawing.Color.Transparent
        Me.lblreg.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.lblreg.Location = New System.Drawing.Point(48, 133)
        Me.lblreg.Name = "lblreg"
        Me.lblreg.Size = New System.Drawing.Size(63, 14)
        Me.lblreg.TabIndex = 286
        Me.lblreg.Text = "Booked By"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.dtto)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.dtfrom)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(37, 313)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(327, 48)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        '
        'dtto
        '
        Me.dtto.CustomFormat = "dd/MM/yyyy"
        Me.dtto.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(208, 19)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(92, 22)
        Me.dtto.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(179, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 14)
        Me.Label1.TabIndex = 106
        Me.Label1.Text = "To :"
        '
        'dtfrom
        '
        Me.dtfrom.CustomFormat = "dd/MM/yyyy"
        Me.dtfrom.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfrom.Location = New System.Drawing.Point(70, 19)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(92, 22)
        Me.dtfrom.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(26, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 14)
        Me.Label6.TabIndex = 104
        Me.Label6.Text = "From :"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.BackColor = System.Drawing.Color.Transparent
        Me.Label43.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(33, 267)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(78, 14)
        Me.Label43.TabIndex = 898
        Me.Label43.Text = "Package Type"
        '
        'CMBPACKAGETYPE
        '
        Me.CMBPACKAGETYPE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBPACKAGETYPE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBPACKAGETYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBPACKAGETYPE.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CMBPACKAGETYPE.FormattingEnabled = True
        Me.CMBPACKAGETYPE.Items.AddRange(New Object() {"DOMESTIC", "INTERNATIONAL"})
        Me.CMBPACKAGETYPE.Location = New System.Drawing.Point(114, 264)
        Me.CMBPACKAGETYPE.MaxDropDownItems = 14
        Me.CMBPACKAGETYPE.Name = "CMBPACKAGETYPE"
        Me.CMBPACKAGETYPE.Size = New System.Drawing.Size(113, 22)
        Me.CMBPACKAGETYPE.TabIndex = 897
        '
        'AirReservationFilter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(400, 472)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "AirReservationFilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Airlines Reservation Filter"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents TXTSALEBAL As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents CMBCONFIRMEDBY As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents CMDSHOWDETAILS As System.Windows.Forms.Button
    Friend WithEvents CHKARRDATE As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ARRIVALTO As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ARRIVALFROM As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TXTPURLESS As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TXTPURGREATER As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TXTSALELESS As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TXTSALEGREATER As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CMBBOOKINGNO As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CMBACCCODE As System.Windows.Forms.ComboBox
    Friend WithEvents CMBPURCODE As System.Windows.Forms.ComboBox
    Friend WithEvents CHKAMENDED As System.Windows.Forms.CheckBox
    Friend WithEvents CHKCANCELLED As System.Windows.Forms.CheckBox
    Friend WithEvents CMBNAME As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CMBPURNAME As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CMBGUESTNAME As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbaircode As System.Windows.Forms.ComboBox
    Friend WithEvents CMBAIRNAME As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents cmdShowReport As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents CMBBOOKEDBY As System.Windows.Forms.ComboBox
    Friend WithEvents lblreg As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TXTHOTELADD As System.Windows.Forms.TextBox
    Friend WithEvents CHKDETAIL As System.Windows.Forms.CheckBox
    Friend WithEvents Label43 As Label
    Friend WithEvents CMBPACKAGETYPE As ComboBox
End Class
