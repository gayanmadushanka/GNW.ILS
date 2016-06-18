using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Pervation.Common.CommonSearch;

namespace Pervation.Presentation._Basic_Windows.CommonSearch
{
   public class MultiCommonSearch
   {
        public static string[] SelectedItems { get; set; }

        public static DataTable SelectedItemsTable { get; set; }

        private static frmMultiCommonSearch AssignSearchDetails(string zSearchCode)
        {
            frmMultiCommonSearch objSearchForm = new frmMultiCommonSearch();
            try
            {
                DataSet dsSearchType = new CommonSearchDataAccess().GetSearchType(zSearchCode);
                if (dsSearchType.Tables[0].Rows.Count > 0)
                {
                    DataRow drSearchType = dsSearchType.Tables[0].Rows[0];

                    objSearchForm.RecordSource = drSearchType["RecordSource"].ToString();
                    objSearchForm.SelectFields = drSearchType["SelectFields"].ToString();
                    objSearchForm.DisplayFields = drSearchType["DisplayField"].ToString();
                    objSearchForm.InitialCondition = drSearchType["InitialCondition"].ToString();
                    objSearchForm.DataType = drSearchType["DataType"].ToString();
                    objSearchForm.RecordSourceType = drSearchType["RecordSourceType"].ToString();
                    objSearchForm.ServerName = drSearchType["ServerConnection"].ToString();
                    objSearchForm.SearchPara = new CommonSearchDataAccess().GetSearchPara(zSearchCode);
                }
            }
            catch (Exception)
            { }
            return objSearchForm;
        }

        private static frmMultiCommonSearch AssignSearchDetails(string zSearchCode, string zServerName)
        {
            frmMultiCommonSearch objSearchForm = new frmMultiCommonSearch();
            try
            {
                DataSet dsSearchType = new CommonSearchDataAccess().GetServerTypeSearch(zSearchCode, zServerName);
                if (dsSearchType.Tables[0].Rows.Count > 0)
                {
                    DataRow drSearchType = dsSearchType.Tables[0].Rows[0];

                    objSearchForm.RecordSource = drSearchType["RecordSource"].ToString();
                    objSearchForm.SelectFields = drSearchType["SelectFields"].ToString();
                    objSearchForm.DisplayFields = drSearchType["DisplayField"].ToString();
                    objSearchForm.DataType = drSearchType["DataType"].ToString();
                    objSearchForm.RecordSourceType = drSearchType["RecordSourceType"].ToString();
                    objSearchForm.SearchPara = new CommonSearchDataAccess().GetSearchPara(zSearchCode, zServerName);
                }
            }
            catch (Exception)
            { }
            return objSearchForm;
        }

        public static DataTable ShowSearchForm(string zSearchCode, string[] zArParamList,
                                              string[] zArSelectedItems, string zTitle,
                                              bool bAllowMultipleSelection, bool bHidePrimaryKeyField)
        {
            frmMultiCommonSearch objSearchForm = new frmMultiCommonSearch();
            try
            {
                //Read Database and get all the relevent details
                objSearchForm = AssignSearchDetails(zSearchCode);



                objSearchForm.ParameterValues = zArParamList;
                objSearchForm.SelectedItems = zArSelectedItems;
                objSearchForm.AllowMultipleSelection = bAllowMultipleSelection;
                objSearchForm.HidePrimaryKeyField = bHidePrimaryKeyField;

                objSearchForm.PageTitle = zTitle;
                objSearchForm.SearchCode = zSearchCode;
                objSearchForm.ShowDialog();
            }
            catch (Exception)
            { }
            return objSearchForm.SelectedData;
        }

        public static DataTable ShowSearchForm(string zSearchCode, string[] zArParamList,
                                             string[] zArSelectedItems, string zTitle,
                                             bool bAllowMultipleSelection, bool bHidePrimaryKeyField,
                                             string zInitialSearchData, string[] zFilteredBy)
        {
            frmMultiCommonSearch objSearchForm = new frmMultiCommonSearch();

            try
            {

                //Read Database and get all the relevent details
                objSearchForm = AssignSearchDetails(zSearchCode);

                objSearchForm.ParameterValues = zArParamList;
                objSearchForm.SelectedItems = zArSelectedItems;
                objSearchForm.AllowMultipleSelection = bAllowMultipleSelection;
                objSearchForm.HidePrimaryKeyField = bHidePrimaryKeyField;

                objSearchForm.PageTitle = zTitle;
                objSearchForm.SearchCode = zSearchCode;
                objSearchForm.FilteredBy = zFilteredBy;
                objSearchForm.IsSearchPage = true;
                objSearchForm.InitialSearchString = zInitialSearchData;
                objSearchForm.ShowDialog();

            }
            catch (Exception ex)
            {


            }
            return objSearchForm.SelectedData;
        }

