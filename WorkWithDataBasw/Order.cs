using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;



namespace WorkWithDataBase
{
    class Order
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; }

        public void MakeOrder(List<Product> products)
        {
            using var conn = new SqlConnection("");
            conn.Open();
            SqlDataAdapter querryString = new SqlDataAdapter("SELECT ProductId, ProductName FROM Products", conn);
            querryString.SelectCommand.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i != products.Count; i++)
            { 
                SqlParameter parm = (SqlParameter)(querryString.SelectCommand.Parameters.Add("ProductId", SqlDbType.Int).Value = products[i].Id);
                parm = (SqlParameter)(querryString.SelectCommand.Parameters.Add("ProductName", SqlDbType.NVarChar).Value = products[i].Name);
            }
        }
    }
}



