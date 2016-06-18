using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;

namespace GNW.ILS.WPF
{
    /// <summary>
    /// Interaction logic for LoggingView.xaml
    /// </summary>
    public partial class LoggingView
    {
        //DataTable _dTable;

        //private string strMinDate = string.Empty;
        //private string strMaxDate = string.Empty;
        //private string strMinimumLength = string.Empty;
        //private UInt16 NoOfLogin = 0;
        //private bool bLoadMain = false;
        private int _errorCode;
        //private string _errorMessage;
        //private string _zCompanyName;

        //string _ENTITY_ID;
        //string _MAC_ADDRESS;
        //string _LOGIN_LOCATION;

        //#region Properties

        //public int RunMain { get; set; }
        //public string LoginUsername { get; set; }
        //public int CurrentCompanyCode { get; set; }
        //public decimal SessionID { get; set; }
        //public string CurrentPassword { get; set; }

        //private string _UserLocationCode = "";
        //public string UserLocationCode
        //{
        //    get { return _UserLocationCode; }
        //    set { _UserLocationCode = value; }
        //}

        //public DataTable AvailableCompanyAccounts { get; set; }

        //private string _FirstName = "";
        //public string FirstName
        //{
        //    get { return _FirstName; }
        //    set { _FirstName = value; }
        //}

        //public int LoginType { get; set; }
        //public bool bCheckMAC { get; set; }

        //#endregion

        public LoggingView()
        {
            try
            {
                InitializeComponent();
                Common.FlowView.Push(this);
                //LoadCompanyDetails();
                //IsVisibleChanged += LoggingView_IsVisibleChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " -Stack/n" + ex.StackTrace);
            }
        }

        //private void LoggingView_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        //{
        //    if ((bool)e.NewValue)
        //    {
        //        Dispatcher.BeginInvoke(DispatcherPriority.ContextIdle, new Action(() => TxtUserName.Focus()));
        //    }
        //}

        private void LoggingView_OnLoaded(object sender, RoutedEventArgs e)
        {
            ////IsToolbar = false;
            //BtnSignIn.IsDefault = true;                 // triggers when press Enter Key ---dulip
            //try
            //{
            //    // object Load Company name in CompanyHeader.xml fil
            //    XmlDocument xmlDocument = new XmlDocument();

            //    // to get XML Node list in the specifed Xpath              
            //    string strXPath = ConfigurationManager.AppSettings["XMLPath"];
            //    strXPath = strXPath + "\\CompanyHeader.xml";
            //    xmlDocument.Load(strXPath);
            //    XmlNodeList xmlNodeListName = xmlDocument.SelectNodes("CompanyConfiguration/HeaderFile/CompanyName");

            //    DataSet dataSet = new DataSet();
            //    DataTable dataTable = dataSet.Tables.Add("DataTable1");
            //    dataTable.Columns.Add("Company Name");

            //    foreach (XmlNode companyName in xmlNodeListName)
            //    {
            //        //cmbCompanyName.Items.Add(CompanyName.InnerText);
            //        DataRow dataRow = dataTable.NewRow();
            //        dataRow["Company Name"] = companyName.InnerText;
            //        dataTable.Rows.Add(dataRow);
            //    }

            //    dataTable.AcceptChanges();
            //    dataSet.AcceptChanges();

            //    XmlNodeList xmlMinDate = xmlDocument.SelectNodes("CompanyConfiguration/LoginCondition/Date/MinDate");
            //    XmlNodeList xmlMaxDate = xmlDocument.SelectNodes("CompanyConfiguration/LoginCondition/Date/MaxDate");
            //    XmlNodeList xmlMinumLength = xmlDocument.SelectNodes("CompanyConfiguration/LoginCondition/Date/PasswardMinilength");
            //    strMinDate = xmlMinDate.Item(0).InnerText;
            //    strMaxDate = xmlMaxDate.Item(0).InnerText;
            //    strMinimumLength = xmlMinumLength.Item(0).InnerText;
            //    xmlDocument.SelectNodes("CompanyConfiguration/HeaderFile/CompanyName");
            //    //CompanyName = xmlCompanyName.Item(0).InnerText;
            //    _ENTITY_ID = ModuleCodes.LogOnSystem;   //LOG_SYS

            //    bCheckMAC = Convert.ToBoolean(ConfigurationManager.AppSettings["CheckMAC"]);

            //    if (bCheckMAC)
            //    {
            //        _MAC_ADDRESS = NetworkUtility.GetMACAddress();
            //        TxtMacAddress.Text = "MAC : " + _MAC_ADDRESS;
            //    }
            //    else
            //    {
            //        TxtMacAddress.Text = "MAC : " + "";
            //    }

            //    int zCompanyCode = Convert.ToInt32(CommonMethods.GetSystemParameterValue("DEFAULT_COMPANY_CODE"));
            //    DataSet dsCompany = CommonMethods.GetReportCampanyDetails(zCompanyCode);

            //    if (dsCompany.Tables[0].Rows.Count > 0)
            //    {

            //        CompanyName = dsCompany.Tables[0].Rows[0]["CompanyName"].ToString();
            //        CompanyAddress = dsCompany.Tables[0].Rows[0]["CompanyAddress"].ToString();
            //        CompanyTel = dsCompany.Tables[0].Rows[0]["CompanyTelNo"].ToString();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message + " -Stack/n" + ex.StackTrace);
            //}
        }

