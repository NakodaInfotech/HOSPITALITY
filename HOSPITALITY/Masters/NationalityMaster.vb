Imports BL
Imports System.Windows.Forms

Public Class NationalityMaster
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
            alParaval.Add(txtabbr.Text.Trim)
            alParaval.Add(txtcode.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim objLWZ As New ClsLawazim
            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                objLWZ.alParaval = alParaval
                IntResult = objLWZ.SAVENATIONALITY()
                MsgBox("Nationality Added")
            ElseIf edit = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(tempid)
                objLWZ.alParaval = alParaval
                IntResult = objLWZ.NATIONALITYUPDATE()
                MsgBox("Nationality Updated")
            End If

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

        If txtcode.Text.Trim.Length = 0 Then
            Ep.SetError(txtcode, "Fill Code")
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
        txtabbr.Clear()
        txtcode.Clear()
    End Sub

    Private Sub NationalityMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            txtname.Text = tempname
            If edit = True Then dttable = objCommon.search(" ISNULL(NAT_NAME, '') AS NAME, ISNULL(NAT_ABBR,'') AS ABBR, ISNULL(NAT_CODE,'') AS CODE ", "", " NATIONALITYMASTER ", " and NAT_id = " & tempid & " and NAT_yearid = " & YearId)
            If dttable.Rows.Count > 0 Then
                txtname.Text = dttable.Rows(0).Item(0).ToString
                txtabbr.Text = dttable.Rows(0).Item(1).ToString
                txtcode.Text = dttable.Rows(0).Item(2).ToString
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub NationalityMaster_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
            Call cmdok_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
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
                    dt = objclscommon.search("NAT_name", "", " NATIONALITYMASTER", " and NAT_name = '" & txtname.Text.Trim & "' and NAT_yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Nationality Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                        BLN = False
                    End If
                    UCase(txtname.Text.Trim)
                End If
            End If

            If (edit = False) Or (edit = True And LCase(tempCODE) <> LCase(txtcode.Text.Trim)) Then
                ' search duplication 
                If txtcode.Text.Trim <> Nothing Then
                    Dim objclscommon As New ClsCommonMaster
                    Dim dt As DataTable
                    dt = objclscommon.search("NAT_code", "", " NATIONALITYMASTER", " and NAT_code = '" & txtcode.Text.Trim & "' and NAT_yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Nationality Code Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                        BLN = False
                    End If
                    pcase(txtname)
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
                tempmsg = MsgBox("Delete Currency Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                If tempmsg = vbYes Then DT = OBJ.NATIONALITYDELETE() Else Exit Sub
                MsgBox(DT.Rows(0).Item(0))
                clear()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtcode_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtcode.Validating
        Try
            If Not VALIDATENAME() Then e.Cancel = True
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
End Class