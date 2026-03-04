using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLib.Product
{
    class ProductRepository
    {
        private const string connStr = "server=st50-5;user=st50-5;database=shoes_store_EG;password=505;port=5432";

        public List<Product> GetAllProducts()
        {
            var products = new List<Product>();

            try
            {
                using (var connection = new MySqlConnection(connStr))
                {
                    connection.Open();

                    const string sql = "SELECT 'articul', 'name', 'unit', 'price', 'supplier', 'manufacturer', 'category', 'discount', 'count'," +
                        " 'description', 'pic' FROM 'products'";
                    using (var command = new MySqlCommand(sql, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var p = new Product(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetDecimal(3), reader.GetString(4),
                                reader.GetString(5), reader.GetString(6), reader.GetInt32(7), reader.GetInt32(8), reader.GetString(9), 
                                reader.GetString(10));
                            products.Add(p);
                        }
                    }
                }

                return products;
            }
            catch(Exception ex)
            {
                throw new Exception("Ошибка при чтении товаров", ex);
            }
        }
    }
}
