
Imports BL
Imports DevExpress.XtraGrid.Views.Grid

Public Class FollowupReport
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public FOLLOWUSER As String

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Sub showform(ByVal EDITVAL As Boolean, ByVal ENQNO As Integer)
        Try
            If ENQNO = 0 Then
                Exit Sub
            End If

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim OBJENQNO As New PackageQuotation
            OBJENQNO.edit = EDITVAL
            OBJENQNO.MdiParent = MDIMain
            OBJENQNO.TEMPENQNO = ENQNO
            OBJENQNO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FollowupReport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.Alt = True And e.KeyCode = Keys.R Then
            Call TOOLREFRESH_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Keys.P Then
            Call TOOLEXCEL_Click(sender, e)
        ElseIf e.KeyCode = Keys.OemQuotes Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub FollowupReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'PACKAGE ENQUIRY'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            DTFOLLOWUPDATE.Text = Mydate
            DTFOLLOWUPDATE.Focus()
            DTFOLLOWUPDATE.SelectAll()

            If FOLLOWUSER = Nothing Then
                fillgrid()
            Else
                fillusergrid()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search(" ISNULL(HOLIDAYENQMASTER.ENQ_NO, 0) AS ENQNO, HOLIDAYENQMASTER.ENQ_DATE AS ENQDATE, ISNULL(GUESTMASTER.GUEST_NAME, '') AS GUESTNAME, (CASE WHEN ISNULL(ENQ_TOURNAME,'') = '' THEN ISNULL(GROUPDEPARTURE.GROUPDEP_NAME, '') ELSE ENQ_TOURNAME END) AS TOUR, ISNULL(HOLIDAYENQMASTER.ENQ_REMARKS, '') AS REMARKS, ISNULL(HOLIDAYENQMASTER_FOLLOWUP.ENQ_NEXTDATE, GETDATE())  AS NEXTDATE, '' as STAGE, '' AS NARRATION, '' AS FOLLOWTO ", "", "   HOLIDAYENQMASTER INNER JOIN HOLIDAYENQMASTER_FOLLOWUP ON HOLIDAYENQMASTER.ENQ_NO = HOLIDAYENQMASTER_FOLLOWUP.ENQ_NO AND HOLIDAYENQMASTER.ENQ_YEARID = HOLIDAYENQMASTER_FOLLOWUP.ENQ_YEARID INNER JOIN GUESTMASTER ON HOLIDAYENQMASTER.ENQ_GUESTID = GUESTMASTER.GUEST_ID LEFT OUTER JOIN GROUPDEPARTURE ON HOLIDAYENQMASTER.ENQ_GROUPDEPARTUREID = GROUPDEPARTURE.GROUPDEP_NO", " AND ISNULL(HOLIDAYENQMASTER_FOLLOWUP.ENQ_CHK,0) = 'FALSE' AND HOLIDAYENQMASTER_FOLLOWUP.ENQ_NEXTDATE = '" & DTFOLLOWUPDATE.Text & "'  AND HOLIDAYENQMASTER.ENQ_YEARID = " & YearId & " ORDER BY HOLIDAYENQMASTER.ENQ_NO")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
            FILLSTAGE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillusergrid()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search(" ISNULL(HOLIDAYENQMASTER.ENQ_NO, 0) AS ENQNO, HOLIDAYENQMASTER.ENQ_DATE AS ENQDATE, ISNULL(GUESTMASTER.GUEST_NAME, '') AS GUESTNAME, (CASE WHEN ISNULL(ENQ_TOURNAME, '') = '' THEN ISNULL(GROUPDEPARTURE.GROUPDEP_NAME, '') ELSE ENQ_TOURNAME END) AS TOUR, ISNULL(HOLIDAYENQMASTER.ENQ_REMARKS, '') AS REMARKS, ISNULL(HOLIDAYENQMASTER_FOLLOWUP.ENQ_NEXTDATE, '') AS NEXTDATE, USERMASTER.User_Name AS USERNAME ", "", " HOLIDAYENQMASTER INNER JOIN HOLIDAYENQMASTER_FOLLOWUP ON HOLIDAYENQMASTER.ENQ_NO = HOLIDAYENQMASTER_FOLLOWUP.ENQ_NO AND HOLIDAYENQMASTER.ENQ_YEARID = HOLIDAYENQMASTER_FOLLOWUP.ENQ_YEARID INNER JOIN GUESTMASTER ON HOLIDAYENQMASTER.ENQ_GUESTID = GUESTMASTER.GUEST_ID INNER JOIN USERMASTER ON HOLIDAYENQMASTER.ENQ_USERID = USERMASTER.User_id LEFT OUTER JOIN GROUPDEPARTURE ON HOLIDAYENQMASTER.ENQ_GROUPDEPARTUREID = GROUPDEPARTURE.GROUPDEP_NO", " AND HOLIDAYENQMASTER_FOLLOWUP.ENQ_NEXTDATE = '" & DTFOLLOWUPDATE.Text & "' AND USERMASTER.USER_NAME = '" & FOLLOWUSER & "' AND HOLIDAYENQMASTER.ENQ_YEARID = " & YearId & " ORDER BY HOLIDAYENQMASTER.ENQ_NO")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEDIT.Click
        Try
            If USEREDIT = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            showform(True, gridbill.GetFocusedRowCellValue("ENQNO"))
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
            showform(True, gridbill.GetFocusedRowCellValue("ENQNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub TOOLREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLREFRESH.Click
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

    Private Sub TOOLEXCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLEXCEL.Click
        Try
            Dim PATH As String = "" = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Package Enquiry Followup Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            Dim workbook As String = PATH
            If FileIO.FileSystem.FileExists(PATH) = True Then Interaction.GetObject(workbook).close(False)
            GC.Collect()

            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "Package Enquiry Followup Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Package Enquiry Followup Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DTFOLLOWUPDATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTFOLLOWUPDATE.GotFocus
        DTFOLLOWUPDATE.SelectAll()
    End Sub

    Private Sub DTFOLLOWUPDATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DTFOLLOWUPDATE.Validating
        Try
            If DTFOLLOWUPDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(DTFOLLOWUPDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub DTFOLLOWUPDATE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTFOLLOWUPDATE.Validated
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If DTFOLLOWUPDATE.Text <> "__/__/____" Then fillgrid() Else MsgBox("Please Enter Followup Date")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSAVE.Click
        Try
            Dim ROW As DataRow = gridbill.GetFocusedDataRow
            If ROW Is Nothing Then Exit Sub
            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable

            If ROW("FOLLOWTO") <> "" And IsDBNull(ROW("NEXTDATE")) = False Then
                Dim STAGEID As Integer
                Dim GIVENBYID As Integer
                DT = OBJCMN.search(" BOOKEDBY_ID AS ID ", "", " BOOKEDBYMASTER ", " AND BOOKEDBY_NAME =  '" & UserName & "' AND BOOKEDBY_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then GIVENBYID = Val(DT.Rows(0).Item(0))
                DT = OBJCMN.search(" STAGE_ID AS ID ", "", " STAGEMASTER ", " AND STAGE_NAME = '" & gridbill.GetFocusedRowCellValue("STAGE") & "' AND STAGE_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then STAGEID = Val(DT.Rows(0).Item(0))

                'SAVE NEW RECORD
                DT = OBJCMN.Execute_Any_String("INSERT INTO HOLIDAYENQMASTER_FOLLOWUP values( " & Val(gridbill.GetFocusedRowCellValue("ENQNO")) & ",0,1,'" & Format(Now.Date, "dd/MM/yyyy") & "'," & GIVENBYID & ",'" & gridbill.GetFocusedRowCellValue("FOLLOWTO") & "'," & STAGEID & ",'" & Format(Convert.ToDateTime(gridbill.GetFocusedRowCellValue("NEXTDATE")).Date, "dd/MM/yyyy") & "' , '" & gridbill.GetFocusedRowCellValue("NARRATION") & "' , " & CmpId & " ," & Userid & "," & YearId & " )", " ", "")

                'CHK TRUE
                DT = OBJCMN.Execute_Any_String("UPDATE HOLIDAYENQMASTER_FOLLOWUP SET ENQ_CHK = 1 WHERE ENQ_NO = " & Val(gridbill.GetFocusedRowCellValue("ENQNO")) & " AND ENQ_NEXTDATE = '" & DTFOLLOWUPDATE.Text & "' AND ENQ_YEARID = " & YearId, "", "")
            End If

            fillgrid()
            gridbill.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_ValidateRow(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles gridbill.ValidateRow
        Try
            If IsDBNull(gridbill.GetRowCellValue(e.RowHandle, "NEXTDATE")) = False Then
                If gridbill.GetRowCellValue(e.RowHandle, "NEXTDATE") <> "" Then
                    If Convert.ToDateTime(gridbill.GetRowCellValue(e.RowHandle, "NEXTDATE")).Date < Convert.ToDateTime(gridbill.GetRowCellValue(e.RowHandle, "DATE")).Date Then
                        e.Valid = False
                        gridbill.SetColumnError(GNEXTDATE, "Date must be After Today's Date")
                        Exit Sub
                    End If
                End If
            End If
            If IsDBNull(gridbill.GetRowCellValue(e.RowHandle, "NEXTDATE")) = False And gridbill.GetRowCellValue(e.RowHandle, "NEXTDATE") <> "" And IsDBNull(gridbill.GetRowCellValue(e.RowHandle, "FOLLOWTO")) = False Then If MsgBox("Save Entry?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then Call CMDSAVE_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLSTAGE()
        Try
            CMBSTAGE.Items.Clear()
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" STAGE_NAME AS STAGE ", "", " STAGEMASTER ", " AND STAGE_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                For Each DTROW As DataRow In DT.Rows
                    CMBSTAGE.Items.Add(DTROW("STAGE"))
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class