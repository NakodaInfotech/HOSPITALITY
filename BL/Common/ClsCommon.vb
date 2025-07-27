
Imports DB

Public Class ClsCommon

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

    Public Function GETMAXNO(ByVal fld1 As String, ByVal tablename As String, Optional ByVal whereclause As String = "") As DataTable
        Dim dtTable As DataTable
        'Dim INTRESULT As Integer
        Try

            Dim strCommand As String = "SP_GETMAXNO"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@fld1", fld1))
                .Add(New SqlClient.SqlParameter("@TBname", tablename))
                .Add(New SqlClient.SqlParameter("@whereclause", whereclause))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function GETTRANSFERDATE() As DateTime
        Dim dtTable As DataTable
        Dim DTTIME As Date
        Try

            Dim strCommand As String = "SP_LASTTRANSFERDATE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(0)))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)
            DTTIME = dtTable.Rows(0).Item(0)
        Catch ex As Exception
            'DTTIME = "01/01/2001"
            'Throw ex
        End Try
        Return DTTIME
    End Function

    Public Function search(ByVal fld1 As String, Optional ByVal fld2 As String = "", Optional ByVal tablename As String = "", Optional ByVal whereclause As String = "") As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_MASTER_GET_ANYID"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@fld1", fld1))
                .Add(New SqlClient.SqlParameter("@fld2", fld2))
                .Add(New SqlClient.SqlParameter("@ptable_name", tablename))
                .Add(New SqlClient.SqlParameter("@whereclause", whereclause))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function getfirstdate(ByVal ddate As Date) As Date
        Dim dtTable As New DataTable
        Dim dtdate As Date
        Try
            Dim strCommand As String = "SELECT CONVERT(date,DATEADD(dd,-(DAY('" & ddate & "' )-1),'" & ddate & "'),101) AS Date_Value"
            dtTable = objDBOperation.execute(strCommand).Tables(0)
        Catch ex As Exception
            Throw ex
        End Try
        dtdate = Convert.ToDateTime(dtTable.Rows(0).Item(0))
        Return dtdate

        'DECLARE @mydate DATETIME
        'SELECT @mydate = getdate()
        'SELECT CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(@mydate)-1),@mydate),101) AS Date_Value,
        '        'First Day of Current Month' AS Date_Type

    End Function

    Public Function getlastdate(ByVal ddate As Date) As Date
        Dim dtTable As New DataTable
        Dim dtdate As Date
        Try
            Dim strCommand As String = "SELECT CONVERT(date,DATEADD(dd,-(DAY(DATEADD(mm,1,'" & ddate & "'))),DATEADD(mm,1,'" & ddate & "')),101)"
            dtTable = objDBOperation.execute(strCommand).Tables(0)
        Catch ex As Exception
            Throw ex
        End Try
        dtdate = dtTable.Rows(0).Item(0)
        Return dtdate

        'DECLARE @mydate DATETIME
        'SELECT @mydate = getdate()
        'SELECT CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,@mydate))),DATEADD(mm,1,@mydate)),101) ,
        'Last Day of Current Month'

    End Function

    Public Function Execute_Any_String(ByVal fld1 As String, ByVal fld2 As String, ByVal fld3 As String) As DataTable
        'Dim dtTable As DataTable
        Dim INTRESULT As Integer
        Try

            Dim strCommand As String = "SP_ANY_STRING_EXECUTE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@fld1", fld1))
                .Add(New SqlClient.SqlParameter("@fld2", fld2))
                .Add(New SqlClient.SqlParameter("@fld3", fld3))
            End With
            INTRESULT = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function MERGEPARAMETER() As Integer
        Dim INTRESULT As Integer
        Try
            Dim strCommand As String = "SP_UTILITIES_MERGEPARAMETER"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@OLDNAME", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@NEWNAME", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@Locationid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@Yearid", alParaval(5)))
            End With
            INTRESULT = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
