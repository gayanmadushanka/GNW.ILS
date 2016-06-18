using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System.Configuration;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Controls.Primitives;

using Telerik.Windows.Controls;
using System.Windows.Controls;

using Pervation.Common.CommonOperations;
using Pervation.Common.CommonSearch;
using Pervation.Presentation._Basic_Windows.CommonSearch;
using Pervation.Presentation._Basic_Windows.CommonMessage;
using MahApps.Metro.Controls;



namespace Pervation.Presentation._Basic_Windows.CommonSearch
{
    /// <summary>
    /// Interaction logic for frmCommonSearch.xaml
    /// </summary>
    public partial class frmCommonSearch : MetroWindow
    {
        bool _IsStatusFields = false;
        string _FieldsWithStatus = "";
        public frmCommonSearch()
        {
            InitializeComponent();
            string zTemp = ConfigurationManager.AppSettings["AlternateGridColour"];
            if (zTemp != null)
            {
                int nColorCode = int.Parse(zTemp);
                this.GridAlternateColour = System.Drawing.Color.FromArgb(nColorCode);
            }

            zTemp = ConfigurationManager.AppSettings["SelectedAlternateGridColour"];
            if (zTemp != null)
            {
                int nColorCode = int.Parse(zTemp);
                this.SelectedGridAlternateColour = System.Drawing.Color.FromArgb(nColorCode);
            }
        }

        #region ShortCutKeys

        private RoutedCommand Settings_Enter;
        private RoutedCommand Settings_Escape;
        private void AddHotKeys()
        {
            try
            {
                Settings_Enter = new RoutedCommand();
                Settings_Enter.InputGestures.Add(new KeyGesture(Key.Enter, ModifierKeys.None));
                CommandBindings.Add(new CommandBinding(Settings_Enter, ShortCutKey_Enter));

                Settings_Escape = new RoutedCommand();
                Settings_Escape.InputGestures.Add(new KeyGesture(Key.Escape, ModifierKeys.None));
                CommandBindings.Add(new CommandBinding(Settings_Escape, ShortCutKey_Escape));
            }
            catch (Exception ex)
            {

            }
        }


