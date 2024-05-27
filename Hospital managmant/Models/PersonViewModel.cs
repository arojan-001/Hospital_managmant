using System;
using System.ComponentModel.DataAnnotations;

namespace Hospital_management.Models
{
    public class PersonViewModel
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } // Autofilled from RegistrationViewModel

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } // Autofilled from RegistrationViewModel

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; } // Autofilled from RegistrationViewModel

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string Email { get; set; } // Autofilled from RegistrationViewModel

        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Gender")]
        public char Gender { get; set; }

        [Display(Name = "Blood Group")]
        public string BloodGroup { get; set; }

        public string Role { get; set; } // Doctor, Patient
    }
}
