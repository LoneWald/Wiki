using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki.Servises;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wiki.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewCharacterProfessionPage : ContentPage
    {
        public NewCharacterProfessionPage()
        {
            InitializeComponent();
        }

        async private void CreateProfessionClick(object sender, EventArgs e)
        {
            if (NameForm.Text == null)
            {
                var toastmessage = "Need to fill name";
                DependencyService.Get<ToastMessage>().ShortTime(toastmessage);
            }
            else
            {

                var characterProfessionApiServise = new CharacterProfessionApiServises();

                var content = await characterProfessionApiServise.AddCharacterProfessionAsync(NameForm.Text, DescriptionForm.Text);
                if (content != null)
                {

                    await Shell.Current.GoToAsync("..");
                }
                else
                {
                    var toastmessage = "Not Created";
                    DependencyService.Get<ToastMessage>().ShortTime(toastmessage);
                }
            }
        }
    }
}