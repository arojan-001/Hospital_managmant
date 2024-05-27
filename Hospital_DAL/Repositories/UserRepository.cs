using Hospital_DAL.EF;
using Hospital_DAL.Entities;
using Hospital_DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Hospital_DAL.Repositories
{
    public class UserRepository : Repository<Login>, IUserRepository
    {
        public UserRepository(EFDbContext context) : base(context) { }

        public async Task<Login> GetByEmailAsync(string email)
        {
            return await _context.Logins.FirstOrDefaultAsync(l => l.Email == email);
        }

        public async Task AddPersonAsync(Person person)
        {
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
        }

        public async Task AddDoctorAsync(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task AddPatientAsync(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
        }
    }
}
