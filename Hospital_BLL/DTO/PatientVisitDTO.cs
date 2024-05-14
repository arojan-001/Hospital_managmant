using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_BLL.DTO
{
    public class PatientVisitDTO
    {
        public int ID { get; set; }
        public int? DoctorID { get; set; }
        public int PatientID { get; set; }
        public DateTime Date { get; set; }
        public float Bill_Amount { get; set; }
        public string Bill_Status { get; set; }
        public int? DoctorNotification { get; set; }
        public int? PatientNotification { get; set; }

        public DoctorDTO Doctor { get; set; }
        public PatientDTO Patient { get; set; }
    }
}
