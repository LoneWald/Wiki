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
    public partial class AccountPage : ContentPage
    {
        AccountViewModel _viewModel;
        public AccountPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new AccountViewModel();
            Check();
            _viewModel.ThisUserChanged += () =>
            {
                if (CurrentUser.ThisUser == null)
                {
                    NonAuthorizedStackLayout.IsVisible = true;
                    AuthorizedStackLayout.IsVisible = false;
                } 
                else
                {
                    NonAuthorizedStackLayout.IsVisible = false;
                    AuthorizedStackLayout.IsVisible = true;
                }
            };
            
        }

        async private void GoToLoginPage()
        {
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            await Shell.Current.GoToAsync(nameof(LoginPage));
        }

        private void Check()
        {
            if (CurrentUser.ThisUser != null)
            {
                NonAuthorizedStackLayout.IsVisible = false;
                AuthorizedStackLayout.IsVisible = true;
            }
        }

        private void LogOutClick(object sender, EventArgs e)
        {
            ClearCurrentUser();
            _viewModel.We();
        }

        private void ClearCurrentUser()
        {
            CurrentUser.ThisUser = null;
        }

        private void SingInClick(object sender, EventArgs e)
        {
            GoToLoginPage();
        }
    }
}