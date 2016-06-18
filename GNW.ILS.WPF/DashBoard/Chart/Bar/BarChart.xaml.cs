using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Input;
using Pervation.Presentation.GridData;

namespace Pervation.Presentation.DashBoard.Chart.Bar
{
    public partial class BarChart
    {
        private readonly DashBoardLinkEnum _dashBoardLinkEnum;
        private readonly BarChartViewModel _barChartViewModel;
        private DataLoadTypeEnum _dataLoadTypeEnum;
        private bool _isApplyLegendState;

        public BarChart(ChartData chartData, DashBoardLinkEnum dashBoardLinkEnum)
        {
            InitializeComponent();

            _barChartViewModel = DataContext as BarChartViewModel;
            if (_barChartViewModel != null && chartData != null)
            {
                _dashBoardLinkEnum = dashBoardLinkEnum;
                _barChartViewModel.ChartData = chartData;
                BtnDaily.IsChecked = true;
                //_barChartViewModel.AxisMaxValue = chartData.SeriesOneData.CategoryValuePairList.Max(x => x.Value) + 200;
            }
        }

        private void BtnDaily_OnClick(object sender, RoutedEventArgs e)
        {
            //RadCartesianChart.LegendItems.RemoveAt(2);
            _dataLoadTypeEnum = DataLoadTypeEnum.Daily;
            LoadChart(_dataLoadTypeEnum.ToString());
        }

        private void BtnWeekly_OnClick(object sender, RoutedEventArgs e)
        {
            _dataLoadTypeEnum = DataLoadTypeEnum.Weekly;
            LoadChart(_dataLoadTypeEnum.ToString());
        }

        private void BtnMonthly_OnClick(object sender, RoutedEventArgs e)
        {
            _dataLoadTypeEnum = DataLoadTypeEnum.Monthly;
            LoadChart(_dataLoadTypeEnum.ToString());
        }

        private void BtnYearly_OnClick(object sender, RoutedEventArgs e)
        {
            _dataLoadTypeEnum = DataLoadTypeEnum.Yearly;
            LoadChart(_dataLoadTypeEnum.ToString());
        }

        private void LoadChart(string type)
        {
            switch (_dashBoardLinkEnum)
            {
                case DashBoardLinkEnum.SAN:
                    break;
                case DashBoardLinkEnum.CAN:
                    break;
                case DashBoardLinkEnum.LWS:
                    break;
                case DashBoardLinkEnum.CWS:
                    DataTable dataTable = GetCompanyWiseSale(type);
                    List<SeriesData> companyWiseSale = ToGetSeriesData(_dataLoadTypeEnum, dataTable);
                    _barChartViewModel.ChartData.SeriesOneData = companyWiseSale[0];
                    _barChartViewModel.ChartData.SeriesTwoData = companyWiseSale[1];
                    _barChartViewModel.ChartData.SeriesThreeData = companyWiseSale[2];
                    _barChartViewModel.ChartData.SeriesFourData = companyWiseSale[3];
                    break;
                case DashBoardLinkEnum.CUO:
                    break;
                case DashBoardLinkEnum.FMI:
                    break;
                case DashBoardLinkEnum.SMI:
                    break;
                case DashBoardLinkEnum.TCU:
                    break;
                case DashBoardLinkEnum.CWC:
                    break;
                case DashBoardLinkEnum.SWS:
                    break;
                case DashBoardLinkEnum.RWS:
                    break;
                case DashBoardLinkEnum.CWSR:
                    break;
                case DashBoardLinkEnum.CWSV:
                    break;
            }
        }

        private void BarChart_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ToLoadBottomGrid(new GridDataView(_dashBoardLinkEnum, _dataLoadTypeEnum.ToString()));
        }

        private void Btnlegend_OnClick(object sender, RoutedEventArgs e)
        {
            if (!_isApplyLegendState)
            {
                _isApplyLegendState = true;
                VisualStateManager.GoToState(this, "LegendPopOpenVisualState", true);
            }
            else
            {
                _isApplyLegendState = false;
                VisualStateManager.GoToState(this, "LegendPopCloseVisualState", true);
            }
        }
    }
}
