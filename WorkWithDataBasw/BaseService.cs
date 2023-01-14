using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace WorkWithDataBase
{
    public abstract class BaseSerice<TEntity> 
    {
        private void UpdateInfo(Func<TEntity, SqlCommand> GetCommand, TEntity entity)
        {
            using var sqlConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\admin\\Downloads\\Products.mdf;Integrated Security=True;Connect Timeout=30");
            var command = GetCommand(entity);
            command.Connection = sqlConnection;
            sqlConnection.Open();
            command.ExecuteNonQuery();
        }

        public List<TType> GetData<TType>(Func<SqlDataReader, TType> handler)
        {
            using var sqlConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\admin\\Downloads\\Products.mdf;Integrated Security=True;Connect Timeout=30");
            var command = CreateGetCommand();
            using var reader = command.ExecuteReader();
            var entities = new List<TType>();

            while (reader.Read())
            {
                var timeEntity = handler(reader);
                entities.Add(timeEntity);
            }

            return entities;
        }

        public void Update(TEntity entity)
        {
            UpdateInfo(CreateUpdateCommand, entity);
        }

        public void Delete(TEntity entity)
        {
            UpdateInfo(CreateDeleteCommand, entity);
        }

        public void Add(TEntity entity)
        {
            UpdateInfo(CreateAddCommand, entity);
        }
        protected abstract SqlCommand CreateGetCommand();

        protected abstract SqlCommand CreateAddCommand(TEntity entity);

        protected abstract SqlCommand CreateDeleteCommand(TEntity entity);

        protected abstract SqlCommand CreateUpdateCommand(TEntity entity);
    }
}
    
