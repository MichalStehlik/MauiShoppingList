using MauiShoppingList.ViewModels;
using MauiShoppingList.Views;

namespace MauiShoppingList
{
    public partial class AppShell : Shell
    {
        public MainViewModel MVM { get; } = new MainViewModel();
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AddPage), typeof(AddPage));
            Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
            BindingContext = MVM;
        }
    }
}
