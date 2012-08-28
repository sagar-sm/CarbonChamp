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
using System.IO;
using System.Collections.Generic;

namespace Carbon_Champ
{
    public class WH : Appliance
    {
        public string WH_rating { get; set; }
        public int WH_volume { get; set; }
        public int WH_DailyUsage { get; set; }
        public int WH_MonthlyUsage { get; set; }

        public override void Eval()
        {
            var resource = Application.GetResourceStream(new Uri(@"/Carbon Champ;component/DataFiles/ECE_MinimizeCalculator_26Nov2011_Ver40_WithAssumedBulbValues.csv", UriKind.Relative));
            StreamReader rd = new StreamReader(resource.Stream);

            for (int i = 0; i < 21; i++) rd.ReadLine(); //skip first 21 rows

            List<string> equation = new List<string>(rd.ReadLine().Split(','));

            //calculate power consumption
            PowerConsumption = (Double.Parse(equation[1]) * Double.Parse(WH_rating) * Double.Parse(WH_rating) * WH_volume)
                                    + (Double.Parse(equation[2]) * WH_volume * Double.Parse(WH_rating))
                                    + (Double.Parse(equation[3]) * WH_volume)
                                    + (Double.Parse(equation[4]) * Double.Parse(WH_rating))
                                    + (Double.Parse(equation[5]));
            EnergyConsumption = (PowerConsumption * WH_DailyUsage * (WH_MonthlyUsage * 30)) / 1000;
            CalcFootprint();
            CalcTariff();

        }
    }
}
