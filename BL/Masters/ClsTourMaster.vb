Imports DB
Public Class ClsTourMaster
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

    Public Function save() As DataTable
        Dim DT As DataTable
        Try
            'save purchase Requisition
            Dim strCommand As String = "SP_MASTER_TOURMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@TOURDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOURNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRPSTRENGTH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOURDAYS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STARTDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ENDDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VISA", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PORT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FAIZE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CTC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VISANO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHKVISANO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CUTOFDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUTOFDAYS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@SELFTOUR", alParaval(I)))
                I = I + 1

                ''A SERVICE TOTAL
                .Add(New SqlClient.SqlParameter("@AADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AINFANT", alParaval(I)))
                I = I + 1

                ''B MISC EXPENSES TOTAL
                .Add(New SqlClient.SqlParameter("@BADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BINFANT", alParaval(I)))
                I = I + 1

                ''C FLIGHT TOTAL
                .Add(New SqlClient.SqlParameter("@CADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CINFANT", alParaval(I)))
                I = I + 1

                ''D CORDINATOR TOTAL
                .Add(New SqlClient.SqlParameter("@DADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DINFANT", alParaval(I)))
                I = I + 1

                ''E LEADER TOTAL
                .Add(New SqlClient.SqlParameter("@ECONTRIBUTION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EINCENTIVES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EREBATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ELEADERCOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ECHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EINFANT", alParaval(I)))
                I = I + 1

                '' ADDITIONAL SERVICES TOTAL
                .Add(New SqlClient.SqlParameter("@FADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FINFANT", alParaval(I)))
                I = I + 1

                '' PURCHASE TOTAL
                .Add(New SqlClient.SqlParameter("@PURCHASEADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURCHASECHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURCHASEINFANT", alParaval(I)))
                I = I + 1

                '' PKG COST
                .Add(New SqlClient.SqlParameter("@PKGADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PKGCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PKGINFANT", alParaval(I)))
                I = I + 1

                ''PROFFIT COST
                .Add(New SqlClient.SqlParameter("@PROFITADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROFITCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROFITINFANT", alParaval(I)))
                I = I + 1

                ''DECLARE COST
                .Add(New SqlClient.SqlParameter("@DECPKGADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DECPKGCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DECPKGINFANT", alParaval(I)))
                I = I + 1

                ''DECLARE COST + ADD SERVICE
                .Add(New SqlClient.SqlParameter("@DECADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DECCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DECINFANT", alParaval(I)))
                I = I + 1

                ''REMARKS
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1

                ''CHKBOX FOR GROUP LEADER COST
                .Add(New SqlClient.SqlParameter("@CHKAPPLYADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHKAPPLYCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHKAPPLY", alParaval(I)))
                I = I + 1



                ''COMPANY DATA
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSFER", alParaval(I)))
                I = I + 1

                ''GRID CURRENCY
                .Add(New SqlClient.SqlParameter("@CURGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CURCURRENCY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CURRATE", alParaval(I)))
                I = I + 1

                ''GRID COUNTRY
                .Add(New SqlClient.SqlParameter("@COUGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COUCOUNTRY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COUCITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COUFROMDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COUTODATE", alParaval(I)))
                I = I + 1

                '' GRID SERVICES
                .Add(New SqlClient.SqlParameter("@SERGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SERCURRENCY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SERADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SERADULTINR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SERCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SERCHILDINR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SERINFANT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SERINFANTINR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SERTYPE", alParaval(I)))
                I = I + 1

                ''GRID MISC EXPENSES
                .Add(New SqlClient.SqlParameter("@MISCGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MISCEXP", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MISCCURRENCY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MISCADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MISCADULTINR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MISCCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MISCCHILDINR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MISCINFANT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MISCINFANTINR", alParaval(I)))
                I = I + 1

                ''GRID FLIGHT
                .Add(New SqlClient.SqlParameter("@FLIGHTGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLIGHTNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLIGHTDET", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLIGHTNARR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLIGHTDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLIGHTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLIGHTARR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLIGHTCURRENCY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLIGHTADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLIGHTADULTINR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLIGHTCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLIGHTCHILDINR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLIGHTINFANT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLIGHTINFANTINR", alParaval(I)))
                I = I + 1

                '' GRID CORDINATOR
                .Add(New SqlClient.SqlParameter("@COGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COCURRENCY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COADULTINR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COCHILDINR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COINFANT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COINFANTINR", alParaval(I)))
                I = I + 1

                ''GRID LEADER
                .Add(New SqlClient.SqlParameter("@GRPGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRPNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRPCONTRI", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRPINCENTIVES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRPREBATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRPLEADERCOST", alParaval(I)))
                I = I + 1

                ''GRID ADD SERVICES
                .Add(New SqlClient.SqlParameter("@ADDGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADDSERVICES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADDCURRENCY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADDADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADDADULTINR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADDCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADDCHILDINR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADDINFANT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADDINFANTINR", alParaval(I)))
                I = I + 1

                ''GRID PURCHASE
                .Add(New SqlClient.SqlParameter("@PURGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURINFANT", alParaval(I)))
                I = I + 1

                ''GRID TOUR DETAILS
                .Add(New SqlClient.SqlParameter("@TOURSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITENARYDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOURDETAILS", alParaval(I)))
                I = I + 1

            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

    Public Function SAVEUPLOAD() As Integer

        Dim intResult As Integer
        Dim strcommand As String = ""

        Try

            'Update AccountsMaster
            strcommand = "SP_TOURMASTER_SAVEUPLOAD"

            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@TOURNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@IMGPATH", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TRANSFER", alParaval(I)))
                I += 1

            End With

            intResult = objDBOperation.executeNonQuery(strcommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function SELECTTOUR() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_MASTER_SELECT_TOURMASTER"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@TOURNO", alParaval(0)))
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
            Dim strCommand As String = "SP_MASTER_TOURMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@TOURDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOURNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRPSTRENGTH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOURDAYS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STARTDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ENDDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VISA", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PORT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FAIZE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CTC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VISANO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHKVISANO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CUTOFDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUTOFDAYS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@SELFTOUR", alParaval(I)))
                I = I + 1

                ''A SERVICE TOTAL
                .Add(New SqlClient.SqlParameter("@AADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AINFANT", alParaval(I)))
                I = I + 1

                ''B MISC EXPENSES TOTAL
                .Add(New SqlClient.SqlParameter("@BADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BINFANT", alParaval(I)))
                I = I + 1

                ''C FLIGHT TOTAL
                .Add(New SqlClient.SqlParameter("@CADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CINFANT", alParaval(I)))
                I = I + 1

                ''D CORDINATOR TOTAL
                .Add(New SqlClient.SqlParameter("@DADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DINFANT", alParaval(I)))
                I = I + 1

                ''E LEADER TOTAL
                .Add(New SqlClient.SqlParameter("@ECONTRIBUTION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EINCENTIVES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EREBATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ELEADERCOST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ECHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EINFANT", alParaval(I)))
                I = I + 1

                '' ADDITIONAL SERVICES TOTAL
                .Add(New SqlClient.SqlParameter("@FADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FINFANT", alParaval(I)))
                I = I + 1

                '' PURCHASE TOTAL
                .Add(New SqlClient.SqlParameter("@PURCHASEADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURCHASECHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURCHASEINFANT", alParaval(I)))
                I = I + 1

                '' PKG COST
                .Add(New SqlClient.SqlParameter("@PKGADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PKGCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PKGINFANT", alParaval(I)))
                I = I + 1

                ''PROFFIT COST
                .Add(New SqlClient.SqlParameter("@PROFITADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROFITCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROFITINFANT", alParaval(I)))
                I = I + 1

                ''DECLARE COST
                .Add(New SqlClient.SqlParameter("@DECPKGADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DECPKGCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DECPKGINFANT", alParaval(I)))
                I = I + 1

                ''DECLARE COST + ADD SERVICE
                .Add(New SqlClient.SqlParameter("@DECADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DECCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DECINFANT", alParaval(I)))
                I = I + 1

                ''REMARKS
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1

                ''CHKBOX FOR GROUP LEADER COST
                .Add(New SqlClient.SqlParameter("@CHKAPPLYADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHKAPPLYCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHKAPPLY", alParaval(I)))
                I = I + 1

                ''COMPANY DATA
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSFER", alParaval(I)))
                I = I + 1

                ''GRID CURRENCY
                .Add(New SqlClient.SqlParameter("@CURGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CURCURRENCY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CURRATE", alParaval(I)))
                I = I + 1

                ''GRID COUNTRY
                .Add(New SqlClient.SqlParameter("@COUGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COUCOUNTRY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COUCITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COUFROMDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COUTODATE", alParaval(I)))
                I = I + 1

                '' GRID SERVICES
                .Add(New SqlClient.SqlParameter("@SERGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SERCURRENCY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SERADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SERADULTINR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SERCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SERCHILDINR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SERINFANT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SERINFANTINR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SERTYPE", alParaval(I)))
                I = I + 1

                ''GRID MISC EXPENSES
                .Add(New SqlClient.SqlParameter("@MISCGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MISCEXP", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MISCCURRENCY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MISCADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MISCADULTINR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MISCCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MISCCHILDINR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MISCINFANT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MISCINFANTINR", alParaval(I)))
                I = I + 1

                ''GRID FLIGHT
                .Add(New SqlClient.SqlParameter("@FLIGHTGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLIGHTNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLIGHTDET", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLIGHTNARR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLIGHTDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLIGHTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLIGHTARR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLIGHTCURRENCY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLIGHTADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLIGHTADULTINR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLIGHTCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLIGHTCHILDINR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLIGHTINFANT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLIGHTINFANTINR", alParaval(I)))
                I = I + 1

                '' GRID CORDINATOR
                .Add(New SqlClient.SqlParameter("@COGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COCURRENCY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COADULTINR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COCHILDINR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COINFANT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COINFANTINR", alParaval(I)))
                I = I + 1

                ''GRID LEADER
                .Add(New SqlClient.SqlParameter("@GRPGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRPNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRPCONTRI", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRPINCENTIVES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRPREBATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRPLEADERCOST", alParaval(I)))
                I = I + 1

                ''GRID ADD SERVICES
                .Add(New SqlClient.SqlParameter("@ADDGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADDSERVICES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADDCURRENCY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADDADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADDADULTINR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADDCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADDCHILDINR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADDINFANT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADDINFANTINR", alParaval(I)))
                I = I + 1

                ''GRID PURCHASE
                .Add(New SqlClient.SqlParameter("@PURGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURINFANT", alParaval(I)))
                I = I + 1

                ''GRID TOUR DETAILS
                .Add(New SqlClient.SqlParameter("@TOURSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITENARYDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOURDETAILS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TOURNO", alParaval(I)))
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
            Dim strCommand As String = "SP_MASTER_TOURMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@TOURNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@LOCATIONid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@YEARid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(4)))

            End With
            DTTABLE = objDBOperation.execute(strCommand, alParameter).Tables(0)
            Return DTTABLE
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region
End Class
