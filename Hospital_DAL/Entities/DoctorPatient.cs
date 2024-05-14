namespace Hospital_DAL.Entities
{
    public class DoctorPatient
    {
        public int DoctorID { get; set; }
        public int PatientID { get; set; }

        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
    }
}
