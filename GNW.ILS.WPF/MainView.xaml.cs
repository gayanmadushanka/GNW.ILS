using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace GNW.ILS.WPF
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView
    {
        //private readonly string _userImagePath;

        public MainView()
        {
            InitializeComponent();
            //Common.txtCurCompName = txtCurrentCompName;
            //Common.txtCurLocName = txtCurrentLocName;
            //Common.btnChangeLoc = btnChangeLocation;

            //DateTime loggedDateTime = Common.GetServerDateTime;

            //txtCurrentCompName.Text = "Company - " + Common.CompanyName;
            //txtCurrentLocName.Text = "Location - " + Common.DefaultLocationName;

            //txtStatusLoggedAs.Text = "User Name - " + Common.FirstName + " " + Common.LastName;
            //txtStatusVersion.Text = "Version -" + Common.SystemVersion;
            //txtStatusLoginDate.Text = loggedDateTime.ToString("dd/MMM/yyyy").ToUpper();
            //txtStatusLoginTime.Text = "Time - " + loggedDateTime.ToString("HH.mm") + " Hrs";

            ////_userImagePath = ConfigurationManager.AppSettings["UserImagePath"];

            //TbLoginName.Text = Common._LoginName;

            //if (Common.Image != null)
            //{
            //    BitmapImage bitmapImage = new BitmapImage();
            //    bitmapImage.BeginInit();
            //    bitmapImage.StreamSource = new MemoryStream(Common.Image);
            //    bitmapImage.EndInit();
            //    ImUser.Source = bitmapImage;
            //}
            //else
            //{
            //    BitmapImage bitmapImage = new BitmapImage(new Uri("../Resources/user-name.png", UriKind.RelativeOrAbsolute));
            //    ImUser.Source = bitmapImage;
            //}
            ////SetLoginUserImage();
            ////CreateFileWatcher(_userImagePath);

            GdDockingContent.Children.Clear();
            GdDockingContent.Children.Add(new uc_DockingView());
        }

        //private void SetLoginUserImage()
        //{
        //    try
        //    {
        //        Dispatcher.Invoke(() =>
        //        {
        //            BitmapImage bitmapImage = new BitmapImage();
        //            bitmapImage.BeginInit();
        //            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
        //            bitmapImage.UriSource = new Uri(_userImagePath + Common._LoginId + ".png");
        //            bitmapImage.EndInit();
        //            ImUser.Source = bitmapImage.Clone();
        //        });
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}


        private void btnChangeLocation_Click(object sender, RoutedEventArgs e)
        {
            //winChangeLocation winChLoc = new winChangeLocation();
            //winChLoc.ToRefreshMainWindowRequestEvent += winChLoc_ToRefreshMainWindowRequestEvent;
            //winChLoc.ShowDialog();
        }

        private void winChLoc_ToRefreshMainWindowRequestEvent()
        {
            Common.AddView(new MainView());
        }

        //public void CreateFileWatcher(string path)
        //{
        //    FileSystemWatcher watcher = new FileSystemWatcher();
        //    watcher.Path = path;
        //    watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;

        //    watcher.Changed += OnChanged;
        //    watcher.Created += OnChanged;
        //    watcher.Deleted += OnChanged;
        //    watcher.Renamed += OnRenamed;

        //    watcher.EnableRaisingEvents = true;
        //}

        //private void OnChanged(object source, FileSystemEventArgs e)
        //{
        //    SetLoginUserImage();
        //}

        //private void OnRenamed(object source, RenamedEventArgs e)
        //{
        //    SetLoginUserImage();
        //}
    }
}
