Imports DB

Public Class ClsItineraryMaster

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
            Dim strCommand As String = "SP_TRANS_ITINERARY_ITINERARYMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@PACKAGETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKAGENAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISPLAYNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKAGEFROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKAGETO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADULTRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRAADULTRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALDAYS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHILDBEDRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHILDRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHILDBELOWAGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PDFPATH", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@INCLUSION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXCLUSION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TERMS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@SIMILAR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUOTE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LUMPSUM", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I += 1

                'GRID HOTEL

                '.Add(New SqlClient.SqlParameter("@HOTELSRNO", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@CITY", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@HOTELNAME", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@ROOMTYPE", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@NIGHTS", alParaval(I)))
                'I = I + 1

                'GRID  AIRLINE PARAMETERS
                .Add(New SqlClient.SqlParameter("@AIRSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SECTOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BASIC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PSF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AIRAMT", alParaval(I)))
                I = I + 1


                'FLIGHT PARAMETERS
                .Add(New SqlClient.SqlParameter("@FLIGHTSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMSEC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOSEC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLIGHTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLIGHTDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ARRIVES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLIGHTCLASS", alParaval(I)))
                I = I + 1

                'GRID VEHICLE
                .Add(New SqlClient.SqlParameter("@VEHICLESRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VEHICLENAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESCRIPTION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VEHICLEDAYS", alParaval(I)))
                I = I + 1

                'GRID MISC
                .Add(New SqlClient.SqlParameter("@MISCSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MISCSERVICETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MISCREMARKS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@INCLUSIONS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXCLUSIONS", alParaval(I)))
                I = I + 1

            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

    Public Function UPDATE() As Integer
        Dim intResult As Integer
        Try
            'update purchase Requisition
            Dim strCommand As String = "SP_TRANS_ITINERARY_ITINERARYMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@PACKAGETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKAGENAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISPLAYNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKAGEFROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKAGETO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADULTRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRAADULTRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALDAYS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHILDBEDRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHILDRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHILDBELOWAGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PDFPATH", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@INCLUSION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXCLUSION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TERMS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@SIMILAR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUOTE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LUMPSUM", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I += 1

                'GRID HOTEL

                '.Add(New SqlClient.SqlParameter("@HOTELSRNO", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@CITY", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@HOTELNAME", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@ROOMTYPE", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@NIGHTS", alParaval(I)))
                'I = I + 1

                'GRID PARAMETERS
                .Add(New SqlClient.SqlParameter("@AIRSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SECTOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BASIC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PSF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AIRAMT", alParaval(I)))
                I = I + 1


                'FLIGHT PARAMETERS
                .Add(New SqlClient.SqlParameter("@FLIGHTSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOOKSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMSEC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOSEC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLIGHTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLIGHTDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ARRIVES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLIGHTCLASS", alParaval(I)))
                I = I + 1

                'GRID VEHICLE
                .Add(New SqlClient.SqlParameter("@VEHICLESRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VEHICLENAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESCRIPTION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VEHICLEDAYS", alParaval(I)))
                I = I + 1

                'GRID MISC
                .Add(New SqlClient.SqlParameter("@MISCSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MISCSERVICETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MISCREMARKS", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@INCLUSIONS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXCLUSIONS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@ITINERARYNO", alParaval(I)))
                I = I + 1

            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function SAVEITINERARY() As Integer
        Dim INTRESULT As Integer
        Try
            Dim STRCOMMAND As String = "SP_TRANS_ITINERARY_ITINERARYMASTER_SAVEITINERARY"
            Dim ALPARAMATER As New ArrayList
            With ALPARAMATER
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@ITINERARYNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HEADER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DETAILS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IMGPATH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I = I + 1
            End With

            INTRESULT = objDBOperation.executeNonQuery(STRCOMMAND, ALPARAMATER)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SAVEHOTEL() As Integer
        Dim INTRESULT As Integer
        Try
            Dim STRCOMMAND As String = "SP_TRANS_ITINERARY_ITINERARYMASTER_SAVEHOTEL"
            Dim ALPARAMATER As New ArrayList
            With ALPARAMATER
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@ITINERARYNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HOTELSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HOTELNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROOMTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NIGHTS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@HOTELIMGPATH", alParaval(I)))
                I = I + 1
                
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I = I + 1
            End With

            INTRESULT = objDBOperation.executeNonQuery(STRCOMMAND, ALPARAMATER)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SELECTITINERARY() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_TRANS_SELECT_ITINERARY_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@ITINERARYNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(2)))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function Delete() As Integer
        Dim INTRESULT As Integer
        Try
            Dim strCommand As String = "SP_TRANS_ITINERARY_ITINERARYMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@ITINERARYNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(2)))
            End With
            INTRESULT = objDBOperation.executeNonQuery(strCommand, alParameter)
            Return INTRESULT
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
