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
using Finance_manager.ViewModel;

namespace Finance_manager
{
    public partial class Authorization : Window
    {
        UnitOfWork uow = new();

        ViewModel.ViewModel vm = new();

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

            vm.MyPassword = passTxtBox.Text;
        }

        private void Validation()
        {
            if (loginTxtBox.Text != string.Empty && passTxtBox.Text != string.Empty)
            {
                try
                {
                    User user = uow.UserRepo.Get(x => x.Login == loginTxtBox.Text).FirstOrDefault();
                    if (BCrypt.Net.BCrypt.Verify(passTxtBox.Text, user.Password))
                    {
                        Hide();

                        MainWindow mw = new MainWindow(user);
                        mw.ShowDialog();
                        ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("123");
                    }

                    loginTxtBox.Text = string.Empty;
                    passTxtBox.Text = string.Empty;

                    Hide();
                }
                catch
                {
                    MessageBox.Show("incorrect login or password.");
                }
        }
            else
            {
                MessageBox.Show("Login && password is empty.");
            }
        }
    }
}