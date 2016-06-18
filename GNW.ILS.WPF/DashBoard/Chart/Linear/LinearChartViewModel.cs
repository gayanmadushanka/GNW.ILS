using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ChartView;

namespace Pervation.Presentation.DashBoard.Chart.Linear
{
    public class LinearChartViewModel : ViewModelBase
    {
        #region Properties

        private Point _panOffset;
        public Point PanOffset
        {
            get { return _panOffset; }
            set
            {
                if (_panOffset != value)
                {
                    _panOffset = value;
                    OnPropertyChanged("PanOffset");
                }
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

        private double _axisMaxValue;
        public double AxisMaxValue
        {
            get { return _axisMaxValue; }
            set
            {
                if (_axisMaxValue != value)
                {
                    _axisMaxValue = value;
                    OnPropertyChanged("AxisMaxValue");
                }
            }
        }

        private double _axisStep;
        public double AxisStep
        {
            get { return _axisStep; }
            set
            {
                if (_axisStep != value)
                {
                    _axisStep = value;
                    OnPropertyChanged("AxisStep");
                }
            }
        }

        private string _axisTitle;
        public string AxisTitle
        {
            get { return _axisTitle; }
            set
            {
                if (_axisTitle != value)
                {
                    _axisTitle = value;
                    OnPropertyChanged("AxisTitle");
                }
            }
        }

        private double _gapLength = 0.1d;
        public double GapLength
        {
            get { return _gapLength; }
            set
            {
                if (_gapLength != value)
                {
                    _gapLength = value;
                    OnPropertyChanged("GapLength");
                }
            }
        }

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

        private Orientation _chartOrientation = Orientation.Vertical;
        public Orientation ChartOrientation
        {
            get { return _chartOrientation; }
            set
            {
                if (_chartOrientation != value)
                {
                    _chartOrientation = value;
                    OnPropertyChanged("ChartOrientation");

                    UpdateMajorLinesVisibility(_chartOrientation);
                }
            }
        }

        private GridLineVisibility _majorLinesVisibility = GridLineVisibility.Y;
        public GridLineVisibility MajorLinesVisibility
        {
            get { return _majorLinesVisibility; }
            set
            {
                if (_majorLinesVisibility != value)
                {
                    _majorLinesVisibility = value;
                    OnPropertyChanged("MajorLinesVisibility");
                }
            }
        }

        private ChartData _chartData;
        public ChartData ChartData
        {
            get { return _chartData; }
            set
            {
                if (!Equals(_chartData, value))
                {
                    _chartData = value;
                    OnPropertyChanged("ChartData");
                }
            }
        }
        #endregion

        public LinearChartViewModel()
        {
            //Zoom = new Size(3, 1);
            //PanOffset = new Point(-100000, 0);
        }

        private void UpdateMajorLinesVisibility(Orientation chartOrientation)
        {
            if (chartOrientation == Orientation.Horizontal)
                MajorLinesVisibility = GridLineVisibility.X;
            else
                MajorLinesVisibility = GridLineVisibility.Y;
        }
    }
}
