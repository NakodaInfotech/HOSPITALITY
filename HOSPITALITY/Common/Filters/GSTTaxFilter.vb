
Imports BL

Public Class GSTTaxFilter

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GSTTaxFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.OemQuotes Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try
            Dim WHERECLAUSE As String = " AND YEARID = " & YearId
            If CMBNAME.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND LEDGERNAME = '" & CMBNAME.Text.Trim & "'"
            If CMBSTATE.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND STATENAME = '" & CMBSTATE.Text.Trim & "'"

            If RBGSTSALEDETAILS.Checked = True Then
                Dim OBJRPT As New GSTSaleReport
                OBJRPT.MdiParent = MDIMain
                If chkdate.CheckState = CheckState.Checked Then
                    WHERECLAUSE = WHERECLAUSE & " AND BOOKINGDATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND BOOKINGDATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"
                    OBJRPT.FROMDATE = dtfrom.Value.Date
                    OBJRPT.TODATE = dtto.Value.Date
                Else
                    OBJRPT.FROMDATE = AccFrom
                    OBJRPT.TODATE = AccFrom
                End If
                OBJRPT.WHERECLAUSE = WHERECLAUSE & " AND SALEPUR = 'SALE' "
                OBJRPT.Show()

            ElseIf RBGSTPURCHASEDETAILS.Checked = True Then
                Dim OBJRPT As New GSTPurchaseReport
                OBJRPT.MdiParent = MDIMain
                If chkdate.CheckState = CheckState.Checked Then
                    WHERECLAUSE = WHERECLAUSE & " AND BOOKINGDATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND BOOKINGDATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"
                    OBJRPT.FROMDATE = dtfrom.Value.Date
                    OBJRPT.TODATE = dtto.Value.Date
                Else
                    OBJRPT.FROMDATE = AccFrom
                    OBJRPT.TODATE = AccFrom
                End If
                OBJRPT.WHERECLAUSE = WHERECLAUSE & " AND SALEPUR = 'PUR' "
                OBJRPT.Show()

            ElseIf RBGSTPARTYSALESUMM.Checked = True Or RBGSTPARTYPURSUMM.Checked = True Then
                Dim OBJRPT As New GSTPartyWiseSumm
                OBJRPT.MdiParent = MDIMain
                If chkdate.CheckState = CheckState.Checked Then
                    WHERECLAUSE = WHERECLAUSE & " AND BOOKINGDATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND BOOKINGDATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"
                    OBJRPT.FROMDATE = dtfrom.Value.Date
                    OBJRPT.TODATE = dtto.Value.Date
                Else
                    OBJRPT.FROMDATE = AccFrom
                    OBJRPT.TODATE = AccFrom
                End If
                If RBGSTPARTYSALESUMM.Checked = True Then OBJRPT.WHERECLAUSE = WHERECLAUSE & " AND SALEPUR = 'SALE' " Else OBJRPT.WHERECLAUSE = WHERECLAUSE & " AND SALEPUR = 'PUR' "
                OBJRPT.Show()

            ElseIf RBGSTSTATESALESUMM.Checked = True Or RBGSTSTATEPURSUMM.Checked = True Then
                Dim OBJRPT As New GSTStateWiseSumm
                OBJRPT.MdiParent = MDIMain
                If chkdate.CheckState = CheckState.Checked Then
                    WHERECLAUSE = WHERECLAUSE & " AND BOOKINGDATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND BOOKINGDATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"
                    OBJRPT.FROMDATE = dtfrom.Value.Date
                    OBJRPT.TODATE = dtto.Value.Date
                Else
                    OBJRPT.FROMDATE = AccFrom
                    OBJRPT.TODATE = AccFrom
                End If
                If RBGSTSTATESALESUMM.Checked = True Then OBJRPT.WHERECLAUSE = WHERECLAUSE & " AND SALEPUR = 'SALE' " Else OBJRPT.WHERECLAUSE = WHERECLAUSE & " AND SALEPUR = 'PUR' "
                OBJRPT.Show()

            ElseIf RBGSTHSNSALESUMM.Checked = True Or RBGSTHSNPURSUMM.Checked = True Then
                Dim OBJRPT As New GSTHSNWiseSummary
                OBJRPT.MdiParent = MDIMain
                If chkdate.CheckState = CheckState.Checked Then
                    WHERECLAUSE = WHERECLAUSE & " AND BOOKINGDATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND BOOKINGDATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"
                    OBJRPT.FROMDATE = dtfrom.Value.Date
                    OBJRPT.TODATE = dtto.Value.Date
                Else
                    OBJRPT.FROMDATE = AccFrom
                    OBJRPT.TODATE = AccFrom
                End If
                If RBGSTHSNSALESUMM.Checked = True Then OBJRPT.WHERECLAUSE = WHERECLAUSE & " AND SALEPUR = 'SALE' " Else OBJRPT.WHERECLAUSE = WHERECLAUSE & " AND SALEPUR = 'PUR' "
                OBJRPT.Show()

            ElseIf RBGSTCNDETAILS.Checked = True Or RBGSTDNDETAILS.Checked = True Then
                Dim OBJRPT As New GSTCNDNDetailsReport
                OBJRPT.MdiParent = MDIMain
                If chkdate.CheckState = CheckState.Checked Then
                    WHERECLAUSE = WHERECLAUSE & " AND DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"
                    OBJRPT.FROMDATE = dtfrom.Value.Date
                    OBJRPT.TODATE = dtto.Value.Date
                Else
                    OBJRPT.FROMDATE = AccFrom
                    OBJRPT.TODATE = AccFrom
                End If
                If RBGSTCNDETAILS.Checked = True Then OBJRPT.WHERECLAUSE = WHERECLAUSE & " AND CNDN = 'CREDITNOTE' " Else OBJRPT.WHERECLAUSE = WHERECLAUSE & " AND CNDN = 'DEBITNOTE' "
                OBJRPT.Show()

            ElseIf RBGSTHSNCNSUMM.Checked = True Or RBGSTHSNDNSUMM.Checked = True Then
                Dim OBJRPT As New GSTHSNWiseCNDNSummReport
                OBJRPT.MdiParent = MDIMain
                If chkdate.CheckState = CheckState.Checked Then
                    WHERECLAUSE = WHERECLAUSE & " AND DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"
                    OBJRPT.FROMDATE = dtfrom.Value.Date
                    OBJRPT.TODATE = dtto.Value.Date
                Else
                    OBJRPT.FROMDATE = AccFrom
                    OBJRPT.TODATE = AccFrom
                End If
                If RBGSTHSNCNSUMM.Checked = True Then OBJRPT.WHERECLAUSE = WHERECLAUSE & " AND CNDN = 'CREDITNOTE' " Else OBJRPT.WHERECLAUSE = WHERECLAUSE & " AND CNDN = 'DEBITNOTE' "
                OBJRPT.Show()

            ElseIf RBGSTR1.Checked = True Then

                'Dim OBJRPT As New clsReportDesigner("B2B", System.AppDomain.CurrentDomain.BaseDirectory & "B2B.xlsx", 2)
                'Dim OBJRPTB2CL As New clsReportDesigner("B2CL", System.AppDomain.CurrentDomain.BaseDirectory & "B2CL.xlsx", 2)
                'Dim OBJRPTB2CS As New clsReportDesigner("B2CS", System.AppDomain.CurrentDomain.BaseDirectory & "B2CS.xlsx", 2)
                'Dim OBJRPTHSN As New clsReportDesigner("HSN", System.AppDomain.CurrentDomain.BaseDirectory & "HSN.xlsx", 2)
                'If chkdate.CheckState = CheckState.Checked Then
                '    OBJRPT.GSTB2B_EXCEL(CmpId, YearId, dtfrom.Value.Date, dtto.Value.Date, "")
                '    OBJRPTB2CL.GSTB2CL_EXCEL(CmpId, YearId, dtfrom.Value.Date, dtto.Value.Date, "")
                '    OBJRPTB2CS.GSTB2CS_EXCEL(CmpId, YearId, dtfrom.Value.Date, dtto.Value.Date, "")
                '    OBJRPTHSN.GSTHSN_EXCEL(CmpId, YearId, dtfrom.Value.Date, dtto.Value.Date, "")
                'Else
                '    OBJRPT.GSTB2B_EXCEL(CmpId, YearId, AccFrom, AccTo, "")
                '    OBJRPTB2CL.GSTB2CL_EXCEL(CmpId, YearId, AccFrom, AccTo, "")
                '    OBJRPTB2CS.GSTB2CS_EXCEL(CmpId, YearId, AccFrom, AccTo, "")
                '    OBJRPTHSN.GSTHSN_EXCEL(CmpId, YearId, AccFrom, AccTo, "")
                'End If


                'DELETE THE FILE AND RECREATE
                If System.IO.File.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "GSTR1.xlsx") = True Then System.IO.File.Delete(System.AppDomain.CurrentDomain.BaseDirectory & "GSTR1.xlsx")
                Dim OBJRPT As New clsReportDesigner("GSTR1", System.AppDomain.CurrentDomain.BaseDirectory & "GSTR1.xlsx", 2)
                If chkdate.CheckState = CheckState.Checked Then
                    OBJRPT.GSTHSN_EXCEL(CmpId, YearId, dtfrom.Value.Date, dtto.Value.Date, "", "HSN")
                    OBJRPT.GSTCDNUR_EXCEL(CmpId, YearId, dtfrom.Value.Date, dtto.Value.Date, "", "CDNUR")
                    OBJRPT.GSTCDNR_EXCEL(CmpId, YearId, dtfrom.Value.Date, dtto.Value.Date, "", "CDNR")
                    OBJRPT.GSTB2CL_EXCEL(CmpId, YearId, dtfrom.Value.Date, dtto.Value.Date, "", "B2CL")
                    OBJRPT.GSTB2CS_EXCEL(CmpId, YearId, dtfrom.Value.Date, dtto.Value.Date, "", "B2CS")
                    OBJRPT.GSTB2B_EXCEL(CmpId, YearId, dtfrom.Value.Date, dtto.Value.Date, "", "B2B")
                Else
                    OBJRPT.GSTHSN_EXCEL(CmpId, YearId, AccFrom, AccTo, "", "HSN")
                    OBJRPT.GSTCDNUR_EXCEL(CmpId, YearId, AccFrom, AccTo, "", "CDNUR")
                    OBJRPT.GSTCDNR_EXCEL(CmpId, YearId, AccFrom, AccTo, "", "CDNR")
                    OBJRPT.GSTB2CS_EXCEL(CmpId, YearId, AccFrom, AccTo, "", "B2CL")
                    OBJRPT.GSTB2CL_EXCEL(CmpId, YearId, AccFrom, AccTo, "", "B2CS")
                    OBJRPT.GSTB2B_EXCEL(CmpId, YearId, AccFrom, AccTo, "", "B2B")
                End If
                Exit Sub

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, False, " AND (GROUP_SECONDARY = 'SUNDRY DEBTORS' OR GROUP_SECONDARY = 'SUNDRY CREDITORS')")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND (GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS' OR GROUP_SECONDARY = 'SUNDRY CREDITORS')"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBACCCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, cmbacccode, e, Me, txtadd, " AND (GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' OR GROUP_SECONDARY = 'SUNDRY CREDITORS')", "SUNDRY DEBTORS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbstate_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBSTATE.Enter
        Try
            If CMBSTATE.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("state_name", "", "StateMaster", " and state_cmpid = " & CmpId & " and state_Locationid = " & Locationid & " and state_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "state_name"
                    CMBSTATE.DataSource = dt
                    CMBSTATE.DisplayMember = "state_name"
                    CMBSTATE.Text = ""
                End If
                CMBSTATE.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbstate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSTATE.Validating
        Try
            If cmbstate.Text.Trim <> "" Then
                pcase(cmbstate)
                Dim objClsCommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objClsCommon.search("state_name", "", "StateMaster", " and state_name = '" & cmbstate.Text.Trim & "' and state_cmpid = " & CmpId & " and state_locationid = " & Locationid & " and state_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbstate.Text.Trim
                    Dim tempmsg As Integer = MsgBox("State not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        cmbstate.Text = a
                        objyearmaster.savestate(cmbstate.Text.Trim, CmpId, Locationid, Userid, YearId, " and state_name = '" & cmbstate.Text.Trim & "' and state_cmpid = " & CmpId & " and state_locationid = " & Locationid & " and state_yearid = " & YearId)
                        Dim dt1 As New DataTable
                        dt1 = cmbstate.DataSource
                        If cmbstate.DataSource <> Nothing Then
line1:
                            If dt1.Rows.Count > 0 Then
                                dt1.Rows.Add(cmbstate.Text)
                                cmbstate.Text = a
                            End If
                        End If
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

End Class