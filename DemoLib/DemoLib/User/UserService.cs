using DemoLib.Product;
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
        public UserService()
        {
            repository_ = new UserRepository(); 
        }
        public User GetUserByLogin(string login)
        {
            return repository_.GetUserByLogin(login);
        }

        public List<string> GetUsersLogins()
        {
            List<User> allUsers = repository_.GetAllUsers();

            List<string> logins = new List<string>();
            foreach (User user in allUsers)
            {
                logins.Add(user.login_);
            }

            return logins;
        }
    }
}
