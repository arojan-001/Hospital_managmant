namespace Hospital_BLL.DTO
{
    public class OtherStaffDTO
    {
        public int StaffID { get; set; }
        public int PersonID { get; set; }
        public string Designation { get; set; }
        public string Highest_Qualification { get; set; }
        public float? Salary { get; set; }

        public PersonDTO Person { get; set; }
    }

}
