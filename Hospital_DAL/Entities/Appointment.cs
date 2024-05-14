namespace Hospital_DAL.Entities
{
    public class Appointment
    {
        public int AppointID { get; set; }
        public int VisitID { get; set; }
        public int Appointment_Status { get; set; }
        public int FeedbackStatus { get; set; }
        public string Disease { get; set; }
        public string Progress { get; set; }
        public string Prescription { get; set; }

        public virtual PatientVisit PatientVisit { get; set; }
    }

}
