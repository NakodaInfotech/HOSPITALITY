
Imports BL

Public Class AttendenceDetails

    Public EMPNAME As String = ""
    Public ATTDATE As Date

    Private Sub AttendenceDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
             End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AttendenceDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("  RIGHT(CONVERT(VARCHAR, ATT_DATE, 100),7) AS TIME ", "", " ATTENDENCE INNER JOIN EMPLOYEEMASTER ON ATTENDENCE.ATT_EMPID = EMPLOYEEMASTER.EMP_id AND ATTENDENCE.ATT_CMPID = EMPLOYEEMASTER.EMP_cmpid AND ATTENDENCE.ATT_LOCATIONID = EMPLOYEEMASTER.EMP_locationid AND ATTENDENCE.ATT_YEARID = EMPLOYEEMASTER.EMP_yearid  ", " AND EMP_NAME = '" & EMPNAME & "' AND CAST(ATT_DATE AS DATE) = '" & Format(ATTDATE, "MM/dd/yyyy") & "' AND ATT_CMPID = " & CmpId & " AND ATT_LOCATIONID = " & Locationid & " AND ATT_YEARID = " & YearId)
            gridbilldetails.DataSource = DT
         
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = "" = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Attendence Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            Dim workbook As String = PATH
            If FileIO.FileSystem.FileExists(PATH) = True Then Interaction.GetObject(workbook).close(False)
            GC.Collect()
            'For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
            '    proc.Kill()
            'Next

            Dim PERIOD As String = ""
            PERIOD = DateAdd(DateInterval.Day, 1, Now.Date) & " - " & DateAdd(DateInterval.Day, 1, Now.Date)
            
            opti.SheetName = "Attendence Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Attendence Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class