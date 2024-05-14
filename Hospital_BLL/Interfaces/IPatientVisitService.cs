using Hospital_BLL.DTO;

namespace Hospital_BLL.Interfaces
{
    public interface IPatientVisitService
    {
        Task<IEnumerable<PatientVisitDTO>> GetAllPatientVisitsAsync();
        Task<PatientVisitDTO> GetPatientVisitByIdAsync(int id);
        Task AddPatientVisitAsync(PatientVisitDTO patientVisit);
        Task UpdatePatientVisitAsync(PatientVisitDTO patientVisit);
        Task DeletePatientVisitAsync(int id);
    }
}
