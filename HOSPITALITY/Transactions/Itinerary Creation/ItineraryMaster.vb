
Imports BL
Imports System.IO
Imports System.ComponentModel

Public Class ItineraryMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim GRIDITINERARYDOUBLECLICK, GRIDVEHICLEDOUBLECLICK, GRIDHOTELDOUBLECLICK, GRIDMISCDOUBLECLICK As Boolean
    Dim TEMPITINERARYROW, TEMPHOTELROW, TEMPVEHICLEROW, TEMPFLIGHTROW, TEMPMISCROW As Integer
    Public edit As Boolean
    Public TEMPITINERARYNO As Integer
    Public TEMPPACKAGENAME As String
    Public TEMPINCLUSION As String
    Public TEMPEXCLUSION As String
    Dim TEMPMSG As Integer
    Dim GRIDAIRDOUBLECLICK As Boolean

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getmax_ITINERARY_no()
        Try
            Dim DTTABLE As New DataTable
            DTTABLE = getmax(" isnull(max(ITINERARY_no),0) + 1 ", " ITINERARYMASTER ", " AND ITINERARY_YEARID = " & YearId)
            If DTTABLE.Rows.Count > 0 Then TXTITINERARYNO.Text = DTTABLE.Rows(0).Item(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub clear()
        Try
            EP.Clear()

            TXTITINERARYNO.Clear()
            CMBPACKAGETYPE.SelectedIndex = 0

            TXTCOPY.Clear()
            tstxtbillno.Clear()

            CMBPACKAGENAME.Text = ""
            TXTDISPLAYNAME.Clear()

            CMBCODE.Text = ""
            TXTADD.Clear()

            PACKAGEFROM.Value = Mydate
            PACKAGETO.Value = Mydate

            TXTADULTRATE.Clear()
            TXTEXTRAADULTRATE.Clear()
            TXTTOTALDAYS.Clear()
            TXTCHILDBEDRATE.Clear()
            TXTCHILDRATE.Clear()
            TXTCHILDBELOWAGE.Clear()

            TXTPDFPATH.Clear()

            PBSOFTCOPY.Image = Nothing
            TXTIMGPATH.Clear()

            PBHOTELSOFTCOPY.Image = Nothing
            TXTHOTELIMGPATH.Clear()

            'GridTour
            GRIDITINERARY.RowCount = 0
            TXTTOURSRNO.Text = 1
            TXTHEADER.Clear()
            TXTDETAILS.Clear()

            'GridHotel
            GRIDHOTEL.RowCount = 0
            TXTHOTELSRNO.Text = 1
            CMBCITY.Text = ""
            CMBHOTEL.Text = ""
            CMBROOMTYPE.SelectedItem = Nothing
            TXTHOTELNIGHTS.Clear()

            'GridVehicle
            GRIDVEHICLE.RowCount = 0
            TXTVEHICLESRNO.Text = 1
            CMBVEHICLENAME.Text = ""
            TXTVEHICLEDESCRIPTION.Clear()
            TXTVEHICLEDAYS.Clear()

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

            TXTINCLUSION.Clear()
            TXTEXCLUSION.Clear()
            CMBCANCEL.Text = ""
            TXTTERMS.Clear()
            CMBNOTES.Text = ""
            TXTREMARKS.Clear()
            CMBINCLUSION.Text = ""
            CMBEXCLUSION.Text = ""
            GRIDVEHICLEDOUBLECLICK = False
            GRIDITINERARYDOUBLECLICK = False
            GRIDHOTELDOUBLECLICK = False
            GRIDAIRDOUBLECLICK = False
            GRIDVEHICLEDOUBLECLICK = False
            GRIDMISCDOUBLECLICK = False

            getmax_ITINERARY_no()


            CMBQUOTE.SelectedIndex = 0
            TXTLUMPSUMCOST.Clear()

            TabControl1.SelectedIndex = Nothing

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        Try
            clear()
            edit = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ITINERARYMASTER_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNoCancel)
                If tempmsg = vbYes Then
                    If errorvalid() = True Then cmdok_Click(sender, e)
                ElseIf tempmsg = vbCancel Then
                    Exit Sub
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.OemPipe Then
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

    Sub FILLPACKAGENAME()
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable = objclscommon.search(" ITINERARY_NAME ", "", " ITINERARYMASTER ", " AND ITINERARY_yearid = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "ITINERARY_name"
                CMBPACKAGENAME.DataSource = dt
                CMBPACKAGENAME.DisplayMember = "ITINERARY_name"
                CMBPACKAGENAME.Text = TEMPPACKAGENAME
                CMBPACKAGENAME.Text = ""
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
    'Sub FILLINCLUSION()
    '    Try
    '        Dim objclscommon As New ClsCommon
    '        Dim dt As DataTable = objclscommon.search(" ITINERARY_INCLUSION ", "", " ITINERARYMASTER ", " AND ITINERARY_yearid = " & YearId)
    '        If dt.Rows.Count > 0 Then
    '            dt.DefaultView.Sort = "ITINERARY_INCLUSION"
    '            CMBINCLUSION.DataSource = dt
    '            CMBINCLUSION.DisplayMember = "ITINERARY_INCLUSION"
    '            CMBINCLUSION.Text = TEMPPACKAGENAME
    '            CMBINCLUSION.Text = ""
    '        End If
    '    Catch ex As Exception
    '        If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
    '    End Try
    'End Sub

    Sub fillcmb()
        Try
            FILLPACKAGENAME()
            fillHOTEL(CMBHOTEL, "")
            fillcity(CMBCITY)
            FILLROOMTYPE()
            FILLVEHICLE(CMBVEHICLENAME, edit, "")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ITINERARYMASTER_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
            CMBPACKAGENAME.Text = TEMPPACKAGENAME

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim ALPARAVAL As New ArrayList
                Dim OBJITI As New ClsItineraryMaster

                ALPARAVAL.Add(TEMPITINERARYNO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(YearId)
                OBJITI.alParaval = ALPARAVAL

                Dim dt As DataTable = OBJITI.SELECTITINERARY()

                If dt.Rows.Count > 0 Then

                    TXTITINERARYNO.Text = TEMPITINERARYNO
                    CMBPACKAGETYPE.Text = Convert.ToString(dt.Rows(0).Item("PACKAGETYPE"))
                    CMBPACKAGENAME.Text = Convert.ToString(dt.Rows(0).Item("NAME"))
                    TEMPPACKAGENAME = Convert.ToString(dt.Rows(0).Item("NAME"))

                    PACKAGEFROM.Value = Convert.ToDateTime(dt.Rows(0).Item("FROMDATE")).Date
                    PACKAGETO.Value = Convert.ToDateTime(dt.Rows(0).Item("TODATE")).Date

                    TXTDISPLAYNAME.Text = Convert.ToString(dt.Rows(0).Item("DISPLAYNAME"))


                    TXTADULTRATE.Text = Format(Val(dt.Rows(0).Item("ADULTRATE")), "0.00")
                    TXTEXTRAADULTRATE.Text = Format(Val(dt.Rows(0).Item("EXTRAADULTRATE")), "0.00")
                    TXTCHILDBEDRATE.Text = Format(Val(dt.Rows(0).Item("CHILDBEDRATE")), "0.00")
                    TXTCHILDRATE.Text = Format(Val(dt.Rows(0).Item("CHILDRATE")), "0.00")
                    TXTCHILDBELOWAGE.Text = Format(Val(dt.Rows(0).Item("CHILDBELOWAGE")), "0.00")
                    TXTTOTALDAYS.Text = Val(dt.Rows(0).Item("TOTALDAYS"))

                    TXTPDFPATH.Text = Convert.ToString(dt.Rows(0).Item("PDFPATH"))

                    TXTINCLUSION.Text = Convert.ToString(dt.Rows(0).Item("INCLUSION"))
                    TXTEXCLUSION.Text = Convert.ToString(dt.Rows(0).Item("EXCLUSION"))
                    TXTTERMS.Text = Convert.ToString(dt.Rows(0).Item("TERMS"))
                    TXTREMARKS.Text = Convert.ToString(dt.Rows(0).Item("REMARKS"))

                    CMBQUOTE.Text = Convert.ToString(dt.Rows(0).Item("QUOTE"))
                    TXTLUMPSUMCOST.Text = Format(Val(dt.Rows(0).Item("LUMPSUM")), "0.00")

                    'TOUR GRID
                    Dim OBJCMN As New ClsCommon
                    Dim dt1 As DataTable
                    dt1 = OBJCMN.search(" ITINERARY_SRNO AS SRNO, ITINERARY_HEADER AS HEADER, ITINERARY_DETAILS AS DETAILS, ITINERARY_PHOTO AS IMGPATH ", "", " ITINERARYMASTER_DESC ", " AND ITINERARYMASTER_DESC.ITINERARY_NO = " & TEMPITINERARYNO & " AND ITINERARY_CMPID = " & CmpId & " AND ITINERARY_YEARID = " & YearId & " ORDER BY ITINERARYMASTER_DESC.ITINERARY_SRNO ")
                    If dt1.Rows.Count > 0 Then
                        For Each ROW As DataRow In dt1.Rows
                            If IsDBNull(ROW("IMGPATH")) = False Then GRIDITINERARY.Rows.Add(Val(ROW("SRNO")), ROW("HEADER"), ROW("DETAILS"), Image.FromStream(New IO.MemoryStream(DirectCast(ROW("IMGPATH"), Byte())))) Else GRIDITINERARY.Rows.Add(Val(ROW("SRNO")), ROW("HEADER"), ROW("DETAILS"), Nothing)
                        Next
                    End If

                    PBSOFTCOPY.Image = Nothing

                    'HOTEL GRID
                    Dim OBJHOTEL As New ClsCommon
                    Dim DT2 As DataTable
                    DT2 = OBJHOTEL.search(" ISNULL(ITINERARYMASTER_HOTEL.ITINERARY_SRNO, 0) AS SRNO, ISNULL(CITYMASTER.city_name, '') AS CITY, ISNULL(HOTELMASTER.HOTEL_NAME, '') AS HOTELNAME, ISNULL(ROOMTYPEMASTER.ROOMTYPE_NAME, '') AS ROOMTYPE, ISNULL(ITINERARYMASTER_HOTEL.ITINERARY_NIGHTS, 0) AS NIGHTS, ITINERARY_HOTELPHOTO AS HOTELIMGPATH ", "", " ITINERARYMASTER_HOTEL INNER JOIN CITYMASTER ON ITINERARYMASTER_HOTEL.ITINERARY_CITYID = CITYMASTER.city_id INNER JOIN HOTELMASTER ON ITINERARYMASTER_HOTEL.ITINERARY_HOTELID = HOTELMASTER.HOTEL_ID INNER JOIN ROOMTYPEMASTER ON ITINERARYMASTER_HOTEL.ITINERARY_ROOMTYPEID = ROOMTYPEMASTER.ROOMTYPE_ID ", " AND ITINERARYMASTER_HOTEL.ITINERARY_NO = " & TEMPITINERARYNO & " AND ITINERARYMASTER_HOTEL.ITINERARY_CMPID = " & CmpId & " AND ITINERARYMASTER_HOTEL.ITINERARY_YEARID = " & YearId & " ORDER BY ITINERARYMASTER_HOTEL.ITINERARY_SRNO ")
                    For Each DTR As DataRow In DT2.Rows
                        If IsDBNull(DTR("HOTELIMGPATH")) = False Then GRIDHOTEL.Rows.Add(Val(DTR("SRNO")), DTR("CITY"), DTR("HOTELNAME"), DTR("ROOMTYPE"), Val(DTR("NIGHTS")), Image.FromStream(New IO.MemoryStream(DirectCast(DTR("HOTELIMGPATH"), Byte())))) Else GRIDHOTEL.Rows.Add(Val(DTR("SRNO")), DTR("CITY"), DTR("HOTELNAME"), DTR("ROOMTYPE"), Val(DTR("NIGHTS")), Nothing)

                    Next

                    PBHOTELSOFTCOPY.Image = Nothing
                    CMBROOMTYPE.SelectedItem = Nothing

                    'GET AIRLINE DATA
                    dt = OBJCMN.search(" ISNULL(ITINERARY_NO, 0) AS GROUPDEPNO, ISNULL(ITINERARY_GRIDSRNO, 0) AS AIRSRNO, ISNULL(ITINERARY_SECTOR, '') AS SECTOR, ISNULL(ITINERARY_FLTNO, '') AS FLTNO, ISNULL(ITINERARY_TYPE, '') AS TYPE, ISNULL(ITINERARY_BASIC, 0) AS BASIC, ISNULL(ITINERARY_PSF, 0) AS PSF, ISNULL(ITINERARY_TAXES, 0) AS TAXES, ISNULL(ITINERARY_AMT, 0) AS AIRAMT ", "", "ITINERARYMASTER_AIRLINE", " AND ITINERARYMASTER_AIRLINE.ITINERARY_NO = " & TEMPITINERARYNO & " AND ITINERARY_YEARID = " & YearId & " ORDER BY ITINERARYMASTER_AIRLINE.ITINERARY_GRIDSRNO")
                    If dt.Rows.Count > 0 Then
                        For Each DR As DataRow In dt.Rows
                            GRIDAIRLINE.Rows.Add(DR("AIRSRNO"), DR("SECTOR"), DR("FLTNO"), DR("TYPE"), Format(Val(DR("BASIC")), "0.00"), Format(Val(DR("PSF")), "0.00"), Format(Val(DR("TAXES")), "0.00"), Format(Val(DR("AIRAMT")), "0.00"))
                        Next
                        total()
                    End If


                    'GET GRIDFLIGHT DATA
                    dt = OBJCMN.search(" ITINERARYMASTER_FLIGHTDESC.ITINERARY_GRIDSRNO AS GRIDSRNO, ITINERARYMASTER_FLIGHTDESC.ITINERARY_BOOKSRNO AS BOOKSRNO, ISNULL(FROMSECTORMASTER.SECTOR_NAME, '') AS FROMSEC, ISNULL(TOSECTORMASTER.SECTOR_NAME, '') AS TOSEC, ITINERARYMASTER_FLIGHTDESC.ITINERARY_FLIGHTNO AS FLIGHTNO, ITINERARYMASTER_FLIGHTDESC.ITINERARY_FLIGHTDATE AS FLIGHTDATE, ISNULL(ITINERARYMASTER_FLIGHTDESC.ITINERARY_ARRIVES, '') AS ARRIVES, CLASSMASTER.CLASS_NAME AS CLASS", "", " SECTORMASTER AS TOSECTORMASTER RIGHT OUTER JOIN ITINERARYMASTER_FLIGHTDESC LEFT OUTER JOIN CLASSMASTER ON ITINERARYMASTER_FLIGHTDESC.ITINERARY_YEARID = CLASSMASTER.CLASS_YEARID AND  ITINERARYMASTER_FLIGHTDESC.ITINERARY_CMPID = CLASSMASTER.CLASS_CMPID AND ITINERARYMASTER_FLIGHTDESC.ITINERARY_CLASSID = CLASSMASTER.CLASS_ID ON  TOSECTORMASTER.SECTOR_ID = ITINERARYMASTER_FLIGHTDESC.ITINERARY_TOID AND TOSECTORMASTER.SECTOR_CMPID = ITINERARYMASTER_FLIGHTDESC.ITINERARY_CMPID AND TOSECTORMASTER.SECTOR_YEARID = ITINERARYMASTER_FLIGHTDESC.ITINERARY_YEARID LEFT OUTER JOIN SECTORMASTER AS FROMSECTORMASTER ON ITINERARYMASTER_FLIGHTDESC.ITINERARY_FROMID = FROMSECTORMASTER.SECTOR_ID AND ITINERARYMASTER_FLIGHTDESC.ITINERARY_CMPID = FROMSECTORMASTER.SECTOR_CMPID AND ITINERARYMASTER_FLIGHTDESC.ITINERARY_YEARID = FROMSECTORMASTER.SECTOR_YEARID", " AND ITINERARYMASTER_FLIGHTDESC.ITINERARY_NO = " & TEMPITINERARYNO & " AND ITINERARYMASTER_FLIGHTDESC.ITINERARY_CMPID = " & CmpId & " AND ITINERARYMASTER_FLIGHTDESC.ITINERARY_YEARID = " & YearId & " ORDER BY ITINERARYMASTER_FLIGHTDESC.ITINERARY_BOOKSRNO ASC, ITINERARYMASTER_FLIGHTDESC.ITINERARY_GRIDSRNO ASC")
                    If dt.Rows.Count > 0 Then
                        For Each DR As DataRow In dt.Rows
                            GRIDFLIGHT.Rows.Add(DR("GRIDSRNO").ToString, DR("BOOKSRNO"), DR("FROMSEC").ToString, DR("TOSEC").ToString, DR("FLIGHTNO").ToString, DR("FLIGHTDATE").ToString, DR("ARRIVES").ToString, DR("CLASS").ToString)
                        Next
                    End If

                    'VEHICLE GRID
                    Dim OBJVEHICLE As New ClsCommon
                    Dim DT3 As DataTable
                    DT3 = OBJVEHICLE.search(" ISNULL(ITINERARYMASTER_VEHICLE.ITINERARY_SRNO, 0) AS SRNO, ISNULL(VEHICLEMASTER.VEHICLE_NAME, '') AS VEHICLENAME, ISNULL(ITINERARYMASTER_VEHICLE.ITINERARY_DESCRIPTION, '') AS DESCRIPTION, ISNULL(ITINERARYMASTER_VEHICLE.ITINERARY_DAYS, 0) AS VEHICLEDAYS ", "", " ITINERARYMASTER_VEHICLE INNER JOIN VEHICLEMASTER ON ITINERARYMASTER_VEHICLE.ITINERARY_VEHICLEID = VEHICLEMASTER.VEHICLE_ID ", "AND ITINERARYMASTER_VEHICLE.ITINERARY_NO = " & TEMPITINERARYNO & " AND ITINERARYMASTER_VEHICLE.ITINERARY_CMPID = " & CmpId & " AND ITINERARYMASTER_VEHICLE.ITINERARY_YEARID = " & YearId & " ORDER BY ITINERARYMASTER_VEHICLE.ITINERARY_SRNO ")
                    If DT3.Rows.Count > 0 Then
                        For Each DTV As DataRow In DT3.Rows
                            GRIDVEHICLE.Rows.Add(Val(DTV("SRNO")), DTV("VEHICLENAME"), DTV("DESCRIPTION"), Val(DTV("VEHICLEDAYS")))
                        Next
                    End If

                    'MISC GRID
                    Dim OBJMISC As New ClsCommon
                    Dim DT4 As DataTable
                    DT4 = OBJMISC.search(" ISNULL(ITINERARYMASTER_MISC.ITINERARY_SRNO, 0) AS SRNO, ISNULL(ITINERARYMASTER_MISC.ITINERARY_TYPE, '') AS SERVICETYPE, ISNULL(ITINERARYMASTER_MISC.ITINERARY_REMARKS, '') AS MISCREMARKS ", "", " ITINERARYMASTER_MISC INNER JOIN ITINERARYMASTER ON ITINERARYMASTER_MISC.ITINERARY_NO = ITINERARYMASTER.ITINERARY_NO ", "AND ITINERARYMASTER_MISC.ITINERARY_NO = " & TEMPITINERARYNO & " AND ITINERARYMASTER_MISC.ITINERARY_CMPID = " & CmpId & " AND ITINERARYMASTER_MISC.ITINERARY_YEARID = " & YearId & " ORDER BY ITINERARYMASTER_MISC.ITINERARY_SRNO ")
                    If DT4.Rows.Count > 0 Then
                        For Each DTM As DataRow In DT4.Rows
                            GRIDMISC.Rows.Add(Val(DTM("SRNO")), DTM("SERVICETYPE"), DTM("MISCREMARKS"))
                        Next
                    End If

                End If
            End If
        Catch ex As Exception
            Throw ex
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

            alParaval.Add(CMBPACKAGETYPE.Text.Trim)
            alParaval.Add(CMBPACKAGENAME.Text.Trim)
            alParaval.Add(TXTDISPLAYNAME.Text.Trim)
            alParaval.Add(PACKAGEFROM.Value.Date)
            alParaval.Add(PACKAGETO.Value.Date)

            alParaval.Add(Val(TXTADULTRATE.Text.Trim))
            alParaval.Add(Val(TXTEXTRAADULTRATE.Text.Trim))
            alParaval.Add(Val(TXTTOTALDAYS.Text.Trim))
            alParaval.Add(Val(TXTCHILDBEDRATE.Text.Trim))
            alParaval.Add(Val(TXTCHILDRATE.Text.Trim))
            alParaval.Add(Val(TXTCHILDBELOWAGE.Text.Trim))

            alParaval.Add(TXTPDFPATH.Text.Trim)

            alParaval.Add(TXTINCLUSION.Text.Trim)
            alParaval.Add(TXTEXCLUSION.Text.Trim)
            alParaval.Add(TXTTERMS.Text.Trim)
            alParaval.Add(TXTREMARKS.Text.Trim)



            If CHKSIMILAR.Checked = True Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(CMBQUOTE.Text.Trim)
            alParaval.Add(Val(TXTLUMPSUMCOST.Text.Trim))

            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)

            ''GRID HOTEL
            'Dim HOTELSRNO As String = ""
            'Dim CITY As String = ""
            'Dim HOTELNAME As String = ""
            'Dim ROOMTYPE As String = ""
            'Dim NIGHTS As String = ""

            'For Each row As Windows.Forms.DataGridViewRow In GRIDHOTEL.Rows
            '    If row.Cells(0).Value <> Nothing Then
            '        If HOTELSRNO = "" Then
            '            HOTELSRNO = Val(row.Cells(GHOTELSRNO.Index).Value)
            '            CITY = row.Cells(GCITY.Index).Value.ToString
            '            HOTELNAME = row.Cells(GHOTELNAME.Index).Value.ToString
            '            ROOMTYPE = row.Cells(GROOMTYPE.Index).Value.ToString
            '            NIGHTS = Val(row.Cells(GNIGHTS.Index).Value)
            '        Else
            '            HOTELSRNO = HOTELSRNO & "|" & Val(row.Cells(GHOTELSRNO.Index).Value)
            '            CITY = CITY & "|" & row.Cells(GCITY.Index).Value.ToString
            '            HOTELNAME = HOTELNAME & "|" & row.Cells(GHOTELNAME.Index).Value.ToString
            '            ROOMTYPE = ROOMTYPE & "|" & row.Cells(GROOMTYPE.Index).Value.ToString
            '            NIGHTS = NIGHTS & "|" & Val(row.Cells(GNIGHTS.Index).Value)
            '        End If
            '    End If
            'Next

            'alParaval.Add(HOTELSRNO)
            'alParaval.Add(CITY)
            'alParaval.Add(HOTELNAME)
            'alParaval.Add(ROOMTYPE)
            'alParaval.Add(NIGHTS)

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


            'GRID VEHICLE
            Dim VEHICLESRNO As String = ""
            Dim VEHICLENAME As String = ""
            Dim DESCRIPTION As String = ""
            Dim VEHICLEDAYS As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDVEHICLE.Rows
                If row.Cells(0).Value <> Nothing Then
                    If VEHICLESRNO = "" Then
                        VEHICLESRNO = Val(row.Cells(GVEHICLESRNO.Index).Value)
                        VEHICLENAME = row.Cells(GVEHICLENAME.Index).Value.ToString
                        DESCRIPTION = row.Cells(GVEHICLEDESC.Index).Value.ToString
                        VEHICLEDAYS = Val(row.Cells(GVEHICLEDAYS.Index).Value)
                    Else
                        VEHICLESRNO = VEHICLESRNO & "|" & Val(row.Cells(GVEHICLESRNO.Index).Value)
                        VEHICLENAME = VEHICLENAME & "|" & row.Cells(GVEHICLENAME.Index).Value.ToString
                        DESCRIPTION = DESCRIPTION & "|" & row.Cells(GVEHICLEDESC.Index).Value.ToString
                        VEHICLEDAYS = VEHICLEDAYS & "|" & Val(row.Cells(GVEHICLEDAYS.Index).Value)
                    End If
                End If
            Next

            alParaval.Add(VEHICLESRNO)
            alParaval.Add(VEHICLENAME)
            alParaval.Add(DESCRIPTION)
            alParaval.Add(VEHICLEDAYS)

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

            alParaval.Add(CMBINCLUSION.Text.Trim)
            alParaval.Add(CMBEXCLUSION.Text.Trim)

            Dim OBJITI As New ClsItineraryMaster()
            OBJITI.alParaval = alParaval

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTNO As DataTable = OBJITI.SAVE()
                MsgBox("Details Added")
                TEMPITINERARYNO = DTNO.Rows(0).Item(0)
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPITINERARYNO)

                IntResult = OBJITI.UPDATE()
                MsgBox("Details Updated")
                edit = False
            End If
            If GRIDITINERARY.RowCount > 0 Then SAVEITINERARY()
            If GRIDHOTEL.RowCount > 0 Then SAVEHOTEL()
            clear()
            CMBPACKAGENAME.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub SAVEITINERARY()
        Try
            'GRID ITINERARY
            Dim OBJITI As New ClsItineraryMaster
            For Each row As Windows.Forms.DataGridViewRow In GRIDITINERARY.Rows
                Dim ALPARAVAL As New ArrayList
                If row.Cells(GTOURSRNO.Index).Value <> Nothing Then
                    ALPARAVAL.Add(TEMPITINERARYNO)
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
                    Dim INTRES As Integer = OBJITI.SAVEITINERARY()
                End If
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SAVEHOTEL()
        Try
            'GRID HOTEL
            Dim OBJITI As New ClsItineraryMaster
            For Each row As Windows.Forms.DataGridViewRow In GRIDHOTEL.Rows
                Dim ALPARAVAL As New ArrayList
                If row.Cells(GHOTELSRNO.Index).Value <> Nothing Then
                    ALPARAVAL.Add(TEMPITINERARYNO)
                    ALPARAVAL.Add(row.Cells(GHOTELSRNO.Index).Value)
                    ALPARAVAL.Add(row.Cells(GCITY.Index).Value)
                    ALPARAVAL.Add(row.Cells(GHOTELNAME.Index).Value)
                    ALPARAVAL.Add(row.Cells(GROOMTYPE.Index).Value)
                    ALPARAVAL.Add(row.Cells(GNIGHTS.Index).Value)

                    If row.Cells(GHOTELIMGPATH.Index).Value IsNot Nothing Then
                        Dim MS As New IO.MemoryStream
                        PBHOTELSOFTCOPY.Image = row.Cells(GHOTELIMGPATH.Index).Value
                        PBHOTELSOFTCOPY.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                        ALPARAVAL.Add(MS.ToArray)
                    Else
                        ALPARAVAL.Add(DBNull.Value)
                    End If

                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Userid)
                    ALPARAVAL.Add(YearId)

                    OBJITI.alParaval = ALPARAVAL
                    Dim INTRES As Integer = OBJITI.SAVEHOTEL()
                End If
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If CMBPACKAGENAME.Text.Trim = "" Then
            EP.SetError(CMBPACKAGENAME, " Please Fill Package name")
            bln = False
        End If

        Dim OBJCMN As New ClsCommon
        Dim DT As New DataTable
        If CMBPACKAGENAME.Text.Trim <> "" Then
            uppercase(CMBPACKAGENAME)
            If (edit = False) Or (edit = True And LCase(CMBPACKAGENAME.Text.Trim) <> LCase(TEMPPACKAGENAME)) Then
                DT = OBJCMN.search(" ITINERARY_NAME ", "", " ITINERARYMASTER ", " AND ITINERARY_NAME = '" & CMBPACKAGENAME.Text.Trim & "' AND ITINERARY_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    EP.SetError(CMBPACKAGENAME, " Package Name Already Exists ")
                    bln = False
                End If
            End If
        End If


        If TXTDISPLAYNAME.Text.Trim = "" Then
            EP.SetError(TXTDISPLAYNAME, " Please Fill Display name ")
            bln = False
        End If

        If CMBQUOTE.Text.Trim = "" Then
            EP.SetError(CMBTYPE, " Please Fill Quote Type ")
            bln = False
        End If

        If Val(TXTTOTALDAYS.Text.Trim) = 0 Then
            EP.SetError(TXTTOTALDAYS, " Please Enter Total Days")
            bln = False
        End If

        If CMBQUOTE.Text = "Per Person" Then
            If Val(TXTADULTRATE.Text.Trim) = 0 Then
                EP.SetError(TXTADULTRATE, " Please Enter Adult Rate on Twin Sharing ")
                bln = False
            End If
        End If

        If CMBQUOTE.Text = "Lump Sum" Then
            If Val(TXTLUMPSUMCOST.Text.Trim) = 0 Then
                EP.SetError(TXTLUMPSUMCOST, "Please Enter Lump Sum Cost")
                bln = False
            End If
        End If


        If GRIDITINERARY.RowCount = 0 Then
            EP.SetError(TabControl1, "Enter Proper Itinerary Details")
            bln = False
        End If

        If GRIDHOTEL.RowCount = 0 Then
            EP.SetError(TabControl1, "Enter Proper Hotel Details")
            bln = False
        End If

        If PACKAGEFROM.Value.Date > PACKAGETO.Value.Date Then
            EP.SetError(PACKAGETO, "Enter Proper Dates")
            bln = False
        End If

        'THIS IS DONE COZ NIGHTSS SHOULD TO ADDED BY 1 TO MATCH WITH DAYS
        Dim TEMPTOTALNIGHTS As Integer = 1
        For Each ROW As DataGridViewRow In GRIDHOTEL.Rows
            TEMPTOTALNIGHTS += Val(ROW.Cells(GNIGHTS.Index).Value)
        Next
        If Val(TXTTOTALDAYS.Text.Trim) <> Val(TEMPTOTALNIGHTS) Then
            If MsgBox("Total Nights Does Not Match With Days, Wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                EP.SetError(TXTTOTALDAYS, "Total Nights Does Not Match With Days")
                bln = False
            End If
        End If



        'CHECKING WHETHER FROM AND TO AND CLASS ARE PRESENT IN MASTER OR NOT IF NOT ADD NEW
        For Each ROW As DataGridViewRow In GRIDFLIGHT.Rows
            Dim alParaval As New ArrayList
            Dim objclsSECTOR As New ClsSectorMaster
            If ROW.Cells(GFROM.Index).Value <> "" Then
                DT = OBJCMN.search("SECTOR_id", "", " SECTORMaster", " and SECTOR_NAME = '" & ROW.Cells(GFROM.Index).Value & "' and SECTOR_YEARid = " & YearId)
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
                DT = OBJCMN.search("SECTOR_id", "", " SECTORMaster", " and SECTOR_NAME = '" & ROW.Cells(GTO.Index).Value & "' and SECTOR_YEARid = " & YearId)
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
                DT = OBJCMN.search("CLASS_id", "", " CLASSMaster", " and CLASS_NAME = '" & ROW.Cells(GCLASS.Index).Value & "' and CLASS_YEARid = " & YearId)
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

    Private Sub TXTTOURSRNO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTTOURSRNO.GotFocus
        If GRIDVEHICLEDOUBLECLICK = False Then
            If GRIDHOTEL.RowCount > 0 Then TXTTOURSRNO.Text = GRIDHOTEL.RowCount + 1
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

    Private Sub GRIDITINERARY_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDITINERARY.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDITINERARY.Item(GTOURSRNO.Index, e.RowIndex).Value <> Nothing Then

                GRIDITINERARYDOUBLECLICK = True
                TXTTOURSRNO.Text = GRIDITINERARY.Item(GTOURSRNO.Index, e.RowIndex).Value
                TXTHEADER.Text = GRIDITINERARY.Item(GHEADER.Index, e.RowIndex).Value
                TXTDETAILS.Text = GRIDITINERARY.Item(GDETAILS.Index, e.RowIndex).Value.ToString
                PBSOFTCOPY.Image = GRIDITINERARY.Item(GIMGPATH.Index, e.RowIndex).Value

                'TXTIMGPATH.Text = GRIDITINERARY.Item(GIMGPATH.Index, e.RowIndex).Value.ToString

                TEMPITINERARYROW = e.RowIndex
                TXTHEADER.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDITINERARY_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDITINERARY.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDITINERARY.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDITINERARYDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block
                GRIDITINERARY.Rows.RemoveAt(GRIDITINERARY.CurrentRow.Index)
                getsrno(GRIDITINERARY)
                TXTTOURSRNO.Text = GRIDITINERARY.RowCount + 1
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDHOTEL_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDHOTEL.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDHOTEL.Item(GHOTELSRNO.Index, e.RowIndex).Value <> Nothing Then

                GRIDHOTELDOUBLECLICK = True
                TXTHOTELSRNO.Text = GRIDHOTEL.Item(GHOTELSRNO.Index, e.RowIndex).Value.ToString
                CMBCITY.Text = GRIDHOTEL.Item(GCITY.Index, e.RowIndex).Value.ToString
                CMBHOTEL.Text = GRIDHOTEL.Item(GHOTELNAME.Index, e.RowIndex).Value.ToString
                FILLROOMTYPE()
                CMBROOMTYPE.SelectedIndex = Nothing
                CMBROOMTYPE.Text = GRIDHOTEL.Item(GROOMTYPE.Index, e.RowIndex).Value
                TXTHOTELNIGHTS.Text = Val(GRIDHOTEL.Item(GNIGHTS.Index, e.RowIndex).Value)
                PBHOTELSOFTCOPY.Image = GRIDHOTEL.Item(GHOTELIMGPATH.Index, e.RowIndex).Value

                'TXTHOTELIMGPATH.Text = GRIDHOTEL.Item(GHOTELIMGPATH.Index, e.RowIndex).Value.ToString

                TEMPHOTELROW = e.RowIndex
                CMBCITY.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDVEHICLE_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDVEHICLE.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDVEHICLE.Item(GVEHICLESRNO.Index, e.RowIndex).Value <> Nothing Then

                GRIDVEHICLEDOUBLECLICK = True
                TXTVEHICLESRNO.Text = GRIDVEHICLE.Item(GVEHICLESRNO.Index, e.RowIndex).Value.ToString
                CMBVEHICLENAME.Text = GRIDVEHICLE.Item(GVEHICLENAME.Index, e.RowIndex).Value.ToString
                TXTVEHICLEDESCRIPTION.Text = GRIDVEHICLE.Item(GVEHICLEDESC.Index, e.RowIndex).Value.ToString
                TXTVEHICLEDAYS.Text = Val(GRIDVEHICLE.Item(GVEHICLEDAYS.Index, e.RowIndex).Value)
                TEMPVEHICLEROW = e.RowIndex
                CMBVEHICLENAME.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDVEHICLE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDVEHICLE.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDVEHICLE.RowCount > 0 Then


                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDVEHICLEDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDVEHICLE.Rows.RemoveAt(GRIDVEHICLE.CurrentRow.Index)
                getsrno(GRIDVEHICLE)

            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDHOTEL_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDHOTEL.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDHOTEL.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDVEHICLEDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDHOTEL.Rows.RemoveAt(GRIDHOTEL.CurrentRow.Index)
                getsrno(GRIDHOTEL)

            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If tstxtbillno.Text.Trim.Length = 0 Then Exit Sub
            GRIDHOTEL.RowCount = 0
            TEMPITINERARYNO = Val(tstxtbillno.Text)
            If TEMPITINERARYNO > 0 Then
                edit = True
                ITINERARYMASTER_Load(sender, e)
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
            Dim OBJITI As New ItineraryDetails
            OBJITI.MdiParent = MDIMain
            OBJITI.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            GRIDHOTEL.RowCount = 0
LINE1:
            TEMPITINERARYNO = Val(TXTITINERARYNO.Text) - 1
            If TEMPITINERARYNO > 0 Then
                edit = True
                ITINERARYMASTER_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If GRIDHOTEL.RowCount = 0 And TEMPITINERARYNO > 1 Then
                TXTITINERARYNO.Text = TEMPITINERARYNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            GRIDHOTEL.RowCount = 0
LINE1:
            TEMPITINERARYNO = Val(TXTITINERARYNO.Text) + 1
            getmax_ITINERARY_no()
            Dim MAXNO As Integer = TXTITINERARYNO.Text.Trim
            clear()
            If Val(TXTITINERARYNO.Text) - 1 >= TEMPITINERARYNO Then
                edit = True
                ITINERARYMASTER_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If GRIDHOTEL.RowCount = 0 And TEMPITINERARYNO < MAXNO Then
                TXTITINERARYNO.Text = TEMPITINERARYNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBHOTEL_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBHOTEL.Enter
        Try
            If CMBHOTEL.Text.Trim = "" Then fillHOTEL(CMBHOTEL)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPACKAGENAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPACKAGENAME.Enter
        Try
            If CMBPACKAGENAME.Text.Trim = "" Then FILLPACKAGENAME()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHOTEL_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBHOTEL.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJHOTEL As New SelectHotel
                OBJHOTEL.ShowDialog()
                If OBJHOTEL.TEMPHOTELNAME <> "" Then CMBHOTEL.Text = OBJHOTEL.TEMPHOTELNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHOTEL_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBHOTEL.Validated
        Try
            FILLROOMTYPE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHOTEL_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBHOTEL.Validating
        Try
            If CMBHOTEL.Text.Trim <> "" Then HOTELvalidate(CMBHOTEL, CMBCODE, e, Me, TXTADD)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPACKAGENAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPACKAGENAME.Validating

        Try
            If CMBPACKAGENAME.Text.Trim <> "" Then
                uppercase(CMBPACKAGENAME)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If (edit = False) Or (edit = True And LCase(CMBPACKAGENAME.Text.Trim) <> LCase(TEMPPACKAGENAME)) Then
                    dt = objclscommon.search(" ITINERARY_NAME ", "", " ITINERARYMASTER ", " AND ITINERARY_NAME = '" & CMBPACKAGENAME.Text.Trim & "' AND ITINERARY_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Package Name Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Try
            If edit = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim tempmsg As Integer = MsgBox("Delete Itinerary Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                If tempmsg = vbYes Then

                    Dim OBJITI As New ClsItineraryMaster
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(TEMPITINERARYNO)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(YearId)

                    OBJITI.alParaval = ALPARAVAL
                    Dim INT As Integer = OBJITI.Delete()
                    MsgBox("Itinerary Deleted")

                    clear()
                    edit = False

                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLROOMTYPE()
        Try
            If CMBHOTEL.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" DISTINCT ROOMTYPEMASTER.ROOMTYPE_NAME AS ROOMTYPE", "", " HOTELMASTER_ROOMDESC INNER JOIN HOTELMASTER ON HOTELMASTER_ROOMDESC.HOTEL_ID = HOTELMASTER.HOTEL_ID AND HOTELMASTER_ROOMDESC.HOTEL_CMPID = HOTELMASTER.HOTEL_CMPID AND HOTELMASTER_ROOMDESC.HOTEL_LOCATIONID = HOTELMASTER.HOTEL_LOCATIONID AND HOTELMASTER_ROOMDESC.HOTEL_YEARID = HOTELMASTER.HOTEL_YEARID INNER JOIN ROOMTYPEMASTER ON HOTELMASTER_ROOMDESC.HOTEL_ROOMTYPEID = ROOMTYPEMASTER.ROOMTYPE_ID AND HOTELMASTER_ROOMDESC.HOTEL_CMPID = ROOMTYPEMASTER.ROOMTYPE_CMPID AND HOTELMASTER_ROOMDESC.HOTEL_LOCATIONID = ROOMTYPEMASTER.ROOMTYPE_LOCATIONID AND HOTELMASTER_ROOMDESC.HOTEL_YEARID = ROOMTYPEMASTER.ROOMTYPE_YEARID", " AND HOTELMASTER.HOTEL_NAME = '" & CMBHOTEL.Text.Trim & "' AND HOTELMASTER.HOTEL_CMPID = " & CmpId & " AND HOTELMASTER.HOTEL_LOCATIONID = " & Locationid & " AND HOTELMASTER.HOTEL_YEARID = " & YearId)
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

    Private Sub CMBVEHICLENAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBVEHICLENAME.Enter
        Try
            If CMBVEHICLENAME.Text.Trim = "" Then FILLVEHICLE(CMBVEHICLENAME, edit, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTVEHICLESRNO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTVEHICLESRNO.GotFocus
        Try
            If GRIDVEHICLEDOUBLECLICK = False Then
                If GRIDVEHICLE.RowCount > 0 Then TXTVEHICLESRNO.Text = GRIDVEHICLE.RowCount + 1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRIDVEHICLE()
        Try
            If GRIDVEHICLEDOUBLECLICK = False Then

                GRIDVEHICLE.Rows.Add(Val(TXTVEHICLESRNO.Text.Trim), CMBVEHICLENAME.Text.Trim, TXTVEHICLEDESCRIPTION.Text.Trim, Val(TXTVEHICLEDAYS.Text.Trim))
                getsrno(GRIDVEHICLE)

            ElseIf GRIDVEHICLEDOUBLECLICK = True Then

                GRIDVEHICLE.Item(GVEHICLESRNO.Index, TEMPVEHICLEROW).Value = TXTVEHICLESRNO.Text.Trim
                GRIDVEHICLE.Item(GVEHICLENAME.Index, TEMPVEHICLEROW).Value = CMBVEHICLENAME.Text.Trim
                GRIDVEHICLE.Item(GVEHICLEDESC.Index, TEMPVEHICLEROW).Value = TXTVEHICLEDESCRIPTION.Text.Trim
                GRIDVEHICLE.Item(GVEHICLEDAYS.Index, TEMPVEHICLEROW).Value = TXTVEHICLEDAYS.Text.Trim

                GRIDVEHICLEDOUBLECLICK = False

            End If
            GRIDVEHICLE.FirstDisplayedScrollingRowIndex = GRIDVEHICLE.RowCount - 1

            TXTVEHICLESRNO.Text = GRIDVEHICLE.RowCount + 1
            CMBVEHICLENAME.Text = ""
            TXTVEHICLEDESCRIPTION.Clear()
            TXTVEHICLEDAYS.Clear()

            CMBVEHICLENAME.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
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

    Private Sub CMBVEHICLENAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBVEHICLENAME.Validating
        Try
            If CMBVEHICLENAME.Text.Trim <> "" Then VEHICLEVALIDATE(CMBVEHICLENAME, e, Me, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDUPLOAD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDUPLOAD.Click
        OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg;*.png)|*.bmp;*.jpeg;*.jpg;*.png"
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
            If GRIDITINERARY.SelectedRows.Count > 0 Then
                Dim objVIEW As New ViewImage
                objVIEW.pbsoftcopy.Image = PBSOFTCOPY.Image
                objVIEW.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDITINERARY_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDITINERARY.RowEnter
        Try
            If e.RowIndex >= 0 Then PBSOFTCOPY.Image = GRIDITINERARY.Rows(e.RowIndex).Cells(GIMGPATH.Index).Value
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
                OBJMAIL.subject = CMBPACKAGENAME.Text.Trim
                OBJMAIL.MdiParent = MDIMain
                OBJMAIL.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTDETAILS_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTDETAILS.Validating
        Try
            If TXTHEADER.Text.Trim <> "" And TXTDETAILS.Text.Trim <> "" Then
                FILLITINERARY()
            Else
                If TXTHEADER.Text.Trim <> "" Then MsgBox("Enter Proper Details")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLITINERARY()
        Try
            If GRIDITINERARYDOUBLECLICK = False Then
                GRIDITINERARY.Rows.Add(Val(TXTTOURSRNO.Text.Trim), TXTHEADER.Text.Trim, TXTDETAILS.Text.Trim, PBSOFTCOPY.Image)
                getsrno(GRIDITINERARY)

            ElseIf GRIDITINERARYDOUBLECLICK = True Then

                GRIDITINERARY.Item(GTOURSRNO.Index, TEMPITINERARYROW).Value = TXTTOURSRNO.Text.Trim
                GRIDITINERARY.Item(GHEADER.Index, TEMPITINERARYROW).Value = TXTHEADER.Text.Trim
                GRIDITINERARY.Item(GDETAILS.Index, TEMPITINERARYROW).Value = TXTDETAILS.Text.Trim
                GRIDITINERARY.Item(GIMGPATH.Index, TEMPITINERARYROW).Value = PBSOFTCOPY.Image

                GRIDITINERARYDOUBLECLICK = False
            End If

            GRIDITINERARY.FirstDisplayedScrollingRowIndex = GRIDITINERARY.RowCount - 1

            TXTTOURSRNO.Text = GRIDITINERARY.RowCount + 1
            TXTHEADER.Clear()
            TXTDETAILS.Clear()
            PBSOFTCOPY.Image = Nothing
            'TXTIMGPATH.Clear()

            TXTHEADER.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTHOTELNIGHTS_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTHOTELNIGHTS.Validating
        Try
            If CMBCITY.Text.Trim <> "" And CMBHOTEL.Text.Trim <> "" And CMBROOMTYPE.Text.Trim <> "" And Val(TXTHOTELNIGHTS.Text.Trim) <> 0 Then
                FILLGRIDHOTEL()
            Else
                MsgBox("Enter Proper Details")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRIDHOTEL()
        Try
            If GRIDHOTELDOUBLECLICK = False Then

                GRIDHOTEL.Rows.Add(Val(TXTHOTELSRNO.Text.Trim), CMBCITY.Text.Trim, CMBHOTEL.Text.Trim, CMBROOMTYPE.Text.Trim, Val(TXTHOTELNIGHTS.Text.Trim), PBHOTELSOFTCOPY.Image)
                getsrno(GRIDHOTEL)

            ElseIf GRIDHOTELDOUBLECLICK = True Then

                GRIDHOTEL.Item(GHOTELSRNO.Index, TEMPHOTELROW).Value = TXTHOTELSRNO.Text.Trim
                GRIDHOTEL.Item(GCITY.Index, TEMPHOTELROW).Value = CMBCITY.Text.Trim
                GRIDHOTEL.Item(GHOTELNAME.Index, TEMPHOTELROW).Value = CMBHOTEL.Text.Trim
                GRIDHOTEL.Item(GROOMTYPE.Index, TEMPHOTELROW).Value = CMBROOMTYPE.Text.Trim
                GRIDHOTEL.Item(GNIGHTS.Index, TEMPHOTELROW).Value = TXTHOTELNIGHTS.Text.Trim
                GRIDHOTEL.Item(GHOTELIMGPATH.Index, TEMPHOTELROW).Value = PBHOTELSOFTCOPY.Image

                GRIDHOTELDOUBLECLICK = False

            End If
            GRIDHOTEL.FirstDisplayedScrollingRowIndex = GRIDHOTEL.RowCount - 1

            TXTHOTELSRNO.Text = GRIDHOTEL.RowCount + 1
            CMBCITY.Text = ""
            CMBHOTEL.Text = ""
            CMBROOMTYPE.Text = ""
            TXTHOTELNIGHTS.Clear()
            PBHOTELSOFTCOPY.Image = Nothing
            TXTHOTELIMGPATH.Clear()

            CMBCITY.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTHOTELNIGHTS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTHOTELNIGHTS.KeyPress, TXTVEHICLEDAYS.KeyPress, TXTTOTALDAYS.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTADULTRATE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTADULTRATE.KeyPress, TXTEXTRAADULTRATE.KeyPress, TXTCHILDBEDRATE.KeyPress, TXTCHILDRATE.KeyPress, TXTCHILDBELOWAGE.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub CMBPACKAGENAME_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBPACKAGENAME.Validated
        Try
            If CMBPACKAGENAME.Text.Trim <> "" And edit = False Then TXTDISPLAYNAME.Text = CMBPACKAGENAME.Text.Trim
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTVEHICLEDAYS_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTVEHICLEDAYS.Validating
        Try
            If CMBVEHICLENAME.Text.Trim <> "" And Val(TXTVEHICLEDAYS.Text.Trim) <> 0 Then
                FILLGRIDVEHICLE()
            Else
                MsgBox("Enter Proper Details")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTHEADER_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTHEADER.Validating
        Try
            CMDUPLOAD.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDUPLOAD_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMDUPLOAD.Validating
        TXTDETAILS.Focus()
    End Sub

    Sub PRINTREPORT(ByVal ITINERARYNO As Integer)
        Try
            If MsgBox("Wish to Print Itinerary?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            Dim OBJITI As New ItineraryDesign
            OBJITI.MdiParent = MDIMain
            OBJITI.ITINERARYNO = TEMPITINERARYNO
            OBJITI.FRMSTRING = "ITINERARY"
            OBJITI.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripprint.Click
        If edit = True Then PRINTREPORT(TEMPITINERARYNO)
    End Sub

    Private Sub TXTTOTALDAYS_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTTOTALDAYS.Validated
        Try
            If edit = False And Val(TXTVEHICLEDAYS.Text.Trim) = 0 Then TXTVEHICLEDAYS.Text = Val(TXTTOTALDAYS.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTAIRAMT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTAIRAMT.Validating
        Try
            If Val(TXTBASIC.Text.Trim) > 0 And Val(TXTAIRAMT.Text.Trim) > 0 Then
                FILLAIRLINEGRID()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical, "TRAVELMATE")
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub total()
        Try
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
                TEMPFLIGHTROW = e.RowIndex
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

        If return_flight_num.Trim = "" And GRIDFLIGHT.Rows.Count > 0 And GRIDITINERARY.Rows.Count > 0 Then
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
        If return_flight_arrives.Trim = "" And GRIDFLIGHT.Rows.Count > 0 And GRIDITINERARY.Rows.Count > 0 Then
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
        If return_flight_class.Trim = "" And GRIDFLIGHT.Rows.Count > 0 And GRIDITINERARY.Rows.Count > 0 Then
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
        If return_flight_date.Trim = "" And GRIDFLIGHT.Rows.Count > 0 And GRIDITINERARY.Rows.Count > 0 Then
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

    Function getBookingSr(ByVal trimSECTORS As String) As Integer
        Dim booksrno As Integer = 0
        For Each dbrows As System.Windows.Forms.DataGridViewRow In GRIDAIRLINE.Rows
            If dbrows.Cells(GSECTOR.Index).Value.ToString.Trim = trimSECTORS Then
                booksrno = Convert.ToInt32(dbrows.Cells(GAIRSRNO.Index).Value)
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

    Private Sub CMDHUPLOAD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDHOTELUPLOAD.Click
        OpenFileDialog2.Filter = "Pictures (*.bmp;*.jpeg;*.png)|*.bmp;*.jpg;*.png"
        OpenFileDialog2.ShowDialog()
        TXTHOTELIMGPATH.Text = OpenFileDialog2.FileName
        On Error Resume Next
        If TXTHOTELIMGPATH.Text.Trim.Length <> 0 Then PBHOTELSOFTCOPY.ImageLocation = TXTHOTELIMGPATH.Text.Trim
    End Sub

    Private Sub CMDHVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDHOTELVIEW.Click
        Try
            If GRIDHOTEL.SelectedRows.Count > 0 Then
                Dim objVIEW As New ViewImage
                objVIEW.pbsoftcopy.Image = PBHOTELSOFTCOPY.Image
                objVIEW.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDHREMOVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDHOTELREMOVE.Click
        Try
            PBHOTELSOFTCOPY.Image = Nothing
            TXTHOTELIMGPATH.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDHOTEL_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDHOTEL.RowEnter
        Try
            If e.RowIndex >= 0 Then PBHOTELSOFTCOPY.Image = GRIDHOTEL.Rows(e.RowIndex).Cells(GHOTELIMGPATH.Index).Value
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCOPY_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCOPY.KeyPress
        Try
            numkeypress(e, TXTCOPY, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCOPY_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTCOPY.Validated
        Try

            If edit = True Then
                MsgBox("Copy Allowed only in Fresh mode", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If TXTCOPY.Text.Trim <> "" Then
                TEMPMSG = MsgBox("Wish to Copy Itinerary No " & TXTCOPY.Text.Trim & "?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then

                    Dim ALPARAVAL As New ArrayList
                    Dim OBJITI As New ClsItineraryMaster

                    ALPARAVAL.Add(TXTCOPY.Text.Trim)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(YearId)
                    OBJITI.alParaval = ALPARAVAL

                    Dim dt As DataTable = OBJITI.SELECTITINERARY()

                    If dt.Rows.Count > 0 Then


                        PACKAGEFROM.Value = Convert.ToDateTime(dt.Rows(0).Item("FROMDATE")).Date
                        PACKAGETO.Value = Convert.ToDateTime(dt.Rows(0).Item("TODATE")).Date

                        TXTDISPLAYNAME.Text = Convert.ToString(dt.Rows(0).Item("DISPLAYNAME"))


                        TXTADULTRATE.Text = Format(Val(dt.Rows(0).Item("ADULTRATE")), "0.00")
                        TXTEXTRAADULTRATE.Text = Format(Val(dt.Rows(0).Item("EXTRAADULTRATE")), "0.00")
                        TXTCHILDBEDRATE.Text = Format(Val(dt.Rows(0).Item("CHILDBEDRATE")), "0.00")
                        TXTCHILDRATE.Text = Format(Val(dt.Rows(0).Item("CHILDRATE")), "0.00")
                        TXTCHILDBELOWAGE.Text = Format(Val(dt.Rows(0).Item("CHILDBELOWAGE")), "0.00")
                        TXTTOTALDAYS.Text = Format(Val(dt.Rows(0).Item("TOTALDAYS")), "0.00")

                        TXTPDFPATH.Text = Convert.ToString(dt.Rows(0).Item("PDFPATH"))

                        TXTINCLUSION.Text = Convert.ToString(dt.Rows(0).Item("INCLUSION"))
                        TXTEXCLUSION.Text = Convert.ToString(dt.Rows(0).Item("EXCLUSION"))
                        TXTTERMS.Text = Convert.ToString(dt.Rows(0).Item("TERMS"))
                        TXTREMARKS.Text = Convert.ToString(dt.Rows(0).Item("REMARKS"))

                        CMBQUOTE.Text = Convert.ToString(dt.Rows(0).Item("QUOTE"))
                        TXTLUMPSUMCOST.Text = Format(Val(dt.Rows(0).Item("LUMPSUM")), "0.00")

                        'TOUR GRID
                        Dim OBJCMN As New ClsCommon
                        Dim dt1 As DataTable
                        dt1 = OBJCMN.search(" ITINERARY_SRNO AS SRNO, ITINERARY_HEADER AS HEADER, ITINERARY_DETAILS AS DETAILS, ITINERARY_PHOTO AS IMGPATH ", "", " ITINERARYMASTER_DESC ", " AND ITINERARYMASTER_DESC.ITINERARY_NO = " & Val(TXTCOPY.Text.Trim) & " AND ITINERARY_CMPID = " & CmpId & " AND ITINERARY_YEARID = " & YearId & " ORDER BY ITINERARYMASTER_DESC.ITINERARY_SRNO ")
                        If dt1.Rows.Count > 0 Then
                            For Each ROW As DataRow In dt1.Rows
                                If IsDBNull(ROW("IMGPATH")) = False Then GRIDITINERARY.Rows.Add(Val(ROW("SRNO")), ROW("HEADER"), ROW("DETAILS"), Image.FromStream(New IO.MemoryStream(DirectCast(ROW("IMGPATH"), Byte())))) Else GRIDITINERARY.Rows.Add(Val(ROW("SRNO")), ROW("HEADER"), ROW("DETAILS"), Nothing)
                            Next
                        End If

                        PBSOFTCOPY.Image = Nothing

                        'HOTEL GRID
                        Dim OBJHOTEL As New ClsCommon
                        Dim DT2 As DataTable
                        DT2 = OBJHOTEL.search(" ISNULL(ITINERARYMASTER_HOTEL.ITINERARY_SRNO, 0) AS SRNO, ISNULL(CITYMASTER.city_name, '') AS CITY, ISNULL(HOTELMASTER.HOTEL_NAME, '') AS HOTELNAME, ISNULL(ROOMTYPEMASTER.ROOMTYPE_NAME, '') AS ROOMTYPE, ISNULL(ITINERARYMASTER_HOTEL.ITINERARY_NIGHTS, 0) AS NIGHTS, ITINERARY_HOTELPHOTO AS HOTELIMGPATH ", "", " ITINERARYMASTER_HOTEL INNER JOIN CITYMASTER ON ITINERARYMASTER_HOTEL.ITINERARY_CITYID = CITYMASTER.city_id INNER JOIN HOTELMASTER ON ITINERARYMASTER_HOTEL.ITINERARY_HOTELID = HOTELMASTER.HOTEL_ID INNER JOIN ROOMTYPEMASTER ON ITINERARYMASTER_HOTEL.ITINERARY_ROOMTYPEID = ROOMTYPEMASTER.ROOMTYPE_ID ", " AND ITINERARYMASTER_HOTEL.ITINERARY_NO = " & Val(TXTCOPY.Text.Trim) & " AND ITINERARYMASTER_HOTEL.ITINERARY_CMPID = " & CmpId & " AND ITINERARYMASTER_HOTEL.ITINERARY_YEARID = " & YearId & " ORDER BY ITINERARYMASTER_HOTEL.ITINERARY_SRNO ")
                        For Each DTR As DataRow In DT2.Rows
                            If IsDBNull(DTR("HOTELIMGPATH")) = False Then GRIDHOTEL.Rows.Add(Val(DTR("SRNO")), DTR("CITY"), DTR("HOTELNAME"), DTR("ROOMTYPE"), Val(DTR("NIGHTS")), Image.FromStream(New IO.MemoryStream(DirectCast(DTR("HOTELIMGPATH"), Byte())))) Else GRIDHOTEL.Rows.Add(Val(DTR("SRNO")), DTR("CITY"), DTR("HOTELNAME"), DTR("ROOMTYPE"), Val(DTR("NIGHTS")), Nothing)
                        Next

                        PBHOTELSOFTCOPY.Image = Nothing
                        CMBROOMTYPE.SelectedItem = Nothing

                        'GET AIRLINE DATA
                        dt = OBJCMN.search(" ISNULL(ITINERARY_NO, 0) AS GROUPDEPNO, ISNULL(ITINERARY_GRIDSRNO, 0) AS AIRSRNO, ISNULL(ITINERARY_SECTOR, '') AS SECTOR, ISNULL(ITINERARY_FLTNO, '') AS FLTNO, ISNULL(ITINERARY_TYPE, '') AS TYPE, ISNULL(ITINERARY_BASIC, 0) AS BASIC, ISNULL(ITINERARY_PSF, 0) AS PSF, ISNULL(ITINERARY_TAXES, 0) AS TAXES, ISNULL(ITINERARY_AMT, 0) AS AIRAMT ", "", "ITINERARYMASTER_AIRLINE", " AND ITINERARYMASTER_AIRLINE.ITINERARY_NO = " & Val(TXTCOPY.Text.Trim) & " AND ITINERARY_YEARID = " & YearId & " ORDER BY ITINERARYMASTER_AIRLINE.ITINERARY_GRIDSRNO")
                        If dt.Rows.Count > 0 Then
                            For Each DR As DataRow In dt.Rows
                                GRIDAIRLINE.Rows.Add(DR("AIRSRNO"), DR("SECTOR"), DR("FLTNO"), DR("TYPE"), Format(Val(DR("BASIC")), "0.00"), Format(Val(DR("PSF")), "0.00"), Format(Val(DR("TAXES")), "0.00"), Format(Val(DR("AIRAMT")), "0.00"))
                            Next
                            'total()
                        End If


                        'GET GRIDFLIGHT DATA
                        dt = OBJCMN.search(" ITINERARYMASTER_FLIGHTDESC.ITINERARY_GRIDSRNO AS GRIDSRNO, ITINERARYMASTER_FLIGHTDESC.ITINERARY_BOOKSRNO AS BOOKSRNO, ISNULL(FROMSECTORMASTER.SECTOR_NAME, '') AS FROMSEC, ISNULL(TOSECTORMASTER.SECTOR_NAME, '') AS TOSEC, ITINERARYMASTER_FLIGHTDESC.ITINERARY_FLIGHTNO AS FLIGHTNO, ITINERARYMASTER_FLIGHTDESC.ITINERARY_FLIGHTDATE AS FLIGHTDATE, ISNULL(ITINERARYMASTER_FLIGHTDESC.ITINERARY_ARRIVES, '') AS ARRIVES, CLASSMASTER.CLASS_NAME AS CLASS", "", " SECTORMASTER AS TOSECTORMASTER RIGHT OUTER JOIN ITINERARYMASTER_FLIGHTDESC LEFT OUTER JOIN CLASSMASTER ON ITINERARYMASTER_FLIGHTDESC.ITINERARY_YEARID = CLASSMASTER.CLASS_YEARID AND  ITINERARYMASTER_FLIGHTDESC.ITINERARY_CMPID = CLASSMASTER.CLASS_CMPID AND ITINERARYMASTER_FLIGHTDESC.ITINERARY_CLASSID = CLASSMASTER.CLASS_ID ON  TOSECTORMASTER.SECTOR_ID = ITINERARYMASTER_FLIGHTDESC.ITINERARY_TOID AND TOSECTORMASTER.SECTOR_CMPID = ITINERARYMASTER_FLIGHTDESC.ITINERARY_CMPID AND TOSECTORMASTER.SECTOR_YEARID = ITINERARYMASTER_FLIGHTDESC.ITINERARY_YEARID LEFT OUTER JOIN SECTORMASTER AS FROMSECTORMASTER ON ITINERARYMASTER_FLIGHTDESC.ITINERARY_FROMID = FROMSECTORMASTER.SECTOR_ID AND ITINERARYMASTER_FLIGHTDESC.ITINERARY_CMPID = FROMSECTORMASTER.SECTOR_CMPID AND ITINERARYMASTER_FLIGHTDESC.ITINERARY_YEARID = FROMSECTORMASTER.SECTOR_YEARID", " AND ITINERARYMASTER_FLIGHTDESC.ITINERARY_NO = " & Val(TXTCOPY.Text.Trim) & " AND ITINERARYMASTER_FLIGHTDESC.ITINERARY_CMPID = " & CmpId & " AND ITINERARYMASTER_FLIGHTDESC.ITINERARY_YEARID = " & YearId & " ORDER BY ITINERARYMASTER_FLIGHTDESC.ITINERARY_BOOKSRNO ASC, ITINERARYMASTER_FLIGHTDESC.ITINERARY_GRIDSRNO ASC")
                        If dt.Rows.Count > 0 Then
                            For Each DR As DataRow In dt.Rows
                                GRIDFLIGHT.Rows.Add(DR("GRIDSRNO").ToString, DR("BOOKSRNO"), DR("FROMSEC").ToString, DR("TOSEC").ToString, DR("FLIGHTNO").ToString, DR("FLIGHTDATE").ToString, DR("ARRIVES").ToString, DR("CLASS").ToString)
                            Next
                            'total()
                        End If

                        'VEHICLE GRID
                        Dim OBJVEHICLE As New ClsCommon
                        Dim DT3 As DataTable
                        DT3 = OBJVEHICLE.search(" ISNULL(ITINERARYMASTER_VEHICLE.ITINERARY_SRNO, 0) AS SRNO, ISNULL(VEHICLEMASTER.VEHICLE_NAME, '') AS VEHICLENAME, ISNULL(ITINERARYMASTER_VEHICLE.ITINERARY_DESCRIPTION, '') AS DESCRIPTION, ISNULL(ITINERARYMASTER_VEHICLE.ITINERARY_DAYS, 0) AS VEHICLEDAYS ", "", " ITINERARYMASTER_VEHICLE INNER JOIN VEHICLEMASTER ON ITINERARYMASTER_VEHICLE.ITINERARY_VEHICLEID = VEHICLEMASTER.VEHICLE_ID ", "AND ITINERARYMASTER_VEHICLE.ITINERARY_NO = " & Val(TXTCOPY.Text.Trim) & " AND ITINERARYMASTER_VEHICLE.ITINERARY_CMPID = " & CmpId & " AND ITINERARYMASTER_VEHICLE.ITINERARY_YEARID = " & YearId & " ORDER BY ITINERARYMASTER_VEHICLE.ITINERARY_SRNO ")
                        If DT3.Rows.Count > 0 Then
                            For Each DTV As DataRow In DT3.Rows
                                GRIDVEHICLE.Rows.Add(Val(DTV("SRNO")), DTV("VEHICLENAME"), DTV("DESCRIPTION"), Val(DTV("VEHICLEDAYS")))
                            Next
                        End If

                        'MISC GRID
                        Dim OBJMISC As New ClsCommon
                        Dim DT4 As DataTable
                        DT4 = OBJMISC.search(" ISNULL(ITINERARYMASTER_MISC.ITINERARY_SRNO, 0) AS SRNO, ISNULL(ITINERARYMASTER_MISC.ITINERARY_TYPE, '') AS SERVICETYPE, ISNULL(ITINERARYMASTER_MISC.ITINERARY_REMARKS, '') AS MISCREMARKS ", "", " ITINERARYMASTER_MISC INNER JOIN ITINERARYMASTER ON ITINERARYMASTER_MISC.ITINERARY_NO = ITINERARYMASTER.ITINERARY_NO ", "AND ITINERARYMASTER_MISC.ITINERARY_NO = " & Val(TXTCOPY.Text.Trim) & " AND ITINERARYMASTER_MISC.ITINERARY_CMPID = " & CmpId & " AND ITINERARYMASTER_MISC.ITINERARY_YEARID = " & YearId & " ORDER BY ITINERARYMASTER_MISC.ITINERARY_SRNO ")
                        If DT4.Rows.Count > 0 Then
                            For Each DTM As DataRow In DT4.Rows
                                GRIDMISC.Rows.Add(Val(DTM("SRNO")), DTM("SERVICETYPE"), DTM("MISCREMARKS"))
                            Next
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDMISC_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDMISC.CellDoubleClick
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

    Private Sub TXTSECTOR_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTSECTOR.Validated
        If TXTSECTOR.Text <> "" And TXTSECTOR.Text <> "   /   /   /   /   /" Then
            'GET LATEST SRNO
            If GRIDAIRDOUBLECLICK = False Then
                If GRIDAIRLINE.RowCount > 0 Then TXTAIRSRNO.Text = Val(GRIDAIRLINE.Rows(GRIDAIRLINE.RowCount - 1).Cells(GSECSRNO.Index).Value) + 1 Else TXTAIRSRNO.Text = 1
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

    Sub CALC()
        Try
            TXTAIRAMT.Text = Format((Val(TXTBASIC.Text.Trim) + Val(TXTPSF.Text.Trim) + Val(TXTGRIDTAX.Text.Trim)), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub CMDCLOSE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLOSE.Click
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

    Private Sub CMBCANCEL_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBCANCEL.Enter
        Try
            If CMBCANCEL.Text.Trim = "" Then FILLPOLICY(CMBCANCEL, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNOTES_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBNOTES.Enter
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
                TXTREMARKS.Clear()
                Dim DT As DataTable = OBJCMN.search(" NOTE_REMARKS AS NOTE", "", " NOTEMASTER", " AND NOTE_NAME ='" & CMBNOTES.Text.Trim & "' AND NOTE_CMPID = " & CmpId & " AND NOTE_LOCATIONID = " & Locationid & " AND NOTE_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then TXTREMARKS.Text = DT.Rows(0).Item("NOTE")
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

    Private Sub CMBCANCEL_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCANCEL.Validated
        Try
            If CMBCANCEL.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                TXTTERMS.Clear()
                Dim DT As DataTable = OBJCMN.search(" POLICY_REMARKS AS POLICY", "", " POLICYMASTER", " AND POLICY_NAME ='" & CMBCANCEL.Text.Trim & "' AND POLICY_CMPID = " & CmpId & " AND POLICY_LOCATIONID = " & Locationid & " AND POLICY_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then TXTTERMS.Text = DT.Rows(0).Item("POLICY")
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

    Private Sub CMBCITY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCITY.Validating
        Try
            If CMBCITY.Text.Trim <> "" Then
                pcase(CMBCITY)
                Dim objclscommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objclscommon.search("city_name", "", "CityMaster", " and city_name = '" & CMBCITY.Text.Trim & "' and city_cmpid = " & CmpId & " and city_Locationid = " & Locationid & " and city_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBCITY.Text.Trim
                    Dim tempmsg As Integer = MsgBox("City not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                        If DTROW(0).Item(1) = False Then
                            MsgBox("Insufficient Rights")
                            Exit Sub
                        End If
                        CMBCITY.Text = a
                        objyearmaster.savecity(CMBCITY.Text.Trim, CmpId, Locationid, Userid, YearId, " and city_name = '" & CMBCITY.Text.Trim & "' and city_cmpid = " & CmpId & " and city_Locationid = " & Locationid & " and city_Yearid = " & YearId)
                        Dim dt1 As New DataTable
                        dt1 = CMBCITY.DataSource
                        If CMBCITY.DataSource <> Nothing Then
line1:
                            If dt1.Rows.Count > 0 Then
                                dt1.Rows.Add(CMBCITY.Text)
                                CMBCITY.Text = a
                            End If
                        End If
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        End Try
    End Sub

    Private Sub ItineraryMaster_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "MATRIX" Then Me.Close()
        If ClientName = "VIHAR" Then TXTDISPLAYNAME.CharacterCasing = CharacterCasing.Normal
    End Sub

    Private Sub CMBINCLUSION_Validated(sender As Object, e As EventArgs) Handles CMBINCLUSION.Validated
        Try
            If CMBINCLUSION.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                TXTINCLUSION.Clear()
                Dim DT As DataTable = OBJCMN.search(" INCLUSION_REMARKS AS INCLUSION", "", " INCLUSIONMASTER ", " AND INCLUSION_NAME ='" & CMBINCLUSION.Text.Trim & "' AND INCLUSION_CMPID = " & CmpId & " AND INCLUSION_LOCATIONID = " & Locationid & " AND INCLUSION_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then TXTINCLUSION.Text = DT.Rows(0).Item("INCLUSION")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBEXCLUSION_Validated(sender As Object, e As EventArgs) Handles CMBEXCLUSION.Validated
        Try
            If CMBEXCLUSION.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                TXTEXCLUSION.Clear()
                Dim DT As DataTable = OBJCMN.search(" EXCLUSION_REMARKS AS EXCLUSION", "", " EXCLUSIONMASTER ", " AND EXCLUSION_NAME ='" & CMBEXCLUSION.Text.Trim & "' AND EXCLUSION_CMPID = " & CmpId & " AND EXCLUSION_LOCATIONID = " & Locationid & " AND EXCLUSION_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then TXTEXCLUSION.Text = DT.Rows(0).Item("EXCLUSION")
            End If
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

    Private Sub CMBINCLUSION_Validating(sender As Object, e As CancelEventArgs) Handles CMBINCLUSION.Validating
        Try
            If CMBINCLUSION.Text.Trim <> "" Then INCLUSIONVALIDATE(CMBINCLUSION, e, Me)
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

    Private Sub CMBINCLUSION_Enter(sender As Object, e As EventArgs) Handles CMBINCLUSION.Enter
        Try
            If CMBINCLUSION.Text.Trim = "" Then FILLINCLUSION(CMBINCLUSION, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class