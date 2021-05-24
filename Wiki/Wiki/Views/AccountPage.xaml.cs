using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Wiki.Models.Users;
using Wiki.Servises;
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
                    OpenNonAuthorizedStackLayout();
                }
                else
                {
                    OpenAuthorizedStackLayout();
                }
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        private void Check()
        {
            if (CurrentUser.ThisUser != null)
            {
                OpenAuthorizedStackLayout();
            }
        }

        private void ClearCurrentUser()
        {
            CurrentUser.ThisUser = null;
        }

        private void GoToLoginStackLayoutClick(object sender, EventArgs e)
        {
            OpenLoginStackLayout();
        }
        
        private void LogOutClick(object sender, EventArgs e)
        {
            ClearCurrentUser();
        }

        async private void CreateCharacterClick(object sender, EventArgs e)
        {
            Routing.RegisterRoute("NewCharacterPage", typeof(NewCharacterPage));
            await Shell.Current.GoToAsync("NewCharacterPage");
        }

        async void LoginClick(Object sender, EventArgs e)
        {
            if (LoginForm.Text == null || PasswordForm.Text == null)
            {
                var toastmessage = "Need to fill everything";
                DependencyService.Get<ToastMessage>().ShortTime(toastmessage);
            }
            else
            {
                var accountApiServises = new AccountApiServises();
                var content = await accountApiServises.AuthenticateUserAsync(LoginForm.Text, PasswordForm.Text);

                if (content != null)
                {
                    CurrentUser.ThisUser = new CurrentUser(content);
                    OpenAuthorizedStackLayout();
                    _viewModel.IsBusy = true;
                }
                else
                {
                    var toastmessage = "Not Found";
                    DependencyService.Get<ToastMessage>().ShortTime(toastmessage);
                }
            }

        }


        private void GoToRegisterStackLayoutClick(Object sender, EventArgs e)
        {
            OpenRegisterStackLayout();
        }

        async private void RegisterClick(Object sender, EventArgs e)
        {
            if (RegEmailForm.Text == null || RegLoginForm.Text == null || RegPasswordForm.Text == null || RegNicknameForm.Text == null)
            {
                var toastmessage = "Need to fill everything";
                DependencyService.Get<ToastMessage>().ShortTime(toastmessage);
            }
            else
            {
                var accountApiServises = new AccountApiServises();
                var content = await accountApiServises.RegisterUserAsync(RegEmailForm.Text, RegLoginForm.Text, RegPasswordForm.Text, RegNicknameForm.Text);
                if (content != null)
                {
                    CurrentUser.ThisUser = new CurrentUser(content);
                    OpenAuthorizedStackLayout();
                    await _viewModel.ExecuteLoadItemsCommand();
                    ClearRegForm();
                }
                else
                {
                    var toastmessage = "Failed to create";
                    DependencyService.Get<ToastMessage>().ShortTime(toastmessage);
                }
            }


        }

        private void ClearRegForm()
        {
            RegEmailForm.Text = null;
            RegLoginForm.Text = null;
            RegPasswordForm.Text = null;
            RegNicknameForm.Text = null;
        }

        private void OpenNonAuthorizedStackLayout()
        {
            AuthorizedStackLayout.IsVisible = false;
            LoginStackLayout.IsVisible = false;
            RegisterStackLayout.IsVisible = false;
            NonAuthorizedStackLayout.IsVisible = true;
        }

        private void OpenAuthorizedStackLayout()
        {
            LoginStackLayout.IsVisible = false;
            RegisterStackLayout.IsVisible = false;
            NonAuthorizedStackLayout.IsVisible = false;
            AuthorizedStackLayout.IsVisible = true;
        }

        private void OpenLoginStackLayout()
        {
            NonAuthorizedStackLayout.IsVisible = false;
            AuthorizedStackLayout.IsVisible = false;
            RegisterStackLayout.IsVisible = false;
            LoginStackLayout.IsVisible = true;
        }

        private void OpenRegisterStackLayout()
        {
            NonAuthorizedStackLayout.IsVisible = false;
            AuthorizedStackLayout.IsVisible = false;
            LoginStackLayout.IsVisible = false;
            RegisterStackLayout.IsVisible = true;
        }
    }
}