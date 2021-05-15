using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wiki.Models.Users;
using Xamarin.Forms;

namespace Wiki.ViewModels
{
    public class AccountViewModel : BaseViewModel
    {

        public CurrentUser user;
        private string _nickname;

        public AccountViewModel()
        {
            this._nickname = CurrentUser.ThisUser?.nickname ?? string.Empty;
            CurrentUser.ThisUserChanged += () =>
            {
                this.Nickname = CurrentUser.ThisUser?.nickname ?? string.Empty;
                ThisUserChanged?.Invoke();
            };
            Title = "My Account";
            user = new CurrentUser();
        }


        public event Action ThisUserChanged;

        public string Nickname
        {
            get => _nickname;
            set
            {
                SetProperty(ref _nickname, value);
            }
        }
        public void We()
        {
                _nickname = "rer";
        }
    }


}
