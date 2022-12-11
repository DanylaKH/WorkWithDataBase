using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace WorkWithDataBase
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProductService productService = new ProductService();
            productService.FillData();
        }
    }   
}
