using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace WorkWithDataBase
{
    class OrderService : BaseSerice<Order>
    {
        public Order MakeOrder(List<Product> products)
        {
            Order newOrder = new Order();
            newOrder.Products = products;
            return newOrder;
        }

        protected override SqlCommand CreateCommand(Order entity)
        {
            Console.WriteLine("Insert Order Name");
            string orderName = Console.ReadLine();
            var command = new SqlCommand("INSERT INTO Orders(OrderProduct, OrderName) VALUES( @OrderProduct, @OrderName)");
            command.Parameters.AddWithValue("@OrderProduct", entity.Products[0].Id);
            command.Parameters.AddWithValue("@OrderName", orderName);
            return command;
        }
    }
}
    

