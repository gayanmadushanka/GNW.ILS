using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Pervation.Presentation.DashBoard.Chart.Bar;
using Pervation.Presentation.DashBoard.Chart.Linear;
using Pervation.Presentation.DashBoard.Chart.Pie;
using Pervation.Presentation.Delegate;
using Pervation.Presentation._Basic_Windows.CommonMessage;
using Telerik.Windows.Controls;

namespace Pervation.Presentation.DashBoard.Chart
{
    /// <summary>
    /// Interaction logic for uc_MainChart.xaml
    /// </summary>
    public partial class uc_MainChart : INotifyPropertyChanged
    {
        private readonly GridTypeEnum _gridType;
        private ChartTypeEnum _chartType;
        private readonly List<RadRadioButton> _radRadioButtonList = new List<RadRadioButton>();
        private List<SeriesData> _seriesDataList;
        private DashBoardLinkEnum _dashBoardLinkEnum;
        private string _dashBoardLinkText;
        private bool _isAutoButtonClick;

        private string _title;

        public new string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Title"));
            }
        }

        public event InsertDashBoardConfigRequest InsertDashBoardConfigEvent;

        public uc_MainChart(GridTypeEnum gridType, ChartTypeEnum chartType)
        {
            _gridType = gridType;
            _chartType = chartType;
            InitializeComponent();
            SetRadRadioButtonList();
            SetGrid(gridType, chartType);
            DataContext = this;
        }

        private void SetRadRadioButtonList()
        {
            _radRadioButtonList.Add(BtnBarChart);
            _radRadioButtonList.Add(BtnLinearChart);
            _radRadioButtonList.Add(BtnPiChart);
        }

        public void SetGrid(GridTypeEnum gridType, ChartTypeEnum chartType = ChartTypeEnum.NODATA, DashBoardLinkEnum dashBoardLinkEnum = DashBoardLinkEnum.NODATA, string title = "")
        {
            _dashBoardLinkEnum = dashBoardLinkEnum;
            _dashBoardLinkText = title;
            _chartType = chartType;
            switch (gridType)
            {
                case GridTypeEnum.GdChart1:
                    SetRadioButtonGroupName("ChartGroup1");
                    SetChart(_chartType);
                    break;
                case GridTypeEnum.GdChart2:
                    SetRadioButtonGroupName("ChartGroup2");
                    SetChart(_chartType);
                    break;
                case GridTypeEnum.GdChart3:
                    SetRadioButtonGroupName("ChartGroup3");
                    SetChart(_chartType);
                    break;
                case GridTypeEnum.GdChart4:
                    SetRadioButtonGroupName("ChartGroup4");
                    SetChart(_chartType);
                    break;
            }
        }

        private void SetChart(ChartTypeEnum chartType)
        {
            _isAutoButtonClick = true;
            switch (chartType)
            {
                case ChartTypeEnum.PI:
                    //SetDashBoardLink();
                    GetChartData();
                    BtnPiChart.IsChecked = true;
                    break;
                case ChartTypeEnum.BAR:
                    //SetDashBoardLink();
                    GetChartData();
                    BtnBarChart.IsChecked = true;
                    break;
                case ChartTypeEnum.LINEAR:
                    //SetDashBoardLink();
                    GetChartData();
                    BtnLinearChart.IsChecked = true;
                    break;
                case ChartTypeEnum.NODATA:
                    BtnPiChart.IsChecked = true;
                    break;
            }
        }

        private void SetRadioButtonGroupName(string chartgroup)
        {
            BtnPiChart.GroupName = chartgroup;
            BtnBarChart.GroupName = chartgroup;
            BtnLinearChart.GroupName = chartgroup;
        }

        private new void AddViewToGrid(UserControl userControl)
        {
            try
            {
                GdChart.Children.Clear();
                GdChart.Children.Add(userControl);
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show(ex.Message);
            }
        }

        private void Uc_MainChart_OnDrop(object sender, DragEventArgs e)
        {
            Link link = e.Data.GetData(typeof(Link)) as Link;
            if (link == null) return;
            _dashBoardLinkText = link.Text;
            _dashBoardLinkEnum = (DashBoardLinkEnum)link.LinkEnum;
            //SetDashBoardLink();
            GetChartData();
            if (InsertDashBoardConfigEvent != null)
                InsertDashBoardConfigEvent(_gridType, _chartType, _dashBoardLinkEnum, _dashBoardLinkText);
        }

        //private void SetDashBoardLink()
        //{
        //    switch (_dashBoardLinkEnum)
        //    {
        //        case DashBoardLinkEnum.SAN:
        //            _seriesDataList = GetSalesAnalysis();
        //            LoadChart(GetChartData(_seriesDataList));
        //            break;
        //        case DashBoardLinkEnum.CAN:
        //            _seriesDataList = GetCostAnalysis();
        //            LoadChart(GetChartData(_seriesDataList));
        //            break;
        //        case DashBoardLinkEnum.LWS:
        //            _seriesDataList = GetCompanyWiseSale('D');
        //            LoadChart(GetChartData(_seriesDataList));
        //            break;
        //        case DashBoardLinkEnum.CWS:
        //            _seriesDataList = GetCompanyWiseSale('D');
        //            LoadChart(GetChartData(_seriesDataList));
        //            break;
        //    }
        //}

        //private ChartData GetChartData(List<SeriesData> seriesDataList)
        //{
        //    switch (_dashBoardLinkEnum)
        //    {
        //        case DashBoardLinkEnum.SAN:
        //            return new ChartData(_dashBoardLinkText, "Quantity", Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, seriesDataList[0]);
        //        case DashBoardLinkEnum.CAN:
        //            return new ChartData(_dashBoardLinkText, "Quantity", Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, seriesDataList[0]);
        //        case DashBoardLinkEnum.LWS:
        //            return new ChartData(_dashBoardLinkText, "Amount", Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Collapsed, seriesDataList[0], seriesDataList[1], seriesDataList[2], seriesDataList[3]);
        //        case DashBoardLinkEnum.CWS:
        //            return new ChartData(_dashBoardLinkText, "Amount", Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, seriesDataList[0], seriesDataList[1], seriesDataList[2], seriesDataList[3]);
        //        case DashBoardLinkEnum.CUO:
        //            return new ChartData(_dashBoardLinkText, "Amount", Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, seriesDataList[0], seriesDataList[1], seriesDataList[2], seriesDataList[3]);
        //        case DashBoardLinkEnum.FMI:
        //            return new ChartData(_dashBoardLinkText, "Amount", Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, seriesDataList[0], seriesDataList[1], seriesDataList[2], seriesDataList[3]);
        //        case DashBoardLinkEnum.SMI:
        //            return new ChartData(_dashBoardLinkText, "Amount", Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, seriesDataList[0], seriesDataList[1], seriesDataList[2], seriesDataList[3]);
        //        case DashBoardLinkEnum.TCU:
        //            return new ChartData(_dashBoardLinkText, "Amount", Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, seriesDataList[0], seriesDataList[1], seriesDataList[2], seriesDataList[3]);
        //        case DashBoardLinkEnum.CWC:
        //            return new ChartData(_dashBoardLinkText, "Amount", Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, seriesDataList[0], seriesDataList[1], seriesDataList[2], seriesDataList[3]);
        //        case DashBoardLinkEnum.SWS:
        //            return new ChartData(_dashBoardLinkText, "Amount", Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, seriesDataList[0], seriesDataList[1], seriesDataList[2], seriesDataList[3]);
        //        case DashBoardLinkEnum.RWS:
        //            return new ChartData(_dashBoardLinkText, "Amount", Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, seriesDataList[0], seriesDataList[1], seriesDataList[2], seriesDataList[3]);
        //        case DashBoardLinkEnum.CWSR:
        //            return new ChartData(_dashBoardLinkText, "Amount", Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, seriesDataList[0], seriesDataList[1], seriesDataList[2], seriesDataList[3]);
        //        case DashBoardLinkEnum.CWSV:
        //            return new ChartData(_dashBoardLinkText, "Amount", Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, seriesDataList[0], seriesDataList[1], seriesDataList[2], seriesDataList[3]);
        //    }
        //    return null;
        //}

        private void GetChartData()
        {
            Title = _dashBoardLinkText;
            switch (_dashBoardLinkEnum)
            {
                case DashBoardLinkEnum.SAN:
                    //_seriesDataList = GetSalesAnalysis();
                    //LoadChart(new ChartData("Quantity", Visibility.Collapsed, Visibility.Visible, Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, _seriesDataList[0]));
                    break;
                case DashBoardLinkEnum.CAN:
                    //_seriesDataList = GetCostAnalysis();
                    //LoadChart(new ChartData("Quantity", Visibility.Collapsed, Visibility.Visible, Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, _seriesDataList[0]));
                    break;
                case DashBoardLinkEnum.LWS:
                    _seriesDataList = ToGetSeriesData(DataLoadTypeEnum.Daily, GetCompanyWiseSale(DataLoadTypeEnum.Daily.ToString()));
                    LoadChart(new ChartData("Amount", Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Collapsed, Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Collapsed, _seriesDataList[0], _seriesDataList[1], _seriesDataList[2], _seriesDataList[3]));
                    break;
                case DashBoardLinkEnum.CWS:
                    _seriesDataList = ToGetSeriesData(DataLoadTypeEnum.Daily, GetCompanyWiseSale(DataLoadTypeEnum.Daily.ToString()));
                    LoadChart(new ChartData("Amount", Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, _seriesDataList[0], _seriesDataList[1], _seriesDataList[2], _seriesDataList[3]));
                    break;
                case DashBoardLinkEnum.CUO:
                    _seriesDataList = ToGetSeriesData(DataLoadTypeEnum.Daily, GetCompanyWiseSale(DataLoadTypeEnum.Daily.ToString()));
                    LoadChart(new ChartData("Amount", Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Collapsed, Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, _seriesDataList[0], _seriesDataList[1], _seriesDataList[2], _seriesDataList[3]));
                    break;
                case DashBoardLinkEnum.FMI:
                    _seriesDataList = ToGetSeriesData(DataLoadTypeEnum.Daily, GetCompanyWiseSale(DataLoadTypeEnum.Daily.ToString()));
                    LoadChart(new ChartData("Amount", Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Collapsed, Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, _seriesDataList[0], _seriesDataList[1], _seriesDataList[2], _seriesDataList[3]));
                    break;
                case DashBoardLinkEnum.SMI:
                    _seriesDataList = ToGetSeriesData(DataLoadTypeEnum.Daily, GetCompanyWiseSale(DataLoadTypeEnum.Daily.ToString()));
                    LoadChart(new ChartData("Amount", Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Collapsed, Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, _seriesDataList[0], _seriesDataList[1], _seriesDataList[2], _seriesDataList[3]));
                    break;
                case DashBoardLinkEnum.TCU:
                    _seriesDataList = ToGetSeriesData(DataLoadTypeEnum.Daily, GetCompanyWiseSale(DataLoadTypeEnum.Daily.ToString()));
                    LoadChart(new ChartData("Amount", Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Collapsed, Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, _seriesDataList[0], _seriesDataList[1], _seriesDataList[2], _seriesDataList[3]));
                    break;
                case DashBoardLinkEnum.CWC:
                    _seriesDataList = ToGetSeriesData(DataLoadTypeEnum.Daily, GetCompanyWiseSale(DataLoadTypeEnum.Daily.ToString()));
                    LoadChart(new ChartData("Amount", Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, _seriesDataList[0], _seriesDataList[1], _seriesDataList[2], _seriesDataList[3]));
                    break;
                case DashBoardLinkEnum.SWS:
                    _seriesDataList = ToGetSeriesData(DataLoadTypeEnum.Daily, GetCompanyWiseSale(DataLoadTypeEnum.Daily.ToString()));
                    LoadChart(new ChartData("Amount", Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Collapsed, Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, _seriesDataList[0], _seriesDataList[1], _seriesDataList[2], _seriesDataList[3]));
                    break;
                case DashBoardLinkEnum.RWS:
                    _seriesDataList = ToGetSeriesData(DataLoadTypeEnum.Daily, GetCompanyWiseSale(DataLoadTypeEnum.Daily.ToString()));
                    LoadChart(new ChartData("Amount", Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Collapsed, Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, _seriesDataList[0], _seriesDataList[1], _seriesDataList[2], _seriesDataList[3]));
                    break;
                case DashBoardLinkEnum.CWSR:
                    _seriesDataList = ToGetSeriesData(DataLoadTypeEnum.Daily, GetCompanyWiseSale(DataLoadTypeEnum.Daily.ToString()));
                    LoadChart(new ChartData("Amount", Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, _seriesDataList[0], _seriesDataList[1], _seriesDataList[2], _seriesDataList[3]));
                    break;
                case DashBoardLinkEnum.CWSV:
                    _seriesDataList = ToGetSeriesData(DataLoadTypeEnum.Daily, GetCompanyWiseSale(DataLoadTypeEnum.Daily.ToString()));
                    LoadChart(new ChartData("Amount", Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, _seriesDataList[0], _seriesDataList[1], _seriesDataList[2], _seriesDataList[3]));
                    break;
                case DashBoardLinkEnum.NODATA:
                    LoadChart(new ChartData("", Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed));
                    break;
            }
        }

        private void LoadChart(ChartData chartData)
        {
            switch (_chartType)
            {
                case ChartTypeEnum.PI:
                    AddViewToGrid(new PieChart(chartData, _dashBoardLinkEnum));
                    break;
                case ChartTypeEnum.BAR:
                    AddViewToGrid(new BarChart(chartData, _dashBoardLinkEnum));
                    break;
                case ChartTypeEnum.LINEAR:
                    AddViewToGrid(new LinearChart(chartData, _dashBoardLinkEnum));
                    break;
            }
        }

        private void BtnPiChart_OnChecked(object sender, RoutedEventArgs e)
        {
            _chartType = ChartTypeEnum.PI;
            GetChartData();
            //LoadChart(GetChartData(_seriesDataList));
            if (!_isAutoButtonClick && InsertDashBoardConfigEvent != null && _chartType != ChartTypeEnum.NODATA && _dashBoardLinkEnum != DashBoardLinkEnum.NODATA)
                InsertDashBoardConfigEvent(_gridType, _chartType, _dashBoardLinkEnum, _dashBoardLinkText);
            _isAutoButtonClick = false;
        }

        private void BtnBarChart_OnChecked(object sender, RoutedEventArgs e)
        {
            _chartType = ChartTypeEnum.BAR;
            GetChartData();
            //LoadChart(GetChartData(_seriesDataList));
            if (!_isAutoButtonClick && InsertDashBoardConfigEvent != null && _chartType != ChartTypeEnum.NODATA && _dashBoardLinkEnum != DashBoardLinkEnum.NODATA)
                InsertDashBoardConfigEvent(_gridType, _chartType, _dashBoardLinkEnum, _dashBoardLinkText);
            _isAutoButtonClick = false;
        }

        private void BtnLinearChart_OnChecked(object sender, RoutedEventArgs e)
        {
            _chartType = ChartTypeEnum.LINEAR;
            GetChartData();
            //LoadChart(GetChartData(_seriesDataList));
            if (!_isAutoButtonClick && InsertDashBoardConfigEvent != null && _chartType != ChartTypeEnum.NODATA && _dashBoardLinkEnum != DashBoardLinkEnum.NODATA)
                InsertDashBoardConfigEvent(_gridType, _chartType, _dashBoardLinkEnum, _dashBoardLinkText);
            _isAutoButtonClick = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

