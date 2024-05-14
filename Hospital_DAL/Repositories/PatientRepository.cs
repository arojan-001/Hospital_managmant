using Hospital_DAL.EF;
using Hospital_DAL.Entities;
using Hospital_DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hospital_DAL.Repositories
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(EFDbContext context) : base(context) { }

        public async Task<IEnumerable<Patient>> GetPatientsByDoctorAsync(int doctorId)
        {
            return await _context.Patients
                .Where(p => p.DoctorPatients.Any(dp => dp.DoctorID == doctorId))
                .ToListAsync();
        }
    }
}
