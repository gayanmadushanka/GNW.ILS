using System.ComponentModel;
using System.Windows;
using Pervation.Presentation._Basic_Windows.Base;

namespace Pervation.Presentation.DashBoard.Chart
{
    public class ChartData : UCBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Properties

        private SeriesData _seriesOneData;
        public SeriesData SeriesOneData
        {
            get { return _seriesOneData; }
            set
            {
                _seriesOneData = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("SeriesOneData"));
            }
        }

        private SeriesData _seriesTwoData;
        public SeriesData SeriesTwoData
        {
            get { return _seriesTwoData; }
            set
            {
                _seriesTwoData = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("SeriesTwoData"));
            }
        }

        private SeriesData _seriesThreeData;
        public SeriesData SeriesThreeData
        {
            get { return _seriesThreeData; }
            set
            {
                _seriesThreeData = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("SeriesThreeData"));
            }
        }

        private SeriesData _seriesFourData;
        public SeriesData SeriesFourData
        {
            get { return _seriesFourData; }
            set
            {
                _seriesFourData = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("SeriesFourData"));
            }
        }

        //private string _title;
        //public new string Title
        //{  
        //    get { return _title; }
        //    set
        //    {
        //        _title = value;
        //        if (PropertyChanged != null)
        //            PropertyChanged(this, new PropertyChangedEventArgs("Title"));
        //    }
        //}

        private string _axisTitle;
        public string AxisTitle
        {
            get { return _axisTitle; }
            set
            {
                _axisTitle = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("AxisTitle"));
            }
        }

        private Visibility _legendVisibility;
        public Visibility LegendVisibility
        {
            get { return _legendVisibility; }
            set
            {
                _legendVisibility = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("LegendVisibility"));
            }
        }

        private Visibility _changeOrientationVisibility;
        public Visibility ChangeOrientationVisibility
        {
            get { return _changeOrientationVisibility; }
            set
            {
                _changeOrientationVisibility = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("ChangeOrientationVisibility"));
            }
        }

        private Visibility _showLabelVisibility;
        public Visibility ShowLabelVisibility
        {
            get { return _showLabelVisibility; }
            set
            {
                _showLabelVisibility = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("ShowLabelVisibility"));
            }
        }

        private Visibility _radioBtnVisibility;
        public Visibility RadioBtnVisibility
        {
            get { return _radioBtnVisibility; }
            set
            {
                _radioBtnVisibility = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("RadioBtnVisibility"));
            }
        }

        private Visibility _btnDailyVisibility;
        public Visibility BtnDailyVisibility
        {
            get { return _btnDailyVisibility; }
            set
            {
                _btnDailyVisibility = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("BtnDailyVisibility"));
            }
        }

        private Visibility _btnWeeklyVisibility;
        public Visibility BtnWeeklyVisibility
        {
            get { return _btnWeeklyVisibility; }
            set
            {
                _btnWeeklyVisibility = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("BtnWeeklyVisibility"));
            }
        }

        private Visibility _btnMonthlyVisibility;
        public Visibility BtnMonthlyVisibility
        {
            get { return _btnMonthlyVisibility; }
            set
            {
                _btnMonthlyVisibility = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("BtnMonthlyVisibility"));
            }
        }

        private Visibility _btnYearlyVisibility;
        public Visibility BtnYearlyVisibility
        {
            get { return _btnYearlyVisibility; }
            set
            {
                _btnYearlyVisibility = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("BtnYearlyVisibility"));
            }
        }
        #endregion

        public ChartData(string axisTitle, Visibility legendVisibility, Visibility changeOrientationVisibility, Visibility showLabelVisibility, Visibility radioBtnVisibility, Visibility btnDailyVisibility, Visibility btnWeeklyVisibility, Visibility btnMonthlyVisibility, Visibility btnYearlyVisibility, SeriesData seriesOneData = null, SeriesData seriesTwoData = null, SeriesData seriesThreeData = null, SeriesData seriesFourData = null)
        {
            AxisTitle = axisTitle;
            LegendVisibility = legendVisibility;
            ChangeOrientationVisibility = changeOrientationVisibility;
            ShowLabelVisibility = showLabelVisibility;
            RadioBtnVisibility = radioBtnVisibility;
            BtnDailyVisibility = btnDailyVisibility;
            BtnWeeklyVisibility = btnWeeklyVisibility;
            BtnMonthlyVisibility = btnMonthlyVisibility;
            BtnYearlyVisibility = btnYearlyVisibility;
            SeriesOneData = seriesOneData;
            SeriesTwoData = seriesTwoData;
            SeriesThreeData = seriesThreeData;
            SeriesFourData = seriesFourData;
        }
    }
}
