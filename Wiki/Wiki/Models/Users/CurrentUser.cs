using Wiki.Models.Login;
using Wiki.Models.Register;
using System;
using System.Collections.Generic;
using System.Text;
using GameWiki.Models;

namespace Wiki.Models.Users
{
    public class CurrentUser : Account
    {
        protected static CurrentUser _ThisUser;
        public static CurrentUser ThisUser
        {
            get
            {
                return _ThisUser;
            }
            set 
            {
                _ThisUser = value;
                ThisUserChanged?.Invoke();
            }
        }

        public static event Action ThisUserChanged;



        public CurrentUser()
            : base()
        {
        }

        public CurrentUser(RegisterApiResponseModel user)
            :base(user)
        {
        }

        public CurrentUser(LoginApiResponseModel user)
            : base(user)
        {
        }
    }
}
