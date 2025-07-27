
Imports BL

Public Class MiscEnquiryFilter
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
            If CMBSOURCE.Text.Trim = "" Then FILLSOURCE(CMBSOURCE, edit)
            'If CMBBOOKEDBY.Text.Trim = "" Then FILLBOOKEDBY(CMBBOOKEDBY, edit)

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub MiscEnquiryFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
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

    Private Sub MiscEnquiryFilter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

            'GET ALL YEARID FROM SELECTED COMPANY WITH SAME STARTYEAR
            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable
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


            If RBGRIDDETAILS.Checked = True Then
                Dim WHERECLAUSE As String = ""
                Dim OBJENQ As New MiscEnqGridReport
                OBJENQ.MdiParent = MDIMain

                If CMBSOURCE.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND SOURCEMASTER.SOURCE_NAME = '" & CMBSOURCE.Text.Trim & "'"
                If CMBSTATUS.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND MISCENQUIRY.MISC_STATUS = '" & CMBSTATUS.Text.Trim & "'"
                If CMBTYPE.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND MISCENQUIRY.MISC_TYPE = '" & CMBTYPE.Text.Trim & "'"
                If chkdate.Checked = True Then WHERECLAUSE = WHERECLAUSE & " AND MISCENQUIRY.MISC_DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND MISCENQUIRY.MISC_DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"

                OBJENQ.DT = OBJCMN.search("  MISCENQUIRY.MISC_NO AS MISCNO, MISCENQUIRY.MISC_DATE AS DATE, ISNULL(PREFIXMASTER.PREFIX_NAME, '') AS PREFIX, ISNULL(MISCENQUIRY.MISC_GUESTNAME, '') AS GUESTNAME, ISNULL(MISCENQUIRY.MISC_MOBILENO, '') AS MOBILENO, ISNULL(MISCENQUIRY.MISC_EMAILID, '') AS EMAILID, ISNULL(MISCENQUIRY.MISC_TYPE, '') AS TYPE, ISNULL(LEADTYPEMASTER.LEADTYPE_NAME, '') AS LEADTYPE, ISNULL(MISCENQUIRY.MISC_STATUS, '') AS STATUS, ISNULL(MISCENQUIRY.MISC_DESC, '') AS [DESC], ISNULL(SOURCEMASTER.SOURCE_NAME, '') AS SOURCE, ISNULL(BOOKEDBYMASTER.BOOKEDBY_NAME, '') AS BOOKEDBY, ISNULL(MISCENQUIRY.MISC_CHECKIN, '') AS CHECKIN, ISNULL(MISCENQUIRY.MISC_CHECKOUT, '') AS CHECKOUT, ISNULL(MISCENQUIRY.MISC_ADULTS, 0) AS ADULTS, ISNULL(MISCENQUIRY.MISC_CHILD, 0) AS CHILD, ISNULL(MISCENQUIRY.MISC_INFANTS, 0) AS INFANTS, ISNULL(MISCENQUIRY.MISC_TOTALPAX, 0) AS TOTALPAX, ISNULL(MISCENQUIRY.MISC_CLOSEDREMARKS, '') AS CLOSEDREMARKS, ISNULL(MISCENQUIRY.MISC_ADDRESS, '') AS ADDRESS, ISNULL(MISCENQUIRY.MISC_DONE, 0) AS DONE, ISNULL(ENQTRANSFERREDTOMASTER.BOOKEDBY_NAME, '') AS ENQTRANSFERREDTO, ISNULL(CITYMASTER.city_name, '') AS CITY, ISNULL(MISCENQUIRY.MISC_CHILDWITHOUTBED, 0) AS CHILDWITHOUTBED, ISNULL(MISCENQUIRY.MISC_EXTRAADULTS, 0) AS EXTRAADULTS, ISNULL(MISCENQUIRY.MISC_ROOMS, 0) AS ROOMS, ISNULL(MISCENQUIRY.MISC_ENQBYNAME, '') AS ENQNAME, ISNULL(MISCENQUIRY.MISC_ENQBYMOBILENO, '') AS ENQMOBILENO, ISNULL(MISCENQUIRY.MISC_ENQBYEMAILID, '') AS ENQEMAILID, ISNULL(MISCENQUIRY.MISC_AGEPOLICYWITHBED, '') AS AGEPOLICYCHILDWITHBED, ISNULL(MISCENQUIRY.MISC_AGEPOLICYWITHOUTBED, '') AS AGEPOLICYCHILDWITHOUTBED, ISNULL(CATEGORY_NAME, '') AS CATEGORY, ISNULL(MISC_BOOKER,'') AS BOOKER, CMPMASTER.CMP_NAME AS CMPNAME ", "", " MISCENQUIRY INNER JOIN BOOKEDBYMASTER ON MISCENQUIRY.MISC_BOOKEDBYID = BOOKEDBYMASTER.BOOKEDBY_ID AND MISCENQUIRY.MISC_YEARID = BOOKEDBYMASTER.BOOKEDBY_YEARID LEFT OUTER JOIN LEADTYPEMASTER ON MISCENQUIRY.MISC_LEADTYPEID = LEADTYPEMASTER.LEADTYPE_ID LEFT OUTER JOIN SOURCEMASTER ON MISCENQUIRY.MISC_SOURCEID = SOURCEMASTER.SOURCE_ID AND MISCENQUIRY.MISC_YEARID = SOURCEMASTER.SOURCE_YEARID LEFT OUTER JOIN CITYMASTER ON MISCENQUIRY.MISC_CITYID = CITYMASTER.city_id LEFT OUTER JOIN BOOKEDBYMASTER AS ENQTRANSFERREDTOMASTER ON MISCENQUIRY.MISC_ENQTRANSFERREDTOID = ENQTRANSFERREDTOMASTER.BOOKEDBY_ID LEFT OUTER JOIN PREFIXMASTER ON MISCENQUIRY.MISC_PREFIXID = PREFIXMASTER.PREFIX_ID LEFT OUTER JOIN CATEGORYMASTER ON MISCENQUIRY.MISC_CATEGORYID = CATEGORY_ID INNER JOIN CMPMASTER ON MISCENQUIRY.MISC_CMPID = CMP_ID ", WHERECLAUSE & " AND MISCENQUIRY.MISC_YEARID  IN (" & CMPCLAUSE & ") ORDER BY MISCENQUIRY.MISC_DATE, MISCENQUIRY.MISC_NO")
                OBJENQ.Show()
                Exit Sub
            End If



            Dim OBJPO As New MiscEnquiryDesign
            OBJPO.MdiParent = MDIMain
            OBJPO.WHERECLAUSE = " {MISCENQUIRY.MISC_YEARID} In [" & CMPCLAUSE & "]"

            If chkdate.Checked = True Then
                getFromToDate()
                OBJPO.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
                OBJPO.WHERECLAUSE = OBJPO.WHERECLAUSE & " And {@Date} In Date " & fromD & " To Date " & toD & ""
            Else
                OBJPO.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
            End If

            If RDBALLDATA.Checked = True Then
                OBJPO.FRMSTRING = "ALLDTLS"

            ElseIf RDSTATUS.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJPO.FRMSTRING = "STATUSWISEDTLS"

            ElseIf RDENQHANDLE.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJPO.FRMSTRING = "HANDLEDWISEDTLS"

            ElseIf RDSOURCE.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJPO.FRMSTRING = "SOURCEWISEDTLS"

            ElseIf RDBMONTHLY.Checked = True Then
                OBJPO.FRMSTRING = "MONTHLYDTLS"

            ElseIf RBPENDING.Checked = True Then
                OBJPO.FRMSTRING = "PENDINENQ"
                OBJPO.WHERECLAUSE = OBJPO.WHERECLAUSE & " And {MISCENQUIRY.MISC_STATUS}= 'Pending'"

            ElseIf RBCLOSED.Checked = True Then
                OBJPO.FRMSTRING = "CLOSEDENQ"
                OBJPO.WHERECLAUSE = OBJPO.WHERECLAUSE & " AND {MISCENQUIRY.MISC_STATUS}= 'Cancel' "

            ElseIf RBCOMPLETED.Checked = True Then
                OBJPO.FRMSTRING = "CONFIRMEDENQ"
                OBJPO.WHERECLAUSE = OBJPO.WHERECLAUSE & " AND {MISCENQUIRY.MISC_STATUS}= 'Confirmed'"

            End If


            If CMBSOURCE.Text.Trim <> "" Then OBJPO.WHERECLAUSE = OBJPO.WHERECLAUSE & " and {SOURCEMASTER.SOURCE_NAME}='" & CMBSOURCE.Text.Trim & "'"
            If CMBSTATUS.Text.Trim <> "" Then OBJPO.WHERECLAUSE = OBJPO.WHERECLAUSE & " and {MISCENQUIRY.MISC_STATUS}='" & CMBSTATUS.Text.Trim & "'"
            If CMBTYPE.Text.Trim <> "" Then OBJPO.WHERECLAUSE = OBJPO.WHERECLAUSE & " AND {MISCENQUIRY.MISC_TYPE}='" & CMBTYPE.Text.Trim & "'"
            If ClientName = "VIDHI" And UserName <> "Admin" Then OBJPO.WHERECLAUSE = OBJPO.WHERECLAUSE & " AND {BOOKEDBYMASTER.BOOKEDBY_NAME}='" & UserName & "'"
            OBJPO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSOURCE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBSOURCE.Enter
        Try
            If CMBSOURCE.Text.Trim = "" Then FILLSOURCE(CMBSOURCE, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class