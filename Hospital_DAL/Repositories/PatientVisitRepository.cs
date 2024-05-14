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
    public class PatientVisitRepository : Repository<PatientVisit>, IPatientVisitRepository
    {
        public PatientVisitRepository(EFDbContext context) : base(context) { }

        public async Task<IEnumerable<PatientVisit>> GetVisitsByDateAsync(DateTime date)
        {
            return await _context.PatientVisits.Where(v => v.Date.Date == date.Date).ToListAsync();
        }
    }
}
