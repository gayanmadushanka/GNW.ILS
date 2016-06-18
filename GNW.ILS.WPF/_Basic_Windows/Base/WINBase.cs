using System;
using System.Collections.Generic;
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

using System.Data;
using System.Drawing;
using System.Reflection;

//using Infragistics.Win.UltraWinGrid;
//using Infragistics.Win.UltraWinTabControl;
using Pervation.Common.CommonOperations;
using Pervation.Common.Security;
///using Pervation.Common.Windows.ErrorHandler;

//using Pervation.Common.Windows.UserControls;
using Pervation.Presentation;

using Pervation.EntityLayer.Master;
using System.Data.SqlClient;
using Pervation.Presentation._Basic_Windows.UserControls;
using Pervation.Presentation._Basic_Windows.CommonMessage;
using Pervation.Presentation._Basic_Windows.ErrorHandler;


namespace Pervation.Presentation._Basic_Windows.Base
{
  public class WINBase :Window
    {

        public delegate void ChangeCompanyHandler();
        public delegate void ViewGLPostingHandler(bool val);
        public delegate void ViewAPPostingHandler(bool val);
        public delegate void ViewARPostingHandler(bool val);

        public delegate void viewGLGenJnlAuthorizationHandler(bool val);
        public delegate void viewAPAuthorizationHandler(bool val);
        public delegate void viewARAuthorizationHandler(bool val);



        public event ChangeCompanyHandler changeCompanyEvent;
        public static event ViewGLPostingHandler viewGLPosting;
        public static event ViewAPPostingHandler viewAPPosting;
        public static event ViewARPostingHandler viewARPosting;

        public static event viewGLGenJnlAuthorizationHandler viewGLGenJnlAuthorization;
        public static event viewAPAuthorizationHandler viewAPAuthorization;
        public static event viewARAuthorizationHandler viewARAuthorization;

        private SolidColorBrush _OrangeBrush;
        public SolidColorBrush OrangeBrush
        {
            get
            {
                _OrangeBrush = new SolidColorBrush();
                _OrangeBrush.Color = System.Windows.Media.Color.FromRgb(255, 201, 147);
                return _OrangeBrush;
            }
            set
            {
                _OrangeBrush = value;
            }
        }

        private SolidColorBrush _CyanBrush;
        public SolidColorBrush CyanBrush
        {
            get
            {
                _CyanBrush = new SolidColorBrush();
                _CyanBrush.Color = System.Windows.Media.Color.FromRgb(207, 241, 252);
                return _CyanBrush;
            }
            set
            {
                _CyanBrush = value;
            }
        }       
             

        #region Property
        public static string DefaultLocation { get; set; }
        public static string DefaultLocationName { get; set; }
        private string _docoumentNo;

        public string DocumentNo
        {
            get
            {
                return _docoumentNo;
            }
            set
            {
                _docoumentNo = value;
            }

        }
        private string _reportcode;

        public string ReportCode
        {
            get
            {
                return _reportcode;
            }
            set
            {
                _reportcode = value;
            }

        }

        public string FinYear { get; set; }

        private static string _CompanyName = "";

        public static string CompanyName
        {
            get { return _CompanyName; }
            set { _CompanyName = value; }
        }

        public static string CompanyAddress { get; set; }
        public static string CompanyTel { get; set; }

        #endregion
        private UCToolmnu _ToolbarMain;
       
        public UCToolmnu ToolbarMain { get { return _ToolbarMain; } set { _ToolbarMain = value; } }

        
      

        private string _Title;
        public string Title { get { return _Title; } set { _Title = value; } }

        //public ToolbarMain;


        public delegate void ToolBarButtonHandler();

        private string _ToolbarButtons = "";
        private System.Drawing.Color _GridColumnStockViewColor = System.Drawing.Color.FromArgb(255, 217, 236, 240);
        public System.Drawing.Color GridColumnStockViewColor
        {
            get
            {
                return _GridColumnStockViewColor;
            }
            set
            {
                _GridColumnStockViewColor = value;
            }
        }


        public static bool _IsManual { get; set; }

        private int _MyProperty;
        public int MyProperty
        {
            set { _MyProperty = value; }
            get { return 0; }
        }


        public static bool _IsBankWise { get; set; }
        public static bool _IsCategoryWise { get; set; }
        public static bool _IsCompanyWise { get; set; }
        public static bool _IsDepartmentWise { get; set; }
        public static bool _IsTempYearEnd { get; set; }
        public static bool _IsFinalYearEnd { get; set; }

        private System.Drawing.Color _GridColumnCellEditColor = System.Drawing.Color.FromArgb(204, 230, 100, 255);
        public System.Drawing.Color GridColumnCellEditColor
        {
            get
            {
                return _GridColumnCellEditColor;
            }
            set
            {
                _GridColumnCellEditColor = value;
            }
        }

        private System.Drawing.Color _GridRowColor = System.Drawing.Color.FromArgb(255, 217, 236, 255);

        public System.Drawing.Color GridRowColor
        {
            get
            {
                return _GridRowColor;
            }
            set
            {
                _GridRowColor = value;
            }
        }

        #region Virtual Methods

        public virtual void OnCreate()
        {
            ToolBarMode("EDIT");
            DisableItemsInToolBar(ModuleID);//Test
        }

        public virtual void OnLoad()
        {
            FormAction = "Create";
            ToolBarMode("VIEW");
            DisableItemsInToolBar(ModuleID);
            ClearTextFields();
            DocNoEnableDisable();
            _ModuleID = ModuleID;
            WriteLog(ModuleID, "Log to the Form ", "0", WriteLogCategories.Log.ToString(), this.Title);
        }

        public virtual void OnLoad(string mode)
        {
            FormAction = "Create";
            ToolBarMode(mode);
            DisableItemsInToolBar(ModuleID);
            ClearTextFields();
            DocNoEnableDisable();
            WriteLog(ModuleID, "Log to the Form ", "0", WriteLogCategories.Log.ToString(), this.Title);
        }

        private string GetPropertyValue(string pName, System.Windows.Controls.Control control)
        {
            Type type = control.GetType();

            string propertyName = pName;
            BindingFlags flags = BindingFlags.GetProperty;
            Binder binder = null;
            object[] args = null;

            object value = type.InvokeMember(
              propertyName,
               flags,
               binder,
               control,
               args
               );
            return value.ToString();
        }

        public static bool CheckViewAccess(int CompanyCode, int _LoginId, string ModuleID)
        {
            bool noAccess = false;
            if (!CanPerform(CompanyCode, _LoginId, ModuleID, Permission.View))
            {
                CustomMessageBox.Show("You do not have view access for this form.", "Close Window", winMessageBox.buttonPanel.OKOnly, winMessageBox.icon.Exclamation);
                noAccess = true;

            }

            return noAccess;

        }




        //public virtual bool OnValidation(Form form) {
        //    TextBox codeText=new TextBox();
        //    bool retValue = false;
        //    foreach (Control controls in form.Controls) {

        //        string controlId = controls.Name;
        //        if (controlId == "txtCode") {
        //            Type controlType = controls.GetType();
        //            PropertyInfo[] properties = controlType.GetProperties();

        //            foreach (PropertyInfo controlProperty in properties) {
        //                if (controlProperty.Name == "Text" &&
        //                controlProperty.PropertyType == typeof(String)) {
        //                    codeText = (TextBox)controls;
        //                    string propertyValue = GetPropertyValue(controlProperty.Name, controls);
        //                    NewRecodeID = propertyValue;
        //                    goto EndLoop;
        //                }
        //            }

        //        } else {
        //        }
        //    }
        //    EndLoop:
        //    if (RecodeID != NewRecodeID) {
        //        if (MessageBox.Show(this, "U cant update?", "Close Window", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
        //            codeText.Text = RecodeID;
        //            retValue = false;
        //        } else {
        //            retValue = true;
        //        }
        //    } else {
        //        retValue = true;
        //    }
        //    return retValue;
        //}

