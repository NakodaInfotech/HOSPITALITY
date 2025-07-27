
Imports DB

Public Class ClsAgentMaster

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

    Public Function save() As Integer
        Dim intResult As Integer
        Dim strcommand As String = ""

        Try

            'save CategoryMaster
            strcommand = "SP_MASTER_AGENTMASTER_SAVE"
            
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@agentname", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@person", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@groupname", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@city", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@comm", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@commdrcr", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@opbal", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@drcr", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@crlimit", alParaval(8)))
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(9)))
                .Add(New SqlClient.SqlParameter("@addr", alParaval(10)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(11)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(12)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(13)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(14)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(15)))

              
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
            strcommand = "SP_MASTER_AGENTMASTER_UPDATE"
            
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@agentname", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@person", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@groupname", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@city", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@comm", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@commdrcr", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@opbal", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@drcr", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@crlimit", alParaval(8)))
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(9)))
                .Add(New SqlClient.SqlParameter("@addr", alParaval(10)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(11)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(12)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(13)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(14)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(15)))
                .Add(New SqlClient.SqlParameter("@AgentId", alParaval(16)))

            End With

            intResult = objDBOperation.executeNonQuery(strcommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function getAGENT() As DataTable
        Dim dtTable As DataTable
        Dim strcommand As String = ""
        Try
            strcommand = "SP_MASTER_SELECT_AGENTS"

            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(3)))
            End With
            dtTable = objDBOperation.execute(strcommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function DELETE() As DataTable
        Dim dtTable As New DataTable
        Dim strcommand As String = ""
        Try
            strcommand = "SP_MASTER_AGENTMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@AGENTNAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(4)))

            End With
            dtTable = objDBOperation.execute(strcommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

#End Region

End Class
