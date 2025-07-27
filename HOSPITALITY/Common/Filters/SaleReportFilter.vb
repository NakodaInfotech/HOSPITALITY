
Imports BL

Public Class SaleReportFilter

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
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

    Private Sub cmbhotelname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBHOTELNAME.Enter
        Try
            If cmbhotelname.Text.Trim = "" Then fillHOTEL(cmbhotelname)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbhotelname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBHOTELNAME.Validating
        Try
            If CMBHOTELNAME.Text.Trim <> "" Then HOTELvalidate(CMBHOTELNAME, cmbhotelcode, e, Me, TXTHOTELADD)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub chkdate_CheckedChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkdate.CheckedChanged
        dtfrom.Enabled = chkdate.CheckState
        dtto.Enabled = chkdate.CheckState
    End Sub

    Private Sub cmdShowReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowReport.Click
        Try
            Dim OBJRESERVATION As New ReservationDetailsDesign
            OBJRESERVATION.FRMSTRING = "SALEREPORT"
            OBJRESERVATION.MdiParent = MDIMain
            OBJRESERVATION.strsearch = ""

            If CMBBOOKEDBY.Text.Trim <> "" Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & "  {BOOKEDBYMASTER.BOOKEDBY_NAME}= '" & CMBBOOKEDBY.Text.Trim & "'"

            If CMBHOTELNAME.Text.Trim <> "" Then
                If OBJRESERVATION.strsearch = "" Then
                    OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & "  {HOTELMASTER.HOTEL_NAME}= '" & CMBHOTELNAME.Text.Trim & "'"
                Else
                    OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & "  AND {HOTELMASTER.HOTEL_NAME}= '" & CMBHOTELNAME.Text.Trim & "'"
                End If
            End If

            If chkdate.Checked = True Then
                getFromToDate()
                If OBJRESERVATION.strsearch <> "" Then
                    OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " and ({@BOOKINGDATE} in date " & fromD & " to date " & toD & ")"
                Else
                    OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " {@BOOKINGDATE} in date " & fromD & " to date " & toD & ""
                End If
                OBJRESERVATION.PERIOD = "From - " & Format(dtfrom.Value.Date, "dd-MM-yyyy") & " To - " & Format(dtto.Value.Date, "dd-MM-yyyy")
            Else
                OBJRESERVATION.PERIOD = "From - " & Format(AccFrom, "dd-MM-yyyy") & "  To - " & Format(AccTo, "dd-MM-yyyy")
            End If

            If OBJRESERVATION.strsearch = "" Then
                OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & "  {HOTELBOOKINGMASTER.BOOKING_CMPID}= " & CmpId & " AND {HOTELBOOKINGMASTER.BOOKING_LOCATIONID}= " & Locationid & " AND {HOTELBOOKINGMASTER.BOOKING_YEARID}=" & YearId & " AND {HOTELBOOKINGMASTER.BOOKING_CANCELLED}= FALSE AND {HOTELBOOKINGMASTER.BOOKING_AMD_DONE}= FALSE "
            Else
                OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & "  AND {HOTELBOOKINGMASTER.BOOKING_CMPID}= " & CmpId & " AND {HOTELBOOKINGMASTER.BOOKING_LOCATIONID}= " & Locationid & " AND {HOTELBOOKINGMASTER.BOOKING_YEARID}=" & YearId & " AND {HOTELBOOKINGMASTER.BOOKING_CANCELLED}= FALSE AND {HOTELBOOKINGMASTER.BOOKING_AMD_DONE}= FALSE "
            End If

            If ClientName = "CLASSIC" And UserName <> "Admin" Then If USERVIEW = False Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " AND {BOOKEDBYMASTER.BOOKEDBY_NAME} = '" & UserName & "' "
            OBJRESERVATION.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaleReportFilter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ACCOUNT REPORTS'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class