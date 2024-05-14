using Hospital_management.Models;
namespace Hospital_managmant.Models
{
    namespace Hospital_management.Models
    {
        
        using System.ComponentModel.DataAnnotations;

        public class DoctorViewModel
        {
            public int DoctorID { get; set; }

            [Required]
            public int DeptNo { get; set; }

            [Required]
            public int PersonID { get; set; }

            [Required]
            [Display(Name = "Charges Per Visit")]
            public float ChargesPerVisit { get; set; }

            [Display(Name = "Monthly Salary")]
            public float? MonthlySalary { get; set; }

            [Display(Name = "Repute Index")]
            public float? ReputeIndex { get; set; }

            [Required]
            [Display(Name = "Patients Treated")]
            public int PatientsTreated { get; set; }

            [Required]
            public string Qualification { get; set; }

            [Required]
            public string Specialization { get; set; }

            [Display(Name = "Work Experience")]
            public int? WorkExperience { get; set; }

            [Required]
            public int Status { get; set; } // Present = 1, Left = 0

            public DepartmentViewModel Department { get; set; }
            public PersonViewModel Person { get; set; }
        }
    }

}
