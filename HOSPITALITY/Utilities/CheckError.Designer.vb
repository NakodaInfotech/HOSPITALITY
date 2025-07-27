<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CheckError
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
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.cmdExit = New System.Windows.Forms.Button
        Me.CMBACCCODE = New System.Windows.Forms.ComboBox
        Me.CMBPURCODE = New System.Windows.Forms.ComboBox
        Me.CMBNAME = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.CMBPURNAME = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.CMBGUESTNAME = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbhotelcode = New System.Windows.Forms.ComboBox
        Me.CMBHOTELNAME = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.CMBBOOKEDBY = New System.Windows.Forms.ComboBox
        Me.lblreg = New System.Windows.Forms.Label
        Me.TXTSALELESS = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.CMDOK = New System.Windows.Forms.Button
        Me.CMDCLEAR = New System.Windows.Forms.Button
        Me.GRIDYEAR = New System.Windows.Forms.DataGridView
        Me.GSRNO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GROOMTYPE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GPLAN = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BlendPanel1.SuspendLayout()
        CType(Me.GRIDYEAR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.GRIDYEAR)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.CMDCLEAR)
        Me.BlendPanel1.Controls.Add(Me.TXTSALELESS)
        Me.BlendPanel1.Controls.Add(Me.Label7)
        Me.BlendPanel1.Controls.Add(Me.CMBACCCODE)
        Me.BlendPanel1.Controls.Add(Me.CMBPURCODE)
        Me.BlendPanel1.Controls.Add(Me.CMBNAME)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.CMBPURNAME)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.CMBGUESTNAME)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.cmbhotelcode)
        Me.BlendPanel1.Controls.Add(Me.CMBHOTELNAME)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.CMBBOOKEDBY)
        Me.BlendPanel1.Controls.Add(Me.lblreg)
        Me.BlendPanel1.Controls.Add(Me.cmdExit)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(401, 411)
        Me.BlendPanel1.TabIndex = 11
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.Color.Transparent
        Me.cmdExit.FlatAppearance.BorderSize = 0
        Me.cmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdExit.Image = Global.HOSPITALITY.My.Resources.Resources._Exit
        Me.cmdExit.Location = New System.Drawing.Point(233, 361)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(76, 25)
        Me.cmdExit.TabIndex = 4
        Me.cmdExit.UseVisualStyleBackColor = False
        '
        'CMBACCCODE
        '
        Me.CMBACCCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBACCCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBACCCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBACCCODE.FormattingEnabled = True
        Me.CMBACCCODE.Items.AddRange(New Object() {""})
        Me.CMBACCCODE.Location = New System.Drawing.Point(309, 137)
        Me.CMBACCCODE.Name = "CMBACCCODE"
        Me.CMBACCCODE.Size = New System.Drawing.Size(55, 22)
        Me.CMBACCCODE.TabIndex = 312
        '
        'CMBPURCODE
        '
        Me.CMBPURCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBPURCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBPURCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBPURCODE.FormattingEnabled = True
        Me.CMBPURCODE.Items.AddRange(New Object() {""})
        Me.CMBPURCODE.Location = New System.Drawing.Point(309, 110)
        Me.CMBPURCODE.Name = "CMBPURCODE"
        Me.CMBPURCODE.Size = New System.Drawing.Size(55, 22)
        Me.CMBPURCODE.TabIndex = 311
        '
        'CMBNAME
        '
        Me.CMBNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBNAME.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CMBNAME.FormattingEnabled = True
        Me.CMBNAME.Items.AddRange(New Object() {""})
        Me.CMBNAME.Location = New System.Drawing.Point(113, 137)
        Me.CMBNAME.Name = "CMBNAME"
        Me.CMBNAME.Size = New System.Drawing.Size(194, 22)
        Me.CMBNAME.TabIndex = 303
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(59, 141)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 14)
        Me.Label5.TabIndex = 310
        Me.Label5.Text = "Sale A/C"
        '
        'CMBPURNAME
        '
        Me.CMBPURNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBPURNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBPURNAME.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CMBPURNAME.FormattingEnabled = True
        Me.CMBPURNAME.Items.AddRange(New Object() {""})
        Me.CMBPURNAME.Location = New System.Drawing.Point(113, 110)
        Me.CMBPURNAME.Name = "CMBPURNAME"
        Me.CMBPURNAME.Size = New System.Drawing.Size(194, 22)
        Me.CMBPURNAME.TabIndex = 302
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(66, 114)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 14)
        Me.Label4.TabIndex = 309
        Me.Label4.Text = "Pur A/C"
        '
        'CMBGUESTNAME
        '
        Me.CMBGUESTNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBGUESTNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBGUESTNAME.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CMBGUESTNAME.FormattingEnabled = True
        Me.CMBGUESTNAME.Items.AddRange(New Object() {""})
        Me.CMBGUESTNAME.Location = New System.Drawing.Point(113, 56)
        Me.CMBGUESTNAME.Name = "CMBGUESTNAME"
        Me.CMBGUESTNAME.Size = New System.Drawing.Size(251, 22)
        Me.CMBGUESTNAME.TabIndex = 300
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(37, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 14)
        Me.Label3.TabIndex = 308
        Me.Label3.Text = "Guest Name"
        '
        'cmbhotelcode
        '
        Me.cmbhotelcode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbhotelcode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbhotelcode.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbhotelcode.FormattingEnabled = True
        Me.cmbhotelcode.Items.AddRange(New Object() {""})
        Me.cmbhotelcode.Location = New System.Drawing.Point(309, 84)
        Me.cmbhotelcode.Name = "cmbhotelcode"
        Me.cmbhotelcode.Size = New System.Drawing.Size(55, 22)
        Me.cmbhotelcode.TabIndex = 305
        '
        'CMBHOTELNAME
        '
        Me.CMBHOTELNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBHOTELNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBHOTELNAME.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CMBHOTELNAME.FormattingEnabled = True
        Me.CMBHOTELNAME.Items.AddRange(New Object() {""})
        Me.CMBHOTELNAME.Location = New System.Drawing.Point(113, 83)
        Me.CMBHOTELNAME.Name = "CMBHOTELNAME"
        Me.CMBHOTELNAME.Size = New System.Drawing.Size(194, 22)
        Me.CMBHOTELNAME.TabIndex = 301
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(39, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 14)
        Me.Label2.TabIndex = 307
        Me.Label2.Text = "Hotel Name"
        '
        'CMBBOOKEDBY
        '
        Me.CMBBOOKEDBY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBBOOKEDBY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBBOOKEDBY.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CMBBOOKEDBY.FormattingEnabled = True
        Me.CMBBOOKEDBY.Items.AddRange(New Object() {""})
        Me.CMBBOOKEDBY.Location = New System.Drawing.Point(113, 164)
        Me.CMBBOOKEDBY.Name = "CMBBOOKEDBY"
        Me.CMBBOOKEDBY.Size = New System.Drawing.Size(251, 22)
        Me.CMBBOOKEDBY.TabIndex = 304
        '
        'lblreg
        '
        Me.lblreg.AutoSize = True
        Me.lblreg.BackColor = System.Drawing.Color.Transparent
        Me.lblreg.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.lblreg.Location = New System.Drawing.Point(48, 168)
        Me.lblreg.Name = "lblreg"
        Me.lblreg.Size = New System.Drawing.Size(63, 14)
        Me.lblreg.TabIndex = 306
        Me.lblreg.Text = "Booked By"
        '
        'TXTSALELESS
        '
        Me.TXTSALELESS.BackColor = System.Drawing.Color.White
        Me.TXTSALELESS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSALELESS.ForeColor = System.Drawing.Color.Black
        Me.TXTSALELESS.Location = New System.Drawing.Point(113, 29)
        Me.TXTSALELESS.Name = "TXTSALELESS"
        Me.TXTSALELESS.Size = New System.Drawing.Size(80, 22)
        Me.TXTSALELESS.TabIndex = 313
        Me.TXTSALELESS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(42, 33)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 14)
        Me.Label7.TabIndex = 314
        Me.Label7.Text = "Booking No"
        '
        'CMDOK
        '
        Me.CMDOK.BackColor = System.Drawing.Color.Transparent
        Me.CMDOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDOK.FlatAppearance.BorderSize = 0
        Me.CMDOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDOK.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDOK.Image = Global.HOSPITALITY.My.Resources.Resources.Save
        Me.CMDOK.Location = New System.Drawing.Point(92, 361)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(72, 24)
        Me.CMDOK.TabIndex = 315
        Me.CMDOK.UseVisualStyleBackColor = False
        '
        'CMDCLEAR
        '
        Me.CMDCLEAR.BackColor = System.Drawing.Color.Transparent
        Me.CMDCLEAR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDCLEAR.FlatAppearance.BorderSize = 0
        Me.CMDCLEAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDCLEAR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDCLEAR.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDCLEAR.Image = Global.HOSPITALITY.My.Resources.Resources.clear
        Me.CMDCLEAR.Location = New System.Drawing.Point(164, 359)
        Me.CMDCLEAR.Name = "CMDCLEAR"
        Me.CMDCLEAR.Size = New System.Drawing.Size(72, 27)
        Me.CMDCLEAR.TabIndex = 316
        Me.CMDCLEAR.UseVisualStyleBackColor = False
        '
        'GRIDYEAR
        '
        Me.GRIDYEAR.AllowUserToAddRows = False
        Me.GRIDYEAR.AllowUserToDeleteRows = False
        Me.GRIDYEAR.AllowUserToResizeColumns = False
        Me.GRIDYEAR.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDYEAR.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GRIDYEAR.BackgroundColor = System.Drawing.Color.White
        Me.GRIDYEAR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDYEAR.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.GRIDYEAR.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GRIDYEAR.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GRIDYEAR.ColumnHeadersHeight = 22
        Me.GRIDYEAR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GRIDYEAR.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GSRNO, Me.GROOMTYPE, Me.GPLAN})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDYEAR.DefaultCellStyle = DataGridViewCellStyle3
        Me.GRIDYEAR.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.GRIDYEAR.GridColor = System.Drawing.SystemColors.Control
        Me.GRIDYEAR.Location = New System.Drawing.Point(19, 201)
        Me.GRIDYEAR.MultiSelect = False
        Me.GRIDYEAR.Name = "GRIDYEAR"
        Me.GRIDYEAR.RowHeadersVisible = False
        Me.GRIDYEAR.RowHeadersWidth = 30
        Me.GRIDYEAR.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDYEAR.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.GRIDYEAR.RowTemplate.Height = 20
        Me.GRIDYEAR.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDYEAR.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDYEAR.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDYEAR.Size = New System.Drawing.Size(362, 152)
        Me.GRIDYEAR.TabIndex = 317
        '
        'GSRNO
        '
        Me.GSRNO.HeaderText = "Sr No"
        Me.GSRNO.Name = "GSRNO"
        Me.GSRNO.Width = 50
        '
        'GROOMTYPE
        '
        Me.GROOMTYPE.HeaderText = "Room Type"
        Me.GROOMTYPE.Name = "GROOMTYPE"
        Me.GROOMTYPE.Width = 200
        '
        'GPLAN
        '
        Me.GPLAN.HeaderText = "Plan"
        Me.GPLAN.Name = "GPLAN"
        Me.GPLAN.Width = 80
        '
        'CheckError
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(401, 411)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "CheckError"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Check Error"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.GRIDYEAR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents CMBACCCODE As System.Windows.Forms.ComboBox
    Friend WithEvents CMBPURCODE As System.Windows.Forms.ComboBox
    Friend WithEvents CMBNAME As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CMBPURNAME As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CMBGUESTNAME As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbhotelcode As System.Windows.Forms.ComboBox
    Friend WithEvents CMBHOTELNAME As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CMBBOOKEDBY As System.Windows.Forms.ComboBox
    Friend WithEvents lblreg As System.Windows.Forms.Label
    Friend WithEvents TXTSALELESS As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CMDOK As System.Windows.Forms.Button
    Friend WithEvents CMDCLEAR As System.Windows.Forms.Button
    Friend WithEvents GRIDYEAR As System.Windows.Forms.DataGridView
    Friend WithEvents GSRNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GROOMTYPE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GPLAN As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
