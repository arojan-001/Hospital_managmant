using Hospital_BLL.DTO;

namespace Hospital_BLL.Interfaces
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientDTO>> GetAllPatientsAsync();
        Task<PatientDTO> GetPatientByIdAsync(int id);
        Task AddPatientAsync(PatientDTO patient);
        Task UpdatePatientAsync(PatientDTO patient);
        Task DeletePatientAsync(int id);
    }
}
