using Dapper;
using Persons.Service.Read.DomainModelLayer;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Persons.Service.Read.InfrastructureLayer
{
    public class ReadRepository: IReadRepository
    {
        private readonly string _connectionString;

        public ReadRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Person GetById(Guid id)
        {
            Person person = null;

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                person = db.QueryFirstOrDefault<Person>("SELECT TOP (1) * FROM Persons WHERE Id = @id", new { id });
            }

            return person;
        }
    }
}
