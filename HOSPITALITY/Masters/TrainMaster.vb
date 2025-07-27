
Imports BL

Public Class TrainMaster

    Public FRMSTRING As String
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Public TEMPTRAINNO As String        'Used for TEMPTRAINNO while edit mode
    Public TEMPTRAINNAME As String        'Used for TEMPTRAINNO while edit mode
    Public TEMPTRAINID As Integer         'Used for TEMPTRAINNO while edit mode
    Public edit As Boolean           'Used for edit

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub TrainMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
                Call cmdok_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If ERRORVALID() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D Then       'for Delete
                Call cmddelete_Click(sender, e)
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillcmb()
        If CMBTRAINNAME.Text.Trim = "" Then FILLTRAINNAME(CMBTRAINNAME)
        If CMBTRAINNO.Text.Trim = "" Then FILLTRAINNO(CMBTRAINNO)
    End Sub

    Sub CLEAR()
        Try
            CMBTRAINNAME.Text = ""
            CMBTRAINNO.Text = ""
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function ERRORVALID() As Boolean
        Try
            Dim BLN As Boolean = True

            If CMBTRAINNAME.Text.Trim = "" Then
                EP.SetError(CMBTRAINNAME, "Enter Train Name")
                BLN = False
            End If

            If CMBTRAINNO.Text.Trim = "" Then
                EP.SetError(CMBTRAINNO, "Enter Train Number")
                BLN = False
            End If

            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            If Not CHECKDUPLICATE(" and TRAIN_NAME = '" & CMBTRAINNAME.Text.Trim & "' And TRAIN_NO = '" & CMBTRAINNO.Text.Trim & "'") Then
                MsgBox("Train Name / No Already Exists", MsgBoxStyle.Critical)
                Exit Sub
            End If


            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(CMBTRAINNAME.Text.Trim)
            alParaval.Add(CMBTRAINNO.Text.Trim)


            Dim OBJTRAIN As New ClsTrainMaster
            OBJTRAIN.alParaval = alParaval

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = OBJTRAIN.SAVE()
                MsgBox("Details Added")

            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPTRAINID)
                IntResult = OBJTRAIN.UPDATE()
                MsgBox("Details Updated")
                edit = False
            End If

            CLEAR()
            CMBTRAINNAME.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Try
            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If edit = True Then
                Dim ALPARAVAL As New ArrayList
                Dim OBJTRAIN As New ClsTrainMaster
                Dim DT As DataTable

                ALPARAVAL.Add(TEMPTRAINID)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                OBJTRAIN.alParaval = ALPARAVAL

                Dim tempmsg As Integer = MsgBox("Delete Train Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                If tempmsg = vbYes Then DT = OBJTRAIN.DELETE() Else Exit Sub
                MsgBox(DT.Rows(0).Item(0))
                CLEAR()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TrainMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'RAIL RESERVATION'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            fillcmb()
            CLEAR()

            If TEMPTRAINNAME <> "" Then CMBTRAINNAME.Text = TEMPTRAINNAME
            If TEMPTRAINNO <> "" Then CMBTRAINNO.Text = TEMPTRAINNO

            If edit = True Then
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim dttable As New DataTable
                Dim OBJTRAIN As New ClsCommon

                OBJTRAIN.alParaval.Add(TEMPTRAINID)
                OBJTRAIN.alParaval.Add(CmpId)
                OBJTRAIN.alParaval.Add(Locationid)
                OBJTRAIN.alParaval.Add(YearId)

                dttable = OBJTRAIN.search(" TRAIN_NAME AS TRAINNAME, TRAIN_NO AS TRAINNO ", "", " TRAINMASTER ", " AND TRAIN_ID = " & TEMPTRAINID)
                If dttable.Rows.Count > 0 Then
                    For Each ROW As DataRow In dttable.Rows
                        CMBTRAINNAME.Text = ROW("TRAINNAME")
                        CMBTRAINNO.Text = ROW("TRAINNO")
                    Next
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTRAINNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTRAINNAME.Enter
        Try
            If CMBTRAINNAME.Text.Trim = "" Then FILLTRAINNAME(CMBTRAINNAME)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTRAINNO_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTRAINNO.Enter
        Try
            If CMBTRAINNO.Text.Trim = "" Then FILLTRAINNO(CMBTRAINNO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function CHECKDUPLICATE(ByVal WHERECLAUSE As String) As Boolean
        Try
            Dim BLN As Boolean = True
            If CMBTRAINNAME.Text.Trim <> "" And CMBTRAINNO.Text.Trim <> "" Then
                pcase(CMBTRAINNAME)
                pcase(CMBTRAINNO)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If (edit = False) Or (edit = True And LCase(CMBTRAINNO.Text) <> LCase(TEMPTRAINNO)) Then
                    dt = objclscommon.search("TRAIN_NO AS TRAINNO", "", "TRAINMASTER ", WHERECLAUSE)
                    If dt.Rows.Count > 0 Then BLN = False
                End If
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub CMBTRAINNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTRAINNAME.Validating
        Try
            If Not CHECKDUPLICATE(" and TRAIN_NAME = '" & CMBTRAINNAME.Text.Trim & "' And TRAIN_NO = '" & CMBTRAINNO.Text.Trim & "'") Then
                MsgBox("Train Name Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                e.Cancel = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTRAINNO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTRAINNO.Validating
        Try
            If Not CHECKDUPLICATE(" and TRAIN_NO = '" & CMBTRAINNO.Text.Trim & "'") Then
                MsgBox("Train No Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                e.Cancel = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class