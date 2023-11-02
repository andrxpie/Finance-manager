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
        User currUser;
        private string login;

        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(string l)
        {
            this.login = l;
        }
        public MainWindow(User user)
        {
            InitializeComponent();

            currUser = user;

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


        private void AddIncomeClick_Click(object sender, RoutedEventArgs e)
        {
            AddTransactionMenu menu = new(currUser);
            menu.Title.Content = "New income";
            NavigateToAddPage.NavigationService.Navigate(menu);

        }

        private void AddSpendsClick_Click(object sender, RoutedEventArgs e)
        {
            AddTransactionMenu menu = new(currUser);
            menu.Title.Content = "New spend";
            menu.isCreditingtransaction = false;
            NavigateToAddPage.NavigationService.Navigate(menu);

        }


        private void ToOpenHistory_Click(object sender, RoutedEventArgs e)
        {
            HistoryOfTransactions historyOfTransactions = new HistoryOfTransactions(currUser);
            this.Close();
            historyOfTransactions.Show();
        }
    }
}
