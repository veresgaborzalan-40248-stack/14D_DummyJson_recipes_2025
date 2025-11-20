using MauiRecipes14D2025.Mvvm.View;

namespace MauiRecipes14D2025
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ListPage());
        }
    }
}
