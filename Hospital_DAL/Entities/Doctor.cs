using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_DAL.Entities
{
    public class Doctor
    {
        public int DoctorID { get; set; }
        public int DeptNo { get; set; }
        public int PersonID { get; set; }
        public float Charges_Per_Visit { get; set; }
        public float? MonthlySalary { get; set; }
        public float? ReputeIndex { get; set; }
        public int Patients_Treated { get; set; }
        public string Qualification { get; set; }
        public string Specialization { get; set; }
        public int? Work_Experience { get; set; }
        public int Status { get; set; } // Present = 1, Left = 0

        public virtual Department Department { get; set; }
        public virtual Person Person { get; set; }

        public ICollection<DoctorPatient> DoctorPatients { get; set; } = new List<DoctorPatient>();
    }

}
