using MauiShoppingList.Models;

namespace MauiShoppingList.Views
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = (Application.Current.MainPage! as AppShell).MVM;
        }

        private void OnAddItem(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(AddPage), true, new Dictionary<string, object>
            {
                ["Item"] = new ShoppingItem()
            });
        }
        private void lvItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = e.CurrentSelection.FirstOrDefault() as ShoppingItem;
            if (selectedItem is not ShoppingItem item)
            {
                return;
            }
            Shell.Current.GoToAsync(nameof(DetailPage), true, new Dictionary<string, object>
            {
                ["Item"] = item
            });
        }
    }

}
