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

using System.IO.IsolatedStorage;
using System.IO;

namespace Carbon_Champ
{
    public partial class DataForm : PhoneApplicationPage
    {
        public DataForm()
        {
            InitializeComponent();
        }
        private void OnLoad(object sender, RoutedEventArgs e)
        {
            LocationPkr.ItemsSource = GlobalVars.Locations;
            FourWlBoolPkr.ItemsSource = new List<string> { "Yes", "No" };
            FuelPkr.ItemsSource = new List<string> { "LPG", "Piped Gas", "Neither" };
            FourFuelPkr.ItemsSource = new List<string> { "Petrol", "Diesel", "CNG", "LPG" };
            SchBusBoolPkr.ItemsSource = new List<string> { "Yes", "No" };
            LonelyPkr.ItemsSource = new List<string> { "Yes", "No" };


            using (IsolatedStorageFile myIso = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (myIso.FileExists("AllEmissions.txt"))
                {
                    using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("AllEmissions.txt", FileMode.Open, FileAccess.Read, myIso))
                    {
                        StreamReader reader = new StreamReader(stream);

                        #region init
                        PeopleTbx.Text = reader.ReadLine();
                        ElecBillTbx.Text = reader.ReadLine();
                        Fuela1.Text = reader.ReadLine();
                        MilkTbx.Text = reader.ReadLine();
                        MeatTbx.Text = reader.ReadLine();
                        RiceTbx.Text = reader.ReadLine();
                        RickshawTbx.Text = reader.ReadLine();
                        TaxiTbx.Text = reader.ReadLine();
                        ActaxiTbx.Text = reader.ReadLine();
                        BusTbx.Text = reader.ReadLine();
                        AcbusTbx.Text = reader.ReadLine();
                        LocalTrnTbx.Text = reader.ReadLine();
                        LocalTrnTimeTbx.Text = reader.ReadLine();
                        CharTbx.Text = reader.ReadLine();
                        CharTimeTbx.Text = reader.ReadLine();
                        FourTbx.Text = reader.ReadLine();
                        TwoWlMinsTbx.Text = reader.ReadLine();
                        FourWlMinsTbx.Text = reader.ReadLine();
                        ShoIntFltTbx.Text = reader.ReadLine();
                        MedIntFltTbx.Text = reader.ReadLine();
                        LngIntFltTbx.Text = reader.ReadLine();
                        ShoDomFltTbx.Text = reader.ReadLine();
                        MedDomFltTbx.Text = reader.ReadLine();
                        LngDomFltTbx.Text = reader.ReadLine();
                        ShoTrnTbx.Text = reader.ReadLine();
                        MedTrnTbx.Text = reader.ReadLine();
                        LngTrnTbx.Text = reader.ReadLine();
                        ShoBusTbx.Text = reader.ReadLine();
                        MedBusTbx.Text = reader.ReadLine();
                        LngBusTbx.Text = reader.ReadLine();

                        string locpkr = reader.ReadLine();
                        string fuepkr = reader.ReadLine();
                        string schpkr = reader.ReadLine();
                        string foupkr = reader.ReadLine();
                        string lonpkr = reader.ReadLine();
                        string fflpkr = reader.ReadLine();

                        LocationPkr.SelectedIndex = Int32.Parse(locpkr);
                        FuelPkr.SelectedIndex = Int32.Parse(fuepkr);
                        SchBusBoolPkr.SelectedIndex = Int32.Parse(schpkr);
                        FourWlBoolPkr.SelectedIndex = Int32.Parse(foupkr);
                        LonelyPkr.SelectedIndex = Int32.Parse(lonpkr);
                        FourFuelPkr.SelectedIndex = Int32.Parse(fflpkr);

                        reader.Close();

                        #endregion

                    }
                }
                else
                {
                    #region init2
                    PeopleTbx.Text = "1";
                    ElecBillTbx.Text = "0";
                    Fuela1.Text = "30";
                    MilkTbx.Text = "0";
                    MeatTbx.Text = "0";
                    RiceTbx.Text = "0";
                    RickshawTbx.Text = "0";
                    TaxiTbx.Text = "0";
                    ActaxiTbx.Text = "0";
                    BusTbx.Text = "0";
                    AcbusTbx.Text = "0";
                    LocalTrnTbx.Text = "0";
                    LocalTrnTimeTbx.Text = "0";
                    CharTbx.Text = "0";
                    CharTimeTbx.Text = "0";
                    FourTbx.Text = "0";
                    TwoWlMinsTbx.Text = "0";
                    FourWlMinsTbx.Text = "0";
                    ShoIntFltTbx.Text = "0";
                    MedIntFltTbx.Text = "0";
                    LngIntFltTbx.Text = "0";
                    ShoDomFltTbx.Text = "0";
                    MedDomFltTbx.Text = "0";
                    LngDomFltTbx.Text = "0";
                    ShoTrnTbx.Text = "0";
                    MedTrnTbx.Text = "0";
                    LngTrnTbx.Text = "0";
                    ShoBusTbx.Text = "0";
                    MedBusTbx.Text = "0";
                    LngBusTbx.Text = "0";

                    #endregion

                }

            }


