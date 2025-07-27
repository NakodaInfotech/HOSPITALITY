Imports BL
Imports DevExpress.XtraGrid.Views.Grid

Public Class GuestLedgerDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Sub showform(ByVal EDITVAL As Boolean, ByVal name As String)
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim OBJGUEST As New GuestMaster
            OBJGUEST.edit = EDITVAL
            OBJGUEST.MdiParent = MDIMain
            OBJGUEST.TEMPGUESTNAME = name
            OBJGUEST.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GuestLedgerDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.Alt = True And e.KeyCode = Keys.R Then
            Call CMDREFRESH_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Keys.P Then
            Call CMDPRINT_Click(sender, e)
        ElseIf e.KeyCode = Keys.OemQuotes Then
            e.SuppressKeyPress = True
        End If
    End Sub


    Private Sub GuestLedgerDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'GUEST MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search(" GUESTMASTER.GUEST_ID AS GUESTID, GUESTMASTER.GUEST_NAME AS NAME, ISNULL(AREAMASTER.area_name, '') AS AREANAME, GUESTMASTER.GUEST_STD AS STD, ISNULL(CITYMASTER.city_name, '') AS CITYNAME, GUESTMASTER.GUEST_ZIPCODE AS ZIPCODE, ISNULL(STATEMASTER.state_name, '') AS STATENAME, ISNULL(COUNTRYMASTER.country_name, '') AS COUNTRYNAME, (CASE WHEN ISNULL(GUESTMASTER.GUEST_ISDOB ,0) = 0 THEN NULL ELSE  GUESTMASTER.GUEST_DOB END) AS DOB, (case when ISNULL(GUESTMASTER.GUEST_ISDOA,0) = 0 then NULL ELSE GUESTMASTER.GUEST_DOA END) AS DOA, ISNULL(GUESTMASTER.GUEST_RESINO, '') AS RESINO, ISNULL(GUESTMASTER.GUEST_ALTNO, '') AS ALTNO, ISNULL(GUESTMASTER.GUEST_PHONENO, '') AS PHONE, ISNULL(GUESTMASTER.GUEST_MOBILENO, '') AS MOBILE, ISNULL(GUESTMASTER.GUEST_FAXNO, '') AS FAX, ISNULL(GUESTMASTER.GUEST_EMAIL, '') AS EMAIL, ISNULL(REFMASTER.GUEST_NAME, '') AS REF, ISNULL(NATIONALITYMASTER.NAT_name, '') AS NATIONALITY, ISNULL(GUESTMASTER.GUEST_ADD, '') AS [ADD], ISNULL(GUESTMASTER.GUEST_REMARKS, '') AS REMARKS, ISNULL(GUESTMASTER.GUEST_DISPLAYNAME, '') AS DISPLAYNAME, ISNULL(GUESTMASTER.GUEST_PASSPORTNO, '') AS PASSPORTNO, GUESTMASTER.GUEST_ISSUEDATE AS ISSUEDATE, GUESTMASTER.GUEST_EXPIRYDATE AS EXPIRYDATE, ISNULL(GUESTMASTER.GUEST_SURNAME, '') AS SURNAME, ISNULL(GUESTMASTER.GUEST_GENDER, '') AS GENDER, ISNULL(GUESTMASTER.GUEST_STATUS, '') AS STATUS, ISNULL(GUESTMASTER.GUEST_REFFVIA, '') AS REFFVIA, ISNULL(CORDINATOR.GUEST_NAME, '') AS CORDINATORVIA, ISNULL(CATEGORY_NAME,'') AS GUESTCATEGORY", "", " GUESTMASTER LEFT OUTER JOIN GUESTCATEGORYMASTER ON GUESTCATEGORYMASTER.CATEGORY_ID = GUESTMASTER.GUEST_GUESTCATEGORYID LEFT OUTER JOIN GUESTMASTER AS CORDINATOR ON GUESTMASTER.GUEST_CORDINATORVIAID = CORDINATOR.GUEST_ID LEFT OUTER JOIN PREFIXMASTER ON GUESTMASTER.GUEST_PREFIXID = PREFIXMASTER.PREFIX_ID LEFT OUTER JOIN COUNTRYMASTER AS ISSUECOUNTRY ON GUESTMASTER.GUEST_ISSUECOUNTRYID = ISSUECOUNTRY.country_id LEFT OUTER JOIN NATIONALITYMASTER ON GUESTMASTER.GUEST_NATIONALITYID = NATIONALITYMASTER.NAT_id LEFT OUTER JOIN GUESTMASTER AS REFMASTER ON GUESTMASTER.GUEST_REFBYID = REFMASTER.GUEST_ID LEFT OUTER JOIN COUNTRYMASTER ON GUESTMASTER.GUEST_COUNTRYID = COUNTRYMASTER.country_id LEFT OUTER JOIN STATEMASTER ON GUESTMASTER.GUEST_STATEID = STATEMASTER.state_id LEFT OUTER JOIN CITYMASTER ON GUESTMASTER.GUEST_CITYID = CITYMASTER.city_id LEFT OUTER JOIN AREAMASTER ON GUESTMASTER.GUEST_AREAID = AREAMASTER.area_id ", " AND GUESTMASTER.GUEST_YEARID = " & YearId & " ORDER BY GUESTMASTER.GUEST_NAME")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub gridbill_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            If USEREDIT = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            showform(True, gridbill.GetFocusedRowCellValue("NAME"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub CMDPRINT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDPRINT.Click
        Try
            Dim PATH As String = "" = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Guest Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            Dim workbook As String = PATH
            If FileIO.FileSystem.FileExists(PATH) = True Then Interaction.GetObject(workbook).close(False)
            GC.Collect()

            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "Guest Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Guest Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class