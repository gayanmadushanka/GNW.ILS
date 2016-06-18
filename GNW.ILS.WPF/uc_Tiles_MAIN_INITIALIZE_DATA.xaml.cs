using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GNW.ILS.WPF.Favorite;
using GNW.ILS.WPF.Master;
using Telerik.Windows.Controls;

namespace GNW.ILS.WPF
{
    /// <summary>
    /// Interaction logic for uc_Tiles_MAIN_INITIALIZE_DATA.xaml
    /// </summary>
    public partial class uc_Tiles_MAIN_INITIALIZE_DATA
    {
        private readonly List<RadTileViewItem> _radTileViewItemList = new List<RadTileViewItem>();
        private readonly List<TextBlock> _textBlockList = new List<TextBlock>();

        public uc_Tiles_MAIN_INITIALIZE_DATA(FavoriteEnum favoriteEnum)
        {
            InitializeComponent();
            SetRadTileViewItemList();
            SetTextBlockList();
            LoadFavoriteTile(favoriteEnum);
        }

        private void LoadFavoriteTile(FavoriteEnum favoriteEnum)
        {
            switch (favoriteEnum)
            {
                case FavoriteEnum.NODATA:
                    break;
                case FavoriteEnum.NCO:
                    ONMouseDown_TileViewItems(TileVI_CompanyMaster);
                    break;
                case FavoriteEnum.RM:
                    ONMouseDown_TileViewItems(TileVI_RouteMaster);
                    break;
                case FavoriteEnum.NSA:
                    ONMouseDown_TileViewItems(TileVI_SalesExecutiveMaster);
                    break;
                case FavoriteEnum.UOM:
                    ONMouseDown_TileViewItems(TileVI_UOMMaster);
                    break;
                case FavoriteEnum.PT:
                    ONMouseDown_TileViewItems(TileVI_PaymentTypeMaster);
                    break;
                case FavoriteEnum.NSU:
                    ONMouseDown_TileViewItems(TileVI_SupplierMaster);
                    break;
                case FavoriteEnum.NI:
                    ONMouseDown_TileViewItems(TileVI_ItemMaster);
                    break;
                case FavoriteEnum.NCU:
                    ONMouseDown_TileViewItems(TileVI_CustomerMaster);
                    break;
                case FavoriteEnum.SC:
                    ONMouseDown_TileViewItems(TileVI_SupplierCategory);
                    break;
                case FavoriteEnum.IC:
                    ONMouseDown_TileViewItems(TileVI_ItemCategory);
                    break;
                case FavoriteEnum.CC:
                    ONMouseDown_TileViewItems(TileVI_CustomerCategory);
                    break;
                case FavoriteEnum.SL:
                    ONMouseDown_TileViewItems(TileVI_StoreLocationMaster);
                    break;
            }
        }

        private void SetTextBlockList()
        {
            _textBlockList.Add(lblCompanyMaster);
            _textBlockList.Add(lblRouteMaster);
            _textBlockList.Add(lblSalesExecutiveMaster);
            _textBlockList.Add(lblStoreLocationMaster);
            _textBlockList.Add(lbLUOMMaster);
            _textBlockList.Add(lblPaymentType);
            _textBlockList.Add(lblSupplierMaster);
            _textBlockList.Add(lblItemMaster);
            _textBlockList.Add(lblCustomerMaster);
            _textBlockList.Add(lblSupplierCategory);
            _textBlockList.Add(lblItemCategory);
            _textBlockList.Add(lblCustomerCategory);
        }

        private void SetRadTileViewItemList()
        {
            _radTileViewItemList.Add(TileVI_CompanyMaster);
            _radTileViewItemList.Add(TileVI_RouteMaster);
            _radTileViewItemList.Add(TileVI_SalesExecutiveMaster);
            _radTileViewItemList.Add(TileVI_StoreLocationMaster);
            _radTileViewItemList.Add(TileVI_UOMMaster);
            _radTileViewItemList.Add(TileVI_PaymentTypeMaster);
            _radTileViewItemList.Add(TileVI_SupplierMaster);
            _radTileViewItemList.Add(TileVI_ItemMaster);
            _radTileViewItemList.Add(TileVI_CustomerMaster);
            _radTileViewItemList.Add(TileVI_SupplierCategory);
            _radTileViewItemList.Add(TileVI_ItemCategory);
            _radTileViewItemList.Add(TileVI_CustomerCategory);
        }

