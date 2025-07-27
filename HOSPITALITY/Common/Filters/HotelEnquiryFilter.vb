Imports BL

Public Class HotelEnquiryFilter

    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String
    Public edit As Boolean

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
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
            If CMBBOOKEDBY.Text.Trim <> "" Then FILLBOOKEDBY(CMBBOOKEDBY, edit)
            If CMBGUESTNAME.Text.Trim = "" Then FILLGUEST(CMBGUESTNAME, False)
            If CMBHOTELNAME.Text.Trim = "" Then fillHOTEL(CMBHOTELNAME, False)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBGUESTNAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBGUESTNAME.Enter
        Try
            If CMBGUESTNAME.Text.Trim = "" Then FILLGUESTNAME(CMBGUESTNAME, False)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub CMBHOTELNAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBHOTELNAME.Enter
        Try
            If CMBHOTELNAME.Text.Trim = "" Then fillHOTEL(CMBHOTELNAME)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EnquiryFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub EnquiryFilter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try
            Dim CHECKED_CMP As CheckedListBox.CheckedItemCollection = LSTCMP.CheckedItems
            Dim OBJENQUIRY As New EnquiryDesign
            OBJENQUIRY.MdiParent = MDIMain
            OBJENQUIRY.WHERECLAUSE = " {HOTELENQMASTER.ENQ_yearid}=" & YearId


            If chkdate.Checked = True Then
                getFromToDate()
                OBJENQUIRY.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
                OBJENQUIRY.WHERECLAUSE = OBJENQUIRY.WHERECLAUSE & " and {@DATE} in date " & fromD & " to date " & toD & ""
            Else
                OBJENQUIRY.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
            End If


            If RDBGUEST.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJENQUIRY.FRMSTRING = "HOTELGUESTWISEDTLS" Else OBJENQUIRY.FRMSTRING = "HOTELGUESTWISESUMM"

            ElseIf RDBHOTEL.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJENQUIRY.FRMSTRING = "HOTELWISEDTLS" Else OBJENQUIRY.FRMSTRING = "HOTELWISESUMM"

            ElseIf RDBOOKEDBY.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJENQUIRY.FRMSTRING = "HOTELBOOKEDBYDTLS" Else OBJENQUIRY.FRMSTRING = "HOTELBOOKEDBYSUMM"

            ElseIf RBPENDING.Checked = True Then
                OBJENQUIRY.FRMSTRING = "HOTELPENDINGENQ"
                OBJENQUIRY.WHERECLAUSE = OBJENQUIRY.WHERECLAUSE & " AND {HOTELENQMASTER.ENQ_DONE} =FALSE AND {HOTELENQMASTER.ENQ_CLOSE}= FALSE"

            ElseIf RBCLOSED.Checked = True Then
                OBJENQUIRY.FRMSTRING = "HOTELCLOSEDENQ"
                OBJENQUIRY.WHERECLAUSE = OBJENQUIRY.WHERECLAUSE & " AND {HOTELENQMASTER.ENQ_CLOSE}= True "

            ElseIf RBCOMPLETED.Checked = True Then
                OBJENQUIRY.FRMSTRING = "HOTELCONFIRMEDENQ"
                OBJENQUIRY.WHERECLAUSE = OBJENQUIRY.WHERECLAUSE & " AND {HOTELENQMASTER.ENQ_DONE} =TRUE AND {HOTELENQMASTER.ENQ_CLOSE}= FALSE"
            End If


            If CMBHOTELNAME.Text <> "" Then OBJENQUIRY.WHERECLAUSE = OBJENQUIRY.WHERECLAUSE & " and {HOTELMASTER.HOTEL_NAME}='" & CMBHOTELNAME.Text.Trim & "'"
            If CMBGUESTNAME.Text <> "" Then OBJENQUIRY.WHERECLAUSE = OBJENQUIRY.WHERECLAUSE & " and {GUESTMASTER.GUEST_NAME}='" & CMBGUESTNAME.Text.Trim & "'"
            If CMBBOOKEDBY.Text <> "" Then OBJENQUIRY.WHERECLAUSE = OBJENQUIRY.WHERECLAUSE & " and {BOOKEDBYMASTER.BOOKEDBY_NAME}='" & CMBBOOKEDBY.Text.Trim & "'"

            OBJENQUIRY.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBOOKEDBY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBBOOKEDBY.Enter
        Try
            If CMBBOOKEDBY.Text.Trim = "" Then FILLBOOKEDBY(CMBBOOKEDBY, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class