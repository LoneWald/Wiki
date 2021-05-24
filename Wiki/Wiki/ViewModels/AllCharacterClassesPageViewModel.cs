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
    class AllCharacterClassesPageViewModel : BaseViewModel
    {
        public bool _isModerator;
        public Command LoadClassesCommand { get; }
        public ObservableCollection<CharacterClassesApiResponseModel> Classes { get; }

        public AllCharacterClassesPageViewModel()
        {
            Title = "All Classes";
            if (CurrentUser.ThisUser != null)
                this.IsModerator = CurrentUser.ThisUser.isModerator;
            else
                this.IsModerator = false;
            CurrentUser.ThisUserChanged += () =>
            {
                this.IsModerator = CurrentUser.ThisUser?.isModerator ?? false;
                ThisUserChanged?.Invoke();

            };
            Classes = new ObservableCollection<CharacterClassesApiResponseModel>();
            LoadClassesCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        public event Action ThisUserChanged;

        public async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Classes.Clear();
                var classesApiServises = new CharacterClassApiServises();
                var classes = await classesApiServises.SelectCharacterClassesAsync();
                foreach (var characterClass in classes)
                {
                    Classes.Add(characterClass);
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