
Imports BL
Imports DevExpress.XtraGrid.Views.Grid

Public Class HotelEnqFollowupReport
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

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
            Dim OBJENQNO As New HotelQuotation
            OBJENQNO.edit = EDITVAL
            OBJENQNO.MdiParent = MDIMain
            OBJENQNO.TEMPENQNO = ENQNO
            OBJENQNO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HotelEnqFollowupReport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub HotelEnqFollowupReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DTFOLLOWUPDATE.Text = Mydate
        DTFOLLOWUPDATE.Focus()
        DTFOLLOWUPDATE.SelectAll()
    End Sub

    Sub fillgrid()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search(" ISNULL(HOTELENQMASTER.ENQ_NO, 0) AS ENQNO, HOTELENQMASTER.ENQ_DATE AS ENQDATE, ISNULL(GUESTMASTER.GUEST_NAME, '') AS GUESTNAME, ISNULL(HOTELMASTER.HOTEL_NAME, '') AS HOTEL, ISNULL(HOTELENQMASTER.ENQ_BOOKINGDESC, '') AS REMARKS, ISNULL(HOTELENQMASTER_FOLLOWUP.ENQ_NEXTDATE, '') AS NEXTDATE", "", "  HOTELENQMASTER INNER JOIN HOTELENQMASTER_FOLLOWUP ON HOTELENQMASTER.ENQ_NO = HOTELENQMASTER_FOLLOWUP.ENQ_NO AND HOTELENQMASTER.ENQ_YEARID = HOTELENQMASTER_FOLLOWUP.ENQ_YEARID INNER JOIN HOTELMASTER ON HOTELENQMASTER.ENQ_HOTELID = HOTELMASTER.HOTEL_ID INNER JOIN GUESTMASTER ON HOTELENQMASTER.ENQ_GUESTID = GUESTMASTER.GUEST_ID", " AND HOTELENQMASTER_FOLLOWUP.ENQ_NEXTDATE = '" & DTFOLLOWUPDATE.Text & "'  AND HOTELENQMASTER.ENQ_YEARID = " & YearId & " ORDER BY HOTELENQMASTER.ENQ_NO")
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

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'PACKAGE ENQUIRY'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)



            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If DTFOLLOWUPDATE.Text <> "__/__/____" Then fillgrid() Else MsgBox("Please Enter Followup Date")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class