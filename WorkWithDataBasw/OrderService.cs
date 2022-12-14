using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace WorkWithDataBase
{
    class OrderService : Order
    {
        public Order MakeOrder(List<Product> products)
        {
            Order newOrder = new Order();
            newOrder.Products = products;
            return newOrder;
        }
    }
}
