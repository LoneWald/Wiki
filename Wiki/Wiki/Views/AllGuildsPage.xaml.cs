using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki.Models.Users;
using Wiki.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wiki.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllGuildsPage : ContentPage
    {
        AllGuildsPageViewModel _viewModel;

        public AllGuildsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new AllGuildsPageViewModel();
            RefreshGuilds();
        }

        public void RefreshGuilds()
        {
            _viewModel.IsBusy = true;
        }


        async private void CreateGuildClick(object sender, EventArgs e)
        {
            Routing.RegisterRoute("NewGuildPage", typeof(NewGuildPage));
            await Shell.Current.GoToAsync("NewGuildPage");
        }
    }
}