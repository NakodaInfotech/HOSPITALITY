Imports DB

Public Class ClsLawazim

    Private objDBOperation As DBOperation
    Public alParaval As New ArrayList
    Dim intResult As Integer
    Dim groupid As Integer

#Region "Constructor"
    Public Sub New()
        Try
            objDBOperation = New DBOperation
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Functions"

    Public Function save() As Integer

        Try

            'save group
            Dim strCommand As String = "SP_MASTER_LAWAZIMMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@ADULT", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@CHILD", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@INFANT", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@CURRENCY", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(8)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(9)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function savevisa() As Integer

        Try

            'save group
            Dim strCommand As String = "SP_MASTER_VISAMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@ADULT", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@CHILD", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@INFANT", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@CURRENCY", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(8)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(9)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function savetax() As Integer

        Try

            'save group
            Dim strCommand As String = "SP_MASTER_COUNTRYTAXMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@ADULT", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@CHILD", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@INFANT", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@CURRENCY", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(8)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(9)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function saveservice() As Integer

        Try

            'save group
            Dim strCommand As String = "SP_MASTER_SERVICEMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@ADULT", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@CHILD", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@INFANT", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@CURRENCY", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(8)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(9)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function savemiscexp() As Integer

        Try

            'save group
            Dim strCommand As String = "SP_MASTER_MISCEXPMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@ADULT", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@CHILD", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@INFANT", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@CURRENCY", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(8)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(9)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function saveMEALPLAN() As Integer

        Try

            'save group
            Dim strCommand As String = "SP_MASTER_MEALCONGIGMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@ADULT", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@CHILD", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@INFANT", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@CURRENCY", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(8)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(9)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function saveTRANSPORT() As Integer

        Try

            'save group
            Dim strCommand As String = "SP_MASTER_TRANSPORTMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@ADULT", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@CHILD", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@INFANT", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@CURRENCY", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(8)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(9)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function saveIMPDATE() As Integer

        Try

            'save group
            Dim strCommand As String = "SP_MASTER_IMPDATEMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@FROMDATE", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@TODATE", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(7)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function saveBLOCKDATE() As Integer
        Try
            'save group
            Dim strCommand As String = "SP_MASTER_BLOCKDATEMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@FROMDATE", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@TODATE", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@REMARK", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(8)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function SAVENATIONALITY() As Integer

        Try
            'save group
            Dim strCommand As String = "SP_MASTER_NATIONALITYMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@ABBR", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@CODE", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(7)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function


    Public Function update() As Integer

        Try

            'save group
            Dim strCommand As String = "SP_MASTER_LAWAZIMMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@ADULT", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@CHILD", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@INFANT", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@CURRENCY", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(8)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(9)))
                .Add(New SqlClient.SqlParameter("@TEMPID", alParaval(10)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function updatevisa() As Integer

        Try

            'save group
            Dim strCommand As String = "SP_MASTER_VISAMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@ADULT", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@CHILD", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@INFANT", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@CURRENCY", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(8)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(9)))
                .Add(New SqlClient.SqlParameter("@TEMPID", alParaval(10)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function updateTAX() As Integer

        Try

            'save group
            Dim strCommand As String = "SP_MASTER_COUNTRYTAXMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@ADULT", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@CHILD", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@INFANT", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@CURRENCY", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(8)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(9)))
                .Add(New SqlClient.SqlParameter("@TEMPID", alParaval(10)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function updateservice() As Integer

        Try

            'save group
            Dim strCommand As String = "SP_MASTER_SERVICEMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@ADULT", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@CHILD", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@INFANT", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@CURRENCY", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(8)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(9)))
                .Add(New SqlClient.SqlParameter("@TEMPID", alParaval(10)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function updatemiscexp() As Integer

        Try

            'save group
            Dim strCommand As String = "SP_MASTER_MISCEXPMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@ADULT", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@CHILD", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@INFANT", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@CURRENCY", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(8)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(9)))
                .Add(New SqlClient.SqlParameter("@TEMPID", alParaval(10)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function updateMEALPLAN() As Integer

        Try

            'save group
            Dim strCommand As String = "SP_MASTER_MEALCONFIGMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@ADULT", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@CHILD", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@INFANT", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@CURRENCY", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(8)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(9)))
                .Add(New SqlClient.SqlParameter("@TEMPID", alParaval(10)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function updateTRANSPORT() As Integer

        Try

            'save group
            Dim strCommand As String = "SP_MASTER_TRANSPORTMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@ADULT", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@CHILD", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@INFANT", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@CURRENCY", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(8)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(9)))
                .Add(New SqlClient.SqlParameter("@TEMPID", alParaval(10)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function updateIMPDATE() As Integer

        Try

            'save group
            Dim strCommand As String = "SP_MASTER_IMPDATEMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@FROMDATE", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@TODATE", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@TEMPID", alParaval(8)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function updateBLOCKDATE() As Integer
        Try
            'save group
            Dim strCommand As String = "SP_MASTER_BLOCKDATEMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@FROMDATE", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@TODATE", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@TEMPID", alParaval(8)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function NATIONALITYUPDATE() As Integer

        Try

            'save group
            Dim strCommand As String = "SP_MASTER_NATIONALITYMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@ABBR", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@CODE", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@TEMPID", alParaval(8)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function


    Public Function DELETE() As DataTable
        Dim dtTable As New DataTable
        Dim strcommand As String = ""
        Try
            strcommand = "SP_MASTER_LAWAZIMMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(4)))

            End With
            dtTable = objDBOperation.execute(strcommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function DELETEVISA() As DataTable
        Dim dtTable As New DataTable
        Dim strcommand As String = ""
        Try
            strcommand = "SP_MASTER_VISAMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(4)))

            End With
            dtTable = objDBOperation.execute(strcommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function DELETETAX() As DataTable
        Dim dtTable As New DataTable
        Dim strcommand As String = ""
        Try
            strcommand = "SP_MASTER_COUNTRYTAXMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(4)))

            End With
            dtTable = objDBOperation.execute(strcommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function DELETESERVICE() As DataTable
        Dim dtTable As New DataTable
        Dim strcommand As String = ""
        Try
            strcommand = "SP_MASTER_SERVICEMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(4)))

            End With
            dtTable = objDBOperation.execute(strcommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function DELETEMISCEXP() As DataTable
        Dim dtTable As New DataTable
        Dim strcommand As String = ""
        Try
            strcommand = "SP_MASTER_MISCEXPMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(4)))

            End With
            dtTable = objDBOperation.execute(strcommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function DELETEMEAL() As DataTable
        Dim dtTable As New DataTable
        Dim strcommand As String = ""
        Try
            strcommand = "SP_MASTER_MEALCONFIGMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@TEMPID", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(5)))

            End With
            dtTable = objDBOperation.execute(strcommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function DELETETRANSPORT() As DataTable
        Dim dtTable As New DataTable
        Dim strcommand As String = ""
        Try
            strcommand = "SP_MASTER_TRANSPORTMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(4)))

            End With
            dtTable = objDBOperation.execute(strcommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function DELETEIMPDATE() As DataTable
        Dim dtTable As New DataTable
        Dim strcommand As String = ""
        Try
            strcommand = "SP_MASTER_IMPDATEMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@TEMPID", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(5)))

            End With
            dtTable = objDBOperation.execute(strcommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function DELETEBLOCKDATE() As DataTable
        Dim dtTable As New DataTable
        Dim strcommand As String = ""
        Try
            strcommand = "SP_MASTER_BLOCKDATEMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@TEMPID", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(5)))

            End With
            dtTable = objDBOperation.execute(strcommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function NATIONALITYDELETE() As DataTable
        Dim dtTable As New DataTable
        Dim strcommand As String = ""
        Try
            strcommand = "SP_MASTER_NATIONALITY_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(4)))

            End With
            dtTable = objDBOperation.execute(strcommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

#End Region
End Class
