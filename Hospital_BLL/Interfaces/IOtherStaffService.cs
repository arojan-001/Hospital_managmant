using Hospital_BLL.DTO;

namespace Hospital_BLL.Interfaces
{
    public interface IOtherStaffService
    {
        Task<IEnumerable<OtherStaffDTO>> GetAllOtherStaffAsync();
        Task<OtherStaffDTO> GetOtherStaffByIdAsync(int id);
        Task AddOtherStaffAsync(OtherStaffDTO otherStaff);
        Task UpdateOtherStaffAsync(OtherStaffDTO otherStaff);
        Task DeleteOtherStaffAsync(int id);
    }
}
