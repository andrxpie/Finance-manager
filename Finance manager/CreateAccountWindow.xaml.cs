using BCrypt.Net;
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
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(passTxtBox.Text);
                user.Login = loginTxtBox.Text;
                user.Password = hashedPassword;
                user.Email = emailTxtBox.Text;
                user.PasswordOpen = passTxtBox.Text;

                // save in db using Unit of Work

                auth.Show();
            }
            else
            {
                MessageBox.Show("Invalid info.", e.Message);
            }
        }
        //Add method to create user in database
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