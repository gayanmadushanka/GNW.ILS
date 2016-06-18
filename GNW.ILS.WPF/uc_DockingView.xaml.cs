using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using GNW.ILS.WPF.Favorite;
using GNW.ILS.WPF._Basic_Windows.Base;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Docking;

namespace GNW.ILS.WPF
{
    public partial class uc_DockingView : INotifyPropertyChanged
    {
        private enum PaneType
        {
            Green,
            OceanBlue,
            Purple,
            Transparent
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //#region Properties
        //private ObservableCollection<Link> _dashBoardLinkList;
        //public ObservableCollection<Link> DashBoardLinkList
        //{
        //    get { return _dashBoardLinkList; }
        //    set
        //    {
        //        _dashBoardLinkList = value;
        //        if (PropertyChanged != null)
        //            PropertyChanged(this, new PropertyChangedEventArgs("DashBoardLinkList"));
        //    }
        //}

        ////private ObservableCollection<Link> _resentLinkList;
        ////public new ObservableCollection<Link> ResentLinkList
        ////{
        ////    get { return _resentLinkList; }
        ////    set
        ////    {
        ////        _resentLinkList = value;
        ////        if (PropertyChanged != null)
        ////            PropertyChanged(this, new PropertyChangedEventArgs("ResentLinkList"));
        ////    }
        ////}

        //private ObservableCollection<Link> _favoriteLinkList;
        //public ObservableCollection<Link> FavoriteLinkList
        //{
        //    get { return _favoriteLinkList; }
        //    set
        //    {
        //        _favoriteLinkList = value;
        //        if (PropertyChanged != null)
        //            PropertyChanged(this, new PropertyChangedEventArgs("FavoriteLinkList"));
        //    }
        //}
        //#endregion

        //private Window _dragdropWindow;
        //private readonly ListBox _lbReportLink = new ListBox();

        public uc_DockingView()
        {
            InitializeComponent();
            UCBase.GdContent = GdContent;
            UCBase.GdBottom = GdBottom;
            UCBase.RpGridData = RpGridData;
            UCBase.RpDashBoard = RpDashBoard;
            UCBase.RpReport = RpReport;
            UCBase.RpBottom = RpBottom;
            UCBase.LbGridDataLink = LbGridDataLink;

            //SetListBoxItemStyle();
            //ToLoadDashBoard();

            ////UCBase.LbResentLink = LbResentLink;
            ////ResentConfig = GetResentConfig();
            ////if (ResentConfig != null)
            ////{
            ////    SetResentConfig();
            ////}

            //_lbReportLink.ItemContainerStyle = FindResource("MenuListBoxItemStyle") as Style;
            //_lbReportLink.Background = FindResource("ManuBGBrush") as Brush;

            //_lbReportLink.MouseDoubleClick += LbReportLink_OnMouseDoubleClick;
            //GdReportLink.Children.Add(_lbReportLink);

            //_lbReportLink.ItemsSource = GetLink(LinkEnum.REP, 4);
            //DashBoardLinkList = GetLink(LinkEnum.DSB, 15042);
            //FavoriteLinkList = GetLink(LinkEnum.FVT, 15009);

            //DataContext = this;
        }

        //#region Common Operation

        //private ObservableCollection<Link> GetLink(LinkEnum linkEnum, int moduleId)
        //{
        //    DataSet userCanAccessLink = GetUserCanAccessLink(_UserCurrentCompanyCode, _LoginId, moduleId);
        //    ObservableCollection<Link> linkList = new ObservableCollection<Link>();
        //    if (userCanAccessLink.Tables[0].Rows.Count > 0)
        //    {
        //        DataTable dtBindHeader = userCanAccessLink.Tables[0];
        //        if (dtBindHeader.Rows.Count > 0)
        //        {
        //            switch (linkEnum)
        //            {
        //                case LinkEnum.DSB:
        //                    GetDashBoardLinkList(dtBindHeader, linkList);
        //                    break;
        //                case LinkEnum.REP:
        //                    GetReportLinkList(dtBindHeader, linkList);
        //                    break;
        //                case LinkEnum.FVT:
        //                    GetFavoriteLinkList(dtBindHeader, linkList);
        //                    break;
        //            }
        //        }
        //    }
        //    return linkList;
        //}

        //#endregion

        #region GridData Operation
        private void LbGridDataLink_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //if (e.ChangedButton != MouseButton.Left) return;
            //Link link = LbGridDataLink.SelectedItem as Link;
            //if (link != null)
            //{
            //    ToLoadBottomGrid(new GridDataView((GridDataLinkEnum)link.LinkEnum));
            //}
        }
        #endregion

