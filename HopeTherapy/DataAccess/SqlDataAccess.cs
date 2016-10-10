using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace HopeTherapy.DataAccess
{
    public class SqlDataAccess
    {
        private readonly string _connectionString;

        public SqlDataAccess(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentException("connectionString is null/empty/whitespace");
            }
            _connectionString = connectionString;
        }

        public IEnumerable<T> ExecuteQuery<T>(string sql)
        {
            if (string.IsNullOrWhiteSpace(sql))
            {
                throw new ArgumentException("sql is null/empty/whitespace");
            }
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<T>(sql);
            }
        }

        public T ExecuteQuerySingleResult<T>(string sql)
        {
            return ExecuteQuery<T>(sql).Single();
        }

        public int ExecuteCommand<T>(string sql)
        {
            if (string.IsNullOrWhiteSpace(sql))
            {
                throw new ArgumentException("sql is null/empty/whitespace");
            }
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Execute(sql);
            }
        }
    }
}