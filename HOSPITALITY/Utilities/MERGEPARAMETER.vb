
Imports BL

Public Class MERGEPARAMETER

    Function ERRORVALID() As Boolean
        Try
            Dim BLN As Boolean = True

            If cmbtype.Text.Trim = "" Then
                EP.SetError(cmbtype, "Select Type")
                BLN = False
            End If

            If cmbOldName.Text.Trim = "" Then
                EP.SetError(cmbOldName, "Select Proper Name")
                BLN = False
            End If

            If cmbReplace.Text.Trim = "" Then
                EP.SetError(cmbReplace, "Select Proper Name")
                BLN = False
            End If

            If cmbOldName.Text.Trim = cmbReplace.Text.Trim Then
                EP.SetError(cmbOldName, "Both the Names cannot be same")
                BLN = False
            End If

            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            If cmbOldName.Text.Trim <> "" And cmbReplace.Text.Trim <> "" And cmbtype.Text.Trim <> "" Then
                Dim TEMPMSG As Integer = MsgBox("Wish to Merge Data?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbNo Then Exit Sub

                EP.Clear()
                If Not ERRORVALID() Then
                    Exit Sub
                End If

                Cursor.Current = Cursors.WaitCursor

                Dim alParaval As New ArrayList
                Dim intresult As Integer

                alParaval.Add(cmbtype.Text)
                alParaval.Add(cmbOldName.Text)
                alParaval.Add(cmbReplace.Text)
                alParaval.Add(CmpId)
                alParaval.Add(Locationid)
                alParaval.Add(YearId)


                Dim OBJMFG As New ClsCommon()
                OBJMFG.alParaval = alParaval
                intresult = OBJMFG.MERGEPARAMETER()
                MsgBox("Merged Successfully")
            Else
                MsgBox("Fill all Details", MsgBoxStyle.Critical)
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmbtype_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtype.Validated
        Try
            If cmbtype.Text.Trim = "AREA" Then
                If cmbOldName.Text.Trim = "" Then FILLAREA(cmbOldName)
                If cmbReplace.Text.Trim = "" Then FILLAREA(cmbReplace)
            ElseIf cmbtype.Text.Trim = "CITY" Then
                If cmbOldName.Text.Trim = "" Then fillcity(cmbOldName)
                If cmbReplace.Text.Trim = "" Then fillcity(cmbReplace)
            ElseIf cmbtype.Text.Trim = "STATE" Then
                If cmbOldName.Text.Trim = "" Then FILLSTATE(cmbOldName)
                If cmbReplace.Text.Trim = "" Then FILLSTATE(cmbReplace)
            ElseIf cmbtype.Text.Trim = "COUNTRY" Then
                If cmbOldName.Text.Trim = "" Then FILLCOUNTRY(cmbOldName)
                If cmbReplace.Text.Trim = "" Then FILLCOUNTRY(cmbReplace)
            ElseIf cmbtype.Text.Trim = "GROUP" Then
                If cmbOldName.Text.Trim = "" Then FILLGROUP(cmbOldName)
                If cmbReplace.Text.Trim = "" Then FILLGROUP(cmbReplace)
            ElseIf cmbtype.Text.Trim = "HOTEL" Then
                If cmbOldName.Text.Trim = "" Then fillHOTEL(cmbOldName)
                If cmbReplace.Text.Trim = "" Then fillHOTEL(cmbReplace)
            ElseIf cmbtype.Text.Trim = "MELAPLAN" Then
                If cmbOldName.Text.Trim = "" Then FILLPLAN(cmbOldName, False)
                If cmbReplace.Text.Trim = "" Then FILLPLAN(cmbReplace, False)
            ElseIf cmbtype.Text.Trim = "DESIGNATION" Then
                If cmbOldName.Text.Trim = "" Then fillDESIGNATION(cmbOldName)
                If cmbReplace.Text.Trim = "" Then fillDESIGNATION(cmbReplace)
            ElseIf cmbtype.Text.Trim = "DEPARTMENT" Then
                If cmbOldName.Text.Trim = "" Then FILLDEPARTMENT(cmbOldName)
                If cmbReplace.Text.Trim = "" Then FILLDEPARTMENT(cmbReplace)
            ElseIf cmbtype.Text.Trim = "GUEST" Then
                If cmbOldName.Text.Trim = "" Then FILLGUESTNAME(cmbOldName, False)
                If cmbReplace.Text.Trim = "" Then FILLGUESTNAME(cmbReplace, False)
            ElseIf cmbtype.Text.Trim = "POLICY" Then
                If cmbOldName.Text.Trim = "" Then FILLPOLICY(cmbOldName, False)
                If cmbReplace.Text.Trim = "" Then FILLPOLICY(cmbReplace, False)
            ElseIf cmbtype.Text.Trim = "NOTE" Then
                If cmbOldName.Text.Trim = "" Then FILLNOTE(cmbOldName, False)
                If cmbReplace.Text.Trim = "" Then FILLNOTE(cmbReplace, False)
            ElseIf cmbtype.Text.Trim = "SOURCE" Then
                If cmbOldName.Text.Trim = "" Then FILLSOURCE(cmbOldName, False)
                If cmbReplace.Text.Trim = "" Then FILLSOURCE(cmbReplace, False)
            ElseIf cmbtype.Text.Trim = "BOOKEDBY" Then
                If cmbOldName.Text.Trim = "" Then FILLBOOKEDBY(cmbOldName, False)
                If cmbReplace.Text.Trim = "" Then FILLBOOKEDBY(cmbReplace, False)
            ElseIf cmbtype.Text.Trim = "FLIGHT" Then
                If cmbOldName.Text.Trim = "" Then FILLAIRLINE(cmbOldName, False, "")
                If cmbReplace.Text.Trim = "" Then FILLAIRLINE(cmbReplace, False, "")
            ElseIf cmbtype.Text.Trim = "AMENITIES" Then
                If cmbOldName.Text.Trim = "" Then FILLAMNETIES(cmbOldName)
                If cmbReplace.Text.Trim = "" Then FILLAMNETIES(cmbReplace)
            ElseIf cmbtype.Text.Trim = "ROOMTYPE" Then
                If cmbOldName.Text.Trim = "" Then fillROOMTYPE(cmbOldName)
                If cmbReplace.Text.Trim = "" Then fillROOMTYPE(cmbReplace)
            ElseIf cmbtype.Text.Trim = "HOTELTYPE" Then
                If cmbOldName.Text.Trim = "" Then fillHOTELTYPE(cmbOldName)
                If cmbReplace.Text.Trim = "" Then fillHOTELTYPE(cmbReplace)
            ElseIf cmbtype.Text.Trim = "GROUPOFHOTELS" Then
                If cmbOldName.Text.Trim = "" Then FILLGROUPOFHOTELS(cmbOldName)
                If cmbReplace.Text.Trim = "" Then FILLGROUPOFHOTELS(cmbReplace)
            ElseIf cmbtype.Text.Trim = "VEHICLETYPE" Then
                If cmbOldName.Text.Trim = "" Then FILLVEHICLETYPE(cmbOldName, False)
                If cmbReplace.Text.Trim = "" Then FILLVEHICLETYPE(cmbReplace, False)
            ElseIf cmbtype.Text.Trim = "VEHICLE" Then
                If cmbOldName.Text.Trim = "" Then FILLVEHICLE(cmbOldName, False, "")
                If cmbReplace.Text.Trim = "" Then FILLVEHICLE(cmbReplace, False, "")
            ElseIf cmbtype.Text.Trim = "DRIVER" Then
                If cmbOldName.Text.Trim = "" Then FILLDRIVERNAME(cmbOldName, False)
                If cmbReplace.Text.Trim = "" Then FILLDRIVERNAME(cmbReplace, False)
            ElseIf cmbtype.Text.Trim = "RELATION" Then
                If cmbOldName.Text.Trim = "" Then FILLRELATION(cmbOldName)
                If cmbReplace.Text.Trim = "" Then FILLRELATION(cmbReplace)
            ElseIf cmbtype.Text.Trim = "CRSTYPE" Then
                If cmbOldName.Text.Trim = "" Then FILLCRS(cmbOldName)
                If cmbReplace.Text.Trim = "" Then FILLCRS(cmbReplace)
            ElseIf cmbtype.Text.Trim = "TAX" Then
                If cmbOldName.Text.Trim = "" Then filltax(cmbOldName, False)
                If cmbReplace.Text.Trim = "" Then filltax(cmbReplace, False)
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub FILLRELATION(ByRef CMBRELATION As ComboBox)
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable= objclscommon.search(" RELATION_NAME ", "", " RELATIONMASTER", " and RELATION_cmpid=" & CmpId & " AND RELATION_LOCATIONID = " & Locationid & " AND RELATION_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "RELATION_NAME"
                CMBRELATION.DataSource = dt
                CMBRELATION.DisplayMember = "RELATION_NAME"
                CMBRELATION.Text = ""
            End If
            CMBRELATION.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLAMNETIES(ByRef CMB As ComboBox)
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("AMENITIES_NAME AS NAME", "", "AMENITIESMASTER", " AND AMENITIES_CMPID = " & CmpId & " AND AMENITIES_LOCATIONID = " & Locationid & " AND AMENITIES_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                DT.DefaultView.Sort = "AMENITIES_NAME"
                CMB.DataSource = DT
                CMB.DisplayMember = "AMENITIES_NAME"
                CMB.Text = ""
            End If
            CMB.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLAREA(ByRef CMB As ComboBox)
        Try
            If CMB.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("area_name", "", "AreaMaster", " and area_cmpid = " & CmpId & " and area_Locationid = " & Locationid & " and area_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "area_name"
                    CMB.DataSource = dt
                    CMB.DisplayMember = "area_name"
                    CMB.Text = ""
                End If
                CMB.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub FILLSTATE(ByRef CMB As ComboBox)
        Try
            If CMB.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("state_name", "", "StateMaster", " and state_cmpid = " & CmpId & " and state_Locationid = " & Locationid & " and state_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "state_name"
                    CMB.DataSource = dt
                    CMB.DisplayMember = "state_name"
                    CMB.Text = ""
                End If
                CMB.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub FILLCOUNTRY(ByRef CMB As ComboBox)
        Try
            If CMB.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("country_name", "", "CountryMaster", " and country_cmpid = " & CmpId & " and country_Locationid = " & Locationid & " and country_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "country_name"
                    CMB.DataSource = dt
                    CMB.DisplayMember = "country_name"
                    CMB.Text = ""
                End If
                CMB.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

End Class