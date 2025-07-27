
Imports DB

Public Class ClsCarBooking

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

    Public Function SAVE() As DataTable
        Dim DT As DataTable
        Try
            'save purchase Requisition
            Dim strCommand As String = "SP_TRANS_BOOKING_CARBOOKING_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@PURREGISTERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALEREGISTERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKINGNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKINGDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REFNO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@GUESTNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PREFIX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKAGEFROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKAGETO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@HRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@KMS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HRKMRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HRSRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@KMSRATE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@HRSPUR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@KMSPUR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HRKMRATEPUR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HRSRATEPUR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@KMSRATEPUR", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@ALLOWANCEPUR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NIGHTALLOWANCEPUR", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@SUNDAYS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SUNDAYSRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRADROP", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRADROPRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTSTATIONDAYS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTSTATIONDAYSRATE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CITY", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@ARRIVAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DEPARTURE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALMISCAMOUNT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GROUPDEPART", alParaval(I)))
                I = I + 1
                ' FIELDS


                'CAR DETAILS
                .Add(New SqlClient.SqlParameter("@CARSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DRIVER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CARNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CARNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADULTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHILDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPAX", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@DAYS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROUTE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CARNOTE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@APPROXHRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@APPROXKMS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ALLOWANCE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CARAMT", alParaval(I)))
                I = I + 1
                ' FIELDS


                'TOUR DETAILS
                .Add(New SqlClient.SqlParameter("@TOURSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOURDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOURDETAILS", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@PURAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURDISCPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURDISC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURSUBTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURCOMMPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURCOMM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTDSPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTDS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PURSERVTAX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTAXSERVCHGS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PURNETT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTAX", alParaval(I)))
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
                ' FIELDS




                .Add(New SqlClient.SqlParameter("@BOOKEDBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SOURCE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@MISCENQNO", alParaval(I)))
                I = I + 1

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
                .Add(New SqlClient.SqlParameter("@EXTRACHGS", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@TAXSERVCHGSAMT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@OTHERCHGSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OTHERCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROUNDOFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRANDTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALEAMTREC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALEEXTRAAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALERETURN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALEBAL", alParaval(I)))
                I = I + 1
                ' FILEDS




                .Add(New SqlClient.SqlParameter("@STARTKMS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ENDKMS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STARTTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ENDTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURSTARTKMS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURENDKMS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURSTARTTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURENDTIME", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@CARQUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DRIVERQUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONFIRMEDBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKINGDESC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SPECIALREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INWORDS", alParaval(I)))
                I = I + 1
                ' FILEDS



                .Add(New SqlClient.SqlParameter("@DONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISPUTE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLCHECKED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOURNAME", alParaval(I)))
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
                ' FILEDS

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
                ' FILEDS
                .Add(New SqlClient.SqlParameter("@IRNNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ACKNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ACKDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@QRCODE", alParaval(I)))
                I += 1

            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

    Public Function SELECTBOOKINGDESC() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_TRANS_SELECT_CARBOOKINGDESC_FOR_EDIT"
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

    Public Function SELECTBOOKINGDUTYSLIP() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_TRANS_SELECT_CARBOOKINGDUTYSLIP_FOR_EDIT"
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

            Dim strCommand As String = "SP_TRANS_SELECT_CARBOOKINGPURDETAILS_FOR_EDIT"
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

            Dim strCommand As String = "SP_TRANS_SELECT_CARBOOKINGTOURDETAILS_FOR_EDIT"
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

    Public Function UPDATE() As Integer
        Dim intResult As Integer
        Try
            'update purchase Requisition
            Dim strCommand As String = "SP_TRANS_BOOKING_CARBOOKING_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@PURREGISTERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALEREGISTERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TBNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKINGDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REFNO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@GUESTNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PREFIX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKAGEFROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKAGETO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@HRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@KMS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HRKMRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HRSRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@KMSRATE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@HRSPUR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@KMSPUR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HRKMRATEPUR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HRSRATEPUR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@KMSRATEPUR", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@ALLOWANCEPUR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NIGHTALLOWANCEPUR", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@SUNDAYS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SUNDAYSRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRADROP", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRADROPRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTSTATIONDAYS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTSTATIONDAYSRATE", alParaval(I)))
                I = I + 1



                .Add(New SqlClient.SqlParameter("@CITY", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@ARRIVAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DEPARTURE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALMISCAMOUNT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GROUPDEPART", alParaval(I)))
                I = I + 1
                ' FIELDS




                'CAR DETAILS
                .Add(New SqlClient.SqlParameter("@CARSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DRIVER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CARNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CARNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADULTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHILDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPAX", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@DAYS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROUTE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CARNOTE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@APPROXHRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@APPROXKMS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ALLOWANCE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CARAMT", alParaval(I)))
                I = I + 1
                ' FIELDS


                'TOUR DETAILS
                .Add(New SqlClient.SqlParameter("@TOURSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOURDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOURDETAILS", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@PURAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURDISCPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURDISC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURSUBTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURCOMMPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURCOMM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTDSPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTDS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PURSERVTAX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTAXSERVCHGS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PURNETT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTAX", alParaval(I)))
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
                ' FIELDS




                .Add(New SqlClient.SqlParameter("@BOOKEDBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SOURCE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@MISCENQNO", alParaval(I)))
                I = I + 1

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
                .Add(New SqlClient.SqlParameter("@EXTRACHGS", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@TAXSERVCHGSAMT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@OTHERCHGSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OTHERCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROUNDOFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRANDTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALEAMTREC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALEEXTRAAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALERETURN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALEBAL", alParaval(I)))
                I = I + 1
                ' FILEDS



                .Add(New SqlClient.SqlParameter("@STARTKMS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ENDKMS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STARTTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ENDTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURSTARTKMS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURENDKMS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURSTARTTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURENDTIME", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@CARQUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DRIVERQUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONFIRMEDBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKINGDESC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SPECIALREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INWORDS", alParaval(I)))
                I = I + 1
                ' FILEDS



                .Add(New SqlClient.SqlParameter("@DONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISPUTE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLCHECKED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOURNAME", alParaval(I)))
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
                ' FILEDS

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
                ' FILEDS
                .Add(New SqlClient.SqlParameter("@IRNNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ACKNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ACKDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@QRCODE", alParaval(I)))
                I += 1

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
            Dim strCommand As String = "SP_TRANS_BOOKING_CARBOOKING_CANCEL"
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
            Dim strCommand As String = "SP_TRANS_BOOKING_CARBOOKING_DELETE"
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

    Public Function SAVEQRCODE() As Integer
        Dim intResult As Integer
        Try
            'save SALE order
            Dim strCommand As String = "SP_TRANS_BOOKING_CARBOOKING_QRCODE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@BOOKINGNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QRCODE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I += 1

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

#End Region

End Class
