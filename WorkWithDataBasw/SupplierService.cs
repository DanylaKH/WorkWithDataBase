using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace WorkWithDataBase
{
    class SupplierService : BaseSerice<Supplier>
    {
        private List<Supplier> Suppliers;

        Supplier test1 = new Supplier();

        public void FillData()
        {
            Suppliers = GetData(test1, x => new Supplier { Id = (int)x["SuppliersId"], Name = x["SuppliersName"].ToString() });
        }

        protected override SqlCommand CreateCommand(Supplier entity, string action)
        {
            if (action == "get")
            {
                var command = new SqlCommand("select * from  @tableName ");
                command.Parameters.AddWithValue("@tableName", "Suppliers");
                return command;
            }
            if (action == "delete")
            {
                var command = new SqlCommand("delete from @tableName where SuppliersName = @supplierName");
                command.Parameters.AddWithValue("@tableName", "Suppliers");
                Console.WriteLine("Write the name of the supplier to be removed");
                string supplierName = Console.ReadLine();
                command.Parameters.AddWithValue("@supplierName", supplierName);
                return command;
            }
            if (action == "update")
            {
                var command = new SqlCommand("update @tableName set SuppliersName = @newSupplerName, SuppliersProduct = @newSupplierProduct, SuppliersAmount = @newSupplierAmount, SuppliersID = @newSupplierID where SuppliersName = @supplierName");
                command.Parameters.AddWithValue("@tableName", "Suppliers");
                Console.WriteLine("write the name of the replacement supplier");
                string supplierName = Console.ReadLine();
                command.Parameters.AddWithValue("@supplierName", supplierName);
                Console.WriteLine("Write the new supplier name");
                string newSupplerName = Console.ReadLine();
                command.Parameters.AddWithValue("@newSupplerName", newSupplerName);
                Console.WriteLine("Write the new supplier product (int)");
                string newSupplierProduct = Console.ReadLine();
                command.Parameters.AddWithValue("@newSupplierProduct", newSupplierProduct);
                Console.WriteLine("Write the new amount (int)");
                string newSupplierAmount = Console.ReadLine();
                command.Parameters.AddWithValue("@newSupplierAmount", newSupplierAmount);
                Console.WriteLine("Write the new supplierID (int)");
                string newSupplierID = Console.ReadLine();
                command.Parameters.AddWithValue("@newSupplierID", newSupplierID);
                return command;
            }
            else
            {
                var command = new SqlCommand("INSERT INTO @tableName(SuppliersName, SuppliersProduct, SuppliersAmount, SuppliersID) VALUES( @SuppliersName, @SuppliersProduct, @SuppliersAmount, @SuppliersID)");
                command.Parameters.AddWithValue("@tableName", "Suppliers");
                Console.WriteLine("Insert Supplier Name");
                string supplierName = Console.ReadLine();
                command.Parameters.AddWithValue("@SuppliersName", supplierName);
                Console.WriteLine("Insert Supplier Product (int)");
                string suppliersProduct = Console.ReadLine();
                command.Parameters.AddWithValue("@SuppliersProduct", suppliersProduct);
                Console.WriteLine("Insert Supplier Amount (int)");
                string suppliersAmount = Console.ReadLine();
                command.Parameters.AddWithValue("@SuppliersAmount", suppliersAmount);
                Console.WriteLine("Insert SupplierID (int)");
                string suppliersID = Console.ReadLine();
                command.Parameters.AddWithValue("@SuppliersID", suppliersID);
                return command;
            }
        }
    }
}
