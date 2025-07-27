
Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports DevExpress.XtraCharts
Imports BL

Public Class AnalyticalCharts

    Protected seriesSelected As Series = Nothing
    Protected pointSelected As SeriesPoint = Nothing
    Protected selectedAnotherObject As Object = Nothing

    Private Sub AnalyticalCharts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            FILLDATA()
        Catch ex As Exception
            Throw ex
        End Try


        'TODO: This line of code loads data into the 'DataSet1.CITYMASTER' table. You can move, or remove it, as needed.
        '' Me.CITYMASTERTableAdapter.Fill(Me.DataSet1.CITYMASTER)
        'TODO: This line of code loads data into the 'DataSet1.DataTable1' table. You can move, or remove it, as needed.
        ''Me.DataTable1TableAdapter.Fill(Me.DataSet1.BOOKEDBY)
    End Sub

    Sub FILLDATA()
        Dim OBJCMN As New ClsCommon

        Dim DTBOOKEDBY As DataTable = OBJCMN.search("  BOOKEDBYMASTER.BOOKEDBY_NAME AS [Booked By], SUM(HOTELBOOKINGMASTER.BOOKING_GRANDTOTAL) AS [Total Sale], HOTELBOOKINGMASTER.BOOKING_BOOKEDBYID AS BOOKEDBYID", "", "   BOOKEDBYMASTER INNER JOIN HOTELMASTER INNER JOIN HOTELBOOKINGMASTER ON HOTELMASTER.HOTEL_ID = HOTELBOOKINGMASTER.BOOKING_HOTELID AND HOTELMASTER.HOTEL_CMPID = HOTELBOOKINGMASTER.BOOKING_CMPID AND HOTELMASTER.HOTEL_LOCATIONID = HOTELBOOKINGMASTER.BOOKING_LOCATIONID AND HOTELMASTER.HOTEL_YEARID = HOTELBOOKINGMASTER.BOOKING_YEARID ON BOOKEDBYMASTER.BOOKEDBY_CMPID = HOTELBOOKINGMASTER.BOOKING_CMPID AND BOOKEDBYMASTER.BOOKEDBY_LOCATIONID = HOTELBOOKINGMASTER.BOOKING_LOCATIONID AND BOOKEDBYMASTER.BOOKEDBY_YEARID = HOTELBOOKINGMASTER.BOOKING_YEARID AND BOOKEDBYMASTER.BOOKEDBY_ID = HOTELBOOKINGMASTER.BOOKING_BOOKEDBYID  ", " AND BOOKING_CANCELLED = 'FALSE' AND BOOKING_AMD_DONE = 'FALSE' GROUP BY BOOKEDBYMASTER.BOOKEDBY_NAME, HOTELBOOKINGMASTER.BOOKING_BOOKEDBYID")
        If DTBOOKEDBY.Rows.Count > 0 Then
            BookedSeries.DataSource = DTBOOKEDBY

            BookedSeries.ArgumentDataMember = "Booked By"
            BookedSeries.ValueDataMembers.Item(0) = "Total Sale"
        End If


        Dim DTCITY As DataTable = OBJCMN.search(" CITYMASTER.city_name AS CITY, SUM(HOTELBOOKINGMASTER.BOOKING_GRANDTOTAL) AS [Total Sale], HOTELBOOKINGMASTER.BOOKING_BOOKEDBYID AS BOOKEDBYID ", "", " HOTELBOOKINGMASTER INNER JOIN HOTELMASTER ON HOTELBOOKINGMASTER.BOOKING_HOTELID = HOTELMASTER.HOTEL_ID AND HOTELBOOKINGMASTER.BOOKING_CMPID = HOTELMASTER.HOTEL_CMPID AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = HOTELMASTER.HOTEL_LOCATIONID AND HOTELBOOKINGMASTER.BOOKING_YEARID = HOTELMASTER.HOTEL_YEARID INNER JOIN CITYMASTER ON HOTELMASTER.HOTEL_CITYID = CITYMASTER.city_id AND HOTELMASTER.HOTEL_CMPID = CITYMASTER.city_cmpid AND HOTELMASTER.HOTEL_LOCATIONID = CITYMASTER.city_locationid AND HOTELMASTER.HOTEL_YEARID = CITYMASTER.city_yearid ", " AND BOOKING_CANCELLED = 'FALSE' AND BOOKING_AMD_DONE = 'FALSE' GROUP BY CITYMASTER.city_name, HOTELBOOKINGMASTER.BOOKING_BOOKEDBYID")
        If DTCITY.Rows.Count > 0 Then
            CitySeries.DataSource = DTCITY

            CitySeries.ArgumentDataMember = "CITY"
            CitySeries.ValueDataMembers.Item(0) = "Total Sale"
        End If

    End Sub

    Private ReadOnly Property BookedSeries() As Series
        Get
            Return PIECHART.GetSeriesByName("Booked")
        End Get
    End Property

    Private ReadOnly Property CitySeries() As Series
        Get
            Return PIECHART.GetSeriesByName("City")
        End Get
    End Property

    Private ReadOnly Property HotelSeries() As Series
        Get
            Return PIECHART.GetSeriesByName("Hotel")
        End Get
    End Property

    Private ReadOnly Property IsBookedChart() As Boolean
        Get
            If BookedSeries Is Nothing Then
                Return False
            Else
                Return BookedSeries.Visible
            End If
        End Get
    End Property

    Protected ReadOnly Property SeriesSelection() As Boolean
        Get
            Return IsBookedChart
        End Get
    End Property

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitCityChart(ByVal point As SeriesPoint)
        If Not BookedSeries Is Nothing AndAlso Not CitySeries Is Nothing Then
            BookedSeries.Visible = False
            CitySeries.DataFilters.Add("BOOKEDBYID", "INTEGER", DataFilterCondition.Equal, "")
            CitySeries.DataFilters(0).Value = CInt(Fix((CType(point.Tag, DataRowView))("BOOKEDBYID")))
            CitySeries.LegendText = point.Argument
            If TypeOf CitySeries.View Is XYDiagramSeriesViewBase Then
                Dim axisX As AxisXBase = (CType(CitySeries.View, XYDiagramSeriesViewBase)).AxisX
                axisX.Label.Angle = 30
                axisX.Label.Antialiasing = True
                Dim axisY As AxisYBase = (CType(CitySeries.View, XYDiagramSeriesViewBase)).AxisY
                axisY.Title.Text = "Grand Total, INR"
                axisY.Title.Visible = True
            End If
            PIECHART.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Left
            PIECHART.Legend.AlignmentVertical = LegendAlignmentVertical.Top
            If (PIECHART.Titles.Count > 1) Then
                PIECHART.Titles(0).Visible = False
                PIECHART.Titles(1).Visible = True
            End If
        End If
    End Sub

    Private Sub InitBookedChart()
        If Not BookedSeries Is Nothing Then
            BookedSeries.Visible = True
            PIECHART.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.RightOutside
            PIECHART.Legend.AlignmentVertical = LegendAlignmentVertical.Center
            If (PIECHART.Titles.Count > 1) Then
                PIECHART.Titles(0).Visible = True
                PIECHART.Titles(1).Visible = False
            End If
        End If
    End Sub

    Protected Function AllowSelectAnotherObject(ByVal obj As Object) As Boolean
        Return (Not IsBookedChart) AndAlso (TypeOf obj Is ChartTitle)
    End Function

    Public Sub UpdateControls()
        'MyBase.UpdateControls()
        If IsBookedChart Then
            If Not Me.seriesSelected Is Nothing AndAlso Not Me.pointSelected Is Nothing Then
                InitCityChart(Me.pointSelected)
                Me.seriesSelected = Nothing
            End If
        Else
            If TypeOf Me.selectedAnotherObject Is ChartTitle Then
                InitBookedChart()
                Me.selectedAnotherObject = Nothing
            End If
        End If
    End Sub

    Protected Overridable Sub Chart_ObjectHotTracked(ByVal sender As Object, ByVal e As HotTrackEventArgs) Handles PIECHART.ObjectHotTracked
        If TypeOf e.Object Is Series Then
            e.Cancel = Not SeriesSelection
        Else
            e.Cancel = Not AllowSelectAnotherObject(e.Object)
        End If
    End Sub

    Protected Overridable Sub Chart_ObjectSelected(ByVal sender As Object, ByVal e As HotTrackEventArgs) Handles PIECHART.ObjectSelected
        If TypeOf e.Object Is Series Then
            e.Cancel = Not SeriesSelection
            If SeriesSelection Then
                Me.seriesSelected = CType(e.Object, Series)
                Me.pointSelected = TryCast(e.AdditionalObject, SeriesPoint)
            End If
        Else
            If AllowSelectAnotherObject(e.Object) Then
                Me.selectedAnotherObject = e.Object
                e.Cancel = False
            Else
                Me.selectedAnotherObject = Nothing
                e.Cancel = True
                PIECHART.ClearSelection(False)
            End If
            If SeriesSelection Then
                Me.seriesSelected = Nothing
                Me.pointSelected = Nothing
            End If
        End If
        UpdateControls()
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub CMDBACK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDBACK.Click
        Try
            InitBookedChart()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class