﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GSTSaleReport
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
        Me.cmdexit = New System.Windows.Forms.Button
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GTYPE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GBILLINITIALS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GBOOKINGDATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GLEDGERNAME = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GGSTIN = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GSTATENAME = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GSTATECODE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GHSNCODE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTAXABLEAMT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCGSTPER = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GSGSTPER = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GSGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GIGSTPER = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GIGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GGTOTAL = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ExcelExport = New System.Windows.Forms.ToolStripButton
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.AutoSize = True
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1106, 579)
        Me.BlendPanel1.TabIndex = 9
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(513, 541)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 2
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(15, 28)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1076, 507)
        Me.gridbilldetails.TabIndex = 256
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.HeaderPanel.Options.UseFont = True
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GTYPE, Me.GBILLINITIALS, Me.GBOOKINGDATE, Me.GLEDGERNAME, Me.GGSTIN, Me.GSTATENAME, Me.GSTATECODE, Me.GHSNCODE, Me.GTAXABLEAMT, Me.GCGSTPER, Me.GCGSTAMT, Me.GSGSTPER, Me.GSGSTAMT, Me.GIGSTPER, Me.GIGSTAMT, Me.GGTOTAL})
        Me.gridbill.CustomizationFormBounds = New System.Drawing.Rectangle(688, 311, 208, 184)
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        '
        'GTYPE
        '
        Me.GTYPE.Caption = "Type"
        Me.GTYPE.FieldName = "BOOKTYPE"
        Me.GTYPE.Name = "GTYPE"
        Me.GTYPE.Visible = True
        Me.GTYPE.VisibleIndex = 0
        '
        'GBILLINITIALS
        '
        Me.GBILLINITIALS.Caption = "Bill No"
        Me.GBILLINITIALS.FieldName = "BILLINITIALS"
        Me.GBILLINITIALS.Name = "GBILLINITIALS"
        Me.GBILLINITIALS.Visible = True
        Me.GBILLINITIALS.VisibleIndex = 1
        '
        'GBOOKINGDATE
        '
        Me.GBOOKINGDATE.Caption = "Date"
        Me.GBOOKINGDATE.FieldName = "BOOKINGDATE"
        Me.GBOOKINGDATE.Name = "GBOOKINGDATE"
        Me.GBOOKINGDATE.Visible = True
        Me.GBOOKINGDATE.VisibleIndex = 2
        '
        'GLEDGERNAME
        '
        Me.GLEDGERNAME.Caption = "Ledger Name"
        Me.GLEDGERNAME.FieldName = "LEDGERNAME"
        Me.GLEDGERNAME.Name = "GLEDGERNAME"
        Me.GLEDGERNAME.Visible = True
        Me.GLEDGERNAME.VisibleIndex = 3
        Me.GLEDGERNAME.Width = 160
        '
        'GGSTIN
        '
        Me.GGSTIN.Caption = "GSTIN"
        Me.GGSTIN.FieldName = "GSTIN"
        Me.GGSTIN.Name = "GGSTIN"
        Me.GGSTIN.Visible = True
        Me.GGSTIN.VisibleIndex = 4
        Me.GGSTIN.Width = 100
        '
        'GSTATENAME
        '
        Me.GSTATENAME.Caption = "State Name"
        Me.GSTATENAME.FieldName = "STATENAME"
        Me.GSTATENAME.Name = "GSTATENAME"
        Me.GSTATENAME.Visible = True
        Me.GSTATENAME.VisibleIndex = 5
        Me.GSTATENAME.Width = 100
        '
        'GSTATECODE
        '
        Me.GSTATECODE.Caption = "State Code"
        Me.GSTATECODE.FieldName = "STATECODE"
        Me.GSTATECODE.Name = "GSTATECODE"
        Me.GSTATECODE.Visible = True
        Me.GSTATECODE.VisibleIndex = 6
        Me.GSTATECODE.Width = 50
        '
        'GHSNCODE
        '
        Me.GHSNCODE.Caption = "HSN Code"
        Me.GHSNCODE.FieldName = "HSNCODE"
        Me.GHSNCODE.Name = "GHSNCODE"
        Me.GHSNCODE.Visible = True
        Me.GHSNCODE.VisibleIndex = 7
        '
        'GTAXABLEAMT
        '
        Me.GTAXABLEAMT.Caption = "Taxable Amt."
        Me.GTAXABLEAMT.DisplayFormat.FormatString = "0.00"
        Me.GTAXABLEAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTAXABLEAMT.FieldName = "TAXABLEAMT"
        Me.GTAXABLEAMT.Name = "GTAXABLEAMT"
        Me.GTAXABLEAMT.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GTAXABLEAMT.Visible = True
        Me.GTAXABLEAMT.VisibleIndex = 8
        Me.GTAXABLEAMT.Width = 80
        '
        'GCGSTPER
        '
        Me.GCGSTPER.Caption = "CGST %"
        Me.GCGSTPER.DisplayFormat.FormatString = "0.00"
        Me.GCGSTPER.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCGSTPER.FieldName = "CGSTPER"
        Me.GCGSTPER.Name = "GCGSTPER"
        Me.GCGSTPER.Visible = True
        Me.GCGSTPER.VisibleIndex = 9
        Me.GCGSTPER.Width = 55
        '
        'GCGSTAMT
        '
        Me.GCGSTAMT.Caption = "CGST Amt."
        Me.GCGSTAMT.DisplayFormat.FormatString = "0.00"
        Me.GCGSTAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCGSTAMT.FieldName = "CGSTAMT"
        Me.GCGSTAMT.Name = "GCGSTAMT"
        Me.GCGSTAMT.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GCGSTAMT.Visible = True
        Me.GCGSTAMT.VisibleIndex = 10
        Me.GCGSTAMT.Width = 80
        '
        'GSGSTPER
        '
        Me.GSGSTPER.Caption = "SGST %"
        Me.GSGSTPER.DisplayFormat.FormatString = "0.00"
        Me.GSGSTPER.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSGSTPER.FieldName = "SGSTPER"
        Me.GSGSTPER.Name = "GSGSTPER"
        Me.GSGSTPER.Visible = True
        Me.GSGSTPER.VisibleIndex = 11
        Me.GSGSTPER.Width = 55
        '
        'GSGSTAMT
        '
        Me.GSGSTAMT.Caption = "SGST Amt."
        Me.GSGSTAMT.DisplayFormat.FormatString = "0.00"
        Me.GSGSTAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSGSTAMT.FieldName = "SGSTAMT"
        Me.GSGSTAMT.Name = "GSGSTAMT"
        Me.GSGSTAMT.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GSGSTAMT.Visible = True
        Me.GSGSTAMT.VisibleIndex = 12
        Me.GSGSTAMT.Width = 80
        '
        'GIGSTPER
        '
        Me.GIGSTPER.Caption = "IGST %"
        Me.GIGSTPER.DisplayFormat.FormatString = "0.00"
        Me.GIGSTPER.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GIGSTPER.FieldName = "IGSTPER"
        Me.GIGSTPER.Name = "GIGSTPER"
        Me.GIGSTPER.Visible = True
        Me.GIGSTPER.VisibleIndex = 13
        Me.GIGSTPER.Width = 55
        '
        'GIGSTAMT
        '
        Me.GIGSTAMT.Caption = "IGST Amt."
        Me.GIGSTAMT.DisplayFormat.FormatString = "0.00"
        Me.GIGSTAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GIGSTAMT.FieldName = "IGSTAMT"
        Me.GIGSTAMT.Name = "GIGSTAMT"
        Me.GIGSTAMT.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GIGSTAMT.Visible = True
        Me.GIGSTAMT.VisibleIndex = 14
        Me.GIGSTAMT.Width = 80
        '
        'GGTOTAL
        '
        Me.GGTOTAL.Caption = "G. Total"
        Me.GGTOTAL.DisplayFormat.FormatString = "0.00"
        Me.GGTOTAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GGTOTAL.FieldName = "GTOTAL"
        Me.GGTOTAL.Name = "GGTOTAL"
        Me.GGTOTAL.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GGTOTAL.Visible = True
        Me.GGTOTAL.VisibleIndex = 15
        Me.GGTOTAL.Width = 80
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExcelExport})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1106, 25)
        Me.ToolStrip1.TabIndex = 255
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ExcelExport
        '
        Me.ExcelExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ExcelExport.Image = Global.HOSPITALITY.My.Resources.Resources.Excel_icon
        Me.ExcelExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ExcelExport.Name = "ExcelExport"
        Me.ExcelExport.Size = New System.Drawing.Size(23, 22)
        Me.ExcelExport.Text = "&Print"
        '
        'SaleGSTreport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1106, 579)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "SaleGSTreport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Sale GST Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GBILLINITIALS As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GBOOKINGDATE As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GLEDGERNAME As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GGSTIN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ExcelExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents GSTATENAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTATECODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GHSNCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTAXABLEAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCGSTPER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSGSTPER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GIGSTPER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GIGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGTOTAL As DevExpress.XtraGrid.Columns.GridColumn
End Class
