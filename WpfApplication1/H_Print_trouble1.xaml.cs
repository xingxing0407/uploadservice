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
    public partial class H_Print_trouble1 : Window
    {
        public H_Print_trouble1()
        {
            InitializeComponent();
        }
        public H_Print_trouble1(string RT_sr)
        {
            InitializeComponent();
            if (RT_sr != "")
            {
                int k = 1;

                string[] RT_srs = RT_sr.Split('$');

                for (int i = 0; i < 10; i++)
                {
                    (FindName("p" + k + "_" + RT_srs[i]) as TextBlock).Visibility =
                         System.Windows.Visibility.Visible;
                    k++;
                }

                this.yx_value.Text = RT_srs[10];
                this.yinx_value.Text = RT_srs[11];
                this.qx_value.Text = RT_srs[12];
                this.ts_value.Text = RT_srs[13];
                this.sr_value.Text = RT_srs[14];
                this.xy_value.Text = RT_srs[15];
                this.tb_value.Text = RT_srs[16];
                this.qyu_value.Text = RT_srs[17];
                this.ph_value.Text = RT_srs[18];

                string time = RT_srs[19]; //System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                DateTime t = DateTime.Parse(time);
                this.year.Content = t.Year.ToString();
                this.month.Content = t.Month.ToString();
                this.day.Content = t.Day.ToString();
                this.reportDoc.Text = RT_srs[20];

                
                string qixu = RT_srs[21];
                string yangxu = RT_srs[22];
                string yinxu = RT_srs[23];
                string tanshi = RT_srs[24];
                string shire = RT_srs[25];
                string xueyu = RT_srs[26];
                string qiyu = RT_srs[27];
                string tebing = RT_srs[28];
                string pinghe = RT_srs[29];
                this.qixu_1.Visibility = System.Windows.Visibility.Hidden;
                this.qixu_2.Visibility = System.Windows.Visibility.Hidden;
                this.yangxu_1.Visibility = System.Windows.Visibility.Hidden;
                this.yangxu_2.Visibility = System.Windows.Visibility.Hidden;
                this.yinxu_1.Visibility = System.Windows.Visibility.Hidden;
                this.yinxu_2.Visibility = System.Windows.Visibility.Hidden;
                this.tanshi_1.Visibility = System.Windows.Visibility.Hidden;
                this.tanshi_2.Visibility = System.Windows.Visibility.Hidden;
                this.shire_1.Visibility = System.Windows.Visibility.Hidden;
                this.shire_2.Visibility = System.Windows.Visibility.Hidden;
                this.xueyu_1.Visibility = System.Windows.Visibility.Hidden;
                this.xueyu_2.Visibility = System.Windows.Visibility.Hidden;
                this.qiyu_1.Visibility = System.Windows.Visibility.Hidden;
                this.qiyu_2.Visibility = System.Windows.Visibility.Hidden;
                this.tebing_1.Visibility = System.Windows.Visibility.Hidden;
                this.tebing_2.Visibility = System.Windows.Visibility.Hidden;
                this.pinghe_1.Visibility = System.Windows.Visibility.Hidden;
                this.pinghe_2.Visibility = System.Windows.Visibility.Hidden;
                if (qixu == "SX0088_1") this.qixu_1.Visibility = System.Windows.Visibility.Visible;
                else if (qixu == "SX0088_2") this.qixu_2.Visibility = System.Windows.Visibility.Visible;

                if (yangxu == "SX0088_1") this.yangxu_1.Visibility = System.Windows.Visibility.Visible;
                else if (yangxu == "SX0088_2") this.yangxu_2.Visibility = System.Windows.Visibility.Visible;

                if (yinxu == "SX0088_1") this.yinxu_1.Visibility = System.Windows.Visibility.Visible;
                else if (yinxu == "SX0088_2") this.yinxu_2.Visibility = System.Windows.Visibility.Visible;

                if (tanshi == "SX0088_1") this.tanshi_1.Visibility = System.Windows.Visibility.Visible;
                else if (tanshi == "SX0088_2") this.tanshi_2.Visibility = System.Windows.Visibility.Visible;

                if (shire == "SX0088_1") this.shire_1.Visibility = System.Windows.Visibility.Visible;
                else if (shire == "SX0088_2") this.shire_2.Visibility = System.Windows.Visibility.Visible;

                if (xueyu == "SX0088_1") this.xueyu_1.Visibility = System.Windows.Visibility.Visible;
                else if (xueyu == "SX0088_2") this.xueyu_2.Visibility = System.Windows.Visibility.Visible;

                if (qiyu == "SX0088_1") this.tebing_1.Visibility = System.Windows.Visibility.Visible;
                else if (qiyu == "SX0088_2") this.tebing_2.Visibility = System.Windows.Visibility.Visible;

                if (tebing == "SX0088_1") this.qiyu_1.Visibility = System.Windows.Visibility.Visible;
                else if (tebing == "SX0088_2") this.qiyu_2.Visibility = System.Windows.Visibility.Visible;

                if (pinghe == "SX0401_1") this.pinghe_1.Visibility = System.Windows.Visibility.Visible;
                else if (pinghe == "SX0401_2") this.pinghe_2.Visibility = System.Windows.Visibility.Visible;

              

            }
        }
    }
}
