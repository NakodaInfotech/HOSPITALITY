
Imports BL

Public Class StationMaster

    Public FRMSTRING As String
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Public TEMPCODE As String        'Used for TEMPTRAINNO while edit mode
    Public TEMPSTATIONNAME As String        'Used for TEMPTRAINNO while edit mode
    Public TEMPSTATIONID As Integer         'Used for TEMPTRAINNO while edit mode
    Public edit As Boolean           'Used for edit

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub StationMaster_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
        If CMBSTATION.Text.Trim = "" Then FILLSTATION(CMBSTATION)
        If CMBCODE.Text.Trim = "" Then FILLSTATIONCODE(CMBCODE)
    End Sub

    Sub CLEAR()
        Try
            CMBSTATION.Text = ""
            CMBCODE.Text = ""
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function ERRORVALID() As Boolean
        Try
            Dim BLN As Boolean = True

            If CMBSTATION.Text.Trim = "" Then
                EP.SetError(CMBSTATION, "Enter Station Name")
                BLN = False
            End If

            If CMBCODE.Text.Trim = "" Then
                EP.SetError(CMBCODE, "Enter Code Number")
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

            If Not CHECKDUPLICATE(" and STATION_NAME = '" & CMBSTATION.Text.Trim & "' And STATION_CODE = '" & CMBCODE.Text.Trim & "'") Then
                MsgBox("Station Name / Code Already Exists", MsgBoxStyle.Critical)
                Exit Sub
            End If


            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(CMBSTATION.Text.Trim)
            alParaval.Add(CMBCODE.Text.Trim)


            Dim OBJTRAIN As New ClsStationMaster
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
                alParaval.Add(TEMPSTATIONID)
                IntResult = OBJTRAIN.UPDATE()
                MsgBox("Details Updated")
                edit = False
            End If

            CLEAR()
            CMBSTATION.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function CHECKDUPLICATE(ByVal WHERECLAUSE As String) As Boolean
        Try
            Dim BLN As Boolean = True
            If CMBSTATION.Text.Trim <> "" And CMBCODE.Text.Trim <> "" Then
                pcase(CMBSTATION)
                pcase(CMBCODE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If (edit = False) Or (edit = True And LCase(CMBSTATION.Text) <> LCase(TEMPCODE)) Then
                    dt = objclscommon.search("STATION_CODE AS CODE", "", "STATIONMASTER ", WHERECLAUSE)
                    If dt.Rows.Count > 0 Then BLN = False
                End If
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Try
            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If edit = True Then
                Dim ALPARAVAL As New ArrayList
                Dim OBJTRAIN As New ClsStationMaster
                Dim DT As DataTable

                ALPARAVAL.Add(TEMPSTATIONID)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)
                ALPARAVAL.Add(Userid)


                OBJTRAIN.alParaval = ALPARAVAL

                Dim tempmsg As Integer = MsgBox("Delete Station Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                If tempmsg = vbYes Then DT = OBJTRAIN.DELETE() Else Exit Sub
                MsgBox(DT.Rows(0).Item(0))
                CLEAR()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub StationMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'RAIL RESERVATION'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            fillcmb()
            CLEAR()

            If TEMPSTATIONNAME <> "" Then CMBSTATION.Text = TEMPSTATIONNAME
            If TEMPCODE <> "" Then CMBCODE.Text = TEMPCODE

            If edit = True Then
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim dttable As New DataTable
                Dim OBJTRAIN As New ClsCommon

                OBJTRAIN.alParaval.Add(TEMPSTATIONID)
                OBJTRAIN.alParaval.Add(CmpId)
                OBJTRAIN.alParaval.Add(Locationid)
                OBJTRAIN.alParaval.Add(YearId)

                dttable = OBJTRAIN.search(" STATION_NAME AS STATIONNAME, STATION_CODE AS CODE ", "", " STATIONMASTER ", " AND STATION_ID = " & TEMPSTATIONID)
                If dttable.Rows.Count > 0 Then
                    For Each ROW As DataRow In dttable.Rows
                        CMBSTATION.Text = ROW("STATIONNAME")
                        CMBCODE.Text = ROW("CODE")
                    Next
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSTATION_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBSTATION.Enter
        Try
            If CMBSTATION.Text.Trim = "" Then FILLSTATION(CMBSTATION)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCODE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBCODE.Enter
        Try
            If CMBCODE.Text.Trim = "" Then FILLSTATIONCODE(CMBCODE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSTATION_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSTATION.Validating
        Try
            If Not CHECKDUPLICATE(" and STATION_NAME = '" & CMBSTATION.Text.Trim & "' And STATION_CODE = '" & CMBCODE.Text.Trim & "'") Then
                MsgBox("Station Name Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                e.Cancel = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCODE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCODE.Validating
        Try
            If Not CHECKDUPLICATE(" and STATION_CODE = '" & CMBCODE.Text.Trim & "'") Then
                MsgBox("Station Code Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                e.Cancel = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class