        //private void LoadCompanyDetails()
        //{
        //    try
        //    {
        //        CompanyDetailLogic logic = new CompanyDetailLogic();
        //        DataSet ds = logic.GetAllCompany();

        //        if (ds.Tables[0].Rows.Count > 0)
        //        {
        //            _dTable = ds.Tables[0].Clone();
        //            ds.Tables[0].Select(SystemFields._IsActive_ + "='true'").CopyToDataTable(_dTable, LoadOption.OverwriteChanges);

        //            if (CbCompany.Items.Count > 0) { CbCompany.Items.Clear(); }

        //            foreach (DataRow item in _dTable.Rows)
        //            {
        //                string eachCompanyName = item[1].ToString();
        //                CbCompany.Items.Add(eachCompanyName);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            Common.LoadProgressBar();
            //RunBackgroundWorker();
            if (ValidateForm())
            {
                //_zCompanyName = CbCompany.SelectedItem.ToString();
                //LoginUsername = TxtUserName.Text.Trim();
                //CurrentPassword = PwdBox.Password.Trim();
                RunBackgroundWorker();
            }
            else
            {
                Common.FlowView.Pop();
                Common.AddView(Common.FlowView.Peek());
            }
        }

        private void RunBackgroundWorker()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            ////Thread.Sleep(5000);
            //try
            //{
            //    _errorCode = 0;
            //    _errorMessage = string.Empty;
            //    DataRow[] zCompanyCodes = _dTable.Select(SystemFields._CompanyName_ + "='" + _zCompanyName + "'");
            //    int iUserCurrentCompanyCode = Convert.ToInt32(zCompanyCodes[0][0]);
            //    Common.SystemVersion = CommonMethods.GetSystemParameterValue("SYS_VERSION");

            //    if (Common.SystemVersion != ConfigurationManager.AppSettings["AppVersion"])
            //    {
            //        _errorCode = 1;
            //        return;
            //    }

            //    object activeModule;
            //    DataTable dtFinancialYear;
            //    UserEnt objUser;
            //    bool bRetVal = UserAuthentication(iUserCurrentCompanyCode, LoginUsername, CurrentPassword, out objUser, out activeModule, out dtFinancialYear);

            //    Common.Assign_All_CommonStaticProperties_to_UCBase_WinBase();

            //    if (bRetVal)
            //    {
            //        if (!objUser.IsUserActive)
            //        {
            //            _errorCode = 2;
            //            return;
            //        }
            //        else
            //        {
            //            Common._LoginId = objUser.LoginId;
            //            Common._LoginName = objUser.UserName;
            //            Common._UserCurrentCompanyCode = iUserCurrentCompanyCode;    //Get Comp Code from CompGirdView
            //            Common._DefaultCurrencyCode = objUser.CurrencyCode;
            //            Common._UserCurrentPharmacyLocationCode = "";
            //            CompanyAllFinancialYear = dtFinancialYear;
            //            CurrentCompanyCode = iUserCurrentCompanyCode;
            //            FirstName = objUser.FirstName;
            //            Common.FirstName = objUser.FirstName;
            //            Common.LastName = objUser.LastName;
            //            Common.Image = objUser.Image;
            //            AvailableCompanyAccounts = objUser.AvailableCompanyAccounts;

