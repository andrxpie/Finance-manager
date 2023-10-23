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
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void CreateAccBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateAccountWindow createAccountWindow = new CreateAccountWindow();
            Close();
            createAccountWindow.Show();
        }

        private void LogInBtn_Click(object sender, RoutedEventArgs e)
        {
            //"MainWindow" mw = new "MainWindow"(loginTxtBox, passTxtBox);
            Validation();
            /*
            if(Validation()){
                mw.Show();
            }
            */
        }
        private void Validation()
        {
            if (loginTxtBox.Text != string.Empty && passTxtBox.Text != string.Empty)
            {
                /*User user = uow.UserRepo.Get(x => x.Login == loginTxtBox.Text);
                if(user != null){
                   return BCrypt.Net.BCrypt.Verify(passTxtBox.Text, user.Password);
                }
                return false;
                */

                Close();
            }
            else
            {
                MessageBox.Show("Incorrect login or password");
            }
        }
    }
}