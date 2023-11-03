using Data_access.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Finance_manager.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        private string selectedText;
        private IUoW uoW = new UnitOfWork();
        private ObservableCollection<Category> categories;
        
        public User CurrUser { get; set; }

        public string SelectedText
        {
            get { return selectedText; }
            set
            {
                selectedText = value;
                OnPropertyChanged();
            }
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