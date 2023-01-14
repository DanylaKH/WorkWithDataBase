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
                ProductService productOperator = new ProductService();
                productOperator.FillData();

                Console.WriteLine("Choice products");
                productOperator.ShowAllProducts();
                List<Product> orderProducts = new List<Product>();
                do
                {
                    Console.WriteLine("Choice one product");
                    orderProducts = productOperator.BackProduct(Console.ReadLine());
                    Console.WriteLine("Another product?");
                }
                while (Console.ReadLine() != "No");

                OrderService orderOperator = new OrderService();
                List<Order> orders = new List<Order>();
                orders.Add(orderOperator.MakeOrder(orderProducts));
                foreach (var order in orders)
                {
                    orderOperator.Add(order);
                }

            }
            if (userChoice == "2")
            {
                ProductService productOperator = new ProductService();
                productOperator.FillData();
                Console.WriteLine("Choice products");
                productOperator.ShowAllProducts();
            }
            if(userChoice == "3")
            {
                ProductService productOperator = new ProductService();
                productOperator.FillData();
                Console.WriteLine("Choice products");
                List<Product> updateProducts = productOperator.BackProduct(Console.ReadLine());
                foreach(Product product in updateProducts)
                {
                    productOperator.Delete(product);
                }
                
            }
            if (userChoice == "4")
            {
                ProductService productOperator = new ProductService();
                productOperator.FillData();
                Console.WriteLine("Choice products");
                List<Product> updateProducts = productOperator.BackProduct(Console.ReadLine());
                foreach (Product product in updateProducts)
                {
                    productOperator.Add(product);
                }
            }
            if (userChoice == "5")
            {
                ProductService productOperator = new ProductService();
                productOperator.FillData();
                Console.WriteLine("Choice products");
                List<Product> updateProducts = productOperator.BackProduct(Console.ReadLine());
                foreach (Product product in updateProducts)
                {
                    productOperator.Update(product);
                }
            }
        }      
    }   
}
