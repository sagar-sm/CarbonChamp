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
    public class Refrigerator : Appliance
    {
        public string Refri_type { get; set; }
        public string Refri_rating { get; set; }
        public string Refri_volume { get; set; }
        private Double Volume { get; set; }

        public override void Eval()
        {
            try
            {
                string tofind = Refri_type + " - (" + Refri_volume + ") - " + Refri_rating + " Star";

                var resource = Application.GetResourceStream(new Uri(@"/Carbon Champ;component/DataFiles/ECE_MinimizeCalculator_26Nov2011_Ver40_WithAssumedBulbValues.csv", UriKind.Relative));
                StreamReader rd = new StreamReader(resource.Stream);

                for (int i = 0; i < 111; i++) rd.ReadLine(); //skip first 112 rows

                //first line with refri volumes
                List<string> line = new List<string>(rd.ReadLine().Split(','));
                //loop to find the correct volume in litres
                while (tofind != line[0])
                {
                    line = new List<string>(rd.ReadLine().Split(','));
                }

                Volume = Double.Parse(line[1]);
                //rd.Dispose();

                //calc power consumption
                var resource2 = Application.GetResourceStream(new Uri(@"/Carbon Champ;component/DataFiles/ECE_MinimizeCalculator_26Nov2011_Ver40_WithAssumedBulbValues.csv", UriKind.Relative));
                StreamReader rd2 = new StreamReader(resource2.Stream);
                string temp = "abc";
                for (int i = 0; i < 8; i++)
                    temp = rd2.ReadLine(); //skip first 9 rows
                //Read next two rows
                List<string> FF_equation = new List<string>(rd2.ReadLine().Split(','));
                List<string> DC_equation = new List<string>(rd2.ReadLine().Split(','));

                //calculate energy consumption
                if (Refri_type == "Frost Free")
                    EnergyConsumption = (Double.Parse(FF_equation[1]) * Double.Parse(Refri_rating) * Double.Parse(Refri_rating) * Volume)
                                        + (Double.Parse(FF_equation[2]) * Volume * Double.Parse(Refri_rating))
                                        + (Double.Parse(FF_equation[3]) * Volume)
                                        + (Double.Parse(FF_equation[4]) * Double.Parse(Refri_rating))
                                        + (Double.Parse(FF_equation[5]));

                else if (Refri_type == "Direct Cool")
                    EnergyConsumption = (Double.Parse(DC_equation[1]) * Double.Parse(Refri_rating) * Double.Parse(Refri_rating) * Volume)
                                        + (Double.Parse(DC_equation[2]) * Volume * Double.Parse(Refri_rating))
                                        + (Double.Parse(DC_equation[3]) * Volume)
                                        + (Double.Parse(DC_equation[4]) * Double.Parse(Refri_rating))
                                        + (Double.Parse(DC_equation[5]));

                CalcFootprint();
                CalcTariff();
            }
            catch { };
        }
    }

}
