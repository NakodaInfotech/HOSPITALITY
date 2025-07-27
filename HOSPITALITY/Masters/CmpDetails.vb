Imports BL

Public Class Cmpdetails

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        End
    End Sub

    Private Sub cmdcreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcreate.Click
        Try
            Dim obj As New Cmpmaster
            obj.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Cmpdetails_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            'fillcmp()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Cmpdetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.N) Then
                Dim objcmpmaster As New Cmpmaster
                objcmpmaster.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Cmpdetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If UserName <> "Admin" Or DISCONTINUECLIENT = True Then
                cmdedit.Enabled = False
                cmddelete.Enabled = False
                cmdcreate.Enabled = False
                cmdbackup.Enabled = False
            End If
            fillcmp()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Sub fillcmp()
        Try
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            Dim whereclause As String = ""
            dt = objclscommon.search(" distinct user_cmpid", "", "UserMaster", " and User_Name = '" & UserName & "'")
            For Each DTROW As DataRow In dt.Rows
                If whereclause = "" Then
                    whereclause = " AND CMP_ID IN (" & DTROW(0)
                Else
                    whereclause = whereclause & "," & DTROW(0)
                End If
            Next
            whereclause = whereclause & ")"
            'dt = objclscommon.search("CMP_NAME, year_dbname, year_cmpid, year_startdate, year_enddate, year_id", "", "YearMaster INNER JOIN cmpmaster on cmp_id = year_cmpid", whereclause)
            dt = objclscommon.search("CMP_NAME, cmp_id", "", "cmpmaster", whereclause)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "cmp_name"
                gridcmp.DataSource = dt
                gridcmp.Columns(1).Visible = False
                'gridcmp.Columns(2).Visible = False
                'gridcmp.Columns(3).Visible = False
                'gridcmp.Columns(4).Visible = False
                'gridcmp.Columns(5).Visible = False
                gridcmp.Columns(0).HeaderText = "Company Name"
                gridcmp.Columns(0).Width = 270
            End If
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

            CmpName = gridcmp.SelectedCells(0).Value
            'DBName = gridcmp.SelectedCells(1).Value
            CmpId = gridcmp.SelectedRows(0).Cells(1).Value
            'AccFrom = gridcmp.SelectedRows(0).Cells(3).Value
            'AccTo = gridcmp.SelectedRows(0).Cells(4).Value
            'YearId = gridcmp.SelectedRows(0).Cells(5).Value

            'GETTING APPLY GST 
            Dim OBJCMN As New ClsCommon
            Dim dt As DataTable = OBJCMN.search("ISNULL(CMP_ALLOWGST,1) AS APPLYGST, ISNULL(CMP_APPLYCESS,0) AS APPLYCESS", "", "CMPMASTER", " and CMP_ID = " & CmpId)
            If dt.Rows.Count > 0 Then
                APPLYGST = dt.Rows(0).Item("APPLYGST")
                APPLYCESS = dt.Rows(0).Item("APPLYCESS")
            End If


            'Cmppassword.cmdback.Visible = False
            'Cmppassword.lblretype.Visible = False
            'Cmppassword.txtretypepassword.Visible = False
            'Cmppassword.cmdnext.Text = "&Ok"
            'Cmppassword.Show()

            YearDetails.Show()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Try
            Cmpmaster.edit = True
            Cmpmaster.TEMPCMPNAME = gridcmp.CurrentRow.Cells(0).Value
            Cmpmaster.ShowDialog()
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

    Private Sub cmdbackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdbackup.Click
        Try
            'TAKE(backup)
            Dim TEMPMSG As Integer = MsgBox("Create Backup?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then

                'CHECKING FOR BACKUP FOLDER
                If FileIO.FileSystem.DirectoryExists("C:\TRAVELMATE BACKUP") = False Then FileIO.FileSystem.CreateDirectory("C:\TRAVELMATE BACKUP")

                'IF SAME DATE'S BACKUP EXIST THEN DELETE IT THEN RECREATE IT
                If FileIO.FileSystem.FileExists("C:\TRAVELMATE BACKUP\BACKUP " & Now.Day & "-" & Now.Month & "-" & Now.Year & ".bak") Then FileIO.FileSystem.DeleteFile("C:\TRAVELMATE BACKUP\BACKUP " & Now.Day & "-" & Now.Month & "-" & Now.Year & ".bak")

                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.Execute_Any_String(" backup database HOSPITALITY to disk='C:\TRAVELMATE BACKUP\BACKUP " & Now.Day & "-" & Now.Month & "-" & Now.Year & ".bak'", "", "")
                MsgBox("Backup Completed")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If UserName <> "Admin" Then Exit Sub
            If MsgBox("Wish to Delete " & gridcmp.SelectedRows(0).Cells(0).Value & " Company?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            If MsgBox("Are you Sure Delete Company and its Data?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            If InputBox("Enter Master Password") <> "Infosys@123" Then Exit Sub


            Dim ALPARAVAL As New ArrayList
            Dim OBJCMP As New ClsYearMaster

            ALPARAVAL.Add(gridcmp.SelectedRows(0).Cells(1).Value)
            OBJCMP.alParaval = ALPARAVAL
            Dim INTRES As Integer = OBJCMP.CMPDELETE
            MsgBox("Company Deleted Successfully")
            fillcmp()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Cmpdetails_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If DISCONTINUECLIENT = True Then
                cmdcreate.Enabled = False
                cmdedit.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class