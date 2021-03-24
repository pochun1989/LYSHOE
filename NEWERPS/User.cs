using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NEWERPS

{
    class User
    {
        private string _userID;
        private string _userName;
        private string _password;

        public string userID { get => _userID; set => _userID = value; }
        public string userName { get => _userName; set => _userName = value; }
        public string password { get => _password; set => _password = value; }


    }
}
