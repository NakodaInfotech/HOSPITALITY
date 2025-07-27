

Imports BL

Public Class MDIMain

    Sub SCROLLERS()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            Dim WHERECLAUSE As String

            LBLCHECKIN.Left = Me.Width
            LBLCHECKIN.Top = StatusStrip2.Top + 2
            CHECKIN_CMD.Top = StatusStrip2.Top - 4

            dt = objclsCMST.search("ISNULL(CHECKIN_DAYS,0) AS DAYS", "", "CHECKINDAYS ", WHERECLAUSE & " AND CHECKINDAYS.CHECKIN_CMPID =" & CmpId & " ")

            If dt.Rows.Count > 0 Then
                WHERECLAUSE = " AND T.ARRIVAL = '" & Format(DateAdd(DateInterval.Day, Val(dt.Rows(0).Item("DAYS")), Mydate), "MM/dd/yyyy") & "' "
            Else
                WHERECLAUSE = " AND T.ARRIVAL = '" & Format(DateAdd(DateInterval.Day, 1, Mydate), "MM/dd/yyyy") & "' "
            End If

            'Dim WHERECLAUSE As String = " AND T.ARRIVAL = '" & Format(DateAdd(DateInterval.Day, 1, Mydate), "MM/dd/yyyy") & "' "
            Dim CHECKINNAMES As String = "There is No Check In for Tomorrow."
            'Dim objclsCMST As New ClsCommonMaster
            'Dim dt As DataTable = objclsCMST.search("*", "", " (SELECT CAST(0 AS BIT) AS CHK, HOTELBOOKINGMASTER.BOOKING_NO  AS SRNO, HOTELBOOKINGMASTER.BOOKING_SALEBILLINITIALS  AS BOOKINGNO, HOTELBOOKINGMASTER.BOOKING_REFNO AS REFNO, HOTELBOOKINGMASTER.BOOKING_DATE AS [DATE], GUESTMASTER.GUEST_NAME AS GUESTNAME , HOTELMASTER.HOTEL_NAME AS HOTELNAME,  HOTELBOOKINGMASTER.BOOKING_ARRIVAL AS ARRIVAL, HOTELBOOKINGMASTER.BOOKING_DEPARTURE AS DEPARTURE, HOTELBOOKINGMASTER.BOOKING_PICKUPDETAILS AS PICKUPDETAILS, BOOKEDBYMASTER.BOOKEDBY_NAME aS BOOKEDBY, BOOKING_SALEBALANCE AS BALANCE, BOOKING_BOOKTYPE AS TYPE , BOOKING_CMPID AS CMPID, BOOKING_LOCATIONID AS LOCATIONID, BOOKING_YEARID AS YEARID FROM HOTELBOOKINGMASTER INNER JOIN GUESTMASTER ON HOTELBOOKINGMASTER.BOOKING_GUESTID = GUESTMASTER.GUEST_ID AND HOTELBOOKINGMASTER.BOOKING_CMPID = GUESTMASTER.GUEST_CMPID AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = GUESTMASTER.GUEST_LOCATIONID AND HOTELBOOKINGMASTER.BOOKING_YEARID = GUESTMASTER.GUEST_YEARID INNER JOIN HOTELMASTER ON HOTELBOOKINGMASTER.BOOKING_CMPID = HOTELMASTER.HOTEL_CMPID AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = HOTELMASTER.HOTEL_LOCATIONID AND HOTELBOOKINGMASTER.BOOKING_YEARID = HOTELMASTER.HOTEL_YEARID AND HOTELBOOKINGMASTER.BOOKING_HOTELID = HOTELMASTER.HOTEL_ID INNER JOIN BOOKEDBYMASTER ON HOTELBOOKINGMASTER.BOOKING_BOOKEDBYID = BOOKEDBYMASTER.BOOKEDBY_ID AND HOTELBOOKINGMASTER.BOOKING_CMPID = BOOKEDBYMASTER.BOOKEDBY_CMPID AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = BOOKEDBYMASTER.BOOKEDBY_LOCATIONID AND HOTELBOOKINGMASTER.BOOKING_YEARID = BOOKEDBYMASTER.BOOKEDBY_YEARID WHERE BOOKING_CANCELLED = 'FALSE' AND BOOKING_SALERETURN = 0  AND BOOKING_AMD_DONE = 0  UNION ALL SELECT   CAST (0 AS BIT) AS CHK, HOLIDAYPACKAGEMASTER.BOOKING_NO AS SRNO, HOLIDAYPACKAGEMASTER.BOOKING_SALEBILLINITIALS, HOLIDAYPACKAGEMASTER.BOOKING_REFNO, HOLIDAYPACKAGEMASTER.BOOKING_DATE, HOLIDAYPACKAGEMASTER.BOOKING_TOURNAME, HOTELMASTER.HOTEL_NAME, HOLIDAYPACKAGEMASTER_DESC.BOOKING_ARRIVALDATE, HOLIDAYPACKAGEMASTER_DESC.BOOKING_DEPARTUREDATE, HOLIDAYPACKAGEMASTER.BOOKING_PICKUPDETAILS, BOOKEDBYMASTER.BOOKEDBY_NAME, HOLIDAYPACKAGEMASTER.BOOKING_SALEBALANCE, 'HOLIDAYPACKAGE' AS TYPE, HOLIDAYPACKAGEMASTER.BOOKING_CMPID AS CMPID, HOLIDAYPACKAGEMASTER.BOOKING_LOCATIONID AS LOCATIONID, HOLIDAYPACKAGEMASTER.BOOKING_YEARID AS YEARID FROM HOLIDAYPACKAGEMASTER_DESC INNER JOIN HOLIDAYPACKAGEMASTER ON HOLIDAYPACKAGEMASTER_DESC.BOOKING_NO = HOLIDAYPACKAGEMASTER.BOOKING_NO AND HOLIDAYPACKAGEMASTER_DESC.BOOKING_CMPID = HOLIDAYPACKAGEMASTER.BOOKING_CMPID AND HOLIDAYPACKAGEMASTER_DESC.BOOKING_LOCATIONID = HOLIDAYPACKAGEMASTER.BOOKING_LOCATIONID AND HOLIDAYPACKAGEMASTER_DESC.BOOKING_YEARID = HOLIDAYPACKAGEMASTER.BOOKING_YEARID INNER JOIN BOOKEDBYMASTER ON HOLIDAYPACKAGEMASTER.BOOKING_CMPID = BOOKEDBYMASTER.BOOKEDBY_CMPID AND HOLIDAYPACKAGEMASTER.BOOKING_LOCATIONID = BOOKEDBYMASTER.BOOKEDBY_LOCATIONID AND HOLIDAYPACKAGEMASTER.BOOKING_YEARID = BOOKEDBYMASTER.BOOKEDBY_YEARID AND HOLIDAYPACKAGEMASTER.BOOKING_BOOKEDBYID = BOOKEDBYMASTER.BOOKEDBY_ID INNER JOIN HOTELMASTER ON HOLIDAYPACKAGEMASTER_DESC.BOOKING_HOTELID = HOTELMASTER.HOTEL_ID AND HOLIDAYPACKAGEMASTER_DESC.BOOKING_CMPID = HOTELMASTER.HOTEL_CMPID AND HOLIDAYPACKAGEMASTER_DESC.BOOKING_LOCATIONID = HOTELMASTER.HOTEL_LOCATIONID AND HOLIDAYPACKAGEMASTER_DESC.BOOKING_YEARID = HotelMaster.HOTEL_YEARID WHERE HOLIDAYPACKAGEMASTER.BOOKING_CANCELLED= 'FALSE' AND HOLIDAYPACKAGEMASTER.BOOKING_AMD_DONE = 0 AND HOLIDAYPACKAGEMASTER.BOOKING_SALERETURN = 0) AS T ", WHERECLAUSE & " AND T.CMPID =" & CmpId & " ORDER BY T.SRNO")
            dt = objclsCMST.search("*", "", " (SELECT CAST(0 AS BIT) AS CHK, HOTELBOOKINGMASTER.BOOKING_NO  AS SRNO, HOTELBOOKINGMASTER.BOOKING_SALEBILLINITIALS  AS BOOKINGNO, HOTELBOOKINGMASTER.BOOKING_REFNO AS REFNO, HOTELBOOKINGMASTER.BOOKING_DATE AS [DATE], GUESTMASTER.GUEST_NAME AS GUESTNAME , HOTELMASTER.HOTEL_NAME AS HOTELNAME,  HOTELBOOKINGMASTER.BOOKING_ARRIVAL AS ARRIVAL, HOTELBOOKINGMASTER.BOOKING_DEPARTURE AS DEPARTURE, HOTELBOOKINGMASTER.BOOKING_PICKUPDETAILS AS PICKUPDETAILS, BOOKEDBYMASTER.BOOKEDBY_NAME aS BOOKEDBY, BOOKING_SALEBALANCE AS BALANCE, BOOKING_BOOKTYPE AS TYPE , BOOKING_CMPID AS CMPID, BOOKING_LOCATIONID AS LOCATIONID, BOOKING_YEARID AS YEARID FROM HOTELBOOKINGMASTER INNER JOIN GUESTMASTER ON HOTELBOOKINGMASTER.BOOKING_GUESTID = GUESTMASTER.GUEST_ID AND HOTELBOOKINGMASTER.BOOKING_CMPID = GUESTMASTER.GUEST_CMPID AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = GUESTMASTER.GUEST_LOCATIONID AND HOTELBOOKINGMASTER.BOOKING_YEARID = GUESTMASTER.GUEST_YEARID INNER JOIN HOTELMASTER ON HOTELBOOKINGMASTER.BOOKING_CMPID = HOTELMASTER.HOTEL_CMPID AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = HOTELMASTER.HOTEL_LOCATIONID AND HOTELBOOKINGMASTER.BOOKING_YEARID = HOTELMASTER.HOTEL_YEARID AND HOTELBOOKINGMASTER.BOOKING_HOTELID = HOTELMASTER.HOTEL_ID INNER JOIN BOOKEDBYMASTER ON HOTELBOOKINGMASTER.BOOKING_BOOKEDBYID = BOOKEDBYMASTER.BOOKEDBY_ID AND HOTELBOOKINGMASTER.BOOKING_CMPID = BOOKEDBYMASTER.BOOKEDBY_CMPID AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = BOOKEDBYMASTER.BOOKEDBY_LOCATIONID AND HOTELBOOKINGMASTER.BOOKING_YEARID = BOOKEDBYMASTER.BOOKEDBY_YEARID WHERE BOOKING_CANCELLED = 'FALSE' AND BOOKING_SALERETURN = 0  AND BOOKING_AMD_DONE = 0  UNION ALL SELECT   CAST (0 AS BIT) AS CHK, HOLIDAYPACKAGEMASTER.BOOKING_NO AS SRNO, HOLIDAYPACKAGEMASTER.BOOKING_SALEBILLINITIALS, HOLIDAYPACKAGEMASTER.BOOKING_REFNO, HOLIDAYPACKAGEMASTER.BOOKING_DATE, HOLIDAYPACKAGEMASTER.BOOKING_TOURNAME, HOTELMASTER.HOTEL_NAME, HOLIDAYPACKAGEMASTER_DESC.BOOKING_ARRIVALDATE, HOLIDAYPACKAGEMASTER_DESC.BOOKING_DEPARTUREDATE, HOLIDAYPACKAGEMASTER.BOOKING_PICKUPDETAILS, BOOKEDBYMASTER.BOOKEDBY_NAME, HOLIDAYPACKAGEMASTER.BOOKING_SALEBALANCE, 'HOLIDAYPACKAGE' AS TYPE, HOLIDAYPACKAGEMASTER.BOOKING_CMPID AS CMPID, HOLIDAYPACKAGEMASTER.BOOKING_LOCATIONID AS LOCATIONID, HOLIDAYPACKAGEMASTER.BOOKING_YEARID AS YEARID FROM HOLIDAYPACKAGEMASTER_DESC INNER JOIN HOLIDAYPACKAGEMASTER ON HOLIDAYPACKAGEMASTER_DESC.BOOKING_NO = HOLIDAYPACKAGEMASTER.BOOKING_NO AND HOLIDAYPACKAGEMASTER_DESC.BOOKING_CMPID = HOLIDAYPACKAGEMASTER.BOOKING_CMPID AND HOLIDAYPACKAGEMASTER_DESC.BOOKING_LOCATIONID = HOLIDAYPACKAGEMASTER.BOOKING_LOCATIONID AND HOLIDAYPACKAGEMASTER_DESC.BOOKING_YEARID = HOLIDAYPACKAGEMASTER.BOOKING_YEARID INNER JOIN BOOKEDBYMASTER ON HOLIDAYPACKAGEMASTER.BOOKING_CMPID = BOOKEDBYMASTER.BOOKEDBY_CMPID AND HOLIDAYPACKAGEMASTER.BOOKING_LOCATIONID = BOOKEDBYMASTER.BOOKEDBY_LOCATIONID AND HOLIDAYPACKAGEMASTER.BOOKING_YEARID = BOOKEDBYMASTER.BOOKEDBY_YEARID AND HOLIDAYPACKAGEMASTER.BOOKING_BOOKEDBYID = BOOKEDBYMASTER.BOOKEDBY_ID INNER JOIN HOTELMASTER ON HOLIDAYPACKAGEMASTER_DESC.BOOKING_HOTELID = HOTELMASTER.HOTEL_ID AND HOLIDAYPACKAGEMASTER_DESC.BOOKING_CMPID = HOTELMASTER.HOTEL_CMPID AND HOLIDAYPACKAGEMASTER_DESC.BOOKING_LOCATIONID = HOTELMASTER.HOTEL_LOCATIONID AND HOLIDAYPACKAGEMASTER_DESC.BOOKING_YEARID = HotelMaster.HOTEL_YEARID WHERE HOLIDAYPACKAGEMASTER.BOOKING_CANCELLED= 'FALSE' AND HOLIDAYPACKAGEMASTER.BOOKING_AMD_DONE = 0 AND HOLIDAYPACKAGEMASTER.BOOKING_SALERETURN = 0 UNION ALL SELECT CAST (0 AS BIT) AS CHK, AIRLINEBOOKINGMASTER.BOOKING_NO AS SRNO, AIRLINEBOOKINGMASTER.BOOKING_SALEBILLINITIALS AS BOOKINGNO, AIRLINEBOOKINGMASTER.BOOKING_REFNO AS REFNO, AIRLINEBOOKINGMASTER.BOOKING_DATE AS DATE, '' AS GUESTNAME, '' AS HOTELNAME, AIRLINEBOOKINGMASTER.BOOKING_TICKETDATE AS ARRIVAL, AIRLINEBOOKINGMASTER.BOOKING_TICKETDATE AS DEPARTURE, '' AS PICKUPDETAILS, BOOKEDBYMASTER.BOOKEDBY_NAME AS BOOKEDBY, AIRLINEBOOKINGMASTER.BOOKING_SALEBALANCE AS BALANCE, 'AIRLINEBOOKING' AS TYPE, AIRLINEBOOKINGMASTER.BOOKING_CMPID AS CMPID, AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID AS LOCATIONID, AIRLINEBOOKINGMASTER.BOOKING_YEARID AS YEARID FROM AIRLINEBOOKINGMASTER INNER JOIN BOOKEDBYMASTER ON AIRLINEBOOKINGMASTER.BOOKING_BOOKEDBYID = BOOKEDBYMASTER.BOOKEDBY_ID WHERE AIRLINEBOOKINGMASTER.BOOKING_CANCELLED= 'FALSE' AND AIRLINEBOOKINGMASTER.BOOKING_DONE = 0 AND AIRLINEBOOKINGMASTER.BOOKING_SALERETURN = 0) AS T ", WHERECLAUSE & " AND T.CMPID =" & CmpId & " ORDER BY T.SRNO")

            If dt.Rows.Count > 0 Then
                CHECKINNAMES = ""
                For Each ROW As DataRow In dt.Rows
                    CHECKINNAMES = CHECKINNAMES & ROW("BOOKINGNO") & " - " & ROW("GUESTNAME") & " - " & ROW("HOTELNAME") & " - Balance : " & ROW("BALANCE") & "                        "
                Next
            End If
            LBLCHECKIN.Text = CHECKINNAMES

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub BALANCESCROLLER()
        Try
            LBLBALANCE.Left = Me.Width
            LBLBALANCE.Top = StatusStrip3.Top + 2
            BALANCE_CMD.Top = StatusStrip3.Top - 4
            Dim WHERECLAUSE As String = " AND HOTELBOOKINGMASTER.BOOKING_SALEBALANCE > 0 "
            If UserName <> "Admin" Then
                WHERECLAUSE = WHERECLAUSE & " AND BOOKEDBYMASTER.BOOKEDBY_NAME = '" & UserName & "'"
            Else
                WHERECLAUSE = WHERECLAUSE & " AND MONTH(HOTELBOOKINGMASTER.BOOKING_date) = " & Month(Mydate)
            End If

            Dim BALANCENAMES As String = "There are No Outstanding Bills"
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search("  HOTELBOOKINGMASTER.BOOKING_NO AS BOOKINGNO, HOTELBOOKINGMASTER.BOOKING_REFNO AS REFNO, HOTELBOOKINGMASTER.BOOKING_DATE AS [DATE], GUESTMASTER.GUEST_NAME AS GUESTNAME , HOTELMASTER.HOTEL_NAME AS HOTELNAME,  HOTELBOOKINGMASTER.BOOKING_ARRIVAL AS ARRIVAL, HOTELBOOKINGMASTER.BOOKING_DEPARTURE AS DEPARTURE, HOTELBOOKINGMASTER.BOOKING_PICKUPDETAILS AS PICKUPDETAILS, BOOKEDBYMASTER.BOOKEDBY_NAME aS BOOKEDBY, BOOKING_SALEBALANCE AS BALANCE, BOOKING_BOOKTYPE AS TYPE, BOOKING_SALEBALANCE AS BALANCE ", "", " HOTELBOOKINGMASTER INNER JOIN GUESTMASTER ON HOTELBOOKINGMASTER.BOOKING_GUESTID = GUESTMASTER.GUEST_ID AND HOTELBOOKINGMASTER.BOOKING_CMPID = GUESTMASTER.GUEST_CMPID AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = GUESTMASTER.GUEST_LOCATIONID AND HOTELBOOKINGMASTER.BOOKING_YEARID = GUESTMASTER.GUEST_YEARID INNER JOIN HOTELMASTER ON HOTELBOOKINGMASTER.BOOKING_CMPID = HOTELMASTER.HOTEL_CMPID AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = HOTELMASTER.HOTEL_LOCATIONID AND HOTELBOOKINGMASTER.BOOKING_YEARID = HOTELMASTER.HOTEL_YEARID AND HOTELBOOKINGMASTER.BOOKING_HOTELID = HOTELMASTER.HOTEL_ID INNER JOIN BOOKEDBYMASTER ON HOTELBOOKINGMASTER.BOOKING_BOOKEDBYID = BOOKEDBYMASTER.BOOKEDBY_ID AND HOTELBOOKINGMASTER.BOOKING_CMPID = BOOKEDBYMASTER.BOOKEDBY_CMPID AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = BOOKEDBYMASTER.BOOKEDBY_LOCATIONID AND HOTELBOOKINGMASTER.BOOKING_YEARID = BOOKEDBYMASTER.BOOKEDBY_YEARID ", WHERECLAUSE & " AND BOOKING_CANCELLED = 'FALSE' AND BOOKING_AMD_DONE = 'FALSE' AND BOOKING_SALERETURN = 0 AND BOOKING_PURRETURN =0 AND BOOKING_CMPID =" & CmpId & " AND BOOKING_LOCATIONID = " & Locationid & " AND BOOKING_YEARID = " & YearId & " ORDER BY BOOKING_NO")
            If dt.Rows.Count > 0 Then
                BALANCENAMES = ""
                For Each ROW As DataRow In dt.Rows
                    BALANCENAMES = BALANCENAMES & ROW("BOOKINGNO") & " - Balance - " & ROW("BALANCE") & "           "
                Next
            End If
            LBLBALANCE.Text = BALANCENAMES

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub backup()
        Try
            'TAKE(backup)
            Dim TEMPMSG As Integer = MsgBox("Create Backup?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then

                'CHECKING FOR BACKUP FOLDER
                If FileIO.FileSystem.DirectoryExists("C:\TRAVELMATE BACKUP") = False Then FileIO.FileSystem.CreateDirectory("C:\TRAVELMATE BACKUP")

                'IF SAME DATE'S BACKUP EXIST THEN DELETE IT THEN RECREATE IT
                If FileIO.FileSystem.FileExists("C:\TRAVELMATE BACKUP\BACKUP " & Now.Day & "-" & Now.Month & "-" & Now.Year & ".bak") Then FileIO.FileSystem.DeleteFile("C:\TRAVELMATE BACKUP\BACKUP " & Now.Day & "-" & Now.Month & "-" & Now.Year & ".bak")

                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.Execute_Any_String(" backup database HOSPITALITY to disk='C:\TRAVELMATE BACKUP\BACKUP " & Now.Day & "-" & Now.Month & "-" & Now.Year & ".bak'", "", "")
                MsgBox("Backup Completed")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MDIMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            Dim TEMPMSG As Integer = MsgBox("Wish to Exit?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbNo Then
                e.Cancel = True
                Exit Sub
            End If
            ' backup()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MDIMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Text = CmpName & " (" & AccFrom & " - " & AccTo & ")             USERNAME : " & UCase(UserName)
        GETCONN()
        If ClientName = "AERO" Then
            Timer1.Enabled = False
            Timer2.Enabled = False
            LBLCHECKIN.Visible = False
            CHECKIN_CMD.Visible = False
        End If

        If ClientName = "TRAVIZIA" Then FOLLOWUP = True

        fillYEAR()
        SETENABILITY()


        'GET COMPANY'S DATA FOR VALIDATIONS OF EWB AND GST
        Dim OBJCMN As New ClsCommon
        Dim DT As DataTable = OBJCMN.search("ISNULL(CMP_EWBUSER,'') AS EWBUSER, ISNULL(CMP_EWBPASS,'') AS EWBPASS, ISNULL(CMP_GSTIN,'') AS CMPGSTIN, ISNULL(CMP_ZIPCODE,'') AS CMPPINCODE, ISNULL(CITY_NAME,'') AS CITYNAME, CAST(STATE_NAME AS VARCHAR(50)) AS STATENAME, CAST(STATE_REMARK AS VARCHAR(50)) AS STATECODE, ISNULL(CMP_ADD1,'') AS CMPADDRESS, ISNULL(CMP_TEL,'') AS CMPTEL, ISNULL(CMP_SAMESTATE,0) AS SAMESTATE", "", " CMPMASTER INNER JOIN STATEMASTER ON STATE_ID = CMP_STATEID LEFT OUTER JOIN CITYMASTER ON CMP_FROMCITYID = CITY_ID ", " AND CMP_ID = " & CmpId)
        If DT.Rows.Count > 0 Then
            CMPEWBUSER = DT.Rows(0).Item("EWBUSER")
            CMPEWBPASS = DT.Rows(0).Item("EWBPASS")
            CMPGSTIN = DT.Rows(0).Item("CMPGSTIN")
            CMPPINCODE = DT.Rows(0).Item("CMPPINCODE")
            CMPCITYNAME = DT.Rows(0).Item("CITYNAME")
            CMPSTATENAME = DT.Rows(0).Item("STATENAME")
            CMPSTATECODE = DT.Rows(0).Item("STATECODE")
            CMPADDRESS = DT.Rows(0).Item("CMPADDRESS")
            CMPTEL = DT.Rows(0).Item("CMPTEL")
            ALLOWSAMESTATE = DT.Rows(0).Item("SAMESTATE")

            DT = OBJCMN.search("ISNULL(SUM(NOOFEINVOICE),0) AS EINVOICECOUNTER", "", " EINVOICECOUNTER ", " AND CMPID = " & CmpId)
            CMPEINVOICECOUNTER = Val(DT.Rows(0).Item("EINVOICECOUNTER"))
            DT = OBJCMN.search("ISNULL(MAX(DATE), GETDATE()) AS EINVOICEEXPDATE", "", " EINVOICECOUNTER ", " AND CMPID = " & CmpId)
            EINVOICEEXPDATE = Convert.ToDateTime(DT.Rows(0).Item("EINVOICEEXPDATE")).Date.AddYears(1)
        End If


        If ClientName = "AIRTRINITY" Or ClientName = "RAMKRISHNA" Or ClientName = "KHANNA" Or ClientName = "APSARA" Or ClientName = "KPNT" Or ClientName = "CLASSIC" Then ALLOWSMS = True

        If LEADMANAGEMENT = False Then
            ITINERARY_MASTER.Enabled = False
            ENQMENU.Enabled = False
            ENQ_REPORTS.Enabled = False
            FOLLOWUP_REPORTS.Enabled = False
        End If

        If DISCONTINUECLIENT = True Then
            CMPADD.Enabled = False
            CMPEDIT.Enabled = False
            YEARADD.Enabled = False
        End If

        If ClientName = "TRAVELBRIDGE" Then
            ITINERARY_MASTER.Visible = False
            DOMESTICENQ_MASTER.Visible = False
            HOLIDAYENQ_MASTER.Text = "Quotation"
            HOLIDAY_TOOL.Visible = False
            TOOLSTRIPPACKAGE.Visible = False
            HOLIDAY_MASTER.Visible = False
            HOTELQUOTATIONFILTER_MASTER.Visible = False
        End If


    End Sub

    Sub SETENABILITY()
        Try
            Dim objhp As New HomePage
            objhp.MdiParent = Me

            'MASTERS
            objhp.ACC_CMD.Enabled = False
            objhp.HOTEL_CMD.Enabled = False
            objhp.FLIGHT_CMD.Enabled = False

            'RESERVATIONS
            objhp.HOTELBOOKING_CMD.Enabled = False
            objhp.AIRLINEBOOKING_CMD.Enabled = False

            'ACCOUNTS
            objhp.PUR_CMD.Enabled = False
            objhp.INV_CMD.Enabled = False
            objhp.PAYMENT_CMD.Enabled = False
            objhp.RECEIPT_CMD.Enabled = False
            objhp.BANK_CMD.Enabled = False
            objhp.CONTRA_CMD.Enabled = False
            objhp.LEDGER_CMD.Enabled = False
            objhp.VOUCHER_CMD.Enabled = False
            objhp.JOURNAL_CMD.Enabled = False

            'JUST ENABLED FOR STAR VISA
            VISAENQ_TOOL.Visible = False
            TOOLSTRIPVISAENQ.Visible = False
            VISAENQDETAILS_TOOL.Visible = False
            TOOLSTRIPVISAENQDETAILS.Visible = False
            VISADETAILS_TOOL.Visible = False
            TOOLSTRIPVISADETAILS.Visible = False

            If UserName = "Admin" Then
                RECODATA.Enabled = True
                MERGELEDGER.Enabled = True
                MERGEPARAMETER_MASTER.Enabled = True
                YEARTRANSFER.Enabled = True
                USERTRANSFER.Enabled = True
                BLOCKUSER.Enabled = True
                CMP_MASTER.Enabled = True
                CMP_MASTER.Visible = True
                ADMIN_MASTER.Enabled = True
                YEAR_MASTER.Enabled = True
                YEAR_MASTER.Visible = True
                BOOKEDBY_MASTER.Visible = True
                SPECIALRIGHTS_MASTER.Enabled = True
                RENUMBERING.Enabled = True
            Else
                'ONLY TO CHANGE PASSWORD
                ADMIN_MASTER.Enabled = True
                USERADD.Enabled = False
                USEREDIT.Enabled = True
            End If


            'IF USER HAS SPECIAL RIGHTS THEN ALLOW THEM TO SYNC DATA
            If (ClientName = "SKYMAPS" Or ClientName = "AIRTRINITY") And FETCHDATA = True Then
                SYNCDATA.Enabled = True
                SYNCDATA.Visible = True
            End If

            If FOLLOWUP = True Then
                Dim OBJFOLLOWUP As New FollowupReport
                OBJFOLLOWUP.MdiParent = Me
                OBJFOLLOWUP.FOLLOWUSER = UserName 'USERNAME is passed so followups of that user for today will be shown
                OBJFOLLOWUP.Show()
            End If

            If MISCENQUIRYREPORT = True Then
                Dim OBJMISC As New MiscEnquiryDetails
                OBJMISC.MdiParent = Me
                OBJMISC.MISCUSER = UserName 'USERNAME is passed so enquiries of that user will be shown
                OBJMISC.Show()
            End If

            'If ClientName = "TRAVIZIA" Then
            '    Dim OBJFOLLOWUP As New FollowupReport
            '    OBJFOLLOWUP.MdiParent = Me
            '    OBJFOLLOWUP.FOLLOWUSER = UserName 'USERNAME is passed so followups of that user for today will be shown
            '    OBJFOLLOWUP.Show()
            'End If

            If ClientName = "ARHAM" Then
                ENQMENU.Visible = False
                FLIGHT_TOOL.Visible = False
                TOOLSTRIPFLIGHT.Visible = False
                AIRLINEBOOKING_TOOL.Visible = False
                TOOLSTRIPAIRLINE.Visible = False
                HOLIDAY_TOOL.Visible = False
                TOOLSTRIPPACKAGE.Visible = False

                HOLIDAY_MASTER.Visible = False
                AIRLINEBOOKING_MASTER.Visible = False
                TOOLSTRIPMENUAIRLINE.Visible = False
                RAIL_MASTER.Visible = False
                TOOLSTRIPMENURAIL.Visible = False
                VISA_MASTER.Visible = False
                MISC_MASTER.Visible = False
                TOOLSTRIPMENUMISC.Visible = False
            End If


            If ClientName = "APSARA" Then
                ITINERARY_MASTER.Visible = False
                ENQMENU.Visible = False
                DOMESTIC_BOOKING.Visible = False
                HOLIDAY_MASTER.Visible = False
                TOOLSTRIPMENUPACKAGE.Visible = False
                AIRLINEBOOKING_MASTER.Visible = False
                TOOLSTRIPMENUAIRLINE.Visible = False
                CAR_MASTER.Visible = False
                TOOLSTRIPMENUCAR.Visible = False
                RAIL_MASTER.Visible = False
                TOOLSTRIPMENURAIL.Visible = False
                VISA_MASTER.Visible = False
                AIRDEBIT_MASTER.Visible = False
                AIRCREDIT_MASTER.Visible = False

                HOTEL_TOOL.Visible = False
                TOOLSTRIPHOTEL.Visible = False
                FLIGHT_TOOL.Visible = False
                TOOLSTRIPFLIGHT.Visible = False
                HOTELBOOKING_TOOL.Visible = False
                TOOLSTRIPHOTELBOOKING.Visible = False
                HOLIDAY_TOOL.Visible = False
                TOOLSTRIPPACKAGE.Visible = False
                AIRLINEBOOKING_TOOL.Visible = False
                TOOLSTRIPAIRLINE.Visible = False
                CAR_TOOL.Visible = False
                TOOLSEPCAR.Visible = False
                VISA_TOOL.Visible = False
                TOOLSTRIPVISA.Visible = False


            End If

            If ClientName = "VIHAR" Or ClientName = "SSR" Then
                TARIFF_MASTER.Visible = True
                TARIFFADD.Visible = True
                TARIFFEDIT.Visible = True
            End If


            If ClientName = "PARAMOUNT" Then ADMINREPORTS.Visible = False

            BRANCHTRANSFER_MASTER.Visible = False
            GROUPDEP_TOOL.Visible = False
            TOOLSEPGROUPDEP.Visible = False

            If ClientName = "FINASTA" Then TOOLSTRIPMENUHOTEL.Visible = True

            If ClientName <> "CLASSIC" Then
                MEMBERDETAILS.Visible = False
                LOYALTYPROGRAMME.Visible = False
                ToolStripSeparator138.Visible = False
                POINTSMASTER.Visible = False
            Else

                If SHOWMEMBERSHIPFORM = True Then
                    MEMBERDETAILS.Enabled = True
                    LOYALTYPROGRAMME.Enabled = True
                End If

                BRANCHTRANSFER_MASTER.Visible = True
                INTERNATIONAL_MASTER.Visible = True
                toolseptransfer.Visible = True

                'TEMPORARILY HIDE LOGS FOR CLASSIC
                ENTRYLOGS_MENU.Visible = False
                UPDATELOGS_MENU.Visible = False
                DELETELOGS_MENU.Visible = False
                TOOLSTRIPLOGS.Visible = False
            End If


            If ClientName = "SCC" Or ClientName = "TRAVCON" Then
                VEHICLERATECHART_MASTER.Visible = True
                VEHICLERATECHARTPUR_MASTER.Visible = True
                VEHICLENO_MASTER.Visible = True
                GUESTLEDGERCONFIG_MASTER.Visible = True
            End If

            If ClientName = "RAMKRISHNA" Or ClientName = "KHANNA" Then
                If ClientName = "RAMKRISHNA" Then TARIFF_MASTER.Visible = True
                GROUPDEP_MASTER.Visible = True
                GROUPDEP_TOOL.Visible = True
                TOOLSEPGROUPDEP.Visible = True
            End If

            If ClientName <> "PRIYA" Then
                MISCENQ_TOOL.Visible = False
                TOOLSEPMISCENQ.Visible = False
                CAR_TOOL.Visible = False
                TOOLSEPCAR.Visible = False
            End If

            If ClientName = "STARVISA" Then
                HOTELBOOKING_TOOL.Visible = False
                TOOLSTRIPHOTELBOOKING.Visible = False
                HOLIDAY_TOOL.Visible = False
                TOOLSTRIPPACKAGE.Visible = False
                AIRLINEBOOKING_TOOL.Visible = False
                TOOLSTRIPAIRLINE.Visible = False
                MISCPUR_TOOL.Visible = False
                TOOLSTRIPMISCPUR.Visible = False
                MISCSALE_TOOL.Visible = False
                TOOLSTRIPMISCSALE.Visible = False
                VISA_TOOL.Text = "Visa Bill"
                VISAENQ_TOOL.Visible = True
                TOOLSTRIPVISAENQ.Visible = True
                VISAENQDETAILS_TOOL.Visible = True
                TOOLSTRIPVISAENQDETAILS.Visible = True
                VISADETAILS_TOOL.Visible = True
                TOOLSTRIPVISADETAILS.Visible = True
                EMAIL_TOOL.Visible = True
            End If


            For Each DTROW As DataRow In USERRIGHTS.Rows

                If DTROW(0).ToString = "GROUP MASTER" Then
                    If DTROW(1).ToString = True Then
                        GROUP_MASTER.Enabled = True
                        GROUPADD.Enabled = True
                    Else
                        GROUPADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        GROUP_MASTER.Enabled = True
                        GROUPEDIT.Enabled = True
                    Else
                        GROUPEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "ACCOUNTS MASTER" Then
                    If DTROW(1).ToString = True Then
                        ACC_MASTER.Enabled = True
                        ACCADD.Enabled = True
                        objhp.ACC_CMD.Enabled = True
                        ACC_TOOL.Enabled = True
                    Else
                        ACCADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        ACC_MASTER.Enabled = True
                        ACCEDIT.Enabled = True
                        objhp.ACC_CMD.Enabled = True
                        ACC_TOOL.Enabled = True
                    Else
                        ACCEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "EMPLOYEE MASTER" Then
                    If DTROW(1).ToString = True Then
                        EMP_MASTER.Enabled = True
                        TARGET_MASTER.Enabled = True
                        EMPADD.Enabled = True
                        TARGETADD.Enabled = True
                    Else
                        EMPADD.Enabled = False
                        TARGETADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        EMP_MASTER.Enabled = True
                        TARGET_MASTER.Enabled = True
                        EMPEDIT.Enabled = True
                        TARGETEDIT.Enabled = True
                    Else
                        EMPEDIT.Enabled = False
                        TARGETEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "GUEST MASTER" Then
                    If DTROW(1).ToString = True Then
                        GUEST_MASTER.Enabled = True
                        GUESTCATEGORY_MASTER.Enabled = True
                        GUESTADD.Enabled = True
                        GUESTCATEGORYADD.Enabled = True
                        GUESTLEDGERCONFIG_MASTER.Enabled = True
                    Else
                        GUESTADD.Enabled = False
                        GUESTCATEGORYADD.Enabled = False
                        GUESTLEDGERCONFIG_MASTER.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        GUEST_MASTER.Enabled = True
                        GUESTCATEGORY_MASTER.Enabled = True
                        GUESTEDIT.Enabled = True
                        GUESTCATEGORYEDIT.Enabled = True
                        GUEST_TOOL.Enabled = True
                        GUESTLEDGERCONFIG_MASTER.Enabled = True
                    Else
                        GUESTEDIT.Enabled = False
                        GUESTCATEGORYEDIT.Enabled = False
                        GUESTLEDGERCONFIG_MASTER.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "AGENT MASTER" Then
                    If DTROW(1).ToString = True Then
                        AGENT_MASTER.Enabled = True
                        AGENTADD.Enabled = True
                    Else
                        AGENTADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        AGENT_MASTER.Enabled = True
                        AGENTEDIT.Enabled = True
                    Else
                        AGENTEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "REGISTER MASTER" Then
                    If (DTROW(1) = True) Or (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        REG_MASTER.Enabled = True
                    End If

                ElseIf DTROW(0).ToString = "POLICY MASTER" Then
                    If DTROW(1).ToString = True Then
                        POLICY_MASTER.Enabled = True
                        POLICYADD.Enabled = True
                    Else
                        POLICYADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        POLICY_MASTER.Enabled = True
                        POLICYEDIT.Enabled = True
                    Else
                        POLICYEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "NOTE MASTER" Then
                    If DTROW(1).ToString = True Then
                        NOTE_MASTER.Enabled = True
                        NOTEADD.Enabled = True
                    Else
                        NOTEADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        NOTE_MASTER.Enabled = True
                        NOTEEDIT.Enabled = True
                    Else
                        NOTEEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "ACCOUNTS MASTER" Then
                    If DTROW(1).ToString = True Then
                        HSN_MASTER.Enabled = True
                        HSNADD.Enabled = True
                        'objhp.ACC_CMD.Enabled = True
                        'ACC_TOOL.Enabled = True
                    Else
                        HSNADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        HSN_MASTER.Enabled = True
                        HSNEDIT.Enabled = True
                        'objhp.ACC_CMD.Enabled = True
                        'ACC_TOOL.Enabled = True
                    Else
                        HSNEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "SOURCE MASTER" Then
                    If DTROW(1).ToString = True Then
                        SOURCE_MASTER.Enabled = True
                        SOURCEADD.Enabled = True
                    Else
                        SOURCEADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        SOURCE_MASTER.Enabled = True
                        SOURCEEDIT.Enabled = True
                    Else
                        SOURCEEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "DESIGNATION MASTER" Then
                    If DTROW(1).ToString = True Then
                        DESIGNATION_MASTER.Enabled = True
                        DESIGNATIONADD.Enabled = True
                    Else
                        DESIGNATIONADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        DESIGNATION_MASTER.Enabled = True
                        DESIGNATIONEDIT.Enabled = True
                    Else
                        DESIGNATIONEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "DEPARTMENT MASTER" Then
                    If DTROW(1).ToString = True Then
                        DEPARTMENT_MASTER.Enabled = True
                        DEPARTMENTADD.Enabled = True
                    Else
                        DEPARTMENTADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        DEPARTMENT_MASTER.Enabled = True
                        DEPARTMENTEDIT.Enabled = True
                    Else
                        DEPARTMENTEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "FLIGHT MASTER" Then
                    If DTROW(1).ToString = True Then
                        FLIGHT_MASTER.Enabled = True
                        STOCK_MASTER.Enabled = True
                        COUPON_MASTER.Enabled = True
                        AIRLINESEGMENT_MASTER.Enabled = True
                        FLIGHTADD.Enabled = True
                        STOCKADD.Enabled = True
                        COUPONADD.Enabled = True
                    Else
                        FLIGHTADD.Enabled = False
                        STOCKADD.Enabled = False
                        COUPONADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        FLIGHT_MASTER.Enabled = True
                        AIRLINESEGMENT_MASTER.Enabled = True
                        STOCK_MASTER.Enabled = True
                        COUPON_MASTER.Enabled = True
                        FLIGHTEDIT.Enabled = True
                        STOCKEDIT.Enabled = True
                        COUPONEDIT.Enabled = True
                        objhp.FLIGHT_CMD.Enabled = True
                        FLIGHT_TOOL.Enabled = True
                    Else
                        FLIGHTEDIT.Enabled = False
                        STOCKEDIT.Enabled = False
                        COUPONEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "AMENITIES MASTER" Then
                    If DTROW(1).ToString = True Then
                        AMENITIES_MASTER.Enabled = True
                        AMENITIESADD.Enabled = True
                        MEALPLAN_MASTER.Enabled = True
                        MEALPLANSADD.Enabled = True
                    Else
                        AMENITIESADD.Enabled = False
                        MEALPLANSADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        AMENITIES_MASTER.Enabled = True
                        AMENITIESEDIT.Enabled = True
                        MEALPLAN_MASTER.Enabled = True
                        MEALPLANEDIT.Enabled = True
                    Else
                        AMENITIESEDIT.Enabled = False
                        MEALPLANEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "ROOMTYPE MASTER" Then
                    If DTROW(1).ToString = True Then
                        ROOM_MASTER.Enabled = True
                        ROOMADD.Enabled = True
                    Else
                        ROOMADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        ROOM_MASTER.Enabled = True
                        ROOMEDIT.Enabled = True
                    Else
                        ROOMEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "HOTELTYPE MASTER" Then
                    If DTROW(1).ToString = True Then
                        HOTELTYPE_MASTER.Enabled = True
                        HOTELTYPEADD.Enabled = True
                    Else
                        HOTELTYPEADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        HOTELTYPE_MASTER.Enabled = True
                        HOTELTYPEEDIT.Enabled = True
                    Else
                        HOTELTYPEEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "GROUP OF HOTELS" Then
                    If DTROW(1).ToString = True Then
                        HOTELGROUP_MASTER.Enabled = True
                        HOTELGROUPADD.Enabled = True
                    Else
                        HOTELGROUPADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        HOTELGROUP_MASTER.Enabled = True
                        HOTELGROUPEDIT.Enabled = True
                    Else
                        HOTELGROUPEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "HOTEL MASTER" Then
                    If DTROW(1).ToString = True Then
                        HOTEL_MASTER.Enabled = True
                        TARIFF_MASTER.Enabled = True
                        HOTEL_TOOL.Enabled = True
                        HOTELADD.Enabled = True
                        objhp.HOTEL_CMD.Enabled = True
                        TARIFFADD.Enabled = True
                        TOUR_MASTER.Enabled = True
                        TOURADD.Enabled = True
                    Else
                        HOTELADD.Enabled = False
                        TARIFFADD.Enabled = False
                        TOURADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        TARIFF_MASTER.Enabled = True
                        HOTEL_MASTER.Enabled = True
                        HOTEL_TOOL.Enabled = True
                        objhp.HOTEL_CMD.Enabled = True
                        TARIFFEDIT.Enabled = True
                        TOUR_MASTER.Enabled = True
                        TOUREDIT.Enabled = True
                    Else
                        HOTELEDIT.Enabled = False
                        TARIFFEDIT.Enabled = False
                        TOUREDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "VEHICLE MASTER" Then
                    If DTROW(1).ToString = True Then
                        VEHICLETYPE_MASTER.Enabled = True
                        DRIVER_MASTER.Enabled = True
                        VEHICLE_MASTER.Enabled = True
                        VEHICLETYPEADD.Enabled = True
                        VEHICLEADD.Enabled = True
                        DRIVERADD.Enabled = True
                        VEHICLENO_MASTER.Enabled = True
                        VEHICLENOADD.Enabled = True
                        VEHICLERATECHART_MASTER.Enabled = True
                        VEHICLERATECHARTPUR_MASTER.Enabled = True
                    Else
                        VEHICLETYPEADD.Enabled = False
                        VEHICLEADD.Enabled = False
                        DRIVERADD.Enabled = False
                        VEHICLENOADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        VEHICLETYPE_MASTER.Enabled = True
                        DRIVER_MASTER.Enabled = True
                        VEHICLE_MASTER.Enabled = True
                        VEHICLETYPEEDIT.Enabled = True
                        VEHICLEEDIT.Enabled = True
                        DRIVEREDIT.Enabled = True
                        VEHICLENO_MASTER.Enabled = True
                        VEHICLENOEDIT.Enabled = True
                        VEHICLERATECHART_MASTER.Enabled = True
                        VEHICLERATECHARTPUR_MASTER.Enabled = True
                    Else
                        VEHICLETYPEEDIT.Enabled = False
                        VEHICLEEDIT.Enabled = False
                        DRIVEREDIT.Enabled = False
                        VEHICLENOEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "UNIT MASTER" Then
                    If DTROW(1).ToString = True Then
                        UNIT_MASTER.Enabled = True
                        UNITADD.Enabled = True
                    Else
                        UNITADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        UNIT_MASTER.Enabled = True
                        UNITEDIT.Enabled = True
                    Else
                        UNITEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "LOCATION MASTER" Then
                    If (DTROW(1) = True) Or (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        LOC_MASTER.Enabled = True
                    End If

                ElseIf DTROW(0).ToString = "TAX MASTER" Then
                    If DTROW(1).ToString = True Then
                        TAX_MASTER.Enabled = True
                        TAXADD.Enabled = True
                    Else
                        TAXADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        TAX_MASTER.Enabled = True
                        TAXEDIT.Enabled = True
                    Else
                        TAXEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "OPENING" Then
                    If DTROW(1).ToString = True Then
                        OPENINGBILL_MASTER.Enabled = True
                        OPENINGBALANCE.Enabled = True
                        OPENINGDRCR.Enabled = True
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        OPENINGBILL_MASTER.Enabled = True
                        OPENINGBALANCE.Enabled = True
                        OPENINGDRCR.Enabled = True
                    End If


                    'RESERVATIONS
                ElseIf DTROW(0).ToString = "DOMESTIC ENQUIRY" Then
                    If DTROW(1).ToString = True Then
                        DOMESTICENQ_MASTER.Enabled = True
                        DOMESTICENQADD.Enabled = True
                    Else
                        DOMESTICENQADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        DOMESTICENQ_MASTER.Enabled = True
                        DOMESTICENQEDIT.Enabled = True
                    Else
                        DOMESTICENQEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "PACKAGE ENQUIRY" Then
                    If DTROW(1).ToString = True Then
                        HOLIDAYENQ_MASTER.Enabled = True
                        HOLIDAYENQADD.Enabled = True
                    Else
                        HOLIDAYENQADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        HOLIDAYENQ_MASTER.Enabled = True
                        HOLIDAYENQEDIT.Enabled = True
                    Else
                        HOLIDAYENQEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "FOREX" Then
                    If DTROW(1).ToString = True Then
                        FOREXENQ_MASTER.Enabled = True
                        FOREXENQADD.Enabled = True
                    Else
                        FOREXENQADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        FOREXENQ_MASTER.Enabled = True
                        FOREXENQEDIT.Enabled = True
                    Else
                        FOREXENQEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "MISC ENQUIRY" Then
                    If DTROW(1).ToString = True Then
                        MISCENQ_TOOL.Enabled = True
                        MISCENQ_MASTER.Enabled = True
                        MISCENQADD.Enabled = True
                    Else
                        MISCENQADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        MISCENQ_TOOL.Enabled = True
                        MISCENQ_MASTER.Enabled = True
                        MISCENQEDIT.Enabled = True
                    Else
                        MISCENQEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "DOMESTIC RESERVATION" Then
                    If DTROW(1).ToString = True Then
                        DOMESTIC_BOOKING.Enabled = True
                        BRANCHTRANSFER_MASTER.Enabled = True
                        HOTELBOOKINGADD.Enabled = True
                        TRANSFERADD.Enabled = True
                        PROFORMA_MASTER.Enabled = True
                        PROFORMAADD.Enabled = True
                    Else
                        HOTELBOOKINGADD.Enabled = False
                        TRANSFERADD.Enabled = False
                        PROFORMAADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        DOMESTIC_BOOKING.Enabled = True
                        BRANCHTRANSFER_MASTER.Enabled = True
                        HOTELBOOKING_TOOL.Enabled = True
                        PROFORMA_TOOL.Enabled = True
                        objhp.HOTELBOOKING_CMD.Enabled = True
                        HOTELBOOKINGEDIT.Enabled = True
                        TRANSFEREDIT.Enabled = True
                        PROFORMA_MASTER.Enabled = True
                        PROFORMAEDIT.Enabled = True
                    Else
                        HOTELBOOKINGEDIT.Enabled = False
                        TRANSFEREDIT.Enabled = False
                        PROFORMAEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "HOLIDAY PACKAGES" Then
                    If DTROW(1).ToString = True Then
                        HOLIDAY_TOOL.Enabled = True
                        GROUPDEP_TOOL.Enabled = True
                        HOLIDAY_MASTER.Enabled = True
                        GROUPDEP_MASTER.Enabled = True
                        HOLIDAYADD.Enabled = True
                        GROUPDEPADD.Enabled = True
                    Else
                        HOLIDAYADD.Enabled = False
                        GROUPDEPADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        HOLIDAY_MASTER.Enabled = True
                        GROUPDEP_MASTER.Enabled = True
                        HOLIDAY_TOOL.Enabled = True
                        GROUPDEP_TOOL.Enabled = True
                        HOLIDAYEDIT.Enabled = True
                        GROUPDEPEDIT.Enabled = True
                    Else
                        HOLIDAYEDIT.Enabled = False
                        GROUPDEPEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "INTERNATIONAL RESERVATION" Then
                    If DTROW(1).ToString = True Then
                        INTERNATIONAL_MASTER.Enabled = True
                        INTERNATIONALADD.Enabled = True
                    Else
                        INTERNATIONALADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        INTERNATIONAL_MASTER.Enabled = True
                        INTERNATIONALEDIT.Enabled = True
                    Else
                        INTERNATIONALEDIT.Enabled = False
                    End If



                ElseIf DTROW(0).ToString = "REGISTRATION" Then
                    If DTROW(1).ToString = True Then
                        GIFTPUR_MASTER.Enabled = True
                        GIFTPURADD.Enabled = True
                        SERVPUR_MASTER.Enabled = True
                        SERVPURADD.Enabled = True
                        REGISTRATION_MASTER.Enabled = True
                        REGISTRATIONADD.Enabled = True
                    Else
                        GIFTPURADD.Enabled = False
                        SERVPURADD.Enabled = False
                        REGISTRATIONADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        GIFTPUR_MASTER.Enabled = True
                        GIFTPUREDIT.Enabled = True
                        SERVPUR_MASTER.Enabled = True
                        SERVPUREDIT.Enabled = True
                        REGISTRATION_MASTER.Enabled = True
                        REGISTRATIONEDIT.Enabled = True
                    Else
                        GIFTPUREDIT.Enabled = False
                        SERVPUREDIT.Enabled = False
                        REGISTRATIONEDIT.Enabled = False
                    End If



                ElseIf DTROW(0).ToString = "CAR RENTAL" Then
                    If DTROW(1).ToString = True Then
                        CAR_TOOL.Enabled = True
                        CAR_MASTER.Enabled = True
                        CARADD.Enabled = True
                    Else
                        CAR_MASTER.Enabled = False
                        CARADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        CAR_TOOL.Enabled = True
                        CAR_MASTER.Enabled = True
                        CAREDIT.Enabled = True
                    Else
                        CAR_MASTER.Enabled = False
                        CAREDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "RAIL RESERVATION" Then
                    If DTROW(1).ToString = True Then
                        RAIL_MASTER.Enabled = True
                        TRAIN_MASTER.Enabled = True
                        STATION_MASTER.Enabled = True
                        LOGIN_MASTER.Enabled = True
                        IDTYPE_MASTER.Enabled = True
                        RAILCONFIG.Enabled = True
                        RAILADD.Enabled = True
                        TRAINADD.Enabled = True
                        STATIONADD.Enabled = True
                        LOGINADD.Enabled = True
                        IDTYPEADD.Enabled = True
                    Else
                        RAIL_MASTER.Enabled = False
                        TRAIN_MASTER.Enabled = False
                        STATION_MASTER.Enabled = False
                        LOGIN_MASTER.Enabled = False
                        IDTYPE_MASTER.Enabled = False
                        RAILADD.Enabled = False
                        TRAINADD.Enabled = False
                        STATIONADD.Enabled = False
                        LOGINADD.Enabled = False
                        IDTYPEADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        RAIL_MASTER.Enabled = True
                        TRAIN_MASTER.Enabled = True
                        STATION_MASTER.Enabled = True
                        LOGIN_MASTER.Enabled = True
                        IDTYPE_MASTER.Enabled = True
                        RAILCONFIG.Enabled = True
                        RAILEDIT.Enabled = True
                        TRAINEDIT.Enabled = True
                        STATIONEDIT.Enabled = True
                        LOGINEDIT.Enabled = True
                        IDTYPEEDIT.Enabled = True
                    Else
                        RAIL_MASTER.Enabled = False
                        TRAIN_MASTER.Enabled = False
                        STATION_MASTER.Enabled = False
                        LOGIN_MASTER.Enabled = False
                        IDTYPE_MASTER.Enabled = False
                        RAILEDIT.Enabled = False
                        TRAINEDIT.Enabled = False
                        STATIONEDIT.Enabled = False
                        LOGINEDIT.Enabled = False
                        IDTYPEEDIT.Enabled = True
                    End If

                ElseIf DTROW(0).ToString = "MISC PURCHASE" Then
                    If DTROW(1).ToString = True Then
                        MISC_MASTER.Enabled = True
                        MISC_PUR_MASTER.Enabled = True
                        MISCPUR_TOOL.Enabled = True
                        MISCPURADD.Enabled = True
                    Else
                        MISC_MASTER.Enabled = False
                        MISC_PUR_MASTER.Enabled = False
                        MISCPURADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        MISC_MASTER.Enabled = True
                        MISC_PUR_MASTER.Enabled = True
                        MISCPUR_TOOL.Enabled = True
                        MISCPUREDIT.Enabled = True
                    Else
                        MISC_MASTER.Enabled = False
                        MISC_PUR_MASTER.Enabled = False
                        MISCPUREDIT.Enabled = False
                    End If
                ElseIf DTROW(0).ToString = "MISC SALE" Then
                    If DTROW(1).ToString = True Then
                        MISC_MASTER.Enabled = True
                        MISC_SAL_MASTER.Enabled = True
                        MISCSALE_TOOL.Enabled = True
                        MISCSALADD.Enabled = True
                        PROFORMAMISC_MASTER.Enabled = True
                        PROFORMAMISCADD.Enabled = True
                    Else
                        MISC_MASTER.Enabled = False
                        MISC_SAL_MASTER.Enabled = False
                        MISCSALADD.Enabled = False
                        PROFORMAMISCADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        MISC_MASTER.Enabled = True
                        MISC_SAL_MASTER.Enabled = True
                        MISCSALE_TOOL.Enabled = True
                        MISCSALEDIT.Enabled = True
                        PROFORMAMISC_MASTER.Enabled = True
                        PROFORMAMISCEDIT.Enabled = True
                    Else
                        MISC_MASTER.Enabled = False
                        MISC_SAL_MASTER.Enabled = False
                        MISCSALEDIT.Enabled = False
                        PROFORMAMISCEDIT.Enabled = False
                    End If
                ElseIf DTROW(0).ToString = "AIRLINE RESERVATION" Then
                    If DTROW(1).ToString = True Then
                        AIRLINEBOOKING_MASTER.Enabled = True
                        'DOMESTIC
                        AIRDOM_MASTER.Enabled = True
                        AIRDOMADD.Enabled = True
                        'INTERNATIONAL
                        AIRINT_MASTER.Enabled = True
                        AIRINTADD.Enabled = True
                    Else
                        AIRDOM_MASTER.Enabled = False
                        AIRINT_MASTER.Enabled = False
                        AIRDOMADD.Enabled = False
                        AIRINTADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        AIRLINEBOOKING_MASTER.Enabled = True
                        AIRLINEBOOKING_TOOL.Enabled = True
                        AIRDOM_TOOL.Enabled = True
                        AIRINT_TOOL.Enabled = True
                        objhp.AIRLINEBOOKING_CMD.Enabled = True
                        AIRINT_MASTER.Enabled = True
                        AIRINTEDIT.Enabled = True
                        AIRDOM_MASTER.Enabled = True
                        AIRDOMEDIT.Enabled = True
                    Else
                        AIRINT_MASTER.Enabled = False
                        AIRDOM_MASTER.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "RAILWAY RESERVATION" Then
                    If DTROW(1).ToString = True Then
                        RAIL_MASTER.Enabled = True
                        RAILADD.Enabled = True
                    Else
                        RAIL_MASTER.Enabled = False
                        RAILADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        RAIL_MASTER.Enabled = True
                        RAILEDIT.Enabled = True
                    Else
                        RAIL_MASTER.Enabled = False
                        RAILEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "VISA" Then
                    If DTROW(1).ToString = True Then
                        VISAENQ_TOOL.Enabled = True
                        VISA_TOOL.Enabled = True
                        DOCUMENT_MASTER.Enabled = True
                        VISAENQ_MASTER.Enabled = True
                        VISA_MASTER.Enabled = True
                        DOCUMENTADD.Enabled = True
                        VISAENQADD.Enabled = True
                        VISAADD.Enabled = True
                    Else
                        VISAENQADD.Enabled = False
                        DOCUMENTADD.Enabled = False
                        VISAADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        VISAENQ_TOOL.Enabled = True
                        VISA_TOOL.Enabled = True
                        DOCUMENT_MASTER.Enabled = True
                        VISAENQ_MASTER.Enabled = True
                        VISA_MASTER.Enabled = True
                        DOCUMENTEDIT.Enabled = True
                        VISAENQEDIT.Enabled = True
                        VISAEDIT.Enabled = True
                    Else
                        VISAENQEDIT.Enabled = False
                        DOCUMENTEDIT.Enabled = False
                        VISAEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "OTHER SALE PURCHASE" Then
                    If DTROW(1).ToString = True Then
                        OTHERSALEPUR_MASTER.Enabled = True
                        OTHERSALEPURADD.Enabled = True
                    Else
                        OTHERSALEPURADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        OTHERSALEPUR_MASTER.Enabled = True
                        OTHERSALEPUREDIT.Enabled = True
                    Else
                        OTHERSALEPUREDIT.Enabled = False
                    End If


                    'ACCOUNTS
                ElseIf DTROW(0).ToString = "PAYMENT" Then
                    If DTROW(1).ToString = True Then
                        PAY_MASTER.Enabled = True
                        PAY_TOOL.Enabled = True
                        PAYADD.Enabled = True
                        objhp.PAYMENT_CMD.Enabled = True
                    Else
                        PAYADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        PAY_MASTER.Enabled = True
                        PAY_TOOL.Enabled = True
                        objhp.PAYMENT_CMD.Enabled = True
                        PAYEDIT.Enabled = True
                    Else
                        PAYEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "RECEIPT" Then
                    If DTROW(1).ToString = True Then
                        REC_MASTER.Enabled = True
                        REC_TOOL.Enabled = True
                        RECADD.Enabled = True
                        objhp.RECEIPT_CMD.Enabled = True
                    Else
                        RECADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        REC_MASTER.Enabled = True
                        REC_TOOL.Enabled = True
                        objhp.RECEIPT_CMD.Enabled = True
                        RECEDIT.Enabled = True
                    Else
                        RECEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "CONTRA VOUCHER" Then
                    If DTROW(1).ToString = True Then
                        CONTRA_TOOL.Enabled = True
                        CONTRA_MASTER.Enabled = True
                        CONTRAADD.Enabled = True
                        objhp.CONTRA_CMD.Enabled = True
                    Else
                        CONTRAADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        CONTRA_TOOL.Enabled = True
                        CONTRA_MASTER.Enabled = True
                        objhp.CONTRA_CMD.Enabled = True
                        CONTRAEDIT.Enabled = True
                    Else
                        CONTRAEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "JOURNAL VOUCHER" Then
                    If DTROW(1).ToString = True Then
                        JV_MASTER.Enabled = True
                        JV_TOOL.Enabled = True
                        JVADD.Enabled = True
                        objhp.JOURNAL_CMD.Enabled = True
                    Else
                        JVADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        JV_MASTER.Enabled = True
                        JV_TOOL.Enabled = True
                        objhp.JOURNAL_CMD.Enabled = True
                        JVEDIT.Enabled = True
                    Else
                        JVEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "DEBIT NOTE" Then
                    If DTROW(1).ToString = True Then
                        DEBIT_MASTER.Enabled = True
                        AIRDEBIT_MASTER.Enabled = True
                        DEBITADD.Enabled = True
                        AIRDEBITADD.Enabled = True
                    Else
                        DEBITADD.Enabled = False
                        AIRDEBITADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        DEBIT_MASTER.Enabled = True
                        AIRDEBIT_MASTER.Enabled = True
                        DEBITEDIT.Enabled = True
                        AIRDEBITEDIT.Enabled = True
                    Else
                        DEBITEDIT.Enabled = False
                        AIRDEBITEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "CREDIT NOTE" Then
                    If DTROW(1).ToString = True Then
                        AIRCREDIT_MASTER.Enabled = True
                        CREDIT_MASTER.Enabled = True
                        CREDITADD.Enabled = True
                        AIRCREDITADD.Enabled = True
                    Else
                        CREDITADD.Enabled = False
                        AIRCREDITADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        AIRCREDIT_MASTER.Enabled = True
                        CREDIT_MASTER.Enabled = True
                        CREDITEDIT.Enabled = True
                        AIRCREDITEDIT.Enabled = True
                    Else
                        CREDITEDIT.Enabled = False
                        AIRCREDITEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "VOUCHER ENTRY" Then
                    If DTROW(1).ToString = True Then
                        VOUCHER_MASTER.Enabled = True
                        VOUCHERADD.Enabled = True
                        objhp.VOUCHER_CMD.Enabled = True
                    Else
                        VOUCHERADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        VOUCHER_MASTER.Enabled = True
                        objhp.VOUCHER_CMD.Enabled = True
                        VOUCHEREDIT.Enabled = True
                    Else
                        VOUCHEREDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "PAYROLL" Then
                    If DTROW(1).ToString = True Then
                        SALARY_MASTER.Enabled = True
                        SALARYADD.Enabled = True
                    Else
                        SALARYADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        SALARY_MASTER.Enabled = True
                        SALARYEDIT.Enabled = True
                    Else
                        SALARYEDIT.Enabled = False
                    End If



                    'REPORTS
                ElseIf DTROW(0).ToString = "RESERVATION REPORTS" Then
                    If (DTROW(1) = True) Or (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        RESERVATION_REPORTS.Enabled = True
                    End If

                ElseIf DTROW(0).ToString = "STOCK REPORTS" Then
                    'If (DTROW(1) = True) Or (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                    '    SALE_REPORTS.Enabled = True
                    'End If

                ElseIf DTROW(0).ToString = "ACCOUNT REPORTS" Then
                    If (DTROW(1) = True) Or (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        JV_REPORTS.Enabled = True
                        CONTRA_REPORTS.Enabled = True
                        ACC_REPORTS.Enabled = True
                    Else
                        ACC_REPORTS.Enabled = False
                    End If

                End If
            Next


            If AIRLINE = False Then
                AIRLINEBOOKING_TOOL.Visible = False
                TOOLSTRIPAIRLINE.Visible = False
                AIRLINEBOOKING_MASTER.Visible = False
                TOOLSTRIPMENUAIRLINE.Visible = False
                FLIGHTMASTER_MENU.Visible = False
                TOOLSTRIPMASTERFLIGHT.Visible = False
                FLIGHT_TOOL.Visible = False
                TOOLSTRIPFLIGHT.Visible = False
            End If

            If CAR = False Then
                CAR_MASTER.Visible = False
                TOOLSTRIPMENUCAR.Visible = False
                VEHICLEMASTER_MENU.Visible = False
                TOOLSTRIPMASTERCAR.Visible = False
            End If

            If MISC = False Then
                MISC_MASTER.Visible = False
                TOOLSTRIPMENUMISC.Visible = False
            End If

            If RAILWAY = False Then
                RAIL_MASTER.Visible = False
                TOOLSTRIPMENURAIL.Visible = False
                RAILMASTER_MENU.Visible = False
                TOOLSTRIPMASTERRAIL.Visible = False
            End If

            If HOTEL = False Then
                HOTEL_TOOL.Visible = False
                TOOLSTRIPHOTEL.Visible = False
                HOTELBOOKING_TOOL.Visible = False
                TOOLSTRIPHOTELBOOKING.Visible = False
                DOMESTIC_BOOKING.Visible = False
                GROUPDEP_MASTER.Visible = False
                TOOLSTRIPMENUHOTEL.Visible = False
                HOTELMASTER_MENU.Visible = False
                TOOLSTRIPMASTERHOTEL.Visible = False
            End If

            If HOLIDAY = False Then
                HOLIDAY_TOOL.Visible = False
                HOLIDAY_MASTER.Visible = False
                TOOLSTRIPPACKAGE.Visible = False
            End If

            If ClientName = "FINASTA" Then
                REGISTRATION_MASTER.Visible = True
                GIFTPUR_MASTER.Visible = True
                SERVPUR_MASTER.Visible = True
                TOUR_MASTER.Visible = True
                Lawazim_Master.Visible = True
                Gift_Master.Visible = True
                TOURVISA_MASTER.Visible = True
                TaxesOfCountry_Master.Visible = True
                AddService_Master.Visible = True
                MiscExp_Master.Visible = True
                ImpDate_Master.Visible = True
                BlockDate_Master.Visible = True
                Transport_ConfigMaster.Visible = True
                MEAL_CONFIG.Visible = True
                CONTACT_MASTER.Visible = True
                TOUR_FILTER.Visible = True

            End If


            objhp.Refresh()
            objhp.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillYEAR()
        Try
            Dim objcmn As New ClsCommon
            Dim dt As DataTable
            Dim whereclause As String = ""
            'If UserName <> "Admin" Then
            '    dt = objcmn.search(" distinct user_YEARid", "", "UserMaster", " and User_Name = '" & UserName & "' and user_cmpid = " & CmpId)
            '    For Each DTROW As DataRow In dt.Rows
            '        If whereclause = "" Then
            '            whereclause = " AND YEAR_ID IN (" & DTROW(0)
            '        Else
            '            whereclause = whereclause & "|" & DTROW(0)
            '        End If
            '    Next
            '    whereclause = whereclause & ")"
            'End If

            dt = objcmn.search(" distinct user_YEARid", "", "UserMaster", " and User_Name = '" & UserName & "' and user_cmpid = " & CmpId)
            For Each DTROW As DataRow In dt.Rows
                If whereclause = "" Then
                    whereclause = " AND YEAR_ID IN (" & DTROW(0)
                Else
                    whereclause = whereclause & "," & DTROW(0)
                End If
            Next
            whereclause = whereclause & ")"

            dt = objcmn.search("CONVERT(char(11), year_startdate , 6) + '   ---   ' + CONVERT(char(11), year_enddate , 6) ", "", "YearMaster INNER JOIN cmpmaster on cmp_id = year_cmpid", whereclause & " order BY YEAR_ID")
            For Each DTROW As DataRow In dt.Rows
                cmbselectcmp.DropDownItems.Add(DTROW(0))
            Next
            cmbselectcmp.Text = CmpName
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewGroupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GROUPADD.Click
        Try
            Dim objGroupMaster As New GroupMaster
            objGroupMaster.MdiParent = Me
            objGroupMaster.Show()
            objGroupMaster.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewCityToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CITYADD.Click
        Try
            Dim objcitymaster As New citymaster
            objcitymaster.MdiParent = Me
            objcitymaster.frmstring = "CITYMASTER"
            objcitymaster.Show()
            objcitymaster.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewStateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STATEADD.Click
        Try
            Dim objcitymaster As New citymaster
            objcitymaster.MdiParent = Me
            objcitymaster.frmstring = "STATEMASTER"
            objcitymaster.Show()
            objcitymaster.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewCountryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COUNTRYADD.Click
        Try
            Dim objcitymaster As New citymaster
            objcitymaster.MdiParent = Me
            objcitymaster.frmstring = "COUNTRYMASTER"
            objcitymaster.Show()
            objcitymaster.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewAreaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AREAADD.Click
        Try
            Dim objcitymaster As New citymaster
            objcitymaster.MdiParent = Me
            objcitymaster.frmstring = "AREAMASTER"
            objcitymaster.Show()
            objcitymaster.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub HOTELADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HOTELADD.Click
        Try
            Dim OBJHOTEL As New HotelMaster
            OBJHOTEL.MdiParent = Me
            OBJHOTEL.Show()
            OBJHOTEL.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewAccountsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ACCADD.Click
        Try
            Dim objAccountMaster As New AccountsMaster
            objAccountMaster.MdiParent = Me
            objAccountMaster.frmstring = "ACCOUNTS"
            objAccountMaster.Show()
            objAccountMaster.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub addTax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TAXADD.Click
        Try
            Dim objtaxmaster As New Taxmaster
            objtaxmaster.MdiParent = Me
            objtaxmaster.Show()
            objtaxmaster.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingGroupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GROUPEDIT.Click
        Try
            Dim objGroupDetails As New GroupDetails
            objGroupDetails.MdiParent = Me
            objGroupDetails.Show()
            objGroupDetails.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingAccoutsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ACCEDIT.Click
        Try
            Dim objAccountDetails As New AccountsDetails
            objAccountDetails.MdiParent = Me
            objAccountDetails.frmstring = "ACCOUNTS"
            objAccountDetails.Show()
            objAccountDetails.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ACC_TOOL.Click
        Try
            Dim objAccountDetails As New AccountsDetails
            objAccountDetails.MdiParent = Me
            objAccountDetails.frmstring = "ACCOUNTS"
            objAccountDetails.Show()
            objAccountDetails.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HOTELEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HOTELEDIT.Click
        Try
            Dim OBJHOTEL As New HotelDetails
            OBJHOTEL.MdiParent = Me
            OBJHOTEL.Show()
            OBJHOTEL.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolstripItemCentre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HOTEL_TOOL.Click
        Try
            Dim OBJHOTEL As New HotelDetails
            OBJHOTEL.MdiParent = Me
            OBJHOTEL.Show()
            OBJHOTEL.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingAreaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AREAEDIT.Click
        Try
            Dim objCityDetails As New CityDetails
            objCityDetails.MdiParent = Me
            objCityDetails.frmstring = "AREAMASTER"
            objCityDetails.Show()
            objCityDetails.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingCityToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CITYEDIT.Click
        Try
            Dim objCityDetails As New CityDetails
            objCityDetails.MdiParent = Me
            objCityDetails.frmstring = "CITYMASTER"
            objCityDetails.Show()
            objCityDetails.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingStateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STATEEDIT.Click
        Try
            Dim objCityDetails As New CityDetails
            objCityDetails.MdiParent = Me
            objCityDetails.frmstring = "STATEMASTER"
            objCityDetails.Show()
            objCityDetails.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingCountryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COUNTRYEDIT.Click
        Try
            Dim objCityDetails As New CityDetails
            objCityDetails.MdiParent = Me
            objCityDetails.frmstring = "COUNTRYMASTER"
            objCityDetails.Show()
            objCityDetails.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditTax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TAXEDIT.Click
        Try
            Dim objtaxDetails As New TaxDetails
            objtaxDetails.MdiParent = Me
            objtaxDetails.Show()
            objtaxDetails.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripMenuItem14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim OBJREG As New RegisterMaster
            OBJREG.MdiParent = Me
            OBJREG.FRMSTRING = "SALE"
            OBJREG.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripMenuItem17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JVREGADD.Click
        Try
            Dim OBJREG As New RegisterMaster
            OBJREG.MdiParent = Me
            OBJREG.FRMSTRING = "JOURNAL"
            OBJREG.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripMenuItem19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CONTRAREGADD.Click
        Try
            Dim OBJREG As New RegisterMaster
            OBJREG.MdiParent = Me
            OBJREG.FRMSTRING = "CONTRA"
            OBJREG.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripMenuItem21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PAYMENTREGADD.Click
        Try
            Dim OBJREG As New RegisterMaster
            OBJREG.MdiParent = Me
            OBJREG.FRMSTRING = "PAYMENT"
            OBJREG.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripMenuItem23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RECEIPTREGADD.Click
        Try
            Dim OBJREG As New RegisterMaster
            OBJREG.MdiParent = Me
            OBJREG.FRMSTRING = "RECEIPT"
            OBJREG.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewJVToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JVADD.Click
        Try
            Dim objJournal As New journal
            objJournal.MdiParent = Me
            objJournal.Show()
            objJournal.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Money Twins")
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub toolstripPayments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PAY_TOOL.Click
        Try
            Dim OBJPAYMENT As New PaymentMaster
            OBJPAYMENT.MdiParent = Me
            OBJPAYMENT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewPaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PAYADD.Click
        Try
            Dim OBJPAYMENT As New PaymentMaster
            OBJPAYMENT.MdiParent = Me
            OBJPAYMENT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ChangeCompany_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeCompany.Click
        Try
            'close all child forms
            Dim frm As Form
            For Each frm In MdiChildren
                frm.Close()
            Next

            Me.Dispose()
            Cmpdetails.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolstripJournal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JV_TOOL.Click
        Try
            Dim OBJJV As New journal
            OBJJV.MdiParent = Me
            OBJJV.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingJVToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JVEDIT.Click
        Try
            Dim OBJJVDETAILS As New JournalDetails
            OBJJVDETAILS.MdiParent = Me
            OBJJVDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolstripReceipts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REC_TOOL.Click
        Try
            Dim OBJREC As New Receipt
            OBJREC.MdiParent = Me
            OBJREC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewReceiptToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RECADD.Click
        Try
            Dim OBJREC As New Receipt
            OBJREC.MdiParent = Me
            OBJREC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingReceiptToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RECEDIT.Click
        Try
            Dim OBJRECDETAILS As New ReceiptDetails
            OBJRECDETAILS.MdiParent = Me
            OBJRECDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaleRegisterToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaleRegisterToolStripMenuItem2.Click
        Try
            Dim objsalereg As New SaleRegister
            objsalereg.MdiParent = Me
            objsalereg.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PurchaseRegisterToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseRegisterToolStripMenuItem2.Click
        Try
            Dim objpurreg As New PurchaseRegister
            objpurreg.MdiParent = Me
            objpurreg.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JournalRegisterToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JournalRegisterToolStripMenuItem2.Click
        Try
            Dim OBJJVREG As New JournalRegister
            OBJJVREG.MdiParent = Me
            OBJJVREG.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BankBookToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankBookToolStripMenuItem.Click
        Try
            Dim OBJBANKREG As New BankRegister
            OBJBANKREG.MdiParent = Me
            OBJBANKREG.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CashBookToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CashBookToolStripMenuItem.Click
        Try
            Dim OBJCASHREG As New cashregister1
            OBJCASHREG.MdiParent = Me
            OBJCASHREG.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DayBookToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DayBookToolStripMenuItem.Click
        Try
            Dim objdaybook As New DayBook
            objdaybook.MdiParent = Me
            objdaybook.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewContraToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CONTRAADD.Click
        Try
            Dim OBJCONTRA As New ContraEntry
            OBJCONTRA.MdiParent = Me
            OBJCONTRA.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingVoucherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CONTRAEDIT.Click
        Try
            Dim OBJCONTRADETAILS As New ContraDetails
            OBJCONTRADETAILS.MdiParent = Me
            OBJCONTRADETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ContraRegisterToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContraRegisterToolStripMenuItem2.Click
        Try
            Dim OBJCONTRAREG As New ContraRegister
            OBJCONTRAREG.MdiParent = Me
            OBJCONTRAREG.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolstripHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolstripHome.Click
        Try
            If ClientName = "FINASTA" Then
                Dim objhp As New HomePage2
                objhp.MdiParent = Me
                objhp.Show()
            Else
                Dim objhp As New HomePage
                objhp.MdiParent = Me
                objhp.Show()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PurchaseTaxRegisterToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseTaxRegisterToolStripMenuItem1.Click
        Try
            Dim OBJTAXFILTER As New TaxRegisterFilter
            OBJTAXFILTER.FRMSTRING = "PURCHASE"
            OBJTAXFILTER.MdiParent = Me
            OBJTAXFILTER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SalesTaxRegisterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesTaxRegisterToolStripMenuItem.Click
        Try
            Dim OBJTAXFILTER As New TaxRegisterFilter
            OBJTAXFILTER.FRMSTRING = "SALES"
            OBJTAXFILTER.MdiParent = Me
            OBJTAXFILTER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub addUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles USERADD.Click
        Try
            Dim objuser As New UserMaster
            objuser.MdiParent = Me
            objuser.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub editUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles USEREDIT.Click
        Try
            Dim objuser As New UserDetails
            objuser.MdiParent = Me
            objuser.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbselectcmp_DropDownItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles cmbselectcmp.DropDownItemClicked
        Try
            'close all child forms
            Dim f As Form
            For Each f In MdiChildren
                f.Close()
            Next
            opencmp(e.ClickedItem.ToString())

            Dim objhp As New HomePage
            objhp.MdiParent = Me
            objhp.Show()

            cmbselectcmp.Text = CmpName
            Me.Text = CmpName & " (" & AccFrom & " - " & AccTo & ")"
            SETENABILITY()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub opencmp(ByVal CMP As String)
        Try

            Dim objcmn As New ClsCommon
            Dim DT As DataTable

            DT = objcmn.search("CMPMASTER.CMP_NAME, YEARMASTER.YEAR_DBNAME, CMPMASTER.CMP_ID, YEARMASTER.YEAR_STARTDATE, YEARMASTER.YEAR_ENDDATE, YEARMASTER.YEAR_ID", "", " CMPMASTER INNER JOIN YEARMASTER ON YEARMASTER.YEAR_CMPID = CMPMASTER.CMP_ID", " AND CMPMASTER.CMP_NAME = '" & CMP & "'")


            CmpName = DT.Rows(0).Item(0).ToString
            DBName = DT.Rows(0).Item(1).ToString
            CmpId = DT.Rows(0).Item(2).ToString
            AccFrom = DT.Rows(0).Item(3)
            AccTo = DT.Rows(0).Item(4)
            YearId = DT.Rows(0).Item(5).ToString

            'GETTING RIGHTS IN DATATABLE
            DT.Clear()
            DT = objcmn.search("User_id", "", "UserMaster", " and user_name = '" & UserName & "' AND USER_CMPID = " & CmpId)
            Userid = DT.Rows(0).Item(0)
            USERRIGHTS = objcmn.search("User_formName as [FormName], User_add as [Add], User_Edit as [Edit], User_View as [View], User_Delete as [Delete]", "", "USERMASTER_RIGHTS INNER JOIN USERMASTER ON USERMASTER.USER_ID = USERMASTER_RIGHTS.USER_ID AND USERMASTER.USER_CMPID = USERMASTER_RIGHTS.USER_CMPID", " and USERMASTER.USER_NAME = '" & UserName & "' and usermaster.user_CMPID = " & CmpId)


            'MDIMain.Show()
            'MDIMain.Refresh()
            Cmppassword.cmdback.Visible = False
            Cmppassword.lblretype.Visible = False
            Cmppassword.txtretypepassword.Visible = False
            Cmppassword.cmdnext.Text = "&Ok"
            Cmppassword.ShowDialog()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewUnitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UNITADD.Click
        Try
            Dim objunitmaster As New UnitMaster
            objunitmaster.MdiParent = Me
            objunitmaster.frmString = "UNIT"
            objunitmaster.Show()
            objunitmaster.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingUnitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UNITEDIT.Click
        Try
            Dim objUnitDetails As New UnitDetails
            objUnitDetails.MdiParent = Me
            objUnitDetails.frmstring = "UNIT"
            objUnitDetails.Show()
            objUnitDetails.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AdvancesSettlementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdvancesSettlementToolStripMenuItem.Click

        Try
            Dim objadv_rec_settlement As New Adv_Receivable_settlement
            objadv_rec_settlement.MdiParent = Me
            objadv_rec_settlement.flag_adv_settlement = True
            objadv_rec_settlement.flag_Rec_settlement = False
            objadv_rec_settlement.Show()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub ReceivableSettlementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReceivableSettlementToolStripMenuItem.Click
        Try
            Dim objadv_rec_settlement As New Adv_Receivable_settlement
            objadv_rec_settlement.MdiParent = Me
            objadv_rec_settlement.flag_adv_settlement = False
            objadv_rec_settlement.flag_Rec_settlement = True
            objadv_rec_settlement.Show()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub PaymentDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaymentDetailsToolStripMenuItem.Click
        Try
            Dim OBJFILTERDETAILS As New filter 'PayamentDetails
            OBJFILTERDETAILS.MdiParent = Me
            OBJFILTERDETAILS.frmstring = "PaymentDetails"
            OBJFILTERDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AdvancesPaidReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdvancesPaidReportToolStripMenuItem.Click
        Try
            Dim OBJFILTERDETAILS As New filter
            OBJFILTERDETAILS.MdiParent = Me
            OBJFILTERDETAILS.frmstring = "AdvancesPaidReport"
            OBJFILTERDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub AdvancesReToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdvancesReToolStripMenuItem.Click
        Try
            Dim OBJFILTERDETAILS As New filter
            OBJFILTERDETAILS.MdiParent = Me
            OBJFILTERDETAILS.frmstring = "AdvancesReceiveReport"
            OBJFILTERDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub ReceiptDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReceiptDetailsToolStripMenuItem.Click
        Try
            Dim OBJFILTERDETAILS As New filter
            OBJFILTERDETAILS.MdiParent = Me
            OBJFILTERDETAILS.frmstring = "ReceiptDetails"
            OBJFILTERDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PartyWiseToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PartyWiseToolStripMenuItem3.Click
        Try
            Dim OBJFILTERDETAILS As New filter
            OBJFILTERDETAILS.MdiParent = Me
            OBJFILTERDETAILS.frmstring = "Contra-PartyWise"
            OBJFILTERDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub PartyWiseToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PartyWiseToolStripMenuItem2.Click
        Try
            Dim OBJFILTERDETAILS As New filter
            OBJFILTERDETAILS.MdiParent = Me
            OBJFILTERDETAILS.frmstring = "Journal-PartyWise"
            OBJFILTERDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub PAYEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PAYEDIT.Click
        Try
            Dim objpAYdtls As New PaymentDetails
            objpAYdtls.MdiParent = Me
            objpAYdtls.Show()
            objpAYdtls.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CONTRA_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CONTRA_TOOL.Click
        Try
            Dim OBJCONTRA As New ContraEntry
            OBJCONTRA.MdiParent = Me
            OBJCONTRA.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TrialBalanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_MASTER.Click
        Try
            Dim OBJTB As New TB
            OBJTB.MdiParent = Me
            OBJTB.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SummaryToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SummaryToolStripMenuItem3.Click
        Try
            Dim OBJFILTERDETAILS As New filter
            OBJFILTERDETAILS.MdiParent = Me
            OBJFILTERDETAILS.frmstring = "Contra-Summary"
            OBJFILTERDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SummaryToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SummaryToolStripMenuItem2.Click
        Try
            Dim OBJFILTERDETAILS As New filter
            OBJFILTERDETAILS.MdiParent = Me
            OBJFILTERDETAILS.frmstring = "Journal-Summary"
            OBJFILTERDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ProfitLossToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PL_MASTER.Click
        Try
            Dim objpl As New PL
            objpl.MdiParent = Me
            objpl.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BalanceSheetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BS_MASTER.Click
        Try
            Dim OBJBALANCESHEET As New BS
            OBJBALANCESHEET.MdiParent = Me
            OBJBALANCESHEET.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AGENTADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AGENTADD.Click
        Try
            Dim OBJAGENT As New AgentMaster
            OBJAGENT.MdiParent = Me
            OBJAGENT.Show()
            OBJAGENT.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AGENTEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AGENTEDIT.Click
        Try
            Dim OBJAGENT As New AgentDetails
            OBJAGENT.MdiParent = Me
            OBJAGENT.Show()
            OBJAGENT.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ROOMADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROOMADD.Click
        Try
            Dim OBJROOMTYPE As New RoomTypeMaster
            OBJROOMTYPE.MdiParent = Me
            OBJROOMTYPE.FRMSTRING = "ROOMTYPE"
            OBJROOMTYPE.Show()
            OBJROOMTYPE.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HOTELTYPEADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HOTELTYPEADD.Click
        Try
            Dim OBJROOMTYPE As New RoomTypeMaster
            OBJROOMTYPE.MdiParent = Me
            OBJROOMTYPE.FRMSTRING = "HOTELTYPE"
            OBJROOMTYPE.Show()
            OBJROOMTYPE.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HOTELGROUPADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HOTELGROUPADD.Click
        Try
            Dim OBJROOMTYPE As New RoomTypeMaster
            OBJROOMTYPE.MdiParent = Me
            OBJROOMTYPE.FRMSTRING = "GROUPOFHOTELS"
            OBJROOMTYPE.Show()
            OBJROOMTYPE.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HOTELGROUPEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HOTELGROUPEDIT.Click
        Try
            Dim OBJROOMTYPE As New RoomTypeDetails
            OBJROOMTYPE.MdiParent = Me
            OBJROOMTYPE.FRMSTRING = "GROUPOFHOTELS"
            OBJROOMTYPE.Show()
            OBJROOMTYPE.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HOTELTYPEEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HOTELTYPEEDIT.Click
        Try
            Dim OBJROOMTYPE As New RoomTypeDetails
            OBJROOMTYPE.MdiParent = Me
            OBJROOMTYPE.FRMSTRING = "HOTELTYPE"
            OBJROOMTYPE.Show()
            OBJROOMTYPE.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ROOMEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROOMEDIT.Click
        Try
            Dim OBJROOMTYPE As New RoomTypeDetails
            OBJROOMTYPE.MdiParent = Me
            OBJROOMTYPE.FRMSTRING = "ROOMTYPE"
            OBJROOMTYPE.Show()
            OBJROOMTYPE.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AMENITIESADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AMENITIESADD.Click
        Try
            Dim OBJROOMTYPE As New RoomTypeMaster
            OBJROOMTYPE.MdiParent = Me
            OBJROOMTYPE.FRMSTRING = "AMENITIES"
            OBJROOMTYPE.Show()
            OBJROOMTYPE.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AMENITIESEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AMENITIESEDIT.Click
        Try
            Dim OBJROOMTYPE As New RoomTypeDetails
            OBJROOMTYPE.MdiParent = Me
            OBJROOMTYPE.FRMSTRING = "AMENITIES"
            OBJROOMTYPE.Show()
            OBJROOMTYPE.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HOTELBOOKING_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HOTELBOOKING_TOOL.Click
        Try
            Dim OBJBOOKING As New HotelBookings
            OBJBOOKING.FRMSTRING = "BOOKING"
            OBJBOOKING.MdiParent = Me
            OBJBOOKING.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SOURCEADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SOURCEADD.Click
        Try
            Dim OBJROOMTYPE As New RoomTypeMaster
            OBJROOMTYPE.MdiParent = Me
            OBJROOMTYPE.FRMSTRING = "SOURCE"
            OBJROOMTYPE.Show()
            OBJROOMTYPE.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SOURCEEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SOURCEEDIT.Click
        Try
            Dim OBJROOMTYPE As New RoomTypeDetails
            OBJROOMTYPE.MdiParent = Me
            OBJROOMTYPE.FRMSTRING = "SOURCE"
            OBJROOMTYPE.Show()
            OBJROOMTYPE.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EXPENSEADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VOUCHERADD.Click
        Try
            Dim OBJNP As New ExpenseVoucher
            OBJNP.FRMSTRING = "NONPURCHASE"
            OBJNP.MdiParent = Me
            OBJNP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EXPENSEEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VOUCHEREDIT.Click
        Try
            Dim OBJNPDETAILS As New ExpenseVoucherDetails
            OBJNPDETAILS.MdiParent = Me
            OBJNPDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewRegisterToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VOUCHERREGADD.Click
        Try
            Dim OBJREG As New RegisterMaster
            OBJREG.MdiParent = Me
            OBJREG.FRMSTRING = "EXPENSE"
            OBJREG.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub LedgerBookToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LedgerBookToolStripMenuItem1.Click
        Try
            Dim objledgerbook As New LedgerBook
            objledgerbook.MdiParent = Me
            objledgerbook.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LedgerOnScreenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LedgerOnScreenToolStripMenuItem.Click
        Try
            Dim objledger As New LedgerSummary
            objledger.MdiParent = Me
            objledger.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GroupWiseTransactionsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupWiseTransactionsToolStripMenuItem1.Click
        Try
            Dim OBJGROUP As New GroupFilter
            OBJGROUP.MdiParent = Me
            OBJGROUP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GroupSummaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupSummaryToolStripMenuItem.Click
        Try
            Dim OBJGROUP As New GroupRegister
            OBJGROUP.MdiParent = Me
            OBJGROUP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewVoucherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HOTELBOOKINGADD.Click
        Try
            Dim OBJBOOKING As New HotelBookings
            OBJBOOKING.FRMSTRING = "BOOKING"
            OBJBOOKING.MdiParent = Me
            OBJBOOKING.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingVoucherToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HOTELBOOKINGEDIT.Click
        Try
            Dim OBJBOOKING As New HotelBookingsDetails
            OBJBOOKING.FRMSTRING = "BOOKING"
            OBJBOOKING.MdiParent = Me
            OBJBOOKING.Show()
            OBJBOOKING.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub FLIGHTADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FLIGHTADD.Click
        Try
            Dim OBJFLIGHT As New FlightMaster
            OBJFLIGHT.MdiParent = Me
            OBJFLIGHT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FLIGHTEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FLIGHTEDIT.Click
        Try
            Dim OBJFLIGHT As New FlightDetails
            OBJFLIGHT.MdiParent = Me
            OBJFLIGHT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HOLIDAY_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HOLIDAY_TOOL.Click
        Try
            Dim OBJBOOKING As New HolidayPackage
            OBJBOOKING.MdiParent = Me
            OBJBOOKING.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HOLIDAYADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HOLIDAYADD.Click
        Try
            Dim OBJBOOKING As New HolidayPackage
            OBJBOOKING.MdiParent = Me
            OBJBOOKING.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HOLIDAYEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HOLIDAYEDIT.Click
        Try
            Dim OBJBOOKING As New HolidayPackageDetails
            OBJBOOKING.MdiParent = Me
            OBJBOOKING.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SendMailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendMailToolStripMenuItem.Click
        Try
            Dim OBJMAIL As New E_Mail
            OBJMAIL.MdiParent = Me
            OBJMAIL.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SendSMSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendSMSToolStripMenuItem.Click
        Try
            Dim OBJSMS As New SendSMS
            OBJSMS.MdiParent = Me
            OBJSMS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMPEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMPEDIT.Click
        Try
            Cmpmaster.edit = True
            Cmpmaster.TEMPCMPNAME = CmpName
            Cmpmaster.ShowDialog()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMPADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMPADD.Click
        Try
            Dim obj As New Cmpmaster
            obj.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub RoomInventoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RoomInventoryToolStripMenuItem.Click
        Try
            Dim OBJINVENTORY As New RoomInventory
            OBJINVENTORY.MdiParent = Me
            OBJINVENTORY.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FLIGHT_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FLIGHT_TOOL.Click
        Try
            Dim OBJFILGHT As New FlightDetails
            OBJFILGHT.MdiParent = Me
            OBJFILGHT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GUESTADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GUESTADD.Click
        Try
            Dim OBJGUEST As New GuestMaster
            OBJGUEST.MdiParent = Me
            OBJGUEST.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GUESTEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GUESTEDIT.Click
        Try
            Dim OBJGUEST As New GuestDetails
            OBJGUEST.MdiParent = Me
            OBJGUEST.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GUEST_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GUEST_TOOL.Click
        Try
            Dim OBJGUEST As New GuestDetails
            OBJGUEST.MdiParent = Me
            OBJGUEST.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ChangeUserToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeUserToolStripMenuItem.Click
        Try
            'close all child forms
            Dim frm As Form
            For Each frm In MdiChildren
                frm.Close()
            Next

            Me.Dispose()
            Login.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BACKUPCMP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BACKUPCMP.Click
        Try
            backup()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CheckInListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckInListToolStripMenuItem.Click
        Try
            Dim OBJCHECKIN As New CheckInList
            OBJCHECKIN.MdiParent = Me
            OBJCHECKIN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PayableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PayableToolStripMenuItem.Click
        Try
            Dim OBJFILTERDETAILS As New OutstandingFilter
            OBJFILTERDETAILS.MdiParent = Me
            OBJFILTERDETAILS.FRMSTRING = "payableoutstanding"
            OBJFILTERDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReceivableOutstandingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReceivableOutstandingToolStripMenuItem.Click
        Try
            Dim OBJFILTERDETAILS As New OutstandingFilter
            OBJFILTERDETAILS.MdiParent = Me
            OBJFILTERDETAILS.FRMSTRING = "receivableoutstanding"
            OBJFILTERDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PayableSummaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PayableSummaryToolStripMenuItem.Click
        Try
            Dim OBJFILTERDETAILS As New OutstandingFilter
            OBJFILTERDETAILS.MdiParent = Me
            OBJFILTERDETAILS.FRMSTRING = "payableoutstandingsummary"
            OBJFILTERDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReceivableSummaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReceivableSummaryToolStripMenuItem.Click
        Try
            Dim OBJFILTERDETAILS As New OutstandingFilter
            OBJFILTERDETAILS.MdiParent = Me
            OBJFILTERDETAILS.FRMSTRING = "receivableoutstandingsummary"
            OBJFILTERDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MERGELEDGER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MERGELEDGER.Click
        Try
            Dim objledger As New MergeLedger
            objledger.MdiParent = Me
            objledger.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaleReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaleReportToolStripMenuItem.Click
        Try
            Dim OBJRESERVATION As New SaleReportFilter
            OBJRESERVATION.MdiParent = Me
            OBJRESERVATION.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReservationDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReservationDetailsToolStripMenuItem.Click
        Try
            Dim OBJRESERVATION As New ReservationFilter
            OBJRESERVATION.MdiParent = Me
            OBJRESERVATION.FRMSTRING = "DETAILS"
            OBJRESERVATION.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TRANSFERADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TRANSFERADD.Click
        Try
            Dim OBJBOOKING As New HotelBookings
            OBJBOOKING.FRMSTRING = "TRANSFER"
            OBJBOOKING.MdiParent = Me
            OBJBOOKING.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TRANSFEREDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TRANSFEREDIT.Click
        Try
            Dim OBJBOOKING As New HotelBookingsDetails
            OBJBOOKING.FRMSTRING = "TRANSFER"
            OBJBOOKING.MdiParent = Me
            OBJBOOKING.Show()
            OBJBOOKING.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ReservationSummaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReservationSummaryToolStripMenuItem.Click
        Try
            Dim OBJRESERVATION As New ReservationFilter
            OBJRESERVATION.MdiParent = Me
            OBJRESERVATION.FRMSTRING = "SUMMARY"
            OBJRESERVATION.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OPENINGBILL_MASTER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OPENINGBILL_MASTER.Click
        Try
            Dim OBJOPENING As New OpeningBills
            OBJOPENING.MdiParent = Me
            OBJOPENING.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        LBLCHECKIN.Left = LBLCHECKIN.Left - 1
        LBLCHECKIN.Top = StatusStrip2.Top + 2
        CHECKIN_CMD.Top = StatusStrip2.Top - 4

        If LBLCHECKIN.Left < 0 - LBLCHECKIN.Width Then
            'Timer1.Enabled = False
            SCROLLERS()
            LBLCHECKIN.Left = Me.Width
        End If
        'Me.Refresh()
    End Sub

    Private Sub CHECKIN_CMD_Click() Handles CHECKIN_CMD.Click
        Try
            Dim OBJCHECKIN As New CheckInList
            OBJCHECKIN.MdiParent = Me
            OBJCHECKIN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ChartsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChartsToolStripMenuItem.Click
        Try
            Dim OBJCHART As New AnalyticalCharts
            OBJCHART.MdiParent = Me
            OBJCHART.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DEBITADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DEBITADD.Click
        Try
            Dim objDN As New DebitNote
            objDN.MdiParent = Me
            objDN.Show()
            objDN.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DEBITEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DEBITEDIT.Click
        Try
            Dim OBJDNDETAILS As New DebitNoteDetails
            OBJDNDETAILS.MdiParent = Me
            OBJDNDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CREDITADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CREDITADD.Click
        Try
            Dim objCN As New CREDITNOTE
            objCN.MdiParent = Me
            objCN.Show()
            objCN.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CREDITEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CREDITEDIT.Click
        Try
            Dim OBJCNDETAILS As New CreditNoteDetails
            OBJCNDETAILS.MdiParent = Me
            OBJCNDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReservationDetailsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReservationDetailsToolStripMenuItem1.Click
        Try
            Dim OBJRESERVATION As New ReservationFilter
            OBJRESERVATION.MdiParent = Me
            OBJRESERVATION.FRMSTRING = "PACKAGE DETAILS"
            OBJRESERVATION.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReservationDetailsToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReservationDetailsToolStripMenuItem2.Click
        Try
            Dim OBJRESERVATION As New ReservationFilter
            OBJRESERVATION.MdiParent = Me
            OBJRESERVATION.FRMSTRING = "VEHICLE DETAILS"
            OBJRESERVATION.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReservationDetailsToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReservationDetailsToolStripMenuItem3.Click
        Try
            Dim OBJRESERVATION As New ReservationFilter
            OBJRESERVATION.MdiParent = Me
            OBJRESERVATION.FRMSTRING = "CONSOLIDATED DETAILS"
            OBJRESERVATION.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReservationSummaryToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReservationSummaryToolStripMenuItem3.Click
        Try
            Dim OBJRESERVATION As New ReservationFilter
            OBJRESERVATION.MdiParent = Me
            OBJRESERVATION.FRMSTRING = "CONSOLIDATED SUMMARY"
            OBJRESERVATION.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PayableOutstandingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PayableOutstandingToolStripMenuItem.Click
        Try
            Dim OBJFILTERDETAILS As New OutstandingFilter
            OBJFILTERDETAILS.MdiParent = Me
            OBJFILTERDETAILS.FRMSTRING = "PACKAGE PAYABLEOUTSTANDING"
            OBJFILTERDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PayableOutstandingToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PayableOutstandingToolStripMenuItem1.Click
        Try
            Dim OBJFILTERDETAILS As New OutstandingFilter
            OBJFILTERDETAILS.MdiParent = Me
            OBJFILTERDETAILS.FRMSTRING = "INTERNATIONAL PAYABLEOUTSTANDING"
            OBJFILTERDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PayableOutstandingToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PayableOutstandingToolStripMenuItem2.Click
        Try
            Dim OBJFILTERDETAILS As New OutstandingFilter
            OBJFILTERDETAILS.MdiParent = Me
            'OBJFILTERDETAILS.frmstring = "CONSOLIDATED PAYABLEOUTSTANDING"
            OBJFILTERDETAILS.FRMSTRING = "payableoutstanding"
            OBJFILTERDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PayableSummaryToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PayableSummaryToolStripMenuItem1.Click
        Try
            Dim OBJFILTERDETAILS As New OutstandingFilter
            OBJFILTERDETAILS.MdiParent = Me
            OBJFILTERDETAILS.FRMSTRING = "PACKAGE PAYABLEOUTSTANDINGSUMMARY"
            OBJFILTERDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PayableSummaryToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PayableSummaryToolStripMenuItem2.Click
        Try
            Dim OBJFILTERDETAILS As New OutstandingFilter
            OBJFILTERDETAILS.MdiParent = Me
            OBJFILTERDETAILS.FRMSTRING = "INTERNATIONAL PAYABLEOUTSTANDINGSUMMARY"
            OBJFILTERDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PayableSummaryToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PayableSummaryToolStripMenuItem3.Click
        Try
            Dim OBJFILTERDETAILS As New OutstandingFilter
            OBJFILTERDETAILS.MdiParent = Me
            'OBJFILTERDETAILS.frmstring = "CONSOLIDATED PAYABLEOUTSTANDINGSUMMARY"
            OBJFILTERDETAILS.FRMSTRING = "payableoutstandingsummary"
            OBJFILTERDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReceivableOutstandingToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReceivableOutstandingToolStripMenuItem1.Click
        Try
            Dim OBJFILTERDETAILS As New OutstandingFilter
            OBJFILTERDETAILS.MdiParent = Me
            OBJFILTERDETAILS.FRMSTRING = "PACKAGE RECEIVABLEOUTSTANDING"
            OBJFILTERDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReceivableOutstandingToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReceivableOutstandingToolStripMenuItem2.Click
        Try
            Dim OBJFILTERDETAILS As New ReservationFilter
            OBJFILTERDETAILS.MdiParent = Me
            OBJFILTERDETAILS.FRMSTRING = "VEHICLEOUTSTANDING"
            OBJFILTERDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReceivableOutstandingToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReceivableOutstandingToolStripMenuItem3.Click
        Try
            Dim OBJFILTERDETAILS As New OutstandingFilter
            OBJFILTERDETAILS.MdiParent = Me
            'OBJFILTERDETAILS.frmstring = "CONSOLIDATED RECEIVABLEOUTSTANDING"
            OBJFILTERDETAILS.FRMSTRING = "receivableoutstanding"
            OBJFILTERDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReceivableSummaryToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReceivableSummaryToolStripMenuItem1.Click
        Try
            Dim OBJFILTERDETAILS As New OutstandingFilter
            OBJFILTERDETAILS.MdiParent = Me
            OBJFILTERDETAILS.FRMSTRING = "PACKAGE RECEIVABLEOUTSTANDINGSUMMARY"
            OBJFILTERDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReceivableSummaryToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReceivableSummaryToolStripMenuItem2.Click
        Try
            Dim OBJFILTERDETAILS As New OutstandingFilter
            OBJFILTERDETAILS.MdiParent = Me
            OBJFILTERDETAILS.FRMSTRING = "INTERNATIONAL RECEIVABLEOUTSTANDINGSUMMARY"
            OBJFILTERDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReceibvableSummaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReceibvableSummaryToolStripMenuItem.Click
        Try
            Dim OBJFILTERDETAILS As New OutstandingFilter
            OBJFILTERDETAILS.MdiParent = Me
            'OBJFILTERDETAILS.frmstring = "CONSOLIDATED RECEIVABLEOUTSTANDINGSUMMARY"
            OBJFILTERDETAILS.FRMSTRING = "receivableoutstandingsummary"
            OBJFILTERDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LedgerBillWiseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LedgerBillWiseToolStripMenuItem.Click
        Try
            Dim OBJBILL As New LedgerBillwise
            OBJBILL.MdiParent = Me
            OBJBILL.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DebitNoteRegisterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DebitNoteRegisterToolStripMenuItem.Click
        Try
            Dim OBJDNREG As New DNRegister
            OBJDNREG.MdiParent = Me
            OBJDNREG.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CreditNoteRegisterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreditNoteRegisterToolStripMenuItem.Click
        Try
            Dim OBJCNREG As New CNRegister
            OBJCNREG.MdiParent = Me
            OBJCNREG.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TRANSFER_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PROFORMA_TOOL.Click
        Try
            Dim OBJBOOKING As New ProformaHotelBookings
            OBJBOOKING.MdiParent = Me
            OBJBOOKING.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BALANCE_CMD_Click() Handles BALANCE_CMD.Click
        Try
            Dim OBJCHECKIN As New CheckInList
            OBJCHECKIN.MdiParent = Me
            OBJCHECKIN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        LBLBALANCE.Left = LBLBALANCE.Left - 2
        If LBLBALANCE.Left < 0 - LBLBALANCE.Width Then
            'Timer1.Enabled = False
            BALANCESCROLLER()
            LBLBALANCE.Left = Me.Width
        End If
    End Sub

    Private Sub SaleBalanceReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaleBalanceReportToolStripMenuItem.Click
        Try
            Dim OBJSB As New PendingBookings
            OBJSB.FRMSTRING = "SALEBALANCE"
            OBJSB.MdiParent = Me
            OBJSB.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EMPADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EMPADD.Click
        Try
            Dim OBJEMP As New EmployeeMaster
            OBJEMP.MdiParent = Me
            OBJEMP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EMPEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EMPEDIT.Click
        Try
            Dim OBJEMP As New EmployeeDetails
            OBJEMP.MdiParent = Me
            OBJEMP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DESIGNATIONADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DESIGNATIONADD.Click
        Try
            Dim OBJROOMTYPE As New RoomTypeMaster
            OBJROOMTYPE.MdiParent = Me
            OBJROOMTYPE.FRMSTRING = "DESIGNATION"
            OBJROOMTYPE.Show()
            OBJROOMTYPE.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DESIGNATIONEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DESIGNATIONEDIT.Click
        Try
            Dim OBJROOMTYPE As New RoomTypeDetails
            OBJROOMTYPE.MdiParent = Me
            OBJROOMTYPE.FRMSTRING = "DESIGNATION"
            OBJROOMTYPE.Show()
            OBJROOMTYPE.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DEPARTMENTADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DEPARTMENTADD.Click
        Try
            Dim OBJROOMTYPE As New RoomTypeMaster
            OBJROOMTYPE.MdiParent = Me
            OBJROOMTYPE.FRMSTRING = "DEPARTMENT"
            OBJROOMTYPE.Show()
            OBJROOMTYPE.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DEPARTMENTEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DEPARTMENTEDIT.Click
        Try
            Dim OBJROOMTYPE As New RoomTypeDetails
            OBJROOMTYPE.MdiParent = Me
            OBJROOMTYPE.FRMSTRING = "DEPARTMENT"
            OBJROOMTYPE.Show()
            OBJROOMTYPE.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function CHECKEMP(ByVal ENROLLNO As Integer) As Boolean
        Try
            Dim BLN As Boolean = False
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("EMP_ID", "", " EMPLOYEEMASTER", " AND EMP_ENROLLNO = '" & ENROLLNO & "' AND EMP_CMPID = " & CmpId & " AND EMP_LOCATIONID = " & Locationid & " AND EMP_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then BLN = True
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub POLICYADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POLICYADD.Click
        Try
            Dim OBJPOLICY As New CancelPolicyMaster
            OBJPOLICY.MdiParent = Me
            OBJPOLICY.FRMSTRING = "POLICY"
            OBJPOLICY.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub POLICYEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POLICYEDIT.Click
        Try
            Dim OBJPOLICY As New CancelPolicyDetails
            OBJPOLICY.MdiParent = Me
            OBJPOLICY.FRMSTRING = "POLICY"
            OBJPOLICY.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub NOTESADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NOTEADD.Click
        Try
            Dim OBJPOLICY As New CancelPolicyMaster
            OBJPOLICY.MdiParent = Me
            OBJPOLICY.FRMSTRING = "NOTES"
            OBJPOLICY.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub NOTESEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NOTEEDIT.Click
        Try
            Dim OBJPOLICY As New CancelPolicyDetails
            OBJPOLICY.MdiParent = Me
            OBJPOLICY.FRMSTRING = "NOTES"
            OBJPOLICY.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewEnquiryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DOMESTICENQADD.Click
        Try
            Dim OBJENQ As New HotelQuotation
            OBJENQ.MdiParent = Me
            OBJENQ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingEnquiryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DOMESTICENQEDIT.Click
        Try
            Dim OBJENQ As New HotelQuotationDetails
            OBJENQ.MdiParent = Me
            OBJENQ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AttendenceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ATT_MASTER.Click
        Try
            Dim OBJATT As New Attendence
            OBJATT.MdiParent = Me
            OBJATT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HOLIDAYENQADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HOLIDAYENQADD.Click
        Try
            Dim OBJENQ As New PackageQuotation
            OBJENQ.MdiParent = Me
            OBJENQ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HOLIDAYENQEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HOLIDAYENQEDIT.Click
        Try
            If ClientName = "TRAVELBRIDGE" Then
                Dim OBJENQ As New PackageQuotationGridDetails
                OBJENQ.MdiParent = Me
                OBJENQ.Show()
            Else
                Dim OBJENQ As New PackageQuotationDetails
                OBJENQ.MdiParent = Me
                OBJENQ.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SALARYADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALARYADD.Click
        Try
            Dim OBJSAL As New SalaryMaster
            OBJSAL.MdiParent = Me
            OBJSAL.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SALARYEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALARYEDIT.Click
        Try
            Dim OBJSAL As New SalaryDetails
            OBJSAL.MdiParent = Me
            OBJSAL.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RECODATA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RECODATA.Click
        Try
            Dim TEMPMSG As Integer = MsgBox("Reconcile Data?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then

                Dim OBJURECO As New ClsDataReco
                Dim ALPARAVAL As New ArrayList
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                OBJURECO.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBJURECO.RECO()

                MsgBox("Data Reconcilation Done Successfully")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PaymentBillWiseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaymentBillWiseToolStripMenuItem.Click
        Try
            Dim OBJFILTERDETAILS As New filter 'PayamentDetails
            OBJFILTERDETAILS.MdiParent = Me
            OBJFILTERDETAILS.frmstring = "PAYMENTBILLWISE"
            OBJFILTERDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReceiptBillWiseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReceiptBillWiseToolStripMenuItem.Click
        Try
            Dim OBJFILTERDETAILS As New filter
            OBJFILTERDETAILS.MdiParent = Me
            OBJFILTERDETAILS.frmstring = "RECEIPTBILLWISE"
            OBJFILTERDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub STOCKADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STOCKADD.Click
        Try
            Dim OBJAIRLINE As New AirlineStockMaster
            OBJAIRLINE.MdiParent = Me
            OBJAIRLINE.FRMSTRING = "BSP"
            OBJAIRLINE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub STOCKEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STOCKEDIT.Click
        Try
            Dim OBJAIRLINE As New AirlineStockDetails
            OBJAIRLINE.MdiParent = Me
            OBJAIRLINE.FRMSTRING = "BSP"
            OBJAIRLINE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MEMBERDETAILS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MEMBERDETAILS.Click
        Try
            Dim OBJMEMBER As New MembershipMaster
            OBJMEMBER.MdiParent = Me
            OBJMEMBER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LOYALTYPROGRAMME_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LOYALTYPROGRAMME.Click
        Try
            Dim OBJLOYAL As New LoyaltyProgram
            OBJLOYAL.MdiParent = Me
            OBJLOYAL.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub YEARTRANSFER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles YEARTRANSFER.Click
        Try
            Dim OBJYEAR As New YearTransfer
            OBJYEAR.FRMSTRING = "YEARTRANSFER"
            OBJYEAR.MdiParent = Me
            OBJYEAR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TARGETADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TARGETADD.Click
        Try
            Dim OBJTARGET As New TargetMaster
            OBJTARGET.MdiParent = Me
            OBJTARGET.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TARGETEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TARGETEDIT.Click
        Try
            Dim OBJTARGET As New TargetDetails
            OBJTARGET.MdiParent = Me
            OBJTARGET.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GridAgeingReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridAgeingReportToolStripMenuItem.Click
        Try
            Dim OBJAR As New AgeingReportGrid
            OBJAR.MdiParent = Me
            OBJAR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub YEARADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles YEARADD.Click
        Try
            Dim TEMPMSG As Integer = MsgBox("Create New Accounting Year?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                Dim obj As New YearMaster
                If CheckFormStatus(YearMaster) Then
                    Exit Sub
                End If
                obj.cmdback.Visible = False
                obj.EDIT = False
                obj.FRMSTRING = "ADDYEAR"
                obj.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function CheckFormStatus(ByVal Myform As Form) As Boolean

        Dim objForm As Form
        Dim FlgLoaded As Boolean
        Dim FlgShown As Boolean
        FlgLoaded = False
        FlgShown = False
        For Each objForm In MdiChildren
            If (Trim(objForm.Name) = Trim(Myform.Name)) Then
                FlgLoaded = True
                If objForm.Visible Then
                    FlgShown = True

                End If
                Exit For
            End If
        Next
        Return FlgShown
    End Function

    Private Sub EmployeeTargetReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TARGET_REPORT.Click
        Try
            Dim OBJTARGET As New TargetReport
            OBJTARGET.MdiParent = Me
            OBJTARGET.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AIRLINESEGMENT_MASTER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AIRLINESEGMENT_MASTER.Click
        Try
            Dim OBJSEG As New AirlineSegmentRate
            OBJSEG.MdiParent = Me
            OBJSEG.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub COUPONADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COUPONADD.Click
        Try
            Dim OBJAIRLINE As New AirlineStockMaster
            OBJAIRLINE.MdiParent = Me
            OBJAIRLINE.FRMSTRING = "COUPON"
            OBJAIRLINE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub COUPONEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COUPONEDIT.Click
        Try
            Dim OBJAIRLINE As New AirlineStockDetails
            OBJAIRLINE.MdiParent = Me
            OBJAIRLINE.FRMSTRING = "COUPON"
            OBJAIRLINE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AIRCREDITADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AIRCREDITADD.Click
        Try
            Dim OBJAIRLINE As New AirlineCreditNote
            OBJAIRLINE.MdiParent = Me
            OBJAIRLINE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AIRCREDITEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AIRCREDITEDIT.Click
        Try
            Dim OBJAIRLINE As New AirlineCreditNoteDetails
            OBJAIRLINE.MdiParent = Me
            OBJAIRLINE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AIRDEBITADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AIRDEBITADD.Click
        Try
            Dim OBJAIRLINE As New AirlineDebitNote
            OBJAIRLINE.MdiParent = Me
            OBJAIRLINE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AIRDEBITEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AIRDEBITEDIT.Click
        Try
            Dim OBJAIRLINE As New AirlineDebitNoteDetails
            OBJAIRLINE.MdiParent = Me
            OBJAIRLINE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MEALPLANSADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MEALPLANSADD.Click
        Try
            Dim OBJROOMTYPE As New RoomTypeMaster
            OBJROOMTYPE.MdiParent = Me
            OBJROOMTYPE.FRMSTRING = "MEALPLAN"
            OBJROOMTYPE.Show()
            OBJROOMTYPE.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MEALPLANEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MEALPLANEDIT.Click
        Try
            Dim OBJROOMTYPE As New RoomTypeDetails
            OBJROOMTYPE.MdiParent = Me
            OBJROOMTYPE.FRMSTRING = "MEALPLAN"
            OBJROOMTYPE.Show()
            OBJROOMTYPE.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AIRDOM_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AIRDOM_TOOL.Click
        Try
            Dim OBJAIRLINE As New AirlineBookings
            OBJAIRLINE.MdiParent = Me
            OBJAIRLINE.FRMSTRING = "DOMESTIC"
            OBJAIRLINE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AIRINT_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AIRINT_TOOL.Click
        Try
            Dim OBJAIRLINE As New AirlineBookings
            OBJAIRLINE.MdiParent = Me
            OBJAIRLINE.FRMSTRING = "INTERNATIONAL"
            OBJAIRLINE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AIRDOMADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AIRDOMADD.Click
        Try
            Dim OBJAIRLINE As New AirlineBookings
            OBJAIRLINE.MdiParent = Me
            OBJAIRLINE.FRMSTRING = "DOMESTIC"
            OBJAIRLINE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AIRDOMEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AIRDOMEDIT.Click
        Try
            Dim OBJAIRLINE As New AirlineBookingDetails
            OBJAIRLINE.MdiParent = Me
            OBJAIRLINE.FRMSTRING = "DOMESTIC"
            OBJAIRLINE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AIRINTADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AIRINTADD.Click
        Try
            Dim OBJAIRLINE As New AirlineBookings
            OBJAIRLINE.MdiParent = Me
            OBJAIRLINE.FRMSTRING = "INTERNATIONAL"
            OBJAIRLINE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AIRINTEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AIRINTEDIT.Click
        Try
            Dim OBJAIRLINE As New AirlineBookingDetails
            OBJAIRLINE.MdiParent = Me
            OBJAIRLINE.FRMSTRING = "INTERNATIONAL"
            OBJAIRLINE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AirToolStripMenuItem.Click
        'Try
        '    Dim objbsp As New BspStock
        '    objbsp.MdiParent = Me
        '    objbsp.Show()
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub

    Private Sub VEHICLETYPEADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VEHICLETYPEADD.Click
        Try
            Dim OBJROOMTYPE As New RoomTypeMaster
            OBJROOMTYPE.MdiParent = Me
            OBJROOMTYPE.FRMSTRING = "VEHICLETYPE"
            OBJROOMTYPE.Show()
            OBJROOMTYPE.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub VEHICLETYPEEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VEHICLETYPEEDIT.Click
        Try
            Dim OBJROOMTYPE As New RoomTypeDetails
            OBJROOMTYPE.MdiParent = Me
            OBJROOMTYPE.FRMSTRING = "VEHICLETYPE"
            OBJROOMTYPE.Show()
            OBJROOMTYPE.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub VEHICLEADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VEHICLEADD.Click
        Try
            Dim OBJVEHICEL As New VehicleMaster
            OBJVEHICEL.MdiParent = Me
            OBJVEHICEL.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub VEHICLEEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VEHICLEEDIT.Click
        Try
            Dim OBJVEHICEL As New VehicleDetails
            OBJVEHICEL.MdiParent = Me
            OBJVEHICEL.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MISCPURREGADD.Click
        Try
            Dim OBJREG As New RegisterMaster
            OBJREG.MdiParent = Me
            OBJREG.FRMSTRING = "MISC. PURCHASE"
            OBJREG.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MISCSALEREGADD.Click
        Try
            Dim OBJREG As New RegisterMaster
            OBJREG.MdiParent = Me
            OBJREG.FRMSTRING = "MISC. SALE"
            OBJREG.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DRIVERADD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DRIVERADD.Click
        Try
            Dim OBJDRIVER As New DriverMaster
            OBJDRIVER.MdiParent = Me
            OBJDRIVER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DRIVEREDIT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DRIVEREDIT.Click
        Try
            Dim OBJDRIVER As New DriverDetails
            OBJDRIVER.MdiParent = Me
            OBJDRIVER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CARADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CARADD.Click
        Try
            Dim OBJCAR As New CarBooking
            OBJCAR.MdiParent = Me
            OBJCAR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CAREDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CAREDIT.Click
        Try
            Dim OBJCAR As New CarBookingDetails
            OBJCAR.MdiParent = Me
            OBJCAR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BSPStockReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSPStockReportToolStripMenuItem.Click
        Try
            Dim objbsp As New BspStock
            objbsp.MdiParent = Me
            objbsp.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReservationDetailsToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReservationDetailsToolStripMenuItem4.Click
        Try
            Dim OBJRESERVATION As New AirReservationFilter
            OBJRESERVATION.MdiParent = Me
            OBJRESERVATION.FRMSTRING = "AIRLINE DETAILS"
            OBJRESERVATION.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PayableOutstandingToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PayableOutstandingToolStripMenuItem3.Click
        Try
            Dim OBJFILTERDETAILS As New OutstandingFilter
            OBJFILTERDETAILS.MdiParent = Me
            OBJFILTERDETAILS.FRMSTRING = "AIRLINE PAYABLEOUTSTANDING"
            OBJFILTERDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PayableSummaryToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PayableSummaryToolStripMenuItem4.Click
        Try
            Dim OBJFILTERDETAILS As New OutstandingFilter
            OBJFILTERDETAILS.MdiParent = Me
            OBJFILTERDETAILS.FRMSTRING = "AIRLINE PAYABLEOUTSTANDINGSUMMARY"
            OBJFILTERDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReceivableOutstandingToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReceivableOutstandingToolStripMenuItem4.Click
        Try
            Dim OBJFILTERDETAILS As New OutstandingFilter
            OBJFILTERDETAILS.MdiParent = Me
            OBJFILTERDETAILS.FRMSTRING = "AIRLINE RECEIVABLEOUTSTANDING"
            OBJFILTERDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReceivableSummaryToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReceivableSummaryToolStripMenuItem3.Click
        Try
            Dim OBJFILTERDETAILS As New OutstandingFilter
            OBJFILTERDETAILS.MdiParent = Me
            OBJFILTERDETAILS.FRMSTRING = "AIRLINE RECEIVABLEOUTSTANDINGSUMMARY"
            OBJFILTERDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub MISCPURADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MISCPURADD.Click
        Try
            Dim OBJMISC As New MiscPur
            OBJMISC.MdiParent = Me
            OBJMISC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MISCPUREDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MISCPUREDIT.Click
        Try
            Dim OBJMISC As New MiscPurDetails
            OBJMISC.MdiParent = Me
            OBJMISC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MISCSALADD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MISCSALADD.Click
        Try
            Dim OBJMISC As New MiscSale
            OBJMISC.MdiParent = Me
            OBJMISC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MISCSALEDIT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MISCSALEDIT.Click
        Try
            Dim OBJMISC As New MiscSaleDetails
            OBJMISC.MdiParent = Me
            OBJMISC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BOOKEDBYADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOOKEDBYADD.Click
        Try
            Dim OBJBOOKEDBY As New RoomTypeMaster
            OBJBOOKEDBY.MdiParent = Me
            OBJBOOKEDBY.FRMSTRING = "BOOKEDBY"
            OBJBOOKEDBY.Show()
            OBJBOOKEDBY.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BOOKEDBYEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOOKEDBYEDIT.Click
        Try
            Dim OBJBOOKEDBY As New RoomTypeDetails
            OBJBOOKEDBY.MdiParent = Me
            OBJBOOKEDBY.FRMSTRING = "BOOKEDBY"
            OBJBOOKEDBY.Show()
            OBJBOOKEDBY.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RAILADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RAILADD.Click
        Try
            Dim OBJRAIL As New RailwayBooking
            OBJRAIL.MdiParent = Me
            OBJRAIL.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RAILEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RAILEDIT.Click
        Try
            Dim OBJRAIL As New RailwayBookingDetails
            OBJRAIL.MdiParent = Me
            OBJRAIL.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MATCHINGADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MATCHINGADD.Click
        Try
            Dim OBJMATCH As New Matching
            OBJMATCH.MdiParent = Me
            OBJMATCH.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Private Sub AxCZKEM1_OnVerify(ByVal sender As Object, ByVal e As Axzkemkeeper._IZKEMEvents_OnVerifyEvent) Handles AxCZKEM1.OnVerify
    '    Try
    '        If e.userID > 0 Then
    '            Dim OBJATT As New ClsAttendence
    '            Dim ALPARAVAL As New ArrayList

    '            ALPARAVAL.Add(e.userID)
    '            ALPARAVAL.Add(CmpId)
    '            ALPARAVAL.Add(Locationid)
    '            ALPARAVAL.Add(YearId)

    '            OBJATT.alParaval = ALPARAVAL
    '            Dim I As Integer = OBJATT.save
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub GROUPDEPADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GROUPDEPADD.Click
        Try
            Dim OBJDEPRT As New GroupDeparture
            OBJDEPRT.MdiParent = Me
            OBJDEPRT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GROUPDEPEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GROUPDEPEDIT.Click
        Try
            Dim OBJGROUPDEP As New GroupDepartureDetails
            OBJGROUPDEP.MdiParent = Me
            OBJGROUPDEP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReservationSummaryToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReservationSummaryToolStripMenuItem1.Click
        Try
            Dim OBJRESERVATION As New AirReservationFilter
            OBJRESERVATION.MdiParent = Me
            OBJRESERVATION.FRMSTRING = "AIRLINE SUMMARY"
            OBJRESERVATION.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        Try
            Dim OBJRESERVATION As New ReservationFilter
            OBJRESERVATION.MdiParent = Me
            OBJRESERVATION.FRMSTRING = "RAIL DETAILS"
            OBJRESERVATION.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AnalyticalReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnalyticalReportsToolStripMenuItem.Click
        Try
            Dim OBJCHART As New ChartFilter
            OBJCHART.MdiParent = Me
            OBJCHART.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub USERTRANSFER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles USERTRANSFER.Click
        Try
            Dim OBJYEAR As New YearTransfer
            OBJYEAR.FRMSTRING = "USERTRANSFER"
            OBJYEAR.MdiParent = Me
            OBJYEAR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TotalSaleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TotalSaleToolStripMenuItem.Click
        Try
            Dim OBJSALE As New TotalSaleReport
            OBJSALE.MdiParent = Me
            OBJSALE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CityWiseSaleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CityWiseSaleToolStripMenuItem.Click
        Try
            Dim OBJCITY As New CityWiseSaleReport
            OBJCITY.MdiParent = Me
            OBJCITY.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HotelWiseSaleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HotelWiseSaleToolStripMenuItem.Click
        Try
            Dim OBJCITY As New HotelWiseSaleReport
            OBJCITY.MdiParent = Me
            OBJCITY.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExecutiveWiseSaleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExecutiveWiseSaleToolStripMenuItem.Click
        Try
            Dim OBJCITY As New CityWiseSaleReport
            OBJCITY.MdiParent = Me
            OBJCITY.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BLOCKUSER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BLOCKUSER.Click
        Try
            Dim OBJUSER As New BlockUser
            OBJUSER.MdiParent = Me
            OBJUSER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PurchaseBalanceReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseBalanceReportToolStripMenuItem.Click
        Try
            Dim OBJSB As New PendingBookings
            OBJSB.FRMSTRING = "PURBALANCE"
            OBJSB.MdiParent = Me
            OBJSB.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ConsolidatedBalanceReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsolidatedBalanceReportToolStripMenuItem.Click
        Try
            Dim OBJSB As New PendingBookings
            OBJSB.FRMSTRING = "ALLBALANCE"
            OBJSB.MdiParent = Me
            OBJSB.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MERGEPARAMETER_MASTER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MERGEPARAMETER_MASTER.Click
        Try
            Dim OBJMERGE As New MERGEPARAMETER
            OBJMERGE.MdiParent = Me
            OBJMERGE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RefWiseSaleReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefWiseSaleReportToolStripMenuItem.Click
        Try
            Dim OBJSB As New RefWiseSaleReport
            OBJSB.FRMSTRING = "SALEBALANCE"
            OBJSB.MdiParent = Me
            OBJSB.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RefWisePurchaseReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefWisePurchaseReportToolStripMenuItem.Click
        Try
            Dim OBJSB As New RefWiseSaleReport
            OBJSB.FRMSTRING = "PURBALANCE"
            OBJSB.MdiParent = Me
            OBJSB.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RefWiseConsolidatedReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefWiseConsolidatedReportToolStripMenuItem.Click
        Try
            Dim OBJSB As New RefWiseSaleReport
            OBJSB.FRMSTRING = "ALLBALANCE"
            OBJSB.MdiParent = Me
            OBJSB.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddTarrifPlanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TARIFFADD.Click
        Try
            Dim OBJTARIFF As New Tariff
            OBJTARIFF.MdiParent = Me
            OBJTARIFF.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PurchaseTDSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseTDSToolStripMenuItem.Click
        Try
            Dim OBJTDS As New PurchaseTDSReport
            OBJTDS.MdiParent = Me
            OBJTDS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TRAINADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TRAINADD.Click
        Try
            Dim OBJTRAIN As New TrainMaster
            OBJTRAIN.MdiParent = Me
            OBJTRAIN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewLoginToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LOGINADD.Click
        Try
            Dim objcitymaster As New citymaster
            objcitymaster.MdiParent = Me
            objcitymaster.frmstring = "LOGINMASTER"
            objcitymaster.Show()
            objcitymaster.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingLoginToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LOGINEDIT.Click
        Try
            Dim objCityDetails As New CityDetails
            objCityDetails.MdiParent = Me
            objCityDetails.frmstring = "LOGINMASTER"
            objCityDetails.Show()
            objCityDetails.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub STATIONADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STATIONADD.Click
        Try
            Dim OBJSTATION As New StationMaster
            OBJSTATION.MdiParent = Me
            OBJSTATION.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TRAINEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TRAINEDIT.Click
        Try
            Dim OBJTRAIN As New TrainDetails
            OBJTRAIN.MdiParent = Me
            OBJTRAIN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub STATIONEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STATIONEDIT.Click
        Try
            Dim OBJSTATION As New StationDetails
            OBJSTATION.MdiParent = Me
            OBJSTATION.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddIDTypeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IDTYPEADD.Click
        Try
            Dim objcitymaster As New citymaster
            objcitymaster.MdiParent = Me
            objcitymaster.frmstring = "IDMASTER"
            objcitymaster.Show()
            objcitymaster.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IDTYPEEDIT.Click
        Try
            Dim objCityDetails As New CityDetails
            objCityDetails.MdiParent = Me
            objCityDetails.frmstring = "IDMASTER"
            objCityDetails.Show()
            objCityDetails.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TARIFFEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TARIFFEDIT.Click
        Try
            Dim OBJTARIFF As New TariffDetails
            OBJTARIFF.MdiParent = Me
            OBJTARIFF.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DeleteLogsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELETELOGS_MENU.Click
        Try
            If UserName = "Admin" Then
                Dim OBJDEL As New DeleteDetails
                OBJDEL.MdiParent = Me
                OBJDEL.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        Try
            Dim OBJFILTERDETAILS As New OutstandingFilter
            OBJFILTERDETAILS.MdiParent = Me
            OBJFILTERDETAILS.FRMSTRING = "RAIL PAYABLEOUTSTANDING"
            OBJFILTERDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem7.Click
        Try
            Dim OBJFILTERDETAILS As New OutstandingFilter
            OBJFILTERDETAILS.MdiParent = Me
            OBJFILTERDETAILS.FRMSTRING = "RAIL PAYABLEOUTSTANDINGSUMMARY"
            OBJFILTERDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem8.Click
        Try
            Dim OBJFILTERDETAILS As New OutstandingFilter
            OBJFILTERDETAILS.MdiParent = Me
            OBJFILTERDETAILS.FRMSTRING = "RAIL RECEIVABLEOUTSTANDING"
            OBJFILTERDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripMenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem9.Click
        Try
            Dim OBJFILTERDETAILS As New OutstandingFilter
            OBJFILTERDETAILS.MdiParent = Me
            OBJFILTERDETAILS.FRMSTRING = "RAIL RECEIVABLEOUTSTANDINGSUMMARY"
            OBJFILTERDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UpdateLogsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UPDATELOGS_MENU.Click
        Try
            If UserName = "Admin" Then
                Dim OBJUPDATE As New UpdateDetails
                OBJUPDATE.MdiParent = Me
                OBJUPDATE.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RailwayConfigToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RAILCONFIG.Click
        Try
            Dim OBJCON As New RailwayConfig
            OBJCON.MdiParent = Me
            OBJCON.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CofiguratorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CofiguratorToolStripMenuItem.Click
        Try
            If UserName <> "ADMIN" Then Exit Sub
            Dim OBJCON As New Moduleconfig
            OBJCON.MdiParent = Me
            OBJCON.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OpeningAmountToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OPENINGBALANCE.Click
        Try
            Dim OBJOP As New OpeningBalance
            OBJOP.MdiParent = Me
            OBJOP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OPENINGDRCR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OPENINGDRCR.Click
        Try
            Dim ObjOpdrcr As New OpeningDrCr
            ObjOpdrcr.MdiParent = Me
            ObjOpdrcr.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LedgerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LedgerToolStripMenuItem.Click
        Try
            If UserName = "Admin" Then
                Dim OBJLEDGER As New Ledgers
                OBJLEDGER.frmstring = "ACCOUNTS"
                OBJLEDGER.MdiParent = Me
                OBJLEDGER.Show()
            Else
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddCurrencyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddCurrencyToolStripMenuItem.Click
        Try
            Dim ObjCURR As New CurrencyMaster
            ObjCURR.MdiParent = Me
            ObjCURR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditExistingToolStripMenuItem.Click
        Try
            Dim objCityDetails As New CityDetails
            objCityDetails.MdiParent = Me
            objCityDetails.frmstring = "CURRENCYMASTER"
            objCityDetails.Show()
            objCityDetails.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddLawazimMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddLawazimMasterToolStripMenuItem.Click
        Try
            Dim objLawazim As New LawazimMaster
            objLawazim.frmstring = "LAWAZIMMASTER"
            objLawazim.MdiParent = Me
            objLawazim.Show()
            objLawazim.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingLawazimToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditExistingLawazimToolStripMenuItem.Click
        Try
            Dim objCityDetails As New LawazimDetails
            objCityDetails.MdiParent = Me
            objCityDetails.frmstring = "LAWAZIMMASTER"
            objCityDetails.Show()
            objCityDetails.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewNationalityToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewNationalityToolStripMenuItem.Click
        Try
            Dim objNAT As New NationalityMaster
            objNAT.MdiParent = Me
            objNAT.Show()
            objNAT.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditNationalityToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditNationalityToolStripMenuItem.Click
        Try
            Dim objCityDetails As New CityDetails
            objCityDetails.MdiParent = Me
            objCityDetails.frmstring = "NATIONALITY"
            objCityDetails.Show()
            objCityDetails.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewGiftToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewGiftToolStripMenuItem.Click
        Try
            Dim ObjCity As New citymaster
            ObjCity.frmstring = "GIFTMASTER"
            ObjCity.MdiParent = Me
            ObjCity.Show()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub ToolStripMenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem10.Click
        Try
            Dim objCityDetails As New CityDetails
            objCityDetails.MdiParent = Me
            objCityDetails.frmstring = "GIFTMASTER"
            objCityDetails.Show()
            objCityDetails.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddVisaMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddVisaMasterToolStripMenuItem.Click
        Try
            Dim objLawazim As New LawazimMaster
            objLawazim.frmstring = "VISA"
            objLawazim.MdiParent = Me
            objLawazim.Show()
            objLawazim.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddTaxesOfCountryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddTaxesOfCountryToolStripMenuItem.Click
        Try
            Dim objLawazim As New LawazimMaster
            objLawazim.frmstring = "TAX"
            objLawazim.MdiParent = Me
            objLawazim.Show()
            objLawazim.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingVisaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditExistingVisaToolStripMenuItem.Click
        Try
            Dim objCityDetails As New LawazimDetails
            objCityDetails.MdiParent = Me
            objCityDetails.frmstring = "VISA"
            objCityDetails.Show()
            objCityDetails.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingTaxesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditExistingTaxesToolStripMenuItem.Click
        Try
            Dim objCityDetails As New LawazimDetails
            objCityDetails.MdiParent = Me
            objCityDetails.frmstring = "TAX"
            objCityDetails.Show()
            objCityDetails.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AdditionalServiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdditionalServiceToolStripMenuItem.Click
        Try
            Dim objLawazim As New LawazimMaster
            objLawazim.frmstring = "ADDSERVICE"
            objLawazim.MdiParent = Me
            objLawazim.Show()
            objLawazim.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingServicesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditExistingServicesToolStripMenuItem.Click
        Try
            Dim objCityDetails As New LawazimDetails
            objCityDetails.MdiParent = Me
            objCityDetails.frmstring = "ADDSERVICE"
            objCityDetails.Show()
            objCityDetails.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddMiscExpensesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddMiscExpensesToolStripMenuItem.Click
        Try
            Dim objLawazim As New LawazimMaster
            objLawazim.frmstring = "MISCEXP"
            objLawazim.MdiParent = Me
            objLawazim.Show()
            objLawazim.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditExistingToolStripMenuItem1.Click
        Try
            Dim objCityDetails As New LawazimDetails
            objCityDetails.MdiParent = Me
            objCityDetails.frmstring = "MISCEXP"
            objCityDetails.Show()
            objCityDetails.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddImpDateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddImpDateToolStripMenuItem.Click
        Try
            Dim objDATE As New ImpDateMaster
            objDATE.frmstring = "IMPDATE"
            objDATE.MdiParent = Me
            objDATE.Show()
            objDATE.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingDateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditExistingDateToolStripMenuItem.Click
        Try
            Dim objDATE As New ImpDateDetail
            objDATE.frmstring = "IMPDATE"
            objDATE.MdiParent = Me
            objDATE.Show()
            objDATE.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddBlockDateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddBlockDateToolStripMenuItem.Click
        Try
            Dim objDATE As New BlockDateMaster
            objDATE.frmstring = "BLOCKDATE"
            objDATE.MdiParent = Me
            objDATE.Show()
            objDATE.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingBlockDateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditExistingBlockDateToolStripMenuItem.Click
        Try
            Dim objDATE As New ImpDateDetail
            objDATE.frmstring = "BLOCKDATE"
            objDATE.MdiParent = Me
            objDATE.Show()
            objDATE.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddTourMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOURADD.Click
        Try
            Dim objDATE As New TourMaster
            objDATE.MdiParent = Me
            objDATE.Show()
            objDATE.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddTransportServicesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddTransportServicesToolStripMenuItem.Click
        Try
            Dim objMeal As New LawazimMaster
            objMeal.frmstring = "TRANSPORT"
            objMeal.MdiParent = Me
            objMeal.Show()
            objMeal.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingServicesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditExistingServicesToolStripMenuItem1.Click
        Try
            Dim objCityDetails As New LawazimDetails
            objCityDetails.MdiParent = Me
            objCityDetails.frmstring = "TRANSPORT"
            objCityDetails.Show()
            objCityDetails.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripMenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem11.Click
        Try
            Dim objMeal As New MealConfigurator
            objMeal.frmstring = "MEALMASTER"
            objMeal.MdiParent = Me
            objMeal.Show()
            objMeal.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripMenuItem12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem12.Click
        Try
            Dim objCityDetails As New LawazimDetails
            objCityDetails.MdiParent = Me
            objCityDetails.frmstring = "MEALMASTER"
            objCityDetails.Show()
            objCityDetails.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub REGISTRATIONADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REGISTRATIONADD.Click
        Try
            Dim objReg As New RegistrationMaster
            objReg.MdiParent = Me
            objReg.Show()
            objReg.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub REGISTRATIONEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REGISTRATIONEDIT.Click
        Try
            Dim objReg As New RegistrationDetails
            objReg.MdiParent = Me
            objReg.Show()
            objReg.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BookingDetailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BookingDetailToolStripMenuItem.Click
        Try
            Dim objReg As New DetailForm
            objReg.FRMSTRING = "BOOKING"
            objReg.MdiParent = Me
            objReg.Show()
            objReg.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TransferDetailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransferDetailToolStripMenuItem.Click
        Try
            Dim objReg As New DetailForm
            objReg.FRMSTRING = "TRANSFER"
            objReg.MdiParent = Me
            objReg.Show()
            objReg.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GiftPurchaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GIFTPUR_MASTER.Click
        'Try
        '    Dim objReg As New GiftPurchase
        '    objReg.MdiParent = Me
        '    objReg.Show()
        '    objReg.BringToFront()
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub

    Private Sub TOUREDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOUREDIT.Click
        Try
            Dim objReg As New TourDetails
            objReg.MdiParent = Me
            objReg.Show()
            objReg.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewPurchaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GIFTPURADD.Click
        Try
            Dim objReg As New GiftPurchase
            objReg.MdiParent = Me
            objReg.Show()
            objReg.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingPurchaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GIFTPUREDIT.Click
        Try
            Dim objGiftdet As New GiftPurchaseDetails
            objGiftdet.MdiParent = Me
            objGiftdet.Show()
            objGiftdet.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddPurchaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SERVPURADD.Click
        Try
            Dim objpur As New PurchaseInvoice
            objpur.MdiParent = Me
            objpur.Show()
            objpur.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SERVPUREDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SERVPUREDIT.Click
        Try
            Dim objpur As New PurchaseInvoiceDetail
            objpur.MdiParent = Me
            objpur.Show()
            objpur.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TourFilterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TourFilterToolStripMenuItem.Click
        Try
            Dim OBJTOUR As New TourFilter
            OBJTOUR.MdiParent = Me
            OBJTOUR.Show()
            OBJTOUR.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewContactsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewContactsToolStripMenuItem.Click
        Try
            Dim OBJCONTACT As New Contact
            OBJCONTACT.MdiParent = Me
            OBJCONTACT.Show()
            OBJCONTACT.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingContactsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditExistingContactsToolStripMenuItem.Click
        Try
            Dim OBJCONTACT As New ContactDetail
            OBJCONTACT.MdiParent = Me
            OBJCONTACT.Show()
            OBJCONTACT.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddEnquiryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VISAENQADD.Click
        Try
            Dim OBJVISA As New VisaEnquiry
            OBJVISA.MdiParent = Me
            OBJVISA.Show()
            OBJVISA.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DOCUMENTEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DOCUMENTEDIT.Click
        Try
            Dim objCityDetails As New CityDetails
            objCityDetails.MdiParent = Me
            objCityDetails.frmstring = "DOCUMENT"
            objCityDetails.Show()
            objCityDetails.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DOCUMENTADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DOCUMENTADD.Click
        Try
            Dim objcitymaster As New citymaster
            objcitymaster.MdiParent = Me
            objcitymaster.frmstring = "DOCUMENT"
            objcitymaster.Show()
            objcitymaster.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub VISAENQEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VISAENQEDIT.Click
        Try
            Dim OBJVISA As New VisaEnquiryDetails
            OBJVISA.MdiParent = Me
            OBJVISA.Show()
            OBJVISA.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddVisaBookingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VISAADD.Click
        Try
            Dim OBJVISA As New VisaBooking
            OBJVISA.MdiParent = Me
            OBJVISA.Show()
            OBJVISA.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub VISAEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VISAEDIT.Click
        Try
            Dim OBJVISA As New VisaBookingDetails
            OBJVISA.MdiParent = Me
            OBJVISA.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FOREXENQADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FOREXENQADD.Click
        Try
            Dim OBJFOREX As New ForexEnquiry
            OBJFOREX.MdiParent = Me
            OBJFOREX.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FOREXENQEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FOREXENQEDIT.Click
        Try
            Dim OBJFOREXENQ As New ForexEnquiryDetails
            OBJFOREXENQ.MdiParent = Me
            OBJFOREXENQ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ForexFilterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ForexFilterToolStripMenuItem.Click
        Try
            Dim OBJFOREXFILTER As New ForexEnquiryFilter
            OBJFOREXFILTER.MdiParent = Me
            OBJFOREXFILTER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HotelEnquiryFilterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HOTELQUOTATIONFILTER_MASTER.Click
        Try
            Dim OBJHOTELENQ As New HotelEnquiryFilter
            OBJHOTELENQ.MdiParent = Me
            OBJHOTELENQ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PackageEnquiryFilterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PACKAGEQUOTATIONFILTER_MASTER.Click
        Try
            Dim OBJPACKAGEENQ As New PackageEnquiryFilter
            OBJPACKAGEENQ.MdiParent = Me
            OBJPACKAGEENQ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub VisaEnquiryFilterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VisaEnquiryFilterToolStripMenuItem.Click
        Try
            Dim OBJVISAENQ As New VisaEnquiryFilter
            OBJVISAENQ.MdiParent = Me
            OBJVISAENQ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EntryLogsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ENTRYLOGS_MENU.Click
        Try
            Dim OBJENTRYDETAILS As New EntryDetails
            OBJENTRYDETAILS.MdiParent = Me
            OBJENTRYDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MISCENQADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MISCENQADD.Click
        Try
            Dim OBJMISCENQ As New MiscEnquiry
            OBJMISCENQ.MdiParent = Me
            OBJMISCENQ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MISCENQEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MISCENQEDIT.Click
        Try
            Dim OBJMISCENQ As New MiscEnquiryDetails
            OBJMISCENQ.MdiParent = Me
            OBJMISCENQ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MiscEnquiryFilterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MiscEnquiryFilterToolStripMenuItem.Click
        Try
            Dim OBJMISCENQ As New MiscEnquiryFilter
            OBJMISCENQ.MdiParent = Me
            OBJMISCENQ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GROUPDEP_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GROUPDEP_TOOL.Click
        Try
            Dim OBJDEPRT As New GroupDeparture
            OBJDEPRT.MdiParent = Me
            OBJDEPRT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub StageMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StageMasterToolStripMenuItem.Click
        Try
            Dim OBJSTAGE As New StageMaster
            OBJSTAGE.MdiParent = Me
            OBJSTAGE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PackageEnquiryFollowupReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PackageEnquiryFollowupReportToolStripMenuItem.Click
        Try
            Dim OBJFOLLOWUP As New FollowupReport
            OBJFOLLOWUP.MdiParent = Me
            OBJFOLLOWUP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HotelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HotelToolStripMenuItem.Click
        Try
            Dim OBJHOTELFOLLOWUP As New HotelEnqFollowupReport
            OBJHOTELFOLLOWUP.MdiParent = Me
            OBJHOTELFOLLOWUP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GUESTCATEGORYADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GUESTCATEGORYADD.Click
        Try
            Dim OBJGUEST As New GuestCategoryMaster
            OBJGUEST.MdiParent = Me
            OBJGUEST.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GUESTCATEGORYEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GUESTCATEGORYEDIT.Click
        Try
            Dim OBJGUEST As New GuestCatrgoryDetails
            OBJGUEST.MdiParent = Me
            OBJGUEST.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GROUPDEPFILTER_MASTER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GROUPDEPFILTER_MASTER.Click
        Try
            Dim OBJGROUP As New GroupDepartureFilter
            OBJGROUP.MdiParent = Me
            OBJGROUP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub INTERNATIONALADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INTERNATIONALADD.Click
        Try
            Dim OBJBOOKING As New InternationalBookings
            OBJBOOKING.MdiParent = Me
            OBJBOOKING.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub INTERNATIONALEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INTERNATIONALEDIT.Click
        Try
            Dim OBJBOOKING As New InternationalBookingsDetails
            OBJBOOKING.MdiParent = Me
            OBJBOOKING.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub VEHICLENOADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VEHICLENOADD.Click
        Try
            Dim OBJVEHICLE As New VehicleNoMaster
            OBJVEHICLE.MdiParent = Me
            OBJVEHICLE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub VEHICLENOEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VEHICLENOEDIT.Click
        Try
            Dim OBJVEHICLE As New VehicleNoDetails
            OBJVEHICLE.MdiParent = Me
            OBJVEHICLE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub VEHICLERATECHART_MASTER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VEHICLERATECHART_MASTER.Click
        Try
            Dim OBJVEHICLE As New VehicleRateList
            OBJVEHICLE.MdiParent = Me
            OBJVEHICLE.FRMSTRING = "SALERATE"
            OBJVEHICLE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub VEHICLERATECHARTPUR_MASTER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VEHICLERATECHARTPUR_MASTER.Click
        Try
            Dim OBJVEHICLE As New VehicleRateList
            OBJVEHICLE.MdiParent = Me
            OBJVEHICLE.FRMSTRING = "PURRATE"
            OBJVEHICLE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CARBOOKING_SALEREPORT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CARBOOKING_SALEREPORT.Click
        Try
            Dim OBJRESERVATION As New ReservationFilter
            OBJRESERVATION.MdiParent = Me
            OBJRESERVATION.FRMSTRING = "VEHICLESALE"
            OBJRESERVATION.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CARBOOKING_PURREPORT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CARBOOKING_PURREPORT.Click
        Try
            Dim OBJRESERVATION As New ReservationFilter
            OBJRESERVATION.MdiParent = Me
            OBJRESERVATION.FRMSTRING = "VEHICLEPUR"
            OBJRESERVATION.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CARBOOKING_INVOICEREPORT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CARBOOKING_INVOICEREPORT.Click
        Try
            Dim OBJRESERVATION As New ReservationFilter
            OBJRESERVATION.MdiParent = Me
            OBJRESERVATION.FRMSTRING = "VEHICLEINVOICE"
            OBJRESERVATION.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JVREGEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JVREGEDIT.Click
        Try
            Dim OBJREG As New RegisterMasterDelete
            OBJREG.MdiParent = Me
            OBJREG.frmstring = "JOURNAL"
            OBJREG.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CONTRAREGEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CONTRAREGEDIT.Click
        Try
            Dim OBJREG As New RegisterMasterDelete
            OBJREG.MdiParent = Me
            OBJREG.FRMSTRING = "CONTRA"
            OBJREG.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PAYMENTREGEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PAYMENTREGEDIT.Click
        Try
            Dim OBJREG As New RegisterMasterDelete
            OBJREG.MdiParent = Me
            OBJREG.FRMSTRING = "PAYMENT"
            OBJREG.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RECEIPTREGEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RECEIPTREGEDIT.Click
        Try
            Dim OBJREG As New RegisterMasterDelete
            OBJREG.MdiParent = Me
            OBJREG.FRMSTRING = "RECEIPT"
            OBJREG.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub VOUCHERREGEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VOUCHERREGEDIT.Click
        Try
            Dim OBJREG As New RegisterMasterDelete
            OBJREG.MdiParent = Me
            OBJREG.FRMSTRING = "EXPENSE"
            OBJREG.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub MISCPURREGEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MISCPURREGEDIT.Click
        Try
            Dim OBJREG As New RegisterMasterDelete
            OBJREG.MdiParent = Me
            OBJREG.FRMSTRING = "MISC. PURCHASE"
            OBJREG.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MISCSALEREGEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MISCSALEREGEDIT.Click
        Try
            Dim OBJREG As New RegisterMasterDelete
            OBJREG.MdiParent = Me
            OBJREG.FRMSTRING = "MISC. SALE"
            OBJREG.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LedgerFilterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LedgerFilterToolStripMenuItem.Click
        Try
            Dim OBJLEDGER As New LedgerFilter
            OBJLEDGER.MdiParent = Me
            OBJLEDGER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaleTDSReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaleTDSReportToolStripMenuItem.Click
        Try
            Dim OBJTDS As New SaleTDSReport
            OBJTDS.MdiParent = Me
            OBJTDS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ITINERARYADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ITINERARYADD.Click
        Try
            Dim OBJITINERARY As New ItineraryMaster
            OBJITINERARY.MdiParent = Me
            OBJITINERARY.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ITINERARYEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ITINERARYEDIT.Click
        Try
            Dim OBJITINERARY As New ItineraryDetails
            OBJITINERARY.MdiParent = Me
            OBJITINERARY.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MISCPUR_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MISCPUR_TOOL.Click
        Try
            Dim OBJMISC As New MiscPur
            OBJMISC.MdiParent = Me
            OBJMISC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MISCSALE_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MISCSALE_TOOL.Click
        Try
            Dim OBJMISC As New MiscSale
            OBJMISC.MdiParent = Me
            OBJMISC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GUESTLEDGERCONFIG_MASTER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GUESTLEDGERCONFIG_MASTER.Click
        Try
            Dim OBJCOFIG As New GuestLedgerConfig
            OBJCOFIG.MdiParent = Me
            OBJCOFIG.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub InterestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InterestToolStripMenuItem.Click
        Try
            Dim OBJINTCALC As New InterestCalc
            OBJINTCALC.MdiParent = Me
            OBJINTCALC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub IntrestCalculatorSummaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IntrestCalculatorSummaryToolStripMenuItem.Click
        Try
            Dim OBJINTCALC As New InterestCalc_Summary
            OBJINTCALC.MdiParent = Me
            OBJINTCALC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub VISA_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VISA_TOOL.Click
        Try
            Dim OBJVISA As New VisaBooking
            OBJVISA.MdiParent = Me
            OBJVISA.Show()
            OBJVISA.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SYNCDATA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SYNCDATA.Click
        Try
            Dim OBJSYNC As New SyncDate
            OBJSYNC.MdiParent = Me
            OBJSYNC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SPECIALRIGHTS_MASTER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SPECIALRIGHTS_MASTER.Click
        Try
            Dim OBJADMIN As New SpecialRights
            OBJADMIN.MdiParent = Me
            OBJADMIN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ROE_MASTER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROE_MASTER.Click
        Try
            Dim OBJROE As New RateOfExchangeMaster
            OBJROE.MdiParent = Me
            OBJROE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#Region "RENUMBERING"

    Private Sub RENUMBERING_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RENUMBERING.Click
        Try

            If InputBox("Enter Master Password", "TRAVELMATE") <> "1902" Then
                MsgBox("Invalid Password")
                Exit Sub
            End If

            If MsgBox("You are about to Renumber Entries, Please Take Backup First, Wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub


            If MsgBox("Wish To Renumber Jounal Entries?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then JOURNALRENUMBERING()
            If MsgBox("Wish To Renumber Payment Entries?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then PAYMENTRENUMBERING()
            If MsgBox("Wish To Renumber Receipt Entries?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then RECEIPTRENUMBERING()

            If ClientName = "CLASSIC" Then
                If MsgBox("Wish To Renumber Transfer Entries?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then TRANSFERRENUMBERING()
            End If

            MsgBox("Re-Numbering done Successfully")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub JOURNALRENUMBERING()
        Try
            'RENUMBER JOUNRAL VOUCHER FIRST
            Dim OBJCMN As New ClsCommon
            Dim DTREGISTER As DataTable = OBJCMN.search("REGISTER_ID AS REGID, REGISTER_NAME AS REGNAME, REGISTER_ABBR AS REGABBR, REGISTER_INITIALS AS REGINITIALS", "", " REGISTERMASTER ", " AND REGISTER_TYPE = 'JOURNAL' AND REGISTER_YEARID = " & YearId)
            If DTREGISTER.Rows.Count > 0 Then
                For Each REGROW As DataRow In DTREGISTER.Rows

                    'SEARCH ENTRY IN THIS REGISTER AND ADD IN TEMP TABLE
                    'FROM THIS TEMPTABLE WE WILL UPDATE THE ENTRIES
                    'WE WILL UPDATE THE ENTRYIES FROM THEIR OLDINITIALS, AND REPLACE WITH NEW INITIALS
                    'BUT NEW INITIALS WILL CONTAIN A SPECIAL CHARACTER SO THAT WE CAN DISTINGUISH BETWEEN OLD AND NEW INITIALS\
                    'ONCE ALL ENTRIES ARE UPDATED WE WILL REMOVE THAT SPECIAL CHARACTER
                    Dim DTENTRY As DataTable = OBJCMN.search("DISTINCT  JOURNAL_NO AS OLDNO, journal_registerid AS REGID, JOURNAL_DATE AS DATE, journal_initials AS OLDINITIALS, journal_yearid AS YEARID ", "", " JOURNALMASTER ", " AND journal_registerid = " & REGROW("REGID") & " AND JOURNAL_YEARID = " & YearId & " ORDER BY journal_registerid, journal_date,journal_no")
                    Dim NEWBILLNO As Integer = 1
                    Dim TEMPDT As DataTable = OBJCMN.Execute_Any_String("DELETE FROM TEMPRENUMBERING WHERE YEARID = " & YearId, "", "")
                    For Each DTROW As DataRow In DTENTRY.Rows
                        TEMPDT = OBJCMN.Execute_Any_String("INSERT INTO TEMPRENUMBERING VALUES (" & DTROW("REGID") & ",'" & Format(Convert.ToDateTime(DTROW("DATE")).Date, "MM/dd/yyyy") & "'," & DTROW("YEARID") & "," & DTROW("OLDNO") & ",'" & DTROW("OLDINITIALS") & "'," & NEWBILLNO & ",'" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N')", "", "")

                        'UPDATE IN JOURNALMASTER
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE JOURNALMASTER SET JOURNAL_NO = " & NEWBILLNO & ",JOURNAL_INITIALS = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE JOURNAL_INITIALS = '" & DTROW("OLDINITIALS") & "' AND JOURNAL_YEARID = " & YearId, "", "")
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE JOURNALMASTER SET JOURNAL_REFNO = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE JOURNAL_REFNO = '" & DTROW("OLDINITIALS") & "' AND JOURNAL_YEARID = " & YearId, "", "")

                        'UPDATE IN ACCMASTER 
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE ACCMASTER SET ACC_BILLNO = " & NEWBILLNO & ",ACC_INITIALS = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE ACC_INITIALS = '" & DTROW("OLDINITIALS") & "' AND ACC_YEARID = " & YearId, "", "")

                        'UPDATE IN PAYMENT MASTER
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE PAYMENTMASTER_DESC SET PAYMENT_BILLINITIALS = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE PAYMENT_BILLINITIALS = '" & DTROW("OLDINITIALS") & "' AND PAYMENT_YEARID = " & YearId, "", "")
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE PAYMENTMASTER_GRIDDESC SET PAYMENT_PAYBILLINITIALS = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE PAYMENT_PAYBILLINITIALS = '" & DTROW("OLDINITIALS") & "' AND PAYMENT_YEARID = " & YearId, "", "")

                        'UPDATE IN RECEIPTMASTER 
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE RECEIPTMASTER_DESC SET RECEIPT_BILLINITIALS = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE RECEIPT_BILLINITIALS = '" & DTROW("OLDINITIALS") & "' AND RECEIPT_YEARID = " & YearId, "", "")
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE RECEIPTMASTER_GRIDDESC SET RECEIPT_PAYBILLINITIALS = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE RECEIPT_PAYBILLINITIALS = '" & DTROW("OLDINITIALS") & "' AND RECEIPT_YEARID = " & YearId, "", "")


                        'UPDATE IN TDSCHALLAN
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE TDSCHALLAN SET TDSCHA_BILLNO = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE TDSCHA_BILLNO = '" & DTROW("OLDINITIALS") & "' AND TDSCHA_YEARID = " & YearId, "", "")


                        NEWBILLNO += 1
                    Next

                    'REMOVE SPECIAL CHARACTER FROM INTIIALS
                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE JOURNALMASTER SET JOURNAL_INITIALS = LEFT(JOURNAL_INITIALS, LEN(JOURNAL_INITIALS)-1) WHERE JOURNAL_YEARID = " & YearId, "", "")
                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE JOURNALMASTER SET JOURNAL_REFNO = LEFT(JOURNAL_REFNO, LEN(JOURNAL_REFNO)-1) FROM JOURNALMASTER INNER JOIN TEMPRENUMBERING ON NEWINITIALS = JOURNAL_REFNO AND YEARID = JOURNAL_YEARID WHERE JOURNAL_YEARID = " & YearId, "", "")
                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE ACCMASTER SET ACC_INITIALS = LEFT(ACC_INITIALS, LEN(ACC_INITIALS)-1) WHERE ACC_YEARID = " & YearId & " AND ACC_TYPE = 'JOURNAL' AND ACC_REGTYPE = '" & REGROW("REGABBR") & "'", "", "")
                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE PAYMENTMASTER_DESC SET PAYMENT_BILLINITIALS = LEFT(PAYMENT_BILLINITIALS, LEN(PAYMENT_BILLINITIALS)-1) FROM PAYMENTMASTER_DESC INNER JOIN TEMPRENUMBERING ON NEWINITIALS = PAYMENT_BILLINITIALS AND YEARID = PAYMENT_YEARID  WHERE PAYMENT_YEARID = " & YearId, "", "")
                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE PAYMENTMASTER_GRIDDESC SET PAYMENT_PAYBILLINITIALS = LEFT(PAYMENT_PAYBILLINITIALS, LEN(PAYMENT_PAYBILLINITIALS)-1) FROM PAYMENTMASTER_GRIDDESC INNER JOIN TEMPRENUMBERING ON NEWINITIALS = PAYMENT_PAYBILLINITIALS AND YEARID = PAYMENT_YEARID WHERE PAYMENT_YEARID = " & YearId, "", "")
                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE RECEIPTMASTER_DESC SET RECEIPT_BILLINITIALS = LEFT(RECEIPT_BILLINITIALS, LEN(RECEIPT_BILLINITIALS)-1) FROM RECEIPTMASTER_DESC INNER JOIN TEMPRENUMBERING ON NEWINITIALS = RECEIPT_BILLINITIALS AND YEARID = RECEIPT_YEARID  WHERE RECEIPT_YEARID = " & YearId, "", "")
                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE RECEIPTMASTER_GRIDDESC SET RECEIPT_PAYBILLINITIALS = LEFT(RECEIPT_PAYBILLINITIALS, LEN(RECEIPT_PAYBILLINITIALS)-1) FROM RECEIPTMASTER_GRIDDESC INNER JOIN TEMPRENUMBERING ON NEWINITIALS = RECEIPT_PAYBILLINITIALS AND YEARID = RECEIPT_YEARID WHERE RECEIPT_YEARID = " & YearId, "", "")
                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE TDSCHALLAN SET TDSCHA_BILLNO = LEFT(TDSCHA_BILLNO, LEN(TDSCHA_BILLNO)-1) FROM TDSCHALLAN INNER JOIN TEMPRENUMBERING ON NEWINITIALS = TDSCHA_BILLNO AND YEARID = TDSCHA_YEARID WHERE TDSCHA_YEARID = " & YearId, "", "")
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PAYMENTRENUMBERING()
        Try
            'RENUMBER JOUNRAL VOUCHER FIRST
            Dim OBJCMN As New ClsCommon
            Dim DTREGISTER As DataTable = OBJCMN.search("REGISTER_ID AS REGID, REGISTER_NAME AS REGNAME, REGISTER_ABBR AS REGABBR, REGISTER_INITIALS AS REGINITIALS", "", " REGISTERMASTER ", " AND REGISTER_TYPE = 'PAYMENT' AND REGISTER_YEARID = " & YearId)
            If DTREGISTER.Rows.Count > 0 Then
                For Each REGROW As DataRow In DTREGISTER.Rows

                    'SEARCH ENTRY IN THIS REGISTER AND ADD IN TEMP TABLE
                    'FROM THIS TEMPTABLE WE WILL UPDATE THE ENTRIES
                    'WE WILL UPDATE THE ENTRYIES FROM THEIR OLDINITIALS, AND REPLACE WITH NEW INITIALS
                    'BUT NEW INITIALS WILL CONTAIN A SPECIAL CHARACTER SO THAT WE CAN DISTINGUISH BETWEEN OLD AND NEW INITIALS\
                    'ONCE ALL ENTRIES ARE UPDATED WE WILL REMOVE THAT SPECIAL CHARACTER
                    Dim DTENTRY As DataTable = OBJCMN.search("DISTINCT  PAYMENT_NO AS OLDNO, PAYMENT_registerid AS REGID, PAYMENT_DATE AS DATE, PAYMENT_initials AS OLDINITIALS, PAYMENT_yearid AS YEARID ", "", " PAYMENTMASTER ", " AND PAYMENT_registerid = " & REGROW("REGID") & " AND PAYMENT_YEARID = " & YearId & " ORDER BY PAYMENT_registerid, PAYMENT_date, PAYMENT_no")
                    Dim NEWBILLNO As Integer = 1
                    Dim TEMPDT As DataTable = OBJCMN.Execute_Any_String("DELETE FROM TEMPRENUMBERING WHERE YEARID = " & YearId, "", "")
                    For Each DTROW As DataRow In DTENTRY.Rows
                        TEMPDT = OBJCMN.Execute_Any_String("INSERT INTO TEMPRENUMBERING VALUES (" & DTROW("REGID") & ",'" & Format(Convert.ToDateTime(DTROW("DATE")).Date, "MM/dd/yyyy") & "'," & DTROW("YEARID") & "," & DTROW("OLDNO") & ",'" & DTROW("OLDINITIALS") & "'," & NEWBILLNO & ",'" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N')", "", "")

                        'UPDATE IN PAYMENT MASTER
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE PAYMENTMASTER SET PAYMENT_NO = " & NEWBILLNO & ", PAYMENT_INITIALS = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE PAYMENT_INITIALS = '" & DTROW("OLDINITIALS") & "' AND PAYMENT_YEARID = " & YearId, "", "")
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE PAYMENTMASTER_DESC SET PAYMENT_NO = " & NEWBILLNO & ", PAYMENT_INITIALS = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE PAYMENT_INITIALS = '" & DTROW("OLDINITIALS") & "' AND PAYMENT_YEARID = " & YearId, "", "")
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE PAYMENTMASTER_GRIDDESC SET PAYMENT_NO = " & NEWBILLNO & ", PAYMENT_INITIALS = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE PAYMENT_INITIALS = '" & DTROW("OLDINITIALS") & "' AND PAYMENT_YEARID = " & YearId, "", "")


                        'UPDATE IN JOURNALMASTER
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE JOURNALMASTER SET JOURNAL_REFNO = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE JOURNAL_REFNO = '" & DTROW("OLDINITIALS") & "' AND JOURNAL_YEARID = " & YearId, "", "")

                        'UPDATE IN ACCMASTER 
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE ACCMASTER SET ACC_BILLNO = " & NEWBILLNO & ",ACC_INITIALS = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE ACC_INITIALS = '" & DTROW("OLDINITIALS") & "' AND ACC_YEARID = " & YearId, "", "")


                        'UPDATE IN RECEIPTMASTER 
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE RECEIPTMASTER_DESC SET RECEIPT_BILLINITIALS = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE RECEIPT_BILLINITIALS = '" & DTROW("OLDINITIALS") & "' AND RECEIPT_YEARID = " & YearId, "", "")
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE RECEIPTMASTER_GRIDDESC SET RECEIPT_PAYBILLINITIALS = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE RECEIPT_PAYBILLINITIALS = '" & DTROW("OLDINITIALS") & "' AND RECEIPT_YEARID = " & YearId, "", "")

                        NEWBILLNO += 1
                    Next

                    'REMOVE SPECIAL CHARACTER FROM INTIIALS
                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE PAYMENTMASTER SET PAYMENT_INITIALS = LEFT(PAYMENT_INITIALS, LEN(PAYMENT_INITIALS)-1) FROM PAYMENTMASTER INNER JOIN TEMPRENUMBERING ON NEWINITIALS = PAYMENT_INITIALS AND YEARID = PAYMENT_YEARID  WHERE PAYMENT_YEARID = " & YearId, "", "")
                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE PAYMENTMASTER_DESC SET PAYMENT_INITIALS = LEFT(PAYMENT_INITIALS, LEN(PAYMENT_INITIALS)-1) FROM PAYMENTMASTER_DESC INNER JOIN TEMPRENUMBERING ON NEWINITIALS = PAYMENT_INITIALS AND YEARID = PAYMENT_YEARID  WHERE PAYMENT_YEARID = " & YearId, "", "")
                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE PAYMENTMASTER_GRIDDESC SET PAYMENT_INITIALS = LEFT(PAYMENT_INITIALS, LEN(PAYMENT_INITIALS)-1) FROM PAYMENTMASTER_GRIDDESC INNER JOIN TEMPRENUMBERING ON NEWINITIALS = PAYMENT_INITIALS AND YEARID = PAYMENT_YEARID WHERE PAYMENT_YEARID = " & YearId, "", "")
                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE JOURNALMASTER SET JOURNAL_REFNO = LEFT(JOURNAL_REFNO, LEN(JOURNAL_REFNO)-1) FROM JOURNALMASTER INNER JOIN TEMPRENUMBERING ON NEWINITIALS = JOURNAL_REFNO AND YEARID = JOURNAL_YEARID WHERE JOURNAL_YEARID = " & YearId, "", "")
                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE ACCMASTER SET ACC_INITIALS = LEFT(ACC_INITIALS, LEN(ACC_INITIALS)-1) WHERE ACC_YEARID = " & YearId & " AND ACC_TYPE = 'PAYMENT' AND ACC_REGTYPE = '" & REGROW("REGABBR") & "'", "", "")
                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE RECEIPTMASTER_DESC SET RECEIPT_BILLINITIALS = LEFT(RECEIPT_BILLINITIALS, LEN(RECEIPT_BILLINITIALS)-1) FROM RECEIPTMASTER_DESC INNER JOIN TEMPRENUMBERING ON NEWINITIALS = RECEIPT_BILLINITIALS AND YEARID = RECEIPT_YEARID  WHERE RECEIPT_YEARID = " & YearId, "", "")
                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE RECEIPTMASTER_GRIDDESC SET RECEIPT_PAYBILLINITIALS = LEFT(RECEIPT_PAYBILLINITIALS, LEN(RECEIPT_PAYBILLINITIALS)-1) FROM RECEIPTMASTER_GRIDDESC INNER JOIN TEMPRENUMBERING ON NEWINITIALS = RECEIPT_PAYBILLINITIALS AND YEARID = RECEIPT_YEARID WHERE RECEIPT_YEARID = " & YearId, "", "")
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub RECEIPTRENUMBERING()
        Try
            'RENUMBER JOUNRAL VOUCHER FIRST
            Dim OBJCMN As New ClsCommon
            Dim DTREGISTER As DataTable = OBJCMN.search("REGISTER_ID AS REGID, REGISTER_NAME AS REGNAME, REGISTER_ABBR AS REGABBR, REGISTER_INITIALS AS REGINITIALS", "", " REGISTERMASTER ", " AND REGISTER_TYPE = 'RECEIPT' AND REGISTER_YEARID = " & YearId)
            If DTREGISTER.Rows.Count > 0 Then
                For Each REGROW As DataRow In DTREGISTER.Rows

                    'SEARCH ENTRY IN THIS REGISTER AND ADD IN TEMP TABLE
                    'FROM THIS TEMPTABLE WE WILL UPDATE THE ENTRIES
                    'WE WILL UPDATE THE ENTRYIES FROM THEIR OLDINITIALS, AND REPLACE WITH NEW INITIALS
                    'BUT NEW INITIALS WILL CONTAIN A SPECIAL CHARACTER SO THAT WE CAN DISTINGUISH BETWEEN OLD AND NEW INITIALS\
                    'ONCE ALL ENTRIES ARE UPDATED WE WILL REMOVE THAT SPECIAL CHARACTER
                    Dim DTENTRY As DataTable = OBJCMN.search("DISTINCT  RECEIPT_NO AS OLDNO, RECEIPT_registerid AS REGID, RECEIPT_DATE AS DATE, RECEIPT_initials AS OLDINITIALS, RECEIPT_yearid AS YEARID ", "", " RECEIPTMASTER ", " AND RECEIPT_registerid = " & REGROW("REGID") & " AND RECEIPT_YEARID = " & YearId & " ORDER BY RECEIPT_registerid, RECEIPT_date, RECEIPT_no")
                    Dim NEWBILLNO As Integer = 1
                    Dim TEMPDT As DataTable = OBJCMN.Execute_Any_String("DELETE FROM TEMPRENUMBERING WHERE YEARID = " & YearId, "", "")
                    For Each DTROW As DataRow In DTENTRY.Rows
                        TEMPDT = OBJCMN.Execute_Any_String("INSERT INTO TEMPRENUMBERING VALUES (" & DTROW("REGID") & ",'" & Format(Convert.ToDateTime(DTROW("DATE")).Date, "MM/dd/yyyy") & "'," & DTROW("YEARID") & "," & DTROW("OLDNO") & ",'" & DTROW("OLDINITIALS") & "'," & NEWBILLNO & ",'" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N')", "", "")


                        'UPDATE IN RECEIPT MASTER
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE RECEIPTMASTER SET RECEIPT_NO = " & NEWBILLNO & ", RECEIPT_INITIALS = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE RECEIPT_INITIALS = '" & DTROW("OLDINITIALS") & "' AND RECEIPT_YEARID = " & YearId, "", "")
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE RECEIPTMASTER_DESC SET RECEIPT_NO = " & NEWBILLNO & ", RECEIPT_INITIALS = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE RECEIPT_INITIALS = '" & DTROW("OLDINITIALS") & "' AND RECEIPT_YEARID = " & YearId, "", "")
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE RECEIPTMASTER_GRIDDESC SET RECEIPT_NO = " & NEWBILLNO & ", RECEIPT_INITIALS = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE RECEIPT_INITIALS = '" & DTROW("OLDINITIALS") & "' AND RECEIPT_YEARID = " & YearId, "", "")


                        'UPDATE IN JOURNALMASTER
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE JOURNALMASTER SET JOURNAL_REFNO = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE JOURNAL_REFNO = '" & DTROW("OLDINITIALS") & "' AND JOURNAL_YEARID = " & YearId, "", "")


                        'UPDATE IN ACCMASTER 
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE ACCMASTER SET ACC_BILLNO = " & NEWBILLNO & ",ACC_INITIALS = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE ACC_INITIALS = '" & DTROW("OLDINITIALS") & "' AND ACC_YEARID = " & YearId, "", "")


                        'UPDATE IN PAYMENTMASTER 
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE PAYMENTMASTER_DESC SET PAYMENT_BILLINITIALS = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE PAYMENT_BILLINITIALS = '" & DTROW("OLDINITIALS") & "' AND PAYMENT_YEARID = " & YearId, "", "")
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE PAYMENTMASTER_GRIDDESC SET PAYMENT_PAYBILLINITIALS = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE PAYMENT_PAYBILLINITIALS = '" & DTROW("OLDINITIALS") & "' AND PAYMENT_YEARID = " & YearId, "", "")

                        NEWBILLNO += 1
                    Next

                    'REMOVE SPECIAL CHARACTER FROM INTIIALS
                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE RECEIPTMASTER SET RECEIPT_INITIALS = LEFT(RECEIPT_INITIALS, LEN(RECEIPT_INITIALS)-1) FROM RECEIPTMASTER INNER JOIN TEMPRENUMBERING ON NEWINITIALS = RECEIPT_INITIALS AND YEARID = RECEIPT_YEARID  WHERE RECEIPT_YEARID = " & YearId, "", "")
                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE RECEIPTMASTER_DESC SET RECEIPT_INITIALS = LEFT(RECEIPT_INITIALS, LEN(RECEIPT_INITIALS)-1) FROM RECEIPTMASTER_DESC INNER JOIN TEMPRENUMBERING ON NEWINITIALS = RECEIPT_INITIALS AND YEARID = RECEIPT_YEARID  WHERE RECEIPT_YEARID = " & YearId, "", "")
                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE RECEIPTMASTER_GRIDDESC SET RECEIPT_INITIALS = LEFT(RECEIPT_INITIALS, LEN(RECEIPT_INITIALS)-1) FROM RECEIPTMASTER_GRIDDESC INNER JOIN TEMPRENUMBERING ON NEWINITIALS = RECEIPT_INITIALS AND YEARID = RECEIPT_YEARID WHERE RECEIPT_YEARID = " & YearId, "", "")
                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE JOURNALMASTER SET JOURNAL_REFNO = LEFT(JOURNAL_REFNO, LEN(JOURNAL_REFNO)-1) FROM JOURNALMASTER INNER JOIN TEMPRENUMBERING ON NEWINITIALS = JOURNAL_REFNO AND YEARID = JOURNAL_YEARID WHERE JOURNAL_YEARID = " & YearId, "", "")
                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE ACCMASTER SET ACC_INITIALS = LEFT(ACC_INITIALS, LEN(ACC_INITIALS)-1) WHERE ACC_YEARID = " & YearId & " AND ACC_TYPE = 'RECEIPT' AND ACC_REGTYPE = '" & REGROW("REGABBR") & "'", "", "")
                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE PAYMENTMASTER_DESC SET PAYMENT_BILLINITIALS = LEFT(PAYMENT_BILLINITIALS, LEN(PAYMENT_BILLINITIALS)-1) FROM PAYMENTMASTER_DESC INNER JOIN TEMPRENUMBERING ON NEWINITIALS = PAYMENT_BILLINITIALS AND YEARID = PAYMENT_YEARID  WHERE PAYMENT_YEARID = " & YearId, "", "")
                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE PAYMENTMASTER_GRIDDESC SET PAYMENT_PAYBILLINITIALS = LEFT(PAYMENT_PAYBILLINITIALS, LEN(PAYMENT_PAYBILLINITIALS)-1) FROM PAYMENTMASTER_GRIDDESC INNER JOIN TEMPRENUMBERING ON NEWINITIALS = PAYMENT_PAYBILLINITIALS AND YEARID = PAYMENT_YEARID WHERE PAYMENT_YEARID = " & YearId, "", "")
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERRENUMBERING()
        Try
            'RENUMBER TRANSFER ENTRIES 
            Dim OBJCMN As New ClsCommon
            Dim DTPURREGISTER As DataTable = OBJCMN.search("REGISTER_ID AS REGID, REGISTER_NAME AS REGNAME, REGISTER_ABBR AS REGABBR, REGISTER_INITIALS AS REGINITIALS", "", " REGISTERMASTER ", " AND REGISTER_NAME = 'TRANSFER PURCHASE REGISTER' AND REGISTER_YEARID = " & YearId)
            Dim REGPURROW As DataRow = DTPURREGISTER.Rows(0)

            Dim DTREGISTER As DataTable = OBJCMN.search("REGISTER_ID AS REGID, REGISTER_NAME AS REGNAME, REGISTER_ABBR AS REGABBR, REGISTER_INITIALS AS REGINITIALS", "", " REGISTERMASTER ", " AND REGISTER_NAME = 'TRANSFER SALE REGISTER' AND REGISTER_YEARID = " & YearId)
            If DTREGISTER.Rows.Count > 0 Then
                For Each REGROW As DataRow In DTREGISTER.Rows

                    'SEARCH ENTRY IN THIS REGISTER AND ADD IN TEMP TABLE
                    'FROM THIS TEMPTABLE WE WILL UPDATE THE ENTRIES
                    'WE WILL UPDATE THE ENTRYIES FROM THEIR OLDINITIALS, AND REPLACE WITH NEW INITIALS
                    'BUT NEW INITIALS WILL CONTAIN A SPECIAL CHARACTER SO THAT WE CAN DISTINGUISH BETWEEN OLD AND NEW INITIALS\
                    'ONCE ALL ENTRIES ARE UPDATED WE WILL REMOVE THAT SPECIAL CHARACTER
                    Dim DTENTRY As DataTable = OBJCMN.search("DISTINCT  BOOKING_NO AS OLDNO, BOOKING_SALEREGISTERID AS REGID, BOOKING_DATE AS DATE, BOOKING_SALEBILLINITIALS AS OLDINITIALS, BOOKING_yearid AS YEARID, BOOKING_PURBILLINITIALS AS OLDPURINITIALS  ", "", " HOTELBOOKINGMASTER ", " AND BOOKING_BOOKTYPE = 'TRANSFER' AND BOOKING_SALEREGISTERID = " & REGROW("REGID") & " AND BOOKING_YEARID = " & YearId & " ORDER BY BOOKING_SALEREGISTERID, BOOKING_date, BOOKING_NO")
                    Dim NEWBILLNO As Integer = 1
                    Dim TEMPDT As DataTable = OBJCMN.Execute_Any_String("DELETE FROM TEMPRENUMBERING WHERE YEARID = " & YearId, "", "")
                    For Each DTROW As DataRow In DTENTRY.Rows
                        TEMPDT = OBJCMN.Execute_Any_String("INSERT INTO TEMPRENUMBERING VALUES (" & DTROW("REGID") & ",'" & Format(Convert.ToDateTime(DTROW("DATE")).Date, "MM/dd/yyyy") & "'," & DTROW("YEARID") & "," & DTROW("OLDNO") & ",'" & DTROW("OLDINITIALS") & "'," & NEWBILLNO & ",'" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N')", "", "")

                        'UPDATE IN HOTELBOOKING MASTER
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE HOTELBOOKINGMASTER SET BOOKING_NO = " & NEWBILLNO & ", BOOKING_SALEBILLINITIALS = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N', BOOKING_PURBILLINITIALS = '" & REGPURROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE BOOKING_SALEBILLINITIALS = '" & DTROW("OLDINITIALS") & "' AND BOOKING_BOOKTYPE = 'TRANSFER' AND BOOKING_SALEREGISTERID = " & REGROW("REGID") & " AND BOOKING_YEARID = " & YearId, "", "")
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE HOTELBOOKINGMASTER_DESC SET BOOKING_NO = " & NEWBILLNO & " WHERE BOOKING_NO  = " & DTROW("OLDNO") & " AND BOOKING_SALEREGID = " & REGROW("REGID") & " AND BOOKING_YEARID = " & YearId, "", "")
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE HOTELBOOKINGMASTER_PURDESC SET BOOKING_NO = " & NEWBILLNO & " WHERE BOOKING_NO  = " & DTROW("OLDNO") & " AND BOOKING_PURREGID = " & REGPURROW("REGID") & " AND BOOKING_YEARID = " & YearId, "", "")
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE HOTELBOOKINGMASTER_UPLOAD SET BOOKING_NO = " & NEWBILLNO & " WHERE BOOKING_NO  = " & DTROW("OLDNO") & " AND BOOKING_SALEREGID = " & REGROW("REGID") & " AND BOOKING_YEARID = " & YearId, "", "")


                        'UPDATE IN JOURNALMASTER
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE JOURNALMASTER SET JOURNAL_REFNO = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE JOURNAL_REFNO = '" & DTROW("OLDINITIALS") & "' AND JOURNAL_YEARID = " & YearId, "", "")
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE JOURNALMASTER SET JOURNAL_REFNO = '" & REGPURROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE JOURNAL_REFNO = '" & DTROW("OLDPURINITIALS") & "' AND JOURNAL_YEARID = " & YearId, "", "")

                        'UPDATE IN ACCMASTER 
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE ACCMASTER SET ACC_BILLNO = " & NEWBILLNO & ",ACC_INITIALS = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE ACC_INITIALS = '" & DTROW("OLDINITIALS") & "' AND ACC_YEARID = " & YearId, "", "")
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE ACCMASTER SET ACC_BILLNO = " & NEWBILLNO & ",ACC_INITIALS = '" & REGPURROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE ACC_INITIALS = '" & DTROW("OLDPURINITIALS") & "' AND ACC_YEARID = " & YearId, "", "")


                        'UPDATE IN RECEIPTMASTER 
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE RECEIPTMASTER_DESC SET RECEIPT_BILLINITIALS = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE RECEIPT_BILLINITIALS = '" & DTROW("OLDINITIALS") & "' AND RECEIPT_YEARID = " & YearId, "", "")
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE RECEIPTMASTER_DESC SET RECEIPT_BILLINITIALS = '" & REGPURROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE RECEIPT_BILLINITIALS = '" & DTROW("OLDPURINITIALS") & "' AND RECEIPT_YEARID = " & YearId, "", "")
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE RECEIPTMASTER_GRIDDESC SET RECEIPT_PAYBILLINITIALS = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE RECEIPT_PAYBILLINITIALS = '" & DTROW("OLDINITIALS") & "' AND RECEIPT_YEARID = " & YearId, "", "")
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE RECEIPTMASTER_GRIDDESC SET RECEIPT_PAYBILLINITIALS = '" & REGPURROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE RECEIPT_PAYBILLINITIALS = '" & DTROW("OLDPURINITIALS") & "' AND RECEIPT_YEARID = " & YearId, "", "")


                        'UPDATE IN PAYMENTMASTER 
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE PAYMENTMASTER_DESC SET PAYMENT_BILLINITIALS = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE PAYMENT_BILLINITIALS = '" & DTROW("OLDINITIALS") & "' AND PAYMENT_YEARID = " & YearId, "", "")
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE PAYMENTMASTER_DESC SET PAYMENT_BILLINITIALS = '" & REGPURROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE PAYMENT_BILLINITIALS = '" & DTROW("OLDPURINITIALS") & "' AND PAYMENT_YEARID = " & YearId, "", "")
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE PAYMENTMASTER_GRIDDESC SET PAYMENT_PAYBILLINITIALS = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE PAYMENT_PAYBILLINITIALS = '" & DTROW("OLDINITIALS") & "' AND PAYMENT_YEARID = " & YearId, "", "")
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE PAYMENTMASTER_GRIDDESC SET PAYMENT_PAYBILLINITIALS = '" & REGPURROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE PAYMENT_PAYBILLINITIALS = '" & DTROW("OLDPURINITIALS") & "' AND PAYMENT_YEARID = " & YearId, "", "")


                        'UPDATE IN CREDITNOTEMASTER 
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE CREDITNOTEMASTER SET CN_BILLNO = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE CN_BILLNO = '" & DTROW("OLDINITIALS") & "' AND CN_YEARID = " & YearId, "", "")
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE CREDITNOTEMASTER SET CN_BILLNO = '" & REGPURROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE CN_BILLNO = '" & DTROW("OLDPURINITIALS") & "' AND CN_YEARID = " & YearId, "", "")

                        'UPDATE IN DEBITNOTEMASTER
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE DEBITNOTEMASTER SET DN_BILLNO = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE DN_BILLNO = '" & DTROW("OLDINITIALS") & "' AND DN_YEARID = " & YearId, "", "")
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE DEBITNOTEMASTER SET DN_BILLNO = '" & REGPURROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE DN_BILLNO = '" & DTROW("OLDPURINITIALS") & "' AND DN_YEARID = " & YearId, "", "")

                        NEWBILLNO += 1
                    Next

                    'REMOVE SPECIAL CHARACTER FROM INTIIALS
                    'FIRST REMOVE FROM CREDITNOTE AND DEBITNOTE THEN REMOVE FROM HOTELBOOKINGMASTER
                    'DONE BY GULKIT
                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE CREDITNOTEMASTER SET CN_BILLNO = LEFT(CN_BILLNO, LEN(CN_BILLNO)-1) FROM CREDITNOTEMASTER INNER JOIN HOTELBOOKINGMASTER ON CN_BILLNO = BOOKING_SALEBILLINITIALS AND CN_YEARID = BOOKING_YEARID WHERE CN_YEARID = " & YearId & " AND BOOKING_SALEREGISTERID = '" & REGROW("REGID") & "'", "", "")
                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE DEBITNOTEMASTER SET DN_BILLNO = LEFT(DN_BILLNO, LEN(DN_BILLNO)-1) FROM DEBITNOTEMASTER INNER JOIN HOTELBOOKINGMASTER ON DN_BILLNO = BOOKING_PURBILLINITIALS AND DN_YEARID = BOOKING_YEARID WHERE DN_YEARID = " & YearId & " AND BOOKING_PURCHASEREGISTERID = '" & REGPURROW("REGID") & "'", "", "")

                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE HOTELBOOKINGMASTER SET BOOKING_SALEBILLINITIALS = LEFT(BOOKING_SALEBILLINITIALS, LEN(BOOKING_SALEBILLINITIALS)-1), BOOKING_PURBILLINITIALS = LEFT(BOOKING_PURBILLINITIALS, LEN(BOOKING_PURBILLINITIALS)-1) FROM HOTELBOOKINGMASTER INNER JOIN TEMPRENUMBERING ON NEWINITIALS = BOOKING_SALEBILLINITIALS AND YEARID = BOOKING_YEARID  WHERE BOOKING_YEARID = " & YearId, "", "")

                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE ACCMASTER SET ACC_INITIALS = LEFT(ACC_INITIALS, LEN(ACC_INITIALS)-1) WHERE ACC_YEARID = " & YearId & " AND ACC_TYPE = 'TRANSFER PURCHASE' AND ACC_REGTYPE = '" & REGROW("REGABBR") & "'", "", "")
                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE ACCMASTER SET ACC_INITIALS = LEFT(ACC_INITIALS, LEN(ACC_INITIALS)-1) WHERE ACC_YEARID = " & YearId & " AND ACC_TYPE = 'TRANSFER SALE' AND ACC_REGTYPE = '" & REGPURROW("REGABBR") & "'", "", "")

                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

    Private Sub OutstandingFilterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OutstandingFilterToolStripMenuItem.Click
        Try
            Dim OBJOUT As New OutstandingFilter
            OBJOUT.MdiParent = Me
            OBJOUT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub VISAENQ_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VISAENQ_TOOL.Click
        Try
            Dim OBJVISA As New VisaEnquiry
            OBJVISA.MdiParent = Me
            OBJVISA.Show()
            OBJVISA.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub VISAENQDETAILS_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VISAENQDETAILS_TOOL.Click
        Try
            Dim OBJVISA As New VisaEnquiryDetails
            OBJVISA.MdiParent = Me
            OBJVISA.Show()
            OBJVISA.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub VISADETAILS_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VISADETAILS_TOOL.Click
        Try
            Dim OBJVISA As New VisaBookingDetails
            OBJVISA.MdiParent = Me
            OBJVISA.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EMAIL_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EMAIL_TOOL.Click
        Try
            Dim OBJEMAIL As New E_Mail
            OBJEMAIL.MdiParent = Me
            OBJEMAIL.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintInvoicesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintInvoicesToolStripMenuItem.Click
        Try
            Dim OBJPRINT As New PrintInvoices
            OBJPRINT.MdiParent = Me
            OBJPRINT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UPLOADToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UPLOADToolStripMenuItem.Click

    End Sub

    Private Sub MISCENQ_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MISCENQ_TOOL.Click
        Try
            Dim OBJMISCENQ As New MiscEnquiry
            OBJMISCENQ.MdiParent = Me
            OBJMISCENQ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CAR_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CAR_TOOL.Click
        Try
            Dim OBJCAR As New CarBooking
            OBJCAR.MdiParent = Me
            OBJCAR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HSNADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HSNADD.Click
        Try
            Dim OBJHSN As New HSNMaster
            OBJHSN.MdiParent = Me
            OBJHSN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingHSNToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HSNEDIT.Click
        Try
            Dim OBJHSN As New HSNDetails
            OBJHSN.MdiParent = Me
            OBJHSN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GSTTAXREGISTER_MENU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GSTTAXREGISTER_MENU.Click
        Try
            Dim OBJGST As New GSTTaxFilter
            OBJGST.MdiParent = Me
            OBJGST.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBANKDTLS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBBANKDTLS.Click
        Try
            Dim OBJBANKDTLS As New CmpBankDetails
            OBJBANKDTLS.MdiParent = Me
            OBJBANKDTLS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHECKINDAYS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHECKINDAYS.Click
        Try
            Dim OBJBANKDTLS As New ChangeCheckinDays
            OBJBANKDTLS.MdiParent = Me
            OBJBANKDTLS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AIRLINEQUOTE_ADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AIRLINEQUOTE_ADD.Click
        Try
            Dim OBJQUOT As New AirlineQuotation
            OBJQUOT.MdiParent = Me
            OBJQUOT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AIRLINEQUOTE_EDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AIRLINEQUOTE_EDIT.Click
        Try
            Dim OBJQUOT As New AirlineQuotationDetails
            OBJQUOT.MdiParent = Me
            OBJQUOT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub ADD_LEADTYPE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ADD_LEADTYPE.Click
        Try
            Dim OBJROOMTYPE As New RoomTypeMaster
            OBJROOMTYPE.MdiParent = Me
            OBJROOMTYPE.FRMSTRING = "LEADTYPE"
            OBJROOMTYPE.Show()
            OBJROOMTYPE.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EDIT_LEADTYPE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles EDIT_LEADTYPE.Click
        Try
            Dim OBJROOMTYPE As New RoomTypeDetails
            OBJROOMTYPE.MdiParent = Me
            OBJROOMTYPE.FRMSTRING = "LEADTYPE"
            OBJROOMTYPE.Show()
            OBJROOMTYPE.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub COMMINV_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COMMINV_TOOL.Click
        Try
            Dim OBJAIRLINE As New OtherSalePurchase
            OBJAIRLINE.MdiParent = Me
            ' OBJAIRLINE.FRMSTRING = "COMMISSION"
            OBJAIRLINE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LabelPrintingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LabelPrintingToolStripMenuItem.Click
        Try
            Dim OBJLABEL As New LabelPrinting
            OBJLABEL.MdiParent = Me
            OBJLABEL.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UPLOADACCOUNTMENU_Click(sender As Object, e As EventArgs) Handles UPLOADACCOUNTMENU.Click
        Try
            ''ONE TIME DATA UPLOAD FOR ARCH FROM EXCEL (SATNAM)
            'Try
            '    'upload the files data
            '    ''Reading from Excel Woorkbook
            '    Dim cPart As Microsoft.Office.Interop.Excel.Range
            '    Dim oExcel As Microsoft.Office.Interop.Excel.Application = CreateObject("Excel.Application")
            '            Dim oBook As Microsoft.Office.Interop.Excel.Workbook = oExcel.Workbooks.Open("D:\VSS\HOSPITALITY\Documentation\PRIYA\SUPPLIER", , False)
            '            Dim oSheet As New Microsoft.Office.Interop.Excel.Worksheet
            '            oSheet = oBook.Worksheets("Sheet1")

            '            'GRID
            '            Dim ADDITEM As Boolean = True
            '            Dim TEMPITEMNAME As String = ""

            '            Dim DTSAVE As New System.Data.DataTable
            '            DTSAVE.Columns.Add("CODE")
            '            DTSAVE.Columns.Add("COMPANYNAME")
            '            DTSAVE.Columns.Add("NAME")
            '            DTSAVE.Columns.Add("ADD1")
            '            DTSAVE.Columns.Add("ADD2")
            '            DTSAVE.Columns.Add("ADDRESS")
            '            DTSAVE.Columns.Add("AREA")
            '            DTSAVE.Columns.Add("CITYNAME")
            '            DTSAVE.Columns.Add("PINNO")
            '            DTSAVE.Columns.Add("STATE")
            '            DTSAVE.Columns.Add("COUNTRY")
            '            DTSAVE.Columns.Add("PHONENO")
            '            DTSAVE.Columns.Add("MOBILENO")
            '            DTSAVE.Columns.Add("ALTNO")
            '            DTSAVE.Columns.Add("FAXNO")
            '            DTSAVE.Columns.Add("EMAIL")

            '            Dim ARR As New ArrayList
            '            Dim COLIND As Integer = 0
            '            Dim DTROWSAVE As System.Data.DataRow = DTSAVE.NewRow()
            '            For I As Integer = 2 To 212

            '                If IsDBNull(oSheet.Range("A" & I.ToString).Text) = False Then
            '                    DTROWSAVE("CODE") = oSheet.Range("A" & I.ToString).Text
            '                Else
            '                    DTROWSAVE("CODE") = ""
            '                End If

            '                If IsDBNull(oSheet.Range("B" & I.ToString).Text) = False Then
            '                    DTROWSAVE("COMPANYNAME") = oSheet.Range("B" & I.ToString).Text
            '                Else
            '                    DTROWSAVE("COMPANYNAME") = ""
            '                End If

            '                If IsDBNull(oSheet.Range("C" & I.ToString).Text) = False Then
            '                    DTROWSAVE("NAME") = oSheet.Range("C" & I.ToString).Text
            '                Else
            '                    DTROWSAVE("NAME") = ""
            '                End If

            '                If IsDBNull(oSheet.Range("D" & I.ToString).Text) = False Then
            '                    DTROWSAVE("ADD1") = oSheet.Range("D" & I.ToString).Text
            '                Else
            '                    DTROWSAVE("ADD1") = ""
            '                End If

            '                If IsDBNull(oSheet.Range("E" & I.ToString).Text) = False Then
            '                    DTROWSAVE("ADD2") = oSheet.Range("E" & I.ToString).Text
            '                Else
            '                    DTROWSAVE("ADD2") = ""
            '                End If

            '                If IsDBNull(oSheet.Range("F" & I.ToString).Text) = False Then
            '                    DTROWSAVE("ADDRESS") = oSheet.Range("F" & I.ToString).Text
            '                Else
            '                    DTROWSAVE("ADDRESS") = ""
            '                End If

            '                If IsDBNull(oSheet.Range("G" & I.ToString).Text) = False Then
            '                    DTROWSAVE("AREA") = oSheet.Range("G" & I.ToString).Text
            '                Else
            '                    DTROWSAVE("AREA") = ""
            '                End If

            '                If IsDBNull(oSheet.Range("H" & I.ToString).Text) = False Then
            '                    DTROWSAVE("CITYNAME") = oSheet.Range("H" & I.ToString).Text
            '                Else
            '                    DTROWSAVE("CITYNAME") = ""
            '                End If

            '                If IsDBNull(oSheet.Range("I" & I.ToString).Text) = False Then
            '                    DTROWSAVE("PINNO") = Val(oSheet.Range("I" & I.ToString).Text)
            '                Else
            '                    DTROWSAVE("PINNO") = 0
            '                End If

            '                If IsDBNull(oSheet.Range("J" & I.ToString).Text) = False Then
            '                    DTROWSAVE("STATE") = Val(oSheet.Range("J" & I.ToString).Text)
            '                Else
            '                    DTROWSAVE("STATE") = 0
            '                End If

            '                If IsDBNull(oSheet.Range("K" & I.ToString).Text) = False Then
            '                    DTROWSAVE("COUNTRY") = Val(oSheet.Range("K" & I.ToString).Text)
            '                Else
            '                    DTROWSAVE("COUNTRY") = 0
            '                End If

            '                If IsDBNull(oSheet.Range("L" & I.ToString).Text) = False Then
            '                    DTROWSAVE("PHONENO") = oSheet.Range("L" & I.ToString).Text
            '                Else
            '                    DTROWSAVE("PHONENO") = ""
            '                End If

            '                If IsDBNull(oSheet.Range("M" & I.ToString).Text) = False Then
            '                    DTROWSAVE("MOBILENO") = Val(oSheet.Range("M" & I.ToString).Text)
            '                Else
            '                    DTROWSAVE("MOBILENO") = 0
            '                End If


            '                If IsDBNull(oSheet.Range("N" & I.ToString).Text) = False Then
            '                    DTROWSAVE("ALTNO") = Val(oSheet.Range("N" & I.ToString).Text)
            '                Else
            '                    DTROWSAVE("ALTNO") = 0
            '                End If



            '                If IsDBNull(oSheet.Range("O" & I.ToString).Text) = False Then
            '                    DTROWSAVE("FAXNO") = Val(oSheet.Range("O" & I.ToString).Text)
            '                Else
            '                    DTROWSAVE("FAXNO") = 0
            '                End If



            '                If IsDBNull(oSheet.Range("P" & I.ToString).Text) = False Then
            '                    DTROWSAVE("EMAIL") = Val(oSheet.Range("P" & I.ToString).Text)
            '                Else
            '                    DTROWSAVE("EMAIL") = 0
            '                End If




            '                Dim ALPARAVAL As New ArrayList
            '                'CHECK WHETHER AREA IS PRESENT OR NOT IF NOT PRESENT THEN ADD NEW
            '                Dim OBJCMN As New ClsCommon
            '                Dim DTTABLE As DataTable = OBJCMN.search("AREA_ID AS AREAID", "", "AREAMASTER ", "AND AREA_NAME = '" & DTROWSAVE("AREA") & "' AND AREA_YEARID = " & YearId)
            '                If DTTABLE.Rows.Count = 0 Then
            '                    'ADD NEW AREA
            '                    Dim objyearmaster As New ClsYearMaster
            '                    objyearmaster.savearea(DTROWSAVE("AREA"), CmpId, Locationid, Userid, YearId, " and AREA_name = '" & DTROWSAVE("AREA") & "' AND AREA_YEARID = " & YearId)
            '                End If


            '                DTTABLE = OBJCMN.search("CITY_ID AS CITYID", "", "CITYMASTER ", "AND CITY_NAME = '" & DTROWSAVE("CITYNAME") & "' AND CITY_YEARID = " & YearId)
            '                If DTTABLE.Rows.Count = 0 Then
            '                    'ADD NEW CITYNAME
            '                    Dim objyearmaster As New ClsYearMaster
            '                    objyearmaster.savecity(DTROWSAVE("CITYNAME"), CmpId, Locationid, Userid, YearId, " and city_name = '" & DTROWSAVE("CITYNAME") & "' AND CITY_CMPID = " & CmpId & " AND CITY_LOCATIONID = " & Locationid & " AND CITY_YEARID = " & YearId)
            '                End If


            '                DTTABLE = OBJCMN.search("STATE_ID AS STATEID", "", "STATEMASTER ", "AND STATE_NAME = '" & DTROWSAVE("STATE") & "' AND STATE_YEARID = " & YearId)
            '                If DTTABLE.Rows.Count = 0 Then
            '                    'ADD NEW STATE
            '                    Dim objyearmaster As New ClsYearMaster
            '                    objyearmaster.savestate(DTROWSAVE("STATE"), CmpId, Locationid, Userid, YearId, " and STATE_name = '" & DTROWSAVE("STATE") & "' AND STATE_YEARID = " & YearId)
            '                End If


            '                DTTABLE = OBJCMN.search("COUNTRY_ID AS COUNTRYID", "", "COUNTRYMASTER ", "AND COUNTRY_NAME = '" & DTROWSAVE("COUNTRY") & "' AND COUNTRY_YEARID = " & YearId)
            '                If DTTABLE.Rows.Count = 0 Then
            '                    'ADD NEW COUNTRY
            '                    Dim objyearmaster As New ClsYearMaster
            '                    objyearmaster.savecountry(DTROWSAVE("COUNTRY"), CmpId, Locationid, Userid, YearId, " and COUNTRY_name = '" & DTROWSAVE("COUNTRY") & "' AND COUNTRY_YEARID = " & YearId)
            '                End If




            '                'ADD IN ACCOUNTSMASTER
            '                ALPARAVAL.Clear()
            '                Dim OBJSM As New ClsAccountsMaster

            '                ALPARAVAL.Add(DTROWSAVE("COMPANYNAME"))
            '                ALPARAVAL.Add(DTROWSAVE("NAME"))
            '                ALPARAVAL.Add("Sundry Creditors")
            '                ALPARAVAL.Add(0)
            '                ALPARAVAL.Add("Cr.")
            '                ALPARAVAL.Add(DTROWSAVE("ADD1"))
            '                ALPARAVAL.Add(DTROWSAVE("ADD2"))
            '                ALPARAVAL.Add(DTROWSAVE("AREA"))
            '                ALPARAVAL.Add("")
            '                ALPARAVAL.Add(DTROWSAVE("CITYNAME"))
            '                ALPARAVAL.Add(DTROWSAVE("PINNO"))
            '                ALPARAVAL.Add(DTROWSAVE("STATE"))
            '                ALPARAVAL.Add(DTROWSAVE("COUNTRY"))
            '                ALPARAVAL.Add(0)
            '                ALPARAVAL.Add(0)
            '                ALPARAVAL.Add("")
            '                ALPARAVAL.Add(DTROWSAVE("ALTNO"))
            '                ALPARAVAL.Add(DTROWSAVE("PHONENO"))
            '                ALPARAVAL.Add(DTROWSAVE("MOBILENO"))
            '                ALPARAVAL.Add(DTROWSAVE("FAXNO"))
            '                ALPARAVAL.Add("")
            '                ALPARAVAL.Add(DTROWSAVE("EMAIL"))
            '                ALPARAVAL.Add("")
            '                ALPARAVAL.Add("")
            '                ALPARAVAL.Add("")
            '                ALPARAVAL.Add("")
            '                ALPARAVAL.Add("")
            '                ALPARAVAL.Add("")
            '                ALPARAVAL.Add("")
            '                ALPARAVAL.Add("")
            '                ALPARAVAL.Add("")
            '                ALPARAVAL.Add(DTROWSAVE("ADDRESS"))
            '                ALPARAVAL.Add("")
            '                ALPARAVAL.Add("")
            '                ALPARAVAL.Add(CmpId)
            '                ALPARAVAL.Add(Locationid)
            '                ALPARAVAL.Add(Userid)
            '                ALPARAVAL.Add(YearId)
            '                ALPARAVAL.Add(0)
            '                ALPARAVAL.Add(DTROWSAVE("CODE"))


            '                'TDS
            '                '*******************************
            '                ALPARAVAL.Add(0)
            '                ALPARAVAL.Add("")
            '                ALPARAVAL.Add(0)

            '                ALPARAVAL.Add("")
            '                ALPARAVAL.Add(Val(0))
            '                ALPARAVAL.Add(0)
            '                ALPARAVAL.Add(Val(0))
            '                '*******************************

            '                ALPARAVAL.Add(0)
            '                ALPARAVAL.Add("")


            '                ''NEWLY ADDED FIELDS*******************(AS PER CLASSIC REQUIREMENTS)
            '                ALPARAVAL.Add("Walk In")
            '                ALPARAVAL.Add("")
            '                ALPARAVAL.Add("")
            '                ALPARAVAL.Add("")
            '                ALPARAVAL.Add(Now.Date)
            '                ALPARAVAL.Add("")

            '                'CONTACT DETAILS
            '                '********************************
            '                Dim CNAME As String = ""
            '                Dim CDOB As String = ""
            '                Dim DESIGNATION As String = ""
            '                Dim CMOB As String = ""
            '                Dim CEMAIL As String = ""

            '                ALPARAVAL.Add(CNAME)
            '                ALPARAVAL.Add(CDOB)
            '                ALPARAVAL.Add(DESIGNATION)
            '                ALPARAVAL.Add(CMOB)
            '                ALPARAVAL.Add(CEMAIL)
            '                '********************************


            '                'BANK DETAILS
            '                '********************************
            '                Dim ACNAME As String = ""
            '                Dim ACNO As String = ""
            '                Dim ACTYPE As String = ""
            '                Dim BANKNAME As String = ""
            '                Dim BRANCH As String = ""
            '                Dim IFSC As String = ""
            '                Dim SWIFT As String = ""
            '                Dim CITY As String = ""
            '                Dim PINCODE As String = ""
            '                Dim COUNTRY As String = ""
            '                ALPARAVAL.Add(ACNAME)
            '                ALPARAVAL.Add(ACNO)
            '                ALPARAVAL.Add(ACTYPE)
            '                ALPARAVAL.Add(BANKNAME)
            '                ALPARAVAL.Add(BRANCH)
            '                ALPARAVAL.Add(IFSC)
            '                ALPARAVAL.Add(SWIFT)
            '                ALPARAVAL.Add(CITY)
            '                ALPARAVAL.Add(PINCODE)
            '                ALPARAVAL.Add(COUNTRY)
            '                '********************************


            '                'FAMILY DETAILS
            '                '********************************
            '                Dim FNAME As String = ""
            '                Dim FDOB As String = ""
            '                Dim FAGE As String = ""
            '                Dim FRELATION As String = ""
            '                Dim FMOBILE As String = ""
            '                Dim FEMAIL As String = ""
            '                Dim FSEX As String = ""


            '                ALPARAVAL.Add(FNAME)
            '                ALPARAVAL.Add(FDOB)
            '                ALPARAVAL.Add(FAGE)
            '                ALPARAVAL.Add(FRELATION)
            '                ALPARAVAL.Add(FMOBILE)
            '                ALPARAVAL.Add(FEMAIL)
            '                ALPARAVAL.Add(FSEX)

            '                '********************************
            '                ALPARAVAL.Add("")

            '                OBJSM.alParaval = ALPARAVAL
            '                Dim INTRES As Integer = OBJSM.save()

            '                DTROWSAVE = DTSAVE.NewRow()

            'SKIPLINE:
            '            Next

            '            oBook.Close()

            '            Exit Sub
            '        Catch ex As Exception
            '            Throw ex
            '        End Try



            If InputBox("Enter Master Password") <> "Infosys@123" Then Exit Sub

            '************************************ LEDGER UPLOAD ****************************
            'upload the files data
            ''Reading from Excel Woorkbook
            Dim cPart As Microsoft.Office.Interop.Excel.Range
            Dim oExcel As Microsoft.Office.Interop.Excel.Application = CreateObject("Excel.Application")
            Dim oBook As Microsoft.Office.Interop.Excel.Workbook = oExcel.Workbooks.Open("D:\" & InputBox("Enter File Name").ToString.Trim, , False)
            Dim oSheet As New Microsoft.Office.Interop.Excel.Worksheet
            oSheet = oBook.Worksheets("Sheet1")

            'GRID
            Dim ADDITEM As Boolean = True
            Dim TEMPITEMNAME As String = ""

            Dim DTSAVE As New System.Data.DataTable
            DTSAVE.Columns.Add("PERSONNAME")
            DTSAVE.Columns.Add("COMPANYNAME")
            DTSAVE.Columns.Add("ADD1")
            DTSAVE.Columns.Add("ADD2")
            DTSAVE.Columns.Add("ADDRESS")
            DTSAVE.Columns.Add("CITYNAME")
            DTSAVE.Columns.Add("PINNO")
            DTSAVE.Columns.Add("STATE")
            DTSAVE.Columns.Add("COUNTRY")
            DTSAVE.Columns.Add("PHONENO")
            DTSAVE.Columns.Add("MOBILENO")
            DTSAVE.Columns.Add("GSTIN")
            DTSAVE.Columns.Add("GROUPNAME")
            DTSAVE.Columns.Add("PANNO")
            DTSAVE.Columns.Add("EMAIL")

            Dim ARR As New ArrayList
            Dim COLIND As Integer = 0
            Dim DTROWSAVE As System.Data.DataRow = DTSAVE.NewRow()

            Dim FROMROWNO As Integer = Val(InputBox("Enter Start Row No"))
            Dim TOROWNO As Integer = Val(InputBox("Enter End Row No"))

            For I As Integer = FROMROWNO To TOROWNO

                If IsDBNull(oSheet.Range("A" & I.ToString).Text) = False Then
                    DTROWSAVE("PERSONNAME") = oSheet.Range("A" & I.ToString).Text
                Else
                    DTROWSAVE("PERSONNAME") = ""
                End If

                If IsDBNull(oSheet.Range("B" & I.ToString).Text) = False Then
                    DTROWSAVE("COMPANYNAME") = oSheet.Range("B" & I.ToString).Text
                Else
                    DTROWSAVE("COMPANYNAME") = ""
                End If

                If IsDBNull(oSheet.Range("C" & I.ToString).Text) = False Then
                    DTROWSAVE("ADD1") = oSheet.Range("C" & I.ToString).Text
                Else
                    DTROWSAVE("ADD1") = ""
                End If

                If IsDBNull(oSheet.Range("D" & I.ToString).Text) = False Then
                    DTROWSAVE("ADD2") = oSheet.Range("D" & I.ToString).Text
                Else
                    DTROWSAVE("ADD2") = ""
                End If

                If IsDBNull(oSheet.Range("E" & I.ToString).Text) = False Then
                    DTROWSAVE("ADDRESS") = oSheet.Range("E" & I.ToString).Text
                Else
                    DTROWSAVE("ADDRESS") = ""
                End If

                If IsDBNull(oSheet.Range("F" & I.ToString).Text) = False Then
                    DTROWSAVE("CITYNAME") = oSheet.Range("F" & I.ToString).Text
                Else
                    DTROWSAVE("CITYNAME") = ""
                End If

                If IsDBNull(oSheet.Range("G" & I.ToString).Text) = False Then
                    DTROWSAVE("PINNO") = oSheet.Range("G" & I.ToString).Text
                Else
                    DTROWSAVE("PINNO") = 0
                End If

                If IsDBNull(oSheet.Range("H" & I.ToString).Text) = False Then
                    DTROWSAVE("STATE") = oSheet.Range("H" & I.ToString).Text
                Else
                    DTROWSAVE("STATE") = ""
                End If

                If IsDBNull(oSheet.Range("I" & I.ToString).Text) = False Then
                    DTROWSAVE("COUNTRY") = oSheet.Range("I" & I.ToString).Text
                Else
                    DTROWSAVE("COUNTRY") = ""
                End If

                If IsDBNull(oSheet.Range("J" & I.ToString).Text) = False Then
                    DTROWSAVE("PHONENO") = oSheet.Range("J" & I.ToString).Text
                Else
                    DTROWSAVE("PHONENO") = ""
                End If

                If IsDBNull(oSheet.Range("K" & I.ToString).Text) = False Then
                    DTROWSAVE("MOBILENO") = oSheet.Range("K" & I.ToString).Text
                Else
                    DTROWSAVE("MOBILENO") = 0
                End If


                If IsDBNull(oSheet.Range("L" & I.ToString).Text) = False Then
                    DTROWSAVE("GSTIN") = oSheet.Range("L" & I.ToString).Text
                Else
                    DTROWSAVE("GSTIN") = ""
                End If

                If IsDBNull(oSheet.Range("M" & I.ToString).Text) = False Then
                    DTROWSAVE("GROUPNAME") = oSheet.Range("M" & I.ToString).Text
                Else
                    DTROWSAVE("GROUPNAME") = ""
                End If

                If IsDBNull(oSheet.Range("N" & I.ToString).Text) = False Then
                    DTROWSAVE("PANNO") = oSheet.Range("N" & I.ToString).Text
                Else
                    DTROWSAVE("PANNO") = ""
                End If

                If IsDBNull(oSheet.Range("O" & I.ToString).Text) = False Then
                    DTROWSAVE("EMAIL") = oSheet.Range("O" & I.ToString).Text
                Else
                    DTROWSAVE("EMAIL") = ""
                End If




                Dim ALPARAVAL As New ArrayList
                Dim OBJCMN As New ClsCommon
                Dim DTTABLE As DataTable = OBJCMN.search("CITY_ID AS CITYID", "", "CITYMASTER ", "AND CITY_NAME = '" & DTROWSAVE("CITYNAME") & "' AND CITY_YEARID = " & YearId)
                If DTTABLE.Rows.Count = 0 Then
                    'ADD NEW CITYNAME
                    Dim objyearmaster As New ClsYearMaster
                    objyearmaster.savecity(DTROWSAVE("CITYNAME"), CmpId, Locationid, Userid, YearId, " and city_name = '" & DTROWSAVE("CITYNAME") & "' AND CITY_CMPID = " & CmpId & " AND CITY_LOCATIONID = " & Locationid & " AND CITY_YEARID = " & YearId)
                End If


                DTTABLE = OBJCMN.search("STATE_ID AS STATEID", "", "STATEMASTER ", "AND STATE_NAME = '" & DTROWSAVE("STATE") & "' AND STATE_YEARID = " & YearId)
                If DTTABLE.Rows.Count = 0 Then
                    'ADD NEW STATE
                    Dim objyearmaster As New ClsYearMaster
                    objyearmaster.savestate(DTROWSAVE("STATE"), CmpId, Locationid, Userid, YearId, " and STATE_name = '" & DTROWSAVE("STATE") & "' AND STATE_YEARID = " & YearId)
                End If


                DTTABLE = OBJCMN.search("COUNTRY_ID AS COUNTRYID", "", "COUNTRYMASTER ", "AND COUNTRY_NAME = '" & DTROWSAVE("COUNTRY") & "' AND COUNTRY_YEARID = " & YearId)
                If DTTABLE.Rows.Count = 0 Then
                    'ADD NEW COUNTRY
                    Dim objyearmaster As New ClsYearMaster
                    objyearmaster.savecountry(DTROWSAVE("COUNTRY"), CmpId, Locationid, Userid, YearId, " and COUNTRY_name = '" & DTROWSAVE("COUNTRY") & "' AND COUNTRY_YEARID = " & YearId)
                End If


                'check whether PARTYNAME is already present or not
                DTTABLE = OBJCMN.search("ACC_CMPNAME AS COMPANYNAME", "", "LEDGERS ", " AND ACC_CMPNAME = '" & DTROWSAVE("COMPANYNAME") & "' AND ACC_YEARID = " & YearId)
                If DTTABLE.Rows.Count > 0 Then GoTo SKIPLINE



                'ADD IN ACCOUNTSMASTER
                ALPARAVAL.Clear()
                Dim OBJSM As New ClsAccountsMaster

                ALPARAVAL.Add(DTROWSAVE("COMPANYNAME"))
                ALPARAVAL.Add(DTROWSAVE("PERSONNAME"))   'NAME
                ALPARAVAL.Add(DTROWSAVE("GROUPNAME"))
                ALPARAVAL.Add(0)    'OPBAL
                ALPARAVAL.Add("Cr.") 'DRCR
                ALPARAVAL.Add(DTROWSAVE("ADD1"))
                ALPARAVAL.Add(DTROWSAVE("ADD2"))
                ALPARAVAL.Add("")     'AREA
                ALPARAVAL.Add("")   'STDCODE
                ALPARAVAL.Add(DTROWSAVE("CITYNAME"))
                ALPARAVAL.Add(DTROWSAVE("PINNO"))
                ALPARAVAL.Add(DTROWSAVE("STATE"))
                ALPARAVAL.Add(DTROWSAVE("COUNTRY"))
                ALPARAVAL.Add(0)    'CRDAYS
                ALPARAVAL.Add(0)    'CRLIMIT
                ALPARAVAL.Add("")   'RESINO
                ALPARAVAL.Add("")   'ALTNO
                ALPARAVAL.Add(DTROWSAVE("PHONENO"))
                ALPARAVAL.Add(DTROWSAVE("MOBILENO"))
                ALPARAVAL.Add("")   'FAXNO
                ALPARAVAL.Add("")   'WEBDITE
                ALPARAVAL.Add(DTROWSAVE("EMAIL"))
                ALPARAVAL.Add(DTROWSAVE("PANNO"))
                ALPARAVAL.Add("")   'EXCISENO
                ALPARAVAL.Add("")   'RANGE
                ALPARAVAL.Add("")   'DIVISION
                ALPARAVAL.Add("")   'CGSTNO
                ALPARAVAL.Add("")   'TINNO
                ALPARAVAL.Add("")   'STNO
                ALPARAVAL.Add("")   'VATNO
                ALPARAVAL.Add(DTROWSAVE("GSTIN"))
                ALPARAVAL.Add(DTROWSAVE("ADDRESS"))
                ALPARAVAL.Add("")   'SHIPADD
                ALPARAVAL.Add("")   'REMARKS
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(Userid)
                ALPARAVAL.Add(YearId)
                ALPARAVAL.Add(0)
                ALPARAVAL.Add(DTROWSAVE("COMPANYNAME"))


                'TDS
                '*******************************
                ALPARAVAL.Add(0)
                ALPARAVAL.Add("")
                ALPARAVAL.Add(0)

                ALPARAVAL.Add("")
                ALPARAVAL.Add(Val(0))
                ALPARAVAL.Add(0)
                ALPARAVAL.Add(Val(0))
                '*******************************

                ALPARAVAL.Add(0)
                ALPARAVAL.Add("")


                ''NEWLY ADDED FIELDS*******************(AS PER CLASSIC REQUIREMENTS)
                ALPARAVAL.Add("Walk In")
                ALPARAVAL.Add("")   'REFFERED
                ALPARAVAL.Add("")   'MEMBERID
                ALPARAVAL.Add("")   'CATEGORY                
                ALPARAVAL.Add(Now.Date) 'EXPDATE
                ALPARAVAL.Add("")   'OPPOINTS
                ALPARAVAL.Add(0)    'BLOCKED

                'CONTACT DETAILS
                '********************************
                Dim CNAME As String = ""
                Dim CDOB As String = ""
                Dim DESIGNATION As String = ""
                Dim CMOB As String = ""
                Dim CEMAIL As String = ""

                ALPARAVAL.Add(CNAME)
                ALPARAVAL.Add(CDOB)
                ALPARAVAL.Add(DESIGNATION)
                ALPARAVAL.Add(CMOB)
                ALPARAVAL.Add(CEMAIL)
                '********************************


                'BANK DETAILS
                '********************************
                Dim ACNAME As String = ""
                Dim ACNO As String = ""
                Dim ACTYPE As String = ""
                Dim BANKNAME As String = ""
                Dim BRANCH As String = ""
                Dim IFSC As String = ""
                Dim SWIFT As String = ""
                Dim CITY As String = ""
                Dim PINCODE As String = ""
                Dim COUNTRY As String = ""
                ALPARAVAL.Add(ACNAME)
                ALPARAVAL.Add(ACNO)
                ALPARAVAL.Add(ACTYPE)
                ALPARAVAL.Add(BANKNAME)
                ALPARAVAL.Add(BRANCH)
                ALPARAVAL.Add(IFSC)
                ALPARAVAL.Add(SWIFT)
                ALPARAVAL.Add(CITY)
                ALPARAVAL.Add(PINCODE)
                ALPARAVAL.Add(COUNTRY)
                '********************************


                'FAMILY DETAILS
                '********************************
                Dim FNAME As String = ""
                Dim FDOB As String = ""
                Dim FAGE As String = ""
                Dim FRELATION As String = ""
                Dim FMOBILE As String = ""
                Dim FEMAIL As String = ""
                Dim FSEX As String = ""


                ALPARAVAL.Add(FNAME)
                ALPARAVAL.Add(FDOB)
                ALPARAVAL.Add(FAGE)
                ALPARAVAL.Add(FRELATION)
                ALPARAVAL.Add(FMOBILE)
                ALPARAVAL.Add(FEMAIL)
                ALPARAVAL.Add(FSEX)

                '********************************
                ALPARAVAL.Add("")

                ALPARAVAL.Add("")   'TDSDEDUCTEDAC
                ALPARAVAL.Add("")   'TDSFORM
                ALPARAVAL.Add(0)    'TDSPER
                ALPARAVAL.Add("")   'TDSCOMPANY


                OBJSM.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBJSM.save()

                DTROWSAVE = DTSAVE.NewRow()

SKIPLINE:
            Next

            oBook.Close()

            Exit Sub

            '************************************ END OF CODE FOR LEDGER UPLOAD ****************************



        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UPLOADOPENINGBILL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UPLOADOPENINGBILLMENU.Click

        'ONE TIME DATA UPLOAD FOR OPENINGBILL
        Try
            If InputBox("Enter Master Password") <> "Infosys@123" Then Exit Sub
            'upload the files data
            ''Reading from Excel Woorkbook
            Dim cPart As Microsoft.Office.Interop.Excel.Range
            Dim oExcel As Microsoft.Office.Interop.Excel.Application = CreateObject("Excel.Application")
            Dim oBook As Microsoft.Office.Interop.Excel.Workbook = oExcel.Workbooks.Open("D:\" & InputBox("Enter File Name").ToString.Trim, , False)
            Dim oSheet As New Microsoft.Office.Interop.Excel.Worksheet
            oSheet = oBook.Worksheets("Sheet1")

            Dim DTSAVE As New System.Data.DataTable
            DTSAVE.Columns.Add("NAME")
            DTSAVE.Columns.Add("TYPE")
            DTSAVE.Columns.Add("REGISTER")
            DTSAVE.Columns.Add("BILLNO")
            DTSAVE.Columns.Add("YEAR")
            DTSAVE.Columns.Add("DATE")
            DTSAVE.Columns.Add("BALANCE")
            DTSAVE.Columns.Add("BILLINITIALS")

            Dim ARR As New ArrayList
            Dim COLIND As Integer = 0
            Dim DTROWSAVE As System.Data.DataRow = DTSAVE.NewRow()


            Dim FROMROWNO As Integer = Val(InputBox("Enter Start Row No"))
            Dim TOROWNO As Integer = Val(InputBox("Enter End Row No"))

            For I As Integer = FROMROWNO To TOROWNO

                If IsDBNull(oSheet.Range("A" & I.ToString).Text) = False Then
                    DTROWSAVE("NAME") = oSheet.Range("A" & I.ToString).Text
                Else
                    DTROWSAVE("NAME") = ""
                End If

                If IsDBNull(oSheet.Range("B" & I.ToString).Text) = False Then
                    DTROWSAVE("TYPE") = oSheet.Range("B" & I.ToString).Text
                Else
                    DTROWSAVE("TYPE") = ""
                End If


                If IsDBNull(oSheet.Range("C" & I.ToString).Text) = False Then
                    DTROWSAVE("REGISTER") = oSheet.Range("C" & I.ToString).Text
                Else
                    DTROWSAVE("REGISTER") = ""
                End If


                If IsDBNull(oSheet.Range("D" & I.ToString).Text) = False Then
                    DTROWSAVE("BILLNO") = Val(oSheet.Range("D" & I.ToString).Text)
                Else
                    DTROWSAVE("BILLNO") = ""
                End If

                If IsDBNull(oSheet.Range("E" & I.ToString).Text) = False Then
                    DTROWSAVE("YEAR") = oSheet.Range("E" & I.ToString).Text
                Else
                    DTROWSAVE("YEAR") = ""
                End If

                If IsDBNull(oSheet.Range("F" & I.ToString).Text) = False Then
                    DTROWSAVE("DATE") = Format(Convert.ToDateTime(oSheet.Range("F" & I.ToString).Text).Date, "MM/dd/yyyy")
                Else
                    DTROWSAVE("DATE") = 0
                End If

                If IsDBNull(oSheet.Range("G" & I.ToString).Text) = False Then
                    DTROWSAVE("BALANCE") = Val(oSheet.Range("G" & I.ToString).Text)
                Else
                    DTROWSAVE("BALANCE") = 0
                End If

                If IsDBNull(oSheet.Range("H" & I.ToString).Text) = False Then
                    DTROWSAVE("BILLINITIALS") = oSheet.Range("H" & I.ToString).Text
                Else
                    DTROWSAVE("BILLINITIALS") = 0
                End If



                Dim ALPARAVAL As New ArrayList
                Dim DTTABLE As New DataTable
                Dim OBJCMN As New ClsCommon
                'check whether BILLNO is already present or not
                DTTABLE = OBJCMN.search("BILL_INITIALS AS BILLINITIALS", "", "OPENINGBILL", " AND BILL_INITIALS = '" & DTROWSAVE("BILLINITIALS") & "' AND BILL_YEARID = " & YearId)
                If DTTABLE.Rows.Count > 0 Then GoTo SKIPLINE



                'ADD IN OPEINGBILL
                ALPARAVAL.Clear()
                Dim OBJSM As New ClsOpening

                ALPARAVAL.Add(DTROWSAVE("NAME"))
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(Userid)
                ALPARAVAL.Add(YearId)
                ALPARAVAL.Add(0)

                ALPARAVAL.Add(I)
                ALPARAVAL.Add(DTROWSAVE("TYPE"))
                ALPARAVAL.Add(DTROWSAVE("BILLNO"))
                ALPARAVAL.Add("Admin")  'BOOKEDBY
                ALPARAVAL.Add(DTROWSAVE("YEAR"))
                ALPARAVAL.Add(DTROWSAVE("DATE"))
                ALPARAVAL.Add(DTROWSAVE("BALANCE"))
                ALPARAVAL.Add(0)    'AMTPAIDREC
                ALPARAVAL.Add(0)    'EXTRAAMT
                ALPARAVAL.Add(0)    'RETURN
                ALPARAVAL.Add(DTROWSAVE("BALANCE"))
                ALPARAVAL.Add(DTROWSAVE("REGISTER"))
                ALPARAVAL.Add(DTROWSAVE("TYPE"))



                OBJSM.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBJSM.UPLOAD()
                DTROWSAVE = DTSAVE.NewRow()

SKIPLINE:
            Next
            oBook.Close()

            Exit Sub
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TERMSANDCONDITIONS_Click(sender As Object, e As EventArgs) Handles TERMSANDCONDITIONS.Click
        Try
            Dim OBJOPPO As New TermsAndConditions
            OBJOPPO.MdiParent = Me
            OBJOPPO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UPLOADSIGN_Click(sender As Object, e As EventArgs) Handles UPLOADSIGN.Click
        Try
            Dim OBJOPPO As New UploadSign
            OBJOPPO.MdiParent = Me
            OBJOPPO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub POINTSMASTER_Click(sender As Object, e As EventArgs) Handles POINTSMASTER.Click
        Try
            Dim OBJPOINTS As New Points
            OBJPOINTS.MdiParent = Me
            OBJPOINTS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewProformaHotelBookingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PROFORMAADD.Click
        Try
            Dim OBJPOINTS As New ProformaHotelBookings
            OBJPOINTS.MdiParent = Me
            OBJPOINTS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EDIT_PERFORMA_Click(sender As Object, e As EventArgs) Handles PROFORMAEDIT.Click
        Try
            Dim OBJPOINTS As New ProformaHotelBookingsDetails
            OBJPOINTS.MdiParent = Me
            OBJPOINTS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewToolStripMenuItem.Click
        Try
            Dim OBJPARTICUALR As New ParticularMaster
            OBJPARTICUALR.MdiParent = Me
            OBJPARTICUALR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditMasterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditMasterToolStripMenuItem.Click
        Try
            Dim OBJPARTICULARDETAILS As New ParticularDetails
            OBJPARTICULARDETAILS.MdiParent = Me
            OBJPARTICULARDETAILS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PROFORMAMISCADD.Click
        Try
            Dim OBJPROFORMAMISC As New ProformaMiscSale
            OBJPROFORMAMISC.MdiParent = Me
            OBJPROFORMAMISC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles PROFORMAMISCEDIT.Click
        Try
            Dim OBJ As ProformaMiscSaleDetails
            OBJ.MdiParent = Me
            OBJ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewCategoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewCategoryToolStripMenuItem.Click
        Try
            Dim OBJROOMTYPE As New RoomTypeMaster
            OBJROOMTYPE.MdiParent = Me
            OBJROOMTYPE.FRMSTRING = "CATEGORY"
            OBJROOMTYPE.Show()
            OBJROOMTYPE.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub EditExistingCategoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditExistingCategoryToolStripMenuItem.Click
        Try
            Dim OBJROOMTYPE As New RoomTypeDetails
            OBJROOMTYPE.MdiParent = Me
            OBJROOMTYPE.FRMSTRING = "CATEGORY"
            OBJROOMTYPE.Show()
            OBJROOMTYPE.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EinvoiceEntryDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EinvoiceEntryDetailsToolStripMenuItem.Click
        Try
            Dim OBJEINV As New EInvoiceCounterReport
            OBJEINV.MdiParent = Me
            OBJEINV.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewInclusionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewInclusionToolStripMenuItem.Click
        Try
            Dim OBJPOLICY As New CancelPolicyMaster
            OBJPOLICY.MdiParent = Me
            OBJPOLICY.FRMSTRING = "INCLUSIONS"
            OBJPOLICY.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingInclusionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditExistingInclusionToolStripMenuItem.Click
        Try
            Dim OBJPOLICY As New CancelPolicyDetails
            OBJPOLICY.MdiParent = Me
            OBJPOLICY.FRMSTRING = "INCLUSIONS"
            OBJPOLICY.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewExclusionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewExclusionToolStripMenuItem.Click
        Try
            Dim OBJPOLICY As New CancelPolicyMaster
            OBJPOLICY.MdiParent = Me
            OBJPOLICY.FRMSTRING = "EXCLUSIONS"
            OBJPOLICY.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingExclusionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditExistingExclusionToolStripMenuItem.Click
        Try
            Dim OBJPOLICY As New CancelPolicyDetails
            OBJPOLICY.MdiParent = Me
            OBJPOLICY.FRMSTRING = "EXCLUSIONS"
            OBJPOLICY.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OTHERSALEPURADD_Click(sender As Object, e As EventArgs) Handles OTHERSALEPURADD.Click
        Try
            Dim OBJPROFORMAMISC As New OtherSalePurchase
            OBJPROFORMAMISC.MdiParent = Me
            OBJPROFORMAMISC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OTHERSALEPUREDIT_Click(sender As Object, e As EventArgs) Handles OTHERSALEPUREDIT.Click
        Try
            Dim OBJPROFORMAMISC As New OtherSalePurchaseDetails
            OBJPROFORMAMISC.MdiParent = Me
            OBJPROFORMAMISC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class
