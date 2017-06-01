using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atest.Pages.Data
{
    public struct UserData
    {
        public string userEmail;
        public string userPass;

        public UserData(string email, string password)
        {
            userEmail = email;
            userPass = password;
        }
    }
}
