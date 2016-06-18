using System.ComponentModel;

namespace Pervation.Presentation.DashBoard.Chart
{
    public class CategoryValuePair : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Properties

        private string _category;
        public string Category
        {
            get { return _category; }
            set
            {
                _category = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Category"));
            }
        }

        private double _value;
        public double Value
        {
            get { return _value; }
            set
            {
                _value = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Value"));
            }
        }

        #endregion

        public CategoryValuePair()
        {

        }

        public CategoryValuePair(string category, double value)
        {
            Category = category;
            Value = value;
        }
    }
}
