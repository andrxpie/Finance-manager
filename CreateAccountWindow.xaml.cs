﻿using System;
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
    /// Interaction logic for CreateAccountWindow.xaml
    /// </summary>
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
            
            if (passTxtBox.Text == passSecTxtBox.Text)
            {
                //save in db
                Authorization auth = new Authorization();

                Close();

                //in db emailTxtBox.Text;
                auth.login = this.loginTxtBox.Text;
                auth.password = this.passTxtBox.Text;
                auth.Show();
            }
            else
            {
                MessageBox.Show("Invalid login or password");
            }
        }
    }
}
