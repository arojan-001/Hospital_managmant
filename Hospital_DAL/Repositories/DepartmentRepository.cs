using Hospital_DAL.EF;
using Hospital_DAL.Entities;
using Hospital_DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_DAL.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(EFDbContext context) : base(context) { }

        public async Task<IEnumerable<Department>> SearchByDepartmentNameAsync(string deptName)
        {
            return await _context.Departments.Where(d => d.DeptName.Contains(deptName)).ToListAsync();
        }
    }
}
