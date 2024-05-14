namespace Hospital_DAL.Entities
{
    public class Person
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PatrName { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public char Gender { get; set; }
        public string BloodGroup { get; set; }

        public virtual Login Login { get; set; }
    }

}
