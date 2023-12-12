namespace MauiShoppingList.Views;

[QueryProperty("Item", "Item")]
public partial class AddPage : ContentPage
{
    public AddPage()
    {
        InitializeComponent();
    }
    private void Cancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
    private void Save_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}