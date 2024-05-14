using Hospital_BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_BLL.Interfaces
{
    public interface IDoctorService
    {
        Task<IEnumerable<DoctorDTO>> GetAllDoctorsAsync();
        Task<DoctorDTO> GetDoctorByIdAsync(int id);
        Task AddDoctorAsync(DoctorDTO doctor);
        Task UpdateDoctorAsync(DoctorDTO doctor);
        Task DeleteDoctorAsync(int id);
    }
}
