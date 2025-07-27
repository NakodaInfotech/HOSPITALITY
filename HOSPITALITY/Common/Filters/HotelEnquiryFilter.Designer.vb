<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HotelEnquiryFilter
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
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.cmdshow = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chkdate = New System.Windows.Forms.CheckBox()
        Me.TXTTEMP = New System.Windows.Forms.TextBox()
        Me.txtadd = New System.Windows.Forms.TextBox()
        Me.cmbacccode = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RDBOOKEDBY = New System.Windows.Forms.RadioButton()
        Me.RBPENDING = New System.Windows.Forms.RadioButton()
        Me.RBCLOSED = New System.Windows.Forms.RadioButton()
        Me.RBCOMPLETED = New System.Windows.Forms.RadioButton()
        Me.RDBHOTEL = New System.Windows.Forms.RadioButton()
        Me.RDBGUEST = New System.Windows.Forms.RadioButton()
        Me.txtDeliveryadd = New System.Windows.Forms.TextBox()
        Me.CMBCODE = New System.Windows.Forms.ComboBox()
        Me.CHKSUMMARY = New System.Windows.Forms.CheckBox()
        Me.CMBITEMCODE = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CMBHOTELNAME = New System.Windows.Forms.ComboBox()
        Me.cmbhotelcode = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CMBGUESTNAME = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CMBBOOKEDBY = New System.Windows.Forms.ComboBox()
        Me.BlendPanel2 = New VbPowerPack.BlendPanel()
        Me.LSTCMP = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.BlendPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(196, 406)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 9
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'cmdshow
        '
        Me.cmdshow.BackColor = System.Drawing.Color.Transparent
        Me.cmdshow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdshow.FlatAppearance.BorderSize = 0
        Me.cmdshow.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdshow.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdshow.Location = New System.Drawing.Point(104, 406)
        Me.cmdshow.Name = "cmdshow"
        Me.cmdshow.Size = New System.Drawing.Size(86, 28)
        Me.cmdshow.TabIndex = 8
        Me.cmdshow.Text = "&Show Details"
        Me.cmdshow.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.dtto)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtfrom)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(52, 338)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(280, 53)
        Me.GroupBox1.TabIndex = 7
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
        Me.Label1.TabIndex = 1
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
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "From :"
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.ForeColor = System.Drawing.Color.Black
        Me.chkdate.Location = New System.Drawing.Point(60, 332)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(52, 18)
        Me.chkdate.TabIndex = 443
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'TXTTEMP
        '
        Me.TXTTEMP.Location = New System.Drawing.Point(62, 405)
        Me.TXTTEMP.Name = "TXTTEMP"
        Me.TXTTEMP.Size = New System.Drawing.Size(30, 23)
        Me.TXTTEMP.TabIndex = 646
        Me.TXTTEMP.Visible = False
        '
        'txtadd
        '
        Me.txtadd.Location = New System.Drawing.Point(59, 407)
        Me.txtadd.Name = "txtadd"
        Me.txtadd.Size = New System.Drawing.Size(30, 23)
        Me.txtadd.TabIndex = 649
        Me.txtadd.Visible = False
        '
        'cmbacccode
        '
        Me.cmbacccode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbacccode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbacccode.BackColor = System.Drawing.Color.White
        Me.cmbacccode.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbacccode.FormattingEnabled = True
        Me.cmbacccode.Location = New System.Drawing.Point(59, 406)
        Me.cmbacccode.MaxDropDownItems = 14
        Me.cmbacccode.Name = "cmbacccode"
        Me.cmbacccode.Size = New System.Drawing.Size(30, 22)
        Me.cmbacccode.TabIndex = 650
        Me.cmbacccode.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.RDBOOKEDBY)
        Me.GroupBox3.Controls.Add(Me.RBPENDING)
        Me.GroupBox3.Controls.Add(Me.RBCLOSED)
        Me.GroupBox3.Controls.Add(Me.RBCOMPLETED)
        Me.GroupBox3.Controls.Add(Me.RDBHOTEL)
        Me.GroupBox3.Controls.Add(Me.RDBGUEST)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(46, 139)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(288, 102)
        Me.GroupBox3.TabIndex = 657
        Me.GroupBox3.TabStop = False
        '
        'RDBOOKEDBY
        '
        Me.RDBOOKEDBY.AutoSize = True
        Me.RDBOOKEDBY.Location = New System.Drawing.Point(26, 71)
        Me.RDBOOKEDBY.Name = "RDBOOKEDBY"
        Me.RDBOOKEDBY.Size = New System.Drawing.Size(81, 18)
        Me.RDBOOKEDBY.TabIndex = 10
        Me.RDBOOKEDBY.Text = "Booked By"
        Me.RDBOOKEDBY.UseVisualStyleBackColor = True
        '
        'RBPENDING
        '
        Me.RBPENDING.AutoSize = True
        Me.RBPENDING.Location = New System.Drawing.Point(155, 21)
        Me.RBPENDING.Name = "RBPENDING"
        Me.RBPENDING.Size = New System.Drawing.Size(108, 18)
        Me.RBPENDING.TabIndex = 9
        Me.RBPENDING.Text = "Pending Orders"
        Me.RBPENDING.UseVisualStyleBackColor = True
        '
        'RBCLOSED
        '
        Me.RBCLOSED.AutoSize = True
        Me.RBCLOSED.Location = New System.Drawing.Point(155, 45)
        Me.RBCLOSED.Name = "RBCLOSED"
        Me.RBCLOSED.Size = New System.Drawing.Size(62, 18)
        Me.RBCLOSED.TabIndex = 8
        Me.RBCLOSED.Text = "Closed"
        Me.RBCLOSED.UseVisualStyleBackColor = True
        '
        'RBCOMPLETED
        '
        Me.RBCOMPLETED.AutoSize = True
        Me.RBCOMPLETED.Location = New System.Drawing.Point(155, 69)
        Me.RBCOMPLETED.Name = "RBCOMPLETED"
        Me.RBCOMPLETED.Size = New System.Drawing.Size(123, 18)
        Me.RBCOMPLETED.TabIndex = 7
        Me.RBCOMPLETED.Text = "Completed Orders"
        Me.RBCOMPLETED.UseVisualStyleBackColor = True
        '
        'RDBHOTEL
        '
        Me.RDBHOTEL.AutoSize = True
        Me.RDBHOTEL.Location = New System.Drawing.Point(26, 47)
        Me.RDBHOTEL.Name = "RDBHOTEL"
        Me.RDBHOTEL.Size = New System.Drawing.Size(86, 18)
        Me.RDBHOTEL.TabIndex = 2
        Me.RDBHOTEL.Text = "Hotel Wise"
        Me.RDBHOTEL.UseVisualStyleBackColor = True
        '
        'RDBGUEST
        '
        Me.RDBGUEST.AutoSize = True
        Me.RDBGUEST.Checked = True
        Me.RDBGUEST.Location = New System.Drawing.Point(26, 22)
        Me.RDBGUEST.Name = "RDBGUEST"
        Me.RDBGUEST.Size = New System.Drawing.Size(88, 18)
        Me.RDBGUEST.TabIndex = 0
        Me.RDBGUEST.TabStop = True
        Me.RDBGUEST.Text = "Guest Wise"
        Me.RDBGUEST.UseVisualStyleBackColor = True
        '
        'txtDeliveryadd
        '
        Me.txtDeliveryadd.BackColor = System.Drawing.Color.White
        Me.txtDeliveryadd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDeliveryadd.Enabled = False
        Me.txtDeliveryadd.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeliveryadd.Location = New System.Drawing.Point(57, 405)
        Me.txtDeliveryadd.Name = "txtDeliveryadd"
        Me.txtDeliveryadd.ReadOnly = True
        Me.txtDeliveryadd.Size = New System.Drawing.Size(34, 22)
        Me.txtDeliveryadd.TabIndex = 737
        Me.txtDeliveryadd.TabStop = False
        Me.txtDeliveryadd.Visible = False
        '
        'CMBCODE
        '
        Me.CMBCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCODE.FormattingEnabled = True
        Me.CMBCODE.Items.AddRange(New Object() {"C/R", "O/R"})
        Me.CMBCODE.Location = New System.Drawing.Point(60, 406)
        Me.CMBCODE.Name = "CMBCODE"
        Me.CMBCODE.Size = New System.Drawing.Size(28, 22)
        Me.CMBCODE.TabIndex = 738
        Me.CMBCODE.Visible = False
        '
        'CHKSUMMARY
        '
        Me.CHKSUMMARY.AutoSize = True
        Me.CHKSUMMARY.BackColor = System.Drawing.Color.Transparent
        Me.CHKSUMMARY.Location = New System.Drawing.Point(88, 114)
        Me.CHKSUMMARY.Name = "CHKSUMMARY"
        Me.CHKSUMMARY.Size = New System.Drawing.Size(77, 19)
        Me.CHKSUMMARY.TabIndex = 7
        Me.CHKSUMMARY.Text = "Summary"
        Me.CHKSUMMARY.UseVisualStyleBackColor = False
        '
        'CMBITEMCODE
        '
        Me.CMBITEMCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBITEMCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBITEMCODE.BackColor = System.Drawing.SystemColors.Window
        Me.CMBITEMCODE.DropDownWidth = 400
        Me.CMBITEMCODE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBITEMCODE.FormattingEnabled = True
        Me.CMBITEMCODE.Location = New System.Drawing.Point(60, 406)
        Me.CMBITEMCODE.Name = "CMBITEMCODE"
        Me.CMBITEMCODE.Size = New System.Drawing.Size(31, 23)
        Me.CMBITEMCODE.TabIndex = 741
        Me.CMBITEMCODE.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(22, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 14)
        Me.Label2.TabIndex = 746
        Me.Label2.Text = "Hotel Name"
        '
        'CMBHOTELNAME
        '
        Me.CMBHOTELNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBHOTELNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBHOTELNAME.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CMBHOTELNAME.FormattingEnabled = True
        Me.CMBHOTELNAME.Items.AddRange(New Object() {""})
        Me.CMBHOTELNAME.Location = New System.Drawing.Point(96, 53)
        Me.CMBHOTELNAME.Name = "CMBHOTELNAME"
        Me.CMBHOTELNAME.Size = New System.Drawing.Size(251, 22)
        Me.CMBHOTELNAME.TabIndex = 743
        '
        'cmbhotelcode
        '
        Me.cmbhotelcode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbhotelcode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbhotelcode.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbhotelcode.FormattingEnabled = True
        Me.cmbhotelcode.Items.AddRange(New Object() {""})
        Me.cmbhotelcode.Location = New System.Drawing.Point(350, 3)
        Me.cmbhotelcode.Name = "cmbhotelcode"
        Me.cmbhotelcode.Size = New System.Drawing.Size(25, 22)
        Me.cmbhotelcode.TabIndex = 745
        Me.cmbhotelcode.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(20, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 14)
        Me.Label3.TabIndex = 747
        Me.Label3.Text = "Guest Name"
        '
        'CMBGUESTNAME
        '
        Me.CMBGUESTNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBGUESTNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBGUESTNAME.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CMBGUESTNAME.FormattingEnabled = True
        Me.CMBGUESTNAME.Items.AddRange(New Object() {""})
        Me.CMBGUESTNAME.Location = New System.Drawing.Point(96, 26)
        Me.CMBGUESTNAME.Name = "CMBGUESTNAME"
        Me.CMBGUESTNAME.Size = New System.Drawing.Size(251, 22)
        Me.CMBGUESTNAME.TabIndex = 742
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(30, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 14)
        Me.Label4.TabIndex = 749
        Me.Label4.Text = "Booked By"
        '
        'CMBBOOKEDBY
        '
        Me.CMBBOOKEDBY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBBOOKEDBY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBBOOKEDBY.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CMBBOOKEDBY.FormattingEnabled = True
        Me.CMBBOOKEDBY.Items.AddRange(New Object() {""})
        Me.CMBBOOKEDBY.Location = New System.Drawing.Point(96, 80)
        Me.CMBBOOKEDBY.Name = "CMBBOOKEDBY"
        Me.CMBBOOKEDBY.Size = New System.Drawing.Size(251, 22)
        Me.CMBBOOKEDBY.TabIndex = 748
        '
        'BlendPanel2
        '
        Me.BlendPanel2.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel2.Controls.Add(Me.LSTCMP)
        Me.BlendPanel2.Controls.Add(Me.CMBBOOKEDBY)
        Me.BlendPanel2.Controls.Add(Me.Label4)
        Me.BlendPanel2.Controls.Add(Me.CMBGUESTNAME)
        Me.BlendPanel2.Controls.Add(Me.Label3)
        Me.BlendPanel2.Controls.Add(Me.cmbhotelcode)
        Me.BlendPanel2.Controls.Add(Me.CMBHOTELNAME)
        Me.BlendPanel2.Controls.Add(Me.Label2)
        Me.BlendPanel2.Controls.Add(Me.CMBITEMCODE)
        Me.BlendPanel2.Controls.Add(Me.CHKSUMMARY)
        Me.BlendPanel2.Controls.Add(Me.CMBCODE)
        Me.BlendPanel2.Controls.Add(Me.txtDeliveryadd)
        Me.BlendPanel2.Controls.Add(Me.GroupBox3)
        Me.BlendPanel2.Controls.Add(Me.cmbacccode)
        Me.BlendPanel2.Controls.Add(Me.txtadd)
        Me.BlendPanel2.Controls.Add(Me.TXTTEMP)
        Me.BlendPanel2.Controls.Add(Me.chkdate)
        Me.BlendPanel2.Controls.Add(Me.GroupBox1)
        Me.BlendPanel2.Controls.Add(Me.cmdshow)
        Me.BlendPanel2.Controls.Add(Me.cmdexit)
        Me.BlendPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlendPanel2.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel2.Name = "BlendPanel2"
        Me.BlendPanel2.Size = New System.Drawing.Size(387, 462)
        Me.BlendPanel2.TabIndex = 447
        '
        'LSTCMP
        '
        Me.LSTCMP.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LSTCMP.FormattingEnabled = True
        Me.LSTCMP.Location = New System.Drawing.Point(33, 251)
        Me.LSTCMP.Name = "LSTCMP"
        Me.LSTCMP.Size = New System.Drawing.Size(330, 72)
        Me.LSTCMP.TabIndex = 750
        '
        'HotelEnquiryFilter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(387, 462)
        Me.Controls.Add(Me.BlendPanel2)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "HotelEnquiryFilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Hotel Enquiry Filter"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.BlendPanel2.ResumeLayout(False)
        Me.BlendPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmdexit As Button
    Friend WithEvents cmdshow As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dtto As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents dtfrom As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents chkdate As CheckBox
    Friend WithEvents TXTTEMP As TextBox
    Friend WithEvents txtadd As TextBox
    Friend WithEvents cmbacccode As ComboBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents RDBOOKEDBY As RadioButton
    Friend WithEvents RBPENDING As RadioButton
    Friend WithEvents RBCLOSED As RadioButton
    Friend WithEvents RBCOMPLETED As RadioButton
    Friend WithEvents RDBHOTEL As RadioButton
    Friend WithEvents RDBGUEST As RadioButton
    Friend WithEvents txtDeliveryadd As TextBox
    Friend WithEvents CMBCODE As ComboBox
    Friend WithEvents CHKSUMMARY As CheckBox
    Friend WithEvents CMBITEMCODE As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents CMBHOTELNAME As ComboBox
    Friend WithEvents cmbhotelcode As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents CMBGUESTNAME As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents CMBBOOKEDBY As ComboBox
    Friend WithEvents BlendPanel2 As VbPowerPack.BlendPanel
    Friend WithEvents LSTCMP As CheckedListBox
End Class
