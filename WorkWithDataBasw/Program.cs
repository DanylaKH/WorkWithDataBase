using System;
using System.Collections.Generic;
using System.Configuration;
using System.Collections.Specialized;




namespace WorkWithDataBase
{
    public class Program
    {
        static void Main(string[] args)
        {


            ProductService productService = new ProductService();
            productService.FillData();
            List<Order> orders = new List<Order>();
            Console.WriteLine("What you want do now?");
            Console.WriteLine("1) Make new Order");
            Console.WriteLine("2) Show info about all products");
            string userChoice = Console.ReadLine();
            if (userChoice == "1")
            {
                OrderService newService = new OrderService();
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
                foreach (var product in orderProducts)
                {
                    newService.UppdateRowDataBase(product.Name, Console.ReadLine());
                }
            }
            if (userChoice == "2")
            {
                Console.WriteLine("Choice products");
                productService.ShowAllProducts();
            }
         }      
    }   
}
