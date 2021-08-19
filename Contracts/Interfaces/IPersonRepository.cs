using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts.Interfaces
{
    public interface IPersonRepository
    {
        public Task<IEnumerable<Person>> GetPeople();
    }
}