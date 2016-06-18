using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Controls;
using Pervation.Presentation.DashBoard.Chart;
using Pervation.Presentation.Delegate;
using Pervation.Presentation._Basic_Windows.CommonMessage;
using SYAN.BusinessLogicLayer.DashBoard;
using SYAN.Common.CommonOperations;
using SYAN.EntityLayer.DashBoard;

namespace Pervation.Presentation.DashBoard
{
    /// <summary>
    /// Interaction logic for uc_DashBoard.xaml
    /// </summary>
    public partial class uc_DashBoard : INotifyPropertyChanged
    {
        #region Properties

        //private int _rowCount;

        //public int RowCount
        //{
        //    get { return _rowCount; }
        //    set
        //    {
        //        _rowCount = value;

        //        if (PropertyChanged != null)
        //            PropertyChanged(this, new PropertyChangedEventArgs("RowCount"));
        //    }
        //}

        //private int _columnCount;

        //public int ColumnCount
        //{
        //    get { return _columnCount; }
        //    set
        //    {
        //        _columnCount = value;
        //        if (PropertyChanged != null)
        //            PropertyChanged(this, new PropertyChangedEventArgs("ColumnCount"));
        //    }
        //}

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        //public event ToLoadReport<DashBoardLinkEnum> ToLoadReportEvent;
        private DashBoardConfig _dashBoardConfig;

        private readonly DashBoardLogic _dashBoardLogic = new DashBoardLogic();
        public uc_DashBoard()
        {
            //Commented line for dynamic grid
            //RowCount = 2;
            //ColumnCount = 2;
            InitializeComponent();
            //DataContext = this;

            //GdLayout.Children.Add(CreateDynamicGrid(new uc_MainChart(GridType.GdChart1),0,0));
            //GdLayout.Children.Add(CreateDynamicGrid(new uc_MainChart(GridType.GdChart2), 0, 1));
            //GdLayout.Children.Add(CreateDynamicGrid(new uc_MainChart(GridType.GdChart3), 1, 0));
            //GdLayout.Children.Add(CreateDynamicGrid(new uc_MainChart(GridType.GdChart4), 1, 1));

            uc_MainChart ucMainChart1 = new uc_MainChart(GridTypeEnum.GdChart1, ChartTypeEnum.PI);
            ucMainChart1.InsertDashBoardConfigEvent += ucMainChart_InsertDashBoardConfigEvent;
            uc_MainChart ucMainChart2 = new uc_MainChart(GridTypeEnum.GdChart2, ChartTypeEnum.BAR);
            ucMainChart2.InsertDashBoardConfigEvent += ucMainChart_InsertDashBoardConfigEvent;
            uc_MainChart ucMainChart3 = new uc_MainChart(GridTypeEnum.GdChart3, ChartTypeEnum.LINEAR);
            ucMainChart3.InsertDashBoardConfigEvent += ucMainChart_InsertDashBoardConfigEvent;
            uc_MainChart ucMainChart4 = new uc_MainChart(GridTypeEnum.GdChart4, ChartTypeEnum.LINEAR);
            ucMainChart4.InsertDashBoardConfigEvent += ucMainChart_InsertDashBoardConfigEvent;

            AddViewToGrid(ucMainChart1, GridTypeEnum.GdChart1);
            AddViewToGrid(ucMainChart2, GridTypeEnum.GdChart2);
            AddViewToGrid(ucMainChart3, GridTypeEnum.GdChart3);
            AddViewToGrid(ucMainChart4, GridTypeEnum.GdChart4);

            _dashBoardConfig = GetDashBoardConfig();
            if (_dashBoardConfig != null)
            {
                SetDashBoardConfig(ref ucMainChart1, ref ucMainChart2, ref ucMainChart3, ref ucMainChart4);
            }
        }

        //private static Grid CreateDynamicGrid(UserControl userControl, int row, int column)
        //{
        //    Grid dynamicGrid = new Grid();
        //    Grid.SetRow(dynamicGrid, row);
        //    Grid.SetColumn(dynamicGrid, column);
        //    dynamicGrid.Children.Add(userControl);
        //    return dynamicGrid;
        //}

