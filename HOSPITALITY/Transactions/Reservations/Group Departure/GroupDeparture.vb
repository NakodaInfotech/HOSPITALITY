
Imports BL
Imports System.IO

Public Class GroupDeparture

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim gridDoubleClick As Boolean
    Dim gridTOURDoubleClick As Boolean
    Dim gridUPLOADdoubleclick As Boolean
    Dim GRIDCARDOUBLECLICK As Boolean
    Dim GRIDAIRDOUBLECLICK As Boolean
    Dim GRIDMISCDOUBLECLICK As Boolean
    Dim temprow As Integer
    Dim temptourrow As Integer
    Dim tempUPLOADrow As Integer
    Dim TEMPCARROW As Integer
    Dim tempFLIGHTrow As Integer
    Dim TEMPMISCROW As Integer
    Public edit As Boolean
    Public TEMPGROUPNO As Integer
    Public TEMPGROUPNAME As String
    Dim TEMPMSG As Integer

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Sub getmax_GROUP_no()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(GROUPDEP_no),0) + 1 ", "GROUPDEPARTURE", " AND GROUPDEP_cmpid=" & CmpId & " and GROUPDEP_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTGROUPNO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Sub clear()
        Try

            TXTGROUPNO.Clear()
            GROUPDATE.Value = Mydate

            TXTCOPY.Clear()
            tstxtbillno.Clear()

            CMBGROUPNAME.Text = ""
            CMBCODE.Text = ""
            PACKAGEFROM.Value = Mydate
            PACKAGETO.Value = Mydate

            TXTTOTALNIGHTS.Clear()
            TXTTOTALPAX.Clear()
            TXTROUTE.Clear()
            TXTADD.Clear()
            txtrefno.Clear()
            txtremarks.Clear()
            TXTPDFPATH.Clear()

            txtsrno.Clear()
            CMBHOTELNAME.Text = ""
            TXTINCLUSIONS.Clear()
            CHECKINDATE.Value = Mydate
            CHECKOUTDATE.Value = Mydate.Date.AddDays(1)
            CMBROOMTYPE.Text = ""
            CMBPLAN.Text = ""
            TXTNOOFROOMS.Clear()
            TXTRATE.Clear()
            TXTTOTAL.Clear()
            TXTTOTALROOMS.Clear()
            TXTTOTALAMT.Clear()
            TXTBTOTALNIGHTS.Clear()
            CMBPACKAGE.Text = "Yes"
            GRIDBOOKINGS.RowCount = 0


            'tour details
            TXTTOURSRNO.Clear()
            TOURDATE.Value = Mydate
            TXTTOURDETAILS.Clear()
            GRIDTOUR.RowCount = 0

            'RAILWAY
            CMBTRAINNAME.Text = ""
            CMBTRAINNO.Text = ""
            JOURNEYDATE.Value = Mydate
            CMBFROM.Text = ""
            CMBFROMCODE.Text = ""
            CMBTO.Text = ""
            CMBTOCODE.Text = ""
            CMBBOARDING.Text = ""
            CMBBOARDINGCODE.Text = ""
            CMBRESTO.Text = ""
            CMBRESTOCODE.Text = "'"
            TXTFARE.Clear()
            TXTEXTRACHGS.Clear()
            cmbtax.Text = ""
            txttax.Clear()
            txtgrandtotal.Clear()

            CMBDNTRAINNAME.Text = ""
            CMBDNTRAINNO.Text = ""
            DNJOURNEYDATE.Value = Mydate
            CMBDNFROM.Text = ""
            CMBDNFROMCODE.Text = ""
            CMBDNTO.Text = ""
            CMBDNTOCODE.Text = ""
            CMBDNBOARDING.Text = ""
            CMBDNBOARDINGCODE.Text = ""
            CMBDNRESTO.Text = ""
            CMBDNRESTOCODE.Text = ""
            TXTDNFARE.Clear()
            TXTDNEXTRACHGS.Clear()
            cmbdntax.Text = ""
            txtdntax.Clear()
            txtdngrandtotal.Clear()

            CMBMIDUPTRAINNAME.Text = ""
            CMBMIDUPTRAINNO.Text = ""
            MIDUPJOURNEYDATE.Value = Mydate
            CMBMIDUPFROM.Text = ""
            CMBMIDUPFROMCODE.Text = ""
            CMBMIDUPTO.Text = ""
            CMBMIDUPTOCODE.Text = ""
            CMBMIDUPBOARDING.Text = ""
            CMBMIDUPBOARDINGCODE.Text = ""
            CMBMIDUPRESTO.Text = ""
            CMBMIDUPRESTOCODE.Text = ""
            TXTMIDUPFARE.Clear()
            TXTMIDUPEXTRACHGS.Clear()
            cmbmiduptax.Text = ""
            txtmiduptax.Clear()
            txtmidupgrandtotal.Clear()

            CMBMIDDNTRAINNAME.Text = ""
            CMBMIDDNTRAINNO.Text = ""
            MIDDNJOURNEYDATE.Value = Mydate
            CMBMIDDNFROM.Text = ""
            CMBMIDDNFROMCODE.Text = ""
            CMBMIDDNTO.Text = ""
            CMBMIDDNTOCODE.Text = ""
            CMBMIDDNBOARDING.Text = ""
            CMBMIDDNBOARDINGCODE.Text = ""
            CMBMIDDNRESTO.Text = ""
            CMBMIDDNRESTOCODE.Text = ""
            TXTMIDDNFARE.Clear()
            TXTMIDDNEXTRACHGS.Clear()
            cmbmiddntax.Text = ""
            txtmiddntax.Clear()
            txtmiddngrandtotal.Clear()

            TXTCARSRNO.Clear()
            CMBCARNAME.Text = ""
            PICKUPDATE.Value = Mydate
            TXTPICKFROM.Clear()
            TXTPICKTIME.Clear()
            TXTPICKDTLS.Clear()
            DROPDDATE.Value = Mydate.Date.AddDays(1)
            TXTDROPAT.Clear()
            TXTDROPTIME.Clear()
            TXTDROPDTLS.Clear()
            TXTCARNOTE.Clear()
            TXTCARAMT.Clear()
            TXTCARDAYS.Clear()
            TXTCARTOTALAMT.Clear()
            GRIDTRANS.RowCount = 0


            TXTAIRSRNO.Clear()
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
            GRIDAIRLINE.RowCount = 0
            GRIDSECTOR.RowCount = 0
            SECTORGROUP.Visible = False
            SECTORGROUP.SendToBack()

            GRIDFLIGHT.RowCount = 0


            PBlock.Visible = False
            lbllocked.Visible = False
            TBDETAILS.SelectedIndex = 0

            PBSOFTCOPY.Image = Nothing
            TXTUPLOADSRNO.Clear()
            txtuploadname.Clear()
            txtuploadremarks.Clear()
            TXTIMGPATH.Clear()
            gridupload.RowCount = 0



            EP.Clear()
            gridDoubleClick = False
            gridTOURDoubleClick = False
            gridUPLOADdoubleclick = False
            GRIDAIRDOUBLECLICK = False

            getmax_GROUP_no()

            txtsrno.Text = 1
            TXTTOURSRNO.Text = 1
            TXTCARSRNO.Text = 1
            TXTUPLOADSRNO.Text = 1
            TXTAIRSRNO.Text = 1

            TXTTOTALPACKAGEAMT.Clear()

            CMBITINERARY.Text = ""

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        clear()
        edit = False
        GROUPDATE.Focus()
    End Sub

    Private Sub GroupDeparture_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GroupDeparture_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If AscW(e.KeyChar) <> 33 Then chkchange.CheckState = CheckState.Checked
    End Sub

    Sub FILLGROUPNAME()
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable = objclscommon.search("GROUPDEP_name", "", " GROUPDEPARTURE ", " and GROUPDEP_yearid = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "GROUPDEP_name"
                CMBGROUPNAME.DataSource = dt
                CMBGROUPNAME.DisplayMember = "GROUPDEP_name"
                CMBGROUPNAME.Text = TEMPGROUPNAME
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillcmb()
        Try
            FILLGROUPNAME()
            fillHOTEL(CMBHOTELNAME, "")
            FILLVEHICLE(CMBCARNAME, edit, "")
            
            filltax(cmbtax, edit)
            filltax(cmbdntax, edit)

            filltax(cmbmiduptax, edit)
            filltax(cmbmiddntax, edit)

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GroupDeparture_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'HOLIDAY PACKAGES'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)


            Cursor.Current = Cursors.WaitCursor
            fillcmb()
            clear()
            CMBGROUPNAME.Text = TEMPGROUPNAME

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim ALPARAVAL As New ArrayList
                Dim OBJGRPDEP As New ClsGroupDeparture

                ALPARAVAL.Add(TEMPGROUPNO)
                ALPARAVAL.Add(YearId)
                OBJGRPDEP.alParaval = ALPARAVAL

                Dim dt As DataTable = OBJGRPDEP.SELECTBOOKINGDESC()

                If dt.Rows.Count > 0 Then

                    TXTGROUPNO.Text = TEMPGROUPNO
                    GROUPDATE.Value = Convert.ToDateTime(dt.Rows(0).Item("DATE")).Date
                    txtrefno.Text = dt.Rows(0).Item("REFNO")
                    CMBGROUPNAME.Text = Convert.ToString(dt.Rows(0).Item("NAME"))
                    TEMPGROUPNAME = Convert.ToString(dt.Rows(0).Item("NAME"))

                    PACKAGEFROM.Value = Convert.ToDateTime(dt.Rows(0).Item("FROMDATE")).Date
                    PACKAGETO.Value = Convert.ToDateTime(dt.Rows(0).Item("TODATE")).Date
                    TXTROUTE.Text = Convert.ToString(dt.Rows(0).Item("ROUTE"))
                    TXTTOTALNIGHTS.Text = Val(dt.Rows(0).Item("TOTALNIGHTS"))
                    TXTTOTALPAX.Text = Val(dt.Rows(0).Item("PAX"))
                    txtremarks.Text = Convert.ToString(dt.Rows(0).Item("REMARKS"))
                    TXTPDFPATH.Text = Convert.ToString(dt.Rows(0).Item("PDFPATH"))
                    TXTTOTALPACKAGEAMT.Text = Format(Val(dt.Rows(0).Item("TOTALPACKAGEAMT")), "0.00")

                    If Val(dt.Rows(0).Item("OUTPAX")) > 0 Then
                        lbllocked.Visible = True
                        PBlock.Visible = True
                    End If

                    'BOOKING GRID
                    For Each ROW As DataRow In dt.Rows
                        GRIDBOOKINGS.Rows.Add(Val(ROW("SRNO")), ROW("HOTELNAME"), ROW("INCLUSIONS"), Format(Convert.ToDateTime(ROW("CHECKIN").DATE), "dd/MM/yyyy"), Format(Convert.ToDateTime(ROW("CHECKOUT").DATE), "dd/MM/yyyy"), ROW("ROOMTYPE"), ROW("PLANNAME"), Val(ROW("NOOFROOMS")), ROW("PACKAGE"), Format(Val(ROW("RATE")), "0.00"), Format(Val(ROW("AMOUNT")), "0.00"), Val(ROW("NIGHTS")))
                    Next
                    total()
                End If



                'TOUR DETAILS GRID
                Dim OBJCMN As New ClsCommon
                dt = OBJCMN.search(" ISNULL(GROUPDEP_NO, 0) AS GROUPDEPNO, ISNULL(GROUPDEP_SRNO, 0) AS TOURSRNO, GROUPDEP_TOURDATE AS TOURDATE, ISNULL(GROUPDEP_TOURDETAILS, '') AS TOURDETAILS", "", " GROUPDEPARTURE_TOURDETAILS ", " AND GROUPDEPARTURE_TOURDETAILS.GROUPDEP_NO = " & TEMPGROUPNO & " AND GROUPDEP_YEARID = " & YearId & " ORDER BY GROUPDEPARTURE_TOURDETAILS.GROUPDEP_SRNO")
                If dt.Rows.Count > 0 Then
                    For Each DTR As DataRow In dt.Rows
                        GRIDTOUR.Rows.Add(DTR("TOURSRNO"), Format(Convert.ToDateTime(DTR("TOURDATE").DATE), "dd/MM/yyyy"), DTR("TOURDETAILS"))
                    Next
                    total()
                End If

                'RAILWAY DETAILS GRID
                dt = OBJCMN.search(" ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_NO, 0) AS GROUPDEPNO, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_TRAINNAME, '') AS TRAINNAME, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_TRAINNO, '') AS TRAINNO, GROUPDEPARTURE_RAILWAY.GROUPDEP_JOURNEYDATE AS JOURNEYDATE, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_FROM, '') AS FRM, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_FROMCODE, '') AS FCODE, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_TO, '') AS [TO], ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_TOCODE, '') AS TOCODE, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_BOARDING, '') AS BOARDING, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_BOARDINGCODE, '') AS BCODE, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_RESTO, '') AS RESTO, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_RESTOCODE, '') AS RCODE, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_FARE, 0) AS FARE, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_EXTRACHGS, 0) AS EXTRACHGS, ISNULL(TAXMASTER.tax_name, '') AS TAXNAME, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_TAXAMT, 0) AS TAXAMT, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_GRANDTOTAL, 0) AS GTOTAL, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_DNTRAINNAME, '') AS DNTRAINNAME, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_DNTRAINNO, '') AS DNTRAINNO, GROUPDEPARTURE_RAILWAY.GROUPDEP_DNJOURNEYDATE AS DNJOURNEYDATE, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_DNFROM, '') AS DNFROM, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_DNFROMCODE, '') AS DNFCODE, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_DNTO, '') AS DNTO, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_DNTOCODE, '') AS DNTOCODE, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_DNBOARDING, '') AS DNBOARDING, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_DNBOARDINGCODE, '') AS DNBCODE, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_DNRESTO, '') AS DNRESTO, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_DNRESTOCODE, '') AS DNRCODE, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_DNFARE, 0) AS DNFARE, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_DNEXTRACHGS, 0) AS DNEXTRACHGS, ISNULL(DNTAXMASTER.tax_name, '') AS DNTAXNAME, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_DNTAXAMT, 0) AS DNTAXAMT, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_DNGRANDTOTAL, 0) AS DNGTOTAL, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_CLASS, '') AS CLASS, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_DNCLASS, '') AS DNCLASS", "", " TAXMASTER RIGHT OUTER JOIN GROUPDEPARTURE_RAILWAY ON TAXMASTER.tax_id = GROUPDEPARTURE_RAILWAY.GROUPDEP_TAXID LEFT OUTER JOIN TAXMASTER AS DNTAXMASTER ON GROUPDEPARTURE_RAILWAY.GROUPDEP_DNTAXID = DNTAXMASTER.tax_id", " AND GROUPDEPARTURE_RAILWAY.GROUPDEP_NO = " & TEMPGROUPNO & " AND GROUPDEP_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    For Each DTR As DataRow In dt.Rows
                        CMBTRAINNAME.Text = DTR("TRAINNAME")
                        CMBTRAINNO.Text = DTR("TRAINNO")
                        JOURNEYDATE.Value = Format(Convert.ToDateTime(DTR("JOURNEYDATE").DATE), "dd/MM/yyyy")
                        CMBCLASS.Text = DTR("CLASS")
                        CMBFROM.Text = DTR("FRM")
                        CMBFROMCODE.Text = DTR("FCODE")
                        CMBTO.Text = DTR("TO")
                        CMBTOCODE.Text = DTR("TOCODE")
                        CMBBOARDING.Text = DTR("BOARDING")
                        CMBBOARDINGCODE.Text = DTR("BCODE")
                        CMBRESTO.Text = DTR("RESTO")
                        CMBRESTOCODE.Text = DTR("RCODE")
                        TXTFARE.Text = Format(Val(DTR("FARE")), "0.00")
                        TXTEXTRACHGS.Text = Format(Val(DTR("EXTRACHGS")), "0.00")
                        cmbtax.Text = DTR("TAXNAME")
                        txttax.Text = Format(Val(DTR("TAXAMT")), "0.00")
                        txtgrandtotal.Text = Format(Val(DTR("GTOTAL")), "0.00")

                        CMBDNTRAINNAME.Text = DTR("DNTRAINNAME")
                        CMBDNTRAINNO.Text = DTR("DNTRAINNO")
                        DNJOURNEYDATE.Value = Format(Convert.ToDateTime(DTR("DNJOURNEYDATE").DATE), "dd/MM/yyyy")
                        CMBDNCLASS.Text = DTR("DNCLASS")
                        CMBDNFROM.Text = DTR("DNFROM")
                        CMBDNFROMCODE.Text = DTR("DNFCODE")
                        CMBDNTO.Text = DTR("DNTO")
                        CMBDNTOCODE.Text = DTR("DNTOCODE")
                        CMBDNBOARDING.Text = DTR("DNBOARDING")
                        CMBDNBOARDINGCODE.Text = DTR("DNBCODE")
                        CMBDNRESTO.Text = DTR("DNRESTO")
                        CMBDNRESTOCODE.Text = DTR("DNRCODE")
                        TXTDNFARE.Text = Format(Val(DTR("DNFARE")), "0.00")
                        TXTDNEXTRACHGS.Text = Format(Val(DTR("DNEXTRACHGS")), "0.00")
                        cmbdntax.Text = DTR("DNTAXNAME")
                        txtdntax.Text = Format(Val(DTR("DNTAXAMT")), "0.00")
                        txtdngrandtotal.Text = Format(Val(DTR("DNGTOTAL")), "0.00")
                    Next
                    total()
                End If

                'TRANSPORT GRID
                dt = OBJCMN.search(" ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_NO, 0) AS GROUPDEPNO, ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_SRNO, 0) AS SRNO, ISNULL(VEHICLEMASTER.VEHICLE_NAME, '') AS VEHICLE, GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_PICKUPON AS PICKUPON,ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_PICKUPFROM, '') AS PICKUPFROM ,ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_PICKUPTIME, '') AS PICKUPTIME, ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_PICKUPDTLS, '') AS PICKUPDTLS, GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_DROPON AS DROPON, ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_DROPAT, '') AS DROPAT, ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_DROPTIME, '') AS DROPTIME, ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_DROPDTLS, '') AS DROPDTLS, ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_CARDAYS, 0) AS CARDAYS, ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_NOTE, '') AS NOTE, ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_AMT, 0) AS AMOUNT ", "", " GROUPDEPARTURE_TRANSDETAILS INNER JOIN VEHICLEMASTER ON GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_VEHICLEID = VEHICLEMASTER.VEHICLE_ID", " AND GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_NO = " & TEMPGROUPNO & " AND GROUPDEP_YEARID = " & YearId & " ORDER BY GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_SRNO")
                If dt.Rows.Count > 0 Then
                    For Each DTR As DataRow In dt.Rows
                        GRIDTRANS.Rows.Add(DTR("SRNO"), DTR("VEHICLE"), Format(Convert.ToDateTime(DTR("PICKUPON").DATE), "dd/MM/yyyy"), DTR("PICKUPFROM"), DTR("PICKUPTIME"), DTR("PICKUPDTLS"), Format(Convert.ToDateTime(DTR("DROPON").DATE), "dd/MM/yyyy"), DTR("DROPAT"), DTR("DROPTIME"), DTR("DROPDTLS"), Val(DTR("CARDAYS")), DTR("NOTE"), Format(Val(DTR("AMOUNT")), "0.00"))
                    Next
                    total()
                End If


                'GET AIRLINE DATA
                dt = OBJCMN.search(" ISNULL(GROUPDEP_NO, 0) AS GROUPDEPNO, ISNULL(GROUPDEP_GRIDSRNO, 0) AS AIRSRNO, ISNULL(GROUPDEP_SECTOR, '') AS SECTOR, ISNULL(GROUPDEP_FLTNO, '') AS FLTNO, ISNULL(GROUPDEP_TYPE, '') AS TYPE, ISNULL(GROUPDEP_BASIC, 0) AS BASIC, ISNULL(GROUPDEP_PSF, 0) AS PSF, ISNULL(GROUPDEP_TAXES, 0) AS TAXES, ISNULL(GROUPDEP_AMT, 0) AS AIRAMT ", "", "GROUPDEPARTURE_AIRLINE", " AND GROUPDEPARTURE_AIRLINE.GROUPDEP_NO = " & TEMPGROUPNO & " AND GROUPDEP_YEARID = " & YearId & " ORDER BY GROUPDEPARTURE_AIRLINE.GROUPDEP_GRIDSRNO")
                If dt.Rows.Count > 0 Then
                    For Each DR As DataRow In dt.Rows
                        GRIDAIRLINE.Rows.Add(DR("AIRSRNO"), DR("SECTOR"), DR("FLTNO"), DR("TYPE"), Format(Val(DR("BASIC")), "0.00"), Format(Val(DR("PSF")), "0.00"), Format(Val(DR("TAXES")), "0.00"), Format(Val(DR("AIRAMT")), "0.00"))
                    Next
                    total()
                End If


                'GET GRIDFLIGHT DATA
                dt = OBJCMN.search(" GROUPDEPARTURE_FLIGHTDESC.GROUPDEP_GRIDSRNO AS GRIDSRNO, GROUPDEPARTURE_FLIGHTDESC.GROUPDEP_BOOKSRNO AS BOOKSRNO, ISNULL(FROMSECTORMASTER.SECTOR_NAME, '') AS FROMSEC, ISNULL(TOSECTORMASTER.SECTOR_NAME, '') AS TOSEC, GROUPDEPARTURE_FLIGHTDESC.GROUPDEP_FLIGHTNO AS FLIGHTNO, GROUPDEPARTURE_FLIGHTDESC.GROUPDEP_FLIGHTDATE AS FLIGHTDATE, ISNULL(GROUPDEPARTURE_FLIGHTDESC.GROUPDEP_ARRIVES, '') AS ARRIVES, CLASSMASTER.CLASS_NAME AS CLASS", "", " SECTORMASTER AS TOSECTORMASTER RIGHT OUTER JOIN GROUPDEPARTURE_FLIGHTDESC LEFT OUTER JOIN CLASSMASTER ON GROUPDEPARTURE_FLIGHTDESC.GROUPDEP_YEARID = CLASSMASTER.CLASS_YEARID AND  GROUPDEPARTURE_FLIGHTDESC.GROUPDEP_CMPID = CLASSMASTER.CLASS_CMPID AND GROUPDEPARTURE_FLIGHTDESC.GROUPDEP_CLASSID = CLASSMASTER.CLASS_ID ON  TOSECTORMASTER.SECTOR_ID = GROUPDEPARTURE_FLIGHTDESC.GROUPDEP_TOID AND TOSECTORMASTER.SECTOR_CMPID = GROUPDEPARTURE_FLIGHTDESC.GROUPDEP_CMPID AND TOSECTORMASTER.SECTOR_YEARID = GROUPDEPARTURE_FLIGHTDESC.GROUPDEP_YEARID LEFT OUTER JOIN SECTORMASTER AS FROMSECTORMASTER ON GROUPDEPARTURE_FLIGHTDESC.GROUPDEP_FROMID = FROMSECTORMASTER.SECTOR_ID AND GROUPDEPARTURE_FLIGHTDESC.GROUPDEP_CMPID = FROMSECTORMASTER.SECTOR_CMPID AND GROUPDEPARTURE_FLIGHTDESC.GROUPDEP_YEARID = FROMSECTORMASTER.SECTOR_YEARID", " AND GROUPDEPARTURE_FLIGHTDESC.GROUPDEP_NO = " & TEMPGROUPNO & " AND GROUPDEPARTURE_FLIGHTDESC.GROUPDEP_CMPID = " & CmpId & " AND GROUPDEPARTURE_FLIGHTDESC.GROUPDEP_YEARID = " & YearId & " ORDER BY GROUPDEPARTURE_FLIGHTDESC.GROUPDEP_BOOKSRNO ASC, GROUPDEPARTURE_FLIGHTDESC.GROUPDEP_GRIDSRNO ASC")
                If dt.Rows.Count > 0 Then
                    For Each DR As DataRow In dt.Rows
                        GRIDFLIGHT.Rows.Add(DR("GRIDSRNO").ToString, DR("BOOKSRNO"), DR("FROMSEC").ToString, DR("TOSEC").ToString, DR("FLIGHTNO").ToString, DR("FLIGHTDATE").ToString, DR("ARRIVES").ToString, DR("CLASS").ToString)
                    Next
                    total()
                End If


                'UPLOAD(GRID)
                dt = OBJCMN.search(" GROUPDEPARTURE_UPLOAD.GROUPDEP_SRNO AS GRIDSRNO, GROUPDEPARTURE_UPLOAD.GROUPDEP_REMARKS AS REMARKS, GROUPDEPARTURE_UPLOAD.GROUPDEP_NAME AS NAME, GROUPDEPARTURE_UPLOAD.GROUPDEP_PHOTO AS IMGPATH ", "", " GROUPDEPARTURE_UPLOAD ", " AND GROUPDEPARTURE_UPLOAD.GROUPDEP_NO = " & TEMPGROUPNO & " AND GROUPDEP_YEARID = " & YearId & " ORDER BY GROUPDEPARTURE_UPLOAD.GROUPDEP_SRNO")
                If dt.Rows.Count > 0 Then
                    For Each DTR As DataRow In dt.Rows
                        gridupload.Rows.Add(DTR("GRIDSRNO"), DTR("REMARKS"), DTR("NAME"), Image.FromStream(New IO.MemoryStream(DirectCast(DTR("IMGPATH"), Byte()))))
                    Next
                End If


                'MID RAILWAY DETAILS GRID
                dt = OBJCMN.search(" ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_NO, 0) AS GROUPDEPNO, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDUPTRAINNAME, '') AS MIDUPTRAINNAME, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDUPTRAINNO, '') AS MIDUPTRAINNO, GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDUPJOURNEYDATE AS MIDUPJOURNEYDATE, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDUPCLASS, '') AS MIDUPCLASS, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDUPFROM, '') AS MIDUPFRM, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDUPFROMCODE, '') AS MIDUPFCODE, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDUPTO, '') AS MIDUPTO, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDUPTOCODE, '') AS MIDUPTOCODE, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDUPBOARDING, '') AS MIDUPBOARDING, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDUPBOARDINGCODE, '') AS MIDUPBCODE, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDUPRESTO, '') AS MIDUPRESTO, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDUPRESTOCODE, '') AS MIDUPRCODE, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDUPFARE, 0) AS MIDUPFARE, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDUPEXTRACHGS, 0) AS MIDUPEXTRACHGS, ISNULL(MIDUPTAXMASTER.tax_name, '') AS MIDUPTAXNAME,ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDUPTAXAMT, 0) AS MIDUPTAXAMT, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDUPGRANDTOTAL, 0) AS MIDUPGTOTAL, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDDNTRAINNAME, '') AS MIDDNTRAINNAME, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDDNTRAINNO, '') AS MIDDNTRAINNO, GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDDNJOURNEYDATE AS MIDDNJOURNEYDATE, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDDNCLASS, '') AS MIDDNCLASS, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDDNFROM, '') AS MIDDNFROM, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDDNFROMCODE, '') AS MIDDNFCODE, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDDNTO, '') AS MIDDNTO, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDDNTOCODE, '') AS MIDDNTOCODE, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDDNBOARDING, '') AS MIDDNBOARDING, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDDNBOARDINGCODE, '') AS MIDDNBCODE, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDDNRESTO, '') AS MIDDNRESTO, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDDNRESTOCODE, '') AS MIDDNRCODE, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDDNFARE, 0) AS MIDDNFARE, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDDNEXTRACHGS, 0) AS MIDDNEXTRACHGS, ISNULL(MIDDNTAXMASTER.tax_name, '') AS MIDDNTAXNAME, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDDNTAXAMT, 0) AS MIDDNTAXAMT, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDDNGRANDTOTAL, 0) AS MIDDNGTOTAL", "", " GROUPDEPARTURE_MIDRAILWAY LEFT OUTER JOIN TAXMASTER AS MIDDNTAXMASTER ON GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDDNTAXID = MIDDNTAXMASTER.tax_id LEFT OUTER JOIN TAXMASTER AS MIDUPTAXMASTER ON GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDUPTAXID = MIDUPTAXMASTER.tax_id", " AND GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_NO = " & TEMPGROUPNO & " AND GROUPDEP_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    For Each DTR As DataRow In dt.Rows
                        CMBMIDUPTRAINNAME.Text = DTR("MIDUPTRAINNAME")
                        CMBMIDUPTRAINNO.Text = DTR("MIDUPTRAINNO")
                        MIDUPJOURNEYDATE.Value = Format(Convert.ToDateTime(DTR("MIDUPJOURNEYDATE").DATE), "dd/MM/yyyy")
                        CMBMIDUPCLASS.Text = DTR("MIDUPCLASS")
                        CMBMIDUPFROM.Text = DTR("MIDUPFRM")
                        CMBMIDUPFROMCODE.Text = DTR("MIDUPFCODE")
                        CMBMIDUPTO.Text = DTR("MIDUPTO")
                        CMBMIDUPTOCODE.Text = DTR("MIDUPTOCODE")
                        CMBMIDUPBOARDING.Text = DTR("MIDUPBOARDING")
                        CMBMIDUPBOARDINGCODE.Text = DTR("MIDUPBCODE")
                        CMBMIDUPRESTO.Text = DTR("MIDUPRESTO")
                        CMBMIDUPRESTOCODE.Text = DTR("MIDUPRCODE")
                        TXTMIDUPFARE.Text = Format(Val(DTR("MIDUPFARE")), "0.00")
                        TXTMIDUPEXTRACHGS.Text = Format(Val(DTR("MIDUPEXTRACHGS")), "0.00")
                        cmbmiduptax.Text = DTR("MIDUPTAXNAME")
                        txtmiduptax.Text = Format(Val(DTR("MIDUPTAXAMT")), "0.00")
                        txtmidupgrandtotal.Text = Format(Val(DTR("MIDUPGTOTAL")), "0.00")

                        CMBMIDDNTRAINNAME.Text = DTR("MIDDNTRAINNAME")
                        CMBMIDDNTRAINNO.Text = DTR("MIDDNTRAINNO")
                        MIDDNJOURNEYDATE.Value = Format(Convert.ToDateTime(DTR("MIDDNJOURNEYDATE").DATE), "dd/MM/yyyy")
                        CMBMIDDNCLASS.Text = DTR("MIDDNCLASS")
                        CMBMIDDNFROM.Text = DTR("MIDDNFROM")
                        CMBMIDDNFROMCODE.Text = DTR("MIDDNFCODE")
                        CMBMIDDNTO.Text = DTR("MIDDNTO")
                        CMBMIDDNTOCODE.Text = DTR("MIDDNTOCODE")
                        CMBMIDDNBOARDING.Text = DTR("MIDDNBOARDING")
                        CMBMIDDNBOARDINGCODE.Text = DTR("MIDDNBCODE")
                        CMBMIDDNRESTO.Text = DTR("MIDDNRESTO")
                        CMBMIDDNRESTOCODE.Text = DTR("MIDDNRCODE")
                        TXTMIDDNFARE.Text = Format(Val(DTR("MIDDNFARE")), "0.00")
                        TXTMIDDNEXTRACHGS.Text = Format(Val(DTR("MIDDNEXTRACHGS")), "0.00")
                        cmbmiddntax.Text = DTR("MIDDNTAXNAME")
                        txtmiddntax.Text = Format(Val(DTR("MIDDNTAXAMT")), "0.00")
                        txtmiddngrandtotal.Text = Format(Val(DTR("MIDDNGTOTAL")), "0.00")
                    Next
                    total()
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

            alParaval.Add(GROUPDATE.Value.Date)
            alParaval.Add(txtrefno.Text.Trim)
            alParaval.Add(CMBGROUPNAME.Text.Trim)
            alParaval.Add(PACKAGEFROM.Value.Date)
            alParaval.Add(PACKAGETO.Value.Date)
            alParaval.Add(Val(TXTTOTALNIGHTS.Text.Trim))
            alParaval.Add(Val(TXTTOTALPAX.Text.Trim))
            alParaval.Add(TXTROUTE.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(TXTPDFPATH.Text.Trim)
            alParaval.Add(Val(TXTTOTALPACKAGEAMT.Text.Trim))
            alParaval.Add(CMBITINERARY.Text.Trim)

            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)

            'BOOKING DETAILS
            Dim gridsrno As String = ""
            Dim HOTELNAME As String = ""
            Dim INCLUSIONS As String = ""
            Dim CHECKIN As String = ""
            Dim CHECKOUT As String = ""
            Dim ROOMTYPE As String = ""
            Dim PLAN As String = ""
            Dim NOOFROOMS As String = ""
            Dim PACKAGE As String = ""
            Dim RATE As String = ""
            Dim AMT As String = ""
            Dim TOTALNIGHTS As String = ""


            For Each row As Windows.Forms.DataGridViewRow In GRIDBOOKINGS.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = Val(row.Cells(GSRNO.Index).Value)
                        HOTELNAME = row.Cells(GHOTELNAME.Index).Value.ToString
                        INCLUSIONS = row.Cells(GINCLUSIONS.Index).Value.ToString
                        CHECKIN = Format(Convert.ToDateTime(row.Cells(GCHECKIN.Index).Value).Date, "MM/dd/yyyy")
                        CHECKOUT = Format(Convert.ToDateTime(row.Cells(GCHECKOUT.Index).Value).Date, "MM/dd/yyyy")
                        ROOMTYPE = row.Cells(groomtype.Index).Value.ToString
                        PLAN = row.Cells(gplan.Index).Value.ToString
                        NOOFROOMS = Val(row.Cells(gnoofRooms.Index).Value)
                        PACKAGE = row.Cells(gpack.Index).Value.ToString
                        RATE = Format(Val(row.Cells(grate.Index).Value), "0.00")
                        AMT = Format(Val(row.Cells(gamt.Index).Value), "0.00")
                        TOTALNIGHTS = Val(row.Cells(GNIGHTS.Index).Value)

                    Else

                        gridsrno = gridsrno & "|" & Val(row.Cells(GSRNO.Index).Value)
                        HOTELNAME = HOTELNAME & "|" & row.Cells(GHOTELNAME.Index).Value
                        INCLUSIONS = INCLUSIONS & "|" & row.Cells(GINCLUSIONS.Index).Value.ToString
                        CHECKIN = CHECKIN & "|" & Format(Convert.ToDateTime(row.Cells(GCHECKIN.Index).Value).Date, "MM/dd/yyyy")
                        CHECKOUT = CHECKOUT & "|" & Format(Convert.ToDateTime(row.Cells(GCHECKOUT.Index).Value).Date, "MM/dd/yyyy")
                        ROOMTYPE = ROOMTYPE & "|" & row.Cells(groomtype.Index).Value
                        PLAN = PLAN & "|" & row.Cells(gplan.Index).Value.ToString
                        NOOFROOMS = NOOFROOMS & "|" & Val(row.Cells(gnoofRooms.Index).Value)
                        PACKAGE = PACKAGE & "|" & row.Cells(gpack.Index).Value.ToString
                        RATE = RATE & "|" & Format(Val(row.Cells(grate.Index).Value), "0.00")
                        AMT = AMT & "|" & Format(Val(row.Cells(gamt.Index).Value), "0.00")
                        TOTALNIGHTS = TOTALNIGHTS & "|" & Val(row.Cells(GNIGHTS.Index).Value)

                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(HOTELNAME)
            alParaval.Add(INCLUSIONS)
            alParaval.Add(CHECKIN)
            alParaval.Add(CHECKOUT)
            alParaval.Add(ROOMTYPE)
            alParaval.Add(PLAN)
            alParaval.Add(NOOFROOMS)
            alParaval.Add(PACKAGE)
            alParaval.Add(RATE)
            alParaval.Add(AMT)
            alParaval.Add(TOTALNIGHTS)

            'TOUR DETAILS
            Dim TOURSRNO As String = ""
            Dim TOURDATE As String = ""
            Dim TOURDETAILS As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDTOUR.Rows
                If row.Cells(0).Value <> Nothing Then
                    If TOURSRNO = "" Then
                        TOURSRNO = Val(row.Cells(GTOURSRNO.Index).Value)
                        TOURDATE = Format(Convert.ToDateTime(row.Cells(GTOURDATE.Index).Value).Date, "MM/dd/yyyy")
                        TOURDETAILS = row.Cells(GTOURDETAILS.Index).Value.ToString

                    Else

                        TOURSRNO = TOURSRNO & "|" & Val(row.Cells(GTOURSRNO.Index).Value)
                        TOURDATE = TOURDATE & "|" & Format(Convert.ToDateTime(row.Cells(GTOURDATE.Index).Value).Date, "MM/dd/yyyy")
                        TOURDETAILS = TOURDETAILS & "|" & row.Cells(GTOURDETAILS.Index).Value.ToString
                    End If
                End If
            Next

            alParaval.Add(TOURSRNO)
            alParaval.Add(TOURDATE)
            alParaval.Add(TOURDETAILS)


            'RAILWAY DETAILS
            alParaval.Add(CMBTRAINNAME.Text.Trim)
            alParaval.Add(CMBTRAINNO.Text.Trim)
            alParaval.Add(JOURNEYDATE.Value.Date)
            alParaval.Add(CMBCLASS.Text.Trim)
            alParaval.Add(CMBFROM.Text.Trim)
            alParaval.Add(CMBFROMCODE.Text.Trim)
            alParaval.Add(CMBTO.Text.Trim)
            alParaval.Add(CMBTOCODE.Text.Trim)
            alParaval.Add(CMBBOARDING.Text.Trim)
            alParaval.Add(CMBBOARDINGCODE.Text.Trim)
            alParaval.Add(CMBRESTO.Text.Trim)
            alParaval.Add(CMBRESTOCODE.Text.Trim)
            alParaval.Add(Format(Val(TXTFARE.Text.Trim), "0.00"))
            alParaval.Add(Format(Val(TXTEXTRACHGS.Text.Trim), "0.00"))
            alParaval.Add(cmbtax.Text.Trim)
            alParaval.Add(Format(Val(txttax.Text.Trim), "0.00"))
            alParaval.Add(Format(Val(txtgrandtotal.Text.Trim), "0.00"))

            alParaval.Add(CMBDNTRAINNAME.Text.Trim)
            alParaval.Add(CMBDNTRAINNO.Text.Trim)
            alParaval.Add(DNJOURNEYDATE.Value.Date)
            alParaval.Add(CMBDNCLASS.Text.Trim)
            alParaval.Add(CMBDNFROM.Text.Trim)
            alParaval.Add(CMBDNFROMCODE.Text.Trim)
            alParaval.Add(CMBDNTO.Text.Trim)
            alParaval.Add(CMBDNTOCODE.Text.Trim)
            alParaval.Add(CMBDNBOARDING.Text.Trim)
            alParaval.Add(CMBDNBOARDINGCODE.Text.Trim)
            alParaval.Add(CMBDNRESTO.Text.Trim)
            alParaval.Add(CMBDNRESTOCODE.Text.Trim)
            alParaval.Add(Format(Val(TXTDNFARE.Text.Trim), "0.00"))
            alParaval.Add(Format(Val(TXTDNEXTRACHGS.Text.Trim), "0.00"))
            alParaval.Add(cmbdntax.Text.Trim)
            alParaval.Add(Format(Val(txtdntax.Text.Trim), "0.00"))
            alParaval.Add(Format(Val(txtdngrandtotal.Text.Trim), "0.00"))


            ''TRANS DETAILS
            Dim CARSRNO As String = ""
            Dim CARNAME As String = ""
            Dim PICKUPON As String = ""
            Dim PICKUPFROM As String = ""
            Dim PICKUPTIME As String = ""
            Dim PICKUPDTLS As String = ""
            Dim DROPON As String = ""
            Dim DROPAT As String = ""
            Dim DROPTIME As String = ""
            Dim DROPDTLS As String = ""
            Dim CARDAYS As String = ""
            Dim CARNOTE As String = ""
            Dim CARAMT As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDTRANS.Rows
                If row.Cells(GCARSRNO.Index).Value <> Nothing Then
                    If CARSRNO = "" Then
                        CARSRNO = Val(row.Cells(GCARSRNO.Index).Value)
                        CARNAME = row.Cells(GCARNAME.Index).Value.ToString
                        PICKUPON = Format(Convert.ToDateTime(row.Cells(GCARPICKUP.Index).Value).Date, "MM/dd/yyyy")
                        PICKUPFROM = row.Cells(GCARPICKUPFROM.Index).Value.ToString
                        PICKUPTIME = row.Cells(GCARPICKUPTIME.Index).Value.ToString
                        PICKUPDTLS = row.Cells(GCARPICKUPDTLS.Index).Value.ToString
                        DROPON = Format(Convert.ToDateTime(row.Cells(GCARDROP.Index).Value).Date, "MM/dd/yyyy")
                        DROPAT = row.Cells(GCARDROPTO.Index).Value.ToString
                        DROPTIME = row.Cells(GCARDROPTIME.Index).Value.ToString
                        DROPDTLS = row.Cells(GCARDROPDTLS.Index).Value.ToString
                        CARDAYS = row.Cells(GCARDAYS.Index).Value.ToString
                        CARNOTE = row.Cells(GCARNOTE.Index).Value.ToString
                        CARAMT = row.Cells(GCARAMT.Index).Value.ToString

                    Else

                        CARSRNO = CARSRNO & "|" & Val(row.Cells(GCARSRNO.Index).Value)
                        CARNAME = CARNAME & "|" & row.Cells(GCARNAME.Index).Value.ToString
                        PICKUPON = PICKUPON & "|" & Format(Convert.ToDateTime(row.Cells(GCARPICKUP.Index).Value).Date, "MM/dd/yyyy")
                        PICKUPFROM = PICKUPFROM & "|" & row.Cells(GCARPICKUPFROM.Index).Value.ToString
                        PICKUPTIME = PICKUPTIME & "|" & row.Cells(GCARPICKUPTIME.Index).Value.ToString
                        PICKUPDTLS = PICKUPDTLS & "|" & row.Cells(GCARPICKUPDTLS.Index).Value.ToString
                        DROPON = DROPON & "|" & Format(Convert.ToDateTime(row.Cells(GCARDROP.Index).Value).Date, "MM/dd/yyyy")
                        DROPAT = DROPAT & "|" & row.Cells(GCARDROPTO.Index).Value.ToString
                        DROPTIME = DROPTIME & "|" & row.Cells(GCARDROPTIME.Index).Value.ToString
                        DROPDTLS = DROPDTLS & "|" & row.Cells(GCARDROPDTLS.Index).Value.ToString
                        CARDAYS = CARDAYS & "|" & row.Cells(GCARDAYS.Index).Value.ToString
                        CARNOTE = CARNOTE & "|" & row.Cells(GCARNOTE.Index).Value.ToString
                        CARAMT = CARAMT & "|" & Val(row.Cells(GCARAMT.Index).Value.ToString)

                    End If
                End If
            Next


            alParaval.Add(CARSRNO)
            alParaval.Add(CARNAME)
            alParaval.Add(PICKUPON)
            alParaval.Add(PICKUPFROM)
            alParaval.Add(PICKUPTIME)
            alParaval.Add(PICKUPDTLS)
            alParaval.Add(DROPON)
            alParaval.Add(DROPAT)
            alParaval.Add(DROPTIME)
            alParaval.Add(DROPDTLS)
            alParaval.Add(CARDAYS)
            alParaval.Add(CARNOTE)
            alParaval.Add(CARAMT)


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


            'MID RAILWAY DETAILS

            alParaval.Add(CMBMIDUPTRAINNAME.Text.Trim)
            alParaval.Add(CMBMIDUPTRAINNO.Text.Trim)
            alParaval.Add(MIDUPJOURNEYDATE.Value.Date)
            alParaval.Add(CMBMIDUPCLASS.Text.Trim)
            alParaval.Add(CMBMIDUPFROM.Text.Trim)
            alParaval.Add(CMBMIDUPFROMCODE.Text.Trim)
            alParaval.Add(CMBMIDUPTO.Text.Trim)
            alParaval.Add(CMBMIDUPTOCODE.Text.Trim)
            alParaval.Add(CMBMIDUPBOARDING.Text.Trim)
            alParaval.Add(CMBMIDUPBOARDINGCODE.Text.Trim)
            alParaval.Add(CMBMIDUPRESTO.Text.Trim)
            alParaval.Add(CMBMIDUPRESTOCODE.Text.Trim)
            alParaval.Add(Format(Val(TXTMIDUPFARE.Text.Trim), "0.00"))
            alParaval.Add(Format(Val(TXTMIDUPEXTRACHGS.Text.Trim), "0.00"))
            alParaval.Add(cmbmiduptax.Text.Trim)
            alParaval.Add(Format(Val(txtmiduptax.Text.Trim), "0.00"))
            alParaval.Add(Format(Val(txtmidupgrandtotal.Text.Trim), "0.00"))

            alParaval.Add(CMBMIDDNTRAINNAME.Text.Trim)
            alParaval.Add(CMBMIDDNTRAINNO.Text.Trim)
            alParaval.Add(MIDDNJOURNEYDATE.Value.Date)
            alParaval.Add(CMBMIDDNCLASS.Text.Trim)
            alParaval.Add(CMBMIDDNFROM.Text.Trim)
            alParaval.Add(CMBMIDDNFROMCODE.Text.Trim)
            alParaval.Add(CMBMIDDNTO.Text.Trim)
            alParaval.Add(CMBMIDDNTOCODE.Text.Trim)
            alParaval.Add(CMBMIDDNBOARDING.Text.Trim)
            alParaval.Add(CMBMIDDNBOARDINGCODE.Text.Trim)
            alParaval.Add(CMBMIDDNRESTO.Text.Trim)
            alParaval.Add(CMBMIDDNRESTOCODE.Text.Trim)
            alParaval.Add(Format(Val(TXTMIDDNFARE.Text.Trim), "0.00"))
            alParaval.Add(Format(Val(TXTMIDDNEXTRACHGS.Text.Trim), "0.00"))
            alParaval.Add(cmbmiddntax.Text.Trim)
            alParaval.Add(Format(Val(txtmiddntax.Text.Trim), "0.00"))
            alParaval.Add(Format(Val(txtmiddngrandtotal.Text.Trim), "0.00"))

            'GRID MISC
            Dim MISCSRNO As String = ""
            Dim MISCSERVICETYPE As String = ""
            Dim MISCREMARKS As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDMISC.Rows
                If row.Cells(0).Value <> Nothing Then
                    If MISCSRNO = "" Then
                        MISCSRNO = Val(row.Cells(GMISCSRNO.Index).Value)
                        MISCSERVICETYPE = row.Cells(GMISCSERVICETYPE.Index).Value.ToString
                        MISCREMARKS = row.Cells(GMISCREMARKS.Index).Value.ToString
                    Else
                        MISCSRNO = MISCSRNO & "|" & Val(row.Cells(GMISCSRNO.Index).Value)
                        MISCSERVICETYPE = MISCSERVICETYPE & "|" & row.Cells(GMISCSERVICETYPE.Index).Value.ToString
                        MISCREMARKS = MISCREMARKS & "|" & row.Cells(GMISCREMARKS.Index).Value.ToString
                    End If
                End If
            Next

            alParaval.Add(MISCSRNO)
            alParaval.Add(MISCSERVICETYPE)
            alParaval.Add(MISCREMARKS)



            Dim OBJGRPDEP As New ClsGroupDeparture()
            OBJGRPDEP.alParaval = alParaval

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTNO As DataTable = OBJGRPDEP.SAVE()
                MsgBox("Details Added")
            Else

                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPGROUPNO)

                IntResult = OBJGRPDEP.update()
                MsgBox("Details Updated")
                edit = False
            End If
            If gridupload.RowCount > 0 Then SAVEUPLOAD()
            clear()
            CMBGROUPNAME.Focus()
            CMBGROUPNAME.Text = ""
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub SAVEUPLOAD()

        Try
            Dim OBJGROUP As New ClsGroupDeparture
            For Each row As Windows.Forms.DataGridViewRow In gridupload.Rows
                Dim MS As New IO.MemoryStream
                Dim ALPARAVAL As New ArrayList
                If row.Cells(GUSRNO.Index).Value <> Nothing Then
                    ALPARAVAL.Add(TXTGROUPNO.Text.Trim)
                    ALPARAVAL.Add(row.Cells(GUSRNO.Index).Value)
                    ALPARAVAL.Add(row.Cells(GUREMARKS.Index).Value)
                    ALPARAVAL.Add(row.Cells(GUNAME.Index).Value)

                    PBSOFTCOPY.Image = row.Cells(GUIMGPATH.Index).Value
                    PBSOFTCOPY.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                    ALPARAVAL.Add(MS.ToArray)
                    ALPARAVAL.Add(YearId)

                    OBJGROUP.alParaval = ALPARAVAL
                    Dim INTRES As Integer = OBJGROUP.SAVEUPLOAD()
                End If
            Next


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLUPLOAD()

        If gridUPLOADdoubleclick = False Then
            gridupload.Rows.Add(Val(TXTUPLOADSRNO.Text.Trim), txtuploadremarks.Text.Trim, txtuploadname.Text.Trim, PBSOFTCOPY.Image)
            getsrno(gridupload)
        ElseIf gridUPLOADdoubleclick = True Then

            gridupload.Item(GUSRNO.Index, tempUPLOADrow).Value = TXTUPLOADSRNO.Text.Trim
            gridupload.Item(GUREMARKS.Index, tempUPLOADrow).Value = txtuploadremarks.Text.Trim
            gridupload.Item(GUNAME.Index, tempUPLOADrow).Value = txtuploadname.Text.Trim
            gridupload.Item(GUIMGPATH.Index, tempUPLOADrow).Value = PBSOFTCOPY.Image

            gridUPLOADdoubleclick = False

        End If
        gridupload.FirstDisplayedScrollingRowIndex = gridupload.RowCount - 1

        TXTUPLOADSRNO.Clear()
        txtuploadremarks.Clear()
        txtuploadname.Clear()
        PBSOFTCOPY.Image = Nothing
        TXTIMGPATH.Clear()

        txtuploadremarks.Focus()

    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        Dim OBJCMN As New ClsCommon
        Dim DT As DataTable

        If Not datecheck(GROUPDATE.Value) Then
            EP.SetError(GROUPDATE, "Date Not in Current Accounting Year")
            bln = False
        End If

        If CMBGROUPNAME.Text.Trim = "" Then
            EP.SetError(CMBGROUPNAME, " Please Fill Group name")
            bln = False
        End If

        If Val(TXTTOTALNIGHTS.Text.Trim) = 0 Then
            EP.SetError(TXTTOTALNIGHTS, " Please Enter Proper Dates")
            bln = False
        End If

        If UserName <> "Admin" Then
            If lbllocked.Visible = True Then
                EP.SetError(lbllocked, " Group Locked, Invoices Raised")
                bln = False
            End If
        End If

        If GRIDBOOKINGS.RowCount = 0 Then
            EP.SetError(TXTTOTAL, "Enter Proper Details")
            bln = False
        End If


        If Not datecheck(GROUPDATE.Value) Then
            EP.SetError(GROUPDATE, "Date Not in Current Accounting Year")
            bln = False
        End If


        If Val(TXTTOTALPACKAGEAMT.Text.Trim) = 0 Then
            EP.SetError(TXTTOTALPACKAGEAMT, " Please Enter Total Package Amt.")
            bln = False
        End If


        For Each ROW As DataGridViewRow In GRIDBOOKINGS.Rows
            If Convert.ToDateTime(ROW.Cells(GCHECKIN.Index).Value).Date < PACKAGEFROM.Value.Date Then
                bln = False
                EP.SetError(PACKAGETO, "Invalid Check In Date")
            End If
            If Convert.ToDateTime(ROW.Cells(GCHECKOUT.Index).Value).Date > PACKAGETO.Value.Date Then
                bln = False
                EP.SetError(PACKAGETO, "Invalid Check Out Date")
            End If
            If Convert.ToDateTime(ROW.Cells(GCHECKIN.Index).Value).Date > Convert.ToDateTime(ROW.Cells(GCHECKOUT.Index).Value).Date Then
                bln = False
                EP.SetError(PACKAGETO, "Check In Cannot be greater than Check Out Date")
            End If
        Next

        For Each ROW As DataGridViewRow In GRIDTRANS.Rows
            If Convert.ToDateTime(ROW.Cells(GCARPICKUP.Index).Value).Date < PACKAGEFROM.Value.Date Then
                bln = False
                EP.SetError(PACKAGETO, "Invalid Pickup Date")
            End If
            If Convert.ToDateTime(ROW.Cells(GCARDROP.Index).Value).Date > PACKAGETO.Value.Date Then
                bln = False
                EP.SetError(PACKAGETO, "Invalid Drop Date")
            End If
            If Convert.ToDateTime(ROW.Cells(GCARPICKUP.Index).Value).Date > Convert.ToDateTime(ROW.Cells(GCARDROP.Index).Value).Date Then
                bln = False
                EP.SetError(PACKAGETO, "Pick-up Date Cannot be greater than Drop Date")
            End If
        Next



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

        Return bln
    End Function

    Sub total()
        Try
            Dim net_purchase As Double = 0

            TXTTOTALAMT.Text = "0.00"
            TXTTOTALROOMS.Text = 0
            TXTCARTOTALAMT.Text = 0.0

            TXTTOTALBASIC.Text = "0.00"
            TXTTOTALPSF.Text = "0.00"
            TXTTOTALTAXES.Text = "0.00"
            TXTAIRTOTAL.Text = "0.00"

            TXTTOTALNIGHTS.Clear()

            txttax.Clear()
            txtdntax.Clear()
            txtgrandtotal.Clear()
            txtdngrandtotal.Clear()
            txtmiduptax.Clear()
            txtmiddntax.Clear()
            txtmidupgrandtotal.Clear()
            txtmiddngrandtotal.Clear()



            If GRIDBOOKINGS.RowCount > 0 Then
                For Each row As DataGridViewRow In GRIDBOOKINGS.Rows
                    If Val(row.Cells(gnoofRooms.Index).Value) > 0 Then TXTTOTALROOMS.Text = Val(TXTTOTALROOMS.Text) + Val(row.Cells(gnoofRooms.Index).Value)
                    row.Cells(GNIGHTS.Index).Value = DateDiff(DateInterval.Day, Convert.ToDateTime(row.Cells(GCHECKIN.Index).Value).Date, Convert.ToDateTime(row.Cells(GCHECKOUT.Index).Value).Date)
                    If Val(row.Cells(gamt.Index).Value) > 0 Then TXTTOTALAMT.Text = Format(Val(TXTTOTALAMT.Text) + Val(row.Cells(gamt.Index).Value), "0.00")
                    TXTTOTALNIGHTS.Text = Val(TXTTOTALNIGHTS.Text.Trim) + Val(row.Cells(GNIGHTS.Index).Value)
                Next
            End If

            If GRIDTRANS.RowCount > 0 Then
                For Each ROW As DataGridViewRow In GRIDTRANS.Rows
                    If Val(ROW.Cells(GCARAMT.Index).Value) > 0 Then TXTCARTOTALAMT.Text = Format(Val(TXTCARTOTALAMT.Text) + Val(ROW.Cells(GCARAMT.Index).Value), "0.00")
                Next
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


            Dim objclscmn As New ClsCommonMaster
            Dim DT As DataTable = objclscmn.search("TAX_NAME ,tax_tax AS TAX", "", "TAXMaster", " and TAX_NAME = '" & cmbtax.Text.Trim & "' And TAX_Yearid = " & YearId)
            If DT.Rows.Count > 0 Then txttax.Text = Format(((Val(TXTEXTRACHGS.Text.Trim) * Val(DT.Rows(0).Item(1))) / 100), "0.00")

            DT = objclscmn.search("TAX_NAME ,tax_tax AS TAX", "", "TAXMaster", " and TAX_NAME = '" & cmbdntax.Text.Trim & "' and TAX_Yearid = " & YearId)
            If DT.Rows.Count > 0 Then txtdntax.Text = Format(((Val(TXTDNEXTRACHGS.Text.Trim) * Val(DT.Rows(0).Item(1))) / 100), "0.00")

            DT = objclscmn.search("TAX_NAME ,tax_tax AS TAX", "", "TAXMaster", " and TAX_NAME = '" & cmbmiduptax.Text.Trim & "' and TAX_Yearid = " & YearId)
            If DT.Rows.Count > 0 Then txtmiduptax.Text = Format(((Val(TXTMIDUPEXTRACHGS.Text.Trim) * Val(DT.Rows(0).Item(1))) / 100), "0.00")

            DT = objclscmn.search("TAX_NAME ,tax_tax AS TAX", "", "TAXMaster", " and TAX_NAME = '" & cmbmiddntax.Text.Trim & "' and TAX_Yearid = " & YearId)
            If DT.Rows.Count > 0 Then txtmiddntax.Text = Format(((Val(TXTMIDDNEXTRACHGS.Text.Trim) * Val(DT.Rows(0).Item(1))) / 100), "0.00")


            txtgrandtotal.Text = Format((Val(TXTFARE.Text.Trim) + Val(TXTEXTRACHGS.Text.Trim) + Val(txttax.Text.Trim)), "0.00")
            txtdngrandtotal.Text = Format((Val(TXTDNFARE.Text.Trim) + Val(TXTDNEXTRACHGS.Text.Trim) + Val(txtdntax.Text.Trim)), "0.00")

            txtmidupgrandtotal.Text = Format((Val(TXTMIDUPFARE.Text.Trim) + Val(TXTMIDUPEXTRACHGS.Text.Trim) + Val(txtmiduptax.Text.Trim)), "0.00")
            txtmiddngrandtotal.Text = Format((Val(TXTMIDDNFARE.Text.Trim) + Val(TXTMIDDNEXTRACHGS.Text.Trim) + Val(txtmiddntax.Text.Trim)), "0.00")


            'TXTTOTALPACKAGEAMT.Text = Format((Val(TXTTOTALAMT.Text.Trim) + Val(txtdngrandtotal.Text.Trim) + Val(txtgrandtotal.Text.Trim) + Val(TXTAIRTOTAL.Text.Trim) + Val(TXTCARTOTALAMT.Text.Trim) + Val(txtmidupgrandtotal.Text.Trim) + Val(txtmiddngrandtotal.Text.Trim)), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsrno.GotFocus
        If gridDoubleClick = False Then
            If GRIDBOOKINGS.RowCount > 0 Then txtsrno.Text = Val(GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(GSRNO.Index).Value) + 1 Else txtsrno.Text = 1
        End If
    End Sub

    Private Sub TXTAIRSRNO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTAIRSRNO.GotFocus
        If GRIDAIRDOUBLECLICK = False Then
            If GRIDAIRLINE.RowCount > 0 Then TXTAIRSRNO.Text = Val(GRIDAIRLINE.Rows(GRIDAIRLINE.RowCount - 1).Cells(GAIRSRNO.Index).Value) + 1 Else TXTAIRSRNO.Text = 1
        End If
    End Sub

    Private Sub TXTAIRAMT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTAIRAMT.Validating
        If Val(TXTBASIC.Text.Trim) > 0 And Val(TXTGRIDTAX.Text.Trim) > 0 And Val(TXTAIRAMT.Text.Trim) > 0 Then
            FILLAIRLINEGRID()
        Else
            MsgBox("Enter Proper Details", MsgBoxStyle.Critical, "TRAVELMATE")
            Exit Sub
        End If
    End Sub

    Private Sub TXTTOTAL_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTTOTAL.Validating
        If CMBHOTELNAME.Text.Trim <> "" And CMBROOMTYPE.Text.Trim <> "" And CMBPLAN.Text.Trim <> "" And Val(TXTNOOFROOMS.Text.Trim) > 0 And CMBPACKAGE.Text.Trim <> "" Then
            fillgrid()
            total()
        Else
            MsgBox("Enter Proper Details", MsgBoxStyle.Critical, "TRAVELMATE")
            Exit Sub
        End If
    End Sub

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
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
                GRIDAIRLINE.Item(GAIRSRNO.Index, TEMPFLIGHTROW).Value = Val(TXTAIRSRNO.Text.Trim)
                GRIDAIRLINE.Item(GSECTOR.Index, TEMPFLIGHTROW).Value = TXTTEMPSECTOR.Text.Trim
                GRIDAIRLINE.Item(GFLTNO.Index, TEMPFLIGHTROW).Value = TXTFLTNO.Text.Trim
                GRIDAIRLINE.Item(GTYPE.Index, TEMPFLIGHTROW).Value = CMBTYPE.Text.Trim
                GRIDAIRLINE.Item(GBASIC.Index, TEMPFLIGHTROW).Value = Format(Val(TXTBASIC.Text.Trim), "0.00")
                GRIDAIRLINE.Item(GPSF.Index, TEMPFLIGHTROW).Value = Format(Val(TXTPSF.Text.Trim), "0.00")
                GRIDAIRLINE.Item(GTAXES.Index, TEMPFLIGHTROW).Value = Format(Val(TXTGRIDTAX.Text.Trim), "0.00")
                GRIDAIRLINE.Item(GTOTAL.Index, TEMPFLIGHTROW).Value = Format(Val(TXTAIRAMT.Text.Trim), "0.00")


                'FIRST REMOVE OLD RECORDS AND THEN ADD NEW 
LINE1:
                For Each ROW As DataGridViewRow In GRIDFLIGHT.Rows
                    If ROW.Cells(GBOOKSRNO.Index).Value = TEMPFLIGHTROW + 1 Then
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

    Function getBookingSr(ByVal trimSECTORS As String) As Integer
        Dim booksrno As Integer = 0
        For Each dbrows As System.Windows.Forms.DataGridViewRow In GRIDAIRLINE.Rows
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

    Sub fillgrid()

        EP.Clear()
        If Not CALDAYS() Then
            Exit Sub
        End If

        GRIDBOOKINGS.Enabled = True
        If gridDoubleClick = False Then
            GRIDBOOKINGS.Rows.Add(Val(txtsrno.Text.Trim), CMBHOTELNAME.Text.Trim, TXTINCLUSIONS.Text.Trim, Format(CHECKINDATE.Value.Date, "dd/MM/yyyy"), Format(CHECKOUTDATE.Value.Date, "dd/MM/yyyy"), CMBROOMTYPE.Text.Trim, CMBPLAN.Text.Trim, Val(TXTNOOFROOMS.Text.Trim), CMBPACKAGE.Text.Trim, Format(Val(TXTRATE.Text.Trim), "0.00"), Format(Val(TXTTOTAL.Text.Trim), "0.00"), DateDiff(DateInterval.Day, CHECKINDATE.Value.Date, CHECKOUTDATE.Value.Date))
            getsrno(GRIDBOOKINGS)
        ElseIf gridDoubleClick = True Then
            GRIDBOOKINGS.Item(GSRNO.Index, temprow).Value = Val(txtsrno.Text.Trim)
            GRIDBOOKINGS.Item(GHOTELNAME.Index, temprow).Value = CMBHOTELNAME.Text.Trim
            GRIDBOOKINGS.Item(GINCLUSIONS.Index, temprow).Value = TXTINCLUSIONS.Text.Trim
            GRIDBOOKINGS.Item(GCHECKIN.Index, temprow).Value = Format(CHECKINDATE.Value.Date, "dd/MM/yyyy")
            GRIDBOOKINGS.Item(GCHECKOUT.Index, temprow).Value = Format(CHECKOUTDATE.Value.Date, "dd/MM/yyyy")
            GRIDBOOKINGS.Item(groomtype.Index, temprow).Value = CMBROOMTYPE.Text.Trim
            GRIDBOOKINGS.Item(gplan.Index, temprow).Value = CMBPLAN.Text.Trim
            GRIDBOOKINGS.Item(gnoofRooms.Index, temprow).Value = Val(TXTNOOFROOMS.Text.Trim)
            GRIDBOOKINGS.Item(gpack.Index, temprow).Value = CMBPACKAGE.Text.Trim
            GRIDBOOKINGS.Item(grate.Index, temprow).Value = Format(Val(TXTRATE.Text.Trim), "0.00")
            GRIDBOOKINGS.Item(gamt.Index, temprow).Value = Format(Val(TXTTOTAL.Text.Trim), "0.00")
            GRIDBOOKINGS.Item(GNIGHTS.Index, temprow).Value = DateDiff(DateInterval.Day, CHECKINDATE.Value.Date, CHECKOUTDATE.Value.Date)
            gridDoubleClick = False
        End If
        GRIDBOOKINGS.FirstDisplayedScrollingRowIndex = GRIDBOOKINGS.RowCount - 1

        txtsrno.Clear()
        CMBHOTELNAME.Text = ""
        CHECKINDATE.Value = CHECKOUTDATE.Value.Date
        CHECKOUTDATE.Value = DateAdd(DateInterval.Day, 1, CHECKINDATE.Value.Date)
        CMBROOMTYPE.Text = ""
        TXTRATE.Clear()
        TXTTOTAL.Clear()
        TXTBTOTALNIGHTS.Clear()
        CMBHOTELNAME.Focus()
        temprow = 0

    End Sub

    Sub FILLTOURGRID()
        Try

            If gridTOURDoubleClick = False Then
                GRIDTOUR.Rows.Add(Val(TXTTOURSRNO.Text.Trim), Format(TOURDATE.Value.Date, "dd/MM/yyyy"), TXTTOURDETAILS.Text.Trim)
                getsrno(GRIDTOUR)
            ElseIf gridTOURDoubleClick = True Then
                GRIDTOUR.Item(GTOURSRNO.Index, temptourrow).Value = Val(TXTTOURSRNO.Text.Trim)
                GRIDTOUR.Item(GTOURDATE.Index, temptourrow).Value = Format(TOURDATE.Value.Date, "dd/MM/yyyy")
                GRIDTOUR.Item(GTOURDETAILS.Index, temptourrow).Value = TXTTOURDETAILS.Text.Trim
                gridTOURDoubleClick = False
            End If

            TXTTOURSRNO.Text = ""
            TOURDATE.Value = DateAdd(DateInterval.Day, 1, TOURDATE.Value.Date)
            TXTTOURDETAILS.Clear()
            temptourrow = 0
            TOURDATE.Focus()

            If GRIDTOUR.RowCount > 0 Then TXTTOURSRNO.Text = Val(GRIDTOUR.RowCount) + 1 Else TXTTOURSRNO.Text = 1
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDTOUR_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDTOUR.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDTOUR.Item(GTOURSRNO.Index, e.RowIndex).Value <> Nothing Then

                gridTOURDoubleClick = True
                TXTTOURSRNO.Text = GRIDTOUR.Item(GTOURSRNO.Index, e.RowIndex).Value
                TOURDATE.Value = GRIDTOUR.Item(GTOURDATE.Index, e.RowIndex).Value
                TXTTOURDETAILS.Text = GRIDTOUR.Item(GTOURDETAILS.Index, e.RowIndex).Value.ToString
                temptourrow = e.RowIndex
                TOURDATE.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDTOUR_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDTOUR.KeyDown
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
                total()

            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDBOOKINGS_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDBOOKINGS.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDBOOKINGS.Item(GSRNO.Index, e.RowIndex).Value <> Nothing Then

                gridDoubleClick = True
                txtsrno.Text = GRIDBOOKINGS.Item(GSRNO.Index, e.RowIndex).Value.ToString
                CMBHOTELNAME.Text = GRIDBOOKINGS.Item(GHOTELNAME.Index, e.RowIndex).Value.ToString
                FILLROOMTYPE()
                TXTINCLUSIONS.Text = GRIDBOOKINGS.Item(GINCLUSIONS.Index, e.RowIndex).Value.ToString
                CHECKINDATE.Value = GRIDBOOKINGS.Item(GCHECKIN.Index, e.RowIndex).Value
                CHECKOUTDATE.Value = GRIDBOOKINGS.Item(GCHECKOUT.Index, e.RowIndex).Value
                CMBROOMTYPE.Text = GRIDBOOKINGS.Item(groomtype.Index, e.RowIndex).Value
                CMBPLAN.Text = GRIDBOOKINGS.Item(gplan.Index, e.RowIndex).Value.ToString
                TXTNOOFROOMS.Text = GRIDBOOKINGS.Item(gnoofRooms.Index, e.RowIndex).Value.ToString
                CMBPACKAGE.Text = GRIDBOOKINGS.Item(gpack.Index, e.RowIndex).Value.ToString
                TXTRATE.Text = GRIDBOOKINGS.Item(grate.Index, e.RowIndex).Value.ToString
                TXTTOTAL.Text = GRIDBOOKINGS.Item(gamt.Index, e.RowIndex).Value.ToString
                temprow = e.RowIndex
                CMBHOTELNAME.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDAIRLINE_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDAIRLINE.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDAIRLINE.Item(GSRNO.Index, e.RowIndex).Value <> Nothing Then

                GRIDAIRDOUBLECLICK = True
                TXTAIRSRNO.Text = GRIDAIRLINE.Item(GAIRSRNO.Index, e.RowIndex).Value.ToString
                TXTSECTOR.Text = GRIDAIRLINE.Item(GSECTOR.Index, e.RowIndex).Value.ToString
                TXTFLTNO.Text = GRIDAIRLINE.Item(GFLTNO.Index, e.RowIndex).Value.ToString
                CMBTYPE.Text = GRIDAIRLINE.Item(GTYPE.Index, e.RowIndex).Value.ToString
                TXTBASIC.Text = GRIDAIRLINE.Item(GBASIC.Index, e.RowIndex).Value.ToString
                TXTPSF.Text = GRIDAIRLINE.Item(GPSF.Index, e.RowIndex).Value.ToString
                TXTGRIDTAX.Text = GRIDAIRLINE.Item(GTAXES.Index, e.RowIndex).Value.ToString
                TXTTOTAL.Text = GRIDAIRLINE.Item(GTOTAL.Index, e.RowIndex).Value.ToString
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

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If tstxtbillno.Text.Trim.Length = 0 Then Exit Sub
            GRIDBOOKINGS.RowCount = 0
            TEMPGROUPNO = Val(tstxtbillno.Text)
            If TEMPGROUPNO > 0 Then
                edit = True
                GroupDeparture_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            Dim OBJGRPDEP As New GroupDepartureDetails
            OBJGRPDEP.MdiParent = MDIMain
            OBJGRPDEP.Show()
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
            TEMPGROUPNO = Val(TXTGROUPNO.Text) - 1
            If TEMPGROUPNO > 0 Then
                edit = True
                GroupDeparture_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If GRIDBOOKINGS.RowCount = 0 And TEMPGROUPNO > 1 Then
                TXTGROUPNO.Text = TEMPGROUPNO
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
            TEMPGROUPNO = Val(TXTGROUPNO.Text) + 1
            getmax_GROUP_no()
            Dim MAXNO As Integer = TXTGROUPNO.Text.Trim
            clear()
            If Val(TXTGROUPNO.Text) - 1 >= TEMPGROUPNO Then
                edit = True
                GroupDeparture_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If GRIDBOOKINGS.RowCount = 0 And TEMPGROUPNO < MAXNO Then
                TXTGROUPNO.Text = TEMPGROUPNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbhotelname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBHOTELNAME.Enter
        Try
            If CMBHOTELNAME.Text.Trim = "" Then fillHOTEL(CMBHOTELNAME)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGROUPNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBGROUPNAME.Enter
        Try
            If CMBGROUPNAME.Text.Trim = "" Then FILLGROUPNAME()
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
            If CMBHOTELNAME.Text.Trim <> "" Then HOTELvalidate(CMBHOTELNAME, CMBCODE, e, Me, TXTADD)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCODE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBCODE.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBGROUPNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBGROUPNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPNAME <> "" Then CMBGROUPNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGROUPNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGROUPNAME.Validating
        Try
            Try
                If CMBGROUPNAME.Text.Trim <> "" Then
                    pcase(CMBGROUPNAME)
                    Dim objclscommon As New ClsCommonMaster
                    Dim dt As DataTable
                    If (edit = False) Or (edit = True And LCase(CMBGROUPNAME.Text.Trim) <> LCase(TEMPGROUPNAME)) Then
                        dt = objclscommon.search("GROUPDEP_NAME", "", " GROUPDEPARTURE ", " AND GROUPDEP_NAME = '" & CMBGROUPNAME.Text.Trim & "' AND GROUPDEP_CMPID = " & CmpId & "  AND GROUPDEP_YEARID = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("Group Name Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                            e.Cancel = True
                        End If
                    End If
                End If
            Catch ex As Exception
                If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
            End Try
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

                If lbllocked.Visible = True Then
                    MsgBox("Group Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                Dim tempmsg As Integer = MsgBox("Delete Group Departure Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                If tempmsg = vbYes Then

                    Dim OBJGRPDEP As New ClsGroupDeparture
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(TEMPGROUPNO)
                    ALPARAVAL.Add(YearId)

                    OBJGRPDEP.alParaval = ALPARAVAL
                    Dim DT As DataTable = OBJGRPDEP.Delete()
                    'MsgBox(DT.Rows(0).Item(0).ToString)
                    MsgBox("Group Departure Deleted")

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
            Else
                TXTTOTAL.Text = 0
            End If
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

    Private Sub CMBPLAN_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPLAN.Validating
        Try
            If CMBPLAN.Text.Trim <> "" Then
                Dim INCLUSIONS As String = ""
                PLANvalidate(CMBPLAN, e, Me, INCLUSIONS)

                If ClientName = "JESAL" Then
                    Dim EXISTINGINCLUSIONS As String = TXTINCLUSIONS.Text.Trim
                    TXTINCLUSIONS.Text = INCLUSIONS & " " & EXISTINGINCLUSIONS
                End If

            End If

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
            FILLROOMTYPE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTRATE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTRATE.KeyPress
        numdotkeypress(e, TXTRATE, Me)
    End Sub

    Private Sub TXTRATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTRATE.Validating
        Try
            If Val(TXTRATE.Text.Trim) > 0 And Val(TXTNOOFROOMS.Text.Trim) > 0 Then
                CALC()
            Else
                TXTTOTAL.Text = 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
        'Try
        '    If Val(TXTRATE.Text.Trim) > 0 And Val(TXTNOOFROOMS.Text.Trim) > 0 Then
        '        TXTTOTAL.Text = Format(Val(TXTRATE.Text.Trim) * Val(TXTNOOFROOMS.Text.Trim), "0.00")
        '    End If
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub

    Private Sub CMBROOMTYPE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBROOMTYPE.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True


    End Sub

    Private Sub TXTCOPY_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCOPY.Validated
        Try
            If Val(TXTCOPY.Text.Trim) > 0 Then
                If edit = True Then
                    MsgBox("Copy Allowed only in Fresh mode", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If TXTCOPY.Text.Trim <> "" Then
                    TEMPMSG = MsgBox("Wish to Copy Voucher No " & Val(TXTCOPY.Text.Trim) & "?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbYes Then

                        TEMPGROUPNO = TXTCOPY.Text.Trim
                        clear()

                        TXTCOPY.Text = TEMPGROUPNO
                        TEMPGROUPNO = 0

                        Dim ALPARAVAL As New ArrayList
                        Dim OBJGRPDEP As New ClsGroupDeparture()

                        ALPARAVAL.Add(TXTCOPY.Text.Trim)
                        ALPARAVAL.Add(YearId)

                        OBJGRPDEP.alParaval = ALPARAVAL
                        Dim dt As DataTable = OBJGRPDEP.SELECTBOOKINGDESC()
                        If dt.Rows.Count > 0 Then


                            txtrefno.Text = dt.Rows(0).Item("REFNO")

                            PACKAGEFROM.Value = Convert.ToDateTime(dt.Rows(0).Item("FROMDATE")).Date
                            PACKAGETO.Value = Convert.ToDateTime(dt.Rows(0).Item("TODATE")).Date
                            TXTROUTE.Text = Convert.ToString(dt.Rows(0).Item("ROUTE"))
                            TXTTOTALNIGHTS.Text = Val(dt.Rows(0).Item("TOTALNIGHTS"))
                            TXTTOTALPAX.Text = Val(dt.Rows(0).Item("PAX"))
                            txtremarks.Text = Convert.ToString(dt.Rows(0).Item("REMARKS"))


                            'BOOKING GRID
                            For Each dr As DataRow In dt.Rows
                                GRIDBOOKINGS.Rows.Add(Val(dr("SRNO")), dr("HOTELNAME"), dr("INCLUSIONS"), Format(Convert.ToDateTime(dr("CHECKIN").DATE), "dd/MM/yyyy"), Format(Convert.ToDateTime(dr("CHECKOUT").DATE), "dd/MM/yyyy"), dr("ROOMTYPE"), dr("PLANNAME"), Val(dr("NOOFROOMS")), dr("PACKAGE"), Format(Val(dr("RATE")), "0.00"), Format(Val(dr("AMOUNT")), "0.00"), Val(dr("NIGHTS")))
                            Next

                            GRIDBOOKINGS.FirstDisplayedScrollingRowIndex = GRIDBOOKINGS.RowCount - 1
                        End If


                        'TOUR DETAILS GRID
                        Dim OBJCMN As New ClsCommon
                        dt = OBJCMN.search(" ISNULL(GROUPDEP_NO, 0) AS GROUPDEPNO, ISNULL(GROUPDEP_SRNO, 0) AS TOURSRNO, GROUPDEP_TOURDATE AS TOURDATE, ISNULL(GROUPDEP_TOURDETAILS, '') AS TOURDETAILS", "", " GROUPDEPARTURE_TOURDETAILS ", " AND GROUPDEPARTURE_TOURDETAILS.GROUPDEP_NO = " & Val(TXTCOPY.Text.Trim) & " AND GROUPDEP_YEARID = " & YearId & " ORDER BY GROUPDEPARTURE_TOURDETAILS.GROUPDEP_SRNO")
                        If dt.Rows.Count > 0 Then
                            For Each DTR As DataRow In dt.Rows
                                GRIDTOUR.Rows.Add(DTR("TOURSRNO"), Format(Convert.ToDateTime(DTR("TOURDATE").DATE), "dd/MM/yyyy"), DTR("TOURDETAILS"))
                            Next
                        End If

                        'RAILWAY DETAILS GRID
                        dt = OBJCMN.search(" ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_NO, 0) AS GROUPDEPNO, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_TRAINNAME, '') AS TRAINNAME, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_TRAINNO, '') AS TRAINNO, GROUPDEPARTURE_RAILWAY.GROUPDEP_JOURNEYDATE AS JOURNEYDATE, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_FROM, '') AS FRM, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_FROMCODE, '') AS FCODE, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_TO, '') AS [TO], ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_TOCODE, '') AS TOCODE, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_BOARDING, '') AS BOARDING, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_BOARDINGCODE, '') AS BCODE, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_RESTO, '') AS RESTO, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_RESTOCODE, '') AS RCODE, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_FARE, 0) AS FARE, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_EXTRACHGS, 0) AS EXTRACHGS, ISNULL(TAXMASTER.tax_name, '') AS TAXNAME, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_TAXAMT, 0) AS TAXAMT, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_GRANDTOTAL, 0) AS GTOTAL, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_DNTRAINNAME, '') AS DNTRAINNAME, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_DNTRAINNO, '') AS DNTRAINNO, GROUPDEPARTURE_RAILWAY.GROUPDEP_DNJOURNEYDATE AS DNJOURNEYDATE, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_DNFROM, '') AS DNFROM, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_DNFROMCODE, '') AS DNFCODE, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_DNTO, '') AS DNTO, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_DNTOCODE, '') AS DNTOCODE, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_DNBOARDING, '') AS DNBOARDING, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_DNBOARDINGCODE, '') AS DNBCODE, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_DNRESTO, '') AS DNRESTO, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_DNRESTOCODE, '') AS DNRCODE, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_DNFARE, 0) AS DNFARE, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_DNEXTRACHGS, 0) AS DNEXTRACHGS, ISNULL(DNTAXMASTER.tax_name, '') AS DNTAXNAME, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_DNTAXAMT, 0) AS DNTAXAMT, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_DNGRANDTOTAL, 0) AS DNGTOTAL, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_CLASS, '') AS CLASS, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_DNCLASS, '') AS DNCLASS", "", " TAXMASTER RIGHT OUTER JOIN GROUPDEPARTURE_RAILWAY ON TAXMASTER.tax_id = GROUPDEPARTURE_RAILWAY.GROUPDEP_TAXID LEFT OUTER JOIN TAXMASTER AS DNTAXMASTER ON GROUPDEPARTURE_RAILWAY.GROUPDEP_DNTAXID = DNTAXMASTER.tax_id", " AND GROUPDEPARTURE_RAILWAY.GROUPDEP_NO = " & Val(TXTCOPY.Text.Trim) & " AND GROUPDEP_YEARID = " & YearId)
                        If dt.Rows.Count > 0 Then
                            For Each DTR As DataRow In dt.Rows
                                CMBTRAINNAME.Text = DTR("TRAINNAME")
                                CMBTRAINNO.Text = DTR("TRAINNO")
                                JOURNEYDATE.Value = Format(Convert.ToDateTime(DTR("JOURNEYDATE").DATE), "dd/MM/yyyy")
                                CMBCLASS.Text = DTR("CLASS")
                                CMBFROM.Text = DTR("FRM")
                                CMBFROMCODE.Text = DTR("FCODE")
                                CMBTO.Text = DTR("TO")
                                CMBTOCODE.Text = DTR("TOCODE")
                                CMBBOARDING.Text = DTR("BOARDING")
                                CMBBOARDINGCODE.Text = DTR("BCODE")
                                CMBRESTO.Text = DTR("RESTO")
                                CMBRESTOCODE.Text = DTR("RCODE")
                                TXTFARE.Text = Format(Val(DTR("FARE")), "0.00")
                                TXTEXTRACHGS.Text = Format(Val(DTR("EXTRACHGS")), "0.00")
                                cmbtax.Text = DTR("TAXNAME")
                                txttax.Text = Format(Val(DTR("TAXAMT")), "0.00")
                                txtgrandtotal.Text = Format(Val(DTR("GTOTAL")), "0.00")

                                CMBDNTRAINNAME.Text = DTR("DNTRAINNAME")
                                CMBDNTRAINNO.Text = DTR("DNTRAINNO")
                                DNJOURNEYDATE.Value = Format(Convert.ToDateTime(DTR("DNJOURNEYDATE").DATE), "dd/MM/yyyy")
                                CMBDNCLASS.Text = DTR("DNCLASS")
                                CMBDNFROM.Text = DTR("DNFROM")
                                CMBDNFROMCODE.Text = DTR("DNFCODE")
                                CMBDNTO.Text = DTR("DNTO")
                                CMBDNTOCODE.Text = DTR("DNTOCODE")
                                CMBDNBOARDING.Text = DTR("DNBOARDING")
                                CMBDNBOARDINGCODE.Text = DTR("DNBCODE")
                                CMBDNRESTO.Text = DTR("DNRESTO")
                                CMBDNRESTOCODE.Text = DTR("DNRCODE")
                                TXTDNFARE.Text = Format(Val(DTR("DNFARE")), "0.00")
                                TXTDNEXTRACHGS.Text = Format(Val(DTR("DNEXTRACHGS")), "0.00")
                                cmbdntax.Text = DTR("DNTAXNAME")
                                txtdntax.Text = Format(Val(DTR("DNTAXAMT")), "0.00")
                                txtdngrandtotal.Text = Format(Val(DTR("DNGTOTAL")), "0.00")
                            Next
                        End If

                        'TRANSPORT GRID
                        dt = OBJCMN.search(" ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_NO, 0) AS GROUPDEPNO, ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_SRNO, 0) AS SRNO, ISNULL(VEHICLEMASTER.VEHICLE_NAME, '') AS VEHICLE, GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_PICKUPON AS PICKUPON,ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_PICKUPFROM, '') AS PICKUPFROM ,ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_PICKUPTIME, '') AS PICKUPTIME, ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_PICKUPDTLS, '') AS PICKUPDTLS, GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_DROPON AS DROPON, ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_DROPAT, '') AS DROPAT, ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_DROPTIME, '') AS DROPTIME, ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_DROPDTLS, '') AS DROPDTLS, ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_CARDAYS, 0) AS CARDAYS, ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_NOTE, '') AS NOTE, ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_AMT, 0) AS AMOUNT ", "", " GROUPDEPARTURE_TRANSDETAILS INNER JOIN VEHICLEMASTER ON GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_VEHICLEID = VEHICLEMASTER.VEHICLE_ID", " AND GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_NO = " & Val(TXTCOPY.Text.Trim) & " AND GROUPDEP_YEARID = " & YearId & " ORDER BY GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_SRNO")
                        If dt.Rows.Count > 0 Then
                            For Each DTR As DataRow In dt.Rows
                                GRIDTRANS.Rows.Add(DTR("SRNO"), DTR("VEHICLE"), Format(Convert.ToDateTime(DTR("PICKUPON").DATE), "dd/MM/yyyy"), DTR("PICKUPFROM"), DTR("PICKUPTIME"), DTR("PICKUPDTLS"), Format(Convert.ToDateTime(DTR("DROPON").DATE), "dd/MM/yyyy"), DTR("DROPAT"), DTR("DROPTIME"), DTR("DROPDTLS"), Val(DTR("CARDAYS")), DTR("NOTE"), Format(Val(DTR("AMOUNT")), "0.00"))
                            Next
                        End If


                        'GET AIRLINE DATA
                        dt = OBJCMN.search(" ISNULL(GROUPDEP_NO, 0) AS GROUPDEPNO, ISNULL(GROUPDEP_GRIDSRNO, 0) AS AIRSRNO, ISNULL(GROUPDEP_SECTOR, '') AS SECTOR, ISNULL(GROUPDEP_FLTNO, '') AS FLTNO, ISNULL(GROUPDEP_TYPE, '') AS TYPE, ISNULL(GROUPDEP_BASIC, 0) AS BASIC, ISNULL(GROUPDEP_PSF, 0) AS PSF, ISNULL(GROUPDEP_TAXES, 0) AS TAXES, ISNULL(GROUPDEP_AMT, 0) AS AIRAMT ", "", "GROUPDEPARTURE_AIRLINE", " AND GROUPDEPARTURE_AIRLINE.GROUPDEP_NO = " & Val(TXTCOPY.Text.Trim) & " AND GROUPDEP_YEARID = " & YearId & " ORDER BY GROUPDEPARTURE_AIRLINE.GROUPDEP_GRIDSRNO")
                        If dt.Rows.Count > 0 Then
                            For Each DR As DataRow In dt.Rows
                                GRIDAIRLINE.Rows.Add(DR("AIRSRNO"), DR("SECTOR"), DR("FLTNO"), DR("TYPE"), Format(Val(DR("BASIC")), "0.00"), Format(Val(DR("PSF")), "0.00"), Format(Val(DR("TAXES")), "0.00"), Format(Val(DR("AIRAMT")), "0.00"))
                            Next
                        End If


                        'GET GRIDFLIGHT DATA
                        dt = OBJCMN.search(" GROUPDEPARTURE_FLIGHTDESC.GROUPDEP_GRIDSRNO AS GRIDSRNO, GROUPDEPARTURE_FLIGHTDESC.GROUPDEP_BOOKSRNO AS BOOKSRNO, ISNULL(FROMSECTORMASTER.SECTOR_NAME, '') AS FROMSEC, ISNULL(TOSECTORMASTER.SECTOR_NAME, '') AS TOSEC, GROUPDEPARTURE_FLIGHTDESC.GROUPDEP_FLIGHTNO AS FLIGHTNO, GROUPDEPARTURE_FLIGHTDESC.GROUPDEP_FLIGHTDATE AS FLIGHTDATE, ISNULL(GROUPDEPARTURE_FLIGHTDESC.GROUPDEP_ARRIVES, '') AS ARRIVES, CLASSMASTER.CLASS_NAME AS CLASS", "", " SECTORMASTER AS TOSECTORMASTER RIGHT OUTER JOIN GROUPDEPARTURE_FLIGHTDESC LEFT OUTER JOIN CLASSMASTER ON GROUPDEPARTURE_FLIGHTDESC.GROUPDEP_YEARID = CLASSMASTER.CLASS_YEARID AND  GROUPDEPARTURE_FLIGHTDESC.GROUPDEP_CMPID = CLASSMASTER.CLASS_CMPID AND GROUPDEPARTURE_FLIGHTDESC.GROUPDEP_CLASSID = CLASSMASTER.CLASS_ID ON  TOSECTORMASTER.SECTOR_ID = GROUPDEPARTURE_FLIGHTDESC.GROUPDEP_TOID AND TOSECTORMASTER.SECTOR_CMPID = GROUPDEPARTURE_FLIGHTDESC.GROUPDEP_CMPID AND TOSECTORMASTER.SECTOR_YEARID = GROUPDEPARTURE_FLIGHTDESC.GROUPDEP_YEARID LEFT OUTER JOIN SECTORMASTER AS FROMSECTORMASTER ON GROUPDEPARTURE_FLIGHTDESC.GROUPDEP_FROMID = FROMSECTORMASTER.SECTOR_ID AND GROUPDEPARTURE_FLIGHTDESC.GROUPDEP_CMPID = FROMSECTORMASTER.SECTOR_CMPID AND GROUPDEPARTURE_FLIGHTDESC.GROUPDEP_YEARID = FROMSECTORMASTER.SECTOR_YEARID", " AND GROUPDEPARTURE_FLIGHTDESC.GROUPDEP_NO = " & Val(TXTCOPY.Text.Trim) & " AND GROUPDEPARTURE_FLIGHTDESC.GROUPDEP_CMPID = " & CmpId & " AND GROUPDEPARTURE_FLIGHTDESC.GROUPDEP_YEARID = " & YearId & " ORDER BY GROUPDEPARTURE_FLIGHTDESC.GROUPDEP_BOOKSRNO ASC, GROUPDEPARTURE_FLIGHTDESC.GROUPDEP_GRIDSRNO ASC")
                        If dt.Rows.Count > 0 Then
                            For Each DR As DataRow In dt.Rows
                                GRIDFLIGHT.Rows.Add(DR("GRIDSRNO").ToString, DR("BOOKSRNO"), DR("FROMSEC").ToString, DR("TOSEC").ToString, DR("FLIGHTNO").ToString, DR("FLIGHTDATE").ToString, DR("ARRIVES").ToString, DR("CLASS").ToString)
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

    Private Sub GroupDeparture_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName <> "RAMKRISHNA" And ClientName <> "KHANNA" And ClientName <> "AIRTRINITY" Then
            Me.Close()
            Exit Sub
        End If
        If edit = False Then clear()
    End Sub

    Private Sub bookingdate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles GROUPDATE.Validating
        'If Not datecheck(GROUPDATE.Value) Then
        '    MsgBox("Date Not in Current Accounting Year")
        '    e.Cancel = True
        'End If
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
        If edit = False Then PACKAGETO.Value = DateAdd(DateInterval.Day, 1, PACKAGEFROM.Value)
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
        TXTTOTALNIGHTS.Text = PACKAGETO.Value.Date.Subtract(PACKAGEFROM.Value.Date).Days
        CHECKOUTDATE.Value = PACKAGETO.Value.Date
        DROPDDATE.Value = PACKAGETO.Value.Date
    End Sub

    Private Sub CHECKINDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CHECKINDATE.Validating
        If ClientName = "CLASSIC" Then
            If Not datecheck(CHECKINDATE.Value) Then
                MsgBox("Date Not in Current Accounting Year")
                e.Cancel = True
            End If
        End If
        If edit = False Then CHECKOUTDATE.Value = DateAdd(DateInterval.Day, 1, CHECKINDATE.Value)
    End Sub

    Private Sub CHECKOUTDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CHECKOUTDATE.Validating
        If ClientName = "CLASSIC" Then
            If Not datecheck(CHECKOUTDATE.Value) Then
                MsgBox("Date Not in Current Accounting Year")
                e.Cancel = True
            End If
        End If
    End Sub

    'Sub fillgridscan()
    '    Try
    '        If gridUPLOADdoubleclick = False Then

    '            gridupload.Rows.Add(Val(txtuploadsrno.Text.Trim), txtuploadremarks.Text.Trim, txtuploadname.Text.Trim, txtimgpath.Text.Trim, TXTNEWIMGPATH.Text.Trim, TXTFILENAME.Text.Trim)
    '            uploadgetsrno(gridupload)

    '        ElseIf gridUPLOADdoubleclick = True Then

    '            gridupload.Item(0, tempUPLOADrow).Value = txtuploadsrno.Text.Trim
    '            gridupload.Item(1, tempUPLOADrow).Value = txtuploadremarks.Text.Trim
    '            gridupload.Item(2, tempUPLOADrow).Value = txtuploadname.Text.Trim
    '            gridupload.Item(3, tempUPLOADrow).Value = txtimgpath.Text.Trim
    '            gridupload.Item(GNEWIMGPATH.Index, tempUPLOADrow).Value = TXTNEWIMGPATH.Text.Trim
    '            gridupload.Item(GFILENAME.Index, tempUPLOADrow).Value = TXTFILENAME.Text.Trim

    '            gridUPLOADdoubleclick = False

    '        End If
    '        gridupload.FirstDisplayedScrollingRowIndex = gridupload.RowCount - 1
    '    Catch ex As Exception
    '        If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
    '    End Try
    'End Sub

    'Private Sub cmdupload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    If (edit = True And USEREDIT = False And USERVIEW = False) Or (edit = False And USERADD = False) Then
    '        MsgBox("Insufficient Rights")
    '        Exit Sub
    '    End If

    '    OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg;*.png;*.pdf)|*.bmp;*.jpg;*.png;*.pdf"
    '    OpenFileDialog1.ShowDialog()

    '    OpenFileDialog1.AddExtension = True
    '    TXTFILENAME.Text = OpenFileDialog1.SafeFileName
    '    txtimgpath.Text = OpenFileDialog1.FileName
    '    TXTNEWIMGPATH.Text = Application.StartupPath & "\HOLIDAY\" & TXTGROUPNO.Text.Trim & txtuploadsrno.Text.Trim & TXTFILENAME.Text.Trim
    '    On Error Resume Next

    '    If txtimgpath.Text.Trim.Length <> 0 Then
    '        PBSoftCopy.ImageLocation = txtimgpath.Text.Trim
    '        PBSoftCopy.Load(txtimgpath.Text.Trim)
    '        txtuploadsrno.Focus()
    '    End If
    'End Sub

    'Private Sub txtuploadname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
    '    Try
    '        If txtimgpath.Text.Trim <> "" And txtuploadname.Text.Trim <> "" Then
    '            fillgridscan()
    '            txtuploadremarks.Clear()
    '            txtuploadname.Clear()
    '            txtimgpath.Clear()
    '            PBSoftCopy.ImageLocation = ""
    '            txtuploadsrno.Focus()
    '        End If
    '    Catch ex As Exception
    '        If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
    '    End Try
    'End Sub

    'Private Sub gridupload_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    '    Try
    '        If gridupload.Rows(e.RowIndex).Cells(GGRIDUPLOADSRNO.Index).Value <> Nothing Then
    '            gridUPLOADdoubleclick = True
    '            tempUPLOADrow = e.RowIndex
    '            txtuploadsrno.Text = gridupload.Rows(e.RowIndex).Cells(GGRIDUPLOADSRNO.Index).Value
    '            txtuploadremarks.Text = gridupload.Rows(e.RowIndex).Cells(GREMARKS.Index).Value
    '            txtuploadname.Text = gridupload.Rows(e.RowIndex).Cells(GGRIDUPLOADNAME.Index).Value
    '            txtimgpath.Text = gridupload.Rows(e.RowIndex).Cells(GIMGPATH.Index).Value
    '            TXTNEWIMGPATH.Text = gridupload.Rows(e.RowIndex).Cells(GNEWIMGPATH.Index).Value
    '            TXTFILENAME.Text = gridupload.Rows(e.RowIndex).Cells(GFILENAME.Index).Value
    '            txtuploadsrno.Focus()
    '        End If

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub gridupload_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    If e.KeyCode = Keys.Delete And gridupload.RowCount > 0 Then
    '        Dim TEMPMSG As Integer = MsgBox("This Will Delete File, Wish to Proceed?", MsgBoxStyle.YesNo)
    '        If TEMPMSG = vbYes Then
    '            If FileIO.FileSystem.FileExists(gridupload.Rows(gridupload.CurrentRow.Index).Cells(GNEWIMGPATH.Index).Value) Then FileIO.FileSystem.DeleteFile(gridupload.Rows(gridupload.CurrentRow.Index).Cells(GNEWIMGPATH.Index).Value)
    '            gridupload.Rows.RemoveAt(gridupload.CurrentRow.Index)
    '            uploadgetsrno(gridupload)
    '        End If
    '    End If
    'End Sub

    'Private Sub gridupload_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    '    Try
    '        If gridupload.RowCount > 0 Then
    '            If Not FileIO.FileSystem.FileExists(gridupload.Rows(e.RowIndex).Cells(GNEWIMGPATH.Index).Value) Then
    '                PBSoftCopy.ImageLocation = gridupload.Rows(e.RowIndex).Cells(GIMGPATH.Index).Value
    '            Else
    '                PBSoftCopy.ImageLocation = gridupload.Rows(e.RowIndex).Cells(GNEWIMGPATH.Index).Value
    '            End If
    '        End If
    '    Catch ex As Exception
    '        If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
    '    End Try
    'End Sub

    'Private Sub txtuploadsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If gridUPLOADdoubleclick = False Then
    '        If gridupload.RowCount > 0 Then
    '            txtuploadsrno.Text = Val(gridupload.Rows(gridupload.RowCount - 1).Cells(GGRIDUPLOADSRNO.Index).Value) + 1
    '        Else
    '            txtuploadsrno.Text = 1
    '        End If
    '    End If
    'End Sub

    'Sub uploadgetsrno(ByRef grid As System.Windows.Forms.DataGridView)
    '    Try
    '        'If edit = False Then
    '        Dim i As Integer = 0
    '        For Each row As DataGridViewRow In grid.Rows
    '            If row.Visible = True Then
    '                row.Cells(GGRIDUPLOADSRNO.Index).Value = i + 1
    '                i = i + 1
    '            End If
    '        Next
    '        'End If
    '    Catch ex As Exception
    '        If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
    '    End Try
    'End Sub

    'Private Sub CMDVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        If txtimgpath.Text.Trim <> "" Then
    '            If Path.GetExtension(txtimgpath.Text.Trim) = ".pdf" Then
    '                System.Diagnostics.Process.Start(txtimgpath.Text.Trim)
    '            Else
    '                Dim objVIEW As New ViewImage
    '                objVIEW.pbsoftcopy.ImageLocation = PBSoftCopy.ImageLocation
    '                objVIEW.ShowDialog()
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

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

    Sub FILLGRIDCAR()
        Try
            EP.Clear()
            If Not CALDAYS() Then
                Exit Sub
            End If

            If GRIDCARDOUBLECLICK = False Then

                GRIDTRANS.Rows.Add(Val(TXTCARSRNO.Text.Trim), CMBCARNAME.Text.Trim, Format(PICKUPDATE.Value.Date, "dd/MM/yyyy"), TXTPICKFROM.Text.Trim, TXTPICKTIME.Text.Trim, TXTPICKDTLS.Text.Trim, Format(DROPDDATE.Value.Date, "dd/MM/yyyy"), TXTDROPAT.Text.Trim, TXTDROPTIME.Text.Trim, TXTDROPDTLS.Text.Trim, Val(TXTCARDAYS.Text.Trim), TXTCARNOTE.Text.Trim, Val(TXTCARAMT.Text.Trim))
                getsrno(GRIDTRANS)

            ElseIf GRIDCARDOUBLECLICK = True Then

                GRIDTRANS.Item(GCARSRNO.Index, TEMPCARROW).Value = TXTCARSRNO.Text.Trim
                GRIDTRANS.Item(GCARNAME.Index, TEMPCARROW).Value = CMBCARNAME.Text.Trim
                GRIDTRANS.Item(GCARPICKUP.Index, TEMPCARROW).Value = Format(PICKUPDATE.Value.Date, "dd/MM/yyyy")
                GRIDTRANS.Item(GCARPICKUPFROM.Index, TEMPCARROW).Value = TXTPICKFROM.Text.Trim
                GRIDTRANS.Item(GCARPICKUPTIME.Index, TEMPCARROW).Value = TXTPICKTIME.Text.Trim
                GRIDTRANS.Item(GCARPICKUPDTLS.Index, TEMPCARROW).Value = TXTPICKDTLS.Text.Trim
                GRIDTRANS.Item(GCARDROP.Index, TEMPCARROW).Value = Format(DROPDDATE.Value.Date, "dd/MM/yyyy")
                GRIDTRANS.Item(GCARDROPTO.Index, TEMPCARROW).Value = TXTDROPAT.Text.Trim
                GRIDTRANS.Item(GCARDROPTIME.Index, TEMPCARROW).Value = TXTDROPTIME.Text.Trim
                GRIDTRANS.Item(GCARDROPDTLS.Index, TEMPCARROW).Value = TXTDROPDTLS.Text.Trim
                GRIDTRANS.Item(GCARDAYS.Index, TEMPCARROW).Value = Val(TXTCARDAYS.Text.Trim)
                GRIDTRANS.Item(GCARNOTE.Index, TEMPCARROW).Value = TXTCARNOTE.Text.Trim
                GRIDTRANS.Item(GCARAMT.Index, TEMPCARROW).Value = Val(TXTCARAMT.Text.Trim)

                GRIDCARDOUBLECLICK = False

            End If
            GRIDTRANS.FirstDisplayedScrollingRowIndex = GRIDTRANS.RowCount - 1

            TXTCARSRNO.Clear()
            CMBCARNAME.Text = ""
            PICKUPDATE.Value = Mydate
            TXTPICKFROM.Clear()
            TXTPICKTIME.Clear()
            TXTPICKDTLS.Clear()
            DROPDDATE.Value = Mydate
            TXTDROPAT.Clear()
            TXTDROPTIME.Clear()
            TXTDROPDTLS.Clear()
            TXTCARDAYS.Text = 1
            TXTCARNOTE.Clear()
            TXTCARAMT.Clear()
            CMBCARNAME.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTCARAMT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCARAMT.Validating
        Try
            If CMBCARNAME.Text.Trim <> "" And TXTPICKFROM.Text.Trim <> "" And TXTDROPAT.Text.Trim <> "" Then
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
                CMBCARNAME.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARNAME.Index).Value
                PICKUPDATE.Value = GRIDTRANS.Rows(e.RowIndex).Cells(GCARPICKUP.Index).Value
                TXTPICKFROM.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARPICKUPFROM.Index).Value
                TXTPICKTIME.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARPICKUPTIME.Index).Value
                TXTPICKDTLS.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARPICKUPDTLS.Index).Value
                DROPDDATE.Value = GRIDTRANS.Rows(e.RowIndex).Cells(GCARDROP.Index).Value
                TXTDROPAT.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARDROPTO.Index).Value
                TXTDROPTIME.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARDROPTIME.Index).Value
                TXTDROPDTLS.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARDROPDTLS.Index).Value
                TXTCARNOTE.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARNOTE.Index).Value
                TXTCARAMT.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARAMT.Index).Value
                CMBCARNAME.Focus()
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

            If CMBHOTELNAME.Text.Trim <> "" And CMBROOMTYPE.Text.Trim <> "" And CMBPLAN.Text.Trim <> "" And Val(TXTNOOFROOMS.Text.Trim) > 0 And Val(TXTRATE.Text.Trim) > 0 And Val(TXTTOTAL.Text.Trim) > 0 And CMBPACKAGE.Text.Trim <> "" Then
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


            If CMBCARNAME.Text.Trim <> "" And TXTPICKFROM.Text.Trim <> "" And TXTDROPAT.Text.Trim <> "" And Val(TXTCARAMT.Text.Trim) > 0 Then
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

            If PACKAGETO.Value.Date <= PACKAGEFROM.Value.Date Then
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

    Sub CALC()
        Try
            TXTBTOTALNIGHTS.Text = DateDiff(DateInterval.Day, CHECKINDATE.Value.Date, CHECKOUTDATE.Value.Date)
            TXTTOTAL.Text = 0.0
            If CMBPACKAGE.Text.Trim = "No" Then
                TXTTOTAL.Text = Format((Val(TXTRATE.Text.Trim) * Val(TXTNOOFROOMS.Text.Trim) * Val(TXTBTOTALNIGHTS.Text.Trim)), "0.00")
            Else
                TXTTOTAL.Text = Format((Val(TXTRATE.Text.Trim) * Val(TXTNOOFROOMS.Text.Trim)), "0.00")
            End If
            TXTAIRAMT.Text = Format((Val(TXTBASIC.Text.Trim) + Val(TXTPSF.Text.Trim) + Val(TXTGRIDTAX.Text.Trim)), "0.00")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPACKAGE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBPACKAGE.Validated
        CALC()
    End Sub

    Private Sub CHECKOUTDATE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHECKOUTDATE.Validated
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

    'Private Sub CMBNAME_Enter1(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUP_SECONDARY = 'Sundry Debtors'")
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub CMBNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
    '    Try
    '        If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBCODE, e, Me, TXTADD, " AND GROUP_SECONDARY = 'Sundry Debtors' ", "Sundry Debtors")
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    
    Private Sub TXTTOURDETAILS_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTTOURDETAILS.Validating
        If (TOURDATE.Value.Date < PACKAGEFROM.Value.Date) Or (TOURDATE.Value.Date > PACKAGETO.Value.Date) Then
            MsgBox("Invalid Tour Date ", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If TXTTOURDETAILS.Text.Trim <> "" Then FILLTOURGRID() Else MsgBox("Please Enter proper details")
    End Sub

    'Private Sub CMBTRAINNAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBTRAINNAME.Enter
    '    Try
    '        If CMBTRAINNAME.Text.Trim = "" Then FILLTRAINNAME(CMBTRAINNAME)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub CMBDNTRAINNAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBDNTRAINNAME.Enter
    '    Try
    '        If CMBDNTRAINNAME.Text.Trim = "" Then FILLTRAINNAME(CMBDNTRAINNAME)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub CMBTRAINNAME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTRAINNAME.Validating
        Try
            If CMBTRAINNAME.Text.Trim <> "" Then TRAINNAMEVALIDATE(CMBTRAINNAME, CMBTRAINNO, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDNTRAINNAME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDNTRAINNAME.Validating
        Try
            If CMBDNTRAINNAME.Text.Trim <> "" Then TRAINNAMEVALIDATE(CMBDNTRAINNAME, CMBDNTRAINNO, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Private Sub CMBFROM_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBFROM.Enter
    '    Try
    '        If CMBFROM.Text.Trim = "" Then FILLSTATION(CMBFROM)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub CMBDNFROM_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBDNFROM.Enter
    '    Try
    '        If CMBDNFROM.Text.Trim = "" Then FILLSTATION(CMBDNFROM)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub CMBTO_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBTO.Enter
    '    Try
    '        If CMBTO.Text.Trim = "" Then FILLSTATION(CMBTO)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub CMBDNTO_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBDNTO.Enter
    '    Try
    '        If CMBDNTO.Text.Trim = "" Then FILLSTATION(CMBDNTO)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub CMBBOARDING_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBBOARDING.Enter
    '    Try
    '        If CMBBOARDING.Text.Trim = "" Then FILLSTATION(CMBBOARDING)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub CMBDNBOARDING_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBDNBOARDING.Enter
    '    Try
    '        If CMBDNBOARDING.Text.Trim = "" Then FILLSTATION(CMBDNBOARDING)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub CMBRESTO_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBRESTO.Enter
    '    Try
    '        If CMBRESTO.Text.Trim = "" Then FILLSTATION(CMBRESTO)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub CMBDNRESTO_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBDNRESTO.Enter
    '    Try
    '        If CMBDNRESTO.Text.Trim = "" Then FILLSTATION(CMBDNRESTO)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub CMBFROMCODE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBFROMCODE.Enter
    '    Try
    '        If CMBFROMCODE.Text.Trim = "" Then FILLSTATIONCODE(CMBFROMCODE)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub CMBDNFROMCODE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBDNFROMCODE.Enter

    '    Try
    '        If CMBDNFROMCODE.Text.Trim = "" Then FILLSTATIONCODE(CMBDNFROMCODE)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub CMBFROMCODE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBFROMCODE.Validated
        Try
            If CMBFROMCODE.Text.Trim <> "" And CMBBOARDING.Text.Trim = "" Then
                CMBBOARDING.Text = CMBFROM.Text.Trim
                CMBBOARDINGCODE.Text = CMBFROMCODE.Text.Trim
                TXTBOARDING.Text = CMBFROMCODE.Text.Trim
            End If
            TXTFROM.Text = CMBFROMCODE.Text.Trim
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDNFROMCODE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBDNFROMCODE.Validated
        Try
            If CMBDNFROMCODE.Text.Trim <> "" And CMBDNBOARDING.Text.Trim = "" Then
                CMBDNBOARDING.Text = CMBDNFROM.Text.Trim
                CMBDNBOARDINGCODE.Text = CMBDNFROMCODE.Text.Trim
                TXTDNBOARDING.Text = CMBDNFROMCODE.Text.Trim
            End If
            TXTDNFROM.Text = CMBDNFROMCODE.Text.Trim
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFROMCODE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBFROMCODE.Validating
        Try
            If CMBFROMCODE.Text.Trim <> "" Then STATIONCODEVALIDATE(CMBFROMCODE, CMBFROM, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDNFROMCODE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDNFROMCODE.Validating
        Try
            If CMBDNFROMCODE.Text.Trim <> "" Then STATIONCODEVALIDATE(CMBDNFROMCODE, CMBDNFROM, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Private Sub CMBTOCODE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBTOCODE.Enter
    '    Try
    '        If CMBTOCODE.Text.Trim = "" Then FILLSTATIONCODE(CMBTOCODE)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub CMBDNTOCODE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBDNTOCODE.Enter
    '    Try
    '        If CMBDNTOCODE.Text.Trim = "" Then FILLSTATIONCODE(CMBDNTOCODE)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub CMBRESTOCODE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBRESTOCODE.Enter
    '    Try
    '        If CMBRESTOCODE.Text.Trim = "" Then FILLSTATIONCODE(CMBRESTOCODE)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub CMBDNRESTOCODE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBDNRESTOCODE.Enter
    '    Try
    '        If CMBDNRESTOCODE.Text.Trim = "" Then FILLSTATIONCODE(CMBDNRESTOCODE)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub CMBRESTOCODE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBRESTOCODE.Validated
        Try
            TXTRESTO.Text = CMBRESTOCODE.Text.Trim
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDNRESTOCODE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBDNRESTOCODE.Validated
        Try
            TXTDNRESTO.Text = CMBDNRESTOCODE.Text.Trim
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBRESTOCODE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBRESTOCODE.Validating
        Try
            If CMBRESTOCODE.Text.Trim <> "" Then STATIONCODEVALIDATE(CMBRESTOCODE, CMBRESTO, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub CMBDNRESTOCODE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDNRESTOCODE.Validating
        Try
            If CMBDNRESTOCODE.Text.Trim <> "" Then STATIONCODEVALIDATE(CMBDNRESTOCODE, CMBDNRESTO, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub CMBTOCODE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBTOCODE.Validated
        Try
            If CMBTOCODE.Text.Trim <> "" And CMBRESTO.Text.Trim = "" Then
                CMBRESTO.Text = CMBTO.Text.Trim
                CMBRESTOCODE.Text = CMBTOCODE.Text.Trim
                TXTRESTO.Text = CMBTOCODE.Text.Trim
            End If
            TXTTO.Text = CMBTOCODE.Text.Trim
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub CMBDNTOCODE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBDNTOCODE.Validated
        Try
            If CMBDNTOCODE.Text.Trim <> "" And CMBDNRESTO.Text.Trim = "" Then
                CMBDNRESTO.Text = CMBDNTO.Text.Trim
                CMBDNRESTOCODE.Text = CMBDNTOCODE.Text.Trim
                TXTDNRESTO.Text = CMBDNTOCODE.Text.Trim
            End If
            TXTDNTO.Text = CMBDNTOCODE.Text.Trim
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub CMBTOCODE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTOCODE.Validating
        Try
            If CMBTOCODE.Text.Trim <> "" Then STATIONCODEVALIDATE(CMBTOCODE, CMBTO, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub CMBDNTOCODE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDNTOCODE.Validating
        Try
            If CMBDNTOCODE.Text.Trim <> "" Then STATIONCODEVALIDATE(CMBDNTOCODE, CMBDNTO, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    'Private Sub CMBBOARDINGCODE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBBOARDINGCODE.Enter
    '    Try
    '        If CMBBOARDINGCODE.Text.Trim = "" Then FILLSTATIONCODE(CMBBOARDINGCODE)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub CMBDNBOARDINGCODE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBDNBOARDINGCODE.Enter
    '    Try
    '        If CMBDNBOARDINGCODE.Text.Trim = "" Then FILLSTATIONCODE(CMBDNBOARDINGCODE)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub CMBBOARDINGCODE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBBOARDINGCODE.Validated
        Try
            TXTBOARDING.Text = CMBBOARDINGCODE.Text.Trim
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDNBOARDINGCODE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBDNBOARDINGCODE.Validated
        Try
            TXTDNBOARDING.Text = CMBDNBOARDINGCODE.Text.Trim
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub CMBBOARDINGCODE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBBOARDINGCODE.Validating
        Try
            If CMBBOARDINGCODE.Text.Trim <> "" Then STATIONCODEVALIDATE(CMBBOARDINGCODE, CMBBOARDING, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDNBOARDINGCODE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDNBOARDINGCODE.Validating
        Try
            If CMBDNBOARDINGCODE.Text.Trim <> "" Then STATIONCODEVALIDATE(CMBDNBOARDINGCODE, CMBDNBOARDING, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
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


    Private Sub cmbdntax_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbdntax.Validated
        Try
            If cmbdntax.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" TAX_TAX AS TAX ", "", " TAXMASTER ", " AND TAX_NAME = '" & cmbdntax.Text.Trim & "' AND TAX_CMPID = " & CmpId & " AND TAX_LOCATIONID = " & Locationid & " AND TAX_YEARID  =  " & YearId)
                If DT.Rows.Count > 0 Then
                    If Val(DT.Rows(0).Item("TAX")) = 0 Then
                        txtdntax.ReadOnly = False
                        txtdntax.Enabled = True
                    End If
                End If
            Else
                txtdntax.Clear()
            End If
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub cmbtax_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbtax.Validating
        Try
            If cmbtax.Text.Trim <> "" Then TAXvalidate(cmbtax, e, Me)
            total()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbdntax_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbdntax.Validating
        Try
            If cmbdntax.Text.Trim <> "" Then TAXvalidate(cmbdntax, e, Me)
            total()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub


    'Private Sub CMBTRAINNO_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBTRAINNO.Enter
    '    Try
    '        If CMBTRAINNO.Text.Trim = "" Then FILLTRAINNO(CMBTRAINNO)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub CMBDNTRAINNO_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBDNTRAINNO.Enter
    '    Try
    '        If CMBDNTRAINNO.Text.Trim = "" Then FILLTRAINNO(CMBDNTRAINNO)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub CMBTRAINNO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTRAINNO.Validating
        Try
            If CMBTRAINNO.Text.Trim <> "" Then TRAINNOVALIDATE(CMBTRAINNO, CMBTRAINNAME, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDNTRAINNO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDNTRAINNO.Validating
        Try
            If CMBDNTRAINNO.Text.Trim <> "" Then TRAINNOVALIDATE(CMBDNTRAINNO, CMBDNTRAINNAME, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridupload_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.CellDoubleClick
        Try
            If e.RowIndex = -1 Then Exit Sub

            If e.RowIndex >= 0 And gridupload.Item(GUSRNO.Index, e.RowIndex).Value <> Nothing Then

                GRIDUPLOADDOUBLECLICK = True
                TXTUPLOADSRNO.Text = gridupload.Item(GUSRNO.Index, e.RowIndex).Value
                txtuploadremarks.Text = gridupload.Item(GUREMARKS.Index, e.RowIndex).Value
                txtuploadname.Text = gridupload.Item(GUNAME.Index, e.RowIndex).Value
                PBSOFTCOPY.Image = gridupload.Item(GUIMGPATH.Index, e.RowIndex).Value

                TEMPUPLOADROW = e.RowIndex
                txtuploadremarks.Focus()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridupload_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridupload.KeyDown
        Try
            If e.KeyCode = Keys.Delete And gridupload.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                If GRIDUPLOADDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                gridupload.Rows.RemoveAt(gridupload.CurrentRow.Index)
                getsrno(gridupload)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtuploadname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtuploadname.Validating
        Try
            If txtuploadremarks.Text.Trim <> "" And txtuploadname.Text.Trim <> "" And PBSOFTCOPY.ImageLocation <> "" Then
                FILLUPLOAD()
            Else
                MsgBox("Enter Proper Details")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTUPLOADSRNO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTUPLOADSRNO.GotFocus
        If GRIDUPLOADDOUBLECLICK = False Then
            If gridupload.RowCount > 0 Then
                TXTUPLOADSRNO.Text = Val(gridupload.Rows(gridupload.RowCount - 1).Cells(0).Value) + 1
            Else
                TXTUPLOADSRNO.Text = 1
            End If
        End If
    End Sub

    Private Sub CMDUPLOAD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDUPLOAD.Click
        OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg;*.png)|*.bmp;*.jpg;*.png"
        OpenFileDialog1.ShowDialog()
        TXTIMGPATH.Text = OpenFileDialog1.FileName
        On Error Resume Next
        If TXTIMGPATH.Text.Trim.Length <> 0 Then PBSOFTCOPY.ImageLocation = TXTIMGPATH.Text.Trim
    End Sub

    Private Sub CMDREMOVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREMOVE.Click
        Try
            PBSOFTCOPY.Image = Nothing
            TXTIMGPATH.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDVIEW.Click
        Try
            If gridupload.SelectedRows.Count > 0 Then
                Dim objVIEW As New ViewImage
                objVIEW.pbsoftcopy.Image = PBSOFTCOPY.Image
                objVIEW.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridupload_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.RowEnter
        Try
            If e.RowIndex >= 0 Then PBSOFTCOPY.Image = gridupload.Rows(e.RowIndex).Cells(GUIMGPATH.Index).Value
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTDNFARE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTDNFARE.Validating
        total()
    End Sub

    Private Sub TXTDNEXTRACHGS_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTDNEXTRACHGS.Validating
        total()
    End Sub

    Private Sub txtdntax_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtdntax.Validating
        total()
    End Sub

    Private Sub TXTGRIDTAX_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTPSF.Validated, TXTGRIDTAX.Validated, TXTBASIC.Validated
        CALC()
    End Sub

    Private Sub CMDCLOSE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLOSE.Click
        Try
            If GRIDSECTOR.Rows.Count > 0 Then TXTFLTNO.Text = GRIDSECTOR.Rows(0).Cells(GSECFLTNO.Index).Value
            SECTORGROUP.Visible = False
            TXTFLTNO.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTSECTOR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTSECTOR.Validated
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

    Private Sub CMBCLASS_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            GETCHARGES()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETCHARGES()
        Try
            If CMBCLASS.Text <> "" Then
                Dim OBJSEARCH As New ClsCommon
                Dim DT As DataTable = OBJSEARCH.search(" ISNULL(RAILWAY_CONFIG.RAILWAY_RATE, 0) AS RATE ", "", "  RAILWAY_CONFIG INNER JOIN LEDGERS ON RAILWAY_CONFIG.RAILWAY_ledgerid = LEDGERS.Acc_id AND RAILWAY_CONFIG.RAILWAY_cmpid = LEDGERS.Acc_cmpid AND RAILWAY_CONFIG.RAILWAY_locationid = LEDGERS.Acc_locationid And RAILWAY_CONFIG.RAILWAY_yearid = LEDGERS.Acc_yearid", " AND RAILWAY_CONFIG.RAILWAY_CLASS='" & CMBCLASS.Text.Trim & "' AND RAILWAY_CONFIG.RAILWAY_CMPID=" & CmpId & " and RAILWAY_CONFIG.RAILWAY_locationid=" & Locationid & " and RAILWAY_CONFIG.RAILWAY_yearid=" & YearId)
                If DT.Rows.Count > 0 Then
                    'cmbaddsub.Text = "Add"
                    'CMBOTHERCHGS.Text = "Service Chgs"
                    TXTEXTRACHGS.Text = Val(DT.Rows(0).Item("RATE")) '* Val(TXTTOTALPAX.Text.Trim)
                    total()
                End If
            End If

            If CMBDNCLASS.Text <> "" Then
                Dim OBJSEARCH As New ClsCommon
                Dim DT As DataTable = OBJSEARCH.search(" ISNULL(RAILWAY_CONFIG.RAILWAY_RATE, 0) AS RATE ", "", "  RAILWAY_CONFIG INNER JOIN LEDGERS ON RAILWAY_CONFIG.RAILWAY_ledgerid = LEDGERS.Acc_id AND RAILWAY_CONFIG.RAILWAY_cmpid = LEDGERS.Acc_cmpid AND RAILWAY_CONFIG.RAILWAY_locationid = LEDGERS.Acc_locationid And RAILWAY_CONFIG.RAILWAY_yearid = LEDGERS.Acc_yearid", " AND RAILWAY_CONFIG.RAILWAY_CLASS='" & CMBDNCLASS.Text.Trim & "' AND RAILWAY_CONFIG.RAILWAY_CMPID=" & CmpId & " and RAILWAY_CONFIG.RAILWAY_locationid=" & Locationid & " and RAILWAY_CONFIG.RAILWAY_yearid=" & YearId)
                If DT.Rows.Count > 0 Then
                    'cmbaddsub.Text = "Add"
                    'CMBOTHERCHGS.Text = "Service Chgs"
                    TXTDNEXTRACHGS.Text = Val(DT.Rows(0).Item("RATE")) '* Val(TXTTOTALPAX.Text.Trim)
                    total()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDNCLASS_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBDNCLASS.Validated
        Try
            GETCHARGES()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTFARE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTFARE.Validating
        total()
    End Sub

    Private Sub TXTEXTRACHGS_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTEXTRACHGS.Validating
        total()
    End Sub

    'Private Sub CMBMIDUPTRAINNAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBMIDUPTRAINNAME.Enter
    '    Try
    '        If CMBMIDUPTRAINNAME.Text.Trim = "" Then FILLTRAINNAME(CMBMIDUPTRAINNAME)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub CMBMIDDNTRAINNAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBMIDDNTRAINNAME.Enter
    '    Try
    '        If CMBMIDDNTRAINNAME.Text.Trim = "" Then FILLTRAINNAME(CMBMIDDNTRAINNAME)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub CMBMIDUPTRAINNAME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBMIDUPTRAINNAME.Validating
        Try
            If CMBMIDUPTRAINNAME.Text.Trim <> "" Then TRAINNAMEVALIDATE(CMBMIDUPTRAINNAME, CMBMIDUPTRAINNO, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMIDDNTRAINNAME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBMIDDNTRAINNAME.Validating
        Try
            If CMBMIDDNTRAINNAME.Text.Trim <> "" Then TRAINNAMEVALIDATE(CMBMIDDNTRAINNAME, CMBMIDDNTRAINNO, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Private Sub CMBMIDUPFROM_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBMIDUPFROM.Enter
    '    Try
    '        If CMBMIDUPFROM.Text.Trim = "" Then FILLSTATION(CMBMIDUPFROM)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub CMBMIDDNFROM_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBMIDDNFROM.Enter
    '    Try
    '        If CMBMIDDNFROM.Text.Trim = "" Then FILLSTATION(CMBMIDDNFROM)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub CMBMIDUPTO_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBMIDUPTO.Enter
    '    Try
    '        If CMBMIDUPTO.Text.Trim = "" Then FILLSTATION(CMBMIDUPTO)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub CMBMIDDNTO_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBMIDDNTO.Enter
    '    Try
    '        If CMBMIDDNTO.Text.Trim = "" Then FILLSTATION(CMBMIDDNTO)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub CMBMIDUPBOARDING_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBMIDUPBOARDING.Enter
    '    Try
    '        If CMBMIDUPBOARDING.Text.Trim = "" Then FILLSTATION(CMBMIDUPBOARDING)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub CMBMIDDNBOARDING_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBMIDDNBOARDING.Enter
    '    Try
    '        If CMBMIDDNBOARDING.Text.Trim = "" Then FILLSTATION(CMBMIDDNBOARDING)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub CMBMIDUPRESTO_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBMIDUPRESTO.Enter
    '    Try
    '        If CMBMIDUPRESTO.Text.Trim = "" Then FILLSTATION(CMBMIDUPRESTO)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub CMBMIDDNRESTO_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBMIDDNRESTO.Enter
    '    Try
    '        If CMBMIDDNRESTO.Text.Trim = "" Then FILLSTATION(CMBMIDDNRESTO)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub CMBMIDUPFROMCODE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBMIDUPFROMCODE.Enter
    '    Try
    '        If CMBMIDUPFROMCODE.Text.Trim = "" Then FILLSTATIONCODE(CMBMIDUPFROMCODE)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub CMBMIDDNFROMCODE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBMIDDNFROMCODE.Enter

    '    Try
    '        If CMBMIDDNFROMCODE.Text.Trim = "" Then FILLSTATIONCODE(CMBMIDDNFROMCODE)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub CMBMIDUPFROMCODE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBMIDUPFROMCODE.Validated
        Try
            If CMBMIDUPFROMCODE.Text.Trim <> "" And CMBMIDUPBOARDING.Text.Trim = "" Then
                CMBMIDUPBOARDING.Text = CMBMIDUPFROM.Text.Trim
                CMBMIDUPBOARDINGCODE.Text = CMBMIDUPFROMCODE.Text.Trim
                TXTMIDUPBOARDING.Text = CMBMIDUPFROMCODE.Text.Trim
            End If
            TXTMIDUPFROM.Text = CMBMIDUPFROMCODE.Text.Trim
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMIDDNFROMCODE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBMIDDNFROMCODE.Validated
        Try
            If CMBMIDDNFROMCODE.Text.Trim <> "" And CMBMIDDNBOARDING.Text.Trim = "" Then
                CMBMIDDNBOARDING.Text = CMBMIDDNFROM.Text.Trim
                CMBMIDDNBOARDINGCODE.Text = CMBMIDDNFROMCODE.Text.Trim
                TXTMIDDNBOARDING.Text = CMBMIDDNFROMCODE.Text.Trim
            End If
            TXTMIDDNFROM.Text = CMBMIDDNFROMCODE.Text.Trim
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMIDUPFROMCODE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBMIDUPFROMCODE.Validating
        Try
            If CMBMIDUPFROMCODE.Text.Trim <> "" Then STATIONCODEVALIDATE(CMBMIDUPFROMCODE, CMBMIDUPFROM, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMIDDNFROMCODE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBMIDDNFROMCODE.Validating
        Try
            If CMBMIDDNFROMCODE.Text.Trim <> "" Then STATIONCODEVALIDATE(CMBMIDDNFROMCODE, CMBMIDDNFROM, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Private Sub CMBMIDUPTOCODE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBMIDUPTOCODE.Enter
    '    Try
    '        If CMBMIDUPTOCODE.Text.Trim = "" Then FILLSTATIONCODE(CMBMIDUPTOCODE)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub CMBMIDDNTOCODE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBMIDDNTOCODE.Enter
    '    Try
    '        If CMBMIDDNTOCODE.Text.Trim = "" Then FILLSTATIONCODE(CMBMIDDNTOCODE)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub CMBMIDUPRESTOCODE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBMIDUPRESTOCODE.Enter
    '    Try
    '        If CMBMIDUPRESTOCODE.Text.Trim = "" Then FILLSTATIONCODE(CMBMIDUPRESTOCODE)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub CMBMIDDNRESTOCODE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBMIDDNRESTOCODE.Enter
    '    Try
    '        If CMBMIDDNRESTOCODE.Text.Trim = "" Then FILLSTATIONCODE(CMBMIDDNRESTOCODE)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub CMBMIDUPRESTOCODE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBMIDUPRESTOCODE.Validated
        Try
            TXTMIDUPRESTO.Text = CMBMIDUPRESTOCODE.Text.Trim
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMIDDNRESTOCODE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBMIDDNRESTOCODE.Validated
        Try
            TXTMIDDNRESTO.Text = CMBMIDDNRESTOCODE.Text.Trim
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMIDUPRESTOCODE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBMIDUPRESTOCODE.Validating
        Try
            If CMBMIDUPRESTOCODE.Text.Trim <> "" Then STATIONCODEVALIDATE(CMBMIDUPRESTOCODE, CMBMIDUPRESTO, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub CMBMIDDNRESTOCODE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBMIDDNRESTOCODE.Validating
        Try
            If CMBMIDDNRESTOCODE.Text.Trim <> "" Then STATIONCODEVALIDATE(CMBMIDDNRESTOCODE, CMBMIDDNRESTO, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub CMBMIDUPTOCODE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBMIDUPTOCODE.Validated
        Try
            If CMBMIDUPTOCODE.Text.Trim <> "" And CMBMIDUPRESTO.Text.Trim = "" Then
                CMBMIDUPRESTO.Text = CMBMIDUPTO.Text.Trim
                CMBMIDUPRESTOCODE.Text = CMBMIDUPTOCODE.Text.Trim
                TXTMIDUPRESTO.Text = CMBMIDUPTOCODE.Text.Trim
            End If
            TXTMIDUPTO.Text = CMBMIDUPTOCODE.Text.Trim
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub CMBMIDDNTOCODE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBMIDDNTOCODE.Validated
        Try
            If CMBMIDDNTOCODE.Text.Trim <> "" And CMBMIDDNRESTO.Text.Trim = "" Then
                CMBMIDDNRESTO.Text = CMBMIDDNTO.Text.Trim
                CMBMIDDNRESTOCODE.Text = CMBMIDDNTOCODE.Text.Trim
                TXTMIDDNRESTO.Text = CMBMIDDNTOCODE.Text.Trim
            End If
            TXTMIDDNTO.Text = CMBMIDDNTOCODE.Text.Trim
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub CMBMIDUPTOCODE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBMIDUPTOCODE.Validating
        Try
            If CMBMIDUPTOCODE.Text.Trim <> "" Then STATIONCODEVALIDATE(CMBMIDUPTOCODE, CMBMIDUPTO, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub CMBMIDDNTOCODE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBMIDDNTOCODE.Validating
        Try
            If CMBMIDDNTOCODE.Text.Trim <> "" Then STATIONCODEVALIDATE(CMBMIDDNTOCODE, CMBMIDDNTO, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    'Private Sub CMBMIDUPBOARDINGCODE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBMIDUPBOARDINGCODE.Enter
    '    Try
    '        If CMBMIDUPBOARDINGCODE.Text.Trim = "" Then FILLSTATIONCODE(CMBMIDUPBOARDINGCODE)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub CMBMIDDNBOARDINGCODE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBMIDDNBOARDINGCODE.Enter
    '    Try
    '        If CMBMIDDNBOARDINGCODE.Text.Trim = "" Then FILLSTATIONCODE(CMBMIDDNBOARDINGCODE)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub CMBMIDUPBOARDINGCODE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBMIDUPBOARDINGCODE.Validated
        Try
            TXTMIDUPBOARDING.Text = CMBMIDUPBOARDINGCODE.Text.Trim
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMIDDNBOARDINGCODE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBMIDDNBOARDINGCODE.Validated
        Try
            TXTMIDDNBOARDING.Text = CMBMIDDNBOARDINGCODE.Text.Trim
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub CMBMIDUPBOARDINGCODE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBMIDUPBOARDINGCODE.Validating
        Try
            If CMBMIDUPBOARDINGCODE.Text.Trim <> "" Then STATIONCODEVALIDATE(CMBMIDUPBOARDINGCODE, CMBMIDUPBOARDING, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMIDDNBOARDINGCODE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBMIDDNBOARDINGCODE.Validating
        Try
            If CMBMIDDNBOARDINGCODE.Text.Trim <> "" Then STATIONCODEVALIDATE(CMBMIDDNBOARDINGCODE, CMBMIDDNBOARDING, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub cmbMIDUPtax_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbmiduptax.Validated
        Try
            If cmbmiduptax.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" TAX_TAX AS TAX ", "", " TAXMASTER ", " AND TAX_NAME = '" & cmbmiduptax.Text.Trim & "' AND TAX_CMPID = " & CmpId & " AND TAX_LOCATIONID = " & Locationid & " AND TAX_YEARID  =  " & YearId)
                If DT.Rows.Count > 0 Then
                    If Val(DT.Rows(0).Item("TAX")) = 0 Then
                        txtmiduptax.ReadOnly = False
                        txtmiduptax.Enabled = True
                    End If
                End If
            Else
                txtmiduptax.Clear()
            End If
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub cmbMIDdntax_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbmiddntax.Validated
        Try
            If cmbmiddntax.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" TAX_TAX AS TAX ", "", " TAXMASTER ", " AND TAX_NAME = '" & cmbmiddntax.Text.Trim & "' AND TAX_CMPID = " & CmpId & " AND TAX_LOCATIONID = " & Locationid & " AND TAX_YEARID  =  " & YearId)
                If DT.Rows.Count > 0 Then
                    If Val(DT.Rows(0).Item("TAX")) = 0 Then
                        txtmiddntax.ReadOnly = False
                        txtmiddntax.Enabled = True
                    End If
                End If
            Else
                txtmiddntax.Clear()
            End If
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub cmbMIDUPtax_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbmiduptax.Validating
        Try
            If cmbmiduptax.Text.Trim <> "" Then TAXvalidate(cmbmiduptax, e, Me)
            total()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbMIDdntax_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbmiddntax.Validating
        Try
            If cmbmiddntax.Text.Trim <> "" Then TAXvalidate(cmbmiddntax, e, Me)
            total()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub


    'Private Sub CMBMIDUPTRAINNO_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBMIDUPTRAINNO.Enter
    '    Try
    '        If CMBMIDUPTRAINNO.Text.Trim = "" Then FILLTRAINNO(CMBMIDUPTRAINNO)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub CMBMIDDNTRAINNO_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBMIDDNTRAINNO.Enter
    '    Try
    '        If CMBMIDDNTRAINNO.Text.Trim = "" Then FILLTRAINNO(CMBMIDDNTRAINNO)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub CMBMIDUPTRAINNO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBMIDUPTRAINNO.Validating
        Try
            If CMBMIDUPTRAINNO.Text.Trim <> "" Then TRAINNOVALIDATE(CMBMIDUPTRAINNO, CMBMIDUPTRAINNAME, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMIDDNTRAINNO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBMIDDNTRAINNO.Validating
        Try
            If CMBMIDDNTRAINNO.Text.Trim <> "" Then TRAINNOVALIDATE(CMBMIDDNTRAINNO, CMBMIDDNTRAINNAME, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub TXTMIDDNFARE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTMIDDNFARE.Validating
        total()
    End Sub

    Private Sub TXTMIDDNEXTRACHGS_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTMIDDNEXTRACHGS.Validating
        total()
    End Sub

    Private Sub txtmiddntax_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtmiddntax.Validating
        total()
    End Sub

    Private Sub txttax_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txttax.Validating
        total()
    End Sub

    Private Sub TXTMIDUPFARE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTMIDUPFARE.Validating
        total()
    End Sub

    Private Sub TXTMIDUPEXTRACHGS_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTMIDUPEXTRACHGS.Validating
        total()
    End Sub

    Private Sub TXTTOTALPACKAGEAMT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTTOTALPACKAGEAMT.KeyPress
        numdot(e, TXTTOTALPACKAGEAMT, Me)
    End Sub

    Private Sub CMBFROM_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBFROM.Validated
        Try
            If CMBFROM.Text.Trim <> "" And CMBBOARDING.Text.Trim = "" Then
                CMBBOARDING.Text = CMBFROM.Text.Trim
                CMBBOARDINGCODE.Text = CMBFROMCODE.Text.Trim
                TXTBOARDING.Text = CMBFROMCODE.Text.Trim
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFROM_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBFROM.Validating
        Try
            If CMBFROM.Text.Trim <> "" Then STATIONVALIDATE(CMBFROM, CMBFROMCODE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTO.Validated
        Try
            If CMBTO.Text.Trim <> "" And CMBRESTO.Text.Trim = "" Then
                CMBRESTO.Text = CMBTO.Text.Trim
                CMBRESTOCODE.Text = CMBTOCODE.Text.Trim
                TXTRESTO.Text = CMBTOCODE.Text.Trim
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTO.Validating
        Try
            If CMBTO.Text.Trim <> "" Then STATIONVALIDATE(CMBTO, CMBTOCODE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDNFROM_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDNFROM.Validated
        Try
            If CMBDNFROM.Text.Trim <> "" And CMBDNBOARDING.Text.Trim = "" Then
                CMBDNBOARDING.Text = CMBDNFROM.Text.Trim
                CMBDNBOARDINGCODE.Text = CMBDNFROMCODE.Text.Trim
                TXTDNBOARDING.Text = CMBDNFROMCODE.Text.Trim
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDNFROM_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDNFROM.Validating
        Try
            If CMBDNFROM.Text.Trim <> "" Then STATIONVALIDATE(CMBDNFROM, CMBDNFROMCODE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDNTO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDNTO.Validated
        Try
            If CMBDNTO.Text.Trim <> "" And CMBDNRESTO.Text.Trim = "" Then
                CMBDNRESTO.Text = CMBDNTO.Text.Trim
                CMBDNRESTOCODE.Text = CMBDNTOCODE.Text.Trim
                TXTDNRESTO.Text = CMBDNTOCODE.Text.Trim
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDNTO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDNTO.Validating
        Try
            If CMBDNTO.Text.Trim <> "" Then STATIONVALIDATE(CMBDNTO, CMBDNTOCODE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    Private Sub CMBMIDDNFROM_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBMIDDNFROM.Validated
        Try
            If CMBMIDDNFROM.Text.Trim <> "" And CMBMIDDNBOARDING.Text.Trim = "" Then
                CMBMIDDNBOARDING.Text = CMBMIDDNFROM.Text.Trim
                CMBMIDDNBOARDINGCODE.Text = CMBMIDDNFROMCODE.Text.Trim
                TXTMIDDNBOARDING.Text = CMBMIDDNFROMCODE.Text.Trim
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMIDDNFROM_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBMIDDNFROM.Validating
        Try
            If CMBMIDDNFROM.Text.Trim <> "" Then STATIONVALIDATE(CMBMIDDNFROM, CMBMIDDNFROMCODE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMIDDNTO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBMIDDNTO.Validated
        Try
            If CMBMIDDNTO.Text.Trim <> "" And CMBMIDDNRESTO.Text.Trim = "" Then
                CMBMIDDNRESTO.Text = CMBMIDDNTO.Text.Trim
                CMBMIDDNRESTOCODE.Text = CMBMIDDNTOCODE.Text.Trim
                TXTMIDDNRESTO.Text = CMBMIDDNTOCODE.Text.Trim
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMIDDNTO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBMIDDNTO.Validating
        Try
            If CMBMIDDNTO.Text.Trim <> "" Then STATIONVALIDATE(CMBMIDDNTO, CMBMIDDNTOCODE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub CMBMIDUPFROM_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBMIDUPFROM.Validated
        Try
            If CMBMIDUPFROM.Text.Trim <> "" And CMBMIDUPBOARDING.Text.Trim = "" Then
                CMBMIDUPBOARDING.Text = CMBMIDUPFROM.Text.Trim
                CMBMIDUPBOARDINGCODE.Text = CMBMIDUPFROMCODE.Text.Trim
                TXTMIDUPBOARDING.Text = CMBMIDUPFROMCODE.Text.Trim
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMIDUPFROM_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBMIDUPFROM.Validating
        Try
            If CMBMIDUPFROM.Text.Trim <> "" Then STATIONVALIDATE(CMBMIDUPFROM, CMBMIDUPFROMCODE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMIDUPTO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBMIDUPTO.Validated
        Try
            If CMBMIDUPTO.Text.Trim <> "" And CMBMIDUPRESTO.Text.Trim = "" Then
                CMBMIDUPRESTO.Text = CMBMIDUPTO.Text.Trim
                CMBMIDUPRESTOCODE.Text = CMBMIDUPTOCODE.Text.Trim
                TXTMIDUPRESTO.Text = CMBMIDUPTOCODE.Text.Trim
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMIDUPTO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBMIDUPTO.Validating
        Try
            If CMBMIDUPTO.Text.Trim <> "" Then STATIONVALIDATE(CMBMIDUPTO, CMBMIDUPTOCODE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDPDF.Click
        OpenFilePdf.Filter = "PDF (*.Pdf)|*.Pdf"
        OpenFilePdf.FileName = ""
        OpenFilePdf.ShowDialog()
        TXTPDFPATH.Text = OpenFilePdf.FileName
    End Sub

    Private Sub EMAILTOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EMAILTOOL.Click
        Try
            If TXTPDFPATH.Text.Trim <> "" Then
                'CHECK WHETHER FILE EXISTS OR NOT
                If FileIO.FileSystem.FileExists(TXTPDFPATH.Text.Trim) = False Then Exit Sub

                Dim OBJMAIL As New SendMail
                OBJMAIL.attachment = TXTPDFPATH.Text.Trim
                OBJMAIL.subject = CMBGROUPNAME.Text.Trim
                OBJMAIL.MdiParent = MDIMain
                OBJMAIL.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDMISC_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDMISC.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDMISC.Item(GMISCSRNO.Index, e.RowIndex).Value <> Nothing Then

                GRIDMISCDOUBLECLICK = True
                TXTMISCSRNO.Text = GRIDMISC.Item(GMISCSRNO.Index, e.RowIndex).Value.ToString
                TXTMISCSERVICETYPE.Text = GRIDMISC.Item(GMISCSERVICETYPE.Index, e.RowIndex).Value.ToString
                TXTMISCREMARKS.Text = GRIDMISC.Item(GMISCREMARKS.Index, e.RowIndex).Value.ToString
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

    Private Sub TXTMISCREMARKS_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTMISCREMARKS.Validated
        Try
            If TXTMISCSERVICETYPE.Text.Trim <> "" Then
                FILLGRIDMISC()
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

                GRIDMISC.Rows.Add(Val(TXTMISCSRNO.Text.Trim), TXTMISCSERVICETYPE.Text.Trim, TXTMISCREMARKS.Text.Trim)
                getsrno(GRIDMISC)

            ElseIf GRIDMISCDOUBLECLICK = True Then

                GRIDMISC.Item(GMISCSRNO.Index, TEMPMISCROW).Value = TXTMISCSRNO.Text.Trim
                GRIDMISC.Item(GMISCSERVICETYPE.Index, TEMPMISCROW).Value = TXTMISCSERVICETYPE.Text.Trim
                GRIDMISC.Item(GMISCREMARKS.Index, TEMPMISCROW).Value = TXTMISCREMARKS.Text.Trim

                GRIDMISCDOUBLECLICK = False

            End If
            GRIDMISC.FirstDisplayedScrollingRowIndex = GRIDMISC.RowCount - 1

            TXTMISCSRNO.Text = GRIDMISC.RowCount + 1
            TXTMISCSERVICETYPE.Clear()
            TXTMISCREMARKS.Clear()

            TXTMISCSERVICETYPE.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBITINERARY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBITINERARY.Enter
        Try
            If CMBITINERARY.Text.Trim = "" Then FILLITINERARY(CMBITINERARY)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITINERARY_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBITINERARY.Validated
        If CMBITINERARY.Text.Trim <> "" Then
            Dim TEMPMSG As Integer = MsgBox("Copy Details of Itinerary " & CMBITINERARY.Text.Trim & "?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                FILLITINERARYDETAILS()
            End If
        End If
    End Sub

    Private Sub CMBITINERARY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITINERARY.Validating
        Try
            If CMBITINERARY.Text.Trim <> "" Then ITEINIRARYVALIDATE(CMBITINERARY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLITINERARYDETAILS()
        Try
            Dim OBJCMN As New ClsCommon

            'GET AIRLINE DATA
            Dim DTA As DataTable = OBJCMN.search(" ISNULL(ITINERARYMASTER_AIRLINE.ITINERARY_NO, 0) AS GROUPDEPNO, ISNULL(ITINERARY_GRIDSRNO, 0) AS AIRSRNO, ISNULL(ITINERARY_SECTOR, '') AS SECTOR, ISNULL(ITINERARY_FLTNO, '') AS FLTNO, ISNULL(ITINERARY_TYPE, '') AS TYPE, ISNULL(ITINERARY_BASIC, 0) AS BASIC, ISNULL(ITINERARY_PSF, 0) AS PSF, ISNULL(ITINERARY_TAXES, 0) AS TAXES, ISNULL(ITINERARY_AMT, 0) AS AIRAMT ", "", " ITINERARYMASTER_AIRLINE INNER JOIN ITINERARYMASTER ON ITINERARYMASTER_AIRLINE.ITINERARY_NO = ITINERARYMASTER.ITINERARY_NO AND ITINERARYMASTER_AIRLINE.ITINERARY_YEARID = ITINERARYMASTER.ITINERARY_YEARID ", " AND ITINERARYMASTER.ITINERARY_NAME = '" & CMBITINERARY.Text.Trim & "' AND ITINERARYMASTER.ITINERARY_YEARID = " & YearId & " ORDER BY ITINERARYMASTER_AIRLINE.ITINERARY_GRIDSRNO")
            If DTA.Rows.Count > 0 Then
                For Each DRA As DataRow In DTA.Rows
                    GRIDAIRLINE.Rows.Add(DRA("AIRSRNO"), DRA("SECTOR"), DRA("FLTNO"), DRA("TYPE"), Format(Val(DRA("BASIC")), "0.00"), Format(Val(DRA("PSF")), "0.00"), Format(Val(DRA("TAXES")), "0.00"), Format(Val(DRA("AIRAMT")), "0.00"))
                Next
                total()
            End If


            'GET GRIDFLIGHT DATA
            Dim DTF As DataTable = OBJCMN.search(" ITINERARYMASTER_FLIGHTDESC.ITINERARY_GRIDSRNO AS GRIDSRNO, ITINERARYMASTER_FLIGHTDESC.ITINERARY_BOOKSRNO AS BOOKSRNO, ISNULL(FROMSECTORMASTER.SECTOR_NAME, '') AS FROMSEC, ISNULL(TOSECTORMASTER.SECTOR_NAME, '') AS TOSEC, ITINERARYMASTER_FLIGHTDESC.ITINERARY_FLIGHTNO AS FLIGHTNO, ITINERARYMASTER_FLIGHTDESC.ITINERARY_FLIGHTDATE AS FLIGHTDATE, ISNULL(ITINERARYMASTER_FLIGHTDESC.ITINERARY_ARRIVES, '') AS ARRIVES, CLASSMASTER.CLASS_NAME AS CLASS", "", " CLASSMASTER RIGHT OUTER JOIN  ITINERARYMASTER_FLIGHTDESC INNER JOIN ITINERARYMASTER ON ITINERARYMASTER_FLIGHTDESC.ITINERARY_NO = ITINERARYMASTER.ITINERARY_NO AND ITINERARYMASTER_FLIGHTDESC.ITINERARY_YEARID = ITINERARYMASTER.ITINERARY_YEARID ON CLASSMASTER.CLASS_YEARID = ITINERARYMASTER_FLIGHTDESC.ITINERARY_YEARID AND CLASSMASTER.CLASS_CMPID = ITINERARYMASTER_FLIGHTDESC.ITINERARY_CMPID AND CLASSMASTER.CLASS_ID = ITINERARYMASTER_FLIGHTDESC.ITINERARY_CLASSID LEFT OUTER JOIN SECTORMASTER AS TOSECTORMASTER ON ITINERARYMASTER_FLIGHTDESC.ITINERARY_TOID = TOSECTORMASTER.SECTOR_ID AND ITINERARYMASTER_FLIGHTDESC.ITINERARY_CMPID = TOSECTORMASTER.SECTOR_CMPID AND ITINERARYMASTER_FLIGHTDESC.ITINERARY_YEARID = TOSECTORMASTER.SECTOR_YEARID LEFT OUTER JOIN SECTORMASTER AS FROMSECTORMASTER ON ITINERARYMASTER_FLIGHTDESC.ITINERARY_FROMID = FROMSECTORMASTER.SECTOR_ID AND ITINERARYMASTER_FLIGHTDESC.ITINERARY_CMPID = FROMSECTORMASTER.SECTOR_CMPID AND ITINERARYMASTER_FLIGHTDESC.ITINERARY_YEARID = FROMSECTORMASTER.SECTOR_YEARID ", " AND ITINERARYMASTER.ITINERARY_NAME = '" & CMBITINERARY.Text.Trim & "' AND ITINERARYMASTER.ITINERARY_YEARID = " & YearId & " ORDER BY ITINERARYMASTER_FLIGHTDESC.ITINERARY_BOOKSRNO ASC, ITINERARYMASTER_FLIGHTDESC.ITINERARY_GRIDSRNO ASC")
            If DTF.Rows.Count > 0 Then
                For Each DRF As DataRow In DTF.Rows
                    GRIDFLIGHT.Rows.Add(DRF("GRIDSRNO").ToString, DRF("BOOKSRNO"), DRF("FROMSEC").ToString, DRF("TOSEC").ToString, DRF("FLIGHTNO").ToString, DRF("FLIGHTDATE").ToString, DRF("ARRIVES").ToString, DRF("CLASS").ToString)
                Next
                total()
            End If

            'MISC GRID
            Dim OBJMISC As New ClsCommon
            Dim DT4 As DataTable
            DT4 = OBJMISC.search(" ISNULL(ITINERARYMASTER_MISC.ITINERARY_SRNO, 0) AS SRNO, ISNULL(ITINERARYMASTER_MISC.ITINERARY_TYPE, '') AS SERVICETYPE, ISNULL(ITINERARYMASTER_MISC.ITINERARY_REMARKS, '') AS MISCREMARKS ", "", " ITINERARYMASTER_MISC INNER JOIN ITINERARYMASTER ON ITINERARYMASTER_MISC.ITINERARY_NO = ITINERARYMASTER.ITINERARY_NO ", " AND ITINERARYMASTER.ITINERARY_NAME = '" & CMBITINERARY.Text.Trim & "' AND ITINERARYMASTER.ITINERARY_YEARID = " & YearId & " ORDER BY ITINERARYMASTER_MISC.ITINERARY_SRNO ")
            If DT4.Rows.Count > 0 Then
                For Each DTM As DataRow In DT4.Rows
                    GRIDMISC.Rows.Add(Val(DTM("SRNO")), DTM("SERVICETYPE"), DTM("MISCREMARKS"))
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
End Class