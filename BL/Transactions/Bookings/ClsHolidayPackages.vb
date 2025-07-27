
Imports DB

Public Class ClsHolidayPackages

    Private objDBOperation As DBOperation
    Public alParaval As New ArrayList

#Region "Constructor"
    Public Sub New()
        Try
            objDBOperation = New DBOperation()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Functions"

    Public Function save() As DataTable
        Dim DT As DataTable
        Try
            'save purchase Requisition
            Dim strCommand As String = "SP_TRANS_BOOKING_HOLIDAYPACKAGE_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@BOOKINGNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURREGISTERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALEREGISTERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKINGDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GUEST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EMAILADD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MOBILENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GUESTADD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REFNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACCNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOURNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKAGETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUOTECALC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKAGEFROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKAGETO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ARRIVALFROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DEPARTTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ARRFLIGHTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DEPARTFLIGHTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADULTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHILDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NCCHILDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPAX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GROUPDEPART", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALMISCAMOUNT", alParaval(I)))
                I = I + 1
                '15 FIELDS



                'GUEST DETAILS
                .Add(New SqlClient.SqlParameter("@GUESTSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GUESTNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SEX", alParaval(I)))
                I = I + 1

                '19 FIELDS


                'BOOKING DETAILS
                .Add(New SqlClient.SqlParameter("@ACCDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HOTELNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONFNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONFBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INCLUSIONS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKIN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKOUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROOMTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PLAN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BADULTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BCHILDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BINFANTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BEXTRAADULTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BEXTRAADULTSRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BEXTRACHILDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BEXTRACHILDSRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BTOTALPAX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NOOFROOMS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKAGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHILDRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INFANTRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CURCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NIGHTS", alParaval(I)))
                I = I + 1
                '30 FIELDS


                'TOUR DETAILS
                '.Add(New SqlClient.SqlParameter("@TOURSRNO", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TOURHEADER", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TOURDETAILS", alParaval(I)))
                'I = I + 1
                '33 FIELDS



                'TRANS PARAMETER
                .Add(New SqlClient.SqlParameter("@CARSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONTACTPERSON", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONTACTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CARTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CARNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CARADULTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CARCHILDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CARTOTALPAX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PICKUPON", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PICKUPFROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PICKUPTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PICKUPDTLS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DROPON", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DROPAT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DROPTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DROPDTLS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CARDAYS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROUTE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CARITINERARY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CARNOTE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CARAMT", alParaval(I)))
                I = I + 1



                'PURCHASE DETAILS
                .Add(New SqlClient.SqlParameter("@PURBILLCHECKED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURHSNCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PUREXTRAADULTRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PUREXTRACHILDRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURDISCRECDPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURDISCRECD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURSUBTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURCOMMRECDPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURCOMMRECD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTDSPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURSERVTAX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURSERVCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURNETTTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTAX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURADDTAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURADDTAX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURCGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURCGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURSGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURSGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURIGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURIGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURCESSPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURCESSAMT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PUROTHERCHGSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PUROTHERCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURROUNDOFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURGTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURAMTPAID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PUREXTRAAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURRETURN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURBALANCE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPURAMT", alParaval(I)))
                I = I + 1
                '60 FIELDS


                'SALE DETAILS
                .Add(New SqlClient.SqlParameter("@EXTRAADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRAADULTRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRACHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRACHILDRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKEDBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALNIGHTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALROOMS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SOURCE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AGENTNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AGENTCOMMPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AGENTCOMMRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AGENTTDSPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AGENTTDSRS", alParaval(I)))
                I = I + 1
               
                '72 FILEDS



                'SALE VALUES
                .Add(New SqlClient.SqlParameter("@TOTALTRANSAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSALEAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OURCOMMPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OURCOMMRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISCPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISCRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SUBTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADDTAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADDTAXAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXSERVCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OTHERCHGSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OTHERCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROUNDOFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRANDTOTAL", alParaval(I)))
                I = I + 1
                '86 FILEDS

                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKINGDESC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SPECIALREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PICKUP", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INWORDS", alParaval(I)))
                I = I + 1
                '91 FILEDS


                .Add(New SqlClient.SqlParameter("@SALEAMTREC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALEEXTRAAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALERETURN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALEBAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISPUTE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLCHECKED", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@REFUNDED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FAILED", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@USERPOINTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REFPOINTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DONTPOSTPURSERVCHGS", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSFER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLIENTNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ENQNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NOTES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@POLICY", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@HSNCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MANUALGST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURMANUALGST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CESSPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CESSAMT", alParaval(I)))
                I = I + 1

                '103 FILEDS

                'GRID  AIRLINE PARAMETERS
                .Add(New SqlClient.SqlParameter("@AIRSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SECTOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AIRLINETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BASIC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PSF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AIRAMT", alParaval(I)))
                I = I + 1


                'FLIGHT PARAMETERS
                .Add(New SqlClient.SqlParameter("@FLIGHTSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMSEC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOSEC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLIGHTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLIGHTDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ARRIVES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLIGHTCLASS", alParaval(I)))
                I = I + 1

                'GRID MISC
                .Add(New SqlClient.SqlParameter("@MISCSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MISCSERVICETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MISCREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MISCAMOUNT", alParaval(I)))
                I = I + 1

                'SCAN DOCS
                .Add(New SqlClient.SqlParameter("@GRIDUPLOADSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UPLOADREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UPLOADNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IMGPATH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NEWIMGPATH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FILENAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IRNNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ACKNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ACKDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@QRCODE", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@CINCLUSION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CEXCLUSION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TINCLUSION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TEXCLUSION", alParaval(I)))
                I = I + 1
                '109 FILEDS

            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

    Public Function SAVEAMENDEDBOOKING() As DataTable

        Dim DT As DataTable
        Try
            'save Amended purchase order
            Dim strCommand As String = "SP_TRANS_BOOKING_HOLIDAYPACKAGE_SAVE_AMENDED"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@PURREGISTERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALEREGISTERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKINGDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EMAILADD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MOBILENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GUESTADD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REFNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACCNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOURNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKAGEFROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKAGETO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ARRIVALFROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DEPARTTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ARRFLIGHTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DEPARTFLIGHTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADULTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHILDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NCCHILDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPAX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GROUPDEPART", alParaval(I)))
                I = I + 1

                '15 FIELDS



                'GUEST DETAILS
                .Add(New SqlClient.SqlParameter("@GUESTSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GUESTNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SEX", alParaval(I)))
                I = I + 1

                '19 FIELDS


                'BOOKING DETAILS
                .Add(New SqlClient.SqlParameter("@ACCDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HOTELNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONFNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONFBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INCLUSIONS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKIN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKOUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROOMTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PLAN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BADULTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BCHILDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BINFANTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BEXTRAADULTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BEXTRAADULTSRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BEXTRACHILDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BEXTRACHILDSRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BTOTALPAX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NOOFROOMS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKAGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NIGHTS", alParaval(I)))
                I = I + 1
                '30 FIELDS



                'TRANS PARAMETER
                .Add(New SqlClient.SqlParameter("@CARSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONTACTPERSON", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONTACTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CARTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CARNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CARADULTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CARCHILDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CARTOTALPAX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PICKUPON", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PICKUPFROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PICKUPTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PICKUPDTLS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DROPON", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DROPAT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DROPTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DROPDTLS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CARDAYS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROUTE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CARITINERARY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CARNOTE", alParaval(I)))
                I = I + 1



                ''TOUR DETAILS
                '.Add(New SqlClient.SqlParameter("@TOURSRNO", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TOURHEADER", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TOURDETAILS", alParaval(I)))
                'I = I + 1
                ''33 FIELDS



                'PURCHASE DETAILS
                .Add(New SqlClient.SqlParameter("@PURBILLCHECKED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURHSNCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PUREXTRAADULTRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PUREXTRACHILDRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURDISCRECDPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURDISCRECD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURSUBTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURCOMMRECDPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURCOMMRECD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTDSPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURSERVTAX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURSERVCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURNETTTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTAX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURADDTAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURADDTAX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURCGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURCGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURSGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURSGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURIGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURIGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURCESSPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURCESSAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PUROTHERCHGSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PUROTHERCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURROUNDOFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURGTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURAMTPAID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PUREXTRAAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURRETURN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURBALANCE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPURAMT", alParaval(I)))
                I = I + 1
                '60 FIELDS


                'SALE DETAILS
                .Add(New SqlClient.SqlParameter("@EXTRAADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRAADULTRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRACHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRACHILDRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKEDBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALNIGHTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALROOMS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SOURCE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AGENTNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AGENTCOMMPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AGENTCOMMRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AGENTTDSPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AGENTTDSRS", alParaval(I)))
                I = I + 1
                '72 FILEDS



                'SALE VALUES
                .Add(New SqlClient.SqlParameter("@TOTALSALEAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OURCOMMPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OURCOMMRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISCPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISCRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SUBTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADDTAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADDTAXAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OTHERCHGSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OTHERCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROUNDOFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRANDTOTAL", alParaval(I)))
                I = I + 1
                '86 FILEDS

                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKINGDESC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SPECIALREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PICKUP", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INWORDS", alParaval(I)))
                I = I + 1
                '91 FILEDS


                .Add(New SqlClient.SqlParameter("@SALEAMTREC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALEEXTRAAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALERETURN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALEBAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISPUTE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLCHECKED", alParaval(I)))
                I = I + 1
                '98 FILEDS


                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSFER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLIENTNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ENQNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NOTES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@POLICY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HSNCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MANUALGST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURMANUALGST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CESSPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CESSAMT", alParaval(I)))
                I = I + 1

                '103 FILEDS

                .Add(New SqlClient.SqlParameter("@BOOKING_AMDNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKING_PREVIOUSLYAMDVALUE", alParaval(I)))
                I = I + 1

            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

    Public Function SELECTBOOKINGFORAMEND() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_TRANS_SELECT_HOLIDAYPACKAGE_FOR_AMENDMENT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@BOOKING_NO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@LocationID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(3)))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable


    End Function

    Public Function SELECTBOOKINGDESC() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_TRANS_SELECT_HOLIDAYPACKAGEDESC_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@BOOKINGNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(3)))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function SELECTBOOKINGGUESTDETAILS() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_TRANS_SELECT_HOLIDAYPACKAGEGUESTDETAILS_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@BOOKINGNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(3)))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function SELECTBOOKINGTOURDETAILS() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_TRANS_SELECT_HOLIDAYPACKAGETOURDETAILS_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@BOOKINGNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(3)))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function SELECTBOOKINGTRANSDETAILS() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_TRANS_SELECT_HOLIDAYPACKAGETRANSDETAILS_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@BOOKINGNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(3)))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function SELECTBOOKINGPURDETAILS() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_TRANS_SELECT_HOLIDAYPACKAGEPURDETAILS_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@BOOKINGNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(3)))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function update() As Integer
        Dim intResult As Integer
        Try
            'update purchase Requisition
            Dim strCommand As String = "SP_TRANS_BOOKING_HOLIDAYPACKAGE_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@TBNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURREGISTERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALEREGISTERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKINGDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GUEST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EMAILADD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MOBILENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GUESTADD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REFNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACCNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOURNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKAGETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUOTECALC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKAGEFROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKAGETO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ARRIVALFROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DEPARTTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ARRFLIGHTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DEPARTFLIGHTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADULTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHILDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NCCHILDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPAX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GROUPDEPART", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALMISCAMOUNT", alParaval(I)))
                I = I + 1
                '15 FIELDS



                'GUEST DETAILS
                .Add(New SqlClient.SqlParameter("@GUESTSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GUESTNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SEX", alParaval(I)))
                I = I + 1

                '19 FIELDS


                'BOOKING DETAILS
                .Add(New SqlClient.SqlParameter("@ACCDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HOTELNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONFNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONFBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INCLUSIONS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKIN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKOUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROOMTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PLAN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BADULTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BCHILDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BINFANTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BEXTRAADULTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BEXTRAADULTSRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BEXTRACHILDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BEXTRACHILDSRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BTOTALPAX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NOOFROOMS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKAGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHILDRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INFANTRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CURCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NIGHTS", alParaval(I)))
                I = I + 1
                '30 FIELDS



                'TOUR DETAILS
                '.Add(New SqlClient.SqlParameter("@TOURSRNO", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TOURHEADER", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TOURDETAILS", alParaval(I)))
                'I = I + 1
                '33 FIELDS



                'TRANS PARAMETER
                .Add(New SqlClient.SqlParameter("@CARSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONTACTPERSON", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONTACTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CARTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CARNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CARADULTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CARCHILDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CARTOTALPAX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PICKUPON", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PICKUPFROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PICKUPTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PICKUPDTLS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DROPON", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DROPAT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DROPTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DROPDTLS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CARDAYS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROUTE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CARITINERARY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CARNOTE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CARAMT", alParaval(I)))
                I = I + 1



                'PURCHASE DETAILS
                .Add(New SqlClient.SqlParameter("@PURBILLCHECKED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURDATE", alParaval(I)))
                I = I + 1
               
                .Add(New SqlClient.SqlParameter("@PURHSNCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PUREXTRAADULTRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PUREXTRACHILDRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURDISCRECDPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURDISCRECD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURSUBTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURCOMMRECDPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURCOMMRECD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTDSPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURSERVTAX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURSERVCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURNETTTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTAX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURADDTAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURADDTAX", alParaval(I)))
                I = I + 1
            
                .Add(New SqlClient.SqlParameter("@PURCGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURCGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURSGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURSGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURIGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURIGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURCESSPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURCESSAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PUROTHERCHGSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PUROTHERCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURROUNDOFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURGTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURAMTPAID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PUREXTRAAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURRETURN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURBALANCE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPURAMT", alParaval(I)))
                I = I + 1
                '60 FIELDS


                'SALE DETAILS
                .Add(New SqlClient.SqlParameter("@EXTRAADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRAADULTRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRACHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRACHILDRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKEDBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALNIGHTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALROOMS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SOURCE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AGENTNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AGENTCOMMPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AGENTCOMMRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AGENTTDSPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AGENTTDSRS", alParaval(I)))
                I = I + 1
                '72 FILEDS



                'SALE VALUES
                .Add(New SqlClient.SqlParameter("@TOTALTRANSAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSALEAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OURCOMMPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OURCOMMRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISCPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISCRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SUBTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADDTAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADDTAXAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXSERVCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OTHERCHGSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OTHERCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROUNDOFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRANDTOTAL", alParaval(I)))
                I = I + 1
                '86 FILEDS


                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKINGDESC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SPECIALREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PICKUP", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INWORDS", alParaval(I)))
                I = I + 1
                '91 FILEDS


                .Add(New SqlClient.SqlParameter("@SALEAMTREC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALEEXTRAAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALERETURN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALEBAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISPUTE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLCHECKED", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@REFUNDED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FAILED", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@USERPOINTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REFPOINTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DONTPOSTPURSERVCHGS", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSFER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLIENTNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ENQNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NOTES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@POLICY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HSNCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MANUALGST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURMANUALGST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CESSPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CESSAMT", alParaval(I)))
                I = I + 1
                '103 FILEDS

                'GRID  AIRLINE PARAMETERS
                .Add(New SqlClient.SqlParameter("@AIRSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SECTOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AIRLINETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BASIC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PSF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AIRAMT", alParaval(I)))
                I = I + 1


                'FLIGHT PARAMETERS
                .Add(New SqlClient.SqlParameter("@FLIGHTSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMSEC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOSEC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLIGHTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLIGHTDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ARRIVES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLIGHTCLASS", alParaval(I)))
                I = I + 1

                'GRID MISC
                .Add(New SqlClient.SqlParameter("@MISCSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MISCSERVICETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MISCREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MISCAMOUNT", alParaval(I)))
                I = I + 1


               

                'SCAN DOCS
                .Add(New SqlClient.SqlParameter("@GRIDUPLOADSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UPLOADREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UPLOADNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IMGPATH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NEWIMGPATH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FILENAME", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@IRNNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ACKNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ACKDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@QRCODE", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@CINCLUSION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CEXCLUSION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TINCLUSION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TEXCLUSION", alParaval(I)))
                I = I + 1

                '109 FIELDS

                .Add(New SqlClient.SqlParameter("@BOOKINGNO", alParaval(I)))
                I = I + 1

            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function CANCEL() As Integer
        Dim INTRESULT As Integer
        Try
            Dim strCommand As String = "SP_TRANS_BOOKING_HOLIDAYPACKAGE_CANCEL"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@BOOKINGNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@LOCATIONid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@YEARid", alParaval(3)))
            End With
            INTRESULT = objDBOperation.executeNonQuery(strCommand, alParameter)
            Return INTRESULT
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Delete() As DataTable
        Dim DTTABLE As DataTable
        Try
            Dim strCommand As String = "SP_TRANS_BOOKING_HOLIDAYPACKAGE_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@BOOKINGNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@LOCATIONid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@YEARid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(4)))

            End With
            DTTABLE = objDBOperation.execute(strCommand, alParameter).Tables(0)
            Return DTTABLE
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SAVETOUR() As Integer
        Dim INTRESULT As Integer
        Try
            Dim STRCOMMAND As String = "SP_TRANS_BOOKING_HOLIDAYPACKAGE_SAVETOUR"
            Dim ALPARAMATER As New ArrayList
            With ALPARAMATER
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@BOOKINGNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOURSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOURHEADER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOURDETAILS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I = I + 1
            End With

            INTRESULT = objDBOperation.executeNonQuery(STRCOMMAND, ALPARAMATER)

        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

End Class
