namespace Pervation.Presentation.DashBoard.Chart.Bar
{
    public class PerformanceData
    {
        private string _quarter;
        private string _name;
        private double _performance;

        public PerformanceData(string name, string quarter, double performance)
        {
            _name = name;
            _quarter = quarter;
            _performance = performance;
        }

        public string QuarterName
        {
            get
            {
                return _quarter;
            }
        }

        public string RepresentativeName
        {
            get
            {
                return _name;
            }
        }

        public double Performance
        {
            get
            {
                return _performance;
            }
        }
    }
}
