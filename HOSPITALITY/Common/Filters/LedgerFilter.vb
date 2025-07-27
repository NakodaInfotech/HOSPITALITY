
Imports BL
Imports System.Windows.Forms

Public Class LedgerFilter

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub LedgerFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub LedgerFilter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Text = "Ledger Filter"
        chkdate.Checked = False
        dtfrom.Enabled = chkdate.CheckState
        dtto.Enabled = chkdate.CheckState
        fillledger(cmbname, False, "")
        FILLGROUP(CMBGROUP, "")
        fillgrid()

        Dim OBJCMN As New ClsCommon
        Dim dt As DataTable = objcmn.search("CMP_NAME", "", "CMPMASTER", "")
        For Each DTROW As DataRow In dt.Rows
            LSTCMP.Items.Add(DTROW(0).ToString)
            If DTROW(0) = CmpName Then LSTCMP.SetItemChecked(LSTCMP.Items.Count - 1, True)
        Next
    End Sub

    Sub fillgrid(Optional ByVal WHERE As String = "")
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim objclspreq As New ClsCommon()
            Dim DT1 As New DataTable
            DT1 = objclspreq.search(" CAST(0 AS BIT) AS CHK, ISNULL(ACC_CMPNAME,'') AS NAME, ISNULL(GROUP_NAME,'') AS GROUPNAME, GROUP_SECONDARY AS SECONDARY", "", "  LEDGERS INNER JOIN  GROUPMASTER ON ACC_GROUPID = GROUP_ID AND ACC_CMPID = GROUP_CMPID AND ACC_LOCATIONID = GROUP_LOCATIONID AND ACC_YEARID = GROUP_YEARID ", " and ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId & "  order by ACC_CMPNAME")
            gridbilldetails.DataSource = DT1
            If dt1.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub chkdate_CheckedChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkdate.CheckedChanged
        dtfrom.Enabled = chkdate.CheckState
        dtto.Enabled = chkdate.CheckState
    End Sub

    Private Sub cmdShowReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try

            Dim OBJ As New registerdesign
            If chkdate.CheckState = CheckState.Checked Then
                OBJ.FROMDATE = dtfrom.Value.Date
                OBJ.TODATE = dtto.Value.Date
                OBJ.PERIOD = Format(dtfrom.Value.Date, "dd/MM/yyyy") & "-" & Format(dtto.Value.Date, "dd/MM/yyyy")
            Else
                OBJ.FROMDATE = AccFrom
                OBJ.TODATE = AccTo
                OBJ.PERIOD = Format(AccFrom.Date, "dd/MM/yyyy") & "-" & Format(AccTo.Date, "dd/MM/yyyy")
            End If
            OBJ.NEWPAGE = CHKGROUPONNEWPG.Checked

            'GET ALL THE YEARIDS STARTING FROM ACCFROM DATE IN SELECTED COMPANY
            Dim objcmn As New ClsCommon
            Dim YEARSEARCH As String = ""
            Dim CHK As CheckedListBox.CheckedItemCollection = LSTCMP.CheckedItems
            For Each OBJCHK As Object In CHK
                Dim dt As DataTable = objcmn.search("YEAR_ID AS YEARID", "", "cmpmaster inner join yearmaster ON YEAR_CMPID = CMP_ID", " AND CMP_NAME ='" & OBJCHK.ToString & "' AND YEAR_STARTDATE = '" & Format(AccFrom.Date, "MM/dd/yyyy") & "'")
                If YEARSEARCH = "" Then
                    YEARSEARCH = " AND ({LEDGERBOOK.YEARID} = " & dt.Rows(0).Item("YEARID")
                Else
                    YEARSEARCH = YEARSEARCH & " OR {LEDGERBOOK.YEARID} = " & dt.Rows(0).Item("YEARID")
                    OBJ.MULTICOMPANY = 1
                End If
            Next
            YEARSEARCH = YEARSEARCH & ")"

            OBJ.strsearch = " {LEDGERBOOK.TYPE} <> 'OPENING' " & YEARSEARCH
            If cmbname.Text.Trim <> "" Then OBJ.strsearch = OBJ.strsearch & " AND {LEDGERBOOK.LEDGERNAME}='" & cmbname.Text.Trim & "'"
            If CMBGROUP.Text.Trim <> "" Then OBJ.STRSEARCH = OBJ.STRSEARCH & " AND {LEDGERBOOK.GROUPNAME}='" & CMBGROUP.Text.Trim & "'"


            If RBLEDGERBOOK.Checked = True Then
                OBJ.frmstring = "LedgerBook"
            ElseIf RBCONFIRMATION.Checked = True Then
                If CHKSUMM.CheckState = CheckState.Checked Then OBJ.frmstring = "LedgerBookConfirmSumm" Else OBJ.frmstring = "LedgerBookConfirm"
            End If

            OBJ.MdiParent = MDIMain
            OBJ.Show()




            'Dim OBJ As New registerdesign
            'OBJ.frmstring = "LedgerBookAll"
            'OBJ.LEDGERNEWPAGE = CHKLEDGERNEWPAGE.Checked
            'For i As Integer = 0 To gridbill.RowCount - 1
            '    Dim dtrow As DataRow = gridbill.GetDataRow(i)
            '    If Convert.ToBoolean(dtrow("CHK")) = True Then
            '        If OBJ.strsearch = "" Then
            '            OBJ.strsearch = " ({LEDGERBOOK.LEDGERNAME} = '" & dtrow("NAME") & "'"
            '        Else
            '            OBJ.strsearch = OBJ.strsearch & " OR {LEDGERBOOK.LEDGERNAME} = '" & dtrow("NAME") & "'"
            '        End If
            '    End If
            'Next
            'If OBJ.strsearch <> "" Then OBJ.strsearch = OBJ.strsearch & ") "
            'OBJ.MdiParent = MDIMain
            'If chkdate.CheckState = CheckState.Checked Then
            '    OBJ.FROMDATE = dtfrom.Value.Date
            '    OBJ.TODATE = dtto.Value.Date
            'Else
            '    OBJ.FROMDATE = AccFrom
            '    OBJ.TODATE = AccTo
            'End If

            'OBJ.Show()

            'Dim ALPARAVAL As New ArrayList
            'For i As Integer = 0 To gridbill.RowCount - 1
            '    Dim dtrow As DataRow = gridbill.GetDataRow(i)
            '    If Convert.ToBoolean(dtrow("CHK")) = True Then
            '        ALPARAVAL.Add(dtrow("NAME"))
            '    End If
            'Next
            'If ALPARAVAL.Count = 0 Then
            '    MsgBox("Atleast Select One Ledger", MsgBoxStyle.Critical)
            '    Exit Sub
            'End If
            'Dim OBJRPT As New clsReportDesigner("LEDGER BOOK", System.AppDomain.CurrentDomain.BaseDirectory & "LEDGER BOOK.xlsx", 2)
            'If chkdate.CheckState = CheckState.Checked Then
            '    OBJRPT.LEDGERBOOK_EXCEL(ALPARAVAL, dtfrom.Value.Date, dtto.Value.Date, False, dtfrom.Value.Date, dtto.Value.Date, CmpId, Locationid, YearId)
            'Else
            '    OBJRPT.LEDGERBOOK_EXCEL(ALPARAVAL, AccFrom, AccTo, False, AccFrom.Date, AccTo.Date, CmpId, Locationid, YearId)
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Private Sub CHKSELECTALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKSELECTALL.CheckedChanged
    '    Try
    '        For i As Integer = 0 To gridbill.RowCount - 1
    '            Dim dtrow As DataRow = gridbill.GetDataRow(i)
    '            dtrow("CHK") = True
    '        Next
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

  
    Private Sub LedgerFilter_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If ClientName = "KHANNA" Then LSTCMP.Visible = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class