using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace WpfApplication1
{
  public  class GridHelper
    {
        //边框的宽度
        static double myBorderWidth = 1;

        public static double GetBorderWidth(DependencyObject obj)
        {
            return (double)obj.GetValue(BorderWidthProperty);
        }

        public static void SetBorderWidth(DependencyObject obj, double value)
        {
            obj.SetValue(BorderWidthProperty, value);
        }

        public static readonly DependencyProperty BorderWidthProperty =
            DependencyProperty.RegisterAttached("BorderWidth", typeof(double), typeof(GridHelper), new PropertyMetadata(OnBorderWidthChanged));

        private static void OnBorderWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            myBorderWidth = (double)e.NewValue;
        }

        public static bool GetShowBorder(DependencyObject obj)
        {
            return (bool)obj.GetValue(ShowBorderProperty);
        }

        public static void SetShowBorder(DependencyObject obj, bool value)
        {
            obj.SetValue(ShowBorderProperty, value);
        }

        public static readonly DependencyProperty ShowBorderProperty =
            DependencyProperty.RegisterAttached("ShowBorder", typeof(bool), typeof(GridHelper), new PropertyMetadata(OnShowBorderChanged));

        //这是一个事件处理程序，需要手工编写，必须是静态方法
        private static void OnShowBorderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var grid = d as Grid;
            if ((bool)e.OldValue)
            {
                grid.Loaded -= (s, arg) => { };
            }
            if ((bool)e.NewValue)
            {
                grid.Loaded += (s, arg) =>
                {
                    //根据Grid的顶层子控件的个数去添加边框，同时考虑合并的情况
                    var controls = grid.Children;
                    var count = controls.Count;
                    for (int i = 0; i < count; i++)
                    {
                        var item = controls[i] as FrameworkElement;
                        var row = Grid.GetRow(item);
                        var column = Grid.GetColumn(item);
                        var rowspan = Grid.GetRowSpan(item);
                        var columnspan = Grid.GetColumnSpan(item);

                        //设置边框线的颜色
                        var border = new Border();
                        border.BorderBrush = new SolidColorBrush(Colors.White);

                        if (row == grid.RowDefinitions.Count - 1 && column == grid.ColumnDefinitions.Count - 1)
                            border.BorderThickness = new Thickness(myBorderWidth);
                        else if (row == grid.RowDefinitions.Count - 1)
                            border.BorderThickness = new Thickness(myBorderWidth, myBorderWidth, 0, 0);
                        else if (column == grid.ColumnDefinitions.Count - 1)
                            border.BorderThickness = new Thickness(myBorderWidth, myBorderWidth, myBorderWidth, 0);
                        else
                            border.BorderThickness = new Thickness(myBorderWidth, myBorderWidth, 0, 0);

                        Grid.SetRow(border, row);
                        Grid.SetColumn(border, column);
                        Grid.SetRowSpan(border, rowspan);
                        Grid.SetColumnSpan(border, columnspan);
                        grid.Children.Add(border);
                    }
                };
            }
        }


    }
}
