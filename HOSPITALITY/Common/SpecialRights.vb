
Imports BL

Public Class SpecialRights

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub UserMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.A Then       'SELECT ALL
                Call chkall_CheckedChanged(sender, e)
            ElseIf (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UserMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            FILLUSER(CMBUSER)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSAVE.Click
        Try
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            alParaval.Add(CMBUSER.Text.Trim)
            alParaval.Add(CHKENQTRANSFER.Checked)
            alParaval.Add(CHKFETCHDATA.Checked)
            alParaval.Add(CHKFOLLOWUP.Checked)
            alParaval.Add(CHKMISCENQUIRY.Checked)
            alParaval.Add(CHKOUTSTANDING.Checked)
            alParaval.Add(CHKCHECKIN.Checked)
            alParaval.Add(CHKMEMBERSHIP.Checked)
            alParaval.Add(YearId)
           
            Dim OBJUSER As New ClsUserMaster()
            OBJUSER.alParaval = alParaval
            Dim INTRES As Integer = OBJUSER.SAVESPECIALRIGHTS()

            clear()
            CMBUSER.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub clear()
        Try
            EP.Clear()
            CMBUSER.Enabled = True
            CHKENQTRANSFER.CheckState = CheckState.Unchecked
            CHKFETCHDATA.CheckState = CheckState.Unchecked
            CHKFOLLOWUP.CheckState = CheckState.Unchecked
            CHKMISCENQUIRY.CheckState = CheckState.Unchecked
            CHKOUTSTANDING.CheckState = CheckState.Unchecked
            CHKCHECKIN.CheckState = CheckState.Unchecked
            CHKMEMBERSHIP.CheckState = CheckState.Unchecked
            CHKALL.CheckState = CheckState.Unchecked
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If CMBUSER.Text.Trim.Length = 0 Then
            EP.SetError(CMBUSER, "Select User Name")
            bln = False
        End If
        Return bln
    End Function

    Private Sub chkall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKALL.CheckedChanged
        Try
            CHKENQTRANSFER.Checked = CHKALL.Checked
            CHKFETCHDATA.Checked = CHKALL.Checked
            CHKFOLLOWUP.Checked = CHKALL.Checked
            CHKMISCENQUIRY.Checked = CHKALL.Checked
            CHKOUTSTANDING.Checked = CHKALL.Checked
            CHKCHECKIN.Checked = CHKALL.Checked
            CHKMEMBERSHIP.Checked = CHKALL.Checked
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBUSER_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBUSER.Validated
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" ISNULL(ENQTRANSFER,0) AS ENQTRANSFER, ISNULL(FETCHDATA,0) AS FETCHDATA, ISNULL(FOLLOWUP,0) AS FOLLOWUP, ISNULL(MISCENQUIRY,0) AS MISCENQUIRY, ISNULL(OUTSTANDING,0) AS OUTSTANDING, ISNULL(CHECKIN,0) AS CHECKIN, ISNULL(MEMBERSHIPNO,0) AS MEMBERSHIPNO ", "", " SPECIALRIGHTS INNER JOIN USERMASTER ON USERID = USER_ID ", " AND USER_NAME = '" & CMBUSER.Text.Trim & "'")
            If DT.Rows.Count > 0 Then
                CHKENQTRANSFER.Checked = Convert.ToBoolean(DT.Rows(0).Item("ENQTRANSFER"))
                CHKFETCHDATA.Checked = Convert.ToBoolean(DT.Rows(0).Item("FETCHDATA"))
                CHKFOLLOWUP.Checked = Convert.ToBoolean(DT.Rows(0).Item("FOLLOWUP"))
                CHKMISCENQUIRY.Checked = Convert.ToBoolean(DT.Rows(0).Item("MISCENQUIRY"))
                CHKOUTSTANDING.Checked = Convert.ToBoolean(DT.Rows(0).Item("OUTSTANDING"))
                CHKCHECKIN.Checked = Convert.ToBoolean(DT.Rows(0).Item("CHECKIN"))
                CHKMEMBERSHIP.Checked = Convert.ToBoolean(DT.Rows(0).Item("MEMBERSHIPNO"))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class