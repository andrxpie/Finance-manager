using Data_access.Repositories;
using Finance_manager.Migrations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Finance_manager;

namespace Finance_manager
{
    /// <summary>
    /// Interaction logic for CategoryWindow.xaml
    /// </summary>
    public partial class CategoryWindow : Window
    {
        private IUoW uoW = new UnitOfWork();
        public ObservableCollection<Category> Categories { get; set; }
        private ViewModel.ViewModel vm;

        public CategoryWindow()
        {
            InitializeComponent();
            vm = new ViewModel.ViewModel();
            DataContext = vm;
        }

        private void AddCategoryBtn_Click(object sender, RoutedEventArgs e)
        {
            AddCategoryWindow addCategoryWindow = new AddCategoryWindow();
            addCategoryWindow.ShowDialog();
            Close();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new();
            main.Show();
            Close();
        }
    }
}
