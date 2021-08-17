using Contracts.Interfaces;
using Entities.Context;

namespace Repositories.Repo
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DapperContext _context;

        public PersonRepository(DapperContext context)
        {
            _context = context;
        }
    }
}