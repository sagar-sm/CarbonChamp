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
    public class Appliance
    {
        public double PowerConsumption { get; set; }
        public double Footprint { get; set; }
        public double EnergyConsumption { get; set; }
        public double Tariff { get; set; }

        public virtual void Eval() { }
        public void CalcTariff()
        {
            if (Globalv.UserLocation == "Bangalore")
                Tariff = 4.5 * EnergyConsumption;
            else if (Globalv.UserLocation == "Chennai")
                Tariff = 3.05 * EnergyConsumption;
            else if (Globalv.UserLocation == "Hyderabad")
                Tariff = 5.95 * EnergyConsumption;
            else if (Globalv.UserLocation == "Kolkata")
                Tariff = 4.79 * EnergyConsumption;
            else if (Globalv.UserLocation == "Mumbai")
                Tariff = 8.43 * EnergyConsumption;
            else if (Globalv.UserLocation == "Delhi")
                Tariff = 4.85 * EnergyConsumption;
            else if (Globalv.UserLocation == "Other")
                Tariff = 4.2 * EnergyConsumption;

            Tariff = Math.Round(Tariff);
        }
        public void CalcFootprint()
        {
            Footprint = Math.Round(EnergyConsumption * 1.56);
            EnergyConsumption = Math.Round(EnergyConsumption);
        }
    }
}
