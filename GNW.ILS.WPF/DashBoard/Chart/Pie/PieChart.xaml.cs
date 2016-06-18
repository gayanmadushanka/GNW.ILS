using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Pervation.Presentation.GridData;
using Telerik.Windows.Controls;

namespace Pervation.Presentation.DashBoard.Chart.Pie
{
    /// <summary>
    /// Interaction logic for PieChart.xaml
    /// </summary>
    public partial class PieChart
    {
        private readonly DashBoardLinkEnum _dashBoardLinkEnum;
        private readonly PieChartViewModel _pieChartViewModel;
        private DataLoadTypeEnum _dataLoadTypeEnum;
        private string _selectedContentForRbGroup2;
        //private static int _radioButtonGroup1Num;
        //private static int _radioButtonGroup2Num;
        private bool _isApplyLegendState;

        public PieChart(ChartData chartData, DashBoardLinkEnum dashBoardLinkEnum)
        {
            InitializeComponent();
            _pieChartViewModel = DataContext as PieChartViewModel;
            if (_pieChartViewModel != null && chartData != null)
            {
                _pieChartViewModel.ChartData = chartData;
                if (dashBoardLinkEnum != DashBoardLinkEnum.NODATA)
                {
                    _dashBoardLinkEnum = dashBoardLinkEnum;
                    //SetRadioButtonGroup1Name((++_radioButtonGroup1Num).ToString(CultureInfo.InvariantCulture));
                    //SetRadioButtonGroup2Name((--_radioButtonGroup2Num).ToString(CultureInfo.InvariantCulture));
                    _dataLoadTypeEnum = DataLoadTypeEnum.Daily;
                    BtnDaily.IsChecked = true;
                    //RbG1Button1.IsChecked = true;
                    //RbG2Button1.IsChecked = true;
                }
            }
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
                    ToSetCompanyWiseSale(type);
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

        private void ToSetCompanyWiseSale(string type)
        {
            List<SeriesData> companyWiseSale = ToGetSeriesData(_dataLoadTypeEnum, GetCompanyWiseSale(type));
            switch (_selectedContentForRbGroup2)
            {
                case "Reckitt":
                    _pieChartViewModel.ChartData.SeriesOneData = companyWiseSale[0];
                    break;
                case "Nestle":
                    _pieChartViewModel.ChartData.SeriesOneData = companyWiseSale[1];
                    break;
                case "Maliban 1":
                    _pieChartViewModel.ChartData.SeriesOneData = companyWiseSale[2];
                    break;
                case "Maliban 2":
                    _pieChartViewModel.ChartData.SeriesOneData = companyWiseSale[3];
                    break;
            }
        }

        private void PieChart_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ToLoadBottomGrid(new GridDataView(_dashBoardLinkEnum, _dataLoadTypeEnum.ToString()));
        }

        //private void RbG2Button1_OnChecked(object sender, RoutedEventArgs e)
        //{
        //    _selectedContentForRbGroup2 = (sender as ComboBoxItem).Content.ToString();
        //    LoadChart(_dataLoadTypeEnum.ToString());
        //}

        //private void RbG2Button2_OnChecked(object sender, RoutedEventArgs e)
        //{
        //    _selectedContentForRbGroup2 = (sender as ComboBoxItem).Content.ToString();
        //    LoadChart(_dataLoadTypeEnum.ToString());
        //}

        //private void RbG2Button3_OnChecked(object sender, RoutedEventArgs e)
        //{
        //    _selectedContentForRbGroup2 = (sender as ComboBoxItem).Content.ToString();
        //    LoadChart(_dataLoadTypeEnum.ToString());
        //}

        //private void RbG2Button4_OnChecked(object sender, RoutedEventArgs e)
        //{
        //    _selectedContentForRbGroup2 = (sender as ComboBoxItem).Content.ToString();
        //    LoadChart(_dataLoadTypeEnum.ToString());
        //}

        //private void BtnDaily_OnClick(object sender, RoutedEventArgs e)
        //{
        //    _dataLoadTypeEnum = (DataLoadTypeEnum)Enum.Parse(typeof(DataLoadTypeEnum), (sender as RadRadioButton).Content.ToString());
        //    LoadChart(_dataLoadTypeEnum.ToString());
        //}

        //private void BtnWeekly_OnClick(object sender, RoutedEventArgs e)
        //{
        //    _dataLoadTypeEnum = (DataLoadTypeEnum)Enum.Parse(typeof(DataLoadTypeEnum), (sender as RadRadioButton).Content.ToString());
        //    LoadChart(_dataLoadTypeEnum.ToString());
        //}

        //private void BtnMonthly_OnClick(object sender, RoutedEventArgs e)
        //{
        //    _dataLoadTypeEnum = (DataLoadTypeEnum)Enum.Parse(typeof(DataLoadTypeEnum), (sender as RadRadioButton).Content.ToString());
        //    LoadChart(_dataLoadTypeEnum.ToString());
        //}

        //private void BtnYearly_OnClick(object sender, RoutedEventArgs e)
        //{
        //    _dataLoadTypeEnum = (DataLoadTypeEnum)Enum.Parse(typeof(DataLoadTypeEnum), (sender as RadRadioButton).Content.ToString());
        //    LoadChart(_dataLoadTypeEnum.ToString());
        //}

        //private void SetRadioButtonGroup1Name(string chartgroup)
        //{
        //    //RbG1Button1.GroupName = chartgroup;
        //    //RbG1Button2.GroupName = chartgroup;
        //    //RbG1Button3.GroupName = chartgroup;
        //    //RbG1Button4.GroupName = chartgroup;
        //}

        //private void SetRadioButtonGroup2Name(string chartgroup)
        //{
        //    //RbG2Button1.GroupName = chartgroup;
        //    //RbG2Button2.GroupName = chartgroup;
        //    //RbG2Button3.GroupName = chartgroup;
        //    //RbG2Button4.GroupName = chartgroup;
        //}

        private void Btn_OnClick(object sender, RoutedEventArgs e)
        {
            _dataLoadTypeEnum = (DataLoadTypeEnum)Enum.Parse(typeof(DataLoadTypeEnum), (sender as RadRadioButton).Content.ToString());
            LoadChart(_dataLoadTypeEnum.ToString());
        }

        private void CbCompany_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBoxItem = CbCompany.SelectedItem as ComboBoxItem;
            if (comboBoxItem != null)
                _selectedContentForRbGroup2 = comboBoxItem.Content.ToString();
            LoadChart(_dataLoadTypeEnum.ToString());
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
