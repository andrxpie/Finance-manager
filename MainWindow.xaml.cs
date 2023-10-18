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

            #region Test
            //myPieChart.Series.Add(new PieSeries { Title = "1", Fill = Brushes.Red, StrokeThickness = 0, Values = new ChartValues<double> { 10.0 } });
            //myPieChart.Series.Add(new PieSeries { Title = "2", Fill = Brushes.AliceBlue, StrokeThickness = 0, Values = new ChartValues<double> { 10.0 } });
            //myPieChart.Series.Add(new PieSeries { Title = "2", Fill = Brushes.Black, StrokeThickness = 0, Values = new ChartValues<double> { 10.0 } });
            //myPieChart.Series.Add(new PieSeries { Title = "3", Fill = Brushes.Yellow, StrokeThickness = 0, Values = new ChartValues<double> { 10.0 } });
            //myPieChart.Series.Add(new PieSeries { Title = "4", Fill = Brushes.Tomato, StrokeThickness = 0, Values = new ChartValues<double> { 10.0 } });
            //myPieChart.Series.Add(new PieSeries { Title = "5", Fill = Brushes.Purple, StrokeThickness = 0, Values = new ChartValues<double> { 25.0 } });
            //myPieChart.Series.Add(new PieSeries { Title = "6", Fill = Brushes.Orange, StrokeThickness = 0, Values = new ChartValues<double> { 25.0 } });
            #endregion

            DataContext = this;
        }
    }
}
