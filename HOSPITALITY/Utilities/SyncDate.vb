
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.IO
Imports BL
Imports System.Xml
Imports System.Web
Imports System.Xml.XPath
Imports System.Net


Public Class SyncDate

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Sub SKYMAPSHOTELSYNC()
        Try

            Dim URL As New Uri("https://mapstriponline.com/api/hotel-master-api.php")

            ServicePointManager.Expect100Continue = True
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

            Dim REQUEST As WebRequest = WebRequest.CreateDefault(URL)
            Dim RESPONSE As WebResponse = REQUEST.GetResponse()
            Dim READER As StreamReader = New StreamReader(RESPONSE.GetResponseStream())
            Dim REQUESTEDTEXT As String = READER.ReadToEnd()

            REQUESTEDTEXT = REQUESTEDTEXT.Replace("'", "")
            REQUESTEDTEXT = REQUESTEDTEXT.Replace("""", "")

            Dim HOTELNAME As String = ""
            Dim ADDRESS1 As String = ""
            Dim CITYNAME As String = ""
            Dim CONTACTNO As String = ""

            Dim STARTPOS As Integer = 0
            Dim ENDPOS As Integer = 0

            'COPY DATA IN NOTEPAD FILE
            Dim objWriter As System.IO.StreamWriter = File.CreateText(Application.StartupPath & "\MAPSHOTELDATA.TXT")
            objWriter.Write(REQUESTEDTEXT)
            objWriter.Dispose()

SEARCHNEXTHOTEL:

            'FETCH DATA FROM NOTEPAD FILE
            'HOTELNAME
            STARTPOS = REQUESTEDTEXT.IndexOf("<HotelName>", ENDPOS) + 11
            If STARTPOS < ENDPOS Then Exit Sub
            ENDPOS = REQUESTEDTEXT.IndexOf("</HotelName>", STARTPOS)
            HOTELNAME = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)


            'WE NEED TO CHECK WHETHER THIS HOTEL IS PRESENT OR NOT
            'IF PRESENT THEN GO FOR NEXT HOTEL
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("HOTEL_NAME AS HOTELNAME", "", "HOTELMASTER ", " AND HOTEL_NAME = '" & HOTELNAME & "' AND HOTEL_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then GoTo SEARCHNEXTHOTEL


            'ADDRESS1
            STARTPOS = REQUESTEDTEXT.IndexOf("<Address1>", ENDPOS) + 10
            ENDPOS = REQUESTEDTEXT.IndexOf("</Address1>", STARTPOS)
            ADDRESS1 = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)


            'CITYNAME
            STARTPOS = REQUESTEDTEXT.IndexOf("<CityName>", ENDPOS) + 10
            ENDPOS = REQUESTEDTEXT.IndexOf("</CityName>", STARTPOS)
            CITYNAME = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)

            'CHECK WHETHER CITY IS PRESENT OR NOT
            'IF NOT THEN ADD NEW
            DT = OBJCMN.search("CITY_NAME AS CITYNAME", "", " CITYMASTER ", " AND CITY_NAME = '" & CITYNAME & "' AND CITY_YEARID = " & YearId)
            If DT.Rows.Count = 0 Then
                Dim OBJYEAR As New ClsYearMaster
                OBJYEAR.savecity(CITYNAME, CmpId, 0, Userid, YearId, " and city_name = '" & CITYNAME & "' and city_yearid = " & YearId)
            End If


            'CONTACTNO
            STARTPOS = REQUESTEDTEXT.IndexOf("<ContactNo>", ENDPOS) + 11
            ENDPOS = REQUESTEDTEXT.IndexOf("</ContactNo>", STARTPOS)
            CONTACTNO = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)


            'IF HOTELNAME IS NOT PRESENT THEN ADD NEW HOTEL
            Dim alParaval As New ArrayList

            alParaval.Add(HOTELNAME.Trim)
            alParaval.Add("")       'HOTELTYPE
            alParaval.Add("")       'CONTACTNAME
            alParaval.Add(HOTELNAME.Trim)  'HOTELCODE
            alParaval.Add("")       'GRADE
            alParaval.Add("")       'GROUP
            alParaval.Add("14:00")  'CHECKIN
            alParaval.Add("12:00")  'CHECKOUT
            alParaval.Add(ADDRESS1.Trim)
            alParaval.Add(ADDRESS1.Trim)
            alParaval.Add("")       'ADD2
            alParaval.Add("")       'AREA
            alParaval.Add("")       'STD
            alParaval.Add(CITYNAME.Trim)
            alParaval.Add("")       'PINCODE
            alParaval.Add("")       'STATE
            alParaval.Add("")       'COUNTRY
            alParaval.Add("")       'ALTNO
            alParaval.Add(CONTACTNO.Trim)
            alParaval.Add("")       'MOBILENO
            alParaval.Add("")       'FAX
            alParaval.Add("")       'WEBSITE
            alParaval.Add("")       'EMAIL
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)        'TRANSFER


            alParaval.Add("")       'AMENITIES
            alParaval.Add("1")      'GRIDSRNO
            alParaval.Add("STANDARD")
            alParaval.Add("1")      'NOOFROOMS
            alParaval.Add("0")      'RATE
            alParaval.Add("")       'IMGPATH
            alParaval.Add("")       'NEWIMGPATH

            alParaval.Add("")       'CNAME
            alParaval.Add("")       'DESIGNATION
            alParaval.Add("")       'CMOB
            alParaval.Add("")       'CEMAIL
            alParaval.Add(0)        'INVENTORY    


            Dim OBJHOTEL As New ClsHotelMaster
            OBJHOTEL.alParaval = alParaval
            Dim IntResult As Integer = OBJHOTEL.save()

            GoTo SEARCHNEXTHOTEL

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SKYMAPSBOOKINGSYNC()
        Try

            Dim URL As New Uri("https://mapstriponline.com/cadmus/export-hotel.php?start=" & CInt(FROMDATE.Value.Date.Subtract(CDate("1.1.1970 00:00:00")).TotalSeconds) & "&end=" & CInt(TODATE.Value.Date.Subtract(CDate("1.1.1970 00:00:00")).TotalSeconds) & "&key=UHJ34RIHGY")

            ServicePointManager.Expect100Continue = True
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

            Dim REQUEST As WebRequest = WebRequest.CreateDefault(URL)
            Dim RESPONSE As WebResponse = REQUEST.GetResponse()
            Dim READER As StreamReader = New StreamReader(RESPONSE.GetResponseStream())
            Dim REQUESTEDTEXT As String = READER.ReadToEnd()

            REQUESTEDTEXT = REQUESTEDTEXT.Replace("'", "")
            REQUESTEDTEXT = REQUESTEDTEXT.Replace("""", "")


            Dim BOOKINGNO As Integer = 0
            Dim BOOKINGDATE As Date = Mydate
            Dim GUESTNAME As String = ""
            Dim GUESTMOBILENO As String = ""
            Dim HOTELNAME As String = ""
            Dim SALENAME As String = ""
            Dim SALESTATENAME As String = ""
            Dim PURCHASENAME As String = ""
            Dim PURCHASERATE As Double = 0
            Dim REFNO As String = ""
            Dim CHECKIN As Date = Mydate
            Dim CHECKOUT As Date = Mydate
            Dim SALESACCODE As String = ""
            Dim PURSACCODE As String = ""
            Dim ROOMCATEGORY As String = ""
            Dim MEALPLAN As String = ""
            Dim ADULTS As Integer = 0
            Dim INFANTS As Integer = 0
            Dim EXTRAADULTS As Integer = 0
            Dim EXTRAADULTSRATE As Double = 0
            Dim EXTRACHILD As Integer = 0
            Dim EXTRACHILDRATE As Double = 0
            Dim NOOFROOMS As Integer = 0
            Dim RATE As Double = 0
            Dim PACKAGE As String = ""
            Dim AMOUNT As Double = 0
            Dim DISCOUNT As Double = 0
            Dim SERVCHGS As Double = 0
            Dim SOURCE As String = ""
            Dim REMARKS As String = ""



            Dim STARTPOS As Integer = 0
            Dim ENDPOS As Integer = 0

            'COPY DATA IN NOTEPAD FILE
            Dim objWriter As System.IO.StreamWriter = File.CreateText(Application.StartupPath & "\MAPSHOTELDATA.TXT")
            objWriter.Write(REQUESTEDTEXT)
            objWriter.Dispose()

SEARCHNEXTBOOKING:

            'FETCH DATA FROM NOTEPAD FILE
            'BOOKING NO
            STARTPOS = REQUESTEDTEXT.IndexOf("<BookingNo>", ENDPOS) + 11
            If STARTPOS < ENDPOS Or STARTPOS = 0 Then Exit Sub
            ENDPOS = REQUESTEDTEXT.IndexOf("</BookingNo>", STARTPOS)
            BOOKINGNO = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)

            'WE NEED TO CHECK WHETHER THIS BOOKINGNO IS PRESENT OR NOT
            'IF PRESENT THEN GO FOR NEXT BOOKING
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("BOOKING_NO AS BOOKINGNO", "", "HOTELBOOKINGMASTER ", " AND BOOKING_NO = " & Val(BOOKINGNO) & " AND BOOKING_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then GoTo SEARCHNEXTBOOKING


            STARTPOS = REQUESTEDTEXT.IndexOf("<BookingDate>", ENDPOS) + 13
            ENDPOS = REQUESTEDTEXT.IndexOf("</BookingDate>", STARTPOS)
            BOOKINGDATE = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)


            STARTPOS = REQUESTEDTEXT.IndexOf("<GuestName>", ENDPOS) + 11
            ENDPOS = REQUESTEDTEXT.IndexOf("</GuestName>", STARTPOS)
            GUESTNAME = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)


            STARTPOS = REQUESTEDTEXT.IndexOf("<GuestMobileNo>", ENDPOS) + 15
            ENDPOS = REQUESTEDTEXT.IndexOf("</GuestMobileNo>", STARTPOS)
            GUESTMOBILENO = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)


            'CHECK WHETHER GUESTNAME IS PRESENT OR NOT
            'IF NOT THEN ADD GUESTNAME 
            DT = OBJCMN.search("GUEST_NAME AS GUESTNAME", "", " GUESTMASTER ", " AND GUEST_NAME = '" & GUESTNAME.Trim & "' AND GUEST_YEARID = " & YearId)
            If DT.Rows.Count = 0 Then ADDGUESTNAME(GUESTNAME.Trim, GUESTMOBILENO)


            STARTPOS = REQUESTEDTEXT.IndexOf("<HotelName>", ENDPOS) + 11
            ENDPOS = REQUESTEDTEXT.IndexOf("</HotelName>", STARTPOS)
            HOTELNAME = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)


            'WE NEED TO CHECK WHETHER THIS HOTEL IS PRESENT OR NOT
            'IF PRESENT THEN GO FOR NEXT HOTEL
            DT = OBJCMN.search("HOTEL_NAME AS HOTELNAME", "", "HOTELMASTER ", " AND HOTEL_NAME = '" & HOTELNAME.Trim & "' AND HOTEL_YEARID = " & YearId)
            If DT.Rows.Count = 0 Then
                MsgBox("Booking No " & BOOKINGNO & " cannot be added as " & HOTELNAME & " is not Present in Hotel Master ")
                GoTo SEARCHNEXTBOOKING
            End If


            STARTPOS = REQUESTEDTEXT.IndexOf("<SaleName>", ENDPOS) + 10
            ENDPOS = REQUESTEDTEXT.IndexOf("</SaleName>", STARTPOS)
            SALENAME = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)


            'SALE NAME WILL BE ADDED AFTER WE FETCH SALESTATENAME



            STARTPOS = REQUESTEDTEXT.IndexOf("<PurchaseName>", ENDPOS) + 14
            ENDPOS = REQUESTEDTEXT.IndexOf("</PurchaseName>", STARTPOS)
            PURCHASENAME = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)

            'CHECK WHETHER PURCHASENAME IS PRESENT OR NOT
            'IF NOT THEN ADD PURCHASENAME
            'WE DONT KNOW TH STATE OF PURCHASER SO WE ARE PASSING BLANK
            DT = OBJCMN.search("ACC_CMPNAME AS NAME", "", " LEDGERS ", " AND ACC_CMPNAME = '" & PURCHASENAME.Trim & "' AND ACC_YEARID = " & YearId)
            If DT.Rows.Count = 0 Then ADDLEDGERS(PURCHASENAME.Trim, "Sundry Creditors", "")


            STARTPOS = REQUESTEDTEXT.IndexOf("<PurchaseRate>", ENDPOS) + 14
            ENDPOS = REQUESTEDTEXT.IndexOf("</PurchaseRate>", STARTPOS)
            PURCHASERATE = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)


            STARTPOS = REQUESTEDTEXT.IndexOf("<ReferenceNo>", ENDPOS) + 13
            ENDPOS = REQUESTEDTEXT.IndexOf("</ReferenceNo>", STARTPOS)
            REFNO = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)


            STARTPOS = REQUESTEDTEXT.IndexOf("<CheckInDate>", ENDPOS) + 13
            ENDPOS = REQUESTEDTEXT.IndexOf("</CheckInDate>", STARTPOS)
            CHECKIN = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)


            STARTPOS = REQUESTEDTEXT.IndexOf("<CheckOutDate>", ENDPOS) + 14
            ENDPOS = REQUESTEDTEXT.IndexOf("</CheckOutDate>", STARTPOS)
            CHECKOUT = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)


            'WE DONT NEED SACDESC
            'SO WE DIRECTLY FETCHED SACCODE
            STARTPOS = REQUESTEDTEXT.IndexOf("<SaleSACCode>", ENDPOS) + 13
            ENDPOS = REQUESTEDTEXT.IndexOf("</SaleSACCode>", STARTPOS)
            SALESACCODE = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)


            STARTPOS = REQUESTEDTEXT.IndexOf("<SaleState>", ENDPOS) + 11
            ENDPOS = REQUESTEDTEXT.IndexOf("</SaleState>", STARTPOS)
            SALESTATENAME = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)


            'WE WILL ADD LEDGERS AFTER SALESTATENAME
            'CHECK WHETHER SALENAME IS PRESENT OR NOT
            'IF NOT THEN ADD SALENAME
            DT = OBJCMN.search("ACC_CMPNAME AS NAME", "", " LEDGERS ", " AND ACC_CMPNAME = '" & SALENAME.Trim & "' AND ACC_YEARID = " & YearId)
            If DT.Rows.Count = 0 Then ADDLEDGERS(SALENAME.Trim, "Sundry Debtors", SALESTATENAME.Trim)



            STARTPOS = REQUESTEDTEXT.IndexOf("<PurchaseSACCode>", ENDPOS) + 17
            ENDPOS = REQUESTEDTEXT.IndexOf("</PurchaseSACCode>", STARTPOS)
            PURSACCODE = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)


            'HERE WE HAVE TO ADD THIS 2 TIMES
            STARTPOS = REQUESTEDTEXT.IndexOf("<RoomCategory>", ENDPOS) + 14
            STARTPOS = REQUESTEDTEXT.IndexOf("<RoomCategory>", STARTPOS) + 14
            ENDPOS = REQUESTEDTEXT.IndexOf("</RoomCategory>", STARTPOS)
            ROOMCATEGORY = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)


            'CHECK WHETHER ROOM CATEGORY IS ADDED IN THE HOTEL OR NOT
            'IF NOT THEN ADD ROOMCATEGORY IN HOTEL_ROOMDESC
            DT = OBJCMN.search("ROOMTYPE_NAME AS ROOMTYPENAME", "", " ROOMTYPEMASTER ", " AND ROOMTYPE_NAME = '" & ROOMCATEGORY.Trim & "' AND ROOMTYPE_YEARID = " & YearId)
            If DT.Rows.Count = 0 Then ADDROOM(ROOMCATEGORY.Trim, HOTELNAME.Trim)

            DT = OBJCMN.search("HOTELMASTER.HOTEL_ID AS HOTELID", "", " HOTELMASTER_ROOMDESC INNER JOIN ROOMTYPEMASTER ON HOTEL_ROOMTYPEID = ROOMTYPE_ID INNER JOIN HOTELMASTER ON HOTELMASTER.HOTEL_ID = HOTELMASTER_ROOMDESC.HOTEL_ID ", " AND ROOMTYPE_NAME = '" & ROOMCATEGORY.Trim & "' AND HOTELMASTER.HOTEL_NAME = '" & HOTELNAME.Trim & "' AND HOTELMASTER.HOTEL_YEARID = " & YearId)
            If DT.Rows.Count = 0 Then ADDROOM(ROOMCATEGORY.Trim, HOTELNAME.Trim)


            'SKIP RATE PER ROOM HERE, COZ WE ARE CAPTURING THAT IN NEXT STATEMENT


            STARTPOS = REQUESTEDTEXT.IndexOf("<MealPlan>", ENDPOS) + 10
            ENDPOS = REQUESTEDTEXT.IndexOf("</MealPlan>", STARTPOS)
            MEALPLAN = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)


            'CHECK WHETHER MEALPLAN IS ADDED OR NOT
            'IF NOT THEN ADD MEALPLAN
            DT = OBJCMN.search("PLAN_NAME AS PLANNAME", "", " PLANMASTER ", " AND PLAN_NAME = '" & MEALPLAN.Trim & "' AND PLAN_YEARID = " & YearId)
            If DT.Rows.Count = 0 Then ADDMEALPLAN(MEALPLAN.Trim)


            STARTPOS = REQUESTEDTEXT.IndexOf("<Adults>", ENDPOS) + 8
            ENDPOS = REQUESTEDTEXT.IndexOf("</Adults>", STARTPOS)
            ADULTS = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)


            STARTPOS = REQUESTEDTEXT.IndexOf("<Infants>", ENDPOS) + 9
            ENDPOS = REQUESTEDTEXT.IndexOf("</Infants>", STARTPOS)
            INFANTS = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)


            STARTPOS = REQUESTEDTEXT.IndexOf("<ExtraAdults>", ENDPOS) + 13
            ENDPOS = REQUESTEDTEXT.IndexOf("</ExtraAdults>", STARTPOS)
            If STARTPOS <> ENDPOS Then EXTRAADULTS = Val(REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS))


            STARTPOS = REQUESTEDTEXT.IndexOf("<ExtraAdultsRate>", ENDPOS) + 17
            ENDPOS = REQUESTEDTEXT.IndexOf("</ExtraAdultsRate>", STARTPOS)
            EXTRAADULTSRATE = Val(REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS))


            STARTPOS = REQUESTEDTEXT.IndexOf("<ExtraChild>", ENDPOS) + 12
            ENDPOS = REQUESTEDTEXT.IndexOf("</ExtraChild>", STARTPOS)
            EXTRACHILD = Val(REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS))


            STARTPOS = REQUESTEDTEXT.IndexOf("<ExtraChildRate>", ENDPOS) + 16
            ENDPOS = REQUESTEDTEXT.IndexOf("</ExtraChildRate>", STARTPOS)
            EXTRACHILDRATE = Val(REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS))


            STARTPOS = REQUESTEDTEXT.IndexOf("<NoOfRooms>", ENDPOS) + 11
            ENDPOS = REQUESTEDTEXT.IndexOf("</NoOfRooms>", STARTPOS)
            NOOFROOMS = Val(REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS))


            STARTPOS = REQUESTEDTEXT.IndexOf("<RatePerRoom>", ENDPOS) + 13
            ENDPOS = REQUESTEDTEXT.IndexOf("</RatePerRoom>", STARTPOS)
            RATE = Val(REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS))


            STARTPOS = REQUESTEDTEXT.IndexOf("<Package>", ENDPOS) + 9
            ENDPOS = REQUESTEDTEXT.IndexOf("</Package>", STARTPOS)
            PACKAGE = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)


            STARTPOS = REQUESTEDTEXT.IndexOf("<Amount>", ENDPOS) + 8
            ENDPOS = REQUESTEDTEXT.IndexOf("</Amount>", STARTPOS)
            AMOUNT = Val(REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS))


            STARTPOS = REQUESTEDTEXT.IndexOf("<Discount>", ENDPOS) + 10
            ENDPOS = REQUESTEDTEXT.IndexOf("</Discount>", STARTPOS)
            DISCOUNT = Val(REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS))


            STARTPOS = REQUESTEDTEXT.IndexOf("<ServiceChgs>", ENDPOS) + 13
            ENDPOS = REQUESTEDTEXT.IndexOf("</ServiceChgs>", STARTPOS)
            SERVCHGS = Val(REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS))


            STARTPOS = REQUESTEDTEXT.IndexOf("<Source>", ENDPOS) + 8
            ENDPOS = REQUESTEDTEXT.IndexOf("</Source>", STARTPOS)
            SOURCE = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)


            'CHECK WHETHER SOURCE IS ADDED OR NOT
            'IF NOT THEN ADD SOURCE
            DT = OBJCMN.search("SOURCE_NAME AS SOURCENAME", "", " SOURCEMASTER ", " AND SOURCE_NAME = '" & SOURCE.Trim & "' AND SOURCE_YEARID = " & YearId)
            If DT.Rows.Count = 0 Then ADDSOURCE(SOURCE.Trim)



            STARTPOS = REQUESTEDTEXT.IndexOf("<Remarks>", ENDPOS) + 9
            ENDPOS = REQUESTEDTEXT.IndexOf("</Remarks>", STARTPOS)
            REMARKS = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)



            Dim alParaval As New ArrayList

            alParaval.Add("BOOKING")
            alParaval.Add("PURCHASE REGISTER")
            alParaval.Add("SALE REGISTER")
            alParaval.Add(BOOKINGNO)
            alParaval.Add(BOOKINGDATE.Date)
            alParaval.Add(1)        'CHKDATE
            alParaval.Add("F.I.T.")
            alParaval.Add(GUESTNAME.Trim)
            alParaval.Add("")       'GUESTADD
            alParaval.Add(HOTELNAME.Trim)
            alParaval.Add(PURCHASENAME.Trim)
            alParaval.Add(SALENAME.Trim)

            alParaval.Add(CHECKIN.Date)
            alParaval.Add(CHECKOUT.Date)
            alParaval.Add("")       'ARRIVALFROM
            alParaval.Add("")       'DEPARTTO
            alParaval.Add("14:00")  'CHECKINTIME
            alParaval.Add("12:00")  'CHECKOUTTIME
            alParaval.Add("")       'ARR FLT NO
            alParaval.Add("")       'DEP FLT NO

            alParaval.Add(Val(ADULTS))
            alParaval.Add(Val(0))
            alParaval.Add(Val(INFANTS))
            alParaval.Add(Val(EXTRAADULTS))
            alParaval.Add(Val(EXTRACHILD))
            alParaval.Add(Val(NOOFROOMS))
            alParaval.Add(Val(RATE))    'TOTALAMT


            'PURCHASE VALUES
            alParaval.Add(Val(PURCHASERATE))       'PUR AMT

            'ADD PURCHASE AMT + EXTRAADULT AMT + EXTRACHILD AMT + PUREXTRACHGS
            alParaval.Add(Val(0))
            alParaval.Add(Val(0))   'DISPER
            alParaval.Add(Val(0))   'PURDISC
            alParaval.Add(Val(PURCHASERATE))   'PURSUBTOTAL
            alParaval.Add(Val(0))   'COMMRECDPER
            alParaval.Add(Val(0))   'COMMRECD
            alParaval.Add(Val(0))   'PURTDSPER
            alParaval.Add(Val(0))   'PURTDSAMT
            alParaval.Add(Val(0))   'PUREXTRACHGS
            alParaval.Add(Val(PURCHASERATE))   'PURNETTAMT
            alParaval.Add("")       'PURTAX
            alParaval.Add(Val(0))   'PURTAXAMT
            alParaval.Add("")       'PURADDTAX
            alParaval.Add(Val(0))   'PURADDTAXAMT

            alParaval.Add("")       'PUROTHERCHGS
            alParaval.Add(0)        'PUROTHERCHGSAMT


            alParaval.Add(Val(0))   'PURROUNDOFF
            alParaval.Add(Val(PURCHASERATE))   'PURGRANDTOTAL

            alParaval.Add(Val(ADULTS + EXTRAADULTS + EXTRACHILD + INFANTS))   'TOTALPAX
            alParaval.Add(Val(CHECKOUT.Date.Subtract(CHECKIN.Date).Days))    'NIGHTS
            alParaval.Add("Admin")  'BOOKEDBY

            alParaval.Add(SOURCE)
            alParaval.Add("")       'AGENTNAME AND DETAILS
            alParaval.Add(Val(0))
            alParaval.Add(Val(0))
            alParaval.Add(Val(0))
            alParaval.Add(Val(0))


            'WE HAVE KEPT THIS CODE COZ WE NEED TO CALCULATE GST AND THEN ADD IN GRANDTOTAL HERE
            'WITH RESPECT TO SALESACCODE FETCH GSTRATES
            'WE DONT HAVE STATE OF THE LEDGERS SO ALWAYD CGST AND SGST
            Dim CGSTPER As Double = 0
            Dim CGSTAMT As Double = 0
            Dim SGSTPER As Double = 0
            Dim SGSTAMT As Double = 0
            Dim IGSTPER As Double = 0
            Dim IGSTAMT As Double = 0
            Dim SUBTOTAL As Double = RATE + SERVCHGS - DISCOUNT

            DT = OBJCMN.search("HSN_CGST AS CGSTPER, HSN_SGST AS SGSTPER, HSN_IGST AS IGSTPER", "", "HSNMASTER", " AND HSN_CODE = '" & SALESACCODE & "' AND HSN_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then

                'CHECK WHETHER LEDGERS IS WITHIN THE CMP STATE OR NOT
                Dim DTLEDGER As DataTable = OBJCMN.search("ISNULL(CAST(STATE_REMARK AS VARCHAR(20)),'') AS STATECODE", "", "LEDGERS LEFT OUTER JOIN STATEMASTER ON LEDGERS.ACC_STATEID = STATE_ID", " AND LEDGERS.ACC_CMPNAME ='" & SALENAME & "' AND LEDGERS.ACC_YEARID = " & YearId)
                If DTLEDGER.Rows.Count > 0 AndAlso DTLEDGER.Rows(0).Item(0) = CMPSTATECODE Then
                    CGSTPER = Val(DT.Rows(0).Item("CGSTPER"))
                    CGSTAMT = Val(Format((DT.Rows(0).Item("CGSTPER") * SERVCHGS) / 100, "0.00"))
                    SGSTPER = Val(DT.Rows(0).Item("SGSTPER"))
                    SGSTAMT = Val(Format((DT.Rows(0).Item("SGSTPER") * SERVCHGS) / 100, "0.00"))
                Else
                    IGSTPER = Val(DT.Rows(0).Item("IGSTPER"))
                    IGSTAMT = Val(Format((DT.Rows(0).Item("IGSTPER") * SERVCHGS) / 100, "0.00"))
                End If
            End If




            'SALE VALUES
            alParaval.Add(Val(RATE))    'TOTALAMT
            alParaval.Add(Val(0))       'COMMPER
            alParaval.Add(Val(SERVCHGS)) 'COMMRS
            alParaval.Add(Val(0))       'DISCPER
            alParaval.Add(Val(DISCOUNT))
            alParaval.Add(Val(0))       'EXTRACHGS
            alParaval.Add(Val(SUBTOTAL))    'SUBTOTAL
            alParaval.Add("")           'TAX
            alParaval.Add(Val(0))       'TAXAMT
            alParaval.Add("")           'ADDTAX
            alParaval.Add(Val(0))       'ADDTAXAMT

            alParaval.Add(1)            'CHKSERVCHGS
            alParaval.Add("")           'OTHERCHGSNAME
            alParaval.Add(0)            'OTHERCHGS


            Dim GRANDTOTAL As Double = Format(Val(SUBTOTAL + CGSTAMT + SGSTAMT + IGSTAMT), "0")
            alParaval.Add(Format(Val(GRANDTOTAL) - (Val(SUBTOTAL) + Val(CGSTAMT) + Val(SGSTAMT) + Val(IGSTAMT)), "0.00"))       'ROUNDOFF
            alParaval.Add(Val(GRANDTOTAL))    'GRANDTOTAL

            alParaval.Add(REMARKS)


            alParaval.Add("")           'BOOKINGDESC
            alParaval.Add("")           'SPECIALREMARKS
            alParaval.Add("")           'PICKUP
            alParaval.Add(CurrencyToWord(GRANDTOTAL))

            alParaval.Add(Val(0))       'DP

            alParaval.Add(Val(0))       'PURAMTPAID
            alParaval.Add(Val(0))       'PUREXTRA
            alParaval.Add(Val(0))       'PURRETURN
            alParaval.Add(Val(PURCHASERATE))       'PURBAL
            alParaval.Add(Val(0))       'AMTREC
            alParaval.Add(Val(0))       'EXTRAAMT
            alParaval.Add(Val(0))       'RETURN
            alParaval.Add(Val(GRANDTOTAL))    'BAL

            'FOR DONE
            alParaval.Add(0)
            alParaval.Add(0)        'USERPOITS
            alParaval.Add(0)        'REFPOINTS


            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            alParaval.Add("1")      'GRIDSRNO
            alParaval.Add(ROOMCATEGORY.Trim)
            alParaval.Add("1")      'AC
            alParaval.Add(MEALPLAN.Trim)
            alParaval.Add(ADULTS)
            alParaval.Add(0)        'CHILD
            alParaval.Add(INFANTS)
            alParaval.Add(EXTRAADULTS)
            alParaval.Add(EXTRAADULTSRATE)
            alParaval.Add(EXTRACHILD)
            alParaval.Add(EXTRACHILDRATE)
            alParaval.Add(NOOFROOMS)
            alParaval.Add("")       'GRIDREMARKS
            If PACKAGE.Trim = "No" Then alParaval.Add(0) Else alParaval.Add(1)
            alParaval.Add(RATE)
            alParaval.Add("")       'CURRCODE
            alParaval.Add("0")      'ROE
            alParaval.Add(RATE)     'AMT



            alParaval.Add("1")   'PURGRIDSRNO
            alParaval.Add("0")   'PURADULTRATE
            alParaval.Add("0")   'PURCHILDRATE
            alParaval.Add(PURCHASERATE)   'PURRATE
            alParaval.Add(PURCHASERATE)   'PURAMT


            alParaval.Add(GUESTMOBILENO)
            alParaval.Add("")       'EMAILDI
            alParaval.Add(REFNO)
            alParaval.Add(0)        'CHKDISPUTE
            alParaval.Add(0)        'BILLCHECKED
            alParaval.Add(0)        'REFUNDED
            alParaval.Add(0)        'FAILED

            alParaval.Add("")       'CONFIRMEDBY
            alParaval.Add("")       'CONFNO
            alParaval.Add(ClientName)
            alParaval.Add("")       'PREFIX
            alParaval.Add(Val(0))   'ENQNO
            alParaval.Add("")       'NOTES
            alParaval.Add("")       'CANCELPOLICY

            alParaval.Add(SALESACCODE)
            alParaval.Add(PURSACCODE)

            alParaval.Add(0)        'MANUALGST

            alParaval.Add(Val(CGSTPER))
            alParaval.Add(Val(CGSTAMT))
            alParaval.Add(Val(SGSTPER))
            alParaval.Add(Val(SGSTAMT))
            alParaval.Add(Val(IGSTPER))   'IGSTPER
            alParaval.Add(Val(IGSTAMT))   'IGSTAMT


            alParaval.Add(0)        'PURSEVCHGS
            alParaval.Add(Val(0))   'PURCOMMPER

            alParaval.Add(0)        'PURMANUALGST


            alParaval.Add(Val(0))       'PURGSTCOMPUMN
            alParaval.Add(Val(0))
            alParaval.Add(Val(0))
            alParaval.Add(Val(0))
            alParaval.Add(Val(0))
            alParaval.Add(Val(0))


            alParaval.Add(0)        'FOR COMM


            alParaval.Add("")       'UPLOADGRID
            alParaval.Add("")
            alParaval.Add("")
            alParaval.Add("")
            alParaval.Add("")
            alParaval.Add("")


            Dim OBJBOOKING As New ClsHotelBookingMaster()
            OBJBOOKING.alParaval = alParaval
            Dim DTNO As DataTable = OBJBOOKING.save()

            GoTo SEARCHNEXTBOOKING

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ADDGUESTNAME(ByVal GUESTNAME As String, GUESTMOBILENO As String)
        Try
            Dim IntResult As Integer
            Dim alParaval As New ArrayList
            alParaval.Add(GUESTNAME)
            alParaval.Add("")   'ADD1
            alParaval.Add("")   'ADD2

            alParaval.Add("")   'AREA
            alParaval.Add("")   'STD
            alParaval.Add("")   'CITYNAME
            alParaval.Add("")   'ZIPCODE
            alParaval.Add("")   'STATENAME
            alParaval.Add("")   'COUNTRY

            alParaval.Add("")   'MEMBERSHIPNO
            alParaval.Add(0)    'DOB
            alParaval.Add(Format(Mydate.Date, "MM/dd/yyyy"))

            alParaval.Add(0)
            alParaval.Add(Format(Mydate.Date, "MM/dd/yyyy"))


            alParaval.Add("")   'BIRTHPLACE

            alParaval.Add("")   'RESINO
            alParaval.Add("")   'ALTNO
            alParaval.Add("")   'TELNO
            alParaval.Add(GUESTMOBILENO)
            alParaval.Add("")   'FAX
            alParaval.Add("")   'WEBSITE
            alParaval.Add("")   'EMAIL
            alParaval.Add("")   'REFNO
            alParaval.Add("")   'NATIONALITY
            alParaval.Add("")   'ADDRESS
            alParaval.Add("")   'REMARKS
            alParaval.Add("")   'ITSNO
            alParaval.Add("")   'PASSNAME
            alParaval.Add("")   'PASSNO
            alParaval.Add(Format(Mydate.Date, "MM/dd/yyyy"))
            alParaval.Add(Format(Mydate.Date, "MM/dd/yyyy"))
            alParaval.Add("")   'GUIVENNAME
            alParaval.Add("")   'SURNAME
            alParaval.Add("")   'GENDER
            alParaval.Add("")   'STATUS
            alParaval.Add("")   'ISSUEPLACE
            alParaval.Add("")   'ISSCOUNTRY
            alParaval.Add("")   'PREFIX

            alParaval.Add(Val(0))
            alParaval.Add(Val(0))
            alParaval.Add(Val(0))
            alParaval.Add("")
            alParaval.Add("")
            alParaval.Add("")
            alParaval.Add("")
            alParaval.Add("")
            alParaval.Add("")   'GUESTCATEGORY

            alParaval.Add(0)    'CHK
            alParaval.Add(0)
            alParaval.Add(0)
            alParaval.Add(0)


            alParaval.Add(1)    'RBGUEST
            alParaval.Add(0)    'LEADER
            alParaval.Add(0)    'COORDINATOR

            alParaval.Add(DBNull.Value) 'IMG
            alParaval.Add("")
            alParaval.Add(DBNull.Value)
            alParaval.Add("")
            alParaval.Add(DBNull.Value)
            alParaval.Add("")
            alParaval.Add(DBNull.Value)
            alParaval.Add("")
            alParaval.Add(DBNull.Value)
            alParaval.Add("")
            alParaval.Add(DBNull.Value)
            alParaval.Add("")
            alParaval.Add(DBNull.Value)
            alParaval.Add("")

            alParaval.Add(Val(0))   'COPYID

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)
            alParaval.Add(0)    'BLOCKED

            Dim OBJGUEST As New ClsGuestMaster
            OBJGUEST.alParaval = alParaval
            IntResult = OBJGUEST.SAVE()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ADDLEDGERS(ByVal NAME As String, GROUPNAME As String, ByVal STATENAME As String)
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("GROUP_ID AS GROUPID ", "", " GROUPMASTER ", " AND GROUP_NAME = '" & GROUPNAME & "' AND GROUP_YEARID = " & YearId)
            Dim DTSTATE As DataTable = OBJCMN.search("STATE_ID AS STATEID ", "", " STATEMASTER ", " AND STATE_NAME = '" & STATENAME & "' AND STATE_YEARID = " & YearId)
            Dim STATEID As Integer = 0
            If DTSTATE.Rows.Count > 0 Then STATEID = Val(DTSTATE.Rows(0).Item("STATEID"))
            DT = OBJCMN.Execute_Any_String("insert into AccountsMaster (acc_cmpname, acc_name, acc_groupid, Acc_opbal, Acc_drcr, ACC_STATEID, acc_cmpid, acc_locationid, acc_userid, acc_yearid, acc_transfer, acc_created, ACC_ISLOCKED) values('" & NAME & "','" & NAME & "'," & Val(DT.Rows(0).Item("GROUPID")) & ",0,'Dr.'," & STATEID & "," & CmpId & ",0," & Userid & "," & YearId & ",0,getdate(),0)", "", "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ADDROOM(ByVal ROOMCATEFGORY As String, HOTELNAME As String)
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable
LINEROOMTYPE:
            DT = OBJCMN.search("ROOMTYPE_ID AS ROOMTYPEID", "", "ROOMTYPEMASTER", " And ROOMTYPE_NAME = '" & ROOMCATEFGORY & "' AND ROOMTYPE_YEARID = " & YearId)
            If DT.Rows.Count = 0 Then
                Dim alParaval As New ArrayList

                alParaval.Add(ROOMCATEFGORY.Trim)
                alParaval.Add("")
                alParaval.Add(CmpId)
                alParaval.Add(Locationid)
                alParaval.Add(Userid)
                alParaval.Add(YearId)
                alParaval.Add(0)

                Dim objclsROOMTYPE As New ClsRoomTypeMaster
                objclsROOMTYPE.alParaval = alParaval
                Dim IntResult As Integer = objclsROOMTYPE.SAVE()
                GoTo LINEROOMTYPE
            End If

            Dim DTHOTEL As DataTable = OBJCMN.search("HOTEL_ID AS HOTELID", "", "HOTELMASTER", " AND HOTEL_NAME = '" & HOTELNAME & "' AND HOTEL_YEARID = " & YearId)
            Dim DTADD As DataTable = OBJCMN.Execute_Any_String("INSERT INTO HOTELMASTER_ROOMDESC VALUES (" & Val(DTHOTEL.Rows(0).Item("HOTELID")) & ",1," & Val(DT.Rows(0).Item("ROOMTYPEID")) & ",1,0,'',''," & CmpId & ",0," & Userid & "," & YearId & ",0, GETDATE())", "", "")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ADDMEALPLAN(ByVal MEALPLAN As String)
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("PLAN_ID AS PLANID", "", "PLANMASTER", " AND PLAN_NAME = '" & MEALPLAN & "' AND PLAN_YEARID = " & YearId)
            If DT.Rows.Count = 0 Then
                Dim alParaval As New ArrayList

                alParaval.Add(MEALPLAN.Trim)
                alParaval.Add("")
                alParaval.Add(CmpId)
                alParaval.Add(Locationid)
                alParaval.Add(Userid)
                alParaval.Add(YearId)
                alParaval.Add(0)

                Dim objclsPLAN As New ClsPlanMaster
                objclsPLAN.alParaval = alParaval
                Dim IntResult As Integer = objclsPLAN.SAVE()

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ADDSOURCE(ByVal SOURCE As String)
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("SOURCE_ID AS SOURCEID", "", "SOURCEMASTER", " AND SOURCE_NAME = '" & SOURCE & "' AND SOURCE_YEARID = " & YearId)
            If DT.Rows.Count = 0 Then
                Dim alParaval As New ArrayList

                alParaval.Add(SOURCE.Trim)
                alParaval.Add("")
                alParaval.Add(CmpId)
                alParaval.Add(Locationid)
                alParaval.Add(Userid)
                alParaval.Add(YearId)
                alParaval.Add(0)

                Dim objclsSOURCE As New ClsSourceMaster
                objclsSOURCE.alParaval = alParaval
                Dim IntResult As Integer = objclsSOURCE.SAVE()

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SKYMAPSSYNC()
        Try

            Dim OBJCMN As New ClsCommon
            Dim DTCHECK As New DataTable
            Dim TEMPCMD As New SqlCommand
            Dim TEMPDT As New DataTable

            Dim CONN As New SqlConnection("Data Source=43.240.65.42;Initial Catalog=Mapstrip;User ID=sa;Password=a@#dFJ@($fF@$^*#);connection timeout= 2000")
            Dim TEMPCONN As New SqlConnection("Data Source=43.240.65.42;Initial Catalog=Mapstrip;User ID=sa;Password=a@#dFJ@($fF@$^*#);connection timeout=2000")

            'ADD FLIGHT INVOICE
            Dim CMD As New SqlCommand("Select distinct * from (Select fb.PNR_Number, fb.CancellationRemarks, pm.PnrId,fb.CompanyId, pm.PNR,UserAmount As userAmt,fb.Request_No As Local_Ref_No,fb.Transaction_Id,dbo.FlightBookingTransaction(fb.Request_No) As FlightBookingTranData,convert(varchar,fb.TransactionDate,106) BookingDate,fb.Booking_Type,fb.Journey_Type,fb.Origin,fb.Destination,convert(varchar,fb.Departure_Date,106)TravelDate,fb.Booking_By_Supplier,fb.Supplier_Code, fb.Booking_Status,Case When Admin_Booking_Status='Rejected' then 'Rejected'  when fb.Booking_Status='SuccessTkd' then 'SuccessTkd'  else 'Underprocess' END as Booking_Status1,fb.Remark,(FB.BASEFARE + FB.TAXES + FB.COMPANYMARKUP + TdsCommission - FB.TOTALDISCOUNT) as CompanyAmount, FB.PURCHASEAMOUNT, FB.BASEFARE, FB.TAXES, FB.COMPANYMARKUP, TdsCommission ,FB.TOTALDISCOUNT,fb.Requet_Type,fb.PromoPlan,'' as Ticket_Status,(flpi.PaxTitle +' '+flpi.PaxFirstName +' '+flpi.PaxLastName) as LeadPaxName, dbo.ufngetAllPassengerDetail(fb.Request_No,fb.Booking_Status) as TotalPassengerName,fb.BalanceBeforeBooking,fb.BookingAmount,dbo.ufngetAllUserAmount(fb.Request_No,fb.Booking_Status) as UserAmount,fb.admin_booking_status,ad.Company_Name,convert(int,adult)+ convert(int,Child)+convert(int,Infant) as TotalPassengerCount  from FlightBooking fb  inner join pnr_mapping pm on fb.Request_No=pm.Local_Ref_No inner join Agent_Details ad on ad.Company_Id=fb.CompanyId inner join FlightLeadPaxTravelInfo flpi on flpi.Request_no=pm.Local_Ref_No where fb.Booking_Status is not null and  fb.TransactionDate is not null and fb.Transaction_id is not null and pm.Service='Flight'  and Trip_Indicator='1' AND BOOKING_STATUS <> 'RollBack' AND CreatedDate >= CONVERT(DATETIME,'" & FROMDATE.Value.Date & " 00:00:00',103) AND CreatedDate <= CONVERT(DATETIME,'" & TODATE.Value.Date & " 23:55:59',103) ) tab order by tab.PnrId ASC ", CONN)
            CONN.Open()
            Dim DA As New SqlDataAdapter(CMD)
            Dim DT As New DataTable
            DA.Fill(DT)

            If DT.Rows.Count > 0 Then
                For Each ROW As DataRow In DT.Rows
                    Cursor.Current = Cursors.WaitCursor
                    Dim alParaval As New ArrayList


                    'BEFORE ADDING IN DATABASE CHECK WHETHER SAME INVOICE IS PRESENT IN TABLE OR NOT
                    'CHECK THE PARTYREFNO --- WE INSERT THE LOCALREFNO IN THIS FIELD
                    'IF NOT PRESENT THEN ADD THE DATA
                    DTCHECK = OBJCMN.search("BOOKING_NO AS BOOKINGNO", "", " AIRLINEBOOKINGMASTER ", " AND BOOKING_PARTYREFNO = '" & ROW("LOCAL_REF_NO") & "' AND BOOKING_YEARID = " & YearId)
                    If DTCHECK.Rows.Count > 0 Then GoTo GOTONEXTRECORD
                    DTCHECK.Clear()



                    'IF BOOKIGNSTATUS IS RETURN THEN ADD RETURN FALSE IN PURCHASEAMT AND COMPANY AMT
                    'FETCH RETURN AMOUNT AND ADD THAT VALUE IN COMPANYAMOUNT AND PURCHASEAMOUNT
                    'If ROW("JOURNEY_TYPE").ToString.Trim = "Return" Then
                    '    TEMPCMD = New SqlCommand("SELECT DISTINCT * from(select pm.PnrId,fb.CompanyAmount,FB.PURCHASEAMOUNT, FB.PNR_NUMBER from FlightBooking fb inner join pnr_mapping pm on fb.Request_No=pm.Local_Ref_No inner join Agent_Details ad on ad.Company_Id=fb.CompanyId WHERE fb.TransactionDate is not null and pm.Service='Flight' AND BOOKING_STATUS <> 'RollBack' and Trip_Indicator='2' AND fb.Request_No = '" & ROW("LOCAL_REF_NO") & "') AS TB", TEMPCONN)
                    '    TEMPCONN.Open()
                    '    DA = New SqlDataAdapter(TEMPCMD)
                    '    DA.Fill(TEMPDT)
                    '    If TEMPDT.Rows.Count > 0 Then
                    '        'ADD COMPANYAMOUNT, PURCHASEAMT AND PNR NO
                    '        ROW("COMPANYAMOUNT") = Val(ROW("COMPANYAMOUNT")) + Val(TEMPDT.Rows(0).Item("COMPANYAMOUNT"))
                    '        ROW("PURCHASEAMOUNT") = Val(ROW("PURCHASEAMOUNT")) + Val(TEMPDT.Rows(0).Item("PURCHASEAMOUNT"))
                    '        ROW("PNR_NUMBER") = ROW("PNR_NUMBER") & "/" & TEMPDT.Rows(0).Item("PNR_NUMBER")
                    '    End If
                    '    TEMPDT.Clear()
                    '    TEMPCONN.Close()
                    'End If



                    If ROW("BOOKING_TYPE") = "Int" Then
                        alParaval.Add("INTAIRLINE PURCHASE REGISTER")
                        alParaval.Add("INTAIRLINE SALE REGISTER")
                    Else
                        alParaval.Add("AIRLINE PURCHASE REGISTER")
                        alParaval.Add("AIRLINE SALE REGISTER")
                    End If

                    alParaval.Add(0)    'BOOKING NO

                    alParaval.Add(Format(Convert.ToDateTime(ROW("BookingDate")).Date, "MM/dd/yyyy"))
                    alParaval.Add("")   'CRSTYPE

                    alParaval.Add(0)    'BSP
                    alParaval.Add(0)    'COUPON


                    'GET AIRLINE NAME FROM FLIGHTSEGMENT TABLE WITH RESPECT TO REQUEST NO
                    'IF WE JOIN THIS TABLE IN ABOVE QUERY WE WILL GET MULTIPLE RECORDS FOR SAME REQUESTNO
                    'SO WE NEED TO FETCH SEPERATELY AND GET TOP1 RECORD ONLY
                    TEMPCMD = New SqlCommand("SELECT TOP 1 AIRLINECODE, AIRLINENAME FROM FLIGHTSEGMENT WHERE REQUEST_NO = '" & ROW("LOCAL_REF_NO") & "'", TEMPCONN)
                    TEMPCONN.Open()
                    DA = New SqlDataAdapter(TEMPCMD)
                    DA.Fill(TEMPDT)
                    If TEMPDT.Rows.Count > 0 Then

                        'CHECK WHETHER THIS AIRLINE IS PRESENT IN FLIGHTMASTER OR NOT
                        'IF NOT THEN ADD FLIGHT NAME FIRST
                        DTCHECK = OBJCMN.search("FLIGHT_NAME AS AIRLINENAME", "", " FLIGHTMASTER ", " AND FLIGHT_NAME = '" & TEMPDT.Rows(0).Item("AIRLINENAME") & "' AND FLIGHT_YEARID = " & YearId)
                        If DTCHECK.Rows.Count = 0 Then
                            'ADD IN FLIGHTMASTER
                            DTCHECK = OBJCMN.Execute_Any_String("INSERT INTO FLIGHTMASTER (FLIGHT_CODE, FLIGHT_NAME, FLIGHT_CMPID, FLIGHT_LOCATIONID, FLIGHT_USERID, FLIGHT_YEARID, FLIGHT_TRANSFER, FLIGHT_CREATED, FLIGHT_MODIFIED, FLIGHT_MODIFIEDBY) VALUES ('" & TEMPDT.Rows(0).Item("AIRLINECODE") & "','" & TEMPDT.Rows(0).Item("AIRLINENAME") & "'," & CmpId & ",0," & Userid & "," & YearId & ",0, GETDATE(), GETDATE()," & Userid & ")", "", "")
                        End If
                    End If
                    alParaval.Add(TEMPDT.Rows(0).Item("AIRLINENAME"))
                    TEMPDT.Clear()
                    TEMPCONN.Close()


                    'CHECK WHETHER SUPPLIER IS PRESENT IN ACCOUNTSMASTER OR NOT
                    'IF NOT THEN ADD LEDGER NAME FIRST
                    DTCHECK = OBJCMN.search("ACC_CMPNAME AS NAME", "", " LEDGERS ", " AND ACC_CMPNAME = '" & ROW("SUPPLIER_CODE") & "' AND ACC_YEARID = " & YearId)
                    If DTCHECK.Rows.Count = 0 Then
                        'ADD IN ACCOUNTSMASTER
                        'GET GROUPID AND ADD
                        TEMPDT = OBJCMN.search(" group_id AS GROUPID", "", " groupmaster ", " AND group_name = 'Sundry Debtors' and group_yearid = " & YearId)
                        DTCHECK = OBJCMN.Execute_Any_String("insert into AccountsMaster (acc_cmpname, acc_name, acc_code, acc_groupid, Acc_opbal , Acc_drcr , acc_cmpid, acc_locationid, acc_userid , acc_yearid,	acc_transfer, acc_created, ACC_ISLOCKED, ACC_MOBILE, ACC_CRDAYS, ACC_CRLIMIT, ACC_ADD) values('" & ROW("SUPPLIER_CODE") & "','" & ROW("SUPPLIER_CODE") & "','" & ROW("SUPPLIER_CODE") & "'," & TEMPDT.Rows(0).Item("GROUPID") & ",0,'', " & CmpId & ",0, " & Userid & "," & YearId & ",0,GETDATE(),0,'',0,0,'') ", "", "")
                    End If
                    alParaval.Add(ROW("SUPPLIER_CODE"))
                    TEMPDT.Dispose()



                    'CHECK WHETHER PARTYNAME IS PRESENT IN ACCOUNTSMASTER OR NOT
                    'IF NOT THEN ADD LEDGER NAME FIRST
                    DTCHECK = OBJCMN.search("ACC_CMPNAME AS NAME", "", " LEDGERS ", " AND ACC_CMPNAME = '" & ROW("COMPANY_NAME") & "' AND ACC_YEARID = " & YearId)
                    If DTCHECK.Rows.Count = 0 Then
                        'ADD IN ACCOUNTSMASTER
                        'GET GROUPID AND ADD
                        TEMPDT = OBJCMN.search(" group_id AS GROUPID", "", " groupmaster ", " AND group_name = 'Sundry Debtors' and group_yearid = " & YearId)
                        DTCHECK = OBJCMN.Execute_Any_String("insert into AccountsMaster (acc_cmpname, acc_name, acc_code, acc_groupid, Acc_opbal , Acc_drcr , acc_cmpid, acc_locationid, acc_userid , acc_yearid,	acc_transfer, acc_created, ACC_ISLOCKED, ACC_MOBILE, ACC_CRDAYS, ACC_CRLIMIT, ACC_ADD) values('" & ROW("COMPANY_NAME") & "','" & ROW("COMPANY_NAME") & "','" & ROW("COMPANY_NAME") & "'," & TEMPDT.Rows(0).Item("GROUPID") & ",0,'', " & CmpId & ",0, " & Userid & "," & YearId & ",0,GETDATE(),0,'',0,0,'') ", "", "")
                    End If
                    alParaval.Add(ROW("COMPANY_NAME"))
                    TEMPDT.Clear()



                    alParaval.Add(Format(Convert.ToDateTime(ROW("TravelDate")).Date, "MM/dd/yyyy"))
                    alParaval.Add(ROW("LOCAL_REF_NO"))
                    alParaval.Add(ROW("PNR"))


                    'PRINT NAME
                    alParaval.Add("")
                    alParaval.Add(Now.Date)
                    alParaval.Add(Now.Date)

                    Dim SPAN As TimeSpan = Now.Date.Subtract(Now.Date)
                    alParaval.Add(SPAN)
                    alParaval.Add("")   'FROM
                    alParaval.Add("")   'TO

                    alParaval.Add("")   'EMAILID
                    alParaval.Add("")   'MOBILENO

                    alParaval.Add(ROW("PNR_NUMBER"))
                    alParaval.Add(ROW("PNR_NUMBER"))   'AIRLINEPNR
                    alParaval.Add(ROW("TRANSACTION_ID"))   'CRS PNR 


                    alParaval.Add(Val(ROW("BASEFARE")))                     'TOTALBASIC
                    alParaval.Add(Val(0))                                   'TOTALYQ
                    alParaval.Add(Val(ROW("TAXES")))                        'TOTALTAXES
                    alParaval.Add(Val(ROW("BASEFARE")) + Val(ROW("TAXES"))) 'TOTALAMT


                    'PURCHASE VALUES
                    alParaval.Add(Val(ROW("BASEFARE")) + Val(ROW("TAXES"))) 'PURCHASEAMT
                    alParaval.Add(Val(ROW("BASEFARE")) + Val(ROW("TAXES"))) 'TOTALPURAMT
                    alParaval.Add(Val(0))   'DISCOUNTPER
                    alParaval.Add(Val(0))   'DISCOUNTRS
                    alParaval.Add(Val(ROW("BASEFARE")) + Val(ROW("TAXES"))) 'PURCHASE SUBTOTAL
                    alParaval.Add(Val(0))   'COMMPER
                    alParaval.Add(Val(0))   'COMMRS
                    alParaval.Add(Val(5))   '5 % FIXED TDSPER
                    alParaval.Add(Val(Val(ROW("TOTALDISCOUNT")) * 0.05))    '5% FIXED OF COMMISSION TDSRS
                    alParaval.Add(Val(0))   'PUREXTRACHGS
                    alParaval.Add(Val(ROW("BASEFARE")) + Val(ROW("TAXES")))   'PURNETTAMT

                    alParaval.Add(0)    'PURTAXONCOMM (CHECKBOX)


                    alParaval.Add("")       'PURTAXNAME
                    alParaval.Add(Val(0))   'PURTAXAMT
                    alParaval.Add("")       'PURADDTAXNAME
                    alParaval.Add(Val(0))   'PURADDTAXAMT

                    'PURCHASE DISCOUNT PERC, AMOUNT AND OTHER DISCOUNT
                    alParaval.Add(Val(0))   'PURDISCPER
                    alParaval.Add(Val(ROW("TOTALDISCOUNT")))   'PURDISCAMT
                    alParaval.Add(Val(0))   'PURADDDISCAMT

                    alParaval.Add("")       'PUROTHERCHGS
                    alParaval.Add(0)        'PUROTHERCHGSAMT


                    alParaval.Add(Val(0))   'PURROUNDOFF
                    alParaval.Add(Val(ROW("PURCHASEAMOUNT")))   'PURGRANDTOTAL

                    alParaval.Add(Val(ROW("TOTALPASSENGERCOUNT")))
                    alParaval.Add(UserName) 'BOOKEDBY
                    alParaval.Add("")       'SOURCE


                    'SALE VALUES
                    alParaval.Add(Val(ROW("BASEFARE")) + Val(ROW("TAXES")))    'TOTALSALEAMT
                    alParaval.Add(Val(0))   'OURCOMMPER
                    alParaval.Add(Val(0))   'OURCOMMRS
                    alParaval.Add(Val(0))   'DISCPER
                    alParaval.Add(Val(0))   'DISCRS
                    alParaval.Add(Val(0))   'EXTRACHGS
                    alParaval.Add(Val(ROW("BASEFARE")) + Val(ROW("TAXES")) - Val(ROW("TOTALDISCOUNT")))    'SUBTOTAL
                    alParaval.Add("")       'TAXNAME
                    alParaval.Add(Val(0))   'TAXAMT
                    alParaval.Add("")       'ADDTAXNAME
                    alParaval.Add(Val(0))   'ADDTAXAMT

                    'SALE DISCOUNT PERC, AMOUNT AND OTHER DISCOUNT
                    alParaval.Add(Val(0))   'DISCRECDPER
                    alParaval.Add(Val(ROW("TOTALDISCOUNT")))   'DISCRECDAMT
                    alParaval.Add(Val(0))   'SALETDSPER
                    alParaval.Add(Val(ROW("TDSCOMMISSION")))    'TDS 
                    alParaval.Add(Val(0))   'ADDDISCAMT


                    alParaval.Add("Other Charges")       'OTHERCHGS
                    alParaval.Add(Val(ROW("COMPANYMARKUP")))        'OTHERCHGSAMT

                    alParaval.Add(Val(0))       'ROUNDOFF
                    alParaval.Add(Val(ROW("COMPANYAMOUNT")))    'GRANDTOTAL

                    alParaval.Add("")   'REAMRKS
                    alParaval.Add(CurrencyToWord(Val(ROW("COMPANYAMOUNT"))))


                    alParaval.Add(Val(0))   'PURAMTPAID
                    alParaval.Add(Val(0))   'PUREXTRAAMT
                    alParaval.Add(Val(0))   'PURRETURN
                    alParaval.Add(Val(ROW("PURCHASEAMOUNT")))    'PURBALANCE
                    alParaval.Add(Val(0))   'SALEAMTREC
                    alParaval.Add(Val(0))   'SALEEXTRAAMT
                    alParaval.Add(Val(0))   'SALERETURN
                    alParaval.Add(Val(ROW("COMPANYAMOUNT")))    'SALEBALANCE

                    alParaval.Add(0)    'DONE

                    alParaval.Add(0)    'DISPUTE
                    alParaval.Add(0)    'BILLCHECKED
                    alParaval.Add(0)    'CHKREFUND
                    alParaval.Add(0)    'CHKFAILED
                    alParaval.Add(0)    'CHKTAXSERVCHGS
                    alParaval.Add("")   'GROUPDEPATURN
                    alParaval.Add(Val(0))   'ENQNO

                    alParaval.Add(CmpId)
                    alParaval.Add(Locationid)
                    alParaval.Add(Userid)
                    alParaval.Add(YearId)
                    alParaval.Add(0)


                    alParaval.Add(ROW("LEADPAXNAME") & " * " & Val(ROW("TOTALPASSENGERCOUNT"))) 'PAXNAMEFORACCOUNTS


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

                    'PASSENGER DETAIL GRID
                    Dim PASSDESC As String = ""
                    Dim SEX As String = ""
                    Dim PANNO As String = ""
                    Dim PASSPORT As String = ""
                    Dim ISSUED As String = ""

                    'FLIGHT GRID
                    Dim FLIGHTSRNO As String = ""
                    Dim BOOKSRNO As String = ""
                    Dim FROMSEC As String = ""
                    Dim TOSEC As String = ""
                    Dim FLIGHTNO As String = ""
                    Dim FLIGHTDATE As String = ""
                    Dim ARRIVES As String = ""
                    Dim FLIGHTCLASS As String = ""



                    'FETCH SECTORS AND CLASS FROM FLIGHTSEGMENT IN A TEMPVARIABLE AND THEN USE THAT BELOW
                    Dim TEMPSECTOR As String = ""
                    Dim TEMPCLASS As String = ""
                    TEMPCMD = New SqlCommand("SELECT Origin_airportcode AS FROMCODE, Destination_airportcode AS TOCODE, CABINCLASS, FLIGHTCLASS AS FLIGHTNO, DEPTIME, ARRTIME FROM flightsegment WHERE Request_No = '" & ROW("LOCAL_REF_NO") & "' ORDER BY SEGMENT_INDEX", TEMPCONN)
                    TEMPCONN.Open()
                    DA = New SqlDataAdapter(TEMPCMD)
                    DA.Fill(TEMPDT)
                    If TEMPDT.Rows.Count > 0 Then
                        Dim I As Integer = 1
                        For Each TEMPROW As DataRow In TEMPDT.Rows
                            If TEMPSECTOR = "" Then
                                TEMPSECTOR = TEMPROW("FROMCODE") & "/" & TEMPROW("TOCODE")
                                FLIGHTSRNO = I
                                BOOKSRNO = 1    'THIS IS FOR FIRST RECORD, IF THERE ARE MULTIPLE PASSENGERS THEN WE WILL LOOP THIS SAME RECORD FURTHER NOT HERE
                                FROMSEC = TEMPROW("FROMCODE")
                                TOSEC = TEMPROW("TOCODE")
                                FLIGHTNO = TEMPROW("FLIGHTNO")
                                FLIGHTDATE = TEMPROW("DEPTIME")
                                ARRIVES = TEMPROW("ARRTIME")
                                FLIGHTCLASS = TEMPROW("CABINCLASS")
                            Else
                                TEMPSECTOR = TEMPSECTOR & "/" & TEMPROW("TOCODE")
                                FLIGHTSRNO = FLIGHTSRNO & "|" & I
                                BOOKSRNO = BOOKSRNO & "|" & I    'THIS IS FOR FIRST RECORD, IF THERE ARE MULTIPLE PASSENGERS THEN WE WILL LOOP THIS SAME RECORD FURTHER NOT HERE
                                FROMSEC = TOSEC & "|" & TEMPROW("FROMCODE")
                                TOSEC = TOSEC & "|" & TEMPROW("TOCODE")
                                FLIGHTNO = FLIGHTNO & "|" & TEMPROW("FLIGHTNO")
                                FLIGHTDATE = FLIGHTDATE & "|" & TEMPROW("DEPTIME")
                                ARRIVES = ARRIVES & "|" & TEMPROW("ARRTIME")
                                FLIGHTCLASS = FLIGHTCLASS & "|" & TEMPROW("CABINCLASS")
                            End If
                            I += 1
                        Next
                        TEMPCLASS = TEMPDT.Rows(0).Item("CABINCLASS")
                    End If
                    TEMPDT.Clear()
                    TEMPCONN.Close()


                    'GET PASSNAME AND TICKETNO FROM FLIGHTPAXTRAVELINFO TABLE WITH RESPECT TO REQUEST NO
                    TEMPCMD = New SqlCommand("SELECT DISTINCT  Title + ' ' + FirstName + ' ' + LastName AS PASSNAME FROM FlightPaxTravelInfo WHERE LOCAL_REF_NO = '" & ROW("LOCAL_REF_NO") & "'", TEMPCONN)
                    TEMPCONN.Open()
                    DA = New SqlDataAdapter(TEMPCMD)
                    DA.Fill(TEMPDT)
                    If TEMPDT.Rows.Count > 0 Then
                        Dim I As Integer = 1
                        For Each TEMPROW As DataRow In TEMPDT.Rows
                            If gridsrno = "" Then
                                gridsrno = I
                                PASSNAME = TEMPROW("PASSNAME")
                                SECTOR = TEMPSECTOR
                                FLTNO = ""
                                TYPE = "Adult"
                                'TICKETNO = TEMPROW("TICKETNO")
                                TICKETNO = ""
                                CLASSNAME = TEMPCLASS
                                BASIC = Format(Val(ROW("BASEFARE")) / Val(ROW("TOTALPASSENGERCOUNT")), "0.00")
                                PSF = 0
                                TAXES = Format(Val(ROW("TAXES")) / Val(ROW("TOTALPASSENGERCOUNT")), "0.00")
                                AMT = Format((Val(ROW("BASEFARE")) + Val(ROW("TAXES"))) / Val(ROW("TOTALPASSENGERCOUNT")), "0.00")
                                BCANCELLED = 0

                                'THESE PARAMETERS ARE FOR PASSGRID
                                PASSDESC = ""
                                SEX = ""
                                PANNO = ""
                                PASSPORT = ""
                                ISSUED = ""

                            Else
                                gridsrno = gridsrno & "|" & I
                                PASSNAME = PASSNAME & "|" & TEMPROW("PASSNAME")
                                SECTOR = SECTOR & "|" & TEMPSECTOR
                                FLTNO = FLTNO & "|" & ""
                                TYPE = TYPE & "|" & "Adult"
                                'TICKETNO = TICKETNO & "|" & TEMPROW("TICKETNO")
                                TICKETNO = TICKETNO & "|" & ""
                                CLASSNAME = CLASSNAME & "|" & TEMPCLASS
                                BASIC = BASIC & "|" & Format(Val(ROW("BASEFARE")) / Val(ROW("TOTALPASSENGERCOUNT")), "0.00")
                                PSF = PSF & "|" & 0
                                TAXES = TAXES & "|" & Format(Val(ROW("TAXES")) / Val(ROW("TOTALPASSENGERCOUNT")), "0.00")
                                AMT = AMT & "|" & Format((Val(ROW("BASEFARE")) + Val(ROW("TAXES"))) / Val(ROW("TOTALPASSENGERCOUNT")), "0.00")
                                BCANCELLED = BCANCELLED & "|" & "0"

                                'THESE PARAMETERS ARE FOR PASSGRID
                                PASSDESC = PASSDESC & "|" & ""
                                SEX = SEX & "|" & ""
                                PANNO = PANNO & "|" & ""
                                PASSPORT = PASSPORT & "|" & ""
                                ISSUED = ISSUED & "|" & ""

                            End If
                            I += 1
                        Next
                    End If
                    TEMPDT.Clear()
                    TEMPCONN.Close()


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


                    alParaval.Add(gridsrno)     'PASSGRIDSRNO
                    alParaval.Add(gridsrno)     'PASSBOOKINGGRIDSRNO
                    alParaval.Add(PASSNAME)     'PASSNAME
                    alParaval.Add(PASSDESC)     'DESC
                    alParaval.Add(TICKETNO)     'PASSTICKETNO
                    alParaval.Add(SEX)
                    alParaval.Add(PANNO)
                    alParaval.Add(PASSPORT)
                    alParaval.Add(ISSUED)



                    'PURCHASE GRID
                    alParaval.Add(gridsrno)     'PURGRIDSRNO
                    alParaval.Add(gridsrno)     'PURBOOKGRIDSRNO
                    alParaval.Add(PASSNAME)     'PURPASSNAME
                    alParaval.Add(TICKETNO)     'PURTICKETNO
                    alParaval.Add(BASIC)        'PURBASIC
                    alParaval.Add(PSF)          'PURYQ
                    alParaval.Add(TAXES)        'PURTAXES
                    alParaval.Add(AMT)          'PURAMT
                    alParaval.Add(BCANCELLED)   'PURCANCELLED




                    'FLIGHT GRID
                    'WE HAVE GOT THE RECORDS FOR ONLY 1 PASSENFER 
                    'WE HAVE TO LOOP IT FOR TOTALNOOFPASSENGERS
                    'FLIGHT GRID
                    Dim TEMPFLIGHTSRNO As String = FLIGHTSRNO
                    Dim TEMPBOOKSRNO As String = BOOKSRNO
                    Dim TEMPFROMSEC As String = FROMSEC
                    Dim TEMPTOSEC As String = TOSEC
                    Dim TEMPFLIGHTNO As String = FLIGHTNO
                    Dim TEMPFLIGHTDATE As String = FLIGHTDATE
                    Dim TEMPARRIVES As String = ARRIVES
                    Dim TEMPFLIGHTCLASS As String = FLIGHTCLASS


                    If Val(ROW("TOTALPASSENGERCOUNT")) > 1 Then
                        For I As Integer = 2 To Val(ROW("TOTALPASSENGERCOUNT"))
                            FLIGHTSRNO = FLIGHTSRNO & "|" & TEMPFLIGHTSRNO
                            BOOKSRNO = BOOKSRNO & "|" & I
                            FROMSEC = TOSEC & "|" & TEMPFROMSEC
                            TOSEC = TOSEC & "|" & TEMPTOSEC
                            FLIGHTNO = FLIGHTNO & "|" & TEMPFLIGHTNO
                            FLIGHTDATE = FLIGHTDATE & "|" & TEMPFLIGHTDATE
                            ARRIVES = ARRIVES & "|" & TEMPARRIVES
                            FLIGHTCLASS = FLIGHTCLASS & "|" & TEMPFLIGHTCLASS
                        Next
                    End If

                    alParaval.Add(FLIGHTSRNO)
                    alParaval.Add(BOOKSRNO)
                    alParaval.Add(FROMSEC)
                    alParaval.Add(TOSEC)
                    alParaval.Add(FLIGHTNO)
                    alParaval.Add(FLIGHTDATE)
                    alParaval.Add(ARRIVES)
                    alParaval.Add(FLIGHTCLASS)



                    alParaval.Add("")   'GRIDUPLOADSRNO
                    alParaval.Add("")   'GRIDREMARKS
                    alParaval.Add("")   'NAME
                    alParaval.Add("")   'IMGPATH
                    alParaval.Add("")   'NEWIMFPATH
                    alParaval.Add("")   'FILENAME


                    alParaval.Add(ClientName)


                    Dim OBJBOOKING As New ClsAirlineBookingMaster()
                    OBJBOOKING.alParaval = alParaval

                    Dim DTNO As DataTable = OBJBOOKING.save()

GOTONEXTRECORD:

                Next


            End If
            CONN.Close()


            'ADD SAME INVOICE FOR RETURN DATA ALSO
            'ADD FLIGHT INVOICE
            CMD = New SqlCommand("select distinct * from (select fb.PNR_Number,fb.CancellationRemarks, pm.PnrId,fb.CompanyId, pm.PNR,UserAmount as userAmt,fb.Request_No as Local_Ref_No,fb.Transaction_Id,dbo.FlightBookingTransaction(fb.Request_No) AS FlightBookingTranData,convert(varchar,fb.TransactionDate,106) BookingDate,fb.Booking_Type,fb.Journey_Type,fb.Origin,fb.Destination,convert(varchar,fb.Departure_Date,106)TravelDate,fb.Booking_By_Supplier,fb.Supplier_Code, fb.Booking_Status,Case when Admin_Booking_Status='Rejected' then 'Rejected'  when fb.Booking_Status='SuccessTkd' then 'SuccessTkd'  else 'Underprocess' END as Booking_Status1,fb.Remark,(FB.BASEFARE + FB.TAXES + FB.COMPANYMARKUP + TdsCommission - FB.TOTALDISCOUNT) as CompanyAmount, FB.PURCHASEAMOUNT, FB.BASEFARE, FB.TAXES, FB.COMPANYMARKUP, TdsCommission ,FB.TOTALDISCOUNT,fb.Requet_Type,fb.PromoPlan,'' as Ticket_Status,(flpi.PaxTitle +' '+flpi.PaxFirstName +' '+flpi.PaxLastName) as LeadPaxName, dbo.ufngetAllPassengerDetail(fb.Request_No,fb.Booking_Status) as TotalPassengerName,fb.BalanceBeforeBooking,fb.BookingAmount,dbo.ufngetAllUserAmount(fb.Request_No,fb.Booking_Status) as UserAmount,fb.admin_booking_status,ad.Company_Name,convert(int,adult)+ convert(int,Child)+convert(int,Infant) as TotalPassengerCount  from FlightBooking fb  inner join pnr_mapping pm on fb.Request_No=pm.Local_Ref_No inner join Agent_Details ad on ad.Company_Id=fb.CompanyId inner join FlightLeadPaxTravelInfo flpi on flpi.Request_no=pm.Local_Ref_No where fb.Booking_Status is not null and  fb.TransactionDate is not null and fb.Transaction_id is not null and pm.Service='Flight'  and Trip_Indicator='2' AND BOOKING_STATUS <> 'RollBack' AND CreatedDate >= CONVERT(DATETIME,'" & FROMDATE.Value.Date & " 00:00:00',103) AND CreatedDate <= CONVERT(DATETIME,'" & TODATE.Value.Date & " 23:55:59',103) ) tab order by tab.PnrId ASC ", CONN)
            CONN.Open()
            DA = New SqlDataAdapter(CMD)
            DA.Fill(DT)

            If DT.Rows.Count > 0 Then
                For Each ROW As DataRow In DT.Rows
                    Cursor.Current = Cursors.WaitCursor
                    Dim alParaval As New ArrayList


                    'BEFORE ADDING IN DATABASE CHECK WHETHER SAME INVOICE IS PRESENT IN TABLE OR NOT
                    'CHECK THE PNR --- WE INSERT THE PNT_NUMBER IN THIS FIELD
                    'IF NOT PRESENT THEN ADD THE DATA
                    DTCHECK = OBJCMN.search("BOOKING_NO AS BOOKINGNO", "", " AIRLINEBOOKINGMASTER ", " AND BOOKING_PNRNO = '" & ROW("PNR_NUMBER") & "' AND BOOKING_YEARID = " & YearId)
                    If DTCHECK.Rows.Count > 0 Then GoTo GOTONEXTRECORDRETURN
                    DTCHECK.Clear()



                    If ROW("BOOKING_TYPE") = "Int" Then
                        alParaval.Add("INTAIRLINE PURCHASE REGISTER")
                        alParaval.Add("INTAIRLINE SALE REGISTER")
                    Else
                        alParaval.Add("AIRLINE PURCHASE REGISTER")
                        alParaval.Add("AIRLINE SALE REGISTER")
                    End If

                    alParaval.Add(0)    'BOOKING NO

                    alParaval.Add(Format(Convert.ToDateTime(ROW("BookingDate")).Date, "MM/dd/yyyy"))
                    alParaval.Add("")   'CRSTYPE

                    alParaval.Add(0)    'BSP
                    alParaval.Add(0)    'COUPON


                    'GET AIRLINE NAME FROM FLIGHTSEGMENT TABLE WITH RESPECT TO REQUEST NO
                    'IF WE JOIN THIS TABLE IN ABOVE QUERY WE WILL GET MULTIPLE RECORDS FOR SAME REQUESTNO
                    'SO WE NEED TO FETCH SEPERATELY AND GET TOP1 RECORD ONLY
                    TEMPCMD = New SqlCommand("SELECT TOP 1 AIRLINECODE, AIRLINENAME FROM FLIGHTSEGMENT WHERE REQUEST_NO = '" & ROW("LOCAL_REF_NO") & "'", TEMPCONN)
                    TEMPCONN.Open()
                    DA = New SqlDataAdapter(TEMPCMD)
                    DA.Fill(TEMPDT)
                    If TEMPDT.Rows.Count > 0 Then

                        'CHECK WHETHER THIS AIRLINE IS PRESENT IN FLIGHTMASTER OR NOT
                        'IF NOT THEN ADD FLIGHT NAME FIRST
                        DTCHECK = OBJCMN.search("FLIGHT_NAME AS AIRLINENAME", "", " FLIGHTMASTER ", " AND FLIGHT_NAME = '" & TEMPDT.Rows(0).Item("AIRLINENAME") & "' AND FLIGHT_YEARID = " & YearId)
                        If DTCHECK.Rows.Count = 0 Then
                            'ADD IN FLIGHTMASTER
                            DTCHECK = OBJCMN.Execute_Any_String("INSERT INTO FLIGHTMASTER (FLIGHT_CODE, FLIGHT_NAME, FLIGHT_CMPID, FLIGHT_LOCATIONID, FLIGHT_USERID, FLIGHT_YEARID, FLIGHT_TRANSFER, FLIGHT_CREATED, FLIGHT_MODIFIED, FLIGHT_MODIFIEDBY) VALUES ('" & TEMPDT.Rows(0).Item("AIRLINECODE") & "','" & TEMPDT.Rows(0).Item("AIRLINENAME") & "'," & CmpId & ",0," & Userid & "," & YearId & ",0, GETDATE(), GETDATE()," & Userid & ")", "", "")
                        End If
                    End If
                    alParaval.Add(TEMPDT.Rows(0).Item("AIRLINENAME"))
                    TEMPDT.Clear()
                    TEMPCONN.Close()


                    'CHECK WHETHER SUPPLIER IS PRESENT IN ACCOUNTSMASTER OR NOT
                    'IF NOT THEN ADD LEDGER NAME FIRST
                    DTCHECK = OBJCMN.search("ACC_CMPNAME AS NAME", "", " LEDGERS ", " AND ACC_CMPNAME = '" & ROW("SUPPLIER_CODE") & "' AND ACC_YEARID = " & YearId)
                    If DTCHECK.Rows.Count = 0 Then
                        'ADD IN ACCOUNTSMASTER
                        'GET GROUPID AND ADD
                        TEMPDT = OBJCMN.search(" group_id AS GROUPID", "", " groupmaster ", " AND group_name = 'Sundry Debtors' and group_yearid = " & YearId)
                        DTCHECK = OBJCMN.Execute_Any_String("insert into AccountsMaster (acc_cmpname, acc_name, acc_code, acc_groupid, Acc_opbal , Acc_drcr , acc_cmpid, acc_locationid, acc_userid , acc_yearid,	acc_transfer, acc_created, ACC_ISLOCKED, ACC_MOBILE, ACC_CRDAYS, ACC_CRLIMIT, ACC_ADD) values('" & ROW("SUPPLIER_CODE") & "','" & ROW("SUPPLIER_CODE") & "','" & ROW("SUPPLIER_CODE") & "'," & TEMPDT.Rows(0).Item("GROUPID") & ",0,'', " & CmpId & ",0, " & Userid & "," & YearId & ",0,GETDATE(),0,'',0,0,'') ", "", "")
                    End If
                    alParaval.Add(ROW("SUPPLIER_CODE"))
                    TEMPDT.Dispose()



                    'CHECK WHETHER PARTYNAME IS PRESENT IN ACCOUNTSMASTER OR NOT
                    'IF NOT THEN ADD LEDGER NAME FIRST
                    DTCHECK = OBJCMN.search("ACC_CMPNAME AS NAME", "", " LEDGERS ", " AND ACC_CMPNAME = '" & ROW("COMPANY_NAME") & "' AND ACC_YEARID = " & YearId)
                    If DTCHECK.Rows.Count = 0 Then
                        'ADD IN ACCOUNTSMASTER
                        'GET GROUPID AND ADD
                        TEMPDT = OBJCMN.search(" group_id AS GROUPID", "", " groupmaster ", " AND group_name = 'Sundry Debtors' and group_yearid = " & YearId)
                        DTCHECK = OBJCMN.Execute_Any_String("insert into AccountsMaster (acc_cmpname, acc_name, acc_code, acc_groupid, Acc_opbal , Acc_drcr , acc_cmpid, acc_locationid, acc_userid , acc_yearid,	acc_transfer, acc_created, ACC_ISLOCKED, ACC_MOBILE, ACC_CRDAYS, ACC_CRLIMIT, ACC_ADD) values('" & ROW("COMPANY_NAME") & "','" & ROW("COMPANY_NAME") & "','" & ROW("COMPANY_NAME") & "'," & TEMPDT.Rows(0).Item("GROUPID") & ",0,'', " & CmpId & ",0, " & Userid & "," & YearId & ",0,GETDATE(),0,'',0,0,'') ", "", "")
                    End If
                    alParaval.Add(ROW("COMPANY_NAME"))
                    TEMPDT.Clear()



                    alParaval.Add(Format(Convert.ToDateTime(ROW("TravelDate")).Date, "MM/dd/yyyy"))
                    alParaval.Add(ROW("LOCAL_REF_NO"))
                    alParaval.Add(ROW("PNR"))


                    'PRINT NAME
                    alParaval.Add("")
                    alParaval.Add(Now.Date)
                    alParaval.Add(Now.Date)

                    Dim SPAN As TimeSpan = Now.Date.Subtract(Now.Date)
                    alParaval.Add(SPAN)
                    alParaval.Add("")   'FROM
                    alParaval.Add("")   'TO

                    alParaval.Add("")   'EMAILID
                    alParaval.Add("")   'MOBILENO

                    alParaval.Add(ROW("PNR_NUMBER"))
                    alParaval.Add(ROW("PNR_NUMBER"))   'AIRLINEPNR
                    alParaval.Add(ROW("TRANSACTION_ID"))   'CRS PNR 


                    alParaval.Add(Val(ROW("BASEFARE")))                     'TOTALBASIC
                    alParaval.Add(Val(0))                                   'TOTALYQ
                    alParaval.Add(Val(ROW("TAXES")))                        'TOTALTAXES
                    alParaval.Add(Val(ROW("BASEFARE")) + Val(ROW("TAXES"))) 'TOTALAMT


                    'PURCHASE VALUES
                    alParaval.Add(Val(ROW("BASEFARE")) + Val(ROW("TAXES"))) 'PURCHASEAMT
                    alParaval.Add(Val(ROW("BASEFARE")) + Val(ROW("TAXES"))) 'TOTALPURAMT
                    alParaval.Add(Val(0))   'DISCOUNTPER
                    alParaval.Add(Val(0))   'DISCOUNTRS
                    alParaval.Add(Val(ROW("BASEFARE")) + Val(ROW("TAXES"))) 'PURCHASE SUBTOTAL
                    alParaval.Add(Val(0))   'COMMPER
                    alParaval.Add(Val(0))   'COMMRS
                    alParaval.Add(Val(5))   '5 % FIXED TDSPER
                    alParaval.Add(Val(Val(ROW("TOTALDISCOUNT")) * 0.05))    '5% FIXED OF COMMISSION TDSRS
                    alParaval.Add(Val(0))   'PUREXTRACHGS
                    alParaval.Add(Val(ROW("BASEFARE")) + Val(ROW("TAXES")))   'PURNETTAMT

                    alParaval.Add(0)    'PURTAXONCOMM (CHECKBOX)


                    alParaval.Add("")       'PURTAXNAME
                    alParaval.Add(Val(0))   'PURTAXAMT
                    alParaval.Add("")       'PURADDTAXNAME
                    alParaval.Add(Val(0))   'PURADDTAXAMT

                    'PURCHASE DISCOUNT PERC, AMOUNT AND OTHER DISCOUNT
                    alParaval.Add(Val(0))   'PURDISCPER
                    alParaval.Add(Val(ROW("TOTALDISCOUNT")))   'PURDISCAMT
                    alParaval.Add(Val(0))   'PURADDDISCAMT

                    alParaval.Add("")       'PUROTHERCHGS
                    alParaval.Add(0)        'PUROTHERCHGSAMT


                    alParaval.Add(Val(0))   'PURROUNDOFF
                    alParaval.Add(Val(ROW("PURCHASEAMOUNT")))   'PURGRANDTOTAL

                    alParaval.Add(Val(ROW("TOTALPASSENGERCOUNT")))
                    alParaval.Add(UserName) 'BOOKEDBY
                    alParaval.Add("")       'SOURCE


                    'SALE VALUES
                    alParaval.Add(Val(ROW("BASEFARE")) + Val(ROW("TAXES")))    'TOTALSALEAMT
                    alParaval.Add(Val(0))   'OURCOMMPER
                    alParaval.Add(Val(0))   'OURCOMMRS
                    alParaval.Add(Val(0))   'DISCPER
                    alParaval.Add(Val(0))   'DISCRS
                    alParaval.Add(Val(0))   'EXTRACHGS
                    alParaval.Add(Val(ROW("BASEFARE")) + Val(ROW("TAXES")) - Val(ROW("TOTALDISCOUNT")))    'SUBTOTAL
                    alParaval.Add("")       'TAXNAME
                    alParaval.Add(Val(0))   'TAXAMT
                    alParaval.Add("")       'ADDTAXNAME
                    alParaval.Add(Val(0))   'ADDTAXAMT

                    'SALE DISCOUNT PERC, AMOUNT AND OTHER DISCOUNT
                    alParaval.Add(Val(0))   'DISCRECDPER
                    alParaval.Add(Val(ROW("TOTALDISCOUNT")))   'DISCRECDAMT
                    alParaval.Add(Val(0))   'SALETDSPER
                    alParaval.Add(Val(ROW("TDSCOMMISSION")))    'TDS 
                    alParaval.Add(Val(0))   'ADDDISCAMT


                    alParaval.Add("Other Charges")       'OTHERCHGS
                    alParaval.Add(Val(ROW("COMPANYMARKUP")))        'OTHERCHGSAMT

                    alParaval.Add(Val(0))       'ROUNDOFF
                    alParaval.Add(Val(ROW("COMPANYAMOUNT")))    'GRANDTOTAL

                    alParaval.Add("")   'REAMRKS
                    alParaval.Add(CurrencyToWord(Val(ROW("COMPANYAMOUNT"))))


                    alParaval.Add(Val(0))   'PURAMTPAID
                    alParaval.Add(Val(0))   'PUREXTRAAMT
                    alParaval.Add(Val(0))   'PURRETURN
                    alParaval.Add(Val(ROW("PURCHASEAMOUNT")))    'PURBALANCE
                    alParaval.Add(Val(0))   'SALEAMTREC
                    alParaval.Add(Val(0))   'SALEEXTRAAMT
                    alParaval.Add(Val(0))   'SALERETURN
                    alParaval.Add(Val(ROW("COMPANYAMOUNT")))    'SALEBALANCE

                    alParaval.Add(0)    'DONE

                    alParaval.Add(0)    'DISPUTE
                    alParaval.Add(0)    'BILLCHECKED
                    alParaval.Add(0)    'CHKREFUND
                    alParaval.Add(0)    'CHKFAILED
                    alParaval.Add(0)    'CHKTAXSERVCHGS
                    alParaval.Add("")   'GROUPDEPATURN
                    alParaval.Add(Val(0))   'ENQNO

                    alParaval.Add(CmpId)
                    alParaval.Add(Locationid)
                    alParaval.Add(Userid)
                    alParaval.Add(YearId)
                    alParaval.Add(0)

                    alParaval.Add(ROW("LEADPAXNAME") & " * " & Val(ROW("TOTALPASSENGERCOUNT"))) 'PAXNAMEFORACCOUNTS

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

                    'PASSENGER DETAIL GRID
                    Dim PASSDESC As String = ""
                    Dim SEX As String = ""
                    Dim PANNO As String = ""
                    Dim PASSPORT As String = ""
                    Dim ISSUED As String = ""

                    'FLIGHT GRID
                    Dim FLIGHTSRNO As String = ""
                    Dim BOOKSRNO As String = ""
                    Dim FROMSEC As String = ""
                    Dim TOSEC As String = ""
                    Dim FLIGHTNO As String = ""
                    Dim FLIGHTDATE As String = ""
                    Dim ARRIVES As String = ""
                    Dim FLIGHTCLASS As String = ""



                    'FETCH SECTORS AND CLASS FROM FLIGHTSEGMENT IN A TEMPVARIABLE AND THEN USE THAT BELOW
                    Dim TEMPSECTOR As String = ""
                    Dim TEMPCLASS As String = ""
                    TEMPCMD = New SqlCommand("SELECT Origin_airportcode AS FROMCODE, Destination_airportcode AS TOCODE, CABINCLASS, FLIGHTCLASS AS FLIGHTNO, DEPTIME, ARRTIME FROM flightsegment WHERE Request_No = '" & ROW("LOCAL_REF_NO") & "' ORDER BY SEGMENT_INDEX", TEMPCONN)
                    TEMPCONN.Open()
                    DA = New SqlDataAdapter(TEMPCMD)
                    DA.Fill(TEMPDT)
                    If TEMPDT.Rows.Count > 0 Then
                        Dim I As Integer = 1
                        For Each TEMPROW As DataRow In TEMPDT.Rows
                            If TEMPSECTOR = "" Then
                                TEMPSECTOR = TEMPROW("FROMCODE") & "/" & TEMPROW("TOCODE")
                                FLIGHTSRNO = I
                                BOOKSRNO = I    'THIS IS FOR FIRST RECORD, IF THERE ARE MULTIPLE PASSENGERS THEN WE WILL LOOP THIS SAME RECORD FURTHER NOT HERE
                                FROMSEC = TEMPROW("FROMCODE")
                                TOSEC = TEMPROW("TOCODE")
                                FLIGHTNO = TEMPROW("FLIGHTNO")
                                FLIGHTDATE = TEMPROW("DEPTIME")
                                ARRIVES = TEMPROW("ARRTIME")
                                FLIGHTCLASS = TEMPROW("CABINCLASS")
                            Else
                                TEMPSECTOR = TEMPSECTOR & "/" & TEMPROW("TOCODE")
                                FLIGHTSRNO = FLIGHTSRNO & "|" & I
                                BOOKSRNO = BOOKSRNO & "|" & I    'THIS IS FOR FIRST RECORD, IF THERE ARE MULTIPLE PASSENGERS THEN WE WILL LOOP THIS SAME RECORD FURTHER NOT HERE
                                FROMSEC = TOSEC & "|" & TEMPROW("FROMCODE")
                                TOSEC = TOSEC & "|" & TEMPROW("TOCODE")
                                FLIGHTNO = FLIGHTNO & "|" & TEMPROW("FLIGHTNO")
                                FLIGHTDATE = FLIGHTDATE & "|" & TEMPROW("DEPTIME")
                                ARRIVES = ARRIVES & "|" & TEMPROW("ARRTIME")
                                FLIGHTCLASS = FLIGHTCLASS & "|" & TEMPROW("CABINCLASS")
                            End If
                            I += 1
                        Next
                        TEMPCLASS = TEMPDT.Rows(0).Item("CABINCLASS")
                    End If
                    TEMPDT.Clear()
                    TEMPCONN.Close()


                    'GET PASSNAME AND TICKETNO FROM FLIGHTPAXTRAVELINFO TABLE WITH RESPECT TO REQUEST NO
                    TEMPCMD = New SqlCommand("SELECT DISTINCT  Title + ' ' + FirstName + ' ' + LastName AS PASSNAME FROM FlightPaxTravelInfo WHERE LOCAL_REF_NO = '" & ROW("LOCAL_REF_NO") & "'", TEMPCONN)
                    TEMPCONN.Open()
                    DA = New SqlDataAdapter(TEMPCMD)
                    DA.Fill(TEMPDT)
                    If TEMPDT.Rows.Count > 0 Then
                        Dim I As Integer = 1
                        For Each TEMPROW As DataRow In TEMPDT.Rows
                            If gridsrno = "" Then
                                gridsrno = I
                                PASSNAME = TEMPROW("PASSNAME")
                                SECTOR = TEMPSECTOR
                                FLTNO = ""
                                TYPE = "Adult"
                                'TICKETNO = TEMPROW("TICKETNO")
                                TICKETNO = ""
                                CLASSNAME = TEMPCLASS
                                BASIC = Format(Val(ROW("BASEFARE")) / Val(ROW("TOTALPASSENGERCOUNT")), "0.00")
                                PSF = 0
                                TAXES = Format(Val(ROW("TAXES")) / Val(ROW("TOTALPASSENGERCOUNT")), "0.00")
                                AMT = Format((Val(ROW("BASEFARE")) + Val(ROW("TAXES"))) / Val(ROW("TOTALPASSENGERCOUNT")), "0.00")
                                BCANCELLED = 0

                                'THESE PARAMETERS ARE FOR PASSGRID
                                PASSDESC = ""
                                SEX = ""
                                PANNO = ""
                                PASSPORT = ""
                                ISSUED = ""

                            Else
                                gridsrno = gridsrno & "|" & I
                                PASSNAME = PASSNAME & "|" & TEMPROW("PASSNAME")
                                SECTOR = SECTOR & "|" & TEMPSECTOR
                                FLTNO = FLTNO & "|" & ""
                                TYPE = TYPE & "|" & "Adult"
                                'TICKETNO = TICKETNO & "|" & TEMPROW("TICKETNO")
                                TICKETNO = TICKETNO & "|" & ""
                                CLASSNAME = CLASSNAME & "|" & TEMPCLASS
                                BASIC = BASIC & "|" & Format(Val(ROW("BASEFARE")) / Val(ROW("TOTALPASSENGERCOUNT")), "0.00")
                                PSF = PSF & "|" & 0
                                TAXES = TAXES & "|" & Format(Val(ROW("TAXES")) / Val(ROW("TOTALPASSENGERCOUNT")), "0.00")
                                AMT = AMT & "|" & Format((Val(ROW("BASEFARE")) + Val(ROW("TAXES"))) / Val(ROW("TOTALPASSENGERCOUNT")), "0.00")
                                BCANCELLED = BCANCELLED & "|" & "0"

                                'THESE PARAMETERS ARE FOR PASSGRID
                                PASSDESC = PASSDESC & "|" & ""
                                SEX = SEX & "|" & ""
                                PANNO = PANNO & "|" & ""
                                PASSPORT = PASSPORT & "|" & ""
                                ISSUED = ISSUED & "|" & ""

                            End If
                            I += 1
                        Next
                    End If
                    TEMPDT.Clear()
                    TEMPCONN.Close()


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


                    alParaval.Add(gridsrno)     'PASSGRIDSRNO
                    alParaval.Add(gridsrno)     'PASSBOOKINGGRIDSRNO
                    alParaval.Add(PASSNAME)     'PASSNAME
                    alParaval.Add(PASSDESC)     'DESC
                    alParaval.Add(TICKETNO)     'PASSTICKETNO
                    alParaval.Add(SEX)
                    alParaval.Add(PANNO)
                    alParaval.Add(PASSPORT)
                    alParaval.Add(ISSUED)



                    'PURCHASE GRID
                    alParaval.Add(gridsrno)     'PURGRIDSRNO
                    alParaval.Add(gridsrno)     'PURBOOKGRIDSRNO
                    alParaval.Add(PASSNAME)     'PURPASSNAME
                    alParaval.Add(TICKETNO)     'PURTICKETNO
                    alParaval.Add(BASIC)        'PURBASIC
                    alParaval.Add(PSF)          'PURYQ
                    alParaval.Add(TAXES)        'PURTAXES
                    alParaval.Add(AMT)          'PURAMT
                    alParaval.Add(BCANCELLED)   'PURCANCELLED




                    'FLIGHT GRID
                    'WE HAVE GOT THE RECORDS FOR ONLY 1 PASSENFER 
                    'WE HAVE TO LOOP IT FOR TOTALNOOFPASSENGERS
                    'FLIGHT GRID
                    Dim TEMPFLIGHTSRNO As String = FLIGHTSRNO
                    Dim TEMPBOOKSRNO As String = BOOKSRNO
                    Dim TEMPFROMSEC As String = FROMSEC
                    Dim TEMPTOSEC As String = TOSEC
                    Dim TEMPFLIGHTNO As String = FLIGHTNO
                    Dim TEMPFLIGHTDATE As String = FLIGHTDATE
                    Dim TEMPARRIVES As String = ARRIVES
                    Dim TEMPFLIGHTCLASS As String = FLIGHTCLASS


                    If Val(ROW("TOTALPASSENGERCOUNT")) > 1 Then
                        For I As Integer = 2 To Val(ROW("TOTALPASSENGERCOUNT"))
                            FLIGHTSRNO = FLIGHTSRNO & "|" & TEMPFLIGHTSRNO
                            BOOKSRNO = BOOKSRNO & "|" & I
                            FROMSEC = TOSEC & "|" & TEMPFROMSEC
                            TOSEC = TOSEC & "|" & TEMPTOSEC
                            FLIGHTNO = FLIGHTNO & "|" & TEMPFLIGHTNO
                            FLIGHTDATE = FLIGHTDATE & "|" & TEMPFLIGHTDATE
                            ARRIVES = ARRIVES & "|" & TEMPARRIVES
                            FLIGHTCLASS = FLIGHTCLASS & "|" & TEMPFLIGHTCLASS
                        Next
                    End If

                    alParaval.Add(FLIGHTSRNO)
                    alParaval.Add(BOOKSRNO)
                    alParaval.Add(FROMSEC)
                    alParaval.Add(TOSEC)
                    alParaval.Add(FLIGHTNO)
                    alParaval.Add(FLIGHTDATE)
                    alParaval.Add(ARRIVES)
                    alParaval.Add(FLIGHTCLASS)



                    alParaval.Add("")   'GRIDUPLOADSRNO
                    alParaval.Add("")   'GRIDREMARKS
                    alParaval.Add("")   'NAME
                    alParaval.Add("")   'IMGPATH
                    alParaval.Add("")   'NEWIMFPATH
                    alParaval.Add("")   'FILENAME


                    alParaval.Add(ClientName)


                    Dim OBJBOOKING As New ClsAirlineBookingMaster()
                    OBJBOOKING.alParaval = alParaval

                    Dim DTNO As DataTable = OBJBOOKING.save()

GOTONEXTRECORDRETURN:

                Next


            End If


            MsgBox("Sync Completed Successfully")
            CONN.Close()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub AIRTRINITYHOTELSYNC()
        Try

            Dim OBJCMN As New ClsCommon
            Dim requestUrl As String = "https://www.trinityairtravel.com/api/?action=gethoteldetails"
            Dim DS As DataSet = New DataSet("XMLDATA")
            DS.ReadXml(requestUrl)

            If DS.Tables.Count = 0 Then Exit Sub

            For Each row As DataRow In DS.Tables(0).Rows

                Dim IntResult As Integer
                Dim alParaval As New ArrayList

                alParaval.Add(row("NAME"))
                alParaval.Add("")           'HOTELTYPE
                alParaval.Add(row("uniqueid")) 'PERSON (WE HAVE ADDED UNIQUE ID)
                alParaval.Add(row("NAME"))  'CODE
                alParaval.Add("3")          'GRADE
                alParaval.Add("")           'GROUP OF HOTELS
                alParaval.Add("14:00")
                alParaval.Add("12:00")
                alParaval.Add(row("ADDRESS"))
                alParaval.Add("")           'ADD1
                alParaval.Add("")           'ADD2
                alParaval.Add("")           'AREA
                alParaval.Add("")           'STD
                alParaval.Add(row("CITY"))
                alParaval.Add("")           'ZIPCODE
                alParaval.Add("")           'STATE
                alParaval.Add("")           'COUNTRY
                alParaval.Add("")           'ALTNO
                alParaval.Add("0")          'TEL1 (MANDATORY)
                alParaval.Add("")           'MOBILENO
                alParaval.Add("")           'FAXNO
                alParaval.Add("")           'WEBSITE
                alParaval.Add("")           'EMAIL
                alParaval.Add(CmpId)
                alParaval.Add(Locationid)
                alParaval.Add(Userid)
                alParaval.Add(YearId)
                alParaval.Add(0)

                alParaval.Add("")           'AMENITIES


                'FIRST CHECK FOR ROOMTYPE IF NOT PRESENT THEN ADD NEW
                Dim DT As DataTable = OBJCMN.search("ROOMTYPE_NAME AS ROOMTYPE", "", " ROOMTYPEMASTER ", " AND ROOMTYPE_NAME = '" & row("roomcategory") & "' AND ROOMTYPE_YEARID = " & YearId)
                If DT.Rows.Count = 0 Then
                    Dim OBJROOMTYPE As New ClsRoomTypeMaster
                    OBJROOMTYPE.alParaval.Add(row("roomcategory"))
                    OBJROOMTYPE.alParaval.Add("")
                    OBJROOMTYPE.alParaval.Add(CmpId)
                    OBJROOMTYPE.alParaval.Add(Locationid)
                    OBJROOMTYPE.alParaval.Add(Userid)
                    OBJROOMTYPE.alParaval.Add(YearId)
                    OBJROOMTYPE.alParaval.Add(0)
                    Dim INTRES As Integer = OBJROOMTYPE.SAVE()
                End If


                'ROOMTYPE GRID
                alParaval.Add("1")          'GRIDSRNO
                alParaval.Add(row("ROOMCATEGORY"))
                alParaval.Add("1")          'NOOFROOMS
                alParaval.Add("0")          'RATE PER ROOM
                alParaval.Add("")           'IMGPATH
                alParaval.Add("")           'NEW IMGPATH

                
                alParaval.Add("")           'CNAME
                alParaval.Add("")           'DESIGNATION
                alParaval.Add("")           'CMOB
                alParaval.Add("")           'CEMAIL


                alParaval.Add(0)            'INVENTORY

                Dim OBJHOTEL As New ClsHotelMaster
                OBJHOTEL.alParaval = alParaval

                'CHECKING WHETHER HOTEL IS PRESENT IN DATABASE OR NOT
                'IF NOT THEN ADD NEW HOTEL OR ELSE UPDATE THE HOTELDATA
                'WE HAVE SAVED THE UNIQUEID FROM ONLINEDATABASE IN PERSON COLUMN
                DT = OBJCMN.search("HOTEL_ID AS HOTELID", "", " HOTELMASTER ", " AND HOTEL_PERSON = '" & Val(row("UNIQUEID")) & "' AND HOTEL_YEARID =" & YearId)
                If DT.Rows.Count = 0 Then
                    Dim INTRESHOSTEL As Integer = OBJHOTEL.save()
                Else
                    alParaval.Add(DT.Rows(0).Item("HOTELID"))
                    Dim INTRESHOSTEL As Integer = OBJHOTEL.update()
                End If


            Next


            'MsgBox("Sync Completed Successfully")
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub AIRTRINITYDOMITINERARYSYNC()
        Try

            Dim OBJCMN As New ClsCommon
            Dim requestUrl As String = "https://www.trinityairtravel.com/api/?action=getitinerarydetails"
            Dim DS As DataSet = New DataSet("XMLDATA")
            DS.ReadXml(requestUrl)

            If DS.Tables.Count = 0 Then Exit Sub

            'For tabno As Integer = 0 To DS.Tables.Count - 1
            '    MsgBox("TABLENAME : " & DS.Tables(tabno).TableName)
            '    For i As Integer = 0 To DS.Tables(tabno).Columns.Count - 1
            '        MsgBox(DS.Tables(tabno).Columns(i).ColumnName)
            '    Next
            'Next


            'For tabno As Integer = 0 To DS.Tables.Count - 1
            '    MsgBox("TABLENAME : " & DS.Tables(tabno).TableName)
            'For i As Integer = 0 To DS.Tables("B").Rows.Count - 1
            '    MsgBox(DS.Tables("FONT").Rows(i).Item("FONT_TEXT") & " DIV ID : " & DS.Tables("FONT").Rows(i).Item("DIV_ID") & " B ID : " & DS.Tables("FONT").Rows(i).Item("B_ID"))
            'Next
            'Next

            ' MsgBox(Convert.ToDateTime(UNITROW("ACTIVEDATES").ToString.Substring(0, 11)).Date)


            For Each DOMROW As DataRow In DS.Tables("Domestic").Rows
                For Each UNITROW As DataRow In DS.Tables("UNIT").Select("DOMESTIC_ID=" & DOMROW("DOMESTIC_ID"))

                    'HERE WE WILL ADD ITINERARYMASTER
                    'TOTALDAYS, ADULTRATE IN ITINERARYMASTER WILL BE UPDATED LATER WHEN WE PUNCH HOTEL DETAILS
                    'UPDATE VEHICLEDAYS ALSO LATER
                    Dim alParaval As New ArrayList

                    alParaval.Add("DOMESTIC")
                    alParaval.Add(UNITROW("NAME"))
                    alParaval.Add(UNITROW("NAME"))  'DISPLAYNAME
                    If UNITROW("ACTIVEDATES").ToString = "No active date after today" Then
                        alParaval.Add(AccFrom.Date)
                        alParaval.Add(AccTo.Date)
                    Else
                        If UNITROW("ACTIVEDATES").ToString.Length > 15 Then alParaval.Add(Convert.ToDateTime(UNITROW("ACTIVEDATES").ToString.Substring(0, 11)).Date) Else alParaval.Add(AccFrom.Date)
                        If UNITROW("ACTIVEDATES").ToString.Length > 15 Then alParaval.Add(Convert.ToDateTime(UNITROW("ACTIVEDATES").ToString.Substring(15, 11)).Date) Else alParaval.Add(AccTo.Date)
                    End If

                    alParaval.Add(0)            'ADULTRATE
                    alParaval.Add(0)            'EXTRADULTRATE
                    alParaval.Add(0)            'TOTALDAYS
                    alParaval.Add(0)            'CHILDWITHBED
                    alParaval.Add(0)            'CHILDRATE
                    alParaval.Add(0)            'CHILDBELOWRATE
                    alParaval.Add("")           'PDFPATH

                    alParaval.Add(UNITROW("PINCLUSIVE"))
                    alParaval.Add(UNITROW("PEXCLUSIVE"))
                    alParaval.Add(UNITROW("PTERMS"))
                    alParaval.Add("")           'REMARKS
                    alParaval.Add(0)            'SIMILAR
                    alParaval.Add("Per Person")

                    alParaval.Add(0)            'LUMPSUMCOST

                    alParaval.Add(CmpId)
                    alParaval.Add(Userid)
                    alParaval.Add(YearId)




                    '    'GRID AIRLINE
                    alParaval.Add("")       'Dim AIRSRNO As String = ""
                    alParaval.Add("")       '    Dim SECTOR As String = ""
                    alParaval.Add("")       '    Dim FLTNO As String = ""
                    alParaval.Add("")       '    Dim TYPE As String = ""
                    alParaval.Add("")       '    Dim BASIC As String = ""
                    alParaval.Add("")       '    Dim PSF As String = ""
                    alParaval.Add("")       '    Dim TAXES As String = ""
                    alParaval.Add("")       '    Dim AIRAMT As String = ""




                    '    'FLIGHT GRID
                    alParaval.Add("")       '    Dim FLIGHTSRNO As String = ""
                    alParaval.Add("")       '    Dim BOOKSRNO As String = ""
                    alParaval.Add("")       '    Dim FROMSEC As String = ""
                    alParaval.Add("")       '    Dim TOSEC As String = ""
                    alParaval.Add("")       '    Dim FLIGHTNO As String = ""
                    alParaval.Add("")       '    Dim FLIGHTDATE As String = ""
                    alParaval.Add("")       '    Dim ARRIVES As String = ""
                    alParaval.Add("")       '    Dim FLIGHTCLASS As String = ""



                    '    'GRID VEHICLE
                    For Each TRANSROW As DataRow In DS.Tables("TRANSPORT").Select("UNIT_ID=" & UNITROW("UNIT_ID"))
                        'THERE MAY BE MULTIPLE TRANSPORT TABLE 
                        'SO WE NEED TO LOOP ALL THOSE TABLES AND FIND WHICH IS THE DEFAULT ONE
                        'ONCE WE GET THE DEFAULT TABLE WE WILL EXIT THE FOR LOOP
                        Dim TTABLENO As Integer = 1
                        For Each TRANSDEFAULTROW As DataRow In DS.Tables("TRANSPORT" & TTABLENO).Select("TRANSPORT_ID=" & TRANSROW("TRANSPORT_ID"))
                            If TRANSDEFAULTROW("DEFAULT") = "Yes" Then
                                alParaval.Add("1")                                  '    Dim VEHICLESRNO As String = ""

                                'FIRST CHECK FOR VEHICLENAME IF NOT PRESENT THEN ADD NEW
                                Dim DT As DataTable = OBJCMN.search("VEHICLE_NAME AS VEHICLENAME", "", " VEHICLEMASTER ", " AND VEHICLE_NAME = '" & TRANSDEFAULTROW("VEHICLENAME") & "' AND VEHICLE_YEARID = " & YearId)
                                If DT.Rows.Count = 0 Then
                                    Dim OBJVEHICLE As New ClsVehicleMaster
                                    OBJVEHICLE.alParaval.Add("")
                                    OBJVEHICLE.alParaval.Add(TRANSDEFAULTROW("VEHICLENAME"))
                                    OBJVEHICLE.alParaval.Add("")
                                    OBJVEHICLE.alParaval.Add(CmpId)
                                    OBJVEHICLE.alParaval.Add(Locationid)
                                    OBJVEHICLE.alParaval.Add(Userid)
                                    OBJVEHICLE.alParaval.Add(YearId)
                                    OBJVEHICLE.alParaval.Add(0)
                                    Dim INTRES As Integer = OBJVEHICLE.SAVE()
                                End If

                                alParaval.Add(TRANSDEFAULTROW("VEHICLENAME"))       '    Dim VEHICLENAME As String = ""
                                alParaval.Add(TRANSDEFAULTROW("PERSON") & " SEATER") '    Dim DESCRIPTION As String = ""
                                alParaval.Add(0)                                '    Dim VEHICLEDAYS As String = "" (THIS WILL BE UPDATED LATER)
                                GoTo TRANSPORTADDED
                            End If
                        Next
                        TTABLENO += 1
                    Next
                    'THIS CODE IS WRITTEN IF NO DEFAULT TRANSPORT IS SELECTED IN SERVER DATABASE
                    alParaval.Add("")  '    Dim VEHICLESRNO As String = ""
                    alParaval.Add("") '    Dim VEHICLENAME As String = ""
                    alParaval.Add("") '    Dim DESCRIPTION As String = ""
                    alParaval.Add("") '    Dim VEHICLEDAYS As String = ""


TRANSPORTADDED:

                    '    'GRID MISC
                    alParaval.Add("")  '    Dim MISCSRNO As String = ""
                    alParaval.Add("") '    Dim MISCSERVICETYPE As String = ""
                    alParaval.Add("") '    Dim MISCREMARKS As String = ""


                    Dim TEMPITINERARYNO As Integer
                    Dim OBJITI As New ClsItineraryMaster()
                    OBJITI.alParaval = alParaval

                    'IF THIS ITINERARY IS ALREADY PRESENT IN DATABASE THEN UPDATE OR ELSE ADD NEW
                    Dim DTSEARCH As DataTable = OBJCMN.search("ITINERARY_NO AS ITINERARYNO", "", "ITINERARYMASTER", " AND ITINERARY_NAME ='" & UNITROW("NAME") & "' AND ITINERARY_YEARID = " & YearId)
                    If DTSEARCH.Rows.Count <= 0 Then
                        Dim DTNO As DataTable = OBJITI.SAVE()
                        TEMPITINERARYNO = DTNO.Rows(0).Item(0)
                    Else
                        alParaval.Add(DTSEARCH.Rows(0).Item("ITINERARYNO"))
                        TEMPITINERARYNO = DTSEARCH.Rows(0).Item("ITINERARYNO")
                        Dim IntResult As Integer = OBJITI.UPDATE()
                    End If



                    'WE WILL ADD HOTELS HERE
                    '    'GRID HOTEL
                    For Each HOTELROW As DataRow In DS.Tables("HOTEL").Select("UNIT_ID=" & UNITROW("UNIT_ID"))
                        'THERE MAY BE MULTIPLE HOTELS TABLE 
                        'WE WILL ADD ALL THE HOTELS MENTIOEND, COZ WE HAVE ALREADY GOT THE FILTERED XML
                        Dim TOTALNIGHTS As Integer
                        Dim ADULTRATE, EXTRAADULTRATE As Double
                        For I As Integer = 1 To 20
                            If DS.Tables.Contains("HOTEL" & I) = False Then GoTo HOTELSADDED
                            For Each HOTELDEFAULTROW As DataRow In DS.Tables("HOTEL" & I).Select("HOTEL_ID=" & HOTELROW("HOTEL_ID"))
                                alParaval.Clear()
                                alParaval.Add(Val(TEMPITINERARYNO))
                                alParaval.Add(I)                                  '    Dim HOTELSRNO As String = ""
                                alParaval.Add(HOTELDEFAULTROW("CITYNAME"))
                                alParaval.Add(HOTELDEFAULTROW("HOTELNAME"))
                                alParaval.Add(HOTELDEFAULTROW("ROOMCATEGORY"))
                                alParaval.Add(Val(HOTELDEFAULTROW("NIGHTS")))
                                alParaval.Add(DBNull.Value)

                                alParaval.Add(CmpId)
                                alParaval.Add(Userid)
                                alParaval.Add(YearId)
                                OBJITI.alParaval = alParaval
                                Dim INTRES As Integer = OBJITI.SAVEHOTEL()
                                TOTALNIGHTS += Val(HOTELDEFAULTROW("NIGHTS"))
                                If DS.Tables.Contains("PERIOD1") = False Then GoTo NORATE
                                ADULTRATE += DS.Tables("PERIOD1").Select("HOTEL" & I & "_ID = " & HOTELDEFAULTROW("HOTEL" & I & "_ID"))(0).Item("ADULTRATE")
                                'EXTRAADULTRATE += DS.Tables("PERIOD1").Select("HOTEL" & I & "_ID = " & HOTELDEFAULTROW("HOTEL" & I & "_ID"))(0).Item("EXTRARATE")
NORATE:
                            Next
                        Next

HOTELSADDED:

                        'UPDATE TOTALDAYS, ADULTRATE, EXTRADUKLTRATE IN ITINERARYMASTER
                        Dim DT As DataTable = OBJCMN.Execute_Any_String("UPDATE ITINERARYMASTER SET ITINERARY_TOTALDAYS = " & Val(TOTALNIGHTS) + 1 & ", ITINERARY_ADULTRATE = " & Val(ADULTRATE) & " WHERE ITINERARY_NO = " & Val(TEMPITINERARYNO) & " AND ITINERARY_YEARID = " & YearId, "", "")


                    Next

                Next
            Next


            'once all the ITINERARY MASTER ARE SAVED WE WILL UPDATE THE ITINERARY DESC
            'ONCE WE SAVE ITINERARYMASTER ADD ITINERARYDETAILS 
            'GRID ITINERARY
            Dim TEMPIT As New DataTable
            TEMPIT.Columns.Add("HEADER")
            TEMPIT.Columns.Add("DETAILS")
            TEMPIT.Columns.Add("NAME")
            TEMPIT.Columns.Add("LINENO")


            Dim LINENO As Integer = 0
            For Each FONTROW As DataRow In DS.Tables("FONT").Rows
                If DS.Tables("FONT").Columns.Contains("B_ID") = False Then GoTo NEXTBID
                If IsDBNull(FONTROW("B_ID")) = False Then
                    'GET DIVID FROM B TABLE
                    Dim TEMPID As Integer = DS.Tables("B").Select("B_ID = " & FONTROW("B_ID"))(0).Item("DIV_ID")
                    'NOW GET PITINERARYID FROM DIV TABLE
                    If IsDBNull(DS.Tables("DIV").Select("DIV_ID = " & TEMPID)(0).Item("PITINERARY_ID")) = False Then TEMPID = DS.Tables("DIV").Select("DIV_ID = " & TEMPID)(0).Item("PITINERARY_ID")
                    'NOW GET UNITID FROM PITINERARY TABLE
                    TEMPID = DS.Tables("PITINERARY").Select("PITINERARY_ID = " & TEMPID, "UNIT_ID")(0).Item("UNIT_ID")
                    'NOW GET UNITNAME FROM UNITTABLE
                    Dim TEMPNAME As String = DS.Tables("UNIT").Select("UNIT_ID = " & TEMPID, "NAME")(0).Item("NAME")
                    If FONTROW("FONT_TEXT") <> "" Then
                        LINENO += 1
                        TEMPIT.Rows.Add(FONTROW("FONT_TEXT"), "", TEMPNAME, LINENO) 'HEADER
                    End If
                Else

                    'NOW GET PITINERARYID FROM DIV TABLE
                    Dim TEMPID As Integer
                    If IsDBNull(DS.Tables("DIV").Select("DIV_ID = " & TEMPID)(0).Item("PITINERARY_ID")) = False Then TEMPID = DS.Tables("DIV").Select("DIV_ID = " & TEMPID, "PITINERARY_ID")(0).Item("PITINERARY_ID")
                    'NOW GET UNITID FROM PITINERARY TABLE
                    TEMPID = DS.Tables("PITINERARY").Select("PITINERARY_ID = " & TEMPID, "UNIT_ID")(0).Item("UNIT_ID")
                    'NOW GET UNITNAME FROM UNITTABLE
                    Dim TEMPNAME As String = DS.Tables("UNIT").Select("UNIT_ID = " & TEMPID, "NAME")(0).Item("NAME")
                    If FONTROW("FONT_TEXT") <> "" Then TEMPIT.Rows.Add("", FONTROW("FONT_TEXT"), TEMPNAME, LINENO) 'HEADER
                End If
NEXTBID:
            Next

            'Dim DV As New DataView(TEMPIT)
            'DV.Sort = "LINENO"

            'For Each row As DataRow In TEMPIT.Rows.count
            '    MsgBox("HEADER : " & row(0) & " DETAILS : " & row(1) & " NAME : " & row(2) & " LINENO : " & row(3))
            'Next

            For I As Integer = 1 To LINENO
                'GET RECORDS FROM TEMPID AND SAVE HERE
                Dim ALPARAVAL As New ArrayList
                'GET ITINERARYNAME AND ITS ID FROM DATABASE
                Dim TEMPNAME As String
                If IsDBNull(TEMPIT.Select("LINENO = '" & I & "'")(0).Item("NAME")) = False Then TEMPNAME = TEMPIT.Select("LINENO = '" & I & "'")(0).Item("NAME")
                Dim DT As DataTable = OBJCMN.search("ITINERARY_NO AS ITINERARYNO", "", "ITINERARYMASTER", " AND ITINERARY_NAME = '" & TEMPNAME & "' AND ITINERARY_YEARID = " & YearId)
                ALPARAVAL.Add(Val(DT.Rows(0).Item("ITINERARYNO")))

                ALPARAVAL.Add(1)

                ALPARAVAL.Add(TEMPIT.Select("DETAILS = '' AND LINENO = '" & I & "'")(0).Item("HEADER"))
                ALPARAVAL.Add(TEMPIT.Select("HEADER = '' AND LINENO = '" & I & "'")(0).Item("DETAILS"))
                ALPARAVAL.Add(DBNull.Value)     'IMAGE

                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Userid)
                ALPARAVAL.Add(YearId)

                Dim OBJITI As New ClsItineraryMaster
                OBJITI.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBJITI.SAVEITINERARY()
            Next


            MsgBox("Sync Completed Successfully")
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub AIRTRINITYENQUIRYSYNC()
        Try
            'USED FOR DATE PARSING
            Dim TEMP As DateTime


            Dim OBJCMN As New ClsCommon
            Dim requestUrl As String = "http://www.trinityairtravel.com/api/?action=getenquires"
            Dim DS As DataSet = New DataSet("XMLDATA")
            DS.ReadXml(requestUrl)

            If DS.Tables.Count = 0 Then Exit Sub

            'For i As Integer = 0 To DS.Tables("International").Columns.Count - 1
            '    MsgBox(DS.Tables("International").Columns(i).ColumnName)
            'Next

            'for domestic packages
            If DS.Tables.Contains("Domestic") = True Then
                For Each DOMROW As DataRow In DS.Tables("Domestic").Rows
                    For Each row As DataRow In DS.Tables("UNIT").Select("DOMESTIC_ID=" & DOMROW("DOMESTIC_ID"))

                        Dim IntResult As Integer
                        Dim alParaval As New ArrayList

                        If Not DateTime.TryParse(row("dateofinquiry"), TEMP) Then alParaval.Add(Now.Date) Else alParaval.Add(row("dateofinquiry"))
                        alParaval.Add(row("nameofgguest"))
                        alParaval.Add(row("mobile"))

                        alParaval.Add("")                   'EMAIL
                        alParaval.Add("DOMESTIC PACKAGE")
                        alParaval.Add("Pending")
                        alParaval.Add("")                   'CITY
                        alParaval.Add(row("DescriptionofInquiry"))
                        alParaval.Add("")                   'SOURCE
                        alParaval.Add(UserName)
                        alParaval.Add("")                   'ENQTRANSFERREDTO
                        If Not DateTime.TryParse(row("traveldate"), TEMP) Then alParaval.Add("") Else alParaval.Add(Format(Convert.ToDateTime(row("traveldate")).Date, "dd/MM/yyyy")) 'CHECKIN  
                        If Not DateTime.TryParse(row("traveldate"), TEMP) Then alParaval.Add("") Else alParaval.Add(Format(Convert.ToDateTime(row("traveldate")).Date, "dd/MM/yyyy")) 'CHECKOUT

                        alParaval.Add(row("placeofresidence"))
                        alParaval.Add(1)        'ADULTS
                        alParaval.Add(0)        'CHILDS
                        alParaval.Add(0)        'INFANTS
                        alParaval.Add(1)        'TOTALPAX
                        alParaval.Add(0)        'CHILDWITHOUTBED
                        alParaval.Add(0)        'EXTRAADULTS
                        alParaval.Add(0)        'ROOMS

                        alParaval.Add("")       'CLOSE REMARKS
                        alParaval.Add(CmpId)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)

                        Dim OBJMISCENQ As New ClsMiscEnquiry
                        OBJMISCENQ.alParaval = alParaval

                        'NO NEED OF UPDATE HERE, JUST SAVE NEW INQUIRY
                        Dim DT As DataTable = OBJMISCENQ.SAVE()
                    Next
                Next
            End If


            'FOR INTERNATIONAL PACKAGES
            If DS.Tables.Contains("International") = True Then
                For Each DOMROW As DataRow In DS.Tables("International").Rows
                    For Each row As DataRow In DS.Tables("UNIT").Select("INTERNATIONAL_ID=" & DOMROW("INTERNATIONAL_ID"))

                        Dim IntResult As Integer
                        Dim alParaval As New ArrayList

                        If Not DateTime.TryParse(row("dateofinquiry"), TEMP) Then alParaval.Add(Now.Date) Else alParaval.Add(row("dateofinquiry"))
                        alParaval.Add(row("nameofgguest"))
                        alParaval.Add(row("mobile"))

                        alParaval.Add("")                   'EMAIL
                        alParaval.Add("INTERNATIONAL PACKAGE")
                        alParaval.Add("Pending")
                        alParaval.Add("")                   'CITY
                        alParaval.Add(row("DescriptionofInquiry"))
                        alParaval.Add("")                   'SOURCE
                        alParaval.Add(UserName)
                        alParaval.Add("")                   'ENQTRANSFERREDTO
                        If Not DateTime.TryParse(row("traveldate"), TEMP) Then alParaval.Add("") Else alParaval.Add(Format(Convert.ToDateTime(row("traveldate")).Date, "dd/MM/yyyy")) 'CHECKIN  
                        If Not DateTime.TryParse(row("traveldate"), TEMP) Then alParaval.Add("") Else alParaval.Add(Format(Convert.ToDateTime(row("traveldate")).Date, "dd/MM/yyyy")) 'CHECKOUT

                        alParaval.Add(row("placeofresidence"))
                        alParaval.Add(1)        'ADULTS
                        alParaval.Add(0)        'CHILDS
                        alParaval.Add(0)        'INFANTS
                        alParaval.Add(1)        'TOTALPAX
                        alParaval.Add(0)        'CHILDWITHOUTBED
                        alParaval.Add(0)        'EXTRAADULTS
                        alParaval.Add(0)        'ROOMS

                        alParaval.Add("")       'CLOSE REMARKS
                        alParaval.Add(CmpId)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)

                        Dim OBJMISCENQ As New ClsMiscEnquiry
                        OBJMISCENQ.alParaval = alParaval

                        'NO NEED OF UPDATE HERE, JUST SAVE NEW INQUIRY
                        Dim DT As DataTable = OBJMISCENQ.SAVE()
                    Next
                Next
            End If


            MsgBox("Sync Completed Successfully")
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDFETCH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDFETCH.Click
        Try
            If ClientName = "SKYMAPS" Then
                If CHKSYNCHOTELS.CheckState = CheckState.Checked Then SKYMAPSHOTELSYNC()
                If CHKSYNCBOOKING.CheckState = CheckState.Checked Then SKYMAPSBOOKINGSYNC()
                MsgBox("Data Fetched Successfully")
                Me.Close()
            End If

            If ClientName = "AIRTRINITY" Then
                AIRTRINITYHOTELSYNC()
                AIRTRINITYDOMITINERARYSYNC()
                AIRTRINITYENQUIRYSYNC()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub SyncDate_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If ClientName = "AIRTRINITY" Then
                LBLFROM.Visible = False
                LBLTO.Visible = False
                FROMDATE.Visible = False
                TODATE.Visible = False
            End If

            If ClientName = "SKYMAPS" Then
                CHKSYNCHOTELS.Visible = True
                CHKSYNCBOOKING.Visible = True
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Friend Sub FILLGUESTNAME(trim As String)
        Throw New NotImplementedException()
    End Sub
End Class