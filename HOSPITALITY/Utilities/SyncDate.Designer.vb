<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SyncDate
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
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CHKSYNCBOOKING = New System.Windows.Forms.CheckBox()
        Me.CHKSYNCHOTELS = New System.Windows.Forms.CheckBox()
        Me.CMDEXIT = New System.Windows.Forms.Button()
        Me.TODATE = New System.Windows.Forms.DateTimePicker()
        Me.CMDFETCH = New System.Windows.Forms.Button()
        Me.FROMDATE = New System.Windows.Forms.DateTimePicker()
        Me.LBLTO = New System.Windows.Forms.Label()
        Me.LBLFROM = New System.Windows.Forms.Label()
        Me.BlendPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CHKSYNCBOOKING)
        Me.BlendPanel1.Controls.Add(Me.CHKSYNCHOTELS)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Controls.Add(Me.TODATE)
        Me.BlendPanel1.Controls.Add(Me.CMDFETCH)
        Me.BlendPanel1.Controls.Add(Me.FROMDATE)
        Me.BlendPanel1.Controls.Add(Me.LBLTO)
        Me.BlendPanel1.Controls.Add(Me.LBLFROM)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(245, 298)
        Me.BlendPanel1.TabIndex = 0
        '
        'CHKSYNCBOOKING
        '
        Me.CHKSYNCBOOKING.AutoSize = True
        Me.CHKSYNCBOOKING.BackColor = System.Drawing.Color.Transparent
        Me.CHKSYNCBOOKING.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKSYNCBOOKING.Location = New System.Drawing.Point(39, 113)
        Me.CHKSYNCBOOKING.Name = "CHKSYNCBOOKING"
        Me.CHKSYNCBOOKING.Size = New System.Drawing.Size(104, 19)
        Me.CHKSYNCBOOKING.TabIndex = 3
        Me.CHKSYNCBOOKING.Text = "Sync Bookings"
        Me.CHKSYNCBOOKING.UseVisualStyleBackColor = False
        Me.CHKSYNCBOOKING.Visible = False
        '
        'CHKSYNCHOTELS
        '
        Me.CHKSYNCHOTELS.AutoSize = True
        Me.CHKSYNCHOTELS.BackColor = System.Drawing.Color.Transparent
        Me.CHKSYNCHOTELS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKSYNCHOTELS.Location = New System.Drawing.Point(39, 88)
        Me.CHKSYNCHOTELS.Name = "CHKSYNCHOTELS"
        Me.CHKSYNCHOTELS.Size = New System.Drawing.Size(89, 19)
        Me.CHKSYNCHOTELS.TabIndex = 2
        Me.CHKSYNCHOTELS.Text = "Sync Hotels"
        Me.CHKSYNCHOTELS.UseVisualStyleBackColor = False
        Me.CHKSYNCHOTELS.Visible = False
        '
        'CMDEXIT
        '
        Me.CMDEXIT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEXIT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDEXIT.Location = New System.Drawing.Point(125, 149)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 5
        Me.CMDEXIT.Text = "E&xit"
        Me.CMDEXIT.UseVisualStyleBackColor = True
        '
        'TODATE
        '
        Me.TODATE.CustomFormat = "dd/MM/yyyy"
        Me.TODATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TODATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TODATE.Location = New System.Drawing.Point(111, 41)
        Me.TODATE.Name = "TODATE"
        Me.TODATE.Size = New System.Drawing.Size(89, 23)
        Me.TODATE.TabIndex = 1
        '
        'CMDFETCH
        '
        Me.CMDFETCH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDFETCH.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDFETCH.Location = New System.Drawing.Point(39, 149)
        Me.CMDFETCH.Name = "CMDFETCH"
        Me.CMDFETCH.Size = New System.Drawing.Size(80, 28)
        Me.CMDFETCH.TabIndex = 4
        Me.CMDFETCH.Text = "&Fetch Data"
        Me.CMDFETCH.UseVisualStyleBackColor = True
        '
        'FROMDATE
        '
        Me.FROMDATE.CustomFormat = "dd/MM/yyyy"
        Me.FROMDATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FROMDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.FROMDATE.Location = New System.Drawing.Point(111, 12)
        Me.FROMDATE.Name = "FROMDATE"
        Me.FROMDATE.Size = New System.Drawing.Size(89, 23)
        Me.FROMDATE.TabIndex = 0
        '
        'LBLTO
        '
        Me.LBLTO.AutoSize = True
        Me.LBLTO.BackColor = System.Drawing.Color.Transparent
        Me.LBLTO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTO.ForeColor = System.Drawing.Color.Black
        Me.LBLTO.Location = New System.Drawing.Point(55, 45)
        Me.LBLTO.Name = "LBLTO"
        Me.LBLTO.Size = New System.Drawing.Size(53, 15)
        Me.LBLTO.TabIndex = 181
        Me.LBLTO.Text = "Till Date"
        '
        'LBLFROM
        '
        Me.LBLFROM.AutoSize = True
        Me.LBLFROM.BackColor = System.Drawing.Color.Transparent
        Me.LBLFROM.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLFROM.ForeColor = System.Drawing.Color.Black
        Me.LBLFROM.Location = New System.Drawing.Point(45, 16)
        Me.LBLFROM.Name = "LBLFROM"
        Me.LBLFROM.Size = New System.Drawing.Size(63, 15)
        Me.LBLFROM.TabIndex = 180
        Me.LBLFROM.Text = "From Date"
        Me.LBLFROM.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SyncDate
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(245, 298)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "SyncDate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Sync Data"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMDEXIT As System.Windows.Forms.Button
    Friend WithEvents TODATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents CMDFETCH As System.Windows.Forms.Button
    Friend WithEvents FROMDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents LBLTO As System.Windows.Forms.Label
    Friend WithEvents LBLFROM As System.Windows.Forms.Label
    Friend WithEvents CHKSYNCBOOKING As CheckBox
    Friend WithEvents CHKSYNCHOTELS As CheckBox
End Class
