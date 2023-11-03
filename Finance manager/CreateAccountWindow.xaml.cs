using BCrypt.Net;
using Data_access.Repositories;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Finance_manager
{
    public partial class CreateAccountWindow : Window
    {
        private UnitOfWork uow = new();

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
            try
            {
                if (passTxtBox.Text == passSecTxtBox.Text && loginTxtBox.Text != string.Empty && policyCheckBox.IsChecked == true)
                {
                    User user = new User();

                    if(uow.UserRepo.Get(x => x.Login == loginTxtBox.Text).FirstOrDefault() != null) 
                    {
                        MessageBox.Show("Login already in use.");
                        loginTxtBox.Focus();
                        return;
                    }
                    else
                    {
                        user.Login = loginTxtBox.Text;
                    }

                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(passTxtBox.Text);
                    user.Password = hashedPassword;

                    if(emailTxtBox.Text != string.Empty) 
                    {
                        if(uow.UserRepo.Get(x => x.Email == emailTxtBox.Text).FirstOrDefault() != null)
                        {
                            MessageBox.Show("Email already in use.");
                            emailTxtBox.Focus();
                            return;
                        }
                        else
                        {
                            user.Email = emailTxtBox.Text;
                        }
                    }

                    if(avatarTxtBox.Text != string.Empty) 
                    {
                        try
                        {
                            File.Copy(avatarTxtBox.Text, Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "media\\avatars", Path.GetFileName(avatarTxtBox.Text)));
                            user.AvatarPicture = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "media\\avatars", Path.GetFileName(avatarTxtBox.Text));
                        }
                        catch
                        {
                            MessageBox.Show("File exist.", "Message", MessageBoxButton.OK);
                        }
                    }

                    uow.UserRepo.Insert(user);
                    uow.Save();

                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: ", ex.Message);
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

        private void SelectImageBtn(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == true) { avatarTxtBox.Text = ofd.FileName; }
        }
    }
}