using Dapper;
using Persons.Service.Write.DomainModelLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Persons.Service.Write.InfrastructureLayer
{
    public class WriteRepository : IWriteRepository
    {
        private readonly string _connectionString;

        public WriteRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Person Find(Guid id)
        {
            Person person = null;

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                person = db.QueryFirstOrDefault<Person>("SELECT TOP (1) * FROM Persons WHERE Id = @id", new { id });
            }

            return person;
        }

        public void Insert(Person item)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "INSERT INTO Persons(Id, Name, BirthDay) VALUES (@Id, @Name, @BirthDay)";
                db.Execute(sqlQuery, item);
            }
        }
    }
}
