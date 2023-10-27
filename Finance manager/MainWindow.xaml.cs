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
    public partial class MainWindow : Window
    {
        ViewModel.ViewModel vm = new();
        User currUser;
        private string login;
        public string SelectegCateg { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            if (SelectegCateg != null)
            {
                vm.SelectedText = SelectegCateg;
            }
            this.DataContext = vm;
        }
        public MainWindow(string l)
        {
            this.login = l;
        }
        public MainWindow(User user)
        {
            InitializeComponent();

            user = currUser;

            #region Test
            myPieChart.Series.Add(new PieSeries { Title = "1", Fill = Brushes.Red, StrokeThickness = 5, Values = new ChartValues<double> { 10.0 } });
            myPieChart.Series.Add(new PieSeries { Title = "2", Fill = Brushes.AliceBlue, StrokeThickness = 5, Values = new ChartValues<double> { 10.0 } });
            myPieChart.Series.Add(new PieSeries { Title = "2", Fill = Brushes.Black, StrokeThickness = 5, Values = new ChartValues<double> { 10.0 } });
            myPieChart.Series.Add(new PieSeries { Title = "3", Fill = Brushes.Yellow, StrokeThickness = 5, Values = new ChartValues<double> { 10.0 } });
            myPieChart.Series.Add(new PieSeries { Title = "4", Fill = Brushes.Tomato, StrokeThickness = 5, Values = new ChartValues<double> { 10.0 } });
            myPieChart.Series.Add(new PieSeries { Title = "5", Fill = Brushes.Purple, StrokeThickness = 5, Values = new ChartValues<double> { 25.0 } });
            myPieChart.Series.Add(new PieSeries { Title = "6", Fill = Brushes.Orange, StrokeThickness = 5, Values = new ChartValues<double> { 25.0 } });

            #endregion

            DataContext = this;
        }


        private void CategoryBtn_Click(object sender, RoutedEventArgs e)
        {
            CategoryWindow categoryWindow = new CategoryWindow();
            if (categoryWindow.ShowDialog() == true ) 
            {
                vm.SelectedText = categoryWindow.SelectegCateg;
            }
        }
    }
}