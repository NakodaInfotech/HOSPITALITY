
Imports BL
Imports DevExpress.XtraGrid.Views.Grid
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class VisaBookingDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim SALEREGID As Integer

    Private Sub VisaBookingDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Sub fillgrid()
        Try
            Dim objclsCMST As New ClsCommonMaster
            'Dim dt As DataTable = objclsCMST.search(" ISNULL(VISABOOKING.BOOKING_ENQNO,0) AS ENQNO, VISABOOKING.BOOKING_NO AS BOOKINGNO, VISABOOKING.BOOKING_DATE AS BOOKINGDATE, LEDGERS.Acc_cmpname AS ACCNAME, ISNULL(BOOKEDBYMASTER.BOOKEDBY_NAME, '') AS BOOKEDBY, ISNULL(VISABOOKING.BOOKING_ENQUIREDBY, '') AS ENQBY, ISNULL(SOURCEMASTER.SOURCE_NAME, '') AS SOURCE,ISNULL(VISABOOKING.BOOKING_REFNO, '') AS REFNO, ISNULL(VISABOOKING.BOOKING_TOTALSALEAMT, '') AS TOTALAMT, ISNULL(VISABOOKING.BOOKING_GRANDTOTAL, 0) AS GRANDTOTAL, ISNULL(VISABOOKING.BOOKING_SALEAMTREC, 0) AS AMTRECD, ISNULL(VISABOOKING.BOOKING_SALEBALANCE, 0) AS BALANCE, ISNULL(VISABOOKING.BOOKING_REMARKS, '') AS REMARKS, ISNULL(USERMASTER.User_Name, '') AS USERNAME, ISNULL(VISABOOKING.BOOKING_BILLCHECKED, 0) AS BILLCHECKED, ISNULL(VISABOOKING.BOOKING_DISPUTE, 0) AS BILLDISPUTE, VISABOOKING.BOOKING_SERVICECHGS AS SERVCHGS, ISNULL(TAXMASTER.tax_name,'') AS TAXNAME, VISABOOKING.BOOKING_TAX AS TAXAMT, VISABOOKING.BOOKING_OTHERCHGS AS OTHERCHGS ", "", " VISABOOKING INNER JOIN LEDGERS ON VISABOOKING.BOOKING_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN TAXMASTER ON VISABOOKING.BOOKING_TAXID = TAXMASTER.tax_id LEFT OUTER JOIN USERMASTER ON VISABOOKING.BOOKING_USERID = USERMASTER.User_id LEFT OUTER JOIN SOURCEMASTER ON VISABOOKING.BOOKING_SOURCEID = SOURCEMASTER.SOURCE_ID LEFT OUTER JOIN BOOKEDBYMASTER ON VISABOOKING.BOOKING_BOOKEDBYID = BOOKEDBYMASTER.BOOKEDBY_ID ", " AND VISABOOKING.BOOKING_YEARID = " & YearId & " ORDER BY VISABOOKING.BOOKING_NO")
            Dim dt As DataTable = objclsCMST.search(" ISNULL(VISABOOKING.BOOKING_ENQNO, 0) AS ENQNO, VISABOOKING.BOOKING_NO AS BOOKINGNO, VISABOOKING.BOOKING_DATE AS BOOKINGDATE, LEDGERS.Acc_cmpname AS ACCNAME, ISNULL(BOOKEDBYMASTER.BOOKEDBY_NAME, '') AS BOOKEDBY, ISNULL(VISABOOKING.BOOKING_ENQUIREDBY, '') AS ENQBY, ISNULL(SOURCEMASTER.SOURCE_NAME, '') AS SOURCE, ISNULL(VISABOOKING.BOOKING_REFNO, '') AS REFNO, ISNULL(VISABOOKING.BOOKING_TOTALSALEAMT, '') AS TOTALAMT, ISNULL(VISABOOKING.BOOKING_GRANDTOTAL, 0) AS GRANDTOTAL, ISNULL(VISABOOKING.BOOKING_SALEAMTREC, 0) AS AMTRECD, ISNULL(VISABOOKING.BOOKING_SALEBALANCE, 0) AS BALANCE, ISNULL(VISABOOKING.BOOKING_REMARKS, '') AS REMARKS, ISNULL(USERMASTER.User_Name, '') AS USERNAME, ISNULL(VISABOOKING.BOOKING_BILLCHECKED, 0) AS BILLCHECKED, ISNULL(VISABOOKING.BOOKING_DISPUTE, 0) AS BILLDISPUTE, VISABOOKING.BOOKING_SERVICECHGS AS SERVCHGS, ISNULL(TAXMASTER.tax_name, '') AS TAXNAME, VISABOOKING.BOOKING_TAX AS TAXAMT, VISABOOKING.BOOKING_OTHERCHGS AS OTHERCHGS, ISNULL(STATEMASTER.state_name, '') AS STATENAME, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(VISABOOKING.BOOKING_CGSTPER, 0) AS CGSTPER, ISNULL(VISABOOKING.BOOKING_CGSTAMT, 0) AS CGSTAMT, ISNULL(VISABOOKING.BOOKING_SGSTPER, 0) AS SGSTPER, ISNULL(VISABOOKING.BOOKING_SGSTAMT, 0) AS SGSTAMT, ISNULL(VISABOOKING.BOOKING_IGSTPER, 0) AS IGSTPER, ISNULL(VISABOOKING.BOOKING_IGSTAMT, 0) AS IGSTAMT, ISNULL(VISABOOKING.BOOKING_IRNNO, '') AS IRNNO, ISNULL(VISABOOKING.BOOKING_ACKNO, '') AS ACKNO, VISABOOKING.BOOKING_ACKDATE AS ACKDATE, VISABOOKING.BOOKING_QRCODE AS QRCODE, ISNULL(GROUPDEPARTURE.GROUPDEP_NAME, '') AS GROUPDEPARTURE ", "", " VISABOOKING INNER JOIN LEDGERS ON VISABOOKING.BOOKING_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN GROUPDEPARTURE ON VISABOOKING.BOOKING_GROUPDEPARTID = GROUPDEPARTURE.GROUPDEP_NO LEFT OUTER JOIN HSNMASTER ON VISABOOKING.BOOKING_HSNCODEID = HSNMASTER.HSN_ID LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN TAXMASTER ON VISABOOKING.BOOKING_TAXID = TAXMASTER.tax_id LEFT OUTER JOIN USERMASTER ON VISABOOKING.BOOKING_USERID = USERMASTER.User_id LEFT OUTER JOIN SOURCEMASTER ON VISABOOKING.BOOKING_SOURCEID = SOURCEMASTER.SOURCE_ID LEFT OUTER JOIN BOOKEDBYMASTER ON VISABOOKING.BOOKING_BOOKEDBYID = BOOKEDBYMASTER.BOOKEDBY_ID ", " AND VISABOOKING.BOOKING_YEARID = " & YearId & " ORDER BY VISABOOKING.BOOKING_NO")
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
                Dim OBJBOOKING As New VisaBooking
                OBJBOOKING.MdiParent = MDIMain
                OBJBOOKING.edit = editval
                OBJBOOKING.TEMPBOOKINGNO = BOOKINGNO
                OBJBOOKING.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
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

    Private Sub VisaBookingDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'VISA'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Dim clscommon As New ClsCommon
            Dim dt As DataTable = clscommon.search(" register_abbr, register_initials, register_id ", "", " RegisterMaster ", " and register_name ='VISA SALE REGISTER' and register_type = 'SALE' and register_YEARid = " & YearId)
            If dt.Rows.Count > 0 Then SALEREGID = dt.Rows(0).Item(2)

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

                If View.GetRowCellDisplayText(e.RowHandle, View.Columns("BILLCHECKED")) = "Checked" Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                    e.Appearance.BackColor = Color.Yellow

                ElseIf View.GetRowCellDisplayText(e.RowHandle, View.Columns("BILLDISPUTE")) = "Checked" Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                    e.Appearance.BackColor = Color.LightBlue

                ElseIf Val(View.GetRowCellDisplayText(e.RowHandle, View.Columns("BALANCE"))) > 0 Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                    e.Appearance.BackColor = Color.Orange

                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Visa Booking Details.XLS"

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

            opti.SheetName = "Visa Booking Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Visa Booking Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

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

    Private Sub VisaBookingDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If ClientName = "STARVISA" Then
                GSOURCE.Caption = "Country"
                GREMARKS.Caption = "Passport"
                GREMARKS.Width = 75
                GREMARKS.VisibleIndex = 3
                GENQNO.Visible = True
                GENQNO.VisibleIndex = 0
                gdate.VisibleIndex = 1
                gaccname.Caption = "Client Name"
                GBOOKEDBY.Visible = False
            End If
            If ClientName = "GLOBAL" Then
                GGSTIN.Visible = False
                GSTATENAME.Visible = False
                GHSNCODE.Visible = False
                GCGSTPER.Visible = False
                GCGSTAMT.Visible = False
                GSGSTAMT.Visible = False
                GSGSTPER.Visible = False
                GIGSTAMT.Visible = False
                GIGSTPER.Visible = False


            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLREFRESH_Click(sender As Object, e As EventArgs) Handles TOOLREFRESH.Click
        Try
            fillgrid()
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
            '    For I As Integer = Val(TXTFROM.Text.Trim) To Val(TXTTO.Text.Trim)
            '    Dim OBJINVOICE As New VisaBookingDesign
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
                Dim OBJINVOICE As New VisaBookingDesign
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

                Dim OBJINVOICE As New VisaBookingDesign
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