
Imports BL
Imports System.IO
Imports System.ComponentModel
Imports System.Net
Imports RestSharp
Imports TaxProEInvoice.API
Imports Newtonsoft.Json

Public Class AirlineBookings

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim gridDoubleClick As Boolean, DIRECTUPLOAD As Boolean
    Dim gridUPLOADdoubleclick As Boolean
    Dim gridFLIGHTDoubleClick As Boolean
    Dim IS_DOMESTIC As Boolean = False
    Dim IS_LCC As Boolean = False
    Dim temprow As Integer
    Dim tempFLIGHTrow As Integer
    Dim tempUPLOADrow As Integer
    Public edit As Boolean
    Public TEMPBOOKINGNO As Integer
    Public TEMPBOOKINGINITIALS As String
    Public FRMSTRING As String
    Dim TEMPMSG As Integer
    Dim COMMBASICPERC As Double     'GET THIS FROM FLIGHTMASTER
    Dim COMMPSFPERC As Double       'GET THIS FROM FLIGHTMASTER
    Dim COMMTAXPERC As Double       'GET THIS FROM FLIGHTMASTER
    Public Shared dt_amd As New DataTable
    Public Shared SELECTENQ As New DataTable
    Dim SALEregabbr, SALEreginitial As String
    Public SALEregid As Integer
    Dim DDATE As DateTime

    Private Sub AirlineBookings_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "ELYSIUM" Or ClientName = "7HOSPITALITY" Then
            Me.Close()
            Exit Sub
        End If

        If ALLOWEINVOICE = True Then TOOLEINV.Visible = True

        If ClientName = "SHREEJI" Or ClientName = "BARODA" Then
            CHKREFUNDED.Visible = True
            CHKFAILED.Visible = True
        End If
        If ClientName = "RAMKRISHNA" Or ClientName = "KHANNA" Then
            LBLGROUPDEP.Visible = True
            CMBGROUPDEPARTURE.Visible = True
        End If

        'AS PER DIPEN BHAI, HE WANTS ADD ROUNDOFF MANUALLY
        If ClientName = "PRIYA" Then
            TXTPURROUNDOFF.ReadOnly = False
            TXTPURROUNDOFF.TabStop = True
        End If

        'TDS DISCOUNT FOR SKYMAPS
        If ClientName = "SKYMAPS" Then
            LBLSALETDS.Visible = True
            TXTSALETDSPER.Visible = True
            TXTSALETDSRS.Visible = True
        End If
        If ClientName = "GLOBAL" Then
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
            LBLPURHSNDESC.Visible = False
            CMBPURHSNITEMDESC.Visible = False
            LBLPURHSNCODE.Visible = False
            TXTPURHSNCODE.Visible = False
            LBLSTATECODE.Visible = False
            TXTSTATECODE.Visible = False
            TXTPURSTATECODE.Visible = False
            CHKPURMANUAL.Visible = False
            LBLPURCGST.Visible = False
            TXTPURCGSTPER.Visible = False
            TXTPURCGSTAMT.Visible = False
            LBLPURSGST.Visible = False
            TXTPURSGSTPER.Visible = False
            TXTPURSGSTAMT.Visible = False
            LBLPURIGST.Visible = False
            TXTPURIGSTPER.Visible = False
            TXTPURIGSTAMT.Visible = False



        End If
    End Sub

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Sub getmax_BOOKING_no()
        Dim DTTABLE As New DataTable
        If ClientName = "UNIGO" Or ClientName = "TRAVELBRIDGE" Or ClientName = "TRAVIZIA" Then
            DTTABLE = getmax(" isnull(MAX(T.BOOKINGNO),0) + 1 ", " (SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM AIRLINEBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM HOTELBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM HOLIDAYPACKAGEMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM CARBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM INTERNATIONALBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM MISCSALMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM RAILBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM VISABOOKING WHERE BOOKING_YEARID = " & YearId & " ) AS T ", "")
        Else
            DTTABLE = getmax(" isnull(max(BOOKING_no),0) + 1 ", "AIRLINEBOOKINGMASTER", " AND BOOKING_SALEREGISTERID = " & SALEregid & " and BOOKING_cmpid=" & CmpId & " and BOOKING_locationid=" & Locationid & " and BOOKING_yearid=" & YearId)
        End If


        If DTTABLE.Rows.Count > 0 Then
            txtbookingno.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Sub clear()
        Try

            LBLPURBAL.ForeColor = Color.Green
            LBLACCBAL.ForeColor = Color.Green

            'Enable Manual Booking No
            If ClientName = "UNIGO" Or ClientName = "TRAVELBRIDGE" Or (ClientName = "CLASSIC" And UserName = "Admin") Or ClientName = "SKYMAPS" Or ClientName = "MILONI" Or ClientName = "NAMASTE" Or ClientName = "BARODA" Then
                txtbookingno.ReadOnly = False
                txtbookingno.Enabled = True
            End If

            If ClientName = "HEENKAR" Then
                CHKTAXSERVCHGS.CheckState = CheckState.Checked
                CHKPURTAXSERVCHGS.CheckState = CheckState.Checked
            Else
                CHKTAXSERVCHGS.CheckState = CheckState.Unchecked
                CHKPURTAXSERVCHGS.CheckState = CheckState.Unchecked

            End If


            TXTCOPY.Clear()
            tstxtbillno.Clear()
            TXTSEARCHTCKETNO.Clear()
            CMBCRSTYPE.Text = ""
            CMBAIRNAME.Text = ""
            CMBAIRCODE.Text = ""
            CMBNAME.Text = ""
            CMBACCCODE.Text = ""
            CMBPURCODE.Text = ""
            CMBPURNAME.Text = ""
            LBLACCBAL.Text = 0.0
            LBLPURBAL.Text = 0.0

            TXTPARTYREFNO.Clear()
            TXTPNRNO.Clear()
            TXTAIRLINEPNR.Clear()
            TXTCRSPNR.Clear()
            TXTREFNO.Clear()
            TXTPRINTNAME.Clear()
            TXTEMAILADD.Clear()
            TXTMOBILE.Clear()

            CMBBSP.Text = "No"
            CMBCOUPON.Text = "No"
            BOOKINGDATE.Text = Mydate
            TICKETDATE.Value = Mydate
            RETURNDATE.Value = Mydate
            TXTTOTALPAX.Clear()

            CMBGROUPDEPARTURE.Text = ""
            CMBGROUPDEPARTURE.Enabled = True
            cmdshowdetails.Visible = False
            PBRECD.Visible = False
            PBPAID.Visible = False
            PBDN.Visible = False
            PBCN.Visible = False
            PBlock.Visible = False
            lbllocked.Visible = False
            lblcancelled.Visible = False
            PBCancelled.Visible = False
            LBLEINVGENERATED.Visible = False



            txtsrno.Clear()
            TXTPASSNAME.Text = ""
            TXTSECTOR.Clear()
            TXTTEMPSECTOR.Clear()
            TXTFLTNO.Clear()
            CMBTYPE.SelectedIndex = 0
            TXTTICKETNO.Clear()
            TXTCLASS.Clear()
            TXTBASIC.Clear()
            TXTBASCIINCOME.Clear()
            INCOMEBASICGROUP.Visible = False
            TXTPSF.Clear()
            TXTPSFINCOME.Clear()
            INCOMEPSFGROUP.Visible = False
            TXTGRIDTAX.Clear()
            TXTTAXINCOME.Clear()
            INCOMETAXGROUP.Visible = False
            TXTTOTAL.Clear()

            GRIDBOOKINGS.RowCount = 0
            GRIDPASS.RowCount = 0
            GRIDPUR.RowCount = 0
            GRIDFLIGHT.RowCount = 0
            GRIDSECTOR.RowCount = 0
            SECTORGROUP.Visible = False
            SECTORGROUP.SendToBack()
            gridupload.RowCount = 0
            GRIDBOOKINGS.ClearSelection()

            TBDETAILS.SelectedIndex = 0

            TXTTOTALBASIC.Clear()
            TXTTOTALPSF.Clear()
            TXTTOTALTAXES.Clear()
            TXTTOTALAMT.Text = 0.0

            TXTPURAMT.Text = 0.0
            TXTTOTALPURAMT.Text = 0.0
            TXTDISCRECDPER.Text = 0.0
            TXTDISCRECDRS.Text = 0.0
            TXTPURSUBTOTAL.Text = 0.0
            TXTCOMMRECDPER.Text = 0.0
            TXTCOMMRECDRS.Text = 0.0
            TXTPURTDSPER.Text = 0.0
            TXTPURTDSRS.Text = 0.0
            TXTPUREXTRACHGS.Text = 0.0
            TXTPURNETTAMT.Text = 0.0
            CMBPURTAX.Text = ""
            TXTPURTAX.Text = 0.0
            TXTPURTAX.ReadOnly = True
            TXTPURTAX.Enabled = False

            CMBPURADDTAX.Text = ""
            TXTPURADDTAX.Text = 0.0
            txtPurDiscountPerc.Clear()
            txtPurDiscountAmount.Clear()
            txtPurAddDiscountAmount.Clear()
            CMBPURADDSUB.SelectedIndex = 0
            CMBPUROTHERCHGS.Text = ""
            TXTPUROTHERCHGS.Text = 0.0
            TXTPURROUNDOFF.Text = 0.0
            TXTPURGTOTAL.Text = 0.0
            TXTFINALPURAMT.Text = 0.0

            TXTTOTALSALEAMT.Text = 0.0
            TXTOURCOMMPER.Text = 0.0
            TXTOURCOMMRS.Text = 0.0
            TXTDISCPER.Text = 0.0
            TXTDISCRS.Text = 0.0
            TXTEXTRACHGS.Text = 0.0
            TXTSUBTOTAL.Text = 0.0

            'WE DONT KNOW THE EXACT TAX
            'If FRMSTRING = "DOMESTIC" Then cmbtax.Text = "S.T. 0.7%" Else cmbtax.Text = "S.T. 1.4%"

            txttax.Text = 0.0
            txttax.ReadOnly = True
            txttax.Enabled = False

            CMBADDTAX.Text = ""
            TXTADDTAX.Text = 0.0
            txtDiscountPerc.Clear()
            txtDiscountAmount.Clear()
            TXTSALETDSPER.Clear()
            TXTSALETDSRS.Clear()
            txtAddDiscountAmount.Clear()
            cmbaddsub.SelectedIndex = 0
            CMBOTHERCHGS.Text = ""
            txtotherchg.Text = 0.0
            txtroundoff.Text = 0.0
            txtgrandtotal.Text = 0.0
            TXTBAL.Text = 0.0

            CMBBOOKEDBY.Text = ""
            CMBSOURCE.Text = ""
            txtremarks.Clear()
            txtinwords.Clear()

            PBSoftCopy.ImageLocation = ""
            txtuploadsrno.Clear()
            txtuploadname.Clear()
            txtuploadremarks.Clear()
            TXTFILENAME.Clear()
            TXTNEWIMGPATH.Clear()
            txtimgpath.Clear()
            gridupload.RowCount = 0

            chkdispute.CheckState = CheckState.Unchecked
            CHKBILLCHECK.CheckState = CheckState.Unchecked
            CHKREFUNDED.CheckState = CheckState.Unchecked
            CHKFAILED.CheckState = CheckState.Unchecked

            CHKREVERSE.CheckState = CheckState.Unchecked
            CHKPURTAXONCOMM.Checked = False
            TXTENQNO.Clear()

            If UserName = "Admin" Or ClientName = "KHANNA" Then
                If ClientName = "JAIN" Then
                    CMBBOOKEDBY.Text = "Admin"
                End If
                CMBBOOKEDBY.Enabled = True
            Else
                CMBBOOKEDBY.Enabled = False
                CMBBOOKEDBY.Text = UserName
            End If

            EP.Clear()
            gridstocks.RowCount = 0
            grpstock.Visible = False
            gridDoubleClick = False
            gridFLIGHTDoubleClick = False

            getmax_BOOKING_no()
            If ClientName <> "MAYUR" Then
                CHKTAXPRINT.Checked = True
                CHKOTHERCHGSPRINT.Checked = True
                CHKADDDISC.Checked = True
            Else
                CHKTAXPRINT.Checked = False
                CHKOTHERCHGSPRINT.Checked = False
                CHKADDDISC.Checked = False
            End If

            If GRIDBOOKINGS.RowCount > 0 Then
                txtsrno.Text = Val(GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(GSRNO.Index).Value) + 1
            Else
                txtsrno.Text = 1
            End If

            'EINVOICE
            TXTIRNNO.Clear()
            TXTACKNO.Clear()
            ACKDATE.Value = Now.Date
            PBQRCODE.Image = Nothing

            TXTHSNCODE.Clear()
            TXTPURHSNCODE.Clear()

            TXTSTATECODE.Clear()
            TXTPURSTATECODE.Clear()
            'CMBHSNITEMDESC.SelectedIndex = 0
            TXTCGSTPER.Text = 0.0
            TXTCGSTAMT.Text = 0.0
            TXTSGSTPER.Text = 0.0
            TXTSGSTAMT.Text = 0.0
            TXTIGSTPER.Text = 0.0
            TXTIGSTAMT.Text = 0.0
            TXTCESSPER.Text = 1
            TXTCESSAMT.Text = 0.0
            TXTPURCGSTPER.Text = 0.0
            TXTPURCGSTAMT.Text = 0.0
            TXTPURSGSTPER.Text = 0.0
            TXTPURSGSTAMT.Text = 0.0
            TXTPURIGSTPER.Text = 0.0
            TXTPURIGSTAMT.Text = 0.0
            TXTPURCESSPER.Text = 1
            TXTPURCESSAMT.Text = 0.0
            TXTPURSERVCHGS.Text = 0.0
            'CHKPURTAXSERVCHGS.CheckState = CheckState.Unchecked

            CHKMANUAL.CheckState = CheckState.Unchecked
            CHKPURMANUAL.CheckState = CheckState.Unchecked

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        clear()
        edit = False
        BOOKINGDATE.Focus()
    End Sub

    Private Sub AirlineBookings_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
                Dim OBJINVDTLS As New AirlineBookingDetails
                OBJINVDTLS.MdiParent = MDIMain
                OBJINVDTLS.Show()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub AirlineBookings_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If AscW(e.KeyChar) <> 33 Then chkchange.CheckState = CheckState.Checked
    End Sub

    Sub fillcmb()
        Try
            If CMBCRSTYPE.Text.Trim = "" Then FILLCRS(CMBCRSTYPE)
            If CMBAIRNAME.Text.Trim = "" Then FILLAIRLINE(CMBAIRNAME, edit, "")
            If CMBAIRCODE.Text.Trim = "" Then FILLAIRCODE(CMBAIRCODE, "")
            If CMBPURNAME.Text.Trim = "" Then fillname(CMBPURNAME, edit, " And GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
            If CMBPURCODE.Text.Trim = "" Then fillACCCODE(CMBPURCODE, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'")
            If CMBHSNITEMDESC.Text.Trim = "" Then FILLHSNITEMDESC(CMBHSNITEMDESC)

            If CMBACCCODE.Text.Trim = "" Then fillACCCODE(CMBACCCODE, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'")
            If CMBSOURCE.Text.Trim = "" Then FILLSOURCE(CMBSOURCE, edit)
            If CMBBOOKEDBY.Text.Trim = "" Then FILLBOOKEDBY(CMBBOOKEDBY, edit)
            If cmbtax.Text.Trim = "" Then filltax(cmbtax, edit)
            If CMBPURTAX.Text.Trim = "" Then filltax(CMBPURTAX, edit)
            If CMBGROUPDEPARTURE.Text.Trim = "" Then FILLGROUPNAME(CMBGROUPDEPARTURE, " AND GROUPDEP_FROM > '" & Format(Convert.ToDateTime(BOOKINGDATE.Text).Date, "MM/dd/yyyy") & "'")

            If ClientName = "CLASSIC" Then
                If CMBOTHERCHGS.Text.Trim = "" Then fillname(CMBOTHERCHGS, edit, " AND GROUP_SECONDARY = 'INDIRECT EXPENSES' AND (ACC_CMPNAME = 'Discount' OR ACC_CMPNAME = 'Round Off')")
                If CMBPUROTHERCHGS.Text.Trim = "" Then fillname(CMBPUROTHERCHGS, edit, " AND (ACC_CMPNAME = 'Discount' OR ACC_CMPNAME = 'Round Off')")
            Else
                If CMBOTHERCHGS.Text.Trim = "" Then fillname(CMBOTHERCHGS, edit, " AND (GROUP_SECONDARY = 'INDIRECT EXPENSES' OR GROUP_SECONDARY = 'INDIRECT INCOME' OR GROUP_SECONDARY = 'DIRECT EXPENSES' OR GROUP_SECONDARY = 'DIRECT INCOME')")
                If CMBPUROTHERCHGS.Text.Trim = "" Then fillname(CMBPUROTHERCHGS, edit, " AND (GROUP_SECONDARY = 'INDIRECT EXPENSES' OR GROUP_SECONDARY = 'INDIRECT INCOME' OR GROUP_SECONDARY = 'DIRECT EXPENSES' OR GROUP_SECONDARY = 'DIRECT INCOME')")
            End If

            If FRMSTRING = "DOMESTIC" Then
                cmbregister.Text = "AIRLINE SALE REGISTER"
            Else
                cmbregister.Text = "INTAIRLINE SALE REGISTER"
            End If

            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" register_abbr, register_initials, register_id ", "", " RegisterMaster ", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'SALE' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
            If dt.Rows.Count > 0 Then

                SALEregabbr = dt.Rows(0).Item(0).ToString
                SALEreginitial = dt.Rows(0).Item(1).ToString
                SALEregid = dt.Rows(0).Item(2)
                cmbregister.Enabled = False
            End If

            If CMBHSNITEMDESC.Text.Trim = "" Then FILLHSNITEMDESC(CMBHSNITEMDESC)
            If CMBPURHSNITEMDESC.Text.Trim = "" Then FILLHSNITEMDESC(CMBPURHSNITEMDESC)

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub AirlineBookings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            'edit = True
            'Dim OBJCMN_auto As New ClsCommon
            'Dim dt_auto As DataTable = OBJCMN_auto.search(" AIRLINEBOOKINGMASTER.booking_no as BOOKING_NO, AIRLINEBOOKINGMASTER.BOOKING_SALEREGISTERID AS BOOKING_SALEREGISTERID  ", "", " AIRLINEBOOKINGMASTER  ", "  AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = " & CmpId & " AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID  = " & Locationid & " AND AIRLINEBOOKINGMASTER.BOOKING_YEARID = " & YearId)
            'If dt_auto.Rows.Count > 0 Then
            '    For Each dr_auto As DataRow In dt_auto.Rows

            ' edit = True
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'AIRLINE RESERVATION'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)
            'SALEregid = dr_auto("BOOKING_SALEREGISTERID")
            'If SALEregid = 13 Then
            '    FRMSTRING = "DOMESTIC"
            'Else
            '    FRMSTRING = "INTERNATIONAL"
            'End If


            If FRMSTRING = "DOMESTIC" Then
                Me.Text = "Domestic Airlines Booking"
            Else
                Me.Text = "Internation Airlines Booking"
            End If

            'RECOMMENDED BY ASHOK BHAI
            If UserName <> "Admin" Then LBLPURBAL.Visible = False
            If ClientName = "SEASONED" Then txttax.Enabled = True

            If ClientName = "UNIGO" Or ClientName = "TRAVELBRIDGE" Or (ClientName = "CLASSIC" And UserName = "Admin") Or ClientName = "UTTARAKHAND" Or ClientName = "GLOBE" Then
                txtbookingno.ReadOnly = False
            End If



            BOOKINGDATE.Text = Mydate
            Cursor.Current = Cursors.WaitCursor
            fillcmb()
            clear()



            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim ALPARAVAL As New ArrayList
                Dim OBJBOOKING As New ClsAirlineBookingMaster()
                'TEMPBOOKINGNO = dr_auto("BOOKING_NO")
                'SALEregid = dr_auto("BOOKING_SALEREGISTERID")
                ALPARAVAL.Add(TEMPBOOKINGNO)
                ALPARAVAL.Add(SALEregid)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                OBJBOOKING.alParaval = ALPARAVAL
                Dim dt As DataTable = OBJBOOKING.SELECTBOOKING()


                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows

                        txtbookingno.ReadOnly = True
                        txtbookingno.Enabled = False

                        txtbookingno.Text = TEMPBOOKINGNO
                        TXTENQNO.Text = dr("ENQNO")
                        TXTSTATECODE.Text = dr("STATECODE")
                        TXTPURSTATECODE.Text = dr("PURSTATECODE")
                        TEMPBOOKINGINITIALS = dr("SALEBILLINITIALS")
                        BOOKINGDATE.Text = Format(Convert.ToDateTime(dr("BOOKINGDATE")), "dd/MM/yyyy")
                        DDATE = BOOKINGDATE.Text
                        CMBCRSTYPE.Text = Convert.ToString(dr("CRSTYPE"))
                        'CMBBSP.Text = dr("BSPSALE")

                        If dr("BSPSALE") = True Then
                            CMBBSP.Text = "Yes"
                        Else
                            CMBBSP.Text = "No"
                        End If

                        If dr("COUPONSALE") = True Then
                            CMBCOUPON.Text = "Yes"
                        Else
                            CMBCOUPON.Text = "No"
                        End If

                        CMBAIRCODE.Text = Convert.ToString(dr("AIRCODE"))
                        CMBAIRNAME.Text = Convert.ToString(dr("AIRNAME"))
                        CMBPURCODE.Text = Convert.ToString(dr("PURCODE"))
                        CMBPURNAME.Text = Convert.ToString(dr("PURNAME"))
                        CMBACCCODE.Text = Convert.ToString(dr("ACCCODE"))
                        CMBNAME.Text = Convert.ToString(dr("ACCNAME"))

                        TICKETDATE.Value = Convert.ToDateTime(dr("TICKETDATE"))
                        TXTPARTYREFNO.Text = dr("PARTYREFNO")
                        TXTREFNO.Text = dr("REFNO")
                        TXTPRINTNAME.Text = dr("PRINTNAME")


                        DEPARTDATE.Value = Convert.ToDateTime(dr("DEPARTURE"))
                        ARRIVALDATE.Value = Convert.ToDateTime(dr("ARRIVAL"))
                        TXTFROM.Text = dr("FROM")
                        TXTTO.Text = dr("TO")

                        TXTEMAILADD.Text = dr("EMAILADD")
                        TXTMOBILE.Text = dr("MOBILENO")
                        TXTPNRNO.Text = dr("PNRNO")
                        TXTAIRLINEPNR.Text = dr("AIRLINEPNR")
                        TXTCRSPNR.Text = dr("CRSPNR")


                        'PURCHASE VALUES
                        TXTPURAMT.Text = dr("PURAMT")
                        TXTDISCRECDPER.Text = dr("DISCRECDPER")
                        TXTDISCRECDRS.Text = dr("DISCRECDRS")
                        TXTCOMMRECDPER.Text = dr("COMMRECDPER")
                        TXTCOMMRECDRS.Text = dr("COMMRECDRS")
                        TXTPURTDSPER.Text = dr("PURTDSPER")
                        TXTPURTDSRS.Text = dr("PURTDSRS")
                        TXTPUREXTRACHGS.Text = dr("PUREXTRACHGS")
                        CMBPURTAX.Text = dr("PURTAXNAME")
                        TXTPURTAX.Text = dr("PURTAX")

                        If CMBPURTAX.Text.Trim <> "" Then
                            Dim OBJCMNN As New ClsCommon
                            Dim DTN As DataTable = OBJCMNN.search(" TAX_TAX AS TAX ", "", " TAXMASTER ", " AND TAX_NAME = '" & CMBPURTAX.Text.Trim & "' AND TAX_CMPID = " & CmpId & " AND TAX_LOCATIONID = " & Locationid & " AND TAX_YEARID  =  " & YearId)
                            If DTN.Rows.Count > 0 Then
                                If Val(DTN.Rows(0).Item("TAX")) = 0 Then
                                    TXTPURTAX.ReadOnly = False
                                    TXTPURTAX.Enabled = True
                                End If
                            End If
                        End If

                        CMBPURADDTAX.Text = dr("PURADDTAXNAME")
                        TXTPURADDTAX.Text = dr("PURADDTAX")
                        txtPurDiscountPerc.Text = dr("PURDISCPERC")
                        txtPurDiscountAmount.Text = Format(dr("PURDISCAMT"), "0.00")
                        txtPurAddDiscountAmount.Text = Format(dr("PURADDDISCAMT"), "0.00")
                        CMBPUROTHERCHGS.Text = dr("PUROTHERCHGSNAME")

                        If Convert.ToBoolean(dr("PURCOMMTAX")) = True Then
                            CHKPURTAXONCOMM.Checked = True
                        Else
                            CHKPURTAXONCOMM.Checked = False
                        End If


                        If dr("PUROTHERCHGS") > 0 Then
                            TXTPUROTHERCHGS.Text = dr("PUROTHERCHGS")
                            CMBPURADDSUB.Text = "Add"
                        Else
                            TXTPUROTHERCHGS.Text = dr("PUROTHERCHGS") * (-1)
                            CMBPURADDSUB.Text = "Sub."
                        End If
                        TXTPURROUNDOFF.Text = dr("PURROUNDOFF")


                        CMBBOOKEDBY.Text = dr("BOOKEDBY")
                        CMBSOURCE.Text = dr("SOURCE")


                        'SALE VALUES
                        TXTTOTALSALEAMT.Text = dr("TOTALSALEAMT")
                        TXTOURCOMMPER.Text = dr("OURCOMMPER")
                        TXTOURCOMMRS.Text = dr("OURCOMMRS")
                        TXTDISCPER.Text = dr("DISCPER")
                        TXTDISCRS.Text = dr("DISCRS")
                        TXTSALETDSPER.Text = dr("SALETDSPER")
                        TXTSALETDSRS.Text = dr("SALETDSRS")
                        TXTEXTRACHGS.Text = dr("EXTRACHGS")
                        cmbtax.Text = dr("TAXNAME")
                        txttax.Text = dr("TAXAMT")

                        If cmbtax.Text.Trim <> "" Then
                            Dim OBJCMNN As New ClsCommon
                            Dim DTN As DataTable = OBJCMNN.search(" TAX_TAX AS TAX ", "", " TAXMASTER ", " AND TAX_NAME = '" & cmbtax.Text.Trim & "' AND TAX_CMPID = " & CmpId & " AND TAX_LOCATIONID = " & Locationid & " AND TAX_YEARID  =  " & YearId)
                            If DTN.Rows.Count > 0 Then
                                If Val(DTN.Rows(0).Item("TAX")) = 0 Then
                                    txttax.ReadOnly = False
                                    txttax.Enabled = True
                                End If
                            End If
                        End If

                        CMBADDTAX.Text = dr("ADDTAXNAME")
                        TXTADDTAX.Text = dr("ADDTAXAMT")
                        txtDiscountPerc.Text = dr("SALEDISCPERC")
                        txtDiscountAmount.Text = Format(dr("SALEDISCAMT"), "0.00")
                        txtAddDiscountAmount.Text = Format(dr("SALEADDDISCAMT"), "0.00")
                        CMBOTHERCHGS.Text = dr("OTHERCHGSNAME")
                        If dr("OTHERCHGS") > 0 Then
                            txtotherchg.Text = dr("OTHERCHGS")
                            cmbaddsub.Text = "Add"
                        Else
                            txtotherchg.Text = dr("OTHERCHGS") * (-1)
                            cmbaddsub.Text = "Sub."
                        End If
                        txtroundoff.Text = dr("ROUNDOFF")


                        txtremarks.Text = Convert.ToString(dr("REMARKS"))


                        TXTPURAMTPAID.Text = dr("PURAMTPAID")
                        TXTPUREXTRAAMT.Text = dr("PUREXTRAAMT")
                        TXTPURRETURN.Text = dr("PURRETURN")
                        TXTPURBAL.Text = dr("PURBAL")

                        TXTSALEAMTREC.Text = dr("SALEAMTREC")
                        TXTSALEEXTRAAMT.Text = dr("SALEEXTRAAMT")
                        TXTSALERETURN.Text = dr("SALERETURN")
                        TXTSALEBAL.Text = dr("SALEBAL")

                        TXTBAL.Text = Format(Val(TXTSALEBAL.Text), "0.00")

                        If Convert.ToBoolean(dr("COMMINVRAISED")) = True Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                        If Val(dr("PURAMTPAID")) > 0 Or Val(dr("PUREXTRAAMT")) > 0 Then
                            cmdshowdetails.Visible = True
                            PBPAID.Visible = True
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                        If Val(dr("PURRETURN")) > 0 Then
                            cmdshowdetails.Visible = True
                            PBDN.Visible = True
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If


                        If Val(dr("SALEAMTREC")) > 0 Or Val(dr("SALEEXTRAAMT")) > 0 Then
                            PBRECD.Visible = True
                            cmdshowdetails.Visible = True
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                        If Convert.ToBoolean(dr("GRIDCANCELLED")) = True Then
                            cmdshowdetails.Visible = True
                            PBCN.Visible = True
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                        If dr("DONE").ToString = True Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If


                        If Convert.ToBoolean(dr("CANCELLED")) = True Then
                            lblcancelled.Visible = True
                            PBCancelled.Visible = True
                        End If

                        chkdispute.Checked = Convert.ToBoolean(dr("DISPUTE"))
                        CHKBILLCHECK.Checked = Convert.ToBoolean(dr("BILLCHECKED"))
                        CHKREFUNDED.Checked = Convert.ToBoolean(dr("REFUNDED"))
                        CHKFAILED.Checked = Convert.ToBoolean(dr("FAILED"))

                        TXTHSNCODE.Text = dr("HSNCODE")
                        TXTPURHSNCODE.Text = dr("PURHSNCODE")

                        If Convert.ToBoolean(dr("MANUALGST")) = False Then CHKMANUAL.Checked = False Else CHKMANUAL.Checked = True
                        If CHKMANUAL.Checked = True Then
                            TXTCGSTAMT.Text = Format(Val(dr("CGSTAMT")), "0.00")
                            TXTSGSTAMT.Text = Format(Val(dr("SGSTAMT")), "0.00")
                            TXTIGSTAMT.Text = Format(Val(dr("IGSTAMT")), "0.00")

                        End If
                        If Convert.ToBoolean(dr("PURMANUALGST")) = False Then CHKPURMANUAL.Checked = False Else CHKPURMANUAL.Checked = True

                        If CHKPURMANUAL.Checked = True Then
                            TXTPURCGSTAMT.Text = Format(Val(dr("PURCGSTAMT")), 0.0)
                            TXTPURSGSTAMT.Text = Format(Val(dr("PURSGSTAMT")), 0.0)
                            TXTPURIGSTAMT.Text = Format(Val(dr("PURIGSTAMT")), 0.0)
                        End If

                        CMBHSNITEMDESC.Text = dr("HSNITEMDESC")
                        CMBPURHSNITEMDESC.Text = dr("PURHSNITEMDESC")

                        TXTCGSTPER.Text = dr("CGSTPER")
                        TXTCGSTAMT.Text = dr("CGSTAMT")
                        TXTSGSTPER.Text = dr("SGSTPER")
                        TXTSGSTAMT.Text = dr("SGSTAMT")
                        TXTIGSTPER.Text = dr("IGSTPER")
                        TXTIGSTAMT.Text = dr("IGSTAMT")
                        TXTCESSPER.Text = dr("CESSPER")
                        TXTCESSAMT.Text = dr("CESSAMT")
                        TXTPURSERVCHGS.Text = dr("PURTAXSERVCHGSAMT")
                        CHKPURTAXSERVCHGS.Checked = Convert.ToBoolean(dr("PURTAXSERVCHGS"))
                        TXTPURCGSTPER.Text = dr("PURCGSTPER")
                        TXTPURCGSTAMT.Text = dr("PURCGSTAMT")
                        TXTPURSGSTPER.Text = dr("PURSGSTPER")
                        TXTPURSGSTAMT.Text = dr("PURSGSTAMT")
                        TXTPURIGSTPER.Text = dr("PURIGSTPER")
                        TXTPURIGSTAMT.Text = dr("PURIGSTAMT")
                        TXTPURCESSPER.Text = dr("PURCESSPER")
                        TXTPURCESSAMT.Text = dr("PURCESSAMT")
                        CHKTAXSERVCHGS.Checked = Convert.ToBoolean(dr("TAXSERVCHGS"))
                        CMBGROUPDEPARTURE.Text = dr("TOURNAME")
                        'CMBGROUPDEPARTURE.Text = Convert.ToString(dr("GROUPNAME"))
                        'CMBGROUPDEPARTURE.Enabled = False

                        'MsgBox(Convert.ToByte(dr("GRIDCANCELLED")))


                        TXTIRNNO.Text = dr("IRNNO")
                        TXTACKNO.Text = dr("ACKNO")
                        ACKDATE.Value = dr("ACKDATE")
                        If IsDBNull(dr("QRCODE")) = False Then
                            PBQRCODE.Image = Image.FromStream(New IO.MemoryStream(DirectCast(dr("QRCODE"), Byte())))
                        Else
                            PBQRCODE.Image = Nothing
                        End If
                        RETURNDATE.Value = Convert.ToDateTime(dr("RETURNDATE"))
                        GRIDBOOKINGS.Rows.Add(dr("GRIDSRNO").ToString, dr("PASSNAME").ToString, dr("SECTOR").ToString, dr("FLTNO"), dr("TYPE").ToString, dr("TICKETNO").ToString, dr("CLASS").ToString, Format(Val(dr("BASIC")), "0.00"), Format(Val(dr("PSF")), "0.00"), Format(Val(dr("GRIDTAXES")), "0.00"), Format(Val(dr("AMT")), "0.00"), Convert.ToByte(dr("GRIDCANCELLED")))
                        If Convert.ToBoolean(dr("GRIDCANCELLED")) = True Then GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow

                    Next

                    GRIDBOOKINGS.FirstDisplayedScrollingRowIndex = GRIDBOOKINGS.RowCount - 1


                    'GET GRIDPASS DATA
                    Dim OBJCMN As New ClsCommon
                    Dim dttable As DataTable = OBJCMN.search("  AIRLINEBOOKINGMASTER_PASSDESC.BOOKING_GRIDSRNO AS GRIDSRNO, AIRLINEBOOKINGMASTER_PASSDESC.BOOKING_PASSGRIDSRNO AS PASSGRIDSRNO, AIRLINEBOOKINGMASTER_PASSDESC.BOOKING_PASSNAME AS PASSNAME, AIRLINEBOOKINGMASTER_PASSDESC.BOOKING_DESC AS [DESC], AIRLINEBOOKINGMASTER_PASSDESC.BOOKING_TICKETNO AS TICKETNO, AIRLINEBOOKINGMASTER_PASSDESC.BOOKING_SEX AS SEX, AIRLINEBOOKINGMASTER_PASSDESC.BOOKING_PANNO AS PANNO, AIRLINEBOOKINGMASTER_PASSDESC.BOOKING_PASSPORTNO AS PASSPORTNO, AIRLINEBOOKINGMASTER_PASSDESC.BOOKING_ISSUEDFROM AS ISSUEDFROM ", "", " AIRLINEBOOKINGMASTER_PASSDESC INNER JOIN AIRLINEBOOKINGMASTER ON AIRLINEBOOKINGMASTER_PASSDESC.BOOKING_NO = AIRLINEBOOKINGMASTER.BOOKING_NO AND AIRLINEBOOKINGMASTER_PASSDESC.BOOKING_CMPID = AIRLINEBOOKINGMASTER.BOOKING_CMPID AND AIRLINEBOOKINGMASTER_PASSDESC.BOOKING_LOCATIONID = AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID AND AIRLINEBOOKINGMASTER_PASSDESC.BOOKING_YEARID = AIRLINEBOOKINGMASTER.BOOKING_YEARID AND AIRLINEBOOKINGMASTER_PASSDESC.BOOKING_SALEREGID = AIRLINEBOOKINGMASTER.BOOKING_SALEREGISTERID ", " AND AIRLINEBOOKINGMASTER.BOOKING_NO = " & TEMPBOOKINGNO & " AND AIRLINEBOOKINGMASTER.BOOKING_SALEREGISTERID = " & SALEregid & " AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = " & CmpId & " AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID  = " & Locationid & " AND AIRLINEBOOKINGMASTER.BOOKING_YEARID = " & YearId & " ORDER BY AIRLINEBOOKINGMASTER_PASSDESC.BOOKING_GRIDSRNO")
                    If dttable.Rows.Count > 0 Then
                        For Each DR As DataRow In dttable.Rows
                            GRIDPASS.Rows.Add(DR("GRIDSRNO").ToString, DR("PASSGRIDSRNO").ToString, DR("PASSNAME").ToString, DR("DESC").ToString, DR("TICKETNO"), DR("SEX"), DR("PANNO"), DR("PASSPORTNO"), DR("ISSUEDFROM"))
                        Next
                    End If



                    'GET GRIDPUR DATA
                    dttable = OBJCMN.search("  AIRLINEBOOKINGMASTER_PURDESC.BOOKING_GRIDSRNO AS GRIDSRNO, AIRLINEBOOKINGMASTER_PURDESC.BOOKING_PASSGRIDSRNO AS PASSGRIDSRNO, AIRLINEBOOKINGMASTER_PURDESC.BOOKING_PASSNAME AS PASSNAME, AIRLINEBOOKINGMASTER_PURDESC.BOOKING_TICKETNO AS TICKETNO, AIRLINEBOOKINGMASTER_PURDESC.BOOKING_BASIC AS BASIC, AIRLINEBOOKINGMASTER_PURDESC.BOOKING_PSF AS PSF, AIRLINEBOOKINGMASTER_PURDESC.BOOKING_TAXES AS TAXES, AIRLINEBOOKINGMASTER_PURDESC.BOOKING_AMT AS AMT, AIRLINEBOOKINGMASTER_PURDESC.BOOKING_CANCELLED AS CANCELLED ", "", " AIRLINEBOOKINGMASTER_PURDESC INNER JOIN AIRLINEBOOKINGMASTER ON AIRLINEBOOKINGMASTER_PURDESC.BOOKING_NO = AIRLINEBOOKINGMASTER.BOOKING_NO AND AIRLINEBOOKINGMASTER_PURDESC.BOOKING_CMPID = AIRLINEBOOKINGMASTER.BOOKING_CMPID AND AIRLINEBOOKINGMASTER_PURDESC.BOOKING_LOCATIONID = AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID AND AIRLINEBOOKINGMASTER_PURDESC.BOOKING_YEARID = AIRLINEBOOKINGMASTER.BOOKING_YEARID AND AIRLINEBOOKINGMASTER_PURDESC.BOOKING_SALEREGID = AIRLINEBOOKINGMASTER.BOOKING_SALEREGISTERID ", " AND AIRLINEBOOKINGMASTER.BOOKING_NO = " & TEMPBOOKINGNO & " AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = " & CmpId & " AND AIRLINEBOOKINGMASTER.BOOKING_SALEREGISTERID = " & SALEregid & " AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID  = " & Locationid & " AND AIRLINEBOOKINGMASTER.BOOKING_YEARID = " & YearId & " ORDER BY AIRLINEBOOKINGMASTER_PURDESC.BOOKING_GRIDSRNO")
                    If dttable.Rows.Count > 0 Then
                        For Each DR As DataRow In dttable.Rows
                            GRIDPUR.Rows.Add(DR("GRIDSRNO").ToString, DR("PASSGRIDSRNO").ToString, DR("PASSNAME").ToString, DR("TICKETNO").ToString, Format(Val(DR("BASIC")), "0.00"), Format(DR("PSF"), "0.00"), Format(DR("TAXES"), "0.00"), Format(DR("AMT"), "0.00"), Convert.ToByte(DR("CANCELLED")))
                            If Convert.ToBoolean(DR("CANCELLED")) = True Then
                                GRIDPUR.Rows(GRIDPUR.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                                GRIDPUR.Rows(GRIDPUR.RowCount - 1).ReadOnly = True
                            End If
                        Next
                    End If


                    'GET GRIDFLIGHT DATA
                    dttable = OBJCMN.search(" AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_GRIDSRNO AS GRIDSRNO, AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_BOOKSRNO AS BOOKSRNO, ISNULL(FROMSECTORMASTER.SECTOR_NAME,'') AS FROMSEC, ISNULL(TOSECTORMASTER.SECTOR_NAME,'') AS TOSEC, AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_FLIGHTNO AS FLIGHTNO,  AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_FLIGHTDATE AS FLIGHTDATE,ISNULL(AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_ARRIVES,'') AS ARRIVES, CLASSMASTER.CLASS_NAME AS CLASS ", "", " SECTORMASTER AS TOSECTORMASTER RIGHT OUTER JOIN AIRLINEBOOKINGMASTER_FLIGHTDESC LEFT OUTER JOIN CLASSMASTER ON AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_YEARID = CLASSMASTER.CLASS_YEARID AND  AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_LOCATIONID = CLASSMASTER.CLASS_LOCATIONID AND AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_CMPID = CLASSMASTER.CLASS_CMPID AND AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_CLASSID = CLASSMASTER.CLASS_ID ON TOSECTORMASTER.SECTOR_ID = AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_TOID AND TOSECTORMASTER.SECTOR_CMPID = AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_CMPID AND TOSECTORMASTER.SECTOR_LOCATIONID = AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_LOCATIONID AND TOSECTORMASTER.SECTOR_YEARID = AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_YEARID LEFT OUTER JOIN SECTORMASTER AS FROMSECTORMASTER ON AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_FROMID = FROMSECTORMASTER.SECTOR_ID AND AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_CMPID = FROMSECTORMASTER.SECTOR_CMPID AND AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_LOCATIONID = FROMSECTORMASTER.SECTOR_LOCATIONID AND AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_YEARID = FROMSECTORMASTER.SECTOR_YEARID ", " AND AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_NO = " & TEMPBOOKINGNO & " AND AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_SALEREGID = " & SALEregid & " AND AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_CMPID = " & CmpId & " AND AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_LOCATIONID  = " & Locationid & " AND AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_YEARID = " & YearId & " ORDER BY AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_BOOKSRNO ASC, AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_GRIDSRNO ASC")
                    If dttable.Rows.Count > 0 Then
                        For Each DR As DataRow In dttable.Rows
                            GRIDFLIGHT.Rows.Add(DR("GRIDSRNO").ToString, DR("BOOKSRNO"), DR("FROMSEC").ToString, DR("TOSEC").ToString, DR("FLIGHTNO").ToString, DR("FLIGHTDATE").ToString, DR("ARRIVES").ToString, DR("CLASS").ToString)
                            'GRIDFLIGHT.Rows.Add(DR("GRIDSRNO").ToString, DR("BOOKSRNO"), DR("FROMSEC").ToString, DR("TOSEC").ToString, DR("FLIGHTNO").ToString, Format(Convert.ToDateTime(DR("FLIGHTDATE")).Date, "dd/MM/yyyy"), DR("ARRIVES").ToString, DR("CLASS").ToString)

                        Next
                    End If
                    'GRIDFLIGHT.Visible = True
                    'GRIDFLIGHT.BringToFront()
                    'GET SCAN DOCS DATA

                    ' Dim OBJCMN As New ClsCommon
                    dttable = OBJCMN.search(" AIRLINEBOOKINGMASTER_UPLOAD.BOOKING_GRIDSRNO AS GRIDSRNO, AIRLINEBOOKINGMASTER_UPLOAD.BOOKING_REMARKS AS REMARKS, AIRLINEBOOKINGMASTER_UPLOAD.BOOKING_NAME AS NAME, AIRLINEBOOKINGMASTER_UPLOAD.BOOKING_IMGPATH AS IMGPATH, AIRLINEBOOKINGMASTER_UPLOAD.BOOKING_NEWIMGPATH AS NEWIMGPATH", "", " AIRLINEBOOKINGMASTER_UPLOAD INNER JOIN AIRLINEBOOKINGMASTER ON AIRLINEBOOKINGMASTER_UPLOAD.BOOKING_NO = AIRLINEBOOKINGMASTER.BOOKING_NO AND AIRLINEBOOKINGMASTER_UPLOAD.BOOKING_CMPID = AIRLINEBOOKINGMASTER.BOOKING_CMPID AND AIRLINEBOOKINGMASTER_UPLOAD.BOOKING_LOCATIONID = AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID AND AIRLINEBOOKINGMASTER_UPLOAD.BOOKING_YEARID = AIRLINEBOOKINGMASTER.BOOKING_YEARID AND AIRLINEBOOKINGMASTER_UPLOAD.BOOKING_SALEREGID = AIRLINEBOOKINGMASTER.BOOKING_SALEREGISTERID ", " AND AIRLINEBOOKINGMASTER.BOOKING_NO = " & TEMPBOOKINGNO & " AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = " & CmpId & " AND AIRLINEBOOKINGMASTER.BOOKING_SALEREGISTERID = " & SALEregid & " AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID  = " & Locationid & " AND AIRLINEBOOKINGMASTER.BOOKING_YEARID = " & YearId & " ORDER BY AIRLINEBOOKINGMASTER_UPLOAD.BOOKING_GRIDSRNO")
                    If dttable.Rows.Count > 0 Then
                        For Each DTR2 As DataRow In dttable.Rows
                            gridupload.Rows.Add(DTR2("GRIDSRNO"), DTR2("REMARKS"), DTR2("NAME"), DTR2("IMGPATH"), DTR2("NEWIMGPATH"))
                        Next
                    End If

                    'dttable = OBJCMN.search(" AIRLINEBOOKINGMASTER_UPLOAD.BOOKING_GRIDSRNO AS GRIDSRNO, AIRLINEBOOKINGMASTER_UPLOAD.BOOKING_REMARKS AS REMARKS, AIRLINEBOOKINGMASTER_UPLOAD.BOOKING_NAME AS NAME, AIRLINEBOOKINGMASTER_UPLOAD.BOOKING_IMGPATH AS IMGPATH, AIRLINEBOOKINGMASTER_UPLOAD.BOOKING_NEWIMGPATH AS NEWIMGPATH ", "", " AIRLINEBOOKINGMASTER_UPLOAD INNER JOIN AIRLINEBOOKINGMASTER ON AIRLINEBOOKINGMASTER_UPLOAD.BOOKING_NO = AIRLINEBOOKINGMASTER.BOOKING_NO AND AIRLINEBOOKINGMASTER_UPLOAD.BOOKING_CMPID = AIRLINEBOOKINGMASTER.BOOKING_CMPID AND AIRLINEBOOKINGMASTER_UPLOAD.BOOKING_LOCATIONID = AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID AND AIRLINEBOOKINGMASTER_UPLOAD.BOOKING_YEARID = AIRLINEBOOKINGMASTER.BOOKING_YEARID AND AIRLINEBOOKINGMASTER_UPLOAD.BOOKING_SALEREGID = AIRLINEBOOKINGMASTER.BOOKING_SALEREGISTERID ", " AND AIRLINEBOOKINGMASTER.BOOKING_NO = " & TEMPBOOKINGNO & " AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = " & CmpId & " AND AIRLINEBOOKINGMASTER.BOOKING_SALEREGISTERID = " & SALEregid & " AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID  = " & Locationid & " AND AIRLINEBOOKINGMASTER.BOOKING_YEARID = " & YearId & " ORDER BY AIRLINEBOOKINGMASTER_UPLOAD.BOOKING_GRIDSRNO")
                    'If dttable.Rows.Count > 0 Then
                    '    For Each DTR As DataRow In dttable.Rows
                    '        gridupload.Rows.Add(DTR("GRIDSRNO"), DTR("REMARKS"), DTR("NAME"), DTR("IMGPATH"), DTR("NEWIMGPATH"))
                    '    Next
                    'End If

                    PURCHASETOTAL()
                    'cmdok_Click(sender, e)
                Else
                    clear()
                    edit = False
                    CMBAIRNAME.Focus()
                End If
                chkchange.CheckState = CheckState.Checked
            End If
            ' Next
            ' End If

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

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            If FRMSTRING = "INTERNATIONAL" Then
                alParaval.Add("INTAIRLINE PURCHASE REGISTER")
                alParaval.Add("INTAIRLINE SALE REGISTER")
            Else
                alParaval.Add("AIRLINE PURCHASE REGISTER")
                alParaval.Add("AIRLINE SALE REGISTER")
            End If

            If ClientName = "PLANET" Or (ClientName = "CLASSIC" And UserName = "Admin") Or ClientName = "BARODA" Or ClientName = "SKYMAPS" Or ClientName = "GLOBE" Or ClientName = "MILONI" Or ClientName = "NAMASTE" Then
                alParaval.Add(txtbookingno.Text.Trim)
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(Format(Convert.ToDateTime(BOOKINGDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CMBCRSTYPE.Text.Trim)

            If CMBBSP.Text = "Yes" Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)
            End If
            If CMBCOUPON.Text = "Yes" Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(CMBAIRNAME.Text.Trim)
            alParaval.Add(CMBPURNAME.Text.Trim)
            alParaval.Add(CMBNAME.Text.Trim)

            alParaval.Add(TICKETDATE.Value.Date.Date)
            alParaval.Add(TXTPARTYREFNO.Text.Trim)
            alParaval.Add(TXTREFNO.Text.Trim)

            'PRINT NAME
            alParaval.Add(TXTPRINTNAME.Text.Trim)
            alParaval.Add(DEPARTDATE.Value)
            alParaval.Add(ARRIVALDATE.Value)

            Dim SPAN As TimeSpan = ARRIVALDATE.Value.Subtract(DEPARTDATE.Value)
            alParaval.Add(SPAN)
            alParaval.Add(TXTFROM.Text.Trim)
            alParaval.Add(TXTTO.Text.Trim)

            alParaval.Add(TXTEMAILADD.Text.Trim)
            alParaval.Add(TXTMOBILE.Text.Trim)

            alParaval.Add(TXTPNRNO.Text.Trim)
            alParaval.Add(TXTAIRLINEPNR.Text.Trim)
            alParaval.Add(TXTCRSPNR.Text.Trim)

            alParaval.Add(Val(TXTTOTALBASIC.Text.Trim))
            alParaval.Add(Val(TXTTOTALPSF.Text.Trim))
            alParaval.Add(Val(TXTTOTALTAXES.Text.Trim))
            alParaval.Add(Val(TXTTOTALAMT.Text.Trim))

            alParaval.Add(Val(TXTTOTALPURBASIC.Text.Trim))
            alParaval.Add(Val(TXTTOTALPURPSF.Text.Trim))
            alParaval.Add(Val(TXTTOTALPURTAX.Text.Trim))

            'PURCHASE VALUES
            alParaval.Add(Val(TXTPURAMT.Text.Trim))
            alParaval.Add(Val(TXTTOTALPURAMT.Text.Trim))
            alParaval.Add(Val(TXTDISCRECDPER.Text.Trim))
            alParaval.Add(Val(TXTDISCRECDRS.Text.Trim))
            alParaval.Add(Val(TXTPURSUBTOTAL.Text.Trim))
            alParaval.Add(Val(TXTCOMMRECDPER.Text.Trim))
            alParaval.Add(Val(TXTCOMMRECDRS.Text.Trim))
            alParaval.Add(Val(TXTPURTDSPER.Text.Trim))
            alParaval.Add(Val(TXTPURTDSRS.Text.Trim))
            alParaval.Add(Val(TXTPUREXTRACHGS.Text.Trim))
            alParaval.Add(Val(TXTPURNETTAMT.Text.Trim))

            If CHKPURTAXONCOMM.Checked = True Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)
            End If


            alParaval.Add(CMBPURTAX.Text.Trim)
            alParaval.Add(Val(TXTPURTAX.Text.Trim))
            alParaval.Add(CMBPURADDTAX.Text.Trim)
            alParaval.Add(Val(TXTPURADDTAX.Text.Trim))
            'PURCHASE DISCOUNT PERC, AMOUNT AND OTHER DISCOUNT
            alParaval.Add(Val(txtPurDiscountPerc.Text.Trim))
            alParaval.Add(Val(txtPurDiscountAmount.Text.Trim))
            alParaval.Add(Val(txtPurAddDiscountAmount.Text.Trim))

            alParaval.Add(CMBPUROTHERCHGS.Text.Trim)
            If CMBPURADDSUB.Text.Trim = "Add" Then
                alParaval.Add(Val(TXTPUROTHERCHGS.Text.Trim))
            ElseIf CMBPURADDSUB.Text.Trim = "Sub." Then
                alParaval.Add(Val((TXTPUROTHERCHGS.Text.Trim) * (-1)))
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(Val(TXTPURROUNDOFF.Text.Trim))
            alParaval.Add(Val(TXTPURGTOTAL.Text.Trim))

            alParaval.Add(Val(TXTTOTALPAX.Text.Trim))
            alParaval.Add(CMBBOOKEDBY.Text.Trim)
            alParaval.Add(CMBSOURCE.Text.Trim)




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
            'SALE DISCOUNT PERC, AMOUNT AND OTHER DISCOUNT
            alParaval.Add(Val(txtDiscountPerc.Text.Trim))
            alParaval.Add(Val(txtDiscountAmount.Text.Trim))
            alParaval.Add(Val(TXTSALETDSPER.Text.Trim))
            alParaval.Add(Val(TXTSALETDSRS.Text.Trim))
            alParaval.Add(Val(txtAddDiscountAmount.Text.Trim))

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

            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(txtinwords.Text.Trim)



            alParaval.Add(Val(TXTPURAMTPAID.Text.Trim))
            alParaval.Add(Val(TXTPUREXTRAAMT.Text.Trim))
            alParaval.Add(Val(TXTPURRETURN.Text.Trim))
            alParaval.Add(Val(TXTPURBAL.Text.Trim))
            alParaval.Add(Val(TXTSALEAMTREC.Text.Trim))
            alParaval.Add(Val(TXTSALEEXTRAAMT.Text.Trim))
            alParaval.Add(Val(TXTSALERETURN.Text.Trim))
            alParaval.Add(Val(TXTSALEBAL.Text.Trim))

            'FOR DONE
            If lbllocked.Visible = True Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)
            End If


            alParaval.Add(chkdispute.CheckState)
            alParaval.Add(CHKBILLCHECK.CheckState)
            alParaval.Add(CHKREFUNDED.CheckState)
            alParaval.Add(CHKFAILED.CheckState)
            alParaval.Add(CHKTAXSERVCHGS.CheckState)
            alParaval.Add(CMBGROUPDEPARTURE.Text.Trim)
            alParaval.Add(TXTHSNCODE.Text.Trim)
            alParaval.Add(TXTPURHSNCODE.Text.Trim)
            alParaval.Add(CHKMANUAL.CheckState)
            alParaval.Add(CHKPURMANUAL.CheckState)
            alParaval.Add(TXTCGSTPER.Text.Trim)
            alParaval.Add(TXTCGSTAMT.Text.Trim)
            alParaval.Add(TXTSGSTPER.Text.Trim)
            alParaval.Add(TXTSGSTAMT.Text.Trim)
            alParaval.Add(TXTIGSTPER.Text.Trim)
            alParaval.Add(TXTIGSTAMT.Text.Trim)
            alParaval.Add(Val(TXTCESSPER.Text.Trim))
            alParaval.Add(Val(TXTCESSAMT.Text.Trim))
            alParaval.Add(CHKPURTAXSERVCHGS.CheckState)
            alParaval.Add(TXTPURSERVCHGS.Text.Trim)
            alParaval.Add(TXTPURCGSTPER.Text.Trim)
            alParaval.Add(TXTPURCGSTAMT.Text.Trim)
            alParaval.Add(TXTPURSGSTPER.Text.Trim)
            alParaval.Add(TXTPURSGSTAMT.Text.Trim)
            alParaval.Add(TXTPURIGSTPER.Text.Trim)
            alParaval.Add(TXTPURIGSTAMT.Text.Trim)
            alParaval.Add(Val(TXTPURCESSPER.Text.Trim))
            alParaval.Add(Val(TXTPURCESSAMT.Text.Trim))

            alParaval.Add(Val(TXTENQNO.Text.Trim))

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            'THIS VARIABLE IS JUST USED TO PASS THE GUESTNAME WITH NO OF PAX IN TOURNAME FIELD IN ACCMASTER TABLE
            'THIS WILL BE THEN FETCHED IN LEDGERBOOK, HENCE REDUCING THE DELAY TIME 
            alParaval.Add(GRIDBOOKINGS.Rows(0).Cells(GNAME.Index).Value & " * " & Val(GRIDBOOKINGS.RowCount))


            'BOOKING GRID
            Dim gridsrno As String = ""
            Dim PASSNAME As String = ""
            Dim SECTOR As String = ""
            Dim FLTNO As String = ""
            Dim TYPE As String = ""
            Dim TICKETNO As String = ""
            Dim CLASSNAME As String = ""
            Dim BASIC As String = ""
            Dim PSF As String = ""
            Dim TAXES As String = ""
            Dim AMT As String = ""
            Dim BCANCELLED As String = ""


            For Each row As Windows.Forms.DataGridViewRow In GRIDBOOKINGS.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(GSRNO.Index).Value.ToString
                        PASSNAME = row.Cells(GNAME.Index).Value.ToString
                        SECTOR = row.Cells(GSECTOR.Index).Value.ToString
                        FLTNO = row.Cells(GFLTNO.Index).Value.ToString
                        TYPE = row.Cells(GTYPE.Index).Value.ToString
                        TICKETNO = row.Cells(GTICKETNO.Index).Value.ToString
                        CLASSNAME = row.Cells(GBOOKCLASS.Index).Value.ToString
                        BASIC = row.Cells(GBASIC.Index).Value.ToString
                        PSF = row.Cells(GPSF.Index).Value.ToString
                        TAXES = row.Cells(GTAXES.Index).Value.ToString
                        AMT = row.Cells(GTOTAL.Index).Value
                        If row.Cells(GCANCELLED.Index).Value <> Nothing Then
                            BCANCELLED = Val(row.Cells(GCANCELLED.Index).Value)
                        Else
                            BCANCELLED = 0
                        End If
                    Else
                        gridsrno = gridsrno & "|" & row.Cells(GSRNO.Index).Value.ToString
                        PASSNAME = PASSNAME & "|" & row.Cells(GNAME.Index).Value.ToString
                        SECTOR = SECTOR & "|" & row.Cells(GSECTOR.Index).Value.ToString
                        FLTNO = FLTNO & "|" & row.Cells(GFLTNO.Index).Value.ToString
                        TYPE = TYPE & "|" & row.Cells(GTYPE.Index).Value.ToString
                        TICKETNO = TICKETNO & "|" & row.Cells(GTICKETNO.Index).Value.ToString
                        CLASSNAME = CLASSNAME & "|" & row.Cells(GBOOKCLASS.Index).Value.ToString
                        BASIC = BASIC & "|" & row.Cells(GBASIC.Index).Value.ToString
                        PSF = PSF & "|" & row.Cells(GPSF.Index).Value.ToString
                        TAXES = TAXES & "|" & row.Cells(GTAXES.Index).Value.ToString
                        AMT = AMT & "|" & row.Cells(GTOTAL.Index).Value

                        If row.Cells(GCANCELLED.Index).Value <> Nothing Then
                            BCANCELLED = BCANCELLED & "|" & Val(row.Cells(GCANCELLED.Index).Value)
                        Else
                            BCANCELLED = BCANCELLED & "|" & "0"
                        End If
                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(PASSNAME)
            alParaval.Add(SECTOR)
            alParaval.Add(FLTNO)
            alParaval.Add(TYPE)
            alParaval.Add(TICKETNO)
            alParaval.Add(CLASSNAME)
            alParaval.Add(BASIC)
            alParaval.Add(PSF)
            alParaval.Add(TAXES)
            alParaval.Add(AMT)
            alParaval.Add(BCANCELLED)


            'PASSENGER DETAIL GRID
            Dim PASSGRIDSRNO As String = ""
            Dim PASSBOOKGRIDSRNO As String = ""
            Dim PASSPASSNAME As String = ""
            Dim PASSDESC As String = ""
            Dim PASSTICKETNO As String = ""
            Dim SEX As String = ""
            Dim PANNO As String = ""
            Dim PASSPORT As String = ""
            Dim ISSUED As String = ""


            For Each row As Windows.Forms.DataGridViewRow In GRIDPASS.Rows
                If row.Cells(0).Value <> Nothing Then
                    If PASSGRIDSRNO = "" Then
                        PASSGRIDSRNO = row.Cells(GPASSSRNO.Index).Value.ToString
                        PASSBOOKGRIDSRNO = row.Cells(GPASSBOOKGRIDSRNO.Index).Value.ToString
                        PASSPASSNAME = row.Cells(GPASSNAME.Index).Value.ToString
                        PASSDESC = row.Cells(GPASSDESC.Index).Value.ToString
                        PASSTICKETNO = row.Cells(GPASSTICKETNO.Index).Value.ToString
                        SEX = row.Cells(GSEX.Index).Value.ToString
                        PANNO = row.Cells(GPANNO.Index).Value.ToString
                        PASSPORT = row.Cells(GPASSPORT.Index).Value.ToString
                        ISSUED = row.Cells(GISSUEDFROM.Index).Value
                    Else
                        PASSGRIDSRNO = PASSGRIDSRNO & "|" & row.Cells(GPASSSRNO.Index).Value.ToString
                        PASSBOOKGRIDSRNO = PASSBOOKGRIDSRNO & "|" & row.Cells(GPASSBOOKGRIDSRNO.Index).Value.ToString
                        PASSPASSNAME = PASSPASSNAME & "|" & row.Cells(GPASSNAME.Index).Value.ToString
                        PASSDESC = PASSDESC & "|" & row.Cells(GPASSDESC.Index).Value.ToString
                        PASSTICKETNO = PASSTICKETNO & "|" & row.Cells(GPASSTICKETNO.Index).Value.ToString
                        SEX = SEX & "|" & row.Cells(GSEX.Index).Value.ToString
                        PANNO = PANNO & "|" & row.Cells(GPANNO.Index).Value.ToString
                        PASSPORT = PASSPORT & "|" & row.Cells(GPASSPORT.Index).Value.ToString
                        ISSUED = ISSUED & "|" & row.Cells(GISSUEDFROM.Index).Value
                    End If
                End If
            Next

            alParaval.Add(PASSGRIDSRNO)
            alParaval.Add(PASSBOOKGRIDSRNO)
            alParaval.Add(PASSPASSNAME)
            alParaval.Add(PASSDESC)
            alParaval.Add(PASSTICKETNO)
            alParaval.Add(SEX)
            alParaval.Add(PANNO)
            alParaval.Add(PASSPORT)
            alParaval.Add(ISSUED)



            'PURCHASE GRID
            Dim PURGRIDSRNO As String = ""
            Dim PURBOOKGRIDSRNO As String = ""
            Dim PURPASSNAME As String = ""
            Dim PURTICKETNO As String = ""
            Dim PURBASIC As String = ""
            Dim PURPSF As String = ""
            Dim PURTAXES As String = ""
            Dim PURGRIDAMT As String = ""
            Dim PURCANCELLED As String = ""


            For Each row As Windows.Forms.DataGridViewRow In GRIDPUR.Rows
                If row.Cells(0).Value <> Nothing Then
                    If PURGRIDSRNO = "" Then
                        PURGRIDSRNO = row.Cells(GPURSRNO.Index).Value.ToString
                        PURBOOKGRIDSRNO = row.Cells(GPURPASSGRIDSRNO.Index).Value.ToString
                        PURPASSNAME = row.Cells(GPURPASSNAME.Index).Value.ToString
                        PURTICKETNO = row.Cells(GPURTICKETNO.Index).Value.ToString
                        PURBASIC = row.Cells(GPURBASIC.Index).Value.ToString
                        PURPSF = row.Cells(GPURPSF.Index).Value.ToString
                        PURTAXES = row.Cells(GPURTAXES.Index).Value.ToString
                        PURGRIDAMT = row.Cells(GPURTOTAL.Index).Value
                        If row.Cells(GPURCANCELLED.Index).Value <> Nothing Then
                            PURCANCELLED = Val(row.Cells(GPURCANCELLED.Index).Value)
                        Else
                            PURCANCELLED = 0
                        End If
                    Else
                        PURGRIDSRNO = PURGRIDSRNO & "|" & row.Cells(GPURSRNO.Index).Value.ToString
                        PURBOOKGRIDSRNO = PURBOOKGRIDSRNO & "|" & row.Cells(GPURPASSGRIDSRNO.Index).Value.ToString
                        PURPASSNAME = PURPASSNAME & "|" & row.Cells(GPURPASSNAME.Index).Value.ToString
                        PURTICKETNO = PURTICKETNO & "|" & row.Cells(GPURTICKETNO.Index).Value.ToString
                        PURBASIC = PURBASIC & "|" & row.Cells(GPURBASIC.Index).Value.ToString
                        PURPSF = PURPSF & "|" & row.Cells(GPURPSF.Index).Value.ToString
                        PURTAXES = PURTAXES & "|" & row.Cells(GPURTAXES.Index).Value.ToString
                        PURGRIDAMT = PURGRIDAMT & "|" & row.Cells(GPURTOTAL.Index).Value

                        If row.Cells(GPURCANCELLED.Index).Value <> Nothing Then
                            PURCANCELLED = PURCANCELLED & "|" & Val(row.Cells(GPURCANCELLED.Index).Value)
                        Else
                            PURCANCELLED = PURCANCELLED & "|" & "0"
                        End If


                    End If
                End If
            Next

            alParaval.Add(PURGRIDSRNO)
            alParaval.Add(PURBOOKGRIDSRNO)
            alParaval.Add(PURPASSNAME)
            alParaval.Add(PURTICKETNO)
            alParaval.Add(PURBASIC)
            alParaval.Add(PURPSF)
            alParaval.Add(PURTAXES)
            alParaval.Add(PURGRIDAMT)
            alParaval.Add(PURCANCELLED)



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
                If row.Cells(0).Value <> Nothing Then
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

            'UPLOAD GRID
            Dim griduploadsrno As String = ""
            Dim imgpath As String = ""
            Dim uploadremarks As String = ""
            Dim name As String = ""
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


            alParaval.Add(ClientName)

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
            'alParaval.Add(CMBGROUPDEPARTURE.Text.Trim)
            alParaval.Add(RETURNDATE.Value.Date.Date)


            Dim OBJBOOKING As New ClsAirlineBookingMaster()
            OBJBOOKING.alParaval = alParaval

            If edit = False Then

                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DTNO As DataTable = OBJBOOKING.save()
                'SENDMSG("Hi, Your booking in " & cmbhotelname.Text.Trim & " is confirmed between " & ARRIVALDATE.Value.Date & " and " & DEPARTDATE.Value.Date)
                If Convert.ToInt32(DTNO.Rows(0).Item(0)) > 0 Then
                    If DIRECTUPLOAD = False Then
                        MessageBox.Show("Details Added")
                        PRINTREPORT(DTNO.Rows(0).Item(0))
                    End If
                Else

                    MessageBox.Show("There was an error saving the entry.")
                    Exit Sub
                End If

            Else

                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                alParaval.Add(TEMPBOOKINGNO)

                Dim DTNO As DataTable = OBJBOOKING.UPDATE()
                'SENDMSG("Hi, Your booking in " & cmbhotelname.Text.Trim & " is Updated between " & ARRIVALDATE.Value.Date & " and " & DEPARTDATE.Value.Date)
                If Convert.ToInt32(DTNO.Rows(0).Item(0)) > 0 Then
                    MessageBox.Show("Details Updated")
                    PRINTREPORT(TEMPBOOKINGNO)
                    edit = False
                Else
                    MessageBox.Show("There was an error saving the entry.")
                    Exit Sub
                End If
                'MessageBox.Show("Details Updated")
                'edit = False
                'PRINTREPORT(TEMPBOOKINGNO)
            End If


            'COPY SCANNED DOCS FILES 
            For Each ROW As DataGridViewRow In gridupload.Rows
                If FileIO.FileSystem.DirectoryExists(Application.StartupPath & "\" & FRMSTRING) = False Then
                    FileIO.FileSystem.CreateDirectory(Application.StartupPath & "\" & FRMSTRING)
                End If
                If FileIO.FileSystem.FileExists(Application.StartupPath & "\" & FRMSTRING) = False Then
                    System.IO.File.Copy(ROW.Cells(GIMGPATH.Index).Value, ROW.Cells(GNEWIMGPATH.Index).Value, True)
                End If
            Next


            clear()
            BOOKINGDATE.Focus()

            If TXTIRNNO.Text <> "" And TXTACKNO.Text <> "" Then
                LBLEINVGENERATED.Visible = True
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub SENDMSG(ByVal msg As String)
        On Error Resume Next
        'If chkmobile.CheckState = CheckState.Checked Then
        '    Dim SourceStream As System.IO.Stream
        '    Dim myRequest As System.Net.HttpWebRequest = WebRequest.Create("http://s1.freesmsapi.com/messages/send?skey=b53d83a8d614ceda6b7560cf8c876309&message=" & msg & "&senderid=Bits&recipient=" & txtmobileno.Text.Trim)
        '    myRequest.Credentials = CredentialCache.DefaultCredentials
        '    Dim webResponse As WebResponse = myRequest.GetResponse
        '    SourceStream = webResponse.GetResponseStream()
        '    Dim reader As StreamReader = New StreamReader(webResponse.GetResponseStream())
        '    Dim str As String = reader.ReadLine()
        '    MsgBox(str)
        'End If
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If BOOKINGDATE.Text = "__/__/____" Then
            EP.SetError(BOOKINGDATE, " Please Enter Proper Date")
            bln = False
        Else
            If Not datecheck(BOOKINGDATE.Text) Then
                EP.SetError(BOOKINGDATE, "Date Not in Current Accounting Year")
                bln = False
            End If
        End If

        If ALLOWSAMESTATE = True And Val(TXTSTATECODE.Text.Trim) <> Val(CMPSTATECODE) Then
            EP.SetError(CMBNAME, " Booking Of Other State Not Allowed")
            bln = False
        End If

        If CMBBSP.Text = "No" And CMBPURNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBAIRNAME, " Please Select BSP SALE or Party Name")
            bln = False
        End If

        If ClientName = "TOPCOMM" And TXTTOTALBASIC.Text.Trim.Length = 0 Then
            EP.SetError(TXTBASIC, "Enter Basic")
            bln = False
        End If

        If ClientName = "URMI" And TXTREFNO.Text.Trim.Length = 0 Then
            EP.SetError(TXTREFNO, "Enter Ref No")
            bln = False
        End If

        If CMBAIRNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBAIRNAME, " Please Select Airline")
            bln = False
        End If

        If CMBNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBNAME, " Please Select Name")
            bln = False
        End If

        If ClientName <> "RAMKRISHNA" And ClientName <> "KHANNA" Then
            If CMBBSP.Text = "Yes" And CMBPURNAME.Text <> "" Then
                EP.SetError(CMBPURNAME, " Please select either BSP Sale or Party Name")
                bln = False
            End If

            If CMBBSP.Text = "Yes" And CMBPURCODE.Text <> "" Then
                EP.SetError(CMBPURCODE, " Please select either BSP Sale or Party Name")
                bln = False
            End If
        End If

        GETBALANCE()
        If LBLPURBAL.ForeColor = Color.Red Then
            EP.SetError(LBLPURBAL, "Amt Exceeds Cr Limit")
            bln = False
        End If

        If LBLACCBAL.ForeColor = Color.Red Then
            EP.SetError(LBLACCBAL, "Amt Exceeds Cr Limit")
            bln = False
        End If

        If ClientName = "CLASSIC" Then
            If UserName <> "Admin" And edit = True Then
                If Convert.ToDateTime(BOOKINGDATE.Text).Date < DDATE.Date Then
                    EP.SetError(BOOKINGDATE, "Back Date Entry Not Allowed")
                    bln = False
                End If
            End If
        End If

        'CHECKING WHETHER NAME IS PRESENT IN DATABASE OR NOT
        'DONT DELETE THIS CODE IT IS NECESSARY COZ SOMETIMES FORM IS OPEN AND USER CHANGES THE NAME FROM BEHIND
        Dim OBJCMN As New ClsCommon
        Dim DT As DataTable

        DT = OBJCMN.search(" ACC_CMPNAME", "", " LEDGERS", " AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
        If DT.Rows.Count = 0 Then
            EP.SetError(CMBNAME, "Change Name")
            bln = False
        End If

        If CMBNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBNAME, " Please Fill Account Name ")
            bln = False
        End If

        If CMBBSP.Text = "No" Then
            DT = OBJCMN.search(" ACC_CMPNAME", "", " LEDGERS", " AND ACC_CMPNAME = '" & CMBPURNAME.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
            If DT.Rows.Count = 0 Then
                EP.SetError(CMBPURNAME, "Change Name")
                bln = False
            End If
        End If

        If ClientName = "CLASSIC" And edit = False And UserName = "Admin" Then
            If Val(txtbookingno.Text.Trim) >= 0 Then
                Dim OBJC As New ClsCommon
                Dim DT1 As DataTable = OBJC.search(" BOOKING_no", "", " AIRLINEBOOKINGMASTER ", " AND BOOKING_NO = '" & txtbookingno.Text.Trim & "' and BOOKING_SALEREGISTERID = " & SALEregid & " and BOOKING_cmpid=" & CmpId & " and BOOKING_locationid=" & Locationid & " and BOOKING_yearid=" & YearId)
                If DT1.Rows.Count > 0 Then
                    EP.SetError(txtbookingno, "Booking No Already Exists !")
                    txtbookingno.Clear()
                    txtbookingno.Focus()
                    bln = False
                End If
            End If
        End If

        If (ClientName = "UTTARAKHAND" Or ClientName = "GLOBE" Or ClientName = "SKYMAPS" Or ClientName = "BARODA" Or ClientName = "MILONI" Or ClientName = "NAMASTE") And edit = False Then
            If Val(txtbookingno.Text.Trim) >= 0 Then
                Dim OBJC As New ClsCommon
                Dim DT1 As DataTable = OBJC.search(" BOOKING_no", "", " AIRLINEBOOKINGMASTER ", " AND BOOKING_NO = '" & txtbookingno.Text.Trim & "' and BOOKING_SALEREGISTERID = " & SALEregid & " and BOOKING_cmpid=" & CmpId & " and BOOKING_locationid=" & Locationid & " and BOOKING_yearid=" & YearId)
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



        'CHECKING FOR SAME PNR-NO
        If ClientName <> "TRISHA" And ClientName <> "SSR" Then
            If TXTPNRNO.Text.Trim.Length > 0 Then
                DT = OBJCMN.search(" BOOKING_NO ", "", " AIRLINEBOOKINGMASTER", " AND BOOKING_PNRNO ='" & TXTPNRNO.Text.Trim & "' AND BOOKING_CMPID = " & CmpId & " AND BOOKING_LOCATIONID = " & Locationid & " AND BOOKING_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    If (edit = False) Or (edit = True And TEMPBOOKINGNO <> DT.Rows(0).Item(0)) Then
                        EP.SetError(TXTPNRNO, "PNR No Already Present")
                        bln = False
                    End If
                End If
            End If
        End If

        'CHECKING FOR SAME AIRLINEPNR-NO
        If TXTAIRLINEPNR.Text.Trim <> "" Then
            DT = OBJCMN.search(" BOOKING_NO ", "", " AIRLINEBOOKINGMASTER", " AND BOOKING_AIRLINEPNR ='" & TXTAIRLINEPNR.Text.Trim & "' AND BOOKING_CMPID = " & CmpId & " AND BOOKING_LOCATIONID = " & Locationid & " AND BOOKING_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                If (edit = False) Or (edit = True And TEMPBOOKINGNO <> DT.Rows(0).Item(0)) Then
                    Dim TEMPMSG As Integer = vbNo
                    If ClientName = "TRISHA" Or ClientName = "SSR" Then TEMPMSG = MsgBox("PNR No Already Present, Wish to Proceed?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbNo Then
                        EP.SetError(TXTAIRLINEPNR, "PNR No Already Present")
                        bln = False
                    End If
                End If
            End If
        End If


        If TXTAIRLINEPNR.Text.Trim.Length = 0 And ClientName = "CLASSIC" Then
            EP.SetError(TXTAIRLINEPNR, " Please Fill Airline PNR")
            bln = False
        End If

        'CHECKING FOR SAME CRSPNR-NO
        '' If TXTCRSPNR.Text.Length > 0 And ClientName <> "SSR" Then
        If ClientName <> "SKYMAPS" Then
            If TXTCRSPNR.Text.Length > 0 Then
                DT = OBJCMN.search(" BOOKING_NO ", "", " AIRLINEBOOKINGMASTER", " AND BOOKING_CRSPNR ='" & TXTCRSPNR.Text.Trim & "' AND BOOKING_CMPID = " & CmpId & " AND BOOKING_LOCATIONID = " & Locationid & " AND BOOKING_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    If (edit = False) Or (edit = True And TEMPBOOKINGNO <> DT.Rows(0).Item(0)) Then
                        EP.SetError(TXTCRSPNR, "PNR No Already Present")
                        bln = False
                    End If
                End If
            End If
        End If
        '***************************************************
        'CHECKING LCC AND VALIDATING TICKETS WITH RESPECT TO STOCKS
        'If (IS_LCC = False) Or (IS_LCC = True And (CMBBSP.Text.Trim = "Yes" Or CMBCOUPON.Text.Trim = "Yes")) Then
        '    'EP.Clear()
        '    If Not CHECKTICKET(chkdup:=True) Then
        '        EP.SetError(CMBBSP, "Duplicate Ticket No.")
        '        bln = False
        '    End If
        'End If

        'checking coupon and bsp stocks
        '        If CMBAIRNAME.Text.Trim.Length > 0 And (CMBBSP.Text = "Yes" Or CMBCOUPON.Text = "Yes") Then
        '            For Each row As DataGridViewRow In GRIDBOOKINGS.Rows

        '                Dim dtstocks As DataTable
        '                If edit = False Then
        '                    dtstocks = stock(" AND TICKETNO='" & row.Cells(GTICKETNO.Index).Value & "'")
        '                Else
        '                    DT = OBJCMN.search(" AIRLINEBOOKINGMASTER.BOOKING_SALEBILLINITIALS ", "", " AIRLINEBOOKINGMASTER INNER JOIN FLIGHTMASTER ON AIRLINEBOOKINGMASTER.BOOKING_AIRLINEID = FLIGHTMASTER.FLIGHT_ID AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = FLIGHTMASTER.FLIGHT_CMPID AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID = FLIGHTMASTER.FLIGHT_LOCATIONID AND AIRLINEBOOKINGMASTER.BOOKING_YEARID = FLIGHTMASTER.FLIGHT_YEARID INNER JOIN AIRLINEBOOKINGMASTER_DESC ON AIRLINEBOOKINGMASTER.BOOKING_NO = AIRLINEBOOKINGMASTER_DESC.BOOKING_NO AND AIRLINEBOOKINGMASTER.BOOKING_SALEREGISTERID = AIRLINEBOOKINGMASTER_DESC.BOOKING_SALEREGID AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = AIRLINEBOOKINGMASTER_DESC.BOOKING_CMPID AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID = AIRLINEBOOKINGMASTER_DESC.BOOKING_LOCATIONID AND AIRLINEBOOKINGMASTER.BOOKING_YEARID = AIRLINEBOOKINGMASTER_DESC.BOOKING_YEARID ", " AND FLIGHT_NAME = '" & CMBAIRNAME.Text.Trim & "' AND AIRLINEBOOKINGMASTER_DESC.BOOKING_TICKETNO = '" & row.Cells(GTICKETNO.Index).Value & "' AND AIRLINEBOOKINGMASTER.BOOKING_SALEBILLINITIALS = '" & TEMPBOOKINGINITIALS & "' AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = " & CmpId & " AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID = " & Locationid & " AND AIRLINEBOOKINGMASTER.BOOKING_YEARID = " & YearId)
        '                    If DT.Rows.Count > 0 Then
        '                        GoTo LINE1
        '                    Else
        '                        dtstocks = stock(" AND TICKETNO='" & row.Cells(GTICKETNO.Index).Value & "'")
        '                    End If
        '                End If
        '                If dtstocks.Rows.Count = 0 Then
        '                    bln = False
        '                    EP.SetError(CMBAIRNAME, "No Such Ticket No. Exists in the stock of " & CMBAIRNAME.Text)
        '                End If
        'LINE1:
        '            Next
        '        End If




        'CHECKING WHETHER FROM AND TO AND CLASS ARE PRESENT IN MASTER OR NOT IF NOT ADD NEW
        For Each ROW As DataGridViewRow In GRIDFLIGHT.Rows
            Dim alParaval As New ArrayList
            Dim objclsSECTOR As New ClsSectorMaster
            If ROW.Cells(GFROM.Index).Value <> "" Then
                DT = OBJCMN.search("SECTOR_id", "", " SECTORMaster", " and SECTOR_NAME = '" & ROW.Cells(GFROM.Index).Value & "' and SECTOR_cmpid = " & CmpId & " and SECTOR_LOCATIONid = " & Locationid & " and SECTOR_YEARid = " & YearId)
                If DT.Rows.Count = 0 Then
                    alParaval.Add(ROW.Cells(GFROM.Index).Value)
                    alParaval.Add("")
                    alParaval.Add(CmpId)
                    alParaval.Add(Locationid)
                    alParaval.Add(Userid)
                    alParaval.Add(YearId)
                    alParaval.Add(0)
                    objclsSECTOR.alParaval = alParaval
                    Dim IntResult As Integer = objclsSECTOR.SAVE()
                End If
            End If

            If ROW.Cells(GTO.Index).Value <> "" Then
                DT = OBJCMN.search("SECTOR_id", "", " SECTORMaster", " and SECTOR_NAME = '" & ROW.Cells(GTO.Index).Value & "' and SECTOR_cmpid = " & CmpId & " and SECTOR_LOCATIONid = " & Locationid & " and SECTOR_YEARid = " & YearId)
                If DT.Rows.Count = 0 Then
                    alParaval.Add(ROW.Cells(GTO.Index).Value)
                    alParaval.Add("")
                    alParaval.Add(CmpId)
                    alParaval.Add(Locationid)
                    alParaval.Add(Userid)
                    alParaval.Add(YearId)
                    alParaval.Add(0)
                    objclsSECTOR.alParaval = alParaval
                    Dim IntResult As Integer = objclsSECTOR.SAVE()
                End If
            End If


            If ROW.Cells(GCLASS.Index).Value <> "" Then
                DT = OBJCMN.search("CLASS_id", "", " CLASSMaster", " and CLASS_NAME = '" & ROW.Cells(GCLASS.Index).Value & "' and CLASS_cmpid = " & CmpId & " and CLASS_LOCATIONid = " & Locationid & " and CLASS_YEARid = " & YearId)
                If DT.Rows.Count = 0 Then
                    alParaval.Add(ROW.Cells(GCLASS.Index).Value)
                    alParaval.Add("")
                    alParaval.Add(CmpId)
                    alParaval.Add(Locationid)
                    alParaval.Add(Userid)
                    alParaval.Add(YearId)
                    alParaval.Add(0)
                    Dim OBJCLASS As New ClsClassMaster
                    OBJCLASS.alParaval = alParaval
                    Dim IntResult As Integer = OBJCLASS.SAVE()
                End If
            End If

        Next



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


        If Val(txtgrandtotal.Text.Trim) = 0 Then
            EP.SetError(txtgrandtotal, "Amount cannot be 0")
            bln = False
        End If

        If Val(TXTFINALPURAMT.Text.Trim) = 0 And ClientName <> "RAMKRISHNA" And ClientName <> "KHANNA" Then
            EP.SetError(TXTFINALPURAMT, "Amount Cannot be 0")
            bln = False
        End If


        If GRIDBOOKINGS.RowCount = 0 Then
            EP.SetError(TXTTOTAL, "Enter Proper Details")
            TBDETAILS.SelectedIndex = 0
            bln = False
        End If

        If GRIDPASS.RowCount = 0 Then
            EP.SetError(TXTTOTAL, "Enter Passenger Details")
            TBDETAILS.SelectedIndex = 0
            bln = False
        End If

        If GRIDPUR.RowCount = 0 And ClientName <> "RAMKRISHNA" And ClientName <> "KHANNA" Then
            EP.SetError(TXTTOTAL, "Enter Purchase Details")
            TBDETAILS.SelectedIndex = 0
            bln = False
        End If

        If CMBBOOKEDBY.Text.Trim.Length = 0 Then
            EP.SetError(CMBBOOKEDBY, " Please Fill Your Name ")
            bln = False
        End If

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

        If Val(txtotherchg.Text.Trim) = 0 Then
            CMBOTHERCHGS.Text = ""
            cmbaddsub.SelectedIndex = 0
        End If

        If Val(TXTPUROTHERCHGS.Text.Trim) = 0 Then
            CMBPUROTHERCHGS.Text = ""
            CMBPURADDSUB.SelectedIndex = 0
        End If


        If Val(txtotherchg.Text.Trim) > 0 And CMBOTHERCHGS.Text.Trim = "" Then
            EP.SetError(txtotherchg, " Select Expense Type")
            bln = False
        End If

        If Val(TXTPUROTHERCHGS.Text.Trim) > 0 And CMBPUROTHERCHGS.Text.Trim = "" Then
            EP.SetError(TXTPUROTHERCHGS, " Select Expense Type")
            bln = False
        End If

        If ClientName = "CLASSIC" Then
            If UserName <> "Admin" And edit = False Then
                If Convert.ToDateTime(BOOKINGDATE.Text).Date < Now.Date Then
                    EP.SetError(BOOKINGDATE, "Back Date Entry Not Allowed")
                    bln = False
                End If
            End If
        End If


        If Not datecheck(BOOKINGDATE.Text) Then
            EP.SetError(BOOKINGDATE, "Date Not in Current Accounting Year")
            bln = False
        End If

        For Each row As DataGridViewRow In GRIDBOOKINGS.Rows
            If row.Cells(GNAME.Index).Value.ToString = "" Then
                EP.SetError(TXTTOTALAMT, "Passenger Cannot be blank")
                bln = False
            End If
        Next

        Return bln
    End Function

    Sub total()

        TXTTOTALPAX.Clear()
        TXTTOTALBASIC.Text = "0.00"
        TXTTOTALPSF.Text = "0.00"
        TXTTOTALTAXES.Text = "0.00"
        TXTTOTALAMT.Text = "0.00"
        TXTTOTALSALEAMT.Text = "0.00"
        TXTCESSAMT.Clear()
        TXTTOTALPAX.Text = GRIDBOOKINGS.RowCount
        If Val(TXTSALETDSPER.Text.Trim) > 0 Then TXTSALETDSRS.Text = 0.0

        CMBADDTAX.Text = ""
        TXTADDTAX.Clear()

        If GRIDBOOKINGS.RowCount > 0 Then

            TXTSUBTOTAL.Text = 0.0
            TXTADDTAX.Text = 0.0
            If Val(TXTOURCOMMPER.Text.Trim) > 0 Then TXTOURCOMMRS.Text = 0.0
            If Val(TXTDISCPER.Text.Trim) > 0 Then TXTDISCRS.Text = 0.0
            txtroundoff.Text = 0.0
            txtgrandtotal.Text = 0.0

            For Each row As DataGridViewRow In GRIDBOOKINGS.Rows
                If Val(row.Cells(GBASIC.Index).Value) > 0 Then TXTTOTALBASIC.Text = Val(TXTTOTALBASIC.Text) + Val(row.Cells(GBASIC.Index).Value)
                If Val(row.Cells(GPSF.Index).Value) > 0 Then TXTTOTALPSF.Text = Val(TXTTOTALPSF.Text) + Val(row.Cells(GPSF.Index).Value)
                If Val(row.Cells(GTAXES.Index).Value) > 0 Then TXTTOTALTAXES.Text = Val(TXTTOTALTAXES.Text) + Val(row.Cells(GTAXES.Index).Value)
                If Val(row.Cells(GTOTAL.Index).Value) > 0 Then TXTTOTALAMT.Text = Format(Val(TXTTOTALAMT.Text) + Val(row.Cells(GTOTAL.Index).Value), "0.00")
            Next

            'TXTTOTALSALEAMT.Text = Format(Val(TXTTOTALAMT.Text.Trim), "0.00")

            'WORKING CODE TILL 24-05-207, NEW CODE WRITTEN BELOW AS PER AERO N ALL
            'If CHKREVERSE.Checked = True Then
            '    Dim objclscmn As New ClsCommonMaster
            '    Dim dt1 As DataTable = objclscmn.search("TAX_NAME ,tax_tax AS TAX", "", "TAXMaster", " and TAX_NAME = '" & cmbtax.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
            '    If dt1.Rows.Count > 0 Then
            '        If CHKTAXSERVCHGS.CheckState = CheckState.Checked Then
            '            TXTEXTRACHGS.Text = Format((Val(TXTEXTRACHGS.Text.Trim) / (Val(dt1.Rows(0).Item(1)) + 100) * 100), "0.00")
            '            TXTTOTALSALEAMT.Text = Format(Val(TXTTOTALAMT.Text.Trim), "0.00")
            '        Else
            '            TXTTOTALSALEAMT.Text = Format((Val(TXTTOTALAMT.Text.Trim) / (Val(dt1.Rows(0).Item(1)) + 100) * 100), "0.00")
            '        End If
            '    End If
            'Else
            '    TXTTOTALSALEAMT.Text = Format(Val(TXTTOTALAMT.Text.Trim), "0.00")
            'End If


            'TESTING FOR AERO 24-05-2017
            '24-05-2017
            If CHKREVERSE.Checked = True Then
                If CHKTAXSERVCHGS.Checked = False Then
                    Dim objclscmn As New ClsCommonMaster
                    Dim dt1 As DataTable = objclscmn.search("TAX_NAME ,tax_tax AS TAX", "", "TAXMaster", " and TAX_NAME = '" & cmbtax.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
                    If dt1.Rows.Count > 0 Then
                        TXTTOTALSALEAMT.Text = Format((Val(TXTTOTALAMT.Text.Trim) / (Val(dt1.Rows(0).Item(1)) + 100) * 100), "0.00")
                    Else
                        TXTTOTALSALEAMT.Text = Format(Val(TXTTOTALAMT.Text.Trim), "0.00")
                    End If
                Else
                    Dim objclscmn As New ClsCommonMaster
                    Dim dt1 As DataTable = objclscmn.search("TAX_NAME ,tax_tax AS TAX", "", "TAXMaster", " and TAX_NAME = '" & cmbtax.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
                    If dt1.Rows.Count > 0 Then
                        TXTOURCOMMRS.Text = Format((Val(TXTOURCOMMRS.Text.Trim) / (Val(dt1.Rows(0).Item(1)) + 100) * 100), "0.00")
                    End If
                    TXTTOTALSALEAMT.Text = Format(Val(TXTTOTALAMT.Text.Trim), "0.00")
                End If
            Else
                TXTTOTALSALEAMT.Text = Format(Val(TXTTOTALAMT.Text.Trim), "0.00")
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
                'TXTDISCPER.Text = Format((Val(TXTDISCRS.Text) * 100) / Val(TXTTOTALSALEAMT.Text), "0.00")
            End If

            If (Val(txtDiscountPerc.Text.Trim) > 0) Then
                txtDiscountAmount.Text = Format((Val(txtDiscountPerc.Text.Trim) * (Val(TXTTOTALBASIC.Text) + Val(TXTTOTALTAXES.Text))) / 100, "0.00")
            ElseIf (Val(txtDiscountAmount.Text) > 0) Then
                txtDiscountAmount.Text = Format(Val(txtDiscountAmount.Text), "0.00")
            End If

            'TDS ON DISCOUNT FOR SKYMAPS
            If Val(TXTSALETDSPER.Text) > 0 Then
                TXTSALETDSRS.Text = Format((Val(TXTSALETDSPER.Text) * Val(txtDiscountAmount.Text)) / 100, "0.00")
            End If


            'COZ OUR COMM SHOULD NOT BE ADDED
            'TXTSUBTOTAL.Text = Format((Val(TXTTOTALSALEAMT.Text) + Val(TXTOURCOMMRS.Text)) - Val(TXTDISCRS.Text), "0.00")
            TXTSUBTOTAL.Text = Format((Val(TXTTOTALSALEAMT.Text) - Val(TXTDISCRS.Text) - Val(txtDiscountAmount.Text.Trim)) + Val(TXTEXTRACHGS.Text.Trim), "0.00")



            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            If Convert.ToDateTime(BOOKINGDATE.Text).Date < "01/07/2017" Then

                dt = objclscommon.search("TAX_NAME AS NAME ,tax_tax AS TAX", "", "TAXMaster", " and TAX_NAME = '" & cmbtax.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
                If CHKTAXSERVCHGS.CheckState = CheckState.Checked Or ClientName = "TRISHA" Then
                    If dt.Rows.Count > 0 Then If Val(dt.Rows(0).Item("TAX")) > 0 Then txttax.Text = Format((Val(dt.Rows(0).Item(1)) * Val(TXTEXTRACHGS.Text)) / 100, "0.00")
                Else
                    If dt.Rows.Count > 0 Then If Val(dt.Rows(0).Item("TAX")) > 0 Then txttax.Text = Format((Val(dt.Rows(0).Item(1)) * Val(TXTTOTALBASIC.Text)) / 100, "0.00")
                End If
            Else
                If CHKMANUAL.CheckState = CheckState.Unchecked Then
                    If CHKTAXSERVCHGS.CheckState = CheckState.Checked Then
                        TXTCGSTAMT.Text = Format((Val(TXTCGSTPER.Text) * Val(TXTEXTRACHGS.Text)) / 100, "0.00")
                        TXTSGSTAMT.Text = Format((Val(TXTSGSTPER.Text) * Val(TXTEXTRACHGS.Text)) / 100, "0.00")
                        TXTIGSTAMT.Text = Format((Val(TXTIGSTPER.Text) * Val(TXTEXTRACHGS.Text)) / 100, "0.00")
                        If APPLYCESS = True And CMBNAME.Text.Trim <> "" Then
                            'IF GSTNO IS BLANK THEN APPLYCESS
                            Dim DTCESS As DataTable = objclscommon.search("ISNULL(ACC_GSTIN,'') AS GSTIN ", "", "LEDGERS", " AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND ACC_YEARID = " & YearId)
                            If DTCESS.Rows(0).Item("GSTIN") = "" Then TXTCESSAMT.Text = Format((Val(TXTCESSPER.Text) * Val(TXTOURCOMMRS.Text)) / 100, "0.00")
                        End If
                    Else

                        TXTCGSTAMT.Text = Format((Val(TXTCGSTPER.Text) * Val(TXTTOTALBASIC.Text)) / 100, "0.00")
                        TXTSGSTAMT.Text = Format((Val(TXTSGSTPER.Text) * Val(TXTTOTALBASIC.Text)) / 100, "0.00")
                        TXTIGSTAMT.Text = Format((Val(TXTIGSTPER.Text) * Val(TXTTOTALBASIC.Text)) / 100, "0.00")
                        If APPLYCESS = True And CMBNAME.Text.Trim <> "" Then
                            'IF GSTNO IS BLANK THEN APPLYCESS
                            Dim DTCESS As DataTable = objclscommon.search("ISNULL(ACC_GSTIN,'') AS GSTIN ", "", "LEDGERS", " AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND ACC_YEARID = " & YearId)
                            If DTCESS.Rows(0).Item("GSTIN") = "" Then TXTCESSAMT.Text = Format((Val(TXTCESSPER.Text) * Val(TXTOURCOMMRS.Text)) / 100, "0.00")
                        End If
                    End If
                End If
            End If







            dt = objclscommon.search("TAX_NAME AS NAME,tax_tax AS TAX", "", "TAXMASTER", " and TAX_NAME = '" & CMBADDTAX.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
            If dt.Rows.Count > 0 Then If Val(dt.Rows(0).Item("TAX")) > 0 Then TXTADDTAX.Text = Format((Val(dt.Rows(0).Item(1)) * Val(TXTTOTALBASIC.Text)) / 100, "0.00")


            If (Val(txtAddDiscountAmount.Text.Trim) > 0) Then txtAddDiscountAmount.Text = Format(Val(txtAddDiscountAmount.Text), "0.00")


            'FOR 7HOSPITALITY TAX SHOULD BE ROUNDED OFF AS PER ACCOUNTANTS REQ
            If ClientName = "7HOSPITALITY" Then
                txttax.Text = Format(Val(txttax.Text.Trim), "0")
                txttax.Text = Format(Val(txttax.Text.Trim), "0.00")
            End If


            If cmbaddsub.Text = "Add" Then
                txtgrandtotal.Text = Format(Val(TXTSUBTOTAL.Text) + Val(txttax.Text) + Val(TXTCGSTAMT.Text) + Val(TXTSGSTAMT.Text) + Val(TXTIGSTAMT.Text) - Val(txtAddDiscountAmount.Text) + Val(TXTCESSAMT.Text.Trim) + Val(TXTADDTAX.Text) + Val(txtotherchg.Text), "0")
                txtroundoff.Text = Format(Val(txtgrandtotal.Text) - (Val(TXTSUBTOTAL.Text) + Val(txttax.Text) + Val(TXTCGSTAMT.Text) + Val(TXTSGSTAMT.Text) + Val(TXTIGSTAMT.Text) - Val(txtAddDiscountAmount.Text) + Val(TXTCESSAMT.Text.Trim) + Val(TXTADDTAX.Text) + Val(txtotherchg.Text)), "0.00")
            Else
                txtgrandtotal.Text = Format((Val(TXTSUBTOTAL.Text) + Val(txttax.Text) + Val(TXTCGSTAMT.Text) + Val(TXTSGSTAMT.Text) + Val(TXTIGSTAMT.Text) - Val(txtAddDiscountAmount.Text) + Val(TXTCESSAMT.Text.Trim) + Val(TXTADDTAX.Text)) - Val(txtotherchg.Text), "0")
                txtroundoff.Text = Format(Val(txtgrandtotal.Text) - ((Val(TXTSUBTOTAL.Text) + Val(txttax.Text) + Val(TXTCGSTAMT.Text) + Val(TXTSGSTAMT.Text) + Val(TXTIGSTAMT.Text) - Val(txtAddDiscountAmount.Text) + Val(TXTCESSAMT.Text.Trim) + Val(TXTADDTAX.Text)) - Val(txtotherchg.Text)), "0.00")
            End If

            txtgrandtotal.Text = Format(Val(txtgrandtotal.Text), "0.00")

            If ClientName = "SKYMAPS" Then
                txtgrandtotal.Text = Format((Val(txtgrandtotal.Text) + Val(TXTSALETDSRS.Text)), "0.00")
            End If


            'as per ASHOK BHAI'S RECOMMENDATION
            'TXTOURCOMMRS.Text = Format(Val(txtgrandtotal.Text) - Val(TXTFINALPURAMT.Text), "0.00")

            If ClientName <> "ELYSIUM" Then TXTOURCOMMRS.Text = Format(Val(TXTSUBTOTAL.Text) - Val(TXTFINALPURAMT.Text), "0.00")


            If Val(txtgrandtotal.Text) > 0 Then txtinwords.Text = CurrencyToWord(txtgrandtotal.Text)
            If edit = False And ClientName <> "ELYSIUM" Then TXTBAL.Text = Val(txtgrandtotal.Text.Trim)

        End If
    End Sub

    Sub PURCHASETOTAL()


        'If GRIDPUR.RowCount > 0 Then

        TXTPURAMT.Text = 0.0
        TXTTOTALPURAMT.Text = 0.0
        TXTPURSUBTOTAL.Text = 0.0
        'TXTPURTAX.Text = 0.0
        TXTPURADDTAX.Text = 0.0
        If Val(TXTDISCRECDPER.Text.Trim) > 0 Then TXTDISCRECDRS.Text = 0.0
        If Val(TXTCOMMRECDPER.Text.Trim) > 0 Then TXTCOMMRECDRS.Text = 0.0
        If Val(TXTPURTDSPER.Text.Trim) > 0 Then TXTPURTDSRS.Text = 0.0
        TXTPURNETTAMT.Text = 0.0

        'THIS IS DONE COZ PRIYA NEED TO WRITE MANUAL ROUNDOFF
        If ClientName <> "PRIYA" Then TXTPURROUNDOFF.Text = 0.0

        TXTPURGTOTAL.Text = 0.0
        TXTTOTALPURBASIC.Text = 0.0
        TXTTOTALPURPSF.Text = 0.0
        TXTTOTALPURTAX.Text = 0.0
        TXTPURCESSAMT.Clear()

        'txtPurDiscountAmount.Text = 0.0
        'txtPurAddDiscountAmount.Text = 0.0

        For Each row As DataGridViewRow In GRIDPUR.Rows
            row.Cells(GPURTOTAL.Index).Value = Format((Val(row.Cells(GPURBASIC.Index).EditedFormattedValue) + Val(row.Cells(GPURPSF.Index).EditedFormattedValue) + Val(row.Cells(GPURTAXES.Index).EditedFormattedValue)), "0.00")
            If Val(row.Cells(GPURTOTAL.Index).Value) > 0 Then TXTPURAMT.Text = Format(Val(TXTPURAMT.Text) + Val(row.Cells(GPURTOTAL.Index).EditedFormattedValue), "0.00")
            If Val(row.Cells(GPURBASIC.Index).Value) > 0 Then TXTTOTALPURBASIC.Text = Format(Val(TXTTOTALPURBASIC.Text) + Val(row.Cells(GPURBASIC.Index).EditedFormattedValue), "0.00")
            If Val(row.Cells(GPURPSF.Index).Value) > 0 Then TXTTOTALPURPSF.Text = Format(Val(TXTTOTALPURPSF.Text) + Val(row.Cells(GPURPSF.Index).EditedFormattedValue), "0.00")
            If Val(row.Cells(GPURTAXES.Index).Value) > 0 Then TXTTOTALPURTAX.Text = Format(Val(TXTTOTALPURTAX.Text) + Val(row.Cells(GPURTAXES.Index).EditedFormattedValue), "0.00")
        Next

        TXTTOTALPURAMT.Text = Format(Val(TXTPURAMT.Text.Trim), "0.00")


        If Val(TXTDISCRECDPER.Text) > 0 Then
            TXTDISCRECDRS.Text = Format((Val(TXTDISCRECDPER.Text) * Val(TXTTOTALPURAMT.Text)) / 100, "0.00")
        Else
            'TXTDISCRECDPER.Text = Format((Val(TXTDISCRECDRS.Text) * 100) / Val(TXTTOTALPURAMT.Text), "0.00")
        End If

        TXTPURSUBTOTAL.Text = Format(Val(TXTTOTALPURAMT.Text) - Val(TXTDISCRECDRS.Text), "0.00")

        If Val(TXTCOMMRECDPER.Text) > 0 Then
            TXTCOMMRECDRS.Text = Format((Val(TXTCOMMRECDPER.Text) * Val(TXTTOTALPURAMT.Text)) / 100, "0.00")
        Else
            'TXTCOMMRECDPER.Text = Format((Val(TXTCOMMRECDRS.Text) * 100) / Val(TXTTOTALPURAMT.Text), "0.00")
        End If

        TXTPURNETTAMT.Text = Format(Val(TXTPURSUBTOTAL.Text) + Val(TXTPURSERVCHGS.Text.Trim) - Val(TXTCOMMRECDRS.Text) + Val(TXTPUREXTRACHGS.Text.Trim), "0.00")




        If (Val(txtPurDiscountPerc.Text.Trim) > 0) Then
            If ClientName = "PRATAMESH" Then
                txtPurDiscountAmount.Text = Format((Val(txtPurDiscountPerc.Text.Trim) * Val(TXTTOTALPURBASIC.Text)) / 100, "0.00")
            Else
                txtPurDiscountAmount.Text = Format((Val(txtPurDiscountPerc.Text.Trim) * (Val(TXTTOTALPURBASIC.Text) + Val(TXTTOTALPURTAX.Text))) / 100, "0.00")
            End If
        ElseIf (Val(txtPurDiscountAmount.Text) > 0) Then
            txtPurDiscountAmount.Text = Format(Val(txtPurDiscountAmount.Text), "0.00")
        Else
            Dim commbasic As Double = 0
            Dim commpsf As Double = 0
            Dim commtax As Double = 0
            If COMMBASICPERC > 0 Then commbasic = (COMMBASICPERC * Val(TXTTOTALPURBASIC.Text)) / 100
            If COMMPSFPERC > 0 Then commpsf = (COMMPSFPERC * Val(TXTTOTALPURPSF.Text)) / 100
            If COMMTAXPERC > 0 Then commtax = (COMMTAXPERC * Val(TXTTOTALPURTAX.Text)) / 100
            txtPurDiscountAmount.Text = commbasic + commpsf + commtax
            txtPurDiscountAmount.Text = Format(Val(txtPurDiscountAmount.Text), "0.00")
        End If

        Dim objclscommon As New ClsCommonMaster
        Dim dt As DataTable

        If Convert.ToDateTime(BOOKINGDATE.Text).Date < "07/01/2017" Then

            dt = objclscommon.search("TAX_NAME AS TAXNAME,tax_tax AS TAX", "", "TAXMaster", " and TAX_NAME = '" & CMBPURTAX.Text.Trim & "' and TAX_Yearid = " & YearId)
            If dt.Rows.Count > 0 Then
                If Val(dt.Rows(0).Item("TAX")) > 0 Then
                    If CHKPURTAXONCOMM.Checked = False Then
                        TXTPURTAX.Text = Format((Val(dt.Rows(0).Item(1)) * (Val(TXTTOTALPURBASIC.Text))) / 100, "0.00")
                    Else
                        TXTPURTAX.Text = Format((Val(dt.Rows(0).Item(1)) * (Val(txtPurDiscountAmount.Text))) / 100, "0.00")
                    End If

                End If
            End If
        Else
            If CHKPURMANUAL.CheckState = CheckState.Unchecked Then
                If CHKPURTAXSERVCHGS.CheckState = CheckState.Checked Then
                    TXTPURCGSTAMT.Text = Format((Val(TXTPURCGSTPER.Text) * Val(TXTPURSERVCHGS.Text)) / 100, "0.00")
                    TXTPURSGSTAMT.Text = Format((Val(TXTPURSGSTPER.Text) * Val(TXTPURSERVCHGS.Text)) / 100, "0.00")
                    TXTPURIGSTAMT.Text = Format((Val(TXTPURIGSTPER.Text) * Val(TXTPURSERVCHGS.Text)) / 100, "0.00")
                    If APPLYCESS = True And CMBPURNAME.Text.Trim <> "" Then
                        'IF GSTNO IS BLANK THEN APPLYCESS
                        Dim DTCESS As DataTable = objclscommon.search("ISNULL(ACC_GSTIN,'') AS GSTIN ", "", "LEDGERS", " AND ACC_CMPNAME = '" & CMBPURNAME.Text.Trim & "' AND ACC_YEARID = " & YearId)
                        If DTCESS.Rows(0).Item("GSTIN") = "" Then TXTPURCESSAMT.Text = Format((Val(TXTPURCESSPER.Text) * Val(TXTPURSERVCHGS.Text)) / 100, "0.00")
                    End If
                Else

                    TXTPURCGSTAMT.Text = Format((Val(TXTPURCGSTPER.Text) * Val(TXTTOTALPURBASIC.Text)) / 100, "0.00")
                    TXTPURSGSTAMT.Text = Format((Val(TXTPURSGSTPER.Text) * Val(TXTTOTALPURBASIC.Text)) / 100, "0.00")
                    TXTPURIGSTAMT.Text = Format((Val(TXTPURIGSTPER.Text) * Val(TXTTOTALPURBASIC.Text)) / 100, "0.00")
                    If APPLYCESS = True And CMBPURNAME.Text.Trim <> "" Then
                        'IF GSTNO IS BLANK THEN APPLYCESS
                        Dim DTCESS As DataTable = objclscommon.search("ISNULL(ACC_GSTIN,'') AS GSTIN ", "", "LEDGERS", " AND ACC_CMPNAME = '" & CMBPURNAME.Text.Trim & "' AND ACC_YEARID = " & YearId)
                        If DTCESS.Rows(0).Item("GSTIN") = "" Then TXTPURCESSAMT.Text = Format((Val(TXTPURCESSPER.Text) * Val(TXTTOTALPURBASIC.Text)) / 100, "0.00")
                    End If
                End If
            End If
        End If

        If Val(TXTPURTDSPER.Text) > 0 Then
            TXTPURTDSRS.Text = Format((Val(TXTPURTDSPER.Text) * Val(txtPurDiscountAmount.Text)) / 100, "0.00")
        End If

        If (Val(txtPurAddDiscountAmount.Text.Trim) > 0) Then
            txtPurAddDiscountAmount.Text = Format(Val(txtPurAddDiscountAmount.Text), "0.00")
        End If

        'for add tax

        'If Format(bookingdate.Value.Date, "MM/DD/yyyy") < "01/07/2017" Then

        dt = objclscommon.search("TAX_NAME,tax_tax", "", "TAXMaster", " and TAX_NAME = '" & CMBPURADDTAX.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
        If dt.Rows.Count > 0 Then TXTPURADDTAX.Text = Format((Val(dt.Rows(0).Item(1)) * (Val(TXTTOTALPURBASIC.Text))) / 100, "0.00")

        'Else
        '    If CHKPURTAXSERVCHGS.CheckState = CheckState.Checked Then
        '        TXTPURCGSTAMT.Text = Format((Val(TXTPURCGSTPER.Text) * Val(TXTPURSERVCHGS.Text)) / 100, "0.00")
        '        TXTPURSGSTAMT.Text = Format((Val(TXTPURSGSTPER.Text) * Val(TXTPURSERVCHGS.Text)) / 100, "0.00")
        '        TXTPURIGSTAMT.Text = Format((Val(TXTPURIGSTPER.Text) * Val(TXTPURSERVCHGS.Text)) / 100, "0.00")

        '    Else

        '        TXTPURCGSTAMT.Text = Format((Val(TXTPURCGSTPER.Text) * Val(TXTPURNETTAMT.Text)) / 100, "0.00")
        '        TXTPURSGSTAMT.Text = Format((Val(TXTPURSGSTPER.Text) * Val(TXTPURNETTAMT.Text)) / 100, "0.00")
        '        TXTPURIGSTAMT.Text = Format((Val(TXTPURIGSTPER.Text) * Val(TXTPURNETTAMT.Text)) / 100, "0.00")

        '    End If
        'End If

        If CMBPURADDSUB.Text = "Add" Then
            TXTPURGTOTAL.Text = Format(Val(TXTPURNETTAMT.Text) + Val(TXTPURTAX.Text) + Val(TXTPURCGSTAMT.Text.Trim) + Val(TXTPURSGSTAMT.Text.Trim) + Val(TXTPURIGSTAMT.Text.Trim) - Val(txtPurDiscountAmount.Text) - Val(txtPurAddDiscountAmount.Text) + Val(TXTPURADDTAX.Text) + Val(TXTPUROTHERCHGS.Text), "0")
            If ClientName <> "PRIYA" Then TXTPURROUNDOFF.Text = Format(Val(TXTPURGTOTAL.Text) - (Val(TXTPURNETTAMT.Text) + Val(TXTPURTAX.Text) + Val(TXTPURCGSTAMT.Text.Trim) + Val(TXTPURSGSTAMT.Text.Trim) + Val(TXTPURIGSTAMT.Text.Trim) - Val(txtPurDiscountAmount.Text) - Val(txtPurAddDiscountAmount.Text) + Val(TXTPURADDTAX.Text) + Val(TXTPUROTHERCHGS.Text)), "0.00")
        Else
            TXTPURGTOTAL.Text = Format((Val(TXTPURNETTAMT.Text) + Val(TXTPURTAX.Text) + Val(TXTPURCGSTAMT.Text.Trim) + Val(TXTPURSGSTAMT.Text.Trim) + Val(TXTPURIGSTAMT.Text.Trim) - Val(txtPurDiscountAmount.Text) - Val(txtPurAddDiscountAmount.Text) + Val(TXTPURADDTAX.Text)) - Val(TXTPUROTHERCHGS.Text), "0")
            If ClientName <> "PRIYA" Then TXTPURROUNDOFF.Text = Format(Val(TXTPURGTOTAL.Text) - ((Val(TXTPURNETTAMT.Text) + Val(TXTPURTAX.Text) + Val(TXTPURCGSTAMT.Text.Trim) + Val(TXTPURSGSTAMT.Text.Trim) + Val(TXTPURIGSTAMT.Text.Trim) - Val(txtPurDiscountAmount.Text) - Val(txtPurAddDiscountAmount.Text) + Val(TXTPURADDTAX.Text)) - Val(TXTPUROTHERCHGS.Text)), "0.00")
        End If

        If ClientName <> "PRIYA" Then
            TXTPURGTOTAL.Text = Format(Val(TXTPURGTOTAL.Text), "0.00")
        Else
            If CMBPURADDSUB.Text = "Add" Then
                TXTPURGTOTAL.Text = Format(Val(TXTPURNETTAMT.Text) + Val(TXTPURTAX.Text) + Val(TXTPURCGSTAMT.Text.Trim) + Val(TXTPURSGSTAMT.Text.Trim) + Val(TXTPURIGSTAMT.Text.Trim) - Val(txtPurDiscountAmount.Text) - Val(txtPurAddDiscountAmount.Text) + Val(TXTPURADDTAX.Text) + Val(TXTPUROTHERCHGS.Text) + Val(TXTPURROUNDOFF.Text.Trim), "0.00")
            Else
                TXTPURGTOTAL.Text = Format((Val(TXTPURNETTAMT.Text) + Val(TXTPURTAX.Text) + Val(TXTPURCGSTAMT.Text.Trim) + Val(TXTPURSGSTAMT.Text.Trim) + Val(TXTPURIGSTAMT.Text.Trim) - Val(txtPurDiscountAmount.Text) - Val(txtPurAddDiscountAmount.Text) + Val(TXTPURADDTAX.Text)) - Val(TXTPUROTHERCHGS.Text) + Val(TXTPURROUNDOFF.Text.Trim), "0.00")
            End If
        End If

        TXTFINALPURAMT.Text = Format(Val(TXTPURGTOTAL.Text), "0.00")
        TXTPURTDSAMT.Text = Format((Val(TXTPURTDSRS.Text.Trim) + Val(TXTFINALPURAMT.Text.Trim)), "0.00")
        total()
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

    Function CHECKTICKET(Optional ByVal chkdup As Boolean = False) As Boolean
        Try
            Dim BLN As Boolean = True
            For Each ROW As DataGridViewRow In GRIDBOOKINGS.Rows
                If TXTPASSNAME.Text.Trim <> "" And ((gridDoubleClick = False And LCase(ROW.Cells(GTICKETNO.Index).Value) = LCase(TXTTICKETNO.Text.Trim)) Or (gridDoubleClick = True And ROW.Index <> temprow And LCase(ROW.Cells(GTICKETNO.Index).Value) = LCase(TXTTICKETNO.Text.Trim))) Then
                    EP.SetError(TXTTOTAL, "Ticket No Already Present below")
                    BLN = False
                End If

                If chkdup = True And BLN = True And ROW.Cells(GTICKETNO.Index).Value.ToString.Length > 0 Then
                    Dim objcmn As New ClsCommon
                    Dim DT As DataTable
                    If edit = False Then
                        DT = objcmn.search(" AIRLINEBOOKINGMASTER.BOOKING_NO AS BOOKINGNO, ISNULL(AIRLINEBOOKINGMASTER_DESC.BOOKING_TICKETNO, '') AS TICKETNO ", " ", " AIRLINEBOOKINGMASTER_DESC INNER JOIN AIRLINEBOOKINGMASTER ON AIRLINEBOOKINGMASTER_DESC.BOOKING_NO = AIRLINEBOOKINGMASTER.BOOKING_NO AND AIRLINEBOOKINGMASTER_DESC.BOOKING_CMPID = AIRLINEBOOKINGMASTER.BOOKING_CMPID AND AIRLINEBOOKINGMASTER_DESC.BOOKING_LOCATIONID = AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID AND AIRLINEBOOKINGMASTER_DESC.BOOKING_YEARID = AIRLINEBOOKINGMASTER.BOOKING_YEARID AND AIRLINEBOOKINGMASTER_DESC.BOOKING_SALEREGID = AIRLINEBOOKINGMASTER.BOOKING_SALEREGISTERID INNER JOIN FLIGHTMASTER ON AIRLINEBOOKINGMASTER.BOOKING_AIRLINEID = FLIGHTMASTER.FLIGHT_ID AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = FLIGHTMASTER.FLIGHT_CMPID AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID = FLIGHTMASTER.FLIGHT_LOCATIONID AND AIRLINEBOOKINGMASTER.BOOKING_YEARID = FLIGHTMASTER.FLIGHT_YEARID ", " AND AIRLINEBOOKINGMASTER_DESC.BOOKING_TICKETNO = '" & ROW.Cells(GTICKETNO.Index).Value.ToString.Trim & "' AND AIRLINEBOOKINGMASTER_DESC.BOOKING_CANCELLED = '0' AND FLIGHTMASTER.FLIGHT_NAME = '" & CMBAIRNAME.Text.Trim & "' AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = " & CmpId & " AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID = " & Locationid & " AND AIRLINEBOOKINGMASTER.BOOKING_YEARID = " & YearId & " AND AIRLINEBOOKINGMASTER.BOOKING_SALEREGISTERID = " & SALEregid)
                    Else
                        DT = objcmn.search(" AIRLINEBOOKINGMASTER.BOOKING_NO AS BOOKINGNO, ISNULL(AIRLINEBOOKINGMASTER_DESC.BOOKING_TICKETNO, '') AS TICKETNO ", " ", " AIRLINEBOOKINGMASTER_DESC INNER JOIN AIRLINEBOOKINGMASTER ON AIRLINEBOOKINGMASTER_DESC.BOOKING_NO = AIRLINEBOOKINGMASTER.BOOKING_NO AND AIRLINEBOOKINGMASTER_DESC.BOOKING_CMPID = AIRLINEBOOKINGMASTER.BOOKING_CMPID AND AIRLINEBOOKINGMASTER_DESC.BOOKING_LOCATIONID = AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID AND AIRLINEBOOKINGMASTER_DESC.BOOKING_YEARID = AIRLINEBOOKINGMASTER.BOOKING_YEARID AND AIRLINEBOOKINGMASTER_DESC.BOOKING_SALEREGID = AIRLINEBOOKINGMASTER.BOOKING_SALEREGISTERID INNER JOIN FLIGHTMASTER ON AIRLINEBOOKINGMASTER.BOOKING_AIRLINEID = FLIGHTMASTER.FLIGHT_ID AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = FLIGHTMASTER.FLIGHT_CMPID AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID = FLIGHTMASTER.FLIGHT_LOCATIONID AND AIRLINEBOOKINGMASTER.BOOKING_YEARID = FLIGHTMASTER.FLIGHT_YEARID ", " AND AIRLINEBOOKINGMASTER_DESC.BOOKING_TICKETNO = '" & ROW.Cells(GTICKETNO.Index).Value.ToString.Trim & "' AND AIRLINEBOOKINGMASTER_DESC.BOOKING_CANCELLED = '0' AND FLIGHTMASTER.FLIGHT_NAME = '" & CMBAIRNAME.Text.Trim & "' AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = " & CmpId & " AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID = " & Locationid & " AND AIRLINEBOOKINGMASTER.BOOKING_YEARID = " & YearId & " AND AIRLINEBOOKINGMASTER.BOOKING_SALEREGISTERID = " & SALEregid & " AND AIRLINEBOOKINGMASTER.BOOKING_NO <> " & TEMPBOOKINGNO)
                    End If
                    If DT.Rows.Count > 0 Then
                        EP.SetError(TXTTOTAL, "Ticket No Already used in Voucher No. " & DT.Rows(0).Item("BOOKINGNO").ToString)
                        BLN = False
                    End If
                End If


            Next

            If BLN = True And TXTTICKETNO.Text.Length > 0 Then
                Dim objcmn As New ClsCommon
                Dim DT As DataTable
                If edit = False Then
                    DT = objcmn.search(" AIRLINEBOOKINGMASTER.BOOKING_NO AS BOOKINGNO, ISNULL(AIRLINEBOOKINGMASTER_DESC.BOOKING_TICKETNO, '') AS TICKETNO ", " ", " AIRLINEBOOKINGMASTER_DESC INNER JOIN AIRLINEBOOKINGMASTER ON AIRLINEBOOKINGMASTER_DESC.BOOKING_NO = AIRLINEBOOKINGMASTER.BOOKING_NO AND AIRLINEBOOKINGMASTER_DESC.BOOKING_CMPID = AIRLINEBOOKINGMASTER.BOOKING_CMPID AND AIRLINEBOOKINGMASTER_DESC.BOOKING_LOCATIONID = AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID AND AIRLINEBOOKINGMASTER_DESC.BOOKING_YEARID = AIRLINEBOOKINGMASTER.BOOKING_YEARID AND AIRLINEBOOKINGMASTER_DESC.BOOKING_SALEREGID = AIRLINEBOOKINGMASTER.BOOKING_SALEREGISTERID INNER JOIN FLIGHTMASTER ON AIRLINEBOOKINGMASTER.BOOKING_AIRLINEID = FLIGHTMASTER.FLIGHT_ID AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = FLIGHTMASTER.FLIGHT_CMPID AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID = FLIGHTMASTER.FLIGHT_LOCATIONID AND AIRLINEBOOKINGMASTER.BOOKING_YEARID = FLIGHTMASTER.FLIGHT_YEARID ", " AND AIRLINEBOOKINGMASTER_DESC.BOOKING_TICKETNO = '" & TXTTICKETNO.Text.Trim & "' AND AIRLINEBOOKINGMASTER_DESC.BOOKING_CANCELLED = '0' AND FLIGHTMASTER.FLIGHT_NAME = '" & CMBAIRNAME.Text.Trim & "' AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = " & CmpId & " AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID = " & Locationid & " AND AIRLINEBOOKINGMASTER.BOOKING_YEARID = " & YearId & " AND AIRLINEBOOKINGMASTER.BOOKING_SALEREGISTERID = " & SALEregid)
                Else
                    DT = objcmn.search(" AIRLINEBOOKINGMASTER.BOOKING_NO AS BOOKINGNO, ISNULL(AIRLINEBOOKINGMASTER_DESC.BOOKING_TICKETNO, '') AS TICKETNO ", " ", " AIRLINEBOOKINGMASTER_DESC INNER JOIN AIRLINEBOOKINGMASTER ON AIRLINEBOOKINGMASTER_DESC.BOOKING_NO = AIRLINEBOOKINGMASTER.BOOKING_NO AND AIRLINEBOOKINGMASTER_DESC.BOOKING_CMPID = AIRLINEBOOKINGMASTER.BOOKING_CMPID AND AIRLINEBOOKINGMASTER_DESC.BOOKING_LOCATIONID = AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID AND AIRLINEBOOKINGMASTER_DESC.BOOKING_YEARID = AIRLINEBOOKINGMASTER.BOOKING_YEARID AND AIRLINEBOOKINGMASTER_DESC.BOOKING_SALEREGID = AIRLINEBOOKINGMASTER.BOOKING_SALEREGISTERID INNER JOIN FLIGHTMASTER ON AIRLINEBOOKINGMASTER.BOOKING_AIRLINEID = FLIGHTMASTER.FLIGHT_ID AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = FLIGHTMASTER.FLIGHT_CMPID AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID = FLIGHTMASTER.FLIGHT_LOCATIONID AND AIRLINEBOOKINGMASTER.BOOKING_YEARID = FLIGHTMASTER.FLIGHT_YEARID ", " AND AIRLINEBOOKINGMASTER_DESC.BOOKING_TICKETNO = '" & TXTTICKETNO.Text.Trim & "' AND AIRLINEBOOKINGMASTER_DESC.BOOKING_CANCELLED = '0' AND FLIGHTMASTER.FLIGHT_NAME = '" & CMBAIRNAME.Text.Trim & "' AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = " & CmpId & " AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID = " & Locationid & " AND AIRLINEBOOKINGMASTER.BOOKING_YEARID = " & YearId & " AND AIRLINEBOOKINGMASTER.BOOKING_SALEREGISTERID = " & SALEregid & " AND AIRLINEBOOKINGMASTER.BOOKING_NO <> " & TEMPBOOKINGNO)
                End If
                If DT.Rows.Count > 0 Then
                    EP.SetError(TXTTOTAL, "Ticket No Already used in Voucher No. " & DT.Rows(0).Item("BOOKINGNO").ToString)
                    BLN = False
                End If
            End If

            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()

        GRIDBOOKINGS.Enabled = True

        If gridDoubleClick = False Then
            GRIDBOOKINGS.Rows.Add(Val(txtsrno.Text.Trim), TXTPASSNAME.Text.Trim, TXTTEMPSECTOR.Text.Trim, TXTFLTNO.Text.Trim, CMBTYPE.Text.Trim, TXTTICKETNO.Text.Trim, TXTCLASS.Text.Trim, Format(Val(TXTBASIC.Text.Trim), "0.00"), Format(Val(TXTPSF.Text.Trim), "0.00"), Format(Val(TXTGRIDTAX.Text.Trim), "0.00"), Format(Val(TXTTOTAL.Text.Trim), "0.00"), 0)
            getsrno(GRIDBOOKINGS)


            'ADD IN FLIGHT ALSO
            For Each ROW As DataGridViewRow In GRIDSECTOR.Rows
                GRIDFLIGHT.Rows.Add(ROW.Cells(GSECSRNO.Index).Value, ROW.Cells(GSECBOOKSRNO.Index).Value, ROW.Cells(GSECFROM.Index).Value, ROW.Cells(GSECTO.Index).Value, ROW.Cells(GSECFLTNO.Index).Value, ROW.Cells(GSECFLTDATE.Index).Value, ROW.Cells(GARRIVAL.Index).Value, ROW.Cells(GSECCLASS.Index).Value)
            Next


            'ADD IN GRIDPASS ALSO
            GRIDPASS.Rows.Add(Val(txtsrno.Text.Trim), Val(GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(GSRNO.Index).Value), TXTPASSNAME.Text.Trim, "", TXTTICKETNO.Text.Trim, "", "", "", "")
            getsrno(GRIDPASS)


            'ADD IN GRIDPUR ALSO
            GRIDPUR.Rows.Add(Val(txtsrno.Text.Trim), Val(GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(GSRNO.Index).Value), TXTPASSNAME.Text.Trim, TXTTICKETNO.Text.Trim, Format(Val(TXTBASIC.Text.Trim) - Val(TXTBASCIINCOME.Text.Trim), "0.00"), Format(Val(TXTPSF.Text.Trim) - Val(TXTPSFINCOME.Text.Trim), "0.00"), Format(Val(TXTGRIDTAX.Text.Trim) - Val(TXTTAXINCOME.Text.Trim), "0.00"), Format(Val(TXTTOTAL.Text.Trim), "0.00"), 0)
            getsrno(GRIDPUR)

        ElseIf gridDoubleClick = True Then
            GRIDBOOKINGS.Item(GSRNO.Index, temprow).Value = Val(txtsrno.Text.Trim)
            GRIDBOOKINGS.Item(GNAME.Index, temprow).Value = TXTPASSNAME.Text.Trim
            GRIDBOOKINGS.Item(GSECTOR.Index, temprow).Value = TXTTEMPSECTOR.Text.Trim
            GRIDBOOKINGS.Item(GFLTNO.Index, temprow).Value = TXTFLTNO.Text.Trim
            GRIDBOOKINGS.Item(GTYPE.Index, temprow).Value = CMBTYPE.Text.Trim
            GRIDBOOKINGS.Item(GTICKETNO.Index, temprow).Value = TXTTICKETNO.Text.Trim
            GRIDBOOKINGS.Item(GBOOKCLASS.Index, temprow).Value = TXTCLASS.Text.Trim
            GRIDBOOKINGS.Item(GBASIC.Index, temprow).Value = Format(Val(TXTBASIC.Text.Trim), "0.00")
            GRIDBOOKINGS.Item(GPSF.Index, temprow).Value = Format(Val(TXTPSF.Text.Trim), "0.00")
            GRIDBOOKINGS.Item(GTAXES.Index, temprow).Value = Format(Val(TXTGRIDTAX.Text.Trim), "0.00")
            GRIDBOOKINGS.Item(GTOTAL.Index, temprow).Value = Format(Val(TXTTOTAL.Text.Trim), "0.00")


            'FIRST REMOVE OLD RECORDS AND THEN ADD NEW 
LINE1:
            For Each ROW As DataGridViewRow In GRIDFLIGHT.Rows
                If ROW.Cells(GBOOKSRNO.Index).Value = temprow + 1 Then
                    GRIDFLIGHT.Rows.RemoveAt(ROW.Index)
                    GoTo LINE1
                End If
            Next
            For Each ROW As DataGridViewRow In GRIDSECTOR.Rows
                GRIDFLIGHT.Rows.Add(ROW.Cells(GSECSRNO.Index).Value, ROW.Cells(GSECBOOKSRNO.Index).Value, ROW.Cells(GSECFROM.Index).Value, ROW.Cells(GSECTO.Index).Value, ROW.Cells(GSECFLTNO.Index).Value, ROW.Cells(GSECFLTDATE.Index).Value, ROW.Cells(GARRIVAL.Index).Value, ROW.Cells(GSECCLASS.Index).Value)
            Next


            'EDIT IN GRIDPASS
            GRIDPASS.Item(GPASSNAME.Index, temprow).Value = TXTPASSNAME.Text.Trim
            GRIDPASS.Item(GPASSTICKETNO.Index, temprow).Value = TXTTICKETNO.Text.Trim


            'EDIT IN GRIDPUR
            GRIDPUR.Item(GPURPASSNAME.Index, temprow).Value = TXTPASSNAME.Text.Trim
            GRIDPUR.Item(GPURTICKETNO.Index, temprow).Value = TXTTICKETNO.Text.Trim
            GRIDPUR.Item(GPURBASIC.Index, temprow).Value = Format(Val(TXTBASIC.Text.Trim) - Val(TXTBASCIINCOME.Text.Trim), "0.00")
            GRIDPUR.Item(GPURPSF.Index, temprow).Value = Format(Val(TXTPSF.Text.Trim) - Val(TXTPSFINCOME.Text.Trim), "0.00")
            GRIDPUR.Item(GPURTAXES.Index, temprow).Value = Format(Val(TXTGRIDTAX.Text.Trim) - Val(TXTTAXINCOME.Text.Trim), "0.00")
            gridDoubleClick = False
        End If

        GRIDBOOKINGS.FirstDisplayedScrollingRowIndex = GRIDBOOKINGS.RowCount - 1

        txtsrno.Text = GRIDBOOKINGS.RowCount + 1
        TXTPASSNAME.Clear()
        TXTCLASS.Clear()
        If Val(TXTTICKETNO.Text.Trim) > 0 Then
            TXTTICKETNO.Text = Val(TXTTICKETNO.Text.Trim) + 1
        Else
            TXTTICKETNO.Text = TXTTICKETNO.Text
        End If

        TXTTOTAL.Clear()
        TXTPASSNAME.Focus()
        INCOMEBASICGROUP.Visible = False
        INCOMEPSFGROUP.Visible = False
        INCOMETAXGROUP.Visible = False

    End Sub

    Private Sub GRIDBOOKINGS_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDBOOKINGS.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDBOOKINGS.Item(GSRNO.Index, e.RowIndex).Value <> Nothing Then

                If Convert.ToBoolean(GRIDBOOKINGS.Rows(e.RowIndex).Cells(GCANCELLED.Index).Value) = True Then 'If row.Cells(16).Value <> "0" Then 
                    MsgBox("Ticket Locked, Credit Note Already Raised")
                    Exit Sub
                End If

                gridDoubleClick = True
                txtsrno.Text = GRIDBOOKINGS.Item(GSRNO.Index, e.RowIndex).Value.ToString
                TXTPASSNAME.Text = GRIDBOOKINGS.Item(GNAME.Index, e.RowIndex).Value.ToString
                TXTSECTOR.Text = GRIDBOOKINGS.Item(GSECTOR.Index, e.RowIndex).Value.ToString
                TXTFLTNO.Text = GRIDBOOKINGS.Item(GFLTNO.Index, e.RowIndex).Value.ToString
                CMBTYPE.Text = GRIDBOOKINGS.Item(GTYPE.Index, e.RowIndex).Value.ToString
                TXTTICKETNO.Text = GRIDBOOKINGS.Item(GTICKETNO.Index, e.RowIndex).Value.ToString
                TXTCLASS.Text = GRIDBOOKINGS.Item(GBOOKCLASS.Index, e.RowIndex).Value.ToString
                TXTBASIC.Text = GRIDBOOKINGS.Item(GBASIC.Index, e.RowIndex).Value.ToString
                TXTPSF.Text = GRIDBOOKINGS.Item(GPSF.Index, e.RowIndex).Value.ToString
                TXTGRIDTAX.Text = GRIDBOOKINGS.Item(GTAXES.Index, e.RowIndex).Value.ToString
                TXTTOTAL.Text = GRIDBOOKINGS.Item(GTOTAL.Index, e.RowIndex).Value.ToString

                TXTBASCIINCOME.Text = Val(GRIDBOOKINGS.Item(GBASIC.Index, e.RowIndex).Value.ToString) - Val(GRIDPUR.Item(GPURBASIC.Index, e.RowIndex).Value.ToString)
                TXTPSFINCOME.Text = Val(GRIDBOOKINGS.Item(GPSF.Index, e.RowIndex).Value.ToString) - Val(GRIDPUR.Item(GPURPSF.Index, e.RowIndex).Value.ToString)
                TXTTAXINCOME.Text = Val(GRIDBOOKINGS.Item(GTAXES.Index, e.RowIndex).Value.ToString) - Val(GRIDPUR.Item(GPURTAXES.Index, e.RowIndex).Value.ToString)

                temprow = e.RowIndex
                FILLGRIDSECTOR()
                TXTPASSNAME.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDBOOKINGS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDBOOKINGS.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDBOOKINGS.RowCount > 0 Then

                If Convert.ToBoolean(GRIDBOOKINGS.Rows(GRIDBOOKINGS.CurrentRow.Index).Cells(GCANCELLED.Index).Value) = True Then 'If row.Cells(16).Value <> "0" Then 
                    MsgBox("Ticket Locked, Credit Note Raised")
                    Exit Sub
                End If



                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If gridDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                Dim TINDEX As Integer = GRIDBOOKINGS.CurrentRow.Index

                For Each ROW As DataGridViewRow In GRIDFLIGHT.Rows
                    If ROW.Cells(GBOOKSRNO.Index).Value = TINDEX Then GRIDFLIGHT.Rows.RemoveAt(ROW.Index)
                    If ROW.Cells(GBOOKSRNO.Index).Value > TINDEX Then ROW.Cells(GBOOKSRNO.Index).Value = ROW.Cells(GBOOKSRNO.Index).Value - 1
                Next



                If Convert.ToBoolean(GRIDPUR.Rows(TINDEX).Cells(GPURCANCELLED.Index).Value) = True Then 'If row.Cells(16).Value <> "0" Then 
                    MsgBox("Ticket Locked, Debit Note Raised")
                    Exit Sub
                End If


                GRIDBOOKINGS.Rows.RemoveAt(TINDEX)
                GRIDPASS.Rows.RemoveAt(TINDEX)
                GRIDPUR.Rows.RemoveAt(TINDEX)

                getsrno(GRIDBOOKINGS)
                getsrno(GRIDPUR)
                getsrno(GRIDPASS)


                'CHANGE BOOKINGGRIDSRNO IN BOTH THE GRIDS
                For Each ROW As DataGridViewRow In GRIDBOOKINGS.Rows
                    'CHECKING IN PASSENGER GRID
                    For Each PASSROW As DataGridViewRow In GRIDPASS.Rows
                        If ROW.Cells(GTICKETNO.Index).Value = PASSROW.Cells(GPASSTICKETNO.Index).Value Then
                            PASSROW.Cells(GPASSBOOKGRIDSRNO.Index).Value = ROW.Cells(GSRNO.Index).Value
                            Exit For
                        End If
                    Next
                    'CHECKING IN PURCHASE GRID
                    For Each PURROW As DataGridViewRow In GRIDPUR.Rows
                        If ROW.Cells(GTICKETNO.Index).Value = PURROW.Cells(GPURTICKETNO.Index).Value Then
                            PURROW.Cells(GPURPASSGRIDSRNO.Index).Value = ROW.Cells(GSRNO.Index).Value
                            Exit For
                        End If
                    Next
                Next
                PURCHASETOTAL()

            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If tstxtbillno.Text.Trim.Length = 0 Then Exit Sub
            GRIDBOOKINGS.RowCount = 0
            TEMPBOOKINGNO = Val(tstxtbillno.Text)
            If TEMPBOOKINGNO > 0 Then
                edit = True
                AirlineBookings_Load(sender, e)
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

    Private Sub cmbtax_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtax.Validated
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

            Dim OBJBOOKING As New AirlineBookingDetails
            OBJBOOKING.MdiParent = MDIMain
            OBJBOOKING.FRMSTRING = FRMSTRING
            OBJBOOKING.SALEREGID = SALEregid
            OBJBOOKING.Show()
            OBJBOOKING.BringToFront()
            Me.Close()
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
            TEMPBOOKINGNO = Val(txtbookingno.Text) - 1
Line2:
            If TEMPBOOKINGNO > 0 Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" BOOKING_NO ", "", "  AIRLINEBOOKINGMASTER ", " AND AIRLINEBOOKINGMASTER.BOOKING_NO = '" & TEMPBOOKINGNO & "' AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = " & CmpId & " AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID = " & Locationid & " AND AIRLINEBOOKINGMASTER.BOOKING_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    edit = True
                    AirlineBookings_Load(sender, e)
                Else
                    TEMPBOOKINGNO = Val(TEMPBOOKINGNO - 1)
                    GoTo Line2
                End If
            Else
                clear()
                edit = False
            End If

            If GRIDBOOKINGS.RowCount = 0 And TEMPBOOKINGNO > 1 Then
                txtbookingno.Text = TEMPBOOKINGNO
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
            TEMPBOOKINGNO = Val(txtbookingno.Text) + 1
            getmax_BOOKING_no()
            Dim MAXNO As Integer = txtbookingno.Text.Trim
            clear()
            If Val(txtbookingno.Text) - 1 >= TEMPBOOKINGNO Then
                edit = True
                AirlineBookings_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If GRIDBOOKINGS.RowCount = 0 And TEMPBOOKINGNO < MAXNO Then
                txtbookingno.Text = TEMPBOOKINGNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

        '        Try
        '            GRIDBOOKINGS.RowCount = 0
        'LINE1:
        '            TEMPBOOKINGNO = Val(txtbookingno.Text) + 1
        '            getmax_BOOKING_no()
        '            Dim MAXNO As Integer = txtbookingno.Text.Trim
        '            clear()
        '            If Val(txtbookingno.Text) - 1 >= TEMPBOOKINGNO Then
        '                edit = True
        '                AirlineBookings_Load(sender, e)
        '            Else
        '                clear()
        '                edit = False
        '            End If
        '            If GRIDBOOKINGS.RowCount = 0 And TEMPBOOKINGNO < MAXNO Then
        '                txtbookingno.Text = TEMPBOOKINGNO
        '                GoTo LINE1
        '            End If
        '        Catch ex As Exception
        '            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        '        End Try

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
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUP_SECONDARY = 'SUNDRY DEBTORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETBALANCE()
        Try

            LBLPURBAL.Text = "0.00"
            LBLACCBAL.Text = "0.00"

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


            'CR LIMIT OF SALE PARTY
            DT = OBJCMN.search("BOOKING_NO, BOOKING_DATE AS DATE, ISNULL(ACC_CRDAYS,0) AS CRDAYS", "", "AIRLINEBOOKINGMASTER INNER JOIN LEDGERS ON ACC_ID = BOOKING_LEDGERID ", " AND BOOKING_SALEBALANCE > 0 AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND BOOKING_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                For Each DTROW As DataRow In DT.Rows
                    If DTROW("CRDAYS") < DateDiff(DateInterval.Day, Convert.ToDateTime(DTROW("DATE")).Date, Now.Date) And DTROW("CRDAYS") > 0 Then
                        MsgBox("Overdue Outstanding", MsgBoxStyle.Critical)
                        GoTo LINE1
                    End If
                Next
            End If


LINE1:

            'PUR BALANCE
            DT = OBJCMN.search("(CASE WHEN DR > 0 THEN CAST(DR AS VARCHAR) + ' Dr'  ELSE CAST(CR AS VARCHAR) + ' Cr' END) AS PURBAL , isnull(ACC_CRLIMIT,0) AS CRLIMIT, (CASE WHEN DR > 0 THEN DR ELSE CR END) AS BALANCE ", "", "  TRIALBALANCE INNER JOIN LEDGERS ON TRIALBALANCE.LEDGERID = LEDGERS.ACC_ID ", " AND NAME = '" & CMBPURNAME.Text.Trim & "' AND LEDGERS.ACC_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                LBLPURBAL.Text = DT.Rows(0).Item("PURBAL")
                If Val(DT.Rows(0).Item("CRLIMIT")) < Val(DT.Rows(0).Item("BALANCE")) And Val(DT.Rows(0).Item("CRLIMIT")) > 0 Then
                    LBLPURBAL.ForeColor = Color.Red
                Else
                    LBLPURBAL.ForeColor = Color.Green
                End If
            End If


            'CR LIMIT OF PUR PARTY
            DT = OBJCMN.search("BOOKING_NO, BOOKING_DATE AS DATE, ISNULL(ACC_CRDAYS,0) AS CRDAYS", "", "AIRLINEBOOKINGMASTER INNER JOIN LEDGERS ON ACC_ID = BOOKING_PURLEDGERID ", " AND BOOKING_PURBALANCE > 0 AND ACC_CMPNAME = '" & CMBPURNAME.Text.Trim & "' AND BOOKING_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                For Each DTROW As DataRow In DT.Rows
                    If DTROW("CRDAYS") < DateDiff(DateInterval.Day, Convert.ToDateTime(DTROW("DATE")).Date, Now.Date) And DTROW("CRDAYS") > 0 Then
                        MsgBox("Overdue Outstanding", MsgBoxStyle.Critical)
                        GoTo LINE2
                    End If
                Next
            End If
LINE2:

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBACCCODE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBACCCODE.Validated
        Try
            If CMBACCCODE.Text.Trim <> "" Then GETBALANCE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBACCCODE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBACCCODE.Validating
        Try
            If CMBACCCODE.Text.Trim <> "" Then ACCCODEVALIDATE(CMBACCCODE, CMBNAME, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'", "SUNDRY DEBTORS")
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

    Private Sub CMBNAME_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Validated
        Try
            If CMBNAME.Text.Trim <> "" Then
                Dim OBJCMN1 As New ClsCommon
                Dim DT1 As DataTable = OBJCMN1.search(" ISNULL(STATEMASTER.state_remark, '') AS STATECODE ", "", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_cmpid = GROUPMASTER.group_cmpid AND LEDGERS.Acc_locationid = GROUPMASTER.group_locationid AND LEDGERS.Acc_yearid = GROUPMASTER.group_yearid AND LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id ", " and LEDGERS.acc_cmpname = '" & CMBNAME.Text.Trim & "' and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' and LEDGERS.acc_YEARid = " & YearId)
                If DT1.Rows.Count > 0 Then TXTSTATECODE.Text = DT1.Rows(0).Item("STATECODE")

                GETBALANCE()
                GETHSNCODE()
            End If


            If TXTMOBILE.Text.Trim = "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" ISNULL(ACC_MOBILE,'') , ISNULL(ACC_EMAIL,'') ", "", " LEDGERS", " AND ACC_CMPNAME ='" & CMBNAME.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    TXTMOBILE.Text = DT.Rows(0).Item(0)
                    TXTEMAILADD.Text = DT.Rows(0).Item(1)
                End If
            End If

            'If CMBNAME.Text.Trim <> "" Then

            'End If
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

                If lbllocked.Visible = True Or lblcancelled.Visible = True Then
                    MsgBox("Booking Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                Dim tempmsg As Integer = MsgBox("Delete Booking Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                If tempmsg = vbYes Then

                    Dim OBJBOOKING As New ClsAirlineBookingMaster
                    Dim ALPARAVAL As New ArrayList

                    If FRMSTRING = "INTERNATIONAL" Then
                        ALPARAVAL.Add("INTAIRLINE PURCHASE REGISTER")
                        ALPARAVAL.Add("INTAIRLINE SALE REGISTER")
                    Else
                        ALPARAVAL.Add("AIRLINE PURCHASE REGISTER")
                        ALPARAVAL.Add("AIRLINE SALE REGISTER")
                    End If
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

    Private Sub CMBBOOKEDBY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBBOOKEDBY.Validating
        Try
            If CMBBOOKEDBY.Text.Trim <> "" Then BOOKEDBYvalidate(CMBBOOKEDBY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CALC()
        Try
            TXTTOTAL.Text = Format((Val(TXTBASIC.Text.Trim) + Val(TXTPSF.Text.Trim) + Val(TXTGRIDTAX.Text.Trim)), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
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

    Private Sub TXTCOMMRECDPER_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCOMMRECDPER.KeyPress
        numdotkeypress(e, TXTCOMMRECDPER, Me)
    End Sub

    Private Sub TXTCOMMRECDPER_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCOMMRECDPER.Validated
        PURCHASETOTAL()
    End Sub

    Private Sub TXTCOMMRECDRS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCOMMRECDRS.KeyPress
        numdotkeypress(e, TXTCOMMRECDRS, Me)
    End Sub

    Private Sub TXTCOMMRECDRS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCOMMRECDRS.Validated
        PURCHASETOTAL()
    End Sub

    Private Sub TXTDISCRECDPER_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTDISCRECDPER.KeyPress
        numdotkeypress(e, TXTDISCRECDPER, Me)
    End Sub

    Private Sub TXTDISCRECDPER_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTDISCRECDPER.Validated
        PURCHASETOTAL()
    End Sub

    Private Sub TXTDISCRECDRS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTDISCRECDRS.KeyPress
        numdotkeypress(e, TXTDISCRECDRS, Me)
    End Sub

    Private Sub TXTDISCRECDRS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTDISCRECDRS.Validated
        PURCHASETOTAL()
    End Sub

    Private Sub TXTPURAMT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPURAMT.KeyPress
        numdotkeypress(e, TXTPURAMT, Me)
    End Sub

    Private Sub TXTPURAMT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTPURAMT.Validated
        PURCHASETOTAL()
    End Sub

    Private Sub TXTPUROTHERCHGS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPUROTHERCHGS.KeyPress
        numdotkeypress(e, TXTPUROTHERCHGS, Me)
    End Sub

    Private Sub TXTPUROTHERCHGS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTPUROTHERCHGS.Validated
        PURCHASETOTAL()
    End Sub

    Private Sub TXTPURROUNDOFF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTPURROUNDOFF.Validated
        PURCHASETOTAL()
    End Sub

    Private Sub TXTPURTAX_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTPURTAX.Validated
        PURCHASETOTAL()
    End Sub

    Private Sub CMBPURTAX_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPURTAX.Enter
        Try
            If CMBPURTAX.Text.Trim = "" Then filltax(CMBPURTAX, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBPURTAX_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPURTAX.Validating
        Try
            If CMBPURTAX.Text.Trim <> "" Then TAXvalidate(CMBPURTAX, e, Me)
            PURCHASETOTAL()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTPURTDSPER_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPURTDSPER.KeyPress
        numdotkeypress(e, TXTPURTDSPER, Me)
    End Sub

    Private Sub TXTPURTDSPER_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTPURTDSPER.Validated
        PURCHASETOTAL()
    End Sub

    Private Sub TXTPURTDSRS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPURTDSRS.KeyPress
        numdotkeypress(e, TXTPURTDSRS, Me)
    End Sub

    Private Sub TXTPURTDSRS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTPURTDSRS.Validated, TXTPURSERVCHGS.Validated
        PURCHASETOTAL()
    End Sub

    Private Sub cmbaddtax_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBADDTAX.GotFocus
        Try
            If CMBADDTAX.Text.Trim = "" Then filltax(CMBADDTAX, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBADDTAX_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBADDTAX.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub cmbADDtax_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBADDTAX.Validating
        Try
            If CMBADDTAX.Text.Trim <> "" Then TAXvalidate(CMBADDTAX, e, Me)
            total()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBPURADDTAX_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPURADDTAX.Enter
        Try
            If CMBPURADDTAX.Text.Trim = "" Then filltax(CMBPURADDTAX, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBPURADDTAX_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBPURADDTAX.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub CMBPURADDTAX_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPURADDTAX.Validating
        Try
            If CMBPURADDTAX.Text.Trim <> "" Then TAXvalidate(CMBPURADDTAX, e, Me)
            PURCHASETOTAL()
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

    Private Sub PBDICSRECDDEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBDICSRECDDEL.Click
        Try
            TXTDISCRECDPER.Text = 0.0
            TXTDISCRECDRS.Text = 0.0
            PURCHASETOTAL()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PBCOMMRECDDEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBCOMMRECDDEL.Click
        Try
            TXTCOMMRECDPER.Text = 0.0
            TXTCOMMRECDRS.Text = 0.0
            PURCHASETOTAL()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PBPURTDSDEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBPURTDSDEL.Click
        Try
            TXTPURTDSPER.Text = 0.0
            TXTPURTDSRS.Text = 0.0
            PURCHASETOTAL()
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

    Private Sub CMBPURCODE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPURCODE.Validated
        Try
            If CMBPURCODE.Text.Trim <> "" Then GETBALANCE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPURCODE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPURCODE.Validating
        Try
            If CMBPURCODE.Text.Trim <> "" Then ACCCODEVALIDATE(CMBPURCODE, CMBPURNAME, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'", "SUNDRY CREDITORS")
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
                GETBALANCE()

                Dim OBJCMN1 As New ClsCommon
                Dim DT1 As DataTable = OBJCMN1.search(" ISNULL(STATEMASTER.state_remark, '') AS PURSTATECODE ", "", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_cmpid = GROUPMASTER.group_cmpid AND LEDGERS.Acc_locationid = GROUPMASTER.group_locationid AND LEDGERS.Acc_yearid = GROUPMASTER.group_yearid AND LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id ", " and LEDGERS.acc_cmpname = '" & CMBPURNAME.Text.Trim & "' and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' and LEDGERS.acc_YEARid = " & YearId)
                If DT1.Rows.Count > 0 Then TXTPURSTATECODE.Text = DT1.Rows(0).Item("PURSTATECODE")

                GETHSNCODE()
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

    Private Sub ToolStripCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripCancel.Click
        Try
            'MsgBox("Cancellation Not Allowed, Make Credit/Debit Note", MsgBoxStyle.Critical)
            'Exit Sub
            If edit = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                TEMPMSG = MsgBox("Wish to Cancel Booking Voucher?", MsgBoxStyle.YesNo, "TRAVELMATE")
                If TEMPMSG = vbYes Then
                    Dim OBJHOTEL As New ClsAirlineBookingMaster
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(TEMPBOOKINGNO)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Locationid)
                    ALPARAVAL.Add(YearId)

                    OBJHOTEL.alParaval = ALPARAVAL
                    Dim INTRESULT As Integer = OBJHOTEL.CANCEL
                    'TEMPMSG = MsgBox("Wish to Intimate Guest?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    'If TEMPMSG = vbYes Then
                    '    'SENDMSG("Hi, Your booking in " & cmbhotelname.Text.Trim & " is between " & ARRIVALDATE.Value.Date & " and " & DEPARTDATE.Value.Date & " is Cancelled")
                    'End If
                    MsgBox("Booking Cancelled")
                    clear()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripprint.Click
        Try
            If edit = True Then PRINTREPORT(TEMPBOOKINGNO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTREPORT(ByVal BOOKNO As Integer)
        Try
            If CMBPRINT.Text = "" Or CMBPRINT.Text = "All" Then
                If ClientName = "AERO" Or ClientName = "SAFAR" Or ClientName = "BARODA" Then
                    TEMPMSG = MsgBox("Wish to Print Voucher?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbYes Then
                        Dim OBJINV As New AirlineBookingVoucherDesign
                        OBJINV.MdiParent = MDIMain
                        OBJINV.BOOKINGNO = BOOKNO
                        OBJINV.SALEREGISTERID = SALEregid
                        OBJINV.PRINTTAX = CHKTAXPRINT.CheckState
                        OBJINV.PRINTGUESTNAME = CHKPRINTNAME.CheckState
                        OBJINV.PRINTOTHERCHGS = CHKOTHERCHGSPRINT.CheckState
                        OBJINV.PRINTADDDISC = CHKADDDISC.CheckState
                        OBJINV.FRMSTRING = "VOUCHER"
                        OBJINV.Show()
                    End If
                End If


                TEMPMSG = MsgBox("Wish to Print Invoice?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim OBJINV As New AirlineBookingVoucherDesign
                    OBJINV.MdiParent = MDIMain
                    OBJINV.BOOKINGNO = BOOKNO
                    OBJINV.BOOKINGDATE = Convert.ToDateTime(BOOKINGDATE.Text).Date
                    OBJINV.SALEREGISTERID = SALEregid
                    OBJINV.PRINTTAX = CHKTAXPRINT.CheckState
                    OBJINV.PRINTGUESTNAME = CHKPRINTNAME.CheckState
                    OBJINV.PRINTOTHERCHGS = CHKOTHERCHGSPRINT.CheckState
                    OBJINV.PRINTADDDISC = CHKADDDISC.CheckState
                    OBJINV.FRMSTRING = "INVOICE"
                    If ClientName = "UTTARAKHAND" Then OBJINV.SUBJECT = "Invoice No. " & BOOKNO & " Ref No. " & TXTREFNO.Text.Trim
                    OBJINV.Show()
                End If

                If ClientName = "SHREEJI" Or ClientName = "BARODA" Then
                    TEMPMSG = MsgBox("Wish to Print Office Copy of Invoice?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbYes Then
                        Dim OBJINV As New AirlineBookingVoucherDesign
                        OBJINV.MdiParent = MDIMain
                        OBJINV.BOOKINGNO = BOOKNO
                        OBJINV.SALEREGISTERID = SALEregid
                        OBJINV.PRINTTAX = CHKTAXPRINT.CheckState
                        OBJINV.PRINTGUESTNAME = CHKPRINTNAME.CheckState
                        OBJINV.PRINTOTHERCHGS = CHKOTHERCHGSPRINT.CheckState
                        OBJINV.PRINTADDDISC = CHKADDDISC.CheckState
                        OBJINV.FRMSTRING = "INVOICEOFFICE"
                        OBJINV.Show()
                    End If
                End If

            ElseIf CMBPRINT.Text = "Voucher" Then
                If ClientName = "SHREEJI" Or ClientName = "SAFAR" Or ClientName = "BARODA" Then
                    Dim OBJINV As New AirlineBookingVoucherDesign
                    OBJINV.MdiParent = MDIMain
                    OBJINV.BOOKINGNO = BOOKNO
                    OBJINV.SALEREGISTERID = SALEregid
                    OBJINV.PRINTTAX = CHKTAXPRINT.CheckState
                    OBJINV.PRINTGUESTNAME = CHKPRINTNAME.CheckState
                    OBJINV.PRINTOTHERCHGS = CHKOTHERCHGSPRINT.CheckState
                    OBJINV.PRINTADDDISC = CHKADDDISC.CheckState
                    OBJINV.FRMSTRING = "VOUCHER"
                    OBJINV.Show()
                End If
            ElseIf CMBPRINT.Text = "Invoice" Then
                Dim OBJINV As New AirlineBookingVoucherDesign
                OBJINV.MdiParent = MDIMain
                OBJINV.BOOKINGNO = BOOKNO
                OBJINV.SALEREGISTERID = SALEregid
                OBJINV.PRINTTAX = CHKTAXPRINT.CheckState
                OBJINV.PRINTGUESTNAME = CHKPRINTNAME.CheckState
                OBJINV.PRINTOTHERCHGS = CHKOTHERCHGSPRINT.CheckState
                OBJINV.PRINTADDDISC = CHKADDDISC.CheckState
                OBJINV.FRMSTRING = "INVOICE"
                If ClientName = "UTTARAKHAND" Then OBJINV.SUBJECT = "Invoice No. " & BOOKNO & " Ref No. " & TXTREFNO.Text.Trim
                OBJINV.Show()

                If ClientName = "SHREEJI" Or ClientName = "BARODA" Then
                    TEMPMSG = MsgBox("Wish to Print Office Copy of Invoice?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbYes Then
                        Dim OBJINV1 As New AirlineBookingVoucherDesign
                        OBJINV1.MdiParent = MDIMain
                        OBJINV1.BOOKINGNO = BOOKNO
                        OBJINV1.SALEREGISTERID = SALEregid
                        OBJINV1.PRINTTAX = CHKTAXPRINT.CheckState
                        OBJINV1.PRINTGUESTNAME = CHKPRINTNAME.CheckState
                        OBJINV1.PRINTOTHERCHGS = CHKOTHERCHGSPRINT.CheckState
                        OBJINV1.PRINTADDDISC = CHKADDDISC.CheckState
                        OBJINV1.FRMSTRING = "INVOICEOFFICE"
                        OBJINV1.Show()
                    End If
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

    Private Sub GRIDPUR_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDPUR.CellValidating
        Try
            Dim colNum As Integer = GRIDPUR.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case GPURBASIC.Index, GPURPSF.Index, GPURTAXES.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDPUR.CurrentCell.Value = Nothing Then GRIDPUR.CurrentCell.Value = "0.00"
                        GRIDPUR.CurrentCell.Value = Convert.ToDecimal(GRIDPUR.Item(colNum, e.RowIndex).Value)
                        '' everything is good
                        PURCHASETOTAL()
                    Else
                        MessageBox.Show("Invalid Number Entered")
                        e.Cancel = True
                        Exit Sub
                    End If

            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDPUR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDPUR.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDBOOKINGS.RowCount > 0 Then

                'dont allow user TO DFELETE IN GRIDPUR
                MessageBox.Show("You Cannot Delete This Row, Delete from Booking Tab")
                Exit Sub

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPUREXTRACHGS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPUREXTRACHGS.KeyPress
        Try
            numdotkeypress(e, TXTPUREXTRACHGS, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPUREXTRACHGS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTPUREXTRACHGS.Validated
        PURCHASETOTAL()
    End Sub

    Private Sub TXTEXTRACHGS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTEXTRACHGS.KeyPress
        numdotkeypress(e, TXTEXTRACHGS, Me)
    End Sub

    Private Sub TXTEXTRACHGS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTEXTRACHGS.Validated
        total()
    End Sub

    Private Sub cmdshowdetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowdetails.Click
        Try
            Dim OBJRECPAY As New ShowRecPay
            OBJRECPAY.MdiParent = MDIMain
            If FRMSTRING = "DOMESTIC" Then
                OBJRECPAY.PURBILLINITIALS = "AP-" & TEMPBOOKINGNO
                OBJRECPAY.SALEBILLINITIALS = "AS-" & TEMPBOOKINGNO
            Else
                OBJRECPAY.PURBILLINITIALS = "IAP-" & TEMPBOOKINGNO
                OBJRECPAY.SALEBILLINITIALS = "IAS-" & TEMPBOOKINGNO
            End If
            OBJRECPAY.Show()
        Catch ex As Exception
            Throw ex
        End Try
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
            If edit = True Then
                MsgBox("Copy Allowed only in Fresh mode", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If TXTCOPY.Text.Trim <> "" Then
                TEMPMSG = MsgBox("Wish to Copy Voucher No " & TXTCOPY.Text.Trim & "?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then

                    Dim ALPARAVAL As New ArrayList
                    Dim OBJBOOKING As New ClsAirlineBookingMaster()

                    ALPARAVAL.Add(TXTCOPY.Text.Trim)
                    ALPARAVAL.Add(SALEregid)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Locationid)
                    ALPARAVAL.Add(YearId)

                    OBJBOOKING.alParaval = ALPARAVAL
                    Dim dt As DataTable = OBJBOOKING.SELECTBOOKING()


                    If dt.Rows.Count > 0 Then
                        For Each dr As DataRow In dt.Rows
                            TXTSTATECODE.Text = dr("STATECODE")
                            TXTPURSTATECODE.Text = dr("PURSTATECODE")
                            BOOKINGDATE.Text = Format(Convert.ToDateTime(dr("BOOKINGDATE")), "dd/MM/yyyy")

                            CMBAIRCODE.Text = Convert.ToString(dr("AIRCODE"))
                            CMBAIRNAME.Text = Convert.ToString(dr("AIRNAME"))
                            CMBPURCODE.Text = Convert.ToString(dr("PURCODE"))
                            CMBPURNAME.Text = Convert.ToString(dr("PURNAME"))
                            CMBACCCODE.Text = Convert.ToString(dr("ACCCODE"))
                            CMBNAME.Text = Convert.ToString(dr("ACCNAME"))

                            'TXTPARTYREFNO.Text = dr("PARTYREFNO")
                            'TXTPNRNO.Text = dr("PNRNO")
                            'TXTREFNO.Text = dr("REFNO")
                            'CMBBSP.Text = dr("BSPSALE")

                            CMBCRSTYPE.Text = Convert.ToString(dr("CRSTYPE"))
                            'CMBBSP.Text = dr("BSPSALE")

                            If Convert.ToBoolean(dr("BSPSALE")) = True Then
                                CMBBSP.Text = "Yes"
                            Else
                                CMBBSP.Text = "No"
                            End If

                            If Convert.ToBoolean(dr("COUPONSALE")) = True Then
                                CMBCOUPON.Text = "Yes"
                            Else
                                CMBCOUPON.Text = "No"
                            End If

                            TICKETDATE.Value = Convert.ToDateTime(dr("TICKETDATE"))
                            RETURNDATE.Value = Convert.ToDateTime(dr("RETURNDATE"))
                            TXTPARTYREFNO.Text = dr("PARTYREFNO")
                            TXTREFNO.Text = dr("REFNO")
                            TXTPRINTNAME.Text = dr("PRINTNAME")
                            TXTEMAILADD.Text = dr("EMAILADD")
                            TXTMOBILE.Text = dr("MOBILENO")
                            TXTPNRNO.Text = dr("PNRNO")
                            TXTAIRLINEPNR.Text = dr("AIRLINEPNR")
                            TXTCRSPNR.Text = dr("CRSPNR")


                            'PURCHASE VALUES
                            TXTPURAMT.Text = dr("PURAMT")
                            TXTDISCRECDPER.Text = dr("DISCRECDPER")
                            TXTDISCRECDRS.Text = dr("DISCRECDRS")
                            TXTCOMMRECDPER.Text = dr("COMMRECDPER")
                            TXTCOMMRECDRS.Text = dr("COMMRECDRS")
                            TXTPURTDSPER.Text = dr("PURTDSPER")
                            TXTPURTDSRS.Text = dr("PURTDSRS")
                            TXTPUREXTRACHGS.Text = dr("PUREXTRACHGS")
                            CMBPURTAX.Text = dr("PURTAXNAME")
                            TXTPURTAX.Text = dr("PURTAX")
                            CMBPURADDTAX.Text = dr("PURADDTAXNAME")
                            TXTPURADDTAX.Text = dr("PURADDTAX")
                            txtPurDiscountPerc.Text = dr("PURDISCPERC")
                            txtPurDiscountAmount.Text = Format(dr("PURDISCAMT"), "0.00")
                            txtPurAddDiscountAmount.Text = Format(dr("PURADDDISCAMT"), "0.00")

                            If Convert.ToBoolean(dr("PURCOMMTAX")) = True Then
                                CHKPURTAXONCOMM.Checked = True
                            Else
                                CHKPURTAXONCOMM.Checked = False
                            End If

                            CMBPUROTHERCHGS.Text = dr("PUROTHERCHGSNAME")
                            If dr("PUROTHERCHGS") > 0 Then
                                TXTPUROTHERCHGS.Text = dr("PUROTHERCHGS")
                                CMBPURADDSUB.Text = "Add"
                            Else
                                TXTPUROTHERCHGS.Text = dr("PUROTHERCHGS") * (-1)
                                CMBPURADDSUB.Text = "Sub."
                            End If
                            TXTPURROUNDOFF.Text = dr("PURROUNDOFF")


                            CMBBOOKEDBY.Text = dr("BOOKEDBY")
                            CMBSOURCE.Text = dr("SOURCE")


                            'SALE VALUES
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
                            txtDiscountPerc.Text = dr("SALEDISCPERC")
                            txtDiscountAmount.Text = Format(dr("SALEDISCAMT"), "0.00")
                            txtAddDiscountAmount.Text = Format(dr("SALEADDDISCAMT"), "0.00")
                            CMBOTHERCHGS.Text = dr("OTHERCHGSNAME")
                            If dr("OTHERCHGS") > 0 Then
                                txtotherchg.Text = dr("OTHERCHGS")
                                cmbaddsub.Text = "Add"
                            Else
                                txtotherchg.Text = dr("OTHERCHGS") * (-1)
                                cmbaddsub.Text = "Sub."
                            End If
                            txtroundoff.Text = dr("ROUNDOFF")


                            txtremarks.Text = Convert.ToString(dr("REMARKS"))


                            TXTPURAMTPAID.Text = 0
                            TXTPUREXTRAAMT.Text = 0
                            TXTPURRETURN.Text = 0
                            TXTPURBAL.Text = 0

                            TXTSALEAMTREC.Text = 0
                            TXTSALEEXTRAAMT.Text = 0
                            TXTSALERETURN.Text = 0
                            TXTSALEBAL.Text = 0

                            TXTBAL.Text = Format(Val(TXTSALEBAL.Text), "0.00")

                            chkdispute.Checked = Convert.ToBoolean(dr("DISPUTE"))
                            CHKBILLCHECK.Checked = Convert.ToBoolean(dr("BILLCHECKED"))
                            CHKREFUNDED.Checked = Convert.ToBoolean(dr("REFUNDED"))
                            CHKFAILED.Checked = Convert.ToBoolean(dr("FAILED"))

                            TXTHSNCODE.Text = dr("HSNCODE")
                            TXTPURHSNCODE.Text = dr("PURHSNCODE")

                            If Convert.ToBoolean(dr("MANUALGST")) = False Then CHKMANUAL.Checked = False Else CHKMANUAL.Checked = True
                            If CHKMANUAL.Checked = True Then
                                TXTCGSTAMT.Text = Format(Val(dr("CGSTAMT")), "0.00")
                                TXTSGSTAMT.Text = Format(Val(dr("SGSTAMT")), "0.00")
                                TXTIGSTAMT.Text = Format(Val(dr("IGSTAMT")), "0.00")

                            End If
                            If Convert.ToBoolean(dr("PURMANUALGST")) = False Then CHKPURMANUAL.Checked = False Else CHKPURMANUAL.Checked = True

                            If CHKPURMANUAL.Checked = True Then
                                TXTPURCGSTAMT.Text = Format(Val(dr("PURCGSTAMT")), 0.0)
                                TXTPURSGSTAMT.Text = Format(Val(dr("PURSGSTAMT")), 0.0)
                                TXTPURIGSTAMT.Text = Format(Val(dr("PURIGSTAMT")), 0.0)
                            End If

                            TXTCGSTPER.Text = dr("CGSTPER")
                            TXTCGSTAMT.Text = dr("CGSTAMT")
                            TXTSGSTPER.Text = dr("SGSTPER")
                            TXTSGSTAMT.Text = dr("SGSTAMT")
                            TXTIGSTPER.Text = dr("IGSTPER")
                            TXTIGSTAMT.Text = dr("IGSTAMT")
                            TXTPURSERVCHGS.Text = dr("PURTAXSERVCHGSAMT")
                            CHKPURTAXSERVCHGS.Checked = Convert.ToBoolean(dr("PURTAXSERVCHGS"))
                            TXTPURCGSTPER.Text = dr("PURCGSTPER")
                            TXTPURCGSTAMT.Text = dr("PURCGSTAMT")
                            TXTPURSGSTPER.Text = dr("PURSGSTPER")
                            TXTPURSGSTAMT.Text = dr("PURSGSTAMT")
                            TXTPURIGSTPER.Text = dr("PURIGSTPER")
                            TXTPURIGSTAMT.Text = dr("PURIGSTAMT")

                            CHKTAXSERVCHGS.Checked = Convert.ToBoolean(dr("TAXSERVCHGS"))

                            GRIDBOOKINGS.Rows.Add(dr("GRIDSRNO").ToString, dr("PASSNAME").ToString, dr("SECTOR").ToString, dr("FLTNO"), dr("TYPE").ToString, dr("TICKETNO").ToString, dr("CLASS").ToString, Format(Val(dr("BASIC")), "0.00"), Format(Val(dr("PSF")), "0.00"), Format(Val(dr("GRIDTAXES")), "0.00"), Format(Val(dr("AMT")), "0.00"), 0)

                        Next

                        GRIDBOOKINGS.FirstDisplayedScrollingRowIndex = GRIDBOOKINGS.RowCount - 1

                        'GET GRIDPASS DATA
                        Dim OBJCMN As New ClsCommon
                        Dim dttable As DataTable = OBJCMN.search("  AIRLINEBOOKINGMASTER_PASSDESC.BOOKING_GRIDSRNO AS GRIDSRNO, AIRLINEBOOKINGMASTER_PASSDESC.BOOKING_PASSGRIDSRNO AS PASSGRIDSRNO, AIRLINEBOOKINGMASTER_PASSDESC.BOOKING_PASSNAME AS PASSNAME, AIRLINEBOOKINGMASTER_PASSDESC.BOOKING_DESC AS [DESC], AIRLINEBOOKINGMASTER_PASSDESC.BOOKING_TICKETNO AS TICKETNO, AIRLINEBOOKINGMASTER_PASSDESC.BOOKING_SEX AS SEX, AIRLINEBOOKINGMASTER_PASSDESC.BOOKING_PANNO AS PANNO, AIRLINEBOOKINGMASTER_PASSDESC.BOOKING_PASSPORTNO AS PASSPORTNO, AIRLINEBOOKINGMASTER_PASSDESC.BOOKING_ISSUEDFROM AS ISSUEDFROM ", "", " AIRLINEBOOKINGMASTER_PASSDESC INNER JOIN AIRLINEBOOKINGMASTER ON AIRLINEBOOKINGMASTER_PASSDESC.BOOKING_NO = AIRLINEBOOKINGMASTER.BOOKING_NO AND AIRLINEBOOKINGMASTER_PASSDESC.BOOKING_CMPID = AIRLINEBOOKINGMASTER.BOOKING_CMPID AND AIRLINEBOOKINGMASTER_PASSDESC.BOOKING_LOCATIONID = AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID AND AIRLINEBOOKINGMASTER_PASSDESC.BOOKING_YEARID = AIRLINEBOOKINGMASTER.BOOKING_YEARID AND AIRLINEBOOKINGMASTER_PASSDESC.BOOKING_SALEREGID = AIRLINEBOOKINGMASTER.BOOKING_SALEREGISTERID ", " AND AIRLINEBOOKINGMASTER.BOOKING_NO = " & TXTCOPY.Text.Trim & " AND AIRLINEBOOKINGMASTER.BOOKING_SALEREGISTERID = " & SALEregid & " AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = " & CmpId & " AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID  = " & Locationid & " AND AIRLINEBOOKINGMASTER.BOOKING_YEARID = " & YearId & " ORDER BY AIRLINEBOOKINGMASTER_PASSDESC.BOOKING_GRIDSRNO")
                        If dttable.Rows.Count > 0 Then
                            For Each DR As DataRow In dttable.Rows
                                GRIDPASS.Rows.Add(DR("GRIDSRNO").ToString, DR("PASSGRIDSRNO").ToString, DR("PASSNAME").ToString, DR("DESC").ToString, DR("TICKETNO"), DR("SEX"), DR("PANNO"), DR("PASSPORTNO"), DR("ISSUEDFROM"))
                            Next
                        End If



                        'GET GRIDPUR DATA
                        dttable = OBJCMN.search("  AIRLINEBOOKINGMASTER_PURDESC.BOOKING_GRIDSRNO AS GRIDSRNO, AIRLINEBOOKINGMASTER_PURDESC.BOOKING_PASSGRIDSRNO AS PASSGRIDSRNO, AIRLINEBOOKINGMASTER_PURDESC.BOOKING_PASSNAME AS PASSNAME, AIRLINEBOOKINGMASTER_PURDESC.BOOKING_TICKETNO AS TICKETNO, AIRLINEBOOKINGMASTER_PURDESC.BOOKING_BASIC AS BASIC, AIRLINEBOOKINGMASTER_PURDESC.BOOKING_PSF AS PSF, AIRLINEBOOKINGMASTER_PURDESC.BOOKING_TAXES AS TAXES, AIRLINEBOOKINGMASTER_PURDESC.BOOKING_AMT AS AMT, AIRLINEBOOKINGMASTER_PURDESC.BOOKING_CANCELLED AS CANCELLED ", "", " AIRLINEBOOKINGMASTER_PURDESC INNER JOIN AIRLINEBOOKINGMASTER ON AIRLINEBOOKINGMASTER_PURDESC.BOOKING_NO = AIRLINEBOOKINGMASTER.BOOKING_NO AND AIRLINEBOOKINGMASTER_PURDESC.BOOKING_CMPID = AIRLINEBOOKINGMASTER.BOOKING_CMPID AND AIRLINEBOOKINGMASTER_PURDESC.BOOKING_LOCATIONID = AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID AND AIRLINEBOOKINGMASTER_PURDESC.BOOKING_YEARID = AIRLINEBOOKINGMASTER.BOOKING_YEARID AND AIRLINEBOOKINGMASTER_PURDESC.BOOKING_SALEREGID = AIRLINEBOOKINGMASTER.BOOKING_SALEREGISTERID ", " AND AIRLINEBOOKINGMASTER.BOOKING_NO = " & TXTCOPY.Text.Trim & " AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = " & CmpId & " AND AIRLINEBOOKINGMASTER.BOOKING_SALEREGISTERID = " & SALEregid & " AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID  = " & Locationid & " AND AIRLINEBOOKINGMASTER.BOOKING_YEARID = " & YearId & " ORDER BY AIRLINEBOOKINGMASTER_PURDESC.BOOKING_GRIDSRNO")
                        If dttable.Rows.Count > 0 Then
                            For Each DR As DataRow In dttable.Rows
                                GRIDPUR.Rows.Add(DR("GRIDSRNO").ToString, DR("PASSGRIDSRNO").ToString, DR("PASSNAME").ToString, DR("TICKETNO").ToString, Format(Val(DR("BASIC")), "0.00"), Format(DR("PSF"), "0.00"), Format(DR("TAXES"), "0.00"), Format(DR("AMT"), "0.00"), 0)
                            Next
                        End If


                        'GET GRIDFLIGHT DATA
                        dttable = OBJCMN.search(" AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_GRIDSRNO AS GRIDSRNO, AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_BOOKSRNO AS BOOKSRNO, ISNULL(FROMSECTORMASTER.SECTOR_NAME,'') AS FROMSEC, ISNULL(TOSECTORMASTER.SECTOR_NAME,'') AS TOSEC, AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_FLIGHTNO AS FLIGHTNO,  AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_FLIGHTDATE AS FLIGHTDATE,ISNULL(AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_ARRIVES,'') AS ARRIVES, CLASSMASTER.CLASS_NAME AS CLASS ", "", " SECTORMASTER AS TOSECTORMASTER RIGHT OUTER JOIN AIRLINEBOOKINGMASTER_FLIGHTDESC LEFT OUTER JOIN CLASSMASTER ON AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_YEARID = CLASSMASTER.CLASS_YEARID AND  AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_LOCATIONID = CLASSMASTER.CLASS_LOCATIONID AND AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_CMPID = CLASSMASTER.CLASS_CMPID AND AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_CLASSID = CLASSMASTER.CLASS_ID ON TOSECTORMASTER.SECTOR_ID = AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_TOID AND TOSECTORMASTER.SECTOR_CMPID = AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_CMPID AND TOSECTORMASTER.SECTOR_LOCATIONID = AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_LOCATIONID AND TOSECTORMASTER.SECTOR_YEARID = AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_YEARID LEFT OUTER JOIN SECTORMASTER AS FROMSECTORMASTER ON AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_FROMID = FROMSECTORMASTER.SECTOR_ID AND AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_CMPID = FROMSECTORMASTER.SECTOR_CMPID AND AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_LOCATIONID = FROMSECTORMASTER.SECTOR_LOCATIONID AND AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_YEARID = FROMSECTORMASTER.SECTOR_YEARID ", " AND AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_NO = " & TXTCOPY.Text.Trim & " AND AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_SALEREGID = " & SALEregid & " AND AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_CMPID = " & CmpId & " AND AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_LOCATIONID  = " & Locationid & " AND AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_YEARID = " & YearId & " ORDER BY AIRLINEBOOKINGMASTER_FLIGHTDESC.BOOKING_GRIDSRNO")
                        If dttable.Rows.Count > 0 Then
                            For Each DR As DataRow In dttable.Rows
                                GRIDFLIGHT.Rows.Add(DR("GRIDSRNO").ToString, DR("BOOKSRNO"), DR("FROMSEC").ToString, DR("TOSEC").ToString, DR("FLIGHTNO").ToString, Format(Convert.ToDateTime(DR("FLIGHTDATE")).Date, "dd/MM/yyyy"), DR("ARRIVES").ToString, DR("CLASS").ToString)
                            Next
                        End If

                        'GET SCAN DOCS DATA
                        dttable = OBJCMN.search(" AIRLINEBOOKINGMASTER_UPLOAD.BOOKING_GRIDSRNO AS GRIDSRNO, AIRLINEBOOKINGMASTER_UPLOAD.BOOKING_REMARKS AS REMARKS, AIRLINEBOOKINGMASTER_UPLOAD.BOOKING_NAME AS NAME, AIRLINEBOOKINGMASTER_UPLOAD.BOOKING_IMGPATH AS IMGPATH, AIRLINEBOOKINGMASTER_UPLOAD.BOOKING_NEWIMGPATH AS NEWIMGPATH ", "", " AIRLINEBOOKINGMASTER_UPLOAD INNER JOIN AIRLINEBOOKINGMASTER ON AIRLINEBOOKINGMASTER_UPLOAD.BOOKING_NO = AIRLINEBOOKINGMASTER.BOOKING_NO AND AIRLINEBOOKINGMASTER_UPLOAD.BOOKING_CMPID = AIRLINEBOOKINGMASTER.BOOKING_CMPID AND AIRLINEBOOKINGMASTER_UPLOAD.BOOKING_LOCATIONID = AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID AND AIRLINEBOOKINGMASTER_UPLOAD.BOOKING_YEARID = AIRLINEBOOKINGMASTER.BOOKING_YEARID AND AIRLINEBOOKINGMASTER_UPLOAD.BOOKING_SALEREGID = AIRLINEBOOKINGMASTER.BOOKING_SALEREGISTERID ", " AND AIRLINEBOOKINGMASTER.BOOKING_NO = " & TXTCOPY.Text.Trim & " AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = " & CmpId & " AND AIRLINEBOOKINGMASTER.BOOKING_SALEREGISTERID = " & SALEregid & " AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID  = " & Locationid & " AND AIRLINEBOOKINGMASTER.BOOKING_YEARID = " & YearId & " ORDER BY AIRLINEBOOKINGMASTER_UPLOAD.BOOKING_GRIDSRNO")
                        If dttable.Rows.Count > 0 Then
                            For Each DTR As DataRow In dttable.Rows
                                gridupload.Rows.Add(DTR("GRIDSRNO"), DTR("REMARKS"), DTR("NAME"), DTR("IMGPATH"), DTR("NEWIMGPATH"))
                            Next
                        End If


                        PURCHASETOTAL()

                    End If
                Else
                    MsgBox("Invalid Voucher No.", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function checknote(ByRef grid As System.Windows.Forms.DataGridView, ByRef col As DataGridViewColumn) As Boolean
        Dim bln As Boolean = True
        For Each row As DataGridViewRow In grid.Rows
            If Convert.ToBoolean(row.Cells(col.Index).Value) = False Then
                bln = False
                Exit For
            End If
        Next
        Return bln
    End Function

    Private Sub DNNOTE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DNNOTE.Click
        Try
            If PBPAID.Visible = True Or PBRECD.Visible = True Then
                MsgBox("Rec/Pay made, Delete Rec/Pay First", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If checknote(GRIDPUR, GPURCANCELLED) = True Then
                MsgBox("Booking Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If
            'If lbllocked.Visible = True Or PBlock.Visible = True Then
            '    MsgBox("Booking Locked", MsgBoxStyle.Critical)
            '    Exit Sub
            'End If

            If edit = True Then
                Dim OBJdN As New AirlineDebitNote
                OBJdN.MdiParent = MDIMain
                OBJdN.FRMSTRING = ""
                If FRMSTRING = "DOMESTIC" Then
                    OBJdN.BILLNO = "AP-" & txtbookingno.Text.Trim
                Else
                    OBJdN.BILLNO = "IAP-" & txtbookingno.Text.Trim
                End If
                OBJdN.Show()
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

            If checknote(GRIDBOOKINGS, GCANCELLED) = True Then
                MsgBox("Booking Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'If lbllocked.Visible = True Or PBlock.Visible = True Then
            '    MsgBox("Booking Locked", MsgBoxStyle.Critical)
            '    Exit Sub
            'End If

            If edit = True Then
                Dim OBJCN As New AirlineCreditNote
                OBJCN.MdiParent = MDIMain
                OBJCN.FRMSTRING = ""
                If FRMSTRING = "DOMESTIC" Then
                    OBJCN.BILLNO = "AS-" & txtbookingno.Text.Trim
                Else
                    OBJCN.BILLNO = "IAS-" & txtbookingno.Text.Trim
                End If
                OBJCN.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    Private Sub GRIDPASS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDPASS.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDBOOKINGS.RowCount > 0 Then

                'dont allow user TO DFELETE IN GRIDPUR
                MessageBox.Show("You Cannot Delete This Row, Delete from Booking Tab")
                Exit Sub

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBAIRCODE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBAIRCODE.Enter
        Try
            If CMBAIRCODE.Text.Trim = "" Then FILLAIRCODE(CMBAIRCODE, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBAIRCODE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBAIRCODE.KeyDown
        Try

            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJFLIGHT As New SelectFlight
                'OBJFLIGH.STRSEARCH = " and ledgers.acc_cmpid = " & CmpId & " and LEDGERS.acc_LOCATIONid = " & Locationid & " and LEDGERS.ACC_YEARID = " & YearId
                OBJFLIGHT.ShowDialog()
                If OBJFLIGHT.TEMPCODE <> "" Then CMBAIRCODE.Text = OBJFLIGHT.TEMPCODE
                If OBJFLIGHT.TEMPNAME <> "" Then CMBAIRNAME.Text = OBJFLIGHT.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBAIRCODE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBAIRCODE.Validating
        Try
            If CMBAIRCODE.Text.Trim <> "" Then AIRCODEVALIDATE(CMBAIRCODE, CMBAIRNAME, e, Me, "", txtPurDiscountPerc.Text, IS_DOMESTIC)
            If edit = False Then
                'If (FRMSTRING = "DOMESTIC") Then
                '    CMBPURTAX.Text = "S.T. 0.65%"
                '    cmbtax.Text = "S.T. 0.65%"
                'Else
                '    CMBPURTAX.Text = "S.T. 1.236%"
                '    cmbtax.Text = "S.T. 1.236%"
                'End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBAIRNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBAIRNAME.Enter
        Try
            If CMBAIRNAME.Text.Trim = "" Then FILLAIRLINE(CMBAIRNAME, edit, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBAIRNAME_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBAIRNAME.KeyDown
        Try

            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJFLIGHT As New SelectFlight
                'OBJFLIGH.STRSEARCH = " and ledgers.acc_cmpid = " & CmpId & " and LEDGERS.acc_LOCATIONid = " & Locationid & " and LEDGERS.ACC_YEARID = " & YearId
                OBJFLIGHT.ShowDialog()
                If OBJFLIGHT.TEMPCODE <> "" Then CMBAIRCODE.Text = OBJFLIGHT.TEMPCODE
                If OBJFLIGHT.TEMPNAME <> "" Then CMBAIRNAME.Text = OBJFLIGHT.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBAIRNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBAIRNAME.Validating
        Try
            If Val(txtPurDiscountPerc.Text.Trim) = 0 Then
                If CMBAIRNAME.Text.Trim <> "" Then AIRLINEVALIDATE(CMBAIRNAME, CMBAIRCODE, e, Me, "", IS_DOMESTIC, IS_LCC, COMMBASICPERC, COMMPSFPERC, COMMTAXPERC)
            Else
                If CMBAIRNAME.Text.Trim <> "" Then AIRLINEVALIDATE(CMBAIRNAME, CMBAIRCODE, e, Me, "", IS_DOMESTIC, IS_LCC)
            End If
            If edit = False Then
                If (FRMSTRING = "DOMESTIC") Then
                    CMBPURTAX.Text = "S.T. 0.65%"
                    cmbtax.Text = "S.T. 0.65%"
                Else
                    CMBPURTAX.Text = "S.T. 1.236%"
                    cmbtax.Text = "S.T. 1.236%"
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBASIC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBASIC.KeyPress
        numdotkeypress(e, TXTBASIC, Me)
    End Sub

    Private Sub TXTPSF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPSF.KeyPress
        numdotkeypress(e, TXTPSF, Me)
    End Sub

    Private Sub TXTGRIDTAX_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTGRIDTAX.KeyPress
        numdotkeypress(e, TXTGRIDTAX, Me)
    End Sub

    Private Sub TXTBASIC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTBASIC.Validated
        If Val(TXTBASIC.Text.Trim) > 0 Then
            INCOMEBASICGROUP.Visible = True
            TXTBASCIINCOME.Focus()
            CALC()
        End If
    End Sub

    Private Sub TXTPSF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTPSF.Validated
        If Val(TXTPSF.Text.Trim) > 0 Then
            INCOMEPSFGROUP.Visible = True
            TXTPSFINCOME.Focus()
            CALC()
        End If
    End Sub

    Private Sub TXTGRIDTAX_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTGRIDTAX.Validated
        If Val(TXTGRIDTAX.Text.Trim) > 0 Then
            INCOMETAXGROUP.Visible = True
            TXTTAXINCOME.Focus()
            CALC()
        End If
    End Sub

    Private Sub CMBCRSTYPE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCRSTYPE.Enter
        Try
            If CMBCRSTYPE.Text.Trim = "" Then FILLCRS(CMBCRSTYPE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCRSTYPE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCRSTYPE.Validating
        Try
            If CMBCRSTYPE.Text.Trim <> "" Then CRSvalidate(CMBCRSTYPE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTSECTOR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTSECTOR.Validated
        If TXTSECTOR.Text <> "" And TXTSECTOR.Text <> "   /   /   /   /   /" Then
            'GET LATEST SRNO
            If gridDoubleClick = False Then
                If GRIDBOOKINGS.RowCount > 0 Then
                    txtsrno.Text = Val(GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(GSRNO.Index).Value) + 1
                Else
                    txtsrno.Text = 1
                End If
            End If

            TXTSECTOR.Text = UCase(TXTSECTOR.Text)
            SECTORGROUP.Visible = True
            SECTORGROUP.BringToFront()
            FILLGRIDSECTOR()
            If DIRECTUPLOAD = True Then CMDCLOSE_Click(sender, e)
            GRIDSECTOR.Focus()
        End If
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
            For I As Integer = 0 To 7
                FROMSECNAME = TXTSECTOR.Text.Substring(STARTPOS, 3)
                If TXTSECTOR.Text.Length > STARTPOS + 4 Then TOSECNAME = TXTSECTOR.Text.Substring(STARTPOS + 4, 3)
                If TOSECNAME.Trim = "" Then Exit For

                If TXTTEMPSECTOR.Text.Trim = "" Then
                    TXTTEMPSECTOR.Text = TXTTEMPSECTOR.Text.Trim & FROMSECNAME & "/" & TOSECNAME
                Else
                    TXTTEMPSECTOR.Text = TXTTEMPSECTOR.Text.Trim & "/" & TOSECNAME
                End If
                Dim flight_number As String = getFlightNumber(Val(txtsrno.Text.Trim), FROMSECNAME, TOSECNAME, J, TXTSECTOR.Text, STARTPOS)
                Dim flight_arrives As String = getFlightArrives(Val(txtsrno.Text.Trim), FROMSECNAME, TOSECNAME, J, TXTSECTOR.Text, STARTPOS)
                Dim flight_class As String = getFlightClass(Val(txtsrno.Text.Trim), FROMSECNAME, TOSECNAME, J, TXTSECTOR.Text, STARTPOS)
                Dim flight_date As String = getFlightDate(Val(txtsrno.Text.Trim), FROMSECNAME, TOSECNAME, J, TXTSECTOR.Text, STARTPOS)

                If flight_date = "" Then
                    flight_date = Format(TICKETDATE.Value.Date, "dd/MM/yy")
                    'flight_date = Format(TICKETDATE.Value.Date, "dd/MM/yyyy").ToString
                Else
                    flight_date = (flight_date).ToString
                End If

                'THIS CODE IS WRITTEN BY GULKIT
                If DIRECTUPLOAD = True Then flight_class = TXTCLASS.Text.Trim

                GRIDSECTOR.Rows.Add(0, Val(txtsrno.Text.Trim), FROMSECNAME, TOSECNAME, flight_number, flight_date, flight_arrives, flight_class)
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

    Function getBookingSr(ByVal trimSECTORS As String) As Integer
        Dim booksrno As Integer = 0
        For Each dbrows As System.Windows.Forms.DataGridViewRow In GRIDBOOKINGS.Rows
            If dbrows.Cells(GSECTOR.Index).Value.ToString.Trim = trimSECTORS Then
                booksrno = Convert.ToInt32(dbrows.Cells(GSRNO.Index).Value)
            End If
        Next
        Return booksrno
    End Function

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

        If return_flight_num.Trim = "" And GRIDFLIGHT.Rows.Count > 0 And GRIDBOOKINGS.Rows.Count > 0 Then
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
        If return_flight_class.Trim = "" And GRIDFLIGHT.Rows.Count > 0 And GRIDBOOKINGS.Rows.Count > 0 Then
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
        If return_flight_arrives.Trim = "" And GRIDFLIGHT.Rows.Count > 0 And GRIDBOOKINGS.Rows.Count > 0 Then
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
        If return_flight_date.Trim = "" And GRIDFLIGHT.Rows.Count > 0 And GRIDBOOKINGS.Rows.Count > 0 Then
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

    Private Sub CMDCLOSE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLOSE.Click
        Try
            'Dim fclass As String
            'Dim fflightno As String
            'Dim fclass_array(GRIDSECTOR.RowCount) As String
            'Dim ffligh_array(GRIDSECTOR.RowCount) As String
            'For Each ROW As DataGridViewRow In GRIDSECTOR.Rows
            '    fclass = fclass + ROW.Cells(GSECCLASS.Index).Value + "-"
            'Next
            'TXTSEAT.Text = fclass.Substring(0, fclass.Length - 1)

            If GRIDSECTOR.Rows.Count > 0 Then
                TXTFLTNO.Text = GRIDSECTOR.Rows(0).Cells(GSECFLTNO.Index).Value
                TXTCLASS.Text = GRIDSECTOR.Rows(0).Cells(GSECCLASS.Index).Value
            End If
            SECTORGROUP.Visible = False
            TXTFLTNO.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDSECTOR_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDSECTOR.CellValidating
        Try
            Dim colNum As Integer = GRIDSECTOR.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                'DONE BY  GULKIT TO ALLOW DATE AND TIME USER INPUT IN ALY FORMAT AS DESIRED
                'Case GSECFLTDATE.Index
                '    Dim dDATE As Date
                '    Dim bValid As Boolean = Date.TryParse(e.FormattedValue.ToString, dDATE)

                '    If GRIDSECTOR.CurrentCell.Value = Nothing Then GRIDSECTOR.CurrentCell.Value = Format(TICKETDATE.Value.Date, "dd/MM/yyyy")
                '    If Not bValid Then
                '        MessageBox.Show("Invalid Date Entered")
                '        e.Cancel = True
                '        Exit Sub
                '    End If
                Case GSECFLTNO.Index, GSECCLASS.Index
                    If GRIDSECTOR.CurrentCell.Value <> Nothing Then GRIDSECTOR.CurrentCell.Value = UCase(GRIDSECTOR.CurrentCell.Value)

            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBSP_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBBSP.Validating
        If CMBBSP.Text = "Yes" Then
            CMBCOUPON.Text = "No"
            CMBPURNAME.Text = ""
            CMBPURCODE.Text = ""
            CMBAIRCODE.Focus()
        Else
            CMBCOUPON.Focus()
        End If
    End Sub

    Private Sub CMBCOUPON_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCOUPON.Validating
        If CMBCOUPON.Text = "Yes" Then
            CMBBSP.Text = "No"
            CMBAIRCODE.Focus()
        End If
    End Sub

    Private Sub TXTPNRNO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTPNRNO.Validating
        Try
            If ClientName <> "TRISHA" And ClientName <> "SSR" Then
                If TXTPNRNO.Text.Trim.Length > 0 Then
                    Dim objcmn As New ClsCommon
                    Dim dt As DataTable = objcmn.search(" BOOKING_NO ", "", " AIRLINEBOOKINGMASTER", " AND BOOKING_PNRNO ='" & TXTPNRNO.Text.Trim & "' AND BOOKING_CMPID = " & CmpId & " AND BOOKING_LOCATIONID = " & Locationid & " AND BOOKING_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        If (edit = False) Or (edit = True And TEMPBOOKINGNO <> dt.Rows(0).Item(0)) Then
                            EP.SetError(TXTPNRNO, "PNR No Already Present")
                            e.Cancel = True
                        Else
                            EP.Clear()
                        End If
                    Else
                        EP.Clear()
                    End If
                Else
                    EP.Clear()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTAIRLINEPNR_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTAIRLINEPNR.Validating
        Try
            If TXTAIRLINEPNR.Text.Trim.Length > 0 Then
                Dim objcmn As New ClsCommon
                Dim dt As DataTable = objcmn.search(" BOOKING_NO ", "", " AIRLINEBOOKINGMASTER", " AND BOOKING_AIRLINEPNR ='" & TXTAIRLINEPNR.Text.Trim & "' AND BOOKING_CMPID = " & CmpId & " AND BOOKING_LOCATIONID = " & Locationid & " AND BOOKING_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    If (edit = False) Or (edit = True And TEMPBOOKINGNO <> dt.Rows(0).Item(0)) Then
                        Dim TEMPMSG As Integer = vbNo
                        If ClientName = "TRISHA" Or ClientName = "SSR" Then TEMPMSG = MsgBox("PNR No Already Present, Wish to Proceed?", MsgBoxStyle.YesNo)
                        If TEMPMSG = vbNo Then
                            EP.SetError(TXTAIRLINEPNR, "PNR No Already Present")
                            e.Cancel = True
                        End If
                    Else
                        EP.Clear()
                    End If
                Else
                    EP.Clear()
                End If
            Else
                EP.Clear()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCRSPNR_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCRSPNR.Validating
        Try
            If TXTCRSPNR.Text.Trim.Length > 0 And ClientName <> "SSR" Then
                Dim objcmn As New ClsCommon
                Dim dt As DataTable = objcmn.search(" BOOKING_NO ", "", " AIRLINEBOOKINGMASTER", " AND BOOKING_CRSPNR ='" & TXTCRSPNR.Text.Trim & "' AND BOOKING_CMPID = " & CmpId & " AND BOOKING_LOCATIONID = " & Locationid & " AND BOOKING_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    If (edit = False) Or (edit = True And TEMPBOOKINGNO <> dt.Rows(0).Item(0)) Then
                        EP.SetError(TXTCRSPNR, "CRS PNR No Already Present")
                        e.Cancel = True
                    Else
                        EP.Clear()
                    End If
                Else
                    EP.Clear()
                End If
            Else
                EP.Clear()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtPurDiscountPerc_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPurDiscountPerc.Validated
        Try
            'If Val(txtPurDiscountPerc.Text.Trim) > 0 Then PURCHASETOTAL()
            PURCHASETOTAL()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtPurDiscountAmount_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPurDiscountAmount.Validating
        Try
            Dim commbasic As Double = 0
            Dim commpsf As Double = 0
            Dim commtax As Double = 0
            Dim commtotal As Double = 0

            If COMMBASICPERC > 0 Then commbasic = (COMMBASICPERC * Val(TXTTOTALPURBASIC.Text)) / 100
            If COMMPSFPERC > 0 Then commpsf = (COMMPSFPERC * Val(TXTTOTALPURPSF.Text)) / 100
            If COMMTAXPERC > 0 Then commtax = (COMMTAXPERC * Val(TXTTOTALPURTAX.Text)) / 100

            commtotal = commbasic + commpsf + commtax
            'txtPurDiscountAmount.Text = Format(Val(txtPurDiscountAmount.Text), "0.00")

            If Val(txtPurDiscountAmount.Text.Trim) > 0 Then
                If (Val(txtPurDiscountPerc.Text.Trim) > 0) Then

                    'Dim sub_total As Double
                    ''For Each ROW As DataGridViewRow In GRIDSECTOR.Rows
                    ''    fclass = fclass + ROW.Cells(GSECCLASS.Index).Value + "-"
                    ''Next
                    'For Each row As DataGridViewRow In GRIDPUR.Rows
                    '    sub_total += (Val(row.Cells(GPURBASIC.Index).Value) + Val(row.Cells(GPURTAXES.Index).Value))
                    'Next

                    Dim disc_amt As Double = Format((Val(txtPurDiscountPerc.Text.Trim) * (Val(TXTTOTALPURBASIC.Text) + Val(TXTTOTALPURTAX.Text))) / 100, "0.00")
                    If (disc_amt <> Val(txtPurDiscountAmount.Text.Trim)) Then txtPurDiscountPerc.Clear()
                End If
            End If

            If Val(txtPurDiscountAmount.Text.Trim) <> commtotal Then
                COMMBASICPERC = 0
                COMMPSFPERC = 0
                COMMTAXPERC = 0
            End If
            PURCHASETOTAL()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtPurAddDiscountAmount_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPurAddDiscountAmount.Validated
        Try
            PURCHASETOTAL()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTBASCIINCOME_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBASCIINCOME.KeyPress
        numdotkeypress(e, TXTBASCIINCOME, Me)
    End Sub

    Private Sub TXTPSFINCOME_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPSFINCOME.KeyPress
        numdotkeypress(e, TXTPSFINCOME, Me)
    End Sub

    Private Sub TXTTAXINCOME_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTTAXINCOME.KeyPress
        numdotkeypress(e, TXTTAXINCOME, Me)
    End Sub

    Private Sub txtDiscountPerc_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDiscountPerc.Validating
        Try
            If Val(txtDiscountPerc.Text.Trim) > 0 Then total()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtDiscountAmount_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDiscountAmount.Validating
        Try
            If Val(txtDiscountAmount.Text.Trim) > 0 Then
                If (Val(txtDiscountPerc.Text.Trim) > 0) Then
                    Dim disc_amt As Double = Format((Val(txtDiscountPerc.Text.Trim) * (Val(TXTTOTALTAXES.Text) + Val(TXTTOTALBASIC.Text))) / 100, "0.00")
                    If (disc_amt <> Val(txtDiscountAmount.Text.Trim)) Then txtDiscountPerc.Clear()
                End If
            End If
            total()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtPurDiscountPerc_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPurDiscountPerc.KeyPress
        numdotkeypress(e, txtPurDiscountPerc, Me)
    End Sub

    Private Sub txtPurDiscountAmount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPurDiscountAmount.KeyPress
        numdotkeypress(e, txtPurDiscountAmount, Me)
    End Sub

    Private Sub txtPurAddDiscountAmount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPurAddDiscountAmount.KeyPress
        numdotkeypress(e, txtPurAddDiscountAmount, Me)
    End Sub

    Private Sub txtDiscountPerc_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiscountPerc.KeyPress
        numdotkeypress(e, txtDiscountPerc, Me)
    End Sub

    Private Sub txtDiscountAmount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiscountAmount.KeyPress
        numdotkeypress(e, txtDiscountAmount, Me)
    End Sub

    Private Sub txtAddDiscountAmount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddDiscountAmount.KeyPress
        numdotkeypress(e, txtAddDiscountAmount, Me)
    End Sub

    Private Sub TXTTICKETNO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTTICKETNO.Validating
        Try
            If TXTTICKETNO.Text.Trim.Length > 0 And (CMBBSP.Text = "Yes" Or CMBCOUPON.Text = "Yes") Then
                EP.Clear()
                If CMBAIRNAME.Text.Trim.Length = 0 Then
                    EP.SetError(CMBAIRNAME, "Please select Airlines to check the stock")
                    Exit Sub
                End If

                Dim DTSTOCK As DataTable
                If edit = False Then
                    DTSTOCK = stock(" AND TICKETNO = '" & TXTTICKETNO.Text.Trim & "'")
                ElseIf edit = True And gridDoubleClick = True And LCase(TXTTICKETNO.Text.Trim) <> LCase(GRIDBOOKINGS.Item(GTICKETNO.Index, temprow).Value) Then
                    DTSTOCK = stock(" AND TICKETNO = '" & TXTTICKETNO.Text.Trim & "'")
                Else
                    Exit Sub
                End If
                If DTSTOCK.Rows.Count = 0 Then
                    MsgBox("Ticket No. Does not Exist in the Stock.", MsgBoxStyle.Critical)
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function stock(Optional ByVal WHERECLAUSE As String = "") As DataTable
        Try
            If CMBBSP.Text = "Yes" Then
                WHERECLAUSE = WHERECLAUSE & " AND TYPE = 'BSP'"
            ElseIf CMBCOUPON.Text = "Yes" Then
                WHERECLAUSE = WHERECLAUSE & " AND TYPE = 'COUPON'"
            End If
            Dim objcmn As New ClsCommon()
            Dim dt As DataTable = objcmn.search(" 0, TICKETNO AS TICKETNO, RATE AS RATE ", "", " STOCKS ", WHERECLAUSE & " AND AIRLINE='" & CMBAIRNAME.Text.Trim & "' AND CMPID = " & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub cmdcheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcheck.Click
        Try
            If CMBBSP.Text = "Yes" Or CMBCOUPON.Text = "Yes" Then
                EP.Clear()
                If CMBAIRNAME.Text.Trim.Length = 0 Then
                    EP.SetError(CMBAIRNAME, "Please select Airlines to check the stock")
                    Exit Sub
                End If
                Dim DTSTOCK As DataTable = stock(" ")
                If DTSTOCK.Rows.Count > 0 Then
                    gridstocks.RowCount = 0
                    Dim ticket_eval As Double
                    lblticketcount.Text = "0"
                    lblticketeval.Text = "0.00"
                    For Each dr As DataRow In DTSTOCK.Rows
                        gridstocks.Rows.Add(0, dr.Item("TICKETNO"), Val(dr("RATE")))
                        ticket_eval += Val(dr("RATE"))

                    Next
                    lblticketcount.Text = gridstocks.RowCount
                    lblticketeval.Text = Format(ticket_eval, "0.00")
                    getsrno(gridstocks)
                    grpstock.Visible = True
                Else
                    MsgBox("No Stock Found", MsgBoxStyle.Information)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSTOCKCLOSE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSTOCKCLOSE.Click
        gridstocks.RowCount = 0
        grpstock.Visible = False
        CMBAIRNAME.Focus()
    End Sub

    Private Sub gridstocks_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridstocks.CellDoubleClick
        Try
            If gridstocks.RowCount > 0 Then
                TXTTICKETNO.Text = gridstocks.Rows(e.RowIndex).Cells(GSTKTICKETNO.Index).Value
                gridstocks.RowCount = 0
                grpstock.Visible = False
                TXTTICKETNO.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
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
        TXTNEWIMGPATH.Text = Application.StartupPath & "\" & FRMSTRING & "\" & txtbookingno.Text.Trim & txtuploadsrno.Text.Trim & TXTFILENAME.Text.Trim
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

    Private Sub cmbregister_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.Enter
        Try
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'SALE'")
            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'RECEIPT' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
            If dt.Rows.Count > 0 Then
                cmbregister.Text = dt.Rows(0).Item(0).ToString
            End If
            If FRMSTRING = "DOMESTIC" Then
                cmbregister.Text = "AIRLINE SALE REGISTER"
            Else
                cmbregister.Text = "INTAIRLINE SALE REGISTER"
            End If
            getmax_BOOKING_no()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbregister.Validating
        Try
            If cmbregister.Text.Trim.Length > 0 And edit = False Then
                clear()
                If FRMSTRING = "DOMESTIC" Then
                    cmbregister.Text = "AIRLINE SALE REGISTER"
                Else
                    cmbregister.Text = "INTAIRLINE SALE REGISTER"
                End If
                Dim clscommon As New ClsCommon
                Dim dt As DataTable
                dt = clscommon.search(" register_abbr, register_initials, register_id ", "", " RegisterMaster ", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'SALE' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
                If dt.Rows.Count > 0 Then

                    SALEregabbr = dt.Rows(0).Item(0).ToString
                    SALEreginitial = dt.Rows(0).Item(1).ToString
                    SALEregid = dt.Rows(0).Item(2)
                    cmbregister.Enabled = False
                Else
                    MsgBox("Register Not Present, Add New from Master Module")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtAddDiscountAmount_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAddDiscountAmount.Validated
        Try
            ' If Val(txtAddDiscountAmount.Text.Trim) > 0 Then total()
            total()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTBASCIINCOME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTBASCIINCOME.Validating
        If Val(TXTBASCIINCOME.Text.Trim) <= Val(TXTBASIC.Text.Trim) Then
            INCOMEBASICGROUP.Visible = False
            TXTPSF.Focus()
        Else
            MsgBox("Income is greater than actual amount")
            e.Cancel = True
        End If

    End Sub

    Private Sub TXTPSFINCOME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTPSFINCOME.Validating
        If Val(TXTPSFINCOME.Text.Trim) <= Val(TXTPSF.Text.Trim) Then
            INCOMEPSFGROUP.Visible = False
            TXTGRIDTAX.Focus()
        Else
            MsgBox("Income is greater than actual amount")
            e.Cancel = True
        End If
    End Sub

    Private Sub TXTTAXINCOME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTTAXINCOME.Validating
        If Val(TXTTAXINCOME.Text.Trim) <= Val(TXTGRIDTAX.Text.Trim) Then
            INCOMETAXGROUP.Visible = False
            TXTTOTAL.Focus()
        Else
            MsgBox("Income is greater than actual amount")
            e.Cancel = True
        End If
    End Sub

    Private Sub CHKPURTAXONCOMM_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHKPURTAXONCOMM.CheckedChanged
        Try
            PURCHASETOTAL()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPURTAX_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBPURTAX.Validated
        Try
            If CMBPURTAX.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" TAX_TAX AS TAX ", "", " TAXMASTER ", " AND TAX_NAME = '" & CMBPURTAX.Text.Trim & "' AND TAX_CMPID = " & CmpId & " AND TAX_LOCATIONID = " & Locationid & " AND TAX_YEARID  =  " & YearId)
                If DT.Rows.Count > 0 Then
                    If Val(DT.Rows(0).Item("TAX")) = 0 Then
                        TXTPURTAX.ReadOnly = False
                        TXTPURTAX.Enabled = True
                    End If
                End If
            Else
                TXTPURTAX.Clear()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txttax_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttax.Validated
        total()
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

            ElseIf ClientName = "CLASSIC" And UserName = "Admin" And edit = False Then

                If Val(txtbookingno.Text.Trim) >= 0 And edit = False Then
                    Dim OBJSEARCH As New ClsCommon
                    Dim DT As DataTable = OBJSEARCH.search(" BOOKING_no AS BOOKINGNO ", "", " AIRLINEBOOKINGMASTER ", " AND BOOKING_NO = '" & txtbookingno.Text.Trim & "' and BOOKING_SALEREGISTERID = " & SALEregid & " and BOOKING_cmpid=" & CmpId & " and BOOKING_locationid=" & Locationid & " and BOOKING_yearid=" & YearId)
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

            ElseIf (ClientName = "UTTARAKHAND" Or ClientName = "GLOBE" Or ClientName = "MILONI" Or ClientName = "NAMASTE") And edit = False Then

                If Val(txtbookingno.Text.Trim) >= 0 And edit = False Then
                    Dim OBJSEARCH As New ClsCommon
                    Dim DT As DataTable = OBJSEARCH.search(" BOOKING_no AS BOOKINGNO ", "", " AIRLINEBOOKINGMASTER ", " AND BOOKING_NO = '" & txtbookingno.Text.Trim & "' and BOOKING_SALEREGISTERID = " & SALEregid & " and BOOKING_cmpid=" & CmpId & " and BOOKING_locationid=" & Locationid & " and BOOKING_yearid=" & YearId)
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

    Private Sub CHKREVERSE_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHKREVERSE.CheckedChanged
        total()
    End Sub

    Private Sub CMBGROUPDEPARTURE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBGROUPDEPARTURE.Enter
        Try
            If CMBGROUPDEPARTURE.Text.Trim = "" Then FILLGROUPNAME(CMBGROUPDEPARTURE, " AND GROUPDEP_FROM < '" & Format(Convert.ToDateTime(BOOKINGDATE.Text).Date, "MM/dd/yyyy") & "'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGROUPDEPARTURE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGROUPDEPARTURE.Validating
        Try
            If CMBGROUPDEPARTURE.Text.Trim <> "" Then GROUPNAMEVALIDATE(CMBGROUPDEPARTURE, e, Me, " AND GROUPDEP_FROM < '" & Format(Convert.ToDateTime(BOOKINGDATE.Text).Date, "MM/dd/yyyy") & "'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGROUPDEPARTURE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBGROUPDEPARTURE.Validated
        Try
            'FIRST SELECT PASSNAME
            If TXTPASSNAME.Text.Trim = "" And CMBGROUPDEPARTURE.Text.Trim <> "" Then
                MsgBox("Enter Pass Name First", MsgBoxStyle.Critical)
                CMBGROUPDEPARTURE.Text = ""
                TXTPASSNAME.Focus()
                Exit Sub
            End If


            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" ISNULL(GROUPDEPARTURE_AIRLINE.GROUPDEP_NO, 0) AS GROUPDEPNO, ISNULL(GROUPDEPARTURE_AIRLINE.GROUPDEP_GRIDSRNO, 0) AS AIRSRNO, ISNULL(GROUPDEPARTURE_AIRLINE.GROUPDEP_SECTOR, '') AS SECTOR, ISNULL(GROUPDEPARTURE_AIRLINE.GROUPDEP_FLTNO, '') AS FLTNO, ISNULL(GROUPDEPARTURE_AIRLINE.GROUPDEP_TYPE, '') AS TYPE, ISNULL(GROUPDEPARTURE_AIRLINE.GROUPDEP_BASIC, 0) AS BASIC, ISNULL(GROUPDEPARTURE_AIRLINE.GROUPDEP_PSF, 0) AS PSF, ISNULL(GROUPDEPARTURE_AIRLINE.GROUPDEP_TAXES, 0) AS TAXES, ISNULL(GROUPDEPARTURE_AIRLINE.GROUPDEP_AMT, 0) AS AIRAMT, ISNULL(GROUPDEPARTURE.GROUPDEP_NAME, '') AS GROUPNAME", "", "GROUPDEPARTURE_AIRLINE INNER JOIN GROUPDEPARTURE ON GROUPDEPARTURE_AIRLINE.GROUPDEP_NO = GROUPDEPARTURE.GROUPDEP_NO AND GROUPDEPARTURE_AIRLINE.GROUPDEP_YEARID = GROUPDEPARTURE.GROUPDEP_YEARID", " AND GROUPDEPARTURE.GROUPDEP_NAME = '" & CMBGROUPDEPARTURE.Text.Trim & "' AND GROUPDEPARTURE.GROUPDEP_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                For Each DR As DataRow In DT.Rows
                    GRIDBOOKINGS.Rows.Add(DR("AIRSRNO"), TXTPASSNAME.Text.Trim, DR("SECTOR"), DR("FLTNO"), DR("TYPE"), "", "", Format(Val(DR("BASIC")), "0.00"), Format(Val(DR("PSF")), "0.00"), Format(Val(DR("TAXES")), "0.00"), Format(Val(DR("AIRAMT")), "0.00"))
                Next
            End If




            'ADD IN GRIDPASS ALSO
            GRIDPASS.Rows.Add(Val(txtsrno.Text.Trim), Val(GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(GSRNO.Index).Value), TXTPASSNAME.Text.Trim, "", TXTTICKETNO.Text.Trim, "", "", "", "")
            getsrno(GRIDPASS)


            'ADD IN GRIDPUR ALSO
            GRIDPUR.Rows.Add(Val(txtsrno.Text.Trim), Val(GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(GSRNO.Index).Value), TXTPASSNAME.Text.Trim, TXTTICKETNO.Text.Trim, Format(Val(GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(GBASIC.Index).Value), "0.00"), Format(Val(GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(GPSF.Index).Value), "0.00"), Format(Val(GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(GTAXES.Index).Value), "0.00"), Format(Val(GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(GTOTAL.Index).Value), "0.00"), 0)
            getsrno(GRIDPUR)
            PURCHASETOTAL()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub CMDSELECTENQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTENQ.Click
        Try
            If edit = True Then
                MsgBox("Not allowed in Edit Mode", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Cursor.Current = Cursors.WaitCursor

            SELECTENQ.Clear()
            Dim OBJHOTELENQ As New SelectAirlineEnq
            OBJHOTELENQ.ShowDialog()
            SELECTENQ = OBJHOTELENQ.DT
            Dim i As Integer = 0
            If SELECTENQ.Rows.Count > 0 Then
                TXTENQNO.Text = SELECTENQ.Rows(0).Item("ENQNO")
                CMBNAME.Text = SELECTENQ.Rows(0).Item("GUESTNAME")
                CMBSOURCE.Text = SELECTENQ.Rows(0).Item("SOURCE")
                TXTEMAILADD.Text = SELECTENQ.Rows(0).Item("EMAILID")
                TXTMOBILE.Text = SELECTENQ.Rows(0).Item("MOBILENO")
                CMBBOOKEDBY.Text = SELECTENQ.Rows(0).Item("BOOKEDBY")
                TXTTOTALPAX.Text = SELECTENQ.Rows(0).Item("TOTALPAX")

            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub CHKTAXSERVCHGS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKTAXSERVCHGS.CheckedChanged
        total()
    End Sub

    Private Sub TXTSALETDSPER_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTSALETDSPER.KeyPress, TXTSALETDSRS.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTSALETDSPER_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTSALETDSPER.Validating, TXTSALETDSRS.Validating
        Try
            total()
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

    Private Sub CHKPURTAXSERVCHGS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKPURTAXSERVCHGS.CheckedChanged
        Try
            PURCHASETOTAL()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETHSNCODE()
        Try
            If BOOKINGDATE.Text = "__/__/____" Then Exit Sub
            If CMBHSNITEMDESC.Text.Trim <> "" And Convert.ToDateTime(BOOKINGDATE.Text).Date >= "01/07/2017" Then
                If CHKMANUAL.CheckState = CheckState.Unchecked Then
                    TXTHSNCODE.Clear()
                    TXTCGSTPER.Clear()
                    TXTCGSTAMT.Clear()
                    TXTSGSTPER.Clear()
                    TXTSGSTAMT.Clear()
                    TXTIGSTPER.Clear()
                    TXTIGSTAMT.Clear()
                End If

                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable
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


                If CMBPURHSNITEMDESC.Text.Trim <> "" Then
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
                'CALC()
                'total()
                PURCHASETOTAL()
            End If

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

    Private Sub CMBPURHSNITEMDESC_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBPURHSNITEMDESC.Enter
        Try
            If CMBPURHSNITEMDESC.Text.Trim = "" Then FILLHSNITEMDESC(CMBPURHSNITEMDESC)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPURHSNITEMDESC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPURHSNITEMDESC.Validated
        Try

            TXTPURHSNCODE.Clear()
            TXTPURCGSTPER.Clear()
            TXTPURCGSTAMT.Clear()
            TXTPURSGSTPER.Clear()
            TXTPURSGSTAMT.Clear()
            TXTPURIGSTPER.Clear()
            TXTPURIGSTAMT.Clear()
            If BOOKINGDATE.Text = "__/__/____" Then Exit Sub
            'If CMBPURITEMDESC.Text.Trim <> "" And Convert.ToDateTime(bookingdate.Text).Date >= "01/07/2017" Then
            If CMBPURHSNITEMDESC.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("  ISNULL(HSN_CODE, '') AS PURHSNCODE, ISNULL(HSN_CGST, 0) AS PURCGSTPER, ISNULL(HSN_SGST, 0) AS PURSGSTPER, ISNULL(HSN_IGST, 0) AS PURIGSTPER ", "", " HSNMASTER ", " AND HSNMASTER.HSN_ITEMDESC = '" & CMBPURHSNITEMDESC.Text.Trim & "' AND HSNMASTER.HSN_YEARID='" & YearId & "' ORDER BY HSNMASTER.HSN_ID DESC")
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
                PURCHASETOTAL()
            End If
        Catch ex As Exception

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
                PURCHASETOTAL()
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

    Private Sub TOOLEXCELUPLOAD_Click(sender As Object, e As EventArgs) Handles TOOLEXCELUPLOAD.Click
        Try
            If InputBox("Enter Master Password") <> "Infosys@123" Then Exit Sub
            'upload the files data
            ''Reading from Excel Woorkbook
            Dim oExcel As Microsoft.Office.Interop.Excel.Application = CreateObject("Excel.Application")
            Dim oBook As Microsoft.Office.Interop.Excel.Workbook = oExcel.Workbooks.Open("D:\" & InputBox("Enter File Name").ToString.Trim, , False)
            Dim oSheet As New Microsoft.Office.Interop.Excel.Worksheet
            oSheet = oBook.Worksheets("Sheet1")

            Dim DTSAVE As New System.Data.DataTable
            DTSAVE.Columns.Add("DATE")
            DTSAVE.Columns.Add("MOBILENO")
            DTSAVE.Columns.Add("AIRLINE")
            DTSAVE.Columns.Add("PURNAME")
            DTSAVE.Columns.Add("PURSTATE")
            DTSAVE.Columns.Add("SALENAME")
            DTSAVE.Columns.Add("SALESTATE")
            DTSAVE.Columns.Add("REFNO")
            DTSAVE.Columns.Add("JOURNEYDATE")
            DTSAVE.Columns.Add("PNRNO")
            DTSAVE.Columns.Add("PURSACCODE")
            DTSAVE.Columns.Add("SALESACCODE")
            DTSAVE.Columns.Add("PASSENGER1")
            DTSAVE.Columns.Add("PASSENGER2")
            DTSAVE.Columns.Add("PASSENGER3")
            DTSAVE.Columns.Add("PASSENGER4")
            DTSAVE.Columns.Add("PASSENGER5")
            DTSAVE.Columns.Add("PASSENGER6")
            DTSAVE.Columns.Add("PASSENGER7")
            DTSAVE.Columns.Add("PASSENGER8")
            DTSAVE.Columns.Add("PASSENGER9")
            DTSAVE.Columns.Add("SECTORS")
            DTSAVE.Columns.Add("FLTNO")
            DTSAVE.Columns.Add("TICKETNO1")
            DTSAVE.Columns.Add("TICKETNO2")
            DTSAVE.Columns.Add("TICKETNO3")
            DTSAVE.Columns.Add("TICKETNO4")
            DTSAVE.Columns.Add("TICKETNO5")
            DTSAVE.Columns.Add("TICKETNO6")
            DTSAVE.Columns.Add("TICKETNO7")
            DTSAVE.Columns.Add("TICKETNO8")
            DTSAVE.Columns.Add("TICKETNO9")
            DTSAVE.Columns.Add("CLASS")
            DTSAVE.Columns.Add("BASICAMT")
            DTSAVE.Columns.Add("YQ")
            DTSAVE.Columns.Add("TAXES")
            DTSAVE.Columns.Add("AMOUNT")
            DTSAVE.Columns.Add("PURCOMM")
            DTSAVE.Columns.Add("PURTDS")
            DTSAVE.Columns.Add("PURSERVCHGS")
            DTSAVE.Columns.Add("SALEDISC")
            DTSAVE.Columns.Add("SALESERVCHGS")
            DTSAVE.Columns.Add("GSTSERVCHGS")
            DTSAVE.Columns.Add("SOURCE")
            DTSAVE.Columns.Add("REMARKS")
            DTSAVE.Columns.Add("RETURNDATE")
            DTSAVE.Columns.Add("INVOICENO")


            Dim ARR As New ArrayList
            Dim COLIND As Integer = 0
            Dim DTROWSAVE As System.Data.DataRow = DTSAVE.NewRow()


            Dim FROMROWNO As Integer = Val(InputBox("Enter Start Row No"))
            Dim TOROWNO As Integer = Val(InputBox("Enter End Row No"))

            For I As Integer = FROMROWNO To TOROWNO

                DIRECTUPLOAD = True

                If IsDBNull(oSheet.Range("A" & I.ToString).Text) = False Then
                    DTROWSAVE("DATE") = Format(Convert.ToDateTime(oSheet.Range("A" & I.ToString).Text).Date, "dd/MM/yyyy")
                Else
                    DTROWSAVE("DATE") = 0
                End If


                If IsDBNull(oSheet.Range("B" & I.ToString).Text) = False Then
                    DTROWSAVE("MOBILENO") = oSheet.Range("B" & I.ToString).Text
                Else
                    DTROWSAVE("MOBILENO") = ""
                End If

                If IsDBNull(oSheet.Range("C" & I.ToString).Text) = False Then
                    DTROWSAVE("AIRLINE") = oSheet.Range("C" & I.ToString).Text
                Else
                    DTROWSAVE("AIRLINE") = ""
                End If


                If IsDBNull(oSheet.Range("D" & I.ToString).Text) = False Then
                    DTROWSAVE("PURNAME") = oSheet.Range("D" & I.ToString).Text
                Else
                    DTROWSAVE("PURNAME") = ""
                End If

                If IsDBNull(oSheet.Range("E" & I.ToString).Text) = False Then
                    DTROWSAVE("PURSTATE") = oSheet.Range("E" & I.ToString).Text
                Else
                    DTROWSAVE("PURSTATE") = ""
                End If

                If IsDBNull(oSheet.Range("F" & I.ToString).Text) = False Then
                    DTROWSAVE("SALENAME") = oSheet.Range("F" & I.ToString).Text
                Else
                    DTROWSAVE("SALENAME") = ""
                End If

                If IsDBNull(oSheet.Range("G" & I.ToString).Text) = False Then
                    DTROWSAVE("SALESTATE") = oSheet.Range("G" & I.ToString).Text
                Else
                    DTROWSAVE("SALESTATE") = ""
                End If

                If IsDBNull(oSheet.Range("H" & I.ToString).Text) = False Then
                    DTROWSAVE("REFNO") = oSheet.Range("H" & I.ToString).Text
                Else
                    DTROWSAVE("REFNO") = ""
                End If

                If IsDBNull(oSheet.Range("I" & I.ToString).Text) = False Then
                    DTROWSAVE("JOURNEYDATE") = Format(Convert.ToDateTime(oSheet.Range("I" & I.ToString).Text).Date, "dd/MM/yyyy")
                Else
                    DTROWSAVE("JOURNEYDATE") = 0
                End If

                If IsDBNull(oSheet.Range("J" & I.ToString).Text) = False Then
                    DTROWSAVE("PNRNO") = oSheet.Range("J" & I.ToString).Text
                Else
                    DTROWSAVE("PNRNO") = ""
                End If

                If IsDBNull(oSheet.Range("K" & I.ToString).Text) = False Then
                    DTROWSAVE("PURSACCODE") = oSheet.Range("K" & I.ToString).Text
                Else
                    DTROWSAVE("PURSACCODE") = ""
                End If

                If IsDBNull(oSheet.Range("L" & I.ToString).Text) = False Then
                    DTROWSAVE("SALESACCODE") = oSheet.Range("L" & I.ToString).Text
                Else
                    DTROWSAVE("SALESACCODE") = ""
                End If

                If IsDBNull(oSheet.Range("M" & I.ToString).Text) = False Then
                    DTROWSAVE("PASSENGER1") = oSheet.Range("M" & I.ToString).Text
                Else
                    DTROWSAVE("PASSENGER1") = ""
                End If

                If IsDBNull(oSheet.Range("N" & I.ToString).Text) = False Then
                    DTROWSAVE("PASSENGER2") = oSheet.Range("N" & I.ToString).Text
                Else
                    DTROWSAVE("PASSENGER2") = ""
                End If

                If IsDBNull(oSheet.Range("O" & I.ToString).Text) = False Then
                    DTROWSAVE("PASSENGER3") = oSheet.Range("O" & I.ToString).Text
                Else
                    DTROWSAVE("PASSENGER3") = ""
                End If

                If IsDBNull(oSheet.Range("P" & I.ToString).Text) = False Then
                    DTROWSAVE("PASSENGER4") = oSheet.Range("P" & I.ToString).Text
                Else
                    DTROWSAVE("PASSENGER4") = ""
                End If

                If IsDBNull(oSheet.Range("Q" & I.ToString).Text) = False Then
                    DTROWSAVE("PASSENGER5") = oSheet.Range("Q" & I.ToString).Text
                Else
                    DTROWSAVE("PASSENGER5") = ""
                End If

                If IsDBNull(oSheet.Range("R" & I.ToString).Text) = False Then
                    DTROWSAVE("PASSENGER6") = oSheet.Range("R" & I.ToString).Text
                Else
                    DTROWSAVE("PASSENGER6") = ""
                End If

                If IsDBNull(oSheet.Range("S" & I.ToString).Text) = False Then
                    DTROWSAVE("PASSENGER7") = oSheet.Range("S" & I.ToString).Text
                Else
                    DTROWSAVE("PASSENGER7") = ""
                End If

                If IsDBNull(oSheet.Range("T" & I.ToString).Text) = False Then
                    DTROWSAVE("PASSENGER8") = oSheet.Range("T" & I.ToString).Text
                Else
                    DTROWSAVE("PASSENGER8") = ""
                End If

                If IsDBNull(oSheet.Range("U" & I.ToString).Text) = False Then
                    DTROWSAVE("PASSENGER9") = oSheet.Range("U" & I.ToString).Text
                Else
                    DTROWSAVE("PASSENGER9") = ""
                End If

                If IsDBNull(oSheet.Range("V" & I.ToString).Text) = False Then
                    DTROWSAVE("SECTORS") = oSheet.Range("V" & I.ToString).Text
                Else
                    DTROWSAVE("SECTORS") = ""
                End If

                If IsDBNull(oSheet.Range("W" & I.ToString).Text) = False Then
                    DTROWSAVE("FLTNO") = oSheet.Range("W" & I.ToString).Text
                Else
                    DTROWSAVE("FLTNO") = ""
                End If

                If IsDBNull(oSheet.Range("X" & I.ToString).Text) = False Then
                    DTROWSAVE("TICKETNO1") = oSheet.Range("X" & I.ToString).Text
                Else
                    DTROWSAVE("TICKETNO1") = ""
                End If

                If IsDBNull(oSheet.Range("Y" & I.ToString).Text) = False Then
                    DTROWSAVE("TICKETNO2") = oSheet.Range("Y" & I.ToString).Text
                Else
                    DTROWSAVE("TICKETNO2") = ""
                End If

                If IsDBNull(oSheet.Range("Z" & I.ToString).Text) = False Then
                    DTROWSAVE("TICKETNO3") = oSheet.Range("Z" & I.ToString).Text
                Else
                    DTROWSAVE("TICKETNO3") = ""
                End If

                If IsDBNull(oSheet.Range("AA" & I.ToString).Text) = False Then
                    DTROWSAVE("TICKETNO4") = oSheet.Range("AA" & I.ToString).Text
                Else
                    DTROWSAVE("TICKETNO4") = ""
                End If

                If IsDBNull(oSheet.Range("AB" & I.ToString).Text) = False Then
                    DTROWSAVE("TICKETNO5") = oSheet.Range("AB" & I.ToString).Text
                Else
                    DTROWSAVE("TICKETNO5") = ""
                End If

                If IsDBNull(oSheet.Range("AC" & I.ToString).Text) = False Then
                    DTROWSAVE("TICKETNO6") = oSheet.Range("AC" & I.ToString).Text
                Else
                    DTROWSAVE("TICKETNO6") = ""
                End If

                If IsDBNull(oSheet.Range("AD" & I.ToString).Text) = False Then
                    DTROWSAVE("TICKETNO7") = oSheet.Range("AD" & I.ToString).Text
                Else
                    DTROWSAVE("TICKETNO7") = ""
                End If

                If IsDBNull(oSheet.Range("AE" & I.ToString).Text) = False Then
                    DTROWSAVE("TICKETNO8") = oSheet.Range("AE" & I.ToString).Text
                Else
                    DTROWSAVE("TICKETNO8") = ""
                End If

                If IsDBNull(oSheet.Range("AF" & I.ToString).Text) = False Then
                    DTROWSAVE("TICKETNO9") = oSheet.Range("AF" & I.ToString).Text
                Else
                    DTROWSAVE("TICKETNO9") = ""
                End If

                If IsDBNull(oSheet.Range("AG" & I.ToString).Text) = False Then
                    DTROWSAVE("CLASS") = oSheet.Range("AG" & I.ToString).Text
                Else
                    DTROWSAVE("CLASS") = ""
                End If

                If IsDBNull(oSheet.Range("AH" & I.ToString).Text) = False Then
                    DTROWSAVE("BASICAMT") = Val(oSheet.Range("AH" & I.ToString).Text)
                Else
                    DTROWSAVE("BASICAMT") = 0
                End If

                If IsDBNull(oSheet.Range("AI" & I.ToString).Text) = False Then
                    DTROWSAVE("YQ") = Val(oSheet.Range("AI" & I.ToString).Text)
                Else
                    DTROWSAVE("YQ") = 0
                End If

                If IsDBNull(oSheet.Range("AJ" & I.ToString).Text) = False Then
                    DTROWSAVE("TAXES") = Val(oSheet.Range("AJ" & I.ToString).Text)
                Else
                    DTROWSAVE("TAXES") = 0
                End If

                If IsDBNull(oSheet.Range("AK" & I.ToString).Text) = False Then
                    DTROWSAVE("AMOUNT") = Val(oSheet.Range("AK" & I.ToString).Text)
                Else
                    DTROWSAVE("AMOUNT") = 0
                End If

                If IsDBNull(oSheet.Range("AL" & I.ToString).Text) = False Then
                    DTROWSAVE("PURCOMM") = Val(oSheet.Range("AL" & I.ToString).Text)
                Else
                    DTROWSAVE("PURCOMM") = 0
                End If

                If IsDBNull(oSheet.Range("AM" & I.ToString).Text) = False Then
                    DTROWSAVE("PURTDS") = Val(oSheet.Range("AM" & I.ToString).Text)
                Else
                    DTROWSAVE("PURTDS") = 0
                End If

                If IsDBNull(oSheet.Range("AN" & I.ToString).Text) = False Then
                    DTROWSAVE("PURSERVCHGS") = Val(oSheet.Range("AN" & I.ToString).Text)
                Else
                    DTROWSAVE("PURSERVCHGS") = 0
                End If

                If IsDBNull(oSheet.Range("AO" & I.ToString).Text) = False Then
                    DTROWSAVE("SALEDISC") = Val(oSheet.Range("AO" & I.ToString).Text)
                Else
                    DTROWSAVE("SALEDISC") = 0
                End If

                If IsDBNull(oSheet.Range("AP" & I.ToString).Text) = False Then
                    DTROWSAVE("SALESERVCHGS") = Val(oSheet.Range("AP" & I.ToString).Text)
                Else
                    DTROWSAVE("SALESERVCHGS") = 0
                End If

                If IsDBNull(oSheet.Range("AQ" & I.ToString).Text) = False Then
                    DTROWSAVE("GSTSERVCHGS") = oSheet.Range("AQ" & I.ToString).Text
                Else
                    DTROWSAVE("GSTSERVCHGS") = 0
                End If

                If IsDBNull(oSheet.Range("AR" & I.ToString).Text) = False Then
                    DTROWSAVE("SOURCE") = oSheet.Range("AR" & I.ToString).Text
                Else
                    DTROWSAVE("SOURCE") = ""
                End If

                If IsDBNull(oSheet.Range("AS" & I.ToString).Text) = False Then
                    DTROWSAVE("REMARKS") = oSheet.Range("AS" & I.ToString).Text
                Else
                    DTROWSAVE("REMARKS") = ""
                End If

                If IsDBNull(oSheet.Range("AT" & I.ToString).Text) = False Then
                    DTROWSAVE("RETURNDATE") = Format(Convert.ToDateTime(oSheet.Range("AT" & I.ToString).Text).Date, "dd/MM/yyyy")
                Else
                    DTROWSAVE("RETURNDATE") = 0
                End If

                If IsDBNull(oSheet.Range("AU" & I.ToString).Text) = False Then
                    DTROWSAVE("INVOICENO") = Val(oSheet.Range("AU" & I.ToString).Text)
                Else
                    DTROWSAVE("INVOICENO") = 0
                End If




                Dim DTTABLE As New DataTable
                Dim OBJCMN As New ClsCommon
                'check whether REFNO is already present or not
                DTTABLE = OBJCMN.search("BOOKING_NO AS REFNO", "", "AIRLINEBOOKINGMASTER", " AND BOOKING_REFNO = '" & DTROWSAVE("REFNO") & "' AND BOOKING_YEARID = " & YearId)
                If DTTABLE.Rows.Count > 0 Then GoTo SKIPLINE


                txtbookingno.Text = Val(DTROWSAVE("INVOICENO"))
                BOOKINGDATE.Text = DTROWSAVE("DATE")
                CMBAIRCODE.Text = DTROWSAVE("AIRLINE")
                Dim eN As New System.ComponentModel.CancelEventArgs
                AIRCODEVALIDATE(CMBAIRCODE, CMBAIRNAME, eN, Me, "", txtPurDiscountPerc.Text, IS_DOMESTIC)

                'CHECK WHETHER HOTELNAME IS PRESENT OR NOT
                'IF NOT THEN SKIP THE ENTRY
                Dim OBJSYNC As New SyncDate
                Dim DT As DataTable = OBJCMN.search("FLIGHT_CODE AS FLIGHTCODE", "", " FLIGHTMASTER ", " AND FLIGHT_CODE = '" & DTROWSAVE("AIRLINE") & "' AND FLIGHT_YEARID = " & YearId)
                If DT.Rows.Count = 0 Then
                    MsgBox("Flight Not Present, please sync the Data first then upload", MsgBoxStyle.Critical)
                    GoTo SKIPLINE
                End If


                CMBPURNAME.Text = DTROWSAVE("PURNAME")
                'CHECK WHETHER PURCHASENAME IS PRESENT OR NOT
                'IF NOT THEN ADD PURCHASENAME
                'WE DONT KNOW TH STATE OF PURCHASER SO WE ARE PASSING BLANK
                DT = OBJCMN.search("ACC_CMPNAME AS NAME", "", " LEDGERS ", " AND ACC_CMPNAME = '" & CMBPURNAME.Text.Trim & "' AND ACC_YEARID = " & YearId)
                If DT.Rows.Count = 0 Then OBJSYNC.ADDLEDGERS(CMBPURNAME.Text.Trim, "Sundry Creditors", DTROWSAVE("PURSTATE"))


                CMBNAME.Text = DTROWSAVE("SALENAME")
                'CHECK WHETHER SALENAME IS PRESENT OR NOT
                'IF NOT THEN ADD SALENAME
                DT = OBJCMN.search("ACC_CMPNAME AS NAME", "", " LEDGERS ", " AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND ACC_YEARID = " & YearId)
                If DT.Rows.Count = 0 Then OBJSYNC.ADDLEDGERS(CMBNAME.Text.Trim, "Sundry Debtors", DTROWSAVE("SALESTATE"))


                TXTREFNO.Text = DTROWSAVE("REFNO")
                TICKETDATE.Value = DTROWSAVE("JOURNEYDATE")
                RETURNDATE.Value = DTROWSAVE("RETURNDATE")
                TXTAIRLINEPNR.Text = DTROWSAVE("PNRNO")
                CMBPURHSNITEMDESC.Text = DTROWSAVE("PURSACCODE")
                CMBHSNITEMDESC.Text = DTROWSAVE("SALESACCODE")

                For ENTRYNO As Integer = 1 To 9
                    If DTROWSAVE("PASSENGER" & ENTRYNO) = "" Then Exit For
                    TXTPASSNAME.Text = DTROWSAVE("PASSENGER" & ENTRYNO)
                    'CLASS SHOULD BE BEFORE TXTSECTOR VALIDATING
                    TXTCLASS.Text = DTROWSAVE("CLASS")
                    TXTSECTOR.Text = DTROWSAVE("SECTORS")
                    TXTSECTOR_Validated(sender, e)
                    TXTFLTNO.Text = DTROWSAVE("FLTNO")
                    TXTTICKETNO.Text = DTROWSAVE("TICKETNO" & ENTRYNO)


                    TXTBASIC.Text = DTROWSAVE("BASICAMT")
                    TXTPSF.Text = DTROWSAVE("YQ")
                    TXTGRIDTAX.Text = DTROWSAVE("TAXES")
                    CALC()
                    TXTTOTAL.Text = DTROWSAVE("AMOUNT")
                    TXTTOTAL_Validated(sender, e)

                Next



                txtPurDiscountAmount.Text = DTROWSAVE("PURCOMM")
                TXTPURTDSRS.Text = DTROWSAVE("PURTDS")
                TXTPURSERVCHGS.Text = DTROWSAVE("PURSERVCHGS")
                txtDiscountAmount.Text = DTROWSAVE("SALEDISC")
                TXTEXTRACHGS.Text = DTROWSAVE("SALESERVCHGS")
                If UCase(DTROWSAVE("GSTSERVCHGS")) = "YES" Then
                    CHKTAXSERVCHGS.CheckState = CheckState.Checked
                    CHKPURTAXSERVCHGS.CheckState = CheckState.Checked
                Else
                    CHKTAXSERVCHGS.CheckState = CheckState.Unchecked
                    CHKPURTAXSERVCHGS.CheckState = CheckState.Unchecked
                End If

                CMBBOOKEDBY.Text = "Admin"


                CMBNAME_Validated(sender, e)
                CMBPURNAME_Validated(sender, e)
                CMBHSNITEMDESC_Validated(sender, e)
                CMBPURHSNITEMDESC_Validated(sender, e)
                total()
                PURCHASETOTAL()

                CMBSOURCE.Text = DTROWSAVE("SOURCE")
                'CHECK WHETHER SOURCE IS ADDED OR NOT
                'IF NOT THEN ADD SOURCE
                DT = OBJCMN.search("SOURCE_NAME AS SOURCENAME", "", " SOURCEMASTER ", " AND SOURCE_NAME = '" & CMBSOURCE.Text.Trim & "' AND SOURCE_YEARID = " & YearId)
                If DT.Rows.Count = 0 Then OBJSYNC.ADDSOURCE(CMBSOURCE.Text.Trim)

                txtremarks.Text = DTROWSAVE("REMARKS")


                Call cmdok_Click(sender, e)
                GRIDBOOKINGS.RowCount = 0

                DTROWSAVE = DTSAVE.NewRow()

SKIPLINE:
            Next
            oBook.Close()
            DIRECTUPLOAD = False

            Exit Sub
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Async Sub CMDGETQRCODE_Click_1(sender As Object, e As EventArgs) Handles CMDGETQRCODE.Click
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
                    DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'AIRINVOICE','" & TOKEN & "','','" & TEMPSTATUS & "','" & Replace(REQUESTEDTEXT, "'", "''") & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
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
                'Dim TEMPREG As DataTable = OBJCMN.Execute_Any_String("SELECT REGISTER_INITIALS AS INITIALS FROM REGISTERMASTER WHERE REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND REGISTER_TYPE ='SALE' AND REGISTER_YEARID = " & YearId, "", "")
                bitmap1.Save(Application.StartupPath & "\" & SALEreginitial & Val(txtbookingno.Text.Trim) & AccFrom.Year & ".png")
                PBQRCODE.ImageLocation = Application.StartupPath & "\" & SALEreginitial & Val(txtbookingno.Text.Trim) & AccFrom.Year & ".png"
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

                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'AIRINVOICE','" & TOKEN & "','" & TXTIRNNO.Text.Trim & "','QRCODE SUCCESS', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'AIRINVOICE','" & TOKEN & "','" & TXTIRNNO.Text.Trim & "','QRCODE SUCCESS1', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                cmdok_Click(sender, e)

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDUPLOADIRN_Click_1(sender As Object, e As EventArgs) Handles CMDUPLOADIRN.Click
        If (edit = True And USEREDIT = False And USERVIEW = False) Or (edit = False And USERADD = False) Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        OpenFileDialog1.Filter = "Pictures (*.png)|*.png"
        OpenFileDialog1.ShowDialog()

        OpenFileDialog1.AddExtension = True
        TXTFILENAME.Text = OpenFileDialog1.SafeFileName
        txtimgpath.Text = OpenFileDialog1.FileName
        TXTNEWIMGPATH.Text = Application.StartupPath & "\UPLOADDOCS\" & txtbookingno.Text.Trim & txtuploadsrno.Text.Trim & TXTFILENAME.Text.Trim
        On Error Resume Next

        If txtimgpath.Text.Trim.Length <> 0 Then
            PBQRCODE.ImageLocation = txtimgpath.Text.Trim
            PBQRCODE.Load(txtimgpath.Text.Trim)
        End If
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
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'AIRINVOICE','" & TOKEN & "','','" & TEMPSTATUS & "','" & Replace(REQUESTEDTEXT, "'", "''") & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
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
                Dim DTINI As DataTable = OBJCMN.search("BOOKING_PRINTINITIALS AS PRINTINITIALS", "", " AIRLINEBOOKINGMASTER ", " AND BOOKING_NO = " & Val(txtbookingno.Text.Trim) & " AND BOOKING_SALEREGISTERID = " & SALEregid & " AND BOOKING_YEARID = " & YearId)
                PRINTINITIALS = DTINI.Rows(0).Item("PRINTINITIALS")

                j = j & """DocDtls"": {"
                j = j & """Typ"":""INV"","
                j = j & """No"":""" & DTINI.Rows(0).Item("PRINTINITIALS") & """" & ","
                j = j & """Dt"":""" & BOOKINGDATE.Text & """" & "},"


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
                    TEMPOTHERAMT = Val(TXTTOTALSALEAMT.Text.Trim) - Val(txtDiscountAmount.Text.Trim) + Val(txttax.Text.Trim) - Val(txtAddDiscountAmount.Text.Trim) + Val(txtotherchg.Text.Trim)
                    TEMPTOTALITEMAMT = Val(TXTEXTRACHGS.Text.Trim) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim)
                Else
                    TEMPOTHERAMT = Val(TXTTOTALPSF.Text.Trim) + Val(TXTTOTALTAXES.Text.Trim) + Val(TXTEXTRACHGS.Text.Trim) - Val(txtDiscountAmount.Text.Trim) + Val(txttax.Text.Trim) - Val(txtAddDiscountAmount.Text.Trim) + Val(txtotherchg.Text.Trim)
                    TEMPTOTALITEMAMT = Val(TXTTOTALBASIC.Text.Trim) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim)
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
                If CHKTAXSERVCHGS.Checked = True Then j = j & """UnitPrice"":" & Val(TXTEXTRACHGS.Text.Trim) & "" & "," Else j = j & """UnitPrice"":" & Val(TXTTOTALBASIC.Text.Trim) & "" & ","
                If CHKTAXSERVCHGS.Checked = True Then j = j & """TotAmt"":" & Format(Val(TXTEXTRACHGS.Text.Trim), "0.00") & "" & "," Else j = j & """TotAmt"":" & Format(Val(TXTTOTALBASIC.Text.Trim), "0.00") & "" & ","

                'j = j & """Discount"":" & Format(Val(TEMPLINECHARGES), "0.00") & "" & ","
                'j = j & """PreTaxVal"":" & "1" & "" & ","
                If CHKTAXSERVCHGS.Checked = True Then j = j & """AssAmt"":" & Format(Val(TXTEXTRACHGS.Text.Trim), "0.00") & "" & "," Else j = j & """AssAmt"":" & Format(Val(TXTTOTALBASIC.Text.Trim), "0.00") & "" & ","
                Dim DTHSN As DataTable = OBJCMN.search(" ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER.HSN_IGST, 0) AS IGSTPER ", "", "HSNMASTER ", " AND HSNMASTER.HSN_CODE = '" & TXTHSNCODE.Text.Trim & "' AND HSNMASTER.HSN_YEARID=" & YearId)
                j = j & """GstRt"":" & Val(DTHSN.Rows(0).Item("IGSTPER")) & "" & ","


                j = j & """IgstAmt"":" & Val(TXTIGSTAMT.Text.Trim) & "" & ","
                j = j & """CgstAmt"":" & Val(TXTCGSTAMT.Text.Trim) & "" & ","
                j = j & """SgstAmt"":" & Val(TXTSGSTAMT.Text.Trim) & "" & ","
                If APPLYCESS = True Then
                    j = j & """CesRt"":" & Val(TXTCESSPER.Text.Trim) & "" & ","
                    j = j & """CesAmt"":" & Val(TXTCESSAMT.Text.Trim) & "" & ","
                Else
                    j = j & """CesRt"":" & "0" & "" & ","
                    j = j & """CesAmt"":" & "0" & "" & ","
                End If
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
                j = j & """Expdt"":""" & BOOKINGDATE.Text & """" & ","
                j = j & """wrDt"":""" & BOOKINGDATE.Text & """" & "},"

                j = j & """AttribDtls"": [{"
                j = j & """Nm"":""123"","
                j = j & """Val"":""" & Val(TEMPTOTALITEMAMT) & """" & "}]"

                j = j & " }"

                j = j & " ],"



                j = j & """ValDtls"": {"
                If CHKTAXSERVCHGS.Checked = True Then j = j & """AssVal"":" & Val(TXTEXTRACHGS.Text.Trim) & "" & "," Else j = j & """AssVal"":" & Val(TXTTOTALBASIC.Text.Trim) & "" & ","
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
                j = j & """InvStDt"":""" & BOOKINGDATE.Text & """" & ","
                j = j & """InvEndDt"":""" & BOOKINGDATE.Text & """" & "},"

                j = j & """PrecDocDtls"": [{"
                j = j & """InvNo"":""" & DTINI.Rows(0).Item("PRINTINITIALS") & """" & ","
                j = j & """InvDt"":""" & BOOKINGDATE.Text & """" & ","
                j = j & """OthRefNo"":"" ""}],"

                j = j & """ContrDtls"": [{"
                j = j & """RecAdvRefr"":"" "","
                j = j & """RecAdvDt"":""" & BOOKINGDATE.Text & """" & ","
                j = j & """Tendrefr"":"" "","
                j = j & """Contrrefr"":"" "","
                j = j & """Extrefr"":"" "","
                j = j & """Projrefr"":"" "","
                j = j & """Porefr"":"" "","
                j = j & """PoRefDt"":""" & BOOKINGDATE.Text & """" & "}]"
                j = j & "},"




                j = j & """AddlDocDtls"": [{"
                j = j & """Url"":""https://einv-apisandbox.nic.in"","
                j = j & """Docs"":""INVOICE"","
                j = j & """Info"":""INVOICE""}],"

                j = j & """TransDocNo"":"" "","



                j = j & """ExpDtls"": {"
                j = j & """ShipBNo"":"" "","
                j = j & """ShipBDt"":""" & BOOKINGDATE.Text & """" & ","
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
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'AIRINVOICE','" & TOKEN & "','','FAILED','" & Replace(REQUESTEDTEXT, "'", "''") & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")

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
            DT = OBJCMN.Execute_Any_String("UPDATE AIRLINEBOOKINGMASTER SET BOOKING_IRNNO = '" & TXTIRNNO.Text.Trim & "', BOOKING_ACKNO = '" & TXTACKNO.Text.Trim & "', BOOKING_ACKDATE = '" & Format(ACKDATE.Value.Date, "MM/dd/yyyy") & "' FROM AIRLINEBOOKINGMASTER WHERE BOOKING_NO = " & Val(txtbookingno.Text.Trim) & " AND BOOKING_SALEREGISTERID = " & SALEregid & " AND BOOKING_YEARID = " & YearId, "", "")

            'ADD DATA IN EINVOICEENTRY
            DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'AIRINVOICE','" & TOKEN & "','" & IRNNO & "','" & TEMPSTATUS & "', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")


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
                'Dim TEMPREG As DataTable = OBJCMN.Execute_Any_String("SELECT REGISTER_INITIALS AS INITIALS FROM REGISTERMASTER WHERE REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND REGISTER_TYPE ='SALE' AND REGISTER_YEARID = " & YearId, "", "")
                bitmap1.Save(Application.StartupPath & "\" & SALEreginitial & Val(txtbookingno.Text.Trim) & AccFrom.Year & ".png")
                PBQRCODE.ImageLocation = Application.StartupPath & "\" & SALEreginitial & Val(txtbookingno.Text.Trim) & AccFrom.Year & ".png"
                PBQRCODE.Refresh()

                If PBQRCODE.Image IsNot Nothing Then
                    Dim OBJINVOICE As New ClsAirlineBookingMaster
                    Dim MS As New IO.MemoryStream
                    PBQRCODE.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                    OBJINVOICE.alParaval.Add(txtbookingno.Text.Trim)
                    OBJINVOICE.alParaval.Add(SALEregid)
                    OBJINVOICE.alParaval.Add(MS.ToArray)
                    OBJINVOICE.alParaval.Add(YearId)
                    Dim INTRES As Integer = OBJINVOICE.SAVEQRCODE()
                End If

                'DT = OBJCMN.Execute_Any_String("UPDATE INVOICEMASTER SET INVOICE_QRCODE = (SELECT * FROM OPENROWSET(BULK '" & Application.StartupPath & "\" & Val(TXTINVOICENO.Text.Trim) & AccFrom.Year & ".png',SINGLE_BLOB) AS IMG) FROM INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICE_REGISTERID = REGISTER_ID WHERE INVOICE_NO = " & Val(TXTINVOICENO.Text.Trim) & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND INVOICE_YEARID = " & YearId, "", "")


                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'AIRINVOICE','" & TOKEN & "','" & IRNNO & "','QRCODE SUCCESS', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'AIRINVOICE','" & TOKEN & "','" & IRNNO & "','QRCODE SUCCESS1', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")

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

    Private Sub TXTPURCGSTAMT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTPURCGSTAMT.Validated, TXTPURSGSTAMT.Validated, TXTPURIGSTAMT.Validated
        PURCHASETOTAL()
    End Sub

    Private Sub BOOKINGDATE_Validating(sender As Object, e As CancelEventArgs) Handles BOOKINGDATE.Validating
        Try
            If BOOKINGDATE.Text <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(BOOKINGDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BOOKINGDATE_Validated(sender As Object, e As EventArgs) Handles BOOKINGDATE.Validated
        Try
            GETHSNCODE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTSEARCHTCKETNO_Validating(sender As Object, e As CancelEventArgs) Handles TXTSEARCHTCKETNO.Validating
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("BOOKING_NO AS BOOKINGNO", "", "AIRLINEBOOKINGMASTER_DESC", " AND BOOKING_TICKETNO ='" & TXTSEARCHTCKETNO.Text.Trim & "' AND BOOKING_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                tstxtbillno.Text = Val(DT.Rows(0).Item("BOOKINGNO"))
                Call tstxtbillno_Validating(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTTOTAL_Validated(sender As Object, e As EventArgs) Handles TXTTOTAL.Validated
        If ClientName = "TOPCOMM" Then
            If TXTPASSNAME.Text.Trim <> "" And TXTTICKETNO.Text.Trim <> "" And Val(TXTBASIC.Text.Trim) > 0 And Val(TXTTOTAL.Text.Trim) > 0 Then
                EP.Clear()

                If Val(txtPurDiscountPerc.Text.Trim) = 0 Then
                    If CMBAIRNAME.Text.Trim <> "" Then AIRLINEVALIDATE(CMBAIRNAME, CMBAIRCODE, e, Me, "", IS_DOMESTIC, IS_LCC, COMMBASICPERC, COMMPSFPERC, COMMTAXPERC)
                Else
                    If CMBAIRNAME.Text.Trim <> "" Then AIRLINEVALIDATE(CMBAIRNAME, CMBAIRCODE, e, Me, "", IS_DOMESTIC, IS_LCC)
                End If

                If (IS_LCC = False) Or (IS_LCC = True And (CMBBSP.Text.Trim = "Yes" Or CMBCOUPON.Text.Trim = "Yes")) Then
                    EP.Clear()
                    If Not CHECKTICKET() Then
                        Exit Sub
                    End If
                End If

                fillgrid()
                PURCHASETOTAL()

            Else
                'e.Cancel = True
                'TXTGRIDTAX.Focus()
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical, "TRAVELMATE")
                Exit Sub
            End If
        Else
            If (TXTPASSNAME.Text.Trim <> "" And ClientName <> "VINAYAK" And Val(TXTBASIC.Text.Trim) > 0 And Val(TXTTOTAL.Text.Trim) > 0) Or (TXTPASSNAME.Text.Trim <> "" And ClientName = "VINAYAK") Then
                EP.Clear()

                'If Val(txtPurDiscountPerc.Text.Trim) = 0 Then
                '    If CMBAIRNAME.Text.Trim <> "" Then AIRLINEVALIDATE(CMBAIRNAME, CMBAIRCODE, e, Me, "", IS_DOMESTIC, IS_LCC, COMMBASICPERC, COMMPSFPERC, COMMTAXPERC)
                'Else
                '    If CMBAIRNAME.Text.Trim <> "" Then AIRLINEVALIDATE(CMBAIRNAME, CMBAIRCODE, e, Me, "", IS_DOMESTIC, IS_LCC)
                'End If

                If (IS_LCC = False) Or (IS_LCC = True And (CMBBSP.Text.Trim = "Yes" Or CMBCOUPON.Text.Trim = "Yes")) Then
                    EP.Clear()
                    If Not CHECKTICKET() Then
                        Exit Sub
                    End If
                End If

                fillgrid()
                PURCHASETOTAL()
            Else
                'e.Cancel = True
                'TXTGRIDTAX.Focus()
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical, "TRAVELMATE")
                Exit Sub
            End If
        End If
    End Sub

End Class