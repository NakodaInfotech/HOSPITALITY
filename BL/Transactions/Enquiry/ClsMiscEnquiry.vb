
Imports DB

Public Class ClsMiscEnquiry

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
            Dim strCommand As String = "SP_TRANS_ENQUIRY_MISCENQ_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@ENQDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ENQNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ENQMOBILENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ENQEMAILID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PREFIX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GUESTNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MOBILENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EMAILID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LEADTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STATUS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SOURCE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKEDBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ENQTRANSFERREDTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKIN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKOUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADD", alParaval(I)))
                I = I + 1
                
                .Add(New SqlClient.SqlParameter("@ADULTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INFANTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPAX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AGEPOLICYCHILDWITHBED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AGEPOLICYCHILDWITHOUTBED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHILDWITHOUTBED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRAADULTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROOMS", alParaval(I)))
                I = I + 1
                
                .Add(New SqlClient.SqlParameter("@CLOSEREMARKS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CATEGORY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FOLLOWUPREMARKS", alParaval(I)))
                I = I + 1

            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

    Public Function SELECTMISCENQ() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_TRANS_SELECT_MISCENQ_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@MISCENQNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(1)))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function SELECTUSERMISCENQ() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_TRANS_SELECT_MISCENQ_USER"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@MISCENQNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@USERNAME", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(2)))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function SELECTBOOKEDBYMISCENQ() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_TRANS_SELECT_MISCENQ_BOOKEDBY"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@USERNAME", alParaval(0)))
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
            Dim strCommand As String = "SP_TRANS_ENQUIRY_MISCENQ_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@ENQDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ENQNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ENQMOBILENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ENQEMAILID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PREFIX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GUESTNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MOBILENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EMAILID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LEADTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STATUS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SOURCE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKEDBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ENQTRANSFERREDTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKIN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKOUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADD", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@ADULTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INFANTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPAX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AGEPOLICYCHILDWITHBED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AGEPOLICYCHILDWITHOUTBED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHILDWITHOUTBED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRAADULTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROOMS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CLOSEREMARKS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CATEGORY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FOLLOWUPREMARKS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@MISCENQNO", alParaval(I)))
                I = I + 1

            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function DELETE() As Integer
        Dim INTRES As Integer
        'Dim DTTABLE As DataTable
        Try
            Dim strCommand As String = "SP_TRANS_ENQUIRY_MISCENQ_DELETE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@MISCENQNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(2)))
            End With
            INTRES = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

#End Region

End Class
