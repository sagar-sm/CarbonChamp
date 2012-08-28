using System;
using System.Net;
using System.Windows;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Carbon_Champ
{
    public static class Globalv
    {
        public static List<string> devices = new List<string> { "Air Conditioner", "Refrigerator", "Fan", "Bulbs", "Water Heater", "Television" };
        public static List<string> ratings = new List<string> { "1", "2", "3", "4", "5"};

        //device lists
        public static List<AC> UserACs = new List<AC>();
        public static List<Refrigerator> UserRefris = new List<Refrigerator>();
        public static List<Fan> UserFans = new List<Fan>();
        public static List<Bulb> UserBulbs = new List<Bulb>();
        public static List<WH> UserWHs = new List<WH>();
        public static List<TV> UserTVs = new List<TV>();
        public static string UserLocation = "Bangalore";

        //switched devs
        public static AC AC_sw = new AC();
        public static Refrigerator Refri_sw = new Refrigerator();
        public static Fan Fan_sw = new Fan();
        public static Bulb Bulb_sw = new Bulb();
        public static WH WH_sw = new WH();
        public static TV TV_sw = new TV();
    }
}
