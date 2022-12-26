using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace WorkWithDataBase
{
    abstract class BaseSerice<TEntity> 
    {
        public void AddEntity(TEntity entity)
        {
            using var sqlConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\admin\\Downloads\\Products.mdf;Integrated Security=True;Connect Timeout=30");
            var command = CreateCommand(entity);
            command.Connection = sqlConnection;
            sqlConnection.Open();
            command.ExecuteNonQuery();
        }
        protected abstract SqlCommand CreateCommand(TEntity entity);
    }
}
    
