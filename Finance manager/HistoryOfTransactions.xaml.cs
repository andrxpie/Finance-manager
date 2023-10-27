using Data_access.Repositories;
using Data_access;
using Data_access.Interfaces;
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
using System.Windows.Shapes;
using Finance_manager.Migrations;

namespace Finance_manager
{
    public partial class HistoryOfTransactions : Window
    {
        private IUoW uow = new UnitOfWork();
        User currentUser;
        public HistoryOfTransactions(User user)
        {
            InitializeComponent();
            currentUser = user;
            historyView.ItemsSource = uow.TransactionRepo.Get(x => x.User.Login == user.Login, includeProperties: "Category").Select(x => new
            {
                x.Id, 
                Category = x.Category.Name,
                Sum = x.Sum, 
                Date = x.DateTime
            });
            uow.Save();
        }

        private void BackToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(currentUser);
            this.Close();
            mainWindow.Show();
        }
    }
}
