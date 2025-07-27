
Imports System.ComponentModel
Imports BL

Public Class MiscEnquiry

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public edit As Boolean
    Public TEMPENQNO As Integer

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Sub GETMAX_MISCENQ_NO()
        Try
            Dim DTTABLE As New DataTable
            DTTABLE = getmax(" isnull(max(MISC_NO),0) + 1 ", " MISCENQUIRY ", " and MISC_yearid = " & YearId)
            If DTTABLE.Rows.Count > 0 Then TXTENQNO.Text = DTTABLE.Rows(0).Item(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbguestname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBGUESTNAME.Enter
        Try
            If CMBGUESTNAME.Text.Trim = "" Then FILLGUESTNAME(CMBGUESTNAME, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGUESTNAME_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBGUESTNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJGUEST As New SelectGuest
                OBJGUEST.ShowDialog()
                If OBJGUEST.TEMPGUESTNAME <> "" Then CMBGUESTNAME.Text = OBJGUEST.TEMPGUESTNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGUESTNAME_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBGUESTNAME.Validated
        Try
            If CMBGUESTNAME.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" GUEST_MOBILENO AS MOBILENO, ISNULL(GUEST_EMAIL,'') AS EMAILID, ISNULL(GUEST_ADD,'') AS [ADDRESS] ", "", " GUESTMASTER ", " AND GUEST_NAME ='" & CMBGUESTNAME.Text.Trim & "' AND GUEST_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    If ClientName <> "TRAVELBRIDGE" Then
                        TXTMOBILENO.Text = DT.Rows(0).Item("MOBILENO")
                        TXTEMAILID.Text = DT.Rows(0).Item("EMAILID")
                    End If
                    TXTADD.Text = DT.Rows(0).Item("ADDRESS")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub clear()
        Try
            CMBCATEGORY.Text = ""
            CMBBOOKER.Text = ""
            CMBBOOKER.Items.Clear()

            tstxtbillno.Clear()
            TXTENQNO.Clear()
            ENQDATE.Value = Mydate
            TXTENQNAME.Clear()
            TXTENQMOBILENO.Clear()
            TXTENQEMAILID.Clear()
            CMBPREFIX.Text = ""
            CMBGUESTNAME.Text = ""
            TXTMOBILENO.Clear()
            TXTEMAILID.Clear()
            CMBTYPE.SelectedIndex = 0
            CMBSTATUS.SelectedIndex = 0
            TXTDESC.Clear()
            CMBSOURCE.Text = ""
            CMBBOOKEDBY.Text = ""
            CMBENQTRANSFERREDTO.Text = ""
            cmbcity.Text = ""
            CMBSTATE.Text = ""
            CMBLEADTYPE.Text = ""
            CHECKIN.Clear()
            CHECKOUT.Clear()
            TXTADD.Clear()
            TXTADULTS.Clear()
            TXTCHILD.Clear()
            TXTINFANTS.Clear()
            TXTTOTALPAX.Clear()
            TXTAGEPOLICYWITHBED.Clear()
            TXTAGEPOLICYWITHOUTBED.Clear()
            TXTCHILDWITHOUTBED.Clear()
            TXTEXTRAADULTS.Clear()
            TXTROOMS.Clear()
            TXTCLOSEREMARKS.Clear()
            CMBLEADTYPE.Text = ""
            EP.Clear()
            GETMAX_MISCENQ_NO()
            CMBCATEGORY.Text = ""
            TXTFOLLOWUPREMARKS.Clear()
            If UserName = "Admin" Then
                CMBBOOKEDBY.Enabled = True
            Else
                CMBBOOKEDBY.Enabled = False
                CMBBOOKEDBY.Text = UserName
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCLEAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        clear()
        edit = False
        ENQDATE.Focus()
    End Sub

    Private Sub MiscEnquiry_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.OemQuotes Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for DIRECT LINK TO INV NO
                tstxtbillno.Focus()
                tstxtbillno.SelectAll()
            ElseIf e.KeyCode = Keys.Left And e.Alt = True Then
                Call toolprevious_Click(sender, e)
            ElseIf e.KeyCode = Keys.Right And e.Alt = True Then
                Call toolnext_Click(sender, e)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillcmb()
        Try
            If CMBCATEGORY.Text.Trim = "" Then FILLCATEGORY(CMBCATEGORY)
            If CMBGUESTNAME.Text.Trim = "" Then FILLGUESTNAME(CMBGUESTNAME, edit)
            If CMBSOURCE.Text.Trim = "" Then FILLSOURCE(CMBSOURCE, edit)
            If CMBBOOKEDBY.Text.Trim = "" Then FILLBOOKEDBY(CMBBOOKEDBY, edit)
            If CMBENQTRANSFERREDTO.Text.Trim = "" Then FILLBOOKEDBY(CMBENQTRANSFERREDTO, edit)
            If cmbcity.Text.Trim = "" Then fillcity(cmbcity)
            If CMBLEADTYPE.Text.Trim = "" Then FILLLEADTYPE(CMBLEADTYPE)

            Dim objclscommon As New ClsCommon
            Dim dt As DataTable = objclscommon.search("state_name", "", "StateMaster", " AND STATE_YEARID =" & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "state_name"
                CMBSTATE.DataSource = dt
                CMBSTATE.DisplayMember = "state_name"
                CMBSTATE.Text = ""
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub MiscEnquiry_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow

            DTROW = USERRIGHTS.Select("FormName = 'MISC ENQUIRY'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor
            fillcmb()
            clear()

            If ENQTRANSFER = True Then CMBENQTRANSFERREDTO.Enabled = True

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim dttable As New DataTable
                Dim OBJFOREXENQ As New ClsMiscEnquiry

                OBJFOREXENQ.alParaval.Add(TEMPENQNO)
                OBJFOREXENQ.alParaval.Add(YearId)
                dttable = OBJFOREXENQ.SELECTMISCENQ()

                If dttable.Rows.Count > 0 Then
                    TXTMOBILENO.Focus()

                    TXTENQNO.Text = TEMPENQNO
                    CMBCATEGORY.Text = dttable.Rows(0).Item("CATEGORY").ToString
                    CMBBOOKER.Text = dttable.Rows(0).Item("BOOKER").ToString
                    ENQDATE.Value = dttable.Rows(0).Item("DATE")
                    TXTENQNAME.Text = dttable.Rows(0).Item("ENQNAME").ToString
                    TXTENQMOBILENO.Text = dttable.Rows(0).Item("ENQMOBILENO").ToString
                    TXTENQEMAILID.Text = dttable.Rows(0).Item("ENQEMAILID").ToString
                    CMBPREFIX.Text = dttable.Rows(0).Item("PREFIX").ToString
                    CMBGUESTNAME.Text = dttable.Rows(0).Item("GUESTNAME").ToString
                    TXTMOBILENO.Text = dttable.Rows(0).Item("MOBILENO").ToString
                    TXTEMAILID.Text = dttable.Rows(0).Item("EMAILID").ToString
                    CMBTYPE.Text = dttable.Rows(0).Item("TYPE").ToString
                    CMBLEADTYPE.Text = dttable.Rows(0).Item("LEADTYPE").ToString
                    CMBSTATUS.Text = dttable.Rows(0).Item("STATUS").ToString
                    cmbcity.Text = dttable.Rows(0).Item("CITY").ToString
                    CMBSTATE.Text = dttable.Rows(0).Item("STATENAME").ToString

                    TXTDESC.Text = dttable.Rows(0).Item("DESC").ToString
                    CMBSOURCE.Text = dttable.Rows(0).Item("SOURCE").ToString
                    CMBBOOKEDBY.Text = dttable.Rows(0).Item("BOOKEDBY").ToString
                    CMBENQTRANSFERREDTO.Text = dttable.Rows(0).Item("ENQTRANSFERREDTO").ToString
                    CHECKIN.Text = dttable.Rows(0).Item("CHECKIN").ToString
                    CHECKOUT.Text = dttable.Rows(0).Item("CHECKOUT").ToString
                    TXTADD.Text = dttable.Rows(0).Item("ADDRESS").ToString
                    TXTADULTS.Text = dttable.Rows(0).Item("ADULTS").ToString
                    TXTCHILD.Text = dttable.Rows(0).Item("CHILD").ToString
                    TXTINFANTS.Text = dttable.Rows(0).Item("INFANTS").ToString
                    TXTTOTALPAX.Text = dttable.Rows(0).Item("TOTALPAX").ToString
                    TXTAGEPOLICYWITHBED.Text = dttable.Rows(0).Item("AGEPOLICYCHILDWITHBED").ToString
                    TXTAGEPOLICYWITHOUTBED.Text = dttable.Rows(0).Item("AGEPOLICYCHILDWITHOUTBED").ToString
                    TXTCHILDWITHOUTBED.Text = dttable.Rows(0).Item("CHILDWITHOUTBED").ToString
                    TXTEXTRAADULTS.Text = dttable.Rows(0).Item("EXTRAADULTS").ToString
                    TXTROOMS.Text = dttable.Rows(0).Item("ROOMS").ToString
                    TXTCLOSEREMARKS.Text = dttable.Rows(0).Item("CLOSEDREMARKS").ToString
                    TXTFOLLOWUPREMARKS.Text = dttable.Rows(0).Item("FOLLOWUPREMARKS").ToString

                    If Convert.ToBoolean(dttable.Rows(0).Item("DONE")) = True Then
                        lbllocked.Visible = True
                        PBlock.Visible = True
                    End If

                End If
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(ENQDATE.Value.Date)
            alParaval.Add(TXTENQNAME.Text.Trim)
            alParaval.Add(TXTENQMOBILENO.Text.Trim)
            alParaval.Add(TXTENQEMAILID.Text.Trim)
            alParaval.Add(CMBPREFIX.Text.Trim)
            alParaval.Add(CMBGUESTNAME.Text.Trim)
            alParaval.Add(TXTMOBILENO.Text.Trim)
            alParaval.Add(TXTEMAILID.Text.Trim)
            alParaval.Add(CMBTYPE.Text.Trim)
            alParaval.Add(CMBLEADTYPE.Text.Trim)
            alParaval.Add(CMBSTATUS.Text.Trim)
            alParaval.Add(cmbcity.Text.Trim)

            alParaval.Add(TXTDESC.Text.Trim)
            alParaval.Add(CMBSOURCE.Text.Trim)
            alParaval.Add(CMBBOOKEDBY.Text.Trim)
            alParaval.Add(CMBENQTRANSFERREDTO.Text.Trim)
            If CHECKIN.Text.Trim <> "__/__/____" Then alParaval.Add(Format(Convert.ToDateTime(CHECKIN.Text).Date, "dd/MM/yyyy")) Else alParaval.Add("")
            If CHECKOUT.Text.Trim <> "__/__/____" Then alParaval.Add(Format(Convert.ToDateTime(CHECKOUT.Text).Date, "dd/MM/yyyy")) Else alParaval.Add("")
            alParaval.Add(TXTADD.Text.Trim)
            alParaval.Add(Val(TXTADULTS.Text.Trim))
            alParaval.Add(Val(TXTCHILD.Text.Trim))
            alParaval.Add(Val(TXTINFANTS.Text.Trim))
            alParaval.Add(Val(TXTTOTALPAX.Text.Trim))
            alParaval.Add(TXTAGEPOLICYWITHBED.Text.Trim)
            alParaval.Add(TXTAGEPOLICYWITHOUTBED.Text.Trim)
            alParaval.Add(Val(TXTCHILDWITHOUTBED.Text.Trim))
            alParaval.Add(Val(TXTEXTRAADULTS.Text.Trim))
            alParaval.Add(Val(TXTROOMS.Text.Trim))
            alParaval.Add(TXTCLOSEREMARKS.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(CMBCATEGORY.Text.Trim)
            alParaval.Add(CMBBOOKER.Text.Trim)
            alParaval.Add(CMBSTATE.Text.Trim)
            alParaval.Add(TXTFOLLOWUPREMARKS.Text.Trim)

            Dim OBJMISCENQ As New ClsMiscEnquiry
            OBJMISCENQ.alParaval = alParaval

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DT As DataTable = OBJMISCENQ.SAVE()
                TEMPENQNO = DT.Rows(0).Item(0)
                MsgBox("Details Added")
                clear()


            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPENQNO)
                IntResult = OBJMISCENQ.UPDATE()
                edit = False
                MsgBox("Details Updated")
                clear()
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Function ERRORVALID() As Boolean
        Dim bln As Boolean = True

        If CMBGUESTNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBGUESTNAME, "Select Guest Name")
            bln = False
        End If

        If TXTMOBILENO.Text.Trim.Length = 0 And ClientName <> "TRAVELBRIDGE" Then
            EP.SetError(TXTMOBILENO, "Enter Mobile No")
            bln = False
        End If

        If TXTDESC.Text.Trim.Length = 0 Then
            EP.SetError(TXTDESC, "Enter Description")
            bln = False
        End If

        If CMBTYPE.Text.Trim = "" Then
            EP.SetError(CMBTYPE, "Select Type")
            bln = False
        End If



        If CMBSOURCE.Text.Trim.Length = 0 And (ClientName = "TRAVIZIA") Then
            EP.SetError(CMBSOURCE, "Select Source")
            bln = False
        End If

        If CMBBOOKEDBY.Text.Trim.Length = 0 Then
            EP.SetError(CMBBOOKEDBY, "Select Enquiry Handeled By")
            bln = False
        End If


        If CMBSTATUS.Text.Trim.Length = 0 Then
            EP.SetError(CMBSTATUS, "Select Enquiry Status")
            bln = False
        End If

        If lbllocked.Visible = True Then
            EP.SetError(lbllocked, "Enquiry Locked, Entry is Confirmed")
            bln = False
        End If

        If ClientName <> "VIHAR" Then
            If Not datecheck(ENQDATE.Value.Date) Then
                EP.SetError(ENQDATE, "Date Not in Accounting Year")
                bln = False
            End If
        End If


        If CMBSTATUS.Text = "Cancel" And TXTCLOSEREMARKS.Text.Trim.Length = 0 Then
            EP.SetError(TXTCLOSEREMARKS, "Enter Closing Remarks")
            bln = False
        End If

        If ClientName = "RAMKRISHNA" And TXTADD.Text.Trim.Length = 0 Then
            EP.SetError(TXTADD, "Enter Address")
            bln = False
        End If

        If ClientName = "TRAVELBRIDGE" And CMBCATEGORY.Text.Trim = "" Then
            EP.SetError(CMBCATEGORY, "Fill Company Group")
            bln = False
        End If


        If ClientName = "TRAVELBRIDGE" And cmbcity.Text.Trim = "" Then
            EP.SetError(cmbcity, "Fill City Name")
            bln = False
        End If

        If CMBSTATE.Text.Trim.Length = 0 And ClientName <> "TRAVELBRIDGE" Then
            EP.SetError(CMBSTATE, "Select State")
            bln = False
        End If

        If ALLOWSAMESTATE = True And CMBSTATE.Text.Trim <> CMPSTATENAME Then
            EP.SetError(CMBSTATE, " Enquiry Of Other State Not Allowed")
            bln = False
        End If


        Return bln

    End Function

    Private Sub CMBSOURCE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBSOURCE.Enter
        Try
            If CMBSOURCE.Text.Trim = "" Then FILLSOURCE(CMBSOURCE, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSOURCE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSOURCE.Validating
        Try
            If CMBSOURCE.Text.Trim <> "" Then SOURCEvalidate(CMBSOURCE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBOOKEDBY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBBOOKEDBY.Enter
        Try
            If CMBBOOKEDBY.Text.Trim = "" Then FILLBOOKEDBY(CMBBOOKEDBY, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBOOKEDBY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBBOOKEDBY.Validating
        Try
            If CMBBOOKEDBY.Text.Trim <> "" Then BOOKEDBYvalidate(CMBBOOKEDBY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBENQTRANSFERREDTO_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBENQTRANSFERREDTO.Enter
        Try
            If CMBENQTRANSFERREDTO.Text.Trim = "" Then FILLBOOKEDBY(CMBENQTRANSFERREDTO, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBENQTRANSFERREDTO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBENQTRANSFERREDTO.Validating
        Try
            If CMBENQTRANSFERREDTO.Text.Trim <> "" Then BOOKEDBYvalidate(CMBENQTRANSFERREDTO, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try

LINE1:
            TEMPENQNO = Val(TXTENQNO.Text) - 1
Line2:
            If TEMPENQNO > 0 Then

                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable
                If ClientName = "VIDHI" Then
                    If UserName <> "Admin" Then
                        DT = OBJCMN.search(" MISC_NO ", "", "  MISCENQUIRY INNER JOIN BOOKEDBYMASTER ON MISCENQUIRY.MISC_BOOKEDBYID = BOOKEDBYMASTER.BOOKEDBY_ID AND MISCENQUIRY.MISC_YEARID = BOOKEDBYMASTER.BOOKEDBY_YEARID ", " AND MISC_NO = '" & TEMPENQNO & "' AND BOOKEDBY_NAME = '" & UserName & "' AND MISC_YEARID = " & YearId)
                    Else
                        DT = OBJCMN.search(" MISC_NO ", "", "  MISCENQUIRY", " AND MISC_NO = '" & TEMPENQNO & "' AND MISC_YEARID = " & YearId)
                    End If
                Else
                    DT = OBJCMN.search(" MISC_NO ", "", "  MISCENQUIRY", " AND MISC_NO = '" & TEMPENQNO & "' AND MISC_YEARID = " & YearId)
                End If

                If DT.Rows.Count > 0 Then
                    edit = True
                    MiscEnquiry_Load(sender, e)
                Else
                    TEMPENQNO = Val(TEMPENQNO - 1)
                    GoTo Line2
                End If
            Else
                clear()
                edit = False
            End If

            If CMBGUESTNAME.Text.Trim = "" And TEMPENQNO > 1 Then
                TXTENQNO.Text = TEMPENQNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try

LINE1:
            TEMPENQNO = Val(TXTENQNO.Text) + 1

            GETMAX_MISCENQ_NO()
            Dim MAXNO As Integer = TXTENQNO.Text.Trim
            clear()

            If Val(TXTENQNO.Text) - 1 >= TEMPENQNO Then

                If ClientName = "VIDHI" Then
                    If UserName <> "Admin" Then
                        Dim OBJCMN As New ClsCommon
                        Dim DT As DataTable
                        DT = OBJCMN.search(" MISC_NO ", "", "  MISCENQUIRY INNER JOIN BOOKEDBYMASTER ON MISCENQUIRY.MISC_BOOKEDBYID = BOOKEDBYMASTER.BOOKEDBY_ID AND MISCENQUIRY.MISC_YEARID = BOOKEDBYMASTER.BOOKEDBY_YEARID ", " AND MISC_NO = '" & TEMPENQNO & "' AND BOOKEDBY_NAME = '" & UserName & "' AND MISC_YEARID = " & YearId)
                        If DT.Rows.Count > 0 Then
                            edit = True
                            MiscEnquiry_Load(sender, e)
                        End If
                    Else
                        edit = True
                        MiscEnquiry_Load(sender, e)
                    End If
                Else

                    edit = True
                    MiscEnquiry_Load(sender, e)
                End If
            Else
                clear()
                edit = False
            End If
            If CMBGUESTNAME.Text.Trim = "" And TEMPENQNO < MAXNO Then
                TXTENQNO.Text = TEMPENQNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tstxtbillno.Validated
        Try
            If tstxtbillno.Text.Trim.Length = 0 Then Exit Sub
            TEMPENQNO = Val(tstxtbillno.Text)
            If TEMPENQNO > 0 Then

                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable
                If ClientName = "VIDHI" Then
                    If UserName <> "Admin" Then
                        DT = OBJCMN.search(" MISC_NO ", "", "  MISCENQUIRY INNER JOIN BOOKEDBYMASTER ON MISCENQUIRY.MISC_BOOKEDBYID = BOOKEDBYMASTER.BOOKEDBY_ID AND MISCENQUIRY.MISC_YEARID = BOOKEDBYMASTER.BOOKEDBY_YEARID ", " AND MISC_NO = '" & TEMPENQNO & "' AND BOOKEDBY_NAME = '" & UserName & "' AND MISC_YEARID = " & YearId)
                    Else
                        DT = OBJCMN.search(" MISC_NO ", "", "  MISCENQUIRY", " AND MISC_NO = '" & TEMPENQNO & "' AND MISC_YEARID = " & YearId)
                    End If
                Else
                    DT = OBJCMN.search(" MISC_NO ", "", "  MISCENQUIRY", " AND MISC_NO = '" & TEMPENQNO & "' AND MISC_YEARID = " & YearId)
                End If

                If DT.Rows.Count > 0 Then
                    edit = True
                    MiscEnquiry_Load(sender, e)
                Else
                    clear()
                    edit = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Try
            If edit = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If lbllocked.Visible = True Then
                    MsgBox("Enquiry Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                Dim OBJFOREX As New ClsMiscEnquiry()
                Dim TEMPMSG As Integer = MsgBox("Wish To Delete?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then

                    Dim alParaval As New ArrayList
                    alParaval.Add(TEMPENQNO)
                    alParaval.Add(YearId)
                    alParaval.Add(Userid)
                    OBJFOREX.alParaval = alParaval
                    Dim INTRES As Integer = OBJFOREX.DELETE()
                    MsgBox("Misc Enquiry Deleted Successfully")
                    clear()
                    edit = False

                End If

            Else
                MsgBox("Delete is only in edit mode!")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHECKIN_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CHECKIN.Validating
        Try
            If CHECKIN.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(CHECKIN.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHECKOUT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CHECKOUT.Validating
        Try
            If CHECKOUT.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(CHECKOUT.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJFOREX As New MiscEnquiryDetails
            OBJFOREX.MdiParent = MDIMain
            OBJFOREX.Show()
            Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTADULTS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTADULTS.KeyPress, TXTCHILD.KeyPress, TXTINFANTS.KeyPress, TXTEXTRAADULTS.KeyPress, TXTCHILDWITHOUTBED.KeyPress, TXTROOMS.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Sub TOTAL()
        TXTTOTALPAX.Text = Val(TXTADULTS.Text) + Val(TXTCHILD.Text) + Val(TXTINFANTS.Text) + Val(TXTCHILDWITHOUTBED.Text) + Val(TXTEXTRAADULTS.Text.Trim)
    End Sub

    Private Sub TXTADULTS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTADULTS.Validated
        If Val(TXTADULTS.Text.Trim) > 0 And Val(TXTROOMS.Text.Trim) = 0 Then TXTROOMS.Text = Math.Floor(Val(TXTADULTS.Text.Trim) / 2)
    End Sub

    Private Sub TXTADULTS_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTADULTS.Validating, TXTCHILD.Validating, TXTINFANTS.Validating, TXTCHILDWITHOUTBED.Validating, TXTEXTRAADULTS.Validating
        TOTAL()
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call CMDOK_Click(sender, e)
    End Sub

    Private Sub TOOLSMS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLSMS.Click
        If edit = False Then Exit Sub
        SMSCODE()
    End Sub

    Sub SMSCODE()
        If ALLOWSMS = True And TXTMOBILENO.Text.Trim <> "" Then
            If SENDMSG("Dear " & CMBGUESTNAME.Text.Trim & ", Thanks you for Chosing " & CmpName & ". Your Inquiry has been noted down, our executive will get in touch Shortly.", TXTMOBILENO.Text.Trim) = "1701" Then MsgBox("Message Sent") Else MsgBox("Error Sending Message")
        End If
    End Sub

    Private Sub cmbcity_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcity.Validating
        Try
            If cmbcity.Text.Trim <> "" Then
                pcase(cmbcity)
                Dim objclscommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objclscommon.search("city_name", "", "CityMaster", " and city_name = '" & cmbcity.Text.Trim & "' and city_cmpid = " & CmpId & " and city_Locationid = " & Locationid & " and city_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbcity.Text.Trim
                    Dim tempmsg As Integer = MsgBox("City not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                        If DTROW(0).Item(1) = False Then
                            MsgBox("Insufficient Rights")
                            Exit Sub
                        End If
                        cmbcity.Text = a
                        objyearmaster.savecity(cmbcity.Text.Trim, CmpId, Locationid, Userid, YearId, " and city_name = '" & cmbcity.Text.Trim & "' and city_cmpid = " & CmpId & " and city_Locationid = " & Locationid & " and city_Yearid = " & YearId)
                        Dim dt1 As New DataTable
                        dt1 = cmbcity.DataSource
                        If cmbcity.DataSource <> Nothing Then
line1:
                            If dt1.Rows.Count > 0 Then
                                dt1.Rows.Add(cmbcity.Text)
                                cmbcity.Text = a
                            End If
                        End If
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcity_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcity.Enter
        Try
            If cmbcity.Text.Trim = "" Then fillcity(cmbcity)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGUESTNAME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGUESTNAME.Validating
        Try
            If ClientName = "BHAGYASHRI" Then
                If CMBGUESTNAME.Text.Trim <> "" Then GUESTNAMEVALIDATE(CMBGUESTNAME, e, Me, TXTGUESTADD)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPREFIX_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBPREFIX.Enter
        Try
            If CMBPREFIX.Text.Trim = "" Then FILLPREFIX(CMBPREFIX)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPREFIX_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBPREFIX.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub CMBPREFIX_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPREFIX.Validating
        Try
            If CMBPREFIX.Text.Trim <> "" Then PREFIXvalidate(CMBPREFIX, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MiscEnquiry_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If ClientName = "MATRIX" Then Me.Close()
            If ClientName = "TRAVELBRIDGE" Then
                LBLCATEGORY.Visible = True
                CMBCATEGORY.Visible = True
                LBLBOOKER.Visible = True
                CMBBOOKER.Visible = True
                TXTMOBILENO.BackColor = Color.White
                cmbcity.BackColor = Color.LemonChiffon
                CMBSTATE.BackColor = Color.LemonChiffon
            End If
            If ClientName = "TRAVIZIA" Then CMBSOURCE.BackColor = Color.LemonChiffon
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub CMBLEADTYPE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBLEADTYPE.Enter
        Try
            If CMBLEADTYPE.Text.Trim = "" Then FILLLEADTYPE(CMBLEADTYPE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub CMBLEADTYPE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBLEADTYPE.Validating
        Try
            If CMBLEADTYPE.Text.Trim <> "" Then LEADTYPEVALIDATE(CMBLEADTYPE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcategory_Validating(sender As Object, e As CancelEventArgs) Handles CMBCATEGORY.Validating
        Try
            If CMBCATEGORY.Text.Trim <> "" Then CATEGORYVALIDATE(CMBCATEGORY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcategory_Enter(sender As Object, e As EventArgs) Handles CMBCATEGORY.Enter
        Try
            If CMBCATEGORY.Text.Trim = "" Then FILLCATEGORY(CMBCATEGORY)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCATEGORY_Validated(sender As Object, e As EventArgs) Handles CMBCATEGORY.Validated
        Try
            'FETCH ALL THE BOOKER DETAILS FROM CONTACT DESC GRID WITH RESPECT TO SELECTED CATEGPORY FROM LEDGERS
            If CMBCATEGORY.Text.Trim <> "" Then
                CMBBOOKER.Items.Clear()
                CMBBOOKER.Text = ""
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" DISTINCT ISNULL(ACCOUNTSMASTER_CONTACTDESC.ACC_CONTACT, '') AS BOOKER", "", " LEDGERS INNER JOIN ACCOUNTSMASTER_CONTACTDESC ON LEDGERS.Acc_id = ACCOUNTSMASTER_CONTACTDESC.ACC_ID INNER JOIN CATEGORYMASTER ON LEDGERS.ACC_CATEGORYID = CATEGORYMASTER.CATEGORY_ID", " AND CATEGORYMASTER.CATEGORY_NAME = '" & CMBCATEGORY.Text.Trim & "' AND LEDGERS.ACC_YEARID = " & YearId)
                For Each DR As DataRow In DT.Rows
                    CMBBOOKER.Items.Add(DR("BOOKER"))
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBOOKER_Validated(sender As Object, e As EventArgs) Handles CMBBOOKER.Validated
        Try
            'FETCH MOBILE NO OF BOOKER
            If CMBCATEGORY.Text.Trim <> "" And CMBBOOKER.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" TOP 1 ISNULL(ACCOUNTSMASTER_CONTACTDESC.ACC_MOBILE, '') AS MOBILENO, ISNULL(ACCOUNTSMASTER_CONTACTDESC.ACC_EMAIL, '') AS EMAILID", "", " LEDGERS INNER JOIN ACCOUNTSMASTER_CONTACTDESC ON LEDGERS.Acc_id = ACCOUNTSMASTER_CONTACTDESC.ACC_ID INNER JOIN CATEGORYMASTER ON LEDGERS.ACC_CATEGORYID = CATEGORYMASTER.CATEGORY_ID", " AND CATEGORYMASTER.CATEGORY_NAME = '" & CMBCATEGORY.Text.Trim & "' AND ISNULL(ACCOUNTSMASTER_CONTACTDESC.ACC_CONTACT, '') = '" & CMBBOOKER.Text.Trim & "' AND LEDGERS.ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    TXTMOBILENO.Text = DT.Rows(0).Item("MOBILENO")
                    TXTEMAILID.Text = DT.Rows(0).Item("EMAILID")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSTATE_Enter(sender As Object, e As EventArgs) Handles CMBSTATE.Enter
        Try
            If CMBSTATE.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("state_name", "", "StateMaster", " and state_cmpid = " & CmpId & " and state_locationid = " & Locationid & " and state_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "state_name"
                    CMBSTATE.DataSource = dt
                    CMBSTATE.DisplayMember = "state_name"
                    CMBSTATE.Text = ""
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBSTATE_Validating(sender As Object, e As CancelEventArgs) Handles CMBSTATE.Validating
        Try
            If CMBSTATE.Text.Trim <> "" Then
                pcase(CMBSTATE)
                Dim objClsCommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objClsCommon.search("state_name", "", "StateMaster", " and state_name = '" & CMBSTATE.Text.Trim & "' and state_cmpid = " & CmpId & " and state_locationid = " & Locationid & " and state_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBSTATE.Text.Trim
                    Dim tempmsg As Integer = MsgBox("State not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        CMBSTATE.Text = a
                        objyearmaster.savestate(CMBSTATE.Text.Trim, CmpId, Locationid, Userid, YearId, " and state_name = '" & CMBSTATE.Text.Trim & "' and state_cmpid = " & CmpId & " and state_locationid = " & Locationid & " and state_yearid = " & YearId)
                        Dim dt1 As New DataTable
                        dt1 = CMBSTATE.DataSource
                        If CMBSTATE.DataSource <> Nothing Then
line1:
                            If dt1.Rows.Count > 0 Then
                                dt1.Rows.Add(CMBSTATE.Text)
                                CMBSTATE.Text = a
                            End If
                        End If
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
End Class