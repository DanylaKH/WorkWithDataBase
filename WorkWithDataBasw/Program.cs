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
            if (query == "Error")
                Console.WriteLine("Error selecting SQL query");
            else
            {
                db1.ShowInfo(query);
            }
            
        }

        static string GetUserChoise()
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
                    if (operationChoise == "1")
                        return ("SELECT * FROM orders");
                    if (operationChoise == "2")
                        return ("SELECT * FROM Orders WHERE OrdersAmount < 100");
                }
                if (tableChoise == "2")
                {
                    Console.WriteLine("Select operation type");
                    Console.WriteLine("1) Show all products");
                    Console.WriteLine("2) Show Products where price less 30");
                    Console.WriteLine("3) Show products where amount more 200");
                    operationChoise = Console.ReadLine();
                    if (operationChoise == "1")
                        return ("SELECT * FROM products");
                    if (operationChoise == "2")
                        return ("SELECT * FROM products WHERE ProductPrice < 30");
                    if (operationChoise == "3")
                        return ("SELECT * FROM products WHERE ProductAmount > 200");
                }
                if (tableChoise == "3")
                {
                    Console.WriteLine("Select operation type");
                    Console.WriteLine("1) Show all Suppliers");
                    operationChoise = Console.ReadLine();
                    if (operationChoise == "1")
                        return ("SELECT * FROM Suppliers");
                }
            return "Error";
        }
    }
}
