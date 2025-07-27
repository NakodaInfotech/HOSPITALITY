
Imports BL

Public Class HotelDetailsReport

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub HotelDetailsReport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal WHERECLAUSE As String)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search(" HOTELMASTER.HOTEL_NAME AS HOTELNAME, ISNULL(AREAMASTER.area_name, '') AS AREA, ISNULL(HOTELMASTER.HOTEL_STD, '') AS STD, ISNULL(CITYMASTER.city_name, '') AS CITY, ISNULL(STATEMASTER.state_name, '') AS STATE, ISNULL(COUNTRYMASTER.country_name, '') AS COUNTRY, ISNULL(HOTELMASTER.HOTEL_ALTNO, '') AS ALTNO, ISNULL(HOTELMASTER.HOTEL_PHONENO, '') AS PHONENO, ISNULL(HOTELMASTER.HOTEL_MOBILENO, '') AS MOBILENO, ISNULL(HOTELMASTER.HOTEL_FAXNO, '') AS FAXNO, ISNULL(HOTELMASTER.HOTEL_WEBSITE, '') AS WEBSITE, ISNULL(HOTELMASTER.HOTEL_EMAILID, '') AS EMAIL, ISNULL(HOTELMASTER.HOTEL_ADD, '') AS ADDRESS  ", "", " HOTELMASTER LEFT OUTER JOIN COUNTRYMASTER ON HOTELMASTER.HOTEL_YEARID = COUNTRYMASTER.country_yearid AND HOTELMASTER.HOTEL_LOCATIONID = COUNTRYMASTER.country_locationid AND HOTELMASTER.HOTEL_CMPID = COUNTRYMASTER.country_cmpid AND HOTELMASTER.HOTEL_COUNTRYID = COUNTRYMASTER.country_id LEFT OUTER JOIN STATEMASTER ON HOTELMASTER.HOTEL_YEARID = STATEMASTER.state_yearid AND HOTELMASTER.HOTEL_LOCATIONID = STATEMASTER.state_locationid AND HOTELMASTER.HOTEL_CMPID = STATEMASTER.state_cmpid AND HOTELMASTER.HOTEL_STATEID = STATEMASTER.state_id LEFT OUTER JOIN CITYMASTER ON HOTELMASTER.HOTEL_YEARID = CITYMASTER.city_yearid AND HOTELMASTER.HOTEL_LOCATIONID = CITYMASTER.city_locationid AND HOTELMASTER.HOTEL_CMPID = CITYMASTER.city_cmpid AND HOTELMASTER.HOTEL_CITYID = CITYMASTER.city_id LEFT OUTER JOIN AREAMASTER ON HOTELMASTER.HOTEL_YEARID = AREAMASTER.area_yearid AND HOTELMASTER.HOTEL_LOCATIONID = AREAMASTER.area_locationid AND HOTELMASTER.HOTEL_CMPID = AREAMASTER.area_cmpid AND HOTELMASTER.HOTEL_AREAID = AREAMASTER.area_id ", WHERECLAUSE & " AND HOTEL_CMPID =" & CmpId & " AND HOTEL_LOCATIONID = " & Locationid & " AND HOTEL_YEARID = " & YearId & " ORDER BY HOTEL_NAME")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then gridbill.FocusedRowHandle = gridbill.RowCount - 1
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub CMDPRINT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDPRINT.Click
        Try
            Dim PATH As String = "" = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Hotel Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True


            Dim workbook As String = PATH
            If FileIO.FileSystem.FileExists(PATH) = True Then Interaction.GetObject(workbook).close(False)
            GC.Collect()
            'For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
            '    proc.Kill()
            'Next

            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "Hotel Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Hotel Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HotelDetailsReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillgrid("")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class