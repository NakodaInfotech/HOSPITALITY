Imports BL

Public Class Moduleconfig
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean
    Dim CON_ID As Integer
    Dim TEMPNO As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            'close all child forms
            Dim frm As Form
            For Each frm In MdiChildren
                frm.Close()
            Next

            Me.Dispose()
            Login.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Moduleconfig_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim clscommon As New ClsCommon
            Dim dtID As DataTable
            dtID = clscommon.search("CON_ID,CON_MANUALINVOICING AS MANUAL,CON_SMSTOPARTY AS SMS,CON_PRINTDIRECT AS PRINTDIRECT,CON_CHKPRINTING AS CHQPRINT,CON_AIRLINE AS AIRLINE,CON_CAR AS CAR,CON_RAILWAY AS RAILWAY,CON_HOLIDAY AS HOLIDAY,CON_HOTEL AS HOTEL,CON_MISC AS MISC,CON_EMAIL AS EMAIL ", "", " CONFIGURATION ", " and CON_cmpid = " & CmpId & " and CON_locationid = " & Locationid & " and CON_yearid = " & YearId)
            If dtID.Rows.Count > 0 Then

                TEMPNO = dtID.Rows(0).Item(0)

                If dtID.Rows(0).Item("MANUAL").ToString = False Then
                    CMBMANUAL.Text = "No"
                Else
                    CMBMANUAL.Text = "Yes"
                End If

                If dtID.Rows(0).Item("SMS").ToString = False Then
                    CMBSMS.Text = "No"
                Else
                    CMBSMS.Text = "Yes"
                End If

                If dtID.Rows(0).Item("PRINTDIRECT").ToString = False Then
                    CMBPRINTDIRECT.Text = "No"
                Else
                    CMBPRINTDIRECT.Text = "Yes"
                End If

                If dtID.Rows(0).Item("CHQPRINT").ToString = False Then
                    CMBCHKPRINT.Text = "No"
                Else
                    CMBCHKPRINT.Text = "Yes"
                End If

                If dtID.Rows(0).Item("AIRLINE").ToString = False Then
                    CMBAIRLINE.Text = "No"
                Else
                    CMBAIRLINE.Text = "Yes"
                End If

                If dtID.Rows(0).Item("CAR").ToString = False Then
                    CMBCAR.Text = "No"
                Else
                    CMBCAR.Text = "Yes"
                End If

                If dtID.Rows(0).Item("RAILWAY").ToString = False Then
                    CMBRAIL.Text = "No"
                Else
                    CMBRAIL.Text = "Yes"
                End If

                If dtID.Rows(0).Item("HOLIDAY").ToString = False Then
                    CMBHOLIDAY.Text = "No"
                Else
                    CMBHOLIDAY.Text = "Yes"
                End If

                If dtID.Rows(0).Item("HOTEL").ToString = False Then
                    CMBHOTEL.Text = "No"
                Else
                    CMBHOTEL.Text = "Yes"
                End If

                If dtID.Rows(0).Item("MISC").ToString = False Then
                    CMBMISC.Text = "No"
                Else
                    CMBMISC.Text = "Yes"
                End If

                TXTEMAIL.Text = dtID.Rows(0).Item("EMAIL").ToString

            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.WaitCursor
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Dim IntResult As Integer
        Dim alParaval As New ArrayList

        If CMBMANUAL.Text.Trim = "No" Then
            alParaval.Add(0)
        Else
            alParaval.Add(1)
        End If

        If CMBSMS.Text.Trim = "No" Then
            alParaval.Add(0)
        Else
            alParaval.Add(1)
        End If

        If CMBPRINTDIRECT.Text.Trim = "No" Then
            alParaval.Add(0)
        Else
            alParaval.Add(1)
        End If

        If CMBCHKPRINT.Text.Trim = "No" Then
            alParaval.Add(0)
        Else
            alParaval.Add(1)
        End If

        If CMBAIRLINE.Text.Trim = "No" Then
            alParaval.Add(0)
        Else
            alParaval.Add(1)
        End If

        If CMBCAR.Text.Trim = "No" Then
            alParaval.Add(0)
        Else
            alParaval.Add(1)
        End If

        If CMBRAIL.Text.Trim = "No" Then
            alParaval.Add(0)
        Else
            alParaval.Add(1)
        End If

        If CMBHOLIDAY.Text.Trim = "No" Then
            alParaval.Add(0)
        Else
            alParaval.Add(1)
        End If

        If CMBHOTEL.Text.Trim = "No" Then
            alParaval.Add(0)
        Else
            alParaval.Add(1)
        End If

        If CMBMISC.Text.Trim = "No" Then
            alParaval.Add(0)
        Else
            alParaval.Add(1)
        End If

        alParaval.Add(TXTEMAIL.Text.Trim)

        alParaval.Add(CmpId)
        alParaval.Add(Locationid)
        alParaval.Add(Userid)
        alParaval.Add(YearId)
        alParaval.Add(0)
        alParaval.Add(TEMPNO)

        Dim OBJcon As New ClsRailway
        OBJcon.alParaval = alParaval

        IntResult = OBJcon.Update()
        MsgBox("Details Added")

        Dim TEMPMSG As Integer = MsgBox("Please Restart Software If Changes Applicable?", MsgBoxStyle.YesNo)
        If TEMPMSG = vbYes Then
            Dim frm As Form
            For Each frm In MdiChildren
                frm.Close()
            Next
            Me.Dispose()
            Login.Show()
        Else
            Me.Close()
        End If
    End Sub
End Class