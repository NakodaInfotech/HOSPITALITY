<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RateOfExchangeMaster
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
        Me.TXTROENO = New System.Windows.Forms.TextBox
        Me.TXTRATE = New System.Windows.Forms.TextBox
        Me.CMBCODE = New System.Windows.Forms.ComboBox
        Me.GRIDRATE = New System.Windows.Forms.DataGridView
        Me.GCURRENCYID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GCODE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GRATE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmdexit = New System.Windows.Forms.Button
        Me.Ep = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        CType(Me.GRIDRATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ep, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.TXTROENO)
        Me.BlendPanel1.Controls.Add(Me.TXTRATE)
        Me.BlendPanel1.Controls.Add(Me.CMBCODE)
        Me.BlendPanel1.Controls.Add(Me.GRIDRATE)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(355, 434)
        Me.BlendPanel1.TabIndex = 2
        '
        'TXTROENO
        '
        Me.TXTROENO.BackColor = System.Drawing.Color.White
        Me.TXTROENO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTROENO.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTROENO.Location = New System.Drawing.Point(313, 12)
        Me.TXTROENO.Name = "TXTROENO"
        Me.TXTROENO.ReadOnly = True
        Me.TXTROENO.Size = New System.Drawing.Size(30, 23)
        Me.TXTROENO.TabIndex = 716
        Me.TXTROENO.Text = " "
        Me.TXTROENO.Visible = False
        '
        'TXTRATE
        '
        Me.TXTRATE.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTRATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTRATE.Location = New System.Drawing.Point(177, 22)
        Me.TXTRATE.Name = "TXTRATE"
        Me.TXTRATE.Size = New System.Drawing.Size(120, 23)
        Me.TXTRATE.TabIndex = 157
        Me.TXTRATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMBCODE
        '
        Me.CMBCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCODE.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBCODE.DropDownWidth = 400
        Me.CMBCODE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCODE.FormattingEnabled = True
        Me.CMBCODE.Location = New System.Drawing.Point(26, 22)
        Me.CMBCODE.Name = "CMBCODE"
        Me.CMBCODE.Size = New System.Drawing.Size(151, 23)
        Me.CMBCODE.TabIndex = 155
        '
        'GRIDRATE
        '
        Me.GRIDRATE.AllowUserToAddRows = False
        Me.GRIDRATE.AllowUserToDeleteRows = False
        Me.GRIDRATE.AllowUserToResizeColumns = False
        Me.GRIDRATE.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDRATE.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GRIDRATE.BackgroundColor = System.Drawing.Color.White
        Me.GRIDRATE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDRATE.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.GRIDRATE.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GRIDRATE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDRATE.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GCURRENCYID, Me.GCODE, Me.GRATE})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDRATE.DefaultCellStyle = DataGridViewCellStyle4
        Me.GRIDRATE.GridColor = System.Drawing.SystemColors.Control
        Me.GRIDRATE.Location = New System.Drawing.Point(26, 45)
        Me.GRIDRATE.MultiSelect = False
        Me.GRIDRATE.Name = "GRIDRATE"
        Me.GRIDRATE.ReadOnly = True
        Me.GRIDRATE.RowHeadersVisible = False
        Me.GRIDRATE.RowHeadersWidth = 30
        Me.GRIDRATE.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDRATE.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.GRIDRATE.RowTemplate.Height = 20
        Me.GRIDRATE.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDRATE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDRATE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDRATE.Size = New System.Drawing.Size(302, 345)
        Me.GRIDRATE.TabIndex = 159
        Me.GRIDRATE.TabStop = False
        '
        'GCURRENCYID
        '
        Me.GCURRENCYID.HeaderText = "Currency Id"
        Me.GCURRENCYID.Name = "GCURRENCYID"
        Me.GCURRENCYID.ReadOnly = True
        Me.GCURRENCYID.Visible = False
        '
        'GCODE
        '
        Me.GCODE.HeaderText = "Currency Code"
        Me.GCODE.Name = "GCODE"
        Me.GCODE.ReadOnly = True
        Me.GCODE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GCODE.Width = 150
        '
        'GRATE
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRATE.DefaultCellStyle = DataGridViewCellStyle3
        Me.GRATE.HeaderText = "Rate Of Exchange"
        Me.GRATE.Name = "GRATE"
        Me.GRATE.ReadOnly = True
        Me.GRATE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GRATE.Width = 120
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(137, 396)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 27)
        Me.cmdexit.TabIndex = 161
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'Ep
        '
        Me.Ep.BlinkRate = 0
        Me.Ep.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.Ep.ContainerControl = Me
        '
        'RateOfExchangeMaster
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(355, 434)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "RateOfExchangeMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Rate Of Exchange"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.GRIDRATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ep, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents Ep As System.Windows.Forms.ErrorProvider
    Friend WithEvents TXTRATE As System.Windows.Forms.TextBox
    Friend WithEvents CMBCODE As System.Windows.Forms.ComboBox
    Friend WithEvents GRIDRATE As System.Windows.Forms.DataGridView
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents GCURRENCYID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GCODE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GRATE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TXTROENO As System.Windows.Forms.TextBox
End Class
