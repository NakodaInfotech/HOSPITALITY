
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO
Imports BL

Public Class ReservationDetailsDesign

    Dim RPTBOOKEDBY As New BookedbyDetailsReport
    Dim RPTRESERVATION As New HotelReservationDtlsReport
    Dim RPTRESSUMM As New HotelResSummReport
    Dim RPTPACKDTLS As New PackageReservationDtls
    Dim RPTINTDTLS As New InternationalReservationDtls

    Public FRMSTRING As String
    Public PERIOD As String
    Public strsearch As String
    Dim tempattachment As String

    Private Sub ReservationDetailsDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            '**************** SET SERVER ************************
            Dim crtableLogonInfo As New TableLogOnInfo
            Dim crConnecttionInfo As New ConnectionInfo
            Dim crTables As Tables
            Dim crTable As Table


            With crConnecttionInfo
                .ServerName = Servername
                .DatabaseName = DatabaseName
                .UserID = DBUSERNAME
                .Password = Dbpassword
                .IntegratedSecurity = Dbsecurity
            End With

            If FRMSTRING = "SALEREPORT" Then
                crTables = RPTBOOKEDBY.Database.Tables
            ElseIf FRMSTRING = "RESERVATIONDETAILS" Then
                crTables = RPTRESERVATION.Database.Tables
            ElseIf FRMSTRING = "RESERVATIONSUMMARY" Then
                crTables = RPTRESSUMM.Database.Tables
            ElseIf FRMSTRING = "PACKAGEDETAILS" Then
                crTables = RPTPACKDTLS.Database.Tables
            ElseIf FRMSTRING = "INTERNATIONALDETAILS" Then
                crTables = RPTINTDTLS.Database.Tables
            End If


            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next


            '************************ END *******************
            CRPO.SelectionFormula = strsearch
            'RPTBOOKEDBY.DataDefinition.FormulaFields("PERIOD").Text = PERIOD

            If FRMSTRING = "SALEREPORT" Then
                CRPO.ReportSource = RPTBOOKEDBY
            ElseIf FRMSTRING = "RESERVATIONDETAILS" Then
                CRPO.ReportSource = RPTRESERVATION
            ElseIf FRMSTRING = "RESERVATIONSUMMARY" Then
                CRPO.ReportSource = RPTRESSUMM
            ElseIf FRMSTRING = "PACKAGEDETAILS" Then
                CRPO.ReportSource = RPTPACKDTLS
            ElseIf FRMSTRING = "INTERNATIONALDETAILS" Then
                CRPO.ReportSource = RPTINTDTLS
            End If
            CRPO.Zoom(100)
            CRPO.Refresh()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub sendmailtool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendmailtool.Click
        Try

            Dim emailid As String = ""
            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            Transfer()

            If FRMSTRING = "SALEREPORT" Then
                tempattachment = "SALE REPORT DETAILS"
            ElseIf FRMSTRING = "RESERVATIONDETAILS" Or FRMSTRING = "PACKAGEDETAILS" Or FRMSTRING = "INTERNATIONALDETAILS" Then
                tempattachment = "RESERVATION DETAILS"
            ElseIf FRMSTRING = "RESERVATIONSUMMARY" Then
                tempattachment = "RESERVATION SUMMARY"
            End If

            Dim objmail As New SendMail
            objmail.attachment = Application.StartupPath & "\" & tempattachment & ".PDF"
            If emailid <> "" Then
                objmail.cmbfirstadd.Text = emailid
            End If
            objmail.Show()
            objmail.BringToFront()
            Windows.Forms.Cursor.Current = Cursors.Arrow
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub Transfer()
        Try
            Dim expo As New ExportOptions
            Dim oDfDopt As New DiskFileDestinationOptions

            If FRMSTRING = "SALEREPORT" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\SALE REPORT DETAILS.PDF"
                expo = RPTBOOKEDBY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTBOOKEDBY.Export()
            ElseIf FRMSTRING = "RESERVATIONDETAILS" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\RESERVATION DETAILS.PDF"
                expo = RPTRESERVATION.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTRESERVATION.Export()
            ElseIf FRMSTRING = "RESERVATIONSUMMARY" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\RESERVATION SUMMARY.PDF"
                expo = RPTRESSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTRESSUMM.Export()
            ElseIf FRMSTRING = "PACKAGEDETAILS" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\RESERVATION DETAILS.PDF"
                expo = RPTPACKDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPACKDTLS.Export()
            ElseIf FRMSTRING = "INTERNATIONALDETAILS" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\RESERVATION DETAILS.PDF"
                expo = RPTINTDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTINTDTLS.Export()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

End Class