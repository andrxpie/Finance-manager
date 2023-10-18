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
    /// <summary>
    /// Interaction logic for Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public string login = string.Empty;
        public string password = string.Empty;

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
            //"MainWindow" mw = new "MainWindow"(login, password);
            Validation();
            
            //mw.Show();
        }
        private void Validation()
        {
            if (loginTxtBox.Text != string.Empty && passTxtBox.Text != string.Empty)
            {
                Close();
            }
            else
            {
                MessageBox.Show("Incorrect login or password");
                
            }
        }
    }
}
