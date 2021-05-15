using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wiki.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MenuViewModel _viewModel;
        public MenuPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new MenuViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}