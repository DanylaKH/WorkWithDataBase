using System;
using System.Collections.Generic;
using System.Configuration;
using System.Collections.Specialized;
using System.Data.SqlClient;

namespace WorkWithDataBase
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What you want do now?");
            Console.WriteLine("1) Make new Order");
            Console.WriteLine("2) Show info about products");
            string userChoice = Console.ReadLine();
            if (userChoice == "1")
            {
                var connectionString = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\admin\\Downloads\\Products.mdf;Integrated Security=True;Connect Timeout=30");
                connectionString.Open();

                OrderService newService = new OrderService();
                ProductService productService = new ProductService();
                List<Order> orders = new List<Order>();

                productService.FillData();
                Console.WriteLine("Choice products");
                productService.ShowAllProducts();
                List<Product> orderProducts = new List<Product>();
                do
                {
                    
                    Console.WriteLine("Choice one product");
                    orderProducts = productService.BackProduct(Console.ReadLine());
                    Console.WriteLine("Another product?");
                } 
                while (Console.ReadLine() != "No");
                orders.Add(newService.MakeOrder(orderProducts));
                foreach (var order in orders)
                {
                    newService.AddEntity(order);
                }
                
            }
            if (userChoice == "2")
            {
                ProductService productService = new ProductService();
                Console.WriteLine("Choice products");
                productService.ShowAllProducts();
            }
         }      
    }   
}
