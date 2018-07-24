using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Diagnostics;
using System.Xml;

namespace WpfApplication1
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public static string ipaddress = "";
        public static string strport = "";
        public static string strservicename = "";
        public static string userid = "";
        public static string pwd = "";
        public App()
      {

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Result/config.xml");
            XmlNode xn = xmlDoc.SelectSingleNode("items");
            foreach (XmlNode xn1 in xn)
            {
                if (xn1.Name == "ipaddress")
                {
                    ipaddress = xn1.InnerXml;
                }
                if (xn1.Name == "strport")
                {
                    strport = xn1.InnerXml;
                }
                if (xn1.Name == "strservicename")
                {
                    strservicename = xn1.InnerXml;
                }
                if (xn1.Name == "userid")
                {
                    userid = xn1.InnerXml;
                }
                if (xn1.Name == "pwd")
                {
                    pwd = xn1.InnerXml;
                }
            }
        }
}  
    
}