        #region Favorite Operation

        //private static void GetFavoriteLinkList(DataTable dtBindHeader, ObservableCollection<Link> linkList)
        //{
        //    try
        //    {
        //        foreach (DataRow row in dtBindHeader.Rows)
        //        {
        //            Link link = new Link(row["ModuleName"].ToString(), (FavoriteEnum)Enum.Parse(typeof(FavoriteEnum), row["ModuleCode"].ToString()), row["ImagePath"].ToString(), row["IsUseLoginCompany"].ToString() != string.Empty && Convert.ToBoolean(row["IsUseLoginCompany"]));
        //            linkList.Add(link);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //    }
        //}

        private void LbFavoriteLink_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
        //    if (e.ChangedButton == MouseButton.Left)
        //    {
        //        Link link = LbFavoriteLink.SelectedItem as Link;
        //        if (link != null)
        //        {
        //            switch ((FavoriteEnum)link.LinkEnum)
        //            {
        //                case FavoriteEnum.PR:
        //                    AddGenaralInventry(FavoriteEnum.PR);
        //                    break;
        //                case FavoriteEnum.PO:
        //                    AddGenaralInventry(FavoriteEnum.PO);
        //                    break;
        //                case FavoriteEnum.GRN:
        //                    AddGenaralInventry(FavoriteEnum.GRN);
        //                    break;
        //                case FavoriteEnum.SUR:
        //                    AddGenaralInventry(FavoriteEnum.SUR);
        //                    break;
        //                case FavoriteEnum.SA:
        //                    AddGenaralInventry(FavoriteEnum.SA);
        //                    break;
        //                case FavoriteEnum.MR:
        //                    AddGenaralInventry(FavoriteEnum.MR);
        //                    break;
        //                case FavoriteEnum.POA:
        //                    AddGenaralInventry(FavoriteEnum.POA);
        //                    break;
        //                case FavoriteEnum.SAR:
        //                    AddGenaralInventry(FavoriteEnum.SAR);
        //                    break;
        //                case FavoriteEnum.IT:
        //                    AddGenaralInventry(FavoriteEnum.IT);
        //                    break;
        //                case FavoriteEnum.JR:
        //                    AddGenaralInventry(FavoriteEnum.JR);
        //                    break;
        //                case FavoriteEnum.ITR:
        //                    AddGenaralInventry(FavoriteEnum.ITR);
        //                    break;
        //                case FavoriteEnum.PRA:
        //                    AddGenaralInventry(FavoriteEnum.PRA);
        //                    break;

        //                case FavoriteEnum.NCO:
        //                    AddMainInitializeData(FavoriteEnum.NCO);
        //                    break;
        //                case FavoriteEnum.RM:
        //                    AddMainInitializeData(FavoriteEnum.RM);
        //                    break;
        //                case FavoriteEnum.NSA:
        //                    AddMainInitializeData(FavoriteEnum.NSA);
        //                    break;
        //                case FavoriteEnum.UOM:
        //                    AddMainInitializeData(FavoriteEnum.UOM);
        //                    break;
        //                case FavoriteEnum.PT:
        //                    AddMainInitializeData(FavoriteEnum.PT);
        //                    break;
        //                case FavoriteEnum.NSU:
        //                    AddMainInitializeData(FavoriteEnum.NSU);
        //                    break;
        //                case FavoriteEnum.NI:
        //                    AddMainInitializeData(FavoriteEnum.NI);
        //                    break;
        //                case FavoriteEnum.NCU:
        //                    AddMainInitializeData(FavoriteEnum.NCU);
        //                    break;
        //                case FavoriteEnum.SC:
        //                    AddMainInitializeData(FavoriteEnum.SC);
        //                    break;
        //                case FavoriteEnum.IC:
        //                    AddMainInitializeData(FavoriteEnum.IC);
        //                    break;
        //                case FavoriteEnum.CC:
        //                    AddMainInitializeData(FavoriteEnum.CC);
        //                    break;
        //                case FavoriteEnum.SL:
        //                    AddMainInitializeData(FavoriteEnum.SL);
        //                    break;

        //                case FavoriteEnum.SI:
        //                    AddSale(FavoriteEnum.SI);
        //                    break;
        //                case FavoriteEnum.SR:
        //                    AddSale(FavoriteEnum.SR);
        //                    break;