        private void ONMouseDown_TileViewItems(RadTileViewItem radTileViewItem)
        {
            if (radTileViewItem != null)
            {
                if (!Equals(radTileViewItem.TileState, TileViewItemState.Maximized))
                {
                    radTileViewItem.TileState = TileViewItemState.Maximized;
                }

                if (Equals(radTileViewItem, TileVI_CompanyMaster))
                {
                    ucCompanyMaster userControl = new ucCompanyMaster();
                    //userControl.ToRearrangeTileViewRequestEvent += ToRearrangeTileViewRequestEvent;
                    SetTile(radTileViewItem, lblCompanyMaster, userControl);
                }
            //    else if (Equals(radTileViewItem, TileVI_RouteMaster))
            //    {
            //        ucRouteMaster userControl = new ucRouteMaster();
            //        userControl.ToRearrangeTileViewRequestEvent += ToRearrangeTileViewRequestEvent;
            //        SetTile(radTileViewItem, lblRouteMaster, userControl);
            //    }
            //    else if (Equals(radTileViewItem, TileVI_SalesExecutiveMaster))
            //    {
            //        ucSalesExecutiveMaster userControl = new ucSalesExecutiveMaster();
            //        userControl.ToRearrangeTileViewRequestEvent += ToRearrangeTileViewRequestEvent;
            //        SetTile(radTileViewItem, lblSalesExecutiveMaster, userControl);
            //    }
            //    else if (Equals(radTileViewItem, TileVI_StoreLocationMaster))
            //    {
            //        ucStoreLocationMaster userControl = new ucStoreLocationMaster();
            //        userControl.ToRearrangeTileViewRequestEvent += ToRearrangeTileViewRequestEvent;
            //        SetTile(radTileViewItem, lblStoreLocationMaster, userControl);
            //    }
            //    else if (Equals(radTileViewItem, TileVI_UOMMaster))
            //    {
            //        ucUOMMaster userControl = new ucUOMMaster();
            //        userControl.ToRearrangeTileViewRequestEvent += ToRearrangeTileViewRequestEvent;
            //        SetTile(radTileViewItem, lbLUOMMaster, userControl);
            //    }
            //    else if (Equals(radTileViewItem, TileVI_PaymentTypeMaster))
            //    {
            //        ucPaymentType userControl = new ucPaymentType();
            //        userControl.ToRearrangeTileViewRequestEvent += ToRearrangeTileViewRequestEvent;
            //        SetTile(radTileViewItem, lblPaymentType, userControl);
            //    }
            //    else if (Equals(radTileViewItem, TileVI_SupplierMaster))
            //    {
            //        ucSupplierMaster userControl = new ucSupplierMaster();
            //        userControl.ToRearrangeTileViewRequestEvent += ToRearrangeTileViewRequestEvent;
            //        SetTile(radTileViewItem, lblSupplierMaster, userControl);
            //    }
            //    else if (Equals(radTileViewItem, TileVI_ItemMaster))
            //    {
            //        ucItemMaster userControl = new ucItemMaster();
            //        userControl.ToRearrangeTileViewRequestEvent += ToRearrangeTileViewRequestEvent;
            //        SetTile(radTileViewItem, lblItemMaster, userControl);
            //    }
            //    else if (Equals(radTileViewItem, TileVI_CustomerMaster))
            //    {
            //        ucCustomerMaster userControl = new ucCustomerMaster();
            //        userControl.ToRearrangeTileViewRequestEvent += ToRearrangeTileViewRequestEvent;
            //        SetTile(radTileViewItem, lblCustomerMaster, userControl);
            //    }
            //    else if (Equals(radTileViewItem, TileVI_SupplierCategory))
            //    {
            //        ucSupplierCategory userControl = new ucSupplierCategory();
            //        userControl.ToRearrangeTileViewRequestEvent += ToRearrangeTileViewRequestEvent;
            //        SetTile(radTileViewItem, lblSupplierCategory, userControl);
            //    }
            //    else if (Equals(radTileViewItem, TileVI_ItemCategory))
            //    {
            //        ucItemCategory userControl = new ucItemCategory();
            //        userControl.ToRearrangeTileViewRequestEvent += ToRearrangeTileViewRequestEvent;
            //        SetTile(radTileViewItem, lblItemCategory, userControl);
            //    }
            //    else if (Equals(radTileViewItem, TileVI_CustomerCategory))
            //    {
            //        ucCustomerCategory userControl = new ucCustomerCategory();
            //        userControl.ToRearrangeTileViewRequestEvent += ToRearrangeTileViewRequestEvent;
            //        SetTile(radTileViewItem, lblCustomerCategory, userControl);
            //    }
            }
        }

