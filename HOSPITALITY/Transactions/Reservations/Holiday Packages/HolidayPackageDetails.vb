
Imports BL
Imports DevExpress.XtraGrid.Views.Grid
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class HolidayPackageDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub HolidayPackageDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Alt = True Then
                showform(False, 0)
            ElseIf e.KeyCode = Keys.O And e.Alt = True Then
                CMDOK_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            If ClientName = "PARAMOUNT" Then
                dt = objclsCMST.search("  HOLIDAYPACKAGEMASTER.BOOKING_NO AS BOOKINGNO, HOLIDAYPACKAGEMASTER.BOOKING_DATE AS BOOKINGDATE, GUESTMASTER.GUEST_NAME AS GUESTNAME, ACCOUNTSMASTER.Acc_cmpname AS ACCNAME, HOLIDAYPACKAGEMASTER.BOOKING_TOURNAME AS TOURNAME, HOLIDAYPACKAGEMASTER.BOOKING_PACKAGEFROM AS PACKAGEFROM, HOLIDAYPACKAGEMASTER.BOOKING_PACKAGETO AS PACKAGETO,  HOLIDAYPACKAGEMASTER.BOOKING_TOTALPAX AS TOTALPAX, HOLIDAYPACKAGEMASTER.BOOKING_TOTALPURAMT AS PURTOTAL, HOLIDAYPACKAGEMASTER.BOOKING_GRANDTOTAL AS GRANDTOTAL, USERMASTER.User_Name AS USERNAME, HOLIDAYPACKAGEMASTER.BOOKING_CANCELLED AS CANCELLED, HOLIDAYPACKAGEMASTER.BOOKING_AMD_DONE AS AMENDED, HOLIDAYPACKAGEMASTER.BOOKING_DISPUTE AS DISPUTED,  HOLIDAYPACKAGEMASTER.BOOKING_BILLCHECKED AS CHECKED, HOLIDAYPACKAGEMASTER.BOOKING_SALERETURN AS SALERETURN, HOLIDAYPACKAGEMASTER.BOOKING_FAILED AS FAILED , HOLIDAYPACKAGEMASTER.BOOKING_REFUNDED AS REFUNDED, ISNULL(BOOKEDBY_NAME,'') AS BOOKEDBY,ISNULL(HOLIDAYPACKAGEMASTER.BOOKING_TAXSERVCHGS, 0) AS TAXSERVCHGS ", "", " HOLIDAYPACKAGEMASTER INNER JOIN ACCOUNTSMASTER ON HOLIDAYPACKAGEMASTER.BOOKING_LEDGERID = ACCOUNTSMASTER.Acc_id AND HOLIDAYPACKAGEMASTER.BOOKING_CMPID = ACCOUNTSMASTER.Acc_cmpid AND HOLIDAYPACKAGEMASTER.BOOKING_LOCATIONID = ACCOUNTSMASTER.Acc_locationid AND HOLIDAYPACKAGEMASTER.BOOKING_YEARID = ACCOUNTSMASTER.Acc_yearid INNER JOIN USERMASTER ON HOLIDAYPACKAGEMASTER.BOOKING_USERID = USERMASTER.User_id AND HOLIDAYPACKAGEMASTER.BOOKING_CMPID = USERMASTER.User_cmpid INNER JOIN HOLIDAYPACKAGEMASTER_GUESTDETAILS ON HOLIDAYPACKAGEMASTER.BOOKING_NO = HOLIDAYPACKAGEMASTER_GUESTDETAILS.BOOKING_NO AND HOLIDAYPACKAGEMASTER.BOOKING_CMPID = HOLIDAYPACKAGEMASTER_GUESTDETAILS.BOOKING_CMPID AND HOLIDAYPACKAGEMASTER.BOOKING_LOCATIONID = HOLIDAYPACKAGEMASTER_GUESTDETAILS.BOOKING_LOCATIONID AND HOLIDAYPACKAGEMASTER.BOOKING_YEARID = HOLIDAYPACKAGEMASTER_GUESTDETAILS.BOOKING_YEARID INNER JOIN GUESTMASTER ON HOLIDAYPACKAGEMASTER_GUESTDETAILS.BOOKING_GUESTID = GUESTMASTER.GUEST_ID AND HOLIDAYPACKAGEMASTER_GUESTDETAILS.BOOKING_CMPID = GUESTMASTER.GUEST_CMPID AND HOLIDAYPACKAGEMASTER_GUESTDETAILS.BOOKING_LOCATIONID = GUESTMASTER.GUEST_LOCATIONID AND HOLIDAYPACKAGEMASTER_GUESTDETAILS.BOOKING_YEARID = GUESTMASTER.GUEST_YEARID LEFT OUTER JOIN BOOKEDBYMASTER ON HOLIDAYPACKAGEMASTER.BOOKING_BOOKEDBYID = BOOKEDBYMASTER.BOOKEDBY_ID AND HOLIDAYPACKAGEMASTER.BOOKING_CMPID = BOOKEDBYMASTER.BOOKEDBY_CMPID AND HOLIDAYPACKAGEMASTER.BOOKING_LOCATIONID = BOOKEDBYMASTER.BOOKEDBY_LOCATIONID AND HOLIDAYPACKAGEMASTER.BOOKING_YEARID = BOOKEDBYMASTER.BOOKEDBY_YEARID  ", " AND HOLIDAYPACKAGEMASTER.BOOKING_CMPID =" & CmpId & " AND HOLIDAYPACKAGEMASTER.BOOKING_LOCATIONID = " & Locationid & " AND HOLIDAYPACKAGEMASTER.BOOKING_YEARID = " & YearId & " ORDER BY HOLIDAYPACKAGEMASTER.BOOKING_NO")
            Else
                'dt = objclsCMST.search("HOLIDAYPACKAGEMASTER.BOOKING_NO AS BOOKINGNO, HOLIDAYPACKAGEMASTER.BOOKING_DATE AS BOOKINGDATE, ACCOUNTSMASTER.Acc_cmpname AS ACCNAME,  HOLIDAYPACKAGEMASTER.BOOKING_TOURNAME AS TOURNAME, HOLIDAYPACKAGEMASTER.BOOKING_PACKAGEFROM AS PACKAGEFROM, HOLIDAYPACKAGEMASTER.BOOKING_PACKAGETO AS PACKAGETO,  HOLIDAYPACKAGEMASTER.BOOKING_TOTALPAX AS TOTALPAX, HOLIDAYPACKAGEMASTER.BOOKING_TOTALPURAMT AS PURTOTAL, HOLIDAYPACKAGEMASTER.BOOKING_GRANDTOTAL AS GRANDTOTAL,  USERMASTER.User_Name AS USERNAME, HOLIDAYPACKAGEMASTER.BOOKING_CANCELLED AS CANCELLED, HOLIDAYPACKAGEMASTER.BOOKING_AMD_DONE AS AMENDED,  HOLIDAYPACKAGEMASTER.BOOKING_DISPUTE AS DISPUTED, HOLIDAYPACKAGEMASTER.BOOKING_BILLCHECKED AS CHECKED, HOLIDAYPACKAGEMASTER.BOOKING_SALERETURN AS SALERETURN,  HOLIDAYPACKAGEMASTER.BOOKING_FAILED AS FAILED, HOLIDAYPACKAGEMASTER.BOOKING_REFUNDED AS REFUNDED, ISNULL(BOOKEDBYMASTER.BOOKEDBY_NAME, '') AS BOOKEDBY,  HOLIDAYPACKAGEMASTER.BOOKING_SUBTOTAL AS SUBTOTAL, ISNULL(TAXMASTER.tax_name, '') AS TAXNAME, HOLIDAYPACKAGEMASTER.BOOKING_TAX AS TAXAMT,  HOLIDAYPACKAGEMASTER.BOOKING_ARRIVALFROM AS ARRFROM, HOLIDAYPACKAGEMASTER.BOOKING_ARRFLIGHTNO AS ARRFLIGHTNO, HOLIDAYPACKAGEMASTER.BOOKING_DEPARTTO AS DEPARTTO,  HOLIDAYPACKAGEMASTER.BOOKING_DEPARTFLIGHTNO AS DEPARTFLIGHTNO, HOLIDAYPACKAGEMASTER.BOOKING_SALEBALANCE AS SALEBAL, HOLIDAYPACKAGEMASTER.BOOKING_REFNO AS REFNO,  ISNULL(STATEMASTER.state_name, '') AS STATENAME, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(ACCOUNTSMASTER.Acc_GSTIN, '') AS GSTIN, ISNULL(HOLIDAYPACKAGEMASTER.BOOKING_CGSTPER, 0)  AS CGSTPER, ISNULL(HOLIDAYPACKAGEMASTER.BOOKING_CGSTAMT, 0) AS CGSTAMT, ISNULL(HOLIDAYPACKAGEMASTER.BOOKING_SGSTPER, 0) AS SGSTPER, ISNULL(HOLIDAYPACKAGEMASTER.BOOKING_SGSTAMT, 0)  AS SGSTAMT, ISNULL(HOLIDAYPACKAGEMASTER.BOOKING_IGSTPER, 0) AS IGSTPER, ISNULL(HOLIDAYPACKAGEMASTER.BOOKING_IGSTAMT, 0) AS IGSTAMT, ISNULL(HOLIDAYPACKAGEMASTER.BOOKING_OURCOMMRS, '')  AS OURCOMMRS, ISNULL(HOLIDAYPACKAGEMASTER.BOOKING_TAXSERVCHGS, 0) AS TAXSERVCHGS, ISNULL(SOURCEMASTER.SOURCE_NAME, '') AS SOURCE, ISNULL(HOLIDAYPACKAGEMASTER.BOOKING_IRNNO, '')  AS IRNNO, ISNULL(HOLIDAYPACKAGEMASTER.BOOKING_ACKNO, '') AS ACKNO, HOLIDAYPACKAGEMASTER.BOOKING_ACKDATE AS ACKDATE, HOLIDAYPACKAGEMASTER.BOOKING_QRCODE AS QRCODE,  ISNULL(GROUPDEPARTURE.GROUPDEP_NAME, '') AS GROUPDEPART", "", " HOLIDAYPACKAGEMASTER INNER JOIN ACCOUNTSMASTER ON HOLIDAYPACKAGEMASTER.BOOKING_LEDGERID = ACCOUNTSMASTER.Acc_id INNER JOIN USERMASTER ON HOLIDAYPACKAGEMASTER.BOOKING_USERID = USERMASTER.User_id LEFT OUTER JOIN GROUPDEPARTURE ON HOLIDAYPACKAGEMASTER.BOOKING_GROUPDEPARTID = GROUPDEPARTURE.GROUPDEP_NO AND  HOLIDAYPACKAGEMASTER.BOOKING_YEARID = GROUPDEPARTURE.GROUPDEP_YEARID LEFT OUTER JOIN HSNMASTER ON HOLIDAYPACKAGEMASTER.BOOKING_HSNCODEID = HSNMASTER.HSN_ID LEFT OUTER JOIN STATEMASTER ON ACCOUNTSMASTER.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN TAXMASTER ON HOLIDAYPACKAGEMASTER.BOOKING_TAXID = TAXMASTER.tax_id LEFT OUTER JOIN BOOKEDBYMASTER ON HOLIDAYPACKAGEMASTER.BOOKING_BOOKEDBYID = BOOKEDBYMASTER.BOOKEDBY_ID LEFT OUTER JOIN SOURCEMASTER ON HOLIDAYPACKAGEMASTER.BOOKING_SOURCEID = SOURCEMASTER.SOURCE_ID ", " AND HOLIDAYPACKAGEMASTER.BOOKING_YEARID = " & YearId & " ORDER BY HOLIDAYPACKAGEMASTER.BOOKING_NO")
                dt = objclsCMST.search("HOLIDAYPACKAGEMASTER.BOOKING_NO AS BOOKINGNO, HOLIDAYPACKAGEMASTER.BOOKING_DATE AS BOOKINGDATE, ACCOUNTSMASTER.Acc_cmpname AS ACCNAME, HOLIDAYPACKAGEMASTER.BOOKING_TOURNAME AS TOURNAME, HOLIDAYPACKAGEMASTER.BOOKING_PACKAGEFROM AS PACKAGEFROM, HOLIDAYPACKAGEMASTER.BOOKING_PACKAGETO AS PACKAGETO, HOLIDAYPACKAGEMASTER.BOOKING_TOTALPAX AS TOTALPAX, HOLIDAYPACKAGEMASTER.BOOKING_TOTALPURAMT AS PURTOTAL, HOLIDAYPACKAGEMASTER.BOOKING_GRANDTOTAL AS GRANDTOTAL, USERMASTER.User_Name AS USERNAME, HOLIDAYPACKAGEMASTER.BOOKING_CANCELLED AS CANCELLED, HOLIDAYPACKAGEMASTER.BOOKING_AMD_DONE AS AMENDED, HOLIDAYPACKAGEMASTER.BOOKING_DISPUTE AS DISPUTED, HOLIDAYPACKAGEMASTER.BOOKING_BILLCHECKED AS CHECKED, HOLIDAYPACKAGEMASTER.BOOKING_SALERETURN AS SALERETURN, HOLIDAYPACKAGEMASTER.BOOKING_FAILED AS FAILED, HOLIDAYPACKAGEMASTER.BOOKING_REFUNDED AS REFUNDED, ISNULL(BOOKEDBYMASTER.BOOKEDBY_NAME, '') AS BOOKEDBY, HOLIDAYPACKAGEMASTER.BOOKING_SUBTOTAL AS SUBTOTAL, ISNULL(TAXMASTER.tax_name, '') AS TAXNAME, HOLIDAYPACKAGEMASTER.BOOKING_TAX AS TAXAMT, HOLIDAYPACKAGEMASTER.BOOKING_ARRIVALFROM AS ARRFROM, HOLIDAYPACKAGEMASTER.BOOKING_ARRFLIGHTNO AS ARRFLIGHTNO, HOLIDAYPACKAGEMASTER.BOOKING_DEPARTTO AS DEPARTTO, HOLIDAYPACKAGEMASTER.BOOKING_DEPARTFLIGHTNO AS DEPARTFLIGHTNO, HOLIDAYPACKAGEMASTER.BOOKING_SALEBALANCE AS SALEBAL, HOLIDAYPACKAGEMASTER.BOOKING_REFNO AS REFNO, ISNULL(STATEMASTER.state_name, '') AS STATENAME, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(ACCOUNTSMASTER.Acc_GSTIN, '') AS GSTIN, ISNULL(HOLIDAYPACKAGEMASTER.BOOKING_CGSTPER, 0) AS CGSTPER, ISNULL(HOLIDAYPACKAGEMASTER.BOOKING_CGSTAMT, 0) AS CGSTAMT, ISNULL(HOLIDAYPACKAGEMASTER.BOOKING_SGSTPER, 0) AS SGSTPER, ISNULL(HOLIDAYPACKAGEMASTER.BOOKING_SGSTAMT, 0) AS SGSTAMT, ISNULL(HOLIDAYPACKAGEMASTER.BOOKING_IGSTPER, 0) AS IGSTPER, ISNULL(HOLIDAYPACKAGEMASTER.BOOKING_IGSTAMT, 0) AS IGSTAMT, ISNULL(HOLIDAYPACKAGEMASTER.BOOKING_OURCOMMRS, '') AS OURCOMMRS, ISNULL(HOLIDAYPACKAGEMASTER.BOOKING_TAXSERVCHGS, 0) AS TAXSERVCHGS, ISNULL(SOURCEMASTER.SOURCE_NAME, '') AS SOURCE, ISNULL(HOLIDAYPACKAGEMASTER.BOOKING_IRNNO, '') AS IRNNO, ISNULL(HOLIDAYPACKAGEMASTER.BOOKING_ACKNO, '') AS ACKNO, HOLIDAYPACKAGEMASTER.BOOKING_ACKDATE AS ACKDATE, HOLIDAYPACKAGEMASTER.BOOKING_QRCODE AS QRCODE, ISNULL(GROUPDEPARTURE.GROUPDEP_NAME, '') AS GROUPDEPART, ISNULL(HOLIDAYPACKAGEMASTER.BOOKING_PACKAGETYPE, '') AS PACKAGETYPE", "", " HOLIDAYPACKAGEMASTER INNER JOIN ACCOUNTSMASTER ON HOLIDAYPACKAGEMASTER.BOOKING_LEDGERID = ACCOUNTSMASTER.Acc_id INNER JOIN USERMASTER ON HOLIDAYPACKAGEMASTER.BOOKING_USERID = USERMASTER.User_id LEFT OUTER JOIN GROUPDEPARTURE ON HOLIDAYPACKAGEMASTER.BOOKING_GROUPDEPARTID = GROUPDEPARTURE.GROUPDEP_NO AND HOLIDAYPACKAGEMASTER.BOOKING_YEARID = GROUPDEPARTURE.GROUPDEP_YEARID LEFT OUTER JOIN HSNMASTER ON HOLIDAYPACKAGEMASTER.BOOKING_HSNCODEID = HSNMASTER.HSN_ID LEFT OUTER JOIN STATEMASTER ON ACCOUNTSMASTER.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN TAXMASTER ON HOLIDAYPACKAGEMASTER.BOOKING_TAXID = TAXMASTER.tax_id LEFT OUTER JOIN BOOKEDBYMASTER ON HOLIDAYPACKAGEMASTER.BOOKING_BOOKEDBYID = BOOKEDBYMASTER.BOOKEDBY_ID LEFT OUTER JOIN SOURCEMASTER ON HOLIDAYPACKAGEMASTER.BOOKING_SOURCEID = SOURCEMASTER.SOURCE_ID ", " AND HOLIDAYPACKAGEMASTER.BOOKING_YEARID = " & YearId & " ORDER BY HOLIDAYPACKAGEMASTER.BOOKING_NO")

                gridbill.Columns("GUESTNAME").Visible = False
            End If
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
                Dim OBJBOOKING As New HolidayPackage
                OBJBOOKING.MdiParent = MDIMain
                OBJBOOKING.edit = editval
                OBJBOOKING.TEMPBOOKINGNO = BOOKINGNO
                OBJBOOKING.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
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

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("BOOKINGNO"))
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

    Private Sub HolidayPackageDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'HOLIDAY PACKAGES'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gridbill.RowStyle
        Try
            Dim DT As DataTable = gridbilldetails.DataSource
            If e.RowHandle >= 0 Then
                Dim ROW As DataRow = DT.Rows(e.RowHandle)
                Dim View As GridView = sender
                If Val(View.GetRowCellDisplayText(e.RowHandle, View.Columns("SALERETURN"))) > 0 Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                    e.Appearance.BackColor = Color.Yellow

                ElseIf View.GetRowCellDisplayText(e.RowHandle, View.Columns("CHECKED")) = "Checked" Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                    e.Appearance.BackColor = Color.LightGreen

                ElseIf View.GetRowCellDisplayText(e.RowHandle, View.Columns("DISPUTED")) = "Checked" Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                    e.Appearance.BackColor = Color.LightBlue

                ElseIf View.GetRowCellDisplayText(e.RowHandle, View.Columns("FAILED")) = "Checked" Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                    e.Appearance.BackColor = Color.Plum

                ElseIf View.GetRowCellDisplayText(e.RowHandle, View.Columns("REFUNDED")) = "Checked" Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                    e.Appearance.BackColor = Color.PeachPuff
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HolidayPackageDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "ELYSIUM" Then Me.Close()
        If ClientName = "SEASONED" Then
            PRINTTOOL.Visible = True
            LBLFROM.Visible = True
            LBLTO.Visible = True
            TXTFROM.Visible = True
            TXTTO.Visible = True
        End If
        If ClientName = "GLOBAL" Then
            GSTATE.Visible = False
            GGSTIN.Visible = False
            GHSNCODE.Visible = False
            GCGSTPER.Visible = False
            GCGSTAMT.Visible = False
            GSGSTPER.Visible = False
            GSGSTAMT.Visible = False
            GIGSTAMT.Visible = False
            GIGSTPER.Visible = False

        End If
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Holiday Package Details.XLS"

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

            opti.SheetName = "Holiday Package Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Holiday Package Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

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
            '    Dim OBJINVOICE As New HolidayPackageVoucherDesign
            '    OBJINVOICE.MdiParent = MDIMain
            '    OBJINVOICE.DIRECTPRINT = True
            '    OBJINVOICE.FRMSTRING = "INVOICE"
            '    OBJINVOICE.BOOKINGNO = Val(I)
            '    OBJINVOICE.Show()
            '    OBJINVOICE.Close()
            'Next
            Dim ALATTACHMENT As New ArrayList
            If INVOICEMAIL = False Then If PRINTDIALOG.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PRINTDIALOG.PrinterSettings
            For I As Integer = Val(TXTFROM.Text.Trim) To Val(TXTTO.Text.Trim)
                Dim OBJINVOICE As New HolidayPackageVoucherDesign
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

                Dim OBJINVOICE As New HolidayPackageVoucherDesign
                OBJINVOICE.MdiParent = MDIMain
                OBJINVOICE.DIRECTPRINT = True
                OBJINVOICE.FRMSTRING = "INVOICE"
                OBJINVOICE.DIRECTMAIL = INVOICEMAIL
                OBJINVOICE.BOOKINGNO = Val(ROW("BOOKINGNO"))
                OBJINVOICE.BOOKINGDATE = ROW("BOOKINGDATE")
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