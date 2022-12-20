using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace WorkWithDataBase
{
    class OrderService : IConnectDataBase
    {
        public string ConnectDB()
        {
            return "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\admin\\Downloads\\Products.mdf; Integrated Security = True; Connect Timeout = 30";
        }

        //string sAttr = ConfigurationManager.AppSettings.Get("ConnectionString");


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
                var conn = new SqlConnection(ConnectDB());
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Orders (OrderProduct, OrderName) VALUES('" + products + "','" + orderName + "')", conn);
                cmd.Parameters.Add("prdoucts", SqlDbType.VarChar, 11);
                cmd.Parameters.Add("orderName", SqlDbType.VarChar, 11);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("DataBase Error");
            } 
        }
    }
}
    