            //            DataSet dsCompany = CommonMethods.GetReportCampanyDetails(Common._UserCurrentCompanyCode);

            //            if (dsCompany.Tables[0].Rows.Count > 0)
            //            {
            //                Common.CompanyName = dsCompany.Tables[0].Rows[0]["CompanyName"].ToString();
            //                Common.CompanyAddress = dsCompany.Tables[0].Rows[0]["CompanyAddress"].ToString();
            //                Common.CompanyTel = dsCompany.Tables[0].Rows[0]["CompanyTelNo"].ToString();
            //            }

            //            DataSet dsLocation = CommonMethods.GetDefaultLocationDetails(Common._UserCurrentCompanyCode, Common._LoginId);

            //            if (dsLocation.Tables[0].Rows.Count > 0)
            //            {
            //                Common.DefaultLocation = dsLocation.Tables[0].Rows[0]["LocationCode"].ToString();
            //                Common.DefaultLocationName = dsLocation.Tables[0].Rows[0]["LocationDescription"].ToString();
            //            }

            //            if (objUser.IsFirstTime)
            //            {          //First Time
            //                LoginType = 1;
            //            }
            //            else
            //            {
            //                if (objUser.NoOfDays <= 0)
            //                {    //Password expired. User must change the password
            //                    LoginType = 2;
            //                    _errorCode = 3;
            //                }
            //                else if (objUser.NoOfDays <= new PasswordPolicy().DaysToInform)
            //                {
            //                    LoginType = 3;     //Just give the user a friendly reminder to change the password
            //                    //if (CustomMessageBox.Show("Password will be expire in " + objUser.NoOfDays + " day(s). Do you wish to change the password now ?", "Password Expiratoin Reminder", winMessageBox.buttonPanel.YESNO, winMessageBox.icon.Question) == winMessageBox.userResult.YES)
            //                    //{
            //                    //    LoginType = 4;
            //                    //}
            //                    //else
            //                    //{
            //                    //    LoginType = 0;
            //                    //}
            //                }
            //                else
            //                {   //Normal login routine
            //                    LoginType = 0;
            //                }
            //            }
            //        }

