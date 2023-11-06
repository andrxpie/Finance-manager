using Data_access.Repositories;
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
    public partial class AddTransactionMenu : Page
    {
        private ViewModel.ViewModel vm = new();
        private static User currUser = new();
        private static UnitOfWork Uow = new UnitOfWork();
        public bool isCreditingtransaction = true;

        private IEnumerable<Category> categories = Uow.CategoryRepo.Get();

        public AddTransactionMenu(User user)
        {
            InitializeComponent();
            CategoriesList.ItemsSource = categories;
            currUser = user;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(null);
        }

        private void Button_Click(object sender, RoutedEventArgs e) => ValueToEnter.Text += ((Button)sender).Content;

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            ValueToEnter.Text = "";
        }

        private void AcceptBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValues() == true)
            {
                Transaction transaction = new Transaction()
                {
                    Sum = Convert.ToInt32(ValueToEnter.Text),
                    UserId = currUser.Id,
                    DateTime = new DateTime(datePicker.SelectedDate.Value.Year, datePicker.SelectedDate.Value.Month, datePicker.SelectedDate.Value.Day),
                    CategoryId = categories.Where(x => x.Name == ((Category)CategoriesList.SelectedItem).Name).Select(x => x.Id).FirstOrDefault()
                };
                BalanceUpdateAsync(currUser, Convert.ToInt32(ValueToEnter.Text));
                
                if (isCreditingtransaction == true)
                    transaction.IsCrediting = true;

                else transaction.IsCrediting = false;
                Uow.TransactionRepo.Insert(transaction);

                Uow.Save();
            }
        }
        private async Task BalanceUpdateAsync(User user, int amount)
        {
            try
            {
                currUser.Balance += amount;
                vm.CurrUser = user;
            }
            catch
            {
                MessageBox.Show("Invalid value");
            }
            
        }

        private bool CheckValues()
        {
            if (datePicker.SelectedDate.Value > DateTime.Now
               && CategoriesList.SelectedItem == null)
            { return false; } return true; 
        }

    }
}