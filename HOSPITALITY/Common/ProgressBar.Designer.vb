<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProgressBar
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
        Me.components = New System.ComponentModel.Container()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.lbl = New System.Windows.Forms.Label()
        Me.bar = New System.Windows.Forms.ProgressBar()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TXTIMGPATH = New System.Windows.Forms.TextBox()
        Me.PBIMG = New System.Windows.Forms.PictureBox()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.PBIMG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.TXTIMGPATH)
        Me.BlendPanel1.Controls.Add(Me.PBIMG)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(447, 83)
        Me.BlendPanel1.TabIndex = 0
        '
        'lbl
        '
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Location = New System.Drawing.Point(23, 48)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(230, 21)
        Me.lbl.TabIndex = 3
        Me.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'bar
        '
        Me.bar.Location = New System.Drawing.Point(26, 17)
        Me.bar.Name = "bar"
        Me.bar.Size = New System.Drawing.Size(397, 25)
        Me.bar.TabIndex = 2
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 200
        '
        'TXTIMGPATH
        '
        Me.TXTIMGPATH.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTIMGPATH.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTIMGPATH.Location = New System.Drawing.Point(176, 18)
        Me.TXTIMGPATH.Multiline = True
        Me.TXTIMGPATH.Name = "TXTIMGPATH"
        Me.TXTIMGPATH.Size = New System.Drawing.Size(27, 22)
        Me.TXTIMGPATH.TabIndex = 677
        Me.TXTIMGPATH.Visible = False
        '
        'PBIMG
        '
        Me.PBIMG.BackColor = System.Drawing.Color.Transparent
        Me.PBIMG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PBIMG.ErrorImage = Nothing
        Me.PBIMG.InitialImage = Nothing
        Me.PBIMG.Location = New System.Drawing.Point(407, 0)
        Me.PBIMG.Name = "PBIMG"
        Me.PBIMG.Size = New System.Drawing.Size(40, 40)
        Me.PBIMG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBIMG.TabIndex = 676
        Me.PBIMG.TabStop = False
        Me.PBIMG.Visible = False
        '
        'ProgressBar
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(447, 83)
        Me.Controls.Add(Me.bar)
        Me.Controls.Add(Me.BlendPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ProgressBar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ProgressBar"
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.PBIMG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents bar As System.Windows.Forms.ProgressBar
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents TXTIMGPATH As TextBox
    Friend WithEvents PBIMG As PictureBox
End Class
