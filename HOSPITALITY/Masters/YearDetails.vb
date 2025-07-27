
Imports BL

Public Class YearDetails

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        End
    End Sub

    Private Sub cmdcreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcreate.Click
        Try
            Dim TEMPMSG As Integer = MsgBox("Create New Accounting Year?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                Dim obj As New YearMaster
                obj.cmdback.Visible = False
                obj.EDIT = False
                obj.FRMSTRING = "ADDYEAR"
                obj.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub YearDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.N) Then
                Dim objYEARmaster As New YearMaster
                objYEARmaster.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillYEAR()
        Try
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            Dim whereclause As String = ""
            dt = objclscommon.search(" distinct user_YEARid", "", "UserMaster", " and User_Name = '" & UserName & "' and user_cmpid = " & CmpId)
            For Each DTROW As DataRow In dt.Rows
                If whereclause = "" Then
                    whereclause = " AND YEAR_ID IN (" & DTROW(0)
                Else
                    whereclause = whereclause & "," & DTROW(0)
                End If
            Next
            If whereclause <> "" Then whereclause = whereclause & ")"
            whereclause = whereclause & " ORDER BY YEAR_ID DESC "
            dt = objclscommon.search("CONVERT(char(11), year_startdate , 6) + '   ---   ' + CONVERT(char(11), year_enddate , 6) AS YEAR , year_dbname, year_cmpid, year_startdate, year_enddate, year_id", "", "YearMaster INNER JOIN cmpmaster on cmp_id = year_cmpid", whereclause)
            If dt.Rows.Count > 0 Then
                gridcmp.DataSource = dt
                gridcmp.Columns(1).Visible = False
                gridcmp.Columns(2).Visible = False
                gridcmp.Columns(3).Visible = False
                gridcmp.Columns(4).Visible = False
                gridcmp.Columns(5).Visible = False
                gridcmp.Columns(0).HeaderText = "Accounting Year"
                gridcmp.Columns(0).Width = 300
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub YearDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If UserName <> "Admin" Or DISCONTINUECLIENT = True Then
                cmddelete.Enabled = False
                cmdcreate.Enabled = False
            End If
            fillYEAR()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdopen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdopen.Click
        Try
            If gridcmp.RowCount > 0 Then OPENCMP()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridcmp_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridcmp.CellDoubleClick
        Try
            OPENCMP()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub OPENCMP()
        Try

            'CmpName = gridcmp.SelectedCells(0).Value
            'DBName = gridcmp.SelectedCells(1).Value
            'CmpId = gridcmp.SelectedRows(0).Cells(2).Value
            AccFrom = gridcmp.SelectedRows(0).Cells(3).Value
            AccTo = gridcmp.SelectedRows(0).Cells(4).Value
            YearId = gridcmp.SelectedRows(0).Cells(5).Value

            'GETTING RIGHTS IN DATATABLE
            Dim OBJCMN As New ClsCommon
            Dim dt As DataTable = OBJCMN.search("*", "", " USERBLOCKED INNER JOIN USERMASTER ON USERBLOCKED.USER_ID = USERMASTER.USER_ID ", " AND USERMASTER.USER_NAME = '" & UserName & "' AND USERBLOCKED.USER_YEARID = " & YearId)
            If dt.Rows.Count = 1 Then
                MsgBox("User Bloked in this year", MsgBoxStyle.Critical)
                Exit Sub

            End If

            Dim dtID As DataTable = OBJCMN.search("CON_ID,CON_MANUALINVOICING AS MANUAL,CON_SMSTOPARTY AS SMS,CON_PRINTDIRECT AS PRINTDIRECT,CON_CHKPRINTING AS CHQPRINT,CON_AIRLINE AS AIRLINE,CON_CAR AS CAR,CON_RAILWAY AS RAILWAY,CON_HOLIDAY AS HOLIDAY,CON_HOTEL AS HOTEL,CON_MISC AS MISC,CON_EMAIL AS EMAIL ", "", " CONFIGURATION ", " and CON_cmpid = " & CmpId)
            If dtID.Rows.Count > 0 Then
                MANUAL = dtID.Rows(0).Item("MANUAL").ToString
                SMS = dtID.Rows(0).Item("SMS").ToString
                PRINTDIRECT = dtID.Rows(0).Item("PRINTDIRECT").ToString
                CHQPRINT = dtID.Rows(0).Item("CHQPRINT").ToString
                AIRLINE = dtID.Rows(0).Item("AIRLINE").ToString
                CAR = dtID.Rows(0).Item("CAR").ToString
                RAILWAY = dtID.Rows(0).Item("RAILWAY").ToString
                HOLIDAY = dtID.Rows(0).Item("HOLIDAY").ToString
                HOTEL = dtID.Rows(0).Item("HOTEL").ToString
                MISC = dtID.Rows(0).Item("MISC").ToString
                CCEMAIL = dtID.Rows(0).Item("EMAIL").ToString
            End If

            dt = OBJCMN.search("User_id", "", "UserMaster", " and user_name = '" & UserName & "' AND USER_CMPID = " & CmpId)
            Userid = dt.Rows(0).Item(0)
            USERRIGHTS = OBJCMN.search("User_formName as [FormName], User_add as [Add], User_Edit as [Edit], User_View as [View], User_Delete as [Delete]", "", "USERMASTER_RIGHTS INNER JOIN USERMASTER ON USERMASTER.USER_ID = USERMASTER_RIGHTS.USER_ID AND USERMASTER.USER_CMPID = USERMASTER_RIGHTS.USER_CMPID", " and USERMASTER.USER_NAME = '" & UserName & "' and usermaster.user_CMPID = " & CmpId)


            'MDIMain.Show()
            'MDIMain.Refresh()
            Cmppassword.cmdback.Visible = False
            Cmppassword.lblretype.Visible = False
            Cmppassword.txtretypepassword.Visible = False
            Cmppassword.cmdnext.Text = "&Ok"
            Cmppassword.Show()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDBACK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDBACK.Click
        Try
            Cmpdetails.Show()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridcmp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridcmp.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If gridcmp.SelectedRows.Count > 0 Then Call cmdopen_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If UserName <> "Admin" Then Exit Sub
            If MsgBox("Wish to Delete " & gridcmp.SelectedRows(0).Cells(0).Value & " Accounting Year?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            If MsgBox("Are you sure Delete Accounting Year and all its Data?", MsgBoxStyle.YesNo) = vbNo Then Exit Sub
            If InputBox("Enter Master Password") <> "Infosys@123" Then Exit Sub

            Dim ALPARAVAL As New ArrayList
            Dim OBJCMP As New ClsYearMaster

            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(gridcmp.SelectedRows(0).Cells(5).Value)
            OBJCMP.alParaval = ALPARAVAL
            Dim INTRES As Integer = OBJCMP.YEARDELETE
            MsgBox("Accounting Year Deleted Successfully")
            fillYEAR()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub YearDetails_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If DISCONTINUECLIENT = True Then
                cmdcreate.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class