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
    public partial class NewCharacterPage : ContentPage
    {
        NewCharacterViewModel _viewModel;

        public NewCharacterPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new NewCharacterViewModel();
            LoadInfo();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        async void AddCharacterClick(Object sender, EventArgs e)
        {
            if (NameForm.Text == null || LevelForm.Text == null || HPForm.Text == null || MPForm.Text == null || StrForm.Text == null || AgiForm.Text == null || IntForm.Text == null || ClassPicker.SelectedItem == null || ProfessionPicker.SelectedItem == null || GuildPicker.SelectedItem == null)
            {
                var toastmessage = "Need to fill everything";
                DependencyService.Get<ToastMessage>().ShortTime(toastmessage);
            }
            else
            {
                
                var characterApiServises = new CharacterApiServises();
                var guild = _viewModel.CharacterClasses.FirstOrDefault(x => x.Name == ClassPicker.SelectedItem.ToString()).Id.ToString();
                var characterClass = _viewModel.CharacterClasses.FirstOrDefault(x => x.Name == ClassPicker.SelectedItem.ToString()).Id.ToString();
                var characterProfession = _viewModel.CharacterProfessions.FirstOrDefault(x => x.Name == ProfessionPicker.SelectedItem.ToString()).Id.ToString();

                var content = await characterApiServises.AddCharacterAsync(CurrentUser.ThisUser.id.ToString(), NameForm.Text, LevelForm.Text, HPForm.Text, MPForm.Text, StrForm.Text, AgiForm.Text, IntForm.Text, characterClass, characterProfession, guild);
                if (content != null)
                {
                    await LoadInfo();
                    await Shell.Current.GoToAsync("..");
                }
                else
                {
                    var toastmessage = "Not Created";
                    DependencyService.Get<ToastMessage>().ShortTime(toastmessage);
                }
            }
        }
        
        async Task LoadInfo()
            {
                await _viewModel.ExecuteLoadItemsCommand();
            }
    }
}