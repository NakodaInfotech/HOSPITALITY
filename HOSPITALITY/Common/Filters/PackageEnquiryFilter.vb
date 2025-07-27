Imports BL

Public Class PackageEnquiryFilter

    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String

    Private Sub cmdexit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
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
            If CMBNAME.Text.Trim <> "" Then fillname(CMBNAME, False, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'")
            If CMBGUESTNAME.Text.Trim = "" Then FILLGUEST(CMBGUESTNAME, False)
            If CMBHOTELNAME.Text.Trim = "" Then fillHOTEL(CMBHOTELNAME)
            If CMBBOOKEDBY.Text.Trim <> "" Then FILLBOOKEDBY(CMBBOOKEDBY, False)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
    Private Sub CHKSELECTALL_CheckedChanged(sender As Object, e As EventArgs) Handles CHKSELECTALL.CheckedChanged
        If CHKSELECTALL.Checked = True Then
            For i As Integer = 0 To LSTCMP.Items.Count - 1
                LSTCMP.SetItemChecked(i, True)
            Next
        Else
            For i As Integer = 0 To LSTCMP.Items.Count - 1
                LSTCMP.SetItemChecked(i, False)
            Next
        End If
    End Sub
    Private Sub CMBGUESTNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBGUESTNAME.Enter
        Try
            If CMBGUESTNAME.Text.Trim = "" Then FILLGUESTNAME(CMBGUESTNAME, False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub CMBHOTELNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBHOTELNAME.Enter
        Try
            If CMBHOTELNAME.Text.Trim = "" Then fillHOTEL(CMBHOTELNAME)
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

    Private Sub PackageEnquiryFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub PackageEnquiryFilter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim OBJCMN As New ClsCommon
            Dim dt As DataTable = OBJCMN.search("CMP_NAME", "", "CMPMASTER", "")
            For Each DROW As DataRow In dt.Rows
                LSTCMP.Items.Add(DROW(0).ToString)
                If DROW(0) = CmpName Then LSTCMP.SetItemChecked(LSTCMP.Items.Count - 1, True)
            Next
            fillcmb()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try
            Dim DT As New DataTable
            Dim OBJCMN As New ClsCommon
            Dim CMPCLAUSE As String = ""
            Dim CHECKED_CMP As CheckedListBox.CheckedItemCollection = LSTCMP.CheckedItems
            For Each item As Object In CHECKED_CMP
                If CMPCLAUSE = "" Then
                    CMPCLAUSE = "'" & item.ToString() & "'"
                Else
                    CMPCLAUSE = CMPCLAUSE & ",'" & item.ToString() & "'"
                End If
            Next item
            DT = OBJCMN.search("cmp_id AS CMPID ,year_id AS YEARID", "", " CMPMASTER inner join YEARMASTER ON YEAR_CMPID = CMP_ID", " AND YEAR_STARTDATE = '" & Format(AccFrom.Date, "MM/dd/yyyy") & "' AND CMP_NAME IN (" & CMPCLAUSE & ")")
            CMPCLAUSE = ""
            For Each DTROW As DataRow In DT.Rows
                If CMPCLAUSE = "" Then CMPCLAUSE = DTROW("YEARID") Else CMPCLAUSE = CMPCLAUSE & "," & DTROW("YEARID")
            Next


            'COMMENTED BY WASEEM
            If RBGRIDDETAILS.Checked = True Then
                Dim WHERECLAUSE As String = ""
                Dim OBJPENQ As New PackageQuotationGridReport

                OBJPENQ.MdiParent = MDIMain

                If CMBHOTELNAME.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND {HOTELMASTER.HOTEL_NAME} = '" & CMBHOTELNAME.Text.Trim & "'"
                If CMBGUESTNAME.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND {GUESTMASTER.GUEST_NAME} = '" & CMBGUESTNAME.Text.Trim & "'"
                If CMBNAME.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND  {LEDGERS.ACC_CMPNAME} = '" & CMBNAME.Text.Trim & "'"
                If CMBBOOKEDBY.Text <> "" Then WHERECLAUSE = WHERECLAUSE & " and {BOOKEDBYMASTER.BOOKEDBY_NAME}='" & CMBBOOKEDBY.Text.Trim & "'"
                If chkdate.Checked = True Then WHERECLAUSE = WHERECLAUSE & " AND HOLIDAYENQMASTER.ENQ_DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND HOLIDAYENQMASTER.ENQ_DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"

                OBJPENQ.DT = OBJCMN.search("  HOLIDAYENQMASTER.ENQ_NO AS ENQNO, HOLIDAYENQMASTER.ENQ_DATE AS ENQDATE, ISNULL(HOLIDAYENQMASTER.ENQ_REFNO, '') AS REFNO, GUESTMASTER.GUEST_NAME AS GUESTNAME, HOLIDAYENQMASTER.ENQ_TOURNAME AS TOURNAME, HOLIDAYENQMASTER.ENQ_PACKAGEFROM AS PACKAGEFROM, HOLIDAYENQMASTER.ENQ_PACKAGETO AS PACKAGETO, HOLIDAYENQMASTER.ENQ_TOTALPAX AS TOTALPAX, HOLIDAYENQMASTER.ENQ_GRANDTOTAL AS GRANDTOTAL, HOLIDAYENQMASTER.ENQ_DONE AS DONE, HOLIDAYENQMASTER.ENQ_REMARKS AS REMARKS, HOLIDAYENQMASTER.ENQ_QUOTEPENDING AS QUOTEPENDING, HOLIDAYENQMASTER.ENQ_AMENDED AS AMENDED, HOLIDAYENQMASTER.ENQ_SUBTOTAL - HOLIDAYENQMASTER.ENQ_COSTPRICE AS COMM, CMPMASTER.CMP_NAME AS CMPNAME ", "", "  HOLIDAYENQMASTER INNER JOIN GUESTMASTER ON HOLIDAYENQMASTER.ENQ_GUESTID = GUESTMASTER.GUEST_ID AND HOLIDAYENQMASTER.ENQ_CMPID = GUESTMASTER.GUEST_CMPID AND HOLIDAYENQMASTER.ENQ_LOCATIONID = GUESTMASTER.GUEST_LOCATIONID AND HOLIDAYENQMASTER.ENQ_YEARID = GUESTMASTER.GUEST_YEARID INNER JOIN BOOKEDBYMASTER ON HOLIDAYENQMASTER.ENQ_BOOKEDBYID = BOOKEDBYMASTER.BOOKEDBY_ID AND HOLIDAYENQMASTER.ENQ_YEARID = BOOKEDBYMASTER.BOOKEDBY_YEARID INNER JOIN CMPMASTER ON HOLIDAYENQMASTER.ENQ_CMPID = CMPMASTER.CMP_ID ", " AND BOOKEDBYMASTER.BOOKEDBY_NAME = '" & UserName & "' AND ENQ_YEARID  IN (" & CMPCLAUSE & ") ORDER BY HOLIDAYENQMASTER.ENQ_DATE, HOLIDAYENQMASTER.ENQ_NO")
                OBJPENQ.Show()
                Exit Sub
            End If


            Dim OBJENQUIRY As New EnquiryDesign

            OBJENQUIRY.MdiParent = MDIMain
            OBJENQUIRY.WHERECLAUSE = " {HOLIDAYENQMASTER.ENQ_yearid}=" & YearId


            If chkdate.Checked = True Then
                getFromToDate()
                OBJENQUIRY.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
                OBJENQUIRY.WHERECLAUSE = OBJENQUIRY.WHERECLAUSE & " and {@DATE} in date " & fromD & " to date " & toD & ""
            Else
                OBJENQUIRY.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
            End If


            If RDBGUEST.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJENQUIRY.FRMSTRING = "PACKAGEGUESTWISEDTLS" Else OBJENQUIRY.FRMSTRING = "PACKAGEGUESTWISESUMM"

            ElseIf RDBHOTEL.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJENQUIRY.FRMSTRING = "PACKAGEHOTELWISEDTLS" Else OBJENQUIRY.FRMSTRING = "PACKAGEHOTELWISESUMM"

            ElseIf RDBOOKEDBY.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJENQUIRY.FRMSTRING = "PACKAGEBOOKEDBYDTLS" Else OBJENQUIRY.FRMSTRING = "PACKAGEBOOKEDBYSUMM"

            ElseIf RBPENDING.Checked = True Then
                OBJENQUIRY.FRMSTRING = "PACKAGEPENDINGENQ"
                OBJENQUIRY.WHERECLAUSE = OBJENQUIRY.WHERECLAUSE & " AND {HOLIDAYENQMASTER.ENQ_DONE} = FALSE AND {HOLIDAYENQMASTER.ENQ_CLOSE} = FALSE"

            ElseIf RBCLOSED.Checked = True Then
                OBJENQUIRY.FRMSTRING = "PACKAGECLOSEDENQ"
                OBJENQUIRY.WHERECLAUSE = OBJENQUIRY.WHERECLAUSE & " AND {HOLIDAYENQMASTER.ENQ_CLOSE} = TRUE"

            ElseIf RBCOMPLETED.Checked = True Then
                OBJENQUIRY.FRMSTRING = "PACKAGECONFIRMEDENQ"
                OBJENQUIRY.WHERECLAUSE = OBJENQUIRY.WHERECLAUSE & " AND {HOLIDAYENQMASTER.ENQ_DONE} = TRUE AND {HOLIDAYENQMASTER.ENQ_CLOSE} = FALSE"

            End If



            If CMBHOTELNAME.Text <> "" Then OBJENQUIRY.WHERECLAUSE = OBJENQUIRY.WHERECLAUSE & " and {HOTELMASTER.HOTEL_NAME}='" & CMBHOTELNAME.Text.Trim & "'"
            If CMBGUESTNAME.Text <> "" Then OBJENQUIRY.WHERECLAUSE = OBJENQUIRY.WHERECLAUSE & " and {GUESTMASTER.GUEST_NAME}='" & CMBGUESTNAME.Text.Trim & "'"
            If CMBNAME.Text <> "" Then OBJENQUIRY.WHERECLAUSE = OBJENQUIRY.WHERECLAUSE & " and {LEDGERS.ACC_CMPNAME}='" & CMBNAME.Text.Trim & "'"
            If CMBBOOKEDBY.Text <> "" Then OBJENQUIRY.WHERECLAUSE = OBJENQUIRY.WHERECLAUSE & " and {BOOKEDBYMASTER.BOOKEDBY_NAME}='" & CMBBOOKEDBY.Text.Trim & "'"

            OBJENQUIRY.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub CMBBOOKEDBY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBBOOKEDBY.Enter
        Try
            If CMBBOOKEDBY.Text.Trim = "" Then FILLBOOKEDBY(CMBBOOKEDBY, False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class