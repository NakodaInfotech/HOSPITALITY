
Imports DB

Public Class ClsGuestMaster

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
            strcommand = "SP_MASTER_GUESTMASTER_SAVE"

            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@name", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@add1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@add2", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@areaname", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@std", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@cityname", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@zipcode", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@statename", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@countryname", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MEMBERSHIPNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ISDOB", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DOB", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@ISDOA", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DOA", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PLACEOFBIRTH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@resino", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@altno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@tel1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@mobileno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@faxno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@website", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@email", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REFBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NATIONALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@add", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@DISPLAYNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PASSPORTNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PASSPORTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ISSUEDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXPIRYDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GIVENNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SURNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GENDER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STATUS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PLACEOFISSUE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ISSUECONTRY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PREFIX", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@ADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INFANT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@FATHER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MOTHER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SPOUSE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@REFFVIA", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CORDINATORVIA", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GUESTCATEGORY", alParaval(I)))
                I = I + 1

                ''CHECK STATUS OF DOCUMENT
                .Add(New SqlClient.SqlParameter("@CHKPASSPORT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHKSAFAI", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHKITS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHKPHOTO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@GUEST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LEADER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CORDINATOR", alParaval(I)))
                I = I + 1

                ''PHOTO UPLOAD
                .Add(New SqlClient.SqlParameter("@IMGPATH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OURLOCATION", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@IMGPATH1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OURLOCATION1", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@IMGPATH2", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OURLOCATION2", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@IMGPATH3", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OURLOCATION3", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@IMGPATH4", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OURLOCATION4", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@IMGPATH5", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OURLOCATION5", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@IMGPATH6", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OURLOCATION6", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@COPYUNIQUENO", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@BLOCKED", alParaval(I)))
                I = I + 1
            End With

            intResult = objDBOperation.executeNonQuery(strcommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function UPDATE() As Integer

        Dim intResult As Integer
        Dim strcommand As String = ""

        Try

            'Update GUESTMASTER
            strcommand = "SP_MASTER_GUESTMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@name", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@add1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@add2", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@areaname", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@std", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@cityname", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@zipcode", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@statename", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@countryname", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MEMBERSHIPNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ISDOB", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DOB", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@ISDOA", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DOA", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@PLACEOFBIRTH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@resino", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@altno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@tel1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@mobileno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@faxno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@website", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@email", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REFBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NATIONALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@add", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@DISPLAYNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PASSPORTNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PASSPORTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ISSUEDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXPIRYDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GIVENNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SURNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GENDER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STATUS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PLACEOFISSUE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ISSUECONTRY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PREFIX", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@ADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INFANT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@FATHER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MOTHER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SPOUSE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@REFFVIA", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CORDINATORVIA", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GUESTCATEGORY", alParaval(I)))
                I = I + 1


                ''CHECK STATUS OF DOCUMENT
                .Add(New SqlClient.SqlParameter("@CHKPASSPORT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHKSAFAI", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHKITS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHKPHOTO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@GUEST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LEADER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CORDINATOR", alParaval(I)))
                I = I + 1

                ''PHOTO UPLOAD

                .Add(New SqlClient.SqlParameter("@IMGPATH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OURLOCATION", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@IMGPATH1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OURLOCATION1", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@IMGPATH2", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OURLOCATION2", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@IMGPATH3", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OURLOCATION3", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@IMGPATH4", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OURLOCATION4", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@IMGPATH5", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OURLOCATION5", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@IMGPATH6", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OURLOCATION6", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@COPYUNIQUENO", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@BLOCKED", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@GUESTID", alParaval(I)))
                I = I + 1

            End With

            intResult = objDBOperation.executeNonQuery(strcommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function SELECTGUESTDETAILS() As DataTable

        Dim DTTABLE As DataTable
        Dim strcommand As String = ""

        Try

            'Update GUESTMASTER
            strcommand = "SP_MASTER_SELECT_GUEST"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@name", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1
                
            End With

            DTTABLE = objDBOperation.execute(strcommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DTTABLE
    End Function

    Public Function COPYGUESTDETAILS(ByVal UNIQUEID As Integer) As DataTable
        Try
            Dim DTTABLE As DataTable
            Dim strcommand As String = ""
            strcommand = "SP_MASTER_COPY_GUEST"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@UNIQUENO", UNIQUEID))
            End With
            DTTABLE = objDBOperation.execute(strcommand, alParameter).Tables(0)
            Return DTTABLE
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DELETE() As DataTable
        Dim DTTABLE As DataTable
        Try

            'save CategoryMaster
            Dim strcommand As String = "SP_MASTER_GUESTMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@GUESTNAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(4)))


            End With

            DTTABLE = objDBOperation.execute(strcommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DTTABLE

    End Function

#End Region


End Class
