using Data_access.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Finance_manager.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        private string selectedText;
        private IUoW uoW = new UnitOfWork();
        private ObservableCollection<Category> categories;
        private User currUser { get; set; }
        public BitmapImage ImageSource { get; set; }
        public string MyPassword { get; set; }


        public SolidColorBrush[] colors = 
        {
            Brushes.Green,
            Brushes.Orange,
            Brushes.Orchid,
            Brushes.Purple,
            Brushes.Red,
            Brushes.White,
            Brushes.Yellow,
            Brushes.YellowGreen,
            Brushes.Aqua, 
            Brushes.Aquamarine,
            Brushes.BlueViolet,
            Brushes.Blue,
            Brushes.Crimson,
            Brushes.Fuchsia,
            Brushes.DarkRed,
            Brushes.DarkSalmon,
        };
        public string SelectedText
        {
           
            get { return selectedText; }
            set
            {
                selectedText = value;
                OnPropertyChanged();
            }
        }

        public User CurrUser
        {
            get { return currUser; }
            set { currUser = value; OnPropertyChanged(nameof(currUser)); }
        }

        public ObservableCollection<Category> Categories
        {
            get { return categories; }
            set
            {
                categories = value;
                OnPropertyChanged(nameof(Categories));
            }
        }

        public ViewModel()
        {
            Random rnd = new Random();
            Categories = new ObservableCollection<Category>();
            ShowCategories();
        }

        private void ShowCategories()
        {
            Categories.Clear();
            foreach (var cat in uoW.CategoryRepo.Get())
            {
                Categories.Add(cat);
            }
            uoW.Save();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}