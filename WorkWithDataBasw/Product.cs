using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using System.Linq;

namespace WorkWithDataBase
{
    class Product : Order
    {
        private List<int> productId = new List<int>();
        private List<string> productName = new List<string>();
        private List<int> productPrice = new List<int>();
        private List<int> productAmount = new List<int>();

        public Product()
        {
            string sqlQuery = string.Format("SELECT * FROM Products");
            //using (SqlConnection connectionString = new SqlConnection(ConfigurationManager.ConnectionStrings["TestBD"].ConnectionString))
            using (SqlConnection connectionString = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\admin\\source\\repos\\DanylaKH\\WorkWithDataBase\\WorkWithDataBasw\\Products.mdf; Integrated Security = True"))
            using (SqlCommand command = new SqlCommand(sqlQuery, connectionString))
            {
                connectionString.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        productId.Add(Convert.ToInt32(reader[0]));
                        productName.Add(Convert.ToString(reader[1]));
                        productPrice.Add(Convert.ToInt32(reader[2]));
                        productAmount.Add(Convert.ToInt32(reader[3]));
                    }
                }
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine("Please Choice a Product Name");
            string name = Console.ReadLine();

            Console.WriteLine("Info about product");
            for (int i = 0; i != productName.Count; i++)
            {
                if (productName[i].Contains(name))
                {
                    string result = Convert.ToString(productId[i]) + " " + productName[i] + " " + Convert.ToString(productPrice[i]) + " " + Convert.ToString(productAmount[i]);
                    Console.WriteLine(result);
                }
    
            }

            Console.WriteLine("Info about order");
            for (int i = 0; i != orderProduct.Count; i++)
            {
                if (orderProduct[i].Contains(name))
                {
                    string result = orderName[i] + " " + Convert.ToString(orderAmount[i]);
                    Console.WriteLine(result);
                }
            }

            Console.WriteLine("Info about supplier");
            for (int i = 0; i != supplierProduct.Count; i++)
            {
                if (supplierProduct[i].Contains(name))
                {
                    string result = supplierName[i] + " " + Convert.ToString(supplierAmount[i]);
                    Console.WriteLine(result);
                }
            }


            /*var newName =  productName.Where(x => x.Contains(name));

            foreach (var x in newName)
                Console.WriteLine(x);
            */
        }
    }
}
