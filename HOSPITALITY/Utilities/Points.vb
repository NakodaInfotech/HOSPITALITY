
Imports BL

Public Class Points

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("USERPOINTS", "", "POINTS", "")
            If DT.Rows.Count > 0 Then DT = OBJCMN.Execute_Any_String(" UPDATE POINTS SET USERPOINTS = " & Val(TXTUSERPOINTS.Text.Trim) & ", REFPOINTS = " & Val(TXTREFPOINTS.Text.Trim) & "", "", "") Else DT = OBJCMN.Execute_Any_String(" INSERT INTO POINTS VALUES (" & Val(TXTUSERPOINTS.Text.Trim) & "," & Val(TXTREFPOINTS.Text.Trim) & ")", "", "")
            MsgBox("Details Updated")
            Me.Close()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OpeningClosingStock_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OpeningClosingStock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("ISNULL(USERPOINTS,0) AS USERPOINTS, ISNULL(REFPOINTS,0) AS REFPOINTS", "", " POINTS ", "")
            If DT.Rows.Count > 0 Then
                TXTUSERPOINTS.Text = Val(DT.Rows(0).Item("USERPOINTS"))
                TXTREFPOINTS.Text = Val(DT.Rows(0).Item("REFPOINTS"))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTREFPOINTS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTREFPOINTS.KeyPress, TXTUSERPOINTS.KeyPress
        numkeypress(e, sender, Me)
    End Sub
End Class