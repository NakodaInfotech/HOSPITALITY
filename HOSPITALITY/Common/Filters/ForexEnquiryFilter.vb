Imports BL

Public Class ForexEnquiryFilter

    Dim edit As Boolean
    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGUEST_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBGUEST.Enter
        Try
            If CMBGUEST.Text.Trim = "" Then FILLGUESTNAME(CMBGUEST, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCURRENCY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBCURRENCY.Enter
        Try
            If CMBCURRENCY.Text.Trim = "" Then fillCurrency(CMBCURRENCY)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getFromToDate()
        a1 = DatePart(DateInterval.Day, dtfrom.Value)
        a2 = DatePart(DateInterval.Month, dtfrom.Value)
        a3 = DatePart(DateInterval.Year, dtfrom.Value)
        fromD = "(" & a3 & "," & a2 & "," & a1 & ")"

        a11 = DatePart(DateInterval.Day, dtto.Value)
        a12 = DatePart(DateInterval.Month, dtto.Value)
        a13 = DatePart(DateInterval.Year, dtto.Value)
        toD = "(" & a13 & "," & a12 & "," & a11 & ")"
    End Sub

    Sub fillcmb()
        Try
            If CMBGUEST.Text.Trim = "" Then FILLGUESTNAME(CMBGUEST, edit)
            If CMBSOURCE.Text.Trim = "" Then FILLSOURCE(CMBSOURCE, edit)
            'If CMBBOOKEDBY.Text.Trim = "" Then FILLBOOKEDBY(CMBBOOKEDBY, edit)
            If CMBCURRENCY.Text.Trim = "" Then fillCurrency(CMBCURRENCY)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBSOURCE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBSOURCE.Enter
        Try
            If CMBSOURCE.Text.Trim = "" Then FILLSOURCE(CMBSOURCE, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ForexEnquiryFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.Escape Then
                Me.Close()
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.S) Then
                cmdshow_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ForexEnquiryFilter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillcmb()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try
            Dim OBJPO As New ForexEnquiryDesign
            OBJPO.MdiParent = MDIMain
            OBJPO.WHERECLAUSE = " {FOREXENQUIRY.FOREX_yearid}=" & YearId

            If chkdate.Checked = True Then
                getFromToDate()
                OBJPO.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
                OBJPO.WHERECLAUSE = OBJPO.WHERECLAUSE & " and {@DATE} in date " & fromD & " to date " & toD & ""
            Else
                OBJPO.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
            End If

            If RDBALLDATA.Checked = True Then
                OBJPO.FRMSTRING = "ALLDTLS"

            ElseIf RDGUEST.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJPO.FRMSTRING = "GUESTWISEDTLS" Else OBJPO.FRMSTRING = "GUESTWISESUMM"

            ElseIf RDCURRENCY.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJPO.FRMSTRING = "CURRENCYWISEDTLS" Else OBJPO.FRMSTRING = "CURRENCYWISESUMM"

            ElseIf RDSTATUS.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJPO.FRMSTRING = "STATUSWISEDTLS" Else OBJPO.FRMSTRING = "STATUSWISESUMM"

            ElseIf RDENQHANDLE.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJPO.FRMSTRING = "HANDLEDWISEDTLS" Else OBJPO.FRMSTRING = "HANDLEDWISESUMM"

            ElseIf RDSOURCE.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJPO.FRMSTRING = "SOURCEWISEDTLS" Else OBJPO.FRMSTRING = "SOURCEWISESUMM"

            ElseIf RDBMONTHLY.Checked = True Then
                OBJPO.FRMSTRING = "MONTHLYDTLS"

            ElseIf RBPENDING.Checked = True Then
                OBJPO.FRMSTRING = "PENDINENQ"
                OBJPO.WHERECLAUSE = OBJPO.WHERECLAUSE & " AND {FOREXENQUIRY.FOREX_STATUS}= 'Pending'"

            ElseIf RBCLOSED.Checked = True Then
                OBJPO.FRMSTRING = "CLOSEDENQ"
                OBJPO.WHERECLAUSE = OBJPO.WHERECLAUSE & " AND {FOREXENQUIRY.FOREX_STATUS}= 'Cancel' "

            ElseIf RBCOMPLETED.Checked = True Then
                OBJPO.FRMSTRING = "CONFIRMEDENQ"
                OBJPO.WHERECLAUSE = OBJPO.WHERECLAUSE & " AND {FOREXENQUIRY.FOREX_STATUS}= 'Confirmed'"

            End If

            If CMBGUEST.Text <> "" Then OBJPO.WHERECLAUSE = OBJPO.WHERECLAUSE & " and {GUESTMASTER.GUEST_NAME}='" & CMBGUEST.Text.Trim & "'"
            If CMBCURRENCY.Text <> "" Then OBJPO.WHERECLAUSE = OBJPO.WHERECLAUSE & " and {CURRENCYMASTER.CUR_CODE}='" & CMBCURRENCY.Text.Trim & "'"
            If CMBSOURCE.Text <> "" Then OBJPO.WHERECLAUSE = OBJPO.WHERECLAUSE & " and {SOURCEMASTER.SOURCE_NAME}='" & CMBSOURCE.Text.Trim & "'"
            If CMBSTATUS.Text <> "" Then OBJPO.WHERECLAUSE = OBJPO.WHERECLAUSE & " and {FOREXENQUIRY.FOREX_STATUS}='" & CMBSTATUS.Text.Trim & "'"
            If CMBBUYSELL.Text <> "" Then OBJPO.WHERECLAUSE = OBJPO.WHERECLAUSE & " and {FOREXENQUIRY.FOREX_BUYSELL}='" & CMBBUYSELL.Text.Trim & "'"

            OBJPO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class