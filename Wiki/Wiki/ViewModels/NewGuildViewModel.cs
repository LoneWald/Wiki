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
    class NewGuildViewModel : BaseViewModel
    {
        public NewGuildViewModel()
        {
            Title = "Creating Guild";
        }

    }
}
