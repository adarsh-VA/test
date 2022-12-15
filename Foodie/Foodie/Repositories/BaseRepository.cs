using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;

namespace Foodie
    .Repository
{
    public class BaseRepository<T> where T : class
    {
        private string _connectionString;

        public BaseRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("FoodieDB");
        }

        public List<T> GetAll(string query)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<T>(query).ToList();
            }      
        }
        public List<T> GetWithValue(string query, object values)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<T>(query, values).ToList();
            }
        }

        public T Get(string query,object values)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<T>(query,values);
            }
        }

        public int Add(string procedure,object values)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.ExecuteScalar<int>(procedure, values, commandType: CommandType.StoredProcedure);
            }
        }
        

        public void ExecuteQuery(string query, object values) 
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, values);
            }
        }

    }
}
