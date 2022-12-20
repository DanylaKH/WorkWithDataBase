using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace WorkWithDataBase
{
    class OrderService 
    {
        public Order MakeOrder(List<Product> products)
        {
            Order newOrder = new Order();
            newOrder.Products = products;
            return newOrder;
        }

        public void UppdateRowDataBase(string products, string orderName, SqlConnection connectionString)
        {
            try
            {
                //string sAttr = ConfigurationManager.AppSettings["ConnectionString"];
                //var connectionString = new SqlConnection(sAttr);
                
                //connectionString.Open();
                SqlCommand cmd = new SqlCommand($"INSERT INTO Orders (OrderProduct, OrderName) VALUES(@OrderProduct, @OrderName)", connectionString);
                cmd.Parameters.AddWithValue("@OrderProduct", products);
                cmd.Parameters.AddWithValue("@OrderName", orderName);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("DataBase Error");
            } 
        }
    }
}
    

