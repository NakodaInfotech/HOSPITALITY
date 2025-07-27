
Imports BL
Imports DevExpress.XtraGrid.Views.Grid
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class MiscPurDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim REGID As Integer

    Private Sub MiscPurDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub MiscPurDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'MISC PURCHASE'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.GotFocus
        Try
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'PURCHASE' and register_name not in ('AIRLINE PURCHASE REGISTER', 'INTAIRLINE PURCHASE REGISTER', 'INTERNATIONAL PURCHASE REGISTER','RAILWAY PURCHASE REGISTER', 'PACKAGE PURCHASE REGISTER', 'PURCHASE REGISTER', 'TRANSFER PURCHASE REGISTER','VEHICLE PURCHASE REGISTER')")
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
                dt = clscommon.search(" register_abbr, register_initials, register_id ", "", " RegisterMaster ", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'PURCHASE' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
                If dt.Rows.Count > 0 Then
                    REGID = dt.Rows(0).Item(2)
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

    Sub fillgrid(ByVal tempcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" MISCPURMASTER.BOOKING_REFNO AS REFNO, MISCPURMASTER.BOOKING_PURBILLINITIALS AS BILLINITIALS, LEDGERS.Acc_cmpname AS ACCNAME, USERMASTER.User_Name AS USERNAME, MISCPURMASTER.BOOKING_NO AS BOOKINGNO, MISCPURMASTER.BOOKING_DATE AS BOOKINGDATE, MISCPURMASTER.BOOKING_FINALPURAMT AS TOTALAMT, MISCPURMASTER.BOOKING_DISCRECDRS AS DISCAMT, MISCPURMASTER.BOOKING_COMMRECDRS AS COMMAMT, MISCPURMASTER.BOOKING_PURTDSRS AS TDSAMT, MISCPURMASTER.BOOKING_PURSUBTOTAL AS SUBTOTAL, ISNULL(TAXMASTER.tax_name, '') AS TAXNAME, MISCPURMASTER.BOOKING_PURTAX AS TAXAMT, MISCPURMASTER.BOOKING_PUROTHERCHGS AS OTHERCHGS, MISCPURMASTER.BOOKING_PURGRANDTOTAL AS GRANDTOTAL, MISCPURMASTER.BOOKING_PURBALANCE AS BALANCE, MISCPURMASTER.BOOKING_DISPUTE AS DISPUTED, MISCPURMASTER.BOOKING_BILLCHECKED AS BILLCHECKED, MISCPURMASTER.BOOKING_CANCELLED AS CANCELLED, USERMASTER_1.User_Name AS MODIFIEDBY, MISCPURMASTER.BOOKING_CGSTAMT AS PURCGSTAMT, MISCPURMASTER.BOOKING_SGSTAMT AS PURSGSTAMT, MISCPURMASTER.BOOKING_IGSTAMT AS PURIGSTAMT, ISNULL(LEDGERS.Acc_GSTIN, '') AS PURGSTIN, ISNULL(STATEMASTER.state_name, '') AS STATENAME, ISNULL(CAST(STATEMASTER.state_remark AS VARCHAR), '') AS STATECODE, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(MISCPURMASTER.BOOKING_TAXSERVCHGSAMT, 0) AS SERVICECHGS, ISNULL(MISCPURMASTER.BOOKING_PURROUNDOFF, 0) AS ROUNDOFF, ISNULL(otherchgsLEDGERs.Acc_cmpname, '') AS OTHERCHGSNAME, ISNULL(MISCPURMASTER.BOOKING_TAXSERVCHGS, 0) AS TAXSERVCHGS, ISNULL(MISCPURMASTER.BOOKING_BOOKINGDESC, '') AS NOTES, ISNULL(GROUPDEPARTURE.GROUPDEP_NAME, '') AS TOURNAME ", "", " MISCPURMASTER INNER JOIN REGISTERMASTER ON REGISTERMASTER.register_id = MISCPURMASTER.BOOKING_PURCHASEREGISTERID INNER JOIN LEDGERS ON LEDGERS.Acc_id = MISCPURMASTER.BOOKING_PURLEDGERID INNER JOIN USERMASTER ON USERMASTER.User_id = MISCPURMASTER.BOOKING_USERID INNER JOIN USERMASTER AS USERMASTER_1 ON MISCPURMASTER.BOOKING_MODIFIEDBY = USERMASTER_1.User_id LEFT OUTER JOIN GROUPDEPARTURE ON MISCPURMASTER.BOOKING_TOURID = GROUPDEPARTURE.GROUPDEP_NO LEFT OUTER JOIN LEDGERS AS otherchgsLEDGERs ON MISCPURMASTER.BOOKING_PUROTHERCHGSID = otherchgsLEDGERs.Acc_id LEFT OUTER JOIN HSNMASTER ON MISCPURMASTER.BOOKING_HSNCODEID = HSNMASTER.HSN_ID LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN TAXMASTER ON MISCPURMASTER.BOOKING_PURTAXID = TAXMASTER.tax_id ", tempcondition & " AND MISCPURMASTER.BOOKING_YEARID = " & YearId & " ORDER BY MISCPURMASTER.BOOKING_NO")
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
            'If cmbregister.Text.Trim <> "MISC COUPON PURCHASE" Then
            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objPUR As New MiscPur
                objPUR.MdiParent = MDIMain
                objPUR.edit = editval
                objPUR.TEMPBOOKINGNO = BOOKINGNO
                objPUR.TEMPREGNAME = cmbregister.Text.Trim
                objPUR.Show()
                'Me.Close()
            End If
            'Else
            'MsgBox("You cannot Add or Edit coupon purchase from here", MsgBoxStyle.Information)
            'Exit Sub
            'End If
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

    Private Sub TOOLGRIDDETAILS_Click(sender As Object, e As EventArgs) Handles TOOLGRIDDETAILS.Click
        Try
            Dim objgrid As New MiscPurGridDetails
            objgrid.MdiParent = MDIMain
            objgrid.Show()
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

    Private Sub ExcelExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Miscellaneous Purchase.XLS"

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

            opti.SheetName = "Miscellaneous Purchase"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Miscellaneous Purchase " & cmbregister.Text, gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MiscPurDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        'If ClientName = "ELYSIUM" Or ClientName = "TOPCOMM" Or ClientName = "7HOSPITALITY" Then Me.Close()
        If ClientName = "ELYSIUM" Or ClientName = "7HOSPITALITY" Then Me.Close()
        If ClientName = "GLOBAL" Then
            GPURGSTIN.Visible = False
            GSTATECODE.Visible = False
            GSTATENAME.Visible = False
            GHSNCODE.Visible = False
            GCGSTAMT.Visible = False
            GPURSGSTAMT.Visible = False
            GPURIGSTAMT.Visible = False

        End If
    End Sub

End Class