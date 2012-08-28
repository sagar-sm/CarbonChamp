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
    public partial class DeviceDetails : PhoneApplicationPage
    {
        public DeviceDetails()
        {
            InitializeComponent();
        }

        string type;
        int index;
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            type = NavigationContext.QueryString["type"];
            index=Int32.Parse(NavigationContext.QueryString["index"]);

            if(type=="a")
            {
                TariffDisp.Text = Globalv.UserACs[index].Tariff.ToString();
                FootprintDisp.Text=Globalv.UserACs[index].Footprint.ToString();
                EnergyDisp.Text=Globalv.UserACs[index].EnergyConsumption.ToString();
            }
            else if(type=="r")
            {
                TariffDisp.Text = Globalv.UserRefris[index].Tariff.ToString();
                FootprintDisp.Text=Globalv.UserRefris[index].Footprint.ToString();
                EnergyDisp.Text=Globalv.UserRefris[index].EnergyConsumption.ToString();
            }
            else if(type=="f")
            {
                TariffDisp.Text = Globalv.UserFans[index].Tariff.ToString();
                FootprintDisp.Text=Globalv.UserFans[index].Footprint.ToString();
                EnergyDisp.Text=Globalv.UserFans[index].EnergyConsumption.ToString();
            }
            else 
            if(type=="b")
            {
                TariffDisp.Text = Globalv.UserBulbs[index].Tariff.ToString();
                FootprintDisp.Text=Globalv.UserBulbs[index].Footprint.ToString();
                EnergyDisp.Text=Globalv.UserBulbs[index].EnergyConsumption.ToString();
            }
            else 
            if(type=="w")
            {
                TariffDisp.Text = Globalv.UserWHs[index].Tariff.ToString();
                FootprintDisp.Text=Globalv.UserWHs[index].Footprint.ToString();
                EnergyDisp.Text=Globalv.UserWHs[index].EnergyConsumption.ToString();
            }
            else 
            if(type=="t")
            {
                TariffDisp.Text = Globalv.UserTVs[index].Tariff.ToString();
                FootprintDisp.Text=Globalv.UserTVs[index].Footprint.ToString();
                EnergyDisp.Text=Globalv.UserTVs[index].EnergyConsumption.ToString();
            }
        }

        private void SwitchButton_Click(object sender, EventArgs e)
        {
            if (type == "a")
            {
                NavigationService.Navigate(new Uri("/SwitchPage.xaml?type=ACForm&index="+index.ToString()+"&isSwitch=1",UriKind.Relative));
            }
            else if (type == "r")
            {
                NavigationService.Navigate(new Uri("/SwitchPage.xaml?type=RefriForm&index=" + index.ToString() + "&isSwitch=1", UriKind.Relative));
            }
            else if (type == "f")
            {
                NavigationService.Navigate(new Uri("/SwitchPage.xaml?type=FanForm&index=" + index.ToString() + "&isSwitch=1", UriKind.Relative));
            }
            else
                if (type == "b")
                {
                    NavigationService.Navigate(new Uri("/SwitchPage.xaml?type=BulbForm&index=" + index.ToString() + "&isSwitch=1", UriKind.Relative));
                }
                else
                    if (type == "w")
                    {
                        NavigationService.Navigate(new Uri("/SwitchPage.xaml?type=WHForm&index=" + index.ToString() + "&isSwitch=1", UriKind.Relative));
                    }
                    else
                        if (type == "t")
                        {
                            NavigationService.Navigate(new Uri("/SwitchPage.xaml?type=TVForm&index=" + index.ToString() + "&isSwitch=1", UriKind.Relative));
                        }
        }
    }

}