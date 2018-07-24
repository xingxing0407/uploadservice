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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Diagnostics;

namespace WpfApplication1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        static public int IsSaveOrAlter;//判断是保存Or编辑；0保存，1修改
        public MainWindow()
        {
            InitializeComponent();
            UserInforShowPage uisp = new UserInforShowPage();
            uisp.Show();
            this.Hide();
        }

        //public static TabControlPage tbcp = new TabControlPage();
        //UserInforShowPage uisp = new UserInforShowPage();
        //public static MainWindow mw = new MainWindow();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //if (MessageWindow1.Show("确定要退出吗？") == true)
            //{
            //    System.Environment.Exit(System.Environment.ExitCode);

            //}
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)  
        {
            //if (e.LeftButton == MouseButtonState.Pressed)
            //{
            //    DragMove();
            //}
        }


        private void bt_UserInforInterClick(object sender, RoutedEventArgs e)
        {
            //tbcp.Left = this.Left;
            //tbcp.Top = this.Top;
         
            //tbcp.qweas.Text = this.tb_MedicalNo.Text;
            //IsSaveOrAlter = 0;
            //tbcp.Show();
            //this.Hide();
        }

        private void bt_UserInforShow(object sender, RoutedEventArgs e)
        {
            //if (tb_MedicalNo.Text == "admin")
            //{
            //    uisp.bt_DeleteUserinfor.Visibility = System.Windows.Visibility.Visible;
            //}
            //else
            //{
            //    uisp.bt_DeleteUserinfor.Visibility = System.Windows.Visibility.Hidden;
            //}
            //uisp.Left = this.Left;
            //uisp.Top = this.Top;
            //uisp.qsxe.Text = tb_MedicalNo.Text;
            //uisp.Show();
            //this.Hide();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //double dHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            //double dWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            //uisp.TabPage = tbcp;
            //Thickness thick = new Thickness(dWidth/5.5, dHeight / 4, -27, 57);
            //Thickness thick1 = new Thickness(dWidth /5, dHeight / 3.5, -27, 57);
            //this.wrps.Margin = thick;
            //this.wrps1.Margin = thick1;
        }

        private void bt_MinsizeClicked(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //MessageWindow3 Mwindow3 = new MessageWindow3();
            //if (Mwindow3.ShowDialog() == true)
            //{
            //    Mwindow3.Show();
            //}
            //  Mwindow3.Show();
        }
       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //UserInforShowPage U_show = new UserInforShowPage();
            //TabControlPage T_page=new TabControlPage();

            //if (tb_MedicalNo.Text == "admin" && tb_MedicalNo1.Password == "admin")
            //{
            //    wrps.Visibility = System.Windows.Visibility.Visible;
            //    wrps1.Visibility = System.Windows.Visibility.Hidden;
            //    uisp.bt_DeleteUserinfor.Visibility = System.Windows.Visibility.Visible;
            //    U_show.qsxe.Text = "admin";
            //    T_page.qweas.Text = "admin";
              

            //}
            //else if (tb_MedicalNo.Text == "guest" && tb_MedicalNo1.Password == "guest")
            //{
            //    wrps.Visibility = System.Windows.Visibility.Visible;
            //    wrps1.Visibility = System.Windows.Visibility.Hidden;
            //    uisp.bt_DeleteUserinfor.Visibility = System.Windows.Visibility.Hidden;
            //    U_show.qsxe.Text = "guest";
            //    T_page.qweas.Text = "guest";
             
            //}
            //else
            //{
            //    TS_label.Visibility = System.Windows.Visibility.Visible;
            //    return;
            //}
        }

        private void cb_PassWd(object sender, RoutedEventArgs e)
        {
            //PCKeyboard.OpenScreenKeyboard(this.tb_MedicalNo);
            //Process[] myproc = Process.GetProcesses();
            //foreach (Process item in myproc)
            //{
            //    if (item.ProcessName.Contains("osk"))
            //    {
            //        item.Kill();
            //    }
            //}
            //Process.Start(@"osk.exe");
        }

        private void mainwindow_closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void tb_MedicalNo1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Key == Key.Enter)
            //{
            //    this.Button_Click_1(null, null);
            //}
        }
    }
}
