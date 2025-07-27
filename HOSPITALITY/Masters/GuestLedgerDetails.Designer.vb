<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GuestLedgerDetails
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
        Me.CMDREFRESH = New System.Windows.Forms.Button()
        Me.CMDPRINT = New System.Windows.Forms.Button()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSURNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGENDER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAREANAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GZIPCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCITYNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSTATENAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GADDRESS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSTD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRESINO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GALTNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPHONE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMOBILENO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFAX = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDOB = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDOA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSTATUS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GEMAIL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDISPLAYNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPASSPORTNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREFVIA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGUESTCATEGORY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMDREFRESH)
        Me.BlendPanel1.Controls.Add(Me.CMDPRINT)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 6
        '
        'CMDREFRESH
        '
        Me.CMDREFRESH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDREFRESH.Location = New System.Drawing.Point(534, 550)
        Me.CMDREFRESH.Name = "CMDREFRESH"
        Me.CMDREFRESH.Size = New System.Drawing.Size(80, 28)
        Me.CMDREFRESH.TabIndex = 502
        Me.CMDREFRESH.Text = "&Refresh"
        Me.CMDREFRESH.UseVisualStyleBackColor = True
        '
        'CMDPRINT
        '
        Me.CMDPRINT.BackColor = System.Drawing.Color.Transparent
        Me.CMDPRINT.BackgroundImage = Global.HOSPITALITY.My.Resources.Resources.Excel_icon
        Me.CMDPRINT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CMDPRINT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDPRINT.FlatAppearance.BorderSize = 0
        Me.CMDPRINT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDPRINT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDPRINT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDPRINT.Location = New System.Drawing.Point(503, 550)
        Me.CMDPRINT.Name = "CMDPRINT"
        Me.CMDPRINT.Size = New System.Drawing.Size(25, 21)
        Me.CMDPRINT.TabIndex = 501
        Me.CMDPRINT.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(14, 12)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1208, 532)
        Me.gridbilldetails.TabIndex = 494
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GNAME, Me.GDISPLAYNAME, Me.GSURNAME, Me.GGENDER, Me.GAREANAME, Me.GZIPCODE, Me.GCITYNAME, Me.GSTATENAME, Me.GADDRESS, Me.GSTD, Me.GRESINO, Me.GALTNO, Me.GPHONE, Me.GMOBILENO, Me.GFAX, Me.GDOB, Me.GDOA, Me.GSTATUS, Me.GEMAIL, Me.GPASSPORTNO, Me.GREFVIA, Me.GGUESTCATEGORY})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        '
        'GNAME
        '
        Me.GNAME.Caption = "Guest Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 0
        Me.GNAME.Width = 200
        '
        'GSURNAME
        '
        Me.GSURNAME.Caption = "Sur Name"
        Me.GSURNAME.FieldName = "SURNAME"
        Me.GSURNAME.Name = "GSURNAME"
        Me.GSURNAME.Visible = True
        Me.GSURNAME.VisibleIndex = 2
        '
        'GGENDER
        '
        Me.GGENDER.Caption = "Gender"
        Me.GGENDER.FieldName = "GENDER"
        Me.GGENDER.Name = "GGENDER"
        Me.GGENDER.Visible = True
        Me.GGENDER.VisibleIndex = 3
        Me.GGENDER.Width = 50
        '
        'GAREANAME
        '
        Me.GAREANAME.Caption = "Area Name"
        Me.GAREANAME.FieldName = "AREANAME"
        Me.GAREANAME.Name = "GAREANAME"
        Me.GAREANAME.Visible = True
        Me.GAREANAME.VisibleIndex = 4
        '
        'GZIPCODE
        '
        Me.GZIPCODE.Caption = "Zip Code"
        Me.GZIPCODE.FieldName = "ZIPCODE"
        Me.GZIPCODE.Name = "GZIPCODE"
        Me.GZIPCODE.Visible = True
        Me.GZIPCODE.VisibleIndex = 5
        '
        'GCITYNAME
        '
        Me.GCITYNAME.Caption = "City Name"
        Me.GCITYNAME.FieldName = "CITYNAME"
        Me.GCITYNAME.Name = "GCITYNAME"
        Me.GCITYNAME.Visible = True
        Me.GCITYNAME.VisibleIndex = 6
        '
        'GSTATENAME
        '
        Me.GSTATENAME.Caption = "State Name"
        Me.GSTATENAME.FieldName = "STATENAME"
        Me.GSTATENAME.Name = "GSTATENAME"
        Me.GSTATENAME.Visible = True
        Me.GSTATENAME.VisibleIndex = 7
        '
        'GADDRESS
        '
        Me.GADDRESS.Caption = "Address"
        Me.GADDRESS.FieldName = "ADD"
        Me.GADDRESS.Name = "GADDRESS"
        Me.GADDRESS.Visible = True
        Me.GADDRESS.VisibleIndex = 8
        Me.GADDRESS.Width = 200
        '
        'GSTD
        '
        Me.GSTD.Caption = "STD Code"
        Me.GSTD.FieldName = "STD"
        Me.GSTD.Name = "GSTD"
        Me.GSTD.Visible = True
        Me.GSTD.VisibleIndex = 9
        '
        'GRESINO
        '
        Me.GRESINO.Caption = "Resi No"
        Me.GRESINO.FieldName = "RESINO"
        Me.GRESINO.Name = "GRESINO"
        Me.GRESINO.Visible = True
        Me.GRESINO.VisibleIndex = 10
        Me.GRESINO.Width = 90
        '
        'GALTNO
        '
        Me.GALTNO.Caption = "Alt No"
        Me.GALTNO.FieldName = "ALTNO"
        Me.GALTNO.Name = "GALTNO"
        Me.GALTNO.Visible = True
        Me.GALTNO.VisibleIndex = 11
        '
        'GPHONE
        '
        Me.GPHONE.Caption = "Tel No"
        Me.GPHONE.FieldName = "PHONE"
        Me.GPHONE.Name = "GPHONE"
        Me.GPHONE.Visible = True
        Me.GPHONE.VisibleIndex = 12
        Me.GPHONE.Width = 90
        '
        'GMOBILENO
        '
        Me.GMOBILENO.Caption = "Mobile No"
        Me.GMOBILENO.FieldName = "MOBILE"
        Me.GMOBILENO.Name = "GMOBILENO"
        Me.GMOBILENO.Visible = True
        Me.GMOBILENO.VisibleIndex = 13
        Me.GMOBILENO.Width = 90
        '
        'GFAX
        '
        Me.GFAX.Caption = "Fax"
        Me.GFAX.FieldName = "FAX"
        Me.GFAX.Name = "GFAX"
        Me.GFAX.Visible = True
        Me.GFAX.VisibleIndex = 14
        '
        'GDOB
        '
        Me.GDOB.Caption = "Birth Date"
        Me.GDOB.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDOB.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDOB.FieldName = "DOB"
        Me.GDOB.Name = "GDOB"
        Me.GDOB.Visible = True
        Me.GDOB.VisibleIndex = 15
        '
        'GDOA
        '
        Me.GDOA.Caption = "Anniversary"
        Me.GDOA.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDOA.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDOA.FieldName = "DOA"
        Me.GDOA.Name = "GDOA"
        Me.GDOA.Visible = True
        Me.GDOA.VisibleIndex = 16
        '
        'GSTATUS
        '
        Me.GSTATUS.Caption = "Status"
        Me.GSTATUS.FieldName = "STATUS"
        Me.GSTATUS.Name = "GSTATUS"
        Me.GSTATUS.Visible = True
        Me.GSTATUS.VisibleIndex = 17
        '
        'GEMAIL
        '
        Me.GEMAIL.Caption = "Email "
        Me.GEMAIL.FieldName = "EMAIL"
        Me.GEMAIL.Name = "GEMAIL"
        Me.GEMAIL.Visible = True
        Me.GEMAIL.VisibleIndex = 18
        '
        'GDISPLAYNAME
        '
        Me.GDISPLAYNAME.Caption = "Display Name"
        Me.GDISPLAYNAME.FieldName = "DISPLAYNAME"
        Me.GDISPLAYNAME.Name = "GDISPLAYNAME"
        Me.GDISPLAYNAME.Visible = True
        Me.GDISPLAYNAME.VisibleIndex = 1
        Me.GDISPLAYNAME.Width = 200
        '
        'GPASSPORTNO
        '
        Me.GPASSPORTNO.Caption = "Passport No"
        Me.GPASSPORTNO.FieldName = "PASSPORTNO"
        Me.GPASSPORTNO.Name = "GPASSPORTNO"
        Me.GPASSPORTNO.Visible = True
        Me.GPASSPORTNO.VisibleIndex = 19
        '
        'GREFVIA
        '
        Me.GREFVIA.Caption = "Refference VIA"
        Me.GREFVIA.FieldName = "REFVIA"
        Me.GREFVIA.Name = "GREFVIA"
        Me.GREFVIA.Visible = True
        Me.GREFVIA.VisibleIndex = 20
        Me.GREFVIA.Width = 150
        '
        'GGUESTCATEGORY
        '
        Me.GGUESTCATEGORY.Caption = "Guest CateGory"
        Me.GGUESTCATEGORY.FieldName = "GUESTCATEGORY"
        Me.GGUESTCATEGORY.Name = "GGUESTCATEGORY"
        Me.GGUESTCATEGORY.Visible = True
        Me.GGUESTCATEGORY.VisibleIndex = 21
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.Color.Transparent
        Me.cmdcancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdcancel.FlatAppearance.BorderSize = 0
        Me.cmdcancel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.Black
        Me.cmdcancel.Location = New System.Drawing.Point(620, 550)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(80, 28)
        Me.cmdcancel.TabIndex = 316
        Me.cmdcancel.Text = "E&xit"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'GuestLedgerDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.KeyPreview = True
        Me.Name = "GuestLedgerDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Guest Ledger Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMDREFRESH As System.Windows.Forms.Button
    Friend WithEvents CMDPRINT As System.Windows.Forms.Button
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDISPLAYNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGENDER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTATUS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GADDRESS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRESINO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GALTNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPHONE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMOBILENO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Friend WithEvents GREFVIA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSURNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAREANAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GZIPCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCITYNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTATENAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFAX As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDOB As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDOA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GEMAIL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPASSPORTNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGUESTCATEGORY As DevExpress.XtraGrid.Columns.GridColumn
End Class
