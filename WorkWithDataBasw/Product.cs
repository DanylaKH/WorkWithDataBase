using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using System.Linq;

namespace WorkWithDataBase
{
    public class Product : Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Supplier Supplier { get; set; }
    }


}
