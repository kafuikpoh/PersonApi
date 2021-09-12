using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.DataTransferObjects;
using Entities.Models;

namespace Contracts.Interfaces
{
    public interface IPersonRepository
    {
        public Task<IEnumerable<Person>> GetPeople();
        public Task<Person> GetPerson(int id);
        public Task<Person> CreatePerson(PersonForCreationDto person);
    }
}