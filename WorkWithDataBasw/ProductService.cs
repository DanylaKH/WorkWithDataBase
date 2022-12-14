using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace WorkWithDataBase
{
    public class ProductService
    {
        private List<Product> Products;
        private List<Supplier> Suppliers;

        public void FillData()
        {
            using var conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\admin\\Downloads\\Products.mdf;Integrated Security=True;Connect Timeout=30");
            conn.Open();

            Products = GetData("Products", conn, x => new Product { Id = (int)x["ProductId"], Name = x["ProductName"].ToString() });
            Suppliers = GetData("Suppliers", conn, x => new Supplier { Id = (int)x["SuppliersId"], Name = x["SuppliersName"].ToString() });
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

        private List<TType> GetData<TType>(string tableName, SqlConnection conn, Func<SqlDataReader, TType> handler)
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
        }
    }
}
