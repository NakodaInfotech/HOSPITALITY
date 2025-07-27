
Imports DB

Public Class ClsHotelEnqMaster

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
            Dim strCommand As String = "SP_TRANS_ENQUIRY_HOTELENQ_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@ENQDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GUESTNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@GUESTADD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HOTELNAME", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@ARRIVALDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DEPARTDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKIN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKOUT", alParaval(I)))
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

               .Add(New SqlClient.SqlParameter("@TOTALPAX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALNIGHTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKEDBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SOURCE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MISCENQNO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@COSTPRICE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TOTALSALEAMT", alParaval(I)))
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


                .Add(New SqlClient.SqlParameter("@ENQDESC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SPECIALREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NOTES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CANCELPOLICY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NOTE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@POLICY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INWORDS", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@CURCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMT", alParaval(I)))
                I = I + 1



                .Add(New SqlClient.SqlParameter("@REFNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLIENTNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PREFIX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AVL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONFNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONFBY", alParaval(I)))
                I = I + 1


                'for followup grid
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

    Public Function SELECTENQ() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_TRANS_SELECT_HOTELENQ_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@ENQNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(2)))
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
            Dim strCommand As String = "SP_TRANS_ENQUIRY_HOTELENQ_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@ENQDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GUESTNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GUESTADD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HOTELNAME", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@ARRIVALDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DEPARTDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKIN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKOUT", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@TOTALPAX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALNIGHTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKEDBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SOURCE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MISCENQNO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@COSTPRICE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TOTALSALEAMT", alParaval(I)))
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


                .Add(New SqlClient.SqlParameter("@ENQDESC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SPECIALREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NOTES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CANCELPOLICY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NOTE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@POLICY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INWORDS", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@CURCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMT", alParaval(I)))
                I = I + 1



                .Add(New SqlClient.SqlParameter("@REFNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLIENTNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PREFIX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AVL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONFNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONFBY", alParaval(I)))
                I = I + 1


                'for followup grid
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
        Try
            Dim INTRES As Integer
            Dim strCommand As String = "SP_TRANS_ENQUIRY_HOTELENQ_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@ENQNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@LOCATIONid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@YEARid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@USERid", alParaval(4)))
            End With
            INTRES = objDBOperation.executeNonQuery(strCommand, alParameter)
            Return INTRES
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
