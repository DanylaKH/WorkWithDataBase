using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace WorkWithDataBase
{
    class Database 
    {
        DataSet dataSet = null;
        DataTable suppliers = null;
        DataTable orders = null;
        DataTable products = null;
        public void CreateDatabase()
        {
            dataSet = new DataSet("Store");
            suppliers = new DataTable("Suppliers");
            orders = new DataTable("Orders");
            products = new DataTable("Products");
            DataColumn productId = new DataColumn("ID", typeof(int));
            DataColumn productName = new DataColumn("Name", typeof(string));
            DataColumn productPrice = new DataColumn("Price", typeof(double));
            DataColumn productAmount = new DataColumn("Amount", typeof(int));

            products.Columns.AddRange(new DataColumn[] { productId, productName, productPrice, productAmount });

            DataRow row1 = products.NewRow();
            row1["ID"] = 1;
            row1["Name"] = "Egg";
            row1["Price"] = 68;
            row1["Amount"] = 390;

            DataRow row2 = products.NewRow();
            row2["ID"] = 2;
            row2["Name"] = "Milk";
            row2["Price"] = 23;
            row2["Amount"] = 120;

            DataRow row3 = products.NewRow();
            row3["ID"] = 3;
            row3["Name"] = "Tomato";
            row3["Price"] = 3.5;
            row3["Amount"] = 800;

            DataRow row4 = products.NewRow();
            row4["ID"] = 4;
            row4["Name"] = "Sugar (1kg)";
            row4["Price"] = 42;
            row4["Amount"] = 135;

            products.Rows.Add(row1);
            products.Rows.Add(row2);
            products.Rows.Add(row3);
            products.Rows.Add(row4);

            dataSet.Tables.Add(products);

            DataColumn ordersId = new DataColumn("ID", typeof(int));
            ordersId.Unique = true;
            ordersId.AutoIncrementSeed = 1;
            ordersId.AutoIncrementStep = 1;
            DataColumn ordersName = new DataColumn("Name", typeof(string));
            DataColumn ordersProduct = new DataColumn("Order Product", typeof(string));
            DataColumn ordersSoldAmount = new DataColumn("Sold Amount", typeof(int));

            orders.Columns.AddRange(new DataColumn[] { ordersId, ordersName, ordersProduct, ordersSoldAmount });

            DataRow row5 = orders.NewRow();
            row5["ID"] = 1;
            row5["Name"] = "First Order";
            row5["Order Product"] = "Egg";
            row5["Sold Amount"] = 50;

            DataRow row6 = orders.NewRow();
            row6["ID"] = 2;
            row6["Name"] = "Second Order";
            row6["Order Product"] = "Milk";
            row6["Sold Amount"] = 110;

            DataRow row7 = orders.NewRow();
            row7["ID"] = 3;
            row7["Name"] = "Third Order";
            row7["Order Product"] = "Tomato";
            row7["Sold Amount"] = 50;

            orders.Rows.Add(row5);
            orders.Rows.Add(row6);
            orders.Rows.Add(row7);

            dataSet.Tables.Add(orders);

            DataColumn supplierId = new DataColumn("ID", typeof(int));
            supplierId.Unique = true;
            supplierId.AutoIncrementSeed = 1;
            supplierId.AutoIncrementStep = 1;
            DataColumn supplierName = new DataColumn("Name", typeof(string));
            DataColumn supplierProduct = new DataColumn("Supplier Product", typeof(string));
            DataColumn supplierAmount = new DataColumn("Supplier Amount", typeof(string));

            suppliers.Columns.AddRange(new DataColumn[] { supplierId, supplierName, supplierProduct, supplierAmount });

            DataRow row8 = suppliers.NewRow();
            row8["ID"] = 1;
            row8["Name"] = "Nestle";
            row8["Supplier Product"] = "Milk";
            row8["Supplier Amount"] = 100;

            DataRow row9 = suppliers.NewRow();
            row9["ID"] = 2;
            row9["Name"] = "KurkaFarm";
            row9["Supplier Product"] = "Eggs";
            row9["Supplier Amount"] = 100;

            DataRow row10 = suppliers.NewRow();
            row10["ID"] = 3;
            row10["Name"] = "PolandTomat";
            row10["Supplier Product"] = "Tomato";
            row10["Supplier Amount"] = 100;

            DataRow row11 = suppliers.NewRow();
            row11["ID"] = 4;
            row11["Name"] = "BrazilSugar";
            row11["Supplier Product"] = "Sugar (1kg)";
            row11["Supplier Amount"] = 100;

            suppliers.Rows.Add(row8);
            suppliers.Rows.Add(row9);
            suppliers.Rows.Add(row10);
            suppliers.Rows.Add(row11);

            dataSet.Tables.Add(suppliers);
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
    }
}
