namespace Hospital_BLL.DTO
{
    public class DoctorPatientDTO
    {
        public int DoctorID { get; set; }
        public int PatientID { get; set; }

        public DoctorDTO Doctor { get; set; }
        public PatientDTO Patient { get; set; }
    }
}
