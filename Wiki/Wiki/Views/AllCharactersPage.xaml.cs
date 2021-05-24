using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wiki.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllCharactersPage : ContentPage
    {
        AllCharactersPageViewModel _viewModel;

        public AllCharactersPage()
        {
            
            InitializeComponent();
            BindingContext = _viewModel = new AllCharactersPageViewModel();
            RefreshCharacters();
        }

        public void RefreshCharacters()
        {
            _viewModel.IsBusy = true;
        }
    }
}