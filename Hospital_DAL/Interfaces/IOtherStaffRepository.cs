using Hospital_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_DAL.Interfaces
{
    public interface IOtherStaffRepository : IRepository<OtherStaff>
    {
        Task<IEnumerable<OtherStaff>> GetStaffByQualificationAsync(string qualification);
    }
}
