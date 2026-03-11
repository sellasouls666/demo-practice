using DemoLib.Order;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLib.Pickup
{
    public class PickupRepository : IPickupRepository
    {
        private const string connStr = "Host=192.168.1.48;Port=5432;Database=shoes_store_EG;Username=st50-5;Password=505;";

        public string GetPickupAddress(int idPickup)
        {
            using (var connection = new NpgsqlConnection(connStr))
            {
                connection.Open();
                const string sql = "SELECT address FROM pickups WHERE id = @id";
                using (var command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", idPickup);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetString(0);
                        }
                        return null;
                    }
                }
            }
        }

        public List<Pickup> GetAllPickups()
        {
            var pickups = new List<Pickup>();

            try
            {
                using (var connection = new NpgsqlConnection(connStr))
                {
                    connection.Open();

                    const string sql = "SELECT address, id FROM pickups";
                    using (var command = new NpgsqlCommand(sql, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var p = new Pickup();
                            p.address_ = reader.GetString(0);
                            p.id_ = reader.GetInt32(1);
                            pickups.Add(p);
                        }
                    }
                }

                return pickups;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при чтении пунктов выдачи", ex);
            }
        }
    }
}
