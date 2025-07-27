Imports BL
Imports System.Windows.Forms

Public Class MealConfigurator
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

            alParaval.Add(CMBPLAN.Text.Trim)
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
            If frmstring = "MEALMASTER" Then
                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    objLWZ.alParaval = alParaval
                    IntResult = objLWZ.saveMEALPLAN()
                    MsgBox("Meal Plan Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(tempid)
                    objLWZ.alParaval = alParaval
                    IntResult = objLWZ.updateMEALPLAN()
                    MsgBox("Meal Plan Updated")
                End If
            End If
            edit = False
            clear()
            CMBPLAN.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If CMBPLAN.Text.Trim.Length = 0 Then
            EP.SetError(CMBPLAN, "Fill plan")
            bln = False
        End If

        If cmbcurrency.Text.Trim.Length = 0 Then
            Ep.SetError(cmbcurrency, "Fill Currency")
            bln = False
        End If

        If Not VALIDATENAME() Then
            EP.SetError(CMBPLAN, "Name Already Exists")
            bln = False
        End If
        Return bln
    End Function

    Sub clear()
        CMBPLAN.Text = ""
        CMBPLAN.Enabled = True
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

    Private Sub MealConfigurator_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            Dim dttable As New DataTable
            Dim objCommon As New ClsCommonMaster

            If edit = True Then
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
            End If
            If frmstring = "MEALMASTER" Then
                If edit = True Then dttable = objCommon.search(" PLANMASTER.PLAN_NAME AS NAME, ISNULL(MEALCONGIGMASTER.MEAL_adult, 0) AS ADULT, ISNULL(MEALCONGIGMASTER.MEAL_child, 0) AS CHILD, ISNULL(MEALCONGIGMASTER.MEAL_infant, 0) AS INFANT, ISNULL(CURRENCYMASTER.CUR_CODE, '') AS CURRENCY", "", " MEALCONGIGMASTER LEFT OUTER JOIN CURRENCYMASTER ON MEALCONGIGMASTER.MEAL_yearid = CURRENCYMASTER.cur_yearid AND MEALCONGIGMASTER.MEAL_currencyid = CURRENCYMASTER.cur_id LEFT OUTER JOIN PLANMASTER ON MEALCONGIGMASTER.MEAL_yearid = PLANMASTER.PLAN_YEARID AND MEALCONGIGMASTER.MEAL_mealid = PLANMASTER.PLAN_ID", " and MEAL_id = " & tempid & " and MEAL_yearid = " & YearId)
                If dttable.Rows.Count > 0 Then
                    CMBPLAN.Text = dttable.Rows(0).Item(0).ToString
                    CMBPLAN.Enabled = False
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

    Private Sub MealConfigurator_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Function VALIDATENAME() As Boolean
        Try
            Dim BLN As Boolean = True
            If (edit = False) Or (edit = True And LCase(tempname) <> LCase(CMBPLAN.Text.Trim)) Then
                ' search duplication 
                If CMBPLAN.Text.Trim <> Nothing Then
                    Dim objclscommon As New ClsCommonMaster
                    Dim dt As DataTable
                    If frmstring = "MEALMASTER" Then
                        dt = objclscommon.search(" PLANMASTER.PLAN_NAME AS NAME", "", " MEALCONGIGMASTER LEFT OUTER JOIN PLANMASTER ON MEALCONGIGMASTER.MEAL_yearid = PLANMASTER.PLAN_YEARID AND MEALCONGIGMASTER.MEAL_mealid = PLANMASTER.PLAN_ID", " and PLAN_name = '" & CMBPLAN.Text.Trim & "' and MEAL_yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("Meal Name Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                            BLN = False
                        End If
                        pcase(CMBPLAN)
                    End If
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

            If edit = True And CMBPLAN.Text.Trim <> "" Then
                Dim ALPARAVAL As New ArrayList
                Dim OBJ As New ClsLawazim

                ALPARAVAL.Add(tempname)
                ALPARAVAL.Add(tempid)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)
                ALPARAVAL.Add(Userid)
                OBJ.alParaval = ALPARAVAL

                Dim DT As DataTable
                Dim tempmsg As Integer
                If frmstring = "MEALMASTER" Then
                    tempmsg = MsgBox("Delete Meal Plan Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then DT = OBJ.DELETEMEAL() Else Exit Sub
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

    Private Sub CMBPLAN_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBPLAN.Enter
        Try
            If CMBPLAN.Text.Trim = "" Then FILLPLAN(CMBPLAN, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPLAN_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPLAN.Validating
        Try
            If CMBPLAN.Text.Trim <> "" Then PLANvalidate(CMBPLAN, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class