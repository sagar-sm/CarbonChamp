using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Threading;
using System.Windows.Controls.Primitives;
using System.ComponentModel;
using Microsoft.Phone.Shell;

namespace Carbon_Champ
{

    public partial class MainPage : PhoneApplicationPage
    {
        BackgroundWorker bgWorker;
        Popup myPopup;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            myPopup = new Popup() { IsOpen = true, Child = new AnimatedSplashScreen() };
            bgWorker = new BackgroundWorker();
            RunBackgroundWorker();
            ShellTile LiveTile = ShellTile.ActiveTiles.First();
            if (LiveTile != null)
            {
                StandardTileData tile = new StandardTileData();
                tile.BackgroundImage = new Uri("/Images/tile0.png", UriKind.Relative);
                tile.BackBackgroundImage = new Uri("/Images/tile1.png", UriKind.Relative);
                tile.Title = "Carbon Champ";
                tile.BackTitle="";
                LiveTile.Update(tile);
            }

        }
        private void RunBackgroundWorker()
        {
            bgWorker.DoWork += ((s, args) =>
            {
                Thread.Sleep(7000);
            });

            bgWorker.RunWorkerCompleted += ((s, args) =>
            {
                this.Dispatcher.BeginInvoke(() =>
                {
                    this.myPopup.IsOpen = false;
                }
            );
            });
            bgWorker.RunWorkerAsync();
        }


        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
            /*try
            {
                FootprintDispTblk.Text = GlobalVars.footprint.ToString();
            }
            catch { FootprintDispTblk.Text = "0.00"; }*/
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Settings.xaml", UriKind.Relative));

        }

        private void HubTile_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            HubTile tile = sender as HubTile;
            NavigationService.Navigate(new Uri("/AddDevice.xaml?type=" + tile.Name, UriKind.Relative));
        }

        private void ToFormBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/DataForm.xaml", UriKind.Relative));
        }
    }
}