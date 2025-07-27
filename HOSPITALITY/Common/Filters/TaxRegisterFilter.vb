
Imports BL
Imports System.Windows.Forms

Public Class TaxRegisterFilter
    Public FRMSTRING As String = ""

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdshowreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowreport.Click
        Try
            Dim CONDITION As String = ""
            If chkdetails.CheckState = Windows.Forms.CheckState.Checked Then
                Dim tempmsg As Integer = MsgBox("Details Report will take some time to Open, Wish to Proceed?", vbYesNo)
                If tempmsg = vbYes Then
                    Cursor.Current = Cursors.WaitCursor
                    If FRMSTRING = "PURCHASE" Then
                        CONDITION = " AND T.CMPID = " & CmpId & " AND T.LOCATIONID = " & Locationid & " AND T.YEARID = " & YearId

                        If chkinv.CheckState = Windows.Forms.CheckState.Checked Then CONDITION = CONDITION & " AND T.BILL >= " & Val(txtfrominvno.Text.Trim) & " AND T.BILL <= " & Val(txttowono.Text.Trim)
                        If chkdate.CheckState = Windows.Forms.CheckState.Checked Then CONDITION = CONDITION & " AND T.DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND T.DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"

                        Dim objrep As New clsReportDesigner("PURCHASE TAX DETAILS", System.AppDomain.CurrentDomain.BaseDirectory & "PURCHASE TAX DETAILS.xlsx", 2)
                        objrep.PURCHASE_TAX_DETAILS_EXCEL(CONDITION, CmpId, Locationid, YearId)
                    Else
                        CONDITION = " AND T.CMPID = " & CmpId & " AND T.LOCATIONID = " & Locationid & " AND T.YEARID = " & YearId

                        If chkinv.CheckState = Windows.Forms.CheckState.Checked Then CONDITION = CONDITION & " AND T.BILL >= " & Val(txtfrominvno.Text.Trim) & " AND T.BILL <= " & Val(txttowono.Text.Trim)
                        If chkdate.CheckState = Windows.Forms.CheckState.Checked Then CONDITION = CONDITION & " AND T.DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND T.DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"

                        Dim objrep As New clsReportDesigner("SALES TAX DETAILS", System.AppDomain.CurrentDomain.BaseDirectory & "SALES TAX DETAILS.xlsx", 2)
                        objrep.SALES_TAX_DETAILS_EXCEL(CONDITION, CmpId, Locationid, YearId)
                    End If
                End If

            Else

                If FRMSTRING = "PURCHASE" Then
                    CONDITION = " AND PURCHASEMASTER.BILL_CMPID = " & CmpId & " AND PURCHASEMASTER.BILL_LOCATIONID = " & Locationid & " AND PURCHASEMASTER.BILL_YEARID = " & YearId

                    If chkinv.CheckState = Windows.Forms.CheckState.Checked Then CONDITION = CONDITION & " AND PURCHASEMASTER.BILL_NO >= " & Val(txtfrominvno.Text.Trim) & " AND PURCHASEMASTER.BILL_NO <= " & Val(txttowono.Text.Trim)
                    If chkdate.CheckState = Windows.Forms.CheckState.Checked Then CONDITION = CONDITION & " AND PURCHASEMASTER.BILL_DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND PURCHASEMASTER.BILL_DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"

                    Dim objrep As New clsReportDesigner("PURCHASE TAX SUMMARY", System.AppDomain.CurrentDomain.BaseDirectory & "PURCHASE TAX SUMMARY.xlsx", 2)
                    objrep.PURCHASE_TAX_SUMMARY_EXCEL(CONDITION, CmpId, Locationid, YearId)
                Else
                    CONDITION = " AND HOTELBOOKINGMASTER.BOOKING_BOOKTYPE = 'BOOKING' AND HOTELBOOKINGMASTER.BOOKING_CMPID = " & CmpId & " AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = " & Locationid & " AND HOTELBOOKINGMASTER.BOOKING_YEARID = " & YearId

                    If chkinv.CheckState = Windows.Forms.CheckState.Checked Then CONDITION = CONDITION & " AND HOTELBOOKINGMASTER.BOOKING_NO >= " & Val(txtfrominvno.Text.Trim) & " AND HOTELBOOKINGMASTER.BOOKING_NO <= " & Val(txttowono.Text.Trim)
                    If chkdate.CheckState = Windows.Forms.CheckState.Checked Then CONDITION = CONDITION & " AND HOTELBOOKINGMASTER.BOOKING_DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND HOTELBOOKINGMASTER.BOOKING_DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"

                    Dim objrep As New clsReportDesigner("SALES TAX SUMMARY", System.AppDomain.CurrentDomain.BaseDirectory & "SALES TAX SUMMARY.xlsx", 2)
                    objrep.SALES_TAX_SUMMARY_EXCEL(CONDITION, CmpId, Locationid, YearId)
                End If

            End If

        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub DateFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Or (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Then
            Me.Close()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Showing Report
            Call cmdshowreport_Click(sender, e)
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub chkdate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkdate.CheckedChanged
        dtfrom.Enabled = chkdate.CheckState
        dtto.Enabled = chkdate.CheckState
    End Sub

    Private Sub chkinv_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkinv.CheckedChanged
        gpwo.Enabled = chkinv.CheckState
        txttowono.Enabled = chkinv.CheckState
        txtfrominvno.Enabled = chkinv.CheckState
    End Sub

End Class