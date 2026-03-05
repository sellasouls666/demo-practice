using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace DemoLib.User
{
    public class UserRepository : IUserRepository
    {
        private const string connStr = "Host=192.168.1.48;Port=5432;Database=shoes_store_EG;Username=st50-5;Password=505;";

        public User GetUserByLogin(string login)
        {
            if (string.IsNullOrWhiteSpace(login))
                return null;

            try
            {
                using (var connection = new NpgsqlConnection(connStr))
                {
                    connection.Open();

                    const string sql = "SELECT role, fio, login, password FROM users WHERE login = @login LIMIT 1";
                    using (var command = new NpgsqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@login", login);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new User
                                (
                                    reader.GetString(0),
                                    reader.GetString(1),
                                    reader.GetString(2),
                                    reader.GetString(3)
                                );
                            }
                        }
                    }
                }

                return null;
            }
            catch(Exception ex)
            {
                throw new Exception($"Ошибка при поиске пользователя с логином '{login}'.", ex);
            }
        }

        public List<User> GetAllUsers()
        {
            var users = new List<User>();

            try
            {
                using (var connection = new NpgsqlConnection(connStr))
                {
                    connection.Open();

                    const string sql = "SELECT role, fio, login, password FROM users";
                    using (var command = new NpgsqlCommand(sql, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var u = new User
                                (
                                    reader.GetString(0),
                                    reader.GetString(1),
                                    reader.GetString(2),
                                    reader.GetString(3)
                                );
                            users.Add(u);
                        }
                    }
                }

                return users;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при чтении списка пользователей из БД.", ex);
            }
        }
    }
}
