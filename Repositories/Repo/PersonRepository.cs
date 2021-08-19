using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.Interfaces;
using Dapper;
using Entities.Context;
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
    }
}