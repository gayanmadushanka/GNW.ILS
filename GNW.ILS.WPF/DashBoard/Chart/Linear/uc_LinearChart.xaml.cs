namespace Pervation.Presentation.DashBoard.Chart.Linear
{
    public partial class uc_LinearChart
    {
        public uc_LinearChart(ChartData chartData)
        {
            InitializeComponent();
            LinearChartViewModelOld linearChartViewModel = DataContext as LinearChartViewModelOld;
            if (linearChartViewModel != null && chartData != null)
            {
                linearChartViewModel.Title = chartData.Title;
                linearChartViewModel.Collection1 = chartData.SeriesOneData.CategoryValuePairList;
            }
        }
    }
}
