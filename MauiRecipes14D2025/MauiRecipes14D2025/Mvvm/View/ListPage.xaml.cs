using MauiRecipes14D2025.Mvvm.Model;
using System.Text.Json;

namespace MauiRecipes14D2025.Mvvm.View;

public partial class ListPage : ContentPage
{
    HttpClient client;
    JsonSerializerOptions serializerOptions;
    string baseurl = "https://dummyjson.com/recipes";
    public ListPage()
    {
        InitializeComponent();
        client = new HttpClient();
        serializerOptions = new JsonSerializerOptions { WriteIndented = true };
    }

    private void collectionRecipes_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedRecipe = collectionRecipes.SelectedItem as Result;
        Navigation.PushAsync(new DetailPage { BindingContext = selectedRecipe });
    }

    private async void buttonGet_Clicked(object sender, EventArgs e)
    {
        var url = $"{baseurl}/?results=30";

        if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
        {
            try
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    using (var responseStream = await response.Content.ReadAsStreamAsync())
                    {
                        var data = await JsonSerializer.DeserializeAsync<Recipes>(responseStream, serializerOptions);
                        collectionRecipes.ItemsSource = data.results;
                    }
                }
                else
                {
                    collectionRecipes.EmptyView = "No data";
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Hiba", ex.Message, "Ok");
            }
        }
        else
        {
            collectionRecipes.EmptyView = "Nincs internet hozzáférés!";
        }
    }
}