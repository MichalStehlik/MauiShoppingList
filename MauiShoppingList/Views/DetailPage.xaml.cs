namespace MauiShoppingList.Views;

[QueryProperty("Item", "Item")]
public partial class DetailPage : ContentPage
{
	public DetailPage()
	{
		InitializeComponent();
        BindingContext = (Application.Current.MainPage as AppShell).MVM;
    }

    private void Cancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
    private void Delete_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
    private void Save_Clicked(object sender, EventArgs e)
    {
        var vm = BindingContext as ViewModels.MainViewModel;
        vm!.UpdateCommand.Execute(null);
        Shell.Current.GoToAsync("..");
    }
}