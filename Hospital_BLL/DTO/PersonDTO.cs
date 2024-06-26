﻿namespace Hospital_BLL.DTO
{
    public class PersonDTO
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PatrName { get; set; }

        public string Email;
        public string Phone { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public char Gender { get; set; }
        public string BloodGroup { get; set; }

        public LoginDTO Login { get; set; }
    }

}
