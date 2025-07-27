
Imports BL

Public Class RoomTypeMaster

    Public FRMSTRING As String
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Public TempName As String        'Used for tempname while edit mode
    Public TempID As Integer         'Used for tempname while edit mode
    Public edit As Boolean           'Used for edit

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub txtname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtname.Validating
        Try
            If Not VALIDATENAME() Then e.Cancel = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function VALIDATENAME() As Boolean
        Try
            Dim BLN As Boolean = True
            If txtname.Text.Trim <> "" Then
                'for search
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If (edit = False) Or (edit = True And LCase(TempName) <> LCase(txtname.Text.Trim)) Then
                    If FRMSTRING = "ROOMTYPE" Then
                        dt = objclscommon.search("ROOMTYPE_name", "", "ROOMTYPEMaster", " and ROOMTYPE_name = '" & txtname.Text.Trim & "' and ROOMTYPE_cmpid =" & CmpId & " and ROOMTYPE_Locationid =" & Locationid & " and ROOMTYPE_Yearid =" & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("Room Type Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                            BLN = False
                        End If
                    ElseIf FRMSTRING = "HOTELTYPE" Then
                        dt = objclscommon.search("HOTELTYPE_name", "", "HOTELTYPEMaster", " and HOTELTYPE_name = '" & txtname.Text.Trim & "' and HOTELTYPE_cmpid = " & CmpId & " and HOTELTYPE_Locationid = " & Locationid & " and HOTELTYPE_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("Hotel Type Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                            BLN = False
                        End If
                    ElseIf FRMSTRING = "GROUPOFHOTELS" Then
                        dt = objclscommon.search("GROUPOFHOTELS_name", "", "GROUPOFHOTELSMaster", " and GROUPOFHOTELS_name = '" & txtname.Text.Trim & "' and GROUPOFHOTELS_cmpid = " & CmpId & " and GROUPOFHOTELS_Locationid = " & Locationid & " and GROUPOFHOTELS_yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("Group Of Hotels Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                            BLN = False
                        End If
                    ElseIf FRMSTRING = "AMENITIES" Then
                        dt = objclscommon.search("AMENITIES_name", "", "AMENITIESMaster", " and AMENITIES_name = '" & txtname.Text.Trim & "' and AMENITIES_cmpid = " & CmpId & " and AMENITIES_Locationid = " & Locationid & " and AMENITIES_yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("Amenities Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                            BLN = False
                        End If
                    ElseIf FRMSTRING = "SOURCE" Then
                        dt = objclscommon.search("SOURCE_name", "", "SOURCEMaster", " and SOURCE_name = '" & txtname.Text.Trim & "' and SOURCE_cmpid = " & CmpId & " and SOURCE_Locationid = " & Locationid & " and SOURCE_yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("Source Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                            BLN = False
                        End If
                    ElseIf FRMSTRING = "DESIGNATION" Then
                        dt = objclscommon.search("DESIGNATION_name", "", "DESIGNATIONMaster", " and DESIGNATION_name = '" & txtname.Text.Trim & "' and DESIGNATION_cmpid = " & CmpId & " and DESIGNATION_Locationid = " & Locationid & " and DESIGNATION_yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("DESIGNATION Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                            BLN = False
                        End If
                    ElseIf FRMSTRING = "DEPARTMENT" Then
                        dt = objclscommon.search("DEPARTMENT_name", "", "DEPARTMENTMaster", " and DEPARTMENT_name = '" & txtname.Text.Trim & "' and DEPARTMENT_cmpid = " & CmpId & " and DEPARTMENT_Locationid = " & Locationid & " and DEPARTMENT_yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("DEPARTMENT Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                            BLN = False
                        End If
                    ElseIf FRMSTRING = "MEALPLAN" Then
                        dt = objclscommon.search("PLAN_name", "", "PLANMASTER", " and PLAN_name = '" & txtname.Text.Trim & "' and PLAN_cmpid = " & CmpId & " and PLAN_Locationid = " & Locationid & " and PLAN_yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("PLAN Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                            BLN = False
                        End If
                    ElseIf FRMSTRING = "VEHICLETYPE" Then
                        dt = objclscommon.search("VEHICLETYPE_name", "", "VEHICLETYPEMASTER", " and VEHICLETYPE_name = '" & txtname.Text.Trim & "' and VEHICLETYPE_cmpid = " & CmpId & " and VEHICLETYPE_Locationid = " & Locationid & " and VEHICLETYPE_yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("VEHICLE TYPE Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                            BLN = False
                        End If
                    ElseIf FRMSTRING = "SOURCE" Then
                        dt = objclscommon.search("SOURCE_name", "", "SOURCEMASTER", " and SOURCE_name = '" & txtname.Text.Trim & "' and SOURCE_cmpid = " & CmpId & " and SOURCE_Locationid = " & Locationid & " and SOURCE_yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("Booked By Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                            BLN = False
                        End If
                    ElseIf FRMSTRING = "BOOKEDBY" Then
                        dt = objclscommon.search("BOOKEDBY_name", "", "BOOKEDBYMASTER", " and BOOKEDBY_name = '" & txtname.Text.Trim & "' and BOOKEDBY_cmpid = " & CmpId & " and BOOKEDBY_Locationid = " & Locationid & " and BOOKEDBY_yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("Booked By Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                            BLN = False
                        End If
                    ElseIf FRMSTRING = "LEADTYPE" Then
                        dt = objclscommon.search("LEADTYPE_name", "", "LEADTYPEMASTER", " and LEADTYPE_name = '" & txtname.Text.Trim & "' and LEADTYPE_cmpid = " & CmpId & " and LEADTYPE_Locationid = " & Locationid & " and LEADTYPE_yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("LEADTYPE Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                            BLN = False
                        End If
                    ElseIf FRMSTRING = "CATEGORY" Then
                        dt = objclscommon.search("CATEGORY_name", "", "CATEGORYMASTER", " and CATEGORY_name = '" & txtname.Text.Trim & "' and CATEGORY_cmpid = " & CmpId & " and CATEGORY_Locationid = " & Locationid & " and CATEGORY_yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("Category Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                            BLN = False
                        End If
                    End If
                End If
                pcase(txtname)
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
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
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            If FRMSTRING = "ROOMTYPE" Then
                Dim OBJROOM As New ClsRoomTypeMaster
                OBJROOM.alParaval = alParaval

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJROOM.save()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJROOM.Update()
                    MsgBox("Details Updated")
                End If

            ElseIf FRMSTRING = "HOTELTYPE" Then
                Dim OBJHOTEL As New ClsHotelTypeMaster
                OBJHOTEL.alParaval = alParaval

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJHOTEL.save()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJHOTEL.Update()
                    MsgBox("Details Updated")
                End If

            ElseIf FRMSTRING = "GROUPOFHOTELS" Then
                Dim OBJGROUP As New ClsGroupOfHotelsMaster
                OBJGROUP.alParaval = alParaval

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJGROUP.save()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJGROUP.Update()
                    MsgBox("Details Updated")
                End If

            ElseIf FRMSTRING = "AMENITIES" Then
                Dim OBJAMENITIES As New ClsAMENITIESMASTER
                OBJAMENITIES.alParaval = alParaval

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJAMENITIES.SAVE()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJAMENITIES.update()
                    MsgBox("Details Updated")
                End If

            ElseIf FRMSTRING = "SOURCE" Then
                Dim OBJSOURCE As New ClsSourceMaster
                OBJSOURCE.alParaval = alParaval

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJSOURCE.SAVE()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJSOURCE.update()
                    MsgBox("Details Updated")
                End If

            ElseIf FRMSTRING = "DESIGNATION" Then
                Dim OBJDES As New ClsDesignationMaster
                OBJDES.alParaval = alParaval

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJDES.SAVE()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJDES.update()
                    MsgBox("Details Updated")
                End If

            ElseIf FRMSTRING = "DEPARTMENT" Then
                Dim OBJDEP As New ClsDepartmentMaster
                OBJDEP.alParaval = alParaval

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJDEP.SAVE()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJDEP.update()
                    MsgBox("Details Updated")
                End If
            ElseIf FRMSTRING = "MEALPLAN" Then
                Dim OBJMEAL As New ClsPlanMaster
                OBJMEAL.alParaval = alParaval

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJMEAL.SAVE()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJMEAL.update()
                    MsgBox("Details Updated")
                End If
            ElseIf FRMSTRING = "BOOKEDBY" Then
                Dim OBJBOOKEDBY As New ClsBookedByMaster
                OBJBOOKEDBY.alParaval = alParaval

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJBOOKEDBY.SAVE()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJBOOKEDBY.update()
                    MsgBox("Details Updated")
                End If

            ElseIf FRMSTRING = "SOURCE" Then
                Dim OBVT As New ClsSourceMaster
                OBVT.alParaval = alParaval

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBVT.SAVE()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBVT.update()
                    MsgBox("Details Updated")
                End If

            ElseIf FRMSTRING = "VEHICLETYPE" Then
                Dim OBVT As New ClsVehicleTypeMaster
                OBVT.alParaval = alParaval

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBVT.SAVE()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBVT.update()
                    MsgBox("Details Updated")
                End If
            ElseIf FRMSTRING = "LEADTYPE" Then
                Dim OBJDEP As New ClsLeadTypeMaster
                OBJDEP.alParaval = alParaval

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJDEP.SAVE()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJDEP.update()
                    MsgBox("Details Updated")
                End If
            ElseIf FRMSTRING = "CATEGORY" Then
                Dim OBJDEP As New ClsCustomerCategoryMaster
                OBJDEP.alParaval = alParaval

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJDEP.SAVE()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJDEP.update()
                    MsgBox("Details Updated")
                End If
            End If

            clear()
            txtname.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If txtname.Text.Trim.Length = 0 Then
            EP.SetError(txtname, "Fill Name")
            bln = False
        End If

        If Not VALIDATENAME() Then
            EP.SetError(txtname, "Name Already Exists")
            bln = False
        End If
        Return bln
    End Function

    Sub clear()
        txtname.Clear()
        txtremarks.Clear()
        edit = False
    End Sub

    Private Sub ROOMTYPEMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
            Call cmdok_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub RoomTypeMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DT As New DataTable
            Dim OBJCOMMON As New ClsCommon

            If FRMSTRING = "ROOMTYPE" Then

                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ROOMTYPE MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Me.Text = "Room Type Master"
                lblgroup.Text = "Room Type"
                lbl.Text = "Enter Room Type" & vbCrLf & "(e.g. Deluxe, Standard,..,etc.)"

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If edit = True Then DT = OBJCOMMON.search(" ROOMTYPE_name, ROOMTYPE_REMARKS", "", "ROOMTYPEMaster", " and ROOMTYPE_id = " & TempID & " and ROOMTYPE_cmpid = " & CmpId & " and ROOMTYPE_locationid = " & Locationid & " and ROOMTYPE_yearid = " & YearId)


            ElseIf FRMSTRING = "HOTELTYPE" Then

                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'HOTELTYPE MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Me.Text = "Hotel Type Master"
                lblgroup.Text = "Hotel Type"
                lbl.Text = "Enter Hotel Type" & vbCrLf & "(e.g. Hotel, Resorts,..,etc.)"

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If edit = True Then DT = OBJCOMMON.search(" HOTELTYPE_name, HOTELTYPE_REMARKS", "", "HOTELTYPEMaster", " and HOTELTYPE_id = " & TempID & " and HOTELTYPE_cmpid = " & CmpId & " and HOTELTYPE_locationid = " & Locationid & " and HOTELTYPE_yearid = " & YearId)


            ElseIf FRMSTRING = "GROUPOFHOTELS" Then

                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'GROUP OF HOTELS'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Me.Text = "Group Of Hotels"
                lblgroup.Text = "Group"
                lbl.Text = "Enter Group Name"

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If edit = True Then DT = OBJCOMMON.search(" GROUPOFHOTELS_name, GROUPOFHOTELS_REMARKS", "", "GROUPOFHOTELSMaster", " and GROUPOFHOTELS_id = " & TempID & " and GROUPOFHOTELS_cmpid = " & CmpId & " and GROUPOFHOTELS_locationid = " & Locationid & " and GROUPOFHOTELS_yearid = " & YearId)

            ElseIf FRMSTRING = "AMENITIES" Then

                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'AMENITIES MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Me.Text = "Amenities Master"
                lblgroup.Text = "Amenities"
                lbl.Text = "Enter Amenities"

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If edit = True Then DT = OBJCOMMON.search(" AMENITIES_name, AMENITIES_REMARKS", "", "AMENITIESMaster", " and AMENITIES_id = " & TempID & " and AMENITIES_cmpid = " & CmpId & " and AMENITIES_locationid = " & Locationid & " and AMENITIES_yearid = " & YearId)

            ElseIf FRMSTRING = "DESIGNATION" Then

                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'DESIGNATION MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Me.Text = "DESIGNATION Master"
                lblgroup.Text = "DESIGNATION"
                lbl.Text = "Enter DESIGNATION"

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If edit = True Then DT = OBJCOMMON.search(" DESIGNATION_name, DESIGNATION_REMARKS", "", "DESIGNATIONMaster", " and DESIGNATION_id = " & TempID & " and DESIGNATION_cmpid = " & CmpId & " and DESIGNATION_locationid = " & Locationid & " and DESIGNATION_yearid = " & YearId)

            ElseIf FRMSTRING = "DEPARTMENT" Then

                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'DEPARTMENT MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Me.Text = "DEPARTMENT Master"
                lblgroup.Text = "DEPARTMENT"
                lbl.Text = "Enter DEPARTMENT"

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If edit = True Then DT = OBJCOMMON.search(" DEPARTMENT_name, DEPARTMENT_REMARKS", "", "DEPARTMENTMaster", " and DEPARTMENT_id = " & TempID & " and DEPARTMENT_cmpid = " & CmpId & " and DEPARTMENT_locationid = " & Locationid & " and DEPARTMENT_yearid = " & YearId)

            ElseIf FRMSTRING = "MEALPLAN" Then

                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'AMENITIES MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Me.Text = "Meal Plan Master"
                lblgroup.Text = "MEALPLAN"
                lbl.Text = "Enter MEALPLAN"

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If edit = True Then DT = OBJCOMMON.search(" PLAN_NAME, PLAN_REMARKS", "", "PLANMASTER", " and PLAN_id = " & TempID & " and PLAN_cmpid = " & CmpId & " and PLAN_locationid = " & Locationid & " and PLAN_yearid = " & YearId)

            ElseIf FRMSTRING = "VEHICLETYPE" Then

                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'VEHICLE MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Me.Text = "VEHICLE Type Master"
                lblgroup.Text = "VEHICLE TYPE"
                lbl.Text = "Enter VEHICLE TYPE"

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If edit = True Then DT = OBJCOMMON.search(" VEHICLETYPE_NAME, VEHICLETYPE_REMARKS", "", "VEHICLETYPEMASTER", " and VEHICLETYPE_id = " & TempID & " and VEHICLETYPE_cmpid = " & CmpId & " and VEHICLETYPE_locationid = " & Locationid & " and VEHICLETYPE_yearid = " & YearId)

            ElseIf FRMSTRING = "SOURCE" Then

                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'SOURCE MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Me.Text = "Source Master"
                lblgroup.Text = "Source"
                lbl.Text = "Enter Source"

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If edit = True Then DT = OBJCOMMON.search(" SOURCE_NAME, SOURCE_REMARKS", "", "SOURCEMASTER", " and SOURCE_id = " & TempID & " and SOURCE_cmpid = " & CmpId & " and SOURCE_locationid = " & Locationid & " and SOURCE_yearid = " & YearId)

            ElseIf FRMSTRING = "BOOKEDBY" Then

                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'HOTEL MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Me.Text = "Booked By Master"
                lblgroup.Text = "Booked By"
                lbl.Text = "Enter Booked By"

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If edit = True Then DT = OBJCOMMON.search(" BOOKEDBY_NAME, BOOKEDBY_REMARKS", "", "BOOKEDBYMASTER", " and BOOKEDBY_id = " & TempID & " and BOOKEDBY_cmpid = " & CmpId & " and BOOKEDBY_locationid = " & Locationid & " and bookedby_yearid = " & YearId)

            ElseIf FRMSTRING = "LEADTYPE" Then

                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ROOMTYPE MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Me.Text = "LEADTYPE MASTER"
                lblgroup.Text = "LEADTYPE"
                lbl.Text = "Enter LEADTYPE"

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If edit = True Then DT = OBJCOMMON.search(" LEADTYPE_name, LEADTYPE_REMARKS", "", "LEADTYPEMASTER", " and LEADTYPE_id = " & TempID & " and LEADTYPE_cmpid = " & CmpId & " and LEADTYPE_locationid = " & Locationid & " and LEADTYPE_yearid = " & YearId)

            ElseIf FRMSTRING = "CATEGORY" Then

                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'GUEST MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Me.Text = "Category Master"
                lblgroup.Text = "Category"
                lbl.Text = "Enter Category"

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If edit = True Then DT = OBJCOMMON.search(" CATEGORY_name, CATEGORY_REMARKS", "", "CATEGORYMASTER", " and CATEGORY_id = " & TempID & " and CATEGORY_cmpid = " & CmpId & " and CATEGORY_locationid = " & Locationid & " and CATEGORY_yearid = " & YearId)

            End If
            If edit = True Then
                txtname.Text = DT.Rows(0).Item(0)
                txtremarks.Text = DT.Rows(0).Item(1)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Try
            If edit = False Then
                MsgBox("Delete Allowed in Edit Mode Only", MsgBoxStyle.Critical)
                Exit Sub
            End If
            Dim TEMPMSG As Integer = MsgBox("Wish to Delete " & txtname.Text.Trim & "?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbNo Then Exit Sub
            Dim DT As New DataTable
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(txtname.Text.Trim)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(YearId)
            ALPARAVAL.Add(Userid)



            If FRMSTRING = "BOOKEDBY" Then

                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'HOTEL MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Dim OBJBOOKEDBY As New ClsBookedByMaster
                OBJBOOKEDBY.alParaval = ALPARAVAL
                DT = OBJBOOKEDBY.DELETE

            ElseIf FRMSTRING = "ROOMTYPE" Then

                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ROOMTYPE MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Dim OBJROOMTYPE As New ClsRoomTypeMaster
                OBJROOMTYPE.alParaval = ALPARAVAL
                DT = OBJROOMTYPE.DELETE

            ElseIf FRMSTRING = "HOTELTYPE" Then

                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'HOTELTYPE MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Dim OBJ As New ClsHotelTypeMaster
                OBJ.alParaval = ALPARAVAL
                DT = OBJ.DELETE

            ElseIf FRMSTRING = "GROUPOFHOTELS" Then

                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'GROUP OF HOTELS'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Dim OBJ As New ClsGroupOfHotelsMaster
                OBJ.alParaval = ALPARAVAL
                DT = OBJ.DELETE

            ElseIf FRMSTRING = "AMENITIES" Then

                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'AMENITIES MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Dim OBJ As New ClsAmenitiesMaster
                OBJ.alParaval = ALPARAVAL
                DT = OBJ.DELETE

            ElseIf FRMSTRING = "DESIGNATION" Then

                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'DESIGNATION MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Dim OBJ As New ClsDesignationMaster
                OBJ.alParaval = ALPARAVAL
                DT = OBJ.DELETE

            ElseIf FRMSTRING = "DEPARTMENT" Then

                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'DEPARTMENT MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Dim OBJ As New ClsDepartmentMaster
                OBJ.alParaval = ALPARAVAL
                DT = OBJ.DELETE

            ElseIf FRMSTRING = "MEALPLAN" Then

                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'AMENITIES MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Dim OBJ As New ClsPlanMaster
                OBJ.alParaval = ALPARAVAL
                DT = OBJ.DELETE

            ElseIf FRMSTRING = "SOURCE" Then

                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'SOURCE MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Dim OBJ As New ClsSourceMaster
                OBJ.alParaval = ALPARAVAL
                DT = OBJ.DELETE

            ElseIf FRMSTRING = "VEHICLETYPE" Then

                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'VEHICLE MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Dim OBJ As New ClsVehicleTypeMaster
                OBJ.alParaval = ALPARAVAL
                DT = OBJ.DELETE

            ElseIf FRMSTRING = "LEADTYPE" Then

                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ROOMTYPE MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Dim OBJ As New ClsLeadTypeMaster
                OBJ.alParaval = ALPARAVAL
                DT = OBJ.DELETE

            ElseIf FRMSTRING = "CATEGORY" Then

                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'GUEST MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Dim OBJ As New ClsCustomerCategoryMaster
                OBJ.alParaval = ALPARAVAL
                DT = OBJ.DELETE

            End If

            MsgBox(DT.Rows(0).Item(0))
            clear()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class