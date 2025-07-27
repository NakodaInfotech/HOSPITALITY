
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO

Public Class InternationalVoucherDesign

    Dim rptvoucher As New InternationalVoucher
    Dim rptINVOICE As New InternationalInvoice

    Public strsearch As String
    Public FRMSTRING As String
    Public BOOKINGNO As Integer
    Public PRINTGUESTNAME As Boolean
    Public HIDEAMT As Boolean
    Public HIDEtransamt As Boolean
    Public hideheader As Boolean
    Public SUBJECT As String
    Public GUESTNAME As String = ""

    Private Sub InternationalBookingVoucher_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim crParameterFieldDefinitions As ParameterFieldDefinitions
            Dim crParameterFieldDefinition As ParameterFieldDefinition
            Dim crParameterValues As New ParameterValues
            Dim crParameterDiscreteValue As New ParameterDiscreteValue

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

            If FRMSTRING = "VOUCHER" Then
                Me.Text = "International Booking Voucher"
                If ClientName = "CLASSIC" Then
                    crTables = rptvoucher.Database.Tables
                End If
            ElseIf FRMSTRING = "INVOICE" Then
                Me.Text = "International Booking Invoice"
                If ClientName = "CLASSIC" Then
                    crTables = rptINVOICE.Database.Tables
                End If
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next
            strsearch = strsearch & " {INTERNATIONALBOOKINGMASTER.BOOKING_NO}= " & BOOKINGNO & " AND {INTERNATIONALBOOKINGMASTER.BOOKING_cmpid}=" & CmpId & " and {INTERNATIONALBOOKINGMASTER.BOOKING_locationid}=" & Locationid & " and {INTERNATIONALBOOKINGMASTER.BOOKING_yearid}=" & YearId
            CRPO.SelectionFormula = strsearch
            If FRMSTRING = "VOUCHER" Then
                If ClientName = "CLASSIC" Then
                    CRPO.ReportSource = rptvoucher
                End If
            ElseIf FRMSTRING = "INVOICE" Then
                If ClientName = "CLASSIC" Then
                    CRPO.ReportSource = rptINVOICE

                    If PRINTGUESTNAME = True Then
                        rptINVOICE.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        rptINVOICE.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If
                    If HIDEAMT = True Then
                        rptINVOICE.Subreports("INTERNATIONALBOOKING_REPORT").DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    Else
                        rptINVOICE.Subreports("INTERNATIONALBOOKING_REPORT").DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    End If

                End If
            End If
            CRPO.Zoom(100)
            CRPO.Refresh()

        Catch Exp As LoadSaveReportException
            MsgBox("Incorrect path for loading report.", _
                    MsgBoxStyle.Critical, "Load Report Error")

        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")

        End Try
    End Sub

    Private Sub sendmailtool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendmailtool.Click
        Dim emailid As String = ""
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Transfer()
        Dim tempattachment As String

        If FRMSTRING = "VOUCHER" Then
            tempattachment = "Reservation Voucher No. " & BOOKINGNO
        ElseIf FRMSTRING = "INVOICE" Then
            tempattachment = "Invoice No. " & BOOKINGNO
        End If

        Try
            Dim objmail As New SendMail
            objmail.attachment = Application.StartupPath & "\" & tempattachment & ".PDF"
            objmail.subject = tempattachment
            If emailid <> "" Then
                objmail.cmbfirstadd.Text = emailid
            End If
            objmail.GUESTNAME = GUESTNAME
            objmail.Show()
            objmail.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
        Windows.Forms.Cursor.Current = Cursors.Arrow
    End Sub

    Sub Transfer()
        Try
            Dim expo As New ExportOptions
            Dim oDfDopt As New DiskFileDestinationOptions

            If FRMSTRING = "VOUCHER" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\Reservation Voucher No. " & BOOKINGNO & ".PDF"
                If ClientName = "CLASSIC" Then
                    expo = rptvoucher.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    rptvoucher.Export()
                End If

            ElseIf FRMSTRING = "INVOICE" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\Invoice No. " & BOOKINGNO & ".PDF"
                If ClientName = "CLASSIC" Then
                    expo = rptINVOICE.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    rptINVOICE.Export()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

End Class