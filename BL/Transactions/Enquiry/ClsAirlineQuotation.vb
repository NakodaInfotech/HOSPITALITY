
Imports DB

Public Class ClsAirlineQuotation

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
        Dim strCommand As String
        Try
            'save purchase Requisition
            strCommand = "SP_TRANS_BOOKING_AIRLINEQUOTE_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                '.Add(New SqlClient.SqlParameter("@PURREGISTERNAME", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@SALEREGISTERNAME", alParaval(I)))
                'I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKINGNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKINGDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CRSTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BSP", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COUPON", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@AIRLINENAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURACCNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACCNAME", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TICKETDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PARTYREFNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REFNO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PRINTNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DEPARTURE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ARRIVAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DURATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@EMAILADD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MOBILENO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PNRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AIRLINEPNR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CRSPNR", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@TOTALBASIC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPSF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALTAXES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALAMT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TOTALPURBASIC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPURPSF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPURTAXES", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@PURAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPURAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISCRECDPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISCRECDRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURSUBTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COMMRECDPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COMMRECDRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTDSPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTDSRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PUREXTRACHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURNETTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURCOMMTAX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTAX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURADDTAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURADDTAX", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PURDISCPERC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURDISCAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURADDDISCAMT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PUROTHERCHGSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PUROTHERCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURROUNDOFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURGRANDTOTAL", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@TOTALPAX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKEDBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SOURCE", alParaval(I)))
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

                'TDS ON DISCOUNT
                .Add(New SqlClient.SqlParameter("@SALETDSPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALETDSRS", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@SALEDISCPERC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALEDISCAMT", alParaval(I)))
                I = I + 1

             

                .Add(New SqlClient.SqlParameter("@SALEADDDISCAMT", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@OTHERCHGSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OTHERCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROUNDOFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRANDTOTAL", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INWORDS", alParaval(I)))
                I = I + 1


                '.Add(New SqlClient.SqlParameter("@PURAMTPAID", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@PUREXTRAAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@PURRETURN", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@PURBAL", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@SALEAMTREC", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@SALEEXTRAAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@SALERETURN", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@SALEBAL", alParaval(I)))
                'I = I + 1

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
                .Add(New SqlClient.SqlParameter("@TAXSERVCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOURNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HSNCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURHSNCODE", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@PURTAXSERVCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTAXSERVCHGSAMT", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@ENQNO", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@PAXNAMEFORACCOUNTS", alParaval(I)))
                I = I + 1



                'GRID PARAMETERS
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PASSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SECTOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TICKETNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLASS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BASIC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PSF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BCANCELLED", alParaval(I)))
                I = I + 1


                'PASS GRID PARAMETERS
                .Add(New SqlClient.SqlParameter("@PASSGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PASSBOOKGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PASSPASSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PASSDESC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PASSTICKETNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SEX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PANNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PASSPORT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ISSUED", alParaval(I)))
                I = I + 1


                'PUR GRID PARAMETERS
                .Add(New SqlClient.SqlParameter("@PURGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURBOOKGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURPASSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTICKETNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURBASIC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURPSF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTAXES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURGRIDAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURCANCELLED", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@CLIENTNAME", alParaval(I)))
                I = I + 1

            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

    Public Function SELECTBOOKING() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_TRANS_SELECT_AIRLINEQUOTE_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@BOOKINGNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@LOCATIONid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@YEARid", alParaval(3)))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function UPDATE() As DataTable
        'Dim intResult As Integer
        Dim DT As DataTable
        Dim strCommand As String
        Try
            'update purchase Requisition
            strCommand = "SP_TRANS_BOOKING_AIRLINEQUOTE_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                '.Add(New SqlClient.SqlParameter("@PURREGISTERNAME", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@SALEREGISTERNAME", alParaval(I)))
                'I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TBNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKINGDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CRSTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BSP", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COUPON", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@AIRLINENAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURACCNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACCNAME", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TICKETDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PARTYREFNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REFNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRINTNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DEPARTURE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ARRIVAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DURATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@EMAILADD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MOBILENO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PNRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AIRLINEPNR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CRSPNR", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TOTALBASIC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPSF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALTAXES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALAMT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TOTALPURBASIC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPURPSF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPURTAXES", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PURAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPURAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISCRECDPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISCRECDRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURSUBTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COMMRECDPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COMMRECDRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTDSPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTDSRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PUREXTRACHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURNETTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURCOMMTAX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTAX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURADDTAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURADDTAX", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PURDISCPERC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURDISCAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURADDDISCAMT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PUROTHERCHGSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PUROTHERCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURROUNDOFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURGRANDTOTAL", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@TOTALPAX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKEDBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SOURCE", alParaval(I)))
                I = I + 1
                '36 FIELDS

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

                'TDS ON DISCOUNT
                .Add(New SqlClient.SqlParameter("@SALETDSPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALETDSRS", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@SALEDISCPERC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALEDISCAMT", alParaval(I)))
                I = I + 1

              

                .Add(New SqlClient.SqlParameter("@SALEADDDISCAMT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@OTHERCHGSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OTHERCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROUNDOFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRANDTOTAL", alParaval(I)))
                I = I + 1
                '51 FIELDS

                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INWORDS", alParaval(I)))
                I = I + 1
                '53 FIELDS


                '.Add(New SqlClient.SqlParameter("@PURAMTPAID", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@PUREXTRAAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@PURRETURN", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@PURBAL", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@SALEAMTREC", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@SALEEXTRAAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@SALERETURN", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@SALEBAL", alParaval(I)))
                'I = I + 1
                '61 FIELDS

                .Add(New SqlClient.SqlParameter("@DONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISPUTE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLCHECKED", alParaval(I)))
                I = I + 1
                '64 FIELDS

                .Add(New SqlClient.SqlParameter("@REFUNDED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FAILED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXSERVCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOURNAME", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@HSNCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURHSNCODE", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@PURTAXSERVCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTAXSERVCHGSAMT", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@ENQNO", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@PAXNAMEFORACCOUNTS", alParaval(I)))
                I = I + 1

                '69 FIELDS


                'GRID PARAMETERS
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PASSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SECTOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TICKETNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLASS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BASIC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PSF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BCANCELLED", alParaval(I)))
                I = I + 1
                '80 FIELDS


                'PASS GRID PARAMETERS
                .Add(New SqlClient.SqlParameter("@PASSGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PASSBOOKGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PASSPASSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PASSDESC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PASSTICKETNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SEX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PANNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PASSPORT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ISSUED", alParaval(I)))
                I = I + 1
                '88 FIELDS


                'PUR GRID PARAMETERS
                .Add(New SqlClient.SqlParameter("@PURGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURBOOKGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURPASSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTICKETNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURBASIC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURPSF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTAXES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURGRIDAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURCANCELLED", alParaval(I)))
                I = I + 1
                '96 FIELDS


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

                ' SCAN DOCS
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

                .Add(New SqlClient.SqlParameter("@CLIENTNAME", alParaval(I)))
                I = I + 1
                '102 FIELDS

                .Add(New SqlClient.SqlParameter("@BOOKINGNO", alParaval(I)))
                I = I + 1

            End With
            'intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)
        Catch ex As Exception
            Throw ex
        End Try
        Return DT
    End Function

    Public Function CANCEL() As Integer
        Dim INTRESULT As Integer
        Try
            Dim strCommand As String = "SP_TRANS_BOOKING_AIRLINEQUOTE_CANCEL"
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
            Dim strCommand As String = "SP_TRANS_BOOKING_AIRLINEQUOTE_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@PURREGNAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@SALEREGNAME", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@BOOKINGNO", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@LOCATIONid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@YEARid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(6)))

            End With
            DTTABLE = objDBOperation.execute(strCommand, alParameter).Tables(0)
            Return DTTABLE
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
