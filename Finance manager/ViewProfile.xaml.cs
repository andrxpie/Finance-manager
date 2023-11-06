using BCrypt.Net;
using Data_access.Repositories;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace Finance_manager
{
    /// <summary>
    /// Interaction logic for ViewProfile.xaml
    /// </summary>
    public partial class ViewProfile : Page
    {
        private static IUoW uow = new UnitOfWork();

        ViewModel.ViewModel vm = new();
        public string TmpPath { get; set; }

        public ViewProfile(User us)
        {
            InitializeComponent();
            vm.CurrUser = us;
            this.DataContext = vm;
        }


        private void EditAvatarBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == true)
            {
                TmpPath = Path.GetFullPath(dialog.FileName);
                Image.Source = new BitmapImage(new Uri($"{TmpPath}", UriKind.Absolute));
            }
        }

        private void AcceptBtn_Click(object sender, RoutedEventArgs e)
        {
            if(BCrypt.Net.BCrypt.Verify(PasswordToEdit.Text, vm.CurrUser.Password))

        }

        private void CancelBtn2_Click(object sender, RoutedEventArgs e)
        {
            PasswordToEdit.Text = "";
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            LoginToEdit.Text = "";
        }
        private void CancelBtn3_Click(object sender, RoutedEventArgs e)
        {
            NewPassword.Text = "";
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(null);
        }

    }
}
