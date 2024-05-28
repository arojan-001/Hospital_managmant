using Hospital_BLL.DTO;

namespace Hospital_BLL.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDTO>> GetAllDepartmentsAsync();
        Task<DepartmentDTO> GetDepartmentByIdAsync(int id);
        Task AddDepartmentAsync(DepartmentDTO department);
        Task UpdateDepartmentAsync(DepartmentDTO department);
        Task DeleteDepartmentAsync(int id);

        Task SeedDefaultDepartmentsAsync();
    }
}
