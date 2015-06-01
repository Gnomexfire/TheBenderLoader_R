using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;
using MahApps.Metro.Controls;
using BenderLoader;
using BenderLoader.Class;

namespace BenderLoader.View
{
    /// <summary>
    /// Interaction logic for Config.xaml
    /// </summary>
    public partial class Config : MetroWindow
    {
        public static int FlagNotice, FlagMin;

        public Config()
        {
            InitializeComponent();
        }

        

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Helper.LoadConfigFile();
            // Check Language
            switch (MainWindow.DefaultLanguage)
            {
                case "pt":
                    ComboBox.SelectedIndex = 0;
                    break;

                case "en":
                    ComboBox.SelectedIndex = 1;
                    break;

                case "fr":
                    ComboBox.SelectedIndex = 2;
                    break;

                case "ko":
                    ComboBox.SelectedIndex = 3;
                    break;


            }

            // Update Display
            LblSelIdioma.Content = MainWindow.XTranslate.LblSelIdioma;
            ChkMinInject.Content = MainWindow.XTranslate.ChkMinInject;
            ChkNotInject.Content = MainWindow.XTranslate.ChkNotInject;
            CmdConfirmar.Content = MainWindow.XTranslate.CmdConfirmar;
            TUpdateManual.Text = MainWindow.XTranslate.TUpdateManual;

            if (FlagNotice == 1)
            {
                ChkNotInject.IsChecked = true;
            }
            if (FlagMin == 1)
            {
                ChkMinInject.IsChecked = true;
            }
        }


        private void CmdConfirmar_Click(object sender, RoutedEventArgs e)
        {
           
            string lPar = String.Empty;
            int nPar, mPar;
            

            switch (ComboBox.SelectedIndex)
            {
                case 0:
                    if (MainWindow.DefaultLanguage != "pt")
                    {
                        lPar = "pt";
                        if (ChkNotInject.IsChecked != null && ChkNotInject.IsChecked.Value)
                        {
                            nPar = 1;
                        }
                        else
                        {
                            nPar = 0;
                        }

                        if (ChkMinInject.IsChecked != null && ChkMinInject.IsChecked.Value)
                        {
                            mPar = 1;
                        }
                        else
                        {
                            mPar = 0;
                        }
                        SalveXml(lPar, nPar, mPar, true);
                    }
                        break;

                case 1:
                    if (MainWindow.DefaultLanguage != "en")
                    {
                        lPar = "en";
                        if (ChkNotInject.IsChecked != null && ChkNotInject.IsChecked.Value)
                        {
                            nPar = 1;
                        }
                        else
                        {
                            nPar = 0;
                        }

                        if (ChkMinInject.IsChecked != null && ChkMinInject.IsChecked.Value)
                        {
                            mPar = 1;
                        }
                        else
                        {
                            mPar = 0;
                        }
                        SalveXml(lPar, nPar,mPar,true);
                    }
                 break;

                case 2:
                    if (MainWindow.DefaultLanguage != "fr")
                    {
                        lPar = "fr";
                        if (ChkNotInject.IsChecked != null && ChkNotInject.IsChecked.Value)
                        {
                            nPar = 1;
                        }
                        else
                        {
                            nPar = 0;
                        }

                        if (ChkMinInject.IsChecked != null && ChkMinInject.IsChecked.Value)
                        {
                            mPar = 1;
                        }
                        else
                        {
                            mPar = 0;
                        }
                        SalveXml(lPar, nPar, mPar, true);
                    }
                 break;

                case 3:
                    if (MainWindow.DefaultLanguage != "ko")
                    {
                        lPar = "ko";
                        if (ChkNotInject.IsChecked != null && ChkNotInject.IsChecked.Value)
                        {
                            nPar = 1;
                        }
                        else
                        {
                            nPar = 0;
                        }

                        if (ChkMinInject.IsChecked != null && ChkMinInject.IsChecked.Value)
                        {
                            mPar = 1;
                        }
                        else
                        {
                            mPar = 0;
                        }
                        SalveXml(lPar, nPar, mPar, true);
                    }
                 break;
            }

            lPar = MainWindow.DefaultLanguage;
            if (ChkNotInject.IsChecked != null && ChkNotInject.IsChecked.Value)
            {
                nPar = 1;
            }
            else
            {
                nPar = 0;
            }

            if (ChkMinInject.IsChecked != null && ChkMinInject.IsChecked.Value)
            {
                mPar = 1;
            }
            else
            {
                mPar = 0;
            }

            SalveXml(lPar, nPar, mPar, true);
        }
        
        void SalveXml(string langPar, int noticePar, int miniPar, bool tosPar)
        {
            var x = new XmlDocument();
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\\Conf.xml"))
            {
                MainWindow.DefaultLanguage = langPar;
                x.Load(AppDomain.CurrentDomain.BaseDirectory + @"\\Conf.xml");
                if (x.DocumentElement != null)
                {
                    var l = x.DocumentElement.SelectNodes("/Conf");
                    if (l != null)
                    {
                        foreach (XmlNode n in l)
                        {
                            var s = n.SelectSingleNode("LanguageDefault");
                            if (s != null)
                            {
                                s.InnerText = langPar;
                            }

                            s = n.SelectSingleNode("NoticeInject");
                            if (s != null)
                            {
                                s.InnerText = noticePar.ToString();
                            }


                            s = n.SelectSingleNode("MinimizarInject");
                            if (s != null)
                            {
                                s.InnerText = miniPar.ToString();
                            }

                            s = n.SelectSingleNode("Tos");
                            if (s != null)
                            {
                                s.InnerText = tosPar.ToString();
                            }

                            s = n.SelectSingleNode("RiotGamePatch");
                            if (s != null)
                            {
                                s.InnerText = s.InnerText;
                            }
                        }
                    }
                }
            // Save File
                x.Save(AppDomain.CurrentDomain.BaseDirectory + @"\\Conf.xml");
                Close();
            }
        }
    }
}
