using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ChartView;

namespace Pervation.Presentation.DashBoard.Chart.Linear
{
    public class LinearChartViewModelOld : ViewModelBase
    {
        private List<CategoryValuePair> _collection1, _collection2, _collection3;

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

        private List<string> _chartTypes;
        public List<string> ChartTypes
        {
            get { return _chartTypes; }
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

        public List<CategoryValuePair> Collection2
        {
            get
            {
                if (_collection2 == null)
                {
                    _collection2 = new List<CategoryValuePair>();
                    _collection2.Add(new CategoryValuePair("January", 1.5));
                    _collection2.Add(new CategoryValuePair("February", 1.7));
                    _collection2.Add(new CategoryValuePair("March", 1.6));
                    _collection2.Add(new CategoryValuePair("April", 1.6));
                    _collection2.Add(new CategoryValuePair("May", 1.7));
                    _collection2.Add(new CategoryValuePair("June", 1.5));
                    _collection2.Add(new CategoryValuePair("July", 1.5));
                    _collection2.Add(new CategoryValuePair("August", 1.7));
                    _collection2.Add(new CategoryValuePair("September", 2.1));
                    _collection2.Add(new CategoryValuePair("October", 1.6));
                    _collection2.Add(new CategoryValuePair("November", 2));
                    _collection2.Add(new CategoryValuePair("December", 1.6));
                }
                return _collection2;
            }
        }

        public List<CategoryValuePair> Collection3
        {
            get
            {
                if (_collection3 == null)
                {
                    _collection3 = new List<CategoryValuePair>();
                    _collection3.Add(new CategoryValuePair("January", 2.5));
                    _collection3.Add(new CategoryValuePair("February", 2.7));
                    _collection3.Add(new CategoryValuePair("March", 2.6));
                    _collection3.Add(new CategoryValuePair("April", 2.6));
                    _collection3.Add(new CategoryValuePair("May", 2.7));
                    _collection3.Add(new CategoryValuePair("June", 2.5));
                    _collection3.Add(new CategoryValuePair("July", 2.5));
                    _collection3.Add(new CategoryValuePair("August", 2.7));
                    _collection3.Add(new CategoryValuePair("September", 2.2));
                    _collection3.Add(new CategoryValuePair("October", 2.6));
                    _collection3.Add(new CategoryValuePair("November", 2));
                    _collection3.Add(new CategoryValuePair("December", 2.6));
                }
                return _collection3;
            }
        }

        #endregion

        public LinearChartViewModelOld()
        {
            Zoom = new Size(3, 1);
            InitializeChartTypes();
            SelectedChartType = ChartTypes[1];
        }

        private void InitializeChartTypes()
        {
            _chartTypes = new List<string> {"Line", "Spline", "Area", "Spline Area", "Step Line", "Step Area"};
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
