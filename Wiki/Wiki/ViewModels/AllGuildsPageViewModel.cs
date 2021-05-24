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
    class AllGuildsPageViewModel : BaseViewModel
    {
        public bool _isModerator;
        public Command LoadGuildsCommand { get; }
        public ObservableCollection<GuildsApiResponseModel> Guilds { get; }

        public AllGuildsPageViewModel()
        {
            Title = "All Guilds";
            if (CurrentUser.ThisUser != null)
                this.IsModerator = CurrentUser.ThisUser.isModerator;
            else
                this.IsModerator = false;
            CurrentUser.ThisUserChanged += () =>
            {
                this.IsModerator = CurrentUser.ThisUser?.isModerator ?? false;
                ThisUserChanged?.Invoke();

            };
            Guilds = new ObservableCollection<GuildsApiResponseModel>();
            LoadGuildsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        public event Action ThisUserChanged;

        public async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Guilds.Clear();
                var guildsApiServises = new GuildApiServises();
                var guilds = await guildsApiServises.SelectGuildsAsync();
                var sortedGuilds = from g in guilds
                                   orderby g.Topposition
                                   select g;
                foreach (var guild in sortedGuilds)
                {
                    Guilds.Add(guild);
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
