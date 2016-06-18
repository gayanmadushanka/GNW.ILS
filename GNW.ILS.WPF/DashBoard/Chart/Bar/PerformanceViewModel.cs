using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Telerik.Charting;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ChartView;

namespace Pervation.Presentation.DashBoard.Chart.Bar
{
    public class PerformanceViewModel : ViewModelBase
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

        private IEnumerable<PerformanceData> _q1;
        public IEnumerable<PerformanceData> Q1
        {
            get
            {
                if (_q1 == null)
                {
                    _q1 = new List<PerformanceData>() {
                        new PerformanceData("Jason Harley", "Q1, 2010", 17790),
                        new PerformanceData("Adam White", "Q1, 2010", 12820),
                        new PerformanceData("Barbara Smith", "Q1, 2010", 14350),
                        new PerformanceData("Susan Jones", "Q1, 2010", 11150),
                        new PerformanceData("Tom Marshall", "Q1, 2010", 11800)
                    };
                }
                return _q1;
            }
        }

        private IEnumerable<PerformanceData> _q2;
        public IEnumerable<PerformanceData> Q2
        {
            get
            {
                if (_q2 == null)
                {
                    _q2 = new List<PerformanceData>(){
                        new PerformanceData("Jason Harley", "Q2, 2010", 15320),
                        new PerformanceData("Adam White", "Q2, 2010", 14100),
                        new PerformanceData("Barbara Smith", "Q2, 2010", 13000),
                        new PerformanceData("Susan Jones", "Q2, 2010", 8850),
                        new PerformanceData("Tom Marshall", "Q2, 2010", 10900)
                    };
                }
                return _q2;
            }
        }

        private IEnumerable<PerformanceData> _q3;
        public IEnumerable<PerformanceData> Q3
        {
            get
            {
                if (_q3 == null)
                {
                    _q3 = new List<PerformanceData>(){
                        new PerformanceData("Jason Harley", "Q3, 2010", 13800),
                        new PerformanceData("Adam White", "Q3, 2010", 12300),
                        new PerformanceData("Barbara Smith", "Q3, 2010", 14900),
                        new PerformanceData("Susan Jones", "Q3, 2010", 10100),
                        new PerformanceData("Tom Marshall", "Q3, 2010", 8700)
                    };
                }
                return _q3;
            }
        }

        private ChartSeriesCombineMode _barCombineMode = ChartSeriesCombineMode.Cluster;
        public ChartSeriesCombineMode BarCombineMode
        {
            get { return _barCombineMode; }
            set
            {
                if (_barCombineMode != value)
                {
                    _barCombineMode = value;
                    OnPropertyChanged("BarCombineMode");

                    UpdateLabelsConfiguration(_barCombineMode);
                    UpdateAxisConfiguration(_barCombineMode);
                }
            }
        }

        private bool _showLabels;
        public bool ShowLabels
        {
            get { return _showLabels; }
            set
            {
                if (_showLabels != value)
                {
                    _showLabels = value;
                    OnPropertyChanged("ShowLabels");
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

        private bool _isShowLabelsEnabled = true;
        public bool IsShowLabelsEnabled
        {
            get { return _isShowLabelsEnabled; }
            set
            {
                if (_isShowLabelsEnabled != value)
                {
                    _isShowLabelsEnabled = value;
                    OnPropertyChanged("IsShowLabelsEnabled");
                }
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

        private double _gapLength = 0.2d;
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

        private double _axisMaxValue = 20000d;
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

        private double _axisStep = 5000d;
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

        private string _axisTitle = "PROFIT (USD)";
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

        private string _axisLabelFormat = "N0";
        public string AxisLabelFormat
        {
            get { return _axisLabelFormat; }
            set
            {
                if (_axisLabelFormat != value)
                {
                    _axisLabelFormat = value;
                    OnPropertyChanged("AxisLabelFormat");
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
        #endregion

        public PerformanceViewModel()
        {
            Zoom = new Size(3, 1);
            //PanOffset = new Point(-100000, 0);
        }

        private void UpdateMajorLinesVisibility(Orientation chartOrientation)
        {
            if (chartOrientation == Orientation.Horizontal)
                MajorLinesVisibility = GridLineVisibility.X;
            else
                MajorLinesVisibility = GridLineVisibility.Y;
        }

        private void UpdateLabelsConfiguration(ChartSeriesCombineMode mode)
        {
            ShowLabels = false;
            IsShowLabelsEnabled = mode == ChartSeriesCombineMode.Cluster;
        }

        private void UpdateAxisConfiguration(ChartSeriesCombineMode mode)
        {
            if (mode == ChartSeriesCombineMode.Cluster)
            {
                GapLength = 0.2d;

                AxisMaxValue = 20000d;
                AxisStep = 5000d;

                AxisTitle = "PROFIT (USD)";
                AxisLabelFormat = "N0";
            }
            else if (mode == ChartSeriesCombineMode.Stack)
            {
                GapLength = 0.5d;

                AxisMaxValue = 70000d;
                AxisStep = 16500d;

                AxisTitle = "PROFIT (USD)";
                AxisLabelFormat = "N0";
            }
            else if (mode == ChartSeriesCombineMode.Stack100)
            {
                GapLength = 0.5d;

                AxisMaxValue = 1d;
                AxisStep = 0.25d;

                AxisTitle = "PROFIT (%)";
                AxisLabelFormat = "P0";
            }
        }
    }
}
