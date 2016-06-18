using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GNW.ILS.WPF._Basic_Windows.Base;
using Telerik.Windows.Controls;

namespace GNW.ILS.WPF.Master
{
    /// <summary>
    /// Interaction logic for ucCompanyMaster.xaml
    /// </summary>
    public partial class ucCompanyMaster : UCBase
    {
        //DataTable dtResult = new DataTable();
        //string _ENTITY_ID;
        //string _EDIT_ID;
        //private CompanyDetailLogic _LogicObject = new CompanyDetailLogic();
        //private ucCommonSearch ucCommonsearch1 = new ucCommonSearch();
        //public event ToRearrangeTileViewRequest ToRearrangeTileViewRequestEvent;
        public ucCompanyMaster()
        {
            try
            {
                InitializeComponent();
                //ToolbarMain = UCToolmnu1;
                //base.InitializeToolBar();

                //this.Loaded += ucCompanyMaster_Loaded;
                //this.Unloaded += ucCompanyMaster_Unloaded;
                //UCToolmnu1.btnNew.Click += btnNew_Click;
                //UCToolmnu1.btnDelete.Click += btnDelete_Click;
                //UCToolmnu1.btnSearch.Click += btnSearch_Click;
                //UCToolmnu1.btnSave.Click += btnSave_Click;
                //UCToolmnu1.btnSaveAs.Click += btnSaveAs_Click;
                //UCToolmnu1.btnClose.Click += btnClose_Click;

                //base.Title = "New Comapany";
                //TitleBar.Text = base.Title;
                //ModuleID = ModuleCodes.CompanyMaster;
                ////ucSearchFrame = this.SearchFrame;
                //SetGridDataLink(ModuleID);
            }
            catch (Exception ex)
            { }
        }

        void ucCompanyMaster_Unloaded(object sender, RoutedEventArgs e)
        {
            //OnClose();
        }

        public void radGridViewMain_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //try
            //{
            //    ucCommonsearch1.OnradGridViewMain_Mouse_DoubleClick();
            //    dtResult = ucCommonsearch1.SelectedData;
            //    onSelect();
            //}
            //catch (Exception ex)
            //{ }
        }

