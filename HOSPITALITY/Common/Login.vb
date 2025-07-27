Imports BL

Public Class Login

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        End
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        End
    End Sub


    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            checkversion()
            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim objlogin As New clsLogin
            UserName = txtusername.Text.Trim
            Mydate = objlogin.getdate()
            Cmpdetails.Show()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If txtusername.Text.Trim.Length = 0 Then
            EP.SetError(txtusername, "Fill User Name")
            bln = False
        End If

        If txtpassword.Text.Trim.Length = 0 Then
            EP.SetError(txtpassword, "Fill Password")
            bln = False
        End If

        Dim objcmn As New ClsCommon
        Dim dt As DataTable = objcmn.search("User_id, User_password, ISNULL(USER_TEL,'') AS USERTELNO, ISNULL(USER_EMAIL,'') AS USEREMAIL", "", "UserMaster", " and user_namE= '" & txtusername.Text.Trim & "'")
        If dt.Rows.Count > 0 Then
            For Each DTROW As DataRow In dt.Rows
                If txtpassword.Text.Trim <> DTROW(1).ToString Then
                    bln = False
                Else
                    Userid = DTROW(0)
                    UserTelNo = DTROW("USERTELNO")
                    USEREMAIL = DTROW("USEREMAIL")
                    bln = True
                    Exit For
                End If
            Next
        Else
            Ep.SetError(txtusername, "Invalid User")
            bln = False
        End If

        If txtusername.Text.Trim <> "Admin" Then
            dt = objcmn.search(" ISNULL(ENQTRANSFER,0) AS ENQTRANSFER, ISNULL(FETCHDATA,0) AS FETCHDATA, ISNULL(FOLLOWUP,0) AS FOLLOWUP, ISNULL(MISCENQUIRY,0) AS MISCENQUIRY, ISNULL(OUTSTANDING,0) AS OUTSTANDING, ISNULL(CHECKIN,0) AS CHECKIN, ISNULL(MEMBERSHIPNO,0) AS MEMBERSHIPNO ", "", " SPECIALRIGHTS INNER JOIN USERMASTER ON USER_ID = USERID ", " AND USER_NAME = '" & txtusername.Text.Trim & "'")
            If dt.Rows.Count > 0 Then
                ENQTRANSFER = Convert.ToBoolean(dt.Rows(0).Item("ENQTRANSFER"))
                FETCHDATA = Convert.ToBoolean(dt.Rows(0).Item("FETCHDATA"))
                FOLLOWUP = Convert.ToBoolean(dt.Rows(0).Item("FOLLOWUP"))
                MISCENQUIRYREPORT = Convert.ToBoolean(dt.Rows(0).Item("MISCENQUIRY"))
                OUTSTANDING = Convert.ToBoolean(dt.Rows(0).Item("OUTSTANDING"))
                CHECKIN = Convert.ToBoolean(dt.Rows(0).Item("CHECKIN"))
                SHOWMEMBERSHIPFORM = Convert.ToBoolean(dt.Rows(0).Item("MEMBERSHIPNO"))
            End If
        Else
            ENQTRANSFER = True
            FETCHDATA = True
            SHOWMEMBERSHIPFORM = True
        End If

        If bln = False Then Ep.SetError(txtpassword, "Incorrect Password")

        Return bln
    End Function

    Private Sub txtusername_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtusername.Validated
        pcase(txtusername)
    End Sub

    Private Sub Login_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.L Then       'for Login
            Call cmdok_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            End
        ElseIf e.KeyCode = Windows.Forms.Keys.Enter Then
            'SendKeys.Send("{Tab}")
        End If
    End Sub

    Sub checkversion()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" VERSION_NO AS VERSION, VERSION_CLIENTNAME AS CLIENTNAME, VERSION_REPORTTYPE AS REPORTTYPE, VERSION_PRESENT AS PRESENT, VERSION_ALLOWEINV AS ALLOWEINVOICE  ", "", " VERSION", "")
            If DT.Rows.Count > 0 Then
                REPORTTYPE = DT.Rows(0).Item("REPORTTYPE")
                ClientName = DT.Rows(0).Item("CLIENTNAME")
                ALLOWEINVOICE = DT.Rows(0).Item("ALLOWEINVOICE")


                DISCONTINUECLIENT = False


                If ClientName = "AERO" Then
                    DISCONTINUECLIENT = True
                    'If Now.Date > DateTime.Parse("15.04.2024 00:00") Then
                    '    Dim DTNEW As DataTable = OBJCMN.Execute_Any_String("UPDATE VERSION SET VERSION_NO='1.0.0000'", "", "")
                    '    GoTo LINE1
                    'End If
                    'ElseIf ClientName = "AIRTRINITY" Then
                    '    If Now.Date > DateTime.Parse("15.09.2020 00:00") Then
                    '        Dim DTNEW As DataTable = OBJCMN.Execute_Any_String("UPDATE VERSION SET VERSION_NO='1.0.0000'", "", "")
                    '        GoTo LINE1
                    '    End If
                ElseIf ClientName = "APSARA" Then
                    If Now.Date > DateTime.Parse("15.01.2026 00:00") Then
                        Dim DTNEW As DataTable = OBJCMN.Execute_Any_String("UPDATE VERSION SET VERSION_NO='1.0.0000'", "", "")
                        GoTo LINE1
                    End If
                    'ElseIf ClientName = "ARHAM" Then
                    '    If Now.Date > DateTime.Parse("15.10.2020 00:00") Then
                    '        Dim DTNEW As DataTable = OBJCMN.Execute_Any_String("UPDATE VERSION SET VERSION_NO='1.0.0000'", "", "")
                    '        GoTo LINE1
                    '    End If
                ElseIf ClientName = "BARODA" Then
                    If Now.Date > DateTime.Parse("15.04.2024 00:00") Then
                        Dim DTNEW As DataTable = OBJCMN.Execute_Any_String("UPDATE VERSION SET VERSION_NO='1.0.0000'", "", "")
                        GoTo LINE1
                    End If
                    'ElseIf ClientName = "BALAJI" Then
                    '    If Now.Date > DateTime.Parse("15.01.2020 00:00") Then
                    '        Dim DTNEW As DataTable = OBJCMN.Execute_Any_String("UPDATE VERSION SET VERSION_NO='1.0.0000'", "", "")
                    '        GoTo LINE1
                    '    End If
                ElseIf ClientName = "BELLA" Then
                    If Now.Date > DateTime.Parse("15.11.2025 00:00") Then
                        Dim DTNEW As DataTable = OBJCMN.Execute_Any_String("UPDATE VERSION SET VERSION_NO='1.0.0000'", "", "")
                        GoTo LINE1
                    End If
                ElseIf ClientName = "CLASSIC" Then
                    DISCONTINUECLIENT = True
                    '    If Now.Date > DateTime.Parse("15.04.2022 00:00") Then
                    '        Dim DTNEW As DataTable = OBJCMN.Execute_Any_String("UPDATE VERSION SET VERSION_NO='1.0.0000'", "", "")
                    '        GoTo LINE1
                    '    End If
                    'ElseIf ClientName = "COZY" Then
                    '    If Now.Date > DateTime.Parse("15.03.2021 00:00") Then
                    '        Dim DTNEW As DataTable = OBJCMN.Execute_Any_String("UPDATE VERSION SET VERSION_NO='1.0.0000'", "", "")
                    '        GoTo LINE1
                    '    End If
                    'ElseIf ClientName = "DEV" Then
                    '    If Now.Date > DateTime.Parse("19.10.2022 00:00") Then
                    '        Dim DTNEW As DataTable = OBJCMN.Execute_Any_String("UPDATE VERSION SET VERSION_NO='1.0.0000'", "", "")
                    '        GoTo LINE1
                    '    End If
                    'ElseIf ClientName = "GLOBE" Then
                    '    If Now.Date > DateTime.Parse("15.04.2021 00:00") Then
                    '        Dim DTNEW As DataTable = OBJCMN.Execute_Any_String("UPDATE VERSION SET VERSION_NO='1.0.0000'", "", "")
                    '        GoTo LINE1
                    '    End If
                ElseIf ClientName = "HAPPYHOLIDAYS" Then
                    If Now.Date > DateTime.Parse("15.02.2026 00:00") Then
                        Dim DTNEW As DataTable = OBJCMN.Execute_Any_String("UPDATE VERSION SET VERSION_NO='1.0.0000'", "", "")
                        GoTo LINE1
                    End If
                ElseIf ClientName = "HEENKAR" Then
                    DISCONTINUECLIENT = True
                    'If Now.Date > DateTime.Parse("15.12.2024 00:00") Then
                    '    Dim DTNEW As DataTable = OBJCMN.Execute_Any_String("UPDATE VERSION SET VERSION_NO='1.0.0000'", "", "")
                    '    GoTo LINE1
                    'End If
                ElseIf ClientName = "JPTRAVELGRAM" Then
                    If Now.Date > DateTime.Parse("15.07.2025 00:00") Then
                        Dim DTNEW As DataTable = OBJCMN.Execute_Any_String("UPDATE VERSION SET VERSION_NO='1.0.0000'", "", "")
                        GoTo LINE1
                    End If
                ElseIf ClientName = "KHANNA" Then
                    LEADMANAGEMENT = True
                    If Now.Date > DateTime.Parse("15.10.2025 00:00") Then
                        Dim DTNEW As DataTable = OBJCMN.Execute_Any_String("UPDATE VERSION SET VERSION_NO='1.0.0000'", "", "")
                        GoTo LINE1
                    End If
                ElseIf ClientName = "KPNT" Then
                    If Now.Date > DateTime.Parse("15.04.2026 00:00") Then
                        Dim DTNEW As DataTable = OBJCMN.Execute_Any_String("UPDATE VERSION SET VERSION_NO='1.0.0000'", "", "")
                        GoTo LINE1
                    End If
                    'ElseIf ClientName = "LUXCREST" Then
                    '    If Now.Date > DateTime.Parse("30.03.2019 00:00") Then
                    '        Dim DTNEW As DataTable = OBJCMN.Execute_Any_String("UPDATE VERSION SET VERSION_NO='1.0.0000'", "", "")
                    '        GoTo LINE1
                    '    End If
                    'ElseIf ClientName = "MAHARAJA" Then
                    '    If Now.Date > DateTime.Parse("15.02.2020 00:00") Then
                    '        Dim DTNEW As DataTable = OBJCMN.Execute_Any_String("UPDATE VERSION SET VERSION_NO='1.0.0000'", "", "")
                    '        GoTo LINE1
                    '    End If
                ElseIf ClientName = "MILONI" Then
                    DISCONTINUECLIENT = True
                    'If Now.Date > DateTime.Parse("15.04.2022 00:00") Then
                    '    Dim DTNEW As DataTable = OBJCMN.Execute_Any_String("UPDATE VERSION SET VERSION_NO='1.0.0000'", "", "")
                    '    GoTo LINE1
                    'End If
                ElseIf ClientName = "MATRIX" Then
                    DISCONTINUECLIENT = True
                    'If Now.Date > DateTime.Parse("15.10.2023 00:00") Then
                    '    Dim DTNEW As DataTable = OBJCMN.Execute_Any_String("UPDATE VERSION SET VERSION_NO='1.0.0000'", "", "")
                    '    GoTo LINE1
                    'End If
                ElseIf ClientName = "PRATAMESH" Then
                    If Now.Date > DateTime.Parse("15.07.2025 00:00") Then
                        Dim DTNEW As DataTable = OBJCMN.Execute_Any_String("UPDATE VERSION SET VERSION_NO='1.0.0000'", "", "")
                        GoTo LINE1
                    End If
                ElseIf ClientName = "RAMKRISHNA" Then
                    If Now.Date > DateTime.Parse("15.04.2025 00:00") Then
                        Dim DTNEW As DataTable = OBJCMN.Execute_Any_String("UPDATE VERSION SET VERSION_NO='1.0.0000'", "", "")
                        GoTo LINE1
                    End If
                ElseIf ClientName = "ROYALHOLIDAYS" Then
                    LEADMANAGEMENT = True
                    If Now.Date > DateTime.Parse("15.03.2026 00:00") Then
                        Dim DTNEW As DataTable = OBJCMN.Execute_Any_String("UPDATE VERSION SET VERSION_NO='1.0.0000'", "", "")
                        GoTo LINE1
                    End If
                    'ElseIf ClientName = "SAFAR" Then
                    '    If Now.Date > DateTime.Parse("15.12.2020 00:00") Then
                    '        Dim DTNEW As DataTable = OBJCMN.Execute_Any_String("UPDATE VERSION SET VERSION_NO='1.0.0000'", "", "")
                    '        GoTo LINE1
                    '    End If
                ElseIf ClientName = "SKYMAPS" Then
                    If Now.Date > DateTime.Parse("15.04.2026 00:00") Then
                        Dim DTNEW As DataTable = OBJCMN.Execute_Any_String("UPDATE VERSION SET VERSION_NO='1.0.0000'", "", "")
                        GoTo LINE1
                    End If
                ElseIf ClientName = "SSR" Then
                    LEADMANAGEMENT = True
                    If Now.Date > DateTime.Parse("15.04.2026 00:00") Then
                        Dim DTNEW As DataTable = OBJCMN.Execute_Any_String("UPDATE VERSION SET VERSION_NO='1.0.0000'", "", "")
                        GoTo LINE1
                    End If
                ElseIf ClientName = "STARVISA" Then
                    If Now.Date > DateTime.Parse("15.12.2025 00:00") Then
                        Dim DTNEW As DataTable = OBJCMN.Execute_Any_String("UPDATE VERSION SET VERSION_NO='1.0.0000'", "", "")
                        GoTo LINE1
                    End If
                    'ElseIf ClientName = "TOPCOMM" Then
                    '    If Now.Date > DateTime.Parse("15.04.2021 00:00") Then
                    '        Dim DTNEW As DataTable = OBJCMN.Execute_Any_String("UPDATE VERSION SET VERSION_NO='1.0.0000'", "", "")
                    '        GoTo LINE1
                    '    End If
                ElseIf ClientName = "TRAVELBRIDGE" Then
                    LEADMANAGEMENT = True
                    If Now.Date > DateTime.Parse("15.09.2025 00:00") Then
                        Dim DTNEW As DataTable = OBJCMN.Execute_Any_String("UPDATE VERSION SET VERSION_NO='1.0.0000'", "", "")
                        GoTo LINE1
                    End If
                ElseIf ClientName = "TRAVIZIA" Then
                    LEADMANAGEMENT = True
                    If Now.Date > DateTime.Parse("15.01.2025 00:00") Then
                        Dim DTNEW As DataTable = OBJCMN.Execute_Any_String("UPDATE VERSION SET VERSION_NO='1.0.0000'", "", "")
                        GoTo LINE1
                    End If
                ElseIf ClientName = "TRISHA" Then
                    If Now.Date > DateTime.Parse("15.07.2025 00:00") Then
                        Dim DTNEW As DataTable = OBJCMN.Execute_Any_String("UPDATE VERSION SET VERSION_NO='1.0.0000'", "", "")
                        GoTo LINE1
                    End If
                ElseIf ClientName = "UNIGO" Then
                    If Now.Date > DateTime.Parse("15.04.2025 00:00") Then
                        Dim DTNEW As DataTable = OBJCMN.Execute_Any_String("UPDATE VERSION SET VERSION_NO='1.0.0000'", "", "")
                        GoTo LINE1
                    End If
                ElseIf ClientName = "URMI" Then
                    If Now.Date > DateTime.Parse("15.04.2026 00:00") Then
                        Dim DTNEW As DataTable = OBJCMN.Execute_Any_String("UPDATE VERSION SET VERSION_NO='1.0.0000'", "", "")
                        GoTo LINE1
                    End If
                    'ElseIf ClientName = "VIDHI" Then
                    '    LEADMANAGEMENT = True
                    '    If Now.Date > DateTime.Parse("15.02.2023 00:00") Then
                    '        Dim DTNEW As DataTable = OBJCMN.Execute_Any_String("UPDATE VERSION SET VERSION_NO='1.0.0000'", "", "")
                    '        GoTo LINE1
                    '    End If
                ElseIf ClientName = "VIHAR" Then
                    LEADMANAGEMENT = True
                    If Now.Date > DateTime.Parse("15.01.2026 00:00") Then
                        Dim DTNEW As DataTable = OBJCMN.Execute_Any_String("UPDATE VERSION SET VERSION_NO='1.0.0000'", "", "")
                        GoTo LINE1
                    End If
                ElseIf ClientName = "VINAYAK" Then
                    If Now.Date > DateTime.Parse("15.03.2026 00:00") Then
                        Dim DTNEW As DataTable = OBJCMN.Execute_Any_String("UPDATE VERSION SET VERSION_NO='1.0.0000'", "", "")
                        GoTo LINE1
                    End If
                Else
                    GoTo LINE1
                End If



                If DT.Rows(0).Item("VERSION") <> "1.0.0085" Then
                    MsgBox("Please Uninstall previous copy of TRAVELMATE and Re-Install the Latest Version.", MsgBoxStyle.Critical)
LINE1:
                    MsgBox(" VERSION EXPIRED PLEASE CONTACT NAKODA INFOTECH ON 02249724411", MsgBoxStyle.Critical)
                    End
                End If
            Else
                'IF CLIENTNAME IS NOT PRESENT
                End
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtpassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtpassword.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If txtusername.Text.Trim <> "" And txtpassword.Text.Trim <> "" Then Call cmdok_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Login_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\Control Panel\International", "sShortDate", "dd/MM/yyyy")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class
