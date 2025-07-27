
Imports BL

Public Class LedgerDetailsReport

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub LedgerDetailsReport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal WHERECLAUSE As String)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search("  ISNULL(LEDGERS.Acc_cmpname,'') AS CMPNAME, ISNULL(LEDGERS.Acc_name,'') AS NAME, ISNULL(LEDGERS.Acc_code,'') AS CODE, ISNULL(GROUPMASTER.group_name,'') AS GROUPNAME,ISNULL(GROUPMASTER.group_secondary, '') AS SECONDARY,ISNULL(LEDGERS.ACC_TYPE,'') AS TYPE, ISNULL(LEDGERS.Acc_opbal,0) AS OPBAL, ISNULL(LEDGERS.Acc_drcr,'') AS DRCR, ISNULL(AREAMASTER.area_name,'') AS AREA, ISNULL(CITYMASTER.city_name,'') AS CITY, ISNULL(STATEMASTER.state_name,'') AS STATE, ISNULL(COUNTRYMASTER.country_name,'') AS COUNTRY, ISNULL(LEDGERS.Acc_resino,'') AS RESINO, ISNULL(LEDGERS.Acc_altno,'') AS ALTNO, ISNULL(LEDGERS.Acc_phone,'') AS PHONENO, ISNULL(LEDGERS.Acc_mobile,'') AS MOBILE, ISNULL(LEDGERS.Acc_fax,'') AS FAX, ISNULL(LEDGERS.Acc_website,'') AS WEBSITE, ISNULL(LEDGERS.Acc_email,'') AS EMAIL, ISNULL(LEDGERS.Acc_panno,'') AS PANNO, ISNULL(LEDGERS.Acc_add,'') AS [ADD],ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(CATEGORYMASTER.CATEGORY_NAME,'') AS CATEGORY ", "", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN CITYMASTER ON LEDGERS.Acc_cityid = CITYMASTER.city_id LEFT OUTER JOIN AREAMASTER ON LEDGERS.Acc_areaid = AREAMASTER.area_id LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN COUNTRYMASTER ON LEDGERS.Acc_countryid = COUNTRYMASTER.country_id LEFT OUTER JOIN CATEGORYMASTER ON LEDGERS.ACC_CATEGORYID = CATEGORYMASTER.CATEGORY_ID", WHERECLAUSE & " AND LEDGERS.ACC_YEARID = " & YearId & " ORDER BY LEDGERS.ACC_CMPNAME")
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
            PATH = Application.StartupPath & "\Ledger Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            Dim workbook As String = PATH
            If FileIO.FileSystem.FileExists(PATH) = True Then Interaction.GetObject(workbook).close(False)
            GC.Collect()
            'For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
            '    proc.Kill()
            'Next

            Dim PERIOD As String = AccFrom & " - " & AccTo
            
            opti.SheetName = "Ledger Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Ledger Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LedgerDetailsReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillgrid("")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSAVE.Click
        Try
            fillgrid("")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class