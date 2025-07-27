
Imports Microsoft.Win32 ' for registry access
Imports System.IO


Module Module1

    '******** COMMON VARIABLES **************
    Public Mydate As DateTime                           'Used for SQL Date throughout the Software at the time of login

    
    ' Public Servername As String = "1.186.114.131"          '' *** Khanna travels Static IP *** ''

    'Public Servername As String = "LAPTOP"          'Used for Servername for reports
    'Public DatabaseName As String = "HOSPITALITY"
    'Public DBUSERNAME As String = "sa"              'Used for Servername username for reports
    'Public Dbpassword As String = "infosys123"        ''Used for Servername password for reports
    'Public Dbsecurity As Boolean = False


    Public SERVERNAME As String
    Public DatabaseName As String
    Public DBUSERNAME As String             'Used for Servername username for reports
    Public Dbpassword As String         ''Used for Servername password for reports
    Public Dbsecurity As Boolean

    'CLIENTNAMES
    '*************
    'AERO
    'AIRTRINITY
    'APPLE
    'ARCH
    'ARHAM
    'ARUN
    'BARODA
    'BHAGYASHRI
    'CLASSIC
    'FINASTA
    'GLOBE
    'HBAZAAR
    'HEENKAR
    'HEERA
    'KHANNA
    'LUXCREST
    'MAHARAJA
    'MANYA
    'MILONI
    'NAMASTE
    'OFFBEAT
    'PRATAMESH
    'RAMKRISHNA
    'SAFAR
    'SCC
    'SEASONED
    'SHREEJI
    'SKYMAPS
    'SSR
    'STARVISA
    'TOPCOMM
    'TRINITY
    'TRISHA
    'URMI
    'WAHWAH
    'WHITEPEARL
    'WORLDSPIN



    Public ClientName As String = "CLASSIC"




    '******** FORM WISE VARIABLES ************
    '---CMPDETAILS---
    Public CmpName As String            'Used for CmpName throughout the software 
    Public DBName As String             'Used for DBName throughout the software 
    Public CmpId As Integer             'Used for CmpId throughout the software
    Public YearId As Integer            'Used for YearId throughout the software
    Public AccFrom, AccTo As DateTime   'Used for A/C year start and end throughout the software
    Public Locationid As Integer        'Used for Locationid while login

    Public MANUAL As Boolean
    Public SMS As Boolean
    Public PRINTDIRECT As Boolean
    Public CHQPRINT As Boolean
    Public AIRLINE As Boolean
    Public CAR As Boolean
    Public RAILWAY As Boolean
    Public HOLIDAY As Boolean
    Public HOTEL As Boolean
    Public MISC As Boolean
    Public CCEMAIL As String
    Public ALLOWSMS As Boolean = False
    Public APPLYGST As Boolean = True
    Public APPLYCESS As Boolean = False
    Public ALLOWSAMESTATE As Boolean = False
    Public ALLOWEINVOICE As Boolean = False
    Public LEADMANAGEMENT As Boolean = False


    'THESE VARIABLES ARE USED FOR EWB AND GST
    Public CMPEWBUSER As String       'Used for COMPANY'S EWBUSER
    Public CMPEWBPASS As String       'Used for COMPANY'S EWBPASS
    Public CMPGSTIN As String       'Used for COMPANY'S GSTIN
    Public CMPPINCODE As String       'Used for COMPANY'S PINCODE
    Public CMPCITYNAME As String       'Used for COMPANY'S CITYNAME
    Public CMPSTATENAME As String       'Used for COMPANY'S STATE NAME
    Public CMPSTATECODE As String       'Used for COMPANY'S STATE CODE
    Public CMPEINVOICECOUNTER As Integer    'Used for COMPANY'S EINVOICE COUNTER
    Public EINVOICEEXPDATE As Date          'Used for COMPANY'S EINVOICE EXPIRY DATE
    Public CMPADDRESS As String         'Used for COMPANY'S ADDRESS
    Public CMPTEL As String       'Used for COMPANY'S TELNO

    '---LOGIN---
    Public Userid As Integer                'Used for Userid while login
    Public UserName As String               'User for UserName while Login
    Public UserTelNo As String               'User for UserTelNo while Login
    Public USEREMAIL As String               'User for UserTelNo while Login
    Public LastTransferDate As Date         'Used for getting LastTransferDate from getting data from eagle's database

    '---VARIABLE---
    Public USERRIGHTS As DataTable          'USED FOR USER RIGHTS THROUGHOUT THE APPLICATION 

    'USED FOR SPECIAL RIGHTS
    Public ENQTRANSFER As Boolean          ''TRANSFER MISC ENQ TO ANOTHER USER
    Public FETCHDATA As Boolean             ''FETCH DATA FROM WEBSITE(SYNC DATA)
    Public FOLLOWUP As Boolean              'FOLLOWUP REPORTS 
    Public MISCENQUIRYREPORT As Boolean           ' MISC ENQUIRY REPORTS
    Public OUTSTANDING As Boolean           'Show REC/PAY Outstanding Panel on Homepage
    Public CHECKIN As Boolean               'Show Tomorrow's check in on Homepage
    Public SHOWMEMBERSHIPFORM As Boolean               'Show MEMBERSHIP FORM
    Public DISCONTINUECLIENT As Boolean = False


    '---VOUCHERS---
    Public REPORTTYPE As Boolean        'USED TO CHECK IF THE CLIENT WILL USINMG OUR DEFAULT FORMAT OR NOT



    'CODE TO PROGRAMMATICALLY CREATE D. S. N.
    'Module CreateDSN

    Private Declare Function SQLConfigDataSource Lib "ODBCCP32.DLL" (ByVal hwndParent As Integer, ByVal ByValfRequest As Integer, ByVal lpszDriver As String, ByVal lpszAttributes As String) As Integer
    Private Const vbAPINull As Integer = 0 ' NULL Pointer
    Private Const ODBC_ADD_SYS_DSN As Short = 1 ' Add data source

    Public Sub GETCONN()
        Try
            '-------NOTEPAD CODE --------

            Dim STARTPOS, ENDPOS As Integer
            Dim CONNSTR As String
            Dim oRead As System.IO.StreamReader = File.OpenText("C:\CONNECTIONSTRING.txt")
            CONNSTR = oRead.ReadToEnd

            STARTPOS = CONNSTR.IndexOf("=", 0)
            ENDPOS = CONNSTR.IndexOf(";", STARTPOS)
            SERVERNAME = CONNSTR.Substring(STARTPOS + 1, ENDPOS - STARTPOS - 1).Trim

            STARTPOS = CONNSTR.IndexOf("=", ENDPOS)
            ENDPOS = CONNSTR.IndexOf(";", STARTPOS)
            DatabaseName = CONNSTR.Substring(STARTPOS + 1, ENDPOS - STARTPOS - 1).Trim

            If CONNSTR.IndexOf("User ID", ENDPOS) > 0 Then
                STARTPOS = CONNSTR.IndexOf("=", ENDPOS)
                ENDPOS = CONNSTR.IndexOf(";", STARTPOS)
                DBUSERNAME = CONNSTR.Substring(STARTPOS + 1, ENDPOS - STARTPOS - 1).Trim

                STARTPOS = CONNSTR.IndexOf("=", ENDPOS)
                ENDPOS = CONNSTR.IndexOf(";", STARTPOS)
                Dbpassword = CONNSTR.Substring(STARTPOS + 1, ENDPOS - STARTPOS - 1).Trim

                Dbsecurity = False

            Else
                DBUSERNAME = ""
                Dbpassword = ""
                Dbsecurity = True
            End If
            
            '----------------- NOTEPAD CODE---------
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Module
