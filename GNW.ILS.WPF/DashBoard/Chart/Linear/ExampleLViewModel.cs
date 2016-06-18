using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ChartView;

namespace Pervation.Presentation.DashBoard.Chart.Linear
{
    public class ExampleLViewModel : ViewModelBase
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

        private string _selectedChartType;
        public string SelectedChartType
        {
            get { return _selectedChartType; }
            set
            {
                if (_selectedChartType == value)
                    return;

                _selectedChartType = value;
                OnPropertyChanged("SelectedChartType");
            }
        }

        private List<string> _chartTypes;
        public List<string> ChartTypes
        {
            get { return _chartTypes; }
        }

        private bool _showLabels = true;
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

        private List<CategoryValuePair> _collection1;
        public List<CategoryValuePair> Collection1
        {
            get { return _collection1; }
            set
            {
                if (_collection1 != value)
                {
                    _collection1 = value;
                    OnPropertyChanged("Collection1");
                }
            }
        }

        private List<CategoryValuePair> _collection2;
        public List<CategoryValuePair> Collection2
        {
            get { return _collection2; }
            set
            {
                if (_collection2 != value)
                {
                    _collection2 = value;
                    OnPropertyChanged("Collection2");
                }
            }
        }

        private List<CategoryValuePair> _collection3;
        public List<CategoryValuePair> Collection3
        {
            get { return _collection3; }
            set
            {
                if (_collection3 != value)
                {
                    _collection3 = value;
                    OnPropertyChanged("Collection3");
                }
            }
        }

        private List<CategoryValuePair> _collection4;
        public List<CategoryValuePair> Collection4
        {
            get { return _collection4; }
            set
            {
                if (_collection4 != value)
                {
                    _collection4 = value;
                    OnPropertyChanged("Collection4");
                }
            }
        }

        private string _legend;
        public string Legend
        {
            get { return _legend; }
            set
            {
                if (_legend == value)
                    return;

                _legend = value;
                OnPropertyChanged("Legend");
            }
        }

        #endregion

        public ExampleLViewModel()
        {
            Zoom = new Size(3, 1);
            InitializeChartTypes();
            SelectedChartType = ChartTypes[0];
            Legend = "test";
            //PanOffset = new Point(-100000, 0);
        }

        private void InitializeChartTypes()
        {
            _chartTypes = new List<string> { "Line", "Bar", "Spline", "Area", "Spline Area", "Step Line", "Step Area" };
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
