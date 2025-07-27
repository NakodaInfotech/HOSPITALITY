Imports BL
Imports System.Windows.Forms

Public Class ImpDateMaster
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

            alParaval.Add(TXTNAME.Text.Trim)
            alParaval.Add(fromdate.Value.Date)
            alParaval.Add(todate.Value.Date)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim objLWZ As New ClsLawazim
            If frmstring = "IMPDATE" Then
                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    objLWZ.alParaval = alParaval
                    IntResult = objLWZ.saveIMPDATE()
                    MsgBox("Imp Dates Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(tempid)
                    objLWZ.alParaval = alParaval
                    IntResult = objLWZ.updateIMPDATE()
                    MsgBox("Imp Dates Updated")
                End If
            End If
            edit = False
            clear()
            TXTNAME.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If fromdate.Value.Date > todate.Value.Date Then
            Ep.SetError(fromdate, "Fill Proper Dates")
            bln = False
        End If

     
        Return bln
    End Function

    Sub clear()
        TXTNAME.Clear()
        fromdate.Value = Mydate
        todate.Value = Mydate
    End Sub

    Private Sub ImpDateMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
            Call cmdok_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub ImpDateMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

            If frmstring = "IMPDATE" Then
                Me.Text = "Imp Date Master"
            ElseIf frmstring = "BLOCKDATE" Then
                Me.Text = "Block Date Master"
            End If

            Dim dttable As New DataTable
            Dim objCommon As New ClsCommonMaster

            If edit = True Then
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
            End If

            If frmstring = "IMPDATE" Then
                If edit = True Then dttable = objCommon.search(" IMPDATEMASTER.IMP_name AS NAME, IMPDATEMASTER.IMP_FROMDATE AS FROMDATE, IMPDATEMASTER.IMP_TODATE AS TODATE", "", " IMPDATEMASTER", " and IMP_id = " & tempid & " and IMP_yearid = " & YearId)
                If dttable.Rows.Count > 0 Then
                    TXTNAME.Text = dttable.Rows(0).Item(0).ToString
                    fromdate.Value = Convert.ToDateTime(dttable.Rows(0).Item(1).ToString)
                    todate.Value = Convert.ToDateTime(dttable.Rows(0).Item(2).ToString)
                End If
            End If

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

            If edit = True Then
                Dim ALPARAVAL As New ArrayList
                Dim OBJ As New ClsLawazim

                ALPARAVAL.Add(tempname)
                ALPARAVAL.Add(tempid)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)
                ALPARAVAL.Add(Userid)
                OBJ.alParaval = ALPARAVAL

                Dim DT As DataTable
                Dim tempmsg As Integer
                If frmstring = "IMPDATE" Then
                    tempmsg = MsgBox("Delete Imp Date Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then DT = OBJ.DELETEIMPDATE() Else Exit Sub
                    MsgBox(DT.Rows(0).Item(0))
                End If
            End If
            clear()
            edit = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class