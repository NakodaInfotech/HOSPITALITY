<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SaleReportFilter
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
        Me.TXTHOTELADD = New System.Windows.Forms.TextBox
        Me.cmbhotelcode = New System.Windows.Forms.ComboBox
        Me.CMBHOTELNAME = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.chkdate = New System.Windows.Forms.CheckBox
        Me.cmdShowReport = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.CMBBOOKEDBY = New System.Windows.Forms.ComboBox
        Me.lblreg = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dtto = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtfrom = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.BlendPanel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.TXTHOTELADD)
        Me.BlendPanel1.Controls.Add(Me.cmbhotelcode)
        Me.BlendPanel1.Controls.Add(Me.CMBHOTELNAME)
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
        Me.BlendPanel1.Size = New System.Drawing.Size(414, 238)
        Me.BlendPanel1.TabIndex = 0
        '
        'TXTHOTELADD
        '
        Me.TXTHOTELADD.BackColor = System.Drawing.Color.White
        Me.TXTHOTELADD.ForeColor = System.Drawing.Color.DimGray
        Me.TXTHOTELADD.Location = New System.Drawing.Point(8, 9)
        Me.TXTHOTELADD.Multiline = True
        Me.TXTHOTELADD.Name = "TXTHOTELADD"
        Me.TXTHOTELADD.ReadOnly = True
        Me.TXTHOTELADD.Size = New System.Drawing.Size(10, 65)
        Me.TXTHOTELADD.TabIndex = 289
        Me.TXTHOTELADD.Visible = False
        '
        'cmbhotelcode
        '
        Me.cmbhotelcode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbhotelcode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbhotelcode.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbhotelcode.FormattingEnabled = True
        Me.cmbhotelcode.Items.AddRange(New Object() {""})
        Me.cmbhotelcode.Location = New System.Drawing.Point(298, 59)
        Me.cmbhotelcode.Name = "cmbhotelcode"
        Me.cmbhotelcode.Size = New System.Drawing.Size(74, 22)
        Me.cmbhotelcode.TabIndex = 2
        '
        'CMBHOTELNAME
        '
        Me.CMBHOTELNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBHOTELNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBHOTELNAME.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CMBHOTELNAME.FormattingEnabled = True
        Me.CMBHOTELNAME.Items.AddRange(New Object() {""})
        Me.CMBHOTELNAME.Location = New System.Drawing.Point(102, 59)
        Me.CMBHOTELNAME.Name = "CMBHOTELNAME"
        Me.CMBHOTELNAME.Size = New System.Drawing.Size(194, 22)
        Me.CMBHOTELNAME.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(28, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 14)
        Me.Label2.TabIndex = 288
        Me.Label2.Text = "Hotel Name"
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.chkdate.Location = New System.Drawing.Point(51, 103)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(52, 18)
        Me.chkdate.TabIndex = 3
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'cmdShowReport
        '
        Me.cmdShowReport.BackColor = System.Drawing.Color.Transparent
        Me.cmdShowReport.FlatAppearance.BorderSize = 0
        Me.cmdShowReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdShowReport.Image = Global.HOSPITALITY.My.Resources.Resources.show_report
        Me.cmdShowReport.Location = New System.Drawing.Point(125, 174)
        Me.cmdShowReport.Name = "cmdShowReport"
        Me.cmdShowReport.Size = New System.Drawing.Size(76, 31)
        Me.cmdShowReport.TabIndex = 5
        Me.cmdShowReport.UseVisualStyleBackColor = False
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.Color.Transparent
        Me.cmdExit.FlatAppearance.BorderSize = 0
        Me.cmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdExit.Image = Global.HOSPITALITY.My.Resources.Resources._Exit
        Me.cmdExit.Location = New System.Drawing.Point(204, 178)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(76, 27)
        Me.cmdExit.TabIndex = 6
        Me.cmdExit.UseVisualStyleBackColor = False
        '
        'CMBBOOKEDBY
        '
        Me.CMBBOOKEDBY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBBOOKEDBY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBBOOKEDBY.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CMBBOOKEDBY.FormattingEnabled = True
        Me.CMBBOOKEDBY.Items.AddRange(New Object() {""})
        Me.CMBBOOKEDBY.Location = New System.Drawing.Point(102, 29)
        Me.CMBBOOKEDBY.Name = "CMBBOOKEDBY"
        Me.CMBBOOKEDBY.Size = New System.Drawing.Size(270, 22)
        Me.CMBBOOKEDBY.TabIndex = 0
        '
        'lblreg
        '
        Me.lblreg.AutoSize = True
        Me.lblreg.BackColor = System.Drawing.Color.Transparent
        Me.lblreg.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.lblreg.Location = New System.Drawing.Point(37, 33)
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
        Me.GroupBox2.Location = New System.Drawing.Point(39, 108)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(327, 52)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        '
        'dtto
        '
        Me.dtto.CustomFormat = "dd/MM/yyyy"
        Me.dtto.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(208, 20)
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
        Me.Label1.Location = New System.Drawing.Point(179, 24)
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
        Me.dtfrom.Location = New System.Drawing.Point(70, 20)
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
        Me.Label6.Location = New System.Drawing.Point(26, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 14)
        Me.Label6.TabIndex = 104
        Me.Label6.Text = "From :"
        '
        'SaleReportFilter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(414, 238)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "SaleReportFilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Sale Report Filter"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents TXTHOTELADD As System.Windows.Forms.TextBox
    Friend WithEvents cmbhotelcode As System.Windows.Forms.ComboBox
    Friend WithEvents CMBHOTELNAME As System.Windows.Forms.ComboBox
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
End Class