            //        #region MAC ADDRESS VALIDATION
            //        if (bCheckMAC)
            //        {
            //            DataSet dsMac = CommonMethods.GetMACAddressDetails(_MAC_ADDRESS);
            //            if (dsMac.Tables[0].Rows.Count > 0)
            //            {
            //                if (!Convert.ToBoolean(dsMac.Tables[0].Rows[0]["IsActive"]))
            //                {
            //                    _errorCode = 4;
            //                }
            //            }
            //            else
            //            {
            //                _errorCode = 5;
            //            }
            //        }
            //        #endregion
            //    }
            //    else
            //    {
            //        _errorCode = 6;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    if (ex.Message.StartsWith("INVALID_USER"))
            //    {
            //        _errorCode = 7;
            //    }
            //    else
            //    {
            //        _errorMessage = ex.Message;
            //        _errorCode = 8;
            //    }
            //}
            _errorCode = 0;
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Task task = Task.Factory.StartNew(() =>
            //{
            //    Thread.Sleep(1000);
            //    return new MainView();
            //});
            //task.ContinueWith((x) =>
            //{
            //    Common.FlowView.Pop();
            //    //Common.Assign_All_CommonStaticProperties_to_UCBase_WinBase();
            //    Thread.Sleep(10000);
            //    switch (_errorCode)
            //    {
            //        case 0:
            //            Common.AddView(new MainView());
            //            break;
            //        case 1:
            //            Common.AddView(Common.FlowView.Peek());
            //            CustomMessageBox.Show("Version not tally,Please get the new version", "Access Denied !", winMessageBox.buttonPanel.YESNO, winMessageBox.icon.Warnning);
            //            break;
            //        case 2:
            //            Common.AddView(Common.FlowView.Peek());
            //            CustomMessageBox.Show("Inactive user. Access denied !", "Access Denied !", winMessageBox.buttonPanel.YESNO, winMessageBox.icon.Warnning);
            //            break;
            //        case 3:
            //            Common.AddView(Common.FlowView.Peek());
            //            CustomMessageBox.Show("Password has been expired. Please change the password.", "Password Expired !", winMessageBox.buttonPanel.OKOnly, winMessageBox.icon.Warnning);
            //            break;
            //        case 4:
            //            Common.AddView(Common.FlowView.Peek());
            //            CustomMessageBox.Show("Inactive mac address. Please contact administrator !", "Inactive MAC Address", winMessageBox.buttonPanel.OKOnly, winMessageBox.icon.Warnning);
            //            break;
            //        case 5:
            //            Common.AddView(Common.FlowView.Peek());
            //            CustomMessageBox.Show("No matching mac address found. Please contact administrator !", "Invalid MAC Address", winMessageBox.buttonPanel.OKOnly, winMessageBox.icon.Warnning);
            //            break;
            //        case 6:
            //            Common.AddView(Common.FlowView.Peek());
            //            CustomMessageBox.Show("Invalid user or Invalid Company. Access denied !", "Access Denied !", winMessageBox.buttonPanel.OKOnly, winMessageBox.icon.Warnning);
            //            break;
            //        case 7:
            //            Common.AddView(Common.FlowView.Peek());
            //            CustomMessageBox.Show("INVALID_USER !", "Access Denied !", winMessageBox.buttonPanel.OKOnly, winMessageBox.icon.Warnning);
            //            break;
            //        case 8:
            //            Common.AddView(Common.FlowView.Peek());
            //            CustomMessageBox.Show("Error login to system \n" + _errorMessage, "Error Login To System", winMessageBox.buttonPanel.OKOnly, winMessageBox.icon.Warnning);
            //            break;
            //    }
            //    Common.BtnLogout.Visibility = Visibility.Visible;
            //    //MessageView messageBox2 = new MessageView("dddd", "Ddd", 15, MessageType.ERROR);
            //    //ContentPanel.ViewOkMessage(messageBox2);
            //}, TaskScheduler.FromCurrentSynchronizationContext());

            //Common.Assign_All_CommonStaticProperties_to_UCBase_WinBase();
            Common.FlowView.Pop();
            switch (_errorCode)
            {
                case 0:
                    Common.AddView(new MainView());
                    break;
                //case 1:
                //    Common.AddView(Common.FlowView.Peek());
                //    CustomMessageBox.Show("Version not tally,Please get the new version", "Access Denied !", winMessageBox.buttonPanel.YESNO, winMessageBox.icon.Warnning);
                //    break;
                //case 2:
                //    Common.AddView(Common.FlowView.Peek());
                //    CustomMessageBox.Show("Inactive user. Access denied !", "Access Denied !", winMessageBox.buttonPanel.YESNO, winMessageBox.icon.Warnning);
                //    break;
                //case 3:
                //    Common.AddView(Common.FlowView.Peek());
                //    CustomMessageBox.Show("Password has been expired. Please change the password.", "Password Expired !", winMessageBox.buttonPanel.OKOnly, winMessageBox.icon.Warnning);
                //    break;
                //case 4:
                //    Common.AddView(Common.FlowView.Peek());
                //    CustomMessageBox.Show("Inactive mac address. Please contact administrator !", "Inactive MAC Address", winMessageBox.buttonPanel.OKOnly, winMessageBox.icon.Warnning);
                //    break;
                //case 5:
                //    Common.AddView(Common.FlowView.Peek());
                //    CustomMessageBox.Show("No matching mac address found. Please contact administrator !", "Invalid MAC Address", winMessageBox.buttonPanel.OKOnly, winMessageBox.icon.Warnning);
                //    break;
                //case 6:
                //    Common.AddView(Common.FlowView.Peek());
                //    CustomMessageBox.Show("Invalid user or Invalid Company. Access denied !", "Access Denied !", winMessageBox.buttonPanel.OKOnly, winMessageBox.icon.Warnning);
                //    break;
                //case 7:
                //    Common.AddView(Common.FlowView.Peek());
                //    CustomMessageBox.Show("INVALID_USER !", "Access Denied !", winMessageBox.buttonPanel.OKOnly, winMessageBox.icon.Warnning);
                //    break;
                //case 8:
                //    Common.AddView(Common.FlowView.Peek());
                //    CustomMessageBox.Show("Error login to system \n" + _errorMessage, "Error Login To System", winMessageBox.buttonPanel.OKOnly, winMessageBox.icon.Warnning);
                //    break;
            }
            Common.BtnLogout.Visibility = Visibility.Visible;
            //MessageView messageBox2 = new MessageView("dddd", "Ddd", 15, MessageType.ERROR);
            //ContentPanel.ViewOkMessage(messageBox2);
        }

