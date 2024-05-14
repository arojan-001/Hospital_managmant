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
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(EFDbContext context) : base(context) { }

        public async Task<IEnumerable<Appointment>> GetUpcomingAppointmentsAsync()
        {
            var today = DateTime.Today;
            return await _context.Appointments.Where(a => a.PatientVisit.Date >= today).ToListAsync();
        }
    }
}
