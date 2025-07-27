
Imports BL
Imports DevExpress.XtraGrid.Views.Grid
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class MiscSaleDetails
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim SALEREGID As Integer

    Private Sub MiscSalDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Alt = True Then
                showform(False, 0)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MiscSalDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'MISC SALE'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)
            fillgrid("")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MiscSalDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ' If ClientName = "ELYSIUM" Or ClientName = "TOPCOMM" Or ClientName = "7HOSPITALITY" Then Me.Close()
        If ClientName = "ELYSIUM" Or ClientName = "7HOSPITALITY" Then Me.Close()
        If ClientName = "SEASONED" Then
            PRINTTOOL.Visible = True
            LBLFROM.Visible = True
            LBLTO.Visible = True
            TXTFROM.Visible = True
            TXTTO.Visible = True
        End If
        If ClientName = "GLOBAL" Then
            GGSTIN.Visible = False
            GSTATECODE.Visible = False
            GSTATENAME.Visible = False
            GHSNCODE.Visible = False
            GCGSTAMT.Visible = False
            GIGSTAMT.Visible = False
            GSGSTAMT.Visible = False

        End If
    End Sub

    Sub fillgrid(ByVal tempcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search("  MISCSALMASTER.BOOKING_REFNO AS REFNO, MISCSALMASTER.BOOKING_PURBILLINITIALS AS BILLINITIALS, LEDGERS.Acc_cmpname AS ACCNAME, USERMASTER.User_Name AS USERNAME,  MISCSALMASTER.BOOKING_NO AS BOOKINGNO, MISCSALMASTER.BOOKING_DATE AS BOOKINGDATE, MISCSALMASTER.BOOKING_FINALPURAMT AS TOTALAMT, MISCSALMASTER.BOOKING_DISCRECDRS AS DISCAMT,  MISCSALMASTER.BOOKING_COMMRECDRS AS COMMAMT, MISCSALMASTER.BOOKING_PURTDSRS AS TDSAMT, MISCSALMASTER.BOOKING_PURSUBTOTAL AS SUBTOTAL, ISNULL(TAXMASTER.tax_name, '') AS TAXNAME,  MISCSALMASTER.BOOKING_PURTAX AS TAXAMT, MISCSALMASTER.BOOKING_PUROTHERCHGS AS OTHERCHGS, MISCSALMASTER.BOOKING_PURGRANDTOTAL AS GRANDTOTAL,  MISCSALMASTER.BOOKING_PURBALANCE AS BALANCE, MISCSALMASTER.BOOKING_DISPUTE AS DISPUTED, MISCSALMASTER.BOOKING_BILLCHECKED AS BILLCHECKED,  MISCSALMASTER.BOOKING_CANCELLED AS CANCELLED, USERMASTER_1.User_Name AS MODIFIEDBY, MISCSALMASTER.BOOKING_CGSTAMT AS CGSTAMT, MISCSALMASTER.BOOKING_SGSTAMT AS SGSTAMT,  MISCSALMASTER.BOOKING_IGSTAMT AS IGSTAMT, ISNULL(LEDGERS.Acc_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.state_name, '') AS STATENAME, ISNULL(CAST(STATEMASTER.state_remark AS VARCHAR), '')  AS STATECODE, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(MISCSALMASTER.BOOKING_PURROUNDOFF, 0) AS ROUNDOFF, ISNULL(MISCSALMASTER.BOOKING_PUREXTRACHGS, 0) AS PUREXTRACHGS,  ISNULL(OTHERCHGSLEDGERS.Acc_cmpname, '') AS OTHERCHGSNAME, ISNULL(MISCSALMASTER.BOOKING_TAXSERVCHGS, 0) AS TAXSERVCHGS, ISNULL(SOURCEMASTER.SOURCE_NAME, '') AS SOURCE,  ISNULL(MISCSALMASTER.BOOKING_BOOKINGDESC, '') AS NOTES, ISNULL(MISCSALMASTER.BOOKING_IRNNO, '') AS IRNNO, ISNULL(MISCSALMASTER.BOOKING_ACKNO, '') AS ACKNO,  MISCSALMASTER.BOOKING_ACKDATE AS ACKDATE, MISCSALMASTER.BOOKING_QRCODE AS QRCODE, ISNULL(GUESTMASTER.GUEST_NAME, '') AS GUESTNAME, ISNULL(GROUPDEPARTURE.GROUPDEP_NAME, '')  AS TOURNAME ", "", "    MISCSALMASTER INNER JOIN REGISTERMASTER ON REGISTERMASTER.register_id = MISCSALMASTER.BOOKING_PURCHASEREGISTERID INNER JOIN LEDGERS ON LEDGERS.Acc_id = MISCSALMASTER.BOOKING_PURLEDGERID INNER JOIN USERMASTER ON USERMASTER.User_id = MISCSALMASTER.BOOKING_USERID INNER JOIN USERMASTER AS USERMASTER_1 ON MISCSALMASTER.BOOKING_MODIFIEDBY = USERMASTER_1.User_id LEFT OUTER JOIN GROUPDEPARTURE ON MISCSALMASTER.BOOKING_TOURID = GROUPDEPARTURE.GROUPDEP_NO AND MISCSALMASTER.BOOKING_YEARID = GROUPDEPARTURE.GROUPDEP_YEARID LEFT OUTER JOIN LEDGERS AS OTHERCHGSLEDGERS ON MISCSALMASTER.BOOKING_PUROTHERCHGSID = OTHERCHGSLEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN HSNMASTER ON MISCSALMASTER.BOOKING_HSNCODEID = HSNMASTER.HSN_ID LEFT OUTER JOIN TAXMASTER ON MISCSALMASTER.BOOKING_PURTAXID = TAXMASTER.tax_id LEFT OUTER JOIN SOURCEMASTER ON MISCSALMASTER.BOOKING_SOURCEID = SOURCEMASTER.SOURCE_ID LEFT OUTER JOIN GUESTMASTER ON MISCSALMASTER.BOOKING_GUESTID = GUESTMASTER.GUEST_ID", tempcondition & " AND MISCSALMASTER.BOOKING_YEARID = " & YearId & " ORDER BY MISCSALMASTER.BOOKING_NO")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal BOOKINGNO As Integer)
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objPUR As New MiscSale
                objPUR.MdiParent = MDIMain
                objPUR.edit = editval
                objPUR.TEMPBOOKINGNO = BOOKINGNO
                objPUR.TEMPREGNAME = cmbregister.Text.Trim
                objPUR.Show()
                'Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.GotFocus
        Try
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'SALE' and register_name not in ('AIRLINE SALE REGISTER', 'INTAIRLINE SALE REGISTER', 'INTERNATIONAL SALE REGISTER', 'RAILWAY SALE REGISTER','PACKAGE SALE REGISTER', 'SALE REGISTER', 'TRANSFER SALE REGISTER','VEHICLE SALE REGISTER')")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbregister.Validating
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If cmbregister.Text.Trim.Length > 0 Then
                cmbregister.Text = UCase(cmbregister.Text)
                Dim clscommon As New ClsCommon
                Dim dt As DataTable
                dt = clscommon.search(" register_abbr, register_initials, register_id ", "", " RegisterMaster ", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'SALE' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
                If dt.Rows.Count > 0 Then
                    SALEREGID = dt.Rows(0).Item(2)
                    fillgrid(" AND REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' ")
                Else
                    MsgBox("Register Not Present, Add New from Master Module")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("BOOKINGNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gridbill.RowStyle
        Try
            Dim DT As DataTable = gridbilldetails.DataSource
            If gridbill.RowFilter = "" Then
                If e.RowHandle >= 0 Then
                    Dim ROW As DataRow = DT.Rows(e.RowHandle)
                    Dim View As GridView = sender
                    If View.GetRowCellDisplayText(e.RowHandle, View.Columns("CANCELLED")) = "Checked" Then
                        e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                        e.Appearance.BackColor = Color.Yellow

                    ElseIf View.GetRowCellDisplayText(e.RowHandle, View.Columns("BILLCHECKED")) = "Checked" Then
                        e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                        e.Appearance.BackColor = Color.LightGreen

                    ElseIf View.GetRowCellDisplayText(e.RowHandle, View.Columns("DISPUTED")) = "Checked" Then
                        e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                        e.Appearance.BackColor = Color.LightBlue
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("BOOKINGNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            showform(False, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLMAIL_Click(sender As Object, e As EventArgs) Handles TOOLMAIL.Click
        Try
            If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridbill.SelectedRowsCount = 0 Then Exit Sub
            'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
            If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
                If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                    MsgBox("Enter Propoer Invoice Nos", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    If MsgBox("Wish to Mail Invoice from " & Val(TXTFROM.Text.Trim) & " To " & Val(TXTTO.Text.Trim) & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                    serverprop(True)
                End If
            Else
                If MsgBox("Wish to Mail Selected Invoice ?", MsgBoxStyle.YesNo) = vbYes Then SERVERPROPSELECTED(True)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Miscellaneous Sale.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            Dim workbook As String = PATH
            If FileIO.FileSystem.FileExists(PATH) = True Then Interaction.GetObject(workbook).close(False)
            GC.Collect()
            'For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
            '    proc.Kill()
            'Next

            Dim PERIOD As String = ""
            PERIOD = AccFrom & " - " & AccTo

            opti.SheetName = "Miscellaneous Sale"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Miscellaneous Sale -  " & cmbregister.Text, gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLGRIDDETAILS_Click(sender As Object, e As EventArgs) Handles TOOLGRIDDETAILS.Click
        Try
            Dim OBJGRIDMISCSALE As New MiscSaleGridDetails
            OBJGRIDMISCSALE.MdiParent = MDIMain
            OBJGRIDMISCSALE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLREFRESH_Click(sender As Object, e As EventArgs) Handles TOOLREFRESH.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            fillgrid(" AND REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRINTTOOL.Click
        Try
            If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridbill.SelectedRowsCount = 0 Then Exit Sub
            'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
            If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
                If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                    MsgBox("Enter Propoer Invoice Nos", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    If MsgBox("Wish to Print Invoice from " & Val(TXTFROM.Text.Trim) & " To " & Val(TXTTO.Text.Trim) & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                    serverprop(False)
                End If
            Else
                If MsgBox("Wish to Print Selected Invoice ?", MsgBoxStyle.YesNo) = vbYes Then SERVERPROPSELECTED(False)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub serverprop(Optional ByVal INVOICEMAIL As Boolean = False)
        Try
            'For I As Integer = Val(TXTFROM.Text.Trim) To Val(TXTTO.Text.Trim)
            '    Dim OBJINVOICE As New MiscVoucherDesign
            '    OBJINVOICE.MdiParent = MDIMain
            '    OBJINVOICE.DIRECTPRINT = True
            '    OBJINVOICE.FRMSTRING = "INVOICE"
            '    OBJINVOICE.BOOKINGNO = Val(I)
            '    OBJINVOICE.SALEREGISTERID = SALEREGID
            '    OBJINVOICE.Show()
            '    OBJINVOICE.Close()
            'Next
            Dim ALATTACHMENT As New ArrayList
            If INVOICEMAIL = False Then If PRINTDIALOG.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PRINTDIALOG.PrinterSettings
            For I As Integer = Val(TXTFROM.Text.Trim) To Val(TXTTO.Text.Trim)
                Dim OBJINVOICE As New MiscVoucherDesign
                OBJINVOICE.MdiParent = MDIMain
                OBJINVOICE.DIRECTPRINT = True
                OBJINVOICE.FRMSTRING = "INVOICE"
                OBJINVOICE.DIRECTMAIL = INVOICEMAIL
                OBJINVOICE.BOOKINGNO = Val(I)
                OBJINVOICE.SALEREGISTERID = SALEREGID
                OBJINVOICE.PRINTSETTING = PRINTDIALOG
                OBJINVOICE.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
                OBJINVOICE.Show()
                OBJINVOICE.Close()
                ALATTACHMENT.Add(Application.StartupPath & "\INVOICE_" & I & ".pdf")
            Next

            If INVOICEMAIL Then
                Dim OBJMAIL As New SendMail
                OBJMAIL.ALATTACHMENT = ALATTACHMENT
                OBJMAIL.subject = "Invoice"
                OBJMAIL.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SERVERPROPSELECTED(Optional ByVal INVOICEMAIL As Boolean = False)
        Try

            Dim ALATTACHMENT As New ArrayList

            If INVOICEMAIL = False Then If PRINTDIALOG.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PRINTDIALOG.PrinterSettings
            Dim SELECTEDROWS As Int32() = gridbill.GetSelectedRows()
            For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
                Dim ROW As DataRow = gridbill.GetDataRow(SELECTEDROWS(I))

                Dim OBJINVOICE As New MiscVoucherDesign
                OBJINVOICE.MdiParent = MDIMain
                OBJINVOICE.DIRECTPRINT = True
                OBJINVOICE.FRMSTRING = "INVOICE"
                OBJINVOICE.DIRECTMAIL = INVOICEMAIL
                OBJINVOICE.BOOKINGNO = Val(ROW("BOOKINGNO"))
                OBJINVOICE.SALEREGISTERID = SALEREGID
                OBJINVOICE.PRINTSETTING = PRINTDIALOG
                OBJINVOICE.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
                OBJINVOICE.Show()
                OBJINVOICE.Close()
                ALATTACHMENT.Add(Application.StartupPath & "\INVOICE_" & Val(ROW("BOOKINGNO")) & ".pdf")
            Next

            If INVOICEMAIL Then
                Dim OBJMAIL As New SendMail
                OBJMAIL.ALATTACHMENT = ALATTACHMENT
                OBJMAIL.subject = "Invoice"
                OBJMAIL.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class