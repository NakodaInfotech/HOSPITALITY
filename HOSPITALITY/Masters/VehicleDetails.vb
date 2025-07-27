
Imports BL

Public Class VehicleDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub VehicleDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.E Then       'for Saving
                Call cmdedit_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.N) Or (e.Alt = True And e.KeyCode = Windows.Forms.Keys.A) Then       'for AddNew 
                Call cmdadd_Click(sender, e)
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub VehicleDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'VEHICLE MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            fillgridname()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Sub fillgridname()
        Dim OBJVEHICLE As New ClsCommon
        Dim dttable As DataTable = OBJVEHICLE.search(" ISNULL(VEHICLETYPEMASTER.VEHICLETYPE_NAME,'') AS TYPE, VEHICLEMASTER.VEHICLE_NAME AS NAME ", "", " VEHICLEMASTER LEFT OUTER JOIN VEHICLETYPEMASTER ON VEHICLEMASTER.VEHICLE_TYPEID = VEHICLETYPEMASTER.VEHICLETYPE_ID AND VEHICLEMASTER.VEHICLE_CMPID = VEHICLETYPEMASTER.VEHICLETYPE_CMPID AND VEHICLEMASTER.VEHICLE_LOCATIONID = VEHICLETYPEMASTER.VEHICLETYPE_LOCATIONID AND VEHICLEMASTER.VEHICLE_YEARID = VEHICLETYPEMASTER.VEHICLETYPE_YEARID", " AND VEHICLE_CMPID =" & CmpId & " AND VEHICLE_LOCATIONID = " & Locationid & " AND VEHICLE_YEARID = " & YearId)
        gridname.DataSource = dttable
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Try
            showform(True, gridledger.GetFocusedRowCellValue("NAME"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal name As String)
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If (editval = False) Or (editval = True And gridledger.RowCount > 0) Then
                Dim OBJVEHICLE As New VehicleMaster
                OBJVEHICLE.MdiParent = MDIMain
                OBJVEHICLE.edit = editval
                OBJVEHICLE.TEMPVEHICLENAME = name
                OBJVEHICLE.Show()
                'Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            showform(False, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridledger_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridledger.DoubleClick
        Try
            showform(True, gridledger.GetFocusedRowCellValue("NAME"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            fillgridname()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class