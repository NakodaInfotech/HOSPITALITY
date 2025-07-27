
Imports BL

Public Class GroupDepartureFilter

    Private Sub CMBTOUR_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTOUR.Enter
        Try
            If CMBTOUR.Text.Trim = "" Then FILLGROUPNAME(CMBTOUR, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTOUR_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTOUR.Validating
        Try
            If CMBTOUR.Text.Trim <> "" Then GROUPNAMEVALIDATE(CMBTOUR, e, Me, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBCODE, e, Me, TXTADD, " AND GROUP_SECONDARY = 'SUNDRY DEBTORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GroupDepartureFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GroupDepartureFilter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillname(CMBNAME, False, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'")
            FILLGROUPNAME(CMBTOUR, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try

            If RBPROFITLOSS.Checked = True Then
                Dim OBJGROUPDEPPL As New GroupDepartureProfitLoss
                OBJGROUPDEPPL.MdiParent = MDIMain
                OBJGROUPDEPPL.Show()
                Exit Sub
            End If


            If CMBTOUR.Text.Trim = "" Then
                MsgBox("Please select Tour Name", MsgBoxStyle.Critical)
                Exit Sub
            End If


            Dim OBJGD As New GroupDepartureDesign


            If RBPASSLIST.Checked = True Then
                Dim WHERECLAUSE As String = ""
                WHERECLAUSE = " AND GROUPDEPARTURE.GROUPDEP_NAME = '" & CMBTOUR.Text.Trim & "'"
                If CMBNAME.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND LEDGERS.ACC_CMPNAME = '" & CMBNAME.Text.Trim & "'"


                'ADD DATA IN TEMP TABLE AND THEN PRINT THE REPORT
                'FIRST GET ALL LEDGERS UNDER SELECTED GROUP
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" GROUPDEPARTURE.GROUPDEP_NAME AS TOURNAME, GROUPDEPARTURE.GROUPDEP_FROM AS FROMDATE, GROUPDEPARTURE.GROUPDEP_TO AS TODATE, LEDGERS.Acc_cmpname AS NAME, LEDGERS.Acc_add AS ADDRESS,ISNULL(LEDGERS.ACC_MOBILE,'') AS MOBILENO, RAILBOOKINGMASTER_DESC.BOOKING_PASSNAME AS PASSNAME, RAILBOOKINGMASTER_DESC.BOOKING_AGE AS AGE, RAILBOOKINGMASTER_DESC.BOOKING_SEX AS SEX, ISNULL(RAILBOOKINGMASTER_DESC.BOOKING_SEATNO,'') AS RAILDN, ISNULL(RAILBOOKINGMASTER_DESC.BOOKING_MIDDN,'') AS MIDDN, ISNULL(RAILBOOKINGMASTER_DESC.BOOKING_UP,'') AS RAILUP, ISNULL(RAILBOOKINGMASTER_DESC.BOOKING_MIDUP,'') AS MIDUP, RAILBOOKINGMASTER.BOOKING_CMPID AS CMPID, RAILBOOKINGMASTER.BOOKING_YEARID AS YEARID ", "", " RAILBOOKINGMASTER INNER JOIN LEDGERS ON RAILBOOKINGMASTER.BOOKING_LEDGERID = LEDGERS.Acc_id INNER JOIN RAILBOOKINGMASTER_DESC ON RAILBOOKINGMASTER.BOOKING_NO = RAILBOOKINGMASTER_DESC.BOOKING_NO AND RAILBOOKINGMASTER.BOOKING_YEARID = RAILBOOKINGMASTER_DESC.BOOKING_YEARID INNER JOIN GROUPDEPARTURE ON RAILBOOKINGMASTER.BOOKING_TOURID = GROUPDEPARTURE.GROUPDEP_NO AND RAILBOOKINGMASTER.BOOKING_YEARID = GROUPDEPARTURE.GROUPDEP_YEARID ", WHERECLAUSE & " AND RAILBOOKINGMASTER.BOOKING_SALERETURN = 0 AND RAILBOOKINGMASTER.BOOKING_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    Dim NEWDT As DataTable = OBJCMN.Execute_Any_String("DELETE FROM TEMPPASSLIST WHERE YEARID = " & YearId, "", "")
                    Dim I As Integer = 1
                    For Each DTROW As DataRow In DT.Rows

                        NEWDT = OBJCMN.Execute_Any_String("INSERT INTO TEMPPASSLIST VALUES ('" & DTROW("TOURNAME") & "','" & Format(DTROW("FROMDATE"), "MM/dd/yyyy") & "', '" & Format(DTROW("TODATE"), "MM/dd/yyyy") & "', '" & DTROW("NAME") & "', '" & DTROW("ADDRESS") & "'," & I & ",'" & DTROW("PASSNAME") & "'," & Val(DTROW("AGE")) & ",'" & DTROW("SEX") & "','" & DTROW("RAILDN") & "','" & DTROW("MIDDN") & "','" & DTROW("RAILUP") & "','" & DTROW("MIDUP") & "',''," & CmpId & "," & YearId & ",'" & DTROW("MOBILENO") & "')", "", "")
                        I += 1
                    Next

                End If
                OBJGD.FRMSTRING = "PASSLIST"
                OBJGD.STRSEARCH = "{TEMPPASSLIST.YEARID} = " & YearId
            Else

                OBJGD.FRMSTRING = "HOTELLIST"
                OBJGD.STRSEARCH = "{GROUPDEPARTURE.GROUPDEP_YEARID} = " & YearId & " AND {GROUPDEPARTURE.GROUPDEP_NAME} ='" & CMBTOUR.Text.Trim & "'"
            End If

            OBJGD.MdiParent = MDIMain
            OBJGD.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

  
End Class