namespace Hospital_BLL.DTO
{
    public class AppointmentDTO
    {
        public int AppointID { get; set; }
        public int VisitID { get; set; }
        public int Appointment_Status { get; set; }
        public int FeedbackStatus { get; set; }
        public string Disease { get; set; }
        public string Progress { get; set; }
        public string Prescription { get; set; }

        public PatientVisitDTO PatientVisit { get; set; }
    }
}
