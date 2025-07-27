<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HolidayMaster
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.TXTHOLIDAYNO = New System.Windows.Forms.TextBox
        Me.TXTHOLIDAY = New System.Windows.Forms.TextBox
        Me.lbl = New System.Windows.Forms.Label
        Me.HOLIDAYDATE = New System.Windows.Forms.DateTimePicker
        Me.GRIDHOLIDAY = New System.Windows.Forms.DataGridView
        Me.cmddelete = New System.Windows.Forms.Button
        Me.cmdexit = New System.Windows.Forms.Button
        Me.chkchange = New System.Windows.Forms.CheckBox
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GSRNO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GDATE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GREMARKS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BlendPanel1.SuspendLayout()
        CType(Me.GRIDHOLIDAY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.TXTHOLIDAYNO)
        Me.BlendPanel1.Controls.Add(Me.TXTHOLIDAY)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Controls.Add(Me.HOLIDAYDATE)
        Me.BlendPanel1.Controls.Add(Me.GRIDHOLIDAY)
        Me.BlendPanel1.Controls.Add(Me.cmddelete)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.chkchange)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(463, 542)
        Me.BlendPanel1.TabIndex = 0
        '
        'TXTHOLIDAYNO
        '
        Me.TXTHOLIDAYNO.BackColor = System.Drawing.Color.Pink
        Me.TXTHOLIDAYNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTHOLIDAYNO.Location = New System.Drawing.Point(206, 19)
        Me.TXTHOLIDAYNO.Name = "TXTHOLIDAYNO"
        Me.TXTHOLIDAYNO.ReadOnly = True
        Me.TXTHOLIDAYNO.Size = New System.Drawing.Size(65, 22)
        Me.TXTHOLIDAYNO.TabIndex = 587
        Me.TXTHOLIDAYNO.TabStop = False
        Me.TXTHOLIDAYNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTHOLIDAYNO.Visible = False
        '
        'TXTHOLIDAY
        '
        Me.TXTHOLIDAY.BackColor = System.Drawing.Color.White
        Me.TXTHOLIDAY.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTHOLIDAY.ForeColor = System.Drawing.Color.Black
        Me.TXTHOLIDAY.Location = New System.Drawing.Point(106, 47)
        Me.TXTHOLIDAY.Name = "TXTHOLIDAY"
        Me.TXTHOLIDAY.Size = New System.Drawing.Size(300, 22)
        Me.TXTHOLIDAY.TabIndex = 1
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(7, 8)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(156, 25)
        Me.lbl.TabIndex = 313
        Me.lbl.Text = "Holiday Master"
        '
        'HOLIDAYDATE
        '
        Me.HOLIDAYDATE.CustomFormat = "dd/MM/yyyy"
        Me.HOLIDAYDATE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HOLIDAYDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.HOLIDAYDATE.Location = New System.Drawing.Point(26, 47)
        Me.HOLIDAYDATE.Name = "HOLIDAYDATE"
        Me.HOLIDAYDATE.Size = New System.Drawing.Size(80, 22)
        Me.HOLIDAYDATE.TabIndex = 0
        '
        'GRIDHOLIDAY
        '
        Me.GRIDHOLIDAY.AllowUserToAddRows = False
        Me.GRIDHOLIDAY.AllowUserToDeleteRows = False
        Me.GRIDHOLIDAY.AllowUserToResizeColumns = False
        Me.GRIDHOLIDAY.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDHOLIDAY.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GRIDHOLIDAY.BackgroundColor = System.Drawing.Color.White
        Me.GRIDHOLIDAY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDHOLIDAY.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GRIDHOLIDAY.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GRIDHOLIDAY.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDHOLIDAY.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GSRNO, Me.GDATE, Me.GREMARKS})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDHOLIDAY.DefaultCellStyle = DataGridViewCellStyle4
        Me.GRIDHOLIDAY.GridColor = System.Drawing.SystemColors.ControlText
        Me.GRIDHOLIDAY.Location = New System.Drawing.Point(26, 70)
        Me.GRIDHOLIDAY.Margin = New System.Windows.Forms.Padding(2)
        Me.GRIDHOLIDAY.MultiSelect = False
        Me.GRIDHOLIDAY.Name = "GRIDHOLIDAY"
        Me.GRIDHOLIDAY.RowHeadersVisible = False
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDHOLIDAY.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.GRIDHOLIDAY.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDHOLIDAY.Size = New System.Drawing.Size(411, 427)
        Me.GRIDHOLIDAY.TabIndex = 2
        Me.GRIDHOLIDAY.TabStop = False
        '
        'cmddelete
        '
        Me.cmddelete.BackColor = System.Drawing.Color.Transparent
        Me.cmddelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmddelete.FlatAppearance.BorderSize = 0
        Me.cmddelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmddelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmddelete.Image = Global.HOSPITALITY.My.Resources.Resources.Delete
        Me.cmddelete.Location = New System.Drawing.Point(157, 502)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(72, 26)
        Me.cmddelete.TabIndex = 4
        Me.cmddelete.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Image = Global.HOSPITALITY.My.Resources.Resources._Exit
        Me.cmdexit.Location = New System.Drawing.Point(233, 502)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(72, 26)
        Me.cmdexit.TabIndex = 5
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'chkchange
        '
        Me.chkchange.AutoSize = True
        Me.chkchange.Location = New System.Drawing.Point(445, 3)
        Me.chkchange.Name = "chkchange"
        Me.chkchange.Size = New System.Drawing.Size(15, 14)
        Me.chkchange.TabIndex = 152
        Me.chkchange.UseVisualStyleBackColor = True
        Me.chkchange.Visible = False
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'GSRNO
        '
        Me.GSRNO.HeaderText = "HOLIDAYNO"
        Me.GSRNO.Name = "GSRNO"
        Me.GSRNO.Visible = False
        '
        'GDATE
        '
        Me.GDATE.HeaderText = "Date"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.Width = 80
        '
        'GREMARKS
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.GREMARKS.DefaultCellStyle = DataGridViewCellStyle3
        Me.GREMARKS.HeaderText = "Holiday"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.Width = 300
        '
        'HolidayMaster
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(463, 542)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "HolidayMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Holiday Master"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.GRIDHOLIDAY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmddelete As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents chkchange As System.Windows.Forms.CheckBox
    Friend WithEvents GRIDHOLIDAY As System.Windows.Forms.DataGridView
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents HOLIDAYDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents TXTHOLIDAY As System.Windows.Forms.TextBox
    Friend WithEvents TXTHOLIDAYNO As System.Windows.Forms.TextBox
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents GSRNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GDATE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GREMARKS As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
