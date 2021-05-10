using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Wiki.Models;
using Wiki.Views;
using Xamarin.Forms;

namespace Wiki.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        private MenuSection _selectedSection;

        public ObservableCollection<MenuSection> Sections { get; }
        public Command LoadSectionsCommand { get; }
        public Command<MenuSection> SectionTapped { get; }

        public MenuViewModel()
        {
            Title = "Menu";
            Sections = new ObservableCollection<MenuSection>();
            LoadSectionsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            SectionTapped = new Command<MenuSection>(OnItemSelected);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Sections.Clear();
                var sections = await DataStore.GetItemsAsync(true);
                foreach (var section in sections)
                {
                    Sections.Add(section);
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
            SelectedItem = null;
        }

        public MenuSection SelectedItem
        {
            get => _selectedSection;
            set
            {
                SetProperty(ref _selectedSection, value);
                OnItemSelected(value);
            }
        }

        async void OnItemSelected(MenuSection section)
        {
            if (section == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(MenuSectionDetailViewModel.SectionId)}={section.Id}");
        }
    }
}
