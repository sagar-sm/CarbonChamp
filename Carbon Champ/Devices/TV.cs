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
    public class TV : Appliance
    {
        public string TV_type { get; set; }
        public string TV_rating { get; set; }
        public int TV_size { get; set; }
        public int TV_DailyUsage { get; set; }

        public override void Eval()
        {
            string tofind = TV_type + " " + TV_rating + " Star";
            var resource = Application.GetResourceStream(new Uri(@"/Carbon Champ;component/DataFiles/ECE_MinimizeCalculator_26Nov2011_Ver40_WithAssumedBulbValues.csv", UriKind.Relative));
            StreamReader rd = new StreamReader(resource.Stream);

            for (int i = 0; i < 25; i++) rd.ReadLine(); //skip rows

            List<string> line = new List<string>(rd.ReadLine().Split(','));
            //loop to find the correct TV
            while (tofind != line[0])
            {
                line = new List<string>(rd.ReadLine().Split(','));
            }

            EnergyConsumption = ((Double.Parse(line[1]) * TV_size) + Double.Parse(line[2])) * 1 * TV_DailyUsage * 12 * 30;
            CalcFootprint();
            CalcTariff();

        }
    }
}
