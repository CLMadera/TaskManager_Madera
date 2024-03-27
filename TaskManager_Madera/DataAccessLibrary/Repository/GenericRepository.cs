using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using DataAccessLibrary.Context;

namespace DataAccessLibrary.Repository
{
    public class GenericRepository<TModel> : IGenericRepository<TModel>
    {
        private readonly IDapperContext _dapperContext;

        public GenericRepository(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public TModel Get(int id)
        {
            using IDbConnection dbConnection = _dapperContext.CreateConnection();
            string query = "SELECT * FROM TableName WHERE Id = @Id";
            return dbConnection.QueryFirstOrDefault<TModel>(query, new { Id = id });
        }

        public IEnumerable<TModel> GetAll()
        {
            using IDbConnection dbConnection = _dapperContext.CreateConnection();
            string query = "SELECT * FROM TableName";
            return dbConnection.Query<TModel>(query);
        }

        public int Create(TModel model)
        {
            using IDbConnection dbConnection = _dapperContext.CreateConnection();
            string query = @"INSERT INTO TableName (/* columns */) VALUES (/* values */);
            return dbConnection.Execute(query, model);
        }

        public bool Update(TModel model)
        {
            using IDbConnection dbConnection = _dapperContext.CreateConnection();
            string query = @"UPDATE TableName SET /* update columns */ WHERE Id = @Id";
            int rowsAffected = dbConnection.Execute(query, model);
            return rowsAffected > 0;
        }

        public bool Delete(int id)
        {
            using IDbConnection dbConnection = _dapperContext.CreateConnection();
            string query = "DELETE FROM TableName WHERE Id = @Id";
            int rowsAffected = dbConnection.Execute(query, new { Id = id });
            return rowsAffected > 0;
        }
    }
}