
Imports BL

Public Class ChartFilter

    Sub FILLCMB()
        Try
            If CMBBOOKEDBY.Text.Trim = "" Then FILLBOOKEDBY(CMBBOOKEDBY, False)
            If CMBHOTELNAME.Text.Trim = "" Then fillHOTEL(CMBHOTELNAME)
            If CMBGUESTNAME.Text.Trim = "" Then FILLGUESTNAME(CMBGUESTNAME, False)
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, False, " AND GROUP_SECONDARY = 'SUNDRY DEBTORS'")
            If CMBPURNAME.Text.Trim = "" Then fillname(CMBPURNAME, False, " AND GROUP_SECONDARY = 'SUNDRY CREDITORS'")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ChartFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for SHOW REPORT
                Call cmdshow_Click(sender, e)
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ChartFilter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            FILLCMB()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBOOKEDBY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBBOOKEDBY.Enter
        Try
            If CMBBOOKEDBY.Text.Trim = "" Then FILLBOOKEDBY(CMBBOOKEDBY, False)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBBOOKEDBY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBBOOKEDBY.Validating
        Try
            If CMBBOOKEDBY.Text.Trim <> "" Then BOOKEDBYvalidate(CMBBOOKEDBY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbhotelname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBHOTELNAME.Enter
        Try
            If cmbhotelname.Text.Trim = "" Then fillHOTEL(cmbhotelname)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbhotelname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBHOTELNAME.Validating
        Try
            If CMBHOTELNAME.Text.Trim <> "" Then HOTELvalidate(CMBHOTELNAME, CMBCODE, e, Me, TXTHOTELADD)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbguestname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBGUESTNAME.Enter
        Try
            If CMBGUESTNAME.Text.Trim = "" Then FILLGUESTNAME(CMBGUESTNAME, False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbguestname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGUESTNAME.Validating
        Try
            If CMBGUESTNAME.Text.Trim <> "" Then GUESTNAMEVALIDATE(CMBGUESTNAME, e, Me, TXTHOTELADD)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, False, " AND GROUP_SECONDARY = 'SUNDRY DEBTORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBCODE, e, Me, TXTHOTELADD, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'", "SUNDRY DEBTORS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPURNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPURNAME.Enter
        Try
            If CMBPURNAME.Text.Trim = "" Then fillname(CMBPURNAME, False, " AND GROUP_SECONDARY = 'SUNDRY CREDITORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPURNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPURNAME.Validating
        Try
            If CMBPURNAME.Text.Trim <> "" Then namevalidate(CMBPURNAME, CMBCODE, e, Me, TXTHOTELADD, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try

            If Val(TXTTOP.Text.Trim) = 0 And (RBTOPHOTEL.Checked = True Or RBTOPCITY.Checked = True Or RBTOPBOOKEDBY.Checked = True Or RBTOPAGENT.Checked = True Or RBTOPPUR.Checked = True Or RBTOPGUEST.Checked = True) Then
                MsgBox("Enter Value", MsgBoxStyle.Critical)
                TXTTOP.Focus()
                Exit Sub
            End If

            Dim WHERECLAUSE As String = ""
            Dim FRMSTRING As String = ""

            If CMBHOTELNAME.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND HOTELNAME = '" & CMBHOTELNAME.Text.Trim & "' "
            If CMBCITY.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND CITYNAME = '" & CMBCITY.Text.Trim & "' "
            If CMBBOOKEDBY.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND BOOKEDBY = '" & CMBBOOKEDBY.Text.Trim & "' "
            If CMBNAME.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND SALELEDGER = '" & CMBNAME.Text.Trim & "' "
            If CMBPURNAME.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND PURLEDGER = '" & CMBPURNAME.Text.Trim & "' "
            If CMBGUESTNAME.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND GUESTNAME = '" & CMBGUESTNAME.Text.Trim & "' "

            Dim objclspreq As New ClsCommon()
            Dim dt As New DataTable
            If RBHOTELWISE.Checked = True Then
                dt = objclspreq.search(" HOTELNAME,SUM(RESERVATION_SALEREPORT.SALEAMT ) AS SALEAMT ", "", " RESERVATION_SALEREPORT ", WHERECLAUSE & "  AND CMPID = " & CmpId & " AND locationid = " & Locationid & " AND yearid = " & YearId & " GROUP BY HOTELNAME HAVING  SUM(RESERVATION_SALEREPORT.SALEAMT ) > " & Val(TXTSALEGREATER.Text.Trim) & " ORDER BY SALEAMT, HOTELNAME")
                FRMSTRING = "HOTELWISE"
            ElseIf RBCITYWISE.Checked = True Then
                dt = objclspreq.search(" HOTELNAME,SUM(RESERVATION_SALEREPORT.SALEAMT ) AS SALEAMT ", "", " RESERVATION_SALEREPORT ", WHERECLAUSE & "  AND CMPID = " & CmpId & " AND locationid = " & Locationid & " AND yearid = " & YearId & " GROUP BY HOTELNAME HAVING SUM(RESERVATION_SALEREPORT.SALEAMT ) > " & Val(TXTSALEGREATER.Text.Trim) & " ORDER BY SALEAMT, HOTELNAME")
                FRMSTRING = "CITYWISE"
            ElseIf RBBOOKEDBYWISE.Checked = True Then
                dt = objclspreq.search(" BOOKEDBY,SUM(RESERVATION_SALEREPORT.SALEAMT ) AS SALEAMT ", "", " RESERVATION_SALEREPORT ", WHERECLAUSE & "  AND CMPID = " & CmpId & " AND locationid = " & Locationid & " AND yearid = " & YearId & " GROUP BY BOOKEDBY HAVING SUM(RESERVATION_SALEREPORT.SALEAMT ) > " & Val(TXTSALEGREATER.Text.Trim) & " ORDER BY SALEAMT, BOOKEDBY")
                FRMSTRING = "BOOKEDBYWISE"
            ElseIf RBMONTH.Checked = True Then
                dt = objclspreq.search(" DATENAME(MONTH,RESERVATION_SALEREPORT.DATE) AS MONTHNAME, SUM(SALEAMT) AS SALEAMT ", "", " RESERVATION_SALEREPORT ", WHERECLAUSE & "  AND CMPID = " & CmpId & " AND locationid = " & Locationid & " AND yearid = " & YearId & " GROUP BY DATENAME(MONTH,RESERVATION_SALEREPORT.DATE), MONTH(RESERVATION_SALEREPORT.DATE)  HAVING SUM(SALEAMT) > " & Val(TXTSALEGREATER.Text.Trim) & " ORDER BY MONTH(RESERVATION_SALEREPORT.DATE) ")
                FRMSTRING = "MONTHWISE"
            ElseIf RBAGENTWISE.Checked = True Then
                dt = objclspreq.search(" SALELEDGER,SUM(RESERVATION_SALEREPORT.SALEAMT ) AS SALEAMT ", "", " RESERVATION_SALEREPORT ", WHERECLAUSE & "  AND CMPID = " & CmpId & " AND locationid = " & Locationid & " AND yearid = " & YearId & " GROUP BY SALELEDGER HAVING SUM(RESERVATION_SALEREPORT.SALEAMT ) > " & Val(TXTSALEGREATER.Text.Trim) & " ORDER BY SALEAMT, SALELEDGER")
                FRMSTRING = "AGENTWISE"
            ElseIf RBPURWISE.Checked = True Then
                If ClientName = "PARAMOUNT" Then
                    dt = objclspreq.search(" LEDGERNAME AS PURLEDGER,SUM(GTOTAL) AS SALEAMT ", "", " RESERVATIONDETAILS ", WHERECLAUSE & " AND REGNAME = 'PACKAGE PURCHASE REGISTER' AND CMPID = " & CmpId & " AND locationid = " & Locationid & " AND yearid = " & YearId & " GROUP BY LEDGERNAME HAVING SUM(GTOTAL) > " & Val(TXTSALEGREATER.Text.Trim) & " ORDER BY SALEAMT, PURLEDGER")
                Else
                    dt = objclspreq.search(" PURLEDGER,SUM(RESERVATION_SALEREPORT.SALEAMT ) AS SALEAMT ", "", " RESERVATION_SALEREPORT ", WHERECLAUSE & "  AND CMPID = " & CmpId & " AND locationid = " & Locationid & " AND yearid = " & YearId & " GROUP BY PURLEDGER HAVING SUM(RESERVATION_SALEREPORT.SALEAMT ) > " & Val(TXTSALEGREATER.Text.Trim) & " ORDER BY SALEAMT, PURLEDGER")
                End If
                FRMSTRING = "PURWISE"
            ElseIf RBGUESTWISE.Checked = True Then
                dt = objclspreq.search(" GUESTNAME,SUM(RESERVATION_SALEREPORT.SALEAMT ) AS SALEAMT ", "", " RESERVATION_SALEREPORT ", WHERECLAUSE & "  AND CMPID = " & CmpId & " AND locationid = " & Locationid & " AND yearid = " & YearId & " GROUP BY GUESTNAME HAVING SUM(RESERVATION_SALEREPORT.SALEAMT ) > " & Val(TXTSALEGREATER.Text.Trim) & " ORDER BY SALEAMT, GUESTNAME")
                FRMSTRING = "GUESTWISE"
            ElseIf RBTOPHOTEL.Checked = True Then
                dt = objclspreq.search(" TOP " & Val(TXTTOP.Text.Trim) & " HOTELNAME , SUM(SALEAMT) AS SALEAMT ", "", " RESERVATION_SALEREPORT ", WHERECLAUSE & "  AND CMPID = " & CmpId & " AND locationid = " & Locationid & " AND yearid = " & YearId & " GROUP BY HOTELNAME HAVING SUM(RESERVATION_SALEREPORT.SALEAMT ) > " & Val(TXTSALEGREATER.Text.Trim) & " ORDER BY SALEAMT DESC")
                FRMSTRING = "TOPHOTEL"
            ElseIf RBTOPCITY.Checked = True Then
                dt = objclspreq.search(" TOP " & Val(TXTTOP.Text.Trim) & " HOTELNAME , SUM(SALEAMT) AS SALEAMT ", "", " RESERVATION_SALEREPORT ", WHERECLAUSE & "  AND CMPID = " & CmpId & " AND locationid = " & Locationid & " AND yearid = " & YearId & " GROUP BY HOTELNAME HAVING SUM(RESERVATION_SALEREPORT.SALEAMT ) > " & Val(TXTSALEGREATER.Text.Trim) & " ORDER BY SALEAMT DESC")
                FRMSTRING = "TOPCITY"
            ElseIf RBTOPBOOKEDBY.Checked = True Then
                dt = objclspreq.search(" TOP " & Val(TXTTOP.Text.Trim) & " BOOKEDBY , SUM(SALEAMT) AS SALEAMT ", "", " RESERVATION_SALEREPORT ", WHERECLAUSE & "  AND CMPID = " & CmpId & " AND locationid = " & Locationid & " AND yearid = " & YearId & " GROUP BY BOOKEDBY HAVING SUM(RESERVATION_SALEREPORT.SALEAMT ) > " & Val(TXTSALEGREATER.Text.Trim) & " ORDER BY SALEAMT DESC")
                FRMSTRING = "TOPBOOKEDBY"
            ElseIf RBTOPAGENT.Checked = True Then
                dt = objclspreq.search(" TOP " & Val(TXTTOP.Text.Trim) & " SALELEDGER , SUM(SALEAMT) AS SALEAMT ", "", " RESERVATION_SALEREPORT ", WHERECLAUSE & "  AND CMPID = " & CmpId & " AND locationid = " & Locationid & " AND yearid = " & YearId & " GROUP BY SALELEDGER HAVING SUM(RESERVATION_SALEREPORT.SALEAMT ) > " & Val(TXTSALEGREATER.Text.Trim) & " ORDER BY SALEAMT DESC")
                FRMSTRING = "TOPAGENT"
            ElseIf RBTOPPUR.Checked = True Then
                dt = objclspreq.search(" TOP " & Val(TXTTOP.Text.Trim) & " PURLEDGER , SUM(SALEAMT) AS SALEAMT ", "", " RESERVATION_SALEREPORT ", WHERECLAUSE & "  AND CMPID = " & CmpId & " AND locationid = " & Locationid & " AND yearid = " & YearId & " GROUP BY PURLEDGER HAVING SUM(RESERVATION_SALEREPORT.SALEAMT ) > " & Val(TXTSALEGREATER.Text.Trim) & " ORDER BY SALEAMT DESC")
                FRMSTRING = "TOPPUR"
            ElseIf RBTOPGUEST.Checked = True Then
                dt = objclspreq.search(" TOP " & Val(TXTTOP.Text.Trim) & " GUESTNAME , SUM(SALEAMT) AS SALEAMT ", "", " RESERVATION_SALEREPORT ", WHERECLAUSE & "  AND CMPID = " & CmpId & " AND locationid = " & Locationid & " AND yearid = " & YearId & " GROUP BY GUESTNAME HAVING SUM(RESERVATION_SALEREPORT.SALEAMT ) > " & Val(TXTSALEGREATER.Text.Trim) & " ORDER BY SALEAMT DESC")
                FRMSTRING = "TOPGUEST"
            End If
            If dt.Rows.Count = 0 Then
                MsgBox("No Records Found", MsgBoxStyle.Critical, "Texpro")
                Exit Sub
            End If
            Dim objrep As New clsReportDesigner("Analytical Report", System.AppDomain.CurrentDomain.BaseDirectory & "Analytical Report.xlsx", 2)
            objrep.CHART_REPORT_EXCEL(dt, CmpId, Locationid, YearId, "ANALYTICAL REPORT", FRMSTRING)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

   Private Sub chkdate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkdate.CheckedChanged
        dtfrom.Enabled = chkdate.CheckState
        dtto.Enabled = chkdate.CheckState
    End Sub
End Class