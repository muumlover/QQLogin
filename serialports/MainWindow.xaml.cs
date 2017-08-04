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
using System.Windows.Threading;

namespace serialports
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            init_ShowPage();
        }

        void init_ShowPage()
        {
            Rectangle rectangle = new Rectangle();//矩形对象
                                                  //属性设置，填充颜色、边粗细、边颜色、宽、高等
            rectangle.Fill = System.Windows.Media.Brushes.Blue;
            rectangle.StrokeThickness = 4;
            rectangle.Stroke = System.Windows.Media.Brushes.Pink; //边，粉色
            rectangle.Width = 80;
            rectangle.Height = 200;
            //矩形对象相对于父容器对象Canvas的位置，左边距、上边距
            Canvas.SetLeft(rectangle, 260);
            Canvas.SetTop(rectangle, 80);
            this.canvPly.Children.Add(rectangle);

            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = TimeSpan.FromMilliseconds(10);   //设置刷新的间隔时间
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            double x = Canvas.GetLeft(this.canvPly.Children[0]);//获取当前高度
            if (x > 180) x = 80;
            Canvas.SetLeft(this.canvPly.Children[0], x + 1);
        }

        private void windows_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}
