using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace WorkWithDataBase
{
    class OrderService : Order
    {
        public Order MakeOrder(List<Product> products)
        {
            Order newOrder = new Order();
            newOrder.Products = products;
            return newOrder;
        }

        public void UppdateRowDataBase(string products, string orderName)
        {
            try
            {
                using var conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\admin\\Downloads\\Products.mdf;Integrated Security=True;Connect Timeout=30");
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Orders (OrderProduct, OrderName) VALUES('" + products + "','" + orderName + "')", conn);
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                Console.WriteLine("DataBase Error");
            }
        }
    }
}
