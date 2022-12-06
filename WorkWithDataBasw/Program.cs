using System;
using System.Data;
using System.IO;

namespace WorkWithDataBase
{
    public class Program
    {
        static void Main(string[] args)
        {
            Suppliers sup1 = new Suppliers();
            Order or1 = new Order();
            Product pr1 = new Product();
            pr1.ShowInfo();
        }

    }   
}
