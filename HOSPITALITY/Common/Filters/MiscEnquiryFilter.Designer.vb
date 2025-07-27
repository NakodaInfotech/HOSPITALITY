<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MiscEnquiryFilter
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
        Me.BlendPanel2 = New VbPowerPack.BlendPanel()
        Me.CHKSELECTALL = New System.Windows.Forms.CheckBox()
        Me.LSTCMP = New System.Windows.Forms.CheckedListBox()
        Me.CMBTYPE = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.CMBSOURCE = New System.Windows.Forms.ComboBox()
        Me.CMBSTATUS = New System.Windows.Forms.ComboBox()
        Me.CHKSUMMARY = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CMBCODE = New System.Windows.Forms.ComboBox()
        Me.txtDeliveryadd = New System.Windows.Forms.TextBox()
        Me.GPREPORTS = New System.Windows.Forms.GroupBox()
        Me.RBGRIDDETAILS = New System.Windows.Forms.RadioButton()
        Me.RBPENDING = New System.Windows.Forms.RadioButton()
        Me.RBCLOSED = New System.Windows.Forms.RadioButton()
        Me.RBCOMPLETED = New System.Windows.Forms.RadioButton()
        Me.RDSOURCE = New System.Windows.Forms.RadioButton()
        Me.RDBMONTHLY = New System.Windows.Forms.RadioButton()
        Me.RDSTATUS = New System.Windows.Forms.RadioButton()
        Me.RDENQHANDLE = New System.Windows.Forms.RadioButton()
        Me.RDBALLDATA = New System.Windows.Forms.RadioButton()
        Me.cmbacccode = New System.Windows.Forms.ComboBox()
        Me.txtadd = New System.Windows.Forms.TextBox()
        Me.TXTTEMP = New System.Windows.Forms.TextBox()
        Me.chkdate = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmdshow = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.BlendPanel2.SuspendLayout()
        Me.GPREPORTS.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel2
        '
        Me.BlendPanel2.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel2.Controls.Add(Me.CHKSELECTALL)
        Me.BlendPanel2.Controls.Add(Me.LSTCMP)
        Me.BlendPanel2.Controls.Add(Me.CMBTYPE)
        Me.BlendPanel2.Controls.Add(Me.Label2)
        Me.BlendPanel2.Controls.Add(Me.Label13)
        Me.BlendPanel2.Controls.Add(Me.CMBSOURCE)
        Me.BlendPanel2.Controls.Add(Me.CMBSTATUS)
        Me.BlendPanel2.Controls.Add(Me.CHKSUMMARY)
        Me.BlendPanel2.Controls.Add(Me.Label5)
        Me.BlendPanel2.Controls.Add(Me.CMBCODE)
        Me.BlendPanel2.Controls.Add(Me.txtDeliveryadd)
        Me.BlendPanel2.Controls.Add(Me.GPREPORTS)
        Me.BlendPanel2.Controls.Add(Me.cmbacccode)
        Me.BlendPanel2.Controls.Add(Me.txtadd)
        Me.BlendPanel2.Controls.Add(Me.TXTTEMP)
        Me.BlendPanel2.Controls.Add(Me.chkdate)
        Me.BlendPanel2.Controls.Add(Me.GroupBox1)
        Me.BlendPanel2.Controls.Add(Me.cmdshow)
        Me.BlendPanel2.Controls.Add(Me.cmdexit)
        Me.BlendPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel2.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel2.Name = "BlendPanel2"
        Me.BlendPanel2.Size = New System.Drawing.Size(773, 420)
        Me.BlendPanel2.TabIndex = 0
        '
        'CHKSELECTALL
        '
        Me.CHKSELECTALL.AutoSize = True
        Me.CHKSELECTALL.BackColor = System.Drawing.Color.Transparent
        Me.CHKSELECTALL.Location = New System.Drawing.Point(375, 116)
        Me.CHKSELECTALL.Name = "CHKSELECTALL"
        Me.CHKSELECTALL.Size = New System.Drawing.Size(130, 19)
        Me.CHKSELECTALL.TabIndex = 747
        Me.CHKSELECTALL.Text = "Select All Company"
        Me.CHKSELECTALL.UseVisualStyleBackColor = False
        '
        'LSTCMP
        '
        Me.LSTCMP.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LSTCMP.FormattingEnabled = True
        Me.LSTCMP.Location = New System.Drawing.Point(375, 141)
        Me.LSTCMP.Name = "LSTCMP"
        Me.LSTCMP.Size = New System.Drawing.Size(330, 174)
        Me.LSTCMP.TabIndex = 7
        '
        'CMBTYPE
        '
        Me.CMBTYPE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBTYPE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBTYPE.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBTYPE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBTYPE.FormattingEnabled = True
        Me.CMBTYPE.Items.AddRange(New Object() {"", "DOMESTIC HOTEL", "INTERNATIONAL HOTEL", "DOMESTIC PACKAGE", "INTERNATIONAL PACKAGE", "DOMESTIC AIRLINE", "INTERNATIONAL AIRLINE", "VISA", "INSURANCE", "RAILWAY", "CAR RENTAL", "MISC"})
        Me.CMBTYPE.Location = New System.Drawing.Point(106, 87)
        Me.CMBTYPE.Name = "CMBTYPE"
        Me.CMBTYPE.Size = New System.Drawing.Size(230, 23)
        Me.CMBTYPE.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(50, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 14)
        Me.Label2.TabIndex = 746
        Me.Label2.Text = "Enq Type"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(60, 34)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(44, 15)
        Me.Label13.TabIndex = 745
        Me.Label13.Text = "Source"
        '
        'CMBSOURCE
        '
        Me.CMBSOURCE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBSOURCE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBSOURCE.BackColor = System.Drawing.Color.White
        Me.CMBSOURCE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBSOURCE.FormattingEnabled = True
        Me.CMBSOURCE.Items.AddRange(New Object() {""})
        Me.CMBSOURCE.Location = New System.Drawing.Point(106, 30)
        Me.CMBSOURCE.Name = "CMBSOURCE"
        Me.CMBSOURCE.Size = New System.Drawing.Size(230, 23)
        Me.CMBSOURCE.TabIndex = 0
        '
        'CMBSTATUS
        '
        Me.CMBSTATUS.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBSTATUS.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBSTATUS.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBSTATUS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBSTATUS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBSTATUS.FormattingEnabled = True
        Me.CMBSTATUS.Items.AddRange(New Object() {"", "Pending", "Cancel", "Confirmed"})
        Me.CMBSTATUS.Location = New System.Drawing.Point(106, 59)
        Me.CMBSTATUS.Name = "CMBSTATUS"
        Me.CMBSTATUS.Size = New System.Drawing.Size(230, 23)
        Me.CMBSTATUS.TabIndex = 1
        '
        'CHKSUMMARY
        '
        Me.CHKSUMMARY.AutoSize = True
        Me.CHKSUMMARY.BackColor = System.Drawing.Color.Transparent
        Me.CHKSUMMARY.Location = New System.Drawing.Point(106, 116)
        Me.CHKSUMMARY.Name = "CHKSUMMARY"
        Me.CHKSUMMARY.Size = New System.Drawing.Size(77, 19)
        Me.CHKSUMMARY.TabIndex = 3
        Me.CHKSUMMARY.Text = "Summary"
        Me.CHKSUMMARY.UseVisualStyleBackColor = False
        Me.CHKSUMMARY.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(63, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 14)
        Me.Label5.TabIndex = 740
        Me.Label5.Text = "Status"
        '
        'CMBCODE
        '
        Me.CMBCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCODE.FormattingEnabled = True
        Me.CMBCODE.Items.AddRange(New Object() {"C/R", "O/R"})
        Me.CMBCODE.Location = New System.Drawing.Point(722, 12)
        Me.CMBCODE.Name = "CMBCODE"
        Me.CMBCODE.Size = New System.Drawing.Size(28, 22)
        Me.CMBCODE.TabIndex = 738
        Me.CMBCODE.Visible = False
        '
        'txtDeliveryadd
        '
        Me.txtDeliveryadd.BackColor = System.Drawing.Color.White
        Me.txtDeliveryadd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDeliveryadd.Enabled = False
        Me.txtDeliveryadd.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeliveryadd.Location = New System.Drawing.Point(719, 13)
        Me.txtDeliveryadd.Name = "txtDeliveryadd"
        Me.txtDeliveryadd.ReadOnly = True
        Me.txtDeliveryadd.Size = New System.Drawing.Size(34, 22)
        Me.txtDeliveryadd.TabIndex = 737
        Me.txtDeliveryadd.TabStop = False
        Me.txtDeliveryadd.Visible = False
        '
        'GPREPORTS
        '
        Me.GPREPORTS.BackColor = System.Drawing.Color.Transparent
        Me.GPREPORTS.Controls.Add(Me.RBGRIDDETAILS)
        Me.GPREPORTS.Controls.Add(Me.RBPENDING)
        Me.GPREPORTS.Controls.Add(Me.RBCLOSED)
        Me.GPREPORTS.Controls.Add(Me.RBCOMPLETED)
        Me.GPREPORTS.Controls.Add(Me.RDSOURCE)
        Me.GPREPORTS.Controls.Add(Me.RDBMONTHLY)
        Me.GPREPORTS.Controls.Add(Me.RDSTATUS)
        Me.GPREPORTS.Controls.Add(Me.RDENQHANDLE)
        Me.GPREPORTS.Controls.Add(Me.RDBALLDATA)
        Me.GPREPORTS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GPREPORTS.Location = New System.Drawing.Point(62, 141)
        Me.GPREPORTS.Name = "GPREPORTS"
        Me.GPREPORTS.Size = New System.Drawing.Size(295, 147)
        Me.GPREPORTS.TabIndex = 4
        Me.GPREPORTS.TabStop = False
        '
        'RBGRIDDETAILS
        '
        Me.RBGRIDDETAILS.AutoSize = True
        Me.RBGRIDDETAILS.Location = New System.Drawing.Point(19, 115)
        Me.RBGRIDDETAILS.Name = "RBGRIDDETAILS"
        Me.RBGRIDDETAILS.Size = New System.Drawing.Size(91, 18)
        Me.RBGRIDDETAILS.TabIndex = 4
        Me.RBGRIDDETAILS.Text = "Grid Details"
        Me.RBGRIDDETAILS.UseVisualStyleBackColor = True
        '
        'RBPENDING
        '
        Me.RBPENDING.AutoSize = True
        Me.RBPENDING.Location = New System.Drawing.Point(147, 67)
        Me.RBPENDING.Name = "RBPENDING"
        Me.RBPENDING.Size = New System.Drawing.Size(72, 18)
        Me.RBPENDING.TabIndex = 7
        Me.RBPENDING.Text = "Pending "
        Me.RBPENDING.UseVisualStyleBackColor = True
        Me.RBPENDING.Visible = False
        '
        'RBCLOSED
        '
        Me.RBCLOSED.AutoSize = True
        Me.RBCLOSED.Location = New System.Drawing.Point(147, 91)
        Me.RBCLOSED.Name = "RBCLOSED"
        Me.RBCLOSED.Size = New System.Drawing.Size(62, 18)
        Me.RBCLOSED.TabIndex = 8
        Me.RBCLOSED.Text = "Closed"
        Me.RBCLOSED.UseVisualStyleBackColor = True
        Me.RBCLOSED.Visible = False
        '
        'RBCOMPLETED
        '
        Me.RBCOMPLETED.AutoSize = True
        Me.RBCOMPLETED.Location = New System.Drawing.Point(19, 91)
        Me.RBCOMPLETED.Name = "RBCOMPLETED"
        Me.RBCOMPLETED.Size = New System.Drawing.Size(79, 18)
        Me.RBCOMPLETED.TabIndex = 3
        Me.RBCOMPLETED.Text = "Confirmed"
        Me.RBCOMPLETED.UseVisualStyleBackColor = True
        Me.RBCOMPLETED.Visible = False
        '
        'RDSOURCE
        '
        Me.RDSOURCE.AutoSize = True
        Me.RDSOURCE.Location = New System.Drawing.Point(19, 43)
        Me.RDSOURCE.Name = "RDSOURCE"
        Me.RDSOURCE.Size = New System.Drawing.Size(92, 18)
        Me.RDSOURCE.TabIndex = 1
        Me.RDSOURCE.Text = "Source Wise"
        Me.RDSOURCE.UseVisualStyleBackColor = True
        '
        'RDBMONTHLY
        '
        Me.RDBMONTHLY.AutoSize = True
        Me.RDBMONTHLY.Location = New System.Drawing.Point(19, 67)
        Me.RDBMONTHLY.Name = "RDBMONTHLY"
        Me.RDBMONTHLY.Size = New System.Drawing.Size(69, 18)
        Me.RDBMONTHLY.TabIndex = 2
        Me.RDBMONTHLY.Text = "Monthly"
        Me.RDBMONTHLY.UseVisualStyleBackColor = True
        '
        'RDSTATUS
        '
        Me.RDSTATUS.AutoSize = True
        Me.RDSTATUS.Location = New System.Drawing.Point(147, 19)
        Me.RDSTATUS.Name = "RDSTATUS"
        Me.RDSTATUS.Size = New System.Drawing.Size(90, 18)
        Me.RDSTATUS.TabIndex = 5
        Me.RDSTATUS.Text = "Status Wise"
        Me.RDSTATUS.UseVisualStyleBackColor = True
        '
        'RDENQHANDLE
        '
        Me.RDENQHANDLE.AutoSize = True
        Me.RDENQHANDLE.Location = New System.Drawing.Point(147, 43)
        Me.RDENQHANDLE.Name = "RDENQHANDLE"
        Me.RDENQHANDLE.Size = New System.Drawing.Size(146, 18)
        Me.RDENQHANDLE.TabIndex = 6
        Me.RDENQHANDLE.Text = "Enquiry Handled Wise"
        Me.RDENQHANDLE.UseVisualStyleBackColor = True
        '
        'RDBALLDATA
        '
        Me.RDBALLDATA.AutoSize = True
        Me.RDBALLDATA.Checked = True
        Me.RDBALLDATA.Location = New System.Drawing.Point(19, 19)
        Me.RDBALLDATA.Name = "RDBALLDATA"
        Me.RDBALLDATA.Size = New System.Drawing.Size(68, 18)
        Me.RDBALLDATA.TabIndex = 0
        Me.RDBALLDATA.TabStop = True
        Me.RDBALLDATA.Text = "All data"
        Me.RDBALLDATA.UseVisualStyleBackColor = True
        '
        'cmbacccode
        '
        Me.cmbacccode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbacccode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbacccode.BackColor = System.Drawing.Color.White
        Me.cmbacccode.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbacccode.FormattingEnabled = True
        Me.cmbacccode.Location = New System.Drawing.Point(721, 14)
        Me.cmbacccode.MaxDropDownItems = 14
        Me.cmbacccode.Name = "cmbacccode"
        Me.cmbacccode.Size = New System.Drawing.Size(30, 22)
        Me.cmbacccode.TabIndex = 650
        Me.cmbacccode.Visible = False
        '
        'txtadd
        '
        Me.txtadd.Location = New System.Drawing.Point(721, 13)
        Me.txtadd.Name = "txtadd"
        Me.txtadd.Size = New System.Drawing.Size(30, 23)
        Me.txtadd.TabIndex = 649
        Me.txtadd.Visible = False
        '
        'TXTTEMP
        '
        Me.TXTTEMP.Location = New System.Drawing.Point(718, 15)
        Me.TXTTEMP.Name = "TXTTEMP"
        Me.TXTTEMP.Size = New System.Drawing.Size(30, 23)
        Me.TXTTEMP.TabIndex = 646
        Me.TXTTEMP.Visible = False
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.ForeColor = System.Drawing.Color.Black
        Me.chkdate.Location = New System.Drawing.Point(70, 307)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(52, 18)
        Me.chkdate.TabIndex = 5
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.dtto)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtfrom)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(62, 310)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(280, 53)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'dtto
        '
        Me.dtto.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(189, 20)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(83, 22)
        Me.dtto.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(161, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 14)
        Me.Label1.TabIndex = 106
        Me.Label1.Text = "To :"
        '
        'dtfrom
        '
        Me.dtfrom.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfrom.Location = New System.Drawing.Point(50, 20)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(83, 22)
        Me.dtfrom.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(9, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 14)
        Me.Label7.TabIndex = 104
        Me.Label7.Text = "From :"
        '
        'cmdshow
        '
        Me.cmdshow.BackColor = System.Drawing.Color.Transparent
        Me.cmdshow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdshow.FlatAppearance.BorderSize = 0
        Me.cmdshow.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdshow.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdshow.Location = New System.Drawing.Point(383, 335)
        Me.cmdshow.Name = "cmdshow"
        Me.cmdshow.Size = New System.Drawing.Size(88, 28)
        Me.cmdshow.TabIndex = 8
        Me.cmdshow.Text = "&Show Details"
        Me.cmdshow.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(477, 335)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(88, 28)
        Me.cmdexit.TabIndex = 9
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'MiscEnquiryFilter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(773, 420)
        Me.Controls.Add(Me.BlendPanel2)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "MiscEnquiryFilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Enquiry Filter"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel2.ResumeLayout(False)
        Me.BlendPanel2.PerformLayout()
        Me.GPREPORTS.ResumeLayout(False)
        Me.GPREPORTS.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel2 As VbPowerPack.BlendPanel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents CMBSOURCE As System.Windows.Forms.ComboBox
    Friend WithEvents CMBSTATUS As System.Windows.Forms.ComboBox
    Friend WithEvents CHKSUMMARY As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CMBCODE As System.Windows.Forms.ComboBox
    Friend WithEvents txtDeliveryadd As System.Windows.Forms.TextBox
    Friend WithEvents GPREPORTS As System.Windows.Forms.GroupBox
    Friend WithEvents RBPENDING As System.Windows.Forms.RadioButton
    Friend WithEvents RBCLOSED As System.Windows.Forms.RadioButton
    Friend WithEvents RBCOMPLETED As System.Windows.Forms.RadioButton
    Friend WithEvents RDSOURCE As System.Windows.Forms.RadioButton
    Friend WithEvents RDBMONTHLY As System.Windows.Forms.RadioButton
    Friend WithEvents RDSTATUS As System.Windows.Forms.RadioButton
    Friend WithEvents RDENQHANDLE As System.Windows.Forms.RadioButton
    Friend WithEvents RDBALLDATA As System.Windows.Forms.RadioButton
    Friend WithEvents cmbacccode As System.Windows.Forms.ComboBox
    Friend WithEvents txtadd As System.Windows.Forms.TextBox
    Friend WithEvents TXTTEMP As System.Windows.Forms.TextBox
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmdshow As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents CMBTYPE As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LSTCMP As CheckedListBox
    Friend WithEvents RBGRIDDETAILS As RadioButton
    Friend WithEvents CHKSELECTALL As CheckBox
End Class
