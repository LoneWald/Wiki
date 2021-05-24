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
using System.Linq;

namespace Wiki.ViewModels
{
    class AllCharacterProfessionsPageViewModel : BaseViewModel
    {
        public bool _isModerator;
        public Command LoadProfessionsCommand { get; }
        public ObservableCollection<CharacterProfessionsApiResponseModel> Professions { get; }

        public AllCharacterProfessionsPageViewModel()
        {
            Title = "All Professions";
            if (CurrentUser.ThisUser != null)
                this.IsModerator = CurrentUser.ThisUser.isModerator;
            else
                this.IsModerator = false;
            CurrentUser.ThisUserChanged += () =>
            {
                this.IsModerator = CurrentUser.ThisUser?.isModerator ?? false;
                ThisUserChanged?.Invoke();

            };
            Professions = new ObservableCollection<CharacterProfessionsApiResponseModel>();
            LoadProfessionsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        public event Action ThisUserChanged;

        public async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Professions.Clear();
                var professionsApiServises = new CharacterProfessionApiServises();
                var professions = await professionsApiServises.SelectCharacterProfessionsAsync();
                foreach (var profession in professions)
                {
                    Professions.Add(profession);
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

        public bool IsModerator
        {
            get => _isModerator;
            set
            {
                SetProperty(ref _isModerator, value);
            }
        }
    }
}
