using Hospital_DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospital_DAL.Interfaces
{
    public interface IPersonRepository : IRepository<Person>
    {
        Task<IEnumerable<Person>> FindByLastNameAsync(string lastName);
    }
}
