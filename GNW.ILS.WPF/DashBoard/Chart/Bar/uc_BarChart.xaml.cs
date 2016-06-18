namespace Pervation.Presentation.DashBoard.Chart.Bar
{
    public partial class uc_BarChart
    {
        public uc_BarChart(string title)
        {
            InitializeComponent();
            PerformanceViewModel performanceViewModel = DataContext as PerformanceViewModel;
            if (performanceViewModel != null)
            {
                performanceViewModel.Title = title;
                //performanceViewModel.Data = chartData;
            }
        }
    }
}
