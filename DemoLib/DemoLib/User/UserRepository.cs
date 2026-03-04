using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLib.User
{
    class UserRepository
    {
        private const string connStr = "server=st50-5;user=st50-5;database=shoes_store_EG;password=505;port=5432";

        public List<User> GetAllUsers()
        {
            return null;
        }
    }
}
