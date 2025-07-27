
Imports BL
Imports System.Windows.Forms

Public Class Taxmaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public edit As Boolean              'Used for edit
    Public tempname As String           'Used for edit name
    Public tempid As Integer            'Used for edit id

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Ep.Clear()
            If Not DELETEERRORVALID() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(UCase(TXTNAME.Text.Trim))
            alParaval.Add(txttax.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim objtax As New ClsTaxMaster
            objtax.alParaval = alParaval
            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objtax.save()
                MsgBox("Details Added")

            ElseIf edit = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(tempid)
                'objCity.alParaval = alParaval
                IntResult = objtax.Update()
                MsgBox("Details Updated")
            End If
            clear()
            TXTNAME.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function DELETEERRORVALID() As Boolean
        Try
            Dim BLN As Boolean = True
            Dim bln_4_case As Boolean = True
            Select Case tempname
                Case "S.T. 1.03%"
                    bln_4_case = False
                Case "S.T. 2.58%"
                    bln_4_case = False
                Case "S.T. 0.65%"
                    bln_4_case = False
                Case "S.T. 1.236%"
                    bln_4_case = False
            End Select

            If bln_4_case = False Then
                Ep.SetError(TXTNAME, "Build In Tax Cannot Delete Or Modify")
                BLN = False
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If TXTNAME.Text.Trim.Length = 0 Then
            Ep.SetError(TXTNAME, "Fill Name")
            bln = False
        End If

        Return bln
    End Function

    Sub clear()
        TXTNAME.Clear()
        txtremarks.Clear()
        txttax.Clear()
    End Sub

    Private Sub txtname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTNAME.Validating
        Try

            If (edit = False) Or (edit = True And LCase(tempname) <> LCase(TXTNAME.Text.Trim)) Then
                ' search duplication 
                If TXTNAME.Text.Trim <> Nothing Then
                    Dim objclscommon As New ClsCommonMaster
                    Dim dt As DataTable
                    dt = objclscommon.search("tax_name", "", " TAXMASTER ", " and TAX_name = '" & TXTNAME.Text.Trim & "' AND TAX_CMPID=" & CmpId & " and tax_LOCATIONid=" & Locationid & " and tax_YEARID=" & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Tax Name Already Exists", MsgBoxStyle.Critical, "")
                        TXTNAME.Focus()
                    End If
                    pcase(TXTNAME)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Taxmaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub Taxmaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'TAX MASTER'")
        USERADD = DTROW(0).Item(1)
        USEREDIT = DTROW(0).Item(2)
        USERVIEW = DTROW(0).Item(3)
        USERDELETE = DTROW(0).Item(4)

        Me.Text = "Tax Master"

        If edit = True Then

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim dttable As New DataTable
            Dim objCommon As New ClsCommonMaster
            dttable = objCommon.search(" tax_name,tax_tax, tax_remarks ", "", "TaxMaster", " and tax_id = " & tempid & " and tax_LOCATIONid=" & Locationid & " and tax_YEARID=" & YearId)

            If dttable.Rows.Count > 0 Then
                TXTNAME.Text = dttable.Rows(0).Item(0).ToString
                txttax.Text = dttable.Rows(0).Item(1).ToString
                txtremarks.Text = dttable.Rows(0).Item(2).ToString
            End If
        End If

    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If edit = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim tempmsg As Integer = MsgBox("Delete Tax Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                If tempmsg = vbYes Then

                    Dim OBJTAX As New ClsTaxMaster
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(TXTNAME.Text.Trim)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Locationid)
                    ALPARAVAL.Add(YearId)
                    ALPARAVAL.Add(Userid)


                    OBJTAX.alParaval = ALPARAVAL
                    Dim DT As DataTable = OBJTAX.DELETE()
                    MsgBox(DT.Rows(0).Item(0).ToString)

                    clear()

                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class