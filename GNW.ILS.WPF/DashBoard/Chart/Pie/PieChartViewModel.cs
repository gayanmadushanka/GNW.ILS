using System.Windows;
using Telerik.Windows.Controls;

namespace Pervation.Presentation.DashBoard.Chart.Pie
{
    public class PieChartViewModel : ViewModelBase
    {

        #region Properties

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        private Size _zoom;
        public Size Zoom
        {
            get { return _zoom; }
            set
            {
                if (_zoom != value)
                {
                    _zoom = value;
                    OnPropertyChanged("Zoom");
                }
            }
        }

        private ChartData _chartData;
        public ChartData ChartData
        {
            get { return _chartData; }
            set
            {
                if (_chartData != value)
                {
                    _chartData = value;
                    OnPropertyChanged("ChartData");
                }
            }
        }

        #endregion

        public PieChartViewModel()
        {
            Zoom = new Size(3, 1);
        }
    }
}
