
Imports DB

Public Class ClsHotelBookingMaster

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
            If alParaval(0) = "BOOKING" Then
                strCommand = "SP_TRANS_BOOKING_HOTELBOOKING_SAVE"
            ElseIf alParaval(0) = "TRANSFER" Then
                strCommand = "SP_TRANS_BOOKING_HOTELBOOKING_TRANSFER_SAVE"
            End If
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURREGISTERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALEREGISTERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKINGNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKINGDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ENTRYDATEASBOOKINGDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKINGTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GUESTNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GUESTADD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HOTELNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURACCNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACCNAME", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@ARRIVALDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DEPARTDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ARRFROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DEPARTTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKIN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKOUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ARRFLIGHTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DEPARTFLIGHTNO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TOTALADULTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALCHILDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALNCCHILDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALEXTRAADULTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALEXTRACHILDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALROOMS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALAMT", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@PURTAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTAX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURADDTAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURADDTAX", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@TOTALNIGHTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKEDBY", alParaval(I)))
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


                .Add(New SqlClient.SqlParameter("@BOOKINGDESC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SPECIALREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PICKUPDETAILS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INWORDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DP", alParaval(I)))
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


                'GRID PARAMETERS
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROOMTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PLAN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADULTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHILDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NCCHILDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRAADULTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADULTRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRACHILDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHILDRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NOOFROOMS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKAGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CURCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMT", alParaval(I)))
                I = I + 1


                'PUR GRID PARAMETERS
                .Add(New SqlClient.SqlParameter("@PURGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURADULTRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURCHILDRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURGRIDAMT", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@CLIENTNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PREFIX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ENQNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NOTESNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@POLICYNAME", alParaval(I)))
                I = I + 1

                'MASTER
                .Add(New SqlClient.SqlParameter("@HSNCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURHSNCODE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@MANUALGST", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@PURTAXSERVCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PUROURCOMMPER", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PURMANUALGST", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@COMMINVRAISED", alParaval(I)))
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
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACKNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACKDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QRCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GUEST1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NOTES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@POLICY", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CINCLUSION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CEXCLUSION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TINCLUSION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TEXCLUSION", alParaval(I)))
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

    Public Function SAVEAMENDEDBOOKING() As DataTable

        Dim DT As DataTable
        Dim strCommand As String
        Try
            'save Amended purchase order
            If alParaval(0) = "BOOKING" Then
                strCommand = "SP_TRANS_BOOKING_HOTELBOOKING_SAVE_AMENDED"
            ElseIf alParaval(0) = "TRANSFER" Then
                strCommand = "SP_TRANS_BOOKING_HOTELBOOKING_TRANSFER_SAVE_AMENDED"
            End If
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURREGISTERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALEREGISTERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKINGDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ENTRYDATEASBOOKINGDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKINGTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GUESTNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GUESTADD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HOTELNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURACCNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACCNAME", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@ARRIVALDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DEPARTDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ARRFROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DEPARTTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKIN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKOUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ARRFLIGHTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DEPARTFLIGHTNO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TOTALADULTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALCHILDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALNCCHILDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALEXTRAADULTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALEXTRACHILDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALROOMS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALAMT", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@PURTAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTAX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURADDTAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURADDTAX", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@TOTALNIGHTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKEDBY", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@BOOKINGDESC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SPECIALREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PICKUPDETAILS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INWORDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DP", alParaval(I)))
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


                'GRID PARAMETERS
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROOMTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PLAN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADULTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHILDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NCCHILDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRAADULTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADULTRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRACHILDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHILDRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NOOFROOMS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKAGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMT", alParaval(I)))
                I = I + 1


                'PUR GRID PARAMETERS
                .Add(New SqlClient.SqlParameter("@PURGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURADULTRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURCHILDRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURGRIDAMT", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@CONFIRMEDBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONFIRMATIONNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLIENTNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PREFIX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ENQNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NOTES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@POLICY", alParaval(I)))
                I = I + 1

                'MASTER
                .Add(New SqlClient.SqlParameter("@HSNCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURHSNCODE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@MANUALGST", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@PURTAXSERVCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PUROURCOMMPER", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PURMANUALGST", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@COMMINVRAISED", alParaval(I)))
                I = I + 1

                'KEEP THIS ITS FOR ADJUSTING VALUE OF I
                I = I + 1
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

            Dim strCommand As String = "SP_TRANS_SELECT_HOTELBOOKING_FOR_AMENDMENT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@BOOKING_NO", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@LocationID", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(4)))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable


    End Function

    Public Function SELECTBOOKING() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_TRANS_SELECT_HOTELBOOKING_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@BOOKINGNO", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(4)))
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
            If alParaval(0) = "BOOKING" Then
                strCommand = "SP_TRANS_BOOKING_HOTELBOOKING_UPDATE"
            ElseIf alParaval(0) = "TRANSFER" Then
                strCommand = "SP_TRANS_BOOKING_HOTELBOOKING_TRANSFER_UPDATE"
            End If
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURREGISTERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALEREGISTERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TBNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKINGDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ENTRYDATEASBOOKINGDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKINGTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GUESTNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GUESTADD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HOTELNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURACCNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACCNAME", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@ARRIVALDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DEPARTDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ARRFROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DEPARTTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKIN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKOUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ARRFLIGHTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DEPARTFLIGHTNO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TOTALADULTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALCHILDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALNCCHILDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALEXTRAADULTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALEXTRACHILDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALROOMS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALAMT", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@PURTAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTAX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURADDTAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURADDTAX", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@TOTALNIGHTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKEDBY", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@BOOKINGDESC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SPECIALREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PICKUPDETAILS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INWORDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DP", alParaval(I)))
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


                'GRID PARAMETERS
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROOMTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PLAN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADULTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHILDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NCCHILDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRAADULTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADULTRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRACHILDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHILDRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NOOFROOMS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKAGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CURCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMT", alParaval(I)))
                I = I + 1


                'PUR GRID PARAMETERS
                .Add(New SqlClient.SqlParameter("@PURGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURADULTRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURCHILDRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURGRIDAMT", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@CLIENTNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PREFIX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ENQNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NOTESNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@POLICYNAME", alParaval(I)))
                I = I + 1


                'MASTER
                .Add(New SqlClient.SqlParameter("@HSNCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURHSNCODE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@MANUALGST", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@PURTAXSERVCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PUROURCOMMPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURMANUALGST", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@COMMINVRAISED", alParaval(I)))
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
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACKNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACKDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QRCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GUEST1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NOTES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@POLICY", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CINCLUSION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CEXCLUSION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TINCLUSION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TEXCLUSION", alParaval(I)))
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

    Public Function CANCEL() As Integer
        Dim INTRESULT As Integer
        Try
            Dim strCommand As String = "SP_TRANS_BOOKING_HOTELBOOKING_CANCEL"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@BOOKINGNO", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@LOCATIONid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@YEARid", alParaval(4)))
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
            Dim strCommand As String = "SP_TRANS_BOOKING_HOTELBOOKING_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@BOOKINGNO", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@LOCATIONid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@YEARid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(5)))

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
            Dim strCommand As String = "SP_TRANS_BOOKING_HOTELBOOKING_QRCODE"
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
