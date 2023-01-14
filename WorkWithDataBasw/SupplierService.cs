using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace WorkWithDataBase
{
    class SupplierService : BaseSerice<Supplier>
    {
        private List<Supplier> Suppliers;

        public void FillData()
        {
            Suppliers = GetData(x => new Supplier { Id = (int)x["SuppliersId"], Name = x["SuppliersName"].ToString() });
        }

        protected override SqlCommand CreateAddCommand(Supplier entity)
        {
            var command = new SqlCommand("INSERT INTO @tableName(SuppliersName, SuppliersProduct, SuppliersAmount, SuppliersID) VALUES( @SuppliersName, @SuppliersProduct, @SuppliersAmount, @SuppliersID)");
            command.Parameters.AddWithValue("@tableName", "Suppliers");
            command.Parameters.AddWithValue("@SuppliersName", entity.Name);
            Console.WriteLine("Insert Supplier Product (int)");
            string suppliersProduct = Console.ReadLine();
            command.Parameters.AddWithValue("@SuppliersProduct", suppliersProduct);
            Random rnd = new Random();
            string suppliersAmount = Convert.ToString(rnd.Next(100, 700));
            command.Parameters.AddWithValue("@SuppliersAmount", suppliersAmount);
            command.Parameters.AddWithValue("@SuppliersID", entity.Id);
            return command;
        }

        protected override SqlCommand CreateDeleteCommand(Supplier entity)
        {
            var command = new SqlCommand("delete from @tableName where SuppliersName = @supplierName");
            command.Parameters.AddWithValue("@tableName", "Suppliers");
            command.Parameters.AddWithValue("@supplierName", entity.Name);
            return command;
        }

        protected override SqlCommand CreateGetCommand()
        {
            var command = new SqlCommand("select * from  @tableName ");
            command.Parameters.AddWithValue("@tableName", "Suppliers");
            return command;
        }

        protected override SqlCommand CreateUpdateCommand(Supplier entity)
        {
            var command = new SqlCommand("update @tableName set SuppliersName = @newSupplerName, SuppliersProduct = @newSupplierProduct, SuppliersAmount = @newSupplierAmount, SuppliersID = @newSupplierID where SuppliersName = @supplierName");
            command.Parameters.AddWithValue("@tableName", "Suppliers");
            Console.WriteLine("write the name of the replacement supplier");
            string supplierName = Console.ReadLine();
            command.Parameters.AddWithValue("@supplierName", entity.Name);
            Console.WriteLine("Write the new supplier name");
            string newSupplerName = Console.ReadLine();
            command.Parameters.AddWithValue("@newSupplerName", newSupplerName);
            Console.WriteLine("Write the new supplier product (int)");
            string newSupplierProduct = Console.ReadLine();
            command.Parameters.AddWithValue("@newSupplierProduct", newSupplierProduct);
            Random rnd = new Random();
            string newSupplierAmount = Convert.ToString(rnd.Next(100, 700));
            command.Parameters.AddWithValue("@newSupplierAmount", newSupplierAmount);
            Console.WriteLine("Write the new supplierID (int)");
            string newSupplierID = Console.ReadLine();
            command.Parameters.AddWithValue("@newSupplierID", newSupplierID);
            return command;
        }
    }
}
