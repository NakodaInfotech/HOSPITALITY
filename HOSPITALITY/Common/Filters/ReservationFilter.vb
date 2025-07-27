
Imports BL

Public Class ReservationFilter

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

    Private Sub cmbhotelname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBHOTELNAME.Enter
        Try
            If CMBHOTELNAME.Text.Trim = "" Then
                If FRMSTRING = "VEHICLESALE" Or FRMSTRING = "VEHICLEPUR" Or FRMSTRING = "VEHICLEINVOICE" Or FRMSTRING = "VEHICLEOUTSTANDING" Then
                    FILLVEHICLE(CMBHOTELNAME, False, "")
                Else
                    fillHOTEL(CMBHOTELNAME)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbhotelname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBHOTELNAME.Validating
        Try
            If CMBHOTELNAME.Text.Trim <> "" Then
                If FRMSTRING = "VEHICLESALE" Or FRMSTRING = "VEHICLEPUR" Or FRMSTRING = "VEHICLEINVOICE" Or FRMSTRING = "VEHICLEOUTSTANDING" Then
                    VEHICLEVALIDATE(CMBHOTELNAME, e, Me)
                Else
                    HOTELvalidate(CMBHOTELNAME, cmbhotelcode, e, Me, TXTHOTELADD)
                End If
            End If
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

    Private Sub CMBGROUPOFHOTELS_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBGROUPOFHOTELS.Enter
        Try
            If CMBGROUPOFHOTELS.Text.Trim = "" Then FILLGROUPOFHOTELS(CMBGROUPOFHOTELS)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGROUPOFHOTELS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGROUPOFHOTELS.Validating
        Try
            If CMBGROUPOFHOTELS.Text.Trim <> "" Then GROUPOFHOTELSVALIDATE(CMBGROUPOFHOTELS, e, Me)
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

    Private Sub chkdate_CheckedChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkdate.CheckedChanged
        dtfrom.Enabled = chkdate.CheckState
        dtto.Enabled = chkdate.CheckState
    End Sub

    Private Sub cmdShowReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowReport.Click
        Try

            Dim OBJRESERVATION As New ReservationDetailsDesign
            OBJRESERVATION.MdiParent = MDIMain

            If FRMSTRING = "DETAILS" Then
                OBJRESERVATION.FRMSTRING = "RESERVATIONDETAILS"
            ElseIf FRMSTRING = "SUMMARY" Then
                OBJRESERVATION.FRMSTRING = "RESERVATIONSUMMARY"
            ElseIf FRMSTRING = "PACKAGE DETAILS" Then
                OBJRESERVATION.FRMSTRING = "PACKAGEDETAILS"
            ElseIf FRMSTRING = "PACKAGE SUMMARY" Then
                OBJRESERVATION.FRMSTRING = "PACKAGESUMMARY"
            ElseIf FRMSTRING = "INTERNATIONAL DETAILS" Then
                OBJRESERVATION.FRMSTRING = "INTERNATIONALDETAILS"
            ElseIf FRMSTRING = "INTERNATIONAL SUMMARY" Then
                OBJRESERVATION.FRMSTRING = "INTERNATIONALSUMMARY"
            ElseIf FRMSTRING = "CONSOLIDATED DETAILS" Then
                OBJRESERVATION.FRMSTRING = "CONSOLIDATEDDETAILS"
            ElseIf FRMSTRING = "CONSOLIDATED SUMMARY" Then
                OBJRESERVATION.FRMSTRING = "CONSOLIDATEDSUMMARY"
            End If


            'FROM HOTELBOOKINGMASTER
            If FRMSTRING = "DETAILS" Or FRMSTRING = "SUMMARY" Then
                OBJRESERVATION.strsearch = "  {HOTELBOOKINGMASTER.BOOKING_CMPID}= " & CmpId & " AND {HOTELBOOKINGMASTER.BOOKING_LOCATIONID}= " & Locationid & " AND {HOTELBOOKINGMASTER.BOOKING_YEARID}=" & YearId


                If CMBGUESTNAME.Text.Trim <> "" Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & "  AND {GUESTMASTER.GUEST_NAME}= '" & CMBGUESTNAME.Text.Trim & "'"
                If CMBHOTELNAME.Text.Trim <> "" Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & "  AND {HOTELMASTER.HOTEL_NAME}= '" & CMBHOTELNAME.Text.Trim & "'"
                If CMBGROUPOFHOTELS.Text.Trim <> "" Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & "  AND {GROUPOFHOTELSMASTER.GROUPOFHOTELS_NAME}= '" & CMBGROUPOFHOTELS.Text.Trim & "'"
                If CMBPURNAME.Text.Trim <> "" Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & "  AND {PURLEDGER.ACC_CMPNAME}= '" & CMBPURNAME.Text.Trim & "'"
                If CMBNAME.Text.Trim <> "" Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & "  AND {LEDGERS.ACC_CMPNAME}= '" & CMBNAME.Text.Trim & "'"
                If CMBBOOKEDBY.Text.Trim <> "" Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " AND {BOOKEDBYMASTER.BOOKEDBY_NAME}= '" & CMBBOOKEDBY.Text.Trim & "'"
                If CMBBOOKINGNO.Text.Trim <> "" Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " AND {HOTELBOOKINGMASTER.BOOKING_SALEBILLINITIALS}= '" & CMBBOOKINGNO.Text.Trim & "'"
                If CMBCONFIRMEDBY.Text.Trim <> "" Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " AND {HOTELBOOKINGMASTER.BOOKING_CONFIRMEDBY}= '" & CMBCONFIRMEDBY.Text.Trim & "'"
                If CMBPACKAGETYPE.Text.Trim <> "" Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " AND {HOTELBOOKINGMASTER.BOOKING_TYPE}= '" & CMBPACKAGETYPE.Text.Trim & "'"

                If Val(TXTSALEGREATER.Text.Trim) > 0 Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " AND {HOTELBOOKINGMASTER.BOOKING_GRANDTOTAL} > " & Val(TXTSALEGREATER.Text.Trim)
                If Val(TXTSALELESS.Text.Trim) > 0 Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " AND {HOTELBOOKINGMASTER.BOOKING_GRANDTOTAL} < " & Val(TXTSALELESS.Text.Trim)

                If Val(TXTPURGREATER.Text.Trim) > 0 Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " AND {HOTELBOOKINGMASTER.BOOKING_PURGRANDTOTAL} < " & Val(TXTPURGREATER.Text.Trim)
                If Val(TXTPURLESS.Text.Trim) > 0 Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " AND {HOTELBOOKINGMASTER.BOOKING_PURGRANDTOTAL} < " & Val(TXTPURLESS.Text.Trim)

                If CHKCANCELLED.CheckState = CheckState.Checked Then
                    OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " AND {HOTELBOOKINGMASTER.BOOKING_CANCELLED} = " & True
                Else
                    OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " AND {HOTELBOOKINGMASTER.BOOKING_CANCELLED} = " & False
                End If

                If CHKAMENDED.CheckState = CheckState.Checked Then
                    OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " AND {HOTELBOOKINGMASTER.BOOKING_AMD_DONE} = " & True
                Else
                    OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " AND {HOTELBOOKINGMASTER.BOOKING_AMD_DONE} = " & False
                End If


                If chkdate.Checked = True Then
                    getFromToDate()
                    OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " and ({@BOOKDATE} in date " & fromD & " to date " & toD & ")"
                    OBJRESERVATION.PERIOD = "From - " & Format(dtfrom.Value.Date, "dd-MM-yyyy") & " To - " & Format(dtto.Value.Date, "dd-MM-yyyy")
                Else
                    OBJRESERVATION.PERIOD = "From - " & Format(AccFrom, "dd-MM-yyyy") & "  To - " & Format(AccTo, "dd-MM-yyyy")
                End If


                If CHKARRDATE.Checked = True Then
                    getFromToDateARR()
                    OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " and ({@ARRIVAL} in date " & fromD & " to date " & toD & ")"
                End If


            ElseIf FRMSTRING = "PACKAGE DETAILS" Or FRMSTRING = "PACKAGE SUMMARY" Then
                'FOR HOLIDAYPACKAGEBOOKING

                OBJRESERVATION.strsearch = " {HOLIDAYPACKAGEMASTER.BOOKING_CMPID}= " & CmpId & " AND {HOLIDAYPACKAGEMASTER.BOOKING_LOCATIONID}= " & Locationid & " AND {HOLIDAYPACKAGEMASTER.BOOKING_YEARID}=" & YearId


                'If CMBGUESTNAME.Text.Trim <> "" Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & "  AND {GUESTMASTER.GUEST_NAME}= '" & CMBGUESTNAME.Text.Trim & "'"
                'If CMBHOTELNAME.Text.Trim <> "" Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & "  AND {HOTELMASTER.HOTEL_NAME}= '" & CMBHOTELNAME.Text.Trim & "'"
                'If CMBPURNAME.Text.Trim <> "" Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & "  AND {PURLEDGER.ACC_CMPNAME}= '" & CMBPURNAME.Text.Trim & "'"
                If CMBGROUPOFHOTELS.Text.Trim <> "" Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & "  AND {GROUPOFHOTELSMASTER.GROUPOFHOTELS_NAME}= '" & CMBGROUPOFHOTELS.Text.Trim & "'"
                If CMBNAME.Text.Trim <> "" Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & "  AND {LEDGERS.ACC_CMPNAME}= '" & CMBNAME.Text.Trim & "'"
                If CMBBOOKEDBY.Text.Trim <> "" Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " AND {BOOKEDBYMASTER.BOOKEDBY_NAME}= '" & CMBBOOKEDBY.Text.Trim & "'"
                If CMBBOOKINGNO.Text.Trim <> "" Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " AND {HOTELBOOKINGMASTER.BOOKING_SALEBILLINITIALS}= '" & CMBBOOKINGNO.Text.Trim & "'"
                If CMBPACKAGETYPE.Text.Trim <> "" Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " AND {HOLIDAYPACKAGEMASTER.BOOKING_PACKAGETYPE}= '" & CMBPACKAGETYPE.Text.Trim & "'"

                If Val(TXTSALEGREATER.Text.Trim) > 0 Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " AND {HOLIDAYPACKAGEMASTER.BOOKING_GRANDTOTAL} > " & Val(TXTSALEGREATER.Text.Trim)
                If Val(TXTSALELESS.Text.Trim) > 0 Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " AND {HOLIDAYPACKAGEMASTER.BOOKING_GRANDTOTAL} < " & Val(TXTSALELESS.Text.Trim)

                If Val(TXTPURGREATER.Text.Trim) > 0 Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " AND {HOLIDAYPACKAGEMASTER.BOOKING_TOTALPURAMT} < " & Val(TXTPURGREATER.Text.Trim)
                If Val(TXTPURLESS.Text.Trim) > 0 Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " AND {HOLIDAYPACKAGEMASTER.BOOKING_TOTALPURAMT} < " & Val(TXTPURLESS.Text.Trim)

                If CHKCANCELLED.CheckState = CheckState.Checked Then
                    OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " AND {HOLIDAYPACKAGEMASTER.BOOKING_CANCELLED} = " & True
                Else
                    OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " AND {HOLIDAYPACKAGEMASTER.BOOKING_CANCELLED} = " & False
                End If

                If CHKAMENDED.CheckState = CheckState.Checked Then
                    OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " AND {HOLIDAYPACKAGEMASTER.BOOKING_AMD_DONE} = " & True
                Else
                    OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " AND {HOLIDAYPACKAGEMASTER.BOOKING_AMD_DONE} = " & False
                End If


                If chkdate.Checked = True Then
                    getFromToDate()
                    OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " and ({@DATE} in date " & fromD & " to date " & toD & ")"
                    OBJRESERVATION.PERIOD = "From - " & Format(dtfrom.Value.Date, "dd-MM-yyyy") & " To - " & Format(dtto.Value.Date, "dd-MM-yyyy")
                Else
                    OBJRESERVATION.PERIOD = "From - " & Format(AccFrom, "dd-MM-yyyy") & "  To - " & Format(AccTo, "dd-MM-yyyy")
                End If


                'If CHKARRDATE.Checked = True Then
                '    getFromToDateARR()
                '    OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " and ({@ARRIVAL} in date " & fromD & " to date " & toD & ")"
                'End If


            ElseIf FRMSTRING = "INTERNATIONAL DETAILS" Or FRMSTRING = "INTERNATIONAL SUMMARY" Then
                'FOR INTERNATIONALPACKAGEBOOKING

                OBJRESERVATION.strsearch = " {INTERNATIONALBOOKINGMASTER.BOOKING_CMPID}= " & CmpId & " AND {INTERNATIONALBOOKINGMASTER.BOOKING_LOCATIONID}= " & Locationid & " AND {INTERNATIONALBOOKINGMASTER.BOOKING_YEARID}=" & YearId


                'If CMBGUESTNAME.Text.Trim <> "" Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & "  AND {GUESTMASTER.GUEST_NAME}= '" & CMBGUESTNAME.Text.Trim & "'"
                'If CMBHOTELNAME.Text.Trim <> "" Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & "  AND {HOTELMASTER.HOTEL_NAME}= '" & CMBHOTELNAME.Text.Trim & "'"
                'If CMBPURNAME.Text.Trim <> "" Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & "  AND {PURLEDGER.ACC_CMPNAME}= '" & CMBPURNAME.Text.Trim & "'"
                If CMBGROUPOFHOTELS.Text.Trim <> "" Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & "  AND {GROUPOFHOTELSMASTER.GROUPOFHOTELS_NAME}= '" & CMBGROUPOFHOTELS.Text.Trim & "'"
                If CMBNAME.Text.Trim <> "" Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & "  AND {LEDGERS.ACC_CMPNAME}= '" & CMBNAME.Text.Trim & "'"
                If CMBBOOKEDBY.Text.Trim <> "" Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " AND {BOOKEDBYMASTER.BOOKEDBY_NAME}= '" & CMBBOOKEDBY.Text.Trim & "'"
                If CMBBOOKINGNO.Text.Trim <> "" Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " AND {INTERNATIONALBOOKINGMASTER.BOOKING_SALEBILLINITIALS}= '" & CMBBOOKINGNO.Text.Trim & "'"

                If Val(TXTSALEGREATER.Text.Trim) > 0 Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " AND {INTERNATIONALBOOKINGMASTER.BOOKING_GRANDTOTAL} > " & Val(TXTSALEGREATER.Text.Trim)
                If Val(TXTSALELESS.Text.Trim) > 0 Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " AND {INTERNATIONALBOOKINGMASTER.BOOKING_GRANDTOTAL} < " & Val(TXTSALELESS.Text.Trim)

                If Val(TXTPURGREATER.Text.Trim) > 0 Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " AND {INTERNATIONALBOOKINGMASTER.BOOKING_TOTALPURAMT} < " & Val(TXTPURGREATER.Text.Trim)
                If Val(TXTPURLESS.Text.Trim) > 0 Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " AND {INTERNATIONALBOOKINGMASTER.BOOKING_TOTALPURAMT} < " & Val(TXTPURLESS.Text.Trim)

                If CHKCANCELLED.CheckState = CheckState.Checked Then
                    OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " AND {INTERNATIONALBOOKINGMASTER.BOOKING_CANCELLED} = " & True
                Else
                    OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " AND {INTERNATIONALBOOKINGMASTER.BOOKING_CANCELLED} = " & False
                End If

                If CHKAMENDED.CheckState = CheckState.Checked Then
                    OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " AND {INTERNATIONALBOOKINGMASTER.BOOKING_AMD_DONE} = " & True
                Else
                    OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " AND {INTERNATIONALBOOKINGMASTER.BOOKING_AMD_DONE} = " & False
                End If


                If chkdate.Checked = True Then
                    getFromToDate()
                    OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " and ({@DATE} in date " & fromD & " to date " & toD & ")"
                    OBJRESERVATION.PERIOD = "From - " & Format(dtfrom.Value.Date, "dd-MM-yyyy") & " To - " & Format(dtto.Value.Date, "dd-MM-yyyy")
                Else
                    OBJRESERVATION.PERIOD = "From - " & Format(AccFrom, "dd-MM-yyyy") & "  To - " & Format(AccTo, "dd-MM-yyyy")
                End If


                'If CHKARRDATE.Checked = True Then
                '    getFromToDateARR()
                '    OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " and ({@ARRIVAL} in date " & fromD & " to date " & toD & ")"
                'End If



            ElseIf FRMSTRING = "VEHICLE DETAILS" Or FRMSTRING = "VEHICLE SUMMARY" Then
                'FOR CARBOOKINGMASTER
                OBJRESERVATION.strsearch = "  {CARBOOKINGMASTER.BOOKING_CMPID}= " & CmpId & " AND {CARBOOKINGMASTER.BOOKING_LOCATIONID}= " & Locationid & " AND {CARBOOKINGMASTER.BOOKING_YEARID}=" & YearId


                If CMBGUESTNAME.Text.Trim <> "" Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & "  AND {GUESTMASTER.GUEST_NAME}= '" & CMBGUESTNAME.Text.Trim & "'"
                If CMBHOTELNAME.Text.Trim <> "" Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & "  AND {HOTELMASTER.HOTEL_NAME}= '" & CMBHOTELNAME.Text.Trim & "'"
                If CMBGROUPOFHOTELS.Text.Trim <> "" Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & "  AND {GROUPOFHOTELSMASTER.GROUPOFHOTELS_NAME}= '" & CMBGROUPOFHOTELS.Text.Trim & "'"
                If CMBPURNAME.Text.Trim <> "" Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & "  AND {PURLEDGER.ACC_CMPNAME}= '" & CMBPURNAME.Text.Trim & "'"
                If CMBNAME.Text.Trim <> "" Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & "  AND {LEDGERS.ACC_CMPNAME}= '" & CMBNAME.Text.Trim & "'"
                If CMBBOOKEDBY.Text.Trim <> "" Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " AND {BOOKEDBYMASTER.BOOKEDBY_NAME}= '" & CMBBOOKEDBY.Text.Trim & "'"
                If CMBBOOKINGNO.Text.Trim <> "" Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " AND {CARBOOKINGMASTER.BOOKING_SALEBILLINITIALS}= '" & CMBBOOKINGNO.Text.Trim & "'"
                If CMBCONFIRMEDBY.Text.Trim <> "" Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " AND {CARBOOKINGMASTER.BOOKING_CONFIRMEDBY}= '" & CMBCONFIRMEDBY.Text.Trim & "'"

                If Val(TXTSALEGREATER.Text.Trim) > 0 Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " AND {CARBOOKINGMASTER.BOOKING_GRANDTOTAL} > " & Val(TXTSALEGREATER.Text.Trim)
                If Val(TXTSALELESS.Text.Trim) > 0 Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " AND {CARBOOKINGMASTER.BOOKING_GRANDTOTAL} < " & Val(TXTSALELESS.Text.Trim)

                If Val(TXTPURGREATER.Text.Trim) > 0 Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " AND {CARBOOKINGMASTER.BOOKING_PURGRANDTOTAL} < " & Val(TXTPURGREATER.Text.Trim)
                If Val(TXTPURLESS.Text.Trim) > 0 Then OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " AND {CARBOOKINGMASTER.BOOKING_PURGRANDTOTAL} < " & Val(TXTPURLESS.Text.Trim)

                If CHKCANCELLED.CheckState = CheckState.Checked Then
                    OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " AND {CARBOOKINGMASTER.BOOKING_CANCELLED} = " & True
                Else
                    OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " AND {CARBOOKINGMASTER.BOOKING_CANCELLED} = " & False
                End If

                If CHKAMENDED.CheckState = CheckState.Checked Then
                    OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " AND {CARBOOKINGMASTER.BOOKING_AMD_DONE} = " & True
                Else
                    OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " AND {CARBOOKINGMASTER.BOOKING_AMD_DONE} = " & False
                End If


                If chkdate.Checked = True Then
                    getFromToDate()
                    OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " and ({@BOOKDATE} in date " & fromD & " to date " & toD & ")"
                    OBJRESERVATION.PERIOD = "From - " & Format(dtfrom.Value.Date, "dd-MM-yyyy") & " To - " & Format(dtto.Value.Date, "dd-MM-yyyy")
                Else
                    OBJRESERVATION.PERIOD = "From - " & Format(AccFrom, "dd-MM-yyyy") & "  To - " & Format(AccTo, "dd-MM-yyyy")
                End If


                If CHKARRDATE.Checked = True Then
                    getFromToDateARR()
                    OBJRESERVATION.strsearch = OBJRESERVATION.strsearch & " and ({@ARRIVAL} in date " & fromD & " to date " & toD & ")"
                End If

            End If

            OBJRESERVATION.Show()
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
            Dim DT As New DataTable
            If FRMSTRING = "VEHICLESALE" Or FRMSTRING = "VEHICLEPUR" Or FRMSTRING = "VEHICLEINVOICE" Or FRMSTRING = "VEHICLEOUTSTANDING" Then
                DT = OBJCMN.search(" BOOKING_SALEBILLINITIALS AS BOOKINGNO ", "", " CARBOOKINGMASTER", " AND BOOKING_YEARID = " & YearId & " ORDER BY BOOKING_NO")
            Else
                DT = OBJCMN.search(" BOOKING_SALEBILLINITIALS AS BOOKINGNO ", "", " HOTELBOOKINGMASTER", " AND BOOKING_CMPID = " & CmpId & " AND BOOKING_LOCATIONID = " & Locationid & " AND BOOKING_YEARID = " & YearId & " ORDER BY BOOKING_BOOKTYPE, BOOKING_NO")
            End If
            If DT.Rows.Count > 0 Then
                CMBBOOKINGNO.DataSource = DT
                CMBBOOKINGNO.DisplayMember = "BOOKINGNO"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReservationFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKSELECTALLCMP_CheckedChanged(sender As Object, e As EventArgs) Handles CHKSELECTALLCMP.CheckedChanged
        If CHKSELECTALLCMP.Checked = True Then
            For i As Integer = 0 To LSTCMP.Items.Count - 1
                LSTCMP.SetItemChecked(i, True)
            Next
        Else
            For i As Integer = 0 To LSTCMP.Items.Count - 1
                LSTCMP.SetItemChecked(i, False)
            Next
        End If
    End Sub

    Private Sub ReservationFilter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ACCOUNT REPORTS'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If FRMSTRING = "DETAILS" Then
                Me.Text = "Reservation Details"
            ElseIf FRMSTRING = "SUMMARY" Then
                Me.Text = "Reservation Summary"
            End If

            Dim OBJCMN As New ClsCommon
            Dim dt As DataTable = OBJCMN.search("CMP_NAME", "", "CMPMASTER", "")
            For Each DROW As DataRow In dt.Rows
                LSTCMP.Items.Add(DROW(0).ToString)
                If DROW(0) = CmpName Then LSTCMP.SetItemChecked(LSTCMP.Items.Count - 1, True)
            Next
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
                Dim DT As DataTable = OBJCMN.search(" DISTINCT CONFIRMEDBY", "", " RESERVATION_SALEREPORT ", " AND CMPID = " & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId & " ORDER BY CONFIRMEDBY")
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

    Private Sub RBSELECTED_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBSELECTED.CheckedChanged
        gridbilldetails.Visible = True
        FILLGRID()
    End Sub

    Sub FILLGRID()
        Try
            Dim OBJCMN As New ClsCommonMaster
            Dim dt As New DataTable
            Dim CMPCLAUSE As String = ""
            Dim CHECKED_CMP As CheckedListBox.CheckedItemCollection = LSTCMP.CheckedItems
            For Each item As Object In CHECKED_CMP
                If CMPCLAUSE = "" Then
                    CMPCLAUSE = "'" & item.ToString() & "'"
                Else
                    CMPCLAUSE = CMPCLAUSE & ",'" & item.ToString() & "'"
                End If
            Next item
            dt = OBJCMN.search("cmp_id AS CMPID ,year_id AS YEARID", "", " CMPMASTER inner join YEARMASTER ON YEAR_CMPID = CMP_ID", " AND YEAR_STARTDATE = '" & Format(AccFrom.Date, "MM/dd/yyyy") & "' AND CMP_NAME IN (" & CMPCLAUSE & ")")
            CMPCLAUSE = ""
            For Each DTROW As DataRow In dt.Rows
                If CMPCLAUSE = "" Then CMPCLAUSE = DTROW("YEARID") Else CMPCLAUSE = CMPCLAUSE & "," & DTROW("YEARID")
            Next

            'OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND YEARID IN (" & CMPCLAUSE & ")"

            dt = OBJCMN.search(" DISTINCT CAST (0 AS BIT) AS CHK,LEDGERS.Acc_cmpname AS NAME, GROUPMASTER.group_secondary AS UNDER, ISNULL(CATEGORYMASTER.CATEGORY_NAME,'') AS CATEGORY ", " ", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN CATEGORYMASTER ON LEDGERS.ACC_CATEGORYID = CATEGORYMASTER.CATEGORY_ID ", " AND GROUPMASTER.GROUP_SECONDARY = 'Sundry Debtors' AND LEDGERS.ACC_YEARID IN (" & CMPCLAUSE & ") ORDER BY LEDGERS.Acc_cmpname")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        gridbilldetails.Visible = False
    End Sub

    Private Sub CHKSELECTALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKSELECTALL.CheckedChanged
        Try
            If gridbilldetails.Visible = True Then
                For i As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                    dtrow("CHK") = CHKSELECTALL.Checked
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSHOWDETAILS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSHOWDETAILS.Click
        Try
            Dim NAMECLAUSE As String = ""
            If RBSELECTED.Checked = True Then
                gridbill.ClearColumnsFilter()
                For i As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        If NAMECLAUSE = "" Then
                            If FRMSTRING = "VEHICLESALE" Or FRMSTRING = "VEHICLEPUR" Or FRMSTRING = "VEHICLEINVOICE" Or FRMSTRING = "VEHICLEOUTSTANDING" Then
                                NAMECLAUSE = " AND (LEDGERS.ACC_CMPNAME = '" & dtrow("NAME") & "'"
                            Else
                                NAMECLAUSE = " AND (SALELEDGER = '" & dtrow("NAME") & "'"
                            End If
                        Else
                            If FRMSTRING = "VEHICLESALE" Or FRMSTRING = "VEHICLEPUR" Or FRMSTRING = "VEHICLEINVOICE" Or FRMSTRING = "VEHICLEOUTSTANDING" Then
                                NAMECLAUSE = NAMECLAUSE & " OR LEDGERS.ACC_CMPNAME = '" & dtrow("NAME") & "'"
                            Else
                                NAMECLAUSE = NAMECLAUSE & " OR SALELEDGER = '" & dtrow("NAME") & "'"
                            End If
                        End If
                    End If
                Next
                If NAMECLAUSE <> "" Then NAMECLAUSE = NAMECLAUSE & ")"
            End If

            If FRMSTRING = "VEHICLESALE" Then
                Dim OBJREPORT As New CarBookingSaleGridReport
                OBJREPORT.FRMSTRING = FRMSTRING
                OBJREPORT.MdiParent = MDIMain
                OBJREPORT.WHERECLAUSE = NAMECLAUSE & " AND CARBOOKINGMASTER.BOOKING_YEARID = " & YearId
                If CMBGUESTNAME.Text.Trim <> "" Then OBJREPORT.WHERECLAUSE = OBJREPORT.WHERECLAUSE & " AND GUEST_NAME = '" & CMBGUESTNAME.Text.Trim & "'"
                If CMBHOTELNAME.Text.Trim <> "" Then OBJREPORT.WHERECLAUSE = OBJREPORT.WHERECLAUSE & " AND VEHICLE_NAME = '" & CMBHOTELNAME.Text.Trim & "'"
                If CMBNAME.Text.Trim <> "" Then OBJREPORT.WHERECLAUSE = OBJREPORT.WHERECLAUSE & " AND LEDGERS.ACC_CMPNAME = '" & CMBNAME.Text.Trim & "'"
                If chkdate.CheckState = CheckState.Checked Then OBJREPORT.WHERECLAUSE = OBJREPORT.WHERECLAUSE & " AND CARBOOKINGMASTER.BOOKING_PACKAGEFROM >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND CARBOOKINGMASTER.BOOKING_PACKAGEFROM <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"
                OBJREPORT.Show()
                Exit Sub
            End If

            If FRMSTRING = "VEHICLEPUR" Then
                Dim OBJREPORT As New CarBookingPurGridReport
                OBJREPORT.FRMSTRING = FRMSTRING
                OBJREPORT.MdiParent = MDIMain
                OBJREPORT.WHERECLAUSE = NAMECLAUSE & " AND CARBOOKINGMASTER.BOOKING_YEARID = " & YearId
                If CMBGUESTNAME.Text.Trim <> "" Then OBJREPORT.WHERECLAUSE = OBJREPORT.WHERECLAUSE & " AND GUEST_NAME = '" & CMBGUESTNAME.Text.Trim & "'"
                If CMBHOTELNAME.Text.Trim <> "" Then OBJREPORT.WHERECLAUSE = OBJREPORT.WHERECLAUSE & " AND VEHICLE_NAME = '" & CMBHOTELNAME.Text.Trim & "'"
                If CMBPURNAME.Text.Trim <> "" Then OBJREPORT.WHERECLAUSE = OBJREPORT.WHERECLAUSE & " AND PURLEDGERS.ACC_CMPNAME = '" & CMBPURNAME.Text.Trim & "'"
                If CMBNAME.Text.Trim <> "" Then OBJREPORT.WHERECLAUSE = OBJREPORT.WHERECLAUSE & " AND LEDGERS.ACC_CMPNAME = '" & CMBNAME.Text.Trim & "'"
                If chkdate.CheckState = CheckState.Checked Then OBJREPORT.WHERECLAUSE = OBJREPORT.WHERECLAUSE & " AND CARBOOKINGMASTER.BOOKING_PACKAGEFROM >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND CARBOOKINGMASTER.BOOKING_PACKAGEFROM <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"
                OBJREPORT.Show()
                Exit Sub
            End If

            If FRMSTRING = "VEHICLEINVOICE" Then
                Dim OBJREPORT As New CarBookingInvoiceDetailsGridReport
                OBJREPORT.FRMSTRING = FRMSTRING
                OBJREPORT.MdiParent = MDIMain
                OBJREPORT.WHERECLAUSE = NAMECLAUSE & " AND CARBOOKINGMASTER.BOOKING_YEARID = " & YearId
                If CMBGUESTNAME.Text.Trim <> "" Then OBJREPORT.WHERECLAUSE = OBJREPORT.WHERECLAUSE & " AND GUEST_NAME = '" & CMBGUESTNAME.Text.Trim & "'"
                If CMBHOTELNAME.Text.Trim <> "" Then OBJREPORT.WHERECLAUSE = OBJREPORT.WHERECLAUSE & " AND VEHICLE_NAME = '" & CMBHOTELNAME.Text.Trim & "'"
                If CMBNAME.Text.Trim <> "" Then OBJREPORT.WHERECLAUSE = OBJREPORT.WHERECLAUSE & " AND LEDGERS.ACC_CMPNAME = '" & CMBNAME.Text.Trim & "'"
                If chkdate.CheckState = CheckState.Checked Then OBJREPORT.WHERECLAUSE = OBJREPORT.WHERECLAUSE & " AND CARBOOKINGMASTER.BOOKING_PACKAGEFROM >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND CARBOOKINGMASTER.BOOKING_PACKAGEFROM <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"
                OBJREPORT.Show()
                Exit Sub
            End If

            If FRMSTRING = "VEHICLEOUTSTANDING" Then
                Dim OBJREPORT As New CarBookingOutstandingGridReport
                OBJREPORT.FRMSTRING = FRMSTRING
                OBJREPORT.MdiParent = MDIMain
                OBJREPORT.WHERECLAUSE = NAMECLAUSE
                If CMBGUESTNAME.Text.Trim <> "" Then OBJREPORT.WHERECLAUSE = OBJREPORT.WHERECLAUSE & " AND GUEST_NAME = '" & CMBGUESTNAME.Text.Trim & "'"
                If CMBHOTELNAME.Text.Trim <> "" Then OBJREPORT.WHERECLAUSE = OBJREPORT.WHERECLAUSE & " AND VEHICLE_NAME = '" & CMBHOTELNAME.Text.Trim & "'"
                If CMBNAME.Text.Trim <> "" Then OBJREPORT.WHERECLAUSE = OBJREPORT.WHERECLAUSE & " AND LEDGERS.ACC_CMPNAME = '" & CMBNAME.Text.Trim & "'"
                If chkdate.CheckState = CheckState.Checked Then OBJREPORT.WHERECLAUSE = OBJREPORT.WHERECLAUSE & " AND CARBOOKINGMASTER.BOOKING_PACKAGEFROM >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND CARBOOKINGMASTER.BOOKING_PACKAGEFROM <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"
                OBJREPORT.Show()
                Exit Sub
            End If


            Dim OBJRESERVATION As New ReservationDetails

            OBJRESERVATION.STRSEARCH = NAMECLAUSE & " AND TYPE <> 'OPENING'"

            If FRMSTRING = "DETAILS" Or FRMSTRING = "SUMMARY" Then
                OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND TYPE = 'HOTELBOOKING'"
            ElseIf FRMSTRING = "PACKAGE DETAILS" Or FRMSTRING = "PACKAGE SUMMARY" Then
                OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND TYPE = 'HOLIDAYPACKAGE'"
            ElseIf FRMSTRING = "INTERNATIONAL DETAILS" Or FRMSTRING = "INTERNATIONAL SUMMARY" Then
                OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND TYPE = 'INTERNATIONALBOOKING'"
            ElseIf FRMSTRING = "RAIL DETAILS" Or FRMSTRING = "RAIL SUMMARY" Then
                OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND TYPE = 'RAILBOOKING'"
            ElseIf FRMSTRING = "VEHICLE DETAILS" Or FRMSTRING = "VEHICLE SUMMARY" Then
                OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND TYPE = 'CARBOOKING'"
            End If


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

            OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND YEARID IN (" & CMPCLAUSE & ")"

            If CMBGUESTNAME.Text.Trim <> "" Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & "  AND GUESTNAME = '" & CMBGUESTNAME.Text.Trim & "'"
            If CMBHOTELNAME.Text.Trim <> "" Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & "  AND HOTELNAME = '" & CMBHOTELNAME.Text.Trim & "'"
            If CMBGROUPOFHOTELS.Text.Trim <> "" Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & "  AND GROUPOFHOTELS = '" & CMBGROUPOFHOTELS.Text.Trim & "'"
            If CMBPURNAME.Text.Trim <> "" Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & "  AND PURLEDGER = '" & CMBPURNAME.Text.Trim & "'"
            If CMBNAME.Text.Trim <> "" Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & "  AND SALELEDGER = '" & CMBNAME.Text.Trim & "'"
            If CMBBOOKEDBY.Text.Trim <> "" Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND BOOKEDBY = '" & CMBBOOKEDBY.Text.Trim & "'"
            If CMBBOOKINGNO.Text.Trim <> "" Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND BOOKINGNO = '" & CMBBOOKINGNO.Text.Trim & "'"
            If CMBCONFIRMEDBY.Text.Trim <> "" Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND CONFIRMEDBY = '" & CMBCONFIRMEDBY.Text.Trim & "'"
            If CMBPACKAGETYPE.Text.Trim <> "" Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND DOMINT = '" & CMBPACKAGETYPE.Text.Trim & "'"

            If Val(TXTSALEBAL.Text.Trim) > 0 Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND SALEBAL > " & Val(TXTSALEBAL.Text.Trim)
            If Val(TXTSALEGREATER.Text.Trim) > 0 Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND SALEAMT > " & Val(TXTSALEGREATER.Text.Trim)
            If Val(TXTSALELESS.Text.Trim) > 0 Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND SALEAMT < " & Val(TXTSALELESS.Text.Trim)

            If Val(TXTPURGREATER.Text.Trim) > 0 Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND PURAMT < " & Val(TXTPURGREATER.Text.Trim)
            If Val(TXTPURLESS.Text.Trim) > 0 Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND PURAMT < " & Val(TXTPURLESS.Text.Trim)

            If CHKCANCELLED.CheckState = CheckState.Checked Then
                OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND CAST(CANCELLED AS BIT) = '" & True & "'"
            Else
                OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND CAST(CANCELLED AS BIT) = '" & False & "'"
            End If

            If CHKAMENDED.CheckState = CheckState.Checked Then
                OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND CAST( AMENDED AS BIT) = '" & True & "'"
            Else
                OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND CAST(AMENDED AS BIT) = '" & False & "'"
            End If

            If chkdate.Checked = True Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " and DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"

            If CHKARRDATE.Checked = True Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " and ARRIVAL >= '" & Format(ARRIVALFROM.Value.Date, "MM/dd/yyyy") & "' AND ARRIVAL <= '" & Format(ARRIVALTO.Value.Date, "MM/dd/yyyy") & "'"

            If ClientName = "CLASSIC" And UserName <> "Admin" Then If USERVIEW = False Then OBJRESERVATION.STRSEARCH = OBJRESERVATION.STRSEARCH & " AND BOOKEDBY = '" & UserName & "' "

            OBJRESERVATION.FRMSTRING = FRMSTRING
            OBJRESERVATION.MdiParent = MDIMain
            OBJRESERVATION.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReservationFilter_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If FRMSTRING = "VEHICLESALE" Or FRMSTRING = "VEHICLEPUR" Or FRMSTRING = "VEHICLEINVOICE" Or FRMSTRING = "VEHICLEOUTSTANDING" Then
                LBLHOTELNAME.Text = "Vehicle Name"
                CHKCANCELLED.Visible = False
                CHKAMENDED.Visible = False
                CHKARRDATE.Visible = False
                GROUPARRIVAL.Visible = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class