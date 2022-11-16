using DeepZoom.Marks.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Joysola.DeepZoom
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var xx = can.Children[0] as RectangleMark;
            xx.MSIStartPoint = new Point(517, 342);
            xx.MSIEndPoint = new Point(837, 545);
            xx.UpdateShape();
            //can.Loaded += (s, e) =>
            //{
            //    xx.Loaded += (x, y) =>
            //    {
            //    };
            //};

        }
    }
}
