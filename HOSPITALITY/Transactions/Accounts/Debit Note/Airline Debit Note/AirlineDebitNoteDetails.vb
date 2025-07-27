Imports BL

Public Class AirlineDebitNoteDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim JVREGID As Integer

    Sub fillgrid(ByVal tempcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            ' dt = objclsCMST.search(" AIRDEBITNOTEMASTER.AIRDN_no AS GSRNO, AIRDEBITNOTEMASTER.AIRDN_date AS DATE, AIRDN_BILLNO AS BILLNO, AIRDEBITNOTEMASTER.AIRDN_CUSTOMER AS CUSTOMER, FLIGHTMASTER.FLIGHT_NAME AS AIRLINE, LEDGERS.Acc_cmpname AS NAME, AIRDEBITNOTEMASTER.AIRDN_PNRNO AS PNR, AIRDEBITNOTEMASTER.AIRDN_AIRPNR AS AIRPNR, AIRDEBITNOTEMASTER.AIRDN_CRSPNR AS CRSPNR, AIRDEBITNOTEMASTER.AIRDN_REFNO AS REFNO, AIRDEBITNOTEMASTER.AIRDN_TOTALAMT AS TOTALAMT, AIRDEBITNOTEMASTER.AIRDN_DISCRS AS DISCAMT, AIRDEBITNOTEMASTER.AIRDN_TDSrs AS TDS, AIRDEBITNOTEMASTER.AIRDN_ADDDISC AS ADDDISCAMT, ISNULL(TAXMASTER.tax_name, '') AS TAXNAME, AIRDEBITNOTEMASTER.AIRDN_TAX AS TAXAMT, AIRDEBITNOTEMASTER.AIRDN_OTHERCHGS AS OTHERCHGS, AIRDEBITNOTEMASTER.AIRDN_CANCEL AS CANCELAMT, AIRDEBITNOTEMASTER.AIRDN_GTOTAL AS GRANDTOTAL ", "", "  AIRDEBITNOTEMASTER INNER JOIN REGISTERMASTER ON AIRDEBITNOTEMASTER.AIRDN_registerid = REGISTERMASTER.register_id AND AIRDEBITNOTEMASTER.AIRDN_cmpid = REGISTERMASTER.register_cmpid AND AIRDEBITNOTEMASTER.AIRDN_locationid = REGISTERMASTER.register_locationid AND AIRDEBITNOTEMASTER.AIRDN_yearid = REGISTERMASTER.register_yearid INNER JOIN LEDGERS ON AIRDEBITNOTEMASTER.AIRDN_LEDGERID = LEDGERS.Acc_id AND AIRDEBITNOTEMASTER.AIRDN_cmpid = LEDGERS.Acc_cmpid AND AIRDEBITNOTEMASTER.AIRDN_locationid = LEDGERS.Acc_locationid AND AIRDEBITNOTEMASTER.AIRDN_yearid = LEDGERS.Acc_yearid LEFT OUTER JOIN FLIGHTMASTER ON AIRDEBITNOTEMASTER.AIRDN_yearid = FLIGHTMASTER.FLIGHT_YEARID AND AIRDEBITNOTEMASTER.AIRDN_locationid = FLIGHTMASTER.FLIGHT_LOCATIONID AND AIRDEBITNOTEMASTER.AIRDN_cmpid = FLIGHTMASTER.FLIGHT_CMPID AND AIRDEBITNOTEMASTER.AIRDN_AIRLINEID = FLIGHTMASTER.FLIGHT_ID LEFT OUTER JOIN TAXMASTER ON AIRDEBITNOTEMASTER.AIRDN_TAXID = TAXMASTER.tax_id ", tempcondition & " AND AIRDN_YEARID = " & YearId & " order by dbo.AIRDEBITNOTEMASTER.AIRDN_NO")
            dt = objclsCMST.search("   AIRDEBITNOTEMASTER.AIRDN_no AS GSRNO, AIRDEBITNOTEMASTER.AIRDN_date AS DATE, AIRDEBITNOTEMASTER.AIRDN_BILLNO AS BILLNO, AIRDEBITNOTEMASTER.AIRDN_CUSTOMER AS CUSTOMER, FLIGHTMASTER.FLIGHT_NAME AS AIRLINE, LEDGERS.Acc_cmpname AS NAME, AIRDEBITNOTEMASTER.AIRDN_PNRNO AS PNR, AIRDEBITNOTEMASTER.AIRDN_AIRPNR AS AIRPNR, AIRDEBITNOTEMASTER.AIRDN_CRSPNR AS CRSPNR, AIRDEBITNOTEMASTER.AIRDN_REFNO AS REFNO, AIRDEBITNOTEMASTER.AIRDN_TOTALAMT AS TOTALAMT, AIRDEBITNOTEMASTER.AIRDN_DISCRS AS DISCAMT, AIRDEBITNOTEMASTER.AIRDN_TDSrs AS TDS, AIRDEBITNOTEMASTER.AIRDN_ADDDISC AS ADDDISCAMT, ISNULL(TAXMASTER.tax_name, '') AS TAXNAME, AIRDEBITNOTEMASTER.AIRDN_TAX AS TAXAMT, AIRDEBITNOTEMASTER.AIRDN_OTHERCHGS AS OTHERCHGS, AIRDEBITNOTEMASTER.AIRDN_CANCEL AS CANCELAMT, AIRDEBITNOTEMASTER.AIRDN_GTOTAL AS GRANDTOTAL, ISNULL(STATEMASTER.state_name, '') AS STATENAME, ISNULL(CAST(STATEMASTER.state_remark AS VARCHAR), '') AS STATECODE, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(AIRDEBITNOTEMASTER.AIRDN_CGSTPER, 0) AS CGSTPER, ISNULL(AIRDEBITNOTEMASTER.AIRDN_CGSTAMT, 0) AS CGSTAMT, ISNULL(AIRDEBITNOTEMASTER.AIRDN_SGSTPER, 0) AS SGSTPER, ISNULL(AIRDEBITNOTEMASTER.AIRDN_SGSTAMT, 0) AS SGSTAMT, ISNULL(AIRDEBITNOTEMASTER.AIRDN_IGSTPER, 0) AS IGSTPER, ISNULL(AIRDEBITNOTEMASTER.AIRDN_IGSTAMT, 0) AS IGSTAMT, ISNULL(purLEDGERS.Acc_cmpname, '') AS PURNAME, ISNULL(purLEDGERS.ACC_GSTIN, '') AS PURGSTIN, ISNULL(CAST(PURSTATEMASTER.state_remark AS VARCHAR(15)), '') AS PURSTATECODE, AIRDEBITNOTEMASTER.AIRDN_SERVCHGS AS SERVCHGS, ISNULL(AIRDEBITNOTEMASTER.AIRDN_IRNNO, '') AS IRNNO, ISNULL(AIRDEBITNOTEMASTER.AIRDN_ACKNO, '') AS ACKNO, AIRDEBITNOTEMASTER.AIRDN_ACKDATE AS ACKDATE, AIRDEBITNOTEMASTER.AIRDN_QRCODE AS QRCODE ", "", " AIRDEBITNOTEMASTER INNER JOIN REGISTERMASTER ON AIRDEBITNOTEMASTER.AIRDN_registerid = REGISTERMASTER.register_id AND AIRDEBITNOTEMASTER.AIRDN_cmpid = REGISTERMASTER.register_cmpid AND AIRDEBITNOTEMASTER.AIRDN_locationid = REGISTERMASTER.register_locationid AND AIRDEBITNOTEMASTER.AIRDN_yearid = REGISTERMASTER.register_yearid INNER JOIN LEDGERS ON AIRDEBITNOTEMASTER.AIRDN_LEDGERID = LEDGERS.Acc_id AND AIRDEBITNOTEMASTER.AIRDN_cmpid = LEDGERS.Acc_cmpid AND AIRDEBITNOTEMASTER.AIRDN_locationid = LEDGERS.Acc_locationid AND AIRDEBITNOTEMASTER.AIRDN_yearid = LEDGERS.Acc_yearid INNER JOIN LEDGERS AS purLEDGERS ON AIRDEBITNOTEMASTER.AIRDN_PURLEDGERID = purLEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER AS PURSTATEMASTER ON purLEDGERS.Acc_stateid = PURSTATEMASTER.state_id LEFT OUTER JOIN HSNMASTER ON AIRDEBITNOTEMASTER.AIRDN_HSNCODEID = HSNMASTER.HSN_ID LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN FLIGHTMASTER ON AIRDEBITNOTEMASTER.AIRDN_yearid = FLIGHTMASTER.FLIGHT_YEARID AND AIRDEBITNOTEMASTER.AIRDN_locationid = FLIGHTMASTER.FLIGHT_LOCATIONID AND AIRDEBITNOTEMASTER.AIRDN_cmpid = FLIGHTMASTER.FLIGHT_CMPID AND AIRDEBITNOTEMASTER.AIRDN_AIRLINEID = FLIGHTMASTER.FLIGHT_ID LEFT OUTER JOIN TAXMASTER ON AIRDEBITNOTEMASTER.AIRDN_TAXID = TAXMASTER.tax_id ", tempcondition & " AND AIRDN_YEARID = " & YearId & " order by dbo.AIRDEBITNOTEMASTER.AIRDN_NO")
            griddetails.DataSource = dt
            If dt.Rows.Count > 0 Then
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
                Dim objDN As New AirlineDebitNote
                objDN.MdiParent = MDIMain
                objDN.edit = editval
                objDN.TEMPDNNO = billno
                objDN.TEMPREGNAME = cmbregister.Text.Trim
                objDN.Show()
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


            Dim PERIOD As String = ""
            PERIOD = AccFrom & " - " & AccTo

            opti.SheetName = "Debit Note Register"
            gridDN.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Debit Note Register", gridDN.VisibleColumns.Count + gridDN.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridDN_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridDN.DoubleClick
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
                    cmbregister.Text = "AIRLINE DEBITNOTE"
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

    Private Sub AirlineDebitNoteDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub AirlineDebitNoteDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'DEBIT NOTE'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'DEBITNOTE'")
            cmbregister.Text = "AIRLINE DEBITNOTE"
            fillgrid(" and REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub CMDOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            showform(True, gridDN.GetFocusedRowCellValue("GSRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AirlineDebitNoteDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        'If ClientName = "TOPCOMM" Or ClientName = "ELYSIUM" Then Me.Close()
        If ClientName = "ELYSIUM" Then Me.Close()
        If ClientName = "GLOBAL" Then
            GGSTIN.Visible = False
            GSTATECODE.Visible = False
            GSTATENAME.Visible = False
            GHSNCODE.Visible = False
            GPURGSTIN.Visible = False
            GPURSTATECODE.Visible = False
            GCGSTPER.Visible = False
            GCGSTAMT.Visible = False
            GSGSTPER.Visible = False
            GSGSTAMT.Visible = False
            GIGSTAMT.Visible = False
            GIGSTPER.Visible = False

        End If
    End Sub
End Class