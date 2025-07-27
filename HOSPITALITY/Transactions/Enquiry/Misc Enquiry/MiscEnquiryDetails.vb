
Imports BL
Imports DevExpress.XtraGrid.Views.Grid

Public Class MiscEnquiryDetails
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public MISCUSER As String

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Sub showform(ByVal EDITVAL As Boolean, ByVal MISCENQNO As Integer)
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim OBJFOREXENQNO As New MiscEnquiry
            OBJFOREXENQNO.edit = EDITVAL
            OBJFOREXENQNO.MdiParent = MDIMain
            OBJFOREXENQNO.TEMPENQNO = MISCENQNO
            OBJFOREXENQNO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MiscEnquiryDetails_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub MiscEnquiryDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'MISC ENQUIRY'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If MISCUSER <> Nothing Then
                Me.Text = "Pending Enquiry Details"
                FILLUSERGRID()
            Else
                If ClientName = "VIDHI" Then
                    If UserName <> "Admin" Then
                        FILLBOOKEDBYGRID()
                    Else
                        FILLGRID()
                    End If
                Else
                    FILLGRID()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLBOOKEDBYGRID()
        Try
            Dim OBJCMN As New ClsMiscEnquiry
            OBJCMN.alParaval.Add(UserName)
            OBJCMN.alParaval.Add(YearId)
            Dim DT As DataTable = OBJCMN.SELECTBOOKEDBYMISCENQ()
            gridbilldetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            Dim OBJCMN As New ClsMiscEnquiry
            OBJCMN.alParaval.Add(0)
            OBJCMN.alParaval.Add(YearId)
            Dim DT As DataTable = OBJCMN.SELECTMISCENQ()
            gridbilldetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLUSERGRID()
        Try
            Dim OBJCMN As New ClsMiscEnquiry
            OBJCMN.alParaval.Add(0)
            OBJCMN.alParaval.Add(UserName)
            OBJCMN.alParaval.Add(YearId)
            Dim DT As DataTable = OBJCMN.SELECTUSERMISCENQ()
            gridbilldetails.DataSource = DT
            If DT.Rows.Count > 0 Then
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
            showform(True, gridbill.GetFocusedRowCellValue("MISCNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            If USEREDIT = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            showform(True, gridbill.GetFocusedRowCellValue("MISCNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_RowStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gridbill.RowStyle
        Try
            Dim DT As DataTable = gridbilldetails.DataSource
            If gridbill.RowFilter = "" Then
                If e.RowHandle >= 0 Then
                    Dim ROW As DataRow = DT.Rows(e.RowHandle)
                    Dim View As GridView = sender
                    If View.GetRowCellDisplayText(e.RowHandle, View.Columns("STATUS")) = "Confirmed" Then
                        e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                        e.Appearance.BackColor = Color.LightGreen
                    ElseIf View.GetRowCellDisplayText(e.RowHandle, View.Columns("STATUS")) = "Cancel" Then
                        e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                        e.Appearance.BackColor = Color.LightBlue
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDADD.Click
        Try
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            showform(False, 0)
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
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLEXCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLEXCEL.Click
        Try
            Dim PATH As String = "" = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Misc Enquiry Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            Dim workbook As String = PATH
            If FileIO.FileSystem.FileExists(PATH) = True Then Interaction.GetObject(workbook).close(False)
            GC.Collect()

            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "Misc Enquiry Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Misc Enquiry Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MiscEnquiryDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If ClientName = "MATRIX" Then Me.Close()
            If ClientName <> "TRAVELBRIDGE" Then
                GCATEGORY.Visible = False
                GBOOKER.Visible = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class