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
    public partial class AllCharacterClassesPage : ContentPage
    {
        AllCharacterClassesPageViewModel _viewModel;
        public AllCharacterClassesPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new AllCharacterClassesPageViewModel();
            RefreshClasses();
        }

        public void RefreshClasses()
        {
            _viewModel.IsBusy = true;
        }

        async private void CreateCharacterClassClick(object sender, EventArgs e)
        {

            Routing.RegisterRoute("NewCharacterClassPage", typeof(NewCharacterClassPage));
            await Shell.Current.GoToAsync("NewCharacterClassPage");
        }
    }
}