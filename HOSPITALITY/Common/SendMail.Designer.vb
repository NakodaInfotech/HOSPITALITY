<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SendMail
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
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
        Me.PBIMG = New System.Windows.Forms.PictureBox
        Me.CHKSSL = New System.Windows.Forms.CheckBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TXTSMTPPORT = New System.Windows.Forms.TextBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.TXTBODY = New System.Windows.Forms.RichTextBox
        Me.txtmailbody = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmbfifthadd = New System.Windows.Forms.ComboBox
        Me.cmbfourthadd = New System.Windows.Forms.ComboBox
        Me.cmbthirdadd = New System.Windows.Forms.ComboBox
        Me.cmbsecondadd = New System.Windows.Forms.ComboBox
        Me.cmbfirstadd = New System.Windows.Forms.ComboBox
        Me.cmdcancel = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmdok = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Ep = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label10 = New System.Windows.Forms.Label
        Me.TXTAUTOCCEMAIL = New System.Windows.Forms.TextBox
        Me.BlendPanel1.SuspendLayout()
        CType(Me.PBIMG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.Ep, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.TXTAUTOCCEMAIL)
        Me.BlendPanel1.Controls.Add(Me.Label10)
        Me.BlendPanel1.Controls.Add(Me.PBIMG)
        Me.BlendPanel1.Controls.Add(Me.CHKSSL)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.TXTSMTPPORT)
        Me.BlendPanel1.Controls.Add(Me.GroupBox5)
        Me.BlendPanel1.Controls.Add(Me.GroupBox1)
        Me.BlendPanel1.Controls.Add(Me.cmbfifthadd)
        Me.BlendPanel1.Controls.Add(Me.cmbfourthadd)
        Me.BlendPanel1.Controls.Add(Me.cmbthirdadd)
        Me.BlendPanel1.Controls.Add(Me.cmbsecondadd)
        Me.BlendPanel1.Controls.Add(Me.cmbfirstadd)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Controls.Add(Me.Label8)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.GroupBox2)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.Label7)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(355, 459)
        Me.BlendPanel1.TabIndex = 0
        '
        'PBIMG
        '
        Me.PBIMG.BackColor = System.Drawing.Color.Transparent
        Me.PBIMG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PBIMG.ErrorImage = Nothing
        Me.PBIMG.InitialImage = Nothing
        Me.PBIMG.Location = New System.Drawing.Point(266, 413)
        Me.PBIMG.Name = "PBIMG"
        Me.PBIMG.Size = New System.Drawing.Size(74, 37)
        Me.PBIMG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBIMG.TabIndex = 537
        Me.PBIMG.TabStop = False
        Me.PBIMG.Visible = False
        '
        'CHKSSL
        '
        Me.CHKSSL.AutoSize = True
        Me.CHKSSL.BackColor = System.Drawing.Color.Transparent
        Me.CHKSSL.Checked = True
        Me.CHKSSL.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKSSL.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKSSL.Location = New System.Drawing.Point(244, 242)
        Me.CHKSSL.Name = "CHKSSL"
        Me.CHKSSL.Size = New System.Drawing.Size(84, 18)
        Me.CHKSSL.TabIndex = 7
        Me.CHKSSL.Text = "Enable SSL"
        Me.CHKSSL.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(74, 242)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 14)
        Me.Label9.TabIndex = 212
        Me.Label9.Text = "SMTP Port No."
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTSMTPPORT
        '
        Me.TXTSMTPPORT.Location = New System.Drawing.Point(156, 239)
        Me.TXTSMTPPORT.Name = "TXTSMTPPORT"
        Me.TXTSMTPPORT.Size = New System.Drawing.Size(80, 23)
        Me.TXTSMTPPORT.TabIndex = 6
        Me.TXTSMTPPORT.Text = "587"
        Me.TXTSMTPPORT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.TXTBODY)
        Me.GroupBox5.Controls.Add(Me.txtmailbody)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(14, 278)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(326, 135)
        Me.GroupBox5.TabIndex = 8
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Email - Message (Pls. Type the Message in the Box below)"
        '
        'TXTBODY
        '
        Me.TXTBODY.ForeColor = System.Drawing.Color.Black
        Me.TXTBODY.Location = New System.Drawing.Point(251, 97)
        Me.TXTBODY.Name = "TXTBODY"
        Me.TXTBODY.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.TXTBODY.Size = New System.Drawing.Size(63, 32)
        Me.TXTBODY.TabIndex = 1
        Me.TXTBODY.Text = ""
        Me.TXTBODY.Visible = False
        '
        'txtmailbody
        '
        Me.txtmailbody.ForeColor = System.Drawing.Color.Black
        Me.txtmailbody.Location = New System.Drawing.Point(8, 17)
        Me.txtmailbody.Multiline = True
        Me.txtmailbody.Name = "txtmailbody"
        Me.txtmailbody.Size = New System.Drawing.Size(306, 112)
        Me.txtmailbody.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Black
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(14, 375)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(326, 1)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'cmbfifthadd
        '
        Me.cmbfifthadd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbfifthadd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbfifthadd.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbfifthadd.FormattingEnabled = True
        Me.cmbfifthadd.Location = New System.Drawing.Point(156, 183)
        Me.cmbfifthadd.MaxDropDownItems = 14
        Me.cmbfifthadd.Name = "cmbfifthadd"
        Me.cmbfifthadd.Size = New System.Drawing.Size(172, 22)
        Me.cmbfifthadd.TabIndex = 4
        '
        'cmbfourthadd
        '
        Me.cmbfourthadd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbfourthadd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbfourthadd.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbfourthadd.FormattingEnabled = True
        Me.cmbfourthadd.Location = New System.Drawing.Point(156, 153)
        Me.cmbfourthadd.MaxDropDownItems = 14
        Me.cmbfourthadd.Name = "cmbfourthadd"
        Me.cmbfourthadd.Size = New System.Drawing.Size(172, 22)
        Me.cmbfourthadd.TabIndex = 3
        '
        'cmbthirdadd
        '
        Me.cmbthirdadd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbthirdadd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbthirdadd.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbthirdadd.FormattingEnabled = True
        Me.cmbthirdadd.Location = New System.Drawing.Point(156, 123)
        Me.cmbthirdadd.MaxDropDownItems = 14
        Me.cmbthirdadd.Name = "cmbthirdadd"
        Me.cmbthirdadd.Size = New System.Drawing.Size(172, 22)
        Me.cmbthirdadd.TabIndex = 2
        '
        'cmbsecondadd
        '
        Me.cmbsecondadd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbsecondadd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbsecondadd.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbsecondadd.FormattingEnabled = True
        Me.cmbsecondadd.Location = New System.Drawing.Point(156, 93)
        Me.cmbsecondadd.MaxDropDownItems = 14
        Me.cmbsecondadd.Name = "cmbsecondadd"
        Me.cmbsecondadd.Size = New System.Drawing.Size(172, 22)
        Me.cmbsecondadd.TabIndex = 1
        '
        'cmbfirstadd
        '
        Me.cmbfirstadd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbfirstadd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbfirstadd.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbfirstadd.FormattingEnabled = True
        Me.cmbfirstadd.Location = New System.Drawing.Point(156, 63)
        Me.cmbfirstadd.MaxDropDownItems = 14
        Me.cmbfirstadd.Name = "cmbfirstadd"
        Me.cmbfirstadd.Size = New System.Drawing.Size(172, 22)
        Me.cmbfirstadd.TabIndex = 0
        '
        'cmdcancel
        '
        Me.cmdcancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdcancel.FlatAppearance.BorderSize = 0
        Me.cmdcancel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.Black
        Me.cmdcancel.Location = New System.Drawing.Point(180, 422)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(80, 28)
        Me.cmdcancel.TabIndex = 10
        Me.cmdcancel.Text = "E&xit"
        Me.cmdcancel.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 14.0!)
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(13, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 23)
        Me.Label8.TabIndex = 210
        Me.Label8.Text = "E-Mail"
        '
        'cmdok
        '
        Me.cmdok.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(94, 422)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 9
        Me.cmdok.Text = "&Mail"
        Me.cmdok.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.cmdok.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(42, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "First Email Address"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Black
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(14, 271)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(326, 1)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(81, 37)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 14)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "For Example"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(156, 37)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(176, 14)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "noreply.travelmate@gmail.com"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(27, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(127, 14)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Second Email Address"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(38, 127)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 14)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Third Email Address"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(31, 157)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(123, 14)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Fourth Email Address"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(41, 187)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 14)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Fifth Email Address"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Ep
        '
        Me.Ep.BlinkRate = 0
        Me.Ep.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.Ep.ContainerControl = Me
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(25, 215)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(128, 14)
        Me.Label10.TabIndex = 714
        Me.Label10.Text = "Auto CC Email Address"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTAUTOCCEMAIL
        '
        Me.TXTAUTOCCEMAIL.Location = New System.Drawing.Point(156, 211)
        Me.TXTAUTOCCEMAIL.Name = "TXTAUTOCCEMAIL"
        Me.TXTAUTOCCEMAIL.Size = New System.Drawing.Size(172, 23)
        Me.TXTAUTOCCEMAIL.TabIndex = 5
        '
        'SendMail
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(355, 459)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "SendMail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Send Mail"
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.PBIMG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.Ep, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Ep As System.Windows.Forms.ErrorProvider
    Friend WithEvents cmbfifthadd As System.Windows.Forms.ComboBox
    Friend WithEvents cmbfourthadd As System.Windows.Forms.ComboBox
    Friend WithEvents cmbthirdadd As System.Windows.Forms.ComboBox
    Friend WithEvents cmbsecondadd As System.Windows.Forms.ComboBox
    Friend WithEvents cmbfirstadd As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtmailbody As System.Windows.Forms.TextBox
    Friend WithEvents TXTBODY As System.Windows.Forms.RichTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TXTSMTPPORT As System.Windows.Forms.TextBox
    Friend WithEvents CHKSSL As System.Windows.Forms.CheckBox
    Friend WithEvents PBIMG As System.Windows.Forms.PictureBox
    Friend WithEvents TXTAUTOCCEMAIL As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
