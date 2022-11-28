using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace WorkWithDataBase
{
    class Database : IDataBaseConnect
    {
        DataSet dataSet = null;
        DataTable suppliers = null;
        DataTable orders = null;
        DataTable products = null;
        public void CreateDatabase()
        {
            dataSet = new DataSet("Store");

            products = new DataTable("Products");
            DataColumn productId = new DataColumn("ID", typeof(int));
            DataColumn productName = new DataColumn("Name", typeof(string));
            DataColumn productPrice = new DataColumn("Price", typeof(int));
            DataColumn productAmount = new DataColumn("Amount", typeof(int));
            products.Columns.AddRange(new DataColumn[] { productId, productName, productPrice, productAmount });
            AddRowInTableProduct();
            dataSet.Tables.Add(products);

            suppliers = new DataTable("Suppliers");
            DataColumn supplierId = new DataColumn("ID", typeof(int));
            DataColumn supplierName = new DataColumn("Name", typeof(string));
            DataColumn supplierProduct = new DataColumn("Supplier Product", typeof(string));
            DataColumn supplierAmount = new DataColumn("Supplier Amount", typeof(string));
            suppliers.Columns.AddRange(new DataColumn[] { supplierId, supplierName, supplierProduct, supplierAmount });
            AddRowInTableSuppliers();
            dataSet.Tables.Add(suppliers);

            orders = new DataTable("Orders");
            DataColumn ordersId = new DataColumn("ID", typeof(int));
            DataColumn ordersName = new DataColumn("Name", typeof(string));
            DataColumn ordersProduct = new DataColumn("Order Product", typeof(string));
            DataColumn ordersSoldAmount = new DataColumn("Sold Amount", typeof(int));
            orders.Columns.AddRange(new DataColumn[] { ordersId, ordersName, ordersProduct, ordersSoldAmount });
            AddRowInTableOrders();
            dataSet.Tables.Add(orders);
        }  

        private void AddRowInTableProduct()
        {
            string queryString = "SELECT * FROM Products";
            SqlConnection connectionString = new SqlConnection(ConnectDB());
            connectionString.Open();
            SqlCommand comand = new SqlCommand(queryString, connectionString);
            SqlDataReader dataReader = comand.ExecuteReader();
            List<int> id = new List<int>();
            List<string> name = new List<string>();
            List<double> price = new List<double>();
            List<int> amount = new List<int>();
            while (dataReader.Read())
            {
                id.Add(dataReader.GetInt32(0));
                name.Add(dataReader.GetString(1));
                price.Add(dataReader.GetInt32(2));
                amount.Add(dataReader.GetInt32(3));
            }
            dataReader.Close();
            
            for (int i = 0; i < id.Count; i++)
            {

                DataRow row = products.NewRow();
                row["ID"] = id[i];
                row["Name"] = name[i];
                row["Price"] = price[i];
                row["Amount"] = amount[i];
                products.Rows.Add(row); 
            }
            
        }

        private void AddRowInTableSuppliers()
        {
            string queryString = "SELECT * FROM Suppliers";
            SqlConnection connectionString = new SqlConnection(ConnectDB());
            connectionString.Open();
            SqlCommand comand = new SqlCommand(queryString, connectionString);
            SqlDataReader dataReader = comand.ExecuteReader();
            List<int> id = new List<int>();
            List<string> name = new List<string>();
            List<string> product = new List<string>();
            List<int> amount = new List<int>();
            while (dataReader.Read())
            {
                id.Add(dataReader.GetInt32(0));
                name.Add(dataReader.GetString(1));
                product.Add(dataReader.GetString(2));
                amount.Add(dataReader.GetInt32(3));
            }
            dataReader.Close();

            for (int i = 0; i < id.Count; i++)
            {
                DataRow row = suppliers.NewRow();
                row["ID"] = id[i];
                row["Name"] = name[i];
                row["Product"] = product[i];
                row["Amount"] = amount[i];
                suppliers.Rows.Add(row);
            }
        }

        private void AddRowInTableOrders()
        {
            string queryString = "SELECT * FROM Orders";
            SqlConnection connectionString = new SqlConnection(ConnectDB());
            connectionString.Open();
            SqlCommand comand = new SqlCommand(queryString, connectionString);
            SqlDataReader dataReader = comand.ExecuteReader();
            List<int> id = new List<int>();
            List<string> name = new List<string>();
            List<string> product = new List<string>();
            List<int> amount = new List<int>();
            while (dataReader.Read())
            {
                id.Add(dataReader.GetInt32(0));
                name.Add(dataReader.GetString(1));
                product.Add(dataReader.GetString(2));
                amount.Add(dataReader.GetInt32(3));
            }
            dataReader.Close();

            for (int i = 0; i < id.Count; i++)
            {
                DataRow row = orders.NewRow();
                row["ID"] = id[i];
                row["Name"] = name[i];
                row["Product"] = product[i];
                row["Amount"] = amount[i];
                orders.Rows.Add(row);
            }
        }

        public void ShowInfo(string tableChoise, string operationChoise) 
        {
            if (tableChoise == "1" && operationChoise == "1")
            {
                foreach(DataRow r in orders.Rows)
                {
                    foreach (var cell in r.ItemArray)
                        Console.WriteLine("{0}\t", cell);
                    
                }
            }
            if (tableChoise == "1" && operationChoise == "2")
            {
                var selected = orders.Select("[Sold Amount] < 100");
                for(int i = 0; i < selected.Length; i++)
                {
                    Console.WriteLine(selected[i][1]);
                }
            }
            if (tableChoise == "2" && operationChoise == "1")
            {
                foreach (DataRow r in products.Rows)
                {
                    foreach (var cell in r.ItemArray)
                        Console.WriteLine("{0}\t", cell);

                }
            }
            if(tableChoise == "2" && operationChoise == "2")
            {
                var selected = products.Select("[Price] < 30");
                for (int i = 0; i < selected.Length; i++)
                {
                    Console.WriteLine(selected[i][1]);
                }
            }
            if (tableChoise == "2" && operationChoise == "3")
            {
                var selected = products.Select("[Amount] > 200");
                for (int i = 0; i < selected.Length; i++)
                {
                    Console.WriteLine(selected[i][1]);
                }
            }
            if (tableChoise == "3" && operationChoise == "1")
            {
                foreach (DataRow r in suppliers.Rows)
                {
                    foreach (var cell in r.ItemArray)
                        Console.WriteLine("{0}\t", cell);

                }
            }
        }

        public string ConnectDB()
        {
            string connect = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\admin\\Source\\Repos\\DanylaKH\\WorkWithDataBase\\WorkWithDataBasw\\Products.mdf;Integrated Security=True";
            return connect;
        }
    }
}
