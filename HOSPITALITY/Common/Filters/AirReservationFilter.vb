Imports BL

Public Class AirReservationFilter

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Public FRMSTRING As String
    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String

    Sub getFromToDate()
        a1 = DatePart(DateInterval.Day, dtfrom.Value.Date)
        a2 = DatePart(DateInterval.Month, dtfrom.Value.Date)
        a3 = DatePart(DateInterval.Year, dtfrom.Value.Date)
        fromD = "(" & a3 & "," & a2 & "," & a1 & ")"

        a11 = DatePart(DateInterval.Day, dtto.Value.Date)
        a12 = DatePart(DateInterval.Month, dtto.Value.Date)
        a13 = DatePart(DateInterval.Year, dtto.Value.Date)
        toD = "(" & a13 & "," & a12 & "," & a11 & ")"
    End Sub

    Sub getFromToDateARR()
        a1 = DatePart(DateInterval.Day, ARRIVALFROM.Value.Date)
        a2 = DatePart(DateInterval.Month, ARRIVALFROM.Value.Date)
        a3 = DatePart(DateInterval.Year, ARRIVALFROM.Value.Date)
        fromD = "(" & a3 & "," & a2 & "," & a1 & ")"

        a11 = DatePart(DateInterval.Day, ARRIVALTO.Value.Date)
        a12 = DatePart(DateInterval.Month, ARRIVALTO.Value.Date)
        a13 = DatePart(DateInterval.Year, ARRIVALTO.Value.Date)
        toD = "(" & a13 & "," & a12 & "," & a11 & ")"
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
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

    Private Sub AirReservationFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
                'Call cmdShowReport_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AirReservationFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ACCOUNT REPORTS'")
        USERADD = DTROW(0).Item(1)
        USEREDIT = DTROW(0).Item(2)
        USERVIEW = DTROW(0).Item(3)
        USERDELETE = DTROW(0).Item(4)
        Me.Text = "Airline Reservation Details"

    End Sub

    Private Sub CMBAIRNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBAIRNAME.Enter
        Try
            If CMBAIRNAME.Text.Trim = "" Then FILLAIRLINE(CMBAIRNAME, False, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBAIRNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBAIRNAME.Validating
        Try
            If CMBAIRNAME.Text.Trim <> "" Then AIRLINEVALIDATE(CMBAIRNAME, cmbaircode, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbaircode_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbaircode.Enter
        Try
            If cmbaircode.Text.Trim = "" Then FILLAIRCODE(cmbaircode, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmbaircode_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbaircode.Validating
        Try
            If cmbaircode.Text.Trim <> "" Then AIRCODEVALIDATE(cmbaircode, CMBAIRNAME, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub CMBACCCODE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBACCCODE.Enter
        Try
            If CMBACCCODE.Text.Trim = "" Then fillACCCODE(CMBACCCODE, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'")
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

    Private Sub CMBACCCODE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBACCCODE.Validating
        Try
            If CMBACCCODE.Text.Trim <> "" Then ACCCODEVALIDATE(CMBACCCODE, CMBNAME, e, Me, TXTHOTELADD, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'", "SUNDRY DEBTORS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBACCCODE, e, Me, TXTHOTELADD, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'", "SUNDRY DEBTORS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPURCODE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPURCODE.Enter
        Try
            If CMBPURCODE.Text.Trim = "" Then fillACCCODE(CMBPURCODE, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
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
    Private Sub CMBPURCODE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPURCODE.Validating
        Try
            If CMBPURCODE.Text.Trim <> "" Then ACCCODEVALIDATE(CMBPURCODE, CMBPURNAME, e, Me, TXTHOTELADD, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'", "SUNDRY CREDITORS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPURNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPURNAME.Validating
        Try
            If CMBPURNAME.Text.Trim <> "" Then namevalidate(CMBPURNAME, CMBPURCODE, e, Me, TXTHOTELADD, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBOOKINGNO_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBBOOKINGNO.Enter
        Try
            FILLBILLNO()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLBILLNO()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" BOOKING_SALEBILLINITIALS AS BOOKINGNO ", "", " AIRLINEBOOKINGMASTER", " AND BOOKING_CMPID = " & CmpId & " AND BOOKING_LOCATIONID = " & Locationid & " AND BOOKING_YEARID = " & YearId & " ORDER BY BOOKING_SALEREGISTERID, BOOKING_NO")
            If DT.Rows.Count > 0 Then
                CMBBOOKINGNO.DataSource = DT
                CMBBOOKINGNO.DisplayMember = "BOOKINGNO"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKARRDATE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKARRDATE.CheckedChanged
        ARRIVALFROM.Enabled = CHKARRDATE.CheckState
        ARRIVALTO.Enabled = CHKARRDATE.CheckState
    End Sub

    Private Sub CMBCONFIRMEDBY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCONFIRMEDBY.Enter
        Try
            If CMBCONFIRMEDBY.Text.Trim = "" Then
                CMBCONFIRMEDBY.Items.Clear()
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" DISTINCT CONFIRMEDBY", "", " AIRRESERVATION_SALEREPORT ", " AND CMPID = " & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId & " ORDER BY CONFIRMEDBY")
                If DT.Rows.Count > 0 Then
                    CMBCONFIRMEDBY.Items.Add("")
                    For Each DTROW As DataRow In DT.Rows
                        CMBCONFIRMEDBY.Items.Add(DTROW("CONFIRMEDBY"))
                    Next
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SUMMARYREPORT()
        Dim OBJRESERVATION As New AirReservationDetails
        If CMBAIRNAME.Text.Trim <> "" Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & "  AND m.AIRLINENAME = '" & CMBAIRNAME.Text.Trim & "'"
        If CMBPURNAME.Text.Trim <> "" Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & "  AND m.PURLEDGER = '" & CMBPURNAME.Text.Trim & "'"
        If CMBNAME.Text.Trim <> "" Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & "  AND m.SALELEDGER = '" & CMBNAME.Text.Trim & "'"
        If CMBBOOKEDBY.Text.Trim <> "" Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND m.BOOKEDBY = '" & CMBBOOKEDBY.Text.Trim & "'"
        If CMBBOOKINGNO.Text.Trim <> "" Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND m.BOOKINGNO = '" & CMBBOOKINGNO.Text.Trim & "'"
        If CMBCONFIRMEDBY.Text.Trim <> "" Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND m.CONFIRMEDBY = '" & CMBCONFIRMEDBY.Text.Trim & "'"
        If CMBPACKAGETYPE.Text.Trim <> "" Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND m.DOMINT = '" & CMBPACKAGETYPE.Text.Trim & "'"

        If Val(TXTSALEBAL.Text.Trim) > 0 Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND m.SALEBAL > " & Val(TXTSALEBAL.Text.Trim)
        If Val(TXTSALEGREATER.Text.Trim) > 0 Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND m.SALEAMT > " & Val(TXTSALEGREATER.Text.Trim)
        If Val(TXTSALELESS.Text.Trim) > 0 Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND m.SALEAMT < " & Val(TXTSALELESS.Text.Trim)

        If Val(TXTPURGREATER.Text.Trim) > 0 Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND m.PURAMT < " & Val(TXTPURGREATER.Text.Trim)
        If Val(TXTPURLESS.Text.Trim) > 0 Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND m.PURAMT < " & Val(TXTPURLESS.Text.Trim)

        If CHKCANCELLED.CheckState = CheckState.Checked Then
            OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND m.CANCELLED = '" & True & "'"
        Else
            OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND m.CANCELLED = '" & False & "'"
        End If

        If CHKAMENDED.CheckState = CheckState.Checked Then
            OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND m.AMENDED = '" & True & "'"
        Else
            OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND m.AMENDED = '" & False & "'"
        End If

        If chkdate.Checked = True Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " and m.DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND m.DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"

        If CHKARRDATE.Checked = True Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " and m.ARRIVAL >= '" & Format(ARRIVALFROM.Value.Date, "MM/dd/yyyy") & "' AND m.ARRIVAL <= '" & Format(ARRIVALTO.Value.Date, "MM/dd/yyyy") & "'"

        If ClientName = "CLASSIC" And UserName <> "Admin" Then If USERVIEW = False Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND BOOKEDBY = '" & UserName & "' "

        OBJRESERVATION.MdiParent = MDIMain
        OBJRESERVATION.Show()
    End Sub

    Sub DETAILREPORT()
        Dim OBJRESERVATION As New AirReservation
        If CMBAIRNAME.Text.Trim <> "" Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & "  AND AIRLINENAME = '" & CMBAIRNAME.Text.Trim & "'"
        If CMBPURNAME.Text.Trim <> "" Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & "  AND PURLEDGER = '" & CMBPURNAME.Text.Trim & "'"
        If CMBNAME.Text.Trim <> "" Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & "  AND SALELEDGER = '" & CMBNAME.Text.Trim & "'"
        If CMBBOOKEDBY.Text.Trim <> "" Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND BOOKEDBY = '" & CMBBOOKEDBY.Text.Trim & "'"
        If CMBBOOKINGNO.Text.Trim <> "" Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND BOOKINGNO = '" & CMBBOOKINGNO.Text.Trim & "'"
        If CMBCONFIRMEDBY.Text.Trim <> "" Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND CONFIRMEDBY = '" & CMBCONFIRMEDBY.Text.Trim & "'"

        If Val(TXTSALEBAL.Text.Trim) > 0 Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND SALEBAL > " & Val(TXTSALEBAL.Text.Trim)
        If Val(TXTSALEGREATER.Text.Trim) > 0 Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND SALEAMT > " & Val(TXTSALEGREATER.Text.Trim)
        If Val(TXTSALELESS.Text.Trim) > 0 Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND SALEAMT < " & Val(TXTSALELESS.Text.Trim)

        If Val(TXTPURGREATER.Text.Trim) > 0 Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND PURAMT < " & Val(TXTPURGREATER.Text.Trim)
        If Val(TXTPURLESS.Text.Trim) > 0 Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND PURAMT < " & Val(TXTPURLESS.Text.Trim)

        If CHKCANCELLED.CheckState = CheckState.Checked Then
            OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND CANCELLED = '" & True & "'"
        Else
            OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND CANCELLED = '" & False & "'"
        End If

        'If CHKAMENDED.CheckState = CheckState.Checked Then
        '    OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND AMENDED = '" & True & "'"
        'Else
        '    OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND AMENDED = '" & False & "'"
        'End If

        If chkdate.Checked = True Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " and DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"

        If CHKARRDATE.Checked = True Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " and ARRIVAL >= '" & Format(ARRIVALFROM.Value.Date, "MM/dd/yyyy") & "' AND ARRIVAL <= '" & Format(ARRIVALTO.Value.Date, "MM/dd/yyyy") & "'"

        If ClientName = "CLASSIC" And UserName <> "Admin" Then If USERVIEW = False Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND BOOKEDBY = '" & UserName & "' "

        OBJRESERVATION.MdiParent = MDIMain
        OBJRESERVATION.Show()
    End Sub

    Private Sub CMDSHOWDETAILS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSHOWDETAILS.Click
        Try
            If CHKDETAIL.Checked = True Then
                DETAILREPORT()
            Else
                SUMMARYREPORT()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class