using Data_access.Repositories;
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

        public string SelectegCateg { get; set; }
        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            Close();
        }

        private void CategoryListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (categLB.SelectedItem != null)
            {
                Category selectedCategory = categLB.SelectedItem as Category;

                if (selectedCategory != null)
                {
                    MessageBox.Show($"You clicked on category: {selectedCategory.Name}");
                    SelectegCateg = selectedCategory.Name;
                }
            }

        }
    }
}
