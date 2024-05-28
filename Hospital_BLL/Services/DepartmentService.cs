using AutoMapper;
using Hospital_BLL.DTO;
using Hospital_BLL.Interfaces;
using Hospital_DAL.Interfaces;
using Hospital_DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospital_BLL.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DepartmentDTO>> GetAllDepartmentsAsync()
        {
            var departments = await _departmentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DepartmentDTO>>(departments);
        }

        public async Task<DepartmentDTO> GetDepartmentByIdAsync(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);
            return _mapper.Map<DepartmentDTO>(department);
        }

        public async Task AddDepartmentAsync(DepartmentDTO departmentDto)
        {
            var department = _mapper.Map<Department>(departmentDto);
            await _departmentRepository.AddAsync(department);
        }

        public async Task UpdateDepartmentAsync(DepartmentDTO departmentDto)
        {
            var department = await _departmentRepository.GetByIdAsync(departmentDto.DeptNo);
            if (department != null)
            {
                _mapper.Map(departmentDto, department);
                await _departmentRepository.UpdateAsync(department);
            }
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            await _departmentRepository.DeleteAsync(id);
        }
        public async Task SeedDefaultDepartmentsAsync()
        {
            var defaultDepartments = new List<DepartmentDTO>
            {
                new DepartmentDTO { DeptName = "Cardiology", Description = "Department of heart-related treatments" },
                new DepartmentDTO { DeptName = "Neurology", Description = "Department of brain and nerve-related treatments" },
                new DepartmentDTO { DeptName = "Pediatrics", Description = "Department for child care" },
                new DepartmentDTO { DeptName = "Orthopedics", Description = "Department for bone and muscle-related treatments" }
            };

            foreach (var departmentDto in defaultDepartments)
            {
                var existingDepartment = await _departmentRepository.SearchByDepartmentNameAsync(departmentDto.DeptName);
                if (existingDepartment == null)
                {
                    var department = _mapper.Map<Department>(departmentDto);
                    await _departmentRepository.AddAsync(department);
                }
            }
        }
    }
}
