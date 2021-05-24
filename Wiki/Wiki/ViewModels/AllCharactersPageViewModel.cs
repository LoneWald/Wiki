using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Wiki.Models.ResponseModels;
using Wiki.Models.Users;
using Wiki.Servises;
using Xamarin.Forms;

namespace Wiki.ViewModels
{
    class AllCharactersPageViewModel : BaseViewModel
    {
        public Command LoadCharactersCommand { get; }
        public ObservableCollection<CharactersApiResponseModel> Characters { get; }

        public AllCharactersPageViewModel()
        {
            Title = "All Characters";
            Characters = new ObservableCollection<CharactersApiResponseModel>();
            LoadCharactersCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }


        public async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Characters.Clear();
                var characterApiServises = new CharacterApiServises();
                var characters = await characterApiServises.SelectAllCharactersAsync();
                foreach (var character in characters)
                {
                    Characters.Add(character);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }
    }
}
