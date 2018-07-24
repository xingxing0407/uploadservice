using System;
using System.Collections.Generic;
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

namespace WpfApplication1
{
    /// <summary>
    /// Print_trouble.xaml 的交互逻辑
    /// </summary>
    public partial class Print_trouble : Window
    {
        public Print_trouble()
        {
            InitializeComponent();
        }
        public Print_trouble(string RT_s)
        {
            InitializeComponent();
            if (RT_s != "")
            {
                this.d_blh.Text = RT_s.Split('$')[0].ToString();
                this.d_name.Text = RT_s.Split('$')[1].ToString();
                this.d_age.Text = RT_s.Split('$')[2].ToString();
                this.d_sex.Text = RT_s.Split('$')[3].ToString();
                int k = 1;
                for (int i = 4; i < RT_s.Split('$').Length; i++)
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
