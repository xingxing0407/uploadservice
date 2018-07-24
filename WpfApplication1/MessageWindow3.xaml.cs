using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;

namespace WpfApplication1
{
    /// <summary>
    /// MessageWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MessageWindow3 : Window
    {
        public MessageWindow3()
        {
            InitializeComponent();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Result/config.xml");
            XmlNode xn = xmlDoc.SelectSingleNode("items");
            foreach (XmlNode xn1 in xn)
            {
                if (xn1.Name == "bbh")
                {
                    Label1.Content = xn1.InnerXml;
                }
                if (xn1.Name == "szdy")
                {
                    if (xn1.InnerXml == "1")
                    {
                        this.rbtnZdjzYes.IsChecked = true;
                    }
                    else
                    {
                        this.rbtnZdjzNo.IsChecked = true;
                    }
                }
                if (xn1.Name == "gsmc")
                {
                    this.tbgsName.Text = xn1.InnerXml;
                }
            }
            
        }

      

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        /// <summary>
        /// 静态方法 模拟MESSAGEBOX.Show方法
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="msg">消息</param>
        /// <returns></returns>
        public static bool? Show(string msg)
        {
            var msgBox = new MessageWindow1();
            msgBox.Message = msg;
            msgBox.ShowInTaskbar = false;
            return msgBox.ShowDialog();
        }
        
        private void bt_YesClick(object sender, RoutedEventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Result/config.xml");
            XmlNode xn = xmlDoc.SelectSingleNode("items");
            foreach (XmlNode xn1 in xn)
            {
                if (xn1.Name == "szdy")
                {
                    if (this.rbtnZdjzYes.IsChecked ==true)
                    {
                        xn1.InnerXml = "1";
                    }
                    else
                    {
                        xn1.InnerXml = "0";
                    }
                }
                if (xn1.Name == "gsmc")
                {
                    xn1.InnerText = this.tbgsName.Text;
                }
            }
            xmlDoc.Save("Result/config.xml");//保存。 
            this.Close();
        }

        private void bt_NoClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void MessageWindowKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.DialogResult = true;
                this.Close();
            }
            else if (e.Key == Key.Escape)
            {
                this.DialogResult = false;
                this.Close();
            }
        }

        private void cb_MedicalNo(object sender, RoutedEventArgs e)
        {
            //PCKeyboard.OpenScreenKeyboard(this.tb_MedicalNo);
            Process[] myproc = Process.GetProcesses();
            foreach (Process item in myproc)
            {
                if (item.ProcessName.Contains("osk"))
                {
                    item.Kill();
                }
            }
            Process.Start(@"osk.exe");
        }

        private void Updats_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog ofld = new System.Windows.Forms.OpenFileDialog();
            ofld.Title = "请选择上传的图片";
            //设置筛选的图片格式  
            ofld.Filter = "图片格式(*.jpg)|*.jpg|图片格式(*.png)|*.png";
            //设置是否允许多选  
            ofld.Multiselect = false;
            if (ofld.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string text = ofld.FileName;
                if (text != "" || text != null)
                {
                    this.tbPath.Text = text;
                    int position = text.LastIndexOf("\\");
                    string fileName = text.Substring(position + 1);
                    if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"Temp\"))
                    {
                        Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"Temp\");
                    }
                    string tempFileName = AppDomain.CurrentDomain.BaseDirectory + @"Temp\" + "logo" + ".png";
                    try
                    {
                        File.Delete(tempFileName);

                        File.Copy(this.tbPath.Text, tempFileName, true);
                    }
                    catch (Exception)
                    {
                        MessageWindow2.Show("图标文件需要在打印前设置");
                    }
                }

            }
        }
    }


}
