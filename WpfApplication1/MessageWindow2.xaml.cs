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
    /// MessageWindow2.xaml 的交互逻辑
    /// </summary>
    public partial class MessageWindow2 : Window
    {
        public MessageWindow2()
        {
            InitializeComponent();
        }

        private void bt_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
        public string Message
        {
            get { return this.lblMsg.Text; }
            set { this.lblMsg.Text = value; }
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
            var msgBox = new MessageWindow2();
            msgBox.Message = msg;
            msgBox.ShowInTaskbar = false;
            return msgBox.ShowDialog();
        }

        private void MessageWindowKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.DialogResult = true;
                this.Close();
            }
        }

    }
}
