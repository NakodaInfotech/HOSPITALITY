

Imports BL
    Imports DevExpress.XtraGrid.Views.Grid
    Imports CrystalDecisions.Shared
    Imports CrystalDecisions.CrystalReports.Engine

Public Class OtherSalePurchaseDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim SALEREGID As Integer

    Private Sub OtherSalePurchaseDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub OtherSalePurchaseDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'OTHER SALE PURCHASE'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" OTHERSALEPURCHASEMASTER.BOOKING_NO AS BOOKINGNO, OTHERSALEPURCHASEMASTER.BOOKING_REFNO AS REFNO, OTHERSALEPURCHASEMASTER.BOOKING_PURBILLINITIALS AS BILLINITIALS, LEDGERS.Acc_cmpname AS ACCNAME, USERMASTER.User_Name AS USERNAME, OTHERSALEPURCHASEMASTER.BOOKING_DATE AS BOOKINGDATE, OTHERSALEPURCHASEMASTER.BOOKING_FINALSALEAMT AS FINALSALEAMT, OTHERSALEPURCHASEMASTER.BOOKING_DISCRECDRS AS DISCAMT, OTHERSALEPURCHASEMASTER.BOOKING_COMMRECDRS AS COMMAMT, OTHERSALEPURCHASEMASTER.BOOKING_TDSRS AS TDSAMT, OTHERSALEPURCHASEMASTER.BOOKING_SUBTOTAL AS SUBTOTAL, ISNULL(TAXMASTER.tax_name, '') AS TAXNAME, OTHERSALEPURCHASEMASTER.BOOKING_TAX AS TAXAMT, OTHERSALEPURCHASEMASTER.BOOKING_OTHERCHGS AS OTHERCHGS, OTHERSALEPURCHASEMASTER.BOOKING_GRANDTOTAL AS GRANDTOTAL, OTHERSALEPURCHASEMASTER.BOOKING_BALANCE AS BALANCE, OTHERSALEPURCHASEMASTER.BOOKING_DISPUTE AS DISPUTED, OTHERSALEPURCHASEMASTER.BOOKING_BILLCHECKED AS BILLCHECKED, OTHERSALEPURCHASEMASTER.BOOKING_CANCELLED AS CANCELLED, USERMASTER_1.User_Name AS MODIFIEDBY, OTHERSALEPURCHASEMASTER.BOOKING_CGSTAMT AS CGSTAMT, OTHERSALEPURCHASEMASTER.BOOKING_SGSTAMT AS SGSTAMT, OTHERSALEPURCHASEMASTER.BOOKING_IGSTAMT AS IGSTAMT, ISNULL(LEDGERS.Acc_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.state_name, '') AS STATENAME, ISNULL(CAST(STATEMASTER.state_remark AS VARCHAR), '') AS STATECODE, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(OTHERSALEPURCHASEMASTER.BOOKING_ROUNDOFF, 0) AS ROUNDOFF, ISNULL(OTHERSALEPURCHASEMASTER.BOOKING_EXTRACHGS, 0) AS PUREXTRACHGS, ISNULL(OTHERCHGSLEDGERS.Acc_cmpname, '') AS OTHERCHGSNAME,  ISNULL(OTHERSALEPURCHASEMASTER.BOOKING_TAXSERVCHGS, 0) AS TAXSERVCHGS, ISNULL(SOURCEMASTER.SOURCE_NAME, '') AS SOURCE, ISNULL(GUESTMASTER.GUEST_NAME, '') AS GUESTNAME, ISNULL(OTHERSALEPURCHASEMASTER.BOOKING_BOOKINGDESC, '') AS NOTES, ISNULL(OTHERSALEPURCHASEMASTER.BOOKING_REMARKS, '') AS REMARKS, ISNULL(OTHERSALEPURCHASEMASTER.BOOKING_SPECIALREMARKS, '') AS SPECIALREMARKS, ISNULL(OTHERSALEPURCHASEMASTER.BOOKING_IRNNO, '') AS IRNNO, ISNULL(OTHERSALEPURCHASEMASTER.BOOKING_ACKNO, '') AS ACKNO, OTHERSALEPURCHASEMASTER.BOOKING_ACKDATE AS ACKDATE, OTHERSALEPURCHASEMASTER.BOOKING_QRCODE AS QRCODE, ISNULL(GROUPDEPARTURE.GROUPDEP_NAME, '') AS TOURNAME, ISNULL(OTHERSALEPURCHASEMASTER.BOOKING_FINALPURAMT, 0) AS FINALPURAMT ", "", " OTHERSALEPURCHASEMASTER INNER JOIN REGISTERMASTER ON REGISTERMASTER.register_id = OTHERSALEPURCHASEMASTER.BOOKING_PURCHASEREGISTERID INNER JOIN LEDGERS ON LEDGERS.Acc_id = OTHERSALEPURCHASEMASTER.BOOKING_LEDGERID INNER JOIN USERMASTER ON USERMASTER.User_id = OTHERSALEPURCHASEMASTER.BOOKING_USERID INNER JOIN USERMASTER AS USERMASTER_1 ON OTHERSALEPURCHASEMASTER.BOOKING_MODIFIEDBY = USERMASTER_1.User_id LEFT OUTER JOIN GROUPDEPARTURE ON OTHERSALEPURCHASEMASTER.BOOKING_YEARID = GROUPDEPARTURE.GROUPDEP_YEARID AND OTHERSALEPURCHASEMASTER.BOOKING_TOURID = GROUPDEPARTURE.GROUPDEP_NO LEFT OUTER JOIN LEDGERS AS OTHERCHGSLEDGERS ON OTHERSALEPURCHASEMASTER.BOOKING_OTHERCHGSID = OTHERCHGSLEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN HSNMASTER ON OTHERSALEPURCHASEMASTER.BOOKING_HSNCODEID = HSNMASTER.HSN_ID LEFT OUTER JOIN TAXMASTER ON OTHERSALEPURCHASEMASTER.BOOKING_TAXID = TAXMASTER.tax_id LEFT OUTER JOIN SOURCEMASTER ON OTHERSALEPURCHASEMASTER.BOOKING_SOURCEID = SOURCEMASTER.SOURCE_ID LEFT OUTER JOIN GUESTMASTER ON OTHERSALEPURCHASEMASTER.BOOKING_GUESTID = GUESTMASTER.GUEST_ID ", " AND OTHERSALEPURCHASEMASTER.BOOKING_YEARID = " & YearId & " ORDER BY OTHERSALEPURCHASEMASTER.BOOKING_NO")
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
                Dim objPUR As New OtherSalePurchase
                objPUR.MdiParent = MDIMain
                objPUR.edit = editval
                objPUR.TEMPBOOKINGNO = BOOKINGNO
                objPUR.Show()
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
            PATH = Application.StartupPath & "\Other Sale Purchase.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            Dim workbook As String = PATH
            If FileIO.FileSystem.FileExists(PATH) = True Then Interaction.GetObject(workbook).close(False)
            GC.Collect()

            Dim PERIOD As String = ""
            PERIOD = AccFrom & " - " & AccTo

            opti.SheetName = "Other Sale Purchase"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Other Sale Purchase", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

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
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLGRIDDETAILS_Click(sender As Object, e As EventArgs) Handles TOOLGRIDDETAILS.Click
        Try
            Dim OBJGRIDMISCSALE As New OSPSaleGridDetails
            OBJGRIDMISCSALE.MdiParent = MDIMain
            OBJGRIDMISCSALE.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLPURGRIDDETAILS_Click(sender As Object, e As EventArgs) Handles TOOLPURGRIDDETAILS.Click
        Try
            Dim OBJGRIDMISCSALE As New OSPPurchaseGridDetails
            OBJGRIDMISCSALE.MdiParent = MDIMain
            OBJGRIDMISCSALE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbilldetails_Click(sender As Object, e As EventArgs)

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
            Dim ALATTACHMENT As New ArrayList
            If INVOICEMAIL = False Then If PrintDialog.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PrintDialog.PrinterSettings
            For I As Integer = Val(TXTFROM.Text.Trim) To Val(TXTTO.Text.Trim)
                Dim OBJINVOICE As New OtherSaleVoucherDesign
                OBJINVOICE.MdiParent = MDIMain
                OBJINVOICE.DIRECTPRINT = True
                OBJINVOICE.FRMSTRING = "INVOICE"
                OBJINVOICE.DIRECTMAIL = INVOICEMAIL
                OBJINVOICE.BOOKINGNO = Val(I)
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

                Dim OBJINVOICE As New OtherSaleVoucherDesign
                OBJINVOICE.MdiParent = MDIMain
                OBJINVOICE.DIRECTPRINT = True
                OBJINVOICE.FRMSTRING = "INVOICE"
                OBJINVOICE.DIRECTMAIL = INVOICEMAIL
                OBJINVOICE.BOOKINGNO = Val(ROW("BOOKINGNO"))
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