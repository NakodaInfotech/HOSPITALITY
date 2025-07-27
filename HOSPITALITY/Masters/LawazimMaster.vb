Imports BL
Imports System.Windows.Forms

Public Class LawazimMaster
    Public frmstring As String          'Used for Area, City, State, Country Forms
    Public edit As Boolean              'Used for edit
    Public tempname As String           'Used for edit name
    Public tempCODE As String           'Used for edit name
    Public tempid As Integer            'Used for edit id
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
            alParaval.Add(txtadults.Text.Trim)
            alParaval.Add(txtchild.Text.Trim)
            alParaval.Add(txtinfant.Text.Trim)
            alParaval.Add(cmbcurrency.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim objLWZ As New ClsLawazim
            If frmstring = "LAWAZIMMASTER" Then
                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    objLWZ.alParaval = alParaval
                    IntResult = objLWZ.save()
                    MsgBox("Lawazim Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(tempid)
                    objLWZ.alParaval = alParaval
                    IntResult = objLWZ.update()
                    MsgBox("Lawazim Updated")
                End If
            ElseIf frmstring = "VISA" Then
                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    objLWZ.alParaval = alParaval
                    IntResult = objLWZ.savevisa()
                    MsgBox("Visa Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(tempid)
                    objLWZ.alParaval = alParaval
                    IntResult = objLWZ.updatevisa()
                    MsgBox("Visa Updated")
                End If
            ElseIf frmstring = "TAX" Then
                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    objLWZ.alParaval = alParaval
                    IntResult = objLWZ.savetax()
                    MsgBox("Country Of Tax Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(tempid)
                    objLWZ.alParaval = alParaval
                    IntResult = objLWZ.updateTAX()
                    MsgBox("Country Of Taxes Updated")
                End If
            ElseIf frmstring = "ADDSERVICE" Then
                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    objLWZ.alParaval = alParaval
                    IntResult = objLWZ.saveservice()
                    MsgBox("Additional Services Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(tempid)
                    objLWZ.alParaval = alParaval
                    IntResult = objLWZ.updateservice()
                    MsgBox("Additional Services Updated")
                End If
            ElseIf frmstring = "MISCEXP" Then
                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    objLWZ.alParaval = alParaval
                    IntResult = objLWZ.savemiscexp()
                    MsgBox("Misc. Exp Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(tempid)
                    objLWZ.alParaval = alParaval
                    IntResult = objLWZ.updatemiscexp()
                    MsgBox("Misc. Exp Updated")
                End If
            ElseIf frmstring = "TRANSPORT" Then
                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    objLWZ.alParaval = alParaval
                    IntResult = objLWZ.saveTRANSPORT()
                    MsgBox("Transport Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(tempid)
                    objLWZ.alParaval = alParaval
                    IntResult = objLWZ.updateTRANSPORT()
                    MsgBox("Transport Updated")
                End If
            End If
            edit = False
            clear()
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

        If cmbcurrency.Text.Trim.Length = 0 Then
            Ep.SetError(cmbcurrency, "Fill Currency")
            bln = False
        End If

        If Not VALIDATENAME() Then
            Ep.SetError(txtname, "Name Already Exists")
            bln = False
        End If
        Return bln
    End Function

    Sub clear()
        txtname.Clear()
        txtadults.Clear()
        txtchild.Clear()
        txtinfant.Clear()
        cmbcurrency.Text = ""
    End Sub

    Sub FillCombo()
        Try
            fillCurrency(cmbcurrency)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LawazimMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            FillCombo()

            If frmstring = "LAWAZIMMASTER" Then
                LBLNAME.Text = "Lawazim"
                Me.Text = "Lawazim Master"
            ElseIf frmstring = "VISA" Then
                LBLNAME.Text = "Visa"
                Me.Text = "Visa Master"
            ElseIf frmstring = "TAX" Then
                LBLNAME.Text = "Country Tax"
                Me.Text = "Taxes Of Country Master"
            ElseIf frmstring = "ADDSERVICE" Then
                LBLNAME.Text = "Service"
                Me.Text = "Service Master"
            ElseIf frmstring = "MISCEXP" Then
                LBLNAME.Text = "Misc Exp."
                Me.Text = "Misc Exp Master"
            ElseIf frmstring = "TRANSPORT" Then
                LBLNAME.Text = "Transport"
                Me.Text = "Transport Master"
            End If

            Dim dttable As New DataTable
            Dim objCommon As New ClsCommonMaster

            If edit = True Then
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
            End If
            If frmstring = "LAWAZIMMASTER" Then
                If edit = True Then dttable = objCommon.search(" ISNULL(LAWAZIMMASTER.LWZM_name, '') AS NAME, ISNULL(LAWAZIMMASTER.LWZM_adult, 0) AS ADULT, ISNULL(LAWAZIMMASTER.LWZM_child, 0) AS CHILD, ISNULL(LAWAZIMMASTER.LWZM_infant, 0) AS INFANT, ISNULL(CURRENCYMASTER.CUR_CODE, '') AS CURRENCY", "", " LAWAZIMMASTER LEFT OUTER JOIN CURRENCYMASTER ON LAWAZIMMASTER.LWZM_yearid = CURRENCYMASTER.cur_yearid AND LAWAZIMMASTER.LWZM_currencyid = CURRENCYMASTER.cur_id", " and LWZM_id = " & tempid & " and LWZM_cmpid = " & CmpId & " and LWZM_Locationid = " & Locationid & " and LWZM_yearid = " & YearId)
                If dttable.Rows.Count > 0 Then
                    txtname.Text = dttable.Rows(0).Item(0).ToString
                    txtadults.Text = dttable.Rows(0).Item(1).ToString
                    txtchild.Text = dttable.Rows(0).Item(2).ToString
                    txtinfant.Text = dttable.Rows(0).Item(3).ToString
                    cmbcurrency.Text = dttable.Rows(0).Item(4).ToString
                End If

            ElseIf frmstring = "VISA" Then
                If edit = True Then dttable = objCommon.search(" ISNULL(VISAMASTER.VISA_name, '') AS NAME, ISNULL(VISAMASTER.VISA_adult, 0) AS ADULT, ISNULL(VISAMASTER.VISA_child, 0) AS CHILD, ISNULL(VISAMASTER.VISA_infant, 0) AS INFANT, ISNULL(CURRENCYMASTER.CUR_CODE, '') AS CURRENCY", "", " VISAMASTER LEFT OUTER JOIN CURRENCYMASTER ON VISAMASTER.VISA_yearid = CURRENCYMASTER.cur_yearid AND VISAMASTER.VISA_currencyid = CURRENCYMASTER.cur_id", " and VISAMASTER.VISA_id = " & tempid & " and VISAMASTER.VISA_cmpid = " & CmpId & " and VISAMASTER.VISA_Locationid = " & Locationid & " and VISAMASTER.VISA_yearid = " & YearId)
                If dttable.Rows.Count > 0 Then
                    txtname.Text = dttable.Rows(0).Item(0).ToString
                    txtadults.Text = dttable.Rows(0).Item(1).ToString
                    txtchild.Text = dttable.Rows(0).Item(2).ToString
                    txtinfant.Text = dttable.Rows(0).Item(3).ToString
                    cmbcurrency.Text = dttable.Rows(0).Item(4).ToString
                End If

            ElseIf frmstring = "TAX" Then
                If edit = True Then dttable = objCommon.search(" ISNULL(COUNTRYTAXMASTER.TAX_name, '') AS NAME, ISNULL(COUNTRYTAXMASTER.TAX_adult, 0) AS ADULT, ISNULL(COUNTRYTAXMASTER.TAX_child, 0) AS CHILD, ISNULL(COUNTRYTAXMASTER.TAX_infant, 0) AS INFANT, ISNULL(CURRENCYMASTER.CUR_CODE, '') AS CURRENCY", "", " COUNTRYTAXMASTER LEFT OUTER JOIN CURRENCYMASTER ON COUNTRYTAXMASTER.TAX_yearid = CURRENCYMASTER.cur_yearid AND COUNTRYTAXMASTER.TAX_currencyid = CURRENCYMASTER.cur_id", " and COUNTRYTAXMASTER.TAX_id = " & tempid & " and COUNTRYTAXMASTER.TAX_cmpid = " & CmpId & " and COUNTRYTAXMASTER.TAX_Locationid = " & Locationid & " and COUNTRYTAXMASTER.TAX_yearid = " & YearId)
                If dttable.Rows.Count > 0 Then
                    txtname.Text = dttable.Rows(0).Item(0).ToString
                    txtadults.Text = dttable.Rows(0).Item(1).ToString
                    txtchild.Text = dttable.Rows(0).Item(2).ToString
                    txtinfant.Text = dttable.Rows(0).Item(3).ToString
                    cmbcurrency.Text = dttable.Rows(0).Item(4).ToString
                End If
            ElseIf frmstring = "MISCEXP" Then
                If edit = True Then dttable = objCommon.search(" ISNULL(MISCEXPMASTER.MISC_name, '') AS NAME, ISNULL(MISCEXPMASTER.MISC_adult, 0) AS ADULT, ISNULL(MISCEXPMASTER.MISC_child, 0) AS CHILD, ISNULL(MISCEXPMASTER.MISC_infant, 0) AS INFANT, ISNULL(CURRENCYMASTER.CUR_CODE, '') AS CURRENCY", "", " MISCEXPMASTER LEFT OUTER JOIN CURRENCYMASTER ON MISCEXPMASTER.MISC_yearid = CURRENCYMASTER.cur_yearid AND MISCEXPMASTER.MISC_currencyid = CURRENCYMASTER.cur_id", " and MISCEXPMASTER.MISC_id = " & tempid & " and MISCEXPMASTER.MISC_yearid = " & YearId)
                If dttable.Rows.Count > 0 Then
                    txtname.Text = dttable.Rows(0).Item(0).ToString
                    txtadults.Text = dttable.Rows(0).Item(1).ToString
                    txtchild.Text = dttable.Rows(0).Item(2).ToString
                    txtinfant.Text = dttable.Rows(0).Item(3).ToString
                    cmbcurrency.Text = dttable.Rows(0).Item(4).ToString
                End If
            ElseIf frmstring = "ADDSERVICE" Then
                If edit = True Then dttable = objCommon.search(" ISNULL(SERVICEMASTER.SERVICE_name, '') AS NAME, ISNULL(SERVICEMASTER.SERVICE_adult, 0) AS ADULT, ISNULL(SERVICEMASTER.SERVICE_child, 0) AS CHILD, ISNULL(SERVICEMASTER.SERVICE_infant, 0) AS INFANT, ISNULL(CURRENCYMASTER.CUR_CODE, '') AS CURRENCY", "", " SERVICEMASTER LEFT OUTER JOIN CURRENCYMASTER ON SERVICEMASTER.SERVICE_yearid = CURRENCYMASTER.cur_yearid AND SERVICEMASTER.SERVICE_currencyid = CURRENCYMASTER.cur_id", " and SERVICEMASTER.SERVICE_id = " & tempid & " and SERVICEMASTER.SERVICE_yearid = " & YearId)
                If dttable.Rows.Count > 0 Then
                    txtname.Text = dttable.Rows(0).Item(0).ToString
                    txtadults.Text = dttable.Rows(0).Item(1).ToString
                    txtchild.Text = dttable.Rows(0).Item(2).ToString
                    txtinfant.Text = dttable.Rows(0).Item(3).ToString
                    cmbcurrency.Text = dttable.Rows(0).Item(4).ToString
                End If
            ElseIf frmstring = "TRANSPORT" Then
                If edit = True Then dttable = objCommon.search(" ISNULL(TRANSPORTMASTER.TRANS_name, '') AS NAME, ISNULL(TRANSPORTMASTER.TRANS_adult, 0) AS ADULT, ISNULL(TRANSPORTMASTER.TRANS_child, 0) AS CHILD, ISNULL(TRANSPORTMASTER.TRANS_infant, 0) AS INFANT, ISNULL(CURRENCYMASTER.CUR_CODE, '') AS CURRENCY", "", " TRANSPORTMASTER LEFT OUTER JOIN CURRENCYMASTER ON TRANSPORTMASTER.TRANS_yearid = CURRENCYMASTER.cur_yearid AND TRANSPORTMASTER.TRANS_currencyid = CURRENCYMASTER.cur_id", " and TRANSPORTMASTER.TRANS_id = " & tempid & " and TRANSPORTMASTER.TRANS_yearid = " & YearId)
                If dttable.Rows.Count > 0 Then
                    txtname.Text = dttable.Rows(0).Item(0).ToString
                    txtadults.Text = dttable.Rows(0).Item(1).ToString
                    txtchild.Text = dttable.Rows(0).Item(2).ToString
                    txtinfant.Text = dttable.Rows(0).Item(3).ToString
                    cmbcurrency.Text = dttable.Rows(0).Item(4).ToString
                End If
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub LawazimMaster_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Function VALIDATENAME() As Boolean
        Try
            Dim BLN As Boolean = True
            If (edit = False) Or (edit = True And LCase(tempname) <> LCase(txtname.Text.Trim)) Then
                ' search duplication 
                If txtname.Text.Trim <> Nothing Then
                    Dim objclscommon As New ClsCommonMaster
                    Dim dt As DataTable
                    If frmstring = "LAWAZIMMASTER" Then
                        dt = objclscommon.search("LWZM_name", "", " LAWAZIMMASTER", " and LWZM_name = '" & txtname.Text.Trim & "' and LWZM_cmpid = " & CmpId & " and LWZM_Locationid = " & Locationid & " and LWZM_yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("Lawazim Name Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                            BLN = False
                        End If
                    ElseIf frmstring = "VISA" Then
                        dt = objclscommon.search(" VISA_name", "", " VISAMASTER", " and VISA_name = '" & txtname.Text.Trim & "' and VISA_cmpid = " & CmpId & " and VISA_Locationid = " & Locationid & " and VISA_yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("Visa Name Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                            BLN = False
                        End If
                    ElseIf frmstring = "TAX" Then
                        dt = objclscommon.search(" TAX_name", "", " COUNTRYTAXMASTER", " and TAX_name = '" & txtname.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("Name Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                            BLN = False
                        End If
                    ElseIf frmstring = "ADDSERVICE" Then
                        dt = objclscommon.search(" SERVICE_name", "", " SERVICEMASTER", " and SERVICE_name = '" & txtname.Text.Trim & "' and SERVICE_cmpid = " & CmpId & " and SERVICE_Locationid = " & Locationid & " and SERVICE_yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("SERVICE Name Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                            BLN = False
                        End If
                    ElseIf frmstring = "MISCEXP" Then
                        dt = objclscommon.search(" MISC_name", "", " MISCEXPMASTER", " and MISC_name = '" & txtname.Text.Trim & "' and MISC_yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox(" Name Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                            BLN = False
                        End If
                    ElseIf frmstring = "TRANSPORT" Then
                        dt = objclscommon.search(" TRANS_name", "", " TRANSPORTMASTER", " and TRANS_name = '" & txtname.Text.Trim & "' and TRANS_yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox(" Name Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
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

    Private Sub txtname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtname.Validating
        Try
            If Not VALIDATENAME() Then e.Cancel = True
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If edit = True And txtname.Text.Trim <> "" Then
                Dim ALPARAVAL As New ArrayList
                Dim OBJ As New ClsLawazim

                ALPARAVAL.Add(tempname)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)
                ALPARAVAL.Add(Userid)
                OBJ.alParaval = ALPARAVAL

                Dim DT As DataTable
                Dim tempmsg As Integer
                If frmstring = "LAWAZIMMASTER" Then
                    tempmsg = MsgBox("Delete Lawazim Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then DT = OBJ.DELETE() Else Exit Sub
                    MsgBox(DT.Rows(0).Item(0))
                ElseIf frmstring = "VISA" Then
                    tempmsg = MsgBox("Delete Visa Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then DT = OBJ.DELETEVISA() Else Exit Sub
                    MsgBox(DT.Rows(0).Item(0))
                ElseIf frmstring = "TAX" Then
                    tempmsg = MsgBox("Delete Visa Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then DT = OBJ.DELETETAX() Else Exit Sub
                    MsgBox(DT.Rows(0).Item(0))
                ElseIf frmstring = "ADDSERVICE" Then
                    tempmsg = MsgBox("Delete Visa Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then DT = OBJ.DELETESERVICE() Else Exit Sub
                    MsgBox(DT.Rows(0).Item(0))
                ElseIf frmstring = "MISCEXP" Then
                    tempmsg = MsgBox("Delete Visa Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then DT = OBJ.DELETEMISCEXP() Else Exit Sub
                    MsgBox(DT.Rows(0).Item(0))
                ElseIf frmstring = "TRANSPORT" Then
                    tempmsg = MsgBox("Delete Transport Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then DT = OBJ.DELETETRANSPORT() Else Exit Sub
                    MsgBox(DT.Rows(0).Item(0))
                End If
            End If
            clear()
            edit = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcurrency_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcurrency.Enter
        Try
            If cmbcurrency.Text = "" Then fillCurrency(cmbcurrency)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcurrency_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcurrency.Validating
        If cmbcurrency.Text <> "" Then CURRENCYvalidate(cmbcurrency, e, Me)
    End Sub

    Private Sub txtadults_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtadults.KeyPress
        numdotkeypress(e, txtadults, Me)
    End Sub

    Private Sub txtchild_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtchild.KeyPress
        numdotkeypress(e, txtchild, Me)
    End Sub

    Private Sub txtinfant_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtinfant.KeyPress
        numdotkeypress(e, txtinfant, Me)
    End Sub
End Class