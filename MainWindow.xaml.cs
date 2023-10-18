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
using LiveCharts;
using LiveCharts.Wpf;

namespace Finance_manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            myPieChart.Series.Add(new PieSeries { Title = "BAD", Fill = Brushes.Red, StrokeThickness = 0, Values = new ChartValues<double> { 90.0 } });
            myPieChart.Series.Add(new PieSeries { Title = "GOOD", Fill = Brushes.Green, StrokeThickness = 0, Values = new ChartValues<double> { 10.0 } });

            DataContext = this;
        }
    }
}