        private void ShortCutKey_Enter(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                if (radGridViewMain.SelectedItems != null)
                {
                    if (radGridViewMain.SelectedItems.Count > 0)
                    {
                        if (_AllowMultipleSelection)
                        {
                            return;
                        }
                        foreach (Object Item in radGridViewMain.Items)
                        {
                            DataRow row = (DataRow)Item;

                            if (row != null)
                            {
                                row[0] = false;
                            }
                        }

                        DataRow TRow = (DataRow)radGridViewMain.SelectedItem;
                        TRow[0] = true;
                        SelectRecord();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void ShortCutKey_Escape(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                SelectedData = _dtSelected;
                this.Close();
            }
            catch (Exception ex)
            {

            }
        }       

        #endregion 
        public frmCommonSearch(int pageSize)
        {
            InitializeComponent();
            string zTemp = ConfigurationManager.AppSettings["AlternateGridColour"];
            if (zTemp != null)
            {
                int nColorCode = int.Parse(zTemp);
                this.GridAlternateColour = System.Drawing.Color.FromArgb(nColorCode);
            }

            zTemp = ConfigurationManager.AppSettings["SelectedAlternateGridColour"];
            if (zTemp != null)
            {
                int nColorCode = int.Parse(zTemp);
                this.SelectedGridAlternateColour = System.Drawing.Color.FromArgb(nColorCode);
            }
            PageSize = pageSize;
           
        }

        public frmCommonSearch(bool IsStatusFields, string FieldsWithStatus)
        {
            InitializeComponent();
            string zTemp = ConfigurationManager.AppSettings["AlternateGridColour"];
            if (zTemp != null)
            {
                int nColorCode = int.Parse(zTemp);
                this.GridAlternateColour = System.Drawing.Color.FromArgb(nColorCode);
            }

            zTemp = ConfigurationManager.AppSettings["SelectedAlternateGridColour"];
            if (zTemp != null)
            {
                int nColorCode = int.Parse(zTemp);
                this.SelectedGridAlternateColour = System.Drawing.Color.FromArgb(nColorCode);
            }

            _IsStatusFields = IsStatusFields;
            _FieldsWithStatus = FieldsWithStatus;
        }
        public frmCommonSearch(bool IsStatusFields,string FieldsWithStatus,int pageSize)
        {
            InitializeComponent();
            string zTemp = ConfigurationManager.AppSettings["AlternateGridColour"];
            if (zTemp != null)
            {
                int nColorCode = int.Parse(zTemp);
                this.GridAlternateColour = System.Drawing.Color.FromArgb(nColorCode);
            }

            zTemp = ConfigurationManager.AppSettings["SelectedAlternateGridColour"];
            if (zTemp != null)
            {
                int nColorCode = int.Parse(zTemp);
                this.SelectedGridAlternateColour = System.Drawing.Color.FromArgb(nColorCode);
            }
            PageSize = pageSize;
            _IsStatusFields = IsStatusFields;
            _FieldsWithStatus = FieldsWithStatus;
        }

        #region Properties
        int PageSize = 20;
        public List<KeyValuePair<int, string>> PageSelectedItems { get; set; }

        private DataTable _dtSelected = null;


        private System.Drawing.Color _GridAlternateColour = System.Drawing.Color.FromArgb(255, 255, 255);
        public System.Drawing.Color GridAlternateColour
        {
            get
            {
                return _GridAlternateColour;
            }
            set
            {
                _GridAlternateColour = value;
            }
        }
        private System.Drawing.Color _SelectedGridAlternateColour = System.Drawing.Color.FromArgb(255, 255, 255);

        public System.Drawing.Color SelectedGridAlternateColour
        {
            get
            {
                return _SelectedGridAlternateColour;
            }
            set
            {
                _SelectedGridAlternateColour = value;
            }
        }

        private int _PageIndex;       
        public int PageIndex
        {
            get { return _PageIndex; }
            set
            {
                _PageIndex = value;
                //remove comments after add ucSearchPaging --dulip
                // this.ucSearchPaging.PageIndex = _PageIndex;

            }
        }

        private int _TotalPageCount;

        public int TotalPageCount
        {
            get { return _TotalPageCount; }
            set
            {
                _TotalPageCount = value;
                //remove comments after add ucSearchPaging --dulip
                this.ucSearchPaging.TotalPageCount = _TotalPageCount;
            }
        }


        private string _PageTitle;

        public string PageTitle
        {
            get { return _PageTitle; }
            set { _PageTitle = value; }
        }



        private bool _HidePrimaryKeyField;

        public bool HidePrimaryKeyField
        {
            get { return _HidePrimaryKeyField; }
            set { _HidePrimaryKeyField = value; }
        }

        public bool IsSearchPage { get; set; }

        private string _SearchCode;

        public string SearchCode
        {
            get { return _SearchCode; }
            set { _SearchCode = value; }
        }

        private string _RecordSource;

        public string RecordSource
        {
            get { return _RecordSource; }
            set { _RecordSource = value; }
        }


        private string _SelectFields;

        public string SelectFields
        {
            get { return _SelectFields; }
            set { _SelectFields = value; }
        }

        private string _DisplayFields;

        public string DisplayFields
        {
            get { return _DisplayFields; }
            set { _DisplayFields = value; }
        }

        private string _RecordSourceType;

        public string RecordSourceType
        {
            get { return _RecordSourceType; }
            set { _RecordSourceType = value; }
        }

        private string _InitialCondition;

        public string InitialCondition
        {
            get { return _InitialCondition; }
            set { _InitialCondition = value; }
        }

        private string _SortOrder;

        public string SortOrder
        {
            get { return _SortOrder; }
            set { _SortOrder = value; }
        }

        private string _ParameterFields;

        public string ParameterFields
        {
            get { return _ParameterFields; }
            set { _ParameterFields = value; }
        }


        private string[] _FilteredBy;

        public string[] FilteredBy
        {
            get { return _FilteredBy; }
            set { _FilteredBy = value; }
        }

        private string _DataType;

        public string DataType
        {
            get { return _DataType; }
            set { _DataType = value; }
        }

        private DataSet _SearchPara;

        public DataSet SearchPara
        {
            get { return _SearchPara; }
            set { _SearchPara = value; }
        }

        private int _RecordsPerPager;

        public int RecordsPerPage
        {
            get { return _RecordsPerPager; }
            set { _RecordsPerPager = value; }
        }

        private string[] _ParameterValues;

        public string[] ParameterValues
        {
            get { return _ParameterValues; }
            set { _ParameterValues = value; }
        }


        public DataTable SelectedData { get; set; }

        private string[] _SelectedItems;

        public string[] SelectedItems
        {
            get { return _SelectedItems; }
            set { _SelectedItems = value; }
        }

        private bool _AllowMultipleSelection;

        public bool AllowMultipleSelection
        {
            get { return _AllowMultipleSelection; }
            set { _AllowMultipleSelection = value; }
        }

        private string _InitialSearchString;

        public string InitialSearchString
        {
            get { return _InitialSearchString; }
            set { _InitialSearchString = value; }
        }

        private string _ServerName;

        public string ServerName
        {
            get { return _ServerName; }
            set { _ServerName = value; }
        }


        const int _CRECORDSPERPAGE = 20;
        private bool _Cancel = true;
        #endregion
        private void frmSearch_Load(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Title = _PageTitle;

                LoadSearchParaList();
                cboSearcPara.SelectedIndex = 0;

                if (IsSearchPage && _InitialSearchString.Length > 0)
                { LoadData(1, _ServerName); }             /*LoadDataForSelectedCode(1, _ServerName); */
                else
                { LoadData(1, _ServerName); }

                if (!_AllowMultipleSelection)
                {
                    // tblLPMain.RowDefinitions[2].Height = new GridLength(0);                                                            
                    //  tblLPMain.RowDefinitions[1].Height = new GridLength(100,GridUnitType.Star);                                                           
                }

                if (_HidePrimaryKeyField)
                {

                }
            }
           catch(Exception ex)
            { }
        }
        private void LoadSearchParaList()
        {
            try
            {
                cboSearcPara.DataContext = _SearchPara.Tables[0];
                cboSearcPara.DisplayMemberPath = "DisplayValue";
                cboSearcPara.SelectedValuePath = "SearchValue";
                cboSearcPara.SelectedValue = _SearchPara.Tables[0].Rows[0][2].ToString();
            }
           catch(Exception ex)
            { }
        }
        private string BuildSearchString()
        {
            string zTemp = "";
            return zTemp;
        }

        private void LoadData(int nPageIndex)
        {
            try
            {
                LoadData(nPageIndex, "");
                bool bHasChanges = false;
                if (_dtSelected != null && _dtSelected.Rows.Count > 0)
                {
                    DataTable dtTemp = (DataTable)radGridViewMain.DataContext;
                    if (dtTemp != null && dtTemp.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtTemp.Rows)
                        {
                            DataRow drFind = _dtSelected.Rows.Find(dr[1].ToString());
                            if (drFind != null)
                            {
                                dr[0] = true;
                                dtTemp.AcceptChanges();
                                bHasChanges = true;

                            }
                        }
                    }
                    if (bHasChanges)
                    {
                        radGridViewMain.DataContext = dtTemp;
                        if (radGridViewMain.Items.Count > 0)
                        {
                            radGridViewMain.Focus();
                           // radGridViewMain.SelectedItem = radGridViewMain.Items[0];
                        }
                    }

                }
            }
           catch(Exception ex)
            { }
        }
        /// <summary>
        /// ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="nPageIndex"></param>
        /// <param name="zServerName"></param>
        private void LoadData(int nPageIndex, string zServerName)
        {
            try
            
            {
                DataSet dsSearchData = null;
                DataSet dsSearchPara = null;
                DataSet dsTotalRecord = null;
                int nStartRecord = 0;
                int nEndRecord = 0;
                int nRecordsPerPage = 0;
                int nTotalRecords = 0;

                string zTempParaList = "";
                string zSearcString = "";
                if (_InitialSearchString != null && _InitialSearchString != string.Empty)
                {
                    txtSearchData.Text = _InitialSearchString.ToString();
                    _InitialSearchString = "";
                }
                string zSearchData = txtSearchData.Text.Trim().Replace("'", "''");
                zSearchData = zSearchData.Replace(",", "");
                lblMessage.Text = "";

                if (_RecordsPerPager <= 0)
                {
                    nRecordsPerPage = _CRECORDSPERPAGE;
                }
                else
                {
                    nRecordsPerPage = _RecordsPerPager;
                }

                if (zSearchData == "")
                {

                    zSearcString = cboSearcPara.SelectedValue + " like '%%'";
                }
                else
                {
                    zSearcString = cboSearcPara.SelectedValue + " like '%" + zSearchData + "%'";
                }


                if (_RecordSourceType == null || _RecordSourceType == "VW")
                {
                    //View
                    //string zSearchCondition = " where " + zSearcString;
                    nStartRecord = ((nPageIndex - 1) * nRecordsPerPage) + 1;
                    nEndRecord = ((nPageIndex - 1) * nRecordsPerPage) + nRecordsPerPage;
                    
                    string zSearchCondition = string.Empty;
                    dsSearchPara = new CommonSearchDataAccess().GetSearchType(_SearchCode.Trim());

                    if (zServerName != "" && zServerName != "NULL")
                    {
                        dsSearchData = new CommonSearchDataAccess().GetSearchRecords(nPageIndex, dsSearchPara.Tables[0].Rows[0]["RecordSource"].ToString(), dsSearchPara.Tables[0].Rows[0]["SelectFields"].ToString(), zSearchCondition, dsSearchPara.Tables[0].Rows[0]["SortOrder"].ToString(), 0, zServerName);
                        dsTotalRecord = new CommonSearchDataAccess().GetSearchRecords(nPageIndex, dsSearchPara.Tables[0].Rows[0]["RecordSource"].ToString(), dsSearchPara.Tables[0].Rows[0]["SelectFields"].ToString(), zSearchCondition, dsSearchPara.Tables[0].Rows[0]["SortOrder"].ToString(), 1, zServerName);
                    }
                    else
                    {
                        string initialCon = dsSearchPara.Tables[0].Rows[0]["InitialCondition"].ToString();
                        if (initialCon != null && initialCon.Length > 2)
                        {
                            string[] tempInitialConArray = Pervation.Common.CommonOperations.CommonMethods.GetStringArray(initialCon);
                            zSearchCondition = " where ";
                            for (int i = 0; i < tempInitialConArray.Length; i++)
                            {
                                if (tempInitialConArray[i].Length > 0)
                                {
                                    if (i == 0)
                                    {
                                        zSearchCondition = zSearchCondition + tempInitialConArray[i] + " '" + _FilteredBy[i] + "'";
                                    }
                                    else
                                    {
                                        zSearchCondition = zSearchCondition + " AND " + tempInitialConArray[i] + " '" + _FilteredBy[i] + "'";
                                    }
                                }
                            }
                            zSearchCondition = zSearchCondition + " And " + zSearcString;
                        }
                        else
                        {
                            zSearchCondition = " where " + zSearcString;
                        }
                        dsSearchData = new CommonSearchDataAccess().GetSearchRecords(nPageIndex, dsSearchPara.Tables[0].Rows[0]["RecordSource"].ToString(), dsSearchPara.Tables[0].Rows[0]["SelectFields"].ToString(), zSearchCondition, dsSearchPara.Tables[0].Rows[0]["SortOrder"].ToString(), 0);
                        dsTotalRecord = new CommonSearchDataAccess().GetSearchRecords(nPageIndex, dsSearchPara.Tables[0].Rows[0]["RecordSource"].ToString(), dsSearchPara.Tables[0].Rows[0]["SelectFields"].ToString(), zSearchCondition, dsSearchPara.Tables[0].Rows[0]["SortOrder"].ToString(), 1);
                    }
                }
                else
                {
                   //Stored Procedure
                    nStartRecord = ((nPageIndex - 1) * nRecordsPerPage) + 1;
                    nEndRecord = ((nPageIndex - 1) * nRecordsPerPage) + nRecordsPerPage;

                    bool bHasParams = false;
                    if (_ParameterValues.Length > 0)
                    {
                        for (int i = 0; i < _ParameterValues.Length; i++)
                        {
                            if (!bHasParams)
                            {
                                bHasParams = true;
                                zTempParaList = _ParameterValues[i];
                            }
                            else
                            {
                                zTempParaList = zTempParaList + "," + _ParameterValues[i];
                            }
                        }
                    }
                    string zSearchCondition = string.Empty;
                    dsSearchPara = new CommonSearchDataAccess().GetSearchType(_SearchCode.Trim());
                    string initialCon = dsSearchPara.Tables[0].Rows[0]["InitialCondition"].ToString();
                    if (initialCon != null && initialCon.Length > 2)
                    {
                        string[] tempInitialConArray = Pervation.Common.CommonOperations.CommonMethods.GetStringArray(initialCon);
                        zSearchCondition = "";
                        for (int i = 0; i < tempInitialConArray.Length; i++)
                        {
                            if (tempInitialConArray[i].Length > 0)
                            {
                                if (i == 0)
                                {
                                    zSearchCondition = zSearchCondition + tempInitialConArray[i] + " '" + _FilteredBy[i] + "'";
                                }
                                else
                                {
                                    zSearchCondition = zSearchCondition + " AND " + tempInitialConArray[i] + " '" + _FilteredBy[i] + "'";
                                }
                            }
                        }
                        zSearchCondition = zSearchCondition + " And " + zSearcString;
                    }
                    else
                    {
                        zSearchCondition = zSearcString;
                    }
                    dsSearchData = new CommonSearchDataAccess().GetSearchRecords(zTempParaList, _SearchCode, nStartRecord, nEndRecord, zSearchCondition);                  
                    dsSearchData.Tables[0].Columns.RemoveAt(0); //This is required only in a SP.
                }

                char[] cSep = { ',' };
                string[] zSelectFields = _SelectFields.Split(cSep);
                string[] zDisplayFields = _DisplayFields.Split(cSep);
                string zPrimaryKey = zSelectFields[0];

                DataSet dsTemp = dsSearchData.Clone();

                foreach (DataColumn dcol in dsTemp.Tables[0].Columns)
                {
                    bool bColFound = false;
                    string zColName = "";
                    for (int i = 0; i < zSelectFields.Length; i++)
                    {
                        if (dcol.ColumnName.Trim() == zSelectFields[i].Trim())
                        {

                            bColFound = true;
                            break;
                        }

                    }
                    if (!bColFound)
                    {
                        zColName = dcol.ColumnName.Trim();
                        dsSearchData.Tables[0].Columns.Remove(zColName);
                    }
                }

                DataColumn dc = new DataColumn("");

                dc.ColumnName = " ";
                dc.DataType = System.Type.GetType("System.Boolean");
                dc.DefaultValue = false;
                dsSearchData.Tables[0].Columns.Add(dc); 


                dsSearchData.Tables[0].Columns[dsSearchData.Tables[0].Columns.Count - 1].SetOrdinal(0);

                if (_SelectedItems != null && _SelectedItems.Length > 0)
                {
                    if (dsSearchData.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in dsSearchData.Tables[0].Rows)
                        {
                            for (int i = 0; i < _SelectedItems.Length; i++)
                            {
                                if (dr[zPrimaryKey].ToString().Trim() == _SelectedItems[i].ToString().Trim())
                                {
                                    dr[0] = true;
                                }
                            }
                        }
                    }
                }
                //----------------------------------------------------------------------------------------
                if (radGridViewMain.Columns.Count <= 0)
                {
                   /* GridViewCheckBoxColumn radDC_Select = new GridViewCheckBoxColumn();
                    radDC_Select.Header = "";
                    //radDC_Select.DataMemberBinding = new System.Windows.Data.Binding(zSelectFields[i]);
                   
                    radDC_Select.IsGroupable = false;
                    radDC_Select.Width = 25;
                    radDC_Select.IsFilterable = false;
                    radDC_Select.IsEnabled = true;
                    radDC_Select.IsReadOnly = false;
                    radGridViewMain.Columns.Add(radDC_Select);*/

                    for (int i = 0; i < (dsSearchData.Tables[0].Columns.Count); i++)
                    {
                        if (i == 0) { continue; }
                       

                        Telerik.Windows.Controls.GridViewColumn radDC;//=new GridViewDataColumn();

                        DataColumn dc1 = dsSearchData.Tables[0].Columns[i];

                        if (dc1.DataType == System.Type.GetType("System.Boolean"))
                        {
                            continue;

                            radDC = new Telerik.Windows.Controls.GridViewCheckBoxColumn();                         
                            radDC.Header = zDisplayFields[i - 1];
                            ((GridViewCheckBoxColumn)radDC).DataMemberBinding = new System.Windows.Data.Binding(zSelectFields[i - 1]);

                            radDC.IsReadOnly = true;
                            radDC.IsGroupable = false;
                            //radDC.DataFormatString
                            //radDC.Width = 100;
                            radDC.IsFilterable = false;
                            // radDC.IsEnabled = true;

                        }
                        else {
                            radDC = new Telerik.Windows.Controls.GridViewDataColumn();
                            radDC.Header = zDisplayFields[i - 1];
                            ((GridViewDataColumn)radDC).DataMemberBinding = new System.Windows.Data.Binding(zSelectFields[i - 1]);

                            radDC.IsReadOnly = true;
                            radDC.IsGroupable = false;
                            //radDC.DataFormatString
                            //radDC.Width = 100;
                            radDC.IsFilterable = false;
                            // radDC.IsEnabled = true;
                        }

                      

                      
                       

                        radGridViewMain.Columns.Add(radDC);
                        
                    }

                }

                DataTable CopyOf_dtGrid=dsSearchData.Tables[0].Copy();
                if(_IsStatusFields)
                { 
                    CopyOf_dtGrid = CommonTasks.CommonTasks.MakeTableStatusFieldsReadable(CopyOf_dtGrid,_FieldsWithStatus);
                }
                
                radGridViewMain.DataContext = CopyOf_dtGrid;
                if (radGridViewMain.Items.Count > 0)
                {
                    //this.radGridViewMain.SelectedItem = ((DataTable)this.radGridViewMain.ItemsSource).First();
                   // this.radGridViewMain.SelectedItem = this.radGridViewMain.Items[0];
                    //    radGridViewMain.Focus();
                    //    radGridViewMain.SelectedItem = radGridViewMain.Items[0];
                    //    radGridViewMain.Items[0] = radGridViewMain.Items[0];
                }

                //----------------------------------------------------------------------------------------  
               /* int c = 0;
                for (int a = 0; a < dsSearchData.Tables[0].Columns.Count;a++ )
                {
                    if (a == 0)  {c++; continue;  }

                    DataColumn dc1 =dsSearchData.Tables[0].Columns[a];

                    if (dc1.DataType == System.Type.GetType("System.Boolean"))
                    {
                        radGridViewMain.Columns[a] = new Telerik.Windows.Controls.GridViewCheckBoxColumn();
                    }
                    c++;
                }*/
               
                
                /*
                for (int p = 1; p < dsSearchData.Tables[0].Columns.Count; p++)
                {

                    if (dsSearchData.Tables[0].Columns[p].DataType == System.Type.GetType("System.Boolean"))
                    {
                       // radGridViewMain.Columns[p-1].DataControl.DataContext = dsSearchData.Tables[0].Columns[p];
                        //radGridViewMain.Columns[p].DataContext = dsSearchData.Tables[0].Columns[p];
                    }else{
                        radGridViewMain.Columns[p-1].DataContext = dsSearchData.Tables[0].Columns[p];
                        //radGridViewMain.Columns[p].DataContext = dsSearchData.Tables[0].Columns[p];
                    }
                    
                }

          
                for(int i=0 ;i<dsSearchData.Tables[0].Rows.Count;i++)
                {
                    DataRow tempDR=dsSearchData.Tables[0].Rows[i];
                  
                    for(int j=0;j<dsSearchData.Tables[0].Columns.Count;j++)
                    {
                        if (j == 0) { continue; }

                        if(dsSearchData.Tables[0].Columns[j].DataType == System.Type.GetType("System.Boolean"))
                        {
                            tempDR[j]=Convert.ToBoolean(dsSearchData.Tables[0].Rows[i][j].ToString());
                        }else{
                            tempDR[j]=dsSearchData.Tables[0].Rows[i][j];
                        }
                        
                    }
                    radGridViewMain.Items.Add(tempDR);
                }*/
              

                  
                if (_AllowMultipleSelection == false)
                {
                    // Comment by Dulip as not in WPF check if prob....

                    // uGrdData.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
                    //  uGrdData.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;

                    // uGrdData.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
                }
                            
                if (_HidePrimaryKeyField)
                {
                    radGridViewMain.Columns[1].IsVisible = true;
                }

                if (_AllowMultipleSelection == false)
                {
                    radGridViewMain.Columns[0].IsVisible = true;          // dulip
                }

                if (dsSearchData.Tables.Count > 1)
                {
                    nTotalRecords = int.Parse(dsSearchData.Tables[1].Rows[0][0].ToString());
                    //nTotalRecords = dsSearchData.Tables[1].Rows.Count;
                }
                else
                {                    
                   nTotalRecords = Convert.ToInt32(dsTotalRecord.Tables[0].Rows[0][0]);
                  //  nTotalRecords = dsSearchData.Tables[0].Rows.Count;
                }             
                //-----------------------------------
               //FitToContent(radGridViewMain);

                if (_SearchPara != null && _SearchPara.Tables[0].Rows.Count > 0)
                {
                    int i = 0;
                    foreach (DataRow dr in _SearchPara.Tables[0].Rows)
                    {
                        if (dr["length"] != null)                                   // if length column not null
                        {
                                                                                    //SET the Width of "SearchValue" Column.....
                            if (!dr["length"].ToString().Equals("") && Convert.ToInt32(dr["length"]) > 0)           //if length column not  "blank"  AND  greater than  0 (+)
                            {
                                string colNum = dr["SearchValue"].ToString();
                               
                                if (radGridViewMain.Columns[i] != null)             // if SearchValue column not null--------check 2
                                {
                                    string colLength=dr["length"].ToString();
                                    radGridViewMain.Columns[i].Width = Convert.ToInt32(colLength);          //set SearchValue Column width as in dr["length"]------Convert.ToInt32(colNum)

                                    if (dr["Alignment"]==null)
                                    {
                                        radGridViewMain.Columns[i].TextAlignment = TextAlignment.Left;
                                    }
                                    else if (dr["Alignment"].ToString() == _Basic_Windows.Enums.CommonEnums.Alignment.Right)
                                    {
                                        radGridViewMain.Columns[i].TextAlignment = TextAlignment.Right;
                                    }
                                    else if (dr["Alignment"].ToString() == _Basic_Windows.Enums.CommonEnums.Alignment.Left)
                                    {
                                        radGridViewMain.Columns[i].TextAlignment = TextAlignment.Left;
                                    }
                                    else if (dr["Alignment"].ToString() == _Basic_Windows.Enums.CommonEnums.Alignment.Center)
                                    {
                                        radGridViewMain.Columns[i].TextAlignment = TextAlignment.Center;
                                    }
                                    else
                                    {
                                        radGridViewMain.Columns[i].TextAlignment = TextAlignment.Left;
                                    }
                                }
                            }
                            else
                            {
                                if (!dr["length"].ToString().Equals("") && Convert.ToInt32(dr["length"]) == 0)          //if length column not "blank"  AND  Equal to  0 
                                {
                                    if (radGridViewMain.Columns[i] != null)                                 // if SearchValue column not null---------Convert.ToInt32(dr["SearchValue"].ToString())
                                        radGridViewMain.Columns[i].IsVisible = false;                       //Hide the SearchValue Column-------Convert.ToInt32(dr["SearchValue"].ToString())
                                }
                            }
                        }
                        i++;
                    }
                }
               
                ApplyPaging(nTotalRecords, nRecordsPerPage, nPageIndex);
                //------------------------------
               
                if (nTotalRecords == 0)
                {
                    lblMessage.Text = "No Records Found";
                    btnSelect.IsEnabled = false;
                }
                else
                {                
                    btnSelect.IsEnabled = true;
                }

                //------------------------------
                if (radGridViewMain.Items.Count > 0)       // Get the Row Count
                {
                    radGridViewMain.Focus();

                }
                else
                {
                    txtSearchData.Focus();
                    txtSearchData.SelectAll();
                }                                          
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show(ex.Message + "\n" + ex.InnerException, "Error !", winMessageBox.buttonPanel.OKOnly, winMessageBox.icon.Warnning);               
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        private void LoadDataForSelectedCode(int nPageIndex, string zServerName)
        {
            try
            {
                DataSet dsSearchData = null;
                DataSet dsSearchPara = null;
                DataSet dsTotalRecord = null;
                int nStartRecord = 0;
                int nEndRecord = 0;
                int nRecordsPerPage = 0;
                int nTotalRecords = 0;

                string zTempParaList = "";
                string zSearcString = "";
                if (_InitialSearchString != null && _InitialSearchString != string.Empty)
                {
                    txtSearchData.Text = _InitialSearchString.ToString();
                    _InitialSearchString = "";
                }
                string zSearchData = txtSearchData.Text.Trim().Replace("'", "''");
                zSearchData = zSearchData.Replace(",", "");
                lblMessage.Text = "";

                if (_RecordsPerPager <= 0)
                {
                    nRecordsPerPage = _CRECORDSPERPAGE;
                }
                else
                {
                    nRecordsPerPage = _RecordsPerPager;
                }

                if (zSearchData == "")
                {
                    zSearcString = cboSearcPara.SelectedValue + "  = ";
                }
                else
                {
                    zSearcString = cboSearcPara.SelectedValue + " = '" + zSearchData + "'";
                }


                if (_RecordSourceType == null || _RecordSourceType == "VW")
                {        //View
                    string zSearchCondition = " where " + zSearcString;

                    dsSearchPara = new CommonSearchDataAccess().GetSearchType(_SearchCode.Trim());

                    if (zServerName != "")
                    {
                        dsSearchData = new CommonSearchDataAccess().GetSearchRecords(nPageIndex, dsSearchPara.Tables[0].Rows[0]["RecordSource"].ToString(), dsSearchPara.Tables[0].Rows[0]["SelectFields"].ToString(), zSearchCondition, dsSearchPara.Tables[0].Rows[0]["SortOrder"].ToString(), 0, zServerName);
                        dsTotalRecord = new CommonSearchDataAccess().GetSearchRecords(nPageIndex, dsSearchPara.Tables[0].Rows[0]["RecordSource"].ToString(), dsSearchPara.Tables[0].Rows[0]["SelectFields"].ToString(), zSearchCondition, dsSearchPara.Tables[0].Rows[0]["SortOrder"].ToString(), 1, zServerName);
                    }
                    else
                    {
                        dsSearchData = new CommonSearchDataAccess().GetSearchRecords(nPageIndex, dsSearchPara.Tables[0].Rows[0]["RecordSource"].ToString(), dsSearchPara.Tables[0].Rows[0]["SelectFields"].ToString(), zSearchCondition, dsSearchPara.Tables[0].Rows[0]["SortOrder"].ToString(), 0);
                        dsTotalRecord = new CommonSearchDataAccess().GetSearchRecords(nPageIndex, dsSearchPara.Tables[0].Rows[0]["RecordSource"].ToString(), dsSearchPara.Tables[0].Rows[0]["SelectFields"].ToString(), zSearchCondition, dsSearchPara.Tables[0].Rows[0]["SortOrder"].ToString(), 1);
                    }
                }
                else
                {                                                              //Stored Procedure
                    nStartRecord = ((nPageIndex - 1) * nRecordsPerPage) + 1;
                    nEndRecord = ((nPageIndex - 1) * nRecordsPerPage) + nRecordsPerPage;

                    bool bHasParams = false;
                    if (_ParameterValues.Length > 0)
                    {
                        for (int i = 0; i < _ParameterValues.Length; i++)
                        {
                            if (!bHasParams)
                            {
                                bHasParams = true;
                                zTempParaList = _ParameterValues[i];
                            }
                            else
                            {
                                zTempParaList = zTempParaList + "," + _ParameterValues[i];
                            }
                        }
                    }

                    dsSearchData = new CommonSearchDataAccess().GetSearchRecords(zTempParaList, _SearchCode, nStartRecord, nEndRecord, zSearcString);
                    dsSearchData.Tables[0].Columns.RemoveAt(0);         //This is required only in a SP.
                }

                char[] cSep = { ',' };
                string[] zSelectFields = _SelectFields.Split(cSep);
                string[] zDisplayFields = _DisplayFields.Split(cSep);
                string zPrimaryKey = zSelectFields[0];

                DataSet dsTemp = dsSearchData.Clone();

                foreach (DataColumn dcol in dsTemp.Tables[0].Columns)
                {
                    bool bColFound = false;
                    string zColName = "";                   
                    for (int i = 0; i < zSelectFields.Length; i++)
                    {
                        if (dcol.ColumnName.Trim() == zSelectFields[i].Trim())
                        {
                            
                            bColFound = true;
                            break;
                        }

                    }
                    if (!bColFound)
                    {
                        zColName = dcol.ColumnName.Trim();
                        dsSearchData.Tables[0].Columns.Remove(zColName);
                    }
                }

                DataColumn dc = new DataColumn("");

                dc.ColumnName = " ";
                dc.DataType = System.Type.GetType("System.Boolean");
                dc.DefaultValue = false;
                dsSearchData.Tables[0].Columns.Add(dc);
                dsSearchData.Tables[0].Columns[dsSearchData.Tables[0].Columns.Count - 1].SetOrdinal(0);

                if (_SelectedItems != null && _SelectedItems.Length > 0)
                {
                    if (dsSearchData.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in dsSearchData.Tables[0].Rows)
                        {
                            for (int i = 0; i < _SelectedItems.Length; i++)
                            {
                                if (dr[zPrimaryKey].ToString().Trim() == _SelectedItems[i].ToString().Trim())
                                {
                                    dr[0] = true;
                                }
                            }
                        }
                    }
                }
               

                radGridViewMain.DataContext = dsSearchData.Tables[0];

                if (_AllowMultipleSelection == false)
                {                   
                    radGridViewMain.CanUserDeleteRows = false;
                    radGridViewMain.CancelEdit();
                    radGridViewMain.SelectionMode = System.Windows.Controls.SelectionMode.Single;
                }


                if (radGridViewMain.Columns.Count > 0)
                {
                    foreach (GridViewDataColumn col in radGridViewMain.Columns)
                    {
                        for (int i = 0; i < zSelectFields.Length; i++)
                        {
                            if (col.Header.ToString() == zSelectFields[i])
                            {
                                col.Header = zDisplayFields[i];
                            }
                        }
                    }
                }

                if (_HidePrimaryKeyField)
                {
                    radGridViewMain.Columns[1].IsVisible = true;
                }

                if (_AllowMultipleSelection == false)
                {
                    radGridViewMain.Columns[0].IsVisible = true;
                }

                if (dsSearchData.Tables.Count > 1)
                {
                    nTotalRecords = int.Parse(dsSearchData.Tables[1].Rows[0][0].ToString());
                }
                else
                {                   
                    nTotalRecords = Convert.ToInt32(dsTotalRecord.Tables[0].Rows[0][0]);
                }
                
                FitToContent(radGridViewMain);

                radGridViewMain.CanUserResizeColumns = true;
                if (_SearchPara != null && _SearchPara.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in _SearchPara.Tables[0].Rows)
                    {
                        if (dr["length"] != null)
                        {
                            if (!dr["length"].ToString().Equals("") && Convert.ToInt32(dr["length"]) > 0)
                            {                               
                                if (radGridViewMain.Columns[0] != null)
                                    radGridViewMain.Columns[0].Width = (int)dr["length"];
                            }
                            else
                            {
                                if (!dr["length"].ToString().Equals("") && Convert.ToInt32(dr["length"]) == 0)
                                {                                 
                                    if (radGridViewMain.Columns[0] != null)
                                        radGridViewMain.Columns[0].IsVisible = true;
                                }
                            }
                        }
                    }
                }

                ApplyPaging(nTotalRecords, nRecordsPerPage, nPageIndex);

                if (nTotalRecords == 0)
                {
                    lblMessage.Text = "No Records Found";
                     btnSelect.IsEnabled = false;
                }
                else
                {
                    btnSelect.IsEnabled = true;
                }
                if (radGridViewMain.Items.Count > 0)
                {
                    radGridViewMain.Focus();
                }
                else
                {
                    txtSearchData.Focus();
                    txtSearchData.SelectAll();
                }

                //}

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(this, ex.Message + "\n" + ex.InnerException, "Error !", MessageBoxButton.OK, MessageBoxImage.Error);
                //throw;
            }
        }


