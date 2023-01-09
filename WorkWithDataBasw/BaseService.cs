using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace WorkWithDataBase
{
    public abstract class BaseSerice<TEntity> 
    {
        public void AddEntity(string tableName, TEntity entity)
        {
            using var sqlConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\admin\\Downloads\\Products.mdf;Integrated Security=True;Connect Timeout=30");
            var command = CreateAddCommand(tableName, entity);
            command.Connection = sqlConnection;
            sqlConnection.Open();
            command.ExecuteNonQuery();
        }

        protected List<TType> GetData<TType>(string tableName, Func<SqlDataReader, TType> handler)
        {
            using var sqlConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\admin\\Downloads\\Products.mdf;Integrated Security=True;Connect Timeout=30");
            var command = CreateGetCommand(tableName);
            using var reader = command.ExecuteReader();
            var entities = new List<TType>();

            while (reader.Read())
            {
                var timeEntity = handler(reader);
                entities.Add(timeEntity);
            }

            return entities;
        }

        protected void DeleteEntity(string tableName, TEntity entity)
        {
            using var sqlConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\admin\\Downloads\\Products.mdf;Integrated Security=True;Connect Timeout=30");
            var command = CreateDeleteCommand(tableName, entity);
            command.Connection = sqlConnection;
            sqlConnection.Open();
            command.ExecuteNonQuery();
        }

        protected void UppdateEntity(string tableName, TEntity entity)
        {
            using var sqlConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\admin\\Downloads\\Products.mdf;Integrated Security=True;Connect Timeout=30");
            var command = CreateUpdateCommand(tableName, entity);
            command.Connection = sqlConnection;
            sqlConnection.Open();
            command.ExecuteNonQuery();
        }

        protected abstract SqlCommand CreateGetCommand(string tableName);

        protected abstract SqlCommand CreateAddCommand(string tableName,TEntity entity);

        protected abstract SqlCommand CreateDeleteCommand(string tableName, TEntity entity);

        protected abstract SqlCommand CreateUpdateCommand(string tableName, TEntity entity);
    }
}
    
