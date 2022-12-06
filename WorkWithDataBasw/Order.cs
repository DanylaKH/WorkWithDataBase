using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;



namespace WorkWithDataBase
{
    class Order : Suppliers
    {
        public List<int> orderId = new List<int>();
        public List<string> orderName = new List<string>();
        public List<string> orderProduct = new List<string>();
        public List<int> orderAmount = new List<int>();

        public Order()
        {
            string sqlQuery = string.Format("SELECT * FROM Orders");
            //using (SqlConnection connectionString = new SqlConnection(ConfigurationManager.ConnectionStrings["TestBD"].ConnectionString))
            using (SqlConnection connectionString = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\admin\\source\\repos\\DanylaKH\\WorkWithDataBase\\WorkWithDataBasw\\Products.mdf; Integrated Security = True"))
            using (SqlCommand command = new SqlCommand(sqlQuery, connectionString))
            {
                connectionString.Open();
                using(SqlDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        orderId.Add(Convert.ToInt32(reader[0]));
                        orderName.Add(Convert.ToString(reader[1]));
                        orderProduct.Add(Convert.ToString(reader[2]));
                        orderAmount.Add(Convert.ToInt32(reader[3]));
                    }
                }
            }
        }
    }
}
