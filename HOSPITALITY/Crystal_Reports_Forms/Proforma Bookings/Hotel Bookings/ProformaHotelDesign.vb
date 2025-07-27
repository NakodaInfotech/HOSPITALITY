
Imports BL
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class ProformaHotelDesign

    Dim RPTVOUCHER As New ProformaBookingVoucher_COMMON
    Dim RPTINVOICE As New ProformaBookingInvoice_COMMON

    Public strsearch As String
    Public SUBJECT As String
    Public FRMSTRING As String
    Public MTDC As Boolean = False
    Public BOOKINGNO As Integer
    Public LETTERHEAD As Integer = 0
    Public BOOKTYPE As String
    Public PRINTGUESTNAME As Boolean
    Public HIDEAMT As Boolean
    Public PRINTST As Boolean
    Public HIDEHEADER As Boolean
    Public GUESTNAME As String = ""
    Public DIRECTPRINT As Boolean = False
    Public DIRECTMAIL As Boolean = False
    Public NOOFCOPIES As Integer = 1
    Public PRINTSETTING As Object = Nothing

    Private Sub ProformaHotelDesign_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try

            If DIRECTPRINT = True Then
                PRINTDIRECTLYTOPRINTER()
                Exit Sub
            End If



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
                .ServerName = SERVERNAME
                .DatabaseName = DatabaseName
                .UserID = DBUSERNAME
                .Password = Dbpassword
                .IntegratedSecurity = Dbsecurity
            End With

            If FRMSTRING = "VOUCHER" Then
                Me.Text = "Hotel Booking Voucher"
                crTables = RPTVOUCHER.Database.Tables

            ElseIf FRMSTRING = "INVOICE" Then
                Me.Text = "Hotel Booking Proforma Invoice"
                crTables = RPTINVOICE.Database.Tables
            End If


            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next
            strsearch = strsearch & " {PROFORMAHOTELBOOKINGMASTER.BOOKING_NO}= " & BOOKINGNO & " AND {PROFORMAHOTELBOOKINGMASTER.BOOKING_BOOKTYPE}= '" & BOOKTYPE & "' and {PROFORMAHOTELBOOKINGMASTER.BOOKING_yearid}=" & YearId
            CRPO.SelectionFormula = strsearch

            If FRMSTRING = "VOUCHER" Then
                CRPO.ReportSource = RPTVOUCHER
            ElseIf FRMSTRING = "INVOICE" Then
                CRPO.ReportSource = RPTINVOICE
                If PRINTGUESTNAME = True Then RPTINVOICE.DataDefinition.FormulaFields("PRINTGUEST").Text = 1 Else RPTINVOICE.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                If HIDEAMT = True Then RPTINVOICE.DataDefinition.FormulaFields("PRINTAMT").Text = 0 Else RPTINVOICE.DataDefinition.FormulaFields("PRINTAMT").Text = 1
            End If

            CRPO.Zoom(100)
            CRPO.Refresh()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTDIRECTLYTOPRINTER()
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
                .ServerName = SERVERNAME
                .DatabaseName = DatabaseName
                .UserID = DBUSERNAME
                .Password = Dbpassword
                .IntegratedSecurity = Dbsecurity
            End With

            strsearch = strsearch & " {PROFORMAHOTELBOOKINGMASTER.BOOKING_NO}= " & BOOKINGNO & " AND {PROFORMAHOTELBOOKINGMASTER.BOOKING_BOOKTYPE}= '" & BOOKTYPE & "' and {PROFORMAHOTELBOOKINGMASTER.BOOKING_yearid}=" & YearId
            CRPO.SelectionFormula = strsearch

            Dim OBJ As New Object
            Dim OBJOLD As New Object
            If FRMSTRING = "INVOICE" Then
                Me.Text = "Hotel Booking Proforma Invoice"
                OBJ = New HotelBookingInvoice_COMMON
            End If

            crTables = OBJ.Database.Tables
            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            OBJ.RecordSelectionFormula = strsearch
            'OBJ.PrintToPrinter(1, True, 0, 0)
            If DIRECTMAIL = False Then
                OBJ.PrintOptions.PrinterName = PRINTSETTING.PrinterSettings.PrinterName
                OBJ.PrintToPrinter(Val(NOOFCOPIES), True, 0, 0)
            Else
                Dim expo As New ExportOptions
                Dim oDfDopt As New DiskFileDestinationOptions
                oDfDopt.DiskFileName = Application.StartupPath & "\PROFORMA_" & BOOKINGNO & ".pdf"
                expo = OBJ.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                OBJ.Export()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub sendmailtool_Click(sender As Object, e As EventArgs) Handles sendmailtool.Click
        Try
            Dim emailid As String = ""
            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            Transfer()
            Dim tempattachment As String = ""
            If FRMSTRING = "VOUCHER" Then tempattachment = "Reservation Voucher No. " & BOOKINGNO Else tempattachment = "Proforma Invoice No. " & BOOKINGNO


            Dim objmail As New SendMail
            objmail.attachment = Application.StartupPath & "\" & tempattachment & ".PDF"
            If SUBJECT = "" Then objmail.subject = tempattachment Else objmail.subject = SUBJECT
            If emailid <> "" Then objmail.cmbfirstadd.Text = emailid


            'FOR SENCOND EMAIL ID
            If ClientName = "TOPCOMM" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" HOTELMASTER.HOTEL_EMAILID AS EMAILID", "", "  PROFORMAHOTELBOOKINGMASTER INNER JOIN HOTELMASTER ON PROFORMAHOTELBOOKINGMASTER.BOOKING_HOTELID = HOTELMASTER.HOTEL_ID AND PROFORMAHOTELBOOKINGMASTER.BOOKING_CMPID = HOTELMASTER.HOTEL_CMPID AND PROFORMAHOTELBOOKINGMASTER.BOOKING_LOCATIONID = HOTELMASTER.HOTEL_LOCATIONID AND PROFORMAHOTELBOOKINGMASTER.BOOKING_YEARID = HOTELMASTER.HOTEL_YEARID ", " AND BOOKING_NO = " & BOOKINGNO & " AND BOOKING_CMPID = " & CmpId & " AND BOOKING_LOCATIONID = " & Locationid & " AND BOOKING_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then objmail.cmbsecondadd.Text = DT.Rows(0).Item("EMAILID")
            End If
            objmail.GUESTNAME = GUESTNAME
            objmail.Show()
            objmail.BringToFront()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub Transfer()
        Try
            Dim expo As New ExportOptions
            Dim oDfDopt As New DiskFileDestinationOptions
            If FRMSTRING = "VOUCHER" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\Reservation Voucher No. " & BOOKINGNO & ".PDF"
                expo = RPTVOUCHER.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTVOUCHER.Export()
            Else
                oDfDopt.DiskFileName = Application.StartupPath & "\Proforma Invoice No. " & BOOKINGNO & ".PDF"
                RPTINVOICE.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                expo = RPTINVOICE.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTINVOICE.Export()
                RPTINVOICE.DataDefinition.FormulaFields("SENDMAIL").Text = 0
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class