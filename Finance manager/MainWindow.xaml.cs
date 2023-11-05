using System;
using System.Collections.Generic;
using System.Drawing;
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
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace Finance_manager
{
    public partial class MainWindow : Window
    {
        ViewModel.ViewModel vm = new();

        public MainWindow(User user)
        {
            InitializeComponent();

            vm.CurrUser = user;
            

            #region Test
            foreach(var i in vm.CurrUser.Transactions.ToList())
            {
                Random rnd = new Random();
                myPieChart.Series.Add(new PieSeries
                {
                    Title = i.Category.Name,
                    Fill = vm.colors.OrderBy(x => rnd.Next()).FirstOrDefault(),
                    Values = new ChartValues<ObservableValue> { new ObservableValue(i.Sum) },
                    StrokeThickness = 5
                });
            } 
            #endregion
        }

        private void AddIncomeClick_Click(object sender, RoutedEventArgs e)
        {
            AddTransactionMenu menu = new(vm.CurrUser);
            menu.Title.Content = "New income";
            Navigator.NavigationService.Navigate(menu);
        }

        private void AddSpendsClick_Click(object sender, RoutedEventArgs e)
        {
            AddTransactionMenu menu = new(vm.CurrUser);
            menu.Title.Content = "New spend";
            menu.isCreditingtransaction = false;
            Navigator.NavigationService.Navigate(menu);
        }

        private void CategoryBtn_Click(object sender, RoutedEventArgs e)
        {
            CategoryWindow categoryWindow = new CategoryWindow();
            if (categoryWindow.ShowDialog() == true ) 
            {
                vm.SelectedText = categoryWindow.SelectegCateg;
            }
        }

        private void ToOpenHistory_Click(object sender, RoutedEventArgs e)
        {
            Hide();

            HistoryOfTransactions historyOfTransactions = new HistoryOfTransactions(vm.CurrUser);
            historyOfTransactions.ShowDialog();

            ShowDialog();
        }

        private void Chip_Click(object sender, RoutedEventArgs e)
        {
            ViewProfile vp = new ViewProfile(vm.CurrUser);
            
            Navigator.NavigationService.Navigate(vp);

        }
    }
}