        //                case FavoriteEnum.UG:
        //                    AddAdminMenu(FavoriteEnum.UG);
        //                    break;
        //                case FavoriteEnum.GR:
        //                    AddAdminMenu(FavoriteEnum.GR);
        //                    break;
        //                case FavoriteEnum.UI:
        //                    AddAdminMenu(FavoriteEnum.UI);
        //                    break;
        //                case FavoriteEnum.AUG:
        //                    AddAdminMenu(FavoriteEnum.AUG);
        //                    break;
        //                case FavoriteEnum.AUL:
        //                    AddAdminMenu(FavoriteEnum.AUL);
        //                    break;
        //                case FavoriteEnum.CS:
        //                    AddAdminMenu(FavoriteEnum.CS);
        //                    break;
        //            }
        //        }
        //    }
        }
        #endregion

        #region ReportLink Operation

        //private static void GetReportLinkList(DataTable dtBindHeader, ObservableCollection<Link> linkList)
        //{
        //    try
        //    {
        //        foreach (DataRow row in dtBindHeader.Rows)
        //        {
        //            Link link = new Link(row["ModuleName"].ToString(), row["ModuleCode"].ToString(), row["ImagePath"].ToString(), row["IsUseLoginCompany"].ToString() != string.Empty && Convert.ToBoolean(row["IsUseLoginCompany"]));
        //            linkList.Add(link);
        //        }
        //    }
        //    catch (Exception)
        //    {

        //    }
        //}

