using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace GNW.ILS.WPF._Basic_Windows.UserControls
{
    /// <summary>
    /// Interaction logic for UCToolmnu.xaml
    /// </summary>
    /// 
    public class MenuEvent : EventArgs
    {
        public Dictionary<string, bool> ToolDic = new Dictionary<string, bool>();
        public MenuEvent(Dictionary<string, bool> ArgToolDic)
        {
            ToolDic = ArgToolDic;
        }

    }
    public delegate MenuEvent dicHandler(Dictionary<string, bool> dic);
    public partial class UCToolmnu : UserControl
    {
        public UCToolmnu()
        {
            InitializeComponent();
            btnNew.Click += new RoutedEventHandler(New_Click);
            btnAppend.Click += new RoutedEventHandler(btnAppend_Click); 
            btnDelete.Click += new RoutedEventHandler(Delete_Click);
            btnSearch.Click += new RoutedEventHandler(Search_Click);
            btnSave.Click += new RoutedEventHandler(Save_Click);
            btnSaveAs.Click += new RoutedEventHandler(SaveAs_Click);
            btnClose.Click += new RoutedEventHandler(Close_Click);
        }       

        public event RoutedEventHandler NewBtnClick;
        public event RoutedEventHandler AppendBtnClick;
        public event RoutedEventHandler DeleteBtnClick;
        public event RoutedEventHandler SearchBtnClick;
        public event RoutedEventHandler SaveBtnClick;
        public event RoutedEventHandler SaveAsBtnClick;
        public event RoutedEventHandler CloseBtnClick;
       
        void New_Click(object sender, RoutedEventArgs e)
        {
            if (NewBtnClick != null)
            {
                NewBtnClick(sender, e);
            }

        }
        void btnAppend_Click(object sender, RoutedEventArgs e)
        {
            if (AppendBtnClick != null)
            {
                AppendBtnClick(sender, e);
            }
        }
        void Delete_Click(object sender, RoutedEventArgs e)
        {

            if (DeleteBtnClick != null)
            {
                DeleteBtnClick(sender, e);
            }
        }
        void Search_Click(object sender, RoutedEventArgs e)
        {
            if (SearchBtnClick != null)
            {
                SearchBtnClick(sender, e);
            }

        }
        void Save_Click(object sender, RoutedEventArgs e)
        {
            if (SaveBtnClick != null)
            {
                SaveBtnClick(sender, e);
            }

        }
        void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            if (SaveBtnClick != null)
            {
                SaveBtnClick(sender, e);
            }

        }
        void Close_Click(object sender, RoutedEventArgs e)
        {
            if (CloseBtnClick != null)
            {
                CloseBtnClick(sender, e);
            }

        }       
        public bool CustomiseButtonEnable(Dictionary<string, bool> customizedic)
        {
            bool flage;
            try
            {
                btnNew.IsEnabled = customizedic[btnNew.Name];
                btnDelete.IsEnabled = customizedic[btnDelete.Name];
                btnSearch.IsEnabled = customizedic[btnSearch.Name];
                btnSave.IsEnabled = customizedic[btnSave.Name];
                btnSaveAs.IsEnabled = customizedic[btnSaveAs.Name];
                btnClose.IsEnabled = customizedic[btnClose.Name];
                btnAppend.IsEnabled = customizedic[btnAppend.Name];
                flage = true;
            }
            catch (Exception ex)
            {
                flage = false;
                throw ex;
            }
            return flage;
        }
    }
}
