
Imports BL

Public Class VehicleNoMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public edit As Boolean
    Public TEMPVEHICLENOID As Integer
    Dim TEMPVEHICLENO As String

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

            alParaval.Add(UCase(CMBNAME.Text.Trim))
            alParaval.Add(UCase(TXTVEHICLENO.Text.Trim))
            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            
            Dim OBJVEHICLE As New ClsVehicleNoMaster
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
                alParaval.Add(TEMPVEHICLENOID)
                IntResult = OBJVEHICLE.UPDATE()
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

        If TXTVEHICLENO.Text.Trim.Length = 0 Then
            EP.SetError(TXTVEHICLENO, "Enter Vehicle No")
            bln = False
        End If
        Return bln
    End Function

    Sub clear()
        CMBNAME.Text = ""
        TXTVEHICLENO.Clear()
        edit = False
    End Sub

    Private Sub VehicleNoMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNoCancel)
                If tempmsg = vbYes Then
                    If errorvalid() = True Then cmdok_Click(sender, e)
                ElseIf tempmsg = vbCancel Then
                    Exit Sub
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.OemQuotes Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub VehicleNoMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'VEHICLE MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            FILLVEHICLE(CMBNAME, edit, "")

            If edit = True Then
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim OBJCMN As New ClsCommon
                Dim dttable As DataTable = OBJCMN.search(" VEHICLENO_ID AS VEHICLENOID, VEHICLEMASTER.VEHICLE_NAME AS NAME, VEHICLENOMASTER.VEHICLENO_NO AS NO", "", " VEHICLENOMASTER INNER JOIN VEHICLEMASTER ON VEHICLENOMASTER.VEHICLENO_VEHICLEID = VEHICLEMASTER.VEHICLE_ID ", " and VEHICLENO_ID = " & TEMPVEHICLENOID)
                If dttable.Rows.Count > 0 Then
                    CMBNAME.Text = dttable.Rows(0).Item("NAME")
                    TEMPVEHICLENO = dttable.Rows(0).Item("NO")
                    TXTVEHICLENO.Text = dttable.Rows(0).Item("NO")
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

                Dim tempmsg As Integer = MsgBox("Delete Vehicle Entry Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                If tempmsg = vbYes Then

                    Dim OBJVEHICLE As New ClsVehicleNoMaster
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(TEMPVEHICLENOID)
                    

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

    Private Sub CMBNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then FILLVEHICLE(CMBNAME, edit, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then VEHICLEVALIDATE(CMBNAME, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTVEHICLENO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTVEHICLENO.Validating
        Try
            If TXTVEHICLENO.Text.Trim <> "" Then
                uppercase(TXTVEHICLENO)
                Dim OBJCMN As New ClsCommon
                If (edit = False) Or (edit = True And LCase(TXTVEHICLENO.Text.Trim) <> LCase(TEMPVEHICLENO)) Then
                    Dim dt As DataTable = OBJCMN.search("VEHICLENO_NO", "", " VEHICLENOMASTER", " AND VEHICLENO_NO = '" & TXTVEHICLENO.Text.Trim & "' AND VEHICLENO_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Vehicle No Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class