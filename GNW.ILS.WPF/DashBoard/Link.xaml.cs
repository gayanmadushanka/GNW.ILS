using System;
using System.ComponentModel;

namespace Pervation.Presentation.DashBoard
{
    /// <summary>
    /// Interaction logic for Link.xaml
    /// </summary>
    public partial class Link : INotifyPropertyChanged
    {
        #region Properties

        private string _text;
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Text"));
            }
        }

        private string _iconPath;
        public string IconPath
        {
            get { return _iconPath; }
            set
            {
                _iconPath = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("IconPath"));
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        public Enum LinkEnum { get; set; }

        public string LinkCode { get; set; }

        public bool? IsUseLoginCompany { get; set; }

        public Link(string text, Enum linkEnum, string iconPath, bool? isUseLoginCompany = false)
            : this(text, string.Empty, linkEnum, iconPath, isUseLoginCompany)
        {
        }

        public Link(string text, string linkCode, string iconPath, bool? isUseLoginCompany)
            : this(text, linkCode, null, iconPath, isUseLoginCompany)
        {
        }

        private Link(string text, string linkCode, Enum linkEnum, string iconPath, bool? isUseLoginCompany)
        {
            Text = text;
            IconPath = iconPath;
            LinkEnum = linkEnum;
            LinkCode = linkCode;
            IsUseLoginCompany = isUseLoginCompany;
            InitializeComponent();
            DataContext = this;
        }

        public Link(Link link)
            : this(link.Text, link.LinkCode, link.LinkEnum, link.IconPath, link.IsUseLoginCompany)
        {
        }
    }
}
