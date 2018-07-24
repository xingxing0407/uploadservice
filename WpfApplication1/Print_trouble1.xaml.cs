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
    public partial class Print_trouble1 : Window
    {
        public Print_trouble1()
        {
            InitializeComponent();
        }
        public Print_trouble1(string RT_sr)
        {
            InitializeComponent();
            if (RT_sr != "")
            {
                int k = 1;
                for (int i = 0; i < 10; i++)
                {
                    (FindName("p" + k + "_" + RT_sr.Split('$')[i].ToString()) as TextBlock).Visibility =
                         System.Windows.Visibility.Visible;
                    k++;
                }

                this.yx_value.Text = RT_sr.Split('$')[10].ToString();
                this.yinx_value.Text = RT_sr.Split('$')[11].ToString();
                this.qx_value.Text = RT_sr.Split('$')[12].ToString();
                this.ts_value.Text = RT_sr.Split('$')[13].ToString();
                this.sr_value.Text = RT_sr.Split('$')[14].ToString();
                this.xy_value.Text = RT_sr.Split('$')[15].ToString();
                this.tb_value.Text = RT_sr.Split('$')[16].ToString();
                this.qyu_value.Text = RT_sr.Split('$')[17].ToString();
                this.ph_value.Text = RT_sr.Split('$')[18].ToString();
            }
        }
    }
}
