
Imports BL

Public Class DebitNoteDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim JVREGID As Integer

    Sub fillgrid(ByVal tempcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim DT As DataTable = objclsCMST.search(" DEBITNOTEMASTER.DN_no AS GSRNO, DEBITNOTEMASTER.DN_date AS GDATE, DEBITNOTEMASTER.DN_BILLNO AS GBILLNO, GUESTMASTER.GUEST_NAME AS GGUESTNAME, HOTELMASTER.HOTEL_NAME AS GHOTELNAME, LEDGERS.Acc_cmpname AS GNAME, DEBITNOTEMASTER.DN_TOTALAMT AS TOTALAMT, DEBITNOTEMASTER.DN_DISCRS AS DISCAMT, DEBITNOTEMASTER.DN_COMMRS AS COMMAMT, DEBITNOTEMASTER.DN_TDSRS AS TDS, DEBITNOTEMASTER.DN_EXTRACHGS AS EXTRACHGS, ISNULL(TAXMASTER.tax_name, '') AS TAXNAME, DEBITNOTEMASTER.DN_TAX AS TAXAMT, ISNULL(ADDTAXMASTER.tax_name, '') AS ADDTAXNAME, DEBITNOTEMASTER.DN_ADDTAX AS ADDTAXAMT, DEBITNOTEMASTER.DN_OTHERCHGS AS OTHERCHGS, DEBITNOTEMASTER.DN_GTOTAL AS GRANDTOTAL, DEBITNOTEMASTER.DN_DP AS DP, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(DEBITNOTEMASTER.DN_SERVCHGS, 0) AS SERVCHGS, ISNULL(DEBITNOTEMASTER.DN_CGSTAMT, 0) AS CGSTAMT, ISNULL(DEBITNOTEMASTER.DN_SGSTAMT, 0) AS SGSTAMT, ISNULL(DEBITNOTEMASTER.DN_IGSTAMT, 0) AS IGSTAMT, ISNULL(DEBITNOTEMASTER.DN_IRNNO, '') AS IRNNO, ISNULL(DEBITNOTEMASTER.DN_ACKNO, '') AS ACKNO, DEBITNOTEMASTER.DN_ACKDATE AS ACKDATE, DEBITNOTEMASTER.DN_QRCODE AS QRCODE, ISNULL(DEBITNOTEMASTER.DN_GSTR1,0) AS GSTR1 ", "", " DEBITNOTEMASTER INNER JOIN REGISTERMASTER ON DEBITNOTEMASTER.DN_registerid = REGISTERMASTER.register_id AND DEBITNOTEMASTER.DN_cmpid = REGISTERMASTER.register_cmpid AND DEBITNOTEMASTER.DN_locationid = REGISTERMASTER.register_locationid AND DEBITNOTEMASTER.DN_yearid = REGISTERMASTER.register_yearid INNER JOIN LEDGERS ON DEBITNOTEMASTER.DN_LEDGERID = LEDGERS.Acc_id AND DEBITNOTEMASTER.DN_cmpid = LEDGERS.Acc_cmpid AND DEBITNOTEMASTER.DN_locationid = LEDGERS.Acc_locationid AND DEBITNOTEMASTER.DN_yearid = LEDGERS.Acc_yearid LEFT OUTER JOIN HOTELMASTER ON DEBITNOTEMASTER.DN_yearid = HOTELMASTER.HOTEL_YEARID AND DEBITNOTEMASTER.DN_locationid = HOTELMASTER.HOTEL_LOCATIONID AND DEBITNOTEMASTER.DN_cmpid = HOTELMASTER.HOTEL_CMPID AND DEBITNOTEMASTER.DN_HOTELID = HOTELMASTER.HOTEL_ID LEFT OUTER JOIN GUESTMASTER ON DEBITNOTEMASTER.DN_yearid = GUESTMASTER.GUEST_YEARID AND DEBITNOTEMASTER.DN_locationid = GUESTMASTER.GUEST_LOCATIONID AND DEBITNOTEMASTER.DN_cmpid = GUESTMASTER.GUEST_CMPID AND DEBITNOTEMASTER.DN_GUESTID = GUESTMASTER.GUEST_ID LEFT OUTER JOIN TAXMASTER AS ADDTAXMASTER ON DEBITNOTEMASTER.DN_ADDTAXID = ADDTAXMASTER.tax_id LEFT OUTER JOIN TAXMASTER AS TAXMASTER ON DEBITNOTEMASTER.DN_TAXID = TAXMASTER.tax_id ", tempcondition & " AND DEBITNOTEMASTER.DN_YEARID = " & YearId & " order by dbo.DEBITNOTEMASTER.DN_NO")
            If DT.Rows.Count > 0 Then
                griddetails.DataSource = DT
                gridDN.FocusedRowHandle = gridDN.RowCount - 1
                gridDN.TopRowIndex = gridDN.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal billno As Integer)
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If (editval = False) Or (editval = True And gridDN.RowCount > 0) Then
                Dim objDN As New DebitNote
                objDN.MdiParent = MDIMain
                objDN.edit = editval
                objDN.TEMPDNNO = billno
                objDN.TEMPREGNAME = cmbregister.Text.Trim
                objDN.Show()
                'Me.Close()
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

    Private Sub gridjournal_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridDN.DoubleClick
        Try
            showform(True, gridDN.GetFocusedRowCellValue("GSRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.GotFocus
        Try
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'DEBITNOTE'")

            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'DEBITNOTE' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
            If dt.Rows.Count > 0 Then
                cmbregister.Text = dt.Rows(0).Item(0).ToString
            End If

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
                dt = clscommon.search(" register_id ", "", " RegisterMaster ", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'DEBITNOTE' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
                If dt.Rows.Count > 0 Then
                    JVREGID = dt.Rows(0).Item(0)
                    fillgrid(" and REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' ")
                Else
                    MsgBox("Register Not Present, Add New from Master Module")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DEBITNoteDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.N) Or (e.Alt = True And e.KeyCode = Windows.Forms.Keys.A) Then       'for AddNew 
                showform(False, 0)
            ElseIf e.KeyCode = Keys.E And e.Alt = True Then
                CMDOK_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DEBITNoteDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'DEBIT NOTE'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            showform(True, gridDN.GetFocusedRowCellValue("GSRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLCOPY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim IntResult As Integer
        'Dim alParaval As New ArrayList
        'Dim TEMPMSG As Integer
        'TEMPMSG = MsgBox("Wish to Copy JOURNAL No " & GRIDDN.GetFocusedRowCellValue("Sr. No"), MsgBoxStyle.YesNo)
        'If TEMPMSG = vbYes Then
        '    alParaval.Add(GRIDDN.GetFocusedRowCellValue("Sr. No"))
        '    alParaval.Add(cmbregister.Text.Trim)
        '    alParaval.Add(CmpId)

        '    Dim objclsjournalmaster As New ClsJournalMaster()
        '    objclsjournalmaster.alParaval = alParaval


        '    If USERADD = False Then
        '        MsgBox("Insufficient Rights")
        '        Exit Sub
        '    End If
        '    IntResult = objclsjournalmaster.COPY()
        '    MessageBox.Show("Details Copied")
        '    cmbregister.Text = UCase(cmbregister.Text)
        '    Dim clscommon As New ClsCommon
        '    Dim dt As DataTable
        '    dt = clscommon.search(" register_id ", "", " RegisterMaster ", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'JOURNAL' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
        '    If dt.Rows.Count > 0 Then
        '        JVREGID = dt.Rows(0).Item(0)
        '        fillgrid(" and dbo.JOURNALMASTER.JOURNAL_cmpid=" & CmpId & " and dbo.JOURNALMASTER.JOURNAL_LOCATIONid=" & Locationid & " and dbo.JOURNALMASTER.JOURNAL_YEARid=" & YearId & " AND JOURNALMASTER.JOURNAL_registerid = " & JVREGID & "  AND DBO.JOURNALMASTER.JOURNAL_DEBIT = 0 ")
        '    End If
        'End If

    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Debit Note Register.XLS"

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

            opti.SheetName = "Debit Note Register"
            gridDN.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Debit Note Register", gridDN.VisibleColumns.Count + gridDN.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DebitNoteDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        'If ClientName = "TOPCOMM" Then Me.Close()
        If ClientName = "GLOBAL" Then
            GGSTIN.Visible = False
            GCGSTAMT.Visible = False
            GSGSTAMT.Visible = False
            GIGSTAMT.Visible = False

        End If
    End Sub
End Class