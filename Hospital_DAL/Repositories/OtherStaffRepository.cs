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
    public class OtherStaffRepository : Repository<OtherStaff>, IOtherStaffRepository
    {
        public OtherStaffRepository(EFDbContext context) : base(context) { }

        public async Task<IEnumerable<OtherStaff>> GetStaffByQualificationAsync(string qualification)
        {
            return await _context.OtherStaffs.Where(s => s.Highest_Qualification == qualification).ToListAsync();
        }
    }
}
