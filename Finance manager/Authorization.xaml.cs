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
using System.IO;

namespace Finance_manager
{
    public partial class Authorization : Window
    {
        UnitOfWork uow = new();

        public Authorization()
        {
            InitializeComponent();
        }

        private void CreateAccBtn_Click(object sender, RoutedEventArgs e)
        {
            Hide();

            CreateAccountWindow createAccountWindow = new CreateAccountWindow();
            createAccountWindow.ShowDialog();

            Show();
        }

        private void LogInBtn_Click(object sender, RoutedEventArgs e)
        {
            Validation();
        }

        private void Validation()
        {
            if (loginTxtBox.Text != string.Empty && passTxtBox.Text != string.Empty)
            {
                try
                {
                    User user = uow.UserRepo.Get(x => x.Login == loginTxtBox.Text).First();
                    if (BCrypt.Net.BCrypt.Verify(passTxtBox.Text, user.Password))
                    {
                        Hide();

                        MainWindow mw = new MainWindow(user);
                        mw.ShowDialog();

                        ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect login or password.");
                    }

                    loginTxtBox.Text = string.Empty;
                    passTxtBox.Text = string.Empty;

                    Hide();
                }
                catch
                {
                    MessageBox.Show("Incorrect login or password.");
                }
            }
            else
            {
                MessageBox.Show("Login && password is empty.");
            }
        }
    }
}