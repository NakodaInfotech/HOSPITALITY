
Imports DB

Public Class ClsMemberShipMaster

    Private objDBOperation As DBOperation
    Public alParaval As New ArrayList

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

    Public Function SAVE() As Integer
        Dim intResult As Integer
        Dim strcommand As String = ""
        Try
            'save GUESTMASTER
            strcommand = "SP_MASTER_MEMBERSHIPNO_SAVE"
            Dim alParameter As New ArrayList
            With alParameter
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
            End With
            intResult = objDBOperation.executeNonQuery(strcommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function DELETE() As DataTable
        Dim DTTABLE As DataTable
        Try
            'save CategoryMaster
            Dim strcommand As String = "SP_MASTER_MEMBERSHIPNO_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
            End With
            DTTABLE = objDBOperation.execute(strcommand, alParameter).Tables(0)
        Catch ex As Exception
            Throw ex
        End Try
        Return DTTABLE
    End Function

#End Region

End Class
