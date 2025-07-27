
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO
Imports BL

Public Class TourDesign

    'Dim RPTPASS As New PassangerListTourWise1
    'Dim RPTITS As New ITSNO6
    'Dim RPTBMM As New BMM15
    'Dim RPTIRAQ As New IraqVisaMenifest9
    'Dim RPTPENDINGDOCS As New PendingDocs6
    'Dim RPTDECLARE As New Declaration11
    'Dim RPTITENARY As New Itenary19
    'Dim RPTPASSPORTPHOTO As New PassportPhoto
    'Dim RPTPHOTOCOPY As New PhotoCopyPassenger
    'Dim RPTPASSLBL As New PassportLablePrinting
    'Dim RPTIDCARD As New IDCardPrinting
    'Dim RPTBAGTAG As New BaggageTagsReport
    'Dim RPTGIFTSALE As New GiftOutReport
    'Dim RPTGIFTPURCHASE As New GiftPurchaseReport
    'Dim RPTSAFAI As New SafaiChitti
    'Dim RPTITSCOPY As New ITSCopyPassenger
    'Dim RPTEMBARK As New EmbarkationForm
    'Dim RPTVISAFORM As New VisaForm
    'Dim RPTVISAFORM2 As New VisaForm2
    'Dim RPTCASH As New CashChequeReport
    'Dim RPTGIFTPENDING As New GiftReport
    'Dim RPTREGINVOICE As New Registration_Invoice

    Public FRMSTRING As String
    Public PERIOD As String
    Public LEADER As String
    Public COUNTRY As String
    Public CITY As String
    Public GIFT As String
    Public TOTALPAX, CHILD, ADULT, INFANT, MALE, FEMALE As Integer

    Public SRNOFORVISAFORM As Integer = 0
    Public REGNO As Integer
    Public AIRTICKET As Integer
    Public FOREIGN As Integer
    Public SERVICECHGS As Integer
    Public INWORDS As String

    Public strsearch As String
    Dim tempattachment As String

    Private Sub TourDesign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            'If FRMSTRING = "PASSLIST" Then
            '    crTables = RPTPASS.Database.Tables
            'ElseIf FRMSTRING = "ITSLIST" Then
            '    crTables = RPTITS.Database.Tables
            'ElseIf FRMSTRING = "BMM" Then
            '    crTables = RPTBMM.Database.Tables
            'ElseIf FRMSTRING = "IRAQ" Then
            '    crTables = RPTIRAQ.Database.Tables
            'ElseIf FRMSTRING = "PENDING" Then
            '    crTables = RPTPENDINGDOCS.Database.Tables
            'ElseIf FRMSTRING = "DECLARE" Then
            '    crTables = RPTDECLARE.Database.Tables
            'ElseIf FRMSTRING = "ITENARY" Then
            '    crTables = RPTITENARY.Database.Tables
            'ElseIf FRMSTRING = "PASSPORTPHOTO" Then
            '    crTables = RPTPASSPORTPHOTO.Database.Tables
            'ElseIf FRMSTRING = "PHOTOCOPY" Then
            '    crTables = RPTPHOTOCOPY.Database.Tables
            'ElseIf FRMSTRING = "PASSLABLE" Then
            '    crTables = RPTPASSLBL.Database.Tables
            'ElseIf FRMSTRING = "IDCARD" Then
            '    crTables = RPTIDCARD.Database.Tables
            'ElseIf FRMSTRING = "BAGTAG" Then
            '    crTables = RPTBAGTAG.Database.Tables
            'ElseIf FRMSTRING = "GIFTSALE" Then
            '    crTables = RPTGIFTSALE.Database.Tables
            'ElseIf FRMSTRING = "GIFTPURCHASE" Then
            '    crTables = RPTGIFTPURCHASE.Database.Tables
            'ElseIf FRMSTRING = "SAFAI" Then
            '    crTables = RPTSAFAI.Database.Tables
            'ElseIf FRMSTRING = "ITSCOPY" Then
            '    crTables = RPTITSCOPY.Database.Tables
            'ElseIf FRMSTRING = "EMBARK" Then
            '    crTables = RPTEMBARK.Database.Tables
            'ElseIf FRMSTRING = "VISAFORM" Then
            '    crTables = RPTVISAFORM.Database.Tables
            'ElseIf FRMSTRING = "VISAFORM2" Then
            '    crTables = RPTVISAFORM2.Database.Tables
            'ElseIf FRMSTRING = "CASH" Then
            '    crTables = RPTCASH.Database.Tables
            'ElseIf FRMSTRING = "GIFTPENDING" Then
            '    crTables = RPTGIFTPENDING.Database.Tables
            'ElseIf FRMSTRING = "INVOICE" Then
            '    crTables = RPTREGINVOICE.Database.Tables
            'End If


            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next


            '************************ END *******************
            CRPO.SelectionFormula = strsearch
            'If FRMSTRING = "BMM" Then

            'RPTBMM.DataDefinition.FormulaFields("LEADER").Text = "'" & LEADER & "'"
            'RPTBMM.DataDefinition.FormulaFields("CHILD").Text = "'" & CHILD & "'"
            'RPTBMM.DataDefinition.FormulaFields("INFANT").Text = "'" & INFANT & "'"
            'RPTBMM.DataDefinition.FormulaFields("ADULT").Text = "'" & ADULT & "'"
            'RPTBMM.DataDefinition.FormulaFields("TOTALPAX").Text = "'" & TOTALPAX & "'"
            'RPTBMM.DataDefinition.FormulaFields("COUNTRY").Text = "'" & COUNTRY & "'"

            'ElseIf FRMSTRING = "ITENARY" Then
            '    RPTITENARY.DataDefinition.FormulaFields("LEADER").Text = "'" & LEADER & "'"

            'ElseIf FRMSTRING = "DECLARE" Then
            '    RPTDECLARE.DataDefinition.FormulaFields("CITY").Text = "'" & CITY & "'"

            'ElseIf FRMSTRING = "GIFTPENDING" Then
            '    RPTGIFTPENDING.DataDefinition.FormulaFields("GIFT").Text = "'" & GIFT & "'"

            'ElseIf FRMSTRING = "INVOICE" Then
            '    RPTREGINVOICE.DataDefinition.FormulaFields("AIRTICKET").Text = AIRTICKET
            '    RPTREGINVOICE.DataDefinition.FormulaFields("FOREIGN").Text = FOREIGN
            '    RPTREGINVOICE.DataDefinition.FormulaFields("SERVICECHGS").Text = SERVICECHGS
            '    RPTREGINVOICE.DataDefinition.FormulaFields("INWORDS").Text = "'" & INWORDS & "'"

            'ElseIf FRMSTRING = "IRAQ" Then
            '    RPTIRAQ.DataDefinition.FormulaFields("CHILD").Text = "'" & CHILD & "'"
            '    RPTIRAQ.DataDefinition.FormulaFields("INFANT").Text = "'" & INFANT & "'"
            '    RPTIRAQ.DataDefinition.FormulaFields("ADULT").Text = "'" & ADULT & "'"
            '    RPTIRAQ.DataDefinition.FormulaFields("MALE").Text = "'" & MALE & "'"
            '    RPTIRAQ.DataDefinition.FormulaFields("FEMALE").Text = "'" & FEMALE & "'"
            '    RPTIRAQ.DataDefinition.FormulaFields("TOTALPAX").Text = "'" & TOTALPAX & "'"
            'End If

            'If FRMSTRING = "PASSLIST" Then
            '    CRPO.ReportSource = RPTPASS
            'ElseIf FRMSTRING = "ITSLIST" Then
            '    CRPO.ReportSource = RPTITS
            'ElseIf FRMSTRING = "BMM" Then
            '    CRPO.ReportSource = RPTBMM
            'ElseIf FRMSTRING = "IRAQ" Then
            '    CRPO.ReportSource = RPTIRAQ
            'ElseIf FRMSTRING = "PENDING" Then
            '    CRPO.ReportSource = RPTPENDINGDOCS
            'ElseIf FRMSTRING = "DECLARE" Then
            '    CRPO.ReportSource = RPTDECLARE
            'ElseIf FRMSTRING = "ITENARY" Then
            '    CRPO.ReportSource = RPTITENARY
            'ElseIf FRMSTRING = "PASSPORTPHOTO" Then
            '    CRPO.ReportSource = RPTPASSPORTPHOTO
            'ElseIf FRMSTRING = "PHOTOCOPY" Then
            '    CRPO.ReportSource = RPTPHOTOCOPY
            'ElseIf FRMSTRING = "PASSLABLE" Then
            '    CRPO.ReportSource = RPTPASSLBL
            'ElseIf FRMSTRING = "IDCARD" Then
            '    CRPO.ReportSource = RPTIDCARD
            'ElseIf FRMSTRING = "BAGTAG" Then
            '    CRPO.ReportSource = RPTBAGTAG
            'ElseIf FRMSTRING = "GIFTSALE" Then
            '    CRPO.ReportSource = RPTGIFTSALE
            'ElseIf FRMSTRING = "GIFTPURCHASE" Then
            '    CRPO.ReportSource = RPTGIFTPURCHASE
            'ElseIf FRMSTRING = "SAFAI" Then
            '    CRPO.ReportSource = RPTSAFAI
            'ElseIf FRMSTRING = "ITSCOPY" Then
            '    CRPO.ReportSource = RPTITSCOPY
            'ElseIf FRMSTRING = "EMBARK" Then
            '    CRPO.ReportSource = RPTEMBARK
            'ElseIf FRMSTRING = "VISAFORM" Then
            '    CRPO.ReportSource = RPTVISAFORM
            '    If SRNOFORVISAFORM > 0 Then RPTVISAFORM.DataDefinition.FormulaFields("SRNO").Text = SRNOFORVISAFORM
            'ElseIf FRMSTRING = "VISAFORM2" Then
            '    CRPO.ReportSource = RPTVISAFORM2
            'ElseIf FRMSTRING = "CASH" Then
            '    CRPO.ReportSource = RPTCASH
            'ElseIf FRMSTRING = "GIFTPENDING" Then
            '    CRPO.ReportSource = RPTGIFTPENDING
            'ElseIf FRMSTRING = "INVOICE" Then
            '    CRPO.ReportSource = RPTREGINVOICE
            'End If

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

            If FRMSTRING = "PASSLIST" Then
                tempattachment = "PASSANGER LIST TOURWISE"
            ElseIf FRMSTRING = "ITSLIST" Then
                tempattachment = "ITS LIST TOURWISE"
            ElseIf FRMSTRING = "BMM" Then
                tempattachment = "BMM"
            ElseIf FRMSTRING = "IRAQ" Then
                tempattachment = "IRAQ"
            ElseIf FRMSTRING = "PENDING" Then
                tempattachment = "PENDING"
            ElseIf FRMSTRING = "DECLARE" Then
                tempattachment = "DECLARE"
            ElseIf FRMSTRING = "ITENARY" Then
                tempattachment = "ITENARY"
            ElseIf FRMSTRING = "PASSPORTPHOTO" Then
                tempattachment = "PASSPORTPHOTO"
            ElseIf FRMSTRING = "PHOTOCOPY" Then
                tempattachment = "PHOTOCOPY"
            ElseIf FRMSTRING = "PASSLABLE" Then
                tempattachment = "PASSPORT LABLE"
            ElseIf FRMSTRING = "IDCARD" Then
                tempattachment = "ID CARD"
            ElseIf FRMSTRING = "BAGTAG" Then
                tempattachment = "BAGGAGE TAG"
            ElseIf FRMSTRING = "GIFTSALE" Then
                tempattachment = "GIFT REGISTERED"
            ElseIf FRMSTRING = "GIFTPURCHASE" Then
                tempattachment = "GIFT PURCHASE"
            ElseIf FRMSTRING = "SAFAI" Then
                tempattachment = "SAFAI CHITTI"
            ElseIf FRMSTRING = "ITSCOPY" Then
                tempattachment = "ITS COPY"
            ElseIf FRMSTRING = "EMBARK" Then
                tempattachment = "EMBARKATION"
            ElseIf FRMSTRING = "VISAFORM" Then
                tempattachment = "VISA FORM"
            ElseIf FRMSTRING = "VISAFORM2" Then
                tempattachment = "VISA FORM2"
            ElseIf FRMSTRING = "CASH" Then
                tempattachment = "CASH CHEQUE"
            ElseIf FRMSTRING = "GIFTPENDING" Then
                tempattachment = "GIFT PENDING"
            ElseIf FRMSTRING = "INVOICE" Then
                tempattachment = "INVOICE"
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

            'If FRMSTRING = "PASSLIST" Then
            '    oDfDopt.DiskFileName = Application.StartupPath & "\PASSANGER LIST TOURWISE.PDF"
            '    expo = RPTPASS.ExportOptions
            '    expo.ExportDestinationType = ExportDestinationType.DiskFile
            '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
            '    expo.DestinationOptions = oDfDopt
            '    RPTPASS.Export()
            'ElseIf FRMSTRING = "ITSLIST" Then
            '    oDfDopt.DiskFileName = Application.StartupPath & "\ITS LIST TOURWISE.PDF"
            '    expo = RPTITS.ExportOptions
            '    expo.ExportDestinationType = ExportDestinationType.DiskFile
            '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
            '    expo.DestinationOptions = oDfDopt
            '    RPTITS.Export()
            'ElseIf FRMSTRING = "BMM" Then
            '    oDfDopt.DiskFileName = Application.StartupPath & "\BMM.PDF"
            '    expo = RPTBMM.ExportOptions
            '    expo.ExportDestinationType = ExportDestinationType.DiskFile
            '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
            '    expo.DestinationOptions = oDfDopt
            '    RPTBMM.Export()
            'ElseIf FRMSTRING = "IRAQ" Then
            '    oDfDopt.DiskFileName = Application.StartupPath & "\IRAQ.PDF"
            '    expo = RPTIRAQ.ExportOptions
            '    expo.ExportDestinationType = ExportDestinationType.DiskFile
            '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
            '    expo.DestinationOptions = oDfDopt
            '    RPTIRAQ.Export()
            'ElseIf FRMSTRING = "PENDING" Then
            '    oDfDopt.DiskFileName = Application.StartupPath & "\PENDINGDOCS.PDF"
            '    expo = RPTPENDINGDOCS.ExportOptions
            '    expo.ExportDestinationType = ExportDestinationType.DiskFile
            '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
            '    expo.DestinationOptions = oDfDopt
            '    RPTPENDINGDOCS.Export()
            'ElseIf FRMSTRING = "DECLARE" Then
            '    oDfDopt.DiskFileName = Application.StartupPath & "\DECLARE.PDF"
            '    expo = RPTDECLARE.ExportOptions
            '    expo.ExportDestinationType = ExportDestinationType.DiskFile
            '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
            '    expo.DestinationOptions = oDfDopt
            '    RPTDECLARE.Export()
            'ElseIf FRMSTRING = "ITENARY" Then
            '    oDfDopt.DiskFileName = Application.StartupPath & "\ITENARY.PDF"
            '    expo = RPTITENARY.ExportOptions
            '    expo.ExportDestinationType = ExportDestinationType.DiskFile
            '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
            '    expo.DestinationOptions = oDfDopt
            '    RPTITENARY.Export()
            'ElseIf FRMSTRING = "PASSPORTPHOTO" Then
            '    oDfDopt.DiskFileName = Application.StartupPath & "\PASSPORTPHOTO.PDF"
            '    expo = RPTPASSPORTPHOTO.ExportOptions
            '    expo.ExportDestinationType = ExportDestinationType.DiskFile
            '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
            '    expo.DestinationOptions = oDfDopt
            '    RPTPASSPORTPHOTO.Export()
            'ElseIf FRMSTRING = "PHOTOCOPY" Then
            '    oDfDopt.DiskFileName = Application.StartupPath & "\PHOTOCOPY.PDF"
            '    expo = RPTPHOTOCOPY.ExportOptions
            '    expo.ExportDestinationType = ExportDestinationType.DiskFile
            '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
            '    expo.DestinationOptions = oDfDopt
            '    RPTPHOTOCOPY.Export()
            'ElseIf FRMSTRING = "PASSLABLE" Then
            '    oDfDopt.DiskFileName = Application.StartupPath & "\PASSPORT LABLE.PDF"
            '    expo = RPTPASSLBL.ExportOptions
            '    expo.ExportDestinationType = ExportDestinationType.DiskFile
            '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
            '    expo.DestinationOptions = oDfDopt
            '    RPTPASSLBL.Export()
            'ElseIf FRMSTRING = "IDCARD" Then
            '    oDfDopt.DiskFileName = Application.StartupPath & "\ID CARD.PDF"
            '    expo = RPTIDCARD.ExportOptions
            '    expo.ExportDestinationType = ExportDestinationType.DiskFile
            '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
            '    expo.DestinationOptions = oDfDopt
            '    RPTIDCARD.Export()
            'ElseIf FRMSTRING = "BAGTAG" Then
            '    oDfDopt.DiskFileName = Application.StartupPath & "\BAGGAGE TAG.PDF"
            '    expo = RPTBAGTAG.ExportOptions
            '    expo.ExportDestinationType = ExportDestinationType.DiskFile
            '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
            '    expo.DestinationOptions = oDfDopt
            '    RPTBAGTAG.Export()
            'ElseIf FRMSTRING = "GIFTSALE" Then
            '    oDfDopt.DiskFileName = Application.StartupPath & "\GIFT REGISTERED.PDF"
            '    expo = RPTGIFTSALE.ExportOptions
            '    expo.ExportDestinationType = ExportDestinationType.DiskFile
            '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
            '    expo.DestinationOptions = oDfDopt
            '    RPTGIFTSALE.Export()
            'ElseIf FRMSTRING = "GIFTPURCHASE" Then
            '    oDfDopt.DiskFileName = Application.StartupPath & "\GIFT PURCHASE.PDF"
            '    expo = RPTGIFTSALE.ExportOptions
            '    expo.ExportDestinationType = ExportDestinationType.DiskFile
            '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
            '    expo.DestinationOptions = oDfDopt
            '    RPTGIFTPURCHASE.Export()
            'ElseIf FRMSTRING = "SAFAI" Then
            '    oDfDopt.DiskFileName = Application.StartupPath & "\SAFAI CHITTI.PDF"
            '    expo = RPTSAFAI.ExportOptions
            '    expo.ExportDestinationType = ExportDestinationType.DiskFile
            '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
            '    expo.DestinationOptions = oDfDopt
            '    RPTSAFAI.Export()
            'ElseIf FRMSTRING = "ITSCOPY" Then
            '    oDfDopt.DiskFileName = Application.StartupPath & "\ITS COPY.PDF"
            '    expo = RPTITSCOPY.ExportOptions
            '    expo.ExportDestinationType = ExportDestinationType.DiskFile
            '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
            '    expo.DestinationOptions = oDfDopt
            '    RPTITSCOPY.Export()
            'ElseIf FRMSTRING = "EMBARK" Then
            '    oDfDopt.DiskFileName = Application.StartupPath & "\EMBARKATION.PDF"
            '    expo = RPTEMBARK.ExportOptions
            '    expo.ExportDestinationType = ExportDestinationType.DiskFile
            '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
            '    expo.DestinationOptions = oDfDopt
            '    RPTEMBARK.Export()
            'ElseIf FRMSTRING = "VISAFORM" Then
            '    oDfDopt.DiskFileName = Application.StartupPath & "\VISA FORM.PDF"
            '    expo = RPTVISAFORM.ExportOptions
            '    expo.ExportDestinationType = ExportDestinationType.DiskFile
            '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
            '    expo.DestinationOptions = oDfDopt
            '    RPTVISAFORM.Export()
            'ElseIf FRMSTRING = "VISAFORM2" Then
            '    oDfDopt.DiskFileName = Application.StartupPath & "\VISA FORM2.PDF"
            '    expo = RPTVISAFORM2.ExportOptions
            '    expo.ExportDestinationType = ExportDestinationType.DiskFile
            '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
            '    expo.DestinationOptions = oDfDopt
            '    RPTVISAFORM2.Export()
            'ElseIf FRMSTRING = "CASH" Then
            '    oDfDopt.DiskFileName = Application.StartupPath & "\CASH CHEQUE.PDF"
            '    expo = RPTCASH.ExportOptions
            '    expo.ExportDestinationType = ExportDestinationType.DiskFile
            '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
            '    expo.DestinationOptions = oDfDopt
            '    RPTCASH.Export()
            'ElseIf FRMSTRING = "GIFTPENDING" Then
            '    oDfDopt.DiskFileName = Application.StartupPath & "\GIFT PENDING.PDF"
            '    expo = RPTCASH.ExportOptions
            '    expo.ExportDestinationType = ExportDestinationType.DiskFile
            '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
            '    expo.DestinationOptions = oDfDopt
            '    RPTGIFTPENDING.Export()
            'ElseIf FRMSTRING = "INVOICE" Then
            '    oDfDopt.DiskFileName = Application.StartupPath & "\INVOICE.PDF"
            '    expo = RPTREGINVOICE.ExportOptions
            '    expo.ExportDestinationType = ExportDestinationType.DiskFile
            '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
            '    expo.DestinationOptions = oDfDopt
            '    RPTREGINVOICE.Export()
            'End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub TourDesign_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        End If
    End Sub

End Class