        private void ucMainChart_InsertDashBoardConfigEvent(GridTypeEnum gridType, ChartTypeEnum chartType, DashBoardLinkEnum dashBoardLinkEnum, string dashBoardLinkText)
        {
            if (_dashBoardConfig == null) _dashBoardConfig = new DashBoardConfig { UserId = Common._LoginId, CompanyCode = Common.UserCurrentCompanyCode, LocationCode = Convert.ToInt32(Common.DefaultLocation), ConfigurationItemList = new List<ConfigurationItem>() };

            foreach (var item in _dashBoardConfig.ConfigurationItemList)
            {
                if (item.GdChart == gridType.ToString())
                {
                    _dashBoardConfig.ConfigurationItemList.Remove(item);
                    break;
                }
            }
            ConfigurationItem configurationItem = new ConfigurationItem { GdChart = gridType.ToString(), Link = dashBoardLinkEnum.ToString(), ChartType = chartType.ToString(), Title = dashBoardLinkText };
            _dashBoardConfig.ConfigurationItemList.Add(configurationItem);
            _dashBoardLogic.InsertDashBoardConfig(_dashBoardConfig);
            _dashBoardConfig = GetDashBoardConfig();
        }

        private void SetDashBoardConfig(ref uc_MainChart ucMainChart1, ref uc_MainChart ucMainChart2, ref uc_MainChart ucMainChart3, ref uc_MainChart ucMainChart4)
        {
            try
            {
                foreach (var configurationItem in _dashBoardConfig.ConfigurationItemList)
                {
                    DashBoardLinkEnum dashBoardLinkEnum = (DashBoardLinkEnum)Enum.Parse(typeof(DashBoardLinkEnum), configurationItem.Link);

                    ChartTypeEnum chartType = (ChartTypeEnum)Enum.Parse(typeof(ChartTypeEnum), configurationItem.ChartType);
                    switch ((GridTypeEnum)Enum.Parse(typeof(GridTypeEnum), configurationItem.GdChart))
                    {
                        case GridTypeEnum.GdChart1:
                            ucMainChart1.SetGrid(GridTypeEnum.GdChart1, chartType, dashBoardLinkEnum, configurationItem.Title);
                            break;
                        case GridTypeEnum.GdChart2:
                            ucMainChart2.SetGrid(GridTypeEnum.GdChart2, chartType, dashBoardLinkEnum, configurationItem.Title);
                            break;
                        case GridTypeEnum.GdChart3:
                            ucMainChart3.SetGrid(GridTypeEnum.GdChart3, chartType, dashBoardLinkEnum, configurationItem.Title);
                            break;
                        case GridTypeEnum.GdChart4:
                            ucMainChart4.SetGrid(GridTypeEnum.GdChart4, chartType, dashBoardLinkEnum, configurationItem.Title);
                            break;
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private DashBoardConfig GetDashBoardConfig()
        {
            DataTable dataTable = _dashBoardLogic.GetDashBoardConfig(new DashBoardConfig { UserId = Common._LoginId, CompanyCode = Common.UserCurrentCompanyCode, LocationCode = Convert.ToInt32(Common.DefaultLocation) });
            DashBoardConfig dashBoardConfig = null;
            if (dataTable.Rows.Count > 0)
            {
                dashBoardConfig = new DashBoardConfig();
                foreach (DataRow row in dataTable.Rows)
                {
                    dashBoardConfig.Id = Convert.ToInt32(row["Id"]);
                    dashBoardConfig.UserId = Convert.ToInt32(row["UserId"]);
                    dashBoardConfig.CompanyCode = Convert.ToInt32(row["CompanyCode"]);
                    dashBoardConfig.LocationCode = Convert.ToInt32(row["LocationCode"]);
                    dashBoardConfig.ConfigurationItemList = XmlSerializerUtil.DeSerializeXmlToObject<List<ConfigurationItem>>(Convert.ToString(row["ChartDetails"]));
                }
            }
            return dashBoardConfig;
        }

        private void AddViewToGrid(UserControl userControl, GridTypeEnum gridType)
        {
            try
            {
                switch (gridType)
                {
                    case GridTypeEnum.GdChart1:
                        GdChart1.Children.Clear();
                        GdChart1.Children.Add(userControl);
                        break;
                    case GridTypeEnum.GdChart2:
                        GdChart2.Children.Clear();
                        GdChart2.Children.Add(userControl);
                        break;
                    case GridTypeEnum.GdChart3:
                        GdChart3.Children.Clear();
                        GdChart3.Children.Add(userControl);
                        break;
                    case GridTypeEnum.GdChart4:
                        GdChart4.Children.Clear();
                        GdChart4.Children.Add(userControl);
                        break;
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show(ex.Message);
            }
        }
    }
}
