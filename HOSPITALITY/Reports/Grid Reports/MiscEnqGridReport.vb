
Imports BL
Imports DevExpress.XtraGrid.Views.Grid

Public Class MiscEnqGridReport

    Public DT As New DataTable

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Sub showform(ByVal EDITVAL As Boolean, ByVal MISCENQNO As Integer)
        Try
            Dim OBJFOREXENQNO As New MiscEnquiry
            OBJFOREXENQNO.edit = EDITVAL
            OBJFOREXENQNO.MdiParent = MDIMain
            OBJFOREXENQNO.TEMPENQNO = MISCENQNO
            OBJFOREXENQNO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MiscEnqGridReport_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            gridbilldetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
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

    Private Sub TOOLREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLREFRESH.Click
        Try
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

    Private Sub MiscEnqGridReport_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If ClientName <> "TRAVELBRIDGE" Then
                GCATEGORY.Visible = False
                GBOOKER.Visible = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class