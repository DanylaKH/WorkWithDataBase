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
            using var conn = new SqlConnection("");
            conn.Open();

            Products = GetData("Products", conn, x => new Product { Id = (int)x["Id"], Name = x["Name"].ToString() });
            Suppliers = GetData("Suppliers", conn, x => new Supplier { Id = (int)x["Id"], Name = x["Name"].ToString() });
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
