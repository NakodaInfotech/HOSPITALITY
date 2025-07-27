
Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports BL

Public Class PackageQuotation

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim gridDoubleClick As Boolean
    Dim gridTOURDoubleClick As Boolean
    Dim GRIDCARDOUBLECLICK, GRIDFOLLOWDOUBLECLICK, GRIDMISCDOUBLECLICK, GRIDAIRDOUBLECLICK, GRIDPURCHASEDOUBLECLICK As Boolean
    Dim temprow As Integer
    Dim tempTOURrow As Integer
    Dim TEMPCARROW, TEMPFOLLOWROW, TEMPMISCROW, tempFLIGHTrow, TEMPPURROW As Integer
    Public edit As Boolean
    Public TEMPENQNO As Integer
    Dim TEMPMSG As Integer

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Sub GETMAX_ENQ_NO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(ENQ_no),0) + 1 ", "HOLIDAYENQMASTER", " AND ENQ_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTENQNO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Sub clear()
        Try
            If ClientName = "TRAVELBRIDGE" Then CMBQUOTECALC.SelectedIndex = 0 Else CMBQUOTECALC.SelectedIndex = 1
            CHKAVL.CheckState = CheckState.Checked
            CMBCANCEL.Text = ""
            CMBNOTES.Text = ""
            TXTNOTES.Clear()
            TXTPOLICY.Clear()

            CMBNAME.Text = ""

            tstxtbillno.Clear()
            TXTTOURNAME.Clear()
            TXTADULTS.Clear()
            TXTCHILDS.Clear()
            TXTNCCHILDS.Clear()
            TXTTOTALPAX.Clear()
            TXTGUESTADD.Clear()
            TXTADD.Clear()
            txtrefno.Clear()
            ENQDATE.Value = Mydate
            TXTENQNO.Clear()
            TXTAMDENQNO.Clear()

            TXTEXTRAADULT.Clear()
            TXTEXTRAADULTRATE.Clear()
            TXTEXTRACHILD.Clear()
            TXTEXTRACHILDRATE.Clear()
            CMBGROUPDEPARTURE.Text = ""
            CMBGROUPDEPARTURE.Enabled = True
            CMBBOOKEDBY.Text = ""


            CMBGUESTNAME.Text = ""
            txtsrno.Clear()
            CMBHOTELCODE.Text = ""
            CMBHOTELNAME.Text = ""
            TXTCONFIRMATIONNO.Clear()
            TXTCONFIRMEDBY.Clear()
            PACKAGEFROM.Value = Mydate
            PACKAGETO.Value = Mydate
            CHECKINDATE.Value = Mydate
            CHECKOUTDATE.Value = Mydate.Date.AddDays(1)
            TXTTOTALNIGHTS.Text = 1
            CMBROOMTYPE.Text = ""
            CMBPLAN.Text = ""
            TXTNOOFROOMS.Clear()
            TXTRATE.Clear()
            TXTCHILDRATE.Clear()
            TXTINFANTRATE.Clear()
            CMBCURCODE.Text = ""
            TXTROE.Clear()
            TXTTOTAL.Clear()
            GRIDBOOKINGS.RowCount = 0
            TXTTOTALROOMS.Clear()
            TXTTOTALAMT.Clear()
            PBSOFTCOPY.Image = Nothing
            TXTTOURSRNO.Clear()
            TXTHEADER.Clear()
            TXTDETAILS.Clear()
            GRIDTOUR.RowCount = 0

            TXTCARSRNO.Clear()
            TXTCONTACTPERSON.Clear()
            TXTCONTACTNO.Clear()
            CMBCARTYPE.Text = ""
            CMBCARNAME.Text = ""
            TXTCARADULTS.Text = 0.0
            TXTCARCHILDS.Text = 0.0
            TXTCARTOTALPAX.Text = 0
            TXTCARTOTALAMT.Text = 0.0
            PICKUPDATE.Value = Mydate
            TXTPICKFROM.Clear()
            TXTPICKTIME.Clear()
            TXTPICKDTLS.Clear()
            DROPDDATE.Value = Mydate.Date.AddDays(1)
            TXTDROPAT.Clear()
            TXTDROPTIME.Clear()
            TXTDROPDTLS.Clear()
            TXTROUTE.Clear()
            TXTCARITINERARY.Clear()
            TXTCARNOTE.Clear()
            TXTCARAMT.Clear()
            GRIDTRANS.RowCount = 0

            TXTTOTALSALEAMT.Text = 0.0
            TXTOURCOMMPER.Text = 0.0
            TXTOURCOMMRS.Text = 0.0
            TXTDISCPER.Text = 0.0
            TXTDISCRS.Text = 0.0
            TXTSUBTOTAL.Text = 0.0
            cmbtax.Text = ""
            txttax.Text = 0.0
            CMBADDTAX.Text = ""
            TXTADDTAX.Text = 0.0
            cmbaddsub.SelectedIndex = 0
            CMBOTHERCHGS.Text = ""
            txtotherchg.Text = 0.0
            txtroundoff.Text = 0.0
            txtgrandtotal.Text = 0.0

            PBlock.Visible = False
            lbllocked.Visible = False
            LBLCLOSED.Visible = False

            TBMISC.SelectedIndex = 0

            TXTTOTALSALEAMT.Text = 0.0
            TXTOURCOMMPER.Text = 0.0

            TXTREMARKS.Clear()
            TXTBOOKDESC.Clear()
            TXTMISCENQNO.Clear()

            txtinwords.Clear()
            CMBEXCLUSION.Text = ""
            CMBINCLUSION.Text = ""
            TXTEXCLUSION.Clear()
            TXTINCLUSION.Clear()

            EP.Clear()
            gridDoubleClick = False
            gridTOURDoubleClick = False
            GRIDCARDOUBLECLICK = False
            GRIDFOLLOWDOUBLECLICK = False
            GRIDMISCDOUBLECLICK = False
            GRIDAIRDOUBLECLICK = False
            GRIDPURCHASEDOUBLECLICK = False

            GETMAX_ENQ_NO()
            If ClientName = "TOPCOMM" Then LBLREFNO.Text = "Tracking ID"


            If UserName = "Admin" Then
                CMBBOOKEDBY.Enabled = True
            Else
                CMBBOOKEDBY.Enabled = False
                CMBBOOKEDBY.Text = UserName
            End If

            txtsrno.Text = 1
            TXTTOURSRNO.Text = 1
            TXTCARSRNO.Text = 1
            TXTFSRNO.Text = 1
            TXTMISCSRNO.Text = 1
            TXTAIRSRNO.Text = 1
            TXTPURSRNO.Text = 1


            TXTTEMPADULTRATE.Clear()
            TXTTEMPEXADULTRATE.Clear()
            TXTTEMPCNBRATE.Clear()
            TXTTEMPCWBRATE.Clear()
            TXTTEMPINFANTRATE.Clear()


            CMBPACKAGETYPE.SelectedIndex = 0
            CMBITINERARY.Text = ""

            TXTBTOTALNIGHTS.Clear()
            TXTBADULTS.Clear()
            TXTBCHILDS.Clear()
            TXTBINFANTS.Clear()
            TXTBEXTRAADULT.Clear()
            TXTBEXTRAADULTRATE.Clear()
            TXTBEXTRACHILD.Clear()
            TXTBEXTRACHILDRATE.Clear()
            TXTBTOTPAX.Clear()
            CMBPACKAGE.Text = "No"

            TXTFSRNO.Text = 1
            DTFOLLOWDATE.Clear()
            CMBFOLLOWUPBY.Text = ""
            TXTFOLLOWTO.Clear()
            CMBSTAGE.Text = ""
            DTNEXTDATE.Clear()
            TXTFNARR.Clear()
            GRIDFOLLOW.RowCount = 0
            GRIDFOLLOWDOUBLECLICK = False

            'GridAir
            GRIDAIRLINE.RowCount = 0
            GRIDSECTOR.RowCount = 0
            TXTAIRSRNO.Text = 1
            TXTSECTOR.Clear()
            TXTTEMPSECTOR.Clear()
            TXTFLTNO.Clear()
            CMBTYPE.SelectedIndex = 0
            TXTBASIC.Clear()
            TXTPSF.Clear()
            TXTGRIDTAX.Clear()
            TXTAIRAMT.Clear()
            TXTTOTALBASIC.Clear()
            TXTTOTALPSF.Clear()
            TXTTOTALTAXES.Clear()
            TXTAIRTOTAL.Text = 0.0

            SECTORGROUP.Visible = False
            SECTORGROUP.SendToBack()

            GRIDFLIGHT.RowCount = 0

            'GridMisc
            GRIDMISC.RowCount = 0
            TXTMISCSRNO.Text = 1
            TXTMISCSERVICETYPE.Clear()
            TXTMISCREMARKS.Clear()
            TXTMISCAMT.Clear()
            GRIDPURCHASE.RowCount = 0
            TXTPURSRNO.Text = 1
            CMBPURNAME.Text = ""
            CMBPURCURCODE.Text = ""
            TXTPURROE.Clear()
            TXTPURAMOUNT.Clear()
            TXTPURREMARKS.Clear()

            GRIDAIRDOUBLECLICK = False
            GRIDMISCDOUBLECLICK = False
            GRIDPURCHASEDOUBLECLICK = False

            CMDAMEND.Enabled = True
            TXTOURCOMM.Clear()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        clear()
        edit = False
        ENQDATE.Focus()
    End Sub

    Private Sub PackageEnquiry_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNoCancel)
                If tempmsg = vbYes Then
                    If errorvalid() = True Then cmdok_Click(sender, e)
                ElseIf tempmsg = vbCancel Then
                    Exit Sub
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.OemQuotes Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.F2 Then
                tstxtbillno.Focus()
            ElseIf e.KeyCode = Keys.Left And e.Alt = True Then
                Call toolprevious_Click(sender, e)
            ElseIf e.KeyCode = Keys.Right And e.Alt = True Then
                Call toolnext_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
                Dim OBJINVDTLS As New PackageQuotationDetails
                OBJINVDTLS.MdiParent = MDIMain
                OBJINVDTLS.Show()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PackageEnquiry_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If AscW(e.KeyChar) <> 33 Then chkchange.CheckState = CheckState.Checked
    End Sub

    Sub fillcmb()
        Try
            If CMBHOTELNAME.Text.Trim = "" Then fillHOTEL(CMBHOTELNAME, "")
            If CMBSOURCE.Text.Trim = "" Then FILLSOURCE(CMBSOURCE, edit)
            If CMBBOOKEDBY.Text.Trim = "" Then FILLBOOKEDBY(CMBBOOKEDBY, edit)
            If cmbtax.Text.Trim = "" Then filltax(cmbtax, edit)
            If CMBOTHERCHGS.Text.Trim = "" Then fillname(CMBOTHERCHGS, edit, " AND GROUPMASTER.GROUP_SECONDARY ='INDIRECT EXPENSES'")
            If CMBCARTYPE.Text.Trim = "" Then FILLVEHICLETYPE(CMBCARTYPE, edit)
            If CMBCARNAME.Text.Trim = "" Then FILLVEHICLE(CMBCARNAME, edit, "")
            If CMBITINERARY.Text.Trim = "" Then FILLITINERARY(CMBITINERARY, " AND DATEADD(DAY,-1, CAST(ITINERARY_FROM AS DATE)) < '" & Format(PACKAGEFROM.Value.Date, "MM/dd/yyyy") & "' AND DATEADD(DAY,1, CAST(ITINERARY_TO AS DATE)) > '" & Format(PACKAGEFROM.Value.Date, "MM/dd/yyyy") & "' AND ISNULL(ITINERARY_PACKAGETYPE,'DOMESTIC') = '" & CMBPACKAGETYPE.Text.Trim & "'")
            If CMBGROUPDEPARTURE.Text.Trim = "" Then FILLGROUPNAME(CMBGROUPDEPARTURE, " AND GROUPDEP_FROM > '" & Format(ENQDATE.Value.Date, "MM/dd/yyyy") & "'")
            If CMBFOLLOWUPBY.Text.Trim = "" Then FILLBOOKEDBY(CMBFOLLOWUPBY, edit)
            If CMBSTAGE.Text.Trim = "" Then FILLSTAGE(CMBSTAGE)
            If CMBCURCODE.Text.Trim = "" Then FILLCURRENCY(CMBCURCODE)
            If CMBPURCURCODE.Text.Trim = "" Then FILLCURRENCY(CMBPURCURCODE)
            If CMBINCLUSION.Text.Trim = "" Then FILLINCLUSION(CMBINCLUSION, edit)
            If CMBEXCLUSION.Text.Trim = "" Then FILLEXCLUSION(CMBEXCLUSION, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PackageEnquiry_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'PACKAGE ENQUIRY'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)


            Cursor.Current = Cursors.WaitCursor
            fillcmb()
            clear()

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim ALPARAVAL As New ArrayList
                Dim OBJBOOKING As New ClsHolidayEnquiry()

                ALPARAVAL.Add(TEMPENQNO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                OBJBOOKING.alParaval = ALPARAVAL
                Dim dt As DataTable = OBJBOOKING.SELECTBOOKINGDESC()
                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows

                        TXTENQNO.Text = TEMPENQNO
                        ENQDATE.Value = Convert.ToDateTime(dr("BOOKINGDATE")).Date
                        txtrefno.Text = dr("REFNO")
                        CMBGUESTNAME.Text = dr("GUESTNAME")
                        CMBNAME.Text = dr("NAME")
                        TXTGUESTADD.Text = dr("GUESTADD")

                        TXTTOURNAME.Text = dr("TOURNAME")
                        PACKAGEFROM.Value = Convert.ToDateTime(dr("PACKAGEFROM")).Date
                        PACKAGETO.Value = Convert.ToDateTime(dr("PACKAGETO")).Date

                        TXTADULTS.Text = dr("ADULTS")
                        TXTCHILDS.Text = dr("CHILDS")
                        TXTNCCHILDS.Text = dr("NCCHILDS")
                        TXTTOTALPAX.Text = dr("TOTALPAX")
                        CMBITINERARY.Text = dr("ITINERARYNAME")
                        CMBGROUPDEPARTURE.Text = dr("GROUPDEPARTURENAME")
                        TXTMISCENQNO.Text = dr("MISCENQNO")

                        CMBPACKAGETYPE.Text = dr("PACKAGETYPE")
                        CMBQUOTECALC.Text = dr("QUOTETYPE")
                        TXTTOTALPURAMT.Text = dr("COSTPRICE")

                        TXTEXTRAADULT.Text = dr("EXTRAADULT")
                        TXTEXTRAADULTRATE.Text = dr("EXTRAADULTRATE")
                        TXTEXTRACHILD.Text = dr("EXTRACHILD")
                        TXTEXTRACHILDRATE.Text = dr("EXTRACHILDRATE")

                        CMBBOOKEDBY.Text = dr("BOOKEDBY")
                        CMBSOURCE.Text = dr("SOURCE")

                        TXTTOTALSALEAMT.Text = dr("TOTALSALEAMT")

                        TXTOURCOMMPER.Text = dr("OURCOMMPER")
                        TXTOURCOMMRS.Text = dr("OURCOMMRS")

                        TXTDISCPER.Text = dr("DISCPER")
                        TXTDISCRS.Text = dr("DISCRS")

                        cmbtax.Text = dr("TAXNAME")
                        txttax.Text = dr("TAXAMT")
                        CMBADDTAX.Text = dr("ADDTAXNAME")
                        TXTADDTAX.Text = dr("ADDTAXAMT")

                        CMBOTHERCHGS.Text = dr("OTHERCHGSNAME")
                        If dr("OTHERCHGS") > 0 Then
                            txtotherchg.Text = dr("OTHERCHGS")
                            cmbaddsub.Text = "Add"
                        Else
                            txtotherchg.Text = dr("OTHERCHGS") * (-1)
                            cmbaddsub.Text = "Sub."
                        End If

                        txtroundoff.Text = dr("ROUNDOFF")

                        TXTREMARKS.Text = Convert.ToString(dr("REMARKS"))
                        TXTBOOKDESC.Text = Convert.ToString(dr("BOOKINGDESC"))
                        CMBNOTES.Text = Convert.ToString(dr("NOTESNAME"))
                        TXTNOTES.Text = Convert.ToString(dr("NOTES"))
                        CMBCANCEL.Text = Convert.ToString(dr("POLICYNAME"))
                        TXTPOLICY.Text = Convert.ToString(dr("POLICY"))
                        CHKAVL.Checked = Convert.ToBoolean(dr("AVL"))
                        CHKQUOTE.Checked = Convert.ToBoolean(dr("QUOTEPENDING"))

                        TXTAMDENQNO.Text = Val(dr("AMDENQNO"))


                        If Convert.ToBoolean(dr("DONE")) = True Or Convert.ToBoolean(dr("AMENDED")) = True Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                        If Convert.ToBoolean(dr("CLOSE")) = True Then
                            LBLCLOSED.Visible = True
                            PBlock.Visible = True
                        End If



                        'BOOKING DETAILS
                        ' GRIDBOOKINGS.Rows.Add(dr("BOOKINGSRNO").ToString, dr("HOTELNAME"), dr("CONFNO"), dr("CONFBY"), dr("INCLUSIONS"), Format(Convert.ToDateTime(dr("ARRIVAL")).Date, "dd/MM/yyyy"), Format(Convert.ToDateTime(dr("DEPARTURE")).Date, "dd/MM/yyyy"), dr("ROOMTYPE").ToString, dr("PLAN").ToString, dr("NOOFROOMS").ToString, Format(Val(dr("RATE")), "0.00"), Format(Val(dr("amt")), "0.00"), Val(dr("NIGHTS")))
                        'GRIDBOOKINGS.Rows.Add(dr("BOOKINGSRNO").ToString, dr("HOTELNAME"), dr("CONFNO"), dr("CONFBY"), dr("INCLUSIONS"), Format(Convert.ToDateTime(dr("ARRIVAL")).Date, "dd/MM/yyyy"), Format(Convert.ToDateTime(dr("DEPARTURE")).Date, "dd/MM/yyyy"), dr("ROOMTYPE").ToString, dr("PLAN").ToString, dr("BADULTS"), dr("BCHILDS"), dr("BINFANTS"), dr("BEXTRAADULTS"), dr("BEXTRAADULTSRATE"), dr("BEXTRACHILDS"), dr("BEXTRACHILDSRATE"), dr("BTOTALPAX"), dr("NOOFROOMS").ToString, dr("BPACKAGE"), Format(Val(dr("RATE")), "0.00"), Format(Val(dr("CHILDRATE")), "0.00"), Format(Val(dr("INFANTRATE")), "0.00"), dr("CURCODE").ToString, Format(Val(dr("ROE")), "0.00"), Format(Val(dr("amt")), "0.00"), Val(dr("NIGHTS")))
                        GRIDBOOKINGS.Rows.Add(dr("BOOKINGSRNO").ToString, dr("HOTELNAME"), dr("CONFNO"), dr("CONFBY"), dr("INCLUSIONS"), Format(Convert.ToDateTime(dr("ARRIVAL")).Date, "dd/MM/yyyy"), Format(Convert.ToDateTime(dr("DEPARTURE")).Date, "dd/MM/yyyy"), dr("ROOMTYPE").ToString, dr("PLAN").ToString, dr("BADULTS"), dr("BCHILDS"), dr("BINFANTS"), dr("BEXTRAADULTS"), dr("BEXTRACHILDS"), dr("NOOFROOMS").ToString, dr("BPACKAGE"), Format(Val(dr("RATE")), "0.00"), Format(Val(dr("CHILDRATE")), "0.00"), Format(Val(dr("INFANTRATE")), "0.00"), dr("BEXTRAADULTSRATE"), dr("BEXTRACHILDSRATE"), dr("BTOTALPAX"), dr("CURCODE").ToString, Format(Val(dr("ROE")), "0.00"), Format(Val(dr("amt")), "0.00"), Val(dr("NIGHTS")))
                        CMBINCLUSION.Text = Convert.ToString(dr("CINCLUSION"))
                        TXTINCLUSION.Text = Convert.ToString(dr("TINCLUSION"))
                        CMBEXCLUSION.Text = Convert.ToString(dr("CEXCLUSION"))
                        TXTEXCLUSION.Text = Convert.ToString(dr("TEXCLUSION"))
                        If ClientName = "KHANNA" Then
                            TXTTEMPADULTRATE.Text = Val(GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(grate.Index).Value)
                            TXTTEMPEXADULTRATE.Text = Val(GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(GEXADURATE.Index).Value)
                            TXTTEMPCNBRATE.Text = Val(GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(GEXCHDRATE.Index).Value)
                            TXTTEMPCWBRATE.Text = Val(GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(GCHILDRATE.Index).Value)
                            TXTTEMPINFANTRATE.Text = Val(GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(GINFANTRATE.Index).Value)
                        End If

                    Next


                    'TOUR GRID
                    Dim OBJCMN As New ClsCommon
                    Dim dt1 As DataTable
                    dt1 = OBJCMN.search(" ENQ_SRNO AS SRNO, ENQ_HEADER AS HEADER, ENQ_DETAILS AS DETAILS, ENQ_PHOTO AS IMGPATH ", "", " HOLIDAYENQMASTER_TOURDETAILS ", " AND HOLIDAYENQMASTER_TOURDETAILS.ENQ_NO = " & TEMPENQNO & " AND ENQ_CMPID = " & CmpId & " AND ENQ_YEARID = " & YearId & " ORDER BY dbo.HOLIDAYENQMASTER_TOURDETAILS.ENQ_SRNO ")
                    If dt1.Rows.Count > 0 Then
                        For Each ROW As DataRow In dt1.Rows
                            If IsDBNull(ROW("IMGPATH")) = False Then GRIDTOUR.Rows.Add(Val(ROW("SRNO")), ROW("HEADER"), ROW("DETAILS"), Image.FromStream(New IO.MemoryStream(DirectCast(ROW("IMGPATH"), Byte())))) Else GRIDTOUR.Rows.Add(Val(ROW("SRNO")), ROW("HEADER"), ROW("DETAILS"), Nothing)
                        Next
                    End If

                    PBSOFTCOPY.Image = Nothing


                    'TRANS DETAILS
                    Dim DT3 As DataTable = OBJBOOKING.SELECTBOOKINGTRANSDETAILS()
                    If DT3.Rows.Count > 0 Then
                        For Each DR2 As DataRow In DT3.Rows
                            GRIDTRANS.Rows.Add(DR2("CARSRNO"), DR2("CONTACTPERSON"), DR2("CONTACTNO"), DR2("CARTYPE"), DR2("CARNAME"), Val(DR2("CARADULTS")), Val(DR2("CARCHILDS")), Val(DR2("CARTOTALPAX")), Format(DR2("PICKUPON"), "dd/MM/yyyy"), DR2("PICKUPFROM"), DR2("PICKUPTIME"), DR2("PICKUPDTLS"), Format(DR2("DROPON"), "dd/MM/yyyy"), DR2("DROPAT"), DR2("DROPTIME"), DR2("DROPDTLS"), Val(DR2("CARDAYS")), DR2("ROUTE"), DR2("CARITINERARY"), DR2("CARNOTE"), Format(Val(DR2("CARAMT")), "0.00"))
                        Next
                    End If

                    'FOLLOWUP GRID
                    Dim DTF As DataTable = OBJCMN.search("  HOLIDAYENQMASTER_FOLLOWUP.ENQ_CHK AS FCHK, ISNULL(HOLIDAYENQMASTER_FOLLOWUP.ENQ_NO, '') AS FOLLOWUPNO, ISNULL(HOLIDAYENQMASTER_FOLLOWUP.ENQ_SRNO, 0) AS SRNO, ISNULL(HOLIDAYENQMASTER_FOLLOWUP.ENQ_DATE, '') AS FOLLOWUPDATE, ISNULL(BOOKEDBYMASTER.BOOKEDBY_NAME, '') AS GIVENBY, ISNULL(HOLIDAYENQMASTER_FOLLOWUP.ENQ_GIVENTO, '') AS GIVENTO, ISNULL(STAGEMASTER.STAGE_NAME, '') AS STAGE, ISNULL(HOLIDAYENQMASTER_FOLLOWUP.ENQ_NEXTDATE, '') AS NEXTDATE, ISNULL(HOLIDAYENQMASTER_FOLLOWUP.ENQ_NARRATION, '') AS NARR", "", " HOLIDAYENQMASTER_FOLLOWUP INNER JOIN BOOKEDBYMASTER ON HOLIDAYENQMASTER_FOLLOWUP.ENQ_GIVENBYID = BOOKEDBYMASTER.BOOKEDBY_ID INNER JOIN STAGEMASTER ON HOLIDAYENQMASTER_FOLLOWUP.ENQ_STAGEID = STAGEMASTER.STAGE_ID", " AND ENQ_NO = " & TEMPENQNO & " AND ENQ_YEARID = " & YearId & " ORDER BY ENQ_SRNO")
                    If DTF.Rows.Count > 0 Then
                        For Each DTFOLLOW As DataRow In DTF.Rows
                            GRIDFOLLOW.Rows.Add(DTFOLLOW("FCHK"), DTFOLLOW("SRNO"), Format(Convert.ToDateTime(DTFOLLOW("FOLLOWUPDATE")).Date, "dd/MM/yyyy"), DTFOLLOW("GIVENBY"), DTFOLLOW("GIVENTO"), DTFOLLOW("STAGE"), DTFOLLOW("NEXTDATE"), DTFOLLOW("NARR"))
                            If Convert.ToBoolean(DTFOLLOW("FCHK")) = True Then GRIDFOLLOW.Rows(GRIDFOLLOW.RowCount - 1).DefaultCellStyle.BackColor = Color.LightGreen
                        Next
                    End If

                    'MISC GRID
                    Dim OBJMISC As New ClsCommon
                    Dim DTM As DataTable = OBJMISC.search(" ISNULL(HOLIDAYENQMASTER_MISC.ENQ_SRNO, 0) AS SRNO, ISNULL(HOLIDAYENQMASTER_MISC.ENQ_TYPE, '') AS TYPE, ISNULL(HOLIDAYENQMASTER_MISC.ENQ_REMARKS, '') AS REMARKS, ISNULL(HOLIDAYENQMASTER_MISC.ENQ_AMOUNT, 0) AS MISCAMOUNT ", "", " HOLIDAYENQMASTER INNER JOIN HOLIDAYENQMASTER_MISC ON HOLIDAYENQMASTER.ENQ_NO = HOLIDAYENQMASTER_MISC.ENQ_NO AND HOLIDAYENQMASTER.ENQ_YEARID = HOLIDAYENQMASTER_MISC.ENQ_YEARID ", " AND HOLIDAYENQMASTER_MISC.ENQ_NO = " & TEMPENQNO & " AND HOLIDAYENQMASTER_MISC.ENQ_YEARID = " & YearId & " ORDER BY HOLIDAYENQMASTER_MISC.ENQ_SRNO ")
                    If DTM.Rows.Count > 0 Then
                        For Each DR As DataRow In DTM.Rows
                            GRIDMISC.Rows.Add(Val(DR("SRNO")), DR("TYPE"), DR("REMARKS"), Val(DR("MISCAMOUNT")))
                        Next
                    End If


                    'GET AIRLINE DATA
                    Dim OBJAIR1 As New ClsCommon
                    Dim DTA1 As DataTable = OBJAIR1.search(" ISNULL(ENQ_NO, 0) AS GROUPDEPNO, ISNULL(ENQ_GRIDSRNO, 0) AS AIRSRNO, ISNULL(ENQ_SECTOR, '') AS SECTOR, ISNULL(ENQ_FLTNO, '') AS FLTNO, ISNULL(ENQ_TYPE, '') AS TYPE, ISNULL(ENQ_BASIC, 0) AS BASIC, ISNULL(ENQ_PSF, 0) AS PSF, ISNULL(ENQ_TAXES, 0) AS TAXES, ISNULL(ENQ_AMT, 0) AS AIRAMT ", "", " HOLIDAYENQMASTER_AIRLINE ", " AND HOLIDAYENQMASTER_AIRLINE.ENQ_NO = " & TEMPENQNO & " AND ENQ_YEARID = " & YearId & " ORDER BY HOLIDAYENQMASTER_AIRLINE.ENQ_GRIDSRNO")
                    If DTA1.Rows.Count > 0 Then
                        For Each DR1 As DataRow In DTA1.Rows
                            GRIDAIRLINE.Rows.Add(DR1("AIRSRNO"), DR1("SECTOR"), DR1("FLTNO"), DR1("TYPE"), Format(Val(DR1("BASIC")), "0.00"), Format(Val(DR1("PSF")), "0.00"), Format(Val(DR1("TAXES")), "0.00"), Format(Val(DR1("AIRAMT")), "0.00"))
                        Next
                        'total()
                    End If


                    'GET GRIDFLIGHT DATA
                    Dim OBJAIR2 As New ClsCommon
                    Dim DTA2 As DataTable = OBJCMN.search(" HOLIDAYENQMASTER_FLIGHTDESC.ENQ_GRIDSRNO AS GRIDSRNO, HOLIDAYENQMASTER_FLIGHTDESC.ENQ_BOOKSRNO AS BOOKSRNO, ISNULL(FROMSECTORMASTER.SECTOR_NAME, '') AS FROMSEC, ISNULL(TOSECTORMASTER.SECTOR_NAME, '') AS TOSEC, HOLIDAYENQMASTER_FLIGHTDESC.ENQ_FLIGHTNO AS FLIGHTNO, HOLIDAYENQMASTER_FLIGHTDESC.ENQ_FLIGHTDATE AS FLIGHTDATE, ISNULL(HOLIDAYENQMASTER_FLIGHTDESC.ENQ_ARRIVES, '') AS ARRIVES, CLASSMASTER.CLASS_NAME AS CLASS", "", " SECTORMASTER AS TOSECTORMASTER RIGHT OUTER JOIN HOLIDAYENQMASTER_FLIGHTDESC LEFT OUTER JOIN CLASSMASTER ON HOLIDAYENQMASTER_FLIGHTDESC.ENQ_YEARID = CLASSMASTER.CLASS_YEARID AND  HOLIDAYENQMASTER_FLIGHTDESC.ENQ_CMPID = CLASSMASTER.CLASS_CMPID AND HOLIDAYENQMASTER_FLIGHTDESC.ENQ_CLASSID = CLASSMASTER.CLASS_ID ON  TOSECTORMASTER.SECTOR_ID = HOLIDAYENQMASTER_FLIGHTDESC.ENQ_TOID AND TOSECTORMASTER.SECTOR_CMPID = HOLIDAYENQMASTER_FLIGHTDESC.ENQ_CMPID AND TOSECTORMASTER.SECTOR_YEARID = HOLIDAYENQMASTER_FLIGHTDESC.ENQ_YEARID LEFT OUTER JOIN SECTORMASTER AS FROMSECTORMASTER ON HOLIDAYENQMASTER_FLIGHTDESC.ENQ_FROMID = FROMSECTORMASTER.SECTOR_ID AND HOLIDAYENQMASTER_FLIGHTDESC.ENQ_CMPID = FROMSECTORMASTER.SECTOR_CMPID AND HOLIDAYENQMASTER_FLIGHTDESC.ENQ_YEARID = FROMSECTORMASTER.SECTOR_YEARID", " AND HOLIDAYENQMASTER_FLIGHTDESC.ENQ_NO = " & TEMPENQNO & " AND HOLIDAYENQMASTER_FLIGHTDESC.ENQ_CMPID = " & CmpId & " AND HOLIDAYENQMASTER_FLIGHTDESC.ENQ_YEARID = " & YearId & " ORDER BY HOLIDAYENQMASTER_FLIGHTDESC.ENQ_BOOKSRNO ASC, HOLIDAYENQMASTER_FLIGHTDESC.ENQ_GRIDSRNO ASC")
                    If dt.Rows.Count > 0 Then
                        For Each DR2 As DataRow In DTA2.Rows
                            GRIDFLIGHT.Rows.Add(DR2("GRIDSRNO").ToString, DR2("BOOKSRNO"), DR2("FROMSEC").ToString, DR2("TOSEC").ToString, DR2("FLIGHTNO").ToString, DR2("FLIGHTDATE").ToString, DR2("ARRIVES").ToString, DR2("CLASS").ToString)
                        Next
                        'total()
                    End If

                    'GRID PURCHASE
                    Dim OBJPUR As New ClsCommon
                    Dim DTP As DataTable = OBJPUR.search(" ISNULL(HOLIDAYENQMASTER_PURCHASE.ENQ_SRNO, 0) AS SRNO, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(HOLIDAYENQMASTER_PURCHASE.ENQ_AMOUNT, 0) AS AMOUNT, ISNULL(CURRENCYMASTER.CUR_CODE, '') AS CURCODE, ISNULL(HOLIDAYENQMASTER_PURCHASE.ENQ_ROE, 0) AS ROE, ISNULL(HOLIDAYENQMASTER_PURCHASE.ENQ_REMARKS, '') AS REMARKS ", "", " HOLIDAYENQMASTER INNER JOIN HOLIDAYENQMASTER_PURCHASE ON HOLIDAYENQMASTER.ENQ_NO = HOLIDAYENQMASTER_PURCHASE.ENQ_NO AND HOLIDAYENQMASTER.ENQ_YEARID = HOLIDAYENQMASTER_PURCHASE.ENQ_YEARID INNER JOIN LEDGERS ON HOLIDAYENQMASTER_PURCHASE.ENQ_NAMEID = LEDGERS.Acc_id LEFT OUTER JOIN CURRENCYMASTER ON ENQ_CURID = CUR_ID", " AND HOLIDAYENQMASTER_PURCHASE.ENQ_NO = " & TEMPENQNO & " AND HOLIDAYENQMASTER_PURCHASE.ENQ_YEARID = " & YearId & " ORDER BY HOLIDAYENQMASTER_PURCHASE.ENQ_SRNO ")
                    If DTP.Rows.Count > 0 Then
                        For Each DP1 As DataRow In DTP.Rows
                            GRIDPURCHASE.Rows.Add(DP1("SRNO"), DP1("NAME").ToString, Format(Val(DP1("AMOUNT")), "0.00"), DP1("CURCODE"), Format(Val(DP1("ROE")), "0.00"), DP1("REMARKS").ToString)
                        Next
                    End If

                    total()
                    chkchange.CheckState = CheckState.Checked
                    GRIDBOOKINGS.FirstDisplayedScrollingRowIndex = GRIDBOOKINGS.RowCount - 1
                    CMDAMEND.Enabled = False

                Else
                    'IF ROWCOUNT = 0
                    clear()
                    edit = False
                    ENQDATE.Focus()
                End If

            End If


        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim IntResult As Integer

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            alParaval.Add(ENQDATE.Value.Date)
            alParaval.Add(txtrefno.Text.Trim)
            alParaval.Add(CMBGUESTNAME.Text.Trim)
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(TXTGUESTADD.Text.Trim)

            alParaval.Add(CMBITINERARY.Text.Trim)
            alParaval.Add(TXTTOURNAME.Text.Trim)

            alParaval.Add(PACKAGEFROM.Value.Date)
            alParaval.Add(PACKAGETO.Value.Date)

            alParaval.Add(Val(TXTADULTS.Text.Trim))
            alParaval.Add(Val(TXTCHILDS.Text.Trim))
            alParaval.Add(Val(TXTNCCHILDS.Text.Trim))
            alParaval.Add(Val(TXTTOTALPAX.Text.Trim))
            alParaval.Add(CMBGROUPDEPARTURE.Text.Trim)
            alParaval.Add(Val(TXTMISCENQNO.Text.Trim))

            alParaval.Add(CMBPACKAGETYPE.Text.Trim)
            alParaval.Add(CMBQUOTECALC.Text.Trim)
            alParaval.Add(Val(TXTTOTALPURAMT.Text.Trim))
            alParaval.Add(Val(TXTAMDENQNO.Text.Trim))

            'BOOKING DETAILS
            Dim gridsrno As String = ""
            Dim HOTELNAME As String = ""
            Dim CONFNO As String = ""
            Dim CONFBY As String = ""
            Dim INCLUSIONS As String = ""
            Dim CHECKIN As String = ""
            Dim CHECKOUT As String = ""
            Dim ROOMTYPE As String = ""
            Dim PLAN As String = ""
            Dim BADULTS As String = ""
            Dim BCHILDS As String = ""
            Dim BINFANTS As String = ""
            Dim BEXTRAADULTS As String = ""
            Dim BEXTRAADULTSRATE As String = ""
            Dim BEXTRACHILDS As String = ""
            Dim BEXTRACHILDSRATE As String = ""
            Dim BTOTALPAX As String = ""
            Dim NOOFROOMS As String = ""
            Dim PACKAGE As String = ""
            Dim RATE As String = ""
            Dim CHILDRATE As String = ""
            Dim INFANTRATE As String = ""
            Dim CURCODE As String = ""
            Dim ROE As String = ""
            Dim AMT As String = ""
            Dim TOTALNIGHTS As String = ""
            Dim ACCDATE As String = ""


            For Each row As Windows.Forms.DataGridViewRow In GRIDBOOKINGS.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(GSRNO.Index).Value.ToString
                        HOTELNAME = row.Cells(GHOTELNAME.Index).Value.ToString
                        CONFNO = row.Cells(GCONFIRMATIONNO.Index).Value.ToString
                        CONFBY = row.Cells(GCONFIRMEDBY.Index).Value.ToString
                        INCLUSIONS = row.Cells(GINCLUSIONS.Index).Value.ToString
                        CHECKIN = Format(Convert.ToDateTime(row.Cells(GCHECKIN.Index).Value).Date, "MM/dd/yyyy")
                        ACCDATE = Format(Convert.ToDateTime(row.Cells(GCHECKIN.Index).Value).Date, "MM/dd/yyyy")
                        CHECKOUT = Format(Convert.ToDateTime(row.Cells(GCHECKOUT.Index).Value).Date, "MM/dd/yyyy")
                        ROOMTYPE = row.Cells(groomtype.Index).Value.ToString
                        PLAN = row.Cells(gplan.Index).Value.ToString
                        BADULTS = row.Cells(GADULTS.Index).Value.ToString
                        BCHILDS = row.Cells(GCHILD.Index).Value.ToString
                        BINFANTS = row.Cells(GINFANT.Index).Value.ToString
                        BEXTRAADULTS = row.Cells(GEXTADU.Index).Value.ToString
                        BEXTRAADULTSRATE = row.Cells(GEXADURATE.Index).Value.ToString
                        BEXTRACHILDS = row.Cells(GEXCHILD.Index).Value.ToString
                        BEXTRACHILDSRATE = row.Cells(GEXCHDRATE.Index).Value.ToString
                        BTOTALPAX = row.Cells(GTOTALPAX.Index).Value.ToString
                        NOOFROOMS = row.Cells(gnoofRooms.Index).Value.ToString
                        PACKAGE = row.Cells(gpack.Index).Value.ToString
                        RATE = Val(row.Cells(grate.Index).Value)
                        CHILDRATE = Val(row.Cells(GCHILDRATE.Index).Value)
                        INFANTRATE = Val(row.Cells(GINFANTRATE.Index).Value)
                        CURCODE = row.Cells(GCURCODE.Index).Value.ToString
                        ROE = row.Cells(GROE.Index).Value.ToString
                        AMT = row.Cells(gamt.Index).Value
                        TOTALNIGHTS = row.Cells(GNIGHTS.Index).Value

                    Else

                        gridsrno = gridsrno & "|" & row.Cells(GSRNO.Index).Value
                        HOTELNAME = HOTELNAME & "|" & row.Cells(GHOTELNAME.Index).Value
                        CONFNO = CONFNO & "|" & row.Cells(GCONFIRMATIONNO.Index).Value.ToString
                        CONFBY = CONFBY & "|" & row.Cells(GCONFIRMEDBY.Index).Value.ToString
                        INCLUSIONS = INCLUSIONS & "|" & row.Cells(GINCLUSIONS.Index).Value.ToString
                        CHECKIN = CHECKIN & "|" & Format(Convert.ToDateTime(row.Cells(GCHECKIN.Index).Value).Date, "MM/dd/yyyy")
                        CHECKOUT = CHECKOUT & "|" & Format(Convert.ToDateTime(row.Cells(GCHECKOUT.Index).Value).Date, "MM/dd/yyyy")
                        ROOMTYPE = ROOMTYPE & "|" & row.Cells(groomtype.Index).Value
                        PLAN = PLAN & "|" & row.Cells(gplan.Index).Value.ToString
                        BADULTS = BADULTS & "|" & row.Cells(GADULTS.Index).Value.ToString
                        BCHILDS = BCHILDS & "|" & row.Cells(GCHILD.Index).Value.ToString
                        BINFANTS = BINFANTS & "|" & row.Cells(GINFANT.Index).Value.ToString
                        BEXTRAADULTS = BEXTRAADULTS & "|" & row.Cells(GEXTADU.Index).Value.ToString
                        BEXTRAADULTSRATE = BEXTRAADULTSRATE & "|" & row.Cells(GEXADURATE.Index).Value.ToString
                        BEXTRACHILDS = BEXTRACHILDS & "|" & row.Cells(GEXCHILD.Index).Value.ToString
                        BEXTRACHILDSRATE = BEXTRACHILDSRATE & "|" & row.Cells(GEXCHDRATE.Index).Value.ToString
                        BTOTALPAX = BTOTALPAX & "|" & row.Cells(GTOTALPAX.Index).Value.ToString
                        NOOFROOMS = NOOFROOMS & "|" & row.Cells(gnoofRooms.Index).Value.ToString
                        PACKAGE = PACKAGE & "|" & row.Cells(gpack.Index).Value.ToString
                        RATE = RATE & "|" & Val(row.Cells(grate.Index).Value)
                        CHILDRATE = CHILDRATE & "|" & Val(row.Cells(GCHILDRATE.Index).Value)
                        INFANTRATE = INFANTRATE & "|" & Val(row.Cells(GINFANTRATE.Index).Value)
                        CURCODE = CURCODE & "|" & row.Cells(GCURCODE.Index).Value
                        ROE = ROE & "|" & row.Cells(GROE.Index).Value
                        AMT = AMT & "|" & row.Cells(gamt.Index).Value
                        TOTALNIGHTS = TOTALNIGHTS & "|" & row.Cells(GNIGHTS.Index).Value

                    End If
                End If
            Next

            alParaval.Add(ACCDATE)
            alParaval.Add(gridsrno)
            alParaval.Add(HOTELNAME)
            alParaval.Add(CONFNO)
            alParaval.Add(CONFBY)
            alParaval.Add(INCLUSIONS)
            alParaval.Add(CHECKIN)
            alParaval.Add(CHECKOUT)
            alParaval.Add(ROOMTYPE)
            alParaval.Add(PLAN)
            alParaval.Add(BADULTS)
            alParaval.Add(BCHILDS)
            alParaval.Add(BINFANTS)
            alParaval.Add(BEXTRAADULTS)
            alParaval.Add(BEXTRAADULTSRATE)
            alParaval.Add(BEXTRACHILDS)
            alParaval.Add(BEXTRACHILDSRATE)
            alParaval.Add(BTOTALPAX)
            alParaval.Add(NOOFROOMS)
            alParaval.Add(PACKAGE)
            alParaval.Add(RATE)
            alParaval.Add(CHILDRATE)
            alParaval.Add(INFANTRATE)
            alParaval.Add(CURCODE)
            alParaval.Add(ROE)
            alParaval.Add(AMT)
            alParaval.Add(TOTALNIGHTS)


            ''TOUR DETAILS
            'Dim TOURSRNO As String = ""
            'Dim TOURHEADER As String = ""
            'Dim TOURDETAILS As String = ""

            'For Each row As Windows.Forms.DataGridViewRow In GRIDTOUR.Rows
            '    If row.Cells(0).Value <> Nothing Then
            '        If TOURSRNO = "" Then
            '            TOURSRNO = row.Cells(GTOURSRNO.Index).Value.ToString
            '            TOURHEADER = Format(Convert.ToDateTime(row.Cells(GHEADER.Index).Value
            '            TOURDETAILS = row.Cells(GDETAILS.Index).Value.ToString

            '        Else

            '            TOURSRNO = TOURSRNO & "|" & row.Cells(GTOURSRNO.Index).Value
            '            TOURHEADER = TOURHEADER & "|" & Format(Convert.ToDateTime(row.Cells(GHEADER.Index).Value).Date, "MM/dd/yyyy")
            '            TOURDETAILS = TOURDETAILS & "|" & row.Cells(GDETAILS.Index).Value

            '        End If
            '    End If
            'Next

            'alParaval.Add(TOURSRNO)
            'alParaval.Add(TOURHEADER)
            'alParaval.Add(TOURDETAILS)




            'TRANS DETAILS
            Dim CARSRNO As String = ""
            Dim CONTACTPERSON As String = ""
            Dim CONTACTNO As String = ""
            Dim CARTYPE As String = ""
            Dim CARNAME As String = ""
            Dim CARADULT As String = ""
            Dim CARCHILD As String = ""
            Dim CARTOTALPAX As String = ""
            Dim PICKUPON As String = ""
            Dim PICKUPFROM As String = ""
            Dim PICKUPTIME As String = ""
            Dim PICKUPDTLS As String = ""
            Dim DROPON As String = ""
            Dim DROPAT As String = ""
            Dim DROPTIME As String = ""
            Dim DROPDTLS As String = ""
            Dim CARDAYS As String = ""
            Dim ROUTE As String = ""
            Dim CARITINERARY As String = ""
            Dim CARNOTE As String = ""
            Dim CARAMT As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDTRANS.Rows
                If row.Cells(GCARSRNO.Index).Value <> Nothing Then
                    If CARSRNO = "" Then
                        CARSRNO = row.Cells(GCARSRNO.Index).Value.ToString
                        CONTACTPERSON = row.Cells(GCARCONTACTNAME.Index).Value.ToString
                        CONTACTNO = row.Cells(GCARCONTACTNO.Index).Value.ToString
                        CARTYPE = row.Cells(GCARTYPE.Index).Value.ToString
                        CARNAME = row.Cells(GCARNAME.Index).Value.ToString
                        CARADULT = row.Cells(GCARADULTS.Index).Value.ToString
                        CARCHILD = row.Cells(GCARCHILDS.Index).Value.ToString
                        CARTOTALPAX = row.Cells(GCARPAX.Index).Value.ToString
                        PICKUPON = Format(Convert.ToDateTime(row.Cells(GCARPICKUP.Index).Value).Date, "MM/dd/yyyy")
                        PICKUPFROM = row.Cells(GCARPICKUPFROM.Index).Value.ToString
                        PICKUPTIME = row.Cells(GCARPICKUPTIME.Index).Value.ToString
                        PICKUPDTLS = row.Cells(GCARPICKUPDTLS.Index).Value.ToString

                        DROPON = Format(Convert.ToDateTime(row.Cells(GCARDROP.Index).Value).Date, "MM/dd/yyyy")
                        DROPAT = row.Cells(GCARDROPTO.Index).Value.ToString
                        DROPTIME = row.Cells(GCARDROPTIME.Index).Value.ToString
                        DROPDTLS = row.Cells(GCARDROPDTLS.Index).Value.ToString
                        CARDAYS = row.Cells(GCARDAYS.Index).Value.ToString

                        ROUTE = row.Cells(GCARROUTE.Index).Value.ToString
                        CARITINERARY = row.Cells(GCARITINERARY.Index).Value.ToString
                        CARNOTE = row.Cells(GCARNOTE.Index).Value.ToString
                        CARAMT = row.Cells(GCARAMT.Index).Value.ToString

                    Else

                        CARSRNO = CARSRNO & "|" & row.Cells(GCARSRNO.Index).Value.ToString
                        CONTACTPERSON = CONTACTPERSON & "|" & row.Cells(GCARCONTACTNAME.Index).Value.ToString
                        CONTACTNO = CONTACTNO & "|" & row.Cells(GCARCONTACTNO.Index).Value.ToString
                        CARTYPE = CARTYPE & "|" & row.Cells(GCARTYPE.Index).Value.ToString
                        CARNAME = CARNAME & "|" & row.Cells(GCARNAME.Index).Value.ToString
                        CARADULT = CARADULT & "|" & row.Cells(GCARADULTS.Index).Value.ToString
                        CARCHILD = CARCHILD & "|" & row.Cells(GCARCHILDS.Index).Value.ToString
                        CARTOTALPAX = CARTOTALPAX & "|" & row.Cells(GCARPAX.Index).Value.ToString
                        PICKUPON = PICKUPON & "|" & Format(Convert.ToDateTime(row.Cells(GCARPICKUP.Index).Value).Date, "MM/dd/yyyy")
                        PICKUPFROM = PICKUPFROM & "|" & row.Cells(GCARPICKUPFROM.Index).Value.ToString
                        PICKUPTIME = PICKUPTIME & "|" & row.Cells(GCARPICKUPTIME.Index).Value.ToString
                        PICKUPDTLS = PICKUPDTLS & "|" & row.Cells(GCARPICKUPDTLS.Index).Value.ToString

                        DROPON = DROPON & "|" & Format(Convert.ToDateTime(row.Cells(GCARDROP.Index).Value).Date, "MM/dd/yyyy")
                        DROPAT = DROPAT & "|" & row.Cells(GCARDROPTO.Index).Value.ToString
                        DROPTIME = DROPTIME & "|" & row.Cells(GCARDROPTIME.Index).Value.ToString
                        DROPDTLS = DROPDTLS & "|" & row.Cells(GCARDROPDTLS.Index).Value.ToString
                        CARDAYS = CARDAYS & "|" & row.Cells(GCARDAYS.Index).Value.ToString

                        ROUTE = ROUTE & "|" & row.Cells(GCARROUTE.Index).Value.ToString
                        CARITINERARY = CARITINERARY & "|" & row.Cells(GCARITINERARY.Index).Value.ToString
                        CARNOTE = CARNOTE & "|" & row.Cells(GCARNOTE.Index).Value.ToString
                        CARAMT = CARAMT & "|" & Val(row.Cells(GCARAMT.Index).Value.ToString)

                    End If
                End If
            Next


            alParaval.Add(CARSRNO)
            alParaval.Add(CONTACTPERSON)
            alParaval.Add(CONTACTNO)
            alParaval.Add(CARTYPE)
            alParaval.Add(CARNAME)
            alParaval.Add(CARADULT)
            alParaval.Add(CARCHILD)
            alParaval.Add(CARTOTALPAX)
            alParaval.Add(PICKUPON)
            alParaval.Add(PICKUPFROM)
            alParaval.Add(PICKUPTIME)
            alParaval.Add(PICKUPDTLS)
            alParaval.Add(DROPON)
            alParaval.Add(DROPAT)
            alParaval.Add(DROPTIME)
            alParaval.Add(DROPDTLS)
            alParaval.Add(CARDAYS)
            alParaval.Add(ROUTE)
            alParaval.Add(CARITINERARY)
            alParaval.Add(CARNOTE)
            alParaval.Add(CARAMT)



            'SALE DETAILS
            alParaval.Add(Val(TXTEXTRAADULT.Text.Trim))
            alParaval.Add(Val(TXTEXTRAADULTRATE.Text.Trim))
            alParaval.Add(Val(TXTEXTRACHILD.Text.Trim))
            alParaval.Add(Val(TXTEXTRACHILDRATE.Text.Trim))
            alParaval.Add(CMBBOOKEDBY.Text.Trim)


            alParaval.Add(Val(TXTTOTALNIGHTS.Text.Trim))
            alParaval.Add(Val(TXTTOTALROOMS.Text.Trim))



            alParaval.Add(CMBSOURCE.Text.Trim)

            'SALE VALUES
            alParaval.Add(Val(TXTTOTALMISCAMT.Text.Trim))
            alParaval.Add(Val(TXTTOTALSALEAMT.Text.Trim))
            alParaval.Add(Val(TXTOURCOMMPER.Text.Trim))
            alParaval.Add(Val(TXTOURCOMMRS.Text.Trim))
            alParaval.Add(Val(TXTDISCPER.Text.Trim))
            alParaval.Add(Val(TXTDISCRS.Text.Trim))
            alParaval.Add(Val(TXTSUBTOTAL.Text.Trim))
            alParaval.Add(cmbtax.Text.Trim)
            alParaval.Add(Val(txttax.Text.Trim))
            alParaval.Add(CMBADDTAX.Text.Trim)
            alParaval.Add(Val(TXTADDTAX.Text.Trim))

            alParaval.Add(CMBOTHERCHGS.Text.Trim)
            If cmbaddsub.Text.Trim = "Add" Then
                alParaval.Add(Val(txtotherchg.Text.Trim))
            ElseIf cmbaddsub.Text.Trim = "Sub." Then
                alParaval.Add(Val((txtotherchg.Text.Trim) * (-1)))
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(Val(txtroundoff.Text.Trim))
            alParaval.Add(Val(txtgrandtotal.Text.Trim))

            alParaval.Add(TXTREMARKS.Text.Trim)
            alParaval.Add(TXTBOOKDESC.Text.Trim)
            alParaval.Add(CMBNOTES.Text.Trim)
            alParaval.Add(CMBCANCEL.Text.Trim)
            alParaval.Add(TXTNOTES.Text.Trim)
            alParaval.Add(TXTPOLICY.Text.Trim)
            alParaval.Add(CHKAVL.Checked)
            alParaval.Add(txtinwords.Text.Trim)
            alParaval.Add(CHKQUOTE.CheckState)


            'FOR DONE
            If lbllocked.Visible = True Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)
            End If


            'FOR FOLLOWUP

            Dim FCHK As String = ""
            Dim FSRNO As String = ""
            Dim FDATE As String = ""
            Dim GIVENBY As String = ""
            Dim GIVENTO As String = ""
            Dim STAGE As String = ""
            Dim NDATE As String = ""
            Dim NARR As String = ""
            For Each row As Windows.Forms.DataGridViewRow In GRIDFOLLOW.Rows
                If row.Cells(GFSRNO.Index).Value <> Nothing Then
                    If FSRNO = "" Then
                        FCHK = row.Cells(GCHK.Index).Value
                        FSRNO = row.Cells(GFSRNO.Index).Value.ToString
                        FDATE = row.Cells(GFDATE.Index).Value.ToString
                        GIVENBY = row.Cells(GFNAME.Index).Value.ToString
                        GIVENTO = row.Cells(GFOLLOWTO.Index).Value.ToString
                        STAGE = row.Cells(GFSTAGE.Index).Value.ToString
                        NDATE = row.Cells(GFNEXTDATE.Index).Value.ToString
                        NARR = row.Cells(GFNARR.Index).Value.ToString
                    Else
                        FCHK = FCHK & "|" & row.Cells(GCHK.Index).Value
                        FSRNO = FSRNO & "|" & row.Cells(GFSRNO.Index).Value.ToString
                        FDATE = FDATE & "|" & row.Cells(GFDATE.Index).Value.ToString
                        GIVENBY = GIVENBY & "|" & row.Cells(GFNAME.Index).Value.ToString
                        GIVENTO = GIVENTO & "|" & row.Cells(GFOLLOWTO.Index).Value.ToString
                        STAGE = STAGE & "|" & row.Cells(GFSTAGE.Index).Value.ToString
                        NDATE = NDATE & "|" & row.Cells(GFNEXTDATE.Index).Value.ToString
                        NARR = NARR & "|" & row.Cells(GFNARR.Index).Value.ToString
                    End If
                End If
            Next

            alParaval.Add(FCHK)
            alParaval.Add(FSRNO)
            alParaval.Add(FDATE)
            alParaval.Add(GIVENBY)
            alParaval.Add(GIVENTO)
            alParaval.Add(STAGE)
            alParaval.Add(NDATE)
            alParaval.Add(NARR)


            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)
            alParaval.Add(ClientName)

            'GRID MISC
            Dim MISCSRNO As String = ""
            Dim MISCSERVICETYPE As String = ""
            Dim MISCREMARKS As String = ""
            Dim MISCAMOUNT As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDMISC.Rows
                If row.Cells(0).Value <> Nothing Then
                    If MISCSRNO = "" Then
                        MISCSRNO = Val(row.Cells(GMISCSRNO.Index).Value)
                        MISCSERVICETYPE = row.Cells(GMISCSERVICETYPE.Index).Value.ToString
                        MISCREMARKS = row.Cells(GMISCREMARKS.Index).Value.ToString
                        MISCAMOUNT = Val(row.Cells(GMISCAMOUNT.Index).Value)

                    Else
                        MISCSRNO = MISCSRNO & "|" & Val(row.Cells(GMISCSRNO.Index).Value)
                        MISCSERVICETYPE = MISCSERVICETYPE & "|" & row.Cells(GMISCSERVICETYPE.Index).Value.ToString
                        MISCREMARKS = MISCREMARKS & "|" & row.Cells(GMISCREMARKS.Index).Value.ToString
                        MISCAMOUNT = MISCAMOUNT & "|" & Val(row.Cells(GMISCAMOUNT.Index).Value)

                    End If
                End If
            Next

            alParaval.Add(MISCSRNO)
            alParaval.Add(MISCSERVICETYPE)
            alParaval.Add(MISCREMARKS)
            alParaval.Add(MISCAMOUNT)


            'GRID AIRLINE
            Dim AIRSRNO As String = ""
            Dim SECTOR As String = ""
            Dim FLTNO As String = ""
            Dim TYPE As String = ""
            Dim BASIC As String = ""
            Dim PSF As String = ""
            Dim TAXES As String = ""
            Dim AIRAMT As String = ""


            For Each row As Windows.Forms.DataGridViewRow In GRIDAIRLINE.Rows
                If row.Cells(GAIRSRNO.Index).Value <> Nothing Then
                    If AIRSRNO = "" Then
                        AIRSRNO = row.Cells(GAIRSRNO.Index).Value.ToString
                        SECTOR = row.Cells(GSECTOR.Index).Value.ToString
                        FLTNO = row.Cells(GFLTNO.Index).Value.ToString
                        TYPE = row.Cells(GTYPE.Index).Value.ToString
                        BASIC = row.Cells(GBASIC.Index).Value.ToString
                        PSF = row.Cells(GPSF.Index).Value.ToString
                        TAXES = row.Cells(GTAXES.Index).Value.ToString
                        AIRAMT = row.Cells(GTOTAL.Index).Value

                    Else
                        AIRSRNO = AIRSRNO & "|" & row.Cells(GAIRSRNO.Index).Value.ToString
                        SECTOR = SECTOR & "|" & row.Cells(GSECTOR.Index).Value.ToString
                        FLTNO = FLTNO & "|" & row.Cells(GFLTNO.Index).Value.ToString
                        TYPE = TYPE & "|" & row.Cells(GTYPE.Index).Value.ToString
                        BASIC = BASIC & "|" & row.Cells(GBASIC.Index).Value.ToString
                        PSF = PSF & "|" & row.Cells(GPSF.Index).Value.ToString
                        TAXES = TAXES & "|" & row.Cells(GTAXES.Index).Value.ToString
                        AIRAMT = AIRAMT & "|" & row.Cells(GTOTAL.Index).Value

                    End If
                End If
            Next

            alParaval.Add(AIRSRNO)
            alParaval.Add(SECTOR)
            alParaval.Add(FLTNO)
            alParaval.Add(TYPE)
            alParaval.Add(BASIC)
            alParaval.Add(PSF)
            alParaval.Add(TAXES)
            alParaval.Add(AIRAMT)

            'FLIGHT GRID
            Dim FLIGHTSRNO As String = ""
            Dim BOOKSRNO As String = ""
            Dim FROMSEC As String = ""
            Dim TOSEC As String = ""
            Dim FLIGHTNO As String = ""
            Dim FLIGHTDATE As String = ""
            Dim ARRIVES As String = ""
            Dim FLIGHTCLASS As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDFLIGHT.Rows
                If row.Cells(GFLIGHTSRNO.Index).Value <> Nothing Then
                    If FLIGHTSRNO = "" Then
                        FLIGHTSRNO = row.Cells(GFLIGHTSRNO.Index).Value.ToString
                        BOOKSRNO = row.Cells(GBOOKSRNO.Index).Value.ToString
                        FROMSEC = row.Cells(GFROM.Index).Value.ToString
                        TOSEC = row.Cells(GTO.Index).Value.ToString
                        FLIGHTNO = row.Cells(GFLIGHTNO.Index).Value.ToString
                        FLIGHTDATE = row.Cells(GFLTDATE.Index).Value.ToString
                        ARRIVES = row.Cells(GFLTARR.Index).Value.ToString
                        FLIGHTCLASS = row.Cells(GCLASS.Index).Value.ToString
                    Else
                        FLIGHTSRNO = FLIGHTSRNO & "|" & row.Cells(GFLIGHTSRNO.Index).Value.ToString
                        BOOKSRNO = BOOKSRNO & "|" & row.Cells(GBOOKSRNO.Index).Value.ToString
                        FROMSEC = FROMSEC & "|" & row.Cells(GFROM.Index).Value.ToString
                        TOSEC = TOSEC & "|" & row.Cells(GTO.Index).Value.ToString
                        FLIGHTNO = FLIGHTNO & "|" & row.Cells(GFLIGHTNO.Index).Value.ToString
                        FLIGHTDATE = FLIGHTDATE & "|" & row.Cells(GFLTDATE.Index).Value.ToString
                        ARRIVES = ARRIVES & "|" & row.Cells(GFLTARR.Index).Value.ToString
                        FLIGHTCLASS = FLIGHTCLASS & "|" & row.Cells(GCLASS.Index).Value.ToString
                    End If
                End If
            Next

            alParaval.Add(FLIGHTSRNO)
            alParaval.Add(BOOKSRNO)
            alParaval.Add(FROMSEC)
            alParaval.Add(TOSEC)
            alParaval.Add(FLIGHTNO)
            alParaval.Add(FLIGHTDATE)
            alParaval.Add(ARRIVES)
            alParaval.Add(FLIGHTCLASS)

            'PURCHASE GRID
            Dim PURSRNO As String = ""
            Dim PURNAME As String = ""
            Dim PURAMOUNT As String = ""
            Dim PURCURCODE As String = ""
            Dim PURROE As String = ""
            Dim PURREMARKS As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDPURCHASE.Rows
                If row.Cells(GPURSRNO.Index).Value <> Nothing Then
                    If PURSRNO = "" Then
                        PURSRNO = row.Cells(GPURSRNO.Index).Value.ToString
                        PURNAME = row.Cells(GPURNAME.Index).Value.ToString
                        PURAMOUNT = Val(row.Cells(GPURAMOUNT.Index).Value)
                        PURCURCODE = row.Cells(GPURCURCODE.Index).Value.ToString
                        PURROE = Val(row.Cells(GPURROE.Index).Value)
                        PURREMARKS = row.Cells(GPURREMARKS.Index).Value.ToString
                    Else
                        PURSRNO = PURSRNO & "|" & row.Cells(GPURSRNO.Index).Value.ToString
                        PURNAME = PURNAME & "|" & row.Cells(GPURNAME.Index).Value.ToString
                        PURAMOUNT = PURAMOUNT & "|" & Val(row.Cells(GPURAMOUNT.Index).Value)
                        PURCURCODE = PURCURCODE & "|" & row.Cells(GPURCURCODE.Index).Value.ToString
                        PURROE = PURROE & "|" & Val(row.Cells(GPURROE.Index).Value)
                        PURREMARKS = PURREMARKS & "|" & row.Cells(GPURREMARKS.Index).Value.ToString
                    End If
                End If
            Next

            alParaval.Add(PURSRNO)
            alParaval.Add(PURNAME)
            alParaval.Add(PURAMOUNT)
            alParaval.Add(PURCURCODE)
            alParaval.Add(PURROE)
            alParaval.Add(PURREMARKS)
            alParaval.Add(CMBINCLUSION.Text.Trim)
            alParaval.Add(CMBEXCLUSION.Text.Trim)
            alParaval.Add(TXTINCLUSION.Text.Trim)
            alParaval.Add(TXTEXCLUSION.Text.Trim)

            Dim OBJBOOKING As New ClsHolidayEnquiry()
            OBJBOOKING.alParaval = alParaval
            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTNO As DataTable = OBJBOOKING.save()
                MessageBox.Show("Details Added")
                TEMPENQNO = Val(DTNO.Rows(0).Item(0))
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                alParaval.Add(TEMPENQNO)

                IntResult = OBJBOOKING.update()
                MessageBox.Show("Details Updated")
                edit = False

            End If
            If GRIDTOUR.RowCount > 0 Then SAVETOUR()

            PRINTREPORT(TEMPENQNO)

            clear()
            ENQDATE.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub SAVETOUR()
        Try
            'GRID TOUR
            Dim OBJITI As New ClsHolidayEnquiry
            For Each row As Windows.Forms.DataGridViewRow In GRIDTOUR.Rows
                Dim ALPARAVAL As New ArrayList
                If row.Cells(GTOURSRNO.Index).Value <> Nothing Then
                    ALPARAVAL.Add(TEMPENQNO)
                    ALPARAVAL.Add(row.Cells(GTOURSRNO.Index).Value)
                    ALPARAVAL.Add(row.Cells(GHEADER.Index).Value)
                    ALPARAVAL.Add(row.Cells(GDETAILS.Index).Value)

                    If row.Cells(GIMGPATH.Index).Value IsNot Nothing Then
                        Dim MS As New IO.MemoryStream
                        PBSOFTCOPY.Image = row.Cells(GIMGPATH.Index).Value
                        PBSOFTCOPY.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                        ALPARAVAL.Add(MS.ToArray)
                    Else
                        ALPARAVAL.Add(DBNull.Value)
                    End If

                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Userid)
                    ALPARAVAL.Add(YearId)

                    OBJITI.alParaval = ALPARAVAL
                    Dim INTRES As Integer = OBJITI.SAVETOUR()
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTREPORT(ByVal ENQNO As Integer)
        Try
            If MsgBox("Send Quote to Guest?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            If ClientName = "TRAVELBRIDGE" AndAlso MsgBox("Wish to Print in Excel?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim OBJRPT As New clsReportDesigner("QUOTE", System.AppDomain.CurrentDomain.BaseDirectory & "QUOTE.xlsx", 2)
                OBJRPT.PACKAGEQUOTE_EXCEL(CmpId, YearId, ENQNO)
                Exit Sub
            End If


            Dim OBJVOUCHER As New HolidayEnqDesign
            OBJVOUCHER.MdiParent = MDIMain
            OBJVOUCHER.GUESTNAME = CMBGUESTNAME.Text.Trim
            OBJVOUCHER.ENQNO = ENQNO


            If ClientName = "UTTARAKHAND" Or ClientName = "SSR" Then
                TEMPMSG = MsgBox("Wish to Print Invoice?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    OBJVOUCHER.HIDEAMT = chkhideamt.CheckState
                    OBJVOUCHER.FRMSTRING = "PACKAGEINV"
                    OBJVOUCHER.Show()
                End If
                Exit Sub
            End If

            If ClientName = "TOPCOMM" Or ClientName = "AIRTRINITY" Or ClientName = "KHANNA" Then
                If MsgBox("Avail & Price to Hotel?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    OBJVOUCHER.SUBJECT = UCase(CMBGUESTNAME.Text.Trim) & " - " & UCase(CMBHOTELNAME.Text.Trim)
                    OBJVOUCHER.FRMSTRING = "HOTELRATE"
                    OBJVOUCHER.Show()
                End If
                'If ClientName = "TOPCOMM" Then Exit Sub
            End If

            If CMBQUOTECALC.Text = "Per Person" Then OBJVOUCHER.QUOTEPERPAX = True Else OBJVOUCHER.QUOTEPERPAX = False

            'SUBJECT
            If ClientName = "BELLA" Then
                'GET DESTINATION FROM ENQNO
                Dim OBJCMN As New ClsCommon
                Dim DTDES As DataTable = OBJCMN.search("ISNULL(CITY_NAME,'') AS DESTINATION", "", " MISCENQUIRY LEFT OUTER JOIN CITYMASTER ON MISC_CITYID = CITY_ID ", " AND MISC_NO =" & Val(TEMPENQNO) & " AND MISC_YEARID = " & YearId)
                OBJVOUCHER.SUBJECT = "BCD-" & Val(TEMPENQNO) & "/" & DTDES.Rows(0).Item("DESTINATION") & "/" & CMBGUESTNAME.Text.Trim & "/" & MonthName(CHECKINDATE.Value.Month) & "/" & Val(TXTTOTALPAX.Text.Trim)
            Else
                OBJVOUCHER.SUBJECT = TXTTOURNAME.Text.Trim & "-FILE NO - " & txtrefno.Text.Trim & "-ENQ NO - " & Val(TXTMISCENQNO.Text.Trim) & "-QUOTE NO - " & Val(TEMPENQNO)
            End If

            OBJVOUCHER.ADULTRATE = Val(GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(grate.Index).Value)
            OBJVOUCHER.EXTRAADULTRATE = Val(GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(GEXADURATE.Index).Value)
            OBJVOUCHER.CHILDRATE = Val(GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(GCHILDRATE.Index).Value)
            OBJVOUCHER.CHILDWITHOUTBEDRATE = Val(GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(GEXCHDRATE.Index).Value)
            OBJVOUCHER.INFANTRATE = Val(GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(GINFANTRATE.Index).Value)
            OBJVOUCHER.EXTRAADULTS = Val(GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(GEXTADU.Index).Value)
            OBJVOUCHER.EXTRACHILDS = Val(GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(GEXCHILD.Index).Value)
            OBJVOUCHER.NOOFROOMS = Val(GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(gnoofRooms.Index).Value)
            OBJVOUCHER.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        Dim OBJCMN As New ClsCommon
        Dim DT As New DataTable



        If CMBGUESTNAME.Text.Trim = "" Then
            EP.SetError(CMBGUESTNAME, " Please Fill Guest name")
            bln = False
        End If

        If GRIDBOOKINGS.RowCount = 0 Then
            EP.SetError(TXTTOTAL, "Enter Hotel Details")
            TBMISC.SelectedIndex = 0
            bln = False
        End If

        If CMBBOOKEDBY.Text.Trim.Length = 0 Then
            EP.SetError(CMBBOOKEDBY, " Please Fill Your Name ")
            bln = False
        End If

        If CMBNOTES.Text.Trim.Length = 0 And ClientName = "TRAVELBRIDGE" Then
            EP.SetError(CMBNOTES, " Please Fill Notes")
            bln = False
        End If

        If CMBCANCEL.Text.Trim.Length = 0 And ClientName = "TRAVELBRIDGE" Then
            EP.SetError(CMBCANCEL, " Please Fill Cancellation Policy")
            bln = False
        End If

        If Val(txtgrandtotal.Text.Trim) = 0 Then
            EP.SetError(txtgrandtotal, "Amount cannot be 0")
            bln = False
        End If

        If Val(txtotherchg.Text.Trim) = 0 Then
            CMBOTHERCHGS.Text = ""
            cmbaddsub.SelectedIndex = 0
        End If


        If Val(txtotherchg.Text.Trim) > 0 And CMBOTHERCHGS.Text.Trim = "" Then
            EP.SetError(txtotherchg, " Select Expense Type")
            bln = False
        End If


        If Not datecheck(ENQDATE.Value) Then
            EP.SetError(ENQDATE, "Date Not in Current Accounting Year")
            bln = False
        End If

        If PBlock.Visible = True Then
            EP.SetError(PBlock, "Quotation Locked, Booking Made")
            bln = False
        End If

        If ClientName = "CLASSIC" Then
            If Not datecheck(PACKAGEFROM.Value) Then
                EP.SetError(PACKAGEFROM, "Date Not in Current Accounting Year")
                bln = False
            End If
            If Not datecheck(PACKAGETO.Value) Then
                EP.SetError(PACKAGETO, "Date Not in Current Accounting Year")
                bln = False
            End If
            If Not datecheck(CHECKINDATE.Value) Then
                EP.SetError(CHECKINDATE, "Date Not in Current Accounting Year")
                bln = False
            End If
            If Not datecheck(CHECKOUTDATE.Value) Then
                EP.SetError(CHECKOUTDATE, "Date Not in Current Accounting Year")
                bln = False
            End If
        End If

        For Each ROW As DataGridViewRow In GRIDTRANS.Rows
            If ClientName <> "TRAVELBRIDGE" Then
                If Convert.ToDateTime(ROW.Cells(GCARPICKUP.Index).Value).Date < PACKAGEFROM.Value.Date Then
                    bln = False
                    EP.SetError(PACKAGETO, "Invalid Pickup Date")
                End If
                If Convert.ToDateTime(ROW.Cells(GCARDROP.Index).Value).Date > PACKAGETO.Value.Date Then
                    bln = False
                    EP.SetError(PACKAGETO, "Invalid Drop Date")
                End If
            End If
            If Convert.ToDateTime(ROW.Cells(GCARPICKUP.Index).Value).Date > Convert.ToDateTime(ROW.Cells(GCARDROP.Index).Value).Date Then
                bln = False
                EP.SetError(PACKAGETO, "Pick-up Date Cannot be greater than Drop Date")
            End If
        Next


        For Each ROW As DataGridViewRow In GRIDBOOKINGS.Rows
            If ClientName <> "TRAVELBRIDGE" Then
                If Convert.ToDateTime(ROW.Cells(GCHECKIN.Index).Value).Date < PACKAGEFROM.Value.Date Then
                    bln = False
                    EP.SetError(PACKAGETO, "Invalid Check In Date")
                End If
                If Convert.ToDateTime(ROW.Cells(GCHECKOUT.Index).Value).Date > PACKAGETO.Value.Date Then
                    bln = False
                    EP.SetError(PACKAGETO, "Invalid Check Out Date")
                End If
            Else

                'CHECK THE STATE OF SELECTED HOTEL, IF ALLOWSAMESTATE IS CHECKED THEN USER CAN SELECT ONLY THOSE HOTELS WHICH ARE PRESNET IN COMPANYSTATE
                DT = OBJCMN.search("ISNULL(CAST(STATE_REMARK AS VARCHAR(10)),'') AS STATECODE", "", " HOTELMASTER LEFT OUTER JOIN STATEMASTER ON HOTELMASTER.HOTEL_STATEID = STATE_ID", " AND HOTEL_NAME = '" & ROW.Cells(GHOTELNAME.Index).Value & "' AND HOTEL_YEARID = " & YearId)
                If DT.Rows.Count = 0 Or (DT.Rows.Count > 0 AndAlso ALLOWSAMESTATE = True And CMPSTATECODE <> DT.Rows(0).Item("STATECODE")) Then
                    EP.SetError(CMBNAME, " Booking Of Other State Not Allowed")
                    bln = False
                End If

            End If

            If Convert.ToDateTime(ROW.Cells(GCHECKIN.Index).Value).Date > Convert.ToDateTime(ROW.Cells(GCHECKOUT.Index).Value).Date Then
                bln = False
                EP.SetError(PACKAGETO, "Check In Cannot be greater than Check Out Date")
            End If
        Next

        If ClientName = "BELLA" Or ClientName = "TRAVELBRIDGE" Then
            If Val(TXTMISCENQNO.Text.Trim) = 0 Then
                EP.SetError(TXTMISCENQNO, "Please Select Enquiry First.....")
                bln = False
            End If
        End If

        Return bln
    End Function

    Sub total()
        Try
            ' TXTTOTALROOMS.Text = "0.00"
            TXTTOTALAMT.Text = "0.00"
            TXTTOTALSALEAMT.Text = "0.00"
            TXTCARTOTALAMT.Text = "0.00"
            TXTTOTALMISCAMT.Text = "0.00"

            TXTTOTALNIGHTS.Text = 0
            TXTTOTALROOMS.Text = 0
            TXTCARTOTALPAX.Text = 0

            CMBADDTAX.Text = ""
            TXTADDTAX.Clear()
            TXTTOTALNIGHTS.Clear()

            TXTTOTALPAX.Text = Val(TXTADULTS.Text.Trim) + Val(TXTCHILDS.Text.Trim) + Val(TXTNCCHILDS.Text.Trim) + Val(TXTEXTRAADULT.Text.Trim) + Val(TXTEXTRACHILD.Text.Trim)


            If GRIDBOOKINGS.RowCount > 0 Then

                TXTSUBTOTAL.Text = 0.0
                txttax.Text = 0.0
                TXTADDTAX.Text = 0.0
                If Val(TXTOURCOMMPER.Text.Trim) > 0 Then TXTOURCOMMRS.Text = 0.0
                If Val(TXTDISCPER.Text.Trim) > 0 Then TXTDISCRS.Text = 0.0
                txtroundoff.Text = 0.0
                txtgrandtotal.Text = 0.0

                For Each row As DataGridViewRow In GRIDBOOKINGS.Rows
                    If Val(row.Cells(gnoofRooms.Index).Value) > 0 Then TXTTOTALROOMS.Text = Val(TXTTOTALROOMS.Text) + Val(row.Cells(gnoofRooms.Index).Value)
                    'row.Cells(gamt.Index).Value = Val(row.Cells(grate.Index).Value) * Val(row.Cells(gnoofRooms.Index).Value)
                    If Val(row.Cells(gamt.Index).Value) > 0 Then TXTTOTALAMT.Text = Format(Val(TXTTOTALAMT.Text) + Val(row.Cells(gamt.Index).Value), "0.00")
                    TXTTOTALNIGHTS.Text = Val(TXTTOTALNIGHTS.Text.Trim) + Val(row.Cells(GNIGHTS.Index).Value)
                    ' TXTTOTALROOMS.Text = Val(TXTTOTALROOMS.Text.Trim) + Val(row.Cells(gnoofRooms.Index).Value)
                Next

                If GRIDTRANS.RowCount > 0 Then
                    For Each ROW As DataGridViewRow In GRIDTRANS.Rows
                        If Val(ROW.Cells(GCARADULTS.Index).Value) > 0 Then TXTCARTOTALPAX.Text = Val(TXTCARTOTALPAX.Text) + Val(ROW.Cells(GCARADULTS.Index).Value)
                        If Val(ROW.Cells(GCARCHILDS.Index).Value) > 0 Then TXTCARTOTALPAX.Text = Val(TXTCARTOTALPAX.Text) + Val(ROW.Cells(GCARCHILDS.Index).Value)
                        If Val(ROW.Cells(GCARAMT.Index).Value) > 0 Then TXTCARTOTALAMT.Text = Format(Val(TXTCARTOTALAMT.Text) + Val(ROW.Cells(GCARAMT.Index).Value), "0.00")
                    Next
                End If

                If GRIDMISC.RowCount > 0 Then
                    For Each ROW As DataGridViewRow In GRIDMISC.Rows
                        If Val(ROW.Cells(GMISCAMOUNT.Index).Value) > 0 Then TXTTOTALMISCAMT.Text = Val(TXTTOTALMISCAMT.Text) + Val(ROW.Cells(GMISCAMOUNT.Index).Value)
                    Next
                End If

                TXTTOTALSALEAMT.Text = Format(Val(TXTTOTALAMT.Text.Trim) + Val(TXTCARTOTALAMT.Text.Trim) + Val(TXTTOTALMISCAMT.Text), "0.00")
                If Val(TXTEXTRAADULT.Text.Trim) > 0 And Val(TXTEXTRAADULTRATE.Text.Trim) > 0 Then
                    'as per ashok sir dont multiply with nights
                    'TXTTOTALSALEAMT.Text = Format(Val(TXTTOTALSALEAMT.Text.Trim) + (Val(TXTEXTRAADULT.Text.Trim) * Val(TXTEXTRAADULTRATE.Text.Trim) * Val(TXTTOTALNIGHTS.Text.Trim)), "0.00")
                    TXTTOTALSALEAMT.Text = Format(Val(TXTTOTALSALEAMT.Text.Trim) + (Val(TXTEXTRAADULT.Text.Trim) * Val(TXTEXTRAADULTRATE.Text.Trim)), "0.00")
                End If

                If Val(TXTEXTRACHILD.Text.Trim) > 0 And Val(TXTEXTRACHILDRATE.Text.Trim) > 0 Then
                    'as per ashok sir dont multiply with nights
                    'TXTTOTALSALEAMT.Text = Format(Val(TXTTOTALSALEAMT.Text.Trim) + (Val(TXTEXTRACHILD.Text.Trim) * Val(TXTEXTRACHILDRATE.Text.Trim) * Val(TXTTOTALNIGHTS.Text.Trim)), "0.00")
                    TXTTOTALSALEAMT.Text = Format(Val(TXTTOTALSALEAMT.Text.Trim) + (Val(TXTEXTRACHILD.Text.Trim) * Val(TXTEXTRACHILDRATE.Text.Trim)), "0.00")
                End If



                'AS COMM IS CALCULATED AUTO
                'If Val(TXTOURCOMMPER.Text) > 0 Then
                '    TXTOURCOMMRS.Text = Format((Val(TXTOURCOMMPER.Text) * Val(TXTFINALPURAMT.Text)) / 100, "0.00")
                'Else
                '    TXTOURCOMMPER.Text = Format((Val(TXTOURCOMMRS.Text) * 100) / Val(TXTFINALPURAMT.Text), "0.00")
                'End If


                If Val(TXTDISCPER.Text) > 0 Then
                    TXTDISCRS.Text = Format((Val(TXTDISCPER.Text) * Val(TXTTOTALSALEAMT.Text)) / 100, "0.00")
                Else
                    ' TXTDISCPER.Text = Format((Val(TXTDISCRS.Text) * 100) / Val(TXTTOTALSALEAMT.Text), "0.00")
                End If


                'COZ OUR COMM SHOULD NOT BE ADDED
                'TXTSUBTOTAL.Text = Format((Val(TXTTOTALSALEAMT.Text) + Val(TXTOURCOMMRS.Text)) - Val(TXTDISCRS.Text), "0.00")
                TXTSUBTOTAL.Text = Format((Val(TXTTOTALSALEAMT.Text)) - Val(TXTDISCRS.Text), "0.00")


                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable = objclscommon.search("TAX_NAME,tax_tax", "", "TAXMaster", " and TAX_NAME = '" & cmbtax.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then txttax.Text = Format((Val(dt.Rows(0).Item(1)) * Val(TXTSUBTOTAL.Text)) / 100, "0.00")

                dt = objclscommon.search("TAX_NAME,tax_tax", "", "TAXMaster", " and TAX_NAME = '" & CMBADDTAX.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then TXTADDTAX.Text = Format((Val(dt.Rows(0).Item(1)) * Val(TXTSUBTOTAL.Text)) / 100, "0.00")


                If cmbaddsub.Text = "Add" Then
                    txtgrandtotal.Text = Format(Val(TXTSUBTOTAL.Text) + Val(txttax.Text) + Val(TXTADDTAX.Text) + Val(txtotherchg.Text), "0")
                    txtroundoff.Text = Format(Val(txtgrandtotal.Text) - (Val(TXTSUBTOTAL.Text) + Val(txttax.Text) + Val(TXTADDTAX.Text) + Val(txtotherchg.Text)), "0.00")
                Else
                    txtgrandtotal.Text = Format((Val(TXTSUBTOTAL.Text) + Val(txttax.Text) + Val(TXTADDTAX.Text)) - Val(txtotherchg.Text), "0")
                    txtroundoff.Text = Format(Val(txtgrandtotal.Text) - ((Val(TXTSUBTOTAL.Text) + Val(txttax.Text) + Val(TXTADDTAX.Text)) - Val(txtotherchg.Text)), "0.00")
                End If

                txtgrandtotal.Text = Format(Val(txtgrandtotal.Text), "0.00")

                'as per ASHOK BHAI'S RECOMMENDATION
                'TXTOURCOMMRS.Text = Format(Val(txtgrandtotal.Text) - Val(TXTFINALPURAMT.Text), "0.00")

                If Val(txtgrandtotal.Text) > 0 Then txtinwords.Text = CurrencyToWord(txtgrandtotal.Text)


            End If

            'GRID AIRLINE
            TXTTOTALBASIC.Text = "0.00"
            TXTTOTALPSF.Text = "0.00"
            TXTTOTALTAXES.Text = "0.00"
            If GRIDAIRLINE.RowCount > 0 Then
                For Each row As DataGridViewRow In GRIDAIRLINE.Rows
                    If Val(row.Cells(GBASIC.Index).Value) > 0 Then TXTTOTALBASIC.Text = Val(TXTTOTALBASIC.Text) + Val(row.Cells(GBASIC.Index).Value)
                    If Val(row.Cells(GPSF.Index).Value) > 0 Then TXTTOTALPSF.Text = Val(TXTTOTALPSF.Text) + Val(row.Cells(GPSF.Index).Value)
                    If Val(row.Cells(GTAXES.Index).Value) > 0 Then TXTTOTALTAXES.Text = Val(TXTTOTALTAXES.Text) + Val(row.Cells(GTAXES.Index).Value)
                    If Val(row.Cells(GTOTAL.Index).Value) > 0 Then TXTAIRTOTAL.Text = Format(Val(TXTAIRTOTAL.Text) + Val(row.Cells(GTOTAL.Index).Value), "0.00")
                Next
            End If

            'Purchase grid total
            TXTTOTALPURAMT.Text = 0.0
            If GRIDPURCHASE.Rows.Count > 0 Then
                For Each ROW As DataGridViewRow In GRIDPURCHASE.Rows
                    TXTTOTALPURAMT.Text = Val(TXTTOTALPURAMT.Text) + Val(ROW.Cells(GPURAMOUNT.Index).Value)
                Next
            End If

            TXTOURCOMM.Text = Val(TXTSUBTOTAL.Text) - Val(TXTTOTALPURAMT.Text)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsrno.GotFocus
        If gridDoubleClick = False Then
            If GRIDBOOKINGS.RowCount > 0 Then
                txtsrno.Text = Val(GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(GSRNO.Index).Value) + 1
            Else
                txtsrno.Text = 1
            End If
        End If
    End Sub

    Private Sub txtTOURSRNO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTTOURSRNO.GotFocus
        If gridTOURDoubleClick = False Then
            If GRIDTOUR.RowCount > 0 Then
                TXTTOURSRNO.Text = Val(GRIDTOUR.Rows(GRIDTOUR.RowCount - 1).Cells(GTOURSRNO.Index).Value) + 1
            Else
                TXTTOURSRNO.Text = 1
            End If
        End If
    End Sub

    Private Sub TXTTOTAL_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTTOTAL.Validating
        If CMBHOTELNAME.Text.Trim <> "" And CMBROOMTYPE.Text.Trim <> "" And CMBPLAN.Text.Trim <> "" And Val(TXTNOOFROOMS.Text.Trim) > 0 Then
            If ClientName = "TRAVELBRIDGE" And (Val(TXTTOTAL.Text.Trim) = 0 Or TXTCONFIRMEDBY.Text.Trim = "" Or TXTINCLUSIONS.Text.Trim = "" Or Val(TXTRATE.Text.Trim) = 0 Or Val(TXTBADULTS.Text.Trim) = 0) Then
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
                Exit Sub
            End If

            fillgrid()
            total()
        Else
            MsgBox("Enter Proper Details", MsgBoxStyle.Critical, "TRAVELMATE")
            Exit Sub
        End If
    End Sub

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            If grid.Name = "GRIDFOLLOW" Then
                For Each row As DataGridViewRow In grid.Rows
                    row.Cells(1).Value = row.Index + 1
                Next
            Else
                For Each row As DataGridViewRow In grid.Rows
                    row.Cells(0).Value = row.Index + 1
                Next
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()

        GRIDBOOKINGS.Enabled = True

        TXTBTOTPAX.Text = Val(TXTBADULTS.Text.Trim) + Val(TXTBCHILDS.Text.Trim) + Val(TXTBINFANTS.Text.Trim) + Val(TXTBEXTRAADULT.Text.Trim) + Val(TXTBEXTRACHILD.Text.Trim)
        If gridDoubleClick = False Then
            'GRIDBOOKINGS.Rows.Add(Val(txtsrno.Text.Trim), CMBHOTELNAME.Text.Trim, TXTCONFIRMATIONNO.Text.Trim, TXTCONFIRMEDBY.Text.Trim, TXTINCLUSION.Text.Trim, Format(CHECKINDATE.Value.Date, "dd/MM/yyyy"), Format(CHECKOUTDATE.Value.Date, "dd/MM/yyyy"), CMBROOMTYPE.Text.Trim, CMBPLAN.Text.Trim, Val(TXTBADULTS.Text.Trim), Val(TXTBCHILDS.Text.Trim), Val(TXTBINFANTS.Text.Trim), Val(TXTBEXTRAADULT.Text.Trim), Format(Val(TXTBEXTRAADULTRATE.Text.Trim), "0.00"), Val(TXTBEXTRACHILD.Text.Trim), Format(Val(TXTBEXTRACHILDRATE.Text.Trim), "0.00"), Val(TXTBTOTPAX.Text.Trim), Val(TXTNOOFROOMS.Text.Trim), CMBPACKAGE.Text.Trim, Format(Val(TXTRATE.Text.Trim), "0.00"), Format(Val(TXTCHILDRATE.Text.Trim), "0.00"), Format(Val(TXTINFANTRATE.Text.Trim), "0.00"), CMBCURCODE.Text.Trim, Val(TXTROE.Text.Trim), Format(Val(TXTTOTAL.Text.Trim), "0.00"), DateDiff(DateInterval.Day, CHECKINDATE.Value.Date, CHECKOUTDATE.Value.Date))

            GRIDBOOKINGS.Rows.Add(Val(txtsrno.Text.Trim), CMBHOTELNAME.Text.Trim, TXTCONFIRMATIONNO.Text.Trim, TXTCONFIRMEDBY.Text.Trim, TXTINCLUSION.Text.Trim, Format(CHECKINDATE.Value.Date, "dd/MM/yyyy"), Format(CHECKOUTDATE.Value.Date, "dd/MM/yyyy"), CMBROOMTYPE.Text.Trim, CMBPLAN.Text.Trim, Val(TXTBADULTS.Text.Trim), Val(TXTBCHILDS.Text.Trim), Val(TXTBINFANTS.Text.Trim), Val(TXTBEXTRAADULT.Text.Trim), Val(TXTBEXTRACHILD.Text.Trim), Val(TXTNOOFROOMS.Text.Trim), CMBPACKAGE.Text.Trim, Format(Val(TXTRATE.Text.Trim), "0.00"), Format(Val(TXTCHILDRATE.Text.Trim), "0.00"), Format(Val(TXTINFANTRATE.Text.Trim), "0.00"), Format(Val(TXTBEXTRAADULTRATE.Text.Trim), "0.00"), Format(Val(TXTBEXTRACHILDRATE.Text.Trim), "0.00"), Val(TXTBTOTPAX.Text.Trim), CMBCURCODE.Text.Trim, Val(TXTROE.Text.Trim), Format(Val(TXTTOTAL.Text.Trim), "0.00"), DateDiff(DateInterval.Day, CHECKINDATE.Value.Date, CHECKOUTDATE.Value.Date))
            'GRIDBOOKINGS.Rows.Add(Val(txtsrno.Text.Trim), CMBHOTELNAME.Text.Trim, TXTCONFIRMATIONNO.Text.Trim, TXTCONFIRMEDBY.Text.Trim, TXTINCLUSION.Text.Trim, Format(CHECKINDATE.Value.Date, "dd/MM/yyyy"), Format(CHECKOUTDATE.Value.Date, "dd/MM/yyyy"), CMBROOMTYPE.Text.Trim, CMBPLAN.Text.Trim, Val(TXTBADULTS.Text.Trim), Val(TXTBCHILDS.Text.Trim), Val(TXTBINFANTS.Text.Trim), Val(TXTBEXTRAADULT.Text.Trim), Format(Val(TXTBEXTRAADULTRATE.Text.Trim), "0.00"), Val(TXTBEXTRACHILD.Text.Trim), Format(Val(TXTBEXTRACHILDRATE.Text.Trim), "0.00"), Val(TXTBTOTPAX.Text.Trim), Val(TXTNOOFROOMS.Text.Trim), CMBPACKAGE.Text.Trim, Format(Val(TXTRATE.Text.Trim), "0.00"), Format(Val(TXTTOTAL.Text.Trim), "0.00"), DateDiff(DateInterval.Day, CHECKINDATE.Value.Date, CHECKOUTDATE.Value.Date))
            getsrno(GRIDBOOKINGS)
        ElseIf gridDoubleClick = True Then
            GRIDBOOKINGS.Item(GSRNO.Index, temprow).Value = Val(txtsrno.Text.Trim)
            GRIDBOOKINGS.Item(GHOTELNAME.Index, temprow).Value = CMBHOTELNAME.Text.Trim
            GRIDBOOKINGS.Item(GCONFIRMATIONNO.Index, temprow).Value = TXTCONFIRMATIONNO.Text.Trim
            GRIDBOOKINGS.Item(GCONFIRMEDBY.Index, temprow).Value = TXTCONFIRMEDBY.Text.Trim
            GRIDBOOKINGS.Item(GINCLUSIONS.Index, temprow).Value = TXTINCLUSION.Text.Trim
            GRIDBOOKINGS.Item(GCHECKIN.Index, temprow).Value = Format(CHECKINDATE.Value.Date, "dd/MM/yyyy")
            GRIDBOOKINGS.Item(GCHECKOUT.Index, temprow).Value = Format(CHECKOUTDATE.Value.Date, "dd/MM/yyyy")
            GRIDBOOKINGS.Item(groomtype.Index, temprow).Value = CMBROOMTYPE.Text.Trim
            GRIDBOOKINGS.Item(gplan.Index, temprow).Value = CMBPLAN.Text.Trim
            GRIDBOOKINGS.Item(GADULTS.Index, temprow).Value = TXTBADULTS.Text.Trim
            GRIDBOOKINGS.Item(GCHILD.Index, temprow).Value = TXTBCHILDS.Text.Trim
            GRIDBOOKINGS.Item(GINFANT.Index, temprow).Value = TXTBINFANTS.Text.Trim
            GRIDBOOKINGS.Item(GEXTADU.Index, temprow).Value = TXTBEXTRAADULT.Text.Trim
            GRIDBOOKINGS.Item(GEXCHILD.Index, temprow).Value = TXTBEXTRACHILD.Text.Trim
            GRIDBOOKINGS.Item(gnoofRooms.Index, temprow).Value = Val(TXTNOOFROOMS.Text.Trim)
            GRIDBOOKINGS.Item(gpack.Index, temprow).Value = CMBPACKAGE.Text.Trim
            GRIDBOOKINGS.Item(grate.Index, temprow).Value = Format(Val(TXTRATE.Text.Trim), "0.00")
            GRIDBOOKINGS.Item(GCHILDRATE.Index, temprow).Value = Format(Val(TXTCHILDRATE.Text.Trim), "0.00")
            GRIDBOOKINGS.Item(GINFANTRATE.Index, temprow).Value = Format(Val(TXTINFANTRATE.Text.Trim), "0.00")
            GRIDBOOKINGS.Item(GEXADURATE.Index, temprow).Value = TXTBEXTRAADULTRATE.Text.Trim
            GRIDBOOKINGS.Item(GEXCHDRATE.Index, temprow).Value = TXTBEXTRACHILDRATE.Text.Trim
            GRIDBOOKINGS.Item(GTOTALPAX.Index, temprow).Value = TXTBTOTPAX.Text.Trim
            GRIDBOOKINGS.Item(GCURCODE.Index, temprow).Value = CMBCURCODE.Text.Trim
            GRIDBOOKINGS.Item(GROE.Index, temprow).Value = Format(Val(TXTROE.Text.Trim), "0.00")
            GRIDBOOKINGS.Item(gamt.Index, temprow).Value = Format(Val(TXTTOTAL.Text.Trim), "0.00")
            GRIDBOOKINGS.Item(GNIGHTS.Index, temprow).Value = DateDiff(DateInterval.Day, CHECKINDATE.Value.Date, CHECKOUTDATE.Value.Date)
            gridDoubleClick = False
        End If

        GRIDBOOKINGS.FirstDisplayedScrollingRowIndex = GRIDBOOKINGS.RowCount - 1

        txtsrno.Clear()
        CMBHOTELNAME.Text = ""
        TXTCONFIRMATIONNO.Clear()
        TXTCONFIRMEDBY.Clear()
        CHECKINDATE.Value = Mydate
        CHECKOUTDATE.Value = Mydate
        CMBROOMTYPE.Text = ""
        'CMBPLAN.Text = ""
        'TXTNOOFROOMS.Text = ""
        TXTRATE.Clear()
        TXTCHILDRATE.Clear()
        TXTINFANTRATE.Clear()
        CMBCURCODE.Text = ""
        TXTROE.Clear()
        TXTTOTAL.Clear()
        TXTBTOTALNIGHTS.Clear()
        'TXTBADULTS.Clear()
        'TXTBCHILDS.Clear()
        TXTBINFANTS.Clear()
        'TXTBEXTRAADULT.Clear()
        TXTBEXTRAADULTRATE.Clear()
        'TXTBEXTRACHILD.Clear()
        TXTBEXTRACHILDRATE.Clear()
        TXTBTOTPAX.Clear()
        'CMBPACKAGE.Text = "Yes"
        temprow = 0

        txtsrno.Focus()

    End Sub

    Sub fillgridTOUR()

        'GRIDTOUR.Enabled = True

        'If gridTOURDoubleClick = False Then
        '    GRIDTOUR.Rows.Add(Val(TXTTOURSRNO.Text.Trim), TXTHEADER.Text.Trim, TXTDETAILS.Text.Trim, PBSOFTCOPY.Image)
        '    getsrno(GRIDTOUR)
        'ElseIf gridTOURDoubleClick = True Then
        '    GRIDTOUR.Item(GTOURSRNO.Index, tempTOURrow).Value = Val(TXTTOURSRNO.Text.Trim)
        '    GRIDTOUR.Item(GHEADER.Index, tempTOURrow).Value = TXTHEADER.Text.Trim
        '    GRIDTOUR.Item(GDETAILS.Index, tempTOURrow).Value = TXTDETAILS.Text.Trim
        '    GRIDTOUR.Item(GIMGPATH.Index, tempTOURrow).Value = PBSOFTCOPY.Image
        '    gridTOURDoubleClick = False
        'End If

        'GRIDTOUR.FirstDisplayedScrollingRowIndex = GRIDTOUR.RowCount - 1

        'TXTTOURSRNO.Clear()
        'TXTHEADER.Clear()
        'TXTDETAILS.Clear()
        'PBSOFTCOPY.Image = Nothing
        'TXTIMGPATH.Clear()

        'TXTTOURSRNO.Focus()
        'GRIDTOUR.FirstDisplayedScrollingRowIndex = GRIDTOUR.RowCount - 1
        Try
            If gridTOURDoubleClick = False Then
                GRIDTOUR.Rows.Add(Val(TXTTOURSRNO.Text.Trim), TXTHEADER.Text.Trim, TXTDETAILS.Text.Trim, PBSOFTCOPY.Image)
                getsrno(GRIDTOUR)

            ElseIf gridTOURDoubleClick = True Then

                GRIDTOUR.Item(GTOURSRNO.Index, tempTOURrow).Value = TXTTOURSRNO.Text.Trim
                GRIDTOUR.Item(GHEADER.Index, tempTOURrow).Value = TXTHEADER.Text.Trim
                GRIDTOUR.Item(GDETAILS.Index, tempTOURrow).Value = TXTDETAILS.Text.Trim
                GRIDTOUR.Item(GIMGPATH.Index, tempTOURrow).Value = PBSOFTCOPY.Image

                gridTOURDoubleClick = False
            End If

            GRIDTOUR.FirstDisplayedScrollingRowIndex = GRIDTOUR.RowCount - 1

            TXTTOURSRNO.Text = GRIDTOUR.RowCount + 1
            TXTHEADER.Clear()
            TXTDETAILS.Clear()
            PBSOFTCOPY.Image = Nothing
            TXTIMGPATH.Clear()
            TXTHEADER.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDBOOKINGS_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDBOOKINGS.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDBOOKINGS.Item(GSRNO.Index, e.RowIndex).Value <> Nothing Then
                gridDoubleClick = True
                txtsrno.Text = GRIDBOOKINGS.Item(GSRNO.Index, e.RowIndex).Value.ToString
                CMBHOTELNAME.Text = GRIDBOOKINGS.Item(GHOTELNAME.Index, e.RowIndex).Value.ToString
                FILLROOMTYPE()
                TXTCONFIRMATIONNO.Text = GRIDBOOKINGS.Item(GCONFIRMATIONNO.Index, e.RowIndex).Value.ToString
                TXTCONFIRMEDBY.Text = GRIDBOOKINGS.Item(GCONFIRMEDBY.Index, e.RowIndex).Value.ToString
                TXTINCLUSION.Text = GRIDBOOKINGS.Item(GINCLUSIONS.Index, e.RowIndex).Value.ToString
                CHECKINDATE.Value = GRIDBOOKINGS.Item(GCHECKIN.Index, e.RowIndex).Value
                CHECKOUTDATE.Value = GRIDBOOKINGS.Item(GCHECKOUT.Index, e.RowIndex).Value
                CMBROOMTYPE.Text = GRIDBOOKINGS.Item(groomtype.Index, e.RowIndex).Value.ToString
                CMBPLAN.Text = GRIDBOOKINGS.Item(gplan.Index, e.RowIndex).Value.ToString
                TXTBADULTS.Text = GRIDBOOKINGS.Item(GADULTS.Index, e.RowIndex).Value.ToString
                TXTBCHILDS.Text = GRIDBOOKINGS.Item(GCHILD.Index, e.RowIndex).Value.ToString
                TXTBINFANTS.Text = GRIDBOOKINGS.Item(GINFANT.Index, e.RowIndex).Value.ToString
                TXTBEXTRAADULT.Text = GRIDBOOKINGS.Item(GEXTADU.Index, e.RowIndex).Value.ToString
                TXTBEXTRAADULTRATE.Text = GRIDBOOKINGS.Item(GEXADURATE.Index, e.RowIndex).Value.ToString
                TXTBEXTRACHILD.Text = GRIDBOOKINGS.Item(GEXCHILD.Index, e.RowIndex).Value.ToString
                TXTBEXTRACHILDRATE.Text = GRIDBOOKINGS.Item(GEXCHDRATE.Index, e.RowIndex).Value.ToString
                TXTBTOTPAX.Text = GRIDBOOKINGS.Item(GTOTALPAX.Index, e.RowIndex).Value.ToString
                TXTNOOFROOMS.Text = GRIDBOOKINGS.Item(gnoofRooms.Index, e.RowIndex).Value.ToString
                CMBPACKAGE.Text = GRIDBOOKINGS.Item(gpack.Index, e.RowIndex).Value.ToString
                TXTRATE.Text = GRIDBOOKINGS.Item(grate.Index, e.RowIndex).Value.ToString
                TXTCHILDRATE.Text = GRIDBOOKINGS.Item(GCHILDRATE.Index, e.RowIndex).Value.ToString
                TXTINFANTRATE.Text = GRIDBOOKINGS.Item(GINFANTRATE.Index, e.RowIndex).Value.ToString
                CMBCURCODE.Text = GRIDBOOKINGS.Item(GCURCODE.Index, e.RowIndex).Value.ToString
                TXTROE.Text = GRIDBOOKINGS.Item(GROE.Index, e.RowIndex).Value.ToString
                TXTTOTAL.Text = GRIDBOOKINGS.Item(gamt.Index, e.RowIndex).Value.ToString
                TXTBTOTALNIGHTS.Text = GRIDBOOKINGS.Item(GNIGHTS.Index, e.RowIndex).Value.ToString
                temprow = e.RowIndex
                txtsrno.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDTOUR_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDTOUR.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDTOUR.Item(GTOURSRNO.Index, e.RowIndex).Value <> Nothing Then

                gridTOURDoubleClick = True
                TXTTOURSRNO.Text = GRIDTOUR.Item(GTOURSRNO.Index, e.RowIndex).Value.ToString
                TXTHEADER.Text = GRIDTOUR.Item(GHEADER.Index, e.RowIndex).Value.ToString
                TXTDETAILS.Text = GRIDTOUR.Item(GDETAILS.Index, e.RowIndex).Value.ToString
                PBSOFTCOPY.Image = GRIDTOUR.Item(GIMGPATH.Index, e.RowIndex).Value
                tempTOURrow = e.RowIndex
                TXTHEADER.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDBOOKINGS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDBOOKINGS.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDBOOKINGS.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If gridDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDBOOKINGS.Rows.RemoveAt(GRIDBOOKINGS.CurrentRow.Index)
                total()
                getsrno(GRIDBOOKINGS)

            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDTOUR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDTOUR.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDTOUR.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If gridTOURDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDTOUR.Rows.RemoveAt(GRIDTOUR.CurrentRow.Index)
                getsrno(GRIDTOUR)
                TXTTOURSRNO.Text = GRIDTOUR.RowCount + 1

            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If tstxtbillno.Text.Trim.Length = 0 Then Exit Sub
            GRIDBOOKINGS.RowCount = 0
            TEMPENQNO = Val(tstxtbillno.Text)
            If TEMPENQNO > 0 Then
                If ClientName = "VIDHI" Then
                    If UserName <> "Admin" Then
                        Dim OBJCMN As New ClsCommon
                        Dim DT As DataTable
                        DT = OBJCMN.search(" HOLIDAYENQMASTER.ENQ_NO ", "", " BOOKEDBYMASTER INNER JOIN HOLIDAYENQMASTER ON BOOKEDBYMASTER.BOOKEDBY_ID = HOLIDAYENQMASTER.ENQ_BOOKEDBYID AND BOOKEDBYMASTER.BOOKEDBY_YEARID = HOLIDAYENQMASTER.ENQ_YEARID ", " AND ENQ_NO = " & TEMPENQNO & " AND BOOKEDBYMASTER.BOOKEDBY_NAME = '" & UserName & "' and ENQ_yearid=" & YearId)
                        If DT.Rows.Count > 0 Then
                            edit = True
                            PackageEnquiry_Load(sender, e)
                        End If
                    Else
                        edit = True
                        PackageEnquiry_Load(sender, e)
                    End If
                Else
                    edit = True
                    PackageEnquiry_Load(sender, e)
                End If
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtax_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtax.GotFocus
        Try
            If cmbtax.Text.Trim = "" Then filltax(cmbtax, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtax_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbtax.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub cmbtax_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbtax.Validating
        Try
            If cmbtax.Text.Trim <> "" Then TAXvalidate(cmbtax, e, Me)
            total()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If ClientName = "TRAVELBRIDGE" Then
                Dim OBJENQ As New PackageQuotationGridDetails
                OBJENQ.MdiParent = MDIMain
                OBJENQ.Show()
            Else
                Dim OBJENQ As New PackageQuotationDetails
                OBJENQ.MdiParent = MDIMain
                OBJENQ.Show()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            GRIDBOOKINGS.RowCount = 0
LINE1:
            TEMPENQNO = Val(TXTENQNO.Text) - 1
            If TEMPENQNO > 0 Then
                If ClientName = "VIDHI" Then
                    If UserName <> "Admin" Then
                        Dim OBJCMN As New ClsCommon
                        Dim DT As DataTable
                        DT = OBJCMN.search(" HOLIDAYENQMASTER.ENQ_NO ", "", " BOOKEDBYMASTER INNER JOIN HOLIDAYENQMASTER ON BOOKEDBYMASTER.BOOKEDBY_ID = HOLIDAYENQMASTER.ENQ_BOOKEDBYID AND BOOKEDBYMASTER.BOOKEDBY_YEARID = HOLIDAYENQMASTER.ENQ_YEARID ", " AND ENQ_NO = " & TEMPENQNO & " AND BOOKEDBYMASTER.BOOKEDBY_NAME = '" & UserName & "' AND ENQ_yearid = " & YearId)
                        If DT.Rows.Count > 0 Then
                            edit = True
                            PackageEnquiry_Load(sender, e)
                        End If
                    Else
                        edit = True
                        PackageEnquiry_Load(sender, e)
                    End If
                Else
                    edit = True
                    PackageEnquiry_Load(sender, e)
                End If
            Else
                clear()
                edit = False
            End If
            If GRIDBOOKINGS.RowCount = 0 And TEMPENQNO > 1 Then
                TXTENQNO.Text = TEMPENQNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            GRIDBOOKINGS.RowCount = 0
LINE1:
            TEMPENQNO = Val(TXTENQNO.Text) + 1
            GETMAX_ENQ_NO()
            Dim MAXNO As Integer = TXTENQNO.Text.Trim
            clear()

            If Val(TXTENQNO.Text) - 1 >= TEMPENQNO Then
                If ClientName = "VIDHI" Then
                    If UserName <> "Admin" Then
                        Dim OBJCMN As New ClsCommon
                        Dim DT As DataTable
                        DT = OBJCMN.search(" HOLIDAYENQMASTER.ENQ_NO ", "", " BOOKEDBYMASTER INNER JOIN HOLIDAYENQMASTER ON BOOKEDBYMASTER.BOOKEDBY_ID = HOLIDAYENQMASTER.ENQ_BOOKEDBYID AND BOOKEDBYMASTER.BOOKEDBY_YEARID = HOLIDAYENQMASTER.ENQ_YEARID ", " AND ENQ_NO = " & TEMPENQNO & " AND BOOKEDBYMASTER.BOOKEDBY_NAME = '" & UserName & "' and ENQ_yearid = " & YearId)
                        If DT.Rows.Count > 0 Then
                            edit = True
                            PackageEnquiry_Load(sender, e)
                        End If
                    Else
                        edit = True
                        PackageEnquiry_Load(sender, e)
                    End If
                Else
                    edit = True
                    PackageEnquiry_Load(sender, e)
                End If
            Else
                clear()
                edit = False
            End If
            If GRIDBOOKINGS.RowCount = 0 And TEMPENQNO < MAXNO Then
                TXTENQNO.Text = TEMPENQNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub GETMAX_ENQ_NO_USER()
        Try
            Dim DTTABLE As New DataTable
            DTTABLE = getmax(" ISNULL(MAX(HOLIDAYENQMASTER.ENQ_NO), 0) + 1 ", " BOOKEDBYMASTER INNER JOIN HOLIDAYENQMASTER ON BOOKEDBYMASTER.BOOKEDBY_ID = HOLIDAYENQMASTER.ENQ_BOOKEDBYID AND BOOKEDBYMASTER.BOOKEDBY_YEARID = HOLIDAYENQMASTER.ENQ_YEARID ", " AND BOOKEDBYMASTER.BOOKEDBY_NAME = '" & UserName & "' and ENQ_yearid=" & YearId)
            If DTTABLE.Rows.Count > 0 Then TXTENQNO.Text = DTTABLE.Rows(0).Item(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbhotelcode_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBHOTELCODE.Enter
        Try
            If CMBHOTELCODE.Text.Trim = "" Then fillHOTELCODE(CMBHOTELCODE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbhotelname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBHOTELNAME.Enter
        Try
            If CMBHOTELNAME.Text.Trim = "" Then fillHOTEL(CMBHOTELNAME)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbhotelcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBHOTELCODE.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJHOTEL As New SelectHotel
                OBJHOTEL.ShowDialog()
                If OBJHOTEL.TEMPHOTELCODE <> "" Then CMBHOTELCODE.Text = OBJHOTEL.TEMPHOTELCODE
                If OBJHOTEL.TEMPHOTELNAME <> "" Then CMBHOTELNAME.Text = OBJHOTEL.TEMPHOTELNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbhotelcode_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBHOTELCODE.Validating
        Try
            If CMBHOTELCODE.Text.Trim <> "" Then HOTELCODEVALIDATE(CMBHOTELCODE, CMBHOTELNAME, e, Me, TXTHOTELADD)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbhotelname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBHOTELNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJHOTEL As New SelectHotel
                OBJHOTEL.ShowDialog()
                If OBJHOTEL.TEMPHOTELCODE <> "" Then CMBHOTELCODE.Text = OBJHOTEL.TEMPHOTELCODE
                If OBJHOTEL.TEMPHOTELNAME <> "" Then CMBHOTELNAME.Text = OBJHOTEL.TEMPHOTELNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHOTELNAME_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBHOTELNAME.Validated
        Try
            FILLROOMTYPE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbhotelname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBHOTELNAME.Validating
        Try
            If CMBHOTELNAME.Text.Trim <> "" Then HOTELvalidate(CMBHOTELNAME, CMBHOTELCODE, e, Me, TXTHOTELADD)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Try
            If edit = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If lbllocked.Visible = True Or LBLCLOSED.Visible = True Then
                    MsgBox("Quotation Locked/Closed", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                Dim tempmsg As Integer = MsgBox("Delete Quotation Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                If tempmsg = vbYes Then

                    Dim OBJBOOKING As New ClsHolidayEnquiry
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(TEMPENQNO)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Locationid)
                    ALPARAVAL.Add(YearId)
                    ALPARAVAL.Add(Userid)

                    OBJBOOKING.alParaval = ALPARAVAL
                    Dim INTRES As Integer = OBJBOOKING.Delete()
                    MsgBox("Quotation Deleted Successfully")

                    clear()
                    edit = False

                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTNOOFROOMS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTNOOFROOMS.KeyPress
        numkeypress(e, TXTNOOFROOMS, Me)
    End Sub

    Private Sub TXTNOOFROOMS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTNOOFROOMS.Validating
        Try
            If Val(TXTRATE.Text.Trim) > 0 And Val(TXTNOOFROOMS.Text.Trim) > 0 Then
                CALC()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTEXTRAADULT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTEXTRAADULT.KeyPress
        numkeypress(e, TXTEXTRAADULT, Me)
    End Sub

    Private Sub TXTEXTRAADULT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTEXTRAADULT.Validated
        Try
            TXTTOTALPAX.Text = Val(TXTADULTS.Text.Trim) + Val(TXTCHILDS.Text.Trim) + Val(TXTNCCHILDS.Text.Trim) + Val(TXTEXTRAADULT.Text.Trim) + Val(TXTEXTRACHILD.Text.Trim)
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTEXTRACHILD_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTEXTRACHILD.KeyPress
        numkeypress(e, TXTEXTRACHILD, Me)
    End Sub

    Private Sub TXTEXTRACHILD_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTEXTRACHILD.Validated
        Try
            TXTTOTALPAX.Text = Val(TXTADULTS.Text.Trim) + Val(TXTCHILDS.Text.Trim) + Val(TXTNCCHILDS.Text.Trim) + Val(TXTEXTRAADULT.Text.Trim) + Val(TXTEXTRACHILD.Text.Trim)
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSOURCE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBSOURCE.Enter
        Try
            If CMBSOURCE.Text.Trim = "" Then FILLSOURCE(CMBSOURCE, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBSOURCE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBSOURCE.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub CMBSOURCE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSOURCE.Validating
        Try
            If CMBSOURCE.Text.Trim <> "" Then SOURCEvalidate(CMBSOURCE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBOOKEDBY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBBOOKEDBY.Enter
        Try
            If CMBBOOKEDBY.Text.Trim = "" Then FILLBOOKEDBY(CMBBOOKEDBY, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBBOOKEDBY_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBBOOKEDBY.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub CMBBOOKEDBY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBBOOKEDBY.Validating
        Try
            If CMBBOOKEDBY.Text.Trim <> "" Then BOOKEDBYvalidate(CMBBOOKEDBY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPLAN_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPLAN.Enter
        Try
            If CMBPLAN.Text.Trim = "" Then FILLPLAN(CMBPLAN, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPLAN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBPLAN.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub CMBPLAN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPLAN.Validated
        GETRATE()
    End Sub

    Sub GETRATE()
        Try
            If edit = True Then Exit Sub
            'GET RATE FROM TARIFFMASTER
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" ISNULL(TARIFFMASTER_DESC.TARIFF_WEEKDAYS,0) AS WEEKDAYS, ISNULL(TARIFFMASTER_DESC.TARIFF_WEEKENDS,0) AS WEEKENDS ", "", " TARIFFMASTER INNER JOIN TARIFFMASTER_DESC ON TARIFFMASTER.TARIFF_ID = TARIFFMASTER_DESC.TARIFF_ID AND TARIFFMASTER.TARIFF_CMPID = TARIFFMASTER_DESC.TARIFF_CMPID AND TARIFFMASTER.TARIFF_LOCATIONID = TARIFFMASTER_DESC.TARIFF_LOCATIONID AND TARIFFMASTER.TARIFF_YEARID = TARIFFMASTER_DESC.TARIFF_YEARID INNER JOIN HOTELMASTER ON TARIFFMASTER.TARIFF_HOTELID = HOTELMASTER.HOTEL_ID AND TARIFFMASTER.TARIFF_CMPID = HOTELMASTER.HOTEL_CMPID AND TARIFFMASTER.TARIFF_LOCATIONID = HOTELMASTER.HOTEL_LOCATIONID AND TARIFFMASTER.TARIFF_YEARID = HOTELMASTER.HOTEL_YEARID INNER JOIN ROOMTYPEMASTER ON TARIFFMASTER_DESC.TARIFF_ROOMTYPEID = ROOMTYPEMASTER.ROOMTYPE_ID AND TARIFFMASTER_DESC.TARIFF_CMPID = ROOMTYPEMASTER.ROOMTYPE_CMPID AND TARIFFMASTER_DESC.TARIFF_LOCATIONID = ROOMTYPEMASTER.ROOMTYPE_LOCATIONID AND TARIFFMASTER_DESC.TARIFF_YEARID = ROOMTYPEMASTER.ROOMTYPE_YEARID INNER JOIN PLANMASTER ON TARIFFMASTER_DESC.TARIFF_PLANID = PLANMASTER.PLAN_ID AND TARIFFMASTER_DESC.TARIFF_CMPID = PLANMASTER.PLAN_CMPID AND TARIFFMASTER_DESC.TARIFF_LOCATIONID = PLANMASTER.PLAN_LOCATIONID AND TARIFFMASTER_DESC.TARIFF_YEARID = PLANMASTER.PLAN_YEARID ", " AND HOTEL_NAME = '" & CMBHOTELNAME.Text.Trim & "' AND ROOMTYPE_NAME = '" & CMBROOMTYPE.Text.Trim & "' AND PLAN_NAME = '" & CMBPLAN.Text.Trim & "' AND CAST(TARIFF_FROMDATE AS DATE) <= '" & Format(CHECKINDATE.Value.Date, "MM/dd/yyyy") & "' AND CAST(TARIFF_TODATE AS DATE) >= '" & Format(CHECKINDATE.Value.Date, "MM/dd/yyyy") & "'")
            If DT.Rows.Count > 0 Then
                If CHECKINDATE.Value.DayOfWeek = DayOfWeek.Saturday Or CHECKINDATE.Value.DayOfWeek = DayOfWeek.Sunday Then
                    TXTRATE.Text = DT.Rows(0).Item("WEEKENDS")
                Else
                    TXTRATE.Text = DT.Rows(0).Item("WEEKDAYS")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPLAN_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPLAN.Validating
        Try
            If CMBPLAN.Text.Trim <> "" Then
                Dim INCLUSIONS As String = ""
                PLANvalidate(CMBPLAN, e, Me, INCLUSIONS)

                If ClientName = "JESAL" Then
                    Dim EXISTINGINCLUSIONS As String = TXTINCLUSION.Text.Trim
                    TXTINCLUSION.Text = INCLUSIONS & " " & EXISTINGINCLUSIONS
                End If
            End If

            'CHECKING COMM WHETHER ANY OTHER HOTEL IS GIVING AND GOOD COMMISSION APART FROM THIS HOTEL
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" ISNULL(TARIFFMASTER_DESC.TARIFF_COMM,0) AS COMM,  ISNULL(HOTEL_NAME,'') AS HOTELNAME ", "", " TARIFFMASTER INNER JOIN TARIFFMASTER_DESC ON TARIFFMASTER.TARIFF_ID = TARIFFMASTER_DESC.TARIFF_ID AND TARIFFMASTER.TARIFF_CMPID = TARIFFMASTER_DESC.TARIFF_CMPID AND TARIFFMASTER.TARIFF_LOCATIONID = TARIFFMASTER_DESC.TARIFF_LOCATIONID AND TARIFFMASTER.TARIFF_YEARID = TARIFFMASTER_DESC.TARIFF_YEARID INNER JOIN HOTELMASTER ON TARIFFMASTER.TARIFF_HOTELID = HOTELMASTER.HOTEL_ID AND TARIFFMASTER.TARIFF_CMPID = HOTELMASTER.HOTEL_CMPID AND TARIFFMASTER.TARIFF_LOCATIONID = HOTELMASTER.HOTEL_LOCATIONID AND TARIFFMASTER.TARIFF_YEARID = HOTELMASTER.HOTEL_YEARID INNER JOIN ROOMTYPEMASTER ON TARIFFMASTER_DESC.TARIFF_ROOMTYPEID = ROOMTYPEMASTER.ROOMTYPE_ID AND TARIFFMASTER_DESC.TARIFF_CMPID = ROOMTYPEMASTER.ROOMTYPE_CMPID AND TARIFFMASTER_DESC.TARIFF_LOCATIONID = ROOMTYPEMASTER.ROOMTYPE_LOCATIONID AND TARIFFMASTER_DESC.TARIFF_YEARID = ROOMTYPEMASTER.ROOMTYPE_YEARID INNER JOIN PLANMASTER ON TARIFFMASTER_DESC.TARIFF_PLANID = PLANMASTER.PLAN_ID AND TARIFFMASTER_DESC.TARIFF_CMPID = PLANMASTER.PLAN_CMPID AND TARIFFMASTER_DESC.TARIFF_LOCATIONID = PLANMASTER.PLAN_LOCATIONID AND TARIFFMASTER_DESC.TARIFF_YEARID = PLANMASTER.PLAN_YEARID ", " AND ROOMTYPE_NAME = '" & CMBROOMTYPE.Text.Trim & "' AND PLAN_NAME = '" & CMBPLAN.Text.Trim & "' AND CAST(TARIFF_FROMDATE AS DATE) <= '" & Format(CHECKINDATE.Value.Date, "MM/dd/yyyy") & "' AND CAST(TARIFF_TODATE AS DATE) >= '" & Format(CHECKINDATE.Value.Date, "MM/dd/yyyy") & "' ORDER BY TARIFF_COMM DESC")
            If DT.Rows.Count > 0 Then If DT.Rows(0).Item("HOTELNAME") <> CMBHOTELNAME.Text.Trim Then MsgBox(DT.Rows(0).Item("HOTELNAME") & " gives " & Val(DT.Rows(0).Item("COMM")) & " % Comm")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLROOMTYPE()
        Try
            If CMBHOTELNAME.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" DISTINCT ROOMTYPEMASTER.ROOMTYPE_NAME AS ROOMTYPE", "", " HOTELMASTER_ROOMDESC INNER JOIN HOTELMASTER ON HOTELMASTER_ROOMDESC.HOTEL_ID = HOTELMASTER.HOTEL_ID AND HOTELMASTER_ROOMDESC.HOTEL_CMPID = HOTELMASTER.HOTEL_CMPID AND HOTELMASTER_ROOMDESC.HOTEL_LOCATIONID = HOTELMASTER.HOTEL_LOCATIONID AND HOTELMASTER_ROOMDESC.HOTEL_YEARID = HOTELMASTER.HOTEL_YEARID INNER JOIN ROOMTYPEMASTER ON HOTELMASTER_ROOMDESC.HOTEL_ROOMTYPEID = ROOMTYPEMASTER.ROOMTYPE_ID AND HOTELMASTER_ROOMDESC.HOTEL_CMPID = ROOMTYPEMASTER.ROOMTYPE_CMPID AND HOTELMASTER_ROOMDESC.HOTEL_LOCATIONID = ROOMTYPEMASTER.ROOMTYPE_LOCATIONID AND HOTELMASTER_ROOMDESC.HOTEL_YEARID = ROOMTYPEMASTER.ROOMTYPE_YEARID", " AND HOTELMASTER.HOTEL_NAME = '" & CMBHOTELNAME.Text.Trim & "' AND HOTELMASTER.HOTEL_CMPID = " & CmpId & " AND HOTELMASTER.HOTEL_LOCATIONID = " & Locationid & " AND HOTELMASTER.HOTEL_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    DT.DefaultView.Sort = "ROOMTYPE"
                    CMBROOMTYPE.DataSource = DT
                    CMBROOMTYPE.DisplayMember = "ROOMTYPE"
                    If edit = False Then CMBROOMTYPE.Text = ""
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBROOMTYPE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBROOMTYPE.Enter
        Try
            If CMBHOTELNAME.Text.Trim <> "" And gridDoubleClick = False Then FILLROOMTYPE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTRATE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTRATE.KeyPress, TXTCHILDRATE.KeyPress, TXTINFANTRATE.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTRATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTRATE.Validating, TXTCHILDRATE.Validating, TXTINFANTRATE.Validating
        Try
            If Val(TXTRATE.Text.Trim) > 0 And Val(TXTNOOFROOMS.Text.Trim) > 0 Then CALC()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBROOMTYPE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBROOMTYPE.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub TXTEXTRAADULTRATE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTEXTRAADULTRATE.KeyPress
        numdotkeypress(e, TXTEXTRAADULTRATE, Me)
    End Sub

    Private Sub TXTEXTRAADULTRATE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTEXTRAADULTRATE.Validated
        TXTTOTALPAX.Text = Val(TXTADULTS.Text.Trim) + Val(TXTCHILDS.Text.Trim) + Val(TXTNCCHILDS.Text.Trim) + Val(TXTEXTRAADULT.Text.Trim) + Val(TXTEXTRACHILD.Text.Trim)
        total()
    End Sub

    Private Sub TXTEXTRACHILDRATE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTEXTRACHILDRATE.KeyPress
        numdotkeypress(e, TXTEXTRACHILDRATE, Me)
    End Sub

    Private Sub TXTEXTRACHILDRATE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTEXTRACHILDRATE.Validated
        TXTTOTALPAX.Text = Val(TXTADULTS.Text.Trim) + Val(TXTCHILDS.Text.Trim) + Val(TXTNCCHILDS.Text.Trim) + Val(TXTEXTRAADULT.Text.Trim) + Val(TXTEXTRACHILD.Text.Trim)
        total()
    End Sub

    Private Sub TXTOURCOMMPER_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTOURCOMMPER.KeyPress
        numdotkeypress(e, TXTOURCOMMPER, Me)
    End Sub

    Private Sub TXTOURCOMMPER_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTOURCOMMPER.Validated
        total()
    End Sub

    Private Sub TXTOURCOMMRS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTOURCOMMRS.KeyPress
        numdotkeypress(e, TXTOURCOMMRS, Me)
    End Sub

    Private Sub TXTOURCOMMRS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTOURCOMMRS.Validated
        total()
    End Sub

    Private Sub TXTDISCPER_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTDISCPER.KeyPress
        numdotkeypress(e, TXTDISCPER, Me)
    End Sub

    Private Sub TXTDISCPER_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTDISCPER.Validated
        total()
    End Sub

    Private Sub TXTDISCRS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTDISCRS.KeyPress
        numdotkeypress(e, TXTDISCRS, Me)
    End Sub

    Private Sub TXTDISCRS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTDISCRS.Validated
        total()
    End Sub

    Private Sub cmbaddsub_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbaddsub.Validated
        total()
    End Sub

    Private Sub txtotherchg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtotherchg.KeyPress
        numdotkeypress(e, txtotherchg, Me)
    End Sub

    Private Sub txtotherchg_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtotherchg.Validated
        total()
    End Sub

    Private Sub TXTADULTS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTADULTS.KeyPress
        numdotkeypress(e, TXTADULTS, Me)
    End Sub

    Private Sub TXTCHILDS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCHILDS.KeyPress
        numdotkeypress(e, TXTCHILDS, Me)
    End Sub

    Private Sub TXTNCCHILDS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTNCCHILDS.KeyPress
        numkeypress(e, TXTNCCHILDS, Me)
    End Sub

    Private Sub cmbaddtax_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBADDTAX.GotFocus
        Try
            If CMBADDTAX.Text.Trim = "" Then filltax(CMBADDTAX, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbADDtax_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBADDTAX.Validating
        Try
            If CMBADDTAX.Text.Trim <> "" Then TAXvalidate(CMBADDTAX, e, Me)
            total()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PBDISCDEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBDISCDEL.Click
        Try
            TXTDISCPER.Text = 0.0
            TXTDISCRS.Text = 0.0
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripprint.Click
        Try
            If edit = True Then PRINTREPORT(TEMPENQNO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTDETAILS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTDETAILS.Validating
        Try
            If TXTHEADER.Text.Trim <> "" And TXTDETAILS.Text.Trim <> "" Then
                fillgridTOUR()
            Else
                If TXTHEADER.Text.Trim <> "" Then MsgBox("Enter Proper Details")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTADULTS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTADULTS.Validated, TXTCHILDS.Validated, TXTNCCHILDS.Validated
        total()
    End Sub

    Private Sub cmbguestname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBGUESTNAME.Enter
        Try
            If CMBGUESTNAME.Text.Trim = "" Then FILLGUESTNAME(CMBGUESTNAME, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGUESTNAME_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBGUESTNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJGUEST As New SelectGuest
                OBJGUEST.ShowDialog()
                If OBJGUEST.TEMPGUESTNAME <> "" Then CMBGUESTNAME.Text = OBJGUEST.TEMPGUESTNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbguestname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGUESTNAME.Validating
        Try
            If CMBGUESTNAME.Text.Trim <> "" Then GUESTNAMEVALIDATE(CMBGUESTNAME, e, Me, TXTGUESTADD)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PackageEnquiry_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "ELYSIUM" Or ClientName = "PLANET" Or ClientName = "MATRIX" Then Me.Close()
        If ClientName = "RAMKRISHNA" Then
            LBLGROUP.Visible = True
            CMBGROUPDEPARTURE.Visible = True
        End If

        If ClientName <> "AIRTRINITY" Or ClientName <> "BELLA" Then
            CMBCURCODE.Visible = False
            GCURCODE.Visible = False
            TXTROE.Visible = False
            GROE.Visible = False
            TXTTOTAL.Left = Val(TXTTOTAL.Left) - Val(CMBCURCODE.Width) - Val(TXTROE.Width)
            GRIDBOOKINGS.Width = Val(GRIDBOOKINGS.Width) - Val(CMBCURCODE.Width) - Val(TXTROE.Width)
            LBLTOTALAMT.Left = Val(LBLTOTALAMT.Left) - Val(CMBCURCODE.Width) - Val(TXTROE.Width)
            TXTTOTALAMT.Left = TXTTOTAL.Left
        End If

        If ClientName = "TRAVELBRIDGE" Then
            GPTOTAL.Visible = False
            LBLTOTALROOMS.Visible = False
            TXTTOTALROOMS.Visible = False
            LBLTOTALAMT.Visible = False
            TXTTOTALAMT.Visible = False
            CMBPACKAGETYPE.Items.Add("HOTEL")
            GCONFIRMEDBY.HeaderText = "Payment Mode"
            TXTCONFIRMEDBY.BackColor = Color.LemonChiffon
            TXTINCLUSION.BackColor = Color.LemonChiffon
            TXTBADULTS.BackColor = Color.LemonChiffon
            TXTRATE.BackColor = Color.LemonChiffon
            CMBNOTES.BackColor = Color.LemonChiffon
            CMBCANCEL.BackColor = Color.LemonChiffon

        End If

        If ClientName = "KHANNA" Then
            LBLTEMPADULT.Visible = True
            LBLTEMPCNB.Visible = True
            LBLTEMPCWB.Visible = True
            LBLTEMPEXADULT.Visible = True
            LBLTEMPINFANT.Visible = True
            TXTTEMPADULTRATE.Visible = True
            TXTTEMPCNBRATE.Visible = True
            TXTTEMPCWBRATE.Visible = True
            TXTTEMPEXADULTRATE.Visible = True
            TXTTEMPINFANTRATE.Visible = True
        End If

    End Sub

    Private Sub TXTTOURNAME_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXTTOURNAME.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub bookingdate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ENQDATE.Validating
        '    If Not datecheck(ENQDATE.Value) Then
        '        MsgBox("Date Not in Current Accounting Year")
        '        e.Cancel = True
        '    End If
    End Sub

    Private Sub PACKAGEFROM_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles PACKAGEFROM.Validated
        CALDAYS()
    End Sub

    Private Sub PACKAGEFROM_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles PACKAGEFROM.Validating
        If ClientName = "CLASSIC" Then
            If Not datecheck(PACKAGEFROM.Value) Then
                MsgBox("Date Not in Current Accounting Year")
                e.Cancel = True
            End If
        End If
        If edit = False And CMBITINERARY.Text.Trim = "" Then PACKAGETO.Value = DateAdd(DateInterval.Day, 1, PACKAGEFROM.Value)
        CHECKINDATE.Value = PACKAGEFROM.Value.Date
        PICKUPDATE.Value = PACKAGEFROM.Value.Date
    End Sub

    Private Sub PACKAGETO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles PACKAGETO.Validating
        If ClientName = "CLASSIC" Then
            If Not datecheck(PACKAGETO.Value) Then
                MsgBox("Date Not in Current Accounting Year")
                e.Cancel = True
            End If
        End If
        CHECKOUTDATE.Value = PACKAGETO.Value.Date
        DROPDDATE.Value = PACKAGETO.Value.Date
    End Sub

    Private Sub CHECKINDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CHECKINDATE.Validating
        If ClientName = "CLASSIC" Then
            If Not datecheck(CHECKINDATE.Value) Then
                MsgBox("Date Not in Current Accounting Year")
                e.Cancel = True
            End If
            'If edit = False Then CHECKOUTDATE.Value = DateAdd(DateInterval.Day, 1, CHECKINDATE.Value)
        End If
        If edit = False And ClientName <> "TRAVELBRIDGE" Then CHECKOUTDATE.Value = DateAdd(DateInterval.Day, 1, CHECKINDATE.Value)
    End Sub

    Private Sub CHECKOUTDATE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHECKOUTDATE.Validated
        Try
            If CHECKOUTDATE.Value.Date > CHECKINDATE.Value.Date Then
                TXTBTOTALNIGHTS.Text = CHECKOUTDATE.Value.Date.Subtract(CHECKINDATE.Value.Date).Days
                ' total()
                'PURCHASETOTAL()
            ElseIf CHECKOUTDATE.Value.Date = CHECKINDATE.Value.Date And (ClientName = "ELYSIUM" Or ClientName = "ESSGEE") Then
                TXTBTOTALNIGHTS.Text = 1
                'total()
                'PURCHASETOTAL()
            Else
                MsgBox("Select Proper Dates", MsgBoxStyle.Critical)
                CHECKINDATE.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHECKOUTDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CHECKOUTDATE.Validating
        If ClientName = "CLASSIC" Then
            If Not datecheck(CHECKOUTDATE.Value) Then
                MsgBox("Date Not in Current Accounting Year")
                e.Cancel = True
            End If
        End If
    End Sub



    Private Sub CMBNOTES_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNOTES.Enter
        Try
            If CMBNOTES.Text.Trim = "" Then FILLNOTE(CMBNOTES, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNOTES_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNOTES.Validated
        Try
            If CMBNOTES.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" NOTE_REMARKS AS NOTE", "", " NOTEMASTER", " AND NOTE_NAME ='" & CMBNOTES.Text.Trim & "' AND NOTE_CMPID = " & CmpId & " AND NOTE_LOCATIONID = " & Locationid & " AND NOTE_YEARID = " & YearId)
                If DT.Rows.Count > 0 AndAlso TXTNOTES.Text.Trim = "" Then TXTNOTES.Text = DT.Rows(0).Item("NOTE")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNOTES_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNOTES.Validating
        Try
            If CMBNOTES.Text.Trim <> "" Then NOTEVALIDATE(CMBNOTES, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCANCEL_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCANCEL.Enter
        Try
            If CMBCANCEL.Text.Trim = "" Then FILLPOLICY(CMBCANCEL, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCANCEL_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCANCEL.Validated
        Try
            If CMBCANCEL.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" POLICY_REMARKS AS POLICY", "", " POLICYMASTER", " AND POLICY_NAME ='" & CMBCANCEL.Text.Trim & "' AND POLICY_CMPID = " & CmpId & " AND POLICY_LOCATIONID = " & Locationid & " AND POLICY_YEARID = " & YearId)
                If DT.Rows.Count > 0 AndAlso TXTPOLICY.Text.Trim = "" Then TXTPOLICY.Text = DT.Rows(0).Item("POLICY")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCANCEL_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCANCEL.Validating
        Try
            If CMBCANCEL.Text.Trim <> "" Then POLICYvalidate(CMBCANCEL, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCARNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCARNAME.Enter
        Try
            If CMBCARNAME.Text.Trim = "" Then FILLVEHICLE(CMBCARNAME, edit, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCARTYPE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCARTYPE.Enter
        Try
            If CMBCARTYPE.Text.Trim = "" Then FILLVEHICLETYPE(CMBCARTYPE, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCARTYPE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCARTYPE.Validating
        Try
            If CMBCARTYPE.Text.Trim <> "" Then VEHICLETYPEvalidate(CMBCARTYPE, e, Me)
            'CMBCARNAME.Text = ""
            'FILLVEHICLE(CMBCARNAME, edit, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCARSRNO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCARSRNO.GotFocus
        Try
            If GRIDCARDOUBLECLICK = False Then
                If GRIDTRANS.RowCount > 0 Then
                    TXTCARSRNO.Text = Val(GRIDTRANS.Rows(GRIDTRANS.RowCount - 1).Cells(GCARSRNO.Index).Value) + 1
                Else
                    TXTCARSRNO.Text = 1
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRIDCAR()
        Try
            EP.Clear()
            If Not CALDAYS() Then
                Exit Sub
            End If

            If GRIDCARDOUBLECLICK = False Then

                GRIDTRANS.Rows.Add(Val(TXTCARSRNO.Text.Trim), TXTCONTACTPERSON.Text.Trim, TXTCONTACTNO.Text.Trim, CMBCARTYPE.Text.Trim, CMBCARNAME.Text.Trim, Val(TXTCARADULTS.Text.Trim), Val(TXTCARCHILDS.Text.Trim), (Val(TXTCARADULTS.Text.Trim) + Val(TXTCARCHILDS.Text.Trim)), Format(PICKUPDATE.Value.Date, "dd/MM/yyyy"), TXTPICKFROM.Text.Trim, TXTPICKTIME.Text.Trim, TXTPICKDTLS.Text.Trim, Format(DROPDDATE.Value.Date, "dd/MM/yyyy"), TXTDROPAT.Text.Trim, TXTDROPTIME.Text.Trim, TXTDROPDTLS.Text.Trim, Val(TXTCARDAYS.Text.Trim), TXTROUTE.Text.Trim, TXTCARITINERARY.Text.Trim, TXTCARNOTE.Text.Trim, Val(TXTCARAMT.Text.Trim))
                getsrno(GRIDTRANS)

            ElseIf GRIDCARDOUBLECLICK = True Then

                GRIDTRANS.Item(GCARSRNO.Index, TEMPCARROW).Value = TXTCARSRNO.Text.Trim
                GRIDTRANS.Item(GCARCONTACTNAME.Index, TEMPCARROW).Value = TXTCONTACTPERSON.Text.Trim
                GRIDTRANS.Item(GCARCONTACTNO.Index, TEMPCARROW).Value = TXTCONTACTNO.Text.Trim
                GRIDTRANS.Item(GCARTYPE.Index, TEMPCARROW).Value = CMBCARTYPE.Text.Trim
                GRIDTRANS.Item(GCARNAME.Index, TEMPCARROW).Value = CMBCARNAME.Text.Trim
                GRIDTRANS.Item(GCARADULTS.Index, TEMPCARROW).Value = Val(TXTCARADULTS.Text.Trim)
                GRIDTRANS.Item(GCARCHILDS.Index, TEMPCARROW).Value = Val(TXTCARCHILDS.Text.Trim)
                GRIDTRANS.Item(GCARPAX.Index, TEMPCARROW).Value = (Val(TXTCARADULTS.Text.Trim) + Val(TXTCARCHILDS.Text.Trim))
                GRIDTRANS.Item(GCARPICKUP.Index, TEMPCARROW).Value = Format(PICKUPDATE.Value.Date, "dd/MM/yyyy")
                GRIDTRANS.Item(GCARPICKUPFROM.Index, TEMPCARROW).Value = TXTPICKFROM.Text.Trim
                GRIDTRANS.Item(GCARPICKUPTIME.Index, TEMPCARROW).Value = TXTPICKTIME.Text.Trim
                GRIDTRANS.Item(GCARPICKUPDTLS.Index, TEMPCARROW).Value = TXTPICKDTLS.Text.Trim
                GRIDTRANS.Item(GCARDROP.Index, TEMPCARROW).Value = Format(DROPDDATE.Value.Date, "dd/MM/yyyy")
                GRIDTRANS.Item(GCARDROPTO.Index, TEMPCARROW).Value = TXTDROPAT.Text.Trim
                GRIDTRANS.Item(GCARDROPTIME.Index, TEMPCARROW).Value = TXTDROPTIME.Text.Trim
                GRIDTRANS.Item(GCARDROPDTLS.Index, TEMPCARROW).Value = TXTDROPDTLS.Text.Trim
                GRIDTRANS.Item(GCARDAYS.Index, TEMPCARROW).Value = Val(TXTCARDAYS.Text.Trim)
                GRIDTRANS.Item(GCARROUTE.Index, TEMPCARROW).Value = TXTROUTE.Text.Trim
                GRIDTRANS.Item(GCARITINERARY.Index, TEMPCARROW).Value = TXTCARITINERARY.Text.Trim
                GRIDTRANS.Item(GCARNOTE.Index, TEMPCARROW).Value = TXTCARNOTE.Text.Trim
                GRIDTRANS.Item(GCARAMT.Index, TEMPCARROW).Value = Val(TXTCARAMT.Text.Trim)


                GRIDCARDOUBLECLICK = False

            End If
            GRIDTRANS.FirstDisplayedScrollingRowIndex = GRIDTRANS.RowCount - 1


            TXTCARSRNO.Clear()
            TXTCONTACTPERSON.Clear()
            TXTCONTACTNO.Clear()
            CMBCARTYPE.Text = ""
            CMBCARNAME.Text = ""
            TXTCARADULTS.Text = 0.0
            TXTCARCHILDS.Text = 0.0
            PICKUPDATE.Value = Mydate
            TXTPICKFROM.Clear()
            TXTPICKTIME.Clear()
            TXTPICKDTLS.Clear()
            DROPDDATE.Value = Mydate
            TXTDROPAT.Clear()
            TXTDROPTIME.Clear()
            TXTDROPDTLS.Clear()
            TXTCARDAYS.Text = 1
            TXTROUTE.Clear()
            TXTCARITINERARY.Clear()
            TXTCARNOTE.Clear()
            TXTCARAMT.Clear()
            CALDAYS()
            TXTCARSRNO.Focus()


        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTCARAMT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCARAMT.Validating
        Try
            If CMBCARNAME.Text.Trim <> "" And Val(TXTCARADULTS.Text.Trim) > 0 Then
                FILLGRIDCAR()
                total()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical, "TRAVELMATE")
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDTRANS_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDTRANS.CellDoubleClick
        Try
            If GRIDTRANS.Rows(e.RowIndex).Cells(GCARSRNO.Index).Value <> Nothing Then
                GRIDCARDOUBLECLICK = True
                TEMPCARROW = e.RowIndex
                TXTCARSRNO.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARSRNO.Index).Value
                TXTCONTACTPERSON.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARCONTACTNAME.Index).Value
                TXTCONTACTNO.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARCONTACTNO.Index).Value
                CMBCARTYPE.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARTYPE.Index).Value
                CMBCARNAME.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARNAME.Index).Value
                TXTCARADULTS.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARADULTS.Index).Value
                TXTCARCHILDS.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARCHILDS.Index).Value
                PICKUPDATE.Value = GRIDTRANS.Rows(e.RowIndex).Cells(GCARPICKUP.Index).Value
                TXTPICKFROM.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARPICKUPFROM.Index).Value
                TXTPICKTIME.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARPICKUPTIME.Index).Value
                TXTPICKDTLS.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARPICKUPDTLS.Index).Value
                DROPDDATE.Value = GRIDTRANS.Rows(e.RowIndex).Cells(GCARDROP.Index).Value
                TXTDROPAT.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARDROPTO.Index).Value
                TXTDROPTIME.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARDROPTIME.Index).Value
                TXTDROPDTLS.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARDROPDTLS.Index).Value
                TXTROUTE.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARROUTE.Index).Value
                TXTCARITINERARY.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARITINERARY.Index).Value
                TXTCARNOTE.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARNOTE.Index).Value
                TXTCARAMT.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARAMT.Index).Value
                TXTCARSRNO.Focus()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDTRANS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDTRANS.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDTRANS.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDCARDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDTRANS.Rows.RemoveAt(GRIDTRANS.CurrentRow.Index)
                total()
                getsrno(GRIDTRANS)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBCARNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCARNAME.Validating
        Try
            If CMBCARNAME.Text.Trim <> "" Then VEHICLEVALIDATE(CMBCARNAME, e, Me, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DROPDDATE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles DROPDDATE.Validated
        Try
            'CALDAYS()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DROPDDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DROPDDATE.Validating
        If ClientName = "CLASSIC" Then
            If Not datecheck(DROPDDATE.Value) Then
                MsgBox("Date Not in Current Accounting Year")
                e.Cancel = True
            End If
        End If
    End Sub

    Function CALDAYS() As Boolean
        Try
            Dim BLN As Boolean = True

            If CMBHOTELNAME.Text.Trim <> "" And CMBROOMTYPE.Text.Trim <> "" And CMBPLAN.Text.Trim <> "" And Val(TXTNOOFROOMS.Text.Trim) > 0 And Val(TXTRATE.Text.Trim) > 0 And Val(TXTTOTAL.Text.Trim) > 0 And Val(TXTBADULTS.Text) > 0 And CMBPACKAGE.Text.Trim <> "" Then
                If CHECKINDATE.Value.Date < PACKAGEFROM.Value.Date Then
                    BLN = False
                    EP.SetError(PACKAGETO, "Invalid Check In Date")
                End If
                If CHECKOUTDATE.Value.Date > PACKAGETO.Value.Date Then
                    BLN = False
                    EP.SetError(PACKAGETO, "Invalid Check Out Date")
                End If

                If CHECKOUTDATE.Value.Date > CHECKINDATE.Value.Date Then
                    TXTBTOTALNIGHTS.Text = CHECKOUTDATE.Value.Date.Subtract(CHECKINDATE.Value.Date).Days
                ElseIf CHECKOUTDATE.Value.Date = CHECKINDATE.Value.Date And (ClientName = "ELYSIUM" Or ClientName = "ESSGEE") Then
                    TXTBTOTALNIGHTS.Text = 1
                Else
                    Exit Function
                    EP.SetError(PACKAGETO, "Invalid Check In/Check Out Date")
                End If
            End If


            If TXTCONTACTPERSON.Text.Trim <> "" And CMBCARNAME.Text.Trim <> "" And Val(TXTCARADULTS.Text.Trim) > 0 And TXTPICKFROM.Text.Trim <> "" And TXTDROPAT.Text.Trim <> "" And Val(TXTCARAMT.Text.Trim) > 0 Then
                If PICKUPDATE.Value.Date < PACKAGEFROM.Value.Date Then
                    BLN = False
                    EP.SetError(PACKAGETO, "Invalid Pickup Date")
                End If
                If DROPDDATE.Value.Date > PACKAGETO.Value.Date Then
                    BLN = False
                    EP.SetError(PACKAGETO, "Invalid Drop Date")
                End If

                If DROPDDATE.Value.Date >= PICKUPDATE.Value.Date Then
                    TXTCARDAYS.Text = DROPDDATE.Value.Date.Subtract(PICKUPDATE.Value.Date).Days
                ElseIf DROPDDATE.Value.Date = PICKUPDATE.Value.Date And (ClientName = "ELYSIUM" Or ClientName = "ESSGEE") Then
                    TXTCARDAYS.Text = 1
                Else
                    'Exit Function
                    BLN = False
                    EP.SetError(PACKAGETO, "Invalid Drop Date")
                End If
            End If



            If PACKAGETO.Value.Date > PACKAGEFROM.Value.Date Then
                TXTPACKAGEDAYS.Text = PACKAGETO.Value.Date.Subtract(PACKAGEFROM.Value.Date).Days
            ElseIf PACKAGETO.Value.Date = PACKAGEFROM.Value.Date And (ClientName = "ELYSIUM" Or ClientName = "ESSGEE") Then
                TXTPACKAGEDAYS.Text = 1
            Else
                BLN = False
                EP.SetError(PACKAGETO, "Invalid Package Date")
            End If


            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub PICKUPDATE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles PICKUPDATE.Validated
        Try
            'CALDAYS()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PICKUPDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles PICKUPDATE.Validating
        If ClientName = "CLASSIC" Then
            If Not datecheck(PICKUPDATE.Value) Then
                MsgBox("Date Not in Current Accounting Year")
                e.Cancel = True
            End If
        End If
        If edit = False Then DROPDDATE.Value = DateAdd(DateInterval.Day, 1, PICKUPDATE.Value)
    End Sub

    Private Sub TXTBEXTRAADULT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBEXTRAADULT.KeyPress
        numkeypress(e, TXTBEXTRAADULT, Me)
    End Sub

    Private Sub TXTBEXTRAADULT_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTBEXTRAADULT.Validated
        Try
            If Val(TXTRATE.Text.Trim) > 0 And Val(TXTNOOFROOMS.Text.Trim) > 0 Then
                CALC()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBEXTRAADULTRATE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBEXTRAADULTRATE.KeyPress
        numdotkeypress(e, TXTBEXTRAADULTRATE, Me)
    End Sub

    Private Sub TXTBEXTRAADULTRATE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTBEXTRAADULTRATE.Validated
        Try
            If Val(TXTRATE.Text.Trim) > 0 And Val(TXTNOOFROOMS.Text.Trim) > 0 Then
                CALC()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBEXTRACHILD_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBEXTRACHILD.KeyPress
        numkeypress(e, TXTBEXTRACHILD, Me)
    End Sub

    Private Sub TXTBEXTRACHILD_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTBEXTRACHILD.Validated
        Try
            If Val(TXTRATE.Text.Trim) > 0 And Val(TXTNOOFROOMS.Text.Trim) > 0 Then
                CALC()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBEXTRACHILDRATE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBEXTRACHILDRATE.KeyPress
        numdotkeypress(e, TXTBEXTRACHILDRATE, Me)
    End Sub

    Private Sub TXTBEXTRACHILDRATE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTBEXTRACHILDRATE.Validated
        Try
            If Val(TXTRATE.Text.Trim) > 0 And Val(TXTNOOFROOMS.Text.Trim) > 0 Then
                CALC()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPACKAGE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBPACKAGE.Validated
        CALC()
    End Sub

    Private Sub TXTBADULTS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBADULTS.KeyPress
        numkeypress(e, TXTBADULTS, Me)
    End Sub

    Private Sub TXTBCHILDS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBCHILDS.KeyPress
        numkeypress(e, TXTBCHILDS, Me)
    End Sub

    Private Sub TXTBINFANTS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBINFANTS.KeyPress
        numkeypress(e, TXTBINFANTS, Me)
    End Sub

    Sub CALC()
        Try
            TXTBTOTALNIGHTS.Text = DateDiff(DateInterval.Day, CHECKINDATE.Value.Date, CHECKOUTDATE.Value.Date)

            'THIS IS DONE BY GULKIT
            'WHEN WE SELECT PERPAX QUOTE IN ITINERARY THEN CALC IS DIFFERENT, IT IS NOT MULTIPLIED BY ROOMS
            'WHEN WE SELECT LUMPSUM QUOTE IN ITINERARY THEN CALC IS DIFFERENT, IT IS NOT MULTIPLIED BY ROOMS NOR BY PAX
            If CMBQUOTECALC.Text = "Normal" Then
                If CMBPACKAGE.Text.Trim = "No" Then
                    TXTTOTAL.Text = Format((Val(TXTRATE.Text.Trim) * Val(TXTNOOFROOMS.Text.Trim) * Val(TXTBTOTALNIGHTS.Text.Trim)) + (Val(TXTBEXTRAADULT.Text.Trim) * Val(TXTBEXTRAADULTRATE.Text.Trim) * Val(TXTBTOTALNIGHTS.Text.Trim)) + (Val(TXTBEXTRACHILD.Text.Trim) * Val(TXTBEXTRACHILDRATE.Text.Trim) * Val(TXTBTOTALNIGHTS.Text.Trim)), "0.00")
                Else
                    TXTTOTAL.Text = Format((Val(TXTRATE.Text.Trim) * Val(TXTNOOFROOMS.Text.Trim)) + Val(TXTBEXTRAADULTRATE.Text.Trim) + Val(TXTBEXTRACHILDRATE.Text.Trim), "0.00")
                End If
            ElseIf CMBQUOTECALC.Text = "Per Person" Then
                TXTTOTAL.Text = Format((Val(TXTRATE.Text.Trim) * Val(TXTBADULTS.Text.Trim)) + (Val(TXTBEXTRAADULT.Text.Trim) * Val(TXTBEXTRAADULTRATE.Text.Trim)) + (Val(TXTBEXTRACHILD.Text.Trim) * Val(TXTBEXTRACHILDRATE.Text.Trim)) + (Val(TXTBCHILDS.Text.Trim) * Val(TXTCHILDRATE.Text.Trim)) + (Val(TXTBINFANTS.Text.Trim) * Val(TXTINFANTRATE.Text.Trim)), "0.00")
            ElseIf CMBQUOTECALC.Text = "Lump Sum" Then
                TXTTOTAL.Text = Format(Val(TXTRATE.Text.Trim), "0.00")
            End If

            'AIRLINE GRID
            TXTAIRAMT.Text = Format((Val(TXTBASIC.Text.Trim) + Val(TXTPSF.Text.Trim) + Val(TXTGRIDTAX.Text.Trim)), "0.00")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCOPY_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCOPY.Validated
        Try
            If Val(TXTCOPY.Text.Trim) > 0 Then
                If edit = True Then
                    MsgBox("Copy Allowed only in Fresh mode", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If TXTCOPY.Text.Trim <> "" Then
                    TEMPMSG = MsgBox("Wish to Copy Voucher No " & TXTCOPY.Text.Trim & "?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbYes Then

                        TEMPENQNO = TXTCOPY.Text.Trim
                        clear()

                        TXTCOPY.Text = TEMPENQNO
                        TEMPENQNO = 0

                        Dim ALPARAVAL As New ArrayList
                        Dim OBJBOOKING As New ClsHolidayEnquiry()

                        ALPARAVAL.Add(Val(TXTCOPY.Text.Trim))
                        ALPARAVAL.Add(CmpId)
                        ALPARAVAL.Add(Locationid)
                        ALPARAVAL.Add(YearId)

                        OBJBOOKING.alParaval = ALPARAVAL
                        Dim dt As DataTable = OBJBOOKING.SELECTBOOKINGDESC()
                        If dt.Rows.Count > 0 Then
                            For Each dr As DataRow In dt.Rows

                                ENQDATE.Value = Convert.ToDateTime(dr("BOOKINGDATE")).Date
                                txtrefno.Text = dr("REFNO")
                                CMBGUESTNAME.Text = dr("GUESTNAME")
                                CMBNAME.Text = dr("NAME")
                                TXTGUESTADD.Text = dr("GUESTADD")

                                TXTTOURNAME.Text = dr("TOURNAME")
                                PACKAGEFROM.Value = Convert.ToDateTime(dr("PACKAGEFROM")).Date
                                PACKAGETO.Value = Convert.ToDateTime(dr("PACKAGETO")).Date

                                TXTADULTS.Text = dr("ADULTS")
                                TXTCHILDS.Text = dr("CHILDS")
                                TXTNCCHILDS.Text = dr("NCCHILDS")
                                TXTTOTALPAX.Text = dr("TOTALPAX")
                                CMBITINERARY.Text = dr("ITINERARYNAME")
                                CMBGROUPDEPARTURE.Text = dr("GROUPDEPARTURENAME")
                                TXTMISCENQNO.Text = dr("MISCENQNO")

                                CMBPACKAGETYPE.Text = dr("PACKAGETYPE")
                                CMBQUOTECALC.Text = dr("QUOTETYPE")
                                TXTTOTALPURAMT.Text = dr("COSTPRICE")

                                TXTEXTRAADULT.Text = dr("EXTRAADULT")
                                TXTEXTRAADULTRATE.Text = dr("EXTRAADULTRATE")
                                TXTEXTRACHILD.Text = dr("EXTRACHILD")
                                TXTEXTRACHILDRATE.Text = dr("EXTRACHILDRATE")

                                CMBBOOKEDBY.Text = dr("BOOKEDBY")
                                CMBSOURCE.Text = dr("SOURCE")

                                TXTTOTALSALEAMT.Text = dr("TOTALSALEAMT")

                                TXTOURCOMMPER.Text = dr("OURCOMMPER")
                                TXTOURCOMMRS.Text = dr("OURCOMMRS")

                                TXTDISCPER.Text = dr("DISCPER")
                                TXTDISCRS.Text = dr("DISCRS")

                                cmbtax.Text = dr("TAXNAME")
                                txttax.Text = dr("TAXAMT")
                                CMBADDTAX.Text = dr("ADDTAXNAME")
                                TXTADDTAX.Text = dr("ADDTAXAMT")

                                CMBOTHERCHGS.Text = dr("OTHERCHGSNAME")
                                If dr("OTHERCHGS") > 0 Then
                                    txtotherchg.Text = dr("OTHERCHGS")
                                    cmbaddsub.Text = "Add"
                                Else
                                    txtotherchg.Text = dr("OTHERCHGS") * (-1)
                                    cmbaddsub.Text = "Sub."
                                End If

                                txtroundoff.Text = dr("ROUNDOFF")

                                TXTREMARKS.Text = Convert.ToString(dr("REMARKS"))
                                TXTBOOKDESC.Text = Convert.ToString(dr("BOOKINGDESC"))
                                CMBNOTES.Text = Convert.ToString(dr("NOTESNAME"))
                                TXTNOTES.Text = Convert.ToString(dr("NOTES"))
                                CMBCANCEL.Text = Convert.ToString(dr("POLICYNAME"))
                                TXTPOLICY.Text = Convert.ToString(dr("POLICY"))
                                CHKAVL.Checked = Convert.ToBoolean(dr("AVL"))
                                CHKQUOTE.Checked = Convert.ToBoolean(dr("QUOTEPENDING"))

                                'GRIDBOOKINGS.Rows.Add(dr("BOOKINGSRNO").ToString, dr("HOTELNAME"), dr("CONFNO"), dr("CONFBY"), dr("INCLUSIONS"), Format(Convert.ToDateTime(dr("ARRIVAL")).Date, "dd/MM/yyyy"), Format(Convert.ToDateTime(dr("DEPARTURE")).Date, "dd/MM/yyyy"), dr("ROOMTYPE").ToString, dr("PLAN").ToString, dr("BADULTS"), dr("BCHILDS"), dr("BINFANTS"), dr("BEXTRAADULTS"), dr("BEXTRAADULTSRATE"), dr("BEXTRACHILDS"), dr("BEXTRACHILDSRATE"), dr("BTOTALPAX"), dr("NOOFROOMS").ToString, dr("BPACKAGE"), Format(Val(dr("RATE")), "0.00"), Format(Val(dr("CHILDRATE")), "0.00"), Format(Val(dr("INFANTRATE")), "0.00"), dr("CURCODE").ToString, Format(Val(dr("ROE")), "0.00"), Format(Val(dr("amt")), "0.00"), Val(dr("NIGHTS")))
                                GRIDBOOKINGS.Rows.Add(dr("BOOKINGSRNO").ToString, dr("HOTELNAME"), dr("CONFNO"), dr("CONFBY"), dr("INCLUSIONS"), Format(Convert.ToDateTime(dr("ARRIVAL")).Date, "dd/MM/yyyy"), Format(Convert.ToDateTime(dr("DEPARTURE")).Date, "dd/MM/yyyy"), dr("ROOMTYPE").ToString, dr("PLAN").ToString, dr("BADULTS"), dr("BCHILDS"), dr("BINFANTS"), dr("BEXTRAADULTS"), dr("BEXTRACHILDS"), dr("NOOFROOMS").ToString, dr("BPACKAGE"), Format(Val(dr("RATE")), "0.00"), Format(Val(dr("CHILDRATE")), "0.00"), Format(Val(dr("INFANTRATE")), "0.00"), dr("BEXTRAADULTSRATE"), dr("BEXTRACHILDSRATE"), dr("BTOTALPAX"), dr("CURCODE").ToString, Format(Val(dr("ROE")), "0.00"), Format(Val(dr("amt")), "0.00"), Val(dr("NIGHTS")))
                                CMBINCLUSION.Text = Convert.ToString(dr("INCLUSION"))
                                CMBEXCLUSION.Text = Convert.ToString(dr("EXCLUSION"))
                            Next


                            'TOUR DETAILS
                            Dim DTT As DataTable = OBJBOOKING.SELECTBOOKINGTOURDETAILS()
                            If DTT.Rows.Count > 0 Then
                                For Each DRT As DataRow In DTT.Rows
                                    If IsDBNull(DRT("IMGPATH")) = False Then GRIDTOUR.Rows.Add(Val(DRT("SRNO")), DRT("HEADER"), DRT("DETAILS"), Image.FromStream(New IO.MemoryStream(DirectCast(DRT("IMGPATH"), Byte())))) Else GRIDTOUR.Rows.Add(Val(DRT("SRNO")), DRT("HEADER"), DRT("DETAILS"), Nothing)
                                Next
                            End If


                            'TRANS DETAILS
                            Dim DT3 As DataTable = OBJBOOKING.SELECTBOOKINGTRANSDETAILS()
                            If DT3.Rows.Count > 0 Then
                                For Each DR2 As DataRow In DT3.Rows
                                    GRIDTRANS.Rows.Add(DR2("CARSRNO"), DR2("CONTACTPERSON"), DR2("CONTACTNO"), DR2("CARTYPE"), DR2("CARNAME"), Val(DR2("CARADULTS")), Val(DR2("CARCHILDS")), Val(DR2("CARTOTALPAX")), Format(DR2("PICKUPON"), "dd/MM/yyyy"), DR2("PICKUPFROM"), DR2("PICKUPTIME"), DR2("PICKUPDTLS"), Format(DR2("DROPON"), "dd/MM/yyyy"), DR2("DROPAT"), DR2("DROPTIME"), DR2("DROPDTLS"), Val(DR2("CARDAYS")), DR2("ROUTE"), DR2("CARITINERARY"), DR2("CARNOTE"), Format(Val(DR2("CARAMT")), "0.00"))
                                Next
                            End If

                            'FOLLOWUP GRID
                            Dim OBJCMN As New ClsCommon
                            Dim DTF As DataTable = OBJCMN.search("  HOLIDAYENQMASTER_FOLLOWUP.ENQ_CHK AS FCHK, ISNULL(HOLIDAYENQMASTER_FOLLOWUP.ENQ_NO, '') AS FOLLOWUPNO, ISNULL(HOLIDAYENQMASTER_FOLLOWUP.ENQ_SRNO, 0) AS SRNO, ISNULL(HOLIDAYENQMASTER_FOLLOWUP.ENQ_DATE, '') AS FOLLOWUPDATE, ISNULL(BOOKEDBYMASTER.BOOKEDBY_NAME, '') AS GIVENBY, ISNULL(HOLIDAYENQMASTER_FOLLOWUP.ENQ_GIVENTO, '') AS GIVENTO, ISNULL(STAGEMASTER.STAGE_NAME, '') AS STAGE, ISNULL(HOLIDAYENQMASTER_FOLLOWUP.ENQ_NEXTDATE, '') AS NEXTDATE, ISNULL(HOLIDAYENQMASTER_FOLLOWUP.ENQ_NARRATION, '') AS NARR", "", " HOLIDAYENQMASTER_FOLLOWUP INNER JOIN BOOKEDBYMASTER ON HOLIDAYENQMASTER_FOLLOWUP.ENQ_GIVENBYID = BOOKEDBYMASTER.BOOKEDBY_ID INNER JOIN STAGEMASTER ON HOLIDAYENQMASTER_FOLLOWUP.ENQ_STAGEID = STAGEMASTER.STAGE_ID", " AND ENQ_NO = " & Val(TXTCOPY.Text.Trim) & " AND ENQ_YEARID = " & YearId & " ORDER BY ENQ_SRNO")
                            If DTF.Rows.Count > 0 Then
                                For Each DTFOLLOW As DataRow In DTF.Rows
                                    GRIDFOLLOW.Rows.Add(DTFOLLOW("FCHK"), DTFOLLOW("SRNO"), Format(Convert.ToDateTime(DTFOLLOW("FOLLOWUPDATE")).Date, "dd/MM/yyyy"), DTFOLLOW("GIVENBY"), DTFOLLOW("GIVENTO"), DTFOLLOW("STAGE"), DTFOLLOW("NEXTDATE"), DTFOLLOW("NARR"))
                                    If Convert.ToBoolean(DTFOLLOW("FCHK")) = True Then GRIDFOLLOW.Rows(GRIDFOLLOW.RowCount - 1).DefaultCellStyle.BackColor = Color.LightGreen
                                Next
                            End If

                            'MISC GRID
                            Dim OBJMISC As New ClsCommon
                            Dim DTM As DataTable = OBJMISC.search(" ISNULL(HOLIDAYENQMASTER_MISC.ENQ_SRNO, 0) AS SRNO, ISNULL(HOLIDAYENQMASTER_MISC.ENQ_TYPE, '') AS TYPE, ISNULL(HOLIDAYENQMASTER_MISC.ENQ_REMARKS, '') AS REMARKS ", "", " HOLIDAYENQMASTER INNER JOIN HOLIDAYENQMASTER_MISC ON HOLIDAYENQMASTER.ENQ_NO = HOLIDAYENQMASTER_MISC.ENQ_NO AND HOLIDAYENQMASTER.ENQ_YEARID = HOLIDAYENQMASTER_MISC.ENQ_YEARID ", " AND HOLIDAYENQMASTER_MISC.ENQ_NO = " & Val(TXTCOPY.Text.Trim) & " AND HOLIDAYENQMASTER_MISC.ENQ_YEARID = " & YearId & " ORDER BY HOLIDAYENQMASTER_MISC.ENQ_SRNO ")
                            If DTM.Rows.Count > 0 Then
                                For Each DR As DataRow In DTM.Rows
                                    GRIDMISC.Rows.Add(Val(DR("SRNO")), DR("TYPE"), DR("REMARKS"))
                                Next
                            End If


                            'GET AIRLINE DATA
                            Dim OBJAIR1 As New ClsCommon
                            Dim DTA1 As DataTable = OBJAIR1.search(" ISNULL(ENQ_NO, 0) AS GROUPDEPNO, ISNULL(ENQ_GRIDSRNO, 0) AS AIRSRNO, ISNULL(ENQ_SECTOR, '') AS SECTOR, ISNULL(ENQ_FLTNO, '') AS FLTNO, ISNULL(ENQ_TYPE, '') AS TYPE, ISNULL(ENQ_BASIC, 0) AS BASIC, ISNULL(ENQ_PSF, 0) AS PSF, ISNULL(ENQ_TAXES, 0) AS TAXES, ISNULL(ENQ_AMT, 0) AS AIRAMT ", "", " HOLIDAYENQMASTER_AIRLINE ", " AND HOLIDAYENQMASTER_AIRLINE.ENQ_NO = " & Val(TXTCOPY.Text.Trim) & " AND ENQ_YEARID = " & YearId & " ORDER BY HOLIDAYENQMASTER_AIRLINE.ENQ_GRIDSRNO")
                            If DTA1.Rows.Count > 0 Then
                                For Each DR1 As DataRow In DTA1.Rows
                                    GRIDAIRLINE.Rows.Add(DR1("AIRSRNO"), DR1("SECTOR"), DR1("FLTNO"), DR1("TYPE"), Format(Val(DR1("BASIC")), "0.00"), Format(Val(DR1("PSF")), "0.00"), Format(Val(DR1("TAXES")), "0.00"), Format(Val(DR1("AIRAMT")), "0.00"))
                                Next
                                'total()
                            End If


                            'GET GRIDFLIGHT DATA
                            Dim OBJAIR2 As New ClsCommon
                            Dim DTA2 As DataTable = OBJCMN.search(" HOLIDAYENQMASTER_FLIGHTDESC.ENQ_GRIDSRNO AS GRIDSRNO, HOLIDAYENQMASTER_FLIGHTDESC.ENQ_BOOKSRNO AS BOOKSRNO, ISNULL(FROMSECTORMASTER.SECTOR_NAME, '') AS FROMSEC, ISNULL(TOSECTORMASTER.SECTOR_NAME, '') AS TOSEC, HOLIDAYENQMASTER_FLIGHTDESC.ENQ_FLIGHTNO AS FLIGHTNO, HOLIDAYENQMASTER_FLIGHTDESC.ENQ_FLIGHTDATE AS FLIGHTDATE, ISNULL(HOLIDAYENQMASTER_FLIGHTDESC.ENQ_ARRIVES, '') AS ARRIVES, CLASSMASTER.CLASS_NAME AS CLASS", "", " SECTORMASTER AS TOSECTORMASTER RIGHT OUTER JOIN HOLIDAYENQMASTER_FLIGHTDESC LEFT OUTER JOIN CLASSMASTER ON HOLIDAYENQMASTER_FLIGHTDESC.ENQ_YEARID = CLASSMASTER.CLASS_YEARID AND  HOLIDAYENQMASTER_FLIGHTDESC.ENQ_CMPID = CLASSMASTER.CLASS_CMPID AND HOLIDAYENQMASTER_FLIGHTDESC.ENQ_CLASSID = CLASSMASTER.CLASS_ID ON  TOSECTORMASTER.SECTOR_ID = HOLIDAYENQMASTER_FLIGHTDESC.ENQ_TOID AND TOSECTORMASTER.SECTOR_CMPID = HOLIDAYENQMASTER_FLIGHTDESC.ENQ_CMPID AND TOSECTORMASTER.SECTOR_YEARID = HOLIDAYENQMASTER_FLIGHTDESC.ENQ_YEARID LEFT OUTER JOIN SECTORMASTER AS FROMSECTORMASTER ON HOLIDAYENQMASTER_FLIGHTDESC.ENQ_FROMID = FROMSECTORMASTER.SECTOR_ID AND HOLIDAYENQMASTER_FLIGHTDESC.ENQ_CMPID = FROMSECTORMASTER.SECTOR_CMPID AND HOLIDAYENQMASTER_FLIGHTDESC.ENQ_YEARID = FROMSECTORMASTER.SECTOR_YEARID", " AND HOLIDAYENQMASTER_FLIGHTDESC.ENQ_NO = " & Val(TXTCOPY.Text.Trim) & " AND HOLIDAYENQMASTER_FLIGHTDESC.ENQ_CMPID = " & CmpId & " AND HOLIDAYENQMASTER_FLIGHTDESC.ENQ_YEARID = " & YearId & " ORDER BY HOLIDAYENQMASTER_FLIGHTDESC.ENQ_BOOKSRNO ASC, HOLIDAYENQMASTER_FLIGHTDESC.ENQ_GRIDSRNO ASC")
                            If dt.Rows.Count > 0 Then
                                For Each DR2 As DataRow In DTA2.Rows
                                    GRIDFLIGHT.Rows.Add(DR2("GRIDSRNO").ToString, DR2("BOOKSRNO"), DR2("FROMSEC").ToString, DR2("TOSEC").ToString, DR2("FLIGHTNO").ToString, DR2("FLIGHTDATE").ToString, DR2("ARRIVES").ToString, DR2("CLASS").ToString)
                                Next
                                'total()
                            End If

                            'GRID PURCHASE
                            Dim OBJPUR As New ClsCommon
                            Dim DTP As DataTable = OBJPUR.search(" ISNULL(HOLIDAYENQMASTER_PURCHASE.ENQ_SRNO, 0) AS SRNO, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(HOLIDAYENQMASTER_PURCHASE.ENQ_AMOUNT, 0) AS AMOUNT, ISNULL(CURRENCYMASTER.CUR_CODE,'') AS CURCODE, ISNULL(ENQ_ROE,0) AS ROE, ISNULL(HOLIDAYENQMASTER_PURCHASE.ENQ_REMARKS, '') AS REMARKS ", "", " HOLIDAYENQMASTER INNER JOIN HOLIDAYENQMASTER_PURCHASE ON HOLIDAYENQMASTER.ENQ_NO = HOLIDAYENQMASTER_PURCHASE.ENQ_NO AND HOLIDAYENQMASTER.ENQ_YEARID = HOLIDAYENQMASTER_PURCHASE.ENQ_YEARID INNER JOIN LEDGERS ON HOLIDAYENQMASTER_PURCHASE.ENQ_NAMEID = LEDGERS.Acc_id LEFT OUTER JOIN CURRENCYMASTER ON CUR_ID = ENQ_CURID ", " AND HOLIDAYENQMASTER_PURCHASE.ENQ_NO = " & Val(TXTCOPY.Text.Trim) & " AND HOLIDAYENQMASTER_PURCHASE.ENQ_YEARID = " & YearId & " ORDER BY HOLIDAYENQMASTER_PURCHASE.ENQ_SRNO ")
                            If DTP.Rows.Count > 0 Then
                                For Each DP1 As DataRow In DTP.Rows
                                    GRIDPURCHASE.Rows.Add(DP1("SRNO"), DP1("NAME").ToString, Format(Val(DP1("AMOUNT")), "0.00"), DP1("CURCODE"), Val(DP1("ROE")), DP1("REMARKS").ToString)
                                Next
                            End If

                            total()
                            chkchange.CheckState = CheckState.Checked
                            GRIDBOOKINGS.FirstDisplayedScrollingRowIndex = GRIDBOOKINGS.RowCount - 1

                        Else
                            'IF ROWCOUNT = 0
                            clear()
                            edit = False
                            ENQDATE.Focus()
                        End If

                    Else
                        MsgBox("Invalid Voucher No.", MsgBoxStyle.Critical)
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUP_SECONDARY = 'SUNDRY DEBTORS'")
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
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'"
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
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBACCCODE, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'", "SUNDRY DEBTORS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCLOSE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLOSE.Click
        Try
            If edit = True Then

                If (edit = True And USEREDIT = False And USERVIEW = False) Or (edit = False And USERADD = False) Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                TEMPMSG = MsgBox("Wish to Close Enquiry ?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    TEMPMSG = MsgBox("Are you Sure?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbYes Then

                        Dim obj As New ClsCommon
                        Dim dt As DataTable = obj.Execute_Any_String(" UPDATE HOLIDAYENQMASTER SET ENQ_CLOSE=1 WHERE ENQ_NO=" & TEMPENQNO & " AND ENQ_YEARID=" & YearId & "", "", "")
                        MsgBox(" Enquiry No- " & TEMPENQNO & " Closed")
                        clear()
                        edit = False
                    End If
                End If
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBGROUPDEPARTURE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBGROUPDEPARTURE.Enter
        Try
            If CMBGROUPDEPARTURE.Text.Trim = "" Then FILLGROUPNAME(CMBGROUPDEPARTURE, " AND GROUPDEP_FROM > '" & Format(ENQDATE.Value.Date, "MM/dd/yyyy") & "'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGROUPDEPARTURE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGROUPDEPARTURE.Validating
        Try
            If CMBGROUPDEPARTURE.Text.Trim <> "" Then GROUPNAMEVALIDATE(CMBGROUPDEPARTURE, e, Me, " AND GROUPDEP_FROM > '" & Format(ENQDATE.Value.Date, "MM/dd/yyyy") & "'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGROUPDEPARTURE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBGROUPDEPARTURE.Validated
        Try
            If CMBGROUPDEPARTURE.Text.Trim <> "" And edit = False Then
                Dim TEMPGROUPNO As Integer

                'GET DATA FROM GROUP DEPARTURE
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" GROUPDEPARTURE.GROUPDEP_NO AS GROUPNO,  GROUPDEPARTURE.GROUPDEP_FROM AS FROMDATE, GROUPDEPARTURE.GROUPDEP_TO AS TODATE,  ISNULL(GROUPDEPARTURE_DESC.GROUPDEP_SRNO, 0) AS SRNO, ISNULL(HOTELMASTER.HOTEL_NAME, '') AS HOTELNAME, ISNULL(GROUPDEPARTURE_DESC.GROUPDEP_INCLUSIONS, '') AS INCLUSIONS, ISNULL(GROUPDEPARTURE_DESC.GROUPDEP_CHECKIN, '') AS CHECKIN, ISNULL(GROUPDEPARTURE_DESC.GROUPDEP_CHECKOUT, '') AS CHECKOUT, ISNULL(ROOMTYPEMASTER.ROOMTYPE_NAME, '') AS ROOMTYPE, ISNULL(PLANMASTER.PLAN_NAME, '') AS PLANNAME, ISNULL(GROUPDEPARTURE_DESC.GROUPDEP_NOOFROOMS, 0) AS NOOFROOMS,                       ISNULL(GROUPDEPARTURE_DESC.GROUPDEP_PACKAGE, '') AS PACKAGE, ISNULL(GROUPDEPARTURE_DESC.GROUPDEP_RATE, 0) AS RATE, ISNULL(GROUPDEPARTURE_DESC.GROUPDEP_AMOUNT, 0) AS AMOUNT, ISNULL(GROUPDEPARTURE_DESC.GROUPDEP_NIGHTS, 0) AS NIGHTS  ", "", " PLANMASTER INNER JOIN GROUPDEPARTURE INNER JOIN GROUPDEPARTURE_DESC ON GROUPDEPARTURE.GROUPDEP_NO = GROUPDEPARTURE_DESC.GROUPDEP_NO AND GROUPDEPARTURE.GROUPDEP_YEARID = GROUPDEPARTURE_DESC.GROUPDEP_YEARID INNER JOIN HOTELMASTER ON GROUPDEPARTURE_DESC.GROUPDEP_HOTELID = HOTELMASTER.HOTEL_ID INNER JOIN ROOMTYPEMASTER ON GROUPDEPARTURE_DESC.GROUPDEP_ROOMTYPEID = ROOMTYPEMASTER.ROOMTYPE_ID ON PLANMASTER.PLAN_ID = GROUPDEPARTURE_DESC.GROUPDEP_PLANID  ", "  AND GROUPDEPARTURE.GROUPDEP_NAME = '" & CMBGROUPDEPARTURE.Text.Trim & "' AND GROUPDEPARTURE.GROUPDEP_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    TXTTOURNAME.Text = CMBGROUPDEPARTURE.Text.Trim
                    TEMPGROUPNO = DT.Rows(0).Item("GROUPNO")
                    PACKAGEFROM.Value = DT.Rows(0).Item("FROMDATE")
                    PACKAGETO.Value = DT.Rows(0).Item("TODATE")
                    For Each ROW As DataRow In DT.Rows
                        'GRIDBOOKINGS.Rows.Add(Val(ROW("SRNO")), ROW("HOTELNAME"), "", "", ROW("INCLUSIONS"), Format(Convert.ToDateTime(ROW("CHECKIN").DATE), "dd/MM/yyyy"), Format(Convert.ToDateTime(ROW("CHECKOUT").DATE), "dd/MM/yyyy"), ROW("ROOMTYPE"), ROW("PLANNAME"), Val(TXTADULTS.Text.Trim), Val(TXTCHILDS.Text.Trim), Val(TXTNCCHILDS.Text.Trim), 0, 0, 0, 0, Val(TXTTOTALPAX.Text.Trim), Val(ROW("NOOFROOMS")), ROW("PACKAGE"), Format(Val(ROW("RATE")), "0.00"), 0, 0, "", 0, Format(Val(ROW("AMOUNT")), "0.00"), Val(ROW("NIGHTS")))
                        GRIDBOOKINGS.Rows.Add(Val(ROW("SRNO")), ROW("HOTELNAME"), "", "", ROW("INCLUSIONS"), Format(Convert.ToDateTime(ROW("CHECKIN").DATE), "dd/MM/yyyy"), Format(Convert.ToDateTime(ROW("CHECKOUT").DATE), "dd/MM/yyyy"), ROW("ROOMTYPE"), ROW("PLANNAME"), Val(TXTADULTS.Text.Trim), Val(TXTCHILDS.Text.Trim), Val(TXTNCCHILDS.Text.Trim), 0, 0, Val(ROW("NOOFROOMS")), ROW("PACKAGE"), Format(Val(ROW("RATE")), "0.00"), 0, 0, 0, 0, Val(TXTTOTALPAX.Text.Trim), "", 0, Format(Val(ROW("AMOUNT")), "0.00"), Val(ROW("NIGHTS")))

                    Next
                End If


                DT = OBJCMN.search(" ISNULL(GROUPDEP_NO, 0) AS GROUPDEPNO, ISNULL(GROUPDEP_SRNO, 0) AS TOURSRNO, GROUPDEP_TOURDATE AS TOURDATE, ISNULL(GROUPDEP_TOURDETAILS, '') AS TOURDETAILS", "", " GROUPDEPARTURE_TOURDETAILS ", " AND GROUPDEPARTURE_TOURDETAILS.GROUPDEP_NO = " & TEMPGROUPNO & " AND GROUPDEP_YEARID = " & YearId & " ORDER BY GROUPDEPARTURE_TOURDETAILS.GROUPDEP_SRNO")
                If DT.Rows.Count > 0 Then
                    For Each DTR As DataRow In DT.Rows
                        GRIDTOUR.Rows.Add(DTR("TOURSRNO"), Format(Convert.ToDateTime(DTR("TOURDATE").DATE), "dd/MM/yyyy"), DTR("TOURDETAILS"))
                    Next
                End If


                'TRANSPORT GRID
                DT = OBJCMN.search(" ISNULL(VEHICLETYPE_NAME,'') AS VEHICLETYPE, ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_NO, 0) AS GROUPDEPNO, ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_SRNO, 0) AS SRNO, ISNULL(VEHICLEMASTER.VEHICLE_NAME, '') AS VEHICLE, GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_PICKUPON AS PICKUPON,ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_PICKUPFROM, '') AS PICKUPFROM ,ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_PICKUPTIME, '') AS PICKUPTIME, ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_PICKUPDTLS, '') AS PICKUPDTLS, GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_DROPON AS DROPON, ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_DROPAT, '') AS DROPAT, ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_DROPTIME, '') AS DROPTIME, ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_DROPDTLS, '') AS DROPDTLS, ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_CARDAYS, 0) AS CARDAYS, ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_NOTE, '') AS NOTE, ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_AMT, 0) AS AMOUNT ", "", " GROUPDEPARTURE_TRANSDETAILS INNER JOIN VEHICLEMASTER ON GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_VEHICLEID = VEHICLEMASTER.VEHICLE_ID LEFT OUTER JOIN VEHICLETYPEMASTER ON VEHICLE_TYPEID = VEHICLETYPE_ID ", " AND GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_NO = " & TEMPGROUPNO & " AND GROUPDEP_YEARID = " & YearId & " ORDER BY GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_SRNO")
                If DT.Rows.Count > 0 Then
                    For Each DTR As DataRow In DT.Rows
                        GRIDTRANS.Rows.Add(DTR("SRNO"), "", "", DTR("VEHICLETYPE"), DTR("VEHICLE"), Val(TXTADULTS.Text.Trim), Val(TXTCHILDS.Text.Trim), Val(TXTTOTALPAX.Text.Trim), Format(Convert.ToDateTime(DTR("PICKUPON").DATE), "dd/MM/yyyy"), DTR("PICKUPFROM"), DTR("PICKUPTIME"), DTR("PICKUPDTLS"), Format(Convert.ToDateTime(DTR("DROPON").DATE), "dd/MM/yyyy"), DTR("DROPAT"), DTR("DROPTIME"), DTR("DROPDTLS"), Val(DTR("CARDAYS")), "", "", DTR("NOTE"), Format(Val(DTR("AMOUNT")), "0.00"))
                    Next
                End If



                TBMISC.SelectedIndex = 1
                total()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFOLLOWUPBY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBFOLLOWUPBY.Enter
        Try
            If CMBFOLLOWUPBY.Text.Trim = "" Then FILLBOOKEDBY(CMBFOLLOWUPBY, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFOLLOWUPBY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBFOLLOWUPBY.Validating
        Try
            If CMBFOLLOWUPBY.Text.Trim <> "" Then BOOKEDBYvalidate(CMBFOLLOWUPBY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSTAGE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBSTAGE.Enter
        Try
            If CMBSTAGE.Text.Trim = "" Then FILLSTAGE(CMBSTAGE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DTFOLLOWDATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DTFOLLOWDATE.Validating
        Try
            If DTFOLLOWDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(DTFOLLOWDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DTNEXTDATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DTNEXTDATE.Validating
        Try
            If DTNEXTDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(DTNEXTDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTFNARR_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTFNARR.Validating
        Try
            If DTFOLLOWDATE.Text.Trim <> "" And CMBFOLLOWUPBY.Text.Trim <> "" And TXTFOLLOWTO.Text.Trim <> "" And CMBSTAGE.Text.Trim <> "" Then
                FILLFOLLOWUP()
            Else
                MsgBox("Enter Proper Details")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLFOLLOWUP()

        If GRIDFOLLOWDOUBLECLICK = False Then
            GRIDFOLLOW.Rows.Add(0, Val(TXTFSRNO.Text.Trim), DTFOLLOWDATE.Text, CMBFOLLOWUPBY.Text.Trim, TXTFOLLOWTO.Text.Trim, CMBSTAGE.Text.Trim, DTNEXTDATE.Text, TXTFNARR.Text.Trim)
            getsrno(GRIDFOLLOW)

        ElseIf GRIDFOLLOWDOUBLECLICK = True Then

            GRIDFOLLOW.Item(GFSRNO.Index, TEMPFOLLOWROW).Value = TXTFSRNO.Text.Trim
            GRIDFOLLOW.Item(GFDATE.Index, TEMPFOLLOWROW).Value = DTFOLLOWDATE.Text
            GRIDFOLLOW.Item(GFNAME.Index, TEMPFOLLOWROW).Value = CMBFOLLOWUPBY.Text.Trim
            GRIDFOLLOW.Item(GFOLLOWTO.Index, TEMPFOLLOWROW).Value = TXTFOLLOWTO.Text.Trim
            GRIDFOLLOW.Item(GFSTAGE.Index, TEMPFOLLOWROW).Value = CMBSTAGE.Text.Trim
            GRIDFOLLOW.Item(GFNEXTDATE.Index, TEMPFOLLOWROW).Value = DTNEXTDATE.Text
            GRIDFOLLOW.Item(GFNARR.Index, TEMPFOLLOWROW).Value = TXTFNARR.Text.Trim

            GRIDFOLLOWDOUBLECLICK = False


        End If
        GRIDFOLLOW.FirstDisplayedScrollingRowIndex = GRIDFOLLOW.RowCount - 1

        'If GRIDFOLLOWDOUBLECLICK = False Or (GRIDFOLLOWDOUBLECLICK = True And TEMPFOLLOWROW = GRIDFOLLOW.RowCount - 1) Then
        '    'GET CLOSING %
        '    Dim OBJCMN As New ClsCommon
        '    Dim DT As DataTable = OBJCMN.search(" STAGE_CLOSING AS CLOSING", "", " STAGEMASTER ", " AND STAGE_NAME = '" & CMBSTAGE.Text.Trim & "'")
        '    'If DT.Rows.Count > 0 Then TXTCLOSING.Text = Val(DT.Rows(0).Item(0))
        'End If


        TXTFSRNO.Text = GRIDFOLLOW.RowCount + 1
        DTFOLLOWDATE.Clear()
        CMBFOLLOWUPBY.Text = ""
        TXTFOLLOWTO.Clear()
        CMBSTAGE.Text = ""
        DTNEXTDATE.Clear()
        TXTFNARR.Clear()

        DTFOLLOWDATE.Focus()

    End Sub

    Private Sub GRIDFOLLOW_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDFOLLOW.CellDoubleClick
        Try
            If e.RowIndex = -1 Then Exit Sub

            If e.RowIndex >= 0 And GRIDFOLLOW.Item(GFSRNO.Index, e.RowIndex).Value <> Nothing Then

                GRIDFOLLOWDOUBLECLICK = True
                TXTFSRNO.Text = GRIDFOLLOW.Item(GFSRNO.Index, e.RowIndex).Value
                DTFOLLOWDATE.Text = GRIDFOLLOW.Item(GFDATE.Index, e.RowIndex).Value
                CMBFOLLOWUPBY.Text = GRIDFOLLOW.Item(GFNAME.Index, e.RowIndex).Value
                TXTFOLLOWTO.Text = GRIDFOLLOW.Item(GFOLLOWTO.Index, e.RowIndex).Value
                CMBSTAGE.Text = GRIDFOLLOW.Item(GFSTAGE.Index, e.RowIndex).Value
                DTNEXTDATE.Text = GRIDFOLLOW.Item(GFNEXTDATE.Index, e.RowIndex).Value
                TXTFNARR.Text = GRIDFOLLOW.Item(GFNARR.Index, e.RowIndex).Value


                TEMPFOLLOWROW = e.RowIndex
                DTFOLLOWDATE.Focus()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDFOLLOW_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDFOLLOW.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDFOLLOW.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                If GRIDFOLLOWDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDFOLLOW.Rows.RemoveAt(GRIDFOLLOW.CurrentRow.Index)
                getsrno(GRIDFOLLOW)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTMISCENQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTMISCENQ.Click
        Try
            If edit = True Then
                MsgBox("Not allowed in Edit Mode", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Cursor.Current = Cursors.WaitCursor

            Dim OBJHOTELENQ As New SelectMiscEnquiry
            OBJHOTELENQ.FRMSTRING = CMBPACKAGETYPE.Text
            OBJHOTELENQ.ShowDialog()
            If OBJHOTELENQ.DT.Rows.Count > 0 Then
                TXTMISCENQNO.Text = (OBJHOTELENQ.DT.Rows(0).Item("MISCNO"))

                'GET OTHER DETAILS AS WELL
                Dim dttable As New DataTable
                Dim OBJFOREXENQ As New ClsMiscEnquiry

                OBJFOREXENQ.alParaval.Add(OBJHOTELENQ.DT.Rows(0).Item("MISCNO"))
                OBJFOREXENQ.alParaval.Add(YearId)
                dttable = OBJFOREXENQ.SELECTMISCENQ()
                If dttable.Rows.Count > 0 Then
                    CMBGUESTNAME.Text = dttable.Rows(0).Item("GUESTNAME").ToString
                    CMBSOURCE.Text = dttable.Rows(0).Item("SOURCE").ToString
                    CMBBOOKEDBY.Text = dttable.Rows(0).Item("BOOKEDBY").ToString
                    If dttable.Rows(0).Item("CHECKIN") <> "" Then PACKAGEFROM.Value = Convert.ToDateTime(dttable.Rows(0).Item("CHECKIN")).Date
                    If dttable.Rows(0).Item("CHECKIN") <> "" Then CHECKINDATE.Value = Convert.ToDateTime(dttable.Rows(0).Item("CHECKIN")).Date
                    If dttable.Rows(0).Item("CHECKIN") <> "" Then PICKUPDATE.Value = Convert.ToDateTime(dttable.Rows(0).Item("CHECKIN")).Date
                    If dttable.Rows(0).Item("CHECKOUT") <> "" Then PACKAGETO.Value = Convert.ToDateTime(dttable.Rows(0).Item("CHECKOUT")).Date
                    If dttable.Rows(0).Item("CHECKOUT") <> "" Then CHECKOUTDATE.Value = Convert.ToDateTime(dttable.Rows(0).Item("CHECKOUT")).Date
                    If dttable.Rows(0).Item("CHECKOUT") <> "" Then DROPDDATE.Value = Convert.ToDateTime(dttable.Rows(0).Item("CHECKOUT")).Date
                    TXTADD.Text = dttable.Rows(0).Item("ADDRESS").ToString
                    TXTADULTS.Text = Val(dttable.Rows(0).Item("ADULTS"))
                    TXTCHILDS.Text = Val(dttable.Rows(0).Item("CHILD"))
                    TXTNCCHILDS.Text = Val(dttable.Rows(0).Item("INFANTS"))
                    TXTEXTRACHILD.Text = Val(dttable.Rows(0).Item("CHILDWITHOUTBED"))
                    TXTEXTRAADULT.Text = Val(dttable.Rows(0).Item("EXTRAADULTS"))
                    TXTBEXTRACHILD.Text = Val(dttable.Rows(0).Item("CHILDWITHOUTBED"))
                    TXTBEXTRAADULT.Text = Val(dttable.Rows(0).Item("EXTRAADULTS"))
                    TXTNOOFROOMS.Text = Val(dttable.Rows(0).Item("ROOMS"))
                    total()
                End If
            End If

            CMBGUESTNAME.Focus()

        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub GRIDMISC_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDMISC.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDMISC.Item(GMISCSRNO.Index, e.RowIndex).Value <> Nothing Then

                GRIDMISCDOUBLECLICK = True
                TXTMISCSRNO.Text = GRIDMISC.Item(GMISCSRNO.Index, e.RowIndex).Value.ToString
                TXTMISCSERVICETYPE.Text = GRIDMISC.Item(GMISCSERVICETYPE.Index, e.RowIndex).Value.ToString
                TXTMISCREMARKS.Text = GRIDMISC.Item(GMISCREMARKS.Index, e.RowIndex).Value.ToString
                TXTMISCAMT.Text = GRIDMISC.Item(GMISCAMOUNT.Index, e.RowIndex).Value.ToString

                TEMPMISCROW = e.RowIndex
                TXTMISCSERVICETYPE.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDMISC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDMISC.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDMISC.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDMISCDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDMISC.Rows.RemoveAt(GRIDMISC.CurrentRow.Index)
                getsrno(GRIDMISC)

            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDAIRLINE_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDAIRLINE.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDAIRLINE.Item(GAIRSRNO.Index, e.RowIndex).Value <> Nothing Then

                GRIDAIRDOUBLECLICK = True
                TXTAIRSRNO.Text = GRIDAIRLINE.Item(GAIRSRNO.Index, e.RowIndex).Value.ToString
                TXTSECTOR.Text = GRIDAIRLINE.Item(GSECTOR.Index, e.RowIndex).Value.ToString
                TXTFLTNO.Text = GRIDAIRLINE.Item(GFLTNO.Index, e.RowIndex).Value.ToString
                CMBTYPE.Text = GRIDAIRLINE.Item(GTYPE.Index, e.RowIndex).Value.ToString
                TXTBASIC.Text = GRIDAIRLINE.Item(GBASIC.Index, e.RowIndex).Value.ToString
                TXTPSF.Text = GRIDAIRLINE.Item(GPSF.Index, e.RowIndex).Value.ToString
                TXTGRIDTAX.Text = GRIDAIRLINE.Item(GTAXES.Index, e.RowIndex).Value.ToString
                TXTAIRAMT.Text = GRIDAIRLINE.Item(GTOTAL.Index, e.RowIndex).Value.ToString
                tempFLIGHTrow = e.RowIndex
                FILLGRIDSECTOR()
                TXTSECTOR.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDAIRLINE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDAIRLINE.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDAIRLINE.RowCount > 0 Then


                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDAIRDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                Dim TINDEX As Integer = GRIDAIRLINE.CurrentRow.Index

                For Each ROW As DataGridViewRow In GRIDFLIGHT.Rows
                    If ROW.Cells(GBOOKSRNO.Index).Value = TINDEX Then GRIDFLIGHT.Rows.RemoveAt(ROW.Index)
                    If ROW.Cells(GBOOKSRNO.Index).Value > TINDEX Then ROW.Cells(GBOOKSRNO.Index).Value = ROW.Cells(GBOOKSRNO.Index).Value - 1
                Next

                GRIDAIRLINE.Rows.RemoveAt(TINDEX)
                getsrno(GRIDAIRLINE)

            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub FILLGRIDSECTOR()
        Try
            Dim FROMSECNAME As String = ""
            Dim TOSECNAME As String = ""
            Dim STARTPOS As Integer = 0
            Dim J As Integer = 1
            TXTTEMPSECTOR.Clear()
            GRIDSECTOR.RowCount = 0
LINE1:
            For I As Integer = 0 To 6
                FROMSECNAME = TXTSECTOR.Text.Substring(STARTPOS, 3)
                If TXTSECTOR.Text.Length > STARTPOS + 4 Then TOSECNAME = TXTSECTOR.Text.Substring(STARTPOS + 4, 3)
                If TOSECNAME.Trim = "" Then Exit For
                If TXTTEMPSECTOR.Text.Trim = "" Then
                    TXTTEMPSECTOR.Text = TXTTEMPSECTOR.Text.Trim & FROMSECNAME & "/" & TOSECNAME
                Else
                    TXTTEMPSECTOR.Text = TXTTEMPSECTOR.Text.Trim & "/" & TOSECNAME
                End If
                Dim flight_number As String = getFlightNumber(Val(TXTAIRSRNO.Text.Trim), FROMSECNAME, TOSECNAME, J, TXTSECTOR.Text, STARTPOS)
                Dim flight_arrives As String = getFlightArrives(Val(TXTAIRSRNO.Text.Trim), FROMSECNAME, TOSECNAME, J, TXTSECTOR.Text, STARTPOS)
                Dim flight_class As String = getFlightClass(Val(TXTAIRSRNO.Text.Trim), FROMSECNAME, TOSECNAME, J, TXTSECTOR.Text, STARTPOS)
                Dim flight_date As String = getFlightDate(Val(TXTAIRSRNO.Text.Trim), FROMSECNAME, TOSECNAME, J, TXTSECTOR.Text, STARTPOS)

                If flight_date = "" Then
                    flight_date = Format(PACKAGEFROM.Value.Date, "dd/MM/yyyy").ToString
                Else
                    flight_date = Format(Convert.ToDateTime(flight_date).Date, "dd/MM/yyyy").ToString
                End If

                GRIDSECTOR.Rows.Add(0, Val(TXTAIRSRNO.Text.Trim), FROMSECNAME, TOSECNAME, flight_number, flight_date, flight_arrives, flight_class)
                STARTPOS += 4
                J += 1
                TOSECNAME = ""
            Next

            If GRIDSECTOR.Rows.Count = 0 And TXTSECTOR.Text.Substring(4, 3).Trim <> "" Then GoTo LINE1
            getsrno(GRIDSECTOR)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function splitSectors(ByVal SECTORS As String) As String
        Try

            Dim TRIMMED As String() = SECTORS.Split("/")
            Dim I As Integer = 0
            Dim STR As String = ""
            For I = 0 To TRIMMED.Length - 1
                If TRIMMED(I).Trim.ToString <> "" Then
                    STR = STR & TRIMMED(I) & "/"
                End If
            Next

            STR = Mid(STR, 1, STR.Length - 1)

            Return STR
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Function getFlightNumber(ByVal booksrno As Integer, ByVal sec_from As String, ByVal sec_to As String, ByVal J As Integer, ByVal SECTORS As String, ByVal POS As Integer) As String
        Dim return_flight_num As String = ""
        POS += 4
        'If gridDoubleClick = False Then
        For Each drow As System.Windows.Forms.DataGridViewRow In GRIDFLIGHT.Rows
            If drow.Cells(GBOOKSRNO.Index).Value = booksrno And drow.Cells(GFROM.Index).Value = sec_from And drow.Cells(GTO.Index).Value = sec_to And drow.Cells(GFLIGHTNO.Index).Value.ToString.Trim <> "" And drow.Cells(GFLIGHTSRNO.Index).Value = J Then
                return_flight_num = drow.Cells(GFLIGHTNO.Index).Value
                Exit For
            End If
        Next
        ' If ClientName = "MAYUR" Then

        If return_flight_num.Trim = "" And GRIDFLIGHT.Rows.Count > 0 Then
            Dim trimSECTORS As String = splitSectors(SECTORS)
            booksrno = getBookingSr(trimSECTORS)
            Dim flight_sr_no As Integer = 0
            If POS > 0 Then flight_sr_no = (POS / 4)

            For Each drow As System.Windows.Forms.DataGridViewRow In GRIDFLIGHT.Rows
                If flight_sr_no = Convert.ToInt32(drow.Cells(GFLIGHTSRNO.Index).Value) And drow.Cells(GBOOKSRNO.Index).Value = booksrno And drow.Cells(GFROM.Index).Value = sec_from And drow.Cells(GTO.Index).Value = sec_to And drow.Cells(GFLIGHTNO.Index).Value.ToString.Trim <> "" Then
                    return_flight_num = drow.Cells(GFLIGHTNO.Index).Value
                    Exit For
                End If
            Next
        End If
        'End If
        'End If
        Return return_flight_num
    End Function

    Function getBookingSr(ByVal trimSECTORS As String) As Integer
        Dim booksrno As Integer = 0
        For Each dbrows As System.Windows.Forms.DataGridViewRow In GRIDAIRLINE.Rows
            If dbrows.Cells(GSECTOR.Index).Value.ToString.Trim = trimSECTORS Then
                booksrno = Convert.ToInt32(dbrows.Cells(GAIRSRNO.Index).Value)
            End If
        Next
        Return booksrno
    End Function

    Function getFlightArrives(ByVal booksrno As Integer, ByVal sec_from As String, ByVal sec_to As String, ByVal J As Integer, ByVal SECTORS As String, ByVal POS As Integer) As String
        Dim return_flight_arrives As String = ""
        POS += 4
        For Each drow As System.Windows.Forms.DataGridViewRow In GRIDFLIGHT.Rows
            If drow.Cells(GBOOKSRNO.Index).Value = booksrno And drow.Cells(GFROM.Index).Value = sec_from And drow.Cells(GTO.Index).Value = sec_to And drow.Cells(GCLASS.Index).Value.ToString.Trim <> "" And drow.Cells(GFLIGHTSRNO.Index).Value = J Then
                return_flight_arrives = drow.Cells(GARRIVAL.Index).Value
                Exit For
            End If
        Next
        'If ClientName = "MAYUR" Then
        If return_flight_arrives.Trim = "" And GRIDFLIGHT.Rows.Count > 0 Then
            Dim trimSECTORS As String = splitSectors(SECTORS)
            booksrno = getBookingSr(trimSECTORS)
            Dim flight_sr_no As Integer = 0
            If POS > 0 Then flight_sr_no = (POS / 4)

            For Each drow As System.Windows.Forms.DataGridViewRow In GRIDFLIGHT.Rows
                If flight_sr_no = Convert.ToInt32(drow.Cells(GFLIGHTSRNO.Index).Value) And drow.Cells(GBOOKSRNO.Index).Value = booksrno And drow.Cells(GFROM.Index).Value = sec_from And drow.Cells(GTO.Index).Value = sec_to And drow.Cells(GCLASS.Index).Value.ToString.Trim <> "" Then
                    return_flight_arrives = drow.Cells(GARRIVAL.Index).Value
                    Exit For
                End If
            Next
        End If
        'End If
        If ClientName = "JAIN" Then
            If return_flight_arrives.Trim.Length = 0 Then return_flight_arrives = "Y"
        End If
        Return return_flight_arrives
    End Function

    Function getFlightClass(ByVal booksrno As Integer, ByVal sec_from As String, ByVal sec_to As String, ByVal J As Integer, ByVal SECTORS As String, ByVal POS As Integer) As String
        Dim return_flight_class As String = ""
        POS += 4
        For Each drow As System.Windows.Forms.DataGridViewRow In GRIDFLIGHT.Rows
            If drow.Cells(GBOOKSRNO.Index).Value = booksrno And drow.Cells(GFROM.Index).Value = sec_from And drow.Cells(GTO.Index).Value = sec_to And drow.Cells(GCLASS.Index).Value.ToString.Trim <> "" And drow.Cells(GFLIGHTSRNO.Index).Value = J Then
                return_flight_class = drow.Cells(GCLASS.Index).Value
                Exit For
            End If
        Next
        'If ClientName = "MAYUR" Then
        If return_flight_class.Trim = "" And GRIDFLIGHT.Rows.Count > 0 Then
            Dim trimSECTORS As String = splitSectors(SECTORS)
            booksrno = getBookingSr(trimSECTORS)
            Dim flight_sr_no As Integer = 0
            If POS > 0 Then flight_sr_no = (POS / 4)

            For Each drow As System.Windows.Forms.DataGridViewRow In GRIDFLIGHT.Rows
                If flight_sr_no = Convert.ToInt32(drow.Cells(GFLIGHTSRNO.Index).Value) And drow.Cells(GBOOKSRNO.Index).Value = booksrno And drow.Cells(GFROM.Index).Value = sec_from And drow.Cells(GTO.Index).Value = sec_to And drow.Cells(GCLASS.Index).Value.ToString.Trim <> "" Then
                    return_flight_class = drow.Cells(GCLASS.Index).Value
                    Exit For
                End If
            Next
        End If
        'End If
        If ClientName = "JAIN" Then
            If return_flight_class.Trim.Length = 0 Then return_flight_class = "Y"
        End If
        Return return_flight_class
    End Function

    Function getFlightDate(ByVal booksrno As Integer, ByVal sec_from As String, ByVal sec_to As String, ByVal J As Integer, ByVal SECTORS As String, ByVal POS As Integer) As String
        Dim return_flight_date As String = ""
        POS += 4
        'If gridDoubleClick = False Then
        For Each drow As System.Windows.Forms.DataGridViewRow In GRIDFLIGHT.Rows
            If drow.Cells(GBOOKSRNO.Index).Value = booksrno And drow.Cells(GFROM.Index).Value = sec_from And drow.Cells(GTO.Index).Value = sec_to And Convert.ToString(drow.Cells(GFLTDATE.Index).Value).ToString <> "" And drow.Cells(GFLIGHTSRNO.Index).Value = J Then
                return_flight_date = Convert.ToString(drow.Cells(GFLTDATE.Index).Value).ToString
                Exit For
            End If
        Next
        'If ClientName = "MAYUR" Then
        If return_flight_date.Trim = "" And GRIDFLIGHT.Rows.Count > 0 Then
            Dim trimSECTORS As String = splitSectors(SECTORS)
            booksrno = getBookingSr(trimSECTORS)
            Dim flight_sr_no As Integer = 0
            If POS > 0 Then flight_sr_no = (POS / 4)

            For Each drow As System.Windows.Forms.DataGridViewRow In GRIDFLIGHT.Rows
                If flight_sr_no = Convert.ToInt32(drow.Cells(GFLIGHTSRNO.Index).Value) And drow.Cells(GBOOKSRNO.Index).Value = booksrno And drow.Cells(GFROM.Index).Value = sec_from And drow.Cells(GTO.Index).Value = sec_to And drow.Cells(GFLTDATE.Index).Value.ToString.Trim <> "" Then
                    return_flight_date = drow.Cells(GFLTDATE.Index).Value
                    Exit For
                End If
            Next
        End If
        'End If
        ' End If
        Return return_flight_date
    End Function

    Private Sub TXTAIRAMT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTAIRAMT.Validating
        Try
            If Val(TXTBASIC.Text.Trim) > 0 And Val(TXTGRIDTAX.Text.Trim) > 0 And Val(TXTAIRAMT.Text.Trim) > 0 Then
                FILLAIRLINEGRID()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical, "TRAVELMATE")
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLAIRLINEGRID()
        Try
            GRIDAIRLINE.Enabled = True
            If GRIDAIRDOUBLECLICK = False Then
                GRIDAIRLINE.Rows.Add(Val(TXTAIRSRNO.Text.Trim), TXTTEMPSECTOR.Text.Trim, TXTFLTNO.Text.Trim, CMBTYPE.Text.Trim, Format(Val(TXTBASIC.Text.Trim), "0.00"), Format(Val(TXTPSF.Text.Trim), "0.00"), Format(Val(TXTGRIDTAX.Text.Trim), "0.00"), Format(Val(TXTAIRAMT.Text.Trim), "0.00"), 0)
                getsrno(GRIDAIRLINE)

                'ADD IN FLIGHT ALSO
                For Each ROW As DataGridViewRow In GRIDSECTOR.Rows
                    GRIDFLIGHT.Rows.Add(ROW.Cells(GSECSRNO.Index).Value, ROW.Cells(GSECBOOKSRNO.Index).Value, ROW.Cells(GSECFROM.Index).Value, ROW.Cells(GSECTO.Index).Value, ROW.Cells(GSECFLTNO.Index).Value, ROW.Cells(GSECFLTDATE.Index).Value, ROW.Cells(GARRIVAL.Index).Value, ROW.Cells(GSECCLASS.Index).Value)
                Next

            ElseIf GRIDAIRDOUBLECLICK = True Then
                GRIDAIRLINE.Item(GAIRSRNO.Index, tempFLIGHTrow).Value = Val(TXTAIRSRNO.Text.Trim)
                GRIDAIRLINE.Item(GSECTOR.Index, tempFLIGHTrow).Value = TXTTEMPSECTOR.Text.Trim
                GRIDAIRLINE.Item(GFLTNO.Index, tempFLIGHTrow).Value = TXTFLTNO.Text.Trim
                GRIDAIRLINE.Item(GTYPE.Index, tempFLIGHTrow).Value = CMBTYPE.Text.Trim
                GRIDAIRLINE.Item(GBASIC.Index, tempFLIGHTrow).Value = Format(Val(TXTBASIC.Text.Trim), "0.00")
                GRIDAIRLINE.Item(GPSF.Index, tempFLIGHTrow).Value = Format(Val(TXTPSF.Text.Trim), "0.00")
                GRIDAIRLINE.Item(GTAXES.Index, tempFLIGHTrow).Value = Format(Val(TXTGRIDTAX.Text.Trim), "0.00")
                GRIDAIRLINE.Item(GTOTAL.Index, tempFLIGHTrow).Value = Format(Val(TXTAIRAMT.Text.Trim), "0.00")


                'FIRST REMOVE OLD RECORDS AND THEN ADD NEW 
LINE1:
                For Each ROW As DataGridViewRow In GRIDFLIGHT.Rows
                    If ROW.Cells(GBOOKSRNO.Index).Value = tempFLIGHTrow + 1 Then
                        GRIDFLIGHT.Rows.RemoveAt(ROW.Index)
                        GoTo LINE1
                    End If
                Next
                For Each ROW As DataGridViewRow In GRIDSECTOR.Rows
                    GRIDFLIGHT.Rows.Add(ROW.Cells(GSECSRNO.Index).Value, ROW.Cells(GSECBOOKSRNO.Index).Value, ROW.Cells(GSECFROM.Index).Value, ROW.Cells(GSECTO.Index).Value, ROW.Cells(GSECFLTNO.Index).Value, ROW.Cells(GSECFLTDATE.Index).Value, ROW.Cells(GARRIVAL.Index).Value, ROW.Cells(GSECCLASS.Index).Value)
                Next

                GRIDAIRDOUBLECLICK = False
            End If
            total()
            GRIDAIRLINE.FirstDisplayedScrollingRowIndex = GRIDAIRLINE.RowCount - 1

            TXTAIRSRNO.Text = GRIDAIRLINE.RowCount + 1
            TXTSECTOR.Clear()
            TXTFLTNO.Clear()
            CMBTYPE.Text = ""
            TXTBASIC.Clear()
            TXTPSF.Clear()
            TXTGRIDTAX.Clear()
            TXTAIRAMT.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTMISCAMT_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTMISCAMT.Validated
        Try
            If TXTMISCSERVICETYPE.Text.Trim <> "" Then
                FILLGRIDMISC()
                total()
            Else
                MsgBox("Enter Proper Details")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRIDMISC()
        Try
            If GRIDMISCDOUBLECLICK = False Then

                GRIDMISC.Rows.Add(Val(TXTMISCSRNO.Text.Trim), TXTMISCSERVICETYPE.Text.Trim, TXTMISCREMARKS.Text.Trim, Val(TXTMISCAMT.Text.Trim))
                getsrno(GRIDMISC)

            ElseIf GRIDMISCDOUBLECLICK = True Then

                GRIDMISC.Item(GMISCSRNO.Index, TEMPMISCROW).Value = TXTMISCSRNO.Text.Trim
                GRIDMISC.Item(GMISCSERVICETYPE.Index, TEMPMISCROW).Value = TXTMISCSERVICETYPE.Text.Trim
                GRIDMISC.Item(GMISCREMARKS.Index, TEMPMISCROW).Value = TXTMISCREMARKS.Text.Trim
                GRIDMISC.Item(GMISCAMOUNT.Index, TEMPMISCROW).Value = TXTMISCAMT.Text.Trim

                GRIDMISCDOUBLECLICK = False

            End If
            GRIDMISC.FirstDisplayedScrollingRowIndex = GRIDMISC.RowCount - 1

            TXTMISCSRNO.Text = GRIDMISC.RowCount + 1
            TXTMISCSERVICETYPE.Clear()
            TXTMISCREMARKS.Clear()
            TXTMISCAMT.Clear()
            TXTMISCSERVICETYPE.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDPURCHASE_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDPURCHASE.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDPURCHASE.Item(GPURSRNO.Index, e.RowIndex).Value <> Nothing Then

                GRIDPURCHASEDOUBLECLICK = True
                TXTPURSRNO.Text = GRIDPURCHASE.Item(GPURSRNO.Index, e.RowIndex).Value.ToString
                CMBPURNAME.Text = GRIDPURCHASE.Item(GPURNAME.Index, e.RowIndex).Value.ToString
                TXTPURAMOUNT.Text = Val(GRIDPURCHASE.Item(GPURAMOUNT.Index, e.RowIndex).Value)
                CMBPURCURCODE.Text = GRIDPURCHASE.Item(GPURCURCODE.Index, e.RowIndex).Value.ToString
                TXTPURROE.Text = Val(GRIDPURCHASE.Item(GPURROE.Index, e.RowIndex).Value)
                TXTPURREMARKS.Text = GRIDPURCHASE.Item(GPURREMARKS.Index, e.RowIndex).Value.ToString
                TEMPPURROW = e.RowIndex
                CMBPURNAME.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRIDPURCHASE()
        Try
            If GRIDPURCHASEDOUBLECLICK = False Then

                GRIDPURCHASE.Rows.Add(Val(TXTPURSRNO.Text.Trim), CMBPURNAME.Text.Trim, Val(TXTPURAMOUNT.Text.Trim), CMBPURCURCODE.Text.Trim, Val(TXTPURROE.Text.Trim), TXTPURREMARKS.Text.Trim)
                getsrno(GRIDPURCHASE)

            ElseIf GRIDPURCHASEDOUBLECLICK = True Then

                GRIDPURCHASE.Item(GPURSRNO.Index, TEMPPURROW).Value = TXTPURSRNO.Text.Trim
                GRIDPURCHASE.Item(GPURNAME.Index, TEMPPURROW).Value = CMBPURNAME.Text.Trim
                GRIDPURCHASE.Item(GPURAMOUNT.Index, TEMPPURROW).Value = Val(TXTPURAMOUNT.Text.Trim)
                GRIDPURCHASE.Item(GPURCURCODE.Index, TEMPPURROW).Value = CMBPURCURCODE.Text.Trim
                GRIDPURCHASE.Item(GPURROE.Index, TEMPPURROW).Value = Val(TXTPURROE.Text.Trim)
                GRIDPURCHASE.Item(GPURREMARKS.Index, TEMPPURROW).Value = TXTPURREMARKS.Text.Trim

                GRIDPURCHASEDOUBLECLICK = False

            End If
            GRIDPURCHASE.FirstDisplayedScrollingRowIndex = GRIDPURCHASE.RowCount - 1

            TXTPURSRNO.Text = GRIDPURCHASE.RowCount + 1
            CMBPURNAME.Text = ""
            TXTPURAMOUNT.Clear()
            CMBPURCURCODE.Text = ""
            TXTPURROE.Clear()
            TXTPURREMARKS.Clear()

            CMBPURNAME.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTPURAMT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPURAMOUNT.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTPURREMARKS_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTPURREMARKS.Validated
        Try
            If CMBPURNAME.Text.Trim <> "" And Val(TXTPURAMOUNT.Text.Trim) > 0 Then
                FILLGRIDPURCHASE()
                total()
            Else
                MsgBox("Enter Proper Details")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTSECTOR_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTSECTOR.Validated
        If TXTSECTOR.Text <> "" And TXTSECTOR.Text <> "   /   /   /   /   /" Then
            'GET LATEST SRNO
            If GRIDAIRDOUBLECLICK = False Then
                If GRIDAIRLINE.RowCount > 0 Then TXTAIRSRNO.Text = Val(GRIDAIRLINE.Rows(GRIDAIRLINE.RowCount - 1).Cells(GSRNO.Index).Value) + 1 Else TXTAIRSRNO.Text = 1
            End If

            TXTSECTOR.Text = UCase(TXTSECTOR.Text)
            SECTORGROUP.Visible = True
            SECTORGROUP.BringToFront()
            FILLGRIDSECTOR()
            GRIDSECTOR.Focus()
        End If
    End Sub

    Private Sub TXTGRIDTAX_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTPSF.Validated, TXTGRIDTAX.Validated, TXTBASIC.Validated
        CALC()
    End Sub

    Private Sub CMBCURCODE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBCURCODE.Enter
        Try
            If CMBCURCODE.Text.Trim = "" Then FILLCURRENCY(CMBCURCODE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCURCODE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCURCODE.Validated
        Try
            'GET ROE
            If CMBCURCODE.Text.Trim <> "" And Val(TXTROE.Text.Trim) = 0 Then TXTROE.Text = GETROE(CMBCURCODE.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCURCODE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCURCODE.Validating
        Try
            If CMBCURCODE.Text.Trim <> "" Then CURRENCYvalidate(CMBCURCODE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPURCURCODE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBPURCURCODE.Enter
        Try
            If CMBPURCURCODE.Text.Trim = "" Then FILLCURRENCY(CMBPURCURCODE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPURCURCODE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPURCURCODE.Validated
        Try
            'GET ROE
            If CMBPURCURCODE.Text.Trim <> "" And Val(TXTPURROE.Text.Trim) = 0 Then TXTPURROE.Text = GETROE(CMBPURCURCODE.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPURCURCODE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPURCURCODE.Validating
        Try
            If CMBPURCURCODE.Text.Trim <> "" Then CURRENCYvalidate(CMBPURCURCODE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITINERARY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITINERARY.Validating
        Try
            If CMBITINERARY.Text.Trim <> "" Then ITEINIRARYVALIDATE(CMBITINERARY, e, Me, " AND DATEADD(DAY,-1, CAST(ITINERARY_FROM AS DATE)) < '" & Format(PACKAGEFROM.Value.Date, "MM/dd/yyyy") & "' AND DATEADD(DAY,1, CAST(ITINERARY_TO AS DATE)) > '" & Format(PACKAGEFROM.Value.Date, "MM/dd/yyyy") & "'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPURNAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBPURNAME.Enter
        Try
            If CMBPURNAME.Text.Trim = "" Then fillname(CMBPURNAME, edit, " AND GROUP_SECONDARY = 'SUNDRY CREDITORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPURNAME_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBPURNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBPURCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBPURNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPURNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPURNAME.Validating
        Try
            If CMBPURNAME.Text.Trim <> "" Then namevalidate(CMBPURNAME, CMBPURCODE, e, Me, TXTPURADD, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITINERARY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBITINERARY.Enter
        Try
            If CMBITINERARY.Text.Trim = "" Then FILLITINERARY(CMBITINERARY, " AND DATEADD(DAY,-1, CAST(ITINERARY_FROM AS DATE)) < '" & Format(PACKAGEFROM.Value.Date, "MM/dd/yyyy") & "' AND DATEADD(DAY,1, CAST(ITINERARY_TO AS DATE)) > '" & Format(PACKAGEFROM.Value.Date, "MM/dd/yyyy") & "' AND ISNULL(ITINERARY_PACKAGETYPE,'DOMESTIC') = '" & CMBPACKAGETYPE.Text.Trim & "'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITINERARY_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBITINERARY.Validated
        Try
            If CMBITINERARY.Text.Trim <> "" Then
                'FIRST SELECT MEALPLAN, ADULTS
                If CMBPLAN.Text.Trim = "" Then
                    MsgBox("Select Meal Plan First", MsgBoxStyle.Critical)
                    CMBITINERARY.Text = ""
                    Exit Sub
                End If
                If Val(TXTADULTS.Text.Trim) = 0 Then
                    MsgBox("Enter No. of Adults First", MsgBoxStyle.Critical)
                    CMBITINERARY.Text = ""
                    Exit Sub
                End If

                If CMBITINERARY.Text.Trim <> "" Then
                    If MsgBox("Copy Itinerary of " & CMBITINERARY.Text.Trim & "?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        CMBITINERARY.Text = ""
                        Exit Sub
                    End If
                    FILLITINERARYDETAILS()

                    CMBGROUPDEPARTURE.Enabled = False
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLITINERARYDETAILS()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" ISNULL(ITINERARYMASTER.ITINERARY_NAME, '') AS NAME, ISNULL(ITINERARYMASTER.ITINERARY_DISPLAYNAME, '') AS DISPLAYNAME, ITINERARYMASTER.ITINERARY_TOTALDAYS AS TOTALDAYS, HOTELMASTER.HOTEL_NAME AS HOTELNAME, ITINERARYMASTER_HOTEL.ITINERARY_NIGHTS AS NIGHTS, ROOMTYPEMASTER.ROOMTYPE_NAME AS ROOMTYPE, ITINERARYMASTER.ITINERARY_QUOTE AS QUOTETYPE, ITINERARYMASTER.ITINERARY_ADULTRATE AS ADULTRATE, ITINERARYMASTER.ITINERARY_EXTRAADULTRATE AS EXTRAADULTRATE, ITINERARYMASTER.ITINERARY_CHILDBEDRATE AS CHILDBEDRATE, ITINERARYMASTER.ITINERARY_CHILDRATE AS CHILDWOBEDRATE, ITINERARYMASTER.ITINERARY_CHILDBELOWAGE AS INFANTRATE, ITINERARYMASTER.ITINERARY_LUMPSUM AS LUMPSUMRATE, ISNULL(ITINERARY_INCLUSION, '') AS INCLUSION, ISNULL(ITINERARY_EXCLUSION, '') AS EXCLUSION, ISNULL(ITINERARY_TERMS, '') AS TERMS, ISNULL(ITINERARY_REMARKS, '') AS REMARKS ", "", " ITINERARYMASTER INNER JOIN ITINERARYMASTER_HOTEL ON ITINERARYMASTER.ITINERARY_NO = ITINERARYMASTER_HOTEL.ITINERARY_NO AND  ITINERARYMASTER.ITINERARY_YEARID = ITINERARYMASTER_HOTEL.ITINERARY_YEARID INNER JOIN HOTELMASTER ON ITINERARYMASTER_HOTEL.ITINERARY_HOTELID = HOTELMASTER.HOTEL_ID INNER JOIN ROOMTYPEMASTER ON ITINERARYMASTER_HOTEL.ITINERARY_ROOMTYPEID = ROOMTYPEMASTER.ROOMTYPE_ID  ", " AND ITINERARYMASTER.ITINERARY_NAME = '" & CMBITINERARY.Text.Trim & "' AND ITINERARYMASTER.ITINERARY_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then

                GRIDBOOKINGS.RowCount = 0
                GRIDTRANS.RowCount = 0
                GRIDMISC.RowCount = 0
                GRIDFLIGHT.RowCount = 0
                GRIDAIRLINE.RowCount = 0

                TXTTOURNAME.Text = DT.Rows(0).Item("DISPLAYNAME")
                TXTNOTES.Text = DT.Rows(0).Item("REMARKS")
                TXTPOLICY.Text = DT.Rows(0).Item("TERMS")
                TXTBOOKDESC.Text = DT.Rows(0).Item("INCLUSION") & vbCrLf & vbCrLf & DT.Rows(0).Item("EXCLUSION")
                TXTTOTALNIGHTS.Text = Val(DT.Rows(0).Item("TOTALDAYS")) - 1
                PACKAGETO.Value = DateAdd(DateInterval.Day, Val(DT.Rows(0).Item("TOTALDAYS")) - 1, PACKAGEFROM.Value.Date)
                CMBQUOTECALC.Text = DT.Rows(0).Item("QUOTETYPE")

                'DONE BY GULKIT
                'If DT.Rows(0).Item("QUOTETYPE") = "Per Person" Then
                '    TXTRATE.Text = Val(DT.Rows(0).Item("ADULTRATE"))
                '    TXTEXTRAADULTRATE.Text = Val(DT.Rows(0).Item("EXTRAADULTRATE"))
                '    TXTEXTRACHILDRATE.Text = Val(DT.Rows(0).Item("CHILDBEDRATE"))
                'End If

                For Each DTROW As DataRow In DT.Rows
                    'GRIDBOOKINGS.Rows.Add(0, DTROW("HOTELNAME"), "", "", "", Format(CHECKINDATE.Value.Date, "dd/MM/yyyy"), Format(CHECKINDATE.Value.Date.AddDays(Val(DTROW("NIGHTS"))), "dd/MM/yyyy"), DTROW("ROOMTYPE"), CMBPLAN.Text.Trim, Val(TXTADULTS.Text.Trim), Val(TXTCHILDS.Text.Trim), Val(TXTNCCHILDS.Text.Trim), Val(TXTBEXTRAADULT.Text.Trim), Format(Val(TXTBEXTRAADULTRATE.Text.Trim), "0.00"), Val(TXTBEXTRACHILD.Text.Trim), Format(Val(TXTBEXTRACHILDRATE.Text.Trim), "0.00"), Val(TXTTOTALPAX.Text.Trim), Math.Floor(Val(TXTADULTS.Text) / 2), "Yes", Format(Val(TXTRATE.Text.Trim), "0.00"), Format(Val(TXTCHILDRATE.Text.Trim), "0.00"), Format(Val(TXTINFANTRATE.Text.Trim), "0.00"), "", 0, Format(Val(TXTRATE.Text.Trim), "0.00"), Val(DTROW("NIGHTS")))
                    GRIDBOOKINGS.Rows.Add(0, DTROW("HOTELNAME"), "", "", "", Format(CHECKINDATE.Value.Date, "dd/MM/yyyy"), Format(CHECKINDATE.Value.Date.AddDays(Val(DTROW("NIGHTS"))), "dd/MM/yyyy"), DTROW("ROOMTYPE"), CMBPLAN.Text.Trim, Val(TXTADULTS.Text.Trim), Val(TXTCHILDS.Text.Trim), Val(TXTNCCHILDS.Text.Trim), Val(TXTBEXTRAADULT.Text.Trim), Val(TXTBEXTRACHILD.Text.Trim), Math.Floor(Val(TXTADULTS.Text) / 2), "Yes", Format(Val(TXTRATE.Text.Trim), "0.00"), Format(Val(TXTCHILDRATE.Text.Trim), "0.00"), Format(Val(TXTINFANTRATE.Text.Trim), "0.00"), Format(Val(TXTBEXTRAADULTRATE.Text.Trim), "0.00"), Format(Val(TXTBEXTRACHILDRATE.Text.Trim), "0.00"), Val(TXTTOTALPAX.Text.Trim), "", 0, Format(Val(TXTRATE.Text.Trim), "0.00"), Val(DTROW("NIGHTS")))
                    CHECKINDATE.Value = CHECKINDATE.Value.Date.AddDays(Val(DTROW("NIGHTS")))
                Next
                getsrno(GRIDBOOKINGS)

                'DONE BY GULKIT
                'If DT.Rows(0).Item("QUOTETYPE") = "Lump Sum" Then
                '    GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(grate.Index).Value = Val(DT.Rows(0).Item("LUMPSUMRATE"))
                '    GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(gamt.Index).Value = Val(DT.Rows(0).Item("LUMPSUMRATE"))
                'End If
                If DT.Rows(0).Item("QUOTETYPE") = "Lump Sum" Then
                    GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(grate.Index).Value = Val(DT.Rows(0).Item("LUMPSUMRATE"))
                    GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(gamt.Index).Value = Val(DT.Rows(0).Item("LUMPSUMRATE"))
                ElseIf DT.Rows(0).Item("QUOTETYPE") = "Per Person" Then
                    GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(grate.Index).Value = Val(DT.Rows(0).Item("ADULTRATE"))
                    GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(GEXADURATE.Index).Value = Val(DT.Rows(0).Item("EXTRAADULTRATE"))
                    GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(GEXCHDRATE.Index).Value = Val(DT.Rows(0).Item("CHILDWOBEDRATE"))
                    GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(GCHILDRATE.Index).Value = Val(DT.Rows(0).Item("CHILDBEDRATE"))
                    GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(GINFANTRATE.Index).Value = Val(DT.Rows(0).Item("INFANTRATE"))
                    GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(gamt.Index).Value = Format((Val(DT.Rows(0).Item("ADULTRATE")) * Val(TXTADULTS.Text.Trim)) + (Val(DT.Rows(0).Item("EXTRAADULTRATE")) * Val(GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(GEXTADU.Index).Value)) + (Val(DT.Rows(0).Item("CHILDWOBEDRATE")) * Val(GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(GEXCHILD.Index).Value)) + (Val(DT.Rows(0).Item("CHILDBEDRATE")) * Val(GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(GCHILD.Index).Value)) + (Val(DT.Rows(0).Item("INFANTRATE")) * Val(GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(GINFANT.Index).Value)), "0.00")

                    TXTTEMPADULTRATE.Text = Val(DT.Rows(0).Item("ADULTRATE"))
                    TXTTEMPCWBRATE.Text = Val(DT.Rows(0).Item("CHILDBEDRATE"))
                    TXTTEMPCNBRATE.Text = Val(DT.Rows(0).Item("CHILDWOBEDRATE"))
                    TXTTEMPEXADULTRATE.Text = Val(DT.Rows(0).Item("EXTRAADULTRATE"))
                    TXTTEMPINFANTRATE.Text = Val(DT.Rows(0).Item("INFANTRATE"))
                End If

                total()
            End If



            'GET VEHICLE DETAILS
            DT = OBJCMN.search(" VEHICLETYPEMASTER.VEHICLETYPE_NAME AS CARTYPE, VEHICLEMASTER.VEHICLE_NAME AS CARNAME, ITINERARYMASTER_VEHICLE.ITINERARY_DESCRIPTION AS DESCRIPTION, ITINERARYMASTER_VEHICLE.ITINERARY_DAYS AS DAYS  ", "", " ITINERARYMASTER INNER JOIN ITINERARYMASTER_VEHICLE ON ITINERARYMASTER.ITINERARY_NO = ITINERARYMASTER_VEHICLE.ITINERARY_NO AND ITINERARYMASTER.ITINERARY_YEARID = ITINERARYMASTER_VEHICLE.ITINERARY_YEARID INNER JOIN VEHICLEMASTER ON ITINERARYMASTER_VEHICLE.ITINERARY_VEHICLEID = VEHICLEMASTER.VEHICLE_ID INNER JOIN VEHICLETYPEMASTER ON VEHICLEMASTER.VEHICLE_TYPEID = VEHICLETYPEMASTER.VEHICLETYPE_ID ", " AND ITINERARYMASTER.ITINERARY_NAME = '" & CMBITINERARY.Text.Trim & "' AND ITINERARYMASTER.ITINERARY_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                For Each DTROW As DataRow In DT.Rows
                    GRIDTRANS.Rows.Add(0, "", "", DTROW("CARTYPE"), DTROW("CARNAME"), Val(TXTADULTS.Text.Trim), Val(TXTCHILDS.Text.Trim), (Val(TXTTOTALPAX.Text.Trim)), Format(PICKUPDATE.Value.Date, "dd/MM/yyyy"), "", "", "", Format(PICKUPDATE.Value.Date.AddDays(Val(DTROW("DAYS")) - 1), "dd/MM/yyyy"), "", "", "", Val(DTROW("DAYS")), "", "", DTROW("DESCRIPTION"), 0)
                Next
                getsrno(GRIDTRANS)
            End If




            'GET AIRLINE DATA
            DT = OBJCMN.search(" ISNULL(ITINERARYMASTER_AIRLINE.ITINERARY_NO, 0) AS GROUPDEPNO, ISNULL(ITINERARY_GRIDSRNO, 0) AS AIRSRNO, ISNULL(ITINERARY_SECTOR, '') AS SECTOR, ISNULL(ITINERARY_FLTNO, '') AS FLTNO, ISNULL(ITINERARY_TYPE, '') AS TYPE, ISNULL(ITINERARY_BASIC, 0) AS BASIC, ISNULL(ITINERARY_PSF, 0) AS PSF, ISNULL(ITINERARY_TAXES, 0) AS TAXES, ISNULL(ITINERARY_AMT, 0) AS AIRAMT ", "", " ITINERARYMASTER_AIRLINE INNER JOIN ITINERARYMASTER ON ITINERARYMASTER_AIRLINE.ITINERARY_NO = ITINERARYMASTER.ITINERARY_NO AND ITINERARYMASTER_AIRLINE.ITINERARY_YEARID = ITINERARYMASTER.ITINERARY_YEARID ", " AND ITINERARYMASTER.ITINERARY_NAME = '" & CMBITINERARY.Text.Trim & "' AND ITINERARYMASTER.ITINERARY_YEARID = " & YearId & " ORDER BY ITINERARYMASTER_AIRLINE.ITINERARY_GRIDSRNO")
            If DT.Rows.Count > 0 Then
                For Each DRA As DataRow In DT.Rows
                    GRIDAIRLINE.Rows.Add(DRA("AIRSRNO"), DRA("SECTOR"), DRA("FLTNO"), DRA("TYPE"), Format(Val(DRA("BASIC")), "0.00"), Format(Val(DRA("PSF")), "0.00"), Format(Val(DRA("TAXES")), "0.00"), Format(Val(DRA("AIRAMT")), "0.00"))
                Next
                total()
            End If


            'GET GRIDFLIGHT DATA
            DT = OBJCMN.search(" ITINERARYMASTER_FLIGHTDESC.ITINERARY_GRIDSRNO AS GRIDSRNO, ITINERARYMASTER_FLIGHTDESC.ITINERARY_BOOKSRNO AS BOOKSRNO, ISNULL(FROMSECTORMASTER.SECTOR_NAME, '') AS FROMSEC, ISNULL(TOSECTORMASTER.SECTOR_NAME, '') AS TOSEC, ITINERARYMASTER_FLIGHTDESC.ITINERARY_FLIGHTNO AS FLIGHTNO, ITINERARYMASTER_FLIGHTDESC.ITINERARY_FLIGHTDATE AS FLIGHTDATE, ISNULL(ITINERARYMASTER_FLIGHTDESC.ITINERARY_ARRIVES, '') AS ARRIVES, CLASSMASTER.CLASS_NAME AS CLASS", "", " CLASSMASTER RIGHT OUTER JOIN  ITINERARYMASTER_FLIGHTDESC INNER JOIN ITINERARYMASTER ON ITINERARYMASTER_FLIGHTDESC.ITINERARY_NO = ITINERARYMASTER.ITINERARY_NO AND ITINERARYMASTER_FLIGHTDESC.ITINERARY_YEARID = ITINERARYMASTER.ITINERARY_YEARID ON CLASSMASTER.CLASS_YEARID = ITINERARYMASTER_FLIGHTDESC.ITINERARY_YEARID AND CLASSMASTER.CLASS_CMPID = ITINERARYMASTER_FLIGHTDESC.ITINERARY_CMPID AND CLASSMASTER.CLASS_ID = ITINERARYMASTER_FLIGHTDESC.ITINERARY_CLASSID LEFT OUTER JOIN SECTORMASTER AS TOSECTORMASTER ON ITINERARYMASTER_FLIGHTDESC.ITINERARY_TOID = TOSECTORMASTER.SECTOR_ID AND ITINERARYMASTER_FLIGHTDESC.ITINERARY_CMPID = TOSECTORMASTER.SECTOR_CMPID AND ITINERARYMASTER_FLIGHTDESC.ITINERARY_YEARID = TOSECTORMASTER.SECTOR_YEARID LEFT OUTER JOIN SECTORMASTER AS FROMSECTORMASTER ON ITINERARYMASTER_FLIGHTDESC.ITINERARY_FROMID = FROMSECTORMASTER.SECTOR_ID AND ITINERARYMASTER_FLIGHTDESC.ITINERARY_CMPID = FROMSECTORMASTER.SECTOR_CMPID AND ITINERARYMASTER_FLIGHTDESC.ITINERARY_YEARID = FROMSECTORMASTER.SECTOR_YEARID ", " AND ITINERARYMASTER.ITINERARY_NAME = '" & CMBITINERARY.Text.Trim & "' AND ITINERARYMASTER.ITINERARY_YEARID = " & YearId & " ORDER BY ITINERARYMASTER_FLIGHTDESC.ITINERARY_BOOKSRNO ASC, ITINERARYMASTER_FLIGHTDESC.ITINERARY_GRIDSRNO ASC")
            If DT.Rows.Count > 0 Then
                For Each DRF As DataRow In DT.Rows
                    GRIDFLIGHT.Rows.Add(DRF("GRIDSRNO").ToString, DRF("BOOKSRNO"), DRF("FROMSEC").ToString, DRF("TOSEC").ToString, DRF("FLIGHTNO").ToString, DRF("FLIGHTDATE").ToString, DRF("ARRIVES").ToString, DRF("CLASS").ToString)
                Next
                total()
            End If


            'MISC GRID
            DT = OBJCMN.search(" ISNULL(ITINERARYMASTER_MISC.ITINERARY_SRNO, 0) AS SRNO, ISNULL(ITINERARYMASTER_MISC.ITINERARY_TYPE, '') AS SERVICETYPE, ISNULL(ITINERARYMASTER_MISC.ITINERARY_REMARKS, '') AS MISCREMARKS ", "", " ITINERARYMASTER_MISC INNER JOIN ITINERARYMASTER ON ITINERARYMASTER_MISC.ITINERARY_NO = ITINERARYMASTER.ITINERARY_NO AND ITINERARYMASTER_MISC.ITINERARY_YEARID = ITINERARYMASTER.ITINERARY_YEARID ", " AND ITINERARYMASTER.ITINERARY_NAME = '" & CMBITINERARY.Text.Trim & "' AND ITINERARYMASTER.ITINERARY_YEARID = " & YearId & " ORDER BY ITINERARYMASTER_MISC.ITINERARY_SRNO ")
            If DT.Rows.Count > 0 Then
                For Each DTM As DataRow In DT.Rows
                    GRIDMISC.Rows.Add(Val(DTM("SRNO")), DTM("SERVICETYPE"), DTM("MISCREMARKS"))
                Next
            End If


            'TOUR GRID
            Dim dt1 As DataTable
            dt1 = OBJCMN.search(" ITINERARY_SRNO AS SRNO, ITINERARY_HEADER AS HEADER, ITINERARY_DETAILS AS DETAILS, ITINERARY_PHOTO AS IMGPATH ", "", " ITINERARYMASTER_DESC INNER JOIN ITINERARYMASTER ON ITINERARYMASTER_DESC.ITINERARY_NO = ITINERARYMASTER.ITINERARY_NO AND ITINERARYMASTER_DESC.ITINERARY_YEARID = ITINERARYMASTER.ITINERARY_YEARID ", " AND ITINERARYMASTER.ITINERARY_NAME = '" & CMBITINERARY.Text.Trim & "' AND ITINERARYMASTER.ITINERARY_CMPID = " & CmpId & " AND ITINERARYMASTER.ITINERARY_YEARID = " & YearId & " ORDER BY ITINERARYMASTER_DESC.ITINERARY_SRNO ")
            If dt1.Rows.Count > 0 Then
                For Each ROW As DataRow In dt1.Rows
                    If IsDBNull(ROW("IMGPATH")) = False Then GRIDTOUR.Rows.Add(Val(ROW("SRNO")), ROW("HEADER"), ROW("DETAILS"), Image.FromStream(New IO.MemoryStream(DirectCast(ROW("IMGPATH"), Byte())))) Else GRIDTOUR.Rows.Add(Val(ROW("SRNO")), ROW("HEADER"), ROW("DETAILS"), Nothing)
                Next
            End If

            PBSOFTCOPY.Image = Nothing



        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCLOSEAIRLINE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLOSEAIRLINE.Click
        Try
            If GRIDSECTOR.Rows.Count > 0 Then
                TXTFLTNO.Text = GRIDSECTOR.Rows(0).Cells(GSECFLTNO.Index).Value
            End If
            SECTORGROUP.Visible = False
            TXTFLTNO.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTROE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTROE.KeyPress, TXTPURROE.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub CMDAMEND_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDAMEND.Click
        Try
            If edit = True Then
                MsgBox("Not allowed in Edit Mode", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Cursor.Current = Cursors.WaitCursor

            Dim OBJAMEND As New SelectQuoteforAmendment
            Dim DTAMEND As DataTable = OBJAMEND.DT
            OBJAMEND.ShowDialog()
            Dim i As Integer = 0
            If DTAMEND.Rows.Count > 0 Then
                clear()

                TXTAMDENQNO.Text = DTAMEND.Rows(0).Item("ENQNO")

                Dim ALPARAVAL As New ArrayList
                Dim OBJBOOKING As New ClsHolidayEnquiry()

                ALPARAVAL.Add(Val(TXTAMDENQNO.Text.Trim))
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                OBJBOOKING.alParaval = ALPARAVAL
                Dim dt As DataTable = OBJBOOKING.SELECTBOOKINGDESC()
                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows

                        ENQDATE.Value = Convert.ToDateTime(dr("BOOKINGDATE")).Date
                        txtrefno.Text = dr("REFNO")
                        CMBGUESTNAME.Text = dr("GUESTNAME")
                        CMBNAME.Text = dr("NAME")
                        TXTGUESTADD.Text = dr("GUESTADD")

                        TXTTOURNAME.Text = dr("TOURNAME")
                        PACKAGEFROM.Value = Convert.ToDateTime(dr("PACKAGEFROM")).Date
                        PACKAGETO.Value = Convert.ToDateTime(dr("PACKAGETO")).Date

                        TXTADULTS.Text = dr("ADULTS")
                        TXTCHILDS.Text = dr("CHILDS")
                        TXTNCCHILDS.Text = dr("NCCHILDS")
                        TXTTOTALPAX.Text = dr("TOTALPAX")
                        CMBITINERARY.Text = dr("ITINERARYNAME")
                        CMBGROUPDEPARTURE.Text = dr("GROUPDEPARTURENAME")
                        TXTMISCENQNO.Text = dr("MISCENQNO")

                        CMBPACKAGETYPE.Text = dr("PACKAGETYPE")
                        CMBQUOTECALC.Text = dr("QUOTETYPE")
                        TXTTOTALPURAMT.Text = dr("COSTPRICE")

                        TXTEXTRAADULT.Text = dr("EXTRAADULT")
                        TXTEXTRAADULTRATE.Text = dr("EXTRAADULTRATE")
                        TXTEXTRACHILD.Text = dr("EXTRACHILD")
                        TXTEXTRACHILDRATE.Text = dr("EXTRACHILDRATE")

                        CMBBOOKEDBY.Text = dr("BOOKEDBY")
                        CMBSOURCE.Text = dr("SOURCE")

                        TXTTOTALSALEAMT.Text = dr("TOTALSALEAMT")

                        TXTOURCOMMPER.Text = dr("OURCOMMPER")
                        TXTOURCOMMRS.Text = dr("OURCOMMRS")

                        TXTDISCPER.Text = dr("DISCPER")
                        TXTDISCRS.Text = dr("DISCRS")

                        cmbtax.Text = dr("TAXNAME")
                        txttax.Text = dr("TAXAMT")
                        CMBADDTAX.Text = dr("ADDTAXNAME")
                        TXTADDTAX.Text = dr("ADDTAXAMT")

                        CMBOTHERCHGS.Text = dr("OTHERCHGSNAME")
                        If dr("OTHERCHGS") > 0 Then
                            txtotherchg.Text = dr("OTHERCHGS")
                            cmbaddsub.Text = "Add"
                        Else
                            txtotherchg.Text = dr("OTHERCHGS") * (-1)
                            cmbaddsub.Text = "Sub."
                        End If

                        txtroundoff.Text = dr("ROUNDOFF")

                        TXTREMARKS.Text = Convert.ToString(dr("REMARKS"))
                        TXTBOOKDESC.Text = Convert.ToString(dr("BOOKINGDESC"))
                        CMBNOTES.Text = Convert.ToString(dr("NOTESNAME"))
                        TXTNOTES.Text = Convert.ToString(dr("NOTES"))
                        CMBCANCEL.Text = Convert.ToString(dr("POLICYNAME"))
                        TXTPOLICY.Text = Convert.ToString(dr("POLICY"))

                        'BOOKING DETAILS
                        GRIDBOOKINGS.Rows.Add(dr("BOOKINGSRNO").ToString, dr("HOTELNAME"), dr("CONFNO"), dr("CONFBY"), dr("INCLUSIONS"), Format(Convert.ToDateTime(dr("ARRIVAL")).Date, "dd/MM/yyyy"), Format(Convert.ToDateTime(dr("DEPARTURE")).Date, "dd/MM/yyyy"), dr("ROOMTYPE").ToString, dr("PLAN").ToString, dr("BADULTS"), dr("BCHILDS"), dr("BINFANTS"), dr("BEXTRAADULTS"), dr("BEXTRAADULTSRATE"), dr("BEXTRACHILDS"), dr("BEXTRACHILDSRATE"), dr("BTOTALPAX"), dr("NOOFROOMS").ToString, dr("BPACKAGE"), Format(Val(dr("RATE")), "0.00"), Format(Val(dr("CHILDRATE")), "0.00"), Format(Val(dr("INFANTRATE")), "0.00"), dr("CURCODE"), Val(dr("ROE")), Format(Val(dr("AMT")), "0.00"), Val(dr("NIGHTS")))

                    Next

                    'TOUR DETAILS
                    Dim DTT As DataTable = OBJBOOKING.SELECTBOOKINGTOURDETAILS()
                    If DTT.Rows.Count > 0 Then
                        For Each DRT As DataRow In DTT.Rows
                            If IsDBNull(DRT("IMGPATH")) = False Then GRIDTOUR.Rows.Add(Val(DRT("SRNO")), DRT("HEADER"), DRT("DETAILS"), Image.FromStream(New IO.MemoryStream(DirectCast(DRT("IMGPATH"), Byte())))) Else GRIDTOUR.Rows.Add(Val(DRT("SRNO")), DRT("HEADER"), DRT("DETAILS"), Nothing)
                        Next
                    End If


                    'TRANS DETAILS
                    Dim DT3 As DataTable = OBJBOOKING.SELECTBOOKINGTRANSDETAILS()
                    If DT3.Rows.Count > 0 Then
                        For Each DR2 As DataRow In DT3.Rows
                            GRIDTRANS.Rows.Add(DR2("CARSRNO"), DR2("CONTACTPERSON"), DR2("CONTACTNO"), DR2("CARTYPE"), DR2("CARNAME"), Val(DR2("CARADULTS")), Val(DR2("CARCHILDS")), Val(DR2("CARTOTALPAX")), Format(DR2("PICKUPON"), "dd/MM/yyyy"), DR2("PICKUPFROM"), DR2("PICKUPTIME"), DR2("PICKUPDTLS"), Format(DR2("DROPON"), "dd/MM/yyyy"), DR2("DROPAT"), DR2("DROPTIME"), DR2("DROPDTLS"), Val(DR2("CARDAYS")), DR2("ROUTE"), DR2("CARITINERARY"), DR2("CARNOTE"), Format(Val(DR2("CARAMT")), "0.00"))
                        Next
                    End If

                    'FOLLOWUP GRID
                    Dim OBJCMN As New ClsCommon
                    Dim DTF As DataTable = OBJCMN.search("  HOLIDAYENQMASTER_FOLLOWUP.ENQ_CHK AS FCHK, ISNULL(HOLIDAYENQMASTER_FOLLOWUP.ENQ_NO, '') AS FOLLOWUPNO, ISNULL(HOLIDAYENQMASTER_FOLLOWUP.ENQ_SRNO, 0) AS SRNO, ISNULL(HOLIDAYENQMASTER_FOLLOWUP.ENQ_DATE, '') AS FOLLOWUPDATE, ISNULL(BOOKEDBYMASTER.BOOKEDBY_NAME, '') AS GIVENBY, ISNULL(HOLIDAYENQMASTER_FOLLOWUP.ENQ_GIVENTO, '') AS GIVENTO, ISNULL(STAGEMASTER.STAGE_NAME, '') AS STAGE, ISNULL(HOLIDAYENQMASTER_FOLLOWUP.ENQ_NEXTDATE, '') AS NEXTDATE, ISNULL(HOLIDAYENQMASTER_FOLLOWUP.ENQ_NARRATION, '') AS NARR", "", " HOLIDAYENQMASTER_FOLLOWUP INNER JOIN BOOKEDBYMASTER ON HOLIDAYENQMASTER_FOLLOWUP.ENQ_GIVENBYID = BOOKEDBYMASTER.BOOKEDBY_ID INNER JOIN STAGEMASTER ON HOLIDAYENQMASTER_FOLLOWUP.ENQ_STAGEID = STAGEMASTER.STAGE_ID", " AND ENQ_NO = " & TEMPENQNO & " AND ENQ_YEARID = " & YearId & " ORDER BY ENQ_SRNO")
                    If DTF.Rows.Count > 0 Then
                        For Each DTFOLLOW As DataRow In DTF.Rows
                            GRIDFOLLOW.Rows.Add(DTFOLLOW("FCHK"), DTFOLLOW("SRNO"), Format(Convert.ToDateTime(DTFOLLOW("FOLLOWUPDATE")).Date, "dd/MM/yyyy"), DTFOLLOW("GIVENBY"), DTFOLLOW("GIVENTO"), DTFOLLOW("STAGE"), DTFOLLOW("NEXTDATE"), DTFOLLOW("NARR"))
                            If Convert.ToBoolean(DTFOLLOW("FCHK")) = True Then GRIDFOLLOW.Rows(GRIDFOLLOW.RowCount - 1).DefaultCellStyle.BackColor = Color.LightGreen
                        Next
                    End If

                    'MISC GRID
                    Dim OBJMISC As New ClsCommon
                    Dim DTM As DataTable = OBJMISC.search(" ISNULL(HOLIDAYENQMASTER_MISC.ENQ_SRNO, 0) AS SRNO, ISNULL(HOLIDAYENQMASTER_MISC.ENQ_TYPE, '') AS TYPE, ISNULL(HOLIDAYENQMASTER_MISC.ENQ_REMARKS, '') AS REMARKS ", "", " HOLIDAYENQMASTER INNER JOIN HOLIDAYENQMASTER_MISC ON HOLIDAYENQMASTER.ENQ_NO = HOLIDAYENQMASTER_MISC.ENQ_NO AND HOLIDAYENQMASTER.ENQ_YEARID = HOLIDAYENQMASTER_MISC.ENQ_YEARID ", " AND HOLIDAYENQMASTER_MISC.ENQ_NO = " & Val(TXTAMDENQNO.Text.Trim) & " AND HOLIDAYENQMASTER_MISC.ENQ_YEARID = " & YearId & " ORDER BY HOLIDAYENQMASTER_MISC.ENQ_SRNO ")
                    If DTM.Rows.Count > 0 Then
                        For Each DTROW As DataRow In DTM.Rows
                            GRIDMISC.Rows.Add(Val(DTROW("SRNO")), DTROW("TYPE"), DTROW("REMARKS"))
                        Next
                    End If


                    'GET AIRLINE DATA
                    Dim OBJAIR1 As New ClsCommon
                    Dim DTA1 As DataTable = OBJAIR1.search(" ISNULL(ENQ_NO, 0) AS GROUPDEPNO, ISNULL(ENQ_GRIDSRNO, 0) AS AIRSRNO, ISNULL(ENQ_SECTOR, '') AS SECTOR, ISNULL(ENQ_FLTNO, '') AS FLTNO, ISNULL(ENQ_TYPE, '') AS TYPE, ISNULL(ENQ_BASIC, 0) AS BASIC, ISNULL(ENQ_PSF, 0) AS PSF, ISNULL(ENQ_TAXES, 0) AS TAXES, ISNULL(ENQ_AMT, 0) AS AIRAMT ", "", " HOLIDAYENQMASTER_AIRLINE ", " AND HOLIDAYENQMASTER_AIRLINE.ENQ_NO = " & TEMPENQNO & " AND ENQ_YEARID = " & YearId & " ORDER BY HOLIDAYENQMASTER_AIRLINE.ENQ_GRIDSRNO")
                    If DTA1.Rows.Count > 0 Then
                        For Each DR1 As DataRow In DTA1.Rows
                            GRIDAIRLINE.Rows.Add(DR1("AIRSRNO"), DR1("SECTOR"), DR1("FLTNO"), DR1("TYPE"), Format(Val(DR1("BASIC")), "0.00"), Format(Val(DR1("PSF")), "0.00"), Format(Val(DR1("TAXES")), "0.00"), Format(Val(DR1("AIRAMT")), "0.00"))
                        Next
                        'total()
                    End If


                    'GET GRIDFLIGHT DATA
                    Dim OBJAIR2 As New ClsCommon
                    Dim DTA2 As DataTable = OBJCMN.search(" HOLIDAYENQMASTER_FLIGHTDESC.ENQ_GRIDSRNO AS GRIDSRNO, HOLIDAYENQMASTER_FLIGHTDESC.ENQ_BOOKSRNO AS BOOKSRNO, ISNULL(FROMSECTORMASTER.SECTOR_NAME, '') AS FROMSEC, ISNULL(TOSECTORMASTER.SECTOR_NAME, '') AS TOSEC, HOLIDAYENQMASTER_FLIGHTDESC.ENQ_FLIGHTNO AS FLIGHTNO, HOLIDAYENQMASTER_FLIGHTDESC.ENQ_FLIGHTDATE AS FLIGHTDATE, ISNULL(HOLIDAYENQMASTER_FLIGHTDESC.ENQ_ARRIVES, '') AS ARRIVES, CLASSMASTER.CLASS_NAME AS CLASS", "", " SECTORMASTER AS TOSECTORMASTER RIGHT OUTER JOIN HOLIDAYENQMASTER_FLIGHTDESC LEFT OUTER JOIN CLASSMASTER ON HOLIDAYENQMASTER_FLIGHTDESC.ENQ_YEARID = CLASSMASTER.CLASS_YEARID AND  HOLIDAYENQMASTER_FLIGHTDESC.ENQ_CMPID = CLASSMASTER.CLASS_CMPID AND HOLIDAYENQMASTER_FLIGHTDESC.ENQ_CLASSID = CLASSMASTER.CLASS_ID ON  TOSECTORMASTER.SECTOR_ID = HOLIDAYENQMASTER_FLIGHTDESC.ENQ_TOID AND TOSECTORMASTER.SECTOR_CMPID = HOLIDAYENQMASTER_FLIGHTDESC.ENQ_CMPID AND TOSECTORMASTER.SECTOR_YEARID = HOLIDAYENQMASTER_FLIGHTDESC.ENQ_YEARID LEFT OUTER JOIN SECTORMASTER AS FROMSECTORMASTER ON HOLIDAYENQMASTER_FLIGHTDESC.ENQ_FROMID = FROMSECTORMASTER.SECTOR_ID AND HOLIDAYENQMASTER_FLIGHTDESC.ENQ_CMPID = FROMSECTORMASTER.SECTOR_CMPID AND HOLIDAYENQMASTER_FLIGHTDESC.ENQ_YEARID = FROMSECTORMASTER.SECTOR_YEARID", " AND HOLIDAYENQMASTER_FLIGHTDESC.ENQ_NO = " & TEMPENQNO & " AND HOLIDAYENQMASTER_FLIGHTDESC.ENQ_CMPID = " & CmpId & " AND HOLIDAYENQMASTER_FLIGHTDESC.ENQ_YEARID = " & YearId & " ORDER BY HOLIDAYENQMASTER_FLIGHTDESC.ENQ_BOOKSRNO ASC, HOLIDAYENQMASTER_FLIGHTDESC.ENQ_GRIDSRNO ASC")
                    If dt.Rows.Count > 0 Then
                        For Each DR2 As DataRow In DTA2.Rows
                            GRIDFLIGHT.Rows.Add(DR2("GRIDSRNO").ToString, DR2("BOOKSRNO"), DR2("FROMSEC").ToString, DR2("TOSEC").ToString, DR2("FLIGHTNO").ToString, DR2("FLIGHTDATE").ToString, DR2("ARRIVES").ToString, DR2("CLASS").ToString)
                        Next
                        'total()
                    End If

                    'GRID PURCHASE
                    Dim OBJPUR As New ClsCommon
                    Dim DTP As DataTable = OBJPUR.search(" ISNULL(HOLIDAYENQMASTER_PURCHASE.ENQ_SRNO, 0) AS SRNO, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(HOLIDAYENQMASTER_PURCHASE.ENQ_AMOUNT, 0) AS AMOUNT, ISNULL(CURRENCYMASTER.CUR_CODE, '') AS CURCODE, ISNULL(HOLIDAYENQMASTER_PURCHASE.ENQ_ROE, 0) AS ROE, ISNULL(HOLIDAYENQMASTER_PURCHASE.ENQ_REMARKS, '') AS REMARKS ", "", " HOLIDAYENQMASTER INNER JOIN HOLIDAYENQMASTER_PURCHASE ON HOLIDAYENQMASTER.ENQ_NO = HOLIDAYENQMASTER_PURCHASE.ENQ_NO AND HOLIDAYENQMASTER.ENQ_YEARID = HOLIDAYENQMASTER_PURCHASE.ENQ_YEARID INNER JOIN LEDGERS ON HOLIDAYENQMASTER_PURCHASE.ENQ_NAMEID = LEDGERS.Acc_id LEFT OUTER JOIN CURRENCYMASTER ON ENQ_CURID = CUR_ID", " AND HOLIDAYENQMASTER_PURCHASE.ENQ_NO = " & Val(TXTAMDENQNO.Text.Trim) & " AND HOLIDAYENQMASTER_PURCHASE.ENQ_YEARID = " & YearId & " ORDER BY HOLIDAYENQMASTER_PURCHASE.ENQ_SRNO ")
                    If DTP.Rows.Count > 0 Then
                        For Each DP1 As DataRow In DTP.Rows
                            GRIDPURCHASE.Rows.Add(DP1("SRNO"), DP1("NAME").ToString, Format(Val(DP1("AMOUNT")), "0.00"), DP1("CURCODE"), Format(Val(DP1("ROE")), "0.00"), DP1("REMARKS").ToString)
                        Next
                    End If

                    total()
                    GRIDBOOKINGS.FirstDisplayedScrollingRowIndex = GRIDBOOKINGS.RowCount - 1
                    CMDAMEND.Enabled = False
                Else
                    'IF ROWCOUNT = 0
                    clear()
                    edit = False
                    ENQDATE.Focus()
                End If

            Else
                MsgBox("Invalid Voucher No.", MsgBoxStyle.Critical)
            End If

        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub GRIDPURCHASE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDPURCHASE.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDPURCHASE.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDPURCHASEDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDPURCHASE.Rows.RemoveAt(GRIDPURCHASE.CurrentRow.Index)
                total()
                getsrno(GRIDPURCHASE)


            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBGUESTNAME_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBGUESTNAME.Validated
        Try
            If CMBGUESTNAME.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" ISNULL(GUEST_ADULT,0) AS ADULTS, ISNULL(GUEST_CHILD,0) AS CHILDS, ISNULL(GUEST_INFANT,0) AS INFANTS ", "", " GUESTMASTER ", " AND GUEST_NAME ='" & CMBGUESTNAME.Text.Trim & "' AND GUEST_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    If DT.Rows(0).Item("ADULTS") > 0 Then TXTADULTS.Text = DT.Rows(0).Item("ADULTS")
                    If DT.Rows(0).Item("CHILDS") > 0 Then TXTCHILDS.Text = DT.Rows(0).Item("CHILDS")
                    If DT.Rows(0).Item("INFANTS") > 0 Then TXTNCCHILDS.Text = DT.Rows(0).Item("INFANTS")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDTOUR_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDTOUR.RowEnter
        Try
            If e.RowIndex >= 0 Then PBSOFTCOPY.Image = GRIDTOUR.Rows(e.RowIndex).Cells(GIMGPATH.Index).Value
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTMISCAMT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTMISCAMT.KeyPress, TXTTEMPADULTRATE.KeyPress, TXTTEMPCNBRATE.KeyPress, TXTTEMPCWBRATE.KeyPress, TXTTEMPEXADULTRATE.KeyPress, TXTTEMPINFANTRATE.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTTEMPADULTRATE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTTEMPADULTRATE.Validated, TXTTEMPCNBRATE.Validated, TXTTEMPCWBRATE.Validated, TXTTEMPEXADULTRATE.Validated, TXTTEMPINFANTRATE.Validated
        If CMBQUOTECALC.Text = "Per Person" And ClientName = "KHANNA" Then
            GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(grate.Index).Value = Val(TXTTEMPADULTRATE.Text.Trim)
            GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(GCHILDRATE.Index).Value = Val(TXTTEMPCWBRATE.Text.Trim)
            GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(GINFANTRATE.Index).Value = Val(TXTTEMPINFANTRATE.Text.Trim)
            GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(GEXADURATE.Index).Value = Val(TXTTEMPEXADULTRATE.Text.Trim)
            GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(GEXCHDRATE.Index).Value = Val(TXTTEMPCNBRATE.Text.Trim)
            If GRIDBOOKINGS.RowCount > 0 Then GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(gamt.Index).Value = Format((Val(TXTTEMPADULTRATE.Text.Trim) * Val(TXTADULTS.Text.Trim)) + (Val(TXTTEMPEXADULTRATE.Text.Trim) * Val(GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(GEXTADU.Index).Value)) + (Val(TXTTEMPCNBRATE.Text.Trim) * Val(GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(GEXCHILD.Index).Value)) + (Val(TXTTEMPCWBRATE.Text.Trim) * Val(GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(GCHILD.Index).Value)) + (Val(TXTTEMPINFANTRATE.Text.Trim) * Val(GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(GINFANT.Index).Value)), "0.00")
        End If
    End Sub

    Private Sub CMBINCLUSION_Validated(sender As Object, e As EventArgs) Handles CMBINCLUSION.Validated
        Try
            Dim OBJCMN As New ClsCommon
            TXTINCLUSION.Clear()
            Dim DT As DataTable = OBJCMN.search(" INCLUSION_REMARKS AS INCLUSION", "", " INCLUSIONMASTER", " AND INCLUSION_NAME ='" & CMBINCLUSION.Text.Trim & "' AND INCLUSION_CMPID = " & CmpId & " AND INCLUSION_LOCATIONID = " & Locationid & " AND INCLUSION_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then TXTINCLUSION.Text = DT.Rows(0).Item("INCLUSION")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBINCLUSION_Validating(sender As Object, e As CancelEventArgs) Handles CMBINCLUSION.Validating
        Try
            If CMBINCLUSION.Text.Trim <> "" Then INCLUSIONVALIDATE(CMBINCLUSION, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBINCLUSION_Enter(sender As Object, e As EventArgs) Handles CMBINCLUSION.Enter
        Try
            If CMBINCLUSION.Text.Trim = "" Then FILLINCLUSION(CMBINCLUSION, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBEXCLUSION_Enter(sender As Object, e As EventArgs) Handles CMBEXCLUSION.Enter
        Try
            If CMBEXCLUSION.Text.Trim = "" Then FILLEXCLUSION(CMBEXCLUSION, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBEXCLUSION_Validated(sender As Object, e As EventArgs) Handles CMBEXCLUSION.Validated
        Try
            Dim OBJCMN As New ClsCommon
            TXTEXCLUSION.Clear()
            Dim DT As DataTable = OBJCMN.search(" EXCLUSION_REMARKS AS EXCLUSION", "", " EXCLUSIONMASTER", " AND EXCLUSION_NAME ='" & CMBEXCLUSION.Text.Trim & "' AND EXCLUSION_CMPID = " & CmpId & " AND EXCLUSION_LOCATIONID = " & Locationid & " AND EXCLUSION_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then TXTEXCLUSION.Text = DT.Rows(0).Item("EXCLUSION")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBEXCLUSION_Validating(sender As Object, e As CancelEventArgs) Handles CMBEXCLUSION.Validating
        Try
            If CMBEXCLUSION.Text.Trim <> "" Then EXCLUSIONVALIDATE(CMBEXCLUSION, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class