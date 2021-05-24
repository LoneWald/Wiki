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
    public class AccountViewModel : BaseViewModel
    {

        public CurrentUser user;
        private string _nickname;
        public Command LoadCharactersCommand { get; }
        public ObservableCollection<CharactersApiResponseModel> Characters { get; }

        public AccountViewModel()
        {
            this._nickname = CurrentUser.ThisUser?.nickname ?? string.Empty;
            CurrentUser.ThisUserChanged += () =>
            {
                this.Nickname = CurrentUser.ThisUser?.nickname ?? string.Empty;
                ThisUserChanged?.Invoke();
                
            };
            Title = "My Account";
            Characters = new ObservableCollection<CharactersApiResponseModel>();
            LoadCharactersCommand = new Command(async () => await ExecuteLoadItemsCommand());
            user = new CurrentUser();
        }


        public event Action ThisUserChanged;

        public async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Characters.Clear();
                var characterApiServises = new CharacterApiServises();
                var characters = await characterApiServises.SelectAccountsCharactersAsync(CurrentUser.ThisUser.id);
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

        public string Nickname
        {
            get => _nickname;
            set
            {
                SetProperty(ref _nickname, value);
            }
        }
    }


}
