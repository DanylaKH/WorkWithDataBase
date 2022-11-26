using System;
using System.Data;
using System.IO;

namespace WorkWithDataBase
{
    public class Program
    {
        static void Main(string[] args)
        {
            string tableChoise = null;
            string operationChoise = null;
            Database db1 = new Database();
            db1.CreateDatabase();
            (tableChoise, operationChoise) = GetUserChoise();
            db1.ShowInfo(tableChoise, operationChoise);
        }

        static (string, string) GetUserChoise()
        {
            string tableChoise = null;
            string operationChoise = null;
            Console.WriteLine("Which table do you want to work with?");
            Console.WriteLine("1) Orders");
            Console.WriteLine("2) Product");
            Console.WriteLine("3) Supplier");
            tableChoise = Console.ReadLine();
            if (tableChoise == "1")
            {
                Console.WriteLine("Select operation type");
                Console.WriteLine("1) Show all orders");
                Console.WriteLine("2) Show order where sold amount less 100");
                operationChoise = Console.ReadLine();
            }
            if (tableChoise == "2")
            {
                Console.WriteLine("Select operation type");
                Console.WriteLine("1) Show all products");
                Console.WriteLine("2) Show Products where price less 30");
                Console.WriteLine("3) Show products where amount more 200");
                operationChoise = Console.ReadLine();
            }
            if (tableChoise == "3")
            {
                Console.WriteLine("Select operation type");
                Console.WriteLine("1) Show all Suppliers");
                operationChoise = Console.ReadLine();
            }
            if(tableChoise != "3" && tableChoise != "2" && tableChoise != "1")
                throw new Exception("Error change table");
            return (tableChoise, operationChoise);
        }
    }
}
