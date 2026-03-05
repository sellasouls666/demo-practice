using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLib.User
{
    public class UserService
    {
        private IUserRepository repository_;
        public User GetUserByLogin(string login)
        {
            return repository_.GetUserByLogin(login);
        }
    }
}
