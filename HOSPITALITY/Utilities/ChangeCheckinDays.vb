Imports BL
Imports System.Windows.Forms
Imports System.IO

Public Class ChangeCheckinDays

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public frmstring As String        'Used from Displaying Customer, Vendor, Employee Master
    Public edit As Boolean = True

    Private Sub TXTDAYS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTDAYS.KeyPress
        numkeypress(e, TXTDAYS, Me)
    End Sub

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub ChangeCheckinDays_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'HOLIDAY PACKAGES'")

            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor

            'fillcmb()
            clear()

            'cmbname.Enabled = True

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If


                Dim OBJINVOICE As New ClsChangeCheckinDays()
                Dim DT As DataTable = OBJINVOICE.GETCHECKINDAYS(CmpId)


                If DT.Rows.Count > 0 Then
                    For Each dr As DataRow In DT.Rows
                        TXTDAYS.Text = Val(Convert.ToString(dr("DAYS")))
                    
                    Next

                Else
                    edit = False
                    clear()

                End If

            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub clear()
        EP.Clear()
        TXTDAYS.Clear()
        'edit = False
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If TXTDAYS.Text.Trim.Length = 0 Or Val(TXTDAYS.Text.Trim) <= 0 Then
            EP.SetError(TXTDAYS, "Days Cannot Be Zero")
            bln = False
        End If

        Return bln
    End Function

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(Val(TXTDAYS.Text.Trim))
            alParaval.Add(CmpId)

            Dim objAccountsMaster As New ClsChangeCheckinDays
            objAccountsMaster.alParaval = alParaval
            'objAccountsMaster.frmstring = frmstring

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objAccountsMaster.save()
                'edit = True
                MsgBox("Details Added")
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                'alParaval.Add(tempAccountId)
                IntResult = objAccountsMaster.update()
                MsgBox("Details Updated")
            End If
            edit = False

            clear()
            TXTDAYS.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
End Class