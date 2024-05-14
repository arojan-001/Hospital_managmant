namespace Hospital_DAL.Entities
{
    public class PatientVisit
    {
        public int ID { get; set; }
        public int? DoctorID { get; set; }
        public int PatientID { get; set; }
        public DateTime Date { get; set; }
        public float Bill_Amount { get; set; }
        public string Bill_Status { get; set; }
        public int? DoctorNotification { get; set; }
        public int? PatientNotification { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
    }

}
