using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;

namespace Pervation.Presentation.DashBoard.Chart
{
    public class SeriesData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Properties

        private ObservableCollection<CategoryValuePair> _categoryValuePairList = new ObservableCollection<CategoryValuePair>();
        public ObservableCollection<CategoryValuePair> CategoryValuePairList
        {
            get { return _categoryValuePairList; }
            set
            {
                _categoryValuePairList = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("CategoryValuePairList"));
            }
        }

        private string _legend;
        public string Legend
        {
            get { return _legend; }
            set
            {
                _legend = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Legend"));
            }
        }
        #endregion

        public SeriesData(DataLoadTypeEnum dataLoadTypeEnum = DataLoadTypeEnum.NoData)
        {
            switch (dataLoadTypeEnum)
            {
                case DataLoadTypeEnum.Daily:
                    SetDay();
                    break;
                case DataLoadTypeEnum.Weekly:
                    SetWeek();
                    break;
                case DataLoadTypeEnum.Monthly:
                    SetMonth();
                    break;
                case DataLoadTypeEnum.Yearly:
                    SetYear();
                    break;
            }
        }

        public void SetDay()
        {
            for (int i = 1; i < 8; i++)
            {
                CategoryValuePairList.Add(new CategoryValuePair { Category = DateTime.Now.AddDays(-i).ToString("ddd") });
            }
        }

        public void SetWeek()
        {
            int weekOfMonth = DateTime.Now.GetWeekOfMonth();
            if (weekOfMonth == 1)
            {
                CategoryValuePairList.Add(new CategoryValuePair { Category = 4.ToString(CultureInfo.InvariantCulture) });
                CategoryValuePairList.Add(new CategoryValuePair { Category = 3.ToString(CultureInfo.InvariantCulture) });
                CategoryValuePairList.Add(new CategoryValuePair { Category = 2.ToString(CultureInfo.InvariantCulture) });
                CategoryValuePairList.Add(new CategoryValuePair { Category = 1.ToString(CultureInfo.InvariantCulture) });
            }
            else if (weekOfMonth == 2)
            {
                CategoryValuePairList.Add(new CategoryValuePair { Category = 1.ToString(CultureInfo.InvariantCulture) });
                CategoryValuePairList.Add(new CategoryValuePair { Category = 4.ToString(CultureInfo.InvariantCulture) });
                CategoryValuePairList.Add(new CategoryValuePair { Category = 3.ToString(CultureInfo.InvariantCulture) });
                CategoryValuePairList.Add(new CategoryValuePair { Category = 2.ToString(CultureInfo.InvariantCulture) });
            }
            else if (weekOfMonth == 3)
            {
                CategoryValuePairList.Add(new CategoryValuePair { Category = 2.ToString(CultureInfo.InvariantCulture) });
                CategoryValuePairList.Add(new CategoryValuePair { Category = 1.ToString(CultureInfo.InvariantCulture) });
                CategoryValuePairList.Add(new CategoryValuePair { Category = 4.ToString(CultureInfo.InvariantCulture) });
                CategoryValuePairList.Add(new CategoryValuePair { Category = 3.ToString(CultureInfo.InvariantCulture) });
            }
            else if (weekOfMonth == 4)
            {
                CategoryValuePairList.Add(new CategoryValuePair { Category = 3.ToString(CultureInfo.InvariantCulture) });
                CategoryValuePairList.Add(new CategoryValuePair { Category = 2.ToString(CultureInfo.InvariantCulture) });
                CategoryValuePairList.Add(new CategoryValuePair { Category = 1.ToString(CultureInfo.InvariantCulture) });
                CategoryValuePairList.Add(new CategoryValuePair { Category = 4.ToString(CultureInfo.InvariantCulture) });
            }
            else if (weekOfMonth == 5)
            {
                CategoryValuePairList.Add(new CategoryValuePair { Category = 4.ToString(CultureInfo.InvariantCulture) });
                CategoryValuePairList.Add(new CategoryValuePair { Category = 3.ToString(CultureInfo.InvariantCulture) });
                CategoryValuePairList.Add(new CategoryValuePair { Category = 2.ToString(CultureInfo.InvariantCulture) });
                CategoryValuePairList.Add(new CategoryValuePair { Category = 1.ToString(CultureInfo.InvariantCulture) });
            }
        }

        public void SetMonth()
        {
            for (int i = 1; i < 13; i++)
            {
                CategoryValuePairList.Add(new CategoryValuePair { Category = DateTime.Now.AddMonths(-i).ToString("MMM") });
            }
        }

        public void SetYear()
        {
            for (int i = 0; i < 3; i++)
            {
                CategoryValuePairList.Add(new CategoryValuePair { Category = DateTime.Now.AddYears(-i).ToString("yyyy") });
            }
        }
    }
}