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
using System.Collections.Generic;

namespace Carbon_Champ
{
    public static class GlobalVars
    {
        public static List<string> Locations = new List<string> { "Mumbai", "New Delhi", "Bangalore", "Chennai", "Kolkata", "Other" };
        public static double[] emissions = new double[50];
        public static double footprint = new double();
        public static List<double> rawdata = new List<double>();
    }
}
