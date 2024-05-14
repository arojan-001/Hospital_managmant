namespace Hospital_management.Models
{
    using Hospital_managmant.Models;
    using System.ComponentModel.DataAnnotations;

    public class PatientViewModel
    {
        public int PatientID { get; set; }

        [Required]
        public int PersonID { get; set; }

        [Required]
        public int TreatmentStatus { get; set; }

        public int? Insurance { get; set; }
        public float? Discount { get; set; }

        public LoginViewModel Login { get; set; }
        public PersonViewModel Person { get; set; }
        public ICollection<DoctorPatientViewModel> DoctorPatients { get; set; }
    }
}
