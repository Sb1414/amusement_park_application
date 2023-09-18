using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amusement_park
{
    internal class User
    {
        private int id { get; set; }
        private string login, password;

        public User() { }
        public User(string login, string password)
        {
            this.login = login;
            this.password = password;
        }
    }
}
