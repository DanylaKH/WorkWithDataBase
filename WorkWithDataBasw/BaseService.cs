using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace WorkWithDataBase
{
    public abstract class BaseSerice<TEntity> 
    {
        public void UpdateInfo(Func<TEntity, SqlCommand> GetCommand, TEntity entity)
        {
            using var sqlConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\admin\\Downloads\\Products.mdf;Integrated Security=True;Connect Timeout=30");
            var command = GetCommand(entity);
            command.Connection = sqlConnection;
            sqlConnection.Open();
            command.ExecuteNonQuery();
        }

        public List<TType> GetData<TType>(string tableName, Func<SqlDataReader, TType> handler)
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

        /*public void DeleteEntity(string tableName, TEntity entity)
        {
            using var sqlConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\admin\\Downloads\\Products.mdf;Integrated Security=True;Connect Timeout=30");
            var command = CreateDeleteCommand(tableName, entity);
            command.Connection = sqlConnection;
            sqlConnection.Open();
            command.ExecuteNonQuery();
        }

        public void UppdateEntity(string tableName, TEntity entity)
        {
            using var sqlConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\admin\\Downloads\\Products.mdf;Integrated Security=True;Connect Timeout=30");
            var command = CreateUpdateCommand(tableName, entity);
            command.Connection = sqlConnection;
            sqlConnection.Open();
            command.ExecuteNonQuery();
        }*/

        protected abstract SqlCommand CreateGetCommand(string tableName);

        public abstract SqlCommand CreateAddCommand(TEntity entity);

        public abstract SqlCommand CreateDeleteCommand(TEntity entity);

        public abstract SqlCommand CreateUpdateCommand(TEntity entity);
    }
}
    
