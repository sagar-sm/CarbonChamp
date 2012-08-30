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

using System.Xml;
using System.Xml.Serialization;
using System.IO.IsolatedStorage;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Carbon_Champ
{
    public partial class SwitchPage : PhoneApplicationPage
    {
        public SwitchPage()
        {
            InitializeComponent();
        }
        string device_type;
        List<string> DailyUsage = new List<string>();
        List<string> MonthlyUsage = new List<string>();
        int index, isSwitch;

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            string dev;
            if (NavigationContext.QueryString.TryGetValue("type", out dev))
                device_type = dev;
            show_form(dev);
            init_data();
            index = Int32.Parse(NavigationContext.QueryString["index"]);
            isSwitch = Int32.Parse(NavigationContext.QueryString["isSwitch"]);
            if (isSwitch == 1)
                PageTitle.Text = "switch to";
            else
                PageTitle.Text = "add new";
        }

        void show_form(string type)
        {
            StackPanel s;
            for (int i = 0; i <= VisualTreeHelper.GetChildrenCount(ContentPanel) - 1; i++)
            {
                s = VisualTreeHelper.GetChild(ContentPanel, i) as StackPanel;
                s.Visibility = Visibility.Collapsed;

            }

            StackPanel found = FindChild<StackPanel>(ContentPanel, type);
            found.Visibility = Visibility.Visible;

        }

        public static T FindChild<T>(DependencyObject parent, string childName) where T : DependencyObject
        {
            // Confirm parent and childName are valid.
            if (parent == null) return null;

            T foundChild = null;

            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                // If the child is not of the request child type child
                T childType = child as T;
                if (childType == null)
                {
                    // recursively drill down the tree
                    foundChild = FindChild<T>(child, childName);

                    // If the child is found, break so we do not overwrite the found child. 
                    if (foundChild != null) break;
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    var frameworkElement = child as FrameworkElement;
                    // If the child's name is set for search
                    if (frameworkElement != null && frameworkElement.Name == childName)
                    {
                        // if the child's name is of the request name
                        foundChild = (T)child;
                        break;
                    }
                }
                else
                {
                    // child element found.
                    foundChild = (T)child;
                    break;
                }
            }

            return foundChild;
        }

        void init_data()
        {
            MonthlyUsage.Clear();
            DailyUsage.Clear();
            MonthlyUsage.Add("1 month");
            DailyUsage.Add("1 hour");

            for (int k = 2; k < 13; k++)
            {
                MonthlyUsage.Add(k.ToString() + " months");
            }
            for (int k = 2; k < 25; k++)
            {
                DailyUsage.Add(k.ToString() + " hours");
            }
            //init ac
            AC_type.ItemsSource = new List<string> { "Split", "Window" };
            AC_tonnage.ItemsSource = new List<float> { 0.75f, 1.0f, 1.5f, 2.0f };
            AC_rating.ItemsSource = Globalv.ratings;
            AC_temperature.ItemsSource = new List<int> { 18, 19, 20, 21, 22, 23, 24, 25, 26 };
            AC_DailyUsage.ItemsSource = DailyUsage;
            AC_MonthlyUsage.ItemsSource = MonthlyUsage;

            //init refri
            Refri_rating.ItemsSource = Globalv.ratings;
            Refri_type.ItemsSource = new List<string> { "Direct Cool", "Frost Free" };
            Refri_Volume.ItemsSource = new List<string> { "80L - 150L", "150L - 200L", "200L - 250L", "250L - 300L" };

            //init fan
            Fan_rating.ItemsSource = Globalv.ratings;
            Fan_DailyUsage.ItemsSource = DailyUsage;
            Fan_MonthlyUsage.ItemsSource = MonthlyUsage;

            //init bulb
            Bulb_type.ItemsSource = new List<string> { "Incandescent 25W", "Incandescent 40-60W", "Incandescent 100W", "CFL", "TFL", "LED" };
            Bulb_DailyUsage.ItemsSource = DailyUsage;

            //init WH
            WH_rating.ItemsSource = Globalv.ratings;
            WH_Volume.ItemsSource = new List<int> { 10, 15, 25, 35, 50 };
            WH_DailyUsage.ItemsSource = DailyUsage;
            WH_MonthlyUsage.ItemsSource = MonthlyUsage;

            //init TV
            TV_rating.ItemsSource = Globalv.ratings;
            TV_type.ItemsSource = new List<string> { "LCD", "CRT" };
            TV_size.ItemsSource = new List<int> { 14, 21, 29, 32 };
            TV_DailyUsage.ItemsSource = DailyUsage;

        }

        private void Next_Click(object sender, EventArgs e)
        {
            if (isSwitch == 1)
            {
                bool allOK = true;

                if (device_type == "ACForm")
                {

                    AC a = new AC
                    {
                        AC_type = AC_type.SelectedItem.ToString(),
                        AC_rating = AC_rating.SelectedItem.ToString(),
                        AC_temperature = (int)AC_temperature.SelectedItem,
                        AC_tonnage = (float)AC_tonnage.SelectedItem,
                        AC_DailyUsage = Int32.Parse(Regex.Match(AC_DailyUsage.SelectedItem.ToString(), @"\d+").Value),
                        AC_MonthlyUsage = Int32.Parse(Regex.Match(AC_MonthlyUsage.SelectedItem.ToString(), @"\d+").Value)
                    };
                    a.Eval();
                    Globalv.AC_sw = a;

                }//end if

                else if (device_type == "RefriForm")
                {
                    Refrigerator r = new Refrigerator
                    {
                        Refri_type = Refri_type.SelectedItem.ToString(),
                        Refri_rating = Refri_rating.SelectedItem.ToString(),
                        Refri_volume = Refri_Volume.SelectedItem.ToString()
                    };
                    r.Eval();
                    Globalv.Refri_sw = r;

                }//end if 

                else if (device_type == "FanForm")
                {
                    if (Fan_count.Text == "")
                    {
                        allOK = false;
                        MessageBox.Show("Please enter valid number of fans");                        
                    }
                    else
                    {
                        Fan f = new Fan
                            {
                                Fan_count = Convert.ToInt32(Double.Parse(Fan_count.Text)),
                                Fan_rating = Fan_rating.SelectedItem.ToString(),
                                Fan_DailyUsage = Int32.Parse(Regex.Match(Fan_DailyUsage.SelectedItem.ToString(), @"\d+").Value),
                                Fan_MonthlyUsage = Int32.Parse(Regex.Match(Fan_MonthlyUsage.SelectedItem.ToString(), @"\d+").Value)
                            };
                        f.Eval();
                        Globalv.Fan_sw = f;
                        allOK = true;
                    }
                }//end if 

                else if (device_type == "BulbForm")
                {
                    if (Bulb_count.Text == "")
                    {
                        allOK = false;
                        MessageBox.Show("Please enter valid number of bulbs");
                    }
                    else
                    {
                        Bulb b = new Bulb
                            {
                                Bulb_type = Bulb_type.SelectedItem.ToString(),
                                Bulb_count = Convert.ToInt32(Double.Parse(Bulb_count.Text)),
                                Bulb_DailyUsage = Int32.Parse(Regex.Match(Bulb_DailyUsage.SelectedItem.ToString(), @"\d+").Value),
                            };
                        b.Eval();
                        Globalv.Bulb_sw = b;
                        allOK = true;
                    }
                }//end if

                else if (device_type == "WHForm")
                {
                    WH w = new WH
                       {
                           WH_rating = WH_rating.SelectedItem.ToString(),
                           WH_volume = Int32.Parse(WH_Volume.SelectedItem.ToString()),
                           WH_DailyUsage = Int32.Parse(Regex.Match(WH_DailyUsage.SelectedItem.ToString(), @"\d+").Value),
                           WH_MonthlyUsage = Int32.Parse(Regex.Match(WH_MonthlyUsage.SelectedItem.ToString(), @"\d+").Value)
                       };
                    w.Eval();
                    Globalv.WH_sw = w;

                }//end if

                else if (device_type == "TVForm")
                {
                    TV t = new TV
                        {
                            TV_rating = TV_rating.SelectedItem.ToString(),
                            TV_type = TV_type.SelectedItem.ToString(),
                            TV_size = Int32.Parse(TV_size.SelectedItem.ToString()),
                            TV_DailyUsage = Int32.Parse(Regex.Match(TV_DailyUsage.SelectedItem.ToString(), @"\d+").Value),
                        };
                    t.Eval();
                    Globalv.TV_sw = t;

                }//end if

                //ensure that isSwitched=1 and index=-1 never occur together.
                if (allOK)
                {
                    NavigationService.Navigate(new Uri("/ComparePage.xaml?type=" + device_type + "&index=" + index.ToString(), UriKind.Relative));
                }
            }
            else if (isSwitch == 0) //then save for add new
            {

                bool allOK = true;

                if (device_type == "ACForm")
                {
                    XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                    xmlWriterSettings.Indent = true;

                    using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                    {
                        List<AC> temp = new List<AC>();
                        if (myIsolatedStorage.FileExists("ACs.xml"))
                        {
                            using (IsolatedStorageFileStream stream1 = new IsolatedStorageFileStream("ACs.xml", FileMode.Open, FileAccess.Read, myIsolatedStorage))
                            {
                                XmlSerializer serializer = new XmlSerializer(typeof(List<AC>));
                                temp = (List<AC>)serializer.Deserialize(stream1);
                            }


                            AC a = new AC
                            {
                                AC_type = AC_type.SelectedItem.ToString(),
                                AC_rating = AC_rating.SelectedItem.ToString(),
                                AC_temperature = (int)AC_temperature.SelectedItem,
                                AC_tonnage = (float)AC_tonnage.SelectedItem,
                                AC_DailyUsage = Int32.Parse(Regex.Match(AC_DailyUsage.SelectedItem.ToString(), @"\d+").Value),
                                AC_MonthlyUsage = Int32.Parse(Regex.Match(AC_MonthlyUsage.SelectedItem.ToString(), @"\d+").Value)
                            };
                            a.Eval();
                            temp.Add(a);
                            Globalv.UserACs = temp;
                        }
                        else
                        {
                            AC a = new AC
                            {
                                AC_type = AC_type.SelectedItem.ToString(),
                                AC_rating = AC_rating.SelectedItem.ToString(),
                                AC_temperature = (int)AC_temperature.SelectedItem,
                                AC_tonnage = (float)AC_tonnage.SelectedItem,
                                AC_DailyUsage = Int32.Parse(Regex.Match(AC_DailyUsage.SelectedItem.ToString(), @"\d+").Value),
                                AC_MonthlyUsage = Int32.Parse(Regex.Match(AC_MonthlyUsage.SelectedItem.ToString(), @"\d+").Value)
                            };
                            a.Eval();
                            Globalv.UserACs.Add(a);
                        }


                        using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("ACs.xml", FileMode.Create, myIsolatedStorage))
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(List<AC>));
                            using (XmlWriter xmlWriter = XmlWriter.Create(stream, xmlWriterSettings))
                            {
                                serializer.Serialize(xmlWriter, Globalv.UserACs);
                            }
                        }

                    }
                }//end if

                else if (device_type == "RefriForm")
                {
                    XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                    xmlWriterSettings.Indent = true;

                    using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                    {
                        List<Refrigerator> temp = new List<Refrigerator>();
                        if (myIsolatedStorage.FileExists("Refris.xml"))
                        {
                            using (IsolatedStorageFileStream stream1 = new IsolatedStorageFileStream("Refris.xml", FileMode.Open, FileAccess.Read, myIsolatedStorage))
                            {
                                XmlSerializer serializer = new XmlSerializer(typeof(List<Refrigerator>));
                                temp = (List<Refrigerator>)serializer.Deserialize(stream1);
                            }


                            Refrigerator r = new Refrigerator
                            {
                                Refri_type = Refri_type.SelectedItem.ToString(),
                                Refri_rating = Refri_rating.SelectedItem.ToString(),
                                Refri_volume = Refri_Volume.SelectedItem.ToString()
                            };
                            r.Eval();
                            temp.Add(r);
                            Globalv.UserRefris = temp;
                        }
                        else
                        {
                            Refrigerator r = new Refrigerator
                            {
                                Refri_type = Refri_type.SelectedItem.ToString(),
                                Refri_rating = Refri_rating.SelectedItem.ToString(),
                                Refri_volume = Refri_Volume.SelectedItem.ToString()
                            };
                            r.Eval();
                            Globalv.UserRefris.Add(r);
                        }


                        using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("Refris.xml", FileMode.Create, myIsolatedStorage))
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(List<Refrigerator>));
                            using (XmlWriter xmlWriter = XmlWriter.Create(stream, xmlWriterSettings))
                            {
                                serializer.Serialize(xmlWriter, Globalv.UserRefris);
                            }
                        }
                    }
                }//end if 

                else if (device_type == "FanForm")
                {
                    XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                    xmlWriterSettings.Indent = true;
                    if (Fan_count.Text == "")
                    {
                        allOK = false;
                        MessageBox.Show("Please enter valid number of fans");
                    }
                    else
                    {
                        using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                        {
                            List<Fan> temp = new List<Fan>();
                            if (myIsolatedStorage.FileExists("Fans.xml"))
                            {
                                using (IsolatedStorageFileStream stream1 = new IsolatedStorageFileStream("Fans.xml", FileMode.Open, FileAccess.Read, myIsolatedStorage))
                                {
                                    XmlSerializer serializer = new XmlSerializer(typeof(List<Fan>));
                                    temp = (List<Fan>)serializer.Deserialize(stream1);
                                }


                                Fan f = new Fan
                                {
                                    Fan_count = Convert.ToInt32(Double.Parse(Fan_count.Text)),
                                    Fan_rating = Fan_rating.SelectedItem.ToString(),
                                    Fan_DailyUsage = Int32.Parse(Regex.Match(Fan_DailyUsage.SelectedItem.ToString(), @"\d+").Value),
                                    Fan_MonthlyUsage = Int32.Parse(Regex.Match(Fan_MonthlyUsage.SelectedItem.ToString(), @"\d+").Value)
                                };
                                f.Eval();
                                temp.Add(f);
                                Globalv.UserFans = temp;
                            }
                            else
                            {
                                Fan f = new Fan
                                {
                                    Fan_count = Convert.ToInt32(Double.Parse(Fan_count.Text)),
                                    Fan_rating = Fan_rating.SelectedItem.ToString(),
                                    Fan_DailyUsage = Int32.Parse(Regex.Match(Fan_DailyUsage.SelectedItem.ToString(), @"\d+").Value),
                                    Fan_MonthlyUsage = Int32.Parse(Regex.Match(Fan_MonthlyUsage.SelectedItem.ToString(), @"\d+").Value)
                                };
                                f.Eval();
                                Globalv.UserFans.Add(f);
                            }

                            using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("Fans.xml", FileMode.Create, myIsolatedStorage))
                            {
                                XmlSerializer serializer = new XmlSerializer(typeof(List<Fan>));
                                using (XmlWriter xmlWriter = XmlWriter.Create(stream, xmlWriterSettings))
                                {
                                    serializer.Serialize(xmlWriter, Globalv.UserFans);
                                }
                            }
                        }
                        allOK = true;
                    }
                }//end if 

                else if (device_type == "BulbForm")
                {
                    XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                    xmlWriterSettings.Indent = true;

                    if (Bulb_count.Text == "")
                    {
                        allOK = false;
                        MessageBox.Show("Please enter valid number of bulbs");
                    }
                    else
                    {
                        using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                        {
                            List<Bulb> temp = new List<Bulb>();
                            if (myIsolatedStorage.FileExists("Bulbs.xml"))
                            {
                                using (IsolatedStorageFileStream stream1 = new IsolatedStorageFileStream("Bulbs.xml", FileMode.Open, FileAccess.Read, myIsolatedStorage))
                                {
                                    XmlSerializer serializer = new XmlSerializer(typeof(List<Bulb>));
                                    temp = (List<Bulb>)serializer.Deserialize(stream1);
                                }


                                Bulb b = new Bulb
                                {
                                    Bulb_type = Bulb_type.SelectedItem.ToString(),
                                    Bulb_count = Convert.ToInt32(Double.Parse(Bulb_count.Text)),
                                    Bulb_DailyUsage = Int32.Parse(Regex.Match(Bulb_DailyUsage.SelectedItem.ToString(), @"\d+").Value),
                                };
                                b.Eval();
                                temp.Add(b);
                                Globalv.UserBulbs = temp;
                            }
                            else
                            {
                                Bulb b = new Bulb
                                {
                                    Bulb_type = Bulb_type.SelectedItem.ToString(),
                                    Bulb_count = Convert.ToInt32(Double.Parse(Bulb_count.Text)),
                                    Bulb_DailyUsage = Int32.Parse(Regex.Match(Bulb_DailyUsage.SelectedItem.ToString(), @"\d+").Value),
                                };
                                b.Eval();
                                Globalv.UserBulbs.Add(b);
                            }

                            using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("Bulbs.xml", FileMode.Create, myIsolatedStorage))
                            {
                                XmlSerializer serializer = new XmlSerializer(typeof(List<Bulb>));
                                using (XmlWriter xmlWriter = XmlWriter.Create(stream, xmlWriterSettings))
                                {
                                    serializer.Serialize(xmlWriter, Globalv.UserBulbs);
                                }
                            }
                        }
                        allOK = true;
                    }
                }//end if

                else if (device_type == "WHForm")
                {
                    XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                    xmlWriterSettings.Indent = true;

                    using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                    {
                        List<WH> temp = new List<WH>();
                        if (myIsolatedStorage.FileExists("WHs.xml"))
                        {
                            using (IsolatedStorageFileStream stream1 = new IsolatedStorageFileStream("WHs.xml", FileMode.Open, FileAccess.Read, myIsolatedStorage))
                            {
                                XmlSerializer serializer = new XmlSerializer(typeof(List<WH>));
                                temp = (List<WH>)serializer.Deserialize(stream1);
                            }


                            WH w = new WH
                            {
                                WH_rating = WH_rating.SelectedItem.ToString(),
                                WH_volume = Int32.Parse(WH_Volume.SelectedItem.ToString()),
                                WH_DailyUsage = Int32.Parse(Regex.Match(WH_DailyUsage.SelectedItem.ToString(), @"\d+").Value),
                                WH_MonthlyUsage = Int32.Parse(Regex.Match(WH_MonthlyUsage.SelectedItem.ToString(), @"\d+").Value)
                            };
                            w.Eval();
                            temp.Add(w);
                            Globalv.UserWHs = temp;
                        }
                        else
                        {
                            WH w = new WH
                            {
                                WH_rating = WH_rating.SelectedItem.ToString(),
                                WH_volume = Int32.Parse(WH_Volume.SelectedItem.ToString()),
                                WH_DailyUsage = Int32.Parse(Regex.Match(WH_DailyUsage.SelectedItem.ToString(), @"\d+").Value),
                                WH_MonthlyUsage = Int32.Parse(Regex.Match(WH_MonthlyUsage.SelectedItem.ToString(), @"\d+").Value)
                            };
                            w.Eval();
                            Globalv.UserWHs.Add(w);
                        }

                        using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("WHs.xml", FileMode.Create, myIsolatedStorage))
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(List<WH>));
                            using (XmlWriter xmlWriter = XmlWriter.Create(stream, xmlWriterSettings))
                            {
                                serializer.Serialize(xmlWriter, Globalv.UserWHs);
                            }
                        }
                    }
                }//end if

                else if (device_type == "TVForm")
                {
                    XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                    xmlWriterSettings.Indent = true;

                    using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                    {
                        List<TV> temp = new List<TV>();
                        if (myIsolatedStorage.FileExists("TVs.xml"))
                        {
                            using (IsolatedStorageFileStream stream1 = new IsolatedStorageFileStream("TVs.xml", FileMode.Open, FileAccess.Read, myIsolatedStorage))
                            {
                                XmlSerializer serializer = new XmlSerializer(typeof(List<TV>));
                                temp = (List<TV>)serializer.Deserialize(stream1);
                            }


                            TV t = new TV
                            {
                                TV_rating = TV_rating.SelectedItem.ToString(),
                                TV_type = TV_type.SelectedItem.ToString(),
                                TV_size = Int32.Parse(TV_size.SelectedItem.ToString()),
                                TV_DailyUsage = Int32.Parse(Regex.Match(TV_DailyUsage.SelectedItem.ToString(), @"\d+").Value),
                            };
                            t.Eval();
                            temp.Add(t);
                            Globalv.UserTVs = temp;
                        }
                        else
                        {
                            TV t = new TV
                                {
                                    TV_rating = TV_rating.SelectedItem.ToString(),
                                    TV_type = TV_type.SelectedItem.ToString(),
                                    TV_size = Int32.Parse(TV_size.SelectedItem.ToString()),
                                    TV_DailyUsage = Int32.Parse(Regex.Match(TV_DailyUsage.SelectedItem.ToString(), @"\d+").Value),
                                };
                            t.Eval();
                            Globalv.UserTVs.Add(t);

                        }
                        using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("TVs.xml", FileMode.Create, myIsolatedStorage))
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(List<TV>));
                            using (XmlWriter xmlWriter = XmlWriter.Create(stream, xmlWriterSettings))
                            {
                                serializer.Serialize(xmlWriter, Globalv.UserTVs);
                            }
                        }
                    }
                }//end if


                if (allOK)
                {
                    //MessageBox.Show("Device added successfully");
                    NavigationService.GoBack();
                }

            }//end save new
        }


    }
}