using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MauiShoppingList.Models
{
    public class ShoppingItem : INotifyPropertyChanged
    {
        private int _id;
        private string _name = "";
        private string _notes = "";
        private bool _done;
        [PrimaryKey, AutoIncrement]
        public int Id 
        { 
            get 
            { 
                return _id; 
            }
            set 
            {
                _id = value;
                OnPropertyChanged();
            }
        }
        public string Name
        {
            get
            {
                return _name; 
            }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public string Notes
        {
            get
            {
                return _notes; 
            }
            set
            {
                _notes = value;
                OnPropertyChanged();
            }
        }
        public bool Done
        {
            get
            {
                return _done; 
            }
            set
            {
                _done = value;
                OnPropertyChanged();
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