        private void ToRearrangeTileViewRequestEvent()
        {
            for (int i = 0; i < _radTileViewItemList.Count; i++)
            {
                PrepareTileToRestored(_radTileViewItemList[i], _textBlockList[i]);
            }
            //ToOnlyVisibleReport();
        }

        private void SetTile(RadTileViewItem radTileViewItem, TextBlock textBlock, UserControl userControl)
        {
            switch (radTileViewItem.TileState)
            {
                case TileViewItemState.Maximized:
                    PrepareTileAsMaximized(radTileViewItem, textBlock, userControl);
                    break;
                case TileViewItemState.Restored:
                    PrepareTileToRestored(radTileViewItem, textBlock);
                    break;
            }
        }

        private static void PrepareTileToRestored(RadTileViewItem radTileViewItem, TextBlock textBlock)
        {
            textBlock.Visibility = Visibility.Visible;
            PrepareTileAsRestored(new[] { radTileViewItem }, new[] { textBlock });
        }

        private void PrepareTileAsMaximized(RadTileViewItem radTileViewItem, TextBlock textBlock, UserControl userControl)
        {
            radTileViewItem.Content = userControl;
            IEnumerable<RadTileViewItem> minTvIs = _radTileViewItemList.Where(x => !Equals(x, radTileViewItem)).ToList();
            IEnumerable<TextBlock> textBlocks = _textBlockList.Where(x => !Equals(x, textBlock));
            PrepareTileAsRestored(minTvIs, textBlocks);
            LabelMakeInvisible();
        }

        private static void PrepareTileAsRestored(IEnumerable<RadTileViewItem> tvIs, IEnumerable<TextBlock> textBlocks)
        {
            int i = 0;
            foreach (RadTileViewItem eachTvi in tvIs)
            {
                eachTvi.Content = null;
                var enumerable = textBlocks as TextBlock[];
                if (enumerable != null)
                {
                    eachTvi.Content = enumerable[i];
                    enumerable[i].HorizontalAlignment = HorizontalAlignment.Center;
                    enumerable[i].VerticalAlignment = VerticalAlignment.Bottom;
                }
                i++;
            }
        }

        private void LabelMakeInvisible()
        {
            foreach (var item in _textBlockList)
            {
                item.Visibility = Visibility.Hidden;
            }
        }

        #region TileVI_MouseDown_Events
        private void TileVI_CompanyMaster_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ONMouseDown_TileViewItems(e.Source as RadTileViewItem);
        }

        private void TileVI_SalesExecutiveMaster_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ONMouseDown_TileViewItems(e.Source as RadTileViewItem);
        }

        private void TileVI_StoreLocationMaster_mouseDown(object sender, MouseButtonEventArgs e)
        {
            ONMouseDown_TileViewItems(e.Source as RadTileViewItem);
        }

        private void TileVI_UOMMaster_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ONMouseDown_TileViewItems(e.Source as RadTileViewItem);
        }

        private void TileVI_PaymentTypeMaster_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ONMouseDown_TileViewItems(e.Source as RadTileViewItem);
        }

        private void TileVI_SupplierMaster_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ONMouseDown_TileViewItems(e.Source as RadTileViewItem);
        }

        private void TileVI_ItemMaster_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ONMouseDown_TileViewItems(e.Source as RadTileViewItem);
        }

        private void TileVI_CustomerMaster_mouseDown(object sender, MouseButtonEventArgs e)
        {
            ONMouseDown_TileViewItems(e.Source as RadTileViewItem);
        }

        private void TileVI_SupplierCategory_mouseDown(object sender, MouseButtonEventArgs e)
        {
            ONMouseDown_TileViewItems(e.Source as RadTileViewItem);
        }

        private void TileVI_CustomerCategory_mouseDown(object sender, MouseButtonEventArgs e)
        {
            ONMouseDown_TileViewItems(e.Source as RadTileViewItem);
        }

        private void TileVI_ItemCategory_mouseDown(object sender, MouseButtonEventArgs e)
        {
            ONMouseDown_TileViewItems(e.Source as RadTileViewItem);
        }

        private void TileVI_RouteMaster_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ONMouseDown_TileViewItems(e.Source as RadTileViewItem);
        }
        #endregion
    }
}
