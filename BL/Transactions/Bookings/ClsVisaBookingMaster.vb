Imports DB

Public Class ClsVisaBookingMaster

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
            Dim strCommand As String = "SP_TRANS_BOOKING_VISABOOKING_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@BOOKINGNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKINGDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURREGISTERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALEREGISTERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKEDBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ENQUIRYBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REFNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ENQNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SOURCE", alParaval(I)))
                I = I + 1

              
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INWORDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSALEAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SERVICECHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MANUAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLCHECKED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLDISPUTE", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@TAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NETT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@OTHERCHGSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OTHERCHGS", alParaval(I)))
                I = I + 1
                '.Add(New SqlClient.SqlParameter("@CHARGES", alParaval(I)))
                'I = I + 1
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

                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PAXNAMEFORACCOUNTS", alParaval(I)))
                I = I + 1


                'GRID PARAMETERS
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PASSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PASSPORTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COUNTRY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SUBDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLLDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VISAFEES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VFS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MISC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SERVICE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMSRNO", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@PURSERVCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURNETTTOTAL", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@IRNNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACKNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACKDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QRCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GROUPDEPART", alParaval(I)))
                I = I + 1

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

            Dim strCommand As String = "SP_TRANS_SELECT_VISABOOKING_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@BOOKINGNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(1)))
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

            Dim strCommand As String = "SP_TRANS_SELECT_VISABOOKINGPURDETAILS_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@BOOKINGNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(1)))
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
            Dim strCommand As String = "SP_TRANS_BOOKING_VISABOOKING_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@TBNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKINGDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURREGISTERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALEREGISTERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKEDBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ENQUIRYBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REFNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ENQNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SOURCE", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INWORDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSALEAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SERVICECHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MANUAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLCHECKED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLDISPUTE", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@TAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NETT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OTHERCHGSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OTHERCHGS", alParaval(I)))
                I = I + 1
                '.Add(New SqlClient.SqlParameter("@CHARGES", alParaval(I)))
                'I = I + 1
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

                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PAXNAMEFORACCOUNTS", alParaval(I)))
                I = I + 1

                'GRID PARAMETERS
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PASSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PASSPORTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COUNTRY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SUBDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLLDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VISAFEES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VFS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MISC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SERVICE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMSRNO", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@PURSERVCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURNETTTOTAL", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@IRNNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACKNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACKDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QRCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GROUPDEPART", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@BOOKINGNO", alParaval(I)))
                I = I + 1

            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function DELETE() As DataTable
        Dim DTTABLE As DataTable
        Try
            Dim strCommand As String = "SP_TRANS_BOOKING_VISABOOKING_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@BOOKINGNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@YEARid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@USERid", alParaval(2)))
            End With
            DTTABLE = objDBOperation.execute(strCommand, alParameter).Tables(0)
            Return DTTABLE
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SAVEUPLOAD() As Integer

        Dim intResult As Integer
        Dim strcommand As String = ""

        Try

            'Update AccountsMaster
            strcommand = "SP_TRANS_BOOKING_VISABOOKING_SAVEUPLOAD"

            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@BOOKINGNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@IMGPATH", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I += 1

            End With

            intResult = objDBOperation.executeNonQuery(strcommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function SAVEQRCODE() As Integer
        Dim intResult As Integer
        Try
            'save SALE order
            Dim strCommand As String = "SP_TRANS_BOOKING_VISABOOKING_QRCODE"
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
