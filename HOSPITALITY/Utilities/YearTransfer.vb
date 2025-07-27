
Imports BL

Public Class YearTransfer

    Dim INTRES As Integer
    Dim OBJTRF As New ClsYearTransfer
    Public FRMSTRING As String = ""

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            'transfering data from selected cmp
            If GRIDYEAR.SelectedRows.Count = 0 Then
                MsgBox("Select Year", MsgBoxStyle.Critical)
                Exit Sub
            End If


            'INTIMATE IF USER HAS SELECTED WRONG YEAR
            If FRMSTRING <> "USERTRANSFER" And AccFrom.Year - Convert.ToDateTime(GRIDYEAR.CurrentRow.Cells(GSTARTDATE.Index).Value).Date.Year > 1 Then
                If MsgBox("We Think You have selected the Wrong Year, Wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            End If


            Dim SELECTEDYEARID As Integer = 0
            Dim TEMPMSG As Integer = MsgBox("Transfer Data from Selected Year?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                TEMPMSG = MsgBox("Are you sure, wish to Proceed?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then

                    SELECTEDYEARID = GRIDYEAR.CurrentRow.Cells(GYEARID.Index).Value

                    If FRMSTRING = "YEARTRANSFER" Then
                        'RECONCILE DATA BEFORE TRANSFERRING

                        'COMMENT BY GULKIT AS IT WAS WORKING SLOW FOR CLASSIC
                        'Dim OBJURECO As New ClsDataReco
                        'Dim ALPARAVAL As New ArrayList
                        'ALPARAVAL.Add(CmpId)
                        'ALPARAVAL.Add(Locationid)
                        'ALPARAVAL.Add(YearId)

                        'OBJURECO.alParaval = ALPARAVAL
                        'Dim INTRES As Integer = OBJURECO.RECO()


                        '********* TRANSFERRING DATA ***********
                        TRANSFERBOOKEDBY(SELECTEDYEARID)
                        TRANSFERUSER(SELECTEDYEARID)


                        TRANSFERDEPARTMENT(SELECTEDYEARID)
                        TRANSFERDESIGNATION(SELECTEDYEARID)
                        TRANSFERNATIONALITY(SELECTEDYEARID)
                        TRANSFERRELATION(SELECTEDYEARID)
                        TRANSFERGROUP(SELECTEDYEARID)
                        TRANSFERLOCATION(SELECTEDYEARID)
                        'TRANSFERREFFEREDBY(SELECTEDYEARID)
                        TRANSFERACCOUNTS(SELECTEDYEARID)
                        TRANSFEREMPLOYEES(SELECTEDYEARID)
                        TRANSFERGUEST(SELECTEDYEARID)


                        TRANSFERDRIVER(SELECTEDYEARID)
                        TRANSFERVEHICLETYPE(SELECTEDYEARID)
                        TRANSFERVEHICLE(SELECTEDYEARID)
                        TRANSFERVEHICLENO(SELECTEDYEARID)
                        TRANSFERVEHICLERATE(SELECTEDYEARID)

                        'TRANSFER STAGE MASTER
                        TRANSFERSTAGE(SELECTEDYEARID)
                        TRANSFERPARTICULAR(SELECTEDYEARID)


                        TRANSFERAMENITIES(SELECTEDYEARID)
                        TRANSFERHOTELTYPE(SELECTEDYEARID)
                        TRANSFERHOTELGROUP(SELECTEDYEARID)
                        TRANSFERROOMTYPE(SELECTEDYEARID)
                        TRANSFERPLAN(SELECTEDYEARID)
                        TRANSFERHOTEL(SELECTEDYEARID)

                        TRANSFERNOTE(SELECTEDYEARID)
                        TRANSFERPOLICY(SELECTEDYEARID)
                        TRANSFERPREFIX(SELECTEDYEARID)
                        TRANSFERSECTOR(SELECTEDYEARID)
                        TRANSFERSOURCE(SELECTEDYEARID)

                        TRANSFERCLASS(SELECTEDYEARID)
                        TRANSFERROUTE(SELECTEDYEARID)
                        TRANSFERFLIGHT(SELECTEDYEARID)


                        TRANSFERCURRENCY(SELECTEDYEARID)
                        TRANSFERCOUNTRYTAX(SELECTEDYEARID)
                        TRANSFERDOC(SELECTEDYEARID)
                        TRANSFERGIFT(SELECTEDYEARID)
                        TRANSFERID(SELECTEDYEARID)
                        TRANSFERLAWAZIM(SELECTEDYEARID)
                        TRANSFERMEALCONFIG(SELECTEDYEARID)
                        TRANSFERSERVICE(SELECTEDYEARID)
                        TRANSFERREGISTER(SELECTEDYEARID)

                        TRANSFERGROUPDEP(SELECTEDYEARID)
                        TRANSFERITINERARY(SELECTEDYEARID)

                        'PENDING ENQUIREIES , HOTEL QUOTATIONS, PACKAGE QUOTATIONS
                        TRANSFERLEADTYPE(SELECTEDYEARID)
                        TRANSFERENQ(SELECTEDYEARID)
                        TRANSFERHOTELENQ(SELECTEDYEARID)
                        TRANSFERHOLIDAYENQ(SELECTEDYEARID)
                        'NOT YET DONE
                        'TRANSFERAIRLINEENQ(SELECTEDYEARID)


                        TRANSFERHSN(SELECTEDYEARID)
                        TRANSFERBILLS(SELECTEDYEARID)
                        TRANSFERBALANCE(SELECTEDYEARID)
                        TRANSFERPROFITLOSS(SELECTEDYEARID)
                        '******* TRANSFERRING DATA DONE ********

                        MsgBox("Transfer Completed Successfully")
                        'MsgBox("Software will be Closed, Please Restart")
                        'End

                    ElseIf FRMSTRING = "USERTRANSFER" Then
                        TRANSFERBOOKEDBY(SELECTEDYEARID)
                        TRANSFERUSER(SELECTEDYEARID)
                        MsgBox("User Transferred Successfully")
                        'MsgBox("Software will be Closed, Please Restart")
                        'End
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub YearTransfer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If FRMSTRING = "USERTRANSFER" Then
                Me.Text = "Transfer Users"
                LBLUSER.Visible = True
                CMBUSER.Visible = True
                fillUSER(CMBUSER, "")
            End If
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" CONVERT(char(11), year_startdate , 6) + ' - ' + CONVERT(char(11), year_enddate , 6) AS YEARNAME, YEAR_ID AS YEARID, year_startdate AS STARTDATE, year_ENDDATE AS ENDDATE   ", "", " YEARMASTER", " AND YEAR_ID <> " & YearId & " AND YEAR_CMPID = " & CmpId & " ORDER BY YEAR_ID DESC ")
            If DT.Rows.Count > 0 Then
                For Each DTROW As DataRow In DT.Rows
                    GRIDYEAR.Rows.Add(DTROW("YEARNAME"), DTROW("YEARID"), Format(Convert.ToDateTime(DTROW("STARTDATE")).Date, "dd/MM/yyyy"), Format(Convert.ToDateTime(DTROW("ENDDATE")).Date, "dd/MM/yyyy"))
                Next
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERUSER(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(CMBUSER.Text.Trim)
            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERUSER()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERDEPARTMENT(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERDEPARTMENT()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERDESIGNATION(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERDESIGNATION()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERNATIONALITY(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERNATIONALITY()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERRELATION(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERRELATION()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERGROUP(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERGROUP()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERLOCATION(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERLOCATION()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERREFFEREDBY(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERREFFEREDBY()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERACCOUNTS(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERACCOUNTS()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFEREMPLOYEES(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFEREMPLOYEES()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERGUEST(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERGUEST()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERDRIVER(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERDRIVER()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERVEHICLETYPE(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERVEHICLETYPE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERVEHICLE(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERVEHICLE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERVEHICLENO(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERVEHICLENO()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERVEHICLERATE(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERVEHICLERATE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERSTAGE(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERSTAGE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERPARTICULAR(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERPARTICULAR()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERAMENITIES(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERAMENITIES()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERHOTELTYPE(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERHOTELTYPE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERHOTELGROUP(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERHOTELGROUP()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERROOMTYPE(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERROOMTYPE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERPLAN(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERPLAN()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERHOTEL(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERHOTEL()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERBOOKEDBY(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERBOOKEDBY()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERNOTE(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERNOTE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERPOLICY(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERPOLICY()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERPREFIX(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERPREFIX()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERSECTOR(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERSECTOR()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERSOURCE(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERSOURCE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERCLASS(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERCLASS()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERROUTE(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERROUTE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERFLIGHT(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERFLIGHT()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERCURRENCY(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERCURRENCY()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERCOUNTRYTAX(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERCOUNTRYTAX()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERDOC(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERDOC()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERGIFT(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERGIFT()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERID(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERLAWAZIM(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERLAWAZIM()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERMEALCONFIG(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERMEALCONFIG()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERSERVICE(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERSERVICE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERREGISTER(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERREGISTER()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERITINERARY(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERITINERARY()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERGROUPDEP(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERGROUPDEP()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERLEADTYPE(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERLEADTYPE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERENQ(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERENQ()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERHOTELENQ(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERHOTELENQ()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERHOLIDAYENQ(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERHOLIDAYENQ()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERAIRLINEENQ(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERAIRLINEENQ()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERHSN(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERHSN()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERBILLS(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERBILLS()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERBALANCE(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERBALANCE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERPROFITLOSS(ByVal SELECTEDYEARID As Integer)
        Try

            
            Dim ALPARAVAL As New ArrayList
            Dim OBJPL As New ClsProfitLoss

            Dim OBJCMN As New ClsCommon
            Dim DTF As DataTable = OBJCMN.search(" YEAR_STARTDATE AS FROMDATE, YEAR_ENDDATE AS TODATE", "", " YEARMASTER ", " AND YEAR_ID = " & SELECTEDYEARID)
            ALPARAVAL.Add(Format(DTF.Rows(0).Item("FROMDATE"), "MM/dd/yyyy"))
            ALPARAVAL.Add(Format(DTF.Rows(0).Item("TODATE"), "MM/dd/yyyy"))

            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(SELECTEDYEARID)

            OBJPL.alParaval = ALPARAVAL
            Dim DT = OBJPL.GETSUMMARY()

            ALPARAVAL.Clear()

            Dim DTROW() As DataRow = DT.Select("NAME = 'Nett Profit'")
            If DTROW.Length > 0 Then
                ALPARAVAL.Add(Val(DTROW(0).Item(1)))
            Else
                Dim DTROW1() As DataRow = DT.Select("NAME = 'Nett Loss'")
                ALPARAVAL.Add(Val(DTROW1(0).Item(1)) * (-1))
            End If



            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERPROFITLOSS()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class