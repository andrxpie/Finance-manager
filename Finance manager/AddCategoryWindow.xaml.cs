using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AddCategoryWindow.xaml
    /// </summary>
    public partial class AddCategoryWindow : Window
    {
        public AddCategoryWindow()
        {
            InitializeComponent();
        }

        private void AddCatgeryBtn_Click(object sender, RoutedEventArgs e)
        {
            AddCatAsync();
        }

        private async void AddCatAsync()
        {
            var entity = new Category
            {
                Name = categoryName.Text,
            };

            using (var cx = new FinanceManagerDbContext())
            {
                await cx.Categories.AddAsync(entity);
                cx.SaveChanges();

                MessageBox.Show("Apply");
            }
            Close();
        }
    }
}