        private bool ValidateForm()
        {
            //bool result = false;
            //try
            //{
            //    if ((TxtUserName.Text.Trim() != string.Empty) && (PwdBox.Password.Trim() != string.Empty) && (CbCompany.SelectedItem != null) && (CbCompany.SelectedItem.ToString().Trim() != string.Empty))
            //    {
            //        result = true;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //return result;
            return true;
        }

        #region To Delete In Logging Click

        ////GMA
        ////if (ValidateForm() == false)
        ////{
        ////    return;
        ////}
        //try
        //{
        //    //GMA
        //    //string zUsername = TxtUserName.Text.Trim();
        //    //string zPassword = PwdBox.Password.Trim();

        //    string zUsername = "Admin";
        //    string zPassword = "123";

        //    string zCompanyName = CbCompany.SelectedItem.ToString();
        //    DataRow[] zCompanyCodes = _dTable.Select(SystemFields._CompanyName_ + "='" + zCompanyName + "'");


        //    Common.SystemVersion = CommonMethods.GetSystemParameterValue("SYS_VERSION");

        //    if (Common.SystemVersion != ConfigurationManager.AppSettings["AppVersion"])
        //    {
        //        CustomMessageBox.Show("Version not tally,Please get the new version", "Access Denied !", winMessageBox.buttonPanel.YESNO, winMessageBox.icon.Warnning);
        //        return;
        //    }

        //    object activeModule;
        //    DataTable dtFinancialYear;
        //    UserEnt objUser;
        //    bool bRetVal = UserAuthentication(Convert.ToInt32(zCompanyCodes[0][0]), zUsername, zPassword, out objUser, out activeModule, out dtFinancialYear);

        //    Common.Assign_All_CommonStaticProperties_to_UCBase_WinBase();

        //    if (bRetVal)
        //    {
        //        if (!objUser.IsUserActive)
        //        {
        //            CustomMessageBox.Show("Inactive user. Access denied !", "Access Denied !", winMessageBox.buttonPanel.YESNO, winMessageBox.icon.Warnning);
        //            return;
        //        }
        //        else
        //        {
        //            Common._LoginId = objUser.LoginId;
        //            Common._LoginName = objUser.UserName;

        //            string selectedCompanyName = CbCompany.SelectedItem.ToString();
        //            DataRow[] selectedCompanyCodes = _dTable.Select(SystemFields._CompanyName_ + "='" + selectedCompanyName + "'");
        //            string sCode = selectedCompanyCodes[0][0].ToString();
        //            int iUserCurrentCompanyCode = Convert.ToInt32(sCode);

        //            Common._UserCurrentCompanyCode = iUserCurrentCompanyCode;    //Get Comp Code from CompGirdView
        //            Common._DefaultCurrencyCode = objUser.CurrencyCode;
        //            Common._UserCurrentPharmacyLocationCode = "";

        //            CompanyAllFinancialYear = dtFinancialYear;
        //            LoginUsername = TxtUserName.Text.Trim();
        //            CurrentPassword = PwdBox.Password.Trim();
        //            CurrentCompanyCode = iUserCurrentCompanyCode;
        //            FirstName = objUser.FirstName;
        //            AvailableCompanyAccounts = objUser.AvailableCompanyAccounts;


        //            DataSet dsCompany = CommonMethods.GetReportCampanyDetails(Common._UserCurrentCompanyCode);

