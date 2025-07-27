<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SpecialRights
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
        Me.components = New System.ComponentModel.Container()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CHKCHECKIN = New System.Windows.Forms.CheckBox()
        Me.CHKOUTSTANDING = New System.Windows.Forms.CheckBox()
        Me.CHKMISCENQUIRY = New System.Windows.Forms.CheckBox()
        Me.CHKFOLLOWUP = New System.Windows.Forms.CheckBox()
        Me.CHKFETCHDATA = New System.Windows.Forms.CheckBox()
        Me.CHKENQTRANSFER = New System.Windows.Forms.CheckBox()
        Me.CMDEXIT = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CMBUSER = New System.Windows.Forms.ComboBox()
        Me.CMDSAVE = New System.Windows.Forms.Button()
        Me.CHKALL = New System.Windows.Forms.CheckBox()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.CHKMEMBERSHIP = New System.Windows.Forms.CheckBox()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CHKMEMBERSHIP)
        Me.BlendPanel1.Controls.Add(Me.CHKCHECKIN)
        Me.BlendPanel1.Controls.Add(Me.CHKOUTSTANDING)
        Me.BlendPanel1.Controls.Add(Me.CHKMISCENQUIRY)
        Me.BlendPanel1.Controls.Add(Me.CHKFOLLOWUP)
        Me.BlendPanel1.Controls.Add(Me.CHKFETCHDATA)
        Me.BlendPanel1.Controls.Add(Me.CHKENQTRANSFER)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Controls.Add(Me.Label10)
        Me.BlendPanel1.Controls.Add(Me.CMBUSER)
        Me.BlendPanel1.Controls.Add(Me.CMDSAVE)
        Me.BlendPanel1.Controls.Add(Me.CHKALL)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(522, 355)
        Me.BlendPanel1.TabIndex = 0
        '
        'CHKCHECKIN
        '
        Me.CHKCHECKIN.AutoSize = True
        Me.CHKCHECKIN.BackColor = System.Drawing.Color.Transparent
        Me.CHKCHECKIN.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKCHECKIN.Location = New System.Drawing.Point(60, 238)
        Me.CHKCHECKIN.Name = "CHKCHECKIN"
        Me.CHKCHECKIN.Size = New System.Drawing.Size(254, 19)
        Me.CHKCHECKIN.TabIndex = 627
        Me.CHKCHECKIN.Text = "Show Tomorrow's Check Ins on Homepage"
        Me.CHKCHECKIN.UseVisualStyleBackColor = False
        '
        'CHKOUTSTANDING
        '
        Me.CHKOUTSTANDING.AutoSize = True
        Me.CHKOUTSTANDING.BackColor = System.Drawing.Color.Transparent
        Me.CHKOUTSTANDING.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKOUTSTANDING.Location = New System.Drawing.Point(60, 213)
        Me.CHKOUTSTANDING.Name = "CHKOUTSTANDING"
        Me.CHKOUTSTANDING.Size = New System.Drawing.Size(250, 19)
        Me.CHKOUTSTANDING.TabIndex = 626
        Me.CHKOUTSTANDING.Text = "Show Rec/Pay Outstanding on Homepage"
        Me.CHKOUTSTANDING.UseVisualStyleBackColor = False
        '
        'CHKMISCENQUIRY
        '
        Me.CHKMISCENQUIRY.AutoSize = True
        Me.CHKMISCENQUIRY.BackColor = System.Drawing.Color.Transparent
        Me.CHKMISCENQUIRY.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKMISCENQUIRY.Location = New System.Drawing.Point(60, 188)
        Me.CHKMISCENQUIRY.Name = "CHKMISCENQUIRY"
        Me.CHKMISCENQUIRY.Size = New System.Drawing.Size(157, 19)
        Me.CHKMISCENQUIRY.TabIndex = 625
        Me.CHKMISCENQUIRY.Text = "Show Pending Enquiries"
        Me.CHKMISCENQUIRY.UseVisualStyleBackColor = False
        '
        'CHKFOLLOWUP
        '
        Me.CHKFOLLOWUP.AutoSize = True
        Me.CHKFOLLOWUP.BackColor = System.Drawing.Color.Transparent
        Me.CHKFOLLOWUP.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKFOLLOWUP.Location = New System.Drawing.Point(60, 163)
        Me.CHKFOLLOWUP.Name = "CHKFOLLOWUP"
        Me.CHKFOLLOWUP.Size = New System.Drawing.Size(154, 19)
        Me.CHKFOLLOWUP.TabIndex = 624
        Me.CHKFOLLOWUP.Text = "Show Followup Reports"
        Me.CHKFOLLOWUP.UseVisualStyleBackColor = False
        '
        'CHKFETCHDATA
        '
        Me.CHKFETCHDATA.AutoSize = True
        Me.CHKFETCHDATA.BackColor = System.Drawing.Color.Transparent
        Me.CHKFETCHDATA.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKFETCHDATA.Location = New System.Drawing.Point(60, 138)
        Me.CHKFETCHDATA.Name = "CHKFETCHDATA"
        Me.CHKFETCHDATA.Size = New System.Drawing.Size(161, 19)
        Me.CHKFETCHDATA.TabIndex = 623
        Me.CHKFETCHDATA.Text = "Fetch Data from Website"
        Me.CHKFETCHDATA.UseVisualStyleBackColor = False
        '
        'CHKENQTRANSFER
        '
        Me.CHKENQTRANSFER.AutoSize = True
        Me.CHKENQTRANSFER.BackColor = System.Drawing.Color.Transparent
        Me.CHKENQTRANSFER.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKENQTRANSFER.Location = New System.Drawing.Point(60, 113)
        Me.CHKENQTRANSFER.Name = "CHKENQTRANSFER"
        Me.CHKENQTRANSFER.Size = New System.Drawing.Size(94, 19)
        Me.CHKENQTRANSFER.TabIndex = 2
        Me.CHKENQTRANSFER.Text = "Enq Transfer"
        Me.CHKENQTRANSFER.UseVisualStyleBackColor = False
        '
        'CMDEXIT
        '
        Me.CMDEXIT.Location = New System.Drawing.Point(264, 315)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 11
        Me.CMDEXIT.Text = "E&xit"
        Me.CMDEXIT.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(44, 26)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(66, 15)
        Me.Label10.TabIndex = 622
        Me.Label10.Text = "User Name"
        '
        'CMBUSER
        '
        Me.CMBUSER.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBUSER.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBUSER.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBUSER.DropDownWidth = 400
        Me.CMBUSER.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBUSER.FormattingEnabled = True
        Me.CMBUSER.Location = New System.Drawing.Point(111, 23)
        Me.CMBUSER.MaxLength = 100
        Me.CMBUSER.Name = "CMBUSER"
        Me.CMBUSER.Size = New System.Drawing.Size(175, 23)
        Me.CMBUSER.TabIndex = 0
        '
        'CMDSAVE
        '
        Me.CMDSAVE.Location = New System.Drawing.Point(178, 315)
        Me.CMDSAVE.Name = "CMDSAVE"
        Me.CMDSAVE.Size = New System.Drawing.Size(80, 28)
        Me.CMDSAVE.TabIndex = 10
        Me.CMDSAVE.Text = "&Save"
        Me.CMDSAVE.UseVisualStyleBackColor = True
        '
        'CHKALL
        '
        Me.CHKALL.AutoSize = True
        Me.CHKALL.BackColor = System.Drawing.Color.Transparent
        Me.CHKALL.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKALL.Location = New System.Drawing.Point(32, 74)
        Me.CHKALL.Name = "CHKALL"
        Me.CHKALL.Size = New System.Drawing.Size(76, 19)
        Me.CHKALL.TabIndex = 1
        Me.CHKALL.Text = "Select &All"
        Me.CHKALL.UseVisualStyleBackColor = False
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'CHKMEMBERSHIP
        '
        Me.CHKMEMBERSHIP.AutoSize = True
        Me.CHKMEMBERSHIP.BackColor = System.Drawing.Color.Transparent
        Me.CHKMEMBERSHIP.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKMEMBERSHIP.Location = New System.Drawing.Point(60, 263)
        Me.CHKMEMBERSHIP.Name = "CHKMEMBERSHIP"
        Me.CHKMEMBERSHIP.Size = New System.Drawing.Size(158, 19)
        Me.CHKMEMBERSHIP.TabIndex = 628
        Me.CHKMEMBERSHIP.Text = "Show Membership Form"
        Me.CHKMEMBERSHIP.UseVisualStyleBackColor = False
        '
        'SpecialRights
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(522, 355)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "SpecialRights"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Special Rights"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CHKENQTRANSFER As System.Windows.Forms.CheckBox
    Friend WithEvents CMDEXIT As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CMBUSER As System.Windows.Forms.ComboBox
    Friend WithEvents CMDSAVE As System.Windows.Forms.Button
    Friend WithEvents CHKALL As System.Windows.Forms.CheckBox
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents CHKFETCHDATA As System.Windows.Forms.CheckBox
    Friend WithEvents CHKMISCENQUIRY As System.Windows.Forms.CheckBox
    Friend WithEvents CHKFOLLOWUP As System.Windows.Forms.CheckBox
    Friend WithEvents CHKCHECKIN As System.Windows.Forms.CheckBox
    Friend WithEvents CHKOUTSTANDING As System.Windows.Forms.CheckBox
    Friend WithEvents CHKMEMBERSHIP As CheckBox
End Class
