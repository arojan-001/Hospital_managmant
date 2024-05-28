using System.Collections.Generic;

namespace Hospital_management.Models
{
    public class AdminViewModel
    {
        public IEnumerable<DepartmentViewModel> Departments { get; set; }
        public IEnumerable<DoctorViewModel> Doctors { get; set; }
    }
}
