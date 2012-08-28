using System;
using System.Net;
using System.Windows;
using System.Windows.Resources;
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
    public class AC : Appliance
    {
        public string AC_type { get; set; }
        public double AC_tonnage { get; set; }
        public string AC_rating { get; set; }
        public int AC_temperature { get; set; }
        public int AC_DailyUsage { get; set; }
        public int AC_MonthlyUsage { get; set; }

        public override void Eval()
        {
            var resource = Application.GetResourceStream(new Uri(@"/Carbon Champ;component/DataFiles/ECE_MinimizeCalculator_26Nov2011_Ver40_WithAssumedBulbValues.csv", UriKind.Relative));
            StreamReader rd = new StreamReader(resource.Stream);

            for (int i = 0; i < 2; i++) rd.ReadLine(); //skip first 2 rows

            //Read next two rows
            List<string> split_equation = new List<string>(rd.ReadLine().Split(','));
            List<string> window_equation = new List<string>(rd.ReadLine().Split(','));

            //calculate power consumption
            if(AC_type == "Split")
                PowerConsumption = (Double.Parse(split_equation[1])*AC_tonnage*AC_tonnage*Double.Parse(AC_rating))
                                    + (Double.Parse(split_equation[2])*AC_tonnage*Double.Parse(AC_rating))
                                    + (Double.Parse(split_equation[3])*Double.Parse(AC_rating))
                                    + (Double.Parse(split_equation[4])*AC_tonnage)
                                    + (Double.Parse(split_equation[5]));

            else if(AC_type=="Window")
                PowerConsumption = (Double.Parse(window_equation[1]) * AC_tonnage * AC_tonnage * Double.Parse(AC_rating))
                                    + (Double.Parse(window_equation[2]) * AC_tonnage * Double.Parse(AC_rating))
                                    + (Double.Parse(window_equation[3]) * Double.Parse(AC_rating))
                                    + (Double.Parse(window_equation[4]) * AC_tonnage)
                                    + (Double.Parse(window_equation[5]));

            //calc energy units
            double FallinEnergyConsumption = (AC_temperature - 20)*4;
            EnergyConsumption = (PowerConsumption * 1 * AC_DailyUsage * (AC_MonthlyUsage * 30) / 1000) * (1 - (FallinEnergyConsumption / 100));
            CalcFootprint();
            CalcTariff();

        }
    }
}