        void btnSaveAs_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    if (CanPerform(_UserCurrentCompanyCode, _LoginId, ModuleID, Permission.Create))
            //    {
            //        OnInsert();
            //    }
            //    else
            //    {
            //        OnNoAccess("Create");
            //    }
            //}
            //catch (Exception ex)
            //{ }
        }

        void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    if (FormAction == "Create")
            //    {
            //        if (CanPerform(_UserCurrentCompanyCode, _LoginId, ModuleID, Permission.Create))
            //        {
            //            OnInsert();
            //        }
            //        else
            //        {
            //            OnNoAccess("Create");
            //        }
            //    }
            //    else if (FormAction == "Modify")
            //    {
            //        if (CanPerform(_UserCurrentCompanyCode, _LoginId, ModuleID, Permission.Modify))
            //        {
            //            OnUpdate();
            //        }
            //        else
            //        {
            //            OnNoAccess("Update");
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{ }
        }

        void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //OnFind();
            }
            catch (Exception ex)
            { }
        }

        void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    if (CanPerform(_UserCurrentCompanyCode, _LoginId, ModuleID, Permission.Delete))
            //    {
            //        if (CustomMessageBox.Show("Do you want to delete this information ?", "Delete Information ?", winMessageBox.buttonPanel.YESNO, winMessageBox.icon.Question) == winMessageBox.userResult.YES)
            //        {
            //            OnDelete();
            //        }
            //        else
            //        {
            //        }
            //    }
            //    else
            //    {

            //    }
            //}
            //catch (Exception ex)
            //{ }
        }

        void btnNew_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //OnNew();
            }
            catch (Exception ex)
            { }
        }

        void ucCompanyMaster_Loaded(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    base.OnLoad();
            //    RadTileViewItem TVI = (RadTileViewItem)this.Parent;
            //    TVI.Header = base.Title;
            //    LoadInitialData();

            //    OnFind();                   //dulip
            //}
            //catch (Exception ex)
            //{ }
        }
        public void LoadInitialData()
        {
            //try
            //{

            //    _ENTITY_ID = ModuleCodes.CompanyMaster;
            //    OnNew();
            //}
            //catch (Exception ex)
            //{
            //    //---------------------------------------------------
            //    //SetUserException(ex);
            //    CustomMessageBox.Show(ex.Message, "Error!", winMessageBox.buttonPanel.OKOnly, winMessageBox.icon.Exclamation);
            //    //---------------------------------------------------
            //}
        }
        //public int NumberOfCompnay { get; set; }

        //#region FillObjects
        //private CompanyDetail fillObject()
        //{
        //    CompanyDetail obj = new CompanyDetail();
        //    try
        //    {
        //        RecodeID = txtCode.Text.Trim();

        //        if (!string.IsNullOrEmpty(txtCode.Text.Trim()))
        //        { obj.CompanyCode = Convert.ToInt32(txtCode.Text.Trim()); }

        //        obj.CompanyName = txtName.Text.Trim();
        //        obj.Address = txtAddress.Text.Trim();
        //        obj.TelNo = txtTelNo.Text.Trim();
        //        obj.FaxNo = txtFaxNo.Text.Trim();
        //        obj.Email = txtEmail.Text.Trim();
        //        obj.User = _LoginName;
        //        obj.CreateUserID = _LoginId;
        //        //obj.PvNo = txtPvNo.Text.Trim();
        //        obj.IsActive = Convert.ToString(chkActive.IsChecked);
        //        obj.IsDefault = Convert.ToString(chkIsDefault.IsChecked);
        //    }
        //    catch (Exception ex)
        //    { }
        //    return obj;
        //}
        //#endregion
        //#region InstanceHandler
        ////-----------To handle the single instance------------

        //private static volatile ucCompanyMaster objInstance;
        //private static object syncRoot = new Object();
        //public static ucCompanyMaster Instance
        //{
        //    get
        //    {
        //        if (objInstance == null)
        //        {
        //            lock (syncRoot)
        //            {
        //                if (objInstance == null)
        //                {
        //                    objInstance = new ucCompanyMaster();
        //                }
        //            }
        //        }
        //        return objInstance;
        //    }
        //}
        //#endregion
        //#region BindData
        //public override void BindData(string recordId)
        //{
        //    try
        //    {
        //        DataSet ds;
        //        DataTable dt;

        //        ds = _LogicObject.GetDetailByCode(recordId);
        //        dt = ds.Tables[0];
        //        if (dt.Rows.Count > 0)
        //        {
        //            DataRow row = dt.Rows[0];

        //            txtCode.Text = row[SystemFields._CompanyCode_].ToString();
        //            txtName.Text = row[SystemFields._CompanyName_].ToString();
        //            txtAddress.Text = row[SystemFields._CompanyAddress_].ToString();
        //            txtTelNo.Text = row[SystemFields._CompanyTelNo_].ToString();
        //            txtFaxNo.Text = row[SystemFields._CompanyFaxNo_].ToString();
        //            txtEmail.Text = row[SystemFields._CompanyEmail_].ToString();
        //            //txtPvNo.Text = row[SystemFields._PvNo_].ToString();

        //            if (System.Convert.ToBoolean(row[SystemFields._IsActive_]) == true)
        //            {
        //                chkActive.IsChecked = true;
        //            }
        //            else
        //            {
        //                chkActive.IsChecked = false;
        //            }

        //            if (System.Convert.ToBoolean(row[SystemFields._IsDefaultCompany_]) == true)
        //            {
        //                chkIsDefault.IsChecked = true;
        //            }
        //            else
        //            {
        //                chkIsDefault.IsChecked = false;
        //            }

        //        }
        //        else
        //        {
        //            //SetUserMessage("User Group not found", MessageType.Information);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        //---------------------------------------------------
        //        //SetUserException(ex);
        //        CustomMessageBox.Show(ex.Message, "Error!", winMessageBox.buttonPanel.OKOnly, winMessageBox.icon.Exclamation);
        //        //---------------------------------------------------
        //    }
        //}
        //#endregion
        //#region Insert
        //public override void OnInsert()
        //{
        //    try
        //    {


        //        var dTCompany = _LogicObject.GetAllCompany().Tables[0];
        //        var existCompany = dTCompany.Rows.Count;
        //        if (true)   //existCompany <= NumberOfCompnay   //-dulip have to change
        //        {
        //            if (ValidateFields())
        //            {
        //                var defaultCompany = dTCompany.Select(SystemFields._IsDefaultCompany_ + "='True'");

        //                CompanyDetail obj = fillObject();

        //                if (Convert.ToBoolean(obj.IsDefault))
        //                    if (defaultCompany.Length > 0)
        //                    {
        //                        MessageBox.Show("Default Company already add to the system", "", MessageBoxButton.OK, MessageBoxImage.Information);
        //                        return;
        //                    }


        //                DataOpRes resultStatus = _LogicObject.InsertData(obj);
        //                if (resultStatus.ToString() == "InsertSuccess")
        //                {
        //                    //------------------------
        //                    InsertWriteLog();
        //                    base.OnInsert();
        //                    OnFind(); // by dulip ---Bottom 10
        //                    //------------------------
        //                }
        //                else
        //                {
        //                }

        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("You exceed the number of company account.", "", MessageBoxButton.OK, MessageBoxImage.Information);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        //---------------------------------------------------
        //        //SetUserException(ex);
        //        CustomMessageBox.Show("Record Not Saved!\n" + ex.Message, "Error!", winMessageBox.buttonPanel.OKOnly, winMessageBox.icon.Exclamation);

        //        //---------------------------------------------------
        //    }
        //}
        //#endregion

        //#region Update
        //public override void OnUpdate()
        //{
        //    try
        //    {

        //        if (base.OnValidation(txtCode))
        //        {

        //        }
        //        else
        //        {
        //            return;
        //        }

        //        if (ValidateFields())
        //        {

        //            CompanyDetail obj = fillObject();
        //            DataOpRes resultStatus = _LogicObject.UpdateData(obj);
        //            if (resultStatus.ToString() == "UpdateSuccess")
        //            {
        //                //---------------------------
        //                UpdateWriteLog();
        //                base.OnUpdate();
        //                OnFind(); // by dulip ---Bottom 8
        //                //---------------------------
        //            }
        //            else
        //            {
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        //---------------------------------------------------
        //        //SetUserException(ex);
        //        CustomMessageBox.Show("Record Not Saved!\n" + ex.Message, "Error!", winMessageBox.buttonPanel.OKOnly, winMessageBox.icon.Exclamation);
        //        //---------------------------------------------------
        //    }
        //}
        //#endregion
        //#region select
        //void onSelect()
        //{
        //    try
        //    {
        //        if (dtResult != null)
        //        {
        //            if (dtResult.Rows.Count > 0)
        //            {
        //                //--------------------------
        //                _EDIT_ID = dtResult.Rows[0][SystemFields._CompanyCode_].ToString();
        //                BindData(_EDIT_ID);
        //                RecodeID = _EDIT_ID;
        //                //--------------------------    
        //            }
        //            base.OnFind();
        //        }
        //    }
        //    catch (Exception ex)
        //    { }
        //}
        //#endregion
        //#region Delete
        //public override void OnDelete()
        //{
        //    try
        //    {
        //        if (ValidateFields())
        //        {
        //            DataOpRes returnStatus = _LogicObject.DeleteData(txtCode.Text.Trim(), UCBase._LoginId);
        //            if (returnStatus.ToString() == "DeleteSuccess")
        //            {
        //                //--------------------------------------
        //                DeleteWriteLog();
        //                base.OnDelete();
        //                OnFind();
        //                //--------------------------------------
        //            }
        //            else
        //            {

        //            }

        //        }
        //        else
        //        {
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //---------------------------------------------------
        //        //SetUserException(ex);
        //        CustomMessageBox.Show("Record Not Deleted!\n" + ex.Message, "Error!", winMessageBox.buttonPanel.OKOnly, winMessageBox.icon.Exclamation);
        //        //---------------------------------------------------
        //    }
        //}
        //#endregion
        //#region Find
        //public override void OnFind()
        //{
        //    try
        //    {
        //        string[] arParam = { "" };
        //        string[] arSelected = { "" };
        //        string[] searchData = { "" };

        //        ucCommonsearch1 = Pervation.Presentation._Basic_Windows.UserControls.cls_ucCommonSearch.ShowSearchForm("Sys_ALL_COMPANYDETAILS", arParam, arSelected,
        //                                                                   "Company Details", false, false, "", searchData);
        //        ucCommonsearch1.radGridViewMain.MouseDoubleClick += radGridViewMain_MouseDoubleClick;
        //        ucCommonsearch1.btnSelect.Click += btnSelect_Click;

        //        scViewer.Content = ucCommonsearch1;
        //        dtResult = ucCommonsearch1.SelectedData;
        //    }
        //    catch (Exception ex)
        //    { }
        //}

        //void btnSelect_Click(object sender, RoutedEventArgs e)
        //{
        //    dtResult = ucCommonsearch1.SelectedData;
        //    onSelect();
        //}
        //#endregion

        //#region New
        //public override void OnNew()
        //{
        //    try
        //    {
        //        base.OnNew();
        //        _EDIT_ID = string.Empty;
        //        ReSet_Header_DataFields();
        //    }
        //    catch (Exception ex)
        //    { }
        //}
        //#endregion

        //#region ValidateFields
        //public bool ValidateFields()
        //{
        //    string ErrorMSG = "Validation Errors....! \n\n";
        //    bool ValidationOk = true;

        //    try
        //    {
        //        RequiredFieldValidation ReqFieldValidator = new RequiredFieldValidation();
        //        ReqFieldValidator.ErrorField = "Company Name";
        //        ValidationResult ValidationResultObj = ReqFieldValidator.Validate(txtName.Text.Trim(), null);

        //        if (!ValidationResultObj.IsValid)
        //        {
        //            ValidationOk = false;
        //            ErrorMSG += ValidationResultObj.ErrorContent;
        //        }

        //        TelePhoneNumberFieldValidation TelFieldValidator = new TelePhoneNumberFieldValidation();
        //        TelFieldValidator.ErrorField = "Contact No";
        //        ValidationResultObj = TelFieldValidator.Validate(txtTelNo.Text.Trim(), null);
        //        if (!ValidationResultObj.IsValid)
        //        {
        //            ValidationOk = false;
        //            ErrorMSG += ValidationResultObj.ErrorContent;
        //        }

        //        TelFieldValidator.ErrorField = "Fax No";
        //        ValidationResultObj = TelFieldValidator.Validate(txtFaxNo.Text.Trim(), null);
        //        if (!ValidationResultObj.IsValid)
        //        {
        //            ValidationOk = false;
        //            ErrorMSG += ValidationResultObj.ErrorContent;
        //        }

        //        EmailFieldValidation EmailFieldValidator = new EmailFieldValidation();
        //        ValidationResultObj = EmailFieldValidator.Validate(txtEmail.Text.Trim(), null);
        //        if (!ValidationResultObj.IsValid)
        //        {
        //            ValidationOk = false;
        //            ErrorMSG += ValidationResultObj.ErrorContent;
        //        }

        //        if (!ValidationOk)
        //        {
        //            CustomMessageBox.Show(ErrorMSG, "Validation Errors!", winMessageBox.buttonPanel.OKOnly, winMessageBox.icon.Information);
        //        }
        //    }
        //    catch (Exception ex)
        //    { }
        //    return ValidationOk;
        //}
        //#endregion

        //#region LocalMethods
        //void ReSet_Header_DataFields()
        //{
        //    try
        //    {
        //        chkActive.IsChecked = true;
        //        chkIsDefault.IsChecked = false;
        //        txtName.Focus();
        //    }
        //    catch (Exception ex)
        //    { }
        //}
        //#endregion
        //override public bool OnClose()
        //{
        //    return base.OnClose();
        //}

        void btnClose_Click(object sender, RoutedEventArgs e)
        {
            //RadTileViewItem radTileViewItem = (RadTileViewItem)Parent;
            //radTileViewItem.TileState = TileViewItemState.Minimized;
            //if (ToRearrangeTileViewRequestEvent != null) ToRearrangeTileViewRequestEvent();
        }

        private void uc_CommonSearch1_Double(object sender, MouseButtonEventArgs e)
        {

        }

        private void txtFaxNo_TextChanged(object sender, TextChangedEventArgs e)
        {
            //try
            //{
            //    OnlyNumericValadator.IsTextAllowed(sender);
            //}
            //catch (Exception ex)
            //{ }
        }
        private void txtTelNo_TextChanged(object sender, TextChangedEventArgs e)
        {
            //try
            //{
            //    OnlyNumericValadator.IsTextAllowed(sender);
            //}
            //catch (Exception ex)
            //{ }
        }

        private void txtCommonTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    CommonTasks.SelectTextBoxData(e);
            //}
            //catch (Exception ex)
            //{ }
        }
    }
}
