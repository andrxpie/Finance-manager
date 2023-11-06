using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
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
using System.Windows.Shell;
using Data_access.Repositories;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace Finance_manager
{
    public partial class MainWindow : Window
    {
        private ViewModel.ViewModel vm = new();
        private string login;
        private IUoW uoW = new UnitOfWork();
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

        public MainWindow(User user)
        {
            InitializeComponent();

            vm.CurrUser = user;

            List<Transaction> list = uoW.TransactionRepo.Get(x => x.User.Login == vm.CurrUser.Login, includeProperties: "Category").ToList();

            Dictionary<string, int> categorysumpair = new Dictionary<string, int>();

            foreach(var i in uoW.CategoryRepo.Get().Where(x => x.Transactions != null).ToList())
            {
                categorysumpair.Add(i.Name, list.Where(x => x.Category.Name == i.Name).Sum(x => x.Sum));
            }

            #region Test
            if (vm.CurrUser.Transactions != null)
            {
                foreach (var i in categorysumpair)
                {
                    myPieChart.Series.Add(new PieSeries
                    {
                        Title = i.Key + " - " + i.Value,
                        Fill = vm.colors[new Random().Next(0, vm.colors.Length)],
                        Values = new ChartValues<ObservableValue> { new ObservableValue(i.Value) },
                        StrokeThickness = 5
                    });
                }
            }
            #endregion

            //Image.Source = new BitmapImage(new Uri($"{vm.CurrUser.AvatarPicture}", UriKind.Absolute));

            this.DataContext = vm;
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