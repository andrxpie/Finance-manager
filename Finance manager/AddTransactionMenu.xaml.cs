using Data_access.Repositories;
using Finance_manager.Migrations;
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

namespace Finance_manager
{
    /// <summary>
    /// Interaction logic for AddTransactionMenu.xaml
    /// </summary>
    public partial class AddTransactionMenu : Page
    {
        User currUser = new();
        UnitOfWork Uow = new UnitOfWork();

        public bool isCreditingtransaction = true;

        public AddTransactionMenu(User user)
        {
            InitializeComponent();
            CategoriesList.ItemsSource = Uow.CategoryRepo.Get().Select(x => x.Name);
            currUser = user;
        }
        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(null);
        }

        private void Button_Click(object sender, RoutedEventArgs e) => ValueToEnter.Text += ((Button)sender).Content;

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            if(ValueToEnter.Text.Length != 0)
            ValueToEnter.Text = ValueToEnter.Text.Substring(0, ValueToEnter.Text.Length - 1);
        }

        private void AcceptBtn_Click(object sender, RoutedEventArgs e)
        {
            if (isCreditingtransaction == true)
            {
                Uow.TransactionRepo.Insert(new Transaction()
                {
                    Sum = Convert.ToInt32(ValueToEnter.Text),
                    UserId = currUser.Id,
                    DateTime = new DateTime(datePicker.SelectedDate.Value.Year, datePicker.SelectedDate.Value.Month, datePicker.SelectedDate.Value.Day),
                    IsCrediting = true
                });
                Uow.Save();
            }
            else
            {
                Uow.TransactionRepo.Insert(new Transaction()
                {
                    Sum = Convert.ToInt32(ValueToEnter.Text),
                    UserId = currUser.Id,
                    DateTime = new DateTime(datePicker.SelectedDate.Value.Year, datePicker.SelectedDate.Value.Month, datePicker.SelectedDate.Value.Day),
                    IsCrediting = false
                });
                Uow.Save();
            }
        }
    }
}

