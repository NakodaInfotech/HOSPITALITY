
Imports BL

Public Class MembershipMaster

    Private Sub MembershipMaster_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim WHERECLAUSE As String = " AND GROUPMASTER.GROUP_SECONDARY = 'Sundry Debtors'"
            If RBPENDING.Checked = True Then WHERECLAUSE = WHERECLAUSE & " AND ISNULL(LEDGERS.ACC_MEMBERID,'') = ''" Else WHERECLAUSE = WHERECLAUSE & " AND ISNULL(LEDGERS.ACC_MEMBERID,'') <> ''"

            Dim OBJCMN As New ClsCommonMaster
            Dim dt As DataTable = OBJCMN.search(" DISTINCT    Acc_cmpname AS NAME, ISNULL(Acc_mobile, '') AS MOBILENO, ISNULL(ACC_MEMBERID, '') AS MEMBERSHIPNO", "", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.ACC_GROUPID = GROUPMASTER.GROUP_ID ", WHERECLAUSE & " ORDER BY LEDGERS.ACC_CMPNAME ")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            Dim IntResult As Integer = 0
            Dim alParaval As New ArrayList
            Dim NAME As String = ""

            Dim SELECTEDROWS As Int32() = gridbill.GetSelectedRows()
            For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
                Dim ROW As DataRow = gridbill.GetDataRow(SELECTEDROWS(I))
                If NAME = "" Then
                    NAME = ROW("NAME")
                Else
                    NAME = NAME & "|" & ROW("NAME")
                End If
            Next
            alParaval.Add(NAME)

            Dim OBJMEM As New ClsMemberShipMaster
            OBJMEM.alParaval = alParaval

            IntResult = OBJMEM.SAVE()
            MsgBox("Details Added")

            fillgrid()
            gridbill.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Try
            Dim alParaval As New ArrayList
            Dim NAME As String = ""

            Dim SELECTEDROWS As Int32() = gridbill.GetSelectedRows()
            For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
                Dim ROW As DataRow = gridbill.GetDataRow(SELECTEDROWS(I))
                If NAME = "" Then
                    NAME = ROW("NAME")
                Else
                    NAME = NAME & "|" & ROW("NAME")
                End If
            Next
            alParaval.Add(NAME)

            Dim OBJMEM As New ClsMemberShipMaster
            OBJMEM.alParaval = alParaval

            Dim DT As DataTable = OBJMEM.DELETE()
            MsgBox("Details Deleted")

            fillgrid()
            gridbill.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSMS_Click(sender As Object, e As EventArgs) Handles CMDSMS.Click
        Try
            'If RBENTERED.Checked = True Then
            '    Dim SELECTEDROWS As Int32() = gridbill.GetSelectedRows()
            '    If MsgBox("Send SMS?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            '    For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
            '        SMSCODE(SELECTEDROWS(I))
            '    Next
            '    MsgBox("Message Sent")
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SMSCODE(ROWNO As Integer)
        'If ALLOWSMS = True Then
        '    Dim ROW As DataRow = gridbill.GetDataRow(ROWNO)

        '    If ClientName <> "KOTHARI" And ROW("MOBILENO") = "" Then Exit Sub
        '    If ClientName = "KOTHARI" And ROW("SHIPTO") = "" Then Exit Sub

        '    If ClientName = "NVAHAN" And ROW("LRNO") = "" Then
        '        If MsgBox("LR No not entered, Wish to send SMS?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        '    End If

        '    Dim MSG As String = ""
        '    Dim OBJCMN As New ClsCommon
        '    Dim DT As New DataTable
        '    Dim DTINV As DataTable = OBJCMN.search("ITEM_NAME AS ITEMNAME, INVOICE_BALENO AS GRIDBALENO, INVOICE_PCS AS PCS, INVOICE_MTRS AS MTRS", "", "INVOICEMASTER_DESC INNER JOIN ITEMMASTER ON INVOICE_ITEMID = ITEM_ID", " AND INVOICE_NO = " & Val(ROW("INVOICENO")) & " AND INVOICE_REGISTERID = " & Val(ROW("REGID")) & " AND INVOICE_YEARID = " & YearId)

        '    If ClientName = "KOTHARI" Then
        '        MSG = MSG & ROW("SHIPTO") & " - " & ROW("CITY") & "\n"
        '        MSG = MSG & "GOODS DISPATCHED" & "\n"
        '        MSG = MSG & "BALE NO." & Val(ROW("INVOICENO")) & " X " & ROW("BALENOFROM") & "\n"
        '        MSG = MSG & "L.R.NO" & ROW("LRNO") & " DT. " & ROW("LRDATE") & "\n"
        '        MSG = MSG & ROW("EWAYBILLNO")

        '    ElseIf ClientName = "KCRAYON" Then
        '        MSG = "INV NO " & Val(ROW("INVOICENO")) & "\n"
        '        DT = OBJCMN.search("ACC_CODE AS TRANSCODE", "", "LEDGERS", " AND ACC_CMPNAME = '" & ROW("TRANSNAME") & "' AND ACC_YEARID = " & YearId)
        '        If DT.Rows.Count > 0 Then MSG = MSG & "TRANSPORT NAME-" & DT.Rows(0).Item("TRANSCODE") & " & LRNO-" & ROW("LRNO") & "\n"
        '        For Each INVROW As DataRow In DT.Rows
        '            MSG = MSG & INVROW("ITEMNAME") & "-" & Format(Val(INVROW("MTRS")), "0.00") & "\n"
        '        Next
        '        MSG = MSG & "THANK YOU"

        '    ElseIf ClientName = "NVAHAN" Then
        '        MSG = "GOODS DESP" & vbCrLf
        '        MSG = MSG & "INV-" & Val(ROW("INVOICENO")) & vbCrLf
        '        MSG = MSG & "LRNO-" & ROW("LRNO") & vbCrLf
        '        MSG = MSG & "DT-" & ROW("LRDATE") & vbCrLf
        '        DT = OBJCMN.search("ACC_CODE AS TRANSCODE", "", "LEDGERS", " AND ACC_CMPNAME = '" & ROW("TRANSNAME") & "' AND ACC_YEARID = " & YearId)
        '        If DT.Rows.Count > 0 Then MSG = MSG & "TRANS-" & DT.Rows(0).Item("TRANSCODE") & vbCrLf
        '        For Each INVROW As DataRow In DT.Rows
        '            MSG = MSG & "ITEM-" & INVROW("ITEMNAME") & vbCrLf & "PCS-" & Val(INVROW("PCS")) & vbCrLf & "MTRS-" & Val(INVROW("MTRS")) & vbCrLf & "BALE-" & INVROW("GRIDBALENO")
        '        Next

        '    ElseIf ClientName = "YASHVI" Then
        '        MSG = ROW("NAME") & "\n"
        '        MSG = MSG & "BALENO-" & ROW("CHALLANNO") & "\n"
        '        DT = OBJCMN.search("ACC_CODE AS TRANSCODE", "", "LEDGERS", " AND ACC_CMPNAME = '" & ROW("TRANSNAME") & "' AND ACC_YEARID = " & YearId)
        '        If DT.Rows.Count > 0 Then MSG = MSG & DT.Rows(0).Item("TRANSCODE") & "\n"
        '        MSG = MSG & "LRNO-" & ROW("LRNO") & "\n"
        '        MSG = MSG & "DT-" & ROW("LRDATE") & "\n"
        '        MSG = MSG & "QTY-" & Val(ROW("MTRS")) & "\n"
        '        MSG = MSG & CmpName

        '    ElseIf ClientName = "SANGHVI" Then
        '        MSG = "INV NO" & Val(ROW("INVOICENO")) & "\n"
        '        MSG = MSG & "DT-" & ROW("DATE") & "\n"
        '        DT = OBJCMN.search("ACC_CODE AS TRANSCODE", "", "LEDGERS", " AND ACC_CMPNAME = '" & ROW("TRANSNAME") & "' AND ACC_YEARID = " & YearId)
        '        If DT.Rows.Count > 0 Then MSG = MSG & "TRANSPORT NAME-" & DT.Rows(0).Item("TRANSCODE") & " & LRNO-" & ROW("LRNO") & "\n"
        '        MSG = MSG & "LRDT-" & ROW("LRDATE") & "\n"
        '        MSG = MSG & " & BUNDLES-" & ROW("BALENOFROM") & "\n"
        '        'For Each ROW As DataGridViewRow In GRIDINVOICE.Rows
        '        '    MSG = MSG & ROW.Cells(GITEMNAME.Index).Value & "-" & Format(Val(ROW.Cells(Gmtrs.Index).Value), "0.00") & "\n"
        '        'Next
        '        MSG = MSG & "THANK YOU"
        '    Else
        '        MSG = "SALE NO " & Val(ROW("INVOICENO")) & "\n"
        '        DT = OBJCMN.search("ACC_CODE AS TRANSCODE", "", "LEDGERS", " AND ACC_CMPNAME = '" & ROW("TRANSNAME") & "' AND ACC_YEARID = " & YearId)
        '        If DT.Rows.Count > 0 Then MSG = MSG & "TRANSPORT -" & DT.Rows(0).Item("TRANSCODE") & " & LRNO-" & ROW("LRNO") & "(" & ROW("LRDATE").Trim & ")" & "\n"
        '        For Each INVROW As DataRow In DT.Rows
        '            MSG = MSG & INVROW("ITEMNAME") & "-" & Format(Val(INVROW("MTRS")), "0.00") & "\n"
        '        Next
        '        MSG = MSG & ROW("BALENOFROM") & "\n"
        '        MSG = MSG & "THANK YOU"
        '    End If

        '    If SENDMSG(MSG, ROW("MOBILENO")) = "1701" Then
        '        DT = OBJCMN.Execute_Any_String("UPDATE INVOICEMASTER SET INVOICE_SMSSEND = 1 WHERE INVOICE_NO = " & Val(ROW("INVOICENO")) & " AND INVOICE_REGISTERID = " & Val(ROW("REGID")) & " AND INVOICE_YEARID = " & YearId, "", "")
        '    Else
        '        MsgBox("Error Sending Message")
        '        Exit Sub
        '    End If
        'End If
    End Sub
End Class