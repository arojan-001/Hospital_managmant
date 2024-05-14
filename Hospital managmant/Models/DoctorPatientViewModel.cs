namespace Hospital_management.Models
{
    using Hospital_managmant.Models.Hospital_management.Models;
    using System.ComponentModel.DataAnnotations;

    public class DoctorPatientViewModel
    {
        [Required]
        public int DoctorID { get; set; }

        [Required]
        public int PatientID { get; set; }

        public DoctorViewModel Doctor { get; set; }
        public PatientViewModel Patient { get; set; }
    }
}
