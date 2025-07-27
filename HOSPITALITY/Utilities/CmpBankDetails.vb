Imports System.IO
Imports BL

Public Class CmpBankDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public frmstring As String        'Used from Displaying Customer, Vendor, Employee Master
    Public edit As Boolean = True

    Private Sub CmpBankDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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


                Dim OBJINVOICE As New ClsBankDetails()
                Dim DT As DataTable = OBJINVOICE.GETCMPBANKDTLS(CmpId)


                If DT.Rows.Count > 0 Then
                    For Each dr As DataRow In DT.Rows
                        TXTBANK.Text = Convert.ToString(dr("BANK"))
                        TXTACCNO.Text = Convert.ToString(dr("ACCNO"))
                        TXTBRANCH.Text = Convert.ToString(dr("BRANCH"))
                        TXTIFSC.Text = Convert.ToString(dr("IFSC"))

                        TXTBANK1.Text = Convert.ToString(dr("BANK1"))
                        TXTACCNO1.Text = Convert.ToString(dr("ACCNO1"))
                        TXTBRANCH1.Text = Convert.ToString(dr("BRANCH1"))
                        TXTIFSC1.Text = Convert.ToString(dr("IFSC1"))

                        TXTBANK2.Text = Convert.ToString(dr("BANK2"))
                        TXTACCNO2.Text = Convert.ToString(dr("ACCNO2"))
                        TXTBRANCH2.Text = Convert.ToString(dr("BRANCH2"))
                        TXTIFSC2.Text = Convert.ToString(dr("IFSC2"))
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

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(TXTBANK.Text.Trim)
            alParaval.Add(TXTACCNO.Text.Trim)
            alParaval.Add(TXTBRANCH.Text.Trim)
            alParaval.Add(TXTIFSC.Text.Trim)

            alParaval.Add(TXTBANK1.Text.Trim)
            alParaval.Add(TXTACCNO1.Text.Trim)
            alParaval.Add(TXTBRANCH1.Text.Trim)
            alParaval.Add(TXTIFSC1.Text.Trim)

            alParaval.Add(TXTBANK2.Text.Trim)
            alParaval.Add(TXTACCNO2.Text.Trim)
            alParaval.Add(TXTBRANCH2.Text.Trim)
            alParaval.Add(TXTIFSC2.Text.Trim)
            alParaval.Add(CmpId)

            Dim objAccountsMaster As New ClsBankDetails
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
            TXTBANK.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        'If CMBNAME.Text.Trim.Length = 0 Then
        '    EP.SetError(CMBNAME, "Fill Party Name")
        '    bln = False
        'End If

        'If GRIDBOOKINGS.RowCount = 0 Then
        '    EP.SetError(GRIDBOOKINGS, "Fill The Grid")
        '    bln = False
        'End If
        Return bln
    End Function

    Sub clear()

        TXTBANK.Clear()
        TXTACCNO.Clear()
        TXTBRANCH.Clear()
        TXTIFSC.Clear()
        TXTBANK1.Clear()
        TXTACCNO1.Clear()
        TXTBRANCH1.Clear()
        TXTIFSC1.Clear()
        TXTBANK2.Clear()
        TXTACCNO2.Clear()
        TXTBRANCH2.Clear()
        TXTIFSC2.Clear()

        'edit = False
    End Sub

    Private Sub CMDCLEAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        Try
            clear()
            edit = False

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class