<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contact
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TXTCONTACTNO = New System.Windows.Forms.TextBox
        Me.CMBCITY = New System.Windows.Forms.ComboBox
        Me.TXTEMAIL = New System.Windows.Forms.TextBox
        Me.TXTMOBILE = New System.Windows.Forms.TextBox
        Me.TXTSURNAME = New System.Windows.Forms.TextBox
        Me.TXTNAME = New System.Windows.Forms.TextBox
        Me.TXTSRNO = New System.Windows.Forms.TextBox
        Me.GRIDCONT = New System.Windows.Forms.DataGridView
        Me.GCONNO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GSRNO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GNAME = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GSURNAME = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GMOBILE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GEMAIL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GCITY = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GCATEGORY = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CMDEXIT = New System.Windows.Forms.Button
        Me.BlendPanel2 = New VbPowerPack.BlendPanel
        Me.CMBCATEGORY = New System.Windows.Forms.ComboBox
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDCONT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BlendPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'TXTCONTACTNO
        '
        Me.TXTCONTACTNO.BackColor = System.Drawing.Color.White
        Me.TXTCONTACTNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCONTACTNO.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTCONTACTNO.Location = New System.Drawing.Point(25, 21)
        Me.TXTCONTACTNO.Name = "TXTCONTACTNO"
        Me.TXTCONTACTNO.ReadOnly = True
        Me.TXTCONTACTNO.Size = New System.Drawing.Size(30, 23)
        Me.TXTCONTACTNO.TabIndex = 40
        Me.TXTCONTACTNO.Visible = False
        '
        'CMBCITY
        '
        Me.CMBCITY.FormattingEnabled = True
        Me.CMBCITY.Location = New System.Drawing.Point(804, 50)
        Me.CMBCITY.Name = "CMBCITY"
        Me.CMBCITY.Size = New System.Drawing.Size(100, 23)
        Me.CMBCITY.TabIndex = 4
        '
        'TXTEMAIL
        '
        Me.TXTEMAIL.BackColor = System.Drawing.Color.White
        Me.TXTEMAIL.Location = New System.Drawing.Point(628, 50)
        Me.TXTEMAIL.Name = "TXTEMAIL"
        Me.TXTEMAIL.Size = New System.Drawing.Size(175, 23)
        Me.TXTEMAIL.TabIndex = 3
        '
        'TXTMOBILE
        '
        Me.TXTMOBILE.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTMOBILE.Location = New System.Drawing.Point(503, 50)
        Me.TXTMOBILE.Name = "TXTMOBILE"
        Me.TXTMOBILE.Size = New System.Drawing.Size(125, 23)
        Me.TXTMOBILE.TabIndex = 2
        Me.TXTMOBILE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTSURNAME
        '
        Me.TXTSURNAME.Location = New System.Drawing.Point(304, 50)
        Me.TXTSURNAME.Name = "TXTSURNAME"
        Me.TXTSURNAME.Size = New System.Drawing.Size(200, 23)
        Me.TXTSURNAME.TabIndex = 1
        '
        'TXTNAME
        '
        Me.TXTNAME.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTNAME.Location = New System.Drawing.Point(54, 50)
        Me.TXTNAME.Name = "TXTNAME"
        Me.TXTNAME.Size = New System.Drawing.Size(250, 23)
        Me.TXTNAME.TabIndex = 0
        '
        'TXTSRNO
        '
        Me.TXTSRNO.BackColor = System.Drawing.Color.Linen
        Me.TXTSRNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSRNO.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTSRNO.Location = New System.Drawing.Point(24, 50)
        Me.TXTSRNO.Name = "TXTSRNO"
        Me.TXTSRNO.ReadOnly = True
        Me.TXTSRNO.Size = New System.Drawing.Size(30, 23)
        Me.TXTSRNO.TabIndex = 33
        '
        'GRIDCONT
        '
        Me.GRIDCONT.AllowUserToAddRows = False
        Me.GRIDCONT.AllowUserToDeleteRows = False
        Me.GRIDCONT.AllowUserToResizeColumns = False
        Me.GRIDCONT.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDCONT.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GRIDCONT.BackgroundColor = System.Drawing.Color.White
        Me.GRIDCONT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDCONT.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.GRIDCONT.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GRIDCONT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDCONT.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GCONNO, Me.GSRNO, Me.GNAME, Me.GSURNAME, Me.GMOBILE, Me.GEMAIL, Me.GCITY, Me.GCATEGORY})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDCONT.DefaultCellStyle = DataGridViewCellStyle3
        Me.GRIDCONT.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.GRIDCONT.GridColor = System.Drawing.SystemColors.Control
        Me.GRIDCONT.Location = New System.Drawing.Point(23, 74)
        Me.GRIDCONT.MultiSelect = False
        Me.GRIDCONT.Name = "GRIDCONT"
        Me.GRIDCONT.RowHeadersVisible = False
        Me.GRIDCONT.RowHeadersWidth = 30
        Me.GRIDCONT.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDCONT.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.GRIDCONT.RowTemplate.Height = 20
        Me.GRIDCONT.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDCONT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDCONT.Size = New System.Drawing.Size(1033, 416)
        Me.GRIDCONT.TabIndex = 3
        Me.GRIDCONT.TabStop = False
        '
        'GCONNO
        '
        Me.GCONNO.HeaderText = "CONNO"
        Me.GCONNO.Name = "GCONNO"
        Me.GCONNO.ReadOnly = True
        Me.GCONNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GCONNO.Visible = False
        '
        'GSRNO
        '
        Me.GSRNO.HeaderText = "Sr."
        Me.GSRNO.Name = "GSRNO"
        Me.GSRNO.ReadOnly = True
        Me.GSRNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GSRNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GSRNO.Width = 30
        '
        'GNAME
        '
        Me.GNAME.HeaderText = "Given Name"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GNAME.Width = 250
        '
        'GSURNAME
        '
        Me.GSURNAME.HeaderText = "Surname"
        Me.GSURNAME.Name = "GSURNAME"
        Me.GSURNAME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GSURNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GSURNAME.Width = 200
        '
        'GMOBILE
        '
        Me.GMOBILE.HeaderText = "Mobile No."
        Me.GMOBILE.Name = "GMOBILE"
        Me.GMOBILE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GMOBILE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GMOBILE.Width = 125
        '
        'GEMAIL
        '
        Me.GEMAIL.HeaderText = "Email Address"
        Me.GEMAIL.Name = "GEMAIL"
        Me.GEMAIL.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GEMAIL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GEMAIL.Width = 175
        '
        'GCITY
        '
        Me.GCITY.HeaderText = "City"
        Me.GCITY.Name = "GCITY"
        Me.GCITY.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCITY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GCATEGORY
        '
        Me.GCATEGORY.HeaderText = "Category"
        Me.GCATEGORY.Name = "GCATEGORY"
        Me.GCATEGORY.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCATEGORY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GCATEGORY.Width = 125
        '
        'CMDEXIT
        '
        Me.CMDEXIT.Location = New System.Drawing.Point(499, 496)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 6
        Me.CMDEXIT.Text = "E&xit"
        Me.CMDEXIT.UseVisualStyleBackColor = True
        '
        'BlendPanel2
        '
        Me.BlendPanel2.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel2.Controls.Add(Me.CMBCATEGORY)
        Me.BlendPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel2.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel2.Name = "BlendPanel2"
        Me.BlendPanel2.Size = New System.Drawing.Size(1079, 528)
        Me.BlendPanel2.TabIndex = 445
        '
        'CMBCATEGORY
        '
        Me.CMBCATEGORY.FormattingEnabled = True
        Me.CMBCATEGORY.Location = New System.Drawing.Point(904, 50)
        Me.CMBCATEGORY.Name = "CMBCATEGORY"
        Me.CMBCATEGORY.Size = New System.Drawing.Size(125, 23)
        Me.CMBCATEGORY.TabIndex = 0
        '
        'Contact
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1079, 528)
        Me.Controls.Add(Me.CMDEXIT)
        Me.Controls.Add(Me.TXTCONTACTNO)
        Me.Controls.Add(Me.CMBCITY)
        Me.Controls.Add(Me.TXTEMAIL)
        Me.Controls.Add(Me.TXTMOBILE)
        Me.Controls.Add(Me.TXTSURNAME)
        Me.Controls.Add(Me.TXTNAME)
        Me.Controls.Add(Me.TXTSRNO)
        Me.Controls.Add(Me.GRIDCONT)
        Me.Controls.Add(Me.BlendPanel2)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "Contact"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Contacts"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDCONT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BlendPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents TXTCONTACTNO As System.Windows.Forms.TextBox
    Friend WithEvents CMBCITY As System.Windows.Forms.ComboBox
    Friend WithEvents TXTEMAIL As System.Windows.Forms.TextBox
    Friend WithEvents TXTMOBILE As System.Windows.Forms.TextBox
    Friend WithEvents TXTSURNAME As System.Windows.Forms.TextBox
    Friend WithEvents TXTNAME As System.Windows.Forms.TextBox
    Friend WithEvents TXTSRNO As System.Windows.Forms.TextBox
    Friend WithEvents GRIDCONT As System.Windows.Forms.DataGridView
    Friend WithEvents CMDEXIT As System.Windows.Forms.Button
    Friend WithEvents GCONNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GSRNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GSURNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GMOBILE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GEMAIL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GCITY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GCATEGORY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BlendPanel2 As VbPowerPack.BlendPanel
    Friend WithEvents CMBCATEGORY As System.Windows.Forms.ComboBox
End Class
