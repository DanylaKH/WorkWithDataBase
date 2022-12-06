using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace WorkWithDataBase
{
    class Suppliers
    {
        public List<int> supplierId = new List<int>();
        public List<string> supplierName = new List<string>();
        public List<string> supplierProduct = new List<string>();
        public List<int> supplierAmount = new List<int>();

        public Suppliers()
        {
            string sqlQuery = string.Format("SELECT * FROM Suppliers");
            //using (SqlConnection connectionString = new SqlConnection(ConfigurationManager.ConnectionStrings["TestBD"].ConnectionString))
            using (SqlConnection connectionString = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\admin\\source\\repos\\DanylaKH\\WorkWithDataBase\\WorkWithDataBasw\\Products.mdf; Integrated Security = True"))
            using (SqlCommand command = new SqlCommand(sqlQuery, connectionString))
            {
                connectionString.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        supplierId.Add(Convert.ToInt32(reader[0]));
                        supplierName.Add(Convert.ToString(reader[1]));
                        supplierProduct.Add(Convert.ToString(reader[2]));
                        supplierAmount.Add(Convert.ToInt32(reader[3]));
                    }
                }
            }
        }
    }
}
