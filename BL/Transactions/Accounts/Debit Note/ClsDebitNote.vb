
Imports DB

Public Class ClsDebitNote

    Private objDBOperation As DBOperation
    Public alParaval As New ArrayList
    Public alP As New ArrayList

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
            'save DEBITNOTE
            Dim strCommand As String = "SP_TRANS_DEBITNOTE_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@registername", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DNdate", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ARRIVALDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKAGESRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GUESTNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HOTELNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@HSNCODE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PURAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISCPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISCRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COMMPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COMMRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TDSPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TDSRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRACHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURSERVCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXSERVCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MANUALGST", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@OTHERCHGSAMT", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@ROUNDOFF", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@GTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DP", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLIENTNAME", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@IRNNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACKNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACKDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QRCODE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@GSTR1", alParaval(I)))
                I = I + 1
            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

    Public Function ACCDELETE() As Integer
        Try
            Dim intResult As Integer
            Dim STRCOMMAND As String
            Dim OBJCOMMON As New ClsCommonMaster
            Dim DTTABLE As DataTable = OBJCOMMON.search(" REGISTER_ABBR", "", " REGISTERMASTER", " AND REGISTER_TYPE = 'DEBITNOTE' AND REGISTER_NAME = '" & alP(0) & "' AND REGISTER_CMPID = " & alP(2) & " AND REGISTER_LOCATIONID = " & alP(3) & " AND REGISTER_YEARID = " & alP(4))

            STRCOMMAND = "DELETE FROM ACCMASTER WHERE ACC_REGTYPE = '" & DTTABLE.Rows(0).Item(0).ToString & "' AND ACC_TYPE=  'DEBITNOTE' AND ACC_BILLNO = " & alP(1) & " AND ACC_CMPID = " & alP(2) & " AND ACC_LOCATIONID = " & alP(3) & " AND ACC_YEARID = " & alP(4)
            Dim DT As DataTable = objDBOperation.execute(STRCOMMAND).Tables(0)
            DTTABLE = objDBOperation.execute(STRCOMMAND).Tables(0)
            Return intResult

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ACCOUNTS() As Integer
        Dim intResult As Integer
        Try
            Dim strCommand As String

            'save DEBITNOTE
            strCommand = "SP_TRANS_DEBITNOTEMASTER_ACCOUNTS_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@FROMIDNAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@AMT", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@TOIDNAME", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@DNNO", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@DNdate", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@REGISTERNAME", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(8)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(9)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return intResult

    End Function

    Public Function selectDEBITNOTE_edit(ByVal DNNO As Integer, ByVal REGISTERNAME As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_TRANS_SELECT_DEBITNOTE_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@DNNO", DNNO))
                .Add(New SqlClient.SqlParameter("@REGISTERNAME", REGISTERNAME))
                .Add(New SqlClient.SqlParameter("@CMPID", CMPID))
                .Add(New SqlClient.SqlParameter("@LOCATIONID", LOCATIONID))
                .Add(New SqlClient.SqlParameter("@YEARID", YEARID))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function update() As DataTable
        Dim DT As DataTable
        Try
            'update DEBITNOTE Entry
            Dim strCommand As String = "SP_TRANS_DEBITNOTE_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@registername", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DNdate", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ARRIVALDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKAGESRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GUESTNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HOTELNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HSNCODE", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@PURAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISCPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISCRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COMMPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COMMRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TDSPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TDSRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRACHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURSERVCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXSERVCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MANUALGST", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@OTHERCHGSAMT", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@ROUNDOFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DP", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLIENTNAME", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@IRNNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACKNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACKDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QRCODE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@GSTR1", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@DNNO", alParaval(I)))
                I = I + 1

            End With
            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT
    End Function

    Public Function COPY() As Integer
        Dim intResult As Integer
        Try
            'save purchase Requisition
            Dim strCommand As String = "SP_TRANS_DEBITNOTE_COPY"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@CPDEBITNOTE_NO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@REGISTERNAME", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(2)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return intResult

    End Function

    Public Function Delete() As DataTable
        Dim dtTable As DataTable
        Try
            Dim strCommand As String = "SP_TRANS_DEBITNOTE_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@DNNO", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@REGISTERNAME", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@LOCATIONid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@YEARid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@Userid", alParaval(6)))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)
            Return dtTable
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SAVEQRCODE() As Integer
        Dim intResult As Integer
        Try
            'save SALE order
            Dim strCommand As String = "SP_TRANS_DEBITNOTE_QRCODE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@DNNO", alParaval(I)))
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
