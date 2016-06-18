using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Input;
using Pervation.Presentation.GridData;

namespace Pervation.Presentation.DashBoard.Chart.Linear
{
    public partial class LinearChart
    {
        private readonly DashBoardLinkEnum _dashBoardLinkEnum;
        private readonly LinearChartViewModel _linearChartViewModel;
        private DataLoadTypeEnum _dataLoadTypeEnum;
        private bool _isApplyLegendState;

        public LinearChart(ChartData chartData, DashBoardLinkEnum dashBoardLinkEnum)
        {
            InitializeComponent();
            _dashBoardLinkEnum = dashBoardLinkEnum;
            _linearChartViewModel = DataContext as LinearChartViewModel;
            if (_linearChartViewModel != null && chartData != null)
            {
                _dashBoardLinkEnum = dashBoardLinkEnum;
                _linearChartViewModel.ChartData = chartData;
                BtnDaily.IsChecked = true;
                //_linearChartViewModel.AxisMaxValue = chartData.SeriesOneData.CategoryValuePairList.Max(x => x.Value) + 200;
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
                    _linearChartViewModel.ChartData.SeriesOneData = companyWiseSale[0];
                    _linearChartViewModel.ChartData.SeriesTwoData = companyWiseSale[1];
                    _linearChartViewModel.ChartData.SeriesThreeData = companyWiseSale[2];
                    _linearChartViewModel.ChartData.SeriesFourData = companyWiseSale[3];
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

        private void LinearChart_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
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
