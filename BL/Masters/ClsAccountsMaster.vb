Imports DB

Public Class ClsAccountsMaster

    Private objDBOperation As DBOperation
    Public alParaval As New ArrayList
    Public frmstring As String        'Used from Displaying Customer, Vendor, Employee Master

#Region "Constructor"
    Public Sub New()
        Try
            objDBOperation = New DBOperation
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Function"

    Public Function save() As Integer
        Dim intResult As Integer
        Dim strcommand As String = ""

        Try

            'save CategoryMaster
            strcommand = "SP_MASTER_ACCOUNTSMASTER_SAVE"

            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@cmpname", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@name", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@groupname", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@opbal", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@drcr", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@add1", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@add2", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@areaname", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@std", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cityname", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@zipcode", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@statename", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@countryname", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@crdays", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@crlimit", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@resino", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@altno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@tel1", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@mobileno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@faxno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@website", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@email", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@panno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@exciseno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@range", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@division", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cstno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@tinno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@stno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@vatno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GSTIN", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@add", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@shippingadd", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TRANSFER", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@code", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@ISTDS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DEDUCTEETYPE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ISLOWER", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SECTION", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TDSRATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SURCHARGE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@LIMIT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TDSAC", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NATURE", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@REFBY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@MEMBERID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CATEGORY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@EXPDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@OPPOINTS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BLOCKED", alParaval(I)))
                I += 1


                .Add(New SqlClient.SqlParameter("@CNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CDOB", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DESIGNATION", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CMOB", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CEMAIL", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@ACNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ACNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ACTYPE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BANKNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BRANCH", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@IFSC", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SWIFT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BCITY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BPINCODE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BCOUNTRY", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@FNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@FDOB", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@FAGE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@FRELATION", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@FMOBILENO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@FEMAIL", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@FSEX", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@dob", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@TDSDEDUCTEDAC", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TDSFORM", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TDSPER", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TDSCOMPANY", alParaval(I)))
                I += 1

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function update() As Integer

        Dim intResult As Integer
        Dim strcommand As String = ""

        Try

            'Update AccountsMaster
            If frmstring = "ACCOUNTS" Then
                strcommand = "SP_MASTER_ACCOUNTSMASTER_UPDATE"
            End If

            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@cmpname", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@name", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@groupname", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@opbal", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@drcr", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@add1", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@add2", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@areaname", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@std", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cityname", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@zipcode", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@statename", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@countryname", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@crdays", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@crlimit", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@resino", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@altno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@tel1", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@mobileno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@faxno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@website", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@email", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@panno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@exciseno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@range", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@division", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cstno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@tinno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@stno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@vatno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GSTIN", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@add", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@shippingadd", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TRANSFER", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@code", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@ISTDS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DEDUCTEETYPE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ISLOWER", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SECTION", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TDSRATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SURCHARGE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@LIMIT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TDSAC", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NATURE", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@REFBY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@MEMBERID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CATEGORY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@EXPDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@OPPOINTS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BLOCKED", alParaval(I)))
                I += 1


                .Add(New SqlClient.SqlParameter("@CNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CDOB", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DESIGNATION", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CMOB", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CEMAIL", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@ACNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ACNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ACTYPE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BANKNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BRANCH", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@IFSC", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SWIFT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BCITY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BPINCODE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BCOUNTRY", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@FNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@FDOB", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@FAGE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@FRELATION", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@FMOBILENO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@FEMAIL", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@FSEX", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@dob", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@TDSDEDUCTEDAC", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TDSFORM", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TDSPER", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TDSCOMPANY", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@AccountId", alParaval(I)))
                I += 1

            End With

            intResult = objDBOperation.executeNonQuery(strcommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function Ledgerupdate() As Integer

        Dim intResult As Integer
        Dim strcommand As String = ""

        Try
            strcommand = "SP_MASTER_LEDGERMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@areaname", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cityname", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@zipcode", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@statename", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@countryname", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@std", alParaval(I)))
                I += 1
               
                .Add(New SqlClient.SqlParameter("@resino", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@altno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@add1", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@add2", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@mobileno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@faxno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@website", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@email", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@tel1", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@add", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@shippingadd", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NOTES", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I += 1
               
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I += 1

            End With

            intResult = objDBOperation.executeNonQuery(strcommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function


    Public Function DELETE() As DataTable
        Dim DTTABLE As DataTable
        Dim strcommand As String = ""

        Try

            'save CategoryMaster
            If frmstring = "ACCOUNTS" Then
                strcommand = "SP_MASTER_ACCOUNTSMASTER_DELETE"
            ElseIf frmstring = "CUSTOMER" Then
                strcommand = "SP_MASTER_CUSTOMERMASTER_DELETE"
            ElseIf frmstring = "VENDOR" Then
                strcommand = "SP_MASTER_VENDORMASTER_DELETE"
            ElseIf frmstring = "EMPLOYEE" Then
                strcommand = "SP_MASTER_EMPLOYEEMASTER_DELETE"
            End If

            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@cmpname", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(4)))

                
            End With

            DTTABLE = objDBOperation.execute(strcommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DTTABLE

    End Function

    Public Function GETACCOUNTS() As DataTable
        Dim DT As DataTable
        Try

            'save CategoryMaster
            Dim strcommand As String = "SP_MASTER_SELECT_ACCOUNTS"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(3)))
            End With

            DT = objDBOperation.execute(strcommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

#End Region


End Class
