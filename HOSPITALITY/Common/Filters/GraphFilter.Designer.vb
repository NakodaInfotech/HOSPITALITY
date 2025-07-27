<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GraphFilter
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.GROUPNAME = New System.Windows.Forms.GroupBox
        Me.TXTTEMPNAME = New System.Windows.Forms.TextBox
        Me.TXTNAME = New System.Windows.Forms.TextBox
        Me.GRIDNAME = New System.Windows.Forms.DataGridView
        Me.CHKNAMEALL = New System.Windows.Forms.CheckBox
        Me.grouphotel = New System.Windows.Forms.GroupBox
        Me.TXTTEMPHOTEL = New System.Windows.Forms.TextBox
        Me.TXTHOTELNAME = New System.Windows.Forms.TextBox
        Me.GRIDHOTEL = New System.Windows.Forms.DataGridView
        Me.CHKHOTELALL = New System.Windows.Forms.CheckBox
        Me.chkdate = New System.Windows.Forms.CheckBox
        Me.cmdShowReport = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TXTTEMPBOOKEDBY = New System.Windows.Forms.TextBox
        Me.TXTBOOKEDBY = New System.Windows.Forms.TextBox
        Me.GRIDBOOKEDBY = New System.Windows.Forms.DataGridView
        Me.CHKBOOKEDALL = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dtto = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtfrom = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.BlendPanel1.SuspendLayout()
        Me.GROUPNAME.SuspendLayout()
        CType(Me.GRIDNAME, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grouphotel.SuspendLayout()
        CType(Me.GRIDHOTEL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GRIDBOOKEDBY, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.GROUPNAME)
        Me.BlendPanel1.Controls.Add(Me.grouphotel)
        Me.BlendPanel1.Controls.Add(Me.chkdate)
        Me.BlendPanel1.Controls.Add(Me.cmdShowReport)
        Me.BlendPanel1.Controls.Add(Me.cmdExit)
        Me.BlendPanel1.Controls.Add(Me.GroupBox1)
        Me.BlendPanel1.Controls.Add(Me.GroupBox2)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(785, 475)
        Me.BlendPanel1.TabIndex = 0
        '
        'GROUPNAME
        '
        Me.GROUPNAME.BackColor = System.Drawing.Color.Transparent
        Me.GROUPNAME.Controls.Add(Me.TXTTEMPNAME)
        Me.GROUPNAME.Controls.Add(Me.TXTNAME)
        Me.GROUPNAME.Controls.Add(Me.GRIDNAME)
        Me.GROUPNAME.Controls.Add(Me.CHKNAMEALL)
        Me.GROUPNAME.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.GROUPNAME.ForeColor = System.Drawing.Color.Black
        Me.GROUPNAME.Location = New System.Drawing.Point(518, 12)
        Me.GROUPNAME.Name = "GROUPNAME"
        Me.GROUPNAME.Size = New System.Drawing.Size(246, 390)
        Me.GROUPNAME.TabIndex = 4
        Me.GROUPNAME.TabStop = False
        Me.GROUPNAME.Text = "Sale A/C"
        '
        'TXTTEMPNAME
        '
        Me.TXTTEMPNAME.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.TXTTEMPNAME.Location = New System.Drawing.Point(88, 44)
        Me.TXTTEMPNAME.Name = "TXTTEMPNAME"
        Me.TXTTEMPNAME.Size = New System.Drawing.Size(152, 22)
        Me.TXTTEMPNAME.TabIndex = 2
        Me.TXTTEMPNAME.Visible = False
        '
        'TXTNAME
        '
        Me.TXTNAME.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.TXTNAME.Location = New System.Drawing.Point(9, 19)
        Me.TXTNAME.Name = "TXTNAME"
        Me.TXTNAME.Size = New System.Drawing.Size(231, 22)
        Me.TXTNAME.TabIndex = 0
        '
        'GRIDNAME
        '
        Me.GRIDNAME.AllowUserToAddRows = False
        Me.GRIDNAME.AllowUserToDeleteRows = False
        Me.GRIDNAME.AllowUserToResizeColumns = False
        Me.GRIDNAME.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GRIDNAME.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GRIDNAME.BackgroundColor = System.Drawing.Color.White
        Me.GRIDNAME.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GRIDNAME.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GRIDNAME.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDNAME.DefaultCellStyle = DataGridViewCellStyle3
        Me.GRIDNAME.GridColor = System.Drawing.SystemColors.Control
        Me.GRIDNAME.Location = New System.Drawing.Point(9, 69)
        Me.GRIDNAME.Margin = New System.Windows.Forms.Padding(2)
        Me.GRIDNAME.MultiSelect = False
        Me.GRIDNAME.Name = "GRIDNAME"
        Me.GRIDNAME.ReadOnly = True
        Me.GRIDNAME.RowHeadersVisible = False
        Me.GRIDNAME.RowHeadersWidth = 30
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDNAME.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.GRIDNAME.RowTemplate.Height = 20
        Me.GRIDNAME.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDNAME.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDNAME.Size = New System.Drawing.Size(231, 316)
        Me.GRIDNAME.TabIndex = 0
        Me.GRIDNAME.TabStop = False
        '
        'CHKNAMEALL
        '
        Me.CHKNAMEALL.AutoSize = True
        Me.CHKNAMEALL.BackColor = System.Drawing.Color.Transparent
        Me.CHKNAMEALL.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CHKNAMEALL.Location = New System.Drawing.Point(11, 46)
        Me.CHKNAMEALL.Name = "CHKNAMEALL"
        Me.CHKNAMEALL.Size = New System.Drawing.Size(77, 18)
        Me.CHKNAMEALL.TabIndex = 1
        Me.CHKNAMEALL.Text = "Select All"
        Me.CHKNAMEALL.UseVisualStyleBackColor = False
        '
        'grouphotel
        '
        Me.grouphotel.BackColor = System.Drawing.Color.Transparent
        Me.grouphotel.Controls.Add(Me.TXTTEMPHOTEL)
        Me.grouphotel.Controls.Add(Me.TXTHOTELNAME)
        Me.grouphotel.Controls.Add(Me.GRIDHOTEL)
        Me.grouphotel.Controls.Add(Me.CHKHOTELALL)
        Me.grouphotel.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.grouphotel.ForeColor = System.Drawing.Color.Black
        Me.grouphotel.Location = New System.Drawing.Point(266, 12)
        Me.grouphotel.Name = "grouphotel"
        Me.grouphotel.Size = New System.Drawing.Size(246, 390)
        Me.grouphotel.TabIndex = 3
        Me.grouphotel.TabStop = False
        Me.grouphotel.Text = "Hotel Name"
        '
        'TXTTEMPHOTEL
        '
        Me.TXTTEMPHOTEL.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.TXTTEMPHOTEL.Location = New System.Drawing.Point(88, 44)
        Me.TXTTEMPHOTEL.Name = "TXTTEMPHOTEL"
        Me.TXTTEMPHOTEL.Size = New System.Drawing.Size(152, 22)
        Me.TXTTEMPHOTEL.TabIndex = 2
        Me.TXTTEMPHOTEL.Visible = False
        '
        'TXTHOTELNAME
        '
        Me.TXTHOTELNAME.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.TXTHOTELNAME.Location = New System.Drawing.Point(9, 19)
        Me.TXTHOTELNAME.Name = "TXTHOTELNAME"
        Me.TXTHOTELNAME.Size = New System.Drawing.Size(231, 22)
        Me.TXTHOTELNAME.TabIndex = 0
        '
        'GRIDHOTEL
        '
        Me.GRIDHOTEL.AllowUserToAddRows = False
        Me.GRIDHOTEL.AllowUserToDeleteRows = False
        Me.GRIDHOTEL.AllowUserToResizeColumns = False
        Me.GRIDHOTEL.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GRIDHOTEL.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.GRIDHOTEL.BackgroundColor = System.Drawing.Color.White
        Me.GRIDHOTEL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Calibri", 9.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GRIDHOTEL.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.GRIDHOTEL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Calibri", 9.0!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDHOTEL.DefaultCellStyle = DataGridViewCellStyle7
        Me.GRIDHOTEL.GridColor = System.Drawing.SystemColors.Control
        Me.GRIDHOTEL.Location = New System.Drawing.Point(9, 69)
        Me.GRIDHOTEL.Margin = New System.Windows.Forms.Padding(2)
        Me.GRIDHOTEL.MultiSelect = False
        Me.GRIDHOTEL.Name = "GRIDHOTEL"
        Me.GRIDHOTEL.ReadOnly = True
        Me.GRIDHOTEL.RowHeadersVisible = False
        Me.GRIDHOTEL.RowHeadersWidth = 30
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDHOTEL.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.GRIDHOTEL.RowTemplate.Height = 20
        Me.GRIDHOTEL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDHOTEL.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDHOTEL.Size = New System.Drawing.Size(231, 316)
        Me.GRIDHOTEL.TabIndex = 0
        Me.GRIDHOTEL.TabStop = False
        '
        'CHKHOTELALL
        '
        Me.CHKHOTELALL.AutoSize = True
        Me.CHKHOTELALL.BackColor = System.Drawing.Color.Transparent
        Me.CHKHOTELALL.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CHKHOTELALL.Location = New System.Drawing.Point(11, 46)
        Me.CHKHOTELALL.Name = "CHKHOTELALL"
        Me.CHKHOTELALL.Size = New System.Drawing.Size(77, 18)
        Me.CHKHOTELALL.TabIndex = 1
        Me.CHKHOTELALL.Text = "Select All"
        Me.CHKHOTELALL.UseVisualStyleBackColor = False
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.chkdate.Location = New System.Drawing.Point(25, 402)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(99, 18)
        Me.chkdate.TabIndex = 5
        Me.chkdate.Text = "Booking Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'cmdShowReport
        '
        Me.cmdShowReport.BackColor = System.Drawing.Color.Transparent
        Me.cmdShowReport.FlatAppearance.BorderSize = 0
        Me.cmdShowReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdShowReport.Image = Global.HOSPITALITY.My.Resources.Resources.show_report
        Me.cmdShowReport.Location = New System.Drawing.Point(391, 422)
        Me.cmdShowReport.Name = "cmdShowReport"
        Me.cmdShowReport.Size = New System.Drawing.Size(76, 29)
        Me.cmdShowReport.TabIndex = 0
        Me.cmdShowReport.UseVisualStyleBackColor = False
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.Color.Transparent
        Me.cmdExit.FlatAppearance.BorderSize = 0
        Me.cmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdExit.Image = Global.HOSPITALITY.My.Resources.Resources._Exit
        Me.cmdExit.Location = New System.Drawing.Point(470, 425)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(76, 25)
        Me.cmdExit.TabIndex = 1
        Me.cmdExit.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.TXTTEMPBOOKEDBY)
        Me.GroupBox1.Controls.Add(Me.TXTBOOKEDBY)
        Me.GroupBox1.Controls.Add(Me.GRIDBOOKEDBY)
        Me.GroupBox1.Controls.Add(Me.CHKBOOKEDALL)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(14, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(246, 390)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Booked By"
        '
        'TXTTEMPBOOKEDBY
        '
        Me.TXTTEMPBOOKEDBY.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.TXTTEMPBOOKEDBY.Location = New System.Drawing.Point(88, 44)
        Me.TXTTEMPBOOKEDBY.Name = "TXTTEMPBOOKEDBY"
        Me.TXTTEMPBOOKEDBY.Size = New System.Drawing.Size(152, 22)
        Me.TXTTEMPBOOKEDBY.TabIndex = 2
        Me.TXTTEMPBOOKEDBY.Visible = False
        '
        'TXTBOOKEDBY
        '
        Me.TXTBOOKEDBY.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.TXTBOOKEDBY.Location = New System.Drawing.Point(9, 19)
        Me.TXTBOOKEDBY.Name = "TXTBOOKEDBY"
        Me.TXTBOOKEDBY.Size = New System.Drawing.Size(231, 22)
        Me.TXTBOOKEDBY.TabIndex = 0
        '
        'GRIDBOOKEDBY
        '
        Me.GRIDBOOKEDBY.AllowUserToAddRows = False
        Me.GRIDBOOKEDBY.AllowUserToDeleteRows = False
        Me.GRIDBOOKEDBY.AllowUserToResizeColumns = False
        Me.GRIDBOOKEDBY.AllowUserToResizeRows = False
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GRIDBOOKEDBY.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.GRIDBOOKEDBY.BackgroundColor = System.Drawing.Color.White
        Me.GRIDBOOKEDBY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Calibri", 9.0!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GRIDBOOKEDBY.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.GRIDBOOKEDBY.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Calibri", 9.0!)
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDBOOKEDBY.DefaultCellStyle = DataGridViewCellStyle11
        Me.GRIDBOOKEDBY.GridColor = System.Drawing.SystemColors.Control
        Me.GRIDBOOKEDBY.Location = New System.Drawing.Point(9, 69)
        Me.GRIDBOOKEDBY.Margin = New System.Windows.Forms.Padding(2)
        Me.GRIDBOOKEDBY.MultiSelect = False
        Me.GRIDBOOKEDBY.Name = "GRIDBOOKEDBY"
        Me.GRIDBOOKEDBY.ReadOnly = True
        Me.GRIDBOOKEDBY.RowHeadersVisible = False
        Me.GRIDBOOKEDBY.RowHeadersWidth = 30
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDBOOKEDBY.RowsDefaultCellStyle = DataGridViewCellStyle12
        Me.GRIDBOOKEDBY.RowTemplate.Height = 20
        Me.GRIDBOOKEDBY.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDBOOKEDBY.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDBOOKEDBY.Size = New System.Drawing.Size(231, 316)
        Me.GRIDBOOKEDBY.TabIndex = 0
        Me.GRIDBOOKEDBY.TabStop = False
        '
        'CHKBOOKEDALL
        '
        Me.CHKBOOKEDALL.AutoSize = True
        Me.CHKBOOKEDALL.BackColor = System.Drawing.Color.Transparent
        Me.CHKBOOKEDALL.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CHKBOOKEDALL.Location = New System.Drawing.Point(11, 46)
        Me.CHKBOOKEDALL.Name = "CHKBOOKEDALL"
        Me.CHKBOOKEDALL.Size = New System.Drawing.Size(77, 18)
        Me.CHKBOOKEDALL.TabIndex = 1
        Me.CHKBOOKEDALL.Text = "Select All"
        Me.CHKBOOKEDALL.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.dtto)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.dtfrom)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(13, 408)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(327, 48)
        Me.GroupBox2.TabIndex = 4
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
        'GraphFilter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(785, 475)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "GraphFilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Graph Filter"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.GROUPNAME.ResumeLayout(False)
        Me.GROUPNAME.PerformLayout()
        CType(Me.GRIDNAME, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grouphotel.ResumeLayout(False)
        Me.grouphotel.PerformLayout()
        CType(Me.GRIDHOTEL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.GRIDBOOKEDBY, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents cmdShowReport As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TXTTEMPBOOKEDBY As System.Windows.Forms.TextBox
    Friend WithEvents TXTBOOKEDBY As System.Windows.Forms.TextBox
    Friend WithEvents GRIDBOOKEDBY As System.Windows.Forms.DataGridView
    Friend WithEvents CHKBOOKEDALL As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GROUPNAME As System.Windows.Forms.GroupBox
    Friend WithEvents TXTTEMPNAME As System.Windows.Forms.TextBox
    Friend WithEvents TXTNAME As System.Windows.Forms.TextBox
    Friend WithEvents GRIDNAME As System.Windows.Forms.DataGridView
    Friend WithEvents CHKNAMEALL As System.Windows.Forms.CheckBox
    Friend WithEvents grouphotel As System.Windows.Forms.GroupBox
    Friend WithEvents TXTTEMPHOTEL As System.Windows.Forms.TextBox
    Friend WithEvents TXTHOTELNAME As System.Windows.Forms.TextBox
    Friend WithEvents GRIDHOTEL As System.Windows.Forms.DataGridView
    Friend WithEvents CHKHOTELALL As System.Windows.Forms.CheckBox
End Class