            if (SchBusBoolPkr.SelectedItem.ToString().Equals("No"))
            {
                CharteredTravelPanel.Visibility = Visibility.Collapsed;
            }
            if (FourWlBoolPkr.SelectedItem.ToString().Equals("No"))
            {
                FourWlPanel.Visibility = Visibility.Collapsed;
            }

            if (FuelPkr.SelectedItem.ToString().Equals("LPG"))
            {
                Fuelq1.Visibility = Visibility.Visible;
                Fuela1.Visibility = Visibility.Visible;
                Fuelq1.DataContext = "How many days does your LPG cylinder last?";
            }
            else if (FuelPkr.SelectedItem.ToString().Equals("Piped Gas"))
            {
                Fuelq1.Visibility = Visibility.Visible;
                Fuela1.Visibility = Visibility.Visible;
                Fuelq1.DataContext = "What is your monthly Piped Gas bill?";
            }
            else
            {
                Fuelq1.Visibility = Visibility.Collapsed;
                Fuela1.Visibility = Visibility.Collapsed;
            }

        }

        private void FuelPkr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FuelPkr.SelectedItem.ToString().Equals("LPG"))
            {
                Fuelq1.Visibility = Visibility.Visible;
                Fuela1.Visibility = Visibility.Visible;
                Fuelq1.DataContext = "How many days does your LPG cylinder last?";
            }
            else if (FuelPkr.SelectedItem.ToString().Equals("Piped Gas"))
            {
                Fuelq1.Visibility = Visibility.Visible;
                Fuela1.Visibility = Visibility.Visible;
                Fuelq1.DataContext = "What is your monthly Piped Gas bill (Rs.)?";
            }
            else
            {
                Fuelq1.Visibility = Visibility.Collapsed;
                Fuela1.Visibility = Visibility.Collapsed;
            }

        }

        private void SchBusBoolPrk_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SchBusBoolPkr.SelectedItem.ToString().Equals("No"))
                CharteredTravelPanel.Visibility = Visibility.Collapsed;
            else
                CharteredTravelPanel.Visibility = Visibility.Visible;

        }

        private void FourWlBoolPkr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FourWlBoolPkr.SelectedItem.ToString().Equals("No"))
                FourWlPanel.Visibility = Visibility.Collapsed;
            else
                FourWlPanel.Visibility = Visibility.Visible;
        }

        private void LonelyPkr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void FourFuelPkr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void CalcButton_Click(object sender, EventArgs e)
        {
            GlobalVars.rawdata.Clear();


            try
            {
                string city = LocationPkr.SelectedItem.ToString();
                int ppl = Int16.Parse(PeopleTbx.Text);

                if (LocationPkr.SelectedItem.ToString().Equals("Other"))
                {
                    city = "India";
                }

                if (ppl == 0)
                {
                    MessageBox.Show("Number of people cannot be 0. Count yourself!");
                    return;
                }

                double procval = new double();

                #region energy

                //electricity
                string id = @"Electricity - Purchased Electricity -  -  - Regional Grid -  -  - -  -  - Grid -  - ";
                string type = @"Cost Based";
                double ElecEmis = evalRawEmission(Double.Parse(ElecBillTbx.Text), city, type, id, 12, true, ppl);
                GlobalVars.rawdata.Add(Double.Parse(ElecBillTbx.Text));
                if (Double.Parse(ElecBillTbx.Text) == 0)
                    ElecEmis = 0;
                GlobalVars.emissions[0] = ElecEmis;

                //t&d losses
                id = @"Electricity T&D Losses - Purchased Electricity -  -  - Regional Grid -  -  - -  -  - Grid -  - ";
                type = @"Cost Based";
                double TDEmis = evalRawEmission(Double.Parse(ElecBillTbx.Text), city, type, id, 12, true, ppl);
                if (Double.Parse(ElecBillTbx.Text) == 0)
                    TDEmis = 0;

                GlobalVars.emissions[1] = TDEmis;

                //fuel
                double LpgEmis = new double();
                double PngEmis = new double();
                GlobalVars.rawdata.Add(Double.Parse(Fuela1.Text));
                if (FuelPkr.SelectedItem.ToString().Equals("LPG"))
                {
                    id = @"Fossil Fuels - Liquefied Petroleum Gases - LPG Cylinder -  -  -  -  -Cooking - Domestic -  -  -  - ";
                    type = @"Weight Based";
                    if (Fuela1.Text != "0")
                        procval = 14.2 / Double.Parse(Fuela1.Text); //primary mult
                    else
                        MessageBox.Show("No. of days your LPG cylinder lasts cannot be 0.");
                    LpgEmis = evalRawEmission(procval, "India", type, id, 365, true, ppl);
                    GlobalVars.emissions[2] = LpgEmis;
                }
                else if (FuelPkr.SelectedItem.ToString().Equals("Piped Gas"))
                {
                    id = @"Fossil Fuels - Natural Gas - PNG -  -  -  -  -Cooking - Domestic -  -  -  - ";
                    type = @"Cost Based";
                    PngEmis = evalRawEmission(Double.Parse(Fuela1.Text), city, type, id, 12, true, ppl);
                    GlobalVars.emissions[2] = PngEmis;
                }
                else if (FuelPkr.SelectedItem.ToString().Equals("Neither"))
                {
                    GlobalVars.emissions[2] = 0;
                }

                #endregion
                //upto index 2

                #region food

                //milk
                id = @"Dairy - Milk - Avg. -  -  -  -  -  - -  -  - Unprocessed -  - ";
                type = @"Volume Based";
                double MilkEmis = evalRawEmission(Double.Parse(MilkTbx.Text), "India", type, id, 52, true, ppl);
                GlobalVars.rawdata.Add(Double.Parse(MilkTbx.Text));
                GlobalVars.emissions[3] = MilkEmis;

                //meat
                id = @"Meat - Meat Avg. -  -  -  -  -  - -  -  - Unprocessed -  - ";
                type = @"Weight Based";
                procval = Double.Parse(MeatTbx.Text) * 0.268;
                double MeatEmis = evalRawEmission(procval, "India", type, id, 52, false);
                GlobalVars.rawdata.Add(double.Parse(MeatTbx.Text));
                GlobalVars.emissions[4] = MeatEmis;

                //rice
                id = @"Rice -  -  -  -  -  -  - -  -  - Unprocessed -  - ";
                type = @"Weight Based";
                procval = Double.Parse(RiceTbx.Text) * 0.15;
                double RiceEmis = evalRawEmission(procval, "India", type, id, 52, false);
                GlobalVars.rawdata.Add(double.Parse(RiceTbx.Text));
                GlobalVars.emissions[5] = RiceEmis;

                #endregion
                //upto index 5

                #region intercity travel

                //Rickshaw
                id = @"Road Travel - Automobile - 3W - Autorickshaw - City Autorickshaw -  -  -Private/Public Travel - City Travel -  - Avg. Fuel - Avg. Transmission - ";
                type = @"Cost Based";
                double RickEmis = evalRawEmission(Double.Parse(RickshawTbx.Text), city, type, id, 52, false);
                if (Double.Parse(RickshawTbx.Text) == 0)
                    RickEmis = 0;

                GlobalVars.emissions[6] = RickEmis;
                GlobalVars.rawdata.Add(Double.Parse(RickshawTbx.Text));

                //Taxi
                id = @"Road Travel - Automobile - 4W  - Avg. Taxi - City Taxi -  -  -Private/Public Travel - City Travel - Non AC - Avg. Fuel -  - ";
                type = @"Cost Based";
                double TaxiEmis = evalRawEmission(Double.Parse(TaxiTbx.Text), city, type, id, 52, false);
                if (Double.Parse(TaxiTbx.Text) == 0)
                    TaxiEmis = 0;

                GlobalVars.emissions[7] = TaxiEmis;
                GlobalVars.rawdata.Add(Double.Parse(TaxiTbx.Text));

                //AC Taxi
                id = @"Road Travel - Automobile - 4W  - Avg. Taxi - City Taxi -  -  -Private/Public Travel - City Travel - AC - Avg. Fuel -  - ";
                type = @"Cost Based";
                double AcTxEmis = evalRawEmission(Double.Parse(ActaxiTbx.Text), city, type, id, 52, false);
                if (Double.Parse(ActaxiTbx.Text) == 0)
                    AcTxEmis = 0;

                GlobalVars.emissions[8] = AcTxEmis;
                GlobalVars.rawdata.Add(Double.Parse(ActaxiTbx.Text));

                //Bus
                id = @"Road Travel - Bus -  -  - City Bus -  -  -Public Travel - City Travel  - Non AC - Avg. Fuel -  - ";
                type = @"Cost Based";
                double BusEmis = evalRawEmission(Double.Parse(BusTbx.Text), city, type, id, 52, false);
                if (Double.Parse(BusTbx.Text) == 0)
                    BusEmis = 0;

                GlobalVars.emissions[9] = BusEmis;
                GlobalVars.rawdata.Add(Double.Parse(BusTbx.Text));

                //AC Bus
                id = @"Road Travel - Bus -  -  - City Bus -  -  -Public Travel - City Travel  - AC - Avg. Fuel -  - ";
                type = @"Cost Based";
                double AcBsEmis = evalRawEmission(Double.Parse(AcbusTbx.Text), city, type, id, 52, false);
                if (Double.Parse(AcbusTbx.Text) == 0)
                    AcBsEmis = 0;

                GlobalVars.emissions[10] = AcBsEmis;
                GlobalVars.rawdata.Add(Double.Parse(AcbusTbx.Text));

                //Local Train
                id = @"Rail Travel - Rail -  -  -  -  -  -Public Travel - City Travel  -  -  -  - ";
                type = @"Duration (Passenger) Based";
                procval = (Double.Parse(LocalTrnTbx.Text) * Double.Parse(LocalTrnTimeTbx.Text) * 2) / 60;
                double LTrnEmis = evalRawEmission(procval, "India", type, id, 52, false);
                GlobalVars.emissions[11] = LTrnEmis;
                GlobalVars.rawdata.Add(double.Parse(LocalTrnTbx.Text));
                GlobalVars.rawdata.Add(Double.Parse(LocalTrnTimeTbx.Text));

                //Chartered Travel
                if (SchBusBoolPkr.SelectedItem.ToString().Equals("Yes"))
                {
                    id = @"Road Travel - Bus - Single Decker -  -  -  -  -Chartered Travel - City Travel  - Non AC - Avg. Fuel -  - ";
                    type = @"Duration (Passenger) Based";
                    procval = (Double.Parse(CharTbx.Text) * Double.Parse(CharTimeTbx.Text) * 2) / 60;
                    double CharEmis = evalRawEmission(procval, "India", type, id, 52, false);
                    GlobalVars.emissions[12] = CharEmis;
                    GlobalVars.rawdata.Add(double.Parse(CharTbx.Text));
                    GlobalVars.rawdata.Add(double.Parse(CharTimeTbx.Text));
                }
                else
                {
                    GlobalVars.emissions[12] = 0;
                    GlobalVars.rawdata.Add(0);
                    GlobalVars.rawdata.Add(0);
                }

                #endregion
                //upto index 12

                #region private travel

                if (FourWlBoolPkr.SelectedItem.ToString().Equals("Yes"))
                {
                    //4 wheeler
                    switch (FourFuelPkr.SelectedItem.ToString())
                    {
                        case "Petrol":
                            id = @"Road Travel - Automobile - 4W  - Sedan -  -  -  -Private Travel - City Travel - AC - Petrol - Manual - ";
                            break;
                        case "Diesel":
                            id = @"Road Travel - Automobile - 4W  - Sedan -  -  -  -Private Travel - City Travel - AC - Diesel - Manual - ";
                            break;
                        case "CNG":
                            id = @"Road Travel - Automobile - 4W  - Sedan -  -  -  -Private Travel - City Travel - AC - CNG - Manual - ";
                            break;
                        case "LPG":
                            id = @"Road Travel - Automobile - 4W  - Sedan -  -  -  -Private Travel - City Travel - AC - Auto LPG - Manual - ";
                            break;
                        default:
                            id = @"Road Travel - Automobile - 4W  - Sedan -  -  -  -Private Travel - City Travel - AC - Petrol - Manual - ";
                            break;
                    }

                    double primary_mult = new double();
                    if (LonelyPkr.SelectedItem.ToString().Equals("Yes"))
                        primary_mult = 1;
                    else
                        primary_mult = 2.5;

                    type = @"Cost Based";
                    procval = Double.Parse(FourTbx.Text) / primary_mult;
                    double FourWEmis = evalRawEmission(procval, city, type, id, 52, false);
                    GlobalVars.emissions[13] = FourWEmis;
                    GlobalVars.rawdata.Add(double.Parse(FourTbx.Text));

                    id = @"Road Travel - Automobile - 2W - Scooter -  -  -  -Private Travel - City -  - Petrol - 4 ST - ";
                    type = @"Duration (Vehicle) Based";
                    procval = (Double.Parse(TwoWlMinsTbx.Text) / 60) / primary_mult;
                    double TwoDurEmission = evalRawEmission(procval, "India", type, id, 365, false);
                    GlobalVars.emissions[14] = TwoDurEmission;
                    GlobalVars.rawdata.Add(double.Parse(TwoWlMinsTbx.Text));

                    id = @"Road Travel - Automobile - 4W  - Sedan -  -  -  -Private Travel - City Travel - AC - Petrol - Manual - ";
                    type = @"Duration (Vehicle) Based";
                    procval = (Double.Parse(FourWlMinsTbx.Text) / 60) / primary_mult;
                    double FouDurEmission = evalRawEmission(procval, "India", type, id, 365, false);
                    GlobalVars.emissions[15] = FouDurEmission;
                    GlobalVars.rawdata.Add(double.Parse(FourWlMinsTbx.Text));
                }

                else
                {
                    GlobalVars.emissions[13] = 0;
                    GlobalVars.emissions[14] = 0;
                    GlobalVars.emissions[15] = 0;
                    GlobalVars.rawdata.Add(0);
                    GlobalVars.rawdata.Add(0);
                    GlobalVars.rawdata.Add(0);
                }
                #endregion
                //upto index 15

                #region long distance travel

                type = @"Duration (Passenger) Based";
                //International Flights
                id = @"Air Travel - Wide-Body Aircraft -  -  - Avg. Int. Airline -  -  -Public Travel - International Travel - Short Haul - Economy Class - Excluding Circling Ineff. - ";
                procval = Double.Parse(ShoIntFltTbx.Text) * 2 * 4;
                double SIntFltEmission = evalRawEmission(procval, "India", type, id, 1, false);
                if (Double.Parse(ShoIntFltTbx.Text) == 0)
                    SIntFltEmission = 0;

                GlobalVars.emissions[16] = SIntFltEmission;

                id = @"Air Travel - Wide-Body Aircraft -  -  - Avg. Int. Airline -  -  -Public Travel - International Travel - Medium Haul - Economy Class - Excluding Circling Ineff. - ";
                procval = Double.Parse(MedIntFltTbx.Text) * 2 * 8;
                double MIntFltEmission = evalRawEmission(procval, "India", type, id, 1, false);
                if (Double.Parse(MedIntFltTbx.Text) == 0)
                    MIntFltEmission = 0;

                GlobalVars.emissions[17] = MIntFltEmission;

                id = @"Air Travel - Wide-Body Aircraft -  -  - Avg. Int. Airline -  -  -Public Travel - International Travel - Long Haul - Economy Class - Excluding Circling Ineff. - ";
                procval = Double.Parse(LngIntFltTbx.Text) * 2 * 12;
                double LIntFltEmission = evalRawEmission(procval, "India", type, id, 1, false);
                if (Double.Parse(LngIntFltTbx.Text) == 0)
                    LIntFltEmission = 0;

                GlobalVars.emissions[18] = LIntFltEmission;

                //Domestic Flight
                id = @"Air Travel - Narrow-Body Aircraft -  -  - Avg. Dom. Airline -  -  -Public Travel - Domestic Travel - Short Haul - Economy Class - Including Circling Ineff. - ";
                procval = Double.Parse(ShoDomFltTbx.Text) * 2 * 1.12;
                double SDomFltEmission = evalRawEmission(procval, "India", type, id, 1, false);
                if (Double.Parse(ShoDomFltTbx.Text) == 0)
                    SDomFltEmission = 0;

                GlobalVars.emissions[19] = SDomFltEmission;

                id = @"Air Travel - Narrow-Body Aircraft -  -  - Avg. Dom. Airline -  -  -Public Travel - Domestic Travel - Medium Haul - Economy Class - Including Circling Ineff. - ";
                procval = Double.Parse(MedDomFltTbx.Text) * 2 * 1.68;
                double MDomFltEmission = evalRawEmission(procval, "India", type, id, 1, false);
                if (Double.Parse(MedDomFltTbx.Text) == 0)
                    MDomFltEmission = 0;

                GlobalVars.emissions[20] = MDomFltEmission;

                id = @"Air Travel - Narrow-Body Aircraft -  -  - Avg. Dom. Airline -  -  -Public Travel - Domestic Travel - Long Haul - Economy Class - Including Circling Ineff. - ";
                procval = Double.Parse(LngDomFltTbx.Text) * 2 * 2.24;
                double LDomFltEmission = evalRawEmission(procval, "India", type, id, 1, false);
                if (Double.Parse(LngDomFltTbx.Text) == 0)
                    LDomFltEmission = 0;

                GlobalVars.emissions[21] = LDomFltEmission;

                //Long Trains
                id = @"Rail Travel - Rail -  -  -  -  -  -Public Travel - Intercity Travel  -  -  -  - ";
                procval = Double.Parse(ShoTrnTbx.Text) * 2 * 4;
                double STrnEmission = evalRawEmission(procval, "India", type, id, 1, false);
                if (Double.Parse(ShoTrnTbx.Text) == 0)
                    STrnEmission = 0;

                GlobalVars.emissions[22] = STrnEmission;

                procval = Double.Parse(MedTrnTbx.Text) * 2 * 12;
                double MTrnEmission = evalRawEmission(procval, "India", type, id, 1, false);
                if (Double.Parse(MedTrnTbx.Text) == 0)
                    MTrnEmission = 0;

                GlobalVars.emissions[23] = MTrnEmission;

                procval = Double.Parse(LngTrnTbx.Text) * 2 * 24;
                double LTrnEmission = evalRawEmission(procval, "India", type, id, 1, false);
                if (Double.Parse(LngTrnTbx.Text) == 0)
                    LTrnEmission = 0;

                GlobalVars.emissions[24] = LTrnEmission;

                //Long Buses
                id = @"Road Travel - Bus - Single Decker -  -  -  -  -Public Travel - Intercity Travel  - AC - Avg. Fuel -  - ";
                procval = Double.Parse(ShoBusTbx.Text) * 2 * 4;
                double SBusEmission = evalRawEmission(procval, "India", type, id, 1, false);
                if (Double.Parse(ShoBusTbx.Text) == 0)
                    SBusEmission = 0;

                GlobalVars.emissions[25] = SBusEmission;

                procval = Double.Parse(MedBusTbx.Text) * 2 * 12;
                double MBusEmission = evalRawEmission(procval, "India", type, id, 1, false);
                if (Double.Parse(MedBusTbx.Text) == 0)
                    MBusEmission = 0;

                GlobalVars.emissions[26] = MBusEmission;

                procval = Double.Parse(LngBusTbx.Text) * 2 * 24;
                double LBusEmission = evalRawEmission(procval, "India", type, id, 1, false);
                if (Double.Parse(LngBusTbx.Text) == 0)
                    LBusEmission = 0;

                GlobalVars.emissions[27] = LBusEmission;

                GlobalVars.rawdata.Add(double.Parse(ShoIntFltTbx.Text));
                GlobalVars.rawdata.Add(double.Parse(MedIntFltTbx.Text));
                GlobalVars.rawdata.Add(double.Parse(LngIntFltTbx.Text));
                GlobalVars.rawdata.Add(double.Parse(ShoDomFltTbx.Text));
                GlobalVars.rawdata.Add(double.Parse(MedDomFltTbx.Text));
                GlobalVars.rawdata.Add(double.Parse(LngDomFltTbx.Text));
                GlobalVars.rawdata.Add(double.Parse(ShoTrnTbx.Text));
                GlobalVars.rawdata.Add(double.Parse(MedTrnTbx.Text));
                GlobalVars.rawdata.Add(double.Parse(LngTrnTbx.Text));
                GlobalVars.rawdata.Add(double.Parse(ShoBusTbx.Text));
                GlobalVars.rawdata.Add(double.Parse(MedBusTbx.Text));
                GlobalVars.rawdata.Add(double.Parse(LngBusTbx.Text));



                #endregion
                //upto index 27

                GlobalVars.footprint = 0;
                for (int k = 0; k <= 27; k++)
                {
                    GlobalVars.footprint += GlobalVars.emissions[k];
                }

                using (IsolatedStorageFile myIso = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("AllEmissions.txt", FileMode.Create, FileAccess.Write, myIso))
                    {
                        StreamWriter writer = new StreamWriter(stream);
                        writer.WriteLine(PeopleTbx.Text);
                        for (int d = 0; d < GlobalVars.rawdata.Count; d++)
                        {
                            writer.WriteLine(GlobalVars.rawdata[d]);
                        }
                        writer.WriteLine(LocationPkr.SelectedIndex.ToString());
                        writer.WriteLine(FuelPkr.SelectedIndex.ToString());
                        writer.WriteLine(SchBusBoolPkr.SelectedIndex.ToString());
                        writer.WriteLine(FourWlBoolPkr.SelectedIndex.ToString());
                        writer.WriteLine(LonelyPkr.SelectedIndex.ToString());
                        writer.WriteLine(FourFuelPkr.SelectedIndex.ToString());

                        writer.Close();

                    }

                    using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("Footprint.txt", FileMode.Create, FileAccess.Write, myIso))
                    {
                        StreamWriter writer = new StreamWriter(stream);
                        writer.WriteLine(GlobalVars.footprint.ToString());
                        writer.Close();

                    }


                }

                MessageBox.Show(Math.Round((GlobalVars.footprint / 1000), 2).ToString() + " tonnes of CO2 per annum", "Your Carbon Footprint is:", MessageBoxButton.OK);
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
            catch (FormatException)
            {
                MessageBox.Show("Please pan and fill all details of all types. Do not leave blanks.", "Oops! Something seems to be missed out.", MessageBoxButton.OK);
            }
        }

        private double evalRawEmission(double amt, string city, string type, string id, double timeMultiplier, bool isHousehold, int members = 1)
        {
            int row = 0, col = 0, i = 0;
            double x4 = 0, x3 = 0, x2 = 0, x1 = 0, x0 = 0;
            var resource = Application.GetResourceStream(new Uri(@"/CarbonCalc;component/DataFiles/no2co2_Calculator_Dec282011.csv", UriKind.Relative));

            System.IO.StreamReader reader = new System.IO.StreamReader(resource.Stream);
            string tofind = city + "-" + type + "-x4";

            string line = reader.ReadLine();
            List<string> entities = new List<string>(line.Split(','));

            //save the coefficients' starting location
            foreach (string s in entities)
            {
                i++;
                if (s.Equals(tofind))
                {
                    col = i - 1;
                    break;
                }
            }

            //read after 1st line
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                row++;
                entities = new List<string>(line.Split(','));
                if (entities[0].Equals(id))
                {
                    x4 = Double.Parse(entities[col].Equals("") ? "0" : entities[col]);
                    x3 = Double.Parse(entities[col + 1].Equals("") ? "0" : entities[col + 1]);
                    x2 = Double.Parse(entities[col + 2].Equals("") ? "0" : entities[col + 2]);
                    x1 = Double.Parse(entities[col + 3].Equals("") ? "0" : entities[col + 3]);
                    x0 = Double.Parse(entities[col + 4].Equals("") ? "0" : entities[col + 4]);

                    break;
                }
            }

            /* for debug
            MessageBox.Show(x4.ToString());
            MessageBox.Show(x3.ToString());
            MessageBox.Show(x2.ToString());
            MessageBox.Show(x1.ToString());
            MessageBox.Show(x0.ToString());
            */
            double result1 = x4 * Math.Pow(amt, 4) + x3 * Math.Pow(amt, 3) + x2 * Math.Pow(amt, 2) + x1 * Math.Pow(amt, 1) + x0;

            double result;

            if (isHousehold)
                result = (result1 * timeMultiplier) / members;
            else
                result = result1 * timeMultiplier;

            return result;

        }

    }
}