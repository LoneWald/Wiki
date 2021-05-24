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
    public partial class AllCharacterProfessionsPage : ContentPage
    {
        AllCharacterProfessionsPageViewModel _viewModel;
        public AllCharacterProfessionsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new AllCharacterProfessionsPageViewModel();
            RefreshProfessions();
        }

        public void RefreshProfessions()
        {
            _viewModel.IsBusy = true;
        }

        async private void CreateCharacterProfessionClick(object sender, EventArgs e)
        {

            Routing.RegisterRoute("NewCharacterProfessionPage", typeof(NewCharacterProfessionPage));
            await Shell.Current.GoToAsync("NewCharacterProfessionPage");
        }
    }
}