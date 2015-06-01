using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using  System.Reflection;
using System.Resources;
using System.Xml;
using BenderLoader.View;

namespace BenderLoader.Class
{
    public static  class Helper 
    {



        public static void LoadConfigFile()
        {
            
            var file = File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\\Conf.xml");
            if (!file)
            {
                // Não existe . . .
            }
            else
            {
                try
                {
                    var xml = new XmlDocument();
                    xml.Load(AppDomain.CurrentDomain.BaseDirectory + @"\\Conf.xml");
                    if (xml.DocumentElement != null)
                    {
                        var l = xml.DocumentElement.SelectNodes("/Conf");
                        if (l != null)
                        {
                            foreach (XmlNode n in l)
                            {
                                var s = n.SelectSingleNode("LanguageDefault");
                                if (s != null)
                                {
                                    MainWindow.DefaultLanguage = s.InnerText;
                                }

                                s = n.SelectSingleNode("NoticeInject");
                                if (s != null)
                                {
                                    Config.FlagNotice = int.Parse(s.InnerText);
                                }

                                s = n.SelectSingleNode("MinimizarInject");
                                if (s != null)
                                {
                                    Config.FlagMin = int.Parse(s.InnerText);
                                }

                                s = n.SelectSingleNode("Tos");
                                if (s != null)
                                {
                                    
                                }

                                s = n.SelectSingleNode("RiotGamePatch");
                                if (s != null)
                                {
                                    
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + System.Environment.NewLine +
                                      e.StackTrace);
                }
                
            }
        }
       
       

        


    }
}