        //bellow FitToContent() added ----- Dulip------resize Datagrid Columns
        private void FitToContent(RadGridView dg)
        {
            // where dg is my data grid's name...
            try
            {
               // for (int i = 1; i < dg.Columns.Count;i++)
                foreach(Telerik.Windows.Controls.GridViewColumn column in dg.Columns)
                {                    
                    //if you want to size ur column as per the cell content               
                    //column.Width = new GridViewLength(1.0,GridViewLengthUnitType.SizeToCells);
                    //if you want to size ur column as per the column header
                    // column.Width = new GridViewLength(1.0, GridViewLengthUnitType.SizeToHeader);
                    //if you want to size ur column as per both header and cell content

                    column.Width = new GridViewLength(1.0, GridViewLengthUnitType.Auto);
                }
            }catch(Exception ex)
            {}
        }

        private void ApplyPaging(int nTotalRecordCount, int nRecordsPerPage, int nCurrentPage)
        {
            try
            {
                int nRecordCount = 0;
                int nPageCount = 0;

                if (nTotalRecordCount == 0)
                {
                    nPageCount = 1;
                }
                else
                {
                    nRecordCount = nTotalRecordCount;

                    if (nRecordCount % nRecordsPerPage != 0)
                    {
                        nPageCount = (nRecordCount / nRecordsPerPage) + 1;
                    }
                    else
                    {
                        nPageCount = nRecordCount / nRecordsPerPage;
                    }
                }
                ucSearchPaging.TotalPageCount = nPageCount;
                ucSearchPaging.PageIndex = nCurrentPage;
            }
           catch(Exception ex)
            { }
        }
        private void CreateDataGrid()
        {
            try
            {
                char[] cSep = { ',' };
                string[] zSelectFields = _SelectFields.Split(cSep);
                string[] zDisplayFields = _DisplayFields.Split(cSep);
                string[] zDataTypes = _DataType.Split(cSep);

                DataTable dtTableStructure = new DataTable();

                DataColumn dc = new DataColumn("");
                dc.ColumnName = " ";
                dc.DataType = System.Type.GetType("System.Boolean");
                dtTableStructure.Columns.Add(dc);

                for (int i = 0; i < zSelectFields.Length; i++)
                {

                    dc = new DataColumn("");
                    dc.ColumnName = zSelectFields[i];
                    dc.Caption = zDisplayFields[i];
                    dtTableStructure.Columns.Add(dc);
                }
                radGridViewMain.DataContext = dtTableStructure;

                if (radGridViewMain.Columns.Count > 0)
                {
                    foreach (GridViewDataColumn col in radGridViewMain.Columns)
                    {
                        if (col.Header.ToString() != "")
                        {
                            col.IsVisible = true;
                        }
                    }
                }
            }
           catch(Exception ex)
            { }
        }

