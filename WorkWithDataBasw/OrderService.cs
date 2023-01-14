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

        protected override SqlCommand CreateAddCommand(Order entity)
        {
            Console.WriteLine("Insert Order Name");
            string orderName = Console.ReadLine();
            var command = new SqlCommand("INSERT INTO Orders(OrderProduct, OrderName) VALUES( @OrderProduct, @OrderName)");
            command.Parameters.AddWithValue("@OrderProduct", entity.Products[0].Id);
            command.Parameters.AddWithValue("@OrderName", orderName);
            return command;
        }
        protected override SqlCommand CreateDeleteCommand(Order entity)
        {
            var command = new SqlCommand("delete from @tableName where OrderName = @orderName");
            command.Parameters.AddWithValue("@tableName", "Orders");
            command.Parameters.AddWithValue("@orderName", entity.Id);
            return command;
        }

        protected override SqlCommand CreateGetCommand()
        {
            var command = new SqlCommand("select * from  @tableName");
            command.Parameters.AddWithValue("@tableName", "Orders");
            return command;
        }

        protected override SqlCommand CreateUpdateCommand(Order entity)
        {
            var command = new SqlCommand("update @tableName set OrderName = @newOrderName, OrderProduct = @newOrderProduct where OrderName = @orderName");
            command.Parameters.AddWithValue("@tableName", "Orders");
            Console.WriteLine("Write the name of the replacement order");
            string orderName = Console.ReadLine();
            command.Parameters.AddWithValue("@orderName", orderName);
            Console.WriteLine("Write the new order name");
            string newOrderName = Console.ReadLine();
            command.Parameters.AddWithValue("@newOrderName", newOrderName);
            command.Parameters.AddWithValue("@newOrderProduct", entity.Products[0].Id);
            return command;
        }
    }
}
    

