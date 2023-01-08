using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace WorkWithDataBase
{
    public abstract class BaseSerice<TEntity> 
    {
        public void AddEntity(TEntity entity)
        {
            using var sqlConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\admin\\Downloads\\Products.mdf;Integrated Security=True;Connect Timeout=30");
            var command = CreateCommand(entity, "add");
            command.Connection = sqlConnection;
            sqlConnection.Open();
            command.ExecuteNonQuery();
        }

        protected List<TType> GetData<TType>(TEntity entity, Func<SqlDataReader, TType> handler)
        {
            using var sqlConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\admin\\Downloads\\Products.mdf;Integrated Security=True;Connect Timeout=30");
            var command = CreateCommand(entity, "get");
            using var reader = command.ExecuteReader();
            var entities = new List<TType>();

            while (reader.Read())
            {
                var timeEntity = handler(reader);
                entities.Add(timeEntity);
            }

            return entities;
        }

        protected void DeleteEntity(TEntity entity)
        {
            using var sqlConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\admin\\Downloads\\Products.mdf;Integrated Security=True;Connect Timeout=30");
            var command = CreateCommand(entity, "delete");
            command.Connection = sqlConnection;
            sqlConnection.Open();
            command.ExecuteNonQuery();
        }

        protected void UppdateEntity(TEntity entity)
        {
            using var sqlConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\admin\\Downloads\\Products.mdf;Integrated Security=True;Connect Timeout=30");
            var command = CreateCommand(entity, "update");
            command.Connection = sqlConnection;
            sqlConnection.Open();
            command.ExecuteNonQuery();
        }

        protected abstract SqlCommand CreateCommand(TEntity entity, string action);
    }
}
    
