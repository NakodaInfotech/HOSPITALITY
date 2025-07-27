Imports BL

Public Class UnitMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public frmString As String      'Used for all Unit form
    Public Tempname As String       'Used for edit name
    Public Tempabbr As String       'Used for validating abbr
    Public tempid As Integer        'Used for id
    Public edit As Boolean          'Used for edit

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If txtname.Text.Trim.Length = 0 Then
            EP.SetError(txtname, "Fill Name")
            bln = False
        End If

        If txtabbr.Text.Trim.Length = 0 Then
            EP.SetError(txtabbr, "Fill Abbr")
            bln = False
        End If
        Return bln
    End Function

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If


            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(txtname.Text.Trim)
            alParaval.Add(txtabbr.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            If frmString = "UNIT" Then

                Dim objclsUnitMaster As New ClsUnitMaster
                objclsUnitMaster.alParaval = alParaval
                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = objclsUnitMaster.save()
                    MsgBox("Details Added")

                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(tempid)
                    IntResult = objclsUnitMaster.update()
                    MsgBox("Details Updated")
                End If

            ElseIf frmString = "TAXMASTER" Then

                Dim objclstaxmaster As New ClsTaxMaster
                objclstaxmaster.alParaval = alParaval
                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = objclstaxmaster.save()
                    MsgBox("Details Added")

                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(tempid)
                    IntResult = objclstaxmaster.Update()
                    MsgBox("Details Updated")
                End If

            End If
            clear()
            txtname.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub clear()
        txtname.Clear()
        txtabbr.Clear()
        txtremarks.Clear()
    End Sub

    Private Sub cmbpackingunit_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbpackingunit.Enter
        Try
            If cmbpackingunit.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("packingunit_name", "", "PackingUnitMaster", " and Packingunit_cmpid = " & CmpId & " and Packingunit_LOCATIONid = " & Locationid & " and Packingunit_YEARid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "packingunit_name"
                    cmbpackingunit.DataSource = dt
                    cmbpackingunit.DisplayMember = "packingunit_name"
                    cmbpackingunit.Text = ""
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtname.Validating
        Try
            'for search
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable

            If (edit = False) Or (edit = True And LCase(Tempname) <> LCase(txtname.Text.Trim)) Then
                If frmString = "UNIT" Then
                    dt = objclscommon.search("unit_name", "", "unitMaster", " and unit_name = '" & txtname.Text.Trim & "' And Unit_cmpid = " & CmpId & " and unit_LOCATIONid = " & Locationid & " and unit_YEARid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Unit Name Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                        e.Cancel = True
                    End If
                ElseIf frmString = "TAXMASTER" Then
                    dt = objclscommon.search("tax_name", "", "TaxMaster", " and tax_name = '" & txtname.Text.Trim & "' And tax_cmpid = " & CmpId & " and tax_LOCATIONid = " & Locationid & " and tax_YEARid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Tax Name Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                        e.Cancel = True
                    End If

                ElseIf frmString = "PACKINGUNIT" Then
                    dt = objclscommon.search("packingunit_name", "", "packingunitMaster", " and packingunit_name = '" & txtname.Text.Trim & "' and PackingUnit_cmpid = " & CmpId & " and Packingunit_LOCATIONid = " & Locationid & " and Packingunit_YEARid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Packing Unit Name Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                        e.Cancel = True
                    End If
                ElseIf frmString = "SUBPACKINGUNIT" Then
                    dt = objclscommon.search("subpackingunit_name", "", "subpackingunitMaster", " and subpackingunit_name = '" & txtname.Text.Trim & "' and SubPackingUnit_cmpid = " & CmpId & " and SubPackingunit_LOCATIONid = " & Locationid & " and SubPackingunit_YEARid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Sub Packing Unit Name Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                        e.Cancel = True
                    End If
                End If
            End If
            pcase(txtname)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UnitMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'fOR sAVE
            Call cmdok_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then               'FOR EXIT
            If errorvalid() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Keys.Oemcomma Then
            'e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub UnitMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim dttable As New DataTable
            Dim objCommon As New ClsCommonMaster

            Dim DTROW() As DataRow
            If frmString = "UNIT" Then
                DTROW = USERRIGHTS.Select("FormName = 'UNIT MASTER'")
            ElseIf frmString = "TAXMASTER" Then
                DTROW = USERRIGHTS.Select("FormName = 'TAX MASTER'")
            End If
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If frmString = "UNIT" Then

                Me.Text = "Unit Master"
                lblgroup.Text = "Unit"
                lblabbr.Text = "Abbr."
                lbl.Text = "Enter Unit " & vbNewLine & "(e.g.  Mtrs,Gram..., etc. )"
                If edit = True Then dttable = objCommon.search(" unit_name, unit_abbr, unit_remarks", "", "UnitMaster", " and unit_id = " & tempid & " and unit_cmpid = " & CmpId & " and unit_LOCATIONid = " & Locationid & " and unit_YEARid = " & YearId)

            ElseIf frmString = "TAXMASTER" Then

                Me.Text = "Tax Master"
                lblgroup.Text = "Tax"
                lblabbr.Text = "Abbr."
                lbl.Text = "Enter Tax " & vbNewLine & "(e.g.  VAT,CST..., etc. )"
                If edit = True Then dttable = objCommon.search(" tax_name, tax_abbr, tax_remarks", "", "TaxMaster", " and tax_id = " & tempid & " and tax_cmpid = " & CmpId & " and tax_LOCATIONid = " & Locationid & " and tax_YEARid = " & YearId)

            ElseIf frmString = "PACKINGUNIT" Then

                Me.Text = "Packing Unit Master"
                lblgroup.Text = "Packing Unit"
                lbl.Text = "Enter Unit " & vbNewLine & "(e.g.  Mtrs,Gram..., etc. )"
                If edit = True Then dttable = objCommon.search(" packingunit_name, packingunit_abbr, packingunit_remarks", "", "PackingUnitMaster", " and packingunit_id = " & tempid & " and Packingunit_cmpid = " & CmpId & " and Packingunit_LOCATIONid = " & Locationid & " and Packingunit_YEARid = " & YearId)

            ElseIf frmString = "SUBPACKINGUNIT" Then

                Me.Text = "Sub Packing Unit Master"
                lblgroup.Text = "Sub Packing Unit"
                lblcmb.Visible = True
                cmbpackingunit.Visible = True
                lbl.Text = "Enter Unit " & vbNewLine & "(e.g.  Mtrs,Gram..., etc. )"
                If edit = True Then dttable = objCommon.search(" subpackingunit_name, subpackingunit_abbr, subpackingunit_remarks", "", "subpackingunitMaster", " and subpackingunit_id = " & tempid & " and SubPackingunit_cmpid = " & CmpId & " and SubPackingunit_LOCATIONid = " & Locationid & " and SubPackingunit_YEARid = " & YearId)

            End If

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If dttable.Rows.Count > 0 Then
                    txtname.Text = dttable.Rows(0).Item(0).ToString
                    txtabbr.Text = dttable.Rows(0).Item(1).ToString
                    txtremarks.Text = dttable.Rows(0).Item(2).ToString
                    Tempabbr = txtabbr.Text.Trim
                End If
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtabbr_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtabbr.KeyPress
        If frmString = "TAXMASTER" Then
            numdot(e, txtabbr, Me)
        End If
    End Sub

    Private Sub txtabbr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtabbr.Validating
        Try
            'for search
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable

            If (edit = False) Or (edit = True And LCase(Tempabbr) <> LCase(txtabbr.Text.Trim)) Then
                If frmString = "UNIT" Then
                    dt = objclscommon.search("unit_abbr", "", "unitMaster", " and unit_abbr = '" & txtabbr.Text.Trim & "' And Unit_cmpid = " & CmpId & " and unit_LOCATIONid = " & Locationid & " and unit_YEARid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Unit Abbr Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                        e.Cancel = True
                    End If
                ElseIf frmString = "TAXMASTER" Then
                    dt = objclscommon.search("tax_abbr", "", "TaxMaster", " and tax_abbr = '" & txtabbr.Text.Trim & "' And tax_cmpid = " & CmpId & " and tax_LOCATIONid = " & Locationid & " and tax_YEARid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Tax Abbr Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                        e.Cancel = True
                    End If

                ElseIf frmString = "PACKINGUNIT" Then
                    dt = objclscommon.search("packingunit_abbr", "", "packingunitMaster", " and packingunit_abbr = '" & txtabbr.Text.Trim & "' and PackingUnit_cmpid = " & CmpId & " and Packingunit_LOCATIONid = " & Locationid & " and Packingunit_YEARid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Packing Unit Abbr Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                        e.Cancel = True
                    End If
                ElseIf frmString = "SUBPACKINGUNIT" Then
                    dt = objclscommon.search("subpackingunit_abbr", "", "subpackingunitMaster", " and subpackingunit_abbr = '" & txtabbr.Text.Trim & "' and SubPackingUnit_cmpid = " & CmpId & " and SubPackingunit_LOCATIONid = " & Locationid & " and SubPackingunit_YEARid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Sub Packing Unit Abbr Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                        e.Cancel = True
                    End If
                End If
            End If
            pcase(txtname)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If edit = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim tempmsg As Integer = MsgBox("Delete Unit Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                If tempmsg = vbYes Then

                    Dim OBJUNIT As New ClsUnitMaster
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(txtname.Text.Trim)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Locationid)
                    ALPARAVAL.Add(YearId)

                    OBJUNIT.alParaval = ALPARAVAL
                    Dim DT As DataTable = OBJUNIT.DELETE()
                    MsgBox(DT.Rows(0).Item(0).ToString)

                    clear()

                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class