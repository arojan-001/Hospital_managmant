using Hospital_DAL.Entities;
using System.Threading.Tasks;

namespace Hospital_DAL.Interfaces
{
    public interface IUserRepository : IRepository<Login>
    {
        Task<Login> GetByEmailAsync(string email);
        Task AddPersonAsync(Person person);
        Task AddDoctorAsync(Doctor doctor);
        Task AddPatientAsync(Patient patient);
    }
}
