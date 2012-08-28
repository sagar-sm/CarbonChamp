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
    public class Fan : Appliance
    {
        public string Fan_rating { get; set; }
        public int Fan_count { get; set; }
        public int Fan_DailyUsage { get; set; }
        public int Fan_MonthlyUsage { get; set; }

        public override void Eval()
        {
            PowerConsumption = (-4.9767 * Double.Parse(Fan_rating)) + 74.478;
            EnergyConsumption = (Fan_count * Fan_DailyUsage * (Fan_MonthlyUsage * 30) * PowerConsumption) / 1000;
            CalcFootprint();
            CalcTariff();
        }
    }
}
