Imports BL
Imports System.Windows.Forms

Public Class citymaster

    Public frmstring As String          'Used for Area, City, State, Country Forms
    Public edit As Boolean              'Used for edit
    Public tempname As String           'Used for edit name
    Public tempcode As String           'Used for edit code
    Public tempid As Integer            'Used for edit id
    Public TEMPSTATECODE As String           'Used for edit name
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click

        Try

            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(txtname.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim objCity As New ClsCityMaster

            If frmstring = "CITYMASTER" Then
                Dim objyear As New ClsYearMaster
                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = objyear.savecity(txtname.Text.Trim, CmpId, Locationid, Userid, YearId, " and city_name ='" & txtname.Text.Trim & "' and city_cmpid = " & CmpId & " and city_Locationid = " & Locationid & " and city_yearid = " & YearId, txtremarks.Text.Trim)
                    MsgBox("City Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(tempid)
                    objCity.alParaval = alParaval
                    IntResult = objCity.UpdateCity()
                    MsgBox("City Updated")
                End If
            ElseIf frmstring = "GIFTMASTER" Then
                Dim objyear As New ClsYearMaster
                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = objyear.savegift(txtname.Text.Trim, CmpId, Locationid, Userid, YearId, " and GIFT_name ='" & txtname.Text.Trim & "' and GIFT_yearid = " & YearId, txtremarks.Text.Trim)
                    MsgBox("Gift Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(tempid)
                    objCity.alParaval = alParaval
                    IntResult = objCity.UpdateGift()
                    MsgBox("Gift Updated")
                End If

            ElseIf frmstring = "LOGINMASTER" Then
                Dim objyear As New ClsYearMaster
                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = objyear.savelogin(txtname.Text.Trim, CmpId, Locationid, Userid, YearId, " and LOGIN_name ='" & txtname.Text.Trim & "' and login_cmpid = " & CmpId & " and login_Locationid = " & Locationid & " and login_yearid = " & YearId, txtremarks.Text.Trim)
                    MsgBox("Login Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(tempid)
                    objCity.alParaval = alParaval
                    IntResult = objCity.UpdateLogin()
                    MsgBox("Login Updated")
                End If

            ElseIf frmstring = "IDMASTER" Then
                Dim objyear As New ClsYearMaster
                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = objyear.saveID(txtname.Text.Trim, CmpId, Locationid, Userid, YearId, " and ID_name ='" & txtname.Text.Trim & "' and ID_cmpid = " & CmpId & " and ID_Locationid = " & Locationid & " and ID_yearid = " & YearId, txtremarks.Text.Trim)
                    MsgBox("ID Type Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(tempid)
                    objCity.alParaval = alParaval
                    IntResult = objCity.UpdateIDType()
                    MsgBox("Login Updated")
                End If

            ElseIf frmstring = "AREAMASTER" Then
                Dim objyear As New ClsYearMaster
                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = objyear.savearea(txtname.Text.Trim, CmpId, Locationid, Userid, YearId, " and area_name='" & txtname.Text.Trim & "' and area_cmpid = " & CmpId & " and area_Locationid = " & Locationid & " and area_yearid = " & YearId, txtremarks.Text.Trim)
                    MsgBox("Area Added")

                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(tempid)
                    objCity.alParaval = alParaval
                    IntResult = objCity.UpdateArea()
                    MsgBox("Area Updated")
                End If

            ElseIf frmstring = "STATEMASTER" Then
                Dim objyear As New ClsYearMaster
                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = objyear.savestate(txtname.Text.Trim, CmpId, Locationid, Userid, YearId, " and state_name='" & txtname.Text.Trim & "' and state_cmpid = " & CmpId & " and state_Locationid = " & Locationid & " and state_yearid = " & YearId, txtremarks.Text.Trim)
                    MsgBox("State Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(tempid)
                    objCity.alParaval = alParaval
                    IntResult = objCity.UpdateState()
                    MsgBox("State Updated")
                End If

            ElseIf frmstring = "COUNTRYMASTER" Then
                Dim objyear As New ClsYearMaster
                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = objyear.savecountry(txtname.Text.Trim, CmpId, Locationid, Userid, YearId, " and country_name='" & txtname.Text.Trim & "' and country_cmpid = " & CmpId & " and country_Locationid = " & Locationid & " and country_yearid = " & YearId, txtremarks.Text.Trim)
                    MsgBox("Country Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(tempid)
                    objCity.alParaval = alParaval
                    IntResult = objCity.UpdateCountry()
                    MsgBox("Country Updated")
                End If
            ElseIf frmstring = "DOCUMENT" Then
                Dim objyear As New ClsYearMaster
                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = objyear.savedocument(txtname.Text.Trim, CmpId, Locationid, Userid, YearId, " and DOC_name='" & txtname.Text.Trim & "' and DOC_cmpid = " & CmpId & " and DOC_Locationid = " & Locationid & " and DOC_yearid = " & YearId, txtremarks.Text.Trim)
                    MsgBox("Document Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(tempid)
                    objCity.alParaval = alParaval
                    IntResult = objCity.UpdateDocument()
                    MsgBox("Document Updated")
                End If
            End If
            clear()
            edit = False
            txtname.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If txtname.Text.Trim.Length = 0 Then
            Ep.SetError(txtname, "Fill Name")
            bln = False
        End If


        If Not VALIDATENAME() Then
            Ep.SetError(txtname, "Name Already Exists")
            bln = False
        End If

        'VALIDATE STATE CODE 
        If frmstring = "STATEMASTER" Then
            If Val(txtremarks.Text.Trim) = 0 Then
                Ep.SetError(txtremarks, "Enter State Code")
                bln = False
            End If
            If txtremarks.Text.Trim <> "" Then
                If (edit = False) Or (edit = True And TEMPSTATECODE <> txtremarks.Text.Trim) Then
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search("STATE_REMARK AS CODE", "", "STATEMASTER", " and CAST(STATE_REMARK AS VARCHAR(5)) = '" & txtremarks.Text.Trim & "' and state_yearid = " & YearId)
                    If DT.Rows.Count > 0 Then
                        Ep.SetError(txtremarks, "State Code Already Exists")
                        bln = False
                    End If
                End If
            End If
        End If

        Return bln
    End Function

    Sub clear()
        txtname.Clear()
        txtremarks.Clear()
    End Sub

    Private Sub citymaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
            Call cmdok_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub citymaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            Dim DTROW() As DataRow
            If frmstring = "FORMTYPE" Then
                DTROW = USERRIGHTS.Select("FormName = 'FORMTYPE MASTER'")
            Else
                DTROW = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
            End If
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)


            Dim dttable As New DataTable
            Dim objCommon As New ClsCommonMaster

            If edit = True Then
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
            End If

            If frmstring = "CITYMASTER" Then

                Me.Text = "CITY MASTER"
                lblgroup.Text = "City"
                lbl.Text = "Enter City " & vbNewLine & "(e.g. Mumbai,Surat..., etc. )"
                If edit = True Then dttable = objCommon.search(" city_name, city_remark", "", "CityMaster", " and city_id = " & tempid & " and city_cmpid = " & CmpId & " and city_Locationid = " & Locationid & " and city_yearid = " & YearId)

            ElseIf frmstring = "GIFTMASTER" Then

                Me.Text = "HADIYAH / GIFT MASTER"
                lblgroup.Text = "Gift"
                lbl.Text = "Enter Gift " & vbNewLine & "(e.g. Bags,Passport Pouch..., etc. )"
                If edit = True Then dttable = objCommon.search(" gift_name, gift_remark", "", "giftMaster", " and gift_id = " & tempid & " and gift_cmpid = " & CmpId & " and gift_Locationid = " & Locationid & " and gift_yearid = " & YearId)

            ElseIf frmstring = "LOGINMASTER" Then

                Me.Text = "LOGIN MASTER"
                lblgroup.Text = "Login"
                lbl.Text = "Enter Login "
                If edit = True Then dttable = objCommon.search(" login_name, login_remark", "", "loginMaster", " and login_id = " & tempid & " and login_cmpid = " & CmpId & " and login_Locationid = " & Locationid & " and login_yearid = " & YearId)

            ElseIf frmstring = "IDMASTER" Then

                Me.Text = "ID MASTER"
                lblgroup.Text = "ID"
                lbl.Text = "Enter ID Type "
                If edit = True Then dttable = objCommon.search(" ID_name, ID_remark", "", "IDMaster", " and ID_id = " & tempid & " and ID_cmpid = " & CmpId & " and ID_Locationid = " & Locationid & " and ID_yearid = " & YearId)


            ElseIf frmstring = "AREAMASTER" Then

                Me.Text = "AREA MASTER"
                lblgroup.Text = "Area"
                lbl.Text = "Enter Area " & vbNewLine & "(e.g. Mumbai Central,Dadar..., etc. )"
                If edit = True Then dttable = objCommon.search(" area_name, area_remark", "", "AreaMaster", " and area_id = " & tempid & " and area_cmpid = " & CmpId & " and area_Locationid = " & Locationid & " and area_yearid = " & YearId)

            ElseIf frmstring = "FORMTYPE" Then

                Me.Text = "FORm MASTER"
                lblgroup.Text = "FORm"
                lbl.Text = "Enter FORm " & vbNewLine & "(e.g. C,H..., etc. )"
                If edit = True Then dttable = objCommon.search(" FORm_name, FORm_remark", "", "formtype", " and FORm_id = " & tempid & " and FORm_cmpid = " & CmpId & " and FORm_Locationid = " & Locationid & " and FORm_yearid = " & YearId)

            ElseIf frmstring = "STATEMASTER" Then

                Me.Text = "STATE MASTER"
                lblgroup.Text = "State"
                lbl.Text = "Enter State " & vbNewLine & "(e.g. Maharashtra,Goa..., etc. )"
                LBLCODE.Visible = True
                txtremarks.Visible = True
                If edit = True Then dttable = objCommon.search(" state_name, state_remark", "", "StateMaster", " and state_id = " & tempid & " and state_cmpid = " & CmpId & " and state_Locationid = " & Locationid & " and state_yearid = " & YearId)

            ElseIf frmstring = "COUNTRYMASTER" Then

                Me.Text = "COUNTRYMASTER"
                lblgroup.Text = "Country"
                lbl.Text = "Enter Country " & vbNewLine & "(e.g. India,South Africa..., etc. )"
                If edit = True Then dttable = objCommon.search(" country_name, country_remark", "", "CountryMaster", " and country_id = " & tempid & " and country_cmpid = " & CmpId & " and country_Locationid = " & Locationid & " and country_yearid = " & YearId)

            ElseIf frmstring = "DOCUMENT" Then

                Me.Text = "DOCUMENT MASTER"
                lblgroup.Text = "Document"
                lbl.Text = "Enter Document " & vbNewLine & "(e.g. Pancard,Passport..., etc. )"
                If edit = True Then dttable = objCommon.search(" doc_name, doc_remark", "", "DOCMaster", " and doc_id = " & tempid & " and doc_cmpid = " & CmpId & " and doc_yearid = " & YearId)
            End If

            If dttable.Rows.Count > 0 Then
                txtname.Text = dttable.Rows(0).Item(0).ToString
                txtremarks.Text = dttable.Rows(0).Item(1).ToString
                TEMPSTATECODE = txtremarks.Text.Trim
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try


    End Sub

    Private Sub txtname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtname.Validating
        Try
            If Not VALIDATENAME() Then e.Cancel = True
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Function VALIDATENAME() As Boolean
        Try
            Dim BLN As Boolean = True
            If (edit = False) Or (edit = True And LCase(tempname) <> LCase(txtname.Text.Trim)) Then
                ' search duplication 
                If txtname.Text.Trim <> Nothing Then
                    Dim objclscommon As New ClsCommonMaster
                    Dim dt As DataTable

                    If frmstring = "CITYMASTER" Then
                        dt = objclscommon.search("city_name", "", "cityMaster", " and city_name = '" & txtname.Text.Trim & "' and city_cmpid = " & CmpId & " and city_Locationid = " & Locationid & " and city_yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("City Name Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                            BLN = False
                        End If
                    ElseIf frmstring = "GIFTMASTER" Then
                        dt = objclscommon.search("gift_name", "", " giftMaster", " and gift_name = '" & txtname.Text.Trim & "' and gift_cmpid = " & CmpId & " and gift_Locationid = " & Locationid & " and gift_yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("Gift Name Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                            BLN = False
                        End If
                    ElseIf frmstring = "LOGINMASTER" Then
                        dt = objclscommon.search("LOGIN_name", "", "LOGINMaster", " and login_name = '" & txtname.Text.Trim & "' and login_cmpid = " & CmpId & " and login_Locationid = " & Locationid & " and login_yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("Login Name Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                            BLN = False
                        End If
                    ElseIf frmstring = "IDMASTER" Then
                        dt = objclscommon.search("ID_name", "", "IDMaster", " and ID_name = '" & txtname.Text.Trim & "' and ID_cmpid = " & CmpId & " and ID_Locationid = " & Locationid & " and ID_yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("ID Type Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                            BLN = False
                        End If
                    ElseIf frmstring = "AREAMASTER" Then
                        dt = objclscommon.search("area_name", "", "Areamaster", " and area_name = '" & txtname.Text.Trim & "'and area_cmpid = " & CmpId & " and area_Locationid = " & Locationid & " and area_yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("Area Name Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                            BLN = False
                        End If

                    ElseIf frmstring = "FORMTYPE" Then
                        dt = objclscommon.search("FORm_name", "", "formtype", " and FORm_name = '" & txtname.Text.Trim & "'and FORm_cmpid = " & CmpId & " and FORm_Locationid = " & Locationid & " and FORm_yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("FORm Name Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                            BLN = False
                        End If

                    ElseIf frmstring = "STATEMASTER" Then
                        dt = objclscommon.search("state_name", "", "STATEMASTER", " and state_name = '" & txtname.Text.Trim & "' and state_cmpid = " & CmpId & " and state_Locationid = " & Locationid & " and state_yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("State Name Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                            BLN = False
                        End If
                    ElseIf frmstring = "COUNTRYMASTER" Then
                        dt = objclscommon.search("country_name", "", "countrymaster", " and country_name = '" & txtname.Text.Trim & "' and country_cmpid = " & CmpId & " and country_Locationid = " & Locationid & " and country_yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("Country Name Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                            BLN = False
                        End If
                    ElseIf frmstring = "DOCUMENT" Then
                        dt = objclscommon.search(" DOC_name", "", "docmaster", " and doc_name = '" & txtname.Text.Trim & "' and doc_cmpid = " & CmpId & " and doc_yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("Document Name Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                            BLN = False
                        End If
                    End If
                    UCase(txtname.Text.Trim)
                End If
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If edit = True And txtname.Text.Trim <> "" Then
                Dim ALPARAVAL As New ArrayList
                Dim OBJ As New ClsCityMaster

                ALPARAVAL.Add(tempname)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)
                ALPARAVAL.Add(Userid)


                OBJ.alParaval = ALPARAVAL

                Dim DT As DataTable
                Dim tempmsg As Integer
                If frmstring = "AREAMASTER" Then
                    tempmsg = MsgBox("Delete Area Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then DT = OBJ.DELETEAREA() Else Exit Sub
                ElseIf frmstring = "CITYMASTER" Then
                    tempmsg = MsgBox("Delete City Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then DT = OBJ.DELETECITY() Else Exit Sub
                ElseIf frmstring = "GIFTMASTER" Then
                    tempmsg = MsgBox("Delete Gift Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then DT = OBJ.DELETEGIFT() Else Exit Sub
                ElseIf frmstring = "LOGINMASTER" Then
                    tempmsg = MsgBox("Delete Login Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then DT = OBJ.DELETLOGIN() Else Exit Sub
                ElseIf frmstring = "IDMASTER" Then
                    tempmsg = MsgBox("Delete ID Type Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then DT = OBJ.DELETID() Else Exit Sub
                ElseIf frmstring = "STATEMASTER" Then
                    tempmsg = MsgBox("Delete State Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then DT = OBJ.DELETESTATE() Else Exit Sub
                ElseIf frmstring = "COUNTRYMASTER" Then
                    tempmsg = MsgBox("Delete Country Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then DT = OBJ.DELETECOUNTRY() Else Exit Sub
                ElseIf frmstring = "DOCUMENT" Then
                    tempmsg = MsgBox("Delete Document Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then DT = OBJ.DELETEDOC() Else Exit Sub
                End If
                MsgBox(DT.Rows(0).Item(0))
                clear()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtremarks_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtremarks.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub txtremarks_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtremarks.Validating
        Try
            If frmstring = "STATEMASTER" And txtremarks.Text.Trim <> "" Then
                If (EDIT = False) Or (EDIT = True And txtremarks.Text.Trim <> TEMPSTATECODE) Then
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search("CAST(STATE_REMARK AS VARCHAR(5)) AS CODE", "", "STATEMASTER", " and CAST(STATE_REMARK AS VARCHAR(5)) = '" & txtremarks.Text.Trim & "' and state_yearid = " & YearId)
                    If DT.Rows.Count > 0 Then
                        MsgBox("State Code Already Exists", MsgBoxStyle.Critical, "TEXTRADE")
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class