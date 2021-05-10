using System.ComponentModel;
using Wiki.ViewModels;
using Xamarin.Forms;

namespace Wiki.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new MenuSectionDetailViewModel();
        }
    }
}