using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace WorkWithDataBase
{
    public class ProductService : BaseSerice<Product>
    {
        private List<Product> Products;
        //private List<Supplier> Suppliers;

        Product testProduct = new Product();
        public void FillData()
        {
            Products = GetData(testProduct, x => new Product { Id = (int)x["ProductId"], Name = x["ProductName"].ToString() });
            //Suppliers = GetData("Suppliers", x => new Supplier { Id = (int)x["SuppliersId"], Name = x["SuppliersName"].ToString() });
        }

        /*private List<TType> GetData<TType>(string tableName, SqlConnection conn, Func<SqlDataReader, TType> handler)
        {
            var command = new SqlCommand($"select * from {tableName}", conn);
            using var reader = command.ExecuteReader();
            var entities = new List<TType>();

            while (reader.Read())
            {
                var entity = handler(reader);
                entities.Add(entity);
            }

            return entities;
        }*/

        public void ShowAllProducts()
        {
            foreach (var product in Products)
            {
                Console.WriteLine($"Product Name: {product.Name}");
            }
        }

        public List<Product> BackProduct(string pattern)
        {
            var products = Products.Where(x => x.Name.Contains(pattern));
            List<Product> newList = new List<Product>();

            foreach (var product in products)
            {
                newList.Add(product);
            }

            return newList;
        }

        public void SearchProducts(string pattern)
        {
            var products = Products.Where(x => x.Name.Contains(pattern));

            foreach (var product in products)
            {
                Console.WriteLine($"Product Name: {product.Name}");
            }
        }

        protected override SqlCommand CreateCommand(Product entity, string action)
        {
            if (action == "get")
            {
                var command = new SqlCommand("select * from  @tableName ");
                command.Parameters.AddWithValue("@tableName", "Products");
                return command;
            }
            if (action == "delete")
            {
                var command = new SqlCommand("delete from @tableName where ProductName = @productName");
                command.Parameters.AddWithValue("@tableName", "Products");
                Console.WriteLine("Write the name of the product to be removed");
                string productName = Console.ReadLine();
                command.Parameters.AddWithValue("@productName", productName);
                return command;
            }
            if (action == "update")
            {
                var command = new SqlCommand("update @tableName set ProductName = @newProductName, ProductPrice = @newProductPrice, ProductAmount = @newProductAmount where ProductName = @productName");
                command.Parameters.AddWithValue("@tableName", "Products");
                Console.WriteLine("write the name of the replacement product");
                string productName = Console.ReadLine();
                command.Parameters.AddWithValue("@productName", productName);
                Console.WriteLine("Write the new product name");
                string newProductName = Console.ReadLine();
                command.Parameters.AddWithValue("@newProductName", newProductName);
                Console.WriteLine("Write the new price");
                string newProductPrice = Console.ReadLine();
                command.Parameters.AddWithValue("@newProductPrice", newProductPrice);
                Console.WriteLine("Write the new amount");
                string newProductAmount = Console.ReadLine();
                command.Parameters.AddWithValue("@newProductAmount", newProductAmount);
                return command;
            }
            else
            {
                var command = new SqlCommand("INSERT INTO @tableName(ProductName, ProductPrice, ProductAmount) VALUES( @ProductName, @ProductPrice, @ProductAmount)");
                command.Parameters.AddWithValue("@tableName", "Products");
                Console.WriteLine("Insert Product Name");
                string productName = Console.ReadLine();
                command.Parameters.AddWithValue("@ProductName", productName);
                Console.WriteLine("Insert Product Name");
                string productPrice = Console.ReadLine();
                command.Parameters.AddWithValue("@ProductPrice", productPrice);
                Console.WriteLine("Insert Product Amount");
                string productAmount = Console.ReadLine();
                command.Parameters.AddWithValue("@ProductAmount", productAmount);
                return command;
            }


        }
    }
}
