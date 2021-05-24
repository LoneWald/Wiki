using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki.Views;
using Wiki.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wiki.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MenuViewModel _viewModel;
        public MenuPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new MenuViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        async private void GoToAllCharactersPage(object sender, EventArgs e)
        {
            Routing.RegisterRoute("AllCharactersPage", typeof(AllCharactersPage));
            await Shell.Current.GoToAsync("AllCharactersPage");
        }

        async private void GoToAllGuildsPage(object sender, EventArgs e)
        {
            Routing.RegisterRoute("AllGuildsPage", typeof(AllGuildsPage));
            await Shell.Current.GoToAsync("AllGuildsPage");
        }

        async private void GoToAllCharacterClassesPage(object sender, EventArgs e)
        {
            Routing.RegisterRoute("AllCharacterClassesPage", typeof(AllCharacterClassesPage));
            await Shell.Current.GoToAsync("AllCharacterClassesPage");
        }

        async private void GoToAllCharacterProfessionsPage(object sender, EventArgs e)
        {
            Routing.RegisterRoute("AllCharacterProfessionsPage", typeof(AllCharacterProfessionsPage));
            await Shell.Current.GoToAsync("AllCharacterProfessionsPage");
        }
    }
}