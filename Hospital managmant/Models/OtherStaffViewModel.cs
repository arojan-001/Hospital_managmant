namespace Hospital_management.Models
{
    using Hospital_managmant.Models;
    using System.ComponentModel.DataAnnotations;

    public class OtherStaffViewModel
    {
        public int StaffID { get; set; }

        [Required]
        public int PersonID { get; set; }

        [Required]
        public string Designation { get; set; }

        [Display(Name = "Highest Qualification")]
        public string HighestQualification { get; set; }

        public float? Salary { get; set; }

        public PersonViewModel Person { get; set; }
    }
}
