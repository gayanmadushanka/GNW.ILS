using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Pervation.Presentation.DashBoard.Chart.Linear
{
    public partial class ExampleL
    {
        private readonly DashBoardLinkEnum _dashBoardLinkEnum;
        private readonly ExampleLViewModel _exampleViewModel;
        public ExampleL(ChartData chartData, DashBoardLinkEnum dashBoardLinkEnum)
        {
            InitializeComponent();
            _dashBoardLinkEnum = dashBoardLinkEnum;
            _exampleViewModel = DataContext as ExampleLViewModel;
            if (_exampleViewModel != null && chartData != null)
            {
                //_exampleViewModel.ChartData = chartData;
                if (chartData.SeriesOneData != null)
                    _exampleViewModel.Collection1 = chartData.SeriesOneData.CategoryValuePairList;
                if (chartData.SeriesTwoData != null)
                    _exampleViewModel.Collection2 = chartData.SeriesTwoData.CategoryValuePairList;
                if (chartData.SeriesThreeData != null)
                    _exampleViewModel.Collection3 = chartData.SeriesThreeData.CategoryValuePairList;
                if (chartData.SeriesFourData != null)
                    _exampleViewModel.Collection4 = chartData.SeriesFourData.CategoryValuePairList;
                if (chartData.SeriesOneData != null)
                    _exampleViewModel.AxisMaxValue = chartData.SeriesOneData.CategoryValuePairList.Max(x => x.Value) + 200;
            }
        }

        private void BtnDaily_OnClick(object sender, RoutedEventArgs e)
        {
            //RadCartesianChart.LegendItems.RemoveAt(2);
            LoadChart('D');
        }

        private void BtnWeekly_OnClick(object sender, RoutedEventArgs e)
        {
            LoadChart('W');
        }

        private void BtnMonthly_OnClick(object sender, RoutedEventArgs e)
        {
            LoadChart('M');
        }

        private void BtnYearly_OnClick(object sender, RoutedEventArgs e)
        {
            LoadChart('Y');
        }

        private void LoadChart(char type)
        {
            switch (_dashBoardLinkEnum)
            {
                case DashBoardLinkEnum.SAN:

                    break;
                case DashBoardLinkEnum.CAN:

                    break;
                case DashBoardLinkEnum.CWS:
                    List<SeriesData> companyWiseSale = GetCompanyWiseSale(type);
                    _exampleViewModel.Collection1 = companyWiseSale[0].CategoryValuePairList;
                    _exampleViewModel.Collection2 = companyWiseSale[1].CategoryValuePairList;
                    _exampleViewModel.Collection3 = companyWiseSale[2].CategoryValuePairList;
                    _exampleViewModel.Collection4 = companyWiseSale[3].CategoryValuePairList;
                    //_exampleViewModel.AxisMaxValue = _exampleViewModel.ChartData.SeriesOneData.CategoryValuePairList.Max(x => x.Value) + 200;
                    break;
            }
        }
    }
}
