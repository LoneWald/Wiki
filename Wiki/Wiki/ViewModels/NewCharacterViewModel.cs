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
    class NewCharacterViewModel : BaseViewModel
    {
        public Command LoadCharacterClassesCommand { get; }
        public ObservableCollection<string> CharacterClassesName { get; }
        public ObservableCollection<CharacterClassesApiResponseModel> CharacterClasses { get; }
        public ObservableCollection<string> CharacterProfessionsName { get; }
        public ObservableCollection<CharacterProfessionsApiResponseModel> CharacterProfessions { get; }
        public ObservableCollection<string> GuildsName { get; }
        public ObservableCollection<GuildsApiResponseModel> Guilds { get; }

        public NewCharacterViewModel()
        {
            Title = "Creating Character";
            CharacterClassesName = new ObservableCollection<string>();
            CharacterClasses = new ObservableCollection<CharacterClassesApiResponseModel>();
            CharacterProfessionsName = new ObservableCollection<string>();
            CharacterProfessions = new ObservableCollection<CharacterProfessionsApiResponseModel>();
            GuildsName = new ObservableCollection<string>();
            Guilds = new ObservableCollection<GuildsApiResponseModel>();
            LoadCharacterClassesCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        public async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                await RefreshCharacterClasses();
                await RefreshCharacterProfessions();
                await RefreshGuilds();
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

        private async Task RefreshCharacterClasses()
        {
            CharacterClasses.Clear();
            CharacterClassesName.Clear();
            var characterClassApiServises = new CharacterClassApiServises();
            var characterClasses = await characterClassApiServises.SelectCharacterClassesAsync();
            var sortedCharacterClasses = from cC in characterClasses
                                         orderby cC.Name
                                         select cC;
            foreach (var characterClass in sortedCharacterClasses)
            {
                CharacterClassesName.Add(characterClass.Name);
                CharacterClasses.Add(characterClass);
            }
        }

        private async Task RefreshCharacterProfessions()
        {
            CharacterProfessions.Clear();
            CharacterProfessionsName.Clear();
            var characterProfessionApiServises = new CharacterProfessionApiServises();
            var characterProfessions = await characterProfessionApiServises.SelectCharacterProfessionsAsync();
            var sortedCharacterProfessions = from cP in characterProfessions
                                             orderby cP.Name
                                             select cP;
            foreach (var characterProfession in sortedCharacterProfessions)
            {
                CharacterProfessionsName.Add(characterProfession.Name);
                CharacterProfessions.Add(characterProfession);
            }
        }

        private async Task RefreshGuilds()
        {
            GuildsName.Clear();
            Guilds.Clear();
            var guildApiServises = new GuildApiServises();
            var guilds = await guildApiServises.SelectGuildsAsync();
            var sortedGuilds = from g in guilds
                               orderby g.Name
                               select g;
            foreach (var guild in sortedGuilds)
            {
                GuildsName.Add(guild.Name);
                Guilds.Add(guild);
            }
        }

    }
}
