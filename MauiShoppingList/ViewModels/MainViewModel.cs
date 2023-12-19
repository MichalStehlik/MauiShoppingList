using MauiShoppingList.Data;
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
        private ShoppingDatabase _database;
        private string _newName;
        public Command DeleteCommand { get; set; }
        public Command AddCommand { get; set; }
        public Command UpdateCommand { get; set; }
        public Command ReloadCommand { get; set; }

        public MainViewModel()
        {
            _database = new ShoppingDatabase();
            Task.Run(() => LoadItems());
            //Items.Add(new ShoppingItem { Id = 1, Name = "Milk", Notes = "2% milk" });
            //Items.Add(new ShoppingItem { Id = 2, Name = "Eggs", Notes = "1 dozen" });
            //Items.Add(new ShoppingItem { Id = 3, Name = "Bread", Notes = "Whole wheat" });

            DeleteCommand = new Command(
                async () =>
                {
                    if (SelectedItem is ShoppingItem)
                    {
                        //Items.Remove(item);
                        await DeleteItemAsync(SelectedItem);
                        await LoadItems();

                    }
                },
                () => SelectedItem is not null
             );
            UpdateCommand = new Command(
                async () =>
                {
                    if (SelectedItem is ShoppingItem)
                    {
                        //Items.Remove(item);
                        await StoreItemAsync(SelectedItem);
                        await LoadItems();

                    }
                },
                () => SelectedItem is not null
             );
            AddCommand = new Command(
                async () =>
                {
                    await StoreItemAsync(new ShoppingItem { Name = NewName });
                    //Items.Add(new ShoppingItem { Name = NewName});
                    await LoadItems();
                },
                () => NewName is not null
            );
            ReloadCommand = new Command(
                async () =>
                {
                    await LoadItems();
                }
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

        private async Task LoadItems()
        {
            var items = await _database.GetItemsAsync();
            Items.Clear();
            foreach (var item in items)
            {
                Items.Add(item); 
            }
        }

        public async Task<int> StoreItemAsync(ShoppingItem item)
        {
            return await _database.StoreItemAsync(item);
        }

        public Task<int> DeleteItemAsync(ShoppingItem item)
        {
            return _database.DeleteItemAsync(item);
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
