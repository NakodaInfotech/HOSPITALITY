
Imports DB

Public Class clspurchasemaster
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

    Public Function save() As Integer
        Dim intResult As Integer
        Try
            'save purchase Requisition
            Dim strCommand As String = "SP_TRANS_PURCHASEMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@registername", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@vendorname", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@purchasedate", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@duedate", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@refno", alParaval(4)))

                .Add(New SqlClient.SqlParameter("@transname", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@lrno", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@lrdate", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@city", alParaval(8)))

                .Add(New SqlClient.SqlParameter("@totalqty", alParaval(9)))
                .Add(New SqlClient.SqlParameter("@totalamt", alParaval(10)))
                .Add(New SqlClient.SqlParameter("@transchgs", alParaval(11)))
                .Add(New SqlClient.SqlParameter("@subtotal", alParaval(12)))
                .Add(New SqlClient.SqlParameter("@taxname", alParaval(13)))
                .Add(New SqlClient.SqlParameter("@taxamt", alParaval(14)))
                .Add(New SqlClient.SqlParameter("@otherchgs", alParaval(15)))
                .Add(New SqlClient.SqlParameter("@roundoff", alParaval(16)))
                .Add(New SqlClient.SqlParameter("@gtotal", alParaval(17)))

                .Add(New SqlClient.SqlParameter("@remarks", alParaval(18)))

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(19)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(20)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(21)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(22)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(23)))

                .Add(New SqlClient.SqlParameter("@itemname", alParaval(24)))
                .Add(New SqlClient.SqlParameter("@qty", alParaval(25)))
                .Add(New SqlClient.SqlParameter("@unit", alParaval(26)))
                .Add(New SqlClient.SqlParameter("@rate", alParaval(27)))
                .Add(New SqlClient.SqlParameter("@amt", alParaval(28)))
                .Add(New SqlClient.SqlParameter("@BUSREFNO", alParaval(29)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return intResult

    End Function

    Public Function COPY() As Integer
        Dim intResult As Integer
        Try
            'save purchase Requisition
            Dim strCommand As String = "SP_TRANS_PURCHASEMASTER_COPY"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@CPPURCHASEBILL_NO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@REGISTERNAME", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(4)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return intResult

    End Function

    Public Function selectbill_edit(ByVal preqno As Integer, ByVal REGISTERNAME As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_TRANS_SELECT_PURCHASEBILL_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@PBILL_NO", preqno))
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

    Public Function update() As Integer
        Dim intResult As Integer
        Try
            'update purchase Requisition
            Dim strCommand As String = "SP_TRANS_PURCHASEMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@registername", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@vendorname", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@purchasedate", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@duedate", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@refno", alParaval(4)))

                .Add(New SqlClient.SqlParameter("@transname", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@lrno", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@lrdate", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@city", alParaval(8)))

                .Add(New SqlClient.SqlParameter("@totalqty", alParaval(9)))
                .Add(New SqlClient.SqlParameter("@totalamt", alParaval(10)))
                .Add(New SqlClient.SqlParameter("@transchgs", alParaval(11)))
                .Add(New SqlClient.SqlParameter("@subtotal", alParaval(12)))
                .Add(New SqlClient.SqlParameter("@taxname", alParaval(13)))
                .Add(New SqlClient.SqlParameter("@taxamt", alParaval(14)))
                .Add(New SqlClient.SqlParameter("@otherchgs", alParaval(15)))
                .Add(New SqlClient.SqlParameter("@roundoff", alParaval(16)))
                .Add(New SqlClient.SqlParameter("@gtotal", alParaval(17)))

                .Add(New SqlClient.SqlParameter("@remarks", alParaval(18)))

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(19)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(20)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(21)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(22)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(23)))

                .Add(New SqlClient.SqlParameter("@itemname", alParaval(24)))
                .Add(New SqlClient.SqlParameter("@qty", alParaval(25)))
                .Add(New SqlClient.SqlParameter("@unit", alParaval(26)))
                .Add(New SqlClient.SqlParameter("@rate", alParaval(27)))
                .Add(New SqlClient.SqlParameter("@amt", alParaval(28)))
                .Add(New SqlClient.SqlParameter("@BUSREFNO", alParaval(29)))
                .Add(New SqlClient.SqlParameter("@billno", alParaval(30)))
                .Add(New SqlClient.SqlParameter("@amtpaid", alParaval(31)))
                .Add(New SqlClient.SqlParameter("@tds", alParaval(32)))

            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function Delete() As DataTable
        Dim dtTable As DataTable

        Try
            Dim strCommand As String = "SP_TRANS_PURCHASEMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@BILLNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@REGISTERNAME", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@LOCATIONid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@YEARid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(5)))

            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

            Return dtTable

        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region

End Class
