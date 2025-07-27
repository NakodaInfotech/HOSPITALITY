
Imports DB

Public Class ClsVisaEnquiry

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
            Dim strCommand As String = "SP_TRANS_ENQUIRY_VISAENQ_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@ENQDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKEDBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ENQUIRYBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SOURCE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DELDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MISCENQNO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@DOCUMENT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLOSEREMARKS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@SUBTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SERVICECHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MANUAL", alParaval(I)))
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


                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@QUERY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDDONE", alParaval(I)))
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

            Dim strCommand As String = "SP_TRANS_SELECT_VISAENQ_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@ENQNO", alParaval(0)))
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
            Dim strCommand As String = "SP_TRANS_ENQUIRY_VISAENQ_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@ENQDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKEDBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ENQUIRYBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SOURCE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DELDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MISCENQNO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@DOCUMENT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLOSEREMARKS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@SUBTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SERVICECHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MANUAL", alParaval(I)))
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


                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@QUERY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDDONE", alParaval(I)))
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

    Public Function DELETE() As Integer
        Try
            Dim INTRES As Integer
            'Dim DTTABLE As DataTable
            Dim strCommand As String = "SP_TRANS_ENQUIRY_VISAENQ_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@ENQNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@YEARid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@USERid", alParaval(2)))
            End With
            INTRES = objDBOperation.executeNonQuery(strCommand, alParameter)
            'DTTABLE = objDBOperation.execute(strCommand, alParameter).Tables(0)
            'Return DTTABLE
            Return INTRES
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SAVEUPLOAD() As Integer

        Dim intResult As Integer
        Dim strcommand As String = ""

        Try

            'Update AccountsMaster
            strcommand = "SP_TRANS_ENQUIRY_VISAENQ_SAVEUPLOAD"

            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@ENQNO", alParaval(I)))
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

#End Region

End Class
