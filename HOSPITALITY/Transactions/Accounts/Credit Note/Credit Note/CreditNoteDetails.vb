
Imports BL

Public Class CreditNoteDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim JVREGID As Integer

    Sub fillgrid(ByVal tempcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search(" CREDITNOTEMASTER.CN_no AS GSRNO, CREDITNOTEMASTER.CN_date AS GDATE, CREDITNOTEMASTER.CN_BILLNO AS GBILLNO, GUESTMASTER.GUEST_NAME AS GGUESTNAME,HOTELMASTER.HOTEL_NAME AS GHOTELNAME, LEDGERS.Acc_cmpname AS GNAME, CREDITNOTEMASTER.CN_TOTALAMT AS TOTALAMT, CREDITNOTEMASTER.CN_DISCRS AS DISCAMT,CREDITNOTEMASTER.CN_EXTRACHGS AS EXTRACHGS, ISNULL(TAXMASTER.tax_name, '') AS TAXNAME, CREDITNOTEMASTER.CN_TAX AS TAXAMT, CREDITNOTEMASTER.CN_OTHERCHGS AS OTHERCHGS, CREDITNOTEMASTER.CN_GTOTAL AS GRANDTOTAL, CREDITNOTEMASTER.CN_DP AS DP, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(CREDITNOTEMASTER.CN_SERVCHGS, 0) AS SERVCHGS, ISNULL(CREDITNOTEMASTER.CN_CGSTAMT, 0) AS CGSTAMT, ISNULL(CREDITNOTEMASTER.CN_SGSTAMT, 0) AS SGSTAMT, ISNULL(CREDITNOTEMASTER.CN_IGSTAMT, 0) AS IGSTAMT,ISNULL(CREDITNOTEMASTER.CN_IRNNO, '') AS IRNNO, ISNULL(CREDITNOTEMASTER.CN_ACKNO, '') AS ACKNO, CREDITNOTEMASTER.CN_ACKDATE AS ACKDATE, CREDITNOTEMASTER.CN_QRCODE AS QRCODE, ISNULL(CREDITNOTEMASTER.CN_NOGSTR1,0) AS NOGSTR1", "", "  CREDITNOTEMASTER INNER JOIN REGISTERMASTER ON CREDITNOTEMASTER.CN_registerid = REGISTERMASTER.register_id AND CREDITNOTEMASTER.CN_cmpid = REGISTERMASTER.register_cmpid AND  CREDITNOTEMASTER.CN_locationid = REGISTERMASTER.register_locationid AND CREDITNOTEMASTER.CN_yearid = REGISTERMASTER.register_yearid INNER JOIN LEDGERS ON CREDITNOTEMASTER.CN_LEDGERID = LEDGERS.Acc_id AND CREDITNOTEMASTER.CN_cmpid = LEDGERS.Acc_cmpid AND CREDITNOTEMASTER.CN_locationid = LEDGERS.Acc_locationid AND CREDITNOTEMASTER.CN_yearid = LEDGERS.Acc_yearid LEFT OUTER JOIN HOTELMASTER ON CREDITNOTEMASTER.CN_yearid = HOTELMASTER.HOTEL_YEARID AND CREDITNOTEMASTER.CN_locationid = HOTELMASTER.HOTEL_LOCATIONID AND CREDITNOTEMASTER.CN_cmpid = HOTELMASTER.HOTEL_CMPID AND CREDITNOTEMASTER.CN_HOTELID = HOTELMASTER.HOTEL_ID LEFT OUTER JOIN GUESTMASTER ON CREDITNOTEMASTER.CN_yearid = GUESTMASTER.GUEST_YEARID AND CREDITNOTEMASTER.CN_locationid = GUESTMASTER.GUEST_LOCATIONID AND CREDITNOTEMASTER.CN_cmpid = GUESTMASTER.GUEST_CMPID AND CREDITNOTEMASTER.CN_GUESTID = GUESTMASTER.GUEST_ID LEFT OUTER JOIN TAXMASTER ON CREDITNOTEMASTER.CN_TAXID = TAXMASTER.tax_id", " AND CREDITNOTEMASTER.CN_YEARID = " & YearId & tempcondition & " ORDER BY CREDITNOTEMASTER.CN_no")
            griddetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridCN.FocusedRowHandle = gridCN.RowCount - 1
                gridCN.TopRowIndex = gridCN.RowCount - 15
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
            If (editval = False) Or (editval = True And gridCN.RowCount > 0) Then
                Dim objCN As New CREDITNOTE
                objCN.MdiParent = MDIMain
                objCN.edit = editval
                objCN.TEMPCNNO = billno
                objCN.TEMPREGNAME = cmbregister.Text.Trim
                objCN.Show()
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

    Private Sub gridjournal_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridCN.DoubleClick
        Try
            showform(True, gridCN.GetFocusedRowCellValue("GSRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.GotFocus
        Try
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'CREDITNOTE'")

            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'CREDITNOTE' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
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
                dt = clscommon.search(" register_id ", "", " RegisterMaster ", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'CREDITNOTE' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
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

    Private Sub CreditNoteDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.N) Or (e.Alt = True And e.KeyCode = Windows.Forms.Keys.A) Then       'for AddNew 
                showform(False, 0)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CreditNoteDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'CREDIT NOTE'")
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
            showform(True, gridCN.GetFocusedRowCellValue("GSRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Credit Note Register.XLS"

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

            opti.SheetName = "Credit Note Register"
            gridCN.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Credit Note Register", gridCN.VisibleColumns.Count + gridCN.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class