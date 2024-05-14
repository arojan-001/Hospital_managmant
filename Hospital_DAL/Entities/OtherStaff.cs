namespace Hospital_DAL.Entities
{
    public class OtherStaff
    {
        public int StaffID { get; set; }
        public int PersonID { get; set; }
        public string Designation { get; set; }
        public string Highest_Qualification { get; set; }
        public float? Salary { get; set; }

        public virtual Person Person { get; set; }
    }

}
