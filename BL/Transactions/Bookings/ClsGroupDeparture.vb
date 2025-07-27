
Imports DB

Public Class ClsGroupDeparture

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
            Dim strCommand As String = "SP_TRANS_BOOKING_GROUPDEPARTURE_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@GROUPDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REFNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GROUPNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKAGEFROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKAGETO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALNIGHTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPAX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROUTE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PDFPATH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPACKAGEAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITINERARYNAME", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I += 1

                'BOOKING DETAILS

                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HOTELNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INCLUSIONS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKIN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKOUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROOMTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PLAN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NOOFROOMS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKAGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NIGHTS", alParaval(I)))
                I = I + 1


                'TOUR DETAILS
                .Add(New SqlClient.SqlParameter("@TOURSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOURDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOURDETAILS", alParaval(I)))
                I = I + 1

                'RAILWAY DETAILS
                .Add(New SqlClient.SqlParameter("@TRAINNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRAINNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOURNEYDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLASS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOARDING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOARDINGCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RESTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RESTOCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FARE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRACHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRANDTOTAL", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@DNTRAINNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DNTRAINNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DNJOURNEYDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DNCLASS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DNFROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DNFROMCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DNTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DNTOCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DNBOARDING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DNBOARDINGCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DNRESTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DNRESTOCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DNFARE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DNEXTRACHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DNTAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DNTAXAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DNGRANDTOTAL", alParaval(I)))
                I = I + 1

                'TRANS PARAMETER
                .Add(New SqlClient.SqlParameter("@CARSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CARNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PICKUPON", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PICKUPFROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PICKUPTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PICKUPDTLS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DROPON", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DROPAT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DROPTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DROPDTLS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CARDAYS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CARNOTE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CARAMT", alParaval(I)))
                I = I + 1


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



                'MID RAILWAY DETAILS
                .Add(New SqlClient.SqlParameter("@MIDUPTRAINNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDUPTRAINNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDUPJOURNEYDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDUPCLASS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDUPFROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDUPFROMCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDUPTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDUPTOCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDUPBOARDING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDUPBOARDINGCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDUPRESTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDUPRESTOCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDUPFARE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDUPEXTRACHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDUPTAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDUPTAXAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDUPGRANDTOTAL", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@MIDDNTRAINNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDDNTRAINNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDDNJOURNEYDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDDNCLASS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDDNFROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDDNFROMCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDDNTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDDNTOCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDDNBOARDING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDDNBOARDINGCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDDNRESTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDDNRESTOCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDDNFARE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDDNEXTRACHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDDNTAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDDNTAXAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDDNGRANDTOTAL", alParaval(I)))
                I = I + 1

                'GRID MISC
                .Add(New SqlClient.SqlParameter("@MISCSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MISCSERVICETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MISCREMARKS", alParaval(I)))
                I = I + 1

            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

    Public Function SELECTBOOKINGDESC() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_TRANS_SELECT_GROUPDEPARTURE_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@GROUPNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(1)))
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
            Dim strCommand As String = "SP_TRANS_BOOKING_GROUPDEPARTURE_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@GROUPDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REFNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GROUPNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKAGEFROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKAGETO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALNIGHTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPAX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROUTE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PDFPATH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPACKAGEAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITINERARYNAME", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I += 1

                'BOOKING DETAILS

                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HOTELNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INCLUSIONS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKIN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKOUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROOMTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PLAN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NOOFROOMS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKAGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NIGHTS", alParaval(I)))
                I = I + 1


                'TOUR DETAILS
                .Add(New SqlClient.SqlParameter("@TOURSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOURDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOURDETAILS", alParaval(I)))
                I = I + 1

                'RAILWAY DETAILS
                .Add(New SqlClient.SqlParameter("@TRAINNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRAINNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOURNEYDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLASS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOARDING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOARDINGCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RESTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RESTOCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FARE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRACHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRANDTOTAL", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@DNTRAINNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DNTRAINNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DNJOURNEYDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DNCLASS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DNFROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DNFROMCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DNTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DNTOCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DNBOARDING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DNBOARDINGCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DNRESTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DNRESTOCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DNFARE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DNEXTRACHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DNTAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DNTAXAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DNGRANDTOTAL", alParaval(I)))
                I = I + 1

                'TRANS PARAMETER
                .Add(New SqlClient.SqlParameter("@CARSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CARNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PICKUPON", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PICKUPFROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PICKUPTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PICKUPDTLS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DROPON", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DROPAT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DROPTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DROPDTLS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CARDAYS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CARNOTE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CARAMT", alParaval(I)))
                I = I + 1


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


                'MID RAILWAY DETAILS
                .Add(New SqlClient.SqlParameter("@MIDUPTRAINNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDUPTRAINNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDUPJOURNEYDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDUPCLASS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDUPFROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDUPFROMCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDUPTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDUPTOCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDUPBOARDING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDUPBOARDINGCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDUPRESTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDUPRESTOCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDUPFARE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDUPEXTRACHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDUPTAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDUPTAXAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDUPGRANDTOTAL", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@MIDDNTRAINNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDDNTRAINNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDDNJOURNEYDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDDNCLASS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDDNFROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDDNFROMCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDDNTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDDNTOCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDDNBOARDING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDDNBOARDINGCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDDNRESTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDDNRESTOCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDDNFARE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDDNEXTRACHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDDNTAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDDNTAXAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MIDDNGRANDTOTAL", alParaval(I)))
                I = I + 1

                'GRID MISC
                .Add(New SqlClient.SqlParameter("@MISCSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MISCSERVICETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MISCREMARKS", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@GROUPDEPARTNO", alParaval(I)))
                I = I + 1

            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function Delete() As DataTable
        Dim DTTABLE As DataTable
        Try
            Dim strCommand As String = "SP_TRANS_BOOKING_GROUPDEPARTURE_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@GROUPDEPNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@YEARid", alParaval(1)))
            End With
            DTTABLE = objDBOperation.execute(strCommand, alParameter).Tables(0)
            Return DTTABLE
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SAVEUPLOAD() As Integer
        Dim INTRESULT As Integer
        Try
            Dim STRCOMMAND As String = "SP_TRANS_BOOKING_GROUPDEPARTURE_SAVEUPLOAD"
            Dim ALPARAMATER As New ArrayList
            With ALPARAMATER
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@GROUPDEPNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IMGPATH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I = I + 1
            End With

            INTRESULT = objDBOperation.executeNonQuery(STRCOMMAND, ALPARAMATER)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
