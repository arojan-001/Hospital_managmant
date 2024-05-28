namespace Hospital_management.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class PatientVisitViewModel
    {
        public int ID { get; set; }

        [Required]
        public int? DoctorID { get; set; }

        [Required]
        public int PatientID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Bill Amount")]
        public float BillAmount { get; set; }

        [Required]
        [Display(Name = "Bill Status")]
        public string BillStatus { get; set; }

        public int? DoctorNotification { get; set; }
        public int? PatientNotification { get; set; }

        public DoctorViewModel Doctor { get; set; }
        public PatientViewModel Patient { get; set; }
    }
}
