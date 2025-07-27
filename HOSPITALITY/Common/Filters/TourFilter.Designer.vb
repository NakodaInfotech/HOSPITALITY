<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TourFilter
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.RBCSV = New System.Windows.Forms.RadioButton
        Me.RBIDCARD = New System.Windows.Forms.RadioButton
        Me.RDBVISA2 = New System.Windows.Forms.RadioButton
        Me.RDBCASH = New System.Windows.Forms.RadioButton
        Me.RDBGIFTPENDING = New System.Windows.Forms.RadioButton
        Me.RDBEMBARKATION = New System.Windows.Forms.RadioButton
        Me.RDBITSCOPY = New System.Windows.Forms.RadioButton
        Me.RDBSAFAI = New System.Windows.Forms.RadioButton
        Me.RDBGIFTPURCHASE = New System.Windows.Forms.RadioButton
        Me.RDBGIFTREG = New System.Windows.Forms.RadioButton
        Me.RDBGIFTSTOCK = New System.Windows.Forms.RadioButton
        Me.RDBPASSPORTLABLE = New System.Windows.Forms.RadioButton
        Me.RDBPHOTO = New System.Windows.Forms.RadioButton
        Me.RDBPASSPHOTO = New System.Windows.Forms.RadioButton
        Me.RDBUPLOAD = New System.Windows.Forms.RadioButton
        Me.RDBITENARY = New System.Windows.Forms.RadioButton
        Me.RDBDECLARE = New System.Windows.Forms.RadioButton
        Me.RDFOREX = New System.Windows.Forms.RadioButton
        Me.RDBKUWAIT = New System.Windows.Forms.RadioButton
        Me.RDBIRAQMU = New System.Windows.Forms.RadioButton
        Me.RDBIRAQAIR = New System.Windows.Forms.RadioButton
        Me.RDBPENDOCS = New System.Windows.Forms.RadioButton
        Me.RDBIRAQ = New System.Windows.Forms.RadioButton
        Me.RDBBMM = New System.Windows.Forms.RadioButton
        Me.RDBITS = New System.Windows.Forms.RadioButton
        Me.RDBPASSLIST = New System.Windows.Forms.RadioButton
        Me.Label10 = New System.Windows.Forms.Label
        Me.CMBTOUR = New System.Windows.Forms.ComboBox
        Me.CMBGUEST = New System.Windows.Forms.ComboBox
        Me.chkdate = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dtto = New System.Windows.Forms.DateTimePicker
        Me.dtfrom = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.BlendPanel2 = New VbPowerPack.BlendPanel
        Me.LBLCURR = New System.Windows.Forms.Label
        Me.CMBCURRENCY = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdshow = New System.Windows.Forms.Button
        Me.cmdexit = New System.Windows.Forms.Button
        Me.RBBAGTAG = New System.Windows.Forms.RadioButton
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.BlendPanel2.SuspendLayout()
        Me.SuspendLayout()
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
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.RBBAGTAG)
        Me.GroupBox3.Controls.Add(Me.RBCSV)
        Me.GroupBox3.Controls.Add(Me.RBIDCARD)
        Me.GroupBox3.Controls.Add(Me.RDBVISA2)
        Me.GroupBox3.Controls.Add(Me.RDBCASH)
        Me.GroupBox3.Controls.Add(Me.RDBGIFTPENDING)
        Me.GroupBox3.Controls.Add(Me.RDBEMBARKATION)
        Me.GroupBox3.Controls.Add(Me.RDBITSCOPY)
        Me.GroupBox3.Controls.Add(Me.RDBSAFAI)
        Me.GroupBox3.Controls.Add(Me.RDBGIFTPURCHASE)
        Me.GroupBox3.Controls.Add(Me.RDBGIFTREG)
        Me.GroupBox3.Controls.Add(Me.RDBGIFTSTOCK)
        Me.GroupBox3.Controls.Add(Me.RDBPASSPORTLABLE)
        Me.GroupBox3.Controls.Add(Me.RDBPHOTO)
        Me.GroupBox3.Controls.Add(Me.RDBPASSPHOTO)
        Me.GroupBox3.Controls.Add(Me.RDBUPLOAD)
        Me.GroupBox3.Controls.Add(Me.RDBITENARY)
        Me.GroupBox3.Controls.Add(Me.RDBDECLARE)
        Me.GroupBox3.Controls.Add(Me.RDFOREX)
        Me.GroupBox3.Controls.Add(Me.RDBKUWAIT)
        Me.GroupBox3.Controls.Add(Me.RDBIRAQMU)
        Me.GroupBox3.Controls.Add(Me.RDBIRAQAIR)
        Me.GroupBox3.Controls.Add(Me.RDBPENDOCS)
        Me.GroupBox3.Controls.Add(Me.RDBIRAQ)
        Me.GroupBox3.Controls.Add(Me.RDBBMM)
        Me.GroupBox3.Controls.Add(Me.RDBITS)
        Me.GroupBox3.Controls.Add(Me.RDBPASSLIST)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(30, 93)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(333, 356)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        '
        'RBCSV
        '
        Me.RBCSV.AutoSize = True
        Me.RBCSV.Location = New System.Drawing.Point(193, 293)
        Me.RBCSV.Name = "RBCSV"
        Me.RBCSV.Size = New System.Drawing.Size(84, 19)
        Me.RBCSV.TabIndex = 26
        Me.RBCSV.TabStop = True
        Me.RBCSV.Text = "CSV Report"
        Me.RBCSV.UseVisualStyleBackColor = True
        '
        'RBIDCARD
        '
        Me.RBIDCARD.AutoSize = True
        Me.RBIDCARD.Location = New System.Drawing.Point(10, 293)
        Me.RBIDCARD.Name = "RBIDCARD"
        Me.RBIDCARD.Size = New System.Drawing.Size(66, 19)
        Me.RBIDCARD.TabIndex = 12
        Me.RBIDCARD.TabStop = True
        Me.RBIDCARD.Text = "ID Card"
        Me.RBIDCARD.UseVisualStyleBackColor = True
        '
        'RDBVISA2
        '
        Me.RDBVISA2.AutoSize = True
        Me.RDBVISA2.Location = New System.Drawing.Point(193, 154)
        Me.RDBVISA2.Name = "RDBVISA2"
        Me.RDBVISA2.Size = New System.Drawing.Size(116, 19)
        Me.RDBVISA2.TabIndex = 20
        Me.RDBVISA2.TabStop = True
        Me.RDBVISA2.Text = "Iraq Visa Form 2"
        Me.RDBVISA2.UseVisualStyleBackColor = True
        '
        'RDBCASH
        '
        Me.RDBCASH.AutoSize = True
        Me.RDBCASH.Location = New System.Drawing.Point(10, 269)
        Me.RDBCASH.Name = "RDBCASH"
        Me.RDBCASH.Size = New System.Drawing.Size(95, 19)
        Me.RDBCASH.TabIndex = 11
        Me.RDBCASH.TabStop = True
        Me.RDBCASH.Text = "Cash Cheque"
        Me.RDBCASH.UseVisualStyleBackColor = True
        '
        'RDBGIFTPENDING
        '
        Me.RDBGIFTPENDING.AutoSize = True
        Me.RDBGIFTPENDING.Location = New System.Drawing.Point(10, 246)
        Me.RDBGIFTPENDING.Name = "RDBGIFTPENDING"
        Me.RDBGIFTPENDING.Size = New System.Drawing.Size(92, 19)
        Me.RDBGIFTPENDING.TabIndex = 10
        Me.RDBGIFTPENDING.TabStop = True
        Me.RDBGIFTPENDING.Text = "Gift Pending"
        Me.RDBGIFTPENDING.UseVisualStyleBackColor = True
        '
        'RDBEMBARKATION
        '
        Me.RDBEMBARKATION.AutoSize = True
        Me.RDBEMBARKATION.Location = New System.Drawing.Point(193, 269)
        Me.RDBEMBARKATION.Name = "RDBEMBARKATION"
        Me.RDBEMBARKATION.Size = New System.Drawing.Size(125, 19)
        Me.RDBEMBARKATION.TabIndex = 25
        Me.RDBEMBARKATION.TabStop = True
        Me.RDBEMBARKATION.Text = "Embarkation Form"
        Me.RDBEMBARKATION.UseVisualStyleBackColor = True
        '
        'RDBITSCOPY
        '
        Me.RDBITSCOPY.AutoSize = True
        Me.RDBITSCOPY.Location = New System.Drawing.Point(193, 200)
        Me.RDBITSCOPY.Name = "RDBITSCOPY"
        Me.RDBITSCOPY.Size = New System.Drawing.Size(71, 19)
        Me.RDBITSCOPY.TabIndex = 22
        Me.RDBITSCOPY.TabStop = True
        Me.RDBITSCOPY.Text = "ITS Copy"
        Me.RDBITSCOPY.UseVisualStyleBackColor = True
        '
        'RDBSAFAI
        '
        Me.RDBSAFAI.AutoSize = True
        Me.RDBSAFAI.Location = New System.Drawing.Point(10, 177)
        Me.RDBSAFAI.Name = "RDBSAFAI"
        Me.RDBSAFAI.Size = New System.Drawing.Size(85, 19)
        Me.RDBSAFAI.TabIndex = 7
        Me.RDBSAFAI.TabStop = True
        Me.RDBSAFAI.Text = "Safai Chitti"
        Me.RDBSAFAI.UseVisualStyleBackColor = True
        '
        'RDBGIFTPURCHASE
        '
        Me.RDBGIFTPURCHASE.AutoSize = True
        Me.RDBGIFTPURCHASE.Location = New System.Drawing.Point(193, 246)
        Me.RDBGIFTPURCHASE.Name = "RDBGIFTPURCHASE"
        Me.RDBGIFTPURCHASE.Size = New System.Drawing.Size(99, 19)
        Me.RDBGIFTPURCHASE.TabIndex = 24
        Me.RDBGIFTPURCHASE.TabStop = True
        Me.RDBGIFTPURCHASE.Text = "Gift Purchase"
        Me.RDBGIFTPURCHASE.UseVisualStyleBackColor = True
        '
        'RDBGIFTREG
        '
        Me.RDBGIFTREG.AutoSize = True
        Me.RDBGIFTREG.Location = New System.Drawing.Point(10, 223)
        Me.RDBGIFTREG.Name = "RDBGIFTREG"
        Me.RDBGIFTREG.Size = New System.Drawing.Size(105, 19)
        Me.RDBGIFTREG.TabIndex = 9
        Me.RDBGIFTREG.TabStop = True
        Me.RDBGIFTREG.Text = "Gift Registered"
        Me.RDBGIFTREG.UseVisualStyleBackColor = True
        '
        'RDBGIFTSTOCK
        '
        Me.RDBGIFTSTOCK.AutoSize = True
        Me.RDBGIFTSTOCK.Location = New System.Drawing.Point(193, 223)
        Me.RDBGIFTSTOCK.Name = "RDBGIFTSTOCK"
        Me.RDBGIFTSTOCK.Size = New System.Drawing.Size(77, 19)
        Me.RDBGIFTSTOCK.TabIndex = 23
        Me.RDBGIFTSTOCK.TabStop = True
        Me.RDBGIFTSTOCK.Text = "Gift Stock"
        Me.RDBGIFTSTOCK.UseVisualStyleBackColor = True
        '
        'RDBPASSPORTLABLE
        '
        Me.RDBPASSPORTLABLE.AutoSize = True
        Me.RDBPASSPORTLABLE.Location = New System.Drawing.Point(10, 200)
        Me.RDBPASSPORTLABLE.Name = "RDBPASSPORTLABLE"
        Me.RDBPASSPORTLABLE.Size = New System.Drawing.Size(106, 19)
        Me.RDBPASSPORTLABLE.TabIndex = 8
        Me.RDBPASSPORTLABLE.TabStop = True
        Me.RDBPASSPORTLABLE.Text = "Passport Lable"
        Me.RDBPASSPORTLABLE.UseVisualStyleBackColor = True
        '
        'RDBPHOTO
        '
        Me.RDBPHOTO.AutoSize = True
        Me.RDBPHOTO.Location = New System.Drawing.Point(193, 177)
        Me.RDBPHOTO.Name = "RDBPHOTO"
        Me.RDBPHOTO.Size = New System.Drawing.Size(94, 19)
        Me.RDBPHOTO.TabIndex = 21
        Me.RDBPHOTO.TabStop = True
        Me.RDBPHOTO.Text = "Photo Graph"
        Me.RDBPHOTO.UseVisualStyleBackColor = True
        '
        'RDBPASSPHOTO
        '
        Me.RDBPASSPHOTO.AutoSize = True
        Me.RDBPASSPHOTO.Location = New System.Drawing.Point(10, 154)
        Me.RDBPASSPHOTO.Name = "RDBPASSPHOTO"
        Me.RDBPASSPHOTO.Size = New System.Drawing.Size(104, 19)
        Me.RDBPASSPHOTO.TabIndex = 6
        Me.RDBPASSPHOTO.TabStop = True
        Me.RDBPASSPHOTO.Text = "Passport Copy"
        Me.RDBPASSPHOTO.UseVisualStyleBackColor = True
        '
        'RDBUPLOAD
        '
        Me.RDBUPLOAD.AutoSize = True
        Me.RDBUPLOAD.Location = New System.Drawing.Point(193, 131)
        Me.RDBUPLOAD.Name = "RDBUPLOAD"
        Me.RDBUPLOAD.Size = New System.Drawing.Size(106, 19)
        Me.RDBUPLOAD.TabIndex = 19
        Me.RDBUPLOAD.TabStop = True
        Me.RDBUPLOAD.Text = "Iraq Visa Form"
        Me.RDBUPLOAD.UseVisualStyleBackColor = True
        '
        'RDBITENARY
        '
        Me.RDBITENARY.AutoSize = True
        Me.RDBITENARY.Location = New System.Drawing.Point(10, 131)
        Me.RDBITENARY.Name = "RDBITENARY"
        Me.RDBITENARY.Size = New System.Drawing.Size(64, 19)
        Me.RDBITENARY.TabIndex = 5
        Me.RDBITENARY.TabStop = True
        Me.RDBITENARY.Text = "Itenary"
        Me.RDBITENARY.UseVisualStyleBackColor = True
        '
        'RDBDECLARE
        '
        Me.RDBDECLARE.AutoSize = True
        Me.RDBDECLARE.Location = New System.Drawing.Point(193, 108)
        Me.RDBDECLARE.Name = "RDBDECLARE"
        Me.RDBDECLARE.Size = New System.Drawing.Size(89, 19)
        Me.RDBDECLARE.TabIndex = 18
        Me.RDBDECLARE.TabStop = True
        Me.RDBDECLARE.Text = "Declaration"
        Me.RDBDECLARE.UseVisualStyleBackColor = True
        '
        'RDFOREX
        '
        Me.RDFOREX.AutoSize = True
        Me.RDFOREX.Location = New System.Drawing.Point(10, 108)
        Me.RDFOREX.Name = "RDFOREX"
        Me.RDFOREX.Size = New System.Drawing.Size(127, 19)
        Me.RDFOREX.TabIndex = 4
        Me.RDFOREX.TabStop = True
        Me.RDFOREX.Text = "Forex Requirement"
        Me.RDFOREX.UseVisualStyleBackColor = True
        '
        'RDBKUWAIT
        '
        Me.RDBKUWAIT.AutoSize = True
        Me.RDBKUWAIT.Location = New System.Drawing.Point(10, 85)
        Me.RDBKUWAIT.Name = "RDBKUWAIT"
        Me.RDBKUWAIT.Size = New System.Drawing.Size(132, 19)
        Me.RDBKUWAIT.TabIndex = 3
        Me.RDBKUWAIT.TabStop = True
        Me.RDBKUWAIT.Text = "Kuwait Airways List"
        Me.RDBKUWAIT.UseVisualStyleBackColor = True
        '
        'RDBIRAQMU
        '
        Me.RDBIRAQMU.AutoSize = True
        Me.RDBIRAQMU.Location = New System.Drawing.Point(10, 62)
        Me.RDBIRAQMU.Name = "RDBIRAQMU"
        Me.RDBIRAQMU.Size = New System.Drawing.Size(130, 19)
        Me.RDBIRAQMU.TabIndex = 2
        Me.RDBIRAQMU.TabStop = True
        Me.RDBIRAQMU.Text = "Iraq Muwafeka List"
        Me.RDBIRAQMU.UseVisualStyleBackColor = True
        '
        'RDBIRAQAIR
        '
        Me.RDBIRAQAIR.AutoSize = True
        Me.RDBIRAQAIR.Location = New System.Drawing.Point(193, 85)
        Me.RDBIRAQAIR.Name = "RDBIRAQAIR"
        Me.RDBIRAQAIR.Size = New System.Drawing.Size(95, 19)
        Me.RDBIRAQAIR.TabIndex = 17
        Me.RDBIRAQAIR.TabStop = True
        Me.RDBIRAQAIR.Text = "Iraq Airways"
        Me.RDBIRAQAIR.UseVisualStyleBackColor = True
        '
        'RDBPENDOCS
        '
        Me.RDBPENDOCS.AutoSize = True
        Me.RDBPENDOCS.Location = New System.Drawing.Point(10, 39)
        Me.RDBPENDOCS.Name = "RDBPENDOCS"
        Me.RDBPENDOCS.Size = New System.Drawing.Size(99, 19)
        Me.RDBPENDOCS.TabIndex = 1
        Me.RDBPENDOCS.TabStop = True
        Me.RDBPENDOCS.Text = "Pending Docs"
        Me.RDBPENDOCS.UseVisualStyleBackColor = True
        '
        'RDBIRAQ
        '
        Me.RDBIRAQ.AutoSize = True
        Me.RDBIRAQ.Location = New System.Drawing.Point(193, 62)
        Me.RDBIRAQ.Name = "RDBIRAQ"
        Me.RDBIRAQ.Size = New System.Drawing.Size(127, 19)
        Me.RDBIRAQ.TabIndex = 16
        Me.RDBIRAQ.TabStop = True
        Me.RDBIRAQ.Text = "Iraq Visa Manifest"
        Me.RDBIRAQ.UseVisualStyleBackColor = True
        '
        'RDBBMM
        '
        Me.RDBBMM.AutoSize = True
        Me.RDBBMM.Location = New System.Drawing.Point(193, 16)
        Me.RDBBMM.Name = "RDBBMM"
        Me.RDBBMM.Size = New System.Drawing.Size(56, 19)
        Me.RDBBMM.TabIndex = 14
        Me.RDBBMM.TabStop = True
        Me.RDBBMM.Text = "QUDS"
        Me.RDBBMM.UseVisualStyleBackColor = True
        '
        'RDBITS
        '
        Me.RDBITS.AutoSize = True
        Me.RDBITS.Location = New System.Drawing.Point(193, 39)
        Me.RDBITS.Name = "RDBITS"
        Me.RDBITS.Size = New System.Drawing.Size(63, 19)
        Me.RDBITS.TabIndex = 15
        Me.RDBITS.TabStop = True
        Me.RDBITS.Text = "ITS List"
        Me.RDBITS.UseVisualStyleBackColor = True
        '
        'RDBPASSLIST
        '
        Me.RDBPASSLIST.AutoSize = True
        Me.RDBPASSLIST.Checked = True
        Me.RDBPASSLIST.Location = New System.Drawing.Point(10, 16)
        Me.RDBPASSLIST.Name = "RDBPASSLIST"
        Me.RDBPASSLIST.Size = New System.Drawing.Size(73, 19)
        Me.RDBPASSLIST.TabIndex = 0
        Me.RDBPASSLIST.TabStop = True
        Me.RDBPASSLIST.Text = "Pass List"
        Me.RDBPASSLIST.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(43, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 15)
        Me.Label10.TabIndex = 652
        Me.Label10.Text = "Tour Name"
        '
        'CMBTOUR
        '
        Me.CMBTOUR.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBTOUR.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBTOUR.BackColor = System.Drawing.Color.White
        Me.CMBTOUR.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBTOUR.FormattingEnabled = True
        Me.CMBTOUR.Location = New System.Drawing.Point(110, 14)
        Me.CMBTOUR.MaxDropDownItems = 14
        Me.CMBTOUR.Name = "CMBTOUR"
        Me.CMBTOUR.Size = New System.Drawing.Size(230, 23)
        Me.CMBTOUR.TabIndex = 0
        '
        'CMBGUEST
        '
        Me.CMBGUEST.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBGUEST.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBGUEST.BackColor = System.Drawing.Color.White
        Me.CMBGUEST.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBGUEST.FormattingEnabled = True
        Me.CMBGUEST.Location = New System.Drawing.Point(110, 42)
        Me.CMBGUEST.MaxDropDownItems = 14
        Me.CMBGUEST.Name = "CMBGUEST"
        Me.CMBGUEST.Size = New System.Drawing.Size(230, 23)
        Me.CMBGUEST.TabIndex = 1
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.ForeColor = System.Drawing.Color.Black
        Me.chkdate.Location = New System.Drawing.Point(42, 455)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(51, 19)
        Me.chkdate.TabIndex = 4
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
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(34, 458)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(280, 53)
        Me.GroupBox1.TabIndex = 4
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
        'BlendPanel2
        '
        Me.BlendPanel2.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel2.Controls.Add(Me.LBLCURR)
        Me.BlendPanel2.Controls.Add(Me.CMBCURRENCY)
        Me.BlendPanel2.Controls.Add(Me.Label4)
        Me.BlendPanel2.Controls.Add(Me.GroupBox3)
        Me.BlendPanel2.Controls.Add(Me.Label10)
        Me.BlendPanel2.Controls.Add(Me.CMBTOUR)
        Me.BlendPanel2.Controls.Add(Me.CMBGUEST)
        Me.BlendPanel2.Controls.Add(Me.chkdate)
        Me.BlendPanel2.Controls.Add(Me.GroupBox1)
        Me.BlendPanel2.Controls.Add(Me.cmdshow)
        Me.BlendPanel2.Controls.Add(Me.cmdexit)
        Me.BlendPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel2.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel2.Name = "BlendPanel2"
        Me.BlendPanel2.Size = New System.Drawing.Size(390, 562)
        Me.BlendPanel2.TabIndex = 0
        '
        'LBLCURR
        '
        Me.LBLCURR.AutoSize = True
        Me.LBLCURR.BackColor = System.Drawing.Color.Transparent
        Me.LBLCURR.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCURR.ForeColor = System.Drawing.Color.Black
        Me.LBLCURR.Location = New System.Drawing.Point(52, 74)
        Me.LBLCURR.Name = "LBLCURR"
        Me.LBLCURR.Size = New System.Drawing.Size(56, 15)
        Me.LBLCURR.TabIndex = 742
        Me.LBLCURR.Text = "Currency"
        Me.LBLCURR.Visible = False
        '
        'CMBCURRENCY
        '
        Me.CMBCURRENCY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCURRENCY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCURRENCY.BackColor = System.Drawing.Color.White
        Me.CMBCURRENCY.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCURRENCY.FormattingEnabled = True
        Me.CMBCURRENCY.Location = New System.Drawing.Point(110, 71)
        Me.CMBCURRENCY.MaxDropDownItems = 14
        Me.CMBCURRENCY.Name = "CMBCURRENCY"
        Me.CMBCURRENCY.Size = New System.Drawing.Size(110, 23)
        Me.CMBCURRENCY.TabIndex = 2
        Me.CMBCURRENCY.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(36, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 15)
        Me.Label4.TabIndex = 740
        Me.Label4.Text = "Guest Name"
        '
        'cmdshow
        '
        Me.cmdshow.BackColor = System.Drawing.Color.Transparent
        Me.cmdshow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdshow.FlatAppearance.BorderSize = 0
        Me.cmdshow.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdshow.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdshow.Location = New System.Drawing.Point(82, 522)
        Me.cmdshow.Name = "cmdshow"
        Me.cmdshow.Size = New System.Drawing.Size(88, 28)
        Me.cmdshow.TabIndex = 5
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
        Me.cmdexit.Location = New System.Drawing.Point(176, 522)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(88, 28)
        Me.cmdexit.TabIndex = 6
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'RBBAGTAG
        '
        Me.RBBAGTAG.AutoSize = True
        Me.RBBAGTAG.Location = New System.Drawing.Point(9, 318)
        Me.RBBAGTAG.Name = "RBBAGTAG"
        Me.RBBAGTAG.Size = New System.Drawing.Size(97, 19)
        Me.RBBAGTAG.TabIndex = 13
        Me.RBBAGTAG.TabStop = True
        Me.RBBAGTAG.Text = "Baggage Tags"
        Me.RBBAGTAG.UseVisualStyleBackColor = True
        '
        'TourFilter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(390, 562)
        Me.Controls.Add(Me.BlendPanel2)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "TourFilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Tour Filter"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.BlendPanel2.ResumeLayout(False)
        Me.BlendPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents RDBPASSLIST As System.Windows.Forms.RadioButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CMBTOUR As System.Windows.Forms.ComboBox
    Friend WithEvents CMBGUEST As System.Windows.Forms.ComboBox
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents BlendPanel2 As VbPowerPack.BlendPanel
    Friend WithEvents cmdshow As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents RDBITS As System.Windows.Forms.RadioButton
    Friend WithEvents RDBBMM As System.Windows.Forms.RadioButton
    Friend WithEvents RDBIRAQ As System.Windows.Forms.RadioButton
    Friend WithEvents RDBPENDOCS As System.Windows.Forms.RadioButton
    Friend WithEvents RDBIRAQAIR As System.Windows.Forms.RadioButton
    Friend WithEvents RDBKUWAIT As System.Windows.Forms.RadioButton
    Friend WithEvents RDBIRAQMU As System.Windows.Forms.RadioButton
    Friend WithEvents RDFOREX As System.Windows.Forms.RadioButton
    Friend WithEvents LBLCURR As System.Windows.Forms.Label
    Friend WithEvents CMBCURRENCY As System.Windows.Forms.ComboBox
    Friend WithEvents RDBDECLARE As System.Windows.Forms.RadioButton
    Friend WithEvents RDBITENARY As System.Windows.Forms.RadioButton
    Friend WithEvents RDBUPLOAD As System.Windows.Forms.RadioButton
    Friend WithEvents RDBPASSPHOTO As System.Windows.Forms.RadioButton
    Friend WithEvents RDBPHOTO As System.Windows.Forms.RadioButton
    Friend WithEvents RDBPASSPORTLABLE As System.Windows.Forms.RadioButton
    Friend WithEvents RDBGIFTSTOCK As System.Windows.Forms.RadioButton
    Friend WithEvents RDBGIFTREG As System.Windows.Forms.RadioButton
    Friend WithEvents RDBGIFTPURCHASE As System.Windows.Forms.RadioButton
    Friend WithEvents RDBITSCOPY As System.Windows.Forms.RadioButton
    Friend WithEvents RDBSAFAI As System.Windows.Forms.RadioButton
    Friend WithEvents RDBEMBARKATION As System.Windows.Forms.RadioButton
    Friend WithEvents RDBGIFTPENDING As System.Windows.Forms.RadioButton
    Friend WithEvents RDBCASH As System.Windows.Forms.RadioButton
    Friend WithEvents RDBVISA2 As System.Windows.Forms.RadioButton
    Friend WithEvents RBIDCARD As System.Windows.Forms.RadioButton
    Friend WithEvents RBCSV As System.Windows.Forms.RadioButton
    Friend WithEvents RBBAGTAG As System.Windows.Forms.RadioButton
End Class
