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
            Console.WriteLine("3) Delete Product");
            Console.WriteLine("4) Add Product");
            Console.WriteLine("5) Update Product");
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
                    newService.UpdateInfo(newService.CreateAddCommand, order);
                }
                
            }
            if (userChoice == "2")
            {
                ProductService productService = new ProductService();
                Console.WriteLine("Choice products");
                productService.ShowAllProducts();
            }
            if(userChoice == "3")
            {
                ProductService productService = new ProductService();
                Console.WriteLine("Choice products");
                List<Product> updateProducts = productService.BackProduct(Console.ReadLine());
                foreach(Product product in updateProducts)
                {
                    productService.UpdateInfo(productService.CreateDeleteCommand, product);
                }
                
            }
            if (userChoice == "4")
            {
                ProductService productService = new ProductService();
                Console.WriteLine("Choice products");
                List<Product> updateProducts = productService.BackProduct(Console.ReadLine());
                foreach (Product product in updateProducts)
                {
                    productService.UpdateInfo(productService.CreateAddCommand, product);
                }
            }
            if (userChoice == "5")
            {
                ProductService productService = new ProductService();
                Console.WriteLine("Choice products");
                List<Product> updateProducts = productService.BackProduct(Console.ReadLine());
                foreach (Product product in updateProducts)
                {
                    productService.UpdateInfo(productService.CreateUpdateCommand, product);
                }
            }
        }      
    }   
}
