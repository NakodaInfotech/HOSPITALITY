Imports DB

Public Class ClsRailway

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
            'save purchase REQUEST
            Dim strCommand As String = "SP_MASTER_RAILWAYMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLASS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
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

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return intResult

    End Function

    Public Function Update() As Integer
        Dim intResult As Integer
        Try
            'Update purchase order
            Dim strCommand As String = "SP_MASTER_CONFIGURATOR_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@MANUAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SMS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRINTDIRECT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHQPRINT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AIRLINE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CAR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RAILWAY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HOLIDAY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HOTEL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MISC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EMAIL", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@CONNO", alParaval(I)))
                I = I + 1


            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

#End Region

End Class
