
Imports DB

Public Class ClsRailBookingMaster

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
            Dim strCommand As String = "SP_TRANS_BOOKING_RAILBOOKING_SAVE"
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
                .Add(New SqlClient.SqlParameter("@JOURNEYDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOARDINGDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURACCNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACCNAME", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@ADULTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHILDS", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@LOGINID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PAYMODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRAINNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRAINNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLASS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ARRTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DEPTIME", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@STATIONFROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STATIONTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOARDINGFROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BFROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RESTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TICKETTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUOTA", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@FARE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IRCTC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GATEWAY", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@PURTAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTAX", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@SPECIALREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INWORDS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@FAREINWORDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IRCTCINWORDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GATEWAYINWORDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALINWORDS", alParaval(I)))
                I = I + 1
               
                .Add(New SqlClient.SqlParameter("@PURAMTPAID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PUREXTRAAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURRETURN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURBAL", alParaval(I)))
                I = I + 1
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

                .Add(New SqlClient.SqlParameter("@GROUPDEPRAILTYPE", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@AGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SEX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SEATNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DNRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDDN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDDNRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UP", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UPRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDUP", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDUPRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STATUS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IDTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IDNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONCESSION", alParaval(I)))
                I = I + 1


                'GUEST DETAILS
                .Add(New SqlClient.SqlParameter("@MOBILENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EMAILADD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REFNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISPUTE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLCHECKED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REFUNDED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FAILED", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CONFIRMEDBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONFIRMATIONNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLIENTNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ENQNO", alParaval(I)))
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

            Dim strCommand As String = "SP_TRANS_SELECT_RAILBOOKING_FOR_EDIT"
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

    Public Function update() As Integer
        Dim intResult As Integer
        Dim strCommand As String
        Try
            'update purchase Requisition
            strCommand = "SP_TRANS_BOOKING_RAILBOOKING_UPDATE"
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
                .Add(New SqlClient.SqlParameter("@JOURNEYDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOARDINGDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURACCNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACCNAME", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@ADULTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHILDS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@LOGINID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PAYMODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRAINNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRAINNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLASS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ARRTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DEPTIME", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@STATIONFROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STATIONTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOARDINGFROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BFROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RESTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TICKETTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUOTA", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@FARE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IRCTC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GATEWAY", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@PURTAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTAX", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@SPECIALREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INWORDS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@FAREINWORDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IRCTCINWORDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GATEWAYINWORDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALINWORDS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PURAMTPAID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PUREXTRAAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURRETURN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURBAL", alParaval(I)))
                I = I + 1
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

                .Add(New SqlClient.SqlParameter("@GROUPDEPRAILTYPE", alParaval(I)))
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
                'GRID PARAMETERS
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PASSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SEX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SEATNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DNRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDDN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDDNRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UP", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UPRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDUP", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDUPRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STATUS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IDTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IDNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONCESSION", alParaval(I)))
                I = I + 1


                'GUEST DETAILS
                .Add(New SqlClient.SqlParameter("@MOBILENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EMAILADD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REFNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISPUTE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLCHECKED", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@REFUNDED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FAILED", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CONFIRMEDBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONFIRMATIONNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLIENTNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ENQNO", alParaval(I)))
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
            Dim strCommand As String = "SP_TRANS_BOOKING_RAILBOOKING_CANCEL"
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
            Dim strCommand As String = "SP_TRANS_BOOKING_RAILBOOKING_DELETE"
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
            Dim strCommand As String = "SP_TRANS_BOOKING_RAILBOOKING_QRCODE"
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
