Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO

Public Class PrintBlankForm

    Public FRMSTRING As String = ""
    Public STRSEARCH As String = ""
    Dim RPTPRINTGUSETDTLS As New PrintGuestDetailForm
    Dim RPTPRINTGUSETDTLS_FINASTA As New PrintGuestDetailForm_FINASTA
    Dim RPTPASSPORT As New PassportPhoto_Guest
    'Dim RPTITS As New ITSCopyPassenger
    'Dim RPTSAFAICHITTI As New SafaiChitti
    'Dim RPTTOURDOCUMENT As New TourDocumentReport
    'Dim RPTCARQUOTE As New CarRateReport

    Private Sub PrintBlankForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub PrintBlankForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Cursor.Current = Cursors.WaitCursor

            '**************** SET SERVER ************************
            Dim crtableLogonInfo As New TableLogOnInfo
            Dim crConnecttionInfo As New ConnectionInfo
            Dim crTables As Tables
            Dim crTable As Table


            With crConnecttionInfo
                .ServerName = SERVERNAME
                .DatabaseName = DatabaseName
                .UserID = DBUSERNAME
                .Password = Dbpassword
                .IntegratedSecurity = Dbsecurity
            End With

            If FRMSTRING = "GUESTFORM" Then
                If ClientName = "FINASTA" Then
                    crTables = RPTPRINTGUSETDTLS_FINASTA.Database.Tables
                Else
                    crTables = RPTPRINTGUSETDTLS.Database.Tables
                End If
            ElseIf FRMSTRING = "PASSPORT" Then
                crTables = RPTPASSPORT.Database.Tables
                'ElseIf FRMSTRING = "ITSCOPY" Then
                '    crTables = RPTITS.Database.Tables
                'ElseIf FRMSTRING = "SAFAICHITTI" Then
                '    crTables = RPTSAFAICHITTI.Database.Tables
                'ElseIf FRMSTRING = "TOURDOCUMENT" Then
                '    crTables = RPTTOURDOCUMENT.Database.Tables
            ElseIf FRMSTRING = "CARQUOTE" Then
                'crTables = RPTCARQUOTE.Database.Tables
            End If


            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            If FRMSTRING = "GUESTFORM" Then
                If ClientName = "FINASTA" Then
                    RPTPRINTGUSETDTLS_FINASTA.RecordSelectionFormula = STRSEARCH
                    crpo.ReportSource = RPTPRINTGUSETDTLS_FINASTA
                Else
                    crpo.ReportSource = RPTPRINTGUSETDTLS
                End If
            ElseIf FRMSTRING = "PASSPORT" Then
                RPTPASSPORT.RecordSelectionFormula = STRSEARCH
                crpo.ReportSource = RPTPASSPORT
                'ElseIf FRMSTRING = "ITSCOPY" Then
                '    RPTITS.RecordSelectionFormula = STRSEARCH
                '    crpo.ReportSource = RPTITS
                'ElseIf FRMSTRING = "SAFAICHITTI" Then
                '    RPTSAFAICHITTI.RecordSelectionFormula = STRSEARCH
                '    crpo.ReportSource = RPTSAFAICHITTI
                'ElseIf FRMSTRING = "TOURDOCUMENT" Then
                '    RPTTOURDOCUMENT.RecordSelectionFormula = STRSEARCH
                '    crpo.ReportSource = RPTTOURDOCUMENT
            ElseIf FRMSTRING = "CARQUOTE" Then
                'RPTCARQUOTE.RecordSelectionFormula = STRSEARCH
                'crpo.ReportSource = RPTCARQUOTE
            End If
            crpo.Zoom(100)
            crpo.Refresh()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub
End Class