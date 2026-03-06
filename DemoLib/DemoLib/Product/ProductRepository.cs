using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace DemoLib.Product
{
    public class ProductRepository : IProductRepository
    {
        private const string connStr = "Host=192.168.1.48;Port=5432;Database=shoes_store_EG;Username=st50-5;Password=505;";

        public List<Product> GetAllProducts()
        {
            var products = new List<Product>();

            try
            {
                using (var connection = new NpgsqlConnection(connStr))
                {
                    connection.Open();

                    const string sql = "SELECT articul, name, unit, price, supplier, manufacturer, category, discount, count," +
                        " description, pic FROM products";
                    using (var command = new NpgsqlCommand(sql, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var p = new Product(reader.GetString(0), 
                                reader.GetString(1), 
                                reader.GetString(2),
                                reader.GetDecimal(3), 
                                reader.GetString(4),
                                reader.GetString(5),
                                reader.GetString(6), 
                                reader.GetInt32(7),
                                reader.GetInt32(8),
                                reader.IsDBNull(9) ? "" : reader.GetString(9), 
                                reader.IsDBNull(10) ? "" : reader.GetString(10));
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

        public int GetProductsCount()
        {
            try
            {
                using (var connection = new NpgsqlConnection(connStr))
                {
                    connection.Open();

                    const string sql = "SELECT COUNT(articul) FROM products";
                    NpgsqlCommand command = new NpgsqlCommand(sql, connection);
                    int result = Convert.ToInt32(command.ExecuteScalar().ToString());
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddProduct(Product product)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connStr))
                {

                    connection.Open();
                    string addProductSql =
                                "INSERT INTO products (articul, name, unit, price, supplier, manufacturer, category, discount, count," +
                                " description, pic)"
                                + " VALUES (@articul, @name, @unit, @price, @supplier, @manufacturer, @category, @discount, @count," +
                                " @description, @pic)";
                    NpgsqlCommand command = new NpgsqlCommand(addProductSql, connection);

                    command.Parameters.AddWithValue("@articul", product.articul_);
                    command.Parameters.AddWithValue("@name", product.name_);
                    command.Parameters.AddWithValue("@unit", product.unit_);
                    command.Parameters.AddWithValue("@price", product.price_);
                    command.Parameters.AddWithValue("@supplier", product.supplier_);
                    command.Parameters.AddWithValue("@manufacturer", product.manufacturer_);
                    command.Parameters.AddWithValue("@category", product.category_);
                    command.Parameters.AddWithValue("@discount", product.discount_);
                    command.Parameters.AddWithValue("@count", product.count_);
                    command.Parameters.AddWithValue("@description", product.description_);
                    command.Parameters.AddWithValue("@pic", product.pic_);

                    command.ExecuteNonQuery();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
