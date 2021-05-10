using System;
using Wiki.Services;
using Wiki.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wiki
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MenuSectionsDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
