
Imports BL

Public Class VehicleRateList

    Public FRMSTRING As String = ""
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim GRIDDOUBLECLICK As Boolean

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        'CHECK DUPLICATION
        'WHETHER VEHICLE FOR THIS LEDGER OR NOT
        '******** FROM PURITY *************
        Dim OBJCMN As New ClsCommon
        Dim DT As New DataTable
        If FRMSTRING = "PURRATE" Then
            DT = OBJCMN.search(" VEHICLERATEPUR.VEHICLERATEPUR_ID AS ID", "", " VEHICLERATEPUR INNER JOIN VEHICLEMASTER ON VEHICLERATEPUR.VEHICLERATEPUR_VEHICLEID = VEHICLE_ID LEFT OUTER JOIN LEDGERS ON VEHICLERATEPUR.VEHICLERATEPUR_LEDGERID = LEDGERS.ACC_ID LEFT OUTER JOIN CITYMASTER ON VEHICLERATEPUR.VEHICLERATEPUR_CITYID = CITYMASTER.CITY_ID ", " AND VEHICLE_NAME = '" & CMBVEHICLENAME.Text.Trim & "' AND ISNULL(LEDGERS.ACC_CMPNAME,'') = '" & CMBNAME.Text.Trim & "' AND ISNULL(CITYMASTER.CITY_NAME,'') = '" & CMBCITY.Text.Trim & "' AND VEHICLERATEPUR_TYPE = '" & CMBTYPE.Text.Trim & "' AND VEHICLERATEPUR_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                If GRIDDOUBLECLICK = False Or (GRIDDOUBLECLICK = True And Val(TXTNO.Text) <> Val(DT.Rows(0).Item(0))) Then
                    EP.SetError(TXTKMRATE, "Vehicle's Rate of Selected Type Already Added below")
                    bln = False
                End If
            End If
        Else
            DT = OBJCMN.search(" VEHICLERATE.VEHICLERATE_ID AS ID", "", " VEHICLERATE INNER JOIN VEHICLEMASTER ON VEHICLERATE.VEHICLERATE_VEHICLEID = VEHICLE_ID LEFT OUTER JOIN LEDGERS ON VEHICLERATE.VEHICLERATE_LEDGERID = LEDGERS.ACC_ID LEFT OUTER JOIN CITYMASTER ON VEHICLERATE.VEHICLERATE_CITYID = CITYMASTER.CITY_ID", " AND VEHICLE_NAME = '" & CMBVEHICLENAME.Text.Trim & "' AND ISNULL(LEDGERS.ACC_CMPNAME,'') = '" & CMBNAME.Text.Trim & "' AND ISNULL(CITYMASTER.CITY_NAME,'') = '" & CMBCITY.Text.Trim & "' AND VEHICLERATE_TYPE = '" & CMBTYPE.Text.Trim & "' AND VEHICLERATE_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                If GRIDDOUBLECLICK = False Or (GRIDDOUBLECLICK = True And Val(TXTNO.Text) <> Val(DT.Rows(0).Item(0))) Then
                    EP.SetError(TXTKMRATE, "Vehicle's Rate of Selected Type Already Added below")
                    bln = False
                End If
            End If
        End If
        

        If CMBVEHICLENAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBVEHICLENAME, "Select Vehicle Name")
            bln = False
        End If

        If CMBTYPE.Text.Trim.Length = 0 Then
            EP.SetError(CMBTYPE, "Select Type")
            bln = False
        End If

        If Val(TXTRATE.Text.Trim) = 0 And CMBTYPE.Text <> "OUTSTATION" Then
            EP.SetError(TXTRATE, "Rate Cannot be 0")
            bln = False
        End If

        If Val(TXTHRRATE.Text.Trim) = 0 And CMBTYPE.Text <> "OUTSTATION" Then
            EP.SetError(TXTHRRATE, "Hr Rate Cannot be 0")
            bln = False
        End If

        If Val(TXTKMRATE.Text.Trim) = 0 Then
            EP.SetError(TXTKMRATE, "Km Rate Cannot be 0")
            bln = False
        End If

        If Val(TXTKMS.Text.Trim) = 0 Then
            EP.SetError(TXTKMRATE, "Km Cannot be 0")
            bln = False
        End If


        Return bln
    End Function

    Sub EDITROW()
        Try
            If USEREDIT = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If gridbill.GetFocusedRowCellValue("ID") > 0 Then
                GRIDDOUBLECLICK = True
                TXTNO.Text = gridbill.GetFocusedRowCellValue("ID")
                CMBVEHICLENAME.Text = gridbill.GetFocusedRowCellValue("VEHICLENAME")
                CMBNAME.Text = gridbill.GetFocusedRowCellValue("NAME")
                CMBCITY.Text = gridbill.GetFocusedRowCellValue("CITY")
                CMBTYPE.Text = gridbill.GetFocusedRowCellValue("TYPE")
                TXTKMS.Text = Val(gridbill.GetFocusedRowCellValue("KMS"))
                TXTALLOWANCE.Text = Val(gridbill.GetFocusedRowCellValue("ALLOWANCE"))
                TXTNIGHTALLOWANCE.Text = Val(gridbill.GetFocusedRowCellValue("NIGHTALLOWANCE"))
                TXTRATE.Text = Val(gridbill.GetFocusedRowCellValue("RATE"))
                TXTHRRATE.Text = Val(gridbill.GetFocusedRowCellValue("HRRATE"))
                TXTKMRATE.Text = Val(gridbill.GetFocusedRowCellValue("KMRATE"))
                CMBVEHICLENAME.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbilldetails_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbilldetails.DoubleClick
        EDITROW()
    End Sub

    Sub fillgrid()
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable
            If FRMSTRING = "PURRATE" Then
                'DT = OBJCMN.search(" VEHICLERATEPUR.VEHICLERATEPUR_ID AS ID, VEHICLEMASTER.VEHICLE_NAME AS VEHICLENAME, ISNULL(LEDGERS.Acc_cmpname,'') AS NAME, ISNULL(CITYMASTER.city_name, '') AS CITY ,VEHICLERATEPUR.VEHICLERATEPUR_TYPE AS TYPE, ISNULL(VEHICLERATEPUR.VEHICLERATEPUR_KMS,0) AS KMS, ISNULL(VEHICLERATEPUR.VEHICLERATEPUR_ALLOWANCE,0) AS ALLOWANCE, ISNULL(VEHICLERATEPUR.VEHICLERATEPUR_NIGHTALLOWANCE,0) AS NIGHTALLOWANCE, ISNULL(VEHICLERATEPUR.VEHICLERATEPUR_RATE,0) AS RATE, ISNULL(VEHICLERATEPUR.VEHICLERATEPUR_HRRATE,0) AS HRRATE, ISNULL(VEHICLERATEPUR.VEHICLERATEPUR_KMRATE,0) AS KMRATE  ", "", " VEHICLERATEPUR INNER JOIN VEHICLEMASTER ON VEHICLERATEPUR.VEHICLERATEPUR_VEHICLEID = VEHICLEMASTER.VEHICLE_ID LEFT OUTER JOIN LEDGERS ON VEHICLERATEPUR.VEHICLERATEPUR_LEDGERID = LEDGERS.Acc_id  ", " AND VEHICLERATEPUR_YEARID = " & YearId)
                DT = OBJCMN.search(" VEHICLERATEPUR.VEHICLERATEPUR_ID AS ID, VEHICLEMASTER.VEHICLE_NAME AS VEHICLENAME, ISNULL(LEDGERS.Acc_cmpname,'') AS NAME, ISNULL(CITYMASTER.city_name, '') AS CITY ,VEHICLERATEPUR.VEHICLERATEPUR_TYPE AS TYPE, ISNULL(VEHICLERATEPUR.VEHICLERATEPUR_KMS,0) AS KMS, ISNULL(VEHICLERATEPUR.VEHICLERATEPUR_ALLOWANCE,0) AS ALLOWANCE, ISNULL(VEHICLERATEPUR.VEHICLERATEPUR_NIGHTALLOWANCE,0) AS NIGHTALLOWANCE, ISNULL(VEHICLERATEPUR.VEHICLERATEPUR_RATE,0) AS RATE, ISNULL(VEHICLERATEPUR.VEHICLERATEPUR_HRRATE,0) AS HRRATE, ISNULL(VEHICLERATEPUR.VEHICLERATEPUR_KMRATE,0) AS KMRATE  ", "", " VEHICLERATEPUR INNER JOIN VEHICLEMASTER ON VEHICLERATEPUR.VEHICLERATEPUR_VEHICLEID = VEHICLEMASTER.VEHICLE_ID LEFT OUTER JOIN LEDGERS ON VEHICLERATEPUR.VEHICLERATEPUR_LEDGERID = LEDGERS.Acc_id  LEFT OUTER JOIN CITYMASTER ON VEHICLERATEPUR.VEHICLERATEPUR_CITYID = CITYMASTER.city_id ", " AND VEHICLERATEPUR_YEARID = " & YearId)

            Else
                DT = OBJCMN.search(" VEHICLERATE.VEHICLERATE_ID AS ID, VEHICLEMASTER.VEHICLE_NAME AS VEHICLENAME, ISNULL(LEDGERS.Acc_cmpname,'') AS NAME, ISNULL(CITYMASTER.city_name, '') AS CITY, VEHICLERATE.VEHICLERATE_TYPE AS TYPE, ISNULL(VEHICLERATE.VEHICLERATE_KMS,0) AS KMS, ISNULL(VEHICLERATE.VEHICLERATE_ALLOWANCE,0) AS ALLOWANCE, ISNULL(VEHICLERATE.VEHICLERATE_NIGHTALLOWANCE,0) AS NIGHTALLOWANCE, ISNULL(VEHICLERATE.VEHICLERATE_RATE,0) AS RATE, ISNULL(VEHICLERATE.VEHICLERATE_HRRATE,0) AS HRRATE, ISNULL(VEHICLERATE.VEHICLERATE_KMRATE,0) AS KMRATE  ", "", " VEHICLERATE INNER JOIN VEHICLEMASTER ON VEHICLERATE.VEHICLERATE_VEHICLEID = VEHICLEMASTER.VEHICLE_ID LEFT OUTER JOIN LEDGERS ON VEHICLERATE.VEHICLERATE_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN CITYMASTER ON VEHICLERATE.VEHICLERATE_CITYID = CITYMASTER.city_id  ", " AND VEHICLERATE_YEARID = " & YearId)
            End If
            gridbilldetails.DataSource = DT
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub VehicleRateList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.F5 Then
            gridbilldetails.Focus()
        ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Sub FILLCMB()
        Try
            FILLVEHICLE(CMBVEHICLENAME, False, "")
            If FRMSTRING = "PURRATE" Then fillname(CMBNAME, False, " AND GROUP_SECONDARY = 'Sundry Creditors'") Else fillname(CMBNAME, False, " AND GROUP_SECONDARY = 'Sundry Debtors'")
            fillcity(CMBCITY)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CLEAR()
        Try
            TXTNO.Clear()
            CMBVEHICLENAME.Text = ""
            CMBNAME.Text = ""
            CMBCITY.Text = ""
            CMBTYPE.SelectedIndex = 0
            TXTRATE.Clear()
            TXTKMS.Clear()
            TXTNIGHTALLOWANCE.Clear()
            TXTALLOWANCE.Clear()
            TXTHRRATE.Clear()
            TXTKMRATE.Clear()
            GRIDDOUBLECLICK = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub VehicleRateList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'VEHICLE MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)


            Dim OBJCMN As New ClsCommon
            Dim dttable As New DataTable

            FILLCMB()
            CLEAR()

            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Sub SAVE()
        Try

            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(Val(TXTNO.Text.Trim))
            ALPARAVAL.Add(CMBVEHICLENAME.Text.Trim)
            ALPARAVAL.Add(CMBNAME.Text.Trim)
            ALPARAVAL.Add(CMBCITY.Text.Trim)
            ALPARAVAL.Add(CMBTYPE.Text.Trim)
            ALPARAVAL.Add(Val(TXTKMS.Text.Trim))
            ALPARAVAL.Add(Val(TXTALLOWANCE.Text.Trim))
            ALPARAVAL.Add(Val(TXTNIGHTALLOWANCE.Text.Trim))
            ALPARAVAL.Add(Val(TXTRATE.Text.Trim))
            ALPARAVAL.Add(Val(TXTHRRATE.Text.Trim))
            ALPARAVAL.Add(Val(TXTKMRATE.Text.Trim))
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)


            If FRMSTRING = "PURRATE" Then
                Dim OBJVEHICLE As New ClsVehiclePurRateList
                OBJVEHICLE.alParaval = ALPARAVAL
                Dim INT As Integer = OBJVEHICLE.SAVE()
            Else
                Dim OBJVEHICLE As New ClsVehicleRateList
                OBJVEHICLE.alParaval = ALPARAVAL
                Dim INT As Integer = OBJVEHICLE.SAVE()
            End If
            
            fillgrid()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbilldetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridbilldetails.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                Call CMDDELETE_Click(sender, e)
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTKMRATE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTKMRATE.Validated
        Try
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            SAVE()
            CLEAR()
            CMBVEHICLENAME.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBVEHICLENAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBVEHICLENAME.Enter
        Try
            If CMBVEHICLENAME.Text.Trim = "" Then FILLVEHICLE(CMBVEHICLENAME, False, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBVEHICLENAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBVEHICLENAME.Validating
        Try
            If CMBVEHICLENAME.Text.Trim <> "" Then VEHICLEVALIDATE(CMBVEHICLENAME, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then
                If FRMSTRING = "PURRATE" Then fillname(CMBNAME, False, " AND GROUP_SECONDARY = 'Sundry Creditors'") Else fillname(CMBNAME, False, " AND GROUP_SECONDARY = 'Sundry Debtors'")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then
                If FRMSTRING = "PURRATE" Then namevalidate(CMBNAME, CMBCODE, e, Me, TXTADD, " AND GROUP_SECONDARY = 'Sundry Creditors'", "Sundry Creditors") Else namevalidate(CMBNAME, CMBCODE, e, Me, TXTADD, " AND GROUP_SECONDARY = 'Sundry Debtors'", "Sundry Debtors")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTRATE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTRATE.KeyPress, TXTHRRATE.KeyPress, TXTKMRATE.KeyPress, TXTALLOWANCE.KeyPress, TXTNIGHTALLOWANCE.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub CMDEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEDIT.Click
        EDITROW()
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Try
            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If GRIDDOUBLECLICK = True Then
                MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                Exit Sub
            End If

            Dim TEMPMSG As Integer = MsgBox("Wish To Delete?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbNo Then Exit Sub


            'DELETE FROM TABLE
            Dim ALPARAVAL As New ArrayList
            ALPARAVAL.Add(gridbill.GetFocusedRowCellValue("ID"))

            If FRMSTRING = "PURRATE" Then
                Dim OBJVEHICLE As New ClsVehiclePurRateList
                OBJVEHICLE.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBJVEHICLE.DELETE()
            Else
                Dim OBJVEHICLE As New ClsVehicleRateList
                OBJVEHICLE.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBJVEHICLE.DELETE()
            End If

            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTKMS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTKMS.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub CMBTYPE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTYPE.Validated
        Try
            If Val(TXTKMS.Text.Trim) > 0 Then Exit Sub
            If CMBTYPE.Text = "LOCAL" Then
                TXTKMS.Text = 80
            ElseIf CMBTYPE.Text = "4HRS 40KMS" Then
                TXTKMS.Text = 40
            ElseIf CMBTYPE.Text = "OUTSTATION" Then
                TXTKMS.Text = 300
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCITY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCITY.Enter
        Try
            If CMBCITY.Text.Trim = "" Then fillcity(CMBCITY)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCITY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCITY.Validating
        Try
            If CMBCITY.Text.Trim <> "" Then CITYVALIDATE(CMBCITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class