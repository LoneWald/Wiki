using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki.Models.Users;
using Wiki.Servises;
using Wiki.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wiki.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewGuildPage : ContentPage
    {
        NewGuildViewModel _viewModel;
        public NewGuildPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new NewGuildViewModel();
        }

        async void CreateGuildClick(Object sender, EventArgs e)
        {
            if (NameForm.Text == null || ExForm.Text == null || MembersForm.Text == null || PositionForm.Text == null)
            {
                var toastmessage = "Need to fill everything";
                DependencyService.Get<ToastMessage>().ShortTime(toastmessage);
            }
            else
            {

                var guildApiServises = new GuildApiServises();

                var content = await guildApiServises.AddGuildAsync(NameForm.Text, ExForm.Text, MembersForm.Text, PositionForm.Text);
                if (content != null)
                {
                    
                    await Shell.Current.GoToAsync("..");
                }
                else
                {
                    var toastmessage = "Not Created";
                    DependencyService.Get<ToastMessage>().ShortTime(toastmessage);
                }
            }
        }
    }
}