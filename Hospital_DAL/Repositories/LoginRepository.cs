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
    public class LoginRepository : Repository<Login>, ILoginRepository
    {
        public LoginRepository(EFDbContext context) : base(context) { }

        public async Task<Login> FindByEmailAsync(string email)
        {
            return await _context.Logins.FirstOrDefaultAsync(l => l.Email == email);
        }
    }

}
