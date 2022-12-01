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
        
        public void ShowInfo(string querry)
        {
            CopyInfoFromDB(querry);
            foreach (DataTable dt in dataSet.Tables)
            {
                Console.WriteLine(dt.TableName); 
                foreach (DataColumn column in dt.Columns)
                    Console.Write("\t{0}", column.ColumnName);
                Console.WriteLine();
                foreach (DataRow row in dt.Rows)
                {
                    var cells = row.ItemArray;
                    foreach (object cell in cells)
                        Console.Write("\t{0}", cell);
                    Console.WriteLine();
                }
            }
        }
        

        private void CopyInfoFromDB(string querry) 
        {
            SqlConnection connectionString = new SqlConnection(ConnectDB());
            connectionString.Open();
            dataSet = new DataSet("Store");
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = new SqlCommand(querry, connectionString);
            dataAdapter.Fill(dataSet);
        }

        public string ConnectDB()
        {
            string connect = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\admin\\Source\\Repos\\DanylaKH\\WorkWithDataBase\\WorkWithDataBasw\\Products.mdf;Integrated Security=True";
            return connect;
        }
    }
}
