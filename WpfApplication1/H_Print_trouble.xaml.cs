using System;
using System.Collections.Generic;
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
    /// Print_trouble.xaml 的交互逻辑
    /// </summary>
    public partial class H_Print_trouble : Window
    {
        public H_Print_trouble()
        {
            InitializeComponent();
        }
        public H_Print_trouble(string RT_s)
        {
            InitializeComponent();
            if (RT_s != "")
            {
                //this.d_bh.Text = RT_s.Split('$')[1].ToString();
                this.d_name.Text = RT_s.Split('$')[5].ToString();
                this.d_age.Text = RT_s.Split('$')[2].ToString();
                this.d_sex.Text = RT_s.Split('$')[3].ToString();
                this.d_sex1.Text = RT_s.Split('$')[4].ToString();
                this.d_birtday.Text = RT_s.Split('$')[5].ToString();
                int k = 1;
                for (int i = 6; i < RT_s.Split('$').Length; i++)
                {
                    if (RT_s.Split('$')[i].ToString() != "0")
                    {
                        (FindName("p" +k+"_"+ RT_s.Split('$')[i].ToString()) as TextBlock).Visibility =
                            System.Windows.Visibility.Visible;
                        
                    }
                    k++;
                }


                
            }
            
           
        }
    }
}
