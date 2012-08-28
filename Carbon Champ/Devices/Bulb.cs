using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Carbon_Champ
{
    public class Bulb : Appliance
    {
        public string Bulb_type { get; set; }
        public int Bulb_count { get; set; }
        public int Bulb_DailyUsage { get; set; }

        public override void Eval()
        {
            if(Bulb_type == "Incandescent 25W")
                PowerConsumption = 25;
            else if(Bulb_type == "Incandescent 40-60W")
                PowerConsumption = 50;
            else if(Bulb_type == "Incandescent 100W")
                PowerConsumption=100;
            else if(Bulb_type == "CFL")
                PowerConsumption = 15.35;
            else if(Bulb_type == "TFL")
                PowerConsumption = 34.14;
            else if(Bulb_type == "LED")
                PowerConsumption = 7.93;

            EnergyConsumption = (PowerConsumption * Bulb_count * Bulb_DailyUsage * 360) / 1000;
            CalcFootprint();
            CalcTariff();
        }
    }
}
