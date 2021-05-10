using System;
using System.Collections.Generic;
using Wiki.ViewModels;
using Wiki.Views;
using Xamarin.Forms;

namespace Wiki
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
        }

    }
}