        private void ucSearchPaging_OnPageIndexChange(int nPageIndex)
        {
            try
            {
                LoadData(nPageIndex);
            }
           catch(Exception ex)
            { }
        }
        /// <summary>
        /// /////////////////////////////////////////////////////////////
        /// </summary>
        private void SelectRecord()
        {
            try
            {
                _Cancel = false;
                lblMessage.Text = "";
                string zTemp = "";
                bool bSelected = false;
                bool bMultiple = false;

                if (_dtSelected == null)
                {
                    _dtSelected = ((DataTable)radGridViewMain.DataContext).Clone();
                    DataColumn[] _dc = new DataColumn[] { _dtSelected.Columns[1] };
                    _dtSelected.PrimaryKey = _dc;
                }

                DataTable dtCurrentData = ((DataTable)radGridViewMain.DataContext).Copy();

                foreach (DataRow dr in dtCurrentData.Rows)
                {
                    if (bool.Parse(dr[0].ToString()))
                    {
                        DataRow drFind = _dtSelected.Rows.Find(dr[1].ToString());
                        if (drFind == null)
                        {
                            _dtSelected.ImportRow(dr);
                        }
                    }
                }
                if (_dtSelected.Rows.Count == 0)
                {
                    lblMessage.Text = "Record not selected";
                    return;
                }
                else
                {
                    if (_dtSelected.Rows.Count > 1 && _AllowMultipleSelection == false)
                    {
                        lblMessage.Text = "Cannot select multiple records";
                        return;
                    }
                }
                SelectedData = _dtSelected;
                this.Close();
            }
           catch(Exception ex)
            { }
        }
        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_AllowMultipleSelection)
                {
                    return;
                }
                foreach (Object Item in radGridViewMain.Items)
                {
                    DataRow row = (DataRow)Item;

                    if (row != null)
                    {
                        row[0] = false;
                    }
                }

                DataRow TRow = (DataRow)radGridViewMain.SelectedItem;
                TRow[0] = true;
                SelectRecord();
            }catch(Exception ex)
            {}
        }

        private void frmCommonSearch1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (_Cancel)
                {
                    _dtSelected = ((DataTable)radGridViewMain.DataContext).Clone();
                    SelectedData = _dtSelected;
                }
            }
           catch(Exception ex)
            { }
        }

        private void radGridViewMain_Initialized(object sender, System.EventArgs e)
        {
            // not working in wpf ------ Dulip

            /*
             radGridViewMain.DisplayLayout.GroupByBox.Hidden = true;
            radGridViewMain.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            radGridViewMain.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            radGridViewMain.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.Default;
            radGridViewMain.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.XPThemed;
            radGridViewMain.DisplayLayout.Override.RowSelectorAppearance.Image = res_CommonWindows.img_16_row_selector;
            radGridViewMain.DisplayLayout.Override.RowAlternateAppearance.BackColor = _GridAlternateColour;
             */


        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadData(1);
            }
           catch(Exception ex)
            { }
        }

        private void cboSearcPara_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                int nIndex = 0;
                switch (e.Key)
                {
                    case Key.F1:
                        nIndex = 0;
                        break;

                    case Key.F2:
                        nIndex = 1;
                        break;

                    case Key.F3:
                        nIndex = 2;
                        break;

                    case Key.F4:
                        nIndex = 3;
                        break;

                    case Key.F5:
                        nIndex = 4;
                        break;

                    case Key.F6:
                        nIndex = 5;
                        break;

                    case Key.F7:
                        nIndex = 6;
                        break;

                    case Key.F8:
                        nIndex = 7;
                        break;

                    case Key.F9:
                        nIndex = 8;
                        break;

                    case Key.F10:
                        nIndex = 9;
                        break;

                    case Key.F11:
                        nIndex = 10;
                        break;

                    case Key.F12:
                        nIndex = 11;
                        break;
                }


                switch (e.Key)
                {
                    case Key.F1:
                    case Key.F2:
                    case Key.F3:
                    case Key.F4:
                    case Key.F5:
                    case Key.F6:
                    case Key.F7:
                    case Key.F8:
                    case Key.F9:
                    case Key.F10:
                    case Key.F11:
                    case Key.F12:
                        if (cboSearcPara.Items.Count >= nIndex + 1)
                        {
                            cboSearcPara.SelectedIndex = nIndex;
                        }
                        else
                        {
                            cboSearcPara.SelectedIndex = cboSearcPara.Items.Count - 1;
                        }
                        break;

                    case Key.Enter:
                        txtSearchData.Focus();
                        break;
                }
            }
           catch(Exception ex)
            { }
        }    
        private void radGridViewMain_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                //if (e.Key == Key.Up || e.Key == Key.Down)
                //{
                //    if (_AllowMultipleSelection)
                //    {
                //        return;
                //    }
                //    foreach (DataGridRow row in radGridViewMain.Items)
                //    {
                //        if (row != null)
                //        {
                //            DataRowView rowView = (DataRowView)row.Item;
                //            rowView.Row[0] = false;
                //        }
                //    }

                //    DataGridRow GridRow = (DataGridRow)radGridViewMain.SelectedItem;
                //    DataRowView RowView = (DataRowView)GridRow.Item;
                //    RowView.Row[0] = true;
                //    SelectRecord();
                //}               
                //else 


                //if (e.Key == Key.Enter)
                //{
                //    if (radGridViewMain.SelectedItems != null)
                //    {
                //        if (radGridViewMain.SelectedItems.Count > 0)
                //        {
                //            if (_AllowMultipleSelection)
                //            {
                //                return;
                //            }
                //            foreach (Object Item in radGridViewMain.Items)
                //            {
                //                DataRow row = (DataRow)Item;

                //                if (row != null)
                //                {
                //                    row[0] = false;
                //                }
                //            }

                //            DataRow TRow = (DataRow)radGridViewMain.SelectedItem;
                //            TRow[0] = true;
                //            SelectRecord();
                //        }
                //    }
                //}
            }
           catch(Exception ex)
            { }
        }

        private void txtSearchData_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    LoadData(1);
                }
                else if (//e.KeyChar == (char)33 ||
                    //e.KeyChar == (char)34 ||
                    //e.KeyChar == (char)35 ||
                    //e.KeyChar == (char)36 ||
                    //e.KeyChar == (char)37 ||
                    //e.KeyChar == (char)38 ||
                    //e.KeyChar == (char)39 ||
                    //e.KeyChar == (char)40 ||
                    //e.KeyChar == (char)41 ||
                    //e.KeyChar == (char)42 ||
                    //e.KeyChar == (char)43 ||
                    e.Key == Key.OemComma //||
                    //e.KeyChar == (char)45 ||
                    //e.KeyChar == (char)46 ||
                    //e.KeyChar == (char)47
                    )
                {
                    e = null;  //---dulip
                    //e.Key = Key.None;
                    //
                }
            }
           catch(Exception ex)
            { }
        }
        private void radGridViewMain_Mouse_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (_AllowMultipleSelection)
                {
                    return;
                }
                foreach (Object Item in radGridViewMain.Items)
                {
                    DataRow row = (DataRow)Item;
                    if (row != null)
                    {
                        row[0] = false;
                    }
                }
                DataRow TRow = (DataRow)radGridViewMain.SelectedItem;
                TRow[0] = true;
                SelectRecord();
            }catch(Exception ex)
            {

            }
        }

        private void uGrdSelected_Initilized(object sender, System.EventArgs e)
        {
            // not working in wpf ------ Dulip
            /*
            uGrdSelected.DisplayLayout.GroupByBox.Hidden = true;
            uGrdSelected.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            uGrdSelected.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            uGrdSelected.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            uGrdSelected.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;

            uGrdSelected.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.Default;
            uGrdSelected.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.XPThemed;
            uGrdSelected.DisplayLayout.Override.RowSelectorAppearance.Image = res_CommonWindows.img_16_row_selector_orange;

            //radGridViewMain.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.FromArgb(217, 236, 255);
            uGrdSelected.DisplayLayout.Override.RowAlternateAppearance.BackColor = _SelectedGridAlternateColour;

            uGrdSelected.DisplayLayout.Bands[0].Columns["Delete"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            uGrdSelected.DisplayLayout.Bands[0].Columns["Delete"].Width = 30;
            uGrdSelected.DisplayLayout.Bands[0].Columns["Delete"].CellButtonAppearance.Image = res_CommonWindows.img_16_row_delete_red;
            uGrdSelected.DisplayLayout.Bands[0].Columns["Delete"].CellAppearance.Image = res_CommonWindows.img_16_row_delete_red;
            */
        }

        /*private void btnAddToList_Click(object sender, RoutedEventArgs e)
        {           
            this.Width = 958;
            this.Height = 750;

            if (_dtSelected == null)
            {
                PrepareSelectedDataTable();
            }

            foreach (DataRow dr in ((DataTable)radGridViewMain.DataContext).Rows)
            {
                if (bool.Parse(dr[0].ToString()))
                {
                    DataRow drFind = _dtSelected.Rows.Find(dr[1].ToString());
                    if (drFind == null)
                    {
                        _dtSelected.ImportRow(dr);
                    }
                }
            }           
        }
        */
        private void PrepareSelectedDataTable()
        {
            try
            {
                _dtSelected = new DataTable();
                _dtSelected = ((DataTable)radGridViewMain.DataContext).Clone();

                DataColumn dc = _dtSelected.Columns.Add("Delete", System.Type.GetType("System.String"));
                dc.Caption = "";

                _dtSelected = (DataTable)radGridViewMain.DataContext;  ///-----put by-------dulip

                _dtSelected.AcceptChanges();

                DataColumn[] _dc = new DataColumn[] { _dtSelected.Columns[1] };
                _dtSelected.PrimaryKey = _dc;
            }
           catch(Exception ex)
            { }
        }

        //instead of uGrdSelected_ClickCellButton


        // Stop here //27/Nov/2014
        private void uGrdSelected_SelectedCells_Changed(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                string ComparingValue = "";
                foreach (DataGridRow row in radGridViewMain.Items)
                {
                    DataRowView RowView = (DataRowView)row.Item;
                    System.Windows.Controls.DataGridCell SelectedCell = (System.Windows.Controls.DataGridCell)radGridViewMain.SelectedCells[0].Item;
                    ComparingValue = ((DataRowView)radGridViewMain.SelectedCells[0].Item).Row[1].ToString();

                    if (RowView.Row[1].ToString() == ComparingValue) //------Edited by Dulip
                    {
                        RowView.Row[0] = false;              // Dulip.... 
                        //uGrdSelected.UpdateData(); ----- // Dulip.... as not working in wpf
                        break;
                    }
                }

                _dtSelected.Rows.Remove(_dtSelected.Rows.Find(ComparingValue));
            }
            catch (Exception ex)
            { }
        }

        private void ucSearchPaging_Loaded(object sender, RoutedEventArgs e)
        {
            AddHotKeys();
        }

        private void ucSearch_Paging_OnOageIndexChanged(int nPageIndex)
        {
            try
            {
                LoadData(nPageIndex);
            }
            catch (Exception ex)
            { }
        }

        private void radGridViewMain_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {

        }

        private void win_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {

                SelectRecord();
            }
            catch (Exception ex)
            { }
        }

        private void radGridViewMain_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            
            {               
                if (e.Key == Key.Enter)
                {
                    if (radGridViewMain.SelectedItems != null)
                    {
                        if (radGridViewMain.SelectedItems.Count > 0)
                        {
                            if (_AllowMultipleSelection)
                            {
                                return;
                            }
                            foreach (Object Item in radGridViewMain.Items)
                            {
                                DataRow row = (DataRow)Item;

                                if (row != null)
                                {
                                    row[0] = false;
                                }
                            }

                            DataRow TRow = (DataRow)radGridViewMain.SelectedItem;
                            TRow[0] = true;
                            SelectRecord();
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }

       /* private void UpdateSelectCountLabel()
        {
            if (_dtSelected != null && _dtSelected.Rows.Count > 0)
            {
                //lblSelectedCount.Content = _dtSelected.Rows.Count.ToString() + " Record(s) selected.";
            }
        }*/

       /* private void ucSearchPaging_OnPageIndexChanged(int nPageIndex)
        {
            LoadData(nPageIndex);
        }  */     


    }
}
