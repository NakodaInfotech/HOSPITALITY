
Imports BL

Public Class LabelPrinting
    Private Sub LabelPrinting_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try

            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" CAST (0 AS BIT) AS CHK,LEDGERS.Acc_cmpname AS NAME, ISNULL(LEDGERS.ACC_ADD,'') AS ADDRESS, GROUPMASTER.group_secondary AS UNDER, ISNULL(LEDGERS.ACC_MOBILE,'') AS MOBILENO, ISNULL(CITY_NAME,'') AS CITY, ISNULL(LEDGERS.ACC_TYPE,'') AS TYPE ", " ", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN CITYMASTER ON CITY_ID = LEDGERS.ACC_CITYID ", " AND (GROUPMASTER.GROUP_SECONDARY = 'Sundry Debtors' OR GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors') AND (LEDGERS.ACC_YEARID = " & YearId & ") ORDER BY LEDGERS.Acc_cmpname")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(sender As Object, e As EventArgs) Handles cmdok.Click
        Try

            Dim OBJLABEL As New registerdesign
            OBJLABEL.MdiParent = MDIMain
            OBJLABEL.frmstring = "LABEL"
            OBJLABEL.strsearch = "{LEDGERS.ACC_YEARID} = " & YearId
            Dim NAMECLAUSE As String = ""


            'Dim OBJCMN As New ClsCommon
            'Dim DT As DataTable = OBJCMN.search("TOP 600 SALELEDGER, SUM(SALEAMT) AS SALEAMT ", "", " RESERVATION_SALEREPORT ", " AND yearid = " & YearId & " GROUP BY SALELEDGER ORDER BY SALEAMT DESC")
            'If DT.Rows.Count > 0 Then
            '    For Each ROW As DataRow In DT.Rows
            '        If NAMECLAUSE = "" Then NAMECLAUSE = " AND ({LEDGERS.ACC_CMPNAME} = '" & ROW("SALELEDGER") & "'" Else NAMECLAUSE = NAMECLAUSE & " OR {LEDGERS.ACC_CMPNAME} = '" & ROW("SALELEDGER") & "'"
            '    Next
            'End If



            'FOR PARTYNAME
            gridbill.ClearColumnsFilter()
            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If NAMECLAUSE = "" Then NAMECLAUSE = " AND ({LEDGERS.ACC_CMPNAME} = '" & dtrow("NAME") & "'" Else NAMECLAUSE = NAMECLAUSE & " OR {LEDGERS.ACC_CMPNAME} = '" & dtrow("NAME") & "'"
                End If
            Next

            If NAMECLAUSE <> "" Then
                NAMECLAUSE = NAMECLAUSE & ")"
                OBJLABEL.strsearch = OBJLABEL.strsearch & NAMECLAUSE
            End If

            OBJLABEL.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKSELECTALL_CheckedChanged(sender As Object, e As EventArgs) Handles CHKSELECTALL.CheckedChanged
        Try
            If gridbilldetails.Visible = True Then
                For i As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                    dtrow("CHK") = CHKSELECTALL.Checked
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub
End Class