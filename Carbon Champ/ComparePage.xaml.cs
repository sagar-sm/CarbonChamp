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
    public partial class ComparePage : PhoneApplicationPage
    {
        public ComparePage()
        {
            InitializeComponent();
        }

        string type;
        int index;

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {//mend this
            type = NavigationContext.QueryString["type"];
            index = Int32.Parse(NavigationContext.QueryString["index"]);

            if (type == "ACForm")
            {
                TariffDisp.Text = Globalv.UserACs[index].Tariff.ToString();
                FootprintDisp.Text = Globalv.UserACs[index].Footprint.ToString();
                EnergyDisp.Text = Globalv.UserACs[index].EnergyConsumption.ToString();
                NewTariffDisp.Text = Globalv.AC_sw.Tariff.ToString();
                NewFootprintDisp.Text = Globalv.AC_sw.Footprint.ToString();
                NewEnergyDisp.Text = Globalv.AC_sw.EnergyConsumption.ToString();
                SavingsDisp.Text = (Globalv.UserACs[index].Tariff - Globalv.AC_sw.Tariff).ToString();
            }
            else if (type == "RefriForm")
            {
                TariffDisp.Text = Globalv.UserRefris[index].Tariff.ToString();
                FootprintDisp.Text = Globalv.UserRefris[index].Footprint.ToString();
                EnergyDisp.Text = Globalv.UserRefris[index].EnergyConsumption.ToString();
                NewTariffDisp.Text = Globalv.Refri_sw.Tariff.ToString();
                NewFootprintDisp.Text = Globalv.Refri_sw.Footprint.ToString();
                NewEnergyDisp.Text = Globalv.Refri_sw.EnergyConsumption.ToString();
                SavingsDisp.Text = (Globalv.UserRefris[index].Tariff - Globalv.Refri_sw.Tariff).ToString();
            }
            else if (type == "FanForm")
            {
                TariffDisp.Text = Globalv.UserFans[index].Tariff.ToString();
                FootprintDisp.Text = Globalv.UserFans[index].Footprint.ToString();
                EnergyDisp.Text = Globalv.UserFans[index].EnergyConsumption.ToString();
                NewTariffDisp.Text = Globalv.Fan_sw.Tariff.ToString();
                NewFootprintDisp.Text = Globalv.Fan_sw.Footprint.ToString();
                NewEnergyDisp.Text = Globalv.Fan_sw.EnergyConsumption.ToString();
                SavingsDisp.Text = (Globalv.UserFans[index].Tariff - Globalv.Fan_sw.Tariff).ToString();
            }
            else
                if (type == "BulbForm")
                {
                    TariffDisp.Text = Globalv.UserBulbs[index].Tariff.ToString();
                    FootprintDisp.Text = Globalv.UserBulbs[index].Footprint.ToString();
                    EnergyDisp.Text = Globalv.UserBulbs[index].EnergyConsumption.ToString();
                    NewTariffDisp.Text = Globalv.Bulb_sw.Tariff.ToString();
                    NewFootprintDisp.Text = Globalv.Bulb_sw.Footprint.ToString();
                    NewEnergyDisp.Text = Globalv.Bulb_sw.EnergyConsumption.ToString();
                    SavingsDisp.Text = (Globalv.UserBulbs[index].Tariff - Globalv.Bulb_sw.Tariff).ToString();
                }
                else
                    if (type == "WHForm")
                    {
                        TariffDisp.Text = Globalv.UserWHs[index].Tariff.ToString();
                        FootprintDisp.Text = Globalv.UserWHs[index].Footprint.ToString();
                        EnergyDisp.Text = Globalv.UserWHs[index].EnergyConsumption.ToString();
                        NewTariffDisp.Text = Globalv.WH_sw.Tariff.ToString();
                        NewFootprintDisp.Text = Globalv.WH_sw.Footprint.ToString();
                        NewEnergyDisp.Text = Globalv.WH_sw.EnergyConsumption.ToString();
                        SavingsDisp.Text = (Globalv.UserWHs[index].Tariff - Globalv.WH_sw.Tariff).ToString();
                    }
                    else
                        if (type == "TVForm")
                        {
                            TariffDisp.Text = Globalv.UserTVs[index].Tariff.ToString();
                            FootprintDisp.Text = Globalv.UserTVs[index].Footprint.ToString();
                            EnergyDisp.Text = Globalv.UserTVs[index].EnergyConsumption.ToString();
                            NewTariffDisp.Text = Globalv.TV_sw.Tariff.ToString();
                            NewFootprintDisp.Text = Globalv.TV_sw.Footprint.ToString();
                            NewEnergyDisp.Text = Globalv.TV_sw.EnergyConsumption.ToString();
                            SavingsDisp.Text = (Globalv.UserTVs[index].Tariff - Globalv.TV_sw.Tariff).ToString();
                        }
        }

    }
}