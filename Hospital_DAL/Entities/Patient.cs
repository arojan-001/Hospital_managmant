namespace Hospital_DAL.Entities
{
    public class Patient
    {
        public int PatientID { get; set; }
        public int PersonID { get; set; }
        public int TreatmentStatus { get; set; }
        public int? Insurance { get; set; }
        public float? Discount { get; set; }
        public virtual Person Person { get; set; }
        public ICollection<DoctorPatient> DoctorPatients { get; set; } = new List<DoctorPatient>();
    }
}