        public virtual bool OnValidation(System.Windows.Controls.TextBox txtCode)
        {
            bool retValue = false;
            if (RecodeID != txtCode.Text.Trim())
            {
                CustomMessageBox.Show("Please use the 'Save As' button to save the new record.", "Close Window", winMessageBox.buttonPanel.OKOnly, winMessageBox.icon.Exclamation);
               // System.Windows.MessageBox.Show(this, "Please use the 'Save As' button to save the new record.", "Close Window", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                txtCode.Text = RecodeID;
                retValue = false;
            }
            else
            {
                retValue = true;
            }

            return retValue;
        }

        public virtual void OnDelete()
        {
            CustomMessageBox.Show("Record successfully deleted", "Data Deleted", winMessageBox.buttonPanel.OKOnly, winMessageBox.icon.Information);
            //MessageBox.Show(this, "Record successfully deleted", "Data Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
            ToolBarMode("DELETE");
            ClearTextFields();
            DisableItemsInToolBar(ModuleID);//Test
        }

        public virtual void OnNew()
        {
            RecodeID = null;
            FormAction = "Create";
            ToolBarMode("VIEW");
            ClearTextFields();
            DisableItemsInToolBar(ModuleID);//Test
        }

        // This will Clear the Child Form text boxes ----- 
        //To child form developer can add only 2 group box... 

        public void ClearTextFields()
        {
            FieldInfo[] b = this.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var item in b)
            {
                switch (item.FieldType.FullName)
                {
                    case "System.Windows.Controls.TextBox":  //edited by dulip
                        {
                            ((TextBox)item.GetValue(this)).Text = "";
                        }
                        break;
                    case "Telerik.Windows.Controls.RadComboBox":
                        {
                            ((Telerik.Windows.Controls.RadComboBox)item.GetValue(this)).Text = "";
                        }
                        break;
                    case "Telerik.Windows.Controls.RadNumericUpDown":
                        {
                            ((Telerik.Windows.Controls.RadNumericUpDown)item.GetValue(this)).Value = 0;
                        }
                        break;
                    case "Telerik.Windows.Controls.RadDateTimePicker": //edited by dulip
                        {
                            int yearID;
                            if (DateTime.Compare(GetServerDateTime, ((System.Windows.Forms.DateTimePicker)item.GetValue(this)).MinDate) >= 0 && DateTime.Compare(GetServerDateTime, ((System.Windows.Forms.DateTimePicker)item.GetValue(this)).MaxDate) <= 0)
                            {
                                ((Telerik.Windows.Controls.RadDateTimePicker)item.GetValue(this)).DisplayDate = GetServerDateTime;
                                IsFinancialYearValid(GetServerDateTime, out yearID);
                                _CurrentFinancialYearId = yearID;
                            }
                        }
                        break;
                    case "Pervation.Presentation._Basic_Windows.UserControls.ucNumericTextBox":  //edited by dulip
                        {
                            var control = ((Pervation.Presentation._Basic_Windows.UserControls.ucNumericTextBox)item.GetValue(this));

                            if (control.AllowOnlyNumeric == true)
                                control.Text = "0.00";               //edited by dulip
                            else if (control.AllowOnlyInteger == true)
                                control.Text = "0";                  //edited by dulip
                            else
                                control.Text = "";                   //edited by dulip
                        }
                        break;
                    case "Pervation.Presentation._Basic_Windows.UserControls.ucCodeTextBox":      //edited by dulip
                        {
                            ((Pervation.Presentation._Basic_Windows.UserControls.ucCodeTextBox)item.GetValue(this)).Text = "";   //edited by dulip
                        }
                        break;
                    case "System.Windows.Controls.CheckBox":         //edited by dulip
                        {
                            ((System.Windows.Controls.CheckBox)item.GetValue(this)).Content = false;    //edited by dulip
                        }
                        break;
                }
            }
        }

        // This will Clear the Child Form Error Providers (Blink of Ep)----- 
        //To child form developer can add only 2 group box... 
        public virtual void ClearErrorFields(Pervation.Common.Windows.UserControls.ucErrorProvider ucEp)
        {
            ucEp.Ep.Clear();     //edited by dulip
            // now no need  as Error Template used // --dulip
        }
        public virtual void BindData(string recordId) { }
        public virtual void BindData(string recordId, string recordId1) { }
        public virtual void OnInsert()
        {
            CustomMessageBox.Show("Record successfully saved", "Data Saving", winMessageBox.buttonPanel.OKOnly, winMessageBox.icon.Information);  //edited by dulip
            //MessageBox.Show(this, "Record successfully saved", "Data Saving", MessageBoxButton.OK, MessageBoxImage.Information);    
            ToolBarMode("INSERT");
            DisableItemsInToolBar(ModuleID);//Test
        }

        public virtual void OnUpdate()
        {
            CustomMessageBox.Show("Record successfully updated", "Updating", winMessageBox.buttonPanel.OKOnly, winMessageBox.icon.Information);  //edited by dulip
           // MessageBox.Show(this, "Record successfully updated", "Updating", MessageBoxButton.OK, MessageBoxImage.Information);  //edited by dulip
            ToolBarMode("INSERT");
            DisableItemsInToolBar(ModuleID);//Test
        }

        public virtual void OnProcess()
        {
            CustomMessageBox.Show("Record successfully processed","Processing", winMessageBox.buttonPanel.OKOnly, winMessageBox.icon.Information);  //edited by dulip
           // MessageBox.Show(this, "Record successfully processed", "Processing", MessageBoxButton.OK, MessageBoxImage.Information);
            ToolBarMode("PROCESS");
            DisableItemsInToolBar(ModuleID);//Test
        }

        public virtual void OnCancellation() { }

        public virtual void OnFind()
        {
            if ((RecodeID != null) && (RecodeID != ""))
            {
                FormAction = "Modify";
                ToolBarMode("SEARCH");
                DisableItemsInToolBar(ModuleID);//Test
            }

        }

        public virtual void OnPrint()
        {
            //----dulip remove bellow comment after set Report viwers...
            //frmOnlineReportViewer onlineReportView = new frmOnlineReportViewer();
            //onlineReportView.LoadOnlieReport(this, DocumentNo, ReportCode, _UserCurrentCompanyCode, FinYear);
            PrintWriteLog();
            // onlineReportView.Show();   // keep this comment.... dulip
        }
       
