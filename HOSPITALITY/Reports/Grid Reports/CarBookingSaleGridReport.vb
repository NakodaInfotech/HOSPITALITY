
Imports BL

Public Class CarBookingSaleGridReport

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public FRMSTRING, WHERECLAUSE As String

    Private Sub CarBookingSaleGridReport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" CARBOOKINGMASTER.BOOKING_NO AS BILL, CARBOOKINGMASTER.BOOKING_SALEBILLINITIALS AS BILLINITIALS,  CARBOOKINGMASTER.BOOKING_PACKAGEFROM AS DATE, CARBOOKINGMASTER_DESC.BOOKING_VEHICLENO AS VEHICLENO, VEHICLEMASTER.VEHICLE_NAME AS VEHICLENAME, DRIVERMASTER.DRIVER_NAME AS DRIVERNAME, CARBOOKINGMASTER.BOOKING_CONFIRMEDBY AS CONFIRMEDBY, GUESTMASTER.GUEST_NAME AS GUESTNAME, CARBOOKINGMASTER.BOOKING_STARTTIME AS STARTTIME,  CARBOOKINGMASTER.BOOKING_ENDTIME AS ENDTIME, (CARBOOKINGMASTER.BOOKING_ENDTIME-CARBOOKINGMASTER.BOOKING_STARTTIME) AS TOTALTIME,  CAST(CARBOOKINGMASTER.BOOKING_REFNO AS INT) AS NIGHTCHGS, CARBOOKINGMASTER.BOOKING_STARTKMS AS STARTKMS, CARBOOKINGMASTER.BOOKING_ENDKMS AS ENDKMS, (CARBOOKINGMASTER.BOOKING_ENDKMS-CARBOOKINGMASTER.BOOKING_STARTKMS) AS TOTALKMS, CASE WHEN ISNULL(BOOKING_TYPE , 'LOCAL') = 'LOCAL' THEN (ISNULL(CARBOOKINGMASTER.BOOKING_ENDKMS, 0)-ISNULL(CARBOOKINGMASTER.BOOKING_STARTKMS, 0))-80 ELSE (CASE WHEN BOOKING_TYPE  = '4HRS 40KMS' THEN (ISNULL(CARBOOKINGMASTER.BOOKING_ENDKMS, 0)-ISNULL(CARBOOKINGMASTER.BOOKING_STARTKMS, 0))-40 ELSE (ISNULL(CARBOOKINGMASTER.BOOKING_ENDKMS, 0)-ISNULL(CARBOOKINGMASTER.BOOKING_STARTKMS, 0)) END) END  AS EXTRAKMS, CASE WHEN ISNULL(BOOKING_TYPE , 'LOCAL') = 'LOCAL' THEN (ISNULL(CARBOOKINGMASTER.BOOKING_ENDTIME, 0)-ISNULL(CARBOOKINGMASTER.BOOKING_STARTTIME, 0))-8 ELSE (CASE WHEN BOOKING_TYPE  = '4HRS 40KMS' THEN (ISNULL(CARBOOKINGMASTER.BOOKING_ENDTIME, 0)-ISNULL(CARBOOKINGMASTER.BOOKING_STARTTIME, 0))-4 ELSE (ISNULL(CARBOOKINGMASTER.BOOKING_ENDTIME, 0)-ISNULL(CARBOOKINGMASTER.BOOKING_STARTTIME, 0)) END) END  AS EXTRATIME, CARBOOKINGMASTER.BOOKING_OTHERCHGS AS TOLLANDPARKING, LEDGERS.Acc_cmpname AS ACCNAME ", "", " CARBOOKINGMASTER INNER JOIN CARBOOKINGMASTER_DESC ON CARBOOKINGMASTER.BOOKING_NO = CARBOOKINGMASTER_DESC.BOOKING_NO AND CARBOOKINGMASTER.BOOKING_YEARID = CARBOOKINGMASTER_DESC.BOOKING_YEARID INNER JOIN GUESTMASTER ON CARBOOKINGMASTER.BOOKING_GUESTID = GUESTMASTER.GUEST_ID INNER JOIN LEDGERS ON CARBOOKINGMASTER.BOOKING_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN VEHICLEMASTER ON CARBOOKINGMASTER_DESC.BOOKING_VEHICLEID = VEHICLEMASTER.VEHICLE_ID LEFT OUTER JOIN DRIVERMASTER ON CARBOOKINGMASTER_DESC.BOOKING_DRIVERID = DRIVERMASTER.DRIVER_ID  ", WHERECLAUSE & " ORDER BY CARBOOKINGMASTER.BOOKING_NO")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub CarBookingSaleGridReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = "" = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Sale Report.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            Dim workbook As String = PATH
            If FileIO.FileSystem.FileExists(PATH) = True Then Interaction.GetObject(workbook).close(False)
            GC.Collect()
            'For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
            '    proc.Kill()
            'Next

            opti.SheetName = ""
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Sale Report", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", "")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal BOOKINGNO As Integer)
        Try
            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim OBJBOOKING As New CarBooking
                OBJBOOKING.MdiParent = MDIMain
                OBJBOOKING.edit = editval
                OBJBOOKING.TEMPBOOKINGNO = BOOKINGNO
                OBJBOOKING.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("BILL"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class