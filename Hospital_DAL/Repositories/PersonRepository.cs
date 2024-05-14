using Hospital_DAL.EF;
using Hospital_DAL.Entities;
using Hospital_DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_DAL.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(EFDbContext context) : base(context) { }

        public async Task<IEnumerable<Person>> FindByLastNameAsync(string lastName)
        {
            return await _context.Persons.Where(p => p.LastName == lastName).ToListAsync();
        }
    }
}
