using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;



namespace WorkWithDataBase
{
    public class Order
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; }
    }
}



