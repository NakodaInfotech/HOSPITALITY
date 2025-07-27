
Imports DB

Public Class ClsHolidayEnquiry

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
            Dim strCommand As String = "SP_TRANS_ENQUIRY_HOLIDAYENQ_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@ENQDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REFNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GUESTNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GUESTADD", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@ITINERARYNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOURNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKAGEFROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKAGETO", alParaval(I)))
                I = I + 1

               
                .Add(New SqlClient.SqlParameter("@ADULTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHILDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NCCHILDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPAX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GROUPDEPARTURE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MISCENQNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKAGETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUOTECALC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COSTPRICE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMDBOOKINGNO", alParaval(I)))
                I = I + 1
                

                '12 FIELDS



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
                '26 FIELDS


                'TOUR DETAILS
                '.Add(New SqlClient.SqlParameter("@TOURSRNO", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TOURDATE", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TOURDETAILS", alParaval(I)))
                'I = I + 1
                '29 FIELDS



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


                '37 FILEDS



                'SALE VALUES
                .Add(New SqlClient.SqlParameter("@TOTALMISCAMOUNT", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@OTHERCHGSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OTHERCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROUNDOFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRANDTOTAL", alParaval(I)))
                I = I + 1
                '51 FILEDS

                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKINGDESC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NOTESNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@POLICYNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NOTES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@POLICY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AVAILABILITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INWORDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUOTEPENDING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DONE", alParaval(I)))
                I = I + 1
                '57 FILEDS


                'for followup grid
                .Add(New SqlClient.SqlParameter("@FCHK", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@FSRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@FDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GIVENBY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GIVENTO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@STAGE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NARR", alParaval(I)))
                I += 1

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
                '64 FILEDS

                'GRID MISC
                .Add(New SqlClient.SqlParameter("@MISCSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MISCSERVICETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MISCREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MISCAMOUNT", alParaval(I)))
                I = I + 1

                'GRID  AIRLINE PARAMETERS
                .Add(New SqlClient.SqlParameter("@AIRSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SECTOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
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

                'GRID PURCHASE
                .Add(New SqlClient.SqlParameter("@PURSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURAMOUNT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURCURCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURROE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURREMARKS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CINCLUSION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CEXCLUSION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TINCLUSION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TEXCLUSION", alParaval(I)))
                I = I + 1

            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

    Public Function SAVETOUR() As Integer
        Dim INTRESULT As Integer
        Try
            Dim STRCOMMAND As String = "SP_TRANS_ENQUIRY_HOLIDAYENQ_SAVETOUR"
            Dim ALPARAMATER As New ArrayList
            With ALPARAMATER
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@ENQNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HEADER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DETAILS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IMGPATH", alParaval(I)))
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

    Public Function SELECTBOOKINGDESC() As DataTable
        Dim dtTable As DataTable
        Try
            Dim strCommand As String = "SP_TRANS_SELECT_HOLIDAYENQDESC_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@ENQNO", alParaval(0)))
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

            Dim strCommand As String = "SP_TRANS_SELECT_HOLIDAYENQTOURDETAILS_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@ENQNO", alParaval(0)))
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

            Dim strCommand As String = "SP_TRANS_SELECT_HOLIDAYENQTRANSDETAILS_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@ENQNO", alParaval(0)))
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
            Dim strCommand As String = "SP_TRANS_ENQUIRY_HOLIDAYENQ_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@ENQDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REFNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GUESTNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GUESTADD", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@ITINERARYNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOURNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKAGEFROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKAGETO", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@ADULTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHILDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NCCHILDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPAX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GROUPDEPARTURE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MISCENQNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKAGETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUOTECALC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COSTPRICE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMDBOOKINGNO", alParaval(I)))
                I = I + 1
                
                '12 FIELDS



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
                '26 FIELDS


                'TOUR DETAILS
                '.Add(New SqlClient.SqlParameter("@TOURSRNO", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TOURDATE", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TOURDETAILS", alParaval(I)))
                'I = I + 1
                '29 FIELDS



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


                '37 FILEDS



                'SALE VALUES
                .Add(New SqlClient.SqlParameter("@TOTALMISCAMOUNT", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@OTHERCHGSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OTHERCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROUNDOFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRANDTOTAL", alParaval(I)))
                I = I + 1
                '51 FILEDS

                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKINGDESC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NOTESNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@POLICYNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NOTES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@POLICY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AVAILABILITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INWORDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUOTEPENDING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DONE", alParaval(I)))
                I = I + 1
                '57 FILEDS


                'for followup grid
                .Add(New SqlClient.SqlParameter("@FCHK", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@FSRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@FDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GIVENBY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GIVENTO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@STAGE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NARR", alParaval(I)))
                I += 1


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
                '64 FILEDS

                'GRID MISC
                .Add(New SqlClient.SqlParameter("@MISCSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MISCSERVICETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MISCREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MISCAMOUNT", alParaval(I)))
                I = I + 1

                'GRID  AIRLINE PARAMETERS
                .Add(New SqlClient.SqlParameter("@AIRSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SECTOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
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

                'GRID PURCHASE
                .Add(New SqlClient.SqlParameter("@PURSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURAMOUNT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURCURCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURROE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURREMARKS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CINCLUSION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CEXCLUSION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TINCLUSION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TEXCLUSION", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@ENQNO", alParaval(I)))
                I = I + 1

            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function Delete() As Integer
        Dim INTRES As Integer
        Try
            Dim strCommand As String = "SP_TRANS_ENQUIRY_HOLIDAYENQ_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@ENQNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@LOCATIONid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@YEARid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@USERid", alParaval(4)))
            End With
            INTRES = objDBOperation.executeNonQuery(strCommand, alParameter)
            Return 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
