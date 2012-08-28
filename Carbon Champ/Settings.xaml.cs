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

namespace Carbon_Champ
{
    public partial class Settings : PhoneApplicationPage
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            LocationsListBox.ItemsSource = GlobalVars.Locations;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Globalv.UserLocation = LocationsListBox.SelectedItem.ToString();
            NavigationService.GoBack();
        }

    }
}