        private void LbReportLink_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
        //    if (e.ChangedButton == MouseButton.Left)
        //    {
        //        Link link = _lbReportLink.SelectedItem as Link;
        //        if (link != null)
        //        {
        //            ReportParameterView reportParameterView = new ReportParameterView(link.LinkCode, link.IsUseLoginCompany);
        //            ToLoadBottomGrid(reportParameterView);
        //            RpBottom.Header = link.Text;
        //        }
        //    }
        }

        #endregion

        #region DashBoardLink Operation

        //private static void GetDashBoardLinkList(DataTable dtBindHeader, ObservableCollection<Link> linkList)
        //{
        //    try
        //    {
        //        foreach (DataRow row in dtBindHeader.Rows)
        //        {
        //            Link link = new Link(row["ModuleName"].ToString(), (DashBoardLinkEnum)Enum.Parse(typeof(DashBoardLinkEnum), row["ModuleCode"].ToString()), row["ImagePath"].ToString(), row["IsUseLoginCompany"].ToString()!= string.Empty && Convert.ToBoolean(row["IsUseLoginCompany"]));
        //            linkList.Add(link);
        //        }
        //    }
        //    catch (Exception)
        //    {

        //    }
        //}

        //private void SetListBoxItemStyle()
        //{
        //    Style listStyle = new Style(typeof(ListBoxItem));
        //    listStyle.Setters.Add(new EventSetter(PreviewMouseLeftButtonDownEvent, new MouseButtonEventHandler(DashBoardLinkList_PreviewMouseLeftButtonDown)));
        //    listStyle.Setters.Add(new EventSetter(GiveFeedbackEvent, new GiveFeedbackEventHandler(DashBoardLinkList_GiveFeedback)));
        //    listStyle.BasedOn = FindResource("MenuListBoxItemStyle") as Style;
        //    LbDashBoardLink.ItemContainerStyle = listStyle;
        //}

        protected void DashBoardLinkList_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
        //    if (sender is ListBoxItem)
        //    {
        //        ListBoxItem draggedItem = sender as ListBoxItem;
        //        Link dashBoardLink = draggedItem.DataContext as Link;

        //        if (dashBoardLink != null)
        //        {
        //            draggedItem.IsSelected = true;
        //            CreateDragDropWindow(dashBoardLink);
        //            DragDrop.DoDragDrop(draggedItem, draggedItem.DataContext, DragDropEffects.Move);
        //        }
        //    }
        //    if (_dragdropWindow != null)
        //    {
        //        _dragdropWindow.Close();
        //        _dragdropWindow = null;
        //    }
        }

        //private void DashBoardLinkList_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        //{
        //    MousePointFeedbackUpdate();
        //}

        ////private void CreateDragDropWindow(Visual dragElement)
        //private void CreateDragDropWindow(Link dragElement)
        //{
        //    Link link = new Link(dragElement) { TxtText = { Foreground = FindResource("ManuBGBrush") as Brush } };

        //    _dragdropWindow = new Window
        //    {
        //        WindowStyle = WindowStyle.None,
        //        AllowsTransparency = true,
        //        AllowDrop = false,
        //        Background = null,
        //        IsHitTestVisible = false,
        //        SizeToContent = SizeToContent.WidthAndHeight,
        //        Topmost = true,
        //        ShowInTaskbar = false,
        //        Content = new Rectangle
        //        {
        //            Width = dragElement.ActualWidth,
        //            Height = dragElement.ActualHeight,
        //            Fill = new VisualBrush(link)
        //        }
        //    };

        //    MousePointFeedbackUpdate();
        //    _dragdropWindow.Show();
        //}

        //private void MousePointFeedbackUpdate()
        //{
        //    Win32Point w32Mouse = new Win32Point();
        //    GetCursorPos(ref w32Mouse);
        //    _dragdropWindow.Left = w32Mouse.X;
        //    _dragdropWindow.Top = w32Mouse.Y;
        //}

        //[DllImport("user32.dll")]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //internal static extern bool GetCursorPos(ref Win32Point pt);

        //[StructLayout(LayoutKind.Sequential)]
        //internal struct Win32Point
        //{
        //    public Int32 X;
        //    public Int32 Y;
        //};

        #endregion

        #region ResentLink Operation

        ////private void LbResentLink_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        ////{
        ////    if (e.ChangedButton == MouseButton.Left)
        ////    {
        ////        Link link = LbResentLink.SelectedItem as Link;
        ////        if (link != null)
        ////        {
        ////            switch ((ResentLinkEnum)link.LinkEnum)
        ////            {
        ////                case ResentLinkEnum.CSB:
        ////                    break;
        ////                case ResentLinkEnum.SMA:
        ////                    break;
        ////                case ResentLinkEnum.PSS:
        ////                    break;
        ////                case ResentLinkEnum.CP:
        ////                    break;
        ////                case ResentLinkEnum.SP:
        ////                    break;
        ////                case ResentLinkEnum.PO:
        ////                    //AddGenaralInventry(ResentLinkEnum.PO);
        ////                    break;
        ////                case ResentLinkEnum.PR:
        ////                    AddMainInitializeData();
        ////                    break;
        ////            }
        ////        }
        ////    }
        ////}

        //#endregion

        //#region Main Menu Operation

        private void MnuItem_AdminConsole_OnClick(object sender, RoutedEventArgs e)
        {
        //    AddAdminMenu();
        }

        //private void AddAdminMenu(FavoriteEnum favoriteEnum = FavoriteEnum.NODATA)
        //{
        //    ToOnlyVisibleReport();
        //    AddViewToGrid(new pg_TileContaining_AdminMenu(favoriteEnum));
        //}

        private void mnuItm_DashBoard_Click(object sender, RoutedEventArgs e)
        {
        //    ToLoadDashBoard();
        }

        ////private void ToLoadDashBoard()
        ////{
        ////    RpBottom.IsPinned = false;
        ////    uc_DashBoard ucDashBoard = new uc_DashBoard();
        ////    ToHiddenGridData();
        ////    AddViewToGrid(ucDashBoard);
        ////}

        private void MnuItm_InitData_OnClick(object sender, RoutedEventArgs e)
        {
            AddMainInitializeData();
        }

        private void AddMainInitializeData(FavoriteEnum favoriteEnum = FavoriteEnum.NODATA)
        {
            ToOnlyVisibleReport();
            AddViewToGrid(new uc_Tiles_MAIN_INITIALIZE_DATA(favoriteEnum));
        }

        private void MnuItm_GenInventry_Click(object sender, RoutedEventArgs e)
        {
        //    AddGenaralInventry();
        }

        //private void AddGenaralInventry(FavoriteEnum favoriteEnum = FavoriteEnum.NODATA)
        //{
        //    ToOnlyVisibleReport();
        //    AddViewToGrid(new uc_Tiles_GENARAL_INVENTRY(favoriteEnum));
        //}

        private void MnuItm_AR_OnClick(object sender, RoutedEventArgs e)
        {
        //    AddSale();
        }

        //private void AddSale(FavoriteEnum favoriteEnum = FavoriteEnum.NODATA)
        //{
        //    ToOnlyVisibleReport();
        //    AddViewToGrid(new uc_Tiles_SALES(favoriteEnum));
        //}

        private void MnuItm_Reports_OnClick(object sender, RoutedEventArgs e)
        {
        //    ToOnlyVisibleReport();
        //    ucReportLoader ucObjRepLoader = new ucReportLoader { ReportCategory = "MAS" };
        //    AddViewToGrid(ucObjRepLoader);
        }
        #endregion

        #region Docking Panel Operation

        private static bool CompassNeedsToShow(Compass compass)
        {
            return compass.IsLeftIndicatorVisible || compass.IsTopIndicatorVisible || compass.IsRightIndicatorVisible ||
                   compass.IsBottomIndicatorVisible || compass.IsCenterIndicatorVisible;
        }

        private void RadDocking_PreviewShowCompass(object sender, PreviewShowCompassEventArgs e)
        {
            if (e.TargetGroup != null)
            {
                e.Compass.IsCenterIndicatorVisible = CanDockIn(e.DraggedSplitContainer, e.TargetGroup,
                    DockPosition.Center);
                e.Compass.IsLeftIndicatorVisible = CanDockIn(e.DraggedSplitContainer, e.TargetGroup, DockPosition.Left);
                e.Compass.IsTopIndicatorVisible = CanDockIn(e.DraggedSplitContainer, e.TargetGroup, DockPosition.Top);
                e.Compass.IsRightIndicatorVisible = CanDockIn(e.DraggedSplitContainer, e.TargetGroup, DockPosition.Right);
                e.Compass.IsBottomIndicatorVisible = CanDockIn(e.DraggedSplitContainer, e.TargetGroup,
                    DockPosition.Bottom);
            }
            else
            {
                e.Compass.IsLeftIndicatorVisible = CanDock(e.DraggedSplitContainer, DockPosition.Left);
                e.Compass.IsTopIndicatorVisible = CanDock(e.DraggedSplitContainer, DockPosition.Top);
                e.Compass.IsRightIndicatorVisible = CanDock(e.DraggedSplitContainer, DockPosition.Right);
                e.Compass.IsBottomIndicatorVisible = CanDock(e.DraggedSplitContainer, DockPosition.Bottom);
            }
            e.Canceled = !(CompassNeedsToShow(e.Compass));
        }

        private PaneType GetPaneType(RadPane pane)
        {
            Panel c = pane.Content as Panel;
            if (c != null)
            {
                if (c.Background != null)
                {
                    if (c.Background.Equals(Resources["GreenBrush"]))
                    {
                        return PaneType.Green;
                    }
                    if (c.Background.Equals(Resources["OceanBlueBrush"]))
                    {
                        return PaneType.OceanBlue;
                    }
                    return PaneType.Purple;
                }
            }
            return PaneType.Purple;
        }

        private bool CanDockIn(RadPane paneToDock, RadPane paneInTargetGroup, DockPosition position)
        {
            PaneType paneToDockType = GetPaneType(paneToDock);
            PaneType paneInTargetGroupType = GetPaneType(paneInTargetGroup);

            switch (paneToDockType)
            {
                case PaneType.Green:
                    switch (paneInTargetGroupType)
                    {

                        case PaneType.Green:
                            return true;
                        case PaneType.OceanBlue:
                            return position != DockPosition.Top && position != DockPosition.Bottom;
                        case PaneType.Purple:
                            return position != DockPosition.Top && position != DockPosition.Bottom;
                    }
                    break;
                case PaneType.OceanBlue:
                    switch (paneInTargetGroupType)
                    {

                        case PaneType.Green:
                            return position != DockPosition.Left && position != DockPosition.Right;
                        case PaneType.OceanBlue:
                            return true;
                        case PaneType.Purple:
                            return position != DockPosition.Left && position != DockPosition.Right;
                    }
                    break;
                case PaneType.Purple:
                    switch (paneInTargetGroupType)
                    {

                        case PaneType.Green:
                            return position != DockPosition.Center;
                        case PaneType.OceanBlue:
                            return position != DockPosition.Center;
                        case PaneType.Purple:
                            return true;
                    }
                    break;
            }
            return false;
        }

        private bool CanDock(RadPane paneToDock, DockPosition position)
        {
            PaneType paneToDockType = GetPaneType(paneToDock);

            switch (paneToDockType)
            {
                case PaneType.Green:
                    return position != DockPosition.Left;
                case PaneType.OceanBlue:
                    return false;
                case PaneType.Purple:
                    return true;
            }
            return false;
        }

        private bool CanDockIn(ISplitItem dragged, ISplitItem target, DockPosition position)
        {
            // If there is a pane that cannot be dropped in any of the targeted panes.
            return !dragged.EnumeratePanes().Any(p => target.EnumeratePanes().Any(p1 => !CanDockIn(p, p1, position)));
        }

        private bool CanDock(ISplitItem dragged, DockPosition position)
        {
            return dragged.EnumeratePanes().All(p => CanDock(p, position));
        }

        #endregion
    }
}
