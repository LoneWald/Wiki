using Wiki.Models.Users;
using Wiki.Models.Login;
using Wiki.Models.Register;
using Wiki.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Wiki.Servises;

namespace Wiki.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
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
                    await Shell.Current.GoToAsync(".."); // LoginSucces()
                }
                else
                {
                    var toastmessage = "Not Found";
                    DependencyService.Get<ToastMessage>().ShortTime(toastmessage);
                }
            }

        }
        
        async void GoToRegisterPageClick(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AccountPage()); // RegisterPage()
        }
    }
}