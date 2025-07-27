
Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports BL
Imports Newtonsoft.Json
Imports RestSharp
Imports TaxProEInvoice.API

Public Class CarBooking

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim gridDoubleClick As Boolean
    Dim gridPURCHASEDoubleClick As Boolean
    Dim gridUPLOADdoubleclick As Boolean
    Dim GRIDCARDOUBLECLICK As Boolean
    Dim GRIDTOURDOUBLECLICK, GRIDAIRDOUBLECLICK As Boolean
    Dim GRIDMISCDOUBLECLICK As Boolean
    Dim temprow As Integer
    Dim tempPURCHASErow As Integer
    Dim tempUPLOADrow As Integer
    Dim TEMPCARROW As Integer
    Dim tempTOURrow As Integer
    Dim tempMISCrow As Integer

    Public edit As Boolean
    Public TEMPBOOKINGNO, tempFLIGHTrow As Integer
    Dim TEMPMSG As Integer
    Dim DDATE As DateTime
    Public Shared SELECTENQ As New DataTable
    Public TEMPENQNO As Integer

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Sub getmax_BOOKING_no()
        Dim DTTABLE As New DataTable
        If ClientName = "UNIGO" Or ClientName = "TRAVELBRIDGE" Or ClientName = "TRAVIZIA" Then
            DTTABLE = getmax(" isnull(MAX(T.BOOKINGNO),0) + 1 ", " (SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM AIRLINEBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM HOTELBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM HOLIDAYPACKAGEMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM CARBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM INTERNATIONALBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM MISCSALMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM RAILBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM VISABOOKING WHERE BOOKING_YEARID = " & YearId & " ) AS T ", "")
        Else
            DTTABLE = getmax(" isnull(max(BOOKING_no),0) + 1 ", "CARBOOKINGMASTER", " AND BOOKING_cmpid=" & CmpId & " and BOOKING_locationid=" & Locationid & " and BOOKING_yearid=" & YearId)
        End If
        If DTTABLE.Rows.Count > 0 Then txtbookingno.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Sub clear()
        Try
            If ClientName = "SKYMAPS" Or ClientName = "BARODA" Or (ClientName = "CLASSIC" And UserName = "Admin") Or ClientName = "GLOBE" Or ClientName = "MILONI" Or ClientName = "NAMASTE" Or ClientName = "UNIGO" Or ClientName = "TRAVELBRIDGE" Then
                txtbookingno.ReadOnly = False
                txtbookingno.Enabled = True
            Else
                txtbookingno.Enabled = True
                txtbookingno.ReadOnly = True
            End If

            'GridMisc
            GRIDMISC.RowCount = 0
            TXTMISCSRNO.Text = 1
            TXTMISCSERVICETYPE.Clear()
            TXTMISCREMARKS.Clear()
            TXTMISCAMT.Clear()
            'TBDETAILS.SelectedIndex = 0


            TXTCOPY.Clear()
            tstxtbillno.Clear()
            CMBGUESTNAME.Text = ""
            txtmobileno.Clear()
            CMBNAME.Text = ""
            CMBTYPE.SelectedIndex = 0
            CMBTOUR.Text = ""
            CMBACCCODE.Text = ""
            LBLACCBAL.Text = 0.0

            PACKAGEFROM.Value = Mydate
            PACKAGETO.Value = Mydate
            TXTPACKAGEDAYS.Text = 1

            TXTHRS.Clear()
            TXTKMS.Clear()
            TXTHRKMRATE.Clear()
            TXTHRSRATE.Clear()
            TXTKMSRATE.Clear()
            CHKRATE.CheckState = CheckState.Unchecked
            GROUPRATE.Enabled = False

            TXTHRSPUR.Clear()
            TXTKMSPUR.Clear()
            TXTHRKMRATEPUR.Clear()
            TXTHRSRATEPUR.Clear()
            TXTKMSRATEPUR.Clear()
            CHKRATEPUR.CheckState = CheckState.Unchecked
            GROUPRATEPUR.Enabled = False

            TXTALLOWANCEPUR.Clear()
            TXTNIGHTALLOWANCEPUR.Clear()

            TXTSUNDAYS.Clear()
            TXTSUNDAYSRATE.Clear()
            TXTEXTRADROP.Clear()
            TXTEXTRADROPRATE.Clear()
            TXTOUTSTATIONDAYS.Clear()
            TXTOUTSTATIONDAYSRATE.Clear()

            TXTSTATECODE.Clear()
            TXTPURSTATECODE.Clear()
            TXTHSNCODE.Clear()
            TXTCGSTPER.Clear()
            TXTCGSTAMT.Clear()
            TXTSGSTPER.Clear()
            TXTSGSTAMT.Clear()
            TXTIGSTPER.Clear()
            TXTIGSTAMT.Clear()

            txtrefno.Clear()
            bookingdate.Value = Mydate
            txtbookingno.Clear()

            TXTSRNO.Text = 1
            CARPICKDATE.Value = Mydate
            CARDROPDATE.Value = DateAdd(DateInterval.Day, 1, Mydate)
            TXTRUNHRS.Clear()
            TXTRUNKMS.Clear()
            TXTEXTRAHRS.Clear()
            TXTEXTRAKMS.Clear()
            TXTTOTALRUNHRS.Clear()
            TXTTOTALRUNKMS.Clear()
            TXTTOTALEXTRAHRS.Clear()
            TXTTOTALEXTRAKMS.Clear()
            TXTARRIVALFROM.Clear()
            TXTDEPARTURETO.Clear()

            GRIDDETAILS.RowCount = 0
            GRIDCARDTLS.RowCount = 0

            TXTCARQUALITY.Clear()
            TXTDRIVERQUALITY.Clear()
            TXTCONFIRMEDBY.Clear()

            TXTCARSRNO.Text = 1
            CMBDRIVER.Text = ""
            CMBCARNAME.Text = ""
            CMBVEHICLENO.Text = ""
            If ClientName = "SCC" Or ClientName = "TRAVCON" Then TXTCARADULTS.Text = 1 Else TXTCARADULTS.Text = 0
            TXTCARCHILDS.Text = 0.0
            TXTCARTOTALPAX.Text = 0
            TXTCARTOTALAMT.Text = 0.0
            PICKUPDATE.Value = Mydate
            TXTPICKFROM.Clear()
            TXTPICKTIME.Clear()
            TXTPICKDTLS.Clear()
            DROPDATE.Value = DateAdd(DateInterval.Day, 1, Mydate)
            TXTDROPAT.Clear()
            TXTDROPTIME.Clear()
            TXTDROPDTLS.Clear()
            TXTROUTE.Clear()
            TXTCARNOTE.Clear()
            TXTCARAMT.Clear()
            TXTAPPHRS.Clear()
            TXTAPPKMS.Clear()
            GRIDTRANS.RowCount = 0

            TXTTOURSRNO.Text = 1
            TOURDATE.Value = Mydate
            TXTTOURDETAILS.Clear()
            GRIDTOUR.RowCount = 0

            TXTPURSRNO.Text = 1
            CMBPURCODE.Text = ""
            CMBPURNAME.Text = ""
            PURDATE.Value = Mydate
            TXTPURHSNCODE.Clear()

            TXTPURAMT.Text = 0.0
            TXTDISCRECDPER.Text = 0.0
            TXTDISCRECDRS.Text = 0.0
            TXTPURSUBTOTAL.Text = 0.0
            TXTCOMMRECDPER.Text = 0.0
            TXTCOMMRECDRS.Text = 0.0
            TXTPURTDSRS.Text = 0.0
            CHKPURSERVTAX.CheckState = CheckState.Unchecked
            TXTPURSERVCHGS.Text = 0.0

            TXTPURNETTAMT.Text = 0.0
            CMBPURTAX.Text = ""
            TXTPURTAX.Text = 0.0

            TXTPURCGSTPER.Text = 0.0
            TXTPURCGSTAMT.Text = 0.0
            TXTPURSGSTPER.Text = 0.0
            TXTPURSGSTAMT.Text = 0.0
            TXTPURIGSTPER.Text = 0.0
            TXTPURIGSTAMT.Text = 0.0

            CMBPUROTHERCHGS.Text = ""
            TXTPUROTHERCHGS.Text = 0.0
            TXTPURROUNDOFF.Text = 0.0
            TXTPURGTOTAL.Text = 0.0
            TXTFINALPURAMT.Text = 0.0
            GRIDPURCHASE.RowCount = 0

            PBSoftCopy.ImageLocation = ""
            txtuploadsrno.Text = 1
            txtuploadname.Clear()
            txtuploadremarks.Clear()
            TXTFILENAME.Clear()
            TXTNEWIMGPATH.Clear()
            txtimgpath.Clear()
            gridupload.RowCount = 0

            cmdshowdetails.Visible = False
            PBRECD.Visible = False
            PBPAID.Visible = False
            PBlock.Visible = False
            lbllocked.Visible = False
            lblcancelled.Visible = False
            PBCancelled.Visible = False
            PBCN.Visible = False
            LBLEINVGENERATED.Visible = False

            txttax.ReadOnly = True
            txttax.Enabled = False

            TBDETAILS.SelectedIndex = 0

            TXTTOTALSALEAMT.Text = 0.0
            TXTOURCOMMPER.Text = 0.0
            TXTOURCOMMRS.Text = 0.0
            TXTDISCPER.Text = 0.0
            TXTDISCRS.Text = 0.0
            TXTEXTRACHGS.Text = 0.0
            TXTSUBTOTAL.Text = 0.0
            cmbtax.Text = ""
            txttax.Text = 0.0
            CMBADDTAX.Text = ""
            TXTADDTAX.Text = 0.0
            CHKTAXSERVCHGS.CheckState = CheckState.Unchecked
            TXTTAXSERVCHGS.Text = 0.0

            If ClientName = "SCC" Then
                cmbaddsub.SelectedIndex = 1
                CMBOTHERCHGS.Text = "Toll & Parking"
                CMBPUROTHERCHGS.Text = "Toll & Parking"
            Else
                cmbaddsub.SelectedIndex = 0
                CMBOTHERCHGS.Text = ""
                CMBPUROTHERCHGS.Text = ""
            End If
            txtotherchg.Text = 0.0
            txtroundoff.Text = 0.0
            txtgrandtotal.Text = 0.0
            TXTBAL.Clear()

            CMBBOOKEDBY.Text = ""
            CMBSOURCE.Text = ""
            TXTSTART.Clear()
            TXTEND.Clear()
            TXTSALETOTALKMS.Clear()
            TXTSALEEXTRAKMS.Clear()
            TXTSTARTTIME.Clear()
            TXTENDTIME.Clear()
            TXTSALETOTALTIME.Clear()
            TXTSALEEXTRATIME.Clear()
            TXTPURSTART.Clear()
            TXTPUREND.Clear()
            TXTPURTOTALKMS.Clear()
            TXTPUREXTRAKMS.Clear()
            TXTPURSTARTTIME.Clear()
            TXTPURENDTIME.Clear()
            TXTPURTOTALTIME.Clear()
            TXTPUREXTRATIME.Clear()
            TXTMISCENQNO.Clear()
            cmbcity.Text = ""
            CMBGROUPDEPARTURE.Text = ""
            CMBGROUPDEPARTURE.Enabled = True

            If ClientName = "CLASSIC" Then
                TXTREMARKS.Text = "Room bill to CLASSIC TRAVEL SHOPPE PVT. LTD. & Extra or Direct Payment if any, payment to be collected directly from Guest."
            ElseIf ClientName = "TOPCOMM" Then
                LBLREFNO.Text = "Tracking ID"
                TXTREMARKS.Clear()
            Else
                TXTREMARKS.Text = "As per Standard Rates billed to " & CmpName & " & Extra if any, payment to be collected direct from Guest."
            End If

            TXTBOOKINGDESC.Clear()
            TXTSPECIALREMARKS.Clear()
            TXTPICKUP.Clear()

            txtinwords.Clear()
            chkdispute.CheckState = CheckState.Unchecked
            CHKBILLCHECK.CheckState = CheckState.Unchecked

            EP.Clear()
            gridDoubleClick = False
            gridPURCHASEDoubleClick = False
            gridUPLOADdoubleclick = False
            GRIDCARDOUBLECLICK = False
            GRIDTOURDOUBLECLICK = False
            GRIDMISCDOUBLECLICK = False
            GRIDAIRDOUBLECLICK = False

            getmax_BOOKING_no()

            If UserName = "Admin" Or ClientName = "KHANNA" Then
                CMBBOOKEDBY.Enabled = True
            Else
                CMBBOOKEDBY.Enabled = False
                CMBBOOKEDBY.Text = UserName
            End If

            'GridAir
            GRIDAIRLINE.RowCount = 0
            GRIDSECTOR.RowCount = 0
            GRIDFLIGHT.RowCount = 0
            TXTAIRSRNO.Text = 1
            TXTSECTOR.Clear()
            TXTTEMPSECTOR.Clear()
            TXTFLTNO.Clear()
            CMBAIRLINETYPE.SelectedIndex = 0
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

            GRIDAIRLINE.RowCount = 0

            CHKMANUAL.CheckState = CheckState.Unchecked
            CHKPURMANUAL.CheckState = CheckState.Unchecked
            TXTIRNNO.Clear()
            TXTACKNO.Clear()
            ACKDATE.Value = Now.Date
            PBQRCODE.Image = Nothing

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        clear()
        edit = False
        bookingdate.Focus()
    End Sub

    Private Sub CarBooking_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNoCancel)
                If tempmsg = vbYes Then
                    If errorvalid() = True Then cmdok_Click(sender, e)
                ElseIf tempmsg = vbCancel Then
                    Exit Sub
                End If
                Me.Close()
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D Then       'for Delete
                Call CMDDELETE_Click(sender, e)
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
            ElseIf e.KeyCode = Keys.P And e.Alt = True Then
                Call ToolStripprint_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
                Dim OBJINVDTLS As New CarBookingDetails
                OBJINVDTLS.MdiParent = MDIMain
                OBJINVDTLS.Show()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub


    Sub fillcmb()
        Try
            If CMBGUESTNAME.Text.Trim = "" Then FILLGUESTNAME(CMBGUESTNAME, edit)
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'")
            FILLGROUPNAME(CMBGROUPDEPARTURE, " AND GROUPDEP_FROM > '" & Format(Convert.ToDateTime(bookingdate.Text).Date, "MM/dd/yyyy") & "'")
            If CMBSOURCE.Text.Trim = "" Then FILLSOURCE(CMBSOURCE, edit)
            If CMBBOOKEDBY.Text.Trim = "" Then FILLBOOKEDBY(CMBBOOKEDBY, edit)
            If cmbtax.Text.Trim = "" Then filltax(cmbtax, edit)
            If CMBPURTAX.Text.Trim = "" Then filltax(CMBPURTAX, edit)
            If CMBOTHERCHGS.Text.Trim = "" Then fillname(CMBOTHERCHGS, edit, " AND (GROUP_SECONDARY = 'INDIRECT EXPENSES' OR GROUP_SECONDARY = 'INDIRECT INCOME' OR GROUP_SECONDARY = 'DIRECT EXPENSES' OR GROUP_SECONDARY = 'DIRECT INCOME')")
            If CMBPUROTHERCHGS.Text.Trim = "" Then fillname(CMBPUROTHERCHGS, edit, " AND (GROUP_SECONDARY = 'INDIRECT EXPENSES' OR GROUP_SECONDARY = 'INDIRECT INCOME' OR GROUP_SECONDARY = 'DIRECT EXPENSES' OR GROUP_SECONDARY = 'DIRECT INCOME')")
            If CMBDRIVER.Text.Trim = "" Then FILLDRIVERNAME(CMBDRIVER, edit)
            If CMBCARNAME.Text.Trim = "" Then FILLVEHICLE(CMBCARNAME, edit, "")
            If CMBTOUR.Text.Trim = "" Then FILLTOURNAME(CMBTOUR, edit, "")
            If cmbcity.Text.Trim = "" Then fillcity(cmbcity)
            If CMBHSNITEMDESC.Text.Trim = "" Then FILLHSNITEMDESC(CMBHSNITEMDESC)
            If CMBPURHSNITEMDESC.Text.Trim = "" Then FILLHSNITEMDESC(CMBPURHSNITEMDESC)

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CarBooking_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'CAR RENTAL'")
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
                Dim OBJBOOKING As New ClsCarBooking()

                ALPARAVAL.Add(TEMPBOOKINGNO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                OBJBOOKING.alParaval = ALPARAVAL
                Dim dt As DataTable = OBJBOOKING.SELECTBOOKINGDESC()
                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows

                        txtbookingno.ReadOnly = True
                        txtbookingno.Enabled = False

                        txtbookingno.Text = TEMPBOOKINGNO

                        bookingdate.Value = Convert.ToDateTime(dr("BOOKINGDATE")).Date
                        DDATE = bookingdate.Value
                        txtrefno.Text = dr("REFNO")

                        CMBGUESTNAME.Text = Convert.ToString(dr("GUESTNAME"))
                        CMBPREFIX.Text = Convert.ToString(dr("PREFIX"))
                        CMBACCCODE.Text = Convert.ToString(dr("ACCCODE"))
                        CMBNAME.Text = Convert.ToString(dr("NAME"))
                        CMBTYPE.Text = Convert.ToString(dr("TYPE"))
                        CMBTOUR.Text = Convert.ToString(dr("TOURNAME"))

                        PACKAGEFROM.Value = Convert.ToDateTime(dr("PACKAGEFROM")).Date
                        PACKAGETO.Value = Convert.ToDateTime(dr("PACKAGETO")).Date

                        If Val(dr("HRKMRATE")) > 0 Or Val(dr("HRSRATE")) > 0 Or Val(dr("KMSRATE")) > 0 Then
                            CHKRATE.CheckState = CheckState.Checked
                            TXTHRS.Text = Val(Convert.ToString(dr("HRS")))
                            TXTKMS.Text = Val(Convert.ToString(dr("KMS")))
                            TXTHRKMRATE.Text = Format(Val(Convert.ToString(dr("HRKMRATE"))), "0.00")
                            TXTHRSRATE.Text = Format(Val(Convert.ToString(dr("HRSRATE"))), "0.00")
                            TXTKMSRATE.Text = Format(Val(Convert.ToString(dr("KMSRATE"))), "0.00")
                        End If

                        If Val(dr("HRKMRATEPUR")) > 0 Or Val(dr("HRSRATEPUR")) > 0 Or Val(dr("KMSRATEPUR")) > 0 Then
                            CHKRATEPUR.CheckState = CheckState.Checked
                            TXTHRSPUR.Text = Val(Convert.ToString(dr("HRSPUR")))
                            TXTKMSPUR.Text = Val(Convert.ToString(dr("KMSPUR")))
                            TXTHRKMRATEPUR.Text = Format(Val(Convert.ToString(dr("HRKMRATEPUR"))), "0.00")
                            TXTHRSRATEPUR.Text = Format(Val(Convert.ToString(dr("HRSRATEPUR"))), "0.00")
                            TXTKMSRATEPUR.Text = Format(Val(Convert.ToString(dr("KMSRATEPUR"))), "0.00")
                        End If

                        TXTALLOWANCEPUR.Text = Format(Val(Convert.ToString(dr("ALLOWANCEPUR"))), "0.00")
                        TXTNIGHTALLOWANCEPUR.Text = Format(Val(Convert.ToString(dr("NIGHTALLOWANCEPUR"))), "0.00")

                        TXTSUNDAYS.Text = Val(Convert.ToString(dr("SUNDAYS")))
                        TXTSUNDAYSRATE.Text = Format(Val(Convert.ToString(dr("SUNDAYSRATE"))), "0.00")
                        TXTEXTRADROP.Text = Val(Convert.ToString(dr("EXTRADROP")))
                        TXTEXTRADROPRATE.Text = Format(Val(Convert.ToString(dr("EXTRADROPRATE"))), "0.00")
                        TXTOUTSTATIONDAYS.Text = Val(Convert.ToString(dr("OUTSTATIONDAYS")))
                        TXTOUTSTATIONDAYSRATE.Text = Format(Val(Convert.ToString(dr("OUTSTATIONDAYSRATE"))), "0.00")




                        cmbcity.Text = Convert.ToString(dr("CITY"))

                        TXTSTATECODE.Text = dr("STATECODE")
                        ' TXTPURSTATECODE.Text = dr("PURSTATECODE")
                        CMBHSNITEMDESC.Text = dr("HSNITEMDESC")
                        TXTHSNCODE.Text = dr("HSNCODE")

                        If Convert.ToBoolean(dr("MANUALGST")) = False Then CHKMANUAL.Checked = False Else CHKMANUAL.Checked = True
                        If Convert.ToBoolean(dr("PURMANUALGST")) = False Then CHKPURMANUAL.Checked = False Else CHKPURMANUAL.Checked = True

                        If CHKMANUAL.Checked = True Then
                            TXTCGSTAMT.Text = Format(Val(dr("CGSTAMT")), "0.00")
                            TXTSGSTAMT.Text = Format(Val(dr("SGSTAMT")), "0.00")
                            TXTIGSTAMT.Text = Format(Val(dr("IGSTAMT")), "0.00")
                        End If

                        TXTCGSTPER.Text = Format(Val(Convert.ToString(dr("CGSTPER"))), "0.00")
                        TXTCGSTAMT.Text = Format(Val(Convert.ToString(dr("CGSTAMT"))), "0.00")
                        TXTSGSTPER.Text = Format(Val(Convert.ToString(dr("SGSTPER"))), "0.00")
                        TXTSGSTAMT.Text = Format(Val(Convert.ToString(dr("SGSTAMT"))), "0.00")
                        TXTIGSTPER.Text = Format(Val(Convert.ToString(dr("IGSTPER"))), "0.00")
                        TXTIGSTAMT.Text = Format(Val(Convert.ToString(dr("IGSTAMT"))), "0.00")

                        TXTARRIVALFROM.Text = Convert.ToString(dr("ARRIVAL"))
                        TXTDEPARTURETO.Text = Convert.ToString(dr("DEPARTURE"))

                        CMBBOOKEDBY.Text = dr("BOOKEDBY")
                        CMBSOURCE.Text = dr("SOURCE")
                        TXTMISCENQNO.Text = dr("MISCENQNO")

                        TXTTOTALSALEAMT.Text = dr("TOTALSALEAMT")
                        TXTOURCOMMPER.Text = dr("OURCOMMPER")
                        TXTOURCOMMRS.Text = dr("OURCOMMRS")
                        TXTDISCPER.Text = dr("DISCPER")
                        TXTDISCRS.Text = dr("DISCRS")
                        TXTEXTRACHGS.Text = dr("EXTRACHGS")

                        cmbtax.Text = dr("TAXNAME")
                        txttax.Text = dr("TAXAMT")
                        CMBADDTAX.Text = dr("ADDTAXNAME")
                        TXTADDTAX.Text = dr("ADDTAXAMT")

                        CHKTAXSERVCHGS.Checked = Convert.ToBoolean(dr("TAXSERVCHGS"))
                        TXTTAXSERVCHGS.Text = dr("TAXSERVCHGSAMT")
                        If ClientName = "SCC" Then
                            CMBOTHERCHGS.Text = "Toll & Parking"
                            cmbaddsub.Text = "Add"
                            txtotherchg.Text = dr("OTHERCHGS")
                        Else
                            CMBOTHERCHGS.Text = dr("OTHERCHGSNAME")
                            If dr("OTHERCHGS") > 0 Then
                                txtotherchg.Text = dr("OTHERCHGS")
                                cmbaddsub.Text = "Add"
                            Else
                                txtotherchg.Text = dr("OTHERCHGS") * (-1)
                                cmbaddsub.Text = "Sub."
                            End If
                        End If


                        txtroundoff.Text = dr("ROUNDOFF")

                        TXTSALEAMTREC.Text = dr("SALEAMTREC")
                        TXTSALEEXTRAAMT.Text = dr("SALEEXTRAAMT")
                        TXTSALERETURN.Text = dr("SALERETURN")
                        TXTSALEBAL.Text = dr("SALEBAL")
                        TXTBAL.Text = dr("SALEBAL")

                        TXTSTART.Text = Val(dr("STARTKMS"))
                        TXTEND.Text = Val(dr("ENDKMS"))
                        TXTSTARTTIME.Text = Val(dr("STARTTIME"))
                        TXTENDTIME.Text = Val(dr("ENDTIME"))
                        TXTPURSTART.Text = Val(dr("PURSTARTKMS"))
                        TXTPUREND.Text = Val(dr("PURENDKMS"))
                        TXTPURSTARTTIME.Text = Val(dr("PURSTARTTIME"))
                        TXTPURENDTIME.Text = Val(dr("PURENDTIME"))

                        TXTCARQUALITY.Text = Convert.ToString(dr("CARQUALITY"))
                        TXTDRIVERQUALITY.Text = Convert.ToString(dr("DRIVERQUALITY"))
                        TXTCONFIRMEDBY.Text = Convert.ToString(dr("CONFIRMEDBY"))
                        TXTREMARKS.Text = Convert.ToString(dr("REMARKS"))
                        TXTBOOKINGDESC.Text = Convert.ToString(dr("BOOKINGDESC"))
                        TXTSPECIALREMARKS.Text = Convert.ToString(dr("SPECIALREMARKS"))
                        CMBGROUPDEPARTURE.Text = Convert.ToString(dr("GROUPDEPART"))
                        'If dr("GROUPDEPART") <> "" Then CMBGROUPDEPARTURE.Enabled = False

                        If Val(dr("SALEAMTREC")) > 0 Or Val(dr("SALEEXTRAAMT")) > 0 Then
                            PBRECD.Visible = True
                            cmdshowdetails.Visible = True
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If


                        If Val(dr("SALERETURN")) > 0 Then
                            cmdshowdetails.Visible = True
                            PBCN.Visible = True
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If


                        If Convert.ToBoolean(dr("DONE")) = True Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                        chkdispute.Checked = Convert.ToBoolean(dr("DISPUTE"))
                        CHKBILLCHECK.Checked = Convert.ToBoolean(dr("BILLCHECKED"))


                        'TRANS DETAILS
                        GRIDTRANS.Rows.Add(dr("SRNO"), dr("DRIVERNAME"), dr("CARNAME"), dr("CARNO"), Val(dr("ADULTS")), Val(dr("CHILDS")), Val(dr("TOTALPAX")), Format(Convert.ToDateTime(dr("PICKUPON")).Date, "dd/MM/yyyy"), dr("PICKUPFROM"), dr("PICKUPTIME"), dr("PICKUPDTLS"), Format(Convert.ToDateTime(dr("DROPON")).Date, "dd/MM/yyyy"), dr("DROPAT"), dr("DROPTIME"), dr("DROPDTLS"), Val(dr("DAYS")), dr("ROUTE"), dr("CARNOTE"), Val(dr("APPROXHRS")), Val(dr("APPROXKMS")), Format(Val(dr("ALLOWANCE")), "0.00"), Format(Val(dr("CARAMT")), "0.00"))

                        TXTIRNNO.Text = dr("IRNNO")
                        TXTACKNO.Text = dr("ACKNO")
                        ACKDATE.Value = dr("ACKDATE")
                        If IsDBNull(dr("QRCODE")) = False Then
                            PBQRCODE.Image = Image.FromStream(New IO.MemoryStream(DirectCast(dr("QRCODE"), Byte())))
                        Else
                            PBQRCODE.Image = Nothing
                        End If

                    Next
                    GRIDTRANS.FirstDisplayedScrollingRowIndex = GRIDTRANS.RowCount - 1

                Else
                    'IF ROWCOUNT = 0
                    clear()
                    edit = False
                    CMBGUESTNAME.Focus()
                End If

                'TOUR DETAILS
                dt = OBJBOOKING.SELECTBOOKINGTOURDETAILS()
                If dt.Rows.Count > 0 Then
                    For Each DR As DataRow In dt.Rows
                        GRIDTOUR.Rows.Add(DR("TOURSRNO"), Format(DR("TOURDATE"), "dd/MM/yyyy"), DR("TOURDETAILS"))
                    Next
                End If


                'DUTYSLIP GRID
                ''DETAILS
                'dt = OBJBOOKING.SELECTBOOKINGDUTYSLIP()
                'If dt.Rows.Count > 0 Then
                '    For Each DR As DataRow In dt.Rows
                '        GRIDCARDTLS.Rows.Add(DR("CARSRNO"), Format(Convert.ToDateTime(DR("PICKDATE")).Date, "dd/MM/yyyy"), Format(Convert.ToDateTime(DR("DROPDATE")).Date, "dd/MM/yyyy"), DR("START"), DR("END"), DR("INTIME"), DR("OUTTIME"), DR("RUNHRS"), DR("RUNKMS"), DR("EXTRAHRS"), DR("EXTRAKMS"), DR("MAINSRNO"))
                '    Next
                'End If



                'PURCHASE DETAILS
                dt = OBJBOOKING.SELECTBOOKINGPURDETAILS()

                If dt.Rows.Count > 0 Then
                    For Each DR As DataRow In dt.Rows
                        'DONT FETCH STATECODE HERE... THERE MAY BE MULTIPLE VENDORS
                        'TXTPURSTATECODE.Text = DR("PURSTATECODE")
                        GRIDPURCHASE.Rows.Add(DR("PURBILLCHECKED"), DR("PURSRNO"), DR("PURNAME"), Format(Convert.ToDateTime(DR("PURDATE")).Date, "dd/MM/yyyy"), DR("PURHSNITEMDESC"), DR("PURHSNCODE"), DR("PURAMT"), DR("PURDISCPER"), DR("PURDISC"), DR("PURSUBTOTAL"), DR("PURCOMMPER"), DR("PURCOMM"), DR("PURTDSPER"), DR("PURTDS"), DR("PURSERVTAX"), DR("PURTAXSERVCHGS"), DR("PURNETT"), DR("TAXNAME"), DR("TAXAMT"), DR("PURCGSTPER"), DR("PURCGSTAMT"), DR("PURSGSTPER"), DR("PURSGSTAMT"), DR("PURIGSTPER"), DR("PURIGSTAMT"), DR("PUROTHERCHGSNAME"), DR("PUROTHERCHGS"), DR("PURROUNDOFF"), DR("PURGTOTAL"), DR("PURAMTPAID"), DR("PUREXTRAAMT"), DR("PURRETURN"), DR("PURBALANCE"))
                        If Convert.ToBoolean(DR("PURBILLCHECKED")) = True Then GRIDPURCHASE.Rows(GRIDPURCHASE.RowCount - 1).DefaultCellStyle.BackColor = Color.LightGreen
                        If Val(DR("PURAMTPAID")) > 0 Or Val(DR("PUREXTRAAMT")) > 0 Then
                            cmdshowdetails.Visible = True
                            PBPAID.Visible = True
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If
                    Next
                    GRIDPURCHASE.ClearSelection()
                End If


                'GET SCAN DOCS DATA
                Dim OBJCMN As New ClsCommon
                dt = OBJCMN.search(" CARBOOKINGMASTER_UPLOAD.BOOKING_GRIDSRNO AS GRIDSRNO, CARBOOKINGMASTER_UPLOAD.BOOKING_REMARKS AS REMARKS, CARBOOKINGMASTER_UPLOAD.BOOKING_NAME AS NAME, CARBOOKINGMASTER_UPLOAD.BOOKING_IMGPATH AS IMGPATH, CARBOOKINGMASTER_UPLOAD.BOOKING_NEWIMGPATH AS NEWIMGPATH ", "", " CARBOOKINGMASTER_UPLOAD ", " AND CARBOOKINGMASTER_UPLOAD.BOOKING_NO = " & TEMPBOOKINGNO & " AND CARBOOKINGMASTER_UPLOAD.BOOKING_CMPID = " & CmpId & " AND  CARBOOKINGMASTER_UPLOAD.BOOKING_LOCATIONID  = " & Locationid & " AND CARBOOKINGMASTER_UPLOAD.BOOKING_YEARID = " & YearId & " ORDER BY CARBOOKINGMASTER_UPLOAD.BOOKING_GRIDSRNO")
                If dt.Rows.Count > 0 Then
                    For Each DTR As DataRow In dt.Rows
                        gridupload.Rows.Add(DTR("GRIDSRNO"), DTR("REMARKS"), DTR("NAME"), DTR("IMGPATH"), DTR("NEWIMGPATH"))
                    Next
                End If
                CALC()
                CALCKMSTIME()
                CALCPUR()
                total()
                chkchange.CheckState = CheckState.Checked

            End If
            'MISC GRID
            Dim OBJMISC As New ClsCommon
            Dim DTM As DataTable = OBJMISC.search(" ISNULL(CARBOOKINGMASTER_MISC.ENQ_SRNO, 0) AS SRNO, ISNULL(CARBOOKINGMASTER_MISC.ENQ_TYPE, '') AS TYPE, ISNULL(CARBOOKINGMASTER_MISC.ENQ_REMARKS, '') AS REMARKS, ISNULL(CARBOOKINGMASTER_MISC.ENQ_AMOUNT, 0) AS MISCAMOUNT ", "", " CARBOOKINGMASTER INNER JOIN CARBOOKINGMASTER_MISC ON CARBOOKINGMASTER.BOOKING_NO = CARBOOKINGMASTER_MISC.ENQ_NO AND CARBOOKINGMASTER.BOOKING_YEARID = CARBOOKINGMASTER_MISC.ENQ_YEARID ", " AND CARBOOKINGMASTER_MISC.ENQ_NO = " & TEMPBOOKINGNO & " AND CARBOOKINGMASTER_MISC.ENQ_YEARID = " & YearId & " ORDER BY CARBOOKINGMASTER_MISC.ENQ_SRNO ")
            If DTM.Rows.Count > 0 Then
                For Each DR As DataRow In DTM.Rows
                    GRIDMISC.Rows.Add(Val(DR("SRNO")), DR("TYPE"), DR("REMARKS"), Val(DR("MISCAMOUNT")))
                Next
            End If

            'GET AIRLINE DATA
            Dim OBJAIR1 As New ClsCommon
            Dim DTA1 As DataTable = OBJAIR1.search(" ISNULL(BOOKING_NO, 0) AS GROUPDEPNO, ISNULL(BOOKING_GRIDSRNO, 0) AS AIRSRNO, ISNULL(BOOKING_SECTOR, '') AS SECTOR, ISNULL(BOOKING_FLTNO, '') AS FLTNO, ISNULL(CARBOOKINGMASTER_AIRLINE.BOOKING_TYPE, '') AS AIRLINETYPE, ISNULL(BOOKING_BASIC, 0) AS BASIC, ISNULL(BOOKING_PSF, 0) AS PSF, ISNULL(BOOKING_TAXES, 0) AS TAXES, ISNULL(BOOKING_AMT, 0) AS AIRAMT ", "", " CARBOOKINGMASTER_AIRLINE ", " AND CARBOOKINGMASTER_AIRLINE.BOOKING_NO = " & TEMPBOOKINGNO & " AND BOOKING_YEARID = " & YearId & " ORDER BY CARBOOKINGMASTER_AIRLINE.BOOKING_GRIDSRNO")
            If DTA1.Rows.Count > 0 Then
                For Each DR1 As DataRow In DTA1.Rows
                    GRIDAIRLINE.Rows.Add(DR1("AIRSRNO"), DR1("SECTOR"), DR1("FLTNO"), DR1("AIRLINETYPE"), Format(Val(DR1("BASIC")), "0.00"), Format(Val(DR1("PSF")), "0.00"), Format(Val(DR1("TAXES")), "0.00"), Format(Val(DR1("AIRAMT")), "0.00"))
                Next
                total()
            End If

            'GET GRIDFLIGHT DATA
            Dim OBJAIR2 As New ClsCommon
            Dim DTA2 As DataTable = OBJAIR2.search(" CARBOOKINGMASTER_FLIGHTDESC.BOOKING_GRIDSRNO AS GRIDSRNO, CARBOOKINGMASTER_FLIGHTDESC.BOOKING_BOOKSRNO AS BOOKSRNO, ISNULL(FROMSECTORMASTER.SECTOR_NAME, '') AS FROMSEC, ISNULL(TOSECTORMASTER.SECTOR_NAME, '') AS TOSEC, CARBOOKINGMASTER_FLIGHTDESC.BOOKING_FLIGHTNO AS FLIGHTNO, CARBOOKINGMASTER_FLIGHTDESC.BOOKING_FLIGHTDATE AS FLIGHTDATE, ISNULL(CARBOOKINGMASTER_FLIGHTDESC.BOOKING_ARRIVES, '') AS ARRIVES, CLASSMASTER.CLASS_NAME AS CLASS", "", " SECTORMASTER AS TOSECTORMASTER RIGHT OUTER JOIN CARBOOKINGMASTER_FLIGHTDESC LEFT OUTER JOIN CLASSMASTER ON CARBOOKINGMASTER_FLIGHTDESC.BOOKING_YEARID = CLASSMASTER.CLASS_YEARID AND  CARBOOKINGMASTER_FLIGHTDESC.BOOKING_CMPID = CLASSMASTER.CLASS_CMPID AND CARBOOKINGMASTER_FLIGHTDESC.BOOKING_CLASSID = CLASSMASTER.CLASS_ID ON  TOSECTORMASTER.SECTOR_ID = CARBOOKINGMASTER_FLIGHTDESC.BOOKING_TOID AND TOSECTORMASTER.SECTOR_CMPID = CARBOOKINGMASTER_FLIGHTDESC.BOOKING_CMPID AND TOSECTORMASTER.SECTOR_YEARID = CARBOOKINGMASTER_FLIGHTDESC.BOOKING_YEARID LEFT OUTER JOIN SECTORMASTER AS FROMSECTORMASTER ON CARBOOKINGMASTER_FLIGHTDESC.BOOKING_FROMID = FROMSECTORMASTER.SECTOR_ID AND CARBOOKINGMASTER_FLIGHTDESC.BOOKING_CMPID = FROMSECTORMASTER.SECTOR_CMPID AND CARBOOKINGMASTER_FLIGHTDESC.BOOKING_YEARID = FROMSECTORMASTER.SECTOR_YEARID", " AND CARBOOKINGMASTER_FLIGHTDESC.BOOKING_NO = " & TEMPBOOKINGNO & " AND CARBOOKINGMASTER_FLIGHTDESC.BOOKING_CMPID = " & CmpId & " AND CARBOOKINGMASTER_FLIGHTDESC.BOOKING_YEARID = " & YearId & " ORDER BY CARBOOKINGMASTER_FLIGHTDESC.BOOKING_BOOKSRNO ASC, CARBOOKINGMASTER_FLIGHTDESC.BOOKING_GRIDSRNO ASC")
            If DTA2.Rows.Count > 0 Then
                For Each DR2 As DataRow In DTA2.Rows
                    GRIDFLIGHT.Rows.Add(DR2("GRIDSRNO").ToString, DR2("BOOKSRNO"), DR2("FROMSEC").ToString, DR2("TOSEC").ToString, DR2("FLIGHTNO").ToString, DR2("FLIGHTDATE").ToString, DR2("ARRIVES").ToString, DR2("CLASS").ToString)
                Next
                total()
            End If
            If TXTIRNNO.Text <> "" And TXTACKNO.Text <> "" Then
                LBLEINVGENERATED.Visible = True
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

            EP.Clear()
            If Not CALDAYS() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            alParaval.Add("VEHICLE PURCHASE REGISTER")
            alParaval.Add("VEHICLE SALE REGISTER")

            If (ClientName = "CLASSIC" And UserName = "Admin") Or ClientName = "GLOBE" Or ClientName = "MILONI" Or ClientName = "NAMASTE" Or ClientName = "SKYMAPS" Or ClientName = "BARODA" Then
                alParaval.Add(txtbookingno.Text.Trim)
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(bookingdate.Value.Date)
            If ClientName = "SCC" Or ClientName = "TRAVCON" Then alParaval.Add(Val(txtrefno.Text.Trim)) Else alParaval.Add(txtrefno.Text.Trim)

            alParaval.Add(CMBGUESTNAME.Text.Trim)
            alParaval.Add(CMBPREFIX.Text.Trim)
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(CMBTYPE.Text.Trim)
            alParaval.Add(PACKAGEFROM.Value.Date)
            alParaval.Add(PACKAGETO.Value.Date)

            alParaval.Add(Val(TXTHRS.Text.Trim))
            alParaval.Add(Val(TXTKMS.Text.Trim))
            alParaval.Add(Val(TXTHRKMRATE.Text.Trim))
            alParaval.Add(Val(TXTHRSRATE.Text.Trim))
            alParaval.Add(Val(TXTKMSRATE.Text.Trim))


            alParaval.Add(Val(TXTHRSPUR.Text.Trim))
            alParaval.Add(Val(TXTKMSPUR.Text.Trim))
            alParaval.Add(Val(TXTHRKMRATEPUR.Text.Trim))
            alParaval.Add(Val(TXTHRSRATEPUR.Text.Trim))
            alParaval.Add(Val(TXTKMSRATEPUR.Text.Trim))

            alParaval.Add(Val(TXTALLOWANCEPUR.Text.Trim))
            alParaval.Add(Val(TXTNIGHTALLOWANCEPUR.Text.Trim))


            alParaval.Add(Val(TXTSUNDAYS.Text.Trim))
            alParaval.Add(Val(TXTSUNDAYSRATE.Text.Trim))
            alParaval.Add(Val(TXTEXTRADROP.Text.Trim))
            alParaval.Add(Val(TXTEXTRADROPRATE.Text.Trim))
            alParaval.Add(Val(TXTOUTSTATIONDAYS.Text.Trim))
            alParaval.Add(Val(TXTOUTSTATIONDAYSRATE.Text.Trim))

            alParaval.Add(cmbcity.Text.Trim)

            alParaval.Add(TXTHSNCODE.Text.Trim)
            alParaval.Add(CHKMANUAL.CheckState)
            alParaval.Add(CHKPURMANUAL.CheckState)




            alParaval.Add(Val(TXTCGSTPER.Text.Trim))
            alParaval.Add(Val(TXTCGSTAMT.Text.Trim))
            alParaval.Add(Val(TXTSGSTPER.Text.Trim))
            alParaval.Add(Val(TXTSGSTAMT.Text.Trim))
            alParaval.Add(Val(TXTIGSTPER.Text.Trim))
            alParaval.Add(Val(TXTIGSTAMT.Text.Trim))

            alParaval.Add(TXTARRIVALFROM.Text.Trim)
            alParaval.Add(TXTDEPARTURETO.Text.Trim)
            alParaval.Add(Val(TXTTOTALMISCAMT.Text.Trim))
            alParaval.Add(CMBGROUPDEPARTURE.Text.Trim)

            'TRANS DETAILS
            Dim CARSRNO As String = ""
            Dim DRIVERNAME As String = ""
            Dim CARNAME As String = ""
            Dim CARNO As String = ""
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
            Dim CARNOTE As String = ""
            Dim APPROXHRS As String = ""
            Dim APPROXKMS As String = ""
            Dim ALLOWANCE As String = ""
            Dim CARAMT As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDTRANS.Rows
                If row.Cells(GCARSRNO.Index).Value <> Nothing Then
                    If CARSRNO = "" Then
                        CARSRNO = row.Cells(GCARSRNO.Index).Value.ToString
                        DRIVERNAME = row.Cells(GDRIVER.Index).Value.ToString
                        CARNAME = row.Cells(GCARNAME.Index).Value.ToString
                        CARNO = row.Cells(GVEHICLENO.Index).Value.ToString
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
                        CARNOTE = row.Cells(GCARNOTE.Index).Value.ToString
                        APPROXHRS = row.Cells(GHRS.Index).Value.ToString
                        APPROXKMS = row.Cells(GKMS.Index).Value.ToString
                        ALLOWANCE = row.Cells(GALLOWANCE.Index).Value.ToString
                        CARAMT = row.Cells(GCARAMT.Index).Value.ToString

                    Else

                        CARSRNO = CARSRNO & "|" & row.Cells(GCARSRNO.Index).Value.ToString
                        DRIVERNAME = DRIVERNAME & "|" & row.Cells(GDRIVER.Index).Value.ToString
                        CARNAME = CARNAME & "|" & row.Cells(GCARNAME.Index).Value.ToString
                        CARNO = CARNO & "|" & row.Cells(GVEHICLENO.Index).Value.ToString
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
                        CARNOTE = CARNOTE & "|" & row.Cells(GCARNOTE.Index).Value.ToString
                        APPROXHRS = APPROXHRS & "|" & Val(row.Cells(GHRS.Index).Value.ToString)
                        APPROXKMS = APPROXKMS & "|" & Val(row.Cells(GKMS.Index).Value.ToString)
                        ALLOWANCE = ALLOWANCE & "|" & Val(row.Cells(GALLOWANCE.Index).Value.ToString)
                        CARAMT = CARAMT & "|" & Val(row.Cells(GCARAMT.Index).Value.ToString)

                    End If
                End If
            Next


            alParaval.Add(CARSRNO)
            alParaval.Add(DRIVERNAME)
            alParaval.Add(CARNAME)
            alParaval.Add(CARNO)
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
            alParaval.Add(CARNOTE)
            alParaval.Add(APPROXHRS)
            alParaval.Add(APPROXKMS)
            alParaval.Add(ALLOWANCE)
            alParaval.Add(CARAMT)


            'TOUR DETAILS
            Dim TOURSRNO As String = ""
            Dim TOURDATE As String = ""
            Dim TOURDETAILS As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDTOUR.Rows
                If row.Cells(0).Value <> Nothing Then
                    If TOURSRNO = "" Then
                        TOURSRNO = row.Cells(GTOURSRNO.Index).Value.ToString
                        TOURDATE = Format(Convert.ToDateTime(row.Cells(GTOURDATE.Index).Value).Date, "MM/dd/yyyy")
                        TOURDETAILS = row.Cells(GTOURDETAILS.Index).Value.ToString

                    Else

                        TOURSRNO = TOURSRNO & "|" & row.Cells(GTOURSRNO.Index).Value
                        TOURDATE = TOURDATE & "|" & Format(Convert.ToDateTime(row.Cells(GTOURDATE.Index).Value).Date, "MM/dd/yyyy")
                        TOURDETAILS = TOURDETAILS & "|" & row.Cells(GTOURDETAILS.Index).Value

                    End If
                End If
            Next

            alParaval.Add(TOURSRNO)
            alParaval.Add(TOURDATE)
            alParaval.Add(TOURDETAILS)


            'PURCHASE DETAILS
            Dim PURBILLCHECKED As String = ""
            Dim PURSRNO As String = ""
            Dim PURNAME As String = ""
            Dim PURDATE As String = ""
            '  Dim PURHSNITEMDESC As String = ""
            Dim PURHSNCODE As String = ""

            Dim PURAMT As String = ""
            Dim PURDISCPER As String = ""
            Dim PURDISC As String = ""
            Dim PURSUBTOTAL As String = ""
            Dim PURCOMMPER As String = ""
            Dim PURCOMM As String = ""
            Dim PURTDSPER As String = ""
            Dim PURTDS As String = ""

            Dim PURSERVTAX As String = ""
            Dim PURTAXSERVCHGS As String = ""

            Dim PURNETT As String = ""
            Dim PURTAXNAME As String = ""
            Dim PURTAX As String = ""

            Dim PURCGSTPER As String = ""
            Dim PURCGSTAMT As String = ""
            Dim PURSGSTPER As String = ""
            Dim PURSGSTAMT As String = ""
            Dim PURIGSTPER As String = ""
            Dim PURIGSTAMT As String = ""

            Dim PUROTHERCHGSNAME As String = ""
            Dim PUROTHERCHGS As String = ""
            Dim PURROUNDOFF As String = ""
            Dim PURGTOTAL As String = ""
            Dim PURAMTPAID As String = ""
            Dim PUREXTRAAMT As String = ""
            Dim PURRETURN As String = ""
            Dim PURBALANCE As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDPURCHASE.Rows
                If row.Cells(GPURSRNO.Index).Value <> Nothing Then
                    If PURSRNO = "" Then

                        PURBILLCHECKED = row.Cells(GCHK.Index).Value
                        PURSRNO = row.Cells(GPURSRNO.Index).Value.ToString
                        PURNAME = row.Cells(GPURNAME.Index).Value.ToString
                        PURDATE = Format(Convert.ToDateTime(row.Cells(GPURDATE.Index).Value).Date, "MM/dd/yyyy")
                        'PURHSNITEMDESC = row.Cells(GPURHSNITEMDESC.Index).Value.ToString
                        PURHSNCODE = row.Cells(GPURHSNCODE.Index).Value.ToString

                        PURAMT = row.Cells(GPURAMT.Index).Value.ToString
                        PURDISCPER = row.Cells(GDISCPER.Index).Value.ToString
                        PURDISC = row.Cells(GDISC.Index).Value.ToString
                        PURSUBTOTAL = row.Cells(GSUBTOTAL.Index).Value.ToString
                        PURCOMMPER = row.Cells(GCOMMPER.Index).Value.ToString
                        PURCOMM = row.Cells(GCOMM.Index).Value.ToString
                        PURTDSPER = row.Cells(GTDSPER.Index).Value.ToString
                        PURTDS = row.Cells(GTDS.Index).Value.ToString
                        If Convert.ToBoolean(row.Cells(GPURSERVICETAX.Index).Value) = True Then
                            PURSERVTAX = 1
                        Else
                            PURSERVTAX = 0
                        End If
                        PURTAXSERVCHGS = row.Cells(GPURTAXSERVCHGS.Index).Value.ToString

                        PURNETT = row.Cells(GNETTTOTAL.Index).Value.ToString
                        PURTAXNAME = row.Cells(GTAX.Index).Value.ToString
                        PURTAX = row.Cells(GTAXAMT.Index).Value.ToString

                        PURCGSTPER = row.Cells(GCGSTPER.Index).Value.ToString
                        PURCGSTAMT = row.Cells(GCGSTAMT.Index).Value.ToString
                        PURSGSTPER = row.Cells(GSGSTPER.Index).Value.ToString
                        PURSGSTAMT = row.Cells(GSGSTAMT.Index).Value.ToString
                        PURIGSTPER = row.Cells(GIGSTPER.Index).Value.ToString
                        PURIGSTAMT = row.Cells(GIGSTAMT.Index).Value.ToString

                        PUROTHERCHGSNAME = row.Cells(GOTHERCHGSNAME.Index).Value.ToString
                        PUROTHERCHGS = row.Cells(GOTHERCHGS.Index).Value.ToString
                        PURROUNDOFF = row.Cells(GROUNDOFF.Index).Value.ToString
                        PURGTOTAL = row.Cells(GGRANDTOTAL.Index).Value.ToString
                        PURAMTPAID = row.Cells(GPURAMTPAID.Index).Value.ToString
                        PUREXTRAAMT = row.Cells(GPUREXTRAAMT.Index).Value.ToString
                        PURRETURN = row.Cells(GPURRETURN.Index).Value.ToString
                        PURBALANCE = row.Cells(GPURBAL.Index).Value.ToString

                    Else

                        PURBILLCHECKED = PURBILLCHECKED & "|" & row.Cells(GCHK.Index).Value
                        PURSRNO = PURSRNO & "|" & row.Cells(GPURSRNO.Index).Value
                        PURNAME = PURNAME & "|" & row.Cells(GPURNAME.Index).Value
                        PURDATE = PURDATE & "|" & Format(Convert.ToDateTime(row.Cells(GPURDATE.Index).Value).Date, "MM/dd/yyyy")
                        'PURHSNITEMDESC = PURHSNITEMDESC & "|" & row.Cells(GPURHSNITEMDESC.Index).Value
                        PURHSNCODE = PURHSNCODE & "|" & row.Cells(GPURHSNCODE.Index).Value.ToString

                        PURAMT = PURAMT & "|" & row.Cells(GPURAMT.Index).Value.ToString
                        PURDISCPER = PURDISCPER & "|" & row.Cells(GDISCPER.Index).Value.ToString
                        PURDISC = PURDISC & "|" & row.Cells(GDISC.Index).Value.ToString
                        PURSUBTOTAL = PURSUBTOTAL & "|" & row.Cells(GSUBTOTAL.Index).Value.ToString
                        PURCOMMPER = PURCOMMPER & "|" & row.Cells(GCOMMPER.Index).Value.ToString
                        PURCOMM = PURCOMM & "|" & row.Cells(GCOMM.Index).Value.ToString
                        PURTDSPER = PURTDSPER & "|" & row.Cells(GTDSPER.Index).Value.ToString
                        PURTDS = PURTDS & "|" & row.Cells(GTDS.Index).Value.ToString
                        If Convert.ToBoolean(row.Cells(GPURSERVICETAX.Index).Value) = True Then
                            PURSERVTAX = PURSERVTAX & "|" & 1
                        Else
                            PURSERVTAX = PURSERVTAX & "|" & 0
                        End If
                        'PURSERVTAX = PURSERVTAX & "|" & row.Cells(GPURSERVICETAX.Index).Value
                        PURTAXSERVCHGS = PURTAXSERVCHGS & "|" & row.Cells(GPURTAXSERVCHGS.Index).Value.ToString

                        PURNETT = PURNETT & "|" & row.Cells(GNETTTOTAL.Index).Value.ToString
                        PURTAXNAME = PURTAXNAME & "|" & row.Cells(GTAX.Index).Value.ToString
                        PURTAX = PURTAX & "|" & row.Cells(GTAXAMT.Index).Value.ToString

                        PURCGSTPER = PURCGSTPER & "|" & row.Cells(GCGSTPER.Index).Value.ToString
                        PURCGSTAMT = PURCGSTAMT & "|" & row.Cells(GCGSTAMT.Index).Value.ToString
                        PURSGSTPER = PURSGSTPER & "|" & row.Cells(GSGSTPER.Index).Value.ToString
                        PURSGSTAMT = PURSGSTAMT & "|" & row.Cells(GSGSTAMT.Index).Value.ToString
                        PURIGSTPER = PURIGSTPER & "|" & row.Cells(GIGSTPER.Index).Value.ToString
                        PURIGSTAMT = PURIGSTAMT & "|" & row.Cells(GIGSTAMT.Index).Value.ToString

                        PUROTHERCHGSNAME = PUROTHERCHGSNAME & "|" & row.Cells(GOTHERCHGSNAME.Index).Value.ToString
                        PUROTHERCHGS = PUROTHERCHGS & "|" & row.Cells(GOTHERCHGS.Index).Value.ToString
                        PURROUNDOFF = PURROUNDOFF & "|" & row.Cells(GROUNDOFF.Index).Value.ToString
                        PURGTOTAL = PURGTOTAL & "|" & row.Cells(GGRANDTOTAL.Index).Value.ToString
                        PURAMTPAID = PURAMTPAID & "|" & row.Cells(GPURAMTPAID.Index).Value.ToString
                        PUREXTRAAMT = PUREXTRAAMT & "|" & row.Cells(GPUREXTRAAMT.Index).Value.ToString
                        PURRETURN = PURRETURN & "|" & row.Cells(GPURRETURN.Index).Value.ToString
                        PURBALANCE = PURBALANCE & "|" & row.Cells(GPURBAL.Index).Value.ToString

                    End If
                End If
            Next

            alParaval.Add(PURBILLCHECKED)
            alParaval.Add(PURSRNO)
            alParaval.Add(PURNAME)
            alParaval.Add(PURDATE)
            'alParaval.Add(PURHSNITEMDESC)
            alParaval.Add(PURHSNCODE)

            alParaval.Add(PURAMT)
            alParaval.Add(PURDISCPER)
            alParaval.Add(PURDISC)
            alParaval.Add(PURSUBTOTAL)
            alParaval.Add(PURCOMMPER)
            alParaval.Add(PURCOMM)
            alParaval.Add(PURTDSPER)
            alParaval.Add(PURTDS)

            alParaval.Add(PURSERVTAX)
            alParaval.Add(PURTAXSERVCHGS)

            alParaval.Add(PURNETT)
            alParaval.Add(PURTAXNAME)
            alParaval.Add(PURTAX)

            alParaval.Add(PURCGSTPER)
            alParaval.Add(PURCGSTAMT)
            alParaval.Add(PURSGSTPER)
            alParaval.Add(PURSGSTAMT)
            alParaval.Add(PURIGSTPER)
            alParaval.Add(PURIGSTAMT)

            alParaval.Add(PUROTHERCHGSNAME)
            alParaval.Add(PUROTHERCHGS)
            alParaval.Add(PURROUNDOFF)
            alParaval.Add(PURGTOTAL)
            alParaval.Add(PURAMTPAID)
            alParaval.Add(PUREXTRAAMT)
            alParaval.Add(PURRETURN)
            alParaval.Add(PURBALANCE)
            alParaval.Add(Val(TXTFINALPURAMT.Text.Trim))




            'SALE DETAILS
            alParaval.Add(CMBBOOKEDBY.Text.Trim)
            alParaval.Add(CMBSOURCE.Text.Trim)

            'MISC ENQ NO
            alParaval.Add(Val(TXTMISCENQNO.Text.Trim))

            'SALE VALUES
            alParaval.Add(Val(TXTTOTALSALEAMT.Text.Trim))
            alParaval.Add(Val(TXTOURCOMMPER.Text.Trim))
            alParaval.Add(Val(TXTOURCOMMRS.Text.Trim))
            alParaval.Add(Val(TXTDISCPER.Text.Trim))
            alParaval.Add(Val(TXTDISCRS.Text.Trim))
            alParaval.Add(Val(TXTEXTRACHGS.Text.Trim))
            alParaval.Add(Val(TXTSUBTOTAL.Text.Trim))
            alParaval.Add(cmbtax.Text.Trim)
            alParaval.Add(Val(txttax.Text.Trim))
            alParaval.Add(CMBADDTAX.Text.Trim)
            alParaval.Add(Val(TXTADDTAX.Text.Trim))

            alParaval.Add(CHKTAXSERVCHGS.CheckState)
            alParaval.Add(Val(TXTTAXSERVCHGS.Text.Trim))


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

            alParaval.Add(Val(TXTSALEAMTREC.Text.Trim))
            alParaval.Add(Val(TXTSALEEXTRAAMT.Text.Trim))
            alParaval.Add(Val(TXTSALERETURN.Text.Trim))
            alParaval.Add(Val(TXTSALEBAL.Text.Trim))



            alParaval.Add(Val(TXTSTART.Text.Trim))
            alParaval.Add(Val(TXTEND.Text.Trim))
            alParaval.Add(Val(TXTSTARTTIME.Text.Trim))
            alParaval.Add(Val(TXTENDTIME.Text.Trim))
            alParaval.Add(Val(TXTPURSTART.Text.Trim))
            alParaval.Add(Val(TXTPUREND.Text.Trim))
            alParaval.Add(Val(TXTPURSTARTTIME.Text.Trim))
            alParaval.Add(Val(TXTPURENDTIME.Text.Trim))


            alParaval.Add(TXTCARQUALITY.Text.Trim)
            alParaval.Add(TXTDRIVERQUALITY.Text.Trim)
            alParaval.Add(TXTCONFIRMEDBY.Text.Trim)
            alParaval.Add(TXTREMARKS.Text.Trim)
            alParaval.Add(TXTBOOKINGDESC.Text.Trim)
            alParaval.Add(TXTSPECIALREMARKS.Text.Trim)
            alParaval.Add(txtinwords.Text.Trim)



            'FOR DONE
            If lbllocked.Visible = True Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(chkdispute.CheckState)
            alParaval.Add(CHKBILLCHECK.CheckState)
            alParaval.Add(CMBTOUR.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)
            alParaval.Add(ClientName)

            'GRID AIRLINE
            Dim AIRSRNO As String = ""
            Dim SECTOR As String = ""
            Dim FLTNO As String = ""
            Dim AIRLINETYPE As String = ""
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
                        AIRLINETYPE = row.Cells(GTYPE.Index).Value.ToString
                        BASIC = row.Cells(GBASIC.Index).Value.ToString
                        PSF = row.Cells(GPSF.Index).Value.ToString
                        TAXES = row.Cells(GTAXES.Index).Value.ToString
                        AIRAMT = row.Cells(GTOTAL.Index).Value

                    Else
                        AIRSRNO = AIRSRNO & "|" & row.Cells(GAIRSRNO.Index).Value.ToString
                        SECTOR = SECTOR & "|" & row.Cells(GSECTOR.Index).Value.ToString
                        FLTNO = FLTNO & "|" & row.Cells(GFLTNO.Index).Value.ToString
                        AIRLINETYPE = AIRLINETYPE & "|" & row.Cells(GTYPE.Index).Value.ToString
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
            alParaval.Add(AIRLINETYPE)
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
                        If row.Cells(GFLTARR.Index).Value = Nothing Then ARRIVES = "" Else ARRIVES = row.Cells(GFLTARR.Index).Value.ToString
                        FLIGHTCLASS = row.Cells(GCLASS.Index).Value.ToString
                    Else
                        FLIGHTSRNO = FLIGHTSRNO & "|" & row.Cells(GFLIGHTSRNO.Index).Value.ToString
                        BOOKSRNO = BOOKSRNO & "|" & row.Cells(GBOOKSRNO.Index).Value.ToString
                        FROMSEC = FROMSEC & "|" & row.Cells(GFROM.Index).Value.ToString
                        TOSEC = TOSEC & "|" & row.Cells(GTO.Index).Value.ToString
                        FLIGHTNO = FLIGHTNO & "|" & row.Cells(GFLIGHTNO.Index).Value.ToString
                        FLIGHTDATE = FLIGHTDATE & "|" & row.Cells(GFLTDATE.Index).Value.ToString
                        If row.Cells(GFLTARR.Index).Value = Nothing Then ARRIVES = ARRIVES & "|" & "" Else ARRIVES = ARRIVES & "|" & row.Cells(GFLTARR.Index).Value.ToString
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



            Dim griduploadsrno As String = ""
            Dim uploadremarks As String = ""
            Dim name As String = ""
            Dim imgpath As String = ""
            Dim NEWIMGPATH As String = ""
            Dim FILENAME As String = ""



            'Saving Upload Grid
            For Each row As Windows.Forms.DataGridViewRow In gridupload.Rows
                If row.Cells(0).Value <> Nothing Then
                    If griduploadsrno = "" Then
                        griduploadsrno = row.Cells(0).Value.ToString
                        uploadremarks = row.Cells(1).Value.ToString
                        name = row.Cells(2).Value.ToString
                        imgpath = row.Cells(3).Value.ToString
                        NEWIMGPATH = row.Cells(GNEWIMGPATH.Index).Value.ToString

                    Else
                        griduploadsrno = griduploadsrno & "|" & row.Cells(0).Value.ToString
                        uploadremarks = uploadremarks & "|" & row.Cells(1).Value.ToString
                        name = name & "|" & row.Cells(2).Value.ToString
                        imgpath = imgpath & "|" & row.Cells(3).Value.ToString
                        NEWIMGPATH = NEWIMGPATH & "|" & row.Cells(GNEWIMGPATH.Index).Value.ToString

                    End If
                End If
            Next

            alParaval.Add(griduploadsrno)
            alParaval.Add(uploadremarks)
            alParaval.Add(name)
            alParaval.Add(imgpath)
            alParaval.Add(NEWIMGPATH)
            alParaval.Add(FILENAME)
            alParaval.Add(TXTIRNNO.Text.Trim)
            alParaval.Add(TXTACKNO.Text.Trim)
            alParaval.Add(Format(ACKDATE.Value.Date, "MM/dd/yyyy"))
            If PBQRCODE.Image IsNot Nothing Then
                Dim MS As New IO.MemoryStream
                PBQRCODE.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                alParaval.Add(MS.ToArray)
            Else
                alParaval.Add(DBNull.Value)
            End If

            Dim OBJBOOKING As New ClsCarBooking()
            OBJBOOKING.alParaval = alParaval


            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTNO As DataTable = OBJBOOKING.SAVE()
                MessageBox.Show("Details Added")
                PRINTREPORT(DTNO.Rows(0).Item(0))
                TEMPBOOKINGNO = DTNO.Rows(0).Item(0)
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPBOOKINGNO)

                IntResult = OBJBOOKING.UPDATE()
                MessageBox.Show("Details Updated")
                edit = False
                PRINTREPORT(TEMPBOOKINGNO)
            End If


            'COPY SCANNED DOCS FILES 
            For Each ROW As DataGridViewRow In gridupload.Rows
                If FileIO.FileSystem.DirectoryExists(Application.StartupPath & "\CAR") = False Then
                    FileIO.FileSystem.CreateDirectory(Application.StartupPath & "\CAR")
                End If
                If FileIO.FileSystem.FileExists(Application.StartupPath & "\CAR") = False Then
                    System.IO.File.Copy(ROW.Cells(GIMGPATH.Index).Value, ROW.Cells(GNEWIMGPATH.Index).Value, True)
                End If
            Next
            clear()
            bookingdate.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLAIRLINEGRID()
        Try
            GRIDAIRLINE.Enabled = True
            If GRIDAIRDOUBLECLICK = False Then
                GRIDAIRLINE.Rows.Add(Val(TXTAIRSRNO.Text.Trim), TXTTEMPSECTOR.Text.Trim, TXTFLTNO.Text.Trim, CMBAIRLINETYPE.Text.Trim, Format(Val(TXTBASIC.Text.Trim), "0.00"), Format(Val(TXTPSF.Text.Trim), "0.00"), Format(Val(TXTGRIDTAX.Text.Trim), "0.00"), Format(Val(TXTAIRAMT.Text.Trim), "0.00"), 0)
                getsrno(GRIDAIRLINE)

                'ADD IN FLIGHT ALSO
                For Each ROW As DataGridViewRow In GRIDSECTOR.Rows
                    GRIDFLIGHT.Rows.Add(ROW.Cells(GSECSRNO.Index).Value, ROW.Cells(GSECBOOKSRNO.Index).Value, ROW.Cells(GSECFROM.Index).Value, ROW.Cells(GSECTO.Index).Value, ROW.Cells(GSECFLTNO.Index).Value, ROW.Cells(GSECFLTDATE.Index).Value, ROW.Cells(GARRIVAL.Index).Value, ROW.Cells(GSECCLASS.Index).Value)
                Next

            ElseIf GRIDAIRDOUBLECLICK = True Then
                GRIDAIRLINE.Item(GAIRSRNO.Index, tempFLIGHTrow).Value = Val(TXTAIRSRNO.Text.Trim)
                GRIDAIRLINE.Item(GSECTOR.Index, tempFLIGHTrow).Value = TXTTEMPSECTOR.Text.Trim
                GRIDAIRLINE.Item(GFLTNO.Index, tempFLIGHTrow).Value = TXTFLTNO.Text.Trim
                GRIDAIRLINE.Item(GTYPE.Index, tempFLIGHTrow).Value = CMBAIRLINETYPE.Text.Trim
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
            CMBAIRLINETYPE.Text = ""
            TXTBASIC.Clear()
            TXTPSF.Clear()
            TXTGRIDTAX.Clear()
            TXTAIRAMT.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        Dim OBJCMN As New ClsCommon
        Dim DT As DataTable

        CALC()
        CALCPUR()

        If Not datecheck(bookingdate.Value) Then
            EP.SetError(bookingdate, "Date Not in Current Accounting Year")
            bln = False
        End If

        If CMBGUESTNAME.Text.Trim = "" Then
            EP.SetError(CMBGUESTNAME, " Please Select Guest Name")
            bln = False
        End If

        If CMBSOURCE.Text.Trim.Length = 0 And ClientName = "WORLDSPIN" Then
            EP.SetError(CMBSOURCE, "Select Source")
            bln = False
        End If

        If ALLOWSAMESTATE = True And Val(TXTSTATECODE.Text.Trim) <> Val(CMPSTATECODE) Then
            EP.SetError(CMBNAME, " Booking Of Other State Not Allowed")
            bln = False
        End If

        GETBALANCE()

        'If LBLPURBAL.ForeColor = Color.Red Then
        '    EP.SetError(LBLPURBAL, "Amt Exceeds Cr Limit")
        '    bln = False
        'End If

        If CHECKPURCHASEBALANCES() Then
            EP.SetError(CMBNAME, "User Cancelled the save operation due to Creditors Credit Issues")
            bln = False
        End If

        If ClientName = "URMI" And txtrefno.Text.Trim.Length = 0 Then
            EP.SetError(txtrefno, "Enter Ref No")
            bln = False
        End If

        If LBLACCBAL.ForeColor = Color.Red Then
            EP.SetError(LBLACCBAL, "Amt Exceeds Cr Limit")
            bln = False
        End If

        If ClientName = "CLASSIC" Then
            If Val(txtgrandtotal.Text.Trim) >= 50001 Then
                DT = OBJCMN.search(" ACC_ADD, ACC_PANNO AS PANNO", "", " LEDGERS", " AND ACC_CMPNAME ='" & CMBNAME.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    If DT.Rows(0).Item("PANNO") = "" Then
                        EP.SetError(CMBNAME, "Insert PAN No")
                        bln = False
                    End If
                End If
            End If

        End If

        If ClientName = "CLASSIC" And UserName = "Admin" And edit = False Then
            If Val(txtbookingno.Text.Trim) >= 0 Then
                Dim OBJC As New ClsCommon
                Dim DT1 As DataTable = OBJC.search(" BOOKING_NO AS BOOKINGNO ", "", " CARBOOKINGMASTER ", " AND CARBOOKINGMASTER.BOOKING_NO = '" & txtbookingno.Text.Trim & "' AND CARBOOKINGMASTER.BOOKING_CMPID=" & CmpId & " and CARBOOKINGMASTER.BOOKING_LOCATIONID=" & Locationid & " and CARBOOKINGMASTER.BOOKING_yearid=" & YearId)
                If DT1.Rows.Count > 0 Then
                    EP.SetError(txtbookingno, "Booking No Already Exists !")
                    txtbookingno.Clear()
                    txtbookingno.Focus()
                    bln = False
                End If
            End If
        End If

        If (ClientName = "GLOBE" Or ClientName = "MILONI" Or ClientName = "NAMASTE" Or ClientName = "SKYMAPS" Or ClientName = "BARODA") And edit = False Then
            If Val(txtbookingno.Text.Trim) >= 0 Then
                Dim OBJC As New ClsCommon
                Dim DT1 As DataTable = OBJC.search(" BOOKING_NO AS BOOKINGNO ", "", " CARBOOKINGMASTER ", " AND CARBOOKINGMASTER.BOOKING_NO = '" & txtbookingno.Text.Trim & "' and CARBOOKINGMASTER.BOOKING_yearid=" & YearId)
                If DT1.Rows.Count > 0 Then
                    EP.SetError(txtbookingno, "Booking No Already Exists !")
                    txtbookingno.Clear()
                    txtbookingno.Focus()
                    bln = False
                End If
            End If
        End If

        If (ClientName = "UNIGO" Or ClientName = "TRAVELBRIDGE") And edit = False Then
            If Val(txtbookingno.Text.Trim) >= 0 Then
                Dim OBJC As New ClsCommon
                Dim DT1 As DataTable = OBJC.search(" T.BOOKINGNO AS BOOKINGNO ", "", " (SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM AIRLINEBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM HOTELBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM HOLIDAYPACKAGEMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM CARBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM INTERNATIONALBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM MISCSALMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM RAILBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM VISABOOKING WHERE BOOKING_YEARID = " & YearId & " ) AS T ", " AND T.BOOKINGNO = " & Val(txtbookingno.Text.Trim))
                If DT1.Rows.Count > 0 Then
                    EP.SetError(txtbookingno, "Booking No Already Exists !")
                    txtbookingno.Clear()
                    txtbookingno.Focus()
                    bln = False
                End If
            End If
        End If

        If edit = False And ClientName = "SCC" Then
            If CMBNAME.Text.Trim <> "" And CMBGUESTNAME.Text.Trim <> "" Then
                Dim OBJD As New ClsCommon
                Dim DT2 As DataTable = OBJD.search(" ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(GUESTMASTER.GUEST_NAME, '') AS GUEST, CARBOOKINGMASTER.BOOKING_PACKAGEFROM AS PACKAGEFROM ", "", " CARBOOKINGMASTER INNER JOIN GUESTMASTER ON CARBOOKINGMASTER.BOOKING_GUESTID = GUESTMASTER.GUEST_ID INNER JOIN LEDGERS ON CARBOOKINGMASTER.BOOKING_LEDGERID = LEDGERS.Acc_id ", " AND LEDGERS.Acc_cmpname = '" & CMBNAME.Text.Trim & "' AND GUESTMASTER.GUEST_NAME = '" & CMBGUESTNAME.Text.Trim & "' AND CARBOOKINGMASTER.BOOKING_PACKAGEFROM = '" & Format(PACKAGEFROM.Value.Date, "MM/dd/yyyy") & "'  and CARBOOKINGMASTER.BOOKING_yearid=" & YearId)
                If DT2.Rows.Count > 0 Then
                    If MsgBox("Entry already present, do you want to create another invoice?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        bln = True
                    Else
                        bln = False
                        EP.SetError(PACKAGEFROM, "Entry already present")
                    End If
                End If
            End If
        End If

        If ClientName <> "SCC" Then
            If Val(txtgrandtotal.Text.Trim) = 0 Then
                EP.SetError(txtgrandtotal, "Amount cannot be 0")
                bln = False
            End If
        End If


        'AS AMIGO HAS THEIR OWN CARS SO NO NEED TO PURCHASE
        If ClientName <> "RAMKRISHNA" And ClientName <> "ARHAM" And ClientName <> "SCC" And ClientName <> "KHANNA" And ClientName <> "TRAVCON" Then
            If Val(TXTFINALPURAMT.Text.Trim) = 0 Then
                EP.SetError(TXTFINALPURAMT, "Amount Cannot be 0")
                bln = False
            End If

            If GRIDPURCHASE.RowCount = 0 Then
                EP.SetError(CMBNAME, " Please Fill Purchase Details ")
                TBDETAILS.SelectedIndex = 2
                bln = False
            End If
        End If



        If CMBNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBNAME, " Please Fill Account Name ")
            bln = False
        End If


        If GRIDTRANS.RowCount = 0 Then
            EP.SetError(CMBNAME, "Enter Vehicle Details")
            TBDETAILS.SelectedIndex = 0
            bln = False
        End If

        If CMBBOOKEDBY.Text.Trim.Length = 0 Then
            EP.SetError(CMBBOOKEDBY, " Please Fill Your Name ")
            bln = False
        End If

        If ClientName = "CLASSIC" Then
            If UserName <> "Admin" And edit = True Then
                If bookingdate.Value.Date < DDATE.Date Then
                    EP.SetError(bookingdate, "Back Date Entry Not Allowed")
                    bln = False
                End If
            End If
        End If


        'CHECKING WHETHER NAME IS PRESENT IN DATABASE OR NOT
        'DONT DELETE THIS CODE IT IS NECESSARY COZ SOMETIMES FORM IS OPEN AND USER CHANGES THE NAME FROM BEHIND
        If ClientName <> "TOPCOMM" Then
            DT = OBJCMN.search(" ACC_CMPNAME", "", " LEDGERS", " AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
            If DT.Rows.Count = 0 Then
                EP.SetError(CMBNAME, "Change Name")
                bln = False
            End If

            For Each ROW As DataGridViewRow In GRIDPURCHASE.Rows
                DT = OBJCMN.search(" ACC_CMPNAME", "", " LEDGERS", " AND ACC_CMPNAME = '" & ROW.Cells(GPURNAME.Index).Value & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
                If DT.Rows.Count = 0 Then
                    EP.SetError(CMBNAME, "Change Purchase Name")
                    bln = False
                End If
            Next
        End If
        '***************************************************

        If ClientName <> "LUXCREST" Then
            If UserName <> "Admin" Then
                If lbllocked.Visible = True Then
                    EP.SetError(lbllocked, " Booking Locked, Payment/Receipt Made")
                    bln = False
                End If
            End If

            If lblcancelled.Visible = True Then
                EP.SetError(PBCancelled, " Booking Locked, Booking Cancelled")
                bln = False
            End If
        End If


        If ClientName = "SCC" And UserName <> "Admin" And CHKBILLCHECK.CheckState = CheckState.Checked And edit = True Then
            If InputBox("Enter Modification Password") <> "scc2188" Then
                EP.SetError(CMBNAME, " Password Incorrect")
                bln = False
            End If
        End If

        If Val(txtotherchg.Text.Trim) = 0 Then
            CMBOTHERCHGS.Text = ""
            cmbaddsub.SelectedIndex = 0
        End If


        If Val(txtotherchg.Text.Trim) > 0 And CMBOTHERCHGS.Text.Trim = "" Then
            EP.SetError(txtotherchg, " Select Expense Type")
            bln = False
        End If

        If Val(TXTPUROTHERCHGS.Text.Trim) > 0 And CMBPUROTHERCHGS.Text.Trim = "" Then
            EP.SetError(TXTPUROTHERCHGS, " Select Expense Type")
            bln = False
        End If



        If Not datecheck(bookingdate.Value) Then
            EP.SetError(bookingdate, "Date Not in Current Accounting Year")
            bln = False
        End If


        If ClientName = "CLASSIC" Then

            If UserName <> "Admin" And edit = False Then
                If bookingdate.Value.Date < Now.Date Then
                    EP.SetError(bookingdate, "Back Date Entry Not Allowed")
                    bln = False
                End If
            End If

            If Not datecheck(PACKAGEFROM.Value) Then
                EP.SetError(PACKAGEFROM, "Date Not in Current Accounting Year")
                bln = False
            End If
            If Not datecheck(PACKAGETO.Value) Then
                EP.SetError(PACKAGETO, "Date Not in Current Accounting Year")
                bln = False
            End If
        End If

        Return bln
    End Function

    Sub total()

        TXTTOTALSALEAMT.Text = "0.00"
        TXTFINALPURAMT.Text = 0.0

        CMBADDTAX.Text = ""
        TXTADDTAX.Clear()

        TXTCARTOTALPAX.Text = 0
        TXTCARTOTALAMT.Text = 0.0
        TXTTOTALMISCAMT.Text = "0.00"

        Dim TEMPPURSUBTOTAL As Double = 0

        For Each row As DataGridViewRow In GRIDPURCHASE.Rows
            If Val(row.Cells(GGRANDTOTAL.Index).Value) > 0 Then TXTFINALPURAMT.Text = Format(Val(TXTFINALPURAMT.Text) + Val(row.Cells(GGRANDTOTAL.Index).Value), "0.00")
            If Val(row.Cells(GNETTTOTAL.Index).Value) > 0 Then TEMPPURSUBTOTAL += Val(row.Cells(GNETTTOTAL.Index).Value)
        Next

        If GRIDTRANS.RowCount > 0 Then

            TXTSUBTOTAL.Text = 0.0
            txttax.Text = 0.0
            TXTADDTAX.Text = 0.0
            If Val(TXTOURCOMMPER.Text.Trim) > 0 Then TXTOURCOMMRS.Text = 0.0
            If Val(TXTDISCPER.Text.Trim) > 0 Then TXTDISCRS.Text = 0.0
            txtroundoff.Text = 0.0
            txtgrandtotal.Text = 0.0

            For Each row As DataGridViewRow In GRIDTRANS.Rows
                If Val(row.Cells(GCARAMT.Index).Value) > 0 Then TXTCARTOTALAMT.Text = Format(Val(TXTCARTOTALAMT.Text) + Val(row.Cells(GCARAMT.Index).Value), "0.00")
                If Val(row.Cells(GCARPAX.Index).Value) > 0 Then TXTCARTOTALPAX.Text = Format(Val(TXTCARTOTALPAX.Text) + Val(row.Cells(GCARPAX.Index).Value), "0")
            Next

            'GRID AIRLINE
            TXTAIRTOTAL.Text = "0.00"
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

            If GRIDMISC.RowCount > 0 Then
                For Each ROW As DataGridViewRow In GRIDMISC.Rows
                    If Val(ROW.Cells(GMISCAMOUNT.Index).Value) > 0 Then TXTTOTALMISCAMT.Text = Val(TXTTOTALMISCAMT.Text) + Val(ROW.Cells(GMISCAMOUNT.Index).Value)
                Next
            End If

            If CHKREVERSE.Checked = True Then

                Dim objclscmn As New ClsCommonMaster
                Dim dt1 As DataTable = objclscmn.search("TAX_NAME ,tax_tax AS TAX", "", "TAXMaster", " and TAX_NAME = '" & cmbtax.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
                If dt1.Rows.Count > 0 Then
                    TXTTOTALSALEAMT.Text = Format((Val(TXTCARTOTALAMT.Text.Trim) / (Val(dt1.Rows(0).Item(1)) + 100) * 100), "0.00")
                End If
            Else
                TXTTOTALSALEAMT.Text = Format(Val(TXTCARTOTALAMT.Text.Trim) + Val(TXTTOTALMISCAMT.Text), "0.00")
            End If

            If ClientName = "SCC" Or ClientName = "TRAVCON" Then TXTTOTALSALEAMT.Text = Format(Val(TXTCARTOTALAMT.Text.Trim) + Val(txtrefno.Text.Trim), "0.00")
            If Val(TXTDISCPER.Text) > 0 Then TXTDISCRS.Text = Format((Val(TXTDISCPER.Text) * Val(TXTTOTALSALEAMT.Text)) / 100, "0.00")

            'TXTSUBTOTAL.Text = Format((Val(TXTTOTALSALEAMT.Text) + Val(TXTEXTRACHGS.Text.Trim)) - Val(TXTDISCRS.Text), "0.00")
            TXTSUBTOTAL.Text = Format((Val(TXTTOTALSALEAMT.Text) + Val(TXTEXTRACHGS.Text.Trim)) - Val(TXTDISCRS.Text) + Val(TXTTAXSERVCHGS.Text), "0.00")

            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable

            If Convert.ToDateTime(bookingdate.Value.Date).Date < "01/07/2017" Then

                dt = objclscommon.search("TAX_NAME,tax_tax", "", "TAXMaster", " and TAX_NAME = '" & cmbtax.Text.Trim & "' and TAX_Yearid = " & YearId)
                If CHKTAXSERVCHGS.CheckState = CheckState.Checked Then
                    If dt.Rows.Count > 0 Then txttax.Text = Format((Val(dt.Rows(0).Item(1)) * Val(TXTTAXSERVCHGS.Text)) / 100, "0.00")
                Else
                    If dt.Rows.Count > 0 Then txttax.Text = Format((Val(dt.Rows(0).Item(1)) * Val(TXTSUBTOTAL.Text)) / 100, "0.00")
                End If

            Else
                If CHKMANUAL.CheckState = CheckState.Unchecked Then
                    If CHKTAXSERVCHGS.CheckState = CheckState.Checked Then
                        TXTCGSTAMT.Text = Format((Val(TXTCGSTPER.Text) * Val(TXTTAXSERVCHGS.Text)) / 100, "0.00")
                        TXTSGSTAMT.Text = Format((Val(TXTSGSTPER.Text) * Val(TXTTAXSERVCHGS.Text)) / 100, "0.00")
                        TXTIGSTAMT.Text = Format((Val(TXTIGSTPER.Text) * Val(TXTTAXSERVCHGS.Text)) / 100, "0.00")

                    Else

                        TXTCGSTAMT.Text = Format((Val(TXTCGSTPER.Text) * Val(TXTSUBTOTAL.Text)) / 100, "0.00")
                        TXTSGSTAMT.Text = Format((Val(TXTSGSTPER.Text) * Val(TXTSUBTOTAL.Text)) / 100, "0.00")
                        TXTIGSTAMT.Text = Format((Val(TXTIGSTPER.Text) * Val(TXTSUBTOTAL.Text)) / 100, "0.00")
                    End If
                End If
            End If

            dt = objclscommon.search("TAX_NAME,tax_tax", "", "TAXMaster", " and TAX_NAME = '" & CMBADDTAX.Text.Trim & "' and TAX_Yearid = " & YearId)
            If dt.Rows.Count > 0 Then TXTADDTAX.Text = Format((Val(dt.Rows(0).Item(1)) * Val(TXTSUBTOTAL.Text)) / 100, "0.00")


            If cmbaddsub.Text = "Add" Then
                txtgrandtotal.Text = Format(Val(TXTSUBTOTAL.Text) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim) + Val(txttax.Text) + Val(TXTADDTAX.Text) + Val(txtotherchg.Text), "0")
                txtroundoff.Text = Format(Val(txtgrandtotal.Text) - (Val(TXTSUBTOTAL.Text) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim) + Val(txttax.Text) + Val(TXTADDTAX.Text) + Val(txtotherchg.Text)), "0.00")
            Else
                txtgrandtotal.Text = Format((Val(TXTSUBTOTAL.Text) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim) + Val(txttax.Text) + Val(TXTADDTAX.Text)) - Val(txtotherchg.Text), "0")
                txtroundoff.Text = Format(Val(txtgrandtotal.Text) - ((Val(TXTSUBTOTAL.Text) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim) + Val(txttax.Text) + Val(TXTADDTAX.Text)) - Val(txtotherchg.Text)), "0.00")
            End If

            txtgrandtotal.Text = Format(Val(txtgrandtotal.Text), "0.00")

            'as per ASHOK BHAI'S RECOMMENDATION
            'TXTOURCOMMRS.Text = Format(Val(txtgrandtotal.Text) - Val(TXTFINALPURAMT.Text), "0.00")
            TXTOURCOMMRS.Text = Format(Val(TXTSUBTOTAL.Text) - Val(TEMPPURSUBTOTAL), "0.00")

            If Val(txtgrandtotal.Text) > 0 Then txtinwords.Text = CurrencyToWord(txtgrandtotal.Text)
        End If
    End Sub

    Sub PURCHASECALC()
        CALCPUR()

        TXTPURSUBTOTAL.Text = 0.0
        TXTPURTAX.Text = 0.0
        TXTPURNETTAMT.Text = 0.0
        TXTPURROUNDOFF.Text = 0.0
        TXTPURGTOTAL.Text = 0.0

        If Val(TXTDISCRECDPER.Text.Trim) > 0 Then TXTDISCRECDRS.Text = 0.0
        If Val(TXTCOMMRECDPER.Text.Trim) > 0 Then TXTCOMMRECDRS.Text = 0.0
        If Val(TXTPURTDSPER.Text.Trim) > 0 Then TXTPURTDSRS.Text = 0.0


        If Val(TXTDISCRECDPER.Text) > 0 Then TXTDISCRECDRS.Text = Format((Val(TXTDISCRECDPER.Text) * Val(TXTPURAMT.Text)) / 100, "0.00")
        TXTPURSUBTOTAL.Text = Format(Val(TXTPURAMT.Text) - Val(TXTDISCRECDRS.Text), "0.00")

        If Val(TXTCOMMRECDPER.Text) > 0 Then TXTCOMMRECDRS.Text = Format((Val(TXTCOMMRECDPER.Text) * Val(TXTPURSUBTOTAL.Text)) / 100, "0.00")
        If Val(TXTPURTDSPER.Text) > 0 Then TXTPURTDSRS.Text = Format((Val(TXTPURTDSPER.Text) * Val(TXTCOMMRECDRS.Text)) / 100, "0.00")

        TXTPURNETTAMT.Text = Format(Val(TXTPURSUBTOTAL.Text) - Val(TXTCOMMRECDRS.Text) + Val(TXTPURSERVCHGS.Text.Trim), "0.00")

        If Convert.ToDateTime(PURDATE.Value.Date).Date < "01/07/2017" Then

            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclscommon.search("TAX_NAME,tax_tax", "", "TAXMaster", " and TAX_NAME = '" & CMBPURTAX.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
            If dt.Rows.Count > 0 Then TXTPURTAX.Text = Format((Val(dt.Rows(0).Item(1)) * Val(TXTPURNETTAMT.Text)) / 100, "0.00")

        Else
            If CHKPURMANUAL.CheckState = CheckState.Unchecked Then
                If CHKPURSERVTAX.CheckState = CheckState.Checked Then
                    TXTPURCGSTAMT.Text = Format((Val(TXTPURCGSTPER.Text) * Val(TXTPURSERVCHGS.Text)) / 100, "0.00")
                    TXTPURSGSTAMT.Text = Format((Val(TXTPURSGSTPER.Text) * Val(TXTPURSERVCHGS.Text)) / 100, "0.00")
                    TXTPURIGSTAMT.Text = Format((Val(TXTPURIGSTPER.Text) * Val(TXTPURSERVCHGS.Text)) / 100, "0.00")

                Else

                    TXTPURCGSTAMT.Text = Format((Val(TXTPURCGSTPER.Text) * Val(TXTPURNETTAMT.Text)) / 100, "0.00")
                    TXTPURSGSTAMT.Text = Format((Val(TXTPURSGSTPER.Text) * Val(TXTPURNETTAMT.Text)) / 100, "0.00")
                    TXTPURIGSTAMT.Text = Format((Val(TXTPURIGSTPER.Text) * Val(TXTPURNETTAMT.Text)) / 100, "0.00")
                End If
            End If
        End If

        If ClientName = "SCC" Or ClientName = "TRAVCON" Then
            TXTPURGTOTAL.Text = Format(Val(TXTPURNETTAMT.Text) + Val(TXTPURTAX.Text) + Val(TXTPURCGSTAMT.Text.Trim) + Val(TXTPURSGSTAMT.Text.Trim) + Val(TXTPURIGSTAMT.Text.Trim) + Val(TXTPUROTHERCHGS.Text) + Val(TXTNIGHTALLOWANCEPUR.Text.Trim), "0")
            TXTPURROUNDOFF.Text = Format(Val(TXTPURGTOTAL.Text) - (Val(TXTPURNETTAMT.Text) + Val(TXTPURTAX.Text) + Val(TXTPURCGSTAMT.Text.Trim) + Val(TXTPURSGSTAMT.Text.Trim) + Val(TXTPURIGSTAMT.Text.Trim) + Val(TXTPUROTHERCHGS.Text) + Val(TXTNIGHTALLOWANCEPUR.Text.Trim)), "0.00")
        Else
            TXTPURGTOTAL.Text = Format(Val(TXTPURNETTAMT.Text) + Val(TXTPURTAX.Text) + Val(TXTPURCGSTAMT.Text.Trim) + Val(TXTPURSGSTAMT.Text.Trim) + Val(TXTPURIGSTAMT.Text.Trim) + Val(TXTPUROTHERCHGS.Text), "0")
            TXTPURROUNDOFF.Text = Format(Val(TXTPURGTOTAL.Text) - (Val(TXTPURNETTAMT.Text) + Val(TXTPURTAX.Text) + Val(TXTPURCGSTAMT.Text.Trim) + Val(TXTPURSGSTAMT.Text.Trim) + Val(TXTPURIGSTAMT.Text.Trim) + Val(TXTPUROTHERCHGS.Text)), "0.00")
        End If


        TXTPURGTOTAL.Text = Format(Val(TXTPURGTOTAL.Text), "0.00")
    End Sub

    Private Sub txtsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTSRNO.GotFocus
        If gridDoubleClick = False Then
            If GRIDDETAILS.RowCount > 0 Then
                TXTSRNO.Text = Val(GRIDDETAILS.Rows(GRIDDETAILS.RowCount - 1).Cells(GSRNO.Index).Value) + 1
            Else
                TXTSRNO.Text = 1
            End If
        End If
    End Sub

    Private Sub txtPURSRNO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTPURSRNO.GotFocus
        If gridPURCHASEDoubleClick = False Then
            If GRIDPURCHASE.RowCount > 0 Then
                TXTPURSRNO.Text = Val(GRIDPURCHASE.Rows(GRIDPURCHASE.RowCount - 1).Cells(GPURSRNO.Index).Value) + 1
            Else
                TXTPURSRNO.Text = 1
            End If
        End If
    End Sub

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                If grid.Name = "GRIDPURCHASE" Then
                    row.Cells(1).Value = row.Index + 1
                Else
                    row.Cells(0).Value = row.Index + 1
                End If
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgridPURCHASE()

        GRIDPURCHASE.Enabled = True

        If gridPURCHASEDoubleClick = False Then

            If CHKPURSERVTAX.Checked = True Then
                GRIDPURCHASE.Rows.Add(0, Val(TXTPURSRNO.Text.Trim), CMBPURNAME.Text.Trim, Format(PURDATE.Value.Date, "dd/MM/yyyy"), CMBPURHSNITEMDESC.Text.Trim, TXTPURHSNCODE.Text.Trim, Format(Val(TXTPURAMT.Text.Trim), "0.00"), Format(Val(TXTDISCRECDPER.Text.Trim), "0.00"), Format(Val(TXTDISCRECDRS.Text.Trim), "0.00"), Format(Val(TXTPURSUBTOTAL.Text.Trim), "0.00"), Format(Val(TXTCOMMRECDPER.Text.Trim), "0.00"), Format(Val(TXTCOMMRECDRS.Text.Trim), "0.00"), Format(Val(TXTPURTDSPER.Text.Trim), "0.00"), Format(Val(TXTPURTDSRS.Text.Trim), "0.00"), 1, Format(Val(TXTPURSERVCHGS.Text.Trim), "0.00"), Format(Val(TXTPURNETTAMT.Text.Trim), "0.00"), CMBPURTAX.Text.Trim, Format(Val(TXTPURTAX.Text.Trim), "0.00"), Format(Val(TXTPURCGSTPER.Text.Trim), "0.00"), Format(Val(TXTPURCGSTAMT.Text.Trim), "0.00"), Format(Val(TXTPURSGSTPER.Text.Trim), "0.00"), Format(Val(TXTPURSGSTAMT.Text.Trim), "0.00"), Format(Val(TXTPURIGSTPER.Text.Trim), "0.00"), Format(Val(TXTPURIGSTAMT.Text.Trim), "0.00"), CMBPUROTHERCHGS.Text.Trim, Format(Val(TXTPUROTHERCHGS.Text.Trim), "0.00"), Format(Val(TXTPURROUNDOFF.Text.Trim), "0.00"), Format(Val(TXTPURGTOTAL.Text.Trim), "0.00"), 0, 0, 0, 0)
            Else
                GRIDPURCHASE.Rows.Add(0, Val(TXTPURSRNO.Text.Trim), CMBPURNAME.Text.Trim, Format(PURDATE.Value.Date, "dd/MM/yyyy"), CMBPURHSNITEMDESC.Text.Trim, TXTPURHSNCODE.Text.Trim, Format(Val(TXTPURAMT.Text.Trim), "0.00"), Format(Val(TXTDISCRECDPER.Text.Trim), "0.00"), Format(Val(TXTDISCRECDRS.Text.Trim), "0.00"), Format(Val(TXTPURSUBTOTAL.Text.Trim), "0.00"), Format(Val(TXTCOMMRECDPER.Text.Trim), "0.00"), Format(Val(TXTCOMMRECDRS.Text.Trim), "0.00"), Format(Val(TXTPURTDSPER.Text.Trim), "0.00"), Format(Val(TXTPURTDSRS.Text.Trim), "0.00"), 0, Format(Val(TXTPURSERVCHGS.Text.Trim), "0.00"), Format(Val(TXTPURNETTAMT.Text.Trim), "0.00"), CMBPURTAX.Text.Trim, Format(Val(TXTPURTAX.Text.Trim), "0.00"), Format(Val(TXTPURCGSTPER.Text.Trim), "0.00"), Format(Val(TXTPURCGSTAMT.Text.Trim), "0.00"), Format(Val(TXTPURSGSTPER.Text.Trim), "0.00"), Format(Val(TXTPURSGSTAMT.Text.Trim), "0.00"), Format(Val(TXTPURIGSTPER.Text.Trim), "0.00"), Format(Val(TXTPURIGSTAMT.Text.Trim), "0.00"), CMBPUROTHERCHGS.Text.Trim, Format(Val(TXTPUROTHERCHGS.Text.Trim), "0.00"), Format(Val(TXTPURROUNDOFF.Text.Trim), "0.00"), Format(Val(TXTPURGTOTAL.Text.Trim), "0.00"), 0, 0, 0, 0)
            End If

            getsrno(GRIDPURCHASE)
        ElseIf gridPURCHASEDoubleClick = True Then
            GRIDPURCHASE.Item(GPURSRNO.Index, tempPURCHASErow).Value = Val(TXTPURSRNO.Text.Trim)
            GRIDPURCHASE.Item(GPURNAME.Index, tempPURCHASErow).Value = CMBPURNAME.Text.Trim
            GRIDPURCHASE.Item(GPURDATE.Index, tempPURCHASErow).Value = Format(PURDATE.Value.Date, "dd/MM/yyyy")
            GRIDPURCHASE.Item(GPURHSNITEMDESC.Index, tempPURCHASErow).Value = CMBPURHSNITEMDESC.Text.Trim
            GRIDPURCHASE.Item(GPURHSNCODE.Index, tempPURCHASErow).Value = TXTPURHSNCODE.Text.Trim

            GRIDPURCHASE.Item(GPURAMT.Index, tempPURCHASErow).Value = Format(Val(TXTPURAMT.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GDISCPER.Index, tempPURCHASErow).Value = Format(Val(TXTDISCRECDPER.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GDISC.Index, tempPURCHASErow).Value = Format(Val(TXTDISCRECDRS.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GSUBTOTAL.Index, tempPURCHASErow).Value = Format(Val(TXTSUBTOTAL.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GCOMMPER.Index, tempPURCHASErow).Value = Format(Val(TXTCOMMRECDPER.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GCOMM.Index, tempPURCHASErow).Value = Format(Val(TXTCOMMRECDRS.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GTDSPER.Index, tempPURCHASErow).Value = Format(Val(TXTPURTDSPER.Text.Trim), "0.00")

            GRIDPURCHASE.Item(GTDS.Index, tempPURCHASErow).Value = Format(Val(TXTPURTDSRS.Text.Trim), "0.00")
            'GRIDPURCHASE.Item(GPURSERVICETAX.Index, tempPURCHASErow).Value = Val(CHKPURSERVTAX.CheckState)
            If CHKPURSERVTAX.Checked = True Then
                GRIDPURCHASE.Item(GPURSERVICETAX.Index, temprow).Value = 1
            Else
                GRIDPURCHASE.Item(GPURSERVICETAX.Index, temprow).Value = 0
            End If

            GRIDPURCHASE.Item(GPURTAXSERVCHGS.Index, tempPURCHASErow).Value = Format(Val(TXTPURSERVCHGS.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GNETTTOTAL.Index, tempPURCHASErow).Value = Format(Val(TXTPURNETTAMT.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GTAX.Index, tempPURCHASErow).Value = CMBPURTAX.Text.Trim
            GRIDPURCHASE.Item(GTAXAMT.Index, tempPURCHASErow).Value = Format(Val(TXTPURTAX.Text.Trim), "0.00")

            GRIDPURCHASE.Item(GCGSTPER.Index, tempPURCHASErow).Value = Format(Val(TXTPURCGSTPER.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GCGSTAMT.Index, tempPURCHASErow).Value = Format(Val(TXTPURCGSTAMT.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GSGSTPER.Index, tempPURCHASErow).Value = Format(Val(TXTPURSGSTPER.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GSGSTAMT.Index, tempPURCHASErow).Value = Format(Val(TXTPURSGSTAMT.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GIGSTPER.Index, tempPURCHASErow).Value = Format(Val(TXTPURIGSTPER.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GIGSTAMT.Index, tempPURCHASErow).Value = Format(Val(TXTPURIGSTAMT.Text.Trim), "0.00")


            GRIDPURCHASE.Item(GOTHERCHGSNAME.Index, tempPURCHASErow).Value = CMBPUROTHERCHGS.Text.Trim
            GRIDPURCHASE.Item(GOTHERCHGS.Index, tempPURCHASErow).Value = Format(Val(TXTPUROTHERCHGS.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GROUNDOFF.Index, tempPURCHASErow).Value = Format(Val(TXTPURROUNDOFF.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GGRANDTOTAL.Index, tempPURCHASErow).Value = Format(Val(TXTPURGTOTAL.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GPURAMTPAID.Index, tempPURCHASErow).Value = Format(Val(TXTPURAMTPAID.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GPUREXTRAAMT.Index, tempPURCHASErow).Value = Format(Val(TXTPUREXTRAAMT.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GPURRETURN.Index, tempPURCHASErow).Value = Format(Val(TXTPURRETURN.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GPURBAL.Index, tempPURCHASErow).Value = Format(Val(TXTPURBAL.Text.Trim), "0.00")
            gridPURCHASEDoubleClick = False
        End If

        GRIDPURCHASE.FirstDisplayedScrollingRowIndex = GRIDPURCHASE.RowCount - 1

        TXTPURSRNO.Clear()
        CMBPURNAME.Text = ""
        PURDATE.Value = Mydate

        TXTPURAMT.Clear()
        TXTDISCRECDPER.Clear()
        TXTDISCRECDRS.Clear()
        TXTPURSUBTOTAL.Clear()
        TXTCOMMRECDPER.Clear()
        TXTCOMMRECDRS.Clear()
        TXTPURTDSPER.Clear()
        TXTPURTDSRS.Clear()

        CHKPURSERVTAX.CheckState = CheckState.Unchecked
        TXTPURSERVCHGS.Clear()
        TXTPURCGSTPER.Clear()
        TXTPURCGSTAMT.Clear()
        TXTPURSGSTPER.Clear()
        TXTPURSGSTAMT.Clear()
        TXTPURIGSTPER.Clear()
        TXTPURIGSTAMT.Clear()

        TXTPURNETTAMT.Clear()
        CMBPURTAX.Text = ""
        TXTPURTAX.Clear()
        CMBPUROTHERCHGS.Text = ""
        TXTPUROTHERCHGS.Clear()
        TXTPURROUNDOFF.Clear()
        TXTPURGTOTAL.Clear()

        CMBPURNAME.Focus()

        TXTPURHSNCODE.Clear()
        CMBPURHSNITEMDESC.SelectedIndex = 0


    End Sub

    Sub FILLGRIDCAR()
        Try
            EP.Clear()
            If Not CALDAYS() Then
                Exit Sub
            End If
            If GRIDCARDOUBLECLICK = False Then

                GRIDTRANS.Rows.Add(Val(TXTCARSRNO.Text.Trim), CMBDRIVER.Text.Trim, CMBCARNAME.Text.Trim, CMBVEHICLENO.Text.Trim, Val(TXTCARADULTS.Text.Trim), Val(TXTCARCHILDS.Text.Trim), (Val(TXTCARADULTS.Text.Trim) + Val(TXTCARCHILDS.Text.Trim)), Format(PICKUPDATE.Value.Date, "dd/MM/yyyy"), TXTPICKFROM.Text.Trim, TXTPICKTIME.Text.Trim, TXTPICKDTLS.Text.Trim, Format(DROPDATE.Value.Date, "dd/MM/yyyy"), TXTDROPAT.Text.Trim, TXTDROPTIME.Text.Trim, TXTDROPDTLS.Text.Trim, Val(TXTCARDAYS.Text.Trim), TXTROUTE.Text.Trim, TXTCARNOTE.Text.Trim, Val(TXTAPPHRS.Text.Trim), Val(TXTAPPKMS.Text.Trim), Val(TXTALLOWANCE.Text.Trim), Val(TXTCARAMT.Text.Trim))
                getsrno(GRIDTRANS)

            ElseIf GRIDCARDOUBLECLICK = True Then

                GRIDTRANS.Item(GCARSRNO.Index, TEMPCARROW).Value = TXTCARSRNO.Text.Trim
                GRIDTRANS.Item(GDRIVER.Index, TEMPCARROW).Value = CMBDRIVER.Text.Trim
                GRIDTRANS.Item(GCARNAME.Index, TEMPCARROW).Value = CMBCARNAME.Text.Trim
                GRIDTRANS.Item(GVEHICLENO.Index, TEMPCARROW).Value = CMBVEHICLENO.Text.Trim
                GRIDTRANS.Item(GCARADULTS.Index, TEMPCARROW).Value = Val(TXTCARADULTS.Text.Trim)
                GRIDTRANS.Item(GCARCHILDS.Index, TEMPCARROW).Value = Val(TXTCARCHILDS.Text.Trim)
                GRIDTRANS.Item(GCARPAX.Index, TEMPCARROW).Value = (Val(TXTCARADULTS.Text.Trim) + Val(TXTCARCHILDS.Text.Trim))
                GRIDTRANS.Item(GCARPICKUP.Index, TEMPCARROW).Value = Format(PICKUPDATE.Value.Date, "dd/MM/yyyy")
                GRIDTRANS.Item(GCARPICKUPFROM.Index, TEMPCARROW).Value = TXTPICKFROM.Text.Trim
                GRIDTRANS.Item(GCARPICKUPTIME.Index, TEMPCARROW).Value = TXTPICKTIME.Text.Trim
                GRIDTRANS.Item(GCARPICKUPDTLS.Index, TEMPCARROW).Value = TXTPICKDTLS.Text.Trim
                GRIDTRANS.Item(GCARDROP.Index, TEMPCARROW).Value = Format(DROPDATE.Value.Date, "dd/MM/yyyy")
                GRIDTRANS.Item(GCARDROPTO.Index, TEMPCARROW).Value = TXTDROPAT.Text.Trim
                GRIDTRANS.Item(GCARDROPTIME.Index, TEMPCARROW).Value = TXTDROPTIME.Text.Trim
                GRIDTRANS.Item(GCARDROPDTLS.Index, TEMPCARROW).Value = TXTDROPDTLS.Text.Trim
                GRIDTRANS.Item(GCARDAYS.Index, TEMPCARROW).Value = Val(TXTCARDAYS.Text.Trim)
                GRIDTRANS.Item(GCARROUTE.Index, TEMPCARROW).Value = TXTROUTE.Text.Trim
                GRIDTRANS.Item(GCARNOTE.Index, TEMPCARROW).Value = TXTCARNOTE.Text.Trim
                GRIDTRANS.Item(GHRS.Index, TEMPCARROW).Value = Val(TXTAPPHRS.Text.Trim)
                GRIDTRANS.Item(GKMS.Index, TEMPCARROW).Value = Val(TXTAPPKMS.Text.Trim)
                GRIDTRANS.Item(GALLOWANCE.Index, TEMPCARROW).Value = Val(TXTALLOWANCE.Text.Trim)
                GRIDTRANS.Item(GCARAMT.Index, TEMPCARROW).Value = Val(TXTCARAMT.Text.Trim)


                GRIDCARDOUBLECLICK = False

            End If
            GRIDTRANS.FirstDisplayedScrollingRowIndex = GRIDTRANS.RowCount - 1

            TXTCARSRNO.Clear()
            CMBDRIVER.Text = ""
            CMBCARNAME.Text = ""
            CMBVEHICLENO.Text = ""
            TXTCARADULTS.Text = 0.0
            TXTCARCHILDS.Text = 0.0
            PICKUPDATE.Value = Mydate
            TXTPICKFROM.Clear()
            TXTPICKTIME.Clear()
            TXTPICKDTLS.Clear()
            DROPDATE.Value = DateAdd(DateInterval.Day, 1, Mydate)
            TXTDROPAT.Clear()
            TXTDROPTIME.Clear()
            TXTDROPDTLS.Clear()
            TXTCARDAYS.Text = 1
            TXTROUTE.Clear()
            TXTCARNOTE.Clear()
            TXTAPPHRS.Clear()
            TXTAPPKMS.Clear()
            TXTALLOWANCE.Clear()
            TXTCARAMT.Clear()
            TXTCARSRNO.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub FILLGRIDDTLS()
        Try
            FILLGRIDCARDTLS()
            If gridDoubleClick = False Then

                GRIDDETAILS.Rows.Add(Val(TXTSRNO.Text.Trim), Format(CARPICKDATE.Value.Date, "dd/MM/yyyy"), Format(CARDROPDATE.Value.Date, "dd/MM/yyyy"), Val(TXTSTART.Text.Trim), Val(TXTEND.Text.Trim), Format(PICKTIME.Value, "hh:mm  tt"), Format(DROPTIME.Value, "hh:mm  tt"), Val(TXTRUNHRS.Text.Trim), Val(TXTRUNKMS.Text.Trim), Val(TXTEXTRAHRS.Text.Trim), Val(TXTEXTRAKMS.Text.Trim), GRIDTRANS.CurrentRow.Cells(GCARSRNO.Index).Value)
                getsrno(GRIDDETAILS)

            ElseIf gridDoubleClick = True Then

                GRIDDETAILS.Item(GDATE.Index, temprow).Value = Format(CARPICKDATE.Value.Date, "dd/MM/yyyy")
                GRIDDETAILS.Item(GDROPDATE.Index, temprow).Value = Format(CARDROPDATE.Value.Date, "dd/MM/yyyy")
                GRIDDETAILS.Item(GSTART.Index, temprow).Value = Val(TXTSTART.Text.Trim)
                GRIDDETAILS.Item(GEND.Index, temprow).Value = Val(TXTEND.Text.Trim)
                GRIDDETAILS.Item(GINTIME.Index, temprow).Value = Format(PICKTIME.Value, "hh:mm  tt")
                GRIDDETAILS.Item(GOUTTIME.Index, temprow).Value = Format(DROPTIME.Value, "hh:mm  tt")
                GRIDDETAILS.Item(GTOTALHRS.Index, temprow).Value = Val(TXTRUNHRS.Text.Trim)
                GRIDDETAILS.Item(GTOTALKMS.Index, temprow).Value = Val(TXTRUNKMS.Text.Trim)
                GRIDDETAILS.Item(GEXTRAHRS.Index, temprow).Value = Val(TXTEXTRAHRS.Text.Trim)
                GRIDDETAILS.Item(GEXTRAKMS.Index, temprow).Value = Val(TXTEXTRAKMS.Text.Trim)


                gridDoubleClick = False

            End If
            'GRIDDETAILS.FirstDisplayedScrollingRowIndex = GRIDCARDTLS.RowCount - 1

            TXTSRNO.Clear()
            TXTSTART.Clear()
            TXTEND.Clear()
            'PICKTIME.Value = Format(Now.Date, "hh:mm  tt")
            'DROPTIME.Value = Format(Now.Date, "hh:mm  tt")
            TXTRUNHRS.Clear()
            TXTRUNKMS.Clear()
            TXTEXTRAHRS.Clear()
            TXTEXTRAKMS.Clear()
            TXTSRNO.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub FILLGRIDCARDTLS()
        Try
            If gridDoubleClick = False Then
                GRIDCARDTLS.Rows.Add((Val(GRIDDETAILS.RowCount) + 1), Format(CARPICKDATE.Value.Date, "dd/MM/yyyy"), Format(CARDROPDATE.Value.Date, "dd/MM/yyyy"), Val(TXTSTART.Text.Trim), Val(TXTEND.Text.Trim), Format(PICKTIME.Value, "hh:ss  tt"), Format(DROPTIME.Value, "hh:ss  tt"), Val(TXTRUNHRS.Text.Trim), Val(TXTRUNKMS.Text.Trim), Val(TXTEXTRAHRS.Text.Trim), Val(TXTEXTRAKMS.Text.Trim), GRIDTRANS.CurrentRow.Cells(GCARSRNO.Index).Value)
            ElseIf gridDoubleClick = True Then

                'FIRST GETTING ROWNO WITH RESPECT TO GRIDPAYDESC'S SRNO AND PAYMENT'S GRIDSRNO
                Dim ROWNO As Integer = 0
                For Each ROW As DataGridViewRow In GRIDCARDTLS.Rows
                    If ROW.Cells(GDTLSSRNO.Index).Value = temprow + 1 And ROW.Cells(GDTLSMAINSRNO.Index).Value = GRIDTRANS.CurrentRow.Cells(GCARSRNO.Index).Value Then
                        ROWNO = ROW.Index
                        Exit For
                    End If
                Next

                GRIDCARDTLS.Item(GDTLSCARPICKDATE.Index, ROWNO).Value = Format(CARPICKDATE.Value.Date, "dd/MM/yyyy")
                GRIDCARDTLS.Item(GDTLSCARDROPDATE.Index, ROWNO).Value = Format(CARDROPDATE.Value.Date, "dd/MM/yyyy")
                GRIDCARDTLS.Item(GDTLSSTART.Index, ROWNO).Value = Val(TXTSTART.Text.Trim)
                GRIDCARDTLS.Item(GDTLSEND.Index, ROWNO).Value = Val(TXTEND.Text.Trim)
                GRIDCARDTLS.Item(GDTLSINTIME.Index, ROWNO).Value = Format(PICKTIME.Value, "hh:ss  tt")
                GRIDCARDTLS.Item(GDTLSOUTTIME.Index, ROWNO).Value = Format(DROPTIME.Value, "hh:ss  tt")
                GRIDCARDTLS.Item(GDTLSTOTALHRS.Index, ROWNO).Value = Val(TXTRUNHRS.Text.Trim)
                GRIDCARDTLS.Item(GDTLSTOTALKMS.Index, ROWNO).Value = Val(TXTRUNKMS.Text.Trim)
                GRIDCARDTLS.Item(GDTLSEXTRAHRS.Index, ROWNO).Value = Val(TXTEXTRAHRS.Text.Trim)
                GRIDCARDTLS.Item(GDTLSEXTRAKMS.Index, ROWNO).Value = Val(TXTEXTRAKMS.Text.Trim)

            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub FILLGRIDMISC()
        Try
            If GRIDMISCDOUBLECLICK = False Then

                GRIDMISC.Rows.Add(Val(TXTMISCSRNO.Text.Trim), TXTMISCSERVICETYPE.Text.Trim, TXTMISCREMARKS.Text.Trim, Val(TXTMISCAMT.Text.Trim))
                getsrno(GRIDMISC)

            ElseIf GRIDMISCDOUBLECLICK = True Then

                GRIDMISC.Item(GMISCSRNO.Index, tempMISCrow).Value = TXTMISCSRNO.Text.Trim
                GRIDMISC.Item(GMISCSERVICETYPE.Index, tempMISCrow).Value = TXTMISCSERVICETYPE.Text.Trim
                GRIDMISC.Item(GMISCREMARKS.Index, tempMISCrow).Value = TXTMISCREMARKS.Text.Trim
                GRIDMISC.Item(GMISCAMOUNT.Index, tempMISCrow).Value = TXTMISCAMT.Text.Trim

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

    Private Sub GRIDMISC_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDMISC.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDMISC.Item(GMISCSRNO.Index, e.RowIndex).Value <> Nothing Then

                GRIDMISCDOUBLECLICK = True
                TXTMISCSRNO.Text = GRIDMISC.Item(GMISCSRNO.Index, e.RowIndex).Value.ToString
                TXTMISCSERVICETYPE.Text = GRIDMISC.Item(GMISCSERVICETYPE.Index, e.RowIndex).Value.ToString
                TXTMISCREMARKS.Text = GRIDMISC.Item(GMISCREMARKS.Index, e.RowIndex).Value.ToString
                TXTMISCAMT.Text = GRIDMISC.Item(GMISCAMOUNT.Index, e.RowIndex).Value.ToString

                tempMISCrow = e.RowIndex
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

    Private Sub GRIDPURCHASE_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDPURCHASE.CellClick
        Try
            If e.ColumnIndex = GCHK.Index Then
                With GRIDPURCHASE.Rows(e.RowIndex).Cells(GCHK.Index)
                    If .Value = True Then
                        .Value = False
                    Else
                        .Value = True
                    End If
                End With
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDPURCHASE_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDPURCHASE.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDPURCHASE.Item(GPURSRNO.Index, e.RowIndex).Value <> Nothing Then

                gridPURCHASEDoubleClick = True
                TXTPURSRNO.Text = GRIDPURCHASE.Item(GPURSRNO.Index, e.RowIndex).Value.ToString
                CMBPURNAME.Text = GRIDPURCHASE.Item(GPURNAME.Index, e.RowIndex).Value.ToString
                PURDATE.Value = Convert.ToDateTime(GRIDPURCHASE.Item(GPURDATE.Index, e.RowIndex).Value).Date
                CMBPURHSNITEMDESC.Text = GRIDPURCHASE.Item(GPURHSNITEMDESC.Index, e.RowIndex).Value.ToString
                TXTPURHSNCODE.Text = GRIDPURCHASE.Item(GPURHSNCODE.Index, e.RowIndex).Value.ToString

                TXTPURAMT.Text = GRIDPURCHASE.Item(GPURAMT.Index, e.RowIndex).Value.ToString
                TXTDISCRECDPER.Text = GRIDPURCHASE.Item(GDISCPER.Index, e.RowIndex).Value.ToString
                TXTDISCRECDRS.Text = GRIDPURCHASE.Item(GDISC.Index, e.RowIndex).Value.ToString
                TXTPURSUBTOTAL.Text = GRIDPURCHASE.Item(GSUBTOTAL.Index, e.RowIndex).Value.ToString
                TXTCOMMRECDPER.Text = GRIDPURCHASE.Item(GCOMMPER.Index, e.RowIndex).Value.ToString
                TXTCOMMRECDRS.Text = GRIDPURCHASE.Item(GCOMM.Index, e.RowIndex).Value.ToString
                TXTPURTDSPER.Text = GRIDPURCHASE.Item(GTDSPER.Index, e.RowIndex).Value.ToString
                TXTPURTDSRS.Text = GRIDPURCHASE.Item(GTDS.Index, e.RowIndex).Value.ToString

                'CHKPURSERVTAX.CheckState = GRIDPURCHASE.Item(GPURSERVICETAX.Index, e.RowIndex).Value
                'If CHKPURSERVTAX.Checked = True Then
                '    GRIDPURCHASE.Item(GPURSERVICETAX.Index, temprow).Value = 1
                'Else
                '    GRIDPURCHASE.Item(GPURSERVICETAX.Index, temprow).Value = 0
                'End If
                CHKPURSERVTAX.Checked = Convert.ToBoolean(GRIDPURCHASE.Item(GPURSERVICETAX.Index, e.RowIndex).Value)

                TXTPURSERVCHGS.Text = GRIDPURCHASE.Item(GPURTAXSERVCHGS.Index, e.RowIndex).Value.ToString

                TXTPURNETTAMT.Text = GRIDPURCHASE.Item(GNETTTOTAL.Index, e.RowIndex).Value.ToString
                CMBPURTAX.Text = GRIDPURCHASE.Item(GTAX.Index, e.RowIndex).Value.ToString
                TXTPURTAX.Text = GRIDPURCHASE.Item(GTAXAMT.Index, e.RowIndex).Value.ToString

                TXTPURCGSTPER.Text = GRIDPURCHASE.Item(GCGSTPER.Index, e.RowIndex).Value.ToString
                TXTPURCGSTAMT.Text = GRIDPURCHASE.Item(GCGSTAMT.Index, e.RowIndex).Value.ToString
                TXTPURSGSTPER.Text = GRIDPURCHASE.Item(GSGSTPER.Index, e.RowIndex).Value.ToString
                TXTPURSGSTAMT.Text = GRIDPURCHASE.Item(GSGSTAMT.Index, e.RowIndex).Value.ToString
                TXTPURIGSTPER.Text = GRIDPURCHASE.Item(GIGSTPER.Index, e.RowIndex).Value.ToString
                TXTPURIGSTAMT.Text = GRIDPURCHASE.Item(GIGSTAMT.Index, e.RowIndex).Value.ToString

                CMBPUROTHERCHGS.Text = GRIDPURCHASE.Item(GOTHERCHGSNAME.Index, e.RowIndex).Value.ToString
                TXTPUROTHERCHGS.Text = GRIDPURCHASE.Item(GOTHERCHGS.Index, e.RowIndex).Value.ToString
                TXTPURROUNDOFF.Text = GRIDPURCHASE.Item(GROUNDOFF.Index, e.RowIndex).Value.ToString
                TXTPURGTOTAL.Text = GRIDPURCHASE.Item(GGRANDTOTAL.Index, e.RowIndex).Value.ToString

                tempPURCHASErow = e.RowIndex
                CMBPURNAME.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDPURCHASE_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDPURCHASE.CellValueChanged
        Try
            If e.RowIndex < 0 Then Exit Sub
            If e.RowIndex >= 0 And GRIDPURCHASE.Item(GPURSRNO.Index, e.RowIndex).Value <> Nothing Then
                If GRIDPURCHASE.Rows(e.RowIndex).Cells(GCHK.Index).Value = True Then
                    GRIDPURCHASE.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightGreen
                Else
                    GRIDPURCHASE.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Empty
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDPURCHASE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDPURCHASE.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDPURCHASE.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If gridPURCHASEDoubleClick = True Then
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

    Sub fillgridTOUR()

        GRIDTOUR.Enabled = True

        If GRIDTOURDOUBLECLICK = False Then
            GRIDTOUR.Rows.Add(Val(TXTTOURSRNO.Text.Trim), Format(TOURDATE.Value.Date, "dd/MM/yyyy"), TXTTOURDETAILS.Text.Trim)
            getsrno(GRIDTOUR)
        ElseIf GRIDTOURDOUBLECLICK = True Then
            GRIDTOUR.Item(GTOURSRNO.Index, tempTOURrow).Value = Val(TXTTOURSRNO.Text.Trim)
            GRIDTOUR.Item(GTOURDATE.Index, tempTOURrow).Value = Format(TOURDATE.Value.Date, "dd/MM/yyyy")
            GRIDTOUR.Item(GTOURDETAILS.Index, tempTOURrow).Value = TXTTOURDETAILS.Text.Trim
            GRIDTOURDOUBLECLICK = False
        End If

        GRIDTOUR.FirstDisplayedScrollingRowIndex = GRIDTOUR.RowCount - 1

        TXTTOURSRNO.Clear()
        TOURDATE.Value = Mydate
        TXTTOURDETAILS.Clear()
        TXTTOURSRNO.Focus()

    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If tstxtbillno.Text.Trim.Length = 0 Then Exit Sub
            GRIDDETAILS.RowCount = 0
            TEMPBOOKINGNO = Val(tstxtbillno.Text)
            If TEMPBOOKINGNO > 0 Then
                edit = True
                CarBooking_Load(sender, e)
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
            Dim OBJBOOKING As New CarBookingDetails
            OBJBOOKING.MdiParent = MDIMain
            OBJBOOKING.Show()
            OBJBOOKING.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            GRIDTRANS.RowCount = 0
LINE1:
            TEMPBOOKINGNO = Val(txtbookingno.Text) - 1
Line2:
            If TEMPBOOKINGNO > 0 Then

                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" BOOKING_NO ", "", "  CARBOOKINGMASTER ", " AND CARBOOKINGMASTER.BOOKING_NO = '" & TEMPBOOKINGNO & "' AND CARBOOKINGMASTER.BOOKING_CMPID = " & CmpId & " AND CARBOOKINGMASTER.BOOKING_LOCATIONID = " & Locationid & " AND CARBOOKINGMASTER.BOOKING_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    edit = True
                    CarBooking_Load(sender, e)
                Else
                    TEMPBOOKINGNO = Val(TEMPBOOKINGNO - 1)
                    GoTo Line2
                End If
            Else
                clear()
                edit = False
            End If

            If GRIDTRANS.RowCount = 0 And TEMPBOOKINGNO > 1 Then
                txtbookingno.Text = TEMPBOOKINGNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            GRIDTRANS.RowCount = 0
LINE1:
            TEMPBOOKINGNO = Val(txtbookingno.Text) + 1
            getmax_BOOKING_no()
            Dim MAXNO As Integer = txtbookingno.Text.Trim
            clear()
            If Val(txtbookingno.Text) - 1 >= TEMPBOOKINGNO Then
                edit = True
                CarBooking_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If GRIDTRANS.RowCount = 0 And TEMPBOOKINGNO < MAXNO Then
                txtbookingno.Text = TEMPBOOKINGNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUP_SECONDARY = 'SUNDRY DEBTORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETBALANCE()
        Try

            Dim USERACCOUNTSADD, USERACCOUNTSEDIT, USERACCOUNTSVIEW, USERACCOUNTSDELETE As Boolean
            Dim DTACCOUNTSROW() As DataRow
            DTACCOUNTSROW = USERRIGHTS.Select("FormName = 'ACCOUNT REPORTS'")
            USERACCOUNTSADD = DTACCOUNTSROW(0).Item(1)
            USERACCOUNTSEDIT = DTACCOUNTSROW(0).Item(2)
            USERACCOUNTSVIEW = DTACCOUNTSROW(0).Item(3)
            USERACCOUNTSDELETE = DTACCOUNTSROW(0).Item(4)
            'If USERACCOUNTSVIEW = True Then
            LBLPURBAL.ForeColor = Color.Green
            LBLACCBAL.ForeColor = Color.Green

            LBLPURBAL.Text = "0.00"
            LBLACCBAL.Text = "0.00"
            If USERACCOUNTSVIEW = False Then
                LBLPURBAL.Visible = False
                LBLACCBAL.Visible = False
            End If
            'SALE BALANCE
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("(CASE WHEN DR > 0 THEN CAST(DR AS VARCHAR) + ' Dr'  ELSE CAST(CR AS VARCHAR) + ' Cr' END) AS SALEBAL, ISNULL(ACC_CRLIMIT,0) AS CRLIMIT, (CASE WHEN DR > 0 THEN DR ELSE CR END) AS BALANCE ", "", "  TRIALBALANCE INNER JOIN LEDGERS ON TRIALBALANCE.LEDGERID = LEDGERS.ACC_ID ", " AND NAME = '" & CMBNAME.Text.Trim & "' AND LEDGERS.ACC_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                LBLACCBAL.Text = DT.Rows(0).Item("SALEBAL")
                If Val(DT.Rows(0).Item("CRLIMIT")) < Val(DT.Rows(0).Item("BALANCE")) And Val(DT.Rows(0).Item("CRLIMIT")) > 0 Then
                    LBLACCBAL.ForeColor = Color.Red
                Else
                    LBLACCBAL.ForeColor = Color.Green
                End If
            End If


            'PUR BALANCE
            For Each drow As Windows.Forms.DataGridViewRow In GRIDPURCHASE.Rows
                DT = OBJCMN.search("(CASE WHEN DR > 0 THEN CAST(DR AS VARCHAR) + ' Dr'  ELSE CAST(CR AS VARCHAR) + ' Cr' END) AS PURBAL , ISNULL(ACC_CRLIMIT,0) AS CRLIMIT, (CASE WHEN DR > 0 THEN DR ELSE CR END) AS BALANCE ", "", "  TRIALBALANCE INNER JOIN LEDGERS ON TRIALBALANCE.LEDGERID = LEDGERS.ACC_ID", " AND NAME = '" & drow.Cells(GPURNAME.Index).Value.ToString & "' AND LEDGERS.ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    'LBLPURBAL.Text = DT.Rows(0).Item("PURBAL")
                    If Val(DT.Rows(0).Item("CRLIMIT")) < Val(DT.Rows(0).Item("BALANCE")) And Val(DT.Rows(0).Item("CRLIMIT")) > 0 Then
                        LBLPURBAL.ForeColor = Color.Red
                    Else
                        LBLPURBAL.ForeColor = Color.Green
                    End If
                End If
                'End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function CHECKPURCHASEBALANCES() As Boolean
        Dim OBJCMN As New ClsCommon
        Dim DT As DataTable
        Dim TEMPMSG As Integer
        Dim BLN As Boolean = False
        For Each drow As Windows.Forms.DataGridViewRow In GRIDPURCHASE.Rows
            DT = OBJCMN.search("(CASE WHEN DR > 0 THEN CAST(DR AS VARCHAR) + ' Dr'  ELSE CAST(CR AS VARCHAR) + ' Cr' END) AS PURBAL , ISNULL(ACC_CRLIMIT,0) AS CRLIMIT, (CASE WHEN DR > 0 THEN DR ELSE CR END) AS BALANCE ", "", "  TRIALBALANCE INNER JOIN LEDGERS ON TRIALBALANCE.LEDGERID = LEDGERS.ACC_ID ", " AND NAME = '" & drow.Cells(GPURNAME.Index).Value.ToString & "' AND LEDGERS.ACC_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                'LBLPURBAL.Text = DT.Rows(0).Item("PURBAL")
                If Val(DT.Rows(0).Item("CRLIMIT")) < Val(DT.Rows(0).Item("BALANCE")) And Val(DT.Rows(0).Item("CRLIMIT")) > 0 Then
                    TEMPMSG = MsgBox("Credit Limit Exceeded for " & drow.Cells(GPURNAME.Index).Value.ToString & ", Wish to Proceed?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbNo Then
                        BLN = True
                        Exit For
                    End If
                End If
            End If
            'End If
        Next
        Return BLN
    End Function

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

    Private Sub CMBNAME_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Validated
        Try
            If CMBNAME.Text.Trim <> "" Then
                GETBALANCE()


                If ClientName = "SCC" Then
                    'FETCH SERVICE TAX FROM ACCOUNTSMASTER AND WITH RESPECT TO THAT GET TAX FROM TAXMASTER
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable
                    DT = OBJCMN.search("ISNULL(TAXMASTER.tax_name,'') AS TAXNAME", "", " LEDGERS INNER JOIN TAXMASTER ON LEDGERS.Acc_kstno = TAXMASTER.tax_tax AND LEDGERS.Acc_yearid = TAXMASTER.tax_yearid ", " AND LEDGERS.ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND ACC_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        cmbtax.Text = DT.Rows(0).Item("TAXNAME")
                    Else
                        cmbtax.Text = ""
                    End If
                    total()
                    FILLGUESTCONFIG()
                End If

                Dim OBJCMN1 As New ClsCommon
                Dim DT1 As DataTable

                DT1 = OBJCMN1.search(" ISNULL(STATEMASTER.state_remark, '') AS STATECODE ", "", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_cmpid = GROUPMASTER.group_cmpid AND LEDGERS.Acc_locationid = GROUPMASTER.group_locationid AND LEDGERS.Acc_yearid = GROUPMASTER.group_yearid AND LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id ", " and LEDGERS.acc_cmpname = '" & CMBNAME.Text.Trim & "' and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' and LEDGERS.acc_YEARid = " & YearId)
                If DT1.Rows.Count > 0 Then

                    TXTSTATECODE.Text = DT1.Rows(0).Item("STATECODE")

                End If
                GETHSNCODE()
            End If

            If edit = False And TXTPICKFROM.Text.Trim = "" Then
                If MsgBox("Pickup from Company Add?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then TXTPICKFROM.Text = TXTADD.Text.Trim
            End If
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGUESTCONFIG()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" ISNULL(GUESTMASTER.GUEST_NAME, '') AS GUESTNAME ", "", " GUESTLEDGERCONFIG INNER JOIN GUESTMASTER ON GUESTLEDGERCONFIG.CONFIG_GUESTID = GUESTMASTER.GUEST_ID INNER JOIN LEDGERS ON GUESTLEDGERCONFIG.CONFIG_LEDGERID = LEDGERS.Acc_id ", " AND CONFIG_YEARID = " & YearId & " AND LEDGERS.ACC_CMPNAME = '" & CMBNAME.Text.Trim & "'")
            If DT.Rows.Count > 0 Then
                Dim TNAME As String = ""
                If edit = True Then TNAME = CMBGUESTNAME.Text.Trim
                DT.DefaultView.Sort = "GUESTNAME"
                CMBGUESTNAME.DataSource = DT
                CMBGUESTNAME.DisplayMember = "GUESTNAME"
                If edit = True Then CMBGUESTNAME.Text = TNAME Else CMBGUESTNAME.Text = ""
            End If
            CMBGUESTNAME.SelectAll()
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

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Try
            If edit = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If lbllocked.Visible = True Or lblcancelled.Visible = True Or PBPAID.Visible = True Or PBRECD.Visible = True Then
                    MsgBox("Voucher Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                Dim tempmsg As Integer = MsgBox("Delete Booking Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                If tempmsg = vbYes Then

                    Dim OBJBOOKING As New ClsCarBooking
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(TEMPBOOKINGNO)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Locationid)
                    ALPARAVAL.Add(YearId)
                    ALPARAVAL.Add(Userid)


                    OBJBOOKING.alParaval = ALPARAVAL
                    Dim DT As DataTable = OBJBOOKING.Delete()
                    MsgBox(DT.Rows(0).Item(0).ToString)

                    clear()
                    edit = False

                End If

            End If
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

    Private Sub TXTOURCOMMPER_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTOURCOMMPER.Validated, TXTOURCOMMRS.Validated, TXTDISCPER.Validated, TXTDISCRS.Validated, cmbaddsub.Validated, txtotherchg.Validated
        total()
    End Sub

    Private Sub TXTPUROTHERCHGS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPUROTHERCHGS.KeyPress
        If e.KeyChar <> "-" Then
            numdotkeypress(e, TXTPUROTHERCHGS, Me)
        End If
    End Sub

    Private Sub CMBPURTAX_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPURTAX.Enter
        Try
            If CMBPURTAX.Text.Trim = "" Then filltax(CMBPURTAX, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBPURTAX_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBPURTAX.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub CMBPURTAX_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPURTAX.Validating
        Try
            If CMBPURTAX.Text.Trim <> "" Then TAXvalidate(CMBPURTAX, e, Me)
            PURCHASECALC()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
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

    Private Sub CMBPURCODE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPURCODE.Enter
        Try
            If CMBPURCODE.Text.Trim = "" Then fillACCCODE(CMBPURCODE, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPURNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPURNAME.Enter
        Try
            If CMBPURNAME.Text.Trim = "" Then fillname(CMBPURNAME, edit, " AND GROUP_SECONDARY = 'SUNDRY CREDITORS'")
        Catch ex As Exception
            Throw ex
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

    Private Sub CMBPURNAME_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPURNAME.Validated
        Try
            If CMBPURNAME.Text.Trim <> "" Then

                Dim OBJCMN1 As New ClsCommon
                Dim DT1 As DataTable = OBJCMN1.search(" ISNULL(STATEMASTER.state_remark, '') AS PURSTATECODE ", "", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_cmpid = GROUPMASTER.group_cmpid AND LEDGERS.Acc_locationid = GROUPMASTER.group_locationid AND LEDGERS.Acc_yearid = GROUPMASTER.group_yearid AND LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id ", " and LEDGERS.acc_cmpname = '" & CMBPURNAME.Text.Trim & "' and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' and LEDGERS.acc_YEARid = " & YearId)
                If DT1.Rows.Count > 0 Then TXTPURSTATECODE.Text = DT1.Rows(0).Item("PURSTATECODE")
                GETHSNCODE()
                GETBALANCE()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPURNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPURNAME.Validating
        Try
            If CMBPURNAME.Text.Trim <> "" Then namevalidate(CMBPURNAME, CMBPURCODE, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripCANCEL.Click
        Try
            If edit = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                TEMPMSG = MsgBox("Wish to Cancel Booking Voucher?", MsgBoxStyle.YesNo, "TRAVELMATE")
                If TEMPMSG = vbYes Then
                    Dim OBJBOOKING As New ClsCarBooking
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(TEMPBOOKINGNO)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Locationid)
                    ALPARAVAL.Add(YearId)

                    OBJBOOKING.alParaval = ALPARAVAL
                    Dim INTRESULT As Integer = OBJBOOKING.CANCEL
                    'If chkmobile.CheckState = CheckState.Checked Then SENDMSG("Hi, Your booking in " & CMBHOTELNAME.Text.Trim & " is Cancelled", txtmobileno.Text.Trim)
                    MsgBox("Booking Cancelled")
                    clear()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTREPORT(ByVal BOOKNO As Integer)

        If CMBPRINT.Text = "All" Or CMBPRINT.Text = "" Then

            If ClientName = "SCC" Then
                If MsgBox("Wish to Print Duty Slip?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim OBJINV As New CarBookingVoucherDesign
                    OBJINV.MdiParent = MDIMain
                    OBJINV.BOOKINGNO = BOOKNO
                    OBJINV.FRMSTRING = "DUTYSLIP"
                    OBJINV.Show()
                End If

                If MsgBox("Wish to Print Welcome Board?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim OBJINV As New CarBookingVoucherDesign
                    OBJINV.MdiParent = MDIMain
                    OBJINV.BOOKINGNO = BOOKNO
                    OBJINV.FRMSTRING = "WELCOMEBOARD"
                    OBJINV.Show()
                End If
            End If

            If ClientName <> "SCC" Then
                TEMPMSG = MsgBox("Wish to Print Voucher?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim OBJVOUCHER As New CarBookingVoucherDesign
                    OBJVOUCHER.MdiParent = MDIMain
                    OBJVOUCHER.BOOKINGNO = BOOKNO
                    If ClientName <> "CLASSIC" Then OBJVOUCHER.TEMP = "TEMP"
                    OBJVOUCHER.FRMSTRING = "VOUCHER"
                    OBJVOUCHER.CARVOUCHERSTR = ""
                    OBJVOUCHER.Show()
                End If
            End If

            TEMPMSG = MsgBox("Wish to Print Invoice?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then

                Dim OBJINV As New CarBookingVoucherDesign
                OBJINV.MdiParent = MDIMain
                OBJINV.BOOKINGNO = BOOKNO
                OBJINV.BOOKINGDATE = bookingdate.Value.Date
                If ClientName <> "CLASSIC" Then
                    OBJINV.CARVOUCHERSTR = ""
                    OBJINV.TEMP = "TEMP"
                End If
                OBJINV.HIDEAMT = chkhideamt.Checked
                OBJINV.PRINTGUESTNAME = chkguestname.Checked
                OBJINV.FRMSTRING = "INVOICE"
                If ClientName = "SCC" Then
                    If MsgBox("Print on Blank Paper?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then OBJINV.FRMSTRING = "INVOICEBLANK"
                End If
                OBJINV.Show()
            End If

        ElseIf CMBPRINT.Text = "Voucher" Then

            Dim OBJVOUCHER As New CarBookingVoucherDesign
            OBJVOUCHER.MdiParent = MDIMain
            OBJVOUCHER.BOOKINGNO = BOOKNO
            If ClientName <> "CLASSIC" Or ClientName <> "PLANET" Or ClientName = "PARAMOUNT" Then OBJVOUCHER.TEMP = "TEMP"
            OBJVOUCHER.FRMSTRING = "VOUCHER"
            If ClientName = "UTTARAKHAND" Then OBJVOUCHER.SUBJECT = "Reservation Voucher No. " & BOOKNO & " Ref No. " & txtrefno.Text.Trim
            OBJVOUCHER.CARVOUCHERSTR = ""
            OBJVOUCHER.Show()

        ElseIf CMBPRINT.Text = "Invoice" Then

            Dim OBJINV As New CarBookingVoucherDesign
            OBJINV.MdiParent = MDIMain
            OBJINV.BOOKINGNO = BOOKNO
            OBJINV.BOOKINGDATE = bookingdate.Value.Date
            If ClientName <> "CLASSIC" Then
                OBJINV.CARVOUCHERSTR = ""
                OBJINV.TEMP = "TEMP"
            End If
            OBJINV.HIDEAMT = chkhideamt.Checked
            OBJINV.PRINTGUESTNAME = chkguestname.Checked
            OBJINV.FRMSTRING = "INVOICE"
            If ClientName = "SCC" Then
                If MsgBox("Print on Blank Paper?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then OBJINV.FRMSTRING = "INVOICEBLANK"
            End If
            OBJINV.Show()

        ElseIf CMBPRINT.Text = "Duty Slip" Then

            If ClientName = "SCC" Then
                Dim OBJINV As New CarBookingVoucherDesign
                OBJINV.MdiParent = MDIMain
                OBJINV.BOOKINGNO = BOOKNO
                OBJINV.FRMSTRING = "DUTYSLIP"
                OBJINV.Show()
            End If

        ElseIf CMBPRINT.Text = "Board" Then

            If ClientName = "SCC" Then
                Dim OBJINV As New CarBookingVoucherDesign
                OBJINV.MdiParent = MDIMain
                OBJINV.BOOKINGNO = BOOKNO
                OBJINV.FRMSTRING = "WELCOMEBOARD"
                OBJINV.Show()
            End If

        End If

    End Sub

    Private Sub ToolStripprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripprint.Click
        Try
            If edit = True Then PRINTREPORT(TEMPBOOKINGNO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPURGTOTAL_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTPURGTOTAL.Validating
        Try
            If CMBPURNAME.Text.Trim <> "" And Val(TXTPURAMT.Text.Trim) > 0 And Val(TXTPURGTOTAL.Text.Trim) > 0 Then
                If ClientName = "SCC" And GRIDPURCHASE.RowCount > 0 And gridPURCHASEDoubleClick = False Then Exit Sub
                fillgridPURCHASE()
                total()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical, "TRAVELMATE")
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PBDICSRECDDEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBDICSRECDDEL.Click
        Try
            TXTDISCRECDPER.Text = 0.0
            TXTDISCRECDRS.Text = 0.0
            TXTPURTDSPER.Text = 0.0
            TXTPURTDSRS.Text = 0.0
            TXTCOMMRECDPER.Text = 0.0
            TXTCOMMRECDRS.Text = 0.0

            PURCHASECALC()
            TXTDISCRECDPER.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPURTDSPER_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPURTDSPER.KeyPress, TXTCOMMRECDPER.KeyPress, TXTDISCRECDPER.KeyPress, TXTMISCAMT.KeyPress, TXTSUNDAYSRATE.KeyPress, TXTEXTRADROPRATE.KeyPress, TXTOUTSTATIONDAYSRATE.KeyPress, TXTKMSRATE.KeyPress, TXTHRSRATE.KeyPress, TXTEXTRACHGS.KeyPress, TXTHRKMRATE.KeyPress, TXTHRS.KeyPress, TXTEXTRAHRS.KeyPress, TXTDISCRECDRS.KeyPress, TXTPURAMT.KeyPress, TXTCOMMRECDRS.KeyPress, txtotherchg.KeyPress, TXTDISCRS.KeyPress, TXTDISCPER.KeyPress, TXTOURCOMMPER.KeyPress, TXTOURCOMMRS.KeyPress, TXTPURTDSRS.KeyPress, TXTPURSTARTTIME.KeyPress, TXTPURENDTIME.KeyPress, TXTKMSPUR.KeyPress, TXTHRSPUR.KeyPress, TXTHRSRATEPUR.KeyPress, TXTKMSRATEPUR.KeyPress, TXTAPPHRS.KeyPress, TXTHRKMRATEPUR.KeyPress, TXTCARAMT.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTPURTDSPER_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTPURTDSPER.Validated, TXTCOMMRECDPER.Validated, TXTDISCRECDPER.Validated, TXTPURSERVCHGS.Validated, TXTCOMMRECDRS.Validated, TXTDISCRECDRS.Validated, TXTPURAMT.Validated, TXTPUROTHERCHGS.Validated, TXTPURTAX.Validated, TXTPURTDSRS.Validated
        PURCHASECALC()
    End Sub

    Private Sub TXTCOPY_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCOPY.KeyPress
        Try
            numkeypress(e, TXTCOPY, Me)
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

                        TEMPBOOKINGNO = TXTCOPY.Text.Trim
                        clear()

                        TXTCOPY.Text = TEMPBOOKINGNO
                        TEMPBOOKINGNO = 0

                        Dim ALPARAVAL As New ArrayList
                        Dim OBJBOOKING As New ClsCarBooking()

                        ALPARAVAL.Add(Val(TXTCOPY.Text.Trim))
                        ALPARAVAL.Add(CmpId)
                        ALPARAVAL.Add(Locationid)
                        ALPARAVAL.Add(YearId)

                        OBJBOOKING.alParaval = ALPARAVAL
                        Dim dt As DataTable = OBJBOOKING.SELECTBOOKINGDESC()
                        If dt.Rows.Count > 0 Then
                            For Each dr As DataRow In dt.Rows

                                '*****************
                                bookingdate.Value = Convert.ToDateTime(dr("BOOKINGDATE")).Date
                                DDATE = bookingdate.Value
                                txtrefno.Text = dr("REFNO")

                                CMBGUESTNAME.Text = Convert.ToString(dr("GUESTNAME"))
                                CMBPREFIX.Text = Convert.ToString(dr("PREFIX"))
                                CMBACCCODE.Text = Convert.ToString(dr("ACCCODE"))
                                CMBNAME.Text = Convert.ToString(dr("NAME"))
                                CMBTYPE.Text = Convert.ToString(dr("TYPE"))
                                CMBTOUR.Text = Convert.ToString(dr("TOURNAME"))

                                PACKAGEFROM.Value = Convert.ToDateTime(dr("PACKAGEFROM")).Date
                                PACKAGETO.Value = Convert.ToDateTime(dr("PACKAGETO")).Date

                                If Val(dr("HRKMRATE")) > 0 Or Val(dr("HRSRATE")) > 0 Or Val(dr("KMSRATE")) > 0 Then
                                    CHKRATE.CheckState = CheckState.Checked
                                    TXTHRS.Text = Val(Convert.ToString(dr("HRS")))
                                    TXTKMS.Text = Val(Convert.ToString(dr("KMS")))
                                    TXTHRKMRATE.Text = Format(Val(Convert.ToString(dr("HRKMRATE"))), "0.00")
                                    TXTHRSRATE.Text = Format(Val(Convert.ToString(dr("HRSRATE"))), "0.00")
                                    TXTKMSRATE.Text = Format(Val(Convert.ToString(dr("KMSRATE"))), "0.00")
                                End If

                                If Val(dr("HRKMRATEPUR")) > 0 Or Val(dr("HRSRATEPUR")) > 0 Or Val(dr("KMSRATEPUR")) > 0 Then
                                    CHKRATEPUR.CheckState = CheckState.Checked
                                    TXTHRSPUR.Text = Val(Convert.ToString(dr("HRSPUR")))
                                    TXTKMSPUR.Text = Val(Convert.ToString(dr("KMSPUR")))
                                    TXTHRKMRATEPUR.Text = Format(Val(Convert.ToString(dr("HRKMRATEPUR"))), "0.00")
                                    TXTHRSRATEPUR.Text = Format(Val(Convert.ToString(dr("HRSRATEPUR"))), "0.00")
                                    TXTKMSRATEPUR.Text = Format(Val(Convert.ToString(dr("KMSRATEPUR"))), "0.00")
                                End If

                                TXTALLOWANCEPUR.Text = Format(Val(Convert.ToString(dr("ALLOWANCEPUR"))), "0.00")
                                TXTNIGHTALLOWANCEPUR.Text = Format(Val(Convert.ToString(dr("NIGHTALLOWANCEPUR"))), "0.00")

                                TXTSUNDAYS.Text = Val(Convert.ToString(dr("SUNDAYS")))
                                TXTSUNDAYSRATE.Text = Format(Val(Convert.ToString(dr("SUNDAYSRATE"))), "0.00")
                                TXTEXTRADROP.Text = Val(Convert.ToString(dr("EXTRADROP")))
                                TXTEXTRADROPRATE.Text = Format(Val(Convert.ToString(dr("EXTRADROPRATE"))), "0.00")
                                TXTOUTSTATIONDAYS.Text = Val(Convert.ToString(dr("OUTSTATIONDAYS")))
                                TXTOUTSTATIONDAYSRATE.Text = Format(Val(Convert.ToString(dr("OUTSTATIONDAYSRATE"))), "0.00")




                                cmbcity.Text = Convert.ToString(dr("CITY"))

                                TXTSTATECODE.Text = dr("STATECODE")
                                ' TXTPURSTATECODE.Text = dr("PURSTATECODE")
                                CMBHSNITEMDESC.Text = dr("HSNITEMDESC")
                                TXTHSNCODE.Text = dr("HSNCODE")

                                If Convert.ToBoolean(dr("MANUALGST")) = False Then CHKMANUAL.Checked = False Else CHKMANUAL.Checked = True
                                If Convert.ToBoolean(dr("PURMANUALGST")) = False Then CHKPURMANUAL.Checked = False Else CHKPURMANUAL.Checked = True

                                If CHKMANUAL.Checked = True Then
                                    TXTCGSTAMT.Text = Format(Val(dr("CGSTAMT")), "0.00")
                                    TXTSGSTAMT.Text = Format(Val(dr("SGSTAMT")), "0.00")
                                    TXTIGSTAMT.Text = Format(Val(dr("IGSTAMT")), "0.00")
                                End If

                                TXTCGSTPER.Text = Format(Val(Convert.ToString(dr("CGSTPER"))), "0.00")
                                TXTCGSTAMT.Text = Format(Val(Convert.ToString(dr("CGSTAMT"))), "0.00")
                                TXTSGSTPER.Text = Format(Val(Convert.ToString(dr("SGSTPER"))), "0.00")
                                TXTSGSTAMT.Text = Format(Val(Convert.ToString(dr("SGSTAMT"))), "0.00")
                                TXTIGSTPER.Text = Format(Val(Convert.ToString(dr("IGSTPER"))), "0.00")
                                TXTIGSTAMT.Text = Format(Val(Convert.ToString(dr("IGSTAMT"))), "0.00")

                                TXTARRIVALFROM.Text = Convert.ToString(dr("ARRIVAL"))
                                TXTDEPARTURETO.Text = Convert.ToString(dr("DEPARTURE"))

                                CMBBOOKEDBY.Text = dr("BOOKEDBY")
                                CMBSOURCE.Text = dr("SOURCE")
                                TXTMISCENQNO.Text = dr("MISCENQNO")

                                TXTTOTALSALEAMT.Text = dr("TOTALSALEAMT")
                                TXTOURCOMMPER.Text = dr("OURCOMMPER")
                                TXTOURCOMMRS.Text = dr("OURCOMMRS")
                                TXTDISCPER.Text = dr("DISCPER")
                                TXTDISCRS.Text = dr("DISCRS")
                                TXTEXTRACHGS.Text = dr("EXTRACHGS")

                                cmbtax.Text = dr("TAXNAME")
                                txttax.Text = dr("TAXAMT")
                                CMBADDTAX.Text = dr("ADDTAXNAME")
                                TXTADDTAX.Text = dr("ADDTAXAMT")

                                CHKTAXSERVCHGS.Checked = Convert.ToBoolean(dr("TAXSERVCHGS"))
                                TXTTAXSERVCHGS.Text = dr("TAXSERVCHGSAMT")
                                If ClientName = "SCC" Then
                                    CMBOTHERCHGS.Text = "Toll & Parking"
                                    cmbaddsub.Text = "Add"
                                    txtotherchg.Text = dr("OTHERCHGS")
                                Else
                                    CMBOTHERCHGS.Text = dr("OTHERCHGSNAME")
                                    If dr("OTHERCHGS") > 0 Then
                                        txtotherchg.Text = dr("OTHERCHGS")
                                        cmbaddsub.Text = "Add"
                                    Else
                                        txtotherchg.Text = dr("OTHERCHGS") * (-1)
                                        cmbaddsub.Text = "Sub."
                                    End If
                                End If


                                txtroundoff.Text = dr("ROUNDOFF")

                                TXTSALEAMTREC.Text = dr("SALEAMTREC")
                                TXTSALEEXTRAAMT.Text = dr("SALEEXTRAAMT")
                                TXTSALERETURN.Text = dr("SALERETURN")
                                TXTSALEBAL.Text = dr("SALEBAL")
                                TXTBAL.Text = dr("SALEBAL")

                                TXTSTART.Text = Val(dr("STARTKMS"))
                                TXTEND.Text = Val(dr("ENDKMS"))
                                TXTSTARTTIME.Text = Val(dr("STARTTIME"))
                                TXTENDTIME.Text = Val(dr("ENDTIME"))
                                TXTPURSTART.Text = Val(dr("PURSTARTKMS"))
                                TXTPUREND.Text = Val(dr("PURENDKMS"))
                                TXTPURSTARTTIME.Text = Val(dr("PURSTARTTIME"))
                                TXTPURENDTIME.Text = Val(dr("PURENDTIME"))

                                TXTCARQUALITY.Text = Convert.ToString(dr("CARQUALITY"))
                                TXTDRIVERQUALITY.Text = Convert.ToString(dr("DRIVERQUALITY"))
                                TXTCONFIRMEDBY.Text = Convert.ToString(dr("CONFIRMEDBY"))
                                TXTREMARKS.Text = Convert.ToString(dr("REMARKS"))
                                TXTBOOKINGDESC.Text = Convert.ToString(dr("BOOKINGDESC"))
                                TXTSPECIALREMARKS.Text = Convert.ToString(dr("SPECIALREMARKS"))


                                'TRANS DETAILS
                                GRIDTRANS.Rows.Add(dr("SRNO"), dr("DRIVERNAME"), dr("CARNAME"), dr("CARNO"), Val(dr("ADULTS")), Val(dr("CHILDS")), Val(dr("TOTALPAX")), Format(Convert.ToDateTime(dr("PICKUPON")).Date, "dd/MM/yyyy"), dr("PICKUPFROM"), dr("PICKUPTIME"), dr("PICKUPDTLS"), Format(Convert.ToDateTime(dr("DROPON")).Date, "dd/MM/yyyy"), dr("DROPAT"), dr("DROPTIME"), dr("DROPDTLS"), Val(dr("DAYS")), dr("ROUTE"), dr("CARNOTE"), Val(dr("APPROXHRS")), Val(dr("APPROXKMS")), Format(Val(dr("ALLOWANCE")), "0.00"), Format(Val(dr("CARAMT")), "0.00"))

                                '******************
                            Next
                            GRIDTRANS.FirstDisplayedScrollingRowIndex = GRIDTRANS.RowCount - 1

                        Else
                            'IF ROWCOUNT = 0
                            clear()
                            edit = False
                            CMBGUESTNAME.Focus()
                        End If



                        'DETAILS
                        dt = OBJBOOKING.SELECTBOOKINGDUTYSLIP()
                        If dt.Rows.Count > 0 Then
                            For Each DR As DataRow In dt.Rows
                                GRIDCARDTLS.Rows.Add(DR("CARSRNO"), Format(Convert.ToDateTime(DR("PICKDATE")).Date, "dd/MM/yyyy"), Format(Convert.ToDateTime(DR("PICKUPON")).Date, "dd/MM/yyyy"), DR("START"), DR("END"), DR("INTIME"), DR("OUTTIME"), DR("RUNHRS"), DR("RUNKMS"), DR("EXTRAHRS"), DR("EXTRAKMS"), DR("MAINSRNO"))
                            Next
                        End If



                        ''PURCHASE DETAILS
                        'dt = OBJBOOKING.SELECTBOOKINGPURDETAILS()
                        'If dt.Rows.Count > 0 Then


                        '    For Each DR As DataRow In dt.Rows
                        '        'GRIDPURCHASE.Rows.Add(0, DR("PURSRNO"), DR("PURNAME"), Format(Convert.ToDateTime(DR("PURDATE")).Date, "dd/MM/yyyy"), DR("PURAMT"), DR("PURDISCPER"), DR("PURDISC"), DR("PURSUBTOTAL"), DR("PURCOMMPER"), DR("PURCOMM"), DR("PURTDSPER"), DR("PURTDS"), DR("PURNETT"), DR("TAXNAME"), DR("TAXAMT"), DR("PUROTHERCHGSNAME"), DR("PUROTHERCHGS"), DR("PURROUNDOFF"), DR("PURGTOTAL"), 0, 0, 0, DR("PURGTOTAL"))
                        '        TXTPURSTATECODE.Text = DR("PURSTATECODE")

                        '        GRIDPURCHASE.Rows.Add(0, DR("PURSRNO"), DR("PURNAME"), Format(Convert.ToDateTime(DR("PURDATE")).Date, "dd/MM/yyyy"), DR("PURAMT"), DR("PURDISCPER"), DR("PURDISC"), DR("PURSUBTOTAL"), DR("PURCOMMPER"), DR("PURCOMM"), DR("PURTDSPER"), DR("PURTDS"), DR("PURSERVTAX"), DR("PURTAXSERVCHGS"), DR("PURNETT"), DR("TAXNAME"), DR("TAXAMT"), DR("PURCGSTPER"), DR("PURCGSTAMT"), DR("PURSGSTPER"), DR("PURSGSTAMT"), DR("PURIGSTPER"), DR("PURIGSTAMT"), DR("PUROTHERCHGSNAME"), DR("PUROTHERCHGS"), DR("PURROUNDOFF"), DR("PURGTOTAL"), 0, 0, 0, DR("PURGTOTAL"))

                        '    Next
                        '    GRIDPURCHASE.ClearSelection()
                        'End If

                        'PURCHASE DETAILS
                        dt = OBJBOOKING.SELECTBOOKINGPURDETAILS()

                        If dt.Rows.Count > 0 Then
                            For Each DR As DataRow In dt.Rows
                                'DONT FETCH STATECODE HERE... THERE MAY BE MULTIPLE VENDORS
                                'TXTPURSTATECODE.Text = DR("PURSTATECODE")
                                GRIDPURCHASE.Rows.Add(0, DR("PURSRNO"), DR("PURNAME"), Format(Convert.ToDateTime(DR("PURDATE")).Date, "dd/MM/yyyy"), DR("PURHSNITEMDESC"), DR("PURHSNCODE"), DR("PURAMT"), DR("PURDISCPER"), DR("PURDISC"), DR("PURSUBTOTAL"), DR("PURCOMMPER"), DR("PURCOMM"), DR("PURTDSPER"), DR("PURTDS"), DR("PURSERVTAX"), DR("PURTAXSERVCHGS"), DR("PURNETT"), DR("TAXNAME"), DR("TAXAMT"), DR("PURCGSTPER"), DR("PURCGSTAMT"), DR("PURSGSTPER"), DR("PURSGSTAMT"), DR("PURIGSTPER"), DR("PURIGSTAMT"), DR("PUROTHERCHGSNAME"), DR("PUROTHERCHGS"), DR("PURROUNDOFF"), DR("PURGTOTAL"), 0, 0, 0, DR("PURGTOTAL"))
                            Next
                            GRIDPURCHASE.ClearSelection()
                        End If


                        'GET SCAN DOCS DATA
                        Dim OBJCMN As New ClsCommon
                        dt = OBJCMN.search(" CARBOOKINGMASTER_UPLOAD.BOOKING_GRIDSRNO AS GRIDSRNO, CARBOOKINGMASTER_UPLOAD.BOOKING_REMARKS AS REMARKS, CARBOOKINGMASTER_UPLOAD.BOOKING_NAME AS NAME, CARBOOKINGMASTER_UPLOAD.BOOKING_IMGPATH AS IMGPATH, CARBOOKINGMASTER_UPLOAD.BOOKING_NEWIMGPATH AS NEWIMGPATH ", "", " CARBOOKINGMASTER_UPLOAD ", " AND CARBOOKINGMASTER_UPLOAD.BOOKING_NO = " & TEMPBOOKINGNO & " AND CARBOOKINGMASTER_UPLOAD.BOOKING_CMPID = " & CmpId & " AND  CARBOOKINGMASTER_UPLOAD.BOOKING_LOCATIONID  = " & Locationid & " AND CARBOOKINGMASTER_UPLOAD.BOOKING_YEARID = " & YearId & " ORDER BY CARBOOKINGMASTER_UPLOAD.BOOKING_GRIDSRNO")
                        If dt.Rows.Count > 0 Then
                            For Each DTR As DataRow In dt.Rows
                                gridupload.Rows.Add(DTR("GRIDSRNO"), DTR("REMARKS"), DTR("NAME"), DTR("IMGPATH"), DTR("NEWIMGPATH"))
                            Next
                        End If

                        'GET AIRLINE DATA
                        Dim OBJAIR1 As New ClsCommon
                        Dim DTA1 As DataTable = OBJAIR1.search(" ISNULL(BOOKING_NO, 0) AS GROUPDEPNO, ISNULL(BOOKING_GRIDSRNO, 0) AS AIRSRNO, ISNULL(BOOKING_SECTOR, '') AS SECTOR, ISNULL(BOOKING_FLTNO, '') AS FLTNO, ISNULL(BOOKING_TYPE, '') AS TYPE, ISNULL(BOOKING_BASIC, 0) AS BASIC, ISNULL(BOOKING_PSF, 0) AS PSF, ISNULL(BOOKING_TAXES, 0) AS TAXES, ISNULL(BOOKING_AMT, 0) AS AIRAMT ", "", " CARBOOKINGMASTER_AIRLINE ", " AND CARBOOKINGMASTER_AIRLINE.BOOKING_NO = " & TEMPBOOKINGNO & " AND BOOKING_YEARID = " & YearId & " ORDER BY CARBOOKINGMASTER_AIRLINE.BOOKING_GRIDSRNO")
                        If DTA1.Rows.Count > 0 Then
                            For Each DR1 As DataRow In DTA1.Rows
                                GRIDAIRLINE.Rows.Add(DR1("AIRSRNO"), DR1("SECTOR"), DR1("FLTNO"), DR1("TYPE"), Format(Val(DR1("BASIC")), "0.00"), Format(Val(DR1("PSF")), "0.00"), Format(Val(DR1("TAXES")), "0.00"), Format(Val(DR1("AIRAMT")), "0.00"))
                            Next
                            total()
                        End If


                        'GET GRIDFLIGHT DATA
                        Dim OBJAIR2 As New ClsCommon
                        Dim DTA2 As DataTable = OBJCMN.search(" CARBOOKINGMASTER_FLIGHTDESC.BOOKING_GRIDSRNO AS GRIDSRNO, CARBOOKINGMASTER_FLIGHTDESC.BOOKING_BOOKSRNO AS BOOKSRNO, ISNULL(FROMSECTORMASTER.SECTOR_NAME, '') AS FROMSEC, ISNULL(TOSECTORMASTER.SECTOR_NAME, '') AS TOSEC, CARBOOKINGMASTER_FLIGHTDESC.BOOKING_FLIGHTNO AS FLIGHTNO, CARBOOKINGMASTER_FLIGHTDESC.BOOKING_FLIGHTDATE AS FLIGHTDATE, ISNULL(CARBOOKINGMASTER_FLIGHTDESC.BOOKING_ARRIVES, '') AS ARRIVES, CLASSMASTER.CLASS_NAME AS CLASS", "", " SECTORMASTER AS TOSECTORMASTER RIGHT OUTER JOIN CARBOOKINGMASTER_FLIGHTDESC LEFT OUTER JOIN CLASSMASTER ON CARBOOKINGMASTER_FLIGHTDESC.BOOKING_YEARID = CLASSMASTER.CLASS_YEARID AND  CARBOOKINGMASTER_FLIGHTDESC.BOOKING_CMPID = CLASSMASTER.CLASS_CMPID AND CARBOOKINGMASTER_FLIGHTDESC.BOOKING_CLASSID = CLASSMASTER.CLASS_ID ON  TOSECTORMASTER.SECTOR_ID = CARBOOKINGMASTER_FLIGHTDESC.BOOKING_TOID AND TOSECTORMASTER.SECTOR_CMPID = CARBOOKINGMASTER_FLIGHTDESC.BOOKING_CMPID AND TOSECTORMASTER.SECTOR_YEARID = CARBOOKINGMASTER_FLIGHTDESC.BOOKING_YEARID LEFT OUTER JOIN SECTORMASTER AS FROMSECTORMASTER ON CARBOOKINGMASTER_FLIGHTDESC.BOOKING_FROMID = FROMSECTORMASTER.SECTOR_ID AND CARBOOKINGMASTER_FLIGHTDESC.BOOKING_CMPID = FROMSECTORMASTER.SECTOR_CMPID AND CARBOOKINGMASTER_FLIGHTDESC.BOOKING_YEARID = FROMSECTORMASTER.SECTOR_YEARID", " AND CARBOOKINGMASTER_FLIGHTDESC.BOOKING_NO = " & Val(TXTCOPY.Text.Trim) & " AND CARBOOKINGMASTER_FLIGHTDESC.BOOKING_CMPID = " & CmpId & " AND CARBOOKINGMASTER_FLIGHTDESC.BOOKING_YEARID = " & YearId & " ORDER BY CARBOOKINGMASTER_FLIGHTDESC.BOOKING_BOOKSRNO ASC, CARBOOKINGMASTER_FLIGHTDESC.BOOKING_GRIDSRNO ASC")
                        If dt.Rows.Count > 0 Then
                            For Each DR2 As DataRow In DTA2.Rows
                                GRIDFLIGHT.Rows.Add(DR2("GRIDSRNO").ToString, DR2("BOOKSRNO"), DR2("FROMSEC").ToString, DR2("TOSEC").ToString, DR2("FLIGHTNO").ToString, DR2("FLIGHTDATE").ToString, DR2("ARRIVES").ToString, DR2("CLASS").ToString)
                            Next
                            total()
                        End If


                        'MISC GRID
                        Dim OBJMISC As New ClsCommon
                        Dim DTM As DataTable = OBJMISC.search(" ISNULL(CARBOOKINGMASTER_MISC.ENQ_SRNO, 0) AS SRNO, ISNULL(CARBOOKINGMASTER_MISC.ENQ_TYPE, '') AS TYPE, ISNULL(CARBOOKINGMASTER_MISC.ENQ_REMARKS, '') AS REMARKS, ISNULL(CARBOOKINGMASTER_MISC.ENQ_AMOUNT, 0) AS MISCAMOUNT ", "", " CARBOOKINGMASTER INNER JOIN CARBOOKINGMASTER_MISC ON CARBOOKINGMASTER.BOOKING_NO = CARBOOKINGMASTER_MISC.ENQ_NO AND CARBOOKINGMASTER.BOOKING_YEARID = CARBOOKINGMASTER_MISC.ENQ_YEARID ", " AND CARBOOKINGMASTER_MISC.ENQ_NO = " & TEMPENQNO & " AND CARBOOKINGMASTER_MISC.ENQ_YEARID = " & YearId & " ORDER BY CARBOOKINGMASTER_MISC.ENQ_SRNO ")
                        If DTM.Rows.Count > 0 Then
                            For Each DR As DataRow In DTM.Rows
                                GRIDMISC.Rows.Add(Val(DR("SRNO")), DR("TYPE"), DR("REMARKS"), Val(DR("MISCAMOUNT")))
                            Next
                        End If

                        total()
                        chkchange.CheckState = CheckState.Checked

                    Else
                        MsgBox("Invalid Voucher No.", MsgBoxStyle.Critical)
                    End If
                End If
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

    Private Sub CMBPURCODE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBPURCODE.KeyDown
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

    Private Sub cmdshowdetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowdetails.Click
        Try
            Dim OBJRECPAY As New ShowRecPay
            OBJRECPAY.MdiParent = MDIMain
            OBJRECPAY.PURBILLINITIALS = "VP-" & TEMPBOOKINGNO
            OBJRECPAY.SALEBILLINITIALS = "VS-" & TEMPBOOKINGNO
            OBJRECPAY.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarBooking_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "CLASSIC" Then Me.Close()
        If ALLOWEINVOICE = True Then TOOLEINV.Visible = True
        If ClientName = "KHANNA" Then
            LBLGROUP.Visible = True
            CMBGROUPDEPARTURE.Visible = True
        End If
        If ClientName = "SCC" Or ClientName = "TRAVCON" Then
            LBLREFNO.Text = "Night Allowance"
            LBLPURSTART.Visible = True
            TXTPURSTART.Visible = True
            LBLPUREND.Visible = True
            TXTPUREND.Visible = True
            TXTPURTOTALKMS.Visible = True
            TXTPUREXTRAKMS.Visible = True
            LBLPURSTARTTIME.Visible = True
            TXTPURSTARTTIME.Visible = True
            LBLPURENDTIME.Visible = True
            TXTPURENDTIME.Visible = True
            TXTPURTOTALTIME.Visible = True
            TXTPUREXTRATIME.Visible = True
            LBLARRIVAL.Text = "Flt Details & Time"
            LBLDEPARTURE.Text = "Teminal"
            LBLBOOKEDBY.Text = "Recd By"
            LBLCONFIRMEDBY.Text = "Instruction From"
            chkguestname.Text = "Print Address"
            LBLALLOWANCEPUR.Visible = True
            TXTALLOWANCEPUR.Visible = True
            CHKRATEPUR.Visible = True
            GROUPRATEPUR.Visible = True
            LBLNIGHTALLOWANCEPUR.Visible = True
            TXTNIGHTALLOWANCEPUR.Visible = True
        End If
        If ClientName = "GLOBAL" Then
            CHKPURMANUAL.Visible = False
            CHKMANUAL.Visible = False
            LBLCGST.Visible = False
            TXTCGSTPER.Visible = False
            TXTCGSTAMT.Visible = False
            LBLSGST.Visible = False
            TXTSGSTPER.Visible = False
            TXTSGSTAMT.Visible = False
            LBLIGST.Visible = False
            TXTIGSTPER.Visible = False
            TXTIGSTAMT.Visible = False
            LBLHSNDESC.Visible = False
            CMBHSNITEMDESC.Visible = False
            LBLHSNCODE.Visible = False
            TXTHSNCODE.Visible = False
            LBLSTATECODE.Visible = False
            TXTSTATECODE.Visible = False
            TXTPURSTATECODE.Visible = False

            'For GRID VALUE PARAMETER
            CMBPURHSNITEMDESC.Visible = False
            GPURHSNITEMDESC.Visible = False
            TXTPURHSNCODE.Visible = False
            GPURHSNCODE.Visible = False
            TXTPURCGSTPER.Visible = False
            GCGSTPER.Visible = False
            GCGSTAMT.Visible = False
            TXTPURCGSTAMT.Visible = False
            GSGSTPER.Visible = False
            TXTPURSGSTPER.Visible = False
            GSGSTAMT.Visible = False
            TXTPURSGSTAMT.Visible = False
            GIGSTPER.Visible = False
            TXTPURIGSTPER.Visible = False
            GIGSTAMT.Visible = False
            TXTPURIGSTAMT.Visible = False


            TXTPURAMT.Left = CMBPURHSNITEMDESC.Left
            TXTDISCRECDPER.Left = TXTPURAMT.Left + TXTPURAMT.Width
            TXTDISCRECDRS.Left = TXTDISCRECDPER.Left + TXTDISCRECDPER.Width
            TXTCOMMRECDPER.Left = TXTDISCRECDRS.Left + TXTDISCRECDRS.Width
            TXTCOMMRECDRS.Left = TXTCOMMRECDPER.Left + TXTCOMMRECDPER.Width
            TXTPURTDSPER.Left = TXTCOMMRECDRS.Left + TXTCOMMRECDRS.Width
            TXTPURTDSRS.Left = TXTPURTDSPER.Left + TXTPURTDSPER.Width
            CHKPURSERVTAX.Left = TXTPURTDSRS.Left + TXTPURTDSRS.Width
            TXTPURSERVCHGS.Left = CHKPURSERVTAX.Left + CHKPURSERVTAX.Width
            CMBPURTAX.Left = TXTPURSERVCHGS.Left + TXTPURSERVCHGS.Width
            TXTPURTAX.Left = CMBPURTAX.Left + CMBPURTAX.Width
            CMBPUROTHERCHGS.Left = TXTPURTAX.Left + TXTPURTAX.Width
            TXTPUROTHERCHGS.Left = CMBPUROTHERCHGS.Left + CMBPUROTHERCHGS.Width
            TXTPURGTOTAL.Left = TXTPUROTHERCHGS.Left + TXTPUROTHERCHGS.Width

            If ClientName = "KHANNA" Then
                CMBGROUPDEPARTURE.Visible = True
            End If



        End If

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
        If edit = False Then
            If ClientName = "SCC" Or ClientName = "TRAVCON" Then
                PACKAGETO.Value = PACKAGEFROM.Value.Date
                bookingdate.Value = PACKAGEFROM.Value.Date
                PURDATE.Value = PACKAGEFROM.Value.Date
            Else
                PACKAGETO.Value = DateAdd(DateInterval.Day, 1, PACKAGEFROM.Value)
            End If
        End If
        PICKUPDATE.Value = PACKAGEFROM.Value.Date
        DROPDATE.Value = PACKAGETO.Value.Date
        CARPICKDATE.Value = PACKAGEFROM.Value.Date
        CARDROPDATE.Value = PACKAGETO.Value.Date
    End Sub

    Private Sub PACKAGETO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles PACKAGETO.Validating
        If ClientName = "CLASSIC" Then
            If Not datecheck(PACKAGETO.Value) Then
                MsgBox("Date Not in Current Accounting Year")
                e.Cancel = True
            End If
        End If
        DROPDATE.Value = PACKAGETO.Value.Date
        CARDROPDATE.Value = PACKAGETO.Value.Date
    End Sub

    Private Sub PURDATE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles PURDATE.Validated, bookingdate.Validated
        GETHSNCODE()
    End Sub

    Private Sub PURDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles PURDATE.Validating
        If Not datecheck(PURDATE.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Sub fillgridscan()
        Try
            If gridUPLOADdoubleclick = False Then

                gridupload.Rows.Add(Val(txtuploadsrno.Text.Trim), txtuploadremarks.Text.Trim, txtuploadname.Text.Trim, txtimgpath.Text.Trim, TXTNEWIMGPATH.Text.Trim, TXTFILENAME.Text.Trim)
                uploadgetsrno(gridupload)

            ElseIf gridUPLOADdoubleclick = True Then

                gridupload.Item(0, tempUPLOADrow).Value = txtuploadsrno.Text.Trim
                gridupload.Item(1, tempUPLOADrow).Value = txtuploadremarks.Text.Trim
                gridupload.Item(2, tempUPLOADrow).Value = txtuploadname.Text.Trim
                gridupload.Item(3, tempUPLOADrow).Value = txtimgpath.Text.Trim
                gridupload.Item(GNEWIMGPATH.Index, tempUPLOADrow).Value = TXTNEWIMGPATH.Text.Trim
                gridupload.Item(GFILENAME.Index, tempUPLOADrow).Value = TXTFILENAME.Text.Trim

                gridUPLOADdoubleclick = False

            End If
            gridupload.FirstDisplayedScrollingRowIndex = gridupload.RowCount - 1
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdupload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdupload.Click

        If (edit = True And USEREDIT = False And USERVIEW = False) Or (edit = False And USERADD = False) Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg;*.png;*.pdf)|*.bmp;*.jpg;*.png;*.pdf"
        OpenFileDialog1.ShowDialog()

        OpenFileDialog1.AddExtension = True
        TXTFILENAME.Text = OpenFileDialog1.SafeFileName
        txtimgpath.Text = OpenFileDialog1.FileName
        TXTNEWIMGPATH.Text = Application.StartupPath & "\CAR" & txtbookingno.Text.Trim & txtuploadsrno.Text.Trim & TXTFILENAME.Text.Trim
        On Error Resume Next

        If txtimgpath.Text.Trim.Length <> 0 Then
            PBSoftCopy.ImageLocation = txtimgpath.Text.Trim
            PBSoftCopy.Load(txtimgpath.Text.Trim)
            txtuploadsrno.Focus()
        End If
    End Sub

    Private Sub txtuploadname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtuploadname.Validating
        Try
            If txtimgpath.Text.Trim <> "" And txtuploadname.Text.Trim <> "" Then
                fillgridscan()
                txtuploadremarks.Clear()
                txtuploadname.Clear()
                txtimgpath.Clear()
                PBSoftCopy.ImageLocation = ""
                txtuploadsrno.Focus()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub gridupload_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.CellDoubleClick
        Try
            If gridupload.Rows(e.RowIndex).Cells(GGRIDUPLOADSRNO.Index).Value <> Nothing Then
                gridUPLOADdoubleclick = True
                tempUPLOADrow = e.RowIndex
                txtuploadsrno.Text = gridupload.Rows(e.RowIndex).Cells(GGRIDUPLOADSRNO.Index).Value
                txtuploadremarks.Text = gridupload.Rows(e.RowIndex).Cells(GREMARKS.Index).Value
                txtuploadname.Text = gridupload.Rows(e.RowIndex).Cells(GGRIDUPLOADNAME.Index).Value
                txtimgpath.Text = gridupload.Rows(e.RowIndex).Cells(GIMGPATH.Index).Value
                TXTNEWIMGPATH.Text = gridupload.Rows(e.RowIndex).Cells(GNEWIMGPATH.Index).Value
                TXTFILENAME.Text = gridupload.Rows(e.RowIndex).Cells(GFILENAME.Index).Value
                txtuploadsrno.Focus()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridupload_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridupload.KeyDown
        If e.KeyCode = Keys.Delete And gridupload.RowCount > 0 Then
            Dim TEMPMSG As Integer = MsgBox("This Will Delete File, Wish to Proceed?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                If FileIO.FileSystem.FileExists(gridupload.Rows(gridupload.CurrentRow.Index).Cells(GNEWIMGPATH.Index).Value) Then FileIO.FileSystem.DeleteFile(gridupload.Rows(gridupload.CurrentRow.Index).Cells(GNEWIMGPATH.Index).Value)
                gridupload.Rows.RemoveAt(gridupload.CurrentRow.Index)
                uploadgetsrno(gridupload)
            End If
        End If
    End Sub

    Private Sub gridupload_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.RowEnter
        Try
            If gridupload.RowCount > 0 Then
                If Not FileIO.FileSystem.FileExists(gridupload.Rows(e.RowIndex).Cells(GNEWIMGPATH.Index).Value) Then
                    PBSoftCopy.ImageLocation = gridupload.Rows(e.RowIndex).Cells(GIMGPATH.Index).Value
                Else
                    PBSoftCopy.ImageLocation = gridupload.Rows(e.RowIndex).Cells(GNEWIMGPATH.Index).Value
                End If
                txtimgpath.Text = PBSoftCopy.ImageLocation
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtuploadsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtuploadsrno.GotFocus
        If gridUPLOADdoubleclick = False Then
            If gridupload.RowCount > 0 Then
                txtuploadsrno.Text = Val(gridupload.Rows(gridupload.RowCount - 1).Cells(GGRIDUPLOADSRNO.Index).Value) + 1
            Else
                txtuploadsrno.Text = 1
            End If
        End If
    End Sub

    Sub uploadgetsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            'If edit = False Then
            Dim i As Integer = 0
            For Each row As DataGridViewRow In grid.Rows
                If row.Visible = True Then
                    row.Cells(GGRIDUPLOADSRNO.Index).Value = i + 1
                    i = i + 1
                End If
            Next
            'End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDVIEW.Click
        Try
            If txtimgpath.Text.Trim <> "" Then
                If Path.GetExtension(txtimgpath.Text.Trim) = ".pdf" Then
                    System.Diagnostics.Process.Start(txtimgpath.Text.Trim)
                Else
                    Dim objVIEW As New ViewImage
                    objVIEW.pbsoftcopy.ImageLocation = PBSoftCopy.ImageLocation
                    objVIEW.ShowDialog()
                End If
            End If
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

    Private Sub TXTCARAMT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCARAMT.Validating
        Try
            If CMBCARNAME.Text.Trim <> "" And Val(TXTCARADULTS.Text.Trim) > 0 And TXTPICKFROM.Text.Trim <> "" Then
                If Not CALDAYS() Then
                    MsgBox("Enter Proper Dates", MsgBoxStyle.Critical, "TRAVELMATE")
                    PICKUPDATE.Focus()
                    Exit Sub
                End If
                If (ClientName = "SCC" Or ClientName = "TRAVCON") And GRIDTRANS.RowCount > 0 And GRIDCARDOUBLECLICK = False Then Exit Sub
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

    Sub GETDESCDATA(ByVal ROWNO As Integer)
        Try
            GRIDDETAILS.RowCount = 0
            For Each ROW As DataGridViewRow In GRIDCARDTLS.Rows
                If ROW.Cells(GMAINSRNO.Index).Value = ROWNO + 1 Then
                    GRIDDETAILS.Rows.Add(ROW.Cells(GDTLSSRNO.Index).Value, ROW.Cells(GDTLSCARPICKDATE.Index).Value, ROW.Cells(GDTLSCARDROPDATE.Index).Value, ROW.Cells(GDTLSSTART.Index).Value, ROW.Cells(GDTLSEND.Index).Value, ROW.Cells(GDTLSINTIME.Index).Value, ROW.Cells(GDTLSOUTTIME.Index).Value, ROW.Cells(GDTLSTOTALHRS.Index).Value, ROW.Cells(GDTLSTOTALKMS.Index).Value, ROW.Cells(GDTLSEXTRAHRS.Index).Value, ROW.Cells(GDTLSEXTRAKMS.Index).Value, ROW.Cells(GDTLSMAINSRNO.Index).Value)
                End If
            Next
            getsrno(GRIDDETAILS)
            DETAILTOTAL()
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
                CMBDRIVER.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GDRIVER.Index).Value
                CMBCARNAME.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARNAME.Index).Value
                CMBVEHICLENO.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GVEHICLENO.Index).Value
                TXTCARADULTS.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARADULTS.Index).Value
                TXTCARCHILDS.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARCHILDS.Index).Value
                PICKUPDATE.Value = GRIDTRANS.Rows(e.RowIndex).Cells(GCARPICKUP.Index).Value
                TXTPICKFROM.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARPICKUPFROM.Index).Value
                TXTPICKTIME.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARPICKUPTIME.Index).Value
                TXTPICKDTLS.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARPICKUPDTLS.Index).Value
                DROPDATE.Value = GRIDTRANS.Rows(e.RowIndex).Cells(GCARDROP.Index).Value
                TXTDROPAT.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARDROPTO.Index).Value
                TXTDROPTIME.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARDROPTIME.Index).Value
                TXTDROPDTLS.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARDROPDTLS.Index).Value
                TXTROUTE.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARROUTE.Index).Value
                TXTCARNOTE.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARNOTE.Index).Value
                TXTAPPHRS.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GHRS.Index).Value
                TXTAPPKMS.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GKMS.Index).Value
                TXTALLOWANCE.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GALLOWANCE.Index).Value
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


                'FINDING ROW IN GRIDCARDTLS
1:
                For Each ROW As DataGridViewRow In GRIDCARDTLS.Rows
                    If ROW.Cells(GMAINSRNO.Index).Value = GRIDTRANS.CurrentRow.Cells(GCARSRNO.Index).Value Then
                        GRIDCARDTLS.Rows.RemoveAt(ROW.Index)
                        GoTo 1
                    ElseIf ROW.Cells(GMAINSRNO.Index).Value > GRIDTRANS.CurrentRow.Cells(GCARSRNO.Index).Value Then
                        ROW.Cells(GMAINSRNO.Index).Value = ROW.Cells(GMAINSRNO.Index).Value - 1
                    End If
                Next
                GRIDDETAILS.RowCount = 0
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

    Private Sub DROPDDATE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles DROPDATE.Validated
        Try
            'CALDAYS()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DROPDDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DROPDATE.Validating
        If ClientName = "CLASSIC" Then
            If Not datecheck(DROPDATE.Value) Then
                MsgBox("Date Not in Current Accounting Year")
                e.Cancel = True
            End If
        End If
    End Sub

    Function CALDAYS() As Boolean
        Try
            Dim BLN As Boolean = True

            If CMBCARNAME.Text.Trim <> "" And Val(TXTCARADULTS.Text.Trim) > 0 Then
                If PICKUPDATE.Value.Date < PACKAGEFROM.Value.Date Then
                    BLN = False
                    EP.SetError(PACKAGETO, "Invalid Pickup Date")
                End If
                If DROPDATE.Value.Date > PACKAGETO.Value.Date Then
                    BLN = False
                    EP.SetError(PACKAGETO, "Invalid Drop Date")
                End If

                If DROPDATE.Value.Date > PICKUPDATE.Value.Date Then
                    If ClientName = "SCC" Or ClientName = "TRAVCON" Then TXTCARDAYS.Text = Val(DROPDATE.Value.Date.Subtract(PICKUPDATE.Value.Date).Days) + 1 Else TXTCARDAYS.Text = DROPDATE.Value.Date.Subtract(PICKUPDATE.Value.Date).Days

                    'DONE BY GULKIT LET THIS CODE BE FOR ALL
                    'ElseIf DROPDATE.Value.Date = PICKUPDATE.Value.Date And (ClientName = "ELYSIUM" Or ClientName = "ESSGEE") Then
                ElseIf DROPDATE.Value.Date = PICKUPDATE.Value.Date Then
                    TXTCARDAYS.Text = 1
                Else
                    Exit Function
                    EP.SetError(PACKAGETO, "Invalid Drop Date")
                End If
            End If



            If PACKAGETO.Value.Date > PACKAGEFROM.Value.Date Then
                TXTPACKAGEDAYS.Text = PACKAGETO.Value.Date.Subtract(PACKAGEFROM.Value.Date).Days

                'FOR SOME CLIENTS ONLY
                'WE CHANGED IT FOR ALL THE CLIENTS
                'ElseIf PACKAGETO.Value.Date = PACKAGEFROM.Value.Date And (ClientName = "ELYSIUM" Or ClientName = "ESSGEE" Or ClientName = "PRATAMESH" Or ClientName = "ARHAM" Or ClientName = "MAHARAJA" Or ClientName = "URMI") Then
            ElseIf PACKAGETO.Value.Date = PACKAGEFROM.Value.Date Then
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
        'If edit = False Then DROPDATE.Value = DateAdd(DateInterval.Day, 1, PICKUPDATE.Value)
    End Sub

    Private Sub CMBDRIVER_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDRIVER.Enter
        Try
            If CMBDRIVER.Text.Trim = "" Then FILLDRIVERNAME(CMBDRIVER, edit, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDRIVER_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDRIVER.Validating
        Try
            If CMBDRIVER.Text.Trim <> "" Then DRIVERNAMEVALIDATE(CMBDRIVER, e, Me, TXTDRIVERADD)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKRATE_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKRATE.CheckStateChanged
        If CHKRATE.Checked = True Then
            TXTHRS.Enabled = True
            TXTKMS.Enabled = True
            TXTHRSRATE.Enabled = True
            TXTKMSRATE.Enabled = True
            TXTCARAMT.ReadOnly = True
            TXTCARAMT.Text = "0.00"
            CALC()
        Else
            '-- clear first
            'TXTHRS.Text = "0"
            'TXTKMS.Text = "0"
            'TXTHRSRATE.Text = "0.00"
            'TXTKMSRATE.Text = "0.00"
            'TXTHRKMRATE.Text = "0.00"

            TXTHRS.Enabled = True
            TXTKMS.Enabled = True
            TXTHRSRATE.Enabled = True
            TXTKMSRATE.Enabled = True
            TXTHRKMRATE.Enabled = True
            TXTCARAMT.ReadOnly = False
            For Each ROW As DataGridViewRow In GRIDTRANS.Rows
                ROW.Cells(GCARAMT.Index).Value = 0
            Next
        End If
        total()
    End Sub

    Private Sub CHKRATEPUR_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKRATEPUR.CheckStateChanged
        If CHKRATEPUR.Checked = True Then
            TXTHRSPUR.Enabled = True
            TXTKMSPUR.Enabled = True
            TXTHRSRATEPUR.Enabled = True
            TXTKMSRATEPUR.Enabled = True
            TXTPURAMT.ReadOnly = True
            TXTPURAMT.Text = "0.00"
            CALCPUR()
        Else
            TXTHRSPUR.Enabled = True
            TXTKMSPUR.Enabled = True
            TXTHRSRATEPUR.Enabled = True
            TXTKMSRATEPUR.Enabled = True
            TXTHRKMRATEPUR.Enabled = True
            TXTPURAMT.ReadOnly = False
            For Each ROW As DataGridViewRow In GRIDPURCHASE.Rows
                ROW.Cells(GPURAMT.Index).Value = 0
            Next
        End If
        total()
    End Sub

    Private Sub CMBPREFIX_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPREFIX.Enter
        Try
            If CMBPREFIX.Text.Trim = "" Then FILLPREFIX(CMBPREFIX)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPREFIX_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBPREFIX.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub CMBPREFIX_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPREFIX.Validating
        Try
            If CMBPREFIX.Text.Trim <> "" Then PREFIXvalidate(CMBPREFIX, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKRATE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKRATE.CheckedChanged
        Try
            GROUPRATE.Enabled = CHKRATE.CheckState
            TXTCARAMT.Enabled = True
            CALC()
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKRATEPUR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKRATEPUR.CheckedChanged
        Try
            GROUPRATEPUR.Enabled = CHKRATEPUR.CheckState
            TXTPURAMT.Enabled = True
            CALCPUR()
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CALC()
        Try
            Dim KMS As Double = 0
            Dim HRS As Double = 0

            'AIRLINE GRID
            TXTAIRAMT.Text = Format((Val(TXTBASIC.Text.Trim) + Val(TXTPSF.Text.Trim) + Val(TXTGRIDTAX.Text.Trim)), "0.00")

            If CHKRATE.CheckState = CheckState.Checked Then
                TXTCARAMT.Text = 0
                If Val(TXTHRKMRATE.Text.Trim) > 0 Then
                    HRS = Val(TXTAPPHRS.Text.Trim) - Val(TXTHRS.Text.Trim)
                    If HRS < 0 Then HRS = 0

                    KMS = Val(TXTAPPKMS.Text.Trim) - Val(TXTKMS.Text.Trim)
                    If KMS < 0 Then KMS = 0

                    TXTCARAMT.Text = Format(Val(Val(TXTALLOWANCE.Text.Trim) + Val(TXTHRKMRATE.Text.Trim) + (Val(HRS) * Val(TXTHRSRATE.Text.Trim)) + (Val(KMS) * Val(TXTKMSRATE.Text.Trim))), "0.00")
                End If

                If CMBTYPE.Text <> "OUTSTATION" Then
                    If Val(TXTHRKMRATE.Text.Trim) = 0 And Val(TXTHRSRATE.Text.Trim) > 0 Then
                        TXTCARAMT.Text = Format(Val(TXTALLOWANCE.Text.Trim) + Val(TXTCARAMT.Text.Trim) + Val(Val(TXTAPPHRS.Text.Trim) * Val(TXTHRSRATE.Text.Trim)), "0.00")
                    End If
                End If
                If Val(TXTHRKMRATE.Text.Trim) = 0 And Val(TXTKMSRATE.Text.Trim) > 0 Then
                    TXTCARAMT.Text = Format(Val(TXTALLOWANCE.Text.Trim) + Val(TXTCARAMT.Text.Trim) + Val(Val(TXTAPPKMS.Text.Trim) * Val(TXTKMSRATE.Text.Trim)), "0.00")
                End If


                For Each ROW As DataGridViewRow In GRIDTRANS.Rows
                    ROW.Cells(GCARAMT.Index).Value = 0
                    HRS = 0
                    KMS = 0
                    If Val(TXTHRKMRATE.Text.Trim) > 0 Then
                        HRS = Val(ROW.Cells(GHRS.Index).Value) - Val(TXTHRS.Text.Trim)
                        If HRS < 0 Then HRS = 0

                        KMS = Val(ROW.Cells(GKMS.Index).Value) - Val(TXTKMS.Text.Trim)
                        If KMS < 0 Then KMS = 0

                        ROW.Cells(GCARAMT.Index).Value = Format(Val(Val(ROW.Cells(GALLOWANCE.Index).Value) + Val(TXTHRKMRATE.Text.Trim) + (Val(HRS) * Val(TXTHRSRATE.Text.Trim)) + (Val(KMS) * Val(TXTKMSRATE.Text.Trim))), "0.00")
                    End If

                    If CMBTYPE.Text <> "OUTSTATION" Then
                        If Val(TXTHRKMRATE.Text.Trim) = 0 And Val(TXTHRSRATE.Text.Trim) > 0 Then
                            ROW.Cells(GCARAMT.Index).Value = Format(Val(ROW.Cells(GALLOWANCE.Index).Value) + Val(ROW.Cells(GCARAMT.Index).Value) + Val(Val(ROW.Cells(GHRS.Index).Value) * Val(TXTHRSRATE.Text.Trim)), "0.00")
                        End If
                    End If
                    If Val(TXTHRKMRATE.Text.Trim) = 0 And Val(TXTKMSRATE.Text.Trim) > 0 Then
                        If CMBTYPE.Text = "OUTSTATION" And Val(ROW.Cells(GKMS.Index).Value) < (Val(TXTKMS.Text) * (Val(ROW.Cells(GCARDAYS.Index).Value))) Then
                            ROW.Cells(GCARAMT.Index).Value = Format(Val(ROW.Cells(GALLOWANCE.Index).Value) + Val(ROW.Cells(GCARAMT.Index).Value) + Val((Val(TXTKMS.Text) * (Val(ROW.Cells(GCARDAYS.Index).Value) + 1)) * Val(TXTKMSRATE.Text.Trim)), "0.00")
                        Else
                            ROW.Cells(GCARAMT.Index).Value = Format(Val(ROW.Cells(GALLOWANCE.Index).Value) + Val(ROW.Cells(GCARAMT.Index).Value) + Val(Val(ROW.Cells(GKMS.Index).Value) * Val(TXTKMSRATE.Text.Trim)), "0.00")
                        End If
                    End If
                Next

                total()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CALCPUR()
        Try
            Dim KMS As Double = 0
            Dim HRS As Double = 0

            If CHKRATEPUR.CheckState = CheckState.Checked Then
                TXTPURAMT.Text = 0
                If Val(TXTHRKMRATEPUR.Text.Trim) > 0 Then
                    HRS = Val(TXTAPPHRS.Text.Trim) - Val(TXTHRSPUR.Text.Trim)
                    If HRS < 0 Then HRS = 0

                    KMS = Val(TXTAPPKMS.Text.Trim) - Val(TXTKMSPUR.Text.Trim)
                    If KMS < 0 Then KMS = 0

                    TXTPURAMT.Text = Format(Val(Val(TXTALLOWANCEPUR.Text.Trim) + Val(TXTHRKMRATEPUR.Text.Trim) + (Val(HRS) * Val(TXTHRSRATEPUR.Text.Trim)) + (Val(KMS) * Val(TXTKMSRATEPUR.Text.Trim))), "0.00")
                End If

                If Val(TXTHRKMRATEPUR.Text.Trim) = 0 And Val(TXTHRSRATEPUR.Text.Trim) > 0 Then
                    TXTPURAMT.Text = Format(Val(TXTALLOWANCEPUR.Text.Trim) + Val(TXTPURAMT.Text.Trim) + Val(Val(TXTAPPHRS.Text.Trim) * Val(TXTHRSRATEPUR.Text.Trim)), "0.00")
                End If
                If Val(TXTHRKMRATEPUR.Text.Trim) = 0 And Val(TXTKMSRATEPUR.Text.Trim) > 0 Then
                    TXTPURAMT.Text = Format(Val(TXTALLOWANCEPUR.Text.Trim) + Val(TXTPURAMT.Text.Trim) + Val(Val(TXTAPPKMS.Text.Trim) * Val(TXTKMSRATEPUR.Text.Trim)), "0.00")
                End If

                If GRIDTRANS.RowCount > 0 Then
                    For Each ROW As DataGridViewRow In GRIDPURCHASE.Rows
                        ROW.Cells(GPURAMT.Index).Value = 0
                        HRS = 0
                        KMS = 0
                        If Val(TXTHRKMRATEPUR.Text.Trim) > 0 Then
                            HRS = Val(TXTPURTOTALTIME.Text.Trim) - Val(TXTHRSPUR.Text.Trim)
                            If HRS < 0 Then HRS = 0

                            KMS = Val(TXTPURTOTALKMS.Text.Trim) - Val(TXTKMSPUR.Text.Trim)
                            If KMS < 0 Then KMS = 0

                            ROW.Cells(GPURAMT.Index).Value = Format(Val(Val(TXTALLOWANCEPUR.Text.Trim) + Val(TXTHRKMRATEPUR.Text.Trim) + (Val(HRS) * Val(TXTHRSRATEPUR.Text.Trim)) + (Val(KMS) * Val(TXTKMSRATEPUR.Text.Trim))), "0.00")
                        End If

                        If Val(TXTHRKMRATEPUR.Text.Trim) = 0 And Val(TXTHRSRATEPUR.Text.Trim) > 0 Then
                            ROW.Cells(GPURAMT.Index).Value = Format(Val(TXTALLOWANCEPUR.Text.Trim) + Val(ROW.Cells(GPURAMT.Index).Value) + Val(Val(TXTPURTOTALKMS.Text.Trim) * Val(TXTHRSRATEPUR.Text.Trim)), "0.00")
                        End If
                        If Val(TXTHRKMRATEPUR.Text.Trim) = 0 And Val(TXTKMSRATEPUR.Text.Trim) > 0 Then
                            ROW.Cells(GPURAMT.Index).Value = Format(Val(TXTALLOWANCEPUR.Text.Trim) + Val(ROW.Cells(GPURAMT.Index).Value) + Val(Val(TXTPURTOTALKMS.Text.Trim) * Val(TXTKMSRATEPUR.Text.Trim)), "0.00")
                        End If
                        ROW.Cells(GNETTTOTAL.Index).Value = Val(ROW.Cells(GPURAMT.Index).Value) - Val(ROW.Cells(GDISC.Index).Value) - Val(ROW.Cells(GCOMM.Index).Value)
                        ROW.Cells(GGRANDTOTAL.Index).Value = Format(Val(ROW.Cells(GNETTTOTAL.Index).Value) + Val(ROW.Cells(GTAXAMT.Index).Value) + Val(ROW.Cells(GOTHERCHGS.Index).Value), "0.00")
                        TXTPURAMT.Text = ROW.Cells(GPURAMT.Index).Value
                        TXTPURGTOTAL.Text = ROW.Cells(GGRANDTOTAL.Index).Value
                    Next
                End If
                total()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTNUM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTKMS.KeyPress, TXTAPPKMS.KeyPress, TXTEXTRAKMS.KeyPress, TXTCARADULTS.KeyPress, TXTCARCHILDS.KeyPress, TXTSTART.KeyPress, TXTEND.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTHRKMRATE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTHRKMRATE.Validated, TXTHRS.Validated, TXTHRSRATE.Validated, TXTKMS.Validated, TXTKMSRATE.Validated, TXTAPPHRS.Validated, TXTAPPKMS.Validated
        CALC()
        CALCKMSTIME()
        CALCPUR()
        total()
    End Sub

    Private Sub TXTHRKMRATEPUR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTHRKMRATEPUR.Validated, TXTHRSPUR.Validated, TXTHRSRATEPUR.Validated, TXTKMSPUR.Validated, TXTKMSRATEPUR.Validated
        CALC()
        CALCKMSTIME()
        CALCPUR()
        total()
    End Sub

    Private Sub TXTEXTRAKMS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTEXTRAKMS.Validating
        Try
            If Val(TXTSTART.Text.Trim) < Val(TXTEND.Text.Trim) And Val(TXTSTART.Text.Trim) > 0 And Val(TXTEND.Text.Trim) > 0 And Val(TXTRUNKMS.Text.Trim) > 0 Then
                FILLGRIDDTLS()
                DETAILTOTAL()
            Else
                If Val(TXTSTART.Text.Trim) > Val(TXTEND.Text.Trim) Then
                    MsgBox("Enter Proper Kms", MsgBoxStyle.Critical, "TRAVELMATE")
                Else
                    MsgBox("Enter Proper Details", MsgBoxStyle.Critical, "TRAVELMATE")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDTRANS_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDTRANS.RowEnter
        Try
            If e.RowIndex >= 0 Then GETDESCDATA(e.RowIndex)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDDETAILS_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDDETAILS.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDDETAILS.Item(GSRNO.Index, e.RowIndex).Value <> Nothing Then
                gridDoubleClick = True
                temprow = e.RowIndex
                TXTSRNO.Text = GRIDDETAILS.Item(GSRNO.Index, e.RowIndex).Value
                CARPICKDATE.Value = Convert.ToDateTime(GRIDDETAILS.Item(GDATE.Index, e.RowIndex).Value).Date
                CARDROPDATE.Value = Convert.ToDateTime(GRIDDETAILS.Item(GDROPDATE.Index, e.RowIndex).Value).Date
                TXTSTART.Text = GRIDDETAILS.Item(GSTART.Index, e.RowIndex).Value
                TXTEND.Text = GRIDDETAILS.Item(GEND.Index, e.RowIndex).Value
                PICKTIME.Text = GRIDDETAILS.Item(GINTIME.Index, e.RowIndex).Value
                DROPTIME.Text = GRIDDETAILS.Item(GOUTTIME.Index, e.RowIndex).Value
                TXTRUNHRS.Text = GRIDDETAILS.Item(GTOTALHRS.Index, e.RowIndex).Value
                TXTRUNKMS.Text = GRIDDETAILS.Item(GTOTALKMS.Index, e.RowIndex).Value
                TXTEXTRAHRS.Text = GRIDDETAILS.Item(GEXTRAHRS.Index, e.RowIndex).Value
                TXTEXTRAKMS.Text = GRIDDETAILS.Item(GEXTRAKMS.Index, e.RowIndex).Value
                TXTSRNO.Focus()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDDETAILS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDDETAILS.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then

                'if LINE IS IN EDIT MODE (GRIDDESCDOUBLECLICK = TRUE) THEN DONT ALLOW TO DELETE
                If gridDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                'REMOVING ROWS FROM GRIDDESC
1:
                For Each ROW As DataGridViewRow In GRIDCARDTLS.Rows
                    If ROW.Cells(GDTLSMAINSRNO.Index).Value = GRIDDETAILS.Rows(GRIDDETAILS.CurrentRow.Index).Cells(GMAINSRNO.Index).Value Then
                        GRIDCARDTLS.Rows.RemoveAt(ROW.Index)
                        GoTo 1
                    End If
                Next

                GRIDDETAILS.Rows.RemoveAt(GRIDDETAILS.CurrentRow.Index)
                DETAILTOTAL()
                getsrno(GRIDDETAILS)
                TXTSRNO.Focus()

                'AGAIN INSERT THE COMPLETE GRIDPAYDESC IN GRIDDESC
                For Each ROW As DataGridViewRow In GRIDDETAILS.Rows
                    GRIDCARDTLS.Rows.Add(ROW.Cells(GSRNO.Index).Value, ROW.Cells(GDATE.Index).Value, ROW.Cells(GDROPDATE.Index).Value, ROW.Cells(GSTART.Index).Value, ROW.Cells(GEND.Index).Value, ROW.Cells(GINTIME.Index).Value, ROW.Cells(GOUTTIME.Index).Value, ROW.Cells(GTOTALHRS.Index).Value, ROW.Cells(GTOTALKMS.Index).Value, ROW.Cells(GEXTRAHRS.Index).Value, ROW.Cells(GEXTRAKMS.Index).Value, ROW.Cells(GMAINSRNO.Index).Value)
                Next

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub DETAILTOTAL()
        Try
            TXTTOTALEXTRAHRS.Clear()
            TXTTOTALEXTRAKMS.Clear()
            TXTTOTALRUNHRS.Clear()
            TXTTOTALRUNKMS.Clear()

            For Each ROW As DataGridViewRow In GRIDDETAILS.Rows
                TXTTOTALEXTRAHRS.Text = Val(TXTTOTALEXTRAHRS.Text.Trim) + Val(ROW.Cells(GEXTRAHRS.Index).Value)
                TXTTOTALEXTRAKMS.Text = Val(TXTTOTALEXTRAKMS.Text.Trim) + Val(ROW.Cells(GEXTRAKMS.Index).Value)
                TXTTOTALRUNHRS.Text = Val(TXTTOTALRUNHRS.Text.Trim) + Val(ROW.Cells(GTOTALHRS.Index).Value)
                TXTTOTALRUNKMS.Text = Val(TXTTOTALRUNKMS.Text.Trim) + Val(ROW.Cells(GTOTALKMS.Index).Value)
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTEND_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTEND.Validated
        Try
            If Val(TXTSTART.Text.Trim) > Val(TXTEND.Text.Trim) Then
                TXTSTART.ForeColor = Color.Red
                TXTEND.ForeColor = Color.Red
            Else
                TXTSTART.ForeColor = Color.Black
                TXTEND.ForeColor = Color.Black
            End If

            'DO THIS CALC ONLY IF THE START-END IS GREATER THEN KMS MENTIONED IN CONFIG
            'IF OUTSTATION THEN MULTIPLY THE KMS * DAYS AND CHECK WHETHER IT IS GRETER OR NOT
            If CMBTYPE.Text = "OUTSTATION" Then
                If Val(TXTEND.Text.Trim) - Val(TXTSTART.Text.Trim) > (Val(TXTKMS.Text.Trim) * (Val(DateDiff(DateInterval.Day, PACKAGEFROM.Value.Date, PACKAGETO.Value.Date)) + 1)) Then
                    If GRIDTRANS.RowCount > 0 Then GRIDTRANS.Rows(0).Cells(GKMS.Index).Value = Val(TXTEND.Text.Trim) - Val(TXTSTART.Text.Trim)
                Else
                    If GRIDTRANS.RowCount > 0 Then GRIDTRANS.Rows(0).Cells(GKMS.Index).Value = (Val(TXTKMS.Text.Trim) * (Val(DateDiff(DateInterval.Day, PACKAGEFROM.Value.Date, PACKAGETO.Value.Date)) + 1))
                End If
            End If


            CALC()
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTSTART_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTSTART.Validated
        Try
            If Val(TXTSTART.Text.Trim) > Val(TXTEND.Text.Trim) Then
                TXTSTART.ForeColor = Color.Red
                TXTEND.ForeColor = Color.Red
            Else
                TXTSTART.ForeColor = Color.Black
                TXTEND.ForeColor = Color.Black
            End If
            If GRIDTRANS.RowCount > 0 Then GRIDTRANS.Rows(0).Cells(GKMS.Index).Value = Val(TXTEND.Text.Trim) - Val(TXTSTART.Text.Trim)
            CALC()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PICKTIME_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles PICKTIME.Validated
        Try
            'Dim A As TimeSpan = DROPTIME.Value - PICKTIME.Value
            'TXTRUNHRS.Text = A.ToString
            'If gridDoubleClick = False Then
            '    If (Val(TXTRUNHRS.Text.Trim) + Val(TXTTOTALRUNHRS.Text.Trim)) - Val(TXTHRS.Text.Trim) > 0 Then
            '        TXTEXTRAHRS.Text = (Val(TXTRUNHRS.Text.Trim) + Val(TXTTOTALRUNHRS.Text.Trim)) - Val(TXTHRS.Text.Trim)
            '    Else
            '        TXTEXTRAHRS.Text = 0
            '    End If
            'End If
            ' TXTRUNHRS.Text = DateDiff(DateInterval.Hour, PICKTIME.Value, DROPTIME.Value)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DROPTIME_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles DROPTIME.Validated
        Try
            'Dim A As TimeSpan = DROPTIME.Value - PICKTIME.Value
            'TXTRUNHRS.Text = A.ToString
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGUESTNAME_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBGUESTNAME.Validated
        Try
            If CMBGUESTNAME.Text.Trim <> "" And edit = False Then

                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" GUEST_MOBILENO AS MOBILENO, ISNULL(GUEST_EMAIL,''), ISNULL(PREFIX_NAME, '') AS PREFIX ", "", " GUESTMASTER LEFT OUTER JOIN PREFIXMASTER ON GUEST_PREFIXID = PREFIX_ID ", " AND GUEST_NAME ='" & CMBGUESTNAME.Text.Trim & "' AND GUEST_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    txtmobileno.Text = DT.Rows(0).Item("MOBILENO")
                    CMBPREFIX.Text = DT.Rows(0).Item("PREFIX")
                End If
                If MsgBox("Pickup from Guest Add?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    If ClientName = "SCC" Then
                        'GET FROM GUESTCONFIG
                        DT = OBJCMN.search("ISNULL(GUESTLEDGERCONFIG.CONFIG_ADDRESS, '') AS ADDRESS, ISNULL(GUESTLEDGERCONFIG.CONFIG_MOBILENO, '') AS MOBILENO ", "", " GUESTLEDGERCONFIG INNER JOIN GUESTMASTER ON GUESTLEDGERCONFIG.CONFIG_GUESTID = GUESTMASTER.GUEST_ID INNER JOIN LEDGERS ON GUESTLEDGERCONFIG.CONFIG_LEDGERID = LEDGERS.Acc_id ", " AND CONFIG_YEARID = " & YearId & " AND LEDGERS.ACC_CMPNAME = '" & CMBNAME.Text.Trim.Trim & "' AND GUESTMASTER.GUEST_NAME = '" & CMBGUESTNAME.Text.Trim & "'")
                        If DT.Rows.Count > 0 Then
                            TXTPICKFROM.Text = DT.Rows(0).Item("ADDRESS")
                            txtmobileno.Text = DT.Rows(0).Item("MOBILENO")
                        End If
                    End If
                Else
                    TXTPICKFROM.Text = TXTADD.Text.Trim
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGUESTNAME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGUESTNAME.Validating
        Try
            If CMBGUESTNAME.Text <> "" Then GUESTNAMEVALIDATE(CMBGUESTNAME, e, Me, TXTADD)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGUESTNAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBGUESTNAME.Enter
        Try
            If CMBGUESTNAME.Text = "" Then
                If ClientName = "SCC" Then FILLGUESTCONFIG() Else FILLGUESTNAME(CMBGUESTNAME, edit)
            End If
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

    Private Sub CNNOTE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CNNOTE.Click
        Try

            If PBPAID.Visible = True Or PBRECD.Visible = True Then
                MsgBox("Rec / Pay made, Delete Rec/Pay First", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If (PBCN.Visible = True) Then
                MsgBox("Booking Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If edit = True Then
                Dim TEMPMSG As Integer = MsgBox("Wish to create Credit Note?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim OBJCN As New CREDITNOTE
                    OBJCN.MdiParent = MDIMain
                    OBJCN.BILLNO = "VS-" & txtbookingno.Text.Trim
                    OBJCN.Show()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DNNOTE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DNNOTE.Click
        Try
            If PBPAID.Visible = True Or PBRECD.Visible = True Then
                MsgBox("Rec/Pay made, Delete Rec/Pay First", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If edit = True Then
                If GRIDPURCHASE.SelectedRows.Count <= 0 Then
                    MsgBox("Select Party To Create Debit Note", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                'CHECK IN DN WHETHER DN IS RAISED OR NOT
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" DN_INITIALS AS BILLINITIALS", "", " DEBITNOTEMASTER ", " AND DN_BILLNO = 'VP-" & TEMPBOOKINGNO & "' AND DN_PACKAGESRNO = " & GRIDPURCHASE.CurrentRow.Index + 1 & " AND DN_CMPID = " & CmpId & " AND DN_LOCATIONID = " & Locationid & " AND DN_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    MsgBox("Debit Note Already Raised", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                Dim TEMPMSG As Integer = MsgBox("Wish to create Debit Note for " & GRIDPURCHASE.Rows(GRIDPURCHASE.CurrentRow.Index).Cells(GPURNAME.Index).Value, MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim OBJdN As New DebitNote
                    OBJdN.MdiParent = MDIMain
                    OBJdN.BILLNO = "VP-" & txtbookingno.Text.Trim
                    OBJdN.PACKAGESRNO = GRIDPURCHASE.CurrentRow.Index + 1
                    OBJdN.Show()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBOTHERCHGS_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBOTHERCHGS.Enter
        Try
            If ClientName = "CLASSIC" Then
                If CMBOTHERCHGS.Text.Trim = "" Then fillname(CMBOTHERCHGS, edit, " AND GROUP_SECONDARY = 'INDIRECT EXPENSES' AND (ACC_CMPNAME = 'Discount' OR ACC_CMPNAME = 'Round Off')")
            Else
                If CMBOTHERCHGS.Text.Trim = "" Then fillname(CMBOTHERCHGS, edit, " AND (GROUP_SECONDARY = 'INDIRECT EXPENSES' OR GROUP_SECONDARY = 'INDIRECT INCOME' OR GROUP_SECONDARY = 'DIRECT EXPENSES' OR GROUP_SECONDARY = 'DIRECT INCOME')")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBOTHERCHGS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBOTHERCHGS.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub CMBOTHERCHGS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBOTHERCHGS.Validating
        Try
            'If CMBOTHERCHGS.Text.Trim <> "" Then namevalidate(CMBOTHERCHGS, CMBOTHERCHGSCODE, e, Me, TXTOTHERCHGSADD, " AND GROUPMASTER.GROUP_SECONDARY = 'INDIRECT EXPENSES'", "INDIRECT EXPENSES")
            If ClientName = "CLASSIC" Then
                If CMBOTHERCHGS.Text.Trim <> "" Then namevalidate(CMBOTHERCHGS, CMBOTHERCHGSCODE, e, Me, TXTOTHERCHGSADD, " AND GROUPMASTER.GROUP_SECONDARY = 'INDIRECT EXPENSES'", "INDIRECT EXPENSES")
            Else
                If CMBOTHERCHGS.Text.Trim <> "" Then namevalidate(CMBOTHERCHGS, CMBOTHERCHGSCODE, e, Me, TXTOTHERCHGSADD, " AND (GROUP_SECONDARY = 'INDIRECT EXPENSES' OR GROUP_SECONDARY = 'INDIRECT INCOME' OR GROUP_SECONDARY = 'DIRECT EXPENSES' OR GROUP_SECONDARY = 'DIRECT INCOME')", "")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPUROTHERCHGS_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPUROTHERCHGS.Enter
        Try
            If ClientName = "CLASSIC" Then
                If CMBPUROTHERCHGS.Text.Trim = "" Then fillname(CMBPUROTHERCHGS, edit, " AND (ACC_CMPNAME = 'Discount' OR ACC_CMPNAME = 'Round Off')")
            Else
                If CMBPUROTHERCHGS.Text.Trim = "" Then fillname(CMBPUROTHERCHGS, edit, " AND (GROUP_SECONDARY = 'INDIRECT EXPENSES' OR GROUP_SECONDARY = 'INDIRECT INCOME' OR GROUP_SECONDARY = 'DIRECT EXPENSES' OR GROUP_SECONDARY = 'DIRECT INCOME')")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPUROTHERCHGS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBPUROTHERCHGS.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub CMBPUROTHERCHGS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPUROTHERCHGS.Validating
        Try
            If ClientName = "CLASSIC" Then
                If CMBOTHERCHGS.Text.Trim <> "" Then namevalidate(CMBPUROTHERCHGS, CMBOTHERCHGSCODE, e, Me, TXTOTHERCHGSADD, " AND GROUPMASTER.GROUP_SECONDARY = 'INDIRECT INCOME'", "INDIRECT INCOME")
            Else
                If CMBPUROTHERCHGS.Text.Trim <> "" Then namevalidate(CMBPUROTHERCHGS, CMBOTHERCHGSCODE, e, Me, TXTOTHERCHGSADD, " AND (GROUP_SECONDARY = 'INDIRECT EXPENSES' OR GROUP_SECONDARY = 'INDIRECT INCOME' OR GROUP_SECONDARY = 'DIRECT EXPENSES' OR GROUP_SECONDARY = 'DIRECT INCOME')", "")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTALLOWANCE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTALLOWANCE.Validated
        CALC()
    End Sub

    Private Sub TXTALLOWANCEPUR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTALLOWANCEPUR.Validated
        CALCPUR()
    End Sub

    Private Sub cmbtax_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtax.Validated
        Try
            If cmbtax.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" TAX_TAX AS TAX ", "", " TAXMASTER ", " AND TAX_NAME = '" & cmbtax.Text.Trim & "' AND TAX_CMPID = " & CmpId & " AND TAX_LOCATIONID = " & Locationid & " AND TAX_YEARID  =  " & YearId)
                If DT.Rows.Count > 0 Then
                    If Val(DT.Rows(0).Item("TAX")) = 0 Then
                        txttax.ReadOnly = False
                        txttax.Enabled = True
                    End If
                End If
            Else
                txttax.Clear()
            End If
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtbookingno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtbookingno.Validating
        Try
            If ClientName = "UNIGO" Or ClientName = "TRAVELBRIDGE" Then
                If Val(txtbookingno.Text.Trim) >= 0 And edit = False Then
                    Dim OBJSEARCH As New ClsCommon
                    Dim DT As DataTable = OBJSEARCH.search(" T.BOOKINGNO AS BOOKINGNO ", "", " (SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM AIRLINEBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM HOTELBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM HOLIDAYPACKAGEMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM CARBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM INTERNATIONALBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM MISCSALMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM RAILBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM VISABOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " ) AS T ", " AND T.BOOKINGNO = " & Val(txtbookingno.Text.Trim))
                    If DT.Rows.Count > 0 Then
                        MsgBox("Booking No Allready Used")
                        e.Cancel = True
                        txtbookingno.Focus()
                    End If

                    If Val(txtbookingno.Text.Trim) = 0 Then
                        MsgBox("Booking No Cannot Be 0!")
                        e.Cancel = True
                    End If
                End If

            ElseIf (ClientName = "CLASSIC" And UserName = "Admin") Or ClientName = "GLOBE" Or ClientName = "MILONI" Or ClientName = "NAMASTE" Then
                If Val(txtbookingno.Text.Trim) >= 0 And edit = False Then
                    Dim OBJSEARCH As New ClsCommon
                    Dim DT As DataTable = OBJSEARCH.search(" BOOKING_NO AS BOOKINGNO ", "", " CARBOOKINGMASTER", " AND CARBOOKINGMASTER.BOOKING_NO = '" & txtbookingno.Text.Trim & "' and CARBOOKINGMASTER.BOOKING_yearid=" & YearId)
                    If DT.Rows.Count > 0 Then
                        MsgBox("Booking No Allready Used")
                        e.Cancel = True
                        txtbookingno.Focus()
                    End If

                    If Val(txtbookingno.Text.Trim) = 0 Then
                        MsgBox("Booking No Cannot Be 0!")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Private Sub txttax_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttax.TextChanged
    '    total()
    'End Sub

    Private Sub TXTEXTRACHGS_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTEXTRACHGS.Validating
        total()
    End Sub

    Private Sub GRIDTOUR_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDTOUR.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDTOUR.Item(GTOURSRNO.Index, e.RowIndex).Value <> Nothing Then

                GRIDTOURDOUBLECLICK = True
                TXTTOURSRNO.Text = GRIDTOUR.Item(GTOURSRNO.Index, e.RowIndex).Value.ToString
                TOURDATE.Value = Convert.ToDateTime(GRIDTOUR.Item(GTOURDATE.Index, e.RowIndex).Value).Date
                TXTTOURDETAILS.Text = GRIDTOUR.Item(GTOURDETAILS.Index, e.RowIndex).Value.ToString

                tempTOURrow = e.RowIndex
                TXTTOURSRNO.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDTOUR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDTOUR.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDTOUR.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDTOURDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDTOUR.Rows.RemoveAt(GRIDTOUR.CurrentRow.Index)
                total()
                getsrno(GRIDTOUR)

            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTTOURDETAILS_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTTOURDETAILS.Validating
        Try
            If TXTTOURDETAILS.Text.Trim <> "" Then
                fillgridTOUR()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical, "TRAVELMATE")
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTOUR_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTOUR.Validating
        Try
            If CMBTOUR.Text.Trim <> "" Then TOURVALIDATE(CMBTOUR, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTOUR_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBTOUR.Enter
        Try
            If CMBTOUR.Text.Trim = "" Then FILLTOURNAME(CMBTOUR, edit, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKREVERSE_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHKREVERSE.CheckedChanged
        total()
    End Sub

    Private Sub TOOLSMS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLSMS.Click
        If edit = False Then Exit Sub
        SMSCODE()
    End Sub

    Sub SMSCODE()
        If txtmobileno.Text.Trim.Length = 0 Then
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" ACC_MOBILE", "", " LEDGERS", " AND ACC_CMPNAME ='" & CMBNAME.Text.Trim & "' AND ACC_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then txtmobileno.Text = DT.Rows(0).Item(0)
        End If
        If ALLOWSMS = True And txtmobileno.Text.Trim <> "" Then
            If GRIDTRANS.Rows(0).Cells(GDRIVER.Index).Value <> "" And GRIDTRANS.Rows(0).Cells(GVEHICLENO.Index).Value <> "" Then
                If SENDMSG("Dear " & CMBPREFIX.Text.Trim & " " & CMBGUESTNAME.Text.Trim & ", Your booking is Confirmed. Booking No VS-" & Val(TEMPBOOKINGNO) & ", Vehicle : " & GRIDTRANS.Rows(0).Cells(GCARNAME.Index).Value & ", No: " & GRIDTRANS.Rows(0).Cells(GVEHICLENO.Index).Value & ", Driver : " & GRIDTRANS.Rows(0).Cells(GDRIVER.Index).Value & ", Pickup " & Format(PACKAGEFROM.Value.Date, "dd/MM/yyyy") & ", " & GRIDTRANS.Rows(0).Cells(GCARPICKUPTIME.Index).Value & ", From " & GRIDTRANS.Rows(0).Cells(GCARPICKUPFROM.Index).Value & ", Drop " & Format(PACKAGETO.Value.Date, "dd/MM/yyyy") & ", " & GRIDTRANS.Rows(0).Cells(GCARDROPTIME.Index).Value & ", At " & GRIDTRANS.Rows(0).Cells(GCARDROPTO.Index).Value & ", Total Pax " & Val(TXTCARTOTALPAX.Text.Trim), txtmobileno.Text.Trim) = "1701" Then MsgBox("Message Sent") Else MsgBox("Error Sending Message")
            Else
                If SENDMSG("Dear " & CMBPREFIX.Text.Trim & " " & CMBGUESTNAME.Text.Trim & ", Your booking is Confirmed. Booking No VS-" & Val(TEMPBOOKINGNO) & ", Vehicle : " & GRIDTRANS.Rows(0).Cells(GCARNAME.Index).Value & ", Pickup " & Format(PACKAGEFROM.Value.Date, "dd/MM/yyyy") & ", " & GRIDTRANS.Rows(0).Cells(GCARPICKUPTIME.Index).Value & ", From " & GRIDTRANS.Rows(0).Cells(GCARPICKUPFROM.Index).Value & ", Drop " & Format(PACKAGETO.Value.Date, "dd/MM/yyyy") & ", " & GRIDTRANS.Rows(0).Cells(GCARDROPTIME.Index).Value & ", At " & GRIDTRANS.Rows(0).Cells(GCARDROPTO.Index).Value & ", Total Pax " & Val(TXTCARTOTALPAX.Text.Trim), txtmobileno.Text.Trim) = "1701" Then MsgBox("Message Sent") Else MsgBox("Error Sending Message")
            End If
        End If
    End Sub

    Private Sub txtrefno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrefno.KeyPress
        If ClientName = "ARUN" Or ClientName = "SCC" Or ClientName = "TRAVCON" Then numdotkeypress(e, sender, Me)
    End Sub

    Sub FILLVEHICLENO()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" VEHICLENOMASTER.VEHICLENO_NO AS VEHICLENO", "", " VEHICLEMASTER INNER JOIN VEHICLENOMASTER ON VEHICLEMASTER.VEHICLE_ID = VEHICLENOMASTER.VEHICLENO_VEHICLEID ", " AND VEHICLE_NAME = '" & CMBCARNAME.Text.Trim & "' AND VEHICLENO_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                CMBVEHICLENO.Items.Clear()
                For Each DTROW As DataRow In DT.Rows
                    CMBVEHICLENO.Items.Add(DTROW("VEHICLENO"))
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCARNAME_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBCARNAME.Validated
        Try
            If CMBCARNAME.Text.Trim <> "" Then
                FILLVEHICLENO()
                GETRATE()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETRATE()
        Try
            'If CHKRATE.CheckState = CheckState.Checked Then Exit Sub
            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable
            If edit = False Then
                'DT = OBJCMN.search(" ISNULL(VEHICLERATE.VEHICLERATE_RATE,0) AS RATE, ISNULL(VEHICLERATE.VEHICLERATE_HRRATE,0) AS HRRATE, ISNULL(VEHICLERATE.VEHICLERATE_KMRATE,0) AS KMRATE,ISNULL(VEHICLERATE.VEHICLERATE_ALLOWANCE,0) AS ALLOWANCE,ISNULL(VEHICLERATE.VEHICLERATE_NIGHTALLOWANCE,0) AS NIGHTALLOWANCE, ISNULL(VEHICLERATE.VEHICLERATE_KMS,0) AS KMS, ISNULL(LEDGERS.ACC_CMPNAME,'') AS NAME ", "", " VEHICLEMASTER INNER JOIN VEHICLERATE ON VEHICLEMASTER.VEHICLE_ID = VEHICLERATE.VEHICLERATE_VEHICLEID LEFT OUTER JOIN LEDGERS ON VEHICLERATE.VEHICLERATE_LEDGERID = LEDGERS.Acc_id ", " AND ISNULL(LEDGERS.ACC_CMPNAME,'')= '" & CMBNAME.Text.Trim & "' AND VEHICLE_NAME = '" & CMBCARNAME.Text.Trim & "' AND VEHICLERATE_TYPE = '" & CMBTYPE.Text.Trim & "' AND VEHICLERATE_YEARID = " & YearId)
                DT = OBJCMN.search(" ISNULL(VEHICLERATE.VEHICLERATE_RATE, 0) AS RATE, ISNULL(VEHICLERATE.VEHICLERATE_HRRATE, 0) AS HRRATE, ISNULL(VEHICLERATE.VEHICLERATE_KMRATE, 0) AS KMRATE, ISNULL(VEHICLERATE.VEHICLERATE_ALLOWANCE, 0) AS ALLOWANCE, ISNULL(VEHICLERATE.VEHICLERATE_NIGHTALLOWANCE, 0) AS NIGHTALLOWANCE, ISNULL(VEHICLERATE.VEHICLERATE_KMS, 0) AS KMS, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(CITYMASTER.city_name, '') AS CITY", "", " VEHICLEMASTER INNER JOIN VEHICLERATE ON VEHICLEMASTER.VEHICLE_ID = VEHICLERATE.VEHICLERATE_VEHICLEID LEFT OUTER JOIN CITYMASTER ON VEHICLERATE.VEHICLERATE_CITYID = CITYMASTER.city_id LEFT OUTER JOIN LEDGERS ON VEHICLERATE.VEHICLERATE_LEDGERID = LEDGERS.Acc_id ", " AND ISNULL(LEDGERS.ACC_CMPNAME,'')= '" & CMBNAME.Text.Trim & "' AND VEHICLE_NAME = '" & CMBCARNAME.Text.Trim & "' AND VEHICLERATE_TYPE = '" & CMBTYPE.Text.Trim & "' AND ISNULL(CITYMASTER.CITY_NAME,'') = '" & cmbcity.Text.Trim & "' AND VEHICLERATE_YEARID = " & YearId)

            Else
                'DT = OBJCMN.search(" ISNULL(VEHICLERATE.VEHICLERATE_RATE,0) AS RATE, ISNULL(VEHICLERATE.VEHICLERATE_HRRATE,0) AS HRRATE, ISNULL(VEHICLERATE.VEHICLERATE_KMRATE,0) AS KMRATE,ISNULL(VEHICLERATE.VEHICLERATE_ALLOWANCE,0) AS ALLOWANCE,ISNULL(VEHICLERATE.VEHICLERATE_NIGHTALLOWANCE,0) AS NIGHTALLOWANCE, ISNULL(VEHICLERATE.VEHICLERATE_KMS,0) AS KMS, ISNULL(LEDGERS.ACC_CMPNAME,'') AS NAME ", "", " VEHICLEMASTER INNER JOIN VEHICLERATE ON VEHICLEMASTER.VEHICLE_ID = VEHICLERATE.VEHICLERATE_VEHICLEID LEFT OUTER JOIN LEDGERS ON VEHICLERATE.VEHICLERATE_LEDGERID = LEDGERS.Acc_id ", " AND ISNULL(LEDGERS.ACC_CMPNAME,'')= '" & CMBNAME.Text.Trim & "' AND VEHICLE_NAME = '" & GRIDTRANS.Rows(0).Cells(GCARNAME.Index).Value & "' AND VEHICLERATE_TYPE = '" & CMBTYPE.Text.Trim & "' AND VEHICLERATE_YEARID = " & YearId)
                DT = OBJCMN.search(" ISNULL(VEHICLERATE.VEHICLERATE_RATE,0) AS RATE, ISNULL(VEHICLERATE.VEHICLERATE_HRRATE,0) AS HRRATE, ISNULL(VEHICLERATE.VEHICLERATE_KMRATE,0) AS KMRATE,ISNULL(VEHICLERATE.VEHICLERATE_ALLOWANCE,0) AS ALLOWANCE,ISNULL(VEHICLERATE.VEHICLERATE_NIGHTALLOWANCE,0) AS NIGHTALLOWANCE, ISNULL(VEHICLERATE.VEHICLERATE_KMS,0) AS KMS, ISNULL(LEDGERS.ACC_CMPNAME,'') AS NAME, ISNULL(CITYMASTER.city_name, '') AS CITY ", "", " VEHICLEMASTER INNER JOIN VEHICLERATE ON VEHICLEMASTER.VEHICLE_ID = VEHICLERATE.VEHICLERATE_VEHICLEID LEFT OUTER JOIN LEDGERS ON VEHICLERATE.VEHICLERATE_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN CITYMASTER ON VEHICLERATE.VEHICLERATE_CITYID = CITYMASTER.city_id", " AND ISNULL(LEDGERS.ACC_CMPNAME,'')= '" & CMBNAME.Text.Trim & "' AND VEHICLE_NAME = '" & GRIDTRANS.Rows(0).Cells(GCARNAME.Index).Value & "' AND VEHICLERATE_TYPE = '" & CMBTYPE.Text.Trim & "' AND ISNULL(CITYMASTER.CITY_NAME,'') = '" & cmbcity.Text.Trim & "' AND VEHICLERATE_YEARID = " & YearId)

            End If
            If DT.Rows.Count > 0 Then
                CHKRATE.CheckState = CheckState.Checked
                If CMBTYPE.Text = "LOCAL" Then
                    TXTHRS.Text = 8
                    TXTKMS.Text = 80
                ElseIf CMBTYPE.Text = "4HRS 40KMS" Then
                    TXTHRS.Text = 4
                    TXTKMS.Text = 40
                ElseIf CMBTYPE.Text = "OUTSTATION" Then
                    TXTKMS.Text = Val(DT.Rows(0).Item("KMS"))
                End If
                If DateDiff(DateInterval.Day, PACKAGEFROM.Value.Date, PACKAGETO.Value.Date) > 0 Then
                    If edit = False Then TXTALLOWANCE.Text = Format(Val(DT.Rows(0).Item("ALLOWANCE")) * (DateDiff(DateInterval.Day, PACKAGEFROM.Value.Date, PACKAGETO.Value.Date) + 1), "0.00") Else GRIDTRANS.Rows(0).Cells(GALLOWANCE.Index).Value = Format(Val(DT.Rows(0).Item("ALLOWANCE")) * (DateDiff(DateInterval.Day, PACKAGEFROM.Value.Date, PACKAGETO.Value.Date) + 1), "0.00")
                    txtrefno.Text = Format(Val(DT.Rows(0).Item("NIGHTALLOWANCE")) * DateDiff(DateInterval.Day, PACKAGEFROM.Value.Date, PACKAGETO.Value.Date), "0.00")
                    TXTAPPKMS.Text = Format(Val(DT.Rows(0).Item("KMS")) * (DateDiff(DateInterval.Day, PACKAGEFROM.Value.Date, PACKAGETO.Value.Date) + 1), "0")
                Else
                    TXTAPPKMS.Text = Format(Val(DT.Rows(0).Item("KMS")), "0")
                    If edit = False Then TXTALLOWANCE.Text = Format(Val(DT.Rows(0).Item("ALLOWANCE")), "0.00") Else GRIDTRANS.Rows(0).Cells(GALLOWANCE.Index).Value = Format(Val(DT.Rows(0).Item("ALLOWANCE")), "0.00")
                    'THIS IS REMOVED COZ IT IS FOR SAME DAY
                    'txtrefno.Text = Format(Val(DT.Rows(0).Item("NIGHTALLOWANCE")), "0.00")
                End If
                TXTHRKMRATE.Text = Format(Val(DT.Rows(0).Item("RATE")), "0.00")
                TXTHRSRATE.Text = Format(Val(DT.Rows(0).Item("HRRATE")), "0.00")
                TXTKMSRATE.Text = Format(Val(DT.Rows(0).Item("KMRATE")), "0.00")

                CALC()
                total()
            End If


            'GET PURCHASE RATE
            If edit = False Then
                ' DT = OBJCMN.search(" ISNULL(VEHICLERATEPUR.VEHICLERATEPUR_RATE,0) AS RATE, ISNULL(VEHICLERATEPUR.VEHICLERATEPUR_HRRATE,0) AS HRRATE, ISNULL(VEHICLERATEPUR.VEHICLERATEPUR_KMRATE,0) AS KMRATE,ISNULL(VEHICLERATEPUR.VEHICLERATEPUR_ALLOWANCE,0) AS ALLOWANCE,ISNULL(VEHICLERATEPUR.VEHICLERATEPUR_NIGHTALLOWANCE,0) AS NIGHTALLOWANCE, ISNULL(VEHICLERATEPUR.VEHICLERATEPUR_KMS,0) AS KMS, ISNULL(LEDGERS.ACC_CMPNAME,'') AS NAME ", "", " VEHICLEMASTER INNER JOIN VEHICLERATEPUR ON VEHICLEMASTER.VEHICLE_ID = VEHICLERATEPUR.VEHICLERATEPUR_VEHICLEID LEFT OUTER JOIN LEDGERS ON VEHICLERATEPUR.VEHICLERATEPUR_LEDGERID = LEDGERS.Acc_id ", " AND ISNULL(LEDGERS.ACC_CMPNAME,'')= '" & CMBPURNAME.Text.Trim & "' AND VEHICLE_NAME = '" & CMBCARNAME.Text.Trim & "' AND VEHICLERATEPUR_TYPE = '" & CMBTYPE.Text.Trim & "' AND VEHICLERATEPUR_YEARID = " & YearId)
                DT = OBJCMN.search(" ISNULL(VEHICLERATEPUR.VEHICLERATEPUR_RATE,0) AS RATE, ISNULL(VEHICLERATEPUR.VEHICLERATEPUR_HRRATE,0) AS HRRATE, ISNULL(VEHICLERATEPUR.VEHICLERATEPUR_KMRATE,0) AS KMRATE,ISNULL(VEHICLERATEPUR.VEHICLERATEPUR_ALLOWANCE,0) AS ALLOWANCE,ISNULL(VEHICLERATEPUR.VEHICLERATEPUR_NIGHTALLOWANCE,0) AS NIGHTALLOWANCE, ISNULL(VEHICLERATEPUR.VEHICLERATEPUR_KMS,0) AS KMS, ISNULL(LEDGERS.ACC_CMPNAME,'') AS NAME , ISNULL(CITYMASTER.city_name, '') AS CITY", "", " VEHICLEMASTER INNER JOIN VEHICLERATEPUR ON VEHICLEMASTER.VEHICLE_ID = VEHICLERATEPUR.VEHICLERATEPUR_VEHICLEID LEFT OUTER JOIN LEDGERS ON VEHICLERATEPUR.VEHICLERATEPUR_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN CITYMASTER ON VEHICLERATEPUR.VEHICLERATEPUR_CITYID = CITYMASTER.city_id ", " AND ISNULL(LEDGERS.ACC_CMPNAME,'')= '" & CMBPURNAME.Text.Trim & "' AND VEHICLE_NAME = '" & CMBCARNAME.Text.Trim & "' AND VEHICLERATEPUR_TYPE = '" & CMBTYPE.Text.Trim & "' AND ISNULL(CITYMASTER.CITY_NAME,'') = '" & cmbcity.Text.Trim & "' AND VEHICLERATEPUR_YEARID = " & YearId)

            Else
                ' DT = OBJCMN.search(" ISNULL(VEHICLERATEPUR.VEHICLERATEPUR_RATE,0) AS RATE, ISNULL(VEHICLERATEPUR.VEHICLERATEPUR_HRRATE,0) AS HRRATE, ISNULL(VEHICLERATEPUR.VEHICLERATEPUR_KMRATE,0) AS KMRATE,ISNULL(VEHICLERATEPUR.VEHICLERATEPUR_ALLOWANCE,0) AS ALLOWANCE,ISNULL(VEHICLERATEPUR.VEHICLERATEPUR_NIGHTALLOWANCE,0) AS NIGHTALLOWANCE, ISNULL(VEHICLERATEPUR.VEHICLERATEPUR_KMS,0) AS KMS, ISNULL(LEDGERS.ACC_CMPNAME,'') AS NAME ", "", " VEHICLEMASTER INNER JOIN VEHICLERATEPUR ON VEHICLEMASTER.VEHICLE_ID = VEHICLERATEPUR.VEHICLERATEPUR_VEHICLEID LEFT OUTER JOIN LEDGERS ON VEHICLERATEPUR.VEHICLERATEPUR_LEDGERID = LEDGERS.Acc_id ", " AND ISNULL(LEDGERS.ACC_CMPNAME,'')= '" & CMBPURNAME.Text.Trim & "' AND VEHICLE_NAME = '" & GRIDTRANS.Rows(0).Cells(GCARNAME.Index).Value & "' AND VEHICLERATEPUR_TYPE = '" & CMBTYPE.Text.Trim & "' AND VEHICLERATEPUR_YEARID = " & YearId)
                DT = OBJCMN.search(" ISNULL(VEHICLERATEPUR.VEHICLERATEPUR_RATE,0) AS RATE, ISNULL(VEHICLERATEPUR.VEHICLERATEPUR_HRRATE,0) AS HRRATE, ISNULL(VEHICLERATEPUR.VEHICLERATEPUR_KMRATE,0) AS KMRATE,ISNULL(VEHICLERATEPUR.VEHICLERATEPUR_ALLOWANCE,0) AS ALLOWANCE,ISNULL(VEHICLERATEPUR.VEHICLERATEPUR_NIGHTALLOWANCE,0) AS NIGHTALLOWANCE, ISNULL(VEHICLERATEPUR.VEHICLERATEPUR_KMS,0) AS KMS, ISNULL(LEDGERS.ACC_CMPNAME,'') AS NAME, ISNULL(CITYMASTER.city_name, '') AS CITY  ", "", " VEHICLEMASTER INNER JOIN VEHICLERATEPUR ON VEHICLEMASTER.VEHICLE_ID = VEHICLERATEPUR.VEHICLERATEPUR_VEHICLEID LEFT OUTER JOIN LEDGERS ON VEHICLERATEPUR.VEHICLERATEPUR_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN CITYMASTER ON VEHICLERATEPUR.VEHICLERATEPUR_CITYID = CITYMASTER.city_id", " AND ISNULL(LEDGERS.ACC_CMPNAME,'')= '" & CMBPURNAME.Text.Trim & "' AND VEHICLE_NAME = '" & GRIDTRANS.Rows(0).Cells(GCARNAME.Index).Value & "' AND VEHICLERATEPUR_TYPE = '" & CMBTYPE.Text.Trim & "' AND ISNULL(CITYMASTER.CITY_NAME,'') = '" & cmbcity.Text.Trim & "' AND VEHICLERATEPUR_YEARID = " & YearId)

            End If
            If DT.Rows.Count > 0 Then
                CHKRATEPUR.CheckState = CheckState.Checked
                If CMBTYPE.Text = "LOCAL" Then
                    TXTHRSPUR.Text = 8
                    TXTKMSPUR.Text = 80
                ElseIf CMBTYPE.Text = "4HRS 40KMS" Then
                    TXTHRSPUR.Text = 4
                    TXTKMSPUR.Text = 40
                End If
                If DateDiff(DateInterval.Day, PACKAGEFROM.Value.Date, PACKAGETO.Value.Date) > 0 Then
                    If edit = False Then TXTALLOWANCEPUR.Text = Format(Val(DT.Rows(0).Item("ALLOWANCE")) * (DateDiff(DateInterval.Day, PACKAGEFROM.Value.Date, PACKAGETO.Value.Date) + 1), "0.00") Else TXTALLOWANCEPUR.Text = Format(Val(DT.Rows(0).Item("ALLOWANCE")) * (DateDiff(DateInterval.Day, PACKAGEFROM.Value.Date, PACKAGETO.Value.Date) + 1), "0.00")
                    TXTNIGHTALLOWANCEPUR.Text = Format(Val(DT.Rows(0).Item("NIGHTALLOWANCE")) * DateDiff(DateInterval.Day, PACKAGEFROM.Value.Date, PACKAGETO.Value.Date), "0.00")
                Else
                    If edit = False Then TXTALLOWANCEPUR.Text = Format(Val(DT.Rows(0).Item("ALLOWANCE")), "0.00") Else TXTALLOWANCEPUR.Text = Format(Val(DT.Rows(0).Item("ALLOWANCE")), "0.00")
                End If
                TXTHRKMRATEPUR.Text = Format(Val(DT.Rows(0).Item("RATE")), "0.00")
                TXTHRSRATEPUR.Text = Format(Val(DT.Rows(0).Item("HRRATE")), "0.00")
                TXTKMSRATEPUR.Text = Format(Val(DT.Rows(0).Item("KMRATE")), "0.00")

                CALCPUR()
                total()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTYPE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBTYPE.Validated
        Try
            GETRATE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtrefno_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtrefno.Validated
        If ClientName = "ARUN" Or ClientName = "SCC" Or ClientName = "TRAVCON" Then
            CALC()
            CALCPUR()
            total()
        End If
    End Sub

    Sub CALCKMSTIME()
        Try
            TXTPURTOTALKMS.Text = Val(TXTPUREND.Text.Trim) - Val(TXTPURSTART.Text.Trim)
            TXTPURTOTALTIME.Text = Val(TXTPURENDTIME.Text.Trim) - Val(TXTPURSTARTTIME.Text.Trim)
            TXTSALETOTALKMS.Text = Val(TXTEND.Text.Trim) - Val(TXTSTART.Text.Trim)
            TXTSALETOTALTIME.Text = Val(TXTENDTIME.Text.Trim) - Val(TXTSTARTTIME.Text.Trim)
            If CMBTYPE.Text = "LOCAL" Then
                TXTPUREXTRAKMS.Text = Val(TXTPUREND.Text.Trim) - Val(TXTPURSTART.Text.Trim) - 80
                TXTPUREXTRATIME.Text = Val(TXTPURENDTIME.Text.Trim) - Val(TXTPURSTARTTIME.Text.Trim) - 8
                TXTSALEEXTRAKMS.Text = Val(TXTEND.Text.Trim) - Val(TXTSTART.Text.Trim) - 80
                TXTSALEEXTRATIME.Text = Val(TXTENDTIME.Text.Trim) - Val(TXTSTARTTIME.Text.Trim) - 8
            ElseIf CMBTYPE.Text = "4HRS 40KMS" Then
                TXTPUREXTRAKMS.Text = Val(TXTPUREND.Text.Trim) - Val(TXTPURSTART.Text.Trim) - 40
                TXTPUREXTRATIME.Text = Val(TXTPURENDTIME.Text.Trim) - Val(TXTPURSTARTTIME.Text.Trim) - 4
                TXTSALEEXTRAKMS.Text = Val(TXTEND.Text.Trim) - Val(TXTSTART.Text.Trim) - 40
                TXTSALEEXTRATIME.Text = Val(TXTENDTIME.Text.Trim) - Val(TXTSTARTTIME.Text.Trim) - 4
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPUREND_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTPUREND.Validated, TXTPURSTART.Validated
        Try
            If Val(TXTPURSTART.Text.Trim) > Val(TXTPUREND.Text.Trim) Then
                TXTPURSTART.ForeColor = Color.Red
                TXTPUREND.ForeColor = Color.Red
            Else
                TXTPURSTART.ForeColor = Color.Black
                TXTPUREND.ForeColor = Color.Black
            End If
            CALCKMSTIME()
            CALCPUR()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPURSTARTTIME_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTPURSTARTTIME.Validated, TXTPURENDTIME.Validated, TXTEND.Validated, TXTSTART.Validated, TXTSTARTTIME.Validated, TXTENDTIME.Validated
        Try
            If Val(TXTSTART.Text.Trim) > Val(TXTEND.Text.Trim) Then
                TXTSTART.ForeColor = Color.Red
                TXTEND.ForeColor = Color.Red
            Else
                TXTSTART.ForeColor = Color.Black
                TXTEND.ForeColor = Color.Black
            End If

            'DO THIS CALC ONLY IF THE START-END IS GREATER THEN KMS MENTIONED IN CONFIG
            'IF OUTSTATION THEN MULTIPLY THE KMS * DAYS AND CHECK WHETHER IT IS GRETER OR NOT
            If Val(TXTEND.Text.Trim) - Val(TXTSTART.Text.Trim) > (Val(TXTKMS.Text.Trim) * (Val(DateDiff(DateInterval.Day, PACKAGEFROM.Value.Date, PACKAGETO.Value.Date)) + 1)) Then
                If GRIDTRANS.RowCount > 0 Then GRIDTRANS.Rows(0).Cells(GKMS.Index).Value = Val(TXTEND.Text.Trim) - Val(TXTSTART.Text.Trim)
            Else
                If GRIDTRANS.RowCount > 0 Then GRIDTRANS.Rows(0).Cells(GKMS.Index).Value = (Val(TXTKMS.Text.Trim) * (Val(DateDiff(DateInterval.Day, PACKAGEFROM.Value.Date, PACKAGETO.Value.Date)) + 1))
            End If

            CALCKMSTIME()
            CALC()
            CALCPUR()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPUREND_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTPUREND.Validating
        Try
            If Val(TXTSTART.Text) = 0 Then
                TXTSTART.Text = TXTPURSTART.Text
                TXTEND.Text = TXTPUREND.Text
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPURENDTIME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTPURENDTIME.Validating
        Try
            If Val(TXTSTARTTIME.Text) = 0 Then
                TXTSTARTTIME.Text = TXTPURSTARTTIME.Text
                TXTENDTIME.Text = TXTPURENDTIME.Text
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTENDTIME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTENDTIME.Validating
        Try
            If GRIDTRANS.RowCount > 0 And CMBTYPE.Text <> "OUTSTATION" Then GRIDTRANS.Rows(0).Cells(GHRS.Index).Value = Val(TXTENDTIME.Text.Trim) - Val(TXTSTARTTIME.Text.Trim)
            CALC()
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTGRIDTAX_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTPSF.Validated, TXTGRIDTAX.Validated, TXTBASIC.Validated
        CALC()
    End Sub

    Private Sub CMDSELECTMISCENQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTMISCENQ.Click
        Try
            If edit = True Then
                MsgBox("Not Allowed in Edit Mode", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Cursor.Current = Cursors.WaitCursor

            SELECTENQ.Clear()
            Dim OBJHOTELENQ As New SelectMiscEnquiry
            OBJHOTELENQ.FRMSTRING = "CAR RENTAL"
            OBJHOTELENQ.ShowDialog()
            SELECTENQ = OBJHOTELENQ.DT
            Dim i As Integer = 0
            If SELECTENQ.Rows.Count > 0 Then
                TXTMISCENQNO.Text = (SELECTENQ.Rows(0).Item("MISCNO"))

                'GET OTHER DETAILS AS WELL
                Dim dttable As New DataTable
                Dim OBJENQ As New ClsMiscEnquiry

                OBJENQ.alParaval.Add(SELECTENQ.Rows(0).Item("MISCNO"))
                OBJENQ.alParaval.Add(YearId)
                dttable = OBJENQ.SELECTMISCENQ()
                If dttable.Rows.Count > 0 Then
                    CMBGUESTNAME.Text = dttable.Rows(0).Item("GUESTNAME").ToString
                    CMBSOURCE.Text = dttable.Rows(0).Item("SOURCE").ToString
                    CMBBOOKEDBY.Text = dttable.Rows(0).Item("BOOKEDBY").ToString
                    'ARRIVALDATE.Value = Convert.ToDateTime(dttable.Rows(0).Item("CHECKIN")).Date
                    TXTADD.Text = dttable.Rows(0).Item("ADDRESS").ToString
                    'TXTADULTS.Text = Val(dttable.Rows(0).Item("ADULTS"))
                    'TXTCHILDS.Text = Val(dttable.Rows(0).Item("CHILD"))
                    'TXTNCCHILDS.Text = Val(dttable.Rows(0).Item("INFANTS"))
                    'TXTEXTRACHILD.Text = Val(dttable.Rows(0).Item("CHILDWITHOUTBED"))
                    'TXTEXTRAADULT.Text = Val(dttable.Rows(0).Item("EXTRAADULTS"))
                    'TXTNOOFROOMS.Text = Val(dttable.Rows(0).Item("ROOMS"))
                    cmbcity.Text = dttable.Rows(0).Item("CITY").ToString

                End If


            End If

        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub GRIDAIRLINE_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDAIRLINE.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDAIRLINE.Item(GAIRSRNO.Index, e.RowIndex).Value <> Nothing Then

                GRIDAIRDOUBLECLICK = True
                TXTAIRSRNO.Text = GRIDAIRLINE.Item(GAIRSRNO.Index, e.RowIndex).Value.ToString
                TXTSECTOR.Text = GRIDAIRLINE.Item(GSECTOR.Index, e.RowIndex).Value.ToString
                TXTFLTNO.Text = GRIDAIRLINE.Item(GFLTNO.Index, e.RowIndex).Value.ToString
                CMBAIRLINETYPE.Text = GRIDAIRLINE.Item(GTYPE.Index, e.RowIndex).Value.ToString
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

    Function getBookingSr(ByVal trimSECTORS As String) As Integer
        Dim booksrno As Integer = 0
        For Each dbrows As System.Windows.Forms.DataGridViewRow In GRIDAIRLINE.Rows
            If dbrows.Cells(GSECTOR.Index).Value.ToString.Trim = trimSECTORS Then
                booksrno = Convert.ToInt32(dbrows.Cells(GAIRSRNO.Index).Value)
            End If
        Next
        Return booksrno
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
            If TXTSECTOR.Text <> "   /   /   /   /   /" Then
                FILLAIRLINEGRID()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical, "TRAVELMATE")
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcity_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcity.Validating
        Try
            If cmbcity.Text.Trim <> "" Then
                pcase(cmbcity)
                Dim objclscommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objclscommon.search("city_name", "", "CityMaster", " and city_name = '" & cmbcity.Text.Trim & "' and city_cmpid = " & CmpId & " and city_Locationid = " & Locationid & " and city_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbcity.Text.Trim
                    Dim tempmsg As Integer = MsgBox("City not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                        If DTROW(0).Item(1) = False Then
                            MsgBox("Insufficient Rights")
                            Exit Sub
                        End If
                        cmbcity.Text = a
                        objyearmaster.savecity(cmbcity.Text.Trim, CmpId, Locationid, Userid, YearId, " and city_name = '" & cmbcity.Text.Trim & "' and city_cmpid = " & CmpId & " and city_Locationid = " & Locationid & " and city_Yearid = " & YearId)
                        Dim dt1 As New DataTable
                        dt1 = cmbcity.DataSource
                        If cmbcity.DataSource <> Nothing Then
line1:
                            If dt1.Rows.Count > 0 Then
                                dt1.Rows.Add(cmbcity.Text)
                                cmbcity.Text = a
                            End If
                        End If
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcity_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcity.Enter
        Try
            If cmbcity.Text.Trim = "" Then fillcity(cmbcity)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTSUNDAYS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTSUNDAYS.KeyPress, TXTEXTRADROP.KeyPress, TXTOUTSTATIONDAYS.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub CMDUPLOADIRN_Click(sender As Object, e As EventArgs) Handles CMDUPLOADIRN.Click
        If (edit = True And USEREDIT = False And USERVIEW = False) Or (edit = False And USERADD = False) Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        OpenFileDialog1.Filter = "Pictures (*.png)|*.png"
        OpenFileDialog1.ShowDialog()

        OpenFileDialog1.AddExtension = True
        TXTFILENAME.Text = OpenFileDialog1.SafeFileName
        txtimgpath.Text = OpenFileDialog1.FileName
        TXTNEWIMGPATH.Text = Application.StartupPath & "\UPLOADDOCS\" & TXTCARSRNO.Text.Trim & txtuploadsrno.Text.Trim & TXTFILENAME.Text.Trim
        On Error Resume Next

        If txtimgpath.Text.Trim.Length <> 0 Then
            PBQRCODE.ImageLocation = txtimgpath.Text.Trim
            PBQRCODE.Load(txtimgpath.Text.Trim)
        End If
    End Sub

    Private Async Sub CMDGETQRCODE_Click(sender As Object, e As EventArgs) Handles CMDGETQRCODE.Click
        Try
            If edit = True And TXTIRNNO.Text.Trim <> "" And IsNothing(PBQRCODE.Image) = True Then

                'FIRST GETTOKEN AND THEN GET QRCODE
                Dim OBJCMN As New ClsCommon
                Dim DT As New DataTable

                Dim URL As New Uri("https://einvapi.charteredinfo.com/eivital/dec/v1.04/auth?aspid=1602611918&password=infosys123&Gstin=" & CMPGSTIN & "&user_name=" & CMPEWBUSER & "&eInvPwd=" & CMPEWBPASS)

                ServicePointManager.Expect100Continue = True
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

                Dim REQUEST As WebRequest
                Dim RESPONSE As WebResponse
                REQUEST = WebRequest.CreateDefault(URL)

                REQUEST.Method = "GET"
                Try
                    RESPONSE = REQUEST.GetResponse()
                Catch ex As WebException
                    RESPONSE = ex.Response
                End Try
                Dim READER As StreamReader = New StreamReader(RESPONSE.GetResponseStream())
                Dim REQUESTEDTEXT As String = READER.ReadToEnd()

                'IF STATUS IS NOT 1 THEN TOKEN IS NOT GENERATED
                Dim STARTPOS As Integer = 0
                Dim TEMPSTATUS As String = ""
                Dim TOKEN As String = ""
                Dim ENDPOS As Integer = 0

                STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("status") + Len("STATUS") + 2
                TEMPSTATUS = REQUESTEDTEXT.Substring(STARTPOS, 1)
                If TEMPSTATUS = "1" Then TEMPSTATUS = "SUCCESS" Else TEMPSTATUS = "FAILED"




                STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("authtoken") + Len("AUTHTOKEN") + 3
                ENDPOS = REQUESTEDTEXT.ToLower.IndexOf(",", STARTPOS) - 1
                TOKEN = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)

                'ADD DATA IN EINVOICEENTRY
                'DONT ADD IN EINVOICEENTRY, DONE BY GULKIT, IF FAILED THEN ADD
                'DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','','" & TEMPSTATUS & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")


                'ONCE WE REC THE TOKEN WE WILL CREATE EWAY BILL
                'IF STATUS IS FAILED THEN ERROR MESSAGE
                If TEMPSTATUS = "FAILED" Then
                    MsgBox("Unable to create Eway Bill", MsgBoxStyle.Critical)
                    DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'CARINVOICE','" & TOKEN & "','','" & TEMPSTATUS & "','" & Replace(REQUESTEDTEXT, "'", "''") & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                    Exit Sub
                End If


                ''GET SIGNED QRCODE
                Dim req As New RestRequest
                req.AddParameter("application/json", "", RestSharp.ParameterType.RequestBody)
                'Dim client As New RestClient("http://gstsandbox.charteredinfo.com/eicore/dec/v1.03/Invoice/irn/" & TXTIRNNO.Text.Trim & "?aspid=1602611918&password=infosys123&gstin=34AACCC1596Q002&user_name=TaxProEnvPON&AuthToken=" & TOKEN & "&QrCodeSize=250")
                Dim client As New RestClient("https://einvapi.charteredinfo.com/eicore/dec/v1.03/Invoice/irn/" & TXTIRNNO.Text.Trim & "?aspid=1602611918&password=infosys123&gstin=" & CMPGSTIN & "&user_name=" & CMPEWBUSER & "&AuthToken=" & TOKEN & "&QrCodeSize=250")
                Dim res As IRestResponse = Await client.ExecuteTaskAsync(req)
                Dim respPl = New RespPl()
                respPl = JsonConvert.DeserializeObject(Of RespPl)(res.Content)
                Dim respPlGenIRNDec As New RespPlGenIRNDec()
                respPlGenIRNDec = JsonConvert.DeserializeObject(Of RespPlGenIRNDec)(respPl.Data)
                'MsgBox(respPlGenIRNDec.Irn)
                Dim qrImg As Byte() = Convert.FromBase64String(respPlGenIRNDec.QrCodeImage)
                Dim tc As TypeConverter = TypeDescriptor.GetConverter(GetType(Bitmap))
                Dim bitmap1 As Bitmap = CType(tc.ConvertFrom(qrImg), Bitmap)



                'bitmap1.Save(Application.StartupPath & "\" & Val(TXTINVOICENO.Text.Trim) & AccFrom.Year & ".png")
                'PBQRCODE.ImageLocation = Application.StartupPath & "\" & Val(TXTINVOICENO.Text.Trim) & AccFrom.Year & ".png"
                'PBQRCODE.Refresh()


                'GET REGINITIALS AS SAVE WITH IT
                'Dim TEMPREG As DataTable = OBJCMN.Execute_Any_String("SELECT REGISTER_INITIALS AS INITIALS FROM REGISTERMASTER WHERE REGISTER_NAME = 'VEHICLE SALE REGISTER' AND REGISTER_TYPE ='SALE' AND REGISTER_YEARID = " & YearId, "", "")
                bitmap1.Save(Application.StartupPath & "\VS" & Val(txtbookingno.Text.Trim) & AccFrom.Year & ".png")
                PBQRCODE.ImageLocation = Application.StartupPath & "\VS" & Val(txtbookingno.Text.Trim) & AccFrom.Year & ".png"
                PBQRCODE.Refresh()



                'If PBQRCODE.Image IsNot Nothing Then
                '    Dim OBJINVOICE As New ClsInvoiceMaster
                '    Dim MS As New IO.MemoryStream
                '    PBQRCODE.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                '    OBJINVOICE.alParaval.Add(TXTINVOICENO.Text.Trim)
                '    OBJINVOICE.alParaval.Add(cmbregister.Text.Trim)
                '    OBJINVOICE.alParaval.Add(MS.ToArray)
                '    OBJINVOICE.alParaval.Add(YearId)
                '    Dim INTRES As Integer = OBJINVOICE.SAVEQRCODE()
                'End If

                'DT = OBJCMN.Execute_Any_String("UPDATE INVOICEMASTER SET INVOICE_QRCODE = (SELECT * FROM OPENROWSET(BULK '" & Application.StartupPath & "\" & Val(TXTINVOICENO.Text.Trim) & AccFrom.Year & ".png',SINGLE_BLOB) AS IMG) FROM INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICE_REGISTERID = REGISTER_ID WHERE INVOICE_NO = " & Val(TXTINVOICENO.Text.Trim) & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND INVOICE_YEARID = " & YearId, "", "")

                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'CARINVOICE','" & TOKEN & "','" & TXTIRNNO.Text.Trim & "','QRCODE SUCCESS', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'CARINVOICE','" & TOKEN & "','" & TXTIRNNO.Text.Trim & "','QRCODE SUCCESS1', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                cmdok_Click(sender, e)

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLEINV_Click(sender As Object, e As EventArgs) Handles TOOLEINV.Click
        Try
            If edit = False Then Exit Sub
            GENERATEINV()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Async Sub GENERATEINV()
        Try
            If ALLOWEINVOICE = False Then Exit Sub
            If CMBNAME.Text.Trim = "" Then Exit Sub

            If Val(TXTCGSTAMT.Text.Trim) = 0 And Val(TXTSGSTAMT.Text.Trim) = 0 And Val(TXTIGSTAMT.Text.Trim) = 0 Then Exit Sub

            If MsgBox("Generate E-Invoice?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            If TXTIRNNO.Text.Trim <> "" Then
                MsgBox("E-Invoice Already Generated", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'BEFORE GENERATING EWAY BILL WE NEED TO VALIDATE WHETHER ALL THE DATA ARE PRESENT OR NOT
            'IF DATA IS NOT PRESENT THEN VALIDATE
            'DATA TO BE CHECKED 
            '   1)CMPEWBUSER | CMPEWBPASS | CMPGSTIN | CMPPINCODE | CMPCITY | CMPSTATE | 
            '   2)PARTYGSTIN | PARTYCITY | PARTYPINCODE | PARTYSTATE | PARTYSTATECODE | PARTYKMS
            '   3)CGST OR SGST OR IGST (ALWAYS USE MTR IN QTYUNIT)
            If CMPEWBUSER = "" Or CMPEWBPASS = "" Or CMPGSTIN = "" Or CMPPINCODE = "" Or CMPCITYNAME = "" Or CMPSTATENAME = "" Then
                MsgBox(" Company Details are not filled properly ", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Dim TEMPCMPADD1 As String = ""
            Dim TEMPCMPADD2 As String = ""
            Dim TEMPCMPDISPATCHADD1 As String = ""
            Dim PARTYGSTIN As String = ""
            Dim PARTYPINCODE As String = ""
            Dim PARTYSTATECODE As String = ""
            Dim PARTYSTATENAME As String = ""
            Dim SHIPTOGSTIN As String = ""
            Dim SHIPTOSTATECODE As String = ""
            Dim SHIPTOSTATENAME As String = ""
            Dim SHIPTOPINCODE As String = ""
            Dim PARTYKMS As Double = 0
            Dim PARTYADD1 As String = ""
            Dim PARTYADD2 As String = ""
            Dim SHIPTOADD1 As String = ""
            Dim SHIPTOADD2 As String = ""
            Dim TRANSGSTIN As String = ""
            'Dim KOTHARIPLACE As String = ""  'THIS VARIABLE IS USED TO FETCH RANGE COLUMN ONLY FOR KOTHARI, THEY WILL ENTER FULL SHIPTO ADDRESS THERE
            Dim DISPATCHFROM As String = ""
            Dim DISPATCHFROMGSTIN As String = ""
            Dim DISPATCHFROMPINCODE As String = ""
            Dim DISPATCHFROMSTATECODE As String = ""
            Dim DISPATCHFROMSTATENAME As String = ""
            Dim DISPATCHFROMKMS As Double = 0
            Dim DISPATCHFROMADD1 As String = ""
            Dim DISPATCHFROMADD2 As String = ""


            Dim OBJCMN As New ClsCommon
            'CMP ADDRESS DETAILS
            Dim DT As DataTable = OBJCMN.search(" ISNULL(CMP_ADD1, '') AS ADD1, ISNULL(CMP_ADD2,'') AS ADD2, ISNULL(CMP_DISPATCHFROM, '') AS DISPATCHADD ", "", " CMPMASTER ", " AND CMP_ID = " & CmpId)
            TEMPCMPADD1 = DT.Rows(0).Item("ADD1")
            TEMPCMPADD2 = DT.Rows(0).Item("ADD2")
            TEMPCMPDISPATCHADD1 = DT.Rows(0).Item("DISPATCHADD")
            DISPATCHFROM = CmpName
            DISPATCHFROMGSTIN = CMPGSTIN
            DISPATCHFROMPINCODE = CMPPINCODE
            DISPATCHFROMSTATECODE = CMPSTATECODE
            DISPATCHFROMSTATENAME = CMPSTATENAME


            'PARTY GST DETAILS 
            DT = OBJCMN.search(" ISNULL(ACC_GSTIN, '') AS GSTIN, ISNULL(ACC_ZIPCODE,'') AS PINCODE, ISNULL(STATE_NAME,'') AS STATENAME, ISNULL(CAST(STATE_REMARK AS VARCHAR(20)),'') AS STATECODE, ISNULL(ACC_ADD1,'') AS ADD1, ISNULL(ACC_ADD2,'') AS ADD2  ", "", " LEDGERS LEFT OUTER JOIN STATEMASTER ON ACC_STATEID = STATE_ID ", " AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND ACC_YEARID = " & YearId)
            If (DT.Rows(0).Item("GSTIN") = "" Or DT.Rows(0).Item("PINCODE") = "" Or DT.Rows(0).Item("STATENAME") = "" Or DT.Rows(0).Item("STATECODE") = "") Then
                MsgBox(" Party Details are not filled properly ", MsgBoxStyle.Critical)
                Exit Sub
            Else
                PARTYGSTIN = DT.Rows(0).Item("GSTIN")
                SHIPTOGSTIN = DT.Rows(0).Item("GSTIN")
                PARTYSTATENAME = DT.Rows(0).Item("STATENAME")
                PARTYSTATECODE = DT.Rows(0).Item("STATECODE")
                SHIPTOSTATENAME = DT.Rows(0).Item("STATENAME")
                SHIPTOSTATECODE = DT.Rows(0).Item("STATECODE")
                PARTYPINCODE = DT.Rows(0).Item("PINCODE")
                'PARTYKMS = Val(DT.Rows(0).Item("KMS"))
                PARTYADD1 = DT.Rows(0).Item("ADD1")
                PARTYADD2 = DT.Rows(0).Item("ADD2")
            End If


            'CHECKING COUNTER AND VALIDATE WHETHER EINVOICE WILL BE ALLOWED OR NOT, FOR EACH EINVOICE BILL WE NEED TO 2 API COUNTS (1 FOR TOKEN AND ANOTHER FOR EINVOICE)
            If CMPEINVOICECOUNTER = 0 Then
                MsgBox("E-Invoice Bill Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'GET USED EINVOICECOUNTER
            Dim USEDEINVOICECOUNTER As Integer = 0
            DT = OBJCMN.search("COUNT(COUNTERID) AS EINVOICECOUNT", "", "EINVOICEENTRY", " AND CMPID =" & CmpId)
            If DT.Rows.Count > 0 Then USEDEINVOICECOUNTER = Val(DT.Rows(0).Item("EINVOICECOUNT"))

            'IF COUNTERS ARE FINISJED
            If CMPEINVOICECOUNTER - USEDEINVOICECOUNTER <= 0 Then
                MsgBox("E-Invoice Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'IF DATE HAS EXPIRED
            If Now.Date > EINVOICEEXPDATE Then
                MsgBox("E-Invoice Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'IF BALANCECOUNTERS ARE .10 THEN INTIMATE
            If CMPEINVOICECOUNTER - USEDEINVOICECOUNTER < Format((CMPEINVOICECOUNTER * 0.1), "0") Then
                MsgBox("Only " & (CMPEINVOICECOUNTER - USEDEINVOICECOUNTER) & " API's Left, Kindly contact Nakoda Infotech for Renewal of E-Invoice Package", MsgBoxStyle.Critical)
            End If


            'FOR GENERATING EINVOICE BILL WE NEED TO FIRST GENERATE THE TOKEN
            'THIS IS FOR SANDBOX TEST
            'Dim URL As New Uri("http://gstsandbox.charteredinfo.com/eivital/dec/v1.04/auth?aspid=1602611918&password=infosys123&Gstin=34AACCC1596Q002&user_name=TaxProEnvPON&eInvPwd=abc34*")
            Dim URL As New Uri("https://einvapi.charteredinfo.com/eivital/dec/v1.04/auth?aspid=1602611918&password=infosys123&Gstin=" & CMPGSTIN & "&user_name=" & CMPEWBUSER & "&eInvPwd=" & CMPEWBPASS)

            ServicePointManager.Expect100Continue = True
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

            Dim REQUEST As WebRequest
            Dim RESPONSE As WebResponse
            REQUEST = WebRequest.CreateDefault(URL)

            REQUEST.Method = "GET"
            Try
                RESPONSE = REQUEST.GetResponse()
            Catch ex As WebException
                RESPONSE = ex.Response
            End Try
            Dim READER As StreamReader = New StreamReader(RESPONSE.GetResponseStream())
            Dim REQUESTEDTEXT As String = READER.ReadToEnd()

            'IF STATUS IS NOT 1 THEN TOKEN IS NOT GENERATED
            Dim STARTPOS As Integer = 0
            Dim TEMPSTATUS As String = ""
            Dim TOKEN As String = ""
            Dim ENDPOS As Integer = 0

            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("status") + Len("STATUS") + 2
            TEMPSTATUS = REQUESTEDTEXT.Substring(STARTPOS, 1)
            If TEMPSTATUS = "1" Then TEMPSTATUS = "SUCCESS" Else TEMPSTATUS = "FAILED"




            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("authtoken") + Len("AUTHTOKEN") + 3
            ENDPOS = REQUESTEDTEXT.ToLower.IndexOf(",", STARTPOS) - 1
            TOKEN = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)

            'ADD DATA IN EINVOICEENTRY
            'DONT ADD IN EINVOICEENTRY, DONE BY GULKIT, IF FAILED THEN ADD
            'DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','','" & TEMPSTATUS & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")


            'ONCE WE REC THE TOKEN WE WILL CREATE EWAY BILL
            'IF STATUS IS FAILED THEN ERROR MESSAGE
            If TEMPSTATUS = "FAILED" Then
                MsgBox("Unable to create E-Invoice", MsgBoxStyle.Critical)
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'CARINVOICE','" & TOKEN & "','','" & TEMPSTATUS & "','" & REQUESTEDTEXT & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                Exit Sub
            End If

            Dim j As String = ""
            Dim PRINTINITIALS As String = ""

            'GENERATING EINVOICE
            'FOR SANBOX TEST
            'Dim FURL As New Uri("http://gstsandbox.charteredinfo.com/eicore/dec/v1.03/Invoice?aspid=1602611918&password=infosys123&Gstin=34AACCC1596Q002&AuthToken=" & TOKEN & "&user_name=TaxProEnvPON&QrCodeSize=250")
            Dim FURL As New Uri("https://einvapi.charteredinfo.com/eicore/dec/v1.03/Invoice?aspid=1602611918&password=infosys123&Gstin=" & CMPGSTIN & "&AuthToken=" & TOKEN & "&user_name=" & CMPEWBUSER & "&QrCodeSize=250")
            REQUEST = WebRequest.CreateDefault(FURL)
            REQUEST.Method = "POST"
            Try
                REQUEST.ContentType = "application/json"



                j = "{"
                j = j & """Version"": ""1.1"","
                j = j & """TranDtls"": {"
                j = j & """TaxSch"":""GST"","
                j = j & """SupTyp"":""B2B"","
                j = j & """RegRev"":""N"","
                j = j & """IgstOnIntra"":""N""},"



                'WE NEED TO FETCH INITIALS INSTEAD OF BILLNO
                Dim DTINI As DataTable = OBJCMN.search("BOOKING_PRINTINITIALS AS PRINTINITIALS", "", " CARBOOKINGMASTER ", " AND BOOKING_NO = " & Val(txtbookingno.Text.Trim) & " AND BOOKING_YEARID = " & YearId)
                PRINTINITIALS = DTINI.Rows(0).Item("PRINTINITIALS")

                j = j & """DocDtls"": {"
                j = j & """Typ"":""INV"","
                j = j & """No"":""" & DTINI.Rows(0).Item("PRINTINITIALS") & """" & ","
                j = j & """Dt"":""" & bookingdate.Text & """" & "},"


                'For WORKING ON SANDBOX
                'CMPGSTIN = "34AACCC1596Q002"
                'CMPPINCODE = "605001"
                'CMPSTATECODE = "34"


                j = j & """SellerDtls"": {"
                j = j & """Gstin"":""" & CMPGSTIN & """" & ","
                j = j & """LglNm"":""" & CmpName & """" & ","
                j = j & """TrdNm"":""" & CmpName & """" & ","
                j = j & """Addr1"":""" & TEMPCMPADD1.Trim.Replace(vbCrLf, " ") & """" & ","
                j = j & """Addr2"":""" & TEMPCMPADD2.Trim.Replace(vbCrLf, " ") & """" & ","
                j = j & """Loc"":""" & CMPCITYNAME & """" & "," 'CMBFROMCITY.Text.Trim & """" & ","
                j = j & """Pin"":" & CMPPINCODE & "" & ","
                j = j & """Stcd"":""" & CMPSTATECODE & """" & "},"

                If PARTYADD1 = "" Then PARTYADD1 = PARTYSTATENAME
                If PARTYADD2 = "" Then PARTYADD2 = PARTYSTATENAME

                j = j & """BuyerDtls"": {"
                j = j & """Gstin"":""" & PARTYGSTIN & """" & ","
                j = j & """LglNm"":""" & CMBNAME.Text.Trim & """" & ","
                j = j & """TrdNm"":""" & CMBNAME.Text.Trim & """" & ","
                j = j & """Pos"":""" & PARTYSTATECODE & """" & ","
                j = j & """Addr1"":""" & PARTYADD1.Replace(vbCrLf, " ") & """" & ","
                j = j & """Addr2"":""" & PARTYADD2.Replace(vbCrLf, " ") & """" & ","
                j = j & """Loc"":""" & PARTYSTATENAME & """" & ","
                j = j & """Pin"":" & PARTYPINCODE & "" & ","
                j = j & """Stcd"":""" & PARTYSTATECODE & """" & "},"


                j = j & """DispDtls"": {"
                j = j & """Nm"":""" & DISPATCHFROM & """" & ","
                j = j & """Addr1"":""" & TEMPCMPDISPATCHADD1.Trim.Replace(vbCrLf, " ") & """" & ","
                j = j & """Addr2"":""" & TEMPCMPADD2.Trim.Replace(vbCrLf, " ") & """" & ","
                j = j & """Loc"":""" & CMPCITYNAME & """" & ","
                j = j & """Pin"":" & DISPATCHFROMPINCODE & "" & ","
                j = j & """Stcd"":""" & DISPATCHFROMSTATECODE & """" & "},"

                j = j & """ShipDtls"": {"
                If SHIPTOGSTIN <> "" Then j = j & """Gstin"":""" & SHIPTOGSTIN & """" & ","
                j = j & """LglNm"":""" & CMBNAME.Text.Trim & """" & ","
                j = j & """TrdNm"":""" & CMBNAME.Text.Trim & """" & ","
                If SHIPTOADD1 = "" Then j = j & """Addr1"":""" & PARTYADD1.Replace(vbCrLf, " ") & """" & "," Else j = j & """Addr1"":""" & SHIPTOADD1.Replace(vbCrLf, " ") & """" & ","
                If SHIPTOADD2 = "" Then SHIPTOADD2 = " ADDRESS2 "
                j = j & """Addr2"":""" & SHIPTOADD2 & """" & ","
                j = j & """Loc"":""" & PARTYSTATENAME & """" & ","
                If SHIPTOPINCODE = "" Then j = j & """Pin"":" & PARTYPINCODE & "" & "," Else j = j & """Pin"":" & SHIPTOPINCODE & "" & ","
                j = j & """Stcd"":""" & SHIPTOSTATECODE & """" & "},"

                Dim TEMPOTHERAMT As Double = 0.0
                Dim TEMPTOTALITEMAMT As Double = 0.0
                If CHKTAXSERVCHGS.Checked = True Then
                    TEMPOTHERAMT = Val(TXTTOTALSALEAMT.Text.Trim) - Val(TXTDISCRS.Text.Trim) + Val(TXTEXTRACHGS.Text.Trim) + Val(txttax.Text.Trim) + Val(txtotherchg.Text.Trim)
                    TEMPTOTALITEMAMT = Val(TXTTAXSERVCHGS.Text.Trim) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim)
                Else
                    TEMPOTHERAMT = Val(txttax.Text.Trim) + Val(txtotherchg.Text.Trim)
                    TEMPTOTALITEMAMT = Val(TXTSUBTOTAL.Text.Trim) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim)
                End If


                j = j & """ItemList"":[{"
                j = j & """SlNo"": """ & "1" & """" & ","
                'j = j & """PrdDesc"":""" & "Travel Booking" & """" & ","
                j = j & """IsServc"":""" & "Y" & """" & ","
                j = j & """HsnCd"":""" & TXTHSNCODE.Text.Trim & """" & ","
                'j = j & """Barcde"":""REC9999"","
                'j = j & """Qty"":" & Val(DTROW("PCS")) & "" & "," Else j = j & """Qty"":" & Val(DTROW("MTRS")) & "" & ","
                'j = j & """FreeQty"":" & "0" & "" & ","
                'j = j & """Unit"":""" & "MTR" & """" & ","
                If CHKTAXSERVCHGS.Checked = True Then j = j & """UnitPrice"":" & Val(TXTTAXSERVCHGS.Text.Trim) & "" & "," Else j = j & """UnitPrice"":" & Val(TXTSUBTOTAL.Text.Trim) & "" & ","
                If CHKTAXSERVCHGS.Checked = True Then j = j & """TotAmt"":" & Format(Val(TXTTAXSERVCHGS.Text.Trim), "0.00") & "" & "," Else j = j & """TotAmt"":" & Format(Val(TXTSUBTOTAL.Text.Trim), "0.00") & "" & ","

                'j = j & """Discount"":" & Format(Val(TEMPLINECHARGES), "0.00") & "" & ","
                'j = j & """PreTaxVal"":" & "1" & "" & ","
                If CHKTAXSERVCHGS.Checked = True Then j = j & """AssAmt"":" & Format(Val(TXTTAXSERVCHGS.Text.Trim), "0.00") & "" & "," Else j = j & """AssAmt"":" & Format(Val(TXTSUBTOTAL.Text.Trim), "0.00") & "" & ","
                Dim DTHSN As DataTable = OBJCMN.search(" ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER.HSN_IGST, 0) AS IGSTPER ", "", "HSNMASTER ", " AND HSNMASTER.HSN_CODE = '" & TXTHSNCODE.Text.Trim & "' AND HSNMASTER.HSN_YEARID=" & YearId)
                j = j & """GstRt"":" & Val(DTHSN.Rows(0).Item("IGSTPER")) & "" & ","


                j = j & """IgstAmt"":" & Val(TXTIGSTAMT.Text.Trim) & "" & ","
                j = j & """CgstAmt"":" & Val(TXTCGSTAMT.Text.Trim) & "" & ","
                j = j & """SgstAmt"":" & Val(TXTSGSTAMT.Text.Trim) & "" & ","
                j = j & """CesRt"":" & "0" & "" & ","
                j = j & """CesAmt"":" & "0" & "" & ","
                j = j & """CesNonAdvlAmt"":" & "0" & "" & ","
                j = j & """StateCesRt"":" & "0" & "" & ","
                j = j & """StateCesAmt"":" & "0" & "" & ","
                j = j & """StateCesNonAdvlAmt"":" & "0" & "" & ","
                j = j & """OthChrg"":" & "0" & "" & ","

                j = j & """TotItemVal"":" & Val(TEMPTOTALITEMAMT) & "" & ","
                j = j & """OrdLineRef"":"" "","
                j = j & """OrgCntry"":""IN"","
                j = j & """PrdSlNo"":""123"","

                j = j & """BchDtls"": {"
                j = j & """Nm"":""123"","
                j = j & """Expdt"":""" & bookingdate.Text & """" & ","
                j = j & """wrDt"":""" & bookingdate.Text & """" & "},"

                j = j & """AttribDtls"": [{"
                j = j & """Nm"":""123"","
                j = j & """Val"":""" & Val(TEMPTOTALITEMAMT) & """" & "}]"

                j = j & " }"

                j = j & " ],"



                j = j & """ValDtls"": {"
                If CHKTAXSERVCHGS.Checked = True Then j = j & """AssVal"":" & Val(TXTTAXSERVCHGS.Text.Trim) & "" & "," Else j = j & """AssVal"":" & Val(TXTSUBTOTAL.Text.Trim) & "" & ","
                j = j & """CgstVal"":" & Val(TXTCGSTAMT.Text.Trim) & "" & ","
                j = j & """SgstVal"":" & Val(TXTSGSTAMT.Text.Trim) & "" & ","
                j = j & """IgstVal"":" & Val(TXTIGSTAMT.Text.Trim) & "" & ","

                j = j & """CesVal"":" & "0" & "" & ","
                j = j & """StCesVal"":" & "0" & "" & ","
                j = j & """Discount"":" & "0" & "" & ","
                j = j & """OthChrg"":" & Val(TEMPOTHERAMT) & "" & ","
                j = j & """RndOffAmt"":" & Val(txtroundoff.Text.Trim) & "" & ","
                j = j & """TotInvVal"":" & Val(txtgrandtotal.Text.Trim) & "" & ","
                j = j & """TotInvValFc"":" & "0" & "" & "},"


                j = j & """PayDtls"": {"
                j = j & """Nm"":"" "","
                j = j & """Accdet"":"" "","
                j = j & """Mode"":""Credit"","
                j = j & """Fininsbr"":"" "","
                j = j & """Payterm"":"" "","
                j = j & """Payinstr"":"" "","
                j = j & """Crtrn"":"" "","
                j = j & """Dirdr"":"" "","
                j = j & """Crday"":" & "0" & "" & ","
                j = j & """Paidamt"":" & "0" & "" & ","
                j = j & """Paymtdue"":" & Val(txtgrandtotal.Text.Trim) & "" & "},"


                j = j & """RefDtls"": {"
                j = j & """InvRm"":""TEST"","
                j = j & """DocPerdDtls"": {"
                j = j & """InvStDt"":""" & bookingdate.Text & """" & ","
                j = j & """InvEndDt"":""" & bookingdate.Text & """" & "},"

                j = j & """PrecDocDtls"": [{"
                j = j & """InvNo"":""" & DTINI.Rows(0).Item("PRINTINITIALS") & """" & ","
                j = j & """InvDt"":""" & bookingdate.Text & """" & ","
                j = j & """OthRefNo"":"" ""}],"

                j = j & """ContrDtls"": [{"
                j = j & """RecAdvRefr"":"" "","
                j = j & """RecAdvDt"":""" & bookingdate.Text & """" & ","
                j = j & """Tendrefr"":"" "","
                j = j & """Contrrefr"":"" "","
                j = j & """Extrefr"":"" "","
                j = j & """Projrefr"":"" "","
                j = j & """Porefr"":"" "","
                j = j & """PoRefDt"":""" & bookingdate.Text & """" & "}]"
                j = j & "},"




                j = j & """AddlDocDtls"": [{"
                j = j & """Url"":""https://einv-apisandbox.nic.in"","
                j = j & """Docs"":""INVOICE"","
                j = j & """Info"":""INVOICE""}],"

                j = j & """TransDocNo"":"" "","



                j = j & """ExpDtls"": {"
                j = j & """ShipBNo"":"" "","
                j = j & """ShipBDt"":""" & bookingdate.Text & """" & ","
                j = j & """Port"":""INBOM1"","
                j = j & """RefClm"":""N"","
                j = j & """ForCur"":""AED"","
                j = j & """CntCode"":""AE""}"



                'THIS CODE IS WRITTEN COZ WHEN BILLTO AND SHIPTO ARE IN THE SAME PINCODE THEN WE HAVE TO PASS MINIMUM 10 KMS
                'OR ELSE IT WILL GIVE ERROR
                If DISPATCHFROMPINCODE = PARTYPINCODE Then PARTYKMS = 10

                'WE HAVE REMOVED CREATING EWAY DIRECTLY FORM EINVOICE
                'USER HAVE TO MANUALLY CREATE EWAY SEPERATELY
                'If TXTVEHICLENO.Text.Trim <> "" Then
                '    j = j & ","
                '    j = j & """EwbDtls"": {"
                '    j = j & """TransId"":""" & TRANSGSTIN & """" & ","
                '    j = j & """TransName"":""" & cmbtrans.Text.Trim & """" & ","
                '    j = j & """Distance"":""" & PARTYKMS & """" & ","
                '    If LRDATE.Text <> "__/__/____" Then j = j & """TransDocDt"":""" & LRDATE.Text & """" & "," Else j = j & """TransDocDt"":"""","
                '    j = j & """VehNo"":""" & TXTVEHICLENO.Text.Trim & """" & ","
                '    j = j & """VehType"":""" & "R" & """" & ","
                '    j = j & """TransMode"":""1""" & "}"
                'End If

                j = j & "}"


                Dim stream As Stream = REQUEST.GetRequestStream()
                Dim buffer As Byte() = System.Text.Encoding.UTF8.GetBytes(j)
                stream.Write(buffer, 0, buffer.Length)

                'POST request absenden
                RESPONSE = REQUEST.GetResponse()



            Catch ex As WebException
                'RESPONSE = ex.Response
                'MsgBox("Error While Generating EWB, Please check the Data Properly")
                ''ADD DATA IN EINVOICEENTRY
                'DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','','FAILED', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")

                RESPONSE = ex.Response
                READER = New StreamReader(RESPONSE.GetResponseStream())
                REQUESTEDTEXT = READER.ReadToEnd()
                GoTo ERRORMESSAGE
            End Try

            READER = New StreamReader(RESPONSE.GetResponseStream())
            REQUESTEDTEXT = READER.ReadToEnd()


            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("status") + Len("STATUS") + 3
            TEMPSTATUS = REQUESTEDTEXT.Substring(STARTPOS, 1)
            If TEMPSTATUS = "1" Then
                TEMPSTATUS = "SUCCESS"
                MsgBox("E-Invoice Generated Successfully ")

            Else

ERRORMESSAGE:
                TEMPSTATUS = "FAILED"

                'Dim ERRORMSG As String = ""
                'STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("ErrorMessage") + Len("ErrorMessage") + 5
                'ENDPOS = REQUESTEDTEXT.ToLower.IndexOf("""", STARTPOS) - 2
                'ERRORMSG = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)

                'ADD DATA IN EINVOICEENTRY
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'CARINVOICE','" & TOKEN & "','','FAILED','" & Replace(REQUESTEDTEXT, "'", "''") & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")

                MsgBox("Error While Generating E-Invoice, " & REQUESTEDTEXT)

                Exit Sub
            End If


            Dim IRNNO As String = ""
            Dim ACKNO As String = ""
            Dim ADATE As String = ""


            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("ackno") + Len("ACKNO") + 5
            ENDPOS = REQUESTEDTEXT.ToLower.IndexOf("\", STARTPOS)
            ACKNO = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)
            TXTACKNO.Text = ACKNO


            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("ackdt") + Len("ACKDT") + 5
            ENDPOS = REQUESTEDTEXT.ToLower.IndexOf("\", STARTPOS)
            ADATE = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)
            ACKDATE.Value = ADATE

            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("irn") + Len("IRN") + 5
            ENDPOS = REQUESTEDTEXT.ToLower.IndexOf("\", STARTPOS)
            IRNNO = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)
            TXTIRNNO.Text = IRNNO


            'WE NEED TO UPDATE THIS IRNNO IN DATABASE ALSO
            DT = OBJCMN.Execute_Any_String("UPDATE CARBOOKINGMASTER SET BOOKING_IRNNO = '" & TXTIRNNO.Text.Trim & "', BOOKING_ACKNO = '" & TXTACKNO.Text.Trim & "', BOOKING_ACKDATE = '" & Format(ACKDATE.Value.Date, "MM/dd/yyyy") & "' FROM CARBOOKINGMASTER WHERE BOOKING_NO = " & Val(txtbookingno.Text.Trim) & " AND BOOKING_YEARID = " & YearId, "", "")

            'ADD DATA IN EINVOICEENTRY
            DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'CARINVOICE','" & TOKEN & "','" & IRNNO & "','" & TEMPSTATUS & "', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")


            'ADD DATA IN EINVOICEENTRY FOR QRCODE
            If TEMPSTATUS = "SUCCESS" Then

                ''GET SIGNED QRCODE
                Dim req As New RestRequest
                req.AddParameter("application/json", j, RestSharp.ParameterType.RequestBody)
                'Dim client As New RestClient("http://gstsandbox.charteredinfo.com/eicore/dec/v1.03/Invoice/irn/" & TXTIRNNO.Text.Trim & "?aspid=1602611918&password=infosys123&gstin=34AACCC1596Q002&user_name=TaxProEnvPON&AuthToken=" & TOKEN & "&QrCodeSize=250")
                Dim client As New RestClient("https://einvapi.charteredinfo.com/eicore/dec/v1.03/Invoice/irn/" & TXTIRNNO.Text.Trim & "?aspid=1602611918&password=infosys123&gstin=" & CMPGSTIN & "&user_name=" & CMPEWBUSER & "&AuthToken=" & TOKEN & "&QrCodeSize=250")
                Dim res As IRestResponse = Await client.ExecuteTaskAsync(req)
                Dim respPl = New RespPl()
                respPl = JsonConvert.DeserializeObject(Of RespPl)(res.Content)
                Dim respPlGenIRNDec As New RespPlGenIRNDec()
                respPlGenIRNDec = JsonConvert.DeserializeObject(Of RespPlGenIRNDec)(respPl.Data)
                'MsgBox(respPlGenIRNDec.Irn)
                Dim qrImg As Byte() = Convert.FromBase64String(respPlGenIRNDec.QrCodeImage)
                Dim tc As TypeConverter = TypeDescriptor.GetConverter(GetType(Bitmap))
                Dim bitmap1 As Bitmap = CType(tc.ConvertFrom(qrImg), Bitmap)

                'GET REGINITIALS AS SAVE WITH IT
                'Dim TEMPREG As DataTable = OBJCMN.Execute_Any_String("SELECT REGISTER_INITIALS AS INITIALS FROM REGISTERMASTER WHERE REGISTER_NAME = 'VEHICLE SALE REGISTER' AND REGISTER_TYPE ='SALE' AND REGISTER_YEARID = " & YearId, "", "")
                bitmap1.Save(Application.StartupPath & "\VS" & Val(txtbookingno.Text.Trim) & AccFrom.Year & ".png")
                PBQRCODE.ImageLocation = Application.StartupPath & "\VS" & Val(txtbookingno.Text.Trim) & AccFrom.Year & ".png"
                PBQRCODE.Refresh()

                If PBQRCODE.Image IsNot Nothing Then
                    Dim OBJINVOICE As New ClsCarBooking
                    Dim MS As New IO.MemoryStream
                    PBQRCODE.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                    OBJINVOICE.alParaval.Add(txtbookingno.Text.Trim)
                    OBJINVOICE.alParaval.Add(MS.ToArray)
                    OBJINVOICE.alParaval.Add(YearId)
                    Dim INTRES As Integer = OBJINVOICE.SAVEQRCODE()
                End If

                'DT = OBJCMN.Execute_Any_String("UPDATE INVOICEMASTER SET INVOICE_QRCODE = (SELECT * FROM OPENROWSET(BULK '" & Application.StartupPath & "\" & Val(TXTINVOICENO.Text.Trim) & AccFrom.Year & ".png',SINGLE_BLOB) AS IMG) FROM INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICE_REGISTERID = REGISTER_ID WHERE INVOICE_NO = " & Val(TXTINVOICENO.Text.Trim) & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND INVOICE_YEARID = " & YearId, "", "")


                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'CARINVOICE','" & TOKEN & "','" & IRNNO & "','QRCODE SUCCESS', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'CARINVOICE','" & TOKEN & "','" & IRNNO & "','QRCODE SUCCESS1', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")

            End If




            'STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("QrCodeImage\", 0) + Len("QrCodeImage\") + 5
            'ENDPOS = REQUESTEDTEXT.ToLower.IndexOf("""", STARTPOS)
            ''Dim QRSTREAM As New MemoryStream
            ''Dim bmp As New Bitmap(QRSTREAM)
            ''bmp.Save(QRSTREAM, Drawing.Imaging.ImageFormat.Bmp)
            ''QRSTREAM.Position = STARTPOS
            ''Dim data As Byte()
            ''QRSTREAM.Read(data, STARTPOS, STARTPOS - ENDPOS)

            'Dim bytes() As Byte
            'Dim ImageInStringFormat As String = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)
            'Dim MS As System.IO.MemoryStream
            'Dim NewImage As Bitmap

            'Dim nbyte() As Byte = System.Text.Encoding.UTF8.GetBytes(ImageInStringFormat)
            'Dim BASE64STRING As String = Convert.ToBase64String(nbyte)

            'bytes = Convert.FromBase64String(BASE64STRING)
            'NewImage = BytesToBitmap(bytes)
            'MS = New System.IO.MemoryStream(bytes)
            'MS.Write(bytes, 0, bytes.Length)
            'NewImage.Save(MS, Drawing.Imaging.ImageFormat.Bmp)    ' = System.Drawing.Image.FromStream(MS, True)
            'NewImage.Save("d:\qrcode.jpg", System.Drawing.Imaging.ImageFormat.Jpeg)

            'IRNNO = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)

            ''ADD data IN EINVOICEENTRY
            'DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','" & IRNNO & "','" & TEMPSTATUS & "', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")



        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHSNITEMDESC_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBHSNITEMDESC.Enter
        Try
            If CMBHSNITEMDESC.Text.Trim = "" Then FILLHSNITEMDESC(CMBHSNITEMDESC)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKPURTAXSERVCHGS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKPURSERVTAX.CheckedChanged
        Try
            PURCHASECALC()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLHSNITEMDESC(ByRef CMBHSNITEMDESC As ComboBox)
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" ISNULL(HSN_ITEMDESC, '') AS HSNITEMDESC ", "", " HSNMASTER ", " AND HSN_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "HSNITEMDESC"
                CMBHSNITEMDESC.DataSource = dt
                CMBHSNITEMDESC.DisplayMember = "HSNITEMDESC"
                'CMBHSNITEMDESC.SelectedIndex = Nothing
            End If
            CMBHSNITEMDESC.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETHSNCODE()
        Try

            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable

            If CMBHSNITEMDESC.Text.Trim <> "" And Convert.ToDateTime(bookingdate.Value.Date).Date >= "01/07/2017" Then
                If CHKMANUAL.CheckState = CheckState.Unchecked Then
                    TXTHSNCODE.Clear()
                    TXTCGSTPER.Clear()
                    TXTCGSTAMT.Clear()
                    TXTSGSTPER.Clear()
                    TXTSGSTAMT.Clear()
                    TXTIGSTPER.Clear()
                    TXTIGSTAMT.Clear()
                End If


                DT = OBJCMN.search("  ISNULL(HSN_CODE, '') AS HSNCODE, ISNULL(HSN_CGST, 0) AS CGSTPER, ISNULL(HSN_SGST, 0) AS SGSTPER, ISNULL(HSN_IGST, 0) AS IGSTPER, ISNULL(HSN_CGST, 0) AS PURCGSTPER, ISNULL(HSN_SGST, 0) AS PURSGSTPER, ISNULL(HSN_IGST, 0) AS PURIGSTPER ", "", " HSNMASTER ", " AND HSNMASTER.HSN_ITEMDESC = '" & CMBHSNITEMDESC.Text.Trim & "' AND HSNMASTER.HSN_YEARID='" & YearId & "' ORDER BY HSNMASTER.HSN_ID DESC")
                If DT.Rows.Count > 0 Then
                    TXTHSNCODE.Text = DT.Rows(0).Item("HSNCODE")
                    If CMBNAME.Text.Trim <> "" Then
                        If TXTSTATECODE.Text.Trim = CMPSTATECODE Then
                            TXTIGSTPER.Text = 0
                            TXTCGSTPER.Text = Val(DT.Rows(0).Item("CGSTPER"))
                            TXTSGSTPER.Text = Val(DT.Rows(0).Item("SGSTPER"))
                        Else
                            TXTCGSTPER.Text = 0
                            TXTSGSTPER.Text = 0
                            TXTIGSTPER.Text = Val(DT.Rows(0).Item("IGSTPER"))
                        End If
                    End If
                End If
            End If

            If CMBPURHSNITEMDESC.Text.Trim <> "" And Convert.ToDateTime(PURDATE.Value.Date).Date >= "01/07/2017" Then
                If CHKPURMANUAL.CheckState = CheckState.Unchecked Then
                    TXTPURHSNCODE.Clear()
                    TXTPURCGSTPER.Clear()
                    TXTPURCGSTAMT.Clear()
                    TXTPURSGSTPER.Clear()
                    TXTPURSGSTAMT.Clear()
                    TXTPURIGSTPER.Clear()
                    TXTPURIGSTAMT.Clear()
                End If

                DT = OBJCMN.search("  ISNULL(HSN_CODE, '') AS PURHSNCODE, ISNULL(HSN_CGST, 0) AS PURCGSTPER, ISNULL(HSN_SGST, 0) AS PURSGSTPER, ISNULL(HSN_IGST, 0) AS PURIGSTPER ", "", " HSNMASTER ", " AND HSNMASTER.HSN_ITEMDESC = '" & CMBPURHSNITEMDESC.Text.Trim & "' AND HSNMASTER.HSN_YEARID='" & YearId & "' ORDER BY HSNMASTER.HSN_ID DESC")
                If DT.Rows.Count > 0 Then
                    TXTPURHSNCODE.Text = DT.Rows(0).Item("PURHSNCODE")

                    If CMBPURNAME.Text.Trim <> "" Then
                        If TXTPURSTATECODE.Text.Trim = CMPSTATECODE Then
                            TXTPURIGSTPER.Text = 0
                            TXTPURCGSTPER.Text = Val(DT.Rows(0).Item("PURCGSTPER"))
                            TXTPURSGSTPER.Text = Val(DT.Rows(0).Item("PURSGSTPER"))
                        Else
                            TXTPURCGSTPER.Text = 0
                            TXTPURSGSTPER.Text = 0
                            TXTPURIGSTPER.Text = Val(DT.Rows(0).Item("PURIGSTPER"))
                        End If
                    End If
                End If
            End If

            total()
            PURCHASECALC()



        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHSNITEMDESC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBHSNITEMDESC.Validated
        Try
            GETHSNCODE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKTAXSERVCHGS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKTAXSERVCHGS.CheckedChanged
        total()
    End Sub

    Private Sub TXTTAXSERVCHGS_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTTAXSERVCHGS.Validated
        total()
    End Sub

    Private Sub CMBPURHSNITEMDESC_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPURHSNITEMDESC.Enter
        Try
            If CMBPURHSNITEMDESC.Text.Trim = "" Then FILLHSNITEMDESC(CMBPURHSNITEMDESC)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPURHSNITEMDESC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPURHSNITEMDESC.Validated
        Try
            GETHSNCODE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKMANUAL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKMANUAL.CheckedChanged
        Try
            If CHKMANUAL.Checked = True Then
                TXTCGSTAMT.ReadOnly = False
                TXTCGSTAMT.TabStop = True
                TXTCGSTAMT.BackColor = Color.LemonChiffon
                TXTSGSTAMT.ReadOnly = False
                TXTSGSTAMT.TabStop = True
                TXTSGSTAMT.BackColor = Color.LemonChiffon
                TXTIGSTAMT.ReadOnly = False
                TXTIGSTAMT.TabStop = True
                TXTIGSTAMT.BackColor = Color.LemonChiffon
            Else
                TXTCGSTAMT.ReadOnly = True
                TXTCGSTAMT.TabStop = False
                TXTCGSTAMT.BackColor = Color.Linen
                TXTSGSTAMT.ReadOnly = True
                TXTSGSTAMT.TabStop = False
                TXTSGSTAMT.BackColor = Color.Linen
                TXTIGSTAMT.ReadOnly = True
                TXTIGSTAMT.TabStop = False
                TXTIGSTAMT.BackColor = Color.Linen
                total()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKPURMANUAL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKPURMANUAL.CheckedChanged
        Try
            If CHKPURMANUAL.Checked = True Then
                TXTPURCGSTAMT.ReadOnly = False
                TXTPURCGSTAMT.TabStop = True
                TXTPURCGSTAMT.BackColor = Color.LemonChiffon
                TXTPURSGSTAMT.ReadOnly = False
                TXTPURSGSTAMT.TabStop = True
                TXTPURSGSTAMT.BackColor = Color.LemonChiffon
                TXTPURIGSTAMT.ReadOnly = False
                TXTPURIGSTAMT.TabStop = True
                TXTPURIGSTAMT.BackColor = Color.LemonChiffon
            Else
                TXTPURCGSTAMT.ReadOnly = True
                TXTPURCGSTAMT.TabStop = False
                TXTPURCGSTAMT.BackColor = Color.Linen
                TXTPURSGSTAMT.ReadOnly = True
                TXTPURSGSTAMT.TabStop = False
                TXTPURSGSTAMT.BackColor = Color.Linen
                TXTPURIGSTAMT.ReadOnly = True
                TXTPURIGSTAMT.TabStop = False
                TXTPURIGSTAMT.BackColor = Color.Linen
                PURCHASECALC()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCGSTAMT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCGSTAMT.KeyPress, TXTSGSTAMT.KeyPress, TXTIGSTAMT.KeyPress, TXTPURCGSTAMT.KeyPress, TXTPURSGSTAMT.KeyPress, TXTPURIGSTAMT.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTCGSTAMT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCGSTAMT.Validated, TXTSGSTAMT.Validated, TXTIGSTAMT.Validated
        CALC()
        total()
    End Sub

    Private Sub TXTPURCGSTAMT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTPURCGSTAMT.Validated, TXTPURSGSTAMT.Validated, TXTPURIGSTAMT.Validated
        PURCHASECALC()
    End Sub

    Private Sub CMBGROUPDEPARTURE_Enter(sender As Object, e As EventArgs) Handles CMBGROUPDEPARTURE.Enter
        Try
            If CMBGROUPDEPARTURE.Text.Trim = "" Then FILLGROUPNAME(CMBGROUPDEPARTURE, " AND GROUPDEP_FROM < '" & Format(Convert.ToDateTime(bookingdate.Text).Date, "MM/dd/yyyy") & "'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Private Sub CMBGROUPDEPARTURE_Validated(sender As Object, e As EventArgs) Handles CMBGROUPDEPARTURE.Validated
    '    Try
    '        If Val(TXTADULTS.Text.Trim) = 0 Then
    '            MsgBox("Enter No. of Adults")
    '            CMBGROUPDEPARTURE.Text = ""
    '            TXTADULTS.Focus()
    '        Else
    '            If CMBGROUPDEPARTURE.Text.Trim <> "" And edit = False Then
    '                Dim TEMPGROUPNO As Integer

    '                'GET DATA FROM GROUP DEPARTURE
    '                Dim OBJCMN As New ClsCommon
    '                Dim DT As DataTable = OBJCMN.search(" GROUPDEPARTURE.GROUPDEP_NO AS GROUPNO,  GROUPDEPARTURE.GROUPDEP_FROM AS FROMDATE, GROUPDEPARTURE.GROUPDEP_TO AS TODATE, GROUPDEPARTURE.GROUPDEP_TOTALPACKAGEAMT AS TOTALPACKAGEAMT,  ISNULL(GROUPDEPARTURE_DESC.GROUPDEP_SRNO, 0) AS SRNO, ISNULL(HOTELMASTER.HOTEL_NAME, '') AS HOTELNAME, ISNULL(GROUPDEPARTURE_DESC.GROUPDEP_INCLUSIONS, '') AS INCLUSIONS, ISNULL(GROUPDEPARTURE_DESC.GROUPDEP_CHECKIN, '') AS CHECKIN, ISNULL(GROUPDEPARTURE_DESC.GROUPDEP_CHECKOUT, '') AS CHECKOUT, ISNULL(ROOMTYPEMASTER.ROOMTYPE_NAME, '') AS ROOMTYPE, ISNULL(PLANMASTER.PLAN_NAME, '') AS PLANNAME, ISNULL(GROUPDEPARTURE_DESC.GROUPDEP_NOOFROOMS, 0) AS NOOFROOMS, ISNULL(GROUPDEPARTURE_DESC.GROUPDEP_PACKAGE, '') AS PACKAGE, ISNULL(GROUPDEPARTURE_DESC.GROUPDEP_RATE, 0) AS RATE, ISNULL(GROUPDEPARTURE_DESC.GROUPDEP_AMOUNT, 0) AS AMOUNT, ISNULL(GROUPDEPARTURE_DESC.GROUPDEP_NIGHTS, 0) AS NIGHTS  ", "", " PLANMASTER INNER JOIN GROUPDEPARTURE INNER JOIN GROUPDEPARTURE_DESC ON GROUPDEPARTURE.GROUPDEP_NO = GROUPDEPARTURE_DESC.GROUPDEP_NO AND GROUPDEPARTURE.GROUPDEP_YEARID = GROUPDEPARTURE_DESC.GROUPDEP_YEARID INNER JOIN HOTELMASTER ON GROUPDEPARTURE_DESC.GROUPDEP_HOTELID = HOTELMASTER.HOTEL_ID INNER JOIN ROOMTYPEMASTER ON GROUPDEPARTURE_DESC.GROUPDEP_ROOMTYPEID = ROOMTYPEMASTER.ROOMTYPE_ID ON PLANMASTER.PLAN_ID = GROUPDEPARTURE_DESC.GROUPDEP_PLANID  ", "  AND GROUPDEPARTURE.GROUPDEP_NAME = '" & CMBGROUPDEPARTURE.Text.Trim & "' AND GROUPDEPARTURE.GROUPDEP_YEARID = " & YearId)
    '                If DT.Rows.Count > 0 Then
    '                    TXTTOURNAME.Text = CMBGROUPDEPARTURE.Text.Trim
    '                    GRIDBOOKINGS.RowCount = 0
    '                    TEMPGROUPNO = DT.Rows(0).Item("GROUPNO")
    '                    PACKAGEFROM.Value = DT.Rows(0).Item("FROMDATE")
    '                    PACKAGETO.Value = DT.Rows(0).Item("TODATE")
    '                    For Each ROW As DataRow In DT.Rows
    '                        If ClientName = "RAMKRISHNA" Then
    '                            GRIDBOOKINGS.Rows.Add(Val(ROW("SRNO")), ROW("HOTELNAME"), "", "", ROW("INCLUSIONS"), Format(Convert.ToDateTime(ROW("CHECKIN").DATE), "dd/MM/yyyy"), Format(Convert.ToDateTime(ROW("CHECKOUT").DATE), "dd/MM/yyyy"), ROW("ROOMTYPE"), ROW("PLANNAME"), Val(TXTADULTS.Text.Trim), Val(TXTCHILDS.Text.Trim), Val(TXTNCCHILDS.Text.Trim), 0, 0, 0, 0, Val(TXTTOTALPAX.Text.Trim), Val(ROW("NOOFROOMS")), ROW("PACKAGE"), Format(Val(TXTADULTS.Text.Trim) * Val(ROW("RATE")), "0.00"), 0, 0, "", 0, Format(Val(ROW("NOOFROOMS")) * Val(ROW("RATE")) * Val(TXTADULTS.Text.Trim), "0.00"), Val(ROW("NIGHTS")))
    '                            'GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(grate.Index).Value = Format(Val(DT.Rows(0).Item("TOTALPACKAGEAMT")) * Val(TXTADULTS.Text.Trim), "0.00")
    '                            'GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(gamt.Index).Value = Format(Val(GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(gnoofRooms.Index).Value) * Val(DT.Rows(0).Item("TOTALPACKAGEAMT")) * Val(TXTADULTS.Text.Trim), "0.00")
    '                        Else
    '                            GRIDBOOKINGS.Rows.Add(Val(ROW("SRNO")), ROW("HOTELNAME"), "", "", ROW("INCLUSIONS"), Format(Convert.ToDateTime(ROW("CHECKIN").DATE), "dd/MM/yyyy"), Format(Convert.ToDateTime(ROW("CHECKOUT").DATE), "dd/MM/yyyy"), ROW("ROOMTYPE"), ROW("PLANNAME"), Val(TXTADULTS.Text.Trim), Val(TXTCHILDS.Text.Trim), Val(TXTNCCHILDS.Text.Trim), 0, 0, 0, 0, Val(TXTTOTALPAX.Text.Trim), Val(ROW("NOOFROOMS")), ROW("PACKAGE"), Format(Val(ROW("RATE")), "0.00"), 0, 0, "", 0, Format(Val(ROW("AMOUNT")), "0.00"), Val(ROW("NIGHTS")))
    '                        End If
    '                    Next

    '                    If ClientName = "RAMKRISHNA" Then
    '                        GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(grate.Index).Value = Format(Val(DT.Rows(0).Item("TOTALPACKAGEAMT")) * Val(TXTADULTS.Text.Trim), "0.00")
    '                        GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(gamt.Index).Value = Format(Val(GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(gnoofRooms.Index).Value) * Val(DT.Rows(0).Item("TOTALPACKAGEAMT")) * Val(TXTADULTS.Text.Trim), "0.00")
    '                    End If

    '                End If


    '                DT = OBJCMN.search(" ISNULL(GROUPDEP_NO, 0) AS GROUPDEPNO, ISNULL(GROUPDEP_SRNO, 0) AS TOURSRNO, GROUPDEP_TOURDATE AS TOURDATE, ISNULL(GROUPDEP_TOURDETAILS, '') AS TOURDETAILS", "", " GROUPDEPARTURE_TOURDETAILS ", " AND GROUPDEPARTURE_TOURDETAILS.GROUPDEP_NO = " & TEMPGROUPNO & " AND GROUPDEP_YEARID = " & YearId & " ORDER BY GROUPDEPARTURE_TOURDETAILS.GROUPDEP_SRNO")
    '                If DT.Rows.Count > 0 Then
    '                    GRIDTOUR.RowCount = 0
    '                    For Each DTR As DataRow In DT.Rows
    '                        GRIDTOUR.Rows.Add(DTR("TOURSRNO"), Format(Convert.ToDateTime(DTR("TOURDATE").DATE), "dd/MM/yyyy"), DTR("TOURDETAILS"))
    '                    Next

    '                    '    For Each DTR As DataRow In DT.Rows
    '                    '        GRIDTOUR.Rows.Add(DTR("TOURSRNO"), DTR("TOURHEADER"), DTR("TOURDETAILS"))
    '                    '    Next
    '                End If


    '                'TRANSPORT GRID
    '                DT = OBJCMN.search(" ISNULL(VEHICLETYPE_NAME,'') AS VEHICLETYPE, ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_NO, 0) AS GROUPDEPNO, ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_SRNO, 0) AS SRNO, ISNULL(VEHICLEMASTER.VEHICLE_NAME, '') AS VEHICLE, GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_PICKUPON AS PICKUPON,ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_PICKUPFROM, '') AS PICKUPFROM ,ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_PICKUPTIME, '') AS PICKUPTIME, ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_PICKUPDTLS, '') AS PICKUPDTLS, GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_DROPON AS DROPON, ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_DROPAT, '') AS DROPAT, ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_DROPTIME, '') AS DROPTIME, ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_DROPDTLS, '') AS DROPDTLS, ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_CARDAYS, 0) AS CARDAYS, ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_NOTE, '') AS NOTE, ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_AMT, 0) AS AMOUNT ", "", " GROUPDEPARTURE_TRANSDETAILS INNER JOIN VEHICLEMASTER ON GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_VEHICLEID = VEHICLEMASTER.VEHICLE_ID LEFT OUTER JOIN VEHICLETYPEMASTER ON VEHICLE_TYPEID = VEHICLETYPE_ID ", " AND GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_NO = " & TEMPGROUPNO & " AND GROUPDEP_YEARID = " & YearId & " ORDER BY GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_SRNO")
    '                If DT.Rows.Count > 0 Then
    '                    GRIDTRANS.RowCount = 0
    '                    For Each DTR As DataRow In DT.Rows
    '                        GRIDTRANS.Rows.Add(DTR("SRNO"), "", "", DTR("VEHICLETYPE"), DTR("VEHICLE"), Val(TXTADULTS.Text.Trim), Val(TXTCHILDS.Text.Trim), Val(TXTTOTALPAX.Text.Trim), Format(Convert.ToDateTime(DTR("PICKUPON").DATE), "dd/MM/yyyy"), DTR("PICKUPFROM"), DTR("PICKUPTIME"), DTR("PICKUPDTLS"), Format(Convert.ToDateTime(DTR("DROPON").DATE), "dd/MM/yyyy"), DTR("DROPAT"), DTR("DROPTIME"), DTR("DROPDTLS"), Val(DTR("CARDAYS")), "", "", DTR("NOTE"), Format(Val(DTR("AMOUNT")), "0.00"))
    '                    Next
    '                End If
    '            End If

    '            TBDETAILS.SelectedIndex = 1
    '            total()
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub CMBGROUPDEPARTURE_Validating(sender As Object, e As CancelEventArgs) Handles CMBGROUPDEPARTURE.Validating
        Try
            If CMBGROUPDEPARTURE.Text.Trim <> "" Then GROUPNAMEVALIDATE(CMBGROUPDEPARTURE, e, Me, " AND GROUPDEP_FROM < '" & Format(Convert.ToDateTime(bookingdate.Text).Date, "MM/dd/yyyy") & "'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class