        public static DataTable ShowSearchForm(string zSearchCode, string[] zArParamList,
                                              string[] zArSelectedItems, string zTitle,
                                              bool bAllowMultipleSelection, bool bHidePrimaryKeyField,
                                              string zInitialSearchData)
        {
            frmMultiCommonSearch objSearchForm = new frmMultiCommonSearch();

            try
            {

                //Read Database and get all the relevent details
                objSearchForm = AssignSearchDetails(zSearchCode);

                objSearchForm.ParameterValues = zArParamList;
                objSearchForm.SelectedItems = zArSelectedItems;
                objSearchForm.AllowMultipleSelection = bAllowMultipleSelection;
                objSearchForm.HidePrimaryKeyField = bHidePrimaryKeyField;

                objSearchForm.PageTitle = zTitle;
                objSearchForm.SearchCode = zSearchCode;
                objSearchForm.IsSearchPage = true;
                objSearchForm.InitialSearchString = zInitialSearchData;
                objSearchForm.ShowDialog();

            }
            catch (Exception ex) { }
            return objSearchForm.SelectedData;
        }


        public static DataTable ShowSearchForm(string zSearchCode, string[] zArParamList,
                                               string[] zArSelectedItems, string zTitle,
                                               bool bAllowMultipleSelection, bool bHidePrimaryKeyField, bool isStatusFields, string StatusFields)
        {
            frmMultiCommonSearch objSearchForm = new frmMultiCommonSearch(isStatusFields, StatusFields);
            try
            {
                //Read Database and get all the relevent details
                objSearchForm = AssignSearchDetails(zSearchCode);



                objSearchForm.ParameterValues = zArParamList;
                objSearchForm.SelectedItems = zArSelectedItems;
                objSearchForm.AllowMultipleSelection = bAllowMultipleSelection;
                objSearchForm.HidePrimaryKeyField = bHidePrimaryKeyField;

                objSearchForm.PageTitle = zTitle;
                objSearchForm.SearchCode = zSearchCode;
                objSearchForm.ShowDialog();
            }
            catch (Exception)
            { }
            return objSearchForm.SelectedData;
        }

        public static DataTable ShowSearchForm(string zSearchCode, string[] zArParamList,
                                             string[] zArSelectedItems, string zTitle,
                                             bool bAllowMultipleSelection, bool bHidePrimaryKeyField,
                                             string zInitialSearchData, string[] zFilteredBy, bool isStatusFields, string StatusFields)
        {
            frmMultiCommonSearch objSearchForm = new frmMultiCommonSearch(isStatusFields, StatusFields);

            try
            {

                //Read Database and get all the relevent details
                objSearchForm = AssignSearchDetails(zSearchCode);

                objSearchForm.ParameterValues = zArParamList;
                objSearchForm.SelectedItems = zArSelectedItems;
                objSearchForm.AllowMultipleSelection = bAllowMultipleSelection;
                objSearchForm.HidePrimaryKeyField = bHidePrimaryKeyField;

                objSearchForm.PageTitle = zTitle;
                objSearchForm.SearchCode = zSearchCode;
                objSearchForm.FilteredBy = zFilteredBy;
                objSearchForm.IsSearchPage = true;
                objSearchForm.InitialSearchString = zInitialSearchData;
                objSearchForm.ShowDialog();

            }
            catch (Exception ex)
            {


            }
            return objSearchForm.SelectedData;
        }

        public static DataTable ShowSearchForm(string zSearchCode, string[] zArParamList,
                                              string[] zArSelectedItems, string zTitle,
                                              bool bAllowMultipleSelection, bool bHidePrimaryKeyField,
                                              string zInitialSearchData, bool isStatusFields, string StatusFields)
        {
            frmMultiCommonSearch objSearchForm = new frmMultiCommonSearch(isStatusFields, StatusFields);

            try
            {

                //Read Database and get all the relevent details
                objSearchForm = AssignSearchDetails(zSearchCode);

                objSearchForm.ParameterValues = zArParamList;
                objSearchForm.SelectedItems = zArSelectedItems;
                objSearchForm.AllowMultipleSelection = bAllowMultipleSelection;
                objSearchForm.HidePrimaryKeyField = bHidePrimaryKeyField;

                objSearchForm.PageTitle = zTitle;
                objSearchForm.SearchCode = zSearchCode;
                objSearchForm.IsSearchPage = true;
                objSearchForm.InitialSearchString = zInitialSearchData;
                objSearchForm.ShowDialog();

            }
            catch (Exception ex) { }
            return objSearchForm.SelectedData;
        }
    }
}
