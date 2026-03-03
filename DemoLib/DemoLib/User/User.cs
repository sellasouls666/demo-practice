using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLib.User
{
    class User
    {
        public string role_ { get; set; }
        public string fio_ { get; set; }
        public string login_ { get; set; }
        public string password_ { get; set; }

        public User(string role, string fio, string login, string password)
        {
            role_ = role;
            fio_ = fio;
            login_ = login;
            password_ = password;
        }
    }
}
