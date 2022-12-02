using System;
using System.Data;
using System.IO;

namespace WorkWithDataBase
{
    public class Program
    {
        static void Main(string[] args)
        {
            Database db1 = new Database();
            string query = GetUserChoise();
            db1.ShowInfo(query);
        }

        static string GetUserChoise()
        {
            string query = "SELECT ProductName, ProductPrice, ProductAmount, SuppliersName FROM Products JOIN Suppliers ON ProductSupplier = SuppliersID WHERE ProductName LIKE ";
            Console.WriteLine("Please choice product name");
            query += "'%" + Console.ReadLine() + "%'";
            return query;
        }
    }
}
