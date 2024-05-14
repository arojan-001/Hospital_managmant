using Hospital_BLL.DTO;

namespace Hospital_BLL.Interfaces
{
    public interface IAppointmentService
    {
        Task<IEnumerable<AppointmentDTO>> GetAllAppointmentsAsync();
        Task<AppointmentDTO> GetAppointmentByIdAsync(int id);
        Task AddAppointmentAsync(AppointmentDTO appointment);
        Task UpdateAppointmentAsync(AppointmentDTO appointment);
        Task DeleteAppointmentAsync(int id);
    }
}
