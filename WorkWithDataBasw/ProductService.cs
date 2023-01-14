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
        

        
        public void FillData()
        {
            Products = GetData( x => new Product { Id = (int)x["ProductId"], Name = x["ProductName"].ToString() });
        }

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

        protected override SqlCommand CreateGetCommand()
        {
            var command = new SqlCommand("select * from  @tableName ");
            command.Parameters.AddWithValue("@tableName", "Products");
            return command;
        }

        protected override SqlCommand CreateAddCommand(Product entity)
        {
            var command = new SqlCommand("INSERT INTO @tableName(ProductName, ProductPrice, ProductAmount) VALUES( @ProductName, @ProductPrice, @ProductAmount)");
            command.Parameters.AddWithValue("@tableName", "Products");
            command.Parameters.AddWithValue("@ProductName", entity.Name);
            Random rnd = new Random();
            string productPrice = Convert.ToString(rnd.Next(2, 70));
            string productAmount = Convert.ToString(rnd.Next(100, 700));
            command.Parameters.AddWithValue("@ProductPrice", productPrice);
            command.Parameters.AddWithValue("@ProductAmount", productAmount);
            return command;
        }

        protected override SqlCommand CreateDeleteCommand(Product entity)
        {
            var command = new SqlCommand("delete from @tableName where ProductName = @productName");
            command.Parameters.AddWithValue("@tableName", "Products");
            command.Parameters.AddWithValue("@productName", entity.Name);
            return command;
        }

        protected override SqlCommand CreateUpdateCommand(Product entity)
        {
            var command = new SqlCommand("update @tableName set ProductName = @newProductName, ProductPrice = @newProductPrice, ProductAmount = @newProductAmount where ProductName = @productName");
            command.Parameters.AddWithValue("@tableName", "Products");
            command.Parameters.AddWithValue("@productName", entity.Name);
            Console.WriteLine("Write the new product name");
            string newProductName = Console.ReadLine();
            command.Parameters.AddWithValue("@newProductName", newProductName);
            Random rnd = new Random();
            string newProductPrice = Convert.ToString(rnd.Next(2, 70));
            string newProductAmount = Convert.ToString(rnd.Next(100, 700));
            command.Parameters.AddWithValue("@newProductPrice", newProductPrice);
            command.Parameters.AddWithValue("@newProductAmount", newProductAmount);
            return command;
        }
    }
}
