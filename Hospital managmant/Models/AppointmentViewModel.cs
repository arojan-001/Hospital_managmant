namespace Hospital_management.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AppointmentViewModel
    {
        public int AppointID { get; set; }

        [Required]
        public int VisitID { get; set; }

        [Required]
        [Display(Name = "Appointment Status")]
        public int AppointmentStatus { get; set; }

        [Required]
        [Display(Name = "Feedback Status")]
        public int FeedbackStatus { get; set; }

        [Required]
        public string Disease { get; set; }

        public string Progress { get; set; }
        public string Prescription { get; set; }

        public PatientVisitViewModel PatientVisit { get; set; }
    }
}
