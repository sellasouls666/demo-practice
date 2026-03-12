using DemoLib.Product;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLib.Order
{
    public class OrderRepository : IOrderRepository
    {
        private const string connStr = "Host=192.168.1.48;Port=5432;Database=shoes_store_EG;Username=st50-5;Password=505;";

        public List<Order> GetAllOrders()
        {
            var orders = new List<Order>();

            try
            {
                using (var connection = new NpgsqlConnection(connStr))
                {
                    connection.Open();
                    const string sql = "SELECT id, \"orderDate\", \"delieveryDate\", \"idPickup\", fio, code, status, \"userLogin\" FROM orders";
                    using (var command = new NpgsqlCommand(sql, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var o = new Order();
                            o.id_ = reader.GetInt32(0);
                            o.orderDate_ = reader.GetDateTime(1);
                            o.delieveryDate_ = reader.GetDateTime(2);
                            o.idPickup_ = reader.GetInt32(3);
                            o.fio_ = reader.IsDBNull(4) ? null : reader.GetString(4);
                            o.code_ = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);
                            o.status_ = reader.GetString(6);
                            o.userLogin_ = reader.IsDBNull(7) ? null : reader.GetString(7);
                            orders.Add(o);
                        }
                    }
                }
                foreach (Order o in orders)
                {
                    o.orderProducts = GetAllOrderProducts(o.id_);
                }
                return orders;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при чтении заказов", ex);
            }
        }

        public List<OrderProductRecord> GetAllOrderProducts(int orderId)
        {
            var orderProducts = new List<OrderProductRecord>();

            try
            {
                using (var connection = new NpgsqlConnection(connStr))
                {
                    connection.Open();

                    const string sql = "SELECT id, articul, quantity FROM \"orderProducts\" WHERE \"orderId\" = @orderId";
                    using (var command = new NpgsqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@orderId", orderId);
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var op = new OrderProductRecord();
                                op.id_ = reader.GetInt32(0);
                                op.articul_ = reader.GetString(1);
                                op.quantity_ = reader.GetInt32(2);
                                orderProducts.Add(op);
                            }
                        }
                    }
                }

                return orderProducts;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при чтении товаров в заказе", ex);
            }
        }

        public void AddOrder(Order order)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connStr))
                {

                    connection.Open();
                    string addOrderSql =
                                "INSERT INTO orders (id, status, \"idPickup\", \"orderDate\", \"delieveryDate\")"
                                + " VALUES (@id, @status, @idPickup, @orderDate, @delieveryDate)";
                    NpgsqlCommand command = new NpgsqlCommand(addOrderSql, connection);

                    command.Parameters.AddWithValue("@id", order.id_);
                    command.Parameters.AddWithValue("@status", order.status_);
                    command.Parameters.AddWithValue("@idPickup", order.idPickup_);
                    command.Parameters.AddWithValue("@orderDate", order.orderDate_);
                    command.Parameters.AddWithValue("@delieveryDate", order.delieveryDate_);

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
