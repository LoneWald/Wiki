using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Wiki.Models;
using Xamarin.Forms;

namespace Wiki.ViewModels
{
    [QueryProperty(nameof(SectionId), nameof(SectionId))]
    public class MenuSectionDetailViewModel : BaseViewModel
    {
        private string sectionId;
        private string text;
        private string pathToImage;
        public string Id { get; set; }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string PathToImage
        {
            get => pathToImage;
            set => SetProperty(ref pathToImage, value);
        }

        public string SectionId
        {
            get
            {
                return sectionId;
            }
            set
            {
                sectionId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string sectionId)
        {
            try
            {
                var section = await DataStore.GetItemAsync(sectionId);
                Id = section.Id;
                Text = section.Text;
                PathToImage = section.PathToImage;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Section");
            }
        }
    }
}
