
Imports BL

Public Class AirlineCreditNoteDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim JVREGID As Integer

    Sub fillgrid(ByVal tempcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            ' dt = objclsCMST.search(" AIRCREDITNOTEMASTER.AIRCN_no AS GSRNO, AIRCREDITNOTEMASTER.AIRCN_date AS DATE, AIRCN_BILLNO AS BILLNO, AIRCREDITNOTEMASTER.AIRCN_PNRNO AS PNRNO, AIRCREDITNOTEMASTER.AIRCN_AIRPNR AS AIRPNR, AIRCREDITNOTEMASTER.AIRCN_CRSPNR AS CRSPNR, AIRCREDITNOTEMASTER.AIRCN_REFNO AS REFNO, AIRCREDITNOTEMASTER.AIRCN_CUSTOMER AS CUSTOMER, FLIGHTMASTER.FLIGHT_NAME AS AIRLINE, LEDGERS.Acc_cmpname AS NAME, AIRCREDITNOTEMASTER.AIRCN_TOTALAMT AS TOTALAMT, AIRCREDITNOTEMASTER.AIRCN_DISCRS AS DISCAMT, AIRCREDITNOTEMASTER.AIRCN_ADDDISC AS ADDDISCAMT, ISNULL(TAXMASTER.tax_name, '') AS TAXNAME, AIRCREDITNOTEMASTER.AIRCN_TAX AS TAXAMT, AIRCREDITNOTEMASTER.AIRCN_OTHERCHGS AS OTHERCHGS, AIRCREDITNOTEMASTER.AIRCN_CANCEL AS CANCELAMT, AIRCREDITNOTEMASTER.AIRCN_GTOTAL AS GRANDTOTAL", "", "  AIRCREDITNOTEMASTER INNER JOIN REGISTERMASTER ON AIRCREDITNOTEMASTER.AIRCN_registerid = REGISTERMASTER.register_id AND AIRCREDITNOTEMASTER.AIRCN_cmpid = REGISTERMASTER.register_cmpid AND AIRCREDITNOTEMASTER.AIRCN_locationid = REGISTERMASTER.register_locationid AND AIRCREDITNOTEMASTER.AIRCN_yearid = REGISTERMASTER.register_yearid INNER JOIN LEDGERS ON AIRCREDITNOTEMASTER.AIRCN_LEDGERID = LEDGERS.Acc_id AND AIRCREDITNOTEMASTER.AIRCN_cmpid = LEDGERS.Acc_cmpid AND AIRCREDITNOTEMASTER.AIRCN_locationid = LEDGERS.Acc_locationid AND AIRCREDITNOTEMASTER.AIRCN_yearid = LEDGERS.Acc_yearid LEFT OUTER JOIN FLIGHTMASTER ON AIRCREDITNOTEMASTER.AIRCN_yearid = FLIGHTMASTER.FLIGHT_YEARID AND AIRCREDITNOTEMASTER.AIRCN_locationid = FLIGHTMASTER.FLIGHT_LOCATIONID AND AIRCREDITNOTEMASTER.AIRCN_cmpid = FLIGHTMASTER.FLIGHT_CMPID AND AIRCREDITNOTEMASTER.AIRCN_AIRLINEID = FLIGHTMASTER.FLIGHT_ID LEFT OUTER JOIN TAXMASTER ON AIRCREDITNOTEMASTER.AIRCN_TAXID = TAXMASTER.tax_id", tempcondition & " AND AIRCN_YEARID = " & YearId & " order by dbo.AIRCREDITNOTEMASTER.AIRCN_NO")
            dt = objclsCMST.search(" AIRCREDITNOTEMASTER.AIRCN_no AS GSRNO, AIRCREDITNOTEMASTER.AIRCN_date AS DATE, AIRCREDITNOTEMASTER.AIRCN_BILLNO AS BILLNO, AIRCREDITNOTEMASTER.AIRCN_PNRNO AS PNRNO, AIRCREDITNOTEMASTER.AIRCN_AIRPNR AS AIRPNR, AIRCREDITNOTEMASTER.AIRCN_CRSPNR AS CRSPNR, AIRCREDITNOTEMASTER.AIRCN_REFNO AS REFNO, AIRCREDITNOTEMASTER.AIRCN_CUSTOMER AS CUSTOMER, FLIGHTMASTER.FLIGHT_NAME AS AIRLINE, LEDGERS.Acc_cmpname AS NAME, AIRCREDITNOTEMASTER.AIRCN_TOTALAMT AS TOTALAMT, AIRCREDITNOTEMASTER.AIRCN_DISCRS AS DISCAMT, AIRCREDITNOTEMASTER.AIRCN_ADDDISC AS ADDDISCAMT, ISNULL(TAXMASTER.tax_name, '') AS TAXNAME, AIRCREDITNOTEMASTER.AIRCN_TAX AS TAXAMT, AIRCREDITNOTEMASTER.AIRCN_OTHERCHGS AS OTHERCHGS, AIRCREDITNOTEMASTER.AIRCN_EXTRACHGS AS SERVCHGS, AIRCREDITNOTEMASTER.AIRCN_CANCEL AS CANCELAMT, AIRCREDITNOTEMASTER.AIRCN_GTOTAL AS GRANDTOTAL, ISNULL(STATEMASTER.state_name, '') AS STATENAME, ISNULL(CAST(STATEMASTER.state_remark AS VARCHAR), '') AS STATECODE, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(AIRCREDITNOTEMASTER.AIRCN_CGSTPER, 0) AS CGSTPER, ISNULL(AIRCREDITNOTEMASTER.AIRCN_CGSTAMT, 0) AS CGSTAMT, ISNULL(AIRCREDITNOTEMASTER.AIRCN_SGSTPER, 0) AS SGSTPER, ISNULL(AIRCREDITNOTEMASTER.AIRCN_SGSTAMT, 0) AS SGSTAMT, ISNULL(AIRCREDITNOTEMASTER.AIRCN_IGSTPER, 0) AS IGSTPER, ISNULL(AIRCREDITNOTEMASTER.AIRCN_IGSTAMT, 0) AS IGSTAMT, ISNULL(AIRCREDITNOTEMASTER.AIRCN_IRNNO, '') AS IRNNO, ISNULL(AIRCREDITNOTEMASTER.AIRCN_ACKNO, '') AS ACKNO, AIRCREDITNOTEMASTER.AIRCN_ACKDATE AS ACKDATE, AIRCREDITNOTEMASTER.AIRCN_QRCODE AS QRCODE", "", " AIRCREDITNOTEMASTER INNER JOIN REGISTERMASTER ON AIRCREDITNOTEMASTER.AIRCN_registerid = REGISTERMASTER.register_id AND AIRCREDITNOTEMASTER.AIRCN_cmpid = REGISTERMASTER.register_cmpid AND AIRCREDITNOTEMASTER.AIRCN_locationid = REGISTERMASTER.register_locationid AND AIRCREDITNOTEMASTER.AIRCN_yearid = REGISTERMASTER.register_yearid INNER JOIN LEDGERS ON AIRCREDITNOTEMASTER.AIRCN_LEDGERID = LEDGERS.Acc_id AND AIRCREDITNOTEMASTER.AIRCN_cmpid = LEDGERS.Acc_cmpid AND  AIRCREDITNOTEMASTER.AIRCN_locationid = LEDGERS.Acc_locationid AND AIRCREDITNOTEMASTER.AIRCN_yearid = LEDGERS.Acc_yearid LEFT OUTER JOIN HSNMASTER ON AIRCREDITNOTEMASTER.AIRCN_HSNCODEID = HSNMASTER.HSN_ID LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN FLIGHTMASTER ON AIRCREDITNOTEMASTER.AIRCN_yearid = FLIGHTMASTER.FLIGHT_YEARID AND AIRCREDITNOTEMASTER.AIRCN_locationid = FLIGHTMASTER.FLIGHT_LOCATIONID AND AIRCREDITNOTEMASTER.AIRCN_cmpid = FLIGHTMASTER.FLIGHT_CMPID AND AIRCREDITNOTEMASTER.AIRCN_AIRLINEID = FLIGHTMASTER.FLIGHT_ID LEFT OUTER JOIN TAXMASTER ON AIRCREDITNOTEMASTER.AIRCN_TAXID = TAXMASTER.tax_id", tempcondition & " AND AIRCN_YEARID = " & YearId & " order by dbo.AIRCREDITNOTEMASTER.AIRCN_NO")
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
                Dim objCN As New AirlineCreditNote
                objCN.MdiParent = MDIMain
                objCN.edit = editval
                objCN.TEMPCNNO = billno
                objCN.TEMPREGNAME = cmbregister.Text.Trim
                objCN.Show()
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
                    cmbregister.Text = "AIRLINE CREDITNOTE"
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

    Private Sub AirlineCreditNoteDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.N) Or (e.Alt = True And e.KeyCode = Windows.Forms.Keys.A) Then       'for AddNew 
                showform(False, 0)
                'ElseIf e.KeyCode = Keys.P And e.Alt = True Then
                '    Call PrintToolStripButton_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AirlineCreditNoteDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'CREDIT NOTE'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'CREDITNOTE'")
            cmbregister.Text = "AIRLINE CREDITNOTE"
            fillgrid(" and REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' ")
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

    Private Sub AirlineCreditNoteDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        '       If ClientName = "TOPCOMM" Or ClientName = "ELYSIUM" Then Me.Close()
        If ClientName = "ELYSIUM" Then Me.Close()
        If ClientName = "GLOBAL" Then
            GGSTIN.Visible = False
            GSTATENAME.Visible = False
            GSTATECODE.Visible = False
            GHSNCODE.Visible = False
            GCGSTPER.Visible = False
            GCGSTAMT.Visible = False
            GSGSTPER.Visible = False
            GSGSTAMT.Visible = False
            GIGSTPER.Visible = False
            GIGSTAMT.Visible = False
        End If
    End Sub
End Class