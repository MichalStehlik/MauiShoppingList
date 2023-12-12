using MauiShoppingList.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiShoppingList.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ShoppingItem> _items = new ObservableCollection<ShoppingItem>();
        private ShoppingItem? _selectedItem;
        private string _newName;
        public Command DeleteCommand { get; set; }
        public Command AddCommand { get; set; }

        public MainViewModel()
        {
            Items.Add(new ShoppingItem { Id = 1, Name = "Milk", Notes = "2% milk" });
            Items.Add(new ShoppingItem { Id = 2, Name = "Eggs", Notes = "1 dozen" });
            Items.Add(new ShoppingItem { Id = 3, Name = "Bread", Notes = "Whole wheat" });
            DeleteCommand = new Command(
                () =>
                {
                    if (SelectedItem is ShoppingItem item)
                    {
                        Items.Remove(item);
                    }
                },
                () => SelectedItem is not null
             );
            AddCommand = new Command(
                () =>
                {
                        Items.Add(new ShoppingItem { Name = NewName});
                },
             () => NewName is not null
             );
        }

        public ObservableCollection<ShoppingItem> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        public ShoppingItem? SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        public string? NewName
        {
            get => _newName;
            set
            {
                _newName = value;
                OnPropertyChanged();
                AddCommand.ChangeCanExecute();
            }
        }

        #region MVVM
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        #endregion
    }
}
