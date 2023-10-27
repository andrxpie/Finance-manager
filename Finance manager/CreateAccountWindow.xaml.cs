using BCrypt.Net;
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
using System.Windows.Shapes;

namespace Finance_manager
{
    public partial class CreateAccountWindow : Window
    {
        UnitOfWork uow = new();

        public CreateAccountWindow()
        {
            InitializeComponent();
        }

        private void CreateAccBtn_Click(object sender, RoutedEventArgs e)
        {
            CheckValid();
        }

        private void CheckValid()
        {
            Exception e = new Exception();
              
            if (passTxtBox.Text == passSecTxtBox.Text && loginTxtBox.Text != string.Empty && policyCheckBox.IsChecked == true)
            {
                Authorization auth = new Authorization();
                Close();

                User user = new User();
                user.Login = loginTxtBox.Text;
                user.Password = BCrypt.Net.BCrypt.HashPassword(passSecTxtBox.Text);
                user.Email = emailTxtBox.Text;
                user.PasswordOpen = passTxtBox.Text;
                uow.UserRepo.Insert(user);
                uow.Save();

                auth.Show();
            }
            else
            {
                MessageBox.Show("Invalid info.", e.Message);
            }
        }

        private void PolicyBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(@"
Lorem ipsum dolor sit amet,
consectetur adipiscing elit,
sed do eiusmod tempor incididunt
ut labore et dolore magna aliqua.
");
        }
    }
}