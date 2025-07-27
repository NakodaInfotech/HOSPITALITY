
Imports BL

Public Class VehicleMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public edit As Boolean
    Public TEMPVEHICLENAME As String
    Dim TEMPVEHICLEID, TEMPGROUPOLDID As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If


            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            uppercase(CMBNAME)

            alParaval.Add(CMBTYPE.Text.Trim)
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim OBJVEHICLE As New ClsVehicleMaster
            OBJVEHICLE.alParaval = alParaval

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = OBJVEHICLE.SAVE()
                MsgBox("Details Added")
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPVEHICLEID)
                IntResult = OBJVEHICLE.update()
                MsgBox("Details Updated")
            End If


            clear()
            CMBNAME.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If CMBNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBNAME, "Fill Vehicle Name")
            bln = False
        End If

        'DONMT KEEP MANDATORY
        'If CMBTYPE.Text.Trim.Length = 0 Then
        '    EP.SetError(CMBTYPE, "Select Vehicle Type")
        '    bln = False
        'End If
        Return bln
    End Function

    Sub clear()
        CMBNAME.Text = ""
        CMBTYPE.Text = ""
        txtremarks.Clear()
        edit = False
    End Sub

    Private Sub VehicleMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
                Call cmdok_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNoCancel)
                If tempmsg = vbYes Then
                    If errorvalid() = True Then cmdok_Click(sender, e)
                ElseIf tempmsg = vbCancel Then
                    Exit Sub
                End If
                Me.Close()
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D Then       'for Delete
                Call cmddelete_Click(sender, e)
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.OemQuotes Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub VehicleMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'VEHICLE MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            FILLVEHICLETYPE(CMBTYPE, edit)
            FILLVEHICLE(CMBTYPE, edit, "")
            CMBNAME.Text = TEMPVEHICLENAME

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim OBJCMN As New ClsCommon
                Dim dttable As DataTable = OBJCMN.search(" VEHICLE_ID AS VEHICLEID, VEHICLEMASTER.VEHICLE_NAME AS NAME, ISNULL(VEHICLETYPEMASTER.VEHICLETYPE_NAME,'') AS TYPE, VEHICLEMASTER.VEHICLE_REMARKS AS REMARKS", "", " VEHICLEMASTER LEFT OUTER JOIN VEHICLETYPEMASTER ON VEHICLEMASTER.VEHICLE_TYPEID = VEHICLETYPEMASTER.VEHICLETYPE_ID AND VEHICLEMASTER.VEHICLE_CMPID = VEHICLETYPEMASTER.VEHICLETYPE_CMPID AND VEHICLEMASTER.VEHICLE_LOCATIONID = VEHICLETYPEMASTER.VEHICLETYPE_LOCATIONID AND VEHICLEMASTER.VEHICLE_YEARID = VEHICLETYPEMASTER.VEHICLETYPE_YEARID ", " and VEHICLE_name = '" & TEMPVEHICLENAME & "' and VEHICLE_cmpid = " & CmpId & " and VEHICLE_LOCATIONid = " & Locationid & " and VEHICLE_YEARid = " & YearId)
                If dttable.Rows.Count > 0 Then
                    TEMPVEHICLEID = dttable.Rows(0).Item("VEHICLEID")
                    CMBNAME.Text = dttable.Rows(0).Item("NAME")
                    CMBTYPE.Text = dttable.Rows(0).Item("TYPE")
                    txtremarks.Text = dttable.Rows(0).Item("REMARKS")
                End If
            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If edit = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim tempmsg As Integer = MsgBox("Delete Vehicle Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                If tempmsg = vbYes Then

                    Dim OBJVEHICLE As New ClsVehicleMaster
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(CMBNAME.Text.Trim)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Locationid)
                    ALPARAVAL.Add(YearId)
                    ALPARAVAL.Add(Userid)


                    OBJVEHICLE.alParaval = ALPARAVAL
                    Dim DT As DataTable = OBJVEHICLE.DELETE()

                    MsgBox(DT.Rows(0).Item(0))
                    clear()

                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTYPE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTYPE.Enter
        Try
            If CMBTYPE.Text.Trim = "" Then FILLVEHICLETYPE(CMBTYPE, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTYPE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTYPE.Validating
        Try
            If CMBTYPE.Text.Trim <> "" Then VEHICLETYPEvalidate(CMBTYPE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then FILLVEHICLE(CMBNAME, edit, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then
                uppercase(CMBNAME)
                Dim objclscommon As New ClsCommonMaster
                If (edit = False) Or (edit = True And LCase(CMBNAME.Text) <> LCase(TEMPVEHICLENAME)) Then
                    Dim dt As DataTable = objclscommon.search("VEHICLE_NAME", "", " VEHICLEMASTER", " AND VEHICLE_NAME = '" & CMBNAME.Text.Trim & "' AND VEHICLE_CMPID = " & CmpId & " AND VEHICLE_LOCATIONID = " & Locationid & " AND VEHICLE_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Vehicle Name Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
End Class