Imports DB

Public Class ClsMiscPurchase
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

    Public Function SELECTBOOKING() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_TRANS_SELECT_MISCPURBOOKING_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@BOOKINGNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@REGNAME", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@LOCATIONid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@YEARid", alParaval(4)))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function save() As DataTable
        Dim DT As DataTable
        Dim strCommand As String
        Try
            'save purchase Requisition

            strCommand = "SP_TRANS_BOOKING_MISC_PUR_SAVE"

            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0


            
                .Add(New SqlClient.SqlParameter("@PURREGISTERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKINGDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACCNAME", alParaval(I)))
                I = I + 1

                
                .Add(New SqlClient.SqlParameter("@FINALPURAMOUNT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISCRECDPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISCRECDRS", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@PURSUBTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTAX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURADDTAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURADDTAX", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TAXSERVCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXSERVCHGSAMT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PUROTHERCHGSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PUROTHERCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURROUNDOFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURGRANDTOTAL", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@BOOKEDBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SOURCE", alParaval(I)))
                I = I + 1
                
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKINGDESC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SPECIALREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INWORDS", alParaval(I)))
                I = I + 1
                
                .Add(New SqlClient.SqlParameter("@PURAMTPAID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PUREXTRAAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURRETURN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURBAL", alParaval(I)))
                I = I + 1
                
                .Add(New SqlClient.SqlParameter("@DONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXTOTALAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOURNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HSNCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MANUALGST", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@PARTICULARS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DFROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTAL", alParaval(I)))
                I = I + 1
                

                .Add(New SqlClient.SqlParameter("@REFNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISPUTE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLCHECKED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLIENTNAME", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@STOCKNO", alParaval(I)))
                I = I + 1

            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

    Public Function update() As Integer
        Dim intResult As Integer
        Dim strCommand As String
        Try
            'update purchase Requisition

            strCommand = "SP_TRANS_BOOKING_MISC_PUR_UPDATE"
            
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
               
                .Add(New SqlClient.SqlParameter("@PURREGISTERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKINGDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACCNAME", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@FINALPURAMOUNT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISCRECDPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISCRECDRS", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@PURSUBTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTAX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURADDTAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURADDTAX", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TAXSERVCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXSERVCHGSAMT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PUROTHERCHGSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PUROTHERCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURROUNDOFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURGRANDTOTAL", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@BOOKEDBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SOURCE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKINGDESC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SPECIALREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INWORDS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PURAMTPAID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PUREXTRAAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURRETURN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURBAL", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@DONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXTOTALAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOURNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HSNCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MANUALGST", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@PARTICULARS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DFROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTAL", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@REFNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISPUTE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLCHECKED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLIENTNAME", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@STOCKNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKING_NO", alParaval(I)))
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
            Dim strCommand As String = "SP_TRANS_BOOKING_MISC_PUR_CANCEL"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@BOOKINGNO", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@REGISTER", alParaval(1)))
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
            Dim strCommand As String = "SP_TRANS_BOOKING_MISC_PUR_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@BOOKINGNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@REGISTER", alParaval(1)))
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


#End Region

End Class