        //            if (dsCompany.Tables[0].Rows.Count > 0)
        //            {
        //                Common.CompanyName = dsCompany.Tables[0].Rows[0]["CompanyName"].ToString();
        //                Common.CompanyAddress = dsCompany.Tables[0].Rows[0]["CompanyAddress"].ToString();
        //                Common.CompanyTel = dsCompany.Tables[0].Rows[0]["CompanyTelNo"].ToString();
        //            }

        //            DataSet dsLocation = CommonMethods.GetDefaultLocationDetails(Common._UserCurrentCompanyCode, Common._LoginId);

        //            if (dsLocation.Tables[0].Rows.Count > 0)
        //            {
        //                Common.DefaultLocation = dsLocation.Tables[0].Rows[0]["LocationCode"].ToString();
        //                Common.DefaultLocationName = dsLocation.Tables[0].Rows[0]["LocationDescription"].ToString();
        //            }

        //            if (objUser.IsFirstTime)
        //            {          //First Time
        //                LoginType = 1;
        //            }
        //            else
        //            {
        //                if (objUser.NoOfDays <= 0)
        //                {    //Password expired. User must change the password
        //                    LoginType = 2;
        //                    CustomMessageBox.Show("Password has been expired. Please change the password.", "Password Expired !", winMessageBox.buttonPanel.OKOnly, winMessageBox.icon.Warnning);
        //                }
        //                else if (objUser.NoOfDays <= new PasswordPolicy().DaysToInform)
        //                {
        //                    LoginType = 3;     //Just give the user a friendly reminder to change the password
        //                    if (CustomMessageBox.Show("Password will be expire in " + objUser.NoOfDays + " day(s). Do you wish to change the password now ?", "Password Expiratoin Reminder", winMessageBox.buttonPanel.YESNO, winMessageBox.icon.Question) == winMessageBox.userResult.YES)
        //                    {
        //                        LoginType = 4;
        //                    }
        //                    else
        //                    {
        //                        LoginType = 0;
        //                    }
        //                }
        //                else
        //                {   //Normal login routine
        //                    LoginType = 0;
        //                }
        //            }
        //        }

        //        #region MAC ADDRESS VALIDATION
        //        if (bCheckMAC)
        //        {
        //            DataSet dsMac = CommonMethods.GetMACAddressDetails(_MAC_ADDRESS);
        //            if (dsMac.Tables[0].Rows.Count > 0)
        //            {
        //                if (!Convert.ToBoolean(dsMac.Tables[0].Rows[0]["IsActive"]))
        //                {
        //                    CustomMessageBox.Show("Inactive mac address. Please contact administrator !", "Inactive MAC Address", winMessageBox.buttonPanel.OKOnly, winMessageBox.icon.Warnning);
        //                    return;
        //                }
        //            }
        //            else
        //            {
        //                CustomMessageBox.Show("No matching mac address found. Please contact administrator !", "Invalid MAC Address", winMessageBox.buttonPanel.OKOnly, winMessageBox.icon.Warnning);
        //                return;
        //            }
        //        }
        //        #endregion

        //        Common._IsAllowLog = true;
        //        Common.FlowView.Pop();
        //        Common.AddView(new MainView());
        //    }
        //    else
        //    {
        //        CustomMessageBox.Show("Invalid user or Invalid Company. Access denied !", "Access Denied !", winMessageBox.buttonPanel.OKOnly, winMessageBox.icon.Warnning);
        //    }
        //}
        //catch (Exception ex)
        //{
        //    if (ex.Message.StartsWith("INVALID_USER"))
        //    {
        //        CustomMessageBox.Show("INVALID_USER !", "Access Denied !", winMessageBox.buttonPanel.OKOnly, winMessageBox.icon.Warnning);
        //    }
        //    else
        //    {
        //        CustomMessageBox.Show("Error login to system \n" + ex.Message, "Error Login To System", winMessageBox.buttonPanel.OKOnly, winMessageBox.icon.Warnning);
        //    }
        //}
        //finally
        //{
        //    Common.Assign_All_CommonStaticProperties_to_UCBase_WinBase();
        //}

        #endregion
    }
}
