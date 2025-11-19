namespace MauiRecipes14D2025.Mvvm.View;

public partial class DetailPage : ContentPage
{
	public DetailPage()
	{
		InitializeComponent();
	}

    private void buttonBack_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ListPage());
    }
}