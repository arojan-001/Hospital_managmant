using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_BLL.DTO
{
    public class PatientDTO
    {
        public int PatientID { get; set; }
        public int PersonID { get; set; }
        public int TreatmentStatus { get; set; }
        public int? Insurance { get; set; }
        public float? Discount { get; set; }

        public LoginDTO Login { get; set; }
        public PersonDTO Person { get; set; }
        public ICollection<DoctorPatientDTO> DoctorPatients { get; set; }
    }
}
