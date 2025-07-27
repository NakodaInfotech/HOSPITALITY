
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared

Public Class GroupDepartureDesign

    Dim RPTPASS As New PassengerListReport_RAMKRISHNA
    Dim RPTHOTELLIST As New ListOfHotelsReport_RAMKRISHNA
    Public FRMSTRING As String = ""
    Public STRSEARCH As String = ""

    Private Sub GroupDepartureDesign_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        End If
    End Sub

    Private Sub GroupDepartureDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
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

            If FRMSTRING = "PASSLIST" Then
                crTables = RPTPASS.Database.Tables
            ElseIf FRMSTRING = "HOTELLIST" Then
                crTables = RPTHOTELLIST.Database.Tables
            End If


            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next


            '************************ END *******************
            CRPO.SelectionFormula = STRSEARCH

            If FRMSTRING = "PASSLIST" Then
                CRPO.ReportSource = RPTPASS
            ElseIf FRMSTRING = "HOTELLIST" Then
                CRPO.ReportSource = RPTHOTELLIST
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
            Dim TEMPATTACHMENT As String = ""

            If FRMSTRING = "PASSLIST" Then
                TEMPATTACHMENT = "PASSANGER LIST TOURWISE"
            ElseIf FRMSTRING = "HOTELLIST" Then
                TEMPATTACHMENT = "HOTEL LIST"
            End If

            Dim objmail As New SendMail
            objmail.attachment = Application.StartupPath & "\" & TEMPATTACHMENT & ".PDF"
            If emailid <> "" Then
                objmail.cmbfirstadd.Text = emailid
            End If
            objmail.subject = TEMPATTACHMENT
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

            If FRMSTRING = "PASSLIST" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\PASSANGER LIST TOURWISE.PDF"
                expo = RPTPASS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPASS.Export()
            ElseIf FRMSTRING = "HOTELLIST" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\HOTEL LIST.PDF"
                expo = RPTHOTELLIST.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTHOTELLIST.Export()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class