using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Contracts.Interfaces;
using Dapper;
using Entities.Context;
using Entities.DataTransferObjects;
using Entities.Models;

namespace Repositories.Repo
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DapperContext _context;

        public PersonRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Person>> GetPeople()
        {
            var query = "SELECT * FROM Person";

            using (var connection = _context.CreateConnection())
            {
                var people = await connection.QueryAsync<Person>(query);
                return people.ToList();
            }
        }

        public async Task<Person> GetPerson(int id)
        {
            var query = "SELECT * FROM Person where person_id = @id";

            using (var connection = _context.CreateConnection())
            {
                var person = await connection.QuerySingleOrDefaultAsync<Person>(query, new { id });

                return person;
            }
        }

        public async Task<Person> CreatePerson(PersonForCreationDto person)
        {
            var query =
                "INSERT INTO Person (fname, lname, birth_date, phone_number) VALUES (@FName, @LName, @Birth_Date, @Phone_Number);" + 
                "SELECT LAST_INSERT_ID()";
            
            var parameters = new DynamicParameters();
            parameters.Add("fname", person.FName, DbType.String);
            parameters.Add("lname", person.LName, DbType.String);
            parameters.Add("birth_date", person.Birth_Date, DbType.String);
            parameters.Add("phone_number", person.Phone_Number, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);
                
                var createdPerson = new Person
                {
                    Person_Id = id,
                    FName = person.FName,
                    LName = person.LName,
                    Birth_Date = DateTime.Parse(person.Birth_Date),
                    Phone_Number = person.Phone_Number
                };

                return createdPerson;
            }
        }
    }
}