        public virtual void OnNoAccess(string zAccessType)
        {
            CustomMessageBox.Show("You don’t have permission to access this form!  Please contact your administrator!", "Access Denied !", winMessageBox.buttonPanel.OKOnly, winMessageBox.icon.Warnning);
          //  System.Windows.MessageBox.Show(this, "You don’t have permission to access this form!  Please contact your administrator!", "Access Denied !", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        #endregion
        public WINBase()
        {
            //this.IsToolbar = true;

            //pgDesignBase PBase = new pgDesignBase();
            //   ToolbarMain = PBase.ucToolbar_Main22;

          //  this.IsToolbar = true;

            //ToolbarMain.btnNew.Tag = "1";
            //ToolbarMain.toolNew.Content = res_CommonWindows.img_gtk_add;


           // ToolbarMain.btnDelete.Tag = "3";
            //ToolbarMain.toolDelete.Content = res_CommonWindows.img_mnudelete;


         //   ToolbarMain.btnPrint.Tag = "4";
            //ToolbarMain.toolPrint.Content = res_CommonWindows.img_16_toolbar_print;


        //    ToolbarMain.btnSearch.Tag = "10";
            //ToolbarMain.toolFind.Content = res_CommonWindows.img_find;

         //   ToolbarMain.btnSave.Tag = "6";
            //ToolbarMain.toolSave.Content = res_CommonWindows.img_SaveAs;

         //   ToolbarMain.btnSaveAs.Tag = "12";
            //ToolbarMain.toolSaveAs.Content = res_CommonWindows.img_SaveAs;

         //   ToolbarMain.btnAppend.Tag = "8";
            //ToolbarMain.toolProcess.Content = res_CommonWindows.img_16_toolbar_process;

         //   ToolbarMain.btnClose.Tag = "7";
            //ToolbarMain.toolClose.Content = res_CommonWindows.img_toolClose;

        }
        public void InitializeToolBar()
        {
            this.IsToolbar = true;
            ToolbarMain.btnNew.Tag = "1";
            //ToolbarMain.toolNew.Content = res_CommonWindows.img_gtk_add;


            ToolbarMain.btnDelete.Tag = "3";
            //ToolbarMain.toolDelete.Content = res_CommonWindows.img_mnudelete;


            ToolbarMain.btnPrint.Tag = "4";
            //ToolbarMain.toolPrint.Content = res_CommonWindows.img_16_toolbar_print;


            ToolbarMain.btnSearch.Tag = "10";
            //ToolbarMain.toolFind.Content = res_CommonWindows.img_find;

            ToolbarMain.btnSave.Tag = "6";
            //ToolbarMain.toolSave.Content = res_CommonWindows.img_SaveAs;

            ToolbarMain.btnSaveAs.Tag = "12";
            //ToolbarMain.toolSaveAs.Content = res_CommonWindows.img_SaveAs;

            ToolbarMain.btnAppend.Tag = "8";
            //ToolbarMain.toolProcess.Content = res_CommonWindows.img_16_toolbar_process;

            ToolbarMain.btnClose.Tag = "7";
            //ToolbarMain.toolClose.Content = res_CommonWindows.img_toolClose;
        }

        public static DataTable SelectedData { get; set; }


        private static ucCommonSearch _winCommonSearch_In_WINbase;
        public static ucCommonSearch winCommonSearch_In_WINbase { get { return _winCommonSearch_In_WINbase; } set { _winCommonSearch_In_WINbase = value; } }

        private static DataTable _dtSelectedSearch;
        public static DataTable dtSelectedSearch { get { return _dtSelectedSearch; } set { _dtSelectedSearch = value; } }
        public string ModuleID { get; set; }
        public static bool IsCompanyChanged { get; set; }
        public static string _ModuleID { get; set; }
        public static Frame winSearchFrame { get; set; }
        public static int _LoginId { get; set; }
        public static string _LoginName { get; set; }

        public static int _UserCurrentCompanyCode;
     
        public static int UserCurrentCompanyCode
        {
            get { return UserCurrentCompanyCode; }
            set { _UserCurrentCompanyCode = value; }
        }
        public static string _UserCurrentPharmacyLocationCode { get; set; }
        public static string _DefaultCurrencyCode { get; set; }
        public static string _CashControlAcc { get; set; }
        public static string _ChequeControlAcc { get; set; }
        public static string _CreditCardControlAcc { get; set; }
        public static DataTable CompanyAllFinancialYear { get; set; }
        public static bool _IsAPCrAuthoriz { get; set; }
        public static bool _IsAPDrAuthoriz { get; set; }
        public static bool _IsARCrAuthoriz { get; set; }
        public static bool _IsARDrAuthoriz { get; set; }

        private static bool apOnlineAllow;
        public static bool _IsAPOnlineAllow
        {
            get
            {
                return apOnlineAllow;
            }
            set
            {
                apOnlineAllow = value;

                if (viewAPPosting != null)
                    viewAPPosting(value);
            }
        }

        private static bool arOnlineAllow;
        public static bool _IsAROnlineAllow
        {
            get
            {
                return arOnlineAllow;
            }
            set
            {
                arOnlineAllow = value;

                if (viewARPosting != null)
                    viewARPosting(value);
            }
        }

        private static bool glOnlineAllow;
        public static bool _IsGLOnlineAllow
        {
            get
            {
                return glOnlineAllow;
            }
            set
            {
                glOnlineAllow = value;

                if (viewGLPosting != null)
                    viewGLPosting(value);
            }
        }

        private static bool glGenJnlAuthoriz;
        public static bool _IsGLGenJnlAuthoriz
        {
            get
            {
                return glGenJnlAuthoriz;
            }
            set
            {
                glGenJnlAuthoriz = value;

                if (viewGLGenJnlAuthorization != null)
                    viewGLGenJnlAuthorization(value);
            }
        }

        private static bool apAuthoriz;
        public static bool _IsAPAuthoriz
        {
            get
            {
                return apAuthoriz;
            }
            set
            {
                apAuthoriz = value;

                if (viewAPAuthorization != null)
                    viewAPAuthorization(value);
            }
        }

        private static bool arAuthoriz;
        public static bool _IsARAuthoriz
        {
            get
            {
                return arAuthoriz;
            }
            set
            {
                arAuthoriz = value;

                if (viewARAuthorization != null)
                    viewARAuthorization(value);
            }
        }

        public static List<string> ActiveModules { get; set; }
        public DateTime? _MinFinancialYear
        {
            get
            {
                if (CompanyAllFinancialYear.Rows.Count > 0)
                    return Convert.ToDateTime(CompanyAllFinancialYear.AsEnumerable().Min(x => x.Field<DateTime>(SystemFields._From_))).Date;

                return null;
            }
        }
        public DateTime? _MaxFinancialYear
        {
            get
            {
                if (CompanyAllFinancialYear.Rows.Count > 0)
                    return Convert.ToDateTime(CompanyAllFinancialYear.AsEnumerable().Max(x => x.Field<DateTime>(SystemFields._To_))).Date.Add(new TimeSpan(23, 59, 59));

                return null;
            }
        }
        private int? FinancialYearId
        {
            get
            {
                if (CompanyAllFinancialYear != null)
                {
                    //var maxDate = CompanyAllFinancialYear.AsEnumerable().Max(x => x.Field<DateTime>(SystemFields._To_)).Date;
                    //if(DateTime.Compare(GetServerDateTime.Date,maxDate.Date)>0)
                    return CompanyAllFinancialYear.AsEnumerable().Max(x => x.Field<int>(SystemFields._SNo_));
                }

                return null;
            }
        }
        public int _CurrentFinancialYearId { get; set; }
        public static string MenuButtons { get; set; }
        public string FormAction { get; set; }
        public static string MACAddress { get; set; }
        public string SecondaryUserID { get; set; }
        public string RecodeID { get; set; }
        public static string NewRecodeID { get; set; }
        public bool IsToolbar { get; set; }
        private bool _ToolbarDeleteEnabled = false;
        public bool ToolbarDeleteEnabled
        {
            get
            {
                return _ToolbarDeleteEnabled;
            }
            set
            {
                _ToolbarDeleteEnabled = value;
                //ToolbarMain.btnDelete.IsEnabled = _ToolbarDeleteEnabled;   // ---dulip                            
            }
        }

        private bool _ToolbarDeleteShow = false;
        public bool ToolbarDeleteShow
        {
            get
            {
                return _ToolbarDeleteShow;
            }
            set
            {
                _ToolbarDeleteShow = value;
                if (_ToolbarDeleteShow) { //ToolbarMain.btnDelete.Visibility = System.Windows.Visibility.Visible; 
                }    // ---dulip                    
                else { //ToolbarMain.btnDelete.Visibility = System.Windows.Visibility.Hidden; 
                }
            }
        }

        private bool _ToolbarProcessEnabled = false;
        public bool ToolbarProcessEnabled
        {
            get
            {
                return _ToolbarProcessEnabled;
            }
            set
            {
                _ToolbarProcessEnabled = value;
               // ToolbarMain.btnAppend.IsEnabled = _ToolbarDeleteEnabled;   // ---dulip  
            }
        }

        private bool _ToolbarProcessShow = false;
        public bool ToolbarProcessShow
        {
            get
            {
                return _ToolbarProcessShow;
            }
            set
            {
                _ToolbarProcessShow = value;
                if (_ToolbarProcessShow) { //ToolbarMain.btnAppend.Visibility = System.Windows.Visibility.Visible; 
                }    // ---dulip                    
                else {// ToolbarMain.btnAppend.Visibility = System.Windows.Visibility.Hidden; 
                }
            }
        }

        private static DateTime _GetServerDateTime;
        public static DateTime GetServerDateTime
        {
            get
            {

                return _GetServerDateTime;     //CommonMethods.GetServerDateTime();
            }
            set
            {
                _GetServerDateTime = value;

            }
        }

        private static DateTime _GetServerDate;
        public static DateTime GetServerDate
        {
            get
            {

                return _GetServerDate;      //CommonMethods.GetServerDate();
            }
            set
            {
                _GetServerDate = value;

            }
        }       

        private static Label _messageLabel;

        public static Label MessageLabel
        {
            get
            {
                return _messageLabel;
            }
            set
            {
                _messageLabel = value;
            }
        }


        public void LockToolBar()
        {
            ToolbarMain.btnNew.IsEnabled = false;
            ToolbarMain.btnDelete.IsEnabled = false;
            ToolbarMain.btnPrint.IsEnabled = false;
            ToolbarMain.btnSearch.IsEnabled = false;
            ToolbarMain.btnSave.IsEnabled = false;
            ToolbarMain.btnSaveAs.IsEnabled = false;
            ToolbarMain.btnAppend.IsEnabled = false;

            ToolbarMain.btnClose.IsEnabled = true;
        }

        public virtual bool OnClose()
        {
            bool ok = false;
            try
            {
                if (IsCompanyChanged)
                {
                    WriteLog(ModuleID, "User Changed Current Company to " + _UserCurrentCompanyCode, "0", WriteLogCategories.Log.ToString(), this.Title);
                    ok = true;
                }
                {
                    WriteLog(ModuleID, "Log off from the Form ", "0", WriteLogCategories.Log.ToString(), this.Title);
                    ok = true;

                    // if (System.Windows.MessageBox.Show(this, "Do you want to close this form?", "Close Window", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    /* if(CustomMessageBox.Show("Do you want to close this form?","Close Window", winMessageBox.buttonPanel.YESNO, winMessageBox.icon.Question)==winMessageBox.userResult.YES)  //edited by dulip)
                       {
                         WriteLog(ModuleID, "Log off from the Form ", "0", WriteLogCategories.Log.ToString(), this.Title);
                         return true;
                       }
                       else
                       {
                           return false;
                       }
                     */
                }
            }
            catch (Exception ex)
            {

            }
            return ok;
        }
        public static bool UserAuthentication(int zCompanyCode, string zUsername, string zPassword, out UserEnt objUser, out object activeModule, out DataTable allFinancialYear)
        {
            bool retVal = false;

            try
            {
                string zEncryptedPassword = new Crypt().Encrypt(zPassword);
                Pervation.Common.Security.SecurePage security = new Pervation.Common.Security.SecurePage();
                retVal = security.Authentication(zCompanyCode, zUsername, zEncryptedPassword, out  objUser, out activeModule, out  allFinancialYear);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return retVal;
        }
        public void ToolBarMode(string zMode)
        {
            Button[] ToolbarButtons = { ToolbarMain.btnNew, ToolbarMain.btnDelete };

            if (zMode == "EDIT") // Enable all  Except  -Print/ Delete    tools
            {
                foreach (Button item in ToolbarButtons)
                {
                    if (item.Tag.ToString() != "4" && item.Tag.ToString() != "3")
                    {
                        item.IsEnabled = true;
                    }
                    else
                    {
                        item.IsEnabled = false;
                    }
                }
            }

            if (zMode == "INSERT")  // Enable  - New/ Print/ Search/ Close  tools
            {
                foreach (Button item in ToolbarButtons)
                {
                    if (item.Tag.ToString() == "1" || item.Tag.ToString() == "4" || item.Tag.ToString() == "10" || item.Tag.ToString() == "7")
                    {
                        item.IsEnabled = true;
                    }
                    else
                    {
                        item.IsEnabled = false;
                    }
                }
            }

            if (zMode == "SEARCH")  // Enable  - Print/ Delete/ SaveAs/ Save    tools
            {
                foreach (Button item in ToolbarButtons)
                {
                    if (item.Tag.ToString() == "4" || item.Tag.ToString() == "3" || item.Tag.ToString() == "12" || item.Tag.ToString() == "6")
                    {
                        item.IsEnabled = true;
                    }
                    else
                    {
                    }
                }
            }
            if (zMode == "DELETE") // Disable  -  Delete/ Print/ Process/ SaveAs/ Save    tools
            {
                foreach (Button item in ToolbarButtons)
                {
                    if (item.Tag.ToString() == "3" || item.Tag.ToString() == "4" || item.Tag.ToString() == "8" || item.Tag.ToString() == "12" || item.Tag.ToString() == "6")
                    {
                        item.IsEnabled = false;
                    }
                    else
                    {
                    }
                }
            }
            if (zMode == "VIEW")   // Disable  -  Delete/ Print/ Process/ SaveAs    tools
            {
                //Check User Right
                foreach (Button item in ToolbarButtons)
                {
                    string zTemp = "";
                    if (item.Tag.ToString() == "3" || item.Tag.ToString() == "4" || item.Tag.ToString() == "8" || item.Tag.ToString() == "12")
                    {
                        item.IsEnabled = false;
                    }
                    else
                    {
                        switch (int.Parse(item.Tag.ToString()))
                        {
                            case 1:
                                zTemp = "";
                                break;

                            case 2:
                                zTemp = "E";
                                break;

                            case 3:
                                zTemp = "D";
                                break;

                            case 4:
                                zTemp = "P";
                                break;

                            case 8:
                                zTemp = "R";
                                break;

                            default:
                                zTemp = "";
                                break;
                        }
                        if (_ToolbarButtons.IndexOf(zTemp) != -1)
                        {
                            item.IsEnabled = true;
                        }
                        else
                        {
                            item.IsEnabled = false;
                        }
                    }

                }
            }
            if (zMode == "PROCESS") // Disable  -  Delete/ Print/ SaveAs    tools
            {
                foreach (Button item in ToolbarButtons)
                {
                    string zTemp = "";
                    if (item.Tag.ToString() == "3" || item.Tag.ToString() == "4" || item.Tag.ToString() == "12")
                    {
                        item.IsEnabled = false;
                    }
                    else
                    {
                        switch (int.Parse(item.Tag.ToString()))
                        {
                            case 1:
                                zTemp = "";
                                break;

                            case 2:
                                zTemp = "E";
                                break;

                            case 3:
                                zTemp = "D";
                                break;

                            case 4:
                                zTemp = "P";
                                break;

                            case 8:
                                zTemp = "";
                                break;

                            default:
                                zTemp = "";
                                break;
                        }
                        if (_ToolbarButtons.IndexOf(zTemp) != -1)
                        {
                            item.IsEnabled = true;
                        }
                        else
                        {
                            item.IsEnabled = false;
                        }
                    }
                }
            }
            this.IsEnabled = true;

        }

        public void DisplayCancelLable(string RecodeID, string moduleId)
        {

            try
            {
                Pervation.Common.Security.ISecurity security = new Pervation.Common.Security.SecurePage();
                //DataSet dsTemp = security.DisableItemsInToolBar(moduleId);
                DataSet dsTemp = security.DisableItemsInToolBar(_UserCurrentCompanyCode, _LoginId, moduleId);



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DocNoEnableDisable()
        {
            DataSet dsTemp;

            dsTemp = new CommonMethods().GetDocNoEnableDisable(ModuleID, _UserCurrentCompanyCode);
            if (dsTemp.Tables[0].Rows.Count > 0)
            {
                //////IsManualPrefix, IsCompanyWisePrefix, IsDepartmentWisePrefix, IsBankWisePrefix, IsCategoryWisePrefix

                _IsManual = Convert.ToBoolean(dsTemp.Tables[0].Rows[0]["IsManualPrefix"]);
                _IsCompanyWise = Convert.ToBoolean(dsTemp.Tables[0].Rows[0]["IsCompanyWisePrefix"]);
                _IsDepartmentWise = Convert.ToBoolean(dsTemp.Tables[0].Rows[0]["IsDepartmentWisePrefix"]);
                _IsBankWise = Convert.ToBoolean(dsTemp.Tables[0].Rows[0]["IsBankWisePrefix"]);
                _IsCategoryWise = Convert.ToBoolean(dsTemp.Tables[0].Rows[0]["IsCategoryWisePrefix"]);

                bool iEnable = Convert.ToBoolean(dsTemp.Tables[0].Rows[0]["IsManualPrefix"]);

                //This is used to change "txtDocNo" property to Enable true or false (Used in transaction forms such as AP, AR and GL) 
                var filedInfo = this.GetType().GetField("txtDocNo", BindingFlags.NonPublic | BindingFlags.Instance);

                if (filedInfo != null)
                {
                    ((TextBox)filedInfo.GetValue(this)).IsReadOnly = !iEnable;
                    ((TextBox)filedInfo.GetValue(this)).MaxLength = 15;
                }

                //This is used to change "txtCode" property to Enable true or false (Used in transaction forms of Master files)
                var filedInfoMast = this.GetType().GetField("txtCode", BindingFlags.NonPublic | BindingFlags.Instance);

                if (filedInfoMast != null)
                {
                    ((TextBox)filedInfoMast.GetValue(this)).IsReadOnly = !iEnable;
                    ((TextBox)filedInfoMast.GetValue(this)).MaxLength = 10;
                }

            }
        }
        public void DisableItemsInToolBar(string moduleId)
        {

            try
            {
                Pervation.Common.Security.ISecurity security = new Pervation.Common.Security.SecurePage();
                //DataSet dsTemp = security.DisableItemsInToolBar(moduleId);
                DataSet dsTemp = security.DisableItemsInToolBar(_UserCurrentCompanyCode, _LoginId, moduleId);

                foreach (DataRow row in dsTemp.Tables[0].Rows)
                {
                    if (row["ApplicableRoles"].ToString().Trim() != "")
                    {
                        string premission = row["ApplicableRoles"].ToString().Trim();

                        //foreach (ToolStripItem item in ToolbarMain.Items)
                        //{
                        //    if (item.Tag.ToString() != "7")
                        //    {
                        //        item.Enabled = false;
                        //    }
                        //}


                        Button[] ToolBarButtons = { ToolbarMain.btnNew, ToolbarMain.btnDelete, ToolbarMain.btnPrint, ToolbarMain.btnSearch, ToolbarMain.btnSave, ToolbarMain.btnSaveAs, ToolbarMain.btnAppend, ToolbarMain.btnClose };

                        if (!premission.Contains("C") && !premission.Contains("E"))
                        {

                            foreach (Button toolItem in ToolBarButtons)
                            {

                                if ((toolItem.Tag.ToString() == "1"))
                                {
                                    if (toolItem.IsEnabled)
                                    {
                                        toolItem.IsEnabled = false;
                                    }
                                }
                                if ((toolItem.Tag.ToString() == "6"))
                                {
                                    if (toolItem.IsEnabled)
                                    {
                                        toolItem.IsEnabled = false;
                                    }
                                }

                                if ((toolItem.Tag.ToString() == "12"))
                                {
                                    if (toolItem.IsEnabled)
                                    {
                                        toolItem.IsEnabled = false;
                                    }
                                }

                                if ((toolItem.Tag.ToString() == "10"))
                                {
                                    if (toolItem.IsEnabled)
                                    {
                                        toolItem.IsEnabled = false;
                                    }
                                }
                            }

                        }

                        //if (! premission.Contains("E")) {

                        //    foreach (ToolStripItem toolItem in ToolbarMain.Items) {

                        //        if ((toolItem.Tag.ToString() == "1")) {
                        //            if (toolItem.Enabled) {
                        //                toolItem.Enabled = false;
                        //            }
                        //        }
                        //        if ((toolItem.Tag.ToString() == "6")) {
                        //            if (toolItem.Enabled) {
                        //                toolItem.Enabled = false;
                        //            }
                        //        }

                        //        if ((toolItem.Tag.ToString() == "12")) {
                        //            if (toolItem.Enabled) {
                        //                toolItem.Enabled = false;
                        //            }
                        //        }

                        //        if ((toolItem.Tag.ToString() == "10")) {
                        //            if (toolItem.Enabled) {
                        //                toolItem.Enabled = false;
                        //            }
                        //        }
                        //    }

                        //}

                        if (!premission.Contains("D"))
                        {
                            if (ModuleID == ModuleCodes.AssignAccountToDepartment || ModuleCodes.AssignAccountToCompany == ModuleID)
                            {
                                var filedInfo = this.GetType().GetField("removeToolStripMenuItem", BindingFlags.NonPublic | BindingFlags.Instance);
                                if (filedInfo != null)
                                {
                                    var delMenu = (System.Windows.Forms.ToolStripMenuItem)filedInfo.GetValue(this);
                                    delMenu.Visible = false;
                                }
                            }

                            foreach (Button toolItem in ToolBarButtons)
                            {
                                if (toolItem.Tag.ToString() == "3")
                                {
                                    if (toolItem.IsEnabled)
                                    {
                                        toolItem.IsEnabled = false;
                                    }
                                }
                            }
                        }
                        else
                        {

                            if (ModuleID == ModuleCodes.AssignAccountToDepartment || ModuleCodes.AssignAccountToCompany == ModuleID)
                            {
                                var filedInfo = this.GetType().GetField("removeToolStripMenuItem", BindingFlags.NonPublic | BindingFlags.Instance);
                                if (filedInfo != null)
                                {
                                    var delMenu = (System.Windows.Forms.ToolStripMenuItem)filedInfo.GetValue(this);
                                    delMenu.Visible = true;
                                }
                            }
                        }

                        if (!premission.Contains("P"))
                        {
                            foreach (Button toolItem in ToolBarButtons)
                            {
                                if (toolItem.Tag.ToString() == "4")
                                {
                                    if (toolItem.IsEnabled)
                                    {
                                        toolItem.IsEnabled = false;
                                    }
                                }
                            }
                        }

                        //if (!premission.Contains("F"))
                        //{
                        //    foreach (ToolStripItem toolItem in ToolbarMain.Items)
                        //    {
                        //        if (toolItem.Tag.ToString() == "10")
                        //        {
                        //            if (toolItem.Enabled) {
                        //                toolItem.Enabled = false;
                        //            }
                        //        }
                        //    }
                        //}
                        if (premission.Contains("SC"))
                        {
                            foreach (Button toolItem in ToolBarButtons)
                            {
                                if ((toolItem.Tag.ToString() == "1") || (toolItem.Tag.ToString() == "12") || (toolItem.Tag.ToString() == "10") || (toolItem.Tag.ToString() == "3") || (toolItem.Tag.ToString() == "4"))
                                {
                                    toolItem.IsEnabled = false;
                                }
                            }

                        }



                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DisableMenuItem(string itemIndex)
        {
            //--- TOOL BAR VALUES AND NAME -----
            //1 -  NEW
            //3- DELETE
            //4- PRINT
            //6- SAVE
            //7- CLOSE
            //8 - PROCESS
            //10-SEARCH          
            //12-SAVE AS
            //-----------------------------------


            Button[] ToolBarButtons = { ToolbarMain.btnNew, ToolbarMain.btnDelete, ToolbarMain.btnPrint, ToolbarMain.btnSearch, ToolbarMain.btnSave, ToolbarMain.btnSaveAs, ToolbarMain.btnAppend, ToolbarMain.btnClose };

            itemIndex = itemIndex + ",";
            foreach (Button toolItem in ToolBarButtons)
            {
                if (itemIndex.Contains("1,"))
                {
                    if ((toolItem.Tag.ToString() == "1"))
                    {
                        toolItem.IsEnabled = false;
                    }
                }
                if (itemIndex.Contains("6,"))
                {
                    if ((toolItem.Tag.ToString() == "6"))
                    {
                        toolItem.IsEnabled = false;
                    }
                }
                if (itemIndex.Contains("7,"))
                {
                    if ((toolItem.Tag.ToString() == "7"))
                    {
                        toolItem.IsEnabled = false;
                    }
                }
                if (itemIndex.Contains("12,"))
                {
                    if ((toolItem.Tag.ToString() == "12"))
                    {
                        toolItem.IsEnabled = false;
                    }
                }
                if (itemIndex.Contains("3,"))
                {
                    if ((toolItem.Tag.ToString() == "3"))
                    {
                        toolItem.IsEnabled = false;
                    }
                }
                if (itemIndex.Contains("4,"))
                {
                    if ((toolItem.Tag.ToString() == "4"))
                    {
                        toolItem.IsEnabled = false;
                    }
                }
                if (itemIndex.Contains("10,"))
                {
                    if ((toolItem.Tag.ToString() == "10"))
                    {
                        toolItem.IsEnabled = false;
                    }
                }
            }

        }

        public void EnableMenuItem(string itemIndex)
        {
            //--- TOOL BAR VALUES AND NAME -----
            //1 -  NEW
            //3- DELETE
            //4- PRINT
            //6- SAVE
            //7- CLOSE
            //8 - PROCESS
            //10-SEARCH          
            //12-SAVE AS
            //-----------------------------------

            Button[] ToolBarButtons = { ToolbarMain.btnNew, ToolbarMain.btnDelete, ToolbarMain.btnPrint, ToolbarMain.btnSearch, ToolbarMain.btnSave, ToolbarMain.btnSaveAs, ToolbarMain.btnAppend, ToolbarMain.btnClose };

            itemIndex = itemIndex + ",";
            foreach (Button toolItem in ToolBarButtons)
            {
                if (itemIndex.Contains("1,"))
                {
                    if ((toolItem.Tag.ToString() == "1"))
                    {
                        toolItem.IsEnabled = true;
                    }
                }
                if (itemIndex.Contains("6,"))
                {
                    if ((toolItem.Tag.ToString() == "6"))
                    {
                        toolItem.IsEnabled = true;
                    }
                }
                if (itemIndex.Contains("7,"))
                {
                    if ((toolItem.Tag.ToString() == "7"))
                    {
                        toolItem.IsEnabled = true;
                    }
                }
                if (itemIndex.Contains("12,"))
                {
                    if ((toolItem.Tag.ToString() == "12"))
                    {
                        toolItem.IsEnabled = true;
                    }
                }
                if (itemIndex.Contains("3,"))
                {
                    if ((toolItem.Tag.ToString() == "3"))
                    {
                        toolItem.IsEnabled = true;
                    }
                }
                if (itemIndex.Contains("4,"))
                {
                    if ((toolItem.Tag.ToString() == "4"))
                    {
                        toolItem.IsEnabled = true;
                    }
                }
                if (itemIndex.Contains("10,"))
                {
                    if ((toolItem.Tag.ToString() == "10"))
                    {
                        toolItem.IsEnabled = true;
                    }
                }
            }

        }
        public static bool CanPerform(int CompanyCode,int _LoginId, string moduleId, Permission permition)
        {
            bool retVal = false;
            try
            {
                Pervation.Common.Security.ISecurity security = new Pervation.Common.Security.SecurePage();
                retVal = security.CanPerform(CompanyCode,_LoginId, moduleId, permition);
            }
            catch (Exception ex)
            {
                retVal = false;
                throw ex;
            }
            return retVal;
        }
        public static void SetUserException(Exception exeption)
        {
            string retValue = string.Empty;
            //OperationalManagement.IoperationalManagement opMangement = new OperationalManagement.OperationManagementPage();
            Pervation.Common.OperationalManagement.IoperationalManagement opMangement = new Pervation.Common.OperationalManagement.OperationManagementPage();
            //frmErrorHandler erroHandeler = new frmErrorHandler();
            try
            {
                string errorNo = string.Empty;
                if (exeption is SqlException)
                {
                    var ex = (SqlException)exeption;
                    if (ex.Number.ToString() == "50000")
                    {
                        var e = (SqlException)exeption;
                        if (e.Number > 0)
                        {
                            errorNo = e.Message.ToString().Substring(0, 5);
                        }
                        else
                        {
                            errorNo = "0001";
                        }
                    }
                    else
                    {
                        var e = (SqlException)exeption;
                        if (e.Number > 0)
                        {
                            errorNo = e.Number.ToString();
                        }
                        else
                        {
                            errorNo = "0001";
                        }
                    }
                }
                else if (exeption is FormatException)
                {
                    var ex = (FormatException)exeption;
                    if (ex.Message.Length > 0)
                    {
                        errorNo = "60001";
                    }
                    else
                    {
                        errorNo = "0001";
                    }

                }
                else
                {
                    errorNo = "0000";
                }
                retValue = opMangement.GetUserExceprion(errorNo);

                string RetAutoId = "";
                if (errorNo == "0000")
                {
                    opMangement.ErrorLogging(_ModuleID, exeption.Message, "GENERAL", _LoginId, out RetAutoId);
                    //erroHandeler.More = "Error Id - " + RetAutoId + "\r\n" + exeption.Message;
                }
                else
                {
                    opMangement.ErrorLogging(_ModuleID, _LoginId, "DATABASE", out RetAutoId);
                    //erroHandeler.More = "Error Id - " + RetAutoId;
                }
                CustomMessageBox.Show(retValue, "Error!", winMessageBox.buttonPanel.OKOnly, winMessageBox.icon.Exclamation);
                //erroHandeler.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void SetUserException1(string id, Exception exceprion)
        {
            string retValue = string.Empty;
            try
            {
                Pervation.Common.OperationalManagement.IoperationalManagement opMangement = new Pervation.Common.OperationalManagement.OperationManagementPage();
                retValue = opMangement.GetUserExceprion(id);
                frmErrorHandler erroHandeler = new frmErrorHandler();
                erroHandeler.UserMessage = retValue;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //public static void SetUserException(string id, Exception exceprion)
        //{
        //    string retValue = string.Empty;
        //    try
        //    {
        //        OperationalManagement.IoperationalManagement opMangement = new OperationalManagement.OperationManagementPage();
        //        retValue = opMangement.GetUserExceprion(id);
        //        frmErrorHandler erroHandeler = new frmErrorHandler();
        //        erroHandeler.UserMessage = retValue;
        //        if (exceprion.Message == "10000" ||
        //        exceprion.Message == "10001" ||
        //        exceprion.Message == "10002" ||
        //        exceprion.Message == "10003" ||
        //        exceprion.Message == "10004" ||
        //        exceprion.Message == "10005" ||
        //        exceprion.Message == "10006" ||
        //        exceprion.Message == "10007" ||
        //        exceprion.Message == "10008" ||
        //        exceprion.Message == "2627" ||
        //        exceprion.Message == "547" ||
        //        exceprion.Message == "10009" ||
        //        exceprion.Message == "50001" ||
        //        exceprion.Message == "50002" ||
        //        exceprion.Message == "50003" ||
        //        exceprion.Message == "50010" ||
        //        exceprion.Message == "50015" ||
        //        exceprion.Message == "50200" ||
        //        exceprion.Message == "50555" ||
        //        exceprion.Message == "50026" ||
        //        exceprion.Message == "55555" ||
        //        exceprion.Message == "-2146232060" ||
        //        exceprion.Message == "50025" ||
        //        exceprion.Message == "50031" ||
        //        exceprion.Message == "50032" ||
        //        exceprion.Message == "50033" ||
        //        exceprion.Message == "50034" ||
        //        exceprion.Message == "50035" ||
        //        exceprion.Message == "50036" ||
        //        exceprion.Message == "50037" ||
        //        exceprion.Message == "50038" ||
        //        exceprion.Message == "50039" ||
        //        exceprion.Message == "50040" ||
        //        exceprion.Message == "50041" ||
        //        exceprion.Message == "50042" ||
        //        exceprion.Message == "50043" ||
        //        exceprion.Message == "50044" ||
        //        exceprion.Message == "50045" ||
        //        exceprion.Message == "50046" ||
        //        exceprion.Message == "50047" ||
        //        exceprion.Message == "50048" ||
        //        exceprion.Message == "50049" ||
        //        exceprion.Message == "50050" ||
        //        exceprion.Message == "50051" ||
        //        exceprion.Message == "50052" ||
        //        exceprion.Message == "50053" ||
        //        exceprion.Message == "50054" ||
        //        exceprion.Message == "50055" ||
        //        exceprion.Message == "50059" ||
        //        exceprion.Message == "50060" ||
        //        exceprion.Message == "50061" ||
        //        exceprion.Message == "50062"

        //            )
        //        {
        //            erroHandeler.Error = null;
        //            erroHandeler.More = opMangement.GetUserExceprion(exceprion.Message.ToString());
        //            erroHandeler.ShowDialog();
        //        }
        //        else
        //        {
        //            erroHandeler.Error = exceprion;
        //            erroHandeler.ShowDialog();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public static string GetUserMessage(string id)
        {
            string retValue = string.Empty;
            try
            {
                //OperationalManagement.IoperationalManagement opMangement = new OperationalManagement.OperationManagementPage();
                Pervation.Common.OperationalManagement.IoperationalManagement opMangement = new Pervation.Common.OperationalManagement.OperationManagementPage();
                retValue = opMangement.GetUserMessage(id);

            }
            catch (Exception ex)
            {
                retValue = string.Empty;
                throw ex;
            }
            return retValue;
        }
        public static string SetUserMessage(string id, string more)
        {
            string retValue = string.Empty;
            try
            {
                //OperationalManagement.IoperationalManagement opMangement = new OperationalManagement.OperationManagementPage();
                Pervation.Common.OperationalManagement.IoperationalManagement opMangement = new Pervation.Common.OperationalManagement.OperationManagementPage();
                retValue = opMangement.GetUserMessage(id);
                frmErrorHandler erroHandeler = new frmErrorHandler();
                erroHandeler.UserMessage = retValue;
                erroHandeler.More = more;
                erroHandeler.Show();
            }
            catch (Exception ex)
            {
                retValue = string.Empty;
                throw ex;
            }
            return retValue;
        }
        public static void WriteLog(string entityCode, string message, string prority, string category, string title)
        {
            try
            {
                //OperationalManagement.IoperationalManagement opMangement = new OperationalManagement.OperationManagementPage();
                Pervation.Common.OperationalManagement.IoperationalManagement opMangement = new Pervation.Common.OperationalManagement.OperationManagementPage();
                opMangement.Logging(entityCode, message, prority, category, title, _LoginId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void InsertWriteLog()
        {
            try
            {

                //OperationalManagement.IoperationalManagement opMangement = new OperationalManagement.OperationManagementPage();
                Pervation.Common.OperationalManagement.IoperationalManagement opMangement = new Pervation.Common.OperationalManagement.OperationManagementPage();
                opMangement.InsertLogging(RecodeID, ModuleID, _LoginId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void InsertWriteLog(string entityCode, string message, string title)
        {
            try
            {
                //OperationalManagement.IoperationalManagement opMangement = new OperationalManagement.OperationManagementPage();
                Pervation.Common.OperationalManagement.IoperationalManagement opMangement = new Pervation.Common.OperationalManagement.OperationManagementPage();
                opMangement.InsertLogging(entityCode, message, title, _LoginId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void PrintWriteLog()
        {
            try
            {

               // OperationalManagement.IoperationalManagement opMangement = new OperationalManagement.OperationManagementPage();
                Pervation.Common.OperationalManagement.IoperationalManagement opMangement = new Pervation.Common.OperationalManagement.OperationManagementPage();
                opMangement.PrintLogging(RecodeID, ModuleID, _LoginId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void PrintWriteLog(string entityCode, string message, string title)
        {
            try
            {
                //OperationalManagement.IoperationalManagement opMangement = new OperationalManagement.OperationManagementPage();
                Pervation.Common.OperationalManagement.IoperationalManagement opMangement = new Pervation.Common.OperationalManagement.OperationManagementPage();
                opMangement.PrintLogging(entityCode, message, title, _LoginId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateWriteLog()
        {
            try
            {
                Pervation.Common.OperationalManagement.IoperationalManagement opMangement = new Pervation.Common.OperationalManagement.OperationManagementPage();
                opMangement.UpdateLogging(RecodeID, ModuleID, _LoginId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateWriteLog(string entityCode, string message, string title)
        {
            try
            {
                Pervation.Common.OperationalManagement.IoperationalManagement opMangement = new Pervation.Common.OperationalManagement.OperationManagementPage();
                opMangement.UpdateLogging(entityCode, message, title,_LoginId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteWriteLog()
        {
            try
            {
                Pervation.Common.OperationalManagement.IoperationalManagement opMangement = new Pervation.Common.OperationalManagement.OperationManagementPage();
                opMangement.DeleteLogging(RecodeID, ModuleID, _LoginId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteWriteLog(string entityCode, string message, string title)
        {
            try
            {
                //OperationalManagement.IoperationalManagement
                Pervation.Common.OperationalManagement.IoperationalManagement opMangement = new Pervation.Common.OperationalManagement.OperationManagementPage();
                opMangement.DeleteLogging(entityCode, message, title,_LoginId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public static void ErrorWriteLog()
        //{
        //    try
        //    {
        //        OperationalManagement.IoperationalManagement opMangement = new OperationalManagement.OperationManagementPage();
        //        opMangement.ErrorLogging(_ModuleID, _LoginName);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public void ErrorWriteLog(string entityCode, string message, string title)
        //{
        //    try
        //    {
        //        OperationalManagement.IoperationalManagement opMangement = new OperationalManagement.OperationManagementPage();
        //        opMangement.ErrorLogging(entityCode, message, title, _LoginName);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public void ErrorWriteLog()
        //{
        //    try
        //    {
        //        OperationalManagement.IoperationalManagement opMangement = new OperationalManagement.OperationManagementPage();
        //        opMangement.ErrorLogging(ModuleID, _LoginName);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public string GetModuleRole(string zModuleCode)
        {
            string zTemp = "";
            try
            {
                Pervation.Common.Security.SecurePage security = new Pervation.Common.Security.SecurePage();
                zTemp = security.GetModuleRole(zModuleCode);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return zTemp;
        }


        //void documentDatePick_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        //{
        //    var dateInfo = this.GetType().GetField("dtDocumentDate", BindingFlags.NonPublic | BindingFlags.Instance);

        //    if (dateInfo != null)
        //    {
        //        int yearID;
        //        if (!IsFinancialYearValid(((DatePicker)dateInfo.GetValue(this)), out yearID))
        //        {
        //            MessageBox.Show("Selected Date is not in Current Financial Year.", "", MessageBoxButton.OK, MessageBoxImage.Information);
        //            _CurrentFinancialYearId = yearID;
        //            return;
        //        }

        //        _CurrentFinancialYearId = yearID;
        //    }
        //}                
        private bool IsFinancialYearValid(DateTime date, out int yearId)
        {
            yearId = -1;

            if (CompanyAllFinancialYear != null)
            {
                DataRow[] row = CompanyAllFinancialYear.Select(SystemFields._SNo_ + "='" + FinancialYearId.ToString() + "'");
                if (row != null)
                {
                    var from = Convert.ToDateTime(row[0][SystemFields._From_]);
                    var to = Convert.ToDateTime(row[0][SystemFields._To_]);

                    if (DateTime.Compare(date.Date, from.Date) >= 0 && DateTime.Compare(date.Date, to.Date) <= 0)
                    {
                        yearId = (FinancialYearId != null ? Convert.ToInt32(FinancialYearId) : -1);
                        return true;
                    }
                    else
                    {
                        for (int i = Convert.ToInt32(FinancialYearId) - 1; i > -1; i--)
                        {
                            DataRow[] otherRow = CompanyAllFinancialYear.Select(SystemFields._SNo_ + "='" + i.ToString() + "'");
                            if (otherRow != null)
                            {
                                from = Convert.ToDateTime(otherRow[0][SystemFields._From_]);
                                to = Convert.ToDateTime(otherRow[0][SystemFields._To_]);

                                if (DateTime.Compare(date.Date, from.Date) >= 0 && DateTime.Compare(date.Date, to.Date) <= 0)
                                {
                                    yearId = i;
                                    break;
                                }
                            }
                        }
                        return false;
                    }

                }
                return false;
            }

            return false;
        }
        public void YearEndValidate(DateTime dt, string systemID, string moduleCode)
        {
            if (CompanyAllFinancialYear != null)
            {
                DataRow[] result = CompanyAllFinancialYear.Select(string.Format("From <= '" + dt.ToShortDateString() + "' AND To >= '" + dt.ToShortDateString() + "'"));

                if ((result != null) && (result.Length > 0))
                {
                    foreach (DataRow row in result)
                    {
                        _IsTempYearEnd = Convert.ToBoolean(row["IsVirtualYearEnd"]);
                        _IsFinalYearEnd = Convert.ToBoolean(row["IsFinalized"]);

                        if (systemID == "GL")
                        {
                            if ((_IsTempYearEnd == false) && (_IsFinalYearEnd == false))
                            {
                                //OnLoad();
                                EnableMenuItem("6");
                            }
                            else if ((_IsTempYearEnd == true) && (_IsFinalYearEnd == false))
                            {
                                if (moduleCode == "JNL")
                                {
                                    //OnLoad();
                                    EnableMenuItem("6");
                                }
                                else if (moduleCode == "RCON")
                                {
                                    //OnLoad();
                                    EnableMenuItem("6");
                                }
                                else
                                {
                                    DisableMenuItem("6");
                                }
                            }
                            else if ((_IsTempYearEnd == false) && (_IsFinalYearEnd == true))
                            {
                                DisableMenuItem("6");
                            }
                            else
                            {
                                DisableMenuItem("6");
                            }
                        }
                        else
                        {
                            if ((_IsTempYearEnd == false) && (_IsFinalYearEnd == false))
                            {
                                //OnLoad();
                                EnableMenuItem("6");
                            }
                            else
                            {
                                DisableMenuItem("6");
                            }
                        }
                    }
                }
            }
        }
        #region Grid Items Duplicate Validation
        //*********************************************************************************
        // --------This part will validate duplicate items in the Grid 
        //---------and provide the duplicate item code

        public string checkDouble(Telerik.Windows.Controls.RadGridView GridName, string PrimaryColumn)
        {
            string functionReturnValue = null;
            int bm = 0;
            string itemcode = null;
            //GridName.Update();
           // GridName.UpdateData();

            foreach (DataRow row in GridName.Items)
            {
                if (!string.IsNullOrEmpty(row[PrimaryColumn].ToString()))
                {
                    itemcode = row[PrimaryColumn].ToString();
                    if (valitem(GridName, PrimaryColumn, Convert.ToString(row[PrimaryColumn].ToString().Trim())) == true)
                    {
                        functionReturnValue = itemcode;
                        return functionReturnValue;
                    }
                    bm = bm + 1;
                }
            }
            return functionReturnValue;

        }

        /*Modified Date/Time : 21/06/2012 3:59 PM                       *
        /****************************************************************
        /*Developer Name : Chathura Lakshan                             *
        /*Description : To Chek Duplicate grid entries with two PKs     */

        #region Grid Items Duplicate Validation WHEN TWO PKs
        // Modified by Chathura Lakshan
        //*********************************************************************************
        // --------This part will validate duplicate items in the Grid 
        //---------and provide the duplicate item code

        /// <summary>
        /// Check the row duplicate whith two PKs
        /// </summary>
        /// <param name="GridName"></param>
        /// <param name="PrimaryColumn1">Primary Key 1</param>
        /// <param name="PrimaryColumn2">Primary Key 2</param>
        /// <returns>Duplicated Keys</returns>
        public string[] checkDoubleWith2PK(Telerik.Windows.Controls.RadGridView GridName, string PrimaryColumn1, string PrimaryColumn2)
        {
            string[] functionReturnValue = new string[2];
            int bm = 0;
            string itemcode = null;
            string batchNo = null;
           // GridName.Update();
           // GridName.UpdateData();

            foreach (DataRow row in GridName.Items)
            {
                if (!string.IsNullOrEmpty(row[PrimaryColumn1].ToString()))
                {
                    itemcode = row[PrimaryColumn1].ToString();
                    batchNo = row[PrimaryColumn2].ToString();
                    if (valitem2(GridName, PrimaryColumn1, PrimaryColumn2, itemcode, batchNo) == true)
                    {
                        functionReturnValue[0] = itemcode;
                        functionReturnValue[1] = batchNo;
                        return functionReturnValue;
                    }
                    bm = bm + 1;
                }
            }
            return functionReturnValue;

        }

        private bool valitem2(Telerik.Windows.Controls.RadGridView GridName, string PrimaryColumn1, string PrimaryColumn2, string Item, string Batch)
        {
            bool functionReturnValue = false;
            int i = 0;
            int itmval = 0;
            foreach (DataRow row in GridName.Items)
            {
                if (!string.IsNullOrEmpty(row[PrimaryColumn1].ToString()))
                {
                    if ((Convert.ToString(row[PrimaryColumn1].ToString().Trim()) == Item) && (Convert.ToString(row[PrimaryColumn2].ToString().Trim()) == Batch))
                    {
                        itmval = itmval + 1;
                    }
                }
            }
            if (itmval > 1)
            {
                return functionReturnValue = true;
            }
            return functionReturnValue;
        }
        #endregion

        public bool valitem(Telerik.Windows.Controls.RadGridView GridName, string PrimaryColumn, string Item)
        {
            bool functionReturnValue = false;
            int i = 0;
            int itmval = 0;
            foreach (DataRow row in GridName.Items)
            {
                if (!string.IsNullOrEmpty(row[PrimaryColumn].ToString()))
                {
                    if (Convert.ToString(row[PrimaryColumn].ToString().Trim()) == Item)
                    {
                        itmval = itmval + 1;
                    }
                }
            }
            if (itmval > 1)
            {
                return functionReturnValue = true;
            }
            return functionReturnValue;
        }

        public void winBase_Load(object sender, RoutedEventArgs e)
        {


            int yearID;
            if (IsToolbar == false)
            {
                ToolbarMain.Visibility = Visibility.Hidden;
            }
            else
            {
                ToolbarMain.Visibility = Visibility.Hidden;
            }

            var filedInfo = this.GetType().GetField("dtDocumentDate", BindingFlags.NonPublic | BindingFlags.Instance);
            if (filedInfo != null)
            {
                var documentDatePick = ((DatePicker)filedInfo.GetValue(this));
                //documentDatePick.ValueChanged += new EventHandler(documentDatePick_ValueChanged);
                //documentDatePick.DateValidationError += documentDatePick_DateValidationError;

                documentDatePick.DateValidationError += documentDatePick_DateValidationError;

                // Edited by Dulip

                if (_MinFinancialYear != null)
                    documentDatePick.DisplayDateEnd = Convert.ToDateTime(_MinFinancialYear).Date;    // changed by Dulip
                else
                    documentDatePick.DisplayDateStart = GetServerDate;
                if (_MaxFinancialYear != null)
                    documentDatePick.DisplayDateEnd = Convert.ToDateTime(_MaxFinancialYear);         // changed by Dulip
                else
                    documentDatePick.DisplayDateStart = GetServerDate;

                IsFinancialYearValid(GetServerDateTime, out yearID);
                _CurrentFinancialYearId = yearID;
            }

        }

        public void documentDatePick_DateValidationError(object sender, DatePickerDateValidationErrorEventArgs e)
        {
            try
            {
                var dateInfo = this.GetType().GetField("dtDocumentDate", BindingFlags.NonPublic | BindingFlags.Instance);

                if (dateInfo != null)
                {
                    int yearID;
                    if (!IsFinancialYearValid(((DatePicker)dateInfo.GetValue(this)).SelectedDate.Value, out yearID))   // Edited by Dulip
                    {
                        MessageBox.Show("Selected Date is not in Current Financial Year.", "", MessageBoxButton.OK, MessageBoxImage.Information);
                        _CurrentFinancialYearId = yearID;
                        return;
                    }

                    _CurrentFinancialYearId = yearID;
                }
            }
            catch (Exception ex) { }

        }   //Changed by Dulip


        //*********************************************************************************
        #endregion


        /* public void Dispose()
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }*/
        
       